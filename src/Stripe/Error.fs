namespace Stripe.Error

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.PaymentMethod

/// An error response from the Stripe API
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
type Error = { Error: ApiErrors }

type Error with
    static member New(error: ApiErrors) =
        {
            Error = error
        }

