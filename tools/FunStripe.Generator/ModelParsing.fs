namespace FunStripe

open FSharp.Data
open FSharp.Data.JsonExtensions
open System
open System.Linq
open System.Text.RegularExpressions

///Shared parsing infrastructure for the Stripe OpenAPI model schema
module ModelParsing =

    ///Record for OpenAPI schema object
    type SchemaObject = {
        AdditionalProperties: JsonValue option
        AnyOf: JsonValue array option
        Description: string
        Enum: JsonValue array option
        Format: string option
        Items: JsonValue
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

    ///Parse a `JsonValue` into a OpenAPI schema-object record
    let getSchemaObject (jv: JsonValue) =
        {
            AdditionalProperties = jv.TryGetProperty("additionalProperties") |> function | Some v -> v |> Some | None -> None
            AnyOf = jv.TryGetProperty("anyOf") |> function | Some v -> v.AsArray() |> Some | None -> None
            Description = jv.TryGetProperty("description") |> function | Some v -> v.AsString() | None -> ""
            Enum = jv.TryGetProperty("enum") |> function | Some v -> v.AsArray() |> Some | None -> None
            Format = jv.TryGetProperty("format") |> function | Some v -> v.AsString() |> Some | None -> None
            Items = jv.TryGetProperty("items") |> function | Some v -> v | None -> JsonValue.Null
            Nullable = jv.TryGetProperty("nullable") |> function | Some v -> v.AsBoolean() |> Some | None -> None
            Properties = jv.TryGetProperty("properties") |> function | Some v -> v | None -> JsonValue.Null
            Ref = jv.TryGetProperty("$ref") |> function | Some v -> v.AsString() |> Some | None -> None
            Required = jv.TryGetProperty("required") |> function | Some v -> v.AsArray() | None -> [||]
            Title = jv.TryGetProperty("title") |> function | Some v -> v.AsString() |> Some | None -> None
            Type = jv.TryGetProperty("type") |> function | Some v -> v.AsString() |> mapType |> Some | None -> None
        }

    ///Convert `snake_case` to `PascalCase`
    let pascalCasify (s: string) =
        Regex.Replace(s, @"(^|_|\.)(\w)", fun (m: Match) -> m.Groups.[2].Value.ToUpper())

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
            $"``{name}``"
        | _ ->
            name

    ///Remove/replace problematic chars/strings from discriminated-union names
    let clean (s: string) =
        s.Replace("*", "Asterix").Replace("GMT+", "GMTplus").Replace("GMT-", "GMTminus").Replace("/", "").Replace("[", "").Replace("]", "").Replace(" ", "").Replace("-", "")

    ///Prepend `Numeric` to discriminated-union names that start with numbers, not permissible in F#
    let escapeNumeric s =
        Regex.Replace(s, @"^(\d)", "Numeric$1")

    ///Extract a type name from a JSON reference field
    let parseRef (s: string) =
        let m = Regex.Match(s, "/([^/]+)$")
        if m.Success then
            m.Groups.[1].Value |> pascalCasify
        else
            s

    ///Regular expression to match enumerations specified in the description
    let enumRegex = @"`([\w "".]+)`(?:(?: \([^)]+\))?,? `([\w "".]+)`)*(?: \([^)]+\))?,? (?:and|or) (?:`([\w ""\.]+)`|null)\."

    ///Types that are non-Stripe types
    let basicTypes = ["bool"; "decimal"; "DateTime"; "int"; "string"] |> Set.ofList

    ///Parses an enumeration from values specified in the description (where the enumeration is not specified explicitly in fields)
    let parseStringEnum desc =
        let m = Regex.Match(desc, enumRegex)
        if m.Success then
            m.Groups.Cast<Group>()
            |> Seq.skip 1
            |> Seq.collect(fun g -> g.Captures.Cast<Capture>())
            |> Seq.map(fun c -> c.Value.Trim('"'))
            |> Some
        else
            None

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
        Nullable: bool
        Required: bool
        Type: string
        EnumValues: string list option
        SubValues: Value array option
        StaticValue: string option
    }

    ///Recursively iterates through schema to create hierarchy of type definitions
    let rec parseValue prefix name req (jv: JsonValue) =
        let name' = name |> pascalCasify
        let so = jv |> getSchemaObject
        let desc = so.Description
        let nullable = so.Nullable |> function | Some true -> true | _ -> false
        let requiredFields = so.Required |> Array.map(fun r -> r.AsString())

        match so.Type with
        | Some t when t = "string" ->
            match so.Enum with
            | Some e ->
                let ev = e |> Array.map((fun v -> v |> parseValue prefix name (requiredFields.Contains name)) >> (fun v -> v.Name)) |> Array.filter((<>) "") |> Array.toList
                if ev |> List.isEmpty then
                    { Description = desc; Name = name; Nullable = nullable; Required = req; Type = "string"; EnumValues = None; SubValues = None; StaticValue = None }
                else
                    match ev |> List.tryExactlyOne with
                    | Some e ->
                        { Description = desc; Name = name; Nullable = nullable; Required = req; Type = "string"; EnumValues = None; SubValues = None; StaticValue = e |> Some }
                    | None ->
                        { Description = desc; Name = name; Nullable = nullable; Required = req; Type = $"{prefix}{name'}"; EnumValues = Some ev; SubValues = None; StaticValue = None }
            | None ->
                if (desc |> String.IsNullOrWhiteSpace |> not) && (Regex.IsMatch(desc, enumRegex)) then
                    match desc |> parseStringEnum with
                    | Some ee ->
                        { Description = desc; Name = name; Nullable = nullable; Required = req; Type = $"{prefix}{name'}"; EnumValues = ee |> List.ofSeq |> Some; SubValues = None; StaticValue = None }
                    | None ->
                        match isoTypeName name with
                        | Some isoType ->
                            { Description = desc; Name = name; Nullable = nullable; Required = req; Type = isoType; EnumValues = None; SubValues = None; StaticValue = None }
                        | None ->
                            { Description = desc; Name = name; Nullable = nullable; Required = req; Type = t; EnumValues = None; SubValues = None; StaticValue = None }
                else
                    match isoTypeName name with
                    | Some isoType ->
                        { Description = desc; Name = name; Nullable = nullable; Required = req; Type = isoType; EnumValues = None; SubValues = None; StaticValue = None }
                    | None ->
                        { Description = desc; Name = name; Nullable = nullable; Required = req; Type = t; EnumValues = None; SubValues = None; StaticValue = None }
        | Some t when t = "array" ->
            match name with
            | "expand" ->
                { Description = desc; Name = name; Nullable = nullable; Required = req; Type = "string list"; EnumValues = None; SubValues = None; StaticValue = None }
            | _ ->
                let sv = so.Items |> parseValue prefix name (requiredFields.Contains name)
                { Description = desc; Name = name; Nullable = nullable; Required = req; Type = $"{sv.Type} list"; EnumValues = None; SubValues = Some [| sv |]; StaticValue = None }
        | Some t when t = "object" ->
            match so.Title with
            | Some _ ->
                let sv = so.Properties.Properties |> Array.map(fun (k, v) -> v |> parseValue $"{prefix}{name'}" k (requiredFields.Contains k))
                { Description = desc; Name = name; Nullable = nullable; Required = req; Type = $"{prefix}{name'}"; EnumValues = None; SubValues = Some sv; StaticValue = None }
            | None ->
                match name with
                | "attributes"
                | "metadata" ->
                    { Description = desc; Name = name; Nullable = nullable; Required = req; Type = "Map<string, string>"; EnumValues = None; SubValues = None; StaticValue = None }
                | _ ->
                    match so.AdditionalProperties with
                    | Some _ ->
                        { Description = desc; Name = name; Nullable = nullable; Required = req; Type = "Map<string, string list>"; EnumValues = None; SubValues = None; StaticValue = None }
                    | None ->
                        { Description = desc; Name = name; Nullable = nullable; Required = req; Type = "string"; EnumValues = None; SubValues = None; StaticValue = None }
        | Some t when t = "int" ->
            match so.Format with
            | Some "unix-time" ->
                { Description = desc; Name = name; Nullable = nullable; Required = req; Type = "DateTime"; EnumValues = None; SubValues = None; StaticValue = None }
            | _ ->
                { Description = desc; Name = name; Nullable = nullable; Required = req; Type = t; EnumValues = None; SubValues = None; StaticValue = None }
        | Some t ->
            { Description = desc; Name = name; Nullable = nullable; Required = req; Type = t; EnumValues = None; SubValues = None; StaticValue = None }
        | None ->
            match so.AnyOf with
            | Some ao ->
                match name with
                | "metadata" ->
                    { Description = desc; Name = name; Nullable = nullable; Required = req; Type = "Map<string, string>"; EnumValues = None; SubValues = None; StaticValue = None }
                | _ ->
                    ao |> parseAnyOfs prefix name requiredFields desc nullable req "'AnyOf"
            | None ->
                match so.Ref with
                | Some r ->
                    { Description = desc; Name = name; Nullable = nullable; Required = req; Type = r |> parseRef; EnumValues = None; SubValues = None; StaticValue = None }
                | None ->
                    { Description = desc; Name = jv.AsString(); Nullable = nullable; Required = req; Type = ""; EnumValues = None; SubValues = None; StaticValue = None }

    and parseAnyOfs prefix name requiredFields description nullable required suffix anyOfs =
        let sv = anyOfs |> Array.map(fun v -> v |> parseValue prefix name (requiredFields.Contains name))
        let choices = sv |> Array.map(fun v -> v.Type |> parseRef) |> Array.toList
        match choices |> List.tryExactlyOne with
        | Some c ->
            { Description = description; Name = name; Nullable = nullable; Required = required; Type = c; EnumValues = None; SubValues = None; StaticValue = None }
        | None ->
            // Stripe "expandable" pattern: anyOf [string, $ref-to-resource, ...]
            // The wire format defaults to a string ID (the resource's id) and only returns a nested
            // object when the caller passes ?expand[]=. Modelling these as a wrapper DU forces
            // every Stripe.{Domain} module to depend on every other domain that has expandable
            // references, producing one giant cyclic SCC. Emitting the field as `string` matches
            // the default wire format, eliminates cross-domain cycles, and lets callers fetch
            // the expanded resource via a separate, typed retrieve call.
            let isExpandable =
                choices |> List.contains "string"
                && choices |> List.exists (fun c -> not (basicTypes.Contains c) && c <> "string")
            if isExpandable then
                { Description = description; Name = name; Nullable = nullable; Required = required; Type = "string"; EnumValues = None; SubValues = None; StaticValue = None }
            else
                let choices' = choices |> List.map(fun c -> $"{c |> pascalCasify} of {c}")
                { Description = description; Name = name; Nullable = nullable; Required = required; Type = $"{prefix}{name |> pascalCasify}{suffix}"; EnumValues = Some choices'; SubValues = None; StaticValue = None }
