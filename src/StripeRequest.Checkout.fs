namespace FunStripe.StripeRequest

open FunStripe
open System.Text.Json.Serialization
open FunStripe.StripeModel
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module CheckoutSessions =

    type ListOptions = {
        ///<summary>Only return Checkout Sessions that were created during the given date interval.</summary>
        [<Config.Query>]Created: int option
        ///<summary>Only return the Checkout Sessions for the Customer specified.</summary>
        [<Config.Query>]Customer: string option
        ///<summary>Only return the Checkout Sessions for the Account specified.</summary>
        [<Config.Query>]CustomerAccount: string option
        ///<summary>Only return the Checkout Sessions for the Customer details specified.</summary>
        [<Config.Query>]CustomerDetails: Map<string, string> option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>Only return the Checkout Session for the PaymentIntent specified.</summary>
        [<Config.Query>]PaymentIntent: string option
        ///<summary>Only return the Checkout Sessions for the Payment Link specified.</summary>
        [<Config.Query>]PaymentLink: string option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Only return the Checkout Sessions matching the given status.</summary>
        [<Config.Query>]Status: string option
        ///<summary>Only return the Checkout Session for the subscription specified.</summary>
        [<Config.Query>]Subscription: string option
    }
    with
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

    ///<summary><p>Returns a list of Checkout Sessions.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("customer", options.Customer |> box); ("customer_account", options.CustomerAccount |> box); ("customer_details", options.CustomerDetails |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("payment_intent", options.PaymentIntent |> box); ("payment_link", options.PaymentLink |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("subscription", options.Subscription |> box)] |> Map.ofList
        $"/v1/checkout/sessions"
        |> RestApi.getAsync<StripeList<CheckoutSession>> settings qs

    type Create'AdaptivePricing = {
        ///<summary>If set to `true`, Adaptive Pricing is available on [eligible sessions](https://docs.stripe.com/payments/currencies/localize-prices/adaptive-pricing?payment-ui=stripe-hosted#restrictions). Defaults to your [dashboard setting](https://dashboard.stripe.com/settings/adaptive-pricing).</summary>
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Create'AfterExpirationRecovery = {
        ///<summary>Enables user redeemable promotion codes on the recovered Checkout Sessions. Defaults to `false`</summary>
        [<Config.Form>]AllowPromotionCodes: bool option
        ///<summary>If `true`, a recovery URL will be generated to recover this Checkout Session if it
        ///expires before a successful transaction is completed. It will be attached to the
        ///Checkout Session object upon expiration.</summary>
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?allowPromotionCodes: bool, ?enabled: bool) =
            {
                AllowPromotionCodes = allowPromotionCodes
                Enabled = enabled
            }

    type Create'AfterExpiration = {
        ///<summary>Configure a Checkout Session that can be used to recover an expired session.</summary>
        [<Config.Form>]Recovery: Create'AfterExpirationRecovery option
    }
    with
        static member New(?recovery: Create'AfterExpirationRecovery) =
            {
                Recovery = recovery
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
        ///Enabling this parameter causes Checkout to collect any billing address information necessary for tax calculation.</summary>
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

    type Create'BrandingSettingsIconType =
    | File
    | Url

    type Create'BrandingSettingsIcon = {
        ///<summary>The ID of a [File upload](https://stripe.com/docs/api/files) representing the icon. Purpose must be `business_icon`. Required if `type` is `file` and disallowed otherwise.</summary>
        [<Config.Form>]File: string option
        ///<summary>The type of image for the icon. Must be one of `file` or `url`.</summary>
        [<Config.Form>]Type: Create'BrandingSettingsIconType option
        ///<summary>The URL of the image. Required if `type` is `url` and disallowed otherwise.</summary>
        [<Config.Form>]Url: string option
    }
    with
        static member New(?file: string, ?type': Create'BrandingSettingsIconType, ?url: string) =
            {
                File = file
                Type = type'
                Url = url
            }

    type Create'BrandingSettingsLogoType =
    | File
    | Url

    type Create'BrandingSettingsLogo = {
        ///<summary>The ID of a [File upload](https://stripe.com/docs/api/files) representing the logo. Purpose must be `business_logo`. Required if `type` is `file` and disallowed otherwise.</summary>
        [<Config.Form>]File: string option
        ///<summary>The type of image for the logo. Must be one of `file` or `url`.</summary>
        [<Config.Form>]Type: Create'BrandingSettingsLogoType option
        ///<summary>The URL of the image. Required if `type` is `url` and disallowed otherwise.</summary>
        [<Config.Form>]Url: string option
    }
    with
        static member New(?file: string, ?type': Create'BrandingSettingsLogoType, ?url: string) =
            {
                File = file
                Type = type'
                Url = url
            }

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

    type Create'BrandingSettings = {
        ///<summary>A hex color value starting with `#` representing the background color for the Checkout Session.</summary>
        [<Config.Form>]BackgroundColor: Choice<string,string> option
        ///<summary>The border style for the Checkout Session.</summary>
        [<Config.Form>]BorderStyle: Create'BrandingSettingsBorderStyle option
        ///<summary>A hex color value starting with `#` representing the button color for the Checkout Session.</summary>
        [<Config.Form>]ButtonColor: Choice<string,string> option
        ///<summary>A string to override the business name shown on the Checkout Session. This only shows at the top of the Checkout page, and your business name still appears in terms, receipts, and other places.</summary>
        [<Config.Form>]DisplayName: string option
        ///<summary>The font family for the Checkout Session corresponding to one of the [supported font families](https://docs.stripe.com/payments/checkout/customization/appearance?payment-ui=stripe-hosted#font-compatibility).</summary>
        [<Config.Form>]FontFamily: Create'BrandingSettingsFontFamily option
        ///<summary>The icon for the Checkout Session. For best results, use a square image.</summary>
        [<Config.Form>]Icon: Create'BrandingSettingsIcon option
        ///<summary>The logo for the Checkout Session.</summary>
        [<Config.Form>]Logo: Create'BrandingSettingsLogo option
    }
    with
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
        ///<summary>Describes whether Checkout saves the billing address onto `customer.address`.
        ///To always collect a full billing address, use `billing_address_collection`. Defaults to `never`.</summary>
        [<Config.Form>]Address: Create'CustomerUpdateAddress option
        ///<summary>Describes whether Checkout saves the name onto `customer.name`. Defaults to `never`.</summary>
        [<Config.Form>]Name: Create'CustomerUpdateName option
        ///<summary>Describes whether Checkout saves shipping information onto `customer.shipping`.
        ///To collect shipping information, use `shipping_address_collection`. Defaults to `never`.</summary>
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
        ///<summary>The ID of the coupon to apply to this Session.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>The ID of a promotion code to apply to this Session.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
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
        ///<summary>Set to `true` to enable invoice creation.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>Parameters passed when creating invoices for payment-mode Checkout Sessions.</summary>
        [<Config.Form>]InvoiceData: Create'InvoiceCreationInvoiceData option
    }
    with
        static member New(?enabled: bool, ?invoiceData: Create'InvoiceCreationInvoiceData) =
            {
                Enabled = enabled
                InvoiceData = invoiceData
            }

    type Create'LineItemsAdjustableQuantity = {
        ///<summary>Set to true if the quantity can be adjusted to any non-negative integer.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The maximum quantity the customer can purchase for the Checkout Session. By default this value is 99. You can specify a value up to 999999.</summary>
        [<Config.Form>]Maximum: int option
        ///<summary>The minimum quantity the customer must purchase for the Checkout Session. By default this value is 0.</summary>
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
        ///<summary>When set, provides configuration for this item’s quantity to be adjusted by the customer during Checkout.</summary>
        [<Config.Form>]AdjustableQuantity: Create'LineItemsAdjustableQuantity option
        ///<summary>The [tax rates](https://docs.stripe.com/api/tax_rates) that will be applied to this line item depending on the customer's billing/shipping address. We currently support the following countries: US, GB, AU, and all countries in the EU. You can't set this parameter if `ui_mode` is `custom`.</summary>
        [<Config.Form>]DynamicTaxRates: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The ID of the [Price](https://docs.stripe.com/api/prices) or [Plan](https://docs.stripe.com/api/plans) object. One of `price` or `price_data` is required.</summary>
        [<Config.Form>]Price: string option
        ///<summary>Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.</summary>
        [<Config.Form>]PriceData: Create'LineItemsPriceData option
        ///<summary>The quantity of the line item being purchased. Quantity should not be defined when `recurring.usage_type=metered`.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>The [tax rates](https://docs.stripe.com/api/tax_rates) which apply to this line item.</summary>
        [<Config.Form>]TaxRates: string list option
    }
    with
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
        ///<summary>Enable business name collection on the Checkout Session. Defaults to `false`.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>Whether the customer is required to provide a business name before completing the Checkout Session. Defaults to `false`.</summary>
        [<Config.Form>]Optional: bool option
    }
    with
        static member New(?enabled: bool, ?optional: bool) =
            {
                Enabled = enabled
                Optional = optional
            }

    type Create'NameCollectionIndividual = {
        ///<summary>Enable individual name collection on the Checkout Session. Defaults to `false`.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>Whether the customer is required to provide their name before completing the Checkout Session. Defaults to `false`.</summary>
        [<Config.Form>]Optional: bool option
    }
    with
        static member New(?enabled: bool, ?optional: bool) =
            {
                Enabled = enabled
                Optional = optional
            }

    type Create'NameCollection = {
        ///<summary>Controls settings applied for collecting the customer's business name on the session.</summary>
        [<Config.Form>]Business: Create'NameCollectionBusiness option
        ///<summary>Controls settings applied for collecting the customer's individual name on the session.</summary>
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
        ///<summary>The maximum quantity of this item the customer can purchase. By default this value is 99. You can specify a value up to 999999.</summary>
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

    type Create'PaymentIntentDataShippingAddress = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'PaymentIntentDataShipping = {
        ///<summary>Shipping address.</summary>
        [<Config.Form>]Address: Create'PaymentIntentDataShippingAddress option
        ///<summary>The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc.</summary>
        [<Config.Form>]Carrier: string option
        ///<summary>Recipient name.</summary>
        [<Config.Form>]Name: string option
        ///<summary>Recipient phone (including extension).</summary>
        [<Config.Form>]Phone: string option
        ///<summary>The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.</summary>
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

    type Create'PaymentIntentDataCaptureMethod =
    | Automatic
    | AutomaticAsync
    | Manual

    type Create'PaymentIntentDataSetupFutureUsage =
    | OffSession
    | OnSession

    type Create'PaymentIntentData = {
        ///<summary>The amount of the application fee (if any) that will be requested to be applied to the payment and transferred to the application owner's Stripe account. The amount of the application fee collected will be capped at the total amount captured. For more information, see the PaymentIntents [use case for connected accounts](https://docs.stripe.com/payments/connected-accounts).</summary>
        [<Config.Form>]ApplicationFeeAmount: int option
        ///<summary>Controls when the funds will be captured from the customer's account.</summary>
        [<Config.Form>]CaptureMethod: Create'PaymentIntentDataCaptureMethod option
        ///<summary>An arbitrary string attached to the object. Often useful for displaying to users.</summary>
        [<Config.Form>]Description: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The Stripe account ID for which these funds are intended. For details,
        ///see the PaymentIntents [use case for connected
        ///accounts](/docs/payments/connected-accounts).</summary>
        [<Config.Form>]OnBehalfOf: string option
        ///<summary>Email address that the receipt for the resulting payment will be sent to. If `receipt_email` is specified for a payment in live mode, a receipt will be sent regardless of your [email settings](https://dashboard.stripe.com/account/emails).</summary>
        [<Config.Form>]ReceiptEmail: string option
        ///<summary>Indicates that you intend to [make future payments](https://docs.stripe.com/payments/payment-intents#future-usage) with the payment
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
        ///legislation and network rules, such as SCA.</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentIntentDataSetupFutureUsage option
        ///<summary>Shipping information for this payment.</summary>
        [<Config.Form>]Shipping: Create'PaymentIntentDataShipping option
        ///<summary>Text that appears on the customer's statement as the statement descriptor for a non-card charge. This value overrides the account's default statement descriptor. For information about requirements, including the 22-character limit, see [the Statement Descriptor docs](https://docs.stripe.com/get-started/account/statement-descriptors).
        ///Setting this value for a card charge returns an error. For card charges, set the [statement_descriptor_suffix](https://docs.stripe.com/get-started/account/statement-descriptors#dynamic) instead.</summary>
        [<Config.Form>]StatementDescriptor: string option
        ///<summary>Provides information about a card charge. Concatenated to the account's [statement descriptor prefix](https://docs.stripe.com/get-started/account/statement-descriptors#static) to form the complete statement descriptor that appears on the customer's statement.</summary>
        [<Config.Form>]StatementDescriptorSuffix: string option
        ///<summary>The parameters used to automatically create a Transfer when the payment succeeds.
        ///For more information, see the PaymentIntents [use case for connected accounts](https://docs.stripe.com/payments/connected-accounts).</summary>
        [<Config.Form>]TransferData: Create'PaymentIntentDataTransferData option
        ///<summary>A string that identifies the resulting payment as part of a group. See the PaymentIntents [use case for connected accounts](https://docs.stripe.com/connect/separate-charges-and-transfers) for details.</summary>
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

    type Create'PaymentMethodDataAllowRedisplay =
    | Always
    | Limited
    | Unspecified

    type Create'PaymentMethodData = {
        ///<summary>Allow redisplay will be set on the payment method on confirmation and indicates whether this payment method can be shown again to the customer in a checkout flow. Only set this field if you wish to override the allow_redisplay value determined by Checkout.</summary>
        [<Config.Form>]AllowRedisplay: Create'PaymentMethodDataAllowRedisplay option
    }
    with
        static member New(?allowRedisplay: Create'PaymentMethodDataAllowRedisplay) =
            {
                AllowRedisplay = allowRedisplay
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
        ///<summary>A URL for custom mandate text to render during confirmation step.
        ///The URL will be rendered with additional GET parameters `payment_intent` and `payment_intent_client_secret` when confirming a Payment Intent,
        ///or `setup_intent` and `setup_intent_client_secret` when confirming a Setup Intent.</summary>
        [<Config.Form>]CustomMandateUrl: Choice<string,string> option
        ///<summary>List of Stripe products where this mandate can be selected automatically. Only usable in `setup` mode.</summary>
        [<Config.Form>]DefaultFor: Create'PaymentMethodOptionsAcssDebitMandateOptionsDefaultFor list option
        ///<summary>Description of the mandate interval. Only required if 'payment_schedule' parameter is 'interval' or 'combined'.</summary>
        [<Config.Form>]IntervalDescription: string option
        ///<summary>Payment schedule for the mandate.</summary>
        [<Config.Form>]PaymentSchedule: Create'PaymentMethodOptionsAcssDebitMandateOptionsPaymentSchedule option
        ///<summary>Transaction type of the mandate.</summary>
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
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies). This is only accepted for Checkout Sessions in `setup` mode.</summary>
        [<Config.Form>]Currency: Create'PaymentMethodOptionsAcssDebitCurrency option
        ///<summary>Additional fields for Mandate creation</summary>
        [<Config.Form>]MandateOptions: Create'PaymentMethodOptionsAcssDebitMandateOptions option
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsAcssDebitSetupFutureUsage option
        ///<summary>Controls when Stripe will attempt to debit the funds from the customer's account. The date must be a string in YYYY-MM-DD format. The date must be in the future and between 3 and 15 calendar days from now.</summary>
        [<Config.Form>]TargetDate: string option
        ///<summary>Verification method for the intent</summary>
        [<Config.Form>]VerificationMethod: Create'PaymentMethodOptionsAcssDebitVerificationMethod option
    }
    with
        static member New(?currency: Create'PaymentMethodOptionsAcssDebitCurrency, ?mandateOptions: Create'PaymentMethodOptionsAcssDebitMandateOptions, ?setupFutureUsage: Create'PaymentMethodOptionsAcssDebitSetupFutureUsage, ?targetDate: string, ?verificationMethod: Create'PaymentMethodOptionsAcssDebitVerificationMethod) =
            {
                Currency = currency
                MandateOptions = mandateOptions
                SetupFutureUsage = setupFutureUsage
                TargetDate = targetDate
                VerificationMethod = verificationMethod
            }

    type Create'PaymentMethodOptionsAffirmCaptureMethod =
    | Manual

    type Create'PaymentMethodOptionsAffirmSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsAffirm = {
        ///<summary>Controls when the funds will be captured from the customer's account.</summary>
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsAffirmCaptureMethod option
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsAffirmSetupFutureUsage option
    }
    with
        static member New(?captureMethod: Create'PaymentMethodOptionsAffirmCaptureMethod, ?setupFutureUsage: Create'PaymentMethodOptionsAffirmSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsAfterpayClearpayCaptureMethod =
    | Manual

    type Create'PaymentMethodOptionsAfterpayClearpaySetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsAfterpayClearpay = {
        ///<summary>Controls when the funds will be captured from the customer's account.</summary>
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsAfterpayClearpayCaptureMethod option
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsAfterpayClearpaySetupFutureUsage option
    }
    with
        static member New(?captureMethod: Create'PaymentMethodOptionsAfterpayClearpayCaptureMethod, ?setupFutureUsage: Create'PaymentMethodOptionsAfterpayClearpaySetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsAlipaySetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsAlipay = {
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsAlipaySetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsAlipaySetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsAlmaCaptureMethod =
    | Manual

    type Create'PaymentMethodOptionsAlma = {
        ///<summary>Controls when the funds will be captured from the customer's account.</summary>
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsAlmaCaptureMethod option
    }
    with
        static member New(?captureMethod: Create'PaymentMethodOptionsAlmaCaptureMethod) =
            {
                CaptureMethod = captureMethod
            }

    type Create'PaymentMethodOptionsAmazonPayCaptureMethod =
    | Manual

    type Create'PaymentMethodOptionsAmazonPaySetupFutureUsage =
    | None'
    | OffSession

    type Create'PaymentMethodOptionsAmazonPay = {
        ///<summary>Controls when the funds will be captured from the customer's account.</summary>
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsAmazonPayCaptureMethod option
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsAmazonPaySetupFutureUsage option
    }
    with
        static member New(?captureMethod: Create'PaymentMethodOptionsAmazonPayCaptureMethod, ?setupFutureUsage: Create'PaymentMethodOptionsAmazonPaySetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsAuBecsDebitSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsAuBecsDebit = {
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsAuBecsDebitSetupFutureUsage option
        ///<summary>Controls when Stripe will attempt to debit the funds from the customer's account. The date must be a string in YYYY-MM-DD format. The date must be in the future and between 3 and 15 calendar days from now.</summary>
        [<Config.Form>]TargetDate: string option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsAuBecsDebitSetupFutureUsage, ?targetDate: string) =
            {
                SetupFutureUsage = setupFutureUsage
                TargetDate = targetDate
            }

    type Create'PaymentMethodOptionsBacsDebitMandateOptions = {
        ///<summary>Prefix used to generate the Mandate reference. Must be at most 12 characters long. Must consist of only uppercase letters, numbers, spaces, or the following special characters: '/', '_', '-', '&', '.'. Cannot begin with 'DDIC' or 'STRIPE'.</summary>
        [<Config.Form>]ReferencePrefix: Choice<string,string> option
    }
    with
        static member New(?referencePrefix: Choice<string,string>) =
            {
                ReferencePrefix = referencePrefix
            }

    type Create'PaymentMethodOptionsBacsDebitSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Create'PaymentMethodOptionsBacsDebit = {
        ///<summary>Additional fields for Mandate creation</summary>
        [<Config.Form>]MandateOptions: Create'PaymentMethodOptionsBacsDebitMandateOptions option
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsBacsDebitSetupFutureUsage option
        ///<summary>Controls when Stripe will attempt to debit the funds from the customer's account. The date must be a string in YYYY-MM-DD format. The date must be in the future and between 3 and 15 calendar days from now.</summary>
        [<Config.Form>]TargetDate: string option
    }
    with
        static member New(?mandateOptions: Create'PaymentMethodOptionsBacsDebitMandateOptions, ?setupFutureUsage: Create'PaymentMethodOptionsBacsDebitSetupFutureUsage, ?targetDate: string) =
            {
                MandateOptions = mandateOptions
                SetupFutureUsage = setupFutureUsage
                TargetDate = targetDate
            }

    type Create'PaymentMethodOptionsBancontactSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsBancontact = {
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsBancontactSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsBancontactSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsBillieCaptureMethod =
    | Manual

    type Create'PaymentMethodOptionsBillie = {
        ///<summary>Controls when the funds will be captured from the customer's account.</summary>
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsBillieCaptureMethod option
    }
    with
        static member New(?captureMethod: Create'PaymentMethodOptionsBillieCaptureMethod) =
            {
                CaptureMethod = captureMethod
            }

    type Create'PaymentMethodOptionsBoletoSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Create'PaymentMethodOptionsBoleto = {
        ///<summary>The number of calendar days before a Boleto voucher expires. For example, if you create a Boleto voucher on Monday and you set expires_after_days to 2, the Boleto invoice will expire on Wednesday at 23:59 America/Sao_Paulo time.</summary>
        [<Config.Form>]ExpiresAfterDays: int option
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsBoletoSetupFutureUsage option
    }
    with
        static member New(?expiresAfterDays: int, ?setupFutureUsage: Create'PaymentMethodOptionsBoletoSetupFutureUsage) =
            {
                ExpiresAfterDays = expiresAfterDays
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsCardInstallments = {
        ///<summary>Setting to true enables installments for this Checkout Session.
        ///Setting to false will prevent any installment plan from applying to a payment.</summary>
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Create'PaymentMethodOptionsCardRestrictionsBrandsBlocked =
    | AmericanExpress
    | DiscoverGlobalNetwork
    | Mastercard
    | Visa

    type Create'PaymentMethodOptionsCardRestrictions = {
        ///<summary>Specify the card brands to block in the Checkout Session. If a customer enters or selects a card belonging to a blocked brand, they can't complete the Session.</summary>
        [<Config.Form>]BrandsBlocked: Create'PaymentMethodOptionsCardRestrictionsBrandsBlocked list option
    }
    with
        static member New(?brandsBlocked: Create'PaymentMethodOptionsCardRestrictionsBrandsBlocked list) =
            {
                BrandsBlocked = brandsBlocked
            }

    type Create'PaymentMethodOptionsCardCaptureMethod =
    | Manual

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

    type Create'PaymentMethodOptionsCardSetupFutureUsage =
    | OffSession
    | OnSession

    type Create'PaymentMethodOptionsCard = {
        ///<summary>Controls when the funds will be captured from the customer's account.</summary>
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsCardCaptureMethod option
        ///<summary>Installment options for card payments</summary>
        [<Config.Form>]Installments: Create'PaymentMethodOptionsCardInstallments option
        ///<summary>Request ability to [capture beyond the standard authorization validity window](/payments/extended-authorization) for this CheckoutSession.</summary>
        [<Config.Form>]RequestExtendedAuthorization: Create'PaymentMethodOptionsCardRequestExtendedAuthorization option
        ///<summary>Request ability to [increment the authorization](/payments/incremental-authorization) for this CheckoutSession.</summary>
        [<Config.Form>]RequestIncrementalAuthorization: Create'PaymentMethodOptionsCardRequestIncrementalAuthorization option
        ///<summary>Request ability to make [multiple captures](/payments/multicapture) for this CheckoutSession.</summary>
        [<Config.Form>]RequestMulticapture: Create'PaymentMethodOptionsCardRequestMulticapture option
        ///<summary>Request ability to [overcapture](/payments/overcapture) for this CheckoutSession.</summary>
        [<Config.Form>]RequestOvercapture: Create'PaymentMethodOptionsCardRequestOvercapture option
        ///<summary>We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://docs.stripe.com/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. If not provided, this value defaults to `automatic`. Read our guide on [manually requesting 3D Secure](https://docs.stripe.com/payments/3d-secure/authentication-flow#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.</summary>
        [<Config.Form>]RequestThreeDSecure: Create'PaymentMethodOptionsCardRequestThreeDSecure option
        ///<summary>Restrictions to apply to the card payment method. For example, you can block specific card brands. You can't set this parameter if `ui_mode` is `custom`.</summary>
        [<Config.Form>]Restrictions: Create'PaymentMethodOptionsCardRestrictions option
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsCardSetupFutureUsage option
        ///<summary>Provides information about a card payment that customers see on their statements. Concatenated with the Kana prefix (shortened Kana descriptor) or Kana statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 22 characters. On card statements, the *concatenation* of both prefix and suffix (including separators) will appear truncated to 22 characters.</summary>
        [<Config.Form>]StatementDescriptorSuffixKana: string option
        ///<summary>Provides information about a card payment that customers see on their statements. Concatenated with the Kanji prefix (shortened Kanji descriptor) or Kanji statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 17 characters. On card statements, the *concatenation* of both prefix and suffix (including separators) will appear truncated to 17 characters.</summary>
        [<Config.Form>]StatementDescriptorSuffixKanji: string option
    }
    with
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

    type Create'PaymentMethodOptionsCashappCaptureMethod =
    | Manual

    type Create'PaymentMethodOptionsCashappSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Create'PaymentMethodOptionsCashapp = {
        ///<summary>Controls when the funds will be captured from the customer's account.</summary>
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsCashappCaptureMethod option
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsCashappSetupFutureUsage option
    }
    with
        static member New(?captureMethod: Create'PaymentMethodOptionsCashappCaptureMethod, ?setupFutureUsage: Create'PaymentMethodOptionsCashappSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsCryptoSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsCrypto = {
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsCryptoSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsCryptoSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsCustomerBalanceBankTransferEuBankTransfer = {
        ///<summary>The desired country code of the bank account information. Permitted values include: `DE`, `FR`, `IE`, or `NL`.</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
    }
    with
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

    type Create'PaymentMethodOptionsCustomerBalanceBankTransfer = {
        ///<summary>Configuration for eu_bank_transfer funding type.</summary>
        [<Config.Form>]EuBankTransfer: Create'PaymentMethodOptionsCustomerBalanceBankTransferEuBankTransfer option
        ///<summary>List of address types that should be returned in the financial_addresses response. If not specified, all valid types will be returned.
        ///Permitted values include: `sort_code`, `zengin`, `iban`, or `spei`.</summary>
        [<Config.Form>]RequestedAddressTypes: Create'PaymentMethodOptionsCustomerBalanceBankTransferRequestedAddressTypes list option
        ///<summary>The list of bank transfer types that this PaymentIntent is allowed to use for funding.</summary>
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
        ///<summary>Configuration for the bank transfer funding type, if the `funding_type` is set to `bank_transfer`.</summary>
        [<Config.Form>]BankTransfer: Create'PaymentMethodOptionsCustomerBalanceBankTransfer option
        ///<summary>The funding method type to be used when there are not enough funds in the customer balance. Permitted values include: `bank_transfer`.</summary>
        [<Config.Form>]FundingType: Create'PaymentMethodOptionsCustomerBalanceFundingType option
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsCustomerBalanceSetupFutureUsage option
    }
    with
        static member New(?bankTransfer: Create'PaymentMethodOptionsCustomerBalanceBankTransfer, ?fundingType: Create'PaymentMethodOptionsCustomerBalanceFundingType, ?setupFutureUsage: Create'PaymentMethodOptionsCustomerBalanceSetupFutureUsage) =
            {
                BankTransfer = bankTransfer
                FundingType = fundingType
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsDemoPaySetupFutureUsage =
    | None'
    | OffSession

    type Create'PaymentMethodOptionsDemoPay = {
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsDemoPaySetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsDemoPaySetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsEpsSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsEps = {
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
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
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
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
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
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
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
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
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsIdealSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsIdealSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsKakaoPayCaptureMethod =
    | Manual

    type Create'PaymentMethodOptionsKakaoPaySetupFutureUsage =
    | None'
    | OffSession

    type Create'PaymentMethodOptionsKakaoPay = {
        ///<summary>Controls when the funds will be captured from the customer's account.</summary>
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsKakaoPayCaptureMethod option
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsKakaoPaySetupFutureUsage option
    }
    with
        static member New(?captureMethod: Create'PaymentMethodOptionsKakaoPayCaptureMethod, ?setupFutureUsage: Create'PaymentMethodOptionsKakaoPaySetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsKlarnaSubscriptionsNextBilling = {
        ///<summary>The amount of the next charge for the subscription.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>The date of the next charge for the subscription in YYYY-MM-DD format.</summary>
        [<Config.Form>]Date: string option
    }
    with
        static member New(?amount: int, ?date: string) =
            {
                Amount = amount
                Date = date
            }

    type Create'PaymentMethodOptionsKlarnaSubscriptionsInterval =
    | Day
    | Month
    | Week
    | Year

    type Create'PaymentMethodOptionsKlarnaSubscriptions = {
        ///<summary>Unit of time between subscription charges.</summary>
        [<Config.Form>]Interval: Create'PaymentMethodOptionsKlarnaSubscriptionsInterval option
        ///<summary>The number of intervals (specified in the `interval` attribute) between subscription charges. For example, `interval=month` and `interval_count=3` charges every 3 months.</summary>
        [<Config.Form>]IntervalCount: int option
        ///<summary>Name for subscription.</summary>
        [<Config.Form>]Name: string option
        ///<summary>Describes the upcoming charge for this subscription.</summary>
        [<Config.Form>]NextBilling: Create'PaymentMethodOptionsKlarnaSubscriptionsNextBilling option
        ///<summary>A non-customer-facing reference to correlate subscription charges in the Klarna app. Use a value that persists across subscription charges.</summary>
        [<Config.Form>]Reference: string option
    }
    with
        static member New(?interval: Create'PaymentMethodOptionsKlarnaSubscriptionsInterval, ?intervalCount: int, ?name: string, ?nextBilling: Create'PaymentMethodOptionsKlarnaSubscriptionsNextBilling, ?reference: string) =
            {
                Interval = interval
                IntervalCount = intervalCount
                Name = name
                NextBilling = nextBilling
                Reference = reference
            }

    type Create'PaymentMethodOptionsKlarnaCaptureMethod =
    | Manual

    type Create'PaymentMethodOptionsKlarnaSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsKlarna = {
        ///<summary>Controls when the funds will be captured from the customer's account.</summary>
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsKlarnaCaptureMethod option
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsKlarnaSetupFutureUsage option
        ///<summary>Subscription details if the Checkout Session sets up a future subscription.</summary>
        [<Config.Form>]Subscriptions: Choice<Create'PaymentMethodOptionsKlarnaSubscriptions list,string> option
    }
    with
        static member New(?captureMethod: Create'PaymentMethodOptionsKlarnaCaptureMethod, ?setupFutureUsage: Create'PaymentMethodOptionsKlarnaSetupFutureUsage, ?subscriptions: Choice<Create'PaymentMethodOptionsKlarnaSubscriptions list,string>) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
                Subscriptions = subscriptions
            }

    type Create'PaymentMethodOptionsKonbiniSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsKonbini = {
        ///<summary>The number of calendar days (between 1 and 60) after which Konbini payment instructions will expire. For example, if a PaymentIntent is confirmed with Konbini and `expires_after_days` set to 2 on Monday JST, the instructions will expire on Wednesday 23:59:59 JST. Defaults to 3 days.</summary>
        [<Config.Form>]ExpiresAfterDays: int option
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsKonbiniSetupFutureUsage option
    }
    with
        static member New(?expiresAfterDays: int, ?setupFutureUsage: Create'PaymentMethodOptionsKonbiniSetupFutureUsage) =
            {
                ExpiresAfterDays = expiresAfterDays
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsKrCardCaptureMethod =
    | Manual

    type Create'PaymentMethodOptionsKrCardSetupFutureUsage =
    | None'
    | OffSession

    type Create'PaymentMethodOptionsKrCard = {
        ///<summary>Controls when the funds will be captured from the customer's account.</summary>
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsKrCardCaptureMethod option
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsKrCardSetupFutureUsage option
    }
    with
        static member New(?captureMethod: Create'PaymentMethodOptionsKrCardCaptureMethod, ?setupFutureUsage: Create'PaymentMethodOptionsKrCardSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsLinkCaptureMethod =
    | Manual

    type Create'PaymentMethodOptionsLinkSetupFutureUsage =
    | None'
    | OffSession

    type Create'PaymentMethodOptionsLink = {
        ///<summary>Controls when the funds will be captured from the customer's account.</summary>
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsLinkCaptureMethod option
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsLinkSetupFutureUsage option
    }
    with
        static member New(?captureMethod: Create'PaymentMethodOptionsLinkCaptureMethod, ?setupFutureUsage: Create'PaymentMethodOptionsLinkSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsMobilepayCaptureMethod =
    | Manual

    type Create'PaymentMethodOptionsMobilepaySetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsMobilepay = {
        ///<summary>Controls when the funds will be captured from the customer's account.</summary>
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsMobilepayCaptureMethod option
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsMobilepaySetupFutureUsage option
    }
    with
        static member New(?captureMethod: Create'PaymentMethodOptionsMobilepayCaptureMethod, ?setupFutureUsage: Create'PaymentMethodOptionsMobilepaySetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsMultibancoSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsMultibanco = {
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsMultibancoSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsMultibancoSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsNaverPayCaptureMethod =
    | Manual

    type Create'PaymentMethodOptionsNaverPaySetupFutureUsage =
    | None'
    | OffSession

    type Create'PaymentMethodOptionsNaverPay = {
        ///<summary>Controls when the funds will be captured from the customer's account.</summary>
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsNaverPayCaptureMethod option
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsNaverPaySetupFutureUsage option
    }
    with
        static member New(?captureMethod: Create'PaymentMethodOptionsNaverPayCaptureMethod, ?setupFutureUsage: Create'PaymentMethodOptionsNaverPaySetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsOxxoSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsOxxo = {
        ///<summary>The number of calendar days before an OXXO voucher expires. For example, if you create an OXXO voucher on Monday and you set expires_after_days to 2, the OXXO invoice will expire on Wednesday at 23:59 America/Mexico_City time.</summary>
        [<Config.Form>]ExpiresAfterDays: int option
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
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
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsP24SetupFutureUsage option
        ///<summary>Confirm that the payer has accepted the P24 terms and conditions.</summary>
        [<Config.Form>]TosShownAndAccepted: bool option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsP24SetupFutureUsage, ?tosShownAndAccepted: bool) =
            {
                SetupFutureUsage = setupFutureUsage
                TosShownAndAccepted = tosShownAndAccepted
            }

    type Create'PaymentMethodOptionsPaycoCaptureMethod =
    | Manual

    type Create'PaymentMethodOptionsPayco = {
        ///<summary>Controls when the funds will be captured from the customer's account.</summary>
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsPaycoCaptureMethod option
    }
    with
        static member New(?captureMethod: Create'PaymentMethodOptionsPaycoCaptureMethod) =
            {
                CaptureMethod = captureMethod
            }

    type Create'PaymentMethodOptionsPaynowSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsPaynow = {
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
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
    | None'
    | OffSession

    type Create'PaymentMethodOptionsPaypal = {
        ///<summary>Controls when the funds will be captured from the customer's account.</summary>
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsPaypalCaptureMethod option
        ///<summary>[Preferred locale](https://docs.stripe.com/payments/paypal/supported-locales) of the PayPal checkout page that the customer is redirected to.</summary>
        [<Config.Form>]PreferredLocale: Create'PaymentMethodOptionsPaypalPreferredLocale option
        ///<summary>A reference of the PayPal transaction visible to customer which is mapped to PayPal's invoice ID. This must be a globally unique ID if you have configured in your PayPal settings to block multiple payments per invoice ID.</summary>
        [<Config.Form>]Reference: string option
        ///<summary>The risk correlation ID for an on-session payment using a saved PayPal payment method.</summary>
        [<Config.Form>]RiskCorrelationId: string option
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
        ///If you've already set `setup_future_usage` and you're performing a request using a publishable key, you can only update the value from `on_session` to `off_session`.</summary>
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

    type Create'PaymentMethodOptionsPaytoMandateOptions = {
        ///<summary>Amount that will be collected. It is required when `amount_type` is `fixed`.</summary>
        [<Config.Form>]Amount: Choice<int,string> option
        ///<summary>The type of amount that will be collected. The amount charged must be exact or up to the value of `amount` param for `fixed` or `maximum` type respectively. Defaults to `maximum`.</summary>
        [<Config.Form>]AmountType: Create'PaymentMethodOptionsPaytoMandateOptionsAmountType option
        ///<summary>Date, in YYYY-MM-DD format, after which payments will not be collected. Defaults to no end date.</summary>
        [<Config.Form>]EndDate: Choice<string,string> option
        ///<summary>The periodicity at which payments will be collected. Defaults to `adhoc`.</summary>
        [<Config.Form>]PaymentSchedule: Create'PaymentMethodOptionsPaytoMandateOptionsPaymentSchedule option
        ///<summary>The number of payments that will be made during a payment period. Defaults to 1 except for when `payment_schedule` is `adhoc`. In that case, it defaults to no limit.</summary>
        [<Config.Form>]PaymentsPerPeriod: Choice<int,string> option
        ///<summary>The purpose for which payments are made. Has a default value based on your merchant category code.</summary>
        [<Config.Form>]Purpose: Create'PaymentMethodOptionsPaytoMandateOptionsPurpose option
        ///<summary>Date, in YYYY-MM-DD format, from which payments will be collected. Defaults to confirmation time.</summary>
        [<Config.Form>]StartDate: Choice<string,string> option
    }
    with
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
    | None'
    | OffSession

    type Create'PaymentMethodOptionsPayto = {
        ///<summary>Additional fields for Mandate creation</summary>
        [<Config.Form>]MandateOptions: Create'PaymentMethodOptionsPaytoMandateOptions option
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsPaytoSetupFutureUsage option
    }
    with
        static member New(?mandateOptions: Create'PaymentMethodOptionsPaytoMandateOptions, ?setupFutureUsage: Create'PaymentMethodOptionsPaytoSetupFutureUsage) =
            {
                MandateOptions = mandateOptions
                SetupFutureUsage = setupFutureUsage
            }

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

    type Create'PaymentMethodOptionsPixMandateOptions = {
        ///<summary>Amount to be charged for future payments. Required when `amount_type=fixed`. If not provided for `amount_type=maximum`, defaults to 40000.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Determines if the amount includes the IOF tax. Defaults to `never`.</summary>
        [<Config.Form>]AmountIncludesIof: Create'PaymentMethodOptionsPixMandateOptionsAmountIncludesIof option
        ///<summary>Type of amount. Defaults to `maximum`.</summary>
        [<Config.Form>]AmountType: Create'PaymentMethodOptionsPixMandateOptionsAmountType option
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Only `brl` is supported currently.</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>Date when the mandate expires and no further payments will be charged, in `YYYY-MM-DD`. If not provided, the mandate will be active until canceled. If provided, end date should be after start date.</summary>
        [<Config.Form>]EndDate: string option
        ///<summary>Schedule at which the future payments will be charged. Defaults to `monthly`.</summary>
        [<Config.Form>]PaymentSchedule: Create'PaymentMethodOptionsPixMandateOptionsPaymentSchedule option
        ///<summary>Subscription name displayed to buyers in their bank app. Defaults to the displayable business name.</summary>
        [<Config.Form>]Reference: string option
        ///<summary>Start date of the mandate, in `YYYY-MM-DD`. Start date should be at least 3 days in the future. Defaults to 3 days after the current date.</summary>
        [<Config.Form>]StartDate: string option
    }
    with
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

    type Create'PaymentMethodOptionsPixAmountIncludesIof =
    | Always
    | Never

    type Create'PaymentMethodOptionsPixSetupFutureUsage =
    | None'
    | OffSession

    type Create'PaymentMethodOptionsPix = {
        ///<summary>Determines if the amount includes the IOF tax. Defaults to `never`.</summary>
        [<Config.Form>]AmountIncludesIof: Create'PaymentMethodOptionsPixAmountIncludesIof option
        ///<summary>The number of seconds (between 10 and 1209600) after which Pix payment will expire. Defaults to 86400 seconds.</summary>
        [<Config.Form>]ExpiresAfterSeconds: int option
        ///<summary>Additional fields for mandate creation.</summary>
        [<Config.Form>]MandateOptions: Create'PaymentMethodOptionsPixMandateOptions option
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsPixSetupFutureUsage option
    }
    with
        static member New(?amountIncludesIof: Create'PaymentMethodOptionsPixAmountIncludesIof, ?expiresAfterSeconds: int, ?mandateOptions: Create'PaymentMethodOptionsPixMandateOptions, ?setupFutureUsage: Create'PaymentMethodOptionsPixSetupFutureUsage) =
            {
                AmountIncludesIof = amountIncludesIof
                ExpiresAfterSeconds = expiresAfterSeconds
                MandateOptions = mandateOptions
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsRevolutPayCaptureMethod =
    | Manual

    type Create'PaymentMethodOptionsRevolutPaySetupFutureUsage =
    | None'
    | OffSession

    type Create'PaymentMethodOptionsRevolutPay = {
        ///<summary>Controls when the funds will be captured from the customer's account.</summary>
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsRevolutPayCaptureMethod option
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsRevolutPaySetupFutureUsage option
    }
    with
        static member New(?captureMethod: Create'PaymentMethodOptionsRevolutPayCaptureMethod, ?setupFutureUsage: Create'PaymentMethodOptionsRevolutPaySetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsSamsungPayCaptureMethod =
    | Manual

    type Create'PaymentMethodOptionsSamsungPay = {
        ///<summary>Controls when the funds will be captured from the customer's account.</summary>
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsSamsungPayCaptureMethod option
    }
    with
        static member New(?captureMethod: Create'PaymentMethodOptionsSamsungPayCaptureMethod) =
            {
                CaptureMethod = captureMethod
            }

    type Create'PaymentMethodOptionsSatispayCaptureMethod =
    | Manual

    type Create'PaymentMethodOptionsSatispay = {
        ///<summary>Controls when the funds will be captured from the customer's account.</summary>
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsSatispayCaptureMethod option
    }
    with
        static member New(?captureMethod: Create'PaymentMethodOptionsSatispayCaptureMethod) =
            {
                CaptureMethod = captureMethod
            }

    type Create'PaymentMethodOptionsSepaDebitMandateOptions = {
        ///<summary>Prefix used to generate the Mandate reference. Must be at most 12 characters long. Must consist of only uppercase letters, numbers, spaces, or the following special characters: '/', '_', '-', '&', '.'. Cannot begin with 'STRIPE'.</summary>
        [<Config.Form>]ReferencePrefix: Choice<string,string> option
    }
    with
        static member New(?referencePrefix: Choice<string,string>) =
            {
                ReferencePrefix = referencePrefix
            }

    type Create'PaymentMethodOptionsSepaDebitSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Create'PaymentMethodOptionsSepaDebit = {
        ///<summary>Additional fields for Mandate creation</summary>
        [<Config.Form>]MandateOptions: Create'PaymentMethodOptionsSepaDebitMandateOptions option
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsSepaDebitSetupFutureUsage option
        ///<summary>Controls when Stripe will attempt to debit the funds from the customer's account. The date must be a string in YYYY-MM-DD format. The date must be in the future and between 3 and 15 calendar days from now.</summary>
        [<Config.Form>]TargetDate: string option
    }
    with
        static member New(?mandateOptions: Create'PaymentMethodOptionsSepaDebitMandateOptions, ?setupFutureUsage: Create'PaymentMethodOptionsSepaDebitSetupFutureUsage, ?targetDate: string) =
            {
                MandateOptions = mandateOptions
                SetupFutureUsage = setupFutureUsage
                TargetDate = targetDate
            }

    type Create'PaymentMethodOptionsSofortSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsSofort = {
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsSofortSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsSofortSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsSwish = {
        ///<summary>The order reference that will be displayed to customers in the Swish application. Defaults to the `id` of the Payment Intent.</summary>
        [<Config.Form>]Reference: string option
    }
    with
        static member New(?reference: string) =
            {
                Reference = reference
            }

    type Create'PaymentMethodOptionsTwintSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsTwint = {
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsTwintSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsTwintSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsUpiMandateOptionsAmountType =
    | Fixed
    | Maximum

    type Create'PaymentMethodOptionsUpiMandateOptions = {
        ///<summary>Amount to be charged for future payments.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.</summary>
        [<Config.Form>]AmountType: Create'PaymentMethodOptionsUpiMandateOptionsAmountType option
        ///<summary>A description of the mandate or subscription that is meant to be displayed to the customer.</summary>
        [<Config.Form>]Description: string option
        ///<summary>End date of the mandate or subscription.</summary>
        [<Config.Form>]EndDate: DateTime option
    }
    with
        static member New(?amount: int, ?amountType: Create'PaymentMethodOptionsUpiMandateOptionsAmountType, ?description: string, ?endDate: DateTime) =
            {
                Amount = amount
                AmountType = amountType
                Description = description
                EndDate = endDate
            }

    type Create'PaymentMethodOptionsUpiSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Create'PaymentMethodOptionsUpi = {
        ///<summary>Additional fields for Mandate creation</summary>
        [<Config.Form>]MandateOptions: Create'PaymentMethodOptionsUpiMandateOptions option
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsUpiSetupFutureUsage option
    }
    with
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

    type Create'PaymentMethodOptionsUsBankAccountFinancialConnections = {
        ///<summary>The list of permissions to request. If this parameter is passed, the `payment_method` permission must be included. Valid permissions include: `balances`, `ownership`, `payment_method`, and `transactions`.</summary>
        [<Config.Form>]Permissions: Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions list option
        ///<summary>List of data features that you would like to retrieve upon account creation.</summary>
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
        ///<summary>Additional fields for Financial Connections Session creation</summary>
        [<Config.Form>]FinancialConnections: Create'PaymentMethodOptionsUsBankAccountFinancialConnections option
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsUsBankAccountSetupFutureUsage option
        ///<summary>Controls when Stripe will attempt to debit the funds from the customer's account. The date must be a string in YYYY-MM-DD format. The date must be in the future and between 3 and 15 calendar days from now.</summary>
        [<Config.Form>]TargetDate: string option
        ///<summary>Verification method for the intent</summary>
        [<Config.Form>]VerificationMethod: Create'PaymentMethodOptionsUsBankAccountVerificationMethod option
    }
    with
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

    type Create'PaymentMethodOptionsWechatPaySetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsWechatPay = {
        ///<summary>The app ID registered with WeChat Pay. Only required when client is ios or android.</summary>
        [<Config.Form>]AppId: string option
        ///<summary>The client type that the end customer will pay from</summary>
        [<Config.Form>]Client: Create'PaymentMethodOptionsWechatPayClient option
        ///<summary>Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).</summary>
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
        ///<summary>contains details about the ACSS Debit payment method options. You can't set this parameter if `ui_mode` is `custom`.</summary>
        [<Config.Form>]AcssDebit: Create'PaymentMethodOptionsAcssDebit option
        ///<summary>contains details about the Affirm payment method options.</summary>
        [<Config.Form>]Affirm: Create'PaymentMethodOptionsAffirm option
        ///<summary>contains details about the Afterpay Clearpay payment method options.</summary>
        [<Config.Form>]AfterpayClearpay: Create'PaymentMethodOptionsAfterpayClearpay option
        ///<summary>contains details about the Alipay payment method options.</summary>
        [<Config.Form>]Alipay: Create'PaymentMethodOptionsAlipay option
        ///<summary>contains details about the Alma payment method options.</summary>
        [<Config.Form>]Alma: Create'PaymentMethodOptionsAlma option
        ///<summary>contains details about the AmazonPay payment method options.</summary>
        [<Config.Form>]AmazonPay: Create'PaymentMethodOptionsAmazonPay option
        ///<summary>contains details about the AU Becs Debit payment method options.</summary>
        [<Config.Form>]AuBecsDebit: Create'PaymentMethodOptionsAuBecsDebit option
        ///<summary>contains details about the Bacs Debit payment method options.</summary>
        [<Config.Form>]BacsDebit: Create'PaymentMethodOptionsBacsDebit option
        ///<summary>contains details about the Bancontact payment method options.</summary>
        [<Config.Form>]Bancontact: Create'PaymentMethodOptionsBancontact option
        ///<summary>contains details about the Billie payment method options.</summary>
        [<Config.Form>]Billie: Create'PaymentMethodOptionsBillie option
        ///<summary>contains details about the Boleto payment method options.</summary>
        [<Config.Form>]Boleto: Create'PaymentMethodOptionsBoleto option
        ///<summary>contains details about the Card payment method options.</summary>
        [<Config.Form>]Card: Create'PaymentMethodOptionsCard option
        ///<summary>contains details about the Cashapp Pay payment method options.</summary>
        [<Config.Form>]Cashapp: Create'PaymentMethodOptionsCashapp option
        ///<summary>contains details about the Crypto payment method options.</summary>
        [<Config.Form>]Crypto: Create'PaymentMethodOptionsCrypto option
        ///<summary>contains details about the Customer Balance payment method options.</summary>
        [<Config.Form>]CustomerBalance: Create'PaymentMethodOptionsCustomerBalance option
        ///<summary>contains details about the DemoPay payment method options.</summary>
        [<Config.Form>]DemoPay: Create'PaymentMethodOptionsDemoPay option
        ///<summary>contains details about the EPS payment method options.</summary>
        [<Config.Form>]Eps: Create'PaymentMethodOptionsEps option
        ///<summary>contains details about the FPX payment method options.</summary>
        [<Config.Form>]Fpx: Create'PaymentMethodOptionsFpx option
        ///<summary>contains details about the Giropay payment method options.</summary>
        [<Config.Form>]Giropay: Create'PaymentMethodOptionsGiropay option
        ///<summary>contains details about the Grabpay payment method options.</summary>
        [<Config.Form>]Grabpay: Create'PaymentMethodOptionsGrabpay option
        ///<summary>contains details about the Ideal payment method options.</summary>
        [<Config.Form>]Ideal: Create'PaymentMethodOptionsIdeal option
        ///<summary>contains details about the Kakao Pay payment method options.</summary>
        [<Config.Form>]KakaoPay: Create'PaymentMethodOptionsKakaoPay option
        ///<summary>contains details about the Klarna payment method options.</summary>
        [<Config.Form>]Klarna: Create'PaymentMethodOptionsKlarna option
        ///<summary>contains details about the Konbini payment method options.</summary>
        [<Config.Form>]Konbini: Create'PaymentMethodOptionsKonbini option
        ///<summary>contains details about the Korean card payment method options.</summary>
        [<Config.Form>]KrCard: Create'PaymentMethodOptionsKrCard option
        ///<summary>contains details about the Link payment method options.</summary>
        [<Config.Form>]Link: Create'PaymentMethodOptionsLink option
        ///<summary>contains details about the Mobilepay payment method options.</summary>
        [<Config.Form>]Mobilepay: Create'PaymentMethodOptionsMobilepay option
        ///<summary>contains details about the Multibanco payment method options.</summary>
        [<Config.Form>]Multibanco: Create'PaymentMethodOptionsMultibanco option
        ///<summary>contains details about the Naver Pay payment method options.</summary>
        [<Config.Form>]NaverPay: Create'PaymentMethodOptionsNaverPay option
        ///<summary>contains details about the OXXO payment method options.</summary>
        [<Config.Form>]Oxxo: Create'PaymentMethodOptionsOxxo option
        ///<summary>contains details about the P24 payment method options.</summary>
        [<Config.Form>]P24: Create'PaymentMethodOptionsP24 option
        ///<summary>contains details about the Pay By Bank payment method options.</summary>
        [<Config.Form>]PayByBank: string option
        ///<summary>contains details about the PAYCO payment method options.</summary>
        [<Config.Form>]Payco: Create'PaymentMethodOptionsPayco option
        ///<summary>contains details about the PayNow payment method options.</summary>
        [<Config.Form>]Paynow: Create'PaymentMethodOptionsPaynow option
        ///<summary>contains details about the PayPal payment method options.</summary>
        [<Config.Form>]Paypal: Create'PaymentMethodOptionsPaypal option
        ///<summary>contains details about the PayTo payment method options.</summary>
        [<Config.Form>]Payto: Create'PaymentMethodOptionsPayto option
        ///<summary>contains details about the Pix payment method options.</summary>
        [<Config.Form>]Pix: Create'PaymentMethodOptionsPix option
        ///<summary>contains details about the RevolutPay payment method options.</summary>
        [<Config.Form>]RevolutPay: Create'PaymentMethodOptionsRevolutPay option
        ///<summary>contains details about the Samsung Pay payment method options.</summary>
        [<Config.Form>]SamsungPay: Create'PaymentMethodOptionsSamsungPay option
        ///<summary>contains details about the Satispay payment method options.</summary>
        [<Config.Form>]Satispay: Create'PaymentMethodOptionsSatispay option
        ///<summary>contains details about the Sepa Debit payment method options.</summary>
        [<Config.Form>]SepaDebit: Create'PaymentMethodOptionsSepaDebit option
        ///<summary>contains details about the Sofort payment method options.</summary>
        [<Config.Form>]Sofort: Create'PaymentMethodOptionsSofort option
        ///<summary>contains details about the Swish payment method options.</summary>
        [<Config.Form>]Swish: Create'PaymentMethodOptionsSwish option
        ///<summary>contains details about the TWINT payment method options.</summary>
        [<Config.Form>]Twint: Create'PaymentMethodOptionsTwint option
        ///<summary>contains details about the UPI payment method options.</summary>
        [<Config.Form>]Upi: Create'PaymentMethodOptionsUpi option
        ///<summary>contains details about the Us Bank Account payment method options.</summary>
        [<Config.Form>]UsBankAccount: Create'PaymentMethodOptionsUsBankAccount option
        ///<summary>contains details about the WeChat Pay payment method options.</summary>
        [<Config.Form>]WechatPay: Create'PaymentMethodOptionsWechatPay option
    }
    with
        static member New(?acssDebit: Create'PaymentMethodOptionsAcssDebit, ?link: Create'PaymentMethodOptionsLink, ?mobilepay: Create'PaymentMethodOptionsMobilepay, ?multibanco: Create'PaymentMethodOptionsMultibanco, ?naverPay: Create'PaymentMethodOptionsNaverPay, ?oxxo: Create'PaymentMethodOptionsOxxo, ?p24: Create'PaymentMethodOptionsP24, ?payByBank: string, ?payco: Create'PaymentMethodOptionsPayco, ?paynow: Create'PaymentMethodOptionsPaynow, ?krCard: Create'PaymentMethodOptionsKrCard, ?paypal: Create'PaymentMethodOptionsPaypal, ?pix: Create'PaymentMethodOptionsPix, ?revolutPay: Create'PaymentMethodOptionsRevolutPay, ?samsungPay: Create'PaymentMethodOptionsSamsungPay, ?satispay: Create'PaymentMethodOptionsSatispay, ?sepaDebit: Create'PaymentMethodOptionsSepaDebit, ?sofort: Create'PaymentMethodOptionsSofort, ?swish: Create'PaymentMethodOptionsSwish, ?twint: Create'PaymentMethodOptionsTwint, ?upi: Create'PaymentMethodOptionsUpi, ?payto: Create'PaymentMethodOptionsPayto, ?usBankAccount: Create'PaymentMethodOptionsUsBankAccount, ?konbini: Create'PaymentMethodOptionsKonbini, ?kakaoPay: Create'PaymentMethodOptionsKakaoPay, ?affirm: Create'PaymentMethodOptionsAffirm, ?afterpayClearpay: Create'PaymentMethodOptionsAfterpayClearpay, ?alipay: Create'PaymentMethodOptionsAlipay, ?alma: Create'PaymentMethodOptionsAlma, ?amazonPay: Create'PaymentMethodOptionsAmazonPay, ?auBecsDebit: Create'PaymentMethodOptionsAuBecsDebit, ?bacsDebit: Create'PaymentMethodOptionsBacsDebit, ?bancontact: Create'PaymentMethodOptionsBancontact, ?billie: Create'PaymentMethodOptionsBillie, ?klarna: Create'PaymentMethodOptionsKlarna, ?boleto: Create'PaymentMethodOptionsBoleto, ?cashapp: Create'PaymentMethodOptionsCashapp, ?crypto: Create'PaymentMethodOptionsCrypto, ?customerBalance: Create'PaymentMethodOptionsCustomerBalance, ?demoPay: Create'PaymentMethodOptionsDemoPay, ?eps: Create'PaymentMethodOptionsEps, ?fpx: Create'PaymentMethodOptionsFpx, ?giropay: Create'PaymentMethodOptionsGiropay, ?grabpay: Create'PaymentMethodOptionsGrabpay, ?ideal: Create'PaymentMethodOptionsIdeal, ?card: Create'PaymentMethodOptionsCard, ?wechatPay: Create'PaymentMethodOptionsWechatPay) =
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

    type Create'Permissions = {
        ///<summary>Determines which entity is allowed to update the shipping details.
        ///Default is `client_only`. Stripe Checkout client will automatically update the shipping details. If set to `server_only`, only your server is allowed to update the shipping details.
        ///When set to `server_only`, you must add the onShippingDetailsChange event handler when initializing the Stripe Checkout client and manually update the shipping details from your server using the Stripe API.</summary>
        [<Config.Form>]UpdateShippingDetails: Create'PermissionsUpdateShippingDetails option
    }
    with
        static member New(?updateShippingDetails: Create'PermissionsUpdateShippingDetails) =
            {
                UpdateShippingDetails = updateShippingDetails
            }

    type Create'PhoneNumberCollection = {
        ///<summary>Set to `true` to enable phone number collection.
        ///Can only be set in `payment` and `subscription` mode.</summary>
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

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

    type Create'SavedPaymentMethodOptions = {
        ///<summary>Uses the `allow_redisplay` value of each saved payment method to filter the set presented to a returning customer. By default, only saved payment methods with ’allow_redisplay: ‘always’ are shown in Checkout.</summary>
        [<Config.Form>]AllowRedisplayFilters: Create'SavedPaymentMethodOptionsAllowRedisplayFilters list option
        ///<summary>Enable customers to choose if they wish to remove their saved payment methods. Disabled by default.</summary>
        [<Config.Form>]PaymentMethodRemove: Create'SavedPaymentMethodOptionsPaymentMethodRemove option
        ///<summary>Enable customers to choose if they wish to save their payment method for future use. Disabled by default.</summary>
        [<Config.Form>]PaymentMethodSave: Create'SavedPaymentMethodOptionsPaymentMethodSave option
    }
    with
        static member New(?allowRedisplayFilters: Create'SavedPaymentMethodOptionsAllowRedisplayFilters list, ?paymentMethodRemove: Create'SavedPaymentMethodOptionsPaymentMethodRemove, ?paymentMethodSave: Create'SavedPaymentMethodOptionsPaymentMethodSave) =
            {
                AllowRedisplayFilters = allowRedisplayFilters
                PaymentMethodRemove = paymentMethodRemove
                PaymentMethodSave = paymentMethodSave
            }

    type Create'SetupIntentData = {
        ///<summary>An arbitrary string attached to the object. Often useful for displaying to users.</summary>
        [<Config.Form>]Description: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The Stripe account for which the setup is intended.</summary>
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

    type Create'ShippingOptionsShippingRateDataDeliveryEstimateMaximumUnit =
    | BusinessDay
    | Day
    | Hour
    | Month
    | Week

    type Create'ShippingOptionsShippingRateDataDeliveryEstimateMaximum = {
        ///<summary>A unit of time.</summary>
        [<Config.Form>]Unit: Create'ShippingOptionsShippingRateDataDeliveryEstimateMaximumUnit option
        ///<summary>Must be greater than 0.</summary>
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
        ///<summary>A unit of time.</summary>
        [<Config.Form>]Unit: Create'ShippingOptionsShippingRateDataDeliveryEstimateMinimumUnit option
        ///<summary>Must be greater than 0.</summary>
        [<Config.Form>]Value: int option
    }
    with
        static member New(?unit: Create'ShippingOptionsShippingRateDataDeliveryEstimateMinimumUnit, ?value: int) =
            {
                Unit = unit
                Value = value
            }

    type Create'ShippingOptionsShippingRateDataDeliveryEstimate = {
        ///<summary>The upper bound of the estimated range. If empty, represents no upper bound i.e., infinite.</summary>
        [<Config.Form>]Maximum: Create'ShippingOptionsShippingRateDataDeliveryEstimateMaximum option
        ///<summary>The lower bound of the estimated range. If empty, represents no lower bound.</summary>
        [<Config.Form>]Minimum: Create'ShippingOptionsShippingRateDataDeliveryEstimateMinimum option
    }
    with
        static member New(?maximum: Create'ShippingOptionsShippingRateDataDeliveryEstimateMaximum, ?minimum: Create'ShippingOptionsShippingRateDataDeliveryEstimateMinimum) =
            {
                Maximum = maximum
                Minimum = minimum
            }

    type Create'ShippingOptionsShippingRateDataFixedAmount = {
        ///<summary>A non-negative integer in cents representing how much to charge.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>Shipping rates defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]CurrencyOptions: Map<string, string> option
    }
    with
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

    type Create'ShippingOptionsShippingRateDataType =
    | FixedAmount

    type Create'ShippingOptionsShippingRateData = {
        ///<summary>The estimated range for how long shipping will take, meant to be displayable to the customer. This will appear on CheckoutSessions.</summary>
        [<Config.Form>]DeliveryEstimate: Create'ShippingOptionsShippingRateDataDeliveryEstimate option
        ///<summary>The name of the shipping rate, meant to be displayable to the customer. This will appear on CheckoutSessions.</summary>
        [<Config.Form>]DisplayName: string option
        ///<summary>Describes a fixed amount to charge for shipping. Must be present if type is `fixed_amount`.</summary>
        [<Config.Form>]FixedAmount: Create'ShippingOptionsShippingRateDataFixedAmount option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Specifies whether the rate is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`.</summary>
        [<Config.Form>]TaxBehavior: Create'ShippingOptionsShippingRateDataTaxBehavior option
        ///<summary>A [tax code](https://docs.stripe.com/tax/tax-categories) ID. The Shipping tax code is `txcd_92010001`.</summary>
        [<Config.Form>]TaxCode: string option
        ///<summary>The type of calculation to use on the shipping rate.</summary>
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
        ///<summary>The ID of the Shipping Rate to use for this shipping option.</summary>
        [<Config.Form>]ShippingRate: string option
        ///<summary>Parameters to be passed to Shipping Rate creation for this shipping option.</summary>
        [<Config.Form>]ShippingRateData: Create'ShippingOptionsShippingRateData option
    }
    with
        static member New(?shippingRate: string, ?shippingRateData: Create'ShippingOptionsShippingRateData) =
            {
                ShippingRate = shippingRate
                ShippingRateData = shippingRateData
            }

    type Create'SubscriptionDataBillingModeFlexibleProrationDiscounts =
    | Included
    | Itemized

    type Create'SubscriptionDataBillingModeFlexible = {
        ///<summary>Controls how invoices and invoice items display proration amounts and discount amounts.</summary>
        [<Config.Form>]ProrationDiscounts: Create'SubscriptionDataBillingModeFlexibleProrationDiscounts option
    }
    with
        static member New(?prorationDiscounts: Create'SubscriptionDataBillingModeFlexibleProrationDiscounts) =
            {
                ProrationDiscounts = prorationDiscounts
            }

    type Create'SubscriptionDataBillingModeType =
    | Classic
    | Flexible

    type Create'SubscriptionDataBillingMode = {
        ///<summary>Configure behavior for flexible billing mode.</summary>
        [<Config.Form>]Flexible: Create'SubscriptionDataBillingModeFlexible option
        ///<summary>Controls the calculation and orchestration of prorations and invoices for subscriptions. If no value is passed, the default is `flexible`.</summary>
        [<Config.Form>]Type: Create'SubscriptionDataBillingModeType option
    }
    with
        static member New(?flexible: Create'SubscriptionDataBillingModeFlexible, ?type': Create'SubscriptionDataBillingModeType) =
            {
                Flexible = flexible
                Type = type'
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

    type Create'SubscriptionDataPendingInvoiceItemIntervalInterval =
    | Day
    | Month
    | Week
    | Year

    type Create'SubscriptionDataPendingInvoiceItemInterval = {
        ///<summary>Specifies invoicing frequency. Either `day`, `week`, `month` or `year`.</summary>
        [<Config.Form>]Interval: Create'SubscriptionDataPendingInvoiceItemIntervalInterval option
        ///<summary>The number of intervals between invoices. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).</summary>
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Create'SubscriptionDataPendingInvoiceItemIntervalInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Create'SubscriptionDataTransferData = {
        ///<summary>A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination.</summary>
        [<Config.Form>]AmountPercent: decimal option
        ///<summary>ID of an existing, connected Stripe account.</summary>
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

    type Create'SubscriptionDataProrationBehavior =
    | CreateProrations
    | None'

    type Create'SubscriptionData = {
        ///<summary>A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. To use an application fee percent, the request must be made on behalf of another account, using the `Stripe-Account` header or an OAuth key. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).</summary>
        [<Config.Form>]ApplicationFeePercent: decimal option
        ///<summary>A future timestamp to anchor the subscription's billing cycle for new subscriptions. You can't set this parameter if `ui_mode` is `custom`.</summary>
        [<Config.Form>]BillingCycleAnchor: DateTime option
        ///<summary>Controls how prorations and invoices for subscriptions are calculated and orchestrated.</summary>
        [<Config.Form>]BillingMode: Create'SubscriptionDataBillingMode option
        ///<summary>The tax rates that will apply to any subscription item that does not have
        ///`tax_rates` set. Invoices created will have their `default_tax_rates` populated
        ///from the subscription.</summary>
        [<Config.Form>]DefaultTaxRates: string list option
        ///<summary>The subscription's description, meant to be displayable to the customer.
        ///Use this field to optionally store an explanation of the subscription
        ///for rendering in the [customer portal](https://docs.stripe.com/customer-management).</summary>
        [<Config.Form>]Description: string option
        ///<summary>All invoices will be billed using the specified settings.</summary>
        [<Config.Form>]InvoiceSettings: Create'SubscriptionDataInvoiceSettings option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The account on behalf of which to charge, for each of the subscription's invoices.</summary>
        [<Config.Form>]OnBehalfOf: string option
        ///<summary>Specifies an interval for how often to bill for any pending invoice items. It is analogous to calling [Create an invoice](https://docs.stripe.com/api#create_invoice) for the given subscription at the specified interval.</summary>
        [<Config.Form>]PendingInvoiceItemInterval: Create'SubscriptionDataPendingInvoiceItemInterval option
        ///<summary>Determines how to handle prorations resulting from the `billing_cycle_anchor`. If no value is passed, the default is `create_prorations`.</summary>
        [<Config.Form>]ProrationBehavior: Create'SubscriptionDataProrationBehavior option
        ///<summary>If specified, the funds from the subscription's invoices will be transferred to the destination and the ID of the resulting transfers will be found on the resulting charges.</summary>
        [<Config.Form>]TransferData: Create'SubscriptionDataTransferData option
        ///<summary>Unix timestamp representing the end of the trial period the customer will get before being charged for the first time. Has to be at least 48 hours in the future.</summary>
        [<Config.Form>]TrialEnd: DateTime option
        ///<summary>Integer representing the number of trial period days before the customer is charged for the first time. Has to be at least 1.</summary>
        [<Config.Form>]TrialPeriodDays: int option
        ///<summary>Settings related to subscription trials.</summary>
        [<Config.Form>]TrialSettings: Create'SubscriptionDataTrialSettings option
    }
    with
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

    type Create'WalletOptionsLinkDisplay =
    | Auto
    | Never

    type Create'WalletOptionsLink = {
        ///<summary>Specifies whether Checkout should display Link as a payment option. By default, Checkout will display all the supported wallets that the Checkout Session was created with. This is the `auto` behavior, and it is the default choice.</summary>
        [<Config.Form>]Display: Create'WalletOptionsLinkDisplay option
    }
    with
        static member New(?display: Create'WalletOptionsLinkDisplay) =
            {
                Display = display
            }

    type Create'WalletOptions = {
        ///<summary>contains details about the Link wallet options.</summary>
        [<Config.Form>]Link: Create'WalletOptionsLink option
    }
    with
        static member New(?link: Create'WalletOptionsLink) =
            {
                Link = link
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

    type Create'Mode =
    | Payment
    | Setup
    | Subscription

    type Create'OriginContext =
    | MobileApp
    | Web

    type Create'PaymentMethodCollection =
    | Always
    | IfRequired

    type Create'RedirectOnCompletion =
    | Always
    | IfRequired
    | Never

    type Create'SubmitType =
    | Auto
    | Book
    | Donate
    | Pay
    | Subscribe

    type Create'UiMode =
    | Elements
    | EmbeddedPage
    | Form
    | HostedPage

    type CreateOptions = {
        ///<summary>Settings for price localization with [Adaptive Pricing](https://docs.stripe.com/payments/checkout/adaptive-pricing).</summary>
        [<Config.Form>]AdaptivePricing: Create'AdaptivePricing option
        ///<summary>Configure actions after a Checkout Session has expired. You can't set this parameter if `ui_mode` is `custom`.</summary>
        [<Config.Form>]AfterExpiration: Create'AfterExpiration option
        ///<summary>Enables user redeemable promotion codes.</summary>
        [<Config.Form>]AllowPromotionCodes: bool option
        ///<summary>Settings for automatic tax lookup for this session and resulting payments, invoices, and subscriptions.</summary>
        [<Config.Form>]AutomaticTax: Create'AutomaticTax option
        ///<summary>Specify whether Checkout should collect the customer's billing address. Defaults to `auto`.</summary>
        [<Config.Form>]BillingAddressCollection: Create'BillingAddressCollection option
        ///<summary>The branding settings for the Checkout Session. This parameter is not allowed if ui_mode is `custom`.</summary>
        [<Config.Form>]BrandingSettings: Create'BrandingSettings option
        ///<summary>If set, Checkout displays a back button and customers will be directed to this URL if they decide to cancel payment and return to your website. This parameter is not allowed if ui_mode is `embedded` or `custom`.</summary>
        [<Config.Form>]CancelUrl: string option
        ///<summary>A unique string to reference the Checkout Session. This can be a
        ///customer ID, a cart ID, or similar, and can be used to reconcile the
        ///session with your internal systems.</summary>
        [<Config.Form>]ClientReferenceId: string option
        ///<summary>Configure fields for the Checkout Session to gather active consent from customers.</summary>
        [<Config.Form>]ConsentCollection: Create'ConsentCollection option
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies). Required in `setup` mode when `payment_method_types` is not set.</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>Collect additional information from your customer using custom fields. Up to 3 fields are supported. You can't set this parameter if `ui_mode` is `custom`.</summary>
        [<Config.Form>]CustomFields: Create'CustomFields list option
        ///<summary>Display additional text for your customers using custom text. You can't set this parameter if `ui_mode` is `custom`.</summary>
        [<Config.Form>]CustomText: Create'CustomText option
        ///<summary>ID of an existing Customer, if one exists. In `payment` mode, the customer’s most recently saved card
        ///payment method will be used to prefill the email, name, card details, and billing address
        ///on the Checkout page. In `subscription` mode, the customer’s [default payment method](https://docs.stripe.com/api/customers/update#update_customer-invoice_settings-default_payment_method)
        ///will be used if it’s a card, otherwise the most recently saved card will be used. A valid billing address, billing name and billing email are required on the payment method for Checkout to prefill the customer's card details.
        ///If the Customer already has a valid [email](https://docs.stripe.com/api/customers/object#customer_object-email) set, the email will be prefilled and not editable in Checkout.
        ///If the Customer does not have a valid `email`, Checkout will set the email entered during the session on the Customer.
        ///If blank for Checkout Sessions in `subscription` mode or with `customer_creation` set as `always` in `payment` mode, Checkout will create a new Customer object based on information provided during the payment flow.
        ///You can set [`payment_intent_data.setup_future_usage`](https://docs.stripe.com/api/checkout/sessions/create#create_checkout_session-payment_intent_data-setup_future_usage) to have Checkout automatically attach the payment method to the Customer you pass in for future reuse.</summary>
        [<Config.Form>]Customer: string option
        ///<summary>ID of an existing Account, if one exists. Has the same behavior as `customer`.</summary>
        [<Config.Form>]CustomerAccount: string option
        ///<summary>Configure whether a Checkout Session creates a [Customer](https://docs.stripe.com/api/customers) during Session confirmation.
        ///When a Customer is not created, you can still retrieve email, address, and other customer data entered in Checkout
        ///with [customer_details](https://docs.stripe.com/api/checkout/sessions/object#checkout_session_object-customer_details).
        ///Sessions that don't create Customers instead are grouped by [guest customers](https://docs.stripe.com/payments/checkout/guest-customers)
        ///in the Dashboard. Promotion codes limited to first time customers will return invalid for these Sessions.
        ///Can only be set in `payment` and `setup` mode.</summary>
        [<Config.Form>]CustomerCreation: Create'CustomerCreation option
        ///<summary>If provided, this value will be used when the Customer object is created.
        ///If not provided, customers will be asked to enter their email address.
        ///Use this parameter to prefill customer data if you already have an email
        ///on file. To access information about the customer once a session is
        ///complete, use the `customer` field.</summary>
        [<Config.Form>]CustomerEmail: string option
        ///<summary>Controls what fields on Customer can be updated by the Checkout Session. Can only be provided when `customer` is provided.</summary>
        [<Config.Form>]CustomerUpdate: Create'CustomerUpdate option
        ///<summary>The coupon or promotion code to apply to this Session. Currently, only up to one may be specified.</summary>
        [<Config.Form>]Discounts: Create'Discounts list option
        ///<summary>A list of the types of payment methods (e.g., `card`) that should be excluded from this Checkout Session. This should only be used when payment methods for this Checkout Session are managed through the [Stripe Dashboard](https://dashboard.stripe.com/settings/payment_methods).</summary>
        [<Config.Form>]ExcludedPaymentMethodTypes: Create'ExcludedPaymentMethodTypes list option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The Epoch time in seconds at which the Checkout Session will expire. It can be anywhere from 30 minutes to 24 hours after Checkout Session creation. By default, this value is 24 hours from creation.</summary>
        [<Config.Form>]ExpiresAt: DateTime option
        ///<summary>The integration identifier for this Checkout Session. Multiple Checkout Sessions can have the same integration identifier.</summary>
        [<Config.Form>]IntegrationIdentifier: string option
        ///<summary>Generate a post-purchase Invoice for one-time payments.</summary>
        [<Config.Form>]InvoiceCreation: Create'InvoiceCreation option
        ///<summary>A list of items the customer is purchasing. Use this parameter to pass one-time or recurring [Prices](https://docs.stripe.com/api/prices). The parameter is required for `payment` and `subscription` mode.
        ///For `payment` mode, there is a maximum of 100 line items, however it is recommended to consolidate line items if there are more than a few dozen.
        ///For `subscription` mode, there is a maximum of 20 line items with recurring Prices and 20 line items with one-time Prices. Line items with one-time Prices will be on the initial invoice only.</summary>
        [<Config.Form>]LineItems: Create'LineItems list option
        ///<summary>The IETF language tag of the locale Checkout is displayed in. If blank or `auto`, the browser's locale is used.</summary>
        [<Config.Form>]Locale: Create'Locale option
        ///<summary>Settings for Managed Payments for this Checkout Session and resulting [PaymentIntents](/api/payment_intents/object), [Invoices](/api/invoices/object), and [Subscriptions](/api/subscriptions/object).</summary>
        [<Config.Form>]ManagedPayments: Create'ManagedPayments option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The mode of the Checkout Session. Pass `subscription` if the Checkout Session includes at least one recurring item.</summary>
        [<Config.Form>]Mode: Create'Mode option
        ///<summary>Controls name collection settings for the session.
        ///You can configure Checkout to collect your customers' business names, individual names, or both. Each name field can be either required or optional.
        ///If a [Customer](https://docs.stripe.com/api/customers) is created or provided, the names can be saved to the Customer object as well.
        ///You can't set this parameter if `ui_mode` is `custom`.</summary>
        [<Config.Form>]NameCollection: Create'NameCollection option
        ///<summary>A list of optional items the customer can add to their order at checkout. Use this parameter to pass one-time or recurring [Prices](https://docs.stripe.com/api/prices).
        ///There is a maximum of 10 optional items allowed on a Checkout Session, and the existing limits on the number of line items allowed on a Checkout Session apply to the combined number of line items and optional items.
        ///For `payment` mode, there is a maximum of 100 combined line items and optional items, however it is recommended to consolidate items if there are more than a few dozen.
        ///For `subscription` mode, there is a maximum of 20 line items and optional items with recurring Prices and 20 line items and optional items with one-time Prices.
        ///You can't set this parameter if `ui_mode` is `custom`.</summary>
        [<Config.Form>]OptionalItems: Create'OptionalItems list option
        ///<summary>Where the user is coming from. This informs the optimizations that are applied to the session. You can't set this parameter if `ui_mode` is `custom`.</summary>
        [<Config.Form>]OriginContext: Create'OriginContext option
        ///<summary>A subset of parameters to be passed to PaymentIntent creation for Checkout Sessions in `payment` mode.</summary>
        [<Config.Form>]PaymentIntentData: Create'PaymentIntentData option
        ///<summary>Specify whether Checkout should collect a payment method. When set to `if_required`, Checkout will not collect a payment method when the total due for the session is 0.
        ///This may occur if the Checkout Session includes a free trial or a discount.
        ///Can only be set in `subscription` mode. Defaults to `always`.
        ///If you'd like information on how to collect a payment method outside of Checkout, read the guide on configuring [subscriptions with a free trial](https://docs.stripe.com/payments/checkout/free-trials).</summary>
        [<Config.Form>]PaymentMethodCollection: Create'PaymentMethodCollection option
        ///<summary>The ID of the payment method configuration to use with this Checkout session.</summary>
        [<Config.Form>]PaymentMethodConfiguration: string option
        ///<summary>This parameter allows you to set some attributes on the payment method created during a Checkout session.</summary>
        [<Config.Form>]PaymentMethodData: Create'PaymentMethodData option
        ///<summary>Payment-method-specific configuration.</summary>
        [<Config.Form>]PaymentMethodOptions: Create'PaymentMethodOptions option
        ///<summary>A list of the types of payment methods (e.g., `card`) this Checkout Session can accept.
        ///You can omit this attribute to manage your payment methods from the [Stripe Dashboard](https://dashboard.stripe.com/settings/payment_methods).
        ///See [Dynamic Payment Methods](https://docs.stripe.com/payments/payment-methods/integration-options#using-dynamic-payment-methods) for more details.
        ///Read more about the supported payment methods and their requirements in our [payment
        ///method details guide](/docs/payments/checkout/payment-methods).
        ///If multiple payment methods are passed, Checkout will dynamically reorder them to
        ///prioritize the most relevant payment methods based on the customer's location and
        ///other characteristics.</summary>
        [<Config.Form>]PaymentMethodTypes: Create'PaymentMethodTypes list option
        ///<summary>This property is used to set up permissions for various actions (e.g., update) on the CheckoutSession object. Can only be set when creating `embedded` or `custom` sessions.
        ///For specific permissions, please refer to their dedicated subsections, such as `permissions.update_shipping_details`.</summary>
        [<Config.Form>]Permissions: Create'Permissions option
        ///<summary>Controls phone number collection settings for the session.
        ///We recommend that you review your privacy policy and check with your legal contacts
        ///before using this feature. Learn more about [collecting phone numbers with Checkout](https://docs.stripe.com/payments/checkout/phone-numbers).</summary>
        [<Config.Form>]PhoneNumberCollection: Create'PhoneNumberCollection option
        ///<summary>This parameter applies to `ui_mode: embedded`. Learn more about the [redirect behavior](https://docs.stripe.com/payments/checkout/custom-success-page?payment-ui=embedded-form) of embedded sessions. Defaults to `always`.</summary>
        [<Config.Form>]RedirectOnCompletion: Create'RedirectOnCompletion option
        ///<summary>The URL to redirect your customer back to after they authenticate or cancel their payment on the
        ///payment method's app or site. This parameter is required if `ui_mode` is `embedded` or `custom`
        ///and redirect-based payment methods are enabled on the session.</summary>
        [<Config.Form>]ReturnUrl: string option
        ///<summary>Controls saved payment method settings for the session. Only available in `payment` and `subscription` mode.</summary>
        [<Config.Form>]SavedPaymentMethodOptions: Create'SavedPaymentMethodOptions option
        ///<summary>A subset of parameters to be passed to SetupIntent creation for Checkout Sessions in `setup` mode.</summary>
        [<Config.Form>]SetupIntentData: Create'SetupIntentData option
        ///<summary>When set, provides configuration for Checkout to collect a shipping address from a customer.</summary>
        [<Config.Form>]ShippingAddressCollection: Create'ShippingAddressCollection option
        ///<summary>The shipping rate options to apply to this Session. Up to a maximum of 5.</summary>
        [<Config.Form>]ShippingOptions: Create'ShippingOptions list option
        ///<summary>Describes the type of transaction being performed by Checkout in order
        ///to customize relevant text on the page, such as the submit button.
        /// `submit_type` can only be specified on Checkout Sessions in
        ///`payment` or `subscription` mode. If blank or `auto`, `pay` is used.
        ///You can't set this parameter if `ui_mode` is `custom`.</summary>
        [<Config.Form>]SubmitType: Create'SubmitType option
        ///<summary>A subset of parameters to be passed to subscription creation for Checkout Sessions in `subscription` mode.</summary>
        [<Config.Form>]SubscriptionData: Create'SubscriptionData option
        ///<summary>The URL to which Stripe should send customers when payment or setup
        ///is complete.
        ///This parameter is not allowed if ui_mode is `embedded` or `custom`. If you'd like to use
        ///information from the successful Checkout Session on your page, read the
        ///guide on [customizing your success page](https://docs.stripe.com/payments/checkout/custom-success-page).</summary>
        [<Config.Form>]SuccessUrl: string option
        ///<summary>Controls tax ID collection during checkout.</summary>
        [<Config.Form>]TaxIdCollection: Create'TaxIdCollection option
        ///<summary>The UI mode of the Session. Defaults to `hosted`.</summary>
        [<Config.Form>]UiMode: Create'UiMode option
        ///<summary>Wallet-specific configuration.</summary>
        [<Config.Form>]WalletOptions: Create'WalletOptions option
    }
    with
        static member New(?adaptivePricing: Create'AdaptivePricing, ?mode: Create'Mode, ?nameCollection: Create'NameCollection, ?optionalItems: Create'OptionalItems list, ?originContext: Create'OriginContext, ?paymentIntentData: Create'PaymentIntentData, ?paymentMethodCollection: Create'PaymentMethodCollection, ?paymentMethodConfiguration: string, ?paymentMethodData: Create'PaymentMethodData, ?paymentMethodOptions: Create'PaymentMethodOptions, ?paymentMethodTypes: Create'PaymentMethodTypes list, ?metadata: Map<string, string>, ?permissions: Create'Permissions, ?redirectOnCompletion: Create'RedirectOnCompletion, ?returnUrl: string, ?savedPaymentMethodOptions: Create'SavedPaymentMethodOptions, ?setupIntentData: Create'SetupIntentData, ?shippingAddressCollection: Create'ShippingAddressCollection, ?shippingOptions: Create'ShippingOptions list, ?submitType: Create'SubmitType, ?subscriptionData: Create'SubscriptionData, ?successUrl: string, ?taxIdCollection: Create'TaxIdCollection, ?phoneNumberCollection: Create'PhoneNumberCollection, ?uiMode: Create'UiMode, ?managedPayments: Create'ManagedPayments, ?lineItems: Create'LineItems list, ?afterExpiration: Create'AfterExpiration, ?allowPromotionCodes: bool, ?automaticTax: Create'AutomaticTax, ?billingAddressCollection: Create'BillingAddressCollection, ?brandingSettings: Create'BrandingSettings, ?cancelUrl: string, ?clientReferenceId: string, ?consentCollection: Create'ConsentCollection, ?currency: IsoTypes.IsoCurrencyCode, ?customFields: Create'CustomFields list, ?locale: Create'Locale, ?customText: Create'CustomText, ?customerAccount: string, ?customerCreation: Create'CustomerCreation, ?customerEmail: string, ?customerUpdate: Create'CustomerUpdate, ?discounts: Create'Discounts list, ?excludedPaymentMethodTypes: Create'ExcludedPaymentMethodTypes list, ?expand: string list, ?expiresAt: DateTime, ?integrationIdentifier: string, ?invoiceCreation: Create'InvoiceCreation, ?customer: string, ?walletOptions: Create'WalletOptions) =
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

    ///<summary><p>Creates a Checkout Session object.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/checkout/sessions"
        |> RestApi.postAsync<_, CheckoutSession> settings (Map.empty) options

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Session: string
    }
    with
        static member New(session: string, ?expand: string list) =
            {
                Expand = expand
                Session = session
            }

    ///<summary><p>Retrieves a Checkout Session object.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/checkout/sessions/{options.Session}"
        |> RestApi.getAsync<CheckoutSession> settings qs

    type Update'CollectedInformationShippingDetailsAddress = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'CollectedInformationShippingDetails = {
        ///<summary>The address of the customer</summary>
        [<Config.Form>]Address: Update'CollectedInformationShippingDetailsAddress option
        ///<summary>The name of customer</summary>
        [<Config.Form>]Name: string option
    }
    with
        static member New(?address: Update'CollectedInformationShippingDetailsAddress, ?name: string) =
            {
                Address = address
                Name = name
            }

    type Update'CollectedInformation = {
        ///<summary>The shipping details to apply to this Session.</summary>
        [<Config.Form>]ShippingDetails: Update'CollectedInformationShippingDetails option
    }
    with
        static member New(?shippingDetails: Update'CollectedInformationShippingDetails) =
            {
                ShippingDetails = shippingDetails
            }

    type Update'LineItemsAdjustableQuantity = {
        ///<summary>Set to true if the quantity can be adjusted to any positive integer. Setting to false will remove any previously specified constraints on quantity.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The maximum quantity the customer can purchase for the Checkout Session. By default this value is 99. You can specify a value up to 999999.</summary>
        [<Config.Form>]Maximum: int option
        ///<summary>The minimum quantity the customer must purchase for the Checkout Session. By default this value is 0.</summary>
        [<Config.Form>]Minimum: int option
    }
    with
        static member New(?enabled: bool, ?maximum: int, ?minimum: int) =
            {
                Enabled = enabled
                Maximum = maximum
                Minimum = minimum
            }

    type Update'LineItemsPriceDataProductData = {
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

    type Update'LineItemsPriceDataRecurringInterval =
    | Day
    | Month
    | Week
    | Year

    type Update'LineItemsPriceDataRecurring = {
        ///<summary>Specifies billing frequency. Either `day`, `week`, `month` or `year`.</summary>
        [<Config.Form>]Interval: Update'LineItemsPriceDataRecurringInterval option
        ///<summary>The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).</summary>
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Update'LineItemsPriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Update'LineItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Update'LineItemsPriceData = {
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to. One of `product` or `product_data` is required.</summary>
        [<Config.Form>]Product: string option
        ///<summary>Data used to generate a new [Product](https://docs.stripe.com/api/products) object inline. One of `product` or `product_data` is required.</summary>
        [<Config.Form>]ProductData: Update'LineItemsPriceDataProductData option
        ///<summary>The recurring components of a price such as `interval` and `interval_count`.</summary>
        [<Config.Form>]Recurring: Update'LineItemsPriceDataRecurring option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: Update'LineItemsPriceDataTaxBehavior option
        ///<summary>A non-negative integer in cents (or local equivalent) representing how much to charge. One of `unit_amount` or `unit_amount_decimal` is required.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
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

    type Update'LineItems = {
        ///<summary>When set, provides configuration for this item’s quantity to be adjusted by the customer during Checkout.</summary>
        [<Config.Form>]AdjustableQuantity: Update'LineItemsAdjustableQuantity option
        ///<summary>ID of an existing line item.</summary>
        [<Config.Form>]Id: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The ID of the [Price](https://docs.stripe.com/api/prices). One of `price` or `price_data` is required when creating a new line item.</summary>
        [<Config.Form>]Price: string option
        ///<summary>Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required when creating a new line item.</summary>
        [<Config.Form>]PriceData: Update'LineItemsPriceData option
        ///<summary>The quantity of the line item being purchased. Quantity should not be defined when `recurring.usage_type=metered`.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>The [tax rates](https://docs.stripe.com/api/tax_rates) which apply to this line item.</summary>
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
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

    type Update'ShippingOptionsShippingRateDataDeliveryEstimateMaximum = {
        ///<summary>A unit of time.</summary>
        [<Config.Form>]Unit: Update'ShippingOptionsShippingRateDataDeliveryEstimateMaximumUnit option
        ///<summary>Must be greater than 0.</summary>
        [<Config.Form>]Value: int option
    }
    with
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

    type Update'ShippingOptionsShippingRateDataDeliveryEstimateMinimum = {
        ///<summary>A unit of time.</summary>
        [<Config.Form>]Unit: Update'ShippingOptionsShippingRateDataDeliveryEstimateMinimumUnit option
        ///<summary>Must be greater than 0.</summary>
        [<Config.Form>]Value: int option
    }
    with
        static member New(?unit: Update'ShippingOptionsShippingRateDataDeliveryEstimateMinimumUnit, ?value: int) =
            {
                Unit = unit
                Value = value
            }

    type Update'ShippingOptionsShippingRateDataDeliveryEstimate = {
        ///<summary>The upper bound of the estimated range. If empty, represents no upper bound i.e., infinite.</summary>
        [<Config.Form>]Maximum: Update'ShippingOptionsShippingRateDataDeliveryEstimateMaximum option
        ///<summary>The lower bound of the estimated range. If empty, represents no lower bound.</summary>
        [<Config.Form>]Minimum: Update'ShippingOptionsShippingRateDataDeliveryEstimateMinimum option
    }
    with
        static member New(?maximum: Update'ShippingOptionsShippingRateDataDeliveryEstimateMaximum, ?minimum: Update'ShippingOptionsShippingRateDataDeliveryEstimateMinimum) =
            {
                Maximum = maximum
                Minimum = minimum
            }

    type Update'ShippingOptionsShippingRateDataFixedAmount = {
        ///<summary>A non-negative integer in cents representing how much to charge.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>Shipping rates defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]CurrencyOptions: Map<string, string> option
    }
    with
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

    type Update'ShippingOptionsShippingRateDataType =
    | FixedAmount

    type Update'ShippingOptionsShippingRateData = {
        ///<summary>The estimated range for how long shipping will take, meant to be displayable to the customer. This will appear on CheckoutSessions.</summary>
        [<Config.Form>]DeliveryEstimate: Update'ShippingOptionsShippingRateDataDeliveryEstimate option
        ///<summary>The name of the shipping rate, meant to be displayable to the customer. This will appear on CheckoutSessions.</summary>
        [<Config.Form>]DisplayName: string option
        ///<summary>Describes a fixed amount to charge for shipping. Must be present if type is `fixed_amount`.</summary>
        [<Config.Form>]FixedAmount: Update'ShippingOptionsShippingRateDataFixedAmount option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Specifies whether the rate is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`.</summary>
        [<Config.Form>]TaxBehavior: Update'ShippingOptionsShippingRateDataTaxBehavior option
        ///<summary>A [tax code](https://docs.stripe.com/tax/tax-categories) ID. The Shipping tax code is `txcd_92010001`.</summary>
        [<Config.Form>]TaxCode: string option
        ///<summary>The type of calculation to use on the shipping rate.</summary>
        [<Config.Form>]Type: Update'ShippingOptionsShippingRateDataType option
    }
    with
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

    type Update'ShippingOptions = {
        ///<summary>The ID of the Shipping Rate to use for this shipping option.</summary>
        [<Config.Form>]ShippingRate: string option
        ///<summary>Parameters to be passed to Shipping Rate creation for this shipping option.</summary>
        [<Config.Form>]ShippingRateData: Update'ShippingOptionsShippingRateData option
    }
    with
        static member New(?shippingRate: string, ?shippingRateData: Update'ShippingOptionsShippingRateData) =
            {
                ShippingRate = shippingRate
                ShippingRateData = shippingRateData
            }

    type UpdateOptions = {
        [<Config.Path>]Session: string
        ///<summary>Information about the customer collected within the Checkout Session. Can only be set when updating `embedded` or `custom` sessions.</summary>
        [<Config.Form>]CollectedInformation: Update'CollectedInformation option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>A list of items the customer is purchasing.
        ///When updating line items, you must retransmit the entire array of line items.
        ///To retain an existing line item, specify its `id`.
        ///To update an existing line item, specify its `id` along with the new values of the fields to update.
        ///To add a new line item, specify one of `price` or `price_data` and `quantity`.
        ///To remove an existing line item, omit the line item's ID from the retransmitted array.
        ///To reorder a line item, specify it at the desired position in the retransmitted array.</summary>
        [<Config.Form>]LineItems: Update'LineItems list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The shipping rate options to apply to this Session. Up to a maximum of 5.</summary>
        [<Config.Form>]ShippingOptions: Choice<Update'ShippingOptions list,string> option
    }
    with
        static member New(session: string, ?collectedInformation: Update'CollectedInformation, ?expand: string list, ?lineItems: Update'LineItems list, ?metadata: Map<string, string>, ?shippingOptions: Choice<Update'ShippingOptions list,string>) =
            {
                Session = session
                CollectedInformation = collectedInformation
                Expand = expand
                LineItems = lineItems
                Metadata = metadata
                ShippingOptions = shippingOptions
            }

    ///<summary><p>Updates a Checkout Session object.</p>
    ///<p>Related guide: <a href="/payments/advanced/dynamic-updates">Dynamically update a Checkout Session</a></p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/checkout/sessions/{options.Session}"
        |> RestApi.postAsync<_, CheckoutSession> settings (Map.empty) options

module CheckoutSessionsExpire =

    type ExpireOptions = {
        [<Config.Path>]Session: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(session: string, ?expand: string list) =
            {
                Session = session
                Expand = expand
            }

    ///<summary><p>A Checkout Session can be expired when it is in one of these statuses: <code>open</code> </p>
    ///<p>After it expires, a customer can’t complete a Checkout Session and customers loading the Checkout Session see a message saying the Checkout Session is expired.</p></summary>
    let Expire settings (options: ExpireOptions) =
        $"/v1/checkout/sessions/{options.Session}/expire"
        |> RestApi.postAsync<_, CheckoutSession> settings (Map.empty) options

module CheckoutSessionsLineItems =

    type ListLineItemsOptions = {
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        [<Config.Path>]Session: string
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
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

    ///<summary><p>When retrieving a Checkout Session, there is an includable <strong>line_items</strong> property containing the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p></summary>
    let ListLineItems settings (options: ListLineItemsOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/checkout/sessions/{options.Session}/line_items"
        |> RestApi.getAsync<StripeList<Item>> settings qs
