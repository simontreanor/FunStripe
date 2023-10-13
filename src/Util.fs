namespace FunStripe

open FSharp.Data
open FSharp.Reflection
open System
open System.Linq
open System.Globalization
open System.Text.RegularExpressions
open System.Reflection

module Util =

    ///Unwrap objects in discriminated-union fields into the underlying object
    let unwrap t (value: obj) =
        let _, fields = FSharpValue.GetUnionFields(value, t)
        fields.Cast<obj>()
        |> Seq.tryExactlyOne

     /// Converts names into snake case. Use in [JsonConfig].
    let snakeCase (name: string): string =
        if name.Contains "_" then name else //don't double-snake-case!
        let regex = @"(?<=[A-Z])(?=[A-Z][a-z])|(?<=[^A-Z])(?=[A-Z])|(?<=[A-Za-z])(?=[^A-Za-z])"
        let words = Regex.Split(name, regex) |> List.ofArray |> List.map(fun s -> s.ToLower())
        words |> String.concat "_"

    ///Recurse through record fields / class properties and format as form key/value pairs
    let format (config: Json.JsonConfig) (propertyInfo: PropertyInfo) parameters =
        let key = propertyInfo |> Json.Core.getJsonFieldName config (Json.Core.getJsonFieldProperty propertyInfo)
        let value = propertyInfo.GetValue(parameters, [||])
        let rec format' (key': string) (value': obj) =
            match value' with
            | :? (obj option) as o when Option.isNone o ->
                Seq.empty
            | _ when value'.GetType().IsGenericType && value'.GetType().GetGenericTypeDefinition() = typedefof<List<_>> ->
                value'
                |> unbox
                |> Seq.mapi (fun i o ->
                    $"{key'}[{i |> string}]", (o |> string |> snakeCase)
                )
            | _ when FSharpType.IsUnion (value'.GetType()) ->
                match value'.GetType().Name with
                | n when n.StartsWith "FSharpOption" || Regex.IsMatch(n, @"Choice\d+Of\d+") ->
                    match unwrap (value'.GetType()) value' with
                    | Some o -> format' key' o
                    | None -> Seq.empty
                | _ ->
                    let jsonUnionCaseName = FSharpValue.GetUnionFields(value', value'.GetType()) |> fun (uci, _) -> uci |> Json.Core.getJsonUnionCaseName config (Json.Core.getJsonUnionCase uci)
                    seq {key', $"{jsonUnionCaseName}"}
            | _ when FSharpType.IsRecord (value'.GetType()) ->
                FSharpType.GetRecordFields (value'.GetType())
                |> Array.map (fun pi ->
                    let jsonFieldName = pi |> Json.Core.getJsonFieldName config (Json.Core.getJsonFieldProperty pi)
                    format' $"{key'}[{jsonFieldName}]" (pi.GetValue(value', [||]))
                )
                |> Seq.concat
            | :? bool as b ->
                seq {key', b |> string |> fun s -> s.ToLower()}
            | :? int | :? int64 as i ->
                seq {key', i |> string}
            | :? string as s ->
                seq {key', s}
            | :? DateTime as dt ->
                let unixTimestamp = (DateTimeOffset dt).ToUnixTimeSeconds().ToString CultureInfo.InvariantCulture
                seq {key', unixTimestamp}
            | :? Map<string,string> as m when m |> Map.isEmpty -> 
                Seq.empty
            | :? Map<string,string> as m ->
                m
                |> Map.toSeq 
                |> Seq.map (fun (k, v) -> $"{key'}[{k}]", v)
            | _ when (unbox value').GetType().IsClass ->
                (unbox value').GetType().GetProperties()
                |> Array.map (fun pi ->
                    let jsonFieldName = pi |> Json.Core.getJsonFieldName config (Json.Core.getJsonFieldProperty pi)
                    format' $"{key'}[{jsonFieldName}]" (pi.GetValue(value', [||]))
                )
                |> Seq.concat
            | _ ->
                seq {key', value' |> string}
        format' key value

    ///JSON setting for snake-case formatting (Stripe uses snake-case, F# prefers pascal/camel case)
    let config = Json.JsonConfig.New(allowUntyped = true, jsonFieldNaming = snakeCase, unformatted = true)

    ///Convert JSON strings to F# objects
    let deserialise<'a> data =
        let value = JsonValue.Parse(data)
        (Json.Core.deserialize config Json.JsonPath.Root typeof<'a> value) :?> 'a

    ///Serialise F# record as form
    let serialiseForm<'a> (parameters:'a) =
        FSharpType.GetRecordFields typeof<'a>
        |> Array.filter(fun pi -> pi.CustomAttributes.Cast<CustomAttributeData>() |> Seq.exists(fun cad -> cad.AttributeType = typeof<Config.FormAttribute>))
        |> Seq.collect (fun pi -> format config pi parameters)
