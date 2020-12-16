namespace FunStripe

open FSharp.Json
open System.Linq

module JsonUtil =
    
    let config = JsonConfig.create(jsonFieldNaming = Json.snakeCase)

    let serialise data =
        Json.serializeEx config data

    let deserialise<'a> data =
        Json.deserializeEx<'a> config data

    let toSnakeCase =
        Json.snakeCase

    let getJsonUnionCaseName (value: obj) =
        let key = value |> string
        let pi = value.GetType().UnderlyingSystemType.GetProperty(key)
        let name =
            pi.GetMethod.GetCustomAttributes(typeof<JsonUnionCase>, false).Cast<JsonUnionCase>()
            |> Seq.map(fun juc -> juc.Case)
            |> Seq.tryExactlyOne
        match name with
        | Some n -> n
        | None -> config.jsonFieldNaming key
