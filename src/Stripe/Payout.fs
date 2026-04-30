namespace Stripe.Payout

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.PaymentMethod

/// Occurs whenever a payout is updated.
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type PayoutUpdated = { Object: Payout }

/// Occurs whenever balance transactions paid out in an automatic payout can be queried.
type PayoutReconciliationCompleted = { Object: Payout }

/// Occurs whenever a payout is *expected* to be available in the destination account. If the payout fails, a `payout.failed` notification is also sent, at a later time.
type PayoutPaid = { Object: Payout }

/// Occurs whenever a payout attempt fails.
type PayoutFailed = { Object: Payout }

/// Occurs whenever a payout is created.
type PayoutCreated = { Object: Payout }

/// Occurs whenever a payout is canceled.
type PayoutCanceled = { Object: Payout }

