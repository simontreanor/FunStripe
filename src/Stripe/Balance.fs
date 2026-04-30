namespace Stripe.Balance

open System.Text.Json.Serialization
open FunStripe
open System

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type BalanceSettingsResourcePayoutScheduleInterval =
    | Daily
    | Manual
    | Monthly
    | Weekly

[<Struct>]
type BalanceSettingsResourcePayoutScheduleWeeklyPayoutDays =
    | Friday
    | Monday
    | Thursday
    | Tuesday
    | Wednesday

type BalanceSettingsResourcePayoutSchedule =
    {
        /// How frequently funds will be paid out. One of `manual` (payouts only created via API call), `daily`, `weekly`, or `monthly`.
        Interval: BalanceSettingsResourcePayoutScheduleInterval option
        /// The day of the month funds will be paid out. Only shown if `interval` is monthly. Payouts scheduled between the 29th and 31st of the month are sent on the last day of shorter months.
        MonthlyPayoutDays: int list option
        /// The days of the week when available funds are paid out, specified as an array, for example, [`monday`, `tuesday`]. Only shown if `interval` is weekly.
        WeeklyPayoutDays: BalanceSettingsResourcePayoutScheduleWeeklyPayoutDays list option
    }

module BalanceSettingsResourcePayoutSchedule =
    let create
        (
            interval: BalanceSettingsResourcePayoutScheduleInterval option,
            monthlyPayoutDays: int list option,
            weeklyPayoutDays: BalanceSettingsResourcePayoutScheduleWeeklyPayoutDays list option
        ) : BalanceSettingsResourcePayoutSchedule
        =
        {
          Interval = interval
          MonthlyPayoutDays = monthlyPayoutDays
          WeeklyPayoutDays = weeklyPayoutDays
        }

[<Struct>]
type BalanceSettingsResourcePayoutsStatus =
    | Disabled
    | Enabled

type BalanceSettingsResourcePayouts =
    {
        /// The minimum balance amount to retain per currency after automatic payouts. Only funds that exceed these amounts are paid out. Learn more about the [minimum balances for automatic payouts](/payouts/minimum-balances-for-automatic-payouts).
        MinimumBalanceByCurrency: Map<string, string list> option
        /// Details on when funds from charges are available, and when they are paid out to an external account. See our [Setting Bank and Debit Card Payouts](https://docs.stripe.com/connect/bank-transfers#payout-information) documentation for details.
        Schedule: BalanceSettingsResourcePayoutSchedule option
        /// The text that appears on the bank account statement for payouts. If not set, this defaults to the platform's bank descriptor as set in the Dashboard.
        StatementDescriptor: string option
        /// Whether the funds in this account can be paid out.
        Status: BalanceSettingsResourcePayoutsStatus
    }

module BalanceSettingsResourcePayouts =
    let create
        (
            minimumBalanceByCurrency: Map<string, string list> option,
            schedule: BalanceSettingsResourcePayoutSchedule option,
            statementDescriptor: string option,
            status: BalanceSettingsResourcePayoutsStatus
        ) : BalanceSettingsResourcePayouts
        =
        {
          MinimumBalanceByCurrency = minimumBalanceByCurrency
          Schedule = schedule
          StatementDescriptor = statementDescriptor
          Status = status
        }

type BalanceSettingsResourceSettlementTiming =
    {
        /// The number of days charge funds are held before becoming available.
        DelayDays: int
        /// The number of days charge funds are held before becoming available. If present, overrides the default, or minimum available, for the account.
        DelayDaysOverride: int option
    }

module BalanceSettingsResourceSettlementTiming =
    let create
        (
            delayDays: int,
            delayDaysOverride: int option
        ) : BalanceSettingsResourceSettlementTiming
        =
        {
          DelayDays = delayDays
          DelayDaysOverride = delayDaysOverride
        }

type BalanceSettingsResourcePayments =
    {
        /// A Boolean indicating if Stripe should try to reclaim negative balances from an attached bank account. See [Understanding Connect account balances](/connect/account-balances) for details. The default value is `false` when [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts, otherwise `true`.
        DebitNegativeBalances: bool option
        /// Settings specific to the account's payouts.
        Payouts: BalanceSettingsResourcePayouts option
        SettlementTiming: BalanceSettingsResourceSettlementTiming
    }

module BalanceSettingsResourcePayments =
    let create
        (
            debitNegativeBalances: bool option,
            payouts: BalanceSettingsResourcePayouts option,
            settlementTiming: BalanceSettingsResourceSettlementTiming
        ) : BalanceSettingsResourcePayments
        =
        {
          DebitNegativeBalances = debitNegativeBalances
          Payouts = payouts
          SettlementTiming = settlementTiming
        }

/// Options for customizing account balances and payout settings for a Stripe platform’s connected accounts.
type BalanceSettings =
    { Payments: BalanceSettingsResourcePayments }

module BalanceSettings =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "balance_settings"

    let create
        (
            payments: BalanceSettingsResourcePayments
        ) : BalanceSettings
        =
        {
          Payments = payments
        }

/// Occurs whenever a balance settings status or property has changed.
type BalanceSettingsUpdated = { Object: BalanceSettings }

module BalanceSettingsUpdated =
    let create
        (
            object: BalanceSettings
        ) : BalanceSettingsUpdated
        =
        {
          Object = object
        }

type BalanceAmountBySourceType =
    {
        /// Amount coming from [legacy US ACH payments](https://docs.stripe.com/ach-deprecated).
        BankAccount: int option
        /// Amount coming from most payment methods, including cards as well as [non-legacy bank debits](https://docs.stripe.com/payments/bank-debits).
        Card: int option
        /// Amount coming from [FPX](https://docs.stripe.com/payments/fpx), a Malaysian payment method.
        Fpx: int option
    }

module BalanceAmountBySourceType =
    let create
        (
            bankAccount: int option,
            card: int option,
            fpx: int option
        ) : BalanceAmountBySourceType
        =
        {
          BankAccount = bankAccount
          Card = card
          Fpx = fpx
        }

type BalanceAmount =
    {
        /// Balance amount.
        Amount: int
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        SourceTypes: BalanceAmountBySourceType option
    }

module BalanceAmount =
    let create
        (
            amount: int,
            currency: IsoTypes.IsoCurrencyCode,
            sourceTypes: BalanceAmountBySourceType option
        ) : BalanceAmount
        =
        {
          Amount = amount
          Currency = currency
          SourceTypes = sourceTypes
        }

type BalanceNetAvailable =
    {
        /// Net balance amount, subtracting fees from platform-set pricing.
        Amount: int
        /// ID of the external account for this net balance (not expandable).
        Destination: string
        SourceTypes: BalanceAmountBySourceType option
    }

module BalanceNetAvailable =
    let create
        (
            amount: int,
            destination: string,
            sourceTypes: BalanceAmountBySourceType option
        ) : BalanceNetAvailable
        =
        {
          Amount = amount
          Destination = destination
          SourceTypes = sourceTypes
        }

type BalanceAmountNet =
    {
        /// Balance amount.
        Amount: int
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// Breakdown of balance by destination.
        NetAvailable: BalanceNetAvailable list option
        SourceTypes: BalanceAmountBySourceType option
    }

module BalanceAmountNet =
    let create
        (
            amount: int,
            currency: IsoTypes.IsoCurrencyCode,
            netAvailable: BalanceNetAvailable list option,
            sourceTypes: BalanceAmountBySourceType option
        ) : BalanceAmountNet
        =
        {
          Amount = amount
          Currency = currency
          NetAvailable = netAvailable
          SourceTypes = sourceTypes
        }

type BalanceDetail =
    {
        /// Funds that are available for use.
        Available: BalanceAmount list
    }

module BalanceDetail =
    let create
        (
            available: BalanceAmount list
        ) : BalanceDetail
        =
        {
          Available = available
        }

type BalanceDetailUngated =
    {
        /// Funds that are available for use.
        Available: BalanceAmount list
        /// Funds that are pending
        Pending: BalanceAmount list
    }

module BalanceDetailUngated =
    let create
        (
            available: BalanceAmount list,
            pending: BalanceAmount list
        ) : BalanceDetailUngated
        =
        {
          Available = available
          Pending = pending
        }

/// This is an object representing your Stripe balance. You can retrieve it to see
/// the balance currently on your Stripe account.
/// The top-level `available` and `pending` comprise your "payments balance."
/// Related guide: [Balances and settlement time](https://docs.stripe.com/payments/balances), [Understanding Connect account balances](https://docs.stripe.com/connect/account-balances)
type Balance =
    {
        /// Available funds that you can transfer or pay out automatically by Stripe or explicitly through the [Transfers API](https://api.stripe.com#transfers) or [Payouts API](https://api.stripe.com#payouts). You can find the available balance for each currency and payment type in the `source_types` property.
        Available: BalanceAmount list
        /// Funds held due to negative balances on connected accounts where [account.controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts. You can find the connect reserve balance for each currency and payment type in the `source_types` property.
        ConnectReserved: BalanceAmount list option
        /// Funds that you can pay out using Instant Payouts.
        InstantAvailable: BalanceAmountNet list option
        Issuing: BalanceDetail option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Funds that aren't available in the balance yet. You can find the pending balance for each currency and each payment type in the `source_types` property.
        Pending: BalanceAmount list
        RefundAndDisputePrefunding: BalanceDetailUngated option
    }

module Balance =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "balance"

    let create
        (
            available: BalanceAmount list,
            livemode: bool,
            pending: BalanceAmount list,
            connectReserved: BalanceAmount list option,
            instantAvailable: BalanceAmountNet list option,
            issuing: BalanceDetail option,
            refundAndDisputePrefunding: BalanceDetailUngated option
        ) : Balance
        =
        {
          Available = available
          Livemode = livemode
          Pending = pending
          ConnectReserved = connectReserved
          InstantAvailable = instantAvailable
          Issuing = issuing
          RefundAndDisputePrefunding = refundAndDisputePrefunding
        }

/// Occurs whenever your Stripe balance has been updated (e.g., when a charge is available to be paid out). By default, Stripe automatically transfers funds in your balance to your bank account on a daily basis. This event is not fired for negative transactions.
type BalanceAvailable = { Object: Balance }

module BalanceAvailable =
    let create
        (
            object: Balance
        ) : BalanceAvailable
        =
        {
          Object = object
        }

