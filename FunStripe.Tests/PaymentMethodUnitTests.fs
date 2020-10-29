module FunStripe.Tests

open NUnit.Framework
open Cards
open PaymentMethods

[<TestFixture>]
type PaymentMethodUnitTests () =

    [<Test>]
    member _.``JSON to x-www-form-urlencoded works properly``() =
        let expected =
            seq {
                "type", "card"
                "card[number]", "4242424242424242"
                "card[exp_month]", "10"
                "card[exp_year]", "2021"
                "card[cvc]", "314"
            }
        let actual = 
            { Type = Card; BillingDetails = None; Metadata = None; Card = Some { ExpMonth = 10; ExpYear = 2021; Number = 4242424242424242L; Cvc = 314 } }
            |> FormUtil.serialise
        Assert.AreEqual (expected, actual)

    [<Test>][<Ignore("Temporarily disabled")>]
    member _.``create test PaymentMethod returns PaymentMethod object``() =
        async {
            let expected = {
                Id = "pm_1EUmyr2x6R10KRrhlYS3l97f"
                Object = PaymentMethod
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
                    ExpMonth = 8
                    ExpYear = 2020
                    Fingerprint = "0Kibh5yAgbiiwPEL"
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
                Created = 1556596209
                Customer = None
                Livemode = false
                Metadata = [] |> Map.ofList
                Type = Card
            }

            let! actual =
                let pms = PaymentMethodService()
                let newCard = { ExpMonth = 10; ExpYear = 2021; Number = 4242424242424242L; Cvc = 314 }

                { Type = Card; BillingDetails = None; Metadata = None; Card = Some newCard }
                |> pms.Create

            Assert.AreEqual (expected, actual)
        }
        |> Async.RunSynchronously
