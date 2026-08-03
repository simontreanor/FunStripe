module FunStripe.Generator

open FunStripe
open System
open System.IO
open System.Xml.Linq

let private parseArgs (argv: string array) =
    let args = argv |> Array.toList
    let getArg flag =
        args
        |> List.tryFindIndex ((=) flag)
        |> Option.bind (fun i -> args |> List.tryItem (i + 1))
    getArg "--spec", getArg "--output", getArg "--version"

/// Repo root, relative to this source file's compile-time location.
let private repoRoot = Path.GetFullPath(Path.Combine(__SOURCE_DIRECTORY__, "../.."))

/// Read a property value from the centralised /Directory.Build.props (the single source
/// of truth for FunStripeVersion and StripeApiVersion), so the generator's defaults never
/// drift from the published package version.
let private readBuildProp (name: string) =
    let propsPath = Path.Combine(repoRoot, "Directory.Build.props")
    if File.Exists propsPath then
        XDocument.Load(propsPath).Descendants(XName.Get name)
        |> Seq.tryHead
        |> Option.map (fun e -> e.Value.Trim())
        |> Option.filter (fun v -> v <> "")
    else
        None

[<EntryPoint>]
let main argv =
    let specPath, outputDir, version = parseArgs argv
    // Default the version from the single source of truth rather than a hard-coded literal
    // (a stale literal previously stamped the wrong version into generated files).
    let version' =
        version
        |> Option.orElse (readBuildProp "FunStripeVersion")
        |> Option.defaultValue "0.0.0"
    // Default output dir is the src/ folder relative to this source file's compile-time location
    let outputDir' =
        outputDir
        |> Option.defaultValue (Path.GetFullPath(Path.Combine(__SOURCE_DIRECTORY__, "../../src")))

    printfn "FunStripe code generator"
    printfn "  Spec:    %s" (specPath |> Option.defaultValue "(default)")
    printfn "  Output:  %s" outputDir'
    printfn "  Version: %s" version'
    printfn ""

    // Ensure the output directory exists; StripeIds.fs is written to its root directly.
    Directory.CreateDirectory(outputDir') |> ignore

    let normalizeLineEndings (s: string) =
        s.Replace("\r\n", "\n").Replace("\n", System.Environment.NewLine)

    // Resolve the spec path the same way the model builders do; default to the bundled spec
    // for the StripeApiVersion recorded in /Directory.Build.props.
    let resolvedSpecPath =
        specPath
        |> Option.defaultValue (
            match readBuildProp "StripeApiVersion" with
            | Some v -> Path.Combine(repoRoot, "spec", $"stripe-openapi-{v}.json")
            | None -> Path.Combine(repoRoot, "spec", "stripe-openapi-2026-04-22.dahlia.json"))

    printfn "Generating StripeIds.fs..."
    StripeIdsBuilder.generate version' outputDir' resolvedSpecPath |> ignore

    printfn "Generating modular Stripe model files (Stripe/*.fs)..."
    let stripeModelDir = Path.Combine(outputDir', "Stripe")
    let modelFiles = ModelBuilderModular.generateAllModuleFiles version' stripeModelDir (Some resolvedSpecPath)
    printfn "  Written %d model module files" modelFiles.Length

    printfn "Generating modular StripeRequest files (StripeRequest/*.fs)..."
    let stripeRequestDir = Path.Combine(outputDir', "StripeRequest")
    let requestFiles = RequestBuilderAST.generateAllRequestFiles version' stripeRequestDir (Some resolvedSpecPath)
    printfn "  Written %d request module files" requestFiles.Length

    0
