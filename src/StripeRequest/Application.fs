namespace StripeRequest.Application

open FunStripe
open System.Text.Json.Serialization
open Stripe.PaymentMethod
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module ApplicationFees =

    type ListOptions =
        {
            /// Only return application fees for the charge specified by this charge ID.
            [<Config.Query>]
            Charge: string option
            /// Only return applications fees that were created during the given date interval.
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
        }

    module ListOptions =
        let create
            (
                charge: string option,
                created: int option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option
            ) : ListOptions
            =
            {
              Charge = charge
              Created = created
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
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
                id: string
            ) : RetrieveOptions
            =
            {
              Id = id
              Expand = None
            }

    ///<p>Returns a list of application fees you’ve previously collected. The application fees are returned in sorted order, with the most recent fees appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("charge", options.Charge |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/application_fees"
        |> RestApi.getAsync<StripeList<ApplicationFee>> settings qs

    ///<p>Retrieves the details of an application fee that your account has collected. The same information is returned when refunding the application fee.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/application_fees/{options.Id}"
        |> RestApi.getAsync<ApplicationFee> settings qs

module ApplicationFeesRefunds =

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Fee: string
            [<Config.Path>]
            Id: string
        }

    module RetrieveOptions =
        let create
            (
                fee: string,
                id: string
            ) : RetrieveOptions
            =
            {
              Fee = fee
              Id = id
              Expand = None
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Fee: string
            [<Config.Path>]
            Id: string
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
                fee: string,
                id: string
            ) : UpdateOptions
            =
            {
              Fee = fee
              Id = id
              Expand = None
              Metadata = None
            }

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
            /// A positive integer, in _cents (or local equivalent)_, representing how much of this fee to refund. Can refund only up to the remaining unrefunded amount of the fee.
            [<Config.Form>]
            Amount: int option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
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
              Expand = None
              Metadata = None
            }

    ///<p>By default, you can see the 10 most recent refunds stored directly on the application fee object, but you can also retrieve details about a specific refund stored on the application fee.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/application_fees/{options.Fee}/refunds/{options.Id}"
        |> RestApi.getAsync<FeeRefund> settings qs

    ///<p>Updates the specified application fee refund by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
    ///<p>This request only accepts metadata as an argument.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/application_fees/{options.Fee}/refunds/{options.Id}"
        |> RestApi.postAsync<_, FeeRefund> settings (Map.empty) options

    ///<p>You can see a list of the refunds belonging to a specific application fee. Note that the 10 most recent refunds are always available by default on the application fee object. If you need more than those 10, you can use this API method and the <code>limit</code> and <code>starting_after</code> parameters to page through additional refunds.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/application_fees/{options.Id}/refunds"
        |> RestApi.getAsync<StripeList<FeeRefund>> settings qs

    ///<p>Refunds an application fee that has previously been collected but not yet refunded.
    ///Funds will be refunded to the Stripe account from which the fee was originally collected.</p>
    ///<p>You can optionally refund only part of an application fee.
    ///You can do so multiple times, until the entire fee has been refunded.</p>
    ///<p>Once entirely refunded, an application fee can’t be refunded again.
    ///This method will raise an error when called on an already-refunded application fee,
    ///or when trying to refund more money than is left on an application fee.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/application_fees/{options.Id}/refunds"
        |> RestApi.postAsync<_, FeeRefund> settings (Map.empty) options

