open FunStripe
open FunStripe.AsyncResultCE
open FunStripe.StripeError
open FunStripe.StripeModel
open FunStripe.StripeRequest
open System
open System.Text.RegularExpressions
open FSharp.Data

///Convert `snake_case` to `PascalCase`
let pascalCasify (s: string) =
    Regex.Replace(s, @"(^|_|\.)(\w)", fun (m: Match) -> m.Groups.[2].Value.ToUpper())

///Get the object type based on the value of the static `Object` field
let getStripeObjectType json =
    (json, @"""object"": ""(.+?)""")
    |> System.Text.RegularExpressions.Regex.Match
    |> fun m -> m.Success |> function
        | true -> $"FunStripe.StripeModel+{m.Groups.[1].Value |> pascalCasify}, FunStripe"
        | false -> "Microsoft.FSharp.Collections.FSharpMap`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], FSharp.Core"
    |> Type.GetType
    |> (fun t -> t, json)

///Convert JSON strings to F# objects
let deserialise' type' data =
    let value = JsonValue.Parse(data)
    (Json.Core.deserialize Util.config Json.JsonPath.Root type' value) :?> 'a

///Detect JSON string type and convert to F# objects
let deserialiseStripeObject json =
    json |> getStripeObjectType ||> deserialise'

let testCustomer = "cus_HxEURwENT9MKb3"

let defaultCard =
    PaymentMethods.Create'CardCardDetailsParams.New(
        cvc = "314",
        expMonth = 10,
        expYear = 2021,
        number = "4242424242424242"
    )

let settings = RestApi.StripeApiSettings.New(apiKey = Config.StripeTestApiKey)

let simpleError message =
    async { return Error { ErrorResponse.StripeError = ErrorObject.New(message = message) } }

let getNewPaymentMethod () =
    asyncResult {
        let options = 
            PaymentMethods.CreateOptions.New(
                card = Choice1Of2 defaultCard,
                type' = PaymentMethods.Create'Type.Card
            )
        return! PaymentMethods.Create settings options
    }

let test() =
    let response =
        """
            {
              "id": "evt_*",
              "object": "event",
              "api_version": "2020-03-02",
              "created": 1612790103,
              "data": {
                "object": {
                  "id": "ch_*",
                  "object": "charge",
                  "amount": 5000,
                  "amount_captured": 5000,
                  "amount_refunded": 0,
                  "application": null,
                  "application_fee": null,
                  "application_fee_amount": null,
                  "balance_transaction": "txn_*",
                  "billing_details": {
                    "address": {
                      "city": null,
                      "country": null,
                      "line1": null,
                      "line2": null,
                      "postal_code": "SS1 2ZZ",
                      "state": null
                    },
                    "email": null,
                    "name": null,
                    "phone": null
                  },
                  "calculated_statement_descriptor": "FOL LOAN REPAYMENT",
                  "captured": true,
                  "created": 1612790102,
                  "currency": "gbp",
                  "customer": "cus_*",
                  "description": "Repayment",
                  "destination": null,
                  "dispute": null,
                  "disputed": false,
                  "failure_code": null,
                  "failure_message": null,
                  "fraud_details": {
                  },
                  "invoice": null,
                  "livemode": true,
                  "metadata": {
                    "Created": "2020-02-09 05:55:02",
                    "Customer email": "x@y.z",
                    "Customer name": "x",
                    "ItemRefId": "97a81234-595a-e911-b49e-2818781234cd",
                    "ItemReference": "68123411392",
                    "Payment n.": "123453",
                    "ReferenceNumber": "420123405882"
                  },
                  "on_behalf_of": null,
                  "order": null,
                  "outcome": {
                    "network_status": "approved_by_network",
                    "reason": null,
                    "risk_level": "normal",
                    "seller_message": "Payment complete.",
                    "type": "authorized"
                  },
                  "paid": true,
                  "payment_intent": null,
                  "payment_method": "src_*",
                  "payment_method_details": {
                    "card": {
                      "brand": "visa",
                      "checks": {
                        "address_line1_check": null,
                        "address_postal_code_check": "pass",
                        "cvc_check": null
                      },
                      "country": "GB",
                      "exp_month": 1,
                      "exp_year": 2023,
                      "fingerprint": "jA0T4567v3Er04sg",
                      "funding": "debit",
                      "installments": null,
                      "last4": "0000",
                      "network": "visa",
                      "three_d_secure": null,
                      "wallet": null
                    },
                    "type": "card"
                  },
                  "receipt_email": null,
                  "receipt_number": null,
                  "receipt_url": "https://pay.stripe.com/receipts/acct_*/ch_*/rcpt_*",
                  "refunded": false,
                  "refunds": {
                    "object": "list",
                    "data": [
                    ],
                    "has_more": false,
                    "total_count": 0,
                    "url": "/v1/charges/ch_*/refunds"
                  },
                  "review": null,
                  "shipping": null,
                  "source": {
                    "id": "src_*",
                    "object": "source",
                    "amount": null,
                    "card": {
                      "exp_month": 1,
                      "exp_year": 2023,
                      "last4": "0000",
                      "country": "GB",
                      "brand": "Visa",
                      "address_zip_check": "pass",
                      "funding": "debit",
                      "fingerprint": "jA0T4567v3Er04sg",
                      "three_d_secure": "optional",
                      "name": null,
                      "address_line1_check": null,
                      "cvc_check": null,
                      "tokenization_method": null,
                      "dynamic_last4": null
                    },
                    "client_secret": "src_client_secret_*",
                    "created": 1612790103,
                    "currency": null,
                    "customer": "cus_*",
                    "flow": "none",
                    "livemode": true,
                    "metadata": {
                    },
                    "owner": {
                      "address": {
                        "city": null,
                        "country": null,
                        "line1": null,
                        "line2": null,
                        "postal_code": "SS1 2ZZ",
                        "state": null
                      },
                      "email": null,
                      "name": null,
                      "phone": null,
                      "verified_address": null,
                      "verified_email": null,
                      "verified_name": null,
                      "verified_phone": null
                    },
                    "statement_descriptor": null,
                    "status": "chargeable",
                    "type": "card",
                    "usage": "reusable"
                  },
                  "source_transfer": null,
                  "statement_descriptor": null,
                  "statement_descriptor_suffix": null,
                  "status": "succeeded",
                  "transfer_data": null,
                  "transfer_group": null
                }
              },
              "livemode": true,
              "pending_webhooks": 1,
              "request": {
                "id": "req_*",
                "idempotency_key": "sameoldkey"
              },
              "type": "charge.succeeded"
            }
        """
    let event = Util.deserialise<Event> response

    let eventObject = event.Data.Object |> deserialiseStripeObject

    sprintf "%A" (eventObject)

[<EntryPoint>]
let main argv =
    let result = test ()
    printfn "Test result: %s" (result)
    0
