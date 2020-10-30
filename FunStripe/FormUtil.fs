namespace FunStripe

open FSharp.Reflection
open System
open System.Globalization
open System.Text.RegularExpressions

module FormUtil =

    let unwrap t (value: obj) =
        let _, fields = FSharpValue.GetUnionFields(value, t)
        match fields.Length with
        | 1 -> Some fields.[0]
        | _ -> None

    let snake (s: string) =
        Regex.Replace (s, @"\w+", (fun m -> m.Value |> JsonUtil.toSnakeCase))

    let rec format (key: string) (value: obj) =
        match value with
        | :? (obj option) as o when Option.isNone o ->
            Seq.empty
        | _ when FSharpType.IsUnion (value.GetType()) ->
            match value.GetType().Name with
            | n when n.StartsWith "FSharpOption" ->
                match unwrap (value.GetType()) value with
                | Some o ->
                    format key o
                | None ->
                    Seq.empty
            | _ ->
                seq {key, value |> string |> JsonUtil.toSnakeCase |> box}
        | _ when FSharpType.IsRecord (value.GetType()) ->
            FSharpType.GetRecordFields (value.GetType())
            |> Array.map (fun pi -> format $"{key}[{pi.Name}]" (pi.GetValue(value, [||])))
            |> Seq.concat
        | :? int | :? int64 as i ->
            seq {key, i |> string |> box}
        | :? DateTime as dt ->
            let unixTimestamp = (DateTimeOffset dt).ToUnixTimeSeconds().ToString CultureInfo.InvariantCulture
            seq {key, unixTimestamp |> box}
        | :? Map<string,string> as m when m |> Map.isEmpty -> 
            Seq.empty
        | :? Map<string,string> as m ->
            m
            |> Map.toSeq 
            |> Seq.map (fun (k, v) -> format $"{key}[{k}]" v)
            |> Seq.concat
        | _ ->
            seq {key, value}

    let serialise<'a> (``params``:'a) =
        FSharpType.GetRecordFields typeof<'a>
        |> Array.map (fun pi -> format (pi.Name) (Some (pi.GetValue(``params``, [||])))) |> Seq.concat
        |> Seq.map (fun (k, v) -> (k |> snake, v |> string))
