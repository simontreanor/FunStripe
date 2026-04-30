namespace Stripe.Forwarded

open System.Text.Json.Serialization
open FunStripe
open System

/// Header data.
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type ForwardedRequestHeader =
    {
        /// The header name.
        Name: string
        /// The header value.
        Value: string
    }

