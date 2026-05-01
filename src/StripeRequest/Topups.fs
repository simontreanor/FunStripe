namespace StripeRequest.Topups

open FunStripe
open System.Text.Json.Serialization
open Stripe.PaymentMethod
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module Topups =

    type ListOptions =
        {
            /// A positive integer representing how much to transfer.
            [<Config.Query>]
            Amount: int option
            /// A filter on the list, based on the object `created` field. The value can be a string with an integer Unix timestamp, or it can be a dictionary with a number of different query options.
            [<Config.Query>]
            Created: int option
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
            /// Only return top-ups that have the given status. One of `canceled`, `failed`, `pending` or `succeeded`.
            [<Config.Query>]
            Status: string option
        }

    type ListOptions with
        static member New(?amount: int, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
            {
                Amount = amount
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Status = status
            }

    module ListOptions =
        let create
            (
                amount: int option,
                created: int option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option,
                status: string option
            ) : ListOptions
            =
            {
              Amount = amount
              Created = created
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
              Status = status
            }

    type CreateOptions =
        {
            /// A positive integer representing how much to transfer.
            [<Config.Form>]
            Amount: int
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode
            /// An arbitrary string attached to the object. Often useful for displaying to users.
            [<Config.Form>]
            Description: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The ID of a source to transfer funds from. For most users, this should be left unspecified which will use the bank account that was set up in the dashboard for the specified currency. In test mode, this can be a test bank token (see [Testing Top-ups](https://docs.stripe.com/connect/testing#testing-top-ups)).
            [<Config.Form>]
            Source: string option
            /// Extra information about a top-up for the source's bank statement. Limited to 15 ASCII characters.
            [<Config.Form>]
            StatementDescriptor: string option
            /// A string that identifies this top-up as part of a group.
            [<Config.Form>]
            TransferGroup: string option
        }

    type CreateOptions with
        static member New(amount: int, currency: IsoTypes.IsoCurrencyCode, ?description: string, ?expand: string list, ?metadata: Map<string, string>, ?source: string, ?statementDescriptor: string, ?transferGroup: string) =
            {
                Amount = amount
                Currency = currency
                Description = description
                Expand = expand
                Metadata = metadata
                Source = source
                StatementDescriptor = statementDescriptor
                TransferGroup = transferGroup
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
              Expand = None
              Metadata = None
              Source = None
              StatementDescriptor = None
              TransferGroup = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Topup: string
        }

    type RetrieveOptions with
        static member New(topup: string, ?expand: string list) =
            {
                Topup = topup
                Expand = expand
            }

    module RetrieveOptions =
        let create
            (
                topup: string
            ) : RetrieveOptions
            =
            {
              Topup = topup
              Expand = None
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Topup: string
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

    type UpdateOptions with
        static member New(topup: string, ?description: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Topup = topup
                Description = description
                Expand = expand
                Metadata = metadata
            }

    module UpdateOptions =
        let create
            (
                topup: string
            ) : UpdateOptions
            =
            {
              Topup = topup
              Description = None
              Expand = None
              Metadata = None
            }

    ///<p>Returns a list of top-ups.</p>
    let List settings (options: ListOptions) =
        let qs = [("amount", options.Amount |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/topups"
        |> RestApi.getAsync<StripeList<Topup>> settings qs

    ///<p>Top up the balance of an account</p>
    let Create settings (options: CreateOptions) =
        $"/v1/topups"
        |> RestApi.postAsync<_, Topup> settings (Map.empty) options

    ///<p>Retrieves the details of a top-up that has previously been created. Supply the unique top-up ID that was returned from your previous request, and Stripe will return the corresponding top-up information.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/topups/{options.Topup}"
        |> RestApi.getAsync<Topup> settings qs

    ///<p>Updates the metadata of a top-up. Other top-up details are not editable by design.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/topups/{options.Topup}"
        |> RestApi.postAsync<_, Topup> settings (Map.empty) options

module TopupsCancel =

    type CancelOptions =
        {
            [<Config.Path>]
            Topup: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type CancelOptions with
        static member New(topup: string, ?expand: string list) =
            {
                Topup = topup
                Expand = expand
            }

    module CancelOptions =
        let create
            (
                topup: string
            ) : CancelOptions
            =
            {
              Topup = topup
              Expand = None
            }

    ///<p>Cancels a top-up. Only pending top-ups can be canceled.</p>
    let Cancel settings (options: CancelOptions) =
        $"/v1/topups/{options.Topup}/cancel"
        |> RestApi.postAsync<_, Topup> settings (Map.empty) options

