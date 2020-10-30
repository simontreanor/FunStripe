namespace FunStripe

open FSharp.Json
//open Newtonsoft.Json
//open Newtonsoft.Json.Serialization

module JsonUtil =
    
    let config = JsonConfig.create(jsonFieldNaming = Json.snakeCase)

    let serialise data =
        Json.serializeEx config data

    let deserialise<'a> data =
        Json.deserializeEx<'a> config data

    let toSnakeCase =
        Json.snakeCase

    // let contractResolver = DefaultContractResolver(NamingStrategy = SnakeCaseNamingStrategy())

    // let serialise data =
    //     JsonConvert.SerializeObject (data, JsonSerializerSettings(ContractResolver = contractResolver))

    // let deserialise<'a> data =
    //     JsonConvert.DeserializeObject<'a> (data, JsonSerializerSettings(ContractResolver = contractResolver))
