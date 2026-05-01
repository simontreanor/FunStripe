namespace Stripe.BalanceSettings

open System.Text.Json.Serialization
open FunStripe
open System

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
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

type BalanceSettingsResourcePayoutSchedule with
    static member New(interval: BalanceSettingsResourcePayoutScheduleInterval option, ?monthlyPayoutDays: int list, ?weeklyPayoutDays: BalanceSettingsResourcePayoutScheduleWeeklyPayoutDays list) =
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

type BalanceSettingsResourcePayouts with
    static member New(minimumBalanceByCurrency: Map<string, string list> option, schedule: BalanceSettingsResourcePayoutSchedule option, statementDescriptor: string option, status: BalanceSettingsResourcePayoutsStatus) =
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

type BalanceSettingsResourceSettlementTiming with
    static member New(delayDays: int, ?delayDaysOverride: int) =
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

type BalanceSettingsResourcePayments with
    static member New(debitNegativeBalances: bool option, payouts: BalanceSettingsResourcePayouts option, settlementTiming: BalanceSettingsResourceSettlementTiming) =
        {
            DebitNegativeBalances = debitNegativeBalances
            Payouts = payouts
            SettlementTiming = settlementTiming
        }

/// Options for customizing account balances and payout settings for a Stripe platform’s connected accounts.
type BalanceSettings =
    { Payments: BalanceSettingsResourcePayments }

type BalanceSettings with
    static member New(payments: BalanceSettingsResourcePayments) =
        {
            Payments = payments
        }

module BalanceSettings =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "balance_settings"

/// Occurs whenever a balance settings status or property has changed.
type BalanceSettingsUpdated = { Object: BalanceSettings }

type BalanceSettingsUpdated with
    static member New(object: BalanceSettings) =
        {
            Object = object
        }

