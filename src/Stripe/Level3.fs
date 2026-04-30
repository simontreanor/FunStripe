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

type Level3 =
    { CustomerReference: string option
      LineItems: Level3LineItems list
      MerchantReference: string
      ShippingAddressZip: string option
      ShippingAmount: int option
      ShippingFromZip: string option }

