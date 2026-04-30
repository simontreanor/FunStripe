namespace Stripe.Discount

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Coupon

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type DiscountSourceCoupon'AnyOf =
    | String of string
    | Coupon of Coupon

type DiscountSource =
    {
        /// The coupon that was redeemed to create this discount.
        Coupon: DiscountSourceCoupon'AnyOf option
    }

module DiscountSource =
    ///The source type of the discount.
    let ``type`` = "coupon"

