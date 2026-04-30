namespace Stripe.Platform

open System.Text.Json.Serialization
open FunStripe
open System

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type PlatformEarningFeeSourceType =
    | Charge
    | Payout

type PlatformEarningFeeSource =
    {
        /// Charge ID that created this application fee.
        Charge: string option
        /// Payout ID that created this application fee.
        Payout: string option
        /// Type of object that created the application fee.
        Type: PlatformEarningFeeSourceType
    }

module PlatformEarningFeeSource =
    let create
        (
            ``type``: PlatformEarningFeeSourceType,
            charge: string option,
            payout: string option
        ) : PlatformEarningFeeSource
        =
        {
          Type = ``type``
          Charge = charge
          Payout = payout
        }

