namespace FunStripe

open NUnit.Framework
open Cards
open PaymentMethods

module Tests =

    [<TestFixture>]
    type PaymentMethodUnitTests () =

        let testCustomer = "cus_HxEURwENT9MKb3"

        let getNewPaymentMethod =
            let pms = PaymentMethodService(apiKey = Config.GetStripeTestApiKey)
            async {
                let newCard = { ExpMonth = 10; ExpYear = 2021; Number = 4242424242424242L; Cvc = 314 }
                return!
                    { Type = Card; BillingDetails = None; Metadata = None; Card = Some newCard }
                    |> pms.Create
            }

        let attachCustomer paymentMethodId =
            let pms = PaymentMethodService(apiKey = Config.GetStripeTestApiKey)
            async {
                return! pms.Attach paymentMethodId { Customer = testCustomer }
            }

        let defaultPaymentMethod = {
            Id = "IgnoreThisId"
            Object = "payment_method"
            BillingDetails = {
                Address = {
                    City = None
                    Country = None
                    Line1 = None
                    Line2 = None
                    PostalCode = None
                    State = None
                }
                Email = None
                Name = None
                Phone = None
            }
            Card = Some {
                Brand = Brand.Visa
                Checks = {
                    AddressLine1Check = None
                    AddressPostalCodeCheck = None
                    CvcCheck = None
                }
                Country = "US"
                ExpMonth = 10
                ExpYear = 2021
                Fingerprint = "YfQddCBRsntX6npu"
                Funding = Funding.Credit
                GeneratedFrom = None
                Last4 = "4242"
                Networks = {
                    Available = [ Visa ]
                    Preferred = None
                }
                ThreeDSecureUsage = {
                    Supported = true
                }
                Wallet = None
            }
            Created = 1604075742
            Customer = None
            Livemode = false
            Metadata = Map.empty
            Type = Card
        }

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
                { Type = Card; BillingDetails = None; Metadata = None; Card = Some { ExpMonth = 10; ExpYear = 2021; Number = 4242424242424242L; Cvc = 314 } }
                |> FormUtil.serialise
                |> Seq.sortBy fst
            Assert.AreEqual (expected, actual)

        [<Test>]
        member _.``test payment method creation``() =
            asyncResult {
                let expected = { defaultPaymentMethod with Card = None } 

                let! actual = getNewPaymentMethod

                //fields Id and Created come back different each time, so set them to match expected
                let actual' = { actual with Id = "IgnoreThisId"; Created = 1604075742; Card = None }
                Assert.AreEqual (expected, actual')
            }
            |> Async.RunSynchronously
            |> ignore

        [<Test>]
        member _.``test payment method retrieval``() =
            asyncResult {
                let! pm = getNewPaymentMethod

                let expected = pm

                let! actual =
                    let pms = PaymentMethodService(apiKey = Config.GetStripeTestApiKey)
                    pms.Get pm.Id

                Assert.AreEqual (expected, actual)
            }
            |> Async.RunSynchronously
            |> ignore

        [<Test>]
        member _.``test payment method update``() =
            asyncResult {
                let! pm = getNewPaymentMethod

                let! newPM = attachCustomer pm.Id

                let expected = { pm with Id = newPM.Id; Customer = Some testCustomer; Metadata = [("order_id", "6735")] |> Map.ofList; Card = None }

                let! actual =
                    let pms = PaymentMethodService(apiKey = Config.GetStripeTestApiKey)
                    {
                        BillingDetails = None
                        Metadata = [("OrderId", "6735")] |> Map.ofList |> Some
                        Card = None
                    }
                    |> pms.Update newPM.Id

                let actual' = { actual with Card = None } //ignore card as updating can change CvcCheck value

                Assert.AreEqual (expected, actual')
            }
            |> Async.RunSynchronously
            |> ignore

        [<Test>]
        member _.``test attaching customer to payment method``() =
            asyncResult {
                let! pm = getNewPaymentMethod

                let expected = { pm with Customer = Some testCustomer; Card = None }

                let! actual =
                    let pms = PaymentMethodService(apiKey = Config.GetStripeTestApiKey)
                    { Customer = testCustomer }
                    |> pms.Attach pm.Id

                let actual' = { actual with Card = None } //ignore card as updating can change CvcCheck value

                Assert.AreEqual (expected, actual')
            }
            |> Async.RunSynchronously
            |> ignore

        [<Test>]
        member _.``test detaching customer from payment method``() =
            asyncResult {
                let! pm = getNewPaymentMethod

                let! newPM = attachCustomer pm.Id

                let expected = { pm with Id = newPM.Id; Customer = None; Card = None }

                let! actual =
                    let pms = PaymentMethodService(apiKey = Config.GetStripeTestApiKey)
                    pms.Detach newPM.Id

                let actual' = { actual with Card = None } //ignore card as updating can change CvcCheck value

                Assert.AreEqual (expected, actual')
            }
            |> Async.RunSynchronously
            |> ignore
