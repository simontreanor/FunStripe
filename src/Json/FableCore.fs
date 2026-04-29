namespace FunStripe.Json

#if FABLE_COMPILER
/// Fable-compatible JSON deserializer that reads the existing [<JsonField>] and
/// [<JsonUnionCase>] attributes via Fable's reflection support, using Thoth.Json
/// for JSON parsing primitives.
module internal FableCore =
    open System
    open System.Reflection
    open FSharp.Reflection
    open Thoth.Json

    // ---------------------------------------------------------------------------
    // Attribute helpers
    // ---------------------------------------------------------------------------

    let private getJsonFieldAttr (prop: PropertyInfo) : JsonField option =
        let attrs = prop.GetCustomAttributes(typeof<JsonField>, false)
        if attrs.Length > 0 then Some (attrs.[0] :?> JsonField) else None

    let private getJsonUnionCaseAttr (uci: UnionCaseInfo) : JsonUnionCase option =
        let attrs = uci.GetCustomAttributes typeof<JsonUnionCase>
        if attrs.Length > 0 then Some (attrs.[0] :?> JsonUnionCase) else None

    let private getFieldName (config: JsonConfig) (prop: PropertyInfo) =
        match getJsonFieldAttr prop with
        | Some jf when not (String.IsNullOrEmpty jf.Name) -> jf.Name
        | _ -> config.JsonFieldNaming prop.Name

    let private getTransformAttr (prop: PropertyInfo) : Type option =
        match getJsonFieldAttr prop with
        | Some jf when jf.Transform <> null -> Some jf.Transform
        | _ -> None

    let private getUnionCaseName (config: JsonConfig) (uci: UnionCaseInfo) =
        match getJsonUnionCaseAttr uci with
        | Some juc when not (String.IsNullOrEmpty juc.Case) -> juc.Case
        | _ -> config.JsonFieldNaming uci.Name

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
    // Transform decoders for the three known ITypeTransform implementations
    // ---------------------------------------------------------------------------

    let private applyTransformDecoder (transformType: Type) : Decoder<obj> =
        if transformType = typeof<Transforms.DateTimeEpoch> then
            Decode.int64
            |> Decode.map (fun epoch ->
                DateTime(1970, 1, 1).Add(TimeSpan.FromSeconds(float epoch)) :> obj)
        elif transformType = typeof<Transforms.DateTimeOffsetEpoch> then
            Decode.int64
            |> Decode.map (fun epoch ->
                DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)
                    .Add(TimeSpan.FromSeconds(float epoch)) :> obj)
        elif transformType = typeof<Transforms.UriTransform> then
            Decode.string |> Decode.map (fun s -> Uri(s) :> obj)
        else
            Decode.fail $"Unsupported transform type: {transformType.Name}"

    // ---------------------------------------------------------------------------
    // Main recursive decoder builder
    // ---------------------------------------------------------------------------

    let rec private makeDecoder (config: JsonConfig) (t: Type) : Decoder<obj> =
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
            // DateTime without a Transform attribute: try ISO-8601 string first, then epoch int
            Decode.oneOf [
                Decode.string
                |> Decode.map (fun s -> DateTime.Parse(s, System.Globalization.CultureInfo.InvariantCulture) :> obj)
                Decode.int64
                |> Decode.map (fun epoch ->
                    DateTime(1970, 1, 1).Add(TimeSpan.FromSeconds(float epoch)) :> obj)
            ]
        elif t = typeof<DateTimeOffset> then
            Decode.oneOf [
                Decode.string
                |> Decode.map (fun s -> DateTimeOffset.Parse(s, System.Globalization.CultureInfo.InvariantCulture) :> obj)
                Decode.int64
                |> Decode.map (fun epoch ->
                    DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)
                        .Add(TimeSpan.FromSeconds(float epoch)) :> obj)
            ]
        elif t = typeof<Guid> then
            Decode.string |> Decode.map (fun s -> Guid.Parse s :> obj)
        elif t = typeof<Uri> then
            Decode.string |> Decode.map (fun s -> Uri s :> obj)
        elif isListType t then
            let itemType = t.GetGenericArguments().[0]
            let itemDecoder = makeDecoder config itemType
            Decode.oneOf [
                // Standard JSON array
                Decode.list itemDecoder |> Decode.map box
                // Stripe paginated list object: { "data": [...], ... }
                Decode.field "data" (Decode.list itemDecoder) |> Decode.map box
            ]
        elif isMapType t then
            // Map<string, 'V>
            let valueType = t.GetGenericArguments().[1]
            let valueDecoder = makeDecoder config valueType
            Decode.dict valueDecoder |> Decode.map box
        elif FSharpType.IsRecord t then
            makeRecordDecoder config t
        elif FSharpType.IsUnion t then
            makeUnionDecoder config t
        else
            Decode.fail $"FableCore: unsupported type '{t.Name}'"

    and private makeDecoderForProp (config: JsonConfig) (prop: PropertyInfo) : Decoder<obj> =
        match getTransformAttr prop with
        | Some transformType -> applyTransformDecoder transformType
        | None -> makeDecoder config prop.PropertyType

    and private makeRecordDecoder (config: JsonConfig) (t: Type) : Decoder<obj> =
        let props = FSharpType.GetRecordFields t
        Decode.object (fun get ->
            let values =
                props
                |> Array.map (fun prop ->
                    let fieldName = getFieldName config prop
                    let fieldType = prop.PropertyType
                    if isOptionType fieldType then
                        // For option fields: absent or null → None; present → Some value
                        let innerType = fieldType.GetGenericArguments().[0]
                        let innerDecoder =
                            match getTransformAttr prop with
                            | Some transformType -> applyTransformDecoder transformType
                            | None -> makeDecoder config innerType
                        // get.Optional.Field returns 'T option; here 'T = obj, so we get obj option
                        get.Optional.Field fieldName innerDecoder |> box
                    else
                        let decoder = makeDecoderForProp config prop
                        get.Required.Field fieldName decoder |> box
                )
            FSharpValue.MakeRecord(t, values)
        )

    and private makeUnionDecoder (config: JsonConfig) (t: Type) : Decoder<obj> =
        let unionCases = FSharpType.GetUnionCases t
        // Simple string enums: all cases have zero fields
        let isSimpleEnum = unionCases |> Array.forall (fun c -> c.GetFields().Length = 0)
        if isSimpleEnum then
            Decode.string
            |> Decode.andThen (fun s ->
                let matchedCase =
                    unionCases
                    |> Array.tryFind (fun c -> getUnionCaseName config c = s)
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
                            if getUnionCaseName config uci = s then
                                Decode.succeed (FSharpValue.MakeUnion(uci, [||]))
                            else
                                Decode.fail $"Not case {uci.Name}")
                    | 1 ->
                        // Single-field case: decode the inner value
                        let fieldType = fields.[0].PropertyType
                        let fieldDecoder = makeDecoder config fieldType
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
    /// Uses the supplied JsonConfig for field naming and attribute inspection.
    let deserializeString (config: JsonConfig) (t: Type) (jsonString: string) : obj =
        let decoder = makeDecoder config t
        match Decode.fromString decoder jsonString with
        | Ok result -> result
        | Error msg -> failwith $"FunStripe JSON deserialization error: {msg}"

#endif
