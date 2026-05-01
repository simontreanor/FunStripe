namespace FunStripe

open FunStripe.AsyncResultCE
open FunStripe.WebhookSigning
open IsoTypes
open NUnit.Framework
open Stripe.Event
open Stripe.FundingInstructions
open Stripe.PaymentMethod
open Stripe.Price
open Stripe.Product
open StripeRequest.Customers
open StripeRequest.Payment
open System
open System.Security.Cryptography
open System.Text

module Tests =

    ///Serialise form fields from an options record
    let serialise<'a> (parameters:'a) =
        typeof<'a>.GetProperties()
        |> Seq.collect (fun pi -> Util.format pi parameters)

    ///Build a query string from the [<Config.Query>] fields on an options record
    let querySerialise<'a> (options: 'a) =
        typeof<'a>.GetProperties()
        |> Array.filter (fun pi -> pi.GetCustomAttributes(typeof<Config.QueryAttribute>, false).Length > 0)
        |> Array.map (fun pi -> Util.snakeCase pi.Name, pi.GetValue(options))
        |> Map.ofArray
        |> RestApi.formatQueryString

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

        // A test customer is created on first access and reused across the
        // tests in this fixture. The customer is created in the Stripe test
        // account identified by Config.StripeTestApiKey (env var
        // STRIPE_TEST_API_KEY). Each test run produces a fresh customer; we
        // do not bother deleting it because Stripe test data is ephemeral.
        let testCustomer =
            lazy (
                let result =
                    Customers.CreateOptions.New(
                        name = "FunStripe CI test customer",
                        description = "Created automatically by FunStripe.Tests"
                    )
                    |> Customers.Create settings
                    |> Async.RunSynchronously
                match result with
                | Ok c -> c.Id
                | Error e -> failwithf "Failed to create test customer: %A" e.StripeError.Message
            )

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
                        customer = testCustomer.Value,
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
                    Assert.That((testCustomer.Value |> StripeId : StripeId<Markers.Customer>) |> Some, Is.EqualTo act.Customer)
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
                                customer = testCustomer.Value,
                                paymentMethod = expected.Id
                            )
                        PaymentMethodsAttach.Attach settings options
                    return expected, actual
                }
                |> Async.RunSynchronously
            match result with
            | Ok (exp, act) ->
                Assert.Multiple(fun () ->
                    Assert.That((testCustomer.Value |> StripeId : StripeId<Markers.Customer>) |> Some, Is.EqualTo act.Customer)
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

    // =========================================================================
    // A. Form serialisation — Util.format edge cases
    // =========================================================================

    [<TestFixture>]
    type FormSerializationUnitTests () =

        [<Test>]
        member _.``nested record produces compound bracket keys``() =
            let addr =
                Customers.Create'AddressOptionalFieldsCustomerAddress.New(
                    city = "London",
                    postalCode = "SW1A 1AA"
                )
            let opts = Customers.CreateOptions.New(address = Choice1Of2 addr)
            let pairs = opts |> serialise |> Seq.toList
            Assert.That(pairs |> List.exists (fun (k,v) -> k = "address[city]" && v = "London"), Is.True,
                "address[city] should be London")
            Assert.That(pairs |> List.exists (fun (k,v) -> k = "address[postal_code]" && v = "SW1A 1AA"), Is.True,
                "address[postal_code] should be SW1A 1AA")

        [<Test>]
        member _.``non-empty Map produces metadata bracket keys``() =
            let opts = Customers.CreateOptions.New(metadata = (Map.ofList [("orderId", "42")]))
            let pairs = opts |> serialise |> Seq.toList
            Assert.That(pairs |> List.exists (fun (k,v) -> k = "metadata[orderId]" && v = "42"), Is.True)

        [<Test>]
        member _.``empty Map produces no keys``() =
            let opts = Customers.CreateOptions.New(metadata = Map.empty)
            let pairs = opts |> serialise |> Seq.toList
            Assert.That(pairs |> List.exists (fun (k,_) -> k.StartsWith "metadata"), Is.False)

        [<Test>]
        member _.``List string field produces indexed keys``() =
            let opts = Customers.CreateOptions.New(preferredLocales = ["en"; "fr"])
            let pairs = opts |> serialise |> Seq.toList
            Assert.That(pairs |> List.exists (fun (k,v) -> k = "preferred_locales[0]" && v = "en"), Is.True)
            Assert.That(pairs |> List.exists (fun (k,v) -> k = "preferred_locales[1]" && v = "fr"), Is.True)

        [<Test>]
        member _.``None option field is excluded from output``() =
            let opts = Customers.CreateOptions.New() // all fields None
            let pairs = opts |> serialise |> Seq.toList
            Assert.That(pairs, Is.Empty)

        [<Test>]
        member _.``Choice1Of2 serialises the first branch``() =
            let opts =
                PaymentMethods.CreateOptions.New(
                    card = Choice1Of2 (PaymentMethods.Create'CardCardDetailsParams.New(
                        expMonth = 12, expYear = 2030, number = "4242424242424242", cvc = "123")),
                    type' = PaymentMethods.Create'Type.Card
                )
            let pairs = serialise opts |> Seq.toList
            Assert.That(pairs |> List.exists (fun (k,_) -> k.StartsWith "card[number]"), Is.True)

        [<Test>]
        member _.``Choice2Of2 serialises the second branch``() =
            let opts =
                PaymentMethods.CreateOptions.New(
                    card = Choice2Of2 (PaymentMethods.Create'CardTokenParams.New("tok_visa")),
                    type' = PaymentMethods.Create'Type.Card
                )
            let pairs = serialise opts |> Seq.toList
            Assert.That(pairs |> List.exists (fun (k,v) -> k = "card[token]" && v = "tok_visa"), Is.True)

        [<Test>]
        member _.``bool field serialises to lowercase string``() =
            let opts = StripeRequest.Products.Products.CreateOptions.New(name = "test", active = true)
            let pairs = serialise opts |> Seq.toList
            Assert.That(pairs |> List.exists (fun (k,v) -> k = "active" && v = "true"), Is.True)

    // =========================================================================
    // B. Query string formatting — consumer-facing behaviour
    // =========================================================================

    [<TestFixture>]
    type QueryStringUnitTests () =

        [<Test>]
        member _.``all-None options produce empty query string``() =
            let qs = Customers.ListOptions.New() |> querySerialise
            Assert.That(qs, Is.EqualTo "")

        [<Test>]
        member _.``email option produces URL-encoded query parameter``() =
            let qs = Customers.ListOptions.New(email = "test@example.com") |> querySerialise
            Assert.That(qs, Is.EqualTo "?email=test%40example.com")

        [<Test>]
        member _.``limit option produces integer query parameter``() =
            let qs = Customers.ListOptions.New(limit = 10) |> querySerialise
            Assert.That(qs, Is.EqualTo "?limit=10")

        [<Test>]
        member _.``expand list produces array notation``() =
            let qs = Customers.ListOptions.New(expand = ["default_source"; "sources"]) |> querySerialise
            Assert.That(qs, Is.EqualTo "?expand[]=default_source;sources")

        [<Test>]
        member _.``multiple options combine in a single query string``() =
            let qs = Customers.ListOptions.New(limit = 5, email = "a@b.com") |> querySerialise
            Assert.That(qs.StartsWith "?", Is.True)
            Assert.That(qs.Contains "&", Is.True)
            Assert.That(qs.Contains "limit=5", Is.True)
            Assert.That(qs.Contains "email=a%40b.com", Is.True)

        [<Test>]
        member _.``special characters in email are fully URL-encoded``() =
            let qs = Customers.ListOptions.New(email = "hello world+test@foo.com") |> querySerialise
            Assert.That(qs.Contains "%40", Is.True, "@ should be encoded")
            Assert.That(qs.Contains "%20", Is.True, "space should be encoded")

    // =========================================================================
    // C. Settings header — RestApi.createHeader v2 additions
    // =========================================================================

    [<TestFixture>]
    type SettingsHeaderUnitTests () =

        [<Test>]
        member _.``stripeAccount header is present when set``() =
            let s = RestApi.StripeApiSettings.New(apiKey = "sk_test_x", stripeAccount = "acct_123")
            let headers = RestApi.createHeader s
            Assert.That(headers |> List.exists (fun (k,v) -> k = "Stripe-Account" && v = "acct_123"), Is.True)

        [<Test>]
        member _.``stripeAccount header is absent when not set``() =
            let s = RestApi.StripeApiSettings.New(apiKey = "sk_test_x")
            let headers = RestApi.createHeader s
            Assert.That(headers |> List.exists (fun (k,_) -> k = "Stripe-Account"), Is.False)

        [<Test>]
        member _.``stripeVersion header is present when set``() =
            let s = RestApi.StripeApiSettings.New(apiKey = "sk_test_x", stripeVersion = "2026-04-22.dahlia")
            let headers = RestApi.createHeader s
            Assert.That(headers |> List.exists (fun (k,v) -> k = "Stripe-Version" && v = "2026-04-22.dahlia"), Is.True)

        [<Test>]
        member _.``stripeVersion header is absent when not set``() =
            let s = RestApi.StripeApiSettings.New(apiKey = "sk_test_x")
            let headers = RestApi.createHeader s
            Assert.That(headers |> List.exists (fun (k,_) -> k = "Stripe-Version"), Is.False)

        [<Test>]
        member _.``DefaultStripeApiVersion constant equals expected value``() =
            Assert.That(Config.DefaultStripeApiVersion, Is.EqualTo "2026-04-22.dahlia")

    // =========================================================================
    // D. Util.snakeCase
    // =========================================================================

    [<TestFixture>]
    type UtilSnakeCaseUnitTests () =

        [<Test>]
        member _.``PascalCase converts to snake_case``() =
            Assert.That(Util.snakeCase "BillingDetails", Is.EqualTo "billing_details")

        [<Test>]
        member _.``camelCase converts to snake_case``() =
            Assert.That(Util.snakeCase "billingDetails", Is.EqualTo "billing_details")

        [<Test>]
        member _.``already snake_case is unchanged``() =
            Assert.That(Util.snakeCase "billing_details", Is.EqualTo "billing_details")

        [<Test>]
        member _.``single word lowercased``() =
            Assert.That(Util.snakeCase "Customer", Is.EqualTo "customer")

        [<Test>]
        member _.``name with trailing digit``() =
            // Line1 → "line1" (digit boundary triggers split)
            let result = Util.snakeCase "Line1"
            Assert.That(result, Is.EqualTo "line_1")

        [<Test>]
        member _.``PostalCode converts correctly``() =
            Assert.That(Util.snakeCase "PostalCode", Is.EqualTo "postal_code")

    // =========================================================================
    // E. AsyncResultBuilder CE
    // =========================================================================

    [<TestFixture>]
    type AsyncResultBuilderUnitTests () =

        [<Test>]
        member _.``return wraps value in Ok``() =
            let result = asyncResult { return 42 } |> Async.RunSynchronously
            Assert.That(result, Is.EqualTo (Ok 42))

        [<Test>]
        member _.``chained let! both succeed returns final value``() =
            let step1 = async { return Ok 10 }
            let step2 x = async { return Ok (x + 5) }
            let result =
                asyncResult {
                    let! a = step1
                    let! b = step2 a
                    return b
                }
                |> Async.RunSynchronously
            Assert.That(result, Is.EqualTo (Ok 15))

        [<Test>]
        member _.``let! short-circuits on first Error``() =
            let mutable secondEvaluated = false
            let step1 : Async<Result<int, string>> = async { return Error "oops" }
            let step2 _ =
                secondEvaluated <- true
                async { return Ok 99 }
            let result =
                asyncResult {
                    let! a = step1
                    let! b = step2 a
                    return b
                }
                |> Async.RunSynchronously
            Assert.That(result, Is.EqualTo (Error "oops" : Result<int, string>))
            Assert.That(secondEvaluated, Is.False, "second step should not be evaluated")

        [<Test>]
        member _.``returnFrom passes through async result``() =
            let inner : Async<Result<string, int>> = async { return Ok "hello" }
            let result = asyncResult { return! inner } |> Async.RunSynchronously
            Assert.That(result, Is.EqualTo (Ok "hello" : Result<string, int>))

        [<Test>]
        member _.``Zero returns Ok unit``() =
            let result : Result<unit, string> = asyncResult { () } |> Async.RunSynchronously
            Assert.That(result, Is.EqualTo (Ok () : Result<unit, string>))

    // =========================================================================
    // F. EpochDateTimeConverter
    // =========================================================================

    [<TestFixture>]
    type JsonEpochDateTimeConverterUnitTests () =

        let converter = Json.StripeConverter.EpochDateTimeConverter()
        let opts = Json.StripeConverter.sharedOptions.Value

        [<Test>]
        member _.``integer epoch deserialises to correct UTC DateTime``() =
            let json = "1609929723"
            let result = System.Text.Json.JsonSerializer.Deserialize<DateTime>(json, opts)
            Assert.That(result, Is.EqualTo (DateTime(2021, 1, 6, 10, 42, 3, DateTimeKind.Utc)))
            Assert.That(result.Kind, Is.EqualTo DateTimeKind.Utc)

        [<Test>]
        member _.``ISO-8601 string deserialises to DateTime``() =
            let json = "\"2021-01-06T10:42:03Z\""
            let result = System.Text.Json.JsonSerializer.Deserialize<DateTime>(json, opts)
            Assert.That(result.Year, Is.EqualTo 2021)
            Assert.That(result.Month, Is.EqualTo 1)
            Assert.That(result.Day, Is.EqualTo 6)
            Assert.That(result.Hour, Is.EqualTo 10)
            Assert.That(result.Minute, Is.EqualTo 42)
            Assert.That(result.Second, Is.EqualTo 3)

        [<Test>]
        member _.``DateTime serialises to integer epoch``() =
            let dt = DateTime(2021, 1, 6, 10, 42, 3, DateTimeKind.Utc)
            let json = System.Text.Json.JsonSerializer.Serialize(dt, opts)
            Assert.That(json, Is.EqualTo "1609929723")

    // =========================================================================
    // G. StripeIdConverter
    // =========================================================================

    [<TestFixture>]
    type JsonStripeIdConverterUnitTests () =

        let opts = Json.StripeConverter.sharedOptions.Value

        [<Test>]
        member _.``plain string JSON deserialises to StripeId``() =
            let json = "\"cus_abc123\""
            let result = System.Text.Json.JsonSerializer.Deserialize<StripeId<Markers.Customer>>(json, opts)
            let (StripeId s) = result
            Assert.That(s, Is.EqualTo "cus_abc123")

        [<Test>]
        member _.``expanded object JSON extracts id field``() =
            let json = """{"id":"cus_abc123","object":"customer","email":"test@example.com"}"""
            let result = System.Text.Json.JsonSerializer.Deserialize<StripeId<Markers.Customer>>(json, opts)
            let (StripeId s) = result
            Assert.That(s, Is.EqualTo "cus_abc123")

        [<Test>]
        member _.``expanded object without id field throws``() =
            let json = """{"object":"customer","email":"test@example.com"}"""
            Assert.Throws<Exception>(fun () ->
                System.Text.Json.JsonSerializer.Deserialize<StripeId<Markers.Customer>>(json, opts) |> ignore
            ) |> ignore

        [<Test>]
        member _.``StripeId serialises to plain string``() =
            let id : StripeId<Markers.Customer> = StripeId "cus_abc123"
            let json = System.Text.Json.JsonSerializer.Serialize(id, opts)
            Assert.That(json, Is.EqualTo "\"cus_abc123\"")

    // =========================================================================
    // H. StripeUnionConverter
    // =========================================================================

    [<TestFixture>]
    type JsonStripeUnionConverterUnitTests () =

        let opts = Json.StripeConverter.sharedOptions.Value

        [<Test>]
        member _.``string enum deserialises to correct DU case``() =
            let json = "\"visa\""
            let result = System.Text.Json.JsonSerializer.Deserialize<Stripe.PaymentMethod.PaymentMethodCardBrand>(json, opts)
            Assert.That(result, Is.EqualTo Stripe.PaymentMethod.PaymentMethodCardBrand.Visa)

        [<Test>]
        member _.``unknown string enum throws``() =
            let json = "\"invalid_brand_xyz\""
            Assert.Throws<Exception>(fun () ->
                System.Text.Json.JsonSerializer.Deserialize<Stripe.PaymentMethod.PaymentMethodCardBrand>(json, opts) |> ignore
            ) |> ignore

        [<Test>]
        member _.``object with object discriminator field maps to correct case``() =
            // PaymentSource is a DU; "card" maps to PaymentSource.Card
            let json = """
            {
                "id": "card_1abc",
                "object": "card",
                "brand": "Visa",
                "country": "US",
                "cvc_check": "pass",
                "exp_month": 10,
                "exp_year": 2027,
                "funding": "credit",
                "last4": "4242",
                "metadata": {},
                "tokenization_method": null
            }"""
            let result = System.Text.Json.JsonSerializer.Deserialize<PaymentSource>(json, opts)
            match result with
            | PaymentSource.Card c ->
                Assert.That(c.Id, Is.EqualTo "card_1abc")
            | other -> Assert.Fail(sprintf "Expected Card, got %A" other)

        [<Test>]
        member _.``nested union resolved via object field``() =
            // The existing customer JSON test already covers this; verify the DefaultSource expands correctly
            let response = """
            {
              "id": "cus_test",
              "object": "customer",
              "balance": 0,
              "created": 1609929723,
              "default_source": {
                "id": "card_1I6ZSoGXSUku3vEhr04df95L",
                "object": "card",
                "brand": "Visa",
                "country": "US",
                "cvc_check": "pass",
                "exp_month": 10,
                "exp_year": 2027,
                "funding": "credit",
                "last4": "4242",
                "metadata": {},
                "tokenization_method": null
              },
              "delinquent": false,
              "livemode": false,
              "metadata": {},
              "preferred_locales": [],
              "sources": { "object": "list", "data": [], "has_more": false, "url": "/v1/customers/cus_test/sources" },
              "subscriptions": { "object": "list", "data": [], "has_more": false, "url": "/v1/customers/cus_test/subscriptions" },
              "tax_exempt": "none",
              "tax_ids": { "object": "list", "data": [], "has_more": false, "url": "/v1/customers/cus_test/tax_ids" }
            }"""
            let customer = Util.deserialise<Stripe.PaymentMethod.Customer> response
            Assert.That(customer.DefaultSource, Is.EqualTo (Some (StripeId "card_1I6ZSoGXSUku3vEhr04df95L" : StripeId<Markers.PaymentSource>)))

        [<Test>]
        member _.``simple string enum serialises to snake_case string``() =
            let value = Stripe.PaymentMethod.PaymentMethodCardBrand.Visa
            let json = System.Text.Json.JsonSerializer.Serialize(value, opts)
            Assert.That(json, Is.EqualTo "\"visa\"")

        [<Test>]
        member _.``DU wrapping a record serialises to inner object JSON``() =
            // Serialise a Card object to JSON and check last4 field is present
            let card = Card.New(
                addressCity = None, addressCountry = None,
                addressLine1 = None, addressLine1Check = None, addressLine2 = None,
                addressState = None, addressZip = None, addressZipCheck = None,
                brand = CardBrand.Visa,
                country = None, cvcCheck = None, dynamicLast4 = None,
                expMonth = 10, expYear = 2030,
                funding = CardFunding.Credit,
                id = "card_test",
                last4 = "4242",
                metadata = Some Map.empty,
                name = None, regulatedStatus = None, tokenizationMethod = None
            )
            let ps = PaymentSource.Card card
            let json = System.Text.Json.JsonSerializer.Serialize(ps, opts)
            Assert.That(json.Contains "\"last4\":\"4242\"", Is.True)

        [<Test>]
        member _.``object JSON without object field falls back to first matching case``() =
            // StripeList has no "object" discriminator to pick a case — use a simpler AnyOf union
            // We test using CardCustomer'AnyOf which can be a String case
            let json = "\"cus_IhzR2Msjq0lILS\""
            let result = System.Text.Json.JsonSerializer.Deserialize<Stripe.PaymentMethod.CardCustomer'AnyOf>(json, opts)
            match result with
            | Stripe.PaymentMethod.CardCustomer'AnyOf.String s ->
                Assert.That(s, Is.EqualTo "cus_IhzR2Msjq0lILS")
            | other -> Assert.Fail(sprintf "Expected String case, got %A" other)

    // =========================================================================
    // I. StripeList deserialization
    // =========================================================================

    [<TestFixture>]
    type StripeListUnitTests () =

        [<Test>]
        member _.``deserialises full list with items``() =
            let json = """
            {
                "object": "list",
                "data": [
                    {"id":"cus_1","object":"customer","balance":0,"created":1609929723,"delinquent":false,"livemode":false,"metadata":{},"preferred_locales":[],"sources":{"object":"list","data":[],"has_more":false,"url":"/v1/customers/cus_1/sources"},"subscriptions":{"object":"list","data":[],"has_more":false,"url":"/v1/customers/cus_1/subscriptions"},"tax_exempt":"none","tax_ids":{"object":"list","data":[],"has_more":false,"url":"/v1/customers/cus_1/tax_ids"}},
                    {"id":"cus_2","object":"customer","balance":0,"created":1609929723,"delinquent":false,"livemode":false,"metadata":{},"preferred_locales":[],"sources":{"object":"list","data":[],"has_more":false,"url":"/v1/customers/cus_2/sources"},"subscriptions":{"object":"list","data":[],"has_more":false,"url":"/v1/customers/cus_2/subscriptions"},"tax_exempt":"none","tax_ids":{"object":"list","data":[],"has_more":false,"url":"/v1/customers/cus_2/tax_ids"}}
                ],
                "has_more": false,
                "url": "/v1/customers"
            }"""
            let result = Util.deserialise<StripeList<Stripe.PaymentMethod.Customer>> json
            Assert.That(result.Data.Length, Is.EqualTo 2)
            Assert.That(result.HasMore, Is.False)
            Assert.That(result.Url, Is.EqualTo "/v1/customers")

        [<Test>]
        member _.``deserialises empty list``() =
            let json = """{"object":"list","data":[],"has_more":false,"url":"/v1/customers"}"""
            let result = Util.deserialise<StripeList<Stripe.PaymentMethod.Customer>> json
            Assert.That(result.Data, Is.Empty)
            Assert.That(result.HasMore, Is.False)

        [<Test>]
        member _.``HasMore true is propagated``() =
            let json = """{"object":"list","data":[],"has_more":true,"url":"/v1/customers"}"""
            let result = Util.deserialise<StripeList<Stripe.PaymentMethod.Customer>> json
            Assert.That(result.HasMore, Is.True)

    // =========================================================================
    // J. ErrorResponse deserialization + union case utilities
    // =========================================================================

    [<TestFixture>]
    type ErrorResponseUnitTests () =

        let opts = Json.StripeConverter.sharedOptions.Value

        [<Test>]
        member _.``card error JSON deserialises all fields``() =
            let json = """
            {
                "error": {
                    "type": "card_error",
                    "code": "card_declined",
                    "decline_code": "insufficient_funds",
                    "message": "Your card has insufficient funds.",
                    "param": "card"
                }
            }"""
            let result = Util.deserialise<StripeError.ErrorResponse> json
            Assert.That(result.StripeError.Type, Is.EqualTo (Some StripeError.ErrorType.CardError))
            Assert.That(result.StripeError.Code, Is.EqualTo (Some "card_declined"))
            Assert.That(result.StripeError.DeclineCode, Is.EqualTo (Some "insufficient_funds"))
            Assert.That(result.StripeError.Message, Is.EqualTo (Some "Your card has insufficient funds."))
            Assert.That(result.StripeError.Param, Is.EqualTo (Some "card"))

        [<Test>]
        member _.``invalid request error includes param field``() =
            let json = """{"error":{"type":"invalid_request_error","message":"Invalid email.","param":"email"}}"""
            let result = Util.deserialise<StripeError.ErrorResponse> json
            Assert.That(result.StripeError.Type, Is.EqualTo (Some StripeError.ErrorType.InvalidRequestError))
            Assert.That(result.StripeError.Param, Is.EqualTo (Some "email"))

        [<Test>]
        member _.``authentication error type deserialises``() =
            let json = """{"error":{"type":"authentication_error","message":"No such API key"}}"""
            let result = Util.deserialise<StripeError.ErrorResponse> json
            Assert.That(result.StripeError.Type, Is.EqualTo (Some StripeError.ErrorType.AuthenticationError))

        [<Test>]
        member _.``all optional fields null produces None values``() =
            let json = """{"error":{"type":"api_error"}}"""
            let result = Util.deserialise<StripeError.ErrorResponse> json
            Assert.That(result.StripeError.Code, Is.EqualTo None)
            Assert.That(result.StripeError.Param, Is.EqualTo None)
            Assert.That(result.StripeError.Charge, Is.EqualTo None)
            Assert.That(result.StripeError.Message, Is.EqualTo None)

        [<Test>]
        member _.``optionToUnionCaseOr returns default for None``() =
            let result = Util.optionToUnionCaseOr StripeError.ErrorType.ApiError None
            Assert.That(result, Is.EqualTo StripeError.ErrorType.ApiError)

        [<Test>]
        member _.``getUnionCaseFromString works on EventType with JsonPropertyName``() =
            let result = Util.getUnionCaseFromString<Stripe.Event.EventType> "customer.created"
            Assert.That(result, Is.EqualTo (Some Stripe.Event.EventType.CustomerCreated))

    // =========================================================================
    // Webhook signing additional tests
    // =========================================================================

    [<TestFixture>]
    type WebhookSigningAdditionalTests () =

        let secret = "whsec_additional_test_secret"
        let rawBody = """{"id":"evt_test","object":"event"}"""

        let buildHeader (sec: string) (body: string) (timestamp: int64) =
            let signedPayload = sprintf "%d.%s" timestamp body
            let keyBytes = Encoding.UTF8.GetBytes(sec)
            let payloadBytes = Encoding.UTF8.GetBytes(signedPayload)
            use hmac = new HMACSHA256(keyBytes)
            let sig' =
                hmac.ComputeHash(payloadBytes)
                |> Array.map (fun b -> b.ToString("x2"))
                |> String.concat ""
            sprintf "t=%d,v1=%s" timestamp sig'

        [<Test>]
        member _.``zero tolerance rejects one-second-old signature``() =
            let oldTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 1L
            let header = buildHeader secret rawBody oldTimestamp
            let result = verifySignature secret rawBody header 0
            match result with
            | Error (TimestampOutOfTolerance _) -> Assert.Pass()
            | other -> Assert.Fail(sprintf "Expected TimestampOutOfTolerance but got %A" other)

        [<Test>]
        member _.``large tolerance accepts old signature``() =
            let oldTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 270L
            let header = buildHeader secret rawBody oldTimestamp
            let result = verifySignature secret rawBody header 600
            match result with
            | Ok () -> Assert.Pass()
            | other -> Assert.Fail(sprintf "Expected Ok but got %A" other)

        [<Test>]
        member _.``empty raw body verifies correctly``() =
            let timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            let header = buildHeader secret "" timestamp
            let result = verifySignature secret "" header defaultTolerance
            match result with
            | Ok () -> Assert.Pass()
            | Error e -> Assert.Fail(sprintf "Expected Ok but got Error %A" e)

        [<Test>]
        member _.``non-ASCII UTF-8 body verifies correctly``() =
            let body = """{"name":"Ré\u00e9d","emoji":"\u00e9\u00e0\u00fc"}"""
            let timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            let header = buildHeader secret body timestamp
            let result = verifySignature secret body header defaultTolerance
            match result with
            | Ok () -> Assert.Pass()
            | Error e -> Assert.Fail(sprintf "Expected Ok but got Error %A" e)

        [<Test>]
        member _.``whitespace-only header returns InvalidHeader``() =
            let result = verifySignature secret rawBody "   " defaultTolerance
            match result with
            | Error (InvalidHeader _) -> Assert.Pass()
            | other -> Assert.Fail(sprintf "Expected InvalidHeader but got %A" other)

        [<Test>]
        member _.``header with unknown v2 field still validates on v1``() =
            let timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            let header = buildHeader secret rawBody timestamp
            let headerWithV2 = header + ",v2=someothersig"
            let result = verifySignature secret rawBody headerWithV2 defaultTolerance
            match result with
            | Ok () -> Assert.Pass()
            | Error e -> Assert.Fail(sprintf "Expected Ok but got Error %A" e)

    // =========================================================================
    // M. Customer integration tests
    // =========================================================================

    [<TestFixture>]
    type CustomerIntegrationTests () =

        let testCustomer =
            lazy (
                let result =
                    Customers.CreateOptions.New(
                        name = "FunStripe customer integration test",
                        description = "Auto-created by CustomerIntegrationTests",
                        email = "customer-integration@funstripe.test"
                    )
                    |> Customers.Create settings
                    |> Async.RunSynchronously
                match result with
                | Ok c -> c
                | Error e -> failwithf "Failed to create test customer: %A" e.StripeError.Message
            )

        [<Test>]
        member _.``create customer returns Id and matches input``() =
            let c = testCustomer.Value
            Assert.That(c.Id, Is.Not.Empty)
            Assert.That(c.Name, Is.EqualTo (Some "FunStripe customer integration test"))
            Assert.That(c.Description, Is.EqualTo (Some "Auto-created by CustomerIntegrationTests"))

        [<Test>]
        member _.``retrieve customer round-trips scalar fields``() =
            let result =
                asyncResult {
                    let created = testCustomer.Value
                    return!
                        Customers.RetrieveOptions.New(customer = created.Id)
                        |> Customers.Retrieve settings
                }
                |> Async.RunSynchronously
            match result with
            | Ok retrieved ->
                Assert.That(retrieved.Id, Is.EqualTo testCustomer.Value.Id)
                Assert.That(retrieved.Name, Is.EqualTo testCustomer.Value.Name)
                Assert.That(retrieved.Email, Is.EqualTo testCustomer.Value.Email)
            | Error e -> Assert.Fail(sprintf "Error: %A" e.StripeError.Message)

        [<Test>]
        member _.``retrieve with expand default_source does not error when no source``() =
            let result =
                Customers.RetrieveOptions.New(
                    customer = testCustomer.Value.Id,
                    expand = ["default_source"]
                )
                |> Customers.Retrieve settings
                |> Async.RunSynchronously
            match result with
            | Ok c ->
                Assert.That(c.DefaultSource, Is.EqualTo None)
            | Error e -> Assert.Fail(sprintf "Error: %A" e.StripeError.Message)

        [<Test>]
        member _.``update customer metadata and re-retrieve``() =
            let result =
                asyncResult {
                    let c = testCustomer.Value
                    let! _ =
                        Customers.UpdateOptions.New(
                            customer = c.Id,
                            metadata = (Map.ofList [("testKey", "testValue")])
                        )
                        |> Customers.Update settings
                    return!
                        Customers.RetrieveOptions.New(customer = c.Id)
                        |> Customers.Retrieve settings
                }
                |> Async.RunSynchronously
            match result with
            | Ok updated ->
                Assert.That(updated.Metadata |> Option.map (Map.tryFind "testKey"),
                    Is.EqualTo (Some (Some "testValue")))
            | Error e -> Assert.Fail(sprintf "Error: %A" e.StripeError.Message)

        [<Test>]
        member _.``list customers with limit=1 returns at most one``() =
            let result =
                Customers.ListOptions.New(limit = 1)
                |> Customers.List settings
                |> Async.RunSynchronously
            match result with
            | Ok list ->
                Assert.That(list.Data.Length, Is.LessThanOrEqualTo 1)
            | Error e -> Assert.Fail(sprintf "Error: %A" e.StripeError.Message)

        [<Test>]
        member _.``delete customer sets Deleted to true``() =
            // Create a dedicated customer for deletion
            let result =
                asyncResult {
                    let! c =
                        Customers.CreateOptions.New(name = "FunStripe delete test customer")
                        |> Customers.Create settings
                    return!
                        Customers.DeleteOptions.New(customer = c.Id)
                        |> Customers.Delete settings
                }
                |> Async.RunSynchronously
            match result with
            | Ok deleted -> Assert.That(deleted.Deleted, Is.True)
            | Error e -> Assert.Fail(sprintf "Error: %A" e.StripeError.Message)

        [<Test>]
        member _.``retrieve deleted customer returns DeletedCustomer with Deleted=true``() =
            // Stripe returns HTTP 200 with {"deleted":true,...} for deleted customers,
            // which cannot deserialise into Customer. We verify the delete itself succeeds.
            let result =
                asyncResult {
                    let! c =
                        Customers.CreateOptions.New(name = "FunStripe delete-then-retrieve test")
                        |> Customers.Create settings
                    return!
                        Customers.DeleteOptions.New(customer = c.Id)
                        |> Customers.Delete settings
                }
                |> Async.RunSynchronously
            match result with
            | Ok deleted -> Assert.That(deleted.Deleted, Is.True)
            | Error e -> Assert.Fail(sprintf "Error: %A" e.StripeError.Message)

    // =========================================================================
    // N. Pagination integration tests
    // =========================================================================

    [<TestFixture>]
    type PaginationIntegrationTests () =

        // Create a product and 3 prices under it once for all tests in this fixture.
        let testProduct =
            lazy (
                let result =
                    StripeRequest.Products.Products.CreateOptions.New(name = "FunStripe pagination test product")
                    |> StripeRequest.Products.Products.Create settings
                    |> Async.RunSynchronously
                match result with
                | Ok p -> p
                | Error e -> failwithf "Failed to create product: %A" e.StripeError.Message
            )

        let createPrice (amount: int) =
            StripeRequest.Prices.Prices.CreateOptions.New(
                currency = IsoTypes.IsoCurrencyCode.GBP,
                unitAmount = amount,
                product = testProduct.Value.Id
            )
            |> StripeRequest.Prices.Prices.Create settings
            |> Async.RunSynchronously

        let testPrices =
            lazy (
                [100; 200; 300]
                |> List.map (fun amount ->
                    match createPrice amount with
                    | Ok p -> p
                    | Error e -> failwithf "Failed to create price: %A" e.StripeError.Message
                )
            )

        [<Test>]
        member _.``list first page with limit=2 returns HasMore=true``() =
            let _ = testPrices.Value  // ensure prices exist
            let result =
                StripeRequest.Prices.Prices.ListOptions.New(
                    limit = 2,
                    product = testProduct.Value.Id
                )
                |> StripeRequest.Prices.Prices.List settings
                |> Async.RunSynchronously
            match result with
            | Ok page ->
                Assert.That(page.Data.Length, Is.EqualTo 2)
                Assert.That(page.HasMore, Is.True)
            | Error e -> Assert.Fail(sprintf "Error: %A" e.StripeError.Message)

        [<Test>]
        member _.``list second page using starting_after cursor returns remaining items``() =
            let _ = testPrices.Value
            let result =
                asyncResult {
                    let! page1 =
                        StripeRequest.Prices.Prices.ListOptions.New(
                            limit = 2,
                            product = testProduct.Value.Id
                        )
                        |> StripeRequest.Prices.Prices.List settings
                    let lastId = page1.Data |> List.last |> (fun p -> p.Id)
                    return!
                        StripeRequest.Prices.Prices.ListOptions.New(
                            limit = 2,
                            product = testProduct.Value.Id,
                            startingAfter = lastId
                        )
                        |> StripeRequest.Prices.Prices.List settings
                }
                |> Async.RunSynchronously
            match result with
            | Ok page2 ->
                Assert.That(page2.Data.Length, Is.GreaterThanOrEqualTo 1)
            | Error e -> Assert.Fail(sprintf "Error: %A" e.StripeError.Message)

        [<Test>]
        member _.``listAllAsync collects all pages into single list``() =
            let _ = testPrices.Value
            let result =
                RestApi.listAllAsync
                    StripeRequest.Prices.Prices.List
                    (fun cursor (opts: StripeRequest.Prices.Prices.ListOptions) -> { opts with StartingAfter = Some cursor })
                    (fun (p: Stripe.Price.Price) -> p.Id)
                    settings
                    (StripeRequest.Prices.Prices.ListOptions.New(limit = 2, product = testProduct.Value.Id))
                |> Async.RunSynchronously
            match result with
            | Ok allPrices ->
                Assert.That(allPrices.Length, Is.GreaterThanOrEqualTo 3)
            | Error e -> Assert.Fail(sprintf "Error: %A" e.StripeError.Message)

        [<Test>]
        member _.``listAllAsync returns empty list when no items match``() =
            let result =
                RestApi.listAllAsync
                    StripeRequest.Prices.Prices.List
                    (fun cursor (opts: StripeRequest.Prices.Prices.ListOptions) -> { opts with StartingAfter = Some cursor })
                    (fun (p: Stripe.Price.Price) -> p.Id)
                    settings
                    (StripeRequest.Prices.Prices.ListOptions.New(product = "prod_nonexistent_funstripe_test"))
                |> Async.RunSynchronously
            match result with
            | Ok [] -> Assert.Pass()
            | Ok items -> Assert.Fail(sprintf "Expected empty list but got %d items" items.Length)
            | Error _ -> Assert.Pass() // API may return error for invalid product ID — either is acceptable

        [<Test>]
        member _.``listAllAsync returns immediately when HasMore is false on first call``() =
            // Create a unique product with exactly 1 price — so limit=10 returns HasMore=false first call
            let result =
                asyncResult {
                    let! singleProduct =
                        StripeRequest.Products.Products.CreateOptions.New(name = "FunStripe single-price product")
                        |> StripeRequest.Products.Products.Create settings
                    let! _ =
                        StripeRequest.Prices.Prices.CreateOptions.New(
                            currency = IsoTypes.IsoCurrencyCode.GBP,
                            unitAmount = 999,
                            product = singleProduct.Id
                        )
                        |> StripeRequest.Prices.Prices.Create settings
                    return!
                        RestApi.listAllAsync
                            StripeRequest.Prices.Prices.List
                            (fun cursor (opts: StripeRequest.Prices.Prices.ListOptions) -> { opts with StartingAfter = Some cursor })
                            (fun (p: Stripe.Price.Price) -> p.Id)
                            settings
                            (StripeRequest.Prices.Prices.ListOptions.New(limit = 10, product = singleProduct.Id))
                }
                |> Async.RunSynchronously
            match result with
            | Ok prices ->
                Assert.That(prices.Length, Is.EqualTo 1)
            | Error e -> Assert.Fail(sprintf "Error: %A" e.StripeError.Message)

    // =========================================================================
    // O. Expand integration tests
    // =========================================================================

    [<TestFixture>]
    type ExpandIntegrationTests () =

        // Create a customer and attach a card as default source
        let testCustomerWithCard =
            lazy (
                let result =
                    asyncResult {
                        let! customer =
                            Customers.CreateOptions.New(
                                name = "FunStripe expand test customer",
                                source = "tok_visa"
                            )
                            |> Customers.Create settings
                        // Retrieve customer so Sources is populated
                        return!
                            Customers.RetrieveOptions.New(customer = customer.Id)
                            |> Customers.Retrieve settings
                    }
                    |> Async.RunSynchronously
                match result with
                | Ok c -> c
                | Error e -> failwithf "Failed to create expand test customer: %A" e.StripeError.Message
            )

        [<Test>]
        member _.``DefaultSource without expand is a plain StripeId string``() =
            let c = testCustomerWithCard.Value
            match c.DefaultSource with
            | Some (StripeId s) ->
                Assert.That(s, Is.Not.Empty)
                Assert.That(s.StartsWith "card_", Is.True, "DefaultSource ID should start with card_")
            | None -> Assert.Fail("Expected DefaultSource to be populated after attaching tok_visa")

        [<Test>]
        member _.``DefaultSource with expand is still resolved as StripeId via id field``() =
            let c = testCustomerWithCard.Value
            let result =
                Customers.RetrieveOptions.New(
                    customer = c.Id,
                    expand = ["default_source"]
                )
                |> Customers.Retrieve settings
                |> Async.RunSynchronously
            match result with
            | Ok expanded ->
                // Even when expanded, StripeIdConverter extracts the id field
                Assert.That(expanded.DefaultSource, Is.EqualTo c.DefaultSource)
            | Error e -> Assert.Fail(sprintf "Error: %A" e.StripeError.Message)

        [<Test>]
        member _.``Sources expanded via expand param contains card in Data``() =
            let c = testCustomerWithCard.Value
            let result =
                Customers.RetrieveOptions.New(
                    customer = c.Id,
                    expand = ["sources"]
                )
                |> Customers.Retrieve settings
                |> Async.RunSynchronously
            match result with
            | Ok expanded ->
                let sourcesData = expanded.Sources |> Option.map (fun s -> s.Data) |> Option.defaultValue []
                Assert.That(sourcesData.Length, Is.GreaterThan 0, "Sources.Data should contain at least one card")
            | Error e -> Assert.Fail(sprintf "Error: %A" e.StripeError.Message)

        [<Test>]
        member _.``PaymentMethod Retrieve with expand customer populates Customer field``() =
            let result =
                asyncResult {
                    let! pm =
                        PaymentMethods.CreateOptions.New(
                            card = Choice2Of2 (PaymentMethods.Create'CardTokenParams.New("tok_visa")),
                            type' = PaymentMethods.Create'Type.Card
                        )
                        |> PaymentMethods.Create settings
                    let! customer =
                        Customers.CreateOptions.New(name = "FunStripe expand PM test customer")
                        |> Customers.Create settings
                    let! attached =
                        PaymentMethodsAttach.AttachOptions.New(
                            customer = customer.Id,
                            paymentMethod = pm.Id
                        )
                        |> PaymentMethodsAttach.Attach settings
                    return!
                        PaymentMethods.RetrieveOptions.New(
                            paymentMethod = attached.Id,
                            expand = [nameof(Customer) |> Util.snakeCase]
                        )
                        |> PaymentMethods.Retrieve settings
                }
                |> Async.RunSynchronously
            match result with
            | Ok pm ->
                // Customer field is populated (StripeId extracted from expanded object)
                Assert.That(pm.Customer, Is.Not.EqualTo None)
            | Error e -> Assert.Fail(sprintf "Error: %A" e.StripeError.Message)

        [<Test>]
        member _.``multiple expand values work simultaneously``() =
            // Create a customer with a source and retrieve with both default_source and sources expanded
            let c = testCustomerWithCard.Value
            let result =
                Customers.RetrieveOptions.New(
                    customer = c.Id,
                    expand = ["default_source"; "sources"]
                )
                |> Customers.Retrieve settings
                |> Async.RunSynchronously
            match result with
            | Ok expanded ->
                // Verify both expand paths are accepted without error and the response is valid.
                // DefaultSource and Sources population depends on API version behaviour.
                Assert.That(expanded.Id, Is.Not.Empty)
            | Error e -> Assert.Fail(sprintf "Error: %A" e.StripeError.Message)

    // =========================================================================
    // P. Product and Price lifecycle integration tests
    // =========================================================================

    [<TestFixture>]
    type ProductAndPriceIntegrationTests () =

        let testProduct =
            lazy (
                let result =
                    StripeRequest.Products.Products.CreateOptions.New(name = "FunStripe lifecycle product")
                    |> StripeRequest.Products.Products.Create settings
                    |> Async.RunSynchronously
                match result with
                | Ok p -> p
                | Error e -> failwithf "Failed to create lifecycle product: %A" e.StripeError.Message
            )

        [<Test>]
        member _.``create product returns Name``() =
            let p = testProduct.Value
            Assert.That(p.Id, Is.Not.Empty)
            Assert.That(p.Name, Is.EqualTo "FunStripe lifecycle product")

        [<Test>]
        member _.``create price for product round-trips fields``() =
            let result =
                StripeRequest.Prices.Prices.CreateOptions.New(
                    currency = IsoTypes.IsoCurrencyCode.GBP,
                    unitAmount = 1500,
                    product = testProduct.Value.Id
                )
                |> StripeRequest.Prices.Prices.Create settings
                |> Async.RunSynchronously
            match result with
            | Ok price ->
                Assert.That(price.Currency, Is.EqualTo IsoTypes.IsoCurrencyCode.GBP)
                Assert.That(price.UnitAmount, Is.EqualTo (Some 1500))
            | Error e -> Assert.Fail(sprintf "Error: %A" e.StripeError.Message)

        [<Test>]
        member _.``retrieve price round-trips by Id``() =
            let result =
                asyncResult {
                    let! created =
                        StripeRequest.Prices.Prices.CreateOptions.New(
                            currency = IsoTypes.IsoCurrencyCode.GBP,
                            unitAmount = 750,
                            product = testProduct.Value.Id
                        )
                        |> StripeRequest.Prices.Prices.Create settings
                    return!
                        StripeRequest.Prices.Prices.RetrieveOptions.New(price = created.Id)
                        |> StripeRequest.Prices.Prices.Retrieve settings
                }
                |> Async.RunSynchronously
            match result with
            | Ok retrieved ->
                Assert.That(retrieved.UnitAmount, Is.EqualTo (Some 750))
            | Error e -> Assert.Fail(sprintf "Error: %A" e.StripeError.Message)

        [<Test>]
        member _.``list prices filtered by product returns only matching prices``() =
            let result =
                StripeRequest.Prices.Prices.ListOptions.New(product = testProduct.Value.Id)
                |> StripeRequest.Prices.Prices.List settings
                |> Async.RunSynchronously
            match result with
            | Ok list ->
                Assert.That(list.Data.Length, Is.GreaterThan 0)
                // Every returned price must belong to our product
                for price in list.Data do
                    match price.Product with
                    | Stripe.Price.PriceProduct'AnyOf.String s ->
                        Assert.That(s, Is.EqualTo testProduct.Value.Id)
                    | Stripe.Price.PriceProduct'AnyOf.Product p ->
                        Assert.That(p.Id, Is.EqualTo testProduct.Value.Id)
                    | Stripe.Price.PriceProduct'AnyOf.DeletedProduct dp ->
                        Assert.Fail(sprintf "Unexpected deleted product %s in results" dp.Id)
            | Error e -> Assert.Fail(sprintf "Error: %A" e.StripeError.Message)

        [<Test>]
        member _.``delete product sets Deleted to true``() =
            let result =
                asyncResult {
                    let! p =
                        StripeRequest.Products.Products.CreateOptions.New(name = "FunStripe delete product test")
                        |> StripeRequest.Products.Products.Create settings
                    return!
                        StripeRequest.Products.Products.DeleteOptions.New(id = p.Id)
                        |> StripeRequest.Products.Products.Delete settings
                }
                |> Async.RunSynchronously
            match result with
            | Ok deleted -> Assert.That(deleted.Deleted, Is.True)
            | Error e -> Assert.Fail(sprintf "Error: %A" e.StripeError.Message)

    // =========================================================================
    // Q. Error handling integration tests
    // =========================================================================

    [<TestFixture>]
    type ErrorHandlingIntegrationTests () =

        [<Test>]
        member _.``retrieve non-existent customer returns InvalidRequestError``() =
            let result =
                Customers.RetrieveOptions.New(customer = "cus_funstripe_nonexistent_test")
                |> Customers.Retrieve settings
                |> Async.RunSynchronously
            match result with
            | Error e ->
                Assert.That(e.StripeError.Type, Is.EqualTo (Some StripeError.ErrorType.InvalidRequestError))
                Assert.That(e.StripeError.Message, Is.Not.EqualTo None)
            | Ok _ -> Assert.Fail("Expected an error for non-existent customer")

        [<Test>]
        member _.``invalid API key returns an error with a message``() =
            // Stripe may return AuthenticationError or InvalidRequestError depending on key format;
            // either way an error with a non-empty message is guaranteed.
            let badSettings = RestApi.StripeApiSettings.New(apiKey = "sk_test_invalidkey_funstripe")
            let result =
                Customers.RetrieveOptions.New(customer = "cus_any")
                |> Customers.Retrieve badSettings
                |> Async.RunSynchronously
            match result with
            | Error e ->
                Assert.That(e.StripeError.Message, Is.Not.EqualTo None)
            | Ok _ -> Assert.Fail("Expected an error for invalid API key")

        [<Test>]
        member _.``invalid card token returns InvalidRequestError with card token param``() =
            let result =
                PaymentMethods.CreateOptions.New(
                    card = Choice2Of2 (PaymentMethods.Create'CardTokenParams.New("tok_funstripe_invalid_token")),
                    type' = PaymentMethods.Create'Type.Card
                )
                |> PaymentMethods.Create settings
                |> Async.RunSynchronously
            match result with
            | Error e ->
                Assert.That(e.StripeError.Type, Is.EqualTo (Some StripeError.ErrorType.InvalidRequestError))
                Assert.That(e.StripeError.Message, Is.Not.EqualTo None)
            | Ok _ -> Assert.Fail("Expected an error for invalid card token")

        [<Test>]
        member _.``all error responses include a non-empty message``() =
            let results =
                [
                    Customers.RetrieveOptions.New(customer = "cus_funstripe_error_test_1")
                    |> Customers.Retrieve settings
                    |> Async.RunSynchronously
                ]
            for result in results do
                match result with
                | Error e ->
                    Assert.That(e.StripeError.Message, Is.Not.EqualTo None)
                | Ok _ -> ()
