namespace Stripe.Topup

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Payment

/// Occurs whenever a top-up succeeds.
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type TopupSucceeded = { Object: Topup }

module TopupSucceeded =
    let create
        (
            object: Topup
        ) : TopupSucceeded
        =
        {
          Object = object
        }

/// Occurs whenever a top-up is reversed.
type TopupReversed = { Object: Topup }

module TopupReversed =
    let create
        (
            object: Topup
        ) : TopupReversed
        =
        {
          Object = object
        }

/// Occurs whenever a top-up fails.
type TopupFailed = { Object: Topup }

module TopupFailed =
    let create
        (
            object: Topup
        ) : TopupFailed
        =
        {
          Object = object
        }

/// Occurs whenever a top-up is created.
type TopupCreated = { Object: Topup }

module TopupCreated =
    let create
        (
            object: Topup
        ) : TopupCreated
        =
        {
          Object = object
        }

/// Occurs whenever a top-up is canceled.
type TopupCanceled = { Object: Topup }

module TopupCanceled =
    let create
        (
            object: Topup
        ) : TopupCanceled
        =
        {
          Object = object
        }

