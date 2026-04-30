namespace Stripe.Level3

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type Level3LineItems =
    { DiscountAmount: int option
      ProductCode: string
      ProductDescription: string
      Quantity: int option
      TaxAmount: int option
      UnitCost: int option }

module Level3LineItems =
    let create
        (
            discountAmount: int option,
            productCode: string,
            productDescription: string,
            quantity: int option,
            taxAmount: int option,
            unitCost: int option
        ) : Level3LineItems
        =
        {
          DiscountAmount = discountAmount
          ProductCode = productCode
          ProductDescription = productDescription
          Quantity = quantity
          TaxAmount = taxAmount
          UnitCost = unitCost
        }

type Level3 =
    { CustomerReference: string option
      LineItems: Level3LineItems list
      MerchantReference: string
      ShippingAddressZip: string option
      ShippingAmount: int option
      ShippingFromZip: string option }

module Level3 =
    let create
        (
            lineItems: Level3LineItems list,
            merchantReference: string
        ) : Level3
        =
        {
          LineItems = lineItems
          MerchantReference = merchantReference
          CustomerReference = None
          ShippingAddressZip = None
          ShippingAmount = None
          ShippingFromZip = None
        }

