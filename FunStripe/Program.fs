// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open FunStripe
open FunStripe.StripeModel
open System

// Define a function to construct a message to print
let ``test parsing customer object``() =
    let expected =
        {
            Address = None
            Balance = Some 0
            Created = DateTime(2021, 1, 6, 10, 42, 3)
            Currency = None
            DefaultSource = Some (CustomerDefaultSource'AnyOf.String "card_1I6ZSoGXSUku3vEhr04df95L")
            Delinquent = Some false
            Description = Some "KEITH LILY"
            Discount = None
            Email = Some "KEITH_2614@mailinator.com"
            Id = "cus_IhzR2Msjq0lILS"
            InvoicePrefix = Some "12F15AC4"
            InvoiceSettings =
                Some {
                    CustomFields = None
                    DefaultPaymentMethod = None
                    Footer = None
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
                            Card.Create (
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
            TaxExempt = Some (CustomerTaxExempt.None')
            TaxIds =
                Some {
                    Data = []
                    HasMore = false
                    Url = "/v1/customers/cus_IhzR2Msjq0lILS/tax_ids"
                }
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
    let serialised = Json.Util.serialise actual
    expected = actual

[<EntryPoint>]
let main argv =
    let result = ``test parsing customer object`` ()
    printfn "Test result: %s" (result.ToString())
    0
