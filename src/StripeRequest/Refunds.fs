namespace StripeRequest.Refunds

open FunStripe
open System.Text.Json.Serialization
open Stripe.PaymentMethod
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module Refunds =

    type ListOptions =
        {
            /// Only return refunds for the charge specified by this charge ID.
            [<Config.Query>]
            Charge: string option
            /// Only return refunds that were created during the given date interval.
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
            /// Only return refunds for the PaymentIntent specified by this ID.
            [<Config.Query>]
            PaymentIntent: string option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    module ListOptions =
        let create
            (
                charge: string option,
                created: int option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                paymentIntent: string option,
                startingAfter: string option
            ) : ListOptions
            =
            {
              Charge = charge
              Created = created
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              PaymentIntent = paymentIntent
              StartingAfter = startingAfter
            }

    type Create'Origin = | CustomerBalance

    type Create'Reason =
        | Duplicate
        | Fraudulent
        | RequestedByCustomer

    type CreateOptions =
        {
            [<Config.Form>]
            Amount: int option
            /// The identifier of the charge to refund.
            [<Config.Form>]
            Charge: string option
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// Customer whose customer balance to refund from.
            [<Config.Form>]
            Customer: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// For payment methods without native refund support (e.g., Konbini, PromptPay), use this email from the customer to receive refund instructions.
            [<Config.Form>]
            InstructionsEmail: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Origin of the refund
            [<Config.Form>]
            Origin: Create'Origin option
            /// The identifier of the PaymentIntent to refund.
            [<Config.Form>]
            PaymentIntent: string option
            /// String indicating the reason for the refund. If set, possible values are `duplicate`, `fraudulent`, and `requested_by_customer`. If you believe the charge to be fraudulent, specifying `fraudulent` as the reason will add the associated card and email to your [block lists](https://docs.stripe.com/radar/lists), and will also help us improve our fraud detection algorithms.
            [<Config.Form>]
            Reason: Create'Reason option
            /// Boolean indicating whether the application fee should be refunded when refunding this charge. If a full charge refund is given, the full application fee will be refunded. Otherwise, the application fee will be refunded in an amount proportional to the amount of the charge refunded. An application fee can be refunded only by the application that created the charge.
            [<Config.Form>]
            RefundApplicationFee: bool option
            /// Boolean indicating whether the transfer should be reversed when refunding this charge. The transfer will be reversed proportionally to the amount being refunded (either the entire or partial amount).<br><br>A transfer can be reversed only by the application that created the charge.
            [<Config.Form>]
            ReverseTransfer: bool option
        }

    module CreateOptions =
        let create
            (
                amount: int option,
                charge: string option,
                currency: IsoTypes.IsoCurrencyCode option,
                customer: string option,
                expand: string list option,
                instructionsEmail: string option,
                metadata: Map<string, string> option,
                origin: Create'Origin option,
                paymentIntent: string option,
                reason: Create'Reason option,
                refundApplicationFee: bool option,
                reverseTransfer: bool option
            ) : CreateOptions
            =
            {
              Amount = amount
              Charge = charge
              Currency = currency
              Customer = customer
              Expand = expand
              InstructionsEmail = instructionsEmail
              Metadata = metadata
              Origin = origin
              PaymentIntent = paymentIntent
              Reason = reason
              RefundApplicationFee = refundApplicationFee
              ReverseTransfer = reverseTransfer
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Refund: string
        }

    module RetrieveOptions =
        let create
            (
                refund: string
            ) : RetrieveOptions
            =
            {
              Refund = refund
              Expand = None
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Refund: string
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
                refund: string
            ) : UpdateOptions
            =
            {
              Refund = refund
              Expand = None
              Metadata = None
            }

    ///<p>Returns a list of all refunds you created. We return the refunds in sorted order, with the most recent refunds appearing first. The 10 most recent refunds are always available by default on the Charge object.</p>
    let List settings (options: ListOptions) =
        let qs = [("charge", options.Charge |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("payment_intent", options.PaymentIntent |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/refunds"
        |> RestApi.getAsync<StripeList<Refund>> settings qs

    ///<p>When you create a new refund, you must specify a Charge or a PaymentIntent object on which to create it.</p>
    ///<p>Creating a new refund will refund a charge that has previously been created but not yet refunded.
    ///Funds will be refunded to the credit or debit card that was originally charged.</p>
    ///<p>You can optionally refund only part of a charge.
    ///You can do so multiple times, until the entire charge has been refunded.</p>
    ///<p>Once entirely refunded, a charge can’t be refunded again.
    ///This method will raise an error when called on an already-refunded charge,
    ///or when trying to refund more money than is left on a charge.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/refunds"
        |> RestApi.postAsync<_, Refund> settings (Map.empty) options

    ///<p>Retrieves the details of an existing refund.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/refunds/{options.Refund}"
        |> RestApi.getAsync<Refund> settings qs

    ///<p>Updates the refund that you specify by setting the values of the passed parameters. Any parameters that you don’t provide remain unchanged.</p>
    ///<p>This request only accepts <code>metadata</code> as an argument.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/refunds/{options.Refund}"
        |> RestApi.postAsync<_, Refund> settings (Map.empty) options

module RefundsCancel =

    type CancelOptions =
        {
            [<Config.Path>]
            Refund: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module CancelOptions =
        let create
            (
                refund: string
            ) : CancelOptions
            =
            {
              Refund = refund
              Expand = None
            }

    ///<p>Cancels a refund with a status of <code>requires_action</code>.</p>
    ///<p>You can’t cancel refunds in other states. Only refunds for payment methods that require customer action can enter the <code>requires_action</code> state.</p>
    let Cancel settings (options: CancelOptions) =
        $"/v1/refunds/{options.Refund}/cancel"
        |> RestApi.postAsync<_, Refund> settings (Map.empty) options

