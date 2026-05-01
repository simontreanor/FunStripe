namespace FunStripe

open FSharp.Data
open FSharp.Data.JsonExtensions
open System
open System.IO
open System.Linq
open System.Text.RegularExpressions
open Fabulous.AST
open type Fabulous.AST.Ast

/// AST-based multi-file request code generator.
/// Parses the OpenAPI spec's `paths` section into a flat IR, groups by semantic module,
/// and serializes via Fabulous.AST v2 into per-resource files under src/StripeRequest/.
module RequestBuilderAST =

    // --- reuse parsing helpers from RequestParsing and ModelBuilderModular ---
    open RequestParsing
    open ModelBuilderModular

    // --- flat intermediate representation ---

    /// A single enum case in a request DU (e.g. Create'Collect | CurrentlyDue)
    type RequestEnumCaseInfo = {
        RawValue: string
        CaseName: string
        JsonUnionCaseValue: string option
    }

    /// A single field in a request options record
    type RequestFieldInfo = {
        DocLines: string list
        FieldName: string
        FieldType: string
        OptionAttribute: OptionType
        IsRequired: bool
    }

    /// A parameter in the companion `create` function
    type RequestParamInfo = {
        ParamName: string
        PascalFieldName: string
        ParamType: string
        IsOptional: bool
    }

    /// Describes how an API function calls the REST API
    type ApiCallInfo = {
        HttpVerb: string
        Path: string
        ResponseType: string
        HasFormOptions: bool
        HasQueryOptions: bool
        QueryFields: (string * string) list  // (rawName, pascalName)
    }

    /// A flat, non-recursive request type definition
    type RequestTypeDef =
        /// A simple DU for request enums (e.g. Create'Collect)
        | RequestEnum of name: string * cases: RequestEnumCaseInfo list
        /// An options record with [<Config.Form>]/[<Config.Query>]/[<Config.Path>] attributes
        | RequestRecord of name: string * fields: RequestFieldInfo list * createParams: RequestParamInfo list
        /// An API endpoint function (e.g. let Create settings (options: CreateOptions) = ...)
        | RequestFunction of name: string * description: string * optionsTypeName: string option * call: ApiCallInfo
        /// A per-endpoint module grouping (e.g. module AccountLinks)
        | RequestModule of name: string

    /// Get the name of a RequestTypeDef
    let getRequestTypeName = function
        | RequestEnum(name, _) -> name
        | RequestRecord(name, _, _) -> name
        | RequestFunction(name, _, _, _) -> name
        | RequestModule(name) -> name

    // --- parsing the spec into flat IR ---

    /// Parse a request enum case value using the same logic as ModelBuilderAST.parseEnumCase
    let parseRequestEnumCase (rawValue: string) : RequestEnumCaseInfo =
        if Regex.IsMatch(rawValue, @"^\p{Lu}") || Regex.IsMatch(rawValue, @"^\d") || rawValue.Contains("-") || rawValue.Contains(" ") || rawValue.Contains(".") then
            let caseName = rawValue |> clean |> pascalCasify |> escapeNumeric
            { RawValue = rawValue; CaseName = caseName; JsonUnionCaseValue = Some rawValue }
        elif rawValue = "none" then
            { RawValue = rawValue; CaseName = $"{rawValue |> pascalCasify}'"; JsonUnionCaseValue = Some rawValue }
        else
            let caseName = rawValue |> clean |> pascalCasify
            { RawValue = rawValue; CaseName = caseName; JsonUnionCaseValue = None }

    /// Build request fields and params from parsed Value array
    let buildRequestFieldsAndParams (values: Value array) : RequestFieldInfo list * RequestParamInfo list =
        let fields =
            values |> Array.map (fun v ->
                let req = v.Required
                let optionSuffix = if req then "" else " option"
                let docLines =
                    if v.Description |> String.IsNullOrWhiteSpace then []
                    else
                        v.Description
                            .Replace("\n\n", "\n")
                            .Split('\n')
                            |> Array.map (fun s -> s.Trim())
                            |> Array.filter (fun s -> s.Length > 0)
                            |> Array.toList
                { DocLines = docLines
                  FieldName = v.Name |> pascalCasify
                  FieldType = $"{v.Type}{optionSuffix}"
                  OptionAttribute = v.OptionType
                  IsRequired = req }
            ) |> Array.toList
        let sortedForCreate = values |> Array.sortBy (fun v -> (if v.Required then 0 else 1), v.Name)
        let createParams =
            sortedForCreate |> Array.map (fun v ->
                { ParamName = v.Name |> camelCasify |> escapeReservedName
                  PascalFieldName = v.Name |> pascalCasify
                  ParamType = v.Type
                  IsOptional = not v.Required }
            ) |> Array.toList
        (fields, createParams)

    /// Recursively collect enums and sub-records from a Value tree,
    /// returning them as RequestTypeDefs that should precede the main options record.
    let rec collectNestedTypes (values: Value array) : RequestTypeDef list =
        let result = ResizeArray<RequestTypeDef>()
        for v in values do
            // Collect enums
            if v.EnumValues.IsSome then
                let cases = v.EnumValues.Value |> List.map parseRequestEnumCase
                result.Add(RequestEnum(v.Type, cases))
            // Collect nested sub-records
            if v.SubValues.IsSome then
                let nested = collectNestedTypes v.SubValues.Value
                for n in nested do result.Add(n)
                let subName = v.Type
                if not (subName.StartsWith "Choice<" || subName.EndsWith " list") then
                    let (subFields, subParams) = buildRequestFieldsAndParams v.SubValues.Value
                    result.Add(RequestRecord(subName, subFields, subParams))
        result |> Seq.toList

    /// Parse the Stripe OpenAPI spec `paths` section into a flat list of
    /// (moduleName * RequestTypeDef list) pairs — one entry per API module.
    let parseRequestFlat (filePath: string option) : (string * RequestTypeDef list) list =
        let root' = __SOURCE_DIRECTORY__
        let filePath' = defaultArg filePath (Path.GetFullPath(Path.Combine(root', "../../spec/stripe-openapi-2026-04-22.dahlia.json")))
        let json = File.ReadAllText(filePath')

        let root = JsonValue.Parse json
        let components = root.Item "components"
        let schemas = components.Item "schemas"
        let operationPaths = root.Item "paths"

        // Build the same request-paths mapping as RequestParsing + RequestBuilderAST
        let requestPaths =
            schemas.Properties
            |> Array.filter (fun (k, v) ->
                v.Properties
                |> Array.exists (fun (k, _) -> k = "x-stripeOperations"))
            |> Array.map (fun (k, v) ->
                (k,
                 v.Properties
                 |> Array.filter (fun (k, _) -> k = "x-stripeOperations")
                 |> Array.collect (fun (_, v) -> v.AsArray())
                 |> Array.filter (fun jv ->
                    jv.TryGetProperty("method_on")
                    |> function | Some p -> p.AsString() = "collection" || p.AsString() = "service" | _ -> false)
                 |> Array.map (fun jv ->
                    (jv.GetProperty("method_name").AsString(),
                     jv.GetProperty("operation").AsString(),
                     jv.GetProperty("path").AsString()))))

        let paths =
            operationPaths.Properties
            |> Array.filter (fun (path, _) -> path.Contains("x-stripe") |> not)
            |> Array.map (fun (path, operations) ->
                let pathRoot =
                    Regex.Split(path, "/")
                    |> Array.mapi (fun i p ->
                        match (i, p) with
                        | 0, _ | 1, _ -> None
                        | _, p when Regex.IsMatch(p, "^\{.+\}$") -> None
                        | _, p -> Some (p |> pascalCasify))
                    |> Array.choose id
                    |> String.concat ""
                    |> fun s -> Regex.Replace(s, "^3d", "ThreeD")

                let methodOperationPaths =
                    operations.Properties
                    |> Array.choose (fun (operation, _) ->
                        requestPaths
                        |> Array.collect snd
                        |> Array.tryFind (fun (_, o, p) -> o = operation && p = path)
                        |> Option.map (fun (m, _, _) -> (m, operation, path)))
                (pathRoot, methodOperationPaths))
            |> Array.groupBy fst
            |> Array.map (fun (k, v) -> k, v |> Array.collect (fun (_, v') -> v'))

        // Build the requests structure
        let requests =
            paths
            |> Array.map (fun (moduleName, methodOperationPaths) ->
                let methods =
                    methodOperationPaths
                    |> Array.map (fun (method, verb, path) ->
                        let methodName = method |> pascalCasify
                        let operation =
                            operationPaths.Properties
                            |> Array.find (fun (p, _) -> p = path)
                            |> fun (_, v) -> v.Properties
                            |> Array.find (fun (verb', _) -> verb' = verb)
                            |> snd
                        let desc = operation.TryGetProperty("description") |> Option.map (fun v -> v.AsString()) |> Option.defaultValue ""
                        let form =
                            operation.GetProperty("requestBody").GetProperty("content").TryGetProperty("application/x-www-form-urlencoded")
                            |> function
                               | Some f -> f
                               | None -> operation.GetProperty("requestBody").GetProperty("content").GetProperty("multipart/form-data")

                        let schema = form.TryGetProperty("schema") |> function | Some jv -> jv | None -> failwith "No schema present"
                        let schemaObject = schema |> RequestParsing.getSchemaObject
                        let required = schemaObject.RequiredFields |> Array.map (fun jv -> jv.AsString())
                        let formParameters =
                            schemaObject.Properties.Properties
                            |> Array.map (fun (k, v) ->
                                v |> parseValue $"{methodName}'" k (required.Contains(k)) false)
                        let queryParameters =
                            operation.TryGetProperty("parameters")
                            |> function | Some jv -> jv.AsArray() | None -> [||]
                            |> parseQueryParameters
                        let options = formParameters |> Array.append queryParameters
                        let responseContent = operation.GetProperty("responses").GetProperty("200").GetProperty("content")
                        let tryJsonMimeType = responseContent.TryGetProperty("application/json")
                        let responseType =
                            match tryJsonMimeType with
                            | Some jsonMimeType ->
                                let responseSchema = jsonMimeType.GetProperty("schema")
                                match responseSchema.TryGetProperty("$ref") with
                                | Some jv ->
                                    jv.AsString() |> parseRef |> pascalCasify
                                | None ->
                                    match responseSchema.TryGetProperty("anyOf") with
                                    | Some jv when jv.AsArray() |> Array.isEmpty |> not ->
                                        (jv.AsArray() |> Array.head).GetProperty("$ref").AsString()
                                        |> parseRef |> pascalCasify
                                    | _ ->
                                        match responseSchema.TryGetProperty("properties") with
                                        | Some jv ->
                                            let listType = jv.GetProperty("data").GetProperty("items").GetProperty("$ref").AsString()
                                            $"{listType |> parseRef |> pascalCasify} list"
                                        | _ ->
                                            failwith $"Unhandled response type: {moduleName}"
                            | _ ->
                                let tryPdfMimeType = responseContent.TryGetProperty("application/pdf")
                                match tryPdfMimeType with
                                | Some _ -> "string"
                                | _ -> failwith $"Unhandled mime type: {moduleName}"

                        (methodName, verb, path, desc, options, responseType))
                (moduleName, methods))

        // Convert to flat IR
        requests
        |> Array.map (fun (moduleName, methods) ->
            let typeDefs = ResizeArray<RequestTypeDef>()
            // Module marker
            typeDefs.Add(RequestModule(moduleName))

            for (methodName, verb, path, desc, options, responseType) in methods do
                let formOptions = options |> Array.filter (fun o -> o.OptionType = Form)
                let queryOptions = options |> Array.filter (fun o -> o.OptionType = Query)

                // Collect nested enums and sub-records first
                let nestedTypes = collectNestedTypes options
                for nt in nestedTypes do typeDefs.Add(nt)

                // Build the main options record if there are any options
                if options |> Array.isEmpty |> not then
                    let (fields, createParams) = buildRequestFieldsAndParams options
                    typeDefs.Add(RequestRecord($"{methodName}Options", fields, createParams))

                // Build the API call info
                let queryFields =
                    queryOptions
                    |> Array.map (fun v -> (v.Name, v.Name |> pascalCasify))
                    |> Array.toList

                let callInfo = {
                    HttpVerb = verb
                    Path = path
                    ResponseType = responseType
                    HasFormOptions = formOptions.Any()
                    HasQueryOptions = queryOptions |> Array.isEmpty |> not
                    QueryFields = queryFields
                }

                let optionsTypeName =
                    if options |> Array.isEmpty then None
                    else Some $"{methodName}Options"

                typeDefs.Add(RequestFunction(methodName, desc, optionsTypeName, callInfo))

            (moduleName, typeDefs |> Seq.toList))
        |> Array.toList

    // --- module assignment ---

    /// Normalize a PascalCase request module name to snake_case.
    /// E.g. "AccountLinks" -> "account_links", "FinancialConnectionsAccounts" -> "financial_connections_accounts"
    let private requestModuleToSnakeCase (moduleName: string) =
        Regex.Replace(moduleName, @"(?<=[a-z])(?=[A-Z])|(?<=[A-Z])(?=[A-Z][a-z])", "_")
             .ToLowerInvariant()

    /// Normalize a request module name to a canonical Stripe domain by longest-prefix match.
    /// Falls back to the first token if no canonical domain matches.
    /// E.g. with canonical ["financial_connections"; "account"], "FinancialConnectionsAccounts" -> "financial_connections",
    /// "AccountLinks" -> "account".
    let normalizeRequestModuleName (canonicalDomains: string list) (moduleName: string) =
        let snake = requestModuleToSnakeCase moduleName
        canonicalDomains
        |> List.tryFind (fun d -> snake = d || snake.StartsWith(d + "_"))
        |> Option.defaultWith (fun () ->
            snake.Split([|'_'|], StringSplitOptions.RemoveEmptyEntries)
            |> Array.tryHead
            |> Option.defaultValue "misc")

    /// Compute request module assignments — maps each request module to a merged semantic module.
    let computeRequestModuleAssignments
        (modelTypeToModule: Map<string, string>)
        (modelModuleToMergedName: Map<string, string>)
        (requestModules: (string * RequestTypeDef list) list)
        : Map<string, string> * string list =

        // Use the keys of modelModuleToMergedName as the canonical domain list,
        // sorted longest-first so prefix matching prefers more specific domains.
        let canonicalDomains =
            modelModuleToMergedName
            |> Map.keys
            |> Seq.toList
            |> List.sortByDescending String.length

        // Canonical-domain-aware module assignment for each request module
        let rawAssignments =
            requestModules
            |> List.map (fun (moduleName, _) ->
                let normalized = normalizeRequestModuleName canonicalDomains moduleName
                let merged =
                    modelModuleToMergedName
                    |> Map.tryFind normalized
                    |> Option.defaultValue normalized
                (moduleName, merged))

        // Build the request-module-to-semantic-module map
        let requestModuleToSemantic = rawAssignments |> Map.ofList

        // Collect all unique semantic modules referenced by requests
        let semanticModulesInUse =
            rawAssignments |> List.map snd |> List.distinct

        (requestModuleToSemantic, semanticModulesInUse)

    /// Group request modules by their assigned semantic module.
    let groupRequestsBySemanticModule
        (requestModuleToSemantic: Map<string, string>)
        (requestModules: (string * RequestTypeDef list) list)
        : Map<string, (string * RequestTypeDef list) list> =
        requestModules
        |> List.groupBy (fun (moduleName, _) ->
            requestModuleToSemantic |> Map.tryFind moduleName |> Option.defaultValue "misc")
        |> Map.ofList

    // --- compute open statements ---

    /// Extract all model type names referenced by request type defs
    let collectReferencedModelTypes (typeDefs: RequestTypeDef list) : Set<string> =
        let result = ResizeArray<string>()
        for td in typeDefs do
            match td with
            | RequestFunction(_, _, _, call) ->
                // Response type may be "TypeName" or "TypeName list"
                let respType = call.ResponseType.Replace(" list", "").Trim()
                result.Add(respType)
            | _ -> ()
        result |> Set.ofSeq

    /// Compute which Stripe.* model namespaces need to be opened for a request file
    let computeRequestOpenStatements
        (modelTypeToModule: Map<string, string>)
        (modelModuleToMergedName: Map<string, string>)
        (typeDefs: RequestTypeDef list)
        : string list =
        let referencedTypes = collectReferencedModelTypes typeDefs
        let toPascal (s: string) =
            s.Split([|'_'|], StringSplitOptions.RemoveEmptyEntries)
            |> Array.map (fun w ->
                if w.Length = 0 then w
                else w.Substring(0, 1).ToUpper() + w.Substring(1))
            |> String.concat ""
        referencedTypes
        |> Set.toList
        |> List.choose (fun typeName ->
            modelTypeToModule
            |> Map.tryFind typeName
            |> Option.map (fun rawMod ->
                modelModuleToMergedName
                |> Map.tryFind rawMod
                |> Option.defaultValue rawMod))
        |> List.distinct
        |> List.sort
        |> List.map toPascal

    // --- serialization ---

    /// F# keywords that must be escaped with double backticks
    let private fsharpKeywords =
        set [
            "abstract"; "and"; "as"; "assert"; "base"; "begin"; "class"; "default";
            "delegate"; "do"; "done"; "downcast"; "downto"; "elif"; "else"; "end";
            "exception"; "extern"; "false"; "finally"; "fixed"; "for"; "fun"; "function";
            "global"; "if"; "in"; "inherit"; "inline"; "interface"; "internal"; "lazy";
            "let"; "match"; "member"; "module"; "mutable"; "namespace"; "new"; "not";
            "null"; "of"; "open"; "or"; "override"; "private"; "public"; "rec"; "return";
            "select"; "static"; "struct"; "then"; "to"; "true"; "try"; "type"; "upcast";
            "use"; "val"; "void"; "when"; "while"; "with"; "yield"
        ]

    /// Escape an identifier with double backticks if it's an F# keyword
    let private escapeKeyword (name: string) =
        if fsharpKeywords.Contains(name) then $"``{name}``" else name

    /// Serialize a request enum DU using Fabulous.AST
    let serializeRequestEnum (name: string) (cases: RequestEnumCaseInfo list) : string =
        let oak = Oak() { AnonymousModule() {
            let u = Union(name) {
                for c in cases do
                    let baseCase = UnionCase(c.CaseName)
                    match c.JsonUnionCaseValue with
                    | Some jsonValue ->
                        baseCase.attribute(Attribute("JsonPropertyName", ParenExpr(String(jsonValue))))
                    | None -> baseCase
            }
            u
        } }
        (Gen.mkOak oak |> Gen.run).Trim()

    /// Serialize a request options record with Config attributes
    let serializeRequestRecord (name: string) (fields: RequestFieldInfo list) : string =
        let oak = Oak() { AnonymousModule() {
            Record(name) {
                for f in fields do
                    let field = Field(f.FieldName, LongIdent(f.FieldType))
                    let field =
                        if not f.DocLines.IsEmpty then
                            field.xmlDocs(f.DocLines)
                        else field
                    let attrName =
                        match f.OptionAttribute with
                        | Form -> "Config.Form"
                        | Query -> "Config.Query"
                        | Path -> "Config.Path"
                        | Undefined -> "Config.Form"
                    field.attribute(Attribute(attrName))
            }
        } }
        (Gen.mkOak oak |> Gen.run).Trim()

    /// Serialize a `type X with static member New(...)` augmentation for a request options
    /// record. Required params come first, then optionals as `?param: T`. Body assigns
    /// each field directly from the parameter (no `Option.flatten` in request types).
    let serializeRequestRecordNewMember (name: string) (createParams: RequestParamInfo list) : string =
        if createParams.IsEmpty then "" else
        let sortedParams =
            (createParams |> List.filter (fun p -> not p.IsOptional)) @
            (createParams |> List.filter (fun p -> p.IsOptional))
        let paramStrs =
            sortedParams |> List.map (fun p ->
                let prefix = if p.IsOptional then "?" else ""
                $"{prefix}{p.ParamName}: {p.ParamType}")
        let paramList = String.concat ", " paramStrs
        let sb = Text.StringBuilder()
        sb.AppendLine($"type {name} with") |> ignore
        sb.AppendLine($"    static member New({paramList}) =") |> ignore
        sb.AppendLine("        {") |> ignore
        for p in createParams do
            sb.AppendLine($"            {p.PascalFieldName} = {p.ParamName}") |> ignore
        sb.AppendLine("        }") |> ignore
        sb.ToString()

    /// Serialize a companion module with `let create` for a request options record.
    let serializeRequestCompanionModule (name: string) (createParams: RequestParamInfo list) : string =
        let sb = Text.StringBuilder()
        sb.AppendLine($"module {name} =") |> ignore

        if not createParams.IsEmpty then
            // Only required params appear in the function signature; optional fields default to None
            let requiredParams = createParams |> List.filter (fun p -> not p.IsOptional)
            let sigParams = if requiredParams.IsEmpty then createParams else requiredParams

            let paramStrings =
                sigParams |> List.mapi (fun i p ->
                    let typeStr = if p.IsOptional then $"{p.ParamType} option" else p.ParamType
                    let comma = if i < sigParams.Length - 1 then "," else ""
                    $"        {p.ParamName}: {typeStr}{comma}")

            sb.AppendLine("    let create") |> ignore
            sb.AppendLine("        (") |> ignore
            for line in paramStrings do
                sb.AppendLine($"    {line}") |> ignore
            sb.AppendLine($"        ) : {name}") |> ignore
            sb.AppendLine("        =") |> ignore

            let fieldStrings =
                createParams |> List.map (fun p ->
                    let value =
                        if p.IsOptional && not (sigParams |> List.exists (fun sp -> sp.ParamName = p.ParamName)) then
                            "None"
                        else
                            p.ParamName
                    $"          {p.PascalFieldName} = {value}")

            sb.AppendLine("        {") |> ignore
            for line in fieldStrings do
                sb.AppendLine(line) |> ignore
            sb.Append("        }") |> ignore

        sb.ToString()

    /// Convert a response type string: "TypeName list" -> "StripeList<TypeName>", others unchanged.
    let formatResponseType (responseType: string) =
        if responseType.EndsWith(" list") then
            let innerType = responseType.[..responseType.Length - 6]
            $"StripeList<{innerType}>"
        else
            responseType

    /// Serialize an API function as raw text
    let serializeRequestFunction (name: string) (description: string) (optionsTypeName: string option) (call: ApiCallInfo) : string =
        let sb = Text.StringBuilder()

        // XML doc comment
        if not (String.IsNullOrWhiteSpace description) then
            let desc =
                if description.Contains("<p>") then description
                else $"<p>{description}</p>"
            let formatted = desc.Replace("\n\n", "\n").Replace("\n", "\n///")
            sb.AppendLine($"///{formatted}") |> ignore

        // Function signature
        let optionsParam =
            match optionsTypeName with
            | Some typeName -> $" (options: {typeName})"
            | None -> ""
        sb.AppendLine($"let {name} settings{optionsParam} =") |> ignore

        // Query string declaration
        if call.HasQueryOptions && not call.QueryFields.IsEmpty then
            let qsParts =
                call.QueryFields
                |> List.map (fun (rawName, pascalName) -> $"(\"{rawName}\", options.{pascalName} |> box)")
                |> String.concat "; "
            sb.AppendLine($"    let qs = [{qsParts}] |> Map.ofList") |> ignore

        // Format path with interpolation
        let formattedPath =
            Regex.Replace(call.Path, @"\{([^}]+)\}", fun m ->
                $"{{options.{m.Groups.[1].Value |> escapeReservedName |> pascalCasify}}}")

        sb.AppendLine($"    $\"{formattedPath}\"") |> ignore

        // REST API call
        let queryArg =
            if call.HasQueryOptions && not call.QueryFields.IsEmpty then " qs"
            else " (Map.empty)"

        let responseTypeStr = formatResponseType call.ResponseType

        match call.HttpVerb with
        | "get" when call.HasFormOptions ->
            sb.Append($"    |> RestApi.getWithAsync<_, {responseTypeStr}> settings{queryArg} options") |> ignore
        | "get" ->
            sb.Append($"    |> RestApi.getAsync<{responseTypeStr}> settings{queryArg}") |> ignore
        | "post" when not call.HasFormOptions ->
            sb.Append($"    |> RestApi.postWithoutAsync<{responseTypeStr}> settings{queryArg}") |> ignore
        | "post" ->
            sb.Append($"    |> RestApi.postAsync<_, {responseTypeStr}> settings{queryArg} options") |> ignore
        | "delete" ->
            sb.Append($"    |> RestApi.deleteAsync<{responseTypeStr}> settings{queryArg}") |> ignore
        | verb ->
            failwith $"Unhandled verb: {verb}"

        sb.ToString()

    /// Serialize a complete request file for one semantic module group.
    let serializeRequestModuleFile
        (version: string)
        (semanticModuleName: string)
        (modelOpenStatements: string list)
        (requestModules: (string * RequestTypeDef list) list)
        : string =

        let pascalName = ModelBuilderModular.pascalModuleName semanticModuleName
        let sb = Text.StringBuilder()

        // Header
        sb.AppendLine($"namespace StripeRequest.{pascalName}") |> ignore
        sb.AppendLine() |> ignore
        sb.AppendLine("open FunStripe") |> ignore
        sb.AppendLine("open System.Text.Json.Serialization") |> ignore

        // Cross-module model opens
        for dep in modelOpenStatements do
            sb.AppendLine($"open Stripe.{dep}") |> ignore

        sb.AppendLine("open System") |> ignore
        sb.AppendLine() |> ignore

        let mutable isFirst = true

        for (moduleName, typeDefs) in requestModules do
            // Open the endpoint module — all types and functions go inside it
            if isFirst then
                sb.AppendLine($"[<System.CodeDom.Compiler.GeneratedCode(\"FunStripe\", \"{version}\")>]") |> ignore
                isFirst <- false
            sb.AppendLine($"module {moduleName} =") |> ignore
            sb.AppendLine() |> ignore

            let indent = "    " // 4-space indent inside module

            // Emit all types (enums, records, companion modules) inside the module
            for td in typeDefs do
                match td with
                | RequestEnum(name, cases) ->
                    let snippet = serializeRequestEnum name cases
                    let indented =
                        snippet.Split('\n')
                        |> Array.map (fun line -> if line.Trim() = "" then "" else $"{indent}{line}")
                        |> String.concat "\n"
                    sb.AppendLine(indented) |> ignore
                    sb.AppendLine() |> ignore

                | RequestRecord(name, fields, createParams) ->
                    let snippet = serializeRequestRecord name fields
                    let indented =
                        snippet.Split('\n')
                        |> Array.map (fun line -> if line.Trim() = "" then "" else $"{indent}{line}")
                        |> String.concat "\n"
                    sb.AppendLine(indented) |> ignore
                    sb.AppendLine() |> ignore

                    // `with static member New(...)` augmentation for ergonomic construction.
                    if not createParams.IsEmpty then
                        let augSnippet = serializeRequestRecordNewMember name createParams
                        let augIndented =
                            augSnippet.Split('\n')
                            |> Array.map (fun line -> if line.Trim() = "" then "" else $"{indent}{line}")
                            |> String.concat "\n"
                        sb.AppendLine(augIndented.TrimEnd()) |> ignore
                        sb.AppendLine() |> ignore

                    // Companion module with `let create`
                    if not createParams.IsEmpty then
                        let companionSnippet = serializeRequestCompanionModule name createParams
                        let companionIndented =
                            companionSnippet.Split('\n')
                            |> Array.map (fun line -> if line.Trim() = "" then "" else $"{indent}{line}")
                            |> String.concat "\n"
                        sb.AppendLine(companionIndented) |> ignore
                        sb.AppendLine() |> ignore

                | RequestModule _ -> ()
                | RequestFunction _ -> ()

            // Emit the API functions inside the same module
            let functions = typeDefs |> List.choose (function | RequestFunction(n, d, o, c) -> Some (n, d, o, c) | _ -> None)
            for (name, desc, optTypeName, call) in functions do
                let funcSnippet = serializeRequestFunction name desc optTypeName call
                // Indent function body inside the module
                let indented =
                    funcSnippet.Split('\n')
                    |> Array.map (fun line -> if line.Trim() = "" then "" else $"{indent}{line}")
                    |> String.concat "\n"
                sb.AppendLine(indented) |> ignore
                sb.AppendLine() |> ignore

        sb.ToString()

    // --- orchestration ---

    /// Run the full pipeline: parse -> assign -> group -> serialize -> write files.
    let generateAllRequestFiles (version: string) (outputDir: string) (specFilePath: string option) =
        // Step 1: Parse the spec model to get module assignments
        let typeDefs = ModelBuilderAST.parseModelFlat specFilePath
        printfn "Parsed %d model type definitions" typeDefs.Length

        // computeModuleAssignmentsFromSpec now returns the full set of mappings,
        // including the post-SCC schema-to-merged-module map and the raw->merged module map.
        // RequestBuilderAST consumes them directly to keep request files in lock-step
        // with the modular Stripe/*.fs files (canonical-domain naming).
        let (modelTypeToModule, modelModuleOrder, _schemaToMergedModule, modelModuleToMergedName) =
            computeModuleAssignmentsFromSpec specFilePath typeDefs
        printfn "Computed model module assignments, %d modules" modelModuleOrder.Length
        let requestModules = parseRequestFlat specFilePath
        printfn "Parsed %d request modules" requestModules.Length

        // Step 3: Compute request module assignments
        let (requestModuleToSemantic, semanticModulesInUse) =
            computeRequestModuleAssignments modelTypeToModule modelModuleToMergedName requestModules
        printfn "Assigned request modules to %d semantic modules" (semanticModulesInUse |> List.distinct |> List.length)

        // Step 4: Group requests by semantic module
        let semanticGroups =
            groupRequestsBySemanticModule requestModuleToSemantic requestModules
        printfn "Grouped into %d semantic request modules" semanticGroups.Count

        // Step 5: Order using model module order
        let orderedSemanticModules =
            let modelOrderMap =
                modelModuleOrder |> List.mapi (fun i m -> m, i) |> Map.ofList
            semanticGroups
            |> Map.keys
            |> Seq.toList
            |> List.sortBy (fun m -> modelOrderMap |> Map.tryFind m |> Option.defaultValue 99999)
            |> List.distinct
        printfn "Ordered %d request modules" orderedSemanticModules.Length

        // Step 6: Ensure output directory exists
        Directory.CreateDirectory(outputDir) |> ignore

        // Step 7: Generate and write each module file
        let generatedFiles = ResizeArray<string>()
        for semanticModule in orderedSemanticModules do
            let requestModulesForFile =
                semanticGroups
                |> Map.tryFind semanticModule
                |> Option.defaultValue []
            if not requestModulesForFile.IsEmpty then
                let allTypeDefs = requestModulesForFile |> List.collect snd
                let openStatements =
                    computeRequestOpenStatements modelTypeToModule modelModuleToMergedName allTypeDefs
                let content =
                    serializeRequestModuleFile version semanticModule openStatements requestModulesForFile
                let pascalName = ModelBuilderModular.pascalModuleName semanticModule
                let fileName = $"{pascalName}.fs"
                let filePath = Path.Combine(outputDir, fileName)
                File.WriteAllText(filePath, content)
                generatedFiles.Add(fileName)
                let typeCount =
                    allTypeDefs
                    |> List.filter (function | RequestEnum _ | RequestRecord _ -> true | _ -> false)
                    |> List.length
                let funcCount =
                    allTypeDefs
                    |> List.filter (function | RequestFunction _ -> true | _ -> false)
                    |> List.length
                printfn "  %-25s %4d types, %3d functions" fileName typeCount funcCount

        printfn "\nGenerated %d request files in %s" generatedFiles.Count outputDir

        // Emit a .props file alongside the generated request modules so consuming
        // .fsproj files can import modular compilation order without manual upkeep.
        let propsPath = Path.Combine(outputDir, "StripeRequest.Modular.props")
        let propsLines = ResizeArray<string>()
        propsLines.Add("<!-- Auto-generated by FunStripe.Generator. Do not edit. -->")
        propsLines.Add("<Project>")
        propsLines.Add("  <ItemGroup>")
        for f in generatedFiles do
            propsLines.Add(sprintf "    <Compile Include=\"$(MSBuildThisFileDirectory)%s\" Link=\"StripeRequest/%s\" />" f f)
        propsLines.Add("  </ItemGroup>")
        propsLines.Add("</Project>")
        File.WriteAllText(propsPath, String.concat "\n" propsLines + "\n")
        printfn "Emitted %s" propsPath

        // Return the ordered list of file names for .fsproj inclusion
        generatedFiles |> Seq.toList
