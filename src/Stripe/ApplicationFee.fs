namespace Stripe.ApplicationFee

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.FeeRefund

/// A list of refunds that have been applied to the fee.
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type ApplicationFeeRefunds =
    {
        /// Details about each object.
        Data: FeeRefund list
        /// True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        /// The URL where this list can be accessed.
        Url: string
    }

module ApplicationFeeRefunds =
    ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
    let object = "list"

[<Struct>]
type PlatformEarningFeeSourceType =
    | Charge
    | Payout

type PlatformEarningFeeSource =
    {
        /// Charge ID that created this application fee.
        Charge: string option
        /// Payout ID that created this application fee.
        Payout: string option
        /// Type of object that created the application fee.
        Type: PlatformEarningFeeSourceType
    }

type ApplicationFee =
    {
        /// ID of the Stripe account this fee was taken from.
        Account: string
        /// Amount earned, in cents (or local equivalent).
        Amount: int
        /// Amount in cents (or local equivalent) refunded (can be less than the amount attribute on the fee if a partial refund was issued)
        AmountRefunded: int
        /// ID of the Connect application that earned the fee.
        Application: string
        /// Balance transaction that describes the impact of this collected application fee on your account balance (not including refunds).
        BalanceTransaction: string option
        /// ID of the charge that the application fee was taken from.
        Charge: string
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// Polymorphic source of the application fee. Includes the ID of the object the application fee was created from.
        FeeSource: PlatformEarningFeeSource option
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// ID of the corresponding charge on the platform account, if this fee was the result of a charge using the `destination` parameter.
        OriginatingTransaction: string option
        /// Whether the fee has been fully refunded. If the fee is only partially refunded, this attribute will still be false.
        Refunded: bool
        /// A list of refunds that have been applied to the fee.
        Refunds: ApplicationFeeRefunds
    }

module ApplicationFee =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "application_fee"

/// Occurs whenever an application fee is refunded, whether from refunding a charge or from [refunding the application fee directly](#fee_refunds). This includes partial refunds.
type ApplicationFeeRefunded = { Object: ApplicationFee }

/// Occurs whenever an application fee refund is updated.
type ApplicationFeeRefundUpdated = { Object: FeeRefund }

/// Occurs whenever an application fee is created on a charge.
type ApplicationFeeCreated = { Object: ApplicationFee }

