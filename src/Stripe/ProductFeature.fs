namespace Stripe.ProductFeature

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Entitlements

/// A product_feature represents an attachment between a feature and a product.
/// When a product is purchased that has a feature attached, Stripe will create an entitlement to the feature for the purchasing customer.
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
type ProductFeature =
    {
        EntitlementFeature: EntitlementsFeature
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
    }

type ProductFeature with
    static member New(entitlementFeature: EntitlementsFeature, id: string, livemode: bool) =
        {
            EntitlementFeature = entitlementFeature
            Id = id
            Livemode = livemode
        }

module ProductFeature =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "product_feature"

type DeletedProductFeature =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

type DeletedProductFeature with
    static member New(deleted: bool, id: string) =
        {
            Deleted = deleted
            Id = id
        }

module DeletedProductFeature =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "product_feature"

