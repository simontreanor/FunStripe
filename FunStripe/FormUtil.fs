namespace FunStripe

open FSharp.Reflection
open System
open System.Globalization

module FormUtil =

    let rec format (key: string) (value: obj option) =
        match value with
        | None ->
            Seq.empty
        | Some o ->
            match o with
            | :? string as s ->
                seq {key, s}
            | :? int | :? int64 as i ->
                seq {key, string i}
            | :? DateTime as dt ->
                let unixTimestamp = (DateTimeOffset dt).ToUnixTimeSeconds().ToString CultureInfo.InvariantCulture
                seq {key, unixTimestamp}
            | :? Map<string,obj option> as m when m |> Map.isEmpty -> 
                Seq.empty
            | :? Map<string,obj option> as m ->
                m
                |> Map.toSeq 
                |> Seq.map (fun (k, v) -> format $"{key}[{k}]" v)
                |> Seq.concat
            | _ ->
                let t = value.GetType()
                if FSharpType.IsUnion t then
                    let valueString = (FSharpValue.GetUnionFields(value, t) |> fst).Name |> JsonUtil.toSnakeCase
                    seq {key, valueString}
                elif FSharpType.IsRecord t then
                    FSharpType.GetRecordFields t
                    |> Array.map (fun pi -> format $"{key}[{pi.Name |> JsonUtil.toSnakeCase}]" (Some (pi.GetValue(value, [||])))) |> Seq.concat
                else
                    Seq.empty

    let serialise<'a> (``params``:'a) =
        FSharpType.GetRecordFields typeof<'a>
        |> Array.map (fun pi -> format $"{pi.Name |> JsonUtil.toSnakeCase}" (Some (pi.GetValue(``params``, [||])))) |> Seq.concat
