namespace FunStripe

open NUnit.Framework
open StripeModel
open StripeRequest
open StripeService

module Tests =

    [<TestFixture>]
    type PaymentMethodUnitTests () =

        let testCustomer = "cus_HxEURwENT9MKb3"

        let defaultCard =
            PostPaymentMethodsCardCardDetailsParams(
                cvc = "314",
                expMonth = 10L,
                expYear = 2021L,
                number = "4242424242424242"
            )

        let getNewPaymentMethod =
            let pms = PaymentMethodService(apiKey = Config.GetStripeTestApiKey)
            asyncResult {
                let parameters = 
                    PostPaymentMethodsParams(
                        card = Choice1Of2 defaultCard,
                        ``type`` = PostPaymentMethodsType'Card
                    )
                return! pms.Create(parameters)
            }

        let attachCustomer paymentMethodId =
            let pms = PaymentMethodService(apiKey = Config.GetStripeTestApiKey)
            asyncResult {
                let parameters = 
                    PostPaymentMethodsPaymentMethodAttachParams(
                        customer = testCustomer
                    )
                return! pms.Attach(parameters, paymentMethodId)
            }

        let defaultPaymentMethod =
            let address = Address(None, None, None, None, None, None)
            let billingDetails = BillingDetails (Some address, None, None, None)
            let checks = PaymentMethodCardChecks(None, None, None)
            let networks = Networks(["Visa"], None)
            let threeDSecureUsage = ThreeDSecureUsage(true)
            let card =
                PaymentMethodCard (
                    brand = PaymentMethodCardBrand'Visa,
                    checks = Some checks,
                    country = Some "US",
                    expMonth = 10L,
                    expYear = 2021L,
                    fingerprint = Some "YfQddCBRsntX6npu",
                    funding = PaymentMethodCardFunding'Credit,
                    last4 = "4242",
                    networks = Some networks,
                    threeDSecureUsage = Some threeDSecureUsage,
                    wallet = None
                )
            
            PaymentMethod(
                billingDetails = billingDetails,
                card = card,
                created = 1604075742L,
                customer = None,
                id = "IgnoreThisId",
                livemode = false,
                metadata = None,
                ``type`` = PaymentMethodType'Card
            )

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
                    ``type`` = PostPaymentMethodsType'Card
                )
                |> FormUtil.serialise
                |> Seq.sortBy fst
            Assert.AreEqual (expected, actual)

        [<Test>]
        member _.``test payment method creation``() =
            asyncResult {
                let expected = defaultPaymentMethod
                let! actual = getNewPaymentMethod
                Assert.Multiple(fun () ->
                    Assert.AreEqual (expected.BillingDetails, actual.BillingDetails)
                    Assert.AreEqual (expected.Customer, actual.Customer)
                    Assert.AreEqual (expected.Livemode, actual.Livemode)
                    Assert.AreEqual (expected.Metadata, actual.Metadata)
                    Assert.AreEqual (expected.Type, actual.Type)
                )
            }
            |> Async.RunSynchronously
            |> ignore

        [<Test>]
        member _.``test payment method retrieval``() =
            asyncResult {
                let! expected = getNewPaymentMethod

                let! actual =
                    let pms = PaymentMethodService(apiKey = Config.GetStripeTestApiKey)
                    pms.Retrieve(expected.Id)

                Assert.AreEqual (expected, actual)
            }
            |> Async.RunSynchronously
            |> ignore

        [<Test>]
        member _.``test payment method update``() =
            asyncResult {
                let! expected = getNewPaymentMethod
                let! newPM = attachCustomer expected.Id

                let! actual =
                    let pms = PaymentMethodService(apiKey = Config.GetStripeTestApiKey)
                    let parameters =
                        PostPaymentMethodsPaymentMethodParams(
                            metadata = ([("OrderId", "6735")] |> Map.ofList)
                        )
                    pms.Update(parameters, newPM.Id)

                Assert.Multiple(fun () ->
                    Assert.AreEqual (testCustomer, actual.Id)
                    Assert.AreEqual (newPM.Id, actual.Id)
                    Assert.AreEqual ([("order_id", "6735")] |> Map.ofList, actual.Metadata)
                )
            }
            |> Async.RunSynchronously
            |> ignore

        // [<Test>]
        // member _.``test attaching customer to payment method``() =
        //     asyncResult {
        //         let! pm = getNewPaymentMethod

        //         let expected = { pm with Customer = Some testCustomer; Card = None }

        //         let! actual =
        //             let pms = PaymentMethodService(apiKey = Config.GetStripeTestApiKey)
        //             { Customer = testCustomer }
        //             |> pms.Attach pm.Id

        //         let actual' = { actual with Card = None } //ignore card as updating can change CvcCheck value

        //         Assert.AreEqual (expected, actual')
        //     }
        //     |> Async.RunSynchronously
        //     |> ignore

        // [<Test>]
        // member _.``test detaching customer from payment method``() =
        //     asyncResult {
        //         let! pm = getNewPaymentMethod

        //         let! newPM = attachCustomer pm.Id

        //         let expected = { pm with Id = newPM.Id; Customer = None; Card = None }

        //         let! actual =
        //             let pms = PaymentMethodService(apiKey = Config.GetStripeTestApiKey)
        //             pms.Detach newPM.Id

        //         let actual' = { actual with Card = None } //ignore card as updating can change CvcCheck value

        //         Assert.AreEqual (expected, actual')
        //     }
        //     |> Async.RunSynchronously
        //     |> ignore
