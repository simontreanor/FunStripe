namespace StripeRequest.Balance

open FunStripe
open System.Text.Json.Serialization
open Stripe.Balance
open Stripe.Payment
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
module Balance =

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

    ///<p>Retrieves the current account balance, based on the authentication that was used to make the request.
    /// For a sample request, see <a href="/docs/connect/account-balances#accounting-for-negative-balances">Accounting for negative balances</a>.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/balance"
        |> RestApi.getAsync<Balance> settings qs

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

module BalanceTransactions =

    type ListOptions =
        {
            /// Only return transactions that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            /// Only return transactions in a certain currency. Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Query>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// For automatic Stripe payouts only, only returns transactions that were paid out on the specified payout ID.
            [<Config.Query>]
            Payout: string option
            /// Only returns transactions associated with the given object.
            [<Config.Query>]
            Source: string option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Only returns transactions of the given type. One of: `adjustment`, `advance`, `advance_funding`, `anticipation_repayment`, `application_fee`, `application_fee_refund`, `charge`, `climate_order_purchase`, `climate_order_refund`, `connect_collection_transfer`, `contribution`, `inbound_transfer`, `inbound_transfer_reversal`, `issuing_authorization_hold`, `issuing_authorization_release`, `issuing_dispute`, `issuing_transaction`, `obligation_outbound`, `obligation_reversal_inbound`, `payment`, `payment_failure_refund`, `payment_network_reserve_hold`, `payment_network_reserve_release`, `payment_refund`, `payment_reversal`, `payment_unreconciled`, `payout`, `payout_cancel`, `payout_failure`, `payout_minimum_balance_hold`, `payout_minimum_balance_release`, `refund`, `refund_failure`, `reserve_transaction`, `reserved_funds`, `reserve_hold`, `reserve_release`, `stripe_fee`, `stripe_fx_fee`, `stripe_balance_payment_debit`, `stripe_balance_payment_debit_reversal`, `tax_fee`, `topup`, `topup_reversal`, `transfer`, `transfer_cancel`, `transfer_failure`, `transfer_refund`, or `fee_credit_funding`.
            [<Config.Query>]
            Type: string option
        }

    module ListOptions =
        let create
            (
                created: int option,
                currency: IsoTypes.IsoCurrencyCode option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                payout: string option,
                source: string option,
                startingAfter: string option,
                ``type``: string option
            ) : ListOptions
            =
            {
              Created = created
              Currency = currency
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              Payout = payout
              Source = source
              StartingAfter = startingAfter
              Type = ``type``
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Id: string
        }

    module RetrieveOptions =
        let create
            (
                id: string,
                expand: string list option
            ) : RetrieveOptions
            =
            {
              Id = id
              Expand = expand
            }

    ///<p>Returns a list of transactions that have contributed to the Stripe account balance (e.g., charges, transfers, and so forth). The transactions are returned in sorted order, with the most recent transactions appearing first.</p>
    ///<p>Note that this endpoint was previously called “Balance history” and used the path <code>/v1/balance/history</code>.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("currency", options.Currency |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("payout", options.Payout |> box); ("source", options.Source |> box); ("starting_after", options.StartingAfter |> box); ("type", options.Type |> box)] |> Map.ofList
        $"/v1/balance_transactions"
        |> RestApi.getAsync<StripeList<BalanceTransaction>> settings qs

    ///<p>Retrieves the balance transaction with the given ID.</p>
    ///<p>Note that this endpoint previously used the path <code>/v1/balance/history/:id</code>.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/balance_transactions/{options.Id}"
        |> RestApi.getAsync<BalanceTransaction> settings qs

