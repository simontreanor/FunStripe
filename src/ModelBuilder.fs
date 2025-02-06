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
    let fixJsonNaming transformType infix (name: string) =
        let infix' = infix |> Option.defaultValue ""
        let nameProperty = if Regex.IsMatch(name, @"(?<!_)\d") then Some $"Name=\"{name}\"" else None
        let transformProperty = transformType |> Option.fold (fun _ v -> Some $"Transform=typeof<%s{v}>") None
        let properties = [nameProperty; transformProperty] |> List.choose id
        match properties with
        | [] ->
            $"{infix'}{name |> pascalCasify}"
        | _ ->
            let propertiesString = properties |> String.concat ", "
            $"[<JsonField({propertiesString})>]{infix'}{name |> pascalCasify}"

    ///Format multiline comments correctly by inserting tabs and comment specifiers at the beginning of each line
    let commentify (tabCount: int) (s: string) = 
        let tabs = "\t" |> String.replicate tabCount
        s.Replace("\n\n", "\n").Replace("\n", $"\n{tabs}///")

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

    type ModelValueItem = {
        Description: string
        Keyword: string
        PascalName: string
        StaticPropertiesString: string
    }
    
    /// Intermediate Abstract Syntax Tree that can be analysed and processed if needed.
    type ModelAst =
    | ModelHeader
    | ModelEnum of Keyword: string * Name: string * Value: string * ModelAst
    | ModelSimpleEnum of Keyword: string * Name: string * Value: string * ModelAst
    | ModelValue of ModelValueItem * ModelAst
    | ModelValueWithProperties of ModelValueItem * Properties: string * CreateFunction: string * ModelAst

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

        // Header is the start of the file. Header is also the terminator node for the AST.
        let header = ModelHeader

        //creates and formats a discriminated union
        let gatherEnum (name: string) values model =

            //delete the suffix if an intermediate container has been used
            let name' = if name.EndsWith "'DU" then name.Replace("'DU", "") else name

            //get the members of the discriminated union
            let valuesString =
                values
                |> List.map(fun s -> $"\t\t| {s |> escapeForJson}")
                |> String.concat "\n"

            let noMembers =
                not (values |> Seq.exists(fun v -> v.Contains " of "))

            //gather the type definition and members of the discriminated union
            if noMembers then
                let keyword = if values.Length < 6 then "[<Struct>]\n\ttype" else "type"
                ModelSimpleEnum(keyword, name',valuesString, model)
            else
                ModelEnum("and", name',valuesString, model)

        let gatherIntermediateListAndContainers (name: string) (description: string) values (model:ModelAst) : ModelAst = 

            let isFirstOccurrence = 
                match model with
                | ModelHeader -> true
                | _ -> false

            //only write `type` on the first type definition in the module; otherwise write `and`
            let keyword = if isFirstOccurrence then "type" else "and"

            //get the type's dynamic properties and their types
            let properties =
                values
                |> Array.filter(fun v -> v.StaticValue.IsNone)
                |> Array.map(fun v ->
                    let comment = if v.Description |> String.IsNullOrWhiteSpace then "" else $"\t\t///{v.Description |> commentify 2}\n"
                    let req = if v.Required && (v.Nullable |> not) then "" else " option"
                    let transform =
                        if v.Type = "DateTime" then
                            Some "Transforms.DateTimeEpoch"
                        else
                            None
                    $"{comment}\t\t{v.Name |> fixJsonNaming transform None}: {v.Type}{req}"
                )

            let propertiesString =
                properties
                |> String.concat "\n"

            //get the type's static properties; this is typically an `Object: string` property with a value set to the name of the type
            let staticProperties =
                values
                |> Array.filter(fun v -> v.StaticValue.IsSome)
                |> Array.map(fun v ->
                    let comment = if v.Description |> String.IsNullOrWhiteSpace then "" else $"\t\t///{v.Description |> commentify 2}\n"
                    let name' = v.Name |> fixJsonNaming None (Some "member _.")
                    $"{comment}\t\t{name'} = \"{v.StaticValue.Value}\""
                )

            let staticPropertiesString =
                staticProperties
                |> String.concat "\n"
                |> fun s ->
                    //if there are any static properties, prefix them with `with`
                    match staticProperties, properties with
                    | [||], _ -> ""
                    | _, [||] -> $"\n{s}\n"
                    | _, _ -> $"\n\twith\n{s}\n"

            //add a static `create` function with optional parameters to simplify record creation
            let createFunction =

                //format parameters
                let functionParameters =
                    values
                    |> Array.filter(fun v -> v.StaticValue.IsNone)
                    |> Array.sortBy(fun v -> ((if v.Required then 1 else 2), v.Name))
                    |> Array.map(fun v ->
                        let o = if v.Required then "" else "?"
                        let n = if v.Nullable then " option" else ""
                        $"{o}{v.Name |> camelCasify |> escapeReservedName}: {v.Type}{n}"
                    )

                let functionParametersString =
                    functionParameters
                    |> String.concat ", "

                //format property initialisers
                let functionProperties =
                    values
                    |> Array.filter(fun v -> v.StaticValue.IsNone)
                    |> Array.sortBy(fun v -> ((if v.Required then 1 else 2), v.Name))
                    |> Array.map(fun v ->
                        let flatten = if (v.Required |> not) && v.Nullable then " |> Option.flatten" else ""
                        let comment = if v.Required then " //required" else ""
                        $"\t\t\t\t{name |> pascalCasify}.{v.Name |> pascalCasify} = {v.Name |> camelCasify |> escapeReservedName}{flatten}{comment}"
                    )

                let functionPropertiesString =
                    functionProperties
                    |> String.concat "\n"

                //if there are no static properties, prefix `create` function with `with`
                let withPrefix = if staticPropertiesString |> String.IsNullOrWhiteSpace then $"\n\twith" else ""

                //compose `create` function
                $"{withPrefix}\n\t\tstatic member New ({functionParametersString}) =\n\t\t\t{{\n{functionPropertiesString}\n\t\t\t}}"

            //if there is a description, format it using comments
            let desc = if description |> String.IsNullOrWhiteSpace then "" else $"\t///{description |> commentify 1}\n"
                    
            //gather the type definition and properties of the type
            if properties |> Array.isEmpty then
                ModelValue({
                    Description = desc
                    Keyword = keyword
                    PascalName = name |> pascalCasify
                    StaticPropertiesString = staticPropertiesString
                }, model)
            else
                ModelValueWithProperties({
                    Description = desc
                    Keyword = keyword
                    PascalName = name |> pascalCasify
                    StaticPropertiesString = staticPropertiesString
                }, propertiesString, createFunction, model)

        //recursively iterate through the values and write them to the string builder
        let rec gatherValues (name: string) (description: string) values (model:ModelAst) : ModelAst =

            let model = 
                //hide intermediate lists and containers
                if not (name.EndsWith " list" || name.EndsWith " hide") then
                    gatherIntermediateListAndContainers (name: string) (description: string) values (model:ModelAst) 
                else model

            //write out any enumerations
            let modelWithEnumerations =
                values
                |> Array.filter(fun v -> v.EnumValues.IsSome)
                |> Array.fold(fun model v ->
                    gatherEnum (v.Type) (v.EnumValues.Value) model
                ) model

            let modelWithSubValues =
                //write out any sub-values
                values
                |> Array.filter(fun v -> v.SubValues.IsSome)
                |> Array.fold(fun model v ->
                    gatherValues (v.Type) (v.Description) (v.SubValues.Value) model
                ) modelWithEnumerations

            modelWithSubValues

        let model = 
            //write the values and enumerations to the string builder
            typeDefinitions
            |> Array.fold(fun model (name, desc, value) ->

                //start off the recursive iteration through the values
                gatherValues name desc value model

            ) header
        model

    /// Save the model to F# file.
    let serializeModel (version:string) fullModel =

        ///Utility function for appending lines to a StringBuilder
        let write (s: string) (sb: Text.StringBuilder) =
            sb.AppendLine s |> ignore

        //use a string builder to hold the output
        let sb = Text.StringBuilder()
        // The buffer will be added just after header
        let buffer = Text.StringBuilder()
        
        let rec writeModel model frontBuffer =
            match model with
            | ModelHeader ->
                //Write the namespace, references and module title
                let header = $"namespace FunStripe\n\nopen FunStripe.Json\nopen FunStripe.Util\nopen System\n\n[<System.CodeDom.Compiler.GeneratedCode(\"FunStripe\", \"{version}\")>]\nmodule StripeModel =\n"
                sb |> write header
                sb |> write (frontBuffer.ToString())
            | ModelEnum (keyword, name, valuesString, model) -> 
                do writeModel model frontBuffer
                //Write the type definition and members of the discriminated union
                sb |> write $"\t{keyword} {name} =\n{valuesString}\n"
            | ModelSimpleEnum (keyword, name, valuesString, model) -> 
                //Move simple enums to top of the file
                frontBuffer |> write $"\t{keyword} {name} =\n{valuesString}\n"
                do writeModel model frontBuffer
            | ModelValue (mve, model) ->
                do writeModel model frontBuffer
                //Write the type definition and properties of the type
                sb |> write $"{mve.Description}\t{mve.Keyword} {mve.PascalName} () = {mve.StaticPropertiesString}\n"
            | ModelValueWithProperties (mve, propertiesString, createFunction, model) ->
                writeModel model frontBuffer
                //Write the type definition and properties of the type
                sb |> write $"{mve.Description}\t{mve.Keyword} {mve.PascalName} = {{\n{propertiesString}\n\t}}{mve.StaticPropertiesString}{createFunction}\n"
            
        writeModel fullModel buffer

        //return a string from the string builder, replacing tabs with four spaces
        sb.ToString().Replace("\t", "    ")

#if INTERACTIVE
    ;;
    open ModelBuilder;;
    let m = parseModel None;;
    let s = serializeModel "0.11.1" m;;
    System.IO.File.WriteAllText($"{__SOURCE_DIRECTORY__}/StripeModel.fs", s);;
#endif
