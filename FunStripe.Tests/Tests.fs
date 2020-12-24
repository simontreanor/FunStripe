namespace FunStripe

open FunStripe.AsyncResultCE
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
            let paymentMethodCard = {
                Brand = PaymentMethodCardBrand.Visa
                Checks = Some paymentMethodCardChecks
                Country = Some "US"
                Description = None
                ExpMonth = 10L
                ExpYear = 2021L
                Fingerprint = Some "YfQddCBRsntX6npu"
                Funding = PaymentMethodCardFunding.Credit
                Iin = None
                Issuer = None
                Last4 = "4242"
                Networks = Some networks
                ThreeDSecureUsage = Some threeDSecureUsage
                Wallet = None
            }
            let paymentMethod = {
                BillingDetails = billingDetails
                Card = Some paymentMethodCard
                CardPresent = None
                Created = 1604075742L
                Customer = None
                Id = "IgnoreThisId"
                Livemode = false
                Metadata = Some Map.empty
                Type = PaymentMethodType.Card
                Alipay = None; AuBecsDebit = None; BacsDebit = None; Bancontact = None; Eps = None; Fpx = None; Giropay = None
                Grabpay = None; Ideal = None; InteracPresent = None; Oxxo = None; P24 = None; SepaDebit = None; Sofort = None
            }
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
                    Assert.AreEqual(Some testCustomer, actual.Customer)
                    Assert.AreEqual(newPM.Id, actual.Id)
                    Assert.AreEqual([("order_id", "6735")] |> Map.ofList, actual.Metadata)
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
                        PostPaymentMethodsPaymentMethodAttachParams(
                            customer = testCustomer
                        )
                    pms.Attach(parameters, expected.Id)

                let actual' = { actual with Card = None } //ignore card as updating can change CvcCheck value

                Assert.Multiple(fun () ->
                    Assert.AreEqual(Some testCustomer, actual.Customer)
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
