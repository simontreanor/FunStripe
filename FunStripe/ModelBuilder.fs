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

///Select the entire text of this module and press `Alt + Enter` to generate the `StripeModel.fs` file
module ModelBuilder =

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
        | "open"
        | "type" ->
            $"``{name}``"
        | _ ->
            name

    ///Remove problematic chars from discriminated-union names
    let clean (s: string) =
        s.Replace("-", "").Replace(" ", "")

    ///Prepend `Numeric` to discriminated-union names that start with numbers, not permissible in F#
    let escapeNumeric s =
        Regex.Replace(s, @"^(\d)", "Numeric$1")

    ///Add `JsonUnionCase` attribute to discriminated-union members, in cases where standard snake-casing of discriminated union names would prevent successful round-tripping
    let escapeForJson (s: string) =
        if s.Contains(" of ") then
            s
        elif Regex.IsMatch(s, @"^\p{Lu}") || Regex.IsMatch(s, @"^\d") || s.Contains("-") || s.Contains(" ") || s.Contains(".") then
            $@"[<JsonUnionCase(""{s}"")>] {s |> clean |> pascalCasify |> escapeNumeric}"
        elif s = "none" then
            $@"[<JsonUnionCase(""{s}"")>] {s|> pascalCasify}'"
        else
            s |> clean |> pascalCasify

    ///Ensure JSON field names can round-trip successfully, as Stripe is inconsistent in the snake-casing of fields containing numbers
    let fixJsonNaming transformType infix name =
        let infix' = infix |> Option.defaultValue ""
        let nameProperty = if Regex.IsMatch(name, @"(?<!_)\d") then Some $"Name=\"{name}\"" else None
        let transformProperty = transformType |> Option.fold (fun _ v -> Some $"Transform=typeof<%s{v}>") None
        let properties = [nameProperty; transformProperty] |> List.choose id
        match properties with
        | [] ->
            $"{infix'}{name |> pascalCasify}"
        | _ ->
            let propertiesString = String.Join(", ", properties)
            $"[<JsonField({propertiesString})>]{infix'}{name |> pascalCasify}"

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

    ///Regular expression to match enumerations specified in the description
    let enumRegex = @"`([\w "".]+)`(?:(?: \([^)]+\))?,? `([\w "".]+)`)*(?: \([^)]+\))?,? (?:and|or) (?:`([\w ""\.]+)`|null)\."

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
                        { Description = desc; Name = name; Nullable = nullable; Required = req; Type = t; EnumValues = None; SubValues = None; StaticValue = None }
                else
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
                    | Some ap ->
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
            let choices' = choices |> List.map(fun c -> $"{c |> pascalCasify} of {c}")
            { Description = description; Name = name; Nullable = nullable; Required = required; Type = $"{prefix}{name |> pascalCasify}{suffix}"; EnumValues = Some choices'; SubValues = None; StaticValue = None }

    ///Utility function for appending lines to a StringBuilder
    let write s (sb: Text.StringBuilder) =
        sb.AppendLine s |> ignore

    ///Parses the Stripe OpenAPI specification, outputting an F# module specifying the object model for all Stripe objects
    let parseModel filePath =
        
        //parse Open API specification file
        let root = __SOURCE_DIRECTORY__
        let filePath' = defaultArg filePath $"{root}/res/spec3.sdk.json"
        let json = File.ReadAllText(filePath')
        
        //get schema root
        let root = JsonValue.Parse json
        let components = root.Item "components"
        let schemas = components.Item "schemas"

        //parse schemas into type definitions
        let typeDefinitions =
            schemas.Properties
            |> Array.map (fun (key, schema) ->

                //parse individual schema
                let schemaObject = schema |> getSchemaObject
                
                //get array of required fields
                let requiredFields = schemaObject.Required |> Array.map(fun jv -> jv.AsString())

                //parse schema into type definition
                let typeDefinition =

                    //if schema object has no properties then it is an `anyOf`
                    if schemaObject.Properties = JsonValue.Null then
                        //parse anyOf into discriminated union; the container will later be hidden for simplicity
                        ($"{key} hide", schemaObject.Description,
                            match schemaObject.AnyOf with
                            | Some ao ->
                                [| ao |> parseAnyOfs (key |> pascalCasify) "" requiredFields "" false false "'DU" |]
                            | None ->
                                [||]
                        )
                    else
                        //parse normal schema object with properties
                        (key, schemaObject.Description,
                            schemaObject.Properties.Properties
                            |> Array.map(fun (k, v) ->
                                v |> parseValue (key |> pascalCasify) k (requiredFields.Contains(k))
                            )
                        )

                //check if the values are missing
                match typeDefinition with
                | (name, desc, [||]) ->
                    //create a dummy value assuming a string type
                    (name, desc,
                        [| { Description = desc; Name = name; Nullable = true; Required = false; Type = "string"; EnumValues = None; SubValues = None; StaticValue = None } |]
                    )
                | td ->
                    //return the normal value
                    td
            )

        //use a string builder to hold the output
        let sb = Text.StringBuilder()

        //write the namespace, references and module title
        sb |> write "namespace FunStripe\n\nopen FunStripe.Json\nopen FunStripe.Json.Util\nopen System\n\nmodule StripeModel =\n"

        //creates and formats a discriminated union
        let writeEnum (name: string) values =

            //delete the suffix if an intermediate container has been used
            let name' = if name.EndsWith "'DU" then name.Replace("'DU", "") else name

            //get the members of the discriminated union
            let valuesString =
                ("\n",
                    values
                    |> List.map(fun s -> $"\t\t| {s |> escapeForJson}")
                ) |> String.Join

            //write the type definition and members of the discriminated union
            sb |> write $"\tand {name'} =\n{valuesString}\n"

        //recursively iterate through the values and write them to the string builder
        let rec writeValues isFirstOccurrence (name: string) (description: string) values =

            //hide intermediate lists and containers
            if not (name.EndsWith " list" || name.EndsWith " hide") then

                //only write `type` on the first type definition in the module; otherwise write `and`
                let keyword = if isFirstOccurrence then "type" else "and"

                //get the type's dynamic properties and their types
                let propertiesString =
                    ("\n",
                        values
                        |> Array.filter(fun v -> v.StaticValue.IsNone)
                        |> Array.map(fun v ->
                            let comment = if v.Description |> String.IsNullOrWhiteSpace then "" else $"\t\t///{v.Description |> commentify}\n"
                            let req = if v.Required && (v.Nullable |> not) then "" else " option"
                            let transform =
                                if v.Type = "DateTime" then
                                    Some "Transforms.DateTimeEpoch"
                                else
                                    None
                            $"{comment}\t\t{v.Name |> fixJsonNaming transform None}: {v.Type}{req}"
                        )
                    ) |> String.Join

                //get the type's static properties; this is typically an `Object: string` property with a value set to the name of the type
                let staticPropertiesString =

                    //get a string list of formatted properties
                    let props =
                        ("\n",
                            values
                            |> Array.filter(fun v -> v.StaticValue.IsSome)
                            |> Array.map(fun v ->
                                let comment = if v.Description |> String.IsNullOrWhiteSpace then "" else $"\t\t///{v.Description |> commentify}\n"
                                let name' = v.Name |> fixJsonNaming None (Some "member _.")
                                $"{comment}\t\t{name'} = \"{v.StaticValue.Value}\""
                            )
                        ) |> String.Join

                    //if there are any static properties, prefix them with `with`
                    if props |> String.IsNullOrWhiteSpace then "" else $"\n\twith\n{props}\n"

                //add a static `create` function with optional parameters to simplify record creation
                let createFunction =

                    //format parameters
                    let parameters =
                        (", ",
                            values
                            |> Array.filter(fun v -> v.StaticValue.IsNone)
                            |> Array.sortBy(fun v -> ((if v.Required then 1 else 2), v.Name))
                            |> Array.map(fun v ->
                                let o = if v.Required then "" else "?"
                                let n = if v.Nullable then " option" else ""
                                $"{o}{v.Name |> camelCasify |> escapeReservedName}: {v.Type}{n}"
                            )
                        ) |> String.Join

                    //format property initialisers
                    let properties =
                        ("\n",
                            values
                            |> Array.filter(fun v -> v.StaticValue.IsNone)
                            |> Array.sortBy(fun v -> ((if v.Required then 1 else 2), v.Name))
                            |> Array.map(fun v ->
                                let flatten = if (v.Required |> not) && v.Nullable then " |> Option.flatten" else ""
                                let comment = if v.Required then " //required" else ""
                                $"\t\t\t\t{name |> pascalCasify}.{v.Name |> pascalCasify} = {v.Name |> camelCasify |> escapeReservedName}{flatten}{comment}"
                            )
                        ) |> String.Join

                    //if there are no static properties, prefix `create` function with `with`
                    let withPrefix = if staticPropertiesString |> String.IsNullOrWhiteSpace then $"\n\twith\n" else ""

                    //compose `create` function
                    $"{withPrefix}\n\t\tstatic member New ({parameters}) =\n\t\t\t{{\n{properties}\n\t\t\t}}"

                //if there is a description, format it using comments
                let desc = if description |> String.IsNullOrWhiteSpace then "" else $"\t///{description |> commentify}\n"
                    
                //write the type definition and properties of the type
                sb |> write $"{desc}\t{keyword} {name |> pascalCasify} = {{\n{propertiesString}\n\t}}{staticPropertiesString}{createFunction}\n"

            //write out any enumerations
            values
            |> Array.filter(fun v -> v.EnumValues.IsSome)
            |> Array.iter(fun v ->
                writeEnum (v.Type) (v.EnumValues.Value)
            )

            //write out any sub-values
            values
            |> Array.filter(fun v -> v.SubValues.IsSome)
            |> Array.iter(fun v ->
                writeValues false (v.Type) (v.Description) (v.SubValues.Value)
            )

        //declare a flag for the first occurence of the `type` keyword
        let mutable isFirstOccurrence = true

        //write the values and enumerations to the string builder
        typeDefinitions
        |> Array.iter(fun (name, desc, value) ->

            //start off the recursive iteration through the values
            writeValues isFirstOccurrence name desc value

            //set the first-occurrence flag to false once it is used
            isFirstOccurrence <- false
        )

        //return a string from the string builder, replacing tabs with four spaces
        sb.ToString().Replace("\t", "    ")

#if INTERACTIVE
    ;;
    open ModelBuilder;;
    let s = parseModel None;;
    System.IO.File.WriteAllText(__SOURCE_DIRECTORY__ + "/StripeModel.fs", s);;
#endif
