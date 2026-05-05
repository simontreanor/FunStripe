namespace FunStripe

open FSharp.Data
open FSharp.Data.JsonExtensions
open System
open System.Linq
open System.Text.RegularExpressions

///Shared parsing infrastructure for the Stripe OpenAPI request schema
module RequestParsing =

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
        | "in"
        | "open"
        | "type" ->
            $"{name}'"
        | _ ->
            name

    ///Remove/replace problematic chars/strings from discriminated-union names
    let clean (s: string) =
        s.Replace("*", "Asterix").Replace("GMT+", "GMTplus").Replace("GMT-", "GMTminus").Replace("/", "").Replace("-", "").Replace(" ", "")

    ///Prepend `Numeric` to discriminated-union names that start with numbers, not permissible in F#
    let escapeNumeric s =
        Regex.Replace(s, @"^(\d)", "Numeric$1")

    ///Remove unnecessary suffix from object titles to prevent wordiness in property naming
    let fixTitle (title: string) =
        Regex.Replace(title, "_param$", "")

    ///Returns the ISO strongly-typed name for currency or country fields, or None if not applicable
    let isoTypeName (name: string) =
        if name = "currency" || (name.EndsWith("_currency") && name <> "default_for_currency") then
            Some "IsoTypes.IsoCurrencyCode"
        elif name = "country" || name.EndsWith("_country") then
            Some "IsoTypes.IsoCountryCode"
        else
            None

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
                match isoTypeName name with
                | Some isoType ->
                    { Description = desc; Name = name; Required = req; Type = isoType; OptionType = Form; EnumValues = None; SubValues = None }
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
                | "invoice_metadata"
                | "metadata"
                | "minimum_balance_by_currency"
                | "payload" ->
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
            let type' =
                if po.Type = "string" then
                    isoTypeName name |> Option.defaultValue po.Type
                else
                    po.Type
            { Description = desc; Name = name; Required = required; Type = type'; OptionType = optionType; EnumValues = None; SubValues = None }
        )

    ///Extract a type name from a JSON reference field
    let parseRef (s: string) =
        let m = Regex.Match(s, "/([^/]+)$")
        if m.Success then
            m.Groups.[1].Value
        else
            failwith $"Unparsable reference: {s}"
