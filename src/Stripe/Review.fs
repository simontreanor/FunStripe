namespace Stripe.Review

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Radar

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type ReviewClosedReason =
    | Acknowledged
    | Approved
    | Canceled
    | Disputed
    | PaymentNeverSettled
    | Redacted
    | Refunded
    | RefundedAsFraud

[<Struct>]
type ReviewOpenedReason =
    | Manual
    | Rule

type ReviewReason =
    | Rule
    | Manual
    | Approved
    | Refunded
    | RefundedAsFraud
    | Disputed
    | Redacted
    | Canceled
    | PaymentNeverSettled
    | Acknowledged

/// Reviews can be used to supplement automated fraud detection with human expertise.
/// Learn more about [Radar](/radar) and reviewing payments
/// [here](https://docs.stripe.com/radar/reviews).
type Review =
    {
        /// The ZIP or postal code of the card used, if applicable.
        BillingZip: string option
        /// The charge associated with this review.
        Charge: StripeId<Markers.Charge> option
        /// The reason the review was closed, or null if it has not yet been closed. One of `approved`, `refunded`, `refunded_as_fraud`, `disputed`, `redacted`, `canceled`, `payment_never_settled`, or `acknowledged`.
        ClosedReason: ReviewClosedReason option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Unique identifier for the object.
        Id: string
        /// The IP address where the payment originated.
        IpAddress: string option
        /// Information related to the location of the payment. Note that this information is an approximation and attempts to locate the nearest population center - it should not be used to determine a specific address.
        IpAddressLocation: RadarReviewResourceLocation option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// If `true`, the review needs action.
        Open: bool
        /// The reason the review was opened. One of `rule` or `manual`.
        OpenedReason: ReviewOpenedReason
        /// The PaymentIntent ID associated with this review, if one exists.
        PaymentIntent: StripeId<Markers.PaymentIntent> option
        /// The reason the review is currently open or closed. One of `rule`, `manual`, `approved`, `refunded`, `refunded_as_fraud`, `disputed`, `redacted`, `canceled`, `payment_never_settled`, or `acknowledged`.
        Reason: ReviewReason
        /// Information related to the browsing session of the user who initiated the payment.
        Session: RadarReviewResourceSession option
    }

module Review =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "review"

/// Occurs whenever a review is opened.
type ReviewOpened = { Object: Review }

/// Occurs whenever a review is closed. The review's `reason` field indicates why: `approved`, `disputed`, `refunded`, `refunded_as_fraud`, or `canceled`.
type ReviewClosed = { Object: Review }

