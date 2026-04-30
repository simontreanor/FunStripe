namespace Stripe.Entitlements

open System.Text.Json.Serialization
open FunStripe
open System

/// A feature represents a monetizable ability or functionality in your system.
/// Features can be assigned to products, and when those products are purchased, Stripe will create an entitlement to the feature for the purchasing customer.
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type EntitlementsFeature =
    {
        /// Inactive features cannot be attached to new products and will not be returned from the features list endpoint.
        Active: bool
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// A unique key you provide as your own system identifier. This may be up to 80 characters.
        LookupKey: string
        /// Set of key-value pairs that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        /// The feature's name, for your own purpose, not meant to be displayable to the customer.
        Name: string
    }

module EntitlementsFeature =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "entitlements.feature"

/// An active entitlement describes access to a feature for a customer.
type EntitlementsActiveEntitlement =
    {
        /// The [Feature](https://docs.stripe.com/api/entitlements/feature) that the customer is entitled to.
        Feature: StripeId<Markers.EntitlementsFeature>
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// A unique key you provide as your own system identifier. This may be up to 80 characters.
        LookupKey: string
    }

module EntitlementsActiveEntitlement =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "entitlements.active_entitlement"

/// The list of entitlements this customer has.
type EntitlementsActiveEntitlementSummaryEntitlements =
    {
        Data: EntitlementsActiveEntitlement list
        /// True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        /// The URL where this list can be accessed.
        Url: string
    }

module EntitlementsActiveEntitlementSummaryEntitlements =
    ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
    let object = "list"

/// A summary of a customer's active entitlements.
type EntitlementsActiveEntitlementSummary =
    {
        /// The customer that is entitled to this feature.
        Customer: string
        /// The list of entitlements this customer has.
        Entitlements: EntitlementsActiveEntitlementSummaryEntitlements
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
    }

module EntitlementsActiveEntitlementSummary =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "entitlements.active_entitlement_summary"

/// Occurs whenever a customer's entitlements change.
type EntitlementsActiveEntitlementSummaryUpdated =
    { Object: EntitlementsActiveEntitlementSummary }

