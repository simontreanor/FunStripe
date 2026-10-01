namespace Stripe.ThreeDSecure

open System.Text.Json.Serialization
open FunStripe
open System

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "3.0.0")>]
type ThreeDSecureAuthenticationDirectoryServer =
    | AmericanExpress
    | CartesBancaires
    | Discover
    | Mastercard
    | Visa

[<Struct>]
type ThreeDSecureAuthenticationMessageCategory =
    | NonPaymentAuthentication
    | PaymentAuthentication

type ThreeDSecureAuthenticationOutcome =
    | Abandoned
    | AttemptAcknowledged
    | Authenticated
    | Canceled
    | Denied
    | Informational
    | InternalError
    | NotSupported
    | NotTriggered
    | ProcessingError
    | Rejected

[<Struct>]
type ThreeDSecureAuthenticationReason =
    | CardholderAuthentication
    | IssuerRequested
    | LiabilityShift
    | ProcessingCosts
    | RegulatoryCompliance

type ThreeDSecureAuthenticationStatus =
    | Canceled
    | [<JsonPropertyName("error")>] Error'
    | Failed
    | RequiresChallenge
    | RequiresSubmission
    | Succeeded

/// Contains additional details about the acquirer for a 3DS Authentication.
type ThreeDSecureStandaloneResourceAcquirerDetails =
    {
        /// The Acquirer BIN (specific to the directory_server).
        AcquirerBin: string option
        /// The two-letter country code of the acquirer ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        AcquirerCountry: IsoTypes.IsoCountryCode option
        /// The Merchant ID (or Card Acceptor ID) that your acquirer assigned you (specific to the directory_server).
        AcquirerMerchantId: string option
        /// The [merchant category code](https://en.wikipedia.org/wiki/Merchant_category_code) as defined by each payment system or directory server.
        Mcc: string option
        /// The merchant name assigned by the acquirer or payment system. Same name used in the authorization message as defined in [ISO 8583](https://en.wikipedia.org/wiki/ISO_8583).
        MerchantName: string option
        /// Requestor ID if you’re enrolled in the card network’s 3DS program. Otherwise, you can omit this field because Stripe assigns a Requestor ID with the card networks.
        RequestorId: string option
    }

type ThreeDSecureStandaloneResourceAcquirerDetails with
    static member New(?acquirerBin: string, ?acquirerCountry: IsoTypes.IsoCountryCode, ?acquirerMerchantId: string, ?mcc: string, ?merchantName: string, ?requestorId: string) =
        {
            AcquirerBin = acquirerBin
            AcquirerCountry = acquirerCountry
            AcquirerMerchantId = acquirerMerchantId
            Mcc = mcc
            MerchantName = merchantName
            RequestorId = requestorId
        }

/// Contains details on the browser for a standalone 3DS Authentication.
type ThreeDSecureStandaloneResourceBrowserDetails =
    {
        /// The HTTP accept headers from the cardholder's browser.
        AcceptHeader: string
        /// The color depth of the cardholder’s screen.
        ColorDepth: int option
        /// The IP address of the browser.
        IpAddress: string
        /// The cardholder browser’s ability to execute Java.
        JavaEnabled: bool option
        /// The cardholder browser’s ability to execute JavaScript.
        JavascriptEnabled: bool
        /// An IETF BCP 47 language tag representing the browser language.
        Language: string
        /// The total height of the cardholder’s screen in pixels.
        ScreenHeight: int option
        /// The total width of the cardholder’s screen in pixels.
        ScreenWidth: int option
        /// The time difference between UTC time and the local time of the cardholder’s browser, in minutes.
        TimezoneOffset: int option
        /// The browser user agent.
        UserAgent: string
    }

type ThreeDSecureStandaloneResourceBrowserDetails with
    static member New(acceptHeader: string, ipAddress: string, javascriptEnabled: bool, language: string, userAgent: string, ?colorDepth: int, ?javaEnabled: bool, ?screenHeight: int, ?screenWidth: int, ?timezoneOffset: int) =
        {
            AcceptHeader = acceptHeader
            IpAddress = ipAddress
            JavascriptEnabled = javascriptEnabled
            Language = language
            UserAgent = userAgent
            ColorDepth = colorDepth
            JavaEnabled = javaEnabled
            ScreenHeight = screenHeight
            ScreenWidth = screenWidth
            TimezoneOffset = timezoneOffset
        }

[<Struct>]
type ThreeDSecureStandaloneResourceChannelType =
    | Browser
    | [<JsonPropertyName("three_r_i")>] ThreeRI

[<Struct>]
type ThreeDSecureStandaloneResourceThreeRiDetailsType =
    | DelayedShipment
    | OtherPayment
    | Recurring
    | SplitShipment

/// Contains details for a 3RI standalone 3DS Authentication.
type ThreeDSecureStandaloneResourceThreeRiDetails =
    {
        /// ID of the previous initial authenticated 3DS Authentication object.
        PreviousAuthentication: string
        /// Type of the 3RI Authentication.
        Type: ThreeDSecureStandaloneResourceThreeRiDetailsType
    }

type ThreeDSecureStandaloneResourceThreeRiDetails with
    static member New(previousAuthentication: string, ``type``: ThreeDSecureStandaloneResourceThreeRiDetailsType) =
        {
            PreviousAuthentication = previousAuthentication
            Type = ``type``
        }

/// Contains details on the channel used (browser, 3RI) for a standalone 3DS Authentication.
type ThreeDSecureStandaloneResourceChannel =
    {
        Browser: ThreeDSecureStandaloneResourceBrowserDetails option
        ThreeRI: ThreeDSecureStandaloneResourceThreeRiDetails option
        /// Type of channel you would prefer to use for this 3DS Authentication. Only browser.
        Type: ThreeDSecureStandaloneResourceChannelType
    }

type ThreeDSecureStandaloneResourceChannel with
    static member New(``type``: ThreeDSecureStandaloneResourceChannelType, ?browser: ThreeDSecureStandaloneResourceBrowserDetails, ?threeRI: ThreeDSecureStandaloneResourceThreeRiDetails) =
        {
            Type = ``type``
            Browser = browser
            ThreeRI = threeRI
        }

[<Struct>]
type ThreeDSecureStandaloneResourceChallengeDetailsType =
    | Mandated
    | Preferred

type ThreeDSecureStandaloneResourceChallengeDetails =
    {
        /// Type of challenge flow you requested for this 3DS Authentication.
        Type: ThreeDSecureStandaloneResourceChallengeDetailsType
    }

type ThreeDSecureStandaloneResourceChallengeDetails with
    static member New(``type``: ThreeDSecureStandaloneResourceChallengeDetailsType) =
        {
            Type = ``type``
        }

[<Struct>]
type ThreeDSecureStandaloneResourceDataShareDetailsType =
    | DsSpecific
    | EmvStandard

type ThreeDSecureStandaloneResourceDataShareDetails =
    {
        /// Type of data share flow you requested for this 3DS Authentication.
        Type: ThreeDSecureStandaloneResourceDataShareDetailsType
    }

type ThreeDSecureStandaloneResourceDataShareDetails with
    static member New(``type``: ThreeDSecureStandaloneResourceDataShareDetailsType) =
        {
            Type = ``type``
        }

[<Struct>]
type ThreeDSecureStandaloneResourceFlowPreferenceType =
    | Challenge
    | DataShare
    | Frictionless

[<Struct>]
type ThreeDSecureStandaloneResourceFrictionlessDetailsType =
    | LowRisk
    | [<JsonPropertyName("none")>] None'

type ThreeDSecureStandaloneResourceFrictionlessDetails =
    {
        /// Type of frictionless flow you requested for this 3DS Authentication.
        Type: ThreeDSecureStandaloneResourceFrictionlessDetailsType
    }

type ThreeDSecureStandaloneResourceFrictionlessDetails with
    static member New(``type``: ThreeDSecureStandaloneResourceFrictionlessDetailsType) =
        {
            Type = ``type``
        }

/// Contains details of the flow preference used for a standalone 3DS Authentication.
type ThreeDSecureStandaloneResourceFlowPreference =
    {
        Challenge: ThreeDSecureStandaloneResourceChallengeDetails option
        DataShare: ThreeDSecureStandaloneResourceDataShareDetails option
        Frictionless: ThreeDSecureStandaloneResourceFrictionlessDetails option
        /// Type of flow you requested for this 3DS Authentication.
        Type: ThreeDSecureStandaloneResourceFlowPreferenceType
    }

type ThreeDSecureStandaloneResourceFlowPreference with
    static member New(``type``: ThreeDSecureStandaloneResourceFlowPreferenceType, ?challenge: ThreeDSecureStandaloneResourceChallengeDetails, ?dataShare: ThreeDSecureStandaloneResourceDataShareDetails, ?frictionless: ThreeDSecureStandaloneResourceFrictionlessDetails) =
        {
            Type = ``type``
            Challenge = challenge
            DataShare = dataShare
            Frictionless = frictionless
        }

[<Struct>]
type ThreeDSecureStandaloneResourceFutureUsageType =
    | CardOnFile
    | Installment
    | Recurring

[<Struct>]
type ThreeDSecureStandaloneResourceExpiryType =
    | Date
    | Never

/// Information about recurring payment expiry
type ThreeDSecureStandaloneResourceExpiry =
    { Date: string option
      Type: ThreeDSecureStandaloneResourceExpiryType }

type ThreeDSecureStandaloneResourceExpiry with
    static member New(``type``: ThreeDSecureStandaloneResourceExpiryType, ?date: string) =
        {
            Type = ``type``
            Date = date
        }

/// Details about installment payments
type ThreeDSecureStandaloneResourceInstallment =
    {
        /// A non-negative integer representing the amount in the [smallest currency unit](/currencies#zero-decimal).
        Amount: int option
        Expiry: ThreeDSecureStandaloneResourceExpiry
        /// The minimum number of time intervals between authorizations.
        IntervalCount: int
        /// The maximum number of installments.
        Number: int
    }

type ThreeDSecureStandaloneResourceInstallment with
    static member New(expiry: ThreeDSecureStandaloneResourceExpiry, intervalCount: int, number: int, ?amount: int) =
        {
            Expiry = expiry
            IntervalCount = intervalCount
            Number = number
            Amount = amount
        }

module ThreeDSecureStandaloneResourceInstallment =
    ///The unit of time for `interval_count`.
    let interval = "day"

/// Details about recurring payments
type ThreeDSecureStandaloneResourceRecurring =
    {
        /// A non-negative integer representing the amount in the [smallest currency unit](/currencies#zero-decimal).
        Amount: int option
        Expiry: ThreeDSecureStandaloneResourceExpiry
        /// The minimum number of time intervals between authorizations.
        IntervalCount: int
    }

type ThreeDSecureStandaloneResourceRecurring with
    static member New(expiry: ThreeDSecureStandaloneResourceExpiry, intervalCount: int, ?amount: int) =
        {
            Expiry = expiry
            IntervalCount = intervalCount
            Amount = amount
        }

module ThreeDSecureStandaloneResourceRecurring =
    ///The unit of time for `interval_count`.
    let interval = "day"

/// Contains information about the future authorisations related to this authentication
type ThreeDSecureStandaloneResourceFutureUsage =
    {
        Installment: ThreeDSecureStandaloneResourceInstallment option
        Recurring: ThreeDSecureStandaloneResourceRecurring option
        /// The type of future usage declared for this 3DS Authentication.
        Type: ThreeDSecureStandaloneResourceFutureUsageType
    }

type ThreeDSecureStandaloneResourceFutureUsage with
    static member New(``type``: ThreeDSecureStandaloneResourceFutureUsageType, ?installment: ThreeDSecureStandaloneResourceInstallment, ?recurring: ThreeDSecureStandaloneResourceRecurring) =
        {
            Type = ``type``
            Installment = installment
            Recurring = recurring
        }

/// Contains details for Cartes Bancaires specific fields in the authentication outcomes.
type ThreeDSecureStandaloneResourceCartesBancaires =
    {
        /// The cryptogram calculation algorithm used by the card Issuer's ACS to calculate the Authentication cryptogram. Also known as cavvAlgorithm. ARes/RReq messageExtension: `CB-AVALGO`
        Avalgo: string
        /// The exemption indicator returned from Cartes Bancaires in the ARes. This is a 3 byte bitmap (lowest significant byte first and most significant bit first) that has been Base64 encoded. String (4 characters). ARes message extension: `CB-EXEMPTION`
        CbExemption: string option
        /// The risk score returned from Cartes Bancaires in the ARes. Numeric value 0-99. ARes/RReq message extension: `CB-SCORE`
        CbScore: string option
    }

type ThreeDSecureStandaloneResourceCartesBancaires with
    static member New(avalgo: string, cbExemption: string option, cbScore: string option) =
        {
            Avalgo = avalgo
            CbExemption = cbExemption
            CbScore = cbScore
        }

/// Contains details specific to the individual network.
type ThreeDSecureStandaloneResourceNetworkDetails =
    { CartesBancaires: ThreeDSecureStandaloneResourceCartesBancaires option }

type ThreeDSecureStandaloneResourceNetworkDetails with
    static member New(?cartesBancaires: ThreeDSecureStandaloneResourceCartesBancaires) =
        {
            CartesBancaires = cartesBancaires
        }

type ThreeDSecureStandaloneResourceOutcomeDetailsAresTransStatus =
    | [<JsonPropertyName("A")>] A
    | [<JsonPropertyName("C")>] C
    | [<JsonPropertyName("D")>] D
    | [<JsonPropertyName("I")>] I
    | [<JsonPropertyName("N")>] N
    | [<JsonPropertyName("R")>] R
    | [<JsonPropertyName("S")>] S
    | [<JsonPropertyName("U")>] U
    | [<JsonPropertyName("Y")>] Y

[<Struct>]
type ThreeDSecureStandaloneResourceOutcomeDetailsProtocolVersion =
    | [<JsonPropertyName("2.1.0")>] Numeric210
    | [<JsonPropertyName("2.2.0")>] Numeric220
    | [<JsonPropertyName("2.3.1")>] Numeric231

type ThreeDSecureStandaloneResourceOutcomeDetailsRequestorChallengeIndicator =
    | [<JsonPropertyName("01")>] Numeric01
    | [<JsonPropertyName("02")>] Numeric02
    | [<JsonPropertyName("03")>] Numeric03
    | [<JsonPropertyName("04")>] Numeric04
    | [<JsonPropertyName("05")>] Numeric05
    | [<JsonPropertyName("06")>] Numeric06

type ThreeDSecureStandaloneResourceOutcomeDetailsRreqTransStatus =
    | [<JsonPropertyName("A")>] A
    | [<JsonPropertyName("C")>] C
    | [<JsonPropertyName("D")>] D
    | [<JsonPropertyName("I")>] I
    | [<JsonPropertyName("N")>] N
    | [<JsonPropertyName("R")>] R
    | [<JsonPropertyName("S")>] S
    | [<JsonPropertyName("U")>] U
    | [<JsonPropertyName("Y")>] Y

/// Contains details on the result for a standalone 3DS Authentication.
type ThreeDSecureStandaloneResourceOutcomeDetails =
    {
        /// Universally unique transaction identifier assigned by the issuer to identify the transaction.
        AcsTransactionId: string option
        /// The Authentication Response Message (ARes) is the issuer's response to the AReq message.
        Ares: string option
        /// TransStatus field on the ARes
        AresTransStatus: ThreeDSecureStandaloneResourceOutcomeDetailsAresTransStatus option
        /// A 28-character Base64 string proving that 3DS was completed. Store this value securely, and don’t reuse it for multiple authorizations.
        Cryptogram: string option
        /// The 3DS2 Directory Server Transaction ID.
        DsTransactionId: string option
        /// Electronic Commerce Indicator provided by the issuer to indicate the result of this 3DS Authentication.
        Eci: string option
        NetworkDetails: ThreeDSecureStandaloneResourceNetworkDetails option
        /// The 3DS protocol version used for this 3DS Authentication.
        ProtocolVersion: ThreeDSecureStandaloneResourceOutcomeDetailsProtocolVersion
        /// The indicator provided to the issuer by Stripe in the AReq that indicates whether a challenge is requested for this Authentication. This indicator should match the flow_preference you specified but may be overridden (for compliance reasons for example).
        RequestorChallengeIndicator: ThreeDSecureStandaloneResourceOutcomeDetailsRequestorChallengeIndicator option
        /// The Results Request Message (RReq) communicates the results of the authentication or verification.
        Rreq: string option
        /// TransStatus field on the RReq
        RreqTransStatus: ThreeDSecureStandaloneResourceOutcomeDetailsRreqTransStatus option
        /// Universally unique transaction identifier assigned by Stripe to identify the transaction.
        ThreeDsServerTransactionId: string
    }

type ThreeDSecureStandaloneResourceOutcomeDetails with
    static member New(protocolVersion: ThreeDSecureStandaloneResourceOutcomeDetailsProtocolVersion, threeDsServerTransactionId: string, ?acsTransactionId: string, ?ares: string, ?aresTransStatus: ThreeDSecureStandaloneResourceOutcomeDetailsAresTransStatus, ?cryptogram: string, ?dsTransactionId: string, ?eci: string, ?networkDetails: ThreeDSecureStandaloneResourceNetworkDetails, ?requestorChallengeIndicator: ThreeDSecureStandaloneResourceOutcomeDetailsRequestorChallengeIndicator, ?rreq: string, ?rreqTransStatus: ThreeDSecureStandaloneResourceOutcomeDetailsRreqTransStatus) =
        {
            ProtocolVersion = protocolVersion
            ThreeDsServerTransactionId = threeDsServerTransactionId
            AcsTransactionId = acsTransactionId
            Ares = ares
            AresTransStatus = aresTransStatus
            Cryptogram = cryptogram
            DsTransactionId = dsTransactionId
            Eci = eci
            NetworkDetails = networkDetails
            RequestorChallengeIndicator = requestorChallengeIndicator
            Rreq = rreq
            RreqTransStatus = rreqTransStatus
        }

/// Contains details about the shipping address for a 3DS Authentication.
type ThreeDSecureStandaloneResourceShippingAddress =
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

type ThreeDSecureStandaloneResourceShippingAddress with
    static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        {
            City = city
            Country = country
            Line1 = line1
            Line2 = line2
            PostalCode = postalCode
            State = state
        }

/// The Standalone 3DS API allows you to run EMV 3D Secure (3DS) authentication using Stripe while authorizing the payment with any PSP.
/// Related guide: [Standalone 3DS](/payments/3d-secure/standalone-3d-secure)
type ThreeDSecureAuthentication =
    {
        AcquirerDetails: ThreeDSecureStandaloneResourceAcquirerDetails option
        /// The amount for this 3DS Authentication.
        Amount: int option
        /// The URL for presenting a challenge to your cardholder, present if status is requires_challenge.
        ChallengeUrl: string option
        Channel: ThreeDSecureStandaloneResourceChannel
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode option
        /// The 3DS directory server with which this 3DS Authentication was processed.
        DirectoryServer: ThreeDSecureAuthenticationDirectoryServer
        /// The URL for performing issuer fingerprinting, present if fingerprinting is supported for the given payment method.
        FingerprintingUrl: string option
        FlowPreference: ThreeDSecureStandaloneResourceFlowPreference option
        FutureUsage: ThreeDSecureStandaloneResourceFutureUsage option
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Indicates whether this 3DS Authentication is being performed for a payment or non-payment use case.
        MessageCategory: ThreeDSecureAuthenticationMessageCategory
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        /// The outcome of this 3DS Authentication.
        Outcome: ThreeDSecureAuthenticationOutcome option
        OutcomeDetails: ThreeDSecureStandaloneResourceOutcomeDetails option
        /// ID of the payment method (a PaymentMethod object) to attach to this 3DS Authentication.
        PaymentMethod: StripeId<Markers.PaymentMethod>
        /// The reason for invoking this 3DS Authentication.
        Reason: ThreeDSecureAuthenticationReason option
        ShippingAddress: ThreeDSecureStandaloneResourceShippingAddress option
        /// Status of this Authentication.
        Status: ThreeDSecureAuthenticationStatus
    }

type ThreeDSecureAuthentication with
    static member New(channel: ThreeDSecureStandaloneResourceChannel, created: DateTime, directoryServer: ThreeDSecureAuthenticationDirectoryServer, id: string, livemode: bool, messageCategory: ThreeDSecureAuthenticationMessageCategory, metadata: Map<string, string> option, paymentMethod: StripeId<Markers.PaymentMethod>, status: ThreeDSecureAuthenticationStatus, ?acquirerDetails: ThreeDSecureStandaloneResourceAcquirerDetails, ?amount: int, ?challengeUrl: string, ?currency: IsoTypes.IsoCurrencyCode, ?fingerprintingUrl: string, ?flowPreference: ThreeDSecureStandaloneResourceFlowPreference, ?futureUsage: ThreeDSecureStandaloneResourceFutureUsage, ?outcome: ThreeDSecureAuthenticationOutcome, ?outcomeDetails: ThreeDSecureStandaloneResourceOutcomeDetails, ?reason: ThreeDSecureAuthenticationReason, ?shippingAddress: ThreeDSecureStandaloneResourceShippingAddress) =
        {
            Channel = channel
            Created = created
            DirectoryServer = directoryServer
            Id = id
            Livemode = livemode
            MessageCategory = messageCategory
            Metadata = metadata
            PaymentMethod = paymentMethod
            Status = status
            AcquirerDetails = acquirerDetails
            Amount = amount
            ChallengeUrl = challengeUrl
            Currency = currency
            FingerprintingUrl = fingerprintingUrl
            FlowPreference = flowPreference
            FutureUsage = futureUsage
            Outcome = outcome
            OutcomeDetails = outcomeDetails
            Reason = reason
            ShippingAddress = shippingAddress
        }

module ThreeDSecureAuthentication =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "three_d_secure.authentication"

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
    | DataShareOnly
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

type ThreeDSecureDetails with
    static member New(authenticationFlow: ThreeDSecureDetailsAuthenticationFlow option, electronicCommerceIndicator: ThreeDSecureDetailsElectronicCommerceIndicator option, result: ThreeDSecureDetailsResult option, resultReason: ThreeDSecureDetailsResultReason option, transactionId: string option, version: ThreeDSecureDetailsVersion option) =
        {
            AuthenticationFlow = authenticationFlow
            ElectronicCommerceIndicator = electronicCommerceIndicator
            Result = result
            ResultReason = resultReason
            TransactionId = transactionId
            Version = version
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
    | DataShareOnly
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

type ThreeDSecureDetailsCharge with
    static member New(authenticationFlow: ThreeDSecureDetailsChargeAuthenticationFlow option, electronicCommerceIndicator: ThreeDSecureDetailsChargeElectronicCommerceIndicator option, exemptionIndicator: ThreeDSecureDetailsChargeExemptionIndicator option, result: ThreeDSecureDetailsChargeResult option, resultReason: ThreeDSecureDetailsChargeResultReason option, transactionId: string option, version: ThreeDSecureDetailsChargeVersion option, ?exemptionIndicatorApplied: bool) =
        {
            AuthenticationFlow = authenticationFlow
            ElectronicCommerceIndicator = electronicCommerceIndicator
            ExemptionIndicator = exemptionIndicator
            Result = result
            ResultReason = resultReason
            TransactionId = transactionId
            Version = version
            ExemptionIndicatorApplied = exemptionIndicatorApplied
        }

type ThreeDSecureUsage =
    {
        /// Whether 3D Secure is supported on this card.
        Supported: bool
    }

type ThreeDSecureUsage with
    static member New(supported: bool) =
        {
            Supported = supported
        }

