namespace Stripe.Proration

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Payment

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type ProrationDetails =
    {
        /// Discount amounts applied when the proration was created.
        DiscountAmounts: DiscountsResourceDiscountAmount list
    }

