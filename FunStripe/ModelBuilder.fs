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

    type Property = {
        AnyOf: JsonValue array option
        Description: string option
        Enum: JsonValue array option
        Items: JsonValue option
        Nullable: bool option
        Ref: string option
        Type': string option
    }

    let commentify (s: string) = 
        s.Replace("\n", "\n\t///")

    let clean (s: string) =
        s.Replace("-", "").Replace(" ", "")

    let casify (s: string) =
        let convertCase s = Regex.Replace(s, @"(^|_|\.)(\w)", fun (m: Match) -> m.Groups.[2].Value.ToUpper())

        if Regex.IsMatch(s, @"^\p{Lu}") then
            $@"[<JsonUnionCase(""{s}"")>] {s |> clean |> convertCase}"
        else
            if Regex.IsMatch(s, @"^\d") then
                $@"[<JsonUnionCase(""{s}"")>] Numeric{s |> clean |> convertCase}"
            elif s.Contains("-") || s.Contains(" ") then
                $@"[<JsonUnionCase(""{s}"")>] {s |> clean |> convertCase}"
            else
                s |> clean |> convertCase

    let parseRef (s: string) =
        let m = Regex.Match(s, "/([^/]+)$")
        if m.Success then
            m.Groups.[1].Value
        else
            failwith $"Error: unparsable reference: {s}"

    let mapType (s: string) =
        match s with
        | "boolean" -> "bool"
        | "integer" -> "int"
        | "number" -> "decimal"
        | _ -> s

    let getProperties (jv: JsonValue) =
        {
            AnyOf = jv.TryGetProperty("anyOf") |> function | Some v -> v.AsArray() |> Some | None -> None
            Description = jv.TryGetProperty("description") |> function | Some v -> v.AsString() |> Some | None -> None
            Enum = jv.TryGetProperty("enum") |> function | Some v -> v.AsArray() |> Some | None -> None
            Items = jv.TryGetProperty("items") |> function | Some v -> v |> Some | None -> None
            Nullable = jv.TryGetProperty("nullable") |> function | Some v -> v.AsBoolean() |> Some | None -> None
            Ref = jv.TryGetProperty("$ref") |> function | Some v -> v.AsString() |> Some | None -> None
            Type' = jv.TryGetProperty("type") |> function | Some v -> v.AsString() |> mapType |> Some | None -> None
        }

    let createEnum name (jvv: JsonValue array) =
        let s = 
            ("", 
                jvv
                |> Array.map(fun jv -> $"\t\t| {jv.AsString() |> casify}\n")
            ) |> String.Join
        $"\tand {name} =\n{s}"

    let createEnum2 name (ss: string seq) =
        let s = 
            ("", 
                ss
                |> Seq.map(fun s -> $"\t\t| {s |> casify}\n")
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
                        $"\t\t| {t |> casify} of {t}\n"
                    | _ ->
                    
                        match props.Ref with
                        | Some r ->
                            let refName = (r |> parseRef |> casify)
                            $"\t\t| {refName} of {refName}\n"
                        | None ->
                            ""
                )
            ) |> String.Join
        $"\tand {name} =\n{s}"

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

        sb |> write "namespace FunStripe\n\nopen FSharp.Json\n\nmodule Stripe =\n"
        
        for (key, value) in schemas.Properties do
            let name = key |> casify
            let record = value |> getProperties

            match record.Description with
            | Some d ->
                sb |> write $"\t///{d |> commentify}"
            | None ->
                ()

            match record.AnyOf with
            | Some aoo ->
                sb |> write (createAnyOf name aoo)
            | None ->

                let keyword =
                    if isFirstOccurrence then
                        isFirstOccurrence <- false
                        "type"
                    else
                        "and"

                sb |> write $"\t{keyword} {name} = {{\n"
        
                let enums = Collections.Generic.List<string>()
                let anyOfs = Collections.Generic.List<string>()
                
                for (k0, v0) in value.Properties do
                
                    match k0 with
                    | "description"
                    | "required"
                    | "title"
                    | "type"
                    | "x-expandableFields"
                    | "x-expansionResources"
                    | "x-resourceId"
                    | "x-stripeOperations"
                    | "x-stripeResource" ->
                        ()
                    | _ ->

                        if (v0.Properties.Any() |> not) then
                            sb |> write "\t\tEmptyProperties: string list\n"
                        else
                            
                        for (k1, v1) in v0.Properties do

                            let k1' = k1 |> casify
                            let props = v1 |> getProperties
            
                            let opt =
                                match props.Nullable with
                                | Some true ->
                                    " option"
                                | _ ->
                                    ""
                            
                            match props.Description with
                            | Some d when (String.IsNullOrWhiteSpace d |> not) ->
                                sb |> write $"\t\t///{d |> commentify}"
                            | _ ->
                                ()
            
                            match props.Enum with
                            | Some ee ->
                                let enumName = $"{name}{k1'}"
                                sb |> write $"\t\t{k1'}: {enumName}{opt}\n"
                                enums.Add (createEnum enumName ee)
                            | None ->

                                match props.Description with
                                | Some d when (String.IsNullOrWhiteSpace d |> not) && (d.Contains("Can be `")) ->
                                    match d |> parseStringEnum with
                                    | Some ee ->
                                        let enumName = $"{name}{k1'}"
                                        sb |> write $"\t\t{k1'}: {enumName}{opt}\n"
                                        enums.Add (createEnum2 enumName ee)
                                    | None ->
                                        ()
                                | _ ->
                                    ()

                                match props.AnyOf with
                                | Some aoo ->
                                    let anyOfName = $"{name}{k1'}DU"
                                    sb |> write $"\t\t{k1'}: {anyOfName}{opt}\n"
                                    anyOfs.Add (createAnyOf anyOfName aoo)
                                | None ->
            
                                    match props.Type' with
                                    | Some t when t = "array" ->
                                        match props.Items with
                                        | Some i ->
                                            let itemProps = i |> getProperties
                                            match itemProps.Ref with
                                            | Some r ->
                                                sb |> write $"\t\t{k1'}: {r |> parseRef |> casify} list\n"
                                            | None ->
                                                match itemProps.Enum with
                                                | Some ee ->
                                                    let enumName = $"{name}{k1'}"
                                                    sb |> write $"\t\t{k1'}: {enumName} list{opt}\n"
                                                    enums.Add(createEnum enumName ee)
                                                | None ->
                                                    match itemProps.Type' with
                                                    | Some t ->
                                                        sb |> write $"\t\t{k1'}: {t} list{opt}\n"
                                                    | None ->
                                                        match itemProps.AnyOf with
                                                        | Some aoo ->
                                                            let anyOfName = $"{name}{k1'}DU"
                                                            sb |> write $"\t\t{k1'}: {anyOfName} list{opt}\n"
                                                            anyOfs.Add(createAnyOf anyOfName aoo)
                                                        | None ->
                                                            failwith $"Error: unhandled property: %A{i}"
                                        | None ->
                                            sb |> write $"\t\t{k1'}: {t}{opt}\n"
                                    | Some t when t = "object" ->
                                        sb |> write $"\t\t{k1'}: Map<string, string>{opt}\n"
                                    | Some t ->
                                        match props.Description with
                                        | Some d when (String.IsNullOrWhiteSpace d |> not) && (d.Contains("Can be `")) ->
                                            ()
                                        | _ ->
                                            sb |> write $"\t\t{k1'}: {t}{opt}\n"
                                    | _ ->
                                    
                                        match props.Ref with
                                        | Some r ->
                                            sb |> write $"\t\t{k1'}: {r |> parseRef |> casify}\n"
                                        | None ->
                                            ()
            
                sb |> write "\t}\n"
                
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
