namespace Stripe.Payments

open System.Text.Json.Serialization
open FunStripe
open System

/// Custom processors represent payment processors not modeled directly in
/// the Stripe API. This resource consists of details about the custom processor
/// used for this payment attempt.
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type PaymentsPrimitivesPaymentRecordsResourceProcessorDetailsResourceCustomDetails =
    {
        /// An opaque string for manual reconciliation of this payment, for example a check number or a payment processor ID.
        PaymentReference: string option
    }

[<Struct>]
type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWalletResourceApplePayType =
    | ApplePay
    | ApplePayLater

type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWalletResourceApplePay =
    {
        /// Type of the apple_pay transaction, one of `apple_pay` or `apple_pay_later`.
        Type: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWalletResourceApplePayType
    }

type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWalletResourceGooglePay =
    { PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWalletResourceGooglePay: string option }

[<Struct>]
type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWalletType =
    | ApplePay
    | GooglePay

type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWallet =
    {
        ApplePay: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWalletResourceApplePay option
        /// (For tokenized numbers only.) The last four digits of the device account number.
        [<JsonPropertyName("dynamic_last4")>]
        DynamicLast4: string option
        GooglePay:
            PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWalletResourceGooglePay option
        /// The type of the card wallet, one of `apple_pay` or `google_pay`. An additional hash is included on the Wallet subhash with a name matching this value. It contains additional information specific to the card wallet type.
        Type: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWalletType
    }

[<Struct>]
type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceThreeDSecureAuthenticationFlow =
    | Challenge
    | Frictionless

type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceThreeDSecureElectronicCommerceIndicator =
    | [<JsonPropertyName("01")>] Numeric01
    | [<JsonPropertyName("02")>] Numeric02
    | [<JsonPropertyName("03")>] Numeric03
    | [<JsonPropertyName("04")>] Numeric04
    | [<JsonPropertyName("05")>] Numeric05
    | [<JsonPropertyName("06")>] Numeric06
    | [<JsonPropertyName("07")>] Numeric07

[<Struct>]
type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceThreeDSecureExemptionIndicator =
    | LowRisk
    | [<JsonPropertyName("none")>] None'

type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceThreeDSecureResult =
    | AttemptAcknowledged
    | Authenticated
    | Exempted
    | Failed
    | NotSupported
    | ProcessingError

type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceThreeDSecureResultReason =
    | Abandoned
    | Bypassed
    | Canceled
    | CardNotEnrolled
    | NetworkNotSupported
    | ProtocolError
    | Rejected

[<Struct>]
type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceThreeDSecureVersion =
    | [<JsonPropertyName("1.0.2")>] Numeric102
    | [<JsonPropertyName("2.1.0")>] Numeric210
    | [<JsonPropertyName("2.2.0")>] Numeric220

type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceThreeDSecure =
    {
        /// For authenticated transactions: Indicates how the issuing bank authenticated the customer.
        AuthenticationFlow:
            PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceThreeDSecureAuthenticationFlow option
        /// The 3D Secure cryptogram, also known as the "authentication value" (AAV, CAVV or AEVV).
        Cryptogram: string option
        /// The Electronic Commerce Indicator (ECI). A protocol-level field indicating what degree of authentication was performed.
        ElectronicCommerceIndicator:
            PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceThreeDSecureElectronicCommerceIndicator option
        /// The exemption requested via 3DS and accepted by the issuer at authentication time.
        ExemptionIndicator:
            PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceThreeDSecureExemptionIndicator option
        /// Whether Stripe requested the value of `exemption_indicator` in the transaction. This will depend on the outcome of Stripe's internal risk assessment.
        ExemptionIndicatorApplied: bool option
        /// Indicates the outcome of 3D Secure authentication.
        Result: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceThreeDSecureResult option
        /// Additional information about why 3D Secure succeeded or failed, based on the `result`.
        ResultReason:
            PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceThreeDSecureResultReason option
        /// The version of 3D Secure that was used.
        Version: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceThreeDSecureVersion option
    }

type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceNetworkToken =
    {
        /// Indicates if Stripe used a network token, either user provided or Stripe managed when processing the transaction.
        Used: bool
    }

[<Struct>]
type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceInstallmentPlanType =
    | Bonus
    | FixedCount
    | Revolving

type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceInstallmentPlan =
    {
        /// For `fixed_count` installment plans, this is the number of installment payments your customer will make to their credit card.
        Count: int option
        /// Type of installment plan, one of `fixed_count`, `revolving`, or `bonus`.
        Type: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceInstallmentPlanType
    }

module PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceInstallmentPlan =
    ///For `fixed_count` installment plans, this is the interval between installment payments your customer will make to their credit card. One of `month`.
    let interval = "month"

type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceInstallments =
    {
        /// Installment plan selected for the payment.
        Plan: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceInstallmentPlan option
    }

[<Struct>]
type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceChecksAddressLine1Check =
    | Fail
    | Pass
    | Unavailable
    | Unchecked

[<Struct>]
type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceChecksAddressPostalCodeCheck =
    | Fail
    | Pass
    | Unavailable
    | Unchecked

[<Struct>]
type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceChecksCvcCheck =
    | Fail
    | Pass
    | Unavailable
    | Unchecked

type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceChecks =
    {
        /// If you provide a value for `address.line1`, the check result is one of `pass`, `fail`, `unavailable`, or `unchecked`.
        [<JsonPropertyName("address_line1_check")>]
        AddressLine1Check:
            PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceChecksAddressLine1Check option
        /// If you provide a address postal code, the check result is one of `pass`, `fail`, `unavailable`, or `unchecked`.
        AddressPostalCodeCheck:
            PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceChecksAddressPostalCodeCheck option
        /// If you provide a CVC, the check results is one of `pass`, `fail`, `unavailable`, or `unchecked`.
        CvcCheck: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceChecksCvcCheck option
    }

/// A representation of a physical address.
type PaymentsPrimitivesPaymentRecordsResourceAddress =
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

type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodAmazonPayDetailsResourceFundingResourceFundingCardBrand =
    | Amex
    | CartesBancaires
    | Diners
    | Discover
    | EftposAu
    | Jcb
    | Link
    | Mastercard
    | Unionpay
    | Visa
    | Unknown

[<Struct>]
type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodAmazonPayDetailsResourceFundingResourceFundingCardFunding =
    | Credit
    | Debit
    | Prepaid
    | Unknown

type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodAmazonPayDetailsResourceFundingResourceFundingCard =
    {
        /// Card brand. Can be `amex`, `cartes_bancaires`, `diners`, `discover`, `eftpos_au`, `jcb`, `link`, `mastercard`, `unionpay`, `visa` or `unknown`.
        Brand:
            PaymentsPrimitivesPaymentRecordsResourcePaymentMethodAmazonPayDetailsResourceFundingResourceFundingCardBrand option
        /// Two-letter ISO code representing the country of the card. You could use this attribute to get a sense of the international breakdown of cards you've collected.
        Country: IsoTypes.IsoCountryCode option
        /// Two-digit number representing the card's expiration month.
        ExpMonth: int option
        /// Four-digit number representing the card's expiration year.
        ExpYear: int option
        /// Card funding type. Can be `credit`, `debit`, `prepaid`, or `unknown`.
        Funding:
            PaymentsPrimitivesPaymentRecordsResourcePaymentMethodAmazonPayDetailsResourceFundingResourceFundingCardFunding option
        /// The last four digits of the card.
        [<JsonPropertyName("last4")>]
        Last4: string option
    }

