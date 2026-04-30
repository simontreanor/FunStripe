namespace Stripe.Dispute

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.File

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type DisputePaymentMethodDetailsAmazonPayDisputeType =
    | Chargeback
    | Claim

type DisputePaymentMethodDetailsAmazonPay =
    {
        /// The AmazonPay dispute type, chargeback or claim
        DisputeType: DisputePaymentMethodDetailsAmazonPayDisputeType option
    }

module DisputePaymentMethodDetailsAmazonPay =
    let create
        (
            disputeType: DisputePaymentMethodDetailsAmazonPayDisputeType option
        ) : DisputePaymentMethodDetailsAmazonPay
        =
        {
          DisputeType = disputeType
        }

type DisputePaymentMethodDetailsCardBrand =
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
type DisputePaymentMethodDetailsCardCaseType =
    | Block
    | Chargeback
    | Compliance
    | Inquiry
    | Resolution

type DisputePaymentMethodDetailsCard =
    {
        /// Card brand. Can be `amex`, `cartes_bancaires`, `diners`, `discover`, `eftpos_au`, `jcb`, `link`, `mastercard`, `unionpay`, `visa` or `unknown`.
        Brand: DisputePaymentMethodDetailsCardBrand
        /// The type of dispute opened. Different case types may have varying fees and financial impact.
        CaseType: DisputePaymentMethodDetailsCardCaseType
        /// The card network's specific dispute reason code, which maps to one of Stripe's primary dispute categories to simplify response guidance. The [Network code map](https://stripe.com/docs/disputes/categories#network-code-map) lists all available dispute reason codes by network.
        NetworkReasonCode: string option
    }

module DisputePaymentMethodDetailsCard =
    let create
        (
            brand: DisputePaymentMethodDetailsCardBrand,
            caseType: DisputePaymentMethodDetailsCardCaseType,
            networkReasonCode: string option
        ) : DisputePaymentMethodDetailsCard
        =
        {
          Brand = brand
          CaseType = caseType
          NetworkReasonCode = networkReasonCode
        }

type DisputePaymentMethodDetailsKlarna =
    {
        /// Chargeback loss reason mapped by Stripe from Klarna's chargeback loss reason
        ChargebackLossReasonCode: string option
        /// The reason for the dispute as defined by Klarna
        ReasonCode: string option
    }

module DisputePaymentMethodDetailsKlarna =
    let create
        (
            reasonCode: string option
        ) : DisputePaymentMethodDetailsKlarna
        =
        {
          ReasonCode = reasonCode
          ChargebackLossReasonCode = None
        }

type DisputePaymentMethodDetailsPaypal =
    {
        /// The ID of the dispute in PayPal.
        CaseId: string option
        /// The reason for the dispute as defined by PayPal
        ReasonCode: string option
    }

module DisputePaymentMethodDetailsPaypal =
    let create
        (
            caseId: string option,
            reasonCode: string option
        ) : DisputePaymentMethodDetailsPaypal
        =
        {
          CaseId = caseId
          ReasonCode = reasonCode
        }

[<Struct>]
type DisputePaymentMethodDetailsType =
    | AmazonPay
    | Card
    | Klarna
    | Paypal

type DisputePaymentMethodDetails =
    {
        AmazonPay: DisputePaymentMethodDetailsAmazonPay option
        Card: DisputePaymentMethodDetailsCard option
        Klarna: DisputePaymentMethodDetailsKlarna option
        Paypal: DisputePaymentMethodDetailsPaypal option
        /// Payment method type.
        Type: DisputePaymentMethodDetailsType
    }

module DisputePaymentMethodDetails =
    let create
        (
            ``type``: DisputePaymentMethodDetailsType
        ) : DisputePaymentMethodDetails
        =
        {
          Type = ``type``
          AmazonPay = None
          Card = None
          Klarna = None
          Paypal = None
        }

[<Struct>]
type DisputeEnhancedEligibilityVisaCompellingEvidence3RequiredActions =
    | MissingCustomerIdentifiers
    | MissingDisputedTransactionDescription
    | MissingMerchandiseOrServices
    | MissingPriorUndisputedTransactionDescription
    | MissingPriorUndisputedTransactions

[<Struct>]
type DisputeEnhancedEligibilityVisaCompellingEvidence3Status =
    | NotQualified
    | Qualified
    | RequiresAction

type DisputeEnhancedEligibilityVisaCompellingEvidence3 =
    {
        /// List of actions required to qualify dispute for Visa Compelling Evidence 3.0 evidence submission.
        RequiredActions: DisputeEnhancedEligibilityVisaCompellingEvidence3RequiredActions list
        /// Visa Compelling Evidence 3.0 eligibility status.
        Status: DisputeEnhancedEligibilityVisaCompellingEvidence3Status
    }

module DisputeEnhancedEligibilityVisaCompellingEvidence3 =
    let create
        (
            requiredActions: DisputeEnhancedEligibilityVisaCompellingEvidence3RequiredActions list,
            status: DisputeEnhancedEligibilityVisaCompellingEvidence3Status
        ) : DisputeEnhancedEligibilityVisaCompellingEvidence3
        =
        {
          RequiredActions = requiredActions
          Status = status
        }

[<Struct>]
type DisputeEnhancedEligibilityVisaComplianceStatus =
    | FeeAcknowledged
    | RequiresFeeAcknowledgement

type DisputeEnhancedEligibilityVisaCompliance =
    {
        /// Visa compliance eligibility status.
        Status: DisputeEnhancedEligibilityVisaComplianceStatus
    }

module DisputeEnhancedEligibilityVisaCompliance =
    let create
        (
            status: DisputeEnhancedEligibilityVisaComplianceStatus
        ) : DisputeEnhancedEligibilityVisaCompliance
        =
        {
          Status = status
        }

type DisputeEnhancedEligibility =
    { VisaCompellingEvidence3: DisputeEnhancedEligibilityVisaCompellingEvidence3 option
      VisaCompliance: DisputeEnhancedEligibilityVisaCompliance option }

module DisputeEnhancedEligibility =
    let create
        (
            visaCompellingEvidence3: DisputeEnhancedEligibilityVisaCompellingEvidence3 option,
            visaCompliance: DisputeEnhancedEligibilityVisaCompliance option
        ) : DisputeEnhancedEligibility
        =
        {
          VisaCompellingEvidence3 = visaCompellingEvidence3
          VisaCompliance = visaCompliance
        }

type DisputeEvidenceDetails =
    {
        /// Date by which evidence must be submitted in order to successfully challenge dispute. Will be 0 if the customer's bank or credit card company doesn't allow a response for this particular dispute.
        DueBy: DateTime option
        EnhancedEligibility: DisputeEnhancedEligibility
        /// Whether evidence has been staged for this dispute.
        HasEvidence: bool
        /// Whether the last evidence submission was submitted past the due date. Defaults to `false` if no evidence submissions have occurred. If `true`, then delivery of the latest evidence is *not* guaranteed.
        PastDue: bool
        /// The number of times evidence has been submitted. Typically, you may only submit evidence once.
        SubmissionCount: int
    }

module DisputeEvidenceDetails =
    let create
        (
            dueBy: DateTime option,
            enhancedEligibility: DisputeEnhancedEligibility,
            hasEvidence: bool,
            pastDue: bool,
            submissionCount: int
        ) : DisputeEvidenceDetails
        =
        {
          DueBy = dueBy
          EnhancedEligibility = enhancedEligibility
          HasEvidence = hasEvidence
          PastDue = pastDue
          SubmissionCount = submissionCount
        }

type DisputeTransactionShippingAddress =
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

module DisputeTransactionShippingAddress =
    let create
        (
            city: string option,
            country: IsoTypes.IsoCountryCode option,
            line1: string option,
            line2: string option,
            postalCode: string option,
            state: string option
        ) : DisputeTransactionShippingAddress
        =
        {
          City = city
          Country = country
          Line1 = line1
          Line2 = line2
          PostalCode = postalCode
          State = state
        }

[<Struct>]
type DisputeVisaCompellingEvidence3DisputedTransactionMerchandiseOrServices =
    | Merchandise
    | Services

type DisputeVisaCompellingEvidence3DisputedTransaction =
    {
        /// User Account ID used to log into business platform. Must be recognizable by the user.
        CustomerAccountId: string option
        /// Unique identifier of the cardholder’s device derived from a combination of at least two hardware and software attributes. Must be at least 20 characters.
        CustomerDeviceFingerprint: string option
        /// Unique identifier of the cardholder’s device such as a device serial number (e.g., International Mobile Equipment Identity [IMEI]). Must be at least 15 characters.
        CustomerDeviceId: string option
        /// The email address of the customer.
        CustomerEmailAddress: string option
        /// The IP address that the customer used when making the purchase.
        CustomerPurchaseIp: string option
        /// Categorization of disputed payment.
        MerchandiseOrServices: DisputeVisaCompellingEvidence3DisputedTransactionMerchandiseOrServices option
        /// A description of the product or service that was sold.
        ProductDescription: string option
        /// The address to which a physical product was shipped. All fields are required for Visa Compelling Evidence 3.0 evidence submission.
        ShippingAddress: DisputeTransactionShippingAddress option
    }

module DisputeVisaCompellingEvidence3DisputedTransaction =
    let create
        (
            customerAccountId: string option,
            customerDeviceFingerprint: string option,
            customerDeviceId: string option,
            customerEmailAddress: string option,
            customerPurchaseIp: string option,
            merchandiseOrServices: DisputeVisaCompellingEvidence3DisputedTransactionMerchandiseOrServices option,
            productDescription: string option,
            shippingAddress: DisputeTransactionShippingAddress option
        ) : DisputeVisaCompellingEvidence3DisputedTransaction
        =
        {
          CustomerAccountId = customerAccountId
          CustomerDeviceFingerprint = customerDeviceFingerprint
          CustomerDeviceId = customerDeviceId
          CustomerEmailAddress = customerEmailAddress
          CustomerPurchaseIp = customerPurchaseIp
          MerchandiseOrServices = merchandiseOrServices
          ProductDescription = productDescription
          ShippingAddress = shippingAddress
        }

type DisputeVisaCompellingEvidence3PriorUndisputedTransaction =
    {
        /// Stripe charge ID for the Visa Compelling Evidence 3.0 eligible prior charge.
        Charge: string
        /// User Account ID used to log into business platform. Must be recognizable by the user.
        CustomerAccountId: string option
        /// Unique identifier of the cardholder’s device derived from a combination of at least two hardware and software attributes. Must be at least 20 characters.
        CustomerDeviceFingerprint: string option
        /// Unique identifier of the cardholder’s device such as a device serial number (e.g., International Mobile Equipment Identity [IMEI]). Must be at least 15 characters.
        CustomerDeviceId: string option
        /// The email address of the customer.
        CustomerEmailAddress: string option
        /// The IP address that the customer used when making the purchase.
        CustomerPurchaseIp: string option
        /// A description of the product or service that was sold.
        ProductDescription: string option
        /// The address to which a physical product was shipped. All fields are required for Visa Compelling Evidence 3.0 evidence submission.
        ShippingAddress: DisputeTransactionShippingAddress option
    }

module DisputeVisaCompellingEvidence3PriorUndisputedTransaction =
    let create
        (
            charge: string,
            customerAccountId: string option,
            customerDeviceFingerprint: string option,
            customerDeviceId: string option,
            customerEmailAddress: string option,
            customerPurchaseIp: string option,
            productDescription: string option,
            shippingAddress: DisputeTransactionShippingAddress option
        ) : DisputeVisaCompellingEvidence3PriorUndisputedTransaction
        =
        {
          Charge = charge
          CustomerAccountId = customerAccountId
          CustomerDeviceFingerprint = customerDeviceFingerprint
          CustomerDeviceId = customerDeviceId
          CustomerEmailAddress = customerEmailAddress
          CustomerPurchaseIp = customerPurchaseIp
          ProductDescription = productDescription
          ShippingAddress = shippingAddress
        }

type DisputeEnhancedEvidenceVisaCompellingEvidence3 =
    {
        /// Disputed transaction details for Visa Compelling Evidence 3.0 evidence submission.
        DisputedTransaction: DisputeVisaCompellingEvidence3DisputedTransaction option
        /// List of exactly two prior undisputed transaction objects for Visa Compelling Evidence 3.0 evidence submission.
        PriorUndisputedTransactions: DisputeVisaCompellingEvidence3PriorUndisputedTransaction list
    }

module DisputeEnhancedEvidenceVisaCompellingEvidence3 =
    let create
        (
            disputedTransaction: DisputeVisaCompellingEvidence3DisputedTransaction option,
            priorUndisputedTransactions: DisputeVisaCompellingEvidence3PriorUndisputedTransaction list
        ) : DisputeEnhancedEvidenceVisaCompellingEvidence3
        =
        {
          DisputedTransaction = disputedTransaction
          PriorUndisputedTransactions = priorUndisputedTransactions
        }

type DisputeEnhancedEvidenceVisaCompliance =
    {
        /// A field acknowledging the fee incurred when countering a Visa compliance dispute. If this field is set to true, evidence can be submitted for the compliance dispute. Stripe collects a 500 USD (or local equivalent) amount to cover the network costs associated with resolving compliance disputes. Stripe refunds the 500 USD network fee if you win the dispute.
        FeeAcknowledged: bool
    }

module DisputeEnhancedEvidenceVisaCompliance =
    let create
        (
            feeAcknowledged: bool
        ) : DisputeEnhancedEvidenceVisaCompliance
        =
        {
          FeeAcknowledged = feeAcknowledged
        }

type DisputeEnhancedEvidence =
    { VisaCompellingEvidence3: DisputeEnhancedEvidenceVisaCompellingEvidence3 option
      VisaCompliance: DisputeEnhancedEvidenceVisaCompliance option }

module DisputeEnhancedEvidence =
    let create
        (
            visaCompellingEvidence3: DisputeEnhancedEvidenceVisaCompellingEvidence3 option,
            visaCompliance: DisputeEnhancedEvidenceVisaCompliance option
        ) : DisputeEnhancedEvidence
        =
        {
          VisaCompellingEvidence3 = visaCompellingEvidence3
          VisaCompliance = visaCompliance
        }

type DisputeEvidenceCancellationPolicy'AnyOf =
    | String of string
    | File of File

type DisputeEvidenceCustomerCommunication'AnyOf =
    | String of string
    | File of File

type DisputeEvidenceCustomerSignature'AnyOf =
    | String of string
    | File of File

type DisputeEvidenceDuplicateChargeDocumentation'AnyOf =
    | String of string
    | File of File

type DisputeEvidenceReceipt'AnyOf =
    | String of string
    | File of File

type DisputeEvidenceRefundPolicy'AnyOf =
    | String of string
    | File of File

type DisputeEvidenceServiceDocumentation'AnyOf =
    | String of string
    | File of File

type DisputeEvidenceShippingDocumentation'AnyOf =
    | String of string
    | File of File

type DisputeEvidenceUncategorizedFile'AnyOf =
    | String of string
    | File of File

type DisputeEvidence =
    {
        /// Any server or activity logs showing proof that the customer accessed or downloaded the purchased digital product. This information should include IP addresses, corresponding timestamps, and any detailed recorded activity.
        AccessActivityLog: string option
        /// The billing address provided by the customer.
        BillingAddress: string option
        /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Your subscription cancellation policy, as shown to the customer.
        CancellationPolicy: DisputeEvidenceCancellationPolicy'AnyOf option
        /// An explanation of how and when the customer was shown your refund policy prior to purchase.
        CancellationPolicyDisclosure: string option
        /// A justification for why the customer's subscription was not canceled.
        CancellationRebuttal: string option
        /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Any communication with the customer that you feel is relevant to your case. Examples include emails proving that the customer received the product or service, or demonstrating their use of or satisfaction with the product or service.
        CustomerCommunication: DisputeEvidenceCustomerCommunication'AnyOf option
        /// The email address of the customer.
        CustomerEmailAddress: string option
        /// The name of the customer.
        CustomerName: string option
        /// The IP address that the customer used when making the purchase.
        CustomerPurchaseIp: string option
        /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) A relevant document or contract showing the customer's signature.
        CustomerSignature: DisputeEvidenceCustomerSignature'AnyOf option
        /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Documentation for the prior charge that can uniquely identify the charge, such as a receipt, shipping label, work order, etc. This document should be paired with a similar document from the disputed payment that proves the two payments are separate.
        DuplicateChargeDocumentation: DisputeEvidenceDuplicateChargeDocumentation'AnyOf option
        /// An explanation of the difference between the disputed charge versus the prior charge that appears to be a duplicate.
        DuplicateChargeExplanation: string option
        /// The Stripe ID for the prior charge which appears to be a duplicate of the disputed charge.
        DuplicateChargeId: string option
        EnhancedEvidence: DisputeEnhancedEvidence
        /// A description of the product or service that was sold.
        ProductDescription: string option
        /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Any receipt or message sent to the customer notifying them of the charge.
        Receipt: DisputeEvidenceReceipt'AnyOf option
        /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Your refund policy, as shown to the customer.
        RefundPolicy: DisputeEvidenceRefundPolicy'AnyOf option
        /// Documentation demonstrating that the customer was shown your refund policy prior to purchase.
        RefundPolicyDisclosure: string option
        /// A justification for why the customer is not entitled to a refund.
        RefundRefusalExplanation: string option
        /// The date on which the customer received or began receiving the purchased service, in a clear human-readable format.
        ServiceDate: string option
        /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Documentation showing proof that a service was provided to the customer. This could include a copy of a signed contract, work order, or other form of written agreement.
        ServiceDocumentation: DisputeEvidenceServiceDocumentation'AnyOf option
        /// The address to which a physical product was shipped. You should try to include as complete address information as possible.
        ShippingAddress: string option
        /// The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc. If multiple carriers were used for this purchase, please separate them with commas.
        ShippingCarrier: string option
        /// The date on which a physical product began its route to the shipping address, in a clear human-readable format.
        ShippingDate: string option
        /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Documentation showing proof that a product was shipped to the customer at the same address the customer provided to you. This could include a copy of the shipment receipt, shipping label, etc. It should show the customer's full shipping address, if possible.
        ShippingDocumentation: DisputeEvidenceShippingDocumentation'AnyOf option
        /// The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
        ShippingTrackingNumber: string option
        /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Any additional evidence or statements.
        UncategorizedFile: DisputeEvidenceUncategorizedFile'AnyOf option
        /// Any additional evidence or statements.
        UncategorizedText: string option
    }

module DisputeEvidence =
    let create
        (
            accessActivityLog: string option,
            billingAddress: string option,
            cancellationPolicy: DisputeEvidenceCancellationPolicy'AnyOf option,
            cancellationPolicyDisclosure: string option,
            cancellationRebuttal: string option,
            customerCommunication: DisputeEvidenceCustomerCommunication'AnyOf option,
            customerEmailAddress: string option,
            customerName: string option,
            customerPurchaseIp: string option,
            customerSignature: DisputeEvidenceCustomerSignature'AnyOf option,
            duplicateChargeDocumentation: DisputeEvidenceDuplicateChargeDocumentation'AnyOf option,
            duplicateChargeExplanation: string option,
            duplicateChargeId: string option,
            enhancedEvidence: DisputeEnhancedEvidence,
            productDescription: string option,
            receipt: DisputeEvidenceReceipt'AnyOf option,
            refundPolicy: DisputeEvidenceRefundPolicy'AnyOf option,
            refundPolicyDisclosure: string option,
            refundRefusalExplanation: string option,
            serviceDate: string option,
            serviceDocumentation: DisputeEvidenceServiceDocumentation'AnyOf option,
            shippingAddress: string option,
            shippingCarrier: string option,
            shippingDate: string option,
            shippingDocumentation: DisputeEvidenceShippingDocumentation'AnyOf option,
            shippingTrackingNumber: string option,
            uncategorizedFile: DisputeEvidenceUncategorizedFile'AnyOf option,
            uncategorizedText: string option
        ) : DisputeEvidence
        =
        {
          AccessActivityLog = accessActivityLog
          BillingAddress = billingAddress
          CancellationPolicy = cancellationPolicy
          CancellationPolicyDisclosure = cancellationPolicyDisclosure
          CancellationRebuttal = cancellationRebuttal
          CustomerCommunication = customerCommunication
          CustomerEmailAddress = customerEmailAddress
          CustomerName = customerName
          CustomerPurchaseIp = customerPurchaseIp
          CustomerSignature = customerSignature
          DuplicateChargeDocumentation = duplicateChargeDocumentation
          DuplicateChargeExplanation = duplicateChargeExplanation
          DuplicateChargeId = duplicateChargeId
          EnhancedEvidence = enhancedEvidence
          ProductDescription = productDescription
          Receipt = receipt
          RefundPolicy = refundPolicy
          RefundPolicyDisclosure = refundPolicyDisclosure
          RefundRefusalExplanation = refundRefusalExplanation
          ServiceDate = serviceDate
          ServiceDocumentation = serviceDocumentation
          ShippingAddress = shippingAddress
          ShippingCarrier = shippingCarrier
          ShippingDate = shippingDate
          ShippingDocumentation = shippingDocumentation
          ShippingTrackingNumber = shippingTrackingNumber
          UncategorizedFile = uncategorizedFile
          UncategorizedText = uncategorizedText
        }

[<Struct>]
type DisputeEnhancedEligibilityTypes =
    | VisaCompellingEvidence3
    | VisaCompliance

