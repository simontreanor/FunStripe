namespace FunStripe

open FunStripe.AsyncResultCE
open NUnit.Framework
open StripeModel
open StripeRequest
open System
open System.Text.RegularExpressions

module Tests =

    let settings = RestApi.StripeApiSettings.New(apiKey = Config.StripeTestApiKey)

    [<TestFixture>]
    type PaymentMethodUnitTests () =

        let testCustomer = "cus_HxEURwENT9MKb3"

        let defaultCard =
            PaymentMethods.Create'CardCardDetailsParams.New(
                cvc = "314",
                expMonth = 10,
                expYear = 2021,
                number = "4242424242424242"
            )

        let getNewPaymentMethod () =
            asyncResult {
                return!
                    PaymentMethods.CreateOptions.New(
                        card = Choice1Of2 defaultCard,
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
            let billingDetails = { BillingDetails.Address = Some address; Email = None; Name = None; Phone = None }
            let paymentMethodCardChecks = { PaymentMethodCardChecks.AddressLine1Check = None; AddressPostalCodeCheck = None; CvcCheck = None }
            let networks = { Available = ["Visa"]; Preferred = None }
            let threeDSecureUsage = { Supported = true }
            let paymentMethodCard =
                PaymentMethodCard.New(
                    brand = PaymentMethodCardBrand.Visa,
                    checks = Some paymentMethodCardChecks,
                    country = Some "US",
                    expMonth = 10,
                    expYear = 2021,
                    fingerprint = Some "YfQddCBRsntX6npu",
                    funding = PaymentMethodCardFunding.Credit,
                    last4 = "4242",
                    networks = Some networks,
                    threeDSecureUsage = Some threeDSecureUsage,
                    wallet = None
                )
            let paymentMethod =
                PaymentMethod.New(
                    billingDetails = billingDetails,
                    card = paymentMethodCard,
                    created = DateTime(2020, 10, 30, 16, 35, 0),
                    customer = None,
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
                    "card[number]", "4242424242424242"
                    "card[exp_month]", "10"
                    "card[exp_year]", "2021"
                    "card[cvc]", "314"
                }
                |> Seq.sortBy fst
            let actual = 
                PaymentMethods.CreateOptions.New(
                    card = Choice1Of2 defaultCard,
                    type' = PaymentMethods.Create'Type.Card
                )
                |> FormUtil.serialise
                |> Seq.sortBy fst
            Assert.AreEqual(expected, actual)

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
                    Assert.AreEqual(exp.BillingDetails, act.BillingDetails)
                    Assert.AreEqual(exp.Customer, act.Customer)
                    Assert.AreEqual(exp.Livemode, act.Livemode)
                    Assert.AreEqual(exp.Metadata, act.Metadata)
                    Assert.AreEqual(exp.Type, act.Type)
                )
            | Error e ->
                Assert.AreEqual("<ErrorMessage>", e.StripeError.Message)

        [<Test>]
        member _.``test payment method retrieval``() =
            let result =
                asyncResult {
                    let! expected = getNewPaymentMethod()
                    let! actual =
                        let queryParameters = PaymentMethods.RetrieveOptions.New(paymentMethod = expected.Id, expand = [nameof(Customer) |> Json.Util.snakeCase])
                        PaymentMethods.Retrieve settings queryParameters
                    return expected, actual

                }
                |> Async.RunSynchronously
            match result with
            | Ok (exp, act) ->
                Assert.AreEqual(exp, act)
            | Error e ->
                Assert.AreEqual("<ErrorMessage>", e.StripeError.Message)

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
                    Assert.AreEqual(testCustomer |> PaymentMethodCustomer'AnyOf.String |> Some , act.Customer)
                    Assert.AreEqual(pm.Id, act.Id)
                    Assert.AreEqual([("order_id", "6735")] |> Map.ofList |> Some, act.Metadata)
                )
            | Error e ->
                Assert.AreEqual("<ErrorMessage>", e.StripeError.Message)

        [<Test>]
        member _.``test attaching customer to payment method``() =
            let result =
                asyncResult {
                    let! expected = getNewPaymentMethod()
                    let! actual =
                        let options =
                            // PaymentMethodsAttach.AttachOptions.New(
                            //     customer = testCustomer,
                            //     expand = [nameof(Customer)],
                            //     paymentMethod = expected.Id
                            // )
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
                    Assert.AreEqual(testCustomer |> PaymentMethodCustomer'AnyOf.String |> Some, act.Customer)
                    Assert.AreEqual(exp.Id, act.Id)
                )
            | Error e ->
                Assert.AreEqual("<ErrorMessage>", e.StripeError.Message)

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
                    Assert.AreEqual(None, act.Customer)
                    Assert.AreEqual(exp.Id, act.Id)
                )
            | Error e ->
                Assert.AreEqual("<ErrorMessage>", e.StripeError.Message)

        [<Test>]
        member _.``test parsing customer object``() =
            let expected =
                {
                    Address = None
                    Balance = Some 0
                    CashBalance =
                        Some {
                            Available = Some (Map.empty)
                            Customer = "cus_IhzR2Msjq0lILS"
                            Livemode = false
                            Settings = { ReconciliationMode = CustomerBalanceCustomerBalanceSettingsReconciliationMode.Automatic }
                        }
                    Created = DateTime(2021, 1, 6, 10, 42, 3)
                    Currency = None
                    DefaultSource = Some (CustomerDefaultSource'AnyOf.String "card_1I6ZSoGXSUku3vEhr04df95L")
                    Delinquent = Some false
                    Description = Some "KEITH LILY"
                    Discount = None
                    Email = Some "KEITH_2614@mailinator.com"
                    Id = "cus_IhzR2Msjq0lILS"
                    InvoiceCreditBalance = Some (Map.empty)
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
                                        country = Some "US",
                                        customer = Some (CardCustomer'AnyOf.String "cus_IhzR2Msjq0lILS"),
                                        cvcCheck = Some (CardCvcCheck.Pass),
                                        dynamicLast4 =  None,
                                        expMonth = 10,
                                        expYear = 2021,
                                        fingerprint = Some "YfQddCBRsntX6npu",
                                        funding = CardFunding.Credit,
                                        last4 = "4242",
                                        metadata = Some (Map.empty),
                                        name =  None,
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
                        "exp_year": 2021,
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
            let actual = Json.Util.deserialise<Customer> response
            Assert.AreEqual(expected, actual)
