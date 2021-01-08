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

///Select the entire text of this module and press ```Alt + Enter``` to generate the ```StripeRequest.fs``` file
module RequestBuilder =

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
        Required: JsonValue array
        Title: string option
        Type: string option
    }

    ///Map JSON types to F# types
    let mapType (s: string) =
        match s with
        | "boolean" -> "bool"
        | "integer" -> "int"
        | "number" -> "decimal"
        | _ -> s

    ///Parse a ```JsonValue``` into an OpenAPI schema-object record
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
            Required = jv.TryGetProperty("required") |> Option.map(fun v -> v.AsArray()) |> Option.defaultValue [||]
            Title = jv.TryGetProperty("title") |> Option.map(fun v -> v.AsString())
            Type = jv.TryGetProperty("type") |> Option.map(fun v -> v.AsString() |> mapType)
        }

    ///Convert ```snake_case``` to ```PascalCase```
    let pascalCasify (s: string) =
        Regex.Replace(s, @"(^|_|\.| |-)(\w)", fun (m: Match) -> m.Groups.[2].Value.ToUpper())

    ///Convert ```snake_case``` to ```camelCase```
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

    ///Remove/replace problematic chars/strings from discriminated-union names
    let clean (s: string) =
        s.Replace("*", "Asterix").Replace("GMT+", "GMTplus").Replace("GMT-", "GMTminus").Replace("/", "").Replace("-", "").Replace(" ", "").Replace("none", "none'")

    ///Prepend ```Numeric``` to discriminated-union names that start with numbers, not permissible in F#
    let escapeNumeric s =
        Regex.Replace(s, @"^(\d)", "Numeric$1")

    ///Add ```JsonUnionCase``` attribute to discriminated-union members, in cases where standard snake-casing of discriminated union names would prevent successful round-tripping
    let escapeForJson s =
        if Regex.IsMatch(s, @"^\p{Lu}") || Regex.IsMatch(s, @"^\d") || s.Contains("-") || s.Contains(" ") then
            $@"[<JsonUnionCase(""{s}"")>] {s |> clean |> pascalCasify |> escapeNumeric}"
        else
            s |> clean |> pascalCasify

    ///Correct Stripe operation IDs that breach naming conventions
    let fixOperationId (operationId: string) =
        operationId.Replace("-", "")

    ///Remove unnecessary suffix from object titles to prevent wordiness in property naming
    let fixTitle (title: string) =
        Regex.Replace(title, "_param$", "")

    ///Class for formatting parameters/properties of types
    type Parameter (description: string, name: string, ``type``: string) =
        member _.Description = description
        member _.Name = name
        member _.Type = ``type``

        member this.ToParameterString() =
            (this.Name |> camelCasify |> escapeReservedName) + ": " + this.Type

        member this.ToPropertyString() =
            "\t\tmember _." + (this.Name |> camelCasify |> escapeReservedName) + " = " + (this.Name |> camelCasify |> escapeReservedName)

    ///Format multiline comments correctly by inserting tabs and comment specifiers at the beginning of each line
    let commentify (s: string) = 
        s.Replace("\n\n", "\n").Replace("\n", "\n\t\t///")

    ///Recursive record for holding type definitions
    type Value = {
        Description: string
        Name: string
        Required: bool
        Type: string
        EnumValues: string list option
        SubValues: Value array option
    }

    ///Utility function for appending lines to a StringBuilder
    let write s (sb: Text.StringBuilder) =
        sb.AppendLine s |> ignore

    ///Parses the Stripe OpenAPI specification, outputting an F# module specifying the object model for all body form parameters in Stripe API requests
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
                                failwith "This `never` fails #1"
                        | Some t when t = "object" ->
                            match so.Title with
                            | Some title ->
                                let prefix' = if isChoice then $"{prefix}{name'}{title |> fixTitle |> pascalCasify}" else $"{prefix}{name'}"
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
                                    failwith "This `never` fails #2"
                        | Some t when t = "int" ->
                            match so.Format with
                            | Some "unix-time" ->
                                { Description = desc; Name = name; Required = req; Type = "DateTime"; EnumValues = None; SubValues = None }
                            | _ ->
                                { Description = desc; Name = name; Required = req; Type = t; EnumValues = None; SubValues = None }
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

        sb |> write "namespace FunStripe\n\nopen FunStripe.Json\nopen System\n\nmodule StripeRequest =\n"

        let writeEnum (name: string) values =
            let valuesString =
                ("\n",
                    values
                    |> List.map(fun s -> $"\t\t| {s |> escapeForJson}")
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
