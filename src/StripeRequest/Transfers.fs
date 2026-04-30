namespace StripeRequest.Transfers

open FunStripe
open System.Text.Json.Serialization
open Stripe.Payment
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
module Transfers =

    type ListOptions =
        {
            /// Only return transfers that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            /// Only return transfers for the destination specified by this account ID.
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
            /// Only return transfers with the specified transfer group.
            [<Config.Query>]
            TransferGroup: string option
        }

    module ListOptions =
        let create
            (
                created: int option,
                destination: string option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option,
                transferGroup: string option
            ) : ListOptions
            =
            {
              Created = created
              Destination = destination
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
              TransferGroup = transferGroup
            }

    type Create'SourceType =
        | BankAccount
        | Card
        | Fpx

    type CreateOptions =
        {
            /// A positive integer in cents (or local equivalent) representing how much to transfer.
            [<Config.Form>]
            Amount: int option
            /// Three-letter [ISO code for currency](https://www.iso.org/iso-4217-currency-codes.html) in lowercase. Must be a [supported currency](https://docs.stripe.com/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode
            /// An arbitrary string attached to the object. Often useful for displaying to users.
            [<Config.Form>]
            Description: string option
            /// The ID of a connected Stripe account. <a href="/docs/connect/separate-charges-and-transfers">See the Connect documentation</a> for details.
            [<Config.Form>]
            Destination: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// You can use this parameter to transfer funds from a charge before they are added to your available balance. A pending balance will transfer immediately but the funds will not become available until the original charge becomes available. [See the Connect documentation](https://docs.stripe.com/connect/separate-charges-and-transfers#transfer-availability) for details.
            [<Config.Form>]
            SourceTransaction: string option
            /// The source balance to use for this transfer. One of `bank_account`, `card`, or `fpx`. For most users, this will default to `card`.
            [<Config.Form>]
            SourceType: Create'SourceType option
            /// A string that identifies this transaction as part of a group. See the [Connect documentation](https://docs.stripe.com/connect/separate-charges-and-transfers#transfer-options) for details.
            [<Config.Form>]
            TransferGroup: string option
        }

    module CreateOptions =
        let create
            (
                currency: IsoTypes.IsoCurrencyCode,
                destination: string
            ) : CreateOptions
            =
            {
              Currency = currency
              Destination = destination
              Amount = None
              Description = None
              Expand = None
              Metadata = None
              SourceTransaction = None
              SourceType = None
              TransferGroup = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Transfer: string
        }

    module RetrieveOptions =
        let create
            (
                transfer: string
            ) : RetrieveOptions
            =
            {
              Transfer = transfer
              Expand = None
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Transfer: string
            /// An arbitrary string attached to the object. Often useful for displaying to users.
            [<Config.Form>]
            Description: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
        }

    module UpdateOptions =
        let create
            (
                transfer: string
            ) : UpdateOptions
            =
            {
              Transfer = transfer
              Description = None
              Expand = None
              Metadata = None
            }

    ///<p>Returns a list of existing transfers sent to connected accounts. The transfers are returned in sorted order, with the most recently created transfers appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("destination", options.Destination |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("transfer_group", options.TransferGroup |> box)] |> Map.ofList
        $"/v1/transfers"
        |> RestApi.getAsync<StripeList<Transfer>> settings qs

    ///<p>To send funds from your Stripe account to a connected account, you create a new transfer object. Your <a href="#balance">Stripe balance</a> must be able to cover the transfer amount, or you’ll receive an “Insufficient Funds” error.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/transfers"
        |> RestApi.postAsync<_, Transfer> settings (Map.empty) options

    ///<p>Retrieves the details of an existing transfer. Supply the unique transfer ID from either a transfer creation request or the transfer list, and Stripe will return the corresponding transfer information.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/transfers/{options.Transfer}"
        |> RestApi.getAsync<Transfer> settings qs

    ///<p>Updates the specified transfer by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
    ///<p>This request accepts only metadata as an argument.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/transfers/{options.Transfer}"
        |> RestApi.postAsync<_, Transfer> settings (Map.empty) options

module TransfersReversals =

    type ListOptions =
        {
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Id: string
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    module ListOptions =
        let create
            (
                id: string
            ) : ListOptions
            =
            {
              Id = id
              EndingBefore = None
              Expand = None
              Limit = None
              StartingAfter = None
            }

    type CreateOptions =
        {
            [<Config.Path>]
            Id: string
            /// A positive integer in cents (or local equivalent) representing how much of this transfer to reverse. Can only reverse up to the unreversed amount remaining of the transfer. Partial transfer reversals are only allowed for transfers to Stripe Accounts. Defaults to the entire transfer amount.
            [<Config.Form>]
            Amount: int option
            /// An arbitrary string which you can attach to a reversal object. This will be unset if you POST an empty value.
            [<Config.Form>]
            Description: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Boolean indicating whether the application fee should be refunded when reversing this transfer. If a full transfer reversal is given, the full application fee will be refunded. Otherwise, the application fee will be refunded with an amount proportional to the amount of the transfer reversed.
            [<Config.Form>]
            RefundApplicationFee: bool option
        }

    module CreateOptions =
        let create
            (
                id: string
            ) : CreateOptions
            =
            {
              Id = id
              Amount = None
              Description = None
              Expand = None
              Metadata = None
              RefundApplicationFee = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Id: string
            [<Config.Path>]
            Transfer: string
        }

    module RetrieveOptions =
        let create
            (
                id: string,
                transfer: string
            ) : RetrieveOptions
            =
            {
              Id = id
              Transfer = transfer
              Expand = None
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Id: string
            [<Config.Path>]
            Transfer: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
        }

    module UpdateOptions =
        let create
            (
                id: string,
                transfer: string
            ) : UpdateOptions
            =
            {
              Id = id
              Transfer = transfer
              Expand = None
              Metadata = None
            }

    ///<p>You can see a list of the reversals belonging to a specific transfer. Note that the 10 most recent reversals are always available by default on the transfer object. If you need more than those 10, you can use this API method and the <code>limit</code> and <code>starting_after</code> parameters to page through additional reversals.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/transfers/{options.Id}/reversals"
        |> RestApi.getAsync<StripeList<TransferReversal>> settings qs

    ///<p>When you create a new reversal, you must specify a transfer to create it on.</p>
    ///<p>When reversing transfers, you can optionally reverse part of the transfer. You can do so as many times as you wish until the entire transfer has been reversed.</p>
    ///<p>Once entirely reversed, a transfer can’t be reversed again. This method will return an error when called on an already-reversed transfer, or when trying to reverse more money than is left on a transfer.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/transfers/{options.Id}/reversals"
        |> RestApi.postAsync<_, TransferReversal> settings (Map.empty) options

    ///<p>By default, you can see the 10 most recent reversals stored directly on the transfer object, but you can also retrieve details about a specific reversal stored on the transfer.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/transfers/{options.Transfer}/reversals/{options.Id}"
        |> RestApi.getAsync<TransferReversal> settings qs

    ///<p>Updates the specified reversal by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
    ///<p>This request only accepts metadata and description as arguments.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/transfers/{options.Transfer}/reversals/{options.Id}"
        |> RestApi.postAsync<_, TransferReversal> settings (Map.empty) options

