namespace StripeRequest.Products

open FunStripe
open System.Text.Json.Serialization
open Stripe.Deleted
open Stripe.Price
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
module Products =

    type ListOptions =
        {
            /// Only return products that are active or inactive (e.g., pass `false` to list all inactive products).
            [<Config.Query>]
            Active: bool option
            /// Only return products that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// Only return products with the given IDs. Cannot be used with [starting_after](https://api.stripe.com#list_products-starting_after) or [ending_before](https://api.stripe.com#list_products-ending_before).
            [<Config.Query>]
            Ids: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// Only return products that can be shipped (i.e., physical, not digital products).
            [<Config.Query>]
            Shippable: bool option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Only return products of this type.
            [<Config.Query>]
            Type: string option
            /// Only return products with the given url.
            [<Config.Query>]
            Url: string option
        }

    module ListOptions =
        let create
            (
                active: bool option,
                created: int option,
                endingBefore: string option,
                expand: string list option,
                ids: string list option,
                limit: int option,
                shippable: bool option,
                startingAfter: string option,
                ``type``: string option,
                url: string option
            ) : ListOptions
            =
            {
              Active = active
              Created = created
              EndingBefore = endingBefore
              Expand = expand
              Ids = ids
              Limit = limit
              Shippable = shippable
              StartingAfter = startingAfter
              Type = ``type``
              Url = url
            }

    type Create'DefaultPriceDataCustomUnitAmount =
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

    module Create'DefaultPriceDataCustomUnitAmount =
        let create
            (
                enabled: bool option,
                maximum: int option,
                minimum: int option,
                preset: int option
            ) : Create'DefaultPriceDataCustomUnitAmount
            =
            {
              Enabled = enabled
              Maximum = maximum
              Minimum = minimum
              Preset = preset
            }

    type Create'DefaultPriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    type Create'DefaultPriceDataRecurring =
        {
            /// Specifies billing frequency. Either `day`, `week`, `month` or `year`.
            [<Config.Form>]
            Interval: Create'DefaultPriceDataRecurringInterval option
            /// The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).
            [<Config.Form>]
            IntervalCount: int option
        }

    module Create'DefaultPriceDataRecurring =
        let create
            (
                interval: Create'DefaultPriceDataRecurringInterval option,
                intervalCount: int option
            ) : Create'DefaultPriceDataRecurring
            =
            {
              Interval = interval
              IntervalCount = intervalCount
            }

    type Create'DefaultPriceDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type Create'DefaultPriceData =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// Prices defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            CurrencyOptions: Map<string, string> option
            /// When set, provides configuration for the amount to be adjusted by the customer during Checkout Sessions and Payment Links.
            [<Config.Form>]
            CustomUnitAmount: Create'DefaultPriceDataCustomUnitAmount option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The recurring components of a price such as `interval` and `interval_count`.
            [<Config.Form>]
            Recurring: Create'DefaultPriceDataRecurring option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: Create'DefaultPriceDataTaxBehavior option
            /// A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge. One of `unit_amount`, `unit_amount_decimal`, or `custom_unit_amount` is required.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    module Create'DefaultPriceData =
        let create
            (
                currency: IsoTypes.IsoCurrencyCode option,
                currencyOptions: Map<string, string> option,
                customUnitAmount: Create'DefaultPriceDataCustomUnitAmount option,
                metadata: Map<string, string> option,
                recurring: Create'DefaultPriceDataRecurring option,
                taxBehavior: Create'DefaultPriceDataTaxBehavior option,
                unitAmount: int option,
                unitAmountDecimal: string option
            ) : Create'DefaultPriceData
            =
            {
              Currency = currency
              CurrencyOptions = currencyOptions
              CustomUnitAmount = customUnitAmount
              Metadata = metadata
              Recurring = recurring
              TaxBehavior = taxBehavior
              UnitAmount = unitAmount
              UnitAmountDecimal = unitAmountDecimal
            }

    type Create'MarketingFeatures =
        {
            /// The marketing feature name. Up to 80 characters long.
            [<Config.Form>]
            Name: string option
        }

    module Create'MarketingFeatures =
        let create
            (
                name: string option
            ) : Create'MarketingFeatures
            =
            {
              Name = name
            }

    type Create'PackageDimensions =
        {
            /// Height, in inches. Maximum precision is 2 decimal places.
            [<Config.Form>]
            Height: decimal option
            /// Length, in inches. Maximum precision is 2 decimal places.
            [<Config.Form>]
            Length: decimal option
            /// Weight, in ounces. Maximum precision is 2 decimal places.
            [<Config.Form>]
            Weight: decimal option
            /// Width, in inches. Maximum precision is 2 decimal places.
            [<Config.Form>]
            Width: decimal option
        }

    module Create'PackageDimensions =
        let create
            (
                height: decimal option,
                length: decimal option,
                weight: decimal option,
                width: decimal option
            ) : Create'PackageDimensions
            =
            {
              Height = height
              Length = length
              Weight = weight
              Width = width
            }

    type Create'Type =
        | Good
        | Service

    type CreateOptions =
        {
            /// Whether the product is currently available for purchase. Defaults to `true`.
            [<Config.Form>]
            Active: bool option
            /// Data used to generate a new [Price](https://docs.stripe.com/api/prices) object. This Price will be set as the default price for this product.
            [<Config.Form>]
            DefaultPriceData: Create'DefaultPriceData option
            /// The product's description, meant to be displayable to the customer. Use this field to optionally store a long form explanation of the product being sold for your own rendering purposes.
            [<Config.Form>]
            Description: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// An identifier will be randomly generated by Stripe. You can optionally override this ID, but the ID must be unique across all products in your Stripe account.
            [<Config.Form>]
            Id: string option
            /// A list of up to 8 URLs of images for this product, meant to be displayable to the customer.
            [<Config.Form>]
            Images: string list option
            /// A list of up to 15 marketing features for this product. These are displayed in [pricing tables](https://docs.stripe.com/payments/checkout/pricing-table).
            [<Config.Form>]
            MarketingFeatures: Create'MarketingFeatures list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The product's name, meant to be displayable to the customer.
            [<Config.Form>]
            Name: string
            /// The dimensions of this product for shipping purposes.
            [<Config.Form>]
            PackageDimensions: Create'PackageDimensions option
            /// Whether this product is shipped (i.e., physical goods).
            [<Config.Form>]
            Shippable: bool option
            /// An arbitrary string to be displayed on your customer's credit card or bank statement. While most banks display this information consistently, some may display it incorrectly or not at all.
            /// This may be up to 22 characters. The statement description may not include `<`, `>`, `\`, `"`, `'` characters, and will appear on your customer's statement in capital letters. Non-ASCII characters are automatically stripped.
            /// It must contain at least one letter. Only used for subscription payments.
            [<Config.Form>]
            StatementDescriptor: string option
            /// A [tax code](https://docs.stripe.com/tax/tax-categories) ID.
            [<Config.Form>]
            TaxCode: string option
            /// The type of the product. Defaults to `service` if not explicitly specified, enabling use of this product with Subscriptions and Plans. Set this parameter to `good` to use this product with Orders and SKUs. On API versions before `2018-02-05`, this field defaults to `good` for compatibility reasons.
            [<Config.Form>]
            Type: Create'Type option
            /// A label that represents units of this product. When set, this will be included in customers' receipts, invoices, Checkout, and the customer portal.
            [<Config.Form>]
            UnitLabel: string option
            /// A URL of a publicly-accessible webpage for this product.
            [<Config.Form>]
            Url: string option
        }

    module CreateOptions =
        let create
            (
                name: string,
                active: bool option,
                defaultPriceData: Create'DefaultPriceData option,
                description: string option,
                expand: string list option,
                id: string option,
                images: string list option,
                marketingFeatures: Create'MarketingFeatures list option,
                metadata: Map<string, string> option,
                packageDimensions: Create'PackageDimensions option,
                shippable: bool option,
                statementDescriptor: string option,
                taxCode: string option,
                ``type``: Create'Type option,
                unitLabel: string option,
                url: string option
            ) : CreateOptions
            =
            {
              Name = name
              Active = active
              DefaultPriceData = defaultPriceData
              Description = description
              Expand = expand
              Id = id
              Images = images
              MarketingFeatures = marketingFeatures
              Metadata = metadata
              PackageDimensions = packageDimensions
              Shippable = shippable
              StatementDescriptor = statementDescriptor
              TaxCode = taxCode
              Type = ``type``
              UnitLabel = unitLabel
              Url = url
            }

    type DeleteOptions =
        { [<Config.Path>]
          Id: string }

    module DeleteOptions =
        let create
            (
                id: string
            ) : DeleteOptions
            =
            {
              Id = id
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
                id: string,
                expand: string list option
            ) : RetrieveOptions
            =
            {
              Id = id
              Expand = expand
            }

    type Update'MarketingFeatures =
        {
            /// The marketing feature name. Up to 80 characters long.
            [<Config.Form>]
            Name: string option
        }

    module Update'MarketingFeatures =
        let create
            (
                name: string option
            ) : Update'MarketingFeatures
            =
            {
              Name = name
            }

    type Update'PackageDimensionsPackageDimensionsSpecs =
        {
            /// Height, in inches. Maximum precision is 2 decimal places.
            [<Config.Form>]
            Height: decimal option
            /// Length, in inches. Maximum precision is 2 decimal places.
            [<Config.Form>]
            Length: decimal option
            /// Weight, in ounces. Maximum precision is 2 decimal places.
            [<Config.Form>]
            Weight: decimal option
            /// Width, in inches. Maximum precision is 2 decimal places.
            [<Config.Form>]
            Width: decimal option
        }

    module Update'PackageDimensionsPackageDimensionsSpecs =
        let create
            (
                height: decimal option,
                length: decimal option,
                weight: decimal option,
                width: decimal option
            ) : Update'PackageDimensionsPackageDimensionsSpecs
            =
            {
              Height = height
              Length = length
              Weight = weight
              Width = width
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Id: string
            /// Whether the product is available for purchase.
            [<Config.Form>]
            Active: bool option
            /// The ID of the [Price](https://docs.stripe.com/api/prices) object that is the default price for this product.
            [<Config.Form>]
            DefaultPrice: string option
            /// The product's description, meant to be displayable to the customer. Use this field to optionally store a long form explanation of the product being sold for your own rendering purposes.
            [<Config.Form>]
            Description: Choice<string,string> option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// A list of up to 8 URLs of images for this product, meant to be displayable to the customer.
            [<Config.Form>]
            Images: Choice<string list,string> option
            /// A list of up to 15 marketing features for this product. These are displayed in [pricing tables](https://docs.stripe.com/payments/checkout/pricing-table).
            [<Config.Form>]
            MarketingFeatures: Choice<Update'MarketingFeatures list,string> option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The product's name, meant to be displayable to the customer.
            [<Config.Form>]
            Name: string option
            /// The dimensions of this product for shipping purposes.
            [<Config.Form>]
            PackageDimensions: Choice<Update'PackageDimensionsPackageDimensionsSpecs,string> option
            /// Whether this product is shipped (i.e., physical goods).
            [<Config.Form>]
            Shippable: bool option
            /// An arbitrary string to be displayed on your customer's credit card or bank statement. While most banks display this information consistently, some may display it incorrectly or not at all.
            /// This may be up to 22 characters. The statement description may not include `<`, `>`, `\`, `"`, `'` characters, and will appear on your customer's statement in capital letters. Non-ASCII characters are automatically stripped.
            /// It must contain at least one letter. May only be set if `type=service`. Only used for subscription payments.
            [<Config.Form>]
            StatementDescriptor: string option
            /// A [tax code](https://docs.stripe.com/tax/tax-categories) ID.
            [<Config.Form>]
            TaxCode: Choice<string,string> option
            /// A label that represents units of this product. When set, this will be included in customers' receipts, invoices, Checkout, and the customer portal. May only be set if `type=service`.
            [<Config.Form>]
            UnitLabel: Choice<string,string> option
            /// A URL of a publicly-accessible webpage for this product.
            [<Config.Form>]
            Url: Choice<string,string> option
        }

    module UpdateOptions =
        let create
            (
                id: string,
                active: bool option,
                defaultPrice: string option,
                description: Choice<string,string> option,
                expand: string list option,
                images: Choice<string list,string> option,
                marketingFeatures: Choice<Update'MarketingFeatures list,string> option,
                metadata: Map<string, string> option,
                name: string option,
                packageDimensions: Choice<Update'PackageDimensionsPackageDimensionsSpecs,string> option,
                shippable: bool option,
                statementDescriptor: string option,
                taxCode: Choice<string,string> option,
                unitLabel: Choice<string,string> option,
                url: Choice<string,string> option
            ) : UpdateOptions
            =
            {
              Id = id
              Active = active
              DefaultPrice = defaultPrice
              Description = description
              Expand = expand
              Images = images
              MarketingFeatures = marketingFeatures
              Metadata = metadata
              Name = name
              PackageDimensions = packageDimensions
              Shippable = shippable
              StatementDescriptor = statementDescriptor
              TaxCode = taxCode
              UnitLabel = unitLabel
              Url = url
            }

    ///<p>Returns a list of your products. The products are returned sorted by creation date, with the most recently created products appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("active", options.Active |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("ids", options.Ids |> box); ("limit", options.Limit |> box); ("shippable", options.Shippable |> box); ("starting_after", options.StartingAfter |> box); ("type", options.Type |> box); ("url", options.Url |> box)] |> Map.ofList
        $"/v1/products"
        |> RestApi.getAsync<StripeList<Product>> settings qs

    ///<p>Creates a new product object.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/products"
        |> RestApi.postAsync<_, Product> settings (Map.empty) options

    ///<p>Delete a product. Deleting a product is only possible if it has no prices associated with it. Additionally, deleting a product with <code>type=good</code> is only possible if it has no SKUs associated with it.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/products/{options.Id}"
        |> RestApi.deleteAsync<DeletedProduct> settings (Map.empty)

    ///<p>Retrieves the details of an existing product. Supply the unique product ID from either a product creation request or the product list, and Stripe will return the corresponding product information.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/products/{options.Id}"
        |> RestApi.getAsync<Product> settings qs

    ///<p>Updates the specific product by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/products/{options.Id}"
        |> RestApi.postAsync<_, Product> settings (Map.empty) options

module ProductsSearch =

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
            /// The search query string. See [search query language](https://docs.stripe.com/search#search-query-language) and the list of supported [query fields for products](https://docs.stripe.com/search#query-fields-for-products).
            [<Config.Query>]
            Query: string
        }

    module SearchOptions =
        let create
            (
                query: string,
                expand: string list option,
                limit: int option,
                page: string option
            ) : SearchOptions
            =
            {
              Query = query
              Expand = expand
              Limit = limit
              Page = page
            }

    ///<p>Search for products you’ve previously created using Stripe’s <a href="/docs/search#search-query-language">Search Query Language</a>.
    ///Don’t use search in read-after-write flows where strict consistency is necessary. Under normal operating
    ///conditions, data is searchable in less than a minute. Occasionally, propagation of new or updated data can be up
    ///to an hour behind during outages. Search functionality is not available to merchants in India.</p>
    let Search settings (options: SearchOptions) =
        let qs = [("expand", options.Expand |> box); ("limit", options.Limit |> box); ("page", options.Page |> box); ("query", options.Query |> box)] |> Map.ofList
        $"/v1/products/search"
        |> RestApi.getAsync<StripeList<Product>> settings qs

module ProductsFeatures =

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
            [<Config.Path>]
            Product: string
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    module ListOptions =
        let create
            (
                product: string,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option
            ) : ListOptions
            =
            {
              Product = product
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
            }

    type CreateOptions =
        {
            [<Config.Path>]
            Product: string
            /// The ID of the [Feature](https://docs.stripe.com/api/entitlements/feature) object attached to this product.
            [<Config.Form>]
            EntitlementFeature: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module CreateOptions =
        let create
            (
                entitlementFeature: string,
                product: string,
                expand: string list option
            ) : CreateOptions
            =
            {
              EntitlementFeature = entitlementFeature
              Product = product
              Expand = expand
            }

    type DeleteOptions =
        { [<Config.Path>]
          Id: string
          [<Config.Path>]
          Product: string }

    module DeleteOptions =
        let create
            (
                id: string,
                product: string
            ) : DeleteOptions
            =
            {
              Id = id
              Product = product
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// The ID of the product_feature.
            [<Config.Path>]
            Id: string
            /// The ID of the product.
            [<Config.Path>]
            Product: string
        }

    module RetrieveOptions =
        let create
            (
                id: string,
                product: string,
                expand: string list option
            ) : RetrieveOptions
            =
            {
              Id = id
              Product = product
              Expand = expand
            }

    ///<p>Retrieve a list of features for a product</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/products/{options.Product}/features"
        |> RestApi.getAsync<StripeList<ProductFeature>> settings qs

    ///<p>Creates a product_feature, which represents a feature attachment to a product</p>
    let Create settings (options: CreateOptions) =
        $"/v1/products/{options.Product}/features"
        |> RestApi.postAsync<_, ProductFeature> settings (Map.empty) options

    ///<p>Deletes the feature attachment to a product</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/products/{options.Product}/features/{options.Id}"
        |> RestApi.deleteAsync<DeletedProductFeature> settings (Map.empty)

    ///<p>Retrieves a product_feature, which represents a feature attachment to a product</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/products/{options.Product}/features/{options.Id}"
        |> RestApi.getAsync<ProductFeature> settings qs

