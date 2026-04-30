namespace Stripe.Payout

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.PaymentMethod

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type PayoutDestination'AnyOf =
    | String of string
    | ExternalAccount of ExternalAccount
    | DeletedExternalAccount of DeletedExternalAccount

[<Struct>]
type PayoutMethod =
    | Standard
    | Instant

[<Struct>]
type PayoutReconciliationStatus =
    | Completed
    | InProgress
    | NotApplicable

[<Struct>]
type PayoutSourceType =
    | Card
    | Fpx
    | BankAccount

[<Struct>]
type PayoutStatus =
    | Paid
    | Pending
    | InTransit
    | Canceled
    | Failed

[<Struct>]
type PayoutType =
    | BankAccount
    | Card

[<Struct>]
type PayoutsTraceIdStatus =
    | Pending
    | Supported
    | Unsupported

type PayoutsTraceId =
    {
        /// Possible values are `pending`, `supported`, and `unsupported`. When `payout.status` is `pending` or `in_transit`, this will be `pending`. When the payout transitions to `paid`, `failed`, or `canceled`, this status will become `supported` or `unsupported` shortly after in most cases. In some cases, this may appear as `pending` for up to 10 days after `arrival_date` until transitioning to `supported` or `unsupported`.
        Status: PayoutsTraceIdStatus
        /// The trace ID value if `trace_id.status` is `supported`, otherwise `nil`.
        Value: string option
    }

/// A `Payout` object is created when you receive funds from Stripe, or when you
/// initiate a payout to either a bank account or debit card of a [connected
/// Stripe account](/docs/connect/bank-debit-card-payouts). You can retrieve individual payouts,
/// and list all payouts. Payouts are made on [varying
/// schedules](/docs/connect/manage-payout-schedule), depending on your country and
/// industry.
/// Related guide: [Receiving payouts](https://docs.stripe.com/payouts)
type Payout =
    {
        /// The amount (in cents (or local equivalent)) that transfers to your bank account or debit card.
        Amount: int
        /// The application fee (if any) for the payout. [See the Connect documentation](https://docs.stripe.com/connect/instant-payouts#monetization-and-fees) for details.
        ApplicationFee: StripeId<Markers.ApplicationFee> option
        /// The amount of the application fee (if any) requested for the payout. [See the Connect documentation](https://docs.stripe.com/connect/instant-payouts#monetization-and-fees) for details.
        ApplicationFeeAmount: int option
        /// Date that you can expect the payout to arrive in the bank. This factors in delays to account for weekends or bank holidays.
        ArrivalDate: DateTime
        /// Returns `true` if the payout is created by an [automated payout schedule](https://docs.stripe.com/payouts#payout-schedule) and `false` if it's [requested manually](https://stripe.com/docs/payouts#manual-payouts).
        Automatic: bool
        /// ID of the balance transaction that describes the impact of this payout on your account balance.
        BalanceTransaction: StripeId<Markers.BalanceTransaction> option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        /// ID of the bank account or card the payout is sent to.
        Destination: PayoutDestination'AnyOf option
        /// If the payout fails or cancels, this is the ID of the balance transaction that reverses the initial balance transaction and returns the funds from the failed payout back in your balance.
        FailureBalanceTransaction: StripeId<Markers.BalanceTransaction> option
        /// Error code that provides a reason for a payout failure, if available. View our [list of failure codes](https://docs.stripe.com/api#payout_failures).
        FailureCode: string option
        /// Message that provides the reason for a payout failure, if available.
        FailureMessage: string option
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        /// The method used to send this payout, which can be `standard` or `instant`. `instant` is supported for payouts to debit cards and bank accounts in certain countries. Learn more about [bank support for Instant Payouts](https://stripe.com/docs/payouts/instant-payouts-banks).
        Method: PayoutMethod
        /// If the payout reverses another, this is the ID of the original payout.
        OriginalPayout: StripeId<Markers.Payout> option
        /// ID of the v2 FinancialAccount the funds are sent to.
        PayoutMethod: string option
        /// If `completed`, you can use the [Balance Transactions API](https://docs.stripe.com/api/balance_transactions/list#balance_transaction_list-payout) to list all balance transactions that are paid out in this payout.
        ReconciliationStatus: PayoutReconciliationStatus
        /// If the payout reverses, this is the ID of the payout that reverses this payout.
        ReversedBy: StripeId<Markers.Payout> option
        /// The source balance this payout came from, which can be one of the following: `card`, `fpx`, or `bank_account`.
        SourceType: PayoutSourceType
        /// Extra information about a payout that displays on the user's bank statement.
        StatementDescriptor: string option
        /// Current status of the payout: `paid`, `pending`, `in_transit`, `canceled` or `failed`. A payout is `pending` until it's submitted to the bank, when it becomes `in_transit`. The status changes to `paid` if the transaction succeeds, or to `failed` or `canceled` (within 5 business days). Some payouts that fail might initially show as `paid`, then change to `failed`.
        Status: PayoutStatus
        /// A value that generates from the beneficiary's bank that allows users to track payouts with their bank. Banks might call this a "reference number" or something similar.
        TraceId: PayoutsTraceId option
        /// Can be `bank_account` or `card`.
        Type: PayoutType
    }

module Payout =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "payout"

/// Occurs whenever a payout is updated.
type PayoutUpdated = { Object: Payout }

/// Occurs whenever balance transactions paid out in an automatic payout can be queried.
type PayoutReconciliationCompleted = { Object: Payout }

/// Occurs whenever a payout is *expected* to be available in the destination account. If the payout fails, a `payout.failed` notification is also sent, at a later time.
type PayoutPaid = { Object: Payout }

/// Occurs whenever a payout attempt fails.
type PayoutFailed = { Object: Payout }

/// Occurs whenever a payout is created.
type PayoutCreated = { Object: Payout }

/// Occurs whenever a payout is canceled.
type PayoutCanceled = { Object: Payout }

