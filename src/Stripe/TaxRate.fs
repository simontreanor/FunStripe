namespace Stripe.TaxRate

open System.Text.Json.Serialization
open FunStripe
open System

/// The amount of the tax rate when the `rate_type`` is `flat_amount`. Tax rates with `rate_type` `percentage` can vary based on the transaction, resulting in this field being `null`. This field exposes the amount and currency of the flat tax rate.
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
type TaxRateFlatAmount =
    {
        /// Amount of the tax when the `rate_type` is `flat_amount`. This positive integer represents how much to charge in the smallest currency unit (e.g., 100 cents to charge $1.00 or 100 to charge ¥100, a zero-decimal currency). The amount value supports up to eight digits (e.g., a value of 99999999 for a USD charge of $999,999.99).
        Amount: int
        /// Three-letter ISO currency code, in lowercase.
        Currency: IsoTypes.IsoCurrencyCode
    }

type TaxRateFlatAmount with
    static member New(amount: int, currency: IsoTypes.IsoCurrencyCode) =
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

type TaxRate with
    static member New(active: bool, country: IsoTypes.IsoCountryCode option, created: DateTime, description: string option, displayName: string, effectivePercentage: decimal option, flatAmount: TaxRateFlatAmount option, id: string, inclusive: bool, jurisdiction: string option, jurisdictionLevel: TaxRateJurisdictionLevel option, livemode: bool, metadata: Map<string, string> option, percentage: decimal, rateType: TaxRateRateType option, state: string option, taxType: TaxRateTaxType option) =
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

module TaxRate =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "tax_rate"

/// Occurs whenever a tax rate is updated.
type TaxRateUpdated = { Object: TaxRate }

type TaxRateUpdated with
    static member New(object: TaxRate) =
        {
            Object = object
        }

/// Occurs whenever a new tax rate is created.
type TaxRateCreated = { Object: TaxRate }

type TaxRateCreated with
    static member New(object: TaxRate) =
        {
            Object = object
        }

