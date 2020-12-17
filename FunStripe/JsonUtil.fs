namespace FunStripe

open FSharp.Json
open System.Linq

module JsonUtil =
    
    let config = JsonConfig.create(jsonFieldNaming = Json.snakeCase)

    let serialise data =
        Json.serializeEx config data

    let deserialise<'a> data =
        //printfn "%A" data //uncomment this to view the raw API response if tests fail
        let o = Json.deserializeEx<'a> config data
        //printfn "%A" o //uncomment this to view the parsed API response if tests fail
        o

    let getJsonUnionCaseName (value: obj) =
        let key = value |> string
        match value.GetType().UnderlyingSystemType.GetProperty(key) with
        | null ->
            config.jsonFieldNaming key
        | pi ->
            let name =
                pi.GetMethod.GetCustomAttributes(typeof<JsonUnionCase>, false).Cast<JsonUnionCase>()
                |> Seq.map(fun juc -> juc.Case)
                |> Seq.tryExactlyOne
            match name with
            | Some n -> n
            | None -> config.jsonFieldNaming key

    let getJsonFieldName (value: obj) =
        let key = value |> string
        match value.GetType().UnderlyingSystemType.GetProperty(key) with
        | null ->
            config.jsonFieldNaming key
        | pi ->
            let name =
                pi.GetMethod.GetCustomAttributes(typeof<JsonField>, false).Cast<JsonField>()
                |> Seq.map(fun jf -> jf.Name)
                |> Seq.tryExactlyOne
            match name with
            | Some n -> n
            | None -> config.jsonFieldNaming key
