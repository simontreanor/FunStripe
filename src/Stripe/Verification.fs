namespace Stripe.Verification

open System.Text.Json.Serialization
open FunStripe
open System

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type VerificationSessionRedactionStatus =
    | Processing
    | Redacted

type VerificationSessionRedaction =
    {
        /// Indicates whether this object and its related objects have been redacted or not.
        Status: VerificationSessionRedactionStatus
    }

module VerificationSessionRedaction =
    let create
        (
            status: VerificationSessionRedactionStatus
        ) : VerificationSessionRedaction
        =
        {
          Status = status
        }

