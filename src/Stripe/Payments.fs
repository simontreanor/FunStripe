namespace Stripe.Payments

open System.Text.Json.Serialization
open FunStripe
open System

/// A representation of a physical address.
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
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

module PaymentsPrimitivesPaymentRecordsResourceAddress =
    let create
        (
            city: string option,
            country: IsoTypes.IsoCountryCode option,
            line1: string option,
            line2: string option,
            postalCode: string option,
            state: string option
        ) : PaymentsPrimitivesPaymentRecordsResourceAddress
        =
        {
          City = city
          Country = country
          Line1 = line1
          Line2 = line2
          PostalCode = postalCode
          State = state
        }

/// The customer's shipping information associated with this payment.
type PaymentsPrimitivesPaymentRecordsResourceShippingDetails =
    {
        Address: PaymentsPrimitivesPaymentRecordsResourceAddress
        /// The shipping recipient's name.
        Name: string option
        /// The shipping recipient's phone number.
        Phone: string option
    }

module PaymentsPrimitivesPaymentRecordsResourceShippingDetails =
    let create
        (
            address: PaymentsPrimitivesPaymentRecordsResourceAddress,
            name: string option,
            phone: string option
        ) : PaymentsPrimitivesPaymentRecordsResourceShippingDetails
        =
        {
          Address = address
          Name = name
          Phone = phone
        }

/// Custom processors represent payment processors not modeled directly in
/// the Stripe API. This resource consists of details about the custom processor
/// used for this payment attempt.
type PaymentsPrimitivesPaymentRecordsResourceProcessorDetailsResourceCustomDetails =
    {
        /// An opaque string for manual reconciliation of this payment, for example a check number or a payment processor ID.
        PaymentReference: string option
    }

module PaymentsPrimitivesPaymentRecordsResourceProcessorDetailsResourceCustomDetails =
    let create
        (
            paymentReference: string option
        ) : PaymentsPrimitivesPaymentRecordsResourceProcessorDetailsResourceCustomDetails
        =
        {
          PaymentReference = paymentReference
        }

/// Processor information associated with this payment.
type PaymentsPrimitivesPaymentRecordsResourceProcessorDetails =
    { Custom: PaymentsPrimitivesPaymentRecordsResourceProcessorDetailsResourceCustomDetails option }

module PaymentsPrimitivesPaymentRecordsResourceProcessorDetails =
    ///The processor used for this payment attempt.
    let ``type`` = "custom"

    let create
        (
            custom: PaymentsPrimitivesPaymentRecordsResourceProcessorDetailsResourceCustomDetails option
        ) : PaymentsPrimitivesPaymentRecordsResourceProcessorDetails
        =
        {
          Custom = custom
        }

/// Custom Payment Methods represent Payment Method types not modeled directly in
/// the Stripe API. This resource consists of details about the custom payment method
/// used for this payment attempt.
type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCustomDetails =
    {
        /// Display name for the custom (user-defined) payment method type used to make this payment.
        DisplayName: string
        /// The custom payment method type associated with this payment.
        Type: string option
    }

module PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCustomDetails =
    let create
        (
            displayName: string,
            ``type``: string option
        ) : PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCustomDetails
        =
        {
          DisplayName = displayName
          Type = ``type``
        }

type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsBrand =
    | Amex
    | CartesBancaires
    | Diners
    | Discover
    | EftposAu
    | Interac
    | Jcb
    | Link
    | Mastercard
    | Unionpay
    | Unknown
    | Visa

[<Struct>]
type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsFunding =
    | Credit
    | Debit
    | Prepaid
    | Unknown

type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsNetwork =
    | Amex
    | CartesBancaires
    | Diners
    | Discover
    | EftposAu
    | Interac
    | Jcb
    | Link
    | Mastercard
    | Unionpay
    | Unknown
    | Visa

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

module PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceChecks =
    let create
        (
            addressLine1Check: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceChecksAddressLine1Check option,
            addressPostalCodeCheck: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceChecksAddressPostalCodeCheck option,
            cvcCheck: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceChecksCvcCheck option
        ) : PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceChecks
        =
        {
          AddressLine1Check = addressLine1Check
          AddressPostalCodeCheck = addressPostalCodeCheck
          CvcCheck = cvcCheck
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

    let create
        (
            count: int option,
            ``type``: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceInstallmentPlanType
        ) : PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceInstallmentPlan
        =
        {
          Count = count
          Type = ``type``
        }

type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceInstallments =
    {
        /// Installment plan selected for the payment.
        Plan: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceInstallmentPlan option
    }

module PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceInstallments =
    let create
        (
            plan: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceInstallmentPlan option
        ) : PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceInstallments
        =
        {
          Plan = plan
        }

type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceNetworkToken =
    {
        /// Indicates if Stripe used a network token, either user provided or Stripe managed when processing the transaction.
        Used: bool
    }

module PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceNetworkToken =
    let create
        (
            used: bool
        ) : PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceNetworkToken
        =
        {
          Used = used
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

module PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceThreeDSecure =
    let create
        (
            authenticationFlow: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceThreeDSecureAuthenticationFlow option,
            cryptogram: string option,
            electronicCommerceIndicator: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceThreeDSecureElectronicCommerceIndicator option,
            exemptionIndicator: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceThreeDSecureExemptionIndicator option,
            exemptionIndicatorApplied: bool option,
            result: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceThreeDSecureResult option,
            resultReason: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceThreeDSecureResultReason option,
            version: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceThreeDSecureVersion option
        ) : PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceThreeDSecure
        =
        {
          AuthenticationFlow = authenticationFlow
          Cryptogram = cryptogram
          ElectronicCommerceIndicator = electronicCommerceIndicator
          ExemptionIndicator = exemptionIndicator
          ExemptionIndicatorApplied = exemptionIndicatorApplied
          Result = result
          ResultReason = resultReason
          Version = version
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

module PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWalletResourceApplePay =
    let create
        (
            ``type``: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWalletResourceApplePayType
        ) : PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWalletResourceApplePay
        =
        {
          Type = ``type``
        }

type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWalletResourceGooglePay =
    { PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWalletResourceGooglePay: string option }

module PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWalletResourceGooglePay =
    let create
        (
            paymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWalletResourceGooglePay: string option option
        ) : PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWalletResourceGooglePay
        =
        {
          PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWalletResourceGooglePay = paymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWalletResourceGooglePay |> Option.flatten
        }

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

module PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWallet =
    let create
        (
            ``type``: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWalletType,
            applePay: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWalletResourceApplePay option,
            dynamicLast4: string option,
            googlePay: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWalletResourceGooglePay option
        ) : PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWallet
        =
        {
          Type = ``type``
          ApplePay = applePay
          DynamicLast4 = dynamicLast4
          GooglePay = googlePay
        }

[<Struct>]
type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsStoredCredentialUsage =
    | Recurring
    | Unscheduled

/// Details of the card used for this payment attempt.
type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetails =
    {
        /// The authorization code of the payment.
        AuthorizationCode: string option
        /// Card brand. Can be `amex`, `cartes_bancaires`, `diners`, `discover`, `eftpos_au`, `jcb`, `link`, `mastercard`, `unionpay`, `visa` or `unknown`.
        Brand: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsBrand option
        /// When using manual capture, a future timestamp at which the charge will be automatically refunded if uncaptured.
        CaptureBefore: DateTime option
        /// Check results by Card networks on Card address and CVC at time of payment.
        Checks: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceChecks option
        /// Two-letter ISO code representing the country of the card. You could use this attribute to get a sense of the international breakdown of cards you've collected.
        Country: IsoTypes.IsoCountryCode option
        /// A high-level description of the type of cards issued in this range.
        Description: string option
        /// Two-digit number representing the card's expiration month.
        ExpMonth: int option
        /// Four-digit number representing the card's expiration year.
        ExpYear: int option
        /// Uniquely identifies this particular card number. You can use this attribute to check whether two customers who’ve signed up with you are using the same card number, for example. For payment methods that tokenize card information (Apple Pay, Google Pay), the tokenized number might be provided instead of the underlying card number.
        /// *As of May 1, 2021, card fingerprint in India for Connect changed to allow two fingerprints for the same card---one for India and one for the rest of the world.*
        Fingerprint: string option
        /// Card funding type. Can be `credit`, `debit`, `prepaid`, or `unknown`.
        Funding: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsFunding option
        /// Issuer identification number of the card.
        Iin: string option
        /// Installment details for this payment.
        Installments: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceInstallments option
        /// The name of the card's issuing bank.
        Issuer: string option
        /// The last four digits of the card.
        [<JsonPropertyName("last4")>]
        Last4: string option
        /// True if this payment was marked as MOTO and out of scope for SCA.
        Moto: bool option
        /// Identifies which network this charge was processed on. Can be `amex`, `cartes_bancaires`, `diners`, `discover`, `eftpos_au`, `interac`, `jcb`, `link`, `mastercard`, `unionpay`, `visa`, or `unknown`.
        Network: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsNetwork option
        /// Advice code from the card network for the failed payment.
        NetworkAdviceCode: string option
        /// Decline code from the card network for the failed payment.
        NetworkDeclineCode: string option
        /// If this card has network token credentials, this contains the details of the network token credentials.
        NetworkToken: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceNetworkToken option
        /// This is used by the financial networks to identify a transaction. Visa calls this the Transaction ID, Mastercard calls this the Trace ID, and American Express calls this the Acquirer Reference Data. This value will be present if it is returned by the financial network in the authorization response, and null otherwise.
        NetworkTransactionId: string option
        /// The transaction type that was passed for an off-session, Merchant-Initiated transaction, one of `recurring` or `unscheduled`.
        StoredCredentialUsage:
            PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsStoredCredentialUsage option
        /// Populated if this transaction used 3D Secure authentication.
        ThreeDSecure: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceThreeDSecure option
        /// If this Card is part of a card wallet, this contains the details of the card wallet.
        Wallet: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWallet option
    }

module PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetails =
    let create
        (
            authorizationCode: string option,
            brand: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsBrand option,
            checks: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceChecks option,
            country: IsoTypes.IsoCountryCode option,
            description: string option,
            expMonth: int option,
            expYear: int option,
            funding: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsFunding option,
            iin: string option,
            installments: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceInstallments option,
            issuer: string option,
            last4: string option,
            network: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsNetwork option,
            networkAdviceCode: string option,
            networkDeclineCode: string option,
            networkTransactionId: string option,
            storedCredentialUsage: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsStoredCredentialUsage option,
            threeDSecure: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceThreeDSecure option,
            wallet: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceWallet option,
            captureBefore: DateTime option,
            fingerprint: string option option,
            moto: bool option option,
            networkToken: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetailsResourceNetworkToken option option
        ) : PaymentsPrimitivesPaymentRecordsResourcePaymentMethodCardDetails
        =
        {
          AuthorizationCode = authorizationCode
          Brand = brand
          Checks = checks
          Country = country
          Description = description
          ExpMonth = expMonth
          ExpYear = expYear
          Funding = funding
          Iin = iin
          Installments = installments
          Issuer = issuer
          Last4 = last4
          Network = network
          NetworkAdviceCode = networkAdviceCode
          NetworkDeclineCode = networkDeclineCode
          NetworkTransactionId = networkTransactionId
          StoredCredentialUsage = storedCredentialUsage
          ThreeDSecure = threeDSecure
          Wallet = wallet
          CaptureBefore = captureBefore
          Fingerprint = fingerprint |> Option.flatten
          Moto = moto |> Option.flatten
          NetworkToken = networkToken |> Option.flatten
        }

/// Billing details used by the customer for this payment.
type PaymentsPrimitivesPaymentRecordsResourceBillingDetails =
    {
        Address: PaymentsPrimitivesPaymentRecordsResourceAddress
        /// The billing email associated with the method of payment.
        Email: string option
        /// The billing name associated with the method of payment.
        Name: string option
        /// The billing phone number associated with the method of payment.
        Phone: string option
    }

module PaymentsPrimitivesPaymentRecordsResourceBillingDetails =
    let create
        (
            address: PaymentsPrimitivesPaymentRecordsResourceAddress,
            email: string option,
            name: string option,
            phone: string option
        ) : PaymentsPrimitivesPaymentRecordsResourceBillingDetails
        =
        {
          Address = address
          Email = email
          Name = name
          Phone = phone
        }

type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodMobilepayDetailsResourceCard =
    {
        /// Brand of the card used in the transaction
        Brand: string option
        /// Two-letter ISO code representing the country of the card
        Country: IsoTypes.IsoCountryCode option
        /// Two digit number representing the card's expiration month
        ExpMonth: int option
        /// Two digit number representing the card's expiration year
        ExpYear: int option
        /// The last 4 digits of the card
        [<JsonPropertyName("last4")>]
        Last4: string option
    }

module PaymentsPrimitivesPaymentRecordsResourcePaymentMethodMobilepayDetailsResourceCard =
    let create
        (
            brand: string option,
            country: IsoTypes.IsoCountryCode option,
            expMonth: int option,
            expYear: int option,
            last4: string option
        ) : PaymentsPrimitivesPaymentRecordsResourcePaymentMethodMobilepayDetailsResourceCard
        =
        {
          Brand = brand
          Country = country
          ExpMonth = expMonth
          ExpYear = expYear
          Last4 = last4
        }

[<Struct>]
type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodKonbiniDetailsResourceStoreChain =
    | Familymart
    | Lawson
    | Ministop
    | Seicomart

type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodKonbiniDetailsResourceStore =
    {
        /// The name of the convenience store chain where the payment was completed.
        Chain: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodKonbiniDetailsResourceStoreChain option
    }

module PaymentsPrimitivesPaymentRecordsResourcePaymentMethodKonbiniDetailsResourceStore =
    let create
        (
            chain: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodKonbiniDetailsResourceStoreChain option
        ) : PaymentsPrimitivesPaymentRecordsResourcePaymentMethodKonbiniDetailsResourceStore
        =
        {
          Chain = chain
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

module PaymentsPrimitivesPaymentRecordsResourcePaymentMethodAmazonPayDetailsResourceFundingResourceFundingCard =
    let create
        (
            brand: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodAmazonPayDetailsResourceFundingResourceFundingCardBrand option,
            country: IsoTypes.IsoCountryCode option,
            expMonth: int option,
            expYear: int option,
            funding: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodAmazonPayDetailsResourceFundingResourceFundingCardFunding option,
            last4: string option
        ) : PaymentsPrimitivesPaymentRecordsResourcePaymentMethodAmazonPayDetailsResourceFundingResourceFundingCard
        =
        {
          Brand = brand
          Country = country
          ExpMonth = expMonth
          ExpYear = expYear
          Funding = funding
          Last4 = last4
        }

type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodAmazonPayDetailsResourceFunding =
    { Card:
        PaymentsPrimitivesPaymentRecordsResourcePaymentMethodAmazonPayDetailsResourceFundingResourceFundingCard option }

module PaymentsPrimitivesPaymentRecordsResourcePaymentMethodAmazonPayDetailsResourceFunding =
    ///funding type of the underlying payment method.
    let ``type`` = "card"

    let create
        (
            card: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodAmazonPayDetailsResourceFundingResourceFundingCard option
        ) : PaymentsPrimitivesPaymentRecordsResourcePaymentMethodAmazonPayDetailsResourceFunding
        =
        {
          Card = card
        }

type PaymentsPrimitivesPaymentRecordsResourcePaymentMethodAlmaDetailsResourceInstallments =
    {
        /// The number of installments.
        Count: int option
    }

module PaymentsPrimitivesPaymentRecordsResourcePaymentMethodAlmaDetailsResourceInstallments =
    let create
        (
            count: int option
        ) : PaymentsPrimitivesPaymentRecordsResourcePaymentMethodAlmaDetailsResourceInstallments
        =
        {
          Count = count
        }

/// Information about the customer for this payment.
type PaymentsPrimitivesPaymentRecordsResourceCustomerDetails =
    {
        /// ID of the Stripe Customer associated with this payment.
        Customer: string option
        /// The customer's email address.
        Email: string option
        /// The customer's name.
        Name: string option
        /// The customer's phone number.
        Phone: string option
    }

module PaymentsPrimitivesPaymentRecordsResourceCustomerDetails =
    let create
        (
            customer: string option,
            email: string option,
            name: string option,
            phone: string option
        ) : PaymentsPrimitivesPaymentRecordsResourceCustomerDetails
        =
        {
          Customer = customer
          Email = email
          Name = name
          Phone = phone
        }

/// A representation of an amount of money, consisting of an amount and a currency.
type PaymentsPrimitivesPaymentRecordsResourceAmount =
    {
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// A positive integer representing the amount in the currency's [minor unit](https://docs.stripe.com/currencies#zero-decimal). For example, `100` can represent 1 USD or 100 JPY.
        Value: int
    }

module PaymentsPrimitivesPaymentRecordsResourceAmount =
    let create
        (
            currency: IsoTypes.IsoCurrencyCode,
            value: int
        ) : PaymentsPrimitivesPaymentRecordsResourceAmount
        =
        {
          Currency = currency
          Value = value
        }

