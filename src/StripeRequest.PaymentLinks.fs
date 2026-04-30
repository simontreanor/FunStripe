namespace FunStripe.StripeRequest

open FunStripe
open System.Text.Json.Serialization
open FunStripe.StripeModel
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
module PaymentLinks =

    type ListOptions = {
        ///<summary>Only return payment links that are active or inactive (e.g., pass `false` to list all inactive payment links).</summary>
        [<Config.Query>]Active: bool option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?active: bool, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Active = active
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<summary><p>Returns a list of your payment links.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("active", options.Active |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/payment_links"
        |> RestApi.getAsync<StripeList<PaymentLink>> settings qs

    type Create'AfterCompletionHostedConfirmation = {
        ///<summary>A custom message to display to the customer after the purchase is complete.</summary>
        [<Config.Form>]CustomMessage: string option
    }
    with
        static member New(?customMessage: string) =
            {
                CustomMessage = customMessage
            }

    type Create'AfterCompletionRedirect = {
        ///<summary>The URL the customer will be redirected to after the purchase is complete. You can embed `{CHECKOUT_SESSION_ID}` into the URL to have the `id` of the completed [checkout session](https://docs.stripe.com/api/checkout/sessions/object#checkout_session_object-id) included.</summary>
        [<Config.Form>]Url: string option
    }
    with
        static member New(?url: string) =
            {
                Url = url
            }

    type Create'AfterCompletionType =
    | HostedConfirmation
    | Redirect

    type Create'AfterCompletion = {
        ///<summary>Configuration when `type=hosted_confirmation`.</summary>
        [<Config.Form>]HostedConfirmation: Create'AfterCompletionHostedConfirmation option
        ///<summary>Configuration when `type=redirect`.</summary>
        [<Config.Form>]Redirect: Create'AfterCompletionRedirect option
        ///<summary>The specified behavior after the purchase is complete. Either `redirect` or `hosted_confirmation`.</summary>
        [<Config.Form>]Type: Create'AfterCompletionType option
    }
    with
        static member New(?hostedConfirmation: Create'AfterCompletionHostedConfirmation, ?redirect: Create'AfterCompletionRedirect, ?type': Create'AfterCompletionType) =
            {
                HostedConfirmation = hostedConfirmation
                Redirect = redirect
                Type = type'
            }

    type Create'AutomaticTaxLiabilityType =
    | Account
    | Self

    type Create'AutomaticTaxLiability = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Create'AutomaticTaxLiabilityType option
    }
    with
        static member New(?account: string, ?type': Create'AutomaticTaxLiabilityType) =
            {
                Account = account
                Type = type'
            }

    type Create'AutomaticTax = {
        ///<summary>Set to `true` to [calculate tax automatically](https://docs.stripe.com/tax) using the customer's location.
        ///Enabling this parameter causes the payment link to collect any billing address information necessary for tax calculation.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.</summary>
        [<Config.Form>]Liability: Create'AutomaticTaxLiability option
    }
    with
        static member New(?enabled: bool, ?liability: Create'AutomaticTaxLiability) =
            {
                Enabled = enabled
                Liability = liability
            }

    type Create'ConsentCollectionPaymentMethodReuseAgreementPosition =
    | Auto
    | Hidden

    type Create'ConsentCollectionPaymentMethodReuseAgreement = {
        ///<summary>Determines the position and visibility of the payment method reuse agreement in the UI. When set to `auto`, Stripe's
        ///defaults will be used. When set to `hidden`, the payment method reuse agreement text will always be hidden in the UI.</summary>
        [<Config.Form>]Position: Create'ConsentCollectionPaymentMethodReuseAgreementPosition option
    }
    with
        static member New(?position: Create'ConsentCollectionPaymentMethodReuseAgreementPosition) =
            {
                Position = position
            }

    type Create'ConsentCollectionPromotions =
    | Auto
    | None'

    type Create'ConsentCollectionTermsOfService =
    | None'
    | Required

    type Create'ConsentCollection = {
        ///<summary>Determines the display of payment method reuse agreement text in the UI. If set to `hidden`, it will hide legal text related to the reuse of a payment method.</summary>
        [<Config.Form>]PaymentMethodReuseAgreement: Create'ConsentCollectionPaymentMethodReuseAgreement option
        ///<summary>If set to `auto`, enables the collection of customer consent for promotional communications. The Checkout
        ///Session will determine whether to display an option to opt into promotional communication
        ///from the merchant depending on the customer's locale. Only available to US merchants.</summary>
        [<Config.Form>]Promotions: Create'ConsentCollectionPromotions option
        ///<summary>If set to `required`, it requires customers to check a terms of service checkbox before being able to pay.
        ///There must be a valid terms of service URL set in your [Dashboard settings](https://dashboard.stripe.com/settings/public).</summary>
        [<Config.Form>]TermsOfService: Create'ConsentCollectionTermsOfService option
    }
    with
        static member New(?paymentMethodReuseAgreement: Create'ConsentCollectionPaymentMethodReuseAgreement, ?promotions: Create'ConsentCollectionPromotions, ?termsOfService: Create'ConsentCollectionTermsOfService) =
            {
                PaymentMethodReuseAgreement = paymentMethodReuseAgreement
                Promotions = promotions
                TermsOfService = termsOfService
            }

    type Create'CustomFieldsDropdownOptions = {
        ///<summary>The label for the option, displayed to the customer. Up to 100 characters.</summary>
        [<Config.Form>]Label: string option
        ///<summary>The value for this option, not displayed to the customer, used by your integration to reconcile the option selected by the customer. Must be unique to this option, alphanumeric, and up to 100 characters.</summary>
        [<Config.Form>]Value: string option
    }
    with
        static member New(?label: string, ?value: string) =
            {
                Label = label
                Value = value
            }

    type Create'CustomFieldsDropdown = {
        ///<summary>The value that pre-fills the field on the payment page.Must match a `value` in the `options` array.</summary>
        [<Config.Form>]DefaultValue: string option
        ///<summary>The options available for the customer to select. Up to 200 options allowed.</summary>
        [<Config.Form>]Options: Create'CustomFieldsDropdownOptions list option
    }
    with
        static member New(?defaultValue: string, ?options: Create'CustomFieldsDropdownOptions list) =
            {
                DefaultValue = defaultValue
                Options = options
            }

    type Create'CustomFieldsLabelType =
    | Custom

    type Create'CustomFieldsLabel = {
        ///<summary>Custom text for the label, displayed to the customer. Up to 50 characters.</summary>
        [<Config.Form>]Custom: string option
        ///<summary>The type of the label.</summary>
        [<Config.Form>]Type: Create'CustomFieldsLabelType option
    }
    with
        static member New(?custom: string, ?type': Create'CustomFieldsLabelType) =
            {
                Custom = custom
                Type = type'
            }

    type Create'CustomFieldsNumeric = {
        ///<summary>The value that pre-fills the field on the payment page.</summary>
        [<Config.Form>]DefaultValue: string option
        ///<summary>The maximum character length constraint for the customer's input.</summary>
        [<Config.Form>]MaximumLength: int option
        ///<summary>The minimum character length requirement for the customer's input.</summary>
        [<Config.Form>]MinimumLength: int option
    }
    with
        static member New(?defaultValue: string, ?maximumLength: int, ?minimumLength: int) =
            {
                DefaultValue = defaultValue
                MaximumLength = maximumLength
                MinimumLength = minimumLength
            }

    type Create'CustomFieldsText = {
        ///<summary>The value that pre-fills the field on the payment page.</summary>
        [<Config.Form>]DefaultValue: string option
        ///<summary>The maximum character length constraint for the customer's input.</summary>
        [<Config.Form>]MaximumLength: int option
        ///<summary>The minimum character length requirement for the customer's input.</summary>
        [<Config.Form>]MinimumLength: int option
    }
    with
        static member New(?defaultValue: string, ?maximumLength: int, ?minimumLength: int) =
            {
                DefaultValue = defaultValue
                MaximumLength = maximumLength
                MinimumLength = minimumLength
            }

    type Create'CustomFieldsType =
    | Dropdown
    | Numeric
    | Text

    type Create'CustomFields = {
        ///<summary>Configuration for `type=dropdown` fields.</summary>
        [<Config.Form>]Dropdown: Create'CustomFieldsDropdown option
        ///<summary>String of your choice that your integration can use to reconcile this field. Must be unique to this field, alphanumeric, and up to 200 characters.</summary>
        [<Config.Form>]Key: string option
        ///<summary>The label for the field, displayed to the customer.</summary>
        [<Config.Form>]Label: Create'CustomFieldsLabel option
        ///<summary>Configuration for `type=numeric` fields.</summary>
        [<Config.Form>]Numeric: Create'CustomFieldsNumeric option
        ///<summary>Whether the customer is required to complete the field before completing the Checkout Session. Defaults to `false`.</summary>
        [<Config.Form>]Optional: bool option
        ///<summary>Configuration for `type=text` fields.</summary>
        [<Config.Form>]Text: Create'CustomFieldsText option
        ///<summary>The type of the field.</summary>
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

    type Create'CustomTextAfterSubmitCustomTextPosition = {
        ///<summary>Text can be up to 1200 characters in length.</summary>
        [<Config.Form>]Message: string option
    }
    with
        static member New(?message: string) =
            {
                Message = message
            }

    type Create'CustomTextShippingAddressCustomTextPosition = {
        ///<summary>Text can be up to 1200 characters in length.</summary>
        [<Config.Form>]Message: string option
    }
    with
        static member New(?message: string) =
            {
                Message = message
            }

    type Create'CustomTextSubmitCustomTextPosition = {
        ///<summary>Text can be up to 1200 characters in length.</summary>
        [<Config.Form>]Message: string option
    }
    with
        static member New(?message: string) =
            {
                Message = message
            }

    type Create'CustomTextTermsOfServiceAcceptanceCustomTextPosition = {
        ///<summary>Text can be up to 1200 characters in length.</summary>
        [<Config.Form>]Message: string option
    }
    with
        static member New(?message: string) =
            {
                Message = message
            }

    type Create'CustomText = {
        ///<summary>Custom text that should be displayed after the payment confirmation button.</summary>
        [<Config.Form>]AfterSubmit: Choice<Create'CustomTextAfterSubmitCustomTextPosition,string> option
        ///<summary>Custom text that should be displayed alongside shipping address collection.</summary>
        [<Config.Form>]ShippingAddress: Choice<Create'CustomTextShippingAddressCustomTextPosition,string> option
        ///<summary>Custom text that should be displayed alongside the payment confirmation button.</summary>
        [<Config.Form>]Submit: Choice<Create'CustomTextSubmitCustomTextPosition,string> option
        ///<summary>Custom text that should be displayed in place of the default terms of service agreement text.</summary>
        [<Config.Form>]TermsOfServiceAcceptance: Choice<Create'CustomTextTermsOfServiceAcceptanceCustomTextPosition,string> option
    }
    with
        static member New(?afterSubmit: Choice<Create'CustomTextAfterSubmitCustomTextPosition,string>, ?shippingAddress: Choice<Create'CustomTextShippingAddressCustomTextPosition,string>, ?submit: Choice<Create'CustomTextSubmitCustomTextPosition,string>, ?termsOfServiceAcceptance: Choice<Create'CustomTextTermsOfServiceAcceptanceCustomTextPosition,string>) =
            {
                AfterSubmit = afterSubmit
                ShippingAddress = shippingAddress
                Submit = submit
                TermsOfServiceAcceptance = termsOfServiceAcceptance
            }

    type Create'InvoiceCreationInvoiceDataCustomFields = {
        ///<summary>The name of the custom field. This may be up to 40 characters.</summary>
        [<Config.Form>]Name: string option
        ///<summary>The value of the custom field. This may be up to 140 characters.</summary>
        [<Config.Form>]Value: string option
    }
    with
        static member New(?name: string, ?value: string) =
            {
                Name = name
                Value = value
            }

    type Create'InvoiceCreationInvoiceDataIssuerType =
    | Account
    | Self

    type Create'InvoiceCreationInvoiceDataIssuer = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Create'InvoiceCreationInvoiceDataIssuerType option
    }
    with
        static member New(?account: string, ?type': Create'InvoiceCreationInvoiceDataIssuerType) =
            {
                Account = account
                Type = type'
            }

    type Create'InvoiceCreationInvoiceDataRenderingOptionsCheckoutRenderingOptionsAmountTaxDisplay =
    | ExcludeTax
    | IncludeInclusiveTax

    type Create'InvoiceCreationInvoiceDataRenderingOptionsCheckoutRenderingOptions = {
        ///<summary>How line-item prices and amounts will be displayed with respect to tax on invoice PDFs. One of `exclude_tax` or `include_inclusive_tax`. `include_inclusive_tax` will include inclusive tax (and exclude exclusive tax) in invoice PDF amounts. `exclude_tax` will exclude all tax (inclusive and exclusive alike) from invoice PDF amounts.</summary>
        [<Config.Form>]AmountTaxDisplay: Create'InvoiceCreationInvoiceDataRenderingOptionsCheckoutRenderingOptionsAmountTaxDisplay option
        ///<summary>ID of the invoice rendering template to use for this invoice.</summary>
        [<Config.Form>]Template: string option
    }
    with
        static member New(?amountTaxDisplay: Create'InvoiceCreationInvoiceDataRenderingOptionsCheckoutRenderingOptionsAmountTaxDisplay, ?template: string) =
            {
                AmountTaxDisplay = amountTaxDisplay
                Template = template
            }

    type Create'InvoiceCreationInvoiceData = {
        ///<summary>The account tax IDs associated with the invoice.</summary>
        [<Config.Form>]AccountTaxIds: Choice<string list,string> option
        ///<summary>Default custom fields to be displayed on invoices for this customer.</summary>
        [<Config.Form>]CustomFields: Choice<Create'InvoiceCreationInvoiceDataCustomFields list,string> option
        ///<summary>An arbitrary string attached to the object. Often useful for displaying to users.</summary>
        [<Config.Form>]Description: string option
        ///<summary>Default footer to be displayed on invoices for this customer.</summary>
        [<Config.Form>]Footer: string option
        ///<summary>The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.</summary>
        [<Config.Form>]Issuer: Create'InvoiceCreationInvoiceDataIssuer option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Default options for invoice PDF rendering for this customer.</summary>
        [<Config.Form>]RenderingOptions: Choice<Create'InvoiceCreationInvoiceDataRenderingOptionsCheckoutRenderingOptions,string> option
    }
    with
        static member New(?accountTaxIds: Choice<string list,string>, ?customFields: Choice<Create'InvoiceCreationInvoiceDataCustomFields list,string>, ?description: string, ?footer: string, ?issuer: Create'InvoiceCreationInvoiceDataIssuer, ?metadata: Map<string, string>, ?renderingOptions: Choice<Create'InvoiceCreationInvoiceDataRenderingOptionsCheckoutRenderingOptions,string>) =
            {
                AccountTaxIds = accountTaxIds
                CustomFields = customFields
                Description = description
                Footer = footer
                Issuer = issuer
                Metadata = metadata
                RenderingOptions = renderingOptions
            }

    type Create'InvoiceCreation = {
        ///<summary>Whether the feature is enabled</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>Invoice PDF configuration.</summary>
        [<Config.Form>]InvoiceData: Create'InvoiceCreationInvoiceData option
    }
    with
        static member New(?enabled: bool, ?invoiceData: Create'InvoiceCreationInvoiceData) =
            {
                Enabled = enabled
                InvoiceData = invoiceData
            }

    type Create'LineItemsAdjustableQuantity = {
        ///<summary>Set to true if the quantity can be adjusted to any non-negative Integer.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The maximum quantity the customer can purchase. By default this value is 99. You can specify a value up to 999999.</summary>
        [<Config.Form>]Maximum: int option
        ///<summary>The minimum quantity the customer can purchase. By default this value is 0. If there is only one item in the cart then that item's quantity cannot go down to 0.</summary>
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
        ///<summary>The product's description, meant to be displayable to the customer. Use this field to optionally store a long form explanation of the product being sold for your own rendering purposes.</summary>
        [<Config.Form>]Description: string option
        ///<summary>A list of up to 8 URLs of images for this product, meant to be displayable to the customer.</summary>
        [<Config.Form>]Images: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The product's name, meant to be displayable to the customer.</summary>
        [<Config.Form>]Name: string option
        ///<summary>A [tax code](https://docs.stripe.com/tax/tax-categories) ID.</summary>
        [<Config.Form>]TaxCode: string option
        ///<summary>A label that represents units of this product. When set, this will be included in customers' receipts, invoices, Checkout, and the customer portal.</summary>
        [<Config.Form>]UnitLabel: string option
    }
    with
        static member New(?description: string, ?images: string list, ?metadata: Map<string, string>, ?name: string, ?taxCode: string, ?unitLabel: string) =
            {
                Description = description
                Images = images
                Metadata = metadata
                Name = name
                TaxCode = taxCode
                UnitLabel = unitLabel
            }

    type Create'LineItemsPriceDataRecurringInterval =
    | Day
    | Month
    | Week
    | Year

    type Create'LineItemsPriceDataRecurring = {
        ///<summary>Specifies billing frequency. Either `day`, `week`, `month` or `year`.</summary>
        [<Config.Form>]Interval: Create'LineItemsPriceDataRecurringInterval option
        ///<summary>The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).</summary>
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
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to. One of `product` or `product_data` is required.</summary>
        [<Config.Form>]Product: string option
        ///<summary>Data used to generate a new [Product](https://docs.stripe.com/api/products) object inline. One of `product` or `product_data` is required.</summary>
        [<Config.Form>]ProductData: Create'LineItemsPriceDataProductData option
        ///<summary>The recurring components of a price such as `interval` and `interval_count`.</summary>
        [<Config.Form>]Recurring: Create'LineItemsPriceDataRecurring option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: Create'LineItemsPriceDataTaxBehavior option
        ///<summary>A non-negative integer in cents (or local equivalent) representing how much to charge. One of `unit_amount` or `unit_amount_decimal` is required.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?productData: Create'LineItemsPriceDataProductData, ?recurring: Create'LineItemsPriceDataRecurring, ?taxBehavior: Create'LineItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
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
        ///<summary>When set, provides configuration for this item’s quantity to be adjusted by the customer during checkout.</summary>
        [<Config.Form>]AdjustableQuantity: Create'LineItemsAdjustableQuantity option
        ///<summary>The ID of the [Price](https://docs.stripe.com/api/prices) or [Plan](https://docs.stripe.com/api/plans) object. One of `price` or `price_data` is required.</summary>
        [<Config.Form>]Price: string option
        ///<summary>Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.</summary>
        [<Config.Form>]PriceData: Create'LineItemsPriceData option
        ///<summary>The quantity of the line item being purchased.</summary>
        [<Config.Form>]Quantity: int option
    }
    with
        static member New(?adjustableQuantity: Create'LineItemsAdjustableQuantity, ?price: string, ?priceData: Create'LineItemsPriceData, ?quantity: int) =
            {
                AdjustableQuantity = adjustableQuantity
                Price = price
                PriceData = priceData
                Quantity = quantity
            }

    type Create'ManagedPayments = {
        ///<summary>Set to `true` to enable [Managed Payments](https://docs.stripe.com/payments/managed-payments), Stripe's merchant of record solution, for this session.</summary>
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Create'NameCollectionBusiness = {
        ///<summary>Enable business name collection on the payment link. Defaults to `false`.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>Whether the customer is required to provide their business name before checking out. Defaults to `false`.</summary>
        [<Config.Form>]Optional: bool option
    }
    with
        static member New(?enabled: bool, ?optional: bool) =
            {
                Enabled = enabled
                Optional = optional
            }

    type Create'NameCollectionIndividual = {
        ///<summary>Enable individual name collection on the payment link. Defaults to `false`.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>Whether the customer is required to provide their full name before checking out. Defaults to `false`.</summary>
        [<Config.Form>]Optional: bool option
    }
    with
        static member New(?enabled: bool, ?optional: bool) =
            {
                Enabled = enabled
                Optional = optional
            }

    type Create'NameCollection = {
        ///<summary>Controls settings applied for collecting the customer's business name.</summary>
        [<Config.Form>]Business: Create'NameCollectionBusiness option
        ///<summary>Controls settings applied for collecting the customer's individual name.</summary>
        [<Config.Form>]Individual: Create'NameCollectionIndividual option
    }
    with
        static member New(?business: Create'NameCollectionBusiness, ?individual: Create'NameCollectionIndividual) =
            {
                Business = business
                Individual = individual
            }

    type Create'OptionalItemsAdjustableQuantity = {
        ///<summary>Set to true if the quantity can be adjusted to any non-negative integer.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The maximum quantity of this item the customer can purchase. By default this value is 99.</summary>
        [<Config.Form>]Maximum: int option
        ///<summary>The minimum quantity of this item the customer must purchase, if they choose to purchase it. Because this item is optional, the customer will always be able to remove it from their order, even if the `minimum` configured here is greater than 0. By default this value is 0.</summary>
        [<Config.Form>]Minimum: int option
    }
    with
        static member New(?enabled: bool, ?maximum: int, ?minimum: int) =
            {
                Enabled = enabled
                Maximum = maximum
                Minimum = minimum
            }

    type Create'OptionalItems = {
        ///<summary>When set, provides configuration for the customer to adjust the quantity of the line item created when a customer chooses to add this optional item to their order.</summary>
        [<Config.Form>]AdjustableQuantity: Create'OptionalItemsAdjustableQuantity option
        ///<summary>The ID of the [Price](https://docs.stripe.com/api/prices) or [Plan](https://docs.stripe.com/api/plans) object.</summary>
        [<Config.Form>]Price: string option
        ///<summary>The initial quantity of the line item created when a customer chooses to add this optional item to their order.</summary>
        [<Config.Form>]Quantity: int option
    }
    with
        static member New(?adjustableQuantity: Create'OptionalItemsAdjustableQuantity, ?price: string, ?quantity: int) =
            {
                AdjustableQuantity = adjustableQuantity
                Price = price
                Quantity = quantity
            }

    type Create'PaymentIntentDataCaptureMethod =
    | Automatic
    | AutomaticAsync
    | Manual

    type Create'PaymentIntentDataSetupFutureUsage =
    | OffSession
    | OnSession

    type Create'PaymentIntentData = {
        ///<summary>Controls when the funds will be captured from the customer's account.</summary>
        [<Config.Form>]CaptureMethod: Create'PaymentIntentDataCaptureMethod option
        ///<summary>An arbitrary string attached to the object. Often useful for displaying to users.</summary>
        [<Config.Form>]Description: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that will declaratively set metadata on [Payment Intents](https://docs.stripe.com/api/payment_intents) generated from this payment link. Unlike object-level metadata, this field is declarative. Updates will clear prior values.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Indicates that you intend to [make future payments](https://docs.stripe.com/payments/payment-intents#future-usage) with the payment method collected by this Checkout Session.
        ///When setting this to `on_session`, Checkout will show a notice to the customer that their payment details will be saved.
        ///When setting this to `off_session`, Checkout will show a notice to the customer that their payment details will be saved and used for future payments.
        ///If a Customer has been provided or Checkout creates a new Customer,Checkout will attach the payment method to the Customer.
        ///If Checkout does not create a Customer, the payment method is not attached to a Customer. To reuse the payment method, you can retrieve it from the Checkout Session's PaymentIntent.
        ///When processing card payments, Checkout also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as SCA.</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentIntentDataSetupFutureUsage option
        ///<summary>Text that appears on the customer's statement as the statement descriptor for a non-card charge. This value overrides the account's default statement descriptor. For information about requirements, including the 22-character limit, see [the Statement Descriptor docs](https://docs.stripe.com/get-started/account/statement-descriptors).
        ///Setting this value for a card charge returns an error. For card charges, set the [statement_descriptor_suffix](https://docs.stripe.com/get-started/account/statement-descriptors#dynamic) instead.</summary>
        [<Config.Form>]StatementDescriptor: string option
        ///<summary>Provides information about a card charge. Concatenated to the account's [statement descriptor prefix](https://docs.stripe.com/get-started/account/statement-descriptors#static) to form the complete statement descriptor that appears on the customer's statement.</summary>
        [<Config.Form>]StatementDescriptorSuffix: string option
        ///<summary>A string that identifies the resulting payment as part of a group. See the PaymentIntents [use case for connected accounts](https://docs.stripe.com/connect/separate-charges-and-transfers) for details.</summary>
        [<Config.Form>]TransferGroup: string option
    }
    with
        static member New(?captureMethod: Create'PaymentIntentDataCaptureMethod, ?description: string, ?metadata: Map<string, string>, ?setupFutureUsage: Create'PaymentIntentDataSetupFutureUsage, ?statementDescriptor: string, ?statementDescriptorSuffix: string, ?transferGroup: string) =
            {
                CaptureMethod = captureMethod
                Description = description
                Metadata = metadata
                SetupFutureUsage = setupFutureUsage
                StatementDescriptor = statementDescriptor
                StatementDescriptorSuffix = statementDescriptorSuffix
                TransferGroup = transferGroup
            }

    type Create'PaymentMethodTypes =
    | Affirm
    | AfterpayClearpay
    | Alipay
    | Alma
    | AuBecsDebit
    | BacsDebit
    | Bancontact
    | Billie
    | Blik
    | Boleto
    | Card
    | Cashapp
    | Eps
    | Fpx
    | Giropay
    | Grabpay
    | Ideal
    | Klarna
    | Konbini
    | Link
    | MbWay
    | Mobilepay
    | Multibanco
    | Oxxo
    | P24
    | PayByBank
    | Paynow
    | Paypal
    | Payto
    | Pix
    | Promptpay
    | Satispay
    | SepaDebit
    | Sofort
    | Sunbit
    | Swish
    | Twint
    | Upi
    | UsBankAccount
    | WechatPay
    | Zip

    type Create'PhoneNumberCollection = {
        ///<summary>Set to `true` to enable phone number collection.</summary>
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Create'RestrictionsCompletedSessions = {
        ///<summary>The maximum number of checkout sessions that can be completed for the `completed_sessions` restriction to be met.</summary>
        [<Config.Form>]Limit: int option
    }
    with
        static member New(?limit: int) =
            {
                Limit = limit
            }

    type Create'Restrictions = {
        ///<summary>Configuration for the `completed_sessions` restriction type.</summary>
        [<Config.Form>]CompletedSessions: Create'RestrictionsCompletedSessions option
    }
    with
        static member New(?completedSessions: Create'RestrictionsCompletedSessions) =
            {
                CompletedSessions = completedSessions
            }

    type Create'ShippingAddressCollectionAllowedCountries =
    | [<JsonPropertyName("AC")>] AC
    | [<JsonPropertyName("AD")>] AD
    | [<JsonPropertyName("AE")>] AE
    | [<JsonPropertyName("AF")>] AF
    | [<JsonPropertyName("AG")>] AG
    | [<JsonPropertyName("AI")>] AI
    | [<JsonPropertyName("AL")>] AL
    | [<JsonPropertyName("AM")>] AM
    | [<JsonPropertyName("AO")>] AO
    | [<JsonPropertyName("AQ")>] AQ
    | [<JsonPropertyName("AR")>] AR
    | [<JsonPropertyName("AT")>] AT
    | [<JsonPropertyName("AU")>] AU
    | [<JsonPropertyName("AW")>] AW
    | [<JsonPropertyName("AX")>] AX
    | [<JsonPropertyName("AZ")>] AZ
    | [<JsonPropertyName("BA")>] BA
    | [<JsonPropertyName("BB")>] BB
    | [<JsonPropertyName("BD")>] BD
    | [<JsonPropertyName("BE")>] BE
    | [<JsonPropertyName("BF")>] BF
    | [<JsonPropertyName("BG")>] BG
    | [<JsonPropertyName("BH")>] BH
    | [<JsonPropertyName("BI")>] BI
    | [<JsonPropertyName("BJ")>] BJ
    | [<JsonPropertyName("BL")>] BL
    | [<JsonPropertyName("BM")>] BM
    | [<JsonPropertyName("BN")>] BN
    | [<JsonPropertyName("BO")>] BO
    | [<JsonPropertyName("BQ")>] BQ
    | [<JsonPropertyName("BR")>] BR
    | [<JsonPropertyName("BS")>] BS
    | [<JsonPropertyName("BT")>] BT
    | [<JsonPropertyName("BV")>] BV
    | [<JsonPropertyName("BW")>] BW
    | [<JsonPropertyName("BY")>] BY
    | [<JsonPropertyName("BZ")>] BZ
    | [<JsonPropertyName("CA")>] CA
    | [<JsonPropertyName("CD")>] CD
    | [<JsonPropertyName("CF")>] CF
    | [<JsonPropertyName("CG")>] CG
    | [<JsonPropertyName("CH")>] CH
    | [<JsonPropertyName("CI")>] CI
    | [<JsonPropertyName("CK")>] CK
    | [<JsonPropertyName("CL")>] CL
    | [<JsonPropertyName("CM")>] CM
    | [<JsonPropertyName("CN")>] CN
    | [<JsonPropertyName("CO")>] CO
    | [<JsonPropertyName("CR")>] CR
    | [<JsonPropertyName("CV")>] CV
    | [<JsonPropertyName("CW")>] CW
    | [<JsonPropertyName("CY")>] CY
    | [<JsonPropertyName("CZ")>] CZ
    | [<JsonPropertyName("DE")>] DE
    | [<JsonPropertyName("DJ")>] DJ
    | [<JsonPropertyName("DK")>] DK
    | [<JsonPropertyName("DM")>] DM
    | [<JsonPropertyName("DO")>] DO
    | [<JsonPropertyName("DZ")>] DZ
    | [<JsonPropertyName("EC")>] EC
    | [<JsonPropertyName("EE")>] EE
    | [<JsonPropertyName("EG")>] EG
    | [<JsonPropertyName("EH")>] EH
    | [<JsonPropertyName("ER")>] ER
    | [<JsonPropertyName("ES")>] ES
    | [<JsonPropertyName("ET")>] ET
    | [<JsonPropertyName("FI")>] FI
    | [<JsonPropertyName("FJ")>] FJ
    | [<JsonPropertyName("FK")>] FK
    | [<JsonPropertyName("FO")>] FO
    | [<JsonPropertyName("FR")>] FR
    | [<JsonPropertyName("GA")>] GA
    | [<JsonPropertyName("GB")>] GB
    | [<JsonPropertyName("GD")>] GD
    | [<JsonPropertyName("GE")>] GE
    | [<JsonPropertyName("GF")>] GF
    | [<JsonPropertyName("GG")>] GG
    | [<JsonPropertyName("GH")>] GH
    | [<JsonPropertyName("GI")>] GI
    | [<JsonPropertyName("GL")>] GL
    | [<JsonPropertyName("GM")>] GM
    | [<JsonPropertyName("GN")>] GN
    | [<JsonPropertyName("GP")>] GP
    | [<JsonPropertyName("GQ")>] GQ
    | [<JsonPropertyName("GR")>] GR
    | [<JsonPropertyName("GS")>] GS
    | [<JsonPropertyName("GT")>] GT
    | [<JsonPropertyName("GU")>] GU
    | [<JsonPropertyName("GW")>] GW
    | [<JsonPropertyName("GY")>] GY
    | [<JsonPropertyName("HK")>] HK
    | [<JsonPropertyName("HN")>] HN
    | [<JsonPropertyName("HR")>] HR
    | [<JsonPropertyName("HT")>] HT
    | [<JsonPropertyName("HU")>] HU
    | [<JsonPropertyName("ID")>] ID
    | [<JsonPropertyName("IE")>] IE
    | [<JsonPropertyName("IL")>] IL
    | [<JsonPropertyName("IM")>] IM
    | [<JsonPropertyName("IN")>] IN
    | [<JsonPropertyName("IO")>] IO
    | [<JsonPropertyName("IQ")>] IQ
    | [<JsonPropertyName("IS")>] IS
    | [<JsonPropertyName("IT")>] IT
    | [<JsonPropertyName("JE")>] JE
    | [<JsonPropertyName("JM")>] JM
    | [<JsonPropertyName("JO")>] JO
    | [<JsonPropertyName("JP")>] JP
    | [<JsonPropertyName("KE")>] KE
    | [<JsonPropertyName("KG")>] KG
    | [<JsonPropertyName("KH")>] KH
    | [<JsonPropertyName("KI")>] KI
    | [<JsonPropertyName("KM")>] KM
    | [<JsonPropertyName("KN")>] KN
    | [<JsonPropertyName("KR")>] KR
    | [<JsonPropertyName("KW")>] KW
    | [<JsonPropertyName("KY")>] KY
    | [<JsonPropertyName("KZ")>] KZ
    | [<JsonPropertyName("LA")>] LA
    | [<JsonPropertyName("LB")>] LB
    | [<JsonPropertyName("LC")>] LC
    | [<JsonPropertyName("LI")>] LI
    | [<JsonPropertyName("LK")>] LK
    | [<JsonPropertyName("LR")>] LR
    | [<JsonPropertyName("LS")>] LS
    | [<JsonPropertyName("LT")>] LT
    | [<JsonPropertyName("LU")>] LU
    | [<JsonPropertyName("LV")>] LV
    | [<JsonPropertyName("LY")>] LY
    | [<JsonPropertyName("MA")>] MA
    | [<JsonPropertyName("MC")>] MC
    | [<JsonPropertyName("MD")>] MD
    | [<JsonPropertyName("ME")>] ME
    | [<JsonPropertyName("MF")>] MF
    | [<JsonPropertyName("MG")>] MG
    | [<JsonPropertyName("MK")>] MK
    | [<JsonPropertyName("ML")>] ML
    | [<JsonPropertyName("MM")>] MM
    | [<JsonPropertyName("MN")>] MN
    | [<JsonPropertyName("MO")>] MO
    | [<JsonPropertyName("MQ")>] MQ
    | [<JsonPropertyName("MR")>] MR
    | [<JsonPropertyName("MS")>] MS
    | [<JsonPropertyName("MT")>] MT
    | [<JsonPropertyName("MU")>] MU
    | [<JsonPropertyName("MV")>] MV
    | [<JsonPropertyName("MW")>] MW
    | [<JsonPropertyName("MX")>] MX
    | [<JsonPropertyName("MY")>] MY
    | [<JsonPropertyName("MZ")>] MZ
    | [<JsonPropertyName("NA")>] NA
    | [<JsonPropertyName("NC")>] NC
    | [<JsonPropertyName("NE")>] NE
    | [<JsonPropertyName("NG")>] NG
    | [<JsonPropertyName("NI")>] NI
    | [<JsonPropertyName("NL")>] NL
    | [<JsonPropertyName("NO")>] NO
    | [<JsonPropertyName("NP")>] NP
    | [<JsonPropertyName("NR")>] NR
    | [<JsonPropertyName("NU")>] NU
    | [<JsonPropertyName("NZ")>] NZ
    | [<JsonPropertyName("OM")>] OM
    | [<JsonPropertyName("PA")>] PA
    | [<JsonPropertyName("PE")>] PE
    | [<JsonPropertyName("PF")>] PF
    | [<JsonPropertyName("PG")>] PG
    | [<JsonPropertyName("PH")>] PH
    | [<JsonPropertyName("PK")>] PK
    | [<JsonPropertyName("PL")>] PL
    | [<JsonPropertyName("PM")>] PM
    | [<JsonPropertyName("PN")>] PN
    | [<JsonPropertyName("PR")>] PR
    | [<JsonPropertyName("PS")>] PS
    | [<JsonPropertyName("PT")>] PT
    | [<JsonPropertyName("PY")>] PY
    | [<JsonPropertyName("QA")>] QA
    | [<JsonPropertyName("RE")>] RE
    | [<JsonPropertyName("RO")>] RO
    | [<JsonPropertyName("RS")>] RS
    | [<JsonPropertyName("RU")>] RU
    | [<JsonPropertyName("RW")>] RW
    | [<JsonPropertyName("SA")>] SA
    | [<JsonPropertyName("SB")>] SB
    | [<JsonPropertyName("SC")>] SC
    | [<JsonPropertyName("SD")>] SD
    | [<JsonPropertyName("SE")>] SE
    | [<JsonPropertyName("SG")>] SG
    | [<JsonPropertyName("SH")>] SH
    | [<JsonPropertyName("SI")>] SI
    | [<JsonPropertyName("SJ")>] SJ
    | [<JsonPropertyName("SK")>] SK
    | [<JsonPropertyName("SL")>] SL
    | [<JsonPropertyName("SM")>] SM
    | [<JsonPropertyName("SN")>] SN
    | [<JsonPropertyName("SO")>] SO
    | [<JsonPropertyName("SR")>] SR
    | [<JsonPropertyName("SS")>] SS
    | [<JsonPropertyName("ST")>] ST
    | [<JsonPropertyName("SV")>] SV
    | [<JsonPropertyName("SX")>] SX
    | [<JsonPropertyName("SZ")>] SZ
    | [<JsonPropertyName("TA")>] TA
    | [<JsonPropertyName("TC")>] TC
    | [<JsonPropertyName("TD")>] TD
    | [<JsonPropertyName("TF")>] TF
    | [<JsonPropertyName("TG")>] TG
    | [<JsonPropertyName("TH")>] TH
    | [<JsonPropertyName("TJ")>] TJ
    | [<JsonPropertyName("TK")>] TK
    | [<JsonPropertyName("TL")>] TL
    | [<JsonPropertyName("TM")>] TM
    | [<JsonPropertyName("TN")>] TN
    | [<JsonPropertyName("TO")>] TO
    | [<JsonPropertyName("TR")>] TR
    | [<JsonPropertyName("TT")>] TT
    | [<JsonPropertyName("TV")>] TV
    | [<JsonPropertyName("TW")>] TW
    | [<JsonPropertyName("TZ")>] TZ
    | [<JsonPropertyName("UA")>] UA
    | [<JsonPropertyName("UG")>] UG
    | [<JsonPropertyName("US")>] US
    | [<JsonPropertyName("UY")>] UY
    | [<JsonPropertyName("UZ")>] UZ
    | [<JsonPropertyName("VA")>] VA
    | [<JsonPropertyName("VC")>] VC
    | [<JsonPropertyName("VE")>] VE
    | [<JsonPropertyName("VG")>] VG
    | [<JsonPropertyName("VN")>] VN
    | [<JsonPropertyName("VU")>] VU
    | [<JsonPropertyName("WF")>] WF
    | [<JsonPropertyName("WS")>] WS
    | [<JsonPropertyName("XK")>] XK
    | [<JsonPropertyName("YE")>] YE
    | [<JsonPropertyName("YT")>] YT
    | [<JsonPropertyName("ZA")>] ZA
    | [<JsonPropertyName("ZM")>] ZM
    | [<JsonPropertyName("ZW")>] ZW
    | [<JsonPropertyName("ZZ")>] ZZ

    type Create'ShippingAddressCollection = {
        ///<summary>An array of two-letter ISO country codes representing which countries Checkout should provide as options for
        ///shipping locations.</summary>
        [<Config.Form>]AllowedCountries: Create'ShippingAddressCollectionAllowedCountries list option
    }
    with
        static member New(?allowedCountries: Create'ShippingAddressCollectionAllowedCountries list) =
            {
                AllowedCountries = allowedCountries
            }

    type Create'ShippingOptions = {
        ///<summary>The ID of the Shipping Rate to use for this shipping option.</summary>
        [<Config.Form>]ShippingRate: string option
    }
    with
        static member New(?shippingRate: string) =
            {
                ShippingRate = shippingRate
            }

    type Create'SubscriptionDataInvoiceSettingsIssuerType =
    | Account
    | Self

    type Create'SubscriptionDataInvoiceSettingsIssuer = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Create'SubscriptionDataInvoiceSettingsIssuerType option
    }
    with
        static member New(?account: string, ?type': Create'SubscriptionDataInvoiceSettingsIssuerType) =
            {
                Account = account
                Type = type'
            }

    type Create'SubscriptionDataInvoiceSettings = {
        ///<summary>The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.</summary>
        [<Config.Form>]Issuer: Create'SubscriptionDataInvoiceSettingsIssuer option
    }
    with
        static member New(?issuer: Create'SubscriptionDataInvoiceSettingsIssuer) =
            {
                Issuer = issuer
            }

    type Create'SubscriptionDataTrialSettingsEndBehaviorMissingPaymentMethod =
    | Cancel
    | CreateInvoice
    | Pause

    type Create'SubscriptionDataTrialSettingsEndBehavior = {
        ///<summary>Indicates how the subscription should change when the trial ends if the user did not provide a payment method.</summary>
        [<Config.Form>]MissingPaymentMethod: Create'SubscriptionDataTrialSettingsEndBehaviorMissingPaymentMethod option
    }
    with
        static member New(?missingPaymentMethod: Create'SubscriptionDataTrialSettingsEndBehaviorMissingPaymentMethod) =
            {
                MissingPaymentMethod = missingPaymentMethod
            }

    type Create'SubscriptionDataTrialSettings = {
        ///<summary>Defines how the subscription should behave when the user's free trial ends.</summary>
        [<Config.Form>]EndBehavior: Create'SubscriptionDataTrialSettingsEndBehavior option
    }
    with
        static member New(?endBehavior: Create'SubscriptionDataTrialSettingsEndBehavior) =
            {
                EndBehavior = endBehavior
            }

    type Create'SubscriptionData = {
        ///<summary>The subscription's description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription for rendering in Stripe surfaces and certain local payment methods UIs.</summary>
        [<Config.Form>]Description: string option
        ///<summary>All invoices will be billed using the specified settings.</summary>
        [<Config.Form>]InvoiceSettings: Create'SubscriptionDataInvoiceSettings option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that will declaratively set metadata on [Subscriptions](https://docs.stripe.com/api/subscriptions) generated from this payment link. Unlike object-level metadata, this field is declarative. Updates will clear prior values.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Integer representing the number of trial period days before the customer is charged for the first time. Has to be at least 1.</summary>
        [<Config.Form>]TrialPeriodDays: int option
        ///<summary>Settings related to subscription trials.</summary>
        [<Config.Form>]TrialSettings: Create'SubscriptionDataTrialSettings option
    }
    with
        static member New(?description: string, ?invoiceSettings: Create'SubscriptionDataInvoiceSettings, ?metadata: Map<string, string>, ?trialPeriodDays: int, ?trialSettings: Create'SubscriptionDataTrialSettings) =
            {
                Description = description
                InvoiceSettings = invoiceSettings
                Metadata = metadata
                TrialPeriodDays = trialPeriodDays
                TrialSettings = trialSettings
            }

    type Create'TaxIdCollectionRequired =
    | IfSupported
    | Never

    type Create'TaxIdCollection = {
        ///<summary>Enable tax ID collection during checkout. Defaults to `false`.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>Describes whether a tax ID is required during checkout. Defaults to `never`. You can't set this parameter if `ui_mode` is `custom`.</summary>
        [<Config.Form>]Required: Create'TaxIdCollectionRequired option
    }
    with
        static member New(?enabled: bool, ?required: Create'TaxIdCollectionRequired) =
            {
                Enabled = enabled
                Required = required
            }

    type Create'TransferData = {
        ///<summary>The amount that will be transferred automatically when a charge succeeds.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>If specified, successful charges will be attributed to the destination
        ///account for tax reporting, and the funds from charges will be transferred
        ///to the destination account. The ID of the resulting transfer will be
        ///returned on the successful charge's `transfer` field.</summary>
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amount: int, ?destination: string) =
            {
                Amount = amount
                Destination = destination
            }

    type Create'BillingAddressCollection =
    | Auto
    | Required

    type Create'CustomerCreation =
    | Always
    | IfRequired

    type Create'PaymentMethodCollection =
    | Always
    | IfRequired

    type Create'SubmitType =
    | Auto
    | Book
    | Donate
    | Pay
    | Subscribe

    type CreateOptions = {
        ///<summary>Behavior after the purchase is complete.</summary>
        [<Config.Form>]AfterCompletion: Create'AfterCompletion option
        ///<summary>Enables user redeemable promotion codes.</summary>
        [<Config.Form>]AllowPromotionCodes: bool option
        ///<summary>The amount of the application fee (if any) that will be requested to be applied to the payment and transferred to the application owner's Stripe account. Can only be applied when there are no line items with recurring prices.</summary>
        [<Config.Form>]ApplicationFeeAmount: int option
        ///<summary>A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. There must be at least 1 line item with a recurring price to use this field.</summary>
        [<Config.Form>]ApplicationFeePercent: decimal option
        ///<summary>Configuration for automatic tax collection.</summary>
        [<Config.Form>]AutomaticTax: Create'AutomaticTax option
        ///<summary>Configuration for collecting the customer's billing address. Defaults to `auto`.</summary>
        [<Config.Form>]BillingAddressCollection: Create'BillingAddressCollection option
        ///<summary>Configure fields to gather active consent from customers.</summary>
        [<Config.Form>]ConsentCollection: Create'ConsentCollection option
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies) and supported by each line item's price.</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>Collect additional information from your customer using custom fields. Up to 3 fields are supported. You can't set this parameter if `ui_mode` is `custom`.</summary>
        [<Config.Form>]CustomFields: Create'CustomFields list option
        ///<summary>Display additional text for your customers using custom text. You can't set this parameter if `ui_mode` is `custom`.</summary>
        [<Config.Form>]CustomText: Create'CustomText option
        ///<summary>Configures whether [checkout sessions](https://docs.stripe.com/api/checkout/sessions) created by this payment link create a [Customer](https://docs.stripe.com/api/customers).</summary>
        [<Config.Form>]CustomerCreation: Create'CustomerCreation option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The custom message to be displayed to a customer when a payment link is no longer active.</summary>
        [<Config.Form>]InactiveMessage: string option
        ///<summary>Generate a post-purchase Invoice for one-time payments.</summary>
        [<Config.Form>]InvoiceCreation: Create'InvoiceCreation option
        ///<summary>The line items representing what is being sold. Each line item represents an item being sold. Up to 20 line items are supported.</summary>
        [<Config.Form>]LineItems: Create'LineItems list
        ///<summary>Settings for Managed Payments for this Payment Link and resulting [CheckoutSessions](/api/checkout/sessions/object), [PaymentIntents](/api/payment_intents/object), [Invoices](/api/invoices/object), and [Subscriptions](/api/subscriptions/object).</summary>
        [<Config.Form>]ManagedPayments: Create'ManagedPayments option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`. Metadata associated with this Payment Link will automatically be copied to [checkout sessions](https://docs.stripe.com/api/checkout/sessions) created by this payment link.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Controls settings applied for collecting the customer's name.</summary>
        [<Config.Form>]NameCollection: Create'NameCollection option
        ///<summary>The account on behalf of which to charge.</summary>
        [<Config.Form>]OnBehalfOf: string option
        ///<summary>A list of optional items the customer can add to their order at checkout. Use this parameter to pass one-time or recurring [Prices](https://docs.stripe.com/api/prices).
        ///There is a maximum of 10 optional items allowed on a payment link, and the existing limits on the number of line items allowed on a payment link apply to the combined number of line items and optional items.
        ///There is a maximum of 20 combined line items and optional items.</summary>
        [<Config.Form>]OptionalItems: Create'OptionalItems list option
        ///<summary>A subset of parameters to be passed to PaymentIntent creation for Checkout Sessions in `payment` mode.</summary>
        [<Config.Form>]PaymentIntentData: Create'PaymentIntentData option
        ///<summary>Specify whether Checkout should collect a payment method. When set to `if_required`, Checkout will not collect a payment method when the total due for the session is 0.This may occur if the Checkout Session includes a free trial or a discount.
        ///Can only be set in `subscription` mode. Defaults to `always`.
        ///If you'd like information on how to collect a payment method outside of Checkout, read the guide on [configuring subscriptions with a free trial](https://docs.stripe.com/payments/checkout/free-trials).</summary>
        [<Config.Form>]PaymentMethodCollection: Create'PaymentMethodCollection option
        ///<summary>The list of payment method types that customers can use. If no value is passed, Stripe will dynamically show relevant payment methods from your [payment method settings](https://dashboard.stripe.com/settings/payment_methods) (20+ payment methods [supported](https://docs.stripe.com/payments/payment-methods/integration-options#payment-method-product-support)).</summary>
        [<Config.Form>]PaymentMethodTypes: Create'PaymentMethodTypes list option
        ///<summary>Controls phone number collection settings during checkout.
        ///We recommend that you review your privacy policy and check with your legal contacts.</summary>
        [<Config.Form>]PhoneNumberCollection: Create'PhoneNumberCollection option
        ///<summary>Settings that restrict the usage of a payment link.</summary>
        [<Config.Form>]Restrictions: Create'Restrictions option
        ///<summary>Configuration for collecting the customer's shipping address.</summary>
        [<Config.Form>]ShippingAddressCollection: Create'ShippingAddressCollection option
        ///<summary>The shipping rate options to apply to [checkout sessions](https://docs.stripe.com/api/checkout/sessions) created by this payment link.</summary>
        [<Config.Form>]ShippingOptions: Create'ShippingOptions list option
        ///<summary>Describes the type of transaction being performed in order to customize relevant text on the page, such as the submit button. Changing this value will also affect the hostname in the [url](https://docs.stripe.com/api/payment_links/payment_links/object#url) property (example: `donate.stripe.com`).</summary>
        [<Config.Form>]SubmitType: Create'SubmitType option
        ///<summary>When creating a subscription, the specified configuration data will be used. There must be at least one line item with a recurring price to use `subscription_data`.</summary>
        [<Config.Form>]SubscriptionData: Create'SubscriptionData option
        ///<summary>Controls tax ID collection during checkout.</summary>
        [<Config.Form>]TaxIdCollection: Create'TaxIdCollection option
        ///<summary>The account (if any) the payments will be attributed to for tax reporting, and where funds from each payment will be transferred to.</summary>
        [<Config.Form>]TransferData: Create'TransferData option
    }
    with
        static member New(lineItems: Create'LineItems list, ?afterCompletion: Create'AfterCompletion, ?subscriptionData: Create'SubscriptionData, ?submitType: Create'SubmitType, ?shippingOptions: Create'ShippingOptions list, ?shippingAddressCollection: Create'ShippingAddressCollection, ?restrictions: Create'Restrictions, ?phoneNumberCollection: Create'PhoneNumberCollection, ?paymentMethodTypes: Create'PaymentMethodTypes list, ?paymentMethodCollection: Create'PaymentMethodCollection, ?paymentIntentData: Create'PaymentIntentData, ?optionalItems: Create'OptionalItems list, ?onBehalfOf: string, ?nameCollection: Create'NameCollection, ?metadata: Map<string, string>, ?managedPayments: Create'ManagedPayments, ?invoiceCreation: Create'InvoiceCreation, ?inactiveMessage: string, ?expand: string list, ?customerCreation: Create'CustomerCreation, ?customText: Create'CustomText, ?customFields: Create'CustomFields list, ?currency: IsoTypes.IsoCurrencyCode, ?consentCollection: Create'ConsentCollection, ?billingAddressCollection: Create'BillingAddressCollection, ?automaticTax: Create'AutomaticTax, ?applicationFeePercent: decimal, ?applicationFeeAmount: int, ?allowPromotionCodes: bool, ?taxIdCollection: Create'TaxIdCollection, ?transferData: Create'TransferData) =
            {
                AfterCompletion = afterCompletion
                AllowPromotionCodes = allowPromotionCodes
                ApplicationFeeAmount = applicationFeeAmount
                ApplicationFeePercent = applicationFeePercent
                AutomaticTax = automaticTax
                BillingAddressCollection = billingAddressCollection
                ConsentCollection = consentCollection
                Currency = currency
                CustomFields = customFields
                CustomText = customText
                CustomerCreation = customerCreation
                Expand = expand
                InactiveMessage = inactiveMessage
                InvoiceCreation = invoiceCreation
                LineItems = lineItems
                ManagedPayments = managedPayments
                Metadata = metadata
                NameCollection = nameCollection
                OnBehalfOf = onBehalfOf
                OptionalItems = optionalItems
                PaymentIntentData = paymentIntentData
                PaymentMethodCollection = paymentMethodCollection
                PaymentMethodTypes = paymentMethodTypes
                PhoneNumberCollection = phoneNumberCollection
                Restrictions = restrictions
                ShippingAddressCollection = shippingAddressCollection
                ShippingOptions = shippingOptions
                SubmitType = submitType
                SubscriptionData = subscriptionData
                TaxIdCollection = taxIdCollection
                TransferData = transferData
            }

    ///<summary><p>Creates a payment link.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/payment_links"
        |> RestApi.postAsync<_, PaymentLink> settings (Map.empty) options

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]PaymentLink: string
    }
    with
        static member New(paymentLink: string, ?expand: string list) =
            {
                Expand = expand
                PaymentLink = paymentLink
            }

    ///<summary><p>Retrieve a payment link.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/payment_links/{options.PaymentLink}"
        |> RestApi.getAsync<PaymentLink> settings qs

    type Update'AfterCompletionHostedConfirmation = {
        ///<summary>A custom message to display to the customer after the purchase is complete.</summary>
        [<Config.Form>]CustomMessage: string option
    }
    with
        static member New(?customMessage: string) =
            {
                CustomMessage = customMessage
            }

    type Update'AfterCompletionRedirect = {
        ///<summary>The URL the customer will be redirected to after the purchase is complete. You can embed `{CHECKOUT_SESSION_ID}` into the URL to have the `id` of the completed [checkout session](https://docs.stripe.com/api/checkout/sessions/object#checkout_session_object-id) included.</summary>
        [<Config.Form>]Url: string option
    }
    with
        static member New(?url: string) =
            {
                Url = url
            }

    type Update'AfterCompletionType =
    | HostedConfirmation
    | Redirect

    type Update'AfterCompletion = {
        ///<summary>Configuration when `type=hosted_confirmation`.</summary>
        [<Config.Form>]HostedConfirmation: Update'AfterCompletionHostedConfirmation option
        ///<summary>Configuration when `type=redirect`.</summary>
        [<Config.Form>]Redirect: Update'AfterCompletionRedirect option
        ///<summary>The specified behavior after the purchase is complete. Either `redirect` or `hosted_confirmation`.</summary>
        [<Config.Form>]Type: Update'AfterCompletionType option
    }
    with
        static member New(?hostedConfirmation: Update'AfterCompletionHostedConfirmation, ?redirect: Update'AfterCompletionRedirect, ?type': Update'AfterCompletionType) =
            {
                HostedConfirmation = hostedConfirmation
                Redirect = redirect
                Type = type'
            }

    type Update'AutomaticTaxLiabilityType =
    | Account
    | Self

    type Update'AutomaticTaxLiability = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Update'AutomaticTaxLiabilityType option
    }
    with
        static member New(?account: string, ?type': Update'AutomaticTaxLiabilityType) =
            {
                Account = account
                Type = type'
            }

    type Update'AutomaticTax = {
        ///<summary>Set to `true` to [calculate tax automatically](https://docs.stripe.com/tax) using the customer's location.
        ///Enabling this parameter causes the payment link to collect any billing address information necessary for tax calculation.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.</summary>
        [<Config.Form>]Liability: Update'AutomaticTaxLiability option
    }
    with
        static member New(?enabled: bool, ?liability: Update'AutomaticTaxLiability) =
            {
                Enabled = enabled
                Liability = liability
            }

    type Update'CustomFieldsDropdownOptions = {
        ///<summary>The label for the option, displayed to the customer. Up to 100 characters.</summary>
        [<Config.Form>]Label: string option
        ///<summary>The value for this option, not displayed to the customer, used by your integration to reconcile the option selected by the customer. Must be unique to this option, alphanumeric, and up to 100 characters.</summary>
        [<Config.Form>]Value: string option
    }
    with
        static member New(?label: string, ?value: string) =
            {
                Label = label
                Value = value
            }

    type Update'CustomFieldsDropdown = {
        ///<summary>The value that pre-fills the field on the payment page.Must match a `value` in the `options` array.</summary>
        [<Config.Form>]DefaultValue: string option
        ///<summary>The options available for the customer to select. Up to 200 options allowed.</summary>
        [<Config.Form>]Options: Update'CustomFieldsDropdownOptions list option
    }
    with
        static member New(?defaultValue: string, ?options: Update'CustomFieldsDropdownOptions list) =
            {
                DefaultValue = defaultValue
                Options = options
            }

    type Update'CustomFieldsLabelType =
    | Custom

    type Update'CustomFieldsLabel = {
        ///<summary>Custom text for the label, displayed to the customer. Up to 50 characters.</summary>
        [<Config.Form>]Custom: string option
        ///<summary>The type of the label.</summary>
        [<Config.Form>]Type: Update'CustomFieldsLabelType option
    }
    with
        static member New(?custom: string, ?type': Update'CustomFieldsLabelType) =
            {
                Custom = custom
                Type = type'
            }

    type Update'CustomFieldsNumeric = {
        ///<summary>The value that pre-fills the field on the payment page.</summary>
        [<Config.Form>]DefaultValue: string option
        ///<summary>The maximum character length constraint for the customer's input.</summary>
        [<Config.Form>]MaximumLength: int option
        ///<summary>The minimum character length requirement for the customer's input.</summary>
        [<Config.Form>]MinimumLength: int option
    }
    with
        static member New(?defaultValue: string, ?maximumLength: int, ?minimumLength: int) =
            {
                DefaultValue = defaultValue
                MaximumLength = maximumLength
                MinimumLength = minimumLength
            }

    type Update'CustomFieldsText = {
        ///<summary>The value that pre-fills the field on the payment page.</summary>
        [<Config.Form>]DefaultValue: string option
        ///<summary>The maximum character length constraint for the customer's input.</summary>
        [<Config.Form>]MaximumLength: int option
        ///<summary>The minimum character length requirement for the customer's input.</summary>
        [<Config.Form>]MinimumLength: int option
    }
    with
        static member New(?defaultValue: string, ?maximumLength: int, ?minimumLength: int) =
            {
                DefaultValue = defaultValue
                MaximumLength = maximumLength
                MinimumLength = minimumLength
            }

    type Update'CustomFieldsType =
    | Dropdown
    | Numeric
    | Text

    type Update'CustomFields = {
        ///<summary>Configuration for `type=dropdown` fields.</summary>
        [<Config.Form>]Dropdown: Update'CustomFieldsDropdown option
        ///<summary>String of your choice that your integration can use to reconcile this field. Must be unique to this field, alphanumeric, and up to 200 characters.</summary>
        [<Config.Form>]Key: string option
        ///<summary>The label for the field, displayed to the customer.</summary>
        [<Config.Form>]Label: Update'CustomFieldsLabel option
        ///<summary>Configuration for `type=numeric` fields.</summary>
        [<Config.Form>]Numeric: Update'CustomFieldsNumeric option
        ///<summary>Whether the customer is required to complete the field before completing the Checkout Session. Defaults to `false`.</summary>
        [<Config.Form>]Optional: bool option
        ///<summary>Configuration for `type=text` fields.</summary>
        [<Config.Form>]Text: Update'CustomFieldsText option
        ///<summary>The type of the field.</summary>
        [<Config.Form>]Type: Update'CustomFieldsType option
    }
    with
        static member New(?dropdown: Update'CustomFieldsDropdown, ?key: string, ?label: Update'CustomFieldsLabel, ?numeric: Update'CustomFieldsNumeric, ?optional: bool, ?text: Update'CustomFieldsText, ?type': Update'CustomFieldsType) =
            {
                Dropdown = dropdown
                Key = key
                Label = label
                Numeric = numeric
                Optional = optional
                Text = text
                Type = type'
            }

    type Update'CustomTextAfterSubmitCustomTextPosition = {
        ///<summary>Text can be up to 1200 characters in length.</summary>
        [<Config.Form>]Message: string option
    }
    with
        static member New(?message: string) =
            {
                Message = message
            }

    type Update'CustomTextShippingAddressCustomTextPosition = {
        ///<summary>Text can be up to 1200 characters in length.</summary>
        [<Config.Form>]Message: string option
    }
    with
        static member New(?message: string) =
            {
                Message = message
            }

    type Update'CustomTextSubmitCustomTextPosition = {
        ///<summary>Text can be up to 1200 characters in length.</summary>
        [<Config.Form>]Message: string option
    }
    with
        static member New(?message: string) =
            {
                Message = message
            }

    type Update'CustomTextTermsOfServiceAcceptanceCustomTextPosition = {
        ///<summary>Text can be up to 1200 characters in length.</summary>
        [<Config.Form>]Message: string option
    }
    with
        static member New(?message: string) =
            {
                Message = message
            }

    type Update'CustomText = {
        ///<summary>Custom text that should be displayed after the payment confirmation button.</summary>
        [<Config.Form>]AfterSubmit: Choice<Update'CustomTextAfterSubmitCustomTextPosition,string> option
        ///<summary>Custom text that should be displayed alongside shipping address collection.</summary>
        [<Config.Form>]ShippingAddress: Choice<Update'CustomTextShippingAddressCustomTextPosition,string> option
        ///<summary>Custom text that should be displayed alongside the payment confirmation button.</summary>
        [<Config.Form>]Submit: Choice<Update'CustomTextSubmitCustomTextPosition,string> option
        ///<summary>Custom text that should be displayed in place of the default terms of service agreement text.</summary>
        [<Config.Form>]TermsOfServiceAcceptance: Choice<Update'CustomTextTermsOfServiceAcceptanceCustomTextPosition,string> option
    }
    with
        static member New(?afterSubmit: Choice<Update'CustomTextAfterSubmitCustomTextPosition,string>, ?shippingAddress: Choice<Update'CustomTextShippingAddressCustomTextPosition,string>, ?submit: Choice<Update'CustomTextSubmitCustomTextPosition,string>, ?termsOfServiceAcceptance: Choice<Update'CustomTextTermsOfServiceAcceptanceCustomTextPosition,string>) =
            {
                AfterSubmit = afterSubmit
                ShippingAddress = shippingAddress
                Submit = submit
                TermsOfServiceAcceptance = termsOfServiceAcceptance
            }

    type Update'InvoiceCreationInvoiceDataCustomFields = {
        ///<summary>The name of the custom field. This may be up to 40 characters.</summary>
        [<Config.Form>]Name: string option
        ///<summary>The value of the custom field. This may be up to 140 characters.</summary>
        [<Config.Form>]Value: string option
    }
    with
        static member New(?name: string, ?value: string) =
            {
                Name = name
                Value = value
            }

    type Update'InvoiceCreationInvoiceDataIssuerType =
    | Account
    | Self

    type Update'InvoiceCreationInvoiceDataIssuer = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Update'InvoiceCreationInvoiceDataIssuerType option
    }
    with
        static member New(?account: string, ?type': Update'InvoiceCreationInvoiceDataIssuerType) =
            {
                Account = account
                Type = type'
            }

    type Update'InvoiceCreationInvoiceDataRenderingOptionsCheckoutRenderingOptionsAmountTaxDisplay =
    | ExcludeTax
    | IncludeInclusiveTax

    type Update'InvoiceCreationInvoiceDataRenderingOptionsCheckoutRenderingOptions = {
        ///<summary>How line-item prices and amounts will be displayed with respect to tax on invoice PDFs. One of `exclude_tax` or `include_inclusive_tax`. `include_inclusive_tax` will include inclusive tax (and exclude exclusive tax) in invoice PDF amounts. `exclude_tax` will exclude all tax (inclusive and exclusive alike) from invoice PDF amounts.</summary>
        [<Config.Form>]AmountTaxDisplay: Update'InvoiceCreationInvoiceDataRenderingOptionsCheckoutRenderingOptionsAmountTaxDisplay option
        ///<summary>ID of the invoice rendering template to use for this invoice.</summary>
        [<Config.Form>]Template: string option
    }
    with
        static member New(?amountTaxDisplay: Update'InvoiceCreationInvoiceDataRenderingOptionsCheckoutRenderingOptionsAmountTaxDisplay, ?template: string) =
            {
                AmountTaxDisplay = amountTaxDisplay
                Template = template
            }

    type Update'InvoiceCreationInvoiceData = {
        ///<summary>The account tax IDs associated with the invoice.</summary>
        [<Config.Form>]AccountTaxIds: Choice<string list,string> option
        ///<summary>Default custom fields to be displayed on invoices for this customer.</summary>
        [<Config.Form>]CustomFields: Choice<Update'InvoiceCreationInvoiceDataCustomFields list,string> option
        ///<summary>An arbitrary string attached to the object. Often useful for displaying to users.</summary>
        [<Config.Form>]Description: string option
        ///<summary>Default footer to be displayed on invoices for this customer.</summary>
        [<Config.Form>]Footer: string option
        ///<summary>The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.</summary>
        [<Config.Form>]Issuer: Update'InvoiceCreationInvoiceDataIssuer option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Default options for invoice PDF rendering for this customer.</summary>
        [<Config.Form>]RenderingOptions: Choice<Update'InvoiceCreationInvoiceDataRenderingOptionsCheckoutRenderingOptions,string> option
    }
    with
        static member New(?accountTaxIds: Choice<string list,string>, ?customFields: Choice<Update'InvoiceCreationInvoiceDataCustomFields list,string>, ?description: string, ?footer: string, ?issuer: Update'InvoiceCreationInvoiceDataIssuer, ?metadata: Map<string, string>, ?renderingOptions: Choice<Update'InvoiceCreationInvoiceDataRenderingOptionsCheckoutRenderingOptions,string>) =
            {
                AccountTaxIds = accountTaxIds
                CustomFields = customFields
                Description = description
                Footer = footer
                Issuer = issuer
                Metadata = metadata
                RenderingOptions = renderingOptions
            }

    type Update'InvoiceCreation = {
        ///<summary>Whether the feature is enabled</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>Invoice PDF configuration.</summary>
        [<Config.Form>]InvoiceData: Update'InvoiceCreationInvoiceData option
    }
    with
        static member New(?enabled: bool, ?invoiceData: Update'InvoiceCreationInvoiceData) =
            {
                Enabled = enabled
                InvoiceData = invoiceData
            }

    type Update'LineItemsAdjustableQuantity = {
        ///<summary>Set to true if the quantity can be adjusted to any non-negative Integer.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The maximum quantity the customer can purchase. By default this value is 99. You can specify a value up to 999999.</summary>
        [<Config.Form>]Maximum: int option
        ///<summary>The minimum quantity the customer can purchase. By default this value is 0. If there is only one item in the cart then that item's quantity cannot go down to 0.</summary>
        [<Config.Form>]Minimum: int option
    }
    with
        static member New(?enabled: bool, ?maximum: int, ?minimum: int) =
            {
                Enabled = enabled
                Maximum = maximum
                Minimum = minimum
            }

    type Update'LineItems = {
        ///<summary>When set, provides configuration for this item’s quantity to be adjusted by the customer during checkout.</summary>
        [<Config.Form>]AdjustableQuantity: Update'LineItemsAdjustableQuantity option
        ///<summary>The ID of an existing line item on the payment link.</summary>
        [<Config.Form>]Id: string option
        ///<summary>The quantity of the line item being purchased.</summary>
        [<Config.Form>]Quantity: int option
    }
    with
        static member New(?adjustableQuantity: Update'LineItemsAdjustableQuantity, ?id: string, ?quantity: int) =
            {
                AdjustableQuantity = adjustableQuantity
                Id = id
                Quantity = quantity
            }

    type Update'NameCollectionNameCollectionParamsBusiness = {
        ///<summary>Enable business name collection on the payment link. Defaults to `false`.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>Whether the customer is required to provide their business name before checking out. Defaults to `false`.</summary>
        [<Config.Form>]Optional: bool option
    }
    with
        static member New(?enabled: bool, ?optional: bool) =
            {
                Enabled = enabled
                Optional = optional
            }

    type Update'NameCollectionNameCollectionParamsIndividual = {
        ///<summary>Enable individual name collection on the payment link. Defaults to `false`.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>Whether the customer is required to provide their full name before checking out. Defaults to `false`.</summary>
        [<Config.Form>]Optional: bool option
    }
    with
        static member New(?enabled: bool, ?optional: bool) =
            {
                Enabled = enabled
                Optional = optional
            }

    type Update'NameCollectionNameCollectionParams = {
        ///<summary>Controls settings applied for collecting the customer's business name.</summary>
        [<Config.Form>]Business: Update'NameCollectionNameCollectionParamsBusiness option
        ///<summary>Controls settings applied for collecting the customer's individual name.</summary>
        [<Config.Form>]Individual: Update'NameCollectionNameCollectionParamsIndividual option
    }
    with
        static member New(?business: Update'NameCollectionNameCollectionParamsBusiness, ?individual: Update'NameCollectionNameCollectionParamsIndividual) =
            {
                Business = business
                Individual = individual
            }

    type Update'OptionalItemsAdjustableQuantity = {
        ///<summary>Set to true if the quantity can be adjusted to any non-negative integer.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The maximum quantity of this item the customer can purchase. By default this value is 99.</summary>
        [<Config.Form>]Maximum: int option
        ///<summary>The minimum quantity of this item the customer must purchase, if they choose to purchase it. Because this item is optional, the customer will always be able to remove it from their order, even if the `minimum` configured here is greater than 0. By default this value is 0.</summary>
        [<Config.Form>]Minimum: int option
    }
    with
        static member New(?enabled: bool, ?maximum: int, ?minimum: int) =
            {
                Enabled = enabled
                Maximum = maximum
                Minimum = minimum
            }

    type Update'OptionalItems = {
        ///<summary>When set, provides configuration for the customer to adjust the quantity of the line item created when a customer chooses to add this optional item to their order.</summary>
        [<Config.Form>]AdjustableQuantity: Update'OptionalItemsAdjustableQuantity option
        ///<summary>The ID of the [Price](https://docs.stripe.com/api/prices) or [Plan](https://docs.stripe.com/api/plans) object.</summary>
        [<Config.Form>]Price: string option
        ///<summary>The initial quantity of the line item created when a customer chooses to add this optional item to their order.</summary>
        [<Config.Form>]Quantity: int option
    }
    with
        static member New(?adjustableQuantity: Update'OptionalItemsAdjustableQuantity, ?price: string, ?quantity: int) =
            {
                AdjustableQuantity = adjustableQuantity
                Price = price
                Quantity = quantity
            }

    type Update'PaymentIntentData = {
        ///<summary>An arbitrary string attached to the object. Often useful for displaying to users.</summary>
        [<Config.Form>]Description: Choice<string,string> option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that will declaratively set metadata on [Payment Intents](https://docs.stripe.com/api/payment_intents) generated from this payment link. Unlike object-level metadata, this field is declarative. Updates will clear prior values.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Text that appears on the customer's statement as the statement descriptor for a non-card charge. This value overrides the account's default statement descriptor. For information about requirements, including the 22-character limit, see [the Statement Descriptor docs](https://docs.stripe.com/get-started/account/statement-descriptors).
        ///Setting this value for a card charge returns an error. For card charges, set the [statement_descriptor_suffix](https://docs.stripe.com/get-started/account/statement-descriptors#dynamic) instead.</summary>
        [<Config.Form>]StatementDescriptor: Choice<string,string> option
        ///<summary>Provides information about a card charge. Concatenated to the account's [statement descriptor prefix](https://docs.stripe.com/get-started/account/statement-descriptors#static) to form the complete statement descriptor that appears on the customer's statement.</summary>
        [<Config.Form>]StatementDescriptorSuffix: Choice<string,string> option
        ///<summary>A string that identifies the resulting payment as part of a group. See the PaymentIntents [use case for connected accounts](https://docs.stripe.com/connect/separate-charges-and-transfers) for details.</summary>
        [<Config.Form>]TransferGroup: Choice<string,string> option
    }
    with
        static member New(?description: Choice<string,string>, ?metadata: Map<string, string>, ?statementDescriptor: Choice<string,string>, ?statementDescriptorSuffix: Choice<string,string>, ?transferGroup: Choice<string,string>) =
            {
                Description = description
                Metadata = metadata
                StatementDescriptor = statementDescriptor
                StatementDescriptorSuffix = statementDescriptorSuffix
                TransferGroup = transferGroup
            }

    type Update'PaymentMethodTypes =
    | Affirm
    | AfterpayClearpay
    | Alipay
    | Alma
    | AuBecsDebit
    | BacsDebit
    | Bancontact
    | Billie
    | Blik
    | Boleto
    | Card
    | Cashapp
    | Eps
    | Fpx
    | Giropay
    | Grabpay
    | Ideal
    | Klarna
    | Konbini
    | Link
    | MbWay
    | Mobilepay
    | Multibanco
    | Oxxo
    | P24
    | PayByBank
    | Paynow
    | Paypal
    | Payto
    | Pix
    | Promptpay
    | Satispay
    | SepaDebit
    | Sofort
    | Sunbit
    | Swish
    | Twint
    | Upi
    | UsBankAccount
    | WechatPay
    | Zip

    type Update'PhoneNumberCollection = {
        ///<summary>Set to `true` to enable phone number collection.</summary>
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Update'RestrictionsRestrictionsParamsCompletedSessions = {
        ///<summary>The maximum number of checkout sessions that can be completed for the `completed_sessions` restriction to be met.</summary>
        [<Config.Form>]Limit: int option
    }
    with
        static member New(?limit: int) =
            {
                Limit = limit
            }

    type Update'RestrictionsRestrictionsParams = {
        ///<summary>Configuration for the `completed_sessions` restriction type.</summary>
        [<Config.Form>]CompletedSessions: Update'RestrictionsRestrictionsParamsCompletedSessions option
    }
    with
        static member New(?completedSessions: Update'RestrictionsRestrictionsParamsCompletedSessions) =
            {
                CompletedSessions = completedSessions
            }

    type Update'ShippingAddressCollectionShippingAddressCollectionParamsAllowedCountries =
    | [<JsonPropertyName("AC")>] AC
    | [<JsonPropertyName("AD")>] AD
    | [<JsonPropertyName("AE")>] AE
    | [<JsonPropertyName("AF")>] AF
    | [<JsonPropertyName("AG")>] AG
    | [<JsonPropertyName("AI")>] AI
    | [<JsonPropertyName("AL")>] AL
    | [<JsonPropertyName("AM")>] AM
    | [<JsonPropertyName("AO")>] AO
    | [<JsonPropertyName("AQ")>] AQ
    | [<JsonPropertyName("AR")>] AR
    | [<JsonPropertyName("AT")>] AT
    | [<JsonPropertyName("AU")>] AU
    | [<JsonPropertyName("AW")>] AW
    | [<JsonPropertyName("AX")>] AX
    | [<JsonPropertyName("AZ")>] AZ
    | [<JsonPropertyName("BA")>] BA
    | [<JsonPropertyName("BB")>] BB
    | [<JsonPropertyName("BD")>] BD
    | [<JsonPropertyName("BE")>] BE
    | [<JsonPropertyName("BF")>] BF
    | [<JsonPropertyName("BG")>] BG
    | [<JsonPropertyName("BH")>] BH
    | [<JsonPropertyName("BI")>] BI
    | [<JsonPropertyName("BJ")>] BJ
    | [<JsonPropertyName("BL")>] BL
    | [<JsonPropertyName("BM")>] BM
    | [<JsonPropertyName("BN")>] BN
    | [<JsonPropertyName("BO")>] BO
    | [<JsonPropertyName("BQ")>] BQ
    | [<JsonPropertyName("BR")>] BR
    | [<JsonPropertyName("BS")>] BS
    | [<JsonPropertyName("BT")>] BT
    | [<JsonPropertyName("BV")>] BV
    | [<JsonPropertyName("BW")>] BW
    | [<JsonPropertyName("BY")>] BY
    | [<JsonPropertyName("BZ")>] BZ
    | [<JsonPropertyName("CA")>] CA
    | [<JsonPropertyName("CD")>] CD
    | [<JsonPropertyName("CF")>] CF
    | [<JsonPropertyName("CG")>] CG
    | [<JsonPropertyName("CH")>] CH
    | [<JsonPropertyName("CI")>] CI
    | [<JsonPropertyName("CK")>] CK
    | [<JsonPropertyName("CL")>] CL
    | [<JsonPropertyName("CM")>] CM
    | [<JsonPropertyName("CN")>] CN
    | [<JsonPropertyName("CO")>] CO
    | [<JsonPropertyName("CR")>] CR
    | [<JsonPropertyName("CV")>] CV
    | [<JsonPropertyName("CW")>] CW
    | [<JsonPropertyName("CY")>] CY
    | [<JsonPropertyName("CZ")>] CZ
    | [<JsonPropertyName("DE")>] DE
    | [<JsonPropertyName("DJ")>] DJ
    | [<JsonPropertyName("DK")>] DK
    | [<JsonPropertyName("DM")>] DM
    | [<JsonPropertyName("DO")>] DO
    | [<JsonPropertyName("DZ")>] DZ
    | [<JsonPropertyName("EC")>] EC
    | [<JsonPropertyName("EE")>] EE
    | [<JsonPropertyName("EG")>] EG
    | [<JsonPropertyName("EH")>] EH
    | [<JsonPropertyName("ER")>] ER
    | [<JsonPropertyName("ES")>] ES
    | [<JsonPropertyName("ET")>] ET
    | [<JsonPropertyName("FI")>] FI
    | [<JsonPropertyName("FJ")>] FJ
    | [<JsonPropertyName("FK")>] FK
    | [<JsonPropertyName("FO")>] FO
    | [<JsonPropertyName("FR")>] FR
    | [<JsonPropertyName("GA")>] GA
    | [<JsonPropertyName("GB")>] GB
    | [<JsonPropertyName("GD")>] GD
    | [<JsonPropertyName("GE")>] GE
    | [<JsonPropertyName("GF")>] GF
    | [<JsonPropertyName("GG")>] GG
    | [<JsonPropertyName("GH")>] GH
    | [<JsonPropertyName("GI")>] GI
    | [<JsonPropertyName("GL")>] GL
    | [<JsonPropertyName("GM")>] GM
    | [<JsonPropertyName("GN")>] GN
    | [<JsonPropertyName("GP")>] GP
    | [<JsonPropertyName("GQ")>] GQ
    | [<JsonPropertyName("GR")>] GR
    | [<JsonPropertyName("GS")>] GS
    | [<JsonPropertyName("GT")>] GT
    | [<JsonPropertyName("GU")>] GU
    | [<JsonPropertyName("GW")>] GW
    | [<JsonPropertyName("GY")>] GY
    | [<JsonPropertyName("HK")>] HK
    | [<JsonPropertyName("HN")>] HN
    | [<JsonPropertyName("HR")>] HR
    | [<JsonPropertyName("HT")>] HT
    | [<JsonPropertyName("HU")>] HU
    | [<JsonPropertyName("ID")>] ID
    | [<JsonPropertyName("IE")>] IE
    | [<JsonPropertyName("IL")>] IL
    | [<JsonPropertyName("IM")>] IM
    | [<JsonPropertyName("IN")>] IN
    | [<JsonPropertyName("IO")>] IO
    | [<JsonPropertyName("IQ")>] IQ
    | [<JsonPropertyName("IS")>] IS
    | [<JsonPropertyName("IT")>] IT
    | [<JsonPropertyName("JE")>] JE
    | [<JsonPropertyName("JM")>] JM
    | [<JsonPropertyName("JO")>] JO
    | [<JsonPropertyName("JP")>] JP
    | [<JsonPropertyName("KE")>] KE
    | [<JsonPropertyName("KG")>] KG
    | [<JsonPropertyName("KH")>] KH
    | [<JsonPropertyName("KI")>] KI
    | [<JsonPropertyName("KM")>] KM
    | [<JsonPropertyName("KN")>] KN
    | [<JsonPropertyName("KR")>] KR
    | [<JsonPropertyName("KW")>] KW
    | [<JsonPropertyName("KY")>] KY
    | [<JsonPropertyName("KZ")>] KZ
    | [<JsonPropertyName("LA")>] LA
    | [<JsonPropertyName("LB")>] LB
    | [<JsonPropertyName("LC")>] LC
    | [<JsonPropertyName("LI")>] LI
    | [<JsonPropertyName("LK")>] LK
    | [<JsonPropertyName("LR")>] LR
    | [<JsonPropertyName("LS")>] LS
    | [<JsonPropertyName("LT")>] LT
    | [<JsonPropertyName("LU")>] LU
    | [<JsonPropertyName("LV")>] LV
    | [<JsonPropertyName("LY")>] LY
    | [<JsonPropertyName("MA")>] MA
    | [<JsonPropertyName("MC")>] MC
    | [<JsonPropertyName("MD")>] MD
    | [<JsonPropertyName("ME")>] ME
    | [<JsonPropertyName("MF")>] MF
    | [<JsonPropertyName("MG")>] MG
    | [<JsonPropertyName("MK")>] MK
    | [<JsonPropertyName("ML")>] ML
    | [<JsonPropertyName("MM")>] MM
    | [<JsonPropertyName("MN")>] MN
    | [<JsonPropertyName("MO")>] MO
    | [<JsonPropertyName("MQ")>] MQ
    | [<JsonPropertyName("MR")>] MR
    | [<JsonPropertyName("MS")>] MS
    | [<JsonPropertyName("MT")>] MT
    | [<JsonPropertyName("MU")>] MU
    | [<JsonPropertyName("MV")>] MV
    | [<JsonPropertyName("MW")>] MW
    | [<JsonPropertyName("MX")>] MX
    | [<JsonPropertyName("MY")>] MY
    | [<JsonPropertyName("MZ")>] MZ
    | [<JsonPropertyName("NA")>] NA
    | [<JsonPropertyName("NC")>] NC
    | [<JsonPropertyName("NE")>] NE
    | [<JsonPropertyName("NG")>] NG
    | [<JsonPropertyName("NI")>] NI
    | [<JsonPropertyName("NL")>] NL
    | [<JsonPropertyName("NO")>] NO
    | [<JsonPropertyName("NP")>] NP
    | [<JsonPropertyName("NR")>] NR
    | [<JsonPropertyName("NU")>] NU
    | [<JsonPropertyName("NZ")>] NZ
    | [<JsonPropertyName("OM")>] OM
    | [<JsonPropertyName("PA")>] PA
    | [<JsonPropertyName("PE")>] PE
    | [<JsonPropertyName("PF")>] PF
    | [<JsonPropertyName("PG")>] PG
    | [<JsonPropertyName("PH")>] PH
    | [<JsonPropertyName("PK")>] PK
    | [<JsonPropertyName("PL")>] PL
    | [<JsonPropertyName("PM")>] PM
    | [<JsonPropertyName("PN")>] PN
    | [<JsonPropertyName("PR")>] PR
    | [<JsonPropertyName("PS")>] PS
    | [<JsonPropertyName("PT")>] PT
    | [<JsonPropertyName("PY")>] PY
    | [<JsonPropertyName("QA")>] QA
    | [<JsonPropertyName("RE")>] RE
    | [<JsonPropertyName("RO")>] RO
    | [<JsonPropertyName("RS")>] RS
    | [<JsonPropertyName("RU")>] RU
    | [<JsonPropertyName("RW")>] RW
    | [<JsonPropertyName("SA")>] SA
    | [<JsonPropertyName("SB")>] SB
    | [<JsonPropertyName("SC")>] SC
    | [<JsonPropertyName("SD")>] SD
    | [<JsonPropertyName("SE")>] SE
    | [<JsonPropertyName("SG")>] SG
    | [<JsonPropertyName("SH")>] SH
    | [<JsonPropertyName("SI")>] SI
    | [<JsonPropertyName("SJ")>] SJ
    | [<JsonPropertyName("SK")>] SK
    | [<JsonPropertyName("SL")>] SL
    | [<JsonPropertyName("SM")>] SM
    | [<JsonPropertyName("SN")>] SN
    | [<JsonPropertyName("SO")>] SO
    | [<JsonPropertyName("SR")>] SR
    | [<JsonPropertyName("SS")>] SS
    | [<JsonPropertyName("ST")>] ST
    | [<JsonPropertyName("SV")>] SV
    | [<JsonPropertyName("SX")>] SX
    | [<JsonPropertyName("SZ")>] SZ
    | [<JsonPropertyName("TA")>] TA
    | [<JsonPropertyName("TC")>] TC
    | [<JsonPropertyName("TD")>] TD
    | [<JsonPropertyName("TF")>] TF
    | [<JsonPropertyName("TG")>] TG
    | [<JsonPropertyName("TH")>] TH
    | [<JsonPropertyName("TJ")>] TJ
    | [<JsonPropertyName("TK")>] TK
    | [<JsonPropertyName("TL")>] TL
    | [<JsonPropertyName("TM")>] TM
    | [<JsonPropertyName("TN")>] TN
    | [<JsonPropertyName("TO")>] TO
    | [<JsonPropertyName("TR")>] TR
    | [<JsonPropertyName("TT")>] TT
    | [<JsonPropertyName("TV")>] TV
    | [<JsonPropertyName("TW")>] TW
    | [<JsonPropertyName("TZ")>] TZ
    | [<JsonPropertyName("UA")>] UA
    | [<JsonPropertyName("UG")>] UG
    | [<JsonPropertyName("US")>] US
    | [<JsonPropertyName("UY")>] UY
    | [<JsonPropertyName("UZ")>] UZ
    | [<JsonPropertyName("VA")>] VA
    | [<JsonPropertyName("VC")>] VC
    | [<JsonPropertyName("VE")>] VE
    | [<JsonPropertyName("VG")>] VG
    | [<JsonPropertyName("VN")>] VN
    | [<JsonPropertyName("VU")>] VU
    | [<JsonPropertyName("WF")>] WF
    | [<JsonPropertyName("WS")>] WS
    | [<JsonPropertyName("XK")>] XK
    | [<JsonPropertyName("YE")>] YE
    | [<JsonPropertyName("YT")>] YT
    | [<JsonPropertyName("ZA")>] ZA
    | [<JsonPropertyName("ZM")>] ZM
    | [<JsonPropertyName("ZW")>] ZW
    | [<JsonPropertyName("ZZ")>] ZZ

    type Update'ShippingAddressCollectionShippingAddressCollectionParams = {
        ///<summary>An array of two-letter ISO country codes representing which countries Checkout should provide as options for
        ///shipping locations.</summary>
        [<Config.Form>]AllowedCountries: Update'ShippingAddressCollectionShippingAddressCollectionParamsAllowedCountries list option
    }
    with
        static member New(?allowedCountries: Update'ShippingAddressCollectionShippingAddressCollectionParamsAllowedCountries list) =
            {
                AllowedCountries = allowedCountries
            }

    type Update'SubscriptionDataInvoiceSettingsIssuerType =
    | Account
    | Self

    type Update'SubscriptionDataInvoiceSettingsIssuer = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Update'SubscriptionDataInvoiceSettingsIssuerType option
    }
    with
        static member New(?account: string, ?type': Update'SubscriptionDataInvoiceSettingsIssuerType) =
            {
                Account = account
                Type = type'
            }

    type Update'SubscriptionDataInvoiceSettings = {
        ///<summary>The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.</summary>
        [<Config.Form>]Issuer: Update'SubscriptionDataInvoiceSettingsIssuer option
    }
    with
        static member New(?issuer: Update'SubscriptionDataInvoiceSettingsIssuer) =
            {
                Issuer = issuer
            }

    type Update'SubscriptionDataTrialSettingsTrialSettingsConfigEndBehaviorMissingPaymentMethod =
    | Cancel
    | CreateInvoice
    | Pause

    type Update'SubscriptionDataTrialSettingsTrialSettingsConfigEndBehavior = {
        ///<summary>Indicates how the subscription should change when the trial ends if the user did not provide a payment method.</summary>
        [<Config.Form>]MissingPaymentMethod: Update'SubscriptionDataTrialSettingsTrialSettingsConfigEndBehaviorMissingPaymentMethod option
    }
    with
        static member New(?missingPaymentMethod: Update'SubscriptionDataTrialSettingsTrialSettingsConfigEndBehaviorMissingPaymentMethod) =
            {
                MissingPaymentMethod = missingPaymentMethod
            }

    type Update'SubscriptionDataTrialSettingsTrialSettingsConfig = {
        ///<summary>Defines how the subscription should behave when the user's free trial ends.</summary>
        [<Config.Form>]EndBehavior: Update'SubscriptionDataTrialSettingsTrialSettingsConfigEndBehavior option
    }
    with
        static member New(?endBehavior: Update'SubscriptionDataTrialSettingsTrialSettingsConfigEndBehavior) =
            {
                EndBehavior = endBehavior
            }

    type Update'SubscriptionData = {
        ///<summary>All invoices will be billed using the specified settings.</summary>
        [<Config.Form>]InvoiceSettings: Update'SubscriptionDataInvoiceSettings option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that will declaratively set metadata on [Subscriptions](https://docs.stripe.com/api/subscriptions) generated from this payment link. Unlike object-level metadata, this field is declarative. Updates will clear prior values.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Integer representing the number of trial period days before the customer is charged for the first time. Has to be at least 1.</summary>
        [<Config.Form>]TrialPeriodDays: Choice<int,string> option
        ///<summary>Settings related to subscription trials.</summary>
        [<Config.Form>]TrialSettings: Choice<Update'SubscriptionDataTrialSettingsTrialSettingsConfig,string> option
    }
    with
        static member New(?invoiceSettings: Update'SubscriptionDataInvoiceSettings, ?metadata: Map<string, string>, ?trialPeriodDays: Choice<int,string>, ?trialSettings: Choice<Update'SubscriptionDataTrialSettingsTrialSettingsConfig,string>) =
            {
                InvoiceSettings = invoiceSettings
                Metadata = metadata
                TrialPeriodDays = trialPeriodDays
                TrialSettings = trialSettings
            }

    type Update'TaxIdCollectionRequired =
    | IfSupported
    | Never

    type Update'TaxIdCollection = {
        ///<summary>Enable tax ID collection during checkout. Defaults to `false`.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>Describes whether a tax ID is required during checkout. Defaults to `never`. You can't set this parameter if `ui_mode` is `custom`.</summary>
        [<Config.Form>]Required: Update'TaxIdCollectionRequired option
    }
    with
        static member New(?enabled: bool, ?required: Update'TaxIdCollectionRequired) =
            {
                Enabled = enabled
                Required = required
            }

    type Update'BillingAddressCollection =
    | Auto
    | Required

    type Update'CustomerCreation =
    | Always
    | IfRequired

    type Update'PaymentMethodCollection =
    | Always
    | IfRequired

    type Update'SubmitType =
    | Auto
    | Book
    | Donate
    | Pay
    | Subscribe

    type UpdateOptions = {
        [<Config.Path>]PaymentLink: string
        ///<summary>Whether the payment link's `url` is active. If `false`, customers visiting the URL will be shown a page saying that the link has been deactivated.</summary>
        [<Config.Form>]Active: bool option
        ///<summary>Behavior after the purchase is complete.</summary>
        [<Config.Form>]AfterCompletion: Update'AfterCompletion option
        ///<summary>Enables user redeemable promotion codes.</summary>
        [<Config.Form>]AllowPromotionCodes: bool option
        ///<summary>Configuration for automatic tax collection.</summary>
        [<Config.Form>]AutomaticTax: Update'AutomaticTax option
        ///<summary>Configuration for collecting the customer's billing address. Defaults to `auto`.</summary>
        [<Config.Form>]BillingAddressCollection: Update'BillingAddressCollection option
        ///<summary>Collect additional information from your customer using custom fields. Up to 3 fields are supported. You can't set this parameter if `ui_mode` is `custom`.</summary>
        [<Config.Form>]CustomFields: Choice<Update'CustomFields list,string> option
        ///<summary>Display additional text for your customers using custom text. You can't set this parameter if `ui_mode` is `custom`.</summary>
        [<Config.Form>]CustomText: Update'CustomText option
        ///<summary>Configures whether [checkout sessions](https://docs.stripe.com/api/checkout/sessions) created by this payment link create a [Customer](https://docs.stripe.com/api/customers).</summary>
        [<Config.Form>]CustomerCreation: Update'CustomerCreation option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The custom message to be displayed to a customer when a payment link is no longer active.</summary>
        [<Config.Form>]InactiveMessage: Choice<string,string> option
        ///<summary>Generate a post-purchase Invoice for one-time payments.</summary>
        [<Config.Form>]InvoiceCreation: Update'InvoiceCreation option
        ///<summary>The line items representing what is being sold. Each line item represents an item being sold. Up to 20 line items are supported.</summary>
        [<Config.Form>]LineItems: Update'LineItems list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`. Metadata associated with this Payment Link will automatically be copied to [checkout sessions](https://docs.stripe.com/api/checkout/sessions) created by this payment link.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Controls settings applied for collecting the customer's name.</summary>
        [<Config.Form>]NameCollection: Choice<Update'NameCollectionNameCollectionParams,string> option
        ///<summary>A list of optional items the customer can add to their order at checkout. Use this parameter to pass one-time or recurring [Prices](https://docs.stripe.com/api/prices).
        ///There is a maximum of 10 optional items allowed on a payment link, and the existing limits on the number of line items allowed on a payment link apply to the combined number of line items and optional items.
        ///There is a maximum of 20 combined line items and optional items.</summary>
        [<Config.Form>]OptionalItems: Choice<Update'OptionalItems list,string> option
        ///<summary>A subset of parameters to be passed to PaymentIntent creation for Checkout Sessions in `payment` mode.</summary>
        [<Config.Form>]PaymentIntentData: Update'PaymentIntentData option
        ///<summary>Specify whether Checkout should collect a payment method. When set to `if_required`, Checkout will not collect a payment method when the total due for the session is 0.This may occur if the Checkout Session includes a free trial or a discount.
        ///Can only be set in `subscription` mode. Defaults to `always`.
        ///If you'd like information on how to collect a payment method outside of Checkout, read the guide on [configuring subscriptions with a free trial](https://docs.stripe.com/payments/checkout/free-trials).</summary>
        [<Config.Form>]PaymentMethodCollection: Update'PaymentMethodCollection option
        ///<summary>The list of payment method types that customers can use. Pass an empty string to enable dynamic payment methods that use your [payment method settings](https://dashboard.stripe.com/settings/payment_methods).</summary>
        [<Config.Form>]PaymentMethodTypes: Choice<Update'PaymentMethodTypes list,string> option
        ///<summary>Controls phone number collection settings during checkout.
        ///We recommend that you review your privacy policy and check with your legal contacts.</summary>
        [<Config.Form>]PhoneNumberCollection: Update'PhoneNumberCollection option
        ///<summary>Settings that restrict the usage of a payment link.</summary>
        [<Config.Form>]Restrictions: Choice<Update'RestrictionsRestrictionsParams,string> option
        ///<summary>Configuration for collecting the customer's shipping address.</summary>
        [<Config.Form>]ShippingAddressCollection: Choice<Update'ShippingAddressCollectionShippingAddressCollectionParams,string> option
        ///<summary>Describes the type of transaction being performed in order to customize relevant text on the page, such as the submit button. Changing this value will also affect the hostname in the [url](https://docs.stripe.com/api/payment_links/payment_links/object#url) property (example: `donate.stripe.com`).</summary>
        [<Config.Form>]SubmitType: Update'SubmitType option
        ///<summary>When creating a subscription, the specified configuration data will be used. There must be at least one line item with a recurring price to use `subscription_data`.</summary>
        [<Config.Form>]SubscriptionData: Update'SubscriptionData option
        ///<summary>Controls tax ID collection during checkout.</summary>
        [<Config.Form>]TaxIdCollection: Update'TaxIdCollection option
    }
    with
        static member New(paymentLink: string, ?submitType: Update'SubmitType, ?shippingAddressCollection: Choice<Update'ShippingAddressCollectionShippingAddressCollectionParams,string>, ?restrictions: Choice<Update'RestrictionsRestrictionsParams,string>, ?phoneNumberCollection: Update'PhoneNumberCollection, ?paymentMethodTypes: Choice<Update'PaymentMethodTypes list,string>, ?paymentMethodCollection: Update'PaymentMethodCollection, ?paymentIntentData: Update'PaymentIntentData, ?optionalItems: Choice<Update'OptionalItems list,string>, ?nameCollection: Choice<Update'NameCollectionNameCollectionParams,string>, ?metadata: Map<string, string>, ?subscriptionData: Update'SubscriptionData, ?lineItems: Update'LineItems list, ?inactiveMessage: Choice<string,string>, ?expand: string list, ?customerCreation: Update'CustomerCreation, ?customText: Update'CustomText, ?customFields: Choice<Update'CustomFields list,string>, ?billingAddressCollection: Update'BillingAddressCollection, ?automaticTax: Update'AutomaticTax, ?allowPromotionCodes: bool, ?afterCompletion: Update'AfterCompletion, ?active: bool, ?invoiceCreation: Update'InvoiceCreation, ?taxIdCollection: Update'TaxIdCollection) =
            {
                PaymentLink = paymentLink
                Active = active
                AfterCompletion = afterCompletion
                AllowPromotionCodes = allowPromotionCodes
                AutomaticTax = automaticTax
                BillingAddressCollection = billingAddressCollection
                CustomFields = customFields
                CustomText = customText
                CustomerCreation = customerCreation
                Expand = expand
                InactiveMessage = inactiveMessage
                InvoiceCreation = invoiceCreation
                LineItems = lineItems
                Metadata = metadata
                NameCollection = nameCollection
                OptionalItems = optionalItems
                PaymentIntentData = paymentIntentData
                PaymentMethodCollection = paymentMethodCollection
                PaymentMethodTypes = paymentMethodTypes
                PhoneNumberCollection = phoneNumberCollection
                Restrictions = restrictions
                ShippingAddressCollection = shippingAddressCollection
                SubmitType = submitType
                SubscriptionData = subscriptionData
                TaxIdCollection = taxIdCollection
            }

    ///<summary><p>Updates a payment link.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/payment_links/{options.PaymentLink}"
        |> RestApi.postAsync<_, PaymentLink> settings (Map.empty) options

module PaymentLinksLineItems =

    type ListLineItemsOptions = {
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        [<Config.Path>]PaymentLink: string
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(paymentLink: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                PaymentLink = paymentLink
                StartingAfter = startingAfter
            }

    ///<summary><p>When retrieving a payment link, there is an includable <strong>line_items</strong> property containing the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p></summary>
    let ListLineItems settings (options: ListLineItemsOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/payment_links/{options.PaymentLink}/line_items"
        |> RestApi.getAsync<StripeList<Item>> settings qs
