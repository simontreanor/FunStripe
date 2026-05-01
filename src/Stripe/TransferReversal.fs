namespace Stripe.TransferReversal

open System.Text.Json.Serialization
open FunStripe
open System

/// [Stripe Connect](https://docs.stripe.com/connect) platforms can reverse transfers made to a
/// connected account, either entirely or partially, and can also specify whether
/// to refund any related application fees. Transfer reversals add to the
/// platform's balance and subtract from the destination account's balance.
/// Reversing a transfer that was made for a [destination
/// charge](/docs/connect/destination-charges) is allowed only up to the amount of
/// the charge. It is possible to reverse a
/// [transfer_group](https://docs.stripe.com/connect/separate-charges-and-transfers#transfer-options)
/// transfer only if the destination account has enough balance to cover the
/// reversal.
/// Related guide: [Reverse transfers](https://docs.stripe.com/connect/separate-charges-and-transfers#reverse-transfers)
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
type TransferReversal =
    {
        /// Amount, in cents (or local equivalent).
        Amount: int
        /// Balance transaction that describes the impact on your account balance.
        BalanceTransaction: StripeId<Markers.BalanceTransaction> option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// Linked payment refund for the transfer reversal.
        DestinationPaymentRefund: StripeId<Markers.Refund> option
        /// Unique identifier for the object.
        Id: string
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        /// ID of the refund responsible for the transfer reversal.
        SourceRefund: StripeId<Markers.Refund> option
        /// ID of the transfer that was reversed.
        Transfer: StripeId<Markers.Transfer>
    }

type TransferReversal with
    static member New(amount: int, balanceTransaction: StripeId<Markers.BalanceTransaction> option, created: DateTime, currency: IsoTypes.IsoCurrencyCode, destinationPaymentRefund: StripeId<Markers.Refund> option, id: string, metadata: Map<string, string> option, sourceRefund: StripeId<Markers.Refund> option, transfer: StripeId<Markers.Transfer>) =
        {
            Amount = amount
            BalanceTransaction = balanceTransaction
            Created = created
            Currency = currency
            DestinationPaymentRefund = destinationPaymentRefund
            Id = id
            Metadata = metadata
            SourceRefund = sourceRefund
            Transfer = transfer
        }

module TransferReversal =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "transfer_reversal"

/// A list of reversals that have been applied to the transfer.
type TransferReversals =
    {
        /// Details about each object.
        Data: TransferReversal list
        /// True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        /// The URL where this list can be accessed.
        Url: string
    }

type TransferReversals with
    static member New(data: TransferReversal list, hasMore: bool, url: string) =
        {
            Data = data
            HasMore = hasMore
            Url = url
        }

module TransferReversals =
    ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
    let object = "list"

