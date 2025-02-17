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

///Select the entire text of this module and press `Alt + Enter` to generate the `StripeRequest.fs` file
module RequestBuilder =

    type OptionType =
        | Form
        | Path
        | Query
        | Undefined

    ///Record for OpenAPI parameter object
    type ParameterObject = {
        Description: string
        In: OptionType
        Name: string
        Required: bool
        Schema: JsonValue
        Type: string
    }

    ///Map JSON types to F# types for parameters
    let mapParameterType (s: string) =
        match s with
        | "boolean" -> "bool"
        | "integer" -> "int"
        | "number" -> "decimal"
        | "array" -> "string list"
        | "object" -> "Map<string, string>"
        | _ -> s

    ///Parse a `JsonValue` into an OpenAPI parameter-object record
    let getParameterObject (jv: JsonValue) =
        let schema = jv.TryGetProperty("schema") |> Option.map id |> Option.defaultValue JsonValue.Null
        {
            Description = jv.TryGetProperty("description") |> Option.map(fun v -> v.AsString()) |> Option.defaultValue ""
            In = jv.GetProperty("in").AsString() |> function | "path" -> Path | "query" -> Query | _ -> Undefined
            Name = jv.TryGetProperty("name") |> Option.map(fun v -> v.AsString()) |> Option.defaultValue ""
            Required = jv.TryGetProperty("required") |> Option.map(fun v -> v.AsBoolean()) |> Option.defaultValue false
            Schema = schema
            Type =
                schema.TryGetProperty("type") |> function
                | Some jv -> jv.AsString()
                | None ->
                    schema.TryGetProperty("anyOf") |> function
                    | Some jv ->
                        jv.AsArray()
                        |> Array.find (fun jv' -> jv'.GetProperty("type").AsString() <> "object")
                        |> fun jv' -> jv'.GetProperty("type").AsString()
                    | None -> "string"
                |> mapParameterType
        }

    ///Record for OpenAPI schema object
    type SchemaObject = {
        AnyOf: JsonValue array option
        Description: string
        Enum: JsonValue array option
        Format: string option
        Items: JsonValue option
        Nullable: bool option
        Properties: JsonValue
        Ref: string option
        RequiredFields: JsonValue array
        Title: string option
        Type: string option
    }

    ///Map JSON types to F# types for form values
    let mapSchemaType (s: string) =
        match s with
        | "boolean" -> "bool"
        | "integer" -> "int"
        | "number" -> "decimal"
        | _ -> s

    ///Parse a `JsonValue` into an OpenAPI schema-object record
    let getSchemaObject (jv: JsonValue) =
        {
            AnyOf = jv.TryGetProperty("anyOf") |> Option.map(fun v -> v.AsArray())
            Description = jv.TryGetProperty("description") |> Option.map(fun v -> v.AsString()) |> Option.defaultValue ""
            Enum = jv.TryGetProperty("enum") |> Option.map(fun v -> v.AsArray())
            Format = jv.TryGetProperty("format") |> Option.map(fun v -> v.AsString())
            Items = jv.TryGetProperty("items") |> Option.map id
            Nullable = jv.TryGetProperty("nullable") |> Option.map(fun v -> v.AsBoolean())
            Properties = jv.TryGetProperty("properties") |> Option.map id |> Option.defaultValue JsonValue.Null
            Ref = jv.TryGetProperty("$ref") |> Option.map(fun v -> v.AsString())
            RequiredFields = jv.TryGetProperty("required") |> Option.map(fun v -> v.AsArray()) |> Option.defaultValue [||]
            Title = jv.TryGetProperty("title") |> Option.map(fun v -> v.AsString())
            Type = jv.TryGetProperty("type") |> Option.map(fun v -> v.AsString() |> mapSchemaType)
        }

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
            $"{name}'"
        | _ ->
            name

    ///Remove/replace problematic chars/strings from discriminated-union names
    let clean (s: string) =
        s.Replace("*", "Asterix").Replace("GMT+", "GMTplus").Replace("GMT-", "GMTminus").Replace("/", "").Replace("-", "").Replace(" ", "").Replace("none", "none'")

    ///Prepend `Numeric` to discriminated-union names that start with numbers, not permissible in F#
    let escapeNumeric s =
        Regex.Replace(s, @"^(\d)", "Numeric$1")

    ///Add `JsonUnionCase` attribute to discriminated-union members, in cases where standard snake-casing of discriminated union names would prevent successful round-tripping
    let escapeForJson (s: string) =
        if Regex.IsMatch(s, @"^\p{Lu}") || Regex.IsMatch(s, @"^\d") || s.Contains("-") || s.Contains(" ") then
            $@"[<JsonUnionCase(""{s}"")>] {s |> clean |> pascalCasify |> escapeNumeric}"
        else
            s |> clean |> pascalCasify

    ///Remove unnecessary suffix from object titles to prevent wordiness in property naming
    let fixTitle (title: string) =
        Regex.Replace(title, "_param$", "")

    ///Class for formatting parameters/properties of types
    type Parameter (description: string, name: string, ``type``: string) =
        member _.Description = description
        member _.Name = name
        member _.Type = ``type``

        member this.ToParameterString() =
            $"{this.Name |> camelCasify |> escapeReservedName}: {this.Type}"

        member this.ToPropertyString() =
            $"\t\tmember _.{this.Name |> camelCasify |> escapeReservedName} = {this.Name |> camelCasify |> escapeReservedName}"

    ///Format multiline comments correctly by inserting tabs and comment specifiers at the beginning of each line, and also formatting the HTML to display all paragraphs correctly
    let commentify indent (s: string) =
        if s |> String.IsNullOrWhiteSpace then
            ""
        elif s.Contains("<p>") then
            let tabs = "\t" |> String.replicate indent
            let formatted = s.Replace("<p>", "").Replace("</p>", "").Replace("\n\n", "\n").Replace("\n", $"\n{tabs}///")
            $"{tabs}///<p>{formatted}</p>"
        else
            let tabs = "\t" |> String.replicate indent
            let formatted = s.Replace("\n\n", "\n").Replace("\n", $"\n{tabs}///")
            $"{tabs}///{formatted}"

    ///Recursive record for holding type definitions
    type Value = {
        Description: string
        Name: string
        Required: bool
        Type: string
        OptionType: OptionType
        EnumValues: string list option
        SubValues: Value array option
    }

    ///Parse form parameters
    let rec parseValue prefix name req isChoice (jv: JsonValue) =
        let name' = name |> pascalCasify
        let so = jv |> getSchemaObject
        let desc = so.Description
        match so.Type with
        | Some t when t = "string" ->
            match so.Enum with
            | Some e ->
                let ev = e |> Array.map((fun v -> v |> parseValue $"{prefix}" name false false) >> (fun v -> v.Name)) |> Array.filter((<>) "") |> Array.toList
                if ev |> List.isEmpty then
                    { Description = desc; Name = name; Required = req; Type = "string"; OptionType = Form; EnumValues = None; SubValues = None }
                else
                    { Description = desc; Name = name; Required = req; Type = $"{prefix}{name'}"; OptionType = Form; EnumValues = Some ev; SubValues = None }
            | None ->
                { Description = desc; Name = name; Required = req; Type = t; OptionType = Form; EnumValues = None; SubValues = None }
        | Some t when t = "array" ->
            match so.Items with
            | Some i ->
                match name with
                | "expand" ->
                    { Description = desc; Name = name; Required = req; Type = "string list"; OptionType = Form; EnumValues = None; SubValues = None }
                | _ ->
                    let sv = i |> parseValue $"{prefix}" name false false
                    { Description = desc; Name = name; Required = req; Type = $"{sv.Type} list"; OptionType = Form; EnumValues = None; SubValues = Some [| sv |] }
            | None ->
                failwith $"This `never` fails #1 {name}"
        | Some t when t = "object" ->
            match so.Title with
            | Some title ->
                let prefix' = if isChoice then $"{prefix}{name'}{title |> fixTitle |> pascalCasify}" else $"{prefix}{name'}"
                let sv = so.Properties.Properties |> Array.map(fun (k, v) -> v |> parseValue prefix' k false false)
                if sv |> Array.isEmpty then
                    { Description = desc; Name = name; Required = req; Type = "string"; OptionType = Form; EnumValues = None; SubValues = None }
                else
                    { Description = desc; Name = name; Required = req; Type = prefix'; OptionType = Form; EnumValues = None; SubValues = Some sv }
            | None ->
                match name with
                | "attributes"
                | "currency_options"
                | "metadata" ->
                    { Description = desc; Name = name; Required = req; Type = "Map<string, string>"; OptionType = Form; EnumValues = None; SubValues = None }
                | _ ->
                    failwith $"This `never` fails #2: {name}"
        | Some t when t = "int" ->
            match so.Format with
            | Some "unix-time" ->
                { Description = desc; Name = name; Required = req; Type = "DateTime"; OptionType = Form; EnumValues = None; SubValues = None }
            | _ ->
                { Description = desc; Name = name; Required = req; Type = t; OptionType = Form; EnumValues = None; SubValues = None }
        | Some t ->
            { Description = desc; Name = name; Required = req; Type = t; OptionType = Form; EnumValues = None; SubValues = None }
        | None ->
            match so.AnyOf with
            | Some ao ->
                match name with
                | "metadata" ->
                    { Description = desc; Name = name; Required = req; Type = "Map<string, string>"; OptionType = Form; EnumValues = None; SubValues = None }
                | _ ->
                    let sv = ao |> Array.map(fun v -> v |> parseValue $"{prefix}" name false true)
                    let choices = sv |> Array.map(fun v -> v.Type) |> Array.toList
                    { Description = desc; Name = name; Required = req; Type = $"""Choice<{choices |> String.concat ","}>"""; OptionType = Form; EnumValues = None; SubValues = Some sv }
            | None ->
                { Description = desc; Name = jv.AsString(); Required = req; Type = ""; OptionType = Undefined; EnumValues = None; SubValues = None }

    ///Parse querystring parameters
    let parseQueryParameters (parameters: JsonValue array) =
        parameters
        |> Array.map (fun jv ->
            let po = jv |> getParameterObject
            let desc = po.Description
            let name = po.Name
            let optionType = po.In
            let required = po.Required
            let type' = po.Type
            { Description = desc; Name = name; Required = required; Type = type'; OptionType = optionType; EnumValues = None; SubValues = None }
        )

    ///Format querystring for path
    let formatQueryString queryOptions =
        queryOptions
        |> Array.map (fun v ->
            $"(\"{v.Name}\", options.{v.Name |> pascalCasify} |> box)"
        )
        |> String.concat "; "
        

    ///Format request path to allow string interpolation of inline parameters
    let formatPathOptions (path: string) =
        Regex.Replace(path, @"\{([^}]+)\}", fun m -> $"{{options.{m.Groups.[1].Value |> escapeReservedName |> pascalCasify}}}")

    ///Extract a type name from a JSON reference field
    let parseRef (s: string) =
        let m = Regex.Match(s, "/([^/]+)$")
        if m.Success then
            m.Groups.[1].Value
        else
            failwith $"Unparsable reference: {s}"

    type ModelRequest = {
        Description: string
        Method: string
        OptionsString: string
        QueryDeclaration: string
        Path: string
        Verb: string
        ResponseType: string
        Query: string
        FormOptions: Value array
        PathOptions: Value array
    }

    /// Intermediate Abstract Syntax Tree that can be analysed and processed if needed.
    type ModelAst =
    | ModelHeader
    | ModelDu of Name: string * Value: string * ModelAst
    | ModelType of Name: string * PropertiesString: string * ParametersString: string * Assignments: string * ModelAst
    | ModelRequest of ModelRequest * ModelAst
    | ModelModule of Module: string * ModelAst

    ///Parses the Stripe OpenAPI specification, outputting an F# module specifying the object model for all body form parameters in Stripe API requests
    let parseRequest filePath =
        let root = __SOURCE_DIRECTORY__

        let filePath' = defaultArg filePath $"{root}/res/spec3.sdk.json"
        let json = File.ReadAllText(filePath')

        let root = JsonValue.Parse json
        let components = root.Item "components"
        let schemas = components.Item "schemas"
        let operationPaths = root.Item "paths"

        let requestPaths =
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
                    Regex.Split(path, "/")
                    |> Array.mapi(fun i p ->
                        match (i, p) with
                        | 0, _ | 1, _ -> None
                        | _, p when Regex.IsMatch(p, "^\{.+\}$") -> None
                        | _, p -> Some (p |> pascalCasify)
                    )
                    |> Array.choose id
                    |> String.concat ""
                    |> fun s -> Regex.Replace(s, "^3d", "ThreeD")

                let methodOperationPaths =
                    operations.Properties
                    |> Array.choose(fun (operation, _) ->
                        requestPaths
                        |> Array.collect snd
                        |> Array.tryFind(fun (_, o, p) -> o = operation && p = path)
                        |> Option.map(fun (m, _, _) -> (m, operation, path))
                    )
                (pathRoot, methodOperationPaths)
            )
            |> Array.groupBy fst
            |> Array.map(fun (k, v) -> k, v |> Array.collect(fun(_, v') -> v'))

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
                        let desc = operation.TryGetProperty("description") |> Option.map(fun v -> v.AsString()) |> Option.defaultValue ""
                        let form =
                            operation.GetProperty("requestBody").GetProperty("content").TryGetProperty("application/x-www-form-urlencoded") |> function
                            | Some f -> f
                            | None -> operation.GetProperty("requestBody").GetProperty("content").GetProperty("multipart/form-data")

                        let schema = form.TryGetProperty("schema") |> function | Some jv -> jv | None -> failwith "No schema present"
                        let schemaObject = schema |> getSchemaObject
                        let required = schemaObject.RequiredFields |> Array.map(fun jv -> jv.AsString())
                        let formParameters =
                            (
                                schemaObject.Properties.Properties
                                |> Array.map(fun (k, v) ->
                                    v |> parseValue $"{methodName}'" k (required.Contains(k)) false
                                )
                            )
                        let queryParameters =
                            operation.TryGetProperty("parameters") |> function | Some jv -> jv.AsArray() | None -> [||]
                            |> parseQueryParameters
                        let options = formParameters |> Array.append queryParameters
                        let responseContent = operation.GetProperty("responses").GetProperty("200").GetProperty("content")
                        let tryJsonMimeType = responseContent.TryGetProperty("application/json")
                        match tryJsonMimeType with
                        | Some jsonMimeType ->
                            let responseSchema = jsonMimeType.GetProperty("schema")
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
                                            failwith $"Unhandled response type: {moduleName} %A{responseSchema}"

                            (methodName, verb, path, desc, options, responseType)
                        | _ ->
                            let tryPdfMimeType = responseContent.TryGetProperty("application/pdf")
                            match tryPdfMimeType with
                            | Some pdfMimeType ->
                                let responseSchema = pdfMimeType.GetProperty("schema")
                                let responseType = "string"
                                (methodName, verb, path, desc, options, responseType)
                            | _ ->
                                failwith $"Unhandled mime type: {moduleName} %A{responseContent}"
                    )
                (moduleName, methods)
            )

        let header = ModelHeader

        ///Gather a discriminated union
        let gatherDU (name: string) values model =
            let valuesString =
                values
                |> List.map(fun s -> $"\t\t| {s |> escapeForJson}")
                |> String.concat "\n"
            ModelDu(name, valuesString, model)

        ///Write a type definition and static create method for a method's options
        let rec gatherOptions (name: string) values model =

            let modelWithOptions =
                values
                |> Array.filter(fun v -> v.SubValues.IsSome)
                |> Array.fold(fun model v ->
                    gatherOptions (v.Type) (v.SubValues.Value) model
                ) model

            let modelWithValues =
                values
                |> Array.filter(fun v -> v.EnumValues.IsSome)
                |> Array.fold(fun model v ->
                    gatherDU (v.Type) (v.EnumValues.Value) model
                ) modelWithOptions

            let modelWithTypes =
                if not (name.StartsWith "Choice<" || name.EndsWith " list") then

                    let parametersString =
                        values
                        |> Array.sortBy(fun v -> if v.Required then 0 else 1)
                        |> Array.map(fun v ->
                            let req = if v.Required then "" else "?"
                            $"{req}{v.Name |> camelCasify |> escapeReservedName}: {v.Type}"
                        )
                        |> String.concat ", "

                    let propertiesString =
                        values
                        |> Array.map(fun v ->
                            let req = if v.Required then "" else " option"
                            let desc = if v.Description |> String.IsNullOrWhiteSpace then "" else $"{v.Description |> commentify 3}\n"
                            $"{desc}\t\t\t[<Config.{v.OptionType |> string}>]{v.Name |> pascalCasify}: {v.Type}{req}"
                        )
                        |> String.concat "\n"

                    let assignments =
                        values
                        |> Array.map(fun v ->
                            $"\t\t\t\t\t{v.Name |> pascalCasify} = {v.Name |> camelCasify |> escapeReservedName}"
                        )
                        |> String.concat "\n"

                    ModelType(name, propertiesString, parametersString, assignments, modelWithValues)

                else modelWithValues

            modelWithTypes

        ///Write a method to make a request from the API
        let gatherMethod method verb path description options responseType model =
            let formOptions = options |> Array.filter(fun o -> o.OptionType = Form)
            let pathOptions = options |> Array.filter(fun o -> o.OptionType = Path)
            let queryOptions = options |> Array.filter(fun o -> o.OptionType = Query)

            let optionsString = if options |> Array.isEmpty |> not then $" (options: {method}Options)" else ""
            let queryString = queryOptions |> formatQueryString
            let (queryDeclaration, query) =
                if queryString = "" then
                    "", " (Map.empty)"
                else
                    $"\t\t\tlet qs = [{queryString}] |> Map.ofList", " qs"

            ModelRequest ({
                Description = description
                Method = method
                OptionsString = optionsString
                QueryDeclaration = queryDeclaration
                Path = path
                Verb = verb
                ResponseType = responseType
                Query = query
                FormOptions = formOptions
                PathOptions = pathOptions
            }, model)

        let model =
            requests
            |> Array.fold(fun model (module', methods) ->
                let modelWithModule = ModelModule(module', model)
                methods
                |> Array.fold(fun modelm (method, verb, path, desc, options, responseType) ->
                    let modelWithOpts = gatherOptions $"{method}Options" options modelm
                    gatherMethod method verb path desc options responseType modelWithOpts
                ) modelWithModule
            ) header

        model

    /// Save the model to F# file.
    let serializeModel (version:string) fullModel =

        //use a string builder to hold the output
        let sb = Text.StringBuilder()

        ///Utility function for appending lines to a StringBuilder
        let write s (sb: Text.StringBuilder) =
            if s |> String.IsNullOrWhiteSpace |> not then sb.AppendLine s |> ignore
        
        let rec writeModel model =
            match model with
            | ModelHeader ->
                sb |> write $"namespace FunStripe\n\nopen FunStripe.Json\nopen StripeModel\nopen System\n\n[<System.CodeDom.Compiler.GeneratedCode(\"FunStripe\", \"{version}\")>]\nmodule StripeRequest =\n"
            | ModelDu (name, valuesString, model) ->
                do writeModel model
                ///Write a discriminated union
                sb |> write $"\t\ttype {name} =\n{valuesString}\n"
            | ModelType (name, propertiesString, parametersString, assignments, model) ->
                do writeModel model
                sb |> write $"\t\ttype {name} = {{\n{propertiesString}\n\t\t}}"
                sb |> write $"\t\twith\n\t\t\tstatic member New({parametersString}) =\n\t\t\t\t{{\n{assignments}\n\t\t\t\t}}\n"

            | ModelRequest (modelRequest, model) ->
                do writeModel model
                sb |> write (modelRequest.Description |> commentify 2)
                sb |> write $"\t\tlet {modelRequest.Method} settings{modelRequest.OptionsString} ="
                sb |> write modelRequest.QueryDeclaration
                sb |> write $"\t\t\t$\"{modelRequest.Path |> formatPathOptions}\""

                //set API method
                match modelRequest.Verb with
                | "get" when modelRequest.FormOptions.Any() ->
                    sb |> write $"\t\t\t|> RestApi.getWithAsync<_, {modelRequest.ResponseType}> settings{modelRequest.Query} options\n"
                | "get" ->
                    sb |> write $"\t\t\t|> RestApi.getAsync<{modelRequest.ResponseType}> settings{modelRequest.Query}\n"
                | "post" when modelRequest.FormOptions.Any() |> not ->
                    sb |> write $"\t\t\t|> RestApi.postWithoutAsync<{modelRequest.ResponseType}> settings{modelRequest.Query}\n"
                | "post" ->
                    sb |> write $"\t\t\t|> RestApi.postAsync<_, {modelRequest.ResponseType}> settings{modelRequest.Query} options\n"
                | "delete" ->
                    sb |> write $"\t\t\t|> RestApi.deleteAsync<{modelRequest.ResponseType}> settings{modelRequest.Query}\n"
                | verb ->
                    failwith $"Unhandled verb: {verb}"

            | ModelModule (module', model) ->
                do writeModel model
                sb |> write $"\tmodule {module'} =\n"

        writeModel fullModel

        sb.ToString().Replace("\t", "    ")

#if INTERACTIVE
    ;;
    open RequestBuilder;;
    let m = parseRequest None;;
    let s = serializeModel "0.11.1" m;;
    System.IO.File.WriteAllText($"{__SOURCE_DIRECTORY__}/StripeRequest.fs", s);;
#endif
