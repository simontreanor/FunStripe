namespace Stripe.Review

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Payment

/// Occurs whenever a review is opened.
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type ReviewOpened = { Object: Review }

module ReviewOpened =
    let create
        (
            object: Review
        ) : ReviewOpened
        =
        {
          Object = object
        }

/// Occurs whenever a review is closed. The review's `reason` field indicates why: `approved`, `disputed`, `refunded`, `refunded_as_fraud`, or `canceled`.
type ReviewClosed = { Object: Review }

module ReviewClosed =
    let create
        (
            object: Review
        ) : ReviewClosed
        =
        {
          Object = object
        }

[<Struct>]
type ReviewOpenedReason =
    | Manual
    | Rule

type ReviewClosedReason =
    | Acknowledged
    | Approved
    | Canceled
    | Disputed
    | PaymentNeverSettled
    | Redacted
    | Refunded
    | RefundedAsFraud

