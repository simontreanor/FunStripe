namespace Stripe.Shipping

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Address
open Stripe.Tax

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
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

module ShippingRateCurrencyOption =
    let create
        (
            amount: int,
            taxBehavior: ShippingRateCurrencyOptionTaxBehavior
        ) : ShippingRateCurrencyOption
        =
        {
          Amount = amount
          TaxBehavior = taxBehavior
        }

[<Struct>]
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

module ShippingRateDeliveryEstimateBound =
    let create
        (
            unit: ShippingRateDeliveryEstimateBoundUnit,
            value: int
        ) : ShippingRateDeliveryEstimateBound
        =
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

module ShippingRateDeliveryEstimate =
    let create
        (
            maximum: ShippingRateDeliveryEstimateBound option,
            minimum: ShippingRateDeliveryEstimateBound option
        ) : ShippingRateDeliveryEstimate
        =
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

module ShippingRateFixedAmount =
    let create
        (
            amount: int,
            currency: IsoTypes.IsoCurrencyCode
        ) : ShippingRateFixedAmount
        =
        {
          Amount = amount
          Currency = currency
          CurrencyOptions = None
        }

[<Struct>]
type ShippingRateTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

type ShippingRateTaxCode'AnyOf =
    | String of string
    | TaxCode of TaxCode

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
        TaxCode: ShippingRateTaxCode'AnyOf option
    }

module ShippingRate =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "shipping_rate"

    ///The type of calculation to use on the shipping rate.
    let ``type`` = "fixed_amount"

    let create
        (
            active: bool,
            created: DateTime,
            deliveryEstimate: ShippingRateDeliveryEstimate option,
            displayName: string option,
            id: string,
            livemode: bool,
            metadata: Map<string, string>,
            taxBehavior: ShippingRateTaxBehavior option,
            taxCode: ShippingRateTaxCode'AnyOf option
        ) : ShippingRate
        =
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
          FixedAmount = None
        }

type Shipping =
    {
        Address: Address option
        /// The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc.
        Carrier: string option
        /// Recipient name.
        Name: string option
        /// Recipient phone (including extension).
        Phone: string option
        /// The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
        TrackingNumber: string option
    }

module Shipping =
    let create
        (
            address: Address option,
            carrier: string option option,
            name: string option,
            phone: string option option,
            trackingNumber: string option option
        ) : Shipping
        =
        {
          Address = address
          Carrier = carrier |> Option.flatten
          Name = name
          Phone = phone |> Option.flatten
          TrackingNumber = trackingNumber |> Option.flatten
        }

