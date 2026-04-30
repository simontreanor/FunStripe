namespace StripeRequest.Customers

open FunStripe
open System.Text.Json.Serialization
open Stripe.PaymentMethod
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module Customers =

    type ListOptions =
        {
            /// Only return customers that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            /// A case-sensitive filter on the list based on the customer's `email` field. The value must be a string.
            [<Config.Query>]
            Email: string option
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
            /// Provides a list of customers that are associated with the specified test clock. The response will not include customers with test clocks if this parameter is not set.
            [<Config.Query>]
            TestClock: string option
        }

    module ListOptions =
        let create
            (
                created: int option,
                email: string option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option,
                testClock: string option
            ) : ListOptions
            =
            {
              Created = created
              Email = email
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
              TestClock = testClock
            }

    type Create'AddressOptionalFieldsCustomerAddress =
        {
            /// City, district, suburb, town, or village.
            [<Config.Form>]
            City: string option
            /// A freeform text field for the country. However, in order to activate some tax features, the format should be a two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
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

    module Create'AddressOptionalFieldsCustomerAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Create'AddressOptionalFieldsCustomerAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Create'CashBalanceSettingsReconciliationMode =
        | Automatic
        | Manual
        | MerchantDefault

    type Create'CashBalanceSettings =
        {
            /// Controls how funds transferred by the customer are applied to payment intents and invoices. Valid options are `automatic`, `manual`, or `merchant_default`. For more information about these reconciliation modes, see [Reconciliation](https://docs.stripe.com/payments/customer-balance/reconciliation).
            [<Config.Form>]
            ReconciliationMode: Create'CashBalanceSettingsReconciliationMode option
        }

    module Create'CashBalanceSettings =
        let create
            (
                reconciliationMode: Create'CashBalanceSettingsReconciliationMode option
            ) : Create'CashBalanceSettings
            =
            {
              ReconciliationMode = reconciliationMode
            }

    type Create'CashBalance =
        {
            /// Settings controlling the behavior of the customer's cash balance,
            /// such as reconciliation of funds received.
            [<Config.Form>]
            Settings: Create'CashBalanceSettings option
        }

    module Create'CashBalance =
        let create
            (
                settings: Create'CashBalanceSettings option
            ) : Create'CashBalance
            =
            {
              Settings = settings
            }

    type Create'InvoiceSettingsCustomFields =
        {
            /// The name of the custom field. This may be up to 40 characters.
            [<Config.Form>]
            Name: string option
            /// The value of the custom field. This may be up to 140 characters.
            [<Config.Form>]
            Value: string option
        }

    module Create'InvoiceSettingsCustomFields =
        let create
            (
                name: string option,
                value: string option
            ) : Create'InvoiceSettingsCustomFields
            =
            {
              Name = name
              Value = value
            }

    type Create'InvoiceSettingsRenderingOptionsCustomerRenderingOptionsAmountTaxDisplay =
        | ExcludeTax
        | IncludeInclusiveTax

    type Create'InvoiceSettingsRenderingOptionsCustomerRenderingOptions =
        {
            /// How line-item prices and amounts will be displayed with respect to tax on invoice PDFs. One of `exclude_tax` or `include_inclusive_tax`. `include_inclusive_tax` will include inclusive tax (and exclude exclusive tax) in invoice PDF amounts. `exclude_tax` will exclude all tax (inclusive and exclusive alike) from invoice PDF amounts.
            [<Config.Form>]
            AmountTaxDisplay: Create'InvoiceSettingsRenderingOptionsCustomerRenderingOptionsAmountTaxDisplay option
            /// ID of the invoice rendering template to use for future invoices.
            [<Config.Form>]
            Template: string option
        }

    module Create'InvoiceSettingsRenderingOptionsCustomerRenderingOptions =
        let create
            (
                amountTaxDisplay: Create'InvoiceSettingsRenderingOptionsCustomerRenderingOptionsAmountTaxDisplay option,
                template: string option
            ) : Create'InvoiceSettingsRenderingOptionsCustomerRenderingOptions
            =
            {
              AmountTaxDisplay = amountTaxDisplay
              Template = template
            }

    type Create'InvoiceSettings =
        {
            /// The list of up to 4 default custom fields to be displayed on invoices for this customer. When updating, pass an empty string to remove previously-defined fields.
            [<Config.Form>]
            CustomFields: Choice<Create'InvoiceSettingsCustomFields list,string> option
            /// ID of a payment method that's attached to the customer, to be used as the customer's default payment method for subscriptions and invoices.
            [<Config.Form>]
            DefaultPaymentMethod: string option
            /// Default footer to be displayed on invoices for this customer.
            [<Config.Form>]
            Footer: string option
            /// Default options for invoice PDF rendering for this customer.
            [<Config.Form>]
            RenderingOptions: Choice<Create'InvoiceSettingsRenderingOptionsCustomerRenderingOptions,string> option
        }

    module Create'InvoiceSettings =
        let create
            (
                customFields: Choice<Create'InvoiceSettingsCustomFields list,string> option,
                defaultPaymentMethod: string option,
                footer: string option,
                renderingOptions: Choice<Create'InvoiceSettingsRenderingOptionsCustomerRenderingOptions,string> option
            ) : Create'InvoiceSettings
            =
            {
              CustomFields = customFields
              DefaultPaymentMethod = defaultPaymentMethod
              Footer = footer
              RenderingOptions = renderingOptions
            }

    type Create'ShippingCustomerShippingAddress =
        {
            /// City, district, suburb, town, or village.
            [<Config.Form>]
            City: string option
            /// A freeform text field for the country. However, in order to activate some tax features, the format should be a two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
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

    module Create'ShippingCustomerShippingAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Create'ShippingCustomerShippingAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Create'ShippingCustomerShipping =
        {
            /// Customer shipping address.
            [<Config.Form>]
            Address: Create'ShippingCustomerShippingAddress option
            /// Customer name.
            [<Config.Form>]
            Name: string option
            /// Customer phone (including extension).
            [<Config.Form>]
            Phone: string option
        }

    module Create'ShippingCustomerShipping =
        let create
            (
                address: Create'ShippingCustomerShippingAddress option,
                name: string option,
                phone: string option
            ) : Create'ShippingCustomerShipping
            =
            {
              Address = address
              Name = name
              Phone = phone
            }

    type Create'TaxValidateLocation =
        | Deferred
        | Immediately

    type Create'Tax =
        {
            /// A recent IP address of the customer used for tax reporting and tax location inference. Stripe recommends updating the IP address when a new PaymentMethod is attached or the address field on the customer is updated. We recommend against updating this field more frequently since it could result in unexpected tax location/reporting outcomes.
            [<Config.Form>]
            IpAddress: Choice<string,string> option
            /// A flag that indicates when Stripe should validate the customer tax location. Defaults to `deferred`.
            [<Config.Form>]
            ValidateLocation: Create'TaxValidateLocation option
        }

    module Create'Tax =
        let create
            (
                ipAddress: Choice<string,string> option,
                validateLocation: Create'TaxValidateLocation option
            ) : Create'Tax
            =
            {
              IpAddress = ipAddress
              ValidateLocation = validateLocation
            }

    type Create'TaxExempt =
        | Exempt
        | [<JsonPropertyName("none")>] None'
        | Reverse

    type Create'TaxIdDataType =
        | AdNrt
        | AeTrn
        | AlTin
        | AmTin
        | AoTin
        | ArCuit
        | AuAbn
        | AuArn
        | AwTin
        | AzTin
        | BaTin
        | BbTin
        | BdBin
        | BfIfu
        | BgUic
        | BhVat
        | BjIfu
        | BoTin
        | BrCnpj
        | BrCpf
        | BsTin
        | ByTin
        | CaBn
        | CaGstHst
        | CaPstBc
        | CaPstMb
        | CaPstSk
        | CaQst
        | CdNif
        | ChUid
        | ChVat
        | ClTin
        | CmNiu
        | CnTin
        | CoNit
        | CrTin
        | CvNif
        | DeStn
        | DoRcn
        | EcRuc
        | EgTin
        | EsCif
        | EtTin
        | EuOssVat
        | EuVat
        | FoVat
        | GbVat
        | GeVat
        | GiTin
        | GnNif
        | HkBr
        | HrOib
        | HuTin
        | IdNpwp
        | IlVat
        | InGst
        | IsVat
        | ItCf
        | JpCn
        | JpRn
        | JpTrn
        | KePin
        | KgTin
        | KhTin
        | KrBrn
        | KzBin
        | LaTin
        | LiUid
        | LiVat
        | LkVat
        | MaVat
        | MdVat
        | MePib
        | MkVat
        | MrNif
        | MxRfc
        | MyFrp
        | MyItn
        | MySst
        | NgTin
        | NoVat
        | NoVoec
        | NpPan
        | NzGst
        | OmVat
        | PeRuc
        | PhTin
        | PlNip
        | PyRuc
        | RoTin
        | RsPib
        | RuInn
        | RuKpp
        | SaVat
        | SgGst
        | SgUen
        | SiTin
        | SnNinea
        | SrFin
        | SvNit
        | ThVat
        | TjTin
        | TrTin
        | TwVat
        | TzVat
        | UaVat
        | UgTin
        | UsEin
        | UyRuc
        | UzTin
        | UzVat
        | VeRif
        | VnTin
        | ZaVat
        | ZmTin
        | ZwTin

    type Create'TaxIdData =
        {
            /// Type of the tax ID, one of `ad_nrt`, `ae_trn`, `al_tin`, `am_tin`, `ao_tin`, `ar_cuit`, `au_abn`, `au_arn`, `aw_tin`, `az_tin`, `ba_tin`, `bb_tin`, `bd_bin`, `bf_ifu`, `bg_uic`, `bh_vat`, `bj_ifu`, `bo_tin`, `br_cnpj`, `br_cpf`, `bs_tin`, `by_tin`, `ca_bn`, `ca_gst_hst`, `ca_pst_bc`, `ca_pst_mb`, `ca_pst_sk`, `ca_qst`, `cd_nif`, `ch_uid`, `ch_vat`, `cl_tin`, `cm_niu`, `cn_tin`, `co_nit`, `cr_tin`, `cv_nif`, `de_stn`, `do_rcn`, `ec_ruc`, `eg_tin`, `es_cif`, `et_tin`, `eu_oss_vat`, `eu_vat`, `fo_vat`, `gb_vat`, `ge_vat`, `gi_tin`, `gn_nif`, `hk_br`, `hr_oib`, `hu_tin`, `id_npwp`, `il_vat`, `in_gst`, `is_vat`, `it_cf`, `jp_cn`, `jp_rn`, `jp_trn`, `ke_pin`, `kg_tin`, `kh_tin`, `kr_brn`, `kz_bin`, `la_tin`, `li_uid`, `li_vat`, `lk_vat`, `ma_vat`, `md_vat`, `me_pib`, `mk_vat`, `mr_nif`, `mx_rfc`, `my_frp`, `my_itn`, `my_sst`, `ng_tin`, `no_vat`, `no_voec`, `np_pan`, `nz_gst`, `om_vat`, `pe_ruc`, `ph_tin`, `pl_nip`, `py_ruc`, `ro_tin`, `rs_pib`, `ru_inn`, `ru_kpp`, `sa_vat`, `sg_gst`, `sg_uen`, `si_tin`, `sn_ninea`, `sr_fin`, `sv_nit`, `th_vat`, `tj_tin`, `tr_tin`, `tw_vat`, `tz_vat`, `ua_vat`, `ug_tin`, `us_ein`, `uy_ruc`, `uz_tin`, `uz_vat`, `ve_rif`, `vn_tin`, `za_vat`, `zm_tin`, or `zw_tin`
            [<Config.Form>]
            Type: Create'TaxIdDataType option
            /// Value of the tax ID.
            [<Config.Form>]
            Value: string option
        }

    module Create'TaxIdData =
        let create
            (
                ``type``: Create'TaxIdDataType option,
                value: string option
            ) : Create'TaxIdData
            =
            {
              Type = ``type``
              Value = value
            }

    type CreateOptions =
        {
            /// The customer's address. Learn about [country-specific requirements for calculating tax](https://docs.stripe.com/invoicing/taxes?dashboard-or-api=dashboard#set-up-customer).
            [<Config.Form>]
            Address: Choice<Create'AddressOptionalFieldsCustomerAddress,string> option
            /// An integer amount in cents (or local equivalent) that represents the customer's current balance, which affect the customer's future invoices. A negative amount represents a credit that decreases the amount due on an invoice; a positive amount increases the amount due on an invoice.
            [<Config.Form>]
            Balance: int option
            /// The customer's business name. This may be up to *150 characters*.
            [<Config.Form>]
            BusinessName: Choice<string,string> option
            /// Balance information and default balance settings for this customer.
            [<Config.Form>]
            CashBalance: Create'CashBalance option
            /// An arbitrary string that you can attach to a customer object. It is displayed alongside the customer in the dashboard.
            [<Config.Form>]
            Description: string option
            /// Customer's email address. It's displayed alongside the customer in your dashboard and can be useful for searching and tracking. This may be up to *512 characters*.
            [<Config.Form>]
            Email: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The customer's full name. This may be up to *150 characters*.
            [<Config.Form>]
            IndividualName: Choice<string,string> option
            /// The prefix for the customer used to generate unique invoice numbers. Must be 3–12 uppercase letters or numbers.
            [<Config.Form>]
            InvoicePrefix: string option
            /// Default invoice settings for this customer.
            [<Config.Form>]
            InvoiceSettings: Create'InvoiceSettings option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The customer's full name or business name.
            [<Config.Form>]
            Name: string option
            /// The sequence to be used on the customer's next invoice. Defaults to 1.
            [<Config.Form>]
            NextInvoiceSequence: int option
            [<Config.Form>]
            PaymentMethod: string option
            /// The customer's phone number.
            [<Config.Form>]
            Phone: string option
            /// Customer's preferred languages, ordered by preference.
            [<Config.Form>]
            PreferredLocales: string list option
            /// The customer's shipping information. Appears on invoices emailed to this customer.
            [<Config.Form>]
            Shipping: Choice<Create'ShippingCustomerShipping,string> option
            [<Config.Form>]
            Source: string option
            /// Tax details about the customer.
            [<Config.Form>]
            Tax: Create'Tax option
            /// The customer's tax exemption. One of `none`, `exempt`, or `reverse`.
            [<Config.Form>]
            TaxExempt: Create'TaxExempt option
            /// The customer's tax IDs.
            [<Config.Form>]
            TaxIdData: Create'TaxIdData list option
            /// ID of the test clock to attach to the customer.
            [<Config.Form>]
            TestClock: string option
            [<Config.Form>]
            Validate: bool option
        }

    module CreateOptions =
        let create
            (
                address: Choice<Create'AddressOptionalFieldsCustomerAddress,string> option,
                balance: int option,
                businessName: Choice<string,string> option,
                cashBalance: Create'CashBalance option,
                description: string option,
                email: string option,
                expand: string list option,
                individualName: Choice<string,string> option,
                invoicePrefix: string option,
                invoiceSettings: Create'InvoiceSettings option,
                metadata: Map<string, string> option,
                name: string option,
                nextInvoiceSequence: int option,
                paymentMethod: string option,
                phone: string option,
                preferredLocales: string list option,
                shipping: Choice<Create'ShippingCustomerShipping,string> option,
                source: string option,
                tax: Create'Tax option,
                taxExempt: Create'TaxExempt option,
                taxIdData: Create'TaxIdData list option,
                testClock: string option,
                validate: bool option
            ) : CreateOptions
            =
            {
              Address = address
              Balance = balance
              BusinessName = businessName
              CashBalance = cashBalance
              Description = description
              Email = email
              Expand = expand
              IndividualName = individualName
              InvoicePrefix = invoicePrefix
              InvoiceSettings = invoiceSettings
              Metadata = metadata
              Name = name
              NextInvoiceSequence = nextInvoiceSequence
              PaymentMethod = paymentMethod
              Phone = phone
              PreferredLocales = preferredLocales
              Shipping = shipping
              Source = source
              Tax = tax
              TaxExempt = taxExempt
              TaxIdData = taxIdData
              TestClock = testClock
              Validate = validate
            }

    type DeleteOptions =
        { [<Config.Path>]
          Customer: string }

    module DeleteOptions =
        let create
            (
                customer: string
            ) : DeleteOptions
            =
            {
              Customer = customer
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            Customer: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    module RetrieveOptions =
        let create
            (
                customer: string
            ) : RetrieveOptions
            =
            {
              Customer = customer
              Expand = None
            }

    type Update'AddressOptionalFieldsCustomerAddress =
        {
            /// City, district, suburb, town, or village.
            [<Config.Form>]
            City: string option
            /// A freeform text field for the country. However, in order to activate some tax features, the format should be a two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
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

    module Update'AddressOptionalFieldsCustomerAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Update'AddressOptionalFieldsCustomerAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Update'CashBalanceSettingsReconciliationMode =
        | Automatic
        | Manual
        | MerchantDefault

    type Update'CashBalanceSettings =
        {
            /// Controls how funds transferred by the customer are applied to payment intents and invoices. Valid options are `automatic`, `manual`, or `merchant_default`. For more information about these reconciliation modes, see [Reconciliation](https://docs.stripe.com/payments/customer-balance/reconciliation).
            [<Config.Form>]
            ReconciliationMode: Update'CashBalanceSettingsReconciliationMode option
        }

    module Update'CashBalanceSettings =
        let create
            (
                reconciliationMode: Update'CashBalanceSettingsReconciliationMode option
            ) : Update'CashBalanceSettings
            =
            {
              ReconciliationMode = reconciliationMode
            }

    type Update'CashBalance =
        {
            /// Settings controlling the behavior of the customer's cash balance,
            /// such as reconciliation of funds received.
            [<Config.Form>]
            Settings: Update'CashBalanceSettings option
        }

    module Update'CashBalance =
        let create
            (
                settings: Update'CashBalanceSettings option
            ) : Update'CashBalance
            =
            {
              Settings = settings
            }

    type Update'InvoiceSettingsCustomFields =
        {
            /// The name of the custom field. This may be up to 40 characters.
            [<Config.Form>]
            Name: string option
            /// The value of the custom field. This may be up to 140 characters.
            [<Config.Form>]
            Value: string option
        }

    module Update'InvoiceSettingsCustomFields =
        let create
            (
                name: string option,
                value: string option
            ) : Update'InvoiceSettingsCustomFields
            =
            {
              Name = name
              Value = value
            }

    type Update'InvoiceSettingsRenderingOptionsCustomerRenderingOptionsAmountTaxDisplay =
        | ExcludeTax
        | IncludeInclusiveTax

    type Update'InvoiceSettingsRenderingOptionsCustomerRenderingOptions =
        {
            /// How line-item prices and amounts will be displayed with respect to tax on invoice PDFs. One of `exclude_tax` or `include_inclusive_tax`. `include_inclusive_tax` will include inclusive tax (and exclude exclusive tax) in invoice PDF amounts. `exclude_tax` will exclude all tax (inclusive and exclusive alike) from invoice PDF amounts.
            [<Config.Form>]
            AmountTaxDisplay: Update'InvoiceSettingsRenderingOptionsCustomerRenderingOptionsAmountTaxDisplay option
            /// ID of the invoice rendering template to use for future invoices.
            [<Config.Form>]
            Template: string option
        }

    module Update'InvoiceSettingsRenderingOptionsCustomerRenderingOptions =
        let create
            (
                amountTaxDisplay: Update'InvoiceSettingsRenderingOptionsCustomerRenderingOptionsAmountTaxDisplay option,
                template: string option
            ) : Update'InvoiceSettingsRenderingOptionsCustomerRenderingOptions
            =
            {
              AmountTaxDisplay = amountTaxDisplay
              Template = template
            }

    type Update'InvoiceSettings =
        {
            /// The list of up to 4 default custom fields to be displayed on invoices for this customer. When updating, pass an empty string to remove previously-defined fields.
            [<Config.Form>]
            CustomFields: Choice<Update'InvoiceSettingsCustomFields list,string> option
            /// ID of a payment method that's attached to the customer, to be used as the customer's default payment method for subscriptions and invoices.
            [<Config.Form>]
            DefaultPaymentMethod: string option
            /// Default footer to be displayed on invoices for this customer.
            [<Config.Form>]
            Footer: string option
            /// Default options for invoice PDF rendering for this customer.
            [<Config.Form>]
            RenderingOptions: Choice<Update'InvoiceSettingsRenderingOptionsCustomerRenderingOptions,string> option
        }

    module Update'InvoiceSettings =
        let create
            (
                customFields: Choice<Update'InvoiceSettingsCustomFields list,string> option,
                defaultPaymentMethod: string option,
                footer: string option,
                renderingOptions: Choice<Update'InvoiceSettingsRenderingOptionsCustomerRenderingOptions,string> option
            ) : Update'InvoiceSettings
            =
            {
              CustomFields = customFields
              DefaultPaymentMethod = defaultPaymentMethod
              Footer = footer
              RenderingOptions = renderingOptions
            }

    type Update'ShippingCustomerShippingAddress =
        {
            /// City, district, suburb, town, or village.
            [<Config.Form>]
            City: string option
            /// A freeform text field for the country. However, in order to activate some tax features, the format should be a two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
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

    module Update'ShippingCustomerShippingAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Update'ShippingCustomerShippingAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Update'ShippingCustomerShipping =
        {
            /// Customer shipping address.
            [<Config.Form>]
            Address: Update'ShippingCustomerShippingAddress option
            /// Customer name.
            [<Config.Form>]
            Name: string option
            /// Customer phone (including extension).
            [<Config.Form>]
            Phone: string option
        }

    module Update'ShippingCustomerShipping =
        let create
            (
                address: Update'ShippingCustomerShippingAddress option,
                name: string option,
                phone: string option
            ) : Update'ShippingCustomerShipping
            =
            {
              Address = address
              Name = name
              Phone = phone
            }

    type Update'TaxValidateLocation =
        | Auto
        | Deferred
        | Immediately

    type Update'Tax =
        {
            /// A recent IP address of the customer used for tax reporting and tax location inference. Stripe recommends updating the IP address when a new PaymentMethod is attached or the address field on the customer is updated. We recommend against updating this field more frequently since it could result in unexpected tax location/reporting outcomes.
            [<Config.Form>]
            IpAddress: Choice<string,string> option
            /// A flag that indicates when Stripe should validate the customer tax location. Defaults to `auto`.
            [<Config.Form>]
            ValidateLocation: Update'TaxValidateLocation option
        }

    module Update'Tax =
        let create
            (
                ipAddress: Choice<string,string> option,
                validateLocation: Update'TaxValidateLocation option
            ) : Update'Tax
            =
            {
              IpAddress = ipAddress
              ValidateLocation = validateLocation
            }

    type Update'TaxExempt =
        | Exempt
        | [<JsonPropertyName("none")>] None'
        | Reverse

    type UpdateOptions =
        {
            [<Config.Path>]
            Customer: string
            /// The customer's address. Learn about [country-specific requirements for calculating tax](https://docs.stripe.com/invoicing/taxes?dashboard-or-api=dashboard#set-up-customer).
            [<Config.Form>]
            Address: Choice<Update'AddressOptionalFieldsCustomerAddress,string> option
            /// An integer amount in cents (or local equivalent) that represents the customer's current balance, which affect the customer's future invoices. A negative amount represents a credit that decreases the amount due on an invoice; a positive amount increases the amount due on an invoice.
            [<Config.Form>]
            Balance: int option
            /// The customer's business name. This may be up to *150 characters*.
            [<Config.Form>]
            BusinessName: Choice<string,string> option
            /// Balance information and default balance settings for this customer.
            [<Config.Form>]
            CashBalance: Update'CashBalance option
            /// If you are using payment methods created via the PaymentMethods API, see the [invoice_settings.default_payment_method](https://docs.stripe.com/api/customers/update#update_customer-invoice_settings-default_payment_method) parameter.
            /// Provide the ID of a payment source already attached to this customer to make it this customer's default payment source.
            /// If you want to add a new payment source and make it the default, see the [source](https://docs.stripe.com/api/customers/update#update_customer-source) property.
            [<Config.Form>]
            DefaultSource: string option
            /// An arbitrary string that you can attach to a customer object. It is displayed alongside the customer in the dashboard.
            [<Config.Form>]
            Description: string option
            /// Customer's email address. It's displayed alongside the customer in your dashboard and can be useful for searching and tracking. This may be up to *512 characters*.
            [<Config.Form>]
            Email: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The customer's full name. This may be up to *150 characters*.
            [<Config.Form>]
            IndividualName: Choice<string,string> option
            /// The prefix for the customer used to generate unique invoice numbers. Must be 3–12 uppercase letters or numbers.
            [<Config.Form>]
            InvoicePrefix: string option
            /// Default invoice settings for this customer.
            [<Config.Form>]
            InvoiceSettings: Update'InvoiceSettings option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The customer's full name or business name.
            [<Config.Form>]
            Name: string option
            /// The sequence to be used on the customer's next invoice. Defaults to 1.
            [<Config.Form>]
            NextInvoiceSequence: int option
            /// The customer's phone number.
            [<Config.Form>]
            Phone: string option
            /// Customer's preferred languages, ordered by preference.
            [<Config.Form>]
            PreferredLocales: string list option
            /// The customer's shipping information. Appears on invoices emailed to this customer.
            [<Config.Form>]
            Shipping: Choice<Update'ShippingCustomerShipping,string> option
            [<Config.Form>]
            Source: string option
            /// Tax details about the customer.
            [<Config.Form>]
            Tax: Update'Tax option
            /// The customer's tax exemption. One of `none`, `exempt`, or `reverse`.
            [<Config.Form>]
            TaxExempt: Update'TaxExempt option
            [<Config.Form>]
            Validate: bool option
        }

    module UpdateOptions =
        let create
            (
                customer: string
            ) : UpdateOptions
            =
            {
              Customer = customer
              Address = None
              Balance = None
              BusinessName = None
              CashBalance = None
              DefaultSource = None
              Description = None
              Email = None
              Expand = None
              IndividualName = None
              InvoicePrefix = None
              InvoiceSettings = None
              Metadata = None
              Name = None
              NextInvoiceSequence = None
              Phone = None
              PreferredLocales = None
              Shipping = None
              Source = None
              Tax = None
              TaxExempt = None
              Validate = None
            }

    ///<p>Returns a list of your customers. The customers are returned sorted by creation date, with the most recent customers appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("email", options.Email |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("test_clock", options.TestClock |> box)] |> Map.ofList
        $"/v1/customers"
        |> RestApi.getAsync<StripeList<Customer>> settings qs

    ///<p>Creates a new customer object.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/customers"
        |> RestApi.postAsync<_, Customer> settings (Map.empty) options

    ///<p>Permanently deletes a customer. It cannot be undone. Also immediately cancels any active subscriptions on the customer.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/customers/{options.Customer}"
        |> RestApi.deleteAsync<DeletedCustomer> settings (Map.empty)

    ///<p>Retrieves a Customer object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/customers/{options.Customer}"
        |> RestApi.getAsync<Customer> settings qs

    ///<p>Updates the specified customer by setting the values of the parameters passed. Any parameters not provided are left unchanged. For example, if you pass the <strong>source</strong> parameter, that becomes the customer’s active source (such as a card) to be used for all charges in the future. When you update a customer to a new valid card source by passing the <strong>source</strong> parameter: for each of the customer’s current subscriptions, if the subscription bills automatically and is in the <code>past_due</code> state, then the latest open invoice for the subscription with automatic collection enabled is retried. This retry doesn’t count as an automatic retry, and doesn’t affect the next regularly scheduled payment for the invoice. Changing the <strong>default_source</strong> for a customer doesn’t trigger this behavior.</p>
    ///<p>This request accepts mostly the same arguments as the customer creation call.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/customers/{options.Customer}"
        |> RestApi.postAsync<_, Customer> settings (Map.empty) options

module CustomersSearch =

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
            /// The search query string. See [search query language](https://docs.stripe.com/search#search-query-language) and the list of supported [query fields for customers](https://docs.stripe.com/search#query-fields-for-customers).
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

    ///<p>Search for customers you’ve previously created using Stripe’s <a href="/docs/search#search-query-language">Search Query Language</a>.
    ///Don’t use search in read-after-write flows where strict consistency is necessary. Under normal operating
    ///conditions, data is searchable in less than a minute. Occasionally, propagation of new or updated data can be up
    ///to an hour behind during outages. Search functionality is not available to merchants in India.</p>
    let Search settings (options: SearchOptions) =
        let qs = [("expand", options.Expand |> box); ("limit", options.Limit |> box); ("page", options.Page |> box); ("query", options.Query |> box)] |> Map.ofList
        $"/v1/customers/search"
        |> RestApi.getAsync<StripeList<Customer>> settings qs

module CustomersBalanceTransactions =

    type BalanceTransactionsOptions =
        {
            /// Only return customer balance transactions that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            [<Config.Path>]
            Customer: string
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// Only return transactions that are related to the specified invoice.
            [<Config.Query>]
            Invoice: string option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    module BalanceTransactionsOptions =
        let create
            (
                customer: string
            ) : BalanceTransactionsOptions
            =
            {
              Customer = customer
              Created = None
              EndingBefore = None
              Expand = None
              Invoice = None
              Limit = None
              StartingAfter = None
            }

    type CreateOptions =
        {
            [<Config.Path>]
            Customer: string
            /// The integer amount in **cents (or local equivalent)** to apply to the customer's credit balance.
            [<Config.Form>]
            Amount: int
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies). Specifies the [`invoice_credit_balance`](https://docs.stripe.com/api/customers/object#customer_object-invoice_credit_balance) that this transaction will apply to. If the customer's `currency` is not set, it will be updated to this value.
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode
            /// An arbitrary string attached to the object. Often useful for displaying to users.
            [<Config.Form>]
            Description: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
        }

    module CreateOptions =
        let create
            (
                amount: int,
                currency: IsoTypes.IsoCurrencyCode,
                customer: string
            ) : CreateOptions
            =
            {
              Amount = amount
              Currency = currency
              Customer = customer
              Description = None
              Expand = None
              Metadata = None
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            Customer: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Transaction: string
        }

    module RetrieveOptions =
        let create
            (
                customer: string,
                transaction: string
            ) : RetrieveOptions
            =
            {
              Customer = customer
              Transaction = transaction
              Expand = None
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Customer: string
            [<Config.Path>]
            Transaction: string
            /// An arbitrary string attached to the object. Often useful for displaying to users.
            [<Config.Form>]
            Description: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
        }

    module UpdateOptions =
        let create
            (
                customer: string,
                transaction: string
            ) : UpdateOptions
            =
            {
              Customer = customer
              Transaction = transaction
              Description = None
              Expand = None
              Metadata = None
            }

    ///<p>Returns a list of transactions that updated the customer’s <a href="/docs/billing/customer/balance">balances</a>.</p>
    let BalanceTransactions settings (options: BalanceTransactionsOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("invoice", options.Invoice |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/customers/{options.Customer}/balance_transactions"
        |> RestApi.getAsync<StripeList<CustomerBalanceTransaction>> settings qs

    ///<p>Creates an immutable transaction that updates the customer’s credit <a href="/docs/billing/customer/balance">balance</a>.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/customers/{options.Customer}/balance_transactions"
        |> RestApi.postAsync<_, CustomerBalanceTransaction> settings (Map.empty) options

    ///<p>Retrieves a specific customer balance transaction that updated the customer’s <a href="/docs/billing/customer/balance">balances</a>.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/customers/{options.Customer}/balance_transactions/{options.Transaction}"
        |> RestApi.getAsync<CustomerBalanceTransaction> settings qs

    ///<p>Most credit balance transaction fields are immutable, but you may update its <code>description</code> and <code>metadata</code>.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/customers/{options.Customer}/balance_transactions/{options.Transaction}"
        |> RestApi.postAsync<_, CustomerBalanceTransaction> settings (Map.empty) options

module CustomersCashBalance =

    type RetrieveOptions =
        {
            [<Config.Path>]
            Customer: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    module RetrieveOptions =
        let create
            (
                customer: string
            ) : RetrieveOptions
            =
            {
              Customer = customer
              Expand = None
            }

    type Update'SettingsReconciliationMode =
        | Automatic
        | Manual
        | MerchantDefault

    type Update'Settings =
        {
            /// Controls how funds transferred by the customer are applied to payment intents and invoices. Valid options are `automatic`, `manual`, or `merchant_default`. For more information about these reconciliation modes, see [Reconciliation](https://docs.stripe.com/payments/customer-balance/reconciliation).
            [<Config.Form>]
            ReconciliationMode: Update'SettingsReconciliationMode option
        }

    module Update'Settings =
        let create
            (
                reconciliationMode: Update'SettingsReconciliationMode option
            ) : Update'Settings
            =
            {
              ReconciliationMode = reconciliationMode
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Customer: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// A hash of settings for this cash balance.
            [<Config.Form>]
            Settings: Update'Settings option
        }

    module UpdateOptions =
        let create
            (
                customer: string
            ) : UpdateOptions
            =
            {
              Customer = customer
              Expand = None
              Settings = None
            }

    ///<p>Retrieves a customer’s cash balance.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/customers/{options.Customer}/cash_balance"
        |> RestApi.getAsync<CashBalance> settings qs

    ///<p>Changes the settings on a customer’s cash balance.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/customers/{options.Customer}/cash_balance"
        |> RestApi.postAsync<_, CashBalance> settings (Map.empty) options

module CustomersCashBalanceTransactions =

    type ListOptions =
        {
            [<Config.Path>]
            Customer: string
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
        }

    module ListOptions =
        let create
            (
                customer: string
            ) : ListOptions
            =
            {
              Customer = customer
              EndingBefore = None
              Expand = None
              Limit = None
              StartingAfter = None
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            Customer: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Transaction: string
        }

    module RetrieveOptions =
        let create
            (
                customer: string,
                transaction: string
            ) : RetrieveOptions
            =
            {
              Customer = customer
              Transaction = transaction
              Expand = None
            }

    ///<p>Returns a list of transactions that modified the customer’s <a href="/docs/payments/customer-balance">cash balance</a>.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/customers/{options.Customer}/cash_balance_transactions"
        |> RestApi.getAsync<StripeList<CustomerCashBalanceTransaction>> settings qs

    ///<p>Retrieves a specific cash balance transaction, which updated the customer’s <a href="/docs/payments/customer-balance">cash balance</a>.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/customers/{options.Customer}/cash_balance_transactions/{options.Transaction}"
        |> RestApi.getAsync<CustomerCashBalanceTransaction> settings qs

module CustomersDiscount =

    type DeleteDiscountOptions =
        { [<Config.Path>]
          Customer: string }

    module DeleteDiscountOptions =
        let create
            (
                customer: string
            ) : DeleteDiscountOptions
            =
            {
              Customer = customer
            }

    ///<p>Removes the currently applied discount on a customer.</p>
    let DeleteDiscount settings (options: DeleteDiscountOptions) =
        $"/v1/customers/{options.Customer}/discount"
        |> RestApi.deleteAsync<DeletedDiscount> settings (Map.empty)

module CustomersFundingInstructions =

    type CreateFundingInstructions'BankTransferEuBankTransfer =
        {
            /// The desired country code of the bank account information. Permitted values include: `DE`, `FR`, `IE`, or `NL`.
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
        }

    module CreateFundingInstructions'BankTransferEuBankTransfer =
        let create
            (
                country: IsoTypes.IsoCountryCode option
            ) : CreateFundingInstructions'BankTransferEuBankTransfer
            =
            {
              Country = country
            }

    type CreateFundingInstructions'BankTransferRequestedAddressTypes =
        | Iban
        | SortCode
        | Spei
        | Zengin

    type CreateFundingInstructions'BankTransferType =
        | EuBankTransfer
        | GbBankTransfer
        | JpBankTransfer
        | MxBankTransfer
        | UsBankTransfer

    type CreateFundingInstructions'BankTransfer =
        {
            /// Configuration for eu_bank_transfer funding type.
            [<Config.Form>]
            EuBankTransfer: CreateFundingInstructions'BankTransferEuBankTransfer option
            /// List of address types that should be returned in the financial_addresses response. If not specified, all valid types will be returned.
            /// Permitted values include: `sort_code`, `zengin`, `iban`, or `spei`.
            [<Config.Form>]
            RequestedAddressTypes: CreateFundingInstructions'BankTransferRequestedAddressTypes list option
            /// The type of the `bank_transfer`
            [<Config.Form>]
            Type: CreateFundingInstructions'BankTransferType option
        }

    module CreateFundingInstructions'BankTransfer =
        let create
            (
                euBankTransfer: CreateFundingInstructions'BankTransferEuBankTransfer option,
                requestedAddressTypes: CreateFundingInstructions'BankTransferRequestedAddressTypes list option,
                ``type``: CreateFundingInstructions'BankTransferType option
            ) : CreateFundingInstructions'BankTransfer
            =
            {
              EuBankTransfer = euBankTransfer
              RequestedAddressTypes = requestedAddressTypes
              Type = ``type``
            }

    type CreateFundingInstructions'FundingType = | BankTransfer

    type CreateFundingInstructionsOptions =
        {
            [<Config.Path>]
            Customer: string
            /// Additional parameters for `bank_transfer` funding types
            [<Config.Form>]
            BankTransfer: CreateFundingInstructions'BankTransfer
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The `funding_type` to get the instructions for.
            [<Config.Form>]
            FundingType: CreateFundingInstructions'FundingType
        }

    module CreateFundingInstructionsOptions =
        let create
            (
                bankTransfer: CreateFundingInstructions'BankTransfer,
                currency: IsoTypes.IsoCurrencyCode,
                customer: string,
                fundingType: CreateFundingInstructions'FundingType
            ) : CreateFundingInstructionsOptions
            =
            {
              BankTransfer = bankTransfer
              Currency = currency
              Customer = customer
              FundingType = fundingType
              Expand = None
            }

    ///<p>Retrieve funding instructions for a customer cash balance. If funding instructions do not yet exist for the customer, new
    ///funding instructions will be created. If funding instructions have already been created for a given customer, the same
    ///funding instructions will be retrieved. In other words, we will return the same funding instructions each time.</p>
    let CreateFundingInstructions settings (options: CreateFundingInstructionsOptions) =
        $"/v1/customers/{options.Customer}/funding_instructions"
        |> RestApi.postAsync<_, FundingInstructions> settings (Map.empty) options

module CustomersPaymentMethods =

    type ListPaymentMethodsOptions =
        {
            /// This field indicates whether this payment method can be shown again to its customer in a checkout flow. Stripe products such as Checkout and Elements use this field to determine whether a payment method can be shown as a saved payment method in a checkout flow.
            [<Config.Query>]
            AllowRedisplay: string option
            [<Config.Path>]
            Customer: string
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
            /// An optional filter on the list, based on the object `type` field. Without the filter, the list includes all current and future payment method types. If your integration expects only one type of payment method in the response, make sure to provide a type value in the request.
            [<Config.Query>]
            Type: string option
        }

    module ListPaymentMethodsOptions =
        let create
            (
                customer: string
            ) : ListPaymentMethodsOptions
            =
            {
              Customer = customer
              AllowRedisplay = None
              EndingBefore = None
              Expand = None
              Limit = None
              StartingAfter = None
              Type = None
            }

    type RetrievePaymentMethodOptions =
        {
            [<Config.Path>]
            Customer: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            PaymentMethod: string
        }

    module RetrievePaymentMethodOptions =
        let create
            (
                customer: string,
                paymentMethod: string
            ) : RetrievePaymentMethodOptions
            =
            {
              Customer = customer
              PaymentMethod = paymentMethod
              Expand = None
            }

    ///<p>Returns a list of PaymentMethods for a given Customer</p>
    let ListPaymentMethods settings (options: ListPaymentMethodsOptions) =
        let qs = [("allow_redisplay", options.AllowRedisplay |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("type", options.Type |> box)] |> Map.ofList
        $"/v1/customers/{options.Customer}/payment_methods"
        |> RestApi.getAsync<StripeList<PaymentMethod>> settings qs

    ///<p>Retrieves a PaymentMethod object for a given Customer.</p>
    let RetrievePaymentMethod settings (options: RetrievePaymentMethodOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/customers/{options.Customer}/payment_methods/{options.PaymentMethod}"
        |> RestApi.getAsync<PaymentMethod> settings qs

module CustomersSources =

    type ListOptions =
        {
            [<Config.Path>]
            Customer: string
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// Filter sources according to a particular object type.
            [<Config.Query>]
            Object: string option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    module ListOptions =
        let create
            (
                customer: string
            ) : ListOptions
            =
            {
              Customer = customer
              EndingBefore = None
              Expand = None
              Limit = None
              Object = None
              StartingAfter = None
            }

    type CreateOptions =
        {
            [<Config.Path>]
            Customer: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Please refer to full [documentation](https://api.stripe.com) instead.
            [<Config.Form>]
            Source: string
            [<Config.Form>]
            Validate: bool option
        }

    module CreateOptions =
        let create
            (
                customer: string,
                source: string
            ) : CreateOptions
            =
            {
              Customer = customer
              Source = source
              Expand = None
              Metadata = None
              Validate = None
            }

    type DeleteOptions =
        {
            [<Config.Path>]
            Customer: string
            [<Config.Path>]
            Id: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module DeleteOptions =
        let create
            (
                customer: string,
                id: string
            ) : DeleteOptions
            =
            {
              Customer = customer
              Id = id
              Expand = None
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            Customer: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Id: string
        }

    module RetrieveOptions =
        let create
            (
                customer: string,
                id: string
            ) : RetrieveOptions
            =
            {
              Customer = customer
              Id = id
              Expand = None
            }

    type Update'AccountHolderType =
        | Company
        | Individual

    type Update'OwnerAddress =
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

    module Update'OwnerAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Update'OwnerAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Update'Owner =
        {
            /// Owner's address.
            [<Config.Form>]
            Address: Update'OwnerAddress option
            /// Owner's email address.
            [<Config.Form>]
            Email: string option
            /// Owner's full name.
            [<Config.Form>]
            Name: string option
            /// Owner's phone number.
            [<Config.Form>]
            Phone: string option
        }

    module Update'Owner =
        let create
            (
                address: Update'OwnerAddress option,
                email: string option,
                name: string option,
                phone: string option
            ) : Update'Owner
            =
            {
              Address = address
              Email = email
              Name = name
              Phone = phone
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Customer: string
            [<Config.Path>]
            Id: string
            /// The name of the person or business that owns the bank account.
            [<Config.Form>]
            AccountHolderName: string option
            /// The type of entity that holds the account. This can be either `individual` or `company`.
            [<Config.Form>]
            AccountHolderType: Update'AccountHolderType option
            /// City/District/Suburb/Town/Village.
            [<Config.Form>]
            AddressCity: string option
            /// Billing address country, if provided when creating card.
            [<Config.Form>]
            AddressCountry: IsoTypes.IsoCountryCode option
            /// Address line 1 (Street address/PO Box/Company name).
            [<Config.Form>]
            AddressLine1: string option
            /// Address line 2 (Apartment/Suite/Unit/Building).
            [<Config.Form>]
            AddressLine2: string option
            /// State/County/Province/Region.
            [<Config.Form>]
            AddressState: string option
            /// ZIP or postal code.
            [<Config.Form>]
            AddressZip: string option
            /// Two digit number representing the card’s expiration month.
            [<Config.Form>]
            ExpMonth: string option
            /// Four digit number representing the card’s expiration year.
            [<Config.Form>]
            ExpYear: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Cardholder name.
            [<Config.Form>]
            Name: string option
            [<Config.Form>]
            Owner: Update'Owner option
        }

    module UpdateOptions =
        let create
            (
                customer: string,
                id: string
            ) : UpdateOptions
            =
            {
              Customer = customer
              Id = id
              AccountHolderName = None
              AccountHolderType = None
              AddressCity = None
              AddressCountry = None
              AddressLine1 = None
              AddressLine2 = None
              AddressState = None
              AddressZip = None
              ExpMonth = None
              ExpYear = None
              Expand = None
              Metadata = None
              Name = None
              Owner = None
            }

    ///<p>List sources for a specified customer.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("object", options.Object |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/customers/{options.Customer}/sources"
        |> RestApi.getAsync<StripeList<PaymentSource>> settings qs

    ///<p>When you create a new credit card, you must specify a customer or recipient on which to create it.</p>
    ///<p>If the card’s owner has no default card, then the new card will become the default.
    ///However, if the owner already has a default, then it will not change.
    ///To change the default, you should <a href="/api/customers/update">update the customer</a> to have a new <code>default_source</code>.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/customers/{options.Customer}/sources"
        |> RestApi.postAsync<_, PaymentSource> settings (Map.empty) options

    ///<p>Delete a specified source for a given customer.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/customers/{options.Customer}/sources/{options.Id}"
        |> RestApi.deleteAsync<PaymentSource> settings (Map.empty)

    ///<p>Retrieve a specified source for a given customer.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/customers/{options.Customer}/sources/{options.Id}"
        |> RestApi.getAsync<PaymentSource> settings qs

    ///<p>Update a specified source for a given customer.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/customers/{options.Customer}/sources/{options.Id}"
        |> RestApi.postAsync<_, Card> settings (Map.empty) options

module CustomersSourcesVerify =

    type VerifyOptions =
        {
            [<Config.Path>]
            Customer: string
            [<Config.Path>]
            Id: string
            /// Two positive integers, in *cents*, equal to the values of the microdeposits sent to the bank account.
            [<Config.Form>]
            Amounts: int list option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module VerifyOptions =
        let create
            (
                customer: string,
                id: string
            ) : VerifyOptions
            =
            {
              Customer = customer
              Id = id
              Amounts = None
              Expand = None
            }

    ///<p>Verify a specified bank account for a given customer.</p>
    let Verify settings (options: VerifyOptions) =
        $"/v1/customers/{options.Customer}/sources/{options.Id}/verify"
        |> RestApi.postAsync<_, BankAccount> settings (Map.empty) options

module CustomersTaxIds =

    type ListOptions =
        {
            [<Config.Path>]
            Customer: string
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
        }

    module ListOptions =
        let create
            (
                customer: string
            ) : ListOptions
            =
            {
              Customer = customer
              EndingBefore = None
              Expand = None
              Limit = None
              StartingAfter = None
            }

    type Create'Type =
        | AdNrt
        | AeTrn
        | AlTin
        | AmTin
        | AoTin
        | ArCuit
        | AuAbn
        | AuArn
        | AwTin
        | AzTin
        | BaTin
        | BbTin
        | BdBin
        | BfIfu
        | BgUic
        | BhVat
        | BjIfu
        | BoTin
        | BrCnpj
        | BrCpf
        | BsTin
        | ByTin
        | CaBn
        | CaGstHst
        | CaPstBc
        | CaPstMb
        | CaPstSk
        | CaQst
        | CdNif
        | ChUid
        | ChVat
        | ClTin
        | CmNiu
        | CnTin
        | CoNit
        | CrTin
        | CvNif
        | DeStn
        | DoRcn
        | EcRuc
        | EgTin
        | EsCif
        | EtTin
        | EuOssVat
        | EuVat
        | FoVat
        | GbVat
        | GeVat
        | GiTin
        | GnNif
        | HkBr
        | HrOib
        | HuTin
        | IdNpwp
        | IlVat
        | InGst
        | IsVat
        | ItCf
        | JpCn
        | JpRn
        | JpTrn
        | KePin
        | KgTin
        | KhTin
        | KrBrn
        | KzBin
        | LaTin
        | LiUid
        | LiVat
        | LkVat
        | MaVat
        | MdVat
        | MePib
        | MkVat
        | MrNif
        | MxRfc
        | MyFrp
        | MyItn
        | MySst
        | NgTin
        | NoVat
        | NoVoec
        | NpPan
        | NzGst
        | OmVat
        | PeRuc
        | PhTin
        | PlNip
        | PyRuc
        | RoTin
        | RsPib
        | RuInn
        | RuKpp
        | SaVat
        | SgGst
        | SgUen
        | SiTin
        | SnNinea
        | SrFin
        | SvNit
        | ThVat
        | TjTin
        | TrTin
        | TwVat
        | TzVat
        | UaVat
        | UgTin
        | UsEin
        | UyRuc
        | UzTin
        | UzVat
        | VeRif
        | VnTin
        | ZaVat
        | ZmTin
        | ZwTin

    type CreateOptions =
        {
            [<Config.Path>]
            Customer: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Type of the tax ID, one of `ad_nrt`, `ae_trn`, `al_tin`, `am_tin`, `ao_tin`, `ar_cuit`, `au_abn`, `au_arn`, `aw_tin`, `az_tin`, `ba_tin`, `bb_tin`, `bd_bin`, `bf_ifu`, `bg_uic`, `bh_vat`, `bj_ifu`, `bo_tin`, `br_cnpj`, `br_cpf`, `bs_tin`, `by_tin`, `ca_bn`, `ca_gst_hst`, `ca_pst_bc`, `ca_pst_mb`, `ca_pst_sk`, `ca_qst`, `cd_nif`, `ch_uid`, `ch_vat`, `cl_tin`, `cm_niu`, `cn_tin`, `co_nit`, `cr_tin`, `cv_nif`, `de_stn`, `do_rcn`, `ec_ruc`, `eg_tin`, `es_cif`, `et_tin`, `eu_oss_vat`, `eu_vat`, `fo_vat`, `gb_vat`, `ge_vat`, `gi_tin`, `gn_nif`, `hk_br`, `hr_oib`, `hu_tin`, `id_npwp`, `il_vat`, `in_gst`, `is_vat`, `it_cf`, `jp_cn`, `jp_rn`, `jp_trn`, `ke_pin`, `kg_tin`, `kh_tin`, `kr_brn`, `kz_bin`, `la_tin`, `li_uid`, `li_vat`, `lk_vat`, `ma_vat`, `md_vat`, `me_pib`, `mk_vat`, `mr_nif`, `mx_rfc`, `my_frp`, `my_itn`, `my_sst`, `ng_tin`, `no_vat`, `no_voec`, `np_pan`, `nz_gst`, `om_vat`, `pe_ruc`, `ph_tin`, `pl_nip`, `py_ruc`, `ro_tin`, `rs_pib`, `ru_inn`, `ru_kpp`, `sa_vat`, `sg_gst`, `sg_uen`, `si_tin`, `sn_ninea`, `sr_fin`, `sv_nit`, `th_vat`, `tj_tin`, `tr_tin`, `tw_vat`, `tz_vat`, `ua_vat`, `ug_tin`, `us_ein`, `uy_ruc`, `uz_tin`, `uz_vat`, `ve_rif`, `vn_tin`, `za_vat`, `zm_tin`, or `zw_tin`
            [<Config.Form>]
            Type: Create'Type
            /// Value of the tax ID.
            [<Config.Form>]
            Value: string
        }

    module CreateOptions =
        let create
            (
                customer: string,
                ``type``: Create'Type,
                value: string
            ) : CreateOptions
            =
            {
              Customer = customer
              Type = ``type``
              Value = value
              Expand = None
            }

    type DeleteOptions =
        { [<Config.Path>]
          Customer: string
          [<Config.Path>]
          Id: string }

    module DeleteOptions =
        let create
            (
                customer: string,
                id: string
            ) : DeleteOptions
            =
            {
              Customer = customer
              Id = id
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            Customer: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Id: string
        }

    module RetrieveOptions =
        let create
            (
                customer: string,
                id: string
            ) : RetrieveOptions
            =
            {
              Customer = customer
              Id = id
              Expand = None
            }

    ///<p>Returns a list of tax IDs for a customer.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/customers/{options.Customer}/tax_ids"
        |> RestApi.getAsync<StripeList<TaxId>> settings qs

    ///<p>Creates a new <code>tax_id</code> object for a customer.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/customers/{options.Customer}/tax_ids"
        |> RestApi.postAsync<_, TaxId> settings (Map.empty) options

    ///<p>Deletes an existing <code>tax_id</code> object.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/customers/{options.Customer}/tax_ids/{options.Id}"
        |> RestApi.deleteAsync<DeletedTaxId> settings (Map.empty)

    ///<p>Retrieves the <code>tax_id</code> object with the given identifier.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/customers/{options.Customer}/tax_ids/{options.Id}"
        |> RestApi.getAsync<TaxId> settings qs

