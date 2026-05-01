namespace Stripe.PromotionCode

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.PaymentMethod

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type PromotionCodeCurrencyOption =
    {
        /// Minimum amount required to redeem this Promotion Code into a Coupon (e.g., a purchase must be $100 or more to work).
        MinimumAmount: int
    }

type PromotionCodeCurrencyOption with
    static member New(minimumAmount: int) =
        {
            MinimumAmount = minimumAmount
        }

type PromotionCodeCustomer'AnyOf =
    | String of string
    | Customer of Customer
    | DeletedCustomer of DeletedCustomer

type PromotionCodesResourcePromotion =
    {
        /// If promotion `type` is `coupon`, the coupon for this promotion.
        Coupon: StripeId<Markers.Coupon> option
    }

type PromotionCodesResourcePromotion with
    static member New(coupon: StripeId<Markers.Coupon> option) =
        {
            Coupon = coupon
        }

module PromotionCodesResourcePromotion =
    ///The type of promotion.
    let ``type`` = "coupon"

type PromotionCodesResourceRestrictions =
    {
        /// Promotion code restrictions defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
        CurrencyOptions: Map<string, string list> option
        /// A Boolean indicating if the Promotion Code should only be redeemed for Customers without any successful payments or invoices
        FirstTimeTransaction: bool
        /// Minimum amount required to redeem this Promotion Code into a Coupon (e.g., a purchase must be $100 or more to work).
        MinimumAmount: int option
        /// Three-letter [ISO code](https://stripe.com/docs/currencies) for minimum_amount
        MinimumAmountCurrency: IsoTypes.IsoCurrencyCode option
    }

type PromotionCodesResourceRestrictions with
    static member New(firstTimeTransaction: bool, minimumAmount: int option, minimumAmountCurrency: IsoTypes.IsoCurrencyCode option, ?currencyOptions: Map<string, string list>) =
        {
            FirstTimeTransaction = firstTimeTransaction
            MinimumAmount = minimumAmount
            MinimumAmountCurrency = minimumAmountCurrency
            CurrencyOptions = currencyOptions
        }

/// A Promotion Code represents a customer-redeemable code for an underlying promotion.
/// You can create multiple codes for a single promotion.
/// If you enable promotion codes in your [customer portal configuration](https://docs.stripe.com/customer-management/configure-portal), then customers can redeem a code themselves when updating a subscription in the portal.
/// Customers can also view the currently active promotion codes and coupons on each of their subscriptions in the portal.
type PromotionCode =
    {
        /// Whether the promotion code is currently active. A promotion code is only active if the coupon is also valid.
        Active: bool
        /// The customer-facing code. Regardless of case, this code must be unique across all active promotion codes for each customer. Valid characters are lower case letters (a-z), upper case letters (A-Z), digits (0-9), and dashes (-).
        Code: string
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// The customer who can use this promotion code.
        Customer: PromotionCodeCustomer'AnyOf option
        /// The account representing the customer who can use this promotion code.
        CustomerAccount: string option
        /// Date at which the promotion code can no longer be redeemed.
        ExpiresAt: DateTime option
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Maximum number of times this promotion code can be redeemed.
        MaxRedemptions: int option
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        Promotion: PromotionCodesResourcePromotion
        Restrictions: PromotionCodesResourceRestrictions
        /// Number of times this promotion code has been used.
        TimesRedeemed: int
    }

type PromotionCode with
    static member New(active: bool, code: string, created: DateTime, customer: PromotionCodeCustomer'AnyOf option, customerAccount: string option, expiresAt: DateTime option, id: string, livemode: bool, maxRedemptions: int option, metadata: Map<string, string> option, promotion: PromotionCodesResourcePromotion, restrictions: PromotionCodesResourceRestrictions, timesRedeemed: int) =
        {
            Active = active
            Code = code
            Created = created
            Customer = customer
            CustomerAccount = customerAccount
            ExpiresAt = expiresAt
            Id = id
            Livemode = livemode
            MaxRedemptions = maxRedemptions
            Metadata = metadata
            Promotion = promotion
            Restrictions = restrictions
            TimesRedeemed = timesRedeemed
        }

module PromotionCode =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "promotion_code"

/// Occurs whenever a promotion code is updated.
type PromotionCodeUpdated = { Object: PromotionCode }

type PromotionCodeUpdated with
    static member New(object: PromotionCode) =
        {
            Object = object
        }

/// Occurs whenever a promotion code is created.
type PromotionCodeCreated = { Object: PromotionCode }

type PromotionCodeCreated with
    static member New(object: PromotionCode) =
        {
            Object = object
        }

