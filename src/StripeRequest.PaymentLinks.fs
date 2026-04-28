namespace FunStripe.StripeRequest

open FunStripe
open FunStripe.Json
open FunStripe.StripeModel
open System

module PaymentLinks =

    type ListOptions = {
        ///Only return payment links that are active or inactive (e.g., pass `false` to list all inactive payment links).
        [<Config.Query>]Active: bool option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
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

    ///<p>Returns a list of your payment links.</p>
    let List settings (options: ListOptions) =
        let qs = [("active", options.Active |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/payment_links"
        |> RestApi.getAsync<PaymentLink list> settings qs

    type Create'AfterCompletionHostedConfirmation = {
        ///A custom message to display to the customer after the purchase is complete.
        [<Config.Form>]CustomMessage: string option
    }
    with
        static member New(?customMessage: string) =
            {
                CustomMessage = customMessage
            }

    type Create'AfterCompletionRedirect = {
        ///The URL the customer will be redirected to after the purchase is complete. You can embed `{CHECKOUT_SESSION_ID}` into the URL to have the `id` of the completed [checkout session](https://stripe.com/docs/api/checkout/sessions/object#checkout_session_object-id) included.
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
        ///Configuration when `type=hosted_confirmation`.
        [<Config.Form>]HostedConfirmation: Create'AfterCompletionHostedConfirmation option
        ///Configuration when `type=redirect`.
        [<Config.Form>]Redirect: Create'AfterCompletionRedirect option
        ///The specified behavior after the purchase is complete. Either `redirect` or `hosted_confirmation`.
        [<Config.Form>]Type: Create'AfterCompletionType option
    }
    with
        static member New(?hostedConfirmation: Create'AfterCompletionHostedConfirmation, ?redirect: Create'AfterCompletionRedirect, ?type': Create'AfterCompletionType) =
            {
                HostedConfirmation = hostedConfirmation
                Redirect = redirect
                Type = type'
            }

    type Create'AutomaticTax = {
        ///If `true`, tax will be calculated automatically using the customer's location.
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
        ///Whether the feature is enabled
        [<Config.Form>]Enabled: bool option
        ///Invoice PDF configuration.
        [<Config.Form>]InvoiceData: Create'InvoiceCreationInvoiceData option
    }
    with
        static member New(?enabled: bool, ?invoiceData: Create'InvoiceCreationInvoiceData) =
            {
                Enabled = enabled
                InvoiceData = invoiceData
            }

    type Create'LineItemsAdjustableQuantity = {
        ///Set to true if the quantity can be adjusted to any non-negative Integer.
        [<Config.Form>]Enabled: bool option
        ///The maximum quantity the customer can purchase. By default this value is 99. You can specify a value up to 999.
        [<Config.Form>]Maximum: int option
        ///The minimum quantity the customer can purchase. By default this value is 0. If there is only one item in the cart then that item's quantity cannot go down to 0.
        [<Config.Form>]Minimum: int option
    }
    with
        static member New(?enabled: bool, ?maximum: int, ?minimum: int) =
            {
                Enabled = enabled
                Maximum = maximum
                Minimum = minimum
            }

    type Create'LineItems = {
        ///When set, provides configuration for this item’s quantity to be adjusted by the customer during checkout.
        [<Config.Form>]AdjustableQuantity: Create'LineItemsAdjustableQuantity option
        ///The ID of the [Price](https://stripe.com/docs/api/prices) or [Plan](https://stripe.com/docs/api/plans) object.
        [<Config.Form>]Price: string option
        ///The quantity of the line item being purchased.
        [<Config.Form>]Quantity: int option
    }
    with
        static member New(?adjustableQuantity: Create'LineItemsAdjustableQuantity, ?price: string, ?quantity: int) =
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
        ///Controls when the funds will be captured from the customer's account.
        [<Config.Form>]CaptureMethod: Create'PaymentIntentDataCaptureMethod option
        ///Indicates that you intend to [make future payments](https://stripe.com/docs/payments/payment-intents#future-usage) with the payment method collected by this Checkout Session.
        ///When setting this to `on_session`, Checkout will show a notice to the customer that their payment details will be saved.
        ///When setting this to `off_session`, Checkout will show a notice to the customer that their payment details will be saved and used for future payments.
        ///If a Customer has been provided or Checkout creates a new Customer,Checkout will attach the payment method to the Customer.
        ///If Checkout does not create a Customer, the payment method is not attached to a Customer. To reuse the payment method, you can retrieve it from the Checkout Session's PaymentIntent.
        ///When processing card payments, Checkout also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as SCA.
        [<Config.Form>]SetupFutureUsage: Create'PaymentIntentDataSetupFutureUsage option
    }
    with
        static member New(?captureMethod: Create'PaymentIntentDataCaptureMethod, ?setupFutureUsage: Create'PaymentIntentDataSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodTypes =
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

    type Create'PhoneNumberCollection = {
        ///Set to `true` to enable phone number collection.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
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

    type Create'ShippingOptions = {
        ///The ID of the Shipping Rate to use for this shipping option.
        [<Config.Form>]ShippingRate: string option
    }
    with
        static member New(?shippingRate: string) =
            {
                ShippingRate = shippingRate
            }

    type Create'SubscriptionData = {
        ///The subscription's description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription.
        [<Config.Form>]Description: string option
        ///Integer representing the number of trial period days before the customer is charged for the first time. Has to be at least 1.
        [<Config.Form>]TrialPeriodDays: int option
    }
    with
        static member New(?description: string, ?trialPeriodDays: int) =
            {
                Description = description
                TrialPeriodDays = trialPeriodDays
            }

    type Create'TaxIdCollection = {
        ///Set to `true` to enable tax ID collection.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Create'TransferData = {
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

    type CreateOptions = {
        ///Behavior after the purchase is complete.
        [<Config.Form>]AfterCompletion: Create'AfterCompletion option
        ///Enables user redeemable promotion codes.
        [<Config.Form>]AllowPromotionCodes: bool option
        ///The amount of the application fee (if any) that will be requested to be applied to the payment and transferred to the application owner's Stripe account. Can only be applied when there are no line items with recurring prices.
        [<Config.Form>]ApplicationFeeAmount: int option
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. There must be at least 1 line item with a recurring price to use this field.
        [<Config.Form>]ApplicationFeePercent: decimal option
        ///Configuration for automatic tax collection.
        [<Config.Form>]AutomaticTax: Create'AutomaticTax option
        ///Configuration for collecting the customer's billing address.
        [<Config.Form>]BillingAddressCollection: Create'BillingAddressCollection option
        ///Configure fields to gather active consent from customers.
        [<Config.Form>]ConsentCollection: Create'ConsentCollection option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies) and supported by each line item's price.
        [<Config.Form>]Currency: string option
        ///Collect additional information from your customer using custom fields. Up to 2 fields are supported.
        [<Config.Form>]CustomFields: Create'CustomFields list option
        ///Display additional text for your customers using custom text.
        [<Config.Form>]CustomText: Create'CustomText option
        ///Configures whether [checkout sessions](https://stripe.com/docs/api/checkout/sessions) created by this payment link create a [Customer](https://stripe.com/docs/api/customers).
        [<Config.Form>]CustomerCreation: Create'CustomerCreation option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Generate a post-purchase Invoice for one-time payments.
        [<Config.Form>]InvoiceCreation: Create'InvoiceCreation option
        ///The line items representing what is being sold. Each line item represents an item being sold. Up to 20 line items are supported.
        [<Config.Form>]LineItems: Create'LineItems list
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`. Metadata associated with this Payment Link will automatically be copied to [checkout sessions](https://stripe.com/docs/api/checkout/sessions) created by this payment link.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The account on behalf of which to charge.
        [<Config.Form>]OnBehalfOf: string option
        ///A subset of parameters to be passed to PaymentIntent creation for Checkout Sessions in `payment` mode.
        [<Config.Form>]PaymentIntentData: Create'PaymentIntentData option
        ///Specify whether Checkout should collect a payment method. When set to `if_required`, Checkout will not collect a payment method when the total due for the session is 0.This may occur if the Checkout Session includes a free trial or a discount.
        ///Can only be set in `subscription` mode.
        ///If you'd like information on how to collect a payment method outside of Checkout, read the guide on [configuring subscriptions with a free trial](https://stripe.com/docs/payments/checkout/free-trials).
        [<Config.Form>]PaymentMethodCollection: Create'PaymentMethodCollection option
        ///The list of payment method types that customers can use. If no value is passed, Stripe will dynamically show relevant payment methods from your [payment method settings](https://dashboard.stripe.com/settings/payment_methods) (20+ payment methods [supported](https://stripe.com/docs/payments/payment-methods/integration-options#payment-method-product-support)).
        [<Config.Form>]PaymentMethodTypes: Create'PaymentMethodTypes list option
        ///Controls phone number collection settings during checkout.
        ///We recommend that you review your privacy policy and check with your legal contacts.
        [<Config.Form>]PhoneNumberCollection: Create'PhoneNumberCollection option
        ///Configuration for collecting the customer's shipping address.
        [<Config.Form>]ShippingAddressCollection: Create'ShippingAddressCollection option
        ///The shipping rate options to apply to [checkout sessions](https://stripe.com/docs/api/checkout/sessions) created by this payment link.
        [<Config.Form>]ShippingOptions: Create'ShippingOptions list option
        ///Describes the type of transaction being performed in order to customize relevant text on the page, such as the submit button. Changing this value will also affect the hostname in the [url](https://stripe.com/docs/api/payment_links/payment_links/object#url) property (example: `donate.stripe.com`).
        [<Config.Form>]SubmitType: Create'SubmitType option
        ///When creating a subscription, the specified configuration data will be used. There must be at least one line item with a recurring price to use `subscription_data`.
        [<Config.Form>]SubscriptionData: Create'SubscriptionData option
        ///Controls tax ID collection during checkout.
        [<Config.Form>]TaxIdCollection: Create'TaxIdCollection option
        ///The account (if any) the payments will be attributed to for tax reporting, and where funds from each payment will be transferred to.
        [<Config.Form>]TransferData: Create'TransferData option
    }
    with
        static member New(lineItems: Create'LineItems list, ?afterCompletion: Create'AfterCompletion, ?subscriptionData: Create'SubscriptionData, ?submitType: Create'SubmitType, ?shippingOptions: Create'ShippingOptions list, ?shippingAddressCollection: Create'ShippingAddressCollection, ?phoneNumberCollection: Create'PhoneNumberCollection, ?paymentMethodTypes: Create'PaymentMethodTypes list, ?paymentMethodCollection: Create'PaymentMethodCollection, ?paymentIntentData: Create'PaymentIntentData, ?onBehalfOf: string, ?metadata: Map<string, string>, ?invoiceCreation: Create'InvoiceCreation, ?expand: string list, ?customerCreation: Create'CustomerCreation, ?customText: Create'CustomText, ?customFields: Create'CustomFields list, ?currency: string, ?consentCollection: Create'ConsentCollection, ?billingAddressCollection: Create'BillingAddressCollection, ?automaticTax: Create'AutomaticTax, ?applicationFeePercent: decimal, ?applicationFeeAmount: int, ?allowPromotionCodes: bool, ?taxIdCollection: Create'TaxIdCollection, ?transferData: Create'TransferData) =
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
                InvoiceCreation = invoiceCreation
                LineItems = lineItems
                Metadata = metadata
                OnBehalfOf = onBehalfOf
                PaymentIntentData = paymentIntentData
                PaymentMethodCollection = paymentMethodCollection
                PaymentMethodTypes = paymentMethodTypes
                PhoneNumberCollection = phoneNumberCollection
                ShippingAddressCollection = shippingAddressCollection
                ShippingOptions = shippingOptions
                SubmitType = submitType
                SubscriptionData = subscriptionData
                TaxIdCollection = taxIdCollection
                TransferData = transferData
            }

    ///<p>Creates a payment link.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/payment_links"
        |> RestApi.postAsync<_, PaymentLink> settings (Map.empty) options

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]PaymentLink: string
    }
    with
        static member New(paymentLink: string, ?expand: string list) =
            {
                Expand = expand
                PaymentLink = paymentLink
            }

    ///<p>Retrieve a payment link.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/payment_links/{options.PaymentLink}"
        |> RestApi.getAsync<PaymentLink> settings qs

    type Update'AfterCompletionHostedConfirmation = {
        ///A custom message to display to the customer after the purchase is complete.
        [<Config.Form>]CustomMessage: string option
    }
    with
        static member New(?customMessage: string) =
            {
                CustomMessage = customMessage
            }

    type Update'AfterCompletionRedirect = {
        ///The URL the customer will be redirected to after the purchase is complete. You can embed `{CHECKOUT_SESSION_ID}` into the URL to have the `id` of the completed [checkout session](https://stripe.com/docs/api/checkout/sessions/object#checkout_session_object-id) included.
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
        ///Configuration when `type=hosted_confirmation`.
        [<Config.Form>]HostedConfirmation: Update'AfterCompletionHostedConfirmation option
        ///Configuration when `type=redirect`.
        [<Config.Form>]Redirect: Update'AfterCompletionRedirect option
        ///The specified behavior after the purchase is complete. Either `redirect` or `hosted_confirmation`.
        [<Config.Form>]Type: Update'AfterCompletionType option
    }
    with
        static member New(?hostedConfirmation: Update'AfterCompletionHostedConfirmation, ?redirect: Update'AfterCompletionRedirect, ?type': Update'AfterCompletionType) =
            {
                HostedConfirmation = hostedConfirmation
                Redirect = redirect
                Type = type'
            }

    type Update'AutomaticTax = {
        ///If `true`, tax will be calculated automatically using the customer's location.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Update'CustomFieldsDropdownOptions = {
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

    type Update'CustomFieldsDropdown = {
        ///The options available for the customer to select. Up to 200 options allowed.
        [<Config.Form>]Options: Update'CustomFieldsDropdownOptions list option
    }
    with
        static member New(?options: Update'CustomFieldsDropdownOptions list) =
            {
                Options = options
            }

    type Update'CustomFieldsLabelType =
    | Custom

    type Update'CustomFieldsLabel = {
        ///Custom text for the label, displayed to the customer. Up to 50 characters.
        [<Config.Form>]Custom: string option
        ///The type of the label.
        [<Config.Form>]Type: Update'CustomFieldsLabelType option
    }
    with
        static member New(?custom: string, ?type': Update'CustomFieldsLabelType) =
            {
                Custom = custom
                Type = type'
            }

    type Update'CustomFieldsNumeric = {
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

    type Update'CustomFieldsText = {
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

    type Update'CustomFieldsType =
    | Dropdown
    | Numeric
    | Text

    type Update'CustomFields = {
        ///Configuration for `type=dropdown` fields.
        [<Config.Form>]Dropdown: Update'CustomFieldsDropdown option
        ///String of your choice that your integration can use to reconcile this field. Must be unique to this field, alphanumeric, and up to 200 characters.
        [<Config.Form>]Key: string option
        ///The label for the field, displayed to the customer.
        [<Config.Form>]Label: Update'CustomFieldsLabel option
        ///Configuration for `type=numeric` fields.
        [<Config.Form>]Numeric: Update'CustomFieldsNumeric option
        ///Whether the customer is required to complete the field before completing the Checkout Session. Defaults to `false`.
        [<Config.Form>]Optional: bool option
        ///Configuration for `type=text` fields.
        [<Config.Form>]Text: Update'CustomFieldsText option
        ///The type of the field.
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

    type Update'CustomTextShippingAddressCustomTextPosition = {
        ///Text may be up to 1000 characters in length.
        [<Config.Form>]Message: string option
    }
    with
        static member New(?message: string) =
            {
                Message = message
            }

    type Update'CustomTextSubmitCustomTextPosition = {
        ///Text may be up to 1000 characters in length.
        [<Config.Form>]Message: string option
    }
    with
        static member New(?message: string) =
            {
                Message = message
            }

    type Update'CustomText = {
        ///Custom text that should be displayed alongside shipping address collection.
        [<Config.Form>]ShippingAddress: Choice<Update'CustomTextShippingAddressCustomTextPosition,string> option
        ///Custom text that should be displayed alongside the payment confirmation button.
        [<Config.Form>]Submit: Choice<Update'CustomTextSubmitCustomTextPosition,string> option
    }
    with
        static member New(?shippingAddress: Choice<Update'CustomTextShippingAddressCustomTextPosition,string>, ?submit: Choice<Update'CustomTextSubmitCustomTextPosition,string>) =
            {
                ShippingAddress = shippingAddress
                Submit = submit
            }

    type Update'InvoiceCreationInvoiceDataCustomFields = {
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

    type Update'InvoiceCreationInvoiceDataRenderingOptionsRenderingOptionsAmountTaxDisplay =
    | ExcludeTax
    | IncludeInclusiveTax

    type Update'InvoiceCreationInvoiceDataRenderingOptionsRenderingOptions = {
        ///How line-item prices and amounts will be displayed with respect to tax on invoice PDFs. One of `exclude_tax` or `include_inclusive_tax`. `include_inclusive_tax` will include inclusive tax (and exclude exclusive tax) in invoice PDF amounts. `exclude_tax` will exclude all tax (inclusive and exclusive alike) from invoice PDF amounts.
        [<Config.Form>]AmountTaxDisplay: Update'InvoiceCreationInvoiceDataRenderingOptionsRenderingOptionsAmountTaxDisplay option
    }
    with
        static member New(?amountTaxDisplay: Update'InvoiceCreationInvoiceDataRenderingOptionsRenderingOptionsAmountTaxDisplay) =
            {
                AmountTaxDisplay = amountTaxDisplay
            }

    type Update'InvoiceCreationInvoiceData = {
        ///The account tax IDs associated with the invoice.
        [<Config.Form>]AccountTaxIds: Choice<string list,string> option
        ///Default custom fields to be displayed on invoices for this customer.
        [<Config.Form>]CustomFields: Choice<Update'InvoiceCreationInvoiceDataCustomFields list,string> option
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        [<Config.Form>]Description: string option
        ///Default footer to be displayed on invoices for this customer.
        [<Config.Form>]Footer: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Default options for invoice PDF rendering for this customer.
        [<Config.Form>]RenderingOptions: Choice<Update'InvoiceCreationInvoiceDataRenderingOptionsRenderingOptions,string> option
    }
    with
        static member New(?accountTaxIds: Choice<string list,string>, ?customFields: Choice<Update'InvoiceCreationInvoiceDataCustomFields list,string>, ?description: string, ?footer: string, ?metadata: Map<string, string>, ?renderingOptions: Choice<Update'InvoiceCreationInvoiceDataRenderingOptionsRenderingOptions,string>) =
            {
                AccountTaxIds = accountTaxIds
                CustomFields = customFields
                Description = description
                Footer = footer
                Metadata = metadata
                RenderingOptions = renderingOptions
            }

    type Update'InvoiceCreation = {
        ///Whether the feature is enabled
        [<Config.Form>]Enabled: bool option
        ///Invoice PDF configuration.
        [<Config.Form>]InvoiceData: Update'InvoiceCreationInvoiceData option
    }
    with
        static member New(?enabled: bool, ?invoiceData: Update'InvoiceCreationInvoiceData) =
            {
                Enabled = enabled
                InvoiceData = invoiceData
            }

    type Update'LineItemsAdjustableQuantity = {
        ///Set to true if the quantity can be adjusted to any non-negative Integer.
        [<Config.Form>]Enabled: bool option
        ///The maximum quantity the customer can purchase. By default this value is 99. You can specify a value up to 999.
        [<Config.Form>]Maximum: int option
        ///The minimum quantity the customer can purchase. By default this value is 0. If there is only one item in the cart then that item's quantity cannot go down to 0.
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
        ///When set, provides configuration for this item’s quantity to be adjusted by the customer during checkout.
        [<Config.Form>]AdjustableQuantity: Update'LineItemsAdjustableQuantity option
        ///The ID of an existing line item on the payment link.
        [<Config.Form>]Id: string option
        ///The quantity of the line item being purchased.
        [<Config.Form>]Quantity: int option
    }
    with
        static member New(?adjustableQuantity: Update'LineItemsAdjustableQuantity, ?id: string, ?quantity: int) =
            {
                AdjustableQuantity = adjustableQuantity
                Id = id
                Quantity = quantity
            }

    type Update'PaymentMethodTypes =
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

    type Update'ShippingAddressCollectionShippingAddressCollectionParamsAllowedCountries =
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

    type Update'ShippingAddressCollectionShippingAddressCollectionParams = {
        ///An array of two-letter ISO country codes representing which countries Checkout should provide as options for
        ///shipping locations. Unsupported country codes: `AS, CX, CC, CU, HM, IR, KP, MH, FM, NF, MP, PW, SD, SY, UM, VI`.
        [<Config.Form>]AllowedCountries: Update'ShippingAddressCollectionShippingAddressCollectionParamsAllowedCountries list option
    }
    with
        static member New(?allowedCountries: Update'ShippingAddressCollectionShippingAddressCollectionParamsAllowedCountries list) =
            {
                AllowedCountries = allowedCountries
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

    type UpdateOptions = {
        [<Config.Path>]PaymentLink: string
        ///Whether the payment link's `url` is active. If `false`, customers visiting the URL will be shown a page saying that the link has been deactivated.
        [<Config.Form>]Active: bool option
        ///Behavior after the purchase is complete.
        [<Config.Form>]AfterCompletion: Update'AfterCompletion option
        ///Enables user redeemable promotion codes.
        [<Config.Form>]AllowPromotionCodes: bool option
        ///Configuration for automatic tax collection.
        [<Config.Form>]AutomaticTax: Update'AutomaticTax option
        ///Configuration for collecting the customer's billing address.
        [<Config.Form>]BillingAddressCollection: Update'BillingAddressCollection option
        ///Collect additional information from your customer using custom fields. Up to 2 fields are supported.
        [<Config.Form>]CustomFields: Choice<Update'CustomFields list,string> option
        ///Display additional text for your customers using custom text.
        [<Config.Form>]CustomText: Update'CustomText option
        ///Configures whether [checkout sessions](https://stripe.com/docs/api/checkout/sessions) created by this payment link create a [Customer](https://stripe.com/docs/api/customers).
        [<Config.Form>]CustomerCreation: Update'CustomerCreation option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Generate a post-purchase Invoice for one-time payments.
        [<Config.Form>]InvoiceCreation: Update'InvoiceCreation option
        ///The line items representing what is being sold. Each line item represents an item being sold. Up to 20 line items are supported.
        [<Config.Form>]LineItems: Update'LineItems list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`. Metadata associated with this Payment Link will automatically be copied to [checkout sessions](https://stripe.com/docs/api/checkout/sessions) created by this payment link.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Specify whether Checkout should collect a payment method. When set to `if_required`, Checkout will not collect a payment method when the total due for the session is 0.This may occur if the Checkout Session includes a free trial or a discount.
        ///Can only be set in `subscription` mode.
        ///If you'd like information on how to collect a payment method outside of Checkout, read the guide on [configuring subscriptions with a free trial](https://stripe.com/docs/payments/checkout/free-trials).
        [<Config.Form>]PaymentMethodCollection: Update'PaymentMethodCollection option
        ///The list of payment method types that customers can use. Pass an empty string to enable dynamic payment methods that use your [payment method settings](https://dashboard.stripe.com/settings/payment_methods).
        [<Config.Form>]PaymentMethodTypes: Choice<Update'PaymentMethodTypes list,string> option
        ///Configuration for collecting the customer's shipping address.
        [<Config.Form>]ShippingAddressCollection: Choice<Update'ShippingAddressCollectionShippingAddressCollectionParams,string> option
    }
    with
        static member New(paymentLink: string, ?active: bool, ?afterCompletion: Update'AfterCompletion, ?allowPromotionCodes: bool, ?automaticTax: Update'AutomaticTax, ?billingAddressCollection: Update'BillingAddressCollection, ?customFields: Choice<Update'CustomFields list,string>, ?customText: Update'CustomText, ?customerCreation: Update'CustomerCreation, ?expand: string list, ?invoiceCreation: Update'InvoiceCreation, ?lineItems: Update'LineItems list, ?metadata: Map<string, string>, ?paymentMethodCollection: Update'PaymentMethodCollection, ?paymentMethodTypes: Choice<Update'PaymentMethodTypes list,string>, ?shippingAddressCollection: Choice<Update'ShippingAddressCollectionShippingAddressCollectionParams,string>) =
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
                InvoiceCreation = invoiceCreation
                LineItems = lineItems
                Metadata = metadata
                PaymentMethodCollection = paymentMethodCollection
                PaymentMethodTypes = paymentMethodTypes
                ShippingAddressCollection = shippingAddressCollection
            }

    ///<p>Updates a payment link.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/payment_links/{options.PaymentLink}"
        |> RestApi.postAsync<_, PaymentLink> settings (Map.empty) options

module PaymentLinksLineItems =

    type ListLineItemsOptions = {
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        [<Config.Path>]PaymentLink: string
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
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

    ///<p>When retrieving a payment link, there is an includable <strong>line_items</strong> property containing the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p>
    let ListLineItems settings (options: ListLineItemsOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/payment_links/{options.PaymentLink}/line_items"
        |> RestApi.getAsync<Item list> settings qs
