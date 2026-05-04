namespace Stripe.Mandate

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.PaymentMethod

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
type MandateMultiUse =
    {
        /// The amount of the payment on a multi use mandate.
        Amount: int option
        /// The currency of the payment on a multi use mandate.
        Currency: IsoTypes.IsoCurrencyCode option
    }

type MandateMultiUse with
    static member New(?amount: int, ?currency: IsoTypes.IsoCurrencyCode) =
        {
            Amount = amount
            Currency = currency
        }

[<Struct>]
type MandateAcssDebitDefaultFor =
    | Invoice
    | Subscription

[<Struct>]
type MandateAcssDebitPaymentSchedule =
    | Combined
    | Interval
    | Sporadic

[<Struct>]
type MandateAcssDebitTransactionType =
    | Business
    | Personal

type MandateAcssDebit =
    {
        /// List of Stripe products where this mandate can be selected automatically.
        DefaultFor: MandateAcssDebitDefaultFor list option
        /// Description of the interval. Only required if the 'payment_schedule' parameter is 'interval' or 'combined'.
        IntervalDescription: string option
        /// Payment schedule for the mandate.
        PaymentSchedule: MandateAcssDebitPaymentSchedule
        /// Transaction type of the mandate.
        TransactionType: MandateAcssDebitTransactionType
    }

type MandateAcssDebit with
    static member New(intervalDescription: string option, paymentSchedule: MandateAcssDebitPaymentSchedule, transactionType: MandateAcssDebitTransactionType, ?defaultFor: MandateAcssDebitDefaultFor list) =
        {
            IntervalDescription = intervalDescription
            PaymentSchedule = paymentSchedule
            TransactionType = transactionType
            DefaultFor = defaultFor
        }

type MandateAmazonPay = { MandateAmazonPay: string option }

type MandateAmazonPay with
    static member New(?mandateAmazonPay: string option) =
        {
            MandateAmazonPay = mandateAmazonPay |> Option.flatten
        }

type MandateAuBecsDebit =
    {
        /// The URL of the mandate. This URL generally contains sensitive information about the customer and should be shared with them exclusively.
        Url: string
    }

type MandateAuBecsDebit with
    static member New(url: string) =
        {
            Url = url
        }

[<Struct>]
type MandateBacsDebitNetworkStatus =
    | Accepted
    | Pending
    | Refused
    | Revoked

[<Struct>]
type MandateBacsDebitRevocationReason =
    | AccountClosed
    | BankAccountRestricted
    | BankOwnershipChanged
    | CouldNotProcess
    | DebitNotAuthorized

type MandateBacsDebit =
    {
        /// The display name for the account on this mandate.
        DisplayName: string option
        /// The status of the mandate on the Bacs network. Can be one of `pending`, `revoked`, `refused`, or `accepted`.
        NetworkStatus: MandateBacsDebitNetworkStatus
        /// The unique reference identifying the mandate on the Bacs network.
        Reference: string
        /// When the mandate is revoked on the Bacs network this field displays the reason for the revocation.
        RevocationReason: MandateBacsDebitRevocationReason option
        /// The service user number for the account on this mandate.
        ServiceUserNumber: string option
        /// The URL that will contain the mandate that the customer has signed.
        Url: string
    }

type MandateBacsDebit with
    static member New(displayName: string option, networkStatus: MandateBacsDebitNetworkStatus, reference: string, revocationReason: MandateBacsDebitRevocationReason option, serviceUserNumber: string option, url: string) =
        {
            DisplayName = displayName
            NetworkStatus = networkStatus
            Reference = reference
            RevocationReason = revocationReason
            ServiceUserNumber = serviceUserNumber
            Url = url
        }

type MandateCashapp = { MandateCashapp: string option }

type MandateCashapp with
    static member New(?mandateCashapp: string option) =
        {
            MandateCashapp = mandateCashapp |> Option.flatten
        }

type MandateKakaoPay = { MandateKakaoPay: string option }

type MandateKakaoPay with
    static member New(?mandateKakaoPay: string option) =
        {
            MandateKakaoPay = mandateKakaoPay |> Option.flatten
        }

type MandateKlarna = { MandateKlarna: string option }

type MandateKlarna with
    static member New(?mandateKlarna: string option) =
        {
            MandateKlarna = mandateKlarna |> Option.flatten
        }

type MandateKrCard = { MandateKrCard: string option }

type MandateKrCard with
    static member New(?mandateKrCard: string option) =
        {
            MandateKrCard = mandateKrCard |> Option.flatten
        }

type MandateLink = { MandateLink: string option }

type MandateLink with
    static member New(?mandateLink: string option) =
        {
            MandateLink = mandateLink |> Option.flatten
        }

type MandateNaverPay = { MandateNaverPay: string option }

type MandateNaverPay with
    static member New(?mandateNaverPay: string option) =
        {
            MandateNaverPay = mandateNaverPay |> Option.flatten
        }

type MandateNzBankAccount = { MandateNzBankAccount: string option }

type MandateNzBankAccount with
    static member New(?mandateNzBankAccount: string option) =
        {
            MandateNzBankAccount = mandateNzBankAccount |> Option.flatten
        }

type MandatePaypal =
    {
        /// The PayPal Billing Agreement ID (BAID). This is an ID generated by PayPal which represents the mandate between the merchant and the customer.
        BillingAgreementId: string option
        /// PayPal account PayerID. This identifier uniquely identifies the PayPal customer.
        PayerId: string option
    }

type MandatePaypal with
    static member New(billingAgreementId: string option, payerId: string option) =
        {
            BillingAgreementId = billingAgreementId
            PayerId = payerId
        }

[<Struct>]
type MandatePaytoAmountType =
    | Fixed
    | Maximum

type MandatePaytoPaymentSchedule =
    | Adhoc
    | Annual
    | Daily
    | Fortnightly
    | Monthly
    | Quarterly
    | SemiAnnual
    | Weekly

type MandatePaytoPurpose =
    | DependantSupport
    | Government
    | Loan
    | Mortgage
    | Other
    | Pension
    | Personal
    | Retail
    | Salary
    | Tax
    | Utility

type MandatePayto =
    {
        /// Amount that will be collected. It is required when `amount_type` is `fixed`.
        Amount: int option
        /// The type of amount that will be collected. The amount charged must be exact or up to the value of `amount` param for `fixed` or `maximum` type respectively. Defaults to `maximum`.
        AmountType: MandatePaytoAmountType
        /// Date, in YYYY-MM-DD format, after which payments will not be collected. Defaults to no end date.
        EndDate: string option
        /// The periodicity at which payments will be collected. Defaults to `adhoc`.
        PaymentSchedule: MandatePaytoPaymentSchedule
        /// The number of payments that will be made during a payment period. Defaults to 1 except for when `payment_schedule` is `adhoc`. In that case, it defaults to no limit.
        PaymentsPerPeriod: int option
        /// The purpose for which payments are made. Has a default value based on your merchant category code.
        Purpose: MandatePaytoPurpose option
        /// Date, in YYYY-MM-DD format, from which payments will be collected. Defaults to confirmation time.
        StartDate: string option
    }

type MandatePayto with
    static member New(amount: int option, amountType: MandatePaytoAmountType, endDate: string option, paymentSchedule: MandatePaytoPaymentSchedule, paymentsPerPeriod: int option, purpose: MandatePaytoPurpose option, startDate: string option) =
        {
            Amount = amount
            AmountType = amountType
            EndDate = endDate
            PaymentSchedule = paymentSchedule
            PaymentsPerPeriod = paymentsPerPeriod
            Purpose = purpose
            StartDate = startDate
        }

[<Struct>]
type MandatePixAmountIncludesIof =
    | Always
    | Never

[<Struct>]
type MandatePixAmountType =
    | Fixed
    | Maximum

[<Struct>]
type MandatePixPaymentSchedule =
    | Halfyearly
    | Monthly
    | Quarterly
    | Weekly
    | Yearly

type MandatePix =
    {
        /// Determines if the amount includes the IOF tax.
        AmountIncludesIof: MandatePixAmountIncludesIof option
        /// Type of amount.
        AmountType: MandatePixAmountType option
        /// Date when the mandate expires and no further payments will be charged, in `YYYY-MM-DD`.
        EndDate: string option
        /// Schedule at which the future payments will be charged.
        PaymentSchedule: MandatePixPaymentSchedule option
        /// Subscription name displayed to buyers in their bank app.
        Reference: string option
        /// Start date of the mandate, in `YYYY-MM-DD`.
        StartDate: string option
    }

type MandatePix with
    static member New(?amountIncludesIof: MandatePixAmountIncludesIof, ?amountType: MandatePixAmountType, ?endDate: string, ?paymentSchedule: MandatePixPaymentSchedule, ?reference: string, ?startDate: string) =
        {
            AmountIncludesIof = amountIncludesIof
            AmountType = amountType
            EndDate = endDate
            PaymentSchedule = paymentSchedule
            Reference = reference
            StartDate = startDate
        }

type MandateRevolutPay = { MandateRevolutPay: string option }

type MandateRevolutPay with
    static member New(?mandateRevolutPay: string option) =
        {
            MandateRevolutPay = mandateRevolutPay |> Option.flatten
        }

type MandateSepaDebit =
    {
        /// The unique reference of the mandate.
        Reference: string
        /// The URL of the mandate. This URL generally contains sensitive information about the customer and should be shared with them exclusively.
        Url: string
    }

type MandateSepaDebit with
    static member New(reference: string, url: string) =
        {
            Reference = reference
            Url = url
        }

[<Struct>]
type MandateUpiAmountType =
    | Fixed
    | Maximum

type MandateUpi =
    {
        /// Amount to be charged for future payments.
        Amount: int option
        /// One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
        AmountType: MandateUpiAmountType option
        /// A description of the mandate or subscription that is meant to be displayed to the customer.
        Description: string option
        /// End date of the mandate or subscription.
        EndDate: DateTime option
    }

type MandateUpi with
    static member New(amount: int option, amountType: MandateUpiAmountType option, description: string option, endDate: DateTime option) =
        {
            Amount = amount
            AmountType = amountType
            Description = description
            EndDate = endDate
        }

type MandateUsBankAccount () = 
    ///Mandate collection method
    member _.CollectionMethod = "paper"


module MandateUsBankAccount =
    ///Mandate collection method
    let collectionMethod = "paper"

type MandatePaymentMethodDetails =
    {
        AcssDebit: MandateAcssDebit option
        AmazonPay: MandateAmazonPay option
        AuBecsDebit: MandateAuBecsDebit option
        BacsDebit: MandateBacsDebit option
        Card: CardMandatePaymentMethodDetails option
        Cashapp: MandateCashapp option
        KakaoPay: MandateKakaoPay option
        Klarna: MandateKlarna option
        KrCard: MandateKrCard option
        Link: MandateLink option
        NaverPay: MandateNaverPay option
        NzBankAccount: MandateNzBankAccount option
        Paypal: MandatePaypal option
        Payto: MandatePayto option
        Pix: MandatePix option
        RevolutPay: MandateRevolutPay option
        SepaDebit: MandateSepaDebit option
        /// This mandate corresponds with a specific payment method type. The `payment_method_details` includes an additional hash with the same name and contains mandate information that's specific to that payment method.
        Type: string
        Upi: MandateUpi option
        UsBankAccount: MandateUsBankAccount option
    }

type MandatePaymentMethodDetails with
    static member New(``type``: string, ?acssDebit: MandateAcssDebit, ?amazonPay: MandateAmazonPay, ?auBecsDebit: MandateAuBecsDebit, ?bacsDebit: MandateBacsDebit, ?card: CardMandatePaymentMethodDetails, ?cashapp: MandateCashapp, ?kakaoPay: MandateKakaoPay, ?klarna: MandateKlarna, ?krCard: MandateKrCard, ?link: MandateLink, ?naverPay: MandateNaverPay, ?nzBankAccount: MandateNzBankAccount, ?paypal: MandatePaypal, ?payto: MandatePayto, ?pix: MandatePix, ?revolutPay: MandateRevolutPay, ?sepaDebit: MandateSepaDebit, ?upi: MandateUpi, ?usBankAccount: MandateUsBankAccount) =
        {
            Type = ``type``
            AcssDebit = acssDebit
            AmazonPay = amazonPay
            AuBecsDebit = auBecsDebit
            BacsDebit = bacsDebit
            Card = card
            Cashapp = cashapp
            KakaoPay = kakaoPay
            Klarna = klarna
            KrCard = krCard
            Link = link
            NaverPay = naverPay
            NzBankAccount = nzBankAccount
            Paypal = paypal
            Payto = payto
            Pix = pix
            RevolutPay = revolutPay
            SepaDebit = sepaDebit
            Upi = upi
            UsBankAccount = usBankAccount
        }

type MandateSingleUse =
    {
        /// The amount of the payment on a single use mandate.
        Amount: int
        /// The currency of the payment on a single use mandate.
        Currency: IsoTypes.IsoCurrencyCode
    }

type MandateSingleUse with
    static member New(amount: int, currency: IsoTypes.IsoCurrencyCode) =
        {
            Amount = amount
            Currency = currency
        }

[<Struct>]
type MandateStatus =
    | Active
    | Inactive
    | Pending

[<Struct>]
type MandateType =
    | MultiUse
    | SingleUse

/// A Mandate is a record of the permission that your customer gives you to debit their payment method.
type Mandate =
    {
        CustomerAcceptance: CustomerAcceptance
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        MultiUse: MandateMultiUse option
        /// The account (if any) that the mandate is intended for.
        OnBehalfOf: string option
        /// ID of the payment method associated with this mandate.
        PaymentMethod: StripeId<Markers.PaymentMethod>
        PaymentMethodDetails: MandatePaymentMethodDetails
        SingleUse: MandateSingleUse option
        /// The mandate status indicates whether or not you can use it to initiate a payment.
        Status: MandateStatus
        /// The type of the mandate.
        Type: MandateType
    }

type Mandate with
    static member New(customerAcceptance: CustomerAcceptance, id: string, livemode: bool, paymentMethod: StripeId<Markers.PaymentMethod>, paymentMethodDetails: MandatePaymentMethodDetails, status: MandateStatus, ``type``: MandateType, ?multiUse: MandateMultiUse, ?onBehalfOf: string, ?singleUse: MandateSingleUse) =
        {
            CustomerAcceptance = customerAcceptance
            Id = id
            Livemode = livemode
            PaymentMethod = paymentMethod
            PaymentMethodDetails = paymentMethodDetails
            Status = status
            Type = ``type``
            MultiUse = multiUse
            OnBehalfOf = onBehalfOf
            SingleUse = singleUse
        }

module Mandate =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "mandate"

[<Struct>]
type MandateOptionsPaytoAmountType =
    | Fixed
    | Maximum

type MandateOptionsPaytoPaymentSchedule =
    | Adhoc
    | Annual
    | Daily
    | Fortnightly
    | Monthly
    | Quarterly
    | SemiAnnual
    | Weekly

type MandateOptionsPaytoPurpose =
    | DependantSupport
    | Government
    | Loan
    | Mortgage
    | Other
    | Pension
    | Personal
    | Retail
    | Salary
    | Tax
    | Utility

type MandateOptionsPayto =
    {
        /// Amount that will be collected. It is required when `amount_type` is `fixed`.
        Amount: int option
        /// The type of amount that will be collected. The amount charged must be exact or up to the value of `amount` param for `fixed` or `maximum` type respectively. Defaults to `maximum`.
        AmountType: MandateOptionsPaytoAmountType option
        /// Date, in YYYY-MM-DD format, after which payments will not be collected. Defaults to no end date.
        EndDate: string option
        /// The periodicity at which payments will be collected. Defaults to `adhoc`.
        PaymentSchedule: MandateOptionsPaytoPaymentSchedule option
        /// The number of payments that will be made during a payment period. Defaults to 1 except for when `payment_schedule` is `adhoc`. In that case, it defaults to no limit.
        PaymentsPerPeriod: int option
        /// The purpose for which payments are made. Has a default value based on your merchant category code.
        Purpose: MandateOptionsPaytoPurpose option
        /// Date, in YYYY-MM-DD format, from which payments will be collected. Defaults to confirmation time.
        StartDate: string option
    }

type MandateOptionsPayto with
    static member New(amount: int option, amountType: MandateOptionsPaytoAmountType option, endDate: string option, paymentSchedule: MandateOptionsPaytoPaymentSchedule option, paymentsPerPeriod: int option, purpose: MandateOptionsPaytoPurpose option, startDate: string option) =
        {
            Amount = amount
            AmountType = amountType
            EndDate = endDate
            PaymentSchedule = paymentSchedule
            PaymentsPerPeriod = paymentsPerPeriod
            Purpose = purpose
            StartDate = startDate
        }

[<Struct>]
type MandateOptionsUpiAmountType =
    | Fixed
    | Maximum

type MandateOptionsUpi =
    {
        /// Amount to be charged for future payments.
        Amount: int option
        /// One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
        AmountType: MandateOptionsUpiAmountType option
        /// A description of the mandate or subscription that is meant to be displayed to the customer.
        Description: string option
        /// End date of the mandate or subscription.
        EndDate: DateTime option
    }

type MandateOptionsUpi with
    static member New(amount: int option, amountType: MandateOptionsUpiAmountType option, description: string option, endDate: DateTime option) =
        {
            Amount = amount
            AmountType = amountType
            Description = description
            EndDate = endDate
        }

/// Occurs whenever a Mandate is updated.
type MandateUpdated = { Object: Mandate }

type MandateUpdated with
    static member New(object: Mandate) =
        {
            Object = object
        }

