namespace FunStripe.Json

#if FABLE_COMPILER
/// Fable-compatible JSON deserializer.
/// Reads [<JsonPropertyName>] attributes (from System.Text.Json.Serialization) for field and
/// case name overrides, falling back to snake_case for everything else.
/// Uses Thoth.Json for JSON parsing primitives.
module internal FableCore =
    open System
    open System.Reflection
    open FSharp.Reflection
    open Thoth.Json
    open System.Text.Json.Serialization

    // ---------------------------------------------------------------------------
    // Naming helpers
    // ---------------------------------------------------------------------------

    let private snakeCase (name: string) =
        let r = System.Text.RegularExpressions.Regex(@"(?<=[A-Z])(?=[A-Z][a-z])|(?<=[^A-Z])(?=[A-Z])|(?<=[A-Za-z])(?=[^A-Za-z])")
        if name.Contains "_" then name
        else r.Split name |> Array.map (fun s -> s.ToLower()) |> String.concat "_"

    let private getPropertyName (prop: PropertyInfo) =
        let attrs = prop.GetCustomAttributes(typeof<JsonPropertyNameAttribute>, false)
        if attrs.Length > 0 then
            (attrs.[0] :?> JsonPropertyNameAttribute).Name
        else
            snakeCase prop.Name

    let private getUnionCaseName (uci: UnionCaseInfo) =
        let attrs = uci.GetCustomAttributes typeof<JsonPropertyNameAttribute>
        if attrs.Length > 0 then
            (attrs.[0] :?> JsonPropertyNameAttribute).Name
        else
            snakeCase uci.Name

    // ---------------------------------------------------------------------------
    // Type helpers
    // ---------------------------------------------------------------------------

    let private isOptionType (t: Type) =
        t.IsGenericType && t.GetGenericTypeDefinition() = typedefof<option<_>>

    let private isListType (t: Type) =
        t.IsGenericType && t.GetGenericTypeDefinition() = typedefof<List<_>>

    let private isMapType (t: Type) =
        t.IsGenericType && t.GetGenericTypeDefinition() = typedefof<Map<_, _>>

    // ---------------------------------------------------------------------------
    // Main recursive decoder builder
    // ---------------------------------------------------------------------------

    let rec private makeDecoder (t: Type) : Decoder<obj> =
        if t = typeof<string> then
            Decode.string |> Decode.map box
        elif t = typeof<bool> then
            Decode.bool |> Decode.map box
        elif t = typeof<int> then
            Decode.oneOf [
                Decode.int |> Decode.map box
                // Stripe occasionally returns numeric strings
                Decode.string
                |> Decode.map (fun s ->
                    match Int32.TryParse s with
                    | true, i -> box i
                    | _ -> box 0)
            ]
        elif t = typeof<int64> then
            Decode.int64 |> Decode.map box
        elif t = typeof<float> then
            Decode.float |> Decode.map box
        elif t = typeof<decimal> then
            Decode.decimal |> Decode.map box
        elif t = typeof<DateTime> then
            // All Stripe DateTime fields use Unix epoch integers
            Decode.oneOf [
                Decode.int64
                |> Decode.map (fun epoch ->
                    DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Add(TimeSpan.FromSeconds(float epoch)) :> obj)
                Decode.string
                |> Decode.map (fun s -> DateTime.Parse(s, System.Globalization.CultureInfo.InvariantCulture) :> obj)
            ]
        elif t = typeof<DateTimeOffset> then
            Decode.oneOf [
                Decode.int64
                |> Decode.map (fun epoch ->
                    DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)
                        .Add(TimeSpan.FromSeconds(float epoch)) :> obj)
                Decode.string
                |> Decode.map (fun s -> DateTimeOffset.Parse(s, System.Globalization.CultureInfo.InvariantCulture) :> obj)
            ]
        elif t = typeof<Guid> then
            Decode.string |> Decode.map (fun s -> Guid.Parse s :> obj)
        elif t = typeof<Uri> then
            Decode.string |> Decode.map (fun s -> Uri s :> obj)
        elif isListType t then
            let itemType = t.GetGenericArguments().[0]
            let itemDecoder = makeDecoder itemType
            Decode.oneOf [
                // Standard JSON array
                Decode.list itemDecoder |> Decode.map box
                // Stripe paginated list object: { "data": [...], ... }
                Decode.field "data" (Decode.list itemDecoder) |> Decode.map box
            ]
        elif isMapType t then
            // Map<string, 'V>
            let valueType = t.GetGenericArguments().[1]
            let valueDecoder = makeDecoder valueType
            Decode.dict valueDecoder |> Decode.map box
        elif FSharpType.IsRecord t then
            makeRecordDecoder t
        elif FSharpType.IsUnion t then
            makeUnionDecoder t
        else
            Decode.fail $"FableCore: unsupported type '{t.Name}'"

    and private makeRecordDecoder (t: Type) : Decoder<obj> =
        let props = FSharpType.GetRecordFields t
        Decode.object (fun get ->
            let values =
                props
                |> Array.map (fun prop ->
                    let fieldName = getPropertyName prop
                    let fieldType = prop.PropertyType
                    if isOptionType fieldType then
                        // For option fields: absent or null → None; present → Some value
                        let innerType = fieldType.GetGenericArguments().[0]
                        let innerDecoder = makeDecoder innerType
                        get.Optional.Field fieldName innerDecoder |> box
                    else
                        let decoder = makeDecoder fieldType
                        get.Required.Field fieldName decoder |> box
                )
            FSharpValue.MakeRecord(t, values)
        )

    and private makeUnionDecoder (t: Type) : Decoder<obj> =
        let unionCases = FSharpType.GetUnionCases t
        // Simple string enums: all cases have zero fields
        let isSimpleEnum = unionCases |> Array.forall (fun c -> c.GetFields().Length = 0)
        if isSimpleEnum then
            Decode.string
            |> Decode.andThen (fun s ->
                let matchedCase =
                    unionCases
                    |> Array.tryFind (fun c -> getUnionCaseName c = s)
                match matchedCase with
                | Some uci ->
                    Decode.succeed (FSharpValue.MakeUnion(uci, [||]))
                | None ->
                    Decode.fail $"FableCore: unknown union case '{s}' for type '{t.Name}'")
        else
            // Complex union: try each case in order
            let caseDecoders =
                unionCases
                |> Array.toList
                |> List.map (fun uci ->
                    let fields = uci.GetFields()
                    match fields.Length with
                    | 0 ->
                        // Zero-field case matched by string value
                        Decode.string
                        |> Decode.andThen (fun s ->
                            if getUnionCaseName uci = s then
                                Decode.succeed (FSharpValue.MakeUnion(uci, [||]))
                            else
                                Decode.fail $"Not case {uci.Name}")
                    | 1 ->
                        // Single-field case: decode the inner value
                        let fieldType = fields.[0].PropertyType
                        let fieldDecoder = makeDecoder fieldType
                        fieldDecoder
                        |> Decode.map (fun v -> FSharpValue.MakeUnion(uci, [| v |]))
                    | _ ->
                        Decode.fail $"FableCore: multi-field union case '{t.Name}.{uci.Name}' is not supported"
                )
            Decode.oneOf caseDecoders

    // ---------------------------------------------------------------------------
    // Public entry point
    // ---------------------------------------------------------------------------

    /// Deserialize a JSON string to an F# value of the given runtime type.
    let deserializeString (t: Type) (jsonString: string) : obj =
        let decoder = makeDecoder t
        match Decode.fromString decoder jsonString with
        | Ok result -> result
        | Error msg -> failwith $"FunStripe JSON deserialization error: {msg}"

#endif
