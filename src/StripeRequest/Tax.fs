namespace StripeRequest.Tax

open FunStripe
open System.Text.Json.Serialization
open Stripe.Deleted
open Stripe.Payment
open Stripe.Tax
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
module TaxAssociationsFind =

    type FindOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// Valid [PaymentIntent](https://docs.stripe.com/api/payment_intents/object) id
            [<Config.Query>]
            PaymentIntent: string
        }

    module FindOptions =
        let create
            (
                paymentIntent: string,
                expand: string list option
            ) : FindOptions
            =
            {
              PaymentIntent = paymentIntent
              Expand = expand
            }

    ///<p>Finds a tax association object by PaymentIntent id.</p>
    let Find settings (options: FindOptions) =
        let qs = [("expand", options.Expand |> box); ("payment_intent", options.PaymentIntent |> box)] |> Map.ofList
        $"/v1/tax/associations/find"
        |> RestApi.getAsync<TaxAssociation> settings qs

module TaxCalculations =

    type Create'CustomerDetailsAddress =
        {
            /// City, district, suburb, town, or village.
            [<Config.Form>]
            City: Choice<string,string> option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Address line 1, such as the street, PO Box, or company name.
            [<Config.Form>]
            Line1: Choice<string,string> option
            /// Address line 2, such as the apartment, suite, unit, or building.
            [<Config.Form>]
            Line2: Choice<string,string> option
            /// ZIP or postal code.
            [<Config.Form>]
            PostalCode: Choice<string,string> option
            /// State, county, province, or region. We recommend sending [ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2) subdivision code value when possible.
            [<Config.Form>]
            State: Choice<string,string> option
        }

    module Create'CustomerDetailsAddress =
        let create
            (
                city: Choice<string,string> option,
                country: IsoTypes.IsoCountryCode option,
                line1: Choice<string,string> option,
                line2: Choice<string,string> option,
                postalCode: Choice<string,string> option,
                state: Choice<string,string> option
            ) : Create'CustomerDetailsAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Create'CustomerDetailsAddressSource =
        | Billing
        | Shipping

    type Create'CustomerDetailsTaxIdsType =
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

    type Create'CustomerDetailsTaxIds =
        {
            /// Type of the tax ID, one of `ad_nrt`, `ae_trn`, `al_tin`, `am_tin`, `ao_tin`, `ar_cuit`, `au_abn`, `au_arn`, `aw_tin`, `az_tin`, `ba_tin`, `bb_tin`, `bd_bin`, `bf_ifu`, `bg_uic`, `bh_vat`, `bj_ifu`, `bo_tin`, `br_cnpj`, `br_cpf`, `bs_tin`, `by_tin`, `ca_bn`, `ca_gst_hst`, `ca_pst_bc`, `ca_pst_mb`, `ca_pst_sk`, `ca_qst`, `cd_nif`, `ch_uid`, `ch_vat`, `cl_tin`, `cm_niu`, `cn_tin`, `co_nit`, `cr_tin`, `cv_nif`, `de_stn`, `do_rcn`, `ec_ruc`, `eg_tin`, `es_cif`, `et_tin`, `eu_oss_vat`, `eu_vat`, `fo_vat`, `gb_vat`, `ge_vat`, `gi_tin`, `gn_nif`, `hk_br`, `hr_oib`, `hu_tin`, `id_npwp`, `il_vat`, `in_gst`, `is_vat`, `it_cf`, `jp_cn`, `jp_rn`, `jp_trn`, `ke_pin`, `kg_tin`, `kh_tin`, `kr_brn`, `kz_bin`, `la_tin`, `li_uid`, `li_vat`, `lk_vat`, `ma_vat`, `md_vat`, `me_pib`, `mk_vat`, `mr_nif`, `mx_rfc`, `my_frp`, `my_itn`, `my_sst`, `ng_tin`, `no_vat`, `no_voec`, `np_pan`, `nz_gst`, `om_vat`, `pe_ruc`, `ph_tin`, `pl_nip`, `py_ruc`, `ro_tin`, `rs_pib`, `ru_inn`, `ru_kpp`, `sa_vat`, `sg_gst`, `sg_uen`, `si_tin`, `sn_ninea`, `sr_fin`, `sv_nit`, `th_vat`, `tj_tin`, `tr_tin`, `tw_vat`, `tz_vat`, `ua_vat`, `ug_tin`, `us_ein`, `uy_ruc`, `uz_tin`, `uz_vat`, `ve_rif`, `vn_tin`, `za_vat`, `zm_tin`, or `zw_tin`
            [<Config.Form>]
            Type: Create'CustomerDetailsTaxIdsType option
            /// Value of the tax ID.
            [<Config.Form>]
            Value: string option
        }

    module Create'CustomerDetailsTaxIds =
        let create
            (
                ``type``: Create'CustomerDetailsTaxIdsType option,
                value: string option
            ) : Create'CustomerDetailsTaxIds
            =
            {
              Type = ``type``
              Value = value
            }

    type Create'CustomerDetailsTaxabilityOverride =
        | CustomerExempt
        | [<JsonPropertyName("none")>] None'
        | ReverseCharge

    type Create'CustomerDetails =
        {
            /// The customer's postal address (for example, home or business location).
            [<Config.Form>]
            Address: Create'CustomerDetailsAddress option
            /// The type of customer address provided.
            [<Config.Form>]
            AddressSource: Create'CustomerDetailsAddressSource option
            /// The customer's IP address (IPv4 or IPv6).
            [<Config.Form>]
            IpAddress: string option
            /// The customer's tax IDs. Stripe Tax might consider a transaction with applicable tax IDs to be B2B, which might affect the tax calculation result. Stripe Tax doesn't validate tax IDs for correctness.
            [<Config.Form>]
            TaxIds: Create'CustomerDetailsTaxIds list option
            /// Overrides the tax calculation result to allow you to not collect tax from your customer. Use this if you've manually checked your customer's tax exemptions. Prefer providing the customer's `tax_ids` where possible, which automatically determines whether `reverse_charge` applies.
            [<Config.Form>]
            TaxabilityOverride: Create'CustomerDetailsTaxabilityOverride option
        }

    module Create'CustomerDetails =
        let create
            (
                address: Create'CustomerDetailsAddress option,
                addressSource: Create'CustomerDetailsAddressSource option,
                ipAddress: string option,
                taxIds: Create'CustomerDetailsTaxIds list option,
                taxabilityOverride: Create'CustomerDetailsTaxabilityOverride option
            ) : Create'CustomerDetails
            =
            {
              Address = address
              AddressSource = addressSource
              IpAddress = ipAddress
              TaxIds = taxIds
              TaxabilityOverride = taxabilityOverride
            }

    type Create'LineItemsTaxBehavior =
        | Exclusive
        | Inclusive

    type Create'LineItems =
        {
            /// A positive integer representing the line item's total price in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units).
            /// If `tax_behavior=inclusive`, then this amount includes taxes. Otherwise, taxes are calculated on top of this amount.
            [<Config.Form>]
            Amount: int option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// If provided, the product's `tax_code` will be used as the line item's `tax_code`.
            [<Config.Form>]
            Product: string option
            /// The number of units of the item being purchased. Used to calculate the per-unit price from the total `amount` for the line. For example, if `amount=100` and `quantity=4`, the calculated unit price is 25.
            [<Config.Form>]
            Quantity: int option
            /// A custom identifier for this line item, which must be unique across the line items in the calculation. The reference helps identify each line item in exported [tax reports](https://docs.stripe.com/tax/reports).
            [<Config.Form>]
            Reference: string option
            /// Specifies whether the `amount` includes taxes. Defaults to `exclusive`.
            [<Config.Form>]
            TaxBehavior: Create'LineItemsTaxBehavior option
            /// A [tax code](https://docs.stripe.com/tax/tax-categories) ID to use for this line item. If not provided, we will use the tax code from the provided `product` param. If neither `tax_code` nor `product` is provided, we will use the default tax code from your Tax Settings.
            [<Config.Form>]
            TaxCode: string option
        }

    module Create'LineItems =
        let create
            (
                amount: int option,
                metadata: Map<string, string> option,
                product: string option,
                quantity: int option,
                reference: string option,
                taxBehavior: Create'LineItemsTaxBehavior option,
                taxCode: string option
            ) : Create'LineItems
            =
            {
              Amount = amount
              Metadata = metadata
              Product = product
              Quantity = quantity
              Reference = reference
              TaxBehavior = taxBehavior
              TaxCode = taxCode
            }

    type Create'ShipFromDetailsAddress =
        {
            /// City, district, suburb, town, or village.
            [<Config.Form>]
            City: Choice<string,string> option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Address line 1, such as the street, PO Box, or company name.
            [<Config.Form>]
            Line1: Choice<string,string> option
            /// Address line 2, such as the apartment, suite, unit, or building.
            [<Config.Form>]
            Line2: Choice<string,string> option
            /// ZIP or postal code.
            [<Config.Form>]
            PostalCode: Choice<string,string> option
            /// State/province as an [ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2) subdivision code, without country prefix, such as "NY" or "TX".
            [<Config.Form>]
            State: Choice<string,string> option
        }

    module Create'ShipFromDetailsAddress =
        let create
            (
                city: Choice<string,string> option,
                country: IsoTypes.IsoCountryCode option,
                line1: Choice<string,string> option,
                line2: Choice<string,string> option,
                postalCode: Choice<string,string> option,
                state: Choice<string,string> option
            ) : Create'ShipFromDetailsAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Create'ShipFromDetails =
        {
            /// The address from which the goods are being shipped from.
            [<Config.Form>]
            Address: Create'ShipFromDetailsAddress option
        }

    module Create'ShipFromDetails =
        let create
            (
                address: Create'ShipFromDetailsAddress option
            ) : Create'ShipFromDetails
            =
            {
              Address = address
            }

    type Create'ShippingCostTaxBehavior =
        | Exclusive
        | Inclusive

    type Create'ShippingCost =
        {
            /// A positive integer in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units) representing the shipping charge. If `tax_behavior=inclusive`, then this amount includes taxes. Otherwise, taxes are calculated on top of this amount.
            [<Config.Form>]
            Amount: int option
            /// If provided, the [shipping rate](https://docs.stripe.com/api/shipping_rates/object)'s `amount`, `tax_code` and `tax_behavior` are used. If you provide a shipping rate, then you cannot pass the `amount`, `tax_code`, or `tax_behavior` parameters.
            [<Config.Form>]
            ShippingRate: string option
            /// Specifies whether the `amount` includes taxes. If `tax_behavior=inclusive`, then the amount includes taxes. Defaults to `exclusive`.
            [<Config.Form>]
            TaxBehavior: Create'ShippingCostTaxBehavior option
            /// The [tax code](https://docs.stripe.com/tax/tax-categories) used to calculate tax on shipping. If not provided, the default shipping tax code from your [Tax Settings](https://dashboard.stripe.com/settings/tax) is used.
            [<Config.Form>]
            TaxCode: string option
        }

    module Create'ShippingCost =
        let create
            (
                amount: int option,
                shippingRate: string option,
                taxBehavior: Create'ShippingCostTaxBehavior option,
                taxCode: string option
            ) : Create'ShippingCost
            =
            {
              Amount = amount
              ShippingRate = shippingRate
              TaxBehavior = taxBehavior
              TaxCode = taxCode
            }

    type CreateOptions =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode
            /// The ID of an existing customer to use for this calculation. If provided, the customer's address and tax IDs are copied to `customer_details`.
            [<Config.Form>]
            Customer: string option
            /// Details about the customer, including address and tax IDs.
            [<Config.Form>]
            CustomerDetails: Create'CustomerDetails option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// A list of items the customer is purchasing.
            [<Config.Form>]
            LineItems: Create'LineItems list
            /// Details about the address from which the goods are being shipped.
            [<Config.Form>]
            ShipFromDetails: Create'ShipFromDetails option
            /// Shipping cost details to be used for the calculation.
            [<Config.Form>]
            ShippingCost: Create'ShippingCost option
            /// Timestamp of date at which the tax rules and rates in effect applies for the calculation. Measured in seconds since the Unix epoch. Can be up to 48 hours in the past, and up to 48 hours in the future.
            [<Config.Form>]
            TaxDate: int option
        }

    module CreateOptions =
        let create
            (
                currency: IsoTypes.IsoCurrencyCode,
                lineItems: Create'LineItems list,
                customer: string option,
                customerDetails: Create'CustomerDetails option,
                expand: string list option,
                shipFromDetails: Create'ShipFromDetails option,
                shippingCost: Create'ShippingCost option,
                taxDate: int option
            ) : CreateOptions
            =
            {
              Currency = currency
              LineItems = lineItems
              Customer = customer
              CustomerDetails = customerDetails
              Expand = expand
              ShipFromDetails = shipFromDetails
              ShippingCost = shippingCost
              TaxDate = taxDate
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            Calculation: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    module RetrieveOptions =
        let create
            (
                calculation: string,
                expand: string list option
            ) : RetrieveOptions
            =
            {
              Calculation = calculation
              Expand = expand
            }

    ///<p>Calculates tax based on the input and returns a Tax <code>Calculation</code> object.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/tax/calculations"
        |> RestApi.postAsync<_, TaxCalculation> settings (Map.empty) options

    ///<p>Retrieves a Tax <code>Calculation</code> object, if the calculation hasn’t expired.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/tax/calculations/{options.Calculation}"
        |> RestApi.getAsync<TaxCalculation> settings qs

module TaxCalculationsLineItems =

    type ListLineItemsOptions =
        {
            [<Config.Path>]
            Calculation: string
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

    module ListLineItemsOptions =
        let create
            (
                calculation: string,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option
            ) : ListLineItemsOptions
            =
            {
              Calculation = calculation
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
            }

    ///<p>Retrieves the line items of a tax calculation as a collection, if the calculation hasn’t expired.</p>
    let ListLineItems settings (options: ListLineItemsOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/tax/calculations/{options.Calculation}/line_items"
        |> RestApi.getAsync<StripeList<TaxCalculationLineItem>> settings qs

module TaxRegistrations =

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
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// The status of the Tax Registration.
            [<Config.Query>]
            Status: string option
        }

    module ListOptions =
        let create
            (
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option,
                status: string option
            ) : ListOptions
            =
            {
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
              Status = status
            }

    type Create'ActiveFrom = | Now

    type Create'CountryOptionsAeStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsAeStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsAeStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsAeStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsAeStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsAeStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsAeType = | Standard

    type Create'CountryOptionsAe =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsAeStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsAeType option
        }

    module Create'CountryOptionsAe =
        let create
            (
                standard: Create'CountryOptionsAeStandard option,
                ``type``: Create'CountryOptionsAeType option
            ) : Create'CountryOptionsAe
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsAlStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsAlStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsAlStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsAlStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsAlStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsAlStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsAlType = | Standard

    type Create'CountryOptionsAl =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsAlStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsAlType option
        }

    module Create'CountryOptionsAl =
        let create
            (
                standard: Create'CountryOptionsAlStandard option,
                ``type``: Create'CountryOptionsAlType option
            ) : Create'CountryOptionsAl
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsAmType = | Simplified

    type Create'CountryOptionsAm =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsAmType option
        }

    module Create'CountryOptionsAm =
        let create
            (
                ``type``: Create'CountryOptionsAmType option
            ) : Create'CountryOptionsAm
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsAoStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsAoStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsAoStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsAoStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsAoStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsAoStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsAoType = | Standard

    type Create'CountryOptionsAo =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsAoStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsAoType option
        }

    module Create'CountryOptionsAo =
        let create
            (
                standard: Create'CountryOptionsAoStandard option,
                ``type``: Create'CountryOptionsAoType option
            ) : Create'CountryOptionsAo
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsAtStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsAtStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsAtStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsAtStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsAtStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsAtStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsAtType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsAt =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsAtStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsAtType option
        }

    module Create'CountryOptionsAt =
        let create
            (
                standard: Create'CountryOptionsAtStandard option,
                ``type``: Create'CountryOptionsAtType option
            ) : Create'CountryOptionsAt
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsAuStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsAuStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsAuStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsAuStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsAuStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsAuStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsAuType = | Standard

    type Create'CountryOptionsAu =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsAuStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsAuType option
        }

    module Create'CountryOptionsAu =
        let create
            (
                standard: Create'CountryOptionsAuStandard option,
                ``type``: Create'CountryOptionsAuType option
            ) : Create'CountryOptionsAu
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsAwStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsAwStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsAwStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsAwStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsAwStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsAwStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsAwType = | Standard

    type Create'CountryOptionsAw =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsAwStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsAwType option
        }

    module Create'CountryOptionsAw =
        let create
            (
                standard: Create'CountryOptionsAwStandard option,
                ``type``: Create'CountryOptionsAwType option
            ) : Create'CountryOptionsAw
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsAzType = | Simplified

    type Create'CountryOptionsAz =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsAzType option
        }

    module Create'CountryOptionsAz =
        let create
            (
                ``type``: Create'CountryOptionsAzType option
            ) : Create'CountryOptionsAz
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsBaStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsBaStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsBaStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsBaStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsBaStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsBaStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsBaType = | Standard

    type Create'CountryOptionsBa =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsBaStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsBaType option
        }

    module Create'CountryOptionsBa =
        let create
            (
                standard: Create'CountryOptionsBaStandard option,
                ``type``: Create'CountryOptionsBaType option
            ) : Create'CountryOptionsBa
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsBbStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsBbStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsBbStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsBbStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsBbStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsBbStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsBbType = | Standard

    type Create'CountryOptionsBb =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsBbStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsBbType option
        }

    module Create'CountryOptionsBb =
        let create
            (
                standard: Create'CountryOptionsBbStandard option,
                ``type``: Create'CountryOptionsBbType option
            ) : Create'CountryOptionsBb
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsBdStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsBdStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsBdStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsBdStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsBdStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsBdStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsBdType = | Standard

    type Create'CountryOptionsBd =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsBdStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsBdType option
        }

    module Create'CountryOptionsBd =
        let create
            (
                standard: Create'CountryOptionsBdStandard option,
                ``type``: Create'CountryOptionsBdType option
            ) : Create'CountryOptionsBd
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsBeStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsBeStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsBeStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsBeStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsBeStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsBeStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsBeType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsBe =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsBeStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsBeType option
        }

    module Create'CountryOptionsBe =
        let create
            (
                standard: Create'CountryOptionsBeStandard option,
                ``type``: Create'CountryOptionsBeType option
            ) : Create'CountryOptionsBe
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsBfStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsBfStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsBfStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsBfStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsBfStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsBfStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsBfType = | Standard

    type Create'CountryOptionsBf =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsBfStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsBfType option
        }

    module Create'CountryOptionsBf =
        let create
            (
                standard: Create'CountryOptionsBfStandard option,
                ``type``: Create'CountryOptionsBfType option
            ) : Create'CountryOptionsBf
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsBgStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsBgStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsBgStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsBgStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsBgStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsBgStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsBgType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsBg =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsBgStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsBgType option
        }

    module Create'CountryOptionsBg =
        let create
            (
                standard: Create'CountryOptionsBgStandard option,
                ``type``: Create'CountryOptionsBgType option
            ) : Create'CountryOptionsBg
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsBhStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsBhStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsBhStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsBhStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsBhStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsBhStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsBhType = | Standard

    type Create'CountryOptionsBh =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsBhStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsBhType option
        }

    module Create'CountryOptionsBh =
        let create
            (
                standard: Create'CountryOptionsBhStandard option,
                ``type``: Create'CountryOptionsBhType option
            ) : Create'CountryOptionsBh
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsBjType = | Simplified

    type Create'CountryOptionsBj =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsBjType option
        }

    module Create'CountryOptionsBj =
        let create
            (
                ``type``: Create'CountryOptionsBjType option
            ) : Create'CountryOptionsBj
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsBsStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsBsStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsBsStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsBsStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsBsStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsBsStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsBsType = | Standard

    type Create'CountryOptionsBs =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsBsStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsBsType option
        }

    module Create'CountryOptionsBs =
        let create
            (
                standard: Create'CountryOptionsBsStandard option,
                ``type``: Create'CountryOptionsBsType option
            ) : Create'CountryOptionsBs
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsByType = | Simplified

    type Create'CountryOptionsBy =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsByType option
        }

    module Create'CountryOptionsBy =
        let create
            (
                ``type``: Create'CountryOptionsByType option
            ) : Create'CountryOptionsBy
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsCaProvinceStandard =
        {
            /// Two-letter CA province code ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
            [<Config.Form>]
            Province: string option
        }

    module Create'CountryOptionsCaProvinceStandard =
        let create
            (
                province: string option
            ) : Create'CountryOptionsCaProvinceStandard
            =
            {
              Province = province
            }

    type Create'CountryOptionsCaType =
        | ProvinceStandard
        | Simplified
        | Standard

    type Create'CountryOptionsCa =
        {
            /// Options for the provincial tax registration.
            [<Config.Form>]
            ProvinceStandard: Create'CountryOptionsCaProvinceStandard option
            /// Type of registration to be created in Canada.
            [<Config.Form>]
            Type: Create'CountryOptionsCaType option
        }

    module Create'CountryOptionsCa =
        let create
            (
                provinceStandard: Create'CountryOptionsCaProvinceStandard option,
                ``type``: Create'CountryOptionsCaType option
            ) : Create'CountryOptionsCa
            =
            {
              ProvinceStandard = provinceStandard
              Type = ``type``
            }

    type Create'CountryOptionsCdStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsCdStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsCdStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsCdStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsCdStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsCdStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsCdType = | Standard

    type Create'CountryOptionsCd =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsCdStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsCdType option
        }

    module Create'CountryOptionsCd =
        let create
            (
                standard: Create'CountryOptionsCdStandard option,
                ``type``: Create'CountryOptionsCdType option
            ) : Create'CountryOptionsCd
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsChStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsChStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsChStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsChStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsChStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsChStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsChType = | Standard

    type Create'CountryOptionsCh =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsChStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsChType option
        }

    module Create'CountryOptionsCh =
        let create
            (
                standard: Create'CountryOptionsChStandard option,
                ``type``: Create'CountryOptionsChType option
            ) : Create'CountryOptionsCh
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsClType = | Simplified

    type Create'CountryOptionsCl =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsClType option
        }

    module Create'CountryOptionsCl =
        let create
            (
                ``type``: Create'CountryOptionsClType option
            ) : Create'CountryOptionsCl
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsCmType = | Simplified

    type Create'CountryOptionsCm =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsCmType option
        }

    module Create'CountryOptionsCm =
        let create
            (
                ``type``: Create'CountryOptionsCmType option
            ) : Create'CountryOptionsCm
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsCoType = | Simplified

    type Create'CountryOptionsCo =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsCoType option
        }

    module Create'CountryOptionsCo =
        let create
            (
                ``type``: Create'CountryOptionsCoType option
            ) : Create'CountryOptionsCo
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsCrType = | Simplified

    type Create'CountryOptionsCr =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsCrType option
        }

    module Create'CountryOptionsCr =
        let create
            (
                ``type``: Create'CountryOptionsCrType option
            ) : Create'CountryOptionsCr
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsCvType = | Simplified

    type Create'CountryOptionsCv =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsCvType option
        }

    module Create'CountryOptionsCv =
        let create
            (
                ``type``: Create'CountryOptionsCvType option
            ) : Create'CountryOptionsCv
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsCyStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsCyStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsCyStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsCyStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsCyStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsCyStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsCyType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsCy =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsCyStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsCyType option
        }

    module Create'CountryOptionsCy =
        let create
            (
                standard: Create'CountryOptionsCyStandard option,
                ``type``: Create'CountryOptionsCyType option
            ) : Create'CountryOptionsCy
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsCzStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsCzStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsCzStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsCzStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsCzStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsCzStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsCzType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsCz =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsCzStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsCzType option
        }

    module Create'CountryOptionsCz =
        let create
            (
                standard: Create'CountryOptionsCzStandard option,
                ``type``: Create'CountryOptionsCzType option
            ) : Create'CountryOptionsCz
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsDeStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsDeStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsDeStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsDeStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsDeStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsDeStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsDeType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsDe =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsDeStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsDeType option
        }

    module Create'CountryOptionsDe =
        let create
            (
                standard: Create'CountryOptionsDeStandard option,
                ``type``: Create'CountryOptionsDeType option
            ) : Create'CountryOptionsDe
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsDkStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsDkStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsDkStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsDkStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsDkStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsDkStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsDkType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsDk =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsDkStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsDkType option
        }

    module Create'CountryOptionsDk =
        let create
            (
                standard: Create'CountryOptionsDkStandard option,
                ``type``: Create'CountryOptionsDkType option
            ) : Create'CountryOptionsDk
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsEcType = | Simplified

    type Create'CountryOptionsEc =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsEcType option
        }

    module Create'CountryOptionsEc =
        let create
            (
                ``type``: Create'CountryOptionsEcType option
            ) : Create'CountryOptionsEc
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsEeStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsEeStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsEeStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsEeStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsEeStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsEeStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsEeType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsEe =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsEeStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsEeType option
        }

    module Create'CountryOptionsEe =
        let create
            (
                standard: Create'CountryOptionsEeStandard option,
                ``type``: Create'CountryOptionsEeType option
            ) : Create'CountryOptionsEe
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsEgType = | Simplified

    type Create'CountryOptionsEg =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsEgType option
        }

    module Create'CountryOptionsEg =
        let create
            (
                ``type``: Create'CountryOptionsEgType option
            ) : Create'CountryOptionsEg
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsEsStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsEsStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsEsStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsEsStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsEsStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsEsStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsEsType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsEs =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsEsStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsEsType option
        }

    module Create'CountryOptionsEs =
        let create
            (
                standard: Create'CountryOptionsEsStandard option,
                ``type``: Create'CountryOptionsEsType option
            ) : Create'CountryOptionsEs
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsEtStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsEtStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsEtStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsEtStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsEtStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsEtStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsEtType = | Standard

    type Create'CountryOptionsEt =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsEtStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsEtType option
        }

    module Create'CountryOptionsEt =
        let create
            (
                standard: Create'CountryOptionsEtStandard option,
                ``type``: Create'CountryOptionsEtType option
            ) : Create'CountryOptionsEt
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsFiStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsFiStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsFiStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsFiStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsFiStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsFiStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsFiType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsFi =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsFiStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsFiType option
        }

    module Create'CountryOptionsFi =
        let create
            (
                standard: Create'CountryOptionsFiStandard option,
                ``type``: Create'CountryOptionsFiType option
            ) : Create'CountryOptionsFi
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsFrStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsFrStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsFrStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsFrStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsFrStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsFrStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsFrType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsFr =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsFrStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsFrType option
        }

    module Create'CountryOptionsFr =
        let create
            (
                standard: Create'CountryOptionsFrStandard option,
                ``type``: Create'CountryOptionsFrType option
            ) : Create'CountryOptionsFr
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsGbStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsGbStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsGbStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsGbStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsGbStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsGbStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsGbType = | Standard

    type Create'CountryOptionsGb =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsGbStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsGbType option
        }

    module Create'CountryOptionsGb =
        let create
            (
                standard: Create'CountryOptionsGbStandard option,
                ``type``: Create'CountryOptionsGbType option
            ) : Create'CountryOptionsGb
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsGeType = | Simplified

    type Create'CountryOptionsGe =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsGeType option
        }

    module Create'CountryOptionsGe =
        let create
            (
                ``type``: Create'CountryOptionsGeType option
            ) : Create'CountryOptionsGe
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsGnStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsGnStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsGnStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsGnStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsGnStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsGnStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsGnType = | Standard

    type Create'CountryOptionsGn =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsGnStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsGnType option
        }

    module Create'CountryOptionsGn =
        let create
            (
                standard: Create'CountryOptionsGnStandard option,
                ``type``: Create'CountryOptionsGnType option
            ) : Create'CountryOptionsGn
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsGrStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsGrStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsGrStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsGrStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsGrStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsGrStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsGrType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsGr =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsGrStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsGrType option
        }

    module Create'CountryOptionsGr =
        let create
            (
                standard: Create'CountryOptionsGrStandard option,
                ``type``: Create'CountryOptionsGrType option
            ) : Create'CountryOptionsGr
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsHrStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsHrStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsHrStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsHrStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsHrStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsHrStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsHrType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsHr =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsHrStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsHrType option
        }

    module Create'CountryOptionsHr =
        let create
            (
                standard: Create'CountryOptionsHrStandard option,
                ``type``: Create'CountryOptionsHrType option
            ) : Create'CountryOptionsHr
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsHuStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsHuStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsHuStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsHuStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsHuStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsHuStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsHuType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsHu =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsHuStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsHuType option
        }

    module Create'CountryOptionsHu =
        let create
            (
                standard: Create'CountryOptionsHuStandard option,
                ``type``: Create'CountryOptionsHuType option
            ) : Create'CountryOptionsHu
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsIdType = | Simplified

    type Create'CountryOptionsId =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsIdType option
        }

    module Create'CountryOptionsId =
        let create
            (
                ``type``: Create'CountryOptionsIdType option
            ) : Create'CountryOptionsId
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsIeStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsIeStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsIeStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsIeStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsIeStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsIeStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsIeType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsIe =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsIeStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsIeType option
        }

    module Create'CountryOptionsIe =
        let create
            (
                standard: Create'CountryOptionsIeStandard option,
                ``type``: Create'CountryOptionsIeType option
            ) : Create'CountryOptionsIe
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsInType = | Simplified

    type Create'CountryOptionsIn =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsInType option
        }

    module Create'CountryOptionsIn =
        let create
            (
                ``type``: Create'CountryOptionsInType option
            ) : Create'CountryOptionsIn
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsIsStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsIsStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsIsStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsIsStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsIsStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsIsStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsIsType = | Standard

    type Create'CountryOptionsIs =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsIsStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsIsType option
        }

    module Create'CountryOptionsIs =
        let create
            (
                standard: Create'CountryOptionsIsStandard option,
                ``type``: Create'CountryOptionsIsType option
            ) : Create'CountryOptionsIs
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsItStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsItStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsItStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsItStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsItStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsItStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsItType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsIt =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsItStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsItType option
        }

    module Create'CountryOptionsIt =
        let create
            (
                standard: Create'CountryOptionsItStandard option,
                ``type``: Create'CountryOptionsItType option
            ) : Create'CountryOptionsIt
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsJpStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsJpStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsJpStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsJpStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsJpStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsJpStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsJpType = | Standard

    type Create'CountryOptionsJp =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsJpStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsJpType option
        }

    module Create'CountryOptionsJp =
        let create
            (
                standard: Create'CountryOptionsJpStandard option,
                ``type``: Create'CountryOptionsJpType option
            ) : Create'CountryOptionsJp
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsKeType = | Simplified

    type Create'CountryOptionsKe =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsKeType option
        }

    module Create'CountryOptionsKe =
        let create
            (
                ``type``: Create'CountryOptionsKeType option
            ) : Create'CountryOptionsKe
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsKgType = | Simplified

    type Create'CountryOptionsKg =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsKgType option
        }

    module Create'CountryOptionsKg =
        let create
            (
                ``type``: Create'CountryOptionsKgType option
            ) : Create'CountryOptionsKg
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsKhType = | Simplified

    type Create'CountryOptionsKh =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsKhType option
        }

    module Create'CountryOptionsKh =
        let create
            (
                ``type``: Create'CountryOptionsKhType option
            ) : Create'CountryOptionsKh
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsKrType = | Simplified

    type Create'CountryOptionsKr =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsKrType option
        }

    module Create'CountryOptionsKr =
        let create
            (
                ``type``: Create'CountryOptionsKrType option
            ) : Create'CountryOptionsKr
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsKzType = | Simplified

    type Create'CountryOptionsKz =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsKzType option
        }

    module Create'CountryOptionsKz =
        let create
            (
                ``type``: Create'CountryOptionsKzType option
            ) : Create'CountryOptionsKz
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsLaType = | Simplified

    type Create'CountryOptionsLa =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsLaType option
        }

    module Create'CountryOptionsLa =
        let create
            (
                ``type``: Create'CountryOptionsLaType option
            ) : Create'CountryOptionsLa
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsLkType = | Simplified

    type Create'CountryOptionsLk =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsLkType option
        }

    module Create'CountryOptionsLk =
        let create
            (
                ``type``: Create'CountryOptionsLkType option
            ) : Create'CountryOptionsLk
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsLtStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsLtStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsLtStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsLtStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsLtStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsLtStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsLtType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsLt =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsLtStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsLtType option
        }

    module Create'CountryOptionsLt =
        let create
            (
                standard: Create'CountryOptionsLtStandard option,
                ``type``: Create'CountryOptionsLtType option
            ) : Create'CountryOptionsLt
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsLuStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsLuStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsLuStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsLuStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsLuStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsLuStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsLuType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsLu =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsLuStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsLuType option
        }

    module Create'CountryOptionsLu =
        let create
            (
                standard: Create'CountryOptionsLuStandard option,
                ``type``: Create'CountryOptionsLuType option
            ) : Create'CountryOptionsLu
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsLvStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsLvStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsLvStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsLvStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsLvStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsLvStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsLvType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsLv =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsLvStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsLvType option
        }

    module Create'CountryOptionsLv =
        let create
            (
                standard: Create'CountryOptionsLvStandard option,
                ``type``: Create'CountryOptionsLvType option
            ) : Create'CountryOptionsLv
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsMaType = | Simplified

    type Create'CountryOptionsMa =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsMaType option
        }

    module Create'CountryOptionsMa =
        let create
            (
                ``type``: Create'CountryOptionsMaType option
            ) : Create'CountryOptionsMa
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsMdType = | Simplified

    type Create'CountryOptionsMd =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsMdType option
        }

    module Create'CountryOptionsMd =
        let create
            (
                ``type``: Create'CountryOptionsMdType option
            ) : Create'CountryOptionsMd
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsMeStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsMeStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsMeStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsMeStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsMeStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsMeStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsMeType = | Standard

    type Create'CountryOptionsMe =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsMeStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsMeType option
        }

    module Create'CountryOptionsMe =
        let create
            (
                standard: Create'CountryOptionsMeStandard option,
                ``type``: Create'CountryOptionsMeType option
            ) : Create'CountryOptionsMe
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsMkStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsMkStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsMkStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsMkStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsMkStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsMkStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsMkType = | Standard

    type Create'CountryOptionsMk =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsMkStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsMkType option
        }

    module Create'CountryOptionsMk =
        let create
            (
                standard: Create'CountryOptionsMkStandard option,
                ``type``: Create'CountryOptionsMkType option
            ) : Create'CountryOptionsMk
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsMrStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsMrStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsMrStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsMrStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsMrStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsMrStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsMrType = | Standard

    type Create'CountryOptionsMr =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsMrStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsMrType option
        }

    module Create'CountryOptionsMr =
        let create
            (
                standard: Create'CountryOptionsMrStandard option,
                ``type``: Create'CountryOptionsMrType option
            ) : Create'CountryOptionsMr
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsMtStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsMtStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsMtStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsMtStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsMtStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsMtStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsMtType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsMt =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsMtStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsMtType option
        }

    module Create'CountryOptionsMt =
        let create
            (
                standard: Create'CountryOptionsMtStandard option,
                ``type``: Create'CountryOptionsMtType option
            ) : Create'CountryOptionsMt
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsMxType = | Simplified

    type Create'CountryOptionsMx =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsMxType option
        }

    module Create'CountryOptionsMx =
        let create
            (
                ``type``: Create'CountryOptionsMxType option
            ) : Create'CountryOptionsMx
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsMyType = | Simplified

    type Create'CountryOptionsMy =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsMyType option
        }

    module Create'CountryOptionsMy =
        let create
            (
                ``type``: Create'CountryOptionsMyType option
            ) : Create'CountryOptionsMy
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsNgType = | Simplified

    type Create'CountryOptionsNg =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsNgType option
        }

    module Create'CountryOptionsNg =
        let create
            (
                ``type``: Create'CountryOptionsNgType option
            ) : Create'CountryOptionsNg
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsNlStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsNlStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsNlStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsNlStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsNlStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsNlStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsNlType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsNl =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsNlStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsNlType option
        }

    module Create'CountryOptionsNl =
        let create
            (
                standard: Create'CountryOptionsNlStandard option,
                ``type``: Create'CountryOptionsNlType option
            ) : Create'CountryOptionsNl
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsNoStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsNoStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsNoStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsNoStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsNoStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsNoStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsNoType = | Standard

    type Create'CountryOptionsNo =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsNoStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsNoType option
        }

    module Create'CountryOptionsNo =
        let create
            (
                standard: Create'CountryOptionsNoStandard option,
                ``type``: Create'CountryOptionsNoType option
            ) : Create'CountryOptionsNo
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsNpType = | Simplified

    type Create'CountryOptionsNp =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsNpType option
        }

    module Create'CountryOptionsNp =
        let create
            (
                ``type``: Create'CountryOptionsNpType option
            ) : Create'CountryOptionsNp
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsNzStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsNzStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsNzStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsNzStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsNzStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsNzStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsNzType = | Standard

    type Create'CountryOptionsNz =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsNzStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsNzType option
        }

    module Create'CountryOptionsNz =
        let create
            (
                standard: Create'CountryOptionsNzStandard option,
                ``type``: Create'CountryOptionsNzType option
            ) : Create'CountryOptionsNz
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsOmStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsOmStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsOmStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsOmStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsOmStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsOmStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsOmType = | Standard

    type Create'CountryOptionsOm =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsOmStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsOmType option
        }

    module Create'CountryOptionsOm =
        let create
            (
                standard: Create'CountryOptionsOmStandard option,
                ``type``: Create'CountryOptionsOmType option
            ) : Create'CountryOptionsOm
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsPeType = | Simplified

    type Create'CountryOptionsPe =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsPeType option
        }

    module Create'CountryOptionsPe =
        let create
            (
                ``type``: Create'CountryOptionsPeType option
            ) : Create'CountryOptionsPe
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsPhType = | Simplified

    type Create'CountryOptionsPh =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsPhType option
        }

    module Create'CountryOptionsPh =
        let create
            (
                ``type``: Create'CountryOptionsPhType option
            ) : Create'CountryOptionsPh
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsPlStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsPlStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsPlStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsPlStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsPlStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsPlStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsPlType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsPl =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsPlStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsPlType option
        }

    module Create'CountryOptionsPl =
        let create
            (
                standard: Create'CountryOptionsPlStandard option,
                ``type``: Create'CountryOptionsPlType option
            ) : Create'CountryOptionsPl
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsPtStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsPtStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsPtStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsPtStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsPtStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsPtStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsPtType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsPt =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsPtStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsPtType option
        }

    module Create'CountryOptionsPt =
        let create
            (
                standard: Create'CountryOptionsPtStandard option,
                ``type``: Create'CountryOptionsPtType option
            ) : Create'CountryOptionsPt
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsRoStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsRoStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsRoStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsRoStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsRoStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsRoStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsRoType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsRo =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsRoStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsRoType option
        }

    module Create'CountryOptionsRo =
        let create
            (
                standard: Create'CountryOptionsRoStandard option,
                ``type``: Create'CountryOptionsRoType option
            ) : Create'CountryOptionsRo
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsRsStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsRsStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsRsStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsRsStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsRsStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsRsStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsRsType = | Standard

    type Create'CountryOptionsRs =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsRsStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsRsType option
        }

    module Create'CountryOptionsRs =
        let create
            (
                standard: Create'CountryOptionsRsStandard option,
                ``type``: Create'CountryOptionsRsType option
            ) : Create'CountryOptionsRs
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsRuType = | Simplified

    type Create'CountryOptionsRu =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsRuType option
        }

    module Create'CountryOptionsRu =
        let create
            (
                ``type``: Create'CountryOptionsRuType option
            ) : Create'CountryOptionsRu
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsSaType = | Simplified

    type Create'CountryOptionsSa =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsSaType option
        }

    module Create'CountryOptionsSa =
        let create
            (
                ``type``: Create'CountryOptionsSaType option
            ) : Create'CountryOptionsSa
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsSeStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsSeStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsSeStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsSeStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsSeStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsSeStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsSeType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsSe =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsSeStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsSeType option
        }

    module Create'CountryOptionsSe =
        let create
            (
                standard: Create'CountryOptionsSeStandard option,
                ``type``: Create'CountryOptionsSeType option
            ) : Create'CountryOptionsSe
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsSgStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsSgStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsSgStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsSgStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsSgStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsSgStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsSgType = | Standard

    type Create'CountryOptionsSg =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsSgStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsSgType option
        }

    module Create'CountryOptionsSg =
        let create
            (
                standard: Create'CountryOptionsSgStandard option,
                ``type``: Create'CountryOptionsSgType option
            ) : Create'CountryOptionsSg
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsSiStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsSiStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsSiStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsSiStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsSiStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsSiStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsSiType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsSi =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsSiStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsSiType option
        }

    module Create'CountryOptionsSi =
        let create
            (
                standard: Create'CountryOptionsSiStandard option,
                ``type``: Create'CountryOptionsSiType option
            ) : Create'CountryOptionsSi
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsSkStandardPlaceOfSupplyScheme =
        | InboundGoods
        | SmallSeller
        | Standard

    type Create'CountryOptionsSkStandard =
        {
            /// Place of supply scheme used in an EU standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsSkStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsSkStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsSkStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsSkStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsSkType =
        | Ioss
        | OssNonUnion
        | OssUnion
        | Standard

    type Create'CountryOptionsSk =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsSkStandard option
            /// Type of registration to be created in an EU country.
            [<Config.Form>]
            Type: Create'CountryOptionsSkType option
        }

    module Create'CountryOptionsSk =
        let create
            (
                standard: Create'CountryOptionsSkStandard option,
                ``type``: Create'CountryOptionsSkType option
            ) : Create'CountryOptionsSk
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsSnType = | Simplified

    type Create'CountryOptionsSn =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsSnType option
        }

    module Create'CountryOptionsSn =
        let create
            (
                ``type``: Create'CountryOptionsSnType option
            ) : Create'CountryOptionsSn
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsSrStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsSrStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsSrStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsSrStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsSrStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsSrStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsSrType = | Standard

    type Create'CountryOptionsSr =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsSrStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsSrType option
        }

    module Create'CountryOptionsSr =
        let create
            (
                standard: Create'CountryOptionsSrStandard option,
                ``type``: Create'CountryOptionsSrType option
            ) : Create'CountryOptionsSr
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsThType = | Simplified

    type Create'CountryOptionsTh =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsThType option
        }

    module Create'CountryOptionsTh =
        let create
            (
                ``type``: Create'CountryOptionsThType option
            ) : Create'CountryOptionsTh
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsTjType = | Simplified

    type Create'CountryOptionsTj =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsTjType option
        }

    module Create'CountryOptionsTj =
        let create
            (
                ``type``: Create'CountryOptionsTjType option
            ) : Create'CountryOptionsTj
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsTrType = | Simplified

    type Create'CountryOptionsTr =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsTrType option
        }

    module Create'CountryOptionsTr =
        let create
            (
                ``type``: Create'CountryOptionsTrType option
            ) : Create'CountryOptionsTr
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsTwType = | Simplified

    type Create'CountryOptionsTw =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsTwType option
        }

    module Create'CountryOptionsTw =
        let create
            (
                ``type``: Create'CountryOptionsTwType option
            ) : Create'CountryOptionsTw
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsTzType = | Simplified

    type Create'CountryOptionsTz =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsTzType option
        }

    module Create'CountryOptionsTz =
        let create
            (
                ``type``: Create'CountryOptionsTzType option
            ) : Create'CountryOptionsTz
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsUaType = | Simplified

    type Create'CountryOptionsUa =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsUaType option
        }

    module Create'CountryOptionsUa =
        let create
            (
                ``type``: Create'CountryOptionsUaType option
            ) : Create'CountryOptionsUa
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsUgType = | Simplified

    type Create'CountryOptionsUg =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsUgType option
        }

    module Create'CountryOptionsUg =
        let create
            (
                ``type``: Create'CountryOptionsUgType option
            ) : Create'CountryOptionsUg
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsUsLocalAmusementTax =
        {
            /// A jurisdiction code representing the [local jurisdiction](/tax/registering?type=amusement_tax#registration-types).
            [<Config.Form>]
            Jurisdiction: string option
        }

    module Create'CountryOptionsUsLocalAmusementTax =
        let create
            (
                jurisdiction: string option
            ) : Create'CountryOptionsUsLocalAmusementTax
            =
            {
              Jurisdiction = jurisdiction
            }

    type Create'CountryOptionsUsLocalLeaseTax =
        {
            /// A [FIPS code](https://www.census.gov/library/reference/code-lists/ansi.html) representing the local jurisdiction. Supported FIPS codes are: `14000` (Chicago).
            [<Config.Form>]
            Jurisdiction: string option
        }

    module Create'CountryOptionsUsLocalLeaseTax =
        let create
            (
                jurisdiction: string option
            ) : Create'CountryOptionsUsLocalLeaseTax
            =
            {
              Jurisdiction = jurisdiction
            }

    type Create'CountryOptionsUsStateSalesTaxElectionsType =
        | LocalUseTax
        | SimplifiedSellersUseTax
        | SingleLocalUseTax

    type Create'CountryOptionsUsStateSalesTaxElections =
        {
            /// A [FIPS code](https://www.census.gov/library/reference/code-lists/ansi.html) representing the local jurisdiction. Supported FIPS codes are: `003` (Allegheny County) and `60000` (Philadelphia City).
            [<Config.Form>]
            Jurisdiction: string option
            /// The type of the election for the state sales tax registration.
            [<Config.Form>]
            Type: Create'CountryOptionsUsStateSalesTaxElectionsType option
        }

    module Create'CountryOptionsUsStateSalesTaxElections =
        let create
            (
                jurisdiction: string option,
                ``type``: Create'CountryOptionsUsStateSalesTaxElectionsType option
            ) : Create'CountryOptionsUsStateSalesTaxElections
            =
            {
              Jurisdiction = jurisdiction
              Type = ``type``
            }

    type Create'CountryOptionsUsStateSalesTax =
        {
            /// Elections for the state sales tax registration.
            [<Config.Form>]
            Elections: Create'CountryOptionsUsStateSalesTaxElections list option
        }

    module Create'CountryOptionsUsStateSalesTax =
        let create
            (
                elections: Create'CountryOptionsUsStateSalesTaxElections list option
            ) : Create'CountryOptionsUsStateSalesTax
            =
            {
              Elections = elections
            }

    type Create'CountryOptionsUsType =
        | LocalAmusementTax
        | LocalLeaseTax
        | StateCommunicationsTax
        | StateRetailDeliveryFee
        | StateSalesTax

    type Create'CountryOptionsUs =
        {
            /// Options for the local amusement tax registration.
            [<Config.Form>]
            LocalAmusementTax: Create'CountryOptionsUsLocalAmusementTax option
            /// Options for the local lease tax registration.
            [<Config.Form>]
            LocalLeaseTax: Create'CountryOptionsUsLocalLeaseTax option
            /// Two-letter US state code ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
            [<Config.Form>]
            State: string option
            /// Options for the state sales tax registration.
            [<Config.Form>]
            StateSalesTax: Create'CountryOptionsUsStateSalesTax option
            /// Type of registration to be created in the US.
            [<Config.Form>]
            Type: Create'CountryOptionsUsType option
        }

    module Create'CountryOptionsUs =
        let create
            (
                localAmusementTax: Create'CountryOptionsUsLocalAmusementTax option,
                localLeaseTax: Create'CountryOptionsUsLocalLeaseTax option,
                state: string option,
                stateSalesTax: Create'CountryOptionsUsStateSalesTax option,
                ``type``: Create'CountryOptionsUsType option
            ) : Create'CountryOptionsUs
            =
            {
              LocalAmusementTax = localAmusementTax
              LocalLeaseTax = localLeaseTax
              State = state
              StateSalesTax = stateSalesTax
              Type = ``type``
            }

    type Create'CountryOptionsUyStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsUyStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsUyStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsUyStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsUyStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsUyStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsUyType = | Standard

    type Create'CountryOptionsUy =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsUyStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsUyType option
        }

    module Create'CountryOptionsUy =
        let create
            (
                standard: Create'CountryOptionsUyStandard option,
                ``type``: Create'CountryOptionsUyType option
            ) : Create'CountryOptionsUy
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsUzType = | Simplified

    type Create'CountryOptionsUz =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsUzType option
        }

    module Create'CountryOptionsUz =
        let create
            (
                ``type``: Create'CountryOptionsUzType option
            ) : Create'CountryOptionsUz
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsVnType = | Simplified

    type Create'CountryOptionsVn =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsVnType option
        }

    module Create'CountryOptionsVn =
        let create
            (
                ``type``: Create'CountryOptionsVnType option
            ) : Create'CountryOptionsVn
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsZaStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsZaStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsZaStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsZaStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsZaStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsZaStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsZaType = | Standard

    type Create'CountryOptionsZa =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsZaStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsZaType option
        }

    module Create'CountryOptionsZa =
        let create
            (
                standard: Create'CountryOptionsZaStandard option,
                ``type``: Create'CountryOptionsZaType option
            ) : Create'CountryOptionsZa
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptionsZmType = | Simplified

    type Create'CountryOptionsZm =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsZmType option
        }

    module Create'CountryOptionsZm =
        let create
            (
                ``type``: Create'CountryOptionsZmType option
            ) : Create'CountryOptionsZm
            =
            {
              Type = ``type``
            }

    type Create'CountryOptionsZwStandardPlaceOfSupplyScheme =
        | InboundGoods
        | Standard

    type Create'CountryOptionsZwStandard =
        {
            /// Place of supply scheme used in an standard registration.
            [<Config.Form>]
            PlaceOfSupplyScheme: Create'CountryOptionsZwStandardPlaceOfSupplyScheme option
        }

    module Create'CountryOptionsZwStandard =
        let create
            (
                placeOfSupplyScheme: Create'CountryOptionsZwStandardPlaceOfSupplyScheme option
            ) : Create'CountryOptionsZwStandard
            =
            {
              PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsZwType = | Standard

    type Create'CountryOptionsZw =
        {
            /// Options for the standard registration.
            [<Config.Form>]
            Standard: Create'CountryOptionsZwStandard option
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsZwType option
        }

    module Create'CountryOptionsZw =
        let create
            (
                standard: Create'CountryOptionsZwStandard option,
                ``type``: Create'CountryOptionsZwType option
            ) : Create'CountryOptionsZw
            =
            {
              Standard = standard
              Type = ``type``
            }

    type Create'CountryOptions =
        {
            /// Options for the registration in AE.
            [<Config.Form>]
            Ae: Create'CountryOptionsAe option
            /// Options for the registration in AL.
            [<Config.Form>]
            Al: Create'CountryOptionsAl option
            /// Options for the registration in AM.
            [<Config.Form>]
            Am: Create'CountryOptionsAm option
            /// Options for the registration in AO.
            [<Config.Form>]
            Ao: Create'CountryOptionsAo option
            /// Options for the registration in AT.
            [<Config.Form>]
            At: Create'CountryOptionsAt option
            /// Options for the registration in AU.
            [<Config.Form>]
            Au: Create'CountryOptionsAu option
            /// Options for the registration in AW.
            [<Config.Form>]
            Aw: Create'CountryOptionsAw option
            /// Options for the registration in AZ.
            [<Config.Form>]
            Az: Create'CountryOptionsAz option
            /// Options for the registration in BA.
            [<Config.Form>]
            Ba: Create'CountryOptionsBa option
            /// Options for the registration in BB.
            [<Config.Form>]
            Bb: Create'CountryOptionsBb option
            /// Options for the registration in BD.
            [<Config.Form>]
            Bd: Create'CountryOptionsBd option
            /// Options for the registration in BE.
            [<Config.Form>]
            Be: Create'CountryOptionsBe option
            /// Options for the registration in BF.
            [<Config.Form>]
            Bf: Create'CountryOptionsBf option
            /// Options for the registration in BG.
            [<Config.Form>]
            Bg: Create'CountryOptionsBg option
            /// Options for the registration in BH.
            [<Config.Form>]
            Bh: Create'CountryOptionsBh option
            /// Options for the registration in BJ.
            [<Config.Form>]
            Bj: Create'CountryOptionsBj option
            /// Options for the registration in BS.
            [<Config.Form>]
            Bs: Create'CountryOptionsBs option
            /// Options for the registration in BY.
            [<Config.Form>]
            By: Create'CountryOptionsBy option
            /// Options for the registration in CA.
            [<Config.Form>]
            Ca: Create'CountryOptionsCa option
            /// Options for the registration in CD.
            [<Config.Form>]
            Cd: Create'CountryOptionsCd option
            /// Options for the registration in CH.
            [<Config.Form>]
            Ch: Create'CountryOptionsCh option
            /// Options for the registration in CL.
            [<Config.Form>]
            Cl: Create'CountryOptionsCl option
            /// Options for the registration in CM.
            [<Config.Form>]
            Cm: Create'CountryOptionsCm option
            /// Options for the registration in CO.
            [<Config.Form>]
            Co: Create'CountryOptionsCo option
            /// Options for the registration in CR.
            [<Config.Form>]
            Cr: Create'CountryOptionsCr option
            /// Options for the registration in CV.
            [<Config.Form>]
            Cv: Create'CountryOptionsCv option
            /// Options for the registration in CY.
            [<Config.Form>]
            Cy: Create'CountryOptionsCy option
            /// Options for the registration in CZ.
            [<Config.Form>]
            Cz: Create'CountryOptionsCz option
            /// Options for the registration in DE.
            [<Config.Form>]
            De: Create'CountryOptionsDe option
            /// Options for the registration in DK.
            [<Config.Form>]
            Dk: Create'CountryOptionsDk option
            /// Options for the registration in EC.
            [<Config.Form>]
            Ec: Create'CountryOptionsEc option
            /// Options for the registration in EE.
            [<Config.Form>]
            Ee: Create'CountryOptionsEe option
            /// Options for the registration in EG.
            [<Config.Form>]
            Eg: Create'CountryOptionsEg option
            /// Options for the registration in ES.
            [<Config.Form>]
            Es: Create'CountryOptionsEs option
            /// Options for the registration in ET.
            [<Config.Form>]
            Et: Create'CountryOptionsEt option
            /// Options for the registration in FI.
            [<Config.Form>]
            Fi: Create'CountryOptionsFi option
            /// Options for the registration in FR.
            [<Config.Form>]
            Fr: Create'CountryOptionsFr option
            /// Options for the registration in GB.
            [<Config.Form>]
            Gb: Create'CountryOptionsGb option
            /// Options for the registration in GE.
            [<Config.Form>]
            Ge: Create'CountryOptionsGe option
            /// Options for the registration in GN.
            [<Config.Form>]
            Gn: Create'CountryOptionsGn option
            /// Options for the registration in GR.
            [<Config.Form>]
            Gr: Create'CountryOptionsGr option
            /// Options for the registration in HR.
            [<Config.Form>]
            Hr: Create'CountryOptionsHr option
            /// Options for the registration in HU.
            [<Config.Form>]
            Hu: Create'CountryOptionsHu option
            /// Options for the registration in ID.
            [<Config.Form>]
            Id: Create'CountryOptionsId option
            /// Options for the registration in IE.
            [<Config.Form>]
            Ie: Create'CountryOptionsIe option
            /// Options for the registration in IN.
            [<Config.Form>]
            In: Create'CountryOptionsIn option
            /// Options for the registration in IS.
            [<Config.Form>]
            Is: Create'CountryOptionsIs option
            /// Options for the registration in IT.
            [<Config.Form>]
            It: Create'CountryOptionsIt option
            /// Options for the registration in JP.
            [<Config.Form>]
            Jp: Create'CountryOptionsJp option
            /// Options for the registration in KE.
            [<Config.Form>]
            Ke: Create'CountryOptionsKe option
            /// Options for the registration in KG.
            [<Config.Form>]
            Kg: Create'CountryOptionsKg option
            /// Options for the registration in KH.
            [<Config.Form>]
            Kh: Create'CountryOptionsKh option
            /// Options for the registration in KR.
            [<Config.Form>]
            Kr: Create'CountryOptionsKr option
            /// Options for the registration in KZ.
            [<Config.Form>]
            Kz: Create'CountryOptionsKz option
            /// Options for the registration in LA.
            [<Config.Form>]
            La: Create'CountryOptionsLa option
            /// Options for the registration in LK.
            [<Config.Form>]
            Lk: Create'CountryOptionsLk option
            /// Options for the registration in LT.
            [<Config.Form>]
            Lt: Create'CountryOptionsLt option
            /// Options for the registration in LU.
            [<Config.Form>]
            Lu: Create'CountryOptionsLu option
            /// Options for the registration in LV.
            [<Config.Form>]
            Lv: Create'CountryOptionsLv option
            /// Options for the registration in MA.
            [<Config.Form>]
            Ma: Create'CountryOptionsMa option
            /// Options for the registration in MD.
            [<Config.Form>]
            Md: Create'CountryOptionsMd option
            /// Options for the registration in ME.
            [<Config.Form>]
            Me: Create'CountryOptionsMe option
            /// Options for the registration in MK.
            [<Config.Form>]
            Mk: Create'CountryOptionsMk option
            /// Options for the registration in MR.
            [<Config.Form>]
            Mr: Create'CountryOptionsMr option
            /// Options for the registration in MT.
            [<Config.Form>]
            Mt: Create'CountryOptionsMt option
            /// Options for the registration in MX.
            [<Config.Form>]
            Mx: Create'CountryOptionsMx option
            /// Options for the registration in MY.
            [<Config.Form>]
            My: Create'CountryOptionsMy option
            /// Options for the registration in NG.
            [<Config.Form>]
            Ng: Create'CountryOptionsNg option
            /// Options for the registration in NL.
            [<Config.Form>]
            Nl: Create'CountryOptionsNl option
            /// Options for the registration in NO.
            [<Config.Form>]
            No: Create'CountryOptionsNo option
            /// Options for the registration in NP.
            [<Config.Form>]
            Np: Create'CountryOptionsNp option
            /// Options for the registration in NZ.
            [<Config.Form>]
            Nz: Create'CountryOptionsNz option
            /// Options for the registration in OM.
            [<Config.Form>]
            Om: Create'CountryOptionsOm option
            /// Options for the registration in PE.
            [<Config.Form>]
            Pe: Create'CountryOptionsPe option
            /// Options for the registration in PH.
            [<Config.Form>]
            Ph: Create'CountryOptionsPh option
            /// Options for the registration in PL.
            [<Config.Form>]
            Pl: Create'CountryOptionsPl option
            /// Options for the registration in PT.
            [<Config.Form>]
            Pt: Create'CountryOptionsPt option
            /// Options for the registration in RO.
            [<Config.Form>]
            Ro: Create'CountryOptionsRo option
            /// Options for the registration in RS.
            [<Config.Form>]
            Rs: Create'CountryOptionsRs option
            /// Options for the registration in RU.
            [<Config.Form>]
            Ru: Create'CountryOptionsRu option
            /// Options for the registration in SA.
            [<Config.Form>]
            Sa: Create'CountryOptionsSa option
            /// Options for the registration in SE.
            [<Config.Form>]
            Se: Create'CountryOptionsSe option
            /// Options for the registration in SG.
            [<Config.Form>]
            Sg: Create'CountryOptionsSg option
            /// Options for the registration in SI.
            [<Config.Form>]
            Si: Create'CountryOptionsSi option
            /// Options for the registration in SK.
            [<Config.Form>]
            Sk: Create'CountryOptionsSk option
            /// Options for the registration in SN.
            [<Config.Form>]
            Sn: Create'CountryOptionsSn option
            /// Options for the registration in SR.
            [<Config.Form>]
            Sr: Create'CountryOptionsSr option
            /// Options for the registration in TH.
            [<Config.Form>]
            Th: Create'CountryOptionsTh option
            /// Options for the registration in TJ.
            [<Config.Form>]
            Tj: Create'CountryOptionsTj option
            /// Options for the registration in TR.
            [<Config.Form>]
            Tr: Create'CountryOptionsTr option
            /// Options for the registration in TW.
            [<Config.Form>]
            Tw: Create'CountryOptionsTw option
            /// Options for the registration in TZ.
            [<Config.Form>]
            Tz: Create'CountryOptionsTz option
            /// Options for the registration in UA.
            [<Config.Form>]
            Ua: Create'CountryOptionsUa option
            /// Options for the registration in UG.
            [<Config.Form>]
            Ug: Create'CountryOptionsUg option
            /// Options for the registration in US.
            [<Config.Form>]
            Us: Create'CountryOptionsUs option
            /// Options for the registration in UY.
            [<Config.Form>]
            Uy: Create'CountryOptionsUy option
            /// Options for the registration in UZ.
            [<Config.Form>]
            Uz: Create'CountryOptionsUz option
            /// Options for the registration in VN.
            [<Config.Form>]
            Vn: Create'CountryOptionsVn option
            /// Options for the registration in ZA.
            [<Config.Form>]
            Za: Create'CountryOptionsZa option
            /// Options for the registration in ZM.
            [<Config.Form>]
            Zm: Create'CountryOptionsZm option
            /// Options for the registration in ZW.
            [<Config.Form>]
            Zw: Create'CountryOptionsZw option
        }

    module Create'CountryOptions =
        let create
            (
                ae: Create'CountryOptionsAe option,
                al: Create'CountryOptionsAl option,
                am: Create'CountryOptionsAm option,
                ao: Create'CountryOptionsAo option,
                at: Create'CountryOptionsAt option,
                au: Create'CountryOptionsAu option,
                aw: Create'CountryOptionsAw option,
                az: Create'CountryOptionsAz option,
                ba: Create'CountryOptionsBa option,
                bb: Create'CountryOptionsBb option,
                bd: Create'CountryOptionsBd option,
                be: Create'CountryOptionsBe option,
                bf: Create'CountryOptionsBf option,
                bg: Create'CountryOptionsBg option,
                bh: Create'CountryOptionsBh option,
                bj: Create'CountryOptionsBj option,
                bs: Create'CountryOptionsBs option,
                by: Create'CountryOptionsBy option,
                ca: Create'CountryOptionsCa option,
                cd: Create'CountryOptionsCd option,
                ch: Create'CountryOptionsCh option,
                cl: Create'CountryOptionsCl option,
                cm: Create'CountryOptionsCm option,
                co: Create'CountryOptionsCo option,
                cr: Create'CountryOptionsCr option,
                cv: Create'CountryOptionsCv option,
                cy: Create'CountryOptionsCy option,
                cz: Create'CountryOptionsCz option,
                de: Create'CountryOptionsDe option,
                dk: Create'CountryOptionsDk option,
                ec: Create'CountryOptionsEc option,
                ee: Create'CountryOptionsEe option,
                eg: Create'CountryOptionsEg option,
                es: Create'CountryOptionsEs option,
                et: Create'CountryOptionsEt option,
                fi: Create'CountryOptionsFi option,
                fr: Create'CountryOptionsFr option,
                gb: Create'CountryOptionsGb option,
                ge: Create'CountryOptionsGe option,
                gn: Create'CountryOptionsGn option,
                gr: Create'CountryOptionsGr option,
                hr: Create'CountryOptionsHr option,
                hu: Create'CountryOptionsHu option,
                id: Create'CountryOptionsId option,
                ie: Create'CountryOptionsIe option,
                ``in``: Create'CountryOptionsIn option,
                is: Create'CountryOptionsIs option,
                it: Create'CountryOptionsIt option,
                jp: Create'CountryOptionsJp option,
                ke: Create'CountryOptionsKe option,
                kg: Create'CountryOptionsKg option,
                kh: Create'CountryOptionsKh option,
                kr: Create'CountryOptionsKr option,
                kz: Create'CountryOptionsKz option,
                la: Create'CountryOptionsLa option,
                lk: Create'CountryOptionsLk option,
                lt: Create'CountryOptionsLt option,
                lu: Create'CountryOptionsLu option,
                lv: Create'CountryOptionsLv option,
                ma: Create'CountryOptionsMa option,
                md: Create'CountryOptionsMd option,
                me: Create'CountryOptionsMe option,
                mk: Create'CountryOptionsMk option,
                mr: Create'CountryOptionsMr option,
                mt: Create'CountryOptionsMt option,
                mx: Create'CountryOptionsMx option,
                my: Create'CountryOptionsMy option,
                ng: Create'CountryOptionsNg option,
                nl: Create'CountryOptionsNl option,
                no: Create'CountryOptionsNo option,
                np: Create'CountryOptionsNp option,
                nz: Create'CountryOptionsNz option,
                om: Create'CountryOptionsOm option,
                pe: Create'CountryOptionsPe option,
                ph: Create'CountryOptionsPh option,
                pl: Create'CountryOptionsPl option,
                pt: Create'CountryOptionsPt option,
                ro: Create'CountryOptionsRo option,
                rs: Create'CountryOptionsRs option,
                ru: Create'CountryOptionsRu option,
                sa: Create'CountryOptionsSa option,
                se: Create'CountryOptionsSe option,
                sg: Create'CountryOptionsSg option,
                si: Create'CountryOptionsSi option,
                sk: Create'CountryOptionsSk option,
                sn: Create'CountryOptionsSn option,
                sr: Create'CountryOptionsSr option,
                th: Create'CountryOptionsTh option,
                tj: Create'CountryOptionsTj option,
                tr: Create'CountryOptionsTr option,
                tw: Create'CountryOptionsTw option,
                tz: Create'CountryOptionsTz option,
                ua: Create'CountryOptionsUa option,
                ug: Create'CountryOptionsUg option,
                us: Create'CountryOptionsUs option,
                uy: Create'CountryOptionsUy option,
                uz: Create'CountryOptionsUz option,
                vn: Create'CountryOptionsVn option,
                za: Create'CountryOptionsZa option,
                zm: Create'CountryOptionsZm option,
                zw: Create'CountryOptionsZw option
            ) : Create'CountryOptions
            =
            {
              Ae = ae
              Al = al
              Am = am
              Ao = ao
              At = at
              Au = au
              Aw = aw
              Az = az
              Ba = ba
              Bb = bb
              Bd = bd
              Be = be
              Bf = bf
              Bg = bg
              Bh = bh
              Bj = bj
              Bs = bs
              By = by
              Ca = ca
              Cd = cd
              Ch = ch
              Cl = cl
              Cm = cm
              Co = co
              Cr = cr
              Cv = cv
              Cy = cy
              Cz = cz
              De = de
              Dk = dk
              Ec = ec
              Ee = ee
              Eg = eg
              Es = es
              Et = et
              Fi = fi
              Fr = fr
              Gb = gb
              Ge = ge
              Gn = gn
              Gr = gr
              Hr = hr
              Hu = hu
              Id = id
              Ie = ie
              In = ``in``
              Is = is
              It = it
              Jp = jp
              Ke = ke
              Kg = kg
              Kh = kh
              Kr = kr
              Kz = kz
              La = la
              Lk = lk
              Lt = lt
              Lu = lu
              Lv = lv
              Ma = ma
              Md = md
              Me = me
              Mk = mk
              Mr = mr
              Mt = mt
              Mx = mx
              My = my
              Ng = ng
              Nl = nl
              No = no
              Np = np
              Nz = nz
              Om = om
              Pe = pe
              Ph = ph
              Pl = pl
              Pt = pt
              Ro = ro
              Rs = rs
              Ru = ru
              Sa = sa
              Se = se
              Sg = sg
              Si = si
              Sk = sk
              Sn = sn
              Sr = sr
              Th = th
              Tj = tj
              Tr = tr
              Tw = tw
              Tz = tz
              Ua = ua
              Ug = ug
              Us = us
              Uy = uy
              Uz = uz
              Vn = vn
              Za = za
              Zm = zm
              Zw = zw
            }

    type CreateOptions =
        {
            /// Time at which the Tax Registration becomes active. It can be either `now` to indicate the current time, or a future timestamp measured in seconds since the Unix epoch.
            [<Config.Form>]
            ActiveFrom: Choice<Create'ActiveFrom,DateTime>
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode
            /// Specific options for a registration in the specified `country`.
            [<Config.Form>]
            CountryOptions: Create'CountryOptions
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// If set, the Tax Registration stops being active at this time. If not set, the Tax Registration will be active indefinitely. Timestamp measured in seconds since the Unix epoch.
            [<Config.Form>]
            ExpiresAt: DateTime option
        }

    module CreateOptions =
        let create
            (
                activeFrom: Choice<Create'ActiveFrom,DateTime>,
                country: IsoTypes.IsoCountryCode,
                countryOptions: Create'CountryOptions,
                expand: string list option,
                expiresAt: DateTime option
            ) : CreateOptions
            =
            {
              ActiveFrom = activeFrom
              Country = country
              CountryOptions = countryOptions
              Expand = expand
              ExpiresAt = expiresAt
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

    type Update'ActiveFrom = | Now

    type Update'ExpiresAt = | Now

    type UpdateOptions =
        {
            [<Config.Path>]
            Id: string
            /// Time at which the registration becomes active. It can be either `now` to indicate the current time, or a timestamp measured in seconds since the Unix epoch.
            [<Config.Form>]
            ActiveFrom: Choice<Update'ActiveFrom,DateTime> option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// If set, the registration stops being active at this time. If not set, the registration will be active indefinitely. It can be either `now` to indicate the current time, or a timestamp measured in seconds since the Unix epoch.
            [<Config.Form>]
            ExpiresAt: Choice<Update'ExpiresAt,DateTime,string> option
        }

    module UpdateOptions =
        let create
            (
                id: string,
                activeFrom: Choice<Update'ActiveFrom,DateTime> option,
                expand: string list option,
                expiresAt: Choice<Update'ExpiresAt,DateTime,string> option
            ) : UpdateOptions
            =
            {
              Id = id
              ActiveFrom = activeFrom
              Expand = expand
              ExpiresAt = expiresAt
            }

    ///<p>Returns a list of Tax <code>Registration</code> objects.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/tax/registrations"
        |> RestApi.getAsync<StripeList<TaxRegistration>> settings qs

    ///<p>Creates a new Tax <code>Registration</code> object.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/tax/registrations"
        |> RestApi.postAsync<_, TaxRegistration> settings (Map.empty) options

    ///<p>Returns a Tax <code>Registration</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/tax/registrations/{options.Id}"
        |> RestApi.getAsync<TaxRegistration> settings qs

    ///<p>Updates an existing Tax <code>Registration</code> object.</p>
    ///<p>A registration cannot be deleted after it has been created. If you wish to end a registration you may do so by setting <code>expires_at</code>.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/tax/registrations/{options.Id}"
        |> RestApi.postAsync<_, TaxRegistration> settings (Map.empty) options

module TaxSettings =

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    module RetrieveOptions =
        let create
            (
                expand: string list option
            ) : RetrieveOptions
            =
            {
              Expand = expand
            }

    type Update'DefaultsTaxBehavior =
        | Exclusive
        | Inclusive
        | InferredByCurrency

    type Update'Defaults =
        {
            /// Specifies the default [tax behavior](https://stripe.com/docs/tax/products-prices-tax-categories-tax-behavior#tax-behavior) to be used when the item's price has unspecified tax behavior. One of inclusive, exclusive, or inferred_by_currency. Once specified, it cannot be changed back to null.
            [<Config.Form>]
            TaxBehavior: Update'DefaultsTaxBehavior option
            /// A [tax code](https://docs.stripe.com/tax/tax-categories) ID.
            [<Config.Form>]
            TaxCode: string option
        }

    module Update'Defaults =
        let create
            (
                taxBehavior: Update'DefaultsTaxBehavior option,
                taxCode: string option
            ) : Update'Defaults
            =
            {
              TaxBehavior = taxBehavior
              TaxCode = taxCode
            }

    type Update'HeadOfficeAddress =
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
            /// State/province as an [ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2) subdivision code, without country prefix, such as "NY" or "TX".
            [<Config.Form>]
            State: string option
        }

    module Update'HeadOfficeAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Update'HeadOfficeAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Update'HeadOffice =
        {
            /// The location of the business for tax purposes.
            [<Config.Form>]
            Address: Update'HeadOfficeAddress option
        }

    module Update'HeadOffice =
        let create
            (
                address: Update'HeadOfficeAddress option
            ) : Update'HeadOffice
            =
            {
              Address = address
            }

    type UpdateOptions =
        {
            /// Default configuration to be used on Stripe Tax calculations.
            [<Config.Form>]
            Defaults: Update'Defaults option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The place where your business is located.
            [<Config.Form>]
            HeadOffice: Update'HeadOffice option
        }

    module UpdateOptions =
        let create
            (
                defaults: Update'Defaults option,
                expand: string list option,
                headOffice: Update'HeadOffice option
            ) : UpdateOptions
            =
            {
              Defaults = defaults
              Expand = expand
              HeadOffice = headOffice
            }

    ///<p>Retrieves Tax <code>Settings</code> for a merchant.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/tax/settings"
        |> RestApi.getAsync<TaxSettings> settings qs

    ///<p>Updates Tax <code>Settings</code> parameters used in tax calculations. All parameters are editable but none can be removed once set.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/tax/settings"
        |> RestApi.postAsync<_, TaxSettings> settings (Map.empty) options

module TaxTransactionsCreateFromCalculation =

    type CreateFromCalculationOptions =
        {
            /// Tax Calculation ID to be used as input when creating the transaction.
            [<Config.Form>]
            Calculation: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The Unix timestamp representing when the tax liability is assumed or reduced, which determines the liability posting period and handling in tax liability reports. The timestamp must fall within the `tax_date` and the current time, unless the `tax_date` is scheduled in advance. Defaults to the current time.
            [<Config.Form>]
            PostedAt: DateTime option
            /// A custom order or sale identifier, such as 'myOrder_123'. Must be unique across all transactions, including reversals.
            [<Config.Form>]
            Reference: string
        }

    module CreateFromCalculationOptions =
        let create
            (
                calculation: string,
                reference: string,
                expand: string list option,
                metadata: Map<string, string> option,
                postedAt: DateTime option
            ) : CreateFromCalculationOptions
            =
            {
              Calculation = calculation
              Reference = reference
              Expand = expand
              Metadata = metadata
              PostedAt = postedAt
            }

    ///<p>Creates a Tax Transaction from a calculation, if that calculation hasn’t expired. Calculations expire after 90 days.</p>
    let CreateFromCalculation settings (options: CreateFromCalculationOptions) =
        $"/v1/tax/transactions/create_from_calculation"
        |> RestApi.postAsync<_, TaxTransaction> settings (Map.empty) options

module TaxTransactionsCreateReversal =

    type CreateReversal'LineItems =
        {
            /// The amount to reverse, in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units) in negative.
            [<Config.Form>]
            Amount: int option
            /// The amount of tax to reverse, in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units) in negative.
            [<Config.Form>]
            AmountTax: int option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The `id` of the line item to reverse in the original transaction.
            [<Config.Form>]
            OriginalLineItem: string option
            /// The quantity reversed. Appears in [tax exports](https://docs.stripe.com/tax/reports), but does not affect the amount of tax reversed.
            [<Config.Form>]
            Quantity: int option
            /// A custom identifier for this line item in the reversal transaction, such as 'L1-refund'.
            [<Config.Form>]
            Reference: string option
        }

    module CreateReversal'LineItems =
        let create
            (
                amount: int option,
                amountTax: int option,
                metadata: Map<string, string> option,
                originalLineItem: string option,
                quantity: int option,
                reference: string option
            ) : CreateReversal'LineItems
            =
            {
              Amount = amount
              AmountTax = amountTax
              Metadata = metadata
              OriginalLineItem = originalLineItem
              Quantity = quantity
              Reference = reference
            }

    type CreateReversal'Mode =
        | Full
        | Partial

    type CreateReversal'ShippingCost =
        {
            /// The amount to reverse, in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units) in negative.
            [<Config.Form>]
            Amount: int option
            /// The amount of tax to reverse, in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units) in negative.
            [<Config.Form>]
            AmountTax: int option
        }

    module CreateReversal'ShippingCost =
        let create
            (
                amount: int option,
                amountTax: int option
            ) : CreateReversal'ShippingCost
            =
            {
              Amount = amount
              AmountTax = amountTax
            }

    type CreateReversalOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// A flat amount to reverse across the entire transaction, in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units) in negative. This value represents the total amount to refund from the transaction, including taxes.
            [<Config.Form>]
            FlatAmount: int option
            /// The line item amounts to reverse.
            [<Config.Form>]
            LineItems: CreateReversal'LineItems list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// If `partial`, the provided line item or shipping cost amounts are reversed. If `full`, the original transaction is fully reversed.
            [<Config.Form>]
            Mode: CreateReversal'Mode
            /// The ID of the Transaction to partially or fully reverse.
            [<Config.Form>]
            OriginalTransaction: string
            /// A custom identifier for this reversal, such as `myOrder_123-refund_1`, which must be unique across all transactions. The reference helps identify this reversal transaction in exported [tax reports](https://docs.stripe.com/tax/reports).
            [<Config.Form>]
            Reference: string
            /// The shipping cost to reverse.
            [<Config.Form>]
            ShippingCost: CreateReversal'ShippingCost option
        }

    module CreateReversalOptions =
        let create
            (
                mode: CreateReversal'Mode,
                originalTransaction: string,
                reference: string,
                expand: string list option,
                flatAmount: int option,
                lineItems: CreateReversal'LineItems list option,
                metadata: Map<string, string> option,
                shippingCost: CreateReversal'ShippingCost option
            ) : CreateReversalOptions
            =
            {
              Mode = mode
              OriginalTransaction = originalTransaction
              Reference = reference
              Expand = expand
              FlatAmount = flatAmount
              LineItems = lineItems
              Metadata = metadata
              ShippingCost = shippingCost
            }

    ///<p>Partially or fully reverses a previously created <code>Transaction</code>.</p>
    let CreateReversal settings (options: CreateReversalOptions) =
        $"/v1/tax/transactions/create_reversal"
        |> RestApi.postAsync<_, TaxTransaction> settings (Map.empty) options

module TaxTransactions =

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Transaction: string
        }

    module RetrieveOptions =
        let create
            (
                transaction: string,
                expand: string list option
            ) : RetrieveOptions
            =
            {
              Transaction = transaction
              Expand = expand
            }

    ///<p>Retrieves a Tax <code>Transaction</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/tax/transactions/{options.Transaction}"
        |> RestApi.getAsync<TaxTransaction> settings qs

module TaxTransactionsLineItems =

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
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            [<Config.Path>]
            Transaction: string
        }

    module ListLineItemsOptions =
        let create
            (
                transaction: string,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option
            ) : ListLineItemsOptions
            =
            {
              Transaction = transaction
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
            }

    ///<p>Retrieves the line items of a committed standalone transaction as a collection.</p>
    let ListLineItems settings (options: ListLineItemsOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/tax/transactions/{options.Transaction}/line_items"
        |> RestApi.getAsync<StripeList<TaxTransactionLineItem>> settings qs

module TaxCodes =

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
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    module ListOptions =
        let create
            (
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option
            ) : ListOptions
            =
            {
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
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

    ///<p>A list of <a href="https://stripe.com/docs/tax/tax-categories">all tax codes available</a> to add to Products in order to allow specific tax calculations.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/tax_codes"
        |> RestApi.getAsync<StripeList<TaxCode>> settings qs

    ///<p>Retrieves the details of an existing tax code. Supply the unique tax code ID and Stripe will return the corresponding tax code information.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/tax_codes/{options.Id}"
        |> RestApi.getAsync<TaxCode> settings qs

module TaxIds =

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
            /// The account or customer the tax ID belongs to. Defaults to `owner[type]=self`.
            [<Config.Query>]
            Owner: Map<string, string> option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    module ListOptions =
        let create
            (
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                owner: Map<string, string> option,
                startingAfter: string option
            ) : ListOptions
            =
            {
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              Owner = owner
              StartingAfter = startingAfter
            }

    type Create'OwnerType =
        | Account
        | Application
        | Customer
        | Self

    type Create'Owner =
        {
            /// Connected Account the tax ID belongs to. Required when `type=account`
            [<Config.Form>]
            Account: string option
            /// Customer the tax ID belongs to. Required when `type=customer`
            [<Config.Form>]
            Customer: string option
            /// ID of the Account representing the customer that the tax ID belongs to. Can be used in place of `customer` when `type=customer`
            [<Config.Form>]
            CustomerAccount: string option
            /// Type of owner referenced.
            [<Config.Form>]
            Type: Create'OwnerType option
        }

    module Create'Owner =
        let create
            (
                account: string option,
                customer: string option,
                customerAccount: string option,
                ``type``: Create'OwnerType option
            ) : Create'Owner
            =
            {
              Account = account
              Customer = customer
              CustomerAccount = customerAccount
              Type = ``type``
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
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The account or customer the tax ID belongs to. Defaults to `owner[type]=self`.
            [<Config.Form>]
            Owner: Create'Owner option
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
                ``type``: Create'Type,
                value: string,
                expand: string list option,
                owner: Create'Owner option
            ) : CreateOptions
            =
            {
              Type = ``type``
              Value = value
              Expand = expand
              Owner = owner
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

    ///<p>Returns a list of tax IDs.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("owner", options.Owner |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/tax_ids"
        |> RestApi.getAsync<StripeList<TaxId>> settings qs

    ///<p>Creates a new account or customer <code>tax_id</code> object.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/tax_ids"
        |> RestApi.postAsync<_, TaxId> settings (Map.empty) options

    ///<p>Deletes an existing account or customer <code>tax_id</code> object.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/tax_ids/{options.Id}"
        |> RestApi.deleteAsync<DeletedTaxId> settings (Map.empty)

    ///<p>Retrieves an account or customer <code>tax_id</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/tax_ids/{options.Id}"
        |> RestApi.getAsync<TaxId> settings qs

module TaxRates =

    type ListOptions =
        {
            /// Optional flag to filter by tax rates that are either active or inactive (archived).
            [<Config.Query>]
            Active: bool option
            /// Optional range for filtering created date.
            [<Config.Query>]
            Created: int option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// Optional flag to filter by tax rates that are inclusive (or those that are not inclusive).
            [<Config.Query>]
            Inclusive: bool option
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
                active: bool option,
                created: int option,
                endingBefore: string option,
                expand: string list option,
                inclusive: bool option,
                limit: int option,
                startingAfter: string option
            ) : ListOptions
            =
            {
              Active = active
              Created = created
              EndingBefore = endingBefore
              Expand = expand
              Inclusive = inclusive
              Limit = limit
              StartingAfter = startingAfter
            }

    type Create'TaxType =
        | AmusementTax
        | CommunicationsTax
        | Gst
        | Hst
        | Igst
        | Jct
        | LeaseTax
        | Pst
        | Qst
        | RetailDeliveryFee
        | Rst
        | SalesTax
        | ServiceTax
        | Vat

    type CreateOptions =
        {
            /// Flag determining whether the tax rate is active or inactive (archived). Inactive tax rates cannot be used with new applications or Checkout Sessions, but will still work for subscriptions and invoices that already have it set.
            [<Config.Form>]
            Active: bool option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// An arbitrary string attached to the tax rate for your internal use only. It will not be visible to your customers.
            [<Config.Form>]
            Description: string option
            /// The display name of the tax rate, which will be shown to users.
            [<Config.Form>]
            DisplayName: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// This specifies if the tax rate is inclusive or exclusive.
            [<Config.Form>]
            Inclusive: bool
            /// The jurisdiction for the tax rate. You can use this label field for tax reporting purposes. It also appears on your customer’s invoice.
            [<Config.Form>]
            Jurisdiction: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// This represents the tax rate percent out of 100.
            [<Config.Form>]
            Percentage: decimal
            /// [ISO 3166-2 subdivision code](https://en.wikipedia.org/wiki/ISO_3166-2), without country prefix. For example, "NY" for New York, United States.
            [<Config.Form>]
            State: string option
            /// The high-level tax type, such as `vat` or `sales_tax`.
            [<Config.Form>]
            TaxType: Create'TaxType option
        }

    module CreateOptions =
        let create
            (
                displayName: string,
                inclusive: bool,
                percentage: decimal,
                active: bool option,
                country: IsoTypes.IsoCountryCode option,
                description: string option,
                expand: string list option,
                jurisdiction: string option,
                metadata: Map<string, string> option,
                state: string option,
                taxType: Create'TaxType option
            ) : CreateOptions
            =
            {
              DisplayName = displayName
              Inclusive = inclusive
              Percentage = percentage
              Active = active
              Country = country
              Description = description
              Expand = expand
              Jurisdiction = jurisdiction
              Metadata = metadata
              State = state
              TaxType = taxType
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            TaxRate: string
        }

    module RetrieveOptions =
        let create
            (
                taxRate: string,
                expand: string list option
            ) : RetrieveOptions
            =
            {
              TaxRate = taxRate
              Expand = expand
            }

    type Update'TaxType =
        | AmusementTax
        | CommunicationsTax
        | Gst
        | Hst
        | Igst
        | Jct
        | LeaseTax
        | Pst
        | Qst
        | RetailDeliveryFee
        | Rst
        | SalesTax
        | ServiceTax
        | Vat

    type UpdateOptions =
        {
            [<Config.Path>]
            TaxRate: string
            /// Flag determining whether the tax rate is active or inactive (archived). Inactive tax rates cannot be used with new applications or Checkout Sessions, but will still work for subscriptions and invoices that already have it set.
            [<Config.Form>]
            Active: bool option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// An arbitrary string attached to the tax rate for your internal use only. It will not be visible to your customers.
            [<Config.Form>]
            Description: string option
            /// The display name of the tax rate, which will be shown to users.
            [<Config.Form>]
            DisplayName: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The jurisdiction for the tax rate. You can use this label field for tax reporting purposes. It also appears on your customer’s invoice.
            [<Config.Form>]
            Jurisdiction: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// [ISO 3166-2 subdivision code](https://en.wikipedia.org/wiki/ISO_3166-2), without country prefix. For example, "NY" for New York, United States.
            [<Config.Form>]
            State: string option
            /// The high-level tax type, such as `vat` or `sales_tax`.
            [<Config.Form>]
            TaxType: Update'TaxType option
        }

    module UpdateOptions =
        let create
            (
                taxRate: string,
                active: bool option,
                country: IsoTypes.IsoCountryCode option,
                description: string option,
                displayName: string option,
                expand: string list option,
                jurisdiction: string option,
                metadata: Map<string, string> option,
                state: string option,
                taxType: Update'TaxType option
            ) : UpdateOptions
            =
            {
              TaxRate = taxRate
              Active = active
              Country = country
              Description = description
              DisplayName = displayName
              Expand = expand
              Jurisdiction = jurisdiction
              Metadata = metadata
              State = state
              TaxType = taxType
            }

    ///<p>Returns a list of your tax rates. Tax rates are returned sorted by creation date, with the most recently created tax rates appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("active", options.Active |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("inclusive", options.Inclusive |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/tax_rates"
        |> RestApi.getAsync<StripeList<TaxRate>> settings qs

    ///<p>Creates a new tax rate.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/tax_rates"
        |> RestApi.postAsync<_, TaxRate> settings (Map.empty) options

    ///<p>Retrieves a tax rate with the given ID</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/tax_rates/{options.TaxRate}"
        |> RestApi.getAsync<TaxRate> settings qs

    ///<p>Updates an existing tax rate.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/tax_rates/{options.TaxRate}"
        |> RestApi.postAsync<_, TaxRate> settings (Map.empty) options

