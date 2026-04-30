namespace Stripe.Discount

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.PaymentMethod

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type DiscountsResourceStackableDiscountWithDiscountEnd =
    {
        /// ID of the coupon to create a new discount for.
        Coupon: StripeId<Markers.Coupon> option
        /// ID of an existing discount on the object (or one of its ancestors) to reuse.
        Discount: StripeId<Markers.Discount> option
        /// ID of the promotion code to create a new discount for.
        PromotionCode: StripeId<Markers.PromotionCode> option
    }

type DeletedDiscountCustomer'AnyOf =
    | String of string
    | Customer of Customer
    | DeletedCustomer of DeletedCustomer

type DiscountSource =
    {
        /// The coupon that was redeemed to create this discount.
        Coupon: StripeId<Markers.Coupon> option
    }

module DiscountSource =
    ///The source type of the discount.
    let ``type`` = "coupon"

type DeletedDiscount =
    {
        /// The Checkout session that this coupon is applied to, if it is applied to a particular session in payment mode. Will not be present for subscription mode.
        CheckoutSession: string option
        /// The ID of the customer associated with this discount.
        Customer: DeletedDiscountCustomer'AnyOf option
        /// The ID of the account representing the customer associated with this discount.
        CustomerAccount: string option
        /// Always true for a deleted object
        Deleted: bool
        /// The ID of the discount object. Discounts cannot be fetched by ID. Use `expand[]=discounts` in API calls to expand discount IDs in an array.
        Id: string
        /// The invoice that the discount's coupon was applied to, if it was applied directly to a particular invoice.
        Invoice: string option
        /// The invoice item `id` (or invoice line item `id` for invoice line items of type='subscription') that the discount's coupon was applied to, if it was applied directly to a particular invoice item or invoice line item.
        InvoiceItem: string option
        /// The promotion code applied to create this discount.
        PromotionCode: StripeId<Markers.PromotionCode> option
        Source: DiscountSource
        /// Date that the coupon was applied.
        Start: DateTime
        /// The subscription that this coupon is applied to, if it is applied to a particular subscription.
        Subscription: string option
        /// The subscription item that this coupon is applied to, if it is applied to a particular subscription item.
        SubscriptionItem: string option
    }

module DeletedDiscount =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "discount"

type DiscountCustomer'AnyOf =
    | String of string
    | Customer of Customer
    | DeletedCustomer of DeletedCustomer

/// A discount represents the actual application of a [coupon](https://api.stripe.com#coupons) or [promotion code](https://api.stripe.com#promotion_codes).
/// It contains information about when the discount began, when it will end, and what it is applied to.
/// Related guide: [Applying discounts to subscriptions](https://docs.stripe.com/billing/subscriptions/discounts)
type Discount =
    {
        /// The Checkout session that this coupon is applied to, if it is applied to a particular session in payment mode. Will not be present for subscription mode.
        CheckoutSession: string option
        /// The ID of the customer associated with this discount.
        Customer: DiscountCustomer'AnyOf option
        /// The ID of the account representing the customer associated with this discount.
        CustomerAccount: string option
        /// If the coupon has a duration of `repeating`, the date that this discount will end. If the coupon has a duration of `once` or `forever`, this attribute will be null.
        End: DateTime option
        /// The ID of the discount object. Discounts cannot be fetched by ID. Use `expand[]=discounts` in API calls to expand discount IDs in an array.
        Id: string
        /// The invoice that the discount's coupon was applied to, if it was applied directly to a particular invoice.
        Invoice: string option
        /// The invoice item `id` (or invoice line item `id` for invoice line items of type='subscription') that the discount's coupon was applied to, if it was applied directly to a particular invoice item or invoice line item.
        InvoiceItem: string option
        /// The promotion code applied to create this discount.
        PromotionCode: StripeId<Markers.PromotionCode> option
        Source: DiscountSource
        /// Date that the coupon was applied.
        Start: DateTime
        /// The subscription that this coupon is applied to, if it is applied to a particular subscription.
        Subscription: string option
        /// The subscription item that this coupon is applied to, if it is applied to a particular subscription item.
        SubscriptionItem: string option
    }

module Discount =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "discount"

type DiscountsResourceDiscountAmountDiscount'AnyOf =
    | String of string
    | Discount of Discount
    | DeletedDiscount of DeletedDiscount

type DiscountsResourceDiscountAmount =
    {
        /// The amount, in cents (or local equivalent), of the discount.
        Amount: int
        /// The discount that was applied to get this discount amount.
        Discount: DiscountsResourceDiscountAmountDiscount'AnyOf
    }

