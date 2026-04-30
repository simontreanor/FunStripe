namespace Stripe.CustomerSession

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.PaymentMethod

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type CustomerSessionCustomer'AnyOf =
    | String of string
    | Customer of Customer

/// This hash contains whether the buy button is enabled.
type CustomerSessionResourceComponentsResourceBuyButton =
    {
        /// Whether the buy button is enabled.
        Enabled: bool
    }

[<Struct>]
type CustomerSessionResourceComponentsResourceCustomerSheetResourceFeaturesPaymentMethodAllowRedisplayFilters =
    | Always
    | Limited
    | Unspecified

[<Struct>]
type CustomerSessionResourceComponentsResourceCustomerSheetResourceFeaturesPaymentMethodRemove =
    | Disabled
    | Enabled

/// This hash contains the features the customer sheet supports.
type CustomerSessionResourceComponentsResourceCustomerSheetResourceFeatures =
    {
        /// A list of [`allow_redisplay`](https://docs.stripe.com/api/payment_methods/object#payment_method_object-allow_redisplay) values that controls which saved payment methods the customer sheet displays by filtering to only show payment methods with an `allow_redisplay` value that is present in this list.
        /// If not specified, defaults to ["always"]. In order to display all saved payment methods, specify ["always", "limited", "unspecified"].
        PaymentMethodAllowRedisplayFilters:
            CustomerSessionResourceComponentsResourceCustomerSheetResourceFeaturesPaymentMethodAllowRedisplayFilters list option
        /// Controls whether the customer sheet displays the option to remove a saved payment method."
        /// Allowing buyers to remove their saved payment methods impacts subscriptions that depend on that payment method. Removing the payment method detaches the [`customer` object](https://docs.stripe.com/api/payment_methods/object#payment_method_object-customer) from that [PaymentMethod](https://docs.stripe.com/api/payment_methods).
        PaymentMethodRemove:
            CustomerSessionResourceComponentsResourceCustomerSheetResourceFeaturesPaymentMethodRemove option
    }

/// This hash contains whether the customer sheet is enabled and the features it supports.
type CustomerSessionResourceComponentsResourceCustomerSheet =
    {
        /// Whether the customer sheet is enabled.
        Enabled: bool
        /// This hash defines whether the customer sheet supports certain features.
        Features: CustomerSessionResourceComponentsResourceCustomerSheetResourceFeatures option
    }

[<Struct>]
type CustomerSessionResourceComponentsResourceMobilePaymentElementResourceFeaturesPaymentMethodAllowRedisplayFilters =
    | Always
    | Limited
    | Unspecified

[<Struct>]
type CustomerSessionResourceComponentsResourceMobilePaymentElementResourceFeaturesPaymentMethodRedisplay =
    | Disabled
    | Enabled

[<Struct>]
type CustomerSessionResourceComponentsResourceMobilePaymentElementResourceFeaturesPaymentMethodRemove =
    | Disabled
    | Enabled

[<Struct>]
type CustomerSessionResourceComponentsResourceMobilePaymentElementResourceFeaturesPaymentMethodSave =
    | Disabled
    | Enabled

[<Struct>]
type CustomerSessionResourceComponentsResourceMobilePaymentElementResourceFeaturesPaymentMethodSaveAllowRedisplayOverride
    =
    | Always
    | Limited
    | Unspecified

/// This hash contains the features the mobile payment element supports.
type CustomerSessionResourceComponentsResourceMobilePaymentElementResourceFeatures =
    {
        /// A list of [`allow_redisplay`](https://docs.stripe.com/api/payment_methods/object#payment_method_object-allow_redisplay) values that controls which saved payment methods the mobile payment element displays by filtering to only show payment methods with an `allow_redisplay` value that is present in this list.
        /// If not specified, defaults to ["always"]. In order to display all saved payment methods, specify ["always", "limited", "unspecified"].
        PaymentMethodAllowRedisplayFilters:
            CustomerSessionResourceComponentsResourceMobilePaymentElementResourceFeaturesPaymentMethodAllowRedisplayFilters list option
        /// Controls whether or not the mobile payment element shows saved payment methods.
        PaymentMethodRedisplay:
            CustomerSessionResourceComponentsResourceMobilePaymentElementResourceFeaturesPaymentMethodRedisplay option
        /// Controls whether the mobile payment element displays the option to remove a saved payment method."
        /// Allowing buyers to remove their saved payment methods impacts subscriptions that depend on that payment method. Removing the payment method detaches the [`customer` object](https://docs.stripe.com/api/payment_methods/object#payment_method_object-customer) from that [PaymentMethod](https://docs.stripe.com/api/payment_methods).
        PaymentMethodRemove:
            CustomerSessionResourceComponentsResourceMobilePaymentElementResourceFeaturesPaymentMethodRemove option
        /// Controls whether the mobile payment element displays a checkbox offering to save a new payment method.
        /// If a customer checks the box, the [`allow_redisplay`](https://docs.stripe.com/api/payment_methods/object#payment_method_object-allow_redisplay) value on the PaymentMethod is set to `'always'` at confirmation time. For PaymentIntents, the [`setup_future_usage`](https://docs.stripe.com/api/payment_intents/object#payment_intent_object-setup_future_usage) value is also set to the value defined in `payment_method_save_usage`.
        PaymentMethodSave:
            CustomerSessionResourceComponentsResourceMobilePaymentElementResourceFeaturesPaymentMethodSave option
        /// Allows overriding the value of allow_override when saving a new payment method when payment_method_save is set to disabled. Use values: "always", "limited", or "unspecified".
        /// If not specified, defaults to `nil` (no override value).
        PaymentMethodSaveAllowRedisplayOverride:
            CustomerSessionResourceComponentsResourceMobilePaymentElementResourceFeaturesPaymentMethodSaveAllowRedisplayOverride option
    }

/// This hash contains whether the mobile payment element is enabled and the features it supports.
type CustomerSessionResourceComponentsResourceMobilePaymentElement =
    {
        /// Whether the mobile payment element is enabled.
        Enabled: bool
        /// This hash defines whether the mobile payment element supports certain features.
        Features: CustomerSessionResourceComponentsResourceMobilePaymentElementResourceFeatures option
    }

[<Struct>]
type CustomerSessionResourceComponentsResourcePaymentElementResourceFeaturesPaymentMethodAllowRedisplayFilters =
    | Always
    | Limited
    | Unspecified

[<Struct>]
type CustomerSessionResourceComponentsResourcePaymentElementResourceFeaturesPaymentMethodRedisplay =
    | Disabled
    | Enabled

[<Struct>]
type CustomerSessionResourceComponentsResourcePaymentElementResourceFeaturesPaymentMethodRemove =
    | Disabled
    | Enabled

[<Struct>]
type CustomerSessionResourceComponentsResourcePaymentElementResourceFeaturesPaymentMethodSave =
    | Disabled
    | Enabled

[<Struct>]
type CustomerSessionResourceComponentsResourcePaymentElementResourceFeaturesPaymentMethodSaveUsage =
    | OffSession
    | OnSession

/// This hash contains the features the Payment Element supports.
type CustomerSessionResourceComponentsResourcePaymentElementResourceFeatures =
    {
        /// A list of [`allow_redisplay`](https://docs.stripe.com/api/payment_methods/object#payment_method_object-allow_redisplay) values that controls which saved payment methods the Payment Element displays by filtering to only show payment methods with an `allow_redisplay` value that is present in this list.
        /// If not specified, defaults to ["always"]. In order to display all saved payment methods, specify ["always", "limited", "unspecified"].
        PaymentMethodAllowRedisplayFilters:
            CustomerSessionResourceComponentsResourcePaymentElementResourceFeaturesPaymentMethodAllowRedisplayFilters list
        /// Controls whether or not the Payment Element shows saved payment methods. This parameter defaults to `disabled`.
        PaymentMethodRedisplay:
            CustomerSessionResourceComponentsResourcePaymentElementResourceFeaturesPaymentMethodRedisplay
        /// Determines the max number of saved payment methods for the Payment Element to display. This parameter defaults to `3`. The maximum redisplay limit is `10`.
        PaymentMethodRedisplayLimit: int option
        /// Controls whether the Payment Element displays the option to remove a saved payment method. This parameter defaults to `disabled`.
        /// Allowing buyers to remove their saved payment methods impacts subscriptions that depend on that payment method. Removing the payment method detaches the [`customer` object](https://docs.stripe.com/api/payment_methods/object#payment_method_object-customer) from that [PaymentMethod](https://docs.stripe.com/api/payment_methods).
        PaymentMethodRemove: CustomerSessionResourceComponentsResourcePaymentElementResourceFeaturesPaymentMethodRemove
        /// Controls whether the Payment Element displays a checkbox offering to save a new payment method. This parameter defaults to `disabled`.
        /// If a customer checks the box, the [`allow_redisplay`](https://docs.stripe.com/api/payment_methods/object#payment_method_object-allow_redisplay) value on the PaymentMethod is set to `'always'` at confirmation time. For PaymentIntents, the [`setup_future_usage`](https://docs.stripe.com/api/payment_intents/object#payment_intent_object-setup_future_usage) value is also set to the value defined in `payment_method_save_usage`.
        PaymentMethodSave: CustomerSessionResourceComponentsResourcePaymentElementResourceFeaturesPaymentMethodSave
        /// When using PaymentIntents and the customer checks the save checkbox, this field determines the [`setup_future_usage`](https://docs.stripe.com/api/payment_intents/object#payment_intent_object-setup_future_usage) value used to confirm the PaymentIntent.
        /// When using SetupIntents, directly configure the [`usage`](https://docs.stripe.com/api/setup_intents/object#setup_intent_object-usage) value on SetupIntent creation.
        PaymentMethodSaveUsage:
            CustomerSessionResourceComponentsResourcePaymentElementResourceFeaturesPaymentMethodSaveUsage option
    }

/// This hash contains whether the Payment Element is enabled and the features it supports.
type CustomerSessionResourceComponentsResourcePaymentElement =
    {
        /// Whether the Payment Element is enabled.
        Enabled: bool
        /// This hash defines whether the Payment Element supports certain features.
        Features: CustomerSessionResourceComponentsResourcePaymentElementResourceFeatures option
    }

/// This hash contains whether the pricing table is enabled.
type CustomerSessionResourceComponentsResourcePricingTable =
    {
        /// Whether the pricing table is enabled.
        Enabled: bool
    }

/// Configuration for the components supported by this Customer Session.
type CustomerSessionResourceComponents =
    { BuyButton: CustomerSessionResourceComponentsResourceBuyButton
      CustomerSheet: CustomerSessionResourceComponentsResourceCustomerSheet
      MobilePaymentElement: CustomerSessionResourceComponentsResourceMobilePaymentElement
      PaymentElement: CustomerSessionResourceComponentsResourcePaymentElement
      PricingTable: CustomerSessionResourceComponentsResourcePricingTable }

/// A Customer Session allows you to grant Stripe's frontend SDKs (like Stripe.js) client-side access
/// control over a Customer.
/// Related guides: [Customer Session with the Payment Element](/payments/accept-a-payment-deferred?platform=web&type=payment#save-payment-methods),
/// [Customer Session with the Pricing Table](/payments/checkout/pricing-table#customer-session),
/// [Customer Session with the Buy Button](/payment-links/buy-button#pass-an-existing-customer).
type CustomerSession =
    {
        /// The client secret of this Customer Session. Used on the client to set up secure access to the given `customer`.
        /// The client secret can be used to provide access to `customer` from your frontend. It should not be stored, logged, or exposed to anyone other than the relevant customer. Make sure that you have TLS enabled on any page that includes the client secret.
        ClientSecret: string
        Components: CustomerSessionResourceComponents option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// The Customer the Customer Session was created for.
        Customer: CustomerSessionCustomer'AnyOf
        /// The Account that the Customer Session was created for.
        CustomerAccount: string option
        /// The timestamp at which this Customer Session will expire.
        ExpiresAt: DateTime
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
    }

module CustomerSession =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "customer_session"

