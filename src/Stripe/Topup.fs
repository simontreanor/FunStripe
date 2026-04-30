namespace Stripe.Topup

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.PaymentMethod

/// Occurs whenever a top-up succeeds.
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type TopupSucceeded = { Object: Topup }

/// Occurs whenever a top-up is reversed.
type TopupReversed = { Object: Topup }

/// Occurs whenever a top-up fails.
type TopupFailed = { Object: Topup }

/// Occurs whenever a top-up is created.
type TopupCreated = { Object: Topup }

/// Occurs whenever a top-up is canceled.
type TopupCanceled = { Object: Topup }

