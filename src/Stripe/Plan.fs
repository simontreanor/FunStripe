namespace Stripe.Plan

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Product

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
type PlanBillingScheme =
    | PerUnit
    | Tiered

[<Struct>]
type PlanInterval =
    | Day
    | Month
    | Week
    | Year

type PlanProduct'AnyOf =
    | String of string
    | Product of Product
    | DeletedProduct of DeletedProduct

type PlanTier =
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

type PlanTier with
    static member New(flatAmount: int option, flatAmountDecimal: string option, unitAmount: int option, unitAmountDecimal: string option, upTo: int option) =
        {
            FlatAmount = flatAmount
            FlatAmountDecimal = flatAmountDecimal
            UnitAmount = unitAmount
            UnitAmountDecimal = unitAmountDecimal
            UpTo = upTo
        }

[<Struct>]
type PlanTiersMode =
    | Graduated
    | Volume

[<Struct>]
type PlanUsageType =
    | Licensed
    | Metered

[<Struct>]
type TransformUsageRound =
    | Down
    | Up

type TransformUsage =
    {
        /// Divide usage by this number.
        DivideBy: int
        /// After division, either round the result `up` or `down`.
        Round: TransformUsageRound
    }

type TransformUsage with
    static member New(divideBy: int, round: TransformUsageRound) =
        {
            DivideBy = divideBy
            Round = round
        }

/// You can now model subscriptions more flexibly using the [Prices API](https://api.stripe.com#prices). It replaces the Plans API and is backwards compatible to simplify your migration.
/// Plans define the base price, currency, and billing cycle for recurring purchases of products.
/// [Products](https://api.stripe.com#products) help you track inventory or provisioning, and plans help you track pricing. Different physical goods or levels of service should be represented by products, and pricing options should be represented by plans. This approach lets you change prices without having to change your provisioning scheme.
/// For example, you might have a single "gold" product that has plans for $10/month, $100/year, €9/month, and €90/year.
/// Related guides: [Set up a subscription](https://docs.stripe.com/billing/subscriptions/set-up-subscription) and more about [products and prices](https://docs.stripe.com/products-prices/overview).
type Plan =
    {
        /// Whether the plan can be used for new purchases.
        Active: bool
        /// The unit amount in cents (or local equivalent) to be charged, represented as a whole integer if possible. Only set if `billing_scheme=per_unit`.
        Amount: int option
        /// The unit amount in cents (or local equivalent) to be charged, represented as a decimal string with at most 12 decimal places. Only set if `billing_scheme=per_unit`.
        AmountDecimal: string option
        /// Describes how to compute the price per period. Either `per_unit` or `tiered`. `per_unit` indicates that the fixed amount (specified in `amount`) will be charged per unit in `quantity` (for plans with `usage_type=licensed`), or per unit of total usage (for plans with `usage_type=metered`). `tiered` indicates that the unit pricing will be computed using a tiering strategy as defined using the `tiers` and `tiers_mode` attributes.
        BillingScheme: PlanBillingScheme
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// Unique identifier for the object.
        Id: string
        /// The frequency at which a subscription is billed. One of `day`, `week`, `month` or `year`.
        Interval: PlanInterval
        /// The number of intervals (specified in the `interval` attribute) between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months.
        IntervalCount: int
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        /// The meter tracking the usage of a metered price
        Meter: string option
        /// A brief description of the plan, hidden from customers.
        Nickname: string option
        /// The product whose pricing this plan determines.
        Product: PlanProduct'AnyOf option
        /// Each element represents a pricing tier. This parameter requires `billing_scheme` to be set to `tiered`. See also the documentation for `billing_scheme`.
        Tiers: PlanTier list option
        /// Defines if the tiering price should be `graduated` or `volume` based. In `volume`-based tiering, the maximum quantity within a period determines the per unit price. In `graduated` tiering, pricing can change as the quantity grows.
        TiersMode: PlanTiersMode option
        /// Apply a transformation to the reported usage or set quantity before computing the amount billed. Cannot be combined with `tiers`.
        TransformUsage: TransformUsage option
        /// Default number of trial days when subscribing a customer to this plan using [`trial_from_plan=true`](https://docs.stripe.com/api#create_subscription-trial_from_plan).
        TrialPeriodDays: int option
        /// Configures how the quantity per period should be determined. Can be either `metered` or `licensed`. `licensed` automatically bills the `quantity` set when adding it to a subscription. `metered` aggregates the total usage based on usage records. Defaults to `licensed`.
        UsageType: PlanUsageType
    }

type Plan with
    static member New(active: bool, amount: int option, amountDecimal: string option, billingScheme: PlanBillingScheme, created: DateTime, currency: IsoTypes.IsoCurrencyCode, id: string, interval: PlanInterval, intervalCount: int, livemode: bool, metadata: Map<string, string> option, meter: string option, nickname: string option, product: PlanProduct'AnyOf option, tiersMode: PlanTiersMode option, transformUsage: TransformUsage option, trialPeriodDays: int option, usageType: PlanUsageType, ?tiers: PlanTier list) =
        {
            Active = active
            Amount = amount
            AmountDecimal = amountDecimal
            BillingScheme = billingScheme
            Created = created
            Currency = currency
            Id = id
            Interval = interval
            IntervalCount = intervalCount
            Livemode = livemode
            Metadata = metadata
            Meter = meter
            Nickname = nickname
            Product = product
            TiersMode = tiersMode
            TransformUsage = transformUsage
            TrialPeriodDays = trialPeriodDays
            UsageType = usageType
            Tiers = tiers
        }

module Plan =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "plan"

/// Occurs whenever a plan is updated.
type PlanUpdated = { Object: Plan }

type PlanUpdated with
    static member New(object: Plan) =
        {
            Object = object
        }

/// Occurs whenever a plan is deleted.
type PlanDeleted = { Object: Plan }

type PlanDeleted with
    static member New(object: Plan) =
        {
            Object = object
        }

/// Occurs whenever a plan is created.
type PlanCreated = { Object: Plan }

type PlanCreated with
    static member New(object: Plan) =
        {
            Object = object
        }

type DeletedPlan =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

type DeletedPlan with
    static member New(deleted: bool, id: string) =
        {
            Deleted = deleted
            Id = id
        }

module DeletedPlan =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "plan"

