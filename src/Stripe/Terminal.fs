namespace Stripe.Terminal

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.File
open Stripe.PaymentMethod

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type TerminalReaderDeviceType =
    | BbposChipper2x
    | BbposWisepad3
    | BbposWiseposE
    | MobilePhoneReader
    | SimulatedStripeS700
    | SimulatedStripeS710
    | SimulatedWiseposE
    | StripeM2
    | StripeS700
    | StripeS710
    | VerifoneP400

/// A Location represents a grouping of readers.
/// Related guide: [Fleet management](https://docs.stripe.com/terminal/fleet/locations)
type TerminalLocation =
    {
        Address: Address
        AddressKana: LegalEntityJapanAddress option
        AddressKanji: LegalEntityJapanAddress option
        /// The ID of a configuration that will be used to customize all readers in this location.
        ConfigurationOverrides: string option
        /// The display name of the location.
        DisplayName: string
        /// The Kana variation of the display name of the location.
        DisplayNameKana: string option
        /// The Kanji variation of the display name of the location.
        DisplayNameKanji: string option
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        /// The phone number of the location.
        Phone: string option
    }

module TerminalLocation =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "terminal.location"

type TerminalReaderLocation'AnyOf =
    | String of string
    | TerminalLocation of TerminalLocation

/// Represents custom text to be displayed when collecting the input using a reader
type TerminalReaderReaderResourceCustomText =
    {
        /// Customize the default description for this input
        Description: string option
        /// Customize the default label for this input's skip button
        SkipButton: string option
        /// Customize the default label for this input's submit button
        SubmitButton: string option
        /// Customize the default title for this input
        Title: string option
    }

/// Information about a email being collected using a reader
type TerminalReaderReaderResourceEmail =
    {
        /// The collected email address
        Value: string option
    }

type TerminalReaderReaderResourceInputType =
    | Email
    | Numeric
    | Phone
    | Selection
    | Signature
    | Text

/// Information about a number being collected using a reader
type TerminalReaderReaderResourceNumeric =
    {
        /// The collected number
        Value: string option
    }

/// Information about a phone number being collected using a reader
type TerminalReaderReaderResourcePhone =
    {
        /// The collected phone number
        Value: string option
    }

[<Struct>]
type TerminalReaderReaderResourceChoiceStyle =
    | Primary
    | Secondary

/// Choice to be selected on a Reader
type TerminalReaderReaderResourceChoice =
    {
        /// The identifier for the selected choice. Maximum 50 characters.
        Id: string option
        /// The button style for the choice. Can be `primary` or `secondary`.
        Style: TerminalReaderReaderResourceChoiceStyle option
        /// The text to be selected. Maximum 30 characters.
        Text: string
    }

/// Information about a selection being collected using a reader
type TerminalReaderReaderResourceSelection =
    {
        /// List of possible choices to be selected
        Choices: TerminalReaderReaderResourceChoice list
        /// The id of the selected choice
        Id: string option
        /// The text of the selected choice
        Text: string option
    }

/// Information about a signature being collected using a reader
type TerminalReaderReaderResourceSignature =
    {
        /// The File ID of a collected signature image
        Value: string option
    }

/// Information about text being collected using a reader
type TerminalReaderReaderResourceText =
    {
        /// The collected text value
        Value: string option
    }

[<Struct>]
type TerminalReaderReaderResourceToggleDefaultValue =
    | Disabled
    | Enabled

[<Struct>]
type TerminalReaderReaderResourceToggleValue =
    | Disabled
    | Enabled

/// Information about an input's toggle
type TerminalReaderReaderResourceToggle =
    {
        /// The toggle's default value. Can be `enabled` or `disabled`.
        DefaultValue: TerminalReaderReaderResourceToggleDefaultValue option
        /// The toggle's description text. Maximum 50 characters.
        Description: string option
        /// The toggle's title text. Maximum 50 characters.
        Title: string option
        /// The toggle's collected value. Can be `enabled` or `disabled`.
        Value: TerminalReaderReaderResourceToggleValue option
    }

/// Represents an input to be collected using the reader
type TerminalReaderReaderResourceInput =
    {
        /// Default text of input being collected.
        CustomText: TerminalReaderReaderResourceCustomText option
        Email: TerminalReaderReaderResourceEmail option
        Numeric: TerminalReaderReaderResourceNumeric option
        Phone: TerminalReaderReaderResourcePhone option
        /// Indicate that this input is required, disabling the skip button.
        Required: bool option
        Selection: TerminalReaderReaderResourceSelection option
        Signature: TerminalReaderReaderResourceSignature option
        /// Indicate that this input was skipped by the user.
        Skipped: bool option
        Text: TerminalReaderReaderResourceText option
        /// List of toggles being collected. Values are present if collection is complete.
        Toggles: TerminalReaderReaderResourceToggle list option
        /// Type of input being collected.
        Type: TerminalReaderReaderResourceInputType
    }

/// Represents a reader action to collect customer inputs
type TerminalReaderReaderResourceCollectInputsAction =
    {
        /// List of inputs to be collected.
        Inputs: TerminalReaderReaderResourceInput list
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
    }

/// Represents a per-transaction tipping configuration
type TerminalReaderReaderResourceTippingConfig =
    {
        /// Amount used to calculate tip suggestions on tipping selection screen for this transaction. Must be a positive integer in the smallest currency unit (e.g., 100 cents to represent $1.00 or 100 to represent ¥100, a zero-decimal currency).
        AmountEligible: int option
    }

/// Represents a per-transaction override of a reader configuration
type TerminalReaderReaderResourceCollectConfig =
    {
        /// Enable customer-initiated cancellation when processing this payment.
        EnableCustomerCancellation: bool option
        /// Override showing a tipping selection screen on this transaction.
        SkipTipping: bool option
        Tipping: TerminalReaderReaderResourceTippingConfig option
    }

type TerminalReaderReaderResourceCollectPaymentMethodActionPaymentIntent'AnyOf =
    | String of string
    | PaymentIntent of PaymentIntent

/// Represents a reader action to collect a payment method
type TerminalReaderReaderResourceCollectPaymentMethodAction =
    {
        CollectConfig: TerminalReaderReaderResourceCollectConfig option
        /// Most recent PaymentIntent processed by the reader.
        PaymentIntent: TerminalReaderReaderResourceCollectPaymentMethodActionPaymentIntent'AnyOf
        PaymentMethod: PaymentMethod option
    }

/// Represents a per-transaction override of a reader configuration
type TerminalReaderReaderResourceConfirmConfig =
    {
        /// If the customer doesn't abandon authenticating the payment, they're redirected to this URL after completion.
        ReturnUrl: string option
    }

type TerminalReaderReaderResourceConfirmPaymentIntentActionPaymentIntent'AnyOf =
    | String of string
    | PaymentIntent of PaymentIntent

/// Represents a reader action to confirm a payment
type TerminalReaderReaderResourceConfirmPaymentIntentAction =
    {
        ConfirmConfig: TerminalReaderReaderResourceConfirmConfig option
        /// Most recent PaymentIntent processed by the reader.
        PaymentIntent: TerminalReaderReaderResourceConfirmPaymentIntentActionPaymentIntent'AnyOf
    }

/// Represents a per-transaction override of a reader configuration
type TerminalReaderReaderResourceProcessConfig =
    {
        /// Enable customer-initiated cancellation when processing this payment.
        EnableCustomerCancellation: bool option
        /// If the customer doesn't abandon authenticating the payment, they're redirected to this URL after completion.
        ReturnUrl: string option
        /// Override showing a tipping selection screen on this transaction.
        SkipTipping: bool option
        Tipping: TerminalReaderReaderResourceTippingConfig option
    }

type TerminalReaderReaderResourceProcessPaymentIntentActionPaymentIntent'AnyOf =
    | String of string
    | PaymentIntent of PaymentIntent

/// Represents a reader action to process a payment intent
type TerminalReaderReaderResourceProcessPaymentIntentAction =
    {
        /// Most recent PaymentIntent processed by the reader.
        PaymentIntent: TerminalReaderReaderResourceProcessPaymentIntentActionPaymentIntent'AnyOf
        ProcessConfig: TerminalReaderReaderResourceProcessConfig option
    }

/// Represents a per-setup override of a reader configuration
type TerminalReaderReaderResourceProcessSetupConfig =
    {
        /// Enable customer-initiated cancellation when processing this SetupIntent.
        EnableCustomerCancellation: bool option
    }

type TerminalReaderReaderResourceProcessSetupIntentActionSetupIntent'AnyOf =
    | String of string
    | SetupIntent of SetupIntent

/// Represents a reader action to process a setup intent
type TerminalReaderReaderResourceProcessSetupIntentAction =
    {
        /// ID of a card PaymentMethod generated from the card_present PaymentMethod that may be attached to a Customer for future transactions. Only present if it was possible to generate a card PaymentMethod.
        GeneratedCard: string option
        ProcessConfig: TerminalReaderReaderResourceProcessSetupConfig option
        /// Most recent SetupIntent processed by the reader.
        SetupIntent: TerminalReaderReaderResourceProcessSetupIntentActionSetupIntent'AnyOf
    }

[<Struct>]
type TerminalReaderReaderResourceReaderActionStatus =
    | Failed
    | InProgress
    | Succeeded

type TerminalReaderReaderResourceReaderActionType =
    | CollectInputs
    | CollectPaymentMethod
    | ConfirmPaymentIntent
    | ProcessPaymentIntent
    | ProcessSetupIntent
    | RefundPayment
    | SetReaderDisplay

type TerminalReaderReaderResourceRefundPaymentActionCharge'AnyOf =
    | String of string
    | Charge of Charge

type TerminalReaderReaderResourceRefundPaymentActionPaymentIntent'AnyOf =
    | String of string
    | PaymentIntent of PaymentIntent

[<Struct>]
type TerminalReaderReaderResourceRefundPaymentActionReason =
    | Duplicate
    | Fraudulent
    | RequestedByCustomer

type TerminalReaderReaderResourceRefundPaymentActionRefund'AnyOf =
    | String of string
    | Refund of Refund

/// Represents a per-transaction override of a reader configuration
type TerminalReaderReaderResourceRefundPaymentConfig =
    {
        /// Enable customer-initiated cancellation when refunding this payment.
        EnableCustomerCancellation: bool option
    }

/// Represents a reader action to refund a payment
type TerminalReaderReaderResourceRefundPaymentAction =
    {
        /// The amount being refunded.
        Amount: int option
        /// Charge that is being refunded.
        Charge: TerminalReaderReaderResourceRefundPaymentActionCharge'AnyOf option
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        /// Payment intent that is being refunded.
        PaymentIntent: TerminalReaderReaderResourceRefundPaymentActionPaymentIntent'AnyOf option
        /// The reason for the refund.
        Reason: TerminalReaderReaderResourceRefundPaymentActionReason option
        /// Unique identifier for the refund object.
        Refund: TerminalReaderReaderResourceRefundPaymentActionRefund'AnyOf option
        /// Boolean indicating whether the application fee should be refunded when refunding this charge. If a full charge refund is given, the full application fee will be refunded. Otherwise, the application fee will be refunded in an amount proportional to the amount of the charge refunded. An application fee can be refunded only by the application that created the charge.
        RefundApplicationFee: bool option
        RefundPaymentConfig: TerminalReaderReaderResourceRefundPaymentConfig option
        /// Boolean indicating whether the transfer should be reversed when refunding this charge. The transfer will be reversed proportionally to the amount being refunded (either the entire or partial amount). A transfer can be reversed only by the application that created the charge.
        ReverseTransfer: bool option
    }

/// Represents a line item to be displayed on the reader
type TerminalReaderReaderResourceLineItem =
    {
        /// The amount of the line item. A positive integer in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).
        Amount: int
        /// Description of the line item.
        Description: string
        /// The quantity of the line item.
        Quantity: int
    }

/// Represents a cart to be displayed on the reader
type TerminalReaderReaderResourceCart =
    {
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// List of line items in the cart.
        LineItems: TerminalReaderReaderResourceLineItem list
        /// Tax amount for the entire cart. A positive integer in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).
        Tax: int option
        /// Total amount for the entire cart, including tax. A positive integer in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).
        Total: int
    }

/// Represents a reader action to set the reader display
type TerminalReaderReaderResourceSetReaderDisplayAction =
    {
        /// Cart object to be displayed by the reader, including line items, amounts, and currency.
        Cart: TerminalReaderReaderResourceCart option
    }

module TerminalReaderReaderResourceSetReaderDisplayAction =
    ///Type of information to be displayed by the reader. Only `cart` is currently supported.
    let ``type`` = "cart"

/// Represents an action performed by the reader
type TerminalReaderReaderResourceReaderAction =
    {
        CollectInputs: TerminalReaderReaderResourceCollectInputsAction option
        CollectPaymentMethod: TerminalReaderReaderResourceCollectPaymentMethodAction option
        ConfirmPaymentIntent: TerminalReaderReaderResourceConfirmPaymentIntentAction option
        /// Failure code, only set if status is `failed`.
        FailureCode: string option
        /// Detailed failure message, only set if status is `failed`.
        FailureMessage: string option
        ProcessPaymentIntent: TerminalReaderReaderResourceProcessPaymentIntentAction option
        ProcessSetupIntent: TerminalReaderReaderResourceProcessSetupIntentAction option
        RefundPayment: TerminalReaderReaderResourceRefundPaymentAction option
        SetReaderDisplay: TerminalReaderReaderResourceSetReaderDisplayAction option
        /// Status of the action performed by the reader.
        Status: TerminalReaderReaderResourceReaderActionStatus
        /// Type of action performed by the reader.
        Type: TerminalReaderReaderResourceReaderActionType
    }

[<Struct>]
type TerminalReaderStatus =
    | Offline
    | Online

/// A Reader represents a physical device for accepting payment details.
/// Related guide: [Connecting to a reader](https://docs.stripe.com/terminal/payments/connect-reader)
type TerminalReader =
    {
        /// The most recent action performed by the reader.
        Action: TerminalReaderReaderResourceReaderAction option
        /// The current software version of the reader.
        DeviceSwVersion: string option
        /// Device type of the reader.
        DeviceType: TerminalReaderDeviceType
        /// Unique identifier for the object.
        Id: string
        /// The local IP address of the reader.
        IpAddress: string option
        /// Custom label given to the reader for easier identification.
        Label: string
        /// The last time this reader reported to Stripe backend. Timestamp is measured in milliseconds since the Unix epoch. Unlike most other Stripe timestamp fields which use seconds, this field uses milliseconds.
        LastSeenAt: DateTime option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// The location identifier of the reader.
        Location: TerminalReaderLocation'AnyOf option
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        /// Serial number of the reader.
        SerialNumber: string
        /// The networking status of the reader. We do not recommend using this field in flows that may block taking payments.
        Status: TerminalReaderStatus option
    }

module TerminalReader =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "terminal.reader"

/// Occurs whenever an action sent to a Terminal reader is updated.
type TerminalReaderActionUpdated = { Object: TerminalReader }

/// Occurs whenever an action sent to a Terminal reader was successful.
type TerminalReaderActionSucceeded = { Object: TerminalReader }

/// Occurs whenever an action sent to a Terminal reader failed.
type TerminalReaderActionFailed = { Object: TerminalReader }

/// Options associated with the Apple Terms and Conditions link type.
type TerminalOnboardingLinkAppleTermsAndConditions =
    {
        /// Whether the link should also support users relinking their Apple account.
        AllowRelinking: bool option
        /// The business name of the merchant accepting Apple's Terms and Conditions.
        MerchantDisplayName: string
    }

/// Link type options associated with the current onboarding link object.
type TerminalOnboardingLinkLinkOptions =
    {
        /// The options associated with the Apple Terms and Conditions link type.
        AppleTermsAndConditions: TerminalOnboardingLinkAppleTermsAndConditions option
    }

/// Returns redirect links used for onboarding onto Tap to Pay on iPhone.
type TerminalOnboardingLink =
    {
        LinkOptions: TerminalOnboardingLinkLinkOptions
        /// Stripe account ID to generate the link for.
        OnBehalfOf: string option
        /// The link passed back to the user for their onboarding.
        RedirectUrl: string
    }

module TerminalOnboardingLink =
    ///The type of link being generated.
    let linkType = "apple_terms_and_conditions"

    let object = "terminal.onboarding_link"

/// A Connection Token is used by the Stripe Terminal SDK to connect to a reader.
/// Related guide: [Fleet management](https://docs.stripe.com/terminal/fleet/locations)
type TerminalConnectionToken =
    {
        /// The id of the location that this connection token is scoped to. Note that location scoping only applies to internet-connected readers. For more details, see [the docs on scoping connection tokens](https://docs.stripe.com/terminal/fleet/locations-and-zones?dashboard-or-api=api#connection-tokens).
        Location: string option
        /// Your application should pass this token to the Stripe Terminal SDK.
        Secret: string
    }

module TerminalConnectionToken =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "terminal.connection_token"

type TerminalConfigurationConfigurationResourceCellularConfig =
    {
        /// Whether a cellular-capable reader can connect to the internet over cellular.
        Enabled: bool
    }

type TerminalConfigurationConfigurationResourceDeviceTypeSpecificConfigSplashscreen'AnyOf =
    | String of string
    | File of File

type TerminalConfigurationConfigurationResourceDeviceTypeSpecificConfig =
    {
        /// A File ID representing an image to display on the reader
        Splashscreen: TerminalConfigurationConfigurationResourceDeviceTypeSpecificConfigSplashscreen'AnyOf option
    }

type TerminalConfigurationConfigurationResourceOfflineConfig =
    {
        /// Determines whether to allow transactions to be collected while reader is offline. Defaults to false.
        Enabled: bool option
    }

type TerminalConfigurationConfigurationResourceRebootWindow =
    {
        /// Integer between 0 to 23 that represents the end hour of the reboot time window. The value must be different than the start_hour.
        EndHour: int
        /// Integer between 0 to 23 that represents the start hour of the reboot time window.
        StartHour: int
    }

type TerminalConfigurationConfigurationResourceCurrencySpecificConfig =
    {
        /// Fixed amounts displayed when collecting a tip
        FixedAmounts: int list option
        /// Percentages displayed when collecting a tip
        Percentages: int list option
        /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
        SmartTipThreshold: int option
    }

type TerminalConfigurationConfigurationResourceTipping =
    { Aed: TerminalConfigurationConfigurationResourceCurrencySpecificConfig option
      Aud: TerminalConfigurationConfigurationResourceCurrencySpecificConfig option
      Cad: TerminalConfigurationConfigurationResourceCurrencySpecificConfig option
      Chf: TerminalConfigurationConfigurationResourceCurrencySpecificConfig option
      Czk: TerminalConfigurationConfigurationResourceCurrencySpecificConfig option
      Dkk: TerminalConfigurationConfigurationResourceCurrencySpecificConfig option
      Eur: TerminalConfigurationConfigurationResourceCurrencySpecificConfig option
      Gbp: TerminalConfigurationConfigurationResourceCurrencySpecificConfig option
      Gip: TerminalConfigurationConfigurationResourceCurrencySpecificConfig option
      Hkd: TerminalConfigurationConfigurationResourceCurrencySpecificConfig option
      Huf: TerminalConfigurationConfigurationResourceCurrencySpecificConfig option
      Jpy: TerminalConfigurationConfigurationResourceCurrencySpecificConfig option
      Mxn: TerminalConfigurationConfigurationResourceCurrencySpecificConfig option
      Myr: TerminalConfigurationConfigurationResourceCurrencySpecificConfig option
      Nok: TerminalConfigurationConfigurationResourceCurrencySpecificConfig option
      Nzd: TerminalConfigurationConfigurationResourceCurrencySpecificConfig option
      Pln: TerminalConfigurationConfigurationResourceCurrencySpecificConfig option
      Ron: TerminalConfigurationConfigurationResourceCurrencySpecificConfig option
      Sek: TerminalConfigurationConfigurationResourceCurrencySpecificConfig option
      Sgd: TerminalConfigurationConfigurationResourceCurrencySpecificConfig option
      Usd: TerminalConfigurationConfigurationResourceCurrencySpecificConfig option }

type TerminalConfigurationConfigurationResourceEnterprisePeapWifi =
    {
        /// A File ID representing a PEM file containing the server certificate
        CaCertificateFile: string option
        /// Password for connecting to the WiFi network
        Password: string
        /// Name of the WiFi network
        Ssid: string
        /// Username for connecting to the WiFi network
        Username: string
    }

type TerminalConfigurationConfigurationResourceEnterpriseTlsWifi =
    {
        /// A File ID representing a PEM file containing the server certificate
        CaCertificateFile: string option
        /// A File ID representing a PEM file containing the client certificate
        ClientCertificateFile: string
        /// A File ID representing a PEM file containing the client RSA private key
        PrivateKeyFile: string
        /// Password for the private key file
        PrivateKeyFilePassword: string option
        /// Name of the WiFi network
        Ssid: string
    }

type TerminalConfigurationConfigurationResourcePersonalPskWifi =
    {
        /// Password for connecting to the WiFi network
        Password: string
        /// Name of the WiFi network
        Ssid: string
    }

[<Struct>]
type TerminalConfigurationConfigurationResourceWifiConfigType =
    | EnterpriseEapPeap
    | EnterpriseEapTls
    | PersonalPsk

type TerminalConfigurationConfigurationResourceWifiConfig =
    {
        EnterpriseEapPeap: TerminalConfigurationConfigurationResourceEnterprisePeapWifi option
        EnterpriseEapTls: TerminalConfigurationConfigurationResourceEnterpriseTlsWifi option
        PersonalPsk: TerminalConfigurationConfigurationResourcePersonalPskWifi option
        /// Security type of the WiFi network. The hash with the corresponding name contains the credentials for this security type.
        Type: TerminalConfigurationConfigurationResourceWifiConfigType
    }

/// A Configurations object represents how features should be configured for terminal readers.
/// For information about how to use it, see the [Terminal configurations documentation](https://docs.stripe.com/terminal/fleet/configurations-overview).
type TerminalConfiguration =
    {
        [<JsonPropertyName("bbpos_wisepad3")>]
        BbposWisepad3: TerminalConfigurationConfigurationResourceDeviceTypeSpecificConfig option
        BbposWiseposE: TerminalConfigurationConfigurationResourceDeviceTypeSpecificConfig option
        Cellular: TerminalConfigurationConfigurationResourceCellularConfig option
        /// Unique identifier for the object.
        Id: string
        /// Whether this Configuration is the default for your account
        IsAccountDefault: bool option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// String indicating the name of the Configuration object, set by the user
        Name: string option
        Offline: TerminalConfigurationConfigurationResourceOfflineConfig option
        RebootWindow: TerminalConfigurationConfigurationResourceRebootWindow option
        [<JsonPropertyName("stripe_s700")>]
        StripeS700: TerminalConfigurationConfigurationResourceDeviceTypeSpecificConfig option
        [<JsonPropertyName("stripe_s710")>]
        StripeS710: TerminalConfigurationConfigurationResourceDeviceTypeSpecificConfig option
        Tipping: TerminalConfigurationConfigurationResourceTipping option
        [<JsonPropertyName("verifone_p400")>]
        VerifoneP400: TerminalConfigurationConfigurationResourceDeviceTypeSpecificConfig option
        Wifi: TerminalConfigurationConfigurationResourceWifiConfig option
    }

module TerminalConfiguration =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "terminal.configuration"

