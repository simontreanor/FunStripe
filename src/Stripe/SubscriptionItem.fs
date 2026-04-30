namespace Stripe.SubscriptionItem

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type SubscriptionItemBillingThresholds =
    {
        /// Usage threshold that triggers the subscription to create an invoice
        UsageGte: int option
    }

