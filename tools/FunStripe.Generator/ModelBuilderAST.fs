namespace FunStripe

open FSharp.Data
open FSharp.Data.JsonExtensions
open System
open System.IO
open System.Linq
open System.Text.RegularExpressions
open Fabulous.AST
open type Fabulous.AST.Ast

///IR types and widget builders for AST-based model code generation
module ModelBuilderAST =

    // --- reuse all parsing and helper functions from ModelParsing ---
    open ModelParsing

    // --- flat type-definition model ---

    /// Represents a single parsed union case for enum/DU generation
    type EnumCaseInfo = {
        /// The raw value (e.g. "1.0.2", "none", "Ach", "String of string")
        RawValue: string
        /// The escaped case name (e.g. "Numeric102", "None'", "Ach")
        CaseName: string
        /// If the case needs a JsonPropertyName attribute, the original string value
        JsonUnionCaseValue: string option
        /// If the case has a payload, the payload type name
        PayloadType: string option
    }

    /// Represents a single record field
    type FieldInfo = {
        /// XML doc comment lines (empty list if no description)
        DocLines: string list
        /// The F# field name (PascalCase)
        FieldName: string
        /// The F# type string (e.g. "string", "int option", "DateTime option")
        FieldType: string
        /// JsonPropertyName attribute value, if needed (e.g. "last4")
        JsonFieldName: string option
    }

    /// Represents a parameter in the static New member
    type ParamInfo = {
        /// The camelCase parameter name (may be backtick-escaped)
        ParamName: string
        /// The PascalCase field name (for RecordFieldExpr)
        PascalFieldName: string
        /// The parameter type string
        ParamType: string
        /// Whether this is an optional parameter (prefixed with ?)
        IsOptional: bool
        /// Whether to append |> Option.flatten in the body
        NeedsFlatten: bool
        /// Whether to add //required comment
        IsRequired: bool
    }

    /// Represents a static/instance member on a type
    type MemberInfo = {
        /// XML doc comment lines
        DocLines: string list
        /// The member name in PascalCase
        MemberName: string
        /// Whether the member name needs a JsonPropertyName attribute
        JsonFieldName: string option
        /// The string literal value (for `member _.Object = "value"`)
        Value: string
    }

    /// A flat, non-recursive type definition
    type TypeDef =
        /// A simple enum (no payloads) — goes to front buffer; gets [<Struct>] if < 6 members
        | SimpleEnum of name: string * cases: EnumCaseInfo list * isStruct: bool
        /// A DU with payloads (AnyOf pattern) — goes to main buffer; uses `and` keyword
        | PayloadEnum of name: string * cases: EnumCaseInfo list
        /// A record type with fields and possibly members — goes to main or front buffer
        | RecordType of name: string * description: string list * fields: FieldInfo list * members: MemberInfo list * newParams: ParamInfo list * isSimple: bool
        /// An empty type with only static members (e.g. `type X () = member _.Foo = "bar"`)
        | EmptyType of name: string * description: string list * members: MemberInfo list * isSimple: bool

    /// Get the name of a TypeDef
    let getTypeName = function
        | SimpleEnum(name, _, _) -> name
        | PayloadEnum(name, _) -> name
        | RecordType(name, _, _, _, _, _) -> name
        | EmptyType(name, _, _, _) -> name

    // --- flatten the parsed Values into a flat list of TypeDefs ---

    /// Parse an enum raw value into an EnumCaseInfo
    let parseEnumCase (rawValue: string) : EnumCaseInfo =
        if rawValue.Contains(" of ") then
            // Payload case like "String of string"
            let parts = rawValue.Split([| " of " |], 2, StringSplitOptions.None)
            let caseName = parts.[0] |> pascalCasify
            let payloadType = parts.[1]
            { RawValue = rawValue; CaseName = caseName; JsonUnionCaseValue = None; PayloadType = Some payloadType }
        elif Regex.IsMatch(rawValue, @"^\p{Lu}") || Regex.IsMatch(rawValue, @"^\d") || rawValue.Contains("-") || rawValue.Contains(" ") || rawValue.Contains(".") || Regex.IsMatch(rawValue, @"[a-zA-Z]\d+(?![a-z])") || Regex.IsMatch(rawValue, @"(^[a-zA-Z]_|_[a-zA-Z]_|_[a-zA-Z]$)") then
            let caseName = rawValue |> clean |> pascalCasify |> escapeNumeric
            { RawValue = rawValue; CaseName = caseName; JsonUnionCaseValue = Some rawValue; PayloadType = None }
        elif rawValue = "none" then
            { RawValue = rawValue; CaseName = $"{rawValue |> pascalCasify}'"; JsonUnionCaseValue = Some rawValue; PayloadType = None }
        else
            let caseName = rawValue |> clean |> pascalCasify
            { RawValue = rawValue; CaseName = caseName; JsonUnionCaseValue = None; PayloadType = None }

    /// Build a FieldInfo from a Value
    let buildFieldInfo (v: Value) : FieldInfo =
        let optionSuffix = if v.Required && (v.Nullable |> not) then "" else " option"
        // Only emit [<JsonPropertyName>] for fields where SnakeCaseNamingPolicy would mangle embedded digits
        let jsonFieldName = if Regex.IsMatch(v.Name, @"(?<!_)\d") then Some v.Name else None
        let docLines =
            if v.Description |> String.IsNullOrWhiteSpace then []
            else v.Description.Replace("\n\n", "\n").Split('\n') |> Array.toList
        { DocLines = docLines; FieldName = v.Name |> pascalCasify; FieldType = $"{v.Type}{optionSuffix}"; JsonFieldName = jsonFieldName }

    /// Build a ParamInfo from a Value
    let buildParamInfo (v: Value) : ParamInfo =
        let flatten = (v.Required |> not) && v.Nullable
        let optionalNullable = if v.Nullable then " option" else ""
        { ParamName = v.Name |> camelCasify |> escapeReservedName; PascalFieldName = v.Name |> pascalCasify; ParamType = $"{v.Type}{optionalNullable}"; IsOptional = not v.Required; NeedsFlatten = flatten; IsRequired = v.Required }

    /// Build a MemberInfo from a static-value Value
    let buildMemberInfo (v: Value) : MemberInfo =
        let docLines =
            if v.Description |> String.IsNullOrWhiteSpace then []
            else v.Description.Replace("\n\n", "\n").Split('\n') |> Array.toList
        let jsonFieldName = if Regex.IsMatch(v.Name, @"(?<!_)\d") then Some v.Name else None
        { DocLines = docLines; MemberName = v.Name |> pascalCasify; JsonFieldName = jsonFieldName; Value = v.StaticValue.Value }

    /// Convert parsed type definitions into a flat list of TypeDefs.
    let flattenTypeDefinitions (typeDefinitions: (string * string * Value array) array) : TypeDef list =
        let result = ResizeArray<TypeDef>()

        let rec processValues (name: string) (description: string) (values: Value array) =
            // Process the main type (skip lists and hidden containers)
            if not (name.EndsWith " list" || name.EndsWith " hide") then
                let dynamicValues = values |> Array.filter (fun v -> v.StaticValue.IsNone)
                let staticValues = values |> Array.filter (fun v -> v.StaticValue.IsSome)
                let nonTrivialTypes = values |> Array.exists (fun x -> not (basicTypes |> Set.contains x.Type))
                let isSimple = not nonTrivialTypes

                let descLines =
                    if description |> String.IsNullOrWhiteSpace then []
                    else description.Replace("\n\n", "\n").Split('\n') |> Array.toList

                let members = staticValues |> Array.map buildMemberInfo |> Array.toList

                if dynamicValues |> Array.isEmpty then
                    // Empty type (no record fields, only members)
                    result.Add(EmptyType(name |> pascalCasify, descLines, members, isSimple))
                else
                    // Record type with fields
                    let fields = dynamicValues |> Array.map buildFieldInfo |> Array.toList
                    let sortedForNew = dynamicValues |> Array.sortBy (fun v -> ((if v.Required then 1 else 2), v.Name))
                    let newParams = sortedForNew |> Array.map buildParamInfo |> Array.toList
                    result.Add(RecordType(name |> pascalCasify, descLines, fields, members, newParams, isSimple))

            // Process any enumerations
            for v in values do
                if v.EnumValues.IsSome then
                    let enumName =
                        let n = v.Type
                        if n.EndsWith "'DU" then n.Replace("'DU", "") else n
                    let cases = v.EnumValues.Value |> List.map parseEnumCase
                    let hasPayloads = cases |> List.exists (fun c -> c.PayloadType.IsSome)
                    if hasPayloads then
                        result.Add(PayloadEnum(enumName, cases))
                    else
                        let isStruct = cases.Length < 6
                        result.Add(SimpleEnum(enumName, cases, isStruct))

            // Process any sub-values recursively
            for v in values do
                if v.SubValues.IsSome then
                    processValues v.Type v.Description v.SubValues.Value

        // Process all top-level type definitions
        for (name, desc, values) in typeDefinitions do
            processValues name desc values

        result |> Seq.toList

    // --- topological ordering to minimise recursive type groups ---

    /// Extract the core Stripe type name from a type string,
    /// stripping 'option' and 'list' suffixes.
    let extractCoreType (s: string) =
        s.Replace(" option", "").Replace(" list", "").Trim()

    /// Get the set of Stripe type names that a TypeDef depends on.
    let getTypeDependencies (allNames: Set<string>) (td: TypeDef) : Set<string> =
        let selfName = getTypeName td
        let depTypes =
            match td with
            | SimpleEnum _ -> []
            | PayloadEnum(_, cases) ->
                cases |> List.choose (fun c -> c.PayloadType) |> List.map extractCoreType
            | RecordType(_, _, fields, _, _, _) ->
                fields |> List.map (fun f -> extractCoreType f.FieldType)
            | EmptyType _ -> []
        depTypes
        |> List.filter (fun t -> allNames.Contains t && t <> selfName)
        |> Set.ofList

    /// Threaded state for Tarjan's SCC algorithm.
    type private TarjanState = {
        Index: int
        Stack: string list
        Disc: Map<string, int>
        Low: Map<string, int>
        OnStack: Set<string>
        Sccs: string list list
    }

    /// Functional Tarjan's SCC algorithm over a string dependency graph.
    /// Returns SCCs in topological order (dependencies before dependents).
    let private tarjanScc (graph: Map<string, Set<string>>) : string list list =
        let rec strongConnect v state =
            let i = state.Index
            let state = {
                state with
                    Index = i + 1
                    Stack = v :: state.Stack
                    Disc = Map.add v i state.Disc
                    Low = Map.add v i state.Low
                    OnStack = Set.add v state.OnStack
            }
            let state =
                graph
                |> Map.tryFind v
                |> Option.defaultValue Set.empty
                |> Set.fold
                    (fun st w ->
                        if not (Map.containsKey w st.Disc) then
                            let st = strongConnect w st
                            { st with Low = Map.add v (min (Map.find v st.Low) (Map.find w st.Low)) st.Low }
                        elif Set.contains w st.OnStack then
                            { st with Low = Map.add v (min (Map.find v st.Low) (Map.find w st.Disc)) st.Low }
                        else
                            st)
                    state
            if Map.find v state.Low = Map.find v state.Disc then
                let idx = state.Stack |> List.findIndex ((=) v)
                let scc = state.Stack |> List.take (idx + 1) |> List.rev
                { state with
                    Stack = state.Stack |> List.skip (idx + 1)
                    OnStack = scc |> List.fold (fun s w -> Set.remove w s) state.OnStack
                    Sccs = scc :: state.Sccs }
            else
                state

        let initial = { Index = 0; Stack = []; Disc = Map.empty; Low = Map.empty; OnStack = Set.empty; Sccs = [] }
        (graph
         |> Map.keys
         |> Seq.fold
             (fun state v ->
                 if Map.containsKey v state.Disc then state
                 else strongConnect v state)
             initial)
            .Sccs
        |> List.rev

    /// Topologically order type definitions using Tarjan's SCC algorithm,
    /// minimising the use of recursive ('and') type keywords.
    /// Returns a list of (TypeDef * isRecursive) pairs in dependency order.
    let topologicallyOrder (typeDefs: TypeDef list) : (TypeDef * bool) list =
        let nameToTd = typeDefs |> List.map (fun td -> getTypeName td, td) |> Map.ofList
        let allNames = typeDefs |> List.map getTypeName |> Set.ofList
        let deps = typeDefs |> List.map (fun td -> getTypeName td, getTypeDependencies allNames td) |> Map.ofList

        // Tarjan's produces SCCs in reverse topological order; reverse them
        let orderedSCCs = tarjanScc deps |> List.rev

        // Preserve original ordering within each SCC
        let originalIndex = typeDefs |> List.mapi (fun i td -> getTypeName td, i) |> Map.ofList

        orderedSCCs |> List.collect (fun scc ->
            let sorted = scc |> List.sortBy (fun name -> originalIndex |> Map.tryFind name |> Option.defaultValue 0)
            sorted |> List.mapi (fun i name ->
                let td = nameToTd.[name]
                let isRecursive = i > 0
                (td, isRecursive)
            )
        )

    // --- convert flat TypeDefs to Fabulous.AST widgets ---

    /// Build a Fabulous.AST UnionCase widget from an EnumCaseInfo
    let buildUnionCaseWidget (c: EnumCaseInfo) =
        let baseCase =
            match c.PayloadType with
            | Some payloadType -> UnionCase(c.CaseName, [Field(payloadType)])
            | None -> UnionCase(c.CaseName)
        match c.JsonUnionCaseValue with
        | Some jsonValue -> baseCase.attribute(Attribute("JsonPropertyName", ParenExpr(String(jsonValue))))
        | None -> baseCase

    /// Build a Fabulous.AST Field widget from a FieldInfo
    let buildFieldWidget (f: FieldInfo) =
        let mutable field = Field(f.FieldName, LongIdent(f.FieldType))
        // Apply XML docs
        if not f.DocLines.IsEmpty then
            field <- field.xmlDocs(f.DocLines)
        // Only emit [<JsonPropertyName>] if SnakeCaseNamingPolicy would mangle embedded digits
        match f.JsonFieldName with
        | Some n ->
            field <- field.attribute(Attribute("JsonPropertyName", ParenExpr(String(n))))
        | None -> ()
        field

    // --- serialisation ---

    /// Parses the Stripe OpenAPI specification and returns a flat list of TypeDefs
    let parseModelFlat (filePath: string option) =
        //parse Open API specification file
        let root' = __SOURCE_DIRECTORY__
        let filePath' = defaultArg filePath (Path.GetFullPath(Path.Combine(root', "../../spec/stripe-openapi-2026-04-22.dahlia.json")))
        let json = File.ReadAllText(filePath')

        //get schema root
        let root = JsonValue.Parse json
        let components = root.Item "components"
        let schemas = components.Item "schemas"

        //parse schemas into type definitions
        let typeDefinitions =
            schemas.Properties
            |> Array.map (fun (key, schema) ->
                let schemaObject = schema |> getSchemaObject
                let requiredFields = schemaObject.Required |> Array.map(fun jv -> jv.AsString())
                let typeDefinition =
                    if schemaObject.Properties = JsonValue.Null then
                        ($"{key} hide", schemaObject.Description,
                            match schemaObject.AnyOf with
                            | Some ao ->
                                [| ao |> parseAnyOfs (key |> pascalCasify) "" requiredFields "" false false "'DU" |]
                            | None ->
                                [||]
                        )
                    else
                        (key, schemaObject.Description,
                            schemaObject.Properties.Properties
                            |> Array.map(fun (k, v) ->
                                v |> parseValue (key |> pascalCasify) k (requiredFields.Contains(k))
                            )
                        )
                match typeDefinition with
                | (name, desc, [||]) ->
                    (name, desc,
                        [| { Description = desc; Name = name; Nullable = true; Required = false; Type = "string"; EnumValues = None; SubValues = None; StaticValue = None } |]
                    )
                | td -> td
            )

        // Flatten into our flat TypeDef list
        flattenTypeDefinitions typeDefinitions
