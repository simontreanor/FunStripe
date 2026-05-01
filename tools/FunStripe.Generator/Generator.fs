module FunStripe.Generator

open FunStripe
open System
open System.IO

let private parseArgs (argv: string array) =
    let args = argv |> Array.toList
    let getArg flag =
        args
        |> List.tryFindIndex ((=) flag)
        |> Option.bind (fun i -> args |> List.tryItem (i + 1))
    getArg "--spec", getArg "--output", getArg "--version"

[<EntryPoint>]
let main argv =
    let specPath, outputDir, version = parseArgs argv
    let version' = version |> Option.defaultValue "2.0.0"
    // Default output dir is the src/ folder relative to this source file's compile-time location
    let outputDir' =
        outputDir
        |> Option.defaultValue (Path.GetFullPath(Path.Combine(__SOURCE_DIRECTORY__, "../../src")))

    printfn "FunStripe code generator"
    printfn "  Spec:    %s" (specPath |> Option.defaultValue "(default)")
    printfn "  Output:  %s" outputDir'
    printfn "  Version: %s" version'
    printfn ""

    let normalizeLineEndings (s: string) =
        s.Replace("\r\n", "\n").Replace("\n", System.Environment.NewLine)

    // Resolve the spec path the same way the model builders do (default = bundled spec).
    let resolvedSpecPath =
        specPath
        |> Option.defaultValue (Path.GetFullPath(Path.Combine(__SOURCE_DIRECTORY__, "../../spec/stripe-openapi-2026-04-22.dahlia.json")))

    printfn "Generating StripeIds.fs..."
    StripeIdsBuilder.generate version' outputDir' resolvedSpecPath |> ignore

    printfn "Generating modular Stripe model files (Stripe/*.fs)..."
    let stripeModelDir = Path.Combine(outputDir', "Stripe")
    let modelFiles = ModelBuilderModular.generateAllModuleFiles version' stripeModelDir specPath
    printfn "  Written %d model module files" modelFiles.Length

    printfn "Generating modular StripeRequest files (StripeRequest/*.fs)..."
    let stripeRequestDir = Path.Combine(outputDir', "StripeRequest")
    let requestFiles = RequestBuilderAST.generateAllRequestFiles version' stripeRequestDir specPath
    printfn "  Written %d request module files" requestFiles.Length

    0
