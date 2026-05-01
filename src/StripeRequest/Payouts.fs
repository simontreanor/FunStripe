namespace StripeRequest.Payouts

open FunStripe
open System.Text.Json.Serialization
open Stripe.PaymentMethod
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module Payouts =

    type ListOptions =
        {
            /// Only return payouts that are expected to arrive during the given date interval.
            [<Config.Query>]
            ArrivalDate: int option
            /// Only return payouts that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            /// The ID of an external account - only return payouts sent to this external account.
            [<Config.Query>]
            Destination: string option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Only return payouts that have the given status: `pending`, `paid`, `failed`, or `canceled`.
            [<Config.Query>]
            Status: string option
        }

    type ListOptions with
        static member New(?arrivalDate: int, ?created: int, ?destination: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
            {
                ArrivalDate = arrivalDate
                Created = created
                Destination = destination
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Status = status
            }

    module ListOptions =
        let create
            (
                arrivalDate: int option,
                created: int option,
                destination: string option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option,
                status: string option
            ) : ListOptions
            =
            {
              ArrivalDate = arrivalDate
              Created = created
              Destination = destination
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
              Status = status
            }

    type Create'Method =
        | Instant
        | Standard

    type Create'SourceType =
        | BankAccount
        | Card
        | Fpx

    type CreateOptions =
        {
            /// A positive integer in cents representing how much to payout.
            [<Config.Form>]
            Amount: int
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode
            /// An arbitrary string attached to the object. Often useful for displaying to users.
            [<Config.Form>]
            Description: string option
            /// The ID of a bank account or a card to send the payout to. If you don't provide a destination, we use the default external account for the specified currency.
            [<Config.Form>]
            Destination: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The method used to send this payout, which is `standard` or `instant`. We support `instant` for payouts to debit cards and bank accounts in certain countries. Learn more about [bank support for Instant Payouts](https://stripe.com/docs/payouts/instant-payouts-banks).
            [<Config.Form>]
            Method: Create'Method option
            /// The ID of a v2 FinancialAccount to send funds to.
            [<Config.Form>]
            PayoutMethod: string option
            /// The balance type of your Stripe balance to draw this payout from. Balances for different payment sources are kept separately. You can find the amounts with the Balances API. One of `bank_account`, `card`, or `fpx`.
            [<Config.Form>]
            SourceType: Create'SourceType option
            /// A string that displays on the recipient's bank or card statement (up to 22 characters). A `statement_descriptor` that's longer than 22 characters return an error. Most banks truncate this information and display it inconsistently. Some banks might not display it at all.
            [<Config.Form>]
            StatementDescriptor: string option
        }

    type CreateOptions with
        static member New(amount: int, currency: IsoTypes.IsoCurrencyCode, ?description: string, ?destination: string, ?expand: string list, ?metadata: Map<string, string>, ?method: Create'Method, ?payoutMethod: string, ?sourceType: Create'SourceType, ?statementDescriptor: string) =
            {
                Amount = amount
                Currency = currency
                Description = description
                Destination = destination
                Expand = expand
                Metadata = metadata
                Method = method
                PayoutMethod = payoutMethod
                SourceType = sourceType
                StatementDescriptor = statementDescriptor
            }

    module CreateOptions =
        let create
            (
                amount: int,
                currency: IsoTypes.IsoCurrencyCode
            ) : CreateOptions
            =
            {
              Amount = amount
              Currency = currency
              Description = None
              Destination = None
              Expand = None
              Metadata = None
              Method = None
              PayoutMethod = None
              SourceType = None
              StatementDescriptor = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Payout: string
        }

    type RetrieveOptions with
        static member New(payout: string, ?expand: string list) =
            {
                Payout = payout
                Expand = expand
            }

    module RetrieveOptions =
        let create
            (
                payout: string
            ) : RetrieveOptions
            =
            {
              Payout = payout
              Expand = None
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Payout: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
        }

    type UpdateOptions with
        static member New(payout: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Payout = payout
                Expand = expand
                Metadata = metadata
            }

    module UpdateOptions =
        let create
            (
                payout: string
            ) : UpdateOptions
            =
            {
              Payout = payout
              Expand = None
              Metadata = None
            }

    ///<p>Returns a list of existing payouts sent to third-party bank accounts or payouts that Stripe sent to you. The payouts return in sorted order, with the most recently created payouts appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("arrival_date", options.ArrivalDate |> box); ("created", options.Created |> box); ("destination", options.Destination |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/payouts"
        |> RestApi.getAsync<StripeList<Payout>> settings qs

    ///<p>To send funds to your own bank account, create a new payout object. Your <a href="#balance">Stripe balance</a> must cover the payout amount. If it doesn’t, you receive an “Insufficient Funds” error.</p>
    ///<p>If your API key is in test mode, money won’t actually be sent, though every other action occurs as if you’re in live mode.</p>
    ///<p>If you create a manual payout on a Stripe account that uses multiple payment source types, you need to specify the source type balance that the payout draws from. The <a href="/api/balances/object">balance object</a> details available and pending amounts by source type.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/payouts"
        |> RestApi.postAsync<_, Payout> settings (Map.empty) options

    ///<p>Retrieves the details of an existing payout. Supply the unique payout ID from either a payout creation request or the payout list. Stripe returns the corresponding payout information.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/payouts/{options.Payout}"
        |> RestApi.getAsync<Payout> settings qs

    ///<p>Updates the specified payout by setting the values of the parameters you pass. We don’t change parameters that you don’t provide. This request only accepts the metadata as arguments.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/payouts/{options.Payout}"
        |> RestApi.postAsync<_, Payout> settings (Map.empty) options

module PayoutsCancel =

    type CancelOptions =
        {
            [<Config.Path>]
            Payout: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type CancelOptions with
        static member New(payout: string, ?expand: string list) =
            {
                Payout = payout
                Expand = expand
            }

    module CancelOptions =
        let create
            (
                payout: string
            ) : CancelOptions
            =
            {
              Payout = payout
              Expand = None
            }

    ///<p>You can cancel a previously created payout if its status is <code>pending</code>. Stripe refunds the funds to your available balance. You can’t cancel automatic Stripe payouts.</p>
    let Cancel settings (options: CancelOptions) =
        $"/v1/payouts/{options.Payout}/cancel"
        |> RestApi.postAsync<_, Payout> settings (Map.empty) options

module PayoutsReverse =

    type ReverseOptions =
        {
            [<Config.Path>]
            Payout: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
        }

    type ReverseOptions with
        static member New(payout: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Payout = payout
                Expand = expand
                Metadata = metadata
            }

    module ReverseOptions =
        let create
            (
                payout: string
            ) : ReverseOptions
            =
            {
              Payout = payout
              Expand = None
              Metadata = None
            }

    ///<p>Reverses a payout by debiting the destination bank account. At this time, you can only reverse payouts for connected accounts to US and Canadian bank accounts. If the payout is manual and in the <code>pending</code> status, use <code>/v1/payouts/:id/cancel</code> instead.</p>
    ///<p>By requesting a reversal through <code>/v1/payouts/:id/reverse</code>, you confirm that the authorized signatory of the selected bank account authorizes the debit on the bank account and that no other authorization is required.</p>
    let Reverse settings (options: ReverseOptions) =
        $"/v1/payouts/{options.Payout}/reverse"
        |> RestApi.postAsync<_, Payout> settings (Map.empty) options

