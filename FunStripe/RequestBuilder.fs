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

module RequestBuilder =

    type SchemaObject = {
        AnyOf: JsonValue array option
        Description: string
        Enum: JsonValue array option
        Items: JsonValue option
        Nullable: bool option
        Properties: JsonValue
        Ref: string option
        Required: JsonValue array
        Title: string option
        Type: string option
    }

    let mapType (s: string) =
        match s with
        | "boolean" -> "bool"
        | "integer" -> "int64"
        | "number" -> "decimal"
        | _ -> s

    let getSchemaObject (jv: JsonValue) =
        {
            AnyOf = jv.TryGetProperty("anyOf") |> function | Some v -> v.AsArray() |> Some | None -> None
            Description = jv.TryGetProperty("description") |> function | Some v -> v.AsString() | None -> ""
            Enum = jv.TryGetProperty("enum") |> function | Some v -> v.AsArray() |> Some | None -> None
            Items = jv.TryGetProperty("items") |> function | Some v -> v |> Some | None -> None
            Nullable = jv.TryGetProperty("nullable") |> function | Some v -> v.AsBoolean() |> Some | None -> None
            Properties = jv.TryGetProperty("properties") |> function | Some v -> v | None -> JsonValue.Null
            Ref = jv.TryGetProperty("$ref") |> function | Some v -> v.AsString() |> Some | None -> None
            Required = jv.TryGetProperty("required") |> function | Some v -> v.AsArray() | None -> [||]
            Title = jv.TryGetProperty("title") |> function | Some v -> v.AsString() |> Some | None -> None
            Type = jv.TryGetProperty("type") |> function | Some v -> v.AsString() |> mapType |> Some | None -> None
        }

    let pascalCasify (s: string) =
        Regex.Replace(s, @"(^|_|\.| |-)(\w)", fun (m: Match) -> m.Groups.[2].Value.ToUpper())

    let camelCasify (s: string) =
        Regex.Replace(s, @"( |_|-)(\w)", fun (m: Match) -> m.Groups.[2].Value.ToUpper())

    let escapeReservedName name =
        match name with
        | "end"
        | "open"
        | "type" ->
            "``" + name + "``"
        | _ ->
            name

    let clean (s: string) =
        s.Replace("*", "Asterix").Replace("GMT+", "GMTplus").Replace("GMT-", "GMTminus").Replace("/", "").Replace("-", "").Replace(" ", "")

    let escapeForJson prefix s =
        if Regex.IsMatch(s, @"^\p{Lu}") then
            $@"[<JsonUnionCase(""{s}"")>] {prefix}{s |> clean |> pascalCasify}"
        else
            if Regex.IsMatch(s, @"^\d") then
                $@"[<JsonUnionCase(""{s}"")>] {prefix}{s |> clean |> pascalCasify}"
            elif s.Contains("*") || s.Contains("-") || s.Contains(" ") then
                $@"[<JsonUnionCase(""{s}"")>] {prefix}{s |> clean |> pascalCasify}"
            else
                $"{prefix}{s |> clean |> pascalCasify}"

    let fixOperationId (operationId: string) =
        operationId.Replace("-", "")

    type Parameter (description: string, name: string, ``type``: string) =

        member _.Description = description
        member _.Name = name
        member _.Type = ``type``

        member this.ToParameterString() =
            (this.Name |> camelCasify |> escapeReservedName) + ": " + this.Type

        member this.ToPropertyString() =
            "\t\tmember _." + (this.Name |> camelCasify |> escapeReservedName) + " = " + (this.Name |> camelCasify |> escapeReservedName)

    type TypeDefinition (name: string, parameters: Parameter list) =

        member _.Name = name
        member _.Parameters = parameters

    let getTypeDefinition (name: string) (parameters: Parameter array) =
        if parameters |> Array.isEmpty then
            ""
        else
            let parametersString = String.Join (", ", parameters |> Array.map(fun p -> p.ToParameterString()))
            let propertiesString = String.Join ("\n", parameters |> Array.map(fun p -> p.ToPropertyString()))
            "\tand " + name + " (" + parametersString + ") =\n" + propertiesString + "\n"

    let commentify (s: string) = 
        s.Replace("\n\n", "\n").Replace("\n", "\n\t\t///")

    type Value = {
        Description: string
        Name: string
        Required: bool
        Type: string
        EnumValues: string list option
        SubValues: Value array option
    }

    let write s (sb: Text.StringBuilder) =
        sb.AppendLine s |> ignore

    let parseRequest filePath =
        let root = __SOURCE_DIRECTORY__

        let filePath' = defaultArg filePath $"{root}/res/spec3.sdk.json"
        let json = File.ReadAllText(filePath')

        let root = JsonValue.Parse json
        let paths = root.Item "paths"

        let methods =
            paths.Properties
            |> Array.collect (fun (_, pathDetail) ->
                pathDetail.Properties
                |> Array.map (fun (_, methodDetail) ->
        
                    let operationId = methodDetail.GetProperty("operationId").AsString() |> fixOperationId
                    let form =
                        methodDetail.GetProperty("requestBody").GetProperty("content").TryGetProperty("application/x-www-form-urlencoded") |> function
                        | Some f -> f
                        | None -> methodDetail.GetProperty("requestBody").GetProperty("content").GetProperty("multipart/form-data")
        
                    let schema = form.TryGetProperty("schema") |> function | Some jv -> jv | None -> failwith "No schema present"

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
                                    { Description = desc; Name = name; Required = req; Type = "string"; EnumValues = None; SubValues = None }
                                else
                                    { Description = desc; Name = name; Required = req; Type = $"{prefix}{name'}"; EnumValues = Some ev; SubValues = None }
                            | None ->
                                { Description = desc; Name = name; Required = req; Type = t; EnumValues = None; SubValues = None }
                        | Some t when t = "array" ->
                            match so.Items with
                            | Some i ->
                                match name with
                                | "expand" ->
                                    { Description = desc; Name = name; Required = req; Type = "string list"; EnumValues = None; SubValues = None }
                                | _ ->
                                    let sv = i |> parseValue $"{prefix}" name false false
                                    { Description = desc; Name = name; Required = req; Type = $"{sv.Type} list"; EnumValues = None; SubValues = Some [| sv |] }
                            | None ->
                                failwith "This never fails (to amuse me) #1"
                        | Some t when t = "object" ->
                            match so.Title with
                            | Some title ->
                                let prefix' = if isChoice then $"{prefix}{name'}{title |> pascalCasify}" else $"{prefix}{name'}"
                                let sv = so.Properties.Properties |> Array.map(fun (k, v) -> v |> parseValue prefix' k false false)
                                if sv |> Array.isEmpty then
                                    { Description = desc; Name = name; Required = req; Type = "string"; EnumValues = None; SubValues = None }
                                else
                                    { Description = desc; Name = name; Required = req; Type = prefix'; EnumValues = None; SubValues = Some sv }
                            | None ->
                                match name with
                                | "attributes"
                                | "metadata" ->
                                    { Description = desc; Name = name; Required = req; Type = "Map<string, string>"; EnumValues = None; SubValues = None }
                                | _ ->
                                    failwith "This never fails (to amuse me) #2"
                        | Some t ->
                            { Description = desc; Name = name; Required = req; Type = t; EnumValues = None; SubValues = None }
                        | None ->
                            match so.AnyOf with
                            | Some ao ->
                                match name with
                                | "metadata" ->
                                    { Description = desc; Name = name; Required = req; Type = "Map<string, string>"; EnumValues = None; SubValues = None }
                                | _ ->
                                    let sv = ao |> Array.map(fun v -> v |> parseValue $"{prefix}" name false true)
                                    let choices = sv |> Array.map(fun v -> v.Type) |> Array.toList
                                    { Description = desc; Name = name; Required = req; Type = "Choice<" + String.Join(",", choices) + ">"; EnumValues = None; SubValues = Some sv }
                            | None ->
                                { Description = desc; Name = jv.AsString(); Required = req; Type = "CATCH-ALL"; EnumValues = None; SubValues = None }

                    let schemaObject = schema |> getSchemaObject
                    let required = schemaObject.Required |> Array.map(fun jv -> jv.AsString())  
                    (operationId + "Params",
                        schemaObject.Properties.Properties
                        |> Array.map(fun (k, v) ->
                            v |> parseValue operationId k (required.Contains(k)) false
                        )
                    )
                )
            )
            |> Array.filter(fun (_, v) -> v <> [||])

        let sb = Text.StringBuilder()

        sb |> write "namespace FunStripe\n\nopen FSharp.Json\n\nmodule StripeRequest =\n"

        let writeEnum (name: string) values =
            let prefix = name.Replace("'", "") + "'"
            let valuesString =
                ("\n",
                    values
                    |> List.map(fun s -> $"\t\t| {s |> escapeForJson prefix}")
                ) |> String.Join
            sb |> write $"\tand {name} =\n{valuesString}\n"

        let rec writeValues isFirstOccurrence (name: string) values =

            if not (name.StartsWith "Choice<" || name.EndsWith " list") then
                let keyword = if isFirstOccurrence then "type" else "and"
                        
                let parametersString =
                    (", ",
                        values
                        |> Array.sortBy(fun v -> if v.Required then 0 else 1)
                        |> Array.map(fun v ->
                            let req = if v.Required then "" else "?"
                            $"{req}{v.Name |> camelCasify |> escapeReservedName}: {v.Type}"
                        )
                    ) |> String.Join

                let propertiesString =
                    ("\n",
                        values
                        |> Array.map(fun v ->
                            let comment = v.Description |> commentify
                            $"\t\t///{comment}\n\t\tmember _.{v.Name |> pascalCasify} = {v.Name |> camelCasify |> escapeReservedName}"
                        )
                    ) |> String.Join
                    
                sb |> write $"\t{keyword} {name} ({parametersString}) =\n{propertiesString}\n"
        
            values
            |> Array.filter(fun v -> v.EnumValues.IsSome)
            |> Array.iter(fun v ->
                writeEnum (v.Type) (v.EnumValues.Value)
            )

            values
            |> Array.filter(fun v -> v.SubValues.IsSome)
            |> Array.iter(fun v ->
                writeValues false (v.Type) (v.SubValues.Value)
            )

        let mutable isFirstOccurrence = true

        for (name, value) in methods do
            writeValues isFirstOccurrence name value
            isFirstOccurrence <- false

        sb.ToString().Replace("\t", "    ")

#if INTERACTIVE
    ;;
    open RequestBuilder;;
    let s = parseRequest None;;
    System.IO.File.WriteAllText(__SOURCE_DIRECTORY__ + "/StripeRequest.fs", s);;
#endif
