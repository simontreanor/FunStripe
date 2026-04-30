namespace Stripe.Custom

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type CustomUnitAmount =
    {
        /// The maximum unit amount the customer can specify for this item.
        Maximum: int option
        /// The minimum unit amount the customer can specify for this item. Must be at least the minimum charge amount.
        Minimum: int option
        /// The starting unit amount which can be updated by the customer.
        Preset: int option
    }

type CustomLogo =
    {
        /// Content type of the Dashboard-only CustomPaymentMethodType logo.
        ContentType: string option
        /// URL of the Dashboard-only CustomPaymentMethodType logo.
        Url: string
    }

