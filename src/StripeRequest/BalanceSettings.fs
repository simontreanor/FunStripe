namespace StripeRequest.BalanceSettings

open FunStripe
open System.Text.Json.Serialization
open Stripe.BalanceSettings
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module BalanceSettings =

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    module RetrieveOptions =
        let create
            (
                expand: string list option
            ) : RetrieveOptions
            =
            {
              Expand = expand
            }

    type Update'PaymentsPayoutsScheduleInterval =
        | Daily
        | Manual
        | Monthly
        | Weekly

    type Update'PaymentsPayoutsScheduleWeeklyPayoutDays =
        | Friday
        | Monday
        | Thursday
        | Tuesday
        | Wednesday

    type Update'PaymentsPayoutsSchedule =
        {
            /// How frequently available funds are paid out. One of: `daily`, `manual`, `weekly`, or `monthly`. Default is `daily`.
            [<Config.Form>]
            Interval: Update'PaymentsPayoutsScheduleInterval option
            /// The days of the month when available funds are paid out, specified as an array of numbers between 1--31. Payouts nominally scheduled between the 29th and 31st of the month are instead sent on the last day of a shorter month. Required and applicable only if `interval` is `monthly`.
            [<Config.Form>]
            MonthlyPayoutDays: int list option
            /// The days of the week when available funds are paid out, specified as an array, e.g., [`monday`, `tuesday`]. Required and applicable only if `interval` is `weekly`.
            [<Config.Form>]
            WeeklyPayoutDays: Update'PaymentsPayoutsScheduleWeeklyPayoutDays list option
        }

    module Update'PaymentsPayoutsSchedule =
        let create
            (
                interval: Update'PaymentsPayoutsScheduleInterval option,
                monthlyPayoutDays: int list option,
                weeklyPayoutDays: Update'PaymentsPayoutsScheduleWeeklyPayoutDays list option
            ) : Update'PaymentsPayoutsSchedule
            =
            {
              Interval = interval
              MonthlyPayoutDays = monthlyPayoutDays
              WeeklyPayoutDays = weeklyPayoutDays
            }

    type Update'PaymentsPayouts =
        {
            /// The minimum balance amount to retain per currency after automatic payouts. Only funds that exceed these amounts are paid out. Learn more about the [minimum balances for automatic payouts](/payouts/minimum-balances-for-automatic-payouts).
            [<Config.Form>]
            MinimumBalanceByCurrency: Choice<Map<string, string>,string> option
            /// Details on when funds from charges are available, and when they are paid out to an external account. For details, see our [Setting Bank and Debit Card Payouts](/connect/bank-transfers#payout-information) documentation.
            [<Config.Form>]
            Schedule: Update'PaymentsPayoutsSchedule option
            /// The text that appears on the bank account statement for payouts. If not set, this defaults to the platform's bank descriptor as set in the Dashboard.
            [<Config.Form>]
            StatementDescriptor: string option
        }

    module Update'PaymentsPayouts =
        let create
            (
                minimumBalanceByCurrency: Choice<Map<string, string>,string> option,
                schedule: Update'PaymentsPayoutsSchedule option,
                statementDescriptor: string option
            ) : Update'PaymentsPayouts
            =
            {
              MinimumBalanceByCurrency = minimumBalanceByCurrency
              Schedule = schedule
              StatementDescriptor = statementDescriptor
            }

    type Update'PaymentsSettlementTiming =
        {
            /// Change `delay_days` for this account, which determines the number of days charge funds are held before becoming available. The maximum value is 31. Passing an empty string to `delay_days_override` will return `delay_days` to the default, which is the lowest available value for the account. [Learn more about controlling delay days](/connect/manage-payout-schedule).
            [<Config.Form>]
            DelayDaysOverride: Choice<int,string> option
        }

    module Update'PaymentsSettlementTiming =
        let create
            (
                delayDaysOverride: Choice<int,string> option
            ) : Update'PaymentsSettlementTiming
            =
            {
              DelayDaysOverride = delayDaysOverride
            }

    type Update'Payments =
        {
            /// A Boolean indicating whether Stripe should try to reclaim negative balances from an attached bank account. For details, see [Understanding Connect Account Balances](/connect/account-balances).
            [<Config.Form>]
            DebitNegativeBalances: bool option
            /// Settings specific to the account's payouts.
            [<Config.Form>]
            Payouts: Update'PaymentsPayouts option
            /// Settings related to the account's balance settlement timing.
            [<Config.Form>]
            SettlementTiming: Update'PaymentsSettlementTiming option
        }

    module Update'Payments =
        let create
            (
                debitNegativeBalances: bool option,
                payouts: Update'PaymentsPayouts option,
                settlementTiming: Update'PaymentsSettlementTiming option
            ) : Update'Payments
            =
            {
              DebitNegativeBalances = debitNegativeBalances
              Payouts = payouts
              SettlementTiming = settlementTiming
            }

    type UpdateOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Settings that apply to the [Payments Balance](https://docs.stripe.com/api/balance).
            [<Config.Form>]
            Payments: Update'Payments option
        }

    module UpdateOptions =
        let create
            (
                expand: string list option,
                payments: Update'Payments option
            ) : UpdateOptions
            =
            {
              Expand = expand
              Payments = payments
            }

    ///<p>Retrieves balance settings for a given connected account.
    /// Related guide: <a href="/connect/authentication">Making API calls for connected accounts</a></p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/balance_settings"
        |> RestApi.getAsync<BalanceSettings> settings qs

    ///<p>Updates balance settings for a given connected account.
    /// Related guide: <a href="/connect/authentication">Making API calls for connected accounts</a></p>
    let Update settings (options: UpdateOptions) =
        $"/v1/balance_settings"
        |> RestApi.postAsync<_, BalanceSettings> settings (Map.empty) options

