namespace Stripe.Price

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Custom
open Stripe.Deleted
open Stripe.Entitlements
open Stripe.Package
open Stripe.Recurring
open Stripe.Tax
open Stripe.Transform

/// A product_feature represents an attachment between a feature and a product.
/// When a product is purchased that has a feature attached, Stripe will create an entitlement to the feature for the purchasing customer.
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type ProductFeature =
    {
        EntitlementFeature: EntitlementsFeature
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
    }

[<Struct>]
type PriceBillingScheme =
    | PerUnit
    | Tiered

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

type ProductMarketingFeature =
    {
        /// The marketing feature name. Up to 80 characters long.
        Name: string option
    }

type ProductTaxCode'AnyOf =
    | String of string
    | TaxCode of TaxCode

[<Struct>]
type ProductType =
    | Good
    | Service

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

and PriceProduct'AnyOf =
    | String of string
    | Product of Product
    | DeletedProduct of DeletedProduct

/// Products describe the specific goods or services you offer to your customers.
/// For example, you might offer a Standard and Premium version of your goods or service; each version would be a separate Product.
/// They can be used in conjunction with [Prices](https://api.stripe.com#prices) to configure pricing in Payment Links, Checkout, and Subscriptions.
/// Related guides: [Set up a subscription](https://docs.stripe.com/billing/subscriptions/set-up-subscription),
/// [share a Payment Link](https://docs.stripe.com/payment-links),
/// [accept payments with Checkout](https://docs.stripe.com/payments/accept-a-payment#create-product-prices-upfront),
/// and more about [Products and Prices](https://docs.stripe.com/products-prices/overview)
and Product =
    {
        /// Whether the product is currently available for purchase.
        Active: bool
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// The ID of the [Price](https://docs.stripe.com/api/prices) object that is the default price for this product.
        DefaultPrice: ProductDefaultPrice'AnyOf option
        /// The product's description, meant to be displayable to the customer. Use this field to optionally store a long form explanation of the product being sold for your own rendering purposes.
        Description: string option
        /// Unique identifier for the object.
        Id: string
        /// A list of up to 8 URLs of images for this product, meant to be displayable to the customer.
        Images: string list
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// A list of up to 15 marketing features for this product. These are displayed in [pricing tables](https://docs.stripe.com/payments/checkout/pricing-table).
        MarketingFeatures: ProductMarketingFeature list
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        /// The product's name, meant to be displayable to the customer.
        Name: string
        /// The dimensions of this product for shipping purposes.
        PackageDimensions: PackageDimensions option
        /// Whether this product is shipped (i.e., physical goods).
        Shippable: bool option
        /// Extra information about a product which will appear on your customer's credit card statement. In the case that multiple products are billed at once, the first statement descriptor will be used. Only used for subscription payments.
        StatementDescriptor: string option
        /// A [tax code](https://docs.stripe.com/tax/tax-categories) ID.
        TaxCode: ProductTaxCode'AnyOf option
        /// The type of the product. The product is either of type `good`, which is eligible for use with Orders and SKUs, or `service`, which is eligible for use with Subscriptions and Plans.
        Type: ProductType
        /// A label that represents units of this product. When set, this will be included in customers' receipts, invoices, Checkout, and the customer portal.
        UnitLabel: string option
        /// Time at which the object was last updated. Measured in seconds since the Unix epoch.
        Updated: DateTime
        /// A URL of a publicly-accessible webpage for this product.
        Url: string option
    }

and ProductDefaultPrice'AnyOf =
    | String of string
    | Price of Price

/// Occurs whenever a product is updated.
type ProductUpdated = { Object: Product }

/// Occurs whenever a product is deleted.
type ProductDeleted = { Object: Product }

/// Occurs whenever a product is created.
type ProductCreated = { Object: Product }

/// Occurs whenever a price is updated.
type PriceUpdated = { Object: Price }

/// Occurs whenever a price is deleted.
type PriceDeleted = { Object: Price }

/// Occurs whenever a price is created.
type PriceCreated = { Object: Price }

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

module ProductFeature =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "product_feature"

module Price =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "price"

module Product =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "product"

