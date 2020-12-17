namespace FunStripe

open FSharp.Json
open System.Linq
// open Newtonsoft.Json
// open Newtonsoft.Json.Serialization
//open System.Text.RegularExpressions

module JsonUtil =
    
    let config = JsonConfig.create(jsonFieldNaming = Json.snakeCase)

    // let settings = JsonSerializerSettings()
    // let resolver = DefaultContractResolver()
    // resolver.NamingStrategy <- SnakeCaseNamingStrategy()
    // settings.ContractResolver <- resolver

    let serialise data =
        Json.serializeEx config data
        // JsonConvert.SerializeObject(data, settings)

    let deserialise<'a> data =
        Json.deserializeEx<'a> config data
        // JsonConvert.DeserializeObject<'a>(data, settings)

    let toSnakeCase (s: string) =
        Json.snakeCase s
        // Regex.Replace(s, @"\p{Lu}", fun (m: Match) -> $"_{m.Value.ToLowerInvariant()}").TrimStart('_')

    let getJsonName (value: obj) =
        let key = value |> string
        let pi = value.GetType().UnderlyingSystemType.GetProperty(key)
        let name =
            pi.GetMethod.GetCustomAttributes(typeof<JsonUnionCase>, false).Cast<JsonUnionCase>()
            |> Seq.map(fun juc -> juc.Case)
            |> Seq.tryExactlyOne
        match name with
        | Some n -> n
        | None -> config.jsonFieldNaming key
        // let key = value |> string
        // let pi = value.GetType().UnderlyingSystemType.GetProperty(key)
        // let name =
        //     pi.GetMethod.GetCustomAttributes(typeof<JsonPropertyAttribute>, false).Cast<JsonPropertyAttribute>()
        //     |> Seq.map(fun jp -> jp.PropertyName)
        //     |> Seq.tryExactlyOne
        // match name with
        // | Some n -> n
        // | None -> key |> toSnakeCase
