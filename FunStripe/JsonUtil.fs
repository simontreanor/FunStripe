namespace FunStripe

open FSharp.Json

module JsonUtil =
    
    let config = JsonConfig.create(jsonFieldNaming = Json.snakeCase)

    let serialise data =
        Json.serializeEx config data

    let deserialise<'a> data =
        Json.deserializeEx<'a> config data

    let toSnakeCase =
        Json.snakeCase
