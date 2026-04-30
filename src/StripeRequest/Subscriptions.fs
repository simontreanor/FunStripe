namespace StripeRequest.Subscriptions

open FunStripe
open System.Text.Json.Serialization
open Stripe.Discount
open Stripe.PaymentMethod
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module Subscriptions =

    type ListOptions =
        {
            /// Filter subscriptions by their automatic tax settings.
            [<Config.Query>]
            AutomaticTax: Map<string, string> option
            /// The collection method of the subscriptions to retrieve. Either `charge_automatically` or `send_invoice`.
            [<Config.Query>]
            CollectionMethod: string option
            /// Only return subscriptions that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            /// Only return subscriptions whose minimum item current_period_end falls within the given date interval.
            [<Config.Query>]
            CurrentPeriodEnd: int option
            /// Only return subscriptions whose maximum item current_period_start falls within the given date interval.
            [<Config.Query>]
            CurrentPeriodStart: int option
            /// The ID of the customer whose subscriptions you're retrieving.
            [<Config.Query>]
            Customer: string option
            /// The ID of the account representing the customer whose subscriptions you're retrieving.
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
            /// The ID of the plan whose subscriptions will be retrieved.
            [<Config.Query>]
            Plan: string option
            /// Filter for subscriptions that contain this recurring price ID.
            [<Config.Query>]
            Price: string option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// The status of the subscriptions to retrieve. Passing in a value of `canceled` will return all canceled subscriptions, including those belonging to deleted customers. Pass `ended` to find subscriptions that are canceled and subscriptions that are expired due to [incomplete payment](https://docs.stripe.com/billing/subscriptions/overview#subscription-statuses). Passing in a value of `all` will return subscriptions of all statuses. If no value is supplied, all subscriptions that have not been canceled are returned.
            [<Config.Query>]
            Status: string option
            /// Filter for subscriptions that are associated with the specified test clock. The response will not include subscriptions with test clocks if this and the customer parameter is not set.
            [<Config.Query>]
            TestClock: string option
        }

    module ListOptions =
        let create
            (
                automaticTax: Map<string, string> option,
                collectionMethod: string option,
                created: int option,
                currentPeriodEnd: int option,
                currentPeriodStart: int option,
                customer: string option,
                customerAccount: string option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                plan: string option,
                price: string option,
                startingAfter: string option,
                status: string option,
                testClock: string option
            ) : ListOptions
            =
            {
              AutomaticTax = automaticTax
              CollectionMethod = collectionMethod
              Created = created
              CurrentPeriodEnd = currentPeriodEnd
              CurrentPeriodStart = currentPeriodStart
              Customer = customer
              CustomerAccount = customerAccount
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              Plan = plan
              Price = price
              StartingAfter = startingAfter
              Status = status
              TestClock = testClock
            }

    type Create'AddInvoiceItemsDiscounts =
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

    module Create'AddInvoiceItemsDiscounts =
        let create
            (
                coupon: string option,
                discount: string option,
                promotionCode: string option
            ) : Create'AddInvoiceItemsDiscounts
            =
            {
              Coupon = coupon
              Discount = discount
              PromotionCode = promotionCode
            }

    type Create'AddInvoiceItemsPeriodEndType =
        | MinItemPeriodEnd
        | Timestamp

    type Create'AddInvoiceItemsPeriodEnd =
        {
            /// A precise Unix timestamp for the end of the invoice item period. Must be greater than or equal to `period.start`.
            [<Config.Form>]
            Timestamp: DateTime option
            /// Select how to calculate the end of the invoice item period.
            [<Config.Form>]
            Type: Create'AddInvoiceItemsPeriodEndType option
        }

    module Create'AddInvoiceItemsPeriodEnd =
        let create
            (
                timestamp: DateTime option,
                ``type``: Create'AddInvoiceItemsPeriodEndType option
            ) : Create'AddInvoiceItemsPeriodEnd
            =
            {
              Timestamp = timestamp
              Type = ``type``
            }

    type Create'AddInvoiceItemsPeriodStartType =
        | MaxItemPeriodStart
        | Now
        | Timestamp

    type Create'AddInvoiceItemsPeriodStart =
        {
            /// A precise Unix timestamp for the start of the invoice item period. Must be less than or equal to `period.end`.
            [<Config.Form>]
            Timestamp: DateTime option
            /// Select how to calculate the start of the invoice item period.
            [<Config.Form>]
            Type: Create'AddInvoiceItemsPeriodStartType option
        }

    module Create'AddInvoiceItemsPeriodStart =
        let create
            (
                timestamp: DateTime option,
                ``type``: Create'AddInvoiceItemsPeriodStartType option
            ) : Create'AddInvoiceItemsPeriodStart
            =
            {
              Timestamp = timestamp
              Type = ``type``
            }

    type Create'AddInvoiceItemsPeriod =
        {
            /// End of the invoice item period.
            [<Config.Form>]
            End: Create'AddInvoiceItemsPeriodEnd option
            /// Start of the invoice item period.
            [<Config.Form>]
            Start: Create'AddInvoiceItemsPeriodStart option
        }

    module Create'AddInvoiceItemsPeriod =
        let create
            (
                ``end``: Create'AddInvoiceItemsPeriodEnd option,
                start: Create'AddInvoiceItemsPeriodStart option
            ) : Create'AddInvoiceItemsPeriod
            =
            {
              End = ``end``
              Start = start
            }

    type Create'AddInvoiceItemsPriceDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type Create'AddInvoiceItemsPriceData =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.
            [<Config.Form>]
            Product: string option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: Create'AddInvoiceItemsPriceDataTaxBehavior option
            /// A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge or a negative integer representing the amount to credit to the customer.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    module Create'AddInvoiceItemsPriceData =
        let create
            (
                currency: IsoTypes.IsoCurrencyCode option,
                product: string option,
                taxBehavior: Create'AddInvoiceItemsPriceDataTaxBehavior option,
                unitAmount: int option,
                unitAmountDecimal: string option
            ) : Create'AddInvoiceItemsPriceData
            =
            {
              Currency = currency
              Product = product
              TaxBehavior = taxBehavior
              UnitAmount = unitAmount
              UnitAmountDecimal = unitAmountDecimal
            }

    type Create'AddInvoiceItems =
        {
            /// The coupons to redeem into discounts for the item.
            [<Config.Form>]
            Discounts: Create'AddInvoiceItemsDiscounts list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The period associated with this invoice item. If not set, `period.start.type` defaults to `max_item_period_start` and `period.end.type` defaults to `min_item_period_end`.
            [<Config.Form>]
            Period: Create'AddInvoiceItemsPeriod option
            /// The ID of the price object. One of `price` or `price_data` is required.
            [<Config.Form>]
            Price: string option
            /// Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.
            [<Config.Form>]
            PriceData: Create'AddInvoiceItemsPriceData option
            /// Quantity for this item. Defaults to 1.
            [<Config.Form>]
            Quantity: int option
            /// The tax rates which apply to the item. When set, the `default_tax_rates` do not apply to this item.
            [<Config.Form>]
            TaxRates: Choice<string list,string> option
        }

    module Create'AddInvoiceItems =
        let create
            (
                discounts: Create'AddInvoiceItemsDiscounts list option,
                metadata: Map<string, string> option,
                period: Create'AddInvoiceItemsPeriod option,
                price: string option,
                priceData: Create'AddInvoiceItemsPriceData option,
                quantity: int option,
                taxRates: Choice<string list,string> option
            ) : Create'AddInvoiceItems
            =
            {
              Discounts = discounts
              Metadata = metadata
              Period = period
              Price = price
              PriceData = priceData
              Quantity = quantity
              TaxRates = taxRates
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
            /// Enabled automatic tax calculation which will automatically compute tax rates on all invoices generated by the subscription.
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

    type Create'BillingCycleAnchorConfig =
        {
            /// The day of the month the anchor should be. Ranges from 1 to 31.
            [<Config.Form>]
            DayOfMonth: int option
            /// The hour of the day the anchor should be. Ranges from 0 to 23.
            [<Config.Form>]
            Hour: int option
            /// The minute of the hour the anchor should be. Ranges from 0 to 59.
            [<Config.Form>]
            Minute: int option
            /// The month to start full cycle periods. Ranges from 1 to 12.
            [<Config.Form>]
            Month: int option
            /// The second of the minute the anchor should be. Ranges from 0 to 59.
            [<Config.Form>]
            Second: int option
        }

    module Create'BillingCycleAnchorConfig =
        let create
            (
                dayOfMonth: int option,
                hour: int option,
                minute: int option,
                month: int option,
                second: int option
            ) : Create'BillingCycleAnchorConfig
            =
            {
              DayOfMonth = dayOfMonth
              Hour = hour
              Minute = minute
              Month = month
              Second = second
            }

    type Create'BillingModeFlexibleProrationDiscounts =
        | Included
        | Itemized

    type Create'BillingModeFlexible =
        {
            /// Controls how invoices and invoice items display proration amounts and discount amounts.
            [<Config.Form>]
            ProrationDiscounts: Create'BillingModeFlexibleProrationDiscounts option
        }

    module Create'BillingModeFlexible =
        let create
            (
                prorationDiscounts: Create'BillingModeFlexibleProrationDiscounts option
            ) : Create'BillingModeFlexible
            =
            {
              ProrationDiscounts = prorationDiscounts
            }

    type Create'BillingModeType =
        | Classic
        | Flexible

    type Create'BillingMode =
        {
            /// Configure behavior for flexible billing mode.
            [<Config.Form>]
            Flexible: Create'BillingModeFlexible option
            /// Controls the calculation and orchestration of prorations and invoices for subscriptions. If no value is passed, the default is `flexible`.
            [<Config.Form>]
            Type: Create'BillingModeType option
        }

    module Create'BillingMode =
        let create
            (
                flexible: Create'BillingModeFlexible option,
                ``type``: Create'BillingModeType option
            ) : Create'BillingMode
            =
            {
              Flexible = flexible
              Type = ``type``
            }

    type Create'BillingThresholdsBillingThresholds =
        {
            /// Monetary threshold that triggers the subscription to advance to a new billing period
            [<Config.Form>]
            AmountGte: int option
            /// Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.
            [<Config.Form>]
            ResetBillingCycleAnchor: bool option
        }

    module Create'BillingThresholdsBillingThresholds =
        let create
            (
                amountGte: int option,
                resetBillingCycleAnchor: bool option
            ) : Create'BillingThresholdsBillingThresholds
            =
            {
              AmountGte = amountGte
              ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type Create'CancelAt =
        | MaxPeriodEnd
        | MinPeriodEnd

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
            /// The account tax IDs associated with the subscription. Will be set on invoices generated by the subscription.
            [<Config.Form>]
            AccountTaxIds: Choice<string list,string> option
            /// The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.
            [<Config.Form>]
            Issuer: Create'InvoiceSettingsIssuer option
        }

    module Create'InvoiceSettings =
        let create
            (
                accountTaxIds: Choice<string list,string> option,
                issuer: Create'InvoiceSettingsIssuer option
            ) : Create'InvoiceSettings
            =
            {
              AccountTaxIds = accountTaxIds
              Issuer = issuer
            }

    type Create'ItemsBillingThresholdsItemBillingThresholds =
        {
            /// Number of units that meets the billing threshold to advance the subscription to a new billing period (e.g., it takes 10 $5 units to meet a $50 [monetary threshold](https://docs.stripe.com/api/subscriptions/update#update_subscription-billing_thresholds-amount_gte))
            [<Config.Form>]
            UsageGte: int option
        }

    module Create'ItemsBillingThresholdsItemBillingThresholds =
        let create
            (
                usageGte: int option
            ) : Create'ItemsBillingThresholdsItemBillingThresholds
            =
            {
              UsageGte = usageGte
            }

    type Create'ItemsDiscounts =
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

    module Create'ItemsDiscounts =
        let create
            (
                coupon: string option,
                discount: string option,
                promotionCode: string option
            ) : Create'ItemsDiscounts
            =
            {
              Coupon = coupon
              Discount = discount
              PromotionCode = promotionCode
            }

    type Create'ItemsPriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    type Create'ItemsPriceDataRecurring =
        {
            /// Specifies billing frequency. Either `day`, `week`, `month` or `year`.
            [<Config.Form>]
            Interval: Create'ItemsPriceDataRecurringInterval option
            /// The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).
            [<Config.Form>]
            IntervalCount: int option
        }

    module Create'ItemsPriceDataRecurring =
        let create
            (
                interval: Create'ItemsPriceDataRecurringInterval option,
                intervalCount: int option
            ) : Create'ItemsPriceDataRecurring
            =
            {
              Interval = interval
              IntervalCount = intervalCount
            }

    type Create'ItemsPriceDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type Create'ItemsPriceData =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.
            [<Config.Form>]
            Product: string option
            /// The recurring components of a price such as `interval` and `interval_count`.
            [<Config.Form>]
            Recurring: Create'ItemsPriceDataRecurring option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: Create'ItemsPriceDataTaxBehavior option
            /// A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    module Create'ItemsPriceData =
        let create
            (
                currency: IsoTypes.IsoCurrencyCode option,
                product: string option,
                recurring: Create'ItemsPriceDataRecurring option,
                taxBehavior: Create'ItemsPriceDataTaxBehavior option,
                unitAmount: int option,
                unitAmountDecimal: string option
            ) : Create'ItemsPriceData
            =
            {
              Currency = currency
              Product = product
              Recurring = recurring
              TaxBehavior = taxBehavior
              UnitAmount = unitAmount
              UnitAmountDecimal = unitAmountDecimal
            }

    type Create'Items =
        {
            /// Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
            [<Config.Form>]
            BillingThresholds: Choice<Create'ItemsBillingThresholdsItemBillingThresholds,string> option
            /// The coupons to redeem into discounts for the subscription item.
            [<Config.Form>]
            Discounts: Choice<Create'ItemsDiscounts list,string> option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Plan ID for this item, as a string.
            [<Config.Form>]
            Plan: string option
            /// The ID of the price object.
            [<Config.Form>]
            Price: string option
            /// Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline.
            [<Config.Form>]
            PriceData: Create'ItemsPriceData option
            /// Quantity for this item.
            [<Config.Form>]
            Quantity: int option
            /// A list of [Tax Rate](https://docs.stripe.com/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://docs.stripe.com/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.
            [<Config.Form>]
            TaxRates: Choice<string list,string> option
        }

    module Create'Items =
        let create
            (
                billingThresholds: Choice<Create'ItemsBillingThresholdsItemBillingThresholds,string> option,
                discounts: Choice<Create'ItemsDiscounts list,string> option,
                metadata: Map<string, string> option,
                plan: string option,
                price: string option,
                priceData: Create'ItemsPriceData option,
                quantity: int option,
                taxRates: Choice<string list,string> option
            ) : Create'Items
            =
            {
              BillingThresholds = billingThresholds
              Discounts = discounts
              Metadata = metadata
              Plan = plan
              Price = price
              PriceData = priceData
              Quantity = quantity
              TaxRates = taxRates
            }

    type Create'PaymentBehavior =
        | AllowIncomplete
        | DefaultIncomplete
        | ErrorIfIncomplete
        | PendingIfIncomplete

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType =
        | Business
        | Personal

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions =
        {
            /// Transaction type of the mandate.
            [<Config.Form>]
            TransactionType:
                Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType option
        }

    module Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions =
        let create
            (
                transactionType: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType option
            ) : Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions
            =
            {
              TransactionType = transactionType
            }

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod =
        | Automatic
        | Instant
        | Microdeposits

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions =
        {
            /// Additional fields for Mandate creation
            [<Config.Form>]
            MandateOptions:
                Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions option
            /// Verification method for the intent
            [<Config.Form>]
            VerificationMethod:
                Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod option
        }

    module Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions =
        let create
            (
                mandateOptions: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions option,
                verificationMethod: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod option
            ) : Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions
            =
            {
              MandateOptions = mandateOptions
              VerificationMethod = verificationMethod
            }

    type Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage =
        | De
        | En
        | Fr
        | Nl

    type Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions =
        {
            /// Preferred language of the Bancontact authorization page that the customer is redirected to.
            [<Config.Form>]
            PreferredLanguage:
                Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage option
        }

    module Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions =
        let create
            (
                preferredLanguage: Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage option
            ) : Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions
            =
            {
              PreferredLanguage = preferredLanguage
            }

    type Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptionsAmountType =
        | Fixed
        | Maximum

    type Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptions =
        {
            /// Amount to be charged for future payments, specified in the presentment currency.
            [<Config.Form>]
            Amount: int option
            /// One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
            [<Config.Form>]
            AmountType:
                Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptionsAmountType option
            /// A description of the mandate or subscription that is meant to be displayed to the customer.
            [<Config.Form>]
            Description: string option
        }

    module Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptions =
        let create
            (
                amount: int option,
                amountType: Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptionsAmountType option,
                description: string option
            ) : Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptions
            =
            {
              Amount = amount
              AmountType = amountType
              Description = description
            }

    type Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsNetwork =
        | Amex
        | CartesBancaires
        | Diners
        | Discover
        | EftposAu
        | Girocard
        | Interac
        | Jcb
        | Link
        | Mastercard
        | Unionpay
        | Unknown
        | Visa

    type Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsRequestThreeDSecure =
        | Any
        | Automatic
        | Challenge

    type Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptions =
        {
            /// Configuration options for setting up an eMandate for cards issued in India.
            [<Config.Form>]
            MandateOptions:
                Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptions option
            /// Selected network to process this Subscription on. Depends on the available networks of the card attached to the Subscription. Can be only set confirm-time.
            [<Config.Form>]
            Network: Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsNetwork option
            /// We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://docs.stripe.com/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Read our guide on [manually requesting 3D Secure](https://docs.stripe.com/payments/3d-secure/authentication-flow#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
            [<Config.Form>]
            RequestThreeDSecure:
                Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsRequestThreeDSecure option
        }

    module Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptions =
        let create
            (
                mandateOptions: Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptions option,
                network: Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsNetwork option,
                requestThreeDSecure: Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsRequestThreeDSecure option
            ) : Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptions
            =
            {
              MandateOptions = mandateOptions
              Network = network
              RequestThreeDSecure = requestThreeDSecure
            }

    type Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer =
        {
            /// The desired country code of the bank account information. Permitted values include: `DE`, `FR`, `IE`, or `NL`.
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
        }

    module Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer =
        let create
            (
                country: IsoTypes.IsoCountryCode option
            ) : Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer
            =
            {
              Country = country
            }

    type Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer =
        {
            /// Configuration for eu_bank_transfer funding type.
            [<Config.Form>]
            EuBankTransfer:
                Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer option
            /// The bank transfer type that can be used for funding. Permitted values include: `eu_bank_transfer`, `gb_bank_transfer`, `jp_bank_transfer`, `mx_bank_transfer`, or `us_bank_transfer`.
            [<Config.Form>]
            Type: string option
        }

    module Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer =
        let create
            (
                euBankTransfer: Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer option,
                ``type``: string option
            ) : Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer
            =
            {
              EuBankTransfer = euBankTransfer
              Type = ``type``
            }

    type Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions =
        {
            /// Configuration for the bank transfer funding type, if the `funding_type` is set to `bank_transfer`.
            [<Config.Form>]
            BankTransfer:
                Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer option
            /// The funding method type to be used when there are not enough funds in the customer balance. Permitted values include: `bank_transfer`.
            [<Config.Form>]
            FundingType: string option
        }

    module Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions =
        let create
            (
                bankTransfer: Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer option,
                fundingType: string option
            ) : Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions
            =
            {
              BankTransfer = bankTransfer
              FundingType = fundingType
            }

    type Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptionsPurpose =
        | DependantSupport
        | Government
        | Loan
        | Mortgage
        | Other
        | Pension
        | Personal
        | Retail
        | Salary
        | Tax
        | Utility

    type Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions =
        {
            /// The maximum amount that can be collected in a single invoice. If you don't specify a maximum, then there is no limit.
            [<Config.Form>]
            Amount: int option
            /// The purpose for which payments are made. Has a default value based on your merchant category code.
            [<Config.Form>]
            Purpose: Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptionsPurpose option
        }

    module Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions =
        let create
            (
                amount: int option,
                purpose: Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptionsPurpose option
            ) : Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions
            =
            {
              Amount = amount
              Purpose = purpose
            }

    type Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions =
        {
            /// Additional fields for Mandate creation.
            [<Config.Form>]
            MandateOptions: Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions option
        }

    module Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions =
        let create
            (
                mandateOptions: Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions option
            ) : Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions
            =
            {
              MandateOptions = mandateOptions
            }

    type Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptionsAmountIncludesIof =
        | Always
        | Never

    type Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptionsPaymentSchedule =
        | Halfyearly
        | Monthly
        | Quarterly
        | Weekly
        | Yearly

    type Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptions =
        {
            /// Amount to be charged for future payments. If not provided, defaults to 40000.
            [<Config.Form>]
            Amount: int option
            /// Determines if the amount includes the IOF tax. Defaults to `never`.
            [<Config.Form>]
            AmountIncludesIof:
                Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptionsAmountIncludesIof option
            /// Date when the mandate expires and no further payments will be charged, in `YYYY-MM-DD`. If not provided, the mandate will be active until canceled.
            [<Config.Form>]
            EndDate: string option
            /// Schedule at which the future payments will be charged. Defaults to the subscription servicing interval.
            [<Config.Form>]
            PaymentSchedule:
                Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptionsPaymentSchedule option
        }

    module Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptions =
        let create
            (
                amount: int option,
                amountIncludesIof: Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptionsAmountIncludesIof option,
                endDate: string option,
                paymentSchedule: Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptionsPaymentSchedule option
            ) : Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptions
            =
            {
              Amount = amount
              AmountIncludesIof = amountIncludesIof
              EndDate = endDate
              PaymentSchedule = paymentSchedule
            }

    type Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptions =
        {
            /// The number of seconds (between 10 and 1209600) after which Pix payment will expire. Defaults to 86400 seconds.
            [<Config.Form>]
            ExpiresAfterSeconds: int option
            /// Configuration options for setting up a mandate
            [<Config.Form>]
            MandateOptions:
                Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptions option
        }

    module Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptions =
        let create
            (
                expiresAfterSeconds: int option,
                mandateOptions: Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptions option
            ) : Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptions
            =
            {
              ExpiresAfterSeconds = expiresAfterSeconds
              MandateOptions = mandateOptions
            }

    type Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptionsAmountType =
        | Fixed
        | Maximum

    type Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions =
        {
            /// Amount to be charged for future payments.
            [<Config.Form>]
            Amount: int option
            /// One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
            [<Config.Form>]
            AmountType:
                Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptionsAmountType option
            /// A description of the mandate or subscription that is meant to be displayed to the customer.
            [<Config.Form>]
            Description: string option
            /// End date of the mandate or subscription.
            [<Config.Form>]
            EndDate: DateTime option
        }

    module Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions =
        let create
            (
                amount: int option,
                amountType: Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptionsAmountType option,
                description: string option,
                endDate: DateTime option
            ) : Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions
            =
            {
              Amount = amount
              AmountType = amountType
              Description = description
              EndDate = endDate
            }

    type Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions =
        {
            /// Configuration options for setting up an eMandate
            [<Config.Form>]
            MandateOptions: Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions option
        }

    module Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions =
        let create
            (
                mandateOptions: Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions option
            ) : Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions
            =
            {
              MandateOptions = mandateOptions
            }

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFiltersAccountSubcategories
        =
        | Checking
        | Savings

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters =
        {
            /// The account subcategories to use to filter for selectable accounts. Valid subcategories are `checking` and `savings`.
            [<Config.Form>]
            AccountSubcategories:
                Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFiltersAccountSubcategories list option
        }

    module Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters =
        let create
            (
                accountSubcategories: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFiltersAccountSubcategories list option
            ) : Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters
            =
            {
              AccountSubcategories = accountSubcategories
            }

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions =
        | Balances
        | Ownership
        | PaymentMethod
        | Transactions

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch =
        | Balances
        | Ownership
        | Transactions

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections =
        {
            /// Provide filters for the linked accounts that the customer can select for the payment method.
            [<Config.Form>]
            Filters:
                Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters option
            /// The list of permissions to request. If this parameter is passed, the `payment_method` permission must be included. Valid permissions include: `balances`, `ownership`, `payment_method`, and `transactions`.
            [<Config.Form>]
            Permissions:
                Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions list option
            /// List of data features that you would like to retrieve upon account creation.
            [<Config.Form>]
            Prefetch:
                Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch list option
        }

    module Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections =
        let create
            (
                filters: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters option,
                permissions: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions list option,
                prefetch: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch list option
            ) : Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections
            =
            {
              Filters = filters
              Permissions = permissions
              Prefetch = prefetch
            }

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod =
        | Automatic
        | Instant
        | Microdeposits

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions =
        {
            /// Additional fields for Financial Connections Session creation
            [<Config.Form>]
            FinancialConnections:
                Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections option
            /// Verification method for the intent
            [<Config.Form>]
            VerificationMethod:
                Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod option
        }

    module Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions =
        let create
            (
                financialConnections: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections option,
                verificationMethod: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod option
            ) : Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions
            =
            {
              FinancialConnections = financialConnections
              VerificationMethod = verificationMethod
            }

    type Create'PaymentSettingsPaymentMethodOptions =
        {
            /// This sub-hash contains details about the Canadian pre-authorized debit payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            AcssDebit: Choice<Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions,string> option
            /// This sub-hash contains details about the Bancontact payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            Bancontact:
                Choice<Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions,string> option
            /// This sub-hash contains details about the Card payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            Card: Choice<Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptions,string> option
            /// This sub-hash contains details about the Bank transfer payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            CustomerBalance:
                Choice<Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions,string> option
            /// This sub-hash contains details about the Konbini payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            Konbini: Choice<string,string> option
            /// This sub-hash contains details about the PayTo payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            Payto: Choice<Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions,string> option
            /// This sub-hash contains details about the Pix payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            Pix: Choice<Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptions,string> option
            /// This sub-hash contains details about the SEPA Direct Debit payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            SepaDebit: Choice<string,string> option
            /// This sub-hash contains details about the UPI payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            Upi: Choice<Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions,string> option
            /// This sub-hash contains details about the ACH direct debit payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            UsBankAccount:
                Choice<Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions,string> option
        }

    module Create'PaymentSettingsPaymentMethodOptions =
        let create
            (
                acssDebit: Choice<Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions,string> option,
                bancontact: Choice<Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions,string> option,
                card: Choice<Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptions,string> option,
                customerBalance: Choice<Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions,string> option,
                konbini: Choice<string,string> option,
                payto: Choice<Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions,string> option,
                pix: Choice<Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptions,string> option,
                sepaDebit: Choice<string,string> option,
                upi: Choice<Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions,string> option,
                usBankAccount: Choice<Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions,string> option
            ) : Create'PaymentSettingsPaymentMethodOptions
            =
            {
              AcssDebit = acssDebit
              Bancontact = bancontact
              Card = card
              CustomerBalance = customerBalance
              Konbini = konbini
              Payto = payto
              Pix = pix
              SepaDebit = sepaDebit
              Upi = upi
              UsBankAccount = usBankAccount
            }

    type Create'PaymentSettingsPaymentMethodTypes =
        | AchCreditTransfer
        | AchDebit
        | AcssDebit
        | Affirm
        | AmazonPay
        | AuBecsDebit
        | BacsDebit
        | Bancontact
        | Boleto
        | Card
        | Cashapp
        | Crypto
        | Custom
        | CustomerBalance
        | Eps
        | Fpx
        | Giropay
        | Grabpay
        | Ideal
        | JpCreditTransfer
        | KakaoPay
        | Klarna
        | Konbini
        | KrCard
        | Link
        | Multibanco
        | NaverPay
        | NzBankAccount
        | P24
        | PayByBank
        | Payco
        | Paynow
        | Paypal
        | Payto
        | Pix
        | Promptpay
        | RevolutPay
        | SepaCreditTransfer
        | SepaDebit
        | Sofort
        | Swish
        | Upi
        | UsBankAccount
        | WechatPay

    type Create'PaymentSettingsSaveDefaultPaymentMethod =
        | Off
        | OnSubscription

    type Create'PaymentSettings =
        {
            /// Payment-method-specific configuration to provide to invoices created by the subscription.
            [<Config.Form>]
            PaymentMethodOptions: Create'PaymentSettingsPaymentMethodOptions option
            /// The list of payment method types (e.g. card) to provide to the invoice’s PaymentIntent. If not set, Stripe attempts to automatically determine the types to use by looking at the invoice’s default payment method, the subscription’s default payment method, the customer’s default payment method, and your [invoice template settings](https://dashboard.stripe.com/settings/billing/invoice). Should not be specified with payment_method_configuration
            [<Config.Form>]
            PaymentMethodTypes: Choice<Create'PaymentSettingsPaymentMethodTypes list,string> option
            /// Configure whether Stripe updates `subscription.default_payment_method` when payment succeeds. Defaults to `off` if unspecified.
            [<Config.Form>]
            SaveDefaultPaymentMethod: Create'PaymentSettingsSaveDefaultPaymentMethod option
        }

    module Create'PaymentSettings =
        let create
            (
                paymentMethodOptions: Create'PaymentSettingsPaymentMethodOptions option,
                paymentMethodTypes: Choice<Create'PaymentSettingsPaymentMethodTypes list,string> option,
                saveDefaultPaymentMethod: Create'PaymentSettingsSaveDefaultPaymentMethod option
            ) : Create'PaymentSettings
            =
            {
              PaymentMethodOptions = paymentMethodOptions
              PaymentMethodTypes = paymentMethodTypes
              SaveDefaultPaymentMethod = saveDefaultPaymentMethod
            }

    type Create'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval =
        | Day
        | Month
        | Week
        | Year

    type Create'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParams =
        {
            /// Specifies invoicing frequency. Either `day`, `week`, `month` or `year`.
            [<Config.Form>]
            Interval: Create'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval option
            /// The number of intervals between invoices. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
            [<Config.Form>]
            IntervalCount: int option
        }

    module Create'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParams =
        let create
            (
                interval: Create'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval option,
                intervalCount: int option
            ) : Create'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParams
            =
            {
              Interval = interval
              IntervalCount = intervalCount
            }

    type Create'ProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | [<JsonPropertyName("none")>] None'

    type Create'TransferData =
        {
            /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination.
            [<Config.Form>]
            AmountPercent: decimal option
            /// ID of an existing, connected Stripe account.
            [<Config.Form>]
            Destination: string option
        }

    module Create'TransferData =
        let create
            (
                amountPercent: decimal option,
                destination: string option
            ) : Create'TransferData
            =
            {
              AmountPercent = amountPercent
              Destination = destination
            }

    type Create'TrialEnd = | Now

    type Create'TrialSettingsEndBehaviorMissingPaymentMethod =
        | Cancel
        | CreateInvoice
        | Pause

    type Create'TrialSettingsEndBehavior =
        {
            /// Indicates how the subscription should change when the trial ends if the user did not provide a payment method.
            [<Config.Form>]
            MissingPaymentMethod: Create'TrialSettingsEndBehaviorMissingPaymentMethod option
        }

    module Create'TrialSettingsEndBehavior =
        let create
            (
                missingPaymentMethod: Create'TrialSettingsEndBehaviorMissingPaymentMethod option
            ) : Create'TrialSettingsEndBehavior
            =
            {
              MissingPaymentMethod = missingPaymentMethod
            }

    type Create'TrialSettings =
        {
            /// Defines how the subscription should behave when the user's free trial ends.
            [<Config.Form>]
            EndBehavior: Create'TrialSettingsEndBehavior option
        }

    module Create'TrialSettings =
        let create
            (
                endBehavior: Create'TrialSettingsEndBehavior option
            ) : Create'TrialSettings
            =
            {
              EndBehavior = endBehavior
            }

    type CreateOptions =
        {
            /// A list of prices and quantities that will generate invoice items appended to the next invoice for this subscription. You may pass up to 20 items.
            [<Config.Form>]
            AddInvoiceItems: Create'AddInvoiceItems list option
            /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. The request must be made by a platform account on a connected account in order to set an application fee percentage. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).
            [<Config.Form>]
            ApplicationFeePercent: Choice<decimal,string> option
            /// Automatic tax settings for this subscription.
            [<Config.Form>]
            AutomaticTax: Create'AutomaticTax option
            /// A past timestamp to backdate the subscription's start date to. If set, the first invoice will contain line items for the timespan between the start date and the current time. Can be combined with trials and the billing cycle anchor.
            [<Config.Form>]
            BackdateStartDate: DateTime option
            /// A future timestamp in UTC format to anchor the subscription's [billing cycle](https://docs.stripe.com/subscriptions/billing-cycle). The anchor is the reference point that aligns future billing cycle dates. It sets the day of week for `week` intervals, the day of month for `month` and `year` intervals, and the month of year for `year` intervals.
            [<Config.Form>]
            BillingCycleAnchor: DateTime option
            /// Mutually exclusive with billing_cycle_anchor and only valid with monthly and yearly price intervals. When provided, the billing_cycle_anchor is set to the next occurrence of the day_of_month at the hour, minute, and second UTC.
            [<Config.Form>]
            BillingCycleAnchorConfig: Create'BillingCycleAnchorConfig option
            /// Controls how prorations and invoices for subscriptions are calculated and orchestrated.
            [<Config.Form>]
            BillingMode: Create'BillingMode option
            /// Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. When updating, pass an empty string to remove previously-defined thresholds.
            [<Config.Form>]
            BillingThresholds: Choice<Create'BillingThresholdsBillingThresholds,string> option
            /// A timestamp at which the subscription should cancel. If set to a date before the current period ends, this will cause a proration if prorations have been enabled using `proration_behavior`. If set during a future period, this will always cause a proration for that period.
            [<Config.Form>]
            CancelAt: Choice<DateTime,Create'CancelAt> option
            /// Indicate whether this subscription should cancel at the end of the current period (`current_period_end`). Defaults to `false`.
            [<Config.Form>]
            CancelAtPeriodEnd: bool option
            /// Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay this subscription at the end of the cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically`.
            [<Config.Form>]
            CollectionMethod: Create'CollectionMethod option
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The identifier of the customer to subscribe.
            [<Config.Form>]
            Customer: string option
            /// The identifier of the account representing the customer to subscribe.
            [<Config.Form>]
            CustomerAccount: string option
            /// Number of days a customer has to pay invoices generated by this subscription. Valid only for subscriptions where `collection_method` is set to `send_invoice`.
            [<Config.Form>]
            DaysUntilDue: int option
            /// ID of the default payment method for the subscription. It must belong to the customer associated with the subscription. This takes precedence over `default_source`. If neither are set, invoices will use the customer's [invoice_settings.default_payment_method](https://docs.stripe.com/api/customers/object#customer_object-invoice_settings-default_payment_method) or [default_source](https://docs.stripe.com/api/customers/object#customer_object-default_source).
            [<Config.Form>]
            DefaultPaymentMethod: string option
            /// ID of the default payment source for the subscription. It must belong to the customer associated with the subscription and be in a chargeable state. If `default_payment_method` is also set, `default_payment_method` will take precedence. If neither are set, invoices will use the customer's [invoice_settings.default_payment_method](https://docs.stripe.com/api/customers/object#customer_object-invoice_settings-default_payment_method) or [default_source](https://docs.stripe.com/api/customers/object#customer_object-default_source).
            [<Config.Form>]
            DefaultSource: string option
            /// The tax rates that will apply to any subscription item that does not have `tax_rates` set. Invoices created will have their `default_tax_rates` populated from the subscription.
            [<Config.Form>]
            DefaultTaxRates: Choice<string list,string> option
            /// The subscription's description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription for rendering in Stripe surfaces and certain local payment methods UIs.
            [<Config.Form>]
            Description: string option
            /// The coupons to redeem into discounts for the subscription. If not specified or empty, inherits the discount from the subscription's customer.
            [<Config.Form>]
            Discounts: Choice<Create'Discounts list,string> option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// All invoices will be billed using the specified settings.
            [<Config.Form>]
            InvoiceSettings: Create'InvoiceSettings option
            /// A list of up to 20 subscription items, each with an attached price.
            [<Config.Form>]
            Items: Create'Items list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Indicates if a customer is on or off-session while an invoice payment is attempted. Defaults to `false` (on-session).
            [<Config.Form>]
            OffSession: bool option
            /// The account on behalf of which to charge, for each of the subscription's invoices.
            [<Config.Form>]
            OnBehalfOf: Choice<string,string> option
            /// Only applies to subscriptions with `collection_method=charge_automatically`.
            /// Use `allow_incomplete` to create Subscriptions with `status=incomplete` if the first invoice can't be paid. Creating Subscriptions with this status allows you to manage scenarios where additional customer actions are needed to pay a subscription's invoice. For example, SCA regulation may require 3DS authentication to complete payment. See the [SCA Migration Guide](https://docs.stripe.com/billing/migration/strong-customer-authentication) for Billing to learn more. This is the default behavior.
            /// Use `default_incomplete` to create Subscriptions with `status=incomplete` when the first invoice requires payment, otherwise start as active. Subscriptions transition to `status=active` when successfully confirming the PaymentIntent on the first invoice. This allows simpler management of scenarios where additional customer actions are needed to pay a subscription’s invoice, such as failed payments, [SCA regulation](https://docs.stripe.com/billing/migration/strong-customer-authentication), or collecting a mandate for a bank debit payment method. If the PaymentIntent is not confirmed within 23 hours Subscriptions transition to `status=incomplete_expired`, which is a terminal state.
            /// Use `error_if_incomplete` if you want Stripe to return an HTTP 402 status code if a subscription's first invoice can't be paid. For example, if a payment method requires 3DS authentication due to SCA regulation and further customer action is needed, this parameter doesn't create a Subscription and returns an error instead. This was the default behavior for API versions prior to 2019-03-14. See the [changelog](https://docs.stripe.com/upgrades#2019-03-14) to learn more.
            /// `pending_if_incomplete` is only used with updates and cannot be passed when creating a Subscription.
            /// Subscriptions with `collection_method=send_invoice` are automatically activated regardless of the first Invoice status.
            [<Config.Form>]
            PaymentBehavior: Create'PaymentBehavior option
            /// Payment settings to pass to invoices created by the subscription.
            [<Config.Form>]
            PaymentSettings: Create'PaymentSettings option
            /// Specifies an interval for how often to bill for any pending invoice items. It is analogous to calling [Create an invoice](/api/invoices/create) for the given subscription at the specified interval.
            [<Config.Form>]
            PendingInvoiceItemInterval:
                Choice<Create'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParams,string> option
            /// Determines how to handle [prorations](https://docs.stripe.com/billing/subscriptions/prorations) resulting from the `billing_cycle_anchor`. If no value is passed, the default is `create_prorations`.
            [<Config.Form>]
            ProrationBehavior: Create'ProrationBehavior option
            /// If specified, the funds from the subscription's invoices will be transferred to the destination and the ID of the resulting transfers will be found on the resulting charges.
            [<Config.Form>]
            TransferData: Create'TransferData option
            /// Unix timestamp representing the end of the trial period the customer will get before being charged for the first time. If set, trial_end will override the default trial period of the plan the customer is being subscribed to. The special value `now` can be provided to end the customer's trial immediately. Can be at most two years from `billing_cycle_anchor`. See [Using trial periods on subscriptions](https://docs.stripe.com/billing/subscriptions/trials) to learn more.
            [<Config.Form>]
            TrialEnd: Choice<Create'TrialEnd,DateTime> option
            /// Indicates if a plan's `trial_period_days` should be applied to the subscription. Setting `trial_end` per subscription is preferred, and this defaults to `false`. Setting this flag to `true` together with `trial_end` is not allowed. See [Using trial periods on subscriptions](https://docs.stripe.com/billing/subscriptions/trials) to learn more.
            [<Config.Form>]
            TrialFromPlan: bool option
            /// Integer representing the number of trial period days before the customer is charged for the first time. This will always overwrite any trials that might apply via a subscribed plan. See [Using trial periods on subscriptions](https://docs.stripe.com/billing/subscriptions/trials) to learn more.
            [<Config.Form>]
            TrialPeriodDays: int option
            /// Settings related to subscription trials.
            [<Config.Form>]
            TrialSettings: Create'TrialSettings option
        }

    module CreateOptions =
        let create
            (
                addInvoiceItems: Create'AddInvoiceItems list option,
                applicationFeePercent: Choice<decimal,string> option,
                automaticTax: Create'AutomaticTax option,
                backdateStartDate: DateTime option,
                billingCycleAnchor: DateTime option,
                billingCycleAnchorConfig: Create'BillingCycleAnchorConfig option,
                billingMode: Create'BillingMode option,
                billingThresholds: Choice<Create'BillingThresholdsBillingThresholds,string> option,
                cancelAt: Choice<DateTime,Create'CancelAt> option,
                cancelAtPeriodEnd: bool option,
                collectionMethod: Create'CollectionMethod option,
                currency: IsoTypes.IsoCurrencyCode option,
                customer: string option,
                customerAccount: string option,
                daysUntilDue: int option,
                defaultPaymentMethod: string option,
                defaultSource: string option,
                defaultTaxRates: Choice<string list,string> option,
                description: string option,
                discounts: Choice<Create'Discounts list,string> option,
                expand: string list option,
                invoiceSettings: Create'InvoiceSettings option,
                items: Create'Items list option,
                metadata: Map<string, string> option,
                offSession: bool option,
                onBehalfOf: Choice<string,string> option,
                paymentBehavior: Create'PaymentBehavior option,
                paymentSettings: Create'PaymentSettings option,
                pendingInvoiceItemInterval: Choice<Create'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParams,string> option,
                prorationBehavior: Create'ProrationBehavior option,
                transferData: Create'TransferData option,
                trialEnd: Choice<Create'TrialEnd,DateTime> option,
                trialFromPlan: bool option,
                trialPeriodDays: int option,
                trialSettings: Create'TrialSettings option
            ) : CreateOptions
            =
            {
              AddInvoiceItems = addInvoiceItems
              ApplicationFeePercent = applicationFeePercent
              AutomaticTax = automaticTax
              BackdateStartDate = backdateStartDate
              BillingCycleAnchor = billingCycleAnchor
              BillingCycleAnchorConfig = billingCycleAnchorConfig
              BillingMode = billingMode
              BillingThresholds = billingThresholds
              CancelAt = cancelAt
              CancelAtPeriodEnd = cancelAtPeriodEnd
              CollectionMethod = collectionMethod
              Currency = currency
              Customer = customer
              CustomerAccount = customerAccount
              DaysUntilDue = daysUntilDue
              DefaultPaymentMethod = defaultPaymentMethod
              DefaultSource = defaultSource
              DefaultTaxRates = defaultTaxRates
              Description = description
              Discounts = discounts
              Expand = expand
              InvoiceSettings = invoiceSettings
              Items = items
              Metadata = metadata
              OffSession = offSession
              OnBehalfOf = onBehalfOf
              PaymentBehavior = paymentBehavior
              PaymentSettings = paymentSettings
              PendingInvoiceItemInterval = pendingInvoiceItemInterval
              ProrationBehavior = prorationBehavior
              TransferData = transferData
              TrialEnd = trialEnd
              TrialFromPlan = trialFromPlan
              TrialPeriodDays = trialPeriodDays
              TrialSettings = trialSettings
            }

    type Cancel'CancellationDetailsFeedback =
        | CustomerService
        | LowQuality
        | MissingFeatures
        | Other
        | SwitchedService
        | TooComplex
        | TooExpensive
        | Unused

    type Cancel'CancellationDetails =
        {
            /// Additional comments about why the user canceled the subscription, if the subscription was canceled explicitly by the user.
            [<Config.Form>]
            Comment: Choice<string,string> option
            /// The customer submitted reason for why they canceled, if the subscription was canceled explicitly by the user.
            [<Config.Form>]
            Feedback: Cancel'CancellationDetailsFeedback option
        }

    module Cancel'CancellationDetails =
        let create
            (
                comment: Choice<string,string> option,
                feedback: Cancel'CancellationDetailsFeedback option
            ) : Cancel'CancellationDetails
            =
            {
              Comment = comment
              Feedback = feedback
            }

    type CancelOptions =
        {
            [<Config.Path>]
            SubscriptionExposedId: string
            /// Details about why this subscription was cancelled
            [<Config.Form>]
            CancellationDetails: Cancel'CancellationDetails option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Will generate a final invoice that invoices for any un-invoiced metered usage and new/pending proration invoice items. Defaults to `false`.
            [<Config.Form>]
            InvoiceNow: bool option
            /// Will generate a proration invoice item that credits remaining unused time until the subscription period end. Defaults to `false`.
            [<Config.Form>]
            Prorate: bool option
        }

    module CancelOptions =
        let create
            (
                subscriptionExposedId: string
            ) : CancelOptions
            =
            {
              SubscriptionExposedId = subscriptionExposedId
              CancellationDetails = None
              Expand = None
              InvoiceNow = None
              Prorate = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            SubscriptionExposedId: string
        }

    module RetrieveOptions =
        let create
            (
                subscriptionExposedId: string
            ) : RetrieveOptions
            =
            {
              SubscriptionExposedId = subscriptionExposedId
              Expand = None
            }

    type Update'AddInvoiceItemsDiscounts =
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

    module Update'AddInvoiceItemsDiscounts =
        let create
            (
                coupon: string option,
                discount: string option,
                promotionCode: string option
            ) : Update'AddInvoiceItemsDiscounts
            =
            {
              Coupon = coupon
              Discount = discount
              PromotionCode = promotionCode
            }

    type Update'AddInvoiceItemsPeriodEndType =
        | MinItemPeriodEnd
        | Timestamp

    type Update'AddInvoiceItemsPeriodEnd =
        {
            /// A precise Unix timestamp for the end of the invoice item period. Must be greater than or equal to `period.start`.
            [<Config.Form>]
            Timestamp: DateTime option
            /// Select how to calculate the end of the invoice item period.
            [<Config.Form>]
            Type: Update'AddInvoiceItemsPeriodEndType option
        }

    module Update'AddInvoiceItemsPeriodEnd =
        let create
            (
                timestamp: DateTime option,
                ``type``: Update'AddInvoiceItemsPeriodEndType option
            ) : Update'AddInvoiceItemsPeriodEnd
            =
            {
              Timestamp = timestamp
              Type = ``type``
            }

    type Update'AddInvoiceItemsPeriodStartType =
        | MaxItemPeriodStart
        | Now
        | Timestamp

    type Update'AddInvoiceItemsPeriodStart =
        {
            /// A precise Unix timestamp for the start of the invoice item period. Must be less than or equal to `period.end`.
            [<Config.Form>]
            Timestamp: DateTime option
            /// Select how to calculate the start of the invoice item period.
            [<Config.Form>]
            Type: Update'AddInvoiceItemsPeriodStartType option
        }

    module Update'AddInvoiceItemsPeriodStart =
        let create
            (
                timestamp: DateTime option,
                ``type``: Update'AddInvoiceItemsPeriodStartType option
            ) : Update'AddInvoiceItemsPeriodStart
            =
            {
              Timestamp = timestamp
              Type = ``type``
            }

    type Update'AddInvoiceItemsPeriod =
        {
            /// End of the invoice item period.
            [<Config.Form>]
            End: Update'AddInvoiceItemsPeriodEnd option
            /// Start of the invoice item period.
            [<Config.Form>]
            Start: Update'AddInvoiceItemsPeriodStart option
        }

    module Update'AddInvoiceItemsPeriod =
        let create
            (
                ``end``: Update'AddInvoiceItemsPeriodEnd option,
                start: Update'AddInvoiceItemsPeriodStart option
            ) : Update'AddInvoiceItemsPeriod
            =
            {
              End = ``end``
              Start = start
            }

    type Update'AddInvoiceItemsPriceDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type Update'AddInvoiceItemsPriceData =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.
            [<Config.Form>]
            Product: string option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: Update'AddInvoiceItemsPriceDataTaxBehavior option
            /// A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge or a negative integer representing the amount to credit to the customer.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    module Update'AddInvoiceItemsPriceData =
        let create
            (
                currency: IsoTypes.IsoCurrencyCode option,
                product: string option,
                taxBehavior: Update'AddInvoiceItemsPriceDataTaxBehavior option,
                unitAmount: int option,
                unitAmountDecimal: string option
            ) : Update'AddInvoiceItemsPriceData
            =
            {
              Currency = currency
              Product = product
              TaxBehavior = taxBehavior
              UnitAmount = unitAmount
              UnitAmountDecimal = unitAmountDecimal
            }

    type Update'AddInvoiceItems =
        {
            /// The coupons to redeem into discounts for the item.
            [<Config.Form>]
            Discounts: Update'AddInvoiceItemsDiscounts list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The period associated with this invoice item. If not set, `period.start.type` defaults to `max_item_period_start` and `period.end.type` defaults to `min_item_period_end`.
            [<Config.Form>]
            Period: Update'AddInvoiceItemsPeriod option
            /// The ID of the price object. One of `price` or `price_data` is required.
            [<Config.Form>]
            Price: string option
            /// Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.
            [<Config.Form>]
            PriceData: Update'AddInvoiceItemsPriceData option
            /// Quantity for this item. Defaults to 1.
            [<Config.Form>]
            Quantity: int option
            /// The tax rates which apply to the item. When set, the `default_tax_rates` do not apply to this item.
            [<Config.Form>]
            TaxRates: Choice<string list,string> option
        }

    module Update'AddInvoiceItems =
        let create
            (
                discounts: Update'AddInvoiceItemsDiscounts list option,
                metadata: Map<string, string> option,
                period: Update'AddInvoiceItemsPeriod option,
                price: string option,
                priceData: Update'AddInvoiceItemsPriceData option,
                quantity: int option,
                taxRates: Choice<string list,string> option
            ) : Update'AddInvoiceItems
            =
            {
              Discounts = discounts
              Metadata = metadata
              Period = period
              Price = price
              PriceData = priceData
              Quantity = quantity
              TaxRates = taxRates
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
            /// Enabled automatic tax calculation which will automatically compute tax rates on all invoices generated by the subscription.
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

    type Update'BillingCycleAnchor =
        | Now
        | Unchanged

    type Update'BillingThresholdsBillingThresholds =
        {
            /// Monetary threshold that triggers the subscription to advance to a new billing period
            [<Config.Form>]
            AmountGte: int option
            /// Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.
            [<Config.Form>]
            ResetBillingCycleAnchor: bool option
        }

    module Update'BillingThresholdsBillingThresholds =
        let create
            (
                amountGte: int option,
                resetBillingCycleAnchor: bool option
            ) : Update'BillingThresholdsBillingThresholds
            =
            {
              AmountGte = amountGte
              ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type Update'CancelAt =
        | MaxPeriodEnd
        | MinPeriodEnd

    type Update'CancellationDetailsFeedback =
        | CustomerService
        | LowQuality
        | MissingFeatures
        | Other
        | SwitchedService
        | TooComplex
        | TooExpensive
        | Unused

    type Update'CancellationDetails =
        {
            /// Additional comments about why the user canceled the subscription, if the subscription was canceled explicitly by the user.
            [<Config.Form>]
            Comment: Choice<string,string> option
            /// The customer submitted reason for why they canceled, if the subscription was canceled explicitly by the user.
            [<Config.Form>]
            Feedback: Update'CancellationDetailsFeedback option
        }

    module Update'CancellationDetails =
        let create
            (
                comment: Choice<string,string> option,
                feedback: Update'CancellationDetailsFeedback option
            ) : Update'CancellationDetails
            =
            {
              Comment = comment
              Feedback = feedback
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
            /// The account tax IDs associated with the subscription. Will be set on invoices generated by the subscription.
            [<Config.Form>]
            AccountTaxIds: Choice<string list,string> option
            /// The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.
            [<Config.Form>]
            Issuer: Update'InvoiceSettingsIssuer option
        }

    module Update'InvoiceSettings =
        let create
            (
                accountTaxIds: Choice<string list,string> option,
                issuer: Update'InvoiceSettingsIssuer option
            ) : Update'InvoiceSettings
            =
            {
              AccountTaxIds = accountTaxIds
              Issuer = issuer
            }

    type Update'ItemsBillingThresholdsItemBillingThresholds =
        {
            /// Number of units that meets the billing threshold to advance the subscription to a new billing period (e.g., it takes 10 $5 units to meet a $50 [monetary threshold](https://docs.stripe.com/api/subscriptions/update#update_subscription-billing_thresholds-amount_gte))
            [<Config.Form>]
            UsageGte: int option
        }

    module Update'ItemsBillingThresholdsItemBillingThresholds =
        let create
            (
                usageGte: int option
            ) : Update'ItemsBillingThresholdsItemBillingThresholds
            =
            {
              UsageGte = usageGte
            }

    type Update'ItemsDiscounts =
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

    module Update'ItemsDiscounts =
        let create
            (
                coupon: string option,
                discount: string option,
                promotionCode: string option
            ) : Update'ItemsDiscounts
            =
            {
              Coupon = coupon
              Discount = discount
              PromotionCode = promotionCode
            }

    type Update'ItemsPriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    type Update'ItemsPriceDataRecurring =
        {
            /// Specifies billing frequency. Either `day`, `week`, `month` or `year`.
            [<Config.Form>]
            Interval: Update'ItemsPriceDataRecurringInterval option
            /// The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).
            [<Config.Form>]
            IntervalCount: int option
        }

    module Update'ItemsPriceDataRecurring =
        let create
            (
                interval: Update'ItemsPriceDataRecurringInterval option,
                intervalCount: int option
            ) : Update'ItemsPriceDataRecurring
            =
            {
              Interval = interval
              IntervalCount = intervalCount
            }

    type Update'ItemsPriceDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type Update'ItemsPriceData =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.
            [<Config.Form>]
            Product: string option
            /// The recurring components of a price such as `interval` and `interval_count`.
            [<Config.Form>]
            Recurring: Update'ItemsPriceDataRecurring option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: Update'ItemsPriceDataTaxBehavior option
            /// A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    module Update'ItemsPriceData =
        let create
            (
                currency: IsoTypes.IsoCurrencyCode option,
                product: string option,
                recurring: Update'ItemsPriceDataRecurring option,
                taxBehavior: Update'ItemsPriceDataTaxBehavior option,
                unitAmount: int option,
                unitAmountDecimal: string option
            ) : Update'ItemsPriceData
            =
            {
              Currency = currency
              Product = product
              Recurring = recurring
              TaxBehavior = taxBehavior
              UnitAmount = unitAmount
              UnitAmountDecimal = unitAmountDecimal
            }

    type Update'Items =
        {
            /// Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
            [<Config.Form>]
            BillingThresholds: Choice<Update'ItemsBillingThresholdsItemBillingThresholds,string> option
            /// Delete all usage for a given subscription item. You must pass this when deleting a usage records subscription item. `clear_usage` has no effect if the plan has a billing meter attached.
            [<Config.Form>]
            ClearUsage: bool option
            /// A flag that, if set to `true`, will delete the specified item.
            [<Config.Form>]
            Deleted: bool option
            /// The coupons to redeem into discounts for the subscription item.
            [<Config.Form>]
            Discounts: Choice<Update'ItemsDiscounts list,string> option
            /// Subscription item to update.
            [<Config.Form>]
            Id: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Plan ID for this item, as a string.
            [<Config.Form>]
            Plan: string option
            /// The ID of the price object. One of `price` or `price_data` is required. When changing a subscription item's price, `quantity` is set to 1 unless a `quantity` parameter is provided.
            [<Config.Form>]
            Price: string option
            /// Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.
            [<Config.Form>]
            PriceData: Update'ItemsPriceData option
            /// Quantity for this item.
            [<Config.Form>]
            Quantity: int option
            /// A list of [Tax Rate](https://docs.stripe.com/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://docs.stripe.com/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.
            [<Config.Form>]
            TaxRates: Choice<string list,string> option
        }

    module Update'Items =
        let create
            (
                billingThresholds: Choice<Update'ItemsBillingThresholdsItemBillingThresholds,string> option,
                clearUsage: bool option,
                deleted: bool option,
                discounts: Choice<Update'ItemsDiscounts list,string> option,
                id: string option,
                metadata: Map<string, string> option,
                plan: string option,
                price: string option,
                priceData: Update'ItemsPriceData option,
                quantity: int option,
                taxRates: Choice<string list,string> option
            ) : Update'Items
            =
            {
              BillingThresholds = billingThresholds
              ClearUsage = clearUsage
              Deleted = deleted
              Discounts = discounts
              Id = id
              Metadata = metadata
              Plan = plan
              Price = price
              PriceData = priceData
              Quantity = quantity
              TaxRates = taxRates
            }

    type Update'PauseCollectionPauseCollectionBehavior =
        | KeepAsDraft
        | MarkUncollectible
        | Void

    type Update'PauseCollectionPauseCollection =
        {
            /// The payment collection behavior for this subscription while paused.
            [<Config.Form>]
            Behavior: Update'PauseCollectionPauseCollectionBehavior option
            /// The time after which the subscription will resume collecting payments.
            [<Config.Form>]
            ResumesAt: DateTime option
        }

    module Update'PauseCollectionPauseCollection =
        let create
            (
                behavior: Update'PauseCollectionPauseCollectionBehavior option,
                resumesAt: DateTime option
            ) : Update'PauseCollectionPauseCollection
            =
            {
              Behavior = behavior
              ResumesAt = resumesAt
            }

    type Update'PaymentBehavior =
        | AllowIncomplete
        | DefaultIncomplete
        | ErrorIfIncomplete
        | PendingIfIncomplete

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType =
        | Business
        | Personal

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions =
        {
            /// Transaction type of the mandate.
            [<Config.Form>]
            TransactionType:
                Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType option
        }

    module Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions =
        let create
            (
                transactionType: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType option
            ) : Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions
            =
            {
              TransactionType = transactionType
            }

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod =
        | Automatic
        | Instant
        | Microdeposits

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions =
        {
            /// Additional fields for Mandate creation
            [<Config.Form>]
            MandateOptions:
                Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions option
            /// Verification method for the intent
            [<Config.Form>]
            VerificationMethod:
                Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod option
        }

    module Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions =
        let create
            (
                mandateOptions: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions option,
                verificationMethod: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod option
            ) : Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions
            =
            {
              MandateOptions = mandateOptions
              VerificationMethod = verificationMethod
            }

    type Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage =
        | De
        | En
        | Fr
        | Nl

    type Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions =
        {
            /// Preferred language of the Bancontact authorization page that the customer is redirected to.
            [<Config.Form>]
            PreferredLanguage:
                Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage option
        }

    module Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions =
        let create
            (
                preferredLanguage: Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage option
            ) : Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions
            =
            {
              PreferredLanguage = preferredLanguage
            }

    type Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptionsAmountType =
        | Fixed
        | Maximum

    type Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptions =
        {
            /// Amount to be charged for future payments, specified in the presentment currency.
            [<Config.Form>]
            Amount: int option
            /// One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
            [<Config.Form>]
            AmountType:
                Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptionsAmountType option
            /// A description of the mandate or subscription that is meant to be displayed to the customer.
            [<Config.Form>]
            Description: string option
        }

    module Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptions =
        let create
            (
                amount: int option,
                amountType: Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptionsAmountType option,
                description: string option
            ) : Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptions
            =
            {
              Amount = amount
              AmountType = amountType
              Description = description
            }

    type Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsNetwork =
        | Amex
        | CartesBancaires
        | Diners
        | Discover
        | EftposAu
        | Girocard
        | Interac
        | Jcb
        | Link
        | Mastercard
        | Unionpay
        | Unknown
        | Visa

    type Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsRequestThreeDSecure =
        | Any
        | Automatic
        | Challenge

    type Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptions =
        {
            /// Configuration options for setting up an eMandate for cards issued in India.
            [<Config.Form>]
            MandateOptions:
                Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptions option
            /// Selected network to process this Subscription on. Depends on the available networks of the card attached to the Subscription. Can be only set confirm-time.
            [<Config.Form>]
            Network: Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsNetwork option
            /// We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://docs.stripe.com/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Read our guide on [manually requesting 3D Secure](https://docs.stripe.com/payments/3d-secure/authentication-flow#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
            [<Config.Form>]
            RequestThreeDSecure:
                Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsRequestThreeDSecure option
        }

    module Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptions =
        let create
            (
                mandateOptions: Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptions option,
                network: Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsNetwork option,
                requestThreeDSecure: Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsRequestThreeDSecure option
            ) : Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptions
            =
            {
              MandateOptions = mandateOptions
              Network = network
              RequestThreeDSecure = requestThreeDSecure
            }

    type Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer =
        {
            /// The desired country code of the bank account information. Permitted values include: `DE`, `FR`, `IE`, or `NL`.
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
        }

    module Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer =
        let create
            (
                country: IsoTypes.IsoCountryCode option
            ) : Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer
            =
            {
              Country = country
            }

    type Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer =
        {
            /// Configuration for eu_bank_transfer funding type.
            [<Config.Form>]
            EuBankTransfer:
                Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer option
            /// The bank transfer type that can be used for funding. Permitted values include: `eu_bank_transfer`, `gb_bank_transfer`, `jp_bank_transfer`, `mx_bank_transfer`, or `us_bank_transfer`.
            [<Config.Form>]
            Type: string option
        }

    module Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer =
        let create
            (
                euBankTransfer: Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer option,
                ``type``: string option
            ) : Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer
            =
            {
              EuBankTransfer = euBankTransfer
              Type = ``type``
            }

    type Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions =
        {
            /// Configuration for the bank transfer funding type, if the `funding_type` is set to `bank_transfer`.
            [<Config.Form>]
            BankTransfer:
                Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer option
            /// The funding method type to be used when there are not enough funds in the customer balance. Permitted values include: `bank_transfer`.
            [<Config.Form>]
            FundingType: string option
        }

    module Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions =
        let create
            (
                bankTransfer: Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer option,
                fundingType: string option
            ) : Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions
            =
            {
              BankTransfer = bankTransfer
              FundingType = fundingType
            }

    type Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptionsPurpose =
        | DependantSupport
        | Government
        | Loan
        | Mortgage
        | Other
        | Pension
        | Personal
        | Retail
        | Salary
        | Tax
        | Utility

    type Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions =
        {
            /// The maximum amount that can be collected in a single invoice. If you don't specify a maximum, then there is no limit.
            [<Config.Form>]
            Amount: int option
            /// The purpose for which payments are made. Has a default value based on your merchant category code.
            [<Config.Form>]
            Purpose: Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptionsPurpose option
        }

    module Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions =
        let create
            (
                amount: int option,
                purpose: Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptionsPurpose option
            ) : Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions
            =
            {
              Amount = amount
              Purpose = purpose
            }

    type Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions =
        {
            /// Additional fields for Mandate creation.
            [<Config.Form>]
            MandateOptions: Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions option
        }

    module Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions =
        let create
            (
                mandateOptions: Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions option
            ) : Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions
            =
            {
              MandateOptions = mandateOptions
            }

    type Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptionsAmountIncludesIof =
        | Always
        | Never

    type Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptionsPaymentSchedule =
        | Halfyearly
        | Monthly
        | Quarterly
        | Weekly
        | Yearly

    type Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptions =
        {
            /// Amount to be charged for future payments. If not provided, defaults to 40000.
            [<Config.Form>]
            Amount: int option
            /// Determines if the amount includes the IOF tax. Defaults to `never`.
            [<Config.Form>]
            AmountIncludesIof:
                Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptionsAmountIncludesIof option
            /// Date when the mandate expires and no further payments will be charged, in `YYYY-MM-DD`. If not provided, the mandate will be active until canceled.
            [<Config.Form>]
            EndDate: string option
            /// Schedule at which the future payments will be charged. Defaults to the subscription servicing interval.
            [<Config.Form>]
            PaymentSchedule:
                Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptionsPaymentSchedule option
        }

    module Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptions =
        let create
            (
                amount: int option,
                amountIncludesIof: Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptionsAmountIncludesIof option,
                endDate: string option,
                paymentSchedule: Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptionsPaymentSchedule option
            ) : Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptions
            =
            {
              Amount = amount
              AmountIncludesIof = amountIncludesIof
              EndDate = endDate
              PaymentSchedule = paymentSchedule
            }

    type Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptions =
        {
            /// The number of seconds (between 10 and 1209600) after which Pix payment will expire. Defaults to 86400 seconds.
            [<Config.Form>]
            ExpiresAfterSeconds: int option
            /// Configuration options for setting up a mandate
            [<Config.Form>]
            MandateOptions:
                Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptions option
        }

    module Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptions =
        let create
            (
                expiresAfterSeconds: int option,
                mandateOptions: Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptions option
            ) : Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptions
            =
            {
              ExpiresAfterSeconds = expiresAfterSeconds
              MandateOptions = mandateOptions
            }

    type Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptionsAmountType =
        | Fixed
        | Maximum

    type Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions =
        {
            /// Amount to be charged for future payments.
            [<Config.Form>]
            Amount: int option
            /// One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
            [<Config.Form>]
            AmountType:
                Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptionsAmountType option
            /// A description of the mandate or subscription that is meant to be displayed to the customer.
            [<Config.Form>]
            Description: string option
            /// End date of the mandate or subscription.
            [<Config.Form>]
            EndDate: DateTime option
        }

    module Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions =
        let create
            (
                amount: int option,
                amountType: Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptionsAmountType option,
                description: string option,
                endDate: DateTime option
            ) : Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions
            =
            {
              Amount = amount
              AmountType = amountType
              Description = description
              EndDate = endDate
            }

    type Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions =
        {
            /// Configuration options for setting up an eMandate
            [<Config.Form>]
            MandateOptions: Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions option
        }

    module Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions =
        let create
            (
                mandateOptions: Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions option
            ) : Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions
            =
            {
              MandateOptions = mandateOptions
            }

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFiltersAccountSubcategories
        =
        | Checking
        | Savings

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters =
        {
            /// The account subcategories to use to filter for selectable accounts. Valid subcategories are `checking` and `savings`.
            [<Config.Form>]
            AccountSubcategories:
                Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFiltersAccountSubcategories list option
        }

    module Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters =
        let create
            (
                accountSubcategories: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFiltersAccountSubcategories list option
            ) : Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters
            =
            {
              AccountSubcategories = accountSubcategories
            }

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions =
        | Balances
        | Ownership
        | PaymentMethod
        | Transactions

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch =
        | Balances
        | Ownership
        | Transactions

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections =
        {
            /// Provide filters for the linked accounts that the customer can select for the payment method.
            [<Config.Form>]
            Filters:
                Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters option
            /// The list of permissions to request. If this parameter is passed, the `payment_method` permission must be included. Valid permissions include: `balances`, `ownership`, `payment_method`, and `transactions`.
            [<Config.Form>]
            Permissions:
                Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions list option
            /// List of data features that you would like to retrieve upon account creation.
            [<Config.Form>]
            Prefetch:
                Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch list option
        }

    module Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections =
        let create
            (
                filters: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters option,
                permissions: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions list option,
                prefetch: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch list option
            ) : Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections
            =
            {
              Filters = filters
              Permissions = permissions
              Prefetch = prefetch
            }

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod =
        | Automatic
        | Instant
        | Microdeposits

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions =
        {
            /// Additional fields for Financial Connections Session creation
            [<Config.Form>]
            FinancialConnections:
                Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections option
            /// Verification method for the intent
            [<Config.Form>]
            VerificationMethod:
                Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod option
        }

    module Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions =
        let create
            (
                financialConnections: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections option,
                verificationMethod: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod option
            ) : Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions
            =
            {
              FinancialConnections = financialConnections
              VerificationMethod = verificationMethod
            }

    type Update'PaymentSettingsPaymentMethodOptions =
        {
            /// This sub-hash contains details about the Canadian pre-authorized debit payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            AcssDebit: Choice<Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions,string> option
            /// This sub-hash contains details about the Bancontact payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            Bancontact:
                Choice<Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions,string> option
            /// This sub-hash contains details about the Card payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            Card: Choice<Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptions,string> option
            /// This sub-hash contains details about the Bank transfer payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            CustomerBalance:
                Choice<Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions,string> option
            /// This sub-hash contains details about the Konbini payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            Konbini: Choice<string,string> option
            /// This sub-hash contains details about the PayTo payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            Payto: Choice<Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions,string> option
            /// This sub-hash contains details about the Pix payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            Pix: Choice<Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptions,string> option
            /// This sub-hash contains details about the SEPA Direct Debit payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            SepaDebit: Choice<string,string> option
            /// This sub-hash contains details about the UPI payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            Upi: Choice<Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions,string> option
            /// This sub-hash contains details about the ACH direct debit payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            UsBankAccount:
                Choice<Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions,string> option
        }

    module Update'PaymentSettingsPaymentMethodOptions =
        let create
            (
                acssDebit: Choice<Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions,string> option,
                bancontact: Choice<Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions,string> option,
                card: Choice<Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptions,string> option,
                customerBalance: Choice<Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions,string> option,
                konbini: Choice<string,string> option,
                payto: Choice<Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions,string> option,
                pix: Choice<Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptions,string> option,
                sepaDebit: Choice<string,string> option,
                upi: Choice<Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions,string> option,
                usBankAccount: Choice<Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions,string> option
            ) : Update'PaymentSettingsPaymentMethodOptions
            =
            {
              AcssDebit = acssDebit
              Bancontact = bancontact
              Card = card
              CustomerBalance = customerBalance
              Konbini = konbini
              Payto = payto
              Pix = pix
              SepaDebit = sepaDebit
              Upi = upi
              UsBankAccount = usBankAccount
            }

    type Update'PaymentSettingsPaymentMethodTypes =
        | AchCreditTransfer
        | AchDebit
        | AcssDebit
        | Affirm
        | AmazonPay
        | AuBecsDebit
        | BacsDebit
        | Bancontact
        | Boleto
        | Card
        | Cashapp
        | Crypto
        | Custom
        | CustomerBalance
        | Eps
        | Fpx
        | Giropay
        | Grabpay
        | Ideal
        | JpCreditTransfer
        | KakaoPay
        | Klarna
        | Konbini
        | KrCard
        | Link
        | Multibanco
        | NaverPay
        | NzBankAccount
        | P24
        | PayByBank
        | Payco
        | Paynow
        | Paypal
        | Payto
        | Pix
        | Promptpay
        | RevolutPay
        | SepaCreditTransfer
        | SepaDebit
        | Sofort
        | Swish
        | Upi
        | UsBankAccount
        | WechatPay

    type Update'PaymentSettingsSaveDefaultPaymentMethod =
        | Off
        | OnSubscription

    type Update'PaymentSettings =
        {
            /// Payment-method-specific configuration to provide to invoices created by the subscription.
            [<Config.Form>]
            PaymentMethodOptions: Update'PaymentSettingsPaymentMethodOptions option
            /// The list of payment method types (e.g. card) to provide to the invoice’s PaymentIntent. If not set, Stripe attempts to automatically determine the types to use by looking at the invoice’s default payment method, the subscription’s default payment method, the customer’s default payment method, and your [invoice template settings](https://dashboard.stripe.com/settings/billing/invoice). Should not be specified with payment_method_configuration
            [<Config.Form>]
            PaymentMethodTypes: Choice<Update'PaymentSettingsPaymentMethodTypes list,string> option
            /// Configure whether Stripe updates `subscription.default_payment_method` when payment succeeds. Defaults to `off` if unspecified.
            [<Config.Form>]
            SaveDefaultPaymentMethod: Update'PaymentSettingsSaveDefaultPaymentMethod option
        }

    module Update'PaymentSettings =
        let create
            (
                paymentMethodOptions: Update'PaymentSettingsPaymentMethodOptions option,
                paymentMethodTypes: Choice<Update'PaymentSettingsPaymentMethodTypes list,string> option,
                saveDefaultPaymentMethod: Update'PaymentSettingsSaveDefaultPaymentMethod option
            ) : Update'PaymentSettings
            =
            {
              PaymentMethodOptions = paymentMethodOptions
              PaymentMethodTypes = paymentMethodTypes
              SaveDefaultPaymentMethod = saveDefaultPaymentMethod
            }

    type Update'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval =
        | Day
        | Month
        | Week
        | Year

    type Update'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParams =
        {
            /// Specifies invoicing frequency. Either `day`, `week`, `month` or `year`.
            [<Config.Form>]
            Interval: Update'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval option
            /// The number of intervals between invoices. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
            [<Config.Form>]
            IntervalCount: int option
        }

    module Update'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParams =
        let create
            (
                interval: Update'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval option,
                intervalCount: int option
            ) : Update'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParams
            =
            {
              Interval = interval
              IntervalCount = intervalCount
            }

    type Update'ProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | [<JsonPropertyName("none")>] None'

    type Update'TransferDataTransferDataSpecs =
        {
            /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination.
            [<Config.Form>]
            AmountPercent: decimal option
            /// ID of an existing, connected Stripe account.
            [<Config.Form>]
            Destination: string option
        }

    module Update'TransferDataTransferDataSpecs =
        let create
            (
                amountPercent: decimal option,
                destination: string option
            ) : Update'TransferDataTransferDataSpecs
            =
            {
              AmountPercent = amountPercent
              Destination = destination
            }

    type Update'TrialEnd = | Now

    type Update'TrialSettingsEndBehaviorMissingPaymentMethod =
        | Cancel
        | CreateInvoice
        | Pause

    type Update'TrialSettingsEndBehavior =
        {
            /// Indicates how the subscription should change when the trial ends if the user did not provide a payment method.
            [<Config.Form>]
            MissingPaymentMethod: Update'TrialSettingsEndBehaviorMissingPaymentMethod option
        }

    module Update'TrialSettingsEndBehavior =
        let create
            (
                missingPaymentMethod: Update'TrialSettingsEndBehaviorMissingPaymentMethod option
            ) : Update'TrialSettingsEndBehavior
            =
            {
              MissingPaymentMethod = missingPaymentMethod
            }

    type Update'TrialSettings =
        {
            /// Defines how the subscription should behave when the user's free trial ends.
            [<Config.Form>]
            EndBehavior: Update'TrialSettingsEndBehavior option
        }

    module Update'TrialSettings =
        let create
            (
                endBehavior: Update'TrialSettingsEndBehavior option
            ) : Update'TrialSettings
            =
            {
              EndBehavior = endBehavior
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            SubscriptionExposedId: string
            /// A list of prices and quantities that will generate invoice items appended to the next invoice for this subscription. You may pass up to 20 items.
            [<Config.Form>]
            AddInvoiceItems: Update'AddInvoiceItems list option
            /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. The request must be made by a platform account on a connected account in order to set an application fee percentage. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).
            [<Config.Form>]
            ApplicationFeePercent: Choice<decimal,string> option
            /// Automatic tax settings for this subscription. We recommend you only include this parameter when the existing value is being changed.
            [<Config.Form>]
            AutomaticTax: Update'AutomaticTax option
            /// Either `now` or `unchanged`. Setting the value to `now` resets the subscription's billing cycle anchor to the current time (in UTC). For more information, see the billing cycle [documentation](https://docs.stripe.com/billing/subscriptions/billing-cycle).
            [<Config.Form>]
            BillingCycleAnchor: Update'BillingCycleAnchor option
            /// Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. When updating, pass an empty string to remove previously-defined thresholds.
            [<Config.Form>]
            BillingThresholds: Choice<Update'BillingThresholdsBillingThresholds,string> option
            /// A timestamp at which the subscription should cancel. If set to a date before the current period ends, this will cause a proration if prorations have been enabled using `proration_behavior`. If set during a future period, this will always cause a proration for that period.
            [<Config.Form>]
            CancelAt: Choice<DateTime,string,Update'CancelAt> option
            /// Indicate whether this subscription should cancel at the end of the current period (`current_period_end`). Defaults to `false`.
            [<Config.Form>]
            CancelAtPeriodEnd: bool option
            /// Details about why this subscription was cancelled
            [<Config.Form>]
            CancellationDetails: Update'CancellationDetails option
            /// Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay this subscription at the end of the cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically`.
            [<Config.Form>]
            CollectionMethod: Update'CollectionMethod option
            /// Number of days a customer has to pay invoices generated by this subscription. Valid only for subscriptions where `collection_method` is set to `send_invoice`.
            [<Config.Form>]
            DaysUntilDue: int option
            /// ID of the default payment method for the subscription. It must belong to the customer associated with the subscription. This takes precedence over `default_source`. If neither are set, invoices will use the customer's [invoice_settings.default_payment_method](https://docs.stripe.com/api/customers/object#customer_object-invoice_settings-default_payment_method) or [default_source](https://docs.stripe.com/api/customers/object#customer_object-default_source).
            [<Config.Form>]
            DefaultPaymentMethod: string option
            /// ID of the default payment source for the subscription. It must belong to the customer associated with the subscription and be in a chargeable state. If `default_payment_method` is also set, `default_payment_method` will take precedence. If neither are set, invoices will use the customer's [invoice_settings.default_payment_method](https://docs.stripe.com/api/customers/object#customer_object-invoice_settings-default_payment_method) or [default_source](https://docs.stripe.com/api/customers/object#customer_object-default_source).
            [<Config.Form>]
            DefaultSource: Choice<string,string> option
            /// The tax rates that will apply to any subscription item that does not have `tax_rates` set. Invoices created will have their `default_tax_rates` populated from the subscription. Pass an empty string to remove previously-defined tax rates.
            [<Config.Form>]
            DefaultTaxRates: Choice<string list,string> option
            /// The subscription's description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription for rendering in Stripe surfaces and certain local payment methods UIs.
            [<Config.Form>]
            Description: Choice<string,string> option
            /// The coupons to redeem into discounts for the subscription. If not specified or empty, inherits the discount from the subscription's customer.
            [<Config.Form>]
            Discounts: Choice<Update'Discounts list,string> option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// All invoices will be billed using the specified settings.
            [<Config.Form>]
            InvoiceSettings: Update'InvoiceSettings option
            /// A list of up to 20 subscription items, each with an attached price.
            [<Config.Form>]
            Items: Update'Items list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Indicates if a customer is on or off-session while an invoice payment is attempted. Defaults to `false` (on-session).
            [<Config.Form>]
            OffSession: bool option
            /// The account on behalf of which to charge, for each of the subscription's invoices.
            [<Config.Form>]
            OnBehalfOf: Choice<string,string> option
            /// If specified, payment collection for this subscription will be paused. Note that the subscription status will be unchanged and will not be updated to `paused`. Learn more about [pausing collection](https://docs.stripe.com/billing/subscriptions/pause-payment).
            [<Config.Form>]
            PauseCollection: Choice<Update'PauseCollectionPauseCollection,string> option
            /// Use `allow_incomplete` to transition the subscription to `status=past_due` if a payment is required but cannot be paid. This allows you to manage scenarios where additional user actions are needed to pay a subscription's invoice. For example, SCA regulation may require 3DS authentication to complete payment. See the [SCA Migration Guide](https://docs.stripe.com/billing/migration/strong-customer-authentication) for Billing to learn more. This is the default behavior.
            /// Use `default_incomplete` to transition the subscription to `status=past_due` when payment is required and await explicit confirmation of the invoice's payment intent. This allows simpler management of scenarios where additional user actions are needed to pay a subscription’s invoice. Such as failed payments, [SCA regulation](https://docs.stripe.com/billing/migration/strong-customer-authentication), or collecting a mandate for a bank debit payment method.
            /// Use `pending_if_incomplete` to update the subscription using [pending updates](https://docs.stripe.com/billing/subscriptions/pending-updates). When you use `pending_if_incomplete` you can only pass the parameters [supported by pending updates](https://docs.stripe.com/billing/pending-updates-reference#supported-attributes).
            /// Use `error_if_incomplete` if you want Stripe to return an HTTP 402 status code if a subscription's invoice cannot be paid. For example, if a payment method requires 3DS authentication due to SCA regulation and further user action is needed, this parameter does not update the subscription and returns an error instead. This was the default behavior for API versions prior to 2019-03-14. See the [changelog](https://docs.stripe.com/changelog/2019-03-14) to learn more.
            [<Config.Form>]
            PaymentBehavior: Update'PaymentBehavior option
            /// Payment settings to pass to invoices created by the subscription.
            [<Config.Form>]
            PaymentSettings: Update'PaymentSettings option
            /// Specifies an interval for how often to bill for any pending invoice items. It is analogous to calling [Create an invoice](/api/invoices/create) for the given subscription at the specified interval.
            [<Config.Form>]
            PendingInvoiceItemInterval:
                Choice<Update'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParams,string> option
            /// Determines how to handle [prorations](https://docs.stripe.com/billing/subscriptions/prorations) when the billing cycle changes (e.g., when switching plans, resetting `billing_cycle_anchor=now`, or starting a trial), or if an item's `quantity` changes. The default value is `create_prorations`.
            [<Config.Form>]
            ProrationBehavior: Update'ProrationBehavior option
            /// If set, prorations will be calculated as though the subscription was updated at the given time. This can be used to apply exactly the same prorations that were previewed with the [create preview](https://stripe.com/docs/api/invoices/create_preview) endpoint. `proration_date` can also be used to implement custom proration logic, such as prorating by day instead of by second, by providing the time that you wish to use for proration calculations.
            [<Config.Form>]
            ProrationDate: DateTime option
            /// If specified, the funds from the subscription's invoices will be transferred to the destination and the ID of the resulting transfers will be found on the resulting charges. This will be unset if you POST an empty value.
            [<Config.Form>]
            TransferData: Choice<Update'TransferDataTransferDataSpecs,string> option
            /// Unix timestamp representing the end of the trial period the customer will get before being charged for the first time. This will always overwrite any trials that might apply via a subscribed plan. If set, `trial_end` will override the default trial period of the plan the customer is being subscribed to. The `billing_cycle_anchor` will be updated to the `trial_end` value. The special value `now` can be provided to end the customer's trial immediately. Can be at most two years from `billing_cycle_anchor`.
            [<Config.Form>]
            TrialEnd: Choice<Update'TrialEnd,DateTime> option
            /// Indicates if a plan's `trial_period_days` should be applied to the subscription. Setting `trial_end` per subscription is preferred, and this defaults to `false`. Setting this flag to `true` together with `trial_end` is not allowed. See [Using trial periods on subscriptions](https://docs.stripe.com/billing/subscriptions/trials) to learn more.
            [<Config.Form>]
            TrialFromPlan: bool option
            /// Settings related to subscription trials.
            [<Config.Form>]
            TrialSettings: Update'TrialSettings option
        }

    module UpdateOptions =
        let create
            (
                subscriptionExposedId: string
            ) : UpdateOptions
            =
            {
              SubscriptionExposedId = subscriptionExposedId
              AddInvoiceItems = None
              ApplicationFeePercent = None
              AutomaticTax = None
              BillingCycleAnchor = None
              BillingThresholds = None
              CancelAt = None
              CancelAtPeriodEnd = None
              CancellationDetails = None
              CollectionMethod = None
              DaysUntilDue = None
              DefaultPaymentMethod = None
              DefaultSource = None
              DefaultTaxRates = None
              Description = None
              Discounts = None
              Expand = None
              InvoiceSettings = None
              Items = None
              Metadata = None
              OffSession = None
              OnBehalfOf = None
              PauseCollection = None
              PaymentBehavior = None
              PaymentSettings = None
              PendingInvoiceItemInterval = None
              ProrationBehavior = None
              ProrationDate = None
              TransferData = None
              TrialEnd = None
              TrialFromPlan = None
              TrialSettings = None
            }

    ///<p>By default, returns a list of subscriptions that have not been canceled. In order to list canceled subscriptions, specify <code>status=canceled</code>.</p>
    let List settings (options: ListOptions) =
        let qs = [("automatic_tax", options.AutomaticTax |> box); ("collection_method", options.CollectionMethod |> box); ("created", options.Created |> box); ("current_period_end", options.CurrentPeriodEnd |> box); ("current_period_start", options.CurrentPeriodStart |> box); ("customer", options.Customer |> box); ("customer_account", options.CustomerAccount |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("plan", options.Plan |> box); ("price", options.Price |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("test_clock", options.TestClock |> box)] |> Map.ofList
        $"/v1/subscriptions"
        |> RestApi.getAsync<StripeList<Subscription>> settings qs

    ///<p>Creates a new subscription on an existing customer. Each customer can have up to 500 active or scheduled subscriptions.</p>
    ///<p>When you create a subscription with <code>collection_method=charge_automatically</code>, the first invoice is finalized as part of the request.
    ///The <code>payment_behavior</code> parameter determines the exact behavior of the initial payment.</p>
    ///<p>To start subscriptions where the first invoice always begins in a <code>draft</code> status, use <a href="/docs/billing/subscriptions/subscription-schedules#managing">subscription schedules</a> instead.
    ///Schedules provide the flexibility to model more complex billing configurations that change over time.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/subscriptions"
        |> RestApi.postAsync<_, Subscription> settings (Map.empty) options

    ///<p>Cancels a customer’s subscription immediately. The customer won’t be charged again for the subscription. After it’s canceled, you can no longer update the subscription or its <a href="/metadata">metadata</a>.</p>
    ///<p>Any pending invoice items that you’ve created are still charged at the end of the period, unless manually <a href="/api/invoiceitems/delete">deleted</a>. If you’ve set the subscription to cancel at the end of the period, any pending prorations are also left in place and collected at the end of the period. But if the subscription is set to cancel immediately, pending prorations are removed if <code>invoice_now</code> and <code>prorate</code> are both set to true.</p>
    ///<p>By default, upon subscription cancellation, Stripe stops automatic collection of all finalized invoices for the customer. This is intended to prevent unexpected payment attempts after the customer has canceled a subscription. However, you can resume automatic collection of the invoices manually after subscription cancellation to have us proceed. Or, you could check for unpaid invoices before allowing the customer to cancel the subscription at all.</p>
    let Cancel settings (options: CancelOptions) =
        $"/v1/subscriptions/{options.SubscriptionExposedId}"
        |> RestApi.deleteAsync<Subscription> settings (Map.empty)

    ///<p>Retrieves the subscription with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/subscriptions/{options.SubscriptionExposedId}"
        |> RestApi.getAsync<Subscription> settings qs

    ///<p>Updates an existing subscription to match the specified parameters.
    ///When changing prices or quantities, we optionally prorate the price we charge next month to make up for any price changes.
    ///To preview how the proration is calculated, use the <a href="/docs/api/invoices/create_preview">create preview</a> endpoint.</p>
    ///<p>By default, we prorate subscription changes. For example, if a customer signs up on May 1 for a <currency>100</currency> price, they’ll be billed <currency>100</currency> immediately. If on May 15 they switch to a <currency>200</currency> price, then on June 1 they’ll be billed <currency>250</currency> (<currency>200</currency> for a renewal of her subscription, plus a <currency>50</currency> prorating adjustment for half of the previous month’s <currency>100</currency> difference). Similarly, a downgrade generates a credit that is applied to the next invoice. We also prorate when you make quantity changes.</p>
    ///<p>Switching prices does not normally change the billing date or generate an immediate charge unless:</p>
    ///<ul>
    ///<li>The billing interval is changed (for example, from monthly to yearly).</li>
    ///<li>The subscription moves from free to paid.</li>
    ///<li>A trial starts or ends.</li>
    ///</ul>
    ///<p>In these cases, we apply a credit for the unused time on the previous price, immediately charge the customer using the new price, and reset the billing date. Learn about how <a href="/docs/billing/subscriptions/upgrade-downgrade#immediate-payment">Stripe immediately attempts payment for subscription changes</a>.</p>
    ///<p>If you want to charge for an upgrade immediately, pass <code>proration_behavior</code> as <code>always_invoice</code> to create prorations, automatically invoice the customer for those proration adjustments, and attempt to collect payment. If you pass <code>create_prorations</code>, the prorations are created but not automatically invoiced. If you want to bill the customer for the prorations before the subscription’s renewal date, you need to manually <a href="/docs/api/invoices/create">invoice the customer</a>.</p>
    ///<p>If you don’t want to prorate, set the <code>proration_behavior</code> option to <code>none</code>. With this option, the customer is billed <currency>100</currency> on May 1 and <currency>200</currency> on June 1. Similarly, if you set <code>proration_behavior</code> to <code>none</code> when switching between different billing intervals (for example, from monthly to yearly), we don’t generate any credits for the old subscription’s unused time. We still reset the billing date and bill immediately for the new subscription.</p>
    ///<p>Updating the quantity on a subscription many times in an hour may result in <a href="/docs/rate-limits">rate limiting</a>. If you need to bill for a frequently changing quantity, consider integrating <a href="/docs/billing/subscriptions/usage-based">usage-based billing</a> instead.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/subscriptions/{options.SubscriptionExposedId}"
        |> RestApi.postAsync<_, Subscription> settings (Map.empty) options

module SubscriptionsSearch =

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
            /// The search query string. See [search query language](https://docs.stripe.com/search#search-query-language) and the list of supported [query fields for subscriptions](https://docs.stripe.com/search#query-fields-for-subscriptions).
            [<Config.Query>]
            Query: string
        }

    module SearchOptions =
        let create
            (
                query: string
            ) : SearchOptions
            =
            {
              Query = query
              Expand = None
              Limit = None
              Page = None
            }

    ///<p>Search for subscriptions you’ve previously created using Stripe’s <a href="/docs/search#search-query-language">Search Query Language</a>.
    ///Don’t use search in read-after-write flows where strict consistency is necessary. Under normal operating
    ///conditions, data is searchable in less than a minute. Occasionally, propagation of new or updated data can be up
    ///to an hour behind during outages. Search functionality is not available to merchants in India.</p>
    let Search settings (options: SearchOptions) =
        let qs = [("expand", options.Expand |> box); ("limit", options.Limit |> box); ("page", options.Page |> box); ("query", options.Query |> box)] |> Map.ofList
        $"/v1/subscriptions/search"
        |> RestApi.getAsync<StripeList<Subscription>> settings qs

module SubscriptionsDiscount =

    type DeleteDiscountOptions =
        { [<Config.Path>]
          SubscriptionExposedId: string }

    module DeleteDiscountOptions =
        let create
            (
                subscriptionExposedId: string
            ) : DeleteDiscountOptions
            =
            {
              SubscriptionExposedId = subscriptionExposedId
            }

    ///<p>Removes the currently applied discount on a subscription.</p>
    let DeleteDiscount settings (options: DeleteDiscountOptions) =
        $"/v1/subscriptions/{options.SubscriptionExposedId}/discount"
        |> RestApi.deleteAsync<DeletedDiscount> settings (Map.empty)

module SubscriptionsMigrate =

    type Migrate'BillingModeFlexibleProrationDiscounts =
        | Included
        | Itemized

    type Migrate'BillingModeFlexible =
        {
            /// Controls how invoices and invoice items display proration amounts and discount amounts.
            [<Config.Form>]
            ProrationDiscounts: Migrate'BillingModeFlexibleProrationDiscounts option
        }

    module Migrate'BillingModeFlexible =
        let create
            (
                prorationDiscounts: Migrate'BillingModeFlexibleProrationDiscounts option
            ) : Migrate'BillingModeFlexible
            =
            {
              ProrationDiscounts = prorationDiscounts
            }

    type Migrate'BillingModeType = | Flexible

    type Migrate'BillingMode =
        {
            /// Configure behavior for flexible billing mode.
            [<Config.Form>]
            Flexible: Migrate'BillingModeFlexible option
            /// Controls the calculation and orchestration of prorations and invoices for subscriptions.
            [<Config.Form>]
            Type: Migrate'BillingModeType option
        }

    module Migrate'BillingMode =
        let create
            (
                flexible: Migrate'BillingModeFlexible option,
                ``type``: Migrate'BillingModeType option
            ) : Migrate'BillingMode
            =
            {
              Flexible = flexible
              Type = ``type``
            }

    type MigrateOptions =
        {
            [<Config.Path>]
            Subscription: string
            /// Controls how prorations and invoices for subscriptions are calculated and orchestrated.
            [<Config.Form>]
            BillingMode: Migrate'BillingMode
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module MigrateOptions =
        let create
            (
                billingMode: Migrate'BillingMode,
                subscription: string
            ) : MigrateOptions
            =
            {
              BillingMode = billingMode
              Subscription = subscription
              Expand = None
            }

    ///<p>Upgrade the billing_mode of an existing subscription.</p>
    let Migrate settings (options: MigrateOptions) =
        $"/v1/subscriptions/{options.Subscription}/migrate"
        |> RestApi.postAsync<_, Subscription> settings (Map.empty) options

module SubscriptionsResume =

    type Resume'BillingCycleAnchor =
        | Now
        | Unchanged

    type Resume'ProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | [<JsonPropertyName("none")>] None'

    type ResumeOptions =
        {
            [<Config.Path>]
            Subscription: string
            /// The billing cycle anchor that applies when the subscription is resumed. Either `now` or `unchanged`. The default is `now`. For more information, see the billing cycle [documentation](https://docs.stripe.com/billing/subscriptions/billing-cycle).
            [<Config.Form>]
            BillingCycleAnchor: Resume'BillingCycleAnchor option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Determines how to handle [prorations](https://docs.stripe.com/billing/subscriptions/prorations) resulting from the `billing_cycle_anchor` being `unchanged`. When the `billing_cycle_anchor` is set to `now` (default value), no prorations are generated. If no value is passed, the default is `create_prorations`.
            [<Config.Form>]
            ProrationBehavior: Resume'ProrationBehavior option
            /// If set, prorations will be calculated as though the subscription was resumed at the given time. This can be used to apply exactly the same prorations that were previewed with the [create preview](https://stripe.com/docs/api/invoices/create_preview) endpoint.
            [<Config.Form>]
            ProrationDate: DateTime option
        }

    module ResumeOptions =
        let create
            (
                subscription: string
            ) : ResumeOptions
            =
            {
              Subscription = subscription
              BillingCycleAnchor = None
              Expand = None
              ProrationBehavior = None
              ProrationDate = None
            }

    ///<p>Initiates resumption of a paused subscription, optionally resetting the billing cycle anchor and creating prorations. If no resumption invoice is generated, the subscription becomes <code>active</code> immediately. If a resumption invoice is generated, the subscription remains <code>paused</code> until the invoice is paid or marked uncollectible. If the invoice isn’t paid by the expiration date, it is voided and the subscription remains <code>paused</code>. You can only resume subscriptions with <code>collection_method</code> set to <code>charge_automatically</code>. <code>send_invoice</code> subscriptions are not supported.</p>
    let Resume settings (options: ResumeOptions) =
        $"/v1/subscriptions/{options.Subscription}/resume"
        |> RestApi.postAsync<_, Subscription> settings (Map.empty) options

