namespace FunStripe.Json

#if !FABLE_COMPILER
/// Custom JSON converters for Stripe's .NET path.
/// Replaces the forked FSharp.Json Core.fs (~916 lines) with focused converters (~150 lines).
module StripeConverter =
    open System
    open System.Text.Json
    open System.Text.Json.Serialization
    open System.Text.RegularExpressions
    open Microsoft.FSharp.Reflection
    open System.Reflection

    // ---------------------------------------------------------------------------
    // Helpers
    // ---------------------------------------------------------------------------

    let private snakeToPascal (s: string) =
        Regex.Replace(s, @"(^|_|\.| )(.)", fun (m: Match) -> m.Groups.[2].Value.ToUpper())

    let private pascalToSnake (s: string) =
        let r = Regex(@"(?<=[A-Z])(?=[A-Z][a-z])|(?<=[^A-Z])(?=[A-Z])|(?<=[A-Za-z])(?=[^A-Za-z])")
        if s.Contains "_" then s
        else r.Split s |> Array.map (fun w -> w.ToLowerInvariant()) |> String.concat "_"

    /// Custom JsonNamingPolicy that converts PascalCase/camelCase field names to snake_case.
    /// Used because JsonNamingPolicy.SnakeCaseLower requires System.Text.Json 8+.
    type SnakeCaseNamingPolicy() =
        inherit JsonNamingPolicy()
        override _.ConvertName(name) = pascalToSnake name

    let private sharedNamingPolicy = SnakeCaseNamingPolicy()

    /// Read the [<JsonPropertyName>] attribute value for a union case, or fall back to
    /// snake_case of the case name.
    let private getUnionCaseName (uci: UnionCaseInfo) =
        match uci.GetCustomAttributes typeof<JsonPropertyNameAttribute> with
        | [| attr |] -> (attr :?> JsonPropertyNameAttribute).Name
        | _ -> pascalToSnake uci.Name

    // ---------------------------------------------------------------------------
    // DateTime converter: reads epoch int64 or ISO-8601 string
    // ---------------------------------------------------------------------------

    /// Deserializes DateTime from a Unix-epoch integer or ISO-8601 string.
    /// Serializes as a Unix-epoch integer (matching Stripe's wire format).
    type EpochDateTimeConverter() =
        inherit JsonConverter<DateTime>()

        override _.Read(reader, _, _) =
            match reader.TokenType with
            | JsonTokenType.Number ->
                DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                    .Add(TimeSpan.FromSeconds(float (reader.GetInt64())))
            | JsonTokenType.String ->
                DateTime.Parse(
                    reader.GetString(),
                    Globalization.CultureInfo.InvariantCulture,
                    Globalization.DateTimeStyles.RoundtripKind)
            | t -> failwith $"EpochDateTimeConverter: unexpected token type {t}"

        override _.Write(writer, value, _) =
            let epoch = int64((value.ToUniversalTime() - DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds)
            writer.WriteNumberValue(epoch)

    // ---------------------------------------------------------------------------
    // Union converter: handles "object"-field discriminated unions
    // ---------------------------------------------------------------------------

    /// Inner (generic) converter for a specific F# DU type.
    type private StripeUnionConverterInner<'T>() =
        inherit JsonConverter<'T>()

        let unionCases = FSharpType.GetUnionCases(typeof<'T>)
        let isSimpleStringEnum = unionCases |> Array.forall (fun c -> c.GetFields().Length = 0)

        override _.Read(reader, _, options) =
            use doc = JsonDocument.ParseValue(&reader)
            let element = doc.RootElement

            match element.ValueKind with
            | JsonValueKind.String ->
                let s = element.GetString()
                if isSimpleStringEnum then
                    // Pure string enum: match by attribute name or snake_case
                    let matchedCase = unionCases |> Array.tryFind (fun c -> getUnionCaseName c = s)
                    match matchedCase with
                    | Some uci -> FSharpValue.MakeUnion(uci, [||]) :?> 'T
                    | None -> failwith $"StripeUnionConverter: unknown case '{s}' for type {typeof<'T>.Name}"
                else
                    // Mixed union: find the case wrapping a string
                    let stringCase =
                        unionCases |> Array.tryFind (fun c ->
                            c.GetFields().Length = 1 && c.GetFields().[0].PropertyType = typeof<string>)
                    match stringCase with
                    | Some uci -> FSharpValue.MakeUnion(uci, [| s :> obj |]) :?> 'T
                    | None ->
                        // Might still be a no-field case matching the string value
                        let matchedCase = unionCases |> Array.tryFind (fun c -> c.GetFields().Length = 0 && getUnionCaseName c = s)
                        match matchedCase with
                        | Some uci -> FSharpValue.MakeUnion(uci, [||]) :?> 'T
                        | None -> failwith $"StripeUnionConverter: no string case in {typeof<'T>.Name} for value '{s}'"

            | JsonValueKind.Number ->
                // Some Stripe fields are numeric enums in request types
                let numberCase =
                    unionCases |> Array.tryFind (fun c ->
                        c.GetFields().Length = 1 && (c.GetFields().[0].PropertyType = typeof<int> || c.GetFields().[0].PropertyType = typeof<int64> || c.GetFields().[0].PropertyType = typeof<decimal>))
                match numberCase with
                | Some uci ->
                    let innerType = uci.GetFields().[0].PropertyType
                    let json = element.GetRawText()
                    let innerValue = JsonSerializer.Deserialize(json, innerType, options)
                    FSharpValue.MakeUnion(uci, [| innerValue |]) :?> 'T
                | None -> failwith $"StripeUnionConverter: no numeric case in {typeof<'T>.Name}"

            | JsonValueKind.Object ->
                let json = element.GetRawText()
                // Attempt to use the "object" field as a discriminator (Stripe's polymorphism pattern)
                let mutable objectProp = Unchecked.defaultof<JsonElement>
                let objectTypeName =
                    if element.TryGetProperty("object", &objectProp) then
                        Some (snakeToPascal (objectProp.GetString()))
                    else
                        None

                match objectTypeName with
                | Some typeName ->
                    // Direct match: find a union case whose wrapped type name matches
                    let directCase =
                        unionCases |> Array.tryFind (fun c ->
                            c.GetFields().Length = 1 && c.GetFields().[0].PropertyType.Name = typeName)
                    match directCase with
                    | Some uci ->
                        let innerType = uci.GetFields().[0].PropertyType
                        let innerValue = JsonSerializer.Deserialize(json, innerType, options)
                        FSharpValue.MakeUnion(uci, [| innerValue |]) :?> 'T
                    | None ->
                        // Nested match: e.g. CustomerDefaultSource'AnyOf → PaymentSource → Card
                        // When the top-level union has a case wrapping another union, and the object
                        // type name matches a case in the inner union.
                        let nestedCase =
                            unionCases |> Array.tryPick (fun wrapperCase ->
                                let fields = wrapperCase.GetFields()
                                if fields.Length = 1 && FSharpType.IsUnion fields.[0].PropertyType then
                                    let innerCases = FSharpType.GetUnionCases fields.[0].PropertyType
                                    innerCases
                                    |> Array.tryFind (fun ic ->
                                        ic.GetFields().Length = 1 && ic.GetFields().[0].PropertyType.Name = typeName)
                                    |> Option.map (fun innerCase -> (wrapperCase, fields.[0].PropertyType, innerCase))
                                else None)

                        match nestedCase with
                        | Some (wrapperCase, wrapperType, innerCase) ->
                            let leafType = innerCase.GetFields().[0].PropertyType
                            let leafValue = JsonSerializer.Deserialize(json, leafType, options)
                            let innerUnionValue = FSharpValue.MakeUnion(innerCase, [| leafValue |])
                            FSharpValue.MakeUnion(wrapperCase, [| innerUnionValue |]) :?> 'T
                        | None ->
                            failwith $"StripeUnionConverter: no matching case for 'object'=\"{typeName}\" in {typeof<'T>.Name}"

                | None ->
                    // No "object" discriminator – try each case in order (untagged fallback)
                    let mutable result = None
                    for uci in unionCases do
                        if result.IsNone then
                            let fields = uci.GetFields()
                            if fields.Length = 1 then
                                try
                                    let innerValue = JsonSerializer.Deserialize(json, fields.[0].PropertyType, options)
                                    result <- Some (FSharpValue.MakeUnion(uci, [| innerValue |]) :?> 'T)
                                with _ -> ()
                    match result with
                    | Some v -> v
                    | None -> failwith $"StripeUnionConverter: could not deserialize {typeof<'T>.Name} from JSON object (no 'object' field)"

            | JsonValueKind.Null ->
                // Should be handled upstream by option<'T>; reaching here is an error
                failwith $"StripeUnionConverter: unexpected null for {typeof<'T>.Name}"

            | other ->
                failwith $"StripeUnionConverter: unexpected JSON value kind {other} for {typeof<'T>.Name}"

        override _.Write(writer, value, options) =
            let uci, fields = FSharpValue.GetUnionFields(value, typeof<'T>)
            match fields.Length with
            | 0 ->
                writer.WriteStringValue(getUnionCaseName uci)
            | 1 ->
                JsonSerializer.Serialize(writer, fields.[0], fields.[0].GetType(), options)
            | _ ->
                failwith $"StripeUnionConverter: multi-field union case not supported: {typeof<'T>.Name}.{uci.Name}"

    /// JsonConverterFactory that produces a StripeUnionConverterInner<'T> for any F# DU
    /// except option<'T> and FSharpList<'T> (which are handled by FSharp.SystemTextJson).
    type StripeUnionConverterFactory() =
        inherit JsonConverterFactory()

        override _.CanConvert(t) =
            FSharpType.IsUnion(t) &&
            not (t.IsGenericType && t.GetGenericTypeDefinition() = typedefof<option<_>>) &&
            not (t.IsGenericType && t.GetGenericTypeDefinition() = typedefof<list<_>>)

        override _.CreateConverter(t, _options) =
            let converterType = typedefof<StripeUnionConverterInner<_>>.MakeGenericType(t)
            Activator.CreateInstance(converterType) :?> JsonConverter

    // ---------------------------------------------------------------------------
    // Public JsonSerializerOptions factory
    // ---------------------------------------------------------------------------

    /// Creates the JsonSerializerOptions used for all Stripe .NET deserialization.
    /// Registers EpochDateTimeConverter and StripeUnionConverterFactory before
    /// FSharp.SystemTextJson's own converters so our union logic takes precedence.
    let createOptions () =
        // Start with FSharp.SystemTextJson options (handles F# records, option, list, map, etc.)
        let opts =
            JsonFSharpOptions
                .Default()
                .ToJsonSerializerOptions()
        opts.PropertyNamingPolicy <- sharedNamingPolicy
        opts.DefaultIgnoreCondition <- JsonIgnoreCondition.WhenWritingNull
        // Insert our converters BEFORE FSharp.SystemTextJson's converter so they win for DUs.
        opts.Converters.Insert(0, EpochDateTimeConverter())
        opts.Converters.Insert(0, StripeUnionConverterFactory())
        opts

    /// Lazily-created shared options instance.
    let sharedOptions = lazy createOptions()
#endif
