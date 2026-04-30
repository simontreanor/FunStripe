namespace Stripe.Level3

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type Level3LineItems =
    { DiscountAmount: int option
      ProductCode: string
      ProductDescription: string
      Quantity: int option
      TaxAmount: int option
      UnitCost: int option }

