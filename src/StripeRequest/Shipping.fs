namespace StripeRequest.Shipping

open FunStripe
open System.Text.Json.Serialization
open Stripe.ShippingRate
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module ShippingRates =

    type ListOptions =
        {
            /// Only return shipping rates that are active or inactive.
            [<Config.Query>]
            Active: bool option
            /// A filter on the list, based on the object `created` field. The value can be a string with an integer Unix timestamp, or it can be a dictionary with a number of different query options.
            [<Config.Query>]
            Created: int option
            /// Only return shipping rates for the given currency.
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
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    module ListOptions =
        let create
            (
                active: bool option,
                created: int option,
                currency: IsoTypes.IsoCurrencyCode option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option
            ) : ListOptions
            =
            {
              Active = active
              Created = created
              Currency = currency
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
            }

    type Create'DeliveryEstimateMaximumUnit =
        | BusinessDay
        | Day
        | Hour
        | Month
        | Week

    type Create'DeliveryEstimateMaximum =
        {
            /// A unit of time.
            [<Config.Form>]
            Unit: Create'DeliveryEstimateMaximumUnit option
            /// Must be greater than 0.
            [<Config.Form>]
            Value: int option
        }

    module Create'DeliveryEstimateMaximum =
        let create
            (
                unit: Create'DeliveryEstimateMaximumUnit option,
                value: int option
            ) : Create'DeliveryEstimateMaximum
            =
            {
              Unit = unit
              Value = value
            }

    type Create'DeliveryEstimateMinimumUnit =
        | BusinessDay
        | Day
        | Hour
        | Month
        | Week

    type Create'DeliveryEstimateMinimum =
        {
            /// A unit of time.
            [<Config.Form>]
            Unit: Create'DeliveryEstimateMinimumUnit option
            /// Must be greater than 0.
            [<Config.Form>]
            Value: int option
        }

    module Create'DeliveryEstimateMinimum =
        let create
            (
                unit: Create'DeliveryEstimateMinimumUnit option,
                value: int option
            ) : Create'DeliveryEstimateMinimum
            =
            {
              Unit = unit
              Value = value
            }

    type Create'DeliveryEstimate =
        {
            /// The upper bound of the estimated range. If empty, represents no upper bound i.e., infinite.
            [<Config.Form>]
            Maximum: Create'DeliveryEstimateMaximum option
            /// The lower bound of the estimated range. If empty, represents no lower bound.
            [<Config.Form>]
            Minimum: Create'DeliveryEstimateMinimum option
        }

    module Create'DeliveryEstimate =
        let create
            (
                maximum: Create'DeliveryEstimateMaximum option,
                minimum: Create'DeliveryEstimateMinimum option
            ) : Create'DeliveryEstimate
            =
            {
              Maximum = maximum
              Minimum = minimum
            }

    type Create'FixedAmount =
        {
            /// A non-negative integer in cents representing how much to charge.
            [<Config.Form>]
            Amount: int option
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// Shipping rates defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            CurrencyOptions: Map<string, string> option
        }

    module Create'FixedAmount =
        let create
            (
                amount: int option,
                currency: IsoTypes.IsoCurrencyCode option,
                currencyOptions: Map<string, string> option
            ) : Create'FixedAmount
            =
            {
              Amount = amount
              Currency = currency
              CurrencyOptions = currencyOptions
            }

    type Create'TaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type Create'Type = | FixedAmount

    type CreateOptions =
        {
            /// The estimated range for how long shipping will take, meant to be displayable to the customer. This will appear on CheckoutSessions.
            [<Config.Form>]
            DeliveryEstimate: Create'DeliveryEstimate option
            /// The name of the shipping rate, meant to be displayable to the customer. This will appear on CheckoutSessions.
            [<Config.Form>]
            DisplayName: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Describes a fixed amount to charge for shipping. Must be present if type is `fixed_amount`.
            [<Config.Form>]
            FixedAmount: Create'FixedAmount option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Specifies whether the rate is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`.
            [<Config.Form>]
            TaxBehavior: Create'TaxBehavior option
            /// A [tax code](https://docs.stripe.com/tax/tax-categories) ID. The Shipping tax code is `txcd_92010001`.
            [<Config.Form>]
            TaxCode: string option
            /// The type of calculation to use on the shipping rate.
            [<Config.Form>]
            Type: Create'Type option
        }

    module CreateOptions =
        let create
            (
                displayName: string
            ) : CreateOptions
            =
            {
              DisplayName = displayName
              DeliveryEstimate = None
              Expand = None
              FixedAmount = None
              Metadata = None
              TaxBehavior = None
              TaxCode = None
              Type = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            ShippingRateToken: string
        }

    module RetrieveOptions =
        let create
            (
                shippingRateToken: string
            ) : RetrieveOptions
            =
            {
              ShippingRateToken = shippingRateToken
              Expand = None
            }

    type Update'FixedAmount =
        {
            /// Shipping rates defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            CurrencyOptions: Map<string, string> option
        }

    module Update'FixedAmount =
        let create
            (
                currencyOptions: Map<string, string> option
            ) : Update'FixedAmount
            =
            {
              CurrencyOptions = currencyOptions
            }

    type Update'TaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type UpdateOptions =
        {
            [<Config.Path>]
            ShippingRateToken: string
            /// Whether the shipping rate can be used for new purchases. Defaults to `true`.
            [<Config.Form>]
            Active: bool option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Describes a fixed amount to charge for shipping. Must be present if type is `fixed_amount`.
            [<Config.Form>]
            FixedAmount: Update'FixedAmount option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Specifies whether the rate is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`.
            [<Config.Form>]
            TaxBehavior: Update'TaxBehavior option
        }

    module UpdateOptions =
        let create
            (
                shippingRateToken: string
            ) : UpdateOptions
            =
            {
              ShippingRateToken = shippingRateToken
              Active = None
              Expand = None
              FixedAmount = None
              Metadata = None
              TaxBehavior = None
            }

    ///<p>Returns a list of your shipping rates.</p>
    let List settings (options: ListOptions) =
        let qs = [("active", options.Active |> box); ("created", options.Created |> box); ("currency", options.Currency |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/shipping_rates"
        |> RestApi.getAsync<StripeList<ShippingRate>> settings qs

    ///<p>Creates a new shipping rate object.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/shipping_rates"
        |> RestApi.postAsync<_, ShippingRate> settings (Map.empty) options

    ///<p>Returns the shipping rate object with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/shipping_rates/{options.ShippingRateToken}"
        |> RestApi.getAsync<ShippingRate> settings qs

    ///<p>Updates an existing shipping rate object.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/shipping_rates/{options.ShippingRateToken}"
        |> RestApi.postAsync<_, ShippingRate> settings (Map.empty) options

