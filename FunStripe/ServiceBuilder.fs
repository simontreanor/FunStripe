#if INTERACTIVE
    #r "nuget: FSharp.Data";;
#else
namespace FunStripe
#endif

open FSharp.Data
open FSharp.Data.JsonExtensions
open System
open System.IO
open System.Linq
open System.Text.RegularExpressions

module ServiceBuilder =

    type Property = {
        AnyOf: JsonValue array option
        Description: string option
        Enum: JsonValue array option
        Items: JsonValue option
        Nullable: bool option
        Ref: string option
        Type': string option
    }

    let commentify (s: string) = 
        s.Replace("\n", "\n\t///")

    let clean (s: string) =
        s.Replace("-", "").Replace(" ", "")

    let casify (s: string) =
        let convertCase s = Regex.Replace(s, @"(^|_|\.)(\w)", fun (m: Match) -> m.Groups.[2].Value.ToUpper())

        if Regex.IsMatch(s, @"^\p{Lu}") then
            $@"[<JsonUnionCase(""{s}"")>] {s |> clean |> convertCase}"
        else
            if Regex.IsMatch(s, @"^\d") then
                $@"[<JsonUnionCase(""{s}"")>] Numeric{s |> clean |> convertCase}"
            elif s.Contains("-") || s.Contains(" ") then
                $@"[<JsonUnionCase(""{s}"")>] {s |> clean |> convertCase}"
            else
                s |> clean |> convertCase

    let parseRef (s: string) =
        let m = Regex.Match(s, "/([^/]+)$")
        if m.Success then
            m.Groups.[1].Value
        else
            failwith $"Error: unparsable reference: {s}"

    let mapType (s: string) =
        match s with
        | "boolean" -> "bool"
        | "integer" -> "int"
        | "number" -> "decimal"
        | _ -> s

    let getProperties (jv: JsonValue) =
        {
            AnyOf = jv.TryGetProperty("anyOf") |> function | Some v -> v.AsArray() |> Some | None -> None
            Description = jv.TryGetProperty("description") |> function | Some v -> v.AsString() |> Some | None -> None
            Enum = jv.TryGetProperty("enum") |> function | Some v -> v.AsArray() |> Some | None -> None
            Items = jv.TryGetProperty("items") |> function | Some v -> v |> Some | None -> None
            Nullable = jv.TryGetProperty("nullable") |> function | Some v -> v.AsBoolean() |> Some | None -> None
            Ref = jv.TryGetProperty("$ref") |> function | Some v -> v.AsString() |> Some | None -> None
            Type' = jv.TryGetProperty("type") |> function | Some v -> v.AsString() |> mapType |> Some | None -> None
        }

    let createEnum name (jvv: JsonValue array) =
        let s = 
            ("", 
                jvv
                |> Array.map(fun jv -> $"\t\t| {jv.AsString() |> casify}\n")
            ) |> String.Join
        $"\tand {name} =\n{s}"

    let createEnum2 name (ss: string seq) =
        let s = 
            ("", 
                ss
                |> Seq.map(fun s -> $"\t\t| {s |> casify}\n")
            ) |> String.Join
        $"\tand {name} =\n{s}"

    let parseStringEnum desc =
        let m = Regex.Match(desc, @"Can be `([^`]+)`(?:[^,]*?, `([^`]+)`)*[^,]*?,? or (?:`([^`]+)`|null).")
        if m.Success then
            m.Groups.Cast<Group>()
            |> Seq.skip 1
            |> Seq.collect(fun g -> g.Captures.Cast<Capture>())
            |> Seq.map(fun c -> c.Value)
            |> Some
        else
            None

    let createAnyOf name (jvv: JsonValue array) =
        let s =
            ("", 
                jvv
                |> Array.map(fun jv ->
                    let props = jv |> getProperties
                    match props.Type' with
                    | Some t ->
                        $"\t\t| {t |> casify} of {t}\n"
                    | _ ->
                    
                        match props.Ref with
                        | Some r ->
                            let refName = (r |> parseRef |> casify)
                            $"\t\t| {refName} of {refName}\n"
                        | None ->
                            ""
                )
            ) |> String.Join
        $"\tand {name} =\n{s}"

    let write s (sb: Text.StringBuilder) =
        sb.AppendLine s |> ignore

    let parseService filePath =

        let root = __SOURCE_DIRECTORY__

        let filePath' = defaultArg filePath $@"{root}/res/spec3.sdk.json"
        let json = File.ReadAllText(filePath')

        let root = JsonValue.Parse json
        let components = root.Item "components"
        let schemas = components.Item "schemas"

        let sb = Text.StringBuilder()

        let mutable isFirstOccurrence = true

        sb |> write "namespace FunStripe\n\nopen FSharp.Json\n\nopen StripeModel\n\nmodule StripeService =\n"
        
        for (key, value) in schemas.Properties do
            let name = key |> casify

            let keyword =
                if isFirstOccurrence then
                    isFirstOccurrence <- false
                    "type"
                else
                    "and"

            value.Properties
            |> Array.filter(fun (k0, _) -> k0 = "x-stripeOperations")
            |> Array.iter(fun(k0, v0) ->
                sb |> write $"\t{keyword} {name}Service(?apiKey: string) = \n"
                sb |> write "\t\tmember _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)\n"

                v0.AsArray()
                |> Array.iter(fun jv ->
                    let path = jv.GetProperty("path").AsString()
                    let method = jv.GetProperty("method_name").AsString()
                    let parameters = jv.TryGetProperty("path_resource_variables") |> function | Some jv -> jv.AsArray() | None -> [||]
                    let verb = jv.GetProperty("operation").AsString()
                    let body = if verb = "get" || verb = "delete" then "" else "_, "

                    let formatParams (jvv: JsonValue array) =
                        (", ", 
                            jvv
                            |> Array.map(fun jv -> jv.GetProperty("name").AsString())
                        ) |> String.Join

                    sb |> write $"\t\tmember this.{method |> casify} ({parameters |> formatParams}) ="
                    sb |> write $"\t\t\t$\"{path}\""
                    sb |> write $"\t\t\t|> this.RestApiClient.{verb |> casify}Async<{body}{name}>\n"

                    //sb |> write $"%A{jv}"
                )
            )
            
        sb.ToString().Replace("\t", "    ")

#if INTERACTIVE
    ;;
    open ServiceBuilder;;
    let s = parseService None;;
    System.IO.File.WriteAllText(__SOURCE_DIRECTORY__ + "/StripeService.fs", s);;
#endif
