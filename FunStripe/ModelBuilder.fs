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

module ModelBuilder =

    let pascalCasify (s: string) =
        Regex.Replace(s, @"(^|_|\.)(\w)", fun (m: Match) -> m.Groups.[2].Value.ToUpper())

    let fixJsonNaming name =
        if Regex.IsMatch(name, @"(?<!_)\d") then
            $"[<JsonField(\"{name}\")>]{name |> pascalCasify}"
        else
            name |> pascalCasify

    type Parameter (description: string, optional: bool, name: string, ``type``: string, nullable: bool, ?staticValue: string) =

        member _.Description = description
        member _.Optional = optional
        member _.Name = name
        member _.Type = ``type``
        member _.Nullable = nullable
        member _.StaticValue = staticValue

        member this.ToPropertyString() =
            match this.StaticValue with
            | Some sv ->
                $"\t\tmember _.{this.Name |> fixJsonNaming} = \"{sv}\""
            | None ->
                let o = if this.Optional || this.Nullable then " option" else ""
                $"\t\t\t{this.Name |> fixJsonNaming}: {this.Type}{o}"

    type Property = {
        AnyOf: JsonValue array option
        Description: string option
        Enum: JsonValue array option
        Items: JsonValue option
        Nullable: bool option
        Properties: JsonValue
        Ref: string option
        Required: JsonValue array
        Type': string option
    }

    let commentify (s: string) = 
        s.Replace("\n", "\n\t///")

    let clean (s: string) =
        s.Replace("-", "").Replace(" ", "").Replace("none", "none'")

    let escapeNumeric s =
        Regex.Replace(s, @"^(\d)", "Numeric$1")

    let escapeForJson s =
        if Regex.IsMatch(s, @"^\p{Lu}") || Regex.IsMatch(s, @"^\d") || s.Contains("-") || s.Contains(" ") then
            $@"[<JsonUnionCase(""{s}"")>] {s |> clean |> pascalCasify |> escapeNumeric}"
        else
            s |> clean |> pascalCasify

    let parseRef (s: string) =
        let m = Regex.Match(s, "/([^/]+)$")
        if m.Success then
            m.Groups.[1].Value
        else
            failwith $"Error: unparsable reference: {s}"

    let mapType (s: string) =
        match s with
        | "boolean" -> "bool"
        | "integer" -> "int64"
        | "number" -> "decimal"
        | _ -> s

    let getProperties (jv: JsonValue) =
        {
            AnyOf = jv.TryGetProperty("anyOf") |> function | Some v -> v.AsArray() |> Some | None -> None
            Description = jv.TryGetProperty("description") |> function | Some v -> v.AsString() |> Some | None -> None
            Enum = jv.TryGetProperty("enum") |> function | Some v -> v.AsArray() |> Some | None -> None
            Items = jv.TryGetProperty("items") |> function | Some v -> v |> Some | None -> None
            Nullable = jv.TryGetProperty("nullable") |> function | Some v -> v.AsBoolean() |> Some | None -> None
            Properties = jv.TryGetProperty("properties") |> function | Some v -> v | None -> JsonValue.Null
            Ref = jv.TryGetProperty("$ref") |> function | Some v -> v.AsString() |> Some | None -> None
            Required = jv.TryGetProperty("required") |> function | Some v -> v.AsArray() | None -> [||]
            Type' = jv.TryGetProperty("type") |> function | Some v -> v.AsString() |> mapType |> Some | None -> None
        }

    let createEnum name (jvv: JsonValue array) =
        let s = 
            ("", 
                jvv
                |> Array.map(fun jv -> $"\t\t| {jv.AsString() |> escapeForJson}\n")
            ) |> String.Join
        $"\tand {name} =\n{s}"

    let createEnum2 name (ss: string seq) =
        let s = 
            ("", 
                ss
                |> Seq.map(fun s -> $"\t\t| {s |> escapeForJson}\n")
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
                        $"\t\t| {t |> escapeForJson} of {t}\n"
                    | _ ->
                    
                        match props.Ref with
                        | Some r ->
                            let refName = (r |> parseRef |> pascalCasify)
                            $"\t\t| {refName} of {refName}\n"
                        | None ->
                            ""
                )
            ) |> String.Join
        $"\tand {name} =\n{s}"

    // let createChoice (jvv: JsonValue array) =
    //     let s =
    //         (", ",
    //             jvv
    //             |> Array.map(fun jv ->
    //                 let props = jv |> getProperties
    //                 match props.Type' with
    //                 | Some t ->
    //                     t |> mapType
    //                 | _ ->
    //                     match props.Ref with
    //                     | Some r ->
    //                         r |> parseRef |> pascalCasify
    //                     | None ->
    //                         failwith "Error: Unparsable choice: %A{jv}"
    //             )
    //         ) |> String.Join
    //     $"Choice<{s}>"

    let write s (sb: Text.StringBuilder) =
        sb.AppendLine s |> ignore

    let parseModel filePath =

        let root = __SOURCE_DIRECTORY__

        let filePath' = defaultArg filePath $@"{root}/res/spec3.sdk.json"
        let json = File.ReadAllText(filePath')

        let root = JsonValue.Parse json
        let components = root.Item "components"
        let schemas = components.Item "schemas"

        let sb = Text.StringBuilder()

        let mutable isFirstOccurrence = true

        sb |> write "namespace FunStripe\n\nopen FSharp.Json\n\nmodule StripeModel =\n"
        
        for (key, value) in schemas.Properties do
            let record = value |> getProperties

            match record.Description with
            | Some d ->
                sb |> write $"\t///{d |> commentify}"
            | None ->
                ()

            match record.AnyOf with
            | Some aoo ->
                sb |> write (createAnyOf (key |> pascalCasify) aoo)
            | None ->

                let keyword =
                    if isFirstOccurrence then
                        isFirstOccurrence <- false
                        "type"
                    else
                        "and"

                let enums = Collections.Generic.List<string>()
                let anyOfs = Collections.Generic.List<string>()

                let properties = record.Properties
                let required = record.Required |> Array.map (fun jv -> jv.AsString())

                let parameters = [
                    if properties.Properties |> Array.isEmpty then
                        yield Parameter("///[no properties given in specification]", true, "Undefined", "string list", false)
                    else
                        for (k1, v1) in properties.Properties do
                            let props = v1 |> getProperties
            
                            let optional = required |> Array.exists (fun r -> r = k1) |> not
                            let nullable = props.Nullable |> function | Some b when b -> true | _ -> false

                            let description =
                                match props.Description with
                                | Some d when (String.IsNullOrWhiteSpace d |> not) ->
                                    $"\t\t///{d |> commentify}"
                                | _ ->
                                    ""
            
                            match props.Enum with
                            | Some ee ->
                                if k1 = "object" then
                                    yield Parameter(description, optional, k1, "string", nullable, key)
                                else
                                    let enumName = $"{key |> pascalCasify}{k1 |> pascalCasify}"
                                    enums.Add (createEnum enumName ee)
                                    yield Parameter(description, optional, k1, enumName, nullable)
                            | None ->
                                match props.Description with
                                | Some d when (String.IsNullOrWhiteSpace d |> not) && (d.Contains("Can be `")) ->
                                    match d |> parseStringEnum with
                                    | Some ee ->
                                        let enumName = $"{key |> pascalCasify}{k1 |> pascalCasify}"
                                        enums.Add (createEnum2 enumName ee)
                                        yield Parameter(description, optional, k1, enumName, nullable)
                                    | None ->
                                        ()
                                | _ ->
                                    ()

                                match props.AnyOf with
                                | Some aoo when aoo |> Array.length = 1 ->
                                    let ref' = ((aoo |> Array.exactlyOne) |> getProperties).Ref
                                    match ref' with
                                    | Some r ->
                                        yield Parameter(description, optional, k1, $"{r |> parseRef |> pascalCasify}", nullable)
                                    | None ->
                                        ()
                                | Some aoo ->
                                    // yield Parameter(description, optional, k1, (createChoice aoo), nullable)
                                    yield Parameter(description, optional, k1, "string", nullable)
                                | None ->
            
                                    match props.Type' with
                                    | Some t when t = "array" ->
                                        match props.Items with
                                        | Some i ->
                                            let itemProps = i |> getProperties
                                            match itemProps.Ref with
                                            | Some r ->
                                                yield Parameter(description, optional, k1, $"{r |> parseRef |> pascalCasify} list", nullable)
                                            | None ->
                                                match itemProps.Enum with
                                                | Some ee ->
                                                    let enumName = $"{key |> pascalCasify}{k1 |> pascalCasify}"
                                                    enums.Add(createEnum enumName ee)
                                                    yield Parameter(description, optional, k1, $"{enumName} list", nullable)
                                                | None ->
                                                    match itemProps.Type' with
                                                    | Some t ->
                                                        yield Parameter(description, optional, k1, $"{t} list", nullable)
                                                    | None ->
                                                        match itemProps.AnyOf with
                                                        | Some aoo when aoo |> Array.length = 1 ->
                                                            let ref' = ((aoo |> Array.exactlyOne) |> getProperties).Ref
                                                            match ref' with
                                                            | Some r ->
                                                                yield Parameter(description, optional, k1, $"{r |> parseRef |> pascalCasify} list", nullable)
                                                            | None ->
                                                                ()
                                                        | Some aoo ->
                                                            // yield Parameter(description, optional, k1, $"{createChoice aoo} list", nullable)
                                                            yield Parameter(description, optional, k1, $"string list", nullable)
                                                        | None ->
                                                            failwith $"Error: unhandled property: %A{i}"
                                        | None ->
                                            yield Parameter(description, optional, k1, $"{t} list", nullable)
                                    | Some t when t = "object" ->
                                        yield Parameter(description, false, k1, "Map<string, string>", false)
                                    | Some t ->
                                        match props.Description with
                                        | Some d when (String.IsNullOrWhiteSpace d |> not) && (d.Contains("Can be `")) ->
                                            ()
                                        | _ ->
                                            yield Parameter(description, optional, k1, t, nullable)
                                    | _ ->
                                        match props.Ref with
                                        | Some r ->
                                            yield Parameter(description, optional, k1, $"{r |> parseRef |> pascalCasify}", nullable)
                                        | None ->
                                            ()
                ]

                sb |> write $"\t{keyword} {key |> pascalCasify} =\n\t\t{{"

                parameters.Cast<Parameter>()
                |> Seq.filter(fun p -> p.StaticValue.IsNone)
                |> Seq.iter(fun p ->
                    sb |> write (p.ToPropertyString())
                )

                sb |> write "\t\t}"

                parameters.Cast<Parameter>()
                |> Seq.filter(fun p -> p.StaticValue.IsSome)
                |> Seq.iter(fun p ->
                    sb |> write (p.ToPropertyString())
                )

                sb |> write ""
                
                for e in enums do
                    sb |> write e
        
                for ao in anyOfs do
                    sb |> write ao

        sb.ToString().Replace("\t", "    ")

#if INTERACTIVE
    ;;
    open ModelBuilder;;
    let s = parseModel None;;
    System.IO.File.WriteAllText(__SOURCE_DIRECTORY__ + "/StripeModel.fs", s);;
#endif
