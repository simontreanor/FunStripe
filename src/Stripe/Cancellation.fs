namespace Stripe.Cancellation

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type CancellationDetailsFeedback =
    | CustomerService
    | LowQuality
    | MissingFeatures
    | Other
    | SwitchedService
    | TooComplex
    | TooExpensive
    | Unused

[<Struct>]
type CancellationDetailsReason =
    | CanceledByRetentionPolicy
    | CancellationRequested
    | PaymentDisputed
    | PaymentFailed

type CancellationDetails =
    {
        /// Additional comments about why the user canceled the subscription, if the subscription was canceled explicitly by the user.
        Comment: string option
        /// The customer submitted reason for why they canceled, if the subscription was canceled explicitly by the user.
        Feedback: CancellationDetailsFeedback option
        /// Why this subscription was canceled.
        Reason: CancellationDetailsReason option
    }

module CancellationDetails =
    let create
        (
            comment: string option,
            feedback: CancellationDetailsFeedback option,
            reason: CancellationDetailsReason option
        ) : CancellationDetails
        =
        {
          Comment = comment
          Feedback = feedback
          Reason = reason
        }

