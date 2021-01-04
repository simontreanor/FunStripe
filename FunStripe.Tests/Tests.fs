namespace FunStripe

open FunStripe.AsyncResultCE
open NUnit.Framework
open StripeModel
open StripeRequest
open StripeService
open System

module Tests =

    [<TestFixture>]
    type PaymentMethodUnitTests () =

        let testCustomer = "cus_HxEURwENT9MKb3"

        let defaultCard =
            PostPaymentMethodsCardCardDetailsParams(
                cvc = "314",
                expMonth = 10,
                expYear = 2021,
                number = "4242424242424242"
            )

        let getNewPaymentMethod () =
            let pms = PaymentMethodService(apiKey = Config.getStripeTestApiKey())
            asyncResult {
                let parameters = 
                    PostPaymentMethodsParams(
                        card = Choice1Of2 defaultCard,
                        ``type`` = PostPaymentMethodsType.Card
                    )
                return! pms.Create(parameters)
            }

        let attachCustomer paymentMethodId =
            let pms = PaymentMethodService(apiKey = Config.getStripeTestApiKey())
            asyncResult {
                let parameters = 
                    PostPaymentMethodsPaymentMethodAttachParams(
                        customer = testCustomer
                    )
                return! pms.Attach(parameters, paymentMethodId)
            }

        let defaultPaymentMethod =
            let address = { City = None; Country = None; Line1 = None; Line2 = None; PostalCode = None; State = None }
            let billingDetails = { Address = Some address; Email = None; Name = None; Phone = None }
            let paymentMethodCardChecks = { PaymentMethodCardChecks.AddressLine1Check = None; AddressPostalCodeCheck = None; CvcCheck = None }
            let networks = { Available = ["Visa"]; Preferred = None }
            let threeDSecureUsage = { Supported = true }
            let paymentMethodCard =
                PaymentMethodCard.Create(
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
                PaymentMethod.Create(
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
                PostPaymentMethodsParams(
                    card = Choice1Of2 defaultCard,
                    ``type`` = PostPaymentMethodsType.Card
                )
                |> FormUtil.serialise
                |> Seq.sortBy fst
            Assert.AreEqual(expected, actual)

        [<Test>]
        member _.``test payment method creation``() =
            asyncResult {
                let expected = defaultPaymentMethod
                let! actual = getNewPaymentMethod()
                Assert.Multiple(fun () ->
                    Assert.AreEqual(expected.BillingDetails, actual.BillingDetails)
                    Assert.AreEqual(expected.Customer, actual.Customer)
                    Assert.AreEqual(expected.Livemode, actual.Livemode)
                    Assert.AreEqual(expected.Metadata, actual.Metadata)
                    Assert.AreEqual(expected.Type, actual.Type)
                )
            }
            |> Async.RunSynchronously
            |> ignore

        [<Test>]
        member _.``test payment method retrieval``() =
            asyncResult {
                let! expected = getNewPaymentMethod()

                let! actual =
                    let pms = PaymentMethodService(apiKey = Config.getStripeTestApiKey())
                    pms.Retrieve(expected.Id)

                Assert.AreEqual(expected, actual)
            }
            |> Async.RunSynchronously
            |> ignore

        [<Test>]
        member _.``test payment method update``() =
            asyncResult {
                let! expected = getNewPaymentMethod()
                let! newPM = attachCustomer expected.Id

                let! actual =
                    let pms = PaymentMethodService(apiKey = Config.getStripeTestApiKey())
                    let parameters =
                        PostPaymentMethodsPaymentMethodParams(
                            metadata = ([("OrderId", "6735")] |> Map.ofList)
                        )
                    pms.Update(parameters, newPM.Id)

                Assert.Multiple(fun () ->
                    Assert.AreEqual(testCustomer |> PaymentMethodCustomer'AnyOf.String |> Some , actual.Customer)
                    Assert.AreEqual(newPM.Id, actual.Id)
                    Assert.AreEqual([("order_id", "6735")] |> Map.ofList |> Some, actual.Metadata)
                )
            }
            |> Async.RunSynchronously
            |> ignore

        [<Test>]
        member _.``test attaching customer to payment method``() =
            asyncResult {
                let! expected = getNewPaymentMethod()
                let! actual =
                    let pms = PaymentMethodService(apiKey = Config.getStripeTestApiKey())
                    let parameters =
                        // PostPaymentMethodsPaymentMethodAttachParams(
                        //     customer = testCustomer,
                        //     expand = [nameof(Customer)]
                        // )
                        PostPaymentMethodsPaymentMethodAttachParams(
                            customer = testCustomer
                        )
                    pms.Attach(parameters, expected.Id)

                Assert.Multiple(fun () ->
                    Assert.AreEqual(testCustomer |> PaymentMethodCustomer'AnyOf.String |> Some, actual.Customer)
                    Assert.AreEqual(expected.Id, actual.Id)
                )
            }
            |> Async.RunSynchronously
            |> ignore

        [<Test>]
        member _.``test detaching customer from payment method``() =
            asyncResult {
                let! expected = getNewPaymentMethod()
                let! newPM = attachCustomer expected.Id

                let! actual =
                    let pms = PaymentMethodService(apiKey = Config.getStripeTestApiKey())
                    let parameters = PostPaymentMethodsPaymentMethodDetachParams()
                    pms.Detach(parameters, newPM.Id)

                Assert.Multiple(fun () ->
                    Assert.AreEqual(None, actual.Customer)
                    Assert.AreEqual(expected.Id, actual.Id)
                )
            }
            |> Async.RunSynchronously
            |> ignore
