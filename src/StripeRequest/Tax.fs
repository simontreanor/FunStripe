namespace StripeRequest.Tax

open FunStripe
open System.Text.Json.Serialization
open Stripe.Tax
open Stripe.TaxCode
open Stripe.TaxId
open Stripe.TaxRate
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
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

    type FindOptions with
        static member New(paymentIntent: string, ?expand: string list) =
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

    type Create'CustomerDetailsAddress with
        static member New(?city: Choice<string,string>, ?country: IsoTypes.IsoCountryCode, ?line1: Choice<string,string>, ?line2: Choice<string,string>, ?postalCode: Choice<string,string>, ?state: Choice<string,string>) =
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

    type Create'CustomerDetailsTaxIds with
        static member New(?type': Create'CustomerDetailsTaxIdsType, ?value: string) =
            {
                Type = type'
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

    type Create'CustomerDetails with
        static member New(?address: Create'CustomerDetailsAddress, ?addressSource: Create'CustomerDetailsAddressSource, ?ipAddress: string, ?taxIds: Create'CustomerDetailsTaxIds list, ?taxabilityOverride: Create'CustomerDetailsTaxabilityOverride) =
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

    type Create'LineItems with
        static member New(?amount: int, ?metadata: Map<string, string>, ?product: string, ?quantity: int, ?reference: string, ?taxBehavior: Create'LineItemsTaxBehavior, ?taxCode: string) =
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

    type Create'ShipFromDetailsAddress with
        static member New(?city: Choice<string,string>, ?country: IsoTypes.IsoCountryCode, ?line1: Choice<string,string>, ?line2: Choice<string,string>, ?postalCode: Choice<string,string>, ?state: Choice<string,string>) =
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

    type Create'ShipFromDetails with
        static member New(?address: Create'ShipFromDetailsAddress) =
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

    type Create'ShippingCost with
        static member New(?amount: int, ?shippingRate: string, ?taxBehavior: Create'ShippingCostTaxBehavior, ?taxCode: string) =
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

    type CreateOptions with
        static member New(currency: IsoTypes.IsoCurrencyCode, lineItems: Create'LineItems list, ?customer: string, ?customerDetails: Create'CustomerDetails, ?expand: string list, ?shipFromDetails: Create'ShipFromDetails, ?shippingCost: Create'ShippingCost, ?taxDate: int) =
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

    type RetrieveOptions with
        static member New(calculation: string, ?expand: string list) =
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

    type ListLineItemsOptions with
        static member New(calculation: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
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

    type ListOptions with
        static member New(?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
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

    type Create'CountryOptionsAeStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsAeStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsAe with
        static member New(?standard: Create'CountryOptionsAeStandard, ?type': Create'CountryOptionsAeType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsAlStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsAlStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsAl with
        static member New(?standard: Create'CountryOptionsAlStandard, ?type': Create'CountryOptionsAlType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsAmType = | Simplified

    type Create'CountryOptionsAm =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsAmType option
        }

    type Create'CountryOptionsAm with
        static member New(?type': Create'CountryOptionsAmType) =
            {
                Type = type'
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

    type Create'CountryOptionsAoStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsAoStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsAo with
        static member New(?standard: Create'CountryOptionsAoStandard, ?type': Create'CountryOptionsAoType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsAtStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsAtStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsAt with
        static member New(?standard: Create'CountryOptionsAtStandard, ?type': Create'CountryOptionsAtType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsAuStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsAuStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsAu with
        static member New(?standard: Create'CountryOptionsAuStandard, ?type': Create'CountryOptionsAuType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsAwStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsAwStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsAw with
        static member New(?standard: Create'CountryOptionsAwStandard, ?type': Create'CountryOptionsAwType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsAzType = | Simplified

    type Create'CountryOptionsAz =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsAzType option
        }

    type Create'CountryOptionsAz with
        static member New(?type': Create'CountryOptionsAzType) =
            {
                Type = type'
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

    type Create'CountryOptionsBaStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsBaStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsBa with
        static member New(?standard: Create'CountryOptionsBaStandard, ?type': Create'CountryOptionsBaType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsBbStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsBbStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsBb with
        static member New(?standard: Create'CountryOptionsBbStandard, ?type': Create'CountryOptionsBbType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsBdStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsBdStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsBd with
        static member New(?standard: Create'CountryOptionsBdStandard, ?type': Create'CountryOptionsBdType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsBeStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsBeStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsBe with
        static member New(?standard: Create'CountryOptionsBeStandard, ?type': Create'CountryOptionsBeType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsBfStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsBfStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsBf with
        static member New(?standard: Create'CountryOptionsBfStandard, ?type': Create'CountryOptionsBfType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsBgStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsBgStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsBg with
        static member New(?standard: Create'CountryOptionsBgStandard, ?type': Create'CountryOptionsBgType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsBhStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsBhStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsBh with
        static member New(?standard: Create'CountryOptionsBhStandard, ?type': Create'CountryOptionsBhType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsBjType = | Simplified

    type Create'CountryOptionsBj =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsBjType option
        }

    type Create'CountryOptionsBj with
        static member New(?type': Create'CountryOptionsBjType) =
            {
                Type = type'
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

    type Create'CountryOptionsBsStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsBsStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsBs with
        static member New(?standard: Create'CountryOptionsBsStandard, ?type': Create'CountryOptionsBsType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsByType = | Simplified

    type Create'CountryOptionsBy =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsByType option
        }

    type Create'CountryOptionsBy with
        static member New(?type': Create'CountryOptionsByType) =
            {
                Type = type'
            }

    type Create'CountryOptionsCaProvinceStandard =
        {
            /// Two-letter CA province code ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
            [<Config.Form>]
            Province: string option
        }

    type Create'CountryOptionsCaProvinceStandard with
        static member New(?province: string) =
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

    type Create'CountryOptionsCa with
        static member New(?provinceStandard: Create'CountryOptionsCaProvinceStandard, ?type': Create'CountryOptionsCaType) =
            {
                ProvinceStandard = provinceStandard
                Type = type'
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

    type Create'CountryOptionsCdStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsCdStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsCd with
        static member New(?standard: Create'CountryOptionsCdStandard, ?type': Create'CountryOptionsCdType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsChStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsChStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsCh with
        static member New(?standard: Create'CountryOptionsChStandard, ?type': Create'CountryOptionsChType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsClType = | Simplified

    type Create'CountryOptionsCl =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsClType option
        }

    type Create'CountryOptionsCl with
        static member New(?type': Create'CountryOptionsClType) =
            {
                Type = type'
            }

    type Create'CountryOptionsCmType = | Simplified

    type Create'CountryOptionsCm =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsCmType option
        }

    type Create'CountryOptionsCm with
        static member New(?type': Create'CountryOptionsCmType) =
            {
                Type = type'
            }

    type Create'CountryOptionsCoType = | Simplified

    type Create'CountryOptionsCo =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsCoType option
        }

    type Create'CountryOptionsCo with
        static member New(?type': Create'CountryOptionsCoType) =
            {
                Type = type'
            }

    type Create'CountryOptionsCrType = | Simplified

    type Create'CountryOptionsCr =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsCrType option
        }

    type Create'CountryOptionsCr with
        static member New(?type': Create'CountryOptionsCrType) =
            {
                Type = type'
            }

    type Create'CountryOptionsCvType = | Simplified

    type Create'CountryOptionsCv =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsCvType option
        }

    type Create'CountryOptionsCv with
        static member New(?type': Create'CountryOptionsCvType) =
            {
                Type = type'
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

    type Create'CountryOptionsCyStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsCyStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsCy with
        static member New(?standard: Create'CountryOptionsCyStandard, ?type': Create'CountryOptionsCyType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsCzStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsCzStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsCz with
        static member New(?standard: Create'CountryOptionsCzStandard, ?type': Create'CountryOptionsCzType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsDeStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsDeStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsDe with
        static member New(?standard: Create'CountryOptionsDeStandard, ?type': Create'CountryOptionsDeType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsDkStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsDkStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsDk with
        static member New(?standard: Create'CountryOptionsDkStandard, ?type': Create'CountryOptionsDkType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsEcType = | Simplified

    type Create'CountryOptionsEc =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsEcType option
        }

    type Create'CountryOptionsEc with
        static member New(?type': Create'CountryOptionsEcType) =
            {
                Type = type'
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

    type Create'CountryOptionsEeStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsEeStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsEe with
        static member New(?standard: Create'CountryOptionsEeStandard, ?type': Create'CountryOptionsEeType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsEgType = | Simplified

    type Create'CountryOptionsEg =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsEgType option
        }

    type Create'CountryOptionsEg with
        static member New(?type': Create'CountryOptionsEgType) =
            {
                Type = type'
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

    type Create'CountryOptionsEsStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsEsStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsEs with
        static member New(?standard: Create'CountryOptionsEsStandard, ?type': Create'CountryOptionsEsType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsEtStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsEtStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsEt with
        static member New(?standard: Create'CountryOptionsEtStandard, ?type': Create'CountryOptionsEtType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsFiStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsFiStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsFi with
        static member New(?standard: Create'CountryOptionsFiStandard, ?type': Create'CountryOptionsFiType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsFrStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsFrStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsFr with
        static member New(?standard: Create'CountryOptionsFrStandard, ?type': Create'CountryOptionsFrType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsGbStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsGbStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsGb with
        static member New(?standard: Create'CountryOptionsGbStandard, ?type': Create'CountryOptionsGbType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsGeType = | Simplified

    type Create'CountryOptionsGe =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsGeType option
        }

    type Create'CountryOptionsGe with
        static member New(?type': Create'CountryOptionsGeType) =
            {
                Type = type'
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

    type Create'CountryOptionsGnStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsGnStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsGn with
        static member New(?standard: Create'CountryOptionsGnStandard, ?type': Create'CountryOptionsGnType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsGrStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsGrStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsGr with
        static member New(?standard: Create'CountryOptionsGrStandard, ?type': Create'CountryOptionsGrType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsHrStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsHrStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsHr with
        static member New(?standard: Create'CountryOptionsHrStandard, ?type': Create'CountryOptionsHrType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsHuStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsHuStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsHu with
        static member New(?standard: Create'CountryOptionsHuStandard, ?type': Create'CountryOptionsHuType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsIdType = | Simplified

    type Create'CountryOptionsId =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsIdType option
        }

    type Create'CountryOptionsId with
        static member New(?type': Create'CountryOptionsIdType) =
            {
                Type = type'
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

    type Create'CountryOptionsIeStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsIeStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsIe with
        static member New(?standard: Create'CountryOptionsIeStandard, ?type': Create'CountryOptionsIeType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsInType = | Simplified

    type Create'CountryOptionsIn =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsInType option
        }

    type Create'CountryOptionsIn with
        static member New(?type': Create'CountryOptionsInType) =
            {
                Type = type'
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

    type Create'CountryOptionsIsStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsIsStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsIs with
        static member New(?standard: Create'CountryOptionsIsStandard, ?type': Create'CountryOptionsIsType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsItStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsItStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsIt with
        static member New(?standard: Create'CountryOptionsItStandard, ?type': Create'CountryOptionsItType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsJpStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsJpStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsJp with
        static member New(?standard: Create'CountryOptionsJpStandard, ?type': Create'CountryOptionsJpType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsKeType = | Simplified

    type Create'CountryOptionsKe =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsKeType option
        }

    type Create'CountryOptionsKe with
        static member New(?type': Create'CountryOptionsKeType) =
            {
                Type = type'
            }

    type Create'CountryOptionsKgType = | Simplified

    type Create'CountryOptionsKg =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsKgType option
        }

    type Create'CountryOptionsKg with
        static member New(?type': Create'CountryOptionsKgType) =
            {
                Type = type'
            }

    type Create'CountryOptionsKhType = | Simplified

    type Create'CountryOptionsKh =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsKhType option
        }

    type Create'CountryOptionsKh with
        static member New(?type': Create'CountryOptionsKhType) =
            {
                Type = type'
            }

    type Create'CountryOptionsKrType = | Simplified

    type Create'CountryOptionsKr =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsKrType option
        }

    type Create'CountryOptionsKr with
        static member New(?type': Create'CountryOptionsKrType) =
            {
                Type = type'
            }

    type Create'CountryOptionsKzType = | Simplified

    type Create'CountryOptionsKz =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsKzType option
        }

    type Create'CountryOptionsKz with
        static member New(?type': Create'CountryOptionsKzType) =
            {
                Type = type'
            }

    type Create'CountryOptionsLaType = | Simplified

    type Create'CountryOptionsLa =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsLaType option
        }

    type Create'CountryOptionsLa with
        static member New(?type': Create'CountryOptionsLaType) =
            {
                Type = type'
            }

    type Create'CountryOptionsLkType = | Simplified

    type Create'CountryOptionsLk =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsLkType option
        }

    type Create'CountryOptionsLk with
        static member New(?type': Create'CountryOptionsLkType) =
            {
                Type = type'
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

    type Create'CountryOptionsLtStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsLtStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsLt with
        static member New(?standard: Create'CountryOptionsLtStandard, ?type': Create'CountryOptionsLtType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsLuStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsLuStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsLu with
        static member New(?standard: Create'CountryOptionsLuStandard, ?type': Create'CountryOptionsLuType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsLvStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsLvStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsLv with
        static member New(?standard: Create'CountryOptionsLvStandard, ?type': Create'CountryOptionsLvType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsMaType = | Simplified

    type Create'CountryOptionsMa =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsMaType option
        }

    type Create'CountryOptionsMa with
        static member New(?type': Create'CountryOptionsMaType) =
            {
                Type = type'
            }

    type Create'CountryOptionsMdType = | Simplified

    type Create'CountryOptionsMd =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsMdType option
        }

    type Create'CountryOptionsMd with
        static member New(?type': Create'CountryOptionsMdType) =
            {
                Type = type'
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

    type Create'CountryOptionsMeStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsMeStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsMe with
        static member New(?standard: Create'CountryOptionsMeStandard, ?type': Create'CountryOptionsMeType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsMkStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsMkStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsMk with
        static member New(?standard: Create'CountryOptionsMkStandard, ?type': Create'CountryOptionsMkType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsMrStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsMrStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsMr with
        static member New(?standard: Create'CountryOptionsMrStandard, ?type': Create'CountryOptionsMrType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsMtStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsMtStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsMt with
        static member New(?standard: Create'CountryOptionsMtStandard, ?type': Create'CountryOptionsMtType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsMxType = | Simplified

    type Create'CountryOptionsMx =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsMxType option
        }

    type Create'CountryOptionsMx with
        static member New(?type': Create'CountryOptionsMxType) =
            {
                Type = type'
            }

    type Create'CountryOptionsMyType = | Simplified

    type Create'CountryOptionsMy =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsMyType option
        }

    type Create'CountryOptionsMy with
        static member New(?type': Create'CountryOptionsMyType) =
            {
                Type = type'
            }

    type Create'CountryOptionsNgType = | Simplified

    type Create'CountryOptionsNg =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsNgType option
        }

    type Create'CountryOptionsNg with
        static member New(?type': Create'CountryOptionsNgType) =
            {
                Type = type'
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

    type Create'CountryOptionsNlStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsNlStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsNl with
        static member New(?standard: Create'CountryOptionsNlStandard, ?type': Create'CountryOptionsNlType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsNoStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsNoStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsNo with
        static member New(?standard: Create'CountryOptionsNoStandard, ?type': Create'CountryOptionsNoType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsNpType = | Simplified

    type Create'CountryOptionsNp =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsNpType option
        }

    type Create'CountryOptionsNp with
        static member New(?type': Create'CountryOptionsNpType) =
            {
                Type = type'
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

    type Create'CountryOptionsNzStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsNzStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsNz with
        static member New(?standard: Create'CountryOptionsNzStandard, ?type': Create'CountryOptionsNzType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsOmStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsOmStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsOm with
        static member New(?standard: Create'CountryOptionsOmStandard, ?type': Create'CountryOptionsOmType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsPeType = | Simplified

    type Create'CountryOptionsPe =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsPeType option
        }

    type Create'CountryOptionsPe with
        static member New(?type': Create'CountryOptionsPeType) =
            {
                Type = type'
            }

    type Create'CountryOptionsPhType = | Simplified

    type Create'CountryOptionsPh =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsPhType option
        }

    type Create'CountryOptionsPh with
        static member New(?type': Create'CountryOptionsPhType) =
            {
                Type = type'
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

    type Create'CountryOptionsPlStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsPlStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsPl with
        static member New(?standard: Create'CountryOptionsPlStandard, ?type': Create'CountryOptionsPlType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsPtStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsPtStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsPt with
        static member New(?standard: Create'CountryOptionsPtStandard, ?type': Create'CountryOptionsPtType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsRoStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsRoStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsRo with
        static member New(?standard: Create'CountryOptionsRoStandard, ?type': Create'CountryOptionsRoType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsRsStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsRsStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsRs with
        static member New(?standard: Create'CountryOptionsRsStandard, ?type': Create'CountryOptionsRsType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsRuType = | Simplified

    type Create'CountryOptionsRu =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsRuType option
        }

    type Create'CountryOptionsRu with
        static member New(?type': Create'CountryOptionsRuType) =
            {
                Type = type'
            }

    type Create'CountryOptionsSaType = | Simplified

    type Create'CountryOptionsSa =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsSaType option
        }

    type Create'CountryOptionsSa with
        static member New(?type': Create'CountryOptionsSaType) =
            {
                Type = type'
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

    type Create'CountryOptionsSeStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsSeStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsSe with
        static member New(?standard: Create'CountryOptionsSeStandard, ?type': Create'CountryOptionsSeType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsSgStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsSgStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsSg with
        static member New(?standard: Create'CountryOptionsSgStandard, ?type': Create'CountryOptionsSgType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsSiStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsSiStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsSi with
        static member New(?standard: Create'CountryOptionsSiStandard, ?type': Create'CountryOptionsSiType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptionsSkStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsSkStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsSk with
        static member New(?standard: Create'CountryOptionsSkStandard, ?type': Create'CountryOptionsSkType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsSnType = | Simplified

    type Create'CountryOptionsSn =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsSnType option
        }

    type Create'CountryOptionsSn with
        static member New(?type': Create'CountryOptionsSnType) =
            {
                Type = type'
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

    type Create'CountryOptionsSrStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsSrStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsSr with
        static member New(?standard: Create'CountryOptionsSrStandard, ?type': Create'CountryOptionsSrType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsThType = | Simplified

    type Create'CountryOptionsTh =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsThType option
        }

    type Create'CountryOptionsTh with
        static member New(?type': Create'CountryOptionsThType) =
            {
                Type = type'
            }

    type Create'CountryOptionsTjType = | Simplified

    type Create'CountryOptionsTj =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsTjType option
        }

    type Create'CountryOptionsTj with
        static member New(?type': Create'CountryOptionsTjType) =
            {
                Type = type'
            }

    type Create'CountryOptionsTrType = | Simplified

    type Create'CountryOptionsTr =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsTrType option
        }

    type Create'CountryOptionsTr with
        static member New(?type': Create'CountryOptionsTrType) =
            {
                Type = type'
            }

    type Create'CountryOptionsTwType = | Simplified

    type Create'CountryOptionsTw =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsTwType option
        }

    type Create'CountryOptionsTw with
        static member New(?type': Create'CountryOptionsTwType) =
            {
                Type = type'
            }

    type Create'CountryOptionsTzType = | Simplified

    type Create'CountryOptionsTz =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsTzType option
        }

    type Create'CountryOptionsTz with
        static member New(?type': Create'CountryOptionsTzType) =
            {
                Type = type'
            }

    type Create'CountryOptionsUaType = | Simplified

    type Create'CountryOptionsUa =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsUaType option
        }

    type Create'CountryOptionsUa with
        static member New(?type': Create'CountryOptionsUaType) =
            {
                Type = type'
            }

    type Create'CountryOptionsUgType = | Simplified

    type Create'CountryOptionsUg =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsUgType option
        }

    type Create'CountryOptionsUg with
        static member New(?type': Create'CountryOptionsUgType) =
            {
                Type = type'
            }

    type Create'CountryOptionsUsLocalAmusementTax =
        {
            /// A jurisdiction code representing the [local jurisdiction](/tax/registering?type=amusement_tax#registration-types).
            [<Config.Form>]
            Jurisdiction: string option
        }

    type Create'CountryOptionsUsLocalAmusementTax with
        static member New(?jurisdiction: string) =
            {
                Jurisdiction = jurisdiction
            }

    type Create'CountryOptionsUsLocalLeaseTax =
        {
            /// A [FIPS code](https://www.census.gov/library/reference/code-lists/ansi.html) representing the local jurisdiction. Supported FIPS codes are: `14000` (Chicago).
            [<Config.Form>]
            Jurisdiction: string option
        }

    type Create'CountryOptionsUsLocalLeaseTax with
        static member New(?jurisdiction: string) =
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

    type Create'CountryOptionsUsStateSalesTaxElections with
        static member New(?jurisdiction: string, ?type': Create'CountryOptionsUsStateSalesTaxElectionsType) =
            {
                Jurisdiction = jurisdiction
                Type = type'
            }

    type Create'CountryOptionsUsStateSalesTax =
        {
            /// Elections for the state sales tax registration.
            [<Config.Form>]
            Elections: Create'CountryOptionsUsStateSalesTaxElections list option
        }

    type Create'CountryOptionsUsStateSalesTax with
        static member New(?elections: Create'CountryOptionsUsStateSalesTaxElections list) =
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

    type Create'CountryOptionsUs with
        static member New(?localAmusementTax: Create'CountryOptionsUsLocalAmusementTax, ?localLeaseTax: Create'CountryOptionsUsLocalLeaseTax, ?state: string, ?stateSalesTax: Create'CountryOptionsUsStateSalesTax, ?type': Create'CountryOptionsUsType) =
            {
                LocalAmusementTax = localAmusementTax
                LocalLeaseTax = localLeaseTax
                State = state
                StateSalesTax = stateSalesTax
                Type = type'
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

    type Create'CountryOptionsUyStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsUyStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsUy with
        static member New(?standard: Create'CountryOptionsUyStandard, ?type': Create'CountryOptionsUyType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsUzType = | Simplified

    type Create'CountryOptionsUz =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsUzType option
        }

    type Create'CountryOptionsUz with
        static member New(?type': Create'CountryOptionsUzType) =
            {
                Type = type'
            }

    type Create'CountryOptionsVnType = | Simplified

    type Create'CountryOptionsVn =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsVnType option
        }

    type Create'CountryOptionsVn with
        static member New(?type': Create'CountryOptionsVnType) =
            {
                Type = type'
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

    type Create'CountryOptionsZaStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsZaStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsZa with
        static member New(?standard: Create'CountryOptionsZaStandard, ?type': Create'CountryOptionsZaType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsZmType = | Simplified

    type Create'CountryOptionsZm =
        {
            /// Type of registration to be created in `country`.
            [<Config.Form>]
            Type: Create'CountryOptionsZmType option
        }

    type Create'CountryOptionsZm with
        static member New(?type': Create'CountryOptionsZmType) =
            {
                Type = type'
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

    type Create'CountryOptionsZwStandard with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsZwStandardPlaceOfSupplyScheme) =
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

    type Create'CountryOptionsZw with
        static member New(?standard: Create'CountryOptionsZwStandard, ?type': Create'CountryOptionsZwType) =
            {
                Standard = standard
                Type = type'
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

    type Create'CountryOptions with
        static member New(?ae: Create'CountryOptionsAe, ?al: Create'CountryOptionsAl, ?am: Create'CountryOptionsAm, ?ao: Create'CountryOptionsAo, ?at: Create'CountryOptionsAt, ?au: Create'CountryOptionsAu, ?aw: Create'CountryOptionsAw, ?az: Create'CountryOptionsAz, ?ba: Create'CountryOptionsBa, ?bb: Create'CountryOptionsBb, ?bd: Create'CountryOptionsBd, ?be: Create'CountryOptionsBe, ?bf: Create'CountryOptionsBf, ?bg: Create'CountryOptionsBg, ?bh: Create'CountryOptionsBh, ?bj: Create'CountryOptionsBj, ?bs: Create'CountryOptionsBs, ?by: Create'CountryOptionsBy, ?ca: Create'CountryOptionsCa, ?cd: Create'CountryOptionsCd, ?ch: Create'CountryOptionsCh, ?cl: Create'CountryOptionsCl, ?cm: Create'CountryOptionsCm, ?co: Create'CountryOptionsCo, ?cr: Create'CountryOptionsCr, ?cv: Create'CountryOptionsCv, ?cy: Create'CountryOptionsCy, ?cz: Create'CountryOptionsCz, ?de: Create'CountryOptionsDe, ?dk: Create'CountryOptionsDk, ?ec: Create'CountryOptionsEc, ?ee: Create'CountryOptionsEe, ?eg: Create'CountryOptionsEg, ?es: Create'CountryOptionsEs, ?et: Create'CountryOptionsEt, ?fi: Create'CountryOptionsFi, ?fr: Create'CountryOptionsFr, ?gb: Create'CountryOptionsGb, ?ge: Create'CountryOptionsGe, ?gn: Create'CountryOptionsGn, ?gr: Create'CountryOptionsGr, ?hr: Create'CountryOptionsHr, ?hu: Create'CountryOptionsHu, ?id: Create'CountryOptionsId, ?ie: Create'CountryOptionsIe, ?in': Create'CountryOptionsIn, ?is: Create'CountryOptionsIs, ?it: Create'CountryOptionsIt, ?jp: Create'CountryOptionsJp, ?ke: Create'CountryOptionsKe, ?kg: Create'CountryOptionsKg, ?kh: Create'CountryOptionsKh, ?kr: Create'CountryOptionsKr, ?kz: Create'CountryOptionsKz, ?la: Create'CountryOptionsLa, ?lk: Create'CountryOptionsLk, ?lt: Create'CountryOptionsLt, ?lu: Create'CountryOptionsLu, ?lv: Create'CountryOptionsLv, ?ma: Create'CountryOptionsMa, ?md: Create'CountryOptionsMd, ?me: Create'CountryOptionsMe, ?mk: Create'CountryOptionsMk, ?mr: Create'CountryOptionsMr, ?mt: Create'CountryOptionsMt, ?mx: Create'CountryOptionsMx, ?my: Create'CountryOptionsMy, ?ng: Create'CountryOptionsNg, ?nl: Create'CountryOptionsNl, ?no: Create'CountryOptionsNo, ?np: Create'CountryOptionsNp, ?nz: Create'CountryOptionsNz, ?om: Create'CountryOptionsOm, ?pe: Create'CountryOptionsPe, ?ph: Create'CountryOptionsPh, ?pl: Create'CountryOptionsPl, ?pt: Create'CountryOptionsPt, ?ro: Create'CountryOptionsRo, ?rs: Create'CountryOptionsRs, ?ru: Create'CountryOptionsRu, ?sa: Create'CountryOptionsSa, ?se: Create'CountryOptionsSe, ?sg: Create'CountryOptionsSg, ?si: Create'CountryOptionsSi, ?sk: Create'CountryOptionsSk, ?sn: Create'CountryOptionsSn, ?sr: Create'CountryOptionsSr, ?th: Create'CountryOptionsTh, ?tj: Create'CountryOptionsTj, ?tr: Create'CountryOptionsTr, ?tw: Create'CountryOptionsTw, ?tz: Create'CountryOptionsTz, ?ua: Create'CountryOptionsUa, ?ug: Create'CountryOptionsUg, ?us: Create'CountryOptionsUs, ?uy: Create'CountryOptionsUy, ?uz: Create'CountryOptionsUz, ?vn: Create'CountryOptionsVn, ?za: Create'CountryOptionsZa, ?zm: Create'CountryOptionsZm, ?zw: Create'CountryOptionsZw) =
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
                In = in'
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

    type CreateOptions with
        static member New(activeFrom: Choice<Create'ActiveFrom,DateTime>, country: IsoTypes.IsoCountryCode, countryOptions: Create'CountryOptions, ?expand: string list, ?expiresAt: DateTime) =
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

    type RetrieveOptions with
        static member New(id: string, ?expand: string list) =
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

    type UpdateOptions with
        static member New(id: string, ?activeFrom: Choice<Update'ActiveFrom,DateTime>, ?expand: string list, ?expiresAt: Choice<Update'ExpiresAt,DateTime,string>) =
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

    type RetrieveOptions with
        static member New(?expand: string list) =
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

    type Update'Defaults with
        static member New(?taxBehavior: Update'DefaultsTaxBehavior, ?taxCode: string) =
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

    type Update'HeadOfficeAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
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

    type Update'HeadOffice with
        static member New(?address: Update'HeadOfficeAddress) =
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

    type UpdateOptions with
        static member New(?defaults: Update'Defaults, ?expand: string list, ?headOffice: Update'HeadOffice) =
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

    type CreateFromCalculationOptions with
        static member New(calculation: string, reference: string, ?expand: string list, ?metadata: Map<string, string>, ?postedAt: DateTime) =
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

    type CreateReversal'LineItems with
        static member New(?amount: int, ?amountTax: int, ?metadata: Map<string, string>, ?originalLineItem: string, ?quantity: int, ?reference: string) =
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

    type CreateReversal'ShippingCost with
        static member New(?amount: int, ?amountTax: int) =
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

    type CreateReversalOptions with
        static member New(mode: CreateReversal'Mode, originalTransaction: string, reference: string, ?expand: string list, ?flatAmount: int, ?lineItems: CreateReversal'LineItems list, ?metadata: Map<string, string>, ?shippingCost: CreateReversal'ShippingCost) =
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

    type RetrieveOptions with
        static member New(transaction: string, ?expand: string list) =
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

    type ListLineItemsOptions with
        static member New(transaction: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
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

    type ListOptions with
        static member New(?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
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

    type RetrieveOptions with
        static member New(id: string, ?expand: string list) =
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

    type ListOptions with
        static member New(?endingBefore: string, ?expand: string list, ?limit: int, ?owner: Map<string, string>, ?startingAfter: string) =
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

    type Create'Owner with
        static member New(?account: string, ?customer: string, ?customerAccount: string, ?type': Create'OwnerType) =
            {
                Account = account
                Customer = customer
                CustomerAccount = customerAccount
                Type = type'
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

    type CreateOptions with
        static member New(type': Create'Type, value: string, ?expand: string list, ?owner: Create'Owner) =
            {
                Type = type'
                Value = value
                Expand = expand
                Owner = owner
            }

    type DeleteOptions =
        { [<Config.Path>]
          Id: string }

    type DeleteOptions with
        static member New(id: string) =
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

    type RetrieveOptions with
        static member New(id: string, ?expand: string list) =
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

    type ListOptions with
        static member New(?active: bool, ?created: int, ?endingBefore: string, ?expand: string list, ?inclusive: bool, ?limit: int, ?startingAfter: string) =
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

    type CreateOptions with
        static member New(displayName: string, inclusive: bool, percentage: decimal, ?active: bool, ?country: IsoTypes.IsoCountryCode, ?description: string, ?expand: string list, ?jurisdiction: string, ?metadata: Map<string, string>, ?state: string, ?taxType: Create'TaxType) =
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

    type RetrieveOptions with
        static member New(taxRate: string, ?expand: string list) =
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

    type UpdateOptions with
        static member New(taxRate: string, ?active: bool, ?country: IsoTypes.IsoCountryCode, ?description: string, ?displayName: string, ?expand: string list, ?jurisdiction: string, ?metadata: Map<string, string>, ?state: string, ?taxType: Update'TaxType) =
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

