namespace StripeRequest.Quotes

open FunStripe
open System.Text.Json.Serialization
open Stripe.Payment
open Stripe.Quote
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
module Quotes =

    type ListOptions =
        {
            /// The ID of the customer whose quotes you're retrieving.
            [<Config.Query>]
            Customer: string option
            /// The ID of the account representing the customer whose quotes you're retrieving.
            [<Config.Query>]
            CustomerAccount: string option
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
            /// The status of the quote.
            [<Config.Query>]
            Status: string option
            /// Provides a list of quotes that are associated with the specified test clock. The response will not include quotes with test clocks if this and the customer parameter is not set.
            [<Config.Query>]
            TestClock: string option
        }

    module ListOptions =
        let create
            (
                customer: string option,
                customerAccount: string option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option,
                status: string option,
                testClock: string option
            ) : ListOptions
            =
            {
              Customer = customer
              CustomerAccount = customerAccount
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
              Status = status
              TestClock = testClock
            }

    type Create'AutomaticTaxLiabilityType =
        | Account
        | Self

    type Create'AutomaticTaxLiability =
        {
            /// The connected account being referenced when `type` is `account`.
            [<Config.Form>]
            Account: string option
            /// Type of the account referenced in the request.
            [<Config.Form>]
            Type: Create'AutomaticTaxLiabilityType option
        }

    module Create'AutomaticTaxLiability =
        let create
            (
                account: string option,
                ``type``: Create'AutomaticTaxLiabilityType option
            ) : Create'AutomaticTaxLiability
            =
            {
              Account = account
              Type = ``type``
            }

    type Create'AutomaticTax =
        {
            /// Controls whether Stripe will automatically compute tax on the resulting invoices or subscriptions as well as the quote itself.
            [<Config.Form>]
            Enabled: bool option
            /// The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.
            [<Config.Form>]
            Liability: Create'AutomaticTaxLiability option
        }

    module Create'AutomaticTax =
        let create
            (
                enabled: bool option,
                liability: Create'AutomaticTaxLiability option
            ) : Create'AutomaticTax
            =
            {
              Enabled = enabled
              Liability = liability
            }

    type Create'CollectionMethod =
        | ChargeAutomatically
        | SendInvoice

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

    type Create'FromQuote =
        {
            /// Whether this quote is a revision of the previous quote.
            [<Config.Form>]
            IsRevision: bool option
            /// The `id` of the quote that will be cloned.
            [<Config.Form>]
            Quote: string option
        }

    module Create'FromQuote =
        let create
            (
                isRevision: bool option,
                quote: string option
            ) : Create'FromQuote
            =
            {
              IsRevision = isRevision
              Quote = quote
            }

    type Create'InvoiceSettingsIssuerType =
        | Account
        | Self

    type Create'InvoiceSettingsIssuer =
        {
            /// The connected account being referenced when `type` is `account`.
            [<Config.Form>]
            Account: string option
            /// Type of the account referenced in the request.
            [<Config.Form>]
            Type: Create'InvoiceSettingsIssuerType option
        }

    module Create'InvoiceSettingsIssuer =
        let create
            (
                account: string option,
                ``type``: Create'InvoiceSettingsIssuerType option
            ) : Create'InvoiceSettingsIssuer
            =
            {
              Account = account
              Type = ``type``
            }

    type Create'InvoiceSettings =
        {
            /// Number of days within which a customer must pay the invoice generated by this quote. This value will be `null` for quotes where `collection_method=charge_automatically`.
            [<Config.Form>]
            DaysUntilDue: int option
            /// The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.
            [<Config.Form>]
            Issuer: Create'InvoiceSettingsIssuer option
        }

    module Create'InvoiceSettings =
        let create
            (
                daysUntilDue: int option,
                issuer: Create'InvoiceSettingsIssuer option
            ) : Create'InvoiceSettings
            =
            {
              DaysUntilDue = daysUntilDue
              Issuer = issuer
            }

    type Create'LineItemsDiscounts =
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

    module Create'LineItemsDiscounts =
        let create
            (
                coupon: string option,
                discount: string option,
                promotionCode: string option
            ) : Create'LineItemsDiscounts
            =
            {
              Coupon = coupon
              Discount = discount
              PromotionCode = promotionCode
            }

    type Create'LineItemsPriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    type Create'LineItemsPriceDataRecurring =
        {
            /// Specifies billing frequency. Either `day`, `week`, `month` or `year`.
            [<Config.Form>]
            Interval: Create'LineItemsPriceDataRecurringInterval option
            /// The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).
            [<Config.Form>]
            IntervalCount: int option
        }

    module Create'LineItemsPriceDataRecurring =
        let create
            (
                interval: Create'LineItemsPriceDataRecurringInterval option,
                intervalCount: int option
            ) : Create'LineItemsPriceDataRecurring
            =
            {
              Interval = interval
              IntervalCount = intervalCount
            }

    type Create'LineItemsPriceDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type Create'LineItemsPriceData =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.
            [<Config.Form>]
            Product: string option
            /// The recurring components of a price such as `interval` and `interval_count`.
            [<Config.Form>]
            Recurring: Create'LineItemsPriceDataRecurring option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: Create'LineItemsPriceDataTaxBehavior option
            /// A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    module Create'LineItemsPriceData =
        let create
            (
                currency: IsoTypes.IsoCurrencyCode option,
                product: string option,
                recurring: Create'LineItemsPriceDataRecurring option,
                taxBehavior: Create'LineItemsPriceDataTaxBehavior option,
                unitAmount: int option,
                unitAmountDecimal: string option
            ) : Create'LineItemsPriceData
            =
            {
              Currency = currency
              Product = product
              Recurring = recurring
              TaxBehavior = taxBehavior
              UnitAmount = unitAmount
              UnitAmountDecimal = unitAmountDecimal
            }

    type Create'LineItems =
        {
            /// The discounts applied to this line item.
            [<Config.Form>]
            Discounts: Choice<Create'LineItemsDiscounts list,string> option
            /// The ID of the price object. One of `price` or `price_data` is required.
            [<Config.Form>]
            Price: string option
            /// Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.
            [<Config.Form>]
            PriceData: Create'LineItemsPriceData option
            /// The quantity of the line item.
            [<Config.Form>]
            Quantity: int option
            /// The tax rates which apply to the line item. When set, the `default_tax_rates` on the quote do not apply to this line item.
            [<Config.Form>]
            TaxRates: Choice<string list,string> option
        }

    module Create'LineItems =
        let create
            (
                discounts: Choice<Create'LineItemsDiscounts list,string> option,
                price: string option,
                priceData: Create'LineItemsPriceData option,
                quantity: int option,
                taxRates: Choice<string list,string> option
            ) : Create'LineItems
            =
            {
              Discounts = discounts
              Price = price
              PriceData = priceData
              Quantity = quantity
              TaxRates = taxRates
            }

    type Create'SubscriptionDataBillingModeFlexibleProrationDiscounts =
        | Included
        | Itemized

    type Create'SubscriptionDataBillingModeFlexible =
        {
            /// Controls how invoices and invoice items display proration amounts and discount amounts.
            [<Config.Form>]
            ProrationDiscounts: Create'SubscriptionDataBillingModeFlexibleProrationDiscounts option
        }

    module Create'SubscriptionDataBillingModeFlexible =
        let create
            (
                prorationDiscounts: Create'SubscriptionDataBillingModeFlexibleProrationDiscounts option
            ) : Create'SubscriptionDataBillingModeFlexible
            =
            {
              ProrationDiscounts = prorationDiscounts
            }

    type Create'SubscriptionDataBillingModeType =
        | Classic
        | Flexible

    type Create'SubscriptionDataBillingMode =
        {
            /// Configure behavior for flexible billing mode.
            [<Config.Form>]
            Flexible: Create'SubscriptionDataBillingModeFlexible option
            /// Controls the calculation and orchestration of prorations and invoices for subscriptions. If no value is passed, the default is `flexible`.
            [<Config.Form>]
            Type: Create'SubscriptionDataBillingModeType option
        }

    module Create'SubscriptionDataBillingMode =
        let create
            (
                flexible: Create'SubscriptionDataBillingModeFlexible option,
                ``type``: Create'SubscriptionDataBillingModeType option
            ) : Create'SubscriptionDataBillingMode
            =
            {
              Flexible = flexible
              Type = ``type``
            }

    type Create'SubscriptionDataEffectiveDate = | CurrentPeriodEnd

    type Create'SubscriptionData =
        {
            /// Controls how prorations and invoices for subscriptions are calculated and orchestrated.
            [<Config.Form>]
            BillingMode: Create'SubscriptionDataBillingMode option
            /// The subscription's description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription for rendering in Stripe surfaces and certain local payment methods UIs.
            [<Config.Form>]
            Description: string option
            /// When creating a new subscription, the date of which the subscription schedule will start after the quote is accepted. The `effective_date` is ignored if it is in the past when the quote is accepted.
            [<Config.Form>]
            EffectiveDate: Choice<Create'SubscriptionDataEffectiveDate,DateTime,string> option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that will set metadata on the subscription or subscription schedule when the quote is accepted. If a recurring price is included in `line_items`, this field will be passed to the resulting subscription's `metadata` field. If `subscription_data.effective_date` is used, this field will be passed to the resulting subscription schedule's `phases.metadata` field. Unlike object-level metadata, this field is declarative. Updates will clear prior values.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Integer representing the number of trial period days before the customer is charged for the first time.
            [<Config.Form>]
            TrialPeriodDays: Choice<int,string> option
        }

    module Create'SubscriptionData =
        let create
            (
                billingMode: Create'SubscriptionDataBillingMode option,
                description: string option,
                effectiveDate: Choice<Create'SubscriptionDataEffectiveDate,DateTime,string> option,
                metadata: Map<string, string> option,
                trialPeriodDays: Choice<int,string> option
            ) : Create'SubscriptionData
            =
            {
              BillingMode = billingMode
              Description = description
              EffectiveDate = effectiveDate
              Metadata = metadata
              TrialPeriodDays = trialPeriodDays
            }

    type Create'TransferDataTransferDataSpecs =
        {
            /// The amount that will be transferred automatically when the invoice is paid. If no amount is set, the full amount is transferred. There cannot be any line items with recurring prices when using this field.
            [<Config.Form>]
            Amount: int option
            /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination. There must be at least 1 line item with a recurring price to use this field.
            [<Config.Form>]
            AmountPercent: decimal option
            /// ID of an existing, connected Stripe account.
            [<Config.Form>]
            Destination: string option
        }

    module Create'TransferDataTransferDataSpecs =
        let create
            (
                amount: int option,
                amountPercent: decimal option,
                destination: string option
            ) : Create'TransferDataTransferDataSpecs
            =
            {
              Amount = amount
              AmountPercent = amountPercent
              Destination = destination
            }

    type CreateOptions =
        {
            /// The amount of the application fee (if any) that will be requested to be applied to the payment and transferred to the application owner's Stripe account. There cannot be any line items with recurring prices when using this field.
            [<Config.Form>]
            ApplicationFeeAmount: Choice<int,string> option
            /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. There must be at least 1 line item with a recurring price to use this field.
            [<Config.Form>]
            ApplicationFeePercent: Choice<decimal,string> option
            /// Settings for automatic tax lookup for this quote and resulting invoices and subscriptions.
            [<Config.Form>]
            AutomaticTax: Create'AutomaticTax option
            /// Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay invoices at the end of the subscription cycle or at invoice finalization using the default payment method attached to the subscription or customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically`.
            [<Config.Form>]
            CollectionMethod: Create'CollectionMethod option
            /// The customer for which this quote belongs to. A customer is required before finalizing the quote. Once specified, it cannot be changed.
            [<Config.Form>]
            Customer: string option
            /// The account for which this quote belongs to. A customer or account is required before finalizing the quote. Once specified, it cannot be changed.
            [<Config.Form>]
            CustomerAccount: string option
            /// The tax rates that will apply to any line item that does not have `tax_rates` set.
            [<Config.Form>]
            DefaultTaxRates: Choice<string list,string> option
            /// A description that will be displayed on the quote PDF. If no value is passed, the default description configured in your [quote template settings](https://dashboard.stripe.com/settings/billing/quote) will be used.
            [<Config.Form>]
            Description: Choice<string,string> option
            /// The discounts applied to the quote.
            [<Config.Form>]
            Discounts: Choice<Create'Discounts list,string> option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// A future timestamp on which the quote will be canceled if in `open` or `draft` status. Measured in seconds since the Unix epoch. If no value is passed, the default expiration date configured in your [quote template settings](https://dashboard.stripe.com/settings/billing/quote) will be used.
            [<Config.Form>]
            ExpiresAt: DateTime option
            /// A footer that will be displayed on the quote PDF. If no value is passed, the default footer configured in your [quote template settings](https://dashboard.stripe.com/settings/billing/quote) will be used.
            [<Config.Form>]
            Footer: Choice<string,string> option
            /// Clone an existing quote. The new quote will be created in `status=draft`. When using this parameter, you cannot specify any other parameters except for `expires_at`.
            [<Config.Form>]
            FromQuote: Create'FromQuote option
            /// A header that will be displayed on the quote PDF. If no value is passed, the default header configured in your [quote template settings](https://dashboard.stripe.com/settings/billing/quote) will be used.
            [<Config.Form>]
            Header: Choice<string,string> option
            /// All invoices will be billed using the specified settings.
            [<Config.Form>]
            InvoiceSettings: Create'InvoiceSettings option
            /// A list of line items the customer is being quoted for. Each line item includes information about the product, the quantity, and the resulting cost.
            [<Config.Form>]
            LineItems: Create'LineItems list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The account on behalf of which to charge.
            [<Config.Form>]
            OnBehalfOf: Choice<string,string> option
            /// When creating a subscription or subscription schedule, the specified configuration data will be used. There must be at least one line item with a recurring price for a subscription or subscription schedule to be created. A subscription schedule is created if `subscription_data[effective_date]` is present and in the future, otherwise a subscription is created.
            [<Config.Form>]
            SubscriptionData: Create'SubscriptionData option
            /// ID of the test clock to attach to the quote.
            [<Config.Form>]
            TestClock: string option
            /// The data with which to automatically create a Transfer for each of the invoices.
            [<Config.Form>]
            TransferData: Choice<Create'TransferDataTransferDataSpecs,string> option
        }

    module CreateOptions =
        let create
            (
                applicationFeeAmount: Choice<int,string> option,
                applicationFeePercent: Choice<decimal,string> option,
                automaticTax: Create'AutomaticTax option,
                collectionMethod: Create'CollectionMethod option,
                customer: string option,
                customerAccount: string option,
                defaultTaxRates: Choice<string list,string> option,
                description: Choice<string,string> option,
                discounts: Choice<Create'Discounts list,string> option,
                expand: string list option,
                expiresAt: DateTime option,
                footer: Choice<string,string> option,
                fromQuote: Create'FromQuote option,
                header: Choice<string,string> option,
                invoiceSettings: Create'InvoiceSettings option,
                lineItems: Create'LineItems list option,
                metadata: Map<string, string> option,
                onBehalfOf: Choice<string,string> option,
                subscriptionData: Create'SubscriptionData option,
                testClock: string option,
                transferData: Choice<Create'TransferDataTransferDataSpecs,string> option
            ) : CreateOptions
            =
            {
              ApplicationFeeAmount = applicationFeeAmount
              ApplicationFeePercent = applicationFeePercent
              AutomaticTax = automaticTax
              CollectionMethod = collectionMethod
              Customer = customer
              CustomerAccount = customerAccount
              DefaultTaxRates = defaultTaxRates
              Description = description
              Discounts = discounts
              Expand = expand
              ExpiresAt = expiresAt
              Footer = footer
              FromQuote = fromQuote
              Header = header
              InvoiceSettings = invoiceSettings
              LineItems = lineItems
              Metadata = metadata
              OnBehalfOf = onBehalfOf
              SubscriptionData = subscriptionData
              TestClock = testClock
              TransferData = transferData
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Quote: string
        }

    module RetrieveOptions =
        let create
            (
                quote: string
            ) : RetrieveOptions
            =
            {
              Quote = quote
              Expand = None
            }

    type Update'AutomaticTaxLiabilityType =
        | Account
        | Self

    type Update'AutomaticTaxLiability =
        {
            /// The connected account being referenced when `type` is `account`.
            [<Config.Form>]
            Account: string option
            /// Type of the account referenced in the request.
            [<Config.Form>]
            Type: Update'AutomaticTaxLiabilityType option
        }

    module Update'AutomaticTaxLiability =
        let create
            (
                account: string option,
                ``type``: Update'AutomaticTaxLiabilityType option
            ) : Update'AutomaticTaxLiability
            =
            {
              Account = account
              Type = ``type``
            }

    type Update'AutomaticTax =
        {
            /// Controls whether Stripe will automatically compute tax on the resulting invoices or subscriptions as well as the quote itself.
            [<Config.Form>]
            Enabled: bool option
            /// The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.
            [<Config.Form>]
            Liability: Update'AutomaticTaxLiability option
        }

    module Update'AutomaticTax =
        let create
            (
                enabled: bool option,
                liability: Update'AutomaticTaxLiability option
            ) : Update'AutomaticTax
            =
            {
              Enabled = enabled
              Liability = liability
            }

    type Update'CollectionMethod =
        | ChargeAutomatically
        | SendInvoice

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

    type Update'InvoiceSettingsIssuerType =
        | Account
        | Self

    type Update'InvoiceSettingsIssuer =
        {
            /// The connected account being referenced when `type` is `account`.
            [<Config.Form>]
            Account: string option
            /// Type of the account referenced in the request.
            [<Config.Form>]
            Type: Update'InvoiceSettingsIssuerType option
        }

    module Update'InvoiceSettingsIssuer =
        let create
            (
                account: string option,
                ``type``: Update'InvoiceSettingsIssuerType option
            ) : Update'InvoiceSettingsIssuer
            =
            {
              Account = account
              Type = ``type``
            }

    type Update'InvoiceSettings =
        {
            /// Number of days within which a customer must pay the invoice generated by this quote. This value will be `null` for quotes where `collection_method=charge_automatically`.
            [<Config.Form>]
            DaysUntilDue: int option
            /// The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.
            [<Config.Form>]
            Issuer: Update'InvoiceSettingsIssuer option
        }

    module Update'InvoiceSettings =
        let create
            (
                daysUntilDue: int option,
                issuer: Update'InvoiceSettingsIssuer option
            ) : Update'InvoiceSettings
            =
            {
              DaysUntilDue = daysUntilDue
              Issuer = issuer
            }

    type Update'LineItemsDiscounts =
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

    module Update'LineItemsDiscounts =
        let create
            (
                coupon: string option,
                discount: string option,
                promotionCode: string option
            ) : Update'LineItemsDiscounts
            =
            {
              Coupon = coupon
              Discount = discount
              PromotionCode = promotionCode
            }

    type Update'LineItemsPriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    type Update'LineItemsPriceDataRecurring =
        {
            /// Specifies billing frequency. Either `day`, `week`, `month` or `year`.
            [<Config.Form>]
            Interval: Update'LineItemsPriceDataRecurringInterval option
            /// The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).
            [<Config.Form>]
            IntervalCount: int option
        }

    module Update'LineItemsPriceDataRecurring =
        let create
            (
                interval: Update'LineItemsPriceDataRecurringInterval option,
                intervalCount: int option
            ) : Update'LineItemsPriceDataRecurring
            =
            {
              Interval = interval
              IntervalCount = intervalCount
            }

    type Update'LineItemsPriceDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type Update'LineItemsPriceData =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.
            [<Config.Form>]
            Product: string option
            /// The recurring components of a price such as `interval` and `interval_count`.
            [<Config.Form>]
            Recurring: Update'LineItemsPriceDataRecurring option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: Update'LineItemsPriceDataTaxBehavior option
            /// A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    module Update'LineItemsPriceData =
        let create
            (
                currency: IsoTypes.IsoCurrencyCode option,
                product: string option,
                recurring: Update'LineItemsPriceDataRecurring option,
                taxBehavior: Update'LineItemsPriceDataTaxBehavior option,
                unitAmount: int option,
                unitAmountDecimal: string option
            ) : Update'LineItemsPriceData
            =
            {
              Currency = currency
              Product = product
              Recurring = recurring
              TaxBehavior = taxBehavior
              UnitAmount = unitAmount
              UnitAmountDecimal = unitAmountDecimal
            }

    type Update'LineItems =
        {
            /// The discounts applied to this line item.
            [<Config.Form>]
            Discounts: Choice<Update'LineItemsDiscounts list,string> option
            /// The ID of an existing line item on the quote.
            [<Config.Form>]
            Id: string option
            /// The ID of the price object. One of `price` or `price_data` is required.
            [<Config.Form>]
            Price: string option
            /// Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.
            [<Config.Form>]
            PriceData: Update'LineItemsPriceData option
            /// The quantity of the line item.
            [<Config.Form>]
            Quantity: int option
            /// The tax rates which apply to the line item. When set, the `default_tax_rates` on the quote do not apply to this line item.
            [<Config.Form>]
            TaxRates: Choice<string list,string> option
        }

    module Update'LineItems =
        let create
            (
                discounts: Choice<Update'LineItemsDiscounts list,string> option,
                id: string option,
                price: string option,
                priceData: Update'LineItemsPriceData option,
                quantity: int option,
                taxRates: Choice<string list,string> option
            ) : Update'LineItems
            =
            {
              Discounts = discounts
              Id = id
              Price = price
              PriceData = priceData
              Quantity = quantity
              TaxRates = taxRates
            }

    type Update'SubscriptionDataEffectiveDate = | CurrentPeriodEnd

    type Update'SubscriptionData =
        {
            /// The subscription's description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription for rendering in Stripe surfaces and certain local payment methods UIs.
            [<Config.Form>]
            Description: Choice<string,string> option
            /// When creating a new subscription, the date of which the subscription schedule will start after the quote is accepted. The `effective_date` is ignored if it is in the past when the quote is accepted.
            [<Config.Form>]
            EffectiveDate: Choice<Update'SubscriptionDataEffectiveDate,DateTime,string> option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that will set metadata on the subscription or subscription schedule when the quote is accepted. If a recurring price is included in `line_items`, this field will be passed to the resulting subscription's `metadata` field. If `subscription_data.effective_date` is used, this field will be passed to the resulting subscription schedule's `phases.metadata` field. Unlike object-level metadata, this field is declarative. Updates will clear prior values.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Integer representing the number of trial period days before the customer is charged for the first time.
            [<Config.Form>]
            TrialPeriodDays: Choice<int,string> option
        }

    module Update'SubscriptionData =
        let create
            (
                description: Choice<string,string> option,
                effectiveDate: Choice<Update'SubscriptionDataEffectiveDate,DateTime,string> option,
                metadata: Map<string, string> option,
                trialPeriodDays: Choice<int,string> option
            ) : Update'SubscriptionData
            =
            {
              Description = description
              EffectiveDate = effectiveDate
              Metadata = metadata
              TrialPeriodDays = trialPeriodDays
            }

    type Update'TransferDataTransferDataSpecs =
        {
            /// The amount that will be transferred automatically when the invoice is paid. If no amount is set, the full amount is transferred. There cannot be any line items with recurring prices when using this field.
            [<Config.Form>]
            Amount: int option
            /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination. There must be at least 1 line item with a recurring price to use this field.
            [<Config.Form>]
            AmountPercent: decimal option
            /// ID of an existing, connected Stripe account.
            [<Config.Form>]
            Destination: string option
        }

    module Update'TransferDataTransferDataSpecs =
        let create
            (
                amount: int option,
                amountPercent: decimal option,
                destination: string option
            ) : Update'TransferDataTransferDataSpecs
            =
            {
              Amount = amount
              AmountPercent = amountPercent
              Destination = destination
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Quote: string
            /// The amount of the application fee (if any) that will be requested to be applied to the payment and transferred to the application owner's Stripe account. There cannot be any line items with recurring prices when using this field.
            [<Config.Form>]
            ApplicationFeeAmount: Choice<int,string> option
            /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. There must be at least 1 line item with a recurring price to use this field.
            [<Config.Form>]
            ApplicationFeePercent: Choice<decimal,string> option
            /// Settings for automatic tax lookup for this quote and resulting invoices and subscriptions.
            [<Config.Form>]
            AutomaticTax: Update'AutomaticTax option
            /// Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay invoices at the end of the subscription cycle or at invoice finalization using the default payment method attached to the subscription or customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically`.
            [<Config.Form>]
            CollectionMethod: Update'CollectionMethod option
            /// The customer for which this quote belongs to. A customer is required before finalizing the quote. Once specified, it cannot be changed.
            [<Config.Form>]
            Customer: string option
            /// The account for which this quote belongs to. A customer or account is required before finalizing the quote. Once specified, it cannot be changed.
            [<Config.Form>]
            CustomerAccount: string option
            /// The tax rates that will apply to any line item that does not have `tax_rates` set.
            [<Config.Form>]
            DefaultTaxRates: Choice<string list,string> option
            /// A description that will be displayed on the quote PDF.
            [<Config.Form>]
            Description: Choice<string,string> option
            /// The discounts applied to the quote.
            [<Config.Form>]
            Discounts: Choice<Update'Discounts list,string> option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// A future timestamp on which the quote will be canceled if in `open` or `draft` status. Measured in seconds since the Unix epoch.
            [<Config.Form>]
            ExpiresAt: DateTime option
            /// A footer that will be displayed on the quote PDF.
            [<Config.Form>]
            Footer: Choice<string,string> option
            /// A header that will be displayed on the quote PDF.
            [<Config.Form>]
            Header: Choice<string,string> option
            /// All invoices will be billed using the specified settings.
            [<Config.Form>]
            InvoiceSettings: Update'InvoiceSettings option
            /// A list of line items the customer is being quoted for. Each line item includes information about the product, the quantity, and the resulting cost.
            [<Config.Form>]
            LineItems: Update'LineItems list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The account on behalf of which to charge.
            [<Config.Form>]
            OnBehalfOf: Choice<string,string> option
            /// When creating a subscription or subscription schedule, the specified configuration data will be used. There must be at least one line item with a recurring price for a subscription or subscription schedule to be created. A subscription schedule is created if `subscription_data[effective_date]` is present and in the future, otherwise a subscription is created.
            [<Config.Form>]
            SubscriptionData: Update'SubscriptionData option
            /// The data with which to automatically create a Transfer for each of the invoices.
            [<Config.Form>]
            TransferData: Choice<Update'TransferDataTransferDataSpecs,string> option
        }

    module UpdateOptions =
        let create
            (
                quote: string
            ) : UpdateOptions
            =
            {
              Quote = quote
              ApplicationFeeAmount = None
              ApplicationFeePercent = None
              AutomaticTax = None
              CollectionMethod = None
              Customer = None
              CustomerAccount = None
              DefaultTaxRates = None
              Description = None
              Discounts = None
              Expand = None
              ExpiresAt = None
              Footer = None
              Header = None
              InvoiceSettings = None
              LineItems = None
              Metadata = None
              OnBehalfOf = None
              SubscriptionData = None
              TransferData = None
            }

    ///<p>Returns a list of your quotes.</p>
    let List settings (options: ListOptions) =
        let qs = [("customer", options.Customer |> box); ("customer_account", options.CustomerAccount |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("test_clock", options.TestClock |> box)] |> Map.ofList
        $"/v1/quotes"
        |> RestApi.getAsync<StripeList<Quote>> settings qs

    ///<p>A quote models prices and services for a customer. Default options for <code>header</code>, <code>description</code>, <code>footer</code>, and <code>expires_at</code> can be set in the dashboard via the <a href="https://dashboard.stripe.com/settings/billing/quote">quote template</a>.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/quotes"
        |> RestApi.postAsync<_, Quote> settings (Map.empty) options

    ///<p>Retrieves the quote with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/quotes/{options.Quote}"
        |> RestApi.getAsync<Quote> settings qs

    ///<p>A quote models prices and services for a customer.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/quotes/{options.Quote}"
        |> RestApi.postAsync<_, Quote> settings (Map.empty) options

module QuotesAccept =

    type AcceptOptions =
        {
            [<Config.Path>]
            Quote: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module AcceptOptions =
        let create
            (
                quote: string
            ) : AcceptOptions
            =
            {
              Quote = quote
              Expand = None
            }

    ///<p>Accepts the specified quote.</p>
    let Accept settings (options: AcceptOptions) =
        $"/v1/quotes/{options.Quote}/accept"
        |> RestApi.postAsync<_, Quote> settings (Map.empty) options

module QuotesCancel =

    type CancelOptions =
        {
            [<Config.Path>]
            Quote: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module CancelOptions =
        let create
            (
                quote: string
            ) : CancelOptions
            =
            {
              Quote = quote
              Expand = None
            }

    ///<p>Cancels the quote.</p>
    let Cancel settings (options: CancelOptions) =
        $"/v1/quotes/{options.Quote}/cancel"
        |> RestApi.postAsync<_, Quote> settings (Map.empty) options

module QuotesComputedUpfrontLineItems =

    type ListComputedUpfrontLineItemsOptions =
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
            Quote: string
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    module ListComputedUpfrontLineItemsOptions =
        let create
            (
                quote: string
            ) : ListComputedUpfrontLineItemsOptions
            =
            {
              Quote = quote
              EndingBefore = None
              Expand = None
              Limit = None
              StartingAfter = None
            }

    ///<p>When retrieving a quote, there is an includable <a href="https://stripe.com/docs/api/quotes/object#quote_object-computed-upfront-line_items"><strong>computed.upfront.line_items</strong></a> property containing the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of upfront line items.</p>
    let ListComputedUpfrontLineItems settings (options: ListComputedUpfrontLineItemsOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/quotes/{options.Quote}/computed_upfront_line_items"
        |> RestApi.getAsync<StripeList<Item>> settings qs

module QuotesFinalize =

    type FinalizeQuoteOptions =
        {
            [<Config.Path>]
            Quote: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// A future timestamp on which the quote will be canceled if in `open` or `draft` status. Measured in seconds since the Unix epoch.
            [<Config.Form>]
            ExpiresAt: DateTime option
        }

    module FinalizeQuoteOptions =
        let create
            (
                quote: string
            ) : FinalizeQuoteOptions
            =
            {
              Quote = quote
              Expand = None
              ExpiresAt = None
            }

    ///<p>Finalizes the quote.</p>
    let FinalizeQuote settings (options: FinalizeQuoteOptions) =
        $"/v1/quotes/{options.Quote}/finalize"
        |> RestApi.postAsync<_, Quote> settings (Map.empty) options

module QuotesLineItems =

    type ListLineItemsOptions =
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
            Quote: string
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    module ListLineItemsOptions =
        let create
            (
                quote: string
            ) : ListLineItemsOptions
            =
            {
              Quote = quote
              EndingBefore = None
              Expand = None
              Limit = None
              StartingAfter = None
            }

    ///<p>When retrieving a quote, there is an includable <strong>line_items</strong> property containing the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p>
    let ListLineItems settings (options: ListLineItemsOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/quotes/{options.Quote}/line_items"
        |> RestApi.getAsync<StripeList<Item>> settings qs

module QuotesPdf =

    type PdfOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Quote: string
        }

    module PdfOptions =
        let create
            (
                quote: string
            ) : PdfOptions
            =
            {
              Quote = quote
              Expand = None
            }

    ///<p>Download the PDF for a finalized quote. Explanation for special handling can be found <a href="https://docs.stripe.com/quotes/overview#quote_pdf">here</a></p>
    let Pdf settings (options: PdfOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/quotes/{options.Quote}/pdf"
        |> RestApi.getAsync<string> settings qs

