namespace Stripe.ShippingRate

open System.Text.Json.Serialization
open FunStripe
open System

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
type ShippingRateDeliveryEstimateBoundUnit =
    | BusinessDay
    | Day
    | Hour
    | Month
    | Week

type ShippingRateDeliveryEstimateBound =
    {
        /// A unit of time.
        Unit: ShippingRateDeliveryEstimateBoundUnit
        /// Must be greater than 0.
        Value: int
    }

type ShippingRateDeliveryEstimateBound with
    static member New(unit: ShippingRateDeliveryEstimateBoundUnit, value: int) =
        {
            Unit = unit
            Value = value
        }

type ShippingRateDeliveryEstimate =
    {
        /// The upper bound of the estimated range. If empty, represents no upper bound i.e., infinite.
        Maximum: ShippingRateDeliveryEstimateBound option
        /// The lower bound of the estimated range. If empty, represents no lower bound.
        Minimum: ShippingRateDeliveryEstimateBound option
    }

type ShippingRateDeliveryEstimate with
    static member New(maximum: ShippingRateDeliveryEstimateBound option, minimum: ShippingRateDeliveryEstimateBound option) =
        {
            Maximum = maximum
            Minimum = minimum
        }

type ShippingRateFixedAmount =
    {
        /// A non-negative integer in cents representing how much to charge.
        Amount: int
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// Shipping rates defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
        CurrencyOptions: Map<string, string list> option
    }

type ShippingRateFixedAmount with
    static member New(amount: int, currency: IsoTypes.IsoCurrencyCode, ?currencyOptions: Map<string, string list>) =
        {
            Amount = amount
            Currency = currency
            CurrencyOptions = currencyOptions
        }

[<Struct>]
type ShippingRateTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

/// Shipping rates describe the price of shipping presented to your customers and
/// applied to a purchase. For more information, see [Charge for shipping](https://docs.stripe.com/payments/during-payment/charge-shipping).
type ShippingRate =
    {
        /// Whether the shipping rate can be used for new purchases. Defaults to `true`.
        Active: bool
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// The estimated range for how long shipping will take, meant to be displayable to the customer. This will appear on CheckoutSessions.
        DeliveryEstimate: ShippingRateDeliveryEstimate option
        /// The name of the shipping rate, meant to be displayable to the customer. This will appear on CheckoutSessions.
        DisplayName: string option
        FixedAmount: ShippingRateFixedAmount option
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        /// Specifies whether the rate is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`.
        TaxBehavior: ShippingRateTaxBehavior option
        /// A [tax code](https://docs.stripe.com/tax/tax-categories) ID. The Shipping tax code is `txcd_92010001`.
        TaxCode: StripeId<Markers.TaxCode> option
    }

type ShippingRate with
    static member New(active: bool, created: DateTime, deliveryEstimate: ShippingRateDeliveryEstimate option, displayName: string option, id: string, livemode: bool, metadata: Map<string, string>, taxBehavior: ShippingRateTaxBehavior option, taxCode: StripeId<Markers.TaxCode> option, ?fixedAmount: ShippingRateFixedAmount) =
        {
            Active = active
            Created = created
            DeliveryEstimate = deliveryEstimate
            DisplayName = displayName
            Id = id
            Livemode = livemode
            Metadata = metadata
            TaxBehavior = taxBehavior
            TaxCode = taxCode
            FixedAmount = fixedAmount
        }

module ShippingRate =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "shipping_rate"

    ///The type of calculation to use on the shipping rate.
    let ``type`` = "fixed_amount"

[<Struct>]
type ShippingRateCurrencyOptionTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

type ShippingRateCurrencyOption =
    {
        /// A non-negative integer in cents representing how much to charge.
        Amount: int
        /// Specifies whether the rate is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`.
        TaxBehavior: ShippingRateCurrencyOptionTaxBehavior
    }

type ShippingRateCurrencyOption with
    static member New(amount: int, taxBehavior: ShippingRateCurrencyOptionTaxBehavior) =
        {
            Amount = amount
            TaxBehavior = taxBehavior
        }

