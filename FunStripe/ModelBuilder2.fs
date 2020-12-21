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

///Select the entire text of this module and press ```Alt + Enter``` to generate the ```StripeModel.fs``` file
module ModelBuilder2 =

    ///Record for OpenAPI schema object
    type SchemaObject = {
        AdditionalProperties: JsonValue option
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

    ///Map JSON types to F# types
    let mapType (s: string) =
        match s with
        | "boolean" -> "bool"
        | "integer" -> "int64"
        | "number" -> "decimal"
        | _ -> s

    ///Parse a ```JsonValue``` into a OpenAPI schema-object record
    let getSchemaObject (jv: JsonValue) =
        {
            AdditionalProperties = jv.TryGetProperty("additionalProperties") |> function | Some v -> v |> Some | None -> None
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

    ///Convert ```snake_case``` to ```PascalCase```
    let pascalCasify (s: string) =
        Regex.Replace(s, @"(^|_|\.)(\w)", fun (m: Match) -> m.Groups.[2].Value.ToUpper())

    ///Remove/replace problematic chars/strings from discriminated-union names
    let clean (s: string) =
        s.Replace("-", "").Replace(" ", "").Replace("none", "none'")

    ///Prepend ```Numeric``` to discriminated-union names that start with numbers, not permissible in F#
    let escapeNumeric s =
        Regex.Replace(s, @"^(\d)", "Numeric$1")

    ///Add ```JsonUnionCase``` attribute to discriminated-union members, in cases where standard snake-casing of discriminated union names would prevent successful round-tripping
    let escapeForJson s =
        if Regex.IsMatch(s, @"^\p{Lu}") || Regex.IsMatch(s, @"^\d") || s.Contains("-") || s.Contains(" ") then
            $@"[<JsonUnionCase(""{s}"")>] {s |> clean |> pascalCasify |> escapeNumeric}"
        else
            s |> clean |> pascalCasify

    ///Ensure JSON field names can round-trip successfully, as Stripe is inconsistent in the snake-casing of fields containing numbers
    let fixJsonNaming infix name =
        let infix' = infix |> Option.defaultValue ""
        if Regex.IsMatch(name, @"(?<!_)\d") then
            $"[<JsonField(\"{name}\")>]{infix'}{name |> pascalCasify}"
        else
            $"{infix'}{name |> pascalCasify}"

    ///Format multiline comments correctly by inserting tabs and comment specifiers at the beginning of each line
    let commentify (s: string) = 
        s.Replace("\n\n", "\n").Replace("\n", "\n\t///")

    ///Extract a type name from a JSON reference field
    let parseRef (s: string) =
        let m = Regex.Match(s, "/([^/]+)$")
        if m.Success then
            m.Groups.[1].Value |> pascalCasify
        else
            s

    ///Parses an enumeration from values specified in the description (where the enumeration is not specified explicitly in fields)
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

    ///Utility function for appending lines to a StringBuilder
    let write s (sb: Text.StringBuilder) =
        sb.AppendLine s |> ignore

    ///Parses the Stripe OpenAPI specification, outputting an F# module specifying the object model for all Stripe objects
    let parseModel filePath =

        let root = __SOURCE_DIRECTORY__

        let filePath' = defaultArg filePath $"{root}/res/spec3.sdk.json"
        let json = File.ReadAllText(filePath')

        let root = JsonValue.Parse json
        let components = root.Item "components"
        let schemas = components.Item "schemas"

        let typeDefinitions =
            schemas.Properties
            |> Array.map (fun (key, schema) ->
        
                let rec parseValue prefix name req isChoice (jv: JsonValue) =
                    let name' = name |> pascalCasify
                    let so = jv |> getSchemaObject
                    let desc = so.Description
                    let nullable = so.Nullable |> function | Some true -> true | _ -> false
                    let requiredFields = so.Required |> Array.map(fun r -> r.AsString())

                    match so.Type with
                    | Some t when t = "string" ->
                        match so.Enum with
                        | Some e ->
                            let ev = e |> Array.map((fun v -> v |> parseValue prefix name (requiredFields.Contains name) false) >> (fun v -> v.Name)) |> Array.filter((<>) "") |> Array.toList
                            if ev |> List.isEmpty then
                                { Description = desc; Name = name; Nullable = nullable; Required = req; Type = "string"; EnumValues = None; SubValues = None; StaticValue = None }
                            else
                                match ev |> List.tryExactlyOne with
                                | Some e ->
                                    { Description = desc; Name = name; Nullable = nullable; Required = req; Type = "string"; EnumValues = None; SubValues = None; StaticValue = e |> Some }
                                | None ->
                                    { Description = desc; Name = name; Nullable = nullable; Required = req; Type = $"{prefix}{name'}"; EnumValues = Some ev; SubValues = None; StaticValue = None }
                        | None ->
                            if (desc |> String.IsNullOrWhiteSpace |> not) && (desc.Contains("Can be `")) then
                                match desc |> parseStringEnum with
                                | Some ee ->
                                    { Description = desc; Name = name; Nullable = nullable; Required = req; Type = $"{prefix}{name'}"; EnumValues = ee |> List.ofSeq |> Some; SubValues = None; StaticValue = None }
                                | None ->
                                    { Description = desc; Name = name; Nullable = nullable; Required = req; Type = t; EnumValues = None; SubValues = None; StaticValue = None }
                            else
                                { Description = desc; Name = name; Nullable = nullable; Required = req; Type = t; EnumValues = None; SubValues = None; StaticValue = None }
                    | Some t when t = "array" ->
                        match so.Items with
                        | Some i ->
                            match name with
                            | "expand" ->
                                { Description = desc; Name = name; Nullable = nullable; Required = req; Type = "string list"; EnumValues = None; SubValues = None; StaticValue = None }
                            | _ ->
                                let sv = i |> parseValue $"{prefix}" name false false
                                { Description = desc; Name = name; Nullable = nullable; Required = req; Type = $"{sv.Type} list"; EnumValues = None; SubValues = Some [| sv |]; StaticValue = None }
                        | None ->
                            failwith "This never fails (to amuse me) #1"
                    | Some t when t = "object" ->
                        match so.Title with
                        | Some title ->
                            let typeName = if isChoice then $"{prefix}{name'}{title |> pascalCasify}" else $"{prefix}{name'}"
                            let sv = so.Properties.Properties |> Array.map(fun (k, v) -> v |> parseValue typeName k (requiredFields.Contains k) false)
                            if sv |> Array.isEmpty then
                                { Description = desc; Name = name; Nullable = nullable; Required = req; Type = "string"; EnumValues = None; SubValues = None; StaticValue = None }
                            else
                                { Description = desc; Name = name; Nullable = nullable; Required = req; Type = typeName; EnumValues = None; SubValues = Some sv; StaticValue = None }
                        | None ->
                            match name with
                            | "attributes"
                            | "metadata" ->
                                { Description = desc; Name = name; Nullable = nullable; Required = req; Type = "Map<string, string>"; EnumValues = None; SubValues = None; StaticValue = None }
                            | _ ->
                                match so.AdditionalProperties with
                                | Some ap ->
                                    { Description = desc; Name = name; Nullable = nullable; Required = req; Type = "Map<string, string list>"; EnumValues = None; SubValues = None; StaticValue = None }
                                | None ->
                                    { Description = desc; Name = name; Nullable = nullable; Required = req; Type = "obj"; EnumValues = None; SubValues = None; StaticValue = None }
                    | Some t ->
                        { Description = desc; Name = name; Nullable = nullable; Required = req; Type = t; EnumValues = None; SubValues = None; StaticValue = None }
                    | None ->
                        match so.AnyOf with
                        | Some ao ->
                            match name with
                            | "metadata" ->
                                { Description = desc; Name = name; Nullable = nullable; Required = req; Type = "Map<string, string>"; EnumValues = None; SubValues = None; StaticValue = None }
                            | _ ->
                                let sv = ao |> Array.map(fun v -> v |> parseValue prefix name (requiredFields.Contains name) true)
                                let choices = sv |> Array.map(fun v -> v.Type |> parseRef) |> Array.toList
                                match choices |> List.tryExactlyOne with
                                | Some c ->
                                    // { Description = desc; Name = name; Required = req; Type = c; EnumValues = None; SubValues = Some sv; StaticValue = None }
                                    { Description = desc; Name = name; Nullable = nullable; Required = req; Type = c; EnumValues = None; SubValues = None; StaticValue = None }
                                | None ->
                                    { Description = desc; Name = name; Nullable = nullable; Required = req; Type = "Choice<" + String.Join(",", choices) + ">"; EnumValues = None; SubValues = Some sv; StaticValue = None }
                        | None ->
                            match so.Ref with
                            | Some r ->
                                { Description = desc; Name = name; Nullable = nullable; Required = req; Type = r |> parseRef; EnumValues = None; SubValues = None; StaticValue = None }
                            | None ->
                                { Description = desc; Name = jv.AsString(); Nullable = nullable; Required = req; Type = "CATCH-ALL"; EnumValues = None; SubValues = None; StaticValue = None }

                let schemaObject = schema |> getSchemaObject
                let required = schemaObject.Required |> Array.map(fun jv -> jv.AsString())  

                (key, schemaObject.Description,
                    schemaObject.Properties.Properties
                    |> Array.map(fun (k, v) ->
                        v |> parseValue (key |> pascalCasify) k (required.Contains(k)) false
                    )
                )

            )
            |> Array.filter(fun (_, _, v) -> v <> [||])

        let sb = Text.StringBuilder()

        sb |> write "namespace FunStripe\n\nopen FSharp.Json\n\nmodule StripeModel =\n"

        let writeEnum (name: string) values =
            let valuesString =
                ("\n",
                    values
                    |> List.map(fun s -> $"\t\t| {s |> escapeForJson}")
                ) |> String.Join
            sb |> write $"\tand {name} =\n{valuesString}\n"

        let rec writeValues isFirstOccurrence (name: string) (description: string) values =

            if not (name.StartsWith "Choice<" || name.EndsWith " list") then
                let keyword = if isFirstOccurrence then "type" else "and"

                let propertiesString =
                    ("\n",
                        values
                        |> Array.filter(fun v -> v.StaticValue.IsNone)
                        |> Array.map(fun v ->
                            let comment = if v.Description |> String.IsNullOrWhiteSpace then "" else $"\t\t///{v.Description |> commentify}\n"
                            let req = if v.Required && (v.Nullable |> not) then "" else " option"
                            $"{comment}\t\t{v.Name |> fixJsonNaming None}: {v.Type}{req}"
                        )
                    ) |> String.Join

                let staticPropertiesString =
                    let props =
                        ("\n",
                            values
                            |> Array.filter(fun v -> v.StaticValue.IsSome)
                            |> Array.map(fun v ->
                                let comment = if v.Description |> String.IsNullOrWhiteSpace then "" else $"\t\t///{v.Description |> commentify}\n"
                                let name' = v.Name |> fixJsonNaming (Some "member _.")
                                $"{comment}\t\t{name'} = \"{v.StaticValue.Value}\""
                            )
                        ) |> String.Join
                    if props |> String.IsNullOrWhiteSpace then "" else $"\n\twith\n{props}"

                let desc = if description |> String.IsNullOrWhiteSpace then "" else $"\t///{description |> commentify}\n"
                    
                sb |> write $"{desc}\t{keyword} {name |> pascalCasify} = {{\n{propertiesString}\n\t}}{staticPropertiesString}\n"
        
            values
            |> Array.filter(fun v -> v.EnumValues.IsSome)
            |> Array.iter(fun v ->
                writeEnum (v.Type) (v.EnumValues.Value)
            )

            values
            |> Array.filter(fun v -> v.SubValues.IsSome)
            |> Array.iter(fun v ->
                writeValues false (v.Type) (v.Description) (v.SubValues.Value)
            )

        let mutable isFirstOccurrence = true

        for (name, desc, value) in typeDefinitions do
            writeValues isFirstOccurrence name desc value
            isFirstOccurrence <- false

        sb.ToString().Replace("\t", "    ")

#if INTERACTIVE
    ;;
    open ModelBuilder2;;
    let s = parseModel None;;
    System.IO.File.WriteAllText(__SOURCE_DIRECTORY__ + "/StripeModel2.fs", s);;
#endif
