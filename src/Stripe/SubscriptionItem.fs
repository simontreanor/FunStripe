namespace Stripe.SubscriptionItem

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Plan
open Stripe.Price
open Stripe.TaxRate

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
type DeletedSubscriptionItem =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

type DeletedSubscriptionItem with
    static member New(deleted: bool, id: string) =
        {
            Deleted = deleted
            Id = id
        }

module DeletedSubscriptionItem =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "subscription_item"

type SubscriptionItemBillingThresholds =
    {
        /// Usage threshold that triggers the subscription to create an invoice
        UsageGte: int option
    }

type SubscriptionItemBillingThresholds with
    static member New(usageGte: int option) =
        {
            UsageGte = usageGte
        }

/// Subscription items allow you to create customer subscriptions with more than
/// one plan, making it easy to represent complex billing relationships.
type SubscriptionItem =
    {
        /// Define thresholds at which an invoice will be sent, and the related subscription advanced to a new billing period
        BillingThresholds: SubscriptionItemBillingThresholds option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: int
        /// The end time of this subscription item's current billing period.
        CurrentPeriodEnd: DateTime
        /// The start time of this subscription item's current billing period.
        CurrentPeriodStart: DateTime
        /// The discounts applied to the subscription item. Subscription item discounts are applied before subscription discounts. Use `expand[]=discounts` to expand each discount.
        Discounts: StripeId<Markers.Discount> list
        /// Unique identifier for the object.
        Id: string
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        Plan: Plan
        Price: Price
        /// The [quantity](https://docs.stripe.com/subscriptions/quantities) of the plan to which the customer should be subscribed.
        Quantity: int option
        /// The `subscription` this `subscription_item` belongs to.
        Subscription: string
        /// The tax rates which apply to this `subscription_item`. When set, the `default_tax_rates` on the subscription do not apply to this `subscription_item`.
        TaxRates: TaxRate list option
    }

type SubscriptionItem with
    static member New(billingThresholds: SubscriptionItemBillingThresholds option, created: int, currentPeriodEnd: DateTime, currentPeriodStart: DateTime, discounts: StripeId<Markers.Discount> list, id: string, metadata: Map<string, string>, plan: Plan, price: Price, subscription: string, taxRates: TaxRate list option, ?quantity: int) =
        {
            BillingThresholds = billingThresholds
            Created = created
            CurrentPeriodEnd = currentPeriodEnd
            CurrentPeriodStart = currentPeriodStart
            Discounts = discounts
            Id = id
            Metadata = metadata
            Plan = plan
            Price = price
            Subscription = subscription
            TaxRates = taxRates
            Quantity = quantity
        }

module SubscriptionItem =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "subscription_item"

/// List of subscription items, each with an attached price.
type SubscriptionItems =
    {
        /// Details about each object.
        Data: SubscriptionItem list
        /// True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        /// The URL where this list can be accessed.
        Url: string
    }

type SubscriptionItems with
    static member New(data: SubscriptionItem list, hasMore: bool, url: string) =
        {
            Data = data
            HasMore = hasMore
            Url = url
        }

module SubscriptionItems =
    ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
    let object = "list"

