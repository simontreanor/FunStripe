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

///Select the entire text of this module and press `Alt + Enter` to generate the `StripeService.fs` file
module ServiceBuilder =

    ///Convert `snake_case` to `PascalCase`
    let pascalCasify (s: string) =
        Regex.Replace(s, @"(^|_|\.| |-)(\w)", fun (m: Match) -> m.Groups.[2].Value.ToUpper())

    ///Convert `snake_case` to `camelCase`
    let camelCasify (s: string) =
        Regex.Replace(s, @"( |_|-)(\w)", fun (m: Match) -> m.Groups.[2].Value.ToUpper())

    ///Escape certain reserved names used in camel-case parameters
    let escapeReservedName name =
        match name with
        | "end"
        | "open"
        | "type" ->
            $"``{name}``"
        | _ ->
            name

    ///Format multiline comments correctly by inserting tabs and comment specifiers at the beginning of each line, and also formatting the HTML to display all paragraphs correctly
    let commentify (s: string) = 
        let s' = s.Replace("<p>", "").Replace("</p>", "").Replace("\n\n", "\n").Replace("\n", "\n\t\t///")
        $"<p>{s'}</p>"

    ///Utility function for appending lines to a StringBuilder
    let write s (sb: Text.StringBuilder) =
        sb.AppendLine s |> ignore

    ///Map JSON types to F# types
    let mapType (s: string) =
        match s with
        | "boolean" -> "bool"
        | "integer" -> "int"
        | "number" -> "decimal"
        | "array" -> "string list"
        | "object" -> "Map<string, string>"
        | _ -> s

    let mapParameters (parameters: JsonValue array) =
        parameters
        |> Array.map (fun jv ->
            let name'' = jv.GetProperty("name").AsString()
            let in' = jv.GetProperty("in").AsString()
            let required = jv.GetProperty("required").AsBoolean()
            let schema' = jv.GetProperty("schema")
            let type' =
                schema'.TryGetProperty("type") |> function
                | Some jv -> jv.AsString()
                | None ->
                    schema'.TryGetProperty("anyOf") |> function
                    | Some jv -> jv.AsArray() |> Array.find (fun jv' -> jv'.GetProperty("type").AsString() <> "object") |> fun jv' -> jv'.GetProperty("type").AsString()
                    | None -> ""
            (name'', in', required, type')
        )

    ///Format properties of a type
    let formatPropertiesString mappedParameters =
        (
            "\n\t\t\t",
            mappedParameters
            |> Array.sortBy (fun (n, in', req, t) -> if req then 0 else 1)
            |> Array.map (fun (n, in', req, t) ->
                let opt = if req then "" else " option"
                $"{n |> escapeReservedName |> pascalCasify}: {t |> mapType}{opt}"
            )
        ) |> String.Join

    ///Format parameters of a type
    let formatParametersString mappedParameters =
        (
            ", ",
            mappedParameters
            |> Array.sortBy (fun (n, in', req, t) -> if req then 0 else 1)
            |> Array.map (fun (n, in', req, t) ->
                let opt = if req then "" else "?"
                $"{opt}{n |> escapeReservedName |> camelCasify}: {t |> mapType}"
            )
        ) |> String.Join

    ///Format parameters assignments for the static `Create` method
    let formatParameterAssignments mappedParameters =
        (
            "\n\t\t\t\t\t",
            mappedParameters
            |> Array.sortBy (fun (n, in', req, t) -> if req then 0 else 1)
            |> Array.map (fun (n, in', req, t) ->
                let escapedName = n |> escapeReservedName
                $"{escapedName |> pascalCasify} = {escapedName |> camelCasify}"
            )
        ) |> String.Join

    ///Format querystring for path
    let formatQueryString mappedParameters =
        (
            "; ",
            mappedParameters
            |> Array.filter (fun (_, in', _, _) -> in' = "query")
            |> Array.sortBy (fun (_, _, req, _) -> if req then 0 else 1)
            |> Array.map (fun (n, _, _, _) ->
                $"(\"{n}\", options.{n |> escapeReservedName |> pascalCasify} |> box)"
            )
        ) |> String.Join

    ///Format request path to allow string interpolation of inline parameters
    let formatPathParams (path: string) =
        Regex.Replace(path, @"\{([^}]+)\}", fun m -> $"{{options.{m.Groups.[1].Value |> escapeReservedName |> pascalCasify}}}")

    ///Extract a type name from a JSON reference field
    let parseRef (s: string) =
        let m = Regex.Match(s, "/([^/]+)$")
        if m.Success then
            m.Groups.[1].Value
        else
            failwith $"Unparsable reference: {s}"

    ///Parses the Stripe OpenAPI specification, outputting an F# module specifying services (request groups) and requests
    let parseService filePath =
        let root = __SOURCE_DIRECTORY__

        let filePath' = defaultArg filePath $@"{root}/res/spec3.sdk.json"
        let json = File.ReadAllText(filePath')

        let root = JsonValue.Parse json
        let components = root.Item "components"
        let schemas = components.Item "schemas"
        let operationPaths = root.Item "paths"

        let servicePaths =
            schemas.Properties
            |> Array.filter(fun (k, v) ->
                v.Properties
                |> Array.exists(fun (k, _) -> k = "x-stripeOperations")
            )
            |> Array.map(fun (k, v) ->
                (
                    k,
                    v.Properties
                    |> Array.filter(fun (k, _) -> k = "x-stripeOperations")
                    |> Array.collect(fun (_, v) -> v.AsArray())
                    |> Array.filter(fun jv -> jv.TryGetProperty("method_on") |> function | Some p -> p.AsString() = "collection" || p.AsString() = "service" | _ -> false)
                    |> Array.map(fun jv -> (jv.GetProperty("method_name").AsString(), jv.GetProperty("operation").AsString(), jv.GetProperty("path").AsString()))
                )
            )

        let paths =
            operationPaths.Properties
            |> Array.filter(fun (path, _) -> path.Contains("x-stripe") |> not)
            |> Array.map(fun (path, operations) ->
                let pathRoot =
                    ("",
                        Regex.Split(path, "/")
                        |> Array.mapi(fun i p ->
                            match (i, p) with
                            | 0, _ | 1, _ -> None
                            | _, p when Regex.IsMatch(p, "^\{.+\}$") -> None
                            | _, p -> Some (p |> pascalCasify)
                        )
                        |> Array.choose id
                    ) |> String.Join
                    |> fun s -> Regex.Replace(s, "^3d", "ThreeD")

                let methodOperationPaths = operations.Properties |> Array.choose(fun (operation, _) ->
                    servicePaths
                    |> Array.collect snd
                    |> Array.tryFind(fun (_, o, p) -> o = operation && p = path)
                    |> Option.map(fun (m, _, _) -> (m, operation, path))
                )
                (pathRoot, methodOperationPaths)
            )
            |> Array.groupBy fst
            |> Array.map(fun (k, v) -> k, v |> Array.collect(fun(_, v') -> v'))

        let sb = Text.StringBuilder()

        sb |> write "namespace FunStripe\n\nopen StripeModel\nopen StripeRequest\n\nmodule StripeService =\n"

        paths
        |> Array.iter (fun (name, methodOperationPaths) ->

            sb |> write $"\tmodule {name} =\n"

            methodOperationPaths
            |> Array.iter (fun (method, operation, path) ->

                let method' = method |> pascalCasify

                operationPaths.Properties
                |> Array.find (fun (p, _) -> p = path)
                |> fun (_, v) -> v.Properties
                |> Array.filter (fun (verb, _) -> verb = operation)
                |> Array.iter (fun (verb, v) ->

                    //prep form values
                    let operationId = v.GetProperty("operationId").AsString()
                    let form =
                        v.GetProperty("requestBody").GetProperty("content").TryGetProperty("application/x-www-form-urlencoded") |> function
                        | Some jv -> jv
                        | None ->
                            v.GetProperty("requestBody").GetProperty("content").TryGetProperty("multipart/form-data") |> function
                            | Some jv -> jv
                            | None -> JsonValue.Null
                    let schema = form.TryGetProperty("schema") |> function | Some jv -> jv | None -> JsonValue.Null
                    let formParameters = schema.TryGetProperty("properties") |> function | Some jv -> jv.Properties | None -> [||]
                    let formParamsType = $"{name}'{method'}Options"
                    let formParam = if formParameters.Any() then $" (formOptions: {formParamsType})" else ""

                    //get request method
                    let description = v.GetProperty("description").AsString()
                    let queryParameters = v.TryGetProperty("parameters") |> function | Some jv -> jv.AsArray() | None -> [||]
                    let mappedParameters = queryParameters |> mapParameters
                    let queryParamsType = $"{method'}Options"
                    let qs = mappedParameters |> formatQueryString
                    let queryDeclaration = if qs = "" then "" else $"\t\t\tlet qs = [{qs}] |> Map.ofList"
                    let queryParam = if queryParameters.Any() then $" (options: {queryParamsType})" else ""
                    let query = if qs = "" then " (Map.empty)" else $" qs"

                    if queryParameters |> Array.isEmpty |> not then
                        sb |> write $"\t\ttype {queryParamsType} = {{"
                        sb |> write $"\t\t\t{(mappedParameters |> formatPropertiesString)}"
                        sb |> write $"\t\t}}"
                        sb |> write $"\t\twith"
                        sb |> write $"\t\t\tstatic member Create ({mappedParameters |> formatParametersString}) ="
                        sb |> write $"\t\t\t\t{{"
                        sb |> write $"\t\t\t\t\t{(mappedParameters |> formatParameterAssignments)}"
                        sb |> write $"\t\t\t\t}}\n"

                    sb |> write $"\t\t///{description |> commentify}"
                    sb |> write $"\t\tlet {method'} settings{formParam}{queryParam} ="
                    sb |> write queryDeclaration
                    sb |> write $"\t\t\t$\"{path |> formatPathParams}\""

                    //get response type
                    let responseSchema = v.GetProperty("responses").GetProperty("200").GetProperty("content").GetProperty("application/json").GetProperty("schema")
                    let responseType =
                        match responseSchema.TryGetProperty("$ref") with
                        | Some jv ->
                            jv.AsString()
                            |> parseRef |> pascalCasify
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
                                    failwith $"Unhandled response type: {name} %A{responseSchema}"

                    //set API method
                    match verb with
                    | "get" when formParameters.Any() ->
                        sb |> write $"\t\t\t|> RestApi.getWithAsync<_, {responseType}> settings{query} formOptions\n"
                    | "get" ->
                        sb |> write $"\t\t\t|> RestApi.getAsync<{responseType}> settings{query}\n"
                    | "post" when formParameters.Any() |> not ->
                        sb |> write $"\t\t\t|> RestApi.postWithoutAsync<{responseType}> settings{query}\n"
                    | "post" ->
                        sb |> write $"\t\t\t|> RestApi.postAsync<_, {responseType}> settings{query} formOptions\n"
                    | "delete" ->
                        sb |> write $"\t\t\t|> RestApi.deleteAsync<{responseType}> settings{query}\n"
                    | _ ->
                        failwith $"Unhandled verb: {verb}"

                )
            )
        )

        sb.ToString().Replace("\t", "    ")

#if INTERACTIVE
    ;;
    open ServiceBuilder;;
    let s = parseService None;;
    System.IO.File.WriteAllText(__SOURCE_DIRECTORY__ + "/StripeService.fs", s);;
#endif
