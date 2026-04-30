namespace FunStripe

open FunStripe.AsyncResultCE
open FunStripe.WebhookSigning
open IsoTypes
open NUnit.Framework
open StripeModel
open FunStripe.StripeRequest
open System
open System.Security.Cryptography
open System.Text

module Tests =

    ///Serialise F# class
    let serialise<'a> (parameters:'a) =
        typeof<'a>.GetProperties()
        |> Seq.collect (fun pi -> Util.format pi parameters)

    let settings = RestApi.StripeApiSettings.New(apiKey = Config.StripeTestApiKey)

    [<TestFixture>]
    type IdempotencyKeyUnitTests () =

        [<Test>]
        member _.``test idempotency key header is included when set via New``() =
            let key = "test-idempotency-key-123"
            let settingsWithKey = RestApi.StripeApiSettings.New(apiKey = Config.StripeTestApiKey, idempotencyKey = key)
            let headers = RestApi.createHeader settingsWithKey
            Assert.That(headers |> List.exists (fun (name, value) -> name = "Idempotency-Key" && value = key), Is.True)

        [<Test>]
        member _.``test idempotency key header is not included when not set``() =
            let settingsWithoutKey = RestApi.StripeApiSettings.New(apiKey = Config.StripeTestApiKey)
            let headers = RestApi.createHeader settingsWithoutKey
            Assert.That(headers |> List.exists (fun (name, _) -> name = "Idempotency-Key"), Is.False)

        [<Test>]
        member _.``test WithIdempotencyKey returns settings with key applied``() =
            let key = "per-request-idempotency-key"
            let settingsWithKey = settings.WithIdempotencyKey(key)
            Assert.That(settingsWithKey.IdempotencyKey, Is.EqualTo (Some key))

        [<Test>]
        member _.``test WithIdempotencyKey does not mutate original settings``() =
            let key = "per-request-idempotency-key"
            let _ = settings.WithIdempotencyKey(key)
            Assert.That(settings.IdempotencyKey, Is.EqualTo None)

        [<Test>]
        member _.``test WithIdempotencyKey header is included in request headers``() =
            let key = "per-request-idempotency-key"
            let settingsWithKey = settings.WithIdempotencyKey(key)
            let headers = RestApi.createHeader settingsWithKey
            Assert.That(headers |> List.exists (fun (name, value) -> name = "Idempotency-Key" && value = key), Is.True)

        [<Test>]
        member _.``test WithIdempotencyKey throws on empty key``() =
            Assert.Throws<System.ArgumentException>(fun () -> settings.WithIdempotencyKey("") |> ignore) |> ignore

        [<Test>]
        member _.``test WithIdempotencyKey throws on whitespace key``() =
            Assert.Throws<System.ArgumentException>(fun () -> settings.WithIdempotencyKey("   ") |> ignore) |> ignore

    [<TestFixture>]
    type PaymentMethodUnitTests () =

        let testCustomer = "cus_HxEURwENT9MKb3"

        let getNewPaymentMethod () =
            asyncResult {
                return!
                    PaymentMethods.CreateOptions.New(
                        card = Choice2Of2 (PaymentMethods.Create'CardTokenParams.New("tok_visa")),
                        type' = PaymentMethods.Create'Type.Card
                    )
                    |> PaymentMethods.Create settings
            }

        let attachCustomer paymentMethodId =
            asyncResult {
                return!
                    PaymentMethodsAttach.AttachOptions.New(
                        customer = testCustomer,
                        paymentMethod = paymentMethodId
                    )
                    |> PaymentMethodsAttach.Attach settings
            }

        let defaultPaymentMethod =
            let address = { Address.City = None; Country = None; Line1 = None; Line2 = None; PostalCode = None; State = None }
            let billingDetails = { BillingDetails.Address = Some address; Email = None; Name = None; Phone = None; TaxId = None }
            let paymentMethodCardChecks = { PaymentMethodCardChecks.AddressLine1Check = None; AddressPostalCodeCheck = None; CvcCheck = None }
            let networks = { Networks.Available = ["Visa"]; Preferred = None }
            let threeDSecureUsage = { Supported = true }
            let paymentMethodCard =
                PaymentMethodCard.New(
                    brand = PaymentMethodCardBrand.Visa,
                    checks = Some paymentMethodCardChecks,
                    country = Some IsoCountryCode.US,
                    displayBrand = None,
                    expMonth = 10,
                    expYear = 2027,
                    fingerprint = Some "YfQddCBRsntX6npu",
                    funding = PaymentMethodCardFunding.Credit,
                    generatedFrom = None,
                    last4 = "4242",
                    networks = Some networks,
                    regulatedStatus = None,
                    threeDSecureUsage = Some threeDSecureUsage,
                    wallet = None
                )
            let paymentMethod =
                PaymentMethod.New(
                    billingDetails = billingDetails,
                    card = paymentMethodCard,
                    created = DateTime(2020, 10, 30, 16, 35, 0),
                    customer = None,
                    customerAccount = None,
                    id = "IgnoreThisId",
                    livemode = false,
                    metadata = Some Map.empty,
                    ``type`` = PaymentMethodType.Card
                )
            paymentMethod

        [<Test>]
        member _.``test JSON to x-www-form-urlencoded conversion``() =
            let expected =
                seq {
                    "type", "card"
                    "card[token]", "tok_visa"
                }
                |> Seq.sortBy fst
            let actual = 
                PaymentMethods.CreateOptions.New(
                    card = Choice2Of2 (PaymentMethods.Create'CardTokenParams.New("tok_visa")),
                    type' = PaymentMethods.Create'Type.Card
                )
                |> serialise
                |> Seq.sortBy fst
            Assert.That(expected, Is.EqualTo<(string * string) seq> actual)

        [<Test>]
        member _.``test payment method creation``() =
            let result =
                asyncResult {
                    let expected = defaultPaymentMethod
                    let! actual = getNewPaymentMethod()
                    return expected, actual
                }
                |> Async.RunSynchronously
            match result with
            | Ok (exp, act) ->
                Assert.Multiple(fun () ->
                    Assert.That(exp.BillingDetails, Is.EqualTo act.BillingDetails)
                    Assert.That(exp.Customer, Is.EqualTo act.Customer)
                    Assert.That(exp.Livemode, Is.EqualTo act.Livemode)
                    Assert.That(exp.Metadata, Is.EqualTo act.Metadata)
                    Assert.That(exp.Type, Is.EqualTo act.Type)
                )
            | Error e ->
                Assert.That("<ErrorMessage>", Is.EqualTo e.StripeError.Message)

        [<Test>]
        member _.``test payment method retrieval``() =
            let result =
                asyncResult {
                    let! expected = getNewPaymentMethod()
                    let! actual =
                        let queryParameters = PaymentMethods.RetrieveOptions.New(paymentMethod = expected.Id, expand = [nameof(Customer) |> Util.snakeCase])
                        PaymentMethods.Retrieve settings queryParameters
                    return expected, actual

                }
                |> Async.RunSynchronously
            match result with
            | Ok (exp, act) ->
                Assert.That(exp, Is.EqualTo act)
            | Error e ->
                Assert.That("<ErrorMessage>", Is.EqualTo e.StripeError.Message)

        [<Test>]
        member _.``test payment method update``() =
            let result =
                asyncResult {
                    let! expected = getNewPaymentMethod()
                    let! newPM = attachCustomer expected.Id
                    let! actual =
                        let options =
                            PaymentMethods.UpdateOptions.New(
                                metadata = ([("OrderId", "6735")] |> Map.ofList),
                                paymentMethod = newPM.Id
                            )
                        PaymentMethods.Update settings options
                    return expected, newPM, actual
                }
                |> Async.RunSynchronously
            match result with
            | Ok (exp, pm, act) ->
                Assert.Multiple(fun () ->
                    Assert.That(testCustomer |> StripeId |> Some, Is.EqualTo act.Customer)
                    Assert.That(pm.Id, Is.EqualTo act.Id)
                    Assert.That([("OrderId", "6735")] |> Map.ofList |> Some, Is.EqualTo act.Metadata)
                )
            | Error e ->
                Assert.That("<ErrorMessage>", Is.EqualTo e.StripeError.Message)

        [<Test>]
        member _.``test attaching customer to payment method``() =
            let result =
                asyncResult {
                    let! expected = getNewPaymentMethod()
                    let! actual =
                        let options =
                            PaymentMethodsAttach.AttachOptions.New(
                                customer = testCustomer,
                                paymentMethod = expected.Id
                            )
                        PaymentMethodsAttach.Attach settings options
                    return expected, actual
                }
                |> Async.RunSynchronously
            match result with
            | Ok (exp, act) ->
                Assert.Multiple(fun () ->
                    Assert.That(testCustomer |> StripeId |> Some, Is.EqualTo act.Customer)
                    Assert.That(exp.Id, Is.EqualTo act.Id)
                )
            | Error e ->
                Assert.That("<ErrorMessage>", Is.EqualTo e.StripeError.Message)

        [<Test>]
        member _.``test detaching customer from payment method``() =
            let result =
                asyncResult {
                    let! expected = getNewPaymentMethod()
                    let! newPM = attachCustomer expected.Id
                    let! actual =
                        let options =
                            PaymentMethodsDetach.DetachOptions.New(
                                paymentMethod = newPM.Id
                            )
                        PaymentMethodsDetach.Detach settings options
                    return expected, actual
                }
                |> Async.RunSynchronously
            match result with
            | Ok (exp, act) ->
                Assert.Multiple(fun () ->
                    Assert.That(None, Is.EqualTo act.Customer)
                    Assert.That(exp.Id, Is.EqualTo act.Id)
                )
            | Error e ->
                Assert.That("<ErrorMessage>", Is.EqualTo e.StripeError.Message)

        [<Test>]
        member _.``test parsing customer object``() =
            let expected =
                {
                    Address = None
                    Balance = Some 0
                    BusinessName = None
                    CashBalance = None
                    Created = DateTime(2021, 1, 6, 10, 42, 3)
                    Currency = None
                    CustomerAccount = None
                    DefaultSource = Some (StripeId "card_1I6ZSoGXSUku3vEhr04df95L" : StripeId<Markers.PaymentSource>)
                    Delinquent = Some false
                    Description = Some "KEITH LILY"
                    Discount = None
                    Email = Some "KEITH_2614@mailinator.com"
                    Id = "cus_IhzR2Msjq0lILS"
                    IndividualName = None
                    InvoiceCreditBalance = None
                    InvoicePrefix = Some "12F15AC4"
                    InvoiceSettings =
                        Some {
                            CustomFields = None
                            DefaultPaymentMethod = None
                            Footer = None
                            RenderingOptions = None
                        }
                    Livemode = false
                    Metadata = Some (Map.empty)
                    Name = None
                    NextInvoiceSequence = Some 1
                    Phone = None
                    PreferredLocales = Some []
                    Shipping = None
                    Sources =
                        Some {
                            Data = [
                                PaymentSource.Card (
                                    Card.New (
                                        id = "card_1I6ZSoGXSUku3vEhr04df95L",
                                        addressCity =  None,
                                        addressCountry =  None,
                                        addressLine1 =  None,
                                        addressLine1Check =  None,
                                        addressLine2 =  None,
                                        addressState =  None,
                                        addressZip =  None,
                                        addressZipCheck =  None,
                                        brand = CardBrand.Visa,
                                        country = Some IsoCountryCode.US,
                                        customer = Some (CardCustomer'AnyOf.String "cus_IhzR2Msjq0lILS"),
                                        cvcCheck = Some (CardCvcCheck.Pass),
                                        dynamicLast4 =  None,
                                        expMonth = 10,
                                        expYear = 2027,
                                        fingerprint = Some "YfQddCBRsntX6npu",
                                        funding = CardFunding.Credit,
                                        last4 = "4242",
                                        metadata = Some (Map.empty),
                                        name =  None,
                                        regulatedStatus = None,
                                        tokenizationMethod =  None
                                    )
                                )
                            ]
                            HasMore = false
                            Url = "/v1/customers/cus_IhzR2Msjq0lILS/sources"
                        }
                    Subscriptions =
                        Some {
                            Data = []
                            HasMore = false
                            Url = "/v1/customers/cus_IhzR2Msjq0lILS/subscriptions"
                        }
                    Tax = None
                    TaxExempt = Some (CustomerTaxExempt.None')
                    TaxIds =
                        Some {
                            Data = []
                            HasMore = false
                            Url = "/v1/customers/cus_IhzR2Msjq0lILS/tax_ids"
                        }
                    TestClock = None
                }
            let response = """
                {
                  "id": "cus_IhzR2Msjq0lILS",
                  "object": "customer",
                  "address": null,
                  "balance": 0,
                  "created": 1609929723,
                  "currency": null,
                  "default_source": "card_1I6ZSoGXSUku3vEhr04df95L",
                  "delinquent": false,
                  "description": "KEITH LILY",
                  "discount": null,
                  "email": "KEITH_2614@mailinator.com",
                  "invoice_prefix": "12F15AC4",
                  "invoice_settings": {
                    "custom_fields": null,
                    "default_payment_method": null,
                    "footer": null
                  },
                  "livemode": false,
                  "metadata": {
                  },
                  "name": null,
                  "next_invoice_sequence": 1,
                  "phone": null,
                  "preferred_locales": [
                  ],
                  "shipping": null,
                  "sources": {
                    "object": "list",
                    "data": [
                      {
                        "id": "card_1I6ZSoGXSUku3vEhr04df95L",
                        "object": "card",
                        "address_city": null,
                        "address_country": null,
                        "address_line1": null,
                        "address_line1_check": null,
                        "address_line2": null,
                        "address_state": null,
                        "address_zip": null,
                        "address_zip_check": null,
                        "brand": "Visa",
                        "country": "US",
                        "customer": "cus_IhzR2Msjq0lILS",
                        "cvc_check": "pass",
                        "dynamic_last4": null,
                        "exp_month": 10,
                        "exp_year": 2027,
                        "fingerprint": "YfQddCBRsntX6npu",
                        "funding": "credit",
                        "last4": "4242",
                        "metadata": {
                        },
                        "name": null,
                        "tokenization_method": null
                      }
                    ],
                    "has_more": false,
                    "total_count": 1,
                    "url": "/v1/customers/cus_IhzR2Msjq0lILS/sources"
                  },
                  "subscriptions": {
                    "object": "list",
                    "data": [
                    ],
                    "has_more": false,
                    "total_count": 0,
                    "url": "/v1/customers/cus_IhzR2Msjq0lILS/subscriptions"
                  },
                  "tax_exempt": "none",
                  "tax_ids": {
                    "object": "list",
                    "data": [
                    ],
                    "has_more": false,
                    "total_count": 0,
                    "url": "/v1/customers/cus_IhzR2Msjq0lILS/tax_ids"
                  }
                }
            """
            let actual = Util.deserialise<Customer> response
            Assert.That(expected, Is.EqualTo actual)

    [<TestFixture>]
    type WebhookSigningTests () =

        let secret = "whsec_test_secret"
        let rawBody = """{"id":"evt_test","object":"event"}"""

        ///Build a valid Stripe-Signature header for the given timestamp
        let buildHeader (secret: string) (rawBody: string) (timestamp: int64) =
            let signedPayload = sprintf "%d.%s" timestamp rawBody
            let keyBytes = Encoding.UTF8.GetBytes(secret)
            let payloadBytes = Encoding.UTF8.GetBytes(signedPayload)
            use hmac = new HMACSHA256(keyBytes)
            let sig' =
                hmac.ComputeHash(payloadBytes)
                |> Array.map (fun b -> b.ToString("x2"))
                |> String.concat ""
            sprintf "t=%d,v1=%s" timestamp sig'

        [<Test>]
        member _.``valid signature returns Ok``() =
            let timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            let header = buildHeader secret rawBody timestamp
            let result = verifySignature secret rawBody header defaultTolerance
            match result with
            | Ok () -> Assert.Pass()
            | Error e -> Assert.Fail(sprintf "Expected Ok but got Error %A" e)

        [<Test>]
        member _.``signature with multiple v1 entries accepts correct one``() =
            let timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            let validHeader = buildHeader secret rawBody timestamp
            // Append a second (wrong) v1 entry after the valid one
            let headerWithExtra = validHeader + ",v1=aabbccddeeff"
            let result = verifySignature secret rawBody headerWithExtra defaultTolerance
            match result with
            | Ok () -> Assert.Pass()
            | Error e -> Assert.Fail(sprintf "Expected Ok but got Error %A" e)

        [<Test>]
        member _.``signature with invalid v1 entry before valid one accepts correct one``() =
            let timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            let validHeader = buildHeader secret rawBody timestamp
            // Prepend a wrong v1 entry before the valid one (e.g. "t=...,v1=bad,v1=good")
            let parts = validHeader.Split(',')
            let headerWithExtraFirst = sprintf "%s,v1=aabbccddeeff,%s" parts.[0] parts.[1]
            let result = verifySignature secret rawBody headerWithExtraFirst defaultTolerance
            match result with
            | Ok () -> Assert.Pass()
            | Error e -> Assert.Fail(sprintf "Expected Ok but got Error %A" e)

        [<Test>]
        member _.``timestamp outside tolerance returns TimestampOutOfTolerance``() =
            let oldTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 600L
            let header = buildHeader secret rawBody oldTimestamp
            let result = verifySignature secret rawBody header defaultTolerance
            match result with
            | Error (TimestampOutOfTolerance _) -> Assert.Pass()
            | other -> Assert.Fail(sprintf "Expected TimestampOutOfTolerance but got %A" other)

        [<Test>]
        member _.``wrong signature returns SignatureMismatch``() =
            let timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            let header = sprintf "t=%d,v1=%s" timestamp (String.replicate 64 "0")
            let result = verifySignature secret rawBody header defaultTolerance
            match result with
            | Error (SignatureMismatch _) -> Assert.Pass()
            | other -> Assert.Fail(sprintf "Expected SignatureMismatch but got %A" other)

        [<Test>]
        member _.``missing timestamp returns InvalidHeader``() =
            let header = "v1=aabbccddeeff"
            let result = verifySignature secret rawBody header defaultTolerance
            match result with
            | Error (InvalidHeader _) -> Assert.Pass()
            | other -> Assert.Fail(sprintf "Expected InvalidHeader but got %A" other)

        [<Test>]
        member _.``missing v1 signature returns InvalidHeader``() =
            let timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            let header = sprintf "t=%d" timestamp
            let result = verifySignature secret rawBody header defaultTolerance
            match result with
            | Error (InvalidHeader _) -> Assert.Pass()
            | other -> Assert.Fail(sprintf "Expected InvalidHeader but got %A" other)

        [<Test>]
        member _.``malformed header returns InvalidHeader``() =
            let result = verifySignature secret rawBody "not-a-valid-header" defaultTolerance
            match result with
            | Error (InvalidHeader _) -> Assert.Pass()
            | other -> Assert.Fail(sprintf "Expected InvalidHeader but got %A" other)

        [<Test>]
        member _.``test parsing customer object with expanded default_source``() =
            let expectedCard =
                Card.New (
                    id = "card_1I6ZSoGXSUku3vEhr04df95L",
                    addressCity =  None,
                    addressCountry =  None,
                    addressLine1 =  None,
                    addressLine1Check =  None,
                    addressLine2 =  None,
                    addressState =  None,
                    addressZip =  None,
                    addressZipCheck =  None,
                    brand = CardBrand.Visa,
                    country = Some IsoCountryCode.US,
                    customer = Some (CardCustomer'AnyOf.String "cus_IhzR2Msjq0lILS"),
                    cvcCheck = Some (CardCvcCheck.Pass),
                    dynamicLast4 =  None,
                    expMonth = 10,
                    expYear = 2027,
                    fingerprint = Some "YfQddCBRsntX6npu",
                    funding = CardFunding.Credit,
                    last4 = "4242",
                    metadata = Some (Map.empty),
                    name =  None,
                    regulatedStatus = None,
                    tokenizationMethod =  None
                )
            let response = """
                {
                  "id": "cus_IhzR2Msjq0lILS",
                  "object": "customer",
                  "address": null,
                  "balance": 0,
                  "created": 1609929723,
                  "currency": null,
                  "default_source": {
                    "id": "card_1I6ZSoGXSUku3vEhr04df95L",
                    "object": "card",
                    "address_city": null,
                    "address_country": null,
                    "address_line1": null,
                    "address_line1_check": null,
                    "address_line2": null,
                    "address_state": null,
                    "address_zip": null,
                    "address_zip_check": null,
                    "brand": "Visa",
                    "country": "US",
                    "customer": "cus_IhzR2Msjq0lILS",
                    "cvc_check": "pass",
                    "dynamic_last4": null,
                    "exp_month": 10,
                    "exp_year": 2027,
                    "fingerprint": "YfQddCBRsntX6npu",
                    "funding": "credit",
                    "last4": "4242",
                    "metadata": {},
                    "name": null,
                    "tokenization_method": null
                  },
                  "delinquent": false,
                  "description": "KEITH LILY",
                  "discount": null,
                  "email": "KEITH_2614@mailinator.com",
                  "invoice_prefix": "12F15AC4",
                  "invoice_settings": {
                    "custom_fields": null,
                    "default_payment_method": null,
                    "footer": null
                  },
                  "livemode": false,
                  "metadata": {},
                  "name": null,
                  "next_invoice_sequence": 1,
                  "phone": null,
                  "preferred_locales": [],
                  "shipping": null,
                  "sources": {
                    "object": "list",
                    "data": [],
                    "has_more": false,
                    "total_count": 0,
                    "url": "/v1/customers/cus_IhzR2Msjq0lILS/sources"
                  },
                  "subscriptions": {
                    "object": "list",
                    "data": [],
                    "has_more": false,
                    "total_count": 0,
                    "url": "/v1/customers/cus_IhzR2Msjq0lILS/subscriptions"
                  },
                  "tax_exempt": "none",
                  "tax_ids": {
                    "object": "list",
                    "data": [],
                    "has_more": false,
                    "total_count": 0,
                    "url": "/v1/customers/cus_IhzR2Msjq0lILS/tax_ids"
                  }
                }
            """
            let actual = Util.deserialise<Customer> response
            Assert.That(Some (StripeId "card_1I6ZSoGXSUku3vEhr04df95L" : StripeId<Markers.PaymentSource>), Is.EqualTo actual.DefaultSource)

        [<Test>]
        member _.``test expand values are not transformed in form parameters``() =
            let expected =
                seq {
                    "expand[0]", "default_source"
                    "expand[1]", "latest_charge"
                }
                |> Seq.sortBy fst
            let actual =
                Customers.CreateOptions.New(
                    expand = ["default_source"; "latest_charge"]
                )
                |> serialise
                |> Seq.filter (fun (k, _) -> k.StartsWith "expand")
                |> Seq.sortBy fst
            Assert.That(expected, Is.EqualTo<(string * string) seq> actual)
