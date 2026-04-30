namespace Stripe.Tax

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Address

/// The amount of the tax rate when the `rate_type`` is `flat_amount`. Tax rates with `rate_type` `percentage` can vary based on the transaction, resulting in this field being `null`. This field exposes the amount and currency of the flat tax rate.
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type TaxRateFlatAmount =
    {
        /// Amount of the tax when the `rate_type` is `flat_amount`. This positive integer represents how much to charge in the smallest currency unit (e.g., 100 cents to charge $1.00 or 100 to charge ¥100, a zero-decimal currency). The amount value supports up to eight digits (e.g., a value of 99999999 for a USD charge of $999,999.99).
        Amount: int
        /// Three-letter ISO currency code, in lowercase.
        Currency: IsoTypes.IsoCurrencyCode
    }

module TaxRateFlatAmount =
    let create
        (
            amount: int,
            currency: IsoTypes.IsoCurrencyCode
        ) : TaxRateFlatAmount
        =
        {
          Amount = amount
          Currency = currency
        }

type TaxRateJurisdictionLevel =
    | City
    | Country
    | County
    | District
    | Multiple
    | State

[<Struct>]
type TaxRateRateType =
    | FlatAmount
    | Percentage

type TaxRateTaxType =
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

/// Tax rates can be applied to [invoices](/invoicing/taxes/tax-rates), [subscriptions](/billing/taxes/tax-rates) and [Checkout Sessions](/payments/checkout/use-manual-tax-rates) to collect tax.
/// Related guide: [Tax rates](/billing/taxes/tax-rates)
type TaxRate =
    {
        /// Defaults to `true`. When set to `false`, this tax rate cannot be used with new applications or Checkout Sessions, but will still work for subscriptions and invoices that already have it set.
        Active: bool
        /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        Country: IsoTypes.IsoCountryCode option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// An arbitrary string attached to the tax rate for your internal use only. It will not be visible to your customers.
        Description: string option
        /// The display name of the tax rates as it will appear to your customer on their receipt email, PDF, and the hosted invoice page.
        DisplayName: string
        /// Actual/effective tax rate percentage out of 100. For tax calculations with automatic_tax[enabled]=true,
        /// this percentage reflects the rate actually used to calculate tax based on the product's taxability
        /// and whether the user is registered to collect taxes in the corresponding jurisdiction.
        EffectivePercentage: decimal option
        /// The amount of the tax rate when the `rate_type` is `flat_amount`. Tax rates with `rate_type` `percentage` can vary based on the transaction, resulting in this field being `null`. This field exposes the amount and currency of the flat tax rate.
        FlatAmount: TaxRateFlatAmount option
        /// Unique identifier for the object.
        Id: string
        /// This specifies if the tax rate is inclusive or exclusive.
        Inclusive: bool
        /// The jurisdiction for the tax rate. You can use this label field for tax reporting purposes. It also appears on your customer’s invoice.
        Jurisdiction: string option
        /// The level of the jurisdiction that imposes this tax rate. Will be `null` for manually defined tax rates.
        JurisdictionLevel: TaxRateJurisdictionLevel option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        /// Tax rate percentage out of 100. For tax calculations with automatic_tax[enabled]=true, this percentage includes the statutory tax rate of non-taxable jurisdictions.
        Percentage: decimal
        /// Indicates the type of tax rate applied to the taxable amount. This value can be `null` when no tax applies to the location. This field is only present for TaxRates created by Stripe Tax.
        RateType: TaxRateRateType option
        /// [ISO 3166-2 subdivision code](https://en.wikipedia.org/wiki/ISO_3166-2), without country prefix. For example, "NY" for New York, United States.
        State: string option
        /// The high-level tax type, such as `vat` or `sales_tax`.
        TaxType: TaxRateTaxType option
    }

module TaxRate =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "tax_rate"

    let create
        (
            active: bool,
            country: IsoTypes.IsoCountryCode option,
            created: DateTime,
            description: string option,
            displayName: string,
            effectivePercentage: decimal option,
            flatAmount: TaxRateFlatAmount option,
            id: string,
            inclusive: bool,
            jurisdiction: string option,
            jurisdictionLevel: TaxRateJurisdictionLevel option,
            livemode: bool,
            metadata: Map<string, string> option,
            percentage: decimal,
            rateType: TaxRateRateType option,
            state: string option,
            taxType: TaxRateTaxType option
        ) : TaxRate
        =
        {
          Active = active
          Country = country
          Created = created
          Description = description
          DisplayName = displayName
          EffectivePercentage = effectivePercentage
          FlatAmount = flatAmount
          Id = id
          Inclusive = inclusive
          Jurisdiction = jurisdiction
          JurisdictionLevel = jurisdictionLevel
          Livemode = livemode
          Metadata = metadata
          Percentage = percentage
          RateType = rateType
          State = state
          TaxType = taxType
        }

/// Occurs whenever a tax rate is updated.
type TaxRateUpdated = { Object: TaxRate }

module TaxRateUpdated =
    let create
        (
            object: TaxRate
        ) : TaxRateUpdated
        =
        {
          Object = object
        }

/// Occurs whenever a new tax rate is created.
type TaxRateCreated = { Object: TaxRate }

module TaxRateCreated =
    let create
        (
            object: TaxRate
        ) : TaxRateCreated
        =
        {
          Object = object
        }

[<Struct>]
type TaxProductResourceCustomerDetailsAddressSource =
    | Billing
    | Shipping

type TaxProductResourceCustomerDetailsResourceTaxIdType =
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
    | Unknown
    | UsEin
    | UyRuc
    | UzTin
    | UzVat
    | VeRif
    | VnTin
    | ZaVat
    | ZmTin
    | ZwTin

type TaxProductResourceCustomerDetailsResourceTaxId =
    {
        /// The type of the tax ID, one of `ad_nrt`, `ar_cuit`, `eu_vat`, `bo_tin`, `br_cnpj`, `br_cpf`, `cn_tin`, `co_nit`, `cr_tin`, `do_rcn`, `ec_ruc`, `eu_oss_vat`, `hr_oib`, `pe_ruc`, `ro_tin`, `rs_pib`, `sv_nit`, `uy_ruc`, `ve_rif`, `vn_tin`, `gb_vat`, `nz_gst`, `au_abn`, `au_arn`, `in_gst`, `no_vat`, `no_voec`, `za_vat`, `ch_vat`, `mx_rfc`, `sg_uen`, `ru_inn`, `ru_kpp`, `ca_bn`, `hk_br`, `es_cif`, `pl_nip`, `it_cf`, `fo_vat`, `gi_tin`, `py_ruc`, `tw_vat`, `th_vat`, `jp_cn`, `jp_rn`, `jp_trn`, `li_uid`, `li_vat`, `lk_vat`, `my_itn`, `us_ein`, `kr_brn`, `ca_qst`, `ca_gst_hst`, `ca_pst_bc`, `ca_pst_mb`, `ca_pst_sk`, `my_sst`, `sg_gst`, `ae_trn`, `cl_tin`, `sa_vat`, `id_npwp`, `my_frp`, `il_vat`, `ge_vat`, `ua_vat`, `is_vat`, `bg_uic`, `hu_tin`, `si_tin`, `ke_pin`, `tr_tin`, `eg_tin`, `ph_tin`, `al_tin`, `bh_vat`, `kz_bin`, `ng_tin`, `om_vat`, `de_stn`, `ch_uid`, `tz_vat`, `uz_vat`, `uz_tin`, `md_vat`, `ma_vat`, `by_tin`, `ao_tin`, `bs_tin`, `bb_tin`, `cd_nif`, `mr_nif`, `me_pib`, `zw_tin`, `ba_tin`, `gn_nif`, `mk_vat`, `sr_fin`, `sn_ninea`, `am_tin`, `np_pan`, `tj_tin`, `ug_tin`, `zm_tin`, `kh_tin`, `aw_tin`, `az_tin`, `bd_bin`, `bj_ifu`, `et_tin`, `kg_tin`, `la_tin`, `cm_niu`, `cv_nif`, `bf_ifu`, or `unknown`
        Type: TaxProductResourceCustomerDetailsResourceTaxIdType
        /// The value of the tax ID.
        Value: string
    }

module TaxProductResourceCustomerDetailsResourceTaxId =
    let create
        (
            ``type``: TaxProductResourceCustomerDetailsResourceTaxIdType,
            value: string
        ) : TaxProductResourceCustomerDetailsResourceTaxId
        =
        {
          Type = ``type``
          Value = value
        }

[<Struct>]
type TaxProductResourceCustomerDetailsTaxabilityOverride =
    | CustomerExempt
    | [<JsonPropertyName("none")>] None'
    | ReverseCharge

type TaxProductResourcePostalAddress =
    {
        /// City, district, suburb, town, or village.
        City: string option
        /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        Country: IsoTypes.IsoCountryCode
        /// Address line 1, such as the street, PO Box, or company name.
        [<JsonPropertyName("line1")>]
        Line1: string option
        /// Address line 2, such as the apartment, suite, unit, or building.
        [<JsonPropertyName("line2")>]
        Line2: string option
        /// ZIP or postal code.
        PostalCode: string option
        /// State/province as an [ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2) subdivision code, without country prefix, such as "NY" or "TX".
        State: string option
    }

module TaxProductResourcePostalAddress =
    let create
        (
            city: string option,
            country: IsoTypes.IsoCountryCode,
            line1: string option,
            line2: string option,
            postalCode: string option,
            state: string option
        ) : TaxProductResourcePostalAddress
        =
        {
          City = city
          Country = country
          Line1 = line1
          Line2 = line2
          PostalCode = postalCode
          State = state
        }

type TaxProductResourceCustomerDetails =
    {
        /// The customer's postal address (for example, home or business location).
        Address: TaxProductResourcePostalAddress option
        /// The type of customer address provided.
        AddressSource: TaxProductResourceCustomerDetailsAddressSource option
        /// The customer's IP address (IPv4 or IPv6).
        IpAddress: string option
        /// The customer's tax IDs (for example, EU VAT numbers).
        TaxIds: TaxProductResourceCustomerDetailsResourceTaxId list
        /// The taxability override used for taxation.
        TaxabilityOverride: TaxProductResourceCustomerDetailsTaxabilityOverride
    }

module TaxProductResourceCustomerDetails =
    let create
        (
            address: TaxProductResourcePostalAddress option,
            addressSource: TaxProductResourceCustomerDetailsAddressSource option,
            ipAddress: string option,
            taxIds: TaxProductResourceCustomerDetailsResourceTaxId list,
            taxabilityOverride: TaxProductResourceCustomerDetailsTaxabilityOverride
        ) : TaxProductResourceCustomerDetails
        =
        {
          Address = address
          AddressSource = addressSource
          IpAddress = ipAddress
          TaxIds = taxIds
          TaxabilityOverride = taxabilityOverride
        }

type TaxProductResourceShipFromDetails =
    { Address: TaxProductResourcePostalAddress }

module TaxProductResourceShipFromDetails =
    let create
        (
            address: TaxProductResourcePostalAddress
        ) : TaxProductResourceShipFromDetails
        =
        {
          Address = address
        }

type TaxProductResourceTaxTransactionResourceReversal =
    {
        /// The `id` of the reversed `Transaction` object.
        OriginalTransaction: string option
    }

module TaxProductResourceTaxTransactionResourceReversal =
    let create
        (
            originalTransaction: string option
        ) : TaxProductResourceTaxTransactionResourceReversal
        =
        {
          OriginalTransaction = originalTransaction
        }

[<Struct>]
type TaxProductResourceJurisdictionLevel =
    | City
    | Country
    | County
    | District
    | State

type TaxProductResourceJurisdiction =
    {
        /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        Country: IsoTypes.IsoCountryCode
        /// A human-readable name for the jurisdiction imposing the tax.
        DisplayName: string
        /// Indicates the level of the jurisdiction imposing the tax.
        Level: TaxProductResourceJurisdictionLevel
        /// [ISO 3166-2 subdivision code](https://en.wikipedia.org/wiki/ISO_3166-2), without country prefix. For example, "NY" for New York, United States.
        State: string option
    }

module TaxProductResourceJurisdiction =
    let create
        (
            country: IsoTypes.IsoCountryCode,
            displayName: string,
            level: TaxProductResourceJurisdictionLevel,
            state: string option
        ) : TaxProductResourceJurisdiction
        =
        {
          Country = country
          DisplayName = displayName
          Level = level
          State = state
        }

[<Struct>]
type TaxProductResourceLineItemTaxBreakdownSourcing =
    | Destination
    | Origin

type TaxProductResourceLineItemTaxBreakdownTaxabilityReason =
    | CustomerExempt
    | NotCollecting
    | NotSubjectToTax
    | NotSupported
    | PortionProductExempt
    | PortionReducedRated
    | PortionStandardRated
    | ProductExempt
    | ProductExemptHoliday
    | ProportionallyRated
    | ReducedRated
    | ReverseCharge
    | StandardRated
    | TaxableBasisReduced
    | ZeroRated

type TaxProductResourceLineItemTaxRateDetailsTaxType =
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

type TaxProductResourceLineItemTaxRateDetails =
    {
        /// A localized display name for tax type, intended to be human-readable. For example, "Local Sales and Use Tax", "Value-added tax (VAT)", or "Umsatzsteuer (USt.)".
        DisplayName: string
        /// The tax rate percentage as a string. For example, 8.5% is represented as "8.5".
        PercentageDecimal: string
        /// The tax type, such as `vat` or `sales_tax`.
        TaxType: TaxProductResourceLineItemTaxRateDetailsTaxType
    }

module TaxProductResourceLineItemTaxRateDetails =
    let create
        (
            displayName: string,
            percentageDecimal: string,
            taxType: TaxProductResourceLineItemTaxRateDetailsTaxType
        ) : TaxProductResourceLineItemTaxRateDetails
        =
        {
          DisplayName = displayName
          PercentageDecimal = percentageDecimal
          TaxType = taxType
        }

type TaxProductResourceLineItemTaxBreakdown =
    {
        /// The amount of tax, in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units).
        Amount: int
        Jurisdiction: TaxProductResourceJurisdiction
        /// Indicates whether the jurisdiction was determined by the origin (merchant's address) or destination (customer's address).
        Sourcing: TaxProductResourceLineItemTaxBreakdownSourcing
        /// Details regarding the rate for this tax. This field will be `null` when the tax is not imposed, for example if the product is exempt from tax.
        TaxRateDetails: TaxProductResourceLineItemTaxRateDetails option
        /// The reasoning behind this tax, for example, if the product is tax exempt. The possible values for this field may be extended as new tax rules are supported.
        TaxabilityReason: TaxProductResourceLineItemTaxBreakdownTaxabilityReason
        /// The amount on which tax is calculated, in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units).
        TaxableAmount: int
    }

module TaxProductResourceLineItemTaxBreakdown =
    let create
        (
            amount: int,
            jurisdiction: TaxProductResourceJurisdiction,
            sourcing: TaxProductResourceLineItemTaxBreakdownSourcing,
            taxRateDetails: TaxProductResourceLineItemTaxRateDetails option,
            taxabilityReason: TaxProductResourceLineItemTaxBreakdownTaxabilityReason,
            taxableAmount: int
        ) : TaxProductResourceLineItemTaxBreakdown
        =
        {
          Amount = amount
          Jurisdiction = jurisdiction
          Sourcing = sourcing
          TaxRateDetails = taxRateDetails
          TaxabilityReason = taxabilityReason
          TaxableAmount = taxableAmount
        }

[<Struct>]
type TaxProductResourceTaxTransactionShippingCostTaxBehavior =
    | Exclusive
    | Inclusive

type TaxProductResourceTaxTransactionShippingCost =
    {
        /// The shipping amount in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units). If `tax_behavior=inclusive`, then this amount includes taxes. Otherwise, taxes were calculated on top of this amount.
        Amount: int
        /// The amount of tax calculated for shipping, in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units).
        AmountTax: int
        /// The ID of an existing [ShippingRate](https://docs.stripe.com/api/shipping_rates/object).
        ShippingRate: string option
        /// Specifies whether the `amount` includes taxes. If `tax_behavior=inclusive`, then the amount includes taxes.
        TaxBehavior: TaxProductResourceTaxTransactionShippingCostTaxBehavior
        /// Detailed account of taxes relevant to shipping cost. (It is not populated for the transaction resource object and will be removed in the next API version.)
        TaxBreakdown: TaxProductResourceLineItemTaxBreakdown list option
        /// The [tax code](https://docs.stripe.com/tax/tax-categories) ID used for shipping.
        TaxCode: string
    }

module TaxProductResourceTaxTransactionShippingCost =
    let create
        (
            amount: int,
            amountTax: int,
            taxBehavior: TaxProductResourceTaxTransactionShippingCostTaxBehavior,
            taxCode: string,
            shippingRate: string option,
            taxBreakdown: TaxProductResourceLineItemTaxBreakdown list option
        ) : TaxProductResourceTaxTransactionShippingCost
        =
        {
          Amount = amount
          AmountTax = amountTax
          TaxBehavior = taxBehavior
          TaxCode = taxCode
          ShippingRate = shippingRate
          TaxBreakdown = taxBreakdown
        }

type TaxProductResourceTaxTransactionLineItemResourceReversal =
    {
        /// The `id` of the line item to reverse in the original transaction.
        OriginalLineItem: string
    }

module TaxProductResourceTaxTransactionLineItemResourceReversal =
    let create
        (
            originalLineItem: string
        ) : TaxProductResourceTaxTransactionLineItemResourceReversal
        =
        {
          OriginalLineItem = originalLineItem
        }

[<Struct>]
type TaxTransactionLineItemTaxBehavior =
    | Exclusive
    | Inclusive

[<Struct>]
type TaxTransactionLineItemType =
    | Reversal
    | Transaction

type TaxTransactionLineItem =
    {
        /// The line item amount in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units). If `tax_behavior=inclusive`, then this amount includes taxes. Otherwise, taxes were calculated on top of this amount.
        Amount: int
        /// The amount of tax calculated for this line item, in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units).
        AmountTax: int
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        /// The ID of an existing [Product](https://docs.stripe.com/api/products/object).
        Product: string option
        /// The number of units of the item being purchased. For reversals, this is the quantity reversed.
        Quantity: int
        /// A custom identifier for this line item in the transaction.
        Reference: string
        /// If `type=reversal`, contains information about what was reversed.
        Reversal: TaxProductResourceTaxTransactionLineItemResourceReversal option
        /// Specifies whether the `amount` includes taxes. If `tax_behavior=inclusive`, then the amount includes taxes.
        TaxBehavior: TaxTransactionLineItemTaxBehavior
        /// The [tax code](https://docs.stripe.com/tax/tax-categories) ID used for this resource.
        TaxCode: string
        /// If `reversal`, this line item reverses an earlier transaction.
        Type: TaxTransactionLineItemType
    }

module TaxTransactionLineItem =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "tax.transaction_line_item"

    let create
        (
            amount: int,
            amountTax: int,
            id: string,
            livemode: bool,
            metadata: Map<string, string> option,
            product: string option,
            quantity: int,
            reference: string,
            reversal: TaxProductResourceTaxTransactionLineItemResourceReversal option,
            taxBehavior: TaxTransactionLineItemTaxBehavior,
            taxCode: string,
            ``type``: TaxTransactionLineItemType
        ) : TaxTransactionLineItem
        =
        {
          Amount = amount
          AmountTax = amountTax
          Id = id
          Livemode = livemode
          Metadata = metadata
          Product = product
          Quantity = quantity
          Reference = reference
          Reversal = reversal
          TaxBehavior = taxBehavior
          TaxCode = taxCode
          Type = ``type``
        }

/// The tax collected or refunded, by line item.
type TaxTransactionLineItems =
    {
        /// Details about each object.
        Data: TaxTransactionLineItem list
        /// True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        /// The URL where this list can be accessed.
        Url: string
    }

module TaxTransactionLineItems =
    ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
    let object = "list"

    let create
        (
            data: TaxTransactionLineItem list,
            hasMore: bool,
            url: string
        ) : TaxTransactionLineItems
        =
        {
          Data = data
          HasMore = hasMore
          Url = url
        }

[<Struct>]
type TaxTransactionType =
    | Reversal
    | Transaction

/// A Tax Transaction records the tax collected from or refunded to your customer.
/// Related guide: [Calculate tax in your custom payment flow](https://docs.stripe.com/tax/custom#tax-transaction)
type TaxTransaction =
    {
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// The ID of an existing [Customer](https://docs.stripe.com/api/customers/object) used for the resource.
        Customer: string option
        CustomerDetails: TaxProductResourceCustomerDetails
        /// Unique identifier for the transaction.
        Id: string
        /// The tax collected or refunded, by line item.
        LineItems: TaxTransactionLineItems option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        /// The Unix timestamp representing when the tax liability is assumed or reduced.
        PostedAt: DateTime
        /// A custom unique identifier, such as 'myOrder_123'.
        Reference: string
        /// If `type=reversal`, contains information about what was reversed.
        Reversal: TaxProductResourceTaxTransactionResourceReversal option
        /// The details of the ship from location, such as the address.
        ShipFromDetails: TaxProductResourceShipFromDetails option
        /// The shipping cost details for the transaction.
        ShippingCost: TaxProductResourceTaxTransactionShippingCost option
        /// The calculation uses the tax rules and rates that are in effect at this timestamp. You can use a date up to 31 days in the past or up to 31 days in the future. If you use a future date, Stripe doesn't guarantee that the expected tax rules and rate being used match the actual rules and rate that will be in effect on that date. We deploy tax changes before their effective date, but not within a fixed window.
        TaxDate: DateTime
        /// If `reversal`, this transaction reverses an earlier transaction.
        Type: TaxTransactionType
    }

module TaxTransaction =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "tax.transaction"

    let create
        (
            created: DateTime,
            currency: IsoTypes.IsoCurrencyCode,
            customer: string option,
            customerDetails: TaxProductResourceCustomerDetails,
            id: string,
            livemode: bool,
            metadata: Map<string, string> option,
            postedAt: DateTime,
            reference: string,
            reversal: TaxProductResourceTaxTransactionResourceReversal option,
            shipFromDetails: TaxProductResourceShipFromDetails option,
            shippingCost: TaxProductResourceTaxTransactionShippingCost option,
            taxDate: DateTime,
            ``type``: TaxTransactionType,
            lineItems: TaxTransactionLineItems option option
        ) : TaxTransaction
        =
        {
          Created = created
          Currency = currency
          Customer = customer
          CustomerDetails = customerDetails
          Id = id
          Livemode = livemode
          Metadata = metadata
          PostedAt = postedAt
          Reference = reference
          Reversal = reversal
          ShipFromDetails = shipFromDetails
          ShippingCost = shippingCost
          TaxDate = taxDate
          Type = ``type``
          LineItems = lineItems |> Option.flatten
        }

[<Struct>]
type TaxProductResourceTaxSettingsDefaultsProvider =
    | Anrok
    | Avalara
    | Sphere
    | Stripe

[<Struct>]
type TaxProductResourceTaxSettingsDefaultsTaxBehavior =
    | Exclusive
    | Inclusive
    | InferredByCurrency

type TaxProductResourceTaxSettingsDefaults =
    {
        /// The tax calculation provider this account uses. Defaults to `stripe` when not using a [third-party provider](/tax/third-party-apps).
        Provider: TaxProductResourceTaxSettingsDefaultsProvider
        /// Default [tax behavior](https://stripe.com/docs/tax/products-prices-tax-categories-tax-behavior#tax-behavior) used to specify whether the price is considered inclusive of taxes or exclusive of taxes. If the item's price has a tax behavior set, it will take precedence over the default tax behavior.
        TaxBehavior: TaxProductResourceTaxSettingsDefaultsTaxBehavior option
        /// Default [tax code](https://stripe.com/docs/tax/tax-categories) used to classify your products and prices.
        TaxCode: string option
    }

module TaxProductResourceTaxSettingsDefaults =
    let create
        (
            provider: TaxProductResourceTaxSettingsDefaultsProvider,
            taxBehavior: TaxProductResourceTaxSettingsDefaultsTaxBehavior option,
            taxCode: string option
        ) : TaxProductResourceTaxSettingsDefaults
        =
        {
          Provider = provider
          TaxBehavior = taxBehavior
          TaxCode = taxCode
        }

type TaxProductResourceTaxSettingsHeadOffice = { Address: Address }

module TaxProductResourceTaxSettingsHeadOffice =
    let create
        (
            address: Address
        ) : TaxProductResourceTaxSettingsHeadOffice
        =
        {
          Address = address
        }

type TaxProductResourceTaxSettingsStatusDetailsResourceActive =
    { TaxProductResourceTaxSettingsStatusDetailsResourceActive: string option }

module TaxProductResourceTaxSettingsStatusDetailsResourceActive =
    let create
        (
            taxProductResourceTaxSettingsStatusDetailsResourceActive: string option option
        ) : TaxProductResourceTaxSettingsStatusDetailsResourceActive
        =
        {
          TaxProductResourceTaxSettingsStatusDetailsResourceActive = taxProductResourceTaxSettingsStatusDetailsResourceActive |> Option.flatten
        }

type TaxProductResourceTaxSettingsStatusDetailsResourcePending =
    {
        /// The list of missing fields that are required to perform calculations. It includes the entry `head_office` when the status is `pending`. It is recommended to set the optional values even if they aren't listed as required for calculating taxes. Calculations can fail if missing fields aren't explicitly provided on every call.
        MissingFields: string list option
    }

module TaxProductResourceTaxSettingsStatusDetailsResourcePending =
    let create
        (
            missingFields: string list option
        ) : TaxProductResourceTaxSettingsStatusDetailsResourcePending
        =
        {
          MissingFields = missingFields
        }

type TaxProductResourceTaxSettingsStatusDetails =
    { Active: TaxProductResourceTaxSettingsStatusDetailsResourceActive option
      Pending: TaxProductResourceTaxSettingsStatusDetailsResourcePending option }

module TaxProductResourceTaxSettingsStatusDetails =
    let create
        (
            active: TaxProductResourceTaxSettingsStatusDetailsResourceActive option,
            pending: TaxProductResourceTaxSettingsStatusDetailsResourcePending option
        ) : TaxProductResourceTaxSettingsStatusDetails
        =
        {
          Active = active
          Pending = pending
        }

[<Struct>]
type TaxSettingsStatus =
    | Active
    | Pending

/// You can use Tax `Settings` to manage configurations used by Stripe Tax calculations.
/// Related guide: [Using the Settings API](https://docs.stripe.com/tax/settings-api)
type TaxSettings =
    {
        Defaults: TaxProductResourceTaxSettingsDefaults
        /// The place where your business is located.
        HeadOffice: TaxProductResourceTaxSettingsHeadOffice option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// The status of the Tax `Settings`.
        Status: TaxSettingsStatus
        StatusDetails: TaxProductResourceTaxSettingsStatusDetails
    }

module TaxSettings =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "tax.settings"

    let create
        (
            defaults: TaxProductResourceTaxSettingsDefaults,
            headOffice: TaxProductResourceTaxSettingsHeadOffice option,
            livemode: bool,
            status: TaxSettingsStatus,
            statusDetails: TaxProductResourceTaxSettingsStatusDetails
        ) : TaxSettings
        =
        {
          Defaults = defaults
          HeadOffice = headOffice
          Livemode = livemode
          Status = status
          StatusDetails = statusDetails
        }

/// Occurs whenever tax settings is updated.
type TaxSettingsUpdated = { Object: TaxSettings }

module TaxSettingsUpdated =
    let create
        (
            object: TaxSettings
        ) : TaxSettingsUpdated
        =
        {
          Object = object
        }

type TaxProductRegistrationsResourceCountryOptionsCaProvinceStandard =
    {
        /// Two-letter CA province code ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
        Province: string
    }

module TaxProductRegistrationsResourceCountryOptionsCaProvinceStandard =
    let create
        (
            province: string
        ) : TaxProductRegistrationsResourceCountryOptionsCaProvinceStandard
        =
        {
          Province = province
        }

[<Struct>]
type TaxProductRegistrationsResourceCountryOptionsCanadaType =
    | ProvinceStandard
    | Simplified
    | Standard

type TaxProductRegistrationsResourceCountryOptionsCanada =
    {
        ProvinceStandard: TaxProductRegistrationsResourceCountryOptionsCaProvinceStandard option
        /// Type of registration in Canada.
        Type: TaxProductRegistrationsResourceCountryOptionsCanadaType
    }

module TaxProductRegistrationsResourceCountryOptionsCanada =
    let create
        (
            ``type``: TaxProductRegistrationsResourceCountryOptionsCanadaType,
            provinceStandard: TaxProductRegistrationsResourceCountryOptionsCaProvinceStandard option
        ) : TaxProductRegistrationsResourceCountryOptionsCanada
        =
        {
          Type = ``type``
          ProvinceStandard = provinceStandard
        }

type TaxProductRegistrationsResourceCountryOptionsDefault () = 
    ///Type of registration in `country`.
    member _.Type = "standard"


module TaxProductRegistrationsResourceCountryOptionsDefault =
    ///Type of registration in `country`.
    let ``type`` = "standard"

[<Struct>]
type TaxProductRegistrationsResourceCountryOptionsDefaultStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

type TaxProductRegistrationsResourceCountryOptionsDefaultStandard =
    {
        /// Place of supply scheme used in an Default standard registration.
        PlaceOfSupplyScheme: TaxProductRegistrationsResourceCountryOptionsDefaultStandardPlaceOfSupplyScheme
    }

module TaxProductRegistrationsResourceCountryOptionsDefaultStandard =
    let create
        (
            placeOfSupplyScheme: TaxProductRegistrationsResourceCountryOptionsDefaultStandardPlaceOfSupplyScheme
        ) : TaxProductRegistrationsResourceCountryOptionsDefaultStandard
        =
        {
          PlaceOfSupplyScheme = placeOfSupplyScheme
        }

type TaxProductRegistrationsResourceCountryOptionsDefaultInboundGoods =
    { Standard: TaxProductRegistrationsResourceCountryOptionsDefaultStandard option }

module TaxProductRegistrationsResourceCountryOptionsDefaultInboundGoods =
    ///Type of registration in `country`.
    let ``type`` = "standard"

    let create
        (
            standard: TaxProductRegistrationsResourceCountryOptionsDefaultStandard option
        ) : TaxProductRegistrationsResourceCountryOptionsDefaultInboundGoods
        =
        {
          Standard = standard
        }

[<Struct>]
type TaxProductRegistrationsResourceCountryOptionsEuStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

type TaxProductRegistrationsResourceCountryOptionsEuStandard =
    {
        /// Place of supply scheme used in an EU standard registration.
        PlaceOfSupplyScheme: TaxProductRegistrationsResourceCountryOptionsEuStandardPlaceOfSupplyScheme
    }

module TaxProductRegistrationsResourceCountryOptionsEuStandard =
    let create
        (
            placeOfSupplyScheme: TaxProductRegistrationsResourceCountryOptionsEuStandardPlaceOfSupplyScheme
        ) : TaxProductRegistrationsResourceCountryOptionsEuStandard
        =
        {
          PlaceOfSupplyScheme = placeOfSupplyScheme
        }

[<Struct>]
type TaxProductRegistrationsResourceCountryOptionsEuropeType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

type TaxProductRegistrationsResourceCountryOptionsEurope =
    {
        Standard: TaxProductRegistrationsResourceCountryOptionsEuStandard option
        /// Type of registration in an EU country.
        Type: TaxProductRegistrationsResourceCountryOptionsEuropeType
    }

module TaxProductRegistrationsResourceCountryOptionsEurope =
    let create
        (
            ``type``: TaxProductRegistrationsResourceCountryOptionsEuropeType,
            standard: TaxProductRegistrationsResourceCountryOptionsEuStandard option
        ) : TaxProductRegistrationsResourceCountryOptionsEurope
        =
        {
          Type = ``type``
          Standard = standard
        }

type TaxProductRegistrationsResourceCountryOptionsSimplified () = 
    ///Type of registration in `country`.
    member _.Type = "simplified"


module TaxProductRegistrationsResourceCountryOptionsSimplified =
    ///Type of registration in `country`.
    let ``type`` = "simplified"

type TaxProductRegistrationsResourceCountryOptionsThailand () = 
    ///Type of registration in `country`.
    member _.Type = "simplified"


module TaxProductRegistrationsResourceCountryOptionsThailand =
    ///Type of registration in `country`.
    let ``type`` = "simplified"

[<Struct>]
type TaxProductRegistrationsResourceCountryOptionsUnitedStatesType =
    | LocalAmusementTax
    | LocalLeaseTax
    | StateCommunicationsTax
    | StateRetailDeliveryFee
    | StateSalesTax

type TaxProductRegistrationsResourceCountryOptionsUsLocalAmusementTax =
    {
        /// A [FIPS code](https://www.census.gov/library/reference/code-lists/ansi.html) representing the local jurisdiction.
        Jurisdiction: string
    }

module TaxProductRegistrationsResourceCountryOptionsUsLocalAmusementTax =
    let create
        (
            jurisdiction: string
        ) : TaxProductRegistrationsResourceCountryOptionsUsLocalAmusementTax
        =
        {
          Jurisdiction = jurisdiction
        }

type TaxProductRegistrationsResourceCountryOptionsUsLocalLeaseTax =
    {
        /// A [FIPS code](https://www.census.gov/library/reference/code-lists/ansi.html) representing the local jurisdiction.
        Jurisdiction: string
    }

module TaxProductRegistrationsResourceCountryOptionsUsLocalLeaseTax =
    let create
        (
            jurisdiction: string
        ) : TaxProductRegistrationsResourceCountryOptionsUsLocalLeaseTax
        =
        {
          Jurisdiction = jurisdiction
        }

[<Struct>]
type TaxProductRegistrationsResourceCountryOptionsUsStateSalesTaxElectionType =
    | LocalUseTax
    | SimplifiedSellersUseTax
    | SingleLocalUseTax

type TaxProductRegistrationsResourceCountryOptionsUsStateSalesTaxElection =
    {
        /// A [FIPS code](https://www.census.gov/library/reference/code-lists/ansi.html) representing the local jurisdiction.
        Jurisdiction: string option
        /// The type of the election for the state sales tax registration.
        Type: TaxProductRegistrationsResourceCountryOptionsUsStateSalesTaxElectionType
    }

module TaxProductRegistrationsResourceCountryOptionsUsStateSalesTaxElection =
    let create
        (
            ``type``: TaxProductRegistrationsResourceCountryOptionsUsStateSalesTaxElectionType,
            jurisdiction: string option
        ) : TaxProductRegistrationsResourceCountryOptionsUsStateSalesTaxElection
        =
        {
          Type = ``type``
          Jurisdiction = jurisdiction
        }

type TaxProductRegistrationsResourceCountryOptionsUsStateSalesTax =
    {
        /// Elections for the state sales tax registration.
        Elections: TaxProductRegistrationsResourceCountryOptionsUsStateSalesTaxElection list option
    }

module TaxProductRegistrationsResourceCountryOptionsUsStateSalesTax =
    let create
        (
            elections: TaxProductRegistrationsResourceCountryOptionsUsStateSalesTaxElection list option
        ) : TaxProductRegistrationsResourceCountryOptionsUsStateSalesTax
        =
        {
          Elections = elections
        }

type TaxProductRegistrationsResourceCountryOptionsUnitedStates =
    {
        LocalAmusementTax: TaxProductRegistrationsResourceCountryOptionsUsLocalAmusementTax option
        LocalLeaseTax: TaxProductRegistrationsResourceCountryOptionsUsLocalLeaseTax option
        /// Two-letter US state code ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
        State: string
        StateSalesTax: TaxProductRegistrationsResourceCountryOptionsUsStateSalesTax option
        /// Type of registration in the US.
        Type: TaxProductRegistrationsResourceCountryOptionsUnitedStatesType
    }

module TaxProductRegistrationsResourceCountryOptionsUnitedStates =
    let create
        (
            state: string,
            ``type``: TaxProductRegistrationsResourceCountryOptionsUnitedStatesType,
            localAmusementTax: TaxProductRegistrationsResourceCountryOptionsUsLocalAmusementTax option,
            localLeaseTax: TaxProductRegistrationsResourceCountryOptionsUsLocalLeaseTax option,
            stateSalesTax: TaxProductRegistrationsResourceCountryOptionsUsStateSalesTax option
        ) : TaxProductRegistrationsResourceCountryOptionsUnitedStates
        =
        {
          State = state
          Type = ``type``
          LocalAmusementTax = localAmusementTax
          LocalLeaseTax = localLeaseTax
          StateSalesTax = stateSalesTax
        }

type TaxProductRegistrationsResourceCountryOptions =
    { Ae: TaxProductRegistrationsResourceCountryOptionsDefaultInboundGoods option
      Al: TaxProductRegistrationsResourceCountryOptionsDefault option
      Am: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Ao: TaxProductRegistrationsResourceCountryOptionsDefault option
      At: TaxProductRegistrationsResourceCountryOptionsEurope option
      Au: TaxProductRegistrationsResourceCountryOptionsDefaultInboundGoods option
      Aw: TaxProductRegistrationsResourceCountryOptionsDefault option
      Az: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Ba: TaxProductRegistrationsResourceCountryOptionsDefault option
      Bb: TaxProductRegistrationsResourceCountryOptionsDefault option
      Bd: TaxProductRegistrationsResourceCountryOptionsDefault option
      Be: TaxProductRegistrationsResourceCountryOptionsEurope option
      Bf: TaxProductRegistrationsResourceCountryOptionsDefault option
      Bg: TaxProductRegistrationsResourceCountryOptionsEurope option
      Bh: TaxProductRegistrationsResourceCountryOptionsDefault option
      Bj: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Bs: TaxProductRegistrationsResourceCountryOptionsDefault option
      By: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Ca: TaxProductRegistrationsResourceCountryOptionsCanada option
      Cd: TaxProductRegistrationsResourceCountryOptionsDefault option
      Ch: TaxProductRegistrationsResourceCountryOptionsDefaultInboundGoods option
      Cl: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Cm: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Co: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Cr: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Cv: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Cy: TaxProductRegistrationsResourceCountryOptionsEurope option
      Cz: TaxProductRegistrationsResourceCountryOptionsEurope option
      De: TaxProductRegistrationsResourceCountryOptionsEurope option
      Dk: TaxProductRegistrationsResourceCountryOptionsEurope option
      Ec: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Ee: TaxProductRegistrationsResourceCountryOptionsEurope option
      Eg: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Es: TaxProductRegistrationsResourceCountryOptionsEurope option
      Et: TaxProductRegistrationsResourceCountryOptionsDefault option
      Fi: TaxProductRegistrationsResourceCountryOptionsEurope option
      Fr: TaxProductRegistrationsResourceCountryOptionsEurope option
      Gb: TaxProductRegistrationsResourceCountryOptionsDefaultInboundGoods option
      Ge: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Gn: TaxProductRegistrationsResourceCountryOptionsDefault option
      Gr: TaxProductRegistrationsResourceCountryOptionsEurope option
      Hr: TaxProductRegistrationsResourceCountryOptionsEurope option
      Hu: TaxProductRegistrationsResourceCountryOptionsEurope option
      Id: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Ie: TaxProductRegistrationsResourceCountryOptionsEurope option
      In: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Is: TaxProductRegistrationsResourceCountryOptionsDefault option
      It: TaxProductRegistrationsResourceCountryOptionsEurope option
      Jp: TaxProductRegistrationsResourceCountryOptionsDefaultInboundGoods option
      Ke: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Kg: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Kh: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Kr: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Kz: TaxProductRegistrationsResourceCountryOptionsSimplified option
      La: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Lk: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Lt: TaxProductRegistrationsResourceCountryOptionsEurope option
      Lu: TaxProductRegistrationsResourceCountryOptionsEurope option
      Lv: TaxProductRegistrationsResourceCountryOptionsEurope option
      Ma: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Md: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Me: TaxProductRegistrationsResourceCountryOptionsDefault option
      Mk: TaxProductRegistrationsResourceCountryOptionsDefault option
      Mr: TaxProductRegistrationsResourceCountryOptionsDefault option
      Mt: TaxProductRegistrationsResourceCountryOptionsEurope option
      Mx: TaxProductRegistrationsResourceCountryOptionsSimplified option
      My: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Ng: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Nl: TaxProductRegistrationsResourceCountryOptionsEurope option
      No: TaxProductRegistrationsResourceCountryOptionsDefaultInboundGoods option
      Np: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Nz: TaxProductRegistrationsResourceCountryOptionsDefaultInboundGoods option
      Om: TaxProductRegistrationsResourceCountryOptionsDefault option
      Pe: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Ph: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Pl: TaxProductRegistrationsResourceCountryOptionsEurope option
      Pt: TaxProductRegistrationsResourceCountryOptionsEurope option
      Ro: TaxProductRegistrationsResourceCountryOptionsEurope option
      Rs: TaxProductRegistrationsResourceCountryOptionsDefault option
      Ru: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Sa: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Se: TaxProductRegistrationsResourceCountryOptionsEurope option
      Sg: TaxProductRegistrationsResourceCountryOptionsDefaultInboundGoods option
      Si: TaxProductRegistrationsResourceCountryOptionsEurope option
      Sk: TaxProductRegistrationsResourceCountryOptionsEurope option
      Sn: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Sr: TaxProductRegistrationsResourceCountryOptionsDefault option
      Th: TaxProductRegistrationsResourceCountryOptionsThailand option
      Tj: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Tr: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Tw: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Tz: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Ua: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Ug: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Us: TaxProductRegistrationsResourceCountryOptionsUnitedStates option
      Uy: TaxProductRegistrationsResourceCountryOptionsDefault option
      Uz: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Vn: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Za: TaxProductRegistrationsResourceCountryOptionsDefault option
      Zm: TaxProductRegistrationsResourceCountryOptionsSimplified option
      Zw: TaxProductRegistrationsResourceCountryOptionsDefault option }

module TaxProductRegistrationsResourceCountryOptions =
    let create
        (
            ae: TaxProductRegistrationsResourceCountryOptionsDefaultInboundGoods option,
            al: TaxProductRegistrationsResourceCountryOptionsDefault option,
            am: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            ao: TaxProductRegistrationsResourceCountryOptionsDefault option,
            at: TaxProductRegistrationsResourceCountryOptionsEurope option,
            au: TaxProductRegistrationsResourceCountryOptionsDefaultInboundGoods option,
            aw: TaxProductRegistrationsResourceCountryOptionsDefault option,
            az: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            ba: TaxProductRegistrationsResourceCountryOptionsDefault option,
            bb: TaxProductRegistrationsResourceCountryOptionsDefault option,
            bd: TaxProductRegistrationsResourceCountryOptionsDefault option,
            be: TaxProductRegistrationsResourceCountryOptionsEurope option,
            bf: TaxProductRegistrationsResourceCountryOptionsDefault option,
            bg: TaxProductRegistrationsResourceCountryOptionsEurope option,
            bh: TaxProductRegistrationsResourceCountryOptionsDefault option,
            bj: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            bs: TaxProductRegistrationsResourceCountryOptionsDefault option,
            by: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            ca: TaxProductRegistrationsResourceCountryOptionsCanada option,
            cd: TaxProductRegistrationsResourceCountryOptionsDefault option,
            ch: TaxProductRegistrationsResourceCountryOptionsDefaultInboundGoods option,
            cl: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            cm: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            co: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            cr: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            cv: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            cy: TaxProductRegistrationsResourceCountryOptionsEurope option,
            cz: TaxProductRegistrationsResourceCountryOptionsEurope option,
            de: TaxProductRegistrationsResourceCountryOptionsEurope option,
            dk: TaxProductRegistrationsResourceCountryOptionsEurope option,
            ec: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            ee: TaxProductRegistrationsResourceCountryOptionsEurope option,
            eg: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            es: TaxProductRegistrationsResourceCountryOptionsEurope option,
            et: TaxProductRegistrationsResourceCountryOptionsDefault option,
            fi: TaxProductRegistrationsResourceCountryOptionsEurope option,
            fr: TaxProductRegistrationsResourceCountryOptionsEurope option,
            gb: TaxProductRegistrationsResourceCountryOptionsDefaultInboundGoods option,
            ge: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            gn: TaxProductRegistrationsResourceCountryOptionsDefault option,
            gr: TaxProductRegistrationsResourceCountryOptionsEurope option,
            hr: TaxProductRegistrationsResourceCountryOptionsEurope option,
            hu: TaxProductRegistrationsResourceCountryOptionsEurope option,
            id: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            ie: TaxProductRegistrationsResourceCountryOptionsEurope option,
            ``in``: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            is: TaxProductRegistrationsResourceCountryOptionsDefault option,
            it: TaxProductRegistrationsResourceCountryOptionsEurope option,
            jp: TaxProductRegistrationsResourceCountryOptionsDefaultInboundGoods option,
            ke: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            kg: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            kh: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            kr: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            kz: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            la: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            lk: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            lt: TaxProductRegistrationsResourceCountryOptionsEurope option,
            lu: TaxProductRegistrationsResourceCountryOptionsEurope option,
            lv: TaxProductRegistrationsResourceCountryOptionsEurope option,
            ma: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            md: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            me: TaxProductRegistrationsResourceCountryOptionsDefault option,
            mk: TaxProductRegistrationsResourceCountryOptionsDefault option,
            mr: TaxProductRegistrationsResourceCountryOptionsDefault option,
            mt: TaxProductRegistrationsResourceCountryOptionsEurope option,
            mx: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            my: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            ng: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            nl: TaxProductRegistrationsResourceCountryOptionsEurope option,
            no: TaxProductRegistrationsResourceCountryOptionsDefaultInboundGoods option,
            np: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            nz: TaxProductRegistrationsResourceCountryOptionsDefaultInboundGoods option,
            om: TaxProductRegistrationsResourceCountryOptionsDefault option,
            pe: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            ph: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            pl: TaxProductRegistrationsResourceCountryOptionsEurope option,
            pt: TaxProductRegistrationsResourceCountryOptionsEurope option,
            ro: TaxProductRegistrationsResourceCountryOptionsEurope option,
            rs: TaxProductRegistrationsResourceCountryOptionsDefault option,
            ru: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            sa: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            se: TaxProductRegistrationsResourceCountryOptionsEurope option,
            sg: TaxProductRegistrationsResourceCountryOptionsDefaultInboundGoods option,
            si: TaxProductRegistrationsResourceCountryOptionsEurope option,
            sk: TaxProductRegistrationsResourceCountryOptionsEurope option,
            sn: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            sr: TaxProductRegistrationsResourceCountryOptionsDefault option,
            th: TaxProductRegistrationsResourceCountryOptionsThailand option,
            tj: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            tr: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            tw: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            tz: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            ua: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            ug: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            us: TaxProductRegistrationsResourceCountryOptionsUnitedStates option,
            uy: TaxProductRegistrationsResourceCountryOptionsDefault option,
            uz: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            vn: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            za: TaxProductRegistrationsResourceCountryOptionsDefault option,
            zm: TaxProductRegistrationsResourceCountryOptionsSimplified option,
            zw: TaxProductRegistrationsResourceCountryOptionsDefault option
        ) : TaxProductRegistrationsResourceCountryOptions
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

[<Struct>]
type TaxRegistrationStatus =
    | Active
    | Expired
    | Scheduled

/// A Tax `Registration` lets us know that your business is registered to collect tax on payments within a region, enabling you to [automatically collect tax](https://docs.stripe.com/tax).
/// Stripe doesn't register on your behalf with the relevant authorities when you create a Tax `Registration` object. For more information on how to register to collect tax, see [our guide](https://docs.stripe.com/tax/registering).
/// Related guide: [Using the Registrations API](https://docs.stripe.com/tax/registrations-api)
type TaxRegistration =
    {
        /// Time at which the registration becomes active. Measured in seconds since the Unix epoch.
        ActiveFrom: DateTime
        /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        Country: IsoTypes.IsoCountryCode
        CountryOptions: TaxProductRegistrationsResourceCountryOptions
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// If set, the registration stops being active at this time. If not set, the registration will be active indefinitely. Measured in seconds since the Unix epoch.
        ExpiresAt: DateTime option
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// The status of the registration. This field is present for convenience and can be deduced from `active_from` and `expires_at`.
        Status: TaxRegistrationStatus
    }

module TaxRegistration =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "tax.registration"

    let create
        (
            activeFrom: DateTime,
            country: IsoTypes.IsoCountryCode,
            countryOptions: TaxProductRegistrationsResourceCountryOptions,
            created: DateTime,
            expiresAt: DateTime option,
            id: string,
            livemode: bool,
            status: TaxRegistrationStatus
        ) : TaxRegistration
        =
        {
          ActiveFrom = activeFrom
          Country = country
          CountryOptions = countryOptions
          Created = created
          ExpiresAt = expiresAt
          Id = id
          Livemode = livemode
          Status = status
        }

[<Struct>]
type TaxCalculationLineItemTaxBehavior =
    | Exclusive
    | Inclusive

type TaxCalculationLineItem =
    {
        /// The line item amount in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units). If `tax_behavior=inclusive`, then this amount includes taxes. Otherwise, taxes were calculated on top of this amount.
        Amount: int
        /// The amount of tax calculated for this line item, in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units).
        AmountTax: int
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        /// The ID of an existing [Product](https://docs.stripe.com/api/products/object).
        Product: string option
        /// The number of units of the item being purchased. For reversals, this is the quantity reversed.
        Quantity: int
        /// A custom identifier for this line item.
        Reference: string
        /// Specifies whether the `amount` includes taxes. If `tax_behavior=inclusive`, then the amount includes taxes.
        TaxBehavior: TaxCalculationLineItemTaxBehavior
        /// Detailed account of taxes relevant to this line item.
        TaxBreakdown: TaxProductResourceLineItemTaxBreakdown list option
        /// The [tax code](https://docs.stripe.com/tax/tax-categories) ID used for this resource.
        TaxCode: string
    }

module TaxCalculationLineItem =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "tax.calculation_line_item"

    let create
        (
            amount: int,
            amountTax: int,
            id: string,
            livemode: bool,
            metadata: Map<string, string> option,
            product: string option,
            quantity: int,
            reference: string,
            taxBehavior: TaxCalculationLineItemTaxBehavior,
            taxCode: string,
            taxBreakdown: TaxProductResourceLineItemTaxBreakdown list option option
        ) : TaxCalculationLineItem
        =
        {
          Amount = amount
          AmountTax = amountTax
          Id = id
          Livemode = livemode
          Metadata = metadata
          Product = product
          Quantity = quantity
          Reference = reference
          TaxBehavior = taxBehavior
          TaxCode = taxCode
          TaxBreakdown = taxBreakdown |> Option.flatten
        }

/// The list of items the customer is purchasing.
type TaxCalculationLineItems =
    {
        /// Details about each object.
        Data: TaxCalculationLineItem list
        /// True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        /// The URL where this list can be accessed.
        Url: string
    }

module TaxCalculationLineItems =
    ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
    let object = "list"

    let create
        (
            data: TaxCalculationLineItem list,
            hasMore: bool,
            url: string
        ) : TaxCalculationLineItems
        =
        {
          Data = data
          HasMore = hasMore
          Url = url
        }

type TaxProductResourceTaxBreakdownTaxabilityReason =
    | CustomerExempt
    | NotCollecting
    | NotSubjectToTax
    | NotSupported
    | PortionProductExempt
    | PortionReducedRated
    | PortionStandardRated
    | ProductExempt
    | ProductExemptHoliday
    | ProportionallyRated
    | ReducedRated
    | ReverseCharge
    | StandardRated
    | TaxableBasisReduced
    | ZeroRated

[<Struct>]
type TaxProductResourceTaxRateDetailsRateType =
    | FlatAmount
    | Percentage

type TaxProductResourceTaxRateDetailsTaxType =
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

type TaxProductResourceTaxRateDetails =
    {
        /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        Country: IsoTypes.IsoCountryCode option
        /// The amount of the tax rate when the `rate_type` is `flat_amount`. Tax rates with `rate_type` `percentage` can vary based on the transaction, resulting in this field being `null`. This field exposes the amount and currency of the flat tax rate.
        FlatAmount: TaxRateFlatAmount option
        /// The tax rate percentage as a string. For example, 8.5% is represented as `"8.5"`.
        PercentageDecimal: string
        /// Indicates the type of tax rate applied to the taxable amount. This value can be `null` when no tax applies to the location. This field is only present for TaxRates created by Stripe Tax.
        RateType: TaxProductResourceTaxRateDetailsRateType option
        /// State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
        State: string option
        /// The tax type, such as `vat` or `sales_tax`.
        TaxType: TaxProductResourceTaxRateDetailsTaxType option
    }

module TaxProductResourceTaxRateDetails =
    let create
        (
            country: IsoTypes.IsoCountryCode option,
            flatAmount: TaxRateFlatAmount option,
            percentageDecimal: string,
            rateType: TaxProductResourceTaxRateDetailsRateType option,
            state: string option,
            taxType: TaxProductResourceTaxRateDetailsTaxType option
        ) : TaxProductResourceTaxRateDetails
        =
        {
          Country = country
          FlatAmount = flatAmount
          PercentageDecimal = percentageDecimal
          RateType = rateType
          State = state
          TaxType = taxType
        }

type TaxProductResourceTaxBreakdown =
    {
        /// The amount of tax, in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units).
        Amount: int
        /// Specifies whether the tax amount is included in the line item amount.
        Inclusive: bool
        TaxRateDetails: TaxProductResourceTaxRateDetails
        /// The reasoning behind this tax, for example, if the product is tax exempt. We might extend the possible values for this field to support new tax rules.
        TaxabilityReason: TaxProductResourceTaxBreakdownTaxabilityReason
        /// The amount on which tax is calculated, in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units).
        TaxableAmount: int
    }

module TaxProductResourceTaxBreakdown =
    let create
        (
            amount: int,
            inclusive: bool,
            taxRateDetails: TaxProductResourceTaxRateDetails,
            taxabilityReason: TaxProductResourceTaxBreakdownTaxabilityReason,
            taxableAmount: int
        ) : TaxProductResourceTaxBreakdown
        =
        {
          Amount = amount
          Inclusive = inclusive
          TaxRateDetails = taxRateDetails
          TaxabilityReason = taxabilityReason
          TaxableAmount = taxableAmount
        }

[<Struct>]
type TaxProductResourceTaxCalculationShippingCostTaxBehavior =
    | Exclusive
    | Inclusive

type TaxProductResourceTaxCalculationShippingCost =
    {
        /// The shipping amount in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units). If `tax_behavior=inclusive`, then this amount includes taxes. Otherwise, taxes were calculated on top of this amount.
        Amount: int
        /// The amount of tax calculated for shipping, in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units).
        AmountTax: int
        /// The ID of an existing [ShippingRate](https://docs.stripe.com/api/shipping_rates/object).
        ShippingRate: string option
        /// Specifies whether the `amount` includes taxes. If `tax_behavior=inclusive`, then the amount includes taxes.
        TaxBehavior: TaxProductResourceTaxCalculationShippingCostTaxBehavior
        /// Detailed account of taxes relevant to shipping cost.
        TaxBreakdown: TaxProductResourceLineItemTaxBreakdown list option
        /// The [tax code](https://docs.stripe.com/tax/tax-categories) ID used for shipping.
        TaxCode: string
    }

module TaxProductResourceTaxCalculationShippingCost =
    let create
        (
            amount: int,
            amountTax: int,
            taxBehavior: TaxProductResourceTaxCalculationShippingCostTaxBehavior,
            taxCode: string,
            shippingRate: string option,
            taxBreakdown: TaxProductResourceLineItemTaxBreakdown list option
        ) : TaxProductResourceTaxCalculationShippingCost
        =
        {
          Amount = amount
          AmountTax = amountTax
          TaxBehavior = taxBehavior
          TaxCode = taxCode
          ShippingRate = shippingRate
          TaxBreakdown = taxBreakdown
        }

/// A Tax Calculation allows you to calculate the tax to collect from your customer.
/// Related guide: [Calculate tax in your custom payment flow](https://docs.stripe.com/tax/custom)
type TaxCalculation =
    {
        /// Total amount after taxes in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units).
        AmountTotal: int
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// The ID of an existing [Customer](https://docs.stripe.com/api/customers/object) used for the resource.
        Customer: string option
        CustomerDetails: TaxProductResourceCustomerDetails
        /// Timestamp of date at which the tax calculation will expire.
        ExpiresAt: DateTime option
        /// Unique identifier for the calculation.
        Id: string option
        /// The list of items the customer is purchasing.
        LineItems: TaxCalculationLineItems option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// The details of the ship from location, such as the address.
        ShipFromDetails: TaxProductResourceShipFromDetails option
        /// The shipping cost details for the calculation.
        ShippingCost: TaxProductResourceTaxCalculationShippingCost option
        /// The amount of tax to be collected on top of the line item prices.
        TaxAmountExclusive: int
        /// The amount of tax already included in the line item prices.
        TaxAmountInclusive: int
        /// Breakdown of individual tax amounts that add up to the total.
        TaxBreakdown: TaxProductResourceTaxBreakdown list
        /// The calculation uses the tax rules and rates that are in effect at this timestamp. You can use a date up to 31 days in the past or up to 31 days in the future. If you use a future date, Stripe doesn't guarantee that the expected tax rules and rate being used match the actual rules and rate that will be in effect on that date. We deploy tax changes before their effective date, but not within a fixed window.
        TaxDate: DateTime
    }

module TaxCalculation =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "tax.calculation"

    let create
        (
            amountTotal: int,
            currency: IsoTypes.IsoCurrencyCode,
            customer: string option,
            customerDetails: TaxProductResourceCustomerDetails,
            expiresAt: DateTime option,
            id: string option,
            livemode: bool,
            shipFromDetails: TaxProductResourceShipFromDetails option,
            shippingCost: TaxProductResourceTaxCalculationShippingCost option,
            taxAmountExclusive: int,
            taxAmountInclusive: int,
            taxBreakdown: TaxProductResourceTaxBreakdown list,
            taxDate: DateTime,
            lineItems: TaxCalculationLineItems option option
        ) : TaxCalculation
        =
        {
          AmountTotal = amountTotal
          Currency = currency
          Customer = customer
          CustomerDetails = customerDetails
          ExpiresAt = expiresAt
          Id = id
          Livemode = livemode
          ShipFromDetails = shipFromDetails
          ShippingCost = shippingCost
          TaxAmountExclusive = taxAmountExclusive
          TaxAmountInclusive = taxAmountInclusive
          TaxBreakdown = taxBreakdown
          TaxDate = taxDate
          LineItems = lineItems |> Option.flatten
        }

type TaxProductResourceTaxAssociationTransactionAttemptsResourceCommitted =
    {
        /// The [Tax Transaction](https://docs.stripe.com/api/tax/transaction/object)
        Transaction: string
    }

module TaxProductResourceTaxAssociationTransactionAttemptsResourceCommitted =
    let create
        (
            transaction: string
        ) : TaxProductResourceTaxAssociationTransactionAttemptsResourceCommitted
        =
        {
          Transaction = transaction
        }

[<Struct>]
type TaxProductResourceTaxAssociationTransactionAttemptsResourceErroredReason =
    | AnotherPaymentAssociatedWithCalculation
    | CalculationExpired
    | CurrencyMismatch
    | OriginalTransactionVoided
    | UniqueReferenceViolation

type TaxProductResourceTaxAssociationTransactionAttemptsResourceErrored =
    {
        /// Details on why we couldn't commit the tax transaction.
        Reason: TaxProductResourceTaxAssociationTransactionAttemptsResourceErroredReason
    }

module TaxProductResourceTaxAssociationTransactionAttemptsResourceErrored =
    let create
        (
            reason: TaxProductResourceTaxAssociationTransactionAttemptsResourceErroredReason
        ) : TaxProductResourceTaxAssociationTransactionAttemptsResourceErrored
        =
        {
          Reason = reason
        }

[<Struct>]
type TaxProductResourceTaxAssociationTransactionAttemptsStatus =
    | Errored
    | Committed

type TaxProductResourceTaxAssociationTransactionAttempts =
    {
        Committed: TaxProductResourceTaxAssociationTransactionAttemptsResourceCommitted option
        Errored: TaxProductResourceTaxAssociationTransactionAttemptsResourceErrored option
        /// The source of the tax transaction attempt. This is either a refund or a payment intent.
        Source: string
        /// The status of the transaction attempt. This can be `errored` or `committed`.
        Status: TaxProductResourceTaxAssociationTransactionAttemptsStatus
    }

module TaxProductResourceTaxAssociationTransactionAttempts =
    let create
        (
            source: string,
            status: TaxProductResourceTaxAssociationTransactionAttemptsStatus,
            committed: TaxProductResourceTaxAssociationTransactionAttemptsResourceCommitted option,
            errored: TaxProductResourceTaxAssociationTransactionAttemptsResourceErrored option
        ) : TaxProductResourceTaxAssociationTransactionAttempts
        =
        {
          Source = source
          Status = status
          Committed = committed
          Errored = errored
        }

/// A Tax Association exposes the Tax Transactions that Stripe attempted to create on your behalf based on the PaymentIntent input
type TaxAssociation =
    {
        /// The [Tax Calculation](https://docs.stripe.com/api/tax/calculations/object) that was included in PaymentIntent.
        Calculation: string
        /// Unique identifier for the object.
        Id: string
        /// The [PaymentIntent](https://docs.stripe.com/api/payment_intents/object) that this Tax Association is tracking.
        PaymentIntent: string
        /// Information about the tax transactions linked to this payment intent
        TaxTransactionAttempts: TaxProductResourceTaxAssociationTransactionAttempts list option
    }

module TaxAssociation =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "tax.association"

    let create
        (
            calculation: string,
            id: string,
            paymentIntent: string,
            taxTransactionAttempts: TaxProductResourceTaxAssociationTransactionAttempts list option
        ) : TaxAssociation
        =
        {
          Calculation = calculation
          Id = id
          PaymentIntent = paymentIntent
          TaxTransactionAttempts = taxTransactionAttempts
        }

[<Struct>]
type TaxIdVerificationStatus =
    | Pending
    | Unavailable
    | Unverified
    | Verified

type TaxIdVerification =
    {
        /// Verification status, one of `pending`, `verified`, `unverified`, or `unavailable`.
        Status: TaxIdVerificationStatus
        /// Verified address.
        VerifiedAddress: string option
        /// Verified name.
        VerifiedName: string option
    }

module TaxIdVerification =
    let create
        (
            status: TaxIdVerificationStatus,
            verifiedAddress: string option,
            verifiedName: string option
        ) : TaxIdVerification
        =
        {
          Status = status
          VerifiedAddress = verifiedAddress
          VerifiedName = verifiedName
        }

/// [Tax codes](https://stripe.com/docs/tax/tax-categories) classify goods and services for tax purposes.
type TaxCode =
    {
        /// A detailed description of which types of products the tax code represents.
        Description: string
        /// Unique identifier for the object.
        Id: string
        /// A short name for the tax code.
        Name: string
    }

module TaxCode =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "tax_code"

    let create
        (
            description: string,
            id: string,
            name: string
        ) : TaxCode
        =
        {
          Description = description
          Id = id
          Name = name
        }

type TaxDeductedAtSource =
    {
        /// Unique identifier for the object.
        Id: string
        /// The end of the invoicing period. This TDS applies to Stripe fees collected during this invoicing period.
        PeriodEnd: DateTime
        /// The start of the invoicing period. This TDS applies to Stripe fees collected during this invoicing period.
        PeriodStart: DateTime
        /// The TAN that was supplied to Stripe when TDS was assessed
        TaxDeductionAccountNumber: string
    }

module TaxDeductedAtSource =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "tax_deducted_at_source"

    let create
        (
            id: string,
            periodEnd: DateTime,
            periodStart: DateTime,
            taxDeductionAccountNumber: string
        ) : TaxDeductedAtSource
        =
        {
          Id = id
          PeriodEnd = periodEnd
          PeriodStart = periodStart
          TaxDeductionAccountNumber = taxDeductionAccountNumber
        }

