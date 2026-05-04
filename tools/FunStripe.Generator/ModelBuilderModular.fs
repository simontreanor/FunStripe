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

    // --- module assignment (canonical-domain prefix-match + schema-level SCC + majority-vote) ---

    /// Manual alias map: maps non-canonical "orphan" prefixes to the canonical Stripe domain
    /// they semantically belong to. Used after canonical-prefix matching to consolidate
    /// schemas whose names use Stripe-internal sub-prefixes that don't appear in the
    /// canonical domain list (top-level resources + dot-prefix domains).
    /// Keys are sorted longest-first by the lookup function below.
    let private canonicalAliases : Map<string, string> =
        Map.ofList [
            // Plural <-> singular (orphan plurals -> canonical singular)
            "invoices",      "invoice"
            "subscriptions", "subscription"
            "quotes",        "quote"
            "payments",      "payment_method"     // payments_primitives_*, payment_records_*
            "payment",       "payment_method"     // payment_flows_*, payment_method_config_*
            // Treasury sub-resources
            "inbound",       "treasury"
            "outbound",      "treasury"
            // Other known sub-prefixes
            "thresholds",    "subscription"
            "level3",        "charge"
            "klarna",        "payment_method"
            "bank",          "financial_connections"
            "portal",        "billing_portal"
            "confirmation",  "confirmation_token"
            "insights",      "radar"
            "rule",          "radar"
            "forwarded",     "forwarding"
            "gelato",        "identity"
            "legal",         "account"
            "connect",       "account"
            "credit",        "billing"
            "currency",      "price"
            "scheduled",     "sigma"
            "promotion",     "promotion_code"
            // Polymorphic external-account / line-item discriminators
            "external",      "account"
            "linked",        "account"
            "line_item",     "invoice"
            // Payment-method brand sub-prefixes
            "amazon",        "payment_method"
            "revolut",       "payment_method"
            // Misc
            "error",         "misc"
        ]

    /// Normalize a schema name by replacing '.' with '_' and lowercasing.
    let private normalizeSchemaKey (schemaName: string) =
        schemaName.ToLowerInvariant().Replace('.', '_')

    /// Strip a leading "deleted_" so deleted_X variants share the same module as X.
    let private stripDeleted (s: string) =
        if s.StartsWith "deleted_" then s.Substring("deleted_".Length) else s

    /// Multi-token prefix aliases: map a long underscore-separated prefix to a canonical domain.
    /// Checked AFTER canonical-domain longest-prefix match but BEFORE first-token fallback,
    /// in longest-prefix order. Use for schemas whose name starts with a token that's a
    /// canonical domain but whose semantic home is elsewhere (e.g. `payment_flows_amount_details`
    /// belongs with `payment_intent`, not the generic `payment_*` -> `payment_method` fallback).
    /// NOTE: only triggered when canonical match fails — but since `payment_flows_*` doesn't
    /// match any canonical domain (no `payment_flows.X` schemas), this works for those.
    let private prefixAliases : (string * string) list =
        [
            // payment_flows_* → split by sub-resource
            "payment_flows_amount_details",                  "payment_intent"
            "payment_flows_automatic_payment_methods_setup", "setup_intent"
            "payment_flows_automatic_payment_methods",       "payment_intent"
            "payment_flows_private_payment_methods_card",    "card"
            "payment_flows_private_payment_methods",         "payment_method"
            "payment_flows",                                 "payment_method"
            // Connect cross-domain references
            "connect_account_reference",                     "account"
            // Issuing terms-of-service: lives on account
            "card_issuing_account",                          "account"
            // automatic_tax_* → tax-related, but referenced from invoice/subscription;
            // pin to invoice (its primary user) to remove the spurious "automatic" module
            "automatic_tax",                                 "invoice"
            // api_errors: depends on payment_intent/setup_intent so must live downstream;
            // park in payment_method (the merged super-module) so the orphan "api" module disappears
            "api_errors",                                    "payment_method"
            // linked_account_options_*: financial_connections concepts
            "linked_account_options",                        "financial_connections"
            // legal_entity_*: account/person territory (already handled by `legal` token alias)
        ]
        |> List.sortByDescending (fun (k, _) -> k.Length)

    /// Try to map a non-canonical token to a canonical domain via:
    ///  1. Direct alias lookup (e.g. "subscriptions" -> "subscription")
    ///  2. Auto-pluralisation (if "fooS" was the token and "foo" is canonical)
    let private resolveAlias (canonicalSet: Set<string>) (token: string) : string option =
        match Map.tryFind token canonicalAliases with
        | Some t when canonicalSet.Contains t -> Some t
        | _ ->
            // Auto-strip a trailing 's' and see whether the singular is canonical
            if token.EndsWith "s" && token.Length > 1 then
                let singular = token.Substring(0, token.Length - 1)
                if canonicalSet.Contains singular then Some singular else None
            else None

    /// Try to match a multi-token prefix alias against the normalized schema name.
    let private resolvePrefixAlias (canonicalSet: Set<string>) (normalized: string) : string option =
        prefixAliases
        |> List.tryPick (fun (prefix, target) ->
            if (normalized = prefix || normalized.StartsWith(prefix + "_")) && canonicalSet.Contains target
            then Some target else None)

    /// Normalize a schema name to its semantic module name by longest-prefix match
    /// against a list of canonical Stripe domains (sorted longest-first).
    /// If no canonical match is found, tries the multi-token prefixAliases, then falls
    /// back to the first underscore-separated token, alias lookup, and orphan token as-is.
    let normalizedModuleForName (canonicalDomains: string list) (schemaName: string) =
        let canonicalSet = canonicalDomains |> Set.ofList
        let normalized = schemaName |> normalizeSchemaKey |> stripDeleted
        // First: check multi-token prefix aliases (highest priority — these override
        // canonical longest-prefix to redirect e.g. `payment_flows_amount_details` away
        // from the generic `payment_method` mapping).
        match resolvePrefixAlias canonicalSet normalized with
        | Some t -> t
        | None ->
        match canonicalDomains |> List.tryFind (fun d -> normalized = d || normalized.StartsWith(d + "_")) with
        | Some d -> d
        | None ->
            let firstToken =
                normalized.Split([|'_'|], StringSplitOptions.RemoveEmptyEntries)
                |> Array.tryHead
                |> Option.defaultValue "misc"
            // Try alias resolution; otherwise leave as orphan
            resolveAlias canonicalSet firstToken
            |> Option.defaultValue firstToken

    /// For a type SCC, compute the module name by majority-vote of canonical-domain matches.
    let normalizedModuleForGroup (canonicalDomains: string list) (members: string list) =
        members
        |> List.map (normalizedModuleForName canonicalDomains)
        |> List.countBy id
        |> List.sortBy (fun (name, count) -> (-count, name))
        |> List.head
        |> fst

    /// Recursively collect all schema $ref references from a JSON value.
    /// Skips refs inside an `anyOf` block when:
    ///   1. The block is "expandable" (contains a `string` member alongside `$ref`s).
    ///      These collapse to `StripeId<Markers.X>` in the F# output.
    ///   2. The block is "polymorphic" (multiple `$ref` members, no `string`).
    ///      These are emitted as inline DUs in the consuming module, but the
    ///      module-level dependency is satisfied by `open` statements alone —
    ///      the consuming module need only be ordered AFTER the variant modules,
    ///      it doesn't need to live in the same SCC as them. Skipping these refs
    ///      from the SCC analysis breaks otherwise-spurious cycles introduced by
    ///      webhook event payloads (e.g. `account.external_account.created.object`
    ///      embedding `bank_account | card | source`).
    /// Recursively collect schema $ref references with controllable anyOf-block elision.
    ///   - `skipExpandable`:   skip anyOf blocks containing a `string` + `$ref`s
    ///                         (these collapse to `StripeId<Markers.X>`)
    ///   - `skipPolymorphic`:  skip anyOf blocks with multiple `$ref`s (no string)
    ///                         (these emit as inline DUs; opening the variant modules
    ///                          satisfies the dep — useful for breaking spurious SCCs)
    /// Skipping polymorphic blocks is appropriate ONLY for SCC analysis; the variant
    /// modules must still be ordered before the consuming module, so the FULL graph
    /// (skipPolymorphic = false) is required for compile ordering.
    let rec collectSchemaRefsWith (skipExpandable: bool) (skipPolymorphic: bool) (element: JsonValue) : Set<string> =
        match element with
        | JsonValue.Record properties ->
            let anyOfClassification =
                properties
                |> Array.tryFind (fun (k, _) -> k = "anyOf")
                |> Option.bind (fun (_, v) ->
                    match v with
                    | JsonValue.Array items ->
                        let hasString =
                            items |> Array.exists (fun it ->
                                match it with
                                | JsonValue.Record p ->
                                    p |> Array.exists (fun (k, v) ->
                                        k = "type" &&
                                        match v with JsonValue.String "string" -> true | _ -> false)
                                | _ -> false)
                        let refCount =
                            items |> Array.sumBy (fun it ->
                                match it with
                                | JsonValue.Record p ->
                                    if p |> Array.exists (fun (k, _) -> k = "$ref") then 1 else 0
                                | _ -> 0)
                        // Classification:
                        //   single-target expandable  = string + exactly 1 $ref  (collapses to StripeId<_>)
                        //   multi-target expandable   = string + 2+ $refs        (emits DU; refs needed for ordering)
                        //   pure polymorphic          = 2+ $refs, no string      (emits DU; refs needed for ordering)
                        if hasString && refCount = 1 then Some "expandable"
                        elif hasString && refCount >= 2 then Some "multi_expandable"
                        elif not hasString && refCount >= 2 then Some "polymorphic"
                        else None
                    | _ -> None)

            let elide =
                match anyOfClassification with
                | Some "expandable" -> skipExpandable
                | Some "polymorphic" -> skipPolymorphic
                | _ -> false

            if elide then Set.empty
            else
                let refSet =
                    properties
                    |> Array.tryFind (fun (k, _) -> k = "$ref")
                    |> Option.bind (fun (_, v) ->
                        match v with
                        | JsonValue.String s when s.StartsWith("#/components/schemas/") ->
                            Some (s.Substring("#/components/schemas/".Length))
                        | _ -> None)
                    |> Option.toList |> Set.ofList
                let childSets = properties |> Array.map (fun (_, v) -> collectSchemaRefsWith skipExpandable skipPolymorphic v)
                childSets |> Array.fold Set.union refSet
        | JsonValue.Array elements ->
            elements |> Array.map (collectSchemaRefsWith skipExpandable skipPolymorphic) |> Array.fold Set.union Set.empty
        | _ -> Set.empty

    /// Default schema-level ref collection used for both SCC cycle detection and
    /// compile ordering. Skips only expandable anyOf blocks (which collapse to
    /// `StripeId<Markers.X>` and induce no module-level dep). Polymorphic anyOf
    /// blocks ARE retained — they emit as inline DUs whose variant types must be
    /// compiled before the consuming module, so the cycle (if any) is real and
    /// must be reflected in the SCC analysis.
    let collectSchemaRefs (element: JsonValue) : Set<string> =
        collectSchemaRefsWith true false element

    /// Alias retained for clarity at call sites where ordering is the goal.
    let collectSchemaRefsFull = collectSchemaRefs

    /// Threaded state for Tarjan's SCC algorithm.
    type private TarjanState<'a when 'a : comparison> = {
        Index: int
        Stack: 'a list
        Disc: Map<'a, int>
        Low: Map<'a, int>
        OnStack: Set<'a>
        Sccs: 'a list list
    }

    /// Functional Tarjan's SCC algorithm.
    /// Returns SCCs in topological order (dependencies before dependents).
    let private tarjanScc (graph: Map<'a, Set<'a>>) : 'a list list when 'a : comparison =
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

        // --- Build canonical Stripe domain list ---
        // A canonical domain is either:
        //   1. A dot-prefix from any schema name (e.g. "financial_connections" from "financial_connections.account")
        //   2. A non-dot top-level resource: a schema with an `object` property whose enum value matches its own name
        //      (e.g. "customer", "payment_intent", "subscription_schedule")
        // Sorted longest-first so prefix matching prefers more specific domains.
        let canonicalDomains =
            let dotPrefixes =
                schemas.Properties
                |> Array.choose (fun (name, _) ->
                    if name.Contains '.' then Some (name.Split('.').[0]) else None)
                |> Set.ofArray
            let topLevelNames =
                schemas.Properties
                |> Array.choose (fun (name, schema) ->
                    if name.Contains '.' then None
                    else
                        match schema.TryGetProperty "properties" with
                        | Some (JsonValue.Record _ as props) ->
                            match props.TryGetProperty "object" with
                            | Some (JsonValue.Record _ as objProp) ->
                                match objProp.TryGetProperty "enum" with
                                | Some (JsonValue.Array [| JsonValue.String s |]) when s = name -> Some name
                                | _ -> None
                            | _ -> None
                        | _ -> None)
                |> Set.ofArray
            // Exclude "deleted_*" pseudo top-level resources (they're not real domains)
            let combined =
                Set.union dotPrefixes topLevelNames
                |> Set.filter (fun d -> not (d.StartsWith "deleted_"))
            combined
            |> Set.toList
            |> List.sortByDescending String.length

        printfn "Canonical Stripe domains: %d (e.g. %s, ...)"
            canonicalDomains.Length
            (canonicalDomains |> List.truncate 5 |> String.concat ", ")

        // Build schema dependency graph from raw $ref links
        let dependencyGraph =
            schemas.Properties
            |> Array.map (fun (key, schema) ->
                let refs = collectSchemaRefs schema |> Set.filter (fun d -> schemaNames.Contains d && d <> key)
                key, refs)
            |> Map.ofArray

        // Full graph (polymorphic anyOf refs retained) — used for cross-SCC ordering only.
        // Module-level ordering must respect DU variant deps so consumers are emitted
        // AFTER all their referenced variant modules, even when the cycle-detection
        // graph (above) elides those refs to break spurious schema-level cycles.
        let dependencyGraphFull =
            schemas.Properties
            |> Array.map (fun (key, schema) ->
                let refs = collectSchemaRefsFull schema |> Set.filter (fun d -> schemaNames.Contains d && d <> key)
                key, refs)
            |> Map.ofArray

        // Schema-level Tarjan SCC
        let sccList =
            tarjanScc dependencyGraph
            |> List.map List.sort

        // Assign each SCC to a module by majority vote against canonical domains
        let initialSccToModule =
            sccList |> List.mapi (fun i members -> i, normalizedModuleForGroup canonicalDomains members) |> Map.ofList
        let schemaToSccId =
            sccList
            |> List.mapi (fun i members -> members |> List.map (fun m -> m, i))
            |> List.collect id |> Map.ofList
        let initialSchemaToModule =
            schemaToSccId |> Map.map (fun _ sccId -> initialSccToModule.[sccId])

        // --- Orphan reassignment ---
        // Schemas whose initial module is NOT a canonical domain are "orphans"
        // (e.g. bank_connections_resource_* -> "bank", which is not canonical).
        // Reassign each orphan SCC to the canonical module that references it most frequently.
        let canonicalSet = canonicalDomains |> Set.ofList
        let isCanonical m = canonicalSet.Contains m

        let orphanSccs =
            initialSccToModule
            |> Map.toList
            |> List.filter (fun (_, m) -> not (isCanonical m))
            |> List.map fst

        let sccToModule =
            let mutable mapping = initialSccToModule
            for orphanSccId in orphanSccs do
                let orphanSchemas = sccList.[orphanSccId] |> Set.ofList
                // Count incoming references from each canonical module
                let canonicalRefCounts =
                    dependencyGraph
                    |> Map.toSeq
                    |> Seq.collect (fun (fromSchema, refs) ->
                        let fromSccId = schemaToSccId.[fromSchema]
                        if fromSccId = orphanSccId then Seq.empty
                        else
                            let fromModule = mapping.[fromSccId]
                            if isCanonical fromModule then
                                refs
                                |> Set.toSeq
                                |> Seq.filter orphanSchemas.Contains
                                |> Seq.map (fun _ -> fromModule)
                            else Seq.empty)
                    |> Seq.countBy id
                    |> Seq.sortByDescending snd
                    |> Seq.toList
                match canonicalRefCounts with
                | (winner, _) :: _ -> mapping <- mapping.Add(orphanSccId, winner)
                | [] -> ()  // No canonical module references it; leave as-is
            mapping

        let schemaToModule =
            schemaToSccId |> Map.map (fun _ sccId -> sccToModule.[sccId])

        // Report any remaining non-canonical orphans
        let remainingOrphans =
            sccToModule
            |> Map.toSeq
            |> Seq.map snd
            |> Seq.distinct
            |> Seq.filter (not << isCanonical)
            |> Seq.toList
        if not remainingOrphans.IsEmpty then
            printfn "Non-canonical orphan modules (no canonical incoming refs): %s"
                (String.concat ", " remainingOrphans)

        // Compute SCC-level dependency graph using the FULL graph so that module
        // ordering respects polymorphic-anyOf DU variant deps. Self-edges (within an
        // SCC) are filtered out, so this can't reintroduce the spurious cycles that
        // motivated polymorphic skipping in the SCC-detection graph above.
        let sccDeps =
            sccList |> List.mapi (fun sccId members ->
                let outgoing =
                    members
                    |> List.collect (fun m ->
                        dependencyGraphFull |> Map.tryFind m |> Option.defaultValue Set.empty |> Set.toList)
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
        let moduleSccList =
            tarjanScc moduleDeps
            |> List.map List.sort

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

        // Kahn's topological sort over module SCCs
        // in-degree = number of dependencies (things this node depends on); sources (in-degree 0) go first
        let inDegrees =
            moduleSccDeps
            |> Map.map (fun _ deps -> Set.count deps)

        // Reverse map: for each node v, which nodes depend on v
        let dependents =
            moduleSccDeps
            |> Map.toSeq
            |> Seq.collect (fun (u, deps) -> deps |> Seq.map (fun dep -> dep, u))
            |> Seq.groupBy fst
            |> Seq.map (fun (dep, pairs) -> dep, pairs |> Seq.map snd |> Set.ofSeq)
            |> Map.ofSeq

        let initialQueue =
            inDegrees
            |> Map.toList
            |> List.choose (fun (v, d) -> if d = 0 then Some v else None)

        let orderedModuleSccIds =
            List.unfold
                (fun (queue, inDegrees) ->
                    match queue with
                    | [] -> None
                    | v :: rest ->
                        let inDegrees', newlyZero =
                            dependents
                            |> Map.tryFind v
                            |> Option.defaultValue Set.empty
                            |> Set.fold
                                (fun (degs, zeros) u ->
                                    let d = Map.find u degs - 1
                                    Map.add u d degs, if d = 0 then u :: zeros else zeros)
                                (inDegrees, [])
                        Some(v, (rest @ newlyZero, inDegrees')))
                (initialQueue, inDegrees)

        let moduleOrder =
            orderedModuleSccIds
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

        // Final schema -> merged module mapping (canonical-domain assignment + orphan reassignment + module-SCC merging)
        let schemaToMergedModule =
            schemaToModule |> Map.map (fun _ rawModule -> moduleToMergedName.[rawModule])

        (typeToModule, moduleOrder, schemaToMergedModule, moduleToMergedName)

    // --- module grouping ---

    /// Convert a module name (snake_case) to PascalCase for the file/namespace name.
    /// E.g. "financial_connections" -> "FinancialConnections", "customer" -> "Customer".
    let pascalModuleName (moduleName: string) =
        moduleName.Split([|'_'|], StringSplitOptions.RemoveEmptyEntries)
        |> Array.map (fun s ->
            if s.Length = 0 then s
            else s.Substring(0, 1).ToUpper() + s.Substring(1))
        |> String.concat ""

    /// Topologically order type definitions for compilation (dependencies before dependents).
    let topologicallyOrderForCompilation (typeDefs: TypeDef list) : (TypeDef * bool) list =
        let nameToTd = typeDefs |> List.map (fun td -> getTypeName td, td) |> Map.ofList
        let allNames = typeDefs |> List.map getTypeName |> Set.ofList
        let deps = typeDefs |> List.map (fun td -> getTypeName td, getTypeDependencies allNames td) |> Map.ofList

        // Tarjan naturally outputs SCCs with dependencies first.
        // Do NOT reverse - this is the correct compilation order.
        let orderedSCCs = tarjanScc deps

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

    /// Emit a `type X with static member New(...) = { ... }` augmentation block as raw text
    /// for a record type. This allows callers to construct records via named/optional
    /// parameters rather than requiring the full positional record literal.
    /// Returns an empty string when there are no params (so the caller can append unconditionally).
    let serializeRecordNewMember (name: string) (newParams: ParamInfo list) : string =
        if newParams.IsEmpty then "" else
        let sb = Text.StringBuilder()
        sb.AppendLine($"type {name} with") |> ignore
        // Parameter list — required first, then optional with `?` prefix
        let sortedParams =
            (newParams |> List.filter (fun p -> not p.IsOptional)) @
            (newParams |> List.filter (fun p -> p.IsOptional))
        let paramStrs =
            sortedParams |> List.map (fun p ->
                let prefix = if p.IsOptional then "?" else ""
                $"{prefix}{p.ParamName}: {p.ParamType}")
        let paramList = String.concat ", " paramStrs
        sb.AppendLine($"    static member New({paramList}) =") |> ignore
        sb.AppendLine("        {") |> ignore
        for p in newParams do
            let body =
                if p.NeedsFlatten then $"{p.ParamName} |> Option.flatten"
                else p.ParamName
            sb.AppendLine($"            {p.PascalFieldName} = {body}") |> ignore
        sb.AppendLine("        }") |> ignore
        sb.ToString()

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

            // Now emit all companion modules (static members only — no create for response models)
            // and `with static member New` augmentations for records.
            for (td, _) in types do
                match td with
                | RecordType(name, _, _, members, newParams, _) ->
                    if not newParams.IsEmpty then
                        let augSnippet = serializeRecordNewMember name newParams
                        sb.AppendLine(augSnippet.TrimEnd()) |> ignore
                        sb.AppendLine() |> ignore
                    if not members.IsEmpty then
                        let snippet = serializeCompanionModule name members []
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

                    // `with static member New(...)` augmentation for ergonomic construction
                    if not newParams.IsEmpty then
                        let augSnippet = serializeRecordNewMember name newParams
                        sb.AppendLine(augSnippet.TrimEnd()) |> ignore
                        sb.AppendLine() |> ignore

                    // Companion module (static members only — no create for response models)
                    if not members.IsEmpty then
                        let modSnippet = serializeCompanionModule name members []
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
        let (typeToModule, moduleOrder, _schemaToMergedModule, _moduleToMergedName) = computeModuleAssignmentsFromSpec specFilePath typeDefs
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

        // Emit a .props file alongside the generated modules so consuming .fsproj files can
        // import modular compilation order without manual upkeep.
        let propsPath = Path.Combine(outputDir, "Stripe.Modular.props")
        let propsLines = ResizeArray<string>()
        propsLines.Add("<!-- Auto-generated by FunStripe.Generator. Do not edit. -->")
        propsLines.Add("<Project>")
        propsLines.Add("  <ItemGroup>")
        for f in generatedFiles do
            propsLines.Add(sprintf "    <Compile Include=\"$(MSBuildThisFileDirectory)%s\" Link=\"Stripe/%s\" />" f f)
        propsLines.Add("  </ItemGroup>")
        propsLines.Add("</Project>")
        File.WriteAllText(propsPath, String.concat "\n" propsLines + "\n")
        printfn "Emitted %s" propsPath

        // Return the ordered list of file names for .fsproj inclusion
        generatedFiles |> Seq.toList
