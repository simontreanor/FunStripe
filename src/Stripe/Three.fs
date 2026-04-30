namespace Stripe.Three

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type ThreeDSecureUsage =
    {
        /// Whether 3D Secure is supported on this card.
        Supported: bool
    }

[<Struct>]
type ThreeDSecureDetailsAuthenticationFlow =
    | Challenge
    | Frictionless

[<Struct>]
type ThreeDSecureDetailsElectronicCommerceIndicator =
    | [<JsonPropertyName("01")>] Numeric01
    | [<JsonPropertyName("02")>] Numeric02
    | [<JsonPropertyName("05")>] Numeric05
    | [<JsonPropertyName("06")>] Numeric06
    | [<JsonPropertyName("07")>] Numeric07

type ThreeDSecureDetailsResult =
    | AttemptAcknowledged
    | Authenticated
    | Exempted
    | Failed
    | NotSupported
    | ProcessingError

type ThreeDSecureDetailsResultReason =
    | Abandoned
    | Bypassed
    | Canceled
    | CardNotEnrolled
    | NetworkNotSupported
    | ProtocolError
    | Rejected

[<Struct>]
type ThreeDSecureDetailsVersion =
    | [<JsonPropertyName("1.0.2")>] Numeric102
    | [<JsonPropertyName("2.1.0")>] Numeric210
    | [<JsonPropertyName("2.2.0")>] Numeric220
    | [<JsonPropertyName("2.3.0")>] Numeric230
    | [<JsonPropertyName("2.3.1")>] Numeric231

type ThreeDSecureDetails =
    {
        /// For authenticated transactions: how the customer was authenticated by
        /// the issuing bank.
        AuthenticationFlow: ThreeDSecureDetailsAuthenticationFlow option
        /// The Electronic Commerce Indicator (ECI). A protocol-level field
        /// indicating what degree of authentication was performed.
        ElectronicCommerceIndicator: ThreeDSecureDetailsElectronicCommerceIndicator option
        /// Indicates the outcome of 3D Secure authentication.
        Result: ThreeDSecureDetailsResult option
        /// Additional information about why 3D Secure succeeded or failed based
        /// on the `result`.
        ResultReason: ThreeDSecureDetailsResultReason option
        /// The 3D Secure 1 XID or 3D Secure 2 Directory Server Transaction ID
        /// (dsTransId) for this payment.
        TransactionId: string option
        /// The version of 3D Secure that was used.
        Version: ThreeDSecureDetailsVersion option
    }

[<Struct>]
type ThreeDSecureDetailsChargeAuthenticationFlow =
    | Challenge
    | Frictionless

[<Struct>]
type ThreeDSecureDetailsChargeElectronicCommerceIndicator =
    | [<JsonPropertyName("01")>] Numeric01
    | [<JsonPropertyName("02")>] Numeric02
    | [<JsonPropertyName("05")>] Numeric05
    | [<JsonPropertyName("06")>] Numeric06
    | [<JsonPropertyName("07")>] Numeric07

[<Struct>]
type ThreeDSecureDetailsChargeExemptionIndicator =
    | LowRisk
    | [<JsonPropertyName("none")>] None'

type ThreeDSecureDetailsChargeResult =
    | AttemptAcknowledged
    | Authenticated
    | Exempted
    | Failed
    | NotSupported
    | ProcessingError

type ThreeDSecureDetailsChargeResultReason =
    | Abandoned
    | Bypassed
    | Canceled
    | CardNotEnrolled
    | NetworkNotSupported
    | ProtocolError
    | Rejected

[<Struct>]
type ThreeDSecureDetailsChargeVersion =
    | [<JsonPropertyName("1.0.2")>] Numeric102
    | [<JsonPropertyName("2.1.0")>] Numeric210
    | [<JsonPropertyName("2.2.0")>] Numeric220
    | [<JsonPropertyName("2.3.0")>] Numeric230
    | [<JsonPropertyName("2.3.1")>] Numeric231

type ThreeDSecureDetailsCharge =
    {
        /// For authenticated transactions: how the customer was authenticated by
        /// the issuing bank.
        AuthenticationFlow: ThreeDSecureDetailsChargeAuthenticationFlow option
        /// The Electronic Commerce Indicator (ECI). A protocol-level field
        /// indicating what degree of authentication was performed.
        ElectronicCommerceIndicator: ThreeDSecureDetailsChargeElectronicCommerceIndicator option
        /// The exemption requested via 3DS and accepted by the issuer at authentication time.
        ExemptionIndicator: ThreeDSecureDetailsChargeExemptionIndicator option
        /// Whether Stripe requested the value of `exemption_indicator` in the transaction. This will depend on
        /// the outcome of Stripe's internal risk assessment.
        ExemptionIndicatorApplied: bool option
        /// Indicates the outcome of 3D Secure authentication.
        Result: ThreeDSecureDetailsChargeResult option
        /// Additional information about why 3D Secure succeeded or failed based
        /// on the `result`.
        ResultReason: ThreeDSecureDetailsChargeResultReason option
        /// The 3D Secure 1 XID or 3D Secure 2 Directory Server Transaction ID
        /// (dsTransId) for this payment.
        TransactionId: string option
        /// The version of 3D Secure that was used.
        Version: ThreeDSecureDetailsChargeVersion option
    }

