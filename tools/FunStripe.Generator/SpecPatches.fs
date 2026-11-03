namespace FunStripe

open System.Collections.Generic
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

    ///The node at `path` under `node`, or null where any step is missing
    let private at (path: string list) (node: JsonNode) =
        path |> List.fold (fun (n: JsonNode) key -> if n = null then null else n.[key]) node

    ///A Checkout Session's Cash App `setup_future_usage`: the object allows only `none`, while the
    ///create request takes `none`, `off_session` and `on_session`. A session created with
    ///`off_session` could then fail to deserialise, since the field is read from the answer. The
    ///values are taken from the create request, as the docs also list only `none` for the object.
    let private checkoutCashappSetupFutureUsage (spec: JsonNode) =
        let answer =
            spec |> at [ "components"; "schemas"; "checkout_cashapp_payment_method_options"; "properties"; "setup_future_usage" ]
        let request =
            spec
            |> at [ "paths"; "/v1/checkout/sessions"; "post"; "requestBody"; "content"; "application/x-www-form-urlencoded"
                    "schema"; "properties"; "payment_method_options"; "properties"; "cashapp"; "properties"
                    "setup_future_usage"; "enum" ]
        match answer, request with
        | null, _ -> false
        | answer, (:? JsonArray as accepted) ->
            [ for value in accepted do
                  if value <> null && value.GetValue<string>() <> "" then
                      addEnumValue (value.GetValue<string>()) answer ]
            |> List.exists id
        | _ -> false

    ///The bank transfer types of funding instructions: the object lists only `eu_bank_transfer` and
    ///`jp_bank_transfer`, while the requests take (and Stripe answers) `gb_bank_transfer`,
    ///`mx_bank_transfer` and `us_bank_transfer` too, e.g. for a UK Issuing balance. The missing values
    ///are taken from the request enum of customer funding instructions.
    let private fundingBankTransferTypes (spec: JsonNode) =
        let objectType =
            spec.["components"].["schemas"].["funding_instructions_bank_transfer"].["properties"].["type"]

        let requestPath = spec.["paths"].["/v1/customers/{customer}/funding_instructions"]

        if objectType = null || requestPath = null then
            false
        else
            match
                requestPath.["post"].["requestBody"].["content"].["application/x-www-form-urlencoded"].["schema"].["properties"].["bank_transfer"].["properties"].["type"].["enum"]
            with
            | :? JsonArray as requested ->
                [ for value in requested -> addEnumValue (value.GetValue<string>()) objectType ]
                |> List.exists id
            | _ -> false

    ///The Issuing balance's funding instructions (`/v1/issuing/funding_instructions`, create and list)
    ///and the test helper that funds the balance (`/v1/test_helpers/issuing/fund_balance`): Stripe
    ///documents them in its API reference but leaves them out of the spec. Built from the customer
    ///funding instructions request and the Issuing list conventions, and offered as methods of the
    ///`funding_instructions` object.
    let private issuingFundingInstructions (spec: JsonNode) =
        let paths = spec.["paths"].AsObject()
        let schemas = spec.["components"].["schemas"]
        let customerRequest = paths.["/v1/customers/{customer}/funding_instructions"]
        let bundles = paths.["/v1/issuing/physical_bundles"]

        if paths.ContainsKey "/v1/issuing/funding_instructions"
           || customerRequest = null
           || bundles = null
           || schemas.["funding_instructions"] = null then
            false
        else
            let clone (node: JsonNode) = node.DeepClone()
            let form = customerRequest.["post"].["requestBody"].["content"].["application/x-www-form-urlencoded"]
            let formProperties = form.["schema"].["properties"]
            let answer = JsonObject()
            answer.["content"] <- JsonObject([ KeyValuePair("application/json", JsonObject([ KeyValuePair("schema", JsonObject([ KeyValuePair("$ref", JsonValue.Create "#/components/schemas/funding_instructions" :> JsonNode) ]) :> JsonNode) ]) :> JsonNode) ])
            answer.["description"] <- JsonValue.Create "Successful response."

            let responses (ok: JsonNode) =
                JsonObject([ KeyValuePair("200", ok); KeyValuePair("default", clone customerRequest.["post"].["responses"].["default"]) ])

            let formBody (properties: (string * JsonNode) list) (required: string list) =
                let schema = JsonObject()
                schema.["additionalProperties"] <- JsonValue.Create false
                schema.["properties"] <- JsonObject(properties |> List.map KeyValuePair)
                schema.["required"] <- JsonArray(required |> List.map (fun name -> JsonValue.Create name :> JsonNode) |> Array.ofList)
                schema.["type"] <- JsonValue.Create "object"
                let content = JsonObject()
                content.["encoding"] <- clone form.["encoding"]
                content.["schema"] <- schema
                JsonObject([ KeyValuePair("content", JsonObject([ KeyValuePair("application/x-www-form-urlencoded", content :> JsonNode) ]) :> JsonNode); KeyValuePair("required", JsonValue.Create true :> JsonNode) ])

            let bankTransfer =
                JsonNode.Parse
                    """{ "description": "The bank transfer to fund the balance by", "properties": { "type": { "description": "The type of the `bank_transfer`", "enum": ["eu_bank_transfer", "gb_bank_transfer"], "type": "string", "x-stripeBypassValidation": true } }, "required": ["type"], "title": "bank_transfer_params", "type": "object" }"""

            let amount =
                JsonNode.Parse """{ "description": "The amount to fund, in the smallest currency unit.", "type": "integer" }"""

            let create = JsonObject()
            create.["description"] <- JsonValue.Create "<p>Create or retrieve funding instructions for an Issuing balance. If funding instructions don't yet exist for the account, new funding instructions will be created. If funding instructions have already been created for a given account, the same funding instructions will be retrieved. In other words, we will return the same funding instructions each time.</p>"
            create.["operationId"] <- JsonValue.Create "PostIssuingFundingInstructions"
            create.["requestBody"] <- formBody [ "bank_transfer", bankTransfer; "currency", clone formProperties.["currency"]; "expand", clone formProperties.["expand"]; "funding_type", clone formProperties.["funding_type"] ] [ "bank_transfer"; "currency"; "funding_type" ]
            create.["responses"] <- responses (clone answer)

            let listAnswer = clone answer
            listAnswer.["content"].["application/json"].["schema"] <-
                JsonNode.Parse
                    """{ "description": "", "properties": { "data": { "items": { "$ref": "#/components/schemas/funding_instructions" }, "type": "array" }, "has_more": { "description": "True if this list has another page of items after this one that can be fetched.", "type": "boolean" }, "object": { "description": "String representing the object's type. Objects of the same type share the same value. Always has the value `list`.", "enum": ["list"], "type": "string" }, "url": { "description": "The URL where this list can be accessed.", "maxLength": 5000, "type": "string" } }, "required": ["data", "has_more", "object", "url"], "title": "FundingInstructionsList", "type": "object", "x-expandableFields": ["data"] }"""

            let list = JsonObject()
            list.["description"] <- JsonValue.Create "<p>Retrieve all applicable funding instructions for an Issuing balance.</p>"
            list.["operationId"] <- JsonValue.Create "GetIssuingFundingInstructions"
            list.["parameters"] <-
                match bundles.["get"].["parameters"] with
                | :? JsonArray as parameters ->
                    JsonArray(
                        [| for parameter in parameters do
                               match parameter.["name"].GetValue<string>() with
                               | "ending_before" | "expand" | "limit" | "starting_after" -> clone parameter
                               | _ -> () |])
                | _ -> JsonArray()
            list.["requestBody"] <- clone bundles.["get"].["requestBody"]
            list.["responses"] <- responses listAnswer

            let fund = JsonObject()
            fund.["description"] <- JsonValue.Create "<p>Updates the Issuing balance as if money had arrived by bank transfer. Test mode only.</p>"
            fund.["operationId"] <- JsonValue.Create "PostTestHelpersIssuingFundBalance"
            fund.["requestBody"] <- formBody [ "amount", amount; "currency", clone formProperties.["currency"]; "expand", clone formProperties.["expand"] ] [ "amount"; "currency" ]
            fund.["responses"] <- responses (clone answer)

            paths.["/v1/issuing/funding_instructions"] <- JsonObject([ KeyValuePair("get", list :> JsonNode); KeyValuePair("post", create :> JsonNode) ])
            paths.["/v1/test_helpers/issuing/fund_balance"] <- JsonObject([ KeyValuePair("post", fund :> JsonNode) ])

            let operation name kind verb path =
                JsonNode.Parse $"""{{ "method_name": "{name}", "method_on": "service", "method_type": "{kind}", "operation": "{verb}", "path": "{path}" }}"""

            let operations =
                match schemas.["funding_instructions"].["x-stripeOperations"] with
                | :? JsonArray as existing -> existing
                | _ ->
                    let created = JsonArray()
                    schemas.["funding_instructions"].["x-stripeOperations"] <- created
                    created

            operations.Add(operation "list" "list" "get" "/v1/issuing/funding_instructions")
            operations.Add(operation "create" "create" "post" "/v1/issuing/funding_instructions")
            operations.Add(operation "fund_balance" "custom" "post" "/v1/test_helpers/issuing/fund_balance")
            true

    let private patches = [
        "issuing_logo file purpose", issuingLogoFilePurpose
        "funding instructions bank transfer types", fundingBankTransferTypes
        "Issuing funding instructions and fund_balance", issuingFundingInstructions
        "Checkout Cash App setup_future_usage", checkoutCashappSetupFutureUsage
    ]

    ///Applies the patches to the JSON of a spec and returns the patched JSON
    let apply (specJson: string) =
        let spec = JsonNode.Parse specJson
        for name, patch in patches do
            if patch spec then printfn "  Patched the spec: %s" name
        spec.ToJsonString()
