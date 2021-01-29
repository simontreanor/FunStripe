namespace FunStripe.Json

open FSharp.Data
open Microsoft.FSharp.Reflection
open System
open System.Linq
open System.Text.RegularExpressions    

module Util =
    
    let internal toLower (str: string) = str.ToLower()

    let internal firstCharCapital (str: string) = (str.[0].ToString()).ToUpper() + str.Substring(1)

    /// Converts names into lower camel case. Use in [JsonConfig].
    let lowerCamelCase (name: string): string =
        let regex = @"(?<=[A-Z])(?=[A-Z][a-z])|(?<=[^A-Z])(?=[A-Z])|(?<=[A-Za-z])(?=[^A-Za-z])"
        let words = Regex.Split(name, regex) |> List.ofArray |> List.map toLower
        let first = List.head words
        let tail = List.tail words |> List.map firstCharCapital
        let parts = [first.ToLower()] @ tail
        String.Join("", parts)

    /// Converts names into snake case. Use in [JsonConfig].
    let snakeCase (name: string): string =
        let regex = @"(?<=[A-Z])(?=[A-Z][a-z])|(?<=[^A-Z])(?=[A-Z])|(?<=[A-Za-z])(?=[^A-Za-z])"
        let words = Regex.Split(name, regex) |> List.ofArray |> List.map toLower
        String.Join("_", words)

    ///JSON setting for snake-case formatting (Stripe uses snake-case, F# prefers pascal/camel case)
    let config = JsonConfig.New(allowUntyped = true, jsonFieldNaming = snakeCase, unformatted = true)

    ///Convert F# objects to JSON strings
    let serialise data =
        let json = Core.serialize config (data.GetType()) data
        let saveOptions =
            match config.Unformatted with
            | true -> JsonSaveOptions.DisableFormatting
            | false -> JsonSaveOptions.None
        json.ToString(saveOptions)

    ///Convert JSON strings to F# objects
    let deserialise<'a> data =
        let value = JsonValue.Parse(data)
        (Core.deserialize config JsonPath.Root typeof<'a> value) :?> 'a

    ///Get the name specified in the ```JsonUnionCase``` attribute (used to ensure correct naming of discriminated-union members where conventions are not followed)
    let getJsonUnionCaseName (value: obj) =
        let key = value |> string
        match value.GetType().UnderlyingSystemType.GetProperty(key) with
        | null ->
            config.JsonFieldNaming key
        | pi ->
            let name =
                pi.GetMethod.GetCustomAttributes(typeof<JsonUnionCase>, false).Cast<JsonUnionCase>()
                |> Seq.map(fun juc -> juc.Case)
                |> Seq.tryExactlyOne
            match name with
            | Some n -> n
            | None -> config.JsonFieldNaming key

    ///Get the name specified in the ```JsonField``` attribute (used to ensure correct naming of record/class members where conventions are not followed)
    let getJsonFieldName (value: obj) =
        let key = value |> string
        match value.GetType().UnderlyingSystemType.GetProperty(key) with
        | null ->
            config.JsonFieldNaming key
        | pi ->
            let name =
                pi.GetMethod.GetCustomAttributes(typeof<JsonField>, false).Cast<JsonField>()
                |> Seq.map(fun jf -> jf.Name)
                |> Seq.tryExactlyOne
            match name with
            | Some n -> n
            | None -> config.JsonFieldNaming key

    let getUnionCaseFromString<'a> (value: string) =
        typeof<'a>.UnderlyingSystemType.GetProperties()
        |> Array.map(fun pi ->
            pi.GetMethod.GetCustomAttributes(typeof<JsonField>, false).Cast<JsonField>()
            |> Seq.map(fun jf -> (pi.Name, jf.Name))
            |> Seq.tryExactlyOne
        )
        |> Array.choose id
        |> Array.tryFind(fun (_, jsonFieldName) -> jsonFieldName = value)
        |> Option.bind(fun (propertyName, _) ->
            match FSharpType.GetUnionCases typeof<'a> |> Array.filter (fun c -> c.Name = propertyName) with
            | [|c|] -> Some (FSharpValue.MakeUnion(c, [||]) :?> 'a)
            | _ -> None
        )
 
    ///Converts a string option to a strongly-typed union case, or a default strongly-typed value
    let optionToUnionCaseOr<'a> (defaultValue: 'a) (s: string option) =
        s |> Option.bind getUnionCaseFromString<'a> |> Option.defaultValue (defaultValue)

