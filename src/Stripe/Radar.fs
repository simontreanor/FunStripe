namespace Stripe.Radar

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type Rule =
    {
        /// The action taken on the payment.
        Action: string
        /// Unique identifier for the object.
        Id: string
        /// The predicate to evaluate the payment against.
        Predicate: string
    }

type RadarReviewResourceSession =
    {
        /// The browser used in this browser session (e.g., `Chrome`).
        Browser: string option
        /// Information about the device used for the browser session (e.g., `Samsung SM-G930T`).
        Device: string option
        /// The platform for the browser session (e.g., `Macintosh`).
        Platform: string option
        /// The version for the browser session (e.g., `61.0.3163.100`).
        Version: string option
    }

type RadarReviewResourceLocation =
    {
        /// The city where the payment originated.
        City: string option
        /// Two-letter ISO code representing the country where the payment originated.
        Country: IsoTypes.IsoCountryCode option
        /// The geographic latitude where the payment originated.
        Latitude: decimal option
        /// The geographic longitude where the payment originated.
        Longitude: decimal option
        /// The state/county/province/region where the payment originated.
        Region: string option
    }

type RadarValueListItemType =
    | Account
    | CardBin
    | CardFingerprint
    | CaseSensitiveString
    | Country
    | CryptoFingerprint
    | CustomerId
    | Email
    | IpAddress
    | SepaDebitFingerprint
    | String
    | UsBankAccountFingerprint

/// Value list items allow you to add specific values to a given Radar value list, which can then be used in rules.
/// Related guide: [Managing list items](https://docs.stripe.com/radar/lists#managing-list-items)
type RadarValueListItem =
    {
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// The name or email address of the user who added this item to the value list.
        CreatedBy: string
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// The value of the item.
        Value: string
        /// The identifier of the value list this item belongs to.
        ValueList: string
    }

module RadarValueListItem =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "radar.value_list_item"

/// List of items contained within this value list.
type RadarValueListListItems =
    {
        /// Details about each object.
        Data: RadarValueListItem list
        /// True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        /// The URL where this list can be accessed.
        Url: string
    }

module RadarValueListListItems =
    ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
    let object = "list"

/// Value lists allow you to group values together which can then be referenced in rules.
/// Related guide: [Default Stripe lists](https://docs.stripe.com/radar/lists#managing-list-items)
type RadarValueList =
    {
        /// The name of the value list for use in rules.
        Alias: string
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// The name or email address of the user who created this value list.
        CreatedBy: string
        /// Unique identifier for the object.
        Id: string
        /// The type of items in the value list. One of `card_fingerprint`, `card_bin`, `crypto_fingerprint`, `email`, `ip_address`, `country`, `string`, `case_sensitive_string`, `customer_id`, `account`, `sepa_debit_fingerprint`, or `us_bank_account_fingerprint`.
        ItemType: RadarValueListItemType
        /// List of items contained within this value list.
        ListItems: RadarValueListListItems
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        /// The name of the value list.
        Name: string
    }

module RadarValueList =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "radar.value_list"

/// Client device metadata attached to this payment evaluation.
type InsightsResourcesPaymentEvaluationClientDeviceMetadata =
    {
        /// ID for the Radar Session associated with the payment evaluation. A [Radar Session](https://docs.stripe.com/radar/radar-session) is a snapshot of the browser metadata and device details that help Radar make more accurate predictions on your payments.
        RadarSession: string
    }

/// Customer details attached to this payment evaluation.
type InsightsResourcesPaymentEvaluationCustomerDetails =
    {
        /// The ID of the customer associated with the payment evaluation.
        Customer: string option
        /// The ID of the Account representing the customer associated with the payment evaluation.
        CustomerAccount: string option
        /// The customer's email address.
        Email: string option
        /// The customer's full name or business name.
        Name: string option
        /// The customer's phone number.
        Phone: string option
    }

type InsightsResourcesPaymentEvaluationDisputeOpenedReason =
    | AccountNotAvailable
    | CreditNotProcessed
    | CustomerInitiated
    | Duplicate
    | Fraudulent
    | General
    | Noncompliant
    | ProductNotReceived
    | ProductUnacceptable
    | SubscriptionCanceled
    | Unrecognized

/// Dispute opened event details attached to this payment evaluation.
type InsightsResourcesPaymentEvaluationDisputeOpened =
    {
        /// Amount to dispute for this payment. A positive integer representing how much to charge in [the smallest currency unit](https://docs.stripe.com/currencies#zero-decimal) (for example, 100 cents to charge 1.00 USD or 100 to charge 100 Yen, a zero-decimal currency).
        Amount: int
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// Reason given by cardholder for dispute.
        Reason: InsightsResourcesPaymentEvaluationDisputeOpenedReason
    }

[<Struct>]
type InsightsResourcesPaymentEvaluationEarlyFraudWarningReceivedFraudType =
    | MadeWithLostCard
    | MadeWithStolenCard
    | Other
    | UnauthorizedUseOfCard

/// Early Fraud Warning Received event details attached to this payment evaluation.
type InsightsResourcesPaymentEvaluationEarlyFraudWarningReceived =
    {
        /// The type of fraud labeled by the issuer.
        FraudType: InsightsResourcesPaymentEvaluationEarlyFraudWarningReceivedFraudType
    }

[<Struct>]
type InsightsResourcesPaymentEvaluationEventType =
    | DisputeOpened
    | EarlyFraudWarningReceived
    | Refunded
    | UserInterventionRaised
    | UserInterventionResolved

[<Struct>]
type InsightsResourcesPaymentEvaluationRefundedReason =
    | Duplicate
    | Fraudulent
    | Other
    | RequestedByCustomer

/// Refunded Event details attached to this payment evaluation.
type InsightsResourcesPaymentEvaluationRefunded =
    {
        /// Amount refunded for this payment. A positive integer representing how much to charge in [the smallest currency unit](https://docs.stripe.com/currencies#zero-decimal) (for example, 100 cents to charge 1.00 USD or 100 to charge 100 Yen, a zero-decimal currency).
        Amount: int
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// Indicates the reason for the refund.
        Reason: InsightsResourcesPaymentEvaluationRefundedReason
    }

/// User intervention raised custom event details attached to this payment evaluation
type InsightsResourcesPaymentEvaluationUserInterventionRaisedCustom =
    {
        /// Custom type of user intervention raised. The string must use a snake case description for the type of intervention performed.
        Type: string
    }

[<Struct>]
type InsightsResourcesPaymentEvaluationUserInterventionRaisedType =
    | [<JsonPropertyName("3ds")>] Numeric3ds
    | Captcha
    | Custom

/// User intervention raised event details attached to this payment evaluation
type InsightsResourcesPaymentEvaluationUserInterventionRaised =
    {
        Custom: InsightsResourcesPaymentEvaluationUserInterventionRaisedCustom option
        /// Unique identifier for the user intervention event.
        Key: string
        /// Type of user intervention raised.
        Type: InsightsResourcesPaymentEvaluationUserInterventionRaisedType
    }

[<Struct>]
type InsightsResourcesPaymentEvaluationUserInterventionResolvedOutcome =
    | Abandoned
    | Failed
    | Passed

/// User Intervention Resolved Event details attached to this payment evaluation
type InsightsResourcesPaymentEvaluationUserInterventionResolved =
    {
        /// Unique ID of this intervention. Use this to provide the result.
        Key: string
        /// Result of the intervention if it has been completed.
        Outcome: InsightsResourcesPaymentEvaluationUserInterventionResolvedOutcome option
    }

/// Event reported for this payment evaluation.
type InsightsResourcesPaymentEvaluationEvent =
    {
        DisputeOpened: InsightsResourcesPaymentEvaluationDisputeOpened option
        EarlyFraudWarningReceived: InsightsResourcesPaymentEvaluationEarlyFraudWarningReceived option
        /// Timestamp when the event occurred.
        OccurredAt: DateTime
        Refunded: InsightsResourcesPaymentEvaluationRefunded option
        /// Indicates the type of event attached to the payment evaluation.
        Type: InsightsResourcesPaymentEvaluationEventType
        UserInterventionRaised: InsightsResourcesPaymentEvaluationUserInterventionRaised option
        UserInterventionResolved: InsightsResourcesPaymentEvaluationUserInterventionResolved option
    }

[<Struct>]
type InsightsResourcesPaymentEvaluationMerchantBlockedReason =
    | AuthenticationRequired
    | BlockedForFraud
    | InvalidPayment
    | Other

/// Details of a merchant_blocked outcome attached to this payment evaluation.
type InsightsResourcesPaymentEvaluationMerchantBlocked =
    {
        /// The reason the payment was blocked by the merchant.
        Reason: InsightsResourcesPaymentEvaluationMerchantBlockedReason
    }

[<Struct>]
type InsightsResourcesPaymentEvaluationOutcomeType =
    | Failed
    | MerchantBlocked
    | Rejected
    | Succeeded

[<Struct>]
type InsightsResourcesPaymentEvaluationRejectedCardAddressLine1Check =
    | Fail
    | Pass
    | Unavailable
    | Unchecked

[<Struct>]
type InsightsResourcesPaymentEvaluationRejectedCardAddressPostalCodeCheck =
    | Fail
    | Pass
    | Unavailable
    | Unchecked

[<Struct>]
type InsightsResourcesPaymentEvaluationRejectedCardCvcCheck =
    | Fail
    | Pass
    | Unavailable
    | Unchecked

type InsightsResourcesPaymentEvaluationRejectedCardReason =
    | AuthenticationFailed
    | DoNotHonor
    | Expired
    | IncorrectCvc
    | IncorrectNumber
    | IncorrectPostalCode
    | InsufficientFunds
    | InvalidAccount
    | LostCard
    | Other
    | ProcessingError
    | ReportedStolen
    | TryAgainLater

/// Details of an rejected card outcome attached to this payment evaluation.
type InsightsResourcesPaymentEvaluationRejectedCard =
    {
        /// Result of the address line 1 check.
        [<JsonPropertyName("address_line1_check")>]
        AddressLine1Check: InsightsResourcesPaymentEvaluationRejectedCardAddressLine1Check
        /// Indicates whether the cardholder provided a postal code and if it matched the cardholder’s billing address.
        AddressPostalCodeCheck: InsightsResourcesPaymentEvaluationRejectedCardAddressPostalCodeCheck
        /// Result of the CVC check.
        CvcCheck: InsightsResourcesPaymentEvaluationRejectedCardCvcCheck
        /// Card issuer's reason for the network decline.
        Reason: InsightsResourcesPaymentEvaluationRejectedCardReason
    }

/// Details of an rejected outcome attached to this payment evaluation.
type InsightsResourcesPaymentEvaluationRejected =
    { Card: InsightsResourcesPaymentEvaluationRejectedCard option }

[<Struct>]
type InsightsResourcesPaymentEvaluationSucceededCardAddressLine1Check =
    | Fail
    | Pass
    | Unavailable
    | Unchecked

[<Struct>]
type InsightsResourcesPaymentEvaluationSucceededCardAddressPostalCodeCheck =
    | Fail
    | Pass
    | Unavailable
    | Unchecked

[<Struct>]
type InsightsResourcesPaymentEvaluationSucceededCardCvcCheck =
    | Fail
    | Pass
    | Unavailable
    | Unchecked

/// Details of an succeeded card outcome attached to this payment evaluation.
type InsightsResourcesPaymentEvaluationSucceededCard =
    {
        /// Result of the address line 1 check.
        [<JsonPropertyName("address_line1_check")>]
        AddressLine1Check: InsightsResourcesPaymentEvaluationSucceededCardAddressLine1Check
        /// Indicates whether the cardholder provided a postal code and if it matched the cardholder’s billing address.
        AddressPostalCodeCheck: InsightsResourcesPaymentEvaluationSucceededCardAddressPostalCodeCheck
        /// Result of the CVC check.
        CvcCheck: InsightsResourcesPaymentEvaluationSucceededCardCvcCheck
    }

/// Details of a succeeded outcome attached to this payment evaluation.
type InsightsResourcesPaymentEvaluationSucceeded =
    { Card: InsightsResourcesPaymentEvaluationSucceededCard option }

/// Outcome details for this payment evaluation.
type InsightsResourcesPaymentEvaluationOutcome =
    {
        MerchantBlocked: InsightsResourcesPaymentEvaluationMerchantBlocked option
        /// The PaymentIntent ID associated with the payment evaluation.
        PaymentIntentId: string option
        Rejected: InsightsResourcesPaymentEvaluationRejected option
        Succeeded: InsightsResourcesPaymentEvaluationSucceeded option
        /// Indicates the outcome of the payment evaluation.
        Type: InsightsResourcesPaymentEvaluationOutcomeType
    }

[<Struct>]
type InsightsResourcesPaymentEvaluationMoneyMovementCardCustomerPresence =
    | OffSession
    | OnSession

[<Struct>]
type InsightsResourcesPaymentEvaluationMoneyMovementCardPaymentType =
    | OneOff
    | Recurring
    | SetupOneOff
    | SetupRecurring

/// Money Movement card details attached to this payment.
type InsightsResourcesPaymentEvaluationMoneyMovementCard =
    {
        /// Describes the presence of the customer during the payment.
        CustomerPresence: InsightsResourcesPaymentEvaluationMoneyMovementCardCustomerPresence option
        /// Describes the type of payment.
        PaymentType: InsightsResourcesPaymentEvaluationMoneyMovementCardPaymentType option
    }

/// Money Movement details attached to this payment.
type InsightsResourcesPaymentEvaluationMoneyMovementDetails =
    {
        /// Describes card money movement details for the payment evaluation.
        Card: InsightsResourcesPaymentEvaluationMoneyMovementCard option
    }

module InsightsResourcesPaymentEvaluationMoneyMovementDetails =
    ///Describes the type of money movement. Currently only `card` is supported.
    let moneyMovementType = "card"

/// Address data.
type InsightsResourcesPaymentEvaluationAddress =
    {
        /// City, district, suburb, town, or village.
        City: string option
        /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        Country: IsoTypes.IsoCountryCode option
        /// Address line 1, such as the street, PO Box, or company name.
        [<JsonPropertyName("line1")>]
        Line1: string option
        /// Address line 2, such as the apartment, suite, unit, or building.
        [<JsonPropertyName("line2")>]
        Line2: string option
        /// ZIP or postal code.
        PostalCode: string option
        /// State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
        State: string option
    }

/// Billing details attached to this payment evaluation.
type InsightsResourcesPaymentEvaluationBillingDetails =
    {
        Address: InsightsResourcesPaymentEvaluationAddress
        /// Email address.
        Email: string option
        /// Full name.
        Name: string option
        /// Billing phone number (including extension).
        Phone: string option
    }

/// Payment method details attached to this payment evaluation.
type InsightsResourcesPaymentEvaluationPaymentMethodDetails =
    {
        /// Billing information associated with the payment evaluation.
        BillingDetails: InsightsResourcesPaymentEvaluationBillingDetails option
        /// The payment method used in this payment evaluation.
        PaymentMethod: string
    }

/// Shipping details attached to this payment.
type InsightsResourcesPaymentEvaluationShipping =
    {
        Address: InsightsResourcesPaymentEvaluationAddress
        /// Shipping name.
        Name: string option
        /// Shipping phone number.
        Phone: string option
    }

/// Payment details attached to this payment evaluation.
type InsightsResourcesPaymentEvaluationPaymentDetails =
    {
        /// Amount intended to be collected by this payment. A positive integer representing how much to charge in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal) (e.g., 100 cents to charge $1.00 or 100 to charge ¥100, a zero-decimal currency). The minimum amount is $0.50 US or [equivalent in charge currency](https://docs.stripe.com/currencies#minimum-and-maximum-charge-amounts). The amount value supports up to eight digits (e.g., a value of 99999999 for a USD charge of $999,999.99).
        Amount: int
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        /// Details about the payment's customer presence and type.
        MoneyMovementDetails: InsightsResourcesPaymentEvaluationMoneyMovementDetails option
        /// Details about the payment method used for the payment.
        PaymentMethodDetails: InsightsResourcesPaymentEvaluationPaymentMethodDetails option
        /// Shipping details for the payment evaluation.
        ShippingDetails: InsightsResourcesPaymentEvaluationShipping option
        /// Payment statement descriptor.
        StatementDescriptor: string option
    }

type InsightsResourcesPaymentEvaluationSignalV2RiskLevel =
    | Elevated
    | Highest
    | Low
    | Normal
    | NotAssessed
    | Unknown

/// A payment evaluation signal with evaluated_at, risk_level, and score fields.
type InsightsResourcesPaymentEvaluationSignalV2 =
    {
        /// The time when this signal was evaluated.
        EvaluatedAt: DateTime
        /// Risk level of this signal, based on the score.
        RiskLevel: InsightsResourcesPaymentEvaluationSignalV2RiskLevel
        /// Score for this signal. Possible values for evaluated payments are between 0 and 100. The value is returned with two decimal places and higher scores indicate a higher likelihood of the signal being true. A score of -1 is returned when a model evaluation was not performed, such as requests from incomplete integrations.
        Score: decimal
    }

/// Collection of signals for this payment evaluation.
type InsightsResourcesPaymentEvaluationSignals =
    { FraudulentPayment: InsightsResourcesPaymentEvaluationSignalV2 }

[<Struct>]
type RadarPaymentEvaluationRecommendedAction =
    | Block
    | Continue

/// Payment Evaluations represent the risk lifecycle of an externally processed payment. It includes the Radar risk score from Stripe, payment outcome taken by the merchant or processor, and any post transaction events, such as refunds or disputes. See the [Radar API guide](/radar/multiprocessor) for integration steps.
type RadarPaymentEvaluation =
    {
        ClientDeviceMetadataDetails: InsightsResourcesPaymentEvaluationClientDeviceMetadata option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        CreatedAt: DateTime
        CustomerDetails: InsightsResourcesPaymentEvaluationCustomerDetails option
        /// Event information associated with the payment evaluation, such as refunds, dispute, early fraud warnings, or user interventions.
        Events: InsightsResourcesPaymentEvaluationEvent list option
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        /// Indicates the final outcome for the payment evaluation.
        Outcome: InsightsResourcesPaymentEvaluationOutcome option
        PaymentDetails: InsightsResourcesPaymentEvaluationPaymentDetails option
        /// Recommended action based on the score of the `fraudulent_payment` signal. Possible values are `block` and `continue`.
        RecommendedAction: RadarPaymentEvaluationRecommendedAction
        Signals: InsightsResourcesPaymentEvaluationSignals
    }

module RadarPaymentEvaluation =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "radar.payment_evaluation"

/// An early fraud warning indicates that the card issuer has notified us that a
/// charge may be fraudulent.
/// Related guide: [Early fraud warnings](https://docs.stripe.com/disputes/measuring#early-fraud-warnings)
type RadarEarlyFraudWarning =
    {
        /// An EFW is actionable if it has not received a dispute and has not been fully refunded. You may wish to proactively refund a charge that receives an EFW, in order to avoid receiving a dispute later.
        Actionable: bool
        /// ID of the charge this early fraud warning is for, optionally expanded.
        Charge: string
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// The type of fraud labelled by the issuer. One of `card_never_received`, `fraudulent_card_application`, `made_with_counterfeit_card`, `made_with_lost_card`, `made_with_stolen_card`, `misc`, `unauthorized_use_of_card`.
        FraudType: string
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// ID of the Payment Intent this early fraud warning is for, optionally expanded.
        PaymentIntent: string option
    }

module RadarEarlyFraudWarning =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "radar.early_fraud_warning"

/// Occurs whenever an early fraud warning is updated.
type RadarEarlyFraudWarningUpdated = { Object: RadarEarlyFraudWarning }

/// Occurs whenever an early fraud warning is created.
type RadarEarlyFraudWarningCreated = { Object: RadarEarlyFraudWarning }

type DeletedRadarValueListItem =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedRadarValueListItem =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "radar.value_list_item"

type DeletedRadarValueList =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedRadarValueList =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "radar.value_list"

/// Options to configure Radar. See [Radar Session](https://docs.stripe.com/radar/radar-session) for more information.
type RadarRadarOptions =
    {
        /// A [Radar Session](https://docs.stripe.com/radar/radar-session) is a snapshot of the browser metadata and device details that help Radar make more accurate predictions on your payments.
        Session: string option
    }

