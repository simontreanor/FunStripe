namespace Stripe.Smor

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type SmorResourceManagedPayments =
    {
        /// Set to `true` to enable [Managed Payments](https://docs.stripe.com/payments/managed-payments), Stripe's merchant of record solution, for this session.
        Enabled: bool
    }

module SmorResourceManagedPayments =
    let create
        (
            enabled: bool
        ) : SmorResourceManagedPayments
        =
        {
          Enabled = enabled
        }

