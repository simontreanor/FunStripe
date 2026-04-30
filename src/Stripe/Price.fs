namespace Stripe.Price

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Product

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type CustomUnitAmount =
    {
        /// The maximum unit amount the customer can specify for this item.
        Maximum: int option
        /// The minimum unit amount the customer can specify for this item. Must be at least the minimum charge amount.
        Minimum: int option
        /// The starting unit amount which can be updated by the customer.
        Preset: int option
    }

[<Struct>]
type PriceBillingScheme =
    | PerUnit
    | Tiered

type PriceProduct'AnyOf =
    | String of string
    | Product of Product
    | DeletedProduct of DeletedProduct

[<Struct>]
type PriceTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

type PriceTier =
    {
        /// Price for the entire tier.
        FlatAmount: int option
        /// Same as `flat_amount`, but contains a decimal value with at most 12 decimal places.
        FlatAmountDecimal: string option
        /// Per unit price for units relevant to the tier.
        UnitAmount: int option
        /// Same as `unit_amount`, but contains a decimal value with at most 12 decimal places.
        UnitAmountDecimal: string option
        /// Up to and including to this quantity will be contained in the tier.
        UpTo: int option
    }

[<Struct>]
type PriceTiersMode =
    | Graduated
    | Volume

[<Struct>]
type PriceType =
    | OneTime
    | Recurring

[<Struct>]
type RecurringInterval =
    | Day
    | Month
    | Week
    | Year

[<Struct>]
type RecurringUsageType =
    | Licensed
    | Metered

type Recurring =
    {
        /// The frequency at which a subscription is billed. One of `day`, `week`, `month` or `year`.
        Interval: RecurringInterval
        /// The number of intervals (specified in the `interval` attribute) between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months.
        IntervalCount: int
        /// The meter tracking the usage of a metered price
        Meter: string option
        /// Default number of trial days when subscribing a customer to this price using [`trial_from_plan=true`](https://docs.stripe.com/api#create_subscription-trial_from_plan).
        TrialPeriodDays: int option
        /// Configures how the quantity per period should be determined. Can be either `metered` or `licensed`. `licensed` automatically bills the `quantity` set when adding it to a subscription. `metered` aggregates the total usage based on usage records. Defaults to `licensed`.
        UsageType: RecurringUsageType
    }

[<Struct>]
type TransformQuantityRound =
    | Down
    | Up

type TransformQuantity =
    {
        /// Divide usage by this number.
        DivideBy: int
        /// After division, either round the result `up` or `down`.
        Round: TransformQuantityRound
    }

/// Prices define the unit cost, currency, and (optional) billing cycle for both recurring and one-time purchases of products.
/// [Products](https://api.stripe.com#products) help you track inventory or provisioning, and prices help you track payment terms. Different physical goods or levels of service should be represented by products, and pricing options should be represented by prices. This approach lets you change prices without having to change your provisioning scheme.
/// For example, you might have a single "gold" product that has prices for $10/month, $100/year, and €9 once.
/// Related guides: [Set up a subscription](https://docs.stripe.com/billing/subscriptions/set-up-subscription), [create an invoice](https://docs.stripe.com/billing/invoices/create), and more about [products and prices](https://docs.stripe.com/products-prices/overview).
type Price =
    {
        /// Whether the price can be used for new purchases.
        Active: bool
        /// Describes how to compute the price per period. Either `per_unit` or `tiered`. `per_unit` indicates that the fixed amount (specified in `unit_amount` or `unit_amount_decimal`) will be charged per unit in `quantity` (for prices with `usage_type=licensed`), or per unit of total usage (for prices with `usage_type=metered`). `tiered` indicates that the unit pricing will be computed using a tiering strategy as defined using the `tiers` and `tiers_mode` attributes.
        BillingScheme: PriceBillingScheme
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// Prices defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
        CurrencyOptions: Map<string, string list> option
        /// When set, provides configuration for the amount to be adjusted by the customer during Checkout Sessions and Payment Links.
        CustomUnitAmount: CustomUnitAmount option
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// A lookup key used to retrieve prices dynamically from a static string. This may be up to 200 characters.
        LookupKey: string option
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        /// A brief description of the price, hidden from customers.
        Nickname: string option
        /// The ID of the product this price is associated with.
        Product: PriceProduct'AnyOf
        /// The recurring components of a price such as `interval` and `usage_type`.
        Recurring: Recurring option
        /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
        TaxBehavior: PriceTaxBehavior option
        /// Each element represents a pricing tier. This parameter requires `billing_scheme` to be set to `tiered`. See also the documentation for `billing_scheme`.
        Tiers: PriceTier list option
        /// Defines if the tiering price should be `graduated` or `volume` based. In `volume`-based tiering, the maximum quantity within a period determines the per unit price. In `graduated` tiering, pricing can change as the quantity grows.
        TiersMode: PriceTiersMode option
        /// Apply a transformation to the reported usage or set quantity before computing the amount billed. Cannot be combined with `tiers`.
        TransformQuantity: TransformQuantity option
        /// One of `one_time` or `recurring` depending on whether the price is for a one-time purchase or a recurring (subscription) purchase.
        Type: PriceType
        /// The unit amount in cents (or local equivalent) to be charged, represented as a whole integer if possible. Only set if `billing_scheme=per_unit`.
        UnitAmount: int option
        /// The unit amount in cents (or local equivalent) to be charged, represented as a decimal string with at most 12 decimal places. Only set if `billing_scheme=per_unit`.
        UnitAmountDecimal: string option
    }

module Price =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "price"

/// Occurs whenever a price is updated.
type PriceUpdated = { Object: Price }

/// Occurs whenever a price is deleted.
type PriceDeleted = { Object: Price }

/// Occurs whenever a price is created.
type PriceCreated = { Object: Price }

type DeletedPrice =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedPrice =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "price"

[<Struct>]
type CurrencyOptionTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

type CurrencyOption =
    {
        /// When set, provides configuration for the amount to be adjusted by the customer during Checkout Sessions and Payment Links.
        CustomUnitAmount: CustomUnitAmount option
        /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
        TaxBehavior: CurrencyOptionTaxBehavior option
        /// Each element represents a pricing tier. This parameter requires `billing_scheme` to be set to `tiered`. See also the documentation for `billing_scheme`.
        Tiers: PriceTier list option
        /// The unit amount in cents (or local equivalent) to be charged, represented as a whole integer if possible. Only set if `billing_scheme=per_unit`.
        UnitAmount: int option
        /// The unit amount in cents (or local equivalent) to be charged, represented as a decimal string with at most 12 decimal places. Only set if `billing_scheme=per_unit`.
        UnitAmountDecimal: string option
    }

