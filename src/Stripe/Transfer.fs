namespace Stripe.Transfer

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.TransferReversal

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type TransferSourceType =
    | Card
    | Fpx
    | BankAccount

/// A `Transfer` object is created when you move funds between Stripe accounts as
/// part of Connect.
/// Before April 6, 2017, transfers also represented movement of funds from a
/// Stripe account to a card or bank account. This behavior has since been split
/// out into a [Payout](https://api.stripe.com#payout_object) object, with corresponding payout endpoints. For more
/// information, read about the
/// [transfer/payout split](https://docs.stripe.com/transfer-payout-split).
/// Related guide: [Creating separate charges and transfers](https://docs.stripe.com/connect/separate-charges-and-transfers)
type Transfer =
    {
        /// Amount in cents (or local equivalent) to be transferred.
        Amount: int
        /// Amount in cents (or local equivalent) reversed (can be less than the amount attribute on the transfer if a partial reversal was issued).
        AmountReversed: int
        /// Balance transaction that describes the impact of this transfer on your account balance.
        BalanceTransaction: StripeId<Markers.BalanceTransaction> option
        /// Time that this record of the transfer was first created.
        Created: DateTime
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        /// ID of the Stripe account the transfer was sent to.
        Destination: StripeId<Markers.Account> option
        /// If the destination is a Stripe account, this will be the ID of the payment that the destination account received for the transfer.
        DestinationPayment: StripeId<Markers.Charge> option
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        /// A list of reversals that have been applied to the transfer.
        Reversals: TransferReversals
        /// Whether the transfer has been fully reversed. If the transfer is only partially reversed, this attribute will still be false.
        Reversed: bool
        /// ID of the charge that was used to fund the transfer. If null, the transfer was funded from the available balance.
        SourceTransaction: StripeId<Markers.Charge> option
        /// The source balance this transfer came from. One of `card`, `fpx`, or `bank_account`.
        SourceType: TransferSourceType option
        /// A string that identifies this transaction as part of a group. See the [Connect documentation](https://docs.stripe.com/connect/separate-charges-and-transfers#transfer-options) for details.
        TransferGroup: string option
    }

type Transfer with
    static member New(amount: int, amountReversed: int, balanceTransaction: StripeId<Markers.BalanceTransaction> option, created: DateTime, currency: IsoTypes.IsoCurrencyCode, description: string option, destination: StripeId<Markers.Account> option, id: string, livemode: bool, metadata: Map<string, string>, reversals: TransferReversals, reversed: bool, sourceTransaction: StripeId<Markers.Charge> option, transferGroup: string option, ?destinationPayment: StripeId<Markers.Charge>, ?sourceType: TransferSourceType) =
        {
            Amount = amount
            AmountReversed = amountReversed
            BalanceTransaction = balanceTransaction
            Created = created
            Currency = currency
            Description = description
            Destination = destination
            Id = id
            Livemode = livemode
            Metadata = metadata
            Reversals = reversals
            Reversed = reversed
            SourceTransaction = sourceTransaction
            TransferGroup = transferGroup
            DestinationPayment = destinationPayment
            SourceType = sourceType
        }

module Transfer =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "transfer"

/// Occurs whenever a transfer's description or metadata is updated.
type TransferUpdated = { Object: Transfer }

type TransferUpdated with
    static member New(object: Transfer) =
        {
            Object = object
        }

/// Occurs whenever a transfer is reversed, including partial reversals.
type TransferReversed = { Object: Transfer }

type TransferReversed with
    static member New(object: Transfer) =
        {
            Object = object
        }

/// Occurs whenever a transfer is created.
type TransferCreated = { Object: Transfer }

type TransferCreated with
    static member New(object: Transfer) =
        {
            Object = object
        }

type TransferData =
    {
        /// The amount transferred to the destination account. This transfer will occur automatically after the payment succeeds. If no amount is specified, by default the entire payment amount is transferred to the destination account.
        ///  The amount must be less than or equal to the [amount](https://docs.stripe.com/api/payment_intents/object#payment_intent_object-amount), and must be a positive integer
        ///  representing how much to transfer in the smallest currency unit (e.g., 100 cents to charge $1.00).
        Amount: int option
        /// The account (if any) that the payment is attributed to for tax reporting, and where funds from the payment are transferred to after payment success.
        Destination: StripeId<Markers.Account>
    }

type TransferData with
    static member New(destination: StripeId<Markers.Account>, ?amount: int) =
        {
            Destination = destination
            Amount = amount
        }

[<Struct>]
type TransferScheduleInterval =
    | Manual
    | Daily
    | Weekly
    | Monthly

[<Struct>]
type TransferScheduleWeeklyPayoutDays =
    | Friday
    | Monday
    | Thursday
    | Tuesday
    | Wednesday

type TransferSchedule =
    {
        /// The number of days charges for the account will be held before being paid out.
        DelayDays: int
        /// How frequently funds will be paid out. One of `manual` (payouts only created via API call), `daily`, `weekly`, or `monthly`.
        Interval: TransferScheduleInterval
        /// The day of the month funds will be paid out. Only shown if `interval` is monthly. Payouts scheduled between the 29th and 31st of the month are sent on the last day of shorter months.
        MonthlyAnchor: int option
        /// The days of the month funds will be paid out. Only shown if `interval` is monthly. Payouts scheduled between the 29th and 31st of the month are sent on the last day of shorter months.
        MonthlyPayoutDays: int list option
        /// The day of the week funds will be paid out, of the style 'monday', 'tuesday', etc. Only shown if `interval` is weekly.
        WeeklyAnchor: string option
        /// The days of the week when available funds are paid out, specified as an array, for example, [`monday`, `tuesday`]. Only shown if `interval` is weekly.
        WeeklyPayoutDays: TransferScheduleWeeklyPayoutDays list option
    }

type TransferSchedule with
    static member New(delayDays: int, interval: TransferScheduleInterval, ?monthlyAnchor: int, ?monthlyPayoutDays: int list, ?weeklyAnchor: string, ?weeklyPayoutDays: TransferScheduleWeeklyPayoutDays list) =
        {
            DelayDays = delayDays
            Interval = interval
            MonthlyAnchor = monthlyAnchor
            MonthlyPayoutDays = monthlyPayoutDays
            WeeklyAnchor = weeklyAnchor
            WeeklyPayoutDays = weeklyPayoutDays
        }

