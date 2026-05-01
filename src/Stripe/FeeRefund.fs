namespace Stripe.FeeRefund

open System.Text.Json.Serialization
open FunStripe
open System

/// `Application Fee Refund` objects allow you to refund an application fee that
/// has previously been created but not yet refunded. Funds will be refunded to
/// the Stripe account from which the fee was originally collected.
/// Related guide: [Refunding application fees](https://docs.stripe.com/connect/destination-charges#refunding-app-fee)
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type FeeRefund =
    {
        /// Amount, in cents (or local equivalent).
        Amount: int
        /// Balance transaction that describes the impact on your account balance.
        BalanceTransaction: StripeId<Markers.BalanceTransaction> option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// ID of the application fee that was refunded.
        Fee: StripeId<Markers.ApplicationFee>
        /// Unique identifier for the object.
        Id: string
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
    }

type FeeRefund with
    static member New(amount: int, balanceTransaction: StripeId<Markers.BalanceTransaction> option, created: DateTime, currency: IsoTypes.IsoCurrencyCode, fee: StripeId<Markers.ApplicationFee>, id: string, metadata: Map<string, string> option) =
        {
            Amount = amount
            BalanceTransaction = balanceTransaction
            Created = created
            Currency = currency
            Fee = fee
            Id = id
            Metadata = metadata
        }

module FeeRefund =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "fee_refund"

