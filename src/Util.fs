namespace FunStripe

open FSharp.Reflection
open System
open System.Globalization
open System.Text.RegularExpressions
open System.Reflection
open System.Text.Json.Serialization

module Util =

    ///Unwrap objects in discriminated-union fields into the underlying object
    let unwrap t (value: obj) =
        let _, fields = FSharpValue.GetUnionFields(value, t)
        fields |> Seq.tryExactlyOne

    let spitNameRegex = Regex(@"(?<=[A-Z])(?=[A-Z][a-z])|(?<=[^A-Z])(?=[A-Z])|(?<=[A-Za-z])(?=[^A-Za-z])")
    let choiceRegex = Regex(@"Choice\d+Of\d+")

    /// Converts names into snake case. Use for JSON field name defaults.
    let snakeCase (name: string): string =
        if name.Contains "_" then name else //don't double-snake-case!
        let words = spitNameRegex.Split name |> List.ofArray |> List.map(fun s -> s.ToLower())
        words |> String.concat "_"

    /// Read the explicit JSON field name from [<JsonPropertyName>] attribute, or fall back to snake_case.
    let private getPropertyName (prop: PropertyInfo) =
        let attrs = prop.GetCustomAttributes(typeof<JsonPropertyNameAttribute>, false)
        if attrs.Length > 0 then
            (attrs.[0] :?> JsonPropertyNameAttribute).Name
        else
            snakeCase prop.Name

    /// Read the explicit JSON case name from [<JsonPropertyName>] attribute, or fall back to snake_case.
    let private getUnionCaseName (uci: UnionCaseInfo) =
        let attrs = uci.GetCustomAttributes typeof<JsonPropertyNameAttribute>
        if attrs.Length > 0 then
            (attrs.[0] :?> JsonPropertyNameAttribute).Name
        else
            snakeCase uci.Name

    ///Recurse through record fields / class properties and format as form key/value pairs
    let format (propertyInfo: PropertyInfo) parameters =
        let key = getPropertyName propertyInfo
        let value = propertyInfo.GetValue(parameters, [||])
        let rec format' (key': string) (value': obj) =
            match value' with
            | :? (obj option) as o when Option.isNone o ->
                Seq.empty
            | _ when value'.GetType().IsGenericType && value'.GetType().GetGenericTypeDefinition() = typedefof<List<_>> ->
                value'
                |> unbox
                |> Seq.mapi (fun i o ->
                    $"{key'}[{i |> string}]", (o |> string)
                )
            | _ when FSharpType.IsUnion (value'.GetType()) ->
                match value'.GetType().Name with
                | n when n.StartsWith "FSharpOption" || choiceRegex.IsMatch n ->
                    match unwrap (value'.GetType()) value' with
                    | Some o -> format' key' o
                    | None -> Seq.empty
                | _ ->
                    let caseName = FSharpValue.GetUnionFields(value', value'.GetType()) |> fun (uci, _) -> getUnionCaseName uci
                    seq {key', $"{caseName}"}
            | _ when FSharpType.IsRecord (value'.GetType()) ->
                FSharpType.GetRecordFields (value'.GetType())
                |> Array.map (fun pi ->
                    let jsonFieldName = getPropertyName pi
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
                // Ensure DateTime is treated as UTC to avoid timezone ambiguity
                // If DateTime.Kind is Unspecified, assume it's UTC (Stripe API expectation)
                let utcDt = 
                    match dt.Kind with
                    | DateTimeKind.Utc -> dt
                    | DateTimeKind.Local -> dt.ToUniversalTime()
                    | DateTimeKind.Unspecified -> 
                        // Unspecified is ambiguous - treat as UTC and log warning in debug
                        #if DEBUG
                        System.Diagnostics.Debug.WriteLine($"Warning: DateTime with Unspecified kind being sent to Stripe API. Consider using DateTime.SpecifyKind or DateTimeOffset. Key: {key'}, Value: {dt}")
                        #endif
                        DateTime.SpecifyKind(dt, DateTimeKind.Utc)
                    | _ -> dt
                
                let unixTimestamp = (DateTimeOffset utcDt).ToUnixTimeSeconds().ToString CultureInfo.InvariantCulture
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
                    let jsonFieldName = getPropertyName pi
                    format' $"{key'}[{jsonFieldName}]" (pi.GetValue(value', [||]))
                )
                |> Seq.concat
            | _ ->
                seq {key', value' |> string}
        format' key value

    ///Convert JSON strings to F# objects
#if FABLE_COMPILER
    let deserialise<'a> (data: string) =
        Json.FableCore.deserializeString typeof<'a> data :?> 'a
#else
    let deserialise<'a> (data: string) : 'a =
        System.Text.Json.JsonSerializer.Deserialize<'a>(data, Json.StripeConverter.sharedOptions.Value)
#endif

    ///Serialise F# record as form
    let serialiseForm<'a> (parameters:'a) =
        FSharpType.GetRecordFields typeof<'a>
        |> Array.filter(fun pi -> pi.GetCustomAttributes(typeof<Config.FormAttribute>, false).Length > 0)
        |> Seq.collect (fun pi -> format pi parameters)

    //following functions are not required by the library but are useful utilities:

   ///Convert F# objects to JSON strings
#if !FABLE_COMPILER
    let serialise (data: obj) =
        System.Text.Json.JsonSerializer.Serialize(data, Json.StripeConverter.sharedOptions.Value)
#endif
        
#if !FABLE_COMPILER
    let getUnionCaseFromString<'a> (value: string) =
        typeof<'a>.UnderlyingSystemType.GetProperties()
        |> Array.map(fun pi ->
            pi.GetMethod.GetCustomAttributes(typeof<JsonPropertyNameAttribute>, false)
            |> Seq.cast<JsonPropertyNameAttribute>
            |> Seq.map(fun attr -> (pi.Name, attr.Name))
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
        s
        |> Option.bind getUnionCaseFromString<'a>
        |> Option.defaultValue defaultValue
#endif
