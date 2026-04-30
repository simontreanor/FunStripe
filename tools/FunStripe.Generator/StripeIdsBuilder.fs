namespace FunStripe

open FSharp.Data
open FSharp.Data.JsonExtensions
open System.IO
open System.Text

/// Generates `src/StripeIds.fs`, a small leaf module containing:
///   * `StripeId<'phantom>` — a phantom-typed wrapper around a Stripe resource ID string.
///   * `module Markers` — one zero-cost class type per resource that appears as a
///     single-target expandable reference in the spec. These markers carry no runtime
///     state; their only purpose is to preserve the relationship between an ID field
///     and its target resource at compile time.
///
/// The file is emitted before `StripeModel.fs` and `Stripe/*.fs` in the project file
/// because every generated record may reference `StripeId<Markers.X>` or `Markers.X`.
module StripeIdsBuilder =

    open ModelParsing  // pascalCasify

    /// Recursively collect schema names that appear as single-target expandable refs.
    /// Pattern: anyOf containing exactly one `{type: string}` entry plus exactly one
    /// `{$ref: #/components/schemas/X}` entry. Multi-target expandables are also
    /// included so their targets get markers (in case future generator passes opt
    /// to use them).
    let rec private collectExpandableTargets (element: JsonValue) : Set<string> =
        match element with
        | JsonValue.Record properties ->
            let directTargets =
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
                        let refs =
                            items |> Array.choose (fun it ->
                                match it with
                                | JsonValue.Record p ->
                                    p |> Array.tryPick (fun (k, v) ->
                                        if k = "$ref" then
                                            match v with
                                            | JsonValue.String s when s.StartsWith("#/components/schemas/") ->
                                                Some (s.Substring("#/components/schemas/".Length))
                                            | _ -> None
                                        else None)
                                | _ -> None)
                        if hasString && refs.Length > 0 then Some (Set.ofArray refs) else None
                    | _ -> None)
                |> Option.defaultValue Set.empty
            let childSets = properties |> Array.map (fun (_, v) -> collectExpandableTargets v)
            childSets |> Array.fold Set.union directTargets
        | JsonValue.Array elements ->
            elements |> Array.map collectExpandableTargets |> Array.fold Set.union Set.empty
        | _ -> Set.empty

    /// Collect every distinct PascalCase target schema referenced by an expandable anyOf
    /// anywhere in the spec. Sorted alphabetically for stable output.
    let private collectMarkers (specPath: string) : string list =
        let json = File.ReadAllText specPath
        let root = JsonValue.Parse json
        let schemas = root?components?schemas
        match schemas with
        | JsonValue.Record props ->
            props
            |> Array.collect (fun (_, schema) -> collectExpandableTargets schema |> Set.toArray)
            |> Set.ofArray
            |> Set.map pascalCasify
            |> Set.toList
            |> List.sort
        | _ -> []

    /// Emit the F# source for `src/StripeIds.fs`.
    let private emitSource (version: string) (markers: string list) : string =
        let sb = StringBuilder()
        let appendLine (s: string) = sb.AppendLine(s : string) |> ignore
        appendLine "namespace FunStripe"
        appendLine ""
        appendLine $"[<System.CodeDom.Compiler.GeneratedCode(\"FunStripe\", \"{version}\")>]"
        appendLine "[<AutoOpen>]"
        appendLine "module StripeIds ="
        appendLine ""
        appendLine "    /// A phantom-typed Stripe resource identifier."
        appendLine "    /// `'phantom` is a zero-cost type tag (see `Markers`) that records which"
        appendLine "    /// resource this ID points at. Wire-form is a plain string."
        appendLine "    type StripeId<'phantom> = StripeId of string"
        appendLine ""
        appendLine ("[<System.CodeDom.Compiler.GeneratedCode(\"FunStripe\", \"" + version + "\")>]")
        appendLine "module Markers ="
        appendLine ""
        appendLine "    // Phantom marker types — one per resource that appears as a single-target"
        appendLine "    // expandable reference in the Stripe OpenAPI spec. They have no fields and"
        appendLine "    // no runtime cost; they exist solely to parameterise StripeId<'phantom>."
        for m in markers do
            appendLine $"    type {m} = class end"
        sb.ToString()

    /// Generate `src/StripeIds.fs` and return its full path.
    let generate (version: string) (outputDir: string) (specPath: string) : string =
        let markers = collectMarkers specPath
        let source = emitSource version markers
        let path = Path.Combine(outputDir, "StripeIds.fs")
        let normalized = source.Replace("\r\n", "\n").Replace("\n", System.Environment.NewLine)
        File.WriteAllText(path, normalized)
        printfn "  Written StripeIds.fs (%d markers)" markers.Length
        path
