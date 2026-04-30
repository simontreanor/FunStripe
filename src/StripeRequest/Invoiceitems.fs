namespace StripeRequest.Invoiceitems

open FunStripe
open System.Text.Json.Serialization
open Stripe.Invoiceitem
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module Invoiceitems =

    type ListOptions =
        {
            /// Only return invoice items that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            /// The identifier of the customer whose invoice items to return. If none is provided, returns all invoice items.
            [<Config.Query>]
            Customer: string option
            /// The identifier of the account representing the customer whose invoice items to return. If none is provided, returns all invoice items.
            [<Config.Query>]
            CustomerAccount: string option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// Only return invoice items belonging to this invoice. If none is provided, all invoice items will be returned. If specifying an invoice, no customer identifier is needed.
            [<Config.Query>]
            Invoice: string option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// Set to `true` to only show pending invoice items, which are not yet attached to any invoices. Set to `false` to only show invoice items already attached to invoices. If unspecified, no filter is applied.
            [<Config.Query>]
            Pending: bool option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    module ListOptions =
        let create
            (
                created: int option,
                customer: string option,
                customerAccount: string option,
                endingBefore: string option,
                expand: string list option,
                invoice: string option,
                limit: int option,
                pending: bool option,
                startingAfter: string option
            ) : ListOptions
            =
            {
              Created = created
              Customer = customer
              CustomerAccount = customerAccount
              EndingBefore = endingBefore
              Expand = expand
              Invoice = invoice
              Limit = limit
              Pending = pending
              StartingAfter = startingAfter
            }

    type Create'Discounts =
        {
            /// ID of the coupon to create a new discount for.
            [<Config.Form>]
            Coupon: string option
            /// ID of an existing discount on the object (or one of its ancestors) to reuse.
            [<Config.Form>]
            Discount: string option
            /// ID of the promotion code to create a new discount for.
            [<Config.Form>]
            PromotionCode: string option
        }

    module Create'Discounts =
        let create
            (
                coupon: string option,
                discount: string option,
                promotionCode: string option
            ) : Create'Discounts
            =
            {
              Coupon = coupon
              Discount = discount
              PromotionCode = promotionCode
            }

    type Create'Period =
        {
            /// The end of the period, which must be greater than or equal to the start. This value is inclusive.
            [<Config.Form>]
            End: DateTime option
            /// The start of the period. This value is inclusive.
            [<Config.Form>]
            Start: DateTime option
        }

    module Create'Period =
        let create
            (
                ``end``: DateTime option,
                start: DateTime option
            ) : Create'Period
            =
            {
              End = ``end``
              Start = start
            }

    type Create'PriceDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type Create'PriceData =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.
            [<Config.Form>]
            Product: string option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: Create'PriceDataTaxBehavior option
            /// A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    module Create'PriceData =
        let create
            (
                currency: IsoTypes.IsoCurrencyCode option,
                product: string option,
                taxBehavior: Create'PriceDataTaxBehavior option,
                unitAmount: int option,
                unitAmountDecimal: string option
            ) : Create'PriceData
            =
            {
              Currency = currency
              Product = product
              TaxBehavior = taxBehavior
              UnitAmount = unitAmount
              UnitAmountDecimal = unitAmountDecimal
            }

    type Create'Pricing =
        {
            /// The ID of the price object.
            [<Config.Form>]
            Price: string option
        }

    module Create'Pricing =
        let create
            (
                price: string option
            ) : Create'Pricing
            =
            {
              Price = price
            }

    type Create'TaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type CreateOptions =
        {
            /// The integer amount in cents (or local equivalent) of the charge to be applied to the upcoming invoice. Passing in a negative `amount` will reduce the `amount_due` on the invoice.
            [<Config.Form>]
            Amount: int option
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The ID of the customer to bill for this invoice item.
            [<Config.Form>]
            Customer: string option
            /// The ID of the account representing the customer to bill for this invoice item.
            [<Config.Form>]
            CustomerAccount: string option
            /// An arbitrary string which you can attach to the invoice item. The description is displayed in the invoice for easy tracking.
            [<Config.Form>]
            Description: string option
            /// Controls whether discounts apply to this invoice item. Defaults to false for prorations or negative invoice items, and true for all other invoice items.
            [<Config.Form>]
            Discountable: bool option
            /// The coupons and promotion codes to redeem into discounts for the invoice item or invoice line item.
            [<Config.Form>]
            Discounts: Choice<Create'Discounts list,string> option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The ID of an existing invoice to add this invoice item to. For subscription invoices, when left blank, the invoice item will be added to the next upcoming scheduled invoice. For standalone invoices, the invoice item won't be automatically added unless you pass `pending_invoice_item_behavior: 'include'` when creating the invoice. This is useful when adding invoice items in response to an invoice.created webhook. You can only add invoice items to draft invoices and there is a maximum of 250 items per invoice.
            [<Config.Form>]
            Invoice: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The period associated with this invoice item. When set to different values, the period will be rendered on the invoice. If you have [Stripe Revenue Recognition](https://docs.stripe.com/revenue-recognition) enabled, the period will be used to recognize and defer revenue. See the [Revenue Recognition documentation](https://docs.stripe.com/revenue-recognition/methodology/subscriptions-and-invoicing) for details.
            [<Config.Form>]
            Period: Create'Period option
            /// Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline.
            [<Config.Form>]
            PriceData: Create'PriceData option
            /// The pricing information for the invoice item.
            [<Config.Form>]
            Pricing: Create'Pricing option
            /// Non-negative integer. The quantity of units for the invoice item. Use `quantity_decimal` instead to provide decimal precision. This field will be deprecated in favor of `quantity_decimal` in a future version.
            [<Config.Form>]
            Quantity: int option
            /// Non-negative decimal with at most 12 decimal places. The quantity of units for the invoice item.
            [<Config.Form>]
            QuantityDecimal: string option
            /// The ID of a subscription to add this invoice item to. When left blank, the invoice item is added to the next upcoming scheduled invoice. When set, scheduled invoices for subscriptions other than the specified subscription will ignore the invoice item. Use this when you want to express that an invoice item has been accrued within the context of a particular subscription.
            [<Config.Form>]
            Subscription: string option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: Create'TaxBehavior option
            /// A [tax code](https://docs.stripe.com/tax/tax-categories) ID.
            [<Config.Form>]
            TaxCode: Choice<string,string> option
            /// The tax rates which apply to the invoice item. When set, the `default_tax_rates` on the invoice do not apply to this invoice item.
            [<Config.Form>]
            TaxRates: string list option
            /// The decimal unit amount in cents (or local equivalent) of the charge to be applied to the upcoming invoice. This `unit_amount_decimal` will be multiplied by the quantity to get the full amount. Passing in a negative `unit_amount_decimal` will reduce the `amount_due` on the invoice. Accepts at most 12 decimal places.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    module CreateOptions =
        let create
            (
                amount: int option,
                currency: IsoTypes.IsoCurrencyCode option,
                customer: string option,
                customerAccount: string option,
                description: string option,
                discountable: bool option,
                discounts: Choice<Create'Discounts list,string> option,
                expand: string list option,
                invoice: string option,
                metadata: Map<string, string> option,
                period: Create'Period option,
                priceData: Create'PriceData option,
                pricing: Create'Pricing option,
                quantity: int option,
                quantityDecimal: string option,
                subscription: string option,
                taxBehavior: Create'TaxBehavior option,
                taxCode: Choice<string,string> option,
                taxRates: string list option,
                unitAmountDecimal: string option
            ) : CreateOptions
            =
            {
              Amount = amount
              Currency = currency
              Customer = customer
              CustomerAccount = customerAccount
              Description = description
              Discountable = discountable
              Discounts = discounts
              Expand = expand
              Invoice = invoice
              Metadata = metadata
              Period = period
              PriceData = priceData
              Pricing = pricing
              Quantity = quantity
              QuantityDecimal = quantityDecimal
              Subscription = subscription
              TaxBehavior = taxBehavior
              TaxCode = taxCode
              TaxRates = taxRates
              UnitAmountDecimal = unitAmountDecimal
            }

    type DeleteOptions =
        { [<Config.Path>]
          Invoiceitem: string }

    module DeleteOptions =
        let create
            (
                invoiceitem: string
            ) : DeleteOptions
            =
            {
              Invoiceitem = invoiceitem
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Invoiceitem: string
        }

    module RetrieveOptions =
        let create
            (
                invoiceitem: string
            ) : RetrieveOptions
            =
            {
              Invoiceitem = invoiceitem
              Expand = None
            }

    type Update'Discounts =
        {
            /// ID of the coupon to create a new discount for.
            [<Config.Form>]
            Coupon: string option
            /// ID of an existing discount on the object (or one of its ancestors) to reuse.
            [<Config.Form>]
            Discount: string option
            /// ID of the promotion code to create a new discount for.
            [<Config.Form>]
            PromotionCode: string option
        }

    module Update'Discounts =
        let create
            (
                coupon: string option,
                discount: string option,
                promotionCode: string option
            ) : Update'Discounts
            =
            {
              Coupon = coupon
              Discount = discount
              PromotionCode = promotionCode
            }

    type Update'Period =
        {
            /// The end of the period, which must be greater than or equal to the start. This value is inclusive.
            [<Config.Form>]
            End: DateTime option
            /// The start of the period. This value is inclusive.
            [<Config.Form>]
            Start: DateTime option
        }

    module Update'Period =
        let create
            (
                ``end``: DateTime option,
                start: DateTime option
            ) : Update'Period
            =
            {
              End = ``end``
              Start = start
            }

    type Update'PriceDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type Update'PriceData =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.
            [<Config.Form>]
            Product: string option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: Update'PriceDataTaxBehavior option
            /// A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    module Update'PriceData =
        let create
            (
                currency: IsoTypes.IsoCurrencyCode option,
                product: string option,
                taxBehavior: Update'PriceDataTaxBehavior option,
                unitAmount: int option,
                unitAmountDecimal: string option
            ) : Update'PriceData
            =
            {
              Currency = currency
              Product = product
              TaxBehavior = taxBehavior
              UnitAmount = unitAmount
              UnitAmountDecimal = unitAmountDecimal
            }

    type Update'Pricing =
        {
            /// The ID of the price object.
            [<Config.Form>]
            Price: string option
        }

    module Update'Pricing =
        let create
            (
                price: string option
            ) : Update'Pricing
            =
            {
              Price = price
            }

    type Update'TaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type UpdateOptions =
        {
            [<Config.Path>]
            Invoiceitem: string
            /// The integer amount in cents (or local equivalent) of the charge to be applied to the upcoming invoice. If you want to apply a credit to the customer's account, pass a negative amount.
            [<Config.Form>]
            Amount: int option
            /// An arbitrary string which you can attach to the invoice item. The description is displayed in the invoice for easy tracking.
            [<Config.Form>]
            Description: string option
            /// Controls whether discounts apply to this invoice item. Defaults to false for prorations or negative invoice items, and true for all other invoice items. Cannot be set to true for prorations.
            [<Config.Form>]
            Discountable: bool option
            /// The coupons, promotion codes & existing discounts which apply to the invoice item or invoice line item. Item discounts are applied before invoice discounts. Pass an empty string to remove previously-defined discounts.
            [<Config.Form>]
            Discounts: Choice<Update'Discounts list,string> option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The period associated with this invoice item. When set to different values, the period will be rendered on the invoice. If you have [Stripe Revenue Recognition](https://docs.stripe.com/revenue-recognition) enabled, the period will be used to recognize and defer revenue. See the [Revenue Recognition documentation](https://docs.stripe.com/revenue-recognition/methodology/subscriptions-and-invoicing) for details.
            [<Config.Form>]
            Period: Update'Period option
            /// Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline.
            [<Config.Form>]
            PriceData: Update'PriceData option
            /// The pricing information for the invoice item.
            [<Config.Form>]
            Pricing: Update'Pricing option
            /// Non-negative integer. The quantity of units for the invoice item. Use `quantity_decimal` instead to provide decimal precision. This field will be deprecated in favor of `quantity_decimal` in a future version.
            [<Config.Form>]
            Quantity: int option
            /// Non-negative decimal with at most 12 decimal places. The quantity of units for the line item.
            [<Config.Form>]
            QuantityDecimal: string option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: Update'TaxBehavior option
            /// A [tax code](https://docs.stripe.com/tax/tax-categories) ID.
            [<Config.Form>]
            TaxCode: Choice<string,string> option
            /// The tax rates which apply to the invoice item. When set, the `default_tax_rates` on the invoice do not apply to this invoice item. Pass an empty string to remove previously-defined tax rates.
            [<Config.Form>]
            TaxRates: Choice<string list,string> option
            /// The decimal unit amount in cents (or local equivalent) of the charge to be applied to the upcoming invoice. This `unit_amount_decimal` will be multiplied by the quantity to get the full amount. Passing in a negative `unit_amount_decimal` will reduce the `amount_due` on the invoice. Accepts at most 12 decimal places.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    module UpdateOptions =
        let create
            (
                invoiceitem: string
            ) : UpdateOptions
            =
            {
              Invoiceitem = invoiceitem
              Amount = None
              Description = None
              Discountable = None
              Discounts = None
              Expand = None
              Metadata = None
              Period = None
              PriceData = None
              Pricing = None
              Quantity = None
              QuantityDecimal = None
              TaxBehavior = None
              TaxCode = None
              TaxRates = None
              UnitAmountDecimal = None
            }

    ///<p>Returns a list of your invoice items. Invoice items are returned sorted by creation date, with the most recently created invoice items appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("customer", options.Customer |> box); ("customer_account", options.CustomerAccount |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("invoice", options.Invoice |> box); ("limit", options.Limit |> box); ("pending", options.Pending |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/invoiceitems"
        |> RestApi.getAsync<StripeList<Invoiceitem>> settings qs

    ///<p>Creates an item to be added to a draft invoice (up to 250 items per invoice). If no invoice is specified, the item will be on the next invoice created for the customer specified.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/invoiceitems"
        |> RestApi.postAsync<_, Invoiceitem> settings (Map.empty) options

    ///<p>Deletes an invoice item, removing it from an invoice. Deleting invoice items is only possible when they’re not attached to invoices, or if it’s attached to a draft invoice.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/invoiceitems/{options.Invoiceitem}"
        |> RestApi.deleteAsync<DeletedInvoiceitem> settings (Map.empty)

    ///<p>Retrieves the invoice item with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/invoiceitems/{options.Invoiceitem}"
        |> RestApi.getAsync<Invoiceitem> settings qs

    ///<p>Updates the amount or description of an invoice item on an upcoming invoice. Updating an invoice item is only possible before the invoice it’s attached to is closed.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/invoiceitems/{options.Invoiceitem}"
        |> RestApi.postAsync<_, Invoiceitem> settings (Map.empty) options

