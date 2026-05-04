namespace StripeRequest.Prices

open FunStripe
open System.Text.Json.Serialization
open Stripe.Price
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
module Prices =

    type ListOptions =
        {
            /// Only return prices that are active or inactive (e.g., pass `false` to list all inactive prices).
            [<Config.Query>]
            Active: bool option
            /// A filter on the list, based on the object `created` field. The value can be a string with an integer Unix timestamp, or it can be a dictionary with a number of different query options.
            [<Config.Query>]
            Created: int option
            /// Only return prices for the given currency.
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
            /// Only return the price with these lookup_keys, if any exist. You can specify up to 10 lookup_keys.
            [<Config.Query>]
            LookupKeys: string list option
            /// Only return prices for the given product.
            [<Config.Query>]
            Product: string option
            /// Only return prices with these recurring fields.
            [<Config.Query>]
            Recurring: Map<string, string> option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Only return prices of type `recurring` or `one_time`.
            [<Config.Query>]
            Type: string option
        }

    type ListOptions with
        static member New(?active: bool, ?created: int, ?currency: IsoTypes.IsoCurrencyCode, ?endingBefore: string, ?expand: string list, ?limit: int, ?lookupKeys: string list, ?product: string, ?recurring: Map<string, string>, ?startingAfter: string, ?type': string) =
            {
                Active = active
                Created = created
                Currency = currency
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                LookupKeys = lookupKeys
                Product = product
                Recurring = recurring
                StartingAfter = startingAfter
                Type = type'
            }

    type Create'BillingScheme =
        | PerUnit
        | Tiered

    type Create'CustomUnitAmount =
        {
            /// Pass in `true` to enable `custom_unit_amount`, otherwise omit `custom_unit_amount`.
            [<Config.Form>]
            Enabled: bool option
            /// The maximum unit amount the customer can specify for this item.
            [<Config.Form>]
            Maximum: int option
            /// The minimum unit amount the customer can specify for this item. Must be at least the minimum charge amount.
            [<Config.Form>]
            Minimum: int option
            /// The starting unit amount which can be updated by the customer.
            [<Config.Form>]
            Preset: int option
        }

    type Create'CustomUnitAmount with
        static member New(?enabled: bool, ?maximum: int, ?minimum: int, ?preset: int) =
            {
                Enabled = enabled
                Maximum = maximum
                Minimum = minimum
                Preset = preset
            }

    type Create'ProductData =
        {
            /// Whether the product is currently available for purchase. Defaults to `true`.
            [<Config.Form>]
            Active: bool option
            /// The identifier for the product. Must be unique. If not provided, an identifier will be randomly generated.
            [<Config.Form>]
            Id: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The product's name, meant to be displayable to the customer.
            [<Config.Form>]
            Name: string option
            /// An arbitrary string to be displayed on your customer's credit card or bank statement. While most banks display this information consistently, some may display it incorrectly or not at all.
            /// This may be up to 22 characters. The statement description may not include `<`, `>`, `\`, `"`, `'` characters, and will appear on your customer's statement in capital letters. Non-ASCII characters are automatically stripped.
            [<Config.Form>]
            StatementDescriptor: string option
            /// A [tax code](https://docs.stripe.com/tax/tax-categories) ID.
            [<Config.Form>]
            TaxCode: string option
            /// A label that represents units of this product. When set, this will be included in customers' receipts, invoices, Checkout, and the customer portal.
            [<Config.Form>]
            UnitLabel: string option
        }

    type Create'ProductData with
        static member New(?active: bool, ?id: string, ?metadata: Map<string, string>, ?name: string, ?statementDescriptor: string, ?taxCode: string, ?unitLabel: string) =
            {
                Active = active
                Id = id
                Metadata = metadata
                Name = name
                StatementDescriptor = statementDescriptor
                TaxCode = taxCode
                UnitLabel = unitLabel
            }

    type Create'RecurringInterval =
        | Day
        | Month
        | Week
        | Year

    type Create'RecurringUsageType =
        | Licensed
        | Metered

    type Create'Recurring =
        {
            /// Specifies billing frequency. Either `day`, `week`, `month` or `year`.
            [<Config.Form>]
            Interval: Create'RecurringInterval option
            /// The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).
            [<Config.Form>]
            IntervalCount: int option
            /// The meter tracking the usage of a metered price
            [<Config.Form>]
            Meter: string option
            /// Default number of trial days when subscribing a customer to this price using [`trial_from_plan=true`](https://docs.stripe.com/api#create_subscription-trial_from_plan).
            [<Config.Form>]
            TrialPeriodDays: int option
            /// Configures how the quantity per period should be determined. Can be either `metered` or `licensed`. `licensed` automatically bills the `quantity` set when adding it to a subscription. `metered` aggregates the total usage based on usage records. Defaults to `licensed`.
            [<Config.Form>]
            UsageType: Create'RecurringUsageType option
        }

    type Create'Recurring with
        static member New(?interval: Create'RecurringInterval, ?intervalCount: int, ?meter: string, ?trialPeriodDays: int, ?usageType: Create'RecurringUsageType) =
            {
                Interval = interval
                IntervalCount = intervalCount
                Meter = meter
                TrialPeriodDays = trialPeriodDays
                UsageType = usageType
            }

    type Create'TaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type Create'TiersUpTo = | Inf

    type Create'Tiers =
        {
            /// The flat billing amount for an entire tier, regardless of the number of units in the tier.
            [<Config.Form>]
            FlatAmount: int option
            /// Same as `flat_amount`, but accepts a decimal value representing an integer in the minor units of the currency. Only one of `flat_amount` and `flat_amount_decimal` can be set.
            [<Config.Form>]
            FlatAmountDecimal: string option
            /// The per unit billing amount for each individual unit for which this tier applies.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
            /// Specifies the upper bound of this tier. The lower bound of a tier is the upper bound of the previous tier adding one. Use `inf` to define a fallback tier.
            [<Config.Form>]
            UpTo: Choice<Create'TiersUpTo,int> option
        }

    type Create'Tiers with
        static member New(?flatAmount: int, ?flatAmountDecimal: string, ?unitAmount: int, ?unitAmountDecimal: string, ?upTo: Choice<Create'TiersUpTo,int>) =
            {
                FlatAmount = flatAmount
                FlatAmountDecimal = flatAmountDecimal
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
                UpTo = upTo
            }

    type Create'TiersMode =
        | Graduated
        | Volume

    type Create'TransformQuantityRound =
        | Down
        | Up

    type Create'TransformQuantity =
        {
            /// Divide usage by this number.
            [<Config.Form>]
            DivideBy: int option
            /// After division, either round the result `up` or `down`.
            [<Config.Form>]
            Round: Create'TransformQuantityRound option
        }

    type Create'TransformQuantity with
        static member New(?divideBy: int, ?round: Create'TransformQuantityRound) =
            {
                DivideBy = divideBy
                Round = round
            }

    type CreateOptions =
        {
            /// Whether the price can be used for new purchases. Defaults to `true`.
            [<Config.Form>]
            Active: bool option
            /// Describes how to compute the price per period. Either `per_unit` or `tiered`. `per_unit` indicates that the fixed amount (specified in `unit_amount` or `unit_amount_decimal`) will be charged per unit in `quantity` (for prices with `usage_type=licensed`), or per unit of total usage (for prices with `usage_type=metered`). `tiered` indicates that the unit pricing will be computed using a tiering strategy as defined using the `tiers` and `tiers_mode` attributes.
            [<Config.Form>]
            BillingScheme: Create'BillingScheme option
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode
            /// Prices defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            CurrencyOptions: Map<string, string> option
            /// When set, provides configuration for the amount to be adjusted by the customer during Checkout Sessions and Payment Links.
            [<Config.Form>]
            CustomUnitAmount: Create'CustomUnitAmount option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// A lookup key used to retrieve prices dynamically from a static string. This may be up to 200 characters.
            [<Config.Form>]
            LookupKey: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// A brief description of the price, hidden from customers.
            [<Config.Form>]
            Nickname: string option
            /// The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.
            [<Config.Form>]
            Product: string option
            /// These fields can be used to create a new product that this price will belong to.
            [<Config.Form>]
            ProductData: Create'ProductData option
            /// The recurring components of a price such as `interval` and `usage_type`.
            [<Config.Form>]
            Recurring: Create'Recurring option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: Create'TaxBehavior option
            /// Each element represents a pricing tier. This parameter requires `billing_scheme` to be set to `tiered`. See also the documentation for `billing_scheme`.
            [<Config.Form>]
            Tiers: Create'Tiers list option
            /// Defines if the tiering price should be `graduated` or `volume` based. In `volume`-based tiering, the maximum quantity within a period determines the per unit price, in `graduated` tiering pricing can successively change as the quantity grows.
            [<Config.Form>]
            TiersMode: Create'TiersMode option
            /// If set to true, will atomically remove the lookup key from the existing price, and assign it to this price.
            [<Config.Form>]
            TransferLookupKey: bool option
            /// Apply a transformation to the reported usage or set quantity before computing the billed price. Cannot be combined with `tiers`.
            [<Config.Form>]
            TransformQuantity: Create'TransformQuantity option
            /// A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge. One of `unit_amount`, `unit_amount_decimal`, or `custom_unit_amount` is required, unless `billing_scheme=tiered`.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    type CreateOptions with
        static member New(currency: IsoTypes.IsoCurrencyCode, ?active: bool, ?billingScheme: Create'BillingScheme, ?currencyOptions: Map<string, string>, ?customUnitAmount: Create'CustomUnitAmount, ?expand: string list, ?lookupKey: string, ?metadata: Map<string, string>, ?nickname: string, ?product: string, ?productData: Create'ProductData, ?recurring: Create'Recurring, ?taxBehavior: Create'TaxBehavior, ?tiers: Create'Tiers list, ?tiersMode: Create'TiersMode, ?transferLookupKey: bool, ?transformQuantity: Create'TransformQuantity, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Active = active
                BillingScheme = billingScheme
                CurrencyOptions = currencyOptions
                CustomUnitAmount = customUnitAmount
                Expand = expand
                LookupKey = lookupKey
                Metadata = metadata
                Nickname = nickname
                Product = product
                ProductData = productData
                Recurring = recurring
                TaxBehavior = taxBehavior
                Tiers = tiers
                TiersMode = tiersMode
                TransferLookupKey = transferLookupKey
                TransformQuantity = transformQuantity
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Price: string
        }

    type RetrieveOptions with
        static member New(price: string, ?expand: string list) =
            {
                Price = price
                Expand = expand
            }

    type Update'TaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type UpdateOptions =
        {
            [<Config.Path>]
            Price: string
            /// Whether the price can be used for new purchases. Defaults to `true`.
            [<Config.Form>]
            Active: bool option
            /// Prices defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            CurrencyOptions: Choice<Map<string, string>,string> option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// A lookup key used to retrieve prices dynamically from a static string. This may be up to 200 characters.
            [<Config.Form>]
            LookupKey: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// A brief description of the price, hidden from customers.
            [<Config.Form>]
            Nickname: string option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: Update'TaxBehavior option
            /// If set to true, will atomically remove the lookup key from the existing price, and assign it to this price.
            [<Config.Form>]
            TransferLookupKey: bool option
        }

    type UpdateOptions with
        static member New(price: string, ?active: bool, ?currencyOptions: Choice<Map<string, string>,string>, ?expand: string list, ?lookupKey: string, ?metadata: Map<string, string>, ?nickname: string, ?taxBehavior: Update'TaxBehavior, ?transferLookupKey: bool) =
            {
                Price = price
                Active = active
                CurrencyOptions = currencyOptions
                Expand = expand
                LookupKey = lookupKey
                Metadata = metadata
                Nickname = nickname
                TaxBehavior = taxBehavior
                TransferLookupKey = transferLookupKey
            }

    ///<p>Returns a list of your active prices, excluding <a href="/docs/products-prices/pricing-models#inline-pricing">inline prices</a>. For the list of inactive prices, set <code>active</code> to false.</p>
    let List settings (options: ListOptions) =
        let qs = [("active", options.Active |> box); ("created", options.Created |> box); ("currency", options.Currency |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("lookup_keys", options.LookupKeys |> box); ("product", options.Product |> box); ("recurring", options.Recurring |> box); ("starting_after", options.StartingAfter |> box); ("type", options.Type |> box)] |> Map.ofList
        $"/v1/prices"
        |> RestApi.getAsync<StripeList<Price>> settings qs

    ///<p>Creates a new <a href="https://docs.stripe.com/api/prices">Price</a> for an existing <a href="https://docs.stripe.com/api/products">Product</a>. The Price can be recurring or one-time.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/prices"
        |> RestApi.postAsync<_, Price> settings (Map.empty) options

    ///<p>Retrieves the price with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/prices/{options.Price}"
        |> RestApi.getAsync<Price> settings qs

    ///<p>Updates the specified price by setting the values of the parameters passed. Any parameters not provided are left unchanged.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/prices/{options.Price}"
        |> RestApi.postAsync<_, Price> settings (Map.empty) options

module PricesSearch =

    type SearchOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for pagination across multiple pages of results. Don't include this parameter on the first call. Use the next_page value returned in a previous response to request subsequent results.
            [<Config.Query>]
            Page: string option
            /// The search query string. See [search query language](https://docs.stripe.com/search#search-query-language) and the list of supported [query fields for prices](https://docs.stripe.com/search#query-fields-for-prices).
            [<Config.Query>]
            Query: string
        }

    type SearchOptions with
        static member New(query: string, ?expand: string list, ?limit: int, ?page: string) =
            {
                Query = query
                Expand = expand
                Limit = limit
                Page = page
            }

    ///<p>Search for prices you’ve previously created using Stripe’s <a href="/docs/search#search-query-language">Search Query Language</a>.
    ///Don’t use search in read-after-write flows where strict consistency is necessary. Under normal operating
    ///conditions, data is searchable in less than a minute. Occasionally, propagation of new or updated data can be up
    ///to an hour behind during outages. Search functionality is not available to merchants in India.</p>
    let Search settings (options: SearchOptions) =
        let qs = [("expand", options.Expand |> box); ("limit", options.Limit |> box); ("page", options.Page |> box); ("query", options.Query |> box)] |> Map.ofList
        $"/v1/prices/search"
        |> RestApi.getAsync<StripeList<Price>> settings qs

