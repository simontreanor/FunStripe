namespace Stripe.Payout

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Payment

/// Occurs whenever a payout is updated.
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type PayoutUpdated = { Object: Payout }

module PayoutUpdated =
    let create
        (
            object: Payout
        ) : PayoutUpdated
        =
        {
          Object = object
        }

/// Occurs whenever balance transactions paid out in an automatic payout can be queried.
type PayoutReconciliationCompleted = { Object: Payout }

module PayoutReconciliationCompleted =
    let create
        (
            object: Payout
        ) : PayoutReconciliationCompleted
        =
        {
          Object = object
        }

/// Occurs whenever a payout is *expected* to be available in the destination account. If the payout fails, a `payout.failed` notification is also sent, at a later time.
type PayoutPaid = { Object: Payout }

module PayoutPaid =
    let create
        (
            object: Payout
        ) : PayoutPaid
        =
        {
          Object = object
        }

/// Occurs whenever a payout attempt fails.
type PayoutFailed = { Object: Payout }

module PayoutFailed =
    let create
        (
            object: Payout
        ) : PayoutFailed
        =
        {
          Object = object
        }

/// Occurs whenever a payout is created.
type PayoutCreated = { Object: Payout }

module PayoutCreated =
    let create
        (
            object: Payout
        ) : PayoutCreated
        =
        {
          Object = object
        }

/// Occurs whenever a payout is canceled.
type PayoutCanceled = { Object: Payout }

module PayoutCanceled =
    let create
        (
            object: Payout
        ) : PayoutCanceled
        =
        {
          Object = object
        }

