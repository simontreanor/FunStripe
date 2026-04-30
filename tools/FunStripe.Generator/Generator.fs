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
    let version' = version |> Option.defaultValue "1.0.0"
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

    printfn "Generating StripeModel.fs..."
    let model = ModelBuilder.parseModel specPath
    let modelContent = ModelBuilder.serializeModel version' model
    File.WriteAllText(Path.Combine(outputDir', "StripeModel.fs"), modelContent |> normalizeLineEndings)
    printfn "  Written StripeModel.fs"

    printfn "Generating StripeRequest files..."
    let request = RequestBuilder.parseRequest specPath
    RequestBuilder.serializeModelByGroups version' outputDir' request
    let requestContent = RequestBuilder.serializeModel version' request
    File.WriteAllText(Path.Combine(outputDir', "StripeRequest.fs"), requestContent |> normalizeLineEndings)
    printfn "  Written StripeRequest.fs and per-group files"

    printfn "Generating modular Stripe model files (Stripe/*.fs)..."
    let stripeModelDir = Path.Combine(outputDir', "Stripe")
    let modelFiles = ModelBuilderModular.generateAllModuleFiles version' stripeModelDir specPath
    printfn "  Written %d model module files" modelFiles.Length

    printfn "Generating modular StripeRequest files (StripeRequest/*.fs)..."
    let stripeRequestDir = Path.Combine(outputDir', "StripeRequest")
    let requestFiles = RequestBuilderAST.generateAllRequestFiles version' stripeRequestDir specPath
    printfn "  Written %d request module files" requestFiles.Length

    0
