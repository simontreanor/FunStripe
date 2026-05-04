namespace StripeRequest.Balance

open FunStripe
open System.Text.Json.Serialization
open Stripe.Balance
open Stripe.PaymentMethod
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
module Balance =

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    type RetrieveOptions with
        static member New(?expand: string list) =
            {
                Expand = expand
            }

    ///<p>Retrieves the current account balance, based on the authentication that was used to make the request.
    /// For a sample request, see <a href="/docs/connect/account-balances#accounting-for-negative-balances">Accounting for negative balances</a>.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/balance"
        |> RestApi.getAsync<Balance> settings qs

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

    type ListOptions with
        static member New(?created: int, ?currency: IsoTypes.IsoCurrencyCode, ?endingBefore: string, ?expand: string list, ?limit: int, ?payout: string, ?source: string, ?startingAfter: string, ?type': string) =
            {
                Created = created
                Currency = currency
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Payout = payout
                Source = source
                StartingAfter = startingAfter
                Type = type'
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Id: string
        }

    type RetrieveOptions with
        static member New(id: string, ?expand: string list) =
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

