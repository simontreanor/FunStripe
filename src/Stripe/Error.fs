namespace Stripe.Error

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.PaymentMethod

/// An error response from the Stripe API
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type Error = { Error: ApiErrors }

