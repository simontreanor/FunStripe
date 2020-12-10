namespace FunStripe

open NUnit.Framework
open StripeModel
open StripeService

module Tests =

    [<TestFixture>]
    type PaymentMethodUnitTests () =

        let testCustomer = "cus_HxEURwENT9MKb3"

        // let getNewPaymentMethod =
        //     let pms = PaymentMethodService(apiKey = Config.GetStripeTestApiKey)
        //     asyncResult {
        //         let newCard = { ExpMonth = 10; ExpYear = 2021; Number = 4242424242424242L; Cvc = 314 }
        //         return!
        //             { Type = Card; BillingDetails = None; Metadata = None; Card = Some newCard }
        //             |> pms.Create
        //     }

        // let attachCustomer paymentMethodId =
        //     let pms = PaymentMethodService(apiKey = Config.GetStripeTestApiKey)
        //     async {
        //         return! pms.Attach paymentMethodId { Customer = testCustomer }
        //     }

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
                    expMonth = 10,
                    expYear = 2021,
                    fingerprint = Some "YfQddCBRsntX6npu",
                    funding = PaymentMethodCardFunding'Credit,
                    last4 = "4242",
                    networks = Some networks,
                    threeDSecureUsage = Some threeDSecureUsage,
                    wallet = None
                )
            
            PaymentMethod(
                billingDetails = billingDetails,
                created = 1604075742,
                customer = None,
                id = "IgnoreThisId",
                livemode = false,
                metadata = None,
                object = PaymentMethodObject'PaymentMethod, //todo: replace object in constructor with literal assignment
                ``type`` = PaymentMethodType'Card,
                card = card
            )

        // [<Test>]
        // member _.``test JSON to x-www-form-urlencoded conversion``() =
        //     let expected =
        //         seq {
        //             "type", "card"
        //             "card[number]", "4242424242424242"
        //             "card[exp_month]", "10"
        //             "card[exp_year]", "2021"
        //             "card[cvc]", "314"
        //         }
        //         |> Seq.sortBy fst
        //     let actual = 
        //         { Type = Card; BillingDetails = None; Metadata = None; Card = Some { ExpMonth = 10; ExpYear = 2021; Number = 4242424242424242L; Cvc = 314 } }
        //         |> FormUtil.serialise
        //         |> Seq.sortBy fst
        //     Assert.AreEqual (expected, actual)

        // [<Test>]
        // member _.``test payment method creation``() =
        //     asyncResult {
        //         let expected = { defaultPaymentMethod with Card = None } 

        //         let! actual = getNewPaymentMethod

        //         //fields Id and Created come back different each time, so set them to match expected
        //         let actual' = { actual with Id = "IgnoreThisId"; Created = 1604075742; Card = None }
        //         Assert.AreEqual (expected, actual')
        //     }
        //     |> Async.RunSynchronously
        //     |> ignore

        // [<Test>]
        // member _.``test payment method retrieval``() =
        //     asyncResult {
        //         let! pm = getNewPaymentMethod

        //         let expected = pm

        //         let! actual =
        //             let pms = PaymentMethodService(apiKey = Config.GetStripeTestApiKey)
        //             pms.Get pm.Id

        //         Assert.AreEqual (expected, actual)
        //     }
        //     |> Async.RunSynchronously
        //     |> ignore

        // [<Test>]
        // member _.``test payment method update``() =
        //     asyncResult {
        //         let! pm = getNewPaymentMethod

        //         let! newPM = attachCustomer pm.Id

        //         let expected = { pm with Id = newPM.Id; Customer = Some testCustomer; Metadata = [("order_id", "6735")] |> Map.ofList; Card = None }

        //         let! actual =
        //             let pms = PaymentMethodService(apiKey = Config.GetStripeTestApiKey)
        //             {
        //                 BillingDetails = None
        //                 Metadata = [("OrderId", "6735")] |> Map.ofList |> Some
        //                 Card = None
        //             }
        //             |> pms.Update newPM.Id

        //         let actual' = { actual with Card = None } //ignore card as updating can change CvcCheck value

        //         Assert.AreEqual (expected, actual')
        //     }
        //     |> Async.RunSynchronously
        //     |> ignore

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
