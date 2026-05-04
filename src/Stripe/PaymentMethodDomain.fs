namespace Stripe.PaymentMethodDomain

open System.Text.Json.Serialization
open FunStripe
open System

/// Contains additional details about the status of a payment method for a specific payment method domain.
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
type PaymentMethodDomainResourcePaymentMethodStatusDetails =
    {
        /// The error message associated with the status of the payment method on the domain.
        ErrorMessage: string
    }

type PaymentMethodDomainResourcePaymentMethodStatusDetails with
    static member New(errorMessage: string) =
        {
            ErrorMessage = errorMessage
        }

[<Struct>]
type PaymentMethodDomainResourcePaymentMethodStatusStatus =
    | Active
    | Inactive

/// Indicates the status of a specific payment method on a payment method domain.
type PaymentMethodDomainResourcePaymentMethodStatus =
    {
        /// The status of the payment method on the domain.
        Status: PaymentMethodDomainResourcePaymentMethodStatusStatus
        StatusDetails: PaymentMethodDomainResourcePaymentMethodStatusDetails option
    }

type PaymentMethodDomainResourcePaymentMethodStatus with
    static member New(status: PaymentMethodDomainResourcePaymentMethodStatusStatus, ?statusDetails: PaymentMethodDomainResourcePaymentMethodStatusDetails) =
        {
            Status = status
            StatusDetails = statusDetails
        }

/// A payment method domain represents a web domain that you have registered with Stripe.
/// Stripe Elements use registered payment method domains to control where certain payment methods are shown.
/// Related guide: [Payment method domains](https://docs.stripe.com/payments/payment-methods/pmd-registration).
type PaymentMethodDomain =
    {
        AmazonPay: PaymentMethodDomainResourcePaymentMethodStatus
        ApplePay: PaymentMethodDomainResourcePaymentMethodStatus
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// The domain name that this payment method domain object represents.
        DomainName: string
        /// Whether this payment method domain is enabled. If the domain is not enabled, payment methods that require a payment method domain will not appear in Elements.
        Enabled: bool
        GooglePay: PaymentMethodDomainResourcePaymentMethodStatus
        /// Unique identifier for the object.
        Id: string
        Klarna: PaymentMethodDomainResourcePaymentMethodStatus
        Link: PaymentMethodDomainResourcePaymentMethodStatus
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        Paypal: PaymentMethodDomainResourcePaymentMethodStatus
    }

type PaymentMethodDomain with
    static member New(amazonPay: PaymentMethodDomainResourcePaymentMethodStatus, applePay: PaymentMethodDomainResourcePaymentMethodStatus, created: DateTime, domainName: string, enabled: bool, googlePay: PaymentMethodDomainResourcePaymentMethodStatus, id: string, klarna: PaymentMethodDomainResourcePaymentMethodStatus, link: PaymentMethodDomainResourcePaymentMethodStatus, livemode: bool, paypal: PaymentMethodDomainResourcePaymentMethodStatus) =
        {
            AmazonPay = amazonPay
            ApplePay = applePay
            Created = created
            DomainName = domainName
            Enabled = enabled
            GooglePay = googlePay
            Id = id
            Klarna = klarna
            Link = link
            Livemode = livemode
            Paypal = paypal
        }

module PaymentMethodDomain =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "payment_method_domain"

