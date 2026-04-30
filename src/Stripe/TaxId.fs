namespace Stripe.TaxId

open System.Text.Json.Serialization
open FunStripe
open System

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type TaxIdVerificationStatus =
    | Pending
    | Unavailable
    | Unverified
    | Verified

type TaxIdVerification =
    {
        /// Verification status, one of `pending`, `verified`, `unverified`, or `unavailable`.
        Status: TaxIdVerificationStatus
        /// Verified address.
        VerifiedAddress: string option
        /// Verified name.
        VerifiedName: string option
    }

