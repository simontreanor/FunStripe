namespace StripeRequest.Shipping

open FunStripe
open System.Text.Json.Serialization
open Stripe.ShippingRate
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
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

    type ListOptions with
        static member New(?active: bool, ?created: int, ?currency: IsoTypes.IsoCurrencyCode, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
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

    type Create'DeliveryEstimateMaximum with
        static member New(?unit: Create'DeliveryEstimateMaximumUnit, ?value: int) =
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

    type Create'DeliveryEstimateMinimum with
        static member New(?unit: Create'DeliveryEstimateMinimumUnit, ?value: int) =
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

    type Create'DeliveryEstimate with
        static member New(?maximum: Create'DeliveryEstimateMaximum, ?minimum: Create'DeliveryEstimateMinimum) =
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

    type Create'FixedAmount with
        static member New(?amount: int, ?currency: IsoTypes.IsoCurrencyCode, ?currencyOptions: Map<string, string>) =
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

    type CreateOptions with
        static member New(displayName: string, ?deliveryEstimate: Create'DeliveryEstimate, ?expand: string list, ?fixedAmount: Create'FixedAmount, ?metadata: Map<string, string>, ?taxBehavior: Create'TaxBehavior, ?taxCode: string, ?type': Create'Type) =
            {
                DisplayName = displayName
                DeliveryEstimate = deliveryEstimate
                Expand = expand
                FixedAmount = fixedAmount
                Metadata = metadata
                TaxBehavior = taxBehavior
                TaxCode = taxCode
                Type = type'
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            ShippingRateToken: string
        }

    type RetrieveOptions with
        static member New(shippingRateToken: string, ?expand: string list) =
            {
                ShippingRateToken = shippingRateToken
                Expand = expand
            }

    type Update'FixedAmount =
        {
            /// Shipping rates defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            CurrencyOptions: Map<string, string> option
        }

    type Update'FixedAmount with
        static member New(?currencyOptions: Map<string, string>) =
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

    type UpdateOptions with
        static member New(shippingRateToken: string, ?active: bool, ?expand: string list, ?fixedAmount: Update'FixedAmount, ?metadata: Map<string, string>, ?taxBehavior: Update'TaxBehavior) =
            {
                ShippingRateToken = shippingRateToken
                Active = active
                Expand = expand
                FixedAmount = fixedAmount
                Metadata = metadata
                TaxBehavior = taxBehavior
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

