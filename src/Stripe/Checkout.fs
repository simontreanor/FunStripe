namespace Stripe.Checkout

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Mandate
open Stripe.PaymentMethod

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
type CheckoutSessionBillingAddressCollection =
    | Auto
    | Required

type CheckoutSessionCustomer'AnyOf =
    | String of string
    | Customer of Customer
    | DeletedCustomer of DeletedCustomer

[<Struct>]
type CheckoutSessionCustomerCreation =
    | Always
    | IfRequired

/// The line items purchased by the customer.
type CheckoutSessionLineItems =
    {
        /// Details about each object.
        Data: Item list
        /// True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        /// The URL where this list can be accessed.
        Url: string
    }

type CheckoutSessionLineItems with
    static member New(data: Item list, hasMore: bool, url: string) =
        {
            Data = data
            HasMore = hasMore
            Url = url
        }

module CheckoutSessionLineItems =
    ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
    let object = "list"

type CheckoutSessionLocale =
    | Auto
    | Bg
    | Cs
    | Da
    | De
    | El
    | En
    | [<JsonPropertyName("en-GB")>] EnGB
    | Es
    | [<JsonPropertyName("es-419")>] Es419
    | Et
    | Fi
    | Fil
    | Fr
    | [<JsonPropertyName("fr-CA")>] FrCA
    | Hr
    | Hu
    | Id
    | It
    | Ja
    | Ko
    | Lt
    | Lv
    | Ms
    | Mt
    | Nb
    | Nl
    | Pl
    | Pt
    | [<JsonPropertyName("pt-BR")>] PtBR
    | Ro
    | Ru
    | Sk
    | Sl
    | Sv
    | Th
    | Tr
    | Vi
    | Zh
    | [<JsonPropertyName("zh-HK")>] ZhHK
    | [<JsonPropertyName("zh-TW")>] ZhTW

[<Struct>]
type CheckoutSessionMode =
    | Payment
    | Setup
    | Subscription

[<Struct>]
type CheckoutSessionOriginContext =
    | MobileApp
    | Web

[<Struct>]
type CheckoutSessionPaymentMethodCollection =
    | Always
    | IfRequired

[<Struct>]
type CheckoutAcssDebitMandateOptionsDefaultFor =
    | Invoice
    | Subscription

[<Struct>]
type CheckoutAcssDebitMandateOptionsPaymentSchedule =
    | Combined
    | Interval
    | Sporadic

[<Struct>]
type CheckoutAcssDebitMandateOptionsTransactionType =
    | Business
    | Personal

type CheckoutAcssDebitMandateOptions =
    {
        /// A URL for custom mandate text
        CustomMandateUrl: string option
        /// List of Stripe products where this mandate can be selected automatically. Returned when the Session is in `setup` mode.
        DefaultFor: CheckoutAcssDebitMandateOptionsDefaultFor list option
        /// Description of the interval. Only required if the 'payment_schedule' parameter is 'interval' or 'combined'.
        IntervalDescription: string option
        /// Payment schedule for the mandate.
        PaymentSchedule: CheckoutAcssDebitMandateOptionsPaymentSchedule option
        /// Transaction type of the mandate.
        TransactionType: CheckoutAcssDebitMandateOptionsTransactionType option
    }

type CheckoutAcssDebitMandateOptions with
    static member New(intervalDescription: string option, paymentSchedule: CheckoutAcssDebitMandateOptionsPaymentSchedule option, transactionType: CheckoutAcssDebitMandateOptionsTransactionType option, ?customMandateUrl: string, ?defaultFor: CheckoutAcssDebitMandateOptionsDefaultFor list) =
        {
            IntervalDescription = intervalDescription
            PaymentSchedule = paymentSchedule
            TransactionType = transactionType
            CustomMandateUrl = customMandateUrl
            DefaultFor = defaultFor
        }

[<Struct>]
type CheckoutAcssDebitPaymentMethodOptionsCurrency =
    | Cad
    | Usd

[<Struct>]
type CheckoutAcssDebitPaymentMethodOptionsSetupFutureUsage =
    | [<JsonPropertyName("none")>] None'
    | OffSession
    | OnSession

[<Struct>]
type CheckoutAcssDebitPaymentMethodOptionsVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

type CheckoutAcssDebitPaymentMethodOptions =
    {
        /// Currency supported by the bank account. Returned when the Session is in `setup` mode.
        Currency: CheckoutAcssDebitPaymentMethodOptionsCurrency option
        MandateOptions: CheckoutAcssDebitMandateOptions option
        /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
        /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
        SetupFutureUsage: CheckoutAcssDebitPaymentMethodOptionsSetupFutureUsage option
        /// Controls when Stripe will attempt to debit the funds from the customer's account. The date must be a string in YYYY-MM-DD format. The date must be in the future and between 3 and 15 calendar days from now.
        TargetDate: string option
        /// Bank account verification method. The default value is `automatic`.
        VerificationMethod: CheckoutAcssDebitPaymentMethodOptionsVerificationMethod option
    }

type CheckoutAcssDebitPaymentMethodOptions with
    static member New(?currency: CheckoutAcssDebitPaymentMethodOptionsCurrency, ?mandateOptions: CheckoutAcssDebitMandateOptions, ?setupFutureUsage: CheckoutAcssDebitPaymentMethodOptionsSetupFutureUsage, ?targetDate: string, ?verificationMethod: CheckoutAcssDebitPaymentMethodOptionsVerificationMethod) =
        {
            Currency = currency
            MandateOptions = mandateOptions
            SetupFutureUsage = setupFutureUsage
            TargetDate = targetDate
            VerificationMethod = verificationMethod
        }

type CheckoutAffirmPaymentMethodOptions () = 
    ///Controls when the funds will be captured from the customer's account.
    member _.CaptureMethod = "manual"
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    member _.SetupFutureUsage = "none"


module CheckoutAffirmPaymentMethodOptions =
    ///Controls when the funds will be captured from the customer's account.
    let captureMethod = "manual"

    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    let setupFutureUsage = "none"

type CheckoutAfterpayClearpayPaymentMethodOptions () = 
    ///Controls when the funds will be captured from the customer's account.
    member _.CaptureMethod = "manual"
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    member _.SetupFutureUsage = "none"


module CheckoutAfterpayClearpayPaymentMethodOptions =
    ///Controls when the funds will be captured from the customer's account.
    let captureMethod = "manual"

    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    let setupFutureUsage = "none"

type CheckoutAlipayPaymentMethodOptions () = 
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    member _.SetupFutureUsage = "none"


module CheckoutAlipayPaymentMethodOptions =
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    let setupFutureUsage = "none"

type CheckoutAlmaPaymentMethodOptions () = 
    ///Controls when the funds will be captured from the customer's account.
    member _.CaptureMethod = "manual"


module CheckoutAlmaPaymentMethodOptions =
    ///Controls when the funds will be captured from the customer's account.
    let captureMethod = "manual"

[<Struct>]
type CheckoutAmazonPayPaymentMethodOptionsSetupFutureUsage =
    | [<JsonPropertyName("none")>] None'
    | OffSession

type CheckoutAmazonPayPaymentMethodOptions =
    {
        /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
        /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
        SetupFutureUsage: CheckoutAmazonPayPaymentMethodOptionsSetupFutureUsage option
    }

type CheckoutAmazonPayPaymentMethodOptions with
    static member New(?setupFutureUsage: CheckoutAmazonPayPaymentMethodOptionsSetupFutureUsage) =
        {
            SetupFutureUsage = setupFutureUsage
        }

module CheckoutAmazonPayPaymentMethodOptions =
    ///Controls when the funds will be captured from the customer's account.
    let captureMethod = "manual"

type CheckoutAuBecsDebitPaymentMethodOptions =
    {
        /// Controls when Stripe will attempt to debit the funds from the customer's account. The date must be a string in YYYY-MM-DD format. The date must be in the future and between 3 and 15 calendar days from now.
        TargetDate: string option
    }

type CheckoutAuBecsDebitPaymentMethodOptions with
    static member New(?targetDate: string) =
        {
            TargetDate = targetDate
        }

module CheckoutAuBecsDebitPaymentMethodOptions =
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    let setupFutureUsage = "none"

[<Struct>]
type CheckoutBacsDebitPaymentMethodOptionsSetupFutureUsage =
    | [<JsonPropertyName("none")>] None'
    | OffSession
    | OnSession

type CheckoutPaymentMethodOptionsMandateOptionsBacsDebit =
    {
        /// Prefix used to generate the Mandate reference. Must be at most 12 characters long. Must consist of only uppercase letters, numbers, spaces, or the following special characters: '/', '_', '-', '&', '.'. Cannot begin with 'DDIC' or 'STRIPE'.
        ReferencePrefix: string option
    }

type CheckoutPaymentMethodOptionsMandateOptionsBacsDebit with
    static member New(?referencePrefix: string) =
        {
            ReferencePrefix = referencePrefix
        }

type CheckoutBacsDebitPaymentMethodOptions =
    {
        MandateOptions: CheckoutPaymentMethodOptionsMandateOptionsBacsDebit option
        /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
        /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
        SetupFutureUsage: CheckoutBacsDebitPaymentMethodOptionsSetupFutureUsage option
        /// Controls when Stripe will attempt to debit the funds from the customer's account. The date must be a string in YYYY-MM-DD format. The date must be in the future and between 3 and 15 calendar days from now.
        TargetDate: string option
    }

type CheckoutBacsDebitPaymentMethodOptions with
    static member New(?mandateOptions: CheckoutPaymentMethodOptionsMandateOptionsBacsDebit, ?setupFutureUsage: CheckoutBacsDebitPaymentMethodOptionsSetupFutureUsage, ?targetDate: string) =
        {
            MandateOptions = mandateOptions
            SetupFutureUsage = setupFutureUsage
            TargetDate = targetDate
        }

type CheckoutBancontactPaymentMethodOptions () = 
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    member _.SetupFutureUsage = "none"


module CheckoutBancontactPaymentMethodOptions =
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    let setupFutureUsage = "none"

type CheckoutBilliePaymentMethodOptions () = 
    ///Controls when the funds will be captured from the customer's account.
    member _.CaptureMethod = "manual"


module CheckoutBilliePaymentMethodOptions =
    ///Controls when the funds will be captured from the customer's account.
    let captureMethod = "manual"

[<Struct>]
type CheckoutBoletoPaymentMethodOptionsSetupFutureUsage =
    | [<JsonPropertyName("none")>] None'
    | OffSession
    | OnSession

type CheckoutBoletoPaymentMethodOptions =
    {
        /// The number of calendar days before a Boleto voucher expires. For example, if you create a Boleto voucher on Monday and you set expires_after_days to 2, the Boleto voucher will expire on Wednesday at 23:59 America/Sao_Paulo time.
        ExpiresAfterDays: int
        /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
        /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
        SetupFutureUsage: CheckoutBoletoPaymentMethodOptionsSetupFutureUsage option
    }

type CheckoutBoletoPaymentMethodOptions with
    static member New(expiresAfterDays: int, ?setupFutureUsage: CheckoutBoletoPaymentMethodOptionsSetupFutureUsage) =
        {
            ExpiresAfterDays = expiresAfterDays
            SetupFutureUsage = setupFutureUsage
        }

type CheckoutCardInstallmentsOptions =
    {
        /// Indicates if installments are enabled
        Enabled: bool option
    }

type CheckoutCardInstallmentsOptions with
    static member New(?enabled: bool) =
        {
            Enabled = enabled
        }

[<Struct>]
type CheckoutCardPaymentMethodOptionsRequestExtendedAuthorization =
    | IfAvailable
    | Never

[<Struct>]
type CheckoutCardPaymentMethodOptionsRequestIncrementalAuthorization =
    | IfAvailable
    | Never

[<Struct>]
type CheckoutCardPaymentMethodOptionsRequestMulticapture =
    | IfAvailable
    | Never

[<Struct>]
type CheckoutCardPaymentMethodOptionsRequestOvercapture =
    | IfAvailable
    | Never

[<Struct>]
type CheckoutCardPaymentMethodOptionsRequestThreeDSecure =
    | Any
    | Automatic
    | Challenge

[<Struct>]
type CheckoutCardPaymentMethodOptionsSetupFutureUsage =
    | [<JsonPropertyName("none")>] None'
    | OffSession
    | OnSession

type CheckoutCardPaymentMethodOptions =
    {
        Installments: CheckoutCardInstallmentsOptions option
        /// Request ability to [capture beyond the standard authorization validity window](/payments/extended-authorization) for this CheckoutSession.
        RequestExtendedAuthorization: CheckoutCardPaymentMethodOptionsRequestExtendedAuthorization option
        /// Request ability to [increment the authorization](/payments/incremental-authorization) for this CheckoutSession.
        RequestIncrementalAuthorization: CheckoutCardPaymentMethodOptionsRequestIncrementalAuthorization option
        /// Request ability to make [multiple captures](/payments/multicapture) for this CheckoutSession.
        RequestMulticapture: CheckoutCardPaymentMethodOptionsRequestMulticapture option
        /// Request ability to [overcapture](/payments/overcapture) for this CheckoutSession.
        RequestOvercapture: CheckoutCardPaymentMethodOptionsRequestOvercapture option
        /// We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://docs.stripe.com/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. If not provided, this value defaults to `automatic`. Read our guide on [manually requesting 3D Secure](https://docs.stripe.com/payments/3d-secure/authentication-flow#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
        RequestThreeDSecure: CheckoutCardPaymentMethodOptionsRequestThreeDSecure
        Restrictions: PaymentPagesPrivateCardPaymentMethodOptionsResourceRestrictions option
        /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
        /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
        SetupFutureUsage: CheckoutCardPaymentMethodOptionsSetupFutureUsage option
        /// Provides information about a card payment that customers see on their statements. Concatenated with the Kana prefix (shortened Kana descriptor) or Kana statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 22 characters. On card statements, the *concatenation* of both prefix and suffix (including separators) will appear truncated to 22 characters.
        StatementDescriptorSuffixKana: string option
        /// Provides information about a card payment that customers see on their statements. Concatenated with the Kanji prefix (shortened Kanji descriptor) or Kanji statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 17 characters. On card statements, the *concatenation* of both prefix and suffix (including separators) will appear truncated to 17 characters.
        StatementDescriptorSuffixKanji: string option
    }

type CheckoutCardPaymentMethodOptions with
    static member New(requestThreeDSecure: CheckoutCardPaymentMethodOptionsRequestThreeDSecure, ?installments: CheckoutCardInstallmentsOptions, ?requestExtendedAuthorization: CheckoutCardPaymentMethodOptionsRequestExtendedAuthorization, ?requestIncrementalAuthorization: CheckoutCardPaymentMethodOptionsRequestIncrementalAuthorization, ?requestMulticapture: CheckoutCardPaymentMethodOptionsRequestMulticapture, ?requestOvercapture: CheckoutCardPaymentMethodOptionsRequestOvercapture, ?restrictions: PaymentPagesPrivateCardPaymentMethodOptionsResourceRestrictions, ?setupFutureUsage: CheckoutCardPaymentMethodOptionsSetupFutureUsage, ?statementDescriptorSuffixKana: string, ?statementDescriptorSuffixKanji: string) =
        {
            RequestThreeDSecure = requestThreeDSecure
            Installments = installments
            RequestExtendedAuthorization = requestExtendedAuthorization
            RequestIncrementalAuthorization = requestIncrementalAuthorization
            RequestMulticapture = requestMulticapture
            RequestOvercapture = requestOvercapture
            Restrictions = restrictions
            SetupFutureUsage = setupFutureUsage
            StatementDescriptorSuffixKana = statementDescriptorSuffixKana
            StatementDescriptorSuffixKanji = statementDescriptorSuffixKanji
        }

module CheckoutCardPaymentMethodOptions =
    ///Controls when the funds will be captured from the customer's account.
    let captureMethod = "manual"

type CheckoutCashappPaymentMethodOptions () = 
    ///Controls when the funds will be captured from the customer's account.
    member _.CaptureMethod = "manual"
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    member _.SetupFutureUsage = "none"


module CheckoutCashappPaymentMethodOptions =
    ///Controls when the funds will be captured from the customer's account.
    let captureMethod = "manual"

    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    let setupFutureUsage = "none"

type CheckoutCustomerBalanceBankTransferPaymentMethodOptionsRequestedAddressTypes =
    | Aba
    | Iban
    | Sepa
    | SortCode
    | Spei
    | Swift
    | Zengin

[<Struct>]
type CheckoutCustomerBalanceBankTransferPaymentMethodOptionsType =
    | EuBankTransfer
    | GbBankTransfer
    | JpBankTransfer
    | MxBankTransfer
    | UsBankTransfer

type CheckoutCustomerBalanceBankTransferPaymentMethodOptions =
    {
        EuBankTransfer: PaymentMethodOptionsCustomerBalanceEuBankAccount option
        /// List of address types that should be returned in the financial_addresses response. If not specified, all valid types will be returned.
        /// Permitted values include: `sort_code`, `zengin`, `iban`, or `spei`.
        RequestedAddressTypes: CheckoutCustomerBalanceBankTransferPaymentMethodOptionsRequestedAddressTypes list option
        /// The bank transfer type that this PaymentIntent is allowed to use for funding Permitted values include: `eu_bank_transfer`, `gb_bank_transfer`, `jp_bank_transfer`, `mx_bank_transfer`, or `us_bank_transfer`.
        Type: CheckoutCustomerBalanceBankTransferPaymentMethodOptionsType option
    }

type CheckoutCustomerBalanceBankTransferPaymentMethodOptions with
    static member New(``type``: CheckoutCustomerBalanceBankTransferPaymentMethodOptionsType option, ?euBankTransfer: PaymentMethodOptionsCustomerBalanceEuBankAccount, ?requestedAddressTypes: CheckoutCustomerBalanceBankTransferPaymentMethodOptionsRequestedAddressTypes list) =
        {
            Type = ``type``
            EuBankTransfer = euBankTransfer
            RequestedAddressTypes = requestedAddressTypes
        }

type CheckoutCustomerBalancePaymentMethodOptions =
    { BankTransfer: CheckoutCustomerBalanceBankTransferPaymentMethodOptions option }

type CheckoutCustomerBalancePaymentMethodOptions with
    static member New(?bankTransfer: CheckoutCustomerBalanceBankTransferPaymentMethodOptions) =
        {
            BankTransfer = bankTransfer
        }

module CheckoutCustomerBalancePaymentMethodOptions =
    ///The funding method type to be used when there are not enough funds in the customer balance. Permitted values include: `bank_transfer`.
    let fundingType = "bank_transfer"

    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    let setupFutureUsage = "none"

type CheckoutEpsPaymentMethodOptions () = 
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    member _.SetupFutureUsage = "none"


module CheckoutEpsPaymentMethodOptions =
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    let setupFutureUsage = "none"

type CheckoutFpxPaymentMethodOptions () = 
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    member _.SetupFutureUsage = "none"


module CheckoutFpxPaymentMethodOptions =
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    let setupFutureUsage = "none"

type CheckoutGiropayPaymentMethodOptions () = 
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    member _.SetupFutureUsage = "none"


module CheckoutGiropayPaymentMethodOptions =
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    let setupFutureUsage = "none"

type CheckoutGrabPayPaymentMethodOptions () = 
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    member _.SetupFutureUsage = "none"


module CheckoutGrabPayPaymentMethodOptions =
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    let setupFutureUsage = "none"

type CheckoutIdealPaymentMethodOptions () = 
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    member _.SetupFutureUsage = "none"


module CheckoutIdealPaymentMethodOptions =
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    let setupFutureUsage = "none"

[<Struct>]
type CheckoutKakaoPayPaymentMethodOptionsSetupFutureUsage =
    | [<JsonPropertyName("none")>] None'
    | OffSession

type CheckoutKakaoPayPaymentMethodOptions =
    {
        /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
        /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
        SetupFutureUsage: CheckoutKakaoPayPaymentMethodOptionsSetupFutureUsage option
    }

type CheckoutKakaoPayPaymentMethodOptions with
    static member New(?setupFutureUsage: CheckoutKakaoPayPaymentMethodOptionsSetupFutureUsage) =
        {
            SetupFutureUsage = setupFutureUsage
        }

module CheckoutKakaoPayPaymentMethodOptions =
    ///Controls when the funds will be captured from the customer's account.
    let captureMethod = "manual"

[<Struct>]
type CheckoutKlarnaPaymentMethodOptionsSetupFutureUsage =
    | [<JsonPropertyName("none")>] None'
    | OffSession
    | OnSession

type CheckoutKlarnaPaymentMethodOptions =
    {
        /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
        /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
        SetupFutureUsage: CheckoutKlarnaPaymentMethodOptionsSetupFutureUsage option
    }

type CheckoutKlarnaPaymentMethodOptions with
    static member New(?setupFutureUsage: CheckoutKlarnaPaymentMethodOptionsSetupFutureUsage) =
        {
            SetupFutureUsage = setupFutureUsage
        }

module CheckoutKlarnaPaymentMethodOptions =
    ///Controls when the funds will be captured from the customer's account.
    let captureMethod = "manual"

type CheckoutKonbiniPaymentMethodOptions =
    {
        /// The number of calendar days (between 1 and 60) after which Konbini payment instructions will expire. For example, if a PaymentIntent is confirmed with Konbini and `expires_after_days` set to 2 on Monday JST, the instructions will expire on Wednesday 23:59:59 JST.
        ExpiresAfterDays: int option
    }

type CheckoutKonbiniPaymentMethodOptions with
    static member New(expiresAfterDays: int option) =
        {
            ExpiresAfterDays = expiresAfterDays
        }

module CheckoutKonbiniPaymentMethodOptions =
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    let setupFutureUsage = "none"

[<Struct>]
type CheckoutKrCardPaymentMethodOptionsSetupFutureUsage =
    | [<JsonPropertyName("none")>] None'
    | OffSession

type CheckoutKrCardPaymentMethodOptions =
    {
        /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
        /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
        SetupFutureUsage: CheckoutKrCardPaymentMethodOptionsSetupFutureUsage option
    }

type CheckoutKrCardPaymentMethodOptions with
    static member New(?setupFutureUsage: CheckoutKrCardPaymentMethodOptionsSetupFutureUsage) =
        {
            SetupFutureUsage = setupFutureUsage
        }

module CheckoutKrCardPaymentMethodOptions =
    ///Controls when the funds will be captured from the customer's account.
    let captureMethod = "manual"

[<Struct>]
type CheckoutLinkPaymentMethodOptionsSetupFutureUsage =
    | [<JsonPropertyName("none")>] None'
    | OffSession

type CheckoutLinkPaymentMethodOptions =
    {
        /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
        /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
        SetupFutureUsage: CheckoutLinkPaymentMethodOptionsSetupFutureUsage option
    }

type CheckoutLinkPaymentMethodOptions with
    static member New(?setupFutureUsage: CheckoutLinkPaymentMethodOptionsSetupFutureUsage) =
        {
            SetupFutureUsage = setupFutureUsage
        }

module CheckoutLinkPaymentMethodOptions =
    ///Controls when the funds will be captured from the customer's account.
    let captureMethod = "manual"

type CheckoutMobilepayPaymentMethodOptions () = 
    ///Controls when the funds will be captured from the customer's account.
    member _.CaptureMethod = "manual"
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    member _.SetupFutureUsage = "none"


module CheckoutMobilepayPaymentMethodOptions =
    ///Controls when the funds will be captured from the customer's account.
    let captureMethod = "manual"

    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    let setupFutureUsage = "none"

type CheckoutMultibancoPaymentMethodOptions () = 
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    member _.SetupFutureUsage = "none"


module CheckoutMultibancoPaymentMethodOptions =
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    let setupFutureUsage = "none"

[<Struct>]
type CheckoutNaverPayPaymentMethodOptionsSetupFutureUsage =
    | [<JsonPropertyName("none")>] None'
    | OffSession

type CheckoutNaverPayPaymentMethodOptions =
    {
        /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
        /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
        SetupFutureUsage: CheckoutNaverPayPaymentMethodOptionsSetupFutureUsage option
    }

type CheckoutNaverPayPaymentMethodOptions with
    static member New(?setupFutureUsage: CheckoutNaverPayPaymentMethodOptionsSetupFutureUsage) =
        {
            SetupFutureUsage = setupFutureUsage
        }

module CheckoutNaverPayPaymentMethodOptions =
    ///Controls when the funds will be captured from the customer's account.
    let captureMethod = "manual"

type CheckoutOxxoPaymentMethodOptions =
    {
        /// The number of calendar days before an OXXO invoice expires. For example, if you create an OXXO invoice on Monday and you set expires_after_days to 2, the OXXO invoice will expire on Wednesday at 23:59 America/Mexico_City time.
        ExpiresAfterDays: int
    }

type CheckoutOxxoPaymentMethodOptions with
    static member New(expiresAfterDays: int) =
        {
            ExpiresAfterDays = expiresAfterDays
        }

module CheckoutOxxoPaymentMethodOptions =
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    let setupFutureUsage = "none"

type CheckoutP24PaymentMethodOptions () = 
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    member _.SetupFutureUsage = "none"


module CheckoutP24PaymentMethodOptions =
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    let setupFutureUsage = "none"

type CheckoutPaycoPaymentMethodOptions () = 
    ///Controls when the funds will be captured from the customer's account.
    member _.CaptureMethod = "manual"


module CheckoutPaycoPaymentMethodOptions =
    ///Controls when the funds will be captured from the customer's account.
    let captureMethod = "manual"

type CheckoutPaynowPaymentMethodOptions () = 
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    member _.SetupFutureUsage = "none"


module CheckoutPaynowPaymentMethodOptions =
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    let setupFutureUsage = "none"

[<Struct>]
type CheckoutPaypalPaymentMethodOptionsSetupFutureUsage =
    | [<JsonPropertyName("none")>] None'
    | OffSession

type CheckoutPaypalPaymentMethodOptions =
    {
        /// Preferred locale of the PayPal checkout page that the customer is redirected to.
        PreferredLocale: string option
        /// A reference of the PayPal transaction visible to customer which is mapped to PayPal's invoice ID. This must be a globally unique ID if you have configured in your PayPal settings to block multiple payments per invoice ID.
        Reference: string option
        /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
        /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
        SetupFutureUsage: CheckoutPaypalPaymentMethodOptionsSetupFutureUsage option
    }

type CheckoutPaypalPaymentMethodOptions with
    static member New(preferredLocale: string option, reference: string option, ?setupFutureUsage: CheckoutPaypalPaymentMethodOptionsSetupFutureUsage) =
        {
            PreferredLocale = preferredLocale
            Reference = reference
            SetupFutureUsage = setupFutureUsage
        }

module CheckoutPaypalPaymentMethodOptions =
    ///Controls when the funds will be captured from the customer's account.
    let captureMethod = "manual"

[<Struct>]
type CheckoutPaytoPaymentMethodOptionsSetupFutureUsage =
    | [<JsonPropertyName("none")>] None'
    | OffSession

type CheckoutPaytoPaymentMethodOptions =
    {
        MandateOptions: MandateOptionsPayto option
        /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
        /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
        SetupFutureUsage: CheckoutPaytoPaymentMethodOptionsSetupFutureUsage option
    }

type CheckoutPaytoPaymentMethodOptions with
    static member New(?mandateOptions: MandateOptionsPayto, ?setupFutureUsage: CheckoutPaytoPaymentMethodOptionsSetupFutureUsage) =
        {
            MandateOptions = mandateOptions
            SetupFutureUsage = setupFutureUsage
        }

[<Struct>]
type CheckoutPixPaymentMethodOptionsAmountIncludesIof =
    | Always
    | Never

[<Struct>]
type CheckoutPixPaymentMethodOptionsSetupFutureUsage =
    | [<JsonPropertyName("none")>] None'
    | OffSession

type CheckoutPixPaymentMethodOptions =
    {
        /// Determines if the amount includes the IOF tax.
        AmountIncludesIof: CheckoutPixPaymentMethodOptionsAmountIncludesIof option
        /// The number of seconds after which Pix payment will expire.
        ExpiresAfterSeconds: int option
        MandateOptions: PaymentMethodOptionsMandateOptionsPix option
        /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
        /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
        SetupFutureUsage: CheckoutPixPaymentMethodOptionsSetupFutureUsage option
    }

type CheckoutPixPaymentMethodOptions with
    static member New(expiresAfterSeconds: int option, ?amountIncludesIof: CheckoutPixPaymentMethodOptionsAmountIncludesIof, ?mandateOptions: PaymentMethodOptionsMandateOptionsPix, ?setupFutureUsage: CheckoutPixPaymentMethodOptionsSetupFutureUsage) =
        {
            ExpiresAfterSeconds = expiresAfterSeconds
            AmountIncludesIof = amountIncludesIof
            MandateOptions = mandateOptions
            SetupFutureUsage = setupFutureUsage
        }

[<Struct>]
type CheckoutRevolutPayPaymentMethodOptionsSetupFutureUsage =
    | [<JsonPropertyName("none")>] None'
    | OffSession

type CheckoutRevolutPayPaymentMethodOptions =
    {
        /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
        /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
        SetupFutureUsage: CheckoutRevolutPayPaymentMethodOptionsSetupFutureUsage option
    }

type CheckoutRevolutPayPaymentMethodOptions with
    static member New(?setupFutureUsage: CheckoutRevolutPayPaymentMethodOptionsSetupFutureUsage) =
        {
            SetupFutureUsage = setupFutureUsage
        }

module CheckoutRevolutPayPaymentMethodOptions =
    ///Controls when the funds will be captured from the customer's account.
    let captureMethod = "manual"

type CheckoutSamsungPayPaymentMethodOptions () = 
    ///Controls when the funds will be captured from the customer's account.
    member _.CaptureMethod = "manual"


module CheckoutSamsungPayPaymentMethodOptions =
    ///Controls when the funds will be captured from the customer's account.
    let captureMethod = "manual"

type CheckoutSatispayPaymentMethodOptions () = 
    ///Controls when the funds will be captured from the customer's account.
    member _.CaptureMethod = "manual"


module CheckoutSatispayPaymentMethodOptions =
    ///Controls when the funds will be captured from the customer's account.
    let captureMethod = "manual"

type CheckoutPaymentMethodOptionsMandateOptionsSepaDebit =
    {
        /// Prefix used to generate the Mandate reference. Must be at most 12 characters long. Must consist of only uppercase letters, numbers, spaces, or the following special characters: '/', '_', '-', '&', '.'. Cannot begin with 'STRIPE'.
        ReferencePrefix: string option
    }

type CheckoutPaymentMethodOptionsMandateOptionsSepaDebit with
    static member New(?referencePrefix: string) =
        {
            ReferencePrefix = referencePrefix
        }

[<Struct>]
type CheckoutSepaDebitPaymentMethodOptionsSetupFutureUsage =
    | [<JsonPropertyName("none")>] None'
    | OffSession
    | OnSession

type CheckoutSepaDebitPaymentMethodOptions =
    {
        MandateOptions: CheckoutPaymentMethodOptionsMandateOptionsSepaDebit option
        /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
        /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
        SetupFutureUsage: CheckoutSepaDebitPaymentMethodOptionsSetupFutureUsage option
        /// Controls when Stripe will attempt to debit the funds from the customer's account. The date must be a string in YYYY-MM-DD format. The date must be in the future and between 3 and 15 calendar days from now.
        TargetDate: string option
    }

type CheckoutSepaDebitPaymentMethodOptions with
    static member New(?mandateOptions: CheckoutPaymentMethodOptionsMandateOptionsSepaDebit, ?setupFutureUsage: CheckoutSepaDebitPaymentMethodOptionsSetupFutureUsage, ?targetDate: string) =
        {
            MandateOptions = mandateOptions
            SetupFutureUsage = setupFutureUsage
            TargetDate = targetDate
        }

type CheckoutSofortPaymentMethodOptions () = 
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    member _.SetupFutureUsage = "none"


module CheckoutSofortPaymentMethodOptions =
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    let setupFutureUsage = "none"

type CheckoutSwishPaymentMethodOptions =
    {
        /// The order reference that will be displayed to customers in the Swish application. Defaults to the `id` of the Payment Intent.
        Reference: string option
    }

type CheckoutSwishPaymentMethodOptions with
    static member New(reference: string option) =
        {
            Reference = reference
        }

type CheckoutTwintPaymentMethodOptions () = 
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    member _.SetupFutureUsage = "none"


module CheckoutTwintPaymentMethodOptions =
    ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
    ///If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
    ///When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
    let setupFutureUsage = "none"

[<Struct>]
type CheckoutUpiPaymentMethodOptionsSetupFutureUsage =
    | [<JsonPropertyName("none")>] None'
    | OffSession
    | OnSession

type CheckoutUpiPaymentMethodOptions =
    {
        MandateOptions: MandateOptionsUpi option
        /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
        /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
        SetupFutureUsage: CheckoutUpiPaymentMethodOptionsSetupFutureUsage option
    }

type CheckoutUpiPaymentMethodOptions with
    static member New(?mandateOptions: MandateOptionsUpi, ?setupFutureUsage: CheckoutUpiPaymentMethodOptionsSetupFutureUsage) =
        {
            MandateOptions = mandateOptions
            SetupFutureUsage = setupFutureUsage
        }

[<Struct>]
type CheckoutUsBankAccountPaymentMethodOptionsSetupFutureUsage =
    | [<JsonPropertyName("none")>] None'
    | OffSession
    | OnSession

[<Struct>]
type CheckoutUsBankAccountPaymentMethodOptionsVerificationMethod =
    | Automatic
    | Instant

type CheckoutUsBankAccountPaymentMethodOptions =
    {
        FinancialConnections: LinkedAccountOptionsCommon option
        /// Indicates that you intend to make future payments with this PaymentIntent's payment method.
        /// If you provide a Customer with the PaymentIntent, you can use this parameter to [attach the payment method](/payments/save-during-payment) to the Customer after the PaymentIntent is confirmed and the customer completes any required actions. If you don't provide a Customer, you can still [attach](/api/payment_methods/attach) the payment method to a Customer after the transaction completes.
        /// If the payment method is `card_present` and isn't a digital wallet, Stripe creates and attaches a [generated_card](/api/charges/object#charge_object-payment_method_details-card_present-generated_card) payment method representing the card to the Customer instead.
        /// When processing card payments, Stripe uses `setup_future_usage` to help you comply with regional legislation and network rules, such as [SCA](/strong-customer-authentication).
        SetupFutureUsage: CheckoutUsBankAccountPaymentMethodOptionsSetupFutureUsage option
        /// Controls when Stripe will attempt to debit the funds from the customer's account. The date must be a string in YYYY-MM-DD format. The date must be in the future and between 3 and 15 calendar days from now.
        TargetDate: string option
        /// Bank account verification method. The default value is `automatic`.
        VerificationMethod: CheckoutUsBankAccountPaymentMethodOptionsVerificationMethod option
    }

type CheckoutUsBankAccountPaymentMethodOptions with
    static member New(?financialConnections: LinkedAccountOptionsCommon, ?setupFutureUsage: CheckoutUsBankAccountPaymentMethodOptionsSetupFutureUsage, ?targetDate: string, ?verificationMethod: CheckoutUsBankAccountPaymentMethodOptionsVerificationMethod) =
        {
            FinancialConnections = financialConnections
            SetupFutureUsage = setupFutureUsage
            TargetDate = targetDate
            VerificationMethod = verificationMethod
        }

type CheckoutSessionPaymentMethodOptions =
    { AcssDebit: CheckoutAcssDebitPaymentMethodOptions option
      Affirm: CheckoutAffirmPaymentMethodOptions option
      AfterpayClearpay: CheckoutAfterpayClearpayPaymentMethodOptions option
      Alipay: CheckoutAlipayPaymentMethodOptions option
      Alma: CheckoutAlmaPaymentMethodOptions option
      AmazonPay: CheckoutAmazonPayPaymentMethodOptions option
      AuBecsDebit: CheckoutAuBecsDebitPaymentMethodOptions option
      BacsDebit: CheckoutBacsDebitPaymentMethodOptions option
      Bancontact: CheckoutBancontactPaymentMethodOptions option
      Billie: CheckoutBilliePaymentMethodOptions option
      Boleto: CheckoutBoletoPaymentMethodOptions option
      Card: CheckoutCardPaymentMethodOptions option
      Cashapp: CheckoutCashappPaymentMethodOptions option
      CustomerBalance: CheckoutCustomerBalancePaymentMethodOptions option
      Eps: CheckoutEpsPaymentMethodOptions option
      Fpx: CheckoutFpxPaymentMethodOptions option
      Giropay: CheckoutGiropayPaymentMethodOptions option
      Grabpay: CheckoutGrabPayPaymentMethodOptions option
      Ideal: CheckoutIdealPaymentMethodOptions option
      KakaoPay: CheckoutKakaoPayPaymentMethodOptions option
      Klarna: CheckoutKlarnaPaymentMethodOptions option
      Konbini: CheckoutKonbiniPaymentMethodOptions option
      KrCard: CheckoutKrCardPaymentMethodOptions option
      Link: CheckoutLinkPaymentMethodOptions option
      Mobilepay: CheckoutMobilepayPaymentMethodOptions option
      Multibanco: CheckoutMultibancoPaymentMethodOptions option
      NaverPay: CheckoutNaverPayPaymentMethodOptions option
      Oxxo: CheckoutOxxoPaymentMethodOptions option
      [<JsonPropertyName("p24")>]
      P24: CheckoutP24PaymentMethodOptions option
      Payco: CheckoutPaycoPaymentMethodOptions option
      Paynow: CheckoutPaynowPaymentMethodOptions option
      Paypal: CheckoutPaypalPaymentMethodOptions option
      Payto: CheckoutPaytoPaymentMethodOptions option
      Pix: CheckoutPixPaymentMethodOptions option
      RevolutPay: CheckoutRevolutPayPaymentMethodOptions option
      SamsungPay: CheckoutSamsungPayPaymentMethodOptions option
      Satispay: CheckoutSatispayPaymentMethodOptions option
      SepaDebit: CheckoutSepaDebitPaymentMethodOptions option
      Sofort: CheckoutSofortPaymentMethodOptions option
      Swish: CheckoutSwishPaymentMethodOptions option
      Twint: CheckoutTwintPaymentMethodOptions option
      Upi: CheckoutUpiPaymentMethodOptions option
      UsBankAccount: CheckoutUsBankAccountPaymentMethodOptions option }

type CheckoutSessionPaymentMethodOptions with
    static member New(?acssDebit: CheckoutAcssDebitPaymentMethodOptions, ?affirm: CheckoutAffirmPaymentMethodOptions, ?afterpayClearpay: CheckoutAfterpayClearpayPaymentMethodOptions, ?alipay: CheckoutAlipayPaymentMethodOptions, ?alma: CheckoutAlmaPaymentMethodOptions, ?amazonPay: CheckoutAmazonPayPaymentMethodOptions, ?auBecsDebit: CheckoutAuBecsDebitPaymentMethodOptions, ?bacsDebit: CheckoutBacsDebitPaymentMethodOptions, ?bancontact: CheckoutBancontactPaymentMethodOptions, ?billie: CheckoutBilliePaymentMethodOptions, ?boleto: CheckoutBoletoPaymentMethodOptions, ?card: CheckoutCardPaymentMethodOptions, ?cashapp: CheckoutCashappPaymentMethodOptions, ?customerBalance: CheckoutCustomerBalancePaymentMethodOptions, ?eps: CheckoutEpsPaymentMethodOptions, ?fpx: CheckoutFpxPaymentMethodOptions, ?giropay: CheckoutGiropayPaymentMethodOptions, ?grabpay: CheckoutGrabPayPaymentMethodOptions, ?ideal: CheckoutIdealPaymentMethodOptions, ?kakaoPay: CheckoutKakaoPayPaymentMethodOptions, ?klarna: CheckoutKlarnaPaymentMethodOptions, ?konbini: CheckoutKonbiniPaymentMethodOptions, ?krCard: CheckoutKrCardPaymentMethodOptions, ?link: CheckoutLinkPaymentMethodOptions, ?mobilepay: CheckoutMobilepayPaymentMethodOptions, ?multibanco: CheckoutMultibancoPaymentMethodOptions, ?naverPay: CheckoutNaverPayPaymentMethodOptions, ?oxxo: CheckoutOxxoPaymentMethodOptions, ?p24: CheckoutP24PaymentMethodOptions, ?payco: CheckoutPaycoPaymentMethodOptions, ?paynow: CheckoutPaynowPaymentMethodOptions, ?paypal: CheckoutPaypalPaymentMethodOptions, ?payto: CheckoutPaytoPaymentMethodOptions, ?pix: CheckoutPixPaymentMethodOptions, ?revolutPay: CheckoutRevolutPayPaymentMethodOptions, ?samsungPay: CheckoutSamsungPayPaymentMethodOptions, ?satispay: CheckoutSatispayPaymentMethodOptions, ?sepaDebit: CheckoutSepaDebitPaymentMethodOptions, ?sofort: CheckoutSofortPaymentMethodOptions, ?swish: CheckoutSwishPaymentMethodOptions, ?twint: CheckoutTwintPaymentMethodOptions, ?upi: CheckoutUpiPaymentMethodOptions, ?usBankAccount: CheckoutUsBankAccountPaymentMethodOptions) =
        {
            AcssDebit = acssDebit
            Affirm = affirm
            AfterpayClearpay = afterpayClearpay
            Alipay = alipay
            Alma = alma
            AmazonPay = amazonPay
            AuBecsDebit = auBecsDebit
            BacsDebit = bacsDebit
            Bancontact = bancontact
            Billie = billie
            Boleto = boleto
            Card = card
            Cashapp = cashapp
            CustomerBalance = customerBalance
            Eps = eps
            Fpx = fpx
            Giropay = giropay
            Grabpay = grabpay
            Ideal = ideal
            KakaoPay = kakaoPay
            Klarna = klarna
            Konbini = konbini
            KrCard = krCard
            Link = link
            Mobilepay = mobilepay
            Multibanco = multibanco
            NaverPay = naverPay
            Oxxo = oxxo
            P24 = p24
            Payco = payco
            Paynow = paynow
            Paypal = paypal
            Payto = payto
            Pix = pix
            RevolutPay = revolutPay
            SamsungPay = samsungPay
            Satispay = satispay
            SepaDebit = sepaDebit
            Sofort = sofort
            Swish = swish
            Twint = twint
            Upi = upi
            UsBankAccount = usBankAccount
        }

[<Struct>]
type CheckoutSessionPaymentStatus =
    | NoPaymentRequired
    | Paid
    | Unpaid

[<Struct>]
type CheckoutSessionRedirectOnCompletion =
    | Always
    | IfRequired
    | Never

[<Struct>]
type CheckoutSessionStatus =
    | Complete
    | Expired
    | Open

[<Struct>]
type CheckoutSessionSubmitType =
    | Auto
    | Book
    | Donate
    | Pay
    | Subscribe

[<Struct>]
type CheckoutSessionUiMode =
    | Elements
    | EmbeddedPage
    | Form
    | HostedPage

[<Struct>]
type CheckoutLinkWalletOptionsDisplay =
    | Auto
    | Never

type CheckoutLinkWalletOptions =
    {
        /// Describes whether Checkout should display Link. Defaults to `auto`.
        Display: CheckoutLinkWalletOptionsDisplay option
    }

type CheckoutLinkWalletOptions with
    static member New(?display: CheckoutLinkWalletOptionsDisplay) =
        {
            Display = display
        }

type CheckoutSessionWalletOptions =
    { Link: CheckoutLinkWalletOptions option }

type CheckoutSessionWalletOptions with
    static member New(?link: CheckoutLinkWalletOptions) =
        {
            Link = link
        }

/// A Checkout Session represents your customer's session as they pay for
/// one-time purchases or subscriptions through [Checkout](https://docs.stripe.com/payments/checkout)
/// or [Payment Links](https://docs.stripe.com/payments/payment-links). We recommend creating a
/// new Session each time your customer attempts to pay.
/// Once payment is successful, the Checkout Session will contain a reference
/// to the [Customer](https://docs.stripe.com/api/customers), and either the successful
/// [PaymentIntent](https://docs.stripe.com/api/payment_intents) or an active
/// [Subscription](https://docs.stripe.com/api/subscriptions).
/// You can create a Checkout Session on your server and redirect to its URL
/// to begin Checkout.
/// Related guide: [Checkout quickstart](https://docs.stripe.com/checkout/quickstart)
type CheckoutSession =
    {
        /// Settings for price localization with [Adaptive Pricing](https://docs.stripe.com/payments/checkout/adaptive-pricing).
        AdaptivePricing: PaymentPagesCheckoutSessionAdaptivePricing option
        /// When set, provides configuration for actions to take if this Checkout Session expires.
        AfterExpiration: PaymentPagesCheckoutSessionAfterExpiration option
        /// Enables user redeemable promotion codes.
        AllowPromotionCodes: bool option
        /// Total of all items before discounts or taxes are applied.
        AmountSubtotal: int option
        /// Total of all items after discounts and taxes are applied.
        AmountTotal: int option
        AutomaticTax: PaymentPagesCheckoutSessionAutomaticTax
        /// Describes whether Checkout should collect the customer's billing address. Defaults to `auto`.
        BillingAddressCollection: CheckoutSessionBillingAddressCollection option
        BrandingSettings: PaymentPagesCheckoutSessionBrandingSettings option
        /// If set, Checkout displays a back button and customers will be directed to this URL if they decide to cancel payment and return to your website.
        CancelUrl: string option
        /// A unique string to reference the Checkout Session. This can be a
        /// customer ID, a cart ID, or similar, and can be used to reconcile the
        /// Session with your internal systems.
        ClientReferenceId: string option
        /// The client secret of your Checkout Session. Applies to Checkout Sessions with `ui_mode: embedded` or `ui_mode: custom`. For `ui_mode: embedded`, the client secret is to be used when initializing Stripe.js embedded checkout.
        ///  For `ui_mode: custom`, use the client secret with [initCheckout](https://docs.stripe.com/js/custom_checkout/init) on your front end.
        ClientSecret: string option
        /// Information about the customer collected within the Checkout Session.
        CollectedInformation: PaymentPagesCheckoutSessionCollectedInformation option
        /// Results of `consent_collection` for this session.
        Consent: PaymentPagesCheckoutSessionConsent option
        /// When set, provides configuration for the Checkout Session to gather active consent from customers.
        ConsentCollection: PaymentPagesCheckoutSessionConsentCollection option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode option
        /// Currency conversion details for [Adaptive Pricing](https://docs.stripe.com/payments/checkout/adaptive-pricing) sessions created before 2025-03-31.
        CurrencyConversion: PaymentPagesCheckoutSessionCurrencyConversion option
        /// Collect additional information from your customer using custom fields. Up to 3 fields are supported. You can't set this parameter if `ui_mode` is `custom`.
        CustomFields: PaymentPagesCheckoutSessionCustomFields list
        CustomText: PaymentPagesCheckoutSessionCustomText
        /// The ID of the customer for this Session.
        /// For Checkout Sessions in `subscription` mode or Checkout Sessions with `customer_creation` set as `always` in `payment` mode, Checkout
        /// will create a new customer object based on information provided
        /// during the payment flow unless an existing customer was provided when
        /// the Session was created.
        Customer: CheckoutSessionCustomer'AnyOf option
        /// The ID of the account for this Session.
        CustomerAccount: string option
        /// Configure whether a Checkout Session creates a Customer when the Checkout Session completes.
        CustomerCreation: CheckoutSessionCustomerCreation option
        /// The customer details including the customer's tax exempt status and the customer's tax IDs. Customer's address details are not present on Sessions in `setup` mode.
        CustomerDetails: PaymentPagesCheckoutSessionCustomerDetails option
        /// If provided, this value will be used when the Customer object is created.
        /// If not provided, customers will be asked to enter their email address.
        /// Use this parameter to prefill customer data if you already have an email
        /// on file. To access information about the customer once the payment flow is
        /// complete, use the `customer` attribute.
        CustomerEmail: string option
        /// List of coupons and promotion codes attached to the Checkout Session.
        Discounts: PaymentPagesCheckoutSessionDiscount list option
        /// A list of the types of payment methods (e.g., `card`) that should be excluded from this Checkout Session. This should only be used when payment methods for this Checkout Session are managed through the [Stripe Dashboard](https://dashboard.stripe.com/settings/payment_methods).
        ExcludedPaymentMethodTypes: string list option
        /// The timestamp at which the Checkout Session will expire.
        ExpiresAt: DateTime
        /// Unique identifier for the object.
        Id: string
        /// The integration identifier for this Checkout Session. Multiple Checkout Sessions can have the same integration identifier.
        IntegrationIdentifier: string option
        /// ID of the invoice created by the Checkout Session, if it exists.
        Invoice: StripeId<Markers.Invoice> option
        /// Details on the state of invoice creation for the Checkout Session.
        InvoiceCreation: PaymentPagesCheckoutSessionInvoiceCreation option
        /// The line items purchased by the customer.
        LineItems: CheckoutSessionLineItems option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// The IETF language tag of the locale Checkout is displayed in. If blank or `auto`, the browser's locale is used.
        Locale: CheckoutSessionLocale option
        /// Settings for Managed Payments for this Checkout Session and resulting [PaymentIntents](/api/payment_intents/object), [Invoices](/api/invoices/object), and [Subscriptions](/api/subscriptions/object).
        ManagedPayments: PaymentPagesCheckoutSessionManagedPayments option
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        /// The mode of the Checkout Session.
        Mode: CheckoutSessionMode
        NameCollection: PaymentPagesCheckoutSessionNameCollection option
        /// The optional items presented to the customer at checkout.
        OptionalItems: PaymentPagesCheckoutSessionOptionalItem list option
        /// Where the user is coming from. This informs the optimizations that are applied to the session.
        OriginContext: CheckoutSessionOriginContext option
        /// The ID of the PaymentIntent for Checkout Sessions in `payment` mode. You can't confirm or cancel the PaymentIntent for a Checkout Session. To cancel, [expire the Checkout Session](https://docs.stripe.com/api/checkout/sessions/expire) instead.
        PaymentIntent: StripeId<Markers.PaymentIntent> option
        /// The ID of the Payment Link that created this Session.
        PaymentLink: StripeId<Markers.PaymentLink> option
        /// Configure whether a Checkout Session should collect a payment method. Defaults to `always`.
        PaymentMethodCollection: CheckoutSessionPaymentMethodCollection option
        /// Information about the payment method configuration used for this Checkout session if using dynamic payment methods.
        PaymentMethodConfigurationDetails: PaymentMethodConfigBizPaymentMethodConfigurationDetails option
        /// Payment-method-specific configuration for the PaymentIntent or SetupIntent of this CheckoutSession.
        PaymentMethodOptions: CheckoutSessionPaymentMethodOptions option
        /// A list of the types of payment methods (e.g. card) this Checkout
        /// Session is allowed to accept.
        PaymentMethodTypes: string list
        /// The payment status of the Checkout Session, one of `paid`, `unpaid`, or `no_payment_required`.
        /// You can use this value to decide when to fulfill your customer's order.
        PaymentStatus: CheckoutSessionPaymentStatus
        /// This property is used to set up permissions for various actions (e.g., update) on the CheckoutSession object.
        /// For specific permissions, please refer to their dedicated subsections, such as `permissions.update_shipping_details`.
        Permissions: PaymentPagesCheckoutSessionPermissions option
        PhoneNumberCollection: PaymentPagesCheckoutSessionPhoneNumberCollection option
        PresentmentDetails: PaymentFlowsPaymentIntentPresentmentDetails option
        /// The ID of the original expired Checkout Session that triggered the recovery flow.
        RecoveredFrom: string option
        /// This parameter applies to `ui_mode: embedded`. Learn more about the [redirect behavior](https://docs.stripe.com/payments/checkout/custom-success-page?payment-ui=embedded-form) of embedded sessions. Defaults to `always`.
        RedirectOnCompletion: CheckoutSessionRedirectOnCompletion option
        /// Applies to Checkout Sessions with `ui_mode: embedded` or `ui_mode: custom`. The URL to redirect your customer back to after they authenticate or cancel their payment on the payment method's app or site.
        ReturnUrl: string option
        /// Controls saved payment method settings for the session. Only available in `payment` and `subscription` mode.
        SavedPaymentMethodOptions: PaymentPagesCheckoutSessionSavedPaymentMethodOptions option
        /// The ID of the SetupIntent for Checkout Sessions in `setup` mode. You can't confirm or cancel the SetupIntent for a Checkout Session. To cancel, [expire the Checkout Session](https://docs.stripe.com/api/checkout/sessions/expire) instead.
        SetupIntent: StripeId<Markers.SetupIntent> option
        /// When set, provides configuration for Checkout to collect a shipping address from a customer.
        ShippingAddressCollection: PaymentPagesCheckoutSessionShippingAddressCollection option
        /// The details of the customer cost of shipping, including the customer chosen ShippingRate.
        ShippingCost: PaymentPagesCheckoutSessionShippingCost option
        /// The shipping rate options applied to this Session.
        ShippingOptions: PaymentPagesCheckoutSessionShippingOption list
        /// The status of the Checkout Session, one of `open`, `complete`, or `expired`.
        Status: CheckoutSessionStatus option
        /// Describes the type of transaction being performed by Checkout in order to customize
        /// relevant text on the page, such as the submit button. `submit_type` can only be
        /// specified on Checkout Sessions in `payment` mode. If blank or `auto`, `pay` is used.
        SubmitType: CheckoutSessionSubmitType option
        /// The ID of the [Subscription](https://docs.stripe.com/api/subscriptions) for Checkout Sessions in `subscription` mode.
        Subscription: StripeId<Markers.Subscription> option
        /// The URL the customer will be directed to after the payment or
        /// subscription creation is successful.
        SuccessUrl: string option
        TaxIdCollection: PaymentPagesCheckoutSessionTaxIdCollection option
        /// Tax and discount details for the computed total amount.
        TotalDetails: PaymentPagesCheckoutSessionTotalDetails option
        /// The UI mode of the Session. Defaults to `hosted_page`.
        UiMode: CheckoutSessionUiMode option
        /// The URL to the Checkout Session. Applies to Checkout Sessions with `ui_mode: hosted`. Redirect customers to this URL to take them to Checkout. If you’re using [Custom Domains](https://docs.stripe.com/payments/checkout/custom-domains), the URL will use your subdomain. Otherwise, it’ll use `checkout.stripe.com.`
        /// This value is only present when the session is active.
        Url: string option
        /// Wallet-specific configuration for this Checkout Session.
        WalletOptions: CheckoutSessionWalletOptions option
    }

type CheckoutSession with
    static member New(adaptivePricing: PaymentPagesCheckoutSessionAdaptivePricing option, afterExpiration: PaymentPagesCheckoutSessionAfterExpiration option, allowPromotionCodes: bool option, amountSubtotal: int option, amountTotal: int option, automaticTax: PaymentPagesCheckoutSessionAutomaticTax, billingAddressCollection: CheckoutSessionBillingAddressCollection option, cancelUrl: string option, clientReferenceId: string option, clientSecret: string option, collectedInformation: PaymentPagesCheckoutSessionCollectedInformation option, consent: PaymentPagesCheckoutSessionConsent option, consentCollection: PaymentPagesCheckoutSessionConsentCollection option, created: DateTime, currency: IsoTypes.IsoCurrencyCode option, currencyConversion: PaymentPagesCheckoutSessionCurrencyConversion option, customFields: PaymentPagesCheckoutSessionCustomFields list, customText: PaymentPagesCheckoutSessionCustomText, customer: CheckoutSessionCustomer'AnyOf option, customerAccount: string option, customerCreation: CheckoutSessionCustomerCreation option, customerDetails: PaymentPagesCheckoutSessionCustomerDetails option, customerEmail: string option, discounts: PaymentPagesCheckoutSessionDiscount list option, expiresAt: DateTime, id: string, integrationIdentifier: string option, invoice: StripeId<Markers.Invoice> option, invoiceCreation: PaymentPagesCheckoutSessionInvoiceCreation option, livemode: bool, locale: CheckoutSessionLocale option, managedPayments: PaymentPagesCheckoutSessionManagedPayments option, metadata: Map<string, string> option, mode: CheckoutSessionMode, originContext: CheckoutSessionOriginContext option, paymentIntent: StripeId<Markers.PaymentIntent> option, paymentLink: StripeId<Markers.PaymentLink> option, paymentMethodCollection: CheckoutSessionPaymentMethodCollection option, paymentMethodConfigurationDetails: PaymentMethodConfigBizPaymentMethodConfigurationDetails option, paymentMethodOptions: CheckoutSessionPaymentMethodOptions option, paymentMethodTypes: string list, paymentStatus: CheckoutSessionPaymentStatus, permissions: PaymentPagesCheckoutSessionPermissions option, recoveredFrom: string option, savedPaymentMethodOptions: PaymentPagesCheckoutSessionSavedPaymentMethodOptions option, setupIntent: StripeId<Markers.SetupIntent> option, shippingAddressCollection: PaymentPagesCheckoutSessionShippingAddressCollection option, shippingCost: PaymentPagesCheckoutSessionShippingCost option, shippingOptions: PaymentPagesCheckoutSessionShippingOption list, status: CheckoutSessionStatus option, submitType: CheckoutSessionSubmitType option, subscription: StripeId<Markers.Subscription> option, successUrl: string option, totalDetails: PaymentPagesCheckoutSessionTotalDetails option, uiMode: CheckoutSessionUiMode option, url: string option, walletOptions: CheckoutSessionWalletOptions option, ?brandingSettings: PaymentPagesCheckoutSessionBrandingSettings, ?excludedPaymentMethodTypes: string list, ?lineItems: CheckoutSessionLineItems, ?nameCollection: PaymentPagesCheckoutSessionNameCollection, ?optionalItems: PaymentPagesCheckoutSessionOptionalItem list option, ?phoneNumberCollection: PaymentPagesCheckoutSessionPhoneNumberCollection, ?presentmentDetails: PaymentFlowsPaymentIntentPresentmentDetails, ?redirectOnCompletion: CheckoutSessionRedirectOnCompletion, ?returnUrl: string, ?taxIdCollection: PaymentPagesCheckoutSessionTaxIdCollection) =
        {
            AdaptivePricing = adaptivePricing
            AfterExpiration = afterExpiration
            AllowPromotionCodes = allowPromotionCodes
            AmountSubtotal = amountSubtotal
            AmountTotal = amountTotal
            AutomaticTax = automaticTax
            BillingAddressCollection = billingAddressCollection
            CancelUrl = cancelUrl
            ClientReferenceId = clientReferenceId
            ClientSecret = clientSecret
            CollectedInformation = collectedInformation
            Consent = consent
            ConsentCollection = consentCollection
            Created = created
            Currency = currency
            CurrencyConversion = currencyConversion
            CustomFields = customFields
            CustomText = customText
            Customer = customer
            CustomerAccount = customerAccount
            CustomerCreation = customerCreation
            CustomerDetails = customerDetails
            CustomerEmail = customerEmail
            Discounts = discounts
            ExpiresAt = expiresAt
            Id = id
            IntegrationIdentifier = integrationIdentifier
            Invoice = invoice
            InvoiceCreation = invoiceCreation
            Livemode = livemode
            Locale = locale
            ManagedPayments = managedPayments
            Metadata = metadata
            Mode = mode
            OriginContext = originContext
            PaymentIntent = paymentIntent
            PaymentLink = paymentLink
            PaymentMethodCollection = paymentMethodCollection
            PaymentMethodConfigurationDetails = paymentMethodConfigurationDetails
            PaymentMethodOptions = paymentMethodOptions
            PaymentMethodTypes = paymentMethodTypes
            PaymentStatus = paymentStatus
            Permissions = permissions
            RecoveredFrom = recoveredFrom
            SavedPaymentMethodOptions = savedPaymentMethodOptions
            SetupIntent = setupIntent
            ShippingAddressCollection = shippingAddressCollection
            ShippingCost = shippingCost
            ShippingOptions = shippingOptions
            Status = status
            SubmitType = submitType
            Subscription = subscription
            SuccessUrl = successUrl
            TotalDetails = totalDetails
            UiMode = uiMode
            Url = url
            WalletOptions = walletOptions
            BrandingSettings = brandingSettings
            ExcludedPaymentMethodTypes = excludedPaymentMethodTypes
            LineItems = lineItems
            NameCollection = nameCollection
            OptionalItems = optionalItems |> Option.flatten
            PhoneNumberCollection = phoneNumberCollection
            PresentmentDetails = presentmentDetails
            RedirectOnCompletion = redirectOnCompletion
            ReturnUrl = returnUrl
            TaxIdCollection = taxIdCollection
        }

module CheckoutSession =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "checkout.session"

/// Occurs when a Checkout Session is expired.
type CheckoutSessionExpired = { Object: CheckoutSession }

type CheckoutSessionExpired with
    static member New(object: CheckoutSession) =
        {
            Object = object
        }

/// Occurs when a Checkout Session has been successfully completed.
type CheckoutSessionCompleted = { Object: CheckoutSession }

type CheckoutSessionCompleted with
    static member New(object: CheckoutSession) =
        {
            Object = object
        }

/// Occurs when a payment intent using a delayed payment method finally succeeds.
type CheckoutSessionAsyncPaymentSucceeded = { Object: CheckoutSession }

type CheckoutSessionAsyncPaymentSucceeded with
    static member New(object: CheckoutSession) =
        {
            Object = object
        }

/// Occurs when a payment intent using a delayed payment method fails.
type CheckoutSessionAsyncPaymentFailed = { Object: CheckoutSession }

type CheckoutSessionAsyncPaymentFailed with
    static member New(object: CheckoutSession) =
        {
            Object = object
        }

