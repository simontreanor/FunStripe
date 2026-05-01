namespace StripeRequest.Checkout

open FunStripe
open System.Text.Json.Serialization
open Stripe.Checkout
open Stripe.PaymentMethod
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
module CheckoutSessions =

    type ListOptions =
        {
            /// Only return Checkout Sessions that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            /// Only return the Checkout Sessions for the Customer specified.
            [<Config.Query>]
            Customer: string option
            /// Only return the Checkout Sessions for the Account specified.
            [<Config.Query>]
            CustomerAccount: string option
            /// Only return the Checkout Sessions for the Customer details specified.
            [<Config.Query>]
            CustomerDetails: Map<string, string> option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// Only return the Checkout Session for the PaymentIntent specified.
            [<Config.Query>]
            PaymentIntent: string option
            /// Only return the Checkout Sessions for the Payment Link specified.
            [<Config.Query>]
            PaymentLink: string option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Only return the Checkout Sessions matching the given status.
            [<Config.Query>]
            Status: string option
            /// Only return the Checkout Session for the subscription specified.
            [<Config.Query>]
            Subscription: string option
        }

    type ListOptions with
        static member New(?created: int, ?customer: string, ?customerAccount: string, ?customerDetails: Map<string, string>, ?endingBefore: string, ?expand: string list, ?limit: int, ?paymentIntent: string, ?paymentLink: string, ?startingAfter: string, ?status: string, ?subscription: string) =
            {
                Created = created
                Customer = customer
                CustomerAccount = customerAccount
                CustomerDetails = customerDetails
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                PaymentIntent = paymentIntent
                PaymentLink = paymentLink
                StartingAfter = startingAfter
                Status = status
                Subscription = subscription
            }

    type Create'AdaptivePricing =
        {
            /// If set to `true`, Adaptive Pricing is available on [eligible sessions](https://docs.stripe.com/payments/currencies/localize-prices/adaptive-pricing?payment-ui=stripe-hosted#restrictions). Defaults to your [dashboard setting](https://dashboard.stripe.com/settings/adaptive-pricing).
            [<Config.Form>]
            Enabled: bool option
        }

    type Create'AdaptivePricing with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Create'AfterExpirationRecovery =
        {
            /// Enables user redeemable promotion codes on the recovered Checkout Sessions. Defaults to `false`
            [<Config.Form>]
            AllowPromotionCodes: bool option
            /// If `true`, a recovery URL will be generated to recover this Checkout Session if it
            /// expires before a successful transaction is completed. It will be attached to the
            /// Checkout Session object upon expiration.
            [<Config.Form>]
            Enabled: bool option
        }

    type Create'AfterExpirationRecovery with
        static member New(?allowPromotionCodes: bool, ?enabled: bool) =
            {
                AllowPromotionCodes = allowPromotionCodes
                Enabled = enabled
            }

    type Create'AfterExpiration =
        {
            /// Configure a Checkout Session that can be used to recover an expired session.
            [<Config.Form>]
            Recovery: Create'AfterExpirationRecovery option
        }

    type Create'AfterExpiration with
        static member New(?recovery: Create'AfterExpirationRecovery) =
            {
                Recovery = recovery
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

    type Create'AutomaticTaxLiability with
        static member New(?account: string, ?type': Create'AutomaticTaxLiabilityType) =
            {
                Account = account
                Type = type'
            }

    type Create'AutomaticTax =
        {
            /// Set to `true` to [calculate tax automatically](https://docs.stripe.com/tax) using the customer's location.
            /// Enabling this parameter causes Checkout to collect any billing address information necessary for tax calculation.
            [<Config.Form>]
            Enabled: bool option
            /// The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.
            [<Config.Form>]
            Liability: Create'AutomaticTaxLiability option
        }

    type Create'AutomaticTax with
        static member New(?enabled: bool, ?liability: Create'AutomaticTaxLiability) =
            {
                Enabled = enabled
                Liability = liability
            }

    type Create'BillingAddressCollection =
        | Auto
        | Required

    type Create'BrandingSettingsBorderStyle =
        | Pill
        | Rectangular
        | Rounded

    type Create'BrandingSettingsFontFamily =
        | BeVietnamPro
        | Bitter
        | ChakraPetch
        | Default
        | Hahmlet
        | Inconsolata
        | Inter
        | Lato
        | Lora
        | MPlus1Code
        | Montserrat
        | NotoSans
        | NotoSansJp
        | NotoSerif
        | Nunito
        | OpenSans
        | Pridi
        | PtSans
        | PtSerif
        | Raleway
        | Roboto
        | RobotoSlab
        | SourceSansPro
        | TitilliumWeb
        | UbuntuMono
        | ZenMaruGothic

    type Create'BrandingSettingsIconType =
        | File
        | Url

    type Create'BrandingSettingsIcon =
        {
            /// The ID of a [File upload](https://stripe.com/docs/api/files) representing the icon. Purpose must be `business_icon`. Required if `type` is `file` and disallowed otherwise.
            [<Config.Form>]
            File: string option
            /// The type of image for the icon. Must be one of `file` or `url`.
            [<Config.Form>]
            Type: Create'BrandingSettingsIconType option
            /// The URL of the image. Required if `type` is `url` and disallowed otherwise.
            [<Config.Form>]
            Url: string option
        }

    type Create'BrandingSettingsIcon with
        static member New(?file: string, ?type': Create'BrandingSettingsIconType, ?url: string) =
            {
                File = file
                Type = type'
                Url = url
            }

    type Create'BrandingSettingsLogoType =
        | File
        | Url

    type Create'BrandingSettingsLogo =
        {
            /// The ID of a [File upload](https://stripe.com/docs/api/files) representing the logo. Purpose must be `business_logo`. Required if `type` is `file` and disallowed otherwise.
            [<Config.Form>]
            File: string option
            /// The type of image for the logo. Must be one of `file` or `url`.
            [<Config.Form>]
            Type: Create'BrandingSettingsLogoType option
            /// The URL of the image. Required if `type` is `url` and disallowed otherwise.
            [<Config.Form>]
            Url: string option
        }

    type Create'BrandingSettingsLogo with
        static member New(?file: string, ?type': Create'BrandingSettingsLogoType, ?url: string) =
            {
                File = file
                Type = type'
                Url = url
            }

    type Create'BrandingSettings =
        {
            /// A hex color value starting with `#` representing the background color for the Checkout Session.
            [<Config.Form>]
            BackgroundColor: Choice<string,string> option
            /// The border style for the Checkout Session.
            [<Config.Form>]
            BorderStyle: Create'BrandingSettingsBorderStyle option
            /// A hex color value starting with `#` representing the button color for the Checkout Session.
            [<Config.Form>]
            ButtonColor: Choice<string,string> option
            /// A string to override the business name shown on the Checkout Session. This only shows at the top of the Checkout page, and your business name still appears in terms, receipts, and other places.
            [<Config.Form>]
            DisplayName: string option
            /// The font family for the Checkout Session corresponding to one of the [supported font families](https://docs.stripe.com/payments/checkout/customization/appearance?payment-ui=stripe-hosted#font-compatibility).
            [<Config.Form>]
            FontFamily: Create'BrandingSettingsFontFamily option
            /// The icon for the Checkout Session. For best results, use a square image.
            [<Config.Form>]
            Icon: Create'BrandingSettingsIcon option
            /// The logo for the Checkout Session.
            [<Config.Form>]
            Logo: Create'BrandingSettingsLogo option
        }

    type Create'BrandingSettings with
        static member New(?backgroundColor: Choice<string,string>, ?borderStyle: Create'BrandingSettingsBorderStyle, ?buttonColor: Choice<string,string>, ?displayName: string, ?fontFamily: Create'BrandingSettingsFontFamily, ?icon: Create'BrandingSettingsIcon, ?logo: Create'BrandingSettingsLogo) =
            {
                BackgroundColor = backgroundColor
                BorderStyle = borderStyle
                ButtonColor = buttonColor
                DisplayName = displayName
                FontFamily = fontFamily
                Icon = icon
                Logo = logo
            }

    type Create'ConsentCollectionPaymentMethodReuseAgreementPosition =
        | Auto
        | Hidden

    type Create'ConsentCollectionPaymentMethodReuseAgreement =
        {
            /// Determines the position and visibility of the payment method reuse agreement in the UI. When set to `auto`, Stripe's
            /// defaults will be used. When set to `hidden`, the payment method reuse agreement text will always be hidden in the UI.
            [<Config.Form>]
            Position: Create'ConsentCollectionPaymentMethodReuseAgreementPosition option
        }

    type Create'ConsentCollectionPaymentMethodReuseAgreement with
        static member New(?position: Create'ConsentCollectionPaymentMethodReuseAgreementPosition) =
            {
                Position = position
            }

    type Create'ConsentCollectionPromotions =
        | Auto
        | [<JsonPropertyName("none")>] None'

    type Create'ConsentCollectionTermsOfService =
        | [<JsonPropertyName("none")>] None'
        | Required

    type Create'ConsentCollection =
        {
            /// Determines the display of payment method reuse agreement text in the UI. If set to `hidden`, it will hide legal text related to the reuse of a payment method.
            [<Config.Form>]
            PaymentMethodReuseAgreement: Create'ConsentCollectionPaymentMethodReuseAgreement option
            /// If set to `auto`, enables the collection of customer consent for promotional communications. The Checkout
            /// Session will determine whether to display an option to opt into promotional communication
            /// from the merchant depending on the customer's locale. Only available to US merchants.
            [<Config.Form>]
            Promotions: Create'ConsentCollectionPromotions option
            /// If set to `required`, it requires customers to check a terms of service checkbox before being able to pay.
            /// There must be a valid terms of service URL set in your [Dashboard settings](https://dashboard.stripe.com/settings/public).
            [<Config.Form>]
            TermsOfService: Create'ConsentCollectionTermsOfService option
        }

    type Create'ConsentCollection with
        static member New(?paymentMethodReuseAgreement: Create'ConsentCollectionPaymentMethodReuseAgreement, ?promotions: Create'ConsentCollectionPromotions, ?termsOfService: Create'ConsentCollectionTermsOfService) =
            {
                PaymentMethodReuseAgreement = paymentMethodReuseAgreement
                Promotions = promotions
                TermsOfService = termsOfService
            }

    type Create'CustomFieldsDropdownOptions =
        {
            /// The label for the option, displayed to the customer. Up to 100 characters.
            [<Config.Form>]
            Label: string option
            /// The value for this option, not displayed to the customer, used by your integration to reconcile the option selected by the customer. Must be unique to this option, alphanumeric, and up to 100 characters.
            [<Config.Form>]
            Value: string option
        }

    type Create'CustomFieldsDropdownOptions with
        static member New(?label: string, ?value: string) =
            {
                Label = label
                Value = value
            }

    type Create'CustomFieldsDropdown =
        {
            /// The value that pre-fills the field on the payment page.Must match a `value` in the `options` array.
            [<Config.Form>]
            DefaultValue: string option
            /// The options available for the customer to select. Up to 200 options allowed.
            [<Config.Form>]
            Options: Create'CustomFieldsDropdownOptions list option
        }

    type Create'CustomFieldsDropdown with
        static member New(?defaultValue: string, ?options: Create'CustomFieldsDropdownOptions list) =
            {
                DefaultValue = defaultValue
                Options = options
            }

    type Create'CustomFieldsLabelType = | Custom

    type Create'CustomFieldsLabel =
        {
            /// Custom text for the label, displayed to the customer. Up to 50 characters.
            [<Config.Form>]
            Custom: string option
            /// The type of the label.
            [<Config.Form>]
            Type: Create'CustomFieldsLabelType option
        }

    type Create'CustomFieldsLabel with
        static member New(?custom: string, ?type': Create'CustomFieldsLabelType) =
            {
                Custom = custom
                Type = type'
            }

    type Create'CustomFieldsNumeric =
        {
            /// The value that pre-fills the field on the payment page.
            [<Config.Form>]
            DefaultValue: string option
            /// The maximum character length constraint for the customer's input.
            [<Config.Form>]
            MaximumLength: int option
            /// The minimum character length requirement for the customer's input.
            [<Config.Form>]
            MinimumLength: int option
        }

    type Create'CustomFieldsNumeric with
        static member New(?defaultValue: string, ?maximumLength: int, ?minimumLength: int) =
            {
                DefaultValue = defaultValue
                MaximumLength = maximumLength
                MinimumLength = minimumLength
            }

    type Create'CustomFieldsText =
        {
            /// The value that pre-fills the field on the payment page.
            [<Config.Form>]
            DefaultValue: string option
            /// The maximum character length constraint for the customer's input.
            [<Config.Form>]
            MaximumLength: int option
            /// The minimum character length requirement for the customer's input.
            [<Config.Form>]
            MinimumLength: int option
        }

    type Create'CustomFieldsText with
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

    type Create'CustomFields =
        {
            /// Configuration for `type=dropdown` fields.
            [<Config.Form>]
            Dropdown: Create'CustomFieldsDropdown option
            /// String of your choice that your integration can use to reconcile this field. Must be unique to this field, alphanumeric, and up to 200 characters.
            [<Config.Form>]
            Key: string option
            /// The label for the field, displayed to the customer.
            [<Config.Form>]
            Label: Create'CustomFieldsLabel option
            /// Configuration for `type=numeric` fields.
            [<Config.Form>]
            Numeric: Create'CustomFieldsNumeric option
            /// Whether the customer is required to complete the field before completing the Checkout Session. Defaults to `false`.
            [<Config.Form>]
            Optional: bool option
            /// Configuration for `type=text` fields.
            [<Config.Form>]
            Text: Create'CustomFieldsText option
            /// The type of the field.
            [<Config.Form>]
            Type: Create'CustomFieldsType option
        }

    type Create'CustomFields with
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

    type Create'CustomTextAfterSubmitCustomTextPosition =
        {
            /// Text can be up to 1200 characters in length.
            [<Config.Form>]
            Message: string option
        }

    type Create'CustomTextAfterSubmitCustomTextPosition with
        static member New(?message: string) =
            {
                Message = message
            }

    type Create'CustomTextShippingAddressCustomTextPosition =
        {
            /// Text can be up to 1200 characters in length.
            [<Config.Form>]
            Message: string option
        }

    type Create'CustomTextShippingAddressCustomTextPosition with
        static member New(?message: string) =
            {
                Message = message
            }

    type Create'CustomTextSubmitCustomTextPosition =
        {
            /// Text can be up to 1200 characters in length.
            [<Config.Form>]
            Message: string option
        }

    type Create'CustomTextSubmitCustomTextPosition with
        static member New(?message: string) =
            {
                Message = message
            }

    type Create'CustomTextTermsOfServiceAcceptanceCustomTextPosition =
        {
            /// Text can be up to 1200 characters in length.
            [<Config.Form>]
            Message: string option
        }

    type Create'CustomTextTermsOfServiceAcceptanceCustomTextPosition with
        static member New(?message: string) =
            {
                Message = message
            }

    type Create'CustomText =
        {
            /// Custom text that should be displayed after the payment confirmation button.
            [<Config.Form>]
            AfterSubmit: Choice<Create'CustomTextAfterSubmitCustomTextPosition,string> option
            /// Custom text that should be displayed alongside shipping address collection.
            [<Config.Form>]
            ShippingAddress: Choice<Create'CustomTextShippingAddressCustomTextPosition,string> option
            /// Custom text that should be displayed alongside the payment confirmation button.
            [<Config.Form>]
            Submit: Choice<Create'CustomTextSubmitCustomTextPosition,string> option
            /// Custom text that should be displayed in place of the default terms of service agreement text.
            [<Config.Form>]
            TermsOfServiceAcceptance: Choice<Create'CustomTextTermsOfServiceAcceptanceCustomTextPosition,string> option
        }

    type Create'CustomText with
        static member New(?afterSubmit: Choice<Create'CustomTextAfterSubmitCustomTextPosition,string>, ?shippingAddress: Choice<Create'CustomTextShippingAddressCustomTextPosition,string>, ?submit: Choice<Create'CustomTextSubmitCustomTextPosition,string>, ?termsOfServiceAcceptance: Choice<Create'CustomTextTermsOfServiceAcceptanceCustomTextPosition,string>) =
            {
                AfterSubmit = afterSubmit
                ShippingAddress = shippingAddress
                Submit = submit
                TermsOfServiceAcceptance = termsOfServiceAcceptance
            }

    type Create'CustomerCreation =
        | Always
        | IfRequired

    type Create'CustomerUpdateAddress =
        | Auto
        | Never

    type Create'CustomerUpdateName =
        | Auto
        | Never

    type Create'CustomerUpdateShipping =
        | Auto
        | Never

    type Create'CustomerUpdate =
        {
            /// Describes whether Checkout saves the billing address onto `customer.address`.
            /// To always collect a full billing address, use `billing_address_collection`. Defaults to `never`.
            [<Config.Form>]
            Address: Create'CustomerUpdateAddress option
            /// Describes whether Checkout saves the name onto `customer.name`. Defaults to `never`.
            [<Config.Form>]
            Name: Create'CustomerUpdateName option
            /// Describes whether Checkout saves shipping information onto `customer.shipping`.
            /// To collect shipping information, use `shipping_address_collection`. Defaults to `never`.
            [<Config.Form>]
            Shipping: Create'CustomerUpdateShipping option
        }

    type Create'CustomerUpdate with
        static member New(?address: Create'CustomerUpdateAddress, ?name: Create'CustomerUpdateName, ?shipping: Create'CustomerUpdateShipping) =
            {
                Address = address
                Name = name
                Shipping = shipping
            }

    type Create'Discounts =
        {
            /// The ID of the coupon to apply to this Session.
            [<Config.Form>]
            Coupon: string option
            /// The ID of a promotion code to apply to this Session.
            [<Config.Form>]
            PromotionCode: string option
        }

    type Create'Discounts with
        static member New(?coupon: string, ?promotionCode: string) =
            {
                Coupon = coupon
                PromotionCode = promotionCode
            }

    type Create'ExcludedPaymentMethodTypes =
        | AcssDebit
        | Affirm
        | AfterpayClearpay
        | Alipay
        | Alma
        | AmazonPay
        | AuBecsDebit
        | BacsDebit
        | Bancontact
        | Billie
        | Blik
        | Boleto
        | Card
        | Cashapp
        | Crypto
        | CustomerBalance
        | Eps
        | Fpx
        | Giropay
        | Grabpay
        | Ideal
        | KakaoPay
        | Klarna
        | Konbini
        | KrCard
        | MbWay
        | Mobilepay
        | Multibanco
        | NaverPay
        | NzBankAccount
        | Oxxo
        | P24
        | PayByBank
        | Payco
        | Paynow
        | Paypal
        | Payto
        | Pix
        | Promptpay
        | RevolutPay
        | SamsungPay
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

    type Create'InvoiceCreationInvoiceDataCustomFields =
        {
            /// The name of the custom field. This may be up to 40 characters.
            [<Config.Form>]
            Name: string option
            /// The value of the custom field. This may be up to 140 characters.
            [<Config.Form>]
            Value: string option
        }

    type Create'InvoiceCreationInvoiceDataCustomFields with
        static member New(?name: string, ?value: string) =
            {
                Name = name
                Value = value
            }

    type Create'InvoiceCreationInvoiceDataIssuerType =
        | Account
        | Self

    type Create'InvoiceCreationInvoiceDataIssuer =
        {
            /// The connected account being referenced when `type` is `account`.
            [<Config.Form>]
            Account: string option
            /// Type of the account referenced in the request.
            [<Config.Form>]
            Type: Create'InvoiceCreationInvoiceDataIssuerType option
        }

    type Create'InvoiceCreationInvoiceDataIssuer with
        static member New(?account: string, ?type': Create'InvoiceCreationInvoiceDataIssuerType) =
            {
                Account = account
                Type = type'
            }

    type Create'InvoiceCreationInvoiceDataRenderingOptionsCheckoutRenderingOptionsAmountTaxDisplay =
        | ExcludeTax
        | IncludeInclusiveTax

    type Create'InvoiceCreationInvoiceDataRenderingOptionsCheckoutRenderingOptions =
        {
            /// How line-item prices and amounts will be displayed with respect to tax on invoice PDFs. One of `exclude_tax` or `include_inclusive_tax`. `include_inclusive_tax` will include inclusive tax (and exclude exclusive tax) in invoice PDF amounts. `exclude_tax` will exclude all tax (inclusive and exclusive alike) from invoice PDF amounts.
            [<Config.Form>]
            AmountTaxDisplay:
                Create'InvoiceCreationInvoiceDataRenderingOptionsCheckoutRenderingOptionsAmountTaxDisplay option
            /// ID of the invoice rendering template to use for this invoice.
            [<Config.Form>]
            Template: string option
        }

    type Create'InvoiceCreationInvoiceDataRenderingOptionsCheckoutRenderingOptions with
        static member New(?amountTaxDisplay: Create'InvoiceCreationInvoiceDataRenderingOptionsCheckoutRenderingOptionsAmountTaxDisplay, ?template: string) =
            {
                AmountTaxDisplay = amountTaxDisplay
                Template = template
            }

    type Create'InvoiceCreationInvoiceData =
        {
            /// The account tax IDs associated with the invoice.
            [<Config.Form>]
            AccountTaxIds: Choice<string list,string> option
            /// Default custom fields to be displayed on invoices for this customer.
            [<Config.Form>]
            CustomFields: Choice<Create'InvoiceCreationInvoiceDataCustomFields list,string> option
            /// An arbitrary string attached to the object. Often useful for displaying to users.
            [<Config.Form>]
            Description: string option
            /// Default footer to be displayed on invoices for this customer.
            [<Config.Form>]
            Footer: string option
            /// The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.
            [<Config.Form>]
            Issuer: Create'InvoiceCreationInvoiceDataIssuer option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Default options for invoice PDF rendering for this customer.
            [<Config.Form>]
            RenderingOptions:
                Choice<Create'InvoiceCreationInvoiceDataRenderingOptionsCheckoutRenderingOptions,string> option
        }

    type Create'InvoiceCreationInvoiceData with
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

    type Create'InvoiceCreation =
        {
            /// Set to `true` to enable invoice creation.
            [<Config.Form>]
            Enabled: bool option
            /// Parameters passed when creating invoices for payment-mode Checkout Sessions.
            [<Config.Form>]
            InvoiceData: Create'InvoiceCreationInvoiceData option
        }

    type Create'InvoiceCreation with
        static member New(?enabled: bool, ?invoiceData: Create'InvoiceCreationInvoiceData) =
            {
                Enabled = enabled
                InvoiceData = invoiceData
            }

    type Create'LineItemsAdjustableQuantity =
        {
            /// Set to true if the quantity can be adjusted to any non-negative integer.
            [<Config.Form>]
            Enabled: bool option
            /// The maximum quantity the customer can purchase for the Checkout Session. By default this value is 99. You can specify a value up to 999999.
            [<Config.Form>]
            Maximum: int option
            /// The minimum quantity the customer must purchase for the Checkout Session. By default this value is 0.
            [<Config.Form>]
            Minimum: int option
        }

    type Create'LineItemsAdjustableQuantity with
        static member New(?enabled: bool, ?maximum: int, ?minimum: int) =
            {
                Enabled = enabled
                Maximum = maximum
                Minimum = minimum
            }

    type Create'LineItemsPriceDataProductData =
        {
            /// The product's description, meant to be displayable to the customer. Use this field to optionally store a long form explanation of the product being sold for your own rendering purposes.
            [<Config.Form>]
            Description: string option
            /// A list of up to 8 URLs of images for this product, meant to be displayable to the customer.
            [<Config.Form>]
            Images: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The product's name, meant to be displayable to the customer.
            [<Config.Form>]
            Name: string option
            /// A [tax code](https://docs.stripe.com/tax/tax-categories) ID.
            [<Config.Form>]
            TaxCode: string option
            /// A label that represents units of this product. When set, this will be included in customers' receipts, invoices, Checkout, and the customer portal.
            [<Config.Form>]
            UnitLabel: string option
        }

    type Create'LineItemsPriceDataProductData with
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

    type Create'LineItemsPriceDataRecurring =
        {
            /// Specifies billing frequency. Either `day`, `week`, `month` or `year`.
            [<Config.Form>]
            Interval: Create'LineItemsPriceDataRecurringInterval option
            /// The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).
            [<Config.Form>]
            IntervalCount: int option
        }

    type Create'LineItemsPriceDataRecurring with
        static member New(?interval: Create'LineItemsPriceDataRecurringInterval, ?intervalCount: int) =
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
            /// The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to. One of `product` or `product_data` is required.
            [<Config.Form>]
            Product: string option
            /// Data used to generate a new [Product](https://docs.stripe.com/api/products) object inline. One of `product` or `product_data` is required.
            [<Config.Form>]
            ProductData: Create'LineItemsPriceDataProductData option
            /// The recurring components of a price such as `interval` and `interval_count`.
            [<Config.Form>]
            Recurring: Create'LineItemsPriceDataRecurring option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: Create'LineItemsPriceDataTaxBehavior option
            /// A non-negative integer in cents (or local equivalent) representing how much to charge. One of `unit_amount` or `unit_amount_decimal` is required.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    type Create'LineItemsPriceData with
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

    type Create'LineItems =
        {
            /// When set, provides configuration for this item’s quantity to be adjusted by the customer during Checkout.
            [<Config.Form>]
            AdjustableQuantity: Create'LineItemsAdjustableQuantity option
            /// The [tax rates](https://docs.stripe.com/api/tax_rates) that will be applied to this line item depending on the customer's billing/shipping address. We currently support the following countries: US, GB, AU, and all countries in the EU. You can't set this parameter if `ui_mode` is `custom`.
            [<Config.Form>]
            DynamicTaxRates: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The ID of the [Price](https://docs.stripe.com/api/prices) or [Plan](https://docs.stripe.com/api/plans) object. One of `price` or `price_data` is required.
            [<Config.Form>]
            Price: string option
            /// Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.
            [<Config.Form>]
            PriceData: Create'LineItemsPriceData option
            /// The quantity of the line item being purchased. Quantity should not be defined when `recurring.usage_type=metered`.
            [<Config.Form>]
            Quantity: int option
            /// The [tax rates](https://docs.stripe.com/api/tax_rates) which apply to this line item.
            [<Config.Form>]
            TaxRates: string list option
        }

    type Create'LineItems with
        static member New(?adjustableQuantity: Create'LineItemsAdjustableQuantity, ?dynamicTaxRates: string list, ?metadata: Map<string, string>, ?price: string, ?priceData: Create'LineItemsPriceData, ?quantity: int, ?taxRates: string list) =
            {
                AdjustableQuantity = adjustableQuantity
                DynamicTaxRates = dynamicTaxRates
                Metadata = metadata
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Create'Locale =
        | Auto
        | Bg
        | Cs
        | Da
        | De
        | El
        | En
        | [<JsonPropertyName("en-GB")>] EnGB
        | Es
        | [<JsonPropertyName("es-419")>] Es419
        | Et
        | Fi
        | Fil
        | Fr
        | [<JsonPropertyName("fr-CA")>] FrCA
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
        | [<JsonPropertyName("pt-BR")>] PtBR
        | Ro
        | Ru
        | Sk
        | Sl
        | Sv
        | Th
        | Tr
        | Vi
        | Zh
        | [<JsonPropertyName("zh-HK")>] ZhHK
        | [<JsonPropertyName("zh-TW")>] ZhTW

    type Create'ManagedPayments =
        {
            /// Set to `true` to enable [Managed Payments](https://docs.stripe.com/payments/managed-payments), Stripe's merchant of record solution, for this session.
            [<Config.Form>]
            Enabled: bool option
        }

    type Create'ManagedPayments with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Create'Mode =
        | Payment
        | Setup
        | Subscription

    type Create'NameCollectionBusiness =
        {
            /// Enable business name collection on the Checkout Session. Defaults to `false`.
            [<Config.Form>]
            Enabled: bool option
            /// Whether the customer is required to provide a business name before completing the Checkout Session. Defaults to `false`.
            [<Config.Form>]
            Optional: bool option
        }

    type Create'NameCollectionBusiness with
        static member New(?enabled: bool, ?optional: bool) =
            {
                Enabled = enabled
                Optional = optional
            }

    type Create'NameCollectionIndividual =
        {
            /// Enable individual name collection on the Checkout Session. Defaults to `false`.
            [<Config.Form>]
            Enabled: bool option
            /// Whether the customer is required to provide their name before completing the Checkout Session. Defaults to `false`.
            [<Config.Form>]
            Optional: bool option
        }

    type Create'NameCollectionIndividual with
        static member New(?enabled: bool, ?optional: bool) =
            {
                Enabled = enabled
                Optional = optional
            }

    type Create'NameCollection =
        {
            /// Controls settings applied for collecting the customer's business name on the session.
            [<Config.Form>]
            Business: Create'NameCollectionBusiness option
            /// Controls settings applied for collecting the customer's individual name on the session.
            [<Config.Form>]
            Individual: Create'NameCollectionIndividual option
        }

    type Create'NameCollection with
        static member New(?business: Create'NameCollectionBusiness, ?individual: Create'NameCollectionIndividual) =
            {
                Business = business
                Individual = individual
            }

    type Create'OptionalItemsAdjustableQuantity =
        {
            /// Set to true if the quantity can be adjusted to any non-negative integer.
            [<Config.Form>]
            Enabled: bool option
            /// The maximum quantity of this item the customer can purchase. By default this value is 99. You can specify a value up to 999999.
            [<Config.Form>]
            Maximum: int option
            /// The minimum quantity of this item the customer must purchase, if they choose to purchase it. Because this item is optional, the customer will always be able to remove it from their order, even if the `minimum` configured here is greater than 0. By default this value is 0.
            [<Config.Form>]
            Minimum: int option
        }

    type Create'OptionalItemsAdjustableQuantity with
        static member New(?enabled: bool, ?maximum: int, ?minimum: int) =
            {
                Enabled = enabled
                Maximum = maximum
                Minimum = minimum
            }

    type Create'OptionalItems =
        {
            /// When set, provides configuration for the customer to adjust the quantity of the line item created when a customer chooses to add this optional item to their order.
            [<Config.Form>]
            AdjustableQuantity: Create'OptionalItemsAdjustableQuantity option
            /// The ID of the [Price](https://docs.stripe.com/api/prices) or [Plan](https://docs.stripe.com/api/plans) object.
            [<Config.Form>]
            Price: string option
            /// The initial quantity of the line item created when a customer chooses to add this optional item to their order.
            [<Config.Form>]
            Quantity: int option
        }

    type Create'OptionalItems with
        static member New(?adjustableQuantity: Create'OptionalItemsAdjustableQuantity, ?price: string, ?quantity: int) =
            {
                AdjustableQuantity = adjustableQuantity
                Price = price
                Quantity = quantity
            }

    type Create'OriginContext =
        | MobileApp
        | Web

    type Create'PaymentIntentDataCaptureMethod =
        | Automatic
        | AutomaticAsync
        | Manual

    type Create'PaymentIntentDataSetupFutureUsage =
        | OffSession
        | OnSession

    type Create'PaymentIntentDataShippingAddress =
        {
            /// City, district, suburb, town, or village.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Address line 1, such as the street, PO Box, or company name.
            [<Config.Form>]
            Line1: string option
            /// Address line 2, such as the apartment, suite, unit, or building.
            [<Config.Form>]
            Line2: string option
            /// ZIP or postal code.
            [<Config.Form>]
            PostalCode: string option
            /// State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
            [<Config.Form>]
            State: string option
        }

    type Create'PaymentIntentDataShippingAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'PaymentIntentDataShipping =
        {
            /// Shipping address.
            [<Config.Form>]
            Address: Create'PaymentIntentDataShippingAddress option
            /// The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc.
            [<Config.Form>]
            Carrier: string option
            /// Recipient name.
            [<Config.Form>]
            Name: string option
            /// Recipient phone (including extension).
            [<Config.Form>]
            Phone: string option
            /// The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
            [<Config.Form>]
            TrackingNumber: string option
        }

    type Create'PaymentIntentDataShipping with
        static member New(?address: Create'PaymentIntentDataShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
            {
                Address = address
                Carrier = carrier
                Name = name
                Phone = phone
                TrackingNumber = trackingNumber
            }

    type Create'PaymentIntentDataTransferData =
        {
            /// The amount that will be transferred automatically when a charge succeeds.
            [<Config.Form>]
            Amount: int option
            /// If specified, successful charges will be attributed to the destination
            /// account for tax reporting, and the funds from charges will be transferred
            /// to the destination account. The ID of the resulting transfer will be
            /// returned on the successful charge's `transfer` field.
            [<Config.Form>]
            Destination: string option
        }

    type Create'PaymentIntentDataTransferData with
        static member New(?amount: int, ?destination: string) =
            {
                Amount = amount
                Destination = destination
            }

    type Create'PaymentIntentData =
        {
            /// The amount of the application fee (if any) that will be requested to be applied to the payment and transferred to the application owner's Stripe account. The amount of the application fee collected will be capped at the total amount captured. For more information, see the PaymentIntents [use case for connected accounts](https://docs.stripe.com/payments/connected-accounts).
            [<Config.Form>]
            ApplicationFeeAmount: int option
            /// Controls when the funds will be captured from the customer's account.
            [<Config.Form>]
            CaptureMethod: Create'PaymentIntentDataCaptureMethod option
            /// An arbitrary string attached to the object. Often useful for displaying to users.
            [<Config.Form>]
            Description: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The Stripe account ID for which these funds are intended. For details,
            /// see the PaymentIntents [use case for connected
            /// accounts](/docs/payments/connected-accounts).
            [<Config.Form>]
            OnBehalfOf: string option
            /// Email address that the receipt for the resulting payment will be sent to. If `receipt_email` is specified for a payment in live mode, a receipt will be sent regardless of your [email settings](https://dashboard.stripe.com/account/emails).
            [<Config.Form>]
            ReceiptEmail: string option
            /// Indicates that you intend to [make future payments](https://docs.stripe.com/payments/payment-intents#future-usage) with the payment
            /// method collected by this Checkout Session.
            /// When setting this to `on_session`, Checkout will show a notice to the
            /// customer that their payment details will be saved.
            /// When setting this to `off_session`, Checkout will show a notice to the
            /// customer that their payment details will be saved and used for future
            /// payments.
            /// If a Customer has been provided or Checkout creates a new Customer,
            /// Checkout will attach the payment method to the Customer.
            /// If Checkout does not create a Customer, the payment method is not attached
            /// to a Customer. To reuse the payment method, you can retrieve it from the
            /// Checkout Session's PaymentIntent.
            /// When processing card payments, Checkout also uses `setup_future_usage`
            /// to dynamically optimize your payment flow and comply with regional
            /// legislation and network rules, such as SCA.
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentIntentDataSetupFutureUsage option
            /// Shipping information for this payment.
            [<Config.Form>]
            Shipping: Create'PaymentIntentDataShipping option
            /// Text that appears on the customer's statement as the statement descriptor for a non-card charge. This value overrides the account's default statement descriptor. For information about requirements, including the 22-character limit, see [the Statement Descriptor docs](https://docs.stripe.com/get-started/account/statement-descriptors).
            /// Setting this value for a card charge returns an error. For card charges, set the [statement_descriptor_suffix](https://docs.stripe.com/get-started/account/statement-descriptors#dynamic) instead.
            [<Config.Form>]
            StatementDescriptor: string option
            /// Provides information about a card charge. Concatenated to the account's [statement descriptor prefix](https://docs.stripe.com/get-started/account/statement-descriptors#static) to form the complete statement descriptor that appears on the customer's statement.
            [<Config.Form>]
            StatementDescriptorSuffix: string option
            /// The parameters used to automatically create a Transfer when the payment succeeds.
            /// For more information, see the PaymentIntents [use case for connected accounts](https://docs.stripe.com/payments/connected-accounts).
            [<Config.Form>]
            TransferData: Create'PaymentIntentDataTransferData option
            /// A string that identifies the resulting payment as part of a group. See the PaymentIntents [use case for connected accounts](https://docs.stripe.com/connect/separate-charges-and-transfers) for details.
            [<Config.Form>]
            TransferGroup: string option
        }

    type Create'PaymentIntentData with
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

    type Create'PaymentMethodCollection =
        | Always
        | IfRequired

    type Create'PaymentMethodDataAllowRedisplay =
        | Always
        | Limited
        | Unspecified

    type Create'PaymentMethodData =
        {
            /// Allow redisplay will be set on the payment method on confirmation and indicates whether this payment method can be shown again to the customer in a checkout flow. Only set this field if you wish to override the allow_redisplay value determined by Checkout.
            [<Config.Form>]
            AllowRedisplay: Create'PaymentMethodDataAllowRedisplay option
        }

    type Create'PaymentMethodData with
        static member New(?allowRedisplay: Create'PaymentMethodDataAllowRedisplay) =
            {
                AllowRedisplay = allowRedisplay
            }

    type Create'PaymentMethodOptionsAcssDebitCurrency =
        | Cad
        | Usd

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

    type Create'PaymentMethodOptionsAcssDebitMandateOptions =
        {
            /// A URL for custom mandate text to render during confirmation step.
            /// The URL will be rendered with additional GET parameters `payment_intent` and `payment_intent_client_secret` when confirming a Payment Intent,
            /// or `setup_intent` and `setup_intent_client_secret` when confirming a Setup Intent.
            [<Config.Form>]
            CustomMandateUrl: Choice<string,string> option
            /// List of Stripe products where this mandate can be selected automatically. Only usable in `setup` mode.
            [<Config.Form>]
            DefaultFor: Create'PaymentMethodOptionsAcssDebitMandateOptionsDefaultFor list option
            /// Description of the mandate interval. Only required if 'payment_schedule' parameter is 'interval' or 'combined'.
            [<Config.Form>]
            IntervalDescription: string option
            /// Payment schedule for the mandate.
            [<Config.Form>]
            PaymentSchedule: Create'PaymentMethodOptionsAcssDebitMandateOptionsPaymentSchedule option
            /// Transaction type of the mandate.
            [<Config.Form>]
            TransactionType: Create'PaymentMethodOptionsAcssDebitMandateOptionsTransactionType option
        }

    type Create'PaymentMethodOptionsAcssDebitMandateOptions with
        static member New(?customMandateUrl: Choice<string,string>, ?defaultFor: Create'PaymentMethodOptionsAcssDebitMandateOptionsDefaultFor list, ?intervalDescription: string, ?paymentSchedule: Create'PaymentMethodOptionsAcssDebitMandateOptionsPaymentSchedule, ?transactionType: Create'PaymentMethodOptionsAcssDebitMandateOptionsTransactionType) =
            {
                CustomMandateUrl = customMandateUrl
                DefaultFor = defaultFor
                IntervalDescription = intervalDescription
                PaymentSchedule = paymentSchedule
                TransactionType = transactionType
            }

    type Create'PaymentMethodOptionsAcssDebitSetupFutureUsage =
        | [<JsonPropertyName("none")>] None'
        | OffSession
        | OnSession

    type Create'PaymentMethodOptionsAcssDebitVerificationMethod =
        | Automatic
        | Instant
        | Microdeposits

    type Create'PaymentMethodOptionsAcssDebit =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies). This is only accepted for Checkout Sessions in `setup` mode.
            [<Config.Form>]
            Currency: Create'PaymentMethodOptionsAcssDebitCurrency option
            /// Additional fields for Mandate creation
            [<Config.Form>]
            MandateOptions: Create'PaymentMethodOptionsAcssDebitMandateOptions option
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsAcssDebitSetupFutureUsage option
            /// Controls when Stripe will attempt to debit the funds from the customer's account. The date must be a string in YYYY-MM-DD format. The date must be in the future and between 3 and 15 calendar days from now.
            [<Config.Form>]
            TargetDate: string option
            /// Verification method for the intent
            [<Config.Form>]
            VerificationMethod: Create'PaymentMethodOptionsAcssDebitVerificationMethod option
        }

    type Create'PaymentMethodOptionsAcssDebit with
        static member New(?currency: Create'PaymentMethodOptionsAcssDebitCurrency, ?mandateOptions: Create'PaymentMethodOptionsAcssDebitMandateOptions, ?setupFutureUsage: Create'PaymentMethodOptionsAcssDebitSetupFutureUsage, ?targetDate: string, ?verificationMethod: Create'PaymentMethodOptionsAcssDebitVerificationMethod) =
            {
                Currency = currency
                MandateOptions = mandateOptions
                SetupFutureUsage = setupFutureUsage
                TargetDate = targetDate
                VerificationMethod = verificationMethod
            }

    type Create'PaymentMethodOptionsAffirmCaptureMethod = | Manual

    type Create'PaymentMethodOptionsAffirmSetupFutureUsage = | [<JsonPropertyName("none")>] None'

    type Create'PaymentMethodOptionsAffirm =
        {
            /// Controls when the funds will be captured from the customer's account.
            [<Config.Form>]
            CaptureMethod: Create'PaymentMethodOptionsAffirmCaptureMethod option
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsAffirmSetupFutureUsage option
        }

    type Create'PaymentMethodOptionsAffirm with
        static member New(?captureMethod: Create'PaymentMethodOptionsAffirmCaptureMethod, ?setupFutureUsage: Create'PaymentMethodOptionsAffirmSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsAfterpayClearpayCaptureMethod = | Manual

    type Create'PaymentMethodOptionsAfterpayClearpaySetupFutureUsage = | [<JsonPropertyName("none")>] None'

    type Create'PaymentMethodOptionsAfterpayClearpay =
        {
            /// Controls when the funds will be captured from the customer's account.
            [<Config.Form>]
            CaptureMethod: Create'PaymentMethodOptionsAfterpayClearpayCaptureMethod option
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsAfterpayClearpaySetupFutureUsage option
        }

    type Create'PaymentMethodOptionsAfterpayClearpay with
        static member New(?captureMethod: Create'PaymentMethodOptionsAfterpayClearpayCaptureMethod, ?setupFutureUsage: Create'PaymentMethodOptionsAfterpayClearpaySetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsAlipaySetupFutureUsage = | [<JsonPropertyName("none")>] None'

    type Create'PaymentMethodOptionsAlipay =
        {
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsAlipaySetupFutureUsage option
        }

    type Create'PaymentMethodOptionsAlipay with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsAlipaySetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsAlmaCaptureMethod = | Manual

    type Create'PaymentMethodOptionsAlma =
        {
            /// Controls when the funds will be captured from the customer's account.
            [<Config.Form>]
            CaptureMethod: Create'PaymentMethodOptionsAlmaCaptureMethod option
        }

    type Create'PaymentMethodOptionsAlma with
        static member New(?captureMethod: Create'PaymentMethodOptionsAlmaCaptureMethod) =
            {
                CaptureMethod = captureMethod
            }

    type Create'PaymentMethodOptionsAmazonPayCaptureMethod = | Manual

    type Create'PaymentMethodOptionsAmazonPaySetupFutureUsage =
        | [<JsonPropertyName("none")>] None'
        | OffSession

    type Create'PaymentMethodOptionsAmazonPay =
        {
            /// Controls when the funds will be captured from the customer's account.
            [<Config.Form>]
            CaptureMethod: Create'PaymentMethodOptionsAmazonPayCaptureMethod option
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsAmazonPaySetupFutureUsage option
        }

    type Create'PaymentMethodOptionsAmazonPay with
        static member New(?captureMethod: Create'PaymentMethodOptionsAmazonPayCaptureMethod, ?setupFutureUsage: Create'PaymentMethodOptionsAmazonPaySetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsAuBecsDebitSetupFutureUsage = | [<JsonPropertyName("none")>] None'

    type Create'PaymentMethodOptionsAuBecsDebit =
        {
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsAuBecsDebitSetupFutureUsage option
            /// Controls when Stripe will attempt to debit the funds from the customer's account. The date must be a string in YYYY-MM-DD format. The date must be in the future and between 3 and 15 calendar days from now.
            [<Config.Form>]
            TargetDate: string option
        }

    type Create'PaymentMethodOptionsAuBecsDebit with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsAuBecsDebitSetupFutureUsage, ?targetDate: string) =
            {
                SetupFutureUsage = setupFutureUsage
                TargetDate = targetDate
            }

    type Create'PaymentMethodOptionsBacsDebitMandateOptions =
        {
            /// Prefix used to generate the Mandate reference. Must be at most 12 characters long. Must consist of only uppercase letters, numbers, spaces, or the following special characters: '/', '_', '-', '&', '.'. Cannot begin with 'DDIC' or 'STRIPE'.
            [<Config.Form>]
            ReferencePrefix: Choice<string,string> option
        }

    type Create'PaymentMethodOptionsBacsDebitMandateOptions with
        static member New(?referencePrefix: Choice<string,string>) =
            {
                ReferencePrefix = referencePrefix
            }

    type Create'PaymentMethodOptionsBacsDebitSetupFutureUsage =
        | [<JsonPropertyName("none")>] None'
        | OffSession
        | OnSession

    type Create'PaymentMethodOptionsBacsDebit =
        {
            /// Additional fields for Mandate creation
            [<Config.Form>]
            MandateOptions: Create'PaymentMethodOptionsBacsDebitMandateOptions option
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsBacsDebitSetupFutureUsage option
            /// Controls when Stripe will attempt to debit the funds from the customer's account. The date must be a string in YYYY-MM-DD format. The date must be in the future and between 3 and 15 calendar days from now.
            [<Config.Form>]
            TargetDate: string option
        }

    type Create'PaymentMethodOptionsBacsDebit with
        static member New(?mandateOptions: Create'PaymentMethodOptionsBacsDebitMandateOptions, ?setupFutureUsage: Create'PaymentMethodOptionsBacsDebitSetupFutureUsage, ?targetDate: string) =
            {
                MandateOptions = mandateOptions
                SetupFutureUsage = setupFutureUsage
                TargetDate = targetDate
            }

    type Create'PaymentMethodOptionsBancontactSetupFutureUsage = | [<JsonPropertyName("none")>] None'

    type Create'PaymentMethodOptionsBancontact =
        {
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsBancontactSetupFutureUsage option
        }

    type Create'PaymentMethodOptionsBancontact with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsBancontactSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsBillieCaptureMethod = | Manual

    type Create'PaymentMethodOptionsBillie =
        {
            /// Controls when the funds will be captured from the customer's account.
            [<Config.Form>]
            CaptureMethod: Create'PaymentMethodOptionsBillieCaptureMethod option
        }

    type Create'PaymentMethodOptionsBillie with
        static member New(?captureMethod: Create'PaymentMethodOptionsBillieCaptureMethod) =
            {
                CaptureMethod = captureMethod
            }

    type Create'PaymentMethodOptionsBoletoSetupFutureUsage =
        | [<JsonPropertyName("none")>] None'
        | OffSession
        | OnSession

    type Create'PaymentMethodOptionsBoleto =
        {
            /// The number of calendar days before a Boleto voucher expires. For example, if you create a Boleto voucher on Monday and you set expires_after_days to 2, the Boleto invoice will expire on Wednesday at 23:59 America/Sao_Paulo time.
            [<Config.Form>]
            ExpiresAfterDays: int option
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsBoletoSetupFutureUsage option
        }

    type Create'PaymentMethodOptionsBoleto with
        static member New(?expiresAfterDays: int, ?setupFutureUsage: Create'PaymentMethodOptionsBoletoSetupFutureUsage) =
            {
                ExpiresAfterDays = expiresAfterDays
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsCardCaptureMethod = | Manual

    type Create'PaymentMethodOptionsCardInstallments =
        {
            /// Setting to true enables installments for this Checkout Session.
            /// Setting to false will prevent any installment plan from applying to a payment.
            [<Config.Form>]
            Enabled: bool option
        }

    type Create'PaymentMethodOptionsCardInstallments with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Create'PaymentMethodOptionsCardRequestExtendedAuthorization =
        | IfAvailable
        | Never

    type Create'PaymentMethodOptionsCardRequestIncrementalAuthorization =
        | IfAvailable
        | Never

    type Create'PaymentMethodOptionsCardRequestMulticapture =
        | IfAvailable
        | Never

    type Create'PaymentMethodOptionsCardRequestOvercapture =
        | IfAvailable
        | Never

    type Create'PaymentMethodOptionsCardRequestThreeDSecure =
        | Any
        | Automatic
        | Challenge

    type Create'PaymentMethodOptionsCardRestrictionsBrandsBlocked =
        | AmericanExpress
        | DiscoverGlobalNetwork
        | Mastercard
        | Visa

    type Create'PaymentMethodOptionsCardRestrictions =
        {
            /// Specify the card brands to block in the Checkout Session. If a customer enters or selects a card belonging to a blocked brand, they can't complete the Session.
            [<Config.Form>]
            BrandsBlocked: Create'PaymentMethodOptionsCardRestrictionsBrandsBlocked list option
        }

    type Create'PaymentMethodOptionsCardRestrictions with
        static member New(?brandsBlocked: Create'PaymentMethodOptionsCardRestrictionsBrandsBlocked list) =
            {
                BrandsBlocked = brandsBlocked
            }

    type Create'PaymentMethodOptionsCardSetupFutureUsage =
        | OffSession
        | OnSession

    type Create'PaymentMethodOptionsCard =
        {
            /// Controls when the funds will be captured from the customer's account.
            [<Config.Form>]
            CaptureMethod: Create'PaymentMethodOptionsCardCaptureMethod option
            /// Installment options for card payments
            [<Config.Form>]
            Installments: Create'PaymentMethodOptionsCardInstallments option
            /// Request ability to [capture beyond the standard authorization validity window](/payments/extended-authorization) for this CheckoutSession.
            [<Config.Form>]
            RequestExtendedAuthorization: Create'PaymentMethodOptionsCardRequestExtendedAuthorization option
            /// Request ability to [increment the authorization](/payments/incremental-authorization) for this CheckoutSession.
            [<Config.Form>]
            RequestIncrementalAuthorization: Create'PaymentMethodOptionsCardRequestIncrementalAuthorization option
            /// Request ability to make [multiple captures](/payments/multicapture) for this CheckoutSession.
            [<Config.Form>]
            RequestMulticapture: Create'PaymentMethodOptionsCardRequestMulticapture option
            /// Request ability to [overcapture](/payments/overcapture) for this CheckoutSession.
            [<Config.Form>]
            RequestOvercapture: Create'PaymentMethodOptionsCardRequestOvercapture option
            /// We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://docs.stripe.com/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. If not provided, this value defaults to `automatic`. Read our guide on [manually requesting 3D Secure](https://docs.stripe.com/payments/3d-secure/authentication-flow#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
            [<Config.Form>]
            RequestThreeDSecure: Create'PaymentMethodOptionsCardRequestThreeDSecure option
            /// Restrictions to apply to the card payment method. For example, you can block specific card brands. You can't set this parameter if `ui_mode` is `custom`.
            [<Config.Form>]
            Restrictions: Create'PaymentMethodOptionsCardRestrictions option
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsCardSetupFutureUsage option
            /// Provides information about a card payment that customers see on their statements. Concatenated with the Kana prefix (shortened Kana descriptor) or Kana statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 22 characters. On card statements, the *concatenation* of both prefix and suffix (including separators) will appear truncated to 22 characters.
            [<Config.Form>]
            StatementDescriptorSuffixKana: string option
            /// Provides information about a card payment that customers see on their statements. Concatenated with the Kanji prefix (shortened Kanji descriptor) or Kanji statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 17 characters. On card statements, the *concatenation* of both prefix and suffix (including separators) will appear truncated to 17 characters.
            [<Config.Form>]
            StatementDescriptorSuffixKanji: string option
        }

    type Create'PaymentMethodOptionsCard with
        static member New(?captureMethod: Create'PaymentMethodOptionsCardCaptureMethod, ?installments: Create'PaymentMethodOptionsCardInstallments, ?requestExtendedAuthorization: Create'PaymentMethodOptionsCardRequestExtendedAuthorization, ?requestIncrementalAuthorization: Create'PaymentMethodOptionsCardRequestIncrementalAuthorization, ?requestMulticapture: Create'PaymentMethodOptionsCardRequestMulticapture, ?requestOvercapture: Create'PaymentMethodOptionsCardRequestOvercapture, ?requestThreeDSecure: Create'PaymentMethodOptionsCardRequestThreeDSecure, ?restrictions: Create'PaymentMethodOptionsCardRestrictions, ?setupFutureUsage: Create'PaymentMethodOptionsCardSetupFutureUsage, ?statementDescriptorSuffixKana: string, ?statementDescriptorSuffixKanji: string) =
            {
                CaptureMethod = captureMethod
                Installments = installments
                RequestExtendedAuthorization = requestExtendedAuthorization
                RequestIncrementalAuthorization = requestIncrementalAuthorization
                RequestMulticapture = requestMulticapture
                RequestOvercapture = requestOvercapture
                RequestThreeDSecure = requestThreeDSecure
                Restrictions = restrictions
                SetupFutureUsage = setupFutureUsage
                StatementDescriptorSuffixKana = statementDescriptorSuffixKana
                StatementDescriptorSuffixKanji = statementDescriptorSuffixKanji
            }

    type Create'PaymentMethodOptionsCashappCaptureMethod = | Manual

    type Create'PaymentMethodOptionsCashappSetupFutureUsage =
        | [<JsonPropertyName("none")>] None'
        | OffSession
        | OnSession

    type Create'PaymentMethodOptionsCashapp =
        {
            /// Controls when the funds will be captured from the customer's account.
            [<Config.Form>]
            CaptureMethod: Create'PaymentMethodOptionsCashappCaptureMethod option
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsCashappSetupFutureUsage option
        }

    type Create'PaymentMethodOptionsCashapp with
        static member New(?captureMethod: Create'PaymentMethodOptionsCashappCaptureMethod, ?setupFutureUsage: Create'PaymentMethodOptionsCashappSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsCryptoSetupFutureUsage = | [<JsonPropertyName("none")>] None'

    type Create'PaymentMethodOptionsCrypto =
        {
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsCryptoSetupFutureUsage option
        }

    type Create'PaymentMethodOptionsCrypto with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsCryptoSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsCustomerBalanceBankTransferEuBankTransfer =
        {
            /// The desired country code of the bank account information. Permitted values include: `DE`, `FR`, `IE`, or `NL`.
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
        }

    type Create'PaymentMethodOptionsCustomerBalanceBankTransferEuBankTransfer with
        static member New(?country: IsoTypes.IsoCountryCode) =
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

    type Create'PaymentMethodOptionsCustomerBalanceBankTransfer =
        {
            /// Configuration for eu_bank_transfer funding type.
            [<Config.Form>]
            EuBankTransfer: Create'PaymentMethodOptionsCustomerBalanceBankTransferEuBankTransfer option
            /// List of address types that should be returned in the financial_addresses response. If not specified, all valid types will be returned.
            /// Permitted values include: `sort_code`, `zengin`, `iban`, or `spei`.
            [<Config.Form>]
            RequestedAddressTypes: Create'PaymentMethodOptionsCustomerBalanceBankTransferRequestedAddressTypes list option
            /// The list of bank transfer types that this PaymentIntent is allowed to use for funding.
            [<Config.Form>]
            Type: Create'PaymentMethodOptionsCustomerBalanceBankTransferType option
        }

    type Create'PaymentMethodOptionsCustomerBalanceBankTransfer with
        static member New(?euBankTransfer: Create'PaymentMethodOptionsCustomerBalanceBankTransferEuBankTransfer, ?requestedAddressTypes: Create'PaymentMethodOptionsCustomerBalanceBankTransferRequestedAddressTypes list, ?type': Create'PaymentMethodOptionsCustomerBalanceBankTransferType) =
            {
                EuBankTransfer = euBankTransfer
                RequestedAddressTypes = requestedAddressTypes
                Type = type'
            }

    type Create'PaymentMethodOptionsCustomerBalanceFundingType = | BankTransfer

    type Create'PaymentMethodOptionsCustomerBalanceSetupFutureUsage = | [<JsonPropertyName("none")>] None'

    type Create'PaymentMethodOptionsCustomerBalance =
        {
            /// Configuration for the bank transfer funding type, if the `funding_type` is set to `bank_transfer`.
            [<Config.Form>]
            BankTransfer: Create'PaymentMethodOptionsCustomerBalanceBankTransfer option
            /// The funding method type to be used when there are not enough funds in the customer balance. Permitted values include: `bank_transfer`.
            [<Config.Form>]
            FundingType: Create'PaymentMethodOptionsCustomerBalanceFundingType option
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsCustomerBalanceSetupFutureUsage option
        }

    type Create'PaymentMethodOptionsCustomerBalance with
        static member New(?bankTransfer: Create'PaymentMethodOptionsCustomerBalanceBankTransfer, ?fundingType: Create'PaymentMethodOptionsCustomerBalanceFundingType, ?setupFutureUsage: Create'PaymentMethodOptionsCustomerBalanceSetupFutureUsage) =
            {
                BankTransfer = bankTransfer
                FundingType = fundingType
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsDemoPaySetupFutureUsage =
        | [<JsonPropertyName("none")>] None'
        | OffSession

    type Create'PaymentMethodOptionsDemoPay =
        {
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsDemoPaySetupFutureUsage option
        }

    type Create'PaymentMethodOptionsDemoPay with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsDemoPaySetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsEpsSetupFutureUsage = | [<JsonPropertyName("none")>] None'

    type Create'PaymentMethodOptionsEps =
        {
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsEpsSetupFutureUsage option
        }

    type Create'PaymentMethodOptionsEps with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsEpsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsFpxSetupFutureUsage = | [<JsonPropertyName("none")>] None'

    type Create'PaymentMethodOptionsFpx =
        {
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsFpxSetupFutureUsage option
        }

    type Create'PaymentMethodOptionsFpx with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsFpxSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsGiropaySetupFutureUsage = | [<JsonPropertyName("none")>] None'

    type Create'PaymentMethodOptionsGiropay =
        {
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsGiropaySetupFutureUsage option
        }

    type Create'PaymentMethodOptionsGiropay with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsGiropaySetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsGrabpaySetupFutureUsage = | [<JsonPropertyName("none")>] None'

    type Create'PaymentMethodOptionsGrabpay =
        {
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsGrabpaySetupFutureUsage option
        }

    type Create'PaymentMethodOptionsGrabpay with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsGrabpaySetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsIdealSetupFutureUsage = | [<JsonPropertyName("none")>] None'

    type Create'PaymentMethodOptionsIdeal =
        {
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsIdealSetupFutureUsage option
        }

    type Create'PaymentMethodOptionsIdeal with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsIdealSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsKakaoPayCaptureMethod = | Manual

    type Create'PaymentMethodOptionsKakaoPaySetupFutureUsage =
        | [<JsonPropertyName("none")>] None'
        | OffSession

    type Create'PaymentMethodOptionsKakaoPay =
        {
            /// Controls when the funds will be captured from the customer's account.
            [<Config.Form>]
            CaptureMethod: Create'PaymentMethodOptionsKakaoPayCaptureMethod option
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsKakaoPaySetupFutureUsage option
        }

    type Create'PaymentMethodOptionsKakaoPay with
        static member New(?captureMethod: Create'PaymentMethodOptionsKakaoPayCaptureMethod, ?setupFutureUsage: Create'PaymentMethodOptionsKakaoPaySetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsKlarnaCaptureMethod = | Manual

    type Create'PaymentMethodOptionsKlarnaSetupFutureUsage = | [<JsonPropertyName("none")>] None'

    type Create'PaymentMethodOptionsKlarnaSubscriptionsInterval =
        | Day
        | Month
        | Week
        | Year

    type Create'PaymentMethodOptionsKlarnaSubscriptionsNextBilling =
        {
            /// The amount of the next charge for the subscription.
            [<Config.Form>]
            Amount: int option
            /// The date of the next charge for the subscription in YYYY-MM-DD format.
            [<Config.Form>]
            Date: string option
        }

    type Create'PaymentMethodOptionsKlarnaSubscriptionsNextBilling with
        static member New(?amount: int, ?date: string) =
            {
                Amount = amount
                Date = date
            }

    type Create'PaymentMethodOptionsKlarnaSubscriptions =
        {
            /// Unit of time between subscription charges.
            [<Config.Form>]
            Interval: Create'PaymentMethodOptionsKlarnaSubscriptionsInterval option
            /// The number of intervals (specified in the `interval` attribute) between subscription charges. For example, `interval=month` and `interval_count=3` charges every 3 months.
            [<Config.Form>]
            IntervalCount: int option
            /// Name for subscription.
            [<Config.Form>]
            Name: string option
            /// Describes the upcoming charge for this subscription.
            [<Config.Form>]
            NextBilling: Create'PaymentMethodOptionsKlarnaSubscriptionsNextBilling option
            /// A non-customer-facing reference to correlate subscription charges in the Klarna app. Use a value that persists across subscription charges.
            [<Config.Form>]
            Reference: string option
        }

    type Create'PaymentMethodOptionsKlarnaSubscriptions with
        static member New(?interval: Create'PaymentMethodOptionsKlarnaSubscriptionsInterval, ?intervalCount: int, ?name: string, ?nextBilling: Create'PaymentMethodOptionsKlarnaSubscriptionsNextBilling, ?reference: string) =
            {
                Interval = interval
                IntervalCount = intervalCount
                Name = name
                NextBilling = nextBilling
                Reference = reference
            }

    type Create'PaymentMethodOptionsKlarna =
        {
            /// Controls when the funds will be captured from the customer's account.
            [<Config.Form>]
            CaptureMethod: Create'PaymentMethodOptionsKlarnaCaptureMethod option
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsKlarnaSetupFutureUsage option
            /// Subscription details if the Checkout Session sets up a future subscription.
            [<Config.Form>]
            Subscriptions: Choice<Create'PaymentMethodOptionsKlarnaSubscriptions list,string> option
        }

    type Create'PaymentMethodOptionsKlarna with
        static member New(?captureMethod: Create'PaymentMethodOptionsKlarnaCaptureMethod, ?setupFutureUsage: Create'PaymentMethodOptionsKlarnaSetupFutureUsage, ?subscriptions: Choice<Create'PaymentMethodOptionsKlarnaSubscriptions list,string>) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
                Subscriptions = subscriptions
            }

    type Create'PaymentMethodOptionsKonbiniSetupFutureUsage = | [<JsonPropertyName("none")>] None'

    type Create'PaymentMethodOptionsKonbini =
        {
            /// The number of calendar days (between 1 and 60) after which Konbini payment instructions will expire. For example, if a PaymentIntent is confirmed with Konbini and `expires_after_days` set to 2 on Monday JST, the instructions will expire on Wednesday 23:59:59 JST. Defaults to 3 days.
            [<Config.Form>]
            ExpiresAfterDays: int option
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsKonbiniSetupFutureUsage option
        }

    type Create'PaymentMethodOptionsKonbini with
        static member New(?expiresAfterDays: int, ?setupFutureUsage: Create'PaymentMethodOptionsKonbiniSetupFutureUsage) =
            {
                ExpiresAfterDays = expiresAfterDays
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsKrCardCaptureMethod = | Manual

    type Create'PaymentMethodOptionsKrCardSetupFutureUsage =
        | [<JsonPropertyName("none")>] None'
        | OffSession

    type Create'PaymentMethodOptionsKrCard =
        {
            /// Controls when the funds will be captured from the customer's account.
            [<Config.Form>]
            CaptureMethod: Create'PaymentMethodOptionsKrCardCaptureMethod option
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsKrCardSetupFutureUsage option
        }

    type Create'PaymentMethodOptionsKrCard with
        static member New(?captureMethod: Create'PaymentMethodOptionsKrCardCaptureMethod, ?setupFutureUsage: Create'PaymentMethodOptionsKrCardSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsLinkCaptureMethod = | Manual

    type Create'PaymentMethodOptionsLinkSetupFutureUsage =
        | [<JsonPropertyName("none")>] None'
        | OffSession

    type Create'PaymentMethodOptionsLink =
        {
            /// Controls when the funds will be captured from the customer's account.
            [<Config.Form>]
            CaptureMethod: Create'PaymentMethodOptionsLinkCaptureMethod option
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsLinkSetupFutureUsage option
        }

    type Create'PaymentMethodOptionsLink with
        static member New(?captureMethod: Create'PaymentMethodOptionsLinkCaptureMethod, ?setupFutureUsage: Create'PaymentMethodOptionsLinkSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsMobilepayCaptureMethod = | Manual

    type Create'PaymentMethodOptionsMobilepaySetupFutureUsage = | [<JsonPropertyName("none")>] None'

    type Create'PaymentMethodOptionsMobilepay =
        {
            /// Controls when the funds will be captured from the customer's account.
            [<Config.Form>]
            CaptureMethod: Create'PaymentMethodOptionsMobilepayCaptureMethod option
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsMobilepaySetupFutureUsage option
        }

    type Create'PaymentMethodOptionsMobilepay with
        static member New(?captureMethod: Create'PaymentMethodOptionsMobilepayCaptureMethod, ?setupFutureUsage: Create'PaymentMethodOptionsMobilepaySetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsMultibancoSetupFutureUsage = | [<JsonPropertyName("none")>] None'

    type Create'PaymentMethodOptionsMultibanco =
        {
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsMultibancoSetupFutureUsage option
        }

    type Create'PaymentMethodOptionsMultibanco with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsMultibancoSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsNaverPayCaptureMethod = | Manual

    type Create'PaymentMethodOptionsNaverPaySetupFutureUsage =
        | [<JsonPropertyName("none")>] None'
        | OffSession

    type Create'PaymentMethodOptionsNaverPay =
        {
            /// Controls when the funds will be captured from the customer's account.
            [<Config.Form>]
            CaptureMethod: Create'PaymentMethodOptionsNaverPayCaptureMethod option
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsNaverPaySetupFutureUsage option
        }

    type Create'PaymentMethodOptionsNaverPay with
        static member New(?captureMethod: Create'PaymentMethodOptionsNaverPayCaptureMethod, ?setupFutureUsage: Create'PaymentMethodOptionsNaverPaySetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsOxxoSetupFutureUsage = | [<JsonPropertyName("none")>] None'

    type Create'PaymentMethodOptionsOxxo =
        {
            /// The number of calendar days before an OXXO voucher expires. For example, if you create an OXXO voucher on Monday and you set expires_after_days to 2, the OXXO invoice will expire on Wednesday at 23:59 America/Mexico_City time.
            [<Config.Form>]
            ExpiresAfterDays: int option
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsOxxoSetupFutureUsage option
        }

    type Create'PaymentMethodOptionsOxxo with
        static member New(?expiresAfterDays: int, ?setupFutureUsage: Create'PaymentMethodOptionsOxxoSetupFutureUsage) =
            {
                ExpiresAfterDays = expiresAfterDays
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsP24SetupFutureUsage = | [<JsonPropertyName("none")>] None'

    type Create'PaymentMethodOptionsP24 =
        {
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsP24SetupFutureUsage option
            /// Confirm that the payer has accepted the P24 terms and conditions.
            [<Config.Form>]
            TosShownAndAccepted: bool option
        }

    type Create'PaymentMethodOptionsP24 with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsP24SetupFutureUsage, ?tosShownAndAccepted: bool) =
            {
                SetupFutureUsage = setupFutureUsage
                TosShownAndAccepted = tosShownAndAccepted
            }

    type Create'PaymentMethodOptionsPaycoCaptureMethod = | Manual

    type Create'PaymentMethodOptionsPayco =
        {
            /// Controls when the funds will be captured from the customer's account.
            [<Config.Form>]
            CaptureMethod: Create'PaymentMethodOptionsPaycoCaptureMethod option
        }

    type Create'PaymentMethodOptionsPayco with
        static member New(?captureMethod: Create'PaymentMethodOptionsPaycoCaptureMethod) =
            {
                CaptureMethod = captureMethod
            }

    type Create'PaymentMethodOptionsPaynowSetupFutureUsage = | [<JsonPropertyName("none")>] None'

    type Create'PaymentMethodOptionsPaynow =
        {
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsPaynowSetupFutureUsage option
        }

    type Create'PaymentMethodOptionsPaynow with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsPaynowSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsPaypalCaptureMethod = | Manual

    type Create'PaymentMethodOptionsPaypalPreferredLocale =
        | [<JsonPropertyName("cs-CZ")>] CsCZ
        | [<JsonPropertyName("da-DK")>] DaDK
        | [<JsonPropertyName("de-AT")>] DeAT
        | [<JsonPropertyName("de-DE")>] DeDE
        | [<JsonPropertyName("de-LU")>] DeLU
        | [<JsonPropertyName("el-GR")>] ElGR
        | [<JsonPropertyName("en-GB")>] EnGB
        | [<JsonPropertyName("en-US")>] EnUS
        | [<JsonPropertyName("es-ES")>] EsES
        | [<JsonPropertyName("fi-FI")>] FiFI
        | [<JsonPropertyName("fr-BE")>] FrBE
        | [<JsonPropertyName("fr-FR")>] FrFR
        | [<JsonPropertyName("fr-LU")>] FrLU
        | [<JsonPropertyName("hu-HU")>] HuHU
        | [<JsonPropertyName("it-IT")>] ItIT
        | [<JsonPropertyName("nl-BE")>] NlBE
        | [<JsonPropertyName("nl-NL")>] NlNL
        | [<JsonPropertyName("pl-PL")>] PlPL
        | [<JsonPropertyName("pt-PT")>] PtPT
        | [<JsonPropertyName("sk-SK")>] SkSK
        | [<JsonPropertyName("sv-SE")>] SvSE

    type Create'PaymentMethodOptionsPaypalSetupFutureUsage =
        | [<JsonPropertyName("none")>] None'
        | OffSession

    type Create'PaymentMethodOptionsPaypal =
        {
            /// Controls when the funds will be captured from the customer's account.
            [<Config.Form>]
            CaptureMethod: Create'PaymentMethodOptionsPaypalCaptureMethod option
            /// [Preferred locale](https://docs.stripe.com/payments/paypal/supported-locales) of the PayPal checkout page that the customer is redirected to.
            [<Config.Form>]
            PreferredLocale: Create'PaymentMethodOptionsPaypalPreferredLocale option
            /// A reference of the PayPal transaction visible to customer which is mapped to PayPal's invoice ID. This must be a globally unique ID if you have configured in your PayPal settings to block multiple payments per invoice ID.
            [<Config.Form>]
            Reference: string option
            /// The risk correlation ID for an on-session payment using a saved PayPal payment method.
            [<Config.Form>]
            RiskCorrelationId: string option
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            /// If you've already set `setup_future_usage` and you're performing a request using a publishable key, you can only update the value from `on_session` to `off_session`.
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsPaypalSetupFutureUsage option
        }

    type Create'PaymentMethodOptionsPaypal with
        static member New(?captureMethod: Create'PaymentMethodOptionsPaypalCaptureMethod, ?preferredLocale: Create'PaymentMethodOptionsPaypalPreferredLocale, ?reference: string, ?riskCorrelationId: string, ?setupFutureUsage: Create'PaymentMethodOptionsPaypalSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                PreferredLocale = preferredLocale
                Reference = reference
                RiskCorrelationId = riskCorrelationId
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsPaytoMandateOptionsAmountType =
        | Fixed
        | Maximum

    type Create'PaymentMethodOptionsPaytoMandateOptionsPaymentSchedule =
        | Adhoc
        | Annual
        | Daily
        | Fortnightly
        | Monthly
        | Quarterly
        | SemiAnnual
        | Weekly

    type Create'PaymentMethodOptionsPaytoMandateOptionsPurpose =
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

    type Create'PaymentMethodOptionsPaytoMandateOptions =
        {
            /// Amount that will be collected. It is required when `amount_type` is `fixed`.
            [<Config.Form>]
            Amount: Choice<int,string> option
            /// The type of amount that will be collected. The amount charged must be exact or up to the value of `amount` param for `fixed` or `maximum` type respectively. Defaults to `maximum`.
            [<Config.Form>]
            AmountType: Create'PaymentMethodOptionsPaytoMandateOptionsAmountType option
            /// Date, in YYYY-MM-DD format, after which payments will not be collected. Defaults to no end date.
            [<Config.Form>]
            EndDate: Choice<string,string> option
            /// The periodicity at which payments will be collected. Defaults to `adhoc`.
            [<Config.Form>]
            PaymentSchedule: Create'PaymentMethodOptionsPaytoMandateOptionsPaymentSchedule option
            /// The number of payments that will be made during a payment period. Defaults to 1 except for when `payment_schedule` is `adhoc`. In that case, it defaults to no limit.
            [<Config.Form>]
            PaymentsPerPeriod: Choice<int,string> option
            /// The purpose for which payments are made. Has a default value based on your merchant category code.
            [<Config.Form>]
            Purpose: Create'PaymentMethodOptionsPaytoMandateOptionsPurpose option
            /// Date, in YYYY-MM-DD format, from which payments will be collected. Defaults to confirmation time.
            [<Config.Form>]
            StartDate: Choice<string,string> option
        }

    type Create'PaymentMethodOptionsPaytoMandateOptions with
        static member New(?amount: Choice<int,string>, ?amountType: Create'PaymentMethodOptionsPaytoMandateOptionsAmountType, ?endDate: Choice<string,string>, ?paymentSchedule: Create'PaymentMethodOptionsPaytoMandateOptionsPaymentSchedule, ?paymentsPerPeriod: Choice<int,string>, ?purpose: Create'PaymentMethodOptionsPaytoMandateOptionsPurpose, ?startDate: Choice<string,string>) =
            {
                Amount = amount
                AmountType = amountType
                EndDate = endDate
                PaymentSchedule = paymentSchedule
                PaymentsPerPeriod = paymentsPerPeriod
                Purpose = purpose
                StartDate = startDate
            }

    type Create'PaymentMethodOptionsPaytoSetupFutureUsage =
        | [<JsonPropertyName("none")>] None'
        | OffSession

    type Create'PaymentMethodOptionsPayto =
        {
            /// Additional fields for Mandate creation
            [<Config.Form>]
            MandateOptions: Create'PaymentMethodOptionsPaytoMandateOptions option
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsPaytoSetupFutureUsage option
        }

    type Create'PaymentMethodOptionsPayto with
        static member New(?mandateOptions: Create'PaymentMethodOptionsPaytoMandateOptions, ?setupFutureUsage: Create'PaymentMethodOptionsPaytoSetupFutureUsage) =
            {
                MandateOptions = mandateOptions
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsPixAmountIncludesIof =
        | Always
        | Never

    type Create'PaymentMethodOptionsPixMandateOptionsAmountIncludesIof =
        | Always
        | Never

    type Create'PaymentMethodOptionsPixMandateOptionsAmountType =
        | Fixed
        | Maximum

    type Create'PaymentMethodOptionsPixMandateOptionsPaymentSchedule =
        | Halfyearly
        | Monthly
        | Quarterly
        | Weekly
        | Yearly

    type Create'PaymentMethodOptionsPixMandateOptions =
        {
            /// Amount to be charged for future payments. Required when `amount_type=fixed`. If not provided for `amount_type=maximum`, defaults to 40000.
            [<Config.Form>]
            Amount: int option
            /// Determines if the amount includes the IOF tax. Defaults to `never`.
            [<Config.Form>]
            AmountIncludesIof: Create'PaymentMethodOptionsPixMandateOptionsAmountIncludesIof option
            /// Type of amount. Defaults to `maximum`.
            [<Config.Form>]
            AmountType: Create'PaymentMethodOptionsPixMandateOptionsAmountType option
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Only `brl` is supported currently.
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// Date when the mandate expires and no further payments will be charged, in `YYYY-MM-DD`. If not provided, the mandate will be active until canceled. If provided, end date should be after start date.
            [<Config.Form>]
            EndDate: string option
            /// Schedule at which the future payments will be charged. Defaults to `monthly`.
            [<Config.Form>]
            PaymentSchedule: Create'PaymentMethodOptionsPixMandateOptionsPaymentSchedule option
            /// Subscription name displayed to buyers in their bank app. Defaults to the displayable business name.
            [<Config.Form>]
            Reference: string option
            /// Start date of the mandate, in `YYYY-MM-DD`. Start date should be at least 3 days in the future. Defaults to 3 days after the current date.
            [<Config.Form>]
            StartDate: string option
        }

    type Create'PaymentMethodOptionsPixMandateOptions with
        static member New(?amount: int, ?amountIncludesIof: Create'PaymentMethodOptionsPixMandateOptionsAmountIncludesIof, ?amountType: Create'PaymentMethodOptionsPixMandateOptionsAmountType, ?currency: IsoTypes.IsoCurrencyCode, ?endDate: string, ?paymentSchedule: Create'PaymentMethodOptionsPixMandateOptionsPaymentSchedule, ?reference: string, ?startDate: string) =
            {
                Amount = amount
                AmountIncludesIof = amountIncludesIof
                AmountType = amountType
                Currency = currency
                EndDate = endDate
                PaymentSchedule = paymentSchedule
                Reference = reference
                StartDate = startDate
            }

    type Create'PaymentMethodOptionsPixSetupFutureUsage =
        | [<JsonPropertyName("none")>] None'
        | OffSession

    type Create'PaymentMethodOptionsPix =
        {
            /// Determines if the amount includes the IOF tax. Defaults to `never`.
            [<Config.Form>]
            AmountIncludesIof: Create'PaymentMethodOptionsPixAmountIncludesIof option
            /// The number of seconds (between 10 and 1209600) after which Pix payment will expire. Defaults to 86400 seconds.
            [<Config.Form>]
            ExpiresAfterSeconds: int option
            /// Additional fields for mandate creation.
            [<Config.Form>]
            MandateOptions: Create'PaymentMethodOptionsPixMandateOptions option
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsPixSetupFutureUsage option
        }

    type Create'PaymentMethodOptionsPix with
        static member New(?amountIncludesIof: Create'PaymentMethodOptionsPixAmountIncludesIof, ?expiresAfterSeconds: int, ?mandateOptions: Create'PaymentMethodOptionsPixMandateOptions, ?setupFutureUsage: Create'PaymentMethodOptionsPixSetupFutureUsage) =
            {
                AmountIncludesIof = amountIncludesIof
                ExpiresAfterSeconds = expiresAfterSeconds
                MandateOptions = mandateOptions
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsRevolutPayCaptureMethod = | Manual

    type Create'PaymentMethodOptionsRevolutPaySetupFutureUsage =
        | [<JsonPropertyName("none")>] None'
        | OffSession

    type Create'PaymentMethodOptionsRevolutPay =
        {
            /// Controls when the funds will be captured from the customer's account.
            [<Config.Form>]
            CaptureMethod: Create'PaymentMethodOptionsRevolutPayCaptureMethod option
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsRevolutPaySetupFutureUsage option
        }

    type Create'PaymentMethodOptionsRevolutPay with
        static member New(?captureMethod: Create'PaymentMethodOptionsRevolutPayCaptureMethod, ?setupFutureUsage: Create'PaymentMethodOptionsRevolutPaySetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsSamsungPayCaptureMethod = | Manual

    type Create'PaymentMethodOptionsSamsungPay =
        {
            /// Controls when the funds will be captured from the customer's account.
            [<Config.Form>]
            CaptureMethod: Create'PaymentMethodOptionsSamsungPayCaptureMethod option
        }

    type Create'PaymentMethodOptionsSamsungPay with
        static member New(?captureMethod: Create'PaymentMethodOptionsSamsungPayCaptureMethod) =
            {
                CaptureMethod = captureMethod
            }

    type Create'PaymentMethodOptionsSatispayCaptureMethod = | Manual

    type Create'PaymentMethodOptionsSatispay =
        {
            /// Controls when the funds will be captured from the customer's account.
            [<Config.Form>]
            CaptureMethod: Create'PaymentMethodOptionsSatispayCaptureMethod option
        }

    type Create'PaymentMethodOptionsSatispay with
        static member New(?captureMethod: Create'PaymentMethodOptionsSatispayCaptureMethod) =
            {
                CaptureMethod = captureMethod
            }

    type Create'PaymentMethodOptionsSepaDebitMandateOptions =
        {
            /// Prefix used to generate the Mandate reference. Must be at most 12 characters long. Must consist of only uppercase letters, numbers, spaces, or the following special characters: '/', '_', '-', '&', '.'. Cannot begin with 'STRIPE'.
            [<Config.Form>]
            ReferencePrefix: Choice<string,string> option
        }

    type Create'PaymentMethodOptionsSepaDebitMandateOptions with
        static member New(?referencePrefix: Choice<string,string>) =
            {
                ReferencePrefix = referencePrefix
            }

    type Create'PaymentMethodOptionsSepaDebitSetupFutureUsage =
        | [<JsonPropertyName("none")>] None'
        | OffSession
        | OnSession

    type Create'PaymentMethodOptionsSepaDebit =
        {
            /// Additional fields for Mandate creation
            [<Config.Form>]
            MandateOptions: Create'PaymentMethodOptionsSepaDebitMandateOptions option
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsSepaDebitSetupFutureUsage option
            /// Controls when Stripe will attempt to debit the funds from the customer's account. The date must be a string in YYYY-MM-DD format. The date must be in the future and between 3 and 15 calendar days from now.
            [<Config.Form>]
            TargetDate: string option
        }

    type Create'PaymentMethodOptionsSepaDebit with
        static member New(?mandateOptions: Create'PaymentMethodOptionsSepaDebitMandateOptions, ?setupFutureUsage: Create'PaymentMethodOptionsSepaDebitSetupFutureUsage, ?targetDate: string) =
            {
                MandateOptions = mandateOptions
                SetupFutureUsage = setupFutureUsage
                TargetDate = targetDate
            }

    type Create'PaymentMethodOptionsSofortSetupFutureUsage = | [<JsonPropertyName("none")>] None'

    type Create'PaymentMethodOptionsSofort =
        {
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsSofortSetupFutureUsage option
        }

    type Create'PaymentMethodOptionsSofort with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsSofortSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsSwish =
        {
            /// The order reference that will be displayed to customers in the Swish application. Defaults to the `id` of the Payment Intent.
            [<Config.Form>]
            Reference: string option
        }

    type Create'PaymentMethodOptionsSwish with
        static member New(?reference: string) =
            {
                Reference = reference
            }

    type Create'PaymentMethodOptionsTwintSetupFutureUsage = | [<JsonPropertyName("none")>] None'

    type Create'PaymentMethodOptionsTwint =
        {
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsTwintSetupFutureUsage option
        }

    type Create'PaymentMethodOptionsTwint with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsTwintSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsUpiMandateOptionsAmountType =
        | Fixed
        | Maximum

    type Create'PaymentMethodOptionsUpiMandateOptions =
        {
            /// Amount to be charged for future payments.
            [<Config.Form>]
            Amount: int option
            /// One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
            [<Config.Form>]
            AmountType: Create'PaymentMethodOptionsUpiMandateOptionsAmountType option
            /// A description of the mandate or subscription that is meant to be displayed to the customer.
            [<Config.Form>]
            Description: string option
            /// End date of the mandate or subscription.
            [<Config.Form>]
            EndDate: DateTime option
        }

    type Create'PaymentMethodOptionsUpiMandateOptions with
        static member New(?amount: int, ?amountType: Create'PaymentMethodOptionsUpiMandateOptionsAmountType, ?description: string, ?endDate: DateTime) =
            {
                Amount = amount
                AmountType = amountType
                Description = description
                EndDate = endDate
            }

    type Create'PaymentMethodOptionsUpiSetupFutureUsage =
        | [<JsonPropertyName("none")>] None'
        | OffSession
        | OnSession

    type Create'PaymentMethodOptionsUpi =
        {
            /// Additional fields for Mandate creation
            [<Config.Form>]
            MandateOptions: Create'PaymentMethodOptionsUpiMandateOptions option
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsUpiSetupFutureUsage option
        }

    type Create'PaymentMethodOptionsUpi with
        static member New(?mandateOptions: Create'PaymentMethodOptionsUpiMandateOptions, ?setupFutureUsage: Create'PaymentMethodOptionsUpiSetupFutureUsage) =
            {
                MandateOptions = mandateOptions
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions =
        | Balances
        | Ownership
        | PaymentMethod
        | Transactions

    type Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPrefetch =
        | Balances
        | Ownership
        | Transactions

    type Create'PaymentMethodOptionsUsBankAccountFinancialConnections =
        {
            /// The list of permissions to request. If this parameter is passed, the `payment_method` permission must be included. Valid permissions include: `balances`, `ownership`, `payment_method`, and `transactions`.
            [<Config.Form>]
            Permissions: Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions list option
            /// List of data features that you would like to retrieve upon account creation.
            [<Config.Form>]
            Prefetch: Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPrefetch list option
        }

    type Create'PaymentMethodOptionsUsBankAccountFinancialConnections with
        static member New(?permissions: Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions list, ?prefetch: Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPrefetch list) =
            {
                Permissions = permissions
                Prefetch = prefetch
            }

    type Create'PaymentMethodOptionsUsBankAccountSetupFutureUsage =
        | [<JsonPropertyName("none")>] None'
        | OffSession
        | OnSession

    type Create'PaymentMethodOptionsUsBankAccountVerificationMethod =
        | Automatic
        | Instant

    type Create'PaymentMethodOptionsUsBankAccount =
        {
            /// Additional fields for Financial Connections Session creation
            [<Config.Form>]
            FinancialConnections: Create'PaymentMethodOptionsUsBankAccountFinancialConnections option
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsUsBankAccountSetupFutureUsage option
            /// Controls when Stripe will attempt to debit the funds from the customer's account. The date must be a string in YYYY-MM-DD format. The date must be in the future and between 3 and 15 calendar days from now.
            [<Config.Form>]
            TargetDate: string option
            /// Verification method for the intent
            [<Config.Form>]
            VerificationMethod: Create'PaymentMethodOptionsUsBankAccountVerificationMethod option
        }

    type Create'PaymentMethodOptionsUsBankAccount with
        static member New(?financialConnections: Create'PaymentMethodOptionsUsBankAccountFinancialConnections, ?setupFutureUsage: Create'PaymentMethodOptionsUsBankAccountSetupFutureUsage, ?targetDate: string, ?verificationMethod: Create'PaymentMethodOptionsUsBankAccountVerificationMethod) =
            {
                FinancialConnections = financialConnections
                SetupFutureUsage = setupFutureUsage
                TargetDate = targetDate
                VerificationMethod = verificationMethod
            }

    type Create'PaymentMethodOptionsWechatPayClient =
        | Android
        | Ios
        | Web

    type Create'PaymentMethodOptionsWechatPaySetupFutureUsage = | [<JsonPropertyName("none")>] None'

    type Create'PaymentMethodOptionsWechatPay =
        {
            /// The app ID registered with WeChat Pay. Only required when client is ios or android.
            [<Config.Form>]
            AppId: string option
            /// The client type that the end customer will pay from
            [<Config.Form>]
            Client: Create'PaymentMethodOptionsWechatPayClient option
            /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
            /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
            /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
            /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsWechatPaySetupFutureUsage option
        }

    type Create'PaymentMethodOptionsWechatPay with
        static member New(?appId: string, ?client: Create'PaymentMethodOptionsWechatPayClient, ?setupFutureUsage: Create'PaymentMethodOptionsWechatPaySetupFutureUsage) =
            {
                AppId = appId
                Client = client
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptions =
        {
            /// contains details about the ACSS Debit payment method options. You can't set this parameter if `ui_mode` is `custom`.
            [<Config.Form>]
            AcssDebit: Create'PaymentMethodOptionsAcssDebit option
            /// contains details about the Affirm payment method options.
            [<Config.Form>]
            Affirm: Create'PaymentMethodOptionsAffirm option
            /// contains details about the Afterpay Clearpay payment method options.
            [<Config.Form>]
            AfterpayClearpay: Create'PaymentMethodOptionsAfterpayClearpay option
            /// contains details about the Alipay payment method options.
            [<Config.Form>]
            Alipay: Create'PaymentMethodOptionsAlipay option
            /// contains details about the Alma payment method options.
            [<Config.Form>]
            Alma: Create'PaymentMethodOptionsAlma option
            /// contains details about the AmazonPay payment method options.
            [<Config.Form>]
            AmazonPay: Create'PaymentMethodOptionsAmazonPay option
            /// contains details about the AU Becs Debit payment method options.
            [<Config.Form>]
            AuBecsDebit: Create'PaymentMethodOptionsAuBecsDebit option
            /// contains details about the Bacs Debit payment method options.
            [<Config.Form>]
            BacsDebit: Create'PaymentMethodOptionsBacsDebit option
            /// contains details about the Bancontact payment method options.
            [<Config.Form>]
            Bancontact: Create'PaymentMethodOptionsBancontact option
            /// contains details about the Billie payment method options.
            [<Config.Form>]
            Billie: Create'PaymentMethodOptionsBillie option
            /// contains details about the Boleto payment method options.
            [<Config.Form>]
            Boleto: Create'PaymentMethodOptionsBoleto option
            /// contains details about the Card payment method options.
            [<Config.Form>]
            Card: Create'PaymentMethodOptionsCard option
            /// contains details about the Cashapp Pay payment method options.
            [<Config.Form>]
            Cashapp: Create'PaymentMethodOptionsCashapp option
            /// contains details about the Crypto payment method options.
            [<Config.Form>]
            Crypto: Create'PaymentMethodOptionsCrypto option
            /// contains details about the Customer Balance payment method options.
            [<Config.Form>]
            CustomerBalance: Create'PaymentMethodOptionsCustomerBalance option
            /// contains details about the DemoPay payment method options.
            [<Config.Form>]
            DemoPay: Create'PaymentMethodOptionsDemoPay option
            /// contains details about the EPS payment method options.
            [<Config.Form>]
            Eps: Create'PaymentMethodOptionsEps option
            /// contains details about the FPX payment method options.
            [<Config.Form>]
            Fpx: Create'PaymentMethodOptionsFpx option
            /// contains details about the Giropay payment method options.
            [<Config.Form>]
            Giropay: Create'PaymentMethodOptionsGiropay option
            /// contains details about the Grabpay payment method options.
            [<Config.Form>]
            Grabpay: Create'PaymentMethodOptionsGrabpay option
            /// contains details about the Ideal payment method options.
            [<Config.Form>]
            Ideal: Create'PaymentMethodOptionsIdeal option
            /// contains details about the Kakao Pay payment method options.
            [<Config.Form>]
            KakaoPay: Create'PaymentMethodOptionsKakaoPay option
            /// contains details about the Klarna payment method options.
            [<Config.Form>]
            Klarna: Create'PaymentMethodOptionsKlarna option
            /// contains details about the Konbini payment method options.
            [<Config.Form>]
            Konbini: Create'PaymentMethodOptionsKonbini option
            /// contains details about the Korean card payment method options.
            [<Config.Form>]
            KrCard: Create'PaymentMethodOptionsKrCard option
            /// contains details about the Link payment method options.
            [<Config.Form>]
            Link: Create'PaymentMethodOptionsLink option
            /// contains details about the Mobilepay payment method options.
            [<Config.Form>]
            Mobilepay: Create'PaymentMethodOptionsMobilepay option
            /// contains details about the Multibanco payment method options.
            [<Config.Form>]
            Multibanco: Create'PaymentMethodOptionsMultibanco option
            /// contains details about the Naver Pay payment method options.
            [<Config.Form>]
            NaverPay: Create'PaymentMethodOptionsNaverPay option
            /// contains details about the OXXO payment method options.
            [<Config.Form>]
            Oxxo: Create'PaymentMethodOptionsOxxo option
            /// contains details about the P24 payment method options.
            [<Config.Form>]
            P24: Create'PaymentMethodOptionsP24 option
            /// contains details about the Pay By Bank payment method options.
            [<Config.Form>]
            PayByBank: string option
            /// contains details about the PAYCO payment method options.
            [<Config.Form>]
            Payco: Create'PaymentMethodOptionsPayco option
            /// contains details about the PayNow payment method options.
            [<Config.Form>]
            Paynow: Create'PaymentMethodOptionsPaynow option
            /// contains details about the PayPal payment method options.
            [<Config.Form>]
            Paypal: Create'PaymentMethodOptionsPaypal option
            /// contains details about the PayTo payment method options.
            [<Config.Form>]
            Payto: Create'PaymentMethodOptionsPayto option
            /// contains details about the Pix payment method options.
            [<Config.Form>]
            Pix: Create'PaymentMethodOptionsPix option
            /// contains details about the RevolutPay payment method options.
            [<Config.Form>]
            RevolutPay: Create'PaymentMethodOptionsRevolutPay option
            /// contains details about the Samsung Pay payment method options.
            [<Config.Form>]
            SamsungPay: Create'PaymentMethodOptionsSamsungPay option
            /// contains details about the Satispay payment method options.
            [<Config.Form>]
            Satispay: Create'PaymentMethodOptionsSatispay option
            /// contains details about the Sepa Debit payment method options.
            [<Config.Form>]
            SepaDebit: Create'PaymentMethodOptionsSepaDebit option
            /// contains details about the Sofort payment method options.
            [<Config.Form>]
            Sofort: Create'PaymentMethodOptionsSofort option
            /// contains details about the Swish payment method options.
            [<Config.Form>]
            Swish: Create'PaymentMethodOptionsSwish option
            /// contains details about the TWINT payment method options.
            [<Config.Form>]
            Twint: Create'PaymentMethodOptionsTwint option
            /// contains details about the UPI payment method options.
            [<Config.Form>]
            Upi: Create'PaymentMethodOptionsUpi option
            /// contains details about the Us Bank Account payment method options.
            [<Config.Form>]
            UsBankAccount: Create'PaymentMethodOptionsUsBankAccount option
            /// contains details about the WeChat Pay payment method options.
            [<Config.Form>]
            WechatPay: Create'PaymentMethodOptionsWechatPay option
        }

    type Create'PaymentMethodOptions with
        static member New(?acssDebit: Create'PaymentMethodOptionsAcssDebit, ?affirm: Create'PaymentMethodOptionsAffirm, ?afterpayClearpay: Create'PaymentMethodOptionsAfterpayClearpay, ?alipay: Create'PaymentMethodOptionsAlipay, ?alma: Create'PaymentMethodOptionsAlma, ?amazonPay: Create'PaymentMethodOptionsAmazonPay, ?auBecsDebit: Create'PaymentMethodOptionsAuBecsDebit, ?bacsDebit: Create'PaymentMethodOptionsBacsDebit, ?bancontact: Create'PaymentMethodOptionsBancontact, ?billie: Create'PaymentMethodOptionsBillie, ?boleto: Create'PaymentMethodOptionsBoleto, ?card: Create'PaymentMethodOptionsCard, ?cashapp: Create'PaymentMethodOptionsCashapp, ?crypto: Create'PaymentMethodOptionsCrypto, ?customerBalance: Create'PaymentMethodOptionsCustomerBalance, ?demoPay: Create'PaymentMethodOptionsDemoPay, ?eps: Create'PaymentMethodOptionsEps, ?fpx: Create'PaymentMethodOptionsFpx, ?giropay: Create'PaymentMethodOptionsGiropay, ?grabpay: Create'PaymentMethodOptionsGrabpay, ?ideal: Create'PaymentMethodOptionsIdeal, ?kakaoPay: Create'PaymentMethodOptionsKakaoPay, ?klarna: Create'PaymentMethodOptionsKlarna, ?konbini: Create'PaymentMethodOptionsKonbini, ?krCard: Create'PaymentMethodOptionsKrCard, ?link: Create'PaymentMethodOptionsLink, ?mobilepay: Create'PaymentMethodOptionsMobilepay, ?multibanco: Create'PaymentMethodOptionsMultibanco, ?naverPay: Create'PaymentMethodOptionsNaverPay, ?oxxo: Create'PaymentMethodOptionsOxxo, ?p24: Create'PaymentMethodOptionsP24, ?payByBank: string, ?payco: Create'PaymentMethodOptionsPayco, ?paynow: Create'PaymentMethodOptionsPaynow, ?paypal: Create'PaymentMethodOptionsPaypal, ?payto: Create'PaymentMethodOptionsPayto, ?pix: Create'PaymentMethodOptionsPix, ?revolutPay: Create'PaymentMethodOptionsRevolutPay, ?samsungPay: Create'PaymentMethodOptionsSamsungPay, ?satispay: Create'PaymentMethodOptionsSatispay, ?sepaDebit: Create'PaymentMethodOptionsSepaDebit, ?sofort: Create'PaymentMethodOptionsSofort, ?swish: Create'PaymentMethodOptionsSwish, ?twint: Create'PaymentMethodOptionsTwint, ?upi: Create'PaymentMethodOptionsUpi, ?usBankAccount: Create'PaymentMethodOptionsUsBankAccount, ?wechatPay: Create'PaymentMethodOptionsWechatPay) =
            {
                AcssDebit = acssDebit
                Affirm = affirm
                AfterpayClearpay = afterpayClearpay
                Alipay = alipay
                Alma = alma
                AmazonPay = amazonPay
                AuBecsDebit = auBecsDebit
                BacsDebit = bacsDebit
                Bancontact = bancontact
                Billie = billie
                Boleto = boleto
                Card = card
                Cashapp = cashapp
                Crypto = crypto
                CustomerBalance = customerBalance
                DemoPay = demoPay
                Eps = eps
                Fpx = fpx
                Giropay = giropay
                Grabpay = grabpay
                Ideal = ideal
                KakaoPay = kakaoPay
                Klarna = klarna
                Konbini = konbini
                KrCard = krCard
                Link = link
                Mobilepay = mobilepay
                Multibanco = multibanco
                NaverPay = naverPay
                Oxxo = oxxo
                P24 = p24
                PayByBank = payByBank
                Payco = payco
                Paynow = paynow
                Paypal = paypal
                Payto = payto
                Pix = pix
                RevolutPay = revolutPay
                SamsungPay = samsungPay
                Satispay = satispay
                SepaDebit = sepaDebit
                Sofort = sofort
                Swish = swish
                Twint = twint
                Upi = upi
                UsBankAccount = usBankAccount
                WechatPay = wechatPay
            }

    type Create'PaymentMethodTypes =
        | AcssDebit
        | Affirm
        | AfterpayClearpay
        | Alipay
        | Alma
        | AmazonPay
        | AuBecsDebit
        | BacsDebit
        | Bancontact
        | Billie
        | Blik
        | Boleto
        | Card
        | Cashapp
        | Crypto
        | CustomerBalance
        | Eps
        | Fpx
        | Giropay
        | Grabpay
        | Ideal
        | KakaoPay
        | Klarna
        | Konbini
        | KrCard
        | Link
        | MbWay
        | Mobilepay
        | Multibanco
        | NaverPay
        | NzBankAccount
        | Oxxo
        | P24
        | PayByBank
        | Payco
        | Paynow
        | Paypal
        | Payto
        | Pix
        | Promptpay
        | RevolutPay
        | SamsungPay
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

    type Create'PermissionsUpdateShippingDetails =
        | ClientOnly
        | ServerOnly

    type Create'Permissions =
        {
            /// Determines which entity is allowed to update the shipping details.
            /// Default is `client_only`. Stripe Checkout client will automatically update the shipping details. If set to `server_only`, only your server is allowed to update the shipping details.
            /// When set to `server_only`, you must add the onShippingDetailsChange event handler when initializing the Stripe Checkout client and manually update the shipping details from your server using the Stripe API.
            [<Config.Form>]
            UpdateShippingDetails: Create'PermissionsUpdateShippingDetails option
        }

    type Create'Permissions with
        static member New(?updateShippingDetails: Create'PermissionsUpdateShippingDetails) =
            {
                UpdateShippingDetails = updateShippingDetails
            }

    type Create'PhoneNumberCollection =
        {
            /// Set to `true` to enable phone number collection.
            /// Can only be set in `payment` and `subscription` mode.
            [<Config.Form>]
            Enabled: bool option
        }

    type Create'PhoneNumberCollection with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Create'RedirectOnCompletion =
        | Always
        | IfRequired
        | Never

    type Create'SavedPaymentMethodOptionsAllowRedisplayFilters =
        | Always
        | Limited
        | Unspecified

    type Create'SavedPaymentMethodOptionsPaymentMethodRemove =
        | Disabled
        | Enabled

    type Create'SavedPaymentMethodOptionsPaymentMethodSave =
        | Disabled
        | Enabled

    type Create'SavedPaymentMethodOptions =
        {
            /// Uses the `allow_redisplay` value of each saved payment method to filter the set presented to a returning customer. By default, only saved payment methods with ’allow_redisplay: ‘always’ are shown in Checkout.
            [<Config.Form>]
            AllowRedisplayFilters: Create'SavedPaymentMethodOptionsAllowRedisplayFilters list option
            /// Enable customers to choose if they wish to remove their saved payment methods. Disabled by default.
            [<Config.Form>]
            PaymentMethodRemove: Create'SavedPaymentMethodOptionsPaymentMethodRemove option
            /// Enable customers to choose if they wish to save their payment method for future use. Disabled by default.
            [<Config.Form>]
            PaymentMethodSave: Create'SavedPaymentMethodOptionsPaymentMethodSave option
        }

    type Create'SavedPaymentMethodOptions with
        static member New(?allowRedisplayFilters: Create'SavedPaymentMethodOptionsAllowRedisplayFilters list, ?paymentMethodRemove: Create'SavedPaymentMethodOptionsPaymentMethodRemove, ?paymentMethodSave: Create'SavedPaymentMethodOptionsPaymentMethodSave) =
            {
                AllowRedisplayFilters = allowRedisplayFilters
                PaymentMethodRemove = paymentMethodRemove
                PaymentMethodSave = paymentMethodSave
            }

    type Create'SetupIntentData =
        {
            /// An arbitrary string attached to the object. Often useful for displaying to users.
            [<Config.Form>]
            Description: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The Stripe account for which the setup is intended.
            [<Config.Form>]
            OnBehalfOf: string option
        }

    type Create'SetupIntentData with
        static member New(?description: string, ?metadata: Map<string, string>, ?onBehalfOf: string) =
            {
                Description = description
                Metadata = metadata
                OnBehalfOf = onBehalfOf
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

    type Create'ShippingAddressCollection =
        {
            /// An array of two-letter ISO country codes representing which countries Checkout should provide as options for
            /// shipping locations.
            [<Config.Form>]
            AllowedCountries: Create'ShippingAddressCollectionAllowedCountries list option
        }

    type Create'ShippingAddressCollection with
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

    type Create'ShippingOptionsShippingRateDataDeliveryEstimateMaximum =
        {
            /// A unit of time.
            [<Config.Form>]
            Unit: Create'ShippingOptionsShippingRateDataDeliveryEstimateMaximumUnit option
            /// Must be greater than 0.
            [<Config.Form>]
            Value: int option
        }

    type Create'ShippingOptionsShippingRateDataDeliveryEstimateMaximum with
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

    type Create'ShippingOptionsShippingRateDataDeliveryEstimateMinimum =
        {
            /// A unit of time.
            [<Config.Form>]
            Unit: Create'ShippingOptionsShippingRateDataDeliveryEstimateMinimumUnit option
            /// Must be greater than 0.
            [<Config.Form>]
            Value: int option
        }

    type Create'ShippingOptionsShippingRateDataDeliveryEstimateMinimum with
        static member New(?unit: Create'ShippingOptionsShippingRateDataDeliveryEstimateMinimumUnit, ?value: int) =
            {
                Unit = unit
                Value = value
            }

    type Create'ShippingOptionsShippingRateDataDeliveryEstimate =
        {
            /// The upper bound of the estimated range. If empty, represents no upper bound i.e., infinite.
            [<Config.Form>]
            Maximum: Create'ShippingOptionsShippingRateDataDeliveryEstimateMaximum option
            /// The lower bound of the estimated range. If empty, represents no lower bound.
            [<Config.Form>]
            Minimum: Create'ShippingOptionsShippingRateDataDeliveryEstimateMinimum option
        }

    type Create'ShippingOptionsShippingRateDataDeliveryEstimate with
        static member New(?maximum: Create'ShippingOptionsShippingRateDataDeliveryEstimateMaximum, ?minimum: Create'ShippingOptionsShippingRateDataDeliveryEstimateMinimum) =
            {
                Maximum = maximum
                Minimum = minimum
            }

    type Create'ShippingOptionsShippingRateDataFixedAmount =
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

    type Create'ShippingOptionsShippingRateDataFixedAmount with
        static member New(?amount: int, ?currency: IsoTypes.IsoCurrencyCode, ?currencyOptions: Map<string, string>) =
            {
                Amount = amount
                Currency = currency
                CurrencyOptions = currencyOptions
            }

    type Create'ShippingOptionsShippingRateDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type Create'ShippingOptionsShippingRateDataType = | FixedAmount

    type Create'ShippingOptionsShippingRateData =
        {
            /// The estimated range for how long shipping will take, meant to be displayable to the customer. This will appear on CheckoutSessions.
            [<Config.Form>]
            DeliveryEstimate: Create'ShippingOptionsShippingRateDataDeliveryEstimate option
            /// The name of the shipping rate, meant to be displayable to the customer. This will appear on CheckoutSessions.
            [<Config.Form>]
            DisplayName: string option
            /// Describes a fixed amount to charge for shipping. Must be present if type is `fixed_amount`.
            [<Config.Form>]
            FixedAmount: Create'ShippingOptionsShippingRateDataFixedAmount option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Specifies whether the rate is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`.
            [<Config.Form>]
            TaxBehavior: Create'ShippingOptionsShippingRateDataTaxBehavior option
            /// A [tax code](https://docs.stripe.com/tax/tax-categories) ID. The Shipping tax code is `txcd_92010001`.
            [<Config.Form>]
            TaxCode: string option
            /// The type of calculation to use on the shipping rate.
            [<Config.Form>]
            Type: Create'ShippingOptionsShippingRateDataType option
        }

    type Create'ShippingOptionsShippingRateData with
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

    type Create'ShippingOptions =
        {
            /// The ID of the Shipping Rate to use for this shipping option.
            [<Config.Form>]
            ShippingRate: string option
            /// Parameters to be passed to Shipping Rate creation for this shipping option.
            [<Config.Form>]
            ShippingRateData: Create'ShippingOptionsShippingRateData option
        }

    type Create'ShippingOptions with
        static member New(?shippingRate: string, ?shippingRateData: Create'ShippingOptionsShippingRateData) =
            {
                ShippingRate = shippingRate
                ShippingRateData = shippingRateData
            }

    type Create'SubmitType =
        | Auto
        | Book
        | Donate
        | Pay
        | Subscribe

    type Create'SubscriptionDataBillingModeFlexibleProrationDiscounts =
        | Included
        | Itemized

    type Create'SubscriptionDataBillingModeFlexible =
        {
            /// Controls how invoices and invoice items display proration amounts and discount amounts.
            [<Config.Form>]
            ProrationDiscounts: Create'SubscriptionDataBillingModeFlexibleProrationDiscounts option
        }

    type Create'SubscriptionDataBillingModeFlexible with
        static member New(?prorationDiscounts: Create'SubscriptionDataBillingModeFlexibleProrationDiscounts) =
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

    type Create'SubscriptionDataBillingMode with
        static member New(?flexible: Create'SubscriptionDataBillingModeFlexible, ?type': Create'SubscriptionDataBillingModeType) =
            {
                Flexible = flexible
                Type = type'
            }

    type Create'SubscriptionDataInvoiceSettingsIssuerType =
        | Account
        | Self

    type Create'SubscriptionDataInvoiceSettingsIssuer =
        {
            /// The connected account being referenced when `type` is `account`.
            [<Config.Form>]
            Account: string option
            /// Type of the account referenced in the request.
            [<Config.Form>]
            Type: Create'SubscriptionDataInvoiceSettingsIssuerType option
        }

    type Create'SubscriptionDataInvoiceSettingsIssuer with
        static member New(?account: string, ?type': Create'SubscriptionDataInvoiceSettingsIssuerType) =
            {
                Account = account
                Type = type'
            }

    type Create'SubscriptionDataInvoiceSettings =
        {
            /// The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.
            [<Config.Form>]
            Issuer: Create'SubscriptionDataInvoiceSettingsIssuer option
        }

    type Create'SubscriptionDataInvoiceSettings with
        static member New(?issuer: Create'SubscriptionDataInvoiceSettingsIssuer) =
            {
                Issuer = issuer
            }

    type Create'SubscriptionDataPendingInvoiceItemIntervalInterval =
        | Day
        | Month
        | Week
        | Year

    type Create'SubscriptionDataPendingInvoiceItemInterval =
        {
            /// Specifies invoicing frequency. Either `day`, `week`, `month` or `year`.
            [<Config.Form>]
            Interval: Create'SubscriptionDataPendingInvoiceItemIntervalInterval option
            /// The number of intervals between invoices. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
            [<Config.Form>]
            IntervalCount: int option
        }

    type Create'SubscriptionDataPendingInvoiceItemInterval with
        static member New(?interval: Create'SubscriptionDataPendingInvoiceItemIntervalInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Create'SubscriptionDataProrationBehavior =
        | CreateProrations
        | [<JsonPropertyName("none")>] None'

    type Create'SubscriptionDataTransferData =
        {
            /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination.
            [<Config.Form>]
            AmountPercent: decimal option
            /// ID of an existing, connected Stripe account.
            [<Config.Form>]
            Destination: string option
        }

    type Create'SubscriptionDataTransferData with
        static member New(?amountPercent: decimal, ?destination: string) =
            {
                AmountPercent = amountPercent
                Destination = destination
            }

    type Create'SubscriptionDataTrialSettingsEndBehaviorMissingPaymentMethod =
        | Cancel
        | CreateInvoice
        | Pause

    type Create'SubscriptionDataTrialSettingsEndBehavior =
        {
            /// Indicates how the subscription should change when the trial ends if the user did not provide a payment method.
            [<Config.Form>]
            MissingPaymentMethod: Create'SubscriptionDataTrialSettingsEndBehaviorMissingPaymentMethod option
        }

    type Create'SubscriptionDataTrialSettingsEndBehavior with
        static member New(?missingPaymentMethod: Create'SubscriptionDataTrialSettingsEndBehaviorMissingPaymentMethod) =
            {
                MissingPaymentMethod = missingPaymentMethod
            }

    type Create'SubscriptionDataTrialSettings =
        {
            /// Defines how the subscription should behave when the user's free trial ends.
            [<Config.Form>]
            EndBehavior: Create'SubscriptionDataTrialSettingsEndBehavior option
        }

    type Create'SubscriptionDataTrialSettings with
        static member New(?endBehavior: Create'SubscriptionDataTrialSettingsEndBehavior) =
            {
                EndBehavior = endBehavior
            }

    type Create'SubscriptionData =
        {
            /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. To use an application fee percent, the request must be made on behalf of another account, using the `Stripe-Account` header or an OAuth key. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).
            [<Config.Form>]
            ApplicationFeePercent: decimal option
            /// A future timestamp to anchor the subscription's billing cycle for new subscriptions. You can't set this parameter if `ui_mode` is `custom`.
            [<Config.Form>]
            BillingCycleAnchor: DateTime option
            /// Controls how prorations and invoices for subscriptions are calculated and orchestrated.
            [<Config.Form>]
            BillingMode: Create'SubscriptionDataBillingMode option
            /// The tax rates that will apply to any subscription item that does not have
            /// `tax_rates` set. Invoices created will have their `default_tax_rates` populated
            /// from the subscription.
            [<Config.Form>]
            DefaultTaxRates: string list option
            /// The subscription's description, meant to be displayable to the customer.
            /// Use this field to optionally store an explanation of the subscription
            /// for rendering in the [customer portal](https://docs.stripe.com/customer-management).
            [<Config.Form>]
            Description: string option
            /// All invoices will be billed using the specified settings.
            [<Config.Form>]
            InvoiceSettings: Create'SubscriptionDataInvoiceSettings option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The account on behalf of which to charge, for each of the subscription's invoices.
            [<Config.Form>]
            OnBehalfOf: string option
            /// Specifies an interval for how often to bill for any pending invoice items. It is analogous to calling [Create an invoice](https://docs.stripe.com/api#create_invoice) for the given subscription at the specified interval.
            [<Config.Form>]
            PendingInvoiceItemInterval: Create'SubscriptionDataPendingInvoiceItemInterval option
            /// Determines how to handle prorations resulting from the `billing_cycle_anchor`. If no value is passed, the default is `create_prorations`.
            [<Config.Form>]
            ProrationBehavior: Create'SubscriptionDataProrationBehavior option
            /// If specified, the funds from the subscription's invoices will be transferred to the destination and the ID of the resulting transfers will be found on the resulting charges.
            [<Config.Form>]
            TransferData: Create'SubscriptionDataTransferData option
            /// Unix timestamp representing the end of the trial period the customer will get before being charged for the first time. Has to be at least 48 hours in the future.
            [<Config.Form>]
            TrialEnd: DateTime option
            /// Integer representing the number of trial period days before the customer is charged for the first time. Has to be at least 1.
            [<Config.Form>]
            TrialPeriodDays: int option
            /// Settings related to subscription trials.
            [<Config.Form>]
            TrialSettings: Create'SubscriptionDataTrialSettings option
        }

    type Create'SubscriptionData with
        static member New(?applicationFeePercent: decimal, ?billingCycleAnchor: DateTime, ?billingMode: Create'SubscriptionDataBillingMode, ?defaultTaxRates: string list, ?description: string, ?invoiceSettings: Create'SubscriptionDataInvoiceSettings, ?metadata: Map<string, string>, ?onBehalfOf: string, ?pendingInvoiceItemInterval: Create'SubscriptionDataPendingInvoiceItemInterval, ?prorationBehavior: Create'SubscriptionDataProrationBehavior, ?transferData: Create'SubscriptionDataTransferData, ?trialEnd: DateTime, ?trialPeriodDays: int, ?trialSettings: Create'SubscriptionDataTrialSettings) =
            {
                ApplicationFeePercent = applicationFeePercent
                BillingCycleAnchor = billingCycleAnchor
                BillingMode = billingMode
                DefaultTaxRates = defaultTaxRates
                Description = description
                InvoiceSettings = invoiceSettings
                Metadata = metadata
                OnBehalfOf = onBehalfOf
                PendingInvoiceItemInterval = pendingInvoiceItemInterval
                ProrationBehavior = prorationBehavior
                TransferData = transferData
                TrialEnd = trialEnd
                TrialPeriodDays = trialPeriodDays
                TrialSettings = trialSettings
            }

    type Create'TaxIdCollectionRequired =
        | IfSupported
        | Never

    type Create'TaxIdCollection =
        {
            /// Enable tax ID collection during checkout. Defaults to `false`.
            [<Config.Form>]
            Enabled: bool option
            /// Describes whether a tax ID is required during checkout. Defaults to `never`. You can't set this parameter if `ui_mode` is `custom`.
            [<Config.Form>]
            Required: Create'TaxIdCollectionRequired option
        }

    type Create'TaxIdCollection with
        static member New(?enabled: bool, ?required: Create'TaxIdCollectionRequired) =
            {
                Enabled = enabled
                Required = required
            }

    type Create'UiMode =
        | Elements
        | EmbeddedPage
        | Form
        | HostedPage

    type Create'WalletOptionsLinkDisplay =
        | Auto
        | Never

    type Create'WalletOptionsLink =
        {
            /// Specifies whether Checkout should display Link as a payment option. By default, Checkout will display all the supported wallets that the Checkout Session was created with. This is the `auto` behavior, and it is the default choice.
            [<Config.Form>]
            Display: Create'WalletOptionsLinkDisplay option
        }

    type Create'WalletOptionsLink with
        static member New(?display: Create'WalletOptionsLinkDisplay) =
            {
                Display = display
            }

    type Create'WalletOptions =
        {
            /// contains details about the Link wallet options.
            [<Config.Form>]
            Link: Create'WalletOptionsLink option
        }

    type Create'WalletOptions with
        static member New(?link: Create'WalletOptionsLink) =
            {
                Link = link
            }

    type CreateOptions =
        {
            /// Settings for price localization with [Adaptive Pricing](https://docs.stripe.com/payments/checkout/adaptive-pricing).
            [<Config.Form>]
            AdaptivePricing: Create'AdaptivePricing option
            /// Configure actions after a Checkout Session has expired. You can't set this parameter if `ui_mode` is `custom`.
            [<Config.Form>]
            AfterExpiration: Create'AfterExpiration option
            /// Enables user redeemable promotion codes.
            [<Config.Form>]
            AllowPromotionCodes: bool option
            /// Settings for automatic tax lookup for this session and resulting payments, invoices, and subscriptions.
            [<Config.Form>]
            AutomaticTax: Create'AutomaticTax option
            /// Specify whether Checkout should collect the customer's billing address. Defaults to `auto`.
            [<Config.Form>]
            BillingAddressCollection: Create'BillingAddressCollection option
            /// The branding settings for the Checkout Session. This parameter is not allowed if ui_mode is `custom`.
            [<Config.Form>]
            BrandingSettings: Create'BrandingSettings option
            /// If set, Checkout displays a back button and customers will be directed to this URL if they decide to cancel payment and return to your website. This parameter is not allowed if ui_mode is `embedded` or `custom`.
            [<Config.Form>]
            CancelUrl: string option
            /// A unique string to reference the Checkout Session. This can be a
            /// customer ID, a cart ID, or similar, and can be used to reconcile the
            /// session with your internal systems.
            [<Config.Form>]
            ClientReferenceId: string option
            /// Configure fields for the Checkout Session to gather active consent from customers.
            [<Config.Form>]
            ConsentCollection: Create'ConsentCollection option
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies). Required in `setup` mode when `payment_method_types` is not set.
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// Collect additional information from your customer using custom fields. Up to 3 fields are supported. You can't set this parameter if `ui_mode` is `custom`.
            [<Config.Form>]
            CustomFields: Create'CustomFields list option
            /// Display additional text for your customers using custom text. You can't set this parameter if `ui_mode` is `custom`.
            [<Config.Form>]
            CustomText: Create'CustomText option
            /// ID of an existing Customer, if one exists. In `payment` mode, the customer’s most recently saved card
            /// payment method will be used to prefill the email, name, card details, and billing address
            /// on the Checkout page. In `subscription` mode, the customer’s [default payment method](https://docs.stripe.com/api/customers/update#update_customer-invoice_settings-default_payment_method)
            /// will be used if it’s a card, otherwise the most recently saved card will be used. A valid billing address, billing name and billing email are required on the payment method for Checkout to prefill the customer's card details.
            /// If the Customer already has a valid [email](https://docs.stripe.com/api/customers/object#customer_object-email) set, the email will be prefilled and not editable in Checkout.
            /// If the Customer does not have a valid `email`, Checkout will set the email entered during the session on the Customer.
            /// If blank for Checkout Sessions in `subscription` mode or with `customer_creation` set as `always` in `payment` mode, Checkout will create a new Customer object based on information provided during the payment flow.
            /// You can set [`payment_intent_data.setup_future_usage`](https://docs.stripe.com/api/checkout/sessions/create#create_checkout_session-payment_intent_data-setup_future_usage) to have Checkout automatically attach the payment method to the Customer you pass in for future reuse.
            [<Config.Form>]
            Customer: string option
            /// ID of an existing Account, if one exists. Has the same behavior as `customer`.
            [<Config.Form>]
            CustomerAccount: string option
            /// Configure whether a Checkout Session creates a [Customer](https://docs.stripe.com/api/customers) during Session confirmation.
            /// When a Customer is not created, you can still retrieve email, address, and other customer data entered in Checkout
            /// with [customer_details](https://docs.stripe.com/api/checkout/sessions/object#checkout_session_object-customer_details).
            /// Sessions that don't create Customers instead are grouped by [guest customers](https://docs.stripe.com/payments/checkout/guest-customers)
            /// in the Dashboard. Promotion codes limited to first time customers will return invalid for these Sessions.
            /// Can only be set in `payment` and `setup` mode.
            [<Config.Form>]
            CustomerCreation: Create'CustomerCreation option
            /// If provided, this value will be used when the Customer object is created.
            /// If not provided, customers will be asked to enter their email address.
            /// Use this parameter to prefill customer data if you already have an email
            /// on file. To access information about the customer once a session is
            /// complete, use the `customer` field.
            [<Config.Form>]
            CustomerEmail: string option
            /// Controls what fields on Customer can be updated by the Checkout Session. Can only be provided when `customer` is provided.
            [<Config.Form>]
            CustomerUpdate: Create'CustomerUpdate option
            /// The coupon or promotion code to apply to this Session. Currently, only up to one may be specified.
            [<Config.Form>]
            Discounts: Create'Discounts list option
            /// A list of the types of payment methods (e.g., `card`) that should be excluded from this Checkout Session. This should only be used when payment methods for this Checkout Session are managed through the [Stripe Dashboard](https://dashboard.stripe.com/settings/payment_methods).
            [<Config.Form>]
            ExcludedPaymentMethodTypes: Create'ExcludedPaymentMethodTypes list option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The Epoch time in seconds at which the Checkout Session will expire. It can be anywhere from 30 minutes to 24 hours after Checkout Session creation. By default, this value is 24 hours from creation.
            [<Config.Form>]
            ExpiresAt: DateTime option
            /// The integration identifier for this Checkout Session. Multiple Checkout Sessions can have the same integration identifier.
            [<Config.Form>]
            IntegrationIdentifier: string option
            /// Generate a post-purchase Invoice for one-time payments.
            [<Config.Form>]
            InvoiceCreation: Create'InvoiceCreation option
            /// A list of items the customer is purchasing. Use this parameter to pass one-time or recurring [Prices](https://docs.stripe.com/api/prices). The parameter is required for `payment` and `subscription` mode.
            /// For `payment` mode, there is a maximum of 100 line items, however it is recommended to consolidate line items if there are more than a few dozen.
            /// For `subscription` mode, there is a maximum of 20 line items with recurring Prices and 20 line items with one-time Prices. Line items with one-time Prices will be on the initial invoice only.
            [<Config.Form>]
            LineItems: Create'LineItems list option
            /// The IETF language tag of the locale Checkout is displayed in. If blank or `auto`, the browser's locale is used.
            [<Config.Form>]
            Locale: Create'Locale option
            /// Settings for Managed Payments for this Checkout Session and resulting [PaymentIntents](/api/payment_intents/object), [Invoices](/api/invoices/object), and [Subscriptions](/api/subscriptions/object).
            [<Config.Form>]
            ManagedPayments: Create'ManagedPayments option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The mode of the Checkout Session. Pass `subscription` if the Checkout Session includes at least one recurring item.
            [<Config.Form>]
            Mode: Create'Mode option
            /// Controls name collection settings for the session.
            /// You can configure Checkout to collect your customers' business names, individual names, or both. Each name field can be either required or optional.
            /// If a [Customer](https://docs.stripe.com/api/customers) is created or provided, the names can be saved to the Customer object as well.
            /// You can't set this parameter if `ui_mode` is `custom`.
            [<Config.Form>]
            NameCollection: Create'NameCollection option
            /// A list of optional items the customer can add to their order at checkout. Use this parameter to pass one-time or recurring [Prices](https://docs.stripe.com/api/prices).
            /// There is a maximum of 10 optional items allowed on a Checkout Session, and the existing limits on the number of line items allowed on a Checkout Session apply to the combined number of line items and optional items.
            /// For `payment` mode, there is a maximum of 100 combined line items and optional items, however it is recommended to consolidate items if there are more than a few dozen.
            /// For `subscription` mode, there is a maximum of 20 line items and optional items with recurring Prices and 20 line items and optional items with one-time Prices.
            /// You can't set this parameter if `ui_mode` is `custom`.
            [<Config.Form>]
            OptionalItems: Create'OptionalItems list option
            /// Where the user is coming from. This informs the optimizations that are applied to the session. You can't set this parameter if `ui_mode` is `custom`.
            [<Config.Form>]
            OriginContext: Create'OriginContext option
            /// A subset of parameters to be passed to PaymentIntent creation for Checkout Sessions in `payment` mode.
            [<Config.Form>]
            PaymentIntentData: Create'PaymentIntentData option
            /// Specify whether Checkout should collect a payment method. When set to `if_required`, Checkout will not collect a payment method when the total due for the session is 0.
            /// This may occur if the Checkout Session includes a free trial or a discount.
            /// Can only be set in `subscription` mode. Defaults to `always`.
            /// If you'd like information on how to collect a payment method outside of Checkout, read the guide on configuring [subscriptions with a free trial](https://docs.stripe.com/payments/checkout/free-trials).
            [<Config.Form>]
            PaymentMethodCollection: Create'PaymentMethodCollection option
            /// The ID of the payment method configuration to use with this Checkout session.
            [<Config.Form>]
            PaymentMethodConfiguration: string option
            /// This parameter allows you to set some attributes on the payment method created during a Checkout session.
            [<Config.Form>]
            PaymentMethodData: Create'PaymentMethodData option
            /// Payment-method-specific configuration.
            [<Config.Form>]
            PaymentMethodOptions: Create'PaymentMethodOptions option
            /// A list of the types of payment methods (e.g., `card`) this Checkout Session can accept.
            /// You can omit this attribute to manage your payment methods from the [Stripe Dashboard](https://dashboard.stripe.com/settings/payment_methods).
            /// See [Dynamic Payment Methods](https://docs.stripe.com/payments/payment-methods/integration-options#using-dynamic-payment-methods) for more details.
            /// Read more about the supported payment methods and their requirements in our [payment
            /// method details guide](/docs/payments/checkout/payment-methods).
            /// If multiple payment methods are passed, Checkout will dynamically reorder them to
            /// prioritize the most relevant payment methods based on the customer's location and
            /// other characteristics.
            [<Config.Form>]
            PaymentMethodTypes: Create'PaymentMethodTypes list option
            /// This property is used to set up permissions for various actions (e.g., update) on the CheckoutSession object. Can only be set when creating `embedded` or `custom` sessions.
            /// For specific permissions, please refer to their dedicated subsections, such as `permissions.update_shipping_details`.
            [<Config.Form>]
            Permissions: Create'Permissions option
            /// Controls phone number collection settings for the session.
            /// We recommend that you review your privacy policy and check with your legal contacts
            /// before using this feature. Learn more about [collecting phone numbers with Checkout](https://docs.stripe.com/payments/checkout/phone-numbers).
            [<Config.Form>]
            PhoneNumberCollection: Create'PhoneNumberCollection option
            /// This parameter applies to `ui_mode: embedded`. Learn more about the [redirect behavior](https://docs.stripe.com/payments/checkout/custom-success-page?payment-ui=embedded-form) of embedded sessions. Defaults to `always`.
            [<Config.Form>]
            RedirectOnCompletion: Create'RedirectOnCompletion option
            /// The URL to redirect your customer back to after they authenticate or cancel their payment on the
            /// payment method's app or site. This parameter is required if `ui_mode` is `embedded` or `custom`
            /// and redirect-based payment methods are enabled on the session.
            [<Config.Form>]
            ReturnUrl: string option
            /// Controls saved payment method settings for the session. Only available in `payment` and `subscription` mode.
            [<Config.Form>]
            SavedPaymentMethodOptions: Create'SavedPaymentMethodOptions option
            /// A subset of parameters to be passed to SetupIntent creation for Checkout Sessions in `setup` mode.
            [<Config.Form>]
            SetupIntentData: Create'SetupIntentData option
            /// When set, provides configuration for Checkout to collect a shipping address from a customer.
            [<Config.Form>]
            ShippingAddressCollection: Create'ShippingAddressCollection option
            /// The shipping rate options to apply to this Session. Up to a maximum of 5.
            [<Config.Form>]
            ShippingOptions: Create'ShippingOptions list option
            /// Describes the type of transaction being performed by Checkout in order
            /// to customize relevant text on the page, such as the submit button.
            /// `submit_type` can only be specified on Checkout Sessions in
            /// `payment` or `subscription` mode. If blank or `auto`, `pay` is used.
            /// You can't set this parameter if `ui_mode` is `custom`.
            [<Config.Form>]
            SubmitType: Create'SubmitType option
            /// A subset of parameters to be passed to subscription creation for Checkout Sessions in `subscription` mode.
            [<Config.Form>]
            SubscriptionData: Create'SubscriptionData option
            /// The URL to which Stripe should send customers when payment or setup
            /// is complete.
            /// This parameter is not allowed if ui_mode is `embedded` or `custom`. If you'd like to use
            /// information from the successful Checkout Session on your page, read the
            /// guide on [customizing your success page](https://docs.stripe.com/payments/checkout/custom-success-page).
            [<Config.Form>]
            SuccessUrl: string option
            /// Controls tax ID collection during checkout.
            [<Config.Form>]
            TaxIdCollection: Create'TaxIdCollection option
            /// The UI mode of the Session. Defaults to `hosted`.
            [<Config.Form>]
            UiMode: Create'UiMode option
            /// Wallet-specific configuration.
            [<Config.Form>]
            WalletOptions: Create'WalletOptions option
        }

    type CreateOptions with
        static member New(?adaptivePricing: Create'AdaptivePricing, ?afterExpiration: Create'AfterExpiration, ?allowPromotionCodes: bool, ?automaticTax: Create'AutomaticTax, ?billingAddressCollection: Create'BillingAddressCollection, ?brandingSettings: Create'BrandingSettings, ?cancelUrl: string, ?clientReferenceId: string, ?consentCollection: Create'ConsentCollection, ?currency: IsoTypes.IsoCurrencyCode, ?customFields: Create'CustomFields list, ?customText: Create'CustomText, ?customer: string, ?customerAccount: string, ?customerCreation: Create'CustomerCreation, ?customerEmail: string, ?customerUpdate: Create'CustomerUpdate, ?discounts: Create'Discounts list, ?excludedPaymentMethodTypes: Create'ExcludedPaymentMethodTypes list, ?expand: string list, ?expiresAt: DateTime, ?integrationIdentifier: string, ?invoiceCreation: Create'InvoiceCreation, ?lineItems: Create'LineItems list, ?locale: Create'Locale, ?managedPayments: Create'ManagedPayments, ?metadata: Map<string, string>, ?mode: Create'Mode, ?nameCollection: Create'NameCollection, ?optionalItems: Create'OptionalItems list, ?originContext: Create'OriginContext, ?paymentIntentData: Create'PaymentIntentData, ?paymentMethodCollection: Create'PaymentMethodCollection, ?paymentMethodConfiguration: string, ?paymentMethodData: Create'PaymentMethodData, ?paymentMethodOptions: Create'PaymentMethodOptions, ?paymentMethodTypes: Create'PaymentMethodTypes list, ?permissions: Create'Permissions, ?phoneNumberCollection: Create'PhoneNumberCollection, ?redirectOnCompletion: Create'RedirectOnCompletion, ?returnUrl: string, ?savedPaymentMethodOptions: Create'SavedPaymentMethodOptions, ?setupIntentData: Create'SetupIntentData, ?shippingAddressCollection: Create'ShippingAddressCollection, ?shippingOptions: Create'ShippingOptions list, ?submitType: Create'SubmitType, ?subscriptionData: Create'SubscriptionData, ?successUrl: string, ?taxIdCollection: Create'TaxIdCollection, ?uiMode: Create'UiMode, ?walletOptions: Create'WalletOptions) =
            {
                AdaptivePricing = adaptivePricing
                AfterExpiration = afterExpiration
                AllowPromotionCodes = allowPromotionCodes
                AutomaticTax = automaticTax
                BillingAddressCollection = billingAddressCollection
                BrandingSettings = brandingSettings
                CancelUrl = cancelUrl
                ClientReferenceId = clientReferenceId
                ConsentCollection = consentCollection
                Currency = currency
                CustomFields = customFields
                CustomText = customText
                Customer = customer
                CustomerAccount = customerAccount
                CustomerCreation = customerCreation
                CustomerEmail = customerEmail
                CustomerUpdate = customerUpdate
                Discounts = discounts
                ExcludedPaymentMethodTypes = excludedPaymentMethodTypes
                Expand = expand
                ExpiresAt = expiresAt
                IntegrationIdentifier = integrationIdentifier
                InvoiceCreation = invoiceCreation
                LineItems = lineItems
                Locale = locale
                ManagedPayments = managedPayments
                Metadata = metadata
                Mode = mode
                NameCollection = nameCollection
                OptionalItems = optionalItems
                OriginContext = originContext
                PaymentIntentData = paymentIntentData
                PaymentMethodCollection = paymentMethodCollection
                PaymentMethodConfiguration = paymentMethodConfiguration
                PaymentMethodData = paymentMethodData
                PaymentMethodOptions = paymentMethodOptions
                PaymentMethodTypes = paymentMethodTypes
                Permissions = permissions
                PhoneNumberCollection = phoneNumberCollection
                RedirectOnCompletion = redirectOnCompletion
                ReturnUrl = returnUrl
                SavedPaymentMethodOptions = savedPaymentMethodOptions
                SetupIntentData = setupIntentData
                ShippingAddressCollection = shippingAddressCollection
                ShippingOptions = shippingOptions
                SubmitType = submitType
                SubscriptionData = subscriptionData
                SuccessUrl = successUrl
                TaxIdCollection = taxIdCollection
                UiMode = uiMode
                WalletOptions = walletOptions
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Session: string
        }

    type RetrieveOptions with
        static member New(session: string, ?expand: string list) =
            {
                Session = session
                Expand = expand
            }

    type Update'CollectedInformationShippingDetailsAddress =
        {
            /// City, district, suburb, town, or village.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Address line 1, such as the street, PO Box, or company name.
            [<Config.Form>]
            Line1: string option
            /// Address line 2, such as the apartment, suite, unit, or building.
            [<Config.Form>]
            Line2: string option
            /// ZIP or postal code.
            [<Config.Form>]
            PostalCode: string option
            /// State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
            [<Config.Form>]
            State: string option
        }

    type Update'CollectedInformationShippingDetailsAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'CollectedInformationShippingDetails =
        {
            /// The address of the customer
            [<Config.Form>]
            Address: Update'CollectedInformationShippingDetailsAddress option
            /// The name of customer
            [<Config.Form>]
            Name: string option
        }

    type Update'CollectedInformationShippingDetails with
        static member New(?address: Update'CollectedInformationShippingDetailsAddress, ?name: string) =
            {
                Address = address
                Name = name
            }

    type Update'CollectedInformation =
        {
            /// The shipping details to apply to this Session.
            [<Config.Form>]
            ShippingDetails: Update'CollectedInformationShippingDetails option
        }

    type Update'CollectedInformation with
        static member New(?shippingDetails: Update'CollectedInformationShippingDetails) =
            {
                ShippingDetails = shippingDetails
            }

    type Update'LineItemsAdjustableQuantity =
        {
            /// Set to true if the quantity can be adjusted to any positive integer. Setting to false will remove any previously specified constraints on quantity.
            [<Config.Form>]
            Enabled: bool option
            /// The maximum quantity the customer can purchase for the Checkout Session. By default this value is 99. You can specify a value up to 999999.
            [<Config.Form>]
            Maximum: int option
            /// The minimum quantity the customer must purchase for the Checkout Session. By default this value is 0.
            [<Config.Form>]
            Minimum: int option
        }

    type Update'LineItemsAdjustableQuantity with
        static member New(?enabled: bool, ?maximum: int, ?minimum: int) =
            {
                Enabled = enabled
                Maximum = maximum
                Minimum = minimum
            }

    type Update'LineItemsPriceDataProductData =
        {
            /// The product's description, meant to be displayable to the customer. Use this field to optionally store a long form explanation of the product being sold for your own rendering purposes.
            [<Config.Form>]
            Description: string option
            /// A list of up to 8 URLs of images for this product, meant to be displayable to the customer.
            [<Config.Form>]
            Images: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The product's name, meant to be displayable to the customer.
            [<Config.Form>]
            Name: string option
            /// A [tax code](https://docs.stripe.com/tax/tax-categories) ID.
            [<Config.Form>]
            TaxCode: string option
            /// A label that represents units of this product. When set, this will be included in customers' receipts, invoices, Checkout, and the customer portal.
            [<Config.Form>]
            UnitLabel: string option
        }

    type Update'LineItemsPriceDataProductData with
        static member New(?description: string, ?images: string list, ?metadata: Map<string, string>, ?name: string, ?taxCode: string, ?unitLabel: string) =
            {
                Description = description
                Images = images
                Metadata = metadata
                Name = name
                TaxCode = taxCode
                UnitLabel = unitLabel
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

    type Update'LineItemsPriceDataRecurring with
        static member New(?interval: Update'LineItemsPriceDataRecurringInterval, ?intervalCount: int) =
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
            /// The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to. One of `product` or `product_data` is required.
            [<Config.Form>]
            Product: string option
            /// Data used to generate a new [Product](https://docs.stripe.com/api/products) object inline. One of `product` or `product_data` is required.
            [<Config.Form>]
            ProductData: Update'LineItemsPriceDataProductData option
            /// The recurring components of a price such as `interval` and `interval_count`.
            [<Config.Form>]
            Recurring: Update'LineItemsPriceDataRecurring option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: Update'LineItemsPriceDataTaxBehavior option
            /// A non-negative integer in cents (or local equivalent) representing how much to charge. One of `unit_amount` or `unit_amount_decimal` is required.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    type Update'LineItemsPriceData with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?productData: Update'LineItemsPriceDataProductData, ?recurring: Update'LineItemsPriceDataRecurring, ?taxBehavior: Update'LineItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                ProductData = productData
                Recurring = recurring
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Update'LineItems =
        {
            /// When set, provides configuration for this item’s quantity to be adjusted by the customer during Checkout.
            [<Config.Form>]
            AdjustableQuantity: Update'LineItemsAdjustableQuantity option
            /// ID of an existing line item.
            [<Config.Form>]
            Id: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The ID of the [Price](https://docs.stripe.com/api/prices). One of `price` or `price_data` is required when creating a new line item.
            [<Config.Form>]
            Price: string option
            /// Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required when creating a new line item.
            [<Config.Form>]
            PriceData: Update'LineItemsPriceData option
            /// The quantity of the line item being purchased. Quantity should not be defined when `recurring.usage_type=metered`.
            [<Config.Form>]
            Quantity: int option
            /// The [tax rates](https://docs.stripe.com/api/tax_rates) which apply to this line item.
            [<Config.Form>]
            TaxRates: Choice<string list,string> option
        }

    type Update'LineItems with
        static member New(?adjustableQuantity: Update'LineItemsAdjustableQuantity, ?id: string, ?metadata: Map<string, string>, ?price: string, ?priceData: Update'LineItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                AdjustableQuantity = adjustableQuantity
                Id = id
                Metadata = metadata
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Update'ShippingOptionsShippingRateDataDeliveryEstimateMaximumUnit =
        | BusinessDay
        | Day
        | Hour
        | Month
        | Week

    type Update'ShippingOptionsShippingRateDataDeliveryEstimateMaximum =
        {
            /// A unit of time.
            [<Config.Form>]
            Unit: Update'ShippingOptionsShippingRateDataDeliveryEstimateMaximumUnit option
            /// Must be greater than 0.
            [<Config.Form>]
            Value: int option
        }

    type Update'ShippingOptionsShippingRateDataDeliveryEstimateMaximum with
        static member New(?unit: Update'ShippingOptionsShippingRateDataDeliveryEstimateMaximumUnit, ?value: int) =
            {
                Unit = unit
                Value = value
            }

    type Update'ShippingOptionsShippingRateDataDeliveryEstimateMinimumUnit =
        | BusinessDay
        | Day
        | Hour
        | Month
        | Week

    type Update'ShippingOptionsShippingRateDataDeliveryEstimateMinimum =
        {
            /// A unit of time.
            [<Config.Form>]
            Unit: Update'ShippingOptionsShippingRateDataDeliveryEstimateMinimumUnit option
            /// Must be greater than 0.
            [<Config.Form>]
            Value: int option
        }

    type Update'ShippingOptionsShippingRateDataDeliveryEstimateMinimum with
        static member New(?unit: Update'ShippingOptionsShippingRateDataDeliveryEstimateMinimumUnit, ?value: int) =
            {
                Unit = unit
                Value = value
            }

    type Update'ShippingOptionsShippingRateDataDeliveryEstimate =
        {
            /// The upper bound of the estimated range. If empty, represents no upper bound i.e., infinite.
            [<Config.Form>]
            Maximum: Update'ShippingOptionsShippingRateDataDeliveryEstimateMaximum option
            /// The lower bound of the estimated range. If empty, represents no lower bound.
            [<Config.Form>]
            Minimum: Update'ShippingOptionsShippingRateDataDeliveryEstimateMinimum option
        }

    type Update'ShippingOptionsShippingRateDataDeliveryEstimate with
        static member New(?maximum: Update'ShippingOptionsShippingRateDataDeliveryEstimateMaximum, ?minimum: Update'ShippingOptionsShippingRateDataDeliveryEstimateMinimum) =
            {
                Maximum = maximum
                Minimum = minimum
            }

    type Update'ShippingOptionsShippingRateDataFixedAmount =
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

    type Update'ShippingOptionsShippingRateDataFixedAmount with
        static member New(?amount: int, ?currency: IsoTypes.IsoCurrencyCode, ?currencyOptions: Map<string, string>) =
            {
                Amount = amount
                Currency = currency
                CurrencyOptions = currencyOptions
            }

    type Update'ShippingOptionsShippingRateDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type Update'ShippingOptionsShippingRateDataType = | FixedAmount

    type Update'ShippingOptionsShippingRateData =
        {
            /// The estimated range for how long shipping will take, meant to be displayable to the customer. This will appear on CheckoutSessions.
            [<Config.Form>]
            DeliveryEstimate: Update'ShippingOptionsShippingRateDataDeliveryEstimate option
            /// The name of the shipping rate, meant to be displayable to the customer. This will appear on CheckoutSessions.
            [<Config.Form>]
            DisplayName: string option
            /// Describes a fixed amount to charge for shipping. Must be present if type is `fixed_amount`.
            [<Config.Form>]
            FixedAmount: Update'ShippingOptionsShippingRateDataFixedAmount option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Specifies whether the rate is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`.
            [<Config.Form>]
            TaxBehavior: Update'ShippingOptionsShippingRateDataTaxBehavior option
            /// A [tax code](https://docs.stripe.com/tax/tax-categories) ID. The Shipping tax code is `txcd_92010001`.
            [<Config.Form>]
            TaxCode: string option
            /// The type of calculation to use on the shipping rate.
            [<Config.Form>]
            Type: Update'ShippingOptionsShippingRateDataType option
        }

    type Update'ShippingOptionsShippingRateData with
        static member New(?deliveryEstimate: Update'ShippingOptionsShippingRateDataDeliveryEstimate, ?displayName: string, ?fixedAmount: Update'ShippingOptionsShippingRateDataFixedAmount, ?metadata: Map<string, string>, ?taxBehavior: Update'ShippingOptionsShippingRateDataTaxBehavior, ?taxCode: string, ?type': Update'ShippingOptionsShippingRateDataType) =
            {
                DeliveryEstimate = deliveryEstimate
                DisplayName = displayName
                FixedAmount = fixedAmount
                Metadata = metadata
                TaxBehavior = taxBehavior
                TaxCode = taxCode
                Type = type'
            }

    type Update'ShippingOptions =
        {
            /// The ID of the Shipping Rate to use for this shipping option.
            [<Config.Form>]
            ShippingRate: string option
            /// Parameters to be passed to Shipping Rate creation for this shipping option.
            [<Config.Form>]
            ShippingRateData: Update'ShippingOptionsShippingRateData option
        }

    type Update'ShippingOptions with
        static member New(?shippingRate: string, ?shippingRateData: Update'ShippingOptionsShippingRateData) =
            {
                ShippingRate = shippingRate
                ShippingRateData = shippingRateData
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Session: string
            /// Information about the customer collected within the Checkout Session. Can only be set when updating `embedded` or `custom` sessions.
            [<Config.Form>]
            CollectedInformation: Update'CollectedInformation option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// A list of items the customer is purchasing.
            /// When updating line items, you must retransmit the entire array of line items.
            /// To retain an existing line item, specify its `id`.
            /// To update an existing line item, specify its `id` along with the new values of the fields to update.
            /// To add a new line item, specify one of `price` or `price_data` and `quantity`.
            /// To remove an existing line item, omit the line item's ID from the retransmitted array.
            /// To reorder a line item, specify it at the desired position in the retransmitted array.
            [<Config.Form>]
            LineItems: Update'LineItems list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The shipping rate options to apply to this Session. Up to a maximum of 5.
            [<Config.Form>]
            ShippingOptions: Choice<Update'ShippingOptions list,string> option
        }

    type UpdateOptions with
        static member New(session: string, ?collectedInformation: Update'CollectedInformation, ?expand: string list, ?lineItems: Update'LineItems list, ?metadata: Map<string, string>, ?shippingOptions: Choice<Update'ShippingOptions list,string>) =
            {
                Session = session
                CollectedInformation = collectedInformation
                Expand = expand
                LineItems = lineItems
                Metadata = metadata
                ShippingOptions = shippingOptions
            }

    ///<p>Returns a list of Checkout Sessions.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("customer", options.Customer |> box); ("customer_account", options.CustomerAccount |> box); ("customer_details", options.CustomerDetails |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("payment_intent", options.PaymentIntent |> box); ("payment_link", options.PaymentLink |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("subscription", options.Subscription |> box)] |> Map.ofList
        $"/v1/checkout/sessions"
        |> RestApi.getAsync<StripeList<CheckoutSession>> settings qs

    ///<p>Creates a Checkout Session object.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/checkout/sessions"
        |> RestApi.postAsync<_, CheckoutSession> settings (Map.empty) options

    ///<p>Retrieves a Checkout Session object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/checkout/sessions/{options.Session}"
        |> RestApi.getAsync<CheckoutSession> settings qs

    ///<p>Updates a Checkout Session object.</p>
    ///<p>Related guide: <a href="/payments/advanced/dynamic-updates">Dynamically update a Checkout Session</a></p>
    let Update settings (options: UpdateOptions) =
        $"/v1/checkout/sessions/{options.Session}"
        |> RestApi.postAsync<_, CheckoutSession> settings (Map.empty) options

module CheckoutSessionsExpire =

    type ExpireOptions =
        {
            [<Config.Path>]
            Session: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type ExpireOptions with
        static member New(session: string, ?expand: string list) =
            {
                Session = session
                Expand = expand
            }

    ///<p>A Checkout Session can be expired when it is in one of these statuses: <code>open</code> </p>
    ///<p>After it expires, a customer can’t complete a Checkout Session and customers loading the Checkout Session see a message saying the Checkout Session is expired.</p>
    let Expire settings (options: ExpireOptions) =
        $"/v1/checkout/sessions/{options.Session}/expire"
        |> RestApi.postAsync<_, CheckoutSession> settings (Map.empty) options

module CheckoutSessionsLineItems =

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
            Session: string
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    type ListLineItemsOptions with
        static member New(session: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Session = session
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>When retrieving a Checkout Session, there is an includable <strong>line_items</strong> property containing the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p>
    let ListLineItems settings (options: ListLineItemsOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/checkout/sessions/{options.Session}/line_items"
        |> RestApi.getAsync<StripeList<Item>> settings qs

