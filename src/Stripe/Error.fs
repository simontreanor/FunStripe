namespace Stripe.Error

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Payment

/// An error response from the Stripe API
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type Error = { Error: ApiErrors }

