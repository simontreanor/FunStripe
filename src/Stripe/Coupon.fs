namespace Stripe.Coupon

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type DeletedCoupon =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedCoupon =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "coupon"

type CouponCurrencyOption =
    {
        /// Amount (in the `currency` specified) that will be taken off the subtotal of any invoices for this customer.
        AmountOff: int
    }

type CouponAppliesTo =
    {
        /// A list of product IDs this coupon applies to
        Products: string list
    }

[<Struct>]
type CouponDuration =
    | Forever
    | Once
    | Repeating

/// A coupon contains information about a percent-off or amount-off discount you
/// might want to apply to a customer. Coupons may be applied to [subscriptions](https://api.stripe.com#subscriptions), [invoices](https://api.stripe.com#invoices),
/// [checkout sessions](https://docs.stripe.com/api/checkout/sessions), [quotes](https://api.stripe.com#quotes), and more. Coupons do not work with conventional one-off [charges](/api/charges/create) or [payment intents](https://docs.stripe.com/api/payment_intents).
type Coupon =
    {
        /// Amount (in the `currency` specified) that will be taken off the subtotal of any invoices for this customer.
        AmountOff: int option
        AppliesTo: CouponAppliesTo option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// If `amount_off` has been set, the three-letter [ISO code for the currency](https://stripe.com/docs/currencies) of the amount to take off.
        Currency: IsoTypes.IsoCurrencyCode option
        /// Coupons defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
        CurrencyOptions: Map<string, string list> option
        /// One of `forever`, `once`, or `repeating`. Describes how long a customer who applies this coupon will get the discount.
        Duration: CouponDuration
        /// If `duration` is `repeating`, the number of months the coupon applies. Null if coupon `duration` is `forever` or `once`.
        DurationInMonths: int option
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Maximum number of times this coupon can be redeemed, in total, across all customers, before it is no longer valid.
        MaxRedemptions: int option
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        /// Name of the coupon displayed to customers on for instance invoices or receipts.
        Name: string option
        /// Percent that will be taken off the subtotal of any invoices for this customer for the duration of the coupon. For example, a coupon with percent_off of 50 will make a $ (or local equivalent)100 invoice $ (or local equivalent)50 instead.
        PercentOff: decimal option
        /// Date after which the coupon can no longer be redeemed.
        RedeemBy: DateTime option
        /// Number of times this coupon has been applied to a customer.
        TimesRedeemed: int
        /// Taking account of the above properties, whether this coupon can still be applied to a customer.
        Valid: bool
    }

module Coupon =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "coupon"

/// Occurs whenever a coupon is updated.
type CouponUpdated = { Object: Coupon }

/// Occurs whenever a coupon is deleted.
type CouponDeleted = { Object: Coupon }

/// Occurs whenever a coupon is created.
type CouponCreated = { Object: Coupon }

