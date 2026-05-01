namespace Stripe.Terminal

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.FundingInstructions
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

type TerminalReaderReaderResourceCustomText with
    static member New(description: string option, skipButton: string option, submitButton: string option, title: string option) =
        {
            Description = description
            SkipButton = skipButton
            SubmitButton = submitButton
            Title = title
        }

/// Information about a email being collected using a reader
type TerminalReaderReaderResourceEmail =
    {
        /// The collected email address
        Value: string option
    }

type TerminalReaderReaderResourceEmail with
    static member New(value: string option) =
        {
            Value = value
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

type TerminalReaderReaderResourceNumeric with
    static member New(value: string option) =
        {
            Value = value
        }

/// Information about a phone number being collected using a reader
type TerminalReaderReaderResourcePhone =
    {
        /// The collected phone number
        Value: string option
    }

type TerminalReaderReaderResourcePhone with
    static member New(value: string option) =
        {
            Value = value
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

type TerminalReaderReaderResourceChoice with
    static member New(id: string option, style: TerminalReaderReaderResourceChoiceStyle option, text: string) =
        {
            Id = id
            Style = style
            Text = text
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

type TerminalReaderReaderResourceSelection with
    static member New(choices: TerminalReaderReaderResourceChoice list, id: string option, text: string option) =
        {
            Choices = choices
            Id = id
            Text = text
        }

/// Information about a signature being collected using a reader
type TerminalReaderReaderResourceSignature =
    {
        /// The File ID of a collected signature image
        Value: string option
    }

type TerminalReaderReaderResourceSignature with
    static member New(value: string option) =
        {
            Value = value
        }

/// Information about text being collected using a reader
type TerminalReaderReaderResourceText =
    {
        /// The collected text value
        Value: string option
    }

type TerminalReaderReaderResourceText with
    static member New(value: string option) =
        {
            Value = value
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

type TerminalReaderReaderResourceToggle with
    static member New(defaultValue: TerminalReaderReaderResourceToggleDefaultValue option, description: string option, title: string option, value: TerminalReaderReaderResourceToggleValue option) =
        {
            DefaultValue = defaultValue
            Description = description
            Title = title
            Value = value
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

type TerminalReaderReaderResourceInput with
    static member New(customText: TerminalReaderReaderResourceCustomText option, required: bool option, toggles: TerminalReaderReaderResourceToggle list option, ``type``: TerminalReaderReaderResourceInputType, ?email: TerminalReaderReaderResourceEmail, ?numeric: TerminalReaderReaderResourceNumeric, ?phone: TerminalReaderReaderResourcePhone, ?selection: TerminalReaderReaderResourceSelection, ?signature: TerminalReaderReaderResourceSignature, ?skipped: bool, ?text: TerminalReaderReaderResourceText) =
        {
            CustomText = customText
            Required = required
            Toggles = toggles
            Type = ``type``
            Email = email
            Numeric = numeric
            Phone = phone
            Selection = selection
            Signature = signature
            Skipped = skipped
            Text = text
        }

/// Represents a reader action to collect customer inputs
type TerminalReaderReaderResourceCollectInputsAction =
    {
        /// List of inputs to be collected.
        Inputs: TerminalReaderReaderResourceInput list
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
    }

type TerminalReaderReaderResourceCollectInputsAction with
    static member New(inputs: TerminalReaderReaderResourceInput list, metadata: Map<string, string> option) =
        {
            Inputs = inputs
            Metadata = metadata
        }

/// Represents a per-transaction tipping configuration
type TerminalReaderReaderResourceTippingConfig =
    {
        /// Amount used to calculate tip suggestions on tipping selection screen for this transaction. Must be a positive integer in the smallest currency unit (e.g., 100 cents to represent $1.00 or 100 to represent ¥100, a zero-decimal currency).
        AmountEligible: int option
    }

type TerminalReaderReaderResourceTippingConfig with
    static member New(?amountEligible: int) =
        {
            AmountEligible = amountEligible
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

type TerminalReaderReaderResourceCollectConfig with
    static member New(?enableCustomerCancellation: bool, ?skipTipping: bool, ?tipping: TerminalReaderReaderResourceTippingConfig) =
        {
            EnableCustomerCancellation = enableCustomerCancellation
            SkipTipping = skipTipping
            Tipping = tipping
        }

/// Represents a reader action to collect a payment method
type TerminalReaderReaderResourceCollectPaymentMethodAction =
    {
        CollectConfig: TerminalReaderReaderResourceCollectConfig option
        /// Most recent PaymentIntent processed by the reader.
        PaymentIntent: StripeId<Markers.PaymentIntent>
        PaymentMethod: PaymentMethod option
    }

type TerminalReaderReaderResourceCollectPaymentMethodAction with
    static member New(paymentIntent: StripeId<Markers.PaymentIntent>, ?collectConfig: TerminalReaderReaderResourceCollectConfig, ?paymentMethod: PaymentMethod) =
        {
            PaymentIntent = paymentIntent
            CollectConfig = collectConfig
            PaymentMethod = paymentMethod
        }

/// Represents a per-transaction override of a reader configuration
type TerminalReaderReaderResourceConfirmConfig =
    {
        /// If the customer doesn't abandon authenticating the payment, they're redirected to this URL after completion.
        ReturnUrl: string option
    }

type TerminalReaderReaderResourceConfirmConfig with
    static member New(?returnUrl: string) =
        {
            ReturnUrl = returnUrl
        }

/// Represents a reader action to confirm a payment
type TerminalReaderReaderResourceConfirmPaymentIntentAction =
    {
        ConfirmConfig: TerminalReaderReaderResourceConfirmConfig option
        /// Most recent PaymentIntent processed by the reader.
        PaymentIntent: StripeId<Markers.PaymentIntent>
    }

type TerminalReaderReaderResourceConfirmPaymentIntentAction with
    static member New(paymentIntent: StripeId<Markers.PaymentIntent>, ?confirmConfig: TerminalReaderReaderResourceConfirmConfig) =
        {
            PaymentIntent = paymentIntent
            ConfirmConfig = confirmConfig
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

type TerminalReaderReaderResourceProcessConfig with
    static member New(?enableCustomerCancellation: bool, ?returnUrl: string, ?skipTipping: bool, ?tipping: TerminalReaderReaderResourceTippingConfig) =
        {
            EnableCustomerCancellation = enableCustomerCancellation
            ReturnUrl = returnUrl
            SkipTipping = skipTipping
            Tipping = tipping
        }

/// Represents a reader action to process a payment intent
type TerminalReaderReaderResourceProcessPaymentIntentAction =
    {
        /// Most recent PaymentIntent processed by the reader.
        PaymentIntent: StripeId<Markers.PaymentIntent>
        ProcessConfig: TerminalReaderReaderResourceProcessConfig option
    }

type TerminalReaderReaderResourceProcessPaymentIntentAction with
    static member New(paymentIntent: StripeId<Markers.PaymentIntent>, ?processConfig: TerminalReaderReaderResourceProcessConfig) =
        {
            PaymentIntent = paymentIntent
            ProcessConfig = processConfig
        }

/// Represents a per-setup override of a reader configuration
type TerminalReaderReaderResourceProcessSetupConfig =
    {
        /// Enable customer-initiated cancellation when processing this SetupIntent.
        EnableCustomerCancellation: bool option
    }

type TerminalReaderReaderResourceProcessSetupConfig with
    static member New(?enableCustomerCancellation: bool) =
        {
            EnableCustomerCancellation = enableCustomerCancellation
        }

/// Represents a reader action to process a setup intent
type TerminalReaderReaderResourceProcessSetupIntentAction =
    {
        /// ID of a card PaymentMethod generated from the card_present PaymentMethod that may be attached to a Customer for future transactions. Only present if it was possible to generate a card PaymentMethod.
        GeneratedCard: string option
        ProcessConfig: TerminalReaderReaderResourceProcessSetupConfig option
        /// Most recent SetupIntent processed by the reader.
        SetupIntent: StripeId<Markers.SetupIntent>
    }

type TerminalReaderReaderResourceProcessSetupIntentAction with
    static member New(setupIntent: StripeId<Markers.SetupIntent>, ?generatedCard: string, ?processConfig: TerminalReaderReaderResourceProcessSetupConfig) =
        {
            SetupIntent = setupIntent
            GeneratedCard = generatedCard
            ProcessConfig = processConfig
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

[<Struct>]
type TerminalReaderReaderResourceRefundPaymentActionReason =
    | Duplicate
    | Fraudulent
    | RequestedByCustomer

/// Represents a per-transaction override of a reader configuration
type TerminalReaderReaderResourceRefundPaymentConfig =
    {
        /// Enable customer-initiated cancellation when refunding this payment.
        EnableCustomerCancellation: bool option
    }

type TerminalReaderReaderResourceRefundPaymentConfig with
    static member New(?enableCustomerCancellation: bool) =
        {
            EnableCustomerCancellation = enableCustomerCancellation
        }

/// Represents a reader action to refund a payment
type TerminalReaderReaderResourceRefundPaymentAction =
    {
        /// The amount being refunded.
        Amount: int option
        /// Charge that is being refunded.
        Charge: StripeId<Markers.Charge> option
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        /// Payment intent that is being refunded.
        PaymentIntent: StripeId<Markers.PaymentIntent> option
        /// The reason for the refund.
        Reason: TerminalReaderReaderResourceRefundPaymentActionReason option
        /// Unique identifier for the refund object.
        Refund: StripeId<Markers.Refund> option
        /// Boolean indicating whether the application fee should be refunded when refunding this charge. If a full charge refund is given, the full application fee will be refunded. Otherwise, the application fee will be refunded in an amount proportional to the amount of the charge refunded. An application fee can be refunded only by the application that created the charge.
        RefundApplicationFee: bool option
        RefundPaymentConfig: TerminalReaderReaderResourceRefundPaymentConfig option
        /// Boolean indicating whether the transfer should be reversed when refunding this charge. The transfer will be reversed proportionally to the amount being refunded (either the entire or partial amount). A transfer can be reversed only by the application that created the charge.
        ReverseTransfer: bool option
    }

type TerminalReaderReaderResourceRefundPaymentAction with
    static member New(?amount: int, ?charge: StripeId<Markers.Charge>, ?metadata: Map<string, string>, ?paymentIntent: StripeId<Markers.PaymentIntent>, ?reason: TerminalReaderReaderResourceRefundPaymentActionReason, ?refund: StripeId<Markers.Refund>, ?refundApplicationFee: bool, ?refundPaymentConfig: TerminalReaderReaderResourceRefundPaymentConfig, ?reverseTransfer: bool) =
        {
            Amount = amount
            Charge = charge
            Metadata = metadata
            PaymentIntent = paymentIntent
            Reason = reason
            Refund = refund
            RefundApplicationFee = refundApplicationFee
            RefundPaymentConfig = refundPaymentConfig
            ReverseTransfer = reverseTransfer
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

type TerminalReaderReaderResourceLineItem with
    static member New(amount: int, description: string, quantity: int) =
        {
            Amount = amount
            Description = description
            Quantity = quantity
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

type TerminalReaderReaderResourceCart with
    static member New(currency: IsoTypes.IsoCurrencyCode, lineItems: TerminalReaderReaderResourceLineItem list, tax: int option, total: int) =
        {
            Currency = currency
            LineItems = lineItems
            Tax = tax
            Total = total
        }

/// Represents a reader action to set the reader display
type TerminalReaderReaderResourceSetReaderDisplayAction =
    {
        /// Cart object to be displayed by the reader, including line items, amounts, and currency.
        Cart: TerminalReaderReaderResourceCart option
    }

type TerminalReaderReaderResourceSetReaderDisplayAction with
    static member New(cart: TerminalReaderReaderResourceCart option) =
        {
            Cart = cart
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

type TerminalReaderReaderResourceReaderAction with
    static member New(failureCode: string option, failureMessage: string option, status: TerminalReaderReaderResourceReaderActionStatus, ``type``: TerminalReaderReaderResourceReaderActionType, ?collectInputs: TerminalReaderReaderResourceCollectInputsAction, ?collectPaymentMethod: TerminalReaderReaderResourceCollectPaymentMethodAction, ?confirmPaymentIntent: TerminalReaderReaderResourceConfirmPaymentIntentAction, ?processPaymentIntent: TerminalReaderReaderResourceProcessPaymentIntentAction, ?processSetupIntent: TerminalReaderReaderResourceProcessSetupIntentAction, ?refundPayment: TerminalReaderReaderResourceRefundPaymentAction, ?setReaderDisplay: TerminalReaderReaderResourceSetReaderDisplayAction) =
        {
            FailureCode = failureCode
            FailureMessage = failureMessage
            Status = status
            Type = ``type``
            CollectInputs = collectInputs
            CollectPaymentMethod = collectPaymentMethod
            ConfirmPaymentIntent = confirmPaymentIntent
            ProcessPaymentIntent = processPaymentIntent
            ProcessSetupIntent = processSetupIntent
            RefundPayment = refundPayment
            SetReaderDisplay = setReaderDisplay
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
        Location: StripeId<Markers.TerminalLocation> option
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        /// Serial number of the reader.
        SerialNumber: string
        /// The networking status of the reader. We do not recommend using this field in flows that may block taking payments.
        Status: TerminalReaderStatus option
    }

type TerminalReader with
    static member New(action: TerminalReaderReaderResourceReaderAction option, deviceSwVersion: string option, deviceType: TerminalReaderDeviceType, id: string, ipAddress: string option, label: string, lastSeenAt: DateTime option, livemode: bool, location: StripeId<Markers.TerminalLocation> option, metadata: Map<string, string>, serialNumber: string, status: TerminalReaderStatus option) =
        {
            Action = action
            DeviceSwVersion = deviceSwVersion
            DeviceType = deviceType
            Id = id
            IpAddress = ipAddress
            Label = label
            LastSeenAt = lastSeenAt
            Livemode = livemode
            Location = location
            Metadata = metadata
            SerialNumber = serialNumber
            Status = status
        }

module TerminalReader =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "terminal.reader"

/// Occurs whenever an action sent to a Terminal reader is updated.
type TerminalReaderActionUpdated = { Object: TerminalReader }

type TerminalReaderActionUpdated with
    static member New(object: TerminalReader) =
        {
            Object = object
        }

/// Occurs whenever an action sent to a Terminal reader was successful.
type TerminalReaderActionSucceeded = { Object: TerminalReader }

type TerminalReaderActionSucceeded with
    static member New(object: TerminalReader) =
        {
            Object = object
        }

/// Occurs whenever an action sent to a Terminal reader failed.
type TerminalReaderActionFailed = { Object: TerminalReader }

type TerminalReaderActionFailed with
    static member New(object: TerminalReader) =
        {
            Object = object
        }

/// Options associated with the Apple Terms and Conditions link type.
type TerminalOnboardingLinkAppleTermsAndConditions =
    {
        /// Whether the link should also support users relinking their Apple account.
        AllowRelinking: bool option
        /// The business name of the merchant accepting Apple's Terms and Conditions.
        MerchantDisplayName: string
    }

type TerminalOnboardingLinkAppleTermsAndConditions with
    static member New(allowRelinking: bool option, merchantDisplayName: string) =
        {
            AllowRelinking = allowRelinking
            MerchantDisplayName = merchantDisplayName
        }

/// Link type options associated with the current onboarding link object.
type TerminalOnboardingLinkLinkOptions =
    {
        /// The options associated with the Apple Terms and Conditions link type.
        AppleTermsAndConditions: TerminalOnboardingLinkAppleTermsAndConditions option
    }

type TerminalOnboardingLinkLinkOptions with
    static member New(appleTermsAndConditions: TerminalOnboardingLinkAppleTermsAndConditions option) =
        {
            AppleTermsAndConditions = appleTermsAndConditions
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

type TerminalOnboardingLink with
    static member New(linkOptions: TerminalOnboardingLinkLinkOptions, onBehalfOf: string option, redirectUrl: string) =
        {
            LinkOptions = linkOptions
            OnBehalfOf = onBehalfOf
            RedirectUrl = redirectUrl
        }

module TerminalOnboardingLink =
    ///The type of link being generated.
    let linkType = "apple_terms_and_conditions"

    let object = "terminal.onboarding_link"

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

type TerminalLocation with
    static member New(address: Address, displayName: string, id: string, livemode: bool, metadata: Map<string, string>, ?addressKana: LegalEntityJapanAddress, ?addressKanji: LegalEntityJapanAddress, ?configurationOverrides: string, ?displayNameKana: string, ?displayNameKanji: string, ?phone: string) =
        {
            Address = address
            DisplayName = displayName
            Id = id
            Livemode = livemode
            Metadata = metadata
            AddressKana = addressKana
            AddressKanji = addressKanji
            ConfigurationOverrides = configurationOverrides
            DisplayNameKana = displayNameKana
            DisplayNameKanji = displayNameKanji
            Phone = phone
        }

module TerminalLocation =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "terminal.location"

/// A Connection Token is used by the Stripe Terminal SDK to connect to a reader.
/// Related guide: [Fleet management](https://docs.stripe.com/terminal/fleet/locations)
type TerminalConnectionToken =
    {
        /// The id of the location that this connection token is scoped to. Note that location scoping only applies to internet-connected readers. For more details, see [the docs on scoping connection tokens](https://docs.stripe.com/terminal/fleet/locations-and-zones?dashboard-or-api=api#connection-tokens).
        Location: string option
        /// Your application should pass this token to the Stripe Terminal SDK.
        Secret: string
    }

type TerminalConnectionToken with
    static member New(secret: string, ?location: string) =
        {
            Secret = secret
            Location = location
        }

module TerminalConnectionToken =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "terminal.connection_token"

type TerminalConfigurationConfigurationResourceCellularConfig =
    {
        /// Whether a cellular-capable reader can connect to the internet over cellular.
        Enabled: bool
    }

type TerminalConfigurationConfigurationResourceCellularConfig with
    static member New(enabled: bool) =
        {
            Enabled = enabled
        }

type TerminalConfigurationConfigurationResourceDeviceTypeSpecificConfig =
    {
        /// A File ID representing an image to display on the reader
        Splashscreen: StripeId<Markers.File> option
    }

type TerminalConfigurationConfigurationResourceDeviceTypeSpecificConfig with
    static member New(?splashscreen: StripeId<Markers.File>) =
        {
            Splashscreen = splashscreen
        }

type TerminalConfigurationConfigurationResourceOfflineConfig =
    {
        /// Determines whether to allow transactions to be collected while reader is offline. Defaults to false.
        Enabled: bool option
    }

type TerminalConfigurationConfigurationResourceOfflineConfig with
    static member New(enabled: bool option) =
        {
            Enabled = enabled
        }

type TerminalConfigurationConfigurationResourceRebootWindow =
    {
        /// Integer between 0 to 23 that represents the end hour of the reboot time window. The value must be different than the start_hour.
        EndHour: int
        /// Integer between 0 to 23 that represents the start hour of the reboot time window.
        StartHour: int
    }

type TerminalConfigurationConfigurationResourceRebootWindow with
    static member New(endHour: int, startHour: int) =
        {
            EndHour = endHour
            StartHour = startHour
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

type TerminalConfigurationConfigurationResourceCurrencySpecificConfig with
    static member New(?fixedAmounts: int list option, ?percentages: int list option, ?smartTipThreshold: int) =
        {
            FixedAmounts = fixedAmounts |> Option.flatten
            Percentages = percentages |> Option.flatten
            SmartTipThreshold = smartTipThreshold
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

type TerminalConfigurationConfigurationResourceTipping with
    static member New(?aed: TerminalConfigurationConfigurationResourceCurrencySpecificConfig, ?aud: TerminalConfigurationConfigurationResourceCurrencySpecificConfig, ?cad: TerminalConfigurationConfigurationResourceCurrencySpecificConfig, ?chf: TerminalConfigurationConfigurationResourceCurrencySpecificConfig, ?czk: TerminalConfigurationConfigurationResourceCurrencySpecificConfig, ?dkk: TerminalConfigurationConfigurationResourceCurrencySpecificConfig, ?eur: TerminalConfigurationConfigurationResourceCurrencySpecificConfig, ?gbp: TerminalConfigurationConfigurationResourceCurrencySpecificConfig, ?gip: TerminalConfigurationConfigurationResourceCurrencySpecificConfig, ?hkd: TerminalConfigurationConfigurationResourceCurrencySpecificConfig, ?huf: TerminalConfigurationConfigurationResourceCurrencySpecificConfig, ?jpy: TerminalConfigurationConfigurationResourceCurrencySpecificConfig, ?mxn: TerminalConfigurationConfigurationResourceCurrencySpecificConfig, ?myr: TerminalConfigurationConfigurationResourceCurrencySpecificConfig, ?nok: TerminalConfigurationConfigurationResourceCurrencySpecificConfig, ?nzd: TerminalConfigurationConfigurationResourceCurrencySpecificConfig, ?pln: TerminalConfigurationConfigurationResourceCurrencySpecificConfig, ?ron: TerminalConfigurationConfigurationResourceCurrencySpecificConfig, ?sek: TerminalConfigurationConfigurationResourceCurrencySpecificConfig, ?sgd: TerminalConfigurationConfigurationResourceCurrencySpecificConfig, ?usd: TerminalConfigurationConfigurationResourceCurrencySpecificConfig) =
        {
            Aed = aed
            Aud = aud
            Cad = cad
            Chf = chf
            Czk = czk
            Dkk = dkk
            Eur = eur
            Gbp = gbp
            Gip = gip
            Hkd = hkd
            Huf = huf
            Jpy = jpy
            Mxn = mxn
            Myr = myr
            Nok = nok
            Nzd = nzd
            Pln = pln
            Ron = ron
            Sek = sek
            Sgd = sgd
            Usd = usd
        }

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

type TerminalConfigurationConfigurationResourceEnterprisePeapWifi with
    static member New(password: string, ssid: string, username: string, ?caCertificateFile: string) =
        {
            Password = password
            Ssid = ssid
            Username = username
            CaCertificateFile = caCertificateFile
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

type TerminalConfigurationConfigurationResourceEnterpriseTlsWifi with
    static member New(clientCertificateFile: string, privateKeyFile: string, ssid: string, ?caCertificateFile: string, ?privateKeyFilePassword: string) =
        {
            ClientCertificateFile = clientCertificateFile
            PrivateKeyFile = privateKeyFile
            Ssid = ssid
            CaCertificateFile = caCertificateFile
            PrivateKeyFilePassword = privateKeyFilePassword
        }

type TerminalConfigurationConfigurationResourcePersonalPskWifi =
    {
        /// Password for connecting to the WiFi network
        Password: string
        /// Name of the WiFi network
        Ssid: string
    }

type TerminalConfigurationConfigurationResourcePersonalPskWifi with
    static member New(password: string, ssid: string) =
        {
            Password = password
            Ssid = ssid
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

type TerminalConfigurationConfigurationResourceWifiConfig with
    static member New(``type``: TerminalConfigurationConfigurationResourceWifiConfigType, ?enterpriseEapPeap: TerminalConfigurationConfigurationResourceEnterprisePeapWifi, ?enterpriseEapTls: TerminalConfigurationConfigurationResourceEnterpriseTlsWifi, ?personalPsk: TerminalConfigurationConfigurationResourcePersonalPskWifi) =
        {
            Type = ``type``
            EnterpriseEapPeap = enterpriseEapPeap
            EnterpriseEapTls = enterpriseEapTls
            PersonalPsk = personalPsk
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

type TerminalConfiguration with
    static member New(id: string, isAccountDefault: bool option, livemode: bool, name: string option, ?bbposWisepad3: TerminalConfigurationConfigurationResourceDeviceTypeSpecificConfig, ?bbposWiseposE: TerminalConfigurationConfigurationResourceDeviceTypeSpecificConfig, ?cellular: TerminalConfigurationConfigurationResourceCellularConfig, ?offline: TerminalConfigurationConfigurationResourceOfflineConfig, ?rebootWindow: TerminalConfigurationConfigurationResourceRebootWindow, ?stripeS700: TerminalConfigurationConfigurationResourceDeviceTypeSpecificConfig, ?stripeS710: TerminalConfigurationConfigurationResourceDeviceTypeSpecificConfig, ?tipping: TerminalConfigurationConfigurationResourceTipping, ?verifoneP400: TerminalConfigurationConfigurationResourceDeviceTypeSpecificConfig, ?wifi: TerminalConfigurationConfigurationResourceWifiConfig) =
        {
            Id = id
            IsAccountDefault = isAccountDefault
            Livemode = livemode
            Name = name
            BbposWisepad3 = bbposWisepad3
            BbposWiseposE = bbposWiseposE
            Cellular = cellular
            Offline = offline
            RebootWindow = rebootWindow
            StripeS700 = stripeS700
            StripeS710 = stripeS710
            Tipping = tipping
            VerifoneP400 = verifoneP400
            Wifi = wifi
        }

module TerminalConfiguration =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "terminal.configuration"

type DeletedTerminalReaderDeviceType =
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

type DeletedTerminalReader =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Device type of the reader.
        DeviceType: DeletedTerminalReaderDeviceType
        /// Unique identifier for the object.
        Id: string
        /// Serial number of the reader.
        SerialNumber: string
    }

type DeletedTerminalReader with
    static member New(deleted: bool, deviceType: DeletedTerminalReaderDeviceType, id: string, serialNumber: string) =
        {
            Deleted = deleted
            DeviceType = deviceType
            Id = id
            SerialNumber = serialNumber
        }

module DeletedTerminalReader =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "terminal.reader"

type DeletedTerminalLocation =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

type DeletedTerminalLocation with
    static member New(deleted: bool, id: string) =
        {
            Deleted = deleted
            Id = id
        }

module DeletedTerminalLocation =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "terminal.location"

type DeletedTerminalConfiguration =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

type DeletedTerminalConfiguration with
    static member New(deleted: bool, id: string) =
        {
            Deleted = deleted
            Id = id
        }

module DeletedTerminalConfiguration =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "terminal.configuration"

