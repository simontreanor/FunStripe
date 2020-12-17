namespace FunStripe

open FSharp.Json

module StripeModel =

    ///This is an object representing a Stripe account. You can retrieve it to see
    ///properties on the account like its current e-mail address or if the account is
    ///enabled yet to make live charges.
    ///
    ///Some properties, marked below, are available only to platforms that want to
    ///[create and manage Express or Custom accounts](https://stripe.com/docs/connect/accounts).
    type Account =
        {
            BusinessProfile: AccountBusinessProfile option
            BusinessType: AccountBusinessType option
            Capabilities: AccountCapabilities option
            ChargesEnabled: bool option
            Company: LegalEntityCompany option
            Country: string option
            Created: int64 option
            DefaultCurrency: string option
            DetailsSubmitted: bool option
            Email: string option
            ExternalAccounts: Map<string, string>
            Id: string
            Individual: Person option
            Metadata: Map<string, string>
            PayoutsEnabled: bool option
            Requirements: AccountRequirements option
            Settings: AccountSettings option
            TosAcceptance: AccountTosAcceptance option
            Type: AccountType option
        }
        member _.Object = "account"

    and AccountBusinessType =
        | Company
        | GovernmentEntity
        | Individual
        | NonProfit

    and AccountType =
        | Custom
        | Express
        | Standard

    ///
    and AccountBacsDebitPaymentsSettings =
        {
            DisplayName: string option
        }

    ///
    and AccountBrandingSettings =
        {
            Icon: string option
            Logo: string option
            PrimaryColor: string option
            SecondaryColor: string option
        }

    ///
    and AccountBusinessProfile =
        {
            Mcc: string option
            Name: string option
            ProductDescription: string option
            SupportAddress: Address option
            SupportEmail: string option
            SupportPhone: string option
            SupportUrl: string option
            Url: string option
        }

    ///
    and AccountCapabilities =
        {
            AuBecsDebitPayments: AccountCapabilitiesAuBecsDebitPayments option
            BacsDebitPayments: AccountCapabilitiesBacsDebitPayments option
            BancontactPayments: AccountCapabilitiesBancontactPayments option
            CardIssuing: AccountCapabilitiesCardIssuing option
            CardPayments: AccountCapabilitiesCardPayments option
            CartesBancairesPayments: AccountCapabilitiesCartesBancairesPayments option
            EpsPayments: AccountCapabilitiesEpsPayments option
            FpxPayments: AccountCapabilitiesFpxPayments option
            GiropayPayments: AccountCapabilitiesGiropayPayments option
            GrabpayPayments: AccountCapabilitiesGrabpayPayments option
            IdealPayments: AccountCapabilitiesIdealPayments option
            JcbPayments: AccountCapabilitiesJcbPayments option
            LegacyPayments: AccountCapabilitiesLegacyPayments option
            OxxoPayments: AccountCapabilitiesOxxoPayments option
            [<JsonField("p24_payments")>]P24Payments: AccountCapabilitiesP24Payments option
            SepaDebitPayments: AccountCapabilitiesSepaDebitPayments option
            SofortPayments: AccountCapabilitiesSofortPayments option
            [<JsonField("tax_reporting_us_1099_k")>]TaxReportingUs1099K: AccountCapabilitiesTaxReportingUs1099K option
            [<JsonField("tax_reporting_us_1099_misc")>]TaxReportingUs1099Misc: AccountCapabilitiesTaxReportingUs1099Misc option
            Transfers: AccountCapabilitiesTransfers option
        }

    and AccountCapabilitiesAuBecsDebitPayments =
        | Active
        | Inactive
        | Pending

    and AccountCapabilitiesBacsDebitPayments =
        | Active
        | Inactive
        | Pending

    and AccountCapabilitiesBancontactPayments =
        | Active
        | Inactive
        | Pending

    and AccountCapabilitiesCardIssuing =
        | Active
        | Inactive
        | Pending

    and AccountCapabilitiesCardPayments =
        | Active
        | Inactive
        | Pending

    and AccountCapabilitiesCartesBancairesPayments =
        | Active
        | Inactive
        | Pending

    and AccountCapabilitiesEpsPayments =
        | Active
        | Inactive
        | Pending

    and AccountCapabilitiesFpxPayments =
        | Active
        | Inactive
        | Pending

    and AccountCapabilitiesGiropayPayments =
        | Active
        | Inactive
        | Pending

    and AccountCapabilitiesGrabpayPayments =
        | Active
        | Inactive
        | Pending

    and AccountCapabilitiesIdealPayments =
        | Active
        | Inactive
        | Pending

    and AccountCapabilitiesJcbPayments =
        | Active
        | Inactive
        | Pending

    and AccountCapabilitiesLegacyPayments =
        | Active
        | Inactive
        | Pending

    and AccountCapabilitiesOxxoPayments =
        | Active
        | Inactive
        | Pending

    and AccountCapabilitiesP24Payments =
        | Active
        | Inactive
        | Pending

    and AccountCapabilitiesSepaDebitPayments =
        | Active
        | Inactive
        | Pending

    and AccountCapabilitiesSofortPayments =
        | Active
        | Inactive
        | Pending

    and AccountCapabilitiesTaxReportingUs1099K =
        | Active
        | Inactive
        | Pending

    and AccountCapabilitiesTaxReportingUs1099Misc =
        | Active
        | Inactive
        | Pending

    and AccountCapabilitiesTransfers =
        | Active
        | Inactive
        | Pending

    ///
    and AccountCapabilityRequirements =
        {
            CurrentDeadline: int64 option
            CurrentlyDue: string list
            DisabledReason: string option
            Errors: AccountRequirementsError list
            EventuallyDue: string list
            PastDue: string list
            PendingVerification: string list
        }

    ///
    and AccountCardPaymentsSettings =
        {
            DeclineOn: AccountDeclineChargeOn option
            StatementDescriptorPrefix: string option
        }

    ///
    and AccountDashboardSettings =
        {
            DisplayName: string option
            Timezone: string option
        }

    ///
    and AccountDeclineChargeOn =
        {
            AvsFailure: bool
            CvcFailure: bool
        }

    ///Account Links are the means by which a Connect platform grants a connected account permission to access
    ///Stripe-hosted applications, such as Connect Onboarding.
    ///
    ///Related guide: [Connect Onboarding](https://stripe.com/docs/connect/connect-onboarding).
    and AccountLink =
        {
            Created: int64
            ExpiresAt: int64
            Url: string
        }
        member _.Object = "account_link"

    ///
    and AccountPaymentsSettings =
        {
            StatementDescriptor: string option
            StatementDescriptorKana: string option
            StatementDescriptorKanji: string option
        }

    ///
    and AccountPayoutSettings =
        {
            DebitNegativeBalances: bool
            Schedule: TransferSchedule
            StatementDescriptor: string option
        }

    ///
    and AccountRequirements =
        {
            CurrentDeadline: int64 option
            CurrentlyDue: string list option
            DisabledReason: AccountRequirementsDisabledReason option
            Errors: AccountRequirementsError list option
            EventuallyDue: string list option
            PastDue: string list option
            PendingVerification: string list option
        }

    and AccountRequirementsDisabledReason =
        | RequirementsPastDue
        | RequirementsPendingVerification
        | RejectedFraud
        | RejectedTermsOfService
        | RejectedListed
        | RejectedOther
        | Listed
        | UnderReview
        | Other

    ///
    and AccountRequirementsError =
        {
            Code: AccountRequirementsErrorCode
            Reason: string
            Requirement: string
        }

    and AccountRequirementsErrorCode =
        | InvalidAddressCityStatePostalCode
        | InvalidStreetAddress
        | InvalidValueOther
        | VerificationDocumentAddressMismatch
        | VerificationDocumentAddressMissing
        | VerificationDocumentCorrupt
        | VerificationDocumentCountryNotSupported
        | VerificationDocumentDobMismatch
        | VerificationDocumentDuplicateType
        | VerificationDocumentExpired
        | VerificationDocumentFailedCopy
        | VerificationDocumentFailedGreyscale
        | VerificationDocumentFailedOther
        | VerificationDocumentFailedTestMode
        | VerificationDocumentFraudulent
        | VerificationDocumentIdNumberMismatch
        | VerificationDocumentIdNumberMissing
        | VerificationDocumentIncomplete
        | VerificationDocumentInvalid
        | VerificationDocumentIssueOrExpiryDateMissing
        | VerificationDocumentManipulated
        | VerificationDocumentMissingBack
        | VerificationDocumentMissingFront
        | VerificationDocumentNameMismatch
        | VerificationDocumentNameMissing
        | VerificationDocumentNationalityMismatch
        | VerificationDocumentNotReadable
        | VerificationDocumentNotSigned
        | VerificationDocumentNotUploaded
        | VerificationDocumentPhotoMismatch
        | VerificationDocumentTooLarge
        | VerificationDocumentTypeNotSupported
        | VerificationFailedAddressMatch
        | VerificationFailedBusinessIecNumber
        | VerificationFailedDocumentMatch
        | VerificationFailedIdNumberMatch
        | VerificationFailedKeyedIdentity
        | VerificationFailedKeyedMatch
        | VerificationFailedNameMatch
        | VerificationFailedOther
        | VerificationFailedTaxIdMatch
        | VerificationFailedTaxIdNotIssued

    ///
    and AccountSepaDebitPaymentsSettings =
        {
            CreditorId: string option
        }

    ///
    and AccountSettings =
        {
            BacsDebitPayments: AccountBacsDebitPaymentsSettings option
            Branding: AccountBrandingSettings
            CardPayments: AccountCardPaymentsSettings
            Dashboard: AccountDashboardSettings
            Payments: AccountPaymentsSettings
            Payouts: AccountPayoutSettings option
            SepaDebitPayments: AccountSepaDebitPaymentsSettings option
        }

    ///
    and AccountTosAcceptance =
        {
            Date: int64 option
            Ip: string option
            ServiceAgreement: string option
            UserAgent: string option
        }

    ///
    and Address =
        {
            City: string option
            Country: string option
            [<JsonField("line1")>]Line1: string option
            [<JsonField("line2")>]Line2: string option
            PostalCode: string option
            State: string option
        }

    ///
    and AlipayAccount =
        {
            Created: int64
            Customer: string option
            Fingerprint: string
            Id: string
            Livemode: bool
            Metadata: Map<string, string>
            PaymentAmount: int64 option
            PaymentCurrency: string option
            Reusable: bool
            Used: bool
            Username: string
        }
        member _.Object = "alipay_account"

    ///
    and AlternateStatementDescriptors =
        {
            Kana: string option
            Kanji: string option
        }

    ///
    and ApiErrors =
        {
            Charge: string option
            Code: string option
            DeclineCode: string option
            DocUrl: string option
            Message: string option
            Param: string option
            PaymentIntent: PaymentIntent option
            PaymentMethod: PaymentMethod option
            PaymentMethodType: string option
            SetupIntent: SetupIntent option
            Source: PaymentSource option
            Type: ApiErrorsType
        }

    and ApiErrorsType =
        | ApiConnectionError
        | ApiError
        | AuthenticationError
        | CardError
        | IdempotencyError
        | InvalidRequestError
        | RateLimitError

    ///
    and ApplePayDomain =
        {
            Created: int64
            DomainName: string
            Id: string
            Livemode: bool
        }
        member _.Object = "apple_pay_domain"

    ///
    and Application =
        {
            Id: string
            Name: string option
        }
        member _.Object = "application"

    ///
    and ApplicationFee =
        {
            Account: string
            Amount: int64
            AmountRefunded: int64
            Application: string
            BalanceTransaction: string option
            Charge: string
            Created: int64
            Currency: string
            Id: string
            Livemode: bool
            OriginatingTransaction: string option
            Refunded: bool
            Refunds: Map<string, string>
        }
        member _.Object = "application_fee"

    ///This is an object representing your Stripe balance. You can retrieve it to see
    ///the balance currently on your Stripe account.
    ///
    ///You can also retrieve the balance history, which contains a list of
    ///[transactions](https://stripe.com/docs/reporting/balance-transaction-types) that contributed to the balance
    ///(charges, payouts, and so forth).
    ///
    ///The available and pending amounts for each currency are broken down further by
    ///payment source types.
    ///
    ///Related guide: [Understanding Connect Account Balances](https://stripe.com/docs/connect/account-balances).
    and Balance =
        {
            Available: BalanceAmount list
            ConnectReserved: BalanceAmount list option
            InstantAvailable: BalanceAmount list option
            Issuing: BalanceDetail option
            Livemode: bool
            Pending: BalanceAmount list
        }
        member _.Object = "balance"

    ///
    and BalanceAmount =
        {
            Amount: int64
            Currency: string
            SourceTypes: BalanceAmountBySourceType option
        }

    ///
    and BalanceAmountBySourceType =
        {
            BankAccount: int64 option
            Card: int64 option
            Fpx: int64 option
        }

    ///
    and BalanceDetail =
        {
            Available: BalanceAmount list
        }

    ///Balance transactions represent funds moving through your Stripe account.
    ///They're created for every type of transaction that comes into or flows out of your Stripe account balance.
    ///
    ///Related guide: [Balance Transaction Types](https://stripe.com/docs/reports/balance-transaction-types).
    and BalanceTransaction =
        {
            Amount: int64
            AvailableOn: int64
            Created: int64
            Currency: string
            Description: string option
            ExchangeRate: decimal option
            Fee: int64
            FeeDetails: Fee list
            Id: string
            Net: int64
            ReportingCategory: string
            Source: string option
            Status: string
            Type: BalanceTransactionType
        }
        member _.Object = "balance_transaction"

    and BalanceTransactionType =
        | Adjustment
        | Advance
        | AdvanceFunding
        | AnticipationRepayment
        | ApplicationFee
        | ApplicationFeeRefund
        | Charge
        | ConnectCollectionTransfer
        | Contribution
        | IssuingAuthorizationHold
        | IssuingAuthorizationRelease
        | IssuingDispute
        | IssuingTransaction
        | Payment
        | PaymentFailureRefund
        | PaymentRefund
        | Payout
        | PayoutCancel
        | PayoutFailure
        | Refund
        | RefundFailure
        | ReserveTransaction
        | ReservedFunds
        | StripeFee
        | StripeFxFee
        | TaxFee
        | Topup
        | TopupReversal
        | Transfer
        | TransferCancel
        | TransferFailure
        | TransferRefund

    and BalanceTransactionSource =
        | ApplicationFee of ApplicationFee
        | Charge of Charge
        | ConnectCollectionTransfer of ConnectCollectionTransfer
        | Dispute of Dispute
        | FeeRefund of FeeRefund
        | IssuingAuthorization of IssuingAuthorization
        | IssuingDispute of IssuingDispute
        | IssuingTransaction of IssuingTransaction
        | Payout of Payout
        | PlatformTaxFee of PlatformTaxFee
        | Refund of Refund
        | ReserveTransaction of ReserveTransaction
        | TaxDeductedAtSource of TaxDeductedAtSource
        | Topup of Topup
        | Transfer of Transfer
        | TransferReversal of TransferReversal

    ///These bank accounts are payment methods on `Customer` objects.
    ///
    ///On the other hand [External Accounts](https://stripe.com/docs/api#external_accounts) are transfer
    ///destinations on `Account` objects for [Custom accounts](https://stripe.com/docs/connect/custom-accounts).
    ///They can be bank accounts or debit cards as well, and are documented in the links above.
    ///
    ///Related guide: [Bank Debits and Transfers](https://stripe.com/docs/payments/bank-debits-transfers).
    and BankAccount =
        {
            Account: string option
            AccountHolderName: string option
            AccountHolderType: string option
            AvailablePayoutMethods: BankAccountAvailablePayoutMethods list option
            BankName: string option
            Country: string
            Currency: string
            Customer: string option
            DefaultForCurrency: bool option
            Fingerprint: string option
            Id: string
            [<JsonField("last4")>]Last4: string
            Metadata: Map<string, string>
            RoutingNumber: string option
            Status: string
        }
        member _.Object = "bank_account"

    and BankAccountAvailablePayoutMethods =
        | Instant
        | Standard

    ///
    and BillingDetails =
        {
            Address: Address option
            Email: string option
            Name: string option
            Phone: string option
        }

    ///A session describes the instantiation of the customer portal for
    ///a particular customer. By visiting the session's URL, the customer
    ///can manage their subscriptions and billing details. For security reasons,
    ///sessions are short-lived and will expire if the customer does not visit the URL.
    ///Create sessions on-demand when customers intend to manage their subscriptions and billing details.
    ///
    ///Integration guide: [Billing customer portal](https://stripe.com/docs/billing/subscriptions/integrating-customer-portal).
    and BillingPortalSession =
        {
            Created: int64
            Customer: string
            Id: string
            Livemode: bool
            ReturnUrl: string
            Url: string
        }
        member _.Object = "billing_portal.session"

    ///
    and BitcoinReceiver =
        {
            Active: bool
            Amount: int64
            AmountReceived: int64
            BitcoinAmount: int64
            BitcoinAmountReceived: int64
            BitcoinUri: string
            Created: int64
            Currency: string
            Customer: string option
            Description: string option
            Email: string option
            Filled: bool
            Id: string
            InboundAddress: string
            Livemode: bool
            Metadata: Map<string, string>
            Payment: string option
            RefundAddress: string option
            Transactions: Map<string, string>
            UncapturedFunds: bool
            UsedForPayment: bool option
        }
        member _.Object = "bitcoin_receiver"

    ///
    and BitcoinTransaction =
        {
            Amount: int64
            BitcoinAmount: int64
            Created: int64
            Currency: string
            Id: string
            Receiver: string
        }
        member _.Object = "bitcoin_transaction"

    ///This is an object representing a capability for a Stripe account.
    ///
    ///Related guide: [Account capabilities](https://stripe.com/docs/connect/account-capabilities).
    and Capability =
        {
            Account: string
            Id: string
            Requested: bool
            RequestedAt: int64 option
            Requirements: AccountCapabilityRequirements option
            Status: CapabilityStatus
        }
        member _.Object = "capability"

    and CapabilityStatus =
        | Active
        | Disabled
        | Inactive
        | Pending
        | Unrequested

    ///You can store multiple cards on a customer in order to charge the customer
    ///later. You can also store multiple debit cards on a recipient in order to
    ///transfer to those cards later.
    ///
    ///Related guide: [Card Payments with Sources](https://stripe.com/docs/sources/cards).
    and Card =
        {
            Account: string option
            AddressCity: string option
            AddressCountry: string option
            [<JsonField("address_line1")>]AddressLine1: string option
            [<JsonField("address_line1_check")>]AddressLine1Check: string option
            [<JsonField("address_line2")>]AddressLine2: string option
            AddressState: string option
            AddressZip: string option
            AddressZipCheck: string option
            AvailablePayoutMethods: CardAvailablePayoutMethods list option
            Brand: CardBrand
            Country: string option
            Currency: string option
            Customer: string option
            CvcCheck: string option
            DefaultForCurrency: bool option
            Description: string option
            [<JsonField("dynamic_last4")>]DynamicLast4: string option
            ExpMonth: int64
            ExpYear: int64
            Fingerprint: string option
            Funding: CardFunding
            Id: string
            Iin: string option
            Issuer: string option
            [<JsonField("last4")>]Last4: string
            Metadata: Map<string, string>
            Name: string option
            Recipient: string option
            TokenizationMethod: CardTokenizationMethod option
        }
        member _.Object = "card"

    and CardAvailablePayoutMethods =
        | Instant
        | Standard

    and CardBrand =
        | [<JsonUnionCase("American Express")>] AmericanExpress
        | [<JsonUnionCase("Diners Club")>] DinersClub
        | [<JsonUnionCase("Discover")>] Discover
        | [<JsonUnionCase("JCB")>] JCB
        | [<JsonUnionCase("MasterCard")>] MasterCard
        | [<JsonUnionCase("UnionPay")>] UnionPay
        | [<JsonUnionCase("Visa")>] Visa
        | [<JsonUnionCase("Unknown")>] Unknown

    and CardFunding =
        | Credit
        | Debit
        | Prepaid
        | Unknown

    and CardTokenizationMethod =
        | AndroidPay
        | ApplePay
        | Masterpass
        | VisaCheckout

    ///
    and CardMandatePaymentMethodDetails =
        {
            Undefined: string list option
        }

    ///To charge a credit or a debit card, you create a `Charge` object. You can
    ///retrieve and refund individual charges as well as list all charges. Charges
    ///are identified by a unique, random ID.
    ///
    ///Related guide: [Accept a payment with the Charges API](https://stripe.com/docs/payments/accept-a-payment-charges).
    and Charge =
        {
            AlternateStatementDescriptors: AlternateStatementDescriptors option
            Amount: int64
            AmountCaptured: int64
            AmountRefunded: int64
            Application: string option
            ApplicationFee: string option
            ApplicationFeeAmount: int64 option
            AuthorizationCode: string option
            BalanceTransaction: string option
            BillingDetails: BillingDetails
            CalculatedStatementDescriptor: string option
            Captured: bool
            Created: int64
            Currency: string
            Customer: string option
            Description: string option
            Destination: string option
            Dispute: string option
            Disputed: bool
            FailureCode: string option
            FailureMessage: string option
            FraudDetails: ChargeFraudDetails option
            Id: string
            Invoice: string option
            [<JsonField("level3")>]Level3: Level3 option
            Livemode: bool
            Metadata: Map<string, string>
            OnBehalfOf: string option
            Order: string option
            Outcome: ChargeOutcome option
            Paid: bool
            PaymentIntent: string option
            PaymentMethod: string option
            PaymentMethodDetails: PaymentMethodDetails option
            ReceiptEmail: string option
            ReceiptNumber: string option
            ReceiptUrl: string option
            Refunded: bool
            Refunds: Map<string, string>
            Review: string option
            Shipping: Shipping option
            Source: PaymentSource option
            SourceTransfer: string option
            StatementDescriptor: string option
            StatementDescriptorSuffix: string option
            Status: string
            Transfer: string option
            TransferData: ChargeTransferData option
            TransferGroup: string option
        }
        member _.Object = "charge"

    ///
    and ChargeFraudDetails =
        {
            StripeReport: string option
            UserReport: string option
        }

    ///
    and ChargeOutcome =
        {
            NetworkStatus: string option
            Reason: string option
            RiskLevel: string option
            RiskScore: int64 option
            Rule: string option
            SellerMessage: string option
            Type: string
        }

    ///
    and ChargeTransferData =
        {
            Amount: int64 option
            Destination: string
        }

    ///A Checkout Session represents your customer's session as they pay for
    ///one-time purchases or subscriptions through [Checkout](https://stripe.com/docs/payments/checkout).
    ///We recommend creating a new Session each time your customer attempts to pay.
    ///
    ///Once payment is successful, the Checkout Session will contain a reference
    ///to the [Customer](https://stripe.com/docs/api/customers), and either the successful
    ///[PaymentIntent](https://stripe.com/docs/api/payment_intents) or an active
    ///[Subscription](https://stripe.com/docs/api/subscriptions).
    ///
    ///You can create a Checkout Session on your server and pass its ID to the
    ///client to begin Checkout.
    ///
    ///Related guide: [Checkout Server Quickstart](https://stripe.com/docs/payments/checkout/api).
    and CheckoutSession =
        {
            AllowPromotionCodes: bool option
            AmountSubtotal: int64 option
            AmountTotal: int64 option
            BillingAddressCollection: CheckoutSessionBillingAddressCollection option
            CancelUrl: string
            ClientReferenceId: string option
            Currency: string option
            Customer: string option
            CustomerEmail: string option
            Id: string
            LineItems: Map<string, string>
            Livemode: bool
            Locale: CheckoutSessionLocale option
            Metadata: Map<string, string>
            Mode: CheckoutSessionMode
            PaymentIntent: string option
            PaymentMethodTypes: string list
            PaymentStatus: CheckoutSessionPaymentStatus
            SetupIntent: string option
            Shipping: Shipping option
            ShippingAddressCollection: PaymentPagesPaymentPageResourcesShippingAddressCollection option
            SubmitType: CheckoutSessionSubmitType option
            Subscription: string option
            SuccessUrl: string
            TotalDetails: PaymentPagesCheckoutSessionTotalDetails option
        }
        member _.Object = "checkout.session"

    and CheckoutSessionBillingAddressCollection =
        | Auto
        | Required

    and CheckoutSessionLocale =
        | Auto
        | Bg
        | Cs
        | Da
        | De
        | El
        | En
        | [<JsonUnionCase("en-GB")>] EnGB
        | Es
        | [<JsonUnionCase("es-419")>] Es419
        | Et
        | Fi
        | Fr
        | [<JsonUnionCase("fr-CA")>] FrCA
        | Hu
        | Id
        | It
        | Ja
        | Lt
        | Lv
        | Ms
        | Mt
        | Nb
        | Nl
        | Pl
        | Pt
        | [<JsonUnionCase("pt-BR")>] PtBR
        | Ro
        | Ru
        | Sk
        | Sl
        | Sv
        | Tr
        | Zh
        | [<JsonUnionCase("zh-HK")>] ZhHK
        | [<JsonUnionCase("zh-TW")>] ZhTW

    and CheckoutSessionMode =
        | Payment
        | Setup
        | Subscription

    and CheckoutSessionPaymentStatus =
        | NoPaymentRequired
        | Paid
        | Unpaid

    and CheckoutSessionSubmitType =
        | Auto
        | Book
        | Donate
        | Pay

    ///
    and ConnectCollectionTransfer =
        {
            Amount: int64
            Currency: string
            Destination: string
            Id: string
            Livemode: bool
        }
        member _.Object = "connect_collection_transfer"

    ///Stripe needs to collect certain pieces of information about each account
    ///created. These requirements can differ depending on the account's country. The
    ///Country Specs API makes these rules available to your integration.
    ///
    ///You can also view the information from this API call as [an online
    ///guide](/docs/connect/required-verification-information).
    and CountrySpec =
        {
            DefaultCurrency: string
            Id: string
            SupportedBankAccountCurrencies: Map<string, string>
            SupportedPaymentCurrencies: string list
            SupportedPaymentMethods: string list
            SupportedTransferCountries: string list
            VerificationFields: CountrySpecVerificationFields
        }
        member _.Object = "country_spec"

    ///
    and CountrySpecVerificationFieldDetails =
        {
            Additional: string list
            Minimum: string list
        }

    ///
    and CountrySpecVerificationFields =
        {
            Company: CountrySpecVerificationFieldDetails
            Individual: CountrySpecVerificationFieldDetails
        }

    ///A coupon contains information about a percent-off or amount-off discount you
    ///might want to apply to a customer. Coupons may be applied to [invoices](https://stripe.com/docs/api#invoices) or
    ///[orders](https://stripe.com/docs/api#create_order-coupon). Coupons do not work with conventional one-off [charges](https://stripe.com/docs/api#create_charge).
    and Coupon =
        {
            AmountOff: int64 option
            AppliesTo: CouponAppliesTo option
            Created: int64
            Currency: string option
            Duration: CouponDuration
            DurationInMonths: int64 option
            Id: string
            Livemode: bool
            MaxRedemptions: int64 option
            Metadata: Map<string, string>
            Name: string option
            PercentOff: decimal option
            RedeemBy: int64 option
            TimesRedeemed: int64
            Valid: bool
        }
        member _.Object = "coupon"

    and CouponDuration =
        | Forever
        | Once
        | Repeating

    ///
    and CouponAppliesTo =
        {
            Products: string list
        }

    ///Issue a credit note to adjust an invoice's amount after the invoice is finalized.
    ///
    ///Related guide: [Credit Notes](https://stripe.com/docs/billing/invoices/credit-notes).
    and CreditNote =
        {
            Amount: int64
            Created: int64
            Currency: string
            Customer: string
            CustomerBalanceTransaction: string option
            DiscountAmount: int64
            DiscountAmounts: DiscountsResourceDiscountAmount list
            Id: string
            Invoice: string
            Lines: Map<string, string>
            Livemode: bool
            Memo: string option
            Metadata: Map<string, string>
            Number: string
            OutOfBandAmount: int64 option
            Pdf: string
            Reason: CreditNoteReason option
            Refund: string option
            Status: CreditNoteStatus
            Subtotal: int64
            TaxAmounts: CreditNoteTaxAmount list
            Total: int64
            Type: CreditNoteType
            VoidedAt: int64 option
        }
        member _.Object = "credit_note"

    and CreditNoteReason =
        | Duplicate
        | Fraudulent
        | OrderChange
        | ProductUnsatisfactory

    and CreditNoteStatus =
        | Issued
        | Void

    and CreditNoteType =
        | PostPayment
        | PrePayment

    ///
    and CreditNoteLineItem =
        {
            Amount: int64
            Description: string option
            DiscountAmount: int64
            DiscountAmounts: DiscountsResourceDiscountAmount list
            Id: string
            InvoiceLineItem: string option
            Livemode: bool
            Quantity: int64 option
            TaxAmounts: CreditNoteTaxAmount list
            TaxRates: TaxRate list
            Type: CreditNoteLineItemType
            UnitAmount: int64 option
            UnitAmountDecimal: string option
        }
        member _.Object = "credit_note_line_item"

    and CreditNoteLineItemType =
        | CustomLineItem
        | InvoiceLineItem

    ///
    and CreditNoteTaxAmount =
        {
            Amount: int64
            Inclusive: bool
            TaxRate: string
        }

    ///`Customer` objects allow you to perform recurring charges, and to track
    ///multiple charges, that are associated with the same customer. The API allows
    ///you to create, delete, and update your customers. You can retrieve individual
    ///customers as well as a list of all your customers.
    ///
    ///Related guide: [Save a card during payment](https://stripe.com/docs/payments/save-during-payment).
    and Customer =
        {
            Address: Address option
            Balance: int64 option
            Created: int64
            Currency: string option
            DefaultSource: string option
            Delinquent: bool option
            Description: string option
            Discount: Discount option
            Email: string option
            Id: string
            InvoicePrefix: string option
            InvoiceSettings: InvoiceSettingCustomerSetting option
            Livemode: bool
            Metadata: Map<string, string>
            Name: string option
            NextInvoiceSequence: int64 option
            Phone: string option
            PreferredLocales: string list option
            Shipping: Shipping option
            Sources: Map<string, string>
            Subscriptions: Map<string, string>
            TaxExempt: CustomerTaxExempt option
            TaxIds: Map<string, string>
        }
        member _.Object = "customer"

    and CustomerTaxExempt =
        | Exempt
        | None'
        | Reverse

    ///
    and CustomerAcceptance =
        {
            AcceptedAt: int64 option
            Offline: OfflineAcceptance option
            Online: OnlineAcceptance option
            Type: CustomerAcceptanceType
        }

    and CustomerAcceptanceType =
        | Offline
        | Online

    ///Each customer has a [`balance`](https://stripe.com/docs/api/customers/object#customer_object-balance) value,
    ///which denotes a debit or credit that's automatically applied to their next invoice upon finalization.
    ///You may modify the value directly by using the [update customer API](https://stripe.com/docs/api/customers/update),
    ///or by creating a Customer Balance Transaction, which increments or decrements the customer's `balance` by the specified `amount`.
    ///
    ///Related guide: [Customer Balance](https://stripe.com/docs/billing/customer/balance) to learn more.
    and CustomerBalanceTransaction =
        {
            Amount: int64
            Created: int64
            CreditNote: string option
            Currency: string
            Customer: string
            Description: string option
            EndingBalance: int64
            Id: string
            Invoice: string option
            Livemode: bool
            Metadata: Map<string, string>
            Type: CustomerBalanceTransactionType
        }
        member _.Object = "customer_balance_transaction"

    and CustomerBalanceTransactionType =
        | Adjustment
        | AppliedToInvoice
        | CreditNote
        | Initial
        | InvoiceTooLarge
        | InvoiceTooSmall
        | Migration
        | UnappliedFromInvoice
        | UnspentReceiverCredit

    ///
    and DeletedAccount =
        {
            Deleted: DeletedAccountDeleted
            Id: string
        }
        member _.Object = "deleted_account"

    and DeletedAccountDeleted =
        | True

    ///
    and DeletedAlipayAccount =
        {
            Deleted: DeletedAlipayAccountDeleted
            Id: string
        }
        member _.Object = "deleted_alipay_account"

    and DeletedAlipayAccountDeleted =
        | True

    ///
    and DeletedApplePayDomain =
        {
            Deleted: DeletedApplePayDomainDeleted
            Id: string
        }
        member _.Object = "deleted_apple_pay_domain"

    and DeletedApplePayDomainDeleted =
        | True

    ///
    and DeletedBankAccount =
        {
            Currency: string option
            Deleted: DeletedBankAccountDeleted
            Id: string
        }
        member _.Object = "deleted_bank_account"

    and DeletedBankAccountDeleted =
        | True

    ///
    and DeletedBitcoinReceiver =
        {
            Deleted: DeletedBitcoinReceiverDeleted
            Id: string
        }
        member _.Object = "deleted_bitcoin_receiver"

    and DeletedBitcoinReceiverDeleted =
        | True

    ///
    and DeletedCard =
        {
            Currency: string option
            Deleted: DeletedCardDeleted
            Id: string
        }
        member _.Object = "deleted_card"

    and DeletedCardDeleted =
        | True

    ///
    and DeletedCoupon =
        {
            Deleted: DeletedCouponDeleted
            Id: string
        }
        member _.Object = "deleted_coupon"

    and DeletedCouponDeleted =
        | True

    ///
    and DeletedCustomer =
        {
            Deleted: DeletedCustomerDeleted
            Id: string
        }
        member _.Object = "deleted_customer"

    and DeletedCustomerDeleted =
        | True

    ///
    and DeletedDiscount =
        {
            CheckoutSession: string option
            Coupon: Coupon
            Customer: string option
            Deleted: DeletedDiscountDeleted
            Id: string
            Invoice: string option
            InvoiceItem: string option
            PromotionCode: string option
            Start: int64
            Subscription: string option
        }
        member _.Object = "deleted_discount"

    and DeletedDiscountDeleted =
        | True

    and DeletedExternalAccount =
        | DeletedBankAccount of DeletedBankAccount
        | DeletedCard of DeletedCard

    ///
    and DeletedInvoice =
        {
            Deleted: DeletedInvoiceDeleted
            Id: string
        }
        member _.Object = "deleted_invoice"

    and DeletedInvoiceDeleted =
        | True

    ///
    and DeletedInvoiceitem =
        {
            Deleted: DeletedInvoiceitemDeleted
            Id: string
        }
        member _.Object = "deleted_invoiceitem"

    and DeletedInvoiceitemDeleted =
        | True

    and DeletedPaymentSource =
        | DeletedAlipayAccount of DeletedAlipayAccount
        | DeletedBankAccount of DeletedBankAccount
        | DeletedBitcoinReceiver of DeletedBitcoinReceiver
        | DeletedCard of DeletedCard

    ///
    and DeletedPerson =
        {
            Deleted: DeletedPersonDeleted
            Id: string
        }
        member _.Object = "deleted_person"

    and DeletedPersonDeleted =
        | True

    ///
    and DeletedPlan =
        {
            Deleted: DeletedPlanDeleted
            Id: string
        }
        member _.Object = "deleted_plan"

    and DeletedPlanDeleted =
        | True

    ///
    and DeletedPrice =
        {
            Deleted: DeletedPriceDeleted
            Id: string
        }
        member _.Object = "deleted_price"

    and DeletedPriceDeleted =
        | True

    ///
    and DeletedProduct =
        {
            Deleted: DeletedProductDeleted
            Id: string
        }
        member _.Object = "deleted_product"

    and DeletedProductDeleted =
        | True

    ///
    and DeletedRadarValueList =
        {
            Deleted: DeletedRadarValueListDeleted
            Id: string
        }
        member _.Object = "deleted_radar.value_list"

    and DeletedRadarValueListDeleted =
        | True

    ///
    and DeletedRadarValueListItem =
        {
            Deleted: DeletedRadarValueListItemDeleted
            Id: string
        }
        member _.Object = "deleted_radar.value_list_item"

    and DeletedRadarValueListItemDeleted =
        | True

    ///
    and DeletedRecipient =
        {
            Deleted: DeletedRecipientDeleted
            Id: string
        }
        member _.Object = "deleted_recipient"

    and DeletedRecipientDeleted =
        | True

    ///
    and DeletedSku =
        {
            Deleted: DeletedSkuDeleted
            Id: string
        }
        member _.Object = "deleted_sku"

    and DeletedSkuDeleted =
        | True

    ///
    and DeletedSubscriptionItem =
        {
            Deleted: DeletedSubscriptionItemDeleted
            Id: string
        }
        member _.Object = "deleted_subscription_item"

    and DeletedSubscriptionItemDeleted =
        | True

    ///
    and DeletedTaxId =
        {
            Deleted: DeletedTaxIdDeleted
            Id: string
        }
        member _.Object = "deleted_tax_id"

    and DeletedTaxIdDeleted =
        | True

    ///
    and DeletedTerminalLocation =
        {
            Deleted: DeletedTerminalLocationDeleted
            Id: string
        }
        member _.Object = "deleted_terminal.location"

    and DeletedTerminalLocationDeleted =
        | True

    ///
    and DeletedTerminalReader =
        {
            Deleted: DeletedTerminalReaderDeleted
            Id: string
        }
        member _.Object = "deleted_terminal.reader"

    and DeletedTerminalReaderDeleted =
        | True

    ///
    and DeletedWebhookEndpoint =
        {
            Deleted: DeletedWebhookEndpointDeleted
            Id: string
        }
        member _.Object = "deleted_webhook_endpoint"

    and DeletedWebhookEndpointDeleted =
        | True

    ///
    and DeliveryEstimate =
        {
            Date: string option
            Earliest: string option
            Latest: string option
            Type: string
        }

    ///A discount represents the actual application of a coupon to a particular
    ///customer. It contains information about when the discount began and when it
    ///will end.
    ///
    ///Related guide: [Applying Discounts to Subscriptions](https://stripe.com/docs/billing/subscriptions/discounts).
    and Discount =
        {
            CheckoutSession: string option
            Coupon: Coupon
            Customer: string option
            End: int64 option
            Id: string
            Invoice: string option
            InvoiceItem: string option
            PromotionCode: string option
            Start: int64
            Subscription: string option
        }
        member _.Object = "discount"

    ///
    and DiscountsResourceDiscountAmount =
        {
            Amount: int64
            Discount: string
        }

    ///A dispute occurs when a customer questions your charge with their card issuer.
    ///When this happens, you're given the opportunity to respond to the dispute with
    ///evidence that shows that the charge is legitimate. You can find more
    ///information about the dispute process in our [Disputes and
    ///Fraud](/docs/disputes) documentation.
    ///
    ///Related guide: [Disputes and Fraud](https://stripe.com/docs/disputes).
    and Dispute =
        {
            Amount: int64
            BalanceTransactions: BalanceTransaction list
            Charge: string
            Created: int64
            Currency: string
            Evidence: DisputeEvidence
            EvidenceDetails: DisputeEvidenceDetails
            Id: string
            IsChargeRefundable: bool
            Livemode: bool
            Metadata: Map<string, string>
            NetworkReasonCode: string option
            PaymentIntent: string option
            Reason: string
            Status: DisputeStatus
        }
        member _.Object = "dispute"

    and DisputeStatus =
        | ChargeRefunded
        | Lost
        | NeedsResponse
        | UnderReview
        | WarningClosed
        | WarningNeedsResponse
        | WarningUnderReview
        | Won

    ///
    and DisputeEvidence =
        {
            AccessActivityLog: string option
            BillingAddress: string option
            CancellationPolicy: string option
            CancellationPolicyDisclosure: string option
            CancellationRebuttal: string option
            CustomerCommunication: string option
            CustomerEmailAddress: string option
            CustomerName: string option
            CustomerPurchaseIp: string option
            CustomerSignature: string option
            DuplicateChargeDocumentation: string option
            DuplicateChargeExplanation: string option
            DuplicateChargeId: string option
            ProductDescription: string option
            Receipt: string option
            RefundPolicy: string option
            RefundPolicyDisclosure: string option
            RefundRefusalExplanation: string option
            ServiceDate: string option
            ServiceDocumentation: string option
            ShippingAddress: string option
            ShippingCarrier: string option
            ShippingDate: string option
            ShippingDocumentation: string option
            ShippingTrackingNumber: string option
            UncategorizedFile: string option
            UncategorizedText: string option
        }

    ///
    and DisputeEvidenceDetails =
        {
            DueBy: int64 option
            HasEvidence: bool
            PastDue: bool
            SubmissionCount: int64
        }

    ///
    and EphemeralKey =
        {
            Created: int64
            Expires: int64
            Id: string
            Livemode: bool
            Secret: string option
        }
        member _.Object = "ephemeral_key"

    ///An error response from the Stripe API
    and Error =
        {
            Error: ApiErrors
        }

    ///Events are our way of letting you know when something interesting happens in
    ///your account. When an interesting event occurs, we create a new `Event`
    ///object. For example, when a charge succeeds, we create a `charge.succeeded`
    ///event; and when an invoice payment attempt fails, we create an
    ///`invoice.payment_failed` event. Note that many API requests may cause multiple
    ///events to be created. For example, if you create a new subscription for a
    ///customer, you will receive both a `customer.subscription.created` event and a
    ///`charge.succeeded` event.
    ///
    ///Events occur when the state of another API resource changes. The state of that
    ///resource at the time of the change is embedded in the event's data field. For
    ///example, a `charge.succeeded` event will contain a charge, and an
    ///`invoice.payment_failed` event will contain an invoice.
    ///
    ///As with other API resources, you can use endpoints to retrieve an
    ///[individual event](https://stripe.com/docs/api#retrieve_event) or a [list of events](https://stripe.com/docs/api#list_events)
    ///from the API. We also have a separate
    ///[webhooks](http://en.wikipedia.org/wiki/Webhook) system for sending the
    ///`Event` objects directly to an endpoint on your server. Webhooks are managed
    ///in your
    ///[account settings](https://dashboard.stripe.com/account/webhooks),
    ///and our [Using Webhooks](https://stripe.com/docs/webhooks) guide will help you get set up.
    ///
    ///When using [Connect](https://stripe.com/docs/connect), you can also receive notifications of
    ///events that occur in connected accounts. For these events, there will be an
    ///additional `account` attribute in the received `Event` object.
    ///
    ///**NOTE:** Right now, access to events through the [Retrieve Event API](https://stripe.com/docs/api#retrieve_event) is
    ///guaranteed only for 30 days.
    and Event =
        {
            Account: string option
            ApiVersion: string option
            Created: int64
            Data: NotificationEventData
            Id: string
            Livemode: bool
            PendingWebhooks: int64
            Request: NotificationEventRequest option
            Type: string
        }
        member _.Object = "event"

    ///`Exchange Rate` objects allow you to determine the rates that Stripe is
    ///currently using to convert from one currency to another. Since this number is
    ///variable throughout the day, there are various reasons why you might want to
    ///know the current rate (for example, to dynamically price an item for a user
    ///with a default payment in a foreign currency).
    ///
    ///If you want a guarantee that the charge is made with a certain exchange rate
    ///you expect is current, you can pass in `exchange_rate` to charges endpoints.
    ///If the value is no longer up to date, the charge won't go through. Please
    ///refer to our [Exchange Rates API](https://stripe.com/docs/exchange-rates) guide for more
    ///details.
    and ExchangeRate =
        {
            Id: string
            Rates: Map<string, string>
        }
        member _.Object = "exchange_rate"

    and ExternalAccount =
        | BankAccount of BankAccount
        | Card of Card

    ///
    and Fee =
        {
            Amount: int64
            Application: string option
            Currency: string
            Description: string option
            Type: string
        }

    ///`Application Fee Refund` objects allow you to refund an application fee that
    ///has previously been created but not yet refunded. Funds will be refunded to
    ///the Stripe account from which the fee was originally collected.
    ///
    ///Related guide: [Refunding Application Fees](https://stripe.com/docs/connect/destination-charges#refunding-app-fee).
    and FeeRefund =
        {
            Amount: int64
            BalanceTransaction: string option
            Created: int64
            Currency: string
            Fee: string
            Id: string
            Metadata: Map<string, string>
        }
        member _.Object = "fee_refund"

    ///This is an object representing a file hosted on Stripe's servers. The
    ///file may have been uploaded by yourself using the [create file](https://stripe.com/docs/api#create_file)
    ///request (for example, when uploading dispute evidence) or it may have
    ///been created by Stripe (for example, the results of a [Sigma scheduled
    ///query](#scheduled_queries)).
    ///
    ///Related guide: [File Upload Guide](https://stripe.com/docs/file-upload).
    and File =
        {
            Created: int64
            ExpiresAt: int64 option
            Filename: string option
            Id: string
            Links: Map<string, string>
            Purpose: FilePurpose
            Size: int64
            Title: string option
            Type: string option
            Url: string option
        }
        member _.Object = "file"

    and FilePurpose =
        | AdditionalVerification
        | BusinessIcon
        | BusinessLogo
        | CustomerSignature
        | DisputeEvidence
        | IdentityDocument
        | PciDocument
        | TaxDocumentUserUpload

    ///To share the contents of a `File` object with non-Stripe users, you can
    ///create a `FileLink`. `FileLink`s contain a URL that can be used to
    ///retrieve the contents of the file without authentication.
    and FileLink =
        {
            Created: int64
            Expired: bool
            ExpiresAt: int64 option
            File: string
            Id: string
            Livemode: bool
            Metadata: Map<string, string>
            Url: string option
        }
        member _.Object = "file_link"

    ///
    and FinancialReportingFinanceReportRunRunParameters =
        {
            Columns: string list option
            ConnectedAccount: string option
            Currency: string option
            IntervalEnd: int64 option
            IntervalStart: int64 option
            Payout: string option
            ReportingCategory: string option
            Timezone: string option
        }

    ///
    and Inventory =
        {
            Quantity: int64 option
            Type: string
            Value: string option
        }

    ///Invoices are statements of amounts owed by a customer, and are either
    ///generated one-off, or generated periodically from a subscription.
    ///
    ///They contain [invoice items](https://stripe.com/docs/api#invoiceitems), and proration adjustments
    ///that may be caused by subscription upgrades/downgrades (if necessary).
    ///
    ///If your invoice is configured to be billed through automatic charges,
    ///Stripe automatically finalizes your invoice and attempts payment. Note
    ///that finalizing the invoice,
    ///[when automatic](https://stripe.com/docs/billing/invoices/workflow/#auto_advance), does
    ///not happen immediately as the invoice is created. Stripe waits
    ///until one hour after the last webhook was successfully sent (or the last
    ///webhook timed out after failing). If you (and the platforms you may have
    ///connected to) have no webhooks configured, Stripe waits one hour after
    ///creation to finalize the invoice.
    ///
    ///If your invoice is configured to be billed by sending an email, then based on your
    ///[email settings](https://dashboard.stripe.com/account/billing/automatic'),
    ///Stripe will email the invoice to your customer and await payment. These
    ///emails can contain a link to a hosted page to pay the invoice.
    ///
    ///Stripe applies any customer credit on the account before determining the
    ///amount due for the invoice (i.e., the amount that will be actually
    ///charged). If the amount due for the invoice is less than Stripe's [minimum allowed charge
    ///per currency](/docs/currencies#minimum-and-maximum-charge-amounts), the
    ///invoice is automatically marked paid, and we add the amount due to the
    ///customer's running account balance which is applied to the next invoice.
    ///
    ///More details on the customer's account balance are
    ///[here](https://stripe.com/docs/api/customers/object#customer_object-account_balance).
    ///
    ///Related guide: [Send Invoices to Customers](https://stripe.com/docs/billing/invoices/sending).
    and Invoice =
        {
            AccountCountry: string option
            AccountName: string option
            AccountTaxIds: string list option
            AmountDue: int64
            AmountPaid: int64
            AmountRemaining: int64
            ApplicationFeeAmount: int64 option
            AttemptCount: int64
            Attempted: bool
            AutoAdvance: bool option
            BillingReason: InvoiceBillingReason option
            Charge: string option
            CollectionMethod: InvoiceCollectionMethod option
            Created: int64
            Currency: string
            CustomFields: InvoiceSettingCustomField list option
            Customer: string
            CustomerAddress: Address option
            CustomerEmail: string option
            CustomerName: string option
            CustomerPhone: string option
            CustomerShipping: Shipping option
            CustomerTaxExempt: InvoiceCustomerTaxExempt option
            CustomerTaxIds: InvoicesResourceInvoiceTaxId list option
            DefaultPaymentMethod: string option
            DefaultSource: string option
            DefaultTaxRates: TaxRate list
            Description: string option
            Discount: Discount option
            Discounts: string list option
            DueDate: int64 option
            EndingBalance: int64 option
            Footer: string option
            HostedInvoiceUrl: string option
            Id: string option
            InvoicePdf: string option
            LastFinalizationError: ApiErrors option
            Lines: Map<string, string>
            Livemode: bool
            Metadata: Map<string, string>
            NextPaymentAttempt: int64 option
            Number: string option
            Paid: bool
            PaymentIntent: string option
            PeriodEnd: int64
            PeriodStart: int64
            PostPaymentCreditNotesAmount: int64
            PrePaymentCreditNotesAmount: int64
            ReceiptNumber: string option
            StartingBalance: int64
            StatementDescriptor: string option
            Status: InvoiceStatus option
            StatusTransitions: InvoicesStatusTransitions
            Subscription: string option
            SubscriptionProrationDate: int64 option
            Subtotal: int64
            Tax: int64 option
            ThresholdReason: InvoiceThresholdReason option
            Total: int64
            TotalDiscountAmounts: DiscountsResourceDiscountAmount list option
            TotalTaxAmounts: InvoiceTaxAmount list
            TransferData: InvoiceTransferData option
            WebhooksDeliveredAt: int64 option
        }
        member _.Object = "invoice"

    and InvoiceBillingReason =
        | AutomaticPendingInvoiceItemInvoice
        | Manual
        | Subscription
        | SubscriptionCreate
        | SubscriptionCycle
        | SubscriptionThreshold
        | SubscriptionUpdate
        | Upcoming

    and InvoiceCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    and InvoiceCustomerTaxExempt =
        | Exempt
        | None'
        | Reverse

    and InvoiceStatus =
        | Deleted
        | Draft
        | Open
        | Paid
        | Uncollectible
        | Void

    ///
    and InvoiceItemThresholdReason =
        {
            LineItemIds: string list
            UsageGte: int64
        }

    ///
    and InvoiceLineItemPeriod =
        {
            End: int64
            Start: int64
        }

    ///
    and InvoiceSettingCustomField =
        {
            Name: string
            Value: string
        }

    ///
    and InvoiceSettingCustomerSetting =
        {
            CustomFields: InvoiceSettingCustomField list option
            DefaultPaymentMethod: string option
            Footer: string option
        }

    ///
    and InvoiceSettingSubscriptionScheduleSetting =
        {
            DaysUntilDue: int64 option
        }

    ///
    and InvoiceTaxAmount =
        {
            Amount: int64
            Inclusive: bool
            TaxRate: string
        }

    ///
    and InvoiceThresholdReason =
        {
            AmountGte: int64 option
            ItemReasons: InvoiceItemThresholdReason list
        }

    ///
    and InvoiceTransferData =
        {
            Amount: int64 option
            Destination: string
        }

    ///Sometimes you want to add a charge or credit to a customer, but actually
    ///charge or credit the customer's card only at the end of a regular billing
    ///cycle. This is useful for combining several charges (to minimize
    ///per-transaction fees), or for having Stripe tabulate your usage-based billing
    ///totals.
    ///
    ///Related guide: [Subscription Invoices](https://stripe.com/docs/billing/invoices/subscription#adding-upcoming-invoice-items).
    and Invoiceitem =
        {
            Amount: int64
            Currency: string
            Customer: string
            Date: int64
            Description: string option
            Discountable: bool
            Discounts: string list option
            Id: string
            Invoice: string option
            Livemode: bool
            Metadata: Map<string, string>
            Period: InvoiceLineItemPeriod
            Plan: Plan option
            Price: Price option
            Proration: bool
            Quantity: int64
            Subscription: string option
            SubscriptionItem: string option
            TaxRates: TaxRate list option
            UnitAmount: int64 option
            UnitAmountDecimal: string option
        }
        member _.Object = "invoiceitem"

    ///
    and InvoicesResourceInvoiceTaxId =
        {
            Type: InvoicesResourceInvoiceTaxIdType
            Value: string option
        }

    and InvoicesResourceInvoiceTaxIdType =
        | AeTrn
        | AuAbn
        | BrCnpj
        | BrCpf
        | CaBn
        | CaQst
        | ChVat
        | ClTin
        | EsCif
        | EuVat
        | HkBr
        | IdNpwp
        | InGst
        | JpCn
        | JpRn
        | KrBrn
        | LiUid
        | MxRfc
        | MyFrp
        | MyItn
        | MySst
        | NoVat
        | NzGst
        | RuInn
        | RuKpp
        | SaVat
        | SgGst
        | SgUen
        | ThVat
        | TwVat
        | Unknown
        | UsEin
        | ZaVat

    ///
    and InvoicesStatusTransitions =
        {
            FinalizedAt: int64 option
            MarkedUncollectibleAt: int64 option
            PaidAt: int64 option
            VoidedAt: int64 option
        }

    ///This resource has been renamed to [Early Fraud
    ///Warning](#early_fraud_warning_object) and will be removed in a future API
    ///version.
    and IssuerFraudRecord =
        {
            Actionable: bool
            Charge: string
            Created: int64
            FraudType: string
            HasLiabilityShift: bool
            Id: string
            Livemode: bool
            PostDate: int64
        }
        member _.Object = "issuer_fraud_record"

    ///When an [issued card](https://stripe.com/docs/issuing) is used to make a purchase, an Issuing `Authorization`
    ///object is created. [Authorizations](https://stripe.com/docs/issuing/purchases/authorizations) must be approved for the
    ///purchase to be completed successfully.
    ///
    ///Related guide: [Issued Card Authorizations](https://stripe.com/docs/issuing/purchases/authorizations).
    and IssuingAuthorization =
        {
            Amount: int64
            AmountDetails: IssuingAuthorizationAmountDetails option
            Approved: bool
            AuthorizationMethod: IssuingAuthorizationAuthorizationMethod
            BalanceTransactions: BalanceTransaction list
            Card: IssuingCard
            Cardholder: string option
            Created: int64
            Currency: string
            Id: string
            Livemode: bool
            MerchantAmount: int64
            MerchantCurrency: string
            MerchantData: IssuingAuthorizationMerchantData
            Metadata: Map<string, string>
            PendingRequest: IssuingAuthorizationPendingRequest option
            RequestHistory: IssuingAuthorizationRequest list
            Status: IssuingAuthorizationStatus
            Transactions: IssuingTransaction list
            VerificationData: IssuingAuthorizationVerificationData
            Wallet: string option
        }
        member _.Object = "issuing.authorization"

    and IssuingAuthorizationAuthorizationMethod =
        | Chip
        | Contactless
        | KeyedIn
        | Online
        | Swipe

    and IssuingAuthorizationStatus =
        | Closed
        | Pending
        | Reversed

    ///You can [create physical or virtual cards](https://stripe.com/docs/issuing/cards) that are issued to cardholders.
    and IssuingCard =
        {
            Brand: string
            CancellationReason: IssuingCardCancellationReason option
            Cardholder: IssuingCardholder
            Created: int64
            Currency: string
            Cvc: string option
            ExpMonth: int64
            ExpYear: int64
            Id: string
            [<JsonField("last4")>]Last4: string
            Livemode: bool
            Metadata: Map<string, string>
            Number: string option
            ReplacedBy: string option
            ReplacementFor: string option
            ReplacementReason: IssuingCardReplacementReason option
            Shipping: IssuingCardShipping option
            SpendingControls: IssuingCardAuthorizationControls
            Status: IssuingCardStatus
            Type: IssuingCardType
        }
        member _.Object = "issuing.card"

    and IssuingCardCancellationReason =
        | Lost
        | Stolen

    and IssuingCardReplacementReason =
        | Damaged
        | Expired
        | Lost
        | Stolen

    and IssuingCardStatus =
        | Active
        | Canceled
        | Inactive

    and IssuingCardType =
        | Physical
        | Virtual

    ///An Issuing `Cardholder` object represents an individual or business entity who is [issued](https://stripe.com/docs/issuing) cards.
    ///
    ///Related guide: [How to create a Cardholder](https://stripe.com/docs/issuing/cards#create-cardholder)
    and IssuingCardholder =
        {
            Billing: IssuingCardholderAddress
            Company: IssuingCardholderCompany option
            Created: int64
            Email: string option
            Id: string
            Individual: IssuingCardholderIndividual option
            Livemode: bool
            Metadata: Map<string, string>
            Name: string
            PhoneNumber: string option
            Requirements: IssuingCardholderRequirements
            SpendingControls: IssuingCardholderAuthorizationControls option
            Status: IssuingCardholderStatus
            Type: IssuingCardholderType
        }
        member _.Object = "issuing.cardholder"

    and IssuingCardholderStatus =
        | Active
        | Blocked
        | Inactive

    and IssuingCardholderType =
        | Company
        | Individual

    ///As a [card issuer](https://stripe.com/docs/issuing), you can dispute transactions that the cardholder does not recognize, suspects to be fraudulent, or has other issues with.
    ///
    ///Related guide: [Disputing Transactions](https://stripe.com/docs/issuing/purchases/disputes)
    and IssuingDispute =
        {
            Amount: int64 option
            BalanceTransactions: BalanceTransaction list option
            Created: int64 option
            Currency: string option
            Evidence: IssuingDisputeEvidence option
            Id: string
            Livemode: bool
            Metadata: Map<string, string>
            Status: IssuingDisputeStatus option
            Transaction: string
        }
        member _.Object = "issuing.dispute"

    and IssuingDisputeStatus =
        | Expired
        | Lost
        | Submitted
        | Unsubmitted
        | Won

    ///Any use of an [issued card](https://stripe.com/docs/issuing) that results in funds entering or leaving
    ///your Stripe account, such as a completed purchase or refund, is represented by an Issuing
    ///`Transaction` object.
    ///
    ///Related guide: [Issued Card Transactions](https://stripe.com/docs/issuing/purchases/transactions).
    and IssuingTransaction =
        {
            Amount: int64
            AmountDetails: IssuingTransactionAmountDetails option
            Authorization: string option
            BalanceTransaction: string option
            Card: string
            Cardholder: string option
            Created: int64
            Currency: string
            Dispute: string option
            Id: string
            Livemode: bool
            MerchantAmount: int64
            MerchantCurrency: string
            MerchantData: IssuingAuthorizationMerchantData
            Metadata: Map<string, string>
            PurchaseDetails: IssuingTransactionPurchaseDetails option
            Type: IssuingTransactionType
        }
        member _.Object = "issuing.transaction"

    and IssuingTransactionType =
        | Capture
        | Dispute
        | Refund

    ///
    and IssuingAuthorizationAmountDetails =
        {
            AtmFee: int64 option
        }

    ///
    and IssuingAuthorizationMerchantData =
        {
            Category: string
            City: string option
            Country: string option
            Name: string option
            NetworkId: string
            PostalCode: string option
            State: string option
        }

    ///
    and IssuingAuthorizationPendingRequest =
        {
            Amount: int64
            AmountDetails: IssuingAuthorizationAmountDetails option
            Currency: string
            IsAmountControllable: bool
            MerchantAmount: int64
            MerchantCurrency: string
        }

    ///
    and IssuingAuthorizationRequest =
        {
            Amount: int64
            AmountDetails: IssuingAuthorizationAmountDetails option
            Approved: bool
            Created: int64
            Currency: string
            MerchantAmount: int64
            MerchantCurrency: string
            Reason: IssuingAuthorizationRequestReason
        }

    and IssuingAuthorizationRequestReason =
        | AccountDisabled
        | CardActive
        | CardInactive
        | CardholderInactive
        | CardholderVerificationRequired
        | InsufficientFunds
        | NotAllowed
        | SpendingControls
        | SuspectedFraud
        | VerificationFailed
        | WebhookApproved
        | WebhookDeclined
        | WebhookTimeout

    ///
    and IssuingAuthorizationVerificationData =
        {
            [<JsonField("address_line1_check")>]AddressLine1Check: IssuingAuthorizationVerificationDataAddressLine1Check
            AddressPostalCodeCheck: IssuingAuthorizationVerificationDataAddressPostalCodeCheck
            CvcCheck: IssuingAuthorizationVerificationDataCvcCheck
            ExpiryCheck: IssuingAuthorizationVerificationDataExpiryCheck
        }

    and IssuingAuthorizationVerificationDataAddressLine1Check =
        | Match
        | Mismatch
        | NotProvided

    and IssuingAuthorizationVerificationDataAddressPostalCodeCheck =
        | Match
        | Mismatch
        | NotProvided

    and IssuingAuthorizationVerificationDataCvcCheck =
        | Match
        | Mismatch
        | NotProvided

    and IssuingAuthorizationVerificationDataExpiryCheck =
        | Match
        | Mismatch
        | NotProvided

    ///
    and IssuingCardAuthorizationControls =
        {
            AllowedCategories: IssuingCardAuthorizationControlsAllowedCategories list option
            BlockedCategories: IssuingCardAuthorizationControlsBlockedCategories list option
            SpendingLimits: IssuingCardSpendingLimit list option
            SpendingLimitsCurrency: string option
        }

    and IssuingCardAuthorizationControlsAllowedCategories =
        | AcRefrigerationRepair
        | AccountingBookkeepingServices
        | AdvertisingServices
        | AgriculturalCooperative
        | AirlinesAirCarriers
        | AirportsFlyingFields
        | AmbulanceServices
        | AmusementParksCarnivals
        | AntiqueReproductions
        | AntiqueShops
        | Aquariums
        | ArchitecturalSurveyingServices
        | ArtDealersAndGalleries
        | ArtistsSupplyAndCraftShops
        | AutoAndHomeSupplyStores
        | AutoBodyRepairShops
        | AutoPaintShops
        | AutoServiceShops
        | AutomatedCashDisburse
        | AutomatedFuelDispensers
        | AutomobileAssociations
        | AutomotivePartsAndAccessoriesStores
        | AutomotiveTireStores
        | BailAndBondPayments
        | Bakeries
        | BandsOrchestras
        | BarberAndBeautyShops
        | BettingCasinoGambling
        | BicycleShops
        | BilliardPoolEstablishments
        | BoatDealers
        | BoatRentalsAndLeases
        | BookStores
        | BooksPeriodicalsAndNewspapers
        | BowlingAlleys
        | BusLines
        | BusinessSecretarialSchools
        | BuyingShoppingServices
        | CableSatelliteAndOtherPayTelevisionAndRadio
        | CameraAndPhotographicSupplyStores
        | CandyNutAndConfectioneryStores
        | CarAndTruckDealersNewUsed
        | CarAndTruckDealersUsedOnly
        | CarRentalAgencies
        | CarWashes
        | CarpentryServices
        | CarpetUpholsteryCleaning
        | Caterers
        | CharitableAndSocialServiceOrganizationsFundraising
        | ChemicalsAndAlliedProducts
        | ChildCareServices
        | ChildrensAndInfantsWearStores
        | ChiropodistsPodiatrists
        | Chiropractors
        | CigarStoresAndStands
        | CivicSocialFraternalAssociations
        | CleaningAndMaintenance
        | ClothingRental
        | CollegesUniversities
        | CommercialEquipment
        | CommercialFootwear
        | CommercialPhotographyArtAndGraphics
        | CommuterTransportAndFerries
        | ComputerNetworkServices
        | ComputerProgramming
        | ComputerRepair
        | ComputerSoftwareStores
        | ComputersPeripheralsAndSoftware
        | ConcreteWorkServices
        | ConstructionMaterials
        | ConsultingPublicRelations
        | CorrespondenceSchools
        | CosmeticStores
        | CounselingServices
        | CountryClubs
        | CourierServices
        | CourtCosts
        | CreditReportingAgencies
        | CruiseLines
        | DairyProductsStores
        | DanceHallStudiosSchools
        | DatingEscortServices
        | DentistsOrthodontists
        | DepartmentStores
        | DetectiveAgencies
        | DigitalGoodsApplications
        | DigitalGoodsGames
        | DigitalGoodsLargeVolume
        | DigitalGoodsMedia
        | DirectMarketingCatalogMerchant
        | DirectMarketingCombinationCatalogAndRetailMerchant
        | DirectMarketingInboundTelemarketing
        | DirectMarketingInsuranceServices
        | DirectMarketingOther
        | DirectMarketingOutboundTelemarketing
        | DirectMarketingSubscription
        | DirectMarketingTravel
        | DiscountStores
        | Doctors
        | DoorToDoorSales
        | DraperyWindowCoveringAndUpholsteryStores
        | DrinkingPlaces
        | DrugStoresAndPharmacies
        | DrugsDrugProprietariesAndDruggistSundries
        | DryCleaners
        | DurableGoods
        | DutyFreeStores
        | EatingPlacesRestaurants
        | EducationalServices
        | ElectricRazorStores
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
        | EmploymentTempAgencies
        | EquipmentRental
        | ExterminatingServices
        | FamilyClothingStores
        | FastFoodRestaurants
        | FinancialInstitutions
        | FinesGovernmentAdministrativeEntities
        | FireplaceFireplaceScreensAndAccessoriesStores
        | FloorCoveringStores
        | Florists
        | FloristsSuppliesNurseryStockAndFlowers
        | FreezerAndLockerMeatProvisioners
        | FuelDealersNonAutomotive
        | FuneralServicesCrematories
        | FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | FurnitureRepairRefinishing
        | FurriersAndFurShops
        | GeneralServices
        | GiftCardNoveltyAndSouvenirShops
        | GlassPaintAndWallpaperStores
        | GlasswareCrystalStores
        | GolfCoursesPublic
        | GovernmentServices
        | GroceryStoresSupermarkets
        | HardwareEquipmentAndSupplies
        | HardwareStores
        | HealthAndBeautySpas
        | HearingAidsSalesAndSupplies
        | HeatingPlumbingAC
        | HobbyToyAndGameShops
        | HomeSupplyWarehouseStores
        | Hospitals
        | HotelsMotelsAndResorts
        | HouseholdApplianceStores
        | IndustrialSupplies
        | InformationRetrievalServices
        | InsuranceDefault
        | InsuranceUnderwritingPremiums
        | IntraCompanyPurchases
        | JewelryStoresWatchesClocksAndSilverwareStores
        | LandscapingServices
        | Laundries
        | LaundryCleaningServices
        | LegalServicesAttorneys
        | LuggageAndLeatherGoodsStores
        | LumberBuildingMaterialsStores
        | ManualCashDisburse
        | MarinasServiceAndSupplies
        | MasonryStoneworkAndPlaster
        | MassageParlors
        | MedicalAndDentalLabs
        | MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | MedicalServices
        | MembershipOrganizations
        | MensAndBoysClothingAndAccessoriesStores
        | MensWomensClothingStores
        | MetalServiceCenters
        | Miscellaneous
        | MiscellaneousApparelAndAccessoryShops
        | MiscellaneousAutoDealers
        | MiscellaneousBusinessServices
        | MiscellaneousFoodStores
        | MiscellaneousGeneralMerchandise
        | MiscellaneousGeneralServices
        | MiscellaneousHomeFurnishingSpecialtyStores
        | MiscellaneousPublishingAndPrinting
        | MiscellaneousRecreationServices
        | MiscellaneousRepairShops
        | MiscellaneousSpecialtyRetail
        | MobileHomeDealers
        | MotionPictureTheaters
        | MotorFreightCarriersAndTrucking
        | MotorHomesDealers
        | MotorVehicleSuppliesAndNewParts
        | MotorcycleShopsAndDealers
        | MotorcycleShopsDealers
        | MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | NewsDealersAndNewsstands
        | NonFiMoneyOrders
        | NonFiStoredValueCardPurchaseLoad
        | NondurableGoods
        | NurseriesLawnAndGardenSupplyStores
        | NursingPersonalCare
        | OfficeAndCommercialFurniture
        | OpticiansEyeglasses
        | OptometristsOphthalmologist
        | OrthopedicGoodsProstheticDevices
        | Osteopaths
        | PackageStoresBeerWineAndLiquor
        | PaintsVarnishesAndSupplies
        | ParkingLotsGarages
        | PassengerRailways
        | PawnShops
        | PetShopsPetFoodAndSupplies
        | PetroleumAndPetroleumProducts
        | PhotoDeveloping
        | PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | PhotographicStudios
        | PictureVideoProduction
        | PieceGoodsNotionsAndOtherDryGoods
        | PlumbingHeatingEquipmentAndSupplies
        | PoliticalOrganizations
        | PostalServicesGovernmentOnly
        | PreciousStonesAndMetalsWatchesAndJewelry
        | ProfessionalServices
        | PublicWarehousingAndStorage
        | QuickCopyReproAndBlueprint
        | Railroads
        | RealEstateAgentsAndManagersRentals
        | RecordStores
        | RecreationalVehicleRentals
        | ReligiousGoodsStores
        | ReligiousOrganizations
        | RoofingSidingSheetMetal
        | SecretarialSupportServices
        | SecurityBrokersDealers
        | ServiceStations
        | SewingNeedleworkFabricAndPieceGoodsStores
        | ShoeRepairHatCleaning
        | ShoeStores
        | SmallApplianceRepair
        | SnowmobileDealers
        | SpecialTradeServices
        | SpecialtyCleaning
        | SportingGoodsStores
        | SportingRecreationCamps
        | SportsAndRidingApparelStores
        | SportsClubsFields
        | StampAndCoinStores
        | StationaryOfficeSuppliesPrintingAndWritingPaper
        | StationeryStoresOfficeAndSchoolSupplyStores
        | SwimmingPoolsSales
        | TUiTravelGermany
        | TailorsAlterations
        | TaxPaymentsGovernmentAgencies
        | TaxPreparationServices
        | TaxicabsLimousines
        | TelecommunicationEquipmentAndTelephoneSales
        | TelecommunicationServices
        | TelegraphServices
        | TentAndAwningShops
        | TestingLaboratories
        | TheatricalTicketAgencies
        | Timeshares
        | TireRetreadingAndRepair
        | TollsBridgeFees
        | TouristAttractionsAndExhibits
        | TowingServices
        | TrailerParksCampgrounds
        | TransportationServices
        | TravelAgenciesTourOperators
        | TruckStopIteration
        | TruckUtilityTrailerRentals
        | TypesettingPlateMakingAndRelatedServices
        | TypewriterStores
        | USFederalGovernmentAgenciesOrDepartments
        | UniformsCommercialClothing
        | UsedMerchandiseAndSecondhandStores
        | Utilities
        | VarietyStores
        | VeterinaryServices
        | VideoAmusementGameSupplies
        | VideoGameArcades
        | VideoTapeRentalStores
        | VocationalTradeSchools
        | WatchJewelryRepair
        | WeldingRepair
        | WholesaleClubs
        | WigAndToupeeStores
        | WiresMoneyOrders
        | WomensAccessoryAndSpecialtyShops
        | WomensReadyToWearStores
        | WreckingAndSalvageYards

    and IssuingCardAuthorizationControlsBlockedCategories =
        | AcRefrigerationRepair
        | AccountingBookkeepingServices
        | AdvertisingServices
        | AgriculturalCooperative
        | AirlinesAirCarriers
        | AirportsFlyingFields
        | AmbulanceServices
        | AmusementParksCarnivals
        | AntiqueReproductions
        | AntiqueShops
        | Aquariums
        | ArchitecturalSurveyingServices
        | ArtDealersAndGalleries
        | ArtistsSupplyAndCraftShops
        | AutoAndHomeSupplyStores
        | AutoBodyRepairShops
        | AutoPaintShops
        | AutoServiceShops
        | AutomatedCashDisburse
        | AutomatedFuelDispensers
        | AutomobileAssociations
        | AutomotivePartsAndAccessoriesStores
        | AutomotiveTireStores
        | BailAndBondPayments
        | Bakeries
        | BandsOrchestras
        | BarberAndBeautyShops
        | BettingCasinoGambling
        | BicycleShops
        | BilliardPoolEstablishments
        | BoatDealers
        | BoatRentalsAndLeases
        | BookStores
        | BooksPeriodicalsAndNewspapers
        | BowlingAlleys
        | BusLines
        | BusinessSecretarialSchools
        | BuyingShoppingServices
        | CableSatelliteAndOtherPayTelevisionAndRadio
        | CameraAndPhotographicSupplyStores
        | CandyNutAndConfectioneryStores
        | CarAndTruckDealersNewUsed
        | CarAndTruckDealersUsedOnly
        | CarRentalAgencies
        | CarWashes
        | CarpentryServices
        | CarpetUpholsteryCleaning
        | Caterers
        | CharitableAndSocialServiceOrganizationsFundraising
        | ChemicalsAndAlliedProducts
        | ChildCareServices
        | ChildrensAndInfantsWearStores
        | ChiropodistsPodiatrists
        | Chiropractors
        | CigarStoresAndStands
        | CivicSocialFraternalAssociations
        | CleaningAndMaintenance
        | ClothingRental
        | CollegesUniversities
        | CommercialEquipment
        | CommercialFootwear
        | CommercialPhotographyArtAndGraphics
        | CommuterTransportAndFerries
        | ComputerNetworkServices
        | ComputerProgramming
        | ComputerRepair
        | ComputerSoftwareStores
        | ComputersPeripheralsAndSoftware
        | ConcreteWorkServices
        | ConstructionMaterials
        | ConsultingPublicRelations
        | CorrespondenceSchools
        | CosmeticStores
        | CounselingServices
        | CountryClubs
        | CourierServices
        | CourtCosts
        | CreditReportingAgencies
        | CruiseLines
        | DairyProductsStores
        | DanceHallStudiosSchools
        | DatingEscortServices
        | DentistsOrthodontists
        | DepartmentStores
        | DetectiveAgencies
        | DigitalGoodsApplications
        | DigitalGoodsGames
        | DigitalGoodsLargeVolume
        | DigitalGoodsMedia
        | DirectMarketingCatalogMerchant
        | DirectMarketingCombinationCatalogAndRetailMerchant
        | DirectMarketingInboundTelemarketing
        | DirectMarketingInsuranceServices
        | DirectMarketingOther
        | DirectMarketingOutboundTelemarketing
        | DirectMarketingSubscription
        | DirectMarketingTravel
        | DiscountStores
        | Doctors
        | DoorToDoorSales
        | DraperyWindowCoveringAndUpholsteryStores
        | DrinkingPlaces
        | DrugStoresAndPharmacies
        | DrugsDrugProprietariesAndDruggistSundries
        | DryCleaners
        | DurableGoods
        | DutyFreeStores
        | EatingPlacesRestaurants
        | EducationalServices
        | ElectricRazorStores
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
        | EmploymentTempAgencies
        | EquipmentRental
        | ExterminatingServices
        | FamilyClothingStores
        | FastFoodRestaurants
        | FinancialInstitutions
        | FinesGovernmentAdministrativeEntities
        | FireplaceFireplaceScreensAndAccessoriesStores
        | FloorCoveringStores
        | Florists
        | FloristsSuppliesNurseryStockAndFlowers
        | FreezerAndLockerMeatProvisioners
        | FuelDealersNonAutomotive
        | FuneralServicesCrematories
        | FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | FurnitureRepairRefinishing
        | FurriersAndFurShops
        | GeneralServices
        | GiftCardNoveltyAndSouvenirShops
        | GlassPaintAndWallpaperStores
        | GlasswareCrystalStores
        | GolfCoursesPublic
        | GovernmentServices
        | GroceryStoresSupermarkets
        | HardwareEquipmentAndSupplies
        | HardwareStores
        | HealthAndBeautySpas
        | HearingAidsSalesAndSupplies
        | HeatingPlumbingAC
        | HobbyToyAndGameShops
        | HomeSupplyWarehouseStores
        | Hospitals
        | HotelsMotelsAndResorts
        | HouseholdApplianceStores
        | IndustrialSupplies
        | InformationRetrievalServices
        | InsuranceDefault
        | InsuranceUnderwritingPremiums
        | IntraCompanyPurchases
        | JewelryStoresWatchesClocksAndSilverwareStores
        | LandscapingServices
        | Laundries
        | LaundryCleaningServices
        | LegalServicesAttorneys
        | LuggageAndLeatherGoodsStores
        | LumberBuildingMaterialsStores
        | ManualCashDisburse
        | MarinasServiceAndSupplies
        | MasonryStoneworkAndPlaster
        | MassageParlors
        | MedicalAndDentalLabs
        | MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | MedicalServices
        | MembershipOrganizations
        | MensAndBoysClothingAndAccessoriesStores
        | MensWomensClothingStores
        | MetalServiceCenters
        | Miscellaneous
        | MiscellaneousApparelAndAccessoryShops
        | MiscellaneousAutoDealers
        | MiscellaneousBusinessServices
        | MiscellaneousFoodStores
        | MiscellaneousGeneralMerchandise
        | MiscellaneousGeneralServices
        | MiscellaneousHomeFurnishingSpecialtyStores
        | MiscellaneousPublishingAndPrinting
        | MiscellaneousRecreationServices
        | MiscellaneousRepairShops
        | MiscellaneousSpecialtyRetail
        | MobileHomeDealers
        | MotionPictureTheaters
        | MotorFreightCarriersAndTrucking
        | MotorHomesDealers
        | MotorVehicleSuppliesAndNewParts
        | MotorcycleShopsAndDealers
        | MotorcycleShopsDealers
        | MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | NewsDealersAndNewsstands
        | NonFiMoneyOrders
        | NonFiStoredValueCardPurchaseLoad
        | NondurableGoods
        | NurseriesLawnAndGardenSupplyStores
        | NursingPersonalCare
        | OfficeAndCommercialFurniture
        | OpticiansEyeglasses
        | OptometristsOphthalmologist
        | OrthopedicGoodsProstheticDevices
        | Osteopaths
        | PackageStoresBeerWineAndLiquor
        | PaintsVarnishesAndSupplies
        | ParkingLotsGarages
        | PassengerRailways
        | PawnShops
        | PetShopsPetFoodAndSupplies
        | PetroleumAndPetroleumProducts
        | PhotoDeveloping
        | PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | PhotographicStudios
        | PictureVideoProduction
        | PieceGoodsNotionsAndOtherDryGoods
        | PlumbingHeatingEquipmentAndSupplies
        | PoliticalOrganizations
        | PostalServicesGovernmentOnly
        | PreciousStonesAndMetalsWatchesAndJewelry
        | ProfessionalServices
        | PublicWarehousingAndStorage
        | QuickCopyReproAndBlueprint
        | Railroads
        | RealEstateAgentsAndManagersRentals
        | RecordStores
        | RecreationalVehicleRentals
        | ReligiousGoodsStores
        | ReligiousOrganizations
        | RoofingSidingSheetMetal
        | SecretarialSupportServices
        | SecurityBrokersDealers
        | ServiceStations
        | SewingNeedleworkFabricAndPieceGoodsStores
        | ShoeRepairHatCleaning
        | ShoeStores
        | SmallApplianceRepair
        | SnowmobileDealers
        | SpecialTradeServices
        | SpecialtyCleaning
        | SportingGoodsStores
        | SportingRecreationCamps
        | SportsAndRidingApparelStores
        | SportsClubsFields
        | StampAndCoinStores
        | StationaryOfficeSuppliesPrintingAndWritingPaper
        | StationeryStoresOfficeAndSchoolSupplyStores
        | SwimmingPoolsSales
        | TUiTravelGermany
        | TailorsAlterations
        | TaxPaymentsGovernmentAgencies
        | TaxPreparationServices
        | TaxicabsLimousines
        | TelecommunicationEquipmentAndTelephoneSales
        | TelecommunicationServices
        | TelegraphServices
        | TentAndAwningShops
        | TestingLaboratories
        | TheatricalTicketAgencies
        | Timeshares
        | TireRetreadingAndRepair
        | TollsBridgeFees
        | TouristAttractionsAndExhibits
        | TowingServices
        | TrailerParksCampgrounds
        | TransportationServices
        | TravelAgenciesTourOperators
        | TruckStopIteration
        | TruckUtilityTrailerRentals
        | TypesettingPlateMakingAndRelatedServices
        | TypewriterStores
        | USFederalGovernmentAgenciesOrDepartments
        | UniformsCommercialClothing
        | UsedMerchandiseAndSecondhandStores
        | Utilities
        | VarietyStores
        | VeterinaryServices
        | VideoAmusementGameSupplies
        | VideoGameArcades
        | VideoTapeRentalStores
        | VocationalTradeSchools
        | WatchJewelryRepair
        | WeldingRepair
        | WholesaleClubs
        | WigAndToupeeStores
        | WiresMoneyOrders
        | WomensAccessoryAndSpecialtyShops
        | WomensReadyToWearStores
        | WreckingAndSalvageYards

    ///
    and IssuingCardShipping =
        {
            Address: Address
            Carrier: IssuingCardShippingCarrier option
            Eta: int64 option
            Name: string
            Service: IssuingCardShippingService
            Status: IssuingCardShippingStatus option
            TrackingNumber: string option
            TrackingUrl: string option
            Type: IssuingCardShippingType
        }

    and IssuingCardShippingCarrier =
        | Fedex
        | Usps

    and IssuingCardShippingService =
        | Express
        | Priority
        | Standard

    and IssuingCardShippingStatus =
        | Canceled
        | Delivered
        | Failure
        | Pending
        | Returned
        | Shipped

    and IssuingCardShippingType =
        | Bulk
        | Individual

    ///
    and IssuingCardSpendingLimit =
        {
            Amount: int64
            Categories: IssuingCardSpendingLimitCategories list option
            Interval: IssuingCardSpendingLimitInterval
        }

    and IssuingCardSpendingLimitCategories =
        | AcRefrigerationRepair
        | AccountingBookkeepingServices
        | AdvertisingServices
        | AgriculturalCooperative
        | AirlinesAirCarriers
        | AirportsFlyingFields
        | AmbulanceServices
        | AmusementParksCarnivals
        | AntiqueReproductions
        | AntiqueShops
        | Aquariums
        | ArchitecturalSurveyingServices
        | ArtDealersAndGalleries
        | ArtistsSupplyAndCraftShops
        | AutoAndHomeSupplyStores
        | AutoBodyRepairShops
        | AutoPaintShops
        | AutoServiceShops
        | AutomatedCashDisburse
        | AutomatedFuelDispensers
        | AutomobileAssociations
        | AutomotivePartsAndAccessoriesStores
        | AutomotiveTireStores
        | BailAndBondPayments
        | Bakeries
        | BandsOrchestras
        | BarberAndBeautyShops
        | BettingCasinoGambling
        | BicycleShops
        | BilliardPoolEstablishments
        | BoatDealers
        | BoatRentalsAndLeases
        | BookStores
        | BooksPeriodicalsAndNewspapers
        | BowlingAlleys
        | BusLines
        | BusinessSecretarialSchools
        | BuyingShoppingServices
        | CableSatelliteAndOtherPayTelevisionAndRadio
        | CameraAndPhotographicSupplyStores
        | CandyNutAndConfectioneryStores
        | CarAndTruckDealersNewUsed
        | CarAndTruckDealersUsedOnly
        | CarRentalAgencies
        | CarWashes
        | CarpentryServices
        | CarpetUpholsteryCleaning
        | Caterers
        | CharitableAndSocialServiceOrganizationsFundraising
        | ChemicalsAndAlliedProducts
        | ChildCareServices
        | ChildrensAndInfantsWearStores
        | ChiropodistsPodiatrists
        | Chiropractors
        | CigarStoresAndStands
        | CivicSocialFraternalAssociations
        | CleaningAndMaintenance
        | ClothingRental
        | CollegesUniversities
        | CommercialEquipment
        | CommercialFootwear
        | CommercialPhotographyArtAndGraphics
        | CommuterTransportAndFerries
        | ComputerNetworkServices
        | ComputerProgramming
        | ComputerRepair
        | ComputerSoftwareStores
        | ComputersPeripheralsAndSoftware
        | ConcreteWorkServices
        | ConstructionMaterials
        | ConsultingPublicRelations
        | CorrespondenceSchools
        | CosmeticStores
        | CounselingServices
        | CountryClubs
        | CourierServices
        | CourtCosts
        | CreditReportingAgencies
        | CruiseLines
        | DairyProductsStores
        | DanceHallStudiosSchools
        | DatingEscortServices
        | DentistsOrthodontists
        | DepartmentStores
        | DetectiveAgencies
        | DigitalGoodsApplications
        | DigitalGoodsGames
        | DigitalGoodsLargeVolume
        | DigitalGoodsMedia
        | DirectMarketingCatalogMerchant
        | DirectMarketingCombinationCatalogAndRetailMerchant
        | DirectMarketingInboundTelemarketing
        | DirectMarketingInsuranceServices
        | DirectMarketingOther
        | DirectMarketingOutboundTelemarketing
        | DirectMarketingSubscription
        | DirectMarketingTravel
        | DiscountStores
        | Doctors
        | DoorToDoorSales
        | DraperyWindowCoveringAndUpholsteryStores
        | DrinkingPlaces
        | DrugStoresAndPharmacies
        | DrugsDrugProprietariesAndDruggistSundries
        | DryCleaners
        | DurableGoods
        | DutyFreeStores
        | EatingPlacesRestaurants
        | EducationalServices
        | ElectricRazorStores
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
        | EmploymentTempAgencies
        | EquipmentRental
        | ExterminatingServices
        | FamilyClothingStores
        | FastFoodRestaurants
        | FinancialInstitutions
        | FinesGovernmentAdministrativeEntities
        | FireplaceFireplaceScreensAndAccessoriesStores
        | FloorCoveringStores
        | Florists
        | FloristsSuppliesNurseryStockAndFlowers
        | FreezerAndLockerMeatProvisioners
        | FuelDealersNonAutomotive
        | FuneralServicesCrematories
        | FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | FurnitureRepairRefinishing
        | FurriersAndFurShops
        | GeneralServices
        | GiftCardNoveltyAndSouvenirShops
        | GlassPaintAndWallpaperStores
        | GlasswareCrystalStores
        | GolfCoursesPublic
        | GovernmentServices
        | GroceryStoresSupermarkets
        | HardwareEquipmentAndSupplies
        | HardwareStores
        | HealthAndBeautySpas
        | HearingAidsSalesAndSupplies
        | HeatingPlumbingAC
        | HobbyToyAndGameShops
        | HomeSupplyWarehouseStores
        | Hospitals
        | HotelsMotelsAndResorts
        | HouseholdApplianceStores
        | IndustrialSupplies
        | InformationRetrievalServices
        | InsuranceDefault
        | InsuranceUnderwritingPremiums
        | IntraCompanyPurchases
        | JewelryStoresWatchesClocksAndSilverwareStores
        | LandscapingServices
        | Laundries
        | LaundryCleaningServices
        | LegalServicesAttorneys
        | LuggageAndLeatherGoodsStores
        | LumberBuildingMaterialsStores
        | ManualCashDisburse
        | MarinasServiceAndSupplies
        | MasonryStoneworkAndPlaster
        | MassageParlors
        | MedicalAndDentalLabs
        | MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | MedicalServices
        | MembershipOrganizations
        | MensAndBoysClothingAndAccessoriesStores
        | MensWomensClothingStores
        | MetalServiceCenters
        | Miscellaneous
        | MiscellaneousApparelAndAccessoryShops
        | MiscellaneousAutoDealers
        | MiscellaneousBusinessServices
        | MiscellaneousFoodStores
        | MiscellaneousGeneralMerchandise
        | MiscellaneousGeneralServices
        | MiscellaneousHomeFurnishingSpecialtyStores
        | MiscellaneousPublishingAndPrinting
        | MiscellaneousRecreationServices
        | MiscellaneousRepairShops
        | MiscellaneousSpecialtyRetail
        | MobileHomeDealers
        | MotionPictureTheaters
        | MotorFreightCarriersAndTrucking
        | MotorHomesDealers
        | MotorVehicleSuppliesAndNewParts
        | MotorcycleShopsAndDealers
        | MotorcycleShopsDealers
        | MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | NewsDealersAndNewsstands
        | NonFiMoneyOrders
        | NonFiStoredValueCardPurchaseLoad
        | NondurableGoods
        | NurseriesLawnAndGardenSupplyStores
        | NursingPersonalCare
        | OfficeAndCommercialFurniture
        | OpticiansEyeglasses
        | OptometristsOphthalmologist
        | OrthopedicGoodsProstheticDevices
        | Osteopaths
        | PackageStoresBeerWineAndLiquor
        | PaintsVarnishesAndSupplies
        | ParkingLotsGarages
        | PassengerRailways
        | PawnShops
        | PetShopsPetFoodAndSupplies
        | PetroleumAndPetroleumProducts
        | PhotoDeveloping
        | PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | PhotographicStudios
        | PictureVideoProduction
        | PieceGoodsNotionsAndOtherDryGoods
        | PlumbingHeatingEquipmentAndSupplies
        | PoliticalOrganizations
        | PostalServicesGovernmentOnly
        | PreciousStonesAndMetalsWatchesAndJewelry
        | ProfessionalServices
        | PublicWarehousingAndStorage
        | QuickCopyReproAndBlueprint
        | Railroads
        | RealEstateAgentsAndManagersRentals
        | RecordStores
        | RecreationalVehicleRentals
        | ReligiousGoodsStores
        | ReligiousOrganizations
        | RoofingSidingSheetMetal
        | SecretarialSupportServices
        | SecurityBrokersDealers
        | ServiceStations
        | SewingNeedleworkFabricAndPieceGoodsStores
        | ShoeRepairHatCleaning
        | ShoeStores
        | SmallApplianceRepair
        | SnowmobileDealers
        | SpecialTradeServices
        | SpecialtyCleaning
        | SportingGoodsStores
        | SportingRecreationCamps
        | SportsAndRidingApparelStores
        | SportsClubsFields
        | StampAndCoinStores
        | StationaryOfficeSuppliesPrintingAndWritingPaper
        | StationeryStoresOfficeAndSchoolSupplyStores
        | SwimmingPoolsSales
        | TUiTravelGermany
        | TailorsAlterations
        | TaxPaymentsGovernmentAgencies
        | TaxPreparationServices
        | TaxicabsLimousines
        | TelecommunicationEquipmentAndTelephoneSales
        | TelecommunicationServices
        | TelegraphServices
        | TentAndAwningShops
        | TestingLaboratories
        | TheatricalTicketAgencies
        | Timeshares
        | TireRetreadingAndRepair
        | TollsBridgeFees
        | TouristAttractionsAndExhibits
        | TowingServices
        | TrailerParksCampgrounds
        | TransportationServices
        | TravelAgenciesTourOperators
        | TruckStopIteration
        | TruckUtilityTrailerRentals
        | TypesettingPlateMakingAndRelatedServices
        | TypewriterStores
        | USFederalGovernmentAgenciesOrDepartments
        | UniformsCommercialClothing
        | UsedMerchandiseAndSecondhandStores
        | Utilities
        | VarietyStores
        | VeterinaryServices
        | VideoAmusementGameSupplies
        | VideoGameArcades
        | VideoTapeRentalStores
        | VocationalTradeSchools
        | WatchJewelryRepair
        | WeldingRepair
        | WholesaleClubs
        | WigAndToupeeStores
        | WiresMoneyOrders
        | WomensAccessoryAndSpecialtyShops
        | WomensReadyToWearStores
        | WreckingAndSalvageYards

    and IssuingCardSpendingLimitInterval =
        | AllTime
        | Daily
        | Monthly
        | PerAuthorization
        | Weekly
        | Yearly

    ///
    and IssuingCardholderAddress =
        {
            Address: Address
        }

    ///
    and IssuingCardholderAuthorizationControls =
        {
            AllowedCategories: IssuingCardholderAuthorizationControlsAllowedCategories list option
            BlockedCategories: IssuingCardholderAuthorizationControlsBlockedCategories list option
            SpendingLimits: IssuingCardholderSpendingLimit list option
            SpendingLimitsCurrency: string option
        }

    and IssuingCardholderAuthorizationControlsAllowedCategories =
        | AcRefrigerationRepair
        | AccountingBookkeepingServices
        | AdvertisingServices
        | AgriculturalCooperative
        | AirlinesAirCarriers
        | AirportsFlyingFields
        | AmbulanceServices
        | AmusementParksCarnivals
        | AntiqueReproductions
        | AntiqueShops
        | Aquariums
        | ArchitecturalSurveyingServices
        | ArtDealersAndGalleries
        | ArtistsSupplyAndCraftShops
        | AutoAndHomeSupplyStores
        | AutoBodyRepairShops
        | AutoPaintShops
        | AutoServiceShops
        | AutomatedCashDisburse
        | AutomatedFuelDispensers
        | AutomobileAssociations
        | AutomotivePartsAndAccessoriesStores
        | AutomotiveTireStores
        | BailAndBondPayments
        | Bakeries
        | BandsOrchestras
        | BarberAndBeautyShops
        | BettingCasinoGambling
        | BicycleShops
        | BilliardPoolEstablishments
        | BoatDealers
        | BoatRentalsAndLeases
        | BookStores
        | BooksPeriodicalsAndNewspapers
        | BowlingAlleys
        | BusLines
        | BusinessSecretarialSchools
        | BuyingShoppingServices
        | CableSatelliteAndOtherPayTelevisionAndRadio
        | CameraAndPhotographicSupplyStores
        | CandyNutAndConfectioneryStores
        | CarAndTruckDealersNewUsed
        | CarAndTruckDealersUsedOnly
        | CarRentalAgencies
        | CarWashes
        | CarpentryServices
        | CarpetUpholsteryCleaning
        | Caterers
        | CharitableAndSocialServiceOrganizationsFundraising
        | ChemicalsAndAlliedProducts
        | ChildCareServices
        | ChildrensAndInfantsWearStores
        | ChiropodistsPodiatrists
        | Chiropractors
        | CigarStoresAndStands
        | CivicSocialFraternalAssociations
        | CleaningAndMaintenance
        | ClothingRental
        | CollegesUniversities
        | CommercialEquipment
        | CommercialFootwear
        | CommercialPhotographyArtAndGraphics
        | CommuterTransportAndFerries
        | ComputerNetworkServices
        | ComputerProgramming
        | ComputerRepair
        | ComputerSoftwareStores
        | ComputersPeripheralsAndSoftware
        | ConcreteWorkServices
        | ConstructionMaterials
        | ConsultingPublicRelations
        | CorrespondenceSchools
        | CosmeticStores
        | CounselingServices
        | CountryClubs
        | CourierServices
        | CourtCosts
        | CreditReportingAgencies
        | CruiseLines
        | DairyProductsStores
        | DanceHallStudiosSchools
        | DatingEscortServices
        | DentistsOrthodontists
        | DepartmentStores
        | DetectiveAgencies
        | DigitalGoodsApplications
        | DigitalGoodsGames
        | DigitalGoodsLargeVolume
        | DigitalGoodsMedia
        | DirectMarketingCatalogMerchant
        | DirectMarketingCombinationCatalogAndRetailMerchant
        | DirectMarketingInboundTelemarketing
        | DirectMarketingInsuranceServices
        | DirectMarketingOther
        | DirectMarketingOutboundTelemarketing
        | DirectMarketingSubscription
        | DirectMarketingTravel
        | DiscountStores
        | Doctors
        | DoorToDoorSales
        | DraperyWindowCoveringAndUpholsteryStores
        | DrinkingPlaces
        | DrugStoresAndPharmacies
        | DrugsDrugProprietariesAndDruggistSundries
        | DryCleaners
        | DurableGoods
        | DutyFreeStores
        | EatingPlacesRestaurants
        | EducationalServices
        | ElectricRazorStores
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
        | EmploymentTempAgencies
        | EquipmentRental
        | ExterminatingServices
        | FamilyClothingStores
        | FastFoodRestaurants
        | FinancialInstitutions
        | FinesGovernmentAdministrativeEntities
        | FireplaceFireplaceScreensAndAccessoriesStores
        | FloorCoveringStores
        | Florists
        | FloristsSuppliesNurseryStockAndFlowers
        | FreezerAndLockerMeatProvisioners
        | FuelDealersNonAutomotive
        | FuneralServicesCrematories
        | FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | FurnitureRepairRefinishing
        | FurriersAndFurShops
        | GeneralServices
        | GiftCardNoveltyAndSouvenirShops
        | GlassPaintAndWallpaperStores
        | GlasswareCrystalStores
        | GolfCoursesPublic
        | GovernmentServices
        | GroceryStoresSupermarkets
        | HardwareEquipmentAndSupplies
        | HardwareStores
        | HealthAndBeautySpas
        | HearingAidsSalesAndSupplies
        | HeatingPlumbingAC
        | HobbyToyAndGameShops
        | HomeSupplyWarehouseStores
        | Hospitals
        | HotelsMotelsAndResorts
        | HouseholdApplianceStores
        | IndustrialSupplies
        | InformationRetrievalServices
        | InsuranceDefault
        | InsuranceUnderwritingPremiums
        | IntraCompanyPurchases
        | JewelryStoresWatchesClocksAndSilverwareStores
        | LandscapingServices
        | Laundries
        | LaundryCleaningServices
        | LegalServicesAttorneys
        | LuggageAndLeatherGoodsStores
        | LumberBuildingMaterialsStores
        | ManualCashDisburse
        | MarinasServiceAndSupplies
        | MasonryStoneworkAndPlaster
        | MassageParlors
        | MedicalAndDentalLabs
        | MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | MedicalServices
        | MembershipOrganizations
        | MensAndBoysClothingAndAccessoriesStores
        | MensWomensClothingStores
        | MetalServiceCenters
        | Miscellaneous
        | MiscellaneousApparelAndAccessoryShops
        | MiscellaneousAutoDealers
        | MiscellaneousBusinessServices
        | MiscellaneousFoodStores
        | MiscellaneousGeneralMerchandise
        | MiscellaneousGeneralServices
        | MiscellaneousHomeFurnishingSpecialtyStores
        | MiscellaneousPublishingAndPrinting
        | MiscellaneousRecreationServices
        | MiscellaneousRepairShops
        | MiscellaneousSpecialtyRetail
        | MobileHomeDealers
        | MotionPictureTheaters
        | MotorFreightCarriersAndTrucking
        | MotorHomesDealers
        | MotorVehicleSuppliesAndNewParts
        | MotorcycleShopsAndDealers
        | MotorcycleShopsDealers
        | MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | NewsDealersAndNewsstands
        | NonFiMoneyOrders
        | NonFiStoredValueCardPurchaseLoad
        | NondurableGoods
        | NurseriesLawnAndGardenSupplyStores
        | NursingPersonalCare
        | OfficeAndCommercialFurniture
        | OpticiansEyeglasses
        | OptometristsOphthalmologist
        | OrthopedicGoodsProstheticDevices
        | Osteopaths
        | PackageStoresBeerWineAndLiquor
        | PaintsVarnishesAndSupplies
        | ParkingLotsGarages
        | PassengerRailways
        | PawnShops
        | PetShopsPetFoodAndSupplies
        | PetroleumAndPetroleumProducts
        | PhotoDeveloping
        | PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | PhotographicStudios
        | PictureVideoProduction
        | PieceGoodsNotionsAndOtherDryGoods
        | PlumbingHeatingEquipmentAndSupplies
        | PoliticalOrganizations
        | PostalServicesGovernmentOnly
        | PreciousStonesAndMetalsWatchesAndJewelry
        | ProfessionalServices
        | PublicWarehousingAndStorage
        | QuickCopyReproAndBlueprint
        | Railroads
        | RealEstateAgentsAndManagersRentals
        | RecordStores
        | RecreationalVehicleRentals
        | ReligiousGoodsStores
        | ReligiousOrganizations
        | RoofingSidingSheetMetal
        | SecretarialSupportServices
        | SecurityBrokersDealers
        | ServiceStations
        | SewingNeedleworkFabricAndPieceGoodsStores
        | ShoeRepairHatCleaning
        | ShoeStores
        | SmallApplianceRepair
        | SnowmobileDealers
        | SpecialTradeServices
        | SpecialtyCleaning
        | SportingGoodsStores
        | SportingRecreationCamps
        | SportsAndRidingApparelStores
        | SportsClubsFields
        | StampAndCoinStores
        | StationaryOfficeSuppliesPrintingAndWritingPaper
        | StationeryStoresOfficeAndSchoolSupplyStores
        | SwimmingPoolsSales
        | TUiTravelGermany
        | TailorsAlterations
        | TaxPaymentsGovernmentAgencies
        | TaxPreparationServices
        | TaxicabsLimousines
        | TelecommunicationEquipmentAndTelephoneSales
        | TelecommunicationServices
        | TelegraphServices
        | TentAndAwningShops
        | TestingLaboratories
        | TheatricalTicketAgencies
        | Timeshares
        | TireRetreadingAndRepair
        | TollsBridgeFees
        | TouristAttractionsAndExhibits
        | TowingServices
        | TrailerParksCampgrounds
        | TransportationServices
        | TravelAgenciesTourOperators
        | TruckStopIteration
        | TruckUtilityTrailerRentals
        | TypesettingPlateMakingAndRelatedServices
        | TypewriterStores
        | USFederalGovernmentAgenciesOrDepartments
        | UniformsCommercialClothing
        | UsedMerchandiseAndSecondhandStores
        | Utilities
        | VarietyStores
        | VeterinaryServices
        | VideoAmusementGameSupplies
        | VideoGameArcades
        | VideoTapeRentalStores
        | VocationalTradeSchools
        | WatchJewelryRepair
        | WeldingRepair
        | WholesaleClubs
        | WigAndToupeeStores
        | WiresMoneyOrders
        | WomensAccessoryAndSpecialtyShops
        | WomensReadyToWearStores
        | WreckingAndSalvageYards

    and IssuingCardholderAuthorizationControlsBlockedCategories =
        | AcRefrigerationRepair
        | AccountingBookkeepingServices
        | AdvertisingServices
        | AgriculturalCooperative
        | AirlinesAirCarriers
        | AirportsFlyingFields
        | AmbulanceServices
        | AmusementParksCarnivals
        | AntiqueReproductions
        | AntiqueShops
        | Aquariums
        | ArchitecturalSurveyingServices
        | ArtDealersAndGalleries
        | ArtistsSupplyAndCraftShops
        | AutoAndHomeSupplyStores
        | AutoBodyRepairShops
        | AutoPaintShops
        | AutoServiceShops
        | AutomatedCashDisburse
        | AutomatedFuelDispensers
        | AutomobileAssociations
        | AutomotivePartsAndAccessoriesStores
        | AutomotiveTireStores
        | BailAndBondPayments
        | Bakeries
        | BandsOrchestras
        | BarberAndBeautyShops
        | BettingCasinoGambling
        | BicycleShops
        | BilliardPoolEstablishments
        | BoatDealers
        | BoatRentalsAndLeases
        | BookStores
        | BooksPeriodicalsAndNewspapers
        | BowlingAlleys
        | BusLines
        | BusinessSecretarialSchools
        | BuyingShoppingServices
        | CableSatelliteAndOtherPayTelevisionAndRadio
        | CameraAndPhotographicSupplyStores
        | CandyNutAndConfectioneryStores
        | CarAndTruckDealersNewUsed
        | CarAndTruckDealersUsedOnly
        | CarRentalAgencies
        | CarWashes
        | CarpentryServices
        | CarpetUpholsteryCleaning
        | Caterers
        | CharitableAndSocialServiceOrganizationsFundraising
        | ChemicalsAndAlliedProducts
        | ChildCareServices
        | ChildrensAndInfantsWearStores
        | ChiropodistsPodiatrists
        | Chiropractors
        | CigarStoresAndStands
        | CivicSocialFraternalAssociations
        | CleaningAndMaintenance
        | ClothingRental
        | CollegesUniversities
        | CommercialEquipment
        | CommercialFootwear
        | CommercialPhotographyArtAndGraphics
        | CommuterTransportAndFerries
        | ComputerNetworkServices
        | ComputerProgramming
        | ComputerRepair
        | ComputerSoftwareStores
        | ComputersPeripheralsAndSoftware
        | ConcreteWorkServices
        | ConstructionMaterials
        | ConsultingPublicRelations
        | CorrespondenceSchools
        | CosmeticStores
        | CounselingServices
        | CountryClubs
        | CourierServices
        | CourtCosts
        | CreditReportingAgencies
        | CruiseLines
        | DairyProductsStores
        | DanceHallStudiosSchools
        | DatingEscortServices
        | DentistsOrthodontists
        | DepartmentStores
        | DetectiveAgencies
        | DigitalGoodsApplications
        | DigitalGoodsGames
        | DigitalGoodsLargeVolume
        | DigitalGoodsMedia
        | DirectMarketingCatalogMerchant
        | DirectMarketingCombinationCatalogAndRetailMerchant
        | DirectMarketingInboundTelemarketing
        | DirectMarketingInsuranceServices
        | DirectMarketingOther
        | DirectMarketingOutboundTelemarketing
        | DirectMarketingSubscription
        | DirectMarketingTravel
        | DiscountStores
        | Doctors
        | DoorToDoorSales
        | DraperyWindowCoveringAndUpholsteryStores
        | DrinkingPlaces
        | DrugStoresAndPharmacies
        | DrugsDrugProprietariesAndDruggistSundries
        | DryCleaners
        | DurableGoods
        | DutyFreeStores
        | EatingPlacesRestaurants
        | EducationalServices
        | ElectricRazorStores
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
        | EmploymentTempAgencies
        | EquipmentRental
        | ExterminatingServices
        | FamilyClothingStores
        | FastFoodRestaurants
        | FinancialInstitutions
        | FinesGovernmentAdministrativeEntities
        | FireplaceFireplaceScreensAndAccessoriesStores
        | FloorCoveringStores
        | Florists
        | FloristsSuppliesNurseryStockAndFlowers
        | FreezerAndLockerMeatProvisioners
        | FuelDealersNonAutomotive
        | FuneralServicesCrematories
        | FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | FurnitureRepairRefinishing
        | FurriersAndFurShops
        | GeneralServices
        | GiftCardNoveltyAndSouvenirShops
        | GlassPaintAndWallpaperStores
        | GlasswareCrystalStores
        | GolfCoursesPublic
        | GovernmentServices
        | GroceryStoresSupermarkets
        | HardwareEquipmentAndSupplies
        | HardwareStores
        | HealthAndBeautySpas
        | HearingAidsSalesAndSupplies
        | HeatingPlumbingAC
        | HobbyToyAndGameShops
        | HomeSupplyWarehouseStores
        | Hospitals
        | HotelsMotelsAndResorts
        | HouseholdApplianceStores
        | IndustrialSupplies
        | InformationRetrievalServices
        | InsuranceDefault
        | InsuranceUnderwritingPremiums
        | IntraCompanyPurchases
        | JewelryStoresWatchesClocksAndSilverwareStores
        | LandscapingServices
        | Laundries
        | LaundryCleaningServices
        | LegalServicesAttorneys
        | LuggageAndLeatherGoodsStores
        | LumberBuildingMaterialsStores
        | ManualCashDisburse
        | MarinasServiceAndSupplies
        | MasonryStoneworkAndPlaster
        | MassageParlors
        | MedicalAndDentalLabs
        | MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | MedicalServices
        | MembershipOrganizations
        | MensAndBoysClothingAndAccessoriesStores
        | MensWomensClothingStores
        | MetalServiceCenters
        | Miscellaneous
        | MiscellaneousApparelAndAccessoryShops
        | MiscellaneousAutoDealers
        | MiscellaneousBusinessServices
        | MiscellaneousFoodStores
        | MiscellaneousGeneralMerchandise
        | MiscellaneousGeneralServices
        | MiscellaneousHomeFurnishingSpecialtyStores
        | MiscellaneousPublishingAndPrinting
        | MiscellaneousRecreationServices
        | MiscellaneousRepairShops
        | MiscellaneousSpecialtyRetail
        | MobileHomeDealers
        | MotionPictureTheaters
        | MotorFreightCarriersAndTrucking
        | MotorHomesDealers
        | MotorVehicleSuppliesAndNewParts
        | MotorcycleShopsAndDealers
        | MotorcycleShopsDealers
        | MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | NewsDealersAndNewsstands
        | NonFiMoneyOrders
        | NonFiStoredValueCardPurchaseLoad
        | NondurableGoods
        | NurseriesLawnAndGardenSupplyStores
        | NursingPersonalCare
        | OfficeAndCommercialFurniture
        | OpticiansEyeglasses
        | OptometristsOphthalmologist
        | OrthopedicGoodsProstheticDevices
        | Osteopaths
        | PackageStoresBeerWineAndLiquor
        | PaintsVarnishesAndSupplies
        | ParkingLotsGarages
        | PassengerRailways
        | PawnShops
        | PetShopsPetFoodAndSupplies
        | PetroleumAndPetroleumProducts
        | PhotoDeveloping
        | PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | PhotographicStudios
        | PictureVideoProduction
        | PieceGoodsNotionsAndOtherDryGoods
        | PlumbingHeatingEquipmentAndSupplies
        | PoliticalOrganizations
        | PostalServicesGovernmentOnly
        | PreciousStonesAndMetalsWatchesAndJewelry
        | ProfessionalServices
        | PublicWarehousingAndStorage
        | QuickCopyReproAndBlueprint
        | Railroads
        | RealEstateAgentsAndManagersRentals
        | RecordStores
        | RecreationalVehicleRentals
        | ReligiousGoodsStores
        | ReligiousOrganizations
        | RoofingSidingSheetMetal
        | SecretarialSupportServices
        | SecurityBrokersDealers
        | ServiceStations
        | SewingNeedleworkFabricAndPieceGoodsStores
        | ShoeRepairHatCleaning
        | ShoeStores
        | SmallApplianceRepair
        | SnowmobileDealers
        | SpecialTradeServices
        | SpecialtyCleaning
        | SportingGoodsStores
        | SportingRecreationCamps
        | SportsAndRidingApparelStores
        | SportsClubsFields
        | StampAndCoinStores
        | StationaryOfficeSuppliesPrintingAndWritingPaper
        | StationeryStoresOfficeAndSchoolSupplyStores
        | SwimmingPoolsSales
        | TUiTravelGermany
        | TailorsAlterations
        | TaxPaymentsGovernmentAgencies
        | TaxPreparationServices
        | TaxicabsLimousines
        | TelecommunicationEquipmentAndTelephoneSales
        | TelecommunicationServices
        | TelegraphServices
        | TentAndAwningShops
        | TestingLaboratories
        | TheatricalTicketAgencies
        | Timeshares
        | TireRetreadingAndRepair
        | TollsBridgeFees
        | TouristAttractionsAndExhibits
        | TowingServices
        | TrailerParksCampgrounds
        | TransportationServices
        | TravelAgenciesTourOperators
        | TruckStopIteration
        | TruckUtilityTrailerRentals
        | TypesettingPlateMakingAndRelatedServices
        | TypewriterStores
        | USFederalGovernmentAgenciesOrDepartments
        | UniformsCommercialClothing
        | UsedMerchandiseAndSecondhandStores
        | Utilities
        | VarietyStores
        | VeterinaryServices
        | VideoAmusementGameSupplies
        | VideoGameArcades
        | VideoTapeRentalStores
        | VocationalTradeSchools
        | WatchJewelryRepair
        | WeldingRepair
        | WholesaleClubs
        | WigAndToupeeStores
        | WiresMoneyOrders
        | WomensAccessoryAndSpecialtyShops
        | WomensReadyToWearStores
        | WreckingAndSalvageYards

    ///
    and IssuingCardholderCompany =
        {
            TaxIdProvided: bool
        }

    ///
    and IssuingCardholderIdDocument =
        {
            Back: string option
            Front: string option
        }

    ///
    and IssuingCardholderIndividual =
        {
            Dob: IssuingCardholderIndividualDob option
            FirstName: string
            LastName: string
            Verification: IssuingCardholderVerification option
        }

    ///
    and IssuingCardholderIndividualDob =
        {
            Day: int64 option
            Month: int64 option
            Year: int64 option
        }

    ///
    and IssuingCardholderRequirements =
        {
            DisabledReason: IssuingCardholderRequirementsDisabledReason option
            PastDue: IssuingCardholderRequirementsPastDue list option
        }

    and IssuingCardholderRequirementsDisabledReason =
        | Listed
        | RejectedListed
        | UnderReview

    and IssuingCardholderRequirementsPastDue =
        | CompanyTaxId
        | IndividualDobDay
        | IndividualDobMonth
        | IndividualDobYear
        | IndividualFirstName
        | IndividualLastName
        | IndividualVerificationDocument

    ///
    and IssuingCardholderSpendingLimit =
        {
            Amount: int64
            Categories: IssuingCardholderSpendingLimitCategories list option
            Interval: IssuingCardholderSpendingLimitInterval
        }

    and IssuingCardholderSpendingLimitCategories =
        | AcRefrigerationRepair
        | AccountingBookkeepingServices
        | AdvertisingServices
        | AgriculturalCooperative
        | AirlinesAirCarriers
        | AirportsFlyingFields
        | AmbulanceServices
        | AmusementParksCarnivals
        | AntiqueReproductions
        | AntiqueShops
        | Aquariums
        | ArchitecturalSurveyingServices
        | ArtDealersAndGalleries
        | ArtistsSupplyAndCraftShops
        | AutoAndHomeSupplyStores
        | AutoBodyRepairShops
        | AutoPaintShops
        | AutoServiceShops
        | AutomatedCashDisburse
        | AutomatedFuelDispensers
        | AutomobileAssociations
        | AutomotivePartsAndAccessoriesStores
        | AutomotiveTireStores
        | BailAndBondPayments
        | Bakeries
        | BandsOrchestras
        | BarberAndBeautyShops
        | BettingCasinoGambling
        | BicycleShops
        | BilliardPoolEstablishments
        | BoatDealers
        | BoatRentalsAndLeases
        | BookStores
        | BooksPeriodicalsAndNewspapers
        | BowlingAlleys
        | BusLines
        | BusinessSecretarialSchools
        | BuyingShoppingServices
        | CableSatelliteAndOtherPayTelevisionAndRadio
        | CameraAndPhotographicSupplyStores
        | CandyNutAndConfectioneryStores
        | CarAndTruckDealersNewUsed
        | CarAndTruckDealersUsedOnly
        | CarRentalAgencies
        | CarWashes
        | CarpentryServices
        | CarpetUpholsteryCleaning
        | Caterers
        | CharitableAndSocialServiceOrganizationsFundraising
        | ChemicalsAndAlliedProducts
        | ChildCareServices
        | ChildrensAndInfantsWearStores
        | ChiropodistsPodiatrists
        | Chiropractors
        | CigarStoresAndStands
        | CivicSocialFraternalAssociations
        | CleaningAndMaintenance
        | ClothingRental
        | CollegesUniversities
        | CommercialEquipment
        | CommercialFootwear
        | CommercialPhotographyArtAndGraphics
        | CommuterTransportAndFerries
        | ComputerNetworkServices
        | ComputerProgramming
        | ComputerRepair
        | ComputerSoftwareStores
        | ComputersPeripheralsAndSoftware
        | ConcreteWorkServices
        | ConstructionMaterials
        | ConsultingPublicRelations
        | CorrespondenceSchools
        | CosmeticStores
        | CounselingServices
        | CountryClubs
        | CourierServices
        | CourtCosts
        | CreditReportingAgencies
        | CruiseLines
        | DairyProductsStores
        | DanceHallStudiosSchools
        | DatingEscortServices
        | DentistsOrthodontists
        | DepartmentStores
        | DetectiveAgencies
        | DigitalGoodsApplications
        | DigitalGoodsGames
        | DigitalGoodsLargeVolume
        | DigitalGoodsMedia
        | DirectMarketingCatalogMerchant
        | DirectMarketingCombinationCatalogAndRetailMerchant
        | DirectMarketingInboundTelemarketing
        | DirectMarketingInsuranceServices
        | DirectMarketingOther
        | DirectMarketingOutboundTelemarketing
        | DirectMarketingSubscription
        | DirectMarketingTravel
        | DiscountStores
        | Doctors
        | DoorToDoorSales
        | DraperyWindowCoveringAndUpholsteryStores
        | DrinkingPlaces
        | DrugStoresAndPharmacies
        | DrugsDrugProprietariesAndDruggistSundries
        | DryCleaners
        | DurableGoods
        | DutyFreeStores
        | EatingPlacesRestaurants
        | EducationalServices
        | ElectricRazorStores
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
        | EmploymentTempAgencies
        | EquipmentRental
        | ExterminatingServices
        | FamilyClothingStores
        | FastFoodRestaurants
        | FinancialInstitutions
        | FinesGovernmentAdministrativeEntities
        | FireplaceFireplaceScreensAndAccessoriesStores
        | FloorCoveringStores
        | Florists
        | FloristsSuppliesNurseryStockAndFlowers
        | FreezerAndLockerMeatProvisioners
        | FuelDealersNonAutomotive
        | FuneralServicesCrematories
        | FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | FurnitureRepairRefinishing
        | FurriersAndFurShops
        | GeneralServices
        | GiftCardNoveltyAndSouvenirShops
        | GlassPaintAndWallpaperStores
        | GlasswareCrystalStores
        | GolfCoursesPublic
        | GovernmentServices
        | GroceryStoresSupermarkets
        | HardwareEquipmentAndSupplies
        | HardwareStores
        | HealthAndBeautySpas
        | HearingAidsSalesAndSupplies
        | HeatingPlumbingAC
        | HobbyToyAndGameShops
        | HomeSupplyWarehouseStores
        | Hospitals
        | HotelsMotelsAndResorts
        | HouseholdApplianceStores
        | IndustrialSupplies
        | InformationRetrievalServices
        | InsuranceDefault
        | InsuranceUnderwritingPremiums
        | IntraCompanyPurchases
        | JewelryStoresWatchesClocksAndSilverwareStores
        | LandscapingServices
        | Laundries
        | LaundryCleaningServices
        | LegalServicesAttorneys
        | LuggageAndLeatherGoodsStores
        | LumberBuildingMaterialsStores
        | ManualCashDisburse
        | MarinasServiceAndSupplies
        | MasonryStoneworkAndPlaster
        | MassageParlors
        | MedicalAndDentalLabs
        | MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | MedicalServices
        | MembershipOrganizations
        | MensAndBoysClothingAndAccessoriesStores
        | MensWomensClothingStores
        | MetalServiceCenters
        | Miscellaneous
        | MiscellaneousApparelAndAccessoryShops
        | MiscellaneousAutoDealers
        | MiscellaneousBusinessServices
        | MiscellaneousFoodStores
        | MiscellaneousGeneralMerchandise
        | MiscellaneousGeneralServices
        | MiscellaneousHomeFurnishingSpecialtyStores
        | MiscellaneousPublishingAndPrinting
        | MiscellaneousRecreationServices
        | MiscellaneousRepairShops
        | MiscellaneousSpecialtyRetail
        | MobileHomeDealers
        | MotionPictureTheaters
        | MotorFreightCarriersAndTrucking
        | MotorHomesDealers
        | MotorVehicleSuppliesAndNewParts
        | MotorcycleShopsAndDealers
        | MotorcycleShopsDealers
        | MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | NewsDealersAndNewsstands
        | NonFiMoneyOrders
        | NonFiStoredValueCardPurchaseLoad
        | NondurableGoods
        | NurseriesLawnAndGardenSupplyStores
        | NursingPersonalCare
        | OfficeAndCommercialFurniture
        | OpticiansEyeglasses
        | OptometristsOphthalmologist
        | OrthopedicGoodsProstheticDevices
        | Osteopaths
        | PackageStoresBeerWineAndLiquor
        | PaintsVarnishesAndSupplies
        | ParkingLotsGarages
        | PassengerRailways
        | PawnShops
        | PetShopsPetFoodAndSupplies
        | PetroleumAndPetroleumProducts
        | PhotoDeveloping
        | PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | PhotographicStudios
        | PictureVideoProduction
        | PieceGoodsNotionsAndOtherDryGoods
        | PlumbingHeatingEquipmentAndSupplies
        | PoliticalOrganizations
        | PostalServicesGovernmentOnly
        | PreciousStonesAndMetalsWatchesAndJewelry
        | ProfessionalServices
        | PublicWarehousingAndStorage
        | QuickCopyReproAndBlueprint
        | Railroads
        | RealEstateAgentsAndManagersRentals
        | RecordStores
        | RecreationalVehicleRentals
        | ReligiousGoodsStores
        | ReligiousOrganizations
        | RoofingSidingSheetMetal
        | SecretarialSupportServices
        | SecurityBrokersDealers
        | ServiceStations
        | SewingNeedleworkFabricAndPieceGoodsStores
        | ShoeRepairHatCleaning
        | ShoeStores
        | SmallApplianceRepair
        | SnowmobileDealers
        | SpecialTradeServices
        | SpecialtyCleaning
        | SportingGoodsStores
        | SportingRecreationCamps
        | SportsAndRidingApparelStores
        | SportsClubsFields
        | StampAndCoinStores
        | StationaryOfficeSuppliesPrintingAndWritingPaper
        | StationeryStoresOfficeAndSchoolSupplyStores
        | SwimmingPoolsSales
        | TUiTravelGermany
        | TailorsAlterations
        | TaxPaymentsGovernmentAgencies
        | TaxPreparationServices
        | TaxicabsLimousines
        | TelecommunicationEquipmentAndTelephoneSales
        | TelecommunicationServices
        | TelegraphServices
        | TentAndAwningShops
        | TestingLaboratories
        | TheatricalTicketAgencies
        | Timeshares
        | TireRetreadingAndRepair
        | TollsBridgeFees
        | TouristAttractionsAndExhibits
        | TowingServices
        | TrailerParksCampgrounds
        | TransportationServices
        | TravelAgenciesTourOperators
        | TruckStopIteration
        | TruckUtilityTrailerRentals
        | TypesettingPlateMakingAndRelatedServices
        | TypewriterStores
        | USFederalGovernmentAgenciesOrDepartments
        | UniformsCommercialClothing
        | UsedMerchandiseAndSecondhandStores
        | Utilities
        | VarietyStores
        | VeterinaryServices
        | VideoAmusementGameSupplies
        | VideoGameArcades
        | VideoTapeRentalStores
        | VocationalTradeSchools
        | WatchJewelryRepair
        | WeldingRepair
        | WholesaleClubs
        | WigAndToupeeStores
        | WiresMoneyOrders
        | WomensAccessoryAndSpecialtyShops
        | WomensReadyToWearStores
        | WreckingAndSalvageYards

    and IssuingCardholderSpendingLimitInterval =
        | AllTime
        | Daily
        | Monthly
        | PerAuthorization
        | Weekly
        | Yearly

    ///
    and IssuingCardholderVerification =
        {
            Document: IssuingCardholderIdDocument option
        }

    ///
    and IssuingDisputeCanceledEvidence =
        {
            AdditionalDocumentation: string option
            CanceledAt: int64 option
            CancellationPolicyProvided: bool option
            CancellationReason: string option
            ExpectedAt: int64 option
            Explanation: string option
            ProductDescription: string option
            ProductType: IssuingDisputeCanceledEvidenceProductType option
            ReturnStatus: IssuingDisputeCanceledEvidenceReturnStatus option
            ReturnedAt: int64 option
        }

    and IssuingDisputeCanceledEvidenceProductType =
        | Merchandise
        | Service

    and IssuingDisputeCanceledEvidenceReturnStatus =
        | MerchantRejected
        | Successful

    ///
    and IssuingDisputeDuplicateEvidence =
        {
            AdditionalDocumentation: string option
            CardStatement: string option
            CashReceipt: string option
            CheckImage: string option
            Explanation: string option
            OriginalTransaction: string option
        }

    ///
    and IssuingDisputeEvidence =
        {
            Canceled: IssuingDisputeCanceledEvidence option
            Duplicate: IssuingDisputeDuplicateEvidence option
            Fraudulent: IssuingDisputeFraudulentEvidence option
            MerchandiseNotAsDescribed: IssuingDisputeMerchandiseNotAsDescribedEvidence option
            NotReceived: IssuingDisputeNotReceivedEvidence option
            Other: IssuingDisputeOtherEvidence option
            Reason: IssuingDisputeEvidenceReason
            ServiceNotAsDescribed: IssuingDisputeServiceNotAsDescribedEvidence option
        }

    and IssuingDisputeEvidenceReason =
        | Canceled
        | Duplicate
        | Fraudulent
        | MerchandiseNotAsDescribed
        | NotReceived
        | Other
        | ServiceNotAsDescribed

    ///
    and IssuingDisputeFraudulentEvidence =
        {
            AdditionalDocumentation: string option
            Explanation: string option
        }

    ///
    and IssuingDisputeMerchandiseNotAsDescribedEvidence =
        {
            AdditionalDocumentation: string option
            Explanation: string option
            ReceivedAt: int64 option
            ReturnDescription: string option
            ReturnStatus: IssuingDisputeMerchandiseNotAsDescribedEvidenceReturnStatus option
            ReturnedAt: int64 option
        }

    and IssuingDisputeMerchandiseNotAsDescribedEvidenceReturnStatus =
        | MerchantRejected
        | Successful

    ///
    and IssuingDisputeNotReceivedEvidence =
        {
            AdditionalDocumentation: string option
            ExpectedAt: int64 option
            Explanation: string option
            ProductDescription: string option
            ProductType: IssuingDisputeNotReceivedEvidenceProductType option
        }

    and IssuingDisputeNotReceivedEvidenceProductType =
        | Merchandise
        | Service

    ///
    and IssuingDisputeOtherEvidence =
        {
            AdditionalDocumentation: string option
            Explanation: string option
            ProductDescription: string option
            ProductType: IssuingDisputeOtherEvidenceProductType option
        }

    and IssuingDisputeOtherEvidenceProductType =
        | Merchandise
        | Service

    ///
    and IssuingDisputeServiceNotAsDescribedEvidence =
        {
            AdditionalDocumentation: string option
            CanceledAt: int64 option
            CancellationReason: string option
            Explanation: string option
            ReceivedAt: int64 option
        }

    ///
    and IssuingTransactionAmountDetails =
        {
            AtmFee: int64 option
        }

    ///
    and IssuingTransactionFlightData =
        {
            DepartureAt: int64 option
            PassengerName: string option
            Refundable: bool option
            Segments: IssuingTransactionFlightDataLeg list option
            TravelAgency: string option
        }

    ///
    and IssuingTransactionFlightDataLeg =
        {
            ArrivalAirportCode: string option
            Carrier: string option
            DepartureAirportCode: string option
            FlightNumber: string option
            ServiceClass: string option
            StopoverAllowed: bool option
        }

    ///
    and IssuingTransactionFuelData =
        {
            Type: string
            Unit: string
            UnitCostDecimal: string
            VolumeDecimal: string option
        }

    ///
    and IssuingTransactionLodgingData =
        {
            CheckInAt: int64 option
            Nights: int64 option
        }

    ///
    and IssuingTransactionPurchaseDetails =
        {
            Flight: IssuingTransactionFlightData option
            Fuel: IssuingTransactionFuelData option
            Lodging: IssuingTransactionLodgingData option
            Receipt: IssuingTransactionReceiptData list option
            Reference: string option
        }

    ///
    and IssuingTransactionReceiptData =
        {
            Description: string option
            Quantity: decimal option
            Total: int64 option
            UnitCost: int64 option
        }

    ///A line item.
    and Item =
        {
            AmountSubtotal: int64 option
            AmountTotal: int64 option
            Currency: string
            Description: string
            Discounts: LineItemsDiscountAmount list option
            Id: string
            Price: Price
            Quantity: int64 option
            Taxes: LineItemsTaxAmount list option
        }
        member _.Object = "item"

    ///
    and LegalEntityCompany =
        {
            Address: Address option
            AddressKana: LegalEntityJapanAddress option
            AddressKanji: LegalEntityJapanAddress option
            DirectorsProvided: bool option
            ExecutivesProvided: bool option
            Name: string option
            NameKana: string option
            NameKanji: string option
            OwnersProvided: bool option
            Phone: string option
            Structure: LegalEntityCompanyStructure option
            TaxIdProvided: bool option
            TaxIdRegistrar: string option
            VatIdProvided: bool option
            Verification: LegalEntityCompanyVerification option
        }

    and LegalEntityCompanyStructure =
        | GovernmentInstrumentality
        | GovernmentalUnit
        | IncorporatedNonProfit
        | LimitedLiabilityPartnership
        | MultiMemberLlc
        | PrivateCompany
        | PrivateCorporation
        | PrivatePartnership
        | PublicCompany
        | PublicCorporation
        | PublicPartnership
        | SoleProprietorship
        | TaxExemptGovernmentInstrumentality
        | UnincorporatedAssociation
        | UnincorporatedNonProfit

    ///
    and LegalEntityCompanyVerification =
        {
            Document: LegalEntityCompanyVerificationDocument
        }

    ///
    and LegalEntityCompanyVerificationDocument =
        {
            Back: string option
            Details: string option
            DetailsCode: string option
            Front: string option
        }

    ///
    and LegalEntityDob =
        {
            Day: int64 option
            Month: int64 option
            Year: int64 option
        }

    ///
    and LegalEntityJapanAddress =
        {
            City: string option
            Country: string option
            [<JsonField("line1")>]Line1: string option
            [<JsonField("line2")>]Line2: string option
            PostalCode: string option
            State: string option
            Town: string option
        }

    ///
    and LegalEntityPersonVerification =
        {
            AdditionalDocument: LegalEntityPersonVerificationDocument option
            Details: string option
            DetailsCode: string option
            Document: LegalEntityPersonVerificationDocument option
            Status: string
        }

    ///
    and LegalEntityPersonVerificationDocument =
        {
            Back: string option
            Details: string option
            DetailsCode: string option
            Front: string option
        }

    ///
    and Level3 =
        {
            CustomerReference: string option
            LineItems: Level3LineItems list
            MerchantReference: string
            ShippingAddressZip: string option
            ShippingAmount: int64 option
            ShippingFromZip: string option
        }

    ///
    and Level3LineItems =
        {
            DiscountAmount: int64 option
            ProductCode: string
            ProductDescription: string
            Quantity: int64 option
            TaxAmount: int64 option
            UnitCost: int64 option
        }

    ///
    and LineItem =
        {
            Amount: int64
            Currency: string
            Description: string option
            DiscountAmounts: DiscountsResourceDiscountAmount list option
            Discountable: bool
            Discounts: string list option
            Id: string
            InvoiceItem: string option
            Livemode: bool
            Metadata: Map<string, string>
            Period: InvoiceLineItemPeriod
            Plan: Plan option
            Price: Price option
            Proration: bool
            Quantity: int64 option
            Subscription: string option
            SubscriptionItem: string option
            TaxAmounts: InvoiceTaxAmount list option
            TaxRates: TaxRate list option
            Type: LineItemType
        }
        member _.Object = "line_item"

    and LineItemType =
        | Invoiceitem
        | Subscription

    ///
    and LineItemsDiscountAmount =
        {
            Amount: int64
            Discount: Discount
        }

    ///
    and LineItemsTaxAmount =
        {
            Amount: int64
            Rate: TaxRate
        }

    ///
    and LoginLink =
        {
            Created: int64
            Url: string
        }
        member _.Object = "login_link"

    ///A Mandate is a record of the permission a customer has given you to debit their payment method.
    and Mandate =
        {
            CustomerAcceptance: CustomerAcceptance
            Id: string
            Livemode: bool
            MultiUse: MandateMultiUse option
            PaymentMethod: string
            PaymentMethodDetails: MandatePaymentMethodDetails
            SingleUse: MandateSingleUse option
            Status: MandateStatus
            Type: MandateType
        }
        member _.Object = "mandate"

    and MandateStatus =
        | Active
        | Inactive
        | Pending

    and MandateType =
        | MultiUse
        | SingleUse

    ///
    and MandateAuBecsDebit =
        {
            Url: string
        }

    ///
    and MandateBacsDebit =
        {
            NetworkStatus: MandateBacsDebitNetworkStatus
            Reference: string
            Url: string
        }

    and MandateBacsDebitNetworkStatus =
        | Accepted
        | Pending
        | Refused
        | Revoked

    ///
    and MandateMultiUse =
        {
            Undefined: string list option
        }

    ///
    and MandatePaymentMethodDetails =
        {
            AuBecsDebit: MandateAuBecsDebit option
            BacsDebit: MandateBacsDebit option
            Card: CardMandatePaymentMethodDetails option
            SepaDebit: MandateSepaDebit option
            Type: string
        }

    ///
    and MandateSepaDebit =
        {
            Reference: string
            Url: string
        }

    ///
    and MandateSingleUse =
        {
            Amount: int64
            Currency: string
        }

    ///
    and Networks =
        {
            Available: string list
            Preferred: string option
        }

    ///
    and NotificationEventData =
        {
            Object: Map<string, string>
            PreviousAttributes: Map<string, string>
        }

    ///
    and NotificationEventRequest =
        {
            Id: string option
            IdempotencyKey: string option
        }

    ///
    and OfflineAcceptance =
        {
            Undefined: string list option
        }

    ///
    and OnlineAcceptance =
        {
            IpAddress: string option
            UserAgent: string option
        }

    ///Order objects are created to handle end customers' purchases of previously
    ///defined [products](https://stripe.com/docs/api#products). You can create, retrieve, and pay individual orders, as well
    ///as list all orders. Orders are identified by a unique, random ID.
    ///
    ///Related guide: [Tax, Shipping, and Inventory](https://stripe.com/docs/orders).
    and Order =
        {
            Amount: int64
            AmountReturned: int64 option
            Application: string option
            ApplicationFee: int64 option
            Charge: string option
            Created: int64
            Currency: string
            Customer: string option
            Email: string option
            ExternalCouponCode: string option
            Id: string
            Items: OrderItem list
            Livemode: bool
            Metadata: Map<string, string>
            Returns: Map<string, string>
            SelectedShippingMethod: string option
            Shipping: Shipping option
            ShippingMethods: ShippingMethod list option
            Status: string
            StatusTransitions: StatusTransitions option
            Updated: int64 option
            UpstreamId: string option
        }
        member _.Object = "order"

    ///A representation of the constituent items of any given order. Can be used to
    ///represent [SKUs](https://stripe.com/docs/api#skus), shipping costs, or taxes owed on the order.
    ///
    ///Related guide: [Orders](https://stripe.com/docs/orders/guide).
    and OrderItem =
        {
            Amount: int64
            Currency: string
            Description: string
            Parent: string option
            Quantity: int64 option
            Type: string
        }
        member _.Object = "order_item"

    ///A return represents the full or partial return of a number of [order items](https://stripe.com/docs/api#order_items).
    ///Returns always belong to an order, and may optionally contain a refund.
    ///
    ///Related guide: [Handling Returns](https://stripe.com/docs/orders/guide#handling-returns).
    and OrderReturn =
        {
            Amount: int64
            Created: int64
            Currency: string
            Id: string
            Items: OrderItem list
            Livemode: bool
            Order: string option
            Refund: string option
        }
        member _.Object = "order_return"

    ///
    and PackageDimensions =
        {
            Height: decimal
            Length: decimal
            Weight: decimal
            Width: decimal
        }

    ///
    and PaymentFlowsPrivatePaymentMethodsAlipay =
        {
            Undefined: string list option
        }

    ///
    and PaymentFlowsPrivatePaymentMethodsAlipayDetails =
        {
            Fingerprint: string option
            TransactionId: string option
        }

    ///A PaymentIntent guides you through the process of collecting a payment from your customer.
    ///We recommend that you create exactly one PaymentIntent for each order or
    ///customer session in your system. You can reference the PaymentIntent later to
    ///see the history of payment attempts for a particular session.
    ///
    ///A PaymentIntent transitions through
    ///[multiple statuses](https://stripe.com/docs/payments/intents#intent-statuses)
    ///throughout its lifetime as it interfaces with Stripe.js to perform
    ///authentication flows and ultimately creates at most one successful charge.
    ///
    ///Related guide: [Payment Intents API](https://stripe.com/docs/payments/payment-intents).
    and PaymentIntent =
        {
            Amount: int64
            AmountCapturable: int64
            AmountReceived: int64
            Application: string option
            ApplicationFeeAmount: int64 option
            CanceledAt: int64 option
            CancellationReason: PaymentIntentCancellationReason option
            CaptureMethod: PaymentIntentCaptureMethod
            Charges: Map<string, string>
            ClientSecret: string option
            ConfirmationMethod: PaymentIntentConfirmationMethod
            Created: int64
            Currency: string
            Customer: string option
            Description: string option
            Id: string
            Invoice: string option
            LastPaymentError: ApiErrors option
            Livemode: bool
            Metadata: Map<string, string>
            NextAction: PaymentIntentNextAction option
            OnBehalfOf: string option
            PaymentMethod: string option
            PaymentMethodOptions: PaymentIntentPaymentMethodOptions option
            PaymentMethodTypes: string list
            ReceiptEmail: string option
            Review: string option
            SetupFutureUsage: PaymentIntentSetupFutureUsage option
            Shipping: Shipping option
            Source: string option
            StatementDescriptor: string option
            StatementDescriptorSuffix: string option
            Status: PaymentIntentStatus
            TransferData: TransferData option
            TransferGroup: string option
        }
        member _.Object = "payment_intent"

    and PaymentIntentCancellationReason =
        | Abandoned
        | Automatic
        | Duplicate
        | FailedInvoice
        | Fraudulent
        | RequestedByCustomer
        | VoidInvoice

    and PaymentIntentCaptureMethod =
        | Automatic
        | Manual

    and PaymentIntentConfirmationMethod =
        | Automatic
        | Manual

    and PaymentIntentSetupFutureUsage =
        | OffSession
        | OnSession

    and PaymentIntentStatus =
        | Canceled
        | Processing
        | RequiresAction
        | RequiresCapture
        | RequiresConfirmation
        | RequiresPaymentMethod
        | Succeeded

    ///
    and PaymentIntentNextAction =
        {
            AlipayHandleRedirect: PaymentIntentNextActionAlipayHandleRedirect option
            OxxoDisplayDetails: PaymentIntentNextActionDisplayOxxoDetails option
            RedirectToUrl: PaymentIntentNextActionRedirectToUrl option
            Type: string
            UseStripeSdk: Map<string, string>
        }

    ///
    and PaymentIntentNextActionAlipayHandleRedirect =
        {
            NativeData: string option
            NativeUrl: string option
            ReturnUrl: string option
            Url: string option
        }

    ///
    and PaymentIntentNextActionDisplayOxxoDetails =
        {
            ExpiresAfter: int64 option
            HostedVoucherUrl: string option
            Number: string option
        }

    ///
    and PaymentIntentNextActionRedirectToUrl =
        {
            ReturnUrl: string option
            Url: string option
        }

    ///
    and PaymentIntentPaymentMethodOptions =
        {
            Alipay: PaymentMethodOptionsAlipay option
            Bancontact: PaymentMethodOptionsBancontact option
            Card: PaymentIntentPaymentMethodOptionsCard option
            Oxxo: PaymentMethodOptionsOxxo option
            [<JsonField("p24")>]P24: PaymentMethodOptionsP24 option
            SepaDebit: PaymentIntentPaymentMethodOptionsSepaDebit option
            Sofort: PaymentMethodOptionsSofort option
        }

    ///
    and PaymentIntentPaymentMethodOptionsCard =
        {
            Installments: PaymentMethodOptionsCardInstallments option
            Network: PaymentIntentPaymentMethodOptionsCardNetwork option
            RequestThreeDSecure: PaymentIntentPaymentMethodOptionsCardRequestThreeDSecure option
        }

    and PaymentIntentPaymentMethodOptionsCardNetwork =
        | Amex
        | CartesBancaires
        | Diners
        | Discover
        | Interac
        | Jcb
        | Mastercard
        | Unionpay
        | Unknown
        | Visa

    and PaymentIntentPaymentMethodOptionsCardRequestThreeDSecure =
        | Any
        | Automatic
        | ChallengeOnly

    ///
    and PaymentIntentPaymentMethodOptionsMandateOptionsSepaDebit =
        {
            Undefined: string list option
        }

    ///
    and PaymentIntentPaymentMethodOptionsSepaDebit =
        {
            MandateOptions: PaymentIntentPaymentMethodOptionsMandateOptionsSepaDebit option
        }

    ///PaymentMethod objects represent your customer's payment instruments.
    ///They can be used with [PaymentIntents](https://stripe.com/docs/payments/payment-intents) to collect payments or saved to
    ///Customer objects to store instrument details for future payments.
    ///
    ///Related guides: [Payment Methods](https://stripe.com/docs/payments/payment-methods) and [More Payment Scenarios](https://stripe.com/docs/payments/more-payment-scenarios).
    and PaymentMethod =
        {
            Alipay: PaymentFlowsPrivatePaymentMethodsAlipay option
            AuBecsDebit: PaymentMethodAuBecsDebit option
            BacsDebit: PaymentMethodBacsDebit option
            Bancontact: PaymentMethodBancontact option
            BillingDetails: BillingDetails
            Card: PaymentMethodCard option
            CardPresent: PaymentMethodCardPresent option
            Created: int64
            Customer: string option
            Eps: PaymentMethodEps option
            Fpx: PaymentMethodFpx option
            Giropay: PaymentMethodGiropay option
            Grabpay: PaymentMethodGrabpay option
            Id: string
            Ideal: PaymentMethodIdeal option
            InteracPresent: PaymentMethodInteracPresent option
            Livemode: bool
            Metadata: Map<string, string>
            Oxxo: PaymentMethodOxxo option
            [<JsonField("p24")>]P24: PaymentMethodP24 option
            SepaDebit: PaymentMethodSepaDebit option
            Sofort: PaymentMethodSofort option
            Type: PaymentMethodType
        }
        member _.Object = "payment_method"

    and PaymentMethodType =
        | Alipay
        | AuBecsDebit
        | BacsDebit
        | Bancontact
        | Card
        | CardPresent
        | Eps
        | Fpx
        | Giropay
        | Grabpay
        | Ideal
        | InteracPresent
        | Oxxo
        | P24
        | SepaDebit
        | Sofort

    ///
    and PaymentMethodAuBecsDebit =
        {
            BsbNumber: string option
            Fingerprint: string option
            [<JsonField("last4")>]Last4: string option
        }

    ///
    and PaymentMethodBacsDebit =
        {
            Fingerprint: string option
            [<JsonField("last4")>]Last4: string option
            SortCode: string option
        }

    ///
    and PaymentMethodBancontact =
        {
            Undefined: string list option
        }

    ///
    and PaymentMethodCard =
        {
            Brand: PaymentMethodCardBrand
            Checks: PaymentMethodCardChecks option
            Country: string option
            Description: string option
            ExpMonth: int64
            ExpYear: int64
            Fingerprint: string option
            Funding: PaymentMethodCardFunding
            Iin: string option
            Issuer: string option
            [<JsonField("last4")>]Last4: string
            Networks: Networks option
            ThreeDSecureUsage: ThreeDSecureUsage option
            Wallet: PaymentMethodCardWallet option
        }

    and PaymentMethodCardBrand =
        | Amex
        | Diners
        | Discover
        | Jcb
        | Mastercard
        | Unionpay
        | Visa
        | Unknown

    and PaymentMethodCardFunding =
        | Credit
        | Debit
        | Prepaid
        | Unknown

    ///
    and PaymentMethodCardChecks =
        {
            [<JsonField("address_line1_check")>]AddressLine1Check: string option
            AddressPostalCodeCheck: string option
            CvcCheck: string option
        }

    ///
    and PaymentMethodCardPresent =
        {
            Undefined: string list option
        }

    ///
    and PaymentMethodCardWallet =
        {
            AmexExpressCheckout: PaymentMethodCardWalletAmexExpressCheckout option
            ApplePay: PaymentMethodCardWalletApplePay option
            [<JsonField("dynamic_last4")>]DynamicLast4: string option
            GooglePay: PaymentMethodCardWalletGooglePay option
            Masterpass: PaymentMethodCardWalletMasterpass option
            SamsungPay: PaymentMethodCardWalletSamsungPay option
            Type: PaymentMethodCardWalletType
            VisaCheckout: PaymentMethodCardWalletVisaCheckout option
        }

    and PaymentMethodCardWalletType =
        | AmexExpressCheckout
        | ApplePay
        | GooglePay
        | Masterpass
        | SamsungPay
        | VisaCheckout

    ///
    and PaymentMethodCardWalletAmexExpressCheckout =
        {
            Undefined: string list option
        }

    ///
    and PaymentMethodCardWalletApplePay =
        {
            Undefined: string list option
        }

    ///
    and PaymentMethodCardWalletGooglePay =
        {
            Undefined: string list option
        }

    ///
    and PaymentMethodCardWalletMasterpass =
        {
            BillingAddress: Address option
            Email: string option
            Name: string option
            ShippingAddress: Address option
        }

    ///
    and PaymentMethodCardWalletSamsungPay =
        {
            Undefined: string list option
        }

    ///
    and PaymentMethodCardWalletVisaCheckout =
        {
            BillingAddress: Address option
            Email: string option
            Name: string option
            ShippingAddress: Address option
        }

    ///
    and PaymentMethodDetails =
        {
            AchCreditTransfer: PaymentMethodDetailsAchCreditTransfer option
            AchDebit: PaymentMethodDetailsAchDebit option
            AcssDebit: PaymentMethodDetailsAcssDebit option
            Alipay: PaymentFlowsPrivatePaymentMethodsAlipayDetails option
            AuBecsDebit: PaymentMethodDetailsAuBecsDebit option
            BacsDebit: PaymentMethodDetailsBacsDebit option
            Bancontact: PaymentMethodDetailsBancontact option
            Card: PaymentMethodDetailsCard option
            CardPresent: PaymentMethodDetailsCardPresent option
            Eps: PaymentMethodDetailsEps option
            Fpx: PaymentMethodDetailsFpx option
            Giropay: PaymentMethodDetailsGiropay option
            Grabpay: PaymentMethodDetailsGrabpay option
            Ideal: PaymentMethodDetailsIdeal option
            InteracPresent: PaymentMethodDetailsInteracPresent option
            Klarna: PaymentMethodDetailsKlarna option
            Multibanco: PaymentMethodDetailsMultibanco option
            Oxxo: PaymentMethodDetailsOxxo option
            [<JsonField("p24")>]P24: PaymentMethodDetailsP24 option
            SepaCreditTransfer: PaymentMethodDetailsSepaCreditTransfer option
            SepaDebit: PaymentMethodDetailsSepaDebit option
            Sofort: PaymentMethodDetailsSofort option
            StripeAccount: PaymentMethodDetailsStripeAccount option
            Type: string
            Wechat: PaymentMethodDetailsWechat option
        }

    ///
    and PaymentMethodDetailsAchCreditTransfer =
        {
            AccountNumber: string option
            BankName: string option
            RoutingNumber: string option
            SwiftCode: string option
        }

    ///
    and PaymentMethodDetailsAchDebit =
        {
            AccountHolderType: PaymentMethodDetailsAchDebitAccountHolderType option
            BankName: string option
            Country: string option
            Fingerprint: string option
            [<JsonField("last4")>]Last4: string option
            RoutingNumber: string option
        }

    and PaymentMethodDetailsAchDebitAccountHolderType =
        | Company
        | Individual

    ///
    and PaymentMethodDetailsAcssDebit =
        {
            BankName: string option
            Fingerprint: string option
            InstitutionNumber: string option
            [<JsonField("last4")>]Last4: string option
            Mandate: string option
            TransitNumber: string option
        }

    ///
    and PaymentMethodDetailsAuBecsDebit =
        {
            BsbNumber: string option
            Fingerprint: string option
            [<JsonField("last4")>]Last4: string option
            Mandate: string option
        }

    ///
    and PaymentMethodDetailsBacsDebit =
        {
            Fingerprint: string option
            [<JsonField("last4")>]Last4: string option
            Mandate: string option
            SortCode: string option
        }

    ///
    and PaymentMethodDetailsBancontact =
        {
            BankCode: string option
            BankName: string option
            Bic: string option
            GeneratedSepaDebit: string option
            GeneratedSepaDebitMandate: string option
            [<JsonField("iban_last4")>]IbanLast4: string option
            PreferredLanguage: PaymentMethodDetailsBancontactPreferredLanguage option
            VerifiedName: string option
        }

    and PaymentMethodDetailsBancontactPreferredLanguage =
        | De
        | En
        | Fr
        | Nl

    ///
    and PaymentMethodDetailsCard =
        {
            Brand: PaymentMethodDetailsCardBrand option
            Checks: PaymentMethodDetailsCardChecks option
            Country: string option
            Description: string option
            ExpMonth: int64
            ExpYear: int64
            Fingerprint: string option
            Funding: PaymentMethodDetailsCardFunding option
            Iin: string option
            Installments: PaymentMethodDetailsCardInstallments option
            Issuer: string option
            [<JsonField("last4")>]Last4: string option
            Moto: bool option
            Network: PaymentMethodDetailsCardNetwork option
            ThreeDSecure: ThreeDSecureDetails option
            Wallet: PaymentMethodDetailsCardWallet option
        }

    and PaymentMethodDetailsCardBrand =
        | Amex
        | Diners
        | Discover
        | Jcb
        | Mastercard
        | Unionpay
        | Visa
        | Unknown

    and PaymentMethodDetailsCardFunding =
        | Credit
        | Debit
        | Prepaid
        | Unknown

    and PaymentMethodDetailsCardNetwork =
        | Amex
        | CartesBancaires
        | Diners
        | Discover
        | Interac
        | Jcb
        | Mastercard
        | Unionpay
        | Visa
        | Unknown

    ///
    and PaymentMethodDetailsCardChecks =
        {
            [<JsonField("address_line1_check")>]AddressLine1Check: string option
            AddressPostalCodeCheck: string option
            CvcCheck: string option
        }

    ///
    and PaymentMethodDetailsCardInstallments =
        {
            Plan: PaymentMethodDetailsCardInstallmentsPlan option
        }

    ///
    and PaymentMethodDetailsCardInstallmentsPlan =
        {
            Count: int64 option
            Interval: PaymentMethodDetailsCardInstallmentsPlanInterval option
            Type: PaymentMethodDetailsCardInstallmentsPlanType
        }

    and PaymentMethodDetailsCardInstallmentsPlanInterval =
        | Month

    and PaymentMethodDetailsCardInstallmentsPlanType =
        | FixedCount

    ///
    and PaymentMethodDetailsCardPresent =
        {
            Brand: PaymentMethodDetailsCardPresentBrand option
            CardholderName: string option
            Country: string option
            Description: string option
            EmvAuthData: string option
            ExpMonth: int64
            ExpYear: int64
            Fingerprint: string option
            Funding: PaymentMethodDetailsCardPresentFunding option
            GeneratedCard: string option
            Iin: string option
            Issuer: string option
            [<JsonField("last4")>]Last4: string option
            Network: PaymentMethodDetailsCardPresentNetwork option
            ReadMethod: PaymentMethodDetailsCardPresentReadMethod option
            Receipt: PaymentMethodDetailsCardPresentReceipt option
        }

    and PaymentMethodDetailsCardPresentBrand =
        | Amex
        | Diners
        | Discover
        | Jcb
        | Mastercard
        | Unionpay
        | Visa
        | Unknown

    and PaymentMethodDetailsCardPresentFunding =
        | Credit
        | Debit
        | Prepaid
        | Unknown

    and PaymentMethodDetailsCardPresentNetwork =
        | Amex
        | CartesBancaires
        | Diners
        | Discover
        | Interac
        | Jcb
        | Mastercard
        | Unionpay
        | Visa
        | Unknown

    and PaymentMethodDetailsCardPresentReadMethod =
        | ContactEmv
        | ContactlessEmv
        | ContactlessMagstripeMode
        | MagneticStripeFallback
        | MagneticStripeTrack2

    ///
    and PaymentMethodDetailsCardPresentReceipt =
        {
            AccountType: PaymentMethodDetailsCardPresentReceiptAccountType option
            ApplicationCryptogram: string option
            ApplicationPreferredName: string option
            AuthorizationCode: string option
            AuthorizationResponseCode: string option
            CardholderVerificationMethod: string option
            DedicatedFileName: string option
            TerminalVerificationResults: string option
            TransactionStatusInformation: string option
        }

    and PaymentMethodDetailsCardPresentReceiptAccountType =
        | Checking
        | Credit
        | Prepaid
        | Unknown

    ///
    and PaymentMethodDetailsCardWallet =
        {
            AmexExpressCheckout: PaymentMethodDetailsCardWalletAmexExpressCheckout option
            ApplePay: PaymentMethodDetailsCardWalletApplePay option
            [<JsonField("dynamic_last4")>]DynamicLast4: string option
            GooglePay: PaymentMethodDetailsCardWalletGooglePay option
            Masterpass: PaymentMethodDetailsCardWalletMasterpass option
            SamsungPay: PaymentMethodDetailsCardWalletSamsungPay option
            Type: PaymentMethodDetailsCardWalletType
            VisaCheckout: PaymentMethodDetailsCardWalletVisaCheckout option
        }

    and PaymentMethodDetailsCardWalletType =
        | AmexExpressCheckout
        | ApplePay
        | GooglePay
        | Masterpass
        | SamsungPay
        | VisaCheckout

    ///
    and PaymentMethodDetailsCardWalletAmexExpressCheckout =
        {
            Undefined: string list option
        }

    ///
    and PaymentMethodDetailsCardWalletApplePay =
        {
            Undefined: string list option
        }

    ///
    and PaymentMethodDetailsCardWalletGooglePay =
        {
            Undefined: string list option
        }

    ///
    and PaymentMethodDetailsCardWalletMasterpass =
        {
            BillingAddress: Address option
            Email: string option
            Name: string option
            ShippingAddress: Address option
        }

    ///
    and PaymentMethodDetailsCardWalletSamsungPay =
        {
            Undefined: string list option
        }

    ///
    and PaymentMethodDetailsCardWalletVisaCheckout =
        {
            BillingAddress: Address option
            Email: string option
            Name: string option
            ShippingAddress: Address option
        }

    ///
    and PaymentMethodDetailsEps =
        {
            VerifiedName: string option
        }

    ///
    and PaymentMethodDetailsFpx =
        {
            AccountHolderType: PaymentMethodDetailsFpxAccountHolderType option
            Bank: PaymentMethodDetailsFpxBank
            TransactionId: string option
        }

    and PaymentMethodDetailsFpxAccountHolderType =
        | Company
        | Individual

    and PaymentMethodDetailsFpxBank =
        | AffinBank
        | AllianceBank
        | Ambank
        | BankIslam
        | BankMuamalat
        | BankRakyat
        | Bsn
        | Cimb
        | DeutscheBank
        | HongLeongBank
        | Hsbc
        | Kfh
        | Maybank2e
        | Maybank2u
        | Ocbc
        | PbEnterprise
        | PublicBank
        | Rhb
        | StandardChartered
        | Uob

    ///
    and PaymentMethodDetailsGiropay =
        {
            BankCode: string option
            BankName: string option
            Bic: string option
            VerifiedName: string option
        }

    ///
    and PaymentMethodDetailsGrabpay =
        {
            TransactionId: string option
        }

    ///
    and PaymentMethodDetailsIdeal =
        {
            Bank: PaymentMethodDetailsIdealBank option
            Bic: PaymentMethodDetailsIdealBic option
            GeneratedSepaDebit: string option
            GeneratedSepaDebitMandate: string option
            [<JsonField("iban_last4")>]IbanLast4: string option
            VerifiedName: string option
        }

    and PaymentMethodDetailsIdealBank =
        | AbnAmro
        | AsnBank
        | Bunq
        | Handelsbanken
        | Ing
        | Knab
        | Moneyou
        | Rabobank
        | Regiobank
        | SnsBank
        | TriodosBank
        | VanLanschot

    and PaymentMethodDetailsIdealBic =
        | [<JsonUnionCase("ABNANL2A")>] ABNANL2A
        | [<JsonUnionCase("ASNBNL21")>] ASNBNL21
        | [<JsonUnionCase("BUNQNL2A")>] BUNQNL2A
        | [<JsonUnionCase("FVLBNL22")>] FVLBNL22
        | [<JsonUnionCase("HANDNL2A")>] HANDNL2A
        | [<JsonUnionCase("INGBNL2A")>] INGBNL2A
        | [<JsonUnionCase("KNABNL2H")>] KNABNL2H
        | [<JsonUnionCase("MOYONL21")>] MOYONL21
        | [<JsonUnionCase("RABONL2U")>] RABONL2U
        | [<JsonUnionCase("RBRBNL21")>] RBRBNL21
        | [<JsonUnionCase("SNSBNL2A")>] SNSBNL2A
        | [<JsonUnionCase("TRIONL2U")>] TRIONL2U

    ///
    and PaymentMethodDetailsInteracPresent =
        {
            Brand: PaymentMethodDetailsInteracPresentBrand option
            CardholderName: string option
            Country: string option
            Description: string option
            EmvAuthData: string option
            ExpMonth: int64
            ExpYear: int64
            Fingerprint: string option
            Funding: PaymentMethodDetailsInteracPresentFunding option
            GeneratedCard: string option
            Iin: string option
            Issuer: string option
            [<JsonField("last4")>]Last4: string option
            Network: PaymentMethodDetailsInteracPresentNetwork option
            PreferredLocales: string list option
            ReadMethod: PaymentMethodDetailsInteracPresentReadMethod option
            Receipt: PaymentMethodDetailsInteracPresentReceipt option
        }

    and PaymentMethodDetailsInteracPresentBrand =
        | Interac
        | Mastercard
        | Visa

    and PaymentMethodDetailsInteracPresentFunding =
        | Credit
        | Debit
        | Prepaid
        | Unknown

    and PaymentMethodDetailsInteracPresentNetwork =
        | Amex
        | CartesBancaires
        | Diners
        | Discover
        | Interac
        | Jcb
        | Mastercard
        | Unionpay
        | Visa
        | Unknown

    and PaymentMethodDetailsInteracPresentReadMethod =
        | ContactEmv
        | ContactlessEmv
        | ContactlessMagstripeMode
        | MagneticStripeFallback
        | MagneticStripeTrack2

    ///
    and PaymentMethodDetailsInteracPresentReceipt =
        {
            AccountType: PaymentMethodDetailsInteracPresentReceiptAccountType option
            ApplicationCryptogram: string option
            ApplicationPreferredName: string option
            AuthorizationCode: string option
            AuthorizationResponseCode: string option
            CardholderVerificationMethod: string option
            DedicatedFileName: string option
            TerminalVerificationResults: string option
            TransactionStatusInformation: string option
        }

    and PaymentMethodDetailsInteracPresentReceiptAccountType =
        | Checking
        | Savings
        | Unknown

    ///
    and PaymentMethodDetailsKlarna =
        {
            Undefined: string list option
        }

    ///
    and PaymentMethodDetailsMultibanco =
        {
            Entity: string option
            Reference: string option
        }

    ///
    and PaymentMethodDetailsOxxo =
        {
            Number: string option
        }

    ///
    and PaymentMethodDetailsP24 =
        {
            Reference: string option
            VerifiedName: string option
        }

    ///
    and PaymentMethodDetailsSepaCreditTransfer =
        {
            BankName: string option
            Bic: string option
            Iban: string option
        }

    ///
    and PaymentMethodDetailsSepaDebit =
        {
            BankCode: string option
            BranchCode: string option
            Country: string option
            Fingerprint: string option
            [<JsonField("last4")>]Last4: string option
            Mandate: string option
        }

    ///
    and PaymentMethodDetailsSofort =
        {
            BankCode: string option
            BankName: string option
            Bic: string option
            Country: string option
            GeneratedSepaDebit: string option
            GeneratedSepaDebitMandate: string option
            [<JsonField("iban_last4")>]IbanLast4: string option
            PreferredLanguage: PaymentMethodDetailsSofortPreferredLanguage option
            VerifiedName: string option
        }

    and PaymentMethodDetailsSofortPreferredLanguage =
        | De
        | En
        | Es
        | Fr
        | It
        | Nl
        | Pl

    ///
    and PaymentMethodDetailsStripeAccount =
        {
            Undefined: string list option
        }

    ///
    and PaymentMethodDetailsWechat =
        {
            Undefined: string list option
        }

    ///
    and PaymentMethodEps =
        {
            Undefined: string list option
        }

    ///
    and PaymentMethodFpx =
        {
            AccountHolderType: PaymentMethodFpxAccountHolderType option
            Bank: PaymentMethodFpxBank
        }

    and PaymentMethodFpxAccountHolderType =
        | Company
        | Individual

    and PaymentMethodFpxBank =
        | AffinBank
        | AllianceBank
        | Ambank
        | BankIslam
        | BankMuamalat
        | BankRakyat
        | Bsn
        | Cimb
        | DeutscheBank
        | HongLeongBank
        | Hsbc
        | Kfh
        | Maybank2e
        | Maybank2u
        | Ocbc
        | PbEnterprise
        | PublicBank
        | Rhb
        | StandardChartered
        | Uob

    ///
    and PaymentMethodGiropay =
        {
            Undefined: string list option
        }

    ///
    and PaymentMethodGrabpay =
        {
            Undefined: string list option
        }

    ///
    and PaymentMethodIdeal =
        {
            Bank: PaymentMethodIdealBank option
            Bic: PaymentMethodIdealBic option
        }

    and PaymentMethodIdealBank =
        | AbnAmro
        | AsnBank
        | Bunq
        | Handelsbanken
        | Ing
        | Knab
        | Moneyou
        | Rabobank
        | Regiobank
        | SnsBank
        | TriodosBank
        | VanLanschot

    and PaymentMethodIdealBic =
        | [<JsonUnionCase("ABNANL2A")>] ABNANL2A
        | [<JsonUnionCase("ASNBNL21")>] ASNBNL21
        | [<JsonUnionCase("BUNQNL2A")>] BUNQNL2A
        | [<JsonUnionCase("FVLBNL22")>] FVLBNL22
        | [<JsonUnionCase("HANDNL2A")>] HANDNL2A
        | [<JsonUnionCase("INGBNL2A")>] INGBNL2A
        | [<JsonUnionCase("KNABNL2H")>] KNABNL2H
        | [<JsonUnionCase("MOYONL21")>] MOYONL21
        | [<JsonUnionCase("RABONL2U")>] RABONL2U
        | [<JsonUnionCase("RBRBNL21")>] RBRBNL21
        | [<JsonUnionCase("SNSBNL2A")>] SNSBNL2A
        | [<JsonUnionCase("TRIONL2U")>] TRIONL2U

    ///
    and PaymentMethodInteracPresent =
        {
            Undefined: string list option
        }

    ///
    and PaymentMethodOptionsAlipay =
        {
            Undefined: string list option
        }

    ///
    and PaymentMethodOptionsBancontact =
        {
            PreferredLanguage: PaymentMethodOptionsBancontactPreferredLanguage
        }

    and PaymentMethodOptionsBancontactPreferredLanguage =
        | De
        | En
        | Fr
        | Nl

    ///
    and PaymentMethodOptionsCardInstallments =
        {
            AvailablePlans: PaymentMethodDetailsCardInstallmentsPlan list option
            Enabled: bool
            Plan: PaymentMethodDetailsCardInstallmentsPlan option
        }

    ///
    and PaymentMethodOptionsOxxo =
        {
            ExpiresAfterDays: int64
        }

    ///
    and PaymentMethodOptionsP24 =
        {
            Undefined: string list option
        }

    ///
    and PaymentMethodOptionsSofort =
        {
            PreferredLanguage: PaymentMethodOptionsSofortPreferredLanguage option
        }

    and PaymentMethodOptionsSofortPreferredLanguage =
        | De
        | En
        | Es
        | Fr
        | It
        | Nl
        | Pl

    ///
    and PaymentMethodOxxo =
        {
            Undefined: string list option
        }

    ///
    and PaymentMethodP24 =
        {
            Bank: PaymentMethodP24Bank option
        }

    and PaymentMethodP24Bank =
        | AliorBank
        | BankMillennium
        | BankNowyBfgSa
        | BankPekaoSa
        | BankiSpbdzielcze
        | Blik
        | BnpParibas
        | Boz
        | CitiHandlowy
        | CreditAgricole
        | Envelobank
        | EtransferPocztowy24
        | GetinBank
        | Ideabank
        | Ing
        | Inteligo
        | MbankMtransfer
        | NestPrzelew
        | NoblePay
        | PbacZIpko
        | PlusBank
        | SantanderPrzelew24
        | TmobileUsbugiBankowe
        | ToyotaBank
        | VolkswagenBank

    ///
    and PaymentMethodSepaDebit =
        {
            BankCode: string option
            BranchCode: string option
            Country: string option
            Fingerprint: string option
            GeneratedFrom: SepaDebitGeneratedFrom option
            [<JsonField("last4")>]Last4: string option
        }

    ///
    and PaymentMethodSofort =
        {
            Country: string option
        }

    ///
    and PaymentPagesCheckoutSessionTotalDetails =
        {
            AmountDiscount: int64
            AmountTax: int64
            Breakdown: PaymentPagesCheckoutSessionTotalDetailsResourceBreakdown option
        }

    ///
    and PaymentPagesCheckoutSessionTotalDetailsResourceBreakdown =
        {
            Discounts: LineItemsDiscountAmount list
            Taxes: LineItemsTaxAmount list
        }

    ///
    and PaymentPagesPaymentPageResourcesShippingAddressCollection =
        {
            AllowedCountries: PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries list
        }

    and PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries =
        | [<JsonUnionCase("AC")>] AC
        | [<JsonUnionCase("AD")>] AD
        | [<JsonUnionCase("AE")>] AE
        | [<JsonUnionCase("AF")>] AF
        | [<JsonUnionCase("AG")>] AG
        | [<JsonUnionCase("AI")>] AI
        | [<JsonUnionCase("AL")>] AL
        | [<JsonUnionCase("AM")>] AM
        | [<JsonUnionCase("AO")>] AO
        | [<JsonUnionCase("AQ")>] AQ
        | [<JsonUnionCase("AR")>] AR
        | [<JsonUnionCase("AT")>] AT
        | [<JsonUnionCase("AU")>] AU
        | [<JsonUnionCase("AW")>] AW
        | [<JsonUnionCase("AX")>] AX
        | [<JsonUnionCase("AZ")>] AZ
        | [<JsonUnionCase("BA")>] BA
        | [<JsonUnionCase("BB")>] BB
        | [<JsonUnionCase("BD")>] BD
        | [<JsonUnionCase("BE")>] BE
        | [<JsonUnionCase("BF")>] BF
        | [<JsonUnionCase("BG")>] BG
        | [<JsonUnionCase("BH")>] BH
        | [<JsonUnionCase("BI")>] BI
        | [<JsonUnionCase("BJ")>] BJ
        | [<JsonUnionCase("BL")>] BL
        | [<JsonUnionCase("BM")>] BM
        | [<JsonUnionCase("BN")>] BN
        | [<JsonUnionCase("BO")>] BO
        | [<JsonUnionCase("BQ")>] BQ
        | [<JsonUnionCase("BR")>] BR
        | [<JsonUnionCase("BS")>] BS
        | [<JsonUnionCase("BT")>] BT
        | [<JsonUnionCase("BV")>] BV
        | [<JsonUnionCase("BW")>] BW
        | [<JsonUnionCase("BY")>] BY
        | [<JsonUnionCase("BZ")>] BZ
        | [<JsonUnionCase("CA")>] CA
        | [<JsonUnionCase("CD")>] CD
        | [<JsonUnionCase("CF")>] CF
        | [<JsonUnionCase("CG")>] CG
        | [<JsonUnionCase("CH")>] CH
        | [<JsonUnionCase("CI")>] CI
        | [<JsonUnionCase("CK")>] CK
        | [<JsonUnionCase("CL")>] CL
        | [<JsonUnionCase("CM")>] CM
        | [<JsonUnionCase("CN")>] CN
        | [<JsonUnionCase("CO")>] CO
        | [<JsonUnionCase("CR")>] CR
        | [<JsonUnionCase("CV")>] CV
        | [<JsonUnionCase("CW")>] CW
        | [<JsonUnionCase("CY")>] CY
        | [<JsonUnionCase("CZ")>] CZ
        | [<JsonUnionCase("DE")>] DE
        | [<JsonUnionCase("DJ")>] DJ
        | [<JsonUnionCase("DK")>] DK
        | [<JsonUnionCase("DM")>] DM
        | [<JsonUnionCase("DO")>] DO
        | [<JsonUnionCase("DZ")>] DZ
        | [<JsonUnionCase("EC")>] EC
        | [<JsonUnionCase("EE")>] EE
        | [<JsonUnionCase("EG")>] EG
        | [<JsonUnionCase("EH")>] EH
        | [<JsonUnionCase("ER")>] ER
        | [<JsonUnionCase("ES")>] ES
        | [<JsonUnionCase("ET")>] ET
        | [<JsonUnionCase("FI")>] FI
        | [<JsonUnionCase("FJ")>] FJ
        | [<JsonUnionCase("FK")>] FK
        | [<JsonUnionCase("FO")>] FO
        | [<JsonUnionCase("FR")>] FR
        | [<JsonUnionCase("GA")>] GA
        | [<JsonUnionCase("GB")>] GB
        | [<JsonUnionCase("GD")>] GD
        | [<JsonUnionCase("GE")>] GE
        | [<JsonUnionCase("GF")>] GF
        | [<JsonUnionCase("GG")>] GG
        | [<JsonUnionCase("GH")>] GH
        | [<JsonUnionCase("GI")>] GI
        | [<JsonUnionCase("GL")>] GL
        | [<JsonUnionCase("GM")>] GM
        | [<JsonUnionCase("GN")>] GN
        | [<JsonUnionCase("GP")>] GP
        | [<JsonUnionCase("GQ")>] GQ
        | [<JsonUnionCase("GR")>] GR
        | [<JsonUnionCase("GS")>] GS
        | [<JsonUnionCase("GT")>] GT
        | [<JsonUnionCase("GU")>] GU
        | [<JsonUnionCase("GW")>] GW
        | [<JsonUnionCase("GY")>] GY
        | [<JsonUnionCase("HK")>] HK
        | [<JsonUnionCase("HN")>] HN
        | [<JsonUnionCase("HR")>] HR
        | [<JsonUnionCase("HT")>] HT
        | [<JsonUnionCase("HU")>] HU
        | [<JsonUnionCase("ID")>] ID
        | [<JsonUnionCase("IE")>] IE
        | [<JsonUnionCase("IL")>] IL
        | [<JsonUnionCase("IM")>] IM
        | [<JsonUnionCase("IN")>] IN
        | [<JsonUnionCase("IO")>] IO
        | [<JsonUnionCase("IQ")>] IQ
        | [<JsonUnionCase("IS")>] IS
        | [<JsonUnionCase("IT")>] IT
        | [<JsonUnionCase("JE")>] JE
        | [<JsonUnionCase("JM")>] JM
        | [<JsonUnionCase("JO")>] JO
        | [<JsonUnionCase("JP")>] JP
        | [<JsonUnionCase("KE")>] KE
        | [<JsonUnionCase("KG")>] KG
        | [<JsonUnionCase("KH")>] KH
        | [<JsonUnionCase("KI")>] KI
        | [<JsonUnionCase("KM")>] KM
        | [<JsonUnionCase("KN")>] KN
        | [<JsonUnionCase("KR")>] KR
        | [<JsonUnionCase("KW")>] KW
        | [<JsonUnionCase("KY")>] KY
        | [<JsonUnionCase("KZ")>] KZ
        | [<JsonUnionCase("LA")>] LA
        | [<JsonUnionCase("LB")>] LB
        | [<JsonUnionCase("LC")>] LC
        | [<JsonUnionCase("LI")>] LI
        | [<JsonUnionCase("LK")>] LK
        | [<JsonUnionCase("LR")>] LR
        | [<JsonUnionCase("LS")>] LS
        | [<JsonUnionCase("LT")>] LT
        | [<JsonUnionCase("LU")>] LU
        | [<JsonUnionCase("LV")>] LV
        | [<JsonUnionCase("LY")>] LY
        | [<JsonUnionCase("MA")>] MA
        | [<JsonUnionCase("MC")>] MC
        | [<JsonUnionCase("MD")>] MD
        | [<JsonUnionCase("ME")>] ME
        | [<JsonUnionCase("MF")>] MF
        | [<JsonUnionCase("MG")>] MG
        | [<JsonUnionCase("MK")>] MK
        | [<JsonUnionCase("ML")>] ML
        | [<JsonUnionCase("MM")>] MM
        | [<JsonUnionCase("MN")>] MN
        | [<JsonUnionCase("MO")>] MO
        | [<JsonUnionCase("MQ")>] MQ
        | [<JsonUnionCase("MR")>] MR
        | [<JsonUnionCase("MS")>] MS
        | [<JsonUnionCase("MT")>] MT
        | [<JsonUnionCase("MU")>] MU
        | [<JsonUnionCase("MV")>] MV
        | [<JsonUnionCase("MW")>] MW
        | [<JsonUnionCase("MX")>] MX
        | [<JsonUnionCase("MY")>] MY
        | [<JsonUnionCase("MZ")>] MZ
        | [<JsonUnionCase("NA")>] NA
        | [<JsonUnionCase("NC")>] NC
        | [<JsonUnionCase("NE")>] NE
        | [<JsonUnionCase("NG")>] NG
        | [<JsonUnionCase("NI")>] NI
        | [<JsonUnionCase("NL")>] NL
        | [<JsonUnionCase("NO")>] NO
        | [<JsonUnionCase("NP")>] NP
        | [<JsonUnionCase("NR")>] NR
        | [<JsonUnionCase("NU")>] NU
        | [<JsonUnionCase("NZ")>] NZ
        | [<JsonUnionCase("OM")>] OM
        | [<JsonUnionCase("PA")>] PA
        | [<JsonUnionCase("PE")>] PE
        | [<JsonUnionCase("PF")>] PF
        | [<JsonUnionCase("PG")>] PG
        | [<JsonUnionCase("PH")>] PH
        | [<JsonUnionCase("PK")>] PK
        | [<JsonUnionCase("PL")>] PL
        | [<JsonUnionCase("PM")>] PM
        | [<JsonUnionCase("PN")>] PN
        | [<JsonUnionCase("PR")>] PR
        | [<JsonUnionCase("PS")>] PS
        | [<JsonUnionCase("PT")>] PT
        | [<JsonUnionCase("PY")>] PY
        | [<JsonUnionCase("QA")>] QA
        | [<JsonUnionCase("RE")>] RE
        | [<JsonUnionCase("RO")>] RO
        | [<JsonUnionCase("RS")>] RS
        | [<JsonUnionCase("RU")>] RU
        | [<JsonUnionCase("RW")>] RW
        | [<JsonUnionCase("SA")>] SA
        | [<JsonUnionCase("SB")>] SB
        | [<JsonUnionCase("SC")>] SC
        | [<JsonUnionCase("SE")>] SE
        | [<JsonUnionCase("SG")>] SG
        | [<JsonUnionCase("SH")>] SH
        | [<JsonUnionCase("SI")>] SI
        | [<JsonUnionCase("SJ")>] SJ
        | [<JsonUnionCase("SK")>] SK
        | [<JsonUnionCase("SL")>] SL
        | [<JsonUnionCase("SM")>] SM
        | [<JsonUnionCase("SN")>] SN
        | [<JsonUnionCase("SO")>] SO
        | [<JsonUnionCase("SR")>] SR
        | [<JsonUnionCase("SS")>] SS
        | [<JsonUnionCase("ST")>] ST
        | [<JsonUnionCase("SV")>] SV
        | [<JsonUnionCase("SX")>] SX
        | [<JsonUnionCase("SZ")>] SZ
        | [<JsonUnionCase("TA")>] TA
        | [<JsonUnionCase("TC")>] TC
        | [<JsonUnionCase("TD")>] TD
        | [<JsonUnionCase("TF")>] TF
        | [<JsonUnionCase("TG")>] TG
        | [<JsonUnionCase("TH")>] TH
        | [<JsonUnionCase("TJ")>] TJ
        | [<JsonUnionCase("TK")>] TK
        | [<JsonUnionCase("TL")>] TL
        | [<JsonUnionCase("TM")>] TM
        | [<JsonUnionCase("TN")>] TN
        | [<JsonUnionCase("TO")>] TO
        | [<JsonUnionCase("TR")>] TR
        | [<JsonUnionCase("TT")>] TT
        | [<JsonUnionCase("TV")>] TV
        | [<JsonUnionCase("TW")>] TW
        | [<JsonUnionCase("TZ")>] TZ
        | [<JsonUnionCase("UA")>] UA
        | [<JsonUnionCase("UG")>] UG
        | [<JsonUnionCase("US")>] US
        | [<JsonUnionCase("UY")>] UY
        | [<JsonUnionCase("UZ")>] UZ
        | [<JsonUnionCase("VA")>] VA
        | [<JsonUnionCase("VC")>] VC
        | [<JsonUnionCase("VE")>] VE
        | [<JsonUnionCase("VG")>] VG
        | [<JsonUnionCase("VN")>] VN
        | [<JsonUnionCase("VU")>] VU
        | [<JsonUnionCase("WF")>] WF
        | [<JsonUnionCase("WS")>] WS
        | [<JsonUnionCase("XK")>] XK
        | [<JsonUnionCase("YE")>] YE
        | [<JsonUnionCase("YT")>] YT
        | [<JsonUnionCase("ZA")>] ZA
        | [<JsonUnionCase("ZM")>] ZM
        | [<JsonUnionCase("ZW")>] ZW
        | [<JsonUnionCase("ZZ")>] ZZ

    and PaymentSource =
        | Account of Account
        | AlipayAccount of AlipayAccount
        | BankAccount of BankAccount
        | BitcoinReceiver of BitcoinReceiver
        | Card of Card
        | Source of Source

    ///A `Payout` object is created when you receive funds from Stripe, or when you
    ///initiate a payout to either a bank account or debit card of a [connected
    ///Stripe account](/docs/connect/bank-debit-card-payouts). You can retrieve individual payouts,
    ///as well as list all payouts. Payouts are made on [varying
    ///schedules](/docs/connect/manage-payout-schedule), depending on your country and
    ///industry.
    ///
    ///Related guide: [Receiving Payouts](https://stripe.com/docs/payouts).
    and Payout =
        {
            Amount: int64
            ArrivalDate: int64
            Automatic: bool
            BalanceTransaction: string option
            Created: int64
            Currency: string
            Description: string option
            Destination: string option
            FailureBalanceTransaction: string option
            FailureCode: string option
            FailureMessage: string option
            Id: string
            Livemode: bool
            Metadata: Map<string, string>
            Method: string
            OriginalPayout: string option
            ReversedBy: string option
            SourceType: string
            StatementDescriptor: string option
            Status: string
            Type: PayoutType
        }
        member _.Object = "payout"

    and PayoutType =
        | BankAccount
        | Card

    ///
    and Period =
        {
            End: int64 option
            Start: int64 option
        }

    ///This is an object representing a person associated with a Stripe account.
    ///
    ///Related guide: [Handling Identity Verification with the API](https://stripe.com/docs/connect/identity-verification-api#person-information).
    and Person =
        {
            Account: string option
            Address: Address option
            AddressKana: LegalEntityJapanAddress option
            AddressKanji: LegalEntityJapanAddress option
            Created: int64
            Dob: LegalEntityDob option
            Email: string option
            FirstName: string option
            FirstNameKana: string option
            FirstNameKanji: string option
            Gender: string option
            Id: string
            IdNumberProvided: bool option
            LastName: string option
            LastNameKana: string option
            LastNameKanji: string option
            MaidenName: string option
            Metadata: Map<string, string>
            Phone: string option
            PoliticalExposure: PersonPoliticalExposure option
            Relationship: PersonRelationship option
            Requirements: PersonRequirements option
            SsnLast4Provided: bool option
            Verification: LegalEntityPersonVerification option
        }
        member _.Object = "person"

    and PersonPoliticalExposure =
        | Existing
        | None'

    ///
    and PersonRelationship =
        {
            Director: bool option
            Executive: bool option
            Owner: bool option
            PercentOwnership: decimal option
            Representative: bool option
            Title: string option
        }

    ///
    and PersonRequirements =
        {
            CurrentlyDue: string list
            Errors: AccountRequirementsError list
            EventuallyDue: string list
            PastDue: string list
            PendingVerification: string list
        }

    ///You can now model subscriptions more flexibly using the [Prices API](https://stripe.com/docs/api#prices). It replaces the Plans API and is backwards compatible to simplify your migration.
    ///
    ///Plans define the base price, currency, and billing cycle for recurring purchases of products.
    ///[Products](https://stripe.com/docs/api#products) help you track inventory or provisioning, and plans help you track pricing. Different physical goods or levels of service should be represented by products, and pricing options should be represented by plans. This approach lets you change prices without having to change your provisioning scheme.
    ///
    ///For example, you might have a single "gold" product that has plans for $10/month, $100/year, €9/month, and €90/year.
    ///
    ///Related guides: [Set up a subscription](https://stripe.com/docs/billing/subscriptions/set-up-subscription) and more about [products and prices](https://stripe.com/docs/billing/prices-guide).
    and Plan =
        {
            Active: bool
            AggregateUsage: PlanAggregateUsage option
            Amount: int64 option
            AmountDecimal: string option
            BillingScheme: PlanBillingScheme
            Created: int64
            Currency: string
            Id: string
            Interval: PlanInterval
            IntervalCount: int64
            Livemode: bool
            Metadata: Map<string, string>
            Nickname: string option
            Product: string option
            Tiers: PlanTier list option
            TiersMode: PlanTiersMode option
            TransformUsage: TransformUsage option
            TrialPeriodDays: int64 option
            UsageType: PlanUsageType
        }
        member _.Object = "plan"

    and PlanAggregateUsage =
        | LastDuringPeriod
        | LastEver
        | Max
        | Sum

    and PlanBillingScheme =
        | PerUnit
        | Tiered

    and PlanInterval =
        | Day
        | Month
        | Week
        | Year

    and PlanTiersMode =
        | Graduated
        | Volume

    and PlanUsageType =
        | Licensed
        | Metered

    ///
    and PlanTier =
        {
            FlatAmount: int64 option
            FlatAmountDecimal: string option
            UnitAmount: int64 option
            UnitAmountDecimal: string option
            UpTo: int64 option
        }

    ///
    and PlatformTaxFee =
        {
            Account: string
            Id: string
            SourceTransaction: string
            Type: string
        }
        member _.Object = "platform_tax_fee"

    ///Prices define the unit cost, currency, and (optional) billing cycle for both recurring and one-time purchases of products.
    ///[Products](https://stripe.com/docs/api#products) help you track inventory or provisioning, and prices help you track payment terms. Different physical goods or levels of service should be represented by products, and pricing options should be represented by prices. This approach lets you change prices without having to change your provisioning scheme.
    ///
    ///For example, you might have a single "gold" product that has prices for $10/month, $100/year, and €9 once.
    ///
    ///Related guides: [Set up a subscription](https://stripe.com/docs/billing/subscriptions/set-up-subscription), [create an invoice](https://stripe.com/docs/billing/invoices/create), and more about [products and prices](https://stripe.com/docs/billing/prices-guide).
    and Price =
        {
            Active: bool
            BillingScheme: PriceBillingScheme
            Created: int64
            Currency: string
            Id: string
            Livemode: bool
            LookupKey: string option
            Metadata: Map<string, string>
            Nickname: string option
            Product: string
            Recurring: Recurring option
            Tiers: PriceTier list option
            TiersMode: PriceTiersMode option
            TransformQuantity: TransformQuantity option
            Type: PriceType
            UnitAmount: int64 option
            UnitAmountDecimal: string option
        }
        member _.Object = "price"

    and PriceBillingScheme =
        | PerUnit
        | Tiered

    and PriceTiersMode =
        | Graduated
        | Volume

    and PriceType =
        | OneTime
        | Recurring

    ///
    and PriceTier =
        {
            FlatAmount: int64 option
            FlatAmountDecimal: string option
            UnitAmount: int64 option
            UnitAmountDecimal: string option
            UpTo: int64 option
        }

    ///Products describe the specific goods or services you offer to your customers.
    ///For example, you might offer a Standard and Premium version of your goods or service; each version would be a separate Product.
    ///They can be used in conjunction with [Prices](https://stripe.com/docs/api#prices) to configure pricing in Checkout and Subscriptions.
    ///
    ///Related guides: [Set up a subscription](https://stripe.com/docs/billing/subscriptions/set-up-subscription) or accept [one-time payments with Checkout](https://stripe.com/docs/payments/checkout/client#create-products) and more about [Products and Prices](https://stripe.com/docs/billing/prices-guide)
    and Product =
        {
            Active: bool
            Attributes: string list option
            Caption: string option
            Created: int64
            DeactivateOn: string list option
            Description: string option
            Id: string
            Images: string list
            Livemode: bool
            Metadata: Map<string, string>
            Name: string
            PackageDimensions: PackageDimensions option
            Shippable: bool option
            StatementDescriptor: string option
            Type: ProductType
            UnitLabel: string option
            Updated: int64
            Url: string option
        }
        member _.Object = "product"

    and ProductType =
        | Good
        | Service

    ///A Promotion Code represents a customer-redeemable code for a coupon. It can be used to
    ///create multiple codes for a single coupon.
    and PromotionCode =
        {
            Active: bool
            Code: string
            Coupon: Coupon
            Created: int64
            Customer: string option
            ExpiresAt: int64 option
            Id: string
            Livemode: bool
            MaxRedemptions: int64 option
            Metadata: Map<string, string>
            Restrictions: PromotionCodesResourceRestrictions
            TimesRedeemed: int64
        }
        member _.Object = "promotion_code"

    ///
    and PromotionCodesResourceRestrictions =
        {
            FirstTimeTransaction: bool
            MinimumAmount: int64 option
            MinimumAmountCurrency: string option
        }

    ///An early fraud warning indicates that the card issuer has notified us that a
    ///charge may be fraudulent.
    ///
    ///Related guide: [Early Fraud Warnings](https://stripe.com/docs/disputes/measuring#early-fraud-warnings).
    and RadarEarlyFraudWarning =
        {
            Actionable: bool
            Charge: string
            Created: int64
            FraudType: string
            Id: string
            Livemode: bool
        }
        member _.Object = "radar.early_fraud_warning"

    ///Value lists allow you to group values together which can then be referenced in rules.
    ///
    ///Related guide: [Default Stripe Lists](https://stripe.com/docs/radar/lists#managing-list-items).
    and RadarValueList =
        {
            Alias: string
            Created: int64
            CreatedBy: string
            Id: string
            ItemType: RadarValueListItemType
            ListItems: Map<string, string>
            Livemode: bool
            Metadata: Map<string, string>
            Name: string
        }
        member _.Object = "radar.value_list"

    and RadarValueListItemType =
        | CardBin
        | CardFingerprint
        | CaseSensitiveString
        | Country
        | Email
        | IpAddress
        | String

    ///Value list items allow you to add specific values to a given Radar value list, which can then be used in rules.
    ///
    ///Related guide: [Managing List Items](https://stripe.com/docs/radar/lists#managing-list-items).
    and RadarValueListItem =
        {
            Created: int64
            CreatedBy: string
            Id: string
            Livemode: bool
            Value: string
            ValueList: string
        }
        member _.Object = "radar.value_list_item"

    ///
    and RadarReviewResourceLocation =
        {
            City: string option
            Country: string option
            Latitude: decimal option
            Longitude: decimal option
            Region: string option
        }

    ///
    and RadarReviewResourceSession =
        {
            Browser: string option
            Device: string option
            Platform: string option
            Version: string option
        }

    ///With `Recipient` objects, you can transfer money from your Stripe account to a
    ///third-party bank account or debit card. The API allows you to create, delete,
    ///and update your recipients. You can retrieve individual recipients as well as
    ///a list of all your recipients.
    ///
    ///**`Recipient` objects have been deprecated in favor of
    ///[Connect](https://stripe.com/docs/connect), specifically Connect's much more powerful
    ///[Account objects](https://stripe.com/docs/api#account). Stripe accounts that don't already use
    ///recipients can no longer begin doing so. Please use `Account` objects
    ///instead.**
    and Recipient =
        {
            ActiveAccount: BankAccount option
            Cards: Map<string, string>
            Created: int64
            DefaultCard: string option
            Description: string option
            Email: string option
            Id: string
            Livemode: bool
            Metadata: Map<string, string>
            MigratedTo: string option
            Name: string option
            RolledBackFrom: string option
            Type: string
            Verified: bool
        }
        member _.Object = "recipient"

    ///
    and Recurring =
        {
            AggregateUsage: RecurringAggregateUsage option
            Interval: RecurringInterval
            IntervalCount: int64
            TrialPeriodDays: int64 option
            UsageType: RecurringUsageType
        }

    and RecurringAggregateUsage =
        | LastDuringPeriod
        | LastEver
        | Max
        | Sum

    and RecurringInterval =
        | Day
        | Month
        | Week
        | Year

    and RecurringUsageType =
        | Licensed
        | Metered

    ///`Refund` objects allow you to refund a charge that has previously been created
    ///but not yet refunded. Funds will be refunded to the credit or debit card that
    ///was originally charged.
    ///
    ///Related guide: [Refunds](https://stripe.com/docs/refunds).
    and Refund =
        {
            Amount: int64
            BalanceTransaction: string option
            Charge: string option
            Created: int64
            Currency: string
            Description: string option
            FailureBalanceTransaction: string option
            FailureReason: string option
            Id: string
            Metadata: Map<string, string>
            PaymentIntent: string option
            Reason: string option
            ReceiptNumber: string option
            SourceTransferReversal: string option
            Status: string option
            TransferReversal: string option
        }
        member _.Object = "refund"

    ///The Report Run object represents an instance of a report type generated with
    ///specific run parameters. Once the object is created, Stripe begins processing the report.
    ///When the report has finished running, it will give you a reference to a file
    ///where you can retrieve your results. For an overview, see
    ///[API Access to Reports](https://stripe.com/docs/reporting/statements/api).
    ///
    ///Note that reports can only be run based on your live-mode data (not test-mode
    ///data), and thus related requests must be made with a
    ///[live-mode API key](https://stripe.com/docs/keys#test-live-modes).
    and ReportingReportRun =
        {
            Created: int64
            Error: string option
            Id: string
            Livemode: bool
            Parameters: FinancialReportingFinanceReportRunRunParameters
            ReportType: string
            Result: File option
            Status: string
            SucceededAt: int64 option
        }
        member _.Object = "reporting.report_run"

    ///The Report Type resource corresponds to a particular type of report, such as
    ///the "Activity summary" or "Itemized payouts" reports. These objects are
    ///identified by an ID belonging to a set of enumerated values. See
    ///[API Access to Reports documentation](https://stripe.com/docs/reporting/statements/api)
    ///for those Report Type IDs, along with required and optional parameters.
    ///
    ///Note that reports can only be run based on your live-mode data (not test-mode
    ///data), and thus related requests must be made with a
    ///[live-mode API key](https://stripe.com/docs/keys#test-live-modes).
    and ReportingReportType =
        {
            DataAvailableEnd: int64
            DataAvailableStart: int64
            DefaultColumns: string list option
            Id: string
            Name: string
            Updated: int64
            Version: int64
        }
        member _.Object = "reporting.report_type"

    ///
    and ReserveTransaction =
        {
            Amount: int64
            Currency: string
            Description: string option
            Id: string
        }
        member _.Object = "reserve_transaction"

    ///Reviews can be used to supplement automated fraud detection with human expertise.
    ///
    ///Learn more about [Radar](/radar) and reviewing payments
    ///[here](https://stripe.com/docs/radar/reviews).
    and Review =
        {
            BillingZip: string option
            Charge: string option
            ClosedReason: ReviewClosedReason option
            Created: int64
            Id: string
            IpAddress: string option
            IpAddressLocation: RadarReviewResourceLocation option
            Livemode: bool
            Open: bool
            OpenedReason: ReviewOpenedReason
            PaymentIntent: string option
            Reason: string
            Session: RadarReviewResourceSession option
        }
        member _.Object = "review"

    and ReviewClosedReason =
        | Approved
        | Disputed
        | Refunded
        | RefundedAsFraud

    and ReviewOpenedReason =
        | Manual
        | Rule

    ///
    and Rule =
        {
            Action: string
            Id: string
            Predicate: string
        }

    ///If you have [scheduled a Sigma query](https://stripe.com/docs/sigma/scheduled-queries), you'll
    ///receive a `sigma.scheduled_query_run.created` webhook each time the query
    ///runs. The webhook contains a `ScheduledQueryRun` object, which you can use to
    ///retrieve the query results.
    and ScheduledQueryRun =
        {
            Created: int64
            DataLoadTime: int64
            Error: SigmaScheduledQueryRunError option
            File: File option
            Id: string
            Livemode: bool
            ResultAvailableUntil: int64
            Sql: string
            Status: string
            Title: string
        }
        member _.Object = "scheduled_query_run"

    ///
    and SepaDebitGeneratedFrom =
        {
            Charge: string option
            SetupAttempt: string option
        }

    ///A SetupAttempt describes one attempted confirmation of a SetupIntent,
    ///whether that confirmation was successful or unsuccessful. You can use
    ///SetupAttempts to inspect details of a specific attempt at setting up a
    ///payment method using a SetupIntent.
    and SetupAttempt =
        {
            Application: string option
            Created: int64
            Customer: string option
            Id: string
            Livemode: bool
            OnBehalfOf: string option
            PaymentMethod: string
            PaymentMethodDetails: SetupAttemptPaymentMethodDetails
            SetupError: ApiErrors option
            SetupIntent: string
            Status: string
            Usage: string
        }
        member _.Object = "setup_attempt"

    ///
    and SetupAttemptPaymentMethodDetails =
        {
            Bancontact: SetupAttemptPaymentMethodDetailsBancontact option
            Card: SetupAttemptPaymentMethodDetailsCard option
            Ideal: SetupAttemptPaymentMethodDetailsIdeal option
            Sofort: SetupAttemptPaymentMethodDetailsSofort option
            Type: string
        }

    ///
    and SetupAttemptPaymentMethodDetailsBancontact =
        {
            BankCode: string option
            BankName: string option
            Bic: string option
            GeneratedSepaDebit: string option
            GeneratedSepaDebitMandate: string option
            [<JsonField("iban_last4")>]IbanLast4: string option
            PreferredLanguage: SetupAttemptPaymentMethodDetailsBancontactPreferredLanguage option
            VerifiedName: string option
        }

    and SetupAttemptPaymentMethodDetailsBancontactPreferredLanguage =
        | De
        | En
        | Fr
        | Nl

    ///
    and SetupAttemptPaymentMethodDetailsCard =
        {
            ThreeDSecure: ThreeDSecureDetails option
        }

    ///
    and SetupAttemptPaymentMethodDetailsIdeal =
        {
            Bank: SetupAttemptPaymentMethodDetailsIdealBank option
            Bic: SetupAttemptPaymentMethodDetailsIdealBic option
            GeneratedSepaDebit: string option
            GeneratedSepaDebitMandate: string option
            [<JsonField("iban_last4")>]IbanLast4: string option
            VerifiedName: string option
        }

    and SetupAttemptPaymentMethodDetailsIdealBank =
        | AbnAmro
        | AsnBank
        | Bunq
        | Handelsbanken
        | Ing
        | Knab
        | Moneyou
        | Rabobank
        | Regiobank
        | SnsBank
        | TriodosBank
        | VanLanschot

    and SetupAttemptPaymentMethodDetailsIdealBic =
        | [<JsonUnionCase("ABNANL2A")>] ABNANL2A
        | [<JsonUnionCase("ASNBNL21")>] ASNBNL21
        | [<JsonUnionCase("BUNQNL2A")>] BUNQNL2A
        | [<JsonUnionCase("FVLBNL22")>] FVLBNL22
        | [<JsonUnionCase("HANDNL2A")>] HANDNL2A
        | [<JsonUnionCase("INGBNL2A")>] INGBNL2A
        | [<JsonUnionCase("KNABNL2H")>] KNABNL2H
        | [<JsonUnionCase("MOYONL21")>] MOYONL21
        | [<JsonUnionCase("RABONL2U")>] RABONL2U
        | [<JsonUnionCase("RBRBNL21")>] RBRBNL21
        | [<JsonUnionCase("SNSBNL2A")>] SNSBNL2A
        | [<JsonUnionCase("TRIONL2U")>] TRIONL2U

    ///
    and SetupAttemptPaymentMethodDetailsSofort =
        {
            BankCode: string option
            BankName: string option
            Bic: string option
            GeneratedSepaDebit: string option
            GeneratedSepaDebitMandate: string option
            [<JsonField("iban_last4")>]IbanLast4: string option
            PreferredLanguage: SetupAttemptPaymentMethodDetailsSofortPreferredLanguage option
            VerifiedName: string option
        }

    and SetupAttemptPaymentMethodDetailsSofortPreferredLanguage =
        | De
        | En
        | Fr
        | Nl

    ///A SetupIntent guides you through the process of setting up and saving a customer's payment credentials for future payments.
    ///For example, you could use a SetupIntent to set up and save your customer's card without immediately collecting a payment.
    ///Later, you can use [PaymentIntents](https://stripe.com/docs/api#payment_intents) to drive the payment flow.
    ///
    ///Create a SetupIntent as soon as you're ready to collect your customer's payment credentials.
    ///Do not maintain long-lived, unconfirmed SetupIntents as they may no longer be valid.
    ///The SetupIntent then transitions through multiple [statuses](https://stripe.com/docs/payments/intents#intent-statuses) as it guides
    ///you through the setup process.
    ///
    ///Successful SetupIntents result in payment credentials that are optimized for future payments.
    ///For example, cardholders in [certain regions](/guides/strong-customer-authentication) may need to be run through
    ///[Strong Customer Authentication](https://stripe.com/docs/strong-customer-authentication) at the time of payment method collection
    ///in order to streamline later [off-session payments](https://stripe.com/docs/payments/setup-intents).
    ///If the SetupIntent is used with a [Customer](https://stripe.com/docs/api#setup_intent_object-customer), upon success,
    ///it will automatically attach the resulting payment method to that Customer.
    ///We recommend using SetupIntents or [setup_future_usage](https://stripe.com/docs/api#payment_intent_object-setup_future_usage) on
    ///PaymentIntents to save payment methods in order to prevent saving invalid or unoptimized payment methods.
    ///
    ///By using SetupIntents, you ensure that your customers experience the minimum set of required friction,
    ///even as regulations change over time.
    ///
    ///Related guide: [Setup Intents API](https://stripe.com/docs/payments/setup-intents).
    and SetupIntent =
        {
            Application: string option
            CancellationReason: SetupIntentCancellationReason option
            ClientSecret: string option
            Created: int64
            Customer: string option
            Description: string option
            Id: string
            LastSetupError: ApiErrors option
            LatestAttempt: string option
            Livemode: bool
            Mandate: string option
            Metadata: Map<string, string>
            NextAction: SetupIntentNextAction option
            OnBehalfOf: string option
            PaymentMethod: string option
            PaymentMethodOptions: SetupIntentPaymentMethodOptions option
            PaymentMethodTypes: string list
            SingleUseMandate: string option
            Status: SetupIntentStatus
            Usage: string
        }
        member _.Object = "setup_intent"

    and SetupIntentCancellationReason =
        | Abandoned
        | Duplicate
        | RequestedByCustomer

    and SetupIntentStatus =
        | Canceled
        | Processing
        | RequiresAction
        | RequiresConfirmation
        | RequiresPaymentMethod
        | Succeeded

    ///
    and SetupIntentNextAction =
        {
            RedirectToUrl: SetupIntentNextActionRedirectToUrl option
            Type: string
            UseStripeSdk: Map<string, string>
        }

    ///
    and SetupIntentNextActionRedirectToUrl =
        {
            ReturnUrl: string option
            Url: string option
        }

    ///
    and SetupIntentPaymentMethodOptions =
        {
            Card: SetupIntentPaymentMethodOptionsCard option
            SepaDebit: SetupIntentPaymentMethodOptionsSepaDebit option
        }

    ///
    and SetupIntentPaymentMethodOptionsCard =
        {
            RequestThreeDSecure: SetupIntentPaymentMethodOptionsCardRequestThreeDSecure option
        }

    and SetupIntentPaymentMethodOptionsCardRequestThreeDSecure =
        | Any
        | Automatic
        | ChallengeOnly

    ///
    and SetupIntentPaymentMethodOptionsMandateOptionsSepaDebit =
        {
            Undefined: string list option
        }

    ///
    and SetupIntentPaymentMethodOptionsSepaDebit =
        {
            MandateOptions: SetupIntentPaymentMethodOptionsMandateOptionsSepaDebit option
        }

    ///
    and Shipping =
        {
            Address: Address option
            Carrier: string option
            Name: string option
            Phone: string option
            TrackingNumber: string option
        }

    ///
    and ShippingMethod =
        {
            Amount: int64
            Currency: string
            DeliveryEstimate: DeliveryEstimate option
            Description: string
            Id: string
        }

    ///
    and SigmaScheduledQueryRunError =
        {
            Message: string
        }

    ///Stores representations of [stock keeping units](http://en.wikipedia.org/wiki/Stock_keeping_unit).
    ///SKUs describe specific product variations, taking into account any combination of: attributes,
    ///currency, and cost. For example, a product may be a T-shirt, whereas a specific SKU represents
    ///the `size: large`, `color: red` version of that shirt.
    ///
    ///Can also be used to manage inventory.
    ///
    ///Related guide: [Tax, Shipping, and Inventory](https://stripe.com/docs/orders).
    and Sku =
        {
            Active: bool
            Attributes: Map<string, string>
            Created: int64
            Currency: string
            Id: string
            Image: string option
            Inventory: Inventory
            Livemode: bool
            Metadata: Map<string, string>
            PackageDimensions: PackageDimensions option
            Price: int64
            Product: string
            Updated: int64
        }
        member _.Object = "sku"

    ///`Source` objects allow you to accept a variety of payment methods. They
    ///represent a customer's payment instrument, and can be used with the Stripe API
    ///just like a `Card` object: once chargeable, they can be charged, or can be
    ///attached to customers.
    ///
    ///Related guides: [Sources API](https://stripe.com/docs/sources) and [Sources & Customers](https://stripe.com/docs/sources/customers).
    and Source =
        {
            AchCreditTransfer: SourceTypeAchCreditTransfer option
            AchDebit: SourceTypeAchDebit option
            AcssDebit: SourceTypeAcssDebit option
            Alipay: SourceTypeAlipay option
            Amount: int64 option
            AuBecsDebit: SourceTypeAuBecsDebit option
            Bancontact: SourceTypeBancontact option
            Card: SourceTypeCard option
            CardPresent: SourceTypeCardPresent option
            ClientSecret: string
            CodeVerification: SourceCodeVerificationFlow option
            Created: int64
            Currency: string option
            Customer: string option
            Eps: SourceTypeEps option
            Flow: string
            Giropay: SourceTypeGiropay option
            Id: string
            Ideal: SourceTypeIdeal option
            Klarna: SourceTypeKlarna option
            Livemode: bool
            Metadata: Map<string, string>
            Multibanco: SourceTypeMultibanco option
            Owner: SourceOwner option
            [<JsonField("p24")>]P24: SourceTypeP24 option
            Receiver: SourceReceiverFlow option
            Redirect: SourceRedirectFlow option
            SepaCreditTransfer: SourceTypeSepaCreditTransfer option
            SepaDebit: SourceTypeSepaDebit option
            Sofort: SourceTypeSofort option
            SourceOrder: SourceOrder option
            StatementDescriptor: string option
            Status: string
            ThreeDSecure: SourceTypeThreeDSecure option
            Type: SourceType
            Usage: string option
            Wechat: SourceTypeWechat option
        }
        member _.Object = "source"

    and SourceType =
        | AchCreditTransfer
        | AchDebit
        | AcssDebit
        | Alipay
        | AuBecsDebit
        | Bancontact
        | Card
        | CardPresent
        | Eps
        | Giropay
        | Ideal
        | Klarna
        | Multibanco
        | P24
        | SepaCreditTransfer
        | SepaDebit
        | Sofort
        | ThreeDSecure
        | Wechat

    ///
    and SourceCodeVerificationFlow =
        {
            AttemptsRemaining: int64
            Status: string
        }

    ///Source mandate notifications should be created when a notification related to
    ///a source mandate must be sent to the payer. They will trigger a webhook or
    ///deliver an email to the customer.
    and SourceMandateNotification =
        {
            AcssDebit: SourceMandateNotificationAcssDebitData option
            Amount: int64 option
            BacsDebit: SourceMandateNotificationBacsDebitData option
            Created: int64
            Id: string
            Livemode: bool
            Reason: string
            SepaDebit: SourceMandateNotificationSepaDebitData option
            Source: Source
            Status: string
            Type: string
        }
        member _.Object = "source_mandate_notification"

    ///
    and SourceMandateNotificationAcssDebitData =
        {
            StatementDescriptor: string option
        }

    ///
    and SourceMandateNotificationBacsDebitData =
        {
            [<JsonField("last4")>]Last4: string option
        }

    ///
    and SourceMandateNotificationSepaDebitData =
        {
            CreditorIdentifier: string option
            [<JsonField("last4")>]Last4: string option
            MandateReference: string option
        }

    ///
    and SourceOrder =
        {
            Amount: int64
            Currency: string
            Email: string option
            Items: SourceOrderItem list option
            Shipping: Shipping option
        }

    ///
    and SourceOrderItem =
        {
            Amount: int64 option
            Currency: string option
            Description: string option
            Parent: string option
            Quantity: int64 option
            Type: string option
        }

    ///
    and SourceOwner =
        {
            Address: Address option
            Email: string option
            Name: string option
            Phone: string option
            VerifiedAddress: Address option
            VerifiedEmail: string option
            VerifiedName: string option
            VerifiedPhone: string option
        }

    ///
    and SourceReceiverFlow =
        {
            Address: string option
            AmountCharged: int64
            AmountReceived: int64
            AmountReturned: int64
            RefundAttributesMethod: string
            RefundAttributesStatus: string
        }

    ///
    and SourceRedirectFlow =
        {
            FailureReason: string option
            ReturnUrl: string
            Status: string
            Url: string
        }

    ///Some payment methods have no required amount that a customer must send.
    ///Customers can be instructed to send any amount, and it can be made up of
    ///multiple transactions. As such, sources can have multiple associated
    ///transactions.
    and SourceTransaction =
        {
            AchCreditTransfer: SourceTransactionAchCreditTransferData option
            Amount: int64
            ChfCreditTransfer: SourceTransactionChfCreditTransferData option
            Created: int64
            Currency: string
            GbpCreditTransfer: SourceTransactionGbpCreditTransferData option
            Id: string
            Livemode: bool
            PaperCheck: SourceTransactionPaperCheckData option
            SepaCreditTransfer: SourceTransactionSepaCreditTransferData option
            Source: string
            Status: string
            Type: SourceTransactionType
        }
        member _.Object = "source_transaction"

    and SourceTransactionType =
        | AchCreditTransfer
        | AchDebit
        | Alipay
        | Bancontact
        | Card
        | CardPresent
        | Eps
        | Giropay
        | Ideal
        | Klarna
        | Multibanco
        | P24
        | SepaDebit
        | Sofort
        | ThreeDSecure
        | Wechat

    ///
    and SourceTransactionAchCreditTransferData =
        {
            CustomerData: string option
            Fingerprint: string option
            [<JsonField("last4")>]Last4: string option
            RoutingNumber: string option
        }

    ///
    and SourceTransactionChfCreditTransferData =
        {
            Reference: string option
            SenderAddressCountry: string option
            [<JsonField("sender_address_line1")>]SenderAddressLine1: string option
            SenderIban: string option
            SenderName: string option
        }

    ///
    and SourceTransactionGbpCreditTransferData =
        {
            Fingerprint: string option
            FundingMethod: string option
            [<JsonField("last4")>]Last4: string option
            Reference: string option
            SenderAccountNumber: string option
            SenderName: string option
            SenderSortCode: string option
        }

    ///
    and SourceTransactionPaperCheckData =
        {
            AvailableAt: string option
            Invoices: string option
        }

    ///
    and SourceTransactionSepaCreditTransferData =
        {
            Reference: string option
            SenderIban: string option
            SenderName: string option
        }

    and SourceTypeAchCreditTransfer =
        {
            AccountNumber: string option
            BankName: string option
            Fingerprint: string option
            RefundAccountHolderName: string option
            RefundAccountHolderType: string option
            RefundRoutingNumber: string option
            RoutingNumber: string option
            SwiftCode: string option
        }

    and SourceTypeAchDebit =
        {
            BankName: string option
            Country: string option
            Fingerprint: string option
            [<JsonField("last4")>]Last4: string option
            RoutingNumber: string option
            Type: string option
        }

    and SourceTypeAcssDebit =
        {
            BankAddressCity: string option
            BankAddressLine1: string option
            BankAddressLine2: string option
            BankAddressPostalCode: string option
            BankName: string option
            Category: string option
            Country: string option
            Fingerprint: string option
            [<JsonField("last4")>]Last4: string option
            RoutingNumber: string option
        }

    and SourceTypeAlipay =
        {
            DataString: string option
            NativeUrl: string option
            StatementDescriptor: string option
        }

    and SourceTypeAuBecsDebit =
        {
            BsbNumber: string option
            Fingerprint: string option
            [<JsonField("last4")>]Last4: string option
        }

    and SourceTypeBancontact =
        {
            BankCode: string option
            BankName: string option
            Bic: string option
            [<JsonField("iban_last4")>]IbanLast4: string option
            PreferredLanguage: string option
            StatementDescriptor: string option
        }

    and SourceTypeCard =
        {
            [<JsonField("address_line1_check")>]AddressLine1Check: string option
            AddressZipCheck: string option
            Brand: string option
            Country: string option
            CvcCheck: string option
            Description: string option
            [<JsonField("dynamic_last4")>]DynamicLast4: string option
            ExpMonth: int64 option
            ExpYear: int64 option
            Fingerprint: string option
            Funding: string option
            Iin: string option
            Issuer: string option
            [<JsonField("last4")>]Last4: string option
            Name: string option
            ThreeDSecure: string option
            TokenizationMethod: string option
        }

    and SourceTypeCardPresent =
        {
            ApplicationCryptogram: string option
            ApplicationPreferredName: string option
            AuthorizationCode: string option
            AuthorizationResponseCode: string option
            Brand: string option
            Country: string option
            CvmType: string option
            DataType: string option
            DedicatedFileName: string option
            Description: string option
            EmvAuthData: string option
            EvidenceCustomerSignature: string option
            EvidenceTransactionCertificate: string option
            ExpMonth: int64 option
            ExpYear: int64 option
            Fingerprint: string option
            Funding: string option
            Iin: string option
            Issuer: string option
            [<JsonField("last4")>]Last4: string option
            PosDeviceId: string option
            PosEntryMode: string option
            ReadMethod: string option
            Reader: string option
            TerminalVerificationResults: string option
            TransactionStatusInformation: string option
        }

    and SourceTypeEps =
        {
            Reference: string option
            StatementDescriptor: string option
        }

    and SourceTypeGiropay =
        {
            BankCode: string option
            BankName: string option
            Bic: string option
            StatementDescriptor: string option
        }

    and SourceTypeIdeal =
        {
            Bank: string option
            Bic: string option
            [<JsonField("iban_last4")>]IbanLast4: string option
            StatementDescriptor: string option
        }

    and SourceTypeKlarna =
        {
            BackgroundImageUrl: string option
            ClientToken: string option
            FirstName: string option
            LastName: string option
            Locale: string option
            LogoUrl: string option
            PageTitle: string option
            PayLaterAssetUrlsDescriptive: string option
            PayLaterAssetUrlsStandard: string option
            PayLaterName: string option
            PayLaterRedirectUrl: string option
            PayNowAssetUrlsDescriptive: string option
            PayNowAssetUrlsStandard: string option
            PayNowName: string option
            PayNowRedirectUrl: string option
            PayOverTimeAssetUrlsDescriptive: string option
            PayOverTimeAssetUrlsStandard: string option
            PayOverTimeName: string option
            PayOverTimeRedirectUrl: string option
            PaymentMethodCategories: string option
            PurchaseCountry: string option
            PurchaseType: string option
            RedirectUrl: string option
            ShippingDelay: int64 option
            ShippingFirstName: string option
            ShippingLastName: string option
        }

    and SourceTypeMultibanco =
        {
            Entity: string option
            Reference: string option
            RefundAccountHolderAddressCity: string option
            RefundAccountHolderAddressCountry: string option
            [<JsonField("refund_account_holder_address_line1")>]RefundAccountHolderAddressLine1: string option
            [<JsonField("refund_account_holder_address_line2")>]RefundAccountHolderAddressLine2: string option
            RefundAccountHolderAddressPostalCode: string option
            RefundAccountHolderAddressState: string option
            RefundAccountHolderName: string option
            RefundIban: string option
        }

    and SourceTypeP24 =
        {
            Reference: string option
        }

    and SourceTypeSepaCreditTransfer =
        {
            BankName: string option
            Bic: string option
            Iban: string option
            RefundAccountHolderAddressCity: string option
            RefundAccountHolderAddressCountry: string option
            [<JsonField("refund_account_holder_address_line1")>]RefundAccountHolderAddressLine1: string option
            [<JsonField("refund_account_holder_address_line2")>]RefundAccountHolderAddressLine2: string option
            RefundAccountHolderAddressPostalCode: string option
            RefundAccountHolderAddressState: string option
            RefundAccountHolderName: string option
            RefundIban: string option
        }

    and SourceTypeSepaDebit =
        {
            BankCode: string option
            BranchCode: string option
            Country: string option
            Fingerprint: string option
            [<JsonField("last4")>]Last4: string option
            MandateReference: string option
            MandateUrl: string option
        }

    and SourceTypeSofort =
        {
            BankCode: string option
            BankName: string option
            Bic: string option
            Country: string option
            [<JsonField("iban_last4")>]IbanLast4: string option
            PreferredLanguage: string option
            StatementDescriptor: string option
        }

    and SourceTypeThreeDSecure =
        {
            [<JsonField("address_line1_check")>]AddressLine1Check: string option
            AddressZipCheck: string option
            Authenticated: bool option
            Brand: string option
            Card: string option
            Country: string option
            Customer: string option
            CvcCheck: string option
            Description: string option
            [<JsonField("dynamic_last4")>]DynamicLast4: string option
            ExpMonth: int64 option
            ExpYear: int64 option
            Fingerprint: string option
            Funding: string option
            Iin: string option
            Issuer: string option
            [<JsonField("last4")>]Last4: string option
            Name: string option
            ThreeDSecure: string option
            TokenizationMethod: string option
        }

    and SourceTypeWechat =
        {
            PrepayId: string option
            QrCodeUrl: string option
            StatementDescriptor: string option
        }

    ///
    and StatusTransitions =
        {
            Canceled: int64 option
            Fulfiled: int64 option
            Paid: int64 option
            Returned: int64 option
        }

    ///Subscriptions allow you to charge a customer on a recurring basis.
    ///
    ///Related guide: [Creating Subscriptions](https://stripe.com/docs/billing/subscriptions/creating).
    and Subscription =
        {
            ApplicationFeePercent: decimal option
            BillingCycleAnchor: int64
            BillingThresholds: SubscriptionBillingThresholds option
            CancelAt: int64 option
            CancelAtPeriodEnd: bool
            CanceledAt: int64 option
            CollectionMethod: SubscriptionCollectionMethod option
            Created: int64
            CurrentPeriodEnd: int64
            CurrentPeriodStart: int64
            Customer: string
            DaysUntilDue: int64 option
            DefaultPaymentMethod: string option
            DefaultSource: string option
            DefaultTaxRates: TaxRate list option
            Discount: Discount option
            EndedAt: int64 option
            Id: string
            Items: Map<string, string>
            LatestInvoice: string option
            Livemode: bool
            Metadata: Map<string, string>
            NextPendingInvoiceItemInvoice: int64 option
            PauseCollection: SubscriptionsResourcePauseCollection option
            PendingInvoiceItemInterval: SubscriptionPendingInvoiceItemInterval option
            PendingSetupIntent: string option
            PendingUpdate: SubscriptionsResourcePendingUpdate option
            Schedule: string option
            StartDate: int64
            Status: SubscriptionStatus
            TransferData: SubscriptionTransferData option
            TrialEnd: int64 option
            TrialStart: int64 option
        }
        member _.Object = "subscription"

    and SubscriptionCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    and SubscriptionStatus =
        | Active
        | Canceled
        | Incomplete
        | IncompleteExpired
        | PastDue
        | Trialing
        | Unpaid

    ///
    and SubscriptionBillingThresholds =
        {
            AmountGte: int64 option
            ResetBillingCycleAnchor: bool option
        }

    ///Subscription items allow you to create customer subscriptions with more than
    ///one plan, making it easy to represent complex billing relationships.
    and SubscriptionItem =
        {
            BillingThresholds: SubscriptionItemBillingThresholds option
            Created: int64
            Id: string
            Metadata: Map<string, string>
            Plan: Plan
            Price: Price
            Quantity: int64 option
            Subscription: string
            TaxRates: TaxRate list option
        }
        member _.Object = "subscription_item"

    ///
    and SubscriptionItemBillingThresholds =
        {
            UsageGte: int64 option
        }

    ///
    and SubscriptionPendingInvoiceItemInterval =
        {
            Interval: SubscriptionPendingInvoiceItemIntervalInterval
            IntervalCount: int64
        }

    and SubscriptionPendingInvoiceItemIntervalInterval =
        | Day
        | Month
        | Week
        | Year

    ///A subscription schedule allows you to create and manage the lifecycle of a subscription by predefining expected changes.
    ///
    ///Related guide: [Subscription Schedules](https://stripe.com/docs/billing/subscriptions/subscription-schedules).
    and SubscriptionSchedule =
        {
            CanceledAt: int64 option
            CompletedAt: int64 option
            Created: int64
            CurrentPhase: SubscriptionScheduleCurrentPhase option
            Customer: string
            DefaultSettings: SubscriptionSchedulesResourceDefaultSettings
            EndBehavior: SubscriptionScheduleEndBehavior
            Id: string
            Livemode: bool
            Metadata: Map<string, string>
            Phases: SubscriptionSchedulePhaseConfiguration list
            ReleasedAt: int64 option
            ReleasedSubscription: string option
            Status: SubscriptionScheduleStatus
            Subscription: string option
        }
        member _.Object = "subscription_schedule"

    and SubscriptionScheduleEndBehavior =
        | Cancel
        | None'
        | Release
        | Renew

    and SubscriptionScheduleStatus =
        | Active
        | Canceled
        | Completed
        | NotStarted
        | Released

    ///An Add Invoice Item describes the prices and quantities that will be added as pending invoice items when entering a phase.
    and SubscriptionScheduleAddInvoiceItem =
        {
            Price: string
            Quantity: int64 option
            TaxRates: TaxRate list option
        }

    ///A phase item describes the price and quantity of a phase.
    and SubscriptionScheduleConfigurationItem =
        {
            BillingThresholds: SubscriptionItemBillingThresholds option
            Plan: string
            Price: string
            Quantity: int64 option
            TaxRates: TaxRate list option
        }

    ///
    and SubscriptionScheduleCurrentPhase =
        {
            EndDate: int64
            StartDate: int64
        }

    ///A phase describes the plans, coupon, and trialing status of a subscription for a predefined time period.
    and SubscriptionSchedulePhaseConfiguration =
        {
            AddInvoiceItems: SubscriptionScheduleAddInvoiceItem list
            ApplicationFeePercent: decimal option
            BillingCycleAnchor: SubscriptionSchedulePhaseConfigurationBillingCycleAnchor option
            BillingThresholds: SubscriptionBillingThresholds option
            CollectionMethod: SubscriptionSchedulePhaseConfigurationCollectionMethod option
            Coupon: string option
            DefaultPaymentMethod: string option
            DefaultTaxRates: TaxRate list option
            EndDate: int64
            InvoiceSettings: InvoiceSettingSubscriptionScheduleSetting option
            Items: SubscriptionScheduleConfigurationItem list
            ProrationBehavior: SubscriptionSchedulePhaseConfigurationProrationBehavior
            StartDate: int64
            TransferData: SubscriptionTransferData option
            TrialEnd: int64 option
        }

    and SubscriptionSchedulePhaseConfigurationBillingCycleAnchor =
        | Automatic
        | PhaseStart

    and SubscriptionSchedulePhaseConfigurationCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    and SubscriptionSchedulePhaseConfigurationProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | None'

    ///
    and SubscriptionSchedulesResourceDefaultSettings =
        {
            BillingCycleAnchor: SubscriptionSchedulesResourceDefaultSettingsBillingCycleAnchor
            BillingThresholds: SubscriptionBillingThresholds option
            CollectionMethod: SubscriptionSchedulesResourceDefaultSettingsCollectionMethod option
            DefaultPaymentMethod: string option
            InvoiceSettings: InvoiceSettingSubscriptionScheduleSetting option
            TransferData: SubscriptionTransferData option
        }

    and SubscriptionSchedulesResourceDefaultSettingsBillingCycleAnchor =
        | Automatic
        | PhaseStart

    and SubscriptionSchedulesResourceDefaultSettingsCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    ///
    and SubscriptionTransferData =
        {
            AmountPercent: decimal option
            Destination: string
        }

    ///The Pause Collection settings determine how we will pause collection for this subscription and for how long the subscription
    ///should be paused.
    and SubscriptionsResourcePauseCollection =
        {
            Behavior: SubscriptionsResourcePauseCollectionBehavior
            ResumesAt: int64 option
        }

    and SubscriptionsResourcePauseCollectionBehavior =
        | KeepAsDraft
        | MarkUncollectible
        | Void

    ///Pending Updates store the changes pending from a previous update that will be applied
    ///to the Subscription upon successful payment.
    and SubscriptionsResourcePendingUpdate =
        {
            BillingCycleAnchor: int64 option
            ExpiresAt: int64
            SubscriptionItems: SubscriptionItem list option
            TrialEnd: int64 option
            TrialFromPlan: bool option
        }

    ///
    and TaxDeductedAtSource =
        {
            Id: string
            PeriodEnd: int64
            PeriodStart: int64
            TaxDeductionAccountNumber: string
        }
        member _.Object = "tax_deducted_at_source"

    ///You can add one or multiple tax IDs to a [customer](https://stripe.com/docs/api/customers).
    ///A customer's tax IDs are displayed on invoices and credit notes issued for the customer.
    ///
    ///Related guide: [Customer Tax Identification Numbers](https://stripe.com/docs/billing/taxes/tax-ids).
    and TaxId =
        {
            Country: string option
            Created: int64
            Customer: string option
            Id: string
            Livemode: bool
            Type: TaxIdType
            Value: string
            Verification: TaxIdVerification option
        }
        member _.Object = "tax_id"

    and TaxIdType =
        | AeTrn
        | AuAbn
        | BrCnpj
        | BrCpf
        | CaBn
        | CaQst
        | ChVat
        | ClTin
        | EsCif
        | EuVat
        | HkBr
        | IdNpwp
        | InGst
        | JpCn
        | JpRn
        | KrBrn
        | LiUid
        | MxRfc
        | MyFrp
        | MyItn
        | MySst
        | NoVat
        | NzGst
        | RuInn
        | RuKpp
        | SaVat
        | SgGst
        | SgUen
        | ThVat
        | TwVat
        | Unknown
        | UsEin
        | ZaVat

    ///
    and TaxIdVerification =
        {
            Status: TaxIdVerificationStatus
            VerifiedAddress: string option
            VerifiedName: string option
        }

    and TaxIdVerificationStatus =
        | Pending
        | Unavailable
        | Unverified
        | Verified

    ///Tax rates can be applied to [invoices](https://stripe.com/docs/billing/invoices/tax-rates), [subscriptions](https://stripe.com/docs/billing/subscriptions/taxes) and [Checkout Sessions](https://stripe.com/docs/payments/checkout/set-up-a-subscription#tax-rates) to collect tax.
    ///
    ///Related guide: [Tax Rates](https://stripe.com/docs/billing/taxes/tax-rates).
    and TaxRate =
        {
            Active: bool
            Created: int64
            Description: string option
            DisplayName: string
            Id: string
            Inclusive: bool
            Jurisdiction: string option
            Livemode: bool
            Metadata: Map<string, string>
            Percentage: decimal
        }
        member _.Object = "tax_rate"

    ///A Connection Token is used by the Stripe Terminal SDK to connect to a reader.
    ///
    ///Related guide: [Fleet Management](https://stripe.com/docs/terminal/readers/fleet-management#create).
    and TerminalConnectionToken =
        {
            Location: string option
            Secret: string
        }
        member _.Object = "terminal.connection_token"

    ///A Location represents a grouping of readers.
    ///
    ///Related guide: [Fleet Management](https://stripe.com/docs/terminal/readers/fleet-management#create).
    and TerminalLocation =
        {
            Address: Address
            DisplayName: string
            Id: string
            Livemode: bool
            Metadata: Map<string, string>
        }
        member _.Object = "terminal.location"

    ///A Reader represents a physical device for accepting payment details.
    ///
    ///Related guide: [Connecting to a Reader](https://stripe.com/docs/terminal/readers/connecting).
    and TerminalReader =
        {
            DeviceSwVersion: string option
            DeviceType: TerminalReaderDeviceType
            Id: string
            IpAddress: string option
            Label: string
            Livemode: bool
            Location: string option
            Metadata: Map<string, string>
            SerialNumber: string
            Status: string option
        }
        member _.Object = "terminal.reader"

    and TerminalReaderDeviceType =
        | BbposChipper2x
        | VerifoneP400

    ///Cardholder authentication via 3D Secure is initiated by creating a `3D Secure`
    ///object. Once the object has been created, you can use it to authenticate the
    ///cardholder and create a charge.
    and ThreeDSecure =
        {
            Amount: int64
            Authenticated: bool
            Card: Card
            Created: int64
            Currency: string
            Id: string
            Livemode: bool
            RedirectUrl: string option
            Status: string
        }
        member _.Object = "three_d_secure"

    ///
    and ThreeDSecureDetails =
        {
            AuthenticationFlow: ThreeDSecureDetailsAuthenticationFlow option
            Result: ThreeDSecureDetailsResult
            ResultReason: ThreeDSecureDetailsResultReason option
            Version: ThreeDSecureDetailsVersion
        }

    and ThreeDSecureDetailsAuthenticationFlow =
        | Challenge
        | Frictionless

    and ThreeDSecureDetailsResult =
        | AttemptAcknowledged
        | Authenticated
        | Failed
        | NotSupported
        | ProcessingError

    and ThreeDSecureDetailsResultReason =
        | Abandoned
        | Bypassed
        | Canceled
        | CardNotEnrolled
        | NetworkNotSupported
        | ProtocolError
        | Rejected

    and ThreeDSecureDetailsVersion =
        | [<JsonUnionCase("1.0.2")>] Numeric102
        | [<JsonUnionCase("2.1.0")>] Numeric210
        | [<JsonUnionCase("2.2.0")>] Numeric220

    ///
    and ThreeDSecureUsage =
        {
            Supported: bool
        }

    ///Tokenization is the process Stripe uses to collect sensitive card or bank
    ///account details, or personally identifiable information (PII), directly from
    ///your customers in a secure manner. A token representing this information is
    ///returned to your server to use. You should use our
    ///[recommended payments integrations](https://stripe.com/docs/payments) to perform this process
    ///client-side. This ensures that no sensitive card data touches your server,
    ///and allows your integration to operate in a PCI-compliant way.
    ///
    ///If you cannot use client-side tokenization, you can also create tokens using
    ///the API with either your publishable or secret API key. Keep in mind that if
    ///your integration uses this method, you are responsible for any PCI compliance
    ///that may be required, and you must keep your secret API key safe. Unlike with
    ///client-side tokenization, your customer's information is not sent directly to
    ///Stripe, so we cannot determine how it is handled or stored.
    ///
    ///Tokens cannot be stored or used more than once. To store card or bank account
    ///information for later use, you can create [Customer](https://stripe.com/docs/api#customers)
    ///objects or [Custom accounts](https://stripe.com/docs/api#external_accounts). Note that
    ///[Radar](https://stripe.com/docs/radar), our integrated solution for automatic fraud protection,
    ///supports only integrations that use client-side tokenization.
    ///
    ///Related guide: [Accept a payment](https://stripe.com/docs/payments/accept-a-payment-charges#web-create-token)
    and Token =
        {
            BankAccount: BankAccount option
            Card: Card option
            ClientIp: string option
            Created: int64
            Id: string
            Livemode: bool
            Type: string
            Used: bool
        }
        member _.Object = "token"

    ///To top up your Stripe balance, you create a top-up object. You can retrieve
    ///individual top-ups, as well as list all top-ups. Top-ups are identified by a
    ///unique, random ID.
    ///
    ///Related guide: [Topping Up your Platform Account](https://stripe.com/docs/connect/top-ups).
    and Topup =
        {
            Amount: int64
            BalanceTransaction: string option
            Created: int64
            Currency: string
            Description: string option
            ExpectedAvailabilityDate: int64 option
            FailureCode: string option
            FailureMessage: string option
            Id: string
            Livemode: bool
            Metadata: Map<string, string>
            Source: Source
            StatementDescriptor: string option
            Status: TopupStatus
            TransferGroup: string option
        }
        member _.Object = "topup"

    and TopupStatus =
        | Canceled
        | Failed
        | Pending
        | Reversed
        | Succeeded

    ///A `Transfer` object is created when you move funds between Stripe accounts as
    ///part of Connect.
    ///
    ///Before April 6, 2017, transfers also represented movement of funds from a
    ///Stripe account to a card or bank account. This behavior has since been split
    ///out into a [Payout](https://stripe.com/docs/api#payout_object) object, with corresponding payout endpoints. For more
    ///information, read about the
    ///[transfer/payout split](https://stripe.com/docs/transfer-payout-split).
    ///
    ///Related guide: [Creating Separate Charges and Transfers](https://stripe.com/docs/connect/charges-transfers).
    and Transfer =
        {
            Amount: int64
            AmountReversed: int64
            BalanceTransaction: string option
            Created: int64
            Currency: string
            Description: string option
            Destination: string option
            DestinationPayment: string option
            Id: string
            Livemode: bool
            Metadata: Map<string, string>
            Reversals: Map<string, string>
            Reversed: bool
            SourceTransaction: string option
            SourceType: string option
            TransferGroup: string option
        }
        member _.Object = "transfer"

    ///
    and TransferData =
        {
            Amount: int64 option
            Destination: string
        }

    ///[Stripe Connect](https://stripe.com/docs/connect) platforms can reverse transfers made to a
    ///connected account, either entirely or partially, and can also specify whether
    ///to refund any related application fees. Transfer reversals add to the
    ///platform's balance and subtract from the destination account's balance.
    ///
    ///Reversing a transfer that was made for a [destination
    ///charge](/docs/connect/destination-charges) is allowed only up to the amount of
    ///the charge. It is possible to reverse a
    ///[transfer_group](https://stripe.com/docs/connect/charges-transfers#transfer-options)
    ///transfer only if the destination account has enough balance to cover the
    ///reversal.
    ///
    ///Related guide: [Reversing Transfers](https://stripe.com/docs/connect/charges-transfers#reversing-transfers).
    and TransferReversal =
        {
            Amount: int64
            BalanceTransaction: string option
            Created: int64
            Currency: string
            DestinationPaymentRefund: string option
            Id: string
            Metadata: Map<string, string>
            SourceRefund: string option
            Transfer: string
        }
        member _.Object = "transfer_reversal"

    ///
    and TransferSchedule =
        {
            DelayDays: int64
            Interval: string
            MonthlyAnchor: int64 option
            WeeklyAnchor: string option
        }

    ///
    and TransformQuantity =
        {
            DivideBy: int64
            Round: TransformQuantityRound
        }

    and TransformQuantityRound =
        | Down
        | Up

    ///
    and TransformUsage =
        {
            DivideBy: int64
            Round: TransformUsageRound
        }

    and TransformUsageRound =
        | Down
        | Up

    ///Usage records allow you to report customer usage and metrics to Stripe for
    ///metered billing of subscription prices.
    ///
    ///Related guide: [Metered Billing](https://stripe.com/docs/billing/subscriptions/metered-billing).
    and UsageRecord =
        {
            Id: string
            Livemode: bool
            Quantity: int64
            SubscriptionItem: string
            Timestamp: int64
        }
        member _.Object = "usage_record"

    ///
    and UsageRecordSummary =
        {
            Id: string
            Invoice: string option
            Livemode: bool
            Period: Period
            SubscriptionItem: string
            TotalUsage: int64
        }
        member _.Object = "usage_record_summary"

    ///You can configure [webhook endpoints](https://stripe.com/docs/webhooks/) via the API to be
    ///notified about events that happen in your Stripe account or connected
    ///accounts.
    ///
    ///Most users configure webhooks from [the dashboard](https://dashboard.stripe.com/webhooks), which provides a user interface for registering and testing your webhook endpoints.
    ///
    ///Related guide: [Setting up Webhooks](https://stripe.com/docs/webhooks/configure).
    and WebhookEndpoint =
        {
            ApiVersion: string option
            Application: string option
            Created: int64
            Description: string option
            EnabledEvents: string list
            Id: string
            Livemode: bool
            Metadata: Map<string, string>
            Secret: string option
            Status: string
            Url: string
        }
        member _.Object = "webhook_endpoint"

