namespace Stripe.Paypal

open System.Text.Json.Serialization
open FunStripe
open System

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type PaypalSellerProtectionDisputeCategories =
    | Fraudulent
    | ProductNotReceived

[<Struct>]
type PaypalSellerProtectionStatus =
    | Eligible
    | NotEligible
    | PartiallyEligible

type PaypalSellerProtection =
    {
        /// An array of conditions that are covered for the transaction, if applicable.
        DisputeCategories: PaypalSellerProtectionDisputeCategories list option
        /// Indicates whether the transaction is eligible for PayPal's seller protection.
        Status: PaypalSellerProtectionStatus
    }

