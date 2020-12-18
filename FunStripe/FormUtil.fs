namespace FunStripe

open FSharp.Reflection
open System
open System.Linq
open System.Globalization
open System.Text.RegularExpressions

module FormUtil =

    ///Unwrap objects in discriminated-union fields into the underlying object
    let unwrap t (value: obj) =
        let _, fields = FSharpValue.GetUnionFields(value, t)
        fields.Cast<obj>()
        |> Seq.tryExactlyOne

    ///Override field names in form key by looking up ```JsonField``` attribute
    let formatFieldName (s: string) =
        Regex.Replace (s, @"\w+", (fun m -> m.Value |> JsonUtil.getJsonFieldName))

    ///Recurse through record fields / class properties and format as form key/value pairs
    let rec format (key: string) (value: obj) =
        match value with
        | :? (obj option) as o when Option.isNone o ->
            Seq.empty
        | _ when FSharpType.IsUnion (value.GetType()) ->
            match value.GetType().Name with
            | n when n.StartsWith "FSharpOption" || Regex.IsMatch(n, @"Choice\d+Of\d+") ->
                match unwrap (value.GetType()) value with
                | Some o ->
                    format key o
                | None ->
                    Seq.empty
            | _ ->
                seq {key, $"{value |> JsonUtil.getJsonUnionCaseName}" |> box}
        | _ when FSharpType.IsRecord (value.GetType()) ->
            FSharpType.GetRecordFields (value.GetType())
            |> Array.map (fun pi -> format $"{key}[{pi.Name}]" (pi.GetValue(value, [||])))
            |> Seq.concat
        | :? int | :? int64 as i ->
            seq {key, i |> string |> box}
        | :? string as s ->
            seq {key, s |> box}
        | :? DateTime as dt ->
            let unixTimestamp = (DateTimeOffset dt).ToUnixTimeSeconds().ToString CultureInfo.InvariantCulture
            seq {key, unixTimestamp |> box}
        | :? Map<string,string> as m when m |> Map.isEmpty -> 
            Seq.empty
        | :? Map<string,string> as m ->
            m
            |> Map.toSeq 
            |> Seq.collect (fun (k, v) -> format $"{key}[{k}]" v)
        | _ when (unbox value).GetType().IsClass ->
            (unbox value).GetType().GetProperties()
            |> Array.map (fun pi ->
                format $"{key}[{pi.Name}]" (pi.GetValue(value, [||]))
            )
            |> Seq.concat
        | _ ->
            seq {key, value}

    ///Serialise F# record
    let serialiseRecord<'a> (parameters:'a) =
        FSharpType.GetRecordFields typeof<'a>
        |> Array.map (fun pi -> format (pi.Name) (Some (pi.GetValue(parameters, [||])))) |> Seq.concat
        |> Seq.map (fun (k, v) -> (k |> formatFieldName, v |> string))

    ///Serialise F# class
    let serialise<'a> (parameters:'a) =
        typeof<'a>.GetProperties()
        |> Array.map (fun pi -> format (pi.Name) (Some (pi.GetValue(parameters, [||])))) |> Seq.concat
        |> Seq.map (fun (k, v) -> (k |> formatFieldName, v |> string))
