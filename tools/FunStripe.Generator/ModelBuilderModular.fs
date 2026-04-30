namespace FunStripe

open FSharp.Data
open FSharp.Data.JsonExtensions
open System
open System.IO
open System.Linq
open System.Text.RegularExpressions
open Fabulous.AST
open type Fabulous.AST.Ast

/// Modular code generator that produces multiple F# files under src/Stripe/,
/// one per semantic module, using records + companion modules with `create` functions.
module ModelBuilderModular =

    // --- reuse all parsing, flattening, and ordering from existing modules ---
    open ModelParsing
    open ModelBuilderAST

    // --- module assignment (schema-level SCC with majority-vote) ---

    /// Normalize a schema name to its semantic module name using the first-token heuristic.
    /// E.g. "account_branding_settings" -> "account", "checkout.session" -> "checkout"
    let normalizedModuleForName (schemaName: string) =
        schemaName.Split([|'.'; '_'|], StringSplitOptions.RemoveEmptyEntries)
        |> Array.map (fun x -> x.Trim().ToLowerInvariant())
        |> Array.tryHead
        |> Option.defaultValue "misc"

    /// For a type SCC, compute the module name by majority-vote of first-tokens.
    let normalizedModuleForGroup (members: string list) =
        members
        |> List.map normalizedModuleForName
        |> List.countBy id
        |> List.sortBy (fun (name, count) -> (-count, name))
        |> List.head
        |> fst

    /// Recursively collect all schema $ref references from a JSON value.
    let rec collectSchemaRefs (element: JsonValue) : Set<string> =
        match element with
        | JsonValue.Record properties ->
            let refSet =
                properties
                |> Array.tryFind (fun (k, _) -> k = "$ref")
                |> Option.bind (fun (_, v) ->
                    match v with
                    | JsonValue.String s when s.StartsWith("#/components/schemas/") ->
                        Some (s.Substring("#/components/schemas/".Length))
                    | _ -> None)
                |> Option.toList |> Set.ofList
            let childSets = properties |> Array.map (fun (_, v) -> collectSchemaRefs v)
            childSets |> Array.fold Set.union refSet
        | JsonValue.Array elements ->
            elements |> Array.map collectSchemaRefs |> Array.fold Set.union Set.empty
        | _ -> Set.empty

    /// Compute module assignments from the OpenAPI spec using schema-level SCC + majority-vote.
    /// Returns (typeToModule, moduleOrder).
    let computeModuleAssignmentsFromSpec (specFilePath: string option) (typeDefs: TypeDef list) =
        let root' = __SOURCE_DIRECTORY__
        let filePath' = defaultArg specFilePath (Path.GetFullPath(Path.Combine(root', "../../spec/stripe-openapi-2026-04-22.dahlia.json")))
        let json = File.ReadAllText(filePath')
        let root = JsonValue.Parse json
        let schemas = root?components?schemas

        // Build schema names and PascalCase <-> schemaName mappings
        let schemaNames = schemas.Properties |> Array.map fst |> Set.ofArray
        let pascalToSchema =
            schemas.Properties
            |> Array.map (fun (key, _) -> pascalCasify key, key)
            |> Map.ofArray
        // Sorted by length descending for prefix matching
        let sortedPascalNames =
            pascalToSchema |> Map.keys |> Seq.toArray |> Array.sortByDescending String.length

        // Build schema dependency graph from raw $ref links
        let dependencyGraph =
            schemas.Properties
            |> Array.map (fun (key, schema) ->
                let refs = collectSchemaRefs schema |> Set.filter (fun d -> schemaNames.Contains d && d <> key)
                key, refs)
            |> Map.ofArray

        // Schema-level Tarjan SCC
        let allSchemasList = schemaNames |> Set.toList
        let mutable sIdx = 0
        let mutable sStack: string list = []
        let sIndices = Collections.Generic.Dictionary<string, int>()
        let sLowlinks = Collections.Generic.Dictionary<string, int>()
        let sOnStack = Collections.Generic.Dictionary<string, bool>()
        let sSccs = Collections.Generic.List<string list>()

        let rec sStrongconnect (v: string) =
            sIndices.[v] <- sIdx
            sLowlinks.[v] <- sIdx
            sIdx <- sIdx + 1
            sStack <- v :: sStack
            sOnStack.[v] <- true
            let successors = dependencyGraph |> Map.tryFind v |> Option.defaultValue Set.empty
            for w in successors do
                if not (sIndices.ContainsKey w) then
                    sStrongconnect w
                    sLowlinks.[v] <- min sLowlinks.[v] sLowlinks.[w]
                elif sOnStack.ContainsKey w && sOnStack.[w] then
                    sLowlinks.[v] <- min sLowlinks.[v] sIndices.[w]
            if sLowlinks.[v] = sIndices.[v] then
                let mutable scc = []
                let mutable cont = true
                while cont do
                    let w = sStack.Head
                    sStack <- sStack.Tail
                    sOnStack.[w] <- false
                    scc <- w :: scc
                    if w = v then cont <- false
                sSccs.Add(scc |> List.sort)

        for node in allSchemasList do
            if not (sIndices.ContainsKey node) then sStrongconnect node

        let sccList = sSccs |> Seq.toList

        // Assign each SCC to a module by majority vote
        let sccToModule =
            sccList |> List.mapi (fun i members -> i, normalizedModuleForGroup members) |> Map.ofList
        let schemaToSccId =
            sccList
            |> List.mapi (fun i members -> members |> List.map (fun m -> m, i))
            |> List.collect id |> Map.ofList
        let schemaToModule =
            schemaToSccId |> Map.map (fun _ sccId -> sccToModule.[sccId])

        // Compute SCC-level dependency graph
        let sccDeps =
            sccList |> List.mapi (fun sccId members ->
                let outgoing =
                    members
                    |> List.collect (fun m ->
                        dependencyGraph |> Map.tryFind m |> Option.defaultValue Set.empty |> Set.toList)
                    |> List.choose (fun dep ->
                        let target = schemaToSccId.[dep]
                        if target = sccId then None else Some target)
                    |> Set.ofList
                sccId, outgoing) |> Map.ofList

        // Compute module-level dependencies
        let allModules = sccToModule |> Map.values |> Set.ofSeq
        let moduleDeps =
            allModules |> Seq.map (fun moduleName ->
                let outgoing =
                    sccDeps
                    |> Map.toSeq
                    |> Seq.filter (fun (fromScc, _) -> sccToModule.[fromScc] = moduleName)
                    |> Seq.collect (fun (_, targets) -> targets |> Seq.map (fun t -> sccToModule.[t]))
                    |> Seq.filter (fun t -> t <> moduleName)
                    |> Set.ofSeq
                moduleName, outgoing) |> Map.ofSeq

        // Module-level Tarjan SCC
        let mutable mIdx = 0
        let mutable mStack: string list = []
        let mIndices = Collections.Generic.Dictionary<string, int>()
        let mLowlinks = Collections.Generic.Dictionary<string, int>()
        let mOnStack = Collections.Generic.Dictionary<string, bool>()
        let mSccs = Collections.Generic.List<string list>()

        let rec mStrongconnect (v: string) =
            mIndices.[v] <- mIdx
            mLowlinks.[v] <- mIdx
            mIdx <- mIdx + 1
            mStack <- v :: mStack
            mOnStack.[v] <- true
            let successors = moduleDeps |> Map.tryFind v |> Option.defaultValue Set.empty
            for w in successors do
                if not (mIndices.ContainsKey w) then
                    mStrongconnect w
                    mLowlinks.[v] <- min mLowlinks.[v] mLowlinks.[w]
                elif mOnStack.ContainsKey w && mOnStack.[w] then
                    mLowlinks.[v] <- min mLowlinks.[v] mIndices.[w]
            if mLowlinks.[v] = mIndices.[v] then
                let mutable scc = []
                let mutable cont = true
                while cont do
                    let w = mStack.Head
                    mStack <- mStack.Tail
                    mOnStack.[w] <- false
                    scc <- w :: scc
                    if w = v then cont <- false
                mSccs.Add(scc |> List.sort)

        for m in allModules do
            if not (mIndices.ContainsKey m) then mStrongconnect m

        let moduleSccList = mSccs |> Seq.toList

        // Determine merged module names for multi-module SCCs
        let moduleToMergedName =
            moduleSccList
            |> List.collect (fun scc ->
                if scc.Length = 1 then
                    [scc.[0], scc.[0]]
                else
                    // Pick the module with the most schemas as the merged name
                    let schemaCounts =
                        scc |> List.map (fun m ->
                            let count = schemaToModule |> Map.filter (fun _ v -> v = m) |> Map.count
                            m, count)
                    let mergedName =
                        schemaCounts
                        |> List.sortBy (fun (name, count) -> (-count, name))
                        |> List.head |> fst
                    scc |> List.map (fun m -> m, mergedName))
            |> Map.ofList

        // Module SCC topological order using Kahn's algorithm
        let moduleSccIdMap =
            moduleSccList
            |> List.mapi (fun i members -> members |> List.map (fun m -> m, i))
            |> List.collect id |> Map.ofList

        let moduleSccDeps =
            moduleSccList |> List.mapi (fun sccId members ->
                let outgoing =
                    members
                    |> List.collect (fun m -> moduleDeps.[m] |> Set.toList)
                    |> List.choose (fun dep ->
                        let target = moduleSccIdMap.[dep]
                        if target = sccId then None else Some target)
                    |> Set.ofList
                sccId, outgoing) |> Map.ofList

        let moduleSccDependents =
            moduleSccDeps
            |> Map.toSeq
            |> Seq.collect (fun (fromScc, targets) -> targets |> Seq.map (fun toScc -> toScc, fromScc))
            |> Seq.groupBy fst
            |> Seq.map (fun (toScc, incoming) -> toScc, incoming |> Seq.map snd |> Set.ofSeq)
            |> Map.ofSeq

        let indegree =
            [0 .. moduleSccList.Length - 1]
            |> List.map (fun i -> i, moduleSccDeps |> Map.tryFind i |> Option.defaultValue Set.empty |> Set.count)
            |> Map.ofList

        let queue = Collections.Generic.Queue<int>()
        for kv in indegree do
            if kv.Value = 0 then queue.Enqueue kv.Key

        let mutable orderedModuleSccIds = []
        let mutable indegreeWork = indegree

        while queue.Count > 0 do
            let current = queue.Dequeue()
            orderedModuleSccIds <- current :: orderedModuleSccIds
            let dependents = moduleSccDependents |> Map.tryFind current |> Option.defaultValue Set.empty
            for depScc in dependents do
                let nextDeg = indegreeWork.[depScc] - 1
                indegreeWork <- indegreeWork.Add(depScc, nextDeg)
                if nextDeg = 0 then queue.Enqueue depScc

        let moduleOrder =
            orderedModuleSccIds
            |> List.rev
            |> List.collect (fun sccId -> moduleSccList.[sccId] |> List.sort)
            |> List.map (fun m -> moduleToMergedName.[m])
            |> List.distinct

        // Map F# type names to merged module names
        let findModuleForTypeName (typeName: string) =
            // First try direct schema mapping
            match pascalToSchema |> Map.tryFind typeName with
            | Some schemaName ->
                let rawModule = schemaToModule.[schemaName]
                moduleToMergedName.[rawModule]
            | None ->
                // Try prefix matching: find longest Pascal schema name that's a prefix
                match sortedPascalNames |> Array.tryFind (fun p -> typeName.StartsWith(p) && typeName.Length > p.Length) with
                | Some parent ->
                    let schemaName = pascalToSchema.[parent]
                    let rawModule = schemaToModule.[schemaName]
                    moduleToMergedName.[rawModule]
                | None ->
                    // Last resort: PascalCase first token heuristic
                    let tokens =
                        Regex.Replace(typeName, @"(?<=[a-z])(?=[A-Z])|(?<=[A-Z])(?=[A-Z][a-z])", "_")
                             .ToLowerInvariant().Split('_')
                    let rawModule = tokens |> Array.tryHead |> Option.defaultValue "misc"
                    moduleToMergedName |> Map.tryFind rawModule |> Option.defaultValue rawModule

        let typeToModule =
            typeDefs
            |> List.map (fun td -> getTypeName td, findModuleForTypeName (getTypeName td))
            |> Map.ofList

        printfn "Module SCC groups:"
        for scc in moduleSccList do
            if scc.Length > 1 then
                let merged = moduleToMergedName.[scc.[0]]
                printfn "  Recursive: [%s] -> merged as '%s'" (String.concat ", " scc) merged

        (typeToModule, moduleOrder)

    // --- module grouping ---

    /// Convert a module name to PascalCase for the file/namespace name
    let pascalModuleName (moduleName: string) =
        moduleName.Substring(0, 1).ToUpper() + moduleName.Substring(1)

    /// Topologically order type definitions for compilation (dependencies before dependents).
    let topologicallyOrderForCompilation (typeDefs: TypeDef list) : (TypeDef * bool) list =
        let nameToTd = typeDefs |> List.map (fun td -> getTypeName td, td) |> Map.ofList
        let allNames = typeDefs |> List.map getTypeName |> Set.ofList
        let deps = typeDefs |> List.map (fun td -> getTypeName td, getTypeDependencies allNames td) |> Map.ofList

        // Tarjan's SCC
        let mutable idx = 0
        let mutable stack: string list = []
        let indices = Collections.Generic.Dictionary<string, int>()
        let lowlinks = Collections.Generic.Dictionary<string, int>()
        let onStack = Collections.Generic.Dictionary<string, bool>()
        let sccs = Collections.Generic.List<string list>()

        let rec strongconnect (v: string) =
            indices.[v] <- idx
            lowlinks.[v] <- idx
            idx <- idx + 1
            stack <- v :: stack
            onStack.[v] <- true

            let successors = deps |> Map.tryFind v |> Option.defaultValue Set.empty
            for w in successors do
                if not (indices.ContainsKey w) then
                    strongconnect w
                    lowlinks.[v] <- min lowlinks.[v] lowlinks.[w]
                elif onStack.ContainsKey w && onStack.[w] then
                    lowlinks.[v] <- min lowlinks.[v] indices.[w]

            if lowlinks.[v] = indices.[v] then
                let mutable scc = []
                let mutable cont = true
                while cont do
                    let w = stack.Head
                    stack <- stack.Tail
                    onStack.[w] <- false
                    scc <- w :: scc
                    if w = v then cont <- false
                sccs.Add(scc)

        for td in typeDefs do
            let name = getTypeName td
            if not (indices.ContainsKey name) then
                strongconnect name

        // Tarjan naturally outputs SCCs with dependencies first.
        // Do NOT reverse - this is the correct compilation order.
        let orderedSCCs = sccs |> Seq.toList

        let originalIndex = typeDefs |> List.mapi (fun i td -> getTypeName td, i) |> Map.ofList

        orderedSCCs |> List.collect (fun scc ->
            let sorted = scc |> List.sortBy (fun name -> originalIndex |> Map.tryFind name |> Option.defaultValue 0)
            sorted |> List.mapi (fun i name ->
                let td = nameToTd.[name]
                let isRecursive = i > 0
                (td, isRecursive)
            )
        )

    /// Group TypeDefs by their assigned module, preserving dependency order within each group.
    let groupByModule (typeToModule: Map<string, string>) (orderedTypeDefs: (TypeDef * bool) list) : Map<string, (TypeDef * bool) list> =
        let grouped =
            orderedTypeDefs
            |> List.groupBy (fun (td, _) ->
                let name = getTypeName td
                typeToModule |> Map.tryFind name |> Option.defaultValue "misc")
        // Re-run topological ordering within each module group
        grouped
        |> List.map (fun (moduleName, types) ->
            let localTypeDefs = types |> List.map fst
            let localOrdered = topologicallyOrderForCompilation localTypeDefs
            moduleName, localOrdered)
        |> Map.ofList

    // --- module dependency computation ---

    /// For each module, compute which other modules it depends on.
    let computeModuleDependencies (typeToModule: Map<string, string>) (moduleGroups: Map<string, (TypeDef * bool) list>) : Map<string, Set<string>> =
        let allTypeNames = typeToModule |> Map.keys |> Set.ofSeq
        moduleGroups
        |> Map.map (fun moduleName types ->
            types
            |> List.collect (fun (td, _) ->
                let deps = getTypeDependencies allTypeNames td
                deps |> Set.toList
                |> List.choose (fun depName ->
                    let depModule =
                        typeToModule
                        |> Map.tryFind depName
                        |> Option.defaultValue "misc"
                    if depModule <> moduleName then Some depModule else None))
            |> Set.ofList)

    // --- Fabulous.AST widget builders for companion modules ---

    /// F# keywords that must be escaped with double backticks when used as identifiers.
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

    /// Escape an identifier with double backticks if it's an F# keyword.
    let private escapeKeyword (name: string) =
        if fsharpKeywords.Contains(name) then $"``{name}``" else name

    /// Serialize a companion module as raw text with a return-type-annotated create function.
    let serializeCompanionModule (name: string) (members: MemberInfo list) (newParams: ParamInfo list) : string =
        let sb = Text.StringBuilder()
        sb.AppendLine($"module {name} =") |> ignore

        for m in members do
            if not m.DocLines.IsEmpty then
                for line in m.DocLines do
                    sb.AppendLine($"    ///{line}") |> ignore
            let valueName = m.MemberName.Substring(0, 1).ToLower() + m.MemberName.Substring(1) |> escapeKeyword
            sb.AppendLine($"    let {valueName} = \"{m.Value}\"") |> ignore
            sb.AppendLine() |> ignore

        if not newParams.IsEmpty then
            // Only required params appear in the function signature; optional fields default to None
            let requiredParams = newParams |> List.filter (fun p -> not p.IsOptional)
            let createParams = if requiredParams.IsEmpty then newParams else requiredParams

            let paramStrings =
                createParams |> List.mapi (fun i p ->
                    let typeStr = if p.IsOptional then $"{p.ParamType} option" else p.ParamType
                    let comma = if i < createParams.Length - 1 then "," else ""
                    $"        {p.ParamName}: {typeStr}{comma}")

            sb.AppendLine("    let create") |> ignore
            sb.AppendLine("        (") |> ignore
            for line in paramStrings do
                sb.AppendLine($"    {line}") |> ignore
            sb.AppendLine($"        ) : {name}") |> ignore
            sb.AppendLine("        =") |> ignore

            let fieldStrings =
                newParams |> List.map (fun p ->
                    let flattenSuffix = if p.NeedsFlatten then " |> Option.flatten" else ""
                    let value =
                        if p.IsOptional && not (createParams |> List.exists (fun cp -> cp.ParamName = p.ParamName)) then
                            "None"
                        else
                            $"{p.ParamName}{flattenSuffix}"
                    $"          {p.PascalFieldName} = {value}")

            sb.AppendLine("        {") |> ignore
            for line in fieldStrings do
                sb.AppendLine(line) |> ignore
            sb.Append("        }") |> ignore

        sb.ToString()

    // --- type widget builders ---

    /// Build a complete type widget for a TypeDef (without members — members go to companion module)
    let buildTypeWidget (td: TypeDef) (isRecursive: bool) =
        match td with
        | SimpleEnum(name, cases, isStruct) ->
            let union =
                let u = Union(name) { for c in cases do buildUnionCaseWidget c }
                let u = if isStruct then u.attribute(Attribute("Struct")) else u
                if isRecursive then u.toRecursive() else u
            Some(Choice1Of2 union)  // Union widget

        | PayloadEnum(name, cases) ->
            let union =
                let u = Union(name) { for c in cases do buildUnionCaseWidget c }
                if isRecursive then u.toRecursive() else u
            Some(Choice1Of2 union)

        | RecordType(name, descLines, fields, _members, _newParams, _isSimple) ->
            let record =
                let r = Record(name) { for f in fields do buildFieldWidget f }
                let r = if not descLines.IsEmpty then r.xmlDocs(descLines) else r
                if isRecursive then r.toRecursive() else r
            Some(Choice2Of2 record)  // Record widget

        | EmptyType _ ->
            None  // EmptyType handled separately as raw string

    // --- file serialization ---

    /// Generate a raw string for an EmptyType declaration
    let serializeEmptyType (name: string) (descLines: string list) (members: MemberInfo list) (isRecursive: bool) (extraAttribute: string option) =
        let keyword = if isRecursive then "and" else "type"
        let descStr =
            if descLines.IsEmpty then ""
            else
                let docComment = descLines |> List.map (fun l -> $"///{l}") |> String.concat "\n"
                $"{docComment}\n"
        let attrStr =
            match extraAttribute with
            | Some attr -> $"{attr}\n"
            | None -> ""
        let membersStr =
            members |> List.map (fun m ->
                let docStr =
                    if m.DocLines.IsEmpty then ""
                    else
                        let dc = m.DocLines |> List.map (fun l -> $"    ///{l}") |> String.concat "\n"
                        $"{dc}\n"
                let jsonFieldPrefix =
                    match m.JsonFieldName with
                    | Some n -> $"[<JsonPropertyName(\"{n}\")>]"
                    | None -> ""
                $"{docStr}    {jsonFieldPrefix}member _.{m.MemberName} = \"{m.Value}\""
            ) |> String.concat "\n"
        let body =
            if members.IsEmpty then ""
            else $"\n{membersStr}\n"
        $"{descStr}{attrStr}{keyword} {name} () = {body}"

    /// Check if a module has any recursive types (types using 'and' keyword)
    let hasRecursiveTypes (types: (TypeDef * bool) list) =
        types |> List.exists (fun (_, isRec) -> isRec)

    /// Serialize a complete module file for one module group.
    let serializeModuleFile (version: string) (moduleName: string) (moduleDeps: Set<string>) (types: (TypeDef * bool) list) : string =
        let pascalName = pascalModuleName moduleName
        let namespaceName = $"Stripe.{pascalName}"

        let sb = Text.StringBuilder()

        // Header
        sb.AppendLine($"namespace {namespaceName}") |> ignore
        sb.AppendLine() |> ignore
        sb.AppendLine("open System.Text.Json.Serialization") |> ignore
        sb.AppendLine("open FunStripe") |> ignore
        sb.AppendLine("open System") |> ignore

        // Cross-module opens
        for dep in moduleDeps |> Set.toList |> List.sort do
            let depPascal = pascalModuleName dep
            sb.AppendLine($"open Stripe.{depPascal}") |> ignore

        sb.AppendLine() |> ignore

        let generatedCodeAttr = $"[<System.CodeDom.Compiler.GeneratedCode(\"FunStripe\", \"{version}\")>]"
        let generatedCodeAttrWidget = Attribute("System.CodeDom.Compiler.GeneratedCode", ParenExpr(ConstantExpr(Constant($"\"FunStripe\", \"{version}\""))))
        let mutable isFirst = true

        let isRecursiveModule = hasRecursiveTypes types

        if isRecursiveModule then
            // Recursive module: emit all types first, then all companion modules after
            for (td, isRec) in types do
                let firstAttr = if isFirst then Some generatedCodeAttr else None
                match td with
                | EmptyType(name, descLines, members, _isSimple) ->
                    let snippet = serializeEmptyType name descLines members isRec firstAttr
                    sb.AppendLine(snippet) |> ignore
                    sb.AppendLine() |> ignore
                | _ ->
                    let snippet =
                        let oak = Oak() { AnonymousModule() {
                            match td with
                            | SimpleEnum(name, cases, isStruct) ->
                                let u = Union(name) { for c in cases do buildUnionCaseWidget c }
                                let u =
                                    match isStruct, isFirst with
                                    | true, true -> u.attributes([Attribute("Struct"); generatedCodeAttrWidget])
                                    | true, false -> u.attribute(Attribute("Struct"))
                                    | false, true -> u.attribute(generatedCodeAttrWidget)
                                    | false, false -> u
                                if isRec then u.toRecursive() else u
                            | PayloadEnum(name, cases) ->
                                let u = Union(name) { for c in cases do buildUnionCaseWidget c }
                                let u = if isFirst then u.attribute(generatedCodeAttrWidget) else u
                                if isRec then u.toRecursive() else u
                            | RecordType(name, descLines, fields, _, _, _) ->
                                let r = Record(name) { for f in fields do buildFieldWidget f }
                                let r = if not descLines.IsEmpty then r.xmlDocs(descLines) else r
                                let r = if isFirst then r.attribute(generatedCodeAttrWidget) else r
                                if isRec then r.toRecursive() else r
                            | EmptyType _ -> ()  // Already handled above
                        } }
                        Gen.mkOak oak |> Gen.run
                    let trimmed = snippet.Trim()
                    if trimmed.Length > 0 then
                        sb.AppendLine(trimmed) |> ignore
                        sb.AppendLine() |> ignore
                isFirst <- false

            // Now emit all companion modules
            for (td, _) in types do
                match td with
                | RecordType(name, _, _, members, newParams, _) when not members.IsEmpty || not newParams.IsEmpty ->
                    let snippet = serializeCompanionModule name members newParams
                    sb.AppendLine(snippet.Trim()) |> ignore
                    sb.AppendLine() |> ignore

                | EmptyType(name, _, members, _) when not members.IsEmpty ->
                    let snippet = serializeCompanionModule name members []
                    sb.AppendLine(snippet.Trim()) |> ignore
                    sb.AppendLine() |> ignore

                | _ -> ()

        else
            // Non-recursive module: interleave types and companion modules
            for (td, isRec) in types do
                let firstAttr = if isFirst then Some generatedCodeAttr else None
                match td with
                | EmptyType(name, descLines, members, _isSimple) ->
                    let typeSnippet = serializeEmptyType name descLines members isRec firstAttr
                    sb.AppendLine(typeSnippet) |> ignore
                    sb.AppendLine() |> ignore
                    // Companion module for EmptyType
                    if not members.IsEmpty then
                        let modSnippet = serializeCompanionModule name members []
                        sb.AppendLine(modSnippet.Trim()) |> ignore
                        sb.AppendLine() |> ignore

                | RecordType(name, descLines, fields, members, newParams, _) ->
                    // Emit the record type
                    let typeSnippet =
                        let oak = Oak() { AnonymousModule() {
                            let r = Record(name) { for f in fields do buildFieldWidget f }
                            let r = if not descLines.IsEmpty then r.xmlDocs(descLines) else r
                            let r = if isFirst then r.attribute(generatedCodeAttrWidget) else r
                            if isRec then r.toRecursive() else r
                        } }
                        Gen.mkOak oak |> Gen.run
                    sb.AppendLine(typeSnippet.Trim()) |> ignore
                    sb.AppendLine() |> ignore

                    // Companion module
                    if not members.IsEmpty || not newParams.IsEmpty then
                        let modSnippet = serializeCompanionModule name members newParams
                        sb.AppendLine(modSnippet.Trim()) |> ignore
                        sb.AppendLine() |> ignore

                | SimpleEnum(name, cases, isStruct) ->
                    let snippet =
                        let oak = Oak() { AnonymousModule() {
                            let u = Union(name) { for c in cases do buildUnionCaseWidget c }
                            let u =
                                match isStruct, isFirst with
                                | true, true -> u.attributes([Attribute("Struct"); generatedCodeAttrWidget])
                                | true, false -> u.attribute(Attribute("Struct"))
                                | false, true -> u.attribute(generatedCodeAttrWidget)
                                | false, false -> u
                            if isRec then u.toRecursive() else u
                        } }
                        Gen.mkOak oak |> Gen.run
                    sb.AppendLine(snippet.Trim()) |> ignore
                    sb.AppendLine() |> ignore

                | PayloadEnum(name, cases) ->
                    let snippet =
                        let oak = Oak() { AnonymousModule() {
                            let u = Union(name) { for c in cases do buildUnionCaseWidget c }
                            let u = if isFirst then u.attribute(generatedCodeAttrWidget) else u
                            if isRec then u.toRecursive() else u
                        } }
                        Gen.mkOak oak |> Gen.run
                    sb.AppendLine(snippet.Trim()) |> ignore
                    sb.AppendLine() |> ignore

                isFirst <- false

        sb.ToString()

    // --- orchestration ---

    /// Run the full pipeline: parse -> assign -> group -> order -> serialize -> write files
    let generateAllModuleFiles (version: string) (outputDir: string) (specFilePath: string option) =
        // Step 1: Parse the spec into flat TypeDefs
        let typeDefs = parseModelFlat specFilePath
        printfn "Parsed %d type definitions" typeDefs.Length

        // Step 2: Topologically order types
        let orderedTypes = topologicallyOrder typeDefs
        printfn "Topologically ordered %d types" orderedTypes.Length

        // Step 3: Compute module assignments from spec (schema-level SCC + majority vote)
        let (typeToModule, moduleOrder) = computeModuleAssignmentsFromSpec specFilePath typeDefs
        printfn "Assigned types to modules, compilation order: %d modules" moduleOrder.Length

        // Step 4: Group by module
        let moduleGroups = groupByModule typeToModule orderedTypes
        printfn "Grouped into %d modules" moduleGroups.Count

        // Step 5: Compute cross-module dependencies for open statements
        let moduleDeps = computeModuleDependencies typeToModule moduleGroups
        printfn "Computed module dependencies"

        // Step 6: Ensure output directory exists
        Directory.CreateDirectory(outputDir) |> ignore

        // Step 7: Generate and write each module file
        let generatedFiles = ResizeArray<string>()
        for moduleName in moduleOrder do
            let types = moduleGroups |> Map.tryFind moduleName |> Option.defaultValue []
            if not types.IsEmpty then
                let deps = moduleDeps |> Map.tryFind moduleName |> Option.defaultValue Set.empty
                let content = serializeModuleFile version moduleName deps types
                let pascalName = pascalModuleName moduleName
                let fileName = $"{pascalName}.fs"
                let filePath = Path.Combine(outputDir, fileName)
                File.WriteAllText(filePath, content)
                generatedFiles.Add(fileName)
                let typeCount = types.Length
                let recCount = types |> List.filter (fun (_, isRec) -> isRec) |> List.length
                printfn "  %-25s %4d types (%d recursive)" fileName typeCount recCount

        printfn "\nGenerated %d files in %s" generatedFiles.Count outputDir

        // Return the ordered list of file names for .fsproj inclusion
        generatedFiles |> Seq.toList
