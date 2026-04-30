namespace StripeRequest.Climate

open FunStripe
open System.Text.Json.Serialization
open Stripe.Climate
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
module ClimateOrders =

    type ListOptions =
        {
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
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option
            ) : ListOptions
            =
            {
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
            }

    type Create'Beneficiary =
        {
            /// Publicly displayable name for the end beneficiary of carbon removal.
            [<Config.Form>]
            PublicName: string option
        }

    module Create'Beneficiary =
        let create
            (
                publicName: string option
            ) : Create'Beneficiary
            =
            {
              PublicName = publicName
            }

    type CreateOptions =
        {
            /// Requested amount of carbon removal units. Either this or `metric_tons` must be specified.
            [<Config.Form>]
            Amount: int option
            /// Publicly sharable reference for the end beneficiary of carbon removal. Assumed to be the Stripe account if not set.
            [<Config.Form>]
            Beneficiary: Create'Beneficiary option
            /// Request currency for the order as a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a supported [settlement currency for your account](https://stripe.com/docs/currencies). If omitted, the account's default currency will be used.
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Requested number of tons for the order. Either this or `amount` must be specified.
            [<Config.Form>]
            MetricTons: string option
            /// Unique identifier of the Climate product.
            [<Config.Form>]
            Product: string
        }

    module CreateOptions =
        let create
            (
                product: string,
                amount: int option,
                beneficiary: Create'Beneficiary option,
                currency: IsoTypes.IsoCurrencyCode option,
                expand: string list option,
                metadata: Map<string, string> option,
                metricTons: string option
            ) : CreateOptions
            =
            {
              Product = product
              Amount = amount
              Beneficiary = beneficiary
              Currency = currency
              Expand = expand
              Metadata = metadata
              MetricTons = metricTons
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// Unique identifier of the order.
            [<Config.Path>]
            Order: string
        }

    module RetrieveOptions =
        let create
            (
                order: string,
                expand: string list option
            ) : RetrieveOptions
            =
            {
              Order = order
              Expand = expand
            }

    type Update'BeneficiaryBeneficiaryParams =
        {
            /// Publicly displayable name for the end beneficiary of carbon removal.
            [<Config.Form>]
            PublicName: Choice<string,string> option
        }

    module Update'BeneficiaryBeneficiaryParams =
        let create
            (
                publicName: Choice<string,string> option
            ) : Update'BeneficiaryBeneficiaryParams
            =
            {
              PublicName = publicName
            }

    type UpdateOptions =
        {
            /// Unique identifier of the order.
            [<Config.Path>]
            Order: string
            /// Publicly sharable reference for the end beneficiary of carbon removal. Assumed to be the Stripe account if not set.
            [<Config.Form>]
            Beneficiary: Choice<Update'BeneficiaryBeneficiaryParams,string> option
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
                order: string,
                beneficiary: Choice<Update'BeneficiaryBeneficiaryParams,string> option,
                expand: string list option,
                metadata: Map<string, string> option
            ) : UpdateOptions
            =
            {
              Order = order
              Beneficiary = beneficiary
              Expand = expand
              Metadata = metadata
            }

    ///<p>Lists all Climate order objects. The orders are returned sorted by creation date, with the
    ///most recently created orders appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/climate/orders"
        |> RestApi.getAsync<StripeList<ClimateOrder>> settings qs

    ///<p>Creates a Climate order object for a given Climate product. The order will be processed immediately
    ///after creation and payment will be deducted your Stripe balance.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/climate/orders"
        |> RestApi.postAsync<_, ClimateOrder> settings (Map.empty) options

    ///<p>Retrieves the details of a Climate order object with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/climate/orders/{options.Order}"
        |> RestApi.getAsync<ClimateOrder> settings qs

    ///<p>Updates the specified order by setting the values of the parameters passed.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/climate/orders/{options.Order}"
        |> RestApi.postAsync<_, ClimateOrder> settings (Map.empty) options

module ClimateOrdersCancel =

    type CancelOptions =
        {
            /// Unique identifier of the order.
            [<Config.Path>]
            Order: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module CancelOptions =
        let create
            (
                order: string,
                expand: string list option
            ) : CancelOptions
            =
            {
              Order = order
              Expand = expand
            }

    ///<p>Cancels a Climate order. You can cancel an order within 24 hours of creation. Stripe refunds the
    ///reservation <code>amount_subtotal</code>, but not the <code>amount_fees</code> for user-triggered cancellations. Frontier
    ///might cancel reservations if suppliers fail to deliver. If Frontier cancels the reservation, Stripe
    ///provides 90 days advance notice and refunds the <code>amount_total</code>.</p>
    let Cancel settings (options: CancelOptions) =
        $"/v1/climate/orders/{options.Order}/cancel"
        |> RestApi.postAsync<_, ClimateOrder> settings (Map.empty) options

module ClimateProducts =

    type ListOptions =
        {
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
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option
            ) : ListOptions
            =
            {
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
            Product: string
        }

    module RetrieveOptions =
        let create
            (
                product: string,
                expand: string list option
            ) : RetrieveOptions
            =
            {
              Product = product
              Expand = expand
            }

    ///<p>Lists all available Climate product objects.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/climate/products"
        |> RestApi.getAsync<StripeList<ClimateProduct>> settings qs

    ///<p>Retrieves the details of a Climate product with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/climate/products/{options.Product}"
        |> RestApi.getAsync<ClimateProduct> settings qs

module ClimateSuppliers =

    type ListOptions =
        {
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
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option
            ) : ListOptions
            =
            {
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
            Supplier: string
        }

    module RetrieveOptions =
        let create
            (
                supplier: string,
                expand: string list option
            ) : RetrieveOptions
            =
            {
              Supplier = supplier
              Expand = expand
            }

    ///<p>Lists all available Climate supplier objects.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/climate/suppliers"
        |> RestApi.getAsync<StripeList<ClimateSupplier>> settings qs

    ///<p>Retrieves a Climate supplier object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/climate/suppliers/{options.Supplier}"
        |> RestApi.getAsync<ClimateSupplier> settings qs

