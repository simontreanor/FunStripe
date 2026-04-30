namespace Stripe.Received

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type ReceivedPaymentMethodDetailsFinancialAccount =
    {
        /// The FinancialAccount ID.
        Id: string
    }

module ReceivedPaymentMethodDetailsFinancialAccount =
    ///The rails the ReceivedCredit was sent over. A FinancialAccount can only send funds over `stripe`.
    let network = "stripe"

