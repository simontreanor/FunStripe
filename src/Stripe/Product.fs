namespace Stripe.Product

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
type DeletedProduct =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

type DeletedProduct with
    static member New(deleted: bool, id: string) =
        {
            Deleted = deleted
            Id = id
        }

module DeletedProduct =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "product"

type PackageDimensions =
    {
        /// Height, in inches.
        Height: decimal
        /// Length, in inches.
        Length: decimal
        /// Weight, in ounces.
        Weight: decimal
        /// Width, in inches.
        Width: decimal
    }

type PackageDimensions with
    static member New(height: decimal, length: decimal, weight: decimal, width: decimal) =
        {
            Height = height
            Length = length
            Weight = weight
            Width = width
        }

type ProductMarketingFeature =
    {
        /// The marketing feature name. Up to 80 characters long.
        Name: string option
    }

type ProductMarketingFeature with
    static member New(?name: string) =
        {
            Name = name
        }

[<Struct>]
type ProductType =
    | Good
    | Service

/// Products describe the specific goods or services you offer to your customers.
/// For example, you might offer a Standard and Premium version of your goods or service; each version would be a separate Product.
/// They can be used in conjunction with [Prices](https://api.stripe.com#prices) to configure pricing in Payment Links, Checkout, and Subscriptions.
/// Related guides: [Set up a subscription](https://docs.stripe.com/billing/subscriptions/set-up-subscription),
/// [share a Payment Link](https://docs.stripe.com/payment-links),
/// [accept payments with Checkout](https://docs.stripe.com/payments/accept-a-payment#create-product-prices-upfront),
/// and more about [Products and Prices](https://docs.stripe.com/products-prices/overview)
type Product =
    {
        /// Whether the product is currently available for purchase.
        Active: bool
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// The ID of the [Price](https://docs.stripe.com/api/prices) object that is the default price for this product.
        DefaultPrice: StripeId<Markers.Price> option
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
        TaxCode: StripeId<Markers.TaxCode> option
        /// The type of the product. The product is either of type `good`, which is eligible for use with Orders and SKUs, or `service`, which is eligible for use with Subscriptions and Plans.
        Type: ProductType
        /// A label that represents units of this product. When set, this will be included in customers' receipts, invoices, Checkout, and the customer portal.
        UnitLabel: string option
        /// Time at which the object was last updated. Measured in seconds since the Unix epoch.
        Updated: DateTime
        /// A URL of a publicly-accessible webpage for this product.
        Url: string option
    }

type Product with
    static member New(active: bool, created: DateTime, description: string option, id: string, images: string list, livemode: bool, marketingFeatures: ProductMarketingFeature list, metadata: Map<string, string>, name: string, packageDimensions: PackageDimensions option, shippable: bool option, ``type``: ProductType, updated: DateTime, url: string option, ?defaultPrice: StripeId<Markers.Price> option, ?statementDescriptor: string option, ?taxCode: StripeId<Markers.TaxCode> option, ?unitLabel: string option) =
        {
            Active = active
            Created = created
            Description = description
            Id = id
            Images = images
            Livemode = livemode
            MarketingFeatures = marketingFeatures
            Metadata = metadata
            Name = name
            PackageDimensions = packageDimensions
            Shippable = shippable
            Type = ``type``
            Updated = updated
            Url = url
            DefaultPrice = defaultPrice |> Option.flatten
            StatementDescriptor = statementDescriptor |> Option.flatten
            TaxCode = taxCode |> Option.flatten
            UnitLabel = unitLabel |> Option.flatten
        }

module Product =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "product"

/// Occurs whenever a product is created.
type ProductCreated = { Object: Product }

type ProductCreated with
    static member New(object: Product) =
        {
            Object = object
        }

/// Occurs whenever a product is deleted.
type ProductDeleted = { Object: Product }

type ProductDeleted with
    static member New(object: Product) =
        {
            Object = object
        }

/// Occurs whenever a product is updated.
type ProductUpdated = { Object: Product }

type ProductUpdated with
    static member New(object: Product) =
        {
            Object = object
        }

