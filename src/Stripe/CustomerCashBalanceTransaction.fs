namespace Stripe.CustomerCashBalanceTransaction

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.PaymentMethod

/// Occurs whenever a new customer cash balance transactions is created.
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type CustomerCashBalanceTransactionCreated =
    { Object: CustomerCashBalanceTransaction }

