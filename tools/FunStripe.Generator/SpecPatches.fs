namespace FunStripe

open System.Text.Json.Nodes

///Corrections to Stripe's OpenAPI spec where it disagrees with the API it describes. Each one is
///applied only while the spec still needs it, so a spec that fixes the problem is left as it is.
module SpecPatches =

    ///Adds `value` to the string enum at `node`, unless it is already there
    let private addEnumValue (value: string) (node: JsonNode) =
        match node with
        | null -> false
        | node ->
            match node.["enum"] with
            | :? JsonArray as values when not (values |> Seq.exists (fun v -> v <> null && v.GetValue<string>() = value)) ->
                values.Add(JsonValue.Create value)
                true
            | _ -> false

    ///The file purpose `issuing_logo`: Stripe requires it for the card logo of an Issuing
    ///personalization design (`card_logo`: "Must have a `purpose` value of `issuing_logo`"), but
    ///leaves it out of the purposes of the File object, of file uploads and of the file list filter.
    ///Without it a logo cannot be uploaded, and the File it creates cannot be deserialised.
    let private issuingLogoFilePurpose (spec: JsonNode) =
        let filesPath = spec.["paths"].["/v1/files"]
        [
            spec.["components"].["schemas"].["file"].["properties"].["purpose"]
            if filesPath <> null then
                filesPath.["post"].["requestBody"].["content"].["multipart/form-data"].["schema"].["properties"].["purpose"]
                match filesPath.["get"].["parameters"] with
                | :? JsonArray as parameters ->
                    for parameter in parameters do
                        if parameter <> null && parameter.["name"] <> null && parameter.["name"].GetValue<string>() = "purpose" then
                            parameter.["schema"]
                | _ -> ()
        ]
        |> List.map (addEnumValue "issuing_logo")
        |> List.exists id

    let private patches = [
        "issuing_logo file purpose", issuingLogoFilePurpose
    ]

    ///Applies the patches to the JSON of a spec and returns the patched JSON
    let apply (specJson: string) =
        let spec = JsonNode.Parse specJson
        for name, patch in patches do
            if patch spec then printfn "  Patched the spec: %s" name
        spec.ToJsonString()
