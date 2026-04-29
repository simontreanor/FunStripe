namespace FunStripe.StripeRequest

open FunStripe
open FunStripe.Json
open FunStripe.StripeModel
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module CheckoutSessions =

    type ListOptions = {
        ///Only return the Checkout Sessions for the Customer specified.
        [<Config.Query>]Customer: string option
        ///Only return the Checkout Sessions for the Customer details specified.
        [<Config.Query>]CustomerDetails: Map<string, string> option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///Only return the Checkout Session for the PaymentIntent specified.
        [<Config.Query>]PaymentIntent: string option
        ///Only return the Checkout Sessions for the Payment Link specified.
        [<Config.Query>]PaymentLink: string option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///Only return the Checkout Session for the subscription specified.
        [<Config.Query>]Subscription: string option
    }
    with
        static member New(?customer: string, ?customerDetails: Map<string, string>, ?endingBefore: string, ?expand: string list, ?limit: int, ?paymentIntent: string, ?paymentLink: string, ?startingAfter: string, ?subscription: string) =
            {
                Customer = customer
                CustomerDetails = customerDetails
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                PaymentIntent = paymentIntent
                PaymentLink = paymentLink
                StartingAfter = startingAfter
                Subscription = subscription
            }

    ///<p>Returns a list of Checkout Sessions.</p>
    let List settings (options: ListOptions) =
        let qs = [("customer", options.Customer |> box); ("customer_details", options.CustomerDetails |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("payment_intent", options.PaymentIntent |> box); ("payment_link", options.PaymentLink |> box); ("starting_after", options.StartingAfter |> box); ("subscription", options.Subscription |> box)] |> Map.ofList
        $"/v1/checkout/sessions"
        |> RestApi.getAsync<CheckoutSession list> settings qs

    type Create'AfterExpirationRecovery = {
        ///Enables user redeemable promotion codes on the recovered Checkout Sessions. Defaults to `false`
        [<Config.Form>]AllowPromotionCodes: bool option
        ///If `true`, a recovery URL will be generated to recover this Checkout Session if it
        ///expires before a successful transaction is completed. It will be attached to the
        ///Checkout Session object upon expiration.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?allowPromotionCodes: bool, ?enabled: bool) =
            {
                AllowPromotionCodes = allowPromotionCodes
                Enabled = enabled
            }

    type Create'AfterExpiration = {
        ///Configure a Checkout Session that can be used to recover an expired session.
        [<Config.Form>]Recovery: Create'AfterExpirationRecovery option
    }
    with
        static member New(?recovery: Create'AfterExpirationRecovery) =
            {
                Recovery = recovery
            }

    type Create'AutomaticTax = {
        ///Set to true to enable automatic taxes.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Create'ConsentCollectionPromotions =
    | Auto
    | None'

    type Create'ConsentCollectionTermsOfService =
    | None'
    | Required

    type Create'ConsentCollection = {
        ///If set to `auto`, enables the collection of customer consent for promotional communications. The Checkout
        ///Session will determine whether to display an option to opt into promotional communication
        ///from the merchant depending on the customer's locale. Only available to US merchants.
        [<Config.Form>]Promotions: Create'ConsentCollectionPromotions option
        ///If set to `required`, it requires customers to check a terms of service checkbox before being able to pay.
        ///There must be a valid terms of service URL set in your [Dashboard settings](https://dashboard.stripe.com/settings/public).
        [<Config.Form>]TermsOfService: Create'ConsentCollectionTermsOfService option
    }
    with
        static member New(?promotions: Create'ConsentCollectionPromotions, ?termsOfService: Create'ConsentCollectionTermsOfService) =
            {
                Promotions = promotions
                TermsOfService = termsOfService
            }

    type Create'CustomFieldsDropdownOptions = {
        ///The label for the option, displayed to the customer. Up to 100 characters.
        [<Config.Form>]Label: string option
        ///The value for this option, not displayed to the customer, used by your integration to reconcile the option selected by the customer. Must be unique to this option, alphanumeric, and up to 100 characters.
        [<Config.Form>]Value: string option
    }
    with
        static member New(?label: string, ?value: string) =
            {
                Label = label
                Value = value
            }

    type Create'CustomFieldsDropdown = {
        ///The options available for the customer to select. Up to 200 options allowed.
        [<Config.Form>]Options: Create'CustomFieldsDropdownOptions list option
    }
    with
        static member New(?options: Create'CustomFieldsDropdownOptions list) =
            {
                Options = options
            }

    type Create'CustomFieldsLabelType =
    | Custom

    type Create'CustomFieldsLabel = {
        ///Custom text for the label, displayed to the customer. Up to 50 characters.
        [<Config.Form>]Custom: string option
        ///The type of the label.
        [<Config.Form>]Type: Create'CustomFieldsLabelType option
    }
    with
        static member New(?custom: string, ?type': Create'CustomFieldsLabelType) =
            {
                Custom = custom
                Type = type'
            }

    type Create'CustomFieldsNumeric = {
        ///The maximum character length constraint for the customer's input.
        [<Config.Form>]MaximumLength: int option
        ///The minimum character length requirement for the customer's input.
        [<Config.Form>]MinimumLength: int option
    }
    with
        static member New(?maximumLength: int, ?minimumLength: int) =
            {
                MaximumLength = maximumLength
                MinimumLength = minimumLength
            }

    type Create'CustomFieldsText = {
        ///The maximum character length constraint for the customer's input.
        [<Config.Form>]MaximumLength: int option
        ///The minimum character length requirement for the customer's input.
        [<Config.Form>]MinimumLength: int option
    }
    with
        static member New(?maximumLength: int, ?minimumLength: int) =
            {
                MaximumLength = maximumLength
                MinimumLength = minimumLength
            }

    type Create'CustomFieldsType =
    | Dropdown
    | Numeric
    | Text

    type Create'CustomFields = {
        ///Configuration for `type=dropdown` fields.
        [<Config.Form>]Dropdown: Create'CustomFieldsDropdown option
        ///String of your choice that your integration can use to reconcile this field. Must be unique to this field, alphanumeric, and up to 200 characters.
        [<Config.Form>]Key: string option
        ///The label for the field, displayed to the customer.
        [<Config.Form>]Label: Create'CustomFieldsLabel option
        ///Configuration for `type=numeric` fields.
        [<Config.Form>]Numeric: Create'CustomFieldsNumeric option
        ///Whether the customer is required to complete the field before completing the Checkout Session. Defaults to `false`.
        [<Config.Form>]Optional: bool option
        ///Configuration for `type=text` fields.
        [<Config.Form>]Text: Create'CustomFieldsText option
        ///The type of the field.
        [<Config.Form>]Type: Create'CustomFieldsType option
    }
    with
        static member New(?dropdown: Create'CustomFieldsDropdown, ?key: string, ?label: Create'CustomFieldsLabel, ?numeric: Create'CustomFieldsNumeric, ?optional: bool, ?text: Create'CustomFieldsText, ?type': Create'CustomFieldsType) =
            {
                Dropdown = dropdown
                Key = key
                Label = label
                Numeric = numeric
                Optional = optional
                Text = text
                Type = type'
            }

    type Create'CustomTextShippingAddressCustomTextPosition = {
        ///Text may be up to 1000 characters in length.
        [<Config.Form>]Message: string option
    }
    with
        static member New(?message: string) =
            {
                Message = message
            }

    type Create'CustomTextSubmitCustomTextPosition = {
        ///Text may be up to 1000 characters in length.
        [<Config.Form>]Message: string option
    }
    with
        static member New(?message: string) =
            {
                Message = message
            }

    type Create'CustomText = {
        ///Custom text that should be displayed alongside shipping address collection.
        [<Config.Form>]ShippingAddress: Choice<Create'CustomTextShippingAddressCustomTextPosition,string> option
        ///Custom text that should be displayed alongside the payment confirmation button.
        [<Config.Form>]Submit: Choice<Create'CustomTextSubmitCustomTextPosition,string> option
    }
    with
        static member New(?shippingAddress: Choice<Create'CustomTextShippingAddressCustomTextPosition,string>, ?submit: Choice<Create'CustomTextSubmitCustomTextPosition,string>) =
            {
                ShippingAddress = shippingAddress
                Submit = submit
            }

    type Create'CustomerUpdateAddress =
    | Auto
    | Never

    type Create'CustomerUpdateName =
    | Auto
    | Never

    type Create'CustomerUpdateShipping =
    | Auto
    | Never

    type Create'CustomerUpdate = {
        ///Describes whether Checkout saves the billing address onto `customer.address`.
        ///To always collect a full billing address, use `billing_address_collection`. Defaults to `never`.
        [<Config.Form>]Address: Create'CustomerUpdateAddress option
        ///Describes whether Checkout saves the name onto `customer.name`. Defaults to `never`.
        [<Config.Form>]Name: Create'CustomerUpdateName option
        ///Describes whether Checkout saves shipping information onto `customer.shipping`.
        ///To collect shipping information, use `shipping_address_collection`. Defaults to `never`.
        [<Config.Form>]Shipping: Create'CustomerUpdateShipping option
    }
    with
        static member New(?address: Create'CustomerUpdateAddress, ?name: Create'CustomerUpdateName, ?shipping: Create'CustomerUpdateShipping) =
            {
                Address = address
                Name = name
                Shipping = shipping
            }

    type Create'Discounts = {
        ///The ID of the coupon to apply to this Session.
        [<Config.Form>]Coupon: string option
        ///The ID of a promotion code to apply to this Session.
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?promotionCode: string) =
            {
                Coupon = coupon
                PromotionCode = promotionCode
            }

    type Create'InvoiceCreationInvoiceDataCustomFields = {
        ///The name of the custom field. This may be up to 30 characters.
        [<Config.Form>]Name: string option
        ///The value of the custom field. This may be up to 30 characters.
        [<Config.Form>]Value: string option
    }
    with
        static member New(?name: string, ?value: string) =
            {
                Name = name
                Value = value
            }

    type Create'InvoiceCreationInvoiceDataRenderingOptionsRenderingOptionsAmountTaxDisplay =
    | ExcludeTax
    | IncludeInclusiveTax

    type Create'InvoiceCreationInvoiceDataRenderingOptionsRenderingOptions = {
        ///How line-item prices and amounts will be displayed with respect to tax on invoice PDFs. One of `exclude_tax` or `include_inclusive_tax`. `include_inclusive_tax` will include inclusive tax (and exclude exclusive tax) in invoice PDF amounts. `exclude_tax` will exclude all tax (inclusive and exclusive alike) from invoice PDF amounts.
        [<Config.Form>]AmountTaxDisplay: Create'InvoiceCreationInvoiceDataRenderingOptionsRenderingOptionsAmountTaxDisplay option
    }
    with
        static member New(?amountTaxDisplay: Create'InvoiceCreationInvoiceDataRenderingOptionsRenderingOptionsAmountTaxDisplay) =
            {
                AmountTaxDisplay = amountTaxDisplay
            }

    type Create'InvoiceCreationInvoiceData = {
        ///The account tax IDs associated with the invoice.
        [<Config.Form>]AccountTaxIds: Choice<string list,string> option
        ///Default custom fields to be displayed on invoices for this customer.
        [<Config.Form>]CustomFields: Choice<Create'InvoiceCreationInvoiceDataCustomFields list,string> option
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        [<Config.Form>]Description: string option
        ///Default footer to be displayed on invoices for this customer.
        [<Config.Form>]Footer: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Default options for invoice PDF rendering for this customer.
        [<Config.Form>]RenderingOptions: Choice<Create'InvoiceCreationInvoiceDataRenderingOptionsRenderingOptions,string> option
    }
    with
        static member New(?accountTaxIds: Choice<string list,string>, ?customFields: Choice<Create'InvoiceCreationInvoiceDataCustomFields list,string>, ?description: string, ?footer: string, ?metadata: Map<string, string>, ?renderingOptions: Choice<Create'InvoiceCreationInvoiceDataRenderingOptionsRenderingOptions,string>) =
            {
                AccountTaxIds = accountTaxIds
                CustomFields = customFields
                Description = description
                Footer = footer
                Metadata = metadata
                RenderingOptions = renderingOptions
            }

    type Create'InvoiceCreation = {
        ///Set to `true` to enable invoice creation.
        [<Config.Form>]Enabled: bool option
        ///Parameters passed when creating invoices for payment-mode Checkout Sessions.
        [<Config.Form>]InvoiceData: Create'InvoiceCreationInvoiceData option
    }
    with
        static member New(?enabled: bool, ?invoiceData: Create'InvoiceCreationInvoiceData) =
            {
                Enabled = enabled
                InvoiceData = invoiceData
            }

    type Create'LineItemsAdjustableQuantity = {
        ///Set to true if the quantity can be adjusted to any non-negative integer. By default customers will be able to remove the line item by setting the quantity to 0.
        [<Config.Form>]Enabled: bool option
        ///The maximum quantity the customer can purchase for the Checkout Session. By default this value is 99. You can specify a value up to 999999.
        [<Config.Form>]Maximum: int option
        ///The minimum quantity the customer must purchase for the Checkout Session. By default this value is 0.
        [<Config.Form>]Minimum: int option
    }
    with
        static member New(?enabled: bool, ?maximum: int, ?minimum: int) =
            {
                Enabled = enabled
                Maximum = maximum
                Minimum = minimum
            }

    type Create'LineItemsPriceDataProductData = {
        ///The product's description, meant to be displayable to the customer. Use this field to optionally store a long form explanation of the product being sold for your own rendering purposes.
        [<Config.Form>]Description: string option
        ///A list of up to 8 URLs of images for this product, meant to be displayable to the customer.
        [<Config.Form>]Images: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The product's name, meant to be displayable to the customer.
        [<Config.Form>]Name: string option
        ///A [tax code](https://stripe.com/docs/tax/tax-categories) ID.
        [<Config.Form>]TaxCode: string option
    }
    with
        static member New(?description: string, ?images: string list, ?metadata: Map<string, string>, ?name: string, ?taxCode: string) =
            {
                Description = description
                Images = images
                Metadata = metadata
                Name = name
                TaxCode = taxCode
            }

    type Create'LineItemsPriceDataRecurringInterval =
    | Day
    | Month
    | Week
    | Year

    type Create'LineItemsPriceDataRecurring = {
        ///Specifies billing frequency. Either `day`, `week`, `month` or `year`.
        [<Config.Form>]Interval: Create'LineItemsPriceDataRecurringInterval option
        ///The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Create'LineItemsPriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Create'LineItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Create'LineItemsPriceData = {
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///The ID of the product that this price will belong to. One of `product` or `product_data` is required.
        [<Config.Form>]Product: string option
        ///Data used to generate a new product object inline. One of `product` or `product_data` is required.
        [<Config.Form>]ProductData: Create'LineItemsPriceDataProductData option
        ///The recurring components of a price such as `interval` and `interval_count`.
        [<Config.Form>]Recurring: Create'LineItemsPriceDataRecurring option
        ///Only required if a [default tax behavior](https://stripe.com/docs/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
        [<Config.Form>]TaxBehavior: Create'LineItemsPriceDataTaxBehavior option
        ///A non-negative integer in cents (or local equivalent) representing how much to charge. One of `unit_amount` or `unit_amount_decimal` is required.
        [<Config.Form>]UnitAmount: int option
        ///Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: string, ?product: string, ?productData: Create'LineItemsPriceDataProductData, ?recurring: Create'LineItemsPriceDataRecurring, ?taxBehavior: Create'LineItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                ProductData = productData
                Recurring = recurring
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Create'LineItems = {
        ///When set, provides configuration for this item’s quantity to be adjusted by the customer during Checkout.
        [<Config.Form>]AdjustableQuantity: Create'LineItemsAdjustableQuantity option
        ///The [tax rates](https://stripe.com/docs/api/tax_rates) that will be applied to this line item depending on the customer's billing/shipping address. We currently support the following countries: US, GB, AU, and all countries in the EU.
        [<Config.Form>]DynamicTaxRates: string list option
        ///The ID of the [Price](https://stripe.com/docs/api/prices) or [Plan](https://stripe.com/docs/api/plans) object. One of `price` or `price_data` is required.
        [<Config.Form>]Price: string option
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline. One of `price` or `price_data` is required.
        [<Config.Form>]PriceData: Create'LineItemsPriceData option
        ///The quantity of the line item being purchased. Quantity should not be defined when `recurring.usage_type=metered`.
        [<Config.Form>]Quantity: int option
        ///The [tax rates](https://stripe.com/docs/api/tax_rates) which apply to this line item.
        [<Config.Form>]TaxRates: string list option
    }
    with
        static member New(?adjustableQuantity: Create'LineItemsAdjustableQuantity, ?dynamicTaxRates: string list, ?price: string, ?priceData: Create'LineItemsPriceData, ?quantity: int, ?taxRates: string list) =
            {
                AdjustableQuantity = adjustableQuantity
                DynamicTaxRates = dynamicTaxRates
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Create'PaymentIntentDataShippingAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'PaymentIntentDataShipping = {
        ///Shipping address.
        [<Config.Form>]Address: Create'PaymentIntentDataShippingAddress option
        ///The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc.
        [<Config.Form>]Carrier: string option
        ///Recipient name.
        [<Config.Form>]Name: string option
        ///Recipient phone (including extension).
        [<Config.Form>]Phone: string option
        ///The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
        [<Config.Form>]TrackingNumber: string option
    }
    with
        static member New(?address: Create'PaymentIntentDataShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
            {
                Address = address
                Carrier = carrier
                Name = name
                Phone = phone
                TrackingNumber = trackingNumber
            }

    type Create'PaymentIntentDataTransferData = {
        ///The amount that will be transferred automatically when a charge succeeds.
        [<Config.Form>]Amount: int option
        ///If specified, successful charges will be attributed to the destination
        ///account for tax reporting, and the funds from charges will be transferred
        ///to the destination account. The ID of the resulting transfer will be
        ///returned on the successful charge's `transfer` field.
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amount: int, ?destination: string) =
            {
                Amount = amount
                Destination = destination
            }

    type Create'PaymentIntentDataCaptureMethod =
    | Automatic
    | AutomaticAsync
    | Manual

    type Create'PaymentIntentDataSetupFutureUsage =
    | OffSession
    | OnSession

    type Create'PaymentIntentData = {
        ///The amount of the application fee (if any) that will be requested to be applied to the payment and transferred to the application owner's Stripe account. The amount of the application fee collected will be capped at the total payment amount. For more information, see the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts).
        [<Config.Form>]ApplicationFeeAmount: int option
        ///Controls when the funds will be captured from the customer's account.
        [<Config.Form>]CaptureMethod: Create'PaymentIntentDataCaptureMethod option
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        [<Config.Form>]Description: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The Stripe account ID for which these funds are intended. For details,
        ///see the PaymentIntents [use case for connected
        ///accounts](/docs/payments/connected-accounts).
        [<Config.Form>]OnBehalfOf: string option
        ///Email address that the receipt for the resulting payment will be sent to. If `receipt_email` is specified for a payment in live mode, a receipt will be sent regardless of your [email settings](https://dashboard.stripe.com/account/emails).
        [<Config.Form>]ReceiptEmail: string option
        ///Indicates that you intend to [make future payments](https://stripe.com/docs/payments/payment-intents#future-usage) with the payment
        ///method collected by this Checkout Session.
        ///When setting this to `on_session`, Checkout will show a notice to the
        ///customer that their payment details will be saved.
        ///When setting this to `off_session`, Checkout will show a notice to the
        ///customer that their payment details will be saved and used for future
        ///payments.
        ///If a Customer has been provided or Checkout creates a new Customer,
        ///Checkout will attach the payment method to the Customer.
        ///If Checkout does not create a Customer, the payment method is not attached
        ///to a Customer. To reuse the payment method, you can retrieve it from the
        ///Checkout Session's PaymentIntent.
        ///When processing card payments, Checkout also uses `setup_future_usage`
        ///to dynamically optimize your payment flow and comply with regional
        ///legislation and network rules, such as SCA.
        [<Config.Form>]SetupFutureUsage: Create'PaymentIntentDataSetupFutureUsage option
        ///Shipping information for this payment.
        [<Config.Form>]Shipping: Create'PaymentIntentDataShipping option
        ///Extra information about the payment. This will appear on your
        ///customer's statement when this payment succeeds in creating a charge.
        [<Config.Form>]StatementDescriptor: string option
        ///Provides information about the charge that customers see on their statements. Concatenated with the
        ///prefix (shortened descriptor) or statement descriptor that’s set on the account to form the complete
        ///statement descriptor. Maximum 22 characters for the concatenated descriptor.
        [<Config.Form>]StatementDescriptorSuffix: string option
        ///The parameters used to automatically create a Transfer when the payment succeeds.
        ///For more information, see the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts).
        [<Config.Form>]TransferData: Create'PaymentIntentDataTransferData option
        ///A string that identifies the resulting payment as part of a group. See the PaymentIntents [use case for connected accounts](https://stripe.com/docs/connect/separate-charges-and-transfers) for details.
        [<Config.Form>]TransferGroup: string option
    }
    with
        static member New(?applicationFeeAmount: int, ?captureMethod: Create'PaymentIntentDataCaptureMethod, ?description: string, ?metadata: Map<string, string>, ?onBehalfOf: string, ?receiptEmail: string, ?setupFutureUsage: Create'PaymentIntentDataSetupFutureUsage, ?shipping: Create'PaymentIntentDataShipping, ?statementDescriptor: string, ?statementDescriptorSuffix: string, ?transferData: Create'PaymentIntentDataTransferData, ?transferGroup: string) =
            {
                ApplicationFeeAmount = applicationFeeAmount
                CaptureMethod = captureMethod
                Description = description
                Metadata = metadata
                OnBehalfOf = onBehalfOf
                ReceiptEmail = receiptEmail
                SetupFutureUsage = setupFutureUsage
                Shipping = shipping
                StatementDescriptor = statementDescriptor
                StatementDescriptorSuffix = statementDescriptorSuffix
                TransferData = transferData
                TransferGroup = transferGroup
            }

    type Create'PaymentMethodOptionsAcssDebitMandateOptionsDefaultFor =
    | Invoice
    | Subscription

    type Create'PaymentMethodOptionsAcssDebitMandateOptionsPaymentSchedule =
    | Combined
    | Interval
    | Sporadic

    type Create'PaymentMethodOptionsAcssDebitMandateOptionsTransactionType =
    | Business
    | Personal

    type Create'PaymentMethodOptionsAcssDebitMandateOptions = {
        ///A URL for custom mandate text to render during confirmation step.
        ///The URL will be rendered with additional GET parameters `payment_intent` and `payment_intent_client_secret` when confirming a Payment Intent,
        ///or `setup_intent` and `setup_intent_client_secret` when confirming a Setup Intent.
        [<Config.Form>]CustomMandateUrl: Choice<string,string> option
        ///List of Stripe products where this mandate can be selected automatically. Only usable in `setup` mode.
        [<Config.Form>]DefaultFor: Create'PaymentMethodOptionsAcssDebitMandateOptionsDefaultFor list option
        ///Description of the mandate interval. Only required if 'payment_schedule' parameter is 'interval' or 'combined'.
        [<Config.Form>]IntervalDescription: string option
        ///Payment schedule for the mandate.
        [<Config.Form>]PaymentSchedule: Create'PaymentMethodOptionsAcssDebitMandateOptionsPaymentSchedule option
        ///Transaction type of the mandate.
        [<Config.Form>]TransactionType: Create'PaymentMethodOptionsAcssDebitMandateOptionsTransactionType option
    }
    with
        static member New(?customMandateUrl: Choice<string,string>, ?defaultFor: Create'PaymentMethodOptionsAcssDebitMandateOptionsDefaultFor list, ?intervalDescription: string, ?paymentSchedule: Create'PaymentMethodOptionsAcssDebitMandateOptionsPaymentSchedule, ?transactionType: Create'PaymentMethodOptionsAcssDebitMandateOptionsTransactionType) =
            {
                CustomMandateUrl = customMandateUrl
                DefaultFor = defaultFor
                IntervalDescription = intervalDescription
                PaymentSchedule = paymentSchedule
                TransactionType = transactionType
            }

    type Create'PaymentMethodOptionsAcssDebitCurrency =
    | Cad
    | Usd

    type Create'PaymentMethodOptionsAcssDebitSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Create'PaymentMethodOptionsAcssDebitVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Create'PaymentMethodOptionsAcssDebit = {
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies). This is only accepted for Checkout Sessions in `setup` mode.
        [<Config.Form>]Currency: Create'PaymentMethodOptionsAcssDebitCurrency option
        ///Additional fields for Mandate creation
        [<Config.Form>]MandateOptions: Create'PaymentMethodOptionsAcssDebitMandateOptions option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsAcssDebitSetupFutureUsage option
        ///Verification method for the intent
        [<Config.Form>]VerificationMethod: Create'PaymentMethodOptionsAcssDebitVerificationMethod option
    }
    with
        static member New(?currency: Create'PaymentMethodOptionsAcssDebitCurrency, ?mandateOptions: Create'PaymentMethodOptionsAcssDebitMandateOptions, ?setupFutureUsage: Create'PaymentMethodOptionsAcssDebitSetupFutureUsage, ?verificationMethod: Create'PaymentMethodOptionsAcssDebitVerificationMethod) =
            {
                Currency = currency
                MandateOptions = mandateOptions
                SetupFutureUsage = setupFutureUsage
                VerificationMethod = verificationMethod
            }

    type Create'PaymentMethodOptionsAffirmSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsAffirm = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsAffirmSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsAffirmSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsAfterpayClearpaySetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsAfterpayClearpay = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsAfterpayClearpaySetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsAfterpayClearpaySetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsAlipaySetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsAlipay = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsAlipaySetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsAlipaySetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsAuBecsDebitSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsAuBecsDebit = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsAuBecsDebitSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsAuBecsDebitSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsBacsDebitSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Create'PaymentMethodOptionsBacsDebit = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsBacsDebitSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsBacsDebitSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsBancontactSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsBancontact = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsBancontactSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsBancontactSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsBoletoSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Create'PaymentMethodOptionsBoleto = {
        ///The number of calendar days before a Boleto voucher expires. For example, if you create a Boleto voucher on Monday and you set expires_after_days to 2, the Boleto invoice will expire on Wednesday at 23:59 America/Sao_Paulo time.
        [<Config.Form>]ExpiresAfterDays: int option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsBoletoSetupFutureUsage option
    }
    with
        static member New(?expiresAfterDays: int, ?setupFutureUsage: Create'PaymentMethodOptionsBoletoSetupFutureUsage) =
            {
                ExpiresAfterDays = expiresAfterDays
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsCardInstallments = {
        ///Setting to true enables installments for this Checkout Session.
        ///Setting to false will prevent any installment plan from applying to a payment.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Create'PaymentMethodOptionsCardSetupFutureUsage =
    | OffSession
    | OnSession

    type Create'PaymentMethodOptionsCard = {
        ///Installment options for card payments
        [<Config.Form>]Installments: Create'PaymentMethodOptionsCardInstallments option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsCardSetupFutureUsage option
        ///Provides information about a card payment that customers see on their statements. Concatenated with the Kana prefix (shortened Kana descriptor) or Kana statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 22 characters. On card statements, the *concatenation* of both prefix and suffix (including separators) will appear truncated to 22 characters.
        [<Config.Form>]StatementDescriptorSuffixKana: string option
        ///Provides information about a card payment that customers see on their statements. Concatenated with the Kanji prefix (shortened Kanji descriptor) or Kanji statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 17 characters. On card statements, the *concatenation* of both prefix and suffix (including separators) will appear truncated to 17 characters.
        [<Config.Form>]StatementDescriptorSuffixKanji: string option
    }
    with
        static member New(?installments: Create'PaymentMethodOptionsCardInstallments, ?setupFutureUsage: Create'PaymentMethodOptionsCardSetupFutureUsage, ?statementDescriptorSuffixKana: string, ?statementDescriptorSuffixKanji: string) =
            {
                Installments = installments
                SetupFutureUsage = setupFutureUsage
                StatementDescriptorSuffixKana = statementDescriptorSuffixKana
                StatementDescriptorSuffixKanji = statementDescriptorSuffixKanji
            }

    type Create'PaymentMethodOptionsCashappSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Create'PaymentMethodOptionsCashapp = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsCashappSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsCashappSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsCustomerBalanceBankTransferEuBankTransfer = {
        ///The desired country code of the bank account information. Permitted values include: `BE`, `DE`, `ES`, `FR`, `IE`, or `NL`.
        [<Config.Form>]Country: string option
    }
    with
        static member New(?country: string) =
            {
                Country = country
            }

    type Create'PaymentMethodOptionsCustomerBalanceBankTransferRequestedAddressTypes =
    | Aba
    | Iban
    | Sepa
    | SortCode
    | Spei
    | Swift
    | Zengin

    type Create'PaymentMethodOptionsCustomerBalanceBankTransferType =
    | EuBankTransfer
    | GbBankTransfer
    | JpBankTransfer
    | MxBankTransfer
    | UsBankTransfer

    type Create'PaymentMethodOptionsCustomerBalanceBankTransfer = {
        ///Configuration for eu_bank_transfer funding type.
        [<Config.Form>]EuBankTransfer: Create'PaymentMethodOptionsCustomerBalanceBankTransferEuBankTransfer option
        ///List of address types that should be returned in the financial_addresses response. If not specified, all valid types will be returned.
        ///Permitted values include: `sort_code`, `zengin`, `iban`, or `spei`.
        [<Config.Form>]RequestedAddressTypes: Create'PaymentMethodOptionsCustomerBalanceBankTransferRequestedAddressTypes list option
        ///The list of bank transfer types that this PaymentIntent is allowed to use for funding. Permitted values include: `us_bank_account`, `eu_bank_account`, `id_bank_account`, `gb_bank_account`, `jp_bank_account`, `mx_bank_account`, `eu_bank_transfer`, `gb_bank_transfer`, `id_bank_transfer`, `jp_bank_transfer`, `mx_bank_transfer`, or `us_bank_transfer`.
        [<Config.Form>]Type: Create'PaymentMethodOptionsCustomerBalanceBankTransferType option
    }
    with
        static member New(?euBankTransfer: Create'PaymentMethodOptionsCustomerBalanceBankTransferEuBankTransfer, ?requestedAddressTypes: Create'PaymentMethodOptionsCustomerBalanceBankTransferRequestedAddressTypes list, ?type': Create'PaymentMethodOptionsCustomerBalanceBankTransferType) =
            {
                EuBankTransfer = euBankTransfer
                RequestedAddressTypes = requestedAddressTypes
                Type = type'
            }

    type Create'PaymentMethodOptionsCustomerBalanceFundingType =
    | BankTransfer

    type Create'PaymentMethodOptionsCustomerBalanceSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsCustomerBalance = {
        ///Configuration for the bank transfer funding type, if the `funding_type` is set to `bank_transfer`.
        [<Config.Form>]BankTransfer: Create'PaymentMethodOptionsCustomerBalanceBankTransfer option
        ///The funding method type to be used when there are not enough funds in the customer balance. Permitted values include: `bank_transfer`.
        [<Config.Form>]FundingType: Create'PaymentMethodOptionsCustomerBalanceFundingType option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsCustomerBalanceSetupFutureUsage option
    }
    with
        static member New(?bankTransfer: Create'PaymentMethodOptionsCustomerBalanceBankTransfer, ?fundingType: Create'PaymentMethodOptionsCustomerBalanceFundingType, ?setupFutureUsage: Create'PaymentMethodOptionsCustomerBalanceSetupFutureUsage) =
            {
                BankTransfer = bankTransfer
                FundingType = fundingType
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsEpsSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsEps = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsEpsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsEpsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsFpxSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsFpx = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsFpxSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsFpxSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsGiropaySetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsGiropay = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsGiropaySetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsGiropaySetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsGrabpaySetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsGrabpay = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsGrabpaySetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsGrabpaySetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsIdealSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsIdeal = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsIdealSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsIdealSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsKlarnaSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsKlarna = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsKlarnaSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsKlarnaSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsKonbiniSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsKonbini = {
        ///The number of calendar days (between 1 and 60) after which Konbini payment instructions will expire. For example, if a PaymentIntent is confirmed with Konbini and `expires_after_days` set to 2 on Monday JST, the instructions will expire on Wednesday 23:59:59 JST. Defaults to 3 days.
        [<Config.Form>]ExpiresAfterDays: int option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsKonbiniSetupFutureUsage option
    }
    with
        static member New(?expiresAfterDays: int, ?setupFutureUsage: Create'PaymentMethodOptionsKonbiniSetupFutureUsage) =
            {
                ExpiresAfterDays = expiresAfterDays
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsLinkSetupFutureUsage =
    | None'
    | OffSession

    type Create'PaymentMethodOptionsLink = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsLinkSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsLinkSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsOxxoSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsOxxo = {
        ///The number of calendar days before an OXXO voucher expires. For example, if you create an OXXO voucher on Monday and you set expires_after_days to 2, the OXXO invoice will expire on Wednesday at 23:59 America/Mexico_City time.
        [<Config.Form>]ExpiresAfterDays: int option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsOxxoSetupFutureUsage option
    }
    with
        static member New(?expiresAfterDays: int, ?setupFutureUsage: Create'PaymentMethodOptionsOxxoSetupFutureUsage) =
            {
                ExpiresAfterDays = expiresAfterDays
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsP24SetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsP24 = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsP24SetupFutureUsage option
        ///Confirm that the payer has accepted the P24 terms and conditions.
        [<Config.Form>]TosShownAndAccepted: bool option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsP24SetupFutureUsage, ?tosShownAndAccepted: bool) =
            {
                SetupFutureUsage = setupFutureUsage
                TosShownAndAccepted = tosShownAndAccepted
            }

    type Create'PaymentMethodOptionsPaynowSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsPaynow = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsPaynowSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsPaynowSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsPaypalCaptureMethod =
    | Manual

    type Create'PaymentMethodOptionsPaypalPreferredLocale =
    | [<JsonUnionCase("cs-CZ")>] CsCZ
    | [<JsonUnionCase("da-DK")>] DaDK
    | [<JsonUnionCase("de-AT")>] DeAT
    | [<JsonUnionCase("de-DE")>] DeDE
    | [<JsonUnionCase("de-LU")>] DeLU
    | [<JsonUnionCase("el-GR")>] ElGR
    | [<JsonUnionCase("en-GB")>] EnGB
    | [<JsonUnionCase("en-US")>] EnUS
    | [<JsonUnionCase("es-ES")>] EsES
    | [<JsonUnionCase("fi-FI")>] FiFI
    | [<JsonUnionCase("fr-BE")>] FrBE
    | [<JsonUnionCase("fr-FR")>] FrFR
    | [<JsonUnionCase("fr-LU")>] FrLU
    | [<JsonUnionCase("hu-HU")>] HuHU
    | [<JsonUnionCase("it-IT")>] ItIT
    | [<JsonUnionCase("nl-BE")>] NlBE
    | [<JsonUnionCase("nl-NL")>] NlNL
    | [<JsonUnionCase("pl-PL")>] PlPL
    | [<JsonUnionCase("pt-PT")>] PtPT
    | [<JsonUnionCase("sk-SK")>] SkSK
    | [<JsonUnionCase("sv-SE")>] SvSE

    type Create'PaymentMethodOptionsPaypalSetupFutureUsage =
    | None'
    | OffSession

    type Create'PaymentMethodOptionsPaypal = {
        ///Controls when the funds will be captured from the customer's account.
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsPaypalCaptureMethod option
        ///[Preferred locale](https://stripe.com/docs/payments/paypal/supported-locales) of the PayPal checkout page that the customer is redirected to.
        [<Config.Form>]PreferredLocale: Create'PaymentMethodOptionsPaypalPreferredLocale option
        ///A reference of the PayPal transaction visible to customer which is mapped to PayPal's invoice ID. This must be a globally unique ID if you have configured in your PayPal settings to block multiple payments per invoice ID.
        [<Config.Form>]Reference: string option
        ///The risk correlation ID for an on-session payment using a saved PayPal payment method.
        [<Config.Form>]RiskCorrelationId: string option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsPaypalSetupFutureUsage option
    }
    with
        static member New(?captureMethod: Create'PaymentMethodOptionsPaypalCaptureMethod, ?preferredLocale: Create'PaymentMethodOptionsPaypalPreferredLocale, ?reference: string, ?riskCorrelationId: string, ?setupFutureUsage: Create'PaymentMethodOptionsPaypalSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                PreferredLocale = preferredLocale
                Reference = reference
                RiskCorrelationId = riskCorrelationId
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsPix = {
        ///The number of seconds (between 10 and 1209600) after which Pix payment will expire. Defaults to 86400 seconds.
        [<Config.Form>]ExpiresAfterSeconds: int option
    }
    with
        static member New(?expiresAfterSeconds: int) =
            {
                ExpiresAfterSeconds = expiresAfterSeconds
            }

    type Create'PaymentMethodOptionsSepaDebitSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Create'PaymentMethodOptionsSepaDebit = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsSepaDebitSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsSepaDebitSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsSofortSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsSofort = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsSofortSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsSofortSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions =
    | Balances
    | Ownership
    | PaymentMethod
    | Transactions

    type Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPrefetch =
    | Balances

    type Create'PaymentMethodOptionsUsBankAccountFinancialConnections = {
        ///The list of permissions to request. If this parameter is passed, the `payment_method` permission must be included. Valid permissions include: `balances`, `ownership`, `payment_method`, and `transactions`.
        [<Config.Form>]Permissions: Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions list option
        ///List of data features that you would like to retrieve upon account creation.
        [<Config.Form>]Prefetch: Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPrefetch list option
    }
    with
        static member New(?permissions: Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions list, ?prefetch: Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPrefetch list) =
            {
                Permissions = permissions
                Prefetch = prefetch
            }

    type Create'PaymentMethodOptionsUsBankAccountSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Create'PaymentMethodOptionsUsBankAccountVerificationMethod =
    | Automatic
    | Instant

    type Create'PaymentMethodOptionsUsBankAccount = {
        ///Additional fields for Financial Connections Session creation
        [<Config.Form>]FinancialConnections: Create'PaymentMethodOptionsUsBankAccountFinancialConnections option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsUsBankAccountSetupFutureUsage option
        ///Verification method for the intent
        [<Config.Form>]VerificationMethod: Create'PaymentMethodOptionsUsBankAccountVerificationMethod option
    }
    with
        static member New(?financialConnections: Create'PaymentMethodOptionsUsBankAccountFinancialConnections, ?setupFutureUsage: Create'PaymentMethodOptionsUsBankAccountSetupFutureUsage, ?verificationMethod: Create'PaymentMethodOptionsUsBankAccountVerificationMethod) =
            {
                FinancialConnections = financialConnections
                SetupFutureUsage = setupFutureUsage
                VerificationMethod = verificationMethod
            }

    type Create'PaymentMethodOptionsWechatPayClient =
    | Android
    | Ios
    | Web

    type Create'PaymentMethodOptionsWechatPaySetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsWechatPay = {
        ///The app ID registered with WeChat Pay. Only required when client is ios or android.
        [<Config.Form>]AppId: string option
        ///The client type that the end customer will pay from
        [<Config.Form>]Client: Create'PaymentMethodOptionsWechatPayClient option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsWechatPaySetupFutureUsage option
    }
    with
        static member New(?appId: string, ?client: Create'PaymentMethodOptionsWechatPayClient, ?setupFutureUsage: Create'PaymentMethodOptionsWechatPaySetupFutureUsage) =
            {
                AppId = appId
                Client = client
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptions = {
        ///contains details about the ACSS Debit payment method options.
        [<Config.Form>]AcssDebit: Create'PaymentMethodOptionsAcssDebit option
        ///contains details about the Affirm payment method options.
        [<Config.Form>]Affirm: Create'PaymentMethodOptionsAffirm option
        ///contains details about the Afterpay Clearpay payment method options.
        [<Config.Form>]AfterpayClearpay: Create'PaymentMethodOptionsAfterpayClearpay option
        ///contains details about the Alipay payment method options.
        [<Config.Form>]Alipay: Create'PaymentMethodOptionsAlipay option
        ///contains details about the AU Becs Debit payment method options.
        [<Config.Form>]AuBecsDebit: Create'PaymentMethodOptionsAuBecsDebit option
        ///contains details about the Bacs Debit payment method options.
        [<Config.Form>]BacsDebit: Create'PaymentMethodOptionsBacsDebit option
        ///contains details about the Bancontact payment method options.
        [<Config.Form>]Bancontact: Create'PaymentMethodOptionsBancontact option
        ///contains details about the Boleto payment method options.
        [<Config.Form>]Boleto: Create'PaymentMethodOptionsBoleto option
        ///contains details about the Card payment method options.
        [<Config.Form>]Card: Create'PaymentMethodOptionsCard option
        ///contains details about the Cashapp Pay payment method options.
        [<Config.Form>]Cashapp: Create'PaymentMethodOptionsCashapp option
        ///contains details about the Customer Balance payment method options.
        [<Config.Form>]CustomerBalance: Create'PaymentMethodOptionsCustomerBalance option
        ///contains details about the EPS payment method options.
        [<Config.Form>]Eps: Create'PaymentMethodOptionsEps option
        ///contains details about the FPX payment method options.
        [<Config.Form>]Fpx: Create'PaymentMethodOptionsFpx option
        ///contains details about the Giropay payment method options.
        [<Config.Form>]Giropay: Create'PaymentMethodOptionsGiropay option
        ///contains details about the Grabpay payment method options.
        [<Config.Form>]Grabpay: Create'PaymentMethodOptionsGrabpay option
        ///contains details about the Ideal payment method options.
        [<Config.Form>]Ideal: Create'PaymentMethodOptionsIdeal option
        ///contains details about the Klarna payment method options.
        [<Config.Form>]Klarna: Create'PaymentMethodOptionsKlarna option
        ///contains details about the Konbini payment method options.
        [<Config.Form>]Konbini: Create'PaymentMethodOptionsKonbini option
        ///contains details about the Link payment method options.
        [<Config.Form>]Link: Create'PaymentMethodOptionsLink option
        ///contains details about the OXXO payment method options.
        [<Config.Form>]Oxxo: Create'PaymentMethodOptionsOxxo option
        ///contains details about the P24 payment method options.
        [<Config.Form>]P24: Create'PaymentMethodOptionsP24 option
        ///contains details about the PayNow payment method options.
        [<Config.Form>]Paynow: Create'PaymentMethodOptionsPaynow option
        ///contains details about the PayPal payment method options.
        [<Config.Form>]Paypal: Create'PaymentMethodOptionsPaypal option
        ///contains details about the Pix payment method options.
        [<Config.Form>]Pix: Create'PaymentMethodOptionsPix option
        ///contains details about the Sepa Debit payment method options.
        [<Config.Form>]SepaDebit: Create'PaymentMethodOptionsSepaDebit option
        ///contains details about the Sofort payment method options.
        [<Config.Form>]Sofort: Create'PaymentMethodOptionsSofort option
        ///contains details about the Us Bank Account payment method options.
        [<Config.Form>]UsBankAccount: Create'PaymentMethodOptionsUsBankAccount option
        ///contains details about the WeChat Pay payment method options.
        [<Config.Form>]WechatPay: Create'PaymentMethodOptionsWechatPay option
    }
    with
        static member New(?acssDebit: Create'PaymentMethodOptionsAcssDebit, ?sofort: Create'PaymentMethodOptionsSofort, ?sepaDebit: Create'PaymentMethodOptionsSepaDebit, ?pix: Create'PaymentMethodOptionsPix, ?paypal: Create'PaymentMethodOptionsPaypal, ?paynow: Create'PaymentMethodOptionsPaynow, ?p24: Create'PaymentMethodOptionsP24, ?oxxo: Create'PaymentMethodOptionsOxxo, ?link: Create'PaymentMethodOptionsLink, ?konbini: Create'PaymentMethodOptionsKonbini, ?klarna: Create'PaymentMethodOptionsKlarna, ?ideal: Create'PaymentMethodOptionsIdeal, ?grabpay: Create'PaymentMethodOptionsGrabpay, ?giropay: Create'PaymentMethodOptionsGiropay, ?fpx: Create'PaymentMethodOptionsFpx, ?eps: Create'PaymentMethodOptionsEps, ?customerBalance: Create'PaymentMethodOptionsCustomerBalance, ?cashapp: Create'PaymentMethodOptionsCashapp, ?card: Create'PaymentMethodOptionsCard, ?boleto: Create'PaymentMethodOptionsBoleto, ?bancontact: Create'PaymentMethodOptionsBancontact, ?bacsDebit: Create'PaymentMethodOptionsBacsDebit, ?auBecsDebit: Create'PaymentMethodOptionsAuBecsDebit, ?alipay: Create'PaymentMethodOptionsAlipay, ?afterpayClearpay: Create'PaymentMethodOptionsAfterpayClearpay, ?affirm: Create'PaymentMethodOptionsAffirm, ?usBankAccount: Create'PaymentMethodOptionsUsBankAccount, ?wechatPay: Create'PaymentMethodOptionsWechatPay) =
            {
                AcssDebit = acssDebit
                Affirm = affirm
                AfterpayClearpay = afterpayClearpay
                Alipay = alipay
                AuBecsDebit = auBecsDebit
                BacsDebit = bacsDebit
                Bancontact = bancontact
                Boleto = boleto
                Card = card
                Cashapp = cashapp
                CustomerBalance = customerBalance
                Eps = eps
                Fpx = fpx
                Giropay = giropay
                Grabpay = grabpay
                Ideal = ideal
                Klarna = klarna
                Konbini = konbini
                Link = link
                Oxxo = oxxo
                P24 = p24
                Paynow = paynow
                Paypal = paypal
                Pix = pix
                SepaDebit = sepaDebit
                Sofort = sofort
                UsBankAccount = usBankAccount
                WechatPay = wechatPay
            }

    type Create'PaymentMethodTypes =
    | AcssDebit
    | Affirm
    | AfterpayClearpay
    | Alipay
    | AuBecsDebit
    | BacsDebit
    | Bancontact
    | Blik
    | Boleto
    | Card
    | Cashapp
    | CustomerBalance
    | Eps
    | Fpx
    | Giropay
    | Grabpay
    | Ideal
    | Klarna
    | Konbini
    | Link
    | Oxxo
    | P24
    | Paynow
    | Paypal
    | Pix
    | Promptpay
    | SepaDebit
    | Sofort
    | UsBankAccount
    | WechatPay
    | Zip

    type Create'PhoneNumberCollection = {
        ///Set to `true` to enable phone number collection.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Create'SetupIntentData = {
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        [<Config.Form>]Description: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The Stripe account for which the setup is intended.
        [<Config.Form>]OnBehalfOf: string option
    }
    with
        static member New(?description: string, ?metadata: Map<string, string>, ?onBehalfOf: string) =
            {
                Description = description
                Metadata = metadata
                OnBehalfOf = onBehalfOf
            }

    type Create'ShippingAddressCollectionAllowedCountries =
    | [<JsonUnionCase("AC")>] AC
    | [<JsonUnionCase("AD")>] AD
    | [<JsonUnionCase("AE")>] AE
    | [<JsonUnionCase("AF")>] AF
    | [<JsonUnionCase("AG")>] AG
    | [<JsonUnionCase("AI")>] AI
    | [<JsonUnionCase("AL")>] AL
    | [<JsonUnionCase("AM")>] AM
    | [<JsonUnionCase("AO")>] AO
    | [<JsonUnionCase("AQ")>] AQ
    | [<JsonUnionCase("AR")>] AR
    | [<JsonUnionCase("AT")>] AT
    | [<JsonUnionCase("AU")>] AU
    | [<JsonUnionCase("AW")>] AW
    | [<JsonUnionCase("AX")>] AX
    | [<JsonUnionCase("AZ")>] AZ
    | [<JsonUnionCase("BA")>] BA
    | [<JsonUnionCase("BB")>] BB
    | [<JsonUnionCase("BD")>] BD
    | [<JsonUnionCase("BE")>] BE
    | [<JsonUnionCase("BF")>] BF
    | [<JsonUnionCase("BG")>] BG
    | [<JsonUnionCase("BH")>] BH
    | [<JsonUnionCase("BI")>] BI
    | [<JsonUnionCase("BJ")>] BJ
    | [<JsonUnionCase("BL")>] BL
    | [<JsonUnionCase("BM")>] BM
    | [<JsonUnionCase("BN")>] BN
    | [<JsonUnionCase("BO")>] BO
    | [<JsonUnionCase("BQ")>] BQ
    | [<JsonUnionCase("BR")>] BR
    | [<JsonUnionCase("BS")>] BS
    | [<JsonUnionCase("BT")>] BT
    | [<JsonUnionCase("BV")>] BV
    | [<JsonUnionCase("BW")>] BW
    | [<JsonUnionCase("BY")>] BY
    | [<JsonUnionCase("BZ")>] BZ
    | [<JsonUnionCase("CA")>] CA
    | [<JsonUnionCase("CD")>] CD
    | [<JsonUnionCase("CF")>] CF
    | [<JsonUnionCase("CG")>] CG
    | [<JsonUnionCase("CH")>] CH
    | [<JsonUnionCase("CI")>] CI
    | [<JsonUnionCase("CK")>] CK
    | [<JsonUnionCase("CL")>] CL
    | [<JsonUnionCase("CM")>] CM
    | [<JsonUnionCase("CN")>] CN
    | [<JsonUnionCase("CO")>] CO
    | [<JsonUnionCase("CR")>] CR
    | [<JsonUnionCase("CV")>] CV
    | [<JsonUnionCase("CW")>] CW
    | [<JsonUnionCase("CY")>] CY
    | [<JsonUnionCase("CZ")>] CZ
    | [<JsonUnionCase("DE")>] DE
    | [<JsonUnionCase("DJ")>] DJ
    | [<JsonUnionCase("DK")>] DK
    | [<JsonUnionCase("DM")>] DM
    | [<JsonUnionCase("DO")>] DO
    | [<JsonUnionCase("DZ")>] DZ
    | [<JsonUnionCase("EC")>] EC
    | [<JsonUnionCase("EE")>] EE
    | [<JsonUnionCase("EG")>] EG
    | [<JsonUnionCase("EH")>] EH
    | [<JsonUnionCase("ER")>] ER
    | [<JsonUnionCase("ES")>] ES
    | [<JsonUnionCase("ET")>] ET
    | [<JsonUnionCase("FI")>] FI
    | [<JsonUnionCase("FJ")>] FJ
    | [<JsonUnionCase("FK")>] FK
    | [<JsonUnionCase("FO")>] FO
    | [<JsonUnionCase("FR")>] FR
    | [<JsonUnionCase("GA")>] GA
    | [<JsonUnionCase("GB")>] GB
    | [<JsonUnionCase("GD")>] GD
    | [<JsonUnionCase("GE")>] GE
    | [<JsonUnionCase("GF")>] GF
    | [<JsonUnionCase("GG")>] GG
    | [<JsonUnionCase("GH")>] GH
    | [<JsonUnionCase("GI")>] GI
    | [<JsonUnionCase("GL")>] GL
    | [<JsonUnionCase("GM")>] GM
    | [<JsonUnionCase("GN")>] GN
    | [<JsonUnionCase("GP")>] GP
    | [<JsonUnionCase("GQ")>] GQ
    | [<JsonUnionCase("GR")>] GR
    | [<JsonUnionCase("GS")>] GS
    | [<JsonUnionCase("GT")>] GT
    | [<JsonUnionCase("GU")>] GU
    | [<JsonUnionCase("GW")>] GW
    | [<JsonUnionCase("GY")>] GY
    | [<JsonUnionCase("HK")>] HK
    | [<JsonUnionCase("HN")>] HN
    | [<JsonUnionCase("HR")>] HR
    | [<JsonUnionCase("HT")>] HT
    | [<JsonUnionCase("HU")>] HU
    | [<JsonUnionCase("ID")>] ID
    | [<JsonUnionCase("IE")>] IE
    | [<JsonUnionCase("IL")>] IL
    | [<JsonUnionCase("IM")>] IM
    | [<JsonUnionCase("IN")>] IN
    | [<JsonUnionCase("IO")>] IO
    | [<JsonUnionCase("IQ")>] IQ
    | [<JsonUnionCase("IS")>] IS
    | [<JsonUnionCase("IT")>] IT
    | [<JsonUnionCase("JE")>] JE
    | [<JsonUnionCase("JM")>] JM
    | [<JsonUnionCase("JO")>] JO
    | [<JsonUnionCase("JP")>] JP
    | [<JsonUnionCase("KE")>] KE
    | [<JsonUnionCase("KG")>] KG
    | [<JsonUnionCase("KH")>] KH
    | [<JsonUnionCase("KI")>] KI
    | [<JsonUnionCase("KM")>] KM
    | [<JsonUnionCase("KN")>] KN
    | [<JsonUnionCase("KR")>] KR
    | [<JsonUnionCase("KW")>] KW
    | [<JsonUnionCase("KY")>] KY
    | [<JsonUnionCase("KZ")>] KZ
    | [<JsonUnionCase("LA")>] LA
    | [<JsonUnionCase("LB")>] LB
    | [<JsonUnionCase("LC")>] LC
    | [<JsonUnionCase("LI")>] LI
    | [<JsonUnionCase("LK")>] LK
    | [<JsonUnionCase("LR")>] LR
    | [<JsonUnionCase("LS")>] LS
    | [<JsonUnionCase("LT")>] LT
    | [<JsonUnionCase("LU")>] LU
    | [<JsonUnionCase("LV")>] LV
    | [<JsonUnionCase("LY")>] LY
    | [<JsonUnionCase("MA")>] MA
    | [<JsonUnionCase("MC")>] MC
    | [<JsonUnionCase("MD")>] MD
    | [<JsonUnionCase("ME")>] ME
    | [<JsonUnionCase("MF")>] MF
    | [<JsonUnionCase("MG")>] MG
    | [<JsonUnionCase("MK")>] MK
    | [<JsonUnionCase("ML")>] ML
    | [<JsonUnionCase("MM")>] MM
    | [<JsonUnionCase("MN")>] MN
    | [<JsonUnionCase("MO")>] MO
    | [<JsonUnionCase("MQ")>] MQ
    | [<JsonUnionCase("MR")>] MR
    | [<JsonUnionCase("MS")>] MS
    | [<JsonUnionCase("MT")>] MT
    | [<JsonUnionCase("MU")>] MU
    | [<JsonUnionCase("MV")>] MV
    | [<JsonUnionCase("MW")>] MW
    | [<JsonUnionCase("MX")>] MX
    | [<JsonUnionCase("MY")>] MY
    | [<JsonUnionCase("MZ")>] MZ
    | [<JsonUnionCase("NA")>] NA
    | [<JsonUnionCase("NC")>] NC
    | [<JsonUnionCase("NE")>] NE
    | [<JsonUnionCase("NG")>] NG
    | [<JsonUnionCase("NI")>] NI
    | [<JsonUnionCase("NL")>] NL
    | [<JsonUnionCase("NO")>] NO
    | [<JsonUnionCase("NP")>] NP
    | [<JsonUnionCase("NR")>] NR
    | [<JsonUnionCase("NU")>] NU
    | [<JsonUnionCase("NZ")>] NZ
    | [<JsonUnionCase("OM")>] OM
    | [<JsonUnionCase("PA")>] PA
    | [<JsonUnionCase("PE")>] PE
    | [<JsonUnionCase("PF")>] PF
    | [<JsonUnionCase("PG")>] PG
    | [<JsonUnionCase("PH")>] PH
    | [<JsonUnionCase("PK")>] PK
    | [<JsonUnionCase("PL")>] PL
    | [<JsonUnionCase("PM")>] PM
    | [<JsonUnionCase("PN")>] PN
    | [<JsonUnionCase("PR")>] PR
    | [<JsonUnionCase("PS")>] PS
    | [<JsonUnionCase("PT")>] PT
    | [<JsonUnionCase("PY")>] PY
    | [<JsonUnionCase("QA")>] QA
    | [<JsonUnionCase("RE")>] RE
    | [<JsonUnionCase("RO")>] RO
    | [<JsonUnionCase("RS")>] RS
    | [<JsonUnionCase("RU")>] RU
    | [<JsonUnionCase("RW")>] RW
    | [<JsonUnionCase("SA")>] SA
    | [<JsonUnionCase("SB")>] SB
    | [<JsonUnionCase("SC")>] SC
    | [<JsonUnionCase("SE")>] SE
    | [<JsonUnionCase("SG")>] SG
    | [<JsonUnionCase("SH")>] SH
    | [<JsonUnionCase("SI")>] SI
    | [<JsonUnionCase("SJ")>] SJ
    | [<JsonUnionCase("SK")>] SK
    | [<JsonUnionCase("SL")>] SL
    | [<JsonUnionCase("SM")>] SM
    | [<JsonUnionCase("SN")>] SN
    | [<JsonUnionCase("SO")>] SO
    | [<JsonUnionCase("SR")>] SR
    | [<JsonUnionCase("SS")>] SS
    | [<JsonUnionCase("ST")>] ST
    | [<JsonUnionCase("SV")>] SV
    | [<JsonUnionCase("SX")>] SX
    | [<JsonUnionCase("SZ")>] SZ
    | [<JsonUnionCase("TA")>] TA
    | [<JsonUnionCase("TC")>] TC
    | [<JsonUnionCase("TD")>] TD
    | [<JsonUnionCase("TF")>] TF
    | [<JsonUnionCase("TG")>] TG
    | [<JsonUnionCase("TH")>] TH
    | [<JsonUnionCase("TJ")>] TJ
    | [<JsonUnionCase("TK")>] TK
    | [<JsonUnionCase("TL")>] TL
    | [<JsonUnionCase("TM")>] TM
    | [<JsonUnionCase("TN")>] TN
    | [<JsonUnionCase("TO")>] TO
    | [<JsonUnionCase("TR")>] TR
    | [<JsonUnionCase("TT")>] TT
    | [<JsonUnionCase("TV")>] TV
    | [<JsonUnionCase("TW")>] TW
    | [<JsonUnionCase("TZ")>] TZ
    | [<JsonUnionCase("UA")>] UA
    | [<JsonUnionCase("UG")>] UG
    | [<JsonUnionCase("US")>] US
    | [<JsonUnionCase("UY")>] UY
    | [<JsonUnionCase("UZ")>] UZ
    | [<JsonUnionCase("VA")>] VA
    | [<JsonUnionCase("VC")>] VC
    | [<JsonUnionCase("VE")>] VE
    | [<JsonUnionCase("VG")>] VG
    | [<JsonUnionCase("VN")>] VN
    | [<JsonUnionCase("VU")>] VU
    | [<JsonUnionCase("WF")>] WF
    | [<JsonUnionCase("WS")>] WS
    | [<JsonUnionCase("XK")>] XK
    | [<JsonUnionCase("YE")>] YE
    | [<JsonUnionCase("YT")>] YT
    | [<JsonUnionCase("ZA")>] ZA
    | [<JsonUnionCase("ZM")>] ZM
    | [<JsonUnionCase("ZW")>] ZW
    | [<JsonUnionCase("ZZ")>] ZZ

    type Create'ShippingAddressCollection = {
        ///An array of two-letter ISO country codes representing which countries Checkout should provide as options for
        ///shipping locations. Unsupported country codes: `AS, CX, CC, CU, HM, IR, KP, MH, FM, NF, MP, PW, SD, SY, UM, VI`.
        [<Config.Form>]AllowedCountries: Create'ShippingAddressCollectionAllowedCountries list option
    }
    with
        static member New(?allowedCountries: Create'ShippingAddressCollectionAllowedCountries list) =
            {
                AllowedCountries = allowedCountries
            }

    type Create'ShippingOptionsShippingRateDataDeliveryEstimateMaximumUnit =
    | BusinessDay
    | Day
    | Hour
    | Month
    | Week

    type Create'ShippingOptionsShippingRateDataDeliveryEstimateMaximum = {
        ///A unit of time.
        [<Config.Form>]Unit: Create'ShippingOptionsShippingRateDataDeliveryEstimateMaximumUnit option
        ///Must be greater than 0.
        [<Config.Form>]Value: int option
    }
    with
        static member New(?unit: Create'ShippingOptionsShippingRateDataDeliveryEstimateMaximumUnit, ?value: int) =
            {
                Unit = unit
                Value = value
            }

    type Create'ShippingOptionsShippingRateDataDeliveryEstimateMinimumUnit =
    | BusinessDay
    | Day
    | Hour
    | Month
    | Week

    type Create'ShippingOptionsShippingRateDataDeliveryEstimateMinimum = {
        ///A unit of time.
        [<Config.Form>]Unit: Create'ShippingOptionsShippingRateDataDeliveryEstimateMinimumUnit option
        ///Must be greater than 0.
        [<Config.Form>]Value: int option
    }
    with
        static member New(?unit: Create'ShippingOptionsShippingRateDataDeliveryEstimateMinimumUnit, ?value: int) =
            {
                Unit = unit
                Value = value
            }

    type Create'ShippingOptionsShippingRateDataDeliveryEstimate = {
        ///The upper bound of the estimated range. If empty, represents no upper bound i.e., infinite.
        [<Config.Form>]Maximum: Create'ShippingOptionsShippingRateDataDeliveryEstimateMaximum option
        ///The lower bound of the estimated range. If empty, represents no lower bound.
        [<Config.Form>]Minimum: Create'ShippingOptionsShippingRateDataDeliveryEstimateMinimum option
    }
    with
        static member New(?maximum: Create'ShippingOptionsShippingRateDataDeliveryEstimateMaximum, ?minimum: Create'ShippingOptionsShippingRateDataDeliveryEstimateMinimum) =
            {
                Maximum = maximum
                Minimum = minimum
            }

    type Create'ShippingOptionsShippingRateDataFixedAmount = {
        ///A non-negative integer in cents representing how much to charge.
        [<Config.Form>]Amount: int option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///Shipping rates defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]CurrencyOptions: Map<string, string> option
    }
    with
        static member New(?amount: int, ?currency: string, ?currencyOptions: Map<string, string>) =
            {
                Amount = amount
                Currency = currency
                CurrencyOptions = currencyOptions
            }

    type Create'ShippingOptionsShippingRateDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Create'ShippingOptionsShippingRateDataType =
    | FixedAmount

    type Create'ShippingOptionsShippingRateData = {
        ///The estimated range for how long shipping will take, meant to be displayable to the customer. This will appear on CheckoutSessions.
        [<Config.Form>]DeliveryEstimate: Create'ShippingOptionsShippingRateDataDeliveryEstimate option
        ///The name of the shipping rate, meant to be displayable to the customer. This will appear on CheckoutSessions.
        [<Config.Form>]DisplayName: string option
        ///Describes a fixed amount to charge for shipping. Must be present if type is `fixed_amount`.
        [<Config.Form>]FixedAmount: Create'ShippingOptionsShippingRateDataFixedAmount option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Specifies whether the rate is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`.
        [<Config.Form>]TaxBehavior: Create'ShippingOptionsShippingRateDataTaxBehavior option
        ///A [tax code](https://stripe.com/docs/tax/tax-categories) ID. The Shipping tax code is `txcd_92010001`.
        [<Config.Form>]TaxCode: string option
        ///The type of calculation to use on the shipping rate. Can only be `fixed_amount` for now.
        [<Config.Form>]Type: Create'ShippingOptionsShippingRateDataType option
    }
    with
        static member New(?deliveryEstimate: Create'ShippingOptionsShippingRateDataDeliveryEstimate, ?displayName: string, ?fixedAmount: Create'ShippingOptionsShippingRateDataFixedAmount, ?metadata: Map<string, string>, ?taxBehavior: Create'ShippingOptionsShippingRateDataTaxBehavior, ?taxCode: string, ?type': Create'ShippingOptionsShippingRateDataType) =
            {
                DeliveryEstimate = deliveryEstimate
                DisplayName = displayName
                FixedAmount = fixedAmount
                Metadata = metadata
                TaxBehavior = taxBehavior
                TaxCode = taxCode
                Type = type'
            }

    type Create'ShippingOptions = {
        ///The ID of the Shipping Rate to use for this shipping option.
        [<Config.Form>]ShippingRate: string option
        ///Parameters to be passed to Shipping Rate creation for this shipping option
        [<Config.Form>]ShippingRateData: Create'ShippingOptionsShippingRateData option
    }
    with
        static member New(?shippingRate: string, ?shippingRateData: Create'ShippingOptionsShippingRateData) =
            {
                ShippingRate = shippingRate
                ShippingRateData = shippingRateData
            }

    type Create'SubscriptionDataTransferData = {
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination.
        [<Config.Form>]AmountPercent: decimal option
        ///ID of an existing, connected Stripe account.
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amountPercent: decimal, ?destination: string) =
            {
                AmountPercent = amountPercent
                Destination = destination
            }

    type Create'SubscriptionDataTrialSettingsEndBehaviorMissingPaymentMethod =
    | Cancel
    | CreateInvoice
    | Pause

    type Create'SubscriptionDataTrialSettingsEndBehavior = {
        ///Indicates how the subscription should change when the trial ends if the user did not provide a payment method.
        [<Config.Form>]MissingPaymentMethod: Create'SubscriptionDataTrialSettingsEndBehaviorMissingPaymentMethod option
    }
    with
        static member New(?missingPaymentMethod: Create'SubscriptionDataTrialSettingsEndBehaviorMissingPaymentMethod) =
            {
                MissingPaymentMethod = missingPaymentMethod
            }

    type Create'SubscriptionDataTrialSettings = {
        ///Defines how the subscription should behave when the user's free trial ends.
        [<Config.Form>]EndBehavior: Create'SubscriptionDataTrialSettingsEndBehavior option
    }
    with
        static member New(?endBehavior: Create'SubscriptionDataTrialSettingsEndBehavior) =
            {
                EndBehavior = endBehavior
            }

    type Create'SubscriptionDataProrationBehavior =
    | CreateProrations
    | None'

    type Create'SubscriptionData = {
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. To use an application fee percent, the request must be made on behalf of another account, using the `Stripe-Account` header or an OAuth key. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).
        [<Config.Form>]ApplicationFeePercent: decimal option
        ///A future timestamp to anchor the subscription's billing cycle for new subscriptions.
        [<Config.Form>]BillingCycleAnchor: DateTime option
        ///The tax rates that will apply to any subscription item that does not have
        ///`tax_rates` set. Invoices created will have their `default_tax_rates` populated
        ///from the subscription.
        [<Config.Form>]DefaultTaxRates: string list option
        ///The subscription's description, meant to be displayable to the customer.
        ///Use this field to optionally store an explanation of the subscription
        ///for rendering in the [customer portal](https://stripe.com/docs/customer-management).
        [<Config.Form>]Description: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The account on behalf of which to charge, for each of the subscription's invoices.
        [<Config.Form>]OnBehalfOf: string option
        ///Determines how to handle prorations resulting from the `billing_cycle_anchor`. If no value is passed, the default is `create_prorations`.
        [<Config.Form>]ProrationBehavior: Create'SubscriptionDataProrationBehavior option
        ///If specified, the funds from the subscription's invoices will be transferred to the destination and the ID of the resulting transfers will be found on the resulting charges.
        [<Config.Form>]TransferData: Create'SubscriptionDataTransferData option
        ///Unix timestamp representing the end of the trial period the customer
        ///will get before being charged for the first time. Has to be at least
        ///48 hours in the future.
        [<Config.Form>]TrialEnd: DateTime option
        ///Integer representing the number of trial period days before the
        ///customer is charged for the first time. Has to be at least 1.
        [<Config.Form>]TrialPeriodDays: int option
        ///Settings related to subscription trials.
        [<Config.Form>]TrialSettings: Create'SubscriptionDataTrialSettings option
    }
    with
        static member New(?applicationFeePercent: decimal, ?billingCycleAnchor: DateTime, ?defaultTaxRates: string list, ?description: string, ?metadata: Map<string, string>, ?onBehalfOf: string, ?prorationBehavior: Create'SubscriptionDataProrationBehavior, ?transferData: Create'SubscriptionDataTransferData, ?trialEnd: DateTime, ?trialPeriodDays: int, ?trialSettings: Create'SubscriptionDataTrialSettings) =
            {
                ApplicationFeePercent = applicationFeePercent
                BillingCycleAnchor = billingCycleAnchor
                DefaultTaxRates = defaultTaxRates
                Description = description
                Metadata = metadata
                OnBehalfOf = onBehalfOf
                ProrationBehavior = prorationBehavior
                TransferData = transferData
                TrialEnd = trialEnd
                TrialPeriodDays = trialPeriodDays
                TrialSettings = trialSettings
            }

    type Create'TaxIdCollection = {
        ///Set to true to enable Tax ID collection.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Create'BillingAddressCollection =
    | Auto
    | Required

    type Create'CustomerCreation =
    | Always
    | IfRequired

    type Create'Locale =
    | Auto
    | Bg
    | Cs
    | Da
    | De
    | El
    | En
    | [<JsonUnionCase("en-GB")>] EnGB
    | Es
    | [<JsonUnionCase("es-419")>] Es419
    | Et
    | Fi
    | Fil
    | Fr
    | [<JsonUnionCase("fr-CA")>] FrCA
    | Hr
    | Hu
    | Id
    | It
    | Ja
    | Ko
    | Lt
    | Lv
    | Ms
    | Mt
    | Nb
    | Nl
    | Pl
    | Pt
    | [<JsonUnionCase("pt-BR")>] PtBR
    | Ro
    | Ru
    | Sk
    | Sl
    | Sv
    | Th
    | Tr
    | Vi
    | Zh
    | [<JsonUnionCase("zh-HK")>] ZhHK
    | [<JsonUnionCase("zh-TW")>] ZhTW

    type Create'Mode =
    | Payment
    | Setup
    | Subscription

    type Create'PaymentMethodCollection =
    | Always
    | IfRequired

    type Create'SubmitType =
    | Auto
    | Book
    | Donate
    | Pay

    type CreateOptions = {
        ///Configure actions after a Checkout Session has expired.
        [<Config.Form>]AfterExpiration: Create'AfterExpiration option
        ///Enables user redeemable promotion codes.
        [<Config.Form>]AllowPromotionCodes: bool option
        ///Settings for automatic tax lookup for this session and resulting payments, invoices, and subscriptions.
        [<Config.Form>]AutomaticTax: Create'AutomaticTax option
        ///Specify whether Checkout should collect the customer's billing address.
        [<Config.Form>]BillingAddressCollection: Create'BillingAddressCollection option
        ///If set, Checkout displays a back button and customers will be directed to this URL if they decide to cancel payment and return to your website.
        [<Config.Form>]CancelUrl: string option
        ///A unique string to reference the Checkout Session. This can be a
        ///customer ID, a cart ID, or similar, and can be used to reconcile the
        ///session with your internal systems.
        [<Config.Form>]ClientReferenceId: string option
        ///Configure fields for the Checkout Session to gather active consent from customers.
        [<Config.Form>]ConsentCollection: Create'ConsentCollection option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///Collect additional information from your customer using custom fields. Up to 2 fields are supported.
        [<Config.Form>]CustomFields: Create'CustomFields list option
        ///Display additional text for your customers using custom text.
        [<Config.Form>]CustomText: Create'CustomText option
        ///ID of an existing Customer, if one exists. In `payment` mode, the customer’s most recent card
        ///payment method will be used to prefill the email, name, card details, and billing address
        ///on the Checkout page. In `subscription` mode, the customer’s [default payment method](https://stripe.com/docs/api/customers/update#update_customer-invoice_settings-default_payment_method)
        ///will be used if it’s a card, and otherwise the most recent card will be used. A valid billing address, billing name and billing email are required on the payment method for Checkout to prefill the customer's card details.
        ///If the Customer already has a valid [email](https://stripe.com/docs/api/customers/object#customer_object-email) set, the email will be prefilled and not editable in Checkout.
        ///If the Customer does not have a valid `email`, Checkout will set the email entered during the session on the Customer.
        ///If blank for Checkout Sessions in `subscription` mode or with `customer_creation` set as `always` in `payment` mode, Checkout will create a new Customer object based on information provided during the payment flow.
        ///You can set [`payment_intent_data.setup_future_usage`](https://stripe.com/docs/api/checkout/sessions/create#create_checkout_session-payment_intent_data-setup_future_usage) to have Checkout automatically attach the payment method to the Customer you pass in for future reuse.
        [<Config.Form>]Customer: string option
        ///Configure whether a Checkout Session creates a [Customer](https://stripe.com/docs/api/customers) during Session confirmation.
        ///When a Customer is not created, you can still retrieve email, address, and other customer data entered in Checkout
        ///with [customer_details](https://stripe.com/docs/api/checkout/sessions/object#checkout_session_object-customer_details).
        ///Sessions that don't create Customers instead are grouped by [guest customers](https://stripe.com/docs/payments/checkout/guest-customers)
        ///in the Dashboard. Promotion codes limited to first time customers will return invalid for these Sessions.
        ///Can only be set in `payment` and `setup` mode.
        [<Config.Form>]CustomerCreation: Create'CustomerCreation option
        ///If provided, this value will be used when the Customer object is created.
        ///If not provided, customers will be asked to enter their email address.
        ///Use this parameter to prefill customer data if you already have an email
        ///on file. To access information about the customer once a session is
        ///complete, use the `customer` field.
        [<Config.Form>]CustomerEmail: string option
        ///Controls what fields on Customer can be updated by the Checkout Session. Can only be provided when `customer` is provided.
        [<Config.Form>]CustomerUpdate: Create'CustomerUpdate option
        ///The coupon or promotion code to apply to this Session. Currently, only up to one may be specified.
        [<Config.Form>]Discounts: Create'Discounts list option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The Epoch time in seconds at which the Checkout Session will expire. It can be anywhere from 30 minutes to 24 hours after Checkout Session creation. By default, this value is 24 hours from creation.
        [<Config.Form>]ExpiresAt: DateTime option
        ///Generate a post-purchase Invoice for one-time payments.
        [<Config.Form>]InvoiceCreation: Create'InvoiceCreation option
        ///A list of items the customer is purchasing. Use this parameter to pass one-time or recurring [Prices](https://stripe.com/docs/api/prices).
        ///For `payment` mode, there is a maximum of 100 line items, however it is recommended to consolidate line items if there are more than a few dozen.
        ///For `subscription` mode, there is a maximum of 20 line items with recurring Prices and 20 line items with one-time Prices. Line items with one-time Prices will be on the initial invoice only.
        [<Config.Form>]LineItems: Create'LineItems list option
        ///The IETF language tag of the locale Checkout is displayed in. If blank or `auto`, the browser's locale is used.
        [<Config.Form>]Locale: Create'Locale option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The mode of the Checkout Session. Pass `subscription` if the Checkout Session includes at least one recurring item.
        [<Config.Form>]Mode: Create'Mode option
        ///A subset of parameters to be passed to PaymentIntent creation for Checkout Sessions in `payment` mode.
        [<Config.Form>]PaymentIntentData: Create'PaymentIntentData option
        ///Specify whether Checkout should collect a payment method. When set to `if_required`, Checkout will not collect a payment method when the total due for the session is 0.
        ///This may occur if the Checkout Session includes a free trial or a discount.
        ///Can only be set in `subscription` mode.
        ///If you'd like information on how to collect a payment method outside of Checkout, read the guide on configuring [subscriptions with a free trial](https://stripe.com/docs/payments/checkout/free-trials).
        [<Config.Form>]PaymentMethodCollection: Create'PaymentMethodCollection option
        ///Payment-method-specific configuration.
        [<Config.Form>]PaymentMethodOptions: Create'PaymentMethodOptions option
        ///A list of the types of payment methods (e.g., `card`) this Checkout Session can accept.
        ///In `payment` and `subscription` mode, you can omit this attribute to manage your payment methods from the [Stripe Dashboard](https://dashboard.stripe.com/settings/payment_methods).
        ///It is required in `setup` mode.
        ///Read more about the supported payment methods and their requirements in our [payment
        ///method details guide](/docs/payments/checkout/payment-methods).
        ///If multiple payment methods are passed, Checkout will dynamically reorder them to
        ///prioritize the most relevant payment methods based on the customer's location and
        ///other characteristics.
        [<Config.Form>]PaymentMethodTypes: Create'PaymentMethodTypes list option
        ///Controls phone number collection settings for the session.
        ///We recommend that you review your privacy policy and check with your legal contacts
        ///before using this feature. Learn more about [collecting phone numbers with Checkout](https://stripe.com/docs/payments/checkout/phone-numbers).
        [<Config.Form>]PhoneNumberCollection: Create'PhoneNumberCollection option
        ///A subset of parameters to be passed to SetupIntent creation for Checkout Sessions in `setup` mode.
        [<Config.Form>]SetupIntentData: Create'SetupIntentData option
        ///When set, provides configuration for Checkout to collect a shipping address from a customer.
        [<Config.Form>]ShippingAddressCollection: Create'ShippingAddressCollection option
        ///The shipping rate options to apply to this Session. Up to a maximum of 5.
        [<Config.Form>]ShippingOptions: Create'ShippingOptions list option
        ///Describes the type of transaction being performed by Checkout in order to customize
        ///relevant text on the page, such as the submit button. `submit_type` can only be
        ///specified on Checkout Sessions in `payment` mode, but not Checkout Sessions
        ///in `subscription` or `setup` mode.
        [<Config.Form>]SubmitType: Create'SubmitType option
        ///A subset of parameters to be passed to subscription creation for Checkout Sessions in `subscription` mode.
        [<Config.Form>]SubscriptionData: Create'SubscriptionData option
        ///The URL to which Stripe should send customers when payment or setup
        ///is complete.
        ///If you’d like to use information from the successful Checkout Session on your page,
        ///read the guide on [customizing your success page](https://stripe.com/docs/payments/checkout/custom-success-page).
        [<Config.Form>]SuccessUrl: string
        ///Controls tax ID collection settings for the session.
        [<Config.Form>]TaxIdCollection: Create'TaxIdCollection option
    }
    with
        static member New(successUrl: string, ?lineItems: Create'LineItems list, ?locale: Create'Locale, ?metadata: Map<string, string>, ?mode: Create'Mode, ?paymentIntentData: Create'PaymentIntentData, ?paymentMethodCollection: Create'PaymentMethodCollection, ?invoiceCreation: Create'InvoiceCreation, ?paymentMethodOptions: Create'PaymentMethodOptions, ?phoneNumberCollection: Create'PhoneNumberCollection, ?setupIntentData: Create'SetupIntentData, ?shippingAddressCollection: Create'ShippingAddressCollection, ?shippingOptions: Create'ShippingOptions list, ?submitType: Create'SubmitType, ?subscriptionData: Create'SubscriptionData, ?paymentMethodTypes: Create'PaymentMethodTypes list, ?afterExpiration: Create'AfterExpiration, ?expiresAt: DateTime, ?discounts: Create'Discounts list, ?customerUpdate: Create'CustomerUpdate, ?customerEmail: string, ?customerCreation: Create'CustomerCreation, ?customer: string, ?customText: Create'CustomText, ?customFields: Create'CustomFields list, ?currency: string, ?consentCollection: Create'ConsentCollection, ?clientReferenceId: string, ?cancelUrl: string, ?billingAddressCollection: Create'BillingAddressCollection, ?automaticTax: Create'AutomaticTax, ?allowPromotionCodes: bool, ?expand: string list, ?taxIdCollection: Create'TaxIdCollection) =
            {
                AfterExpiration = afterExpiration
                AllowPromotionCodes = allowPromotionCodes
                AutomaticTax = automaticTax
                BillingAddressCollection = billingAddressCollection
                CancelUrl = cancelUrl
                ClientReferenceId = clientReferenceId
                ConsentCollection = consentCollection
                Currency = currency
                CustomFields = customFields
                CustomText = customText
                Customer = customer
                CustomerCreation = customerCreation
                CustomerEmail = customerEmail
                CustomerUpdate = customerUpdate
                Discounts = discounts
                Expand = expand
                ExpiresAt = expiresAt
                InvoiceCreation = invoiceCreation
                LineItems = lineItems
                Locale = locale
                Metadata = metadata
                Mode = mode
                PaymentIntentData = paymentIntentData
                PaymentMethodCollection = paymentMethodCollection
                PaymentMethodOptions = paymentMethodOptions
                PaymentMethodTypes = paymentMethodTypes
                PhoneNumberCollection = phoneNumberCollection
                SetupIntentData = setupIntentData
                ShippingAddressCollection = shippingAddressCollection
                ShippingOptions = shippingOptions
                SubmitType = submitType
                SubscriptionData = subscriptionData
                SuccessUrl = successUrl
                TaxIdCollection = taxIdCollection
            }

    ///<p>Creates a Session object.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/checkout/sessions"
        |> RestApi.postAsync<_, CheckoutSession> settings (Map.empty) options

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Session: string
    }
    with
        static member New(session: string, ?expand: string list) =
            {
                Expand = expand
                Session = session
            }

    ///<p>Retrieves a Session object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/checkout/sessions/{options.Session}"
        |> RestApi.getAsync<CheckoutSession> settings qs

module CheckoutSessionsExpire =

    type ExpireOptions = {
        [<Config.Path>]Session: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(session: string, ?expand: string list) =
            {
                Session = session
                Expand = expand
            }

    ///<p>A Session can be expired when it is in one of these statuses: <code>open</code> 
    ///After it expires, a customer can’t complete a Session and customers loading the Session see a message saying the Session is expired.</p>
    let Expire settings (options: ExpireOptions) =
        $"/v1/checkout/sessions/{options.Session}/expire"
        |> RestApi.postAsync<_, CheckoutSession> settings (Map.empty) options

module CheckoutSessionsLineItems =

    type ListLineItemsOptions = {
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        [<Config.Path>]Session: string
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(session: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Session = session
                StartingAfter = startingAfter
            }

    ///<p>When retrieving a Checkout Session, there is an includable <strong>line_items</strong> property containing the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p>
    let ListLineItems settings (options: ListLineItemsOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/checkout/sessions/{options.Session}/line_items"
        |> RestApi.getAsync<Item list> settings qs
