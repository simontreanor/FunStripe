namespace FunStripe

open FSharp.Json

module StripeModel =

    ///This is an object representing a Stripe account. You can retrieve it to see
    ///properties on the account like its current e-mail address or if the account is
    ///enabled yet to make live charges.
    ///
    ///Some properties, marked below, are available only to platforms that want to
    ///[create and manage Express or Custom accounts](https://stripe.com/docs/connect/accounts).
    type Account (id: string, object: AccountObject, ?businessProfile: AccountBusinessProfile option, ?businessType: AccountBusinessType option, ?capabilities: AccountCapabilities, ?chargesEnabled: bool, ?company: LegalEntityCompany, ?country: string, ?created: int, ?defaultCurrency: string, ?detailsSubmitted: bool, ?email: string option, ?externalAccounts: Map<string, string>, ?individual: Person, ?metadata: Map<string, string>, ?payoutsEnabled: bool, ?requirements: AccountRequirements, ?settings: AccountSettings option, ?tosAcceptance: AccountTosAcceptance, ?``type``: AccountType) =

        member _.BusinessProfile = businessProfile |> Option.flatten
        member _.BusinessType = businessType |> Option.flatten
        member _.Capabilities = capabilities
        member _.ChargesEnabled = chargesEnabled
        member _.Company = company
        member _.Country = country
        member _.Created = created
        member _.DefaultCurrency = defaultCurrency
        member _.DetailsSubmitted = detailsSubmitted
        member _.Email = email |> Option.flatten
        member _.ExternalAccounts = externalAccounts
        member _.Id = id
        member _.Individual = individual
        member _.Metadata = metadata
        member _.Object = object
        member _.PayoutsEnabled = payoutsEnabled
        member _.Requirements = requirements
        member _.Settings = settings |> Option.flatten
        member _.TosAcceptance = tosAcceptance
        member _.Type = ``type``

    and AccountBusinessType =
        | AccountBusinessType'Company
        | AccountBusinessType'GovernmentEntity
        | AccountBusinessType'Individual
        | AccountBusinessType'NonProfit

    and AccountObject =
        | AccountObject'Account

    and AccountType =
        | AccountType'Custom
        | AccountType'Express
        | AccountType'Standard

    ///
    and AccountBacsDebitPaymentsSettings (?displayName: string) =

        member _.DisplayName = displayName

    ///
    and AccountBrandingSettings (icon: AccountBrandingSettingsIconDU option, logo: AccountBrandingSettingsLogoDU option, primaryColor: string option, secondaryColor: string option) =

        member _.Icon = icon
        member _.Logo = logo
        member _.PrimaryColor = primaryColor
        member _.SecondaryColor = secondaryColor

    and AccountBrandingSettingsIconDU =
        | AccountBrandingSettingsIconDU'String of string
        | AccountBrandingSettingsIconDU'File of File

    and AccountBrandingSettingsLogoDU =
        | AccountBrandingSettingsLogoDU'String of string
        | AccountBrandingSettingsLogoDU'File of File

    ///
    and AccountBusinessProfile (mcc: string option, name: string option, supportAddress: Address option, supportEmail: string option, supportPhone: string option, supportUrl: string option, url: string option, ?productDescription: string option) =

        member _.Mcc = mcc
        member _.Name = name
        member _.ProductDescription = productDescription |> Option.flatten
        member _.SupportAddress = supportAddress
        member _.SupportEmail = supportEmail
        member _.SupportPhone = supportPhone
        member _.SupportUrl = supportUrl
        member _.Url = url

    ///
    and AccountCapabilities (?auBecsDebitPayments: AccountCapabilitiesAuBecsDebitPayments, ?bacsDebitPayments: AccountCapabilitiesBacsDebitPayments, ?bancontactPayments: AccountCapabilitiesBancontactPayments, ?cardIssuing: AccountCapabilitiesCardIssuing, ?cardPayments: AccountCapabilitiesCardPayments, ?cartesBancairesPayments: AccountCapabilitiesCartesBancairesPayments, ?epsPayments: AccountCapabilitiesEpsPayments, ?fpxPayments: AccountCapabilitiesFpxPayments, ?giropayPayments: AccountCapabilitiesGiropayPayments, ?grabpayPayments: AccountCapabilitiesGrabpayPayments, ?idealPayments: AccountCapabilitiesIdealPayments, ?jcbPayments: AccountCapabilitiesJcbPayments, ?legacyPayments: AccountCapabilitiesLegacyPayments, ?oxxoPayments: AccountCapabilitiesOxxoPayments, ?p24Payments: AccountCapabilitiesP24Payments, ?sepaDebitPayments: AccountCapabilitiesSepaDebitPayments, ?sofortPayments: AccountCapabilitiesSofortPayments, ?taxReportingUs1099K: AccountCapabilitiesTaxReportingUs1099K, ?taxReportingUs1099Misc: AccountCapabilitiesTaxReportingUs1099Misc, ?transfers: AccountCapabilitiesTransfers) =

        member _.AuBecsDebitPayments = auBecsDebitPayments
        member _.BacsDebitPayments = bacsDebitPayments
        member _.BancontactPayments = bancontactPayments
        member _.CardIssuing = cardIssuing
        member _.CardPayments = cardPayments
        member _.CartesBancairesPayments = cartesBancairesPayments
        member _.EpsPayments = epsPayments
        member _.FpxPayments = fpxPayments
        member _.GiropayPayments = giropayPayments
        member _.GrabpayPayments = grabpayPayments
        member _.IdealPayments = idealPayments
        member _.JcbPayments = jcbPayments
        member _.LegacyPayments = legacyPayments
        member _.OxxoPayments = oxxoPayments
        member _.P24Payments = p24Payments
        member _.SepaDebitPayments = sepaDebitPayments
        member _.SofortPayments = sofortPayments
        member _.TaxReportingUs1099K = taxReportingUs1099K
        member _.TaxReportingUs1099Misc = taxReportingUs1099Misc
        member _.Transfers = transfers

    and AccountCapabilitiesAuBecsDebitPayments =
        | AccountCapabilitiesAuBecsDebitPayments'Active
        | AccountCapabilitiesAuBecsDebitPayments'Inactive
        | AccountCapabilitiesAuBecsDebitPayments'Pending

    and AccountCapabilitiesBacsDebitPayments =
        | AccountCapabilitiesBacsDebitPayments'Active
        | AccountCapabilitiesBacsDebitPayments'Inactive
        | AccountCapabilitiesBacsDebitPayments'Pending

    and AccountCapabilitiesBancontactPayments =
        | AccountCapabilitiesBancontactPayments'Active
        | AccountCapabilitiesBancontactPayments'Inactive
        | AccountCapabilitiesBancontactPayments'Pending

    and AccountCapabilitiesCardIssuing =
        | AccountCapabilitiesCardIssuing'Active
        | AccountCapabilitiesCardIssuing'Inactive
        | AccountCapabilitiesCardIssuing'Pending

    and AccountCapabilitiesCardPayments =
        | AccountCapabilitiesCardPayments'Active
        | AccountCapabilitiesCardPayments'Inactive
        | AccountCapabilitiesCardPayments'Pending

    and AccountCapabilitiesCartesBancairesPayments =
        | AccountCapabilitiesCartesBancairesPayments'Active
        | AccountCapabilitiesCartesBancairesPayments'Inactive
        | AccountCapabilitiesCartesBancairesPayments'Pending

    and AccountCapabilitiesEpsPayments =
        | AccountCapabilitiesEpsPayments'Active
        | AccountCapabilitiesEpsPayments'Inactive
        | AccountCapabilitiesEpsPayments'Pending

    and AccountCapabilitiesFpxPayments =
        | AccountCapabilitiesFpxPayments'Active
        | AccountCapabilitiesFpxPayments'Inactive
        | AccountCapabilitiesFpxPayments'Pending

    and AccountCapabilitiesGiropayPayments =
        | AccountCapabilitiesGiropayPayments'Active
        | AccountCapabilitiesGiropayPayments'Inactive
        | AccountCapabilitiesGiropayPayments'Pending

    and AccountCapabilitiesGrabpayPayments =
        | AccountCapabilitiesGrabpayPayments'Active
        | AccountCapabilitiesGrabpayPayments'Inactive
        | AccountCapabilitiesGrabpayPayments'Pending

    and AccountCapabilitiesIdealPayments =
        | AccountCapabilitiesIdealPayments'Active
        | AccountCapabilitiesIdealPayments'Inactive
        | AccountCapabilitiesIdealPayments'Pending

    and AccountCapabilitiesJcbPayments =
        | AccountCapabilitiesJcbPayments'Active
        | AccountCapabilitiesJcbPayments'Inactive
        | AccountCapabilitiesJcbPayments'Pending

    and AccountCapabilitiesLegacyPayments =
        | AccountCapabilitiesLegacyPayments'Active
        | AccountCapabilitiesLegacyPayments'Inactive
        | AccountCapabilitiesLegacyPayments'Pending

    and AccountCapabilitiesOxxoPayments =
        | AccountCapabilitiesOxxoPayments'Active
        | AccountCapabilitiesOxxoPayments'Inactive
        | AccountCapabilitiesOxxoPayments'Pending

    and AccountCapabilitiesP24Payments =
        | AccountCapabilitiesP24Payments'Active
        | AccountCapabilitiesP24Payments'Inactive
        | AccountCapabilitiesP24Payments'Pending

    and AccountCapabilitiesSepaDebitPayments =
        | AccountCapabilitiesSepaDebitPayments'Active
        | AccountCapabilitiesSepaDebitPayments'Inactive
        | AccountCapabilitiesSepaDebitPayments'Pending

    and AccountCapabilitiesSofortPayments =
        | AccountCapabilitiesSofortPayments'Active
        | AccountCapabilitiesSofortPayments'Inactive
        | AccountCapabilitiesSofortPayments'Pending

    and AccountCapabilitiesTaxReportingUs1099K =
        | AccountCapabilitiesTaxReportingUs1099K'Active
        | AccountCapabilitiesTaxReportingUs1099K'Inactive
        | AccountCapabilitiesTaxReportingUs1099K'Pending

    and AccountCapabilitiesTaxReportingUs1099Misc =
        | AccountCapabilitiesTaxReportingUs1099Misc'Active
        | AccountCapabilitiesTaxReportingUs1099Misc'Inactive
        | AccountCapabilitiesTaxReportingUs1099Misc'Pending

    and AccountCapabilitiesTransfers =
        | AccountCapabilitiesTransfers'Active
        | AccountCapabilitiesTransfers'Inactive
        | AccountCapabilitiesTransfers'Pending

    ///
    and AccountCapabilityRequirements (currentDeadline: int option, currentlyDue: string list, disabledReason: string option, errors: AccountRequirementsError list, eventuallyDue: string list, pastDue: string list, pendingVerification: string list) =

        member _.CurrentDeadline = currentDeadline
        member _.CurrentlyDue = currentlyDue
        member _.DisabledReason = disabledReason
        member _.Errors = errors
        member _.EventuallyDue = eventuallyDue
        member _.PastDue = pastDue
        member _.PendingVerification = pendingVerification

    ///
    and AccountCardPaymentsSettings (statementDescriptorPrefix: string option, ?declineOn: AccountDeclineChargeOn) =

        member _.DeclineOn = declineOn
        member _.StatementDescriptorPrefix = statementDescriptorPrefix

    ///
    and AccountDashboardSettings (displayName: string option, timezone: string option) =

        member _.DisplayName = displayName
        member _.Timezone = timezone

    ///
    and AccountDeclineChargeOn (avsFailure: bool, cvcFailure: bool) =

        member _.AvsFailure = avsFailure
        member _.CvcFailure = cvcFailure

    ///Account Links are the means by which a Connect platform grants a connected account permission to access
    ///Stripe-hosted applications, such as Connect Onboarding.
    ///
    ///Related guide: [Connect Onboarding](https://stripe.com/docs/connect/connect-onboarding).
    and AccountLink (created: int, expiresAt: int, object: AccountLinkObject, url: string) =

        member _.Created = created
        member _.ExpiresAt = expiresAt
        member _.Object = object
        member _.Url = url

    and AccountLinkObject =
        | AccountLinkObject'AccountLink

    ///
    and AccountPaymentsSettings (statementDescriptor: string option, statementDescriptorKana: string option, statementDescriptorKanji: string option) =

        member _.StatementDescriptor = statementDescriptor
        member _.StatementDescriptorKana = statementDescriptorKana
        member _.StatementDescriptorKanji = statementDescriptorKanji

    ///
    and AccountPayoutSettings (debitNegativeBalances: bool, schedule: TransferSchedule, statementDescriptor: string option) =

        member _.DebitNegativeBalances = debitNegativeBalances
        member _.Schedule = schedule
        member _.StatementDescriptor = statementDescriptor

    ///
    and AccountRequirements (currentDeadline: int option, currentlyDue: string list option, disabledReason: AccountRequirementsDisabledReason option, errors: AccountRequirementsError list option, eventuallyDue: string list option, pastDue: string list option, pendingVerification: string list option) =

        member _.CurrentDeadline = currentDeadline
        member _.CurrentlyDue = currentlyDue
        member _.DisabledReason = disabledReason
        member _.Errors = errors
        member _.EventuallyDue = eventuallyDue
        member _.PastDue = pastDue
        member _.PendingVerification = pendingVerification

    and AccountRequirementsDisabledReason =
        | AccountRequirementsDisabledReason'RequirementsPastDue
        | AccountRequirementsDisabledReason'RequirementsPendingVerification
        | AccountRequirementsDisabledReason'RejectedFraud
        | AccountRequirementsDisabledReason'RejectedTermsOfService
        | AccountRequirementsDisabledReason'RejectedListed
        | AccountRequirementsDisabledReason'RejectedOther
        | AccountRequirementsDisabledReason'Listed
        | AccountRequirementsDisabledReason'UnderReview
        | AccountRequirementsDisabledReason'Other

    ///
    and AccountRequirementsError (code: AccountRequirementsErrorCode, reason: string, requirement: string) =

        member _.Code = code
        member _.Reason = reason
        member _.Requirement = requirement

    and AccountRequirementsErrorCode =
        | AccountRequirementsErrorCode'InvalidAddressCityStatePostalCode
        | AccountRequirementsErrorCode'InvalidStreetAddress
        | AccountRequirementsErrorCode'InvalidValueOther
        | AccountRequirementsErrorCode'VerificationDocumentAddressMismatch
        | AccountRequirementsErrorCode'VerificationDocumentAddressMissing
        | AccountRequirementsErrorCode'VerificationDocumentCorrupt
        | AccountRequirementsErrorCode'VerificationDocumentCountryNotSupported
        | AccountRequirementsErrorCode'VerificationDocumentDobMismatch
        | AccountRequirementsErrorCode'VerificationDocumentDuplicateType
        | AccountRequirementsErrorCode'VerificationDocumentExpired
        | AccountRequirementsErrorCode'VerificationDocumentFailedCopy
        | AccountRequirementsErrorCode'VerificationDocumentFailedGreyscale
        | AccountRequirementsErrorCode'VerificationDocumentFailedOther
        | AccountRequirementsErrorCode'VerificationDocumentFailedTestMode
        | AccountRequirementsErrorCode'VerificationDocumentFraudulent
        | AccountRequirementsErrorCode'VerificationDocumentIdNumberMismatch
        | AccountRequirementsErrorCode'VerificationDocumentIdNumberMissing
        | AccountRequirementsErrorCode'VerificationDocumentIncomplete
        | AccountRequirementsErrorCode'VerificationDocumentInvalid
        | AccountRequirementsErrorCode'VerificationDocumentIssueOrExpiryDateMissing
        | AccountRequirementsErrorCode'VerificationDocumentManipulated
        | AccountRequirementsErrorCode'VerificationDocumentMissingBack
        | AccountRequirementsErrorCode'VerificationDocumentMissingFront
        | AccountRequirementsErrorCode'VerificationDocumentNameMismatch
        | AccountRequirementsErrorCode'VerificationDocumentNameMissing
        | AccountRequirementsErrorCode'VerificationDocumentNationalityMismatch
        | AccountRequirementsErrorCode'VerificationDocumentNotReadable
        | AccountRequirementsErrorCode'VerificationDocumentNotSigned
        | AccountRequirementsErrorCode'VerificationDocumentNotUploaded
        | AccountRequirementsErrorCode'VerificationDocumentPhotoMismatch
        | AccountRequirementsErrorCode'VerificationDocumentTooLarge
        | AccountRequirementsErrorCode'VerificationDocumentTypeNotSupported
        | AccountRequirementsErrorCode'VerificationFailedAddressMatch
        | AccountRequirementsErrorCode'VerificationFailedBusinessIecNumber
        | AccountRequirementsErrorCode'VerificationFailedDocumentMatch
        | AccountRequirementsErrorCode'VerificationFailedIdNumberMatch
        | AccountRequirementsErrorCode'VerificationFailedKeyedIdentity
        | AccountRequirementsErrorCode'VerificationFailedKeyedMatch
        | AccountRequirementsErrorCode'VerificationFailedNameMatch
        | AccountRequirementsErrorCode'VerificationFailedOther
        | AccountRequirementsErrorCode'VerificationFailedTaxIdMatch
        | AccountRequirementsErrorCode'VerificationFailedTaxIdNotIssued

    ///
    and AccountSepaDebitPaymentsSettings (?creditorId: string) =

        member _.CreditorId = creditorId

    ///
    and AccountSettings (branding: AccountBrandingSettings, cardPayments: AccountCardPaymentsSettings, dashboard: AccountDashboardSettings, payments: AccountPaymentsSettings, ?bacsDebitPayments: AccountBacsDebitPaymentsSettings, ?payouts: AccountPayoutSettings, ?sepaDebitPayments: AccountSepaDebitPaymentsSettings) =

        member _.BacsDebitPayments = bacsDebitPayments
        member _.Branding = branding
        member _.CardPayments = cardPayments
        member _.Dashboard = dashboard
        member _.Payments = payments
        member _.Payouts = payouts
        member _.SepaDebitPayments = sepaDebitPayments

    ///
    and AccountTosAcceptance (?date: int option, ?ip: string option, ?serviceAgreement: string, ?userAgent: string option) =

        member _.Date = date |> Option.flatten
        member _.Ip = ip |> Option.flatten
        member _.ServiceAgreement = serviceAgreement
        member _.UserAgent = userAgent |> Option.flatten

    ///
    and Address (city: string option, country: string option, line1: string option, line2: string option, postalCode: string option, state: string option) =

        member _.City = city
        member _.Country = country
        member _.Line1 = line1
        member _.Line2 = line2
        member _.PostalCode = postalCode
        member _.State = state

    ///
    and AlipayAccount (created: int, fingerprint: string, id: string, livemode: bool, object: AlipayAccountObject, paymentAmount: int option, paymentCurrency: string option, reusable: bool, used: bool, username: string, ?customer: Choice<string, Customer, DeletedCustomer, File> option, ?metadata: Map<string, string>) =

        member _.Created = created
        member _.Customer = customer |> Option.flatten
        member _.Fingerprint = fingerprint
        member _.Id = id
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Object = object
        member _.PaymentAmount = paymentAmount
        member _.PaymentCurrency = paymentCurrency
        member _.Reusable = reusable
        member _.Used = used
        member _.Username = username

    and AlipayAccountObject =
        | AlipayAccountObject'AlipayAccount

    and AlipayAccountCustomerDU =
        | AlipayAccountCustomerDU'String of string
        | AlipayAccountCustomerDU'Customer of Customer
        | AlipayAccountCustomerDU'DeletedCustomer of DeletedCustomer

    ///
    and AlternateStatementDescriptors (?kana: string, ?kanji: string) =

        member _.Kana = kana
        member _.Kanji = kanji

    ///
    and ApiErrors (``type``: ApiErrorsType, ?charge: string, ?code: string, ?declineCode: string, ?docUrl: string, ?message: string, ?param: string, ?paymentIntent: PaymentIntent, ?paymentMethod: PaymentMethod, ?paymentMethodType: string, ?setupIntent: SetupIntent, ?source: PaymentSource) =

        member _.Charge = charge
        member _.Code = code
        member _.DeclineCode = declineCode
        member _.DocUrl = docUrl
        member _.Message = message
        member _.Param = param
        member _.PaymentIntent = paymentIntent
        member _.PaymentMethod = paymentMethod
        member _.PaymentMethodType = paymentMethodType
        member _.SetupIntent = setupIntent
        member _.Source = source
        member _.Type = ``type``

    and ApiErrorsType =
        | ApiErrorsType'ApiConnectionError
        | ApiErrorsType'ApiError
        | ApiErrorsType'AuthenticationError
        | ApiErrorsType'CardError
        | ApiErrorsType'IdempotencyError
        | ApiErrorsType'InvalidRequestError
        | ApiErrorsType'RateLimitError

    ///
    and ApplePayDomain (created: int, domainName: string, id: string, livemode: bool, object: ApplePayDomainObject) =

        member _.Created = created
        member _.DomainName = domainName
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = object

    and ApplePayDomainObject =
        | ApplePayDomainObject'ApplePayDomain

    ///
    and Application (id: string, name: string option, object: ApplicationObject) =

        member _.Id = id
        member _.Name = name
        member _.Object = object

    and ApplicationObject =
        | ApplicationObject'Application

    ///
    and ApplicationFee (account: ApplicationFeeAccountDU, amount: int, amountRefunded: int, application: ApplicationFeeApplicationDU, balanceTransaction: ApplicationFeeBalanceTransactionDU option, charge: ApplicationFeeChargeDU, created: int, currency: string, id: string, livemode: bool, object: ApplicationFeeObject, originatingTransaction: ApplicationFeeOriginatingTransactionDU option, refunded: bool, refunds: Map<string, string>) =

        member _.Account = account
        member _.Amount = amount
        member _.AmountRefunded = amountRefunded
        member _.Application = application
        member _.BalanceTransaction = balanceTransaction
        member _.Charge = charge
        member _.Created = created
        member _.Currency = currency
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = object
        member _.OriginatingTransaction = originatingTransaction
        member _.Refunded = refunded
        member _.Refunds = refunds

    and ApplicationFeeObject =
        | ApplicationFeeObject'ApplicationFee

    and ApplicationFeeAccountDU =
        | ApplicationFeeAccountDU'String of string
        | ApplicationFeeAccountDU'Account of Account

    and ApplicationFeeApplicationDU =
        | ApplicationFeeApplicationDU'String of string
        | ApplicationFeeApplicationDU'Application of Application

    and ApplicationFeeBalanceTransactionDU =
        | ApplicationFeeBalanceTransactionDU'String of string
        | ApplicationFeeBalanceTransactionDU'BalanceTransaction of BalanceTransaction

    and ApplicationFeeChargeDU =
        | ApplicationFeeChargeDU'String of string
        | ApplicationFeeChargeDU'Charge of Charge

    and ApplicationFeeOriginatingTransactionDU =
        | ApplicationFeeOriginatingTransactionDU'String of string
        | ApplicationFeeOriginatingTransactionDU'Charge of Charge

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
    and Balance (available: BalanceAmount list, livemode: bool, object: BalanceObject, pending: BalanceAmount list, ?connectReserved: BalanceAmount list, ?instantAvailable: BalanceAmount list, ?issuing: BalanceDetail) =

        member _.Available = available
        member _.ConnectReserved = connectReserved
        member _.InstantAvailable = instantAvailable
        member _.Issuing = issuing
        member _.Livemode = livemode
        member _.Object = object
        member _.Pending = pending

    and BalanceObject =
        | BalanceObject'Balance

    ///
    and BalanceAmount (amount: int, currency: string, ?sourceTypes: BalanceAmountBySourceType) =

        member _.Amount = amount
        member _.Currency = currency
        member _.SourceTypes = sourceTypes

    ///
    and BalanceAmountBySourceType (?bankAccount: int, ?card: int, ?fpx: int) =

        member _.BankAccount = bankAccount
        member _.Card = card
        member _.Fpx = fpx

    ///
    and BalanceDetail (available: BalanceAmount list) =

        member _.Available = available

    ///Balance transactions represent funds moving through your Stripe account.
    ///They're created for every type of transaction that comes into or flows out of your Stripe account balance.
    ///
    ///Related guide: [Balance Transaction Types](https://stripe.com/docs/reports/balance-transaction-types).
    and BalanceTransaction (amount: int, availableOn: int, created: int, currency: string, description: string option, exchangeRate: decimal option, fee: int, feeDetails: Fee list, id: string, net: int, object: BalanceTransactionObject, reportingCategory: string, source: BalanceTransactionSourceDU option, status: string, ``type``: BalanceTransactionType) =

        member _.Amount = amount
        member _.AvailableOn = availableOn
        member _.Created = created
        member _.Currency = currency
        member _.Description = description
        member _.ExchangeRate = exchangeRate
        member _.Fee = fee
        member _.FeeDetails = feeDetails
        member _.Id = id
        member _.Net = net
        member _.Object = object
        member _.ReportingCategory = reportingCategory
        member _.Source = source
        member _.Status = status
        member _.Type = ``type``

    and BalanceTransactionObject =
        | BalanceTransactionObject'BalanceTransaction

    and BalanceTransactionType =
        | BalanceTransactionType'Adjustment
        | BalanceTransactionType'Advance
        | BalanceTransactionType'AdvanceFunding
        | BalanceTransactionType'AnticipationRepayment
        | BalanceTransactionType'ApplicationFee
        | BalanceTransactionType'ApplicationFeeRefund
        | BalanceTransactionType'Charge
        | BalanceTransactionType'ConnectCollectionTransfer
        | BalanceTransactionType'Contribution
        | BalanceTransactionType'IssuingAuthorizationHold
        | BalanceTransactionType'IssuingAuthorizationRelease
        | BalanceTransactionType'IssuingDispute
        | BalanceTransactionType'IssuingTransaction
        | BalanceTransactionType'Payment
        | BalanceTransactionType'PaymentFailureRefund
        | BalanceTransactionType'PaymentRefund
        | BalanceTransactionType'Payout
        | BalanceTransactionType'PayoutCancel
        | BalanceTransactionType'PayoutFailure
        | BalanceTransactionType'Refund
        | BalanceTransactionType'RefundFailure
        | BalanceTransactionType'ReserveTransaction
        | BalanceTransactionType'ReservedFunds
        | BalanceTransactionType'StripeFee
        | BalanceTransactionType'StripeFxFee
        | BalanceTransactionType'TaxFee
        | BalanceTransactionType'Topup
        | BalanceTransactionType'TopupReversal
        | BalanceTransactionType'Transfer
        | BalanceTransactionType'TransferCancel
        | BalanceTransactionType'TransferFailure
        | BalanceTransactionType'TransferRefund

    and BalanceTransactionSourceDU =
        | BalanceTransactionSourceDU'String of string
        | BalanceTransactionSourceDU'BalanceTransactionSource of BalanceTransactionSource

    and BalanceTransactionSource =
        | BalanceTransactionSource'ApplicationFee of ApplicationFee
        | BalanceTransactionSource'Charge of Charge
        | BalanceTransactionSource'ConnectCollectionTransfer of ConnectCollectionTransfer
        | BalanceTransactionSource'Dispute of Dispute
        | BalanceTransactionSource'FeeRefund of FeeRefund
        | BalanceTransactionSource'IssuingAuthorization of IssuingAuthorization
        | BalanceTransactionSource'IssuingDispute of IssuingDispute
        | BalanceTransactionSource'IssuingTransaction of IssuingTransaction
        | BalanceTransactionSource'Payout of Payout
        | BalanceTransactionSource'PlatformTaxFee of PlatformTaxFee
        | BalanceTransactionSource'Refund of Refund
        | BalanceTransactionSource'ReserveTransaction of ReserveTransaction
        | BalanceTransactionSource'TaxDeductedAtSource of TaxDeductedAtSource
        | BalanceTransactionSource'Topup of Topup
        | BalanceTransactionSource'Transfer of Transfer
        | BalanceTransactionSource'TransferReversal of TransferReversal

    ///These bank accounts are payment methods on `Customer` objects.
    ///
    ///On the other hand [External Accounts](https://stripe.com/docs/api#external_accounts) are transfer
    ///destinations on `Account` objects for [Custom accounts](https://stripe.com/docs/connect/custom-accounts).
    ///They can be bank accounts or debit cards as well, and are documented in the links above.
    ///
    ///Related guide: [Bank Debits and Transfers](https://stripe.com/docs/payments/bank-debits-transfers).
    and BankAccount (accountHolderName: string option, accountHolderType: string option, bankName: string option, country: string, currency: string, fingerprint: string option, id: string, last4: string, object: BankAccountObject, routingNumber: string option, status: string, ?account: BankAccountAccountDU option, ?availablePayoutMethods: BankAccountAvailablePayoutMethods list option, ?customer: BankAccountCustomerDU option, ?defaultForCurrency: bool option, ?metadata: Map<string, string> option) =

        member _.Account = account |> Option.flatten
        member _.AccountHolderName = accountHolderName
        member _.AccountHolderType = accountHolderType
        member _.AvailablePayoutMethods = availablePayoutMethods |> Option.flatten
        member _.BankName = bankName
        member _.Country = country
        member _.Currency = currency
        member _.Customer = customer |> Option.flatten
        member _.DefaultForCurrency = defaultForCurrency |> Option.flatten
        member _.Fingerprint = fingerprint
        member _.Id = id
        member _.Last4 = last4
        member _.Metadata = metadata |> Option.flatten
        member _.Object = object
        member _.RoutingNumber = routingNumber
        member _.Status = status

    and BankAccountAvailablePayoutMethods =
        | BankAccountAvailablePayoutMethods'Instant
        | BankAccountAvailablePayoutMethods'Standard

    and BankAccountObject =
        | BankAccountObject'BankAccount

    and BankAccountAccountDU =
        | BankAccountAccountDU'String of string
        | BankAccountAccountDU'Account of Account

    and BankAccountCustomerDU =
        | BankAccountCustomerDU'String of string
        | BankAccountCustomerDU'Customer of Customer
        | BankAccountCustomerDU'DeletedCustomer of DeletedCustomer

    ///
    and BillingDetails (address: Address option, email: string option, name: string option, phone: string option) =

        member _.Address = address
        member _.Email = email
        member _.Name = name
        member _.Phone = phone

    ///A session describes the instantiation of the customer portal for
    ///a particular customer. By visiting the session's URL, the customer
    ///can manage their subscriptions and billing details. For security reasons,
    ///sessions are short-lived and will expire if the customer does not visit the URL.
    ///Create sessions on-demand when customers intend to manage their subscriptions and billing details.
    ///
    ///Integration guide: [Billing customer portal](https://stripe.com/docs/billing/subscriptions/integrating-customer-portal).
    and BillingPortalSession (created: int, customer: string, id: string, livemode: bool, object: BillingPortalSessionObject, returnUrl: string, url: string) =

        member _.Created = created
        member _.Customer = customer
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = object
        member _.ReturnUrl = returnUrl
        member _.Url = url

    and BillingPortalSessionObject =
        | BillingPortalSessionObject'BillingPortalSession

    ///
    and BitcoinReceiver (active: bool, amount: int, amountReceived: int, bitcoinAmount: int, bitcoinAmountReceived: int, bitcoinUri: string, created: int, currency: string, description: string option, email: string option, filled: bool, id: string, inboundAddress: string, livemode: bool, metadata: Map<string, string> option, object: BitcoinReceiverObject, refundAddress: string option, uncapturedFunds: bool, usedForPayment: bool option, ?customer: string option, ?payment: string option, ?transactions: Map<string, string>) =

        member _.Active = active
        member _.Amount = amount
        member _.AmountReceived = amountReceived
        member _.BitcoinAmount = bitcoinAmount
        member _.BitcoinAmountReceived = bitcoinAmountReceived
        member _.BitcoinUri = bitcoinUri
        member _.Created = created
        member _.Currency = currency
        member _.Customer = customer |> Option.flatten
        member _.Description = description
        member _.Email = email
        member _.Filled = filled
        member _.Id = id
        member _.InboundAddress = inboundAddress
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Object = object
        member _.Payment = payment |> Option.flatten
        member _.RefundAddress = refundAddress
        member _.Transactions = transactions
        member _.UncapturedFunds = uncapturedFunds
        member _.UsedForPayment = usedForPayment

    and BitcoinReceiverObject =
        | BitcoinReceiverObject'BitcoinReceiver

    ///
    and BitcoinTransaction (amount: int, bitcoinAmount: int, created: int, currency: string, id: string, object: BitcoinTransactionObject, receiver: string) =

        member _.Amount = amount
        member _.BitcoinAmount = bitcoinAmount
        member _.Created = created
        member _.Currency = currency
        member _.Id = id
        member _.Object = object
        member _.Receiver = receiver

    and BitcoinTransactionObject =
        | BitcoinTransactionObject'BitcoinTransaction

    ///This is an object representing a capability for a Stripe account.
    ///
    ///Related guide: [Account capabilities](https://stripe.com/docs/connect/account-capabilities).
    and Capability (account: CapabilityAccountDU, id: string, object: CapabilityObject, requested: bool, requestedAt: int option, status: CapabilityStatus, ?requirements: AccountCapabilityRequirements) =

        member _.Account = account
        member _.Id = id
        member _.Object = object
        member _.Requested = requested
        member _.RequestedAt = requestedAt
        member _.Requirements = requirements
        member _.Status = status

    and CapabilityObject =
        | CapabilityObject'Capability

    and CapabilityStatus =
        | CapabilityStatus'Active
        | CapabilityStatus'Disabled
        | CapabilityStatus'Inactive
        | CapabilityStatus'Pending
        | CapabilityStatus'Unrequested

    and CapabilityAccountDU =
        | CapabilityAccountDU'String of string
        | CapabilityAccountDU'Account of Account

    ///You can store multiple cards on a customer in order to charge the customer
    ///later. You can also store multiple debit cards on a recipient in order to
    ///transfer to those cards later.
    ///
    ///Related guide: [Card Payments with Sources](https://stripe.com/docs/sources/cards).
    and Card (addressCity: string option, addressCountry: string option, addressLine1: string option, addressLine1Check: string option, addressLine2: string option, addressState: string option, addressZip: string option, addressZipCheck: string option, brand: CardBrand, country: string option, cvcCheck: string option, dynamicLast4: string option, expMonth: int, expYear: int, funding: CardFunding, id: string, last4: string, metadata: Map<string, string> option, name: string option, object: CardObject, tokenizationMethod: CardTokenizationMethod option, ?account: CardAccountDU option, ?availablePayoutMethods: CardAvailablePayoutMethods list option, ?currency: string option, ?customer: CardCustomerDU option, ?defaultForCurrency: bool option, ?description: string, ?fingerprint: string option, ?iin: string, ?issuer: string, ?recipient: CardRecipientDU option) =

        member _.Account = account |> Option.flatten
        member _.AddressCity = addressCity
        member _.AddressCountry = addressCountry
        member _.AddressLine1 = addressLine1
        member _.AddressLine1Check = addressLine1Check
        member _.AddressLine2 = addressLine2
        member _.AddressState = addressState
        member _.AddressZip = addressZip
        member _.AddressZipCheck = addressZipCheck
        member _.AvailablePayoutMethods = availablePayoutMethods |> Option.flatten
        member _.Brand = brand
        member _.Country = country
        member _.Currency = currency |> Option.flatten
        member _.Customer = customer |> Option.flatten
        member _.CvcCheck = cvcCheck
        member _.DefaultForCurrency = defaultForCurrency |> Option.flatten
        member _.Description = description
        member _.DynamicLast4 = dynamicLast4
        member _.ExpMonth = expMonth
        member _.ExpYear = expYear
        member _.Fingerprint = fingerprint |> Option.flatten
        member _.Funding = funding
        member _.Id = id
        member _.Iin = iin
        member _.Issuer = issuer
        member _.Last4 = last4
        member _.Metadata = metadata
        member _.Name = name
        member _.Object = object
        member _.Recipient = recipient |> Option.flatten
        member _.TokenizationMethod = tokenizationMethod

    and CardAvailablePayoutMethods =
        | CardAvailablePayoutMethods'Instant
        | CardAvailablePayoutMethods'Standard

    and CardBrand =
        | [<JsonUnionCase("American Express")>] CardBrand'AmericanExpress
        | [<JsonUnionCase("Diners Club")>] CardBrand'DinersClub
        | [<JsonUnionCase("Discover")>] CardBrand'Discover
        | [<JsonUnionCase("JCB")>] CardBrand'JCB
        | [<JsonUnionCase("MasterCard")>] CardBrand'MasterCard
        | [<JsonUnionCase("UnionPay")>] CardBrand'UnionPay
        | [<JsonUnionCase("Visa")>] CardBrand'Visa
        | [<JsonUnionCase("Unknown")>] CardBrand'Unknown

    and CardFunding =
        | CardFunding'Credit
        | CardFunding'Debit
        | CardFunding'Prepaid
        | CardFunding'Unknown

    and CardObject =
        | CardObject'Card

    and CardTokenizationMethod =
        | CardTokenizationMethod'AndroidPay
        | CardTokenizationMethod'ApplePay
        | CardTokenizationMethod'Masterpass
        | CardTokenizationMethod'VisaCheckout

    and CardAccountDU =
        | CardAccountDU'String of string
        | CardAccountDU'Account of Account

    and CardCustomerDU =
        | CardCustomerDU'String of string
        | CardCustomerDU'Customer of Customer
        | CardCustomerDU'DeletedCustomer of DeletedCustomer

    and CardRecipientDU =
        | CardRecipientDU'String of string
        | CardRecipientDU'Recipient of Recipient

    ///
    and CardMandatePaymentMethodDetails (?undefined: string list) =

        member _.Undefined = undefined

    ///To charge a credit or a debit card, you create a `Charge` object. You can
    ///retrieve and refund individual charges as well as list all charges. Charges
    ///are identified by a unique, random ID.
    ///
    ///Related guide: [Accept a payment with the Charges API](https://stripe.com/docs/payments/accept-a-payment-charges).
    and Charge (amount: int, amountCaptured: int, amountRefunded: int, application: ChargeApplicationDU option, applicationFee: ChargeApplicationFeeDU option, applicationFeeAmount: int option, balanceTransaction: ChargeBalanceTransactionDU option, billingDetails: BillingDetails, calculatedStatementDescriptor: string option, captured: bool, created: int, currency: string, customer: ChargeCustomerDU option, description: string option, destination: ChargeDestinationDU option, dispute: ChargeDisputeDU option, disputed: bool, failureCode: string option, failureMessage: string option, fraudDetails: ChargeFraudDetails option, id: string, invoice: ChargeInvoiceDU option, livemode: bool, metadata: Map<string, string>, object: ChargeObject, onBehalfOf: ChargeOnBehalfOfDU option, order: ChargeOrderDU option, outcome: ChargeOutcome option, paid: bool, paymentIntent: ChargePaymentIntentDU option, paymentMethod: string option, paymentMethodDetails: PaymentMethodDetails option, receiptEmail: string option, receiptNumber: string option, receiptUrl: string option, refunded: bool, refunds: Map<string, string>, review: ChargeReviewDU option, shipping: Shipping option, source: PaymentSource option, sourceTransfer: ChargeSourceTransferDU option, statementDescriptor: string option, statementDescriptorSuffix: string option, status: string, transferData: ChargeTransferData option, transferGroup: string option, ?alternateStatementDescriptors: AlternateStatementDescriptors, ?authorizationCode: string, ?level3: Level3, ?transfer: ChargeTransferDU) =

        member _.AlternateStatementDescriptors = alternateStatementDescriptors
        member _.Amount = amount
        member _.AmountCaptured = amountCaptured
        member _.AmountRefunded = amountRefunded
        member _.Application = application
        member _.ApplicationFee = applicationFee
        member _.ApplicationFeeAmount = applicationFeeAmount
        member _.AuthorizationCode = authorizationCode
        member _.BalanceTransaction = balanceTransaction
        member _.BillingDetails = billingDetails
        member _.CalculatedStatementDescriptor = calculatedStatementDescriptor
        member _.Captured = captured
        member _.Created = created
        member _.Currency = currency
        member _.Customer = customer
        member _.Description = description
        member _.Destination = destination
        member _.Dispute = dispute
        member _.Disputed = disputed
        member _.FailureCode = failureCode
        member _.FailureMessage = failureMessage
        member _.FraudDetails = fraudDetails
        member _.Id = id
        member _.Invoice = invoice
        member _.Level3 = level3
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Object = object
        member _.OnBehalfOf = onBehalfOf
        member _.Order = order
        member _.Outcome = outcome
        member _.Paid = paid
        member _.PaymentIntent = paymentIntent
        member _.PaymentMethod = paymentMethod
        member _.PaymentMethodDetails = paymentMethodDetails
        member _.ReceiptEmail = receiptEmail
        member _.ReceiptNumber = receiptNumber
        member _.ReceiptUrl = receiptUrl
        member _.Refunded = refunded
        member _.Refunds = refunds
        member _.Review = review
        member _.Shipping = shipping
        member _.Source = source
        member _.SourceTransfer = sourceTransfer
        member _.StatementDescriptor = statementDescriptor
        member _.StatementDescriptorSuffix = statementDescriptorSuffix
        member _.Status = status
        member _.Transfer = transfer
        member _.TransferData = transferData
        member _.TransferGroup = transferGroup

    and ChargeObject =
        | ChargeObject'Charge

    and ChargeApplicationDU =
        | ChargeApplicationDU'String of string
        | ChargeApplicationDU'Application of Application

    and ChargeApplicationFeeDU =
        | ChargeApplicationFeeDU'String of string
        | ChargeApplicationFeeDU'ApplicationFee of ApplicationFee

    and ChargeBalanceTransactionDU =
        | ChargeBalanceTransactionDU'String of string
        | ChargeBalanceTransactionDU'BalanceTransaction of BalanceTransaction

    and ChargeCustomerDU =
        | ChargeCustomerDU'String of string
        | ChargeCustomerDU'Customer of Customer
        | ChargeCustomerDU'DeletedCustomer of DeletedCustomer

    and ChargeDestinationDU =
        | ChargeDestinationDU'String of string
        | ChargeDestinationDU'Account of Account

    and ChargeDisputeDU =
        | ChargeDisputeDU'String of string
        | ChargeDisputeDU'Dispute of Dispute

    and ChargeInvoiceDU =
        | ChargeInvoiceDU'String of string
        | ChargeInvoiceDU'Invoice of Invoice

    and ChargeOnBehalfOfDU =
        | ChargeOnBehalfOfDU'String of string
        | ChargeOnBehalfOfDU'Account of Account

    and ChargeOrderDU =
        | ChargeOrderDU'String of string
        | ChargeOrderDU'Order of Order

    and ChargePaymentIntentDU =
        | ChargePaymentIntentDU'String of string
        | ChargePaymentIntentDU'PaymentIntent of PaymentIntent

    and ChargeReviewDU =
        | ChargeReviewDU'String of string
        | ChargeReviewDU'Review of Review

    and ChargeSourceTransferDU =
        | ChargeSourceTransferDU'String of string
        | ChargeSourceTransferDU'Transfer of Transfer

    and ChargeTransferDU =
        | ChargeTransferDU'String of string
        | ChargeTransferDU'Transfer of Transfer

    ///
    and ChargeFraudDetails (?stripeReport: string, ?userReport: string) =

        member _.StripeReport = stripeReport
        member _.UserReport = userReport

    ///
    and ChargeOutcome (networkStatus: string option, reason: string option, sellerMessage: string option, ``type``: string, ?riskLevel: string, ?riskScore: int, ?rule: ChargeOutcomeRuleDU) =

        member _.NetworkStatus = networkStatus
        member _.Reason = reason
        member _.RiskLevel = riskLevel
        member _.RiskScore = riskScore
        member _.Rule = rule
        member _.SellerMessage = sellerMessage
        member _.Type = ``type``

    and ChargeOutcomeRuleDU =
        | ChargeOutcomeRuleDU'String of string
        | ChargeOutcomeRuleDU'Rule of Rule

    ///
    and ChargeTransferData (amount: int option, destination: ChargeTransferDataDestinationDU) =

        member _.Amount = amount
        member _.Destination = destination

    and ChargeTransferDataDestinationDU =
        | ChargeTransferDataDestinationDU'String of string
        | ChargeTransferDataDestinationDU'Account of Account

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
    and CheckoutSession (allowPromotionCodes: bool option, amountSubtotal: int option, amountTotal: int option, billingAddressCollection: CheckoutSessionBillingAddressCollection option, cancelUrl: string, clientReferenceId: string option, currency: string option, customer: CheckoutSessionCustomerDU option, customerEmail: string option, id: string, livemode: bool, locale: CheckoutSessionLocale option, metadata: Map<string, string> option, mode: CheckoutSessionMode, object: CheckoutSessionObject, paymentIntent: CheckoutSessionPaymentIntentDU option, paymentMethodTypes: string list, paymentStatus: CheckoutSessionPaymentStatus, setupIntent: CheckoutSessionSetupIntentDU option, shipping: Shipping option, shippingAddressCollection: PaymentPagesPaymentPageResourcesShippingAddressCollection option, submitType: CheckoutSessionSubmitType option, subscription: CheckoutSessionSubscriptionDU option, successUrl: string, totalDetails: PaymentPagesCheckoutSessionTotalDetails option, ?lineItems: Map<string, string>) =

        member _.AllowPromotionCodes = allowPromotionCodes
        member _.AmountSubtotal = amountSubtotal
        member _.AmountTotal = amountTotal
        member _.BillingAddressCollection = billingAddressCollection
        member _.CancelUrl = cancelUrl
        member _.ClientReferenceId = clientReferenceId
        member _.Currency = currency
        member _.Customer = customer
        member _.CustomerEmail = customerEmail
        member _.Id = id
        member _.LineItems = lineItems
        member _.Livemode = livemode
        member _.Locale = locale
        member _.Metadata = metadata
        member _.Mode = mode
        member _.Object = object
        member _.PaymentIntent = paymentIntent
        member _.PaymentMethodTypes = paymentMethodTypes
        member _.PaymentStatus = paymentStatus
        member _.SetupIntent = setupIntent
        member _.Shipping = shipping
        member _.ShippingAddressCollection = shippingAddressCollection
        member _.SubmitType = submitType
        member _.Subscription = subscription
        member _.SuccessUrl = successUrl
        member _.TotalDetails = totalDetails

    and CheckoutSessionBillingAddressCollection =
        | CheckoutSessionBillingAddressCollection'Auto
        | CheckoutSessionBillingAddressCollection'Required

    and CheckoutSessionLocale =
        | CheckoutSessionLocale'Auto
        | CheckoutSessionLocale'Bg
        | CheckoutSessionLocale'Cs
        | CheckoutSessionLocale'Da
        | CheckoutSessionLocale'De
        | CheckoutSessionLocale'El
        | CheckoutSessionLocale'En
        | [<JsonUnionCase("en-GB")>] CheckoutSessionLocale'EnGB
        | CheckoutSessionLocale'Es
        | [<JsonUnionCase("es-419")>] CheckoutSessionLocale'Es419
        | CheckoutSessionLocale'Et
        | CheckoutSessionLocale'Fi
        | CheckoutSessionLocale'Fr
        | [<JsonUnionCase("fr-CA")>] CheckoutSessionLocale'FrCA
        | CheckoutSessionLocale'Hu
        | CheckoutSessionLocale'Id
        | CheckoutSessionLocale'It
        | CheckoutSessionLocale'Ja
        | CheckoutSessionLocale'Lt
        | CheckoutSessionLocale'Lv
        | CheckoutSessionLocale'Ms
        | CheckoutSessionLocale'Mt
        | CheckoutSessionLocale'Nb
        | CheckoutSessionLocale'Nl
        | CheckoutSessionLocale'Pl
        | CheckoutSessionLocale'Pt
        | [<JsonUnionCase("pt-BR")>] CheckoutSessionLocale'PtBR
        | CheckoutSessionLocale'Ro
        | CheckoutSessionLocale'Ru
        | CheckoutSessionLocale'Sk
        | CheckoutSessionLocale'Sl
        | CheckoutSessionLocale'Sv
        | CheckoutSessionLocale'Tr
        | CheckoutSessionLocale'Zh
        | [<JsonUnionCase("zh-HK")>] CheckoutSessionLocale'ZhHK
        | [<JsonUnionCase("zh-TW")>] CheckoutSessionLocale'ZhTW

    and CheckoutSessionMode =
        | CheckoutSessionMode'Payment
        | CheckoutSessionMode'Setup
        | CheckoutSessionMode'Subscription

    and CheckoutSessionObject =
        | CheckoutSessionObject'CheckoutSession

    and CheckoutSessionPaymentStatus =
        | CheckoutSessionPaymentStatus'NoPaymentRequired
        | CheckoutSessionPaymentStatus'Paid
        | CheckoutSessionPaymentStatus'Unpaid

    and CheckoutSessionSubmitType =
        | CheckoutSessionSubmitType'Auto
        | CheckoutSessionSubmitType'Book
        | CheckoutSessionSubmitType'Donate
        | CheckoutSessionSubmitType'Pay

    and CheckoutSessionCustomerDU =
        | CheckoutSessionCustomerDU'String of string
        | CheckoutSessionCustomerDU'Customer of Customer
        | CheckoutSessionCustomerDU'DeletedCustomer of DeletedCustomer

    and CheckoutSessionPaymentIntentDU =
        | CheckoutSessionPaymentIntentDU'String of string
        | CheckoutSessionPaymentIntentDU'PaymentIntent of PaymentIntent

    and CheckoutSessionSetupIntentDU =
        | CheckoutSessionSetupIntentDU'String of string
        | CheckoutSessionSetupIntentDU'SetupIntent of SetupIntent

    and CheckoutSessionSubscriptionDU =
        | CheckoutSessionSubscriptionDU'String of string
        | CheckoutSessionSubscriptionDU'Subscription of Subscription

    ///
    and ConnectCollectionTransfer (amount: int, currency: string, destination: ConnectCollectionTransferDestinationDU, id: string, livemode: bool, object: ConnectCollectionTransferObject) =

        member _.Amount = amount
        member _.Currency = currency
        member _.Destination = destination
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = object

    and ConnectCollectionTransferObject =
        | ConnectCollectionTransferObject'ConnectCollectionTransfer

    and ConnectCollectionTransferDestinationDU =
        | ConnectCollectionTransferDestinationDU'String of string
        | ConnectCollectionTransferDestinationDU'Account of Account

    ///Stripe needs to collect certain pieces of information about each account
    ///created. These requirements can differ depending on the account's country. The
    ///Country Specs API makes these rules available to your integration.
    ///
    ///You can also view the information from this API call as [an online
    ///guide](/docs/connect/required-verification-information).
    and CountrySpec (defaultCurrency: string, id: string, object: CountrySpecObject, supportedBankAccountCurrencies: Map<string, string>, supportedPaymentCurrencies: string list, supportedPaymentMethods: string list, supportedTransferCountries: string list, verificationFields: CountrySpecVerificationFields) =

        member _.DefaultCurrency = defaultCurrency
        member _.Id = id
        member _.Object = object
        member _.SupportedBankAccountCurrencies = supportedBankAccountCurrencies
        member _.SupportedPaymentCurrencies = supportedPaymentCurrencies
        member _.SupportedPaymentMethods = supportedPaymentMethods
        member _.SupportedTransferCountries = supportedTransferCountries
        member _.VerificationFields = verificationFields

    and CountrySpecObject =
        | CountrySpecObject'CountrySpec

    ///
    and CountrySpecVerificationFieldDetails (additional: string list, minimum: string list) =

        member _.Additional = additional
        member _.Minimum = minimum

    ///
    and CountrySpecVerificationFields (company: CountrySpecVerificationFieldDetails, individual: CountrySpecVerificationFieldDetails) =

        member _.Company = company
        member _.Individual = individual

    ///A coupon contains information about a percent-off or amount-off discount you
    ///might want to apply to a customer. Coupons may be applied to [invoices](https://stripe.com/docs/api#invoices) or
    ///[orders](https://stripe.com/docs/api#create_order-coupon). Coupons do not work with conventional one-off [charges](https://stripe.com/docs/api#create_charge).
    and Coupon (amountOff: int option, created: int, currency: string option, duration: CouponDuration, durationInMonths: int option, id: string, livemode: bool, maxRedemptions: int option, metadata: Map<string, string> option, name: string option, object: CouponObject, percentOff: decimal option, redeemBy: int option, timesRedeemed: int, valid: bool, ?appliesTo: CouponAppliesTo) =

        member _.AmountOff = amountOff
        member _.AppliesTo = appliesTo
        member _.Created = created
        member _.Currency = currency
        member _.Duration = duration
        member _.DurationInMonths = durationInMonths
        member _.Id = id
        member _.Livemode = livemode
        member _.MaxRedemptions = maxRedemptions
        member _.Metadata = metadata
        member _.Name = name
        member _.Object = object
        member _.PercentOff = percentOff
        member _.RedeemBy = redeemBy
        member _.TimesRedeemed = timesRedeemed
        member _.Valid = valid

    and CouponDuration =
        | CouponDuration'Forever
        | CouponDuration'Once
        | CouponDuration'Repeating

    and CouponObject =
        | CouponObject'Coupon

    ///
    and CouponAppliesTo (products: string list) =

        member _.Products = products

    ///Issue a credit note to adjust an invoice's amount after the invoice is finalized.
    ///
    ///Related guide: [Credit Notes](https://stripe.com/docs/billing/invoices/credit-notes).
    and CreditNote (amount: int, created: int, currency: string, customer: CreditNoteCustomerDU, customerBalanceTransaction: CreditNoteCustomerBalanceTransactionDU option, discountAmount: int, discountAmounts: DiscountsResourceDiscountAmount list, id: string, invoice: CreditNoteInvoiceDU, lines: Map<string, string>, livemode: bool, memo: string option, metadata: Map<string, string> option, number: string, object: CreditNoteObject, outOfBandAmount: int option, pdf: string, reason: CreditNoteReason option, refund: CreditNoteRefundDU option, status: CreditNoteStatus, subtotal: int, taxAmounts: CreditNoteTaxAmount list, total: int, ``type``: CreditNoteType, voidedAt: int option) =

        member _.Amount = amount
        member _.Created = created
        member _.Currency = currency
        member _.Customer = customer
        member _.CustomerBalanceTransaction = customerBalanceTransaction
        member _.DiscountAmount = discountAmount
        member _.DiscountAmounts = discountAmounts
        member _.Id = id
        member _.Invoice = invoice
        member _.Lines = lines
        member _.Livemode = livemode
        member _.Memo = memo
        member _.Metadata = metadata
        member _.Number = number
        member _.Object = object
        member _.OutOfBandAmount = outOfBandAmount
        member _.Pdf = pdf
        member _.Reason = reason
        member _.Refund = refund
        member _.Status = status
        member _.Subtotal = subtotal
        member _.TaxAmounts = taxAmounts
        member _.Total = total
        member _.Type = ``type``
        member _.VoidedAt = voidedAt

    and CreditNoteObject =
        | CreditNoteObject'CreditNote

    and CreditNoteReason =
        | CreditNoteReason'Duplicate
        | CreditNoteReason'Fraudulent
        | CreditNoteReason'OrderChange
        | CreditNoteReason'ProductUnsatisfactory

    and CreditNoteStatus =
        | CreditNoteStatus'Issued
        | CreditNoteStatus'Void

    and CreditNoteType =
        | CreditNoteType'PostPayment
        | CreditNoteType'PrePayment

    and CreditNoteCustomerDU =
        | CreditNoteCustomerDU'String of string
        | CreditNoteCustomerDU'Customer of Customer
        | CreditNoteCustomerDU'DeletedCustomer of DeletedCustomer

    and CreditNoteCustomerBalanceTransactionDU =
        | CreditNoteCustomerBalanceTransactionDU'String of string
        | CreditNoteCustomerBalanceTransactionDU'CustomerBalanceTransaction of CustomerBalanceTransaction

    and CreditNoteInvoiceDU =
        | CreditNoteInvoiceDU'String of string
        | CreditNoteInvoiceDU'Invoice of Invoice

    and CreditNoteRefundDU =
        | CreditNoteRefundDU'String of string
        | CreditNoteRefundDU'Refund of Refund

    ///
    and CreditNoteLineItem (amount: int, description: string option, discountAmount: int, discountAmounts: DiscountsResourceDiscountAmount list, id: string, livemode: bool, object: CreditNoteLineItemObject, quantity: int option, taxAmounts: CreditNoteTaxAmount list, taxRates: TaxRate list, ``type``: CreditNoteLineItemType, unitAmount: int option, unitAmountDecimal: string option, ?invoiceLineItem: string) =

        member _.Amount = amount
        member _.Description = description
        member _.DiscountAmount = discountAmount
        member _.DiscountAmounts = discountAmounts
        member _.Id = id
        member _.InvoiceLineItem = invoiceLineItem
        member _.Livemode = livemode
        member _.Object = object
        member _.Quantity = quantity
        member _.TaxAmounts = taxAmounts
        member _.TaxRates = taxRates
        member _.Type = ``type``
        member _.UnitAmount = unitAmount
        member _.UnitAmountDecimal = unitAmountDecimal

    and CreditNoteLineItemObject =
        | CreditNoteLineItemObject'CreditNoteLineItem

    and CreditNoteLineItemType =
        | CreditNoteLineItemType'CustomLineItem
        | CreditNoteLineItemType'InvoiceLineItem

    ///
    and CreditNoteTaxAmount (amount: int, inclusive: bool, taxRate: CreditNoteTaxAmountTaxRateDU) =

        member _.Amount = amount
        member _.Inclusive = inclusive
        member _.TaxRate = taxRate

    and CreditNoteTaxAmountTaxRateDU =
        | CreditNoteTaxAmountTaxRateDU'String of string
        | CreditNoteTaxAmountTaxRateDU'TaxRate of TaxRate

    ///`Customer` objects allow you to perform recurring charges, and to track
    ///multiple charges, that are associated with the same customer. The API allows
    ///you to create, delete, and update your customers. You can retrieve individual
    ///customers as well as a list of all your customers.
    ///
    ///Related guide: [Save a card during payment](https://stripe.com/docs/payments/save-during-payment).
    and Customer (created: int, defaultSource: CustomerDefaultSourceDU option, description: string option, email: string option, id: string, livemode: bool, object: CustomerObject, shipping: Shipping option, ?address: Address option, ?balance: int, ?currency: string option, ?delinquent: bool option, ?discount: Discount option, ?invoicePrefix: string option, ?invoiceSettings: InvoiceSettingCustomerSetting, ?metadata: Map<string, string>, ?name: string option, ?nextInvoiceSequence: int, ?phone: string option, ?preferredLocales: string list option, ?sources: Map<string, string>, ?subscriptions: Map<string, string>, ?taxExempt: CustomerTaxExempt option, ?taxIds: Map<string, string>) =

        member _.Address = address |> Option.flatten
        member _.Balance = balance
        member _.Created = created
        member _.Currency = currency |> Option.flatten
        member _.DefaultSource = defaultSource
        member _.Delinquent = delinquent |> Option.flatten
        member _.Description = description
        member _.Discount = discount |> Option.flatten
        member _.Email = email
        member _.Id = id
        member _.InvoicePrefix = invoicePrefix |> Option.flatten
        member _.InvoiceSettings = invoiceSettings
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Name = name |> Option.flatten
        member _.NextInvoiceSequence = nextInvoiceSequence
        member _.Object = object
        member _.Phone = phone |> Option.flatten
        member _.PreferredLocales = preferredLocales |> Option.flatten
        member _.Shipping = shipping
        member _.Sources = sources
        member _.Subscriptions = subscriptions
        member _.TaxExempt = taxExempt |> Option.flatten
        member _.TaxIds = taxIds

    and CustomerObject =
        | CustomerObject'Customer

    and CustomerTaxExempt =
        | CustomerTaxExempt'Exempt
        | CustomerTaxExempt'None
        | CustomerTaxExempt'Reverse

    and CustomerDefaultSourceDU =
        | CustomerDefaultSourceDU'String of string
        | CustomerDefaultSourceDU'PaymentSource of PaymentSource

    ///
    and CustomerAcceptance (acceptedAt: int option, ``type``: CustomerAcceptanceType, ?offline: OfflineAcceptance, ?online: OnlineAcceptance) =

        member _.AcceptedAt = acceptedAt
        member _.Offline = offline
        member _.Online = online
        member _.Type = ``type``

    and CustomerAcceptanceType =
        | CustomerAcceptanceType'Offline
        | CustomerAcceptanceType'Online

    ///Each customer has a [`balance`](https://stripe.com/docs/api/customers/object#customer_object-balance) value,
    ///which denotes a debit or credit that's automatically applied to their next invoice upon finalization.
    ///You may modify the value directly by using the [update customer API](https://stripe.com/docs/api/customers/update),
    ///or by creating a Customer Balance Transaction, which increments or decrements the customer's `balance` by the specified `amount`.
    ///
    ///Related guide: [Customer Balance](https://stripe.com/docs/billing/customer/balance) to learn more.
    and CustomerBalanceTransaction (amount: int, created: int, creditNote: CustomerBalanceTransactionCreditNoteDU option, currency: string, customer: CustomerBalanceTransactionCustomerDU, description: string option, endingBalance: int, id: string, invoice: CustomerBalanceTransactionInvoiceDU option, livemode: bool, metadata: Map<string, string> option, object: CustomerBalanceTransactionObject, ``type``: CustomerBalanceTransactionType) =

        member _.Amount = amount
        member _.Created = created
        member _.CreditNote = creditNote
        member _.Currency = currency
        member _.Customer = customer
        member _.Description = description
        member _.EndingBalance = endingBalance
        member _.Id = id
        member _.Invoice = invoice
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Object = object
        member _.Type = ``type``

    and CustomerBalanceTransactionObject =
        | CustomerBalanceTransactionObject'CustomerBalanceTransaction

    and CustomerBalanceTransactionType =
        | CustomerBalanceTransactionType'Adjustment
        | CustomerBalanceTransactionType'AppliedToInvoice
        | CustomerBalanceTransactionType'CreditNote
        | CustomerBalanceTransactionType'Initial
        | CustomerBalanceTransactionType'InvoiceTooLarge
        | CustomerBalanceTransactionType'InvoiceTooSmall
        | CustomerBalanceTransactionType'Migration
        | CustomerBalanceTransactionType'UnappliedFromInvoice
        | CustomerBalanceTransactionType'UnspentReceiverCredit

    and CustomerBalanceTransactionCreditNoteDU =
        | CustomerBalanceTransactionCreditNoteDU'String of string
        | CustomerBalanceTransactionCreditNoteDU'CreditNote of CreditNote

    and CustomerBalanceTransactionCustomerDU =
        | CustomerBalanceTransactionCustomerDU'String of string
        | CustomerBalanceTransactionCustomerDU'Customer of Customer

    and CustomerBalanceTransactionInvoiceDU =
        | CustomerBalanceTransactionInvoiceDU'String of string
        | CustomerBalanceTransactionInvoiceDU'Invoice of Invoice

    ///
    and DeletedAccount (deleted: DeletedAccountDeleted, id: string, object: DeletedAccountObject) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = object

    and DeletedAccountDeleted =
        | DeletedAccountDeleted'True

    and DeletedAccountObject =
        | DeletedAccountObject'Account

    ///
    and DeletedAlipayAccount (deleted: DeletedAlipayAccountDeleted, id: string, object: DeletedAlipayAccountObject) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = object

    and DeletedAlipayAccountDeleted =
        | DeletedAlipayAccountDeleted'True

    and DeletedAlipayAccountObject =
        | DeletedAlipayAccountObject'AlipayAccount

    ///
    and DeletedApplePayDomain (deleted: DeletedApplePayDomainDeleted, id: string, object: DeletedApplePayDomainObject) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = object

    and DeletedApplePayDomainDeleted =
        | DeletedApplePayDomainDeleted'True

    and DeletedApplePayDomainObject =
        | DeletedApplePayDomainObject'ApplePayDomain

    ///
    and DeletedBankAccount (currency: string option, deleted: DeletedBankAccountDeleted, id: string, object: DeletedBankAccountObject) =

        member _.Currency = currency
        member _.Deleted = deleted
        member _.Id = id
        member _.Object = object

    and DeletedBankAccountDeleted =
        | DeletedBankAccountDeleted'True

    and DeletedBankAccountObject =
        | DeletedBankAccountObject'BankAccount

    ///
    and DeletedBitcoinReceiver (deleted: DeletedBitcoinReceiverDeleted, id: string, object: DeletedBitcoinReceiverObject) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = object

    and DeletedBitcoinReceiverDeleted =
        | DeletedBitcoinReceiverDeleted'True

    and DeletedBitcoinReceiverObject =
        | DeletedBitcoinReceiverObject'BitcoinReceiver

    ///
    and DeletedCard (currency: string option, deleted: DeletedCardDeleted, id: string, object: DeletedCardObject) =

        member _.Currency = currency
        member _.Deleted = deleted
        member _.Id = id
        member _.Object = object

    and DeletedCardDeleted =
        | DeletedCardDeleted'True

    and DeletedCardObject =
        | DeletedCardObject'Card

    ///
    and DeletedCoupon (deleted: DeletedCouponDeleted, id: string, object: DeletedCouponObject) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = object

    and DeletedCouponDeleted =
        | DeletedCouponDeleted'True

    and DeletedCouponObject =
        | DeletedCouponObject'Coupon

    ///
    and DeletedCustomer (deleted: DeletedCustomerDeleted, id: string, object: DeletedCustomerObject) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = object

    and DeletedCustomerDeleted =
        | DeletedCustomerDeleted'True

    and DeletedCustomerObject =
        | DeletedCustomerObject'Customer

    ///
    and DeletedDiscount (checkoutSession: string option, coupon: Coupon, customer: DeletedDiscountCustomerDU option, deleted: DeletedDiscountDeleted, id: string, invoice: string option, invoiceItem: string option, object: DeletedDiscountObject, promotionCode: DeletedDiscountPromotionCodeDU option, start: int, subscription: string option) =

        member _.CheckoutSession = checkoutSession
        member _.Coupon = coupon
        member _.Customer = customer
        member _.Deleted = deleted
        member _.Id = id
        member _.Invoice = invoice
        member _.InvoiceItem = invoiceItem
        member _.Object = object
        member _.PromotionCode = promotionCode
        member _.Start = start
        member _.Subscription = subscription

    and DeletedDiscountDeleted =
        | DeletedDiscountDeleted'True

    and DeletedDiscountObject =
        | DeletedDiscountObject'Discount

    and DeletedDiscountCustomerDU =
        | DeletedDiscountCustomerDU'String of string
        | DeletedDiscountCustomerDU'Customer of Customer
        | DeletedDiscountCustomerDU'DeletedCustomer of DeletedCustomer

    and DeletedDiscountPromotionCodeDU =
        | DeletedDiscountPromotionCodeDU'String of string
        | DeletedDiscountPromotionCodeDU'PromotionCode of PromotionCode

    and DeletedExternalAccount =
        | DeletedExternalAccount'DeletedBankAccount of DeletedBankAccount
        | DeletedExternalAccount'DeletedCard of DeletedCard

    ///
    and DeletedInvoice (deleted: DeletedInvoiceDeleted, id: string, object: DeletedInvoiceObject) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = object

    and DeletedInvoiceDeleted =
        | DeletedInvoiceDeleted'True

    and DeletedInvoiceObject =
        | DeletedInvoiceObject'Invoice

    ///
    and DeletedInvoiceitem (deleted: DeletedInvoiceitemDeleted, id: string, object: DeletedInvoiceitemObject) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = object

    and DeletedInvoiceitemDeleted =
        | DeletedInvoiceitemDeleted'True

    and DeletedInvoiceitemObject =
        | DeletedInvoiceitemObject'Invoiceitem

    and DeletedPaymentSource =
        | DeletedPaymentSource'DeletedAlipayAccount of DeletedAlipayAccount
        | DeletedPaymentSource'DeletedBankAccount of DeletedBankAccount
        | DeletedPaymentSource'DeletedBitcoinReceiver of DeletedBitcoinReceiver
        | DeletedPaymentSource'DeletedCard of DeletedCard

    ///
    and DeletedPerson (deleted: DeletedPersonDeleted, id: string, object: DeletedPersonObject) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = object

    and DeletedPersonDeleted =
        | DeletedPersonDeleted'True

    and DeletedPersonObject =
        | DeletedPersonObject'Person

    ///
    and DeletedPlan (deleted: DeletedPlanDeleted, id: string, object: DeletedPlanObject) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = object

    and DeletedPlanDeleted =
        | DeletedPlanDeleted'True

    and DeletedPlanObject =
        | DeletedPlanObject'Plan

    ///
    and DeletedPrice (deleted: DeletedPriceDeleted, id: string, object: DeletedPriceObject) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = object

    and DeletedPriceDeleted =
        | DeletedPriceDeleted'True

    and DeletedPriceObject =
        | DeletedPriceObject'Price

    ///
    and DeletedProduct (deleted: DeletedProductDeleted, id: string, object: DeletedProductObject) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = object

    and DeletedProductDeleted =
        | DeletedProductDeleted'True

    and DeletedProductObject =
        | DeletedProductObject'Product

    ///
    and DeletedRadarValueList (deleted: DeletedRadarValueListDeleted, id: string, object: DeletedRadarValueListObject) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = object

    and DeletedRadarValueListDeleted =
        | DeletedRadarValueListDeleted'True

    and DeletedRadarValueListObject =
        | DeletedRadarValueListObject'RadarValueList

    ///
    and DeletedRadarValueListItem (deleted: DeletedRadarValueListItemDeleted, id: string, object: DeletedRadarValueListItemObject) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = object

    and DeletedRadarValueListItemDeleted =
        | DeletedRadarValueListItemDeleted'True

    and DeletedRadarValueListItemObject =
        | DeletedRadarValueListItemObject'RadarValueListItem

    ///
    and DeletedRecipient (deleted: DeletedRecipientDeleted, id: string, object: DeletedRecipientObject) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = object

    and DeletedRecipientDeleted =
        | DeletedRecipientDeleted'True

    and DeletedRecipientObject =
        | DeletedRecipientObject'Recipient

    ///
    and DeletedSku (deleted: DeletedSkuDeleted, id: string, object: DeletedSkuObject) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = object

    and DeletedSkuDeleted =
        | DeletedSkuDeleted'True

    and DeletedSkuObject =
        | DeletedSkuObject'Sku

    ///
    and DeletedSubscriptionItem (deleted: DeletedSubscriptionItemDeleted, id: string, object: DeletedSubscriptionItemObject) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = object

    and DeletedSubscriptionItemDeleted =
        | DeletedSubscriptionItemDeleted'True

    and DeletedSubscriptionItemObject =
        | DeletedSubscriptionItemObject'SubscriptionItem

    ///
    and DeletedTaxId (deleted: DeletedTaxIdDeleted, id: string, object: DeletedTaxIdObject) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = object

    and DeletedTaxIdDeleted =
        | DeletedTaxIdDeleted'True

    and DeletedTaxIdObject =
        | DeletedTaxIdObject'TaxId

    ///
    and DeletedTerminalLocation (deleted: DeletedTerminalLocationDeleted, id: string, object: DeletedTerminalLocationObject) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = object

    and DeletedTerminalLocationDeleted =
        | DeletedTerminalLocationDeleted'True

    and DeletedTerminalLocationObject =
        | DeletedTerminalLocationObject'TerminalLocation

    ///
    and DeletedTerminalReader (deleted: DeletedTerminalReaderDeleted, id: string, object: DeletedTerminalReaderObject) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = object

    and DeletedTerminalReaderDeleted =
        | DeletedTerminalReaderDeleted'True

    and DeletedTerminalReaderObject =
        | DeletedTerminalReaderObject'TerminalReader

    ///
    and DeletedWebhookEndpoint (deleted: DeletedWebhookEndpointDeleted, id: string, object: DeletedWebhookEndpointObject) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = object

    and DeletedWebhookEndpointDeleted =
        | DeletedWebhookEndpointDeleted'True

    and DeletedWebhookEndpointObject =
        | DeletedWebhookEndpointObject'WebhookEndpoint

    ///
    and DeliveryEstimate (``type``: string, ?date: string, ?earliest: string, ?latest: string) =

        member _.Date = date
        member _.Earliest = earliest
        member _.Latest = latest
        member _.Type = ``type``

    ///A discount represents the actual application of a coupon to a particular
    ///customer. It contains information about when the discount began and when it
    ///will end.
    ///
    ///Related guide: [Applying Discounts to Subscriptions](https://stripe.com/docs/billing/subscriptions/discounts).
    and Discount (checkoutSession: string option, coupon: Coupon, customer: DiscountCustomerDU option, ``end``: int option, id: string, invoice: string option, invoiceItem: string option, object: DiscountObject, promotionCode: DiscountPromotionCodeDU option, start: int, subscription: string option) =

        member _.CheckoutSession = checkoutSession
        member _.Coupon = coupon
        member _.Customer = customer
        member _.End = ``end``
        member _.Id = id
        member _.Invoice = invoice
        member _.InvoiceItem = invoiceItem
        member _.Object = object
        member _.PromotionCode = promotionCode
        member _.Start = start
        member _.Subscription = subscription

    and DiscountObject =
        | DiscountObject'Discount

    and DiscountCustomerDU =
        | DiscountCustomerDU'String of string
        | DiscountCustomerDU'Customer of Customer
        | DiscountCustomerDU'DeletedCustomer of DeletedCustomer

    and DiscountPromotionCodeDU =
        | DiscountPromotionCodeDU'String of string
        | DiscountPromotionCodeDU'PromotionCode of PromotionCode

    ///
    and DiscountsResourceDiscountAmount (amount: int, discount: DiscountsResourceDiscountAmountDiscountDU) =

        member _.Amount = amount
        member _.Discount = discount

    and DiscountsResourceDiscountAmountDiscountDU =
        | DiscountsResourceDiscountAmountDiscountDU'String of string
        | DiscountsResourceDiscountAmountDiscountDU'Discount of Discount
        | DiscountsResourceDiscountAmountDiscountDU'DeletedDiscount of DeletedDiscount

    ///A dispute occurs when a customer questions your charge with their card issuer.
    ///When this happens, you're given the opportunity to respond to the dispute with
    ///evidence that shows that the charge is legitimate. You can find more
    ///information about the dispute process in our [Disputes and
    ///Fraud](/docs/disputes) documentation.
    ///
    ///Related guide: [Disputes and Fraud](https://stripe.com/docs/disputes).
    and Dispute (amount: int, balanceTransactions: BalanceTransaction list, charge: DisputeChargeDU, created: int, currency: string, evidence: DisputeEvidence, evidenceDetails: DisputeEvidenceDetails, id: string, isChargeRefundable: bool, livemode: bool, metadata: Map<string, string>, object: DisputeObject, paymentIntent: DisputePaymentIntentDU option, reason: string, status: DisputeStatus, ?networkReasonCode: string option) =

        member _.Amount = amount
        member _.BalanceTransactions = balanceTransactions
        member _.Charge = charge
        member _.Created = created
        member _.Currency = currency
        member _.Evidence = evidence
        member _.EvidenceDetails = evidenceDetails
        member _.Id = id
        member _.IsChargeRefundable = isChargeRefundable
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.NetworkReasonCode = networkReasonCode |> Option.flatten
        member _.Object = object
        member _.PaymentIntent = paymentIntent
        member _.Reason = reason
        member _.Status = status

    and DisputeObject =
        | DisputeObject'Dispute

    and DisputeStatus =
        | DisputeStatus'ChargeRefunded
        | DisputeStatus'Lost
        | DisputeStatus'NeedsResponse
        | DisputeStatus'UnderReview
        | DisputeStatus'WarningClosed
        | DisputeStatus'WarningNeedsResponse
        | DisputeStatus'WarningUnderReview
        | DisputeStatus'Won

    and DisputeChargeDU =
        | DisputeChargeDU'String of string
        | DisputeChargeDU'Charge of Charge

    and DisputePaymentIntentDU =
        | DisputePaymentIntentDU'String of string
        | DisputePaymentIntentDU'PaymentIntent of PaymentIntent

    ///
    and DisputeEvidence (accessActivityLog: string option, billingAddress: string option, cancellationPolicy: DisputeEvidenceCancellationPolicyDU option, cancellationPolicyDisclosure: string option, cancellationRebuttal: string option, customerCommunication: DisputeEvidenceCustomerCommunicationDU option, customerEmailAddress: string option, customerName: string option, customerPurchaseIp: string option, customerSignature: DisputeEvidenceCustomerSignatureDU option, duplicateChargeDocumentation: DisputeEvidenceDuplicateChargeDocumentationDU option, duplicateChargeExplanation: string option, duplicateChargeId: string option, productDescription: string option, receipt: DisputeEvidenceReceiptDU option, refundPolicy: DisputeEvidenceRefundPolicyDU option, refundPolicyDisclosure: string option, refundRefusalExplanation: string option, serviceDate: string option, serviceDocumentation: DisputeEvidenceServiceDocumentationDU option, shippingAddress: string option, shippingCarrier: string option, shippingDate: string option, shippingDocumentation: DisputeEvidenceShippingDocumentationDU option, shippingTrackingNumber: string option, uncategorizedFile: DisputeEvidenceUncategorizedFileDU option, uncategorizedText: string option) =

        member _.AccessActivityLog = accessActivityLog
        member _.BillingAddress = billingAddress
        member _.CancellationPolicy = cancellationPolicy
        member _.CancellationPolicyDisclosure = cancellationPolicyDisclosure
        member _.CancellationRebuttal = cancellationRebuttal
        member _.CustomerCommunication = customerCommunication
        member _.CustomerEmailAddress = customerEmailAddress
        member _.CustomerName = customerName
        member _.CustomerPurchaseIp = customerPurchaseIp
        member _.CustomerSignature = customerSignature
        member _.DuplicateChargeDocumentation = duplicateChargeDocumentation
        member _.DuplicateChargeExplanation = duplicateChargeExplanation
        member _.DuplicateChargeId = duplicateChargeId
        member _.ProductDescription = productDescription
        member _.Receipt = receipt
        member _.RefundPolicy = refundPolicy
        member _.RefundPolicyDisclosure = refundPolicyDisclosure
        member _.RefundRefusalExplanation = refundRefusalExplanation
        member _.ServiceDate = serviceDate
        member _.ServiceDocumentation = serviceDocumentation
        member _.ShippingAddress = shippingAddress
        member _.ShippingCarrier = shippingCarrier
        member _.ShippingDate = shippingDate
        member _.ShippingDocumentation = shippingDocumentation
        member _.ShippingTrackingNumber = shippingTrackingNumber
        member _.UncategorizedFile = uncategorizedFile
        member _.UncategorizedText = uncategorizedText

    and DisputeEvidenceCancellationPolicyDU =
        | DisputeEvidenceCancellationPolicyDU'String of string
        | DisputeEvidenceCancellationPolicyDU'File of File

    and DisputeEvidenceCustomerCommunicationDU =
        | DisputeEvidenceCustomerCommunicationDU'String of string
        | DisputeEvidenceCustomerCommunicationDU'File of File

    and DisputeEvidenceCustomerSignatureDU =
        | DisputeEvidenceCustomerSignatureDU'String of string
        | DisputeEvidenceCustomerSignatureDU'File of File

    and DisputeEvidenceDuplicateChargeDocumentationDU =
        | DisputeEvidenceDuplicateChargeDocumentationDU'String of string
        | DisputeEvidenceDuplicateChargeDocumentationDU'File of File

    and DisputeEvidenceReceiptDU =
        | DisputeEvidenceReceiptDU'String of string
        | DisputeEvidenceReceiptDU'File of File

    and DisputeEvidenceRefundPolicyDU =
        | DisputeEvidenceRefundPolicyDU'String of string
        | DisputeEvidenceRefundPolicyDU'File of File

    and DisputeEvidenceServiceDocumentationDU =
        | DisputeEvidenceServiceDocumentationDU'String of string
        | DisputeEvidenceServiceDocumentationDU'File of File

    and DisputeEvidenceShippingDocumentationDU =
        | DisputeEvidenceShippingDocumentationDU'String of string
        | DisputeEvidenceShippingDocumentationDU'File of File

    and DisputeEvidenceUncategorizedFileDU =
        | DisputeEvidenceUncategorizedFileDU'String of string
        | DisputeEvidenceUncategorizedFileDU'File of File

    ///
    and DisputeEvidenceDetails (dueBy: int option, hasEvidence: bool, pastDue: bool, submissionCount: int) =

        member _.DueBy = dueBy
        member _.HasEvidence = hasEvidence
        member _.PastDue = pastDue
        member _.SubmissionCount = submissionCount

    ///
    and EphemeralKey (created: int, expires: int, id: string, livemode: bool, object: EphemeralKeyObject, ?secret: string) =

        member _.Created = created
        member _.Expires = expires
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = object
        member _.Secret = secret

    and EphemeralKeyObject =
        | EphemeralKeyObject'EphemeralKey

    ///An error response from the Stripe API
    and Error (error: ApiErrors) =

        member _.Error = error

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
    and Event (apiVersion: string option, created: int, data: NotificationEventData, id: string, livemode: bool, object: EventObject, pendingWebhooks: int, request: NotificationEventRequest option, ``type``: string, ?account: string) =

        member _.Account = account
        member _.ApiVersion = apiVersion
        member _.Created = created
        member _.Data = data
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = object
        member _.PendingWebhooks = pendingWebhooks
        member _.Request = request
        member _.Type = ``type``

    and EventObject =
        | EventObject'Event

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
    and ExchangeRate (id: string, object: ExchangeRateObject, rates: Map<string, string>) =

        member _.Id = id
        member _.Object = object
        member _.Rates = rates

    and ExchangeRateObject =
        | ExchangeRateObject'ExchangeRate

    and ExternalAccount =
        | ExternalAccount'BankAccount of BankAccount
        | ExternalAccount'Card of Card

    ///
    and Fee (amount: int, application: string option, currency: string, description: string option, ``type``: string) =

        member _.Amount = amount
        member _.Application = application
        member _.Currency = currency
        member _.Description = description
        member _.Type = ``type``

    ///`Application Fee Refund` objects allow you to refund an application fee that
    ///has previously been created but not yet refunded. Funds will be refunded to
    ///the Stripe account from which the fee was originally collected.
    ///
    ///Related guide: [Refunding Application Fees](https://stripe.com/docs/connect/destination-charges#refunding-app-fee).
    and FeeRefund (amount: int, balanceTransaction: FeeRefundBalanceTransactionDU option, created: int, currency: string, fee: FeeRefundFeeDU, id: string, metadata: Map<string, string> option, object: FeeRefundObject) =

        member _.Amount = amount
        member _.BalanceTransaction = balanceTransaction
        member _.Created = created
        member _.Currency = currency
        member _.Fee = fee
        member _.Id = id
        member _.Metadata = metadata
        member _.Object = object

    and FeeRefundObject =
        | FeeRefundObject'FeeRefund

    and FeeRefundBalanceTransactionDU =
        | FeeRefundBalanceTransactionDU'String of string
        | FeeRefundBalanceTransactionDU'BalanceTransaction of BalanceTransaction

    and FeeRefundFeeDU =
        | FeeRefundFeeDU'String of string
        | FeeRefundFeeDU'ApplicationFee of ApplicationFee

    ///This is an object representing a file hosted on Stripe's servers. The
    ///file may have been uploaded by yourself using the [create file](https://stripe.com/docs/api#create_file)
    ///request (for example, when uploading dispute evidence) or it may have
    ///been created by Stripe (for example, the results of a [Sigma scheduled
    ///query](#scheduled_queries)).
    ///
    ///Related guide: [File Upload Guide](https://stripe.com/docs/file-upload).
    and File (created: int, expiresAt: int option, filename: string option, id: string, object: FileObject, purpose: FilePurpose, size: int, title: string option, ``type``: string option, url: string option, ?links: Map<string, string> option) =

        member _.Created = created
        member _.ExpiresAt = expiresAt
        member _.Filename = filename
        member _.Id = id
        member _.Links = links |> Option.flatten
        member _.Object = object
        member _.Purpose = purpose
        member _.Size = size
        member _.Title = title
        member _.Type = ``type``
        member _.Url = url

    and FileObject =
        | FileObject'File

    and FilePurpose =
        | FilePurpose'AdditionalVerification
        | FilePurpose'BusinessIcon
        | FilePurpose'BusinessLogo
        | FilePurpose'CustomerSignature
        | FilePurpose'DisputeEvidence
        | FilePurpose'IdentityDocument
        | FilePurpose'PciDocument
        | FilePurpose'TaxDocumentUserUpload

    ///To share the contents of a `File` object with non-Stripe users, you can
    ///create a `FileLink`. `FileLink`s contain a URL that can be used to
    ///retrieve the contents of the file without authentication.
    and FileLink (created: int, expired: bool, expiresAt: int option, file: FileLinkFileDU, id: string, livemode: bool, metadata: Map<string, string>, object: FileLinkObject, url: string option) =

        member _.Created = created
        member _.Expired = expired
        member _.ExpiresAt = expiresAt
        member _.File = file
        member _.Id = id
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Object = object
        member _.Url = url

    and FileLinkObject =
        | FileLinkObject'FileLink

    and FileLinkFileDU =
        | FileLinkFileDU'String of string
        | FileLinkFileDU'File of File

    ///
    and FinancialReportingFinanceReportRunRunParameters (?columns: string list, ?connectedAccount: string, ?currency: string, ?intervalEnd: int, ?intervalStart: int, ?payout: string, ?reportingCategory: string, ?timezone: string) =

        member _.Columns = columns
        member _.ConnectedAccount = connectedAccount
        member _.Currency = currency
        member _.IntervalEnd = intervalEnd
        member _.IntervalStart = intervalStart
        member _.Payout = payout
        member _.ReportingCategory = reportingCategory
        member _.Timezone = timezone

    ///
    and Inventory (quantity: int option, ``type``: string, value: string option) =

        member _.Quantity = quantity
        member _.Type = ``type``
        member _.Value = value

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
    and Invoice (accountCountry: string option, accountName: string option, amountDue: int, amountPaid: int, amountRemaining: int, applicationFeeAmount: int option, attemptCount: int, attempted: bool, billingReason: InvoiceBillingReason option, charge: InvoiceChargeDU option, collectionMethod: InvoiceCollectionMethod option, created: int, currency: string, customFields: InvoiceSettingCustomField list option, customer: InvoiceCustomerDU, customerAddress: Address option, customerEmail: string option, customerName: string option, customerPhone: string option, customerShipping: Shipping option, customerTaxExempt: InvoiceCustomerTaxExempt option, defaultPaymentMethod: InvoiceDefaultPaymentMethodDU option, defaultSource: InvoiceDefaultSourceDU option, defaultTaxRates: TaxRate list, description: string option, discount: Discount option, discounts: InvoiceDiscountsDU list option, dueDate: int option, endingBalance: int option, footer: string option, lines: Map<string, string>, livemode: bool, metadata: Map<string, string> option, nextPaymentAttempt: int option, number: string option, object: InvoiceObject, paid: bool, paymentIntent: InvoicePaymentIntentDU option, periodEnd: int, periodStart: int, postPaymentCreditNotesAmount: int, prePaymentCreditNotesAmount: int, receiptNumber: string option, startingBalance: int, statementDescriptor: string option, status: InvoiceStatus option, statusTransitions: InvoicesStatusTransitions, subscription: InvoiceSubscriptionDU option, subtotal: int, tax: int option, total: int, totalDiscountAmounts: DiscountsResourceDiscountAmount list option, totalTaxAmounts: InvoiceTaxAmount list, transferData: InvoiceTransferData option, webhooksDeliveredAt: int option, ?accountTaxIds: InvoiceAccountTaxIdsDU list option, ?autoAdvance: bool, ?customerTaxIds: InvoicesResourceInvoiceTaxId list option, ?hostedInvoiceUrl: string option, ?id: string, ?invoicePdf: string option, ?lastFinalizationError: ApiErrors option, ?subscriptionProrationDate: int, ?thresholdReason: InvoiceThresholdReason) =

        member _.AccountCountry = accountCountry
        member _.AccountName = accountName
        member _.AccountTaxIds = accountTaxIds |> Option.flatten
        member _.AmountDue = amountDue
        member _.AmountPaid = amountPaid
        member _.AmountRemaining = amountRemaining
        member _.ApplicationFeeAmount = applicationFeeAmount
        member _.AttemptCount = attemptCount
        member _.Attempted = attempted
        member _.AutoAdvance = autoAdvance
        member _.BillingReason = billingReason
        member _.Charge = charge
        member _.CollectionMethod = collectionMethod
        member _.Created = created
        member _.Currency = currency
        member _.CustomFields = customFields
        member _.Customer = customer
        member _.CustomerAddress = customerAddress
        member _.CustomerEmail = customerEmail
        member _.CustomerName = customerName
        member _.CustomerPhone = customerPhone
        member _.CustomerShipping = customerShipping
        member _.CustomerTaxExempt = customerTaxExempt
        member _.CustomerTaxIds = customerTaxIds |> Option.flatten
        member _.DefaultPaymentMethod = defaultPaymentMethod
        member _.DefaultSource = defaultSource
        member _.DefaultTaxRates = defaultTaxRates
        member _.Description = description
        member _.Discount = discount
        member _.Discounts = discounts
        member _.DueDate = dueDate
        member _.EndingBalance = endingBalance
        member _.Footer = footer
        member _.HostedInvoiceUrl = hostedInvoiceUrl |> Option.flatten
        member _.Id = id
        member _.InvoicePdf = invoicePdf |> Option.flatten
        member _.LastFinalizationError = lastFinalizationError |> Option.flatten
        member _.Lines = lines
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.NextPaymentAttempt = nextPaymentAttempt
        member _.Number = number
        member _.Object = object
        member _.Paid = paid
        member _.PaymentIntent = paymentIntent
        member _.PeriodEnd = periodEnd
        member _.PeriodStart = periodStart
        member _.PostPaymentCreditNotesAmount = postPaymentCreditNotesAmount
        member _.PrePaymentCreditNotesAmount = prePaymentCreditNotesAmount
        member _.ReceiptNumber = receiptNumber
        member _.StartingBalance = startingBalance
        member _.StatementDescriptor = statementDescriptor
        member _.Status = status
        member _.StatusTransitions = statusTransitions
        member _.Subscription = subscription
        member _.SubscriptionProrationDate = subscriptionProrationDate
        member _.Subtotal = subtotal
        member _.Tax = tax
        member _.ThresholdReason = thresholdReason
        member _.Total = total
        member _.TotalDiscountAmounts = totalDiscountAmounts
        member _.TotalTaxAmounts = totalTaxAmounts
        member _.TransferData = transferData
        member _.WebhooksDeliveredAt = webhooksDeliveredAt

    and InvoiceBillingReason =
        | InvoiceBillingReason'AutomaticPendingInvoiceItemInvoice
        | InvoiceBillingReason'Manual
        | InvoiceBillingReason'Subscription
        | InvoiceBillingReason'SubscriptionCreate
        | InvoiceBillingReason'SubscriptionCycle
        | InvoiceBillingReason'SubscriptionThreshold
        | InvoiceBillingReason'SubscriptionUpdate
        | InvoiceBillingReason'Upcoming

    and InvoiceCollectionMethod =
        | InvoiceCollectionMethod'ChargeAutomatically
        | InvoiceCollectionMethod'SendInvoice

    and InvoiceCustomerTaxExempt =
        | InvoiceCustomerTaxExempt'Exempt
        | InvoiceCustomerTaxExempt'None
        | InvoiceCustomerTaxExempt'Reverse

    and InvoiceObject =
        | InvoiceObject'Invoice

    and InvoiceStatus =
        | InvoiceStatus'Deleted
        | InvoiceStatus'Draft
        | InvoiceStatus'Open
        | InvoiceStatus'Paid
        | InvoiceStatus'Uncollectible
        | InvoiceStatus'Void

    and InvoiceAccountTaxIdsDU =
        | InvoiceAccountTaxIdsDU'String of string
        | InvoiceAccountTaxIdsDU'TaxId of TaxId
        | InvoiceAccountTaxIdsDU'DeletedTaxId of DeletedTaxId

    and InvoiceChargeDU =
        | InvoiceChargeDU'String of string
        | InvoiceChargeDU'Charge of Charge

    and InvoiceCustomerDU =
        | InvoiceCustomerDU'String of string
        | InvoiceCustomerDU'Customer of Customer
        | InvoiceCustomerDU'DeletedCustomer of DeletedCustomer

    and InvoiceDefaultPaymentMethodDU =
        | InvoiceDefaultPaymentMethodDU'String of string
        | InvoiceDefaultPaymentMethodDU'PaymentMethod of PaymentMethod

    and InvoiceDefaultSourceDU =
        | InvoiceDefaultSourceDU'String of string
        | InvoiceDefaultSourceDU'PaymentSource of PaymentSource

    and InvoiceDiscountsDU =
        | InvoiceDiscountsDU'String of string
        | InvoiceDiscountsDU'Discount of Discount
        | InvoiceDiscountsDU'DeletedDiscount of DeletedDiscount

    and InvoicePaymentIntentDU =
        | InvoicePaymentIntentDU'String of string
        | InvoicePaymentIntentDU'PaymentIntent of PaymentIntent

    and InvoiceSubscriptionDU =
        | InvoiceSubscriptionDU'String of string
        | InvoiceSubscriptionDU'Subscription of Subscription

    ///
    and InvoiceItemThresholdReason (lineItemIds: string list, usageGte: int) =

        member _.LineItemIds = lineItemIds
        member _.UsageGte = usageGte

    ///
    and InvoiceLineItemPeriod (``end``: int, start: int) =

        member _.End = ``end``
        member _.Start = start

    ///
    and InvoiceSettingCustomField (name: string, value: string) =

        member _.Name = name
        member _.Value = value

    ///
    and InvoiceSettingCustomerSetting (customFields: InvoiceSettingCustomField list option, defaultPaymentMethod: InvoiceSettingCustomerSettingDefaultPaymentMethodDU option, footer: string option) =

        member _.CustomFields = customFields
        member _.DefaultPaymentMethod = defaultPaymentMethod
        member _.Footer = footer

    and InvoiceSettingCustomerSettingDefaultPaymentMethodDU =
        | InvoiceSettingCustomerSettingDefaultPaymentMethodDU'String of string
        | InvoiceSettingCustomerSettingDefaultPaymentMethodDU'PaymentMethod of PaymentMethod

    ///
    and InvoiceSettingSubscriptionScheduleSetting (daysUntilDue: int option) =

        member _.DaysUntilDue = daysUntilDue

    ///
    and InvoiceTaxAmount (amount: int, inclusive: bool, taxRate: InvoiceTaxAmountTaxRateDU) =

        member _.Amount = amount
        member _.Inclusive = inclusive
        member _.TaxRate = taxRate

    and InvoiceTaxAmountTaxRateDU =
        | InvoiceTaxAmountTaxRateDU'String of string
        | InvoiceTaxAmountTaxRateDU'TaxRate of TaxRate

    ///
    and InvoiceThresholdReason (amountGte: int option, itemReasons: InvoiceItemThresholdReason list) =

        member _.AmountGte = amountGte
        member _.ItemReasons = itemReasons

    ///
    and InvoiceTransferData (amount: int option, destination: InvoiceTransferDataDestinationDU) =

        member _.Amount = amount
        member _.Destination = destination

    and InvoiceTransferDataDestinationDU =
        | InvoiceTransferDataDestinationDU'String of string
        | InvoiceTransferDataDestinationDU'Account of Account

    ///Sometimes you want to add a charge or credit to a customer, but actually
    ///charge or credit the customer's card only at the end of a regular billing
    ///cycle. This is useful for combining several charges (to minimize
    ///per-transaction fees), or for having Stripe tabulate your usage-based billing
    ///totals.
    ///
    ///Related guide: [Subscription Invoices](https://stripe.com/docs/billing/invoices/subscription#adding-upcoming-invoice-items).
    and Invoiceitem (amount: int, currency: string, customer: InvoiceitemCustomerDU, date: int, description: string option, discountable: bool, discounts: InvoiceitemDiscountsDU list option, id: string, invoice: InvoiceitemInvoiceDU option, livemode: bool, metadata: Map<string, string> option, object: InvoiceitemObject, period: InvoiceLineItemPeriod, plan: Plan option, price: Price option, proration: bool, quantity: int, subscription: InvoiceitemSubscriptionDU option, taxRates: TaxRate list option, unitAmount: int option, unitAmountDecimal: string option, ?subscriptionItem: string) =

        member _.Amount = amount
        member _.Currency = currency
        member _.Customer = customer
        member _.Date = date
        member _.Description = description
        member _.Discountable = discountable
        member _.Discounts = discounts
        member _.Id = id
        member _.Invoice = invoice
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Object = object
        member _.Period = period
        member _.Plan = plan
        member _.Price = price
        member _.Proration = proration
        member _.Quantity = quantity
        member _.Subscription = subscription
        member _.SubscriptionItem = subscriptionItem
        member _.TaxRates = taxRates
        member _.UnitAmount = unitAmount
        member _.UnitAmountDecimal = unitAmountDecimal

    and InvoiceitemObject =
        | InvoiceitemObject'Invoiceitem

    and InvoiceitemCustomerDU =
        | InvoiceitemCustomerDU'String of string
        | InvoiceitemCustomerDU'Customer of Customer
        | InvoiceitemCustomerDU'DeletedCustomer of DeletedCustomer

    and InvoiceitemDiscountsDU =
        | InvoiceitemDiscountsDU'String of string
        | InvoiceitemDiscountsDU'Discount of Discount

    and InvoiceitemInvoiceDU =
        | InvoiceitemInvoiceDU'String of string
        | InvoiceitemInvoiceDU'Invoice of Invoice

    and InvoiceitemSubscriptionDU =
        | InvoiceitemSubscriptionDU'String of string
        | InvoiceitemSubscriptionDU'Subscription of Subscription

    ///
    and InvoicesResourceInvoiceTaxId (``type``: InvoicesResourceInvoiceTaxIdType, value: string option) =

        member _.Type = ``type``
        member _.Value = value

    and InvoicesResourceInvoiceTaxIdType =
        | InvoicesResourceInvoiceTaxIdType'AeTrn
        | InvoicesResourceInvoiceTaxIdType'AuAbn
        | InvoicesResourceInvoiceTaxIdType'BrCnpj
        | InvoicesResourceInvoiceTaxIdType'BrCpf
        | InvoicesResourceInvoiceTaxIdType'CaBn
        | InvoicesResourceInvoiceTaxIdType'CaQst
        | InvoicesResourceInvoiceTaxIdType'ChVat
        | InvoicesResourceInvoiceTaxIdType'ClTin
        | InvoicesResourceInvoiceTaxIdType'EsCif
        | InvoicesResourceInvoiceTaxIdType'EuVat
        | InvoicesResourceInvoiceTaxIdType'HkBr
        | InvoicesResourceInvoiceTaxIdType'IdNpwp
        | InvoicesResourceInvoiceTaxIdType'InGst
        | InvoicesResourceInvoiceTaxIdType'JpCn
        | InvoicesResourceInvoiceTaxIdType'JpRn
        | InvoicesResourceInvoiceTaxIdType'KrBrn
        | InvoicesResourceInvoiceTaxIdType'LiUid
        | InvoicesResourceInvoiceTaxIdType'MxRfc
        | InvoicesResourceInvoiceTaxIdType'MyFrp
        | InvoicesResourceInvoiceTaxIdType'MyItn
        | InvoicesResourceInvoiceTaxIdType'MySst
        | InvoicesResourceInvoiceTaxIdType'NoVat
        | InvoicesResourceInvoiceTaxIdType'NzGst
        | InvoicesResourceInvoiceTaxIdType'RuInn
        | InvoicesResourceInvoiceTaxIdType'RuKpp
        | InvoicesResourceInvoiceTaxIdType'SaVat
        | InvoicesResourceInvoiceTaxIdType'SgGst
        | InvoicesResourceInvoiceTaxIdType'SgUen
        | InvoicesResourceInvoiceTaxIdType'ThVat
        | InvoicesResourceInvoiceTaxIdType'TwVat
        | InvoicesResourceInvoiceTaxIdType'Unknown
        | InvoicesResourceInvoiceTaxIdType'UsEin
        | InvoicesResourceInvoiceTaxIdType'ZaVat

    ///
    and InvoicesStatusTransitions (finalizedAt: int option, markedUncollectibleAt: int option, paidAt: int option, voidedAt: int option) =

        member _.FinalizedAt = finalizedAt
        member _.MarkedUncollectibleAt = markedUncollectibleAt
        member _.PaidAt = paidAt
        member _.VoidedAt = voidedAt

    ///This resource has been renamed to [Early Fraud
    ///Warning](#early_fraud_warning_object) and will be removed in a future API
    ///version.
    and IssuerFraudRecord (actionable: bool, charge: IssuerFraudRecordChargeDU, created: int, fraudType: string, hasLiabilityShift: bool, id: string, livemode: bool, object: IssuerFraudRecordObject, postDate: int) =

        member _.Actionable = actionable
        member _.Charge = charge
        member _.Created = created
        member _.FraudType = fraudType
        member _.HasLiabilityShift = hasLiabilityShift
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = object
        member _.PostDate = postDate

    and IssuerFraudRecordObject =
        | IssuerFraudRecordObject'IssuerFraudRecord

    and IssuerFraudRecordChargeDU =
        | IssuerFraudRecordChargeDU'String of string
        | IssuerFraudRecordChargeDU'Charge of Charge

    ///When an [issued card](https://stripe.com/docs/issuing) is used to make a purchase, an Issuing `Authorization`
    ///object is created. [Authorizations](https://stripe.com/docs/issuing/purchases/authorizations) must be approved for the
    ///purchase to be completed successfully.
    ///
    ///Related guide: [Issued Card Authorizations](https://stripe.com/docs/issuing/purchases/authorizations).
    and IssuingAuthorization (amount: int, amountDetails: IssuingAuthorizationAmountDetails option, approved: bool, authorizationMethod: IssuingAuthorizationAuthorizationMethod, balanceTransactions: BalanceTransaction list, card: IssuingCard, cardholder: IssuingAuthorizationCardholderDU option, created: int, currency: string, id: string, livemode: bool, merchantAmount: int, merchantCurrency: string, merchantData: IssuingAuthorizationMerchantData, metadata: Map<string, string>, object: IssuingAuthorizationObject, pendingRequest: IssuingAuthorizationPendingRequest option, requestHistory: IssuingAuthorizationRequest list, status: IssuingAuthorizationStatus, transactions: IssuingTransaction list, verificationData: IssuingAuthorizationVerificationData, wallet: string option) =

        member _.Amount = amount
        member _.AmountDetails = amountDetails
        member _.Approved = approved
        member _.AuthorizationMethod = authorizationMethod
        member _.BalanceTransactions = balanceTransactions
        member _.Card = card
        member _.Cardholder = cardholder
        member _.Created = created
        member _.Currency = currency
        member _.Id = id
        member _.Livemode = livemode
        member _.MerchantAmount = merchantAmount
        member _.MerchantCurrency = merchantCurrency
        member _.MerchantData = merchantData
        member _.Metadata = metadata
        member _.Object = object
        member _.PendingRequest = pendingRequest
        member _.RequestHistory = requestHistory
        member _.Status = status
        member _.Transactions = transactions
        member _.VerificationData = verificationData
        member _.Wallet = wallet

    and IssuingAuthorizationAuthorizationMethod =
        | IssuingAuthorizationAuthorizationMethod'Chip
        | IssuingAuthorizationAuthorizationMethod'Contactless
        | IssuingAuthorizationAuthorizationMethod'KeyedIn
        | IssuingAuthorizationAuthorizationMethod'Online
        | IssuingAuthorizationAuthorizationMethod'Swipe

    and IssuingAuthorizationObject =
        | IssuingAuthorizationObject'IssuingAuthorization

    and IssuingAuthorizationStatus =
        | IssuingAuthorizationStatus'Closed
        | IssuingAuthorizationStatus'Pending
        | IssuingAuthorizationStatus'Reversed

    and IssuingAuthorizationCardholderDU =
        | IssuingAuthorizationCardholderDU'String of string
        | IssuingAuthorizationCardholderDU'IssuingCardholder of IssuingCardholder

    ///You can [create physical or virtual cards](https://stripe.com/docs/issuing/cards) that are issued to cardholders.
    and IssuingCard (brand: string, cancellationReason: IssuingCardCancellationReason option, cardholder: IssuingCardholder, created: int, currency: string, expMonth: int, expYear: int, id: string, last4: string, livemode: bool, metadata: Map<string, string>, object: IssuingCardObject, replacedBy: IssuingCardReplacedByDU option, replacementFor: IssuingCardReplacementForDU option, replacementReason: IssuingCardReplacementReason option, shipping: IssuingCardShipping option, spendingControls: IssuingCardAuthorizationControls, status: IssuingCardStatus, ``type``: IssuingCardType, ?cvc: string, ?number: string) =

        member _.Brand = brand
        member _.CancellationReason = cancellationReason
        member _.Cardholder = cardholder
        member _.Created = created
        member _.Currency = currency
        member _.Cvc = cvc
        member _.ExpMonth = expMonth
        member _.ExpYear = expYear
        member _.Id = id
        member _.Last4 = last4
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Number = number
        member _.Object = object
        member _.ReplacedBy = replacedBy
        member _.ReplacementFor = replacementFor
        member _.ReplacementReason = replacementReason
        member _.Shipping = shipping
        member _.SpendingControls = spendingControls
        member _.Status = status
        member _.Type = ``type``

    and IssuingCardCancellationReason =
        | IssuingCardCancellationReason'Lost
        | IssuingCardCancellationReason'Stolen

    and IssuingCardObject =
        | IssuingCardObject'IssuingCard

    and IssuingCardReplacementReason =
        | IssuingCardReplacementReason'Damaged
        | IssuingCardReplacementReason'Expired
        | IssuingCardReplacementReason'Lost
        | IssuingCardReplacementReason'Stolen

    and IssuingCardStatus =
        | IssuingCardStatus'Active
        | IssuingCardStatus'Canceled
        | IssuingCardStatus'Inactive

    and IssuingCardType =
        | IssuingCardType'Physical
        | IssuingCardType'Virtual

    and IssuingCardReplacedByDU =
        | IssuingCardReplacedByDU'String of string
        | IssuingCardReplacedByDU'IssuingCard of IssuingCard

    and IssuingCardReplacementForDU =
        | IssuingCardReplacementForDU'String of string
        | IssuingCardReplacementForDU'IssuingCard of IssuingCard

    ///An Issuing `Cardholder` object represents an individual or business entity who is [issued](https://stripe.com/docs/issuing) cards.
    ///
    ///Related guide: [How to create a Cardholder](https://stripe.com/docs/issuing/cards#create-cardholder)
    and IssuingCardholder (billing: IssuingCardholderAddress, company: IssuingCardholderCompany option, created: int, email: string option, id: string, individual: IssuingCardholderIndividual option, livemode: bool, metadata: Map<string, string>, name: string, object: IssuingCardholderObject, phoneNumber: string option, requirements: IssuingCardholderRequirements, spendingControls: IssuingCardholderAuthorizationControls option, status: IssuingCardholderStatus, ``type``: IssuingCardholderType) =

        member _.Billing = billing
        member _.Company = company
        member _.Created = created
        member _.Email = email
        member _.Id = id
        member _.Individual = individual
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Name = name
        member _.Object = object
        member _.PhoneNumber = phoneNumber
        member _.Requirements = requirements
        member _.SpendingControls = spendingControls
        member _.Status = status
        member _.Type = ``type``

    and IssuingCardholderObject =
        | IssuingCardholderObject'IssuingCardholder

    and IssuingCardholderStatus =
        | IssuingCardholderStatus'Active
        | IssuingCardholderStatus'Blocked
        | IssuingCardholderStatus'Inactive

    and IssuingCardholderType =
        | IssuingCardholderType'Company
        | IssuingCardholderType'Individual

    ///As a [card issuer](https://stripe.com/docs/issuing), you can dispute transactions that the cardholder does not recognize, suspects to be fraudulent, or has other issues with.
    ///
    ///Related guide: [Disputing Transactions](https://stripe.com/docs/issuing/purchases/disputes)
    and IssuingDispute (balanceTransactions: BalanceTransaction list option, id: string, livemode: bool, object: IssuingDisputeObject, transaction: IssuingDisputeTransactionDU, ?amount: int, ?created: int, ?currency: string, ?evidence: IssuingDisputeEvidence, ?metadata: Map<string, string>, ?status: IssuingDisputeStatus) =

        member _.Amount = amount
        member _.BalanceTransactions = balanceTransactions
        member _.Created = created
        member _.Currency = currency
        member _.Evidence = evidence
        member _.Id = id
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Object = object
        member _.Status = status
        member _.Transaction = transaction

    and IssuingDisputeObject =
        | IssuingDisputeObject'IssuingDispute

    and IssuingDisputeStatus =
        | IssuingDisputeStatus'Expired
        | IssuingDisputeStatus'Lost
        | IssuingDisputeStatus'Submitted
        | IssuingDisputeStatus'Unsubmitted
        | IssuingDisputeStatus'Won

    and IssuingDisputeTransactionDU =
        | IssuingDisputeTransactionDU'String of string
        | IssuingDisputeTransactionDU'IssuingTransaction of IssuingTransaction

    ///Any use of an [issued card](https://stripe.com/docs/issuing) that results in funds entering or leaving
    ///your Stripe account, such as a completed purchase or refund, is represented by an Issuing
    ///`Transaction` object.
    ///
    ///Related guide: [Issued Card Transactions](https://stripe.com/docs/issuing/purchases/transactions).
    and IssuingTransaction (amount: int, amountDetails: IssuingTransactionAmountDetails option, authorization: IssuingTransactionAuthorizationDU option, balanceTransaction: IssuingTransactionBalanceTransactionDU option, card: IssuingTransactionCardDU, cardholder: IssuingTransactionCardholderDU option, created: int, currency: string, id: string, livemode: bool, merchantAmount: int, merchantCurrency: string, merchantData: IssuingAuthorizationMerchantData, metadata: Map<string, string>, object: IssuingTransactionObject, purchaseDetails: IssuingTransactionPurchaseDetails option, ``type``: IssuingTransactionType, ?dispute: IssuingTransactionDisputeDU option) =

        member _.Amount = amount
        member _.AmountDetails = amountDetails
        member _.Authorization = authorization
        member _.BalanceTransaction = balanceTransaction
        member _.Card = card
        member _.Cardholder = cardholder
        member _.Created = created
        member _.Currency = currency
        member _.Dispute = dispute |> Option.flatten
        member _.Id = id
        member _.Livemode = livemode
        member _.MerchantAmount = merchantAmount
        member _.MerchantCurrency = merchantCurrency
        member _.MerchantData = merchantData
        member _.Metadata = metadata
        member _.Object = object
        member _.PurchaseDetails = purchaseDetails
        member _.Type = ``type``

    and IssuingTransactionObject =
        | IssuingTransactionObject'IssuingTransaction

    and IssuingTransactionType =
        | IssuingTransactionType'Capture
        | IssuingTransactionType'Dispute
        | IssuingTransactionType'Refund

    and IssuingTransactionAuthorizationDU =
        | IssuingTransactionAuthorizationDU'String of string
        | IssuingTransactionAuthorizationDU'IssuingAuthorization of IssuingAuthorization

    and IssuingTransactionBalanceTransactionDU =
        | IssuingTransactionBalanceTransactionDU'String of string
        | IssuingTransactionBalanceTransactionDU'BalanceTransaction of BalanceTransaction

    and IssuingTransactionCardDU =
        | IssuingTransactionCardDU'String of string
        | IssuingTransactionCardDU'IssuingCard of IssuingCard

    and IssuingTransactionCardholderDU =
        | IssuingTransactionCardholderDU'String of string
        | IssuingTransactionCardholderDU'IssuingCardholder of IssuingCardholder

    and IssuingTransactionDisputeDU =
        | IssuingTransactionDisputeDU'String of string
        | IssuingTransactionDisputeDU'IssuingDispute of IssuingDispute

    ///
    and IssuingAuthorizationAmountDetails (atmFee: int option) =

        member _.AtmFee = atmFee

    ///
    and IssuingAuthorizationMerchantData (category: string, city: string option, country: string option, name: string option, networkId: string, postalCode: string option, state: string option) =

        member _.Category = category
        member _.City = city
        member _.Country = country
        member _.Name = name
        member _.NetworkId = networkId
        member _.PostalCode = postalCode
        member _.State = state

    ///
    and IssuingAuthorizationPendingRequest (amount: int, amountDetails: IssuingAuthorizationAmountDetails option, currency: string, isAmountControllable: bool, merchantAmount: int, merchantCurrency: string) =

        member _.Amount = amount
        member _.AmountDetails = amountDetails
        member _.Currency = currency
        member _.IsAmountControllable = isAmountControllable
        member _.MerchantAmount = merchantAmount
        member _.MerchantCurrency = merchantCurrency

    ///
    and IssuingAuthorizationRequest (amount: int, amountDetails: IssuingAuthorizationAmountDetails option, approved: bool, created: int, currency: string, merchantAmount: int, merchantCurrency: string, reason: IssuingAuthorizationRequestReason) =

        member _.Amount = amount
        member _.AmountDetails = amountDetails
        member _.Approved = approved
        member _.Created = created
        member _.Currency = currency
        member _.MerchantAmount = merchantAmount
        member _.MerchantCurrency = merchantCurrency
        member _.Reason = reason

    and IssuingAuthorizationRequestReason =
        | IssuingAuthorizationRequestReason'AccountDisabled
        | IssuingAuthorizationRequestReason'CardActive
        | IssuingAuthorizationRequestReason'CardInactive
        | IssuingAuthorizationRequestReason'CardholderInactive
        | IssuingAuthorizationRequestReason'CardholderVerificationRequired
        | IssuingAuthorizationRequestReason'InsufficientFunds
        | IssuingAuthorizationRequestReason'NotAllowed
        | IssuingAuthorizationRequestReason'SpendingControls
        | IssuingAuthorizationRequestReason'SuspectedFraud
        | IssuingAuthorizationRequestReason'VerificationFailed
        | IssuingAuthorizationRequestReason'WebhookApproved
        | IssuingAuthorizationRequestReason'WebhookDeclined
        | IssuingAuthorizationRequestReason'WebhookTimeout

    ///
    and IssuingAuthorizationVerificationData (addressLine1Check: IssuingAuthorizationVerificationDataAddressLine1Check, addressPostalCodeCheck: IssuingAuthorizationVerificationDataAddressPostalCodeCheck, cvcCheck: IssuingAuthorizationVerificationDataCvcCheck, expiryCheck: IssuingAuthorizationVerificationDataExpiryCheck) =

        member _.AddressLine1Check = addressLine1Check
        member _.AddressPostalCodeCheck = addressPostalCodeCheck
        member _.CvcCheck = cvcCheck
        member _.ExpiryCheck = expiryCheck

    and IssuingAuthorizationVerificationDataAddressLine1Check =
        | IssuingAuthorizationVerificationDataAddressLine1Check'Match
        | IssuingAuthorizationVerificationDataAddressLine1Check'Mismatch
        | IssuingAuthorizationVerificationDataAddressLine1Check'NotProvided

    and IssuingAuthorizationVerificationDataAddressPostalCodeCheck =
        | IssuingAuthorizationVerificationDataAddressPostalCodeCheck'Match
        | IssuingAuthorizationVerificationDataAddressPostalCodeCheck'Mismatch
        | IssuingAuthorizationVerificationDataAddressPostalCodeCheck'NotProvided

    and IssuingAuthorizationVerificationDataCvcCheck =
        | IssuingAuthorizationVerificationDataCvcCheck'Match
        | IssuingAuthorizationVerificationDataCvcCheck'Mismatch
        | IssuingAuthorizationVerificationDataCvcCheck'NotProvided

    and IssuingAuthorizationVerificationDataExpiryCheck =
        | IssuingAuthorizationVerificationDataExpiryCheck'Match
        | IssuingAuthorizationVerificationDataExpiryCheck'Mismatch
        | IssuingAuthorizationVerificationDataExpiryCheck'NotProvided

    ///
    and IssuingCardAuthorizationControls (allowedCategories: IssuingCardAuthorizationControlsAllowedCategories list option, blockedCategories: IssuingCardAuthorizationControlsBlockedCategories list option, spendingLimits: IssuingCardSpendingLimit list option, spendingLimitsCurrency: string option) =

        member _.AllowedCategories = allowedCategories
        member _.BlockedCategories = blockedCategories
        member _.SpendingLimits = spendingLimits
        member _.SpendingLimitsCurrency = spendingLimitsCurrency

    and IssuingCardAuthorizationControlsAllowedCategories =
        | IssuingCardAuthorizationControlsAllowedCategories'AcRefrigerationRepair
        | IssuingCardAuthorizationControlsAllowedCategories'AccountingBookkeepingServices
        | IssuingCardAuthorizationControlsAllowedCategories'AdvertisingServices
        | IssuingCardAuthorizationControlsAllowedCategories'AgriculturalCooperative
        | IssuingCardAuthorizationControlsAllowedCategories'AirlinesAirCarriers
        | IssuingCardAuthorizationControlsAllowedCategories'AirportsFlyingFields
        | IssuingCardAuthorizationControlsAllowedCategories'AmbulanceServices
        | IssuingCardAuthorizationControlsAllowedCategories'AmusementParksCarnivals
        | IssuingCardAuthorizationControlsAllowedCategories'AntiqueReproductions
        | IssuingCardAuthorizationControlsAllowedCategories'AntiqueShops
        | IssuingCardAuthorizationControlsAllowedCategories'Aquariums
        | IssuingCardAuthorizationControlsAllowedCategories'ArchitecturalSurveyingServices
        | IssuingCardAuthorizationControlsAllowedCategories'ArtDealersAndGalleries
        | IssuingCardAuthorizationControlsAllowedCategories'ArtistsSupplyAndCraftShops
        | IssuingCardAuthorizationControlsAllowedCategories'AutoAndHomeSupplyStores
        | IssuingCardAuthorizationControlsAllowedCategories'AutoBodyRepairShops
        | IssuingCardAuthorizationControlsAllowedCategories'AutoPaintShops
        | IssuingCardAuthorizationControlsAllowedCategories'AutoServiceShops
        | IssuingCardAuthorizationControlsAllowedCategories'AutomatedCashDisburse
        | IssuingCardAuthorizationControlsAllowedCategories'AutomatedFuelDispensers
        | IssuingCardAuthorizationControlsAllowedCategories'AutomobileAssociations
        | IssuingCardAuthorizationControlsAllowedCategories'AutomotivePartsAndAccessoriesStores
        | IssuingCardAuthorizationControlsAllowedCategories'AutomotiveTireStores
        | IssuingCardAuthorizationControlsAllowedCategories'BailAndBondPayments
        | IssuingCardAuthorizationControlsAllowedCategories'Bakeries
        | IssuingCardAuthorizationControlsAllowedCategories'BandsOrchestras
        | IssuingCardAuthorizationControlsAllowedCategories'BarberAndBeautyShops
        | IssuingCardAuthorizationControlsAllowedCategories'BettingCasinoGambling
        | IssuingCardAuthorizationControlsAllowedCategories'BicycleShops
        | IssuingCardAuthorizationControlsAllowedCategories'BilliardPoolEstablishments
        | IssuingCardAuthorizationControlsAllowedCategories'BoatDealers
        | IssuingCardAuthorizationControlsAllowedCategories'BoatRentalsAndLeases
        | IssuingCardAuthorizationControlsAllowedCategories'BookStores
        | IssuingCardAuthorizationControlsAllowedCategories'BooksPeriodicalsAndNewspapers
        | IssuingCardAuthorizationControlsAllowedCategories'BowlingAlleys
        | IssuingCardAuthorizationControlsAllowedCategories'BusLines
        | IssuingCardAuthorizationControlsAllowedCategories'BusinessSecretarialSchools
        | IssuingCardAuthorizationControlsAllowedCategories'BuyingShoppingServices
        | IssuingCardAuthorizationControlsAllowedCategories'CableSatelliteAndOtherPayTelevisionAndRadio
        | IssuingCardAuthorizationControlsAllowedCategories'CameraAndPhotographicSupplyStores
        | IssuingCardAuthorizationControlsAllowedCategories'CandyNutAndConfectioneryStores
        | IssuingCardAuthorizationControlsAllowedCategories'CarAndTruckDealersNewUsed
        | IssuingCardAuthorizationControlsAllowedCategories'CarAndTruckDealersUsedOnly
        | IssuingCardAuthorizationControlsAllowedCategories'CarRentalAgencies
        | IssuingCardAuthorizationControlsAllowedCategories'CarWashes
        | IssuingCardAuthorizationControlsAllowedCategories'CarpentryServices
        | IssuingCardAuthorizationControlsAllowedCategories'CarpetUpholsteryCleaning
        | IssuingCardAuthorizationControlsAllowedCategories'Caterers
        | IssuingCardAuthorizationControlsAllowedCategories'CharitableAndSocialServiceOrganizationsFundraising
        | IssuingCardAuthorizationControlsAllowedCategories'ChemicalsAndAlliedProducts
        | IssuingCardAuthorizationControlsAllowedCategories'ChildCareServices
        | IssuingCardAuthorizationControlsAllowedCategories'ChildrensAndInfantsWearStores
        | IssuingCardAuthorizationControlsAllowedCategories'ChiropodistsPodiatrists
        | IssuingCardAuthorizationControlsAllowedCategories'Chiropractors
        | IssuingCardAuthorizationControlsAllowedCategories'CigarStoresAndStands
        | IssuingCardAuthorizationControlsAllowedCategories'CivicSocialFraternalAssociations
        | IssuingCardAuthorizationControlsAllowedCategories'CleaningAndMaintenance
        | IssuingCardAuthorizationControlsAllowedCategories'ClothingRental
        | IssuingCardAuthorizationControlsAllowedCategories'CollegesUniversities
        | IssuingCardAuthorizationControlsAllowedCategories'CommercialEquipment
        | IssuingCardAuthorizationControlsAllowedCategories'CommercialFootwear
        | IssuingCardAuthorizationControlsAllowedCategories'CommercialPhotographyArtAndGraphics
        | IssuingCardAuthorizationControlsAllowedCategories'CommuterTransportAndFerries
        | IssuingCardAuthorizationControlsAllowedCategories'ComputerNetworkServices
        | IssuingCardAuthorizationControlsAllowedCategories'ComputerProgramming
        | IssuingCardAuthorizationControlsAllowedCategories'ComputerRepair
        | IssuingCardAuthorizationControlsAllowedCategories'ComputerSoftwareStores
        | IssuingCardAuthorizationControlsAllowedCategories'ComputersPeripheralsAndSoftware
        | IssuingCardAuthorizationControlsAllowedCategories'ConcreteWorkServices
        | IssuingCardAuthorizationControlsAllowedCategories'ConstructionMaterials
        | IssuingCardAuthorizationControlsAllowedCategories'ConsultingPublicRelations
        | IssuingCardAuthorizationControlsAllowedCategories'CorrespondenceSchools
        | IssuingCardAuthorizationControlsAllowedCategories'CosmeticStores
        | IssuingCardAuthorizationControlsAllowedCategories'CounselingServices
        | IssuingCardAuthorizationControlsAllowedCategories'CountryClubs
        | IssuingCardAuthorizationControlsAllowedCategories'CourierServices
        | IssuingCardAuthorizationControlsAllowedCategories'CourtCosts
        | IssuingCardAuthorizationControlsAllowedCategories'CreditReportingAgencies
        | IssuingCardAuthorizationControlsAllowedCategories'CruiseLines
        | IssuingCardAuthorizationControlsAllowedCategories'DairyProductsStores
        | IssuingCardAuthorizationControlsAllowedCategories'DanceHallStudiosSchools
        | IssuingCardAuthorizationControlsAllowedCategories'DatingEscortServices
        | IssuingCardAuthorizationControlsAllowedCategories'DentistsOrthodontists
        | IssuingCardAuthorizationControlsAllowedCategories'DepartmentStores
        | IssuingCardAuthorizationControlsAllowedCategories'DetectiveAgencies
        | IssuingCardAuthorizationControlsAllowedCategories'DigitalGoodsApplications
        | IssuingCardAuthorizationControlsAllowedCategories'DigitalGoodsGames
        | IssuingCardAuthorizationControlsAllowedCategories'DigitalGoodsLargeVolume
        | IssuingCardAuthorizationControlsAllowedCategories'DigitalGoodsMedia
        | IssuingCardAuthorizationControlsAllowedCategories'DirectMarketingCatalogMerchant
        | IssuingCardAuthorizationControlsAllowedCategories'DirectMarketingCombinationCatalogAndRetailMerchant
        | IssuingCardAuthorizationControlsAllowedCategories'DirectMarketingInboundTelemarketing
        | IssuingCardAuthorizationControlsAllowedCategories'DirectMarketingInsuranceServices
        | IssuingCardAuthorizationControlsAllowedCategories'DirectMarketingOther
        | IssuingCardAuthorizationControlsAllowedCategories'DirectMarketingOutboundTelemarketing
        | IssuingCardAuthorizationControlsAllowedCategories'DirectMarketingSubscription
        | IssuingCardAuthorizationControlsAllowedCategories'DirectMarketingTravel
        | IssuingCardAuthorizationControlsAllowedCategories'DiscountStores
        | IssuingCardAuthorizationControlsAllowedCategories'Doctors
        | IssuingCardAuthorizationControlsAllowedCategories'DoorToDoorSales
        | IssuingCardAuthorizationControlsAllowedCategories'DraperyWindowCoveringAndUpholsteryStores
        | IssuingCardAuthorizationControlsAllowedCategories'DrinkingPlaces
        | IssuingCardAuthorizationControlsAllowedCategories'DrugStoresAndPharmacies
        | IssuingCardAuthorizationControlsAllowedCategories'DrugsDrugProprietariesAndDruggistSundries
        | IssuingCardAuthorizationControlsAllowedCategories'DryCleaners
        | IssuingCardAuthorizationControlsAllowedCategories'DurableGoods
        | IssuingCardAuthorizationControlsAllowedCategories'DutyFreeStores
        | IssuingCardAuthorizationControlsAllowedCategories'EatingPlacesRestaurants
        | IssuingCardAuthorizationControlsAllowedCategories'EducationalServices
        | IssuingCardAuthorizationControlsAllowedCategories'ElectricRazorStores
        | IssuingCardAuthorizationControlsAllowedCategories'ElectricalPartsAndEquipment
        | IssuingCardAuthorizationControlsAllowedCategories'ElectricalServices
        | IssuingCardAuthorizationControlsAllowedCategories'ElectronicsRepairShops
        | IssuingCardAuthorizationControlsAllowedCategories'ElectronicsStores
        | IssuingCardAuthorizationControlsAllowedCategories'ElementarySecondarySchools
        | IssuingCardAuthorizationControlsAllowedCategories'EmploymentTempAgencies
        | IssuingCardAuthorizationControlsAllowedCategories'EquipmentRental
        | IssuingCardAuthorizationControlsAllowedCategories'ExterminatingServices
        | IssuingCardAuthorizationControlsAllowedCategories'FamilyClothingStores
        | IssuingCardAuthorizationControlsAllowedCategories'FastFoodRestaurants
        | IssuingCardAuthorizationControlsAllowedCategories'FinancialInstitutions
        | IssuingCardAuthorizationControlsAllowedCategories'FinesGovernmentAdministrativeEntities
        | IssuingCardAuthorizationControlsAllowedCategories'FireplaceFireplaceScreensAndAccessoriesStores
        | IssuingCardAuthorizationControlsAllowedCategories'FloorCoveringStores
        | IssuingCardAuthorizationControlsAllowedCategories'Florists
        | IssuingCardAuthorizationControlsAllowedCategories'FloristsSuppliesNurseryStockAndFlowers
        | IssuingCardAuthorizationControlsAllowedCategories'FreezerAndLockerMeatProvisioners
        | IssuingCardAuthorizationControlsAllowedCategories'FuelDealersNonAutomotive
        | IssuingCardAuthorizationControlsAllowedCategories'FuneralServicesCrematories
        | IssuingCardAuthorizationControlsAllowedCategories'FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | IssuingCardAuthorizationControlsAllowedCategories'FurnitureRepairRefinishing
        | IssuingCardAuthorizationControlsAllowedCategories'FurriersAndFurShops
        | IssuingCardAuthorizationControlsAllowedCategories'GeneralServices
        | IssuingCardAuthorizationControlsAllowedCategories'GiftCardNoveltyAndSouvenirShops
        | IssuingCardAuthorizationControlsAllowedCategories'GlassPaintAndWallpaperStores
        | IssuingCardAuthorizationControlsAllowedCategories'GlasswareCrystalStores
        | IssuingCardAuthorizationControlsAllowedCategories'GolfCoursesPublic
        | IssuingCardAuthorizationControlsAllowedCategories'GovernmentServices
        | IssuingCardAuthorizationControlsAllowedCategories'GroceryStoresSupermarkets
        | IssuingCardAuthorizationControlsAllowedCategories'HardwareEquipmentAndSupplies
        | IssuingCardAuthorizationControlsAllowedCategories'HardwareStores
        | IssuingCardAuthorizationControlsAllowedCategories'HealthAndBeautySpas
        | IssuingCardAuthorizationControlsAllowedCategories'HearingAidsSalesAndSupplies
        | IssuingCardAuthorizationControlsAllowedCategories'HeatingPlumbingAC
        | IssuingCardAuthorizationControlsAllowedCategories'HobbyToyAndGameShops
        | IssuingCardAuthorizationControlsAllowedCategories'HomeSupplyWarehouseStores
        | IssuingCardAuthorizationControlsAllowedCategories'Hospitals
        | IssuingCardAuthorizationControlsAllowedCategories'HotelsMotelsAndResorts
        | IssuingCardAuthorizationControlsAllowedCategories'HouseholdApplianceStores
        | IssuingCardAuthorizationControlsAllowedCategories'IndustrialSupplies
        | IssuingCardAuthorizationControlsAllowedCategories'InformationRetrievalServices
        | IssuingCardAuthorizationControlsAllowedCategories'InsuranceDefault
        | IssuingCardAuthorizationControlsAllowedCategories'InsuranceUnderwritingPremiums
        | IssuingCardAuthorizationControlsAllowedCategories'IntraCompanyPurchases
        | IssuingCardAuthorizationControlsAllowedCategories'JewelryStoresWatchesClocksAndSilverwareStores
        | IssuingCardAuthorizationControlsAllowedCategories'LandscapingServices
        | IssuingCardAuthorizationControlsAllowedCategories'Laundries
        | IssuingCardAuthorizationControlsAllowedCategories'LaundryCleaningServices
        | IssuingCardAuthorizationControlsAllowedCategories'LegalServicesAttorneys
        | IssuingCardAuthorizationControlsAllowedCategories'LuggageAndLeatherGoodsStores
        | IssuingCardAuthorizationControlsAllowedCategories'LumberBuildingMaterialsStores
        | IssuingCardAuthorizationControlsAllowedCategories'ManualCashDisburse
        | IssuingCardAuthorizationControlsAllowedCategories'MarinasServiceAndSupplies
        | IssuingCardAuthorizationControlsAllowedCategories'MasonryStoneworkAndPlaster
        | IssuingCardAuthorizationControlsAllowedCategories'MassageParlors
        | IssuingCardAuthorizationControlsAllowedCategories'MedicalAndDentalLabs
        | IssuingCardAuthorizationControlsAllowedCategories'MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | IssuingCardAuthorizationControlsAllowedCategories'MedicalServices
        | IssuingCardAuthorizationControlsAllowedCategories'MembershipOrganizations
        | IssuingCardAuthorizationControlsAllowedCategories'MensAndBoysClothingAndAccessoriesStores
        | IssuingCardAuthorizationControlsAllowedCategories'MensWomensClothingStores
        | IssuingCardAuthorizationControlsAllowedCategories'MetalServiceCenters
        | IssuingCardAuthorizationControlsAllowedCategories'Miscellaneous
        | IssuingCardAuthorizationControlsAllowedCategories'MiscellaneousApparelAndAccessoryShops
        | IssuingCardAuthorizationControlsAllowedCategories'MiscellaneousAutoDealers
        | IssuingCardAuthorizationControlsAllowedCategories'MiscellaneousBusinessServices
        | IssuingCardAuthorizationControlsAllowedCategories'MiscellaneousFoodStores
        | IssuingCardAuthorizationControlsAllowedCategories'MiscellaneousGeneralMerchandise
        | IssuingCardAuthorizationControlsAllowedCategories'MiscellaneousGeneralServices
        | IssuingCardAuthorizationControlsAllowedCategories'MiscellaneousHomeFurnishingSpecialtyStores
        | IssuingCardAuthorizationControlsAllowedCategories'MiscellaneousPublishingAndPrinting
        | IssuingCardAuthorizationControlsAllowedCategories'MiscellaneousRecreationServices
        | IssuingCardAuthorizationControlsAllowedCategories'MiscellaneousRepairShops
        | IssuingCardAuthorizationControlsAllowedCategories'MiscellaneousSpecialtyRetail
        | IssuingCardAuthorizationControlsAllowedCategories'MobileHomeDealers
        | IssuingCardAuthorizationControlsAllowedCategories'MotionPictureTheaters
        | IssuingCardAuthorizationControlsAllowedCategories'MotorFreightCarriersAndTrucking
        | IssuingCardAuthorizationControlsAllowedCategories'MotorHomesDealers
        | IssuingCardAuthorizationControlsAllowedCategories'MotorVehicleSuppliesAndNewParts
        | IssuingCardAuthorizationControlsAllowedCategories'MotorcycleShopsAndDealers
        | IssuingCardAuthorizationControlsAllowedCategories'MotorcycleShopsDealers
        | IssuingCardAuthorizationControlsAllowedCategories'MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | IssuingCardAuthorizationControlsAllowedCategories'NewsDealersAndNewsstands
        | IssuingCardAuthorizationControlsAllowedCategories'NonFiMoneyOrders
        | IssuingCardAuthorizationControlsAllowedCategories'NonFiStoredValueCardPurchaseLoad
        | IssuingCardAuthorizationControlsAllowedCategories'NondurableGoods
        | IssuingCardAuthorizationControlsAllowedCategories'NurseriesLawnAndGardenSupplyStores
        | IssuingCardAuthorizationControlsAllowedCategories'NursingPersonalCare
        | IssuingCardAuthorizationControlsAllowedCategories'OfficeAndCommercialFurniture
        | IssuingCardAuthorizationControlsAllowedCategories'OpticiansEyeglasses
        | IssuingCardAuthorizationControlsAllowedCategories'OptometristsOphthalmologist
        | IssuingCardAuthorizationControlsAllowedCategories'OrthopedicGoodsProstheticDevices
        | IssuingCardAuthorizationControlsAllowedCategories'Osteopaths
        | IssuingCardAuthorizationControlsAllowedCategories'PackageStoresBeerWineAndLiquor
        | IssuingCardAuthorizationControlsAllowedCategories'PaintsVarnishesAndSupplies
        | IssuingCardAuthorizationControlsAllowedCategories'ParkingLotsGarages
        | IssuingCardAuthorizationControlsAllowedCategories'PassengerRailways
        | IssuingCardAuthorizationControlsAllowedCategories'PawnShops
        | IssuingCardAuthorizationControlsAllowedCategories'PetShopsPetFoodAndSupplies
        | IssuingCardAuthorizationControlsAllowedCategories'PetroleumAndPetroleumProducts
        | IssuingCardAuthorizationControlsAllowedCategories'PhotoDeveloping
        | IssuingCardAuthorizationControlsAllowedCategories'PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | IssuingCardAuthorizationControlsAllowedCategories'PhotographicStudios
        | IssuingCardAuthorizationControlsAllowedCategories'PictureVideoProduction
        | IssuingCardAuthorizationControlsAllowedCategories'PieceGoodsNotionsAndOtherDryGoods
        | IssuingCardAuthorizationControlsAllowedCategories'PlumbingHeatingEquipmentAndSupplies
        | IssuingCardAuthorizationControlsAllowedCategories'PoliticalOrganizations
        | IssuingCardAuthorizationControlsAllowedCategories'PostalServicesGovernmentOnly
        | IssuingCardAuthorizationControlsAllowedCategories'PreciousStonesAndMetalsWatchesAndJewelry
        | IssuingCardAuthorizationControlsAllowedCategories'ProfessionalServices
        | IssuingCardAuthorizationControlsAllowedCategories'PublicWarehousingAndStorage
        | IssuingCardAuthorizationControlsAllowedCategories'QuickCopyReproAndBlueprint
        | IssuingCardAuthorizationControlsAllowedCategories'Railroads
        | IssuingCardAuthorizationControlsAllowedCategories'RealEstateAgentsAndManagersRentals
        | IssuingCardAuthorizationControlsAllowedCategories'RecordStores
        | IssuingCardAuthorizationControlsAllowedCategories'RecreationalVehicleRentals
        | IssuingCardAuthorizationControlsAllowedCategories'ReligiousGoodsStores
        | IssuingCardAuthorizationControlsAllowedCategories'ReligiousOrganizations
        | IssuingCardAuthorizationControlsAllowedCategories'RoofingSidingSheetMetal
        | IssuingCardAuthorizationControlsAllowedCategories'SecretarialSupportServices
        | IssuingCardAuthorizationControlsAllowedCategories'SecurityBrokersDealers
        | IssuingCardAuthorizationControlsAllowedCategories'ServiceStations
        | IssuingCardAuthorizationControlsAllowedCategories'SewingNeedleworkFabricAndPieceGoodsStores
        | IssuingCardAuthorizationControlsAllowedCategories'ShoeRepairHatCleaning
        | IssuingCardAuthorizationControlsAllowedCategories'ShoeStores
        | IssuingCardAuthorizationControlsAllowedCategories'SmallApplianceRepair
        | IssuingCardAuthorizationControlsAllowedCategories'SnowmobileDealers
        | IssuingCardAuthorizationControlsAllowedCategories'SpecialTradeServices
        | IssuingCardAuthorizationControlsAllowedCategories'SpecialtyCleaning
        | IssuingCardAuthorizationControlsAllowedCategories'SportingGoodsStores
        | IssuingCardAuthorizationControlsAllowedCategories'SportingRecreationCamps
        | IssuingCardAuthorizationControlsAllowedCategories'SportsAndRidingApparelStores
        | IssuingCardAuthorizationControlsAllowedCategories'SportsClubsFields
        | IssuingCardAuthorizationControlsAllowedCategories'StampAndCoinStores
        | IssuingCardAuthorizationControlsAllowedCategories'StationaryOfficeSuppliesPrintingAndWritingPaper
        | IssuingCardAuthorizationControlsAllowedCategories'StationeryStoresOfficeAndSchoolSupplyStores
        | IssuingCardAuthorizationControlsAllowedCategories'SwimmingPoolsSales
        | IssuingCardAuthorizationControlsAllowedCategories'TUiTravelGermany
        | IssuingCardAuthorizationControlsAllowedCategories'TailorsAlterations
        | IssuingCardAuthorizationControlsAllowedCategories'TaxPaymentsGovernmentAgencies
        | IssuingCardAuthorizationControlsAllowedCategories'TaxPreparationServices
        | IssuingCardAuthorizationControlsAllowedCategories'TaxicabsLimousines
        | IssuingCardAuthorizationControlsAllowedCategories'TelecommunicationEquipmentAndTelephoneSales
        | IssuingCardAuthorizationControlsAllowedCategories'TelecommunicationServices
        | IssuingCardAuthorizationControlsAllowedCategories'TelegraphServices
        | IssuingCardAuthorizationControlsAllowedCategories'TentAndAwningShops
        | IssuingCardAuthorizationControlsAllowedCategories'TestingLaboratories
        | IssuingCardAuthorizationControlsAllowedCategories'TheatricalTicketAgencies
        | IssuingCardAuthorizationControlsAllowedCategories'Timeshares
        | IssuingCardAuthorizationControlsAllowedCategories'TireRetreadingAndRepair
        | IssuingCardAuthorizationControlsAllowedCategories'TollsBridgeFees
        | IssuingCardAuthorizationControlsAllowedCategories'TouristAttractionsAndExhibits
        | IssuingCardAuthorizationControlsAllowedCategories'TowingServices
        | IssuingCardAuthorizationControlsAllowedCategories'TrailerParksCampgrounds
        | IssuingCardAuthorizationControlsAllowedCategories'TransportationServices
        | IssuingCardAuthorizationControlsAllowedCategories'TravelAgenciesTourOperators
        | IssuingCardAuthorizationControlsAllowedCategories'TruckStopIteration
        | IssuingCardAuthorizationControlsAllowedCategories'TruckUtilityTrailerRentals
        | IssuingCardAuthorizationControlsAllowedCategories'TypesettingPlateMakingAndRelatedServices
        | IssuingCardAuthorizationControlsAllowedCategories'TypewriterStores
        | IssuingCardAuthorizationControlsAllowedCategories'USFederalGovernmentAgenciesOrDepartments
        | IssuingCardAuthorizationControlsAllowedCategories'UniformsCommercialClothing
        | IssuingCardAuthorizationControlsAllowedCategories'UsedMerchandiseAndSecondhandStores
        | IssuingCardAuthorizationControlsAllowedCategories'Utilities
        | IssuingCardAuthorizationControlsAllowedCategories'VarietyStores
        | IssuingCardAuthorizationControlsAllowedCategories'VeterinaryServices
        | IssuingCardAuthorizationControlsAllowedCategories'VideoAmusementGameSupplies
        | IssuingCardAuthorizationControlsAllowedCategories'VideoGameArcades
        | IssuingCardAuthorizationControlsAllowedCategories'VideoTapeRentalStores
        | IssuingCardAuthorizationControlsAllowedCategories'VocationalTradeSchools
        | IssuingCardAuthorizationControlsAllowedCategories'WatchJewelryRepair
        | IssuingCardAuthorizationControlsAllowedCategories'WeldingRepair
        | IssuingCardAuthorizationControlsAllowedCategories'WholesaleClubs
        | IssuingCardAuthorizationControlsAllowedCategories'WigAndToupeeStores
        | IssuingCardAuthorizationControlsAllowedCategories'WiresMoneyOrders
        | IssuingCardAuthorizationControlsAllowedCategories'WomensAccessoryAndSpecialtyShops
        | IssuingCardAuthorizationControlsAllowedCategories'WomensReadyToWearStores
        | IssuingCardAuthorizationControlsAllowedCategories'WreckingAndSalvageYards

    and IssuingCardAuthorizationControlsBlockedCategories =
        | IssuingCardAuthorizationControlsBlockedCategories'AcRefrigerationRepair
        | IssuingCardAuthorizationControlsBlockedCategories'AccountingBookkeepingServices
        | IssuingCardAuthorizationControlsBlockedCategories'AdvertisingServices
        | IssuingCardAuthorizationControlsBlockedCategories'AgriculturalCooperative
        | IssuingCardAuthorizationControlsBlockedCategories'AirlinesAirCarriers
        | IssuingCardAuthorizationControlsBlockedCategories'AirportsFlyingFields
        | IssuingCardAuthorizationControlsBlockedCategories'AmbulanceServices
        | IssuingCardAuthorizationControlsBlockedCategories'AmusementParksCarnivals
        | IssuingCardAuthorizationControlsBlockedCategories'AntiqueReproductions
        | IssuingCardAuthorizationControlsBlockedCategories'AntiqueShops
        | IssuingCardAuthorizationControlsBlockedCategories'Aquariums
        | IssuingCardAuthorizationControlsBlockedCategories'ArchitecturalSurveyingServices
        | IssuingCardAuthorizationControlsBlockedCategories'ArtDealersAndGalleries
        | IssuingCardAuthorizationControlsBlockedCategories'ArtistsSupplyAndCraftShops
        | IssuingCardAuthorizationControlsBlockedCategories'AutoAndHomeSupplyStores
        | IssuingCardAuthorizationControlsBlockedCategories'AutoBodyRepairShops
        | IssuingCardAuthorizationControlsBlockedCategories'AutoPaintShops
        | IssuingCardAuthorizationControlsBlockedCategories'AutoServiceShops
        | IssuingCardAuthorizationControlsBlockedCategories'AutomatedCashDisburse
        | IssuingCardAuthorizationControlsBlockedCategories'AutomatedFuelDispensers
        | IssuingCardAuthorizationControlsBlockedCategories'AutomobileAssociations
        | IssuingCardAuthorizationControlsBlockedCategories'AutomotivePartsAndAccessoriesStores
        | IssuingCardAuthorizationControlsBlockedCategories'AutomotiveTireStores
        | IssuingCardAuthorizationControlsBlockedCategories'BailAndBondPayments
        | IssuingCardAuthorizationControlsBlockedCategories'Bakeries
        | IssuingCardAuthorizationControlsBlockedCategories'BandsOrchestras
        | IssuingCardAuthorizationControlsBlockedCategories'BarberAndBeautyShops
        | IssuingCardAuthorizationControlsBlockedCategories'BettingCasinoGambling
        | IssuingCardAuthorizationControlsBlockedCategories'BicycleShops
        | IssuingCardAuthorizationControlsBlockedCategories'BilliardPoolEstablishments
        | IssuingCardAuthorizationControlsBlockedCategories'BoatDealers
        | IssuingCardAuthorizationControlsBlockedCategories'BoatRentalsAndLeases
        | IssuingCardAuthorizationControlsBlockedCategories'BookStores
        | IssuingCardAuthorizationControlsBlockedCategories'BooksPeriodicalsAndNewspapers
        | IssuingCardAuthorizationControlsBlockedCategories'BowlingAlleys
        | IssuingCardAuthorizationControlsBlockedCategories'BusLines
        | IssuingCardAuthorizationControlsBlockedCategories'BusinessSecretarialSchools
        | IssuingCardAuthorizationControlsBlockedCategories'BuyingShoppingServices
        | IssuingCardAuthorizationControlsBlockedCategories'CableSatelliteAndOtherPayTelevisionAndRadio
        | IssuingCardAuthorizationControlsBlockedCategories'CameraAndPhotographicSupplyStores
        | IssuingCardAuthorizationControlsBlockedCategories'CandyNutAndConfectioneryStores
        | IssuingCardAuthorizationControlsBlockedCategories'CarAndTruckDealersNewUsed
        | IssuingCardAuthorizationControlsBlockedCategories'CarAndTruckDealersUsedOnly
        | IssuingCardAuthorizationControlsBlockedCategories'CarRentalAgencies
        | IssuingCardAuthorizationControlsBlockedCategories'CarWashes
        | IssuingCardAuthorizationControlsBlockedCategories'CarpentryServices
        | IssuingCardAuthorizationControlsBlockedCategories'CarpetUpholsteryCleaning
        | IssuingCardAuthorizationControlsBlockedCategories'Caterers
        | IssuingCardAuthorizationControlsBlockedCategories'CharitableAndSocialServiceOrganizationsFundraising
        | IssuingCardAuthorizationControlsBlockedCategories'ChemicalsAndAlliedProducts
        | IssuingCardAuthorizationControlsBlockedCategories'ChildCareServices
        | IssuingCardAuthorizationControlsBlockedCategories'ChildrensAndInfantsWearStores
        | IssuingCardAuthorizationControlsBlockedCategories'ChiropodistsPodiatrists
        | IssuingCardAuthorizationControlsBlockedCategories'Chiropractors
        | IssuingCardAuthorizationControlsBlockedCategories'CigarStoresAndStands
        | IssuingCardAuthorizationControlsBlockedCategories'CivicSocialFraternalAssociations
        | IssuingCardAuthorizationControlsBlockedCategories'CleaningAndMaintenance
        | IssuingCardAuthorizationControlsBlockedCategories'ClothingRental
        | IssuingCardAuthorizationControlsBlockedCategories'CollegesUniversities
        | IssuingCardAuthorizationControlsBlockedCategories'CommercialEquipment
        | IssuingCardAuthorizationControlsBlockedCategories'CommercialFootwear
        | IssuingCardAuthorizationControlsBlockedCategories'CommercialPhotographyArtAndGraphics
        | IssuingCardAuthorizationControlsBlockedCategories'CommuterTransportAndFerries
        | IssuingCardAuthorizationControlsBlockedCategories'ComputerNetworkServices
        | IssuingCardAuthorizationControlsBlockedCategories'ComputerProgramming
        | IssuingCardAuthorizationControlsBlockedCategories'ComputerRepair
        | IssuingCardAuthorizationControlsBlockedCategories'ComputerSoftwareStores
        | IssuingCardAuthorizationControlsBlockedCategories'ComputersPeripheralsAndSoftware
        | IssuingCardAuthorizationControlsBlockedCategories'ConcreteWorkServices
        | IssuingCardAuthorizationControlsBlockedCategories'ConstructionMaterials
        | IssuingCardAuthorizationControlsBlockedCategories'ConsultingPublicRelations
        | IssuingCardAuthorizationControlsBlockedCategories'CorrespondenceSchools
        | IssuingCardAuthorizationControlsBlockedCategories'CosmeticStores
        | IssuingCardAuthorizationControlsBlockedCategories'CounselingServices
        | IssuingCardAuthorizationControlsBlockedCategories'CountryClubs
        | IssuingCardAuthorizationControlsBlockedCategories'CourierServices
        | IssuingCardAuthorizationControlsBlockedCategories'CourtCosts
        | IssuingCardAuthorizationControlsBlockedCategories'CreditReportingAgencies
        | IssuingCardAuthorizationControlsBlockedCategories'CruiseLines
        | IssuingCardAuthorizationControlsBlockedCategories'DairyProductsStores
        | IssuingCardAuthorizationControlsBlockedCategories'DanceHallStudiosSchools
        | IssuingCardAuthorizationControlsBlockedCategories'DatingEscortServices
        | IssuingCardAuthorizationControlsBlockedCategories'DentistsOrthodontists
        | IssuingCardAuthorizationControlsBlockedCategories'DepartmentStores
        | IssuingCardAuthorizationControlsBlockedCategories'DetectiveAgencies
        | IssuingCardAuthorizationControlsBlockedCategories'DigitalGoodsApplications
        | IssuingCardAuthorizationControlsBlockedCategories'DigitalGoodsGames
        | IssuingCardAuthorizationControlsBlockedCategories'DigitalGoodsLargeVolume
        | IssuingCardAuthorizationControlsBlockedCategories'DigitalGoodsMedia
        | IssuingCardAuthorizationControlsBlockedCategories'DirectMarketingCatalogMerchant
        | IssuingCardAuthorizationControlsBlockedCategories'DirectMarketingCombinationCatalogAndRetailMerchant
        | IssuingCardAuthorizationControlsBlockedCategories'DirectMarketingInboundTelemarketing
        | IssuingCardAuthorizationControlsBlockedCategories'DirectMarketingInsuranceServices
        | IssuingCardAuthorizationControlsBlockedCategories'DirectMarketingOther
        | IssuingCardAuthorizationControlsBlockedCategories'DirectMarketingOutboundTelemarketing
        | IssuingCardAuthorizationControlsBlockedCategories'DirectMarketingSubscription
        | IssuingCardAuthorizationControlsBlockedCategories'DirectMarketingTravel
        | IssuingCardAuthorizationControlsBlockedCategories'DiscountStores
        | IssuingCardAuthorizationControlsBlockedCategories'Doctors
        | IssuingCardAuthorizationControlsBlockedCategories'DoorToDoorSales
        | IssuingCardAuthorizationControlsBlockedCategories'DraperyWindowCoveringAndUpholsteryStores
        | IssuingCardAuthorizationControlsBlockedCategories'DrinkingPlaces
        | IssuingCardAuthorizationControlsBlockedCategories'DrugStoresAndPharmacies
        | IssuingCardAuthorizationControlsBlockedCategories'DrugsDrugProprietariesAndDruggistSundries
        | IssuingCardAuthorizationControlsBlockedCategories'DryCleaners
        | IssuingCardAuthorizationControlsBlockedCategories'DurableGoods
        | IssuingCardAuthorizationControlsBlockedCategories'DutyFreeStores
        | IssuingCardAuthorizationControlsBlockedCategories'EatingPlacesRestaurants
        | IssuingCardAuthorizationControlsBlockedCategories'EducationalServices
        | IssuingCardAuthorizationControlsBlockedCategories'ElectricRazorStores
        | IssuingCardAuthorizationControlsBlockedCategories'ElectricalPartsAndEquipment
        | IssuingCardAuthorizationControlsBlockedCategories'ElectricalServices
        | IssuingCardAuthorizationControlsBlockedCategories'ElectronicsRepairShops
        | IssuingCardAuthorizationControlsBlockedCategories'ElectronicsStores
        | IssuingCardAuthorizationControlsBlockedCategories'ElementarySecondarySchools
        | IssuingCardAuthorizationControlsBlockedCategories'EmploymentTempAgencies
        | IssuingCardAuthorizationControlsBlockedCategories'EquipmentRental
        | IssuingCardAuthorizationControlsBlockedCategories'ExterminatingServices
        | IssuingCardAuthorizationControlsBlockedCategories'FamilyClothingStores
        | IssuingCardAuthorizationControlsBlockedCategories'FastFoodRestaurants
        | IssuingCardAuthorizationControlsBlockedCategories'FinancialInstitutions
        | IssuingCardAuthorizationControlsBlockedCategories'FinesGovernmentAdministrativeEntities
        | IssuingCardAuthorizationControlsBlockedCategories'FireplaceFireplaceScreensAndAccessoriesStores
        | IssuingCardAuthorizationControlsBlockedCategories'FloorCoveringStores
        | IssuingCardAuthorizationControlsBlockedCategories'Florists
        | IssuingCardAuthorizationControlsBlockedCategories'FloristsSuppliesNurseryStockAndFlowers
        | IssuingCardAuthorizationControlsBlockedCategories'FreezerAndLockerMeatProvisioners
        | IssuingCardAuthorizationControlsBlockedCategories'FuelDealersNonAutomotive
        | IssuingCardAuthorizationControlsBlockedCategories'FuneralServicesCrematories
        | IssuingCardAuthorizationControlsBlockedCategories'FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | IssuingCardAuthorizationControlsBlockedCategories'FurnitureRepairRefinishing
        | IssuingCardAuthorizationControlsBlockedCategories'FurriersAndFurShops
        | IssuingCardAuthorizationControlsBlockedCategories'GeneralServices
        | IssuingCardAuthorizationControlsBlockedCategories'GiftCardNoveltyAndSouvenirShops
        | IssuingCardAuthorizationControlsBlockedCategories'GlassPaintAndWallpaperStores
        | IssuingCardAuthorizationControlsBlockedCategories'GlasswareCrystalStores
        | IssuingCardAuthorizationControlsBlockedCategories'GolfCoursesPublic
        | IssuingCardAuthorizationControlsBlockedCategories'GovernmentServices
        | IssuingCardAuthorizationControlsBlockedCategories'GroceryStoresSupermarkets
        | IssuingCardAuthorizationControlsBlockedCategories'HardwareEquipmentAndSupplies
        | IssuingCardAuthorizationControlsBlockedCategories'HardwareStores
        | IssuingCardAuthorizationControlsBlockedCategories'HealthAndBeautySpas
        | IssuingCardAuthorizationControlsBlockedCategories'HearingAidsSalesAndSupplies
        | IssuingCardAuthorizationControlsBlockedCategories'HeatingPlumbingAC
        | IssuingCardAuthorizationControlsBlockedCategories'HobbyToyAndGameShops
        | IssuingCardAuthorizationControlsBlockedCategories'HomeSupplyWarehouseStores
        | IssuingCardAuthorizationControlsBlockedCategories'Hospitals
        | IssuingCardAuthorizationControlsBlockedCategories'HotelsMotelsAndResorts
        | IssuingCardAuthorizationControlsBlockedCategories'HouseholdApplianceStores
        | IssuingCardAuthorizationControlsBlockedCategories'IndustrialSupplies
        | IssuingCardAuthorizationControlsBlockedCategories'InformationRetrievalServices
        | IssuingCardAuthorizationControlsBlockedCategories'InsuranceDefault
        | IssuingCardAuthorizationControlsBlockedCategories'InsuranceUnderwritingPremiums
        | IssuingCardAuthorizationControlsBlockedCategories'IntraCompanyPurchases
        | IssuingCardAuthorizationControlsBlockedCategories'JewelryStoresWatchesClocksAndSilverwareStores
        | IssuingCardAuthorizationControlsBlockedCategories'LandscapingServices
        | IssuingCardAuthorizationControlsBlockedCategories'Laundries
        | IssuingCardAuthorizationControlsBlockedCategories'LaundryCleaningServices
        | IssuingCardAuthorizationControlsBlockedCategories'LegalServicesAttorneys
        | IssuingCardAuthorizationControlsBlockedCategories'LuggageAndLeatherGoodsStores
        | IssuingCardAuthorizationControlsBlockedCategories'LumberBuildingMaterialsStores
        | IssuingCardAuthorizationControlsBlockedCategories'ManualCashDisburse
        | IssuingCardAuthorizationControlsBlockedCategories'MarinasServiceAndSupplies
        | IssuingCardAuthorizationControlsBlockedCategories'MasonryStoneworkAndPlaster
        | IssuingCardAuthorizationControlsBlockedCategories'MassageParlors
        | IssuingCardAuthorizationControlsBlockedCategories'MedicalAndDentalLabs
        | IssuingCardAuthorizationControlsBlockedCategories'MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | IssuingCardAuthorizationControlsBlockedCategories'MedicalServices
        | IssuingCardAuthorizationControlsBlockedCategories'MembershipOrganizations
        | IssuingCardAuthorizationControlsBlockedCategories'MensAndBoysClothingAndAccessoriesStores
        | IssuingCardAuthorizationControlsBlockedCategories'MensWomensClothingStores
        | IssuingCardAuthorizationControlsBlockedCategories'MetalServiceCenters
        | IssuingCardAuthorizationControlsBlockedCategories'Miscellaneous
        | IssuingCardAuthorizationControlsBlockedCategories'MiscellaneousApparelAndAccessoryShops
        | IssuingCardAuthorizationControlsBlockedCategories'MiscellaneousAutoDealers
        | IssuingCardAuthorizationControlsBlockedCategories'MiscellaneousBusinessServices
        | IssuingCardAuthorizationControlsBlockedCategories'MiscellaneousFoodStores
        | IssuingCardAuthorizationControlsBlockedCategories'MiscellaneousGeneralMerchandise
        | IssuingCardAuthorizationControlsBlockedCategories'MiscellaneousGeneralServices
        | IssuingCardAuthorizationControlsBlockedCategories'MiscellaneousHomeFurnishingSpecialtyStores
        | IssuingCardAuthorizationControlsBlockedCategories'MiscellaneousPublishingAndPrinting
        | IssuingCardAuthorizationControlsBlockedCategories'MiscellaneousRecreationServices
        | IssuingCardAuthorizationControlsBlockedCategories'MiscellaneousRepairShops
        | IssuingCardAuthorizationControlsBlockedCategories'MiscellaneousSpecialtyRetail
        | IssuingCardAuthorizationControlsBlockedCategories'MobileHomeDealers
        | IssuingCardAuthorizationControlsBlockedCategories'MotionPictureTheaters
        | IssuingCardAuthorizationControlsBlockedCategories'MotorFreightCarriersAndTrucking
        | IssuingCardAuthorizationControlsBlockedCategories'MotorHomesDealers
        | IssuingCardAuthorizationControlsBlockedCategories'MotorVehicleSuppliesAndNewParts
        | IssuingCardAuthorizationControlsBlockedCategories'MotorcycleShopsAndDealers
        | IssuingCardAuthorizationControlsBlockedCategories'MotorcycleShopsDealers
        | IssuingCardAuthorizationControlsBlockedCategories'MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | IssuingCardAuthorizationControlsBlockedCategories'NewsDealersAndNewsstands
        | IssuingCardAuthorizationControlsBlockedCategories'NonFiMoneyOrders
        | IssuingCardAuthorizationControlsBlockedCategories'NonFiStoredValueCardPurchaseLoad
        | IssuingCardAuthorizationControlsBlockedCategories'NondurableGoods
        | IssuingCardAuthorizationControlsBlockedCategories'NurseriesLawnAndGardenSupplyStores
        | IssuingCardAuthorizationControlsBlockedCategories'NursingPersonalCare
        | IssuingCardAuthorizationControlsBlockedCategories'OfficeAndCommercialFurniture
        | IssuingCardAuthorizationControlsBlockedCategories'OpticiansEyeglasses
        | IssuingCardAuthorizationControlsBlockedCategories'OptometristsOphthalmologist
        | IssuingCardAuthorizationControlsBlockedCategories'OrthopedicGoodsProstheticDevices
        | IssuingCardAuthorizationControlsBlockedCategories'Osteopaths
        | IssuingCardAuthorizationControlsBlockedCategories'PackageStoresBeerWineAndLiquor
        | IssuingCardAuthorizationControlsBlockedCategories'PaintsVarnishesAndSupplies
        | IssuingCardAuthorizationControlsBlockedCategories'ParkingLotsGarages
        | IssuingCardAuthorizationControlsBlockedCategories'PassengerRailways
        | IssuingCardAuthorizationControlsBlockedCategories'PawnShops
        | IssuingCardAuthorizationControlsBlockedCategories'PetShopsPetFoodAndSupplies
        | IssuingCardAuthorizationControlsBlockedCategories'PetroleumAndPetroleumProducts
        | IssuingCardAuthorizationControlsBlockedCategories'PhotoDeveloping
        | IssuingCardAuthorizationControlsBlockedCategories'PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | IssuingCardAuthorizationControlsBlockedCategories'PhotographicStudios
        | IssuingCardAuthorizationControlsBlockedCategories'PictureVideoProduction
        | IssuingCardAuthorizationControlsBlockedCategories'PieceGoodsNotionsAndOtherDryGoods
        | IssuingCardAuthorizationControlsBlockedCategories'PlumbingHeatingEquipmentAndSupplies
        | IssuingCardAuthorizationControlsBlockedCategories'PoliticalOrganizations
        | IssuingCardAuthorizationControlsBlockedCategories'PostalServicesGovernmentOnly
        | IssuingCardAuthorizationControlsBlockedCategories'PreciousStonesAndMetalsWatchesAndJewelry
        | IssuingCardAuthorizationControlsBlockedCategories'ProfessionalServices
        | IssuingCardAuthorizationControlsBlockedCategories'PublicWarehousingAndStorage
        | IssuingCardAuthorizationControlsBlockedCategories'QuickCopyReproAndBlueprint
        | IssuingCardAuthorizationControlsBlockedCategories'Railroads
        | IssuingCardAuthorizationControlsBlockedCategories'RealEstateAgentsAndManagersRentals
        | IssuingCardAuthorizationControlsBlockedCategories'RecordStores
        | IssuingCardAuthorizationControlsBlockedCategories'RecreationalVehicleRentals
        | IssuingCardAuthorizationControlsBlockedCategories'ReligiousGoodsStores
        | IssuingCardAuthorizationControlsBlockedCategories'ReligiousOrganizations
        | IssuingCardAuthorizationControlsBlockedCategories'RoofingSidingSheetMetal
        | IssuingCardAuthorizationControlsBlockedCategories'SecretarialSupportServices
        | IssuingCardAuthorizationControlsBlockedCategories'SecurityBrokersDealers
        | IssuingCardAuthorizationControlsBlockedCategories'ServiceStations
        | IssuingCardAuthorizationControlsBlockedCategories'SewingNeedleworkFabricAndPieceGoodsStores
        | IssuingCardAuthorizationControlsBlockedCategories'ShoeRepairHatCleaning
        | IssuingCardAuthorizationControlsBlockedCategories'ShoeStores
        | IssuingCardAuthorizationControlsBlockedCategories'SmallApplianceRepair
        | IssuingCardAuthorizationControlsBlockedCategories'SnowmobileDealers
        | IssuingCardAuthorizationControlsBlockedCategories'SpecialTradeServices
        | IssuingCardAuthorizationControlsBlockedCategories'SpecialtyCleaning
        | IssuingCardAuthorizationControlsBlockedCategories'SportingGoodsStores
        | IssuingCardAuthorizationControlsBlockedCategories'SportingRecreationCamps
        | IssuingCardAuthorizationControlsBlockedCategories'SportsAndRidingApparelStores
        | IssuingCardAuthorizationControlsBlockedCategories'SportsClubsFields
        | IssuingCardAuthorizationControlsBlockedCategories'StampAndCoinStores
        | IssuingCardAuthorizationControlsBlockedCategories'StationaryOfficeSuppliesPrintingAndWritingPaper
        | IssuingCardAuthorizationControlsBlockedCategories'StationeryStoresOfficeAndSchoolSupplyStores
        | IssuingCardAuthorizationControlsBlockedCategories'SwimmingPoolsSales
        | IssuingCardAuthorizationControlsBlockedCategories'TUiTravelGermany
        | IssuingCardAuthorizationControlsBlockedCategories'TailorsAlterations
        | IssuingCardAuthorizationControlsBlockedCategories'TaxPaymentsGovernmentAgencies
        | IssuingCardAuthorizationControlsBlockedCategories'TaxPreparationServices
        | IssuingCardAuthorizationControlsBlockedCategories'TaxicabsLimousines
        | IssuingCardAuthorizationControlsBlockedCategories'TelecommunicationEquipmentAndTelephoneSales
        | IssuingCardAuthorizationControlsBlockedCategories'TelecommunicationServices
        | IssuingCardAuthorizationControlsBlockedCategories'TelegraphServices
        | IssuingCardAuthorizationControlsBlockedCategories'TentAndAwningShops
        | IssuingCardAuthorizationControlsBlockedCategories'TestingLaboratories
        | IssuingCardAuthorizationControlsBlockedCategories'TheatricalTicketAgencies
        | IssuingCardAuthorizationControlsBlockedCategories'Timeshares
        | IssuingCardAuthorizationControlsBlockedCategories'TireRetreadingAndRepair
        | IssuingCardAuthorizationControlsBlockedCategories'TollsBridgeFees
        | IssuingCardAuthorizationControlsBlockedCategories'TouristAttractionsAndExhibits
        | IssuingCardAuthorizationControlsBlockedCategories'TowingServices
        | IssuingCardAuthorizationControlsBlockedCategories'TrailerParksCampgrounds
        | IssuingCardAuthorizationControlsBlockedCategories'TransportationServices
        | IssuingCardAuthorizationControlsBlockedCategories'TravelAgenciesTourOperators
        | IssuingCardAuthorizationControlsBlockedCategories'TruckStopIteration
        | IssuingCardAuthorizationControlsBlockedCategories'TruckUtilityTrailerRentals
        | IssuingCardAuthorizationControlsBlockedCategories'TypesettingPlateMakingAndRelatedServices
        | IssuingCardAuthorizationControlsBlockedCategories'TypewriterStores
        | IssuingCardAuthorizationControlsBlockedCategories'USFederalGovernmentAgenciesOrDepartments
        | IssuingCardAuthorizationControlsBlockedCategories'UniformsCommercialClothing
        | IssuingCardAuthorizationControlsBlockedCategories'UsedMerchandiseAndSecondhandStores
        | IssuingCardAuthorizationControlsBlockedCategories'Utilities
        | IssuingCardAuthorizationControlsBlockedCategories'VarietyStores
        | IssuingCardAuthorizationControlsBlockedCategories'VeterinaryServices
        | IssuingCardAuthorizationControlsBlockedCategories'VideoAmusementGameSupplies
        | IssuingCardAuthorizationControlsBlockedCategories'VideoGameArcades
        | IssuingCardAuthorizationControlsBlockedCategories'VideoTapeRentalStores
        | IssuingCardAuthorizationControlsBlockedCategories'VocationalTradeSchools
        | IssuingCardAuthorizationControlsBlockedCategories'WatchJewelryRepair
        | IssuingCardAuthorizationControlsBlockedCategories'WeldingRepair
        | IssuingCardAuthorizationControlsBlockedCategories'WholesaleClubs
        | IssuingCardAuthorizationControlsBlockedCategories'WigAndToupeeStores
        | IssuingCardAuthorizationControlsBlockedCategories'WiresMoneyOrders
        | IssuingCardAuthorizationControlsBlockedCategories'WomensAccessoryAndSpecialtyShops
        | IssuingCardAuthorizationControlsBlockedCategories'WomensReadyToWearStores
        | IssuingCardAuthorizationControlsBlockedCategories'WreckingAndSalvageYards

    ///
    and IssuingCardShipping (address: Address, carrier: IssuingCardShippingCarrier option, eta: int option, name: string, service: IssuingCardShippingService, status: IssuingCardShippingStatus option, trackingNumber: string option, trackingUrl: string option, ``type``: IssuingCardShippingType) =

        member _.Address = address
        member _.Carrier = carrier
        member _.Eta = eta
        member _.Name = name
        member _.Service = service
        member _.Status = status
        member _.TrackingNumber = trackingNumber
        member _.TrackingUrl = trackingUrl
        member _.Type = ``type``

    and IssuingCardShippingCarrier =
        | IssuingCardShippingCarrier'Fedex
        | IssuingCardShippingCarrier'Usps

    and IssuingCardShippingService =
        | IssuingCardShippingService'Express
        | IssuingCardShippingService'Priority
        | IssuingCardShippingService'Standard

    and IssuingCardShippingStatus =
        | IssuingCardShippingStatus'Canceled
        | IssuingCardShippingStatus'Delivered
        | IssuingCardShippingStatus'Failure
        | IssuingCardShippingStatus'Pending
        | IssuingCardShippingStatus'Returned
        | IssuingCardShippingStatus'Shipped

    and IssuingCardShippingType =
        | IssuingCardShippingType'Bulk
        | IssuingCardShippingType'Individual

    ///
    and IssuingCardSpendingLimit (amount: int, categories: IssuingCardSpendingLimitCategories list option, interval: IssuingCardSpendingLimitInterval) =

        member _.Amount = amount
        member _.Categories = categories
        member _.Interval = interval

    and IssuingCardSpendingLimitCategories =
        | IssuingCardSpendingLimitCategories'AcRefrigerationRepair
        | IssuingCardSpendingLimitCategories'AccountingBookkeepingServices
        | IssuingCardSpendingLimitCategories'AdvertisingServices
        | IssuingCardSpendingLimitCategories'AgriculturalCooperative
        | IssuingCardSpendingLimitCategories'AirlinesAirCarriers
        | IssuingCardSpendingLimitCategories'AirportsFlyingFields
        | IssuingCardSpendingLimitCategories'AmbulanceServices
        | IssuingCardSpendingLimitCategories'AmusementParksCarnivals
        | IssuingCardSpendingLimitCategories'AntiqueReproductions
        | IssuingCardSpendingLimitCategories'AntiqueShops
        | IssuingCardSpendingLimitCategories'Aquariums
        | IssuingCardSpendingLimitCategories'ArchitecturalSurveyingServices
        | IssuingCardSpendingLimitCategories'ArtDealersAndGalleries
        | IssuingCardSpendingLimitCategories'ArtistsSupplyAndCraftShops
        | IssuingCardSpendingLimitCategories'AutoAndHomeSupplyStores
        | IssuingCardSpendingLimitCategories'AutoBodyRepairShops
        | IssuingCardSpendingLimitCategories'AutoPaintShops
        | IssuingCardSpendingLimitCategories'AutoServiceShops
        | IssuingCardSpendingLimitCategories'AutomatedCashDisburse
        | IssuingCardSpendingLimitCategories'AutomatedFuelDispensers
        | IssuingCardSpendingLimitCategories'AutomobileAssociations
        | IssuingCardSpendingLimitCategories'AutomotivePartsAndAccessoriesStores
        | IssuingCardSpendingLimitCategories'AutomotiveTireStores
        | IssuingCardSpendingLimitCategories'BailAndBondPayments
        | IssuingCardSpendingLimitCategories'Bakeries
        | IssuingCardSpendingLimitCategories'BandsOrchestras
        | IssuingCardSpendingLimitCategories'BarberAndBeautyShops
        | IssuingCardSpendingLimitCategories'BettingCasinoGambling
        | IssuingCardSpendingLimitCategories'BicycleShops
        | IssuingCardSpendingLimitCategories'BilliardPoolEstablishments
        | IssuingCardSpendingLimitCategories'BoatDealers
        | IssuingCardSpendingLimitCategories'BoatRentalsAndLeases
        | IssuingCardSpendingLimitCategories'BookStores
        | IssuingCardSpendingLimitCategories'BooksPeriodicalsAndNewspapers
        | IssuingCardSpendingLimitCategories'BowlingAlleys
        | IssuingCardSpendingLimitCategories'BusLines
        | IssuingCardSpendingLimitCategories'BusinessSecretarialSchools
        | IssuingCardSpendingLimitCategories'BuyingShoppingServices
        | IssuingCardSpendingLimitCategories'CableSatelliteAndOtherPayTelevisionAndRadio
        | IssuingCardSpendingLimitCategories'CameraAndPhotographicSupplyStores
        | IssuingCardSpendingLimitCategories'CandyNutAndConfectioneryStores
        | IssuingCardSpendingLimitCategories'CarAndTruckDealersNewUsed
        | IssuingCardSpendingLimitCategories'CarAndTruckDealersUsedOnly
        | IssuingCardSpendingLimitCategories'CarRentalAgencies
        | IssuingCardSpendingLimitCategories'CarWashes
        | IssuingCardSpendingLimitCategories'CarpentryServices
        | IssuingCardSpendingLimitCategories'CarpetUpholsteryCleaning
        | IssuingCardSpendingLimitCategories'Caterers
        | IssuingCardSpendingLimitCategories'CharitableAndSocialServiceOrganizationsFundraising
        | IssuingCardSpendingLimitCategories'ChemicalsAndAlliedProducts
        | IssuingCardSpendingLimitCategories'ChildCareServices
        | IssuingCardSpendingLimitCategories'ChildrensAndInfantsWearStores
        | IssuingCardSpendingLimitCategories'ChiropodistsPodiatrists
        | IssuingCardSpendingLimitCategories'Chiropractors
        | IssuingCardSpendingLimitCategories'CigarStoresAndStands
        | IssuingCardSpendingLimitCategories'CivicSocialFraternalAssociations
        | IssuingCardSpendingLimitCategories'CleaningAndMaintenance
        | IssuingCardSpendingLimitCategories'ClothingRental
        | IssuingCardSpendingLimitCategories'CollegesUniversities
        | IssuingCardSpendingLimitCategories'CommercialEquipment
        | IssuingCardSpendingLimitCategories'CommercialFootwear
        | IssuingCardSpendingLimitCategories'CommercialPhotographyArtAndGraphics
        | IssuingCardSpendingLimitCategories'CommuterTransportAndFerries
        | IssuingCardSpendingLimitCategories'ComputerNetworkServices
        | IssuingCardSpendingLimitCategories'ComputerProgramming
        | IssuingCardSpendingLimitCategories'ComputerRepair
        | IssuingCardSpendingLimitCategories'ComputerSoftwareStores
        | IssuingCardSpendingLimitCategories'ComputersPeripheralsAndSoftware
        | IssuingCardSpendingLimitCategories'ConcreteWorkServices
        | IssuingCardSpendingLimitCategories'ConstructionMaterials
        | IssuingCardSpendingLimitCategories'ConsultingPublicRelations
        | IssuingCardSpendingLimitCategories'CorrespondenceSchools
        | IssuingCardSpendingLimitCategories'CosmeticStores
        | IssuingCardSpendingLimitCategories'CounselingServices
        | IssuingCardSpendingLimitCategories'CountryClubs
        | IssuingCardSpendingLimitCategories'CourierServices
        | IssuingCardSpendingLimitCategories'CourtCosts
        | IssuingCardSpendingLimitCategories'CreditReportingAgencies
        | IssuingCardSpendingLimitCategories'CruiseLines
        | IssuingCardSpendingLimitCategories'DairyProductsStores
        | IssuingCardSpendingLimitCategories'DanceHallStudiosSchools
        | IssuingCardSpendingLimitCategories'DatingEscortServices
        | IssuingCardSpendingLimitCategories'DentistsOrthodontists
        | IssuingCardSpendingLimitCategories'DepartmentStores
        | IssuingCardSpendingLimitCategories'DetectiveAgencies
        | IssuingCardSpendingLimitCategories'DigitalGoodsApplications
        | IssuingCardSpendingLimitCategories'DigitalGoodsGames
        | IssuingCardSpendingLimitCategories'DigitalGoodsLargeVolume
        | IssuingCardSpendingLimitCategories'DigitalGoodsMedia
        | IssuingCardSpendingLimitCategories'DirectMarketingCatalogMerchant
        | IssuingCardSpendingLimitCategories'DirectMarketingCombinationCatalogAndRetailMerchant
        | IssuingCardSpendingLimitCategories'DirectMarketingInboundTelemarketing
        | IssuingCardSpendingLimitCategories'DirectMarketingInsuranceServices
        | IssuingCardSpendingLimitCategories'DirectMarketingOther
        | IssuingCardSpendingLimitCategories'DirectMarketingOutboundTelemarketing
        | IssuingCardSpendingLimitCategories'DirectMarketingSubscription
        | IssuingCardSpendingLimitCategories'DirectMarketingTravel
        | IssuingCardSpendingLimitCategories'DiscountStores
        | IssuingCardSpendingLimitCategories'Doctors
        | IssuingCardSpendingLimitCategories'DoorToDoorSales
        | IssuingCardSpendingLimitCategories'DraperyWindowCoveringAndUpholsteryStores
        | IssuingCardSpendingLimitCategories'DrinkingPlaces
        | IssuingCardSpendingLimitCategories'DrugStoresAndPharmacies
        | IssuingCardSpendingLimitCategories'DrugsDrugProprietariesAndDruggistSundries
        | IssuingCardSpendingLimitCategories'DryCleaners
        | IssuingCardSpendingLimitCategories'DurableGoods
        | IssuingCardSpendingLimitCategories'DutyFreeStores
        | IssuingCardSpendingLimitCategories'EatingPlacesRestaurants
        | IssuingCardSpendingLimitCategories'EducationalServices
        | IssuingCardSpendingLimitCategories'ElectricRazorStores
        | IssuingCardSpendingLimitCategories'ElectricalPartsAndEquipment
        | IssuingCardSpendingLimitCategories'ElectricalServices
        | IssuingCardSpendingLimitCategories'ElectronicsRepairShops
        | IssuingCardSpendingLimitCategories'ElectronicsStores
        | IssuingCardSpendingLimitCategories'ElementarySecondarySchools
        | IssuingCardSpendingLimitCategories'EmploymentTempAgencies
        | IssuingCardSpendingLimitCategories'EquipmentRental
        | IssuingCardSpendingLimitCategories'ExterminatingServices
        | IssuingCardSpendingLimitCategories'FamilyClothingStores
        | IssuingCardSpendingLimitCategories'FastFoodRestaurants
        | IssuingCardSpendingLimitCategories'FinancialInstitutions
        | IssuingCardSpendingLimitCategories'FinesGovernmentAdministrativeEntities
        | IssuingCardSpendingLimitCategories'FireplaceFireplaceScreensAndAccessoriesStores
        | IssuingCardSpendingLimitCategories'FloorCoveringStores
        | IssuingCardSpendingLimitCategories'Florists
        | IssuingCardSpendingLimitCategories'FloristsSuppliesNurseryStockAndFlowers
        | IssuingCardSpendingLimitCategories'FreezerAndLockerMeatProvisioners
        | IssuingCardSpendingLimitCategories'FuelDealersNonAutomotive
        | IssuingCardSpendingLimitCategories'FuneralServicesCrematories
        | IssuingCardSpendingLimitCategories'FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | IssuingCardSpendingLimitCategories'FurnitureRepairRefinishing
        | IssuingCardSpendingLimitCategories'FurriersAndFurShops
        | IssuingCardSpendingLimitCategories'GeneralServices
        | IssuingCardSpendingLimitCategories'GiftCardNoveltyAndSouvenirShops
        | IssuingCardSpendingLimitCategories'GlassPaintAndWallpaperStores
        | IssuingCardSpendingLimitCategories'GlasswareCrystalStores
        | IssuingCardSpendingLimitCategories'GolfCoursesPublic
        | IssuingCardSpendingLimitCategories'GovernmentServices
        | IssuingCardSpendingLimitCategories'GroceryStoresSupermarkets
        | IssuingCardSpendingLimitCategories'HardwareEquipmentAndSupplies
        | IssuingCardSpendingLimitCategories'HardwareStores
        | IssuingCardSpendingLimitCategories'HealthAndBeautySpas
        | IssuingCardSpendingLimitCategories'HearingAidsSalesAndSupplies
        | IssuingCardSpendingLimitCategories'HeatingPlumbingAC
        | IssuingCardSpendingLimitCategories'HobbyToyAndGameShops
        | IssuingCardSpendingLimitCategories'HomeSupplyWarehouseStores
        | IssuingCardSpendingLimitCategories'Hospitals
        | IssuingCardSpendingLimitCategories'HotelsMotelsAndResorts
        | IssuingCardSpendingLimitCategories'HouseholdApplianceStores
        | IssuingCardSpendingLimitCategories'IndustrialSupplies
        | IssuingCardSpendingLimitCategories'InformationRetrievalServices
        | IssuingCardSpendingLimitCategories'InsuranceDefault
        | IssuingCardSpendingLimitCategories'InsuranceUnderwritingPremiums
        | IssuingCardSpendingLimitCategories'IntraCompanyPurchases
        | IssuingCardSpendingLimitCategories'JewelryStoresWatchesClocksAndSilverwareStores
        | IssuingCardSpendingLimitCategories'LandscapingServices
        | IssuingCardSpendingLimitCategories'Laundries
        | IssuingCardSpendingLimitCategories'LaundryCleaningServices
        | IssuingCardSpendingLimitCategories'LegalServicesAttorneys
        | IssuingCardSpendingLimitCategories'LuggageAndLeatherGoodsStores
        | IssuingCardSpendingLimitCategories'LumberBuildingMaterialsStores
        | IssuingCardSpendingLimitCategories'ManualCashDisburse
        | IssuingCardSpendingLimitCategories'MarinasServiceAndSupplies
        | IssuingCardSpendingLimitCategories'MasonryStoneworkAndPlaster
        | IssuingCardSpendingLimitCategories'MassageParlors
        | IssuingCardSpendingLimitCategories'MedicalAndDentalLabs
        | IssuingCardSpendingLimitCategories'MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | IssuingCardSpendingLimitCategories'MedicalServices
        | IssuingCardSpendingLimitCategories'MembershipOrganizations
        | IssuingCardSpendingLimitCategories'MensAndBoysClothingAndAccessoriesStores
        | IssuingCardSpendingLimitCategories'MensWomensClothingStores
        | IssuingCardSpendingLimitCategories'MetalServiceCenters
        | IssuingCardSpendingLimitCategories'Miscellaneous
        | IssuingCardSpendingLimitCategories'MiscellaneousApparelAndAccessoryShops
        | IssuingCardSpendingLimitCategories'MiscellaneousAutoDealers
        | IssuingCardSpendingLimitCategories'MiscellaneousBusinessServices
        | IssuingCardSpendingLimitCategories'MiscellaneousFoodStores
        | IssuingCardSpendingLimitCategories'MiscellaneousGeneralMerchandise
        | IssuingCardSpendingLimitCategories'MiscellaneousGeneralServices
        | IssuingCardSpendingLimitCategories'MiscellaneousHomeFurnishingSpecialtyStores
        | IssuingCardSpendingLimitCategories'MiscellaneousPublishingAndPrinting
        | IssuingCardSpendingLimitCategories'MiscellaneousRecreationServices
        | IssuingCardSpendingLimitCategories'MiscellaneousRepairShops
        | IssuingCardSpendingLimitCategories'MiscellaneousSpecialtyRetail
        | IssuingCardSpendingLimitCategories'MobileHomeDealers
        | IssuingCardSpendingLimitCategories'MotionPictureTheaters
        | IssuingCardSpendingLimitCategories'MotorFreightCarriersAndTrucking
        | IssuingCardSpendingLimitCategories'MotorHomesDealers
        | IssuingCardSpendingLimitCategories'MotorVehicleSuppliesAndNewParts
        | IssuingCardSpendingLimitCategories'MotorcycleShopsAndDealers
        | IssuingCardSpendingLimitCategories'MotorcycleShopsDealers
        | IssuingCardSpendingLimitCategories'MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | IssuingCardSpendingLimitCategories'NewsDealersAndNewsstands
        | IssuingCardSpendingLimitCategories'NonFiMoneyOrders
        | IssuingCardSpendingLimitCategories'NonFiStoredValueCardPurchaseLoad
        | IssuingCardSpendingLimitCategories'NondurableGoods
        | IssuingCardSpendingLimitCategories'NurseriesLawnAndGardenSupplyStores
        | IssuingCardSpendingLimitCategories'NursingPersonalCare
        | IssuingCardSpendingLimitCategories'OfficeAndCommercialFurniture
        | IssuingCardSpendingLimitCategories'OpticiansEyeglasses
        | IssuingCardSpendingLimitCategories'OptometristsOphthalmologist
        | IssuingCardSpendingLimitCategories'OrthopedicGoodsProstheticDevices
        | IssuingCardSpendingLimitCategories'Osteopaths
        | IssuingCardSpendingLimitCategories'PackageStoresBeerWineAndLiquor
        | IssuingCardSpendingLimitCategories'PaintsVarnishesAndSupplies
        | IssuingCardSpendingLimitCategories'ParkingLotsGarages
        | IssuingCardSpendingLimitCategories'PassengerRailways
        | IssuingCardSpendingLimitCategories'PawnShops
        | IssuingCardSpendingLimitCategories'PetShopsPetFoodAndSupplies
        | IssuingCardSpendingLimitCategories'PetroleumAndPetroleumProducts
        | IssuingCardSpendingLimitCategories'PhotoDeveloping
        | IssuingCardSpendingLimitCategories'PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | IssuingCardSpendingLimitCategories'PhotographicStudios
        | IssuingCardSpendingLimitCategories'PictureVideoProduction
        | IssuingCardSpendingLimitCategories'PieceGoodsNotionsAndOtherDryGoods
        | IssuingCardSpendingLimitCategories'PlumbingHeatingEquipmentAndSupplies
        | IssuingCardSpendingLimitCategories'PoliticalOrganizations
        | IssuingCardSpendingLimitCategories'PostalServicesGovernmentOnly
        | IssuingCardSpendingLimitCategories'PreciousStonesAndMetalsWatchesAndJewelry
        | IssuingCardSpendingLimitCategories'ProfessionalServices
        | IssuingCardSpendingLimitCategories'PublicWarehousingAndStorage
        | IssuingCardSpendingLimitCategories'QuickCopyReproAndBlueprint
        | IssuingCardSpendingLimitCategories'Railroads
        | IssuingCardSpendingLimitCategories'RealEstateAgentsAndManagersRentals
        | IssuingCardSpendingLimitCategories'RecordStores
        | IssuingCardSpendingLimitCategories'RecreationalVehicleRentals
        | IssuingCardSpendingLimitCategories'ReligiousGoodsStores
        | IssuingCardSpendingLimitCategories'ReligiousOrganizations
        | IssuingCardSpendingLimitCategories'RoofingSidingSheetMetal
        | IssuingCardSpendingLimitCategories'SecretarialSupportServices
        | IssuingCardSpendingLimitCategories'SecurityBrokersDealers
        | IssuingCardSpendingLimitCategories'ServiceStations
        | IssuingCardSpendingLimitCategories'SewingNeedleworkFabricAndPieceGoodsStores
        | IssuingCardSpendingLimitCategories'ShoeRepairHatCleaning
        | IssuingCardSpendingLimitCategories'ShoeStores
        | IssuingCardSpendingLimitCategories'SmallApplianceRepair
        | IssuingCardSpendingLimitCategories'SnowmobileDealers
        | IssuingCardSpendingLimitCategories'SpecialTradeServices
        | IssuingCardSpendingLimitCategories'SpecialtyCleaning
        | IssuingCardSpendingLimitCategories'SportingGoodsStores
        | IssuingCardSpendingLimitCategories'SportingRecreationCamps
        | IssuingCardSpendingLimitCategories'SportsAndRidingApparelStores
        | IssuingCardSpendingLimitCategories'SportsClubsFields
        | IssuingCardSpendingLimitCategories'StampAndCoinStores
        | IssuingCardSpendingLimitCategories'StationaryOfficeSuppliesPrintingAndWritingPaper
        | IssuingCardSpendingLimitCategories'StationeryStoresOfficeAndSchoolSupplyStores
        | IssuingCardSpendingLimitCategories'SwimmingPoolsSales
        | IssuingCardSpendingLimitCategories'TUiTravelGermany
        | IssuingCardSpendingLimitCategories'TailorsAlterations
        | IssuingCardSpendingLimitCategories'TaxPaymentsGovernmentAgencies
        | IssuingCardSpendingLimitCategories'TaxPreparationServices
        | IssuingCardSpendingLimitCategories'TaxicabsLimousines
        | IssuingCardSpendingLimitCategories'TelecommunicationEquipmentAndTelephoneSales
        | IssuingCardSpendingLimitCategories'TelecommunicationServices
        | IssuingCardSpendingLimitCategories'TelegraphServices
        | IssuingCardSpendingLimitCategories'TentAndAwningShops
        | IssuingCardSpendingLimitCategories'TestingLaboratories
        | IssuingCardSpendingLimitCategories'TheatricalTicketAgencies
        | IssuingCardSpendingLimitCategories'Timeshares
        | IssuingCardSpendingLimitCategories'TireRetreadingAndRepair
        | IssuingCardSpendingLimitCategories'TollsBridgeFees
        | IssuingCardSpendingLimitCategories'TouristAttractionsAndExhibits
        | IssuingCardSpendingLimitCategories'TowingServices
        | IssuingCardSpendingLimitCategories'TrailerParksCampgrounds
        | IssuingCardSpendingLimitCategories'TransportationServices
        | IssuingCardSpendingLimitCategories'TravelAgenciesTourOperators
        | IssuingCardSpendingLimitCategories'TruckStopIteration
        | IssuingCardSpendingLimitCategories'TruckUtilityTrailerRentals
        | IssuingCardSpendingLimitCategories'TypesettingPlateMakingAndRelatedServices
        | IssuingCardSpendingLimitCategories'TypewriterStores
        | IssuingCardSpendingLimitCategories'USFederalGovernmentAgenciesOrDepartments
        | IssuingCardSpendingLimitCategories'UniformsCommercialClothing
        | IssuingCardSpendingLimitCategories'UsedMerchandiseAndSecondhandStores
        | IssuingCardSpendingLimitCategories'Utilities
        | IssuingCardSpendingLimitCategories'VarietyStores
        | IssuingCardSpendingLimitCategories'VeterinaryServices
        | IssuingCardSpendingLimitCategories'VideoAmusementGameSupplies
        | IssuingCardSpendingLimitCategories'VideoGameArcades
        | IssuingCardSpendingLimitCategories'VideoTapeRentalStores
        | IssuingCardSpendingLimitCategories'VocationalTradeSchools
        | IssuingCardSpendingLimitCategories'WatchJewelryRepair
        | IssuingCardSpendingLimitCategories'WeldingRepair
        | IssuingCardSpendingLimitCategories'WholesaleClubs
        | IssuingCardSpendingLimitCategories'WigAndToupeeStores
        | IssuingCardSpendingLimitCategories'WiresMoneyOrders
        | IssuingCardSpendingLimitCategories'WomensAccessoryAndSpecialtyShops
        | IssuingCardSpendingLimitCategories'WomensReadyToWearStores
        | IssuingCardSpendingLimitCategories'WreckingAndSalvageYards

    and IssuingCardSpendingLimitInterval =
        | IssuingCardSpendingLimitInterval'AllTime
        | IssuingCardSpendingLimitInterval'Daily
        | IssuingCardSpendingLimitInterval'Monthly
        | IssuingCardSpendingLimitInterval'PerAuthorization
        | IssuingCardSpendingLimitInterval'Weekly
        | IssuingCardSpendingLimitInterval'Yearly

    ///
    and IssuingCardholderAddress (address: Address) =

        member _.Address = address

    ///
    and IssuingCardholderAuthorizationControls (allowedCategories: IssuingCardholderAuthorizationControlsAllowedCategories list option, blockedCategories: IssuingCardholderAuthorizationControlsBlockedCategories list option, spendingLimits: IssuingCardholderSpendingLimit list option, spendingLimitsCurrency: string option) =

        member _.AllowedCategories = allowedCategories
        member _.BlockedCategories = blockedCategories
        member _.SpendingLimits = spendingLimits
        member _.SpendingLimitsCurrency = spendingLimitsCurrency

    and IssuingCardholderAuthorizationControlsAllowedCategories =
        | IssuingCardholderAuthorizationControlsAllowedCategories'AcRefrigerationRepair
        | IssuingCardholderAuthorizationControlsAllowedCategories'AccountingBookkeepingServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'AdvertisingServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'AgriculturalCooperative
        | IssuingCardholderAuthorizationControlsAllowedCategories'AirlinesAirCarriers
        | IssuingCardholderAuthorizationControlsAllowedCategories'AirportsFlyingFields
        | IssuingCardholderAuthorizationControlsAllowedCategories'AmbulanceServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'AmusementParksCarnivals
        | IssuingCardholderAuthorizationControlsAllowedCategories'AntiqueReproductions
        | IssuingCardholderAuthorizationControlsAllowedCategories'AntiqueShops
        | IssuingCardholderAuthorizationControlsAllowedCategories'Aquariums
        | IssuingCardholderAuthorizationControlsAllowedCategories'ArchitecturalSurveyingServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'ArtDealersAndGalleries
        | IssuingCardholderAuthorizationControlsAllowedCategories'ArtistsSupplyAndCraftShops
        | IssuingCardholderAuthorizationControlsAllowedCategories'AutoAndHomeSupplyStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'AutoBodyRepairShops
        | IssuingCardholderAuthorizationControlsAllowedCategories'AutoPaintShops
        | IssuingCardholderAuthorizationControlsAllowedCategories'AutoServiceShops
        | IssuingCardholderAuthorizationControlsAllowedCategories'AutomatedCashDisburse
        | IssuingCardholderAuthorizationControlsAllowedCategories'AutomatedFuelDispensers
        | IssuingCardholderAuthorizationControlsAllowedCategories'AutomobileAssociations
        | IssuingCardholderAuthorizationControlsAllowedCategories'AutomotivePartsAndAccessoriesStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'AutomotiveTireStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'BailAndBondPayments
        | IssuingCardholderAuthorizationControlsAllowedCategories'Bakeries
        | IssuingCardholderAuthorizationControlsAllowedCategories'BandsOrchestras
        | IssuingCardholderAuthorizationControlsAllowedCategories'BarberAndBeautyShops
        | IssuingCardholderAuthorizationControlsAllowedCategories'BettingCasinoGambling
        | IssuingCardholderAuthorizationControlsAllowedCategories'BicycleShops
        | IssuingCardholderAuthorizationControlsAllowedCategories'BilliardPoolEstablishments
        | IssuingCardholderAuthorizationControlsAllowedCategories'BoatDealers
        | IssuingCardholderAuthorizationControlsAllowedCategories'BoatRentalsAndLeases
        | IssuingCardholderAuthorizationControlsAllowedCategories'BookStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'BooksPeriodicalsAndNewspapers
        | IssuingCardholderAuthorizationControlsAllowedCategories'BowlingAlleys
        | IssuingCardholderAuthorizationControlsAllowedCategories'BusLines
        | IssuingCardholderAuthorizationControlsAllowedCategories'BusinessSecretarialSchools
        | IssuingCardholderAuthorizationControlsAllowedCategories'BuyingShoppingServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'CableSatelliteAndOtherPayTelevisionAndRadio
        | IssuingCardholderAuthorizationControlsAllowedCategories'CameraAndPhotographicSupplyStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'CandyNutAndConfectioneryStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'CarAndTruckDealersNewUsed
        | IssuingCardholderAuthorizationControlsAllowedCategories'CarAndTruckDealersUsedOnly
        | IssuingCardholderAuthorizationControlsAllowedCategories'CarRentalAgencies
        | IssuingCardholderAuthorizationControlsAllowedCategories'CarWashes
        | IssuingCardholderAuthorizationControlsAllowedCategories'CarpentryServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'CarpetUpholsteryCleaning
        | IssuingCardholderAuthorizationControlsAllowedCategories'Caterers
        | IssuingCardholderAuthorizationControlsAllowedCategories'CharitableAndSocialServiceOrganizationsFundraising
        | IssuingCardholderAuthorizationControlsAllowedCategories'ChemicalsAndAlliedProducts
        | IssuingCardholderAuthorizationControlsAllowedCategories'ChildCareServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'ChildrensAndInfantsWearStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'ChiropodistsPodiatrists
        | IssuingCardholderAuthorizationControlsAllowedCategories'Chiropractors
        | IssuingCardholderAuthorizationControlsAllowedCategories'CigarStoresAndStands
        | IssuingCardholderAuthorizationControlsAllowedCategories'CivicSocialFraternalAssociations
        | IssuingCardholderAuthorizationControlsAllowedCategories'CleaningAndMaintenance
        | IssuingCardholderAuthorizationControlsAllowedCategories'ClothingRental
        | IssuingCardholderAuthorizationControlsAllowedCategories'CollegesUniversities
        | IssuingCardholderAuthorizationControlsAllowedCategories'CommercialEquipment
        | IssuingCardholderAuthorizationControlsAllowedCategories'CommercialFootwear
        | IssuingCardholderAuthorizationControlsAllowedCategories'CommercialPhotographyArtAndGraphics
        | IssuingCardholderAuthorizationControlsAllowedCategories'CommuterTransportAndFerries
        | IssuingCardholderAuthorizationControlsAllowedCategories'ComputerNetworkServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'ComputerProgramming
        | IssuingCardholderAuthorizationControlsAllowedCategories'ComputerRepair
        | IssuingCardholderAuthorizationControlsAllowedCategories'ComputerSoftwareStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'ComputersPeripheralsAndSoftware
        | IssuingCardholderAuthorizationControlsAllowedCategories'ConcreteWorkServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'ConstructionMaterials
        | IssuingCardholderAuthorizationControlsAllowedCategories'ConsultingPublicRelations
        | IssuingCardholderAuthorizationControlsAllowedCategories'CorrespondenceSchools
        | IssuingCardholderAuthorizationControlsAllowedCategories'CosmeticStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'CounselingServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'CountryClubs
        | IssuingCardholderAuthorizationControlsAllowedCategories'CourierServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'CourtCosts
        | IssuingCardholderAuthorizationControlsAllowedCategories'CreditReportingAgencies
        | IssuingCardholderAuthorizationControlsAllowedCategories'CruiseLines
        | IssuingCardholderAuthorizationControlsAllowedCategories'DairyProductsStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'DanceHallStudiosSchools
        | IssuingCardholderAuthorizationControlsAllowedCategories'DatingEscortServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'DentistsOrthodontists
        | IssuingCardholderAuthorizationControlsAllowedCategories'DepartmentStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'DetectiveAgencies
        | IssuingCardholderAuthorizationControlsAllowedCategories'DigitalGoodsApplications
        | IssuingCardholderAuthorizationControlsAllowedCategories'DigitalGoodsGames
        | IssuingCardholderAuthorizationControlsAllowedCategories'DigitalGoodsLargeVolume
        | IssuingCardholderAuthorizationControlsAllowedCategories'DigitalGoodsMedia
        | IssuingCardholderAuthorizationControlsAllowedCategories'DirectMarketingCatalogMerchant
        | IssuingCardholderAuthorizationControlsAllowedCategories'DirectMarketingCombinationCatalogAndRetailMerchant
        | IssuingCardholderAuthorizationControlsAllowedCategories'DirectMarketingInboundTelemarketing
        | IssuingCardholderAuthorizationControlsAllowedCategories'DirectMarketingInsuranceServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'DirectMarketingOther
        | IssuingCardholderAuthorizationControlsAllowedCategories'DirectMarketingOutboundTelemarketing
        | IssuingCardholderAuthorizationControlsAllowedCategories'DirectMarketingSubscription
        | IssuingCardholderAuthorizationControlsAllowedCategories'DirectMarketingTravel
        | IssuingCardholderAuthorizationControlsAllowedCategories'DiscountStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'Doctors
        | IssuingCardholderAuthorizationControlsAllowedCategories'DoorToDoorSales
        | IssuingCardholderAuthorizationControlsAllowedCategories'DraperyWindowCoveringAndUpholsteryStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'DrinkingPlaces
        | IssuingCardholderAuthorizationControlsAllowedCategories'DrugStoresAndPharmacies
        | IssuingCardholderAuthorizationControlsAllowedCategories'DrugsDrugProprietariesAndDruggistSundries
        | IssuingCardholderAuthorizationControlsAllowedCategories'DryCleaners
        | IssuingCardholderAuthorizationControlsAllowedCategories'DurableGoods
        | IssuingCardholderAuthorizationControlsAllowedCategories'DutyFreeStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'EatingPlacesRestaurants
        | IssuingCardholderAuthorizationControlsAllowedCategories'EducationalServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'ElectricRazorStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'ElectricalPartsAndEquipment
        | IssuingCardholderAuthorizationControlsAllowedCategories'ElectricalServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'ElectronicsRepairShops
        | IssuingCardholderAuthorizationControlsAllowedCategories'ElectronicsStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'ElementarySecondarySchools
        | IssuingCardholderAuthorizationControlsAllowedCategories'EmploymentTempAgencies
        | IssuingCardholderAuthorizationControlsAllowedCategories'EquipmentRental
        | IssuingCardholderAuthorizationControlsAllowedCategories'ExterminatingServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'FamilyClothingStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'FastFoodRestaurants
        | IssuingCardholderAuthorizationControlsAllowedCategories'FinancialInstitutions
        | IssuingCardholderAuthorizationControlsAllowedCategories'FinesGovernmentAdministrativeEntities
        | IssuingCardholderAuthorizationControlsAllowedCategories'FireplaceFireplaceScreensAndAccessoriesStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'FloorCoveringStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'Florists
        | IssuingCardholderAuthorizationControlsAllowedCategories'FloristsSuppliesNurseryStockAndFlowers
        | IssuingCardholderAuthorizationControlsAllowedCategories'FreezerAndLockerMeatProvisioners
        | IssuingCardholderAuthorizationControlsAllowedCategories'FuelDealersNonAutomotive
        | IssuingCardholderAuthorizationControlsAllowedCategories'FuneralServicesCrematories
        | IssuingCardholderAuthorizationControlsAllowedCategories'FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | IssuingCardholderAuthorizationControlsAllowedCategories'FurnitureRepairRefinishing
        | IssuingCardholderAuthorizationControlsAllowedCategories'FurriersAndFurShops
        | IssuingCardholderAuthorizationControlsAllowedCategories'GeneralServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'GiftCardNoveltyAndSouvenirShops
        | IssuingCardholderAuthorizationControlsAllowedCategories'GlassPaintAndWallpaperStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'GlasswareCrystalStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'GolfCoursesPublic
        | IssuingCardholderAuthorizationControlsAllowedCategories'GovernmentServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'GroceryStoresSupermarkets
        | IssuingCardholderAuthorizationControlsAllowedCategories'HardwareEquipmentAndSupplies
        | IssuingCardholderAuthorizationControlsAllowedCategories'HardwareStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'HealthAndBeautySpas
        | IssuingCardholderAuthorizationControlsAllowedCategories'HearingAidsSalesAndSupplies
        | IssuingCardholderAuthorizationControlsAllowedCategories'HeatingPlumbingAC
        | IssuingCardholderAuthorizationControlsAllowedCategories'HobbyToyAndGameShops
        | IssuingCardholderAuthorizationControlsAllowedCategories'HomeSupplyWarehouseStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'Hospitals
        | IssuingCardholderAuthorizationControlsAllowedCategories'HotelsMotelsAndResorts
        | IssuingCardholderAuthorizationControlsAllowedCategories'HouseholdApplianceStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'IndustrialSupplies
        | IssuingCardholderAuthorizationControlsAllowedCategories'InformationRetrievalServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'InsuranceDefault
        | IssuingCardholderAuthorizationControlsAllowedCategories'InsuranceUnderwritingPremiums
        | IssuingCardholderAuthorizationControlsAllowedCategories'IntraCompanyPurchases
        | IssuingCardholderAuthorizationControlsAllowedCategories'JewelryStoresWatchesClocksAndSilverwareStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'LandscapingServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'Laundries
        | IssuingCardholderAuthorizationControlsAllowedCategories'LaundryCleaningServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'LegalServicesAttorneys
        | IssuingCardholderAuthorizationControlsAllowedCategories'LuggageAndLeatherGoodsStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'LumberBuildingMaterialsStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'ManualCashDisburse
        | IssuingCardholderAuthorizationControlsAllowedCategories'MarinasServiceAndSupplies
        | IssuingCardholderAuthorizationControlsAllowedCategories'MasonryStoneworkAndPlaster
        | IssuingCardholderAuthorizationControlsAllowedCategories'MassageParlors
        | IssuingCardholderAuthorizationControlsAllowedCategories'MedicalAndDentalLabs
        | IssuingCardholderAuthorizationControlsAllowedCategories'MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | IssuingCardholderAuthorizationControlsAllowedCategories'MedicalServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'MembershipOrganizations
        | IssuingCardholderAuthorizationControlsAllowedCategories'MensAndBoysClothingAndAccessoriesStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'MensWomensClothingStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'MetalServiceCenters
        | IssuingCardholderAuthorizationControlsAllowedCategories'Miscellaneous
        | IssuingCardholderAuthorizationControlsAllowedCategories'MiscellaneousApparelAndAccessoryShops
        | IssuingCardholderAuthorizationControlsAllowedCategories'MiscellaneousAutoDealers
        | IssuingCardholderAuthorizationControlsAllowedCategories'MiscellaneousBusinessServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'MiscellaneousFoodStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'MiscellaneousGeneralMerchandise
        | IssuingCardholderAuthorizationControlsAllowedCategories'MiscellaneousGeneralServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'MiscellaneousHomeFurnishingSpecialtyStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'MiscellaneousPublishingAndPrinting
        | IssuingCardholderAuthorizationControlsAllowedCategories'MiscellaneousRecreationServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'MiscellaneousRepairShops
        | IssuingCardholderAuthorizationControlsAllowedCategories'MiscellaneousSpecialtyRetail
        | IssuingCardholderAuthorizationControlsAllowedCategories'MobileHomeDealers
        | IssuingCardholderAuthorizationControlsAllowedCategories'MotionPictureTheaters
        | IssuingCardholderAuthorizationControlsAllowedCategories'MotorFreightCarriersAndTrucking
        | IssuingCardholderAuthorizationControlsAllowedCategories'MotorHomesDealers
        | IssuingCardholderAuthorizationControlsAllowedCategories'MotorVehicleSuppliesAndNewParts
        | IssuingCardholderAuthorizationControlsAllowedCategories'MotorcycleShopsAndDealers
        | IssuingCardholderAuthorizationControlsAllowedCategories'MotorcycleShopsDealers
        | IssuingCardholderAuthorizationControlsAllowedCategories'MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | IssuingCardholderAuthorizationControlsAllowedCategories'NewsDealersAndNewsstands
        | IssuingCardholderAuthorizationControlsAllowedCategories'NonFiMoneyOrders
        | IssuingCardholderAuthorizationControlsAllowedCategories'NonFiStoredValueCardPurchaseLoad
        | IssuingCardholderAuthorizationControlsAllowedCategories'NondurableGoods
        | IssuingCardholderAuthorizationControlsAllowedCategories'NurseriesLawnAndGardenSupplyStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'NursingPersonalCare
        | IssuingCardholderAuthorizationControlsAllowedCategories'OfficeAndCommercialFurniture
        | IssuingCardholderAuthorizationControlsAllowedCategories'OpticiansEyeglasses
        | IssuingCardholderAuthorizationControlsAllowedCategories'OptometristsOphthalmologist
        | IssuingCardholderAuthorizationControlsAllowedCategories'OrthopedicGoodsProstheticDevices
        | IssuingCardholderAuthorizationControlsAllowedCategories'Osteopaths
        | IssuingCardholderAuthorizationControlsAllowedCategories'PackageStoresBeerWineAndLiquor
        | IssuingCardholderAuthorizationControlsAllowedCategories'PaintsVarnishesAndSupplies
        | IssuingCardholderAuthorizationControlsAllowedCategories'ParkingLotsGarages
        | IssuingCardholderAuthorizationControlsAllowedCategories'PassengerRailways
        | IssuingCardholderAuthorizationControlsAllowedCategories'PawnShops
        | IssuingCardholderAuthorizationControlsAllowedCategories'PetShopsPetFoodAndSupplies
        | IssuingCardholderAuthorizationControlsAllowedCategories'PetroleumAndPetroleumProducts
        | IssuingCardholderAuthorizationControlsAllowedCategories'PhotoDeveloping
        | IssuingCardholderAuthorizationControlsAllowedCategories'PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | IssuingCardholderAuthorizationControlsAllowedCategories'PhotographicStudios
        | IssuingCardholderAuthorizationControlsAllowedCategories'PictureVideoProduction
        | IssuingCardholderAuthorizationControlsAllowedCategories'PieceGoodsNotionsAndOtherDryGoods
        | IssuingCardholderAuthorizationControlsAllowedCategories'PlumbingHeatingEquipmentAndSupplies
        | IssuingCardholderAuthorizationControlsAllowedCategories'PoliticalOrganizations
        | IssuingCardholderAuthorizationControlsAllowedCategories'PostalServicesGovernmentOnly
        | IssuingCardholderAuthorizationControlsAllowedCategories'PreciousStonesAndMetalsWatchesAndJewelry
        | IssuingCardholderAuthorizationControlsAllowedCategories'ProfessionalServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'PublicWarehousingAndStorage
        | IssuingCardholderAuthorizationControlsAllowedCategories'QuickCopyReproAndBlueprint
        | IssuingCardholderAuthorizationControlsAllowedCategories'Railroads
        | IssuingCardholderAuthorizationControlsAllowedCategories'RealEstateAgentsAndManagersRentals
        | IssuingCardholderAuthorizationControlsAllowedCategories'RecordStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'RecreationalVehicleRentals
        | IssuingCardholderAuthorizationControlsAllowedCategories'ReligiousGoodsStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'ReligiousOrganizations
        | IssuingCardholderAuthorizationControlsAllowedCategories'RoofingSidingSheetMetal
        | IssuingCardholderAuthorizationControlsAllowedCategories'SecretarialSupportServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'SecurityBrokersDealers
        | IssuingCardholderAuthorizationControlsAllowedCategories'ServiceStations
        | IssuingCardholderAuthorizationControlsAllowedCategories'SewingNeedleworkFabricAndPieceGoodsStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'ShoeRepairHatCleaning
        | IssuingCardholderAuthorizationControlsAllowedCategories'ShoeStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'SmallApplianceRepair
        | IssuingCardholderAuthorizationControlsAllowedCategories'SnowmobileDealers
        | IssuingCardholderAuthorizationControlsAllowedCategories'SpecialTradeServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'SpecialtyCleaning
        | IssuingCardholderAuthorizationControlsAllowedCategories'SportingGoodsStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'SportingRecreationCamps
        | IssuingCardholderAuthorizationControlsAllowedCategories'SportsAndRidingApparelStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'SportsClubsFields
        | IssuingCardholderAuthorizationControlsAllowedCategories'StampAndCoinStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'StationaryOfficeSuppliesPrintingAndWritingPaper
        | IssuingCardholderAuthorizationControlsAllowedCategories'StationeryStoresOfficeAndSchoolSupplyStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'SwimmingPoolsSales
        | IssuingCardholderAuthorizationControlsAllowedCategories'TUiTravelGermany
        | IssuingCardholderAuthorizationControlsAllowedCategories'TailorsAlterations
        | IssuingCardholderAuthorizationControlsAllowedCategories'TaxPaymentsGovernmentAgencies
        | IssuingCardholderAuthorizationControlsAllowedCategories'TaxPreparationServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'TaxicabsLimousines
        | IssuingCardholderAuthorizationControlsAllowedCategories'TelecommunicationEquipmentAndTelephoneSales
        | IssuingCardholderAuthorizationControlsAllowedCategories'TelecommunicationServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'TelegraphServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'TentAndAwningShops
        | IssuingCardholderAuthorizationControlsAllowedCategories'TestingLaboratories
        | IssuingCardholderAuthorizationControlsAllowedCategories'TheatricalTicketAgencies
        | IssuingCardholderAuthorizationControlsAllowedCategories'Timeshares
        | IssuingCardholderAuthorizationControlsAllowedCategories'TireRetreadingAndRepair
        | IssuingCardholderAuthorizationControlsAllowedCategories'TollsBridgeFees
        | IssuingCardholderAuthorizationControlsAllowedCategories'TouristAttractionsAndExhibits
        | IssuingCardholderAuthorizationControlsAllowedCategories'TowingServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'TrailerParksCampgrounds
        | IssuingCardholderAuthorizationControlsAllowedCategories'TransportationServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'TravelAgenciesTourOperators
        | IssuingCardholderAuthorizationControlsAllowedCategories'TruckStopIteration
        | IssuingCardholderAuthorizationControlsAllowedCategories'TruckUtilityTrailerRentals
        | IssuingCardholderAuthorizationControlsAllowedCategories'TypesettingPlateMakingAndRelatedServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'TypewriterStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'USFederalGovernmentAgenciesOrDepartments
        | IssuingCardholderAuthorizationControlsAllowedCategories'UniformsCommercialClothing
        | IssuingCardholderAuthorizationControlsAllowedCategories'UsedMerchandiseAndSecondhandStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'Utilities
        | IssuingCardholderAuthorizationControlsAllowedCategories'VarietyStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'VeterinaryServices
        | IssuingCardholderAuthorizationControlsAllowedCategories'VideoAmusementGameSupplies
        | IssuingCardholderAuthorizationControlsAllowedCategories'VideoGameArcades
        | IssuingCardholderAuthorizationControlsAllowedCategories'VideoTapeRentalStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'VocationalTradeSchools
        | IssuingCardholderAuthorizationControlsAllowedCategories'WatchJewelryRepair
        | IssuingCardholderAuthorizationControlsAllowedCategories'WeldingRepair
        | IssuingCardholderAuthorizationControlsAllowedCategories'WholesaleClubs
        | IssuingCardholderAuthorizationControlsAllowedCategories'WigAndToupeeStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'WiresMoneyOrders
        | IssuingCardholderAuthorizationControlsAllowedCategories'WomensAccessoryAndSpecialtyShops
        | IssuingCardholderAuthorizationControlsAllowedCategories'WomensReadyToWearStores
        | IssuingCardholderAuthorizationControlsAllowedCategories'WreckingAndSalvageYards

    and IssuingCardholderAuthorizationControlsBlockedCategories =
        | IssuingCardholderAuthorizationControlsBlockedCategories'AcRefrigerationRepair
        | IssuingCardholderAuthorizationControlsBlockedCategories'AccountingBookkeepingServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'AdvertisingServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'AgriculturalCooperative
        | IssuingCardholderAuthorizationControlsBlockedCategories'AirlinesAirCarriers
        | IssuingCardholderAuthorizationControlsBlockedCategories'AirportsFlyingFields
        | IssuingCardholderAuthorizationControlsBlockedCategories'AmbulanceServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'AmusementParksCarnivals
        | IssuingCardholderAuthorizationControlsBlockedCategories'AntiqueReproductions
        | IssuingCardholderAuthorizationControlsBlockedCategories'AntiqueShops
        | IssuingCardholderAuthorizationControlsBlockedCategories'Aquariums
        | IssuingCardholderAuthorizationControlsBlockedCategories'ArchitecturalSurveyingServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'ArtDealersAndGalleries
        | IssuingCardholderAuthorizationControlsBlockedCategories'ArtistsSupplyAndCraftShops
        | IssuingCardholderAuthorizationControlsBlockedCategories'AutoAndHomeSupplyStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'AutoBodyRepairShops
        | IssuingCardholderAuthorizationControlsBlockedCategories'AutoPaintShops
        | IssuingCardholderAuthorizationControlsBlockedCategories'AutoServiceShops
        | IssuingCardholderAuthorizationControlsBlockedCategories'AutomatedCashDisburse
        | IssuingCardholderAuthorizationControlsBlockedCategories'AutomatedFuelDispensers
        | IssuingCardholderAuthorizationControlsBlockedCategories'AutomobileAssociations
        | IssuingCardholderAuthorizationControlsBlockedCategories'AutomotivePartsAndAccessoriesStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'AutomotiveTireStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'BailAndBondPayments
        | IssuingCardholderAuthorizationControlsBlockedCategories'Bakeries
        | IssuingCardholderAuthorizationControlsBlockedCategories'BandsOrchestras
        | IssuingCardholderAuthorizationControlsBlockedCategories'BarberAndBeautyShops
        | IssuingCardholderAuthorizationControlsBlockedCategories'BettingCasinoGambling
        | IssuingCardholderAuthorizationControlsBlockedCategories'BicycleShops
        | IssuingCardholderAuthorizationControlsBlockedCategories'BilliardPoolEstablishments
        | IssuingCardholderAuthorizationControlsBlockedCategories'BoatDealers
        | IssuingCardholderAuthorizationControlsBlockedCategories'BoatRentalsAndLeases
        | IssuingCardholderAuthorizationControlsBlockedCategories'BookStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'BooksPeriodicalsAndNewspapers
        | IssuingCardholderAuthorizationControlsBlockedCategories'BowlingAlleys
        | IssuingCardholderAuthorizationControlsBlockedCategories'BusLines
        | IssuingCardholderAuthorizationControlsBlockedCategories'BusinessSecretarialSchools
        | IssuingCardholderAuthorizationControlsBlockedCategories'BuyingShoppingServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'CableSatelliteAndOtherPayTelevisionAndRadio
        | IssuingCardholderAuthorizationControlsBlockedCategories'CameraAndPhotographicSupplyStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'CandyNutAndConfectioneryStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'CarAndTruckDealersNewUsed
        | IssuingCardholderAuthorizationControlsBlockedCategories'CarAndTruckDealersUsedOnly
        | IssuingCardholderAuthorizationControlsBlockedCategories'CarRentalAgencies
        | IssuingCardholderAuthorizationControlsBlockedCategories'CarWashes
        | IssuingCardholderAuthorizationControlsBlockedCategories'CarpentryServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'CarpetUpholsteryCleaning
        | IssuingCardholderAuthorizationControlsBlockedCategories'Caterers
        | IssuingCardholderAuthorizationControlsBlockedCategories'CharitableAndSocialServiceOrganizationsFundraising
        | IssuingCardholderAuthorizationControlsBlockedCategories'ChemicalsAndAlliedProducts
        | IssuingCardholderAuthorizationControlsBlockedCategories'ChildCareServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'ChildrensAndInfantsWearStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'ChiropodistsPodiatrists
        | IssuingCardholderAuthorizationControlsBlockedCategories'Chiropractors
        | IssuingCardholderAuthorizationControlsBlockedCategories'CigarStoresAndStands
        | IssuingCardholderAuthorizationControlsBlockedCategories'CivicSocialFraternalAssociations
        | IssuingCardholderAuthorizationControlsBlockedCategories'CleaningAndMaintenance
        | IssuingCardholderAuthorizationControlsBlockedCategories'ClothingRental
        | IssuingCardholderAuthorizationControlsBlockedCategories'CollegesUniversities
        | IssuingCardholderAuthorizationControlsBlockedCategories'CommercialEquipment
        | IssuingCardholderAuthorizationControlsBlockedCategories'CommercialFootwear
        | IssuingCardholderAuthorizationControlsBlockedCategories'CommercialPhotographyArtAndGraphics
        | IssuingCardholderAuthorizationControlsBlockedCategories'CommuterTransportAndFerries
        | IssuingCardholderAuthorizationControlsBlockedCategories'ComputerNetworkServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'ComputerProgramming
        | IssuingCardholderAuthorizationControlsBlockedCategories'ComputerRepair
        | IssuingCardholderAuthorizationControlsBlockedCategories'ComputerSoftwareStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'ComputersPeripheralsAndSoftware
        | IssuingCardholderAuthorizationControlsBlockedCategories'ConcreteWorkServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'ConstructionMaterials
        | IssuingCardholderAuthorizationControlsBlockedCategories'ConsultingPublicRelations
        | IssuingCardholderAuthorizationControlsBlockedCategories'CorrespondenceSchools
        | IssuingCardholderAuthorizationControlsBlockedCategories'CosmeticStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'CounselingServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'CountryClubs
        | IssuingCardholderAuthorizationControlsBlockedCategories'CourierServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'CourtCosts
        | IssuingCardholderAuthorizationControlsBlockedCategories'CreditReportingAgencies
        | IssuingCardholderAuthorizationControlsBlockedCategories'CruiseLines
        | IssuingCardholderAuthorizationControlsBlockedCategories'DairyProductsStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'DanceHallStudiosSchools
        | IssuingCardholderAuthorizationControlsBlockedCategories'DatingEscortServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'DentistsOrthodontists
        | IssuingCardholderAuthorizationControlsBlockedCategories'DepartmentStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'DetectiveAgencies
        | IssuingCardholderAuthorizationControlsBlockedCategories'DigitalGoodsApplications
        | IssuingCardholderAuthorizationControlsBlockedCategories'DigitalGoodsGames
        | IssuingCardholderAuthorizationControlsBlockedCategories'DigitalGoodsLargeVolume
        | IssuingCardholderAuthorizationControlsBlockedCategories'DigitalGoodsMedia
        | IssuingCardholderAuthorizationControlsBlockedCategories'DirectMarketingCatalogMerchant
        | IssuingCardholderAuthorizationControlsBlockedCategories'DirectMarketingCombinationCatalogAndRetailMerchant
        | IssuingCardholderAuthorizationControlsBlockedCategories'DirectMarketingInboundTelemarketing
        | IssuingCardholderAuthorizationControlsBlockedCategories'DirectMarketingInsuranceServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'DirectMarketingOther
        | IssuingCardholderAuthorizationControlsBlockedCategories'DirectMarketingOutboundTelemarketing
        | IssuingCardholderAuthorizationControlsBlockedCategories'DirectMarketingSubscription
        | IssuingCardholderAuthorizationControlsBlockedCategories'DirectMarketingTravel
        | IssuingCardholderAuthorizationControlsBlockedCategories'DiscountStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'Doctors
        | IssuingCardholderAuthorizationControlsBlockedCategories'DoorToDoorSales
        | IssuingCardholderAuthorizationControlsBlockedCategories'DraperyWindowCoveringAndUpholsteryStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'DrinkingPlaces
        | IssuingCardholderAuthorizationControlsBlockedCategories'DrugStoresAndPharmacies
        | IssuingCardholderAuthorizationControlsBlockedCategories'DrugsDrugProprietariesAndDruggistSundries
        | IssuingCardholderAuthorizationControlsBlockedCategories'DryCleaners
        | IssuingCardholderAuthorizationControlsBlockedCategories'DurableGoods
        | IssuingCardholderAuthorizationControlsBlockedCategories'DutyFreeStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'EatingPlacesRestaurants
        | IssuingCardholderAuthorizationControlsBlockedCategories'EducationalServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'ElectricRazorStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'ElectricalPartsAndEquipment
        | IssuingCardholderAuthorizationControlsBlockedCategories'ElectricalServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'ElectronicsRepairShops
        | IssuingCardholderAuthorizationControlsBlockedCategories'ElectronicsStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'ElementarySecondarySchools
        | IssuingCardholderAuthorizationControlsBlockedCategories'EmploymentTempAgencies
        | IssuingCardholderAuthorizationControlsBlockedCategories'EquipmentRental
        | IssuingCardholderAuthorizationControlsBlockedCategories'ExterminatingServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'FamilyClothingStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'FastFoodRestaurants
        | IssuingCardholderAuthorizationControlsBlockedCategories'FinancialInstitutions
        | IssuingCardholderAuthorizationControlsBlockedCategories'FinesGovernmentAdministrativeEntities
        | IssuingCardholderAuthorizationControlsBlockedCategories'FireplaceFireplaceScreensAndAccessoriesStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'FloorCoveringStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'Florists
        | IssuingCardholderAuthorizationControlsBlockedCategories'FloristsSuppliesNurseryStockAndFlowers
        | IssuingCardholderAuthorizationControlsBlockedCategories'FreezerAndLockerMeatProvisioners
        | IssuingCardholderAuthorizationControlsBlockedCategories'FuelDealersNonAutomotive
        | IssuingCardholderAuthorizationControlsBlockedCategories'FuneralServicesCrematories
        | IssuingCardholderAuthorizationControlsBlockedCategories'FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | IssuingCardholderAuthorizationControlsBlockedCategories'FurnitureRepairRefinishing
        | IssuingCardholderAuthorizationControlsBlockedCategories'FurriersAndFurShops
        | IssuingCardholderAuthorizationControlsBlockedCategories'GeneralServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'GiftCardNoveltyAndSouvenirShops
        | IssuingCardholderAuthorizationControlsBlockedCategories'GlassPaintAndWallpaperStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'GlasswareCrystalStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'GolfCoursesPublic
        | IssuingCardholderAuthorizationControlsBlockedCategories'GovernmentServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'GroceryStoresSupermarkets
        | IssuingCardholderAuthorizationControlsBlockedCategories'HardwareEquipmentAndSupplies
        | IssuingCardholderAuthorizationControlsBlockedCategories'HardwareStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'HealthAndBeautySpas
        | IssuingCardholderAuthorizationControlsBlockedCategories'HearingAidsSalesAndSupplies
        | IssuingCardholderAuthorizationControlsBlockedCategories'HeatingPlumbingAC
        | IssuingCardholderAuthorizationControlsBlockedCategories'HobbyToyAndGameShops
        | IssuingCardholderAuthorizationControlsBlockedCategories'HomeSupplyWarehouseStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'Hospitals
        | IssuingCardholderAuthorizationControlsBlockedCategories'HotelsMotelsAndResorts
        | IssuingCardholderAuthorizationControlsBlockedCategories'HouseholdApplianceStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'IndustrialSupplies
        | IssuingCardholderAuthorizationControlsBlockedCategories'InformationRetrievalServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'InsuranceDefault
        | IssuingCardholderAuthorizationControlsBlockedCategories'InsuranceUnderwritingPremiums
        | IssuingCardholderAuthorizationControlsBlockedCategories'IntraCompanyPurchases
        | IssuingCardholderAuthorizationControlsBlockedCategories'JewelryStoresWatchesClocksAndSilverwareStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'LandscapingServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'Laundries
        | IssuingCardholderAuthorizationControlsBlockedCategories'LaundryCleaningServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'LegalServicesAttorneys
        | IssuingCardholderAuthorizationControlsBlockedCategories'LuggageAndLeatherGoodsStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'LumberBuildingMaterialsStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'ManualCashDisburse
        | IssuingCardholderAuthorizationControlsBlockedCategories'MarinasServiceAndSupplies
        | IssuingCardholderAuthorizationControlsBlockedCategories'MasonryStoneworkAndPlaster
        | IssuingCardholderAuthorizationControlsBlockedCategories'MassageParlors
        | IssuingCardholderAuthorizationControlsBlockedCategories'MedicalAndDentalLabs
        | IssuingCardholderAuthorizationControlsBlockedCategories'MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | IssuingCardholderAuthorizationControlsBlockedCategories'MedicalServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'MembershipOrganizations
        | IssuingCardholderAuthorizationControlsBlockedCategories'MensAndBoysClothingAndAccessoriesStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'MensWomensClothingStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'MetalServiceCenters
        | IssuingCardholderAuthorizationControlsBlockedCategories'Miscellaneous
        | IssuingCardholderAuthorizationControlsBlockedCategories'MiscellaneousApparelAndAccessoryShops
        | IssuingCardholderAuthorizationControlsBlockedCategories'MiscellaneousAutoDealers
        | IssuingCardholderAuthorizationControlsBlockedCategories'MiscellaneousBusinessServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'MiscellaneousFoodStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'MiscellaneousGeneralMerchandise
        | IssuingCardholderAuthorizationControlsBlockedCategories'MiscellaneousGeneralServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'MiscellaneousHomeFurnishingSpecialtyStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'MiscellaneousPublishingAndPrinting
        | IssuingCardholderAuthorizationControlsBlockedCategories'MiscellaneousRecreationServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'MiscellaneousRepairShops
        | IssuingCardholderAuthorizationControlsBlockedCategories'MiscellaneousSpecialtyRetail
        | IssuingCardholderAuthorizationControlsBlockedCategories'MobileHomeDealers
        | IssuingCardholderAuthorizationControlsBlockedCategories'MotionPictureTheaters
        | IssuingCardholderAuthorizationControlsBlockedCategories'MotorFreightCarriersAndTrucking
        | IssuingCardholderAuthorizationControlsBlockedCategories'MotorHomesDealers
        | IssuingCardholderAuthorizationControlsBlockedCategories'MotorVehicleSuppliesAndNewParts
        | IssuingCardholderAuthorizationControlsBlockedCategories'MotorcycleShopsAndDealers
        | IssuingCardholderAuthorizationControlsBlockedCategories'MotorcycleShopsDealers
        | IssuingCardholderAuthorizationControlsBlockedCategories'MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | IssuingCardholderAuthorizationControlsBlockedCategories'NewsDealersAndNewsstands
        | IssuingCardholderAuthorizationControlsBlockedCategories'NonFiMoneyOrders
        | IssuingCardholderAuthorizationControlsBlockedCategories'NonFiStoredValueCardPurchaseLoad
        | IssuingCardholderAuthorizationControlsBlockedCategories'NondurableGoods
        | IssuingCardholderAuthorizationControlsBlockedCategories'NurseriesLawnAndGardenSupplyStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'NursingPersonalCare
        | IssuingCardholderAuthorizationControlsBlockedCategories'OfficeAndCommercialFurniture
        | IssuingCardholderAuthorizationControlsBlockedCategories'OpticiansEyeglasses
        | IssuingCardholderAuthorizationControlsBlockedCategories'OptometristsOphthalmologist
        | IssuingCardholderAuthorizationControlsBlockedCategories'OrthopedicGoodsProstheticDevices
        | IssuingCardholderAuthorizationControlsBlockedCategories'Osteopaths
        | IssuingCardholderAuthorizationControlsBlockedCategories'PackageStoresBeerWineAndLiquor
        | IssuingCardholderAuthorizationControlsBlockedCategories'PaintsVarnishesAndSupplies
        | IssuingCardholderAuthorizationControlsBlockedCategories'ParkingLotsGarages
        | IssuingCardholderAuthorizationControlsBlockedCategories'PassengerRailways
        | IssuingCardholderAuthorizationControlsBlockedCategories'PawnShops
        | IssuingCardholderAuthorizationControlsBlockedCategories'PetShopsPetFoodAndSupplies
        | IssuingCardholderAuthorizationControlsBlockedCategories'PetroleumAndPetroleumProducts
        | IssuingCardholderAuthorizationControlsBlockedCategories'PhotoDeveloping
        | IssuingCardholderAuthorizationControlsBlockedCategories'PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | IssuingCardholderAuthorizationControlsBlockedCategories'PhotographicStudios
        | IssuingCardholderAuthorizationControlsBlockedCategories'PictureVideoProduction
        | IssuingCardholderAuthorizationControlsBlockedCategories'PieceGoodsNotionsAndOtherDryGoods
        | IssuingCardholderAuthorizationControlsBlockedCategories'PlumbingHeatingEquipmentAndSupplies
        | IssuingCardholderAuthorizationControlsBlockedCategories'PoliticalOrganizations
        | IssuingCardholderAuthorizationControlsBlockedCategories'PostalServicesGovernmentOnly
        | IssuingCardholderAuthorizationControlsBlockedCategories'PreciousStonesAndMetalsWatchesAndJewelry
        | IssuingCardholderAuthorizationControlsBlockedCategories'ProfessionalServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'PublicWarehousingAndStorage
        | IssuingCardholderAuthorizationControlsBlockedCategories'QuickCopyReproAndBlueprint
        | IssuingCardholderAuthorizationControlsBlockedCategories'Railroads
        | IssuingCardholderAuthorizationControlsBlockedCategories'RealEstateAgentsAndManagersRentals
        | IssuingCardholderAuthorizationControlsBlockedCategories'RecordStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'RecreationalVehicleRentals
        | IssuingCardholderAuthorizationControlsBlockedCategories'ReligiousGoodsStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'ReligiousOrganizations
        | IssuingCardholderAuthorizationControlsBlockedCategories'RoofingSidingSheetMetal
        | IssuingCardholderAuthorizationControlsBlockedCategories'SecretarialSupportServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'SecurityBrokersDealers
        | IssuingCardholderAuthorizationControlsBlockedCategories'ServiceStations
        | IssuingCardholderAuthorizationControlsBlockedCategories'SewingNeedleworkFabricAndPieceGoodsStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'ShoeRepairHatCleaning
        | IssuingCardholderAuthorizationControlsBlockedCategories'ShoeStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'SmallApplianceRepair
        | IssuingCardholderAuthorizationControlsBlockedCategories'SnowmobileDealers
        | IssuingCardholderAuthorizationControlsBlockedCategories'SpecialTradeServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'SpecialtyCleaning
        | IssuingCardholderAuthorizationControlsBlockedCategories'SportingGoodsStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'SportingRecreationCamps
        | IssuingCardholderAuthorizationControlsBlockedCategories'SportsAndRidingApparelStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'SportsClubsFields
        | IssuingCardholderAuthorizationControlsBlockedCategories'StampAndCoinStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'StationaryOfficeSuppliesPrintingAndWritingPaper
        | IssuingCardholderAuthorizationControlsBlockedCategories'StationeryStoresOfficeAndSchoolSupplyStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'SwimmingPoolsSales
        | IssuingCardholderAuthorizationControlsBlockedCategories'TUiTravelGermany
        | IssuingCardholderAuthorizationControlsBlockedCategories'TailorsAlterations
        | IssuingCardholderAuthorizationControlsBlockedCategories'TaxPaymentsGovernmentAgencies
        | IssuingCardholderAuthorizationControlsBlockedCategories'TaxPreparationServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'TaxicabsLimousines
        | IssuingCardholderAuthorizationControlsBlockedCategories'TelecommunicationEquipmentAndTelephoneSales
        | IssuingCardholderAuthorizationControlsBlockedCategories'TelecommunicationServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'TelegraphServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'TentAndAwningShops
        | IssuingCardholderAuthorizationControlsBlockedCategories'TestingLaboratories
        | IssuingCardholderAuthorizationControlsBlockedCategories'TheatricalTicketAgencies
        | IssuingCardholderAuthorizationControlsBlockedCategories'Timeshares
        | IssuingCardholderAuthorizationControlsBlockedCategories'TireRetreadingAndRepair
        | IssuingCardholderAuthorizationControlsBlockedCategories'TollsBridgeFees
        | IssuingCardholderAuthorizationControlsBlockedCategories'TouristAttractionsAndExhibits
        | IssuingCardholderAuthorizationControlsBlockedCategories'TowingServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'TrailerParksCampgrounds
        | IssuingCardholderAuthorizationControlsBlockedCategories'TransportationServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'TravelAgenciesTourOperators
        | IssuingCardholderAuthorizationControlsBlockedCategories'TruckStopIteration
        | IssuingCardholderAuthorizationControlsBlockedCategories'TruckUtilityTrailerRentals
        | IssuingCardholderAuthorizationControlsBlockedCategories'TypesettingPlateMakingAndRelatedServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'TypewriterStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'USFederalGovernmentAgenciesOrDepartments
        | IssuingCardholderAuthorizationControlsBlockedCategories'UniformsCommercialClothing
        | IssuingCardholderAuthorizationControlsBlockedCategories'UsedMerchandiseAndSecondhandStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'Utilities
        | IssuingCardholderAuthorizationControlsBlockedCategories'VarietyStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'VeterinaryServices
        | IssuingCardholderAuthorizationControlsBlockedCategories'VideoAmusementGameSupplies
        | IssuingCardholderAuthorizationControlsBlockedCategories'VideoGameArcades
        | IssuingCardholderAuthorizationControlsBlockedCategories'VideoTapeRentalStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'VocationalTradeSchools
        | IssuingCardholderAuthorizationControlsBlockedCategories'WatchJewelryRepair
        | IssuingCardholderAuthorizationControlsBlockedCategories'WeldingRepair
        | IssuingCardholderAuthorizationControlsBlockedCategories'WholesaleClubs
        | IssuingCardholderAuthorizationControlsBlockedCategories'WigAndToupeeStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'WiresMoneyOrders
        | IssuingCardholderAuthorizationControlsBlockedCategories'WomensAccessoryAndSpecialtyShops
        | IssuingCardholderAuthorizationControlsBlockedCategories'WomensReadyToWearStores
        | IssuingCardholderAuthorizationControlsBlockedCategories'WreckingAndSalvageYards

    ///
    and IssuingCardholderCompany (taxIdProvided: bool) =

        member _.TaxIdProvided = taxIdProvided

    ///
    and IssuingCardholderIdDocument (back: IssuingCardholderIdDocumentBackDU option, front: IssuingCardholderIdDocumentFrontDU option) =

        member _.Back = back
        member _.Front = front

    and IssuingCardholderIdDocumentBackDU =
        | IssuingCardholderIdDocumentBackDU'String of string
        | IssuingCardholderIdDocumentBackDU'File of File

    and IssuingCardholderIdDocumentFrontDU =
        | IssuingCardholderIdDocumentFrontDU'String of string
        | IssuingCardholderIdDocumentFrontDU'File of File

    ///
    and IssuingCardholderIndividual (dob: IssuingCardholderIndividualDob option, firstName: string, lastName: string, verification: IssuingCardholderVerification option) =

        member _.Dob = dob
        member _.FirstName = firstName
        member _.LastName = lastName
        member _.Verification = verification

    ///
    and IssuingCardholderIndividualDob (day: int option, month: int option, year: int option) =

        member _.Day = day
        member _.Month = month
        member _.Year = year

    ///
    and IssuingCardholderRequirements (disabledReason: IssuingCardholderRequirementsDisabledReason option, pastDue: IssuingCardholderRequirementsPastDue list option) =

        member _.DisabledReason = disabledReason
        member _.PastDue = pastDue

    and IssuingCardholderRequirementsDisabledReason =
        | IssuingCardholderRequirementsDisabledReason'Listed
        | IssuingCardholderRequirementsDisabledReason'RejectedListed
        | IssuingCardholderRequirementsDisabledReason'UnderReview

    and IssuingCardholderRequirementsPastDue =
        | IssuingCardholderRequirementsPastDue'CompanyTaxId
        | IssuingCardholderRequirementsPastDue'IndividualDobDay
        | IssuingCardholderRequirementsPastDue'IndividualDobMonth
        | IssuingCardholderRequirementsPastDue'IndividualDobYear
        | IssuingCardholderRequirementsPastDue'IndividualFirstName
        | IssuingCardholderRequirementsPastDue'IndividualLastName
        | IssuingCardholderRequirementsPastDue'IndividualVerificationDocument

    ///
    and IssuingCardholderSpendingLimit (amount: int, categories: IssuingCardholderSpendingLimitCategories list option, interval: IssuingCardholderSpendingLimitInterval) =

        member _.Amount = amount
        member _.Categories = categories
        member _.Interval = interval

    and IssuingCardholderSpendingLimitCategories =
        | IssuingCardholderSpendingLimitCategories'AcRefrigerationRepair
        | IssuingCardholderSpendingLimitCategories'AccountingBookkeepingServices
        | IssuingCardholderSpendingLimitCategories'AdvertisingServices
        | IssuingCardholderSpendingLimitCategories'AgriculturalCooperative
        | IssuingCardholderSpendingLimitCategories'AirlinesAirCarriers
        | IssuingCardholderSpendingLimitCategories'AirportsFlyingFields
        | IssuingCardholderSpendingLimitCategories'AmbulanceServices
        | IssuingCardholderSpendingLimitCategories'AmusementParksCarnivals
        | IssuingCardholderSpendingLimitCategories'AntiqueReproductions
        | IssuingCardholderSpendingLimitCategories'AntiqueShops
        | IssuingCardholderSpendingLimitCategories'Aquariums
        | IssuingCardholderSpendingLimitCategories'ArchitecturalSurveyingServices
        | IssuingCardholderSpendingLimitCategories'ArtDealersAndGalleries
        | IssuingCardholderSpendingLimitCategories'ArtistsSupplyAndCraftShops
        | IssuingCardholderSpendingLimitCategories'AutoAndHomeSupplyStores
        | IssuingCardholderSpendingLimitCategories'AutoBodyRepairShops
        | IssuingCardholderSpendingLimitCategories'AutoPaintShops
        | IssuingCardholderSpendingLimitCategories'AutoServiceShops
        | IssuingCardholderSpendingLimitCategories'AutomatedCashDisburse
        | IssuingCardholderSpendingLimitCategories'AutomatedFuelDispensers
        | IssuingCardholderSpendingLimitCategories'AutomobileAssociations
        | IssuingCardholderSpendingLimitCategories'AutomotivePartsAndAccessoriesStores
        | IssuingCardholderSpendingLimitCategories'AutomotiveTireStores
        | IssuingCardholderSpendingLimitCategories'BailAndBondPayments
        | IssuingCardholderSpendingLimitCategories'Bakeries
        | IssuingCardholderSpendingLimitCategories'BandsOrchestras
        | IssuingCardholderSpendingLimitCategories'BarberAndBeautyShops
        | IssuingCardholderSpendingLimitCategories'BettingCasinoGambling
        | IssuingCardholderSpendingLimitCategories'BicycleShops
        | IssuingCardholderSpendingLimitCategories'BilliardPoolEstablishments
        | IssuingCardholderSpendingLimitCategories'BoatDealers
        | IssuingCardholderSpendingLimitCategories'BoatRentalsAndLeases
        | IssuingCardholderSpendingLimitCategories'BookStores
        | IssuingCardholderSpendingLimitCategories'BooksPeriodicalsAndNewspapers
        | IssuingCardholderSpendingLimitCategories'BowlingAlleys
        | IssuingCardholderSpendingLimitCategories'BusLines
        | IssuingCardholderSpendingLimitCategories'BusinessSecretarialSchools
        | IssuingCardholderSpendingLimitCategories'BuyingShoppingServices
        | IssuingCardholderSpendingLimitCategories'CableSatelliteAndOtherPayTelevisionAndRadio
        | IssuingCardholderSpendingLimitCategories'CameraAndPhotographicSupplyStores
        | IssuingCardholderSpendingLimitCategories'CandyNutAndConfectioneryStores
        | IssuingCardholderSpendingLimitCategories'CarAndTruckDealersNewUsed
        | IssuingCardholderSpendingLimitCategories'CarAndTruckDealersUsedOnly
        | IssuingCardholderSpendingLimitCategories'CarRentalAgencies
        | IssuingCardholderSpendingLimitCategories'CarWashes
        | IssuingCardholderSpendingLimitCategories'CarpentryServices
        | IssuingCardholderSpendingLimitCategories'CarpetUpholsteryCleaning
        | IssuingCardholderSpendingLimitCategories'Caterers
        | IssuingCardholderSpendingLimitCategories'CharitableAndSocialServiceOrganizationsFundraising
        | IssuingCardholderSpendingLimitCategories'ChemicalsAndAlliedProducts
        | IssuingCardholderSpendingLimitCategories'ChildCareServices
        | IssuingCardholderSpendingLimitCategories'ChildrensAndInfantsWearStores
        | IssuingCardholderSpendingLimitCategories'ChiropodistsPodiatrists
        | IssuingCardholderSpendingLimitCategories'Chiropractors
        | IssuingCardholderSpendingLimitCategories'CigarStoresAndStands
        | IssuingCardholderSpendingLimitCategories'CivicSocialFraternalAssociations
        | IssuingCardholderSpendingLimitCategories'CleaningAndMaintenance
        | IssuingCardholderSpendingLimitCategories'ClothingRental
        | IssuingCardholderSpendingLimitCategories'CollegesUniversities
        | IssuingCardholderSpendingLimitCategories'CommercialEquipment
        | IssuingCardholderSpendingLimitCategories'CommercialFootwear
        | IssuingCardholderSpendingLimitCategories'CommercialPhotographyArtAndGraphics
        | IssuingCardholderSpendingLimitCategories'CommuterTransportAndFerries
        | IssuingCardholderSpendingLimitCategories'ComputerNetworkServices
        | IssuingCardholderSpendingLimitCategories'ComputerProgramming
        | IssuingCardholderSpendingLimitCategories'ComputerRepair
        | IssuingCardholderSpendingLimitCategories'ComputerSoftwareStores
        | IssuingCardholderSpendingLimitCategories'ComputersPeripheralsAndSoftware
        | IssuingCardholderSpendingLimitCategories'ConcreteWorkServices
        | IssuingCardholderSpendingLimitCategories'ConstructionMaterials
        | IssuingCardholderSpendingLimitCategories'ConsultingPublicRelations
        | IssuingCardholderSpendingLimitCategories'CorrespondenceSchools
        | IssuingCardholderSpendingLimitCategories'CosmeticStores
        | IssuingCardholderSpendingLimitCategories'CounselingServices
        | IssuingCardholderSpendingLimitCategories'CountryClubs
        | IssuingCardholderSpendingLimitCategories'CourierServices
        | IssuingCardholderSpendingLimitCategories'CourtCosts
        | IssuingCardholderSpendingLimitCategories'CreditReportingAgencies
        | IssuingCardholderSpendingLimitCategories'CruiseLines
        | IssuingCardholderSpendingLimitCategories'DairyProductsStores
        | IssuingCardholderSpendingLimitCategories'DanceHallStudiosSchools
        | IssuingCardholderSpendingLimitCategories'DatingEscortServices
        | IssuingCardholderSpendingLimitCategories'DentistsOrthodontists
        | IssuingCardholderSpendingLimitCategories'DepartmentStores
        | IssuingCardholderSpendingLimitCategories'DetectiveAgencies
        | IssuingCardholderSpendingLimitCategories'DigitalGoodsApplications
        | IssuingCardholderSpendingLimitCategories'DigitalGoodsGames
        | IssuingCardholderSpendingLimitCategories'DigitalGoodsLargeVolume
        | IssuingCardholderSpendingLimitCategories'DigitalGoodsMedia
        | IssuingCardholderSpendingLimitCategories'DirectMarketingCatalogMerchant
        | IssuingCardholderSpendingLimitCategories'DirectMarketingCombinationCatalogAndRetailMerchant
        | IssuingCardholderSpendingLimitCategories'DirectMarketingInboundTelemarketing
        | IssuingCardholderSpendingLimitCategories'DirectMarketingInsuranceServices
        | IssuingCardholderSpendingLimitCategories'DirectMarketingOther
        | IssuingCardholderSpendingLimitCategories'DirectMarketingOutboundTelemarketing
        | IssuingCardholderSpendingLimitCategories'DirectMarketingSubscription
        | IssuingCardholderSpendingLimitCategories'DirectMarketingTravel
        | IssuingCardholderSpendingLimitCategories'DiscountStores
        | IssuingCardholderSpendingLimitCategories'Doctors
        | IssuingCardholderSpendingLimitCategories'DoorToDoorSales
        | IssuingCardholderSpendingLimitCategories'DraperyWindowCoveringAndUpholsteryStores
        | IssuingCardholderSpendingLimitCategories'DrinkingPlaces
        | IssuingCardholderSpendingLimitCategories'DrugStoresAndPharmacies
        | IssuingCardholderSpendingLimitCategories'DrugsDrugProprietariesAndDruggistSundries
        | IssuingCardholderSpendingLimitCategories'DryCleaners
        | IssuingCardholderSpendingLimitCategories'DurableGoods
        | IssuingCardholderSpendingLimitCategories'DutyFreeStores
        | IssuingCardholderSpendingLimitCategories'EatingPlacesRestaurants
        | IssuingCardholderSpendingLimitCategories'EducationalServices
        | IssuingCardholderSpendingLimitCategories'ElectricRazorStores
        | IssuingCardholderSpendingLimitCategories'ElectricalPartsAndEquipment
        | IssuingCardholderSpendingLimitCategories'ElectricalServices
        | IssuingCardholderSpendingLimitCategories'ElectronicsRepairShops
        | IssuingCardholderSpendingLimitCategories'ElectronicsStores
        | IssuingCardholderSpendingLimitCategories'ElementarySecondarySchools
        | IssuingCardholderSpendingLimitCategories'EmploymentTempAgencies
        | IssuingCardholderSpendingLimitCategories'EquipmentRental
        | IssuingCardholderSpendingLimitCategories'ExterminatingServices
        | IssuingCardholderSpendingLimitCategories'FamilyClothingStores
        | IssuingCardholderSpendingLimitCategories'FastFoodRestaurants
        | IssuingCardholderSpendingLimitCategories'FinancialInstitutions
        | IssuingCardholderSpendingLimitCategories'FinesGovernmentAdministrativeEntities
        | IssuingCardholderSpendingLimitCategories'FireplaceFireplaceScreensAndAccessoriesStores
        | IssuingCardholderSpendingLimitCategories'FloorCoveringStores
        | IssuingCardholderSpendingLimitCategories'Florists
        | IssuingCardholderSpendingLimitCategories'FloristsSuppliesNurseryStockAndFlowers
        | IssuingCardholderSpendingLimitCategories'FreezerAndLockerMeatProvisioners
        | IssuingCardholderSpendingLimitCategories'FuelDealersNonAutomotive
        | IssuingCardholderSpendingLimitCategories'FuneralServicesCrematories
        | IssuingCardholderSpendingLimitCategories'FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | IssuingCardholderSpendingLimitCategories'FurnitureRepairRefinishing
        | IssuingCardholderSpendingLimitCategories'FurriersAndFurShops
        | IssuingCardholderSpendingLimitCategories'GeneralServices
        | IssuingCardholderSpendingLimitCategories'GiftCardNoveltyAndSouvenirShops
        | IssuingCardholderSpendingLimitCategories'GlassPaintAndWallpaperStores
        | IssuingCardholderSpendingLimitCategories'GlasswareCrystalStores
        | IssuingCardholderSpendingLimitCategories'GolfCoursesPublic
        | IssuingCardholderSpendingLimitCategories'GovernmentServices
        | IssuingCardholderSpendingLimitCategories'GroceryStoresSupermarkets
        | IssuingCardholderSpendingLimitCategories'HardwareEquipmentAndSupplies
        | IssuingCardholderSpendingLimitCategories'HardwareStores
        | IssuingCardholderSpendingLimitCategories'HealthAndBeautySpas
        | IssuingCardholderSpendingLimitCategories'HearingAidsSalesAndSupplies
        | IssuingCardholderSpendingLimitCategories'HeatingPlumbingAC
        | IssuingCardholderSpendingLimitCategories'HobbyToyAndGameShops
        | IssuingCardholderSpendingLimitCategories'HomeSupplyWarehouseStores
        | IssuingCardholderSpendingLimitCategories'Hospitals
        | IssuingCardholderSpendingLimitCategories'HotelsMotelsAndResorts
        | IssuingCardholderSpendingLimitCategories'HouseholdApplianceStores
        | IssuingCardholderSpendingLimitCategories'IndustrialSupplies
        | IssuingCardholderSpendingLimitCategories'InformationRetrievalServices
        | IssuingCardholderSpendingLimitCategories'InsuranceDefault
        | IssuingCardholderSpendingLimitCategories'InsuranceUnderwritingPremiums
        | IssuingCardholderSpendingLimitCategories'IntraCompanyPurchases
        | IssuingCardholderSpendingLimitCategories'JewelryStoresWatchesClocksAndSilverwareStores
        | IssuingCardholderSpendingLimitCategories'LandscapingServices
        | IssuingCardholderSpendingLimitCategories'Laundries
        | IssuingCardholderSpendingLimitCategories'LaundryCleaningServices
        | IssuingCardholderSpendingLimitCategories'LegalServicesAttorneys
        | IssuingCardholderSpendingLimitCategories'LuggageAndLeatherGoodsStores
        | IssuingCardholderSpendingLimitCategories'LumberBuildingMaterialsStores
        | IssuingCardholderSpendingLimitCategories'ManualCashDisburse
        | IssuingCardholderSpendingLimitCategories'MarinasServiceAndSupplies
        | IssuingCardholderSpendingLimitCategories'MasonryStoneworkAndPlaster
        | IssuingCardholderSpendingLimitCategories'MassageParlors
        | IssuingCardholderSpendingLimitCategories'MedicalAndDentalLabs
        | IssuingCardholderSpendingLimitCategories'MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | IssuingCardholderSpendingLimitCategories'MedicalServices
        | IssuingCardholderSpendingLimitCategories'MembershipOrganizations
        | IssuingCardholderSpendingLimitCategories'MensAndBoysClothingAndAccessoriesStores
        | IssuingCardholderSpendingLimitCategories'MensWomensClothingStores
        | IssuingCardholderSpendingLimitCategories'MetalServiceCenters
        | IssuingCardholderSpendingLimitCategories'Miscellaneous
        | IssuingCardholderSpendingLimitCategories'MiscellaneousApparelAndAccessoryShops
        | IssuingCardholderSpendingLimitCategories'MiscellaneousAutoDealers
        | IssuingCardholderSpendingLimitCategories'MiscellaneousBusinessServices
        | IssuingCardholderSpendingLimitCategories'MiscellaneousFoodStores
        | IssuingCardholderSpendingLimitCategories'MiscellaneousGeneralMerchandise
        | IssuingCardholderSpendingLimitCategories'MiscellaneousGeneralServices
        | IssuingCardholderSpendingLimitCategories'MiscellaneousHomeFurnishingSpecialtyStores
        | IssuingCardholderSpendingLimitCategories'MiscellaneousPublishingAndPrinting
        | IssuingCardholderSpendingLimitCategories'MiscellaneousRecreationServices
        | IssuingCardholderSpendingLimitCategories'MiscellaneousRepairShops
        | IssuingCardholderSpendingLimitCategories'MiscellaneousSpecialtyRetail
        | IssuingCardholderSpendingLimitCategories'MobileHomeDealers
        | IssuingCardholderSpendingLimitCategories'MotionPictureTheaters
        | IssuingCardholderSpendingLimitCategories'MotorFreightCarriersAndTrucking
        | IssuingCardholderSpendingLimitCategories'MotorHomesDealers
        | IssuingCardholderSpendingLimitCategories'MotorVehicleSuppliesAndNewParts
        | IssuingCardholderSpendingLimitCategories'MotorcycleShopsAndDealers
        | IssuingCardholderSpendingLimitCategories'MotorcycleShopsDealers
        | IssuingCardholderSpendingLimitCategories'MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | IssuingCardholderSpendingLimitCategories'NewsDealersAndNewsstands
        | IssuingCardholderSpendingLimitCategories'NonFiMoneyOrders
        | IssuingCardholderSpendingLimitCategories'NonFiStoredValueCardPurchaseLoad
        | IssuingCardholderSpendingLimitCategories'NondurableGoods
        | IssuingCardholderSpendingLimitCategories'NurseriesLawnAndGardenSupplyStores
        | IssuingCardholderSpendingLimitCategories'NursingPersonalCare
        | IssuingCardholderSpendingLimitCategories'OfficeAndCommercialFurniture
        | IssuingCardholderSpendingLimitCategories'OpticiansEyeglasses
        | IssuingCardholderSpendingLimitCategories'OptometristsOphthalmologist
        | IssuingCardholderSpendingLimitCategories'OrthopedicGoodsProstheticDevices
        | IssuingCardholderSpendingLimitCategories'Osteopaths
        | IssuingCardholderSpendingLimitCategories'PackageStoresBeerWineAndLiquor
        | IssuingCardholderSpendingLimitCategories'PaintsVarnishesAndSupplies
        | IssuingCardholderSpendingLimitCategories'ParkingLotsGarages
        | IssuingCardholderSpendingLimitCategories'PassengerRailways
        | IssuingCardholderSpendingLimitCategories'PawnShops
        | IssuingCardholderSpendingLimitCategories'PetShopsPetFoodAndSupplies
        | IssuingCardholderSpendingLimitCategories'PetroleumAndPetroleumProducts
        | IssuingCardholderSpendingLimitCategories'PhotoDeveloping
        | IssuingCardholderSpendingLimitCategories'PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | IssuingCardholderSpendingLimitCategories'PhotographicStudios
        | IssuingCardholderSpendingLimitCategories'PictureVideoProduction
        | IssuingCardholderSpendingLimitCategories'PieceGoodsNotionsAndOtherDryGoods
        | IssuingCardholderSpendingLimitCategories'PlumbingHeatingEquipmentAndSupplies
        | IssuingCardholderSpendingLimitCategories'PoliticalOrganizations
        | IssuingCardholderSpendingLimitCategories'PostalServicesGovernmentOnly
        | IssuingCardholderSpendingLimitCategories'PreciousStonesAndMetalsWatchesAndJewelry
        | IssuingCardholderSpendingLimitCategories'ProfessionalServices
        | IssuingCardholderSpendingLimitCategories'PublicWarehousingAndStorage
        | IssuingCardholderSpendingLimitCategories'QuickCopyReproAndBlueprint
        | IssuingCardholderSpendingLimitCategories'Railroads
        | IssuingCardholderSpendingLimitCategories'RealEstateAgentsAndManagersRentals
        | IssuingCardholderSpendingLimitCategories'RecordStores
        | IssuingCardholderSpendingLimitCategories'RecreationalVehicleRentals
        | IssuingCardholderSpendingLimitCategories'ReligiousGoodsStores
        | IssuingCardholderSpendingLimitCategories'ReligiousOrganizations
        | IssuingCardholderSpendingLimitCategories'RoofingSidingSheetMetal
        | IssuingCardholderSpendingLimitCategories'SecretarialSupportServices
        | IssuingCardholderSpendingLimitCategories'SecurityBrokersDealers
        | IssuingCardholderSpendingLimitCategories'ServiceStations
        | IssuingCardholderSpendingLimitCategories'SewingNeedleworkFabricAndPieceGoodsStores
        | IssuingCardholderSpendingLimitCategories'ShoeRepairHatCleaning
        | IssuingCardholderSpendingLimitCategories'ShoeStores
        | IssuingCardholderSpendingLimitCategories'SmallApplianceRepair
        | IssuingCardholderSpendingLimitCategories'SnowmobileDealers
        | IssuingCardholderSpendingLimitCategories'SpecialTradeServices
        | IssuingCardholderSpendingLimitCategories'SpecialtyCleaning
        | IssuingCardholderSpendingLimitCategories'SportingGoodsStores
        | IssuingCardholderSpendingLimitCategories'SportingRecreationCamps
        | IssuingCardholderSpendingLimitCategories'SportsAndRidingApparelStores
        | IssuingCardholderSpendingLimitCategories'SportsClubsFields
        | IssuingCardholderSpendingLimitCategories'StampAndCoinStores
        | IssuingCardholderSpendingLimitCategories'StationaryOfficeSuppliesPrintingAndWritingPaper
        | IssuingCardholderSpendingLimitCategories'StationeryStoresOfficeAndSchoolSupplyStores
        | IssuingCardholderSpendingLimitCategories'SwimmingPoolsSales
        | IssuingCardholderSpendingLimitCategories'TUiTravelGermany
        | IssuingCardholderSpendingLimitCategories'TailorsAlterations
        | IssuingCardholderSpendingLimitCategories'TaxPaymentsGovernmentAgencies
        | IssuingCardholderSpendingLimitCategories'TaxPreparationServices
        | IssuingCardholderSpendingLimitCategories'TaxicabsLimousines
        | IssuingCardholderSpendingLimitCategories'TelecommunicationEquipmentAndTelephoneSales
        | IssuingCardholderSpendingLimitCategories'TelecommunicationServices
        | IssuingCardholderSpendingLimitCategories'TelegraphServices
        | IssuingCardholderSpendingLimitCategories'TentAndAwningShops
        | IssuingCardholderSpendingLimitCategories'TestingLaboratories
        | IssuingCardholderSpendingLimitCategories'TheatricalTicketAgencies
        | IssuingCardholderSpendingLimitCategories'Timeshares
        | IssuingCardholderSpendingLimitCategories'TireRetreadingAndRepair
        | IssuingCardholderSpendingLimitCategories'TollsBridgeFees
        | IssuingCardholderSpendingLimitCategories'TouristAttractionsAndExhibits
        | IssuingCardholderSpendingLimitCategories'TowingServices
        | IssuingCardholderSpendingLimitCategories'TrailerParksCampgrounds
        | IssuingCardholderSpendingLimitCategories'TransportationServices
        | IssuingCardholderSpendingLimitCategories'TravelAgenciesTourOperators
        | IssuingCardholderSpendingLimitCategories'TruckStopIteration
        | IssuingCardholderSpendingLimitCategories'TruckUtilityTrailerRentals
        | IssuingCardholderSpendingLimitCategories'TypesettingPlateMakingAndRelatedServices
        | IssuingCardholderSpendingLimitCategories'TypewriterStores
        | IssuingCardholderSpendingLimitCategories'USFederalGovernmentAgenciesOrDepartments
        | IssuingCardholderSpendingLimitCategories'UniformsCommercialClothing
        | IssuingCardholderSpendingLimitCategories'UsedMerchandiseAndSecondhandStores
        | IssuingCardholderSpendingLimitCategories'Utilities
        | IssuingCardholderSpendingLimitCategories'VarietyStores
        | IssuingCardholderSpendingLimitCategories'VeterinaryServices
        | IssuingCardholderSpendingLimitCategories'VideoAmusementGameSupplies
        | IssuingCardholderSpendingLimitCategories'VideoGameArcades
        | IssuingCardholderSpendingLimitCategories'VideoTapeRentalStores
        | IssuingCardholderSpendingLimitCategories'VocationalTradeSchools
        | IssuingCardholderSpendingLimitCategories'WatchJewelryRepair
        | IssuingCardholderSpendingLimitCategories'WeldingRepair
        | IssuingCardholderSpendingLimitCategories'WholesaleClubs
        | IssuingCardholderSpendingLimitCategories'WigAndToupeeStores
        | IssuingCardholderSpendingLimitCategories'WiresMoneyOrders
        | IssuingCardholderSpendingLimitCategories'WomensAccessoryAndSpecialtyShops
        | IssuingCardholderSpendingLimitCategories'WomensReadyToWearStores
        | IssuingCardholderSpendingLimitCategories'WreckingAndSalvageYards

    and IssuingCardholderSpendingLimitInterval =
        | IssuingCardholderSpendingLimitInterval'AllTime
        | IssuingCardholderSpendingLimitInterval'Daily
        | IssuingCardholderSpendingLimitInterval'Monthly
        | IssuingCardholderSpendingLimitInterval'PerAuthorization
        | IssuingCardholderSpendingLimitInterval'Weekly
        | IssuingCardholderSpendingLimitInterval'Yearly

    ///
    and IssuingCardholderVerification (document: IssuingCardholderIdDocument option) =

        member _.Document = document

    ///
    and IssuingDisputeCanceledEvidence (additionalDocumentation: IssuingDisputeCanceledEvidenceAdditionalDocumentationDU option, canceledAt: int option, cancellationPolicyProvided: bool option, cancellationReason: string option, expectedAt: int option, explanation: string option, productDescription: string option, productType: IssuingDisputeCanceledEvidenceProductType option, returnStatus: IssuingDisputeCanceledEvidenceReturnStatus option, returnedAt: int option) =

        member _.AdditionalDocumentation = additionalDocumentation
        member _.CanceledAt = canceledAt
        member _.CancellationPolicyProvided = cancellationPolicyProvided
        member _.CancellationReason = cancellationReason
        member _.ExpectedAt = expectedAt
        member _.Explanation = explanation
        member _.ProductDescription = productDescription
        member _.ProductType = productType
        member _.ReturnStatus = returnStatus
        member _.ReturnedAt = returnedAt

    and IssuingDisputeCanceledEvidenceProductType =
        | IssuingDisputeCanceledEvidenceProductType'Merchandise
        | IssuingDisputeCanceledEvidenceProductType'Service

    and IssuingDisputeCanceledEvidenceReturnStatus =
        | IssuingDisputeCanceledEvidenceReturnStatus'MerchantRejected
        | IssuingDisputeCanceledEvidenceReturnStatus'Successful

    and IssuingDisputeCanceledEvidenceAdditionalDocumentationDU =
        | IssuingDisputeCanceledEvidenceAdditionalDocumentationDU'String of string
        | IssuingDisputeCanceledEvidenceAdditionalDocumentationDU'File of File

    ///
    and IssuingDisputeDuplicateEvidence (additionalDocumentation: IssuingDisputeDuplicateEvidenceAdditionalDocumentationDU option, cardStatement: IssuingDisputeDuplicateEvidenceCardStatementDU option, cashReceipt: IssuingDisputeDuplicateEvidenceCashReceiptDU option, checkImage: IssuingDisputeDuplicateEvidenceCheckImageDU option, explanation: string option, originalTransaction: string option) =

        member _.AdditionalDocumentation = additionalDocumentation
        member _.CardStatement = cardStatement
        member _.CashReceipt = cashReceipt
        member _.CheckImage = checkImage
        member _.Explanation = explanation
        member _.OriginalTransaction = originalTransaction

    and IssuingDisputeDuplicateEvidenceAdditionalDocumentationDU =
        | IssuingDisputeDuplicateEvidenceAdditionalDocumentationDU'String of string
        | IssuingDisputeDuplicateEvidenceAdditionalDocumentationDU'File of File

    and IssuingDisputeDuplicateEvidenceCardStatementDU =
        | IssuingDisputeDuplicateEvidenceCardStatementDU'String of string
        | IssuingDisputeDuplicateEvidenceCardStatementDU'File of File

    and IssuingDisputeDuplicateEvidenceCashReceiptDU =
        | IssuingDisputeDuplicateEvidenceCashReceiptDU'String of string
        | IssuingDisputeDuplicateEvidenceCashReceiptDU'File of File

    and IssuingDisputeDuplicateEvidenceCheckImageDU =
        | IssuingDisputeDuplicateEvidenceCheckImageDU'String of string
        | IssuingDisputeDuplicateEvidenceCheckImageDU'File of File

    ///
    and IssuingDisputeEvidence (reason: IssuingDisputeEvidenceReason, ?canceled: IssuingDisputeCanceledEvidence, ?duplicate: IssuingDisputeDuplicateEvidence, ?fraudulent: IssuingDisputeFraudulentEvidence, ?merchandiseNotAsDescribed: IssuingDisputeMerchandiseNotAsDescribedEvidence, ?notReceived: IssuingDisputeNotReceivedEvidence, ?other: IssuingDisputeOtherEvidence, ?serviceNotAsDescribed: IssuingDisputeServiceNotAsDescribedEvidence) =

        member _.Canceled = canceled
        member _.Duplicate = duplicate
        member _.Fraudulent = fraudulent
        member _.MerchandiseNotAsDescribed = merchandiseNotAsDescribed
        member _.NotReceived = notReceived
        member _.Other = other
        member _.Reason = reason
        member _.ServiceNotAsDescribed = serviceNotAsDescribed

    and IssuingDisputeEvidenceReason =
        | IssuingDisputeEvidenceReason'Canceled
        | IssuingDisputeEvidenceReason'Duplicate
        | IssuingDisputeEvidenceReason'Fraudulent
        | IssuingDisputeEvidenceReason'MerchandiseNotAsDescribed
        | IssuingDisputeEvidenceReason'NotReceived
        | IssuingDisputeEvidenceReason'Other
        | IssuingDisputeEvidenceReason'ServiceNotAsDescribed

    ///
    and IssuingDisputeFraudulentEvidence (additionalDocumentation: IssuingDisputeFraudulentEvidenceAdditionalDocumentationDU option, explanation: string option) =

        member _.AdditionalDocumentation = additionalDocumentation
        member _.Explanation = explanation

    and IssuingDisputeFraudulentEvidenceAdditionalDocumentationDU =
        | IssuingDisputeFraudulentEvidenceAdditionalDocumentationDU'String of string
        | IssuingDisputeFraudulentEvidenceAdditionalDocumentationDU'File of File

    ///
    and IssuingDisputeMerchandiseNotAsDescribedEvidence (additionalDocumentation: IssuingDisputeMerchandiseNotAsDescribedEvidenceAdditionalDocumentationDU option, explanation: string option, receivedAt: int option, returnDescription: string option, returnStatus: IssuingDisputeMerchandiseNotAsDescribedEvidenceReturnStatus option, returnedAt: int option) =

        member _.AdditionalDocumentation = additionalDocumentation
        member _.Explanation = explanation
        member _.ReceivedAt = receivedAt
        member _.ReturnDescription = returnDescription
        member _.ReturnStatus = returnStatus
        member _.ReturnedAt = returnedAt

    and IssuingDisputeMerchandiseNotAsDescribedEvidenceReturnStatus =
        | IssuingDisputeMerchandiseNotAsDescribedEvidenceReturnStatus'MerchantRejected
        | IssuingDisputeMerchandiseNotAsDescribedEvidenceReturnStatus'Successful

    and IssuingDisputeMerchandiseNotAsDescribedEvidenceAdditionalDocumentationDU =
        | IssuingDisputeMerchandiseNotAsDescribedEvidenceAdditionalDocumentationDU'String of string
        | IssuingDisputeMerchandiseNotAsDescribedEvidenceAdditionalDocumentationDU'File of File

    ///
    and IssuingDisputeNotReceivedEvidence (additionalDocumentation: IssuingDisputeNotReceivedEvidenceAdditionalDocumentationDU option, expectedAt: int option, explanation: string option, productDescription: string option, productType: IssuingDisputeNotReceivedEvidenceProductType option) =

        member _.AdditionalDocumentation = additionalDocumentation
        member _.ExpectedAt = expectedAt
        member _.Explanation = explanation
        member _.ProductDescription = productDescription
        member _.ProductType = productType

    and IssuingDisputeNotReceivedEvidenceProductType =
        | IssuingDisputeNotReceivedEvidenceProductType'Merchandise
        | IssuingDisputeNotReceivedEvidenceProductType'Service

    and IssuingDisputeNotReceivedEvidenceAdditionalDocumentationDU =
        | IssuingDisputeNotReceivedEvidenceAdditionalDocumentationDU'String of string
        | IssuingDisputeNotReceivedEvidenceAdditionalDocumentationDU'File of File

    ///
    and IssuingDisputeOtherEvidence (additionalDocumentation: IssuingDisputeOtherEvidenceAdditionalDocumentationDU option, explanation: string option, productDescription: string option, productType: IssuingDisputeOtherEvidenceProductType option) =

        member _.AdditionalDocumentation = additionalDocumentation
        member _.Explanation = explanation
        member _.ProductDescription = productDescription
        member _.ProductType = productType

    and IssuingDisputeOtherEvidenceProductType =
        | IssuingDisputeOtherEvidenceProductType'Merchandise
        | IssuingDisputeOtherEvidenceProductType'Service

    and IssuingDisputeOtherEvidenceAdditionalDocumentationDU =
        | IssuingDisputeOtherEvidenceAdditionalDocumentationDU'String of string
        | IssuingDisputeOtherEvidenceAdditionalDocumentationDU'File of File

    ///
    and IssuingDisputeServiceNotAsDescribedEvidence (additionalDocumentation: IssuingDisputeServiceNotAsDescribedEvidenceAdditionalDocumentationDU option, canceledAt: int option, cancellationReason: string option, explanation: string option, receivedAt: int option) =

        member _.AdditionalDocumentation = additionalDocumentation
        member _.CanceledAt = canceledAt
        member _.CancellationReason = cancellationReason
        member _.Explanation = explanation
        member _.ReceivedAt = receivedAt

    and IssuingDisputeServiceNotAsDescribedEvidenceAdditionalDocumentationDU =
        | IssuingDisputeServiceNotAsDescribedEvidenceAdditionalDocumentationDU'String of string
        | IssuingDisputeServiceNotAsDescribedEvidenceAdditionalDocumentationDU'File of File

    ///
    and IssuingTransactionAmountDetails (atmFee: int option) =

        member _.AtmFee = atmFee

    ///
    and IssuingTransactionFlightData (departureAt: int option, passengerName: string option, refundable: bool option, segments: IssuingTransactionFlightDataLeg list option, travelAgency: string option) =

        member _.DepartureAt = departureAt
        member _.PassengerName = passengerName
        member _.Refundable = refundable
        member _.Segments = segments
        member _.TravelAgency = travelAgency

    ///
    and IssuingTransactionFlightDataLeg (arrivalAirportCode: string option, carrier: string option, departureAirportCode: string option, flightNumber: string option, serviceClass: string option, stopoverAllowed: bool option) =

        member _.ArrivalAirportCode = arrivalAirportCode
        member _.Carrier = carrier
        member _.DepartureAirportCode = departureAirportCode
        member _.FlightNumber = flightNumber
        member _.ServiceClass = serviceClass
        member _.StopoverAllowed = stopoverAllowed

    ///
    and IssuingTransactionFuelData (``type``: string, unit: string, unitCostDecimal: string, volumeDecimal: string option) =

        member _.Type = ``type``
        member _.Unit = unit
        member _.UnitCostDecimal = unitCostDecimal
        member _.VolumeDecimal = volumeDecimal

    ///
    and IssuingTransactionLodgingData (checkInAt: int option, nights: int option) =

        member _.CheckInAt = checkInAt
        member _.Nights = nights

    ///
    and IssuingTransactionPurchaseDetails (flight: IssuingTransactionFlightData option, fuel: IssuingTransactionFuelData option, lodging: IssuingTransactionLodgingData option, receipt: IssuingTransactionReceiptData list option, reference: string option) =

        member _.Flight = flight
        member _.Fuel = fuel
        member _.Lodging = lodging
        member _.Receipt = receipt
        member _.Reference = reference

    ///
    and IssuingTransactionReceiptData (description: string option, quantity: decimal option, total: int option, unitCost: int option) =

        member _.Description = description
        member _.Quantity = quantity
        member _.Total = total
        member _.UnitCost = unitCost

    ///A line item.
    and Item (amountSubtotal: int option, amountTotal: int option, currency: string, description: string, id: string, object: ItemObject, price: Price, quantity: int option, ?discounts: LineItemsDiscountAmount list, ?taxes: LineItemsTaxAmount list) =

        member _.AmountSubtotal = amountSubtotal
        member _.AmountTotal = amountTotal
        member _.Currency = currency
        member _.Description = description
        member _.Discounts = discounts
        member _.Id = id
        member _.Object = object
        member _.Price = price
        member _.Quantity = quantity
        member _.Taxes = taxes

    and ItemObject =
        | ItemObject'Item

    ///
    and LegalEntityCompany (name: string option, ?address: Address, ?addressKana: LegalEntityJapanAddress option, ?addressKanji: LegalEntityJapanAddress option, ?directorsProvided: bool, ?executivesProvided: bool, ?nameKana: string option, ?nameKanji: string option, ?ownersProvided: bool, ?phone: string option, ?structure: LegalEntityCompanyStructure, ?taxIdProvided: bool, ?taxIdRegistrar: string, ?vatIdProvided: bool, ?verification: LegalEntityCompanyVerification option) =

        member _.Address = address
        member _.AddressKana = addressKana |> Option.flatten
        member _.AddressKanji = addressKanji |> Option.flatten
        member _.DirectorsProvided = directorsProvided
        member _.ExecutivesProvided = executivesProvided
        member _.Name = name
        member _.NameKana = nameKana |> Option.flatten
        member _.NameKanji = nameKanji |> Option.flatten
        member _.OwnersProvided = ownersProvided
        member _.Phone = phone |> Option.flatten
        member _.Structure = structure
        member _.TaxIdProvided = taxIdProvided
        member _.TaxIdRegistrar = taxIdRegistrar
        member _.VatIdProvided = vatIdProvided
        member _.Verification = verification |> Option.flatten

    and LegalEntityCompanyStructure =
        | LegalEntityCompanyStructure'GovernmentInstrumentality
        | LegalEntityCompanyStructure'GovernmentalUnit
        | LegalEntityCompanyStructure'IncorporatedNonProfit
        | LegalEntityCompanyStructure'LimitedLiabilityPartnership
        | LegalEntityCompanyStructure'MultiMemberLlc
        | LegalEntityCompanyStructure'PrivateCompany
        | LegalEntityCompanyStructure'PrivateCorporation
        | LegalEntityCompanyStructure'PrivatePartnership
        | LegalEntityCompanyStructure'PublicCompany
        | LegalEntityCompanyStructure'PublicCorporation
        | LegalEntityCompanyStructure'PublicPartnership
        | LegalEntityCompanyStructure'SoleProprietorship
        | LegalEntityCompanyStructure'TaxExemptGovernmentInstrumentality
        | LegalEntityCompanyStructure'UnincorporatedAssociation
        | LegalEntityCompanyStructure'UnincorporatedNonProfit

    ///
    and LegalEntityCompanyVerification (document: LegalEntityCompanyVerificationDocument) =

        member _.Document = document

    ///
    and LegalEntityCompanyVerificationDocument (back: LegalEntityCompanyVerificationDocumentBackDU option, details: string option, detailsCode: string option, front: LegalEntityCompanyVerificationDocumentFrontDU option) =

        member _.Back = back
        member _.Details = details
        member _.DetailsCode = detailsCode
        member _.Front = front

    and LegalEntityCompanyVerificationDocumentBackDU =
        | LegalEntityCompanyVerificationDocumentBackDU'String of string
        | LegalEntityCompanyVerificationDocumentBackDU'File of File

    and LegalEntityCompanyVerificationDocumentFrontDU =
        | LegalEntityCompanyVerificationDocumentFrontDU'String of string
        | LegalEntityCompanyVerificationDocumentFrontDU'File of File

    ///
    and LegalEntityDob (day: int option, month: int option, year: int option) =

        member _.Day = day
        member _.Month = month
        member _.Year = year

    ///
    and LegalEntityJapanAddress (city: string option, country: string option, line1: string option, line2: string option, postalCode: string option, state: string option, town: string option) =

        member _.City = city
        member _.Country = country
        member _.Line1 = line1
        member _.Line2 = line2
        member _.PostalCode = postalCode
        member _.State = state
        member _.Town = town

    ///
    and LegalEntityPersonVerification (status: string, ?additionalDocument: LegalEntityPersonVerificationDocument option, ?details: string option, ?detailsCode: string option, ?document: LegalEntityPersonVerificationDocument) =

        member _.AdditionalDocument = additionalDocument |> Option.flatten
        member _.Details = details |> Option.flatten
        member _.DetailsCode = detailsCode |> Option.flatten
        member _.Document = document
        member _.Status = status

    ///
    and LegalEntityPersonVerificationDocument (back: LegalEntityPersonVerificationDocumentBackDU option, details: string option, detailsCode: string option, front: LegalEntityPersonVerificationDocumentFrontDU option) =

        member _.Back = back
        member _.Details = details
        member _.DetailsCode = detailsCode
        member _.Front = front

    and LegalEntityPersonVerificationDocumentBackDU =
        | LegalEntityPersonVerificationDocumentBackDU'String of string
        | LegalEntityPersonVerificationDocumentBackDU'File of File

    and LegalEntityPersonVerificationDocumentFrontDU =
        | LegalEntityPersonVerificationDocumentFrontDU'String of string
        | LegalEntityPersonVerificationDocumentFrontDU'File of File

    ///
    and Level3 (lineItems: Level3LineItems list, merchantReference: string, ?customerReference: string, ?shippingAddressZip: string, ?shippingAmount: int, ?shippingFromZip: string) =

        member _.CustomerReference = customerReference
        member _.LineItems = lineItems
        member _.MerchantReference = merchantReference
        member _.ShippingAddressZip = shippingAddressZip
        member _.ShippingAmount = shippingAmount
        member _.ShippingFromZip = shippingFromZip

    ///
    and Level3LineItems (discountAmount: int option, productCode: string, productDescription: string, quantity: int option, taxAmount: int option, unitCost: int option) =

        member _.DiscountAmount = discountAmount
        member _.ProductCode = productCode
        member _.ProductDescription = productDescription
        member _.Quantity = quantity
        member _.TaxAmount = taxAmount
        member _.UnitCost = unitCost

    ///
    and LineItem (amount: int, currency: string, description: string option, discountAmounts: DiscountsResourceDiscountAmount list option, discountable: bool, discounts: LineItemDiscountsDU list option, id: string, livemode: bool, metadata: Map<string, string>, object: LineItemObject, period: InvoiceLineItemPeriod, plan: Plan option, price: Price option, proration: bool, quantity: int option, subscription: string option, ``type``: LineItemType, ?invoiceItem: string, ?subscriptionItem: string, ?taxAmounts: InvoiceTaxAmount list, ?taxRates: TaxRate list) =

        member _.Amount = amount
        member _.Currency = currency
        member _.Description = description
        member _.DiscountAmounts = discountAmounts
        member _.Discountable = discountable
        member _.Discounts = discounts
        member _.Id = id
        member _.InvoiceItem = invoiceItem
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Object = object
        member _.Period = period
        member _.Plan = plan
        member _.Price = price
        member _.Proration = proration
        member _.Quantity = quantity
        member _.Subscription = subscription
        member _.SubscriptionItem = subscriptionItem
        member _.TaxAmounts = taxAmounts
        member _.TaxRates = taxRates
        member _.Type = ``type``

    and LineItemObject =
        | LineItemObject'LineItem

    and LineItemType =
        | LineItemType'Invoiceitem
        | LineItemType'Subscription

    and LineItemDiscountsDU =
        | LineItemDiscountsDU'String of string
        | LineItemDiscountsDU'Discount of Discount

    ///
    and LineItemsDiscountAmount (amount: int, discount: Discount) =

        member _.Amount = amount
        member _.Discount = discount

    ///
    and LineItemsTaxAmount (amount: int, rate: TaxRate) =

        member _.Amount = amount
        member _.Rate = rate

    ///
    and LoginLink (created: int, object: LoginLinkObject, url: string) =

        member _.Created = created
        member _.Object = object
        member _.Url = url

    and LoginLinkObject =
        | LoginLinkObject'LoginLink

    ///A Mandate is a record of the permission a customer has given you to debit their payment method.
    and Mandate (customerAcceptance: CustomerAcceptance, id: string, livemode: bool, object: MandateObject, paymentMethod: MandatePaymentMethodDU, paymentMethodDetails: MandatePaymentMethodDetails, status: MandateStatus, ``type``: MandateType, ?multiUse: MandateMultiUse, ?singleUse: MandateSingleUse) =

        member _.CustomerAcceptance = customerAcceptance
        member _.Id = id
        member _.Livemode = livemode
        member _.MultiUse = multiUse
        member _.Object = object
        member _.PaymentMethod = paymentMethod
        member _.PaymentMethodDetails = paymentMethodDetails
        member _.SingleUse = singleUse
        member _.Status = status
        member _.Type = ``type``

    and MandateObject =
        | MandateObject'Mandate

    and MandateStatus =
        | MandateStatus'Active
        | MandateStatus'Inactive
        | MandateStatus'Pending

    and MandateType =
        | MandateType'MultiUse
        | MandateType'SingleUse

    and MandatePaymentMethodDU =
        | MandatePaymentMethodDU'String of string
        | MandatePaymentMethodDU'PaymentMethod of PaymentMethod

    ///
    and MandateAuBecsDebit (url: string) =

        member _.Url = url

    ///
    and MandateBacsDebit (networkStatus: MandateBacsDebitNetworkStatus, reference: string, url: string) =

        member _.NetworkStatus = networkStatus
        member _.Reference = reference
        member _.Url = url

    and MandateBacsDebitNetworkStatus =
        | MandateBacsDebitNetworkStatus'Accepted
        | MandateBacsDebitNetworkStatus'Pending
        | MandateBacsDebitNetworkStatus'Refused
        | MandateBacsDebitNetworkStatus'Revoked

    ///
    and MandateMultiUse (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and MandatePaymentMethodDetails (``type``: string, ?auBecsDebit: MandateAuBecsDebit, ?bacsDebit: MandateBacsDebit, ?card: CardMandatePaymentMethodDetails, ?sepaDebit: MandateSepaDebit) =

        member _.AuBecsDebit = auBecsDebit
        member _.BacsDebit = bacsDebit
        member _.Card = card
        member _.SepaDebit = sepaDebit
        member _.Type = ``type``

    ///
    and MandateSepaDebit (reference: string, url: string) =

        member _.Reference = reference
        member _.Url = url

    ///
    and MandateSingleUse (amount: int, currency: string) =

        member _.Amount = amount
        member _.Currency = currency

    ///
    and Networks (available: string list, preferred: string option) =

        member _.Available = available
        member _.Preferred = preferred

    ///
    and NotificationEventData (object: Map<string, string>, ?previousAttributes: Map<string, string>) =

        member _.Object = object
        member _.PreviousAttributes = previousAttributes

    ///
    and NotificationEventRequest (id: string option, idempotencyKey: string option) =

        member _.Id = id
        member _.IdempotencyKey = idempotencyKey

    ///
    and OfflineAcceptance (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and OnlineAcceptance (ipAddress: string option, userAgent: string option) =

        member _.IpAddress = ipAddress
        member _.UserAgent = userAgent

    ///Order objects are created to handle end customers' purchases of previously
    ///defined [products](https://stripe.com/docs/api#products). You can create, retrieve, and pay individual orders, as well
    ///as list all orders. Orders are identified by a unique, random ID.
    ///
    ///Related guide: [Tax, Shipping, and Inventory](https://stripe.com/docs/orders).
    and Order (amount: int, amountReturned: int option, application: string option, applicationFee: int option, charge: OrderChargeDU option, created: int, currency: string, customer: OrderCustomerDU option, email: string option, id: string, items: OrderItem list, livemode: bool, metadata: Map<string, string> option, object: OrderObject, returns: Map<string, string> option, selectedShippingMethod: string option, shipping: Shipping option, shippingMethods: ShippingMethod list option, status: string, statusTransitions: StatusTransitions option, updated: int option, ?externalCouponCode: string, ?upstreamId: string) =

        member _.Amount = amount
        member _.AmountReturned = amountReturned
        member _.Application = application
        member _.ApplicationFee = applicationFee
        member _.Charge = charge
        member _.Created = created
        member _.Currency = currency
        member _.Customer = customer
        member _.Email = email
        member _.ExternalCouponCode = externalCouponCode
        member _.Id = id
        member _.Items = items
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Object = object
        member _.Returns = returns
        member _.SelectedShippingMethod = selectedShippingMethod
        member _.Shipping = shipping
        member _.ShippingMethods = shippingMethods
        member _.Status = status
        member _.StatusTransitions = statusTransitions
        member _.Updated = updated
        member _.UpstreamId = upstreamId

    and OrderObject =
        | OrderObject'Order

    and OrderChargeDU =
        | OrderChargeDU'String of string
        | OrderChargeDU'Charge of Charge

    and OrderCustomerDU =
        | OrderCustomerDU'String of string
        | OrderCustomerDU'Customer of Customer
        | OrderCustomerDU'DeletedCustomer of DeletedCustomer

    ///A representation of the constituent items of any given order. Can be used to
    ///represent [SKUs](https://stripe.com/docs/api#skus), shipping costs, or taxes owed on the order.
    ///
    ///Related guide: [Orders](https://stripe.com/docs/orders/guide).
    and OrderItem (amount: int, currency: string, description: string, object: OrderItemObject, parent: OrderItemParentDU option, quantity: int option, ``type``: string) =

        member _.Amount = amount
        member _.Currency = currency
        member _.Description = description
        member _.Object = object
        member _.Parent = parent
        member _.Quantity = quantity
        member _.Type = ``type``

    and OrderItemObject =
        | OrderItemObject'OrderItem

    and OrderItemParentDU =
        | OrderItemParentDU'String of string
        | OrderItemParentDU'Sku of Sku

    ///A return represents the full or partial return of a number of [order items](https://stripe.com/docs/api#order_items).
    ///Returns always belong to an order, and may optionally contain a refund.
    ///
    ///Related guide: [Handling Returns](https://stripe.com/docs/orders/guide#handling-returns).
    and OrderReturn (amount: int, created: int, currency: string, id: string, items: OrderItem list, livemode: bool, object: OrderReturnObject, order: OrderReturnOrderDU option, refund: OrderReturnRefundDU option) =

        member _.Amount = amount
        member _.Created = created
        member _.Currency = currency
        member _.Id = id
        member _.Items = items
        member _.Livemode = livemode
        member _.Object = object
        member _.Order = order
        member _.Refund = refund

    and OrderReturnObject =
        | OrderReturnObject'OrderReturn

    and OrderReturnOrderDU =
        | OrderReturnOrderDU'String of string
        | OrderReturnOrderDU'Order of Order

    and OrderReturnRefundDU =
        | OrderReturnRefundDU'String of string
        | OrderReturnRefundDU'Refund of Refund

    ///
    and PackageDimensions (height: decimal, length: decimal, weight: decimal, width: decimal) =

        member _.Height = height
        member _.Length = length
        member _.Weight = weight
        member _.Width = width

    ///
    and PaymentFlowsPrivatePaymentMethodsAlipay (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and PaymentFlowsPrivatePaymentMethodsAlipayDetails (fingerprint: string option, transactionId: string option) =

        member _.Fingerprint = fingerprint
        member _.TransactionId = transactionId

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
    and PaymentIntent (amount: int, amountCapturable: int, amountReceived: int, application: PaymentIntentApplicationDU option, applicationFeeAmount: int option, canceledAt: int option, cancellationReason: PaymentIntentCancellationReason option, captureMethod: PaymentIntentCaptureMethod, charges: Map<string, string>, clientSecret: string option, confirmationMethod: PaymentIntentConfirmationMethod, created: int, currency: string, customer: PaymentIntentCustomerDU option, description: string option, id: string, invoice: PaymentIntentInvoiceDU option, lastPaymentError: ApiErrors option, livemode: bool, metadata: Map<string, string>, nextAction: PaymentIntentNextAction option, object: PaymentIntentObject, onBehalfOf: PaymentIntentOnBehalfOfDU option, paymentMethod: PaymentIntentPaymentMethodDU option, paymentMethodOptions: PaymentIntentPaymentMethodOptions option, paymentMethodTypes: string list, receiptEmail: string option, review: PaymentIntentReviewDU option, setupFutureUsage: PaymentIntentSetupFutureUsage option, shipping: Shipping option, source: PaymentIntentSourceDU option, statementDescriptor: string option, statementDescriptorSuffix: string option, status: PaymentIntentStatus, transferData: TransferData option, transferGroup: string option) =

        member _.Amount = amount
        member _.AmountCapturable = amountCapturable
        member _.AmountReceived = amountReceived
        member _.Application = application
        member _.ApplicationFeeAmount = applicationFeeAmount
        member _.CanceledAt = canceledAt
        member _.CancellationReason = cancellationReason
        member _.CaptureMethod = captureMethod
        member _.Charges = charges
        member _.ClientSecret = clientSecret
        member _.ConfirmationMethod = confirmationMethod
        member _.Created = created
        member _.Currency = currency
        member _.Customer = customer
        member _.Description = description
        member _.Id = id
        member _.Invoice = invoice
        member _.LastPaymentError = lastPaymentError
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.NextAction = nextAction
        member _.Object = object
        member _.OnBehalfOf = onBehalfOf
        member _.PaymentMethod = paymentMethod
        member _.PaymentMethodOptions = paymentMethodOptions
        member _.PaymentMethodTypes = paymentMethodTypes
        member _.ReceiptEmail = receiptEmail
        member _.Review = review
        member _.SetupFutureUsage = setupFutureUsage
        member _.Shipping = shipping
        member _.Source = source
        member _.StatementDescriptor = statementDescriptor
        member _.StatementDescriptorSuffix = statementDescriptorSuffix
        member _.Status = status
        member _.TransferData = transferData
        member _.TransferGroup = transferGroup

    and PaymentIntentCancellationReason =
        | PaymentIntentCancellationReason'Abandoned
        | PaymentIntentCancellationReason'Automatic
        | PaymentIntentCancellationReason'Duplicate
        | PaymentIntentCancellationReason'FailedInvoice
        | PaymentIntentCancellationReason'Fraudulent
        | PaymentIntentCancellationReason'RequestedByCustomer
        | PaymentIntentCancellationReason'VoidInvoice

    and PaymentIntentCaptureMethod =
        | PaymentIntentCaptureMethod'Automatic
        | PaymentIntentCaptureMethod'Manual

    and PaymentIntentConfirmationMethod =
        | PaymentIntentConfirmationMethod'Automatic
        | PaymentIntentConfirmationMethod'Manual

    and PaymentIntentObject =
        | PaymentIntentObject'PaymentIntent

    and PaymentIntentSetupFutureUsage =
        | PaymentIntentSetupFutureUsage'OffSession
        | PaymentIntentSetupFutureUsage'OnSession

    and PaymentIntentStatus =
        | PaymentIntentStatus'Canceled
        | PaymentIntentStatus'Processing
        | PaymentIntentStatus'RequiresAction
        | PaymentIntentStatus'RequiresCapture
        | PaymentIntentStatus'RequiresConfirmation
        | PaymentIntentStatus'RequiresPaymentMethod
        | PaymentIntentStatus'Succeeded

    and PaymentIntentApplicationDU =
        | PaymentIntentApplicationDU'String of string
        | PaymentIntentApplicationDU'Application of Application

    and PaymentIntentCustomerDU =
        | PaymentIntentCustomerDU'String of string
        | PaymentIntentCustomerDU'Customer of Customer
        | PaymentIntentCustomerDU'DeletedCustomer of DeletedCustomer

    and PaymentIntentInvoiceDU =
        | PaymentIntentInvoiceDU'String of string
        | PaymentIntentInvoiceDU'Invoice of Invoice

    and PaymentIntentOnBehalfOfDU =
        | PaymentIntentOnBehalfOfDU'String of string
        | PaymentIntentOnBehalfOfDU'Account of Account

    and PaymentIntentPaymentMethodDU =
        | PaymentIntentPaymentMethodDU'String of string
        | PaymentIntentPaymentMethodDU'PaymentMethod of PaymentMethod

    and PaymentIntentReviewDU =
        | PaymentIntentReviewDU'String of string
        | PaymentIntentReviewDU'Review of Review

    and PaymentIntentSourceDU =
        | PaymentIntentSourceDU'String of string
        | PaymentIntentSourceDU'PaymentSource of PaymentSource
        | PaymentIntentSourceDU'DeletedPaymentSource of DeletedPaymentSource

    ///
    and PaymentIntentNextAction (``type``: string, ?alipayHandleRedirect: PaymentIntentNextActionAlipayHandleRedirect, ?oxxoDisplayDetails: PaymentIntentNextActionDisplayOxxoDetails, ?redirectToUrl: PaymentIntentNextActionRedirectToUrl, ?useStripeSdk: Map<string, string>) =

        member _.AlipayHandleRedirect = alipayHandleRedirect
        member _.OxxoDisplayDetails = oxxoDisplayDetails
        member _.RedirectToUrl = redirectToUrl
        member _.Type = ``type``
        member _.UseStripeSdk = useStripeSdk

    ///
    and PaymentIntentNextActionAlipayHandleRedirect (nativeData: string option, nativeUrl: string option, returnUrl: string option, url: string option) =

        member _.NativeData = nativeData
        member _.NativeUrl = nativeUrl
        member _.ReturnUrl = returnUrl
        member _.Url = url

    ///
    and PaymentIntentNextActionDisplayOxxoDetails (expiresAfter: int option, hostedVoucherUrl: string option, number: string option) =

        member _.ExpiresAfter = expiresAfter
        member _.HostedVoucherUrl = hostedVoucherUrl
        member _.Number = number

    ///
    and PaymentIntentNextActionRedirectToUrl (returnUrl: string option, url: string option) =

        member _.ReturnUrl = returnUrl
        member _.Url = url

    ///
    and PaymentIntentPaymentMethodOptions (?alipay: PaymentMethodOptionsAlipay, ?bancontact: PaymentMethodOptionsBancontact, ?card: PaymentIntentPaymentMethodOptionsCard, ?oxxo: PaymentMethodOptionsOxxo, ?p24: PaymentMethodOptionsP24, ?sepaDebit: PaymentIntentPaymentMethodOptionsSepaDebit, ?sofort: PaymentMethodOptionsSofort) =

        member _.Alipay = alipay
        member _.Bancontact = bancontact
        member _.Card = card
        member _.Oxxo = oxxo
        member _.P24 = p24
        member _.SepaDebit = sepaDebit
        member _.Sofort = sofort

    ///
    and PaymentIntentPaymentMethodOptionsCard (installments: PaymentMethodOptionsCardInstallments option, network: PaymentIntentPaymentMethodOptionsCardNetwork option, requestThreeDSecure: PaymentIntentPaymentMethodOptionsCardRequestThreeDSecure option) =

        member _.Installments = installments
        member _.Network = network
        member _.RequestThreeDSecure = requestThreeDSecure

    and PaymentIntentPaymentMethodOptionsCardNetwork =
        | PaymentIntentPaymentMethodOptionsCardNetwork'Amex
        | PaymentIntentPaymentMethodOptionsCardNetwork'CartesBancaires
        | PaymentIntentPaymentMethodOptionsCardNetwork'Diners
        | PaymentIntentPaymentMethodOptionsCardNetwork'Discover
        | PaymentIntentPaymentMethodOptionsCardNetwork'Interac
        | PaymentIntentPaymentMethodOptionsCardNetwork'Jcb
        | PaymentIntentPaymentMethodOptionsCardNetwork'Mastercard
        | PaymentIntentPaymentMethodOptionsCardNetwork'Unionpay
        | PaymentIntentPaymentMethodOptionsCardNetwork'Unknown
        | PaymentIntentPaymentMethodOptionsCardNetwork'Visa

    and PaymentIntentPaymentMethodOptionsCardRequestThreeDSecure =
        | PaymentIntentPaymentMethodOptionsCardRequestThreeDSecure'Any
        | PaymentIntentPaymentMethodOptionsCardRequestThreeDSecure'Automatic
        | PaymentIntentPaymentMethodOptionsCardRequestThreeDSecure'ChallengeOnly

    ///
    and PaymentIntentPaymentMethodOptionsMandateOptionsSepaDebit (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and PaymentIntentPaymentMethodOptionsSepaDebit (?mandateOptions: PaymentIntentPaymentMethodOptionsMandateOptionsSepaDebit) =

        member _.MandateOptions = mandateOptions

    ///PaymentMethod objects represent your customer's payment instruments.
    ///They can be used with [PaymentIntents](https://stripe.com/docs/payments/payment-intents) to collect payments or saved to
    ///Customer objects to store instrument details for future payments.
    ///
    ///Related guides: [Payment Methods](https://stripe.com/docs/payments/payment-methods) and [More Payment Scenarios](https://stripe.com/docs/payments/more-payment-scenarios).
    and PaymentMethod (billingDetails: BillingDetails, created: int, customer: PaymentMethodCustomerDU option, id: string, livemode: bool, metadata: Map<string, string> option, object: PaymentMethodObject, ``type``: PaymentMethodType, ?alipay: PaymentFlowsPrivatePaymentMethodsAlipay, ?auBecsDebit: PaymentMethodAuBecsDebit, ?bacsDebit: PaymentMethodBacsDebit, ?bancontact: PaymentMethodBancontact, ?card: PaymentMethodCard, ?cardPresent: PaymentMethodCardPresent, ?eps: PaymentMethodEps, ?fpx: PaymentMethodFpx, ?giropay: PaymentMethodGiropay, ?grabpay: PaymentMethodGrabpay, ?ideal: PaymentMethodIdeal, ?interacPresent: PaymentMethodInteracPresent, ?oxxo: PaymentMethodOxxo, ?p24: PaymentMethodP24, ?sepaDebit: PaymentMethodSepaDebit, ?sofort: PaymentMethodSofort) =

        member _.Alipay = alipay
        member _.AuBecsDebit = auBecsDebit
        member _.BacsDebit = bacsDebit
        member _.Bancontact = bancontact
        member _.BillingDetails = billingDetails
        member _.Card = card
        member _.CardPresent = cardPresent
        member _.Created = created
        member _.Customer = customer
        member _.Eps = eps
        member _.Fpx = fpx
        member _.Giropay = giropay
        member _.Grabpay = grabpay
        member _.Id = id
        member _.Ideal = ideal
        member _.InteracPresent = interacPresent
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Object = object
        member _.Oxxo = oxxo
        member _.P24 = p24
        member _.SepaDebit = sepaDebit
        member _.Sofort = sofort
        member _.Type = ``type``

    and PaymentMethodObject =
        | PaymentMethodObject'PaymentMethod

    and PaymentMethodType =
        | PaymentMethodType'Alipay
        | PaymentMethodType'AuBecsDebit
        | PaymentMethodType'BacsDebit
        | PaymentMethodType'Bancontact
        | PaymentMethodType'Card
        | PaymentMethodType'CardPresent
        | PaymentMethodType'Eps
        | PaymentMethodType'Fpx
        | PaymentMethodType'Giropay
        | PaymentMethodType'Grabpay
        | PaymentMethodType'Ideal
        | PaymentMethodType'InteracPresent
        | PaymentMethodType'Oxxo
        | PaymentMethodType'P24
        | PaymentMethodType'SepaDebit
        | PaymentMethodType'Sofort

    and PaymentMethodCustomerDU =
        | PaymentMethodCustomerDU'String of string
        | PaymentMethodCustomerDU'Customer of Customer

    ///
    and PaymentMethodAuBecsDebit (bsbNumber: string option, fingerprint: string option, last4: string option) =

        member _.BsbNumber = bsbNumber
        member _.Fingerprint = fingerprint
        member _.Last4 = last4

    ///
    and PaymentMethodBacsDebit (fingerprint: string option, last4: string option, sortCode: string option) =

        member _.Fingerprint = fingerprint
        member _.Last4 = last4
        member _.SortCode = sortCode

    ///
    and PaymentMethodBancontact (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and PaymentMethodCard (brand: PaymentMethodCardBrand, checks: PaymentMethodCardChecks option, country: string option, expMonth: int, expYear: int, funding: PaymentMethodCardFunding, last4: string, networks: Networks option, threeDSecureUsage: ThreeDSecureUsage option, wallet: PaymentMethodCardWallet option, ?description: string option, ?fingerprint: string option, ?iin: string option, ?issuer: string option) =

        member _.Brand = brand
        member _.Checks = checks
        member _.Country = country
        member _.Description = description |> Option.flatten
        member _.ExpMonth = expMonth
        member _.ExpYear = expYear
        member _.Fingerprint = fingerprint |> Option.flatten
        member _.Funding = funding
        member _.Iin = iin |> Option.flatten
        member _.Issuer = issuer |> Option.flatten
        member _.Last4 = last4
        member _.Networks = networks
        member _.ThreeDSecureUsage = threeDSecureUsage
        member _.Wallet = wallet

    and PaymentMethodCardBrand =
        | PaymentMethodCardBrand'Amex
        | PaymentMethodCardBrand'Diners
        | PaymentMethodCardBrand'Discover
        | PaymentMethodCardBrand'Jcb
        | PaymentMethodCardBrand'Mastercard
        | PaymentMethodCardBrand'Unionpay
        | PaymentMethodCardBrand'Visa
        | PaymentMethodCardBrand'Unknown

    and PaymentMethodCardFunding =
        | PaymentMethodCardFunding'Credit
        | PaymentMethodCardFunding'Debit
        | PaymentMethodCardFunding'Prepaid
        | PaymentMethodCardFunding'Unknown

    ///
    and PaymentMethodCardChecks (addressLine1Check: string option, addressPostalCodeCheck: string option, cvcCheck: string option) =

        member _.AddressLine1Check = addressLine1Check
        member _.AddressPostalCodeCheck = addressPostalCodeCheck
        member _.CvcCheck = cvcCheck

    ///
    and PaymentMethodCardPresent (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and PaymentMethodCardWallet (dynamicLast4: string option, ``type``: PaymentMethodCardWalletType, ?amexExpressCheckout: PaymentMethodCardWalletAmexExpressCheckout, ?applePay: PaymentMethodCardWalletApplePay, ?googlePay: PaymentMethodCardWalletGooglePay, ?masterpass: PaymentMethodCardWalletMasterpass, ?samsungPay: PaymentMethodCardWalletSamsungPay, ?visaCheckout: PaymentMethodCardWalletVisaCheckout) =

        member _.AmexExpressCheckout = amexExpressCheckout
        member _.ApplePay = applePay
        member _.DynamicLast4 = dynamicLast4
        member _.GooglePay = googlePay
        member _.Masterpass = masterpass
        member _.SamsungPay = samsungPay
        member _.Type = ``type``
        member _.VisaCheckout = visaCheckout

    and PaymentMethodCardWalletType =
        | PaymentMethodCardWalletType'AmexExpressCheckout
        | PaymentMethodCardWalletType'ApplePay
        | PaymentMethodCardWalletType'GooglePay
        | PaymentMethodCardWalletType'Masterpass
        | PaymentMethodCardWalletType'SamsungPay
        | PaymentMethodCardWalletType'VisaCheckout

    ///
    and PaymentMethodCardWalletAmexExpressCheckout (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and PaymentMethodCardWalletApplePay (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and PaymentMethodCardWalletGooglePay (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and PaymentMethodCardWalletMasterpass (billingAddress: Address option, email: string option, name: string option, shippingAddress: Address option) =

        member _.BillingAddress = billingAddress
        member _.Email = email
        member _.Name = name
        member _.ShippingAddress = shippingAddress

    ///
    and PaymentMethodCardWalletSamsungPay (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and PaymentMethodCardWalletVisaCheckout (billingAddress: Address option, email: string option, name: string option, shippingAddress: Address option) =

        member _.BillingAddress = billingAddress
        member _.Email = email
        member _.Name = name
        member _.ShippingAddress = shippingAddress

    ///
    and PaymentMethodDetails (``type``: string, ?achCreditTransfer: PaymentMethodDetailsAchCreditTransfer, ?achDebit: PaymentMethodDetailsAchDebit, ?acssDebit: PaymentMethodDetailsAcssDebit, ?alipay: PaymentFlowsPrivatePaymentMethodsAlipayDetails, ?auBecsDebit: PaymentMethodDetailsAuBecsDebit, ?bacsDebit: PaymentMethodDetailsBacsDebit, ?bancontact: PaymentMethodDetailsBancontact, ?card: PaymentMethodDetailsCard, ?cardPresent: PaymentMethodDetailsCardPresent, ?eps: PaymentMethodDetailsEps, ?fpx: PaymentMethodDetailsFpx, ?giropay: PaymentMethodDetailsGiropay, ?grabpay: PaymentMethodDetailsGrabpay, ?ideal: PaymentMethodDetailsIdeal, ?interacPresent: PaymentMethodDetailsInteracPresent, ?klarna: PaymentMethodDetailsKlarna, ?multibanco: PaymentMethodDetailsMultibanco, ?oxxo: PaymentMethodDetailsOxxo, ?p24: PaymentMethodDetailsP24, ?sepaCreditTransfer: PaymentMethodDetailsSepaCreditTransfer, ?sepaDebit: PaymentMethodDetailsSepaDebit, ?sofort: PaymentMethodDetailsSofort, ?stripeAccount: PaymentMethodDetailsStripeAccount, ?wechat: PaymentMethodDetailsWechat) =

        member _.AchCreditTransfer = achCreditTransfer
        member _.AchDebit = achDebit
        member _.AcssDebit = acssDebit
        member _.Alipay = alipay
        member _.AuBecsDebit = auBecsDebit
        member _.BacsDebit = bacsDebit
        member _.Bancontact = bancontact
        member _.Card = card
        member _.CardPresent = cardPresent
        member _.Eps = eps
        member _.Fpx = fpx
        member _.Giropay = giropay
        member _.Grabpay = grabpay
        member _.Ideal = ideal
        member _.InteracPresent = interacPresent
        member _.Klarna = klarna
        member _.Multibanco = multibanco
        member _.Oxxo = oxxo
        member _.P24 = p24
        member _.SepaCreditTransfer = sepaCreditTransfer
        member _.SepaDebit = sepaDebit
        member _.Sofort = sofort
        member _.StripeAccount = stripeAccount
        member _.Type = ``type``
        member _.Wechat = wechat

    ///
    and PaymentMethodDetailsAchCreditTransfer (accountNumber: string option, bankName: string option, routingNumber: string option, swiftCode: string option) =

        member _.AccountNumber = accountNumber
        member _.BankName = bankName
        member _.RoutingNumber = routingNumber
        member _.SwiftCode = swiftCode

    ///
    and PaymentMethodDetailsAchDebit (accountHolderType: PaymentMethodDetailsAchDebitAccountHolderType option, bankName: string option, country: string option, fingerprint: string option, last4: string option, routingNumber: string option) =

        member _.AccountHolderType = accountHolderType
        member _.BankName = bankName
        member _.Country = country
        member _.Fingerprint = fingerprint
        member _.Last4 = last4
        member _.RoutingNumber = routingNumber

    and PaymentMethodDetailsAchDebitAccountHolderType =
        | PaymentMethodDetailsAchDebitAccountHolderType'Company
        | PaymentMethodDetailsAchDebitAccountHolderType'Individual

    ///
    and PaymentMethodDetailsAcssDebit (bankName: string option, fingerprint: string option, institutionNumber: string option, last4: string option, transitNumber: string option, ?mandate: string) =

        member _.BankName = bankName
        member _.Fingerprint = fingerprint
        member _.InstitutionNumber = institutionNumber
        member _.Last4 = last4
        member _.Mandate = mandate
        member _.TransitNumber = transitNumber

    ///
    and PaymentMethodDetailsAuBecsDebit (bsbNumber: string option, fingerprint: string option, last4: string option, ?mandate: string) =

        member _.BsbNumber = bsbNumber
        member _.Fingerprint = fingerprint
        member _.Last4 = last4
        member _.Mandate = mandate

    ///
    and PaymentMethodDetailsBacsDebit (fingerprint: string option, last4: string option, mandate: string option, sortCode: string option) =

        member _.Fingerprint = fingerprint
        member _.Last4 = last4
        member _.Mandate = mandate
        member _.SortCode = sortCode

    ///
    and PaymentMethodDetailsBancontact (bankCode: string option, bankName: string option, bic: string option, generatedSepaDebit: PaymentMethodDetailsBancontactGeneratedSepaDebitDU option, generatedSepaDebitMandate: PaymentMethodDetailsBancontactGeneratedSepaDebitMandateDU option, ibanLast4: string option, preferredLanguage: PaymentMethodDetailsBancontactPreferredLanguage option, verifiedName: string option) =

        member _.BankCode = bankCode
        member _.BankName = bankName
        member _.Bic = bic
        member _.GeneratedSepaDebit = generatedSepaDebit
        member _.GeneratedSepaDebitMandate = generatedSepaDebitMandate
        member _.IbanLast4 = ibanLast4
        member _.PreferredLanguage = preferredLanguage
        member _.VerifiedName = verifiedName

    and PaymentMethodDetailsBancontactPreferredLanguage =
        | PaymentMethodDetailsBancontactPreferredLanguage'De
        | PaymentMethodDetailsBancontactPreferredLanguage'En
        | PaymentMethodDetailsBancontactPreferredLanguage'Fr
        | PaymentMethodDetailsBancontactPreferredLanguage'Nl

    and PaymentMethodDetailsBancontactGeneratedSepaDebitDU =
        | PaymentMethodDetailsBancontactGeneratedSepaDebitDU'String of string
        | PaymentMethodDetailsBancontactGeneratedSepaDebitDU'PaymentMethod of PaymentMethod

    and PaymentMethodDetailsBancontactGeneratedSepaDebitMandateDU =
        | PaymentMethodDetailsBancontactGeneratedSepaDebitMandateDU'String of string
        | PaymentMethodDetailsBancontactGeneratedSepaDebitMandateDU'Mandate of Mandate

    ///
    and PaymentMethodDetailsCard (brand: PaymentMethodDetailsCardBrand option, checks: PaymentMethodDetailsCardChecks option, country: string option, expMonth: int, expYear: int, funding: PaymentMethodDetailsCardFunding option, installments: PaymentMethodDetailsCardInstallments option, last4: string option, network: PaymentMethodDetailsCardNetwork option, threeDSecure: ThreeDSecureDetails option, wallet: PaymentMethodDetailsCardWallet option, ?description: string option, ?fingerprint: string option, ?iin: string option, ?issuer: string option, ?moto: bool option) =

        member _.Brand = brand
        member _.Checks = checks
        member _.Country = country
        member _.Description = description |> Option.flatten
        member _.ExpMonth = expMonth
        member _.ExpYear = expYear
        member _.Fingerprint = fingerprint |> Option.flatten
        member _.Funding = funding
        member _.Iin = iin |> Option.flatten
        member _.Installments = installments
        member _.Issuer = issuer |> Option.flatten
        member _.Last4 = last4
        member _.Moto = moto |> Option.flatten
        member _.Network = network
        member _.ThreeDSecure = threeDSecure
        member _.Wallet = wallet

    and PaymentMethodDetailsCardBrand =
        | PaymentMethodDetailsCardBrand'Amex
        | PaymentMethodDetailsCardBrand'Diners
        | PaymentMethodDetailsCardBrand'Discover
        | PaymentMethodDetailsCardBrand'Jcb
        | PaymentMethodDetailsCardBrand'Mastercard
        | PaymentMethodDetailsCardBrand'Unionpay
        | PaymentMethodDetailsCardBrand'Visa
        | PaymentMethodDetailsCardBrand'Unknown

    and PaymentMethodDetailsCardFunding =
        | PaymentMethodDetailsCardFunding'Credit
        | PaymentMethodDetailsCardFunding'Debit
        | PaymentMethodDetailsCardFunding'Prepaid
        | PaymentMethodDetailsCardFunding'Unknown

    and PaymentMethodDetailsCardNetwork =
        | PaymentMethodDetailsCardNetwork'Amex
        | PaymentMethodDetailsCardNetwork'CartesBancaires
        | PaymentMethodDetailsCardNetwork'Diners
        | PaymentMethodDetailsCardNetwork'Discover
        | PaymentMethodDetailsCardNetwork'Interac
        | PaymentMethodDetailsCardNetwork'Jcb
        | PaymentMethodDetailsCardNetwork'Mastercard
        | PaymentMethodDetailsCardNetwork'Unionpay
        | PaymentMethodDetailsCardNetwork'Visa
        | PaymentMethodDetailsCardNetwork'Unknown

    ///
    and PaymentMethodDetailsCardChecks (addressLine1Check: string option, addressPostalCodeCheck: string option, cvcCheck: string option) =

        member _.AddressLine1Check = addressLine1Check
        member _.AddressPostalCodeCheck = addressPostalCodeCheck
        member _.CvcCheck = cvcCheck

    ///
    and PaymentMethodDetailsCardInstallments (plan: PaymentMethodDetailsCardInstallmentsPlan option) =

        member _.Plan = plan

    ///
    and PaymentMethodDetailsCardInstallmentsPlan (count: int option, interval: PaymentMethodDetailsCardInstallmentsPlanInterval option, ``type``: PaymentMethodDetailsCardInstallmentsPlanType) =

        member _.Count = count
        member _.Interval = interval
        member _.Type = ``type``

    and PaymentMethodDetailsCardInstallmentsPlanInterval =
        | PaymentMethodDetailsCardInstallmentsPlanInterval'Month

    and PaymentMethodDetailsCardInstallmentsPlanType =
        | PaymentMethodDetailsCardInstallmentsPlanType'FixedCount

    ///
    and PaymentMethodDetailsCardPresent (brand: PaymentMethodDetailsCardPresentBrand option, cardholderName: string option, country: string option, emvAuthData: string option, expMonth: int, expYear: int, fingerprint: string option, funding: PaymentMethodDetailsCardPresentFunding option, generatedCard: string option, last4: string option, network: PaymentMethodDetailsCardPresentNetwork option, readMethod: PaymentMethodDetailsCardPresentReadMethod option, receipt: PaymentMethodDetailsCardPresentReceipt option, ?description: string option, ?iin: string option, ?issuer: string option) =

        member _.Brand = brand
        member _.CardholderName = cardholderName
        member _.Country = country
        member _.Description = description |> Option.flatten
        member _.EmvAuthData = emvAuthData
        member _.ExpMonth = expMonth
        member _.ExpYear = expYear
        member _.Fingerprint = fingerprint
        member _.Funding = funding
        member _.GeneratedCard = generatedCard
        member _.Iin = iin |> Option.flatten
        member _.Issuer = issuer |> Option.flatten
        member _.Last4 = last4
        member _.Network = network
        member _.ReadMethod = readMethod
        member _.Receipt = receipt

    and PaymentMethodDetailsCardPresentBrand =
        | PaymentMethodDetailsCardPresentBrand'Amex
        | PaymentMethodDetailsCardPresentBrand'Diners
        | PaymentMethodDetailsCardPresentBrand'Discover
        | PaymentMethodDetailsCardPresentBrand'Jcb
        | PaymentMethodDetailsCardPresentBrand'Mastercard
        | PaymentMethodDetailsCardPresentBrand'Unionpay
        | PaymentMethodDetailsCardPresentBrand'Visa
        | PaymentMethodDetailsCardPresentBrand'Unknown

    and PaymentMethodDetailsCardPresentFunding =
        | PaymentMethodDetailsCardPresentFunding'Credit
        | PaymentMethodDetailsCardPresentFunding'Debit
        | PaymentMethodDetailsCardPresentFunding'Prepaid
        | PaymentMethodDetailsCardPresentFunding'Unknown

    and PaymentMethodDetailsCardPresentNetwork =
        | PaymentMethodDetailsCardPresentNetwork'Amex
        | PaymentMethodDetailsCardPresentNetwork'CartesBancaires
        | PaymentMethodDetailsCardPresentNetwork'Diners
        | PaymentMethodDetailsCardPresentNetwork'Discover
        | PaymentMethodDetailsCardPresentNetwork'Interac
        | PaymentMethodDetailsCardPresentNetwork'Jcb
        | PaymentMethodDetailsCardPresentNetwork'Mastercard
        | PaymentMethodDetailsCardPresentNetwork'Unionpay
        | PaymentMethodDetailsCardPresentNetwork'Visa
        | PaymentMethodDetailsCardPresentNetwork'Unknown

    and PaymentMethodDetailsCardPresentReadMethod =
        | PaymentMethodDetailsCardPresentReadMethod'ContactEmv
        | PaymentMethodDetailsCardPresentReadMethod'ContactlessEmv
        | PaymentMethodDetailsCardPresentReadMethod'ContactlessMagstripeMode
        | PaymentMethodDetailsCardPresentReadMethod'MagneticStripeFallback
        | PaymentMethodDetailsCardPresentReadMethod'MagneticStripeTrack2

    ///
    and PaymentMethodDetailsCardPresentReceipt (applicationCryptogram: string option, applicationPreferredName: string option, authorizationCode: string option, authorizationResponseCode: string option, cardholderVerificationMethod: string option, dedicatedFileName: string option, terminalVerificationResults: string option, transactionStatusInformation: string option, ?accountType: PaymentMethodDetailsCardPresentReceiptAccountType) =

        member _.AccountType = accountType
        member _.ApplicationCryptogram = applicationCryptogram
        member _.ApplicationPreferredName = applicationPreferredName
        member _.AuthorizationCode = authorizationCode
        member _.AuthorizationResponseCode = authorizationResponseCode
        member _.CardholderVerificationMethod = cardholderVerificationMethod
        member _.DedicatedFileName = dedicatedFileName
        member _.TerminalVerificationResults = terminalVerificationResults
        member _.TransactionStatusInformation = transactionStatusInformation

    and PaymentMethodDetailsCardPresentReceiptAccountType =
        | PaymentMethodDetailsCardPresentReceiptAccountType'Checking
        | PaymentMethodDetailsCardPresentReceiptAccountType'Credit
        | PaymentMethodDetailsCardPresentReceiptAccountType'Prepaid
        | PaymentMethodDetailsCardPresentReceiptAccountType'Unknown

    ///
    and PaymentMethodDetailsCardWallet (dynamicLast4: string option, ``type``: PaymentMethodDetailsCardWalletType, ?amexExpressCheckout: PaymentMethodDetailsCardWalletAmexExpressCheckout, ?applePay: PaymentMethodDetailsCardWalletApplePay, ?googlePay: PaymentMethodDetailsCardWalletGooglePay, ?masterpass: PaymentMethodDetailsCardWalletMasterpass, ?samsungPay: PaymentMethodDetailsCardWalletSamsungPay, ?visaCheckout: PaymentMethodDetailsCardWalletVisaCheckout) =

        member _.AmexExpressCheckout = amexExpressCheckout
        member _.ApplePay = applePay
        member _.DynamicLast4 = dynamicLast4
        member _.GooglePay = googlePay
        member _.Masterpass = masterpass
        member _.SamsungPay = samsungPay
        member _.Type = ``type``
        member _.VisaCheckout = visaCheckout

    and PaymentMethodDetailsCardWalletType =
        | PaymentMethodDetailsCardWalletType'AmexExpressCheckout
        | PaymentMethodDetailsCardWalletType'ApplePay
        | PaymentMethodDetailsCardWalletType'GooglePay
        | PaymentMethodDetailsCardWalletType'Masterpass
        | PaymentMethodDetailsCardWalletType'SamsungPay
        | PaymentMethodDetailsCardWalletType'VisaCheckout

    ///
    and PaymentMethodDetailsCardWalletAmexExpressCheckout (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and PaymentMethodDetailsCardWalletApplePay (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and PaymentMethodDetailsCardWalletGooglePay (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and PaymentMethodDetailsCardWalletMasterpass (billingAddress: Address option, email: string option, name: string option, shippingAddress: Address option) =

        member _.BillingAddress = billingAddress
        member _.Email = email
        member _.Name = name
        member _.ShippingAddress = shippingAddress

    ///
    and PaymentMethodDetailsCardWalletSamsungPay (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and PaymentMethodDetailsCardWalletVisaCheckout (billingAddress: Address option, email: string option, name: string option, shippingAddress: Address option) =

        member _.BillingAddress = billingAddress
        member _.Email = email
        member _.Name = name
        member _.ShippingAddress = shippingAddress

    ///
    and PaymentMethodDetailsEps (verifiedName: string option) =

        member _.VerifiedName = verifiedName

    ///
    and PaymentMethodDetailsFpx (accountHolderType: PaymentMethodDetailsFpxAccountHolderType option, bank: PaymentMethodDetailsFpxBank, transactionId: string option) =

        member _.AccountHolderType = accountHolderType
        member _.Bank = bank
        member _.TransactionId = transactionId

    and PaymentMethodDetailsFpxAccountHolderType =
        | PaymentMethodDetailsFpxAccountHolderType'Company
        | PaymentMethodDetailsFpxAccountHolderType'Individual

    and PaymentMethodDetailsFpxBank =
        | PaymentMethodDetailsFpxBank'AffinBank
        | PaymentMethodDetailsFpxBank'AllianceBank
        | PaymentMethodDetailsFpxBank'Ambank
        | PaymentMethodDetailsFpxBank'BankIslam
        | PaymentMethodDetailsFpxBank'BankMuamalat
        | PaymentMethodDetailsFpxBank'BankRakyat
        | PaymentMethodDetailsFpxBank'Bsn
        | PaymentMethodDetailsFpxBank'Cimb
        | PaymentMethodDetailsFpxBank'DeutscheBank
        | PaymentMethodDetailsFpxBank'HongLeongBank
        | PaymentMethodDetailsFpxBank'Hsbc
        | PaymentMethodDetailsFpxBank'Kfh
        | PaymentMethodDetailsFpxBank'Maybank2e
        | PaymentMethodDetailsFpxBank'Maybank2u
        | PaymentMethodDetailsFpxBank'Ocbc
        | PaymentMethodDetailsFpxBank'PbEnterprise
        | PaymentMethodDetailsFpxBank'PublicBank
        | PaymentMethodDetailsFpxBank'Rhb
        | PaymentMethodDetailsFpxBank'StandardChartered
        | PaymentMethodDetailsFpxBank'Uob

    ///
    and PaymentMethodDetailsGiropay (bankCode: string option, bankName: string option, bic: string option, verifiedName: string option) =

        member _.BankCode = bankCode
        member _.BankName = bankName
        member _.Bic = bic
        member _.VerifiedName = verifiedName

    ///
    and PaymentMethodDetailsGrabpay (transactionId: string option) =

        member _.TransactionId = transactionId

    ///
    and PaymentMethodDetailsIdeal (bank: PaymentMethodDetailsIdealBank option, bic: PaymentMethodDetailsIdealBic option, generatedSepaDebit: PaymentMethodDetailsIdealGeneratedSepaDebitDU option, generatedSepaDebitMandate: PaymentMethodDetailsIdealGeneratedSepaDebitMandateDU option, ibanLast4: string option, verifiedName: string option) =

        member _.Bank = bank
        member _.Bic = bic
        member _.GeneratedSepaDebit = generatedSepaDebit
        member _.GeneratedSepaDebitMandate = generatedSepaDebitMandate
        member _.IbanLast4 = ibanLast4
        member _.VerifiedName = verifiedName

    and PaymentMethodDetailsIdealBank =
        | PaymentMethodDetailsIdealBank'AbnAmro
        | PaymentMethodDetailsIdealBank'AsnBank
        | PaymentMethodDetailsIdealBank'Bunq
        | PaymentMethodDetailsIdealBank'Handelsbanken
        | PaymentMethodDetailsIdealBank'Ing
        | PaymentMethodDetailsIdealBank'Knab
        | PaymentMethodDetailsIdealBank'Moneyou
        | PaymentMethodDetailsIdealBank'Rabobank
        | PaymentMethodDetailsIdealBank'Regiobank
        | PaymentMethodDetailsIdealBank'SnsBank
        | PaymentMethodDetailsIdealBank'TriodosBank
        | PaymentMethodDetailsIdealBank'VanLanschot

    and PaymentMethodDetailsIdealBic =
        | [<JsonUnionCase("ABNANL2A")>] PaymentMethodDetailsIdealBic'ABNANL2A
        | [<JsonUnionCase("ASNBNL21")>] PaymentMethodDetailsIdealBic'ASNBNL21
        | [<JsonUnionCase("BUNQNL2A")>] PaymentMethodDetailsIdealBic'BUNQNL2A
        | [<JsonUnionCase("FVLBNL22")>] PaymentMethodDetailsIdealBic'FVLBNL22
        | [<JsonUnionCase("HANDNL2A")>] PaymentMethodDetailsIdealBic'HANDNL2A
        | [<JsonUnionCase("INGBNL2A")>] PaymentMethodDetailsIdealBic'INGBNL2A
        | [<JsonUnionCase("KNABNL2H")>] PaymentMethodDetailsIdealBic'KNABNL2H
        | [<JsonUnionCase("MOYONL21")>] PaymentMethodDetailsIdealBic'MOYONL21
        | [<JsonUnionCase("RABONL2U")>] PaymentMethodDetailsIdealBic'RABONL2U
        | [<JsonUnionCase("RBRBNL21")>] PaymentMethodDetailsIdealBic'RBRBNL21
        | [<JsonUnionCase("SNSBNL2A")>] PaymentMethodDetailsIdealBic'SNSBNL2A
        | [<JsonUnionCase("TRIONL2U")>] PaymentMethodDetailsIdealBic'TRIONL2U

    and PaymentMethodDetailsIdealGeneratedSepaDebitDU =
        | PaymentMethodDetailsIdealGeneratedSepaDebitDU'String of string
        | PaymentMethodDetailsIdealGeneratedSepaDebitDU'PaymentMethod of PaymentMethod

    and PaymentMethodDetailsIdealGeneratedSepaDebitMandateDU =
        | PaymentMethodDetailsIdealGeneratedSepaDebitMandateDU'String of string
        | PaymentMethodDetailsIdealGeneratedSepaDebitMandateDU'Mandate of Mandate

    ///
    and PaymentMethodDetailsInteracPresent (brand: PaymentMethodDetailsInteracPresentBrand option, cardholderName: string option, country: string option, emvAuthData: string option, expMonth: int, expYear: int, fingerprint: string option, funding: PaymentMethodDetailsInteracPresentFunding option, generatedCard: string option, last4: string option, network: PaymentMethodDetailsInteracPresentNetwork option, preferredLocales: string list option, readMethod: PaymentMethodDetailsInteracPresentReadMethod option, receipt: PaymentMethodDetailsInteracPresentReceipt option, ?description: string option, ?iin: string option, ?issuer: string option) =

        member _.Brand = brand
        member _.CardholderName = cardholderName
        member _.Country = country
        member _.Description = description |> Option.flatten
        member _.EmvAuthData = emvAuthData
        member _.ExpMonth = expMonth
        member _.ExpYear = expYear
        member _.Fingerprint = fingerprint
        member _.Funding = funding
        member _.GeneratedCard = generatedCard
        member _.Iin = iin |> Option.flatten
        member _.Issuer = issuer |> Option.flatten
        member _.Last4 = last4
        member _.Network = network
        member _.PreferredLocales = preferredLocales
        member _.ReadMethod = readMethod
        member _.Receipt = receipt

    and PaymentMethodDetailsInteracPresentBrand =
        | PaymentMethodDetailsInteracPresentBrand'Interac
        | PaymentMethodDetailsInteracPresentBrand'Mastercard
        | PaymentMethodDetailsInteracPresentBrand'Visa

    and PaymentMethodDetailsInteracPresentFunding =
        | PaymentMethodDetailsInteracPresentFunding'Credit
        | PaymentMethodDetailsInteracPresentFunding'Debit
        | PaymentMethodDetailsInteracPresentFunding'Prepaid
        | PaymentMethodDetailsInteracPresentFunding'Unknown

    and PaymentMethodDetailsInteracPresentNetwork =
        | PaymentMethodDetailsInteracPresentNetwork'Amex
        | PaymentMethodDetailsInteracPresentNetwork'CartesBancaires
        | PaymentMethodDetailsInteracPresentNetwork'Diners
        | PaymentMethodDetailsInteracPresentNetwork'Discover
        | PaymentMethodDetailsInteracPresentNetwork'Interac
        | PaymentMethodDetailsInteracPresentNetwork'Jcb
        | PaymentMethodDetailsInteracPresentNetwork'Mastercard
        | PaymentMethodDetailsInteracPresentNetwork'Unionpay
        | PaymentMethodDetailsInteracPresentNetwork'Visa
        | PaymentMethodDetailsInteracPresentNetwork'Unknown

    and PaymentMethodDetailsInteracPresentReadMethod =
        | PaymentMethodDetailsInteracPresentReadMethod'ContactEmv
        | PaymentMethodDetailsInteracPresentReadMethod'ContactlessEmv
        | PaymentMethodDetailsInteracPresentReadMethod'ContactlessMagstripeMode
        | PaymentMethodDetailsInteracPresentReadMethod'MagneticStripeFallback
        | PaymentMethodDetailsInteracPresentReadMethod'MagneticStripeTrack2

    ///
    and PaymentMethodDetailsInteracPresentReceipt (applicationCryptogram: string option, applicationPreferredName: string option, authorizationCode: string option, authorizationResponseCode: string option, cardholderVerificationMethod: string option, dedicatedFileName: string option, terminalVerificationResults: string option, transactionStatusInformation: string option, ?accountType: PaymentMethodDetailsInteracPresentReceiptAccountType) =

        member _.AccountType = accountType
        member _.ApplicationCryptogram = applicationCryptogram
        member _.ApplicationPreferredName = applicationPreferredName
        member _.AuthorizationCode = authorizationCode
        member _.AuthorizationResponseCode = authorizationResponseCode
        member _.CardholderVerificationMethod = cardholderVerificationMethod
        member _.DedicatedFileName = dedicatedFileName
        member _.TerminalVerificationResults = terminalVerificationResults
        member _.TransactionStatusInformation = transactionStatusInformation

    and PaymentMethodDetailsInteracPresentReceiptAccountType =
        | PaymentMethodDetailsInteracPresentReceiptAccountType'Checking
        | PaymentMethodDetailsInteracPresentReceiptAccountType'Savings
        | PaymentMethodDetailsInteracPresentReceiptAccountType'Unknown

    ///
    and PaymentMethodDetailsKlarna (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and PaymentMethodDetailsMultibanco (entity: string option, reference: string option) =

        member _.Entity = entity
        member _.Reference = reference

    ///
    and PaymentMethodDetailsOxxo (number: string option) =

        member _.Number = number

    ///
    and PaymentMethodDetailsP24 (reference: string option, verifiedName: string option) =

        member _.Reference = reference
        member _.VerifiedName = verifiedName

    ///
    and PaymentMethodDetailsSepaCreditTransfer (bankName: string option, bic: string option, iban: string option) =

        member _.BankName = bankName
        member _.Bic = bic
        member _.Iban = iban

    ///
    and PaymentMethodDetailsSepaDebit (bankCode: string option, branchCode: string option, country: string option, fingerprint: string option, last4: string option, mandate: string option) =

        member _.BankCode = bankCode
        member _.BranchCode = branchCode
        member _.Country = country
        member _.Fingerprint = fingerprint
        member _.Last4 = last4
        member _.Mandate = mandate

    ///
    and PaymentMethodDetailsSofort (bankCode: string option, bankName: string option, bic: string option, country: string option, generatedSepaDebit: PaymentMethodDetailsSofortGeneratedSepaDebitDU option, generatedSepaDebitMandate: PaymentMethodDetailsSofortGeneratedSepaDebitMandateDU option, ibanLast4: string option, preferredLanguage: PaymentMethodDetailsSofortPreferredLanguage option, verifiedName: string option) =

        member _.BankCode = bankCode
        member _.BankName = bankName
        member _.Bic = bic
        member _.Country = country
        member _.GeneratedSepaDebit = generatedSepaDebit
        member _.GeneratedSepaDebitMandate = generatedSepaDebitMandate
        member _.IbanLast4 = ibanLast4
        member _.PreferredLanguage = preferredLanguage
        member _.VerifiedName = verifiedName

    and PaymentMethodDetailsSofortPreferredLanguage =
        | PaymentMethodDetailsSofortPreferredLanguage'De
        | PaymentMethodDetailsSofortPreferredLanguage'En
        | PaymentMethodDetailsSofortPreferredLanguage'Es
        | PaymentMethodDetailsSofortPreferredLanguage'Fr
        | PaymentMethodDetailsSofortPreferredLanguage'It
        | PaymentMethodDetailsSofortPreferredLanguage'Nl
        | PaymentMethodDetailsSofortPreferredLanguage'Pl

    and PaymentMethodDetailsSofortGeneratedSepaDebitDU =
        | PaymentMethodDetailsSofortGeneratedSepaDebitDU'String of string
        | PaymentMethodDetailsSofortGeneratedSepaDebitDU'PaymentMethod of PaymentMethod

    and PaymentMethodDetailsSofortGeneratedSepaDebitMandateDU =
        | PaymentMethodDetailsSofortGeneratedSepaDebitMandateDU'String of string
        | PaymentMethodDetailsSofortGeneratedSepaDebitMandateDU'Mandate of Mandate

    ///
    and PaymentMethodDetailsStripeAccount (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and PaymentMethodDetailsWechat (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and PaymentMethodEps (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and PaymentMethodFpx (accountHolderType: PaymentMethodFpxAccountHolderType option, bank: PaymentMethodFpxBank) =

        member _.AccountHolderType = accountHolderType
        member _.Bank = bank

    and PaymentMethodFpxAccountHolderType =
        | PaymentMethodFpxAccountHolderType'Company
        | PaymentMethodFpxAccountHolderType'Individual

    and PaymentMethodFpxBank =
        | PaymentMethodFpxBank'AffinBank
        | PaymentMethodFpxBank'AllianceBank
        | PaymentMethodFpxBank'Ambank
        | PaymentMethodFpxBank'BankIslam
        | PaymentMethodFpxBank'BankMuamalat
        | PaymentMethodFpxBank'BankRakyat
        | PaymentMethodFpxBank'Bsn
        | PaymentMethodFpxBank'Cimb
        | PaymentMethodFpxBank'DeutscheBank
        | PaymentMethodFpxBank'HongLeongBank
        | PaymentMethodFpxBank'Hsbc
        | PaymentMethodFpxBank'Kfh
        | PaymentMethodFpxBank'Maybank2e
        | PaymentMethodFpxBank'Maybank2u
        | PaymentMethodFpxBank'Ocbc
        | PaymentMethodFpxBank'PbEnterprise
        | PaymentMethodFpxBank'PublicBank
        | PaymentMethodFpxBank'Rhb
        | PaymentMethodFpxBank'StandardChartered
        | PaymentMethodFpxBank'Uob

    ///
    and PaymentMethodGiropay (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and PaymentMethodGrabpay (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and PaymentMethodIdeal (bank: PaymentMethodIdealBank option, bic: PaymentMethodIdealBic option) =

        member _.Bank = bank
        member _.Bic = bic

    and PaymentMethodIdealBank =
        | PaymentMethodIdealBank'AbnAmro
        | PaymentMethodIdealBank'AsnBank
        | PaymentMethodIdealBank'Bunq
        | PaymentMethodIdealBank'Handelsbanken
        | PaymentMethodIdealBank'Ing
        | PaymentMethodIdealBank'Knab
        | PaymentMethodIdealBank'Moneyou
        | PaymentMethodIdealBank'Rabobank
        | PaymentMethodIdealBank'Regiobank
        | PaymentMethodIdealBank'SnsBank
        | PaymentMethodIdealBank'TriodosBank
        | PaymentMethodIdealBank'VanLanschot

    and PaymentMethodIdealBic =
        | [<JsonUnionCase("ABNANL2A")>] PaymentMethodIdealBic'ABNANL2A
        | [<JsonUnionCase("ASNBNL21")>] PaymentMethodIdealBic'ASNBNL21
        | [<JsonUnionCase("BUNQNL2A")>] PaymentMethodIdealBic'BUNQNL2A
        | [<JsonUnionCase("FVLBNL22")>] PaymentMethodIdealBic'FVLBNL22
        | [<JsonUnionCase("HANDNL2A")>] PaymentMethodIdealBic'HANDNL2A
        | [<JsonUnionCase("INGBNL2A")>] PaymentMethodIdealBic'INGBNL2A
        | [<JsonUnionCase("KNABNL2H")>] PaymentMethodIdealBic'KNABNL2H
        | [<JsonUnionCase("MOYONL21")>] PaymentMethodIdealBic'MOYONL21
        | [<JsonUnionCase("RABONL2U")>] PaymentMethodIdealBic'RABONL2U
        | [<JsonUnionCase("RBRBNL21")>] PaymentMethodIdealBic'RBRBNL21
        | [<JsonUnionCase("SNSBNL2A")>] PaymentMethodIdealBic'SNSBNL2A
        | [<JsonUnionCase("TRIONL2U")>] PaymentMethodIdealBic'TRIONL2U

    ///
    and PaymentMethodInteracPresent (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and PaymentMethodOptionsAlipay (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and PaymentMethodOptionsBancontact (preferredLanguage: PaymentMethodOptionsBancontactPreferredLanguage) =

        member _.PreferredLanguage = preferredLanguage

    and PaymentMethodOptionsBancontactPreferredLanguage =
        | PaymentMethodOptionsBancontactPreferredLanguage'De
        | PaymentMethodOptionsBancontactPreferredLanguage'En
        | PaymentMethodOptionsBancontactPreferredLanguage'Fr
        | PaymentMethodOptionsBancontactPreferredLanguage'Nl

    ///
    and PaymentMethodOptionsCardInstallments (availablePlans: PaymentMethodDetailsCardInstallmentsPlan list option, enabled: bool, plan: PaymentMethodDetailsCardInstallmentsPlan option) =

        member _.AvailablePlans = availablePlans
        member _.Enabled = enabled
        member _.Plan = plan

    ///
    and PaymentMethodOptionsOxxo (expiresAfterDays: int) =

        member _.ExpiresAfterDays = expiresAfterDays

    ///
    and PaymentMethodOptionsP24 (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and PaymentMethodOptionsSofort (preferredLanguage: PaymentMethodOptionsSofortPreferredLanguage option) =

        member _.PreferredLanguage = preferredLanguage

    and PaymentMethodOptionsSofortPreferredLanguage =
        | PaymentMethodOptionsSofortPreferredLanguage'De
        | PaymentMethodOptionsSofortPreferredLanguage'En
        | PaymentMethodOptionsSofortPreferredLanguage'Es
        | PaymentMethodOptionsSofortPreferredLanguage'Fr
        | PaymentMethodOptionsSofortPreferredLanguage'It
        | PaymentMethodOptionsSofortPreferredLanguage'Nl
        | PaymentMethodOptionsSofortPreferredLanguage'Pl

    ///
    and PaymentMethodOxxo (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and PaymentMethodP24 (bank: PaymentMethodP24Bank option) =

        member _.Bank = bank

    and PaymentMethodP24Bank =
        | PaymentMethodP24Bank'AliorBank
        | PaymentMethodP24Bank'BankMillennium
        | PaymentMethodP24Bank'BankNowyBfgSa
        | PaymentMethodP24Bank'BankPekaoSa
        | PaymentMethodP24Bank'BankiSpbdzielcze
        | PaymentMethodP24Bank'Blik
        | PaymentMethodP24Bank'BnpParibas
        | PaymentMethodP24Bank'Boz
        | PaymentMethodP24Bank'CitiHandlowy
        | PaymentMethodP24Bank'CreditAgricole
        | PaymentMethodP24Bank'Envelobank
        | PaymentMethodP24Bank'EtransferPocztowy24
        | PaymentMethodP24Bank'GetinBank
        | PaymentMethodP24Bank'Ideabank
        | PaymentMethodP24Bank'Ing
        | PaymentMethodP24Bank'Inteligo
        | PaymentMethodP24Bank'MbankMtransfer
        | PaymentMethodP24Bank'NestPrzelew
        | PaymentMethodP24Bank'NoblePay
        | PaymentMethodP24Bank'PbacZIpko
        | PaymentMethodP24Bank'PlusBank
        | PaymentMethodP24Bank'SantanderPrzelew24
        | PaymentMethodP24Bank'TmobileUsbugiBankowe
        | PaymentMethodP24Bank'ToyotaBank
        | PaymentMethodP24Bank'VolkswagenBank

    ///
    and PaymentMethodSepaDebit (bankCode: string option, branchCode: string option, country: string option, fingerprint: string option, generatedFrom: SepaDebitGeneratedFrom option, last4: string option) =

        member _.BankCode = bankCode
        member _.BranchCode = branchCode
        member _.Country = country
        member _.Fingerprint = fingerprint
        member _.GeneratedFrom = generatedFrom
        member _.Last4 = last4

    ///
    and PaymentMethodSofort (country: string option) =

        member _.Country = country

    ///
    and PaymentPagesCheckoutSessionTotalDetails (amountDiscount: int, amountTax: int, ?breakdown: PaymentPagesCheckoutSessionTotalDetailsResourceBreakdown) =

        member _.AmountDiscount = amountDiscount
        member _.AmountTax = amountTax
        member _.Breakdown = breakdown

    ///
    and PaymentPagesCheckoutSessionTotalDetailsResourceBreakdown (discounts: LineItemsDiscountAmount list, taxes: LineItemsTaxAmount list) =

        member _.Discounts = discounts
        member _.Taxes = taxes

    ///
    and PaymentPagesPaymentPageResourcesShippingAddressCollection (allowedCountries: PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries list) =

        member _.AllowedCountries = allowedCountries

    and PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries =
        | [<JsonUnionCase("AC")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'AC
        | [<JsonUnionCase("AD")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'AD
        | [<JsonUnionCase("AE")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'AE
        | [<JsonUnionCase("AF")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'AF
        | [<JsonUnionCase("AG")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'AG
        | [<JsonUnionCase("AI")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'AI
        | [<JsonUnionCase("AL")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'AL
        | [<JsonUnionCase("AM")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'AM
        | [<JsonUnionCase("AO")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'AO
        | [<JsonUnionCase("AQ")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'AQ
        | [<JsonUnionCase("AR")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'AR
        | [<JsonUnionCase("AT")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'AT
        | [<JsonUnionCase("AU")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'AU
        | [<JsonUnionCase("AW")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'AW
        | [<JsonUnionCase("AX")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'AX
        | [<JsonUnionCase("AZ")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'AZ
        | [<JsonUnionCase("BA")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'BA
        | [<JsonUnionCase("BB")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'BB
        | [<JsonUnionCase("BD")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'BD
        | [<JsonUnionCase("BE")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'BE
        | [<JsonUnionCase("BF")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'BF
        | [<JsonUnionCase("BG")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'BG
        | [<JsonUnionCase("BH")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'BH
        | [<JsonUnionCase("BI")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'BI
        | [<JsonUnionCase("BJ")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'BJ
        | [<JsonUnionCase("BL")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'BL
        | [<JsonUnionCase("BM")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'BM
        | [<JsonUnionCase("BN")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'BN
        | [<JsonUnionCase("BO")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'BO
        | [<JsonUnionCase("BQ")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'BQ
        | [<JsonUnionCase("BR")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'BR
        | [<JsonUnionCase("BS")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'BS
        | [<JsonUnionCase("BT")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'BT
        | [<JsonUnionCase("BV")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'BV
        | [<JsonUnionCase("BW")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'BW
        | [<JsonUnionCase("BY")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'BY
        | [<JsonUnionCase("BZ")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'BZ
        | [<JsonUnionCase("CA")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'CA
        | [<JsonUnionCase("CD")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'CD
        | [<JsonUnionCase("CF")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'CF
        | [<JsonUnionCase("CG")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'CG
        | [<JsonUnionCase("CH")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'CH
        | [<JsonUnionCase("CI")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'CI
        | [<JsonUnionCase("CK")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'CK
        | [<JsonUnionCase("CL")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'CL
        | [<JsonUnionCase("CM")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'CM
        | [<JsonUnionCase("CN")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'CN
        | [<JsonUnionCase("CO")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'CO
        | [<JsonUnionCase("CR")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'CR
        | [<JsonUnionCase("CV")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'CV
        | [<JsonUnionCase("CW")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'CW
        | [<JsonUnionCase("CY")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'CY
        | [<JsonUnionCase("CZ")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'CZ
        | [<JsonUnionCase("DE")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'DE
        | [<JsonUnionCase("DJ")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'DJ
        | [<JsonUnionCase("DK")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'DK
        | [<JsonUnionCase("DM")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'DM
        | [<JsonUnionCase("DO")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'DO
        | [<JsonUnionCase("DZ")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'DZ
        | [<JsonUnionCase("EC")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'EC
        | [<JsonUnionCase("EE")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'EE
        | [<JsonUnionCase("EG")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'EG
        | [<JsonUnionCase("EH")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'EH
        | [<JsonUnionCase("ER")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'ER
        | [<JsonUnionCase("ES")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'ES
        | [<JsonUnionCase("ET")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'ET
        | [<JsonUnionCase("FI")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'FI
        | [<JsonUnionCase("FJ")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'FJ
        | [<JsonUnionCase("FK")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'FK
        | [<JsonUnionCase("FO")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'FO
        | [<JsonUnionCase("FR")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'FR
        | [<JsonUnionCase("GA")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'GA
        | [<JsonUnionCase("GB")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'GB
        | [<JsonUnionCase("GD")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'GD
        | [<JsonUnionCase("GE")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'GE
        | [<JsonUnionCase("GF")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'GF
        | [<JsonUnionCase("GG")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'GG
        | [<JsonUnionCase("GH")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'GH
        | [<JsonUnionCase("GI")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'GI
        | [<JsonUnionCase("GL")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'GL
        | [<JsonUnionCase("GM")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'GM
        | [<JsonUnionCase("GN")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'GN
        | [<JsonUnionCase("GP")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'GP
        | [<JsonUnionCase("GQ")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'GQ
        | [<JsonUnionCase("GR")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'GR
        | [<JsonUnionCase("GS")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'GS
        | [<JsonUnionCase("GT")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'GT
        | [<JsonUnionCase("GU")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'GU
        | [<JsonUnionCase("GW")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'GW
        | [<JsonUnionCase("GY")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'GY
        | [<JsonUnionCase("HK")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'HK
        | [<JsonUnionCase("HN")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'HN
        | [<JsonUnionCase("HR")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'HR
        | [<JsonUnionCase("HT")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'HT
        | [<JsonUnionCase("HU")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'HU
        | [<JsonUnionCase("ID")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'ID
        | [<JsonUnionCase("IE")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'IE
        | [<JsonUnionCase("IL")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'IL
        | [<JsonUnionCase("IM")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'IM
        | [<JsonUnionCase("IN")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'IN
        | [<JsonUnionCase("IO")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'IO
        | [<JsonUnionCase("IQ")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'IQ
        | [<JsonUnionCase("IS")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'IS
        | [<JsonUnionCase("IT")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'IT
        | [<JsonUnionCase("JE")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'JE
        | [<JsonUnionCase("JM")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'JM
        | [<JsonUnionCase("JO")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'JO
        | [<JsonUnionCase("JP")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'JP
        | [<JsonUnionCase("KE")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'KE
        | [<JsonUnionCase("KG")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'KG
        | [<JsonUnionCase("KH")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'KH
        | [<JsonUnionCase("KI")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'KI
        | [<JsonUnionCase("KM")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'KM
        | [<JsonUnionCase("KN")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'KN
        | [<JsonUnionCase("KR")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'KR
        | [<JsonUnionCase("KW")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'KW
        | [<JsonUnionCase("KY")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'KY
        | [<JsonUnionCase("KZ")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'KZ
        | [<JsonUnionCase("LA")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'LA
        | [<JsonUnionCase("LB")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'LB
        | [<JsonUnionCase("LC")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'LC
        | [<JsonUnionCase("LI")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'LI
        | [<JsonUnionCase("LK")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'LK
        | [<JsonUnionCase("LR")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'LR
        | [<JsonUnionCase("LS")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'LS
        | [<JsonUnionCase("LT")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'LT
        | [<JsonUnionCase("LU")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'LU
        | [<JsonUnionCase("LV")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'LV
        | [<JsonUnionCase("LY")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'LY
        | [<JsonUnionCase("MA")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'MA
        | [<JsonUnionCase("MC")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'MC
        | [<JsonUnionCase("MD")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'MD
        | [<JsonUnionCase("ME")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'ME
        | [<JsonUnionCase("MF")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'MF
        | [<JsonUnionCase("MG")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'MG
        | [<JsonUnionCase("MK")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'MK
        | [<JsonUnionCase("ML")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'ML
        | [<JsonUnionCase("MM")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'MM
        | [<JsonUnionCase("MN")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'MN
        | [<JsonUnionCase("MO")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'MO
        | [<JsonUnionCase("MQ")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'MQ
        | [<JsonUnionCase("MR")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'MR
        | [<JsonUnionCase("MS")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'MS
        | [<JsonUnionCase("MT")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'MT
        | [<JsonUnionCase("MU")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'MU
        | [<JsonUnionCase("MV")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'MV
        | [<JsonUnionCase("MW")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'MW
        | [<JsonUnionCase("MX")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'MX
        | [<JsonUnionCase("MY")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'MY
        | [<JsonUnionCase("MZ")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'MZ
        | [<JsonUnionCase("NA")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'NA
        | [<JsonUnionCase("NC")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'NC
        | [<JsonUnionCase("NE")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'NE
        | [<JsonUnionCase("NG")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'NG
        | [<JsonUnionCase("NI")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'NI
        | [<JsonUnionCase("NL")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'NL
        | [<JsonUnionCase("NO")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'NO
        | [<JsonUnionCase("NP")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'NP
        | [<JsonUnionCase("NR")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'NR
        | [<JsonUnionCase("NU")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'NU
        | [<JsonUnionCase("NZ")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'NZ
        | [<JsonUnionCase("OM")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'OM
        | [<JsonUnionCase("PA")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'PA
        | [<JsonUnionCase("PE")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'PE
        | [<JsonUnionCase("PF")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'PF
        | [<JsonUnionCase("PG")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'PG
        | [<JsonUnionCase("PH")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'PH
        | [<JsonUnionCase("PK")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'PK
        | [<JsonUnionCase("PL")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'PL
        | [<JsonUnionCase("PM")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'PM
        | [<JsonUnionCase("PN")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'PN
        | [<JsonUnionCase("PR")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'PR
        | [<JsonUnionCase("PS")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'PS
        | [<JsonUnionCase("PT")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'PT
        | [<JsonUnionCase("PY")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'PY
        | [<JsonUnionCase("QA")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'QA
        | [<JsonUnionCase("RE")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'RE
        | [<JsonUnionCase("RO")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'RO
        | [<JsonUnionCase("RS")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'RS
        | [<JsonUnionCase("RU")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'RU
        | [<JsonUnionCase("RW")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'RW
        | [<JsonUnionCase("SA")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'SA
        | [<JsonUnionCase("SB")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'SB
        | [<JsonUnionCase("SC")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'SC
        | [<JsonUnionCase("SE")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'SE
        | [<JsonUnionCase("SG")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'SG
        | [<JsonUnionCase("SH")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'SH
        | [<JsonUnionCase("SI")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'SI
        | [<JsonUnionCase("SJ")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'SJ
        | [<JsonUnionCase("SK")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'SK
        | [<JsonUnionCase("SL")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'SL
        | [<JsonUnionCase("SM")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'SM
        | [<JsonUnionCase("SN")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'SN
        | [<JsonUnionCase("SO")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'SO
        | [<JsonUnionCase("SR")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'SR
        | [<JsonUnionCase("SS")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'SS
        | [<JsonUnionCase("ST")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'ST
        | [<JsonUnionCase("SV")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'SV
        | [<JsonUnionCase("SX")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'SX
        | [<JsonUnionCase("SZ")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'SZ
        | [<JsonUnionCase("TA")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'TA
        | [<JsonUnionCase("TC")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'TC
        | [<JsonUnionCase("TD")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'TD
        | [<JsonUnionCase("TF")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'TF
        | [<JsonUnionCase("TG")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'TG
        | [<JsonUnionCase("TH")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'TH
        | [<JsonUnionCase("TJ")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'TJ
        | [<JsonUnionCase("TK")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'TK
        | [<JsonUnionCase("TL")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'TL
        | [<JsonUnionCase("TM")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'TM
        | [<JsonUnionCase("TN")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'TN
        | [<JsonUnionCase("TO")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'TO
        | [<JsonUnionCase("TR")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'TR
        | [<JsonUnionCase("TT")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'TT
        | [<JsonUnionCase("TV")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'TV
        | [<JsonUnionCase("TW")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'TW
        | [<JsonUnionCase("TZ")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'TZ
        | [<JsonUnionCase("UA")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'UA
        | [<JsonUnionCase("UG")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'UG
        | [<JsonUnionCase("US")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'US
        | [<JsonUnionCase("UY")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'UY
        | [<JsonUnionCase("UZ")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'UZ
        | [<JsonUnionCase("VA")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'VA
        | [<JsonUnionCase("VC")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'VC
        | [<JsonUnionCase("VE")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'VE
        | [<JsonUnionCase("VG")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'VG
        | [<JsonUnionCase("VN")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'VN
        | [<JsonUnionCase("VU")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'VU
        | [<JsonUnionCase("WF")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'WF
        | [<JsonUnionCase("WS")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'WS
        | [<JsonUnionCase("XK")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'XK
        | [<JsonUnionCase("YE")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'YE
        | [<JsonUnionCase("YT")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'YT
        | [<JsonUnionCase("ZA")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'ZA
        | [<JsonUnionCase("ZM")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'ZM
        | [<JsonUnionCase("ZW")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'ZW
        | [<JsonUnionCase("ZZ")>] PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries'ZZ

    and PaymentSource =
        | PaymentSource'Account of Account
        | PaymentSource'AlipayAccount of AlipayAccount
        | PaymentSource'BankAccount of BankAccount
        | PaymentSource'BitcoinReceiver of BitcoinReceiver
        | PaymentSource'Card of Card
        | PaymentSource'Source of Source

    ///A `Payout` object is created when you receive funds from Stripe, or when you
    ///initiate a payout to either a bank account or debit card of a [connected
    ///Stripe account](/docs/connect/bank-debit-card-payouts). You can retrieve individual payouts,
    ///as well as list all payouts. Payouts are made on [varying
    ///schedules](/docs/connect/manage-payout-schedule), depending on your country and
    ///industry.
    ///
    ///Related guide: [Receiving Payouts](https://stripe.com/docs/payouts).
    and Payout (amount: int, arrivalDate: int, automatic: bool, balanceTransaction: PayoutBalanceTransactionDU option, created: int, currency: string, description: string option, destination: PayoutDestinationDU option, failureBalanceTransaction: PayoutFailureBalanceTransactionDU option, failureCode: string option, failureMessage: string option, id: string, livemode: bool, metadata: Map<string, string> option, method: string, object: PayoutObject, originalPayout: PayoutOriginalPayoutDU option, reversedBy: PayoutReversedByDU option, sourceType: string, statementDescriptor: string option, status: string, ``type``: PayoutType) =

        member _.Amount = amount
        member _.ArrivalDate = arrivalDate
        member _.Automatic = automatic
        member _.BalanceTransaction = balanceTransaction
        member _.Created = created
        member _.Currency = currency
        member _.Description = description
        member _.Destination = destination
        member _.FailureBalanceTransaction = failureBalanceTransaction
        member _.FailureCode = failureCode
        member _.FailureMessage = failureMessage
        member _.Id = id
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Method = method
        member _.Object = object
        member _.OriginalPayout = originalPayout
        member _.ReversedBy = reversedBy
        member _.SourceType = sourceType
        member _.StatementDescriptor = statementDescriptor
        member _.Status = status
        member _.Type = ``type``

    and PayoutObject =
        | PayoutObject'Payout

    and PayoutType =
        | PayoutType'BankAccount
        | PayoutType'Card

    and PayoutBalanceTransactionDU =
        | PayoutBalanceTransactionDU'String of string
        | PayoutBalanceTransactionDU'BalanceTransaction of BalanceTransaction

    and PayoutDestinationDU =
        | PayoutDestinationDU'String of string
        | PayoutDestinationDU'ExternalAccount of ExternalAccount
        | PayoutDestinationDU'DeletedExternalAccount of DeletedExternalAccount

    and PayoutFailureBalanceTransactionDU =
        | PayoutFailureBalanceTransactionDU'String of string
        | PayoutFailureBalanceTransactionDU'BalanceTransaction of BalanceTransaction

    and PayoutOriginalPayoutDU =
        | PayoutOriginalPayoutDU'String of string
        | PayoutOriginalPayoutDU'Payout of Payout

    and PayoutReversedByDU =
        | PayoutReversedByDU'String of string
        | PayoutReversedByDU'Payout of Payout

    ///
    and Period (``end``: int option, start: int option) =

        member _.End = ``end``
        member _.Start = start

    ///This is an object representing a person associated with a Stripe account.
    ///
    ///Related guide: [Handling Identity Verification with the API](https://stripe.com/docs/connect/identity-verification-api#person-information).
    and Person (created: int, id: string, object: PersonObject, ?account: string, ?address: Address, ?addressKana: LegalEntityJapanAddress option, ?addressKanji: LegalEntityJapanAddress option, ?dob: LegalEntityDob, ?email: string option, ?firstName: string option, ?firstNameKana: string option, ?firstNameKanji: string option, ?gender: string option, ?idNumberProvided: bool, ?lastName: string option, ?lastNameKana: string option, ?lastNameKanji: string option, ?maidenName: string option, ?metadata: Map<string, string>, ?phone: string option, ?politicalExposure: PersonPoliticalExposure, ?relationship: PersonRelationship, ?requirements: PersonRequirements option, ?ssnLast4Provided: bool, ?verification: LegalEntityPersonVerification) =

        member _.Account = account
        member _.Address = address
        member _.AddressKana = addressKana |> Option.flatten
        member _.AddressKanji = addressKanji |> Option.flatten
        member _.Created = created
        member _.Dob = dob
        member _.Email = email |> Option.flatten
        member _.FirstName = firstName |> Option.flatten
        member _.FirstNameKana = firstNameKana |> Option.flatten
        member _.FirstNameKanji = firstNameKanji |> Option.flatten
        member _.Gender = gender |> Option.flatten
        member _.Id = id
        member _.IdNumberProvided = idNumberProvided
        member _.LastName = lastName |> Option.flatten
        member _.LastNameKana = lastNameKana |> Option.flatten
        member _.LastNameKanji = lastNameKanji |> Option.flatten
        member _.MaidenName = maidenName |> Option.flatten
        member _.Metadata = metadata
        member _.Object = object
        member _.Phone = phone |> Option.flatten
        member _.PoliticalExposure = politicalExposure
        member _.Relationship = relationship
        member _.Requirements = requirements |> Option.flatten
        member _.SsnLast4Provided = ssnLast4Provided
        member _.Verification = verification

    and PersonObject =
        | PersonObject'Person

    and PersonPoliticalExposure =
        | PersonPoliticalExposure'Existing
        | PersonPoliticalExposure'None

    ///
    and PersonRelationship (director: bool option, executive: bool option, owner: bool option, percentOwnership: decimal option, representative: bool option, title: string option) =

        member _.Director = director
        member _.Executive = executive
        member _.Owner = owner
        member _.PercentOwnership = percentOwnership
        member _.Representative = representative
        member _.Title = title

    ///
    and PersonRequirements (currentlyDue: string list, errors: AccountRequirementsError list, eventuallyDue: string list, pastDue: string list, pendingVerification: string list) =

        member _.CurrentlyDue = currentlyDue
        member _.Errors = errors
        member _.EventuallyDue = eventuallyDue
        member _.PastDue = pastDue
        member _.PendingVerification = pendingVerification

    ///You can now model subscriptions more flexibly using the [Prices API](https://stripe.com/docs/api#prices). It replaces the Plans API and is backwards compatible to simplify your migration.
    ///
    ///Plans define the base price, currency, and billing cycle for recurring purchases of products.
    ///[Products](https://stripe.com/docs/api#products) help you track inventory or provisioning, and plans help you track pricing. Different physical goods or levels of service should be represented by products, and pricing options should be represented by plans. This approach lets you change prices without having to change your provisioning scheme.
    ///
    ///For example, you might have a single "gold" product that has plans for $10/month, $100/year, €9/month, and €90/year.
    ///
    ///Related guides: [Set up a subscription](https://stripe.com/docs/billing/subscriptions/set-up-subscription) and more about [products and prices](https://stripe.com/docs/billing/prices-guide).
    and Plan (active: bool, aggregateUsage: PlanAggregateUsage option, amount: int option, amountDecimal: string option, billingScheme: PlanBillingScheme, created: int, currency: string, id: string, interval: PlanInterval, intervalCount: int, livemode: bool, metadata: Map<string, string> option, nickname: string option, object: PlanObject, product: PlanProductDU option, tiersMode: PlanTiersMode option, transformUsage: TransformUsage option, trialPeriodDays: int option, usageType: PlanUsageType, ?tiers: PlanTier list) =

        member _.Active = active
        member _.AggregateUsage = aggregateUsage
        member _.Amount = amount
        member _.AmountDecimal = amountDecimal
        member _.BillingScheme = billingScheme
        member _.Created = created
        member _.Currency = currency
        member _.Id = id
        member _.Interval = interval
        member _.IntervalCount = intervalCount
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Nickname = nickname
        member _.Object = object
        member _.Product = product
        member _.Tiers = tiers
        member _.TiersMode = tiersMode
        member _.TransformUsage = transformUsage
        member _.TrialPeriodDays = trialPeriodDays
        member _.UsageType = usageType

    and PlanAggregateUsage =
        | PlanAggregateUsage'LastDuringPeriod
        | PlanAggregateUsage'LastEver
        | PlanAggregateUsage'Max
        | PlanAggregateUsage'Sum

    and PlanBillingScheme =
        | PlanBillingScheme'PerUnit
        | PlanBillingScheme'Tiered

    and PlanInterval =
        | PlanInterval'Day
        | PlanInterval'Month
        | PlanInterval'Week
        | PlanInterval'Year

    and PlanObject =
        | PlanObject'Plan

    and PlanTiersMode =
        | PlanTiersMode'Graduated
        | PlanTiersMode'Volume

    and PlanUsageType =
        | PlanUsageType'Licensed
        | PlanUsageType'Metered

    and PlanProductDU =
        | PlanProductDU'String of string
        | PlanProductDU'Product of Product
        | PlanProductDU'DeletedProduct of DeletedProduct

    ///
    and PlanTier (flatAmount: int option, flatAmountDecimal: string option, unitAmount: int option, unitAmountDecimal: string option, upTo: int option) =

        member _.FlatAmount = flatAmount
        member _.FlatAmountDecimal = flatAmountDecimal
        member _.UnitAmount = unitAmount
        member _.UnitAmountDecimal = unitAmountDecimal
        member _.UpTo = upTo

    ///
    and PlatformTaxFee (account: string, id: string, object: PlatformTaxFeeObject, sourceTransaction: string, ``type``: string) =

        member _.Account = account
        member _.Id = id
        member _.Object = object
        member _.SourceTransaction = sourceTransaction
        member _.Type = ``type``

    and PlatformTaxFeeObject =
        | PlatformTaxFeeObject'PlatformTaxFee

    ///Prices define the unit cost, currency, and (optional) billing cycle for both recurring and one-time purchases of products.
    ///[Products](https://stripe.com/docs/api#products) help you track inventory or provisioning, and prices help you track payment terms. Different physical goods or levels of service should be represented by products, and pricing options should be represented by prices. This approach lets you change prices without having to change your provisioning scheme.
    ///
    ///For example, you might have a single "gold" product that has prices for $10/month, $100/year, and €9 once.
    ///
    ///Related guides: [Set up a subscription](https://stripe.com/docs/billing/subscriptions/set-up-subscription), [create an invoice](https://stripe.com/docs/billing/invoices/create), and more about [products and prices](https://stripe.com/docs/billing/prices-guide).
    and Price (active: bool, billingScheme: PriceBillingScheme, created: int, currency: string, id: string, livemode: bool, lookupKey: string option, metadata: Map<string, string>, nickname: string option, object: PriceObject, product: PriceProductDU, recurring: Recurring option, tiersMode: PriceTiersMode option, transformQuantity: TransformQuantity option, ``type``: PriceType, unitAmount: int option, unitAmountDecimal: string option, ?tiers: PriceTier list) =

        member _.Active = active
        member _.BillingScheme = billingScheme
        member _.Created = created
        member _.Currency = currency
        member _.Id = id
        member _.Livemode = livemode
        member _.LookupKey = lookupKey
        member _.Metadata = metadata
        member _.Nickname = nickname
        member _.Object = object
        member _.Product = product
        member _.Recurring = recurring
        member _.Tiers = tiers
        member _.TiersMode = tiersMode
        member _.TransformQuantity = transformQuantity
        member _.Type = ``type``
        member _.UnitAmount = unitAmount
        member _.UnitAmountDecimal = unitAmountDecimal

    and PriceBillingScheme =
        | PriceBillingScheme'PerUnit
        | PriceBillingScheme'Tiered

    and PriceObject =
        | PriceObject'Price

    and PriceTiersMode =
        | PriceTiersMode'Graduated
        | PriceTiersMode'Volume

    and PriceType =
        | PriceType'OneTime
        | PriceType'Recurring

    and PriceProductDU =
        | PriceProductDU'String of string
        | PriceProductDU'Product of Product
        | PriceProductDU'DeletedProduct of DeletedProduct

    ///
    and PriceTier (flatAmount: int option, flatAmountDecimal: string option, unitAmount: int option, unitAmountDecimal: string option, upTo: int option) =

        member _.FlatAmount = flatAmount
        member _.FlatAmountDecimal = flatAmountDecimal
        member _.UnitAmount = unitAmount
        member _.UnitAmountDecimal = unitAmountDecimal
        member _.UpTo = upTo

    ///Products describe the specific goods or services you offer to your customers.
    ///For example, you might offer a Standard and Premium version of your goods or service; each version would be a separate Product.
    ///They can be used in conjunction with [Prices](https://stripe.com/docs/api#prices) to configure pricing in Checkout and Subscriptions.
    ///
    ///Related guides: [Set up a subscription](https://stripe.com/docs/billing/subscriptions/set-up-subscription) or accept [one-time payments with Checkout](https://stripe.com/docs/payments/checkout/client#create-products) and more about [Products and Prices](https://stripe.com/docs/billing/prices-guide)
    and Product (active: bool, attributes: string list option, caption: string option, created: int, description: string option, id: string, images: string list, livemode: bool, metadata: Map<string, string>, name: string, object: ProductObject, packageDimensions: PackageDimensions option, shippable: bool option, statementDescriptor: string option, ``type``: ProductType, unitLabel: string option, updated: int, url: string option, ?deactivateOn: string list) =

        member _.Active = active
        member _.Attributes = attributes
        member _.Caption = caption
        member _.Created = created
        member _.DeactivateOn = deactivateOn
        member _.Description = description
        member _.Id = id
        member _.Images = images
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Name = name
        member _.Object = object
        member _.PackageDimensions = packageDimensions
        member _.Shippable = shippable
        member _.StatementDescriptor = statementDescriptor
        member _.Type = ``type``
        member _.UnitLabel = unitLabel
        member _.Updated = updated
        member _.Url = url

    and ProductObject =
        | ProductObject'Product

    and ProductType =
        | ProductType'Good
        | ProductType'Service

    ///A Promotion Code represents a customer-redeemable code for a coupon. It can be used to
    ///create multiple codes for a single coupon.
    and PromotionCode (active: bool, code: string, coupon: Coupon, created: int, customer: PromotionCodeCustomerDU option, expiresAt: int option, id: string, livemode: bool, maxRedemptions: int option, metadata: Map<string, string> option, object: PromotionCodeObject, restrictions: PromotionCodesResourceRestrictions, timesRedeemed: int) =

        member _.Active = active
        member _.Code = code
        member _.Coupon = coupon
        member _.Created = created
        member _.Customer = customer
        member _.ExpiresAt = expiresAt
        member _.Id = id
        member _.Livemode = livemode
        member _.MaxRedemptions = maxRedemptions
        member _.Metadata = metadata
        member _.Object = object
        member _.Restrictions = restrictions
        member _.TimesRedeemed = timesRedeemed

    and PromotionCodeObject =
        | PromotionCodeObject'PromotionCode

    and PromotionCodeCustomerDU =
        | PromotionCodeCustomerDU'String of string
        | PromotionCodeCustomerDU'Customer of Customer
        | PromotionCodeCustomerDU'DeletedCustomer of DeletedCustomer

    ///
    and PromotionCodesResourceRestrictions (firstTimeTransaction: bool, minimumAmount: int option, minimumAmountCurrency: string option) =

        member _.FirstTimeTransaction = firstTimeTransaction
        member _.MinimumAmount = minimumAmount
        member _.MinimumAmountCurrency = minimumAmountCurrency

    ///An early fraud warning indicates that the card issuer has notified us that a
    ///charge may be fraudulent.
    ///
    ///Related guide: [Early Fraud Warnings](https://stripe.com/docs/disputes/measuring#early-fraud-warnings).
    and RadarEarlyFraudWarning (actionable: bool, charge: RadarEarlyFraudWarningChargeDU, created: int, fraudType: string, id: string, livemode: bool, object: RadarEarlyFraudWarningObject) =

        member _.Actionable = actionable
        member _.Charge = charge
        member _.Created = created
        member _.FraudType = fraudType
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = object

    and RadarEarlyFraudWarningObject =
        | RadarEarlyFraudWarningObject'RadarEarlyFraudWarning

    and RadarEarlyFraudWarningChargeDU =
        | RadarEarlyFraudWarningChargeDU'String of string
        | RadarEarlyFraudWarningChargeDU'Charge of Charge

    ///Value lists allow you to group values together which can then be referenced in rules.
    ///
    ///Related guide: [Default Stripe Lists](https://stripe.com/docs/radar/lists#managing-list-items).
    and RadarValueList (alias: string, created: int, createdBy: string, id: string, itemType: RadarValueListItemType, listItems: Map<string, string>, livemode: bool, metadata: Map<string, string>, name: string, object: RadarValueListObject) =

        member _.Alias = alias
        member _.Created = created
        member _.CreatedBy = createdBy
        member _.Id = id
        member _.ItemType = itemType
        member _.ListItems = listItems
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Name = name
        member _.Object = object

    and RadarValueListItemType =
        | RadarValueListItemType'CardBin
        | RadarValueListItemType'CardFingerprint
        | RadarValueListItemType'CaseSensitiveString
        | RadarValueListItemType'Country
        | RadarValueListItemType'Email
        | RadarValueListItemType'IpAddress
        | RadarValueListItemType'String

    and RadarValueListObject =
        | RadarValueListObject'RadarValueList

    ///Value list items allow you to add specific values to a given Radar value list, which can then be used in rules.
    ///
    ///Related guide: [Managing List Items](https://stripe.com/docs/radar/lists#managing-list-items).
    and RadarValueListItem (created: int, createdBy: string, id: string, livemode: bool, object: RadarValueListItemObject, value: string, valueList: string) =

        member _.Created = created
        member _.CreatedBy = createdBy
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = object
        member _.Value = value
        member _.ValueList = valueList

    and RadarValueListItemObject =
        | RadarValueListItemObject'RadarValueListItem

    ///
    and RadarReviewResourceLocation (city: string option, country: string option, latitude: decimal option, longitude: decimal option, region: string option) =

        member _.City = city
        member _.Country = country
        member _.Latitude = latitude
        member _.Longitude = longitude
        member _.Region = region

    ///
    and RadarReviewResourceSession (browser: string option, device: string option, platform: string option, version: string option) =

        member _.Browser = browser
        member _.Device = device
        member _.Platform = platform
        member _.Version = version

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
    and Recipient (activeAccount: BankAccount option, cards: Map<string, string> option, created: int, defaultCard: RecipientDefaultCardDU option, description: string option, email: string option, id: string, livemode: bool, metadata: Map<string, string>, migratedTo: RecipientMigratedToDU option, name: string option, object: RecipientObject, ``type``: string, verified: bool, ?rolledBackFrom: RecipientRolledBackFromDU) =

        member _.ActiveAccount = activeAccount
        member _.Cards = cards
        member _.Created = created
        member _.DefaultCard = defaultCard
        member _.Description = description
        member _.Email = email
        member _.Id = id
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.MigratedTo = migratedTo
        member _.Name = name
        member _.Object = object
        member _.RolledBackFrom = rolledBackFrom
        member _.Type = ``type``
        member _.Verified = verified

    and RecipientObject =
        | RecipientObject'Recipient

    and RecipientDefaultCardDU =
        | RecipientDefaultCardDU'String of string
        | RecipientDefaultCardDU'Card of Card

    and RecipientMigratedToDU =
        | RecipientMigratedToDU'String of string
        | RecipientMigratedToDU'Account of Account

    and RecipientRolledBackFromDU =
        | RecipientRolledBackFromDU'String of string
        | RecipientRolledBackFromDU'Account of Account

    ///
    and Recurring (aggregateUsage: RecurringAggregateUsage option, interval: RecurringInterval, intervalCount: int, trialPeriodDays: int option, usageType: RecurringUsageType) =

        member _.AggregateUsage = aggregateUsage
        member _.Interval = interval
        member _.IntervalCount = intervalCount
        member _.TrialPeriodDays = trialPeriodDays
        member _.UsageType = usageType

    and RecurringAggregateUsage =
        | RecurringAggregateUsage'LastDuringPeriod
        | RecurringAggregateUsage'LastEver
        | RecurringAggregateUsage'Max
        | RecurringAggregateUsage'Sum

    and RecurringInterval =
        | RecurringInterval'Day
        | RecurringInterval'Month
        | RecurringInterval'Week
        | RecurringInterval'Year

    and RecurringUsageType =
        | RecurringUsageType'Licensed
        | RecurringUsageType'Metered

    ///`Refund` objects allow you to refund a charge that has previously been created
    ///but not yet refunded. Funds will be refunded to the credit or debit card that
    ///was originally charged.
    ///
    ///Related guide: [Refunds](https://stripe.com/docs/refunds).
    and Refund (amount: int, balanceTransaction: RefundBalanceTransactionDU option, charge: RefundChargeDU option, created: int, currency: string, id: string, metadata: Map<string, string> option, object: RefundObject, paymentIntent: RefundPaymentIntentDU option, reason: string option, receiptNumber: string option, sourceTransferReversal: RefundSourceTransferReversalDU option, status: string option, transferReversal: RefundTransferReversalDU option, ?description: string, ?failureBalanceTransaction: RefundFailureBalanceTransactionDU, ?failureReason: string) =

        member _.Amount = amount
        member _.BalanceTransaction = balanceTransaction
        member _.Charge = charge
        member _.Created = created
        member _.Currency = currency
        member _.Description = description
        member _.FailureBalanceTransaction = failureBalanceTransaction
        member _.FailureReason = failureReason
        member _.Id = id
        member _.Metadata = metadata
        member _.Object = object
        member _.PaymentIntent = paymentIntent
        member _.Reason = reason
        member _.ReceiptNumber = receiptNumber
        member _.SourceTransferReversal = sourceTransferReversal
        member _.Status = status
        member _.TransferReversal = transferReversal

    and RefundObject =
        | RefundObject'Refund

    and RefundBalanceTransactionDU =
        | RefundBalanceTransactionDU'String of string
        | RefundBalanceTransactionDU'BalanceTransaction of BalanceTransaction

    and RefundChargeDU =
        | RefundChargeDU'String of string
        | RefundChargeDU'Charge of Charge

    and RefundFailureBalanceTransactionDU =
        | RefundFailureBalanceTransactionDU'String of string
        | RefundFailureBalanceTransactionDU'BalanceTransaction of BalanceTransaction

    and RefundPaymentIntentDU =
        | RefundPaymentIntentDU'String of string
        | RefundPaymentIntentDU'PaymentIntent of PaymentIntent

    and RefundSourceTransferReversalDU =
        | RefundSourceTransferReversalDU'String of string
        | RefundSourceTransferReversalDU'TransferReversal of TransferReversal

    and RefundTransferReversalDU =
        | RefundTransferReversalDU'String of string
        | RefundTransferReversalDU'TransferReversal of TransferReversal

    ///The Report Run object represents an instance of a report type generated with
    ///specific run parameters. Once the object is created, Stripe begins processing the report.
    ///When the report has finished running, it will give you a reference to a file
    ///where you can retrieve your results. For an overview, see
    ///[API Access to Reports](https://stripe.com/docs/reporting/statements/api).
    ///
    ///Note that reports can only be run based on your live-mode data (not test-mode
    ///data), and thus related requests must be made with a
    ///[live-mode API key](https://stripe.com/docs/keys#test-live-modes).
    and ReportingReportRun (created: int, error: string option, id: string, livemode: bool, object: ReportingReportRunObject, parameters: FinancialReportingFinanceReportRunRunParameters, reportType: string, result: File option, status: string, succeededAt: int option) =

        member _.Created = created
        member _.Error = error
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = object
        member _.Parameters = parameters
        member _.ReportType = reportType
        member _.Result = result
        member _.Status = status
        member _.SucceededAt = succeededAt

    and ReportingReportRunObject =
        | ReportingReportRunObject'ReportingReportRun

    ///The Report Type resource corresponds to a particular type of report, such as
    ///the "Activity summary" or "Itemized payouts" reports. These objects are
    ///identified by an ID belonging to a set of enumerated values. See
    ///[API Access to Reports documentation](https://stripe.com/docs/reporting/statements/api)
    ///for those Report Type IDs, along with required and optional parameters.
    ///
    ///Note that reports can only be run based on your live-mode data (not test-mode
    ///data), and thus related requests must be made with a
    ///[live-mode API key](https://stripe.com/docs/keys#test-live-modes).
    and ReportingReportType (dataAvailableEnd: int, dataAvailableStart: int, defaultColumns: string list option, id: string, name: string, object: ReportingReportTypeObject, updated: int, version: int) =

        member _.DataAvailableEnd = dataAvailableEnd
        member _.DataAvailableStart = dataAvailableStart
        member _.DefaultColumns = defaultColumns
        member _.Id = id
        member _.Name = name
        member _.Object = object
        member _.Updated = updated
        member _.Version = version

    and ReportingReportTypeObject =
        | ReportingReportTypeObject'ReportingReportType

    ///
    and ReserveTransaction (amount: int, currency: string, description: string option, id: string, object: ReserveTransactionObject) =

        member _.Amount = amount
        member _.Currency = currency
        member _.Description = description
        member _.Id = id
        member _.Object = object

    and ReserveTransactionObject =
        | ReserveTransactionObject'ReserveTransaction

    ///Reviews can be used to supplement automated fraud detection with human expertise.
    ///
    ///Learn more about [Radar](/radar) and reviewing payments
    ///[here](https://stripe.com/docs/radar/reviews).
    and Review (billingZip: string option, charge: ReviewChargeDU option, closedReason: ReviewClosedReason option, created: int, id: string, ipAddress: string option, ipAddressLocation: RadarReviewResourceLocation option, livemode: bool, object: ReviewObject, ``open``: bool, openedReason: ReviewOpenedReason, reason: string, session: RadarReviewResourceSession option, ?paymentIntent: ReviewPaymentIntentDU) =

        member _.BillingZip = billingZip
        member _.Charge = charge
        member _.ClosedReason = closedReason
        member _.Created = created
        member _.Id = id
        member _.IpAddress = ipAddress
        member _.IpAddressLocation = ipAddressLocation
        member _.Livemode = livemode
        member _.Object = object
        member _.Open = ``open``
        member _.OpenedReason = openedReason
        member _.PaymentIntent = paymentIntent
        member _.Reason = reason
        member _.Session = session

    and ReviewClosedReason =
        | ReviewClosedReason'Approved
        | ReviewClosedReason'Disputed
        | ReviewClosedReason'Refunded
        | ReviewClosedReason'RefundedAsFraud

    and ReviewObject =
        | ReviewObject'Review

    and ReviewOpenedReason =
        | ReviewOpenedReason'Manual
        | ReviewOpenedReason'Rule

    and ReviewChargeDU =
        | ReviewChargeDU'String of string
        | ReviewChargeDU'Charge of Charge

    and ReviewPaymentIntentDU =
        | ReviewPaymentIntentDU'String of string
        | ReviewPaymentIntentDU'PaymentIntent of PaymentIntent

    ///
    and Rule (action: string, id: string, predicate: string) =

        member _.Action = action
        member _.Id = id
        member _.Predicate = predicate

    ///If you have [scheduled a Sigma query](https://stripe.com/docs/sigma/scheduled-queries), you'll
    ///receive a `sigma.scheduled_query_run.created` webhook each time the query
    ///runs. The webhook contains a `ScheduledQueryRun` object, which you can use to
    ///retrieve the query results.
    and ScheduledQueryRun (created: int, dataLoadTime: int, file: File option, id: string, livemode: bool, object: ScheduledQueryRunObject, resultAvailableUntil: int, sql: string, status: string, title: string, ?error: SigmaScheduledQueryRunError) =

        member _.Created = created
        member _.DataLoadTime = dataLoadTime
        member _.Error = error
        member _.File = file
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = object
        member _.ResultAvailableUntil = resultAvailableUntil
        member _.Sql = sql
        member _.Status = status
        member _.Title = title

    and ScheduledQueryRunObject =
        | ScheduledQueryRunObject'ScheduledQueryRun

    ///
    and SepaDebitGeneratedFrom (charge: SepaDebitGeneratedFromChargeDU option, setupAttempt: SepaDebitGeneratedFromSetupAttemptDU option) =

        member _.Charge = charge
        member _.SetupAttempt = setupAttempt

    and SepaDebitGeneratedFromChargeDU =
        | SepaDebitGeneratedFromChargeDU'String of string
        | SepaDebitGeneratedFromChargeDU'Charge of Charge

    and SepaDebitGeneratedFromSetupAttemptDU =
        | SepaDebitGeneratedFromSetupAttemptDU'String of string
        | SepaDebitGeneratedFromSetupAttemptDU'SetupAttempt of SetupAttempt

    ///A SetupAttempt describes one attempted confirmation of a SetupIntent,
    ///whether that confirmation was successful or unsuccessful. You can use
    ///SetupAttempts to inspect details of a specific attempt at setting up a
    ///payment method using a SetupIntent.
    and SetupAttempt (application: SetupAttemptApplicationDU option, created: int, customer: SetupAttemptCustomerDU option, id: string, livemode: bool, object: SetupAttemptObject, onBehalfOf: SetupAttemptOnBehalfOfDU option, paymentMethod: SetupAttemptPaymentMethodDU, paymentMethodDetails: SetupAttemptPaymentMethodDetails, setupError: ApiErrors option, setupIntent: SetupAttemptSetupIntentDU, status: string, usage: string) =

        member _.Application = application
        member _.Created = created
        member _.Customer = customer
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = object
        member _.OnBehalfOf = onBehalfOf
        member _.PaymentMethod = paymentMethod
        member _.PaymentMethodDetails = paymentMethodDetails
        member _.SetupError = setupError
        member _.SetupIntent = setupIntent
        member _.Status = status
        member _.Usage = usage

    and SetupAttemptObject =
        | SetupAttemptObject'SetupAttempt

    and SetupAttemptApplicationDU =
        | SetupAttemptApplicationDU'String of string
        | SetupAttemptApplicationDU'Application of Application

    and SetupAttemptCustomerDU =
        | SetupAttemptCustomerDU'String of string
        | SetupAttemptCustomerDU'Customer of Customer
        | SetupAttemptCustomerDU'DeletedCustomer of DeletedCustomer

    and SetupAttemptOnBehalfOfDU =
        | SetupAttemptOnBehalfOfDU'String of string
        | SetupAttemptOnBehalfOfDU'Account of Account

    and SetupAttemptPaymentMethodDU =
        | SetupAttemptPaymentMethodDU'String of string
        | SetupAttemptPaymentMethodDU'PaymentMethod of PaymentMethod

    and SetupAttemptSetupIntentDU =
        | SetupAttemptSetupIntentDU'String of string
        | SetupAttemptSetupIntentDU'SetupIntent of SetupIntent

    ///
    and SetupAttemptPaymentMethodDetails (``type``: string, ?bancontact: SetupAttemptPaymentMethodDetailsBancontact, ?card: SetupAttemptPaymentMethodDetailsCard, ?ideal: SetupAttemptPaymentMethodDetailsIdeal, ?sofort: SetupAttemptPaymentMethodDetailsSofort) =

        member _.Bancontact = bancontact
        member _.Card = card
        member _.Ideal = ideal
        member _.Sofort = sofort
        member _.Type = ``type``

    ///
    and SetupAttemptPaymentMethodDetailsBancontact (bankCode: string option, bankName: string option, bic: string option, generatedSepaDebit: SetupAttemptPaymentMethodDetailsBancontactGeneratedSepaDebitDU option, generatedSepaDebitMandate: SetupAttemptPaymentMethodDetailsBancontactGeneratedSepaDebitMandateDU option, ibanLast4: string option, preferredLanguage: SetupAttemptPaymentMethodDetailsBancontactPreferredLanguage option, verifiedName: string option) =

        member _.BankCode = bankCode
        member _.BankName = bankName
        member _.Bic = bic
        member _.GeneratedSepaDebit = generatedSepaDebit
        member _.GeneratedSepaDebitMandate = generatedSepaDebitMandate
        member _.IbanLast4 = ibanLast4
        member _.PreferredLanguage = preferredLanguage
        member _.VerifiedName = verifiedName

    and SetupAttemptPaymentMethodDetailsBancontactPreferredLanguage =
        | SetupAttemptPaymentMethodDetailsBancontactPreferredLanguage'De
        | SetupAttemptPaymentMethodDetailsBancontactPreferredLanguage'En
        | SetupAttemptPaymentMethodDetailsBancontactPreferredLanguage'Fr
        | SetupAttemptPaymentMethodDetailsBancontactPreferredLanguage'Nl

    and SetupAttemptPaymentMethodDetailsBancontactGeneratedSepaDebitDU =
        | SetupAttemptPaymentMethodDetailsBancontactGeneratedSepaDebitDU'String of string
        | SetupAttemptPaymentMethodDetailsBancontactGeneratedSepaDebitDU'PaymentMethod of PaymentMethod

    and SetupAttemptPaymentMethodDetailsBancontactGeneratedSepaDebitMandateDU =
        | SetupAttemptPaymentMethodDetailsBancontactGeneratedSepaDebitMandateDU'String of string
        | SetupAttemptPaymentMethodDetailsBancontactGeneratedSepaDebitMandateDU'Mandate of Mandate

    ///
    and SetupAttemptPaymentMethodDetailsCard (threeDSecure: ThreeDSecureDetails option) =

        member _.ThreeDSecure = threeDSecure

    ///
    and SetupAttemptPaymentMethodDetailsIdeal (bank: SetupAttemptPaymentMethodDetailsIdealBank option, bic: SetupAttemptPaymentMethodDetailsIdealBic option, generatedSepaDebit: SetupAttemptPaymentMethodDetailsIdealGeneratedSepaDebitDU option, generatedSepaDebitMandate: SetupAttemptPaymentMethodDetailsIdealGeneratedSepaDebitMandateDU option, ibanLast4: string option, verifiedName: string option) =

        member _.Bank = bank
        member _.Bic = bic
        member _.GeneratedSepaDebit = generatedSepaDebit
        member _.GeneratedSepaDebitMandate = generatedSepaDebitMandate
        member _.IbanLast4 = ibanLast4
        member _.VerifiedName = verifiedName

    and SetupAttemptPaymentMethodDetailsIdealBank =
        | SetupAttemptPaymentMethodDetailsIdealBank'AbnAmro
        | SetupAttemptPaymentMethodDetailsIdealBank'AsnBank
        | SetupAttemptPaymentMethodDetailsIdealBank'Bunq
        | SetupAttemptPaymentMethodDetailsIdealBank'Handelsbanken
        | SetupAttemptPaymentMethodDetailsIdealBank'Ing
        | SetupAttemptPaymentMethodDetailsIdealBank'Knab
        | SetupAttemptPaymentMethodDetailsIdealBank'Moneyou
        | SetupAttemptPaymentMethodDetailsIdealBank'Rabobank
        | SetupAttemptPaymentMethodDetailsIdealBank'Regiobank
        | SetupAttemptPaymentMethodDetailsIdealBank'SnsBank
        | SetupAttemptPaymentMethodDetailsIdealBank'TriodosBank
        | SetupAttemptPaymentMethodDetailsIdealBank'VanLanschot

    and SetupAttemptPaymentMethodDetailsIdealBic =
        | [<JsonUnionCase("ABNANL2A")>] SetupAttemptPaymentMethodDetailsIdealBic'ABNANL2A
        | [<JsonUnionCase("ASNBNL21")>] SetupAttemptPaymentMethodDetailsIdealBic'ASNBNL21
        | [<JsonUnionCase("BUNQNL2A")>] SetupAttemptPaymentMethodDetailsIdealBic'BUNQNL2A
        | [<JsonUnionCase("FVLBNL22")>] SetupAttemptPaymentMethodDetailsIdealBic'FVLBNL22
        | [<JsonUnionCase("HANDNL2A")>] SetupAttemptPaymentMethodDetailsIdealBic'HANDNL2A
        | [<JsonUnionCase("INGBNL2A")>] SetupAttemptPaymentMethodDetailsIdealBic'INGBNL2A
        | [<JsonUnionCase("KNABNL2H")>] SetupAttemptPaymentMethodDetailsIdealBic'KNABNL2H
        | [<JsonUnionCase("MOYONL21")>] SetupAttemptPaymentMethodDetailsIdealBic'MOYONL21
        | [<JsonUnionCase("RABONL2U")>] SetupAttemptPaymentMethodDetailsIdealBic'RABONL2U
        | [<JsonUnionCase("RBRBNL21")>] SetupAttemptPaymentMethodDetailsIdealBic'RBRBNL21
        | [<JsonUnionCase("SNSBNL2A")>] SetupAttemptPaymentMethodDetailsIdealBic'SNSBNL2A
        | [<JsonUnionCase("TRIONL2U")>] SetupAttemptPaymentMethodDetailsIdealBic'TRIONL2U

    and SetupAttemptPaymentMethodDetailsIdealGeneratedSepaDebitDU =
        | SetupAttemptPaymentMethodDetailsIdealGeneratedSepaDebitDU'String of string
        | SetupAttemptPaymentMethodDetailsIdealGeneratedSepaDebitDU'PaymentMethod of PaymentMethod

    and SetupAttemptPaymentMethodDetailsIdealGeneratedSepaDebitMandateDU =
        | SetupAttemptPaymentMethodDetailsIdealGeneratedSepaDebitMandateDU'String of string
        | SetupAttemptPaymentMethodDetailsIdealGeneratedSepaDebitMandateDU'Mandate of Mandate

    ///
    and SetupAttemptPaymentMethodDetailsSofort (bankCode: string option, bankName: string option, bic: string option, generatedSepaDebit: SetupAttemptPaymentMethodDetailsSofortGeneratedSepaDebitDU option, generatedSepaDebitMandate: SetupAttemptPaymentMethodDetailsSofortGeneratedSepaDebitMandateDU option, ibanLast4: string option, preferredLanguage: SetupAttemptPaymentMethodDetailsSofortPreferredLanguage option, verifiedName: string option) =

        member _.BankCode = bankCode
        member _.BankName = bankName
        member _.Bic = bic
        member _.GeneratedSepaDebit = generatedSepaDebit
        member _.GeneratedSepaDebitMandate = generatedSepaDebitMandate
        member _.IbanLast4 = ibanLast4
        member _.PreferredLanguage = preferredLanguage
        member _.VerifiedName = verifiedName

    and SetupAttemptPaymentMethodDetailsSofortPreferredLanguage =
        | SetupAttemptPaymentMethodDetailsSofortPreferredLanguage'De
        | SetupAttemptPaymentMethodDetailsSofortPreferredLanguage'En
        | SetupAttemptPaymentMethodDetailsSofortPreferredLanguage'Fr
        | SetupAttemptPaymentMethodDetailsSofortPreferredLanguage'Nl

    and SetupAttemptPaymentMethodDetailsSofortGeneratedSepaDebitDU =
        | SetupAttemptPaymentMethodDetailsSofortGeneratedSepaDebitDU'String of string
        | SetupAttemptPaymentMethodDetailsSofortGeneratedSepaDebitDU'PaymentMethod of PaymentMethod

    and SetupAttemptPaymentMethodDetailsSofortGeneratedSepaDebitMandateDU =
        | SetupAttemptPaymentMethodDetailsSofortGeneratedSepaDebitMandateDU'String of string
        | SetupAttemptPaymentMethodDetailsSofortGeneratedSepaDebitMandateDU'Mandate of Mandate

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
    and SetupIntent (application: SetupIntentApplicationDU option, cancellationReason: SetupIntentCancellationReason option, clientSecret: string option, created: int, customer: SetupIntentCustomerDU option, description: string option, id: string, lastSetupError: ApiErrors option, latestAttempt: SetupIntentLatestAttemptDU option, livemode: bool, mandate: SetupIntentMandateDU option, metadata: Map<string, string> option, nextAction: SetupIntentNextAction option, object: SetupIntentObject, onBehalfOf: SetupIntentOnBehalfOfDU option, paymentMethod: SetupIntentPaymentMethodDU option, paymentMethodOptions: SetupIntentPaymentMethodOptions option, paymentMethodTypes: string list, singleUseMandate: SetupIntentSingleUseMandateDU option, status: SetupIntentStatus, usage: string) =

        member _.Application = application
        member _.CancellationReason = cancellationReason
        member _.ClientSecret = clientSecret
        member _.Created = created
        member _.Customer = customer
        member _.Description = description
        member _.Id = id
        member _.LastSetupError = lastSetupError
        member _.LatestAttempt = latestAttempt
        member _.Livemode = livemode
        member _.Mandate = mandate
        member _.Metadata = metadata
        member _.NextAction = nextAction
        member _.Object = object
        member _.OnBehalfOf = onBehalfOf
        member _.PaymentMethod = paymentMethod
        member _.PaymentMethodOptions = paymentMethodOptions
        member _.PaymentMethodTypes = paymentMethodTypes
        member _.SingleUseMandate = singleUseMandate
        member _.Status = status
        member _.Usage = usage

    and SetupIntentCancellationReason =
        | SetupIntentCancellationReason'Abandoned
        | SetupIntentCancellationReason'Duplicate
        | SetupIntentCancellationReason'RequestedByCustomer

    and SetupIntentObject =
        | SetupIntentObject'SetupIntent

    and SetupIntentStatus =
        | SetupIntentStatus'Canceled
        | SetupIntentStatus'Processing
        | SetupIntentStatus'RequiresAction
        | SetupIntentStatus'RequiresConfirmation
        | SetupIntentStatus'RequiresPaymentMethod
        | SetupIntentStatus'Succeeded

    and SetupIntentApplicationDU =
        | SetupIntentApplicationDU'String of string
        | SetupIntentApplicationDU'Application of Application

    and SetupIntentCustomerDU =
        | SetupIntentCustomerDU'String of string
        | SetupIntentCustomerDU'Customer of Customer
        | SetupIntentCustomerDU'DeletedCustomer of DeletedCustomer

    and SetupIntentLatestAttemptDU =
        | SetupIntentLatestAttemptDU'String of string
        | SetupIntentLatestAttemptDU'SetupAttempt of SetupAttempt

    and SetupIntentMandateDU =
        | SetupIntentMandateDU'String of string
        | SetupIntentMandateDU'Mandate of Mandate

    and SetupIntentOnBehalfOfDU =
        | SetupIntentOnBehalfOfDU'String of string
        | SetupIntentOnBehalfOfDU'Account of Account

    and SetupIntentPaymentMethodDU =
        | SetupIntentPaymentMethodDU'String of string
        | SetupIntentPaymentMethodDU'PaymentMethod of PaymentMethod

    and SetupIntentSingleUseMandateDU =
        | SetupIntentSingleUseMandateDU'String of string
        | SetupIntentSingleUseMandateDU'Mandate of Mandate

    ///
    and SetupIntentNextAction (``type``: string, ?redirectToUrl: SetupIntentNextActionRedirectToUrl, ?useStripeSdk: Map<string, string>) =

        member _.RedirectToUrl = redirectToUrl
        member _.Type = ``type``
        member _.UseStripeSdk = useStripeSdk

    ///
    and SetupIntentNextActionRedirectToUrl (returnUrl: string option, url: string option) =

        member _.ReturnUrl = returnUrl
        member _.Url = url

    ///
    and SetupIntentPaymentMethodOptions (?card: SetupIntentPaymentMethodOptionsCard, ?sepaDebit: SetupIntentPaymentMethodOptionsSepaDebit) =

        member _.Card = card
        member _.SepaDebit = sepaDebit

    ///
    and SetupIntentPaymentMethodOptionsCard (requestThreeDSecure: SetupIntentPaymentMethodOptionsCardRequestThreeDSecure option) =

        member _.RequestThreeDSecure = requestThreeDSecure

    and SetupIntentPaymentMethodOptionsCardRequestThreeDSecure =
        | SetupIntentPaymentMethodOptionsCardRequestThreeDSecure'Any
        | SetupIntentPaymentMethodOptionsCardRequestThreeDSecure'Automatic
        | SetupIntentPaymentMethodOptionsCardRequestThreeDSecure'ChallengeOnly

    ///
    and SetupIntentPaymentMethodOptionsMandateOptionsSepaDebit (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and SetupIntentPaymentMethodOptionsSepaDebit (?mandateOptions: SetupIntentPaymentMethodOptionsMandateOptionsSepaDebit) =

        member _.MandateOptions = mandateOptions

    ///
    and Shipping (?address: Address, ?carrier: string option, ?name: string option, ?phone: string option, ?trackingNumber: string option) =

        member _.Address = address
        member _.Carrier = carrier |> Option.flatten
        member _.Name = name |> Option.flatten
        member _.Phone = phone |> Option.flatten
        member _.TrackingNumber = trackingNumber |> Option.flatten

    ///
    and ShippingMethod (amount: int, currency: string, deliveryEstimate: DeliveryEstimate option, description: string, id: string) =

        member _.Amount = amount
        member _.Currency = currency
        member _.DeliveryEstimate = deliveryEstimate
        member _.Description = description
        member _.Id = id

    ///
    and SigmaScheduledQueryRunError (message: string) =

        member _.Message = message

    ///Stores representations of [stock keeping units](http://en.wikipedia.org/wiki/Stock_keeping_unit).
    ///SKUs describe specific product variations, taking into account any combination of: attributes,
    ///currency, and cost. For example, a product may be a T-shirt, whereas a specific SKU represents
    ///the `size: large`, `color: red` version of that shirt.
    ///
    ///Can also be used to manage inventory.
    ///
    ///Related guide: [Tax, Shipping, and Inventory](https://stripe.com/docs/orders).
    and Sku (active: bool, attributes: Map<string, string>, created: int, currency: string, id: string, image: string option, inventory: Inventory, livemode: bool, metadata: Map<string, string>, object: SkuObject, packageDimensions: PackageDimensions option, price: int, product: SkuProductDU, updated: int) =

        member _.Active = active
        member _.Attributes = attributes
        member _.Created = created
        member _.Currency = currency
        member _.Id = id
        member _.Image = image
        member _.Inventory = inventory
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Object = object
        member _.PackageDimensions = packageDimensions
        member _.Price = price
        member _.Product = product
        member _.Updated = updated

    and SkuObject =
        | SkuObject'Sku

    and SkuProductDU =
        | SkuProductDU'String of string
        | SkuProductDU'Product of Product

    ///`Source` objects allow you to accept a variety of payment methods. They
    ///represent a customer's payment instrument, and can be used with the Stripe API
    ///just like a `Card` object: once chargeable, they can be charged, or can be
    ///attached to customers.
    ///
    ///Related guides: [Sources API](https://stripe.com/docs/sources) and [Sources & Customers](https://stripe.com/docs/sources/customers).
    and Source (amount: int option, clientSecret: string, created: int, currency: string option, flow: string, id: string, livemode: bool, metadata: Map<string, string> option, object: SourceObject, owner: SourceOwner option, statementDescriptor: string option, status: string, ``type``: SourceType, usage: string option, ?achCreditTransfer: SourceTypeAchCreditTransfer, ?achDebit: SourceTypeAchDebit, ?acssDebit: SourceTypeAcssDebit, ?alipay: SourceTypeAlipay, ?auBecsDebit: SourceTypeAuBecsDebit, ?bancontact: SourceTypeBancontact, ?card: SourceTypeCard, ?cardPresent: SourceTypeCardPresent, ?codeVerification: SourceCodeVerificationFlow, ?customer: string, ?eps: SourceTypeEps, ?giropay: SourceTypeGiropay, ?ideal: SourceTypeIdeal, ?klarna: SourceTypeKlarna, ?multibanco: SourceTypeMultibanco, ?p24: SourceTypeP24, ?receiver: SourceReceiverFlow, ?redirect: SourceRedirectFlow, ?sepaCreditTransfer: SourceTypeSepaCreditTransfer, ?sepaDebit: SourceTypeSepaDebit, ?sofort: SourceTypeSofort, ?sourceOrder: SourceOrder, ?threeDSecure: SourceTypeThreeDSecure, ?wechat: SourceTypeWechat) =

        member _.AchCreditTransfer = achCreditTransfer
        member _.AchDebit = achDebit
        member _.AcssDebit = acssDebit
        member _.Alipay = alipay
        member _.Amount = amount
        member _.AuBecsDebit = auBecsDebit
        member _.Bancontact = bancontact
        member _.Card = card
        member _.CardPresent = cardPresent
        member _.ClientSecret = clientSecret
        member _.CodeVerification = codeVerification
        member _.Created = created
        member _.Currency = currency
        member _.Customer = customer
        member _.Eps = eps
        member _.Flow = flow
        member _.Giropay = giropay
        member _.Id = id
        member _.Ideal = ideal
        member _.Klarna = klarna
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Multibanco = multibanco
        member _.Object = object
        member _.Owner = owner
        member _.P24 = p24
        member _.Receiver = receiver
        member _.Redirect = redirect
        member _.SepaCreditTransfer = sepaCreditTransfer
        member _.SepaDebit = sepaDebit
        member _.Sofort = sofort
        member _.SourceOrder = sourceOrder
        member _.StatementDescriptor = statementDescriptor
        member _.Status = status
        member _.ThreeDSecure = threeDSecure
        member _.Type = ``type``
        member _.Usage = usage
        member _.Wechat = wechat

    and SourceObject =
        | SourceObject'Source

    and SourceType =
        | SourceType'AchCreditTransfer
        | SourceType'AchDebit
        | SourceType'AcssDebit
        | SourceType'Alipay
        | SourceType'AuBecsDebit
        | SourceType'Bancontact
        | SourceType'Card
        | SourceType'CardPresent
        | SourceType'Eps
        | SourceType'Giropay
        | SourceType'Ideal
        | SourceType'Klarna
        | SourceType'Multibanco
        | SourceType'P24
        | SourceType'SepaCreditTransfer
        | SourceType'SepaDebit
        | SourceType'Sofort
        | SourceType'ThreeDSecure
        | SourceType'Wechat

    ///
    and SourceCodeVerificationFlow (attemptsRemaining: int, status: string) =

        member _.AttemptsRemaining = attemptsRemaining
        member _.Status = status

    ///Source mandate notifications should be created when a notification related to
    ///a source mandate must be sent to the payer. They will trigger a webhook or
    ///deliver an email to the customer.
    and SourceMandateNotification (amount: int option, created: int, id: string, livemode: bool, object: SourceMandateNotificationObject, reason: string, source: Source, status: string, ``type``: string, ?acssDebit: SourceMandateNotificationAcssDebitData, ?bacsDebit: SourceMandateNotificationBacsDebitData, ?sepaDebit: SourceMandateNotificationSepaDebitData) =

        member _.AcssDebit = acssDebit
        member _.Amount = amount
        member _.BacsDebit = bacsDebit
        member _.Created = created
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = object
        member _.Reason = reason
        member _.SepaDebit = sepaDebit
        member _.Source = source
        member _.Status = status
        member _.Type = ``type``

    and SourceMandateNotificationObject =
        | SourceMandateNotificationObject'SourceMandateNotification

    ///
    and SourceMandateNotificationAcssDebitData (?statementDescriptor: string) =

        member _.StatementDescriptor = statementDescriptor

    ///
    and SourceMandateNotificationBacsDebitData (?last4: string) =

        member _.Last4 = last4

    ///
    and SourceMandateNotificationSepaDebitData (?creditorIdentifier: string, ?last4: string, ?mandateReference: string) =

        member _.CreditorIdentifier = creditorIdentifier
        member _.Last4 = last4
        member _.MandateReference = mandateReference

    ///
    and SourceOrder (amount: int, currency: string, items: SourceOrderItem list option, ?email: string, ?shipping: Shipping) =

        member _.Amount = amount
        member _.Currency = currency
        member _.Email = email
        member _.Items = items
        member _.Shipping = shipping

    ///
    and SourceOrderItem (amount: int option, currency: string option, description: string option, parent: string option, ``type``: string option, ?quantity: int) =

        member _.Amount = amount
        member _.Currency = currency
        member _.Description = description
        member _.Parent = parent
        member _.Quantity = quantity
        member _.Type = ``type``

    ///
    and SourceOwner (address: Address option, email: string option, name: string option, phone: string option, verifiedAddress: Address option, verifiedEmail: string option, verifiedName: string option, verifiedPhone: string option) =

        member _.Address = address
        member _.Email = email
        member _.Name = name
        member _.Phone = phone
        member _.VerifiedAddress = verifiedAddress
        member _.VerifiedEmail = verifiedEmail
        member _.VerifiedName = verifiedName
        member _.VerifiedPhone = verifiedPhone

    ///
    and SourceReceiverFlow (address: string option, amountCharged: int, amountReceived: int, amountReturned: int, refundAttributesMethod: string, refundAttributesStatus: string) =

        member _.Address = address
        member _.AmountCharged = amountCharged
        member _.AmountReceived = amountReceived
        member _.AmountReturned = amountReturned
        member _.RefundAttributesMethod = refundAttributesMethod
        member _.RefundAttributesStatus = refundAttributesStatus

    ///
    and SourceRedirectFlow (failureReason: string option, returnUrl: string, status: string, url: string) =

        member _.FailureReason = failureReason
        member _.ReturnUrl = returnUrl
        member _.Status = status
        member _.Url = url

    ///Some payment methods have no required amount that a customer must send.
    ///Customers can be instructed to send any amount, and it can be made up of
    ///multiple transactions. As such, sources can have multiple associated
    ///transactions.
    and SourceTransaction (amount: int, created: int, currency: string, id: string, livemode: bool, object: SourceTransactionObject, source: string, status: string, ``type``: SourceTransactionType, ?achCreditTransfer: SourceTransactionAchCreditTransferData, ?chfCreditTransfer: SourceTransactionChfCreditTransferData, ?gbpCreditTransfer: SourceTransactionGbpCreditTransferData, ?paperCheck: SourceTransactionPaperCheckData, ?sepaCreditTransfer: SourceTransactionSepaCreditTransferData) =

        member _.AchCreditTransfer = achCreditTransfer
        member _.Amount = amount
        member _.ChfCreditTransfer = chfCreditTransfer
        member _.Created = created
        member _.Currency = currency
        member _.GbpCreditTransfer = gbpCreditTransfer
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = object
        member _.PaperCheck = paperCheck
        member _.SepaCreditTransfer = sepaCreditTransfer
        member _.Source = source
        member _.Status = status
        member _.Type = ``type``

    and SourceTransactionObject =
        | SourceTransactionObject'SourceTransaction

    and SourceTransactionType =
        | SourceTransactionType'AchCreditTransfer
        | SourceTransactionType'AchDebit
        | SourceTransactionType'Alipay
        | SourceTransactionType'Bancontact
        | SourceTransactionType'Card
        | SourceTransactionType'CardPresent
        | SourceTransactionType'Eps
        | SourceTransactionType'Giropay
        | SourceTransactionType'Ideal
        | SourceTransactionType'Klarna
        | SourceTransactionType'Multibanco
        | SourceTransactionType'P24
        | SourceTransactionType'SepaDebit
        | SourceTransactionType'Sofort
        | SourceTransactionType'ThreeDSecure
        | SourceTransactionType'Wechat

    ///
    and SourceTransactionAchCreditTransferData (?customerData: string, ?fingerprint: string, ?last4: string, ?routingNumber: string) =

        member _.CustomerData = customerData
        member _.Fingerprint = fingerprint
        member _.Last4 = last4
        member _.RoutingNumber = routingNumber

    ///
    and SourceTransactionChfCreditTransferData (?reference: string, ?senderAddressCountry: string, ?senderAddressLine1: string, ?senderIban: string, ?senderName: string) =

        member _.Reference = reference
        member _.SenderAddressCountry = senderAddressCountry
        member _.SenderAddressLine1 = senderAddressLine1
        member _.SenderIban = senderIban
        member _.SenderName = senderName

    ///
    and SourceTransactionGbpCreditTransferData (?fingerprint: string, ?fundingMethod: string, ?last4: string, ?reference: string, ?senderAccountNumber: string, ?senderName: string, ?senderSortCode: string) =

        member _.Fingerprint = fingerprint
        member _.FundingMethod = fundingMethod
        member _.Last4 = last4
        member _.Reference = reference
        member _.SenderAccountNumber = senderAccountNumber
        member _.SenderName = senderName
        member _.SenderSortCode = senderSortCode

    ///
    and SourceTransactionPaperCheckData (?availableAt: string, ?invoices: string) =

        member _.AvailableAt = availableAt
        member _.Invoices = invoices

    ///
    and SourceTransactionSepaCreditTransferData (?reference: string, ?senderIban: string, ?senderName: string) =

        member _.Reference = reference
        member _.SenderIban = senderIban
        member _.SenderName = senderName

    and SourceTypeAchCreditTransfer (?accountNumber: string option, ?bankName: string option, ?fingerprint: string option, ?refundAccountHolderName: string option, ?refundAccountHolderType: string option, ?refundRoutingNumber: string option, ?routingNumber: string option, ?swiftCode: string option) =

        member _.AccountNumber = accountNumber |> Option.flatten
        member _.BankName = bankName |> Option.flatten
        member _.Fingerprint = fingerprint |> Option.flatten
        member _.RefundAccountHolderName = refundAccountHolderName |> Option.flatten
        member _.RefundAccountHolderType = refundAccountHolderType |> Option.flatten
        member _.RefundRoutingNumber = refundRoutingNumber |> Option.flatten
        member _.RoutingNumber = routingNumber |> Option.flatten
        member _.SwiftCode = swiftCode |> Option.flatten

    and SourceTypeAchDebit (?bankName: string option, ?country: string option, ?fingerprint: string option, ?last4: string option, ?routingNumber: string option, ?``type``: string option) =

        member _.BankName = bankName |> Option.flatten
        member _.Country = country |> Option.flatten
        member _.Fingerprint = fingerprint |> Option.flatten
        member _.Last4 = last4 |> Option.flatten
        member _.RoutingNumber = routingNumber |> Option.flatten
        member _.Type = ``type`` |> Option.flatten

    and SourceTypeAcssDebit (?bankAddressCity: string option, ?bankAddressLine1: string option, ?bankAddressLine2: string option, ?bankAddressPostalCode: string option, ?bankName: string option, ?category: string option, ?country: string option, ?fingerprint: string option, ?last4: string option, ?routingNumber: string option) =

        member _.BankAddressCity = bankAddressCity |> Option.flatten
        member _.BankAddressLine1 = bankAddressLine1 |> Option.flatten
        member _.BankAddressLine2 = bankAddressLine2 |> Option.flatten
        member _.BankAddressPostalCode = bankAddressPostalCode |> Option.flatten
        member _.BankName = bankName |> Option.flatten
        member _.Category = category |> Option.flatten
        member _.Country = country |> Option.flatten
        member _.Fingerprint = fingerprint |> Option.flatten
        member _.Last4 = last4 |> Option.flatten
        member _.RoutingNumber = routingNumber |> Option.flatten

    and SourceTypeAlipay (?dataString: string option, ?nativeUrl: string option, ?statementDescriptor: string option) =

        member _.DataString = dataString |> Option.flatten
        member _.NativeUrl = nativeUrl |> Option.flatten
        member _.StatementDescriptor = statementDescriptor |> Option.flatten

    and SourceTypeAuBecsDebit (?bsbNumber: string option, ?fingerprint: string option, ?last4: string option) =

        member _.BsbNumber = bsbNumber |> Option.flatten
        member _.Fingerprint = fingerprint |> Option.flatten
        member _.Last4 = last4 |> Option.flatten

    and SourceTypeBancontact (?bankCode: string option, ?bankName: string option, ?bic: string option, ?ibanLast4: string option, ?preferredLanguage: string option, ?statementDescriptor: string option) =

        member _.BankCode = bankCode |> Option.flatten
        member _.BankName = bankName |> Option.flatten
        member _.Bic = bic |> Option.flatten
        member _.IbanLast4 = ibanLast4 |> Option.flatten
        member _.PreferredLanguage = preferredLanguage |> Option.flatten
        member _.StatementDescriptor = statementDescriptor |> Option.flatten

    and SourceTypeCard (?addressLine1Check: string option, ?addressZipCheck: string option, ?brand: string option, ?country: string option, ?cvcCheck: string option, ?description: string, ?dynamicLast4: string option, ?expMonth: int option, ?expYear: int option, ?fingerprint: string, ?funding: string option, ?iin: string, ?issuer: string, ?last4: string option, ?name: string option, ?threeDSecure: string, ?tokenizationMethod: string option) =

        member _.AddressLine1Check = addressLine1Check |> Option.flatten
        member _.AddressZipCheck = addressZipCheck |> Option.flatten
        member _.Brand = brand |> Option.flatten
        member _.Country = country |> Option.flatten
        member _.CvcCheck = cvcCheck |> Option.flatten
        member _.Description = description
        member _.DynamicLast4 = dynamicLast4 |> Option.flatten
        member _.ExpMonth = expMonth |> Option.flatten
        member _.ExpYear = expYear |> Option.flatten
        member _.Fingerprint = fingerprint
        member _.Funding = funding |> Option.flatten
        member _.Iin = iin
        member _.Issuer = issuer
        member _.Last4 = last4 |> Option.flatten
        member _.Name = name |> Option.flatten
        member _.ThreeDSecure = threeDSecure
        member _.TokenizationMethod = tokenizationMethod |> Option.flatten

    and SourceTypeCardPresent (?applicationCryptogram: string, ?applicationPreferredName: string, ?authorizationCode: string option, ?authorizationResponseCode: string, ?brand: string option, ?country: string option, ?cvmType: string, ?dataType: string option, ?dedicatedFileName: string, ?description: string, ?emvAuthData: string, ?evidenceCustomerSignature: string option, ?evidenceTransactionCertificate: string option, ?expMonth: int option, ?expYear: int option, ?fingerprint: string, ?funding: string option, ?iin: string, ?issuer: string, ?last4: string option, ?posDeviceId: string option, ?posEntryMode: string, ?readMethod: string option, ?reader: string option, ?terminalVerificationResults: string, ?transactionStatusInformation: string) =

        member _.ApplicationCryptogram = applicationCryptogram
        member _.ApplicationPreferredName = applicationPreferredName
        member _.AuthorizationCode = authorizationCode |> Option.flatten
        member _.AuthorizationResponseCode = authorizationResponseCode
        member _.Brand = brand |> Option.flatten
        member _.Country = country |> Option.flatten
        member _.CvmType = cvmType
        member _.DataType = dataType |> Option.flatten
        member _.DedicatedFileName = dedicatedFileName
        member _.Description = description
        member _.EmvAuthData = emvAuthData
        member _.EvidenceCustomerSignature = evidenceCustomerSignature |> Option.flatten
        member _.EvidenceTransactionCertificate = evidenceTransactionCertificate |> Option.flatten
        member _.ExpMonth = expMonth |> Option.flatten
        member _.ExpYear = expYear |> Option.flatten
        member _.Fingerprint = fingerprint
        member _.Funding = funding |> Option.flatten
        member _.Iin = iin
        member _.Issuer = issuer
        member _.Last4 = last4 |> Option.flatten
        member _.PosDeviceId = posDeviceId |> Option.flatten
        member _.PosEntryMode = posEntryMode
        member _.ReadMethod = readMethod |> Option.flatten
        member _.Reader = reader |> Option.flatten
        member _.TerminalVerificationResults = terminalVerificationResults
        member _.TransactionStatusInformation = transactionStatusInformation

    and SourceTypeEps (?reference: string option, ?statementDescriptor: string option) =

        member _.Reference = reference |> Option.flatten
        member _.StatementDescriptor = statementDescriptor |> Option.flatten

    and SourceTypeGiropay (?bankCode: string option, ?bankName: string option, ?bic: string option, ?statementDescriptor: string option) =

        member _.BankCode = bankCode |> Option.flatten
        member _.BankName = bankName |> Option.flatten
        member _.Bic = bic |> Option.flatten
        member _.StatementDescriptor = statementDescriptor |> Option.flatten

    and SourceTypeIdeal (?bank: string option, ?bic: string option, ?ibanLast4: string option, ?statementDescriptor: string option) =

        member _.Bank = bank |> Option.flatten
        member _.Bic = bic |> Option.flatten
        member _.IbanLast4 = ibanLast4 |> Option.flatten
        member _.StatementDescriptor = statementDescriptor |> Option.flatten

    and SourceTypeKlarna (?backgroundImageUrl: string, ?clientToken: string option, ?firstName: string, ?lastName: string, ?locale: string, ?logoUrl: string, ?pageTitle: string, ?payLaterAssetUrlsDescriptive: string, ?payLaterAssetUrlsStandard: string, ?payLaterName: string, ?payLaterRedirectUrl: string, ?payNowAssetUrlsDescriptive: string, ?payNowAssetUrlsStandard: string, ?payNowName: string, ?payNowRedirectUrl: string, ?payOverTimeAssetUrlsDescriptive: string, ?payOverTimeAssetUrlsStandard: string, ?payOverTimeName: string, ?payOverTimeRedirectUrl: string, ?paymentMethodCategories: string, ?purchaseCountry: string, ?purchaseType: string, ?redirectUrl: string, ?shippingDelay: int, ?shippingFirstName: string, ?shippingLastName: string) =

        member _.BackgroundImageUrl = backgroundImageUrl
        member _.ClientToken = clientToken |> Option.flatten
        member _.FirstName = firstName
        member _.LastName = lastName
        member _.Locale = locale
        member _.LogoUrl = logoUrl
        member _.PageTitle = pageTitle
        member _.PayLaterAssetUrlsDescriptive = payLaterAssetUrlsDescriptive
        member _.PayLaterAssetUrlsStandard = payLaterAssetUrlsStandard
        member _.PayLaterName = payLaterName
        member _.PayLaterRedirectUrl = payLaterRedirectUrl
        member _.PayNowAssetUrlsDescriptive = payNowAssetUrlsDescriptive
        member _.PayNowAssetUrlsStandard = payNowAssetUrlsStandard
        member _.PayNowName = payNowName
        member _.PayNowRedirectUrl = payNowRedirectUrl
        member _.PayOverTimeAssetUrlsDescriptive = payOverTimeAssetUrlsDescriptive
        member _.PayOverTimeAssetUrlsStandard = payOverTimeAssetUrlsStandard
        member _.PayOverTimeName = payOverTimeName
        member _.PayOverTimeRedirectUrl = payOverTimeRedirectUrl
        member _.PaymentMethodCategories = paymentMethodCategories
        member _.PurchaseCountry = purchaseCountry
        member _.PurchaseType = purchaseType
        member _.RedirectUrl = redirectUrl
        member _.ShippingDelay = shippingDelay
        member _.ShippingFirstName = shippingFirstName
        member _.ShippingLastName = shippingLastName

    and SourceTypeMultibanco (?entity: string option, ?reference: string option, ?refundAccountHolderAddressCity: string option, ?refundAccountHolderAddressCountry: string option, ?refundAccountHolderAddressLine1: string option, ?refundAccountHolderAddressLine2: string option, ?refundAccountHolderAddressPostalCode: string option, ?refundAccountHolderAddressState: string option, ?refundAccountHolderName: string option, ?refundIban: string option) =

        member _.Entity = entity |> Option.flatten
        member _.Reference = reference |> Option.flatten
        member _.RefundAccountHolderAddressCity = refundAccountHolderAddressCity |> Option.flatten
        member _.RefundAccountHolderAddressCountry = refundAccountHolderAddressCountry |> Option.flatten
        member _.RefundAccountHolderAddressLine1 = refundAccountHolderAddressLine1 |> Option.flatten
        member _.RefundAccountHolderAddressLine2 = refundAccountHolderAddressLine2 |> Option.flatten
        member _.RefundAccountHolderAddressPostalCode = refundAccountHolderAddressPostalCode |> Option.flatten
        member _.RefundAccountHolderAddressState = refundAccountHolderAddressState |> Option.flatten
        member _.RefundAccountHolderName = refundAccountHolderName |> Option.flatten
        member _.RefundIban = refundIban |> Option.flatten

    and SourceTypeP24 (?reference: string option) =

        member _.Reference = reference |> Option.flatten

    and SourceTypeSepaCreditTransfer (?bankName: string option, ?bic: string option, ?iban: string option, ?refundAccountHolderAddressCity: string option, ?refundAccountHolderAddressCountry: string option, ?refundAccountHolderAddressLine1: string option, ?refundAccountHolderAddressLine2: string option, ?refundAccountHolderAddressPostalCode: string option, ?refundAccountHolderAddressState: string option, ?refundAccountHolderName: string option, ?refundIban: string option) =

        member _.BankName = bankName |> Option.flatten
        member _.Bic = bic |> Option.flatten
        member _.Iban = iban |> Option.flatten
        member _.RefundAccountHolderAddressCity = refundAccountHolderAddressCity |> Option.flatten
        member _.RefundAccountHolderAddressCountry = refundAccountHolderAddressCountry |> Option.flatten
        member _.RefundAccountHolderAddressLine1 = refundAccountHolderAddressLine1 |> Option.flatten
        member _.RefundAccountHolderAddressLine2 = refundAccountHolderAddressLine2 |> Option.flatten
        member _.RefundAccountHolderAddressPostalCode = refundAccountHolderAddressPostalCode |> Option.flatten
        member _.RefundAccountHolderAddressState = refundAccountHolderAddressState |> Option.flatten
        member _.RefundAccountHolderName = refundAccountHolderName |> Option.flatten
        member _.RefundIban = refundIban |> Option.flatten

    and SourceTypeSepaDebit (?bankCode: string option, ?branchCode: string option, ?country: string option, ?fingerprint: string option, ?last4: string option, ?mandateReference: string option, ?mandateUrl: string option) =

        member _.BankCode = bankCode |> Option.flatten
        member _.BranchCode = branchCode |> Option.flatten
        member _.Country = country |> Option.flatten
        member _.Fingerprint = fingerprint |> Option.flatten
        member _.Last4 = last4 |> Option.flatten
        member _.MandateReference = mandateReference |> Option.flatten
        member _.MandateUrl = mandateUrl |> Option.flatten

    and SourceTypeSofort (?bankCode: string option, ?bankName: string option, ?bic: string option, ?country: string option, ?ibanLast4: string option, ?preferredLanguage: string option, ?statementDescriptor: string option) =

        member _.BankCode = bankCode |> Option.flatten
        member _.BankName = bankName |> Option.flatten
        member _.Bic = bic |> Option.flatten
        member _.Country = country |> Option.flatten
        member _.IbanLast4 = ibanLast4 |> Option.flatten
        member _.PreferredLanguage = preferredLanguage |> Option.flatten
        member _.StatementDescriptor = statementDescriptor |> Option.flatten

    and SourceTypeThreeDSecure (?addressLine1Check: string option, ?addressZipCheck: string option, ?authenticated: bool option, ?brand: string option, ?card: string option, ?country: string option, ?customer: string option, ?cvcCheck: string option, ?description: string, ?dynamicLast4: string option, ?expMonth: int option, ?expYear: int option, ?fingerprint: string, ?funding: string option, ?iin: string, ?issuer: string, ?last4: string option, ?name: string option, ?threeDSecure: string, ?tokenizationMethod: string option) =

        member _.AddressLine1Check = addressLine1Check |> Option.flatten
        member _.AddressZipCheck = addressZipCheck |> Option.flatten
        member _.Authenticated = authenticated |> Option.flatten
        member _.Brand = brand |> Option.flatten
        member _.Card = card |> Option.flatten
        member _.Country = country |> Option.flatten
        member _.Customer = customer |> Option.flatten
        member _.CvcCheck = cvcCheck |> Option.flatten
        member _.Description = description
        member _.DynamicLast4 = dynamicLast4 |> Option.flatten
        member _.ExpMonth = expMonth |> Option.flatten
        member _.ExpYear = expYear |> Option.flatten
        member _.Fingerprint = fingerprint
        member _.Funding = funding |> Option.flatten
        member _.Iin = iin
        member _.Issuer = issuer
        member _.Last4 = last4 |> Option.flatten
        member _.Name = name |> Option.flatten
        member _.ThreeDSecure = threeDSecure
        member _.TokenizationMethod = tokenizationMethod |> Option.flatten

    and SourceTypeWechat (?prepayId: string, ?qrCodeUrl: string option, ?statementDescriptor: string) =

        member _.PrepayId = prepayId
        member _.QrCodeUrl = qrCodeUrl |> Option.flatten
        member _.StatementDescriptor = statementDescriptor

    ///
    and StatusTransitions (canceled: int option, fulfiled: int option, paid: int option, returned: int option) =

        member _.Canceled = canceled
        member _.Fulfiled = fulfiled
        member _.Paid = paid
        member _.Returned = returned

    ///Subscriptions allow you to charge a customer on a recurring basis.
    ///
    ///Related guide: [Creating Subscriptions](https://stripe.com/docs/billing/subscriptions/creating).
    and Subscription (applicationFeePercent: decimal option, billingCycleAnchor: int, billingThresholds: SubscriptionBillingThresholds option, cancelAt: int option, cancelAtPeriodEnd: bool, canceledAt: int option, collectionMethod: SubscriptionCollectionMethod option, created: int, currentPeriodEnd: int, currentPeriodStart: int, customer: SubscriptionCustomerDU, daysUntilDue: int option, defaultPaymentMethod: SubscriptionDefaultPaymentMethodDU option, defaultSource: SubscriptionDefaultSourceDU option, discount: Discount option, endedAt: int option, id: string, items: Map<string, string>, latestInvoice: SubscriptionLatestInvoiceDU option, livemode: bool, metadata: Map<string, string>, nextPendingInvoiceItemInvoice: int option, object: SubscriptionObject, pauseCollection: SubscriptionsResourcePauseCollection option, pendingInvoiceItemInterval: SubscriptionPendingInvoiceItemInterval option, pendingSetupIntent: SubscriptionPendingSetupIntentDU option, pendingUpdate: SubscriptionsResourcePendingUpdate option, schedule: SubscriptionScheduleDU option, startDate: int, status: SubscriptionStatus, transferData: SubscriptionTransferData option, trialEnd: int option, trialStart: int option, ?defaultTaxRates: TaxRate list option) =

        member _.ApplicationFeePercent = applicationFeePercent
        member _.BillingCycleAnchor = billingCycleAnchor
        member _.BillingThresholds = billingThresholds
        member _.CancelAt = cancelAt
        member _.CancelAtPeriodEnd = cancelAtPeriodEnd
        member _.CanceledAt = canceledAt
        member _.CollectionMethod = collectionMethod
        member _.Created = created
        member _.CurrentPeriodEnd = currentPeriodEnd
        member _.CurrentPeriodStart = currentPeriodStart
        member _.Customer = customer
        member _.DaysUntilDue = daysUntilDue
        member _.DefaultPaymentMethod = defaultPaymentMethod
        member _.DefaultSource = defaultSource
        member _.DefaultTaxRates = defaultTaxRates |> Option.flatten
        member _.Discount = discount
        member _.EndedAt = endedAt
        member _.Id = id
        member _.Items = items
        member _.LatestInvoice = latestInvoice
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.NextPendingInvoiceItemInvoice = nextPendingInvoiceItemInvoice
        member _.Object = object
        member _.PauseCollection = pauseCollection
        member _.PendingInvoiceItemInterval = pendingInvoiceItemInterval
        member _.PendingSetupIntent = pendingSetupIntent
        member _.PendingUpdate = pendingUpdate
        member _.Schedule = schedule
        member _.StartDate = startDate
        member _.Status = status
        member _.TransferData = transferData
        member _.TrialEnd = trialEnd
        member _.TrialStart = trialStart

    and SubscriptionCollectionMethod =
        | SubscriptionCollectionMethod'ChargeAutomatically
        | SubscriptionCollectionMethod'SendInvoice

    and SubscriptionObject =
        | SubscriptionObject'Subscription

    and SubscriptionStatus =
        | SubscriptionStatus'Active
        | SubscriptionStatus'Canceled
        | SubscriptionStatus'Incomplete
        | SubscriptionStatus'IncompleteExpired
        | SubscriptionStatus'PastDue
        | SubscriptionStatus'Trialing
        | SubscriptionStatus'Unpaid

    and SubscriptionCustomerDU =
        | SubscriptionCustomerDU'String of string
        | SubscriptionCustomerDU'Customer of Customer
        | SubscriptionCustomerDU'DeletedCustomer of DeletedCustomer

    and SubscriptionDefaultPaymentMethodDU =
        | SubscriptionDefaultPaymentMethodDU'String of string
        | SubscriptionDefaultPaymentMethodDU'PaymentMethod of PaymentMethod

    and SubscriptionDefaultSourceDU =
        | SubscriptionDefaultSourceDU'String of string
        | SubscriptionDefaultSourceDU'PaymentSource of PaymentSource

    and SubscriptionLatestInvoiceDU =
        | SubscriptionLatestInvoiceDU'String of string
        | SubscriptionLatestInvoiceDU'Invoice of Invoice

    and SubscriptionPendingSetupIntentDU =
        | SubscriptionPendingSetupIntentDU'String of string
        | SubscriptionPendingSetupIntentDU'SetupIntent of SetupIntent

    and SubscriptionScheduleDU =
        | SubscriptionScheduleDU'String of string
        | SubscriptionScheduleDU'SubscriptionSchedule of SubscriptionSchedule

    ///
    and SubscriptionBillingThresholds (amountGte: int option, resetBillingCycleAnchor: bool option) =

        member _.AmountGte = amountGte
        member _.ResetBillingCycleAnchor = resetBillingCycleAnchor

    ///Subscription items allow you to create customer subscriptions with more than
    ///one plan, making it easy to represent complex billing relationships.
    and SubscriptionItem (billingThresholds: SubscriptionItemBillingThresholds option, created: int, id: string, metadata: Map<string, string>, object: SubscriptionItemObject, plan: Plan, price: Price, subscription: string, taxRates: TaxRate list option, ?quantity: int) =

        member _.BillingThresholds = billingThresholds
        member _.Created = created
        member _.Id = id
        member _.Metadata = metadata
        member _.Object = object
        member _.Plan = plan
        member _.Price = price
        member _.Quantity = quantity
        member _.Subscription = subscription
        member _.TaxRates = taxRates

    and SubscriptionItemObject =
        | SubscriptionItemObject'SubscriptionItem

    ///
    and SubscriptionItemBillingThresholds (usageGte: int option) =

        member _.UsageGte = usageGte

    ///
    and SubscriptionPendingInvoiceItemInterval (interval: SubscriptionPendingInvoiceItemIntervalInterval, intervalCount: int) =

        member _.Interval = interval
        member _.IntervalCount = intervalCount

    and SubscriptionPendingInvoiceItemIntervalInterval =
        | SubscriptionPendingInvoiceItemIntervalInterval'Day
        | SubscriptionPendingInvoiceItemIntervalInterval'Month
        | SubscriptionPendingInvoiceItemIntervalInterval'Week
        | SubscriptionPendingInvoiceItemIntervalInterval'Year

    ///A subscription schedule allows you to create and manage the lifecycle of a subscription by predefining expected changes.
    ///
    ///Related guide: [Subscription Schedules](https://stripe.com/docs/billing/subscriptions/subscription-schedules).
    and SubscriptionSchedule (canceledAt: int option, completedAt: int option, created: int, currentPhase: SubscriptionScheduleCurrentPhase option, customer: SubscriptionScheduleCustomerDU, defaultSettings: SubscriptionSchedulesResourceDefaultSettings, endBehavior: SubscriptionScheduleEndBehavior, id: string, livemode: bool, metadata: Map<string, string> option, object: SubscriptionScheduleObject, phases: SubscriptionSchedulePhaseConfiguration list, releasedAt: int option, releasedSubscription: string option, status: SubscriptionScheduleStatus, subscription: SubscriptionScheduleSubscriptionDU option) =

        member _.CanceledAt = canceledAt
        member _.CompletedAt = completedAt
        member _.Created = created
        member _.CurrentPhase = currentPhase
        member _.Customer = customer
        member _.DefaultSettings = defaultSettings
        member _.EndBehavior = endBehavior
        member _.Id = id
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Object = object
        member _.Phases = phases
        member _.ReleasedAt = releasedAt
        member _.ReleasedSubscription = releasedSubscription
        member _.Status = status
        member _.Subscription = subscription

    and SubscriptionScheduleEndBehavior =
        | SubscriptionScheduleEndBehavior'Cancel
        | SubscriptionScheduleEndBehavior'None
        | SubscriptionScheduleEndBehavior'Release
        | SubscriptionScheduleEndBehavior'Renew

    and SubscriptionScheduleObject =
        | SubscriptionScheduleObject'SubscriptionSchedule

    and SubscriptionScheduleStatus =
        | SubscriptionScheduleStatus'Active
        | SubscriptionScheduleStatus'Canceled
        | SubscriptionScheduleStatus'Completed
        | SubscriptionScheduleStatus'NotStarted
        | SubscriptionScheduleStatus'Released

    and SubscriptionScheduleCustomerDU =
        | SubscriptionScheduleCustomerDU'String of string
        | SubscriptionScheduleCustomerDU'Customer of Customer
        | SubscriptionScheduleCustomerDU'DeletedCustomer of DeletedCustomer

    and SubscriptionScheduleSubscriptionDU =
        | SubscriptionScheduleSubscriptionDU'String of string
        | SubscriptionScheduleSubscriptionDU'Subscription of Subscription

    ///An Add Invoice Item describes the prices and quantities that will be added as pending invoice items when entering a phase.
    and SubscriptionScheduleAddInvoiceItem (price: SubscriptionScheduleAddInvoiceItemPriceDU, quantity: int option, ?taxRates: TaxRate list option) =

        member _.Price = price
        member _.Quantity = quantity
        member _.TaxRates = taxRates |> Option.flatten

    and SubscriptionScheduleAddInvoiceItemPriceDU =
        | SubscriptionScheduleAddInvoiceItemPriceDU'String of string
        | SubscriptionScheduleAddInvoiceItemPriceDU'Price of Price
        | SubscriptionScheduleAddInvoiceItemPriceDU'DeletedPrice of DeletedPrice

    ///A phase item describes the price and quantity of a phase.
    and SubscriptionScheduleConfigurationItem (billingThresholds: SubscriptionItemBillingThresholds option, plan: SubscriptionScheduleConfigurationItemPlanDU, price: SubscriptionScheduleConfigurationItemPriceDU, ?quantity: int, ?taxRates: TaxRate list option) =

        member _.BillingThresholds = billingThresholds
        member _.Plan = plan
        member _.Price = price
        member _.Quantity = quantity
        member _.TaxRates = taxRates |> Option.flatten

    and SubscriptionScheduleConfigurationItemPlanDU =
        | SubscriptionScheduleConfigurationItemPlanDU'String of string
        | SubscriptionScheduleConfigurationItemPlanDU'Plan of Plan
        | SubscriptionScheduleConfigurationItemPlanDU'DeletedPlan of DeletedPlan

    and SubscriptionScheduleConfigurationItemPriceDU =
        | SubscriptionScheduleConfigurationItemPriceDU'String of string
        | SubscriptionScheduleConfigurationItemPriceDU'Price of Price
        | SubscriptionScheduleConfigurationItemPriceDU'DeletedPrice of DeletedPrice

    ///
    and SubscriptionScheduleCurrentPhase (endDate: int, startDate: int) =

        member _.EndDate = endDate
        member _.StartDate = startDate

    ///A phase describes the plans, coupon, and trialing status of a subscription for a predefined time period.
    and SubscriptionSchedulePhaseConfiguration (addInvoiceItems: SubscriptionScheduleAddInvoiceItem list, applicationFeePercent: decimal option, billingCycleAnchor: SubscriptionSchedulePhaseConfigurationBillingCycleAnchor option, billingThresholds: SubscriptionBillingThresholds option, collectionMethod: SubscriptionSchedulePhaseConfigurationCollectionMethod option, coupon: SubscriptionSchedulePhaseConfigurationCouponDU option, defaultPaymentMethod: SubscriptionSchedulePhaseConfigurationDefaultPaymentMethodDU option, endDate: int, invoiceSettings: InvoiceSettingSubscriptionScheduleSetting option, items: SubscriptionScheduleConfigurationItem list, prorationBehavior: SubscriptionSchedulePhaseConfigurationProrationBehavior, startDate: int, transferData: SubscriptionTransferData option, trialEnd: int option, ?defaultTaxRates: TaxRate list option) =

        member _.AddInvoiceItems = addInvoiceItems
        member _.ApplicationFeePercent = applicationFeePercent
        member _.BillingCycleAnchor = billingCycleAnchor
        member _.BillingThresholds = billingThresholds
        member _.CollectionMethod = collectionMethod
        member _.Coupon = coupon
        member _.DefaultPaymentMethod = defaultPaymentMethod
        member _.DefaultTaxRates = defaultTaxRates |> Option.flatten
        member _.EndDate = endDate
        member _.InvoiceSettings = invoiceSettings
        member _.Items = items
        member _.ProrationBehavior = prorationBehavior
        member _.StartDate = startDate
        member _.TransferData = transferData
        member _.TrialEnd = trialEnd

    and SubscriptionSchedulePhaseConfigurationBillingCycleAnchor =
        | SubscriptionSchedulePhaseConfigurationBillingCycleAnchor'Automatic
        | SubscriptionSchedulePhaseConfigurationBillingCycleAnchor'PhaseStart

    and SubscriptionSchedulePhaseConfigurationCollectionMethod =
        | SubscriptionSchedulePhaseConfigurationCollectionMethod'ChargeAutomatically
        | SubscriptionSchedulePhaseConfigurationCollectionMethod'SendInvoice

    and SubscriptionSchedulePhaseConfigurationProrationBehavior =
        | SubscriptionSchedulePhaseConfigurationProrationBehavior'AlwaysInvoice
        | SubscriptionSchedulePhaseConfigurationProrationBehavior'CreateProrations
        | SubscriptionSchedulePhaseConfigurationProrationBehavior'None

    and SubscriptionSchedulePhaseConfigurationCouponDU =
        | SubscriptionSchedulePhaseConfigurationCouponDU'String of string
        | SubscriptionSchedulePhaseConfigurationCouponDU'Coupon of Coupon
        | SubscriptionSchedulePhaseConfigurationCouponDU'DeletedCoupon of DeletedCoupon

    and SubscriptionSchedulePhaseConfigurationDefaultPaymentMethodDU =
        | SubscriptionSchedulePhaseConfigurationDefaultPaymentMethodDU'String of string
        | SubscriptionSchedulePhaseConfigurationDefaultPaymentMethodDU'PaymentMethod of PaymentMethod

    ///
    and SubscriptionSchedulesResourceDefaultSettings (billingCycleAnchor: SubscriptionSchedulesResourceDefaultSettingsBillingCycleAnchor, billingThresholds: SubscriptionBillingThresholds option, collectionMethod: SubscriptionSchedulesResourceDefaultSettingsCollectionMethod option, defaultPaymentMethod: SubscriptionSchedulesResourceDefaultSettingsDefaultPaymentMethodDU option, invoiceSettings: InvoiceSettingSubscriptionScheduleSetting option, transferData: SubscriptionTransferData option) =

        member _.BillingCycleAnchor = billingCycleAnchor
        member _.BillingThresholds = billingThresholds
        member _.CollectionMethod = collectionMethod
        member _.DefaultPaymentMethod = defaultPaymentMethod
        member _.InvoiceSettings = invoiceSettings
        member _.TransferData = transferData

    and SubscriptionSchedulesResourceDefaultSettingsBillingCycleAnchor =
        | SubscriptionSchedulesResourceDefaultSettingsBillingCycleAnchor'Automatic
        | SubscriptionSchedulesResourceDefaultSettingsBillingCycleAnchor'PhaseStart

    and SubscriptionSchedulesResourceDefaultSettingsCollectionMethod =
        | SubscriptionSchedulesResourceDefaultSettingsCollectionMethod'ChargeAutomatically
        | SubscriptionSchedulesResourceDefaultSettingsCollectionMethod'SendInvoice

    and SubscriptionSchedulesResourceDefaultSettingsDefaultPaymentMethodDU =
        | SubscriptionSchedulesResourceDefaultSettingsDefaultPaymentMethodDU'String of string
        | SubscriptionSchedulesResourceDefaultSettingsDefaultPaymentMethodDU'PaymentMethod of PaymentMethod

    ///
    and SubscriptionTransferData (amountPercent: decimal option, destination: SubscriptionTransferDataDestinationDU) =

        member _.AmountPercent = amountPercent
        member _.Destination = destination

    and SubscriptionTransferDataDestinationDU =
        | SubscriptionTransferDataDestinationDU'String of string
        | SubscriptionTransferDataDestinationDU'Account of Account

    ///The Pause Collection settings determine how we will pause collection for this subscription and for how long the subscription
    ///should be paused.
    and SubscriptionsResourcePauseCollection (behavior: SubscriptionsResourcePauseCollectionBehavior, resumesAt: int option) =

        member _.Behavior = behavior
        member _.ResumesAt = resumesAt

    and SubscriptionsResourcePauseCollectionBehavior =
        | SubscriptionsResourcePauseCollectionBehavior'KeepAsDraft
        | SubscriptionsResourcePauseCollectionBehavior'MarkUncollectible
        | SubscriptionsResourcePauseCollectionBehavior'Void

    ///Pending Updates store the changes pending from a previous update that will be applied
    ///to the Subscription upon successful payment.
    and SubscriptionsResourcePendingUpdate (billingCycleAnchor: int option, expiresAt: int, subscriptionItems: SubscriptionItem list option, trialEnd: int option, trialFromPlan: bool option) =

        member _.BillingCycleAnchor = billingCycleAnchor
        member _.ExpiresAt = expiresAt
        member _.SubscriptionItems = subscriptionItems
        member _.TrialEnd = trialEnd
        member _.TrialFromPlan = trialFromPlan

    ///
    and TaxDeductedAtSource (id: string, object: TaxDeductedAtSourceObject, periodEnd: int, periodStart: int, taxDeductionAccountNumber: string) =

        member _.Id = id
        member _.Object = object
        member _.PeriodEnd = periodEnd
        member _.PeriodStart = periodStart
        member _.TaxDeductionAccountNumber = taxDeductionAccountNumber

    and TaxDeductedAtSourceObject =
        | TaxDeductedAtSourceObject'TaxDeductedAtSource

    ///You can add one or multiple tax IDs to a [customer](https://stripe.com/docs/api/customers).
    ///A customer's tax IDs are displayed on invoices and credit notes issued for the customer.
    ///
    ///Related guide: [Customer Tax Identification Numbers](https://stripe.com/docs/billing/taxes/tax-ids).
    and TaxId (country: string option, created: int, customer: TaxIdCustomerDU option, id: string, livemode: bool, object: TaxIdObject, ``type``: TaxIdType, value: string, verification: TaxIdVerification option) =

        member _.Country = country
        member _.Created = created
        member _.Customer = customer
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = object
        member _.Type = ``type``
        member _.Value = value
        member _.Verification = verification

    and TaxIdObject =
        | TaxIdObject'TaxId

    and TaxIdType =
        | TaxIdType'AeTrn
        | TaxIdType'AuAbn
        | TaxIdType'BrCnpj
        | TaxIdType'BrCpf
        | TaxIdType'CaBn
        | TaxIdType'CaQst
        | TaxIdType'ChVat
        | TaxIdType'ClTin
        | TaxIdType'EsCif
        | TaxIdType'EuVat
        | TaxIdType'HkBr
        | TaxIdType'IdNpwp
        | TaxIdType'InGst
        | TaxIdType'JpCn
        | TaxIdType'JpRn
        | TaxIdType'KrBrn
        | TaxIdType'LiUid
        | TaxIdType'MxRfc
        | TaxIdType'MyFrp
        | TaxIdType'MyItn
        | TaxIdType'MySst
        | TaxIdType'NoVat
        | TaxIdType'NzGst
        | TaxIdType'RuInn
        | TaxIdType'RuKpp
        | TaxIdType'SaVat
        | TaxIdType'SgGst
        | TaxIdType'SgUen
        | TaxIdType'ThVat
        | TaxIdType'TwVat
        | TaxIdType'Unknown
        | TaxIdType'UsEin
        | TaxIdType'ZaVat

    and TaxIdCustomerDU =
        | TaxIdCustomerDU'String of string
        | TaxIdCustomerDU'Customer of Customer

    ///
    and TaxIdVerification (status: TaxIdVerificationStatus, verifiedAddress: string option, verifiedName: string option) =

        member _.Status = status
        member _.VerifiedAddress = verifiedAddress
        member _.VerifiedName = verifiedName

    and TaxIdVerificationStatus =
        | TaxIdVerificationStatus'Pending
        | TaxIdVerificationStatus'Unavailable
        | TaxIdVerificationStatus'Unverified
        | TaxIdVerificationStatus'Verified

    ///Tax rates can be applied to [invoices](https://stripe.com/docs/billing/invoices/tax-rates), [subscriptions](https://stripe.com/docs/billing/subscriptions/taxes) and [Checkout Sessions](https://stripe.com/docs/payments/checkout/set-up-a-subscription#tax-rates) to collect tax.
    ///
    ///Related guide: [Tax Rates](https://stripe.com/docs/billing/taxes/tax-rates).
    and TaxRate (active: bool, created: int, description: string option, displayName: string, id: string, inclusive: bool, jurisdiction: string option, livemode: bool, metadata: Map<string, string> option, object: TaxRateObject, percentage: decimal) =

        member _.Active = active
        member _.Created = created
        member _.Description = description
        member _.DisplayName = displayName
        member _.Id = id
        member _.Inclusive = inclusive
        member _.Jurisdiction = jurisdiction
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Object = object
        member _.Percentage = percentage

    and TaxRateObject =
        | TaxRateObject'TaxRate

    ///A Connection Token is used by the Stripe Terminal SDK to connect to a reader.
    ///
    ///Related guide: [Fleet Management](https://stripe.com/docs/terminal/readers/fleet-management#create).
    and TerminalConnectionToken (object: TerminalConnectionTokenObject, secret: string, ?location: string) =

        member _.Location = location
        member _.Object = object
        member _.Secret = secret

    and TerminalConnectionTokenObject =
        | TerminalConnectionTokenObject'TerminalConnectionToken

    ///A Location represents a grouping of readers.
    ///
    ///Related guide: [Fleet Management](https://stripe.com/docs/terminal/readers/fleet-management#create).
    and TerminalLocation (address: Address, displayName: string, id: string, livemode: bool, metadata: Map<string, string>, object: TerminalLocationObject) =

        member _.Address = address
        member _.DisplayName = displayName
        member _.Id = id
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Object = object

    and TerminalLocationObject =
        | TerminalLocationObject'TerminalLocation

    ///A Reader represents a physical device for accepting payment details.
    ///
    ///Related guide: [Connecting to a Reader](https://stripe.com/docs/terminal/readers/connecting).
    and TerminalReader (deviceSwVersion: string option, deviceType: TerminalReaderDeviceType, id: string, ipAddress: string option, label: string, livemode: bool, location: string option, metadata: Map<string, string>, object: TerminalReaderObject, serialNumber: string, status: string option) =

        member _.DeviceSwVersion = deviceSwVersion
        member _.DeviceType = deviceType
        member _.Id = id
        member _.IpAddress = ipAddress
        member _.Label = label
        member _.Livemode = livemode
        member _.Location = location
        member _.Metadata = metadata
        member _.Object = object
        member _.SerialNumber = serialNumber
        member _.Status = status

    and TerminalReaderDeviceType =
        | TerminalReaderDeviceType'BbposChipper2x
        | TerminalReaderDeviceType'VerifoneP400

    and TerminalReaderObject =
        | TerminalReaderObject'TerminalReader

    ///Cardholder authentication via 3D Secure is initiated by creating a `3D Secure`
    ///object. Once the object has been created, you can use it to authenticate the
    ///cardholder and create a charge.
    and ThreeDSecure (amount: int, authenticated: bool, card: Card, created: int, currency: string, id: string, livemode: bool, object: ThreeDSecureObject, redirectUrl: string option, status: string) =

        member _.Amount = amount
        member _.Authenticated = authenticated
        member _.Card = card
        member _.Created = created
        member _.Currency = currency
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = object
        member _.RedirectUrl = redirectUrl
        member _.Status = status

    and ThreeDSecureObject =
        | ThreeDSecureObject'ThreeDSecure

    ///
    and ThreeDSecureDetails (authenticationFlow: ThreeDSecureDetailsAuthenticationFlow option, result: ThreeDSecureDetailsResult, resultReason: ThreeDSecureDetailsResultReason option, version: ThreeDSecureDetailsVersion) =

        member _.AuthenticationFlow = authenticationFlow
        member _.Result = result
        member _.ResultReason = resultReason
        member _.Version = version

    and ThreeDSecureDetailsAuthenticationFlow =
        | ThreeDSecureDetailsAuthenticationFlow'Challenge
        | ThreeDSecureDetailsAuthenticationFlow'Frictionless

    and ThreeDSecureDetailsResult =
        | ThreeDSecureDetailsResult'AttemptAcknowledged
        | ThreeDSecureDetailsResult'Authenticated
        | ThreeDSecureDetailsResult'Failed
        | ThreeDSecureDetailsResult'NotSupported
        | ThreeDSecureDetailsResult'ProcessingError

    and ThreeDSecureDetailsResultReason =
        | ThreeDSecureDetailsResultReason'Abandoned
        | ThreeDSecureDetailsResultReason'Bypassed
        | ThreeDSecureDetailsResultReason'Canceled
        | ThreeDSecureDetailsResultReason'CardNotEnrolled
        | ThreeDSecureDetailsResultReason'NetworkNotSupported
        | ThreeDSecureDetailsResultReason'ProtocolError
        | ThreeDSecureDetailsResultReason'Rejected

    and ThreeDSecureDetailsVersion =
        | [<JsonUnionCase("1.0.2")>] ThreeDSecureDetailsVersion'102
        | [<JsonUnionCase("2.1.0")>] ThreeDSecureDetailsVersion'210
        | [<JsonUnionCase("2.2.0")>] ThreeDSecureDetailsVersion'220

    ///
    and ThreeDSecureUsage (supported: bool) =

        member _.Supported = supported

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
    and Token (clientIp: string option, created: int, id: string, livemode: bool, object: TokenObject, ``type``: string, used: bool, ?bankAccount: BankAccount, ?card: Card) =

        member _.BankAccount = bankAccount
        member _.Card = card
        member _.ClientIp = clientIp
        member _.Created = created
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = object
        member _.Type = ``type``
        member _.Used = used

    and TokenObject =
        | TokenObject'Token

    ///To top up your Stripe balance, you create a top-up object. You can retrieve
    ///individual top-ups, as well as list all top-ups. Top-ups are identified by a
    ///unique, random ID.
    ///
    ///Related guide: [Topping Up your Platform Account](https://stripe.com/docs/connect/top-ups).
    and Topup (amount: int, balanceTransaction: TopupBalanceTransactionDU option, created: int, currency: string, description: string option, expectedAvailabilityDate: int option, failureCode: string option, failureMessage: string option, id: string, livemode: bool, metadata: Map<string, string>, object: TopupObject, source: Source, statementDescriptor: string option, status: TopupStatus, transferGroup: string option) =

        member _.Amount = amount
        member _.BalanceTransaction = balanceTransaction
        member _.Created = created
        member _.Currency = currency
        member _.Description = description
        member _.ExpectedAvailabilityDate = expectedAvailabilityDate
        member _.FailureCode = failureCode
        member _.FailureMessage = failureMessage
        member _.Id = id
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Object = object
        member _.Source = source
        member _.StatementDescriptor = statementDescriptor
        member _.Status = status
        member _.TransferGroup = transferGroup

    and TopupObject =
        | TopupObject'Topup

    and TopupStatus =
        | TopupStatus'Canceled
        | TopupStatus'Failed
        | TopupStatus'Pending
        | TopupStatus'Reversed
        | TopupStatus'Succeeded

    and TopupBalanceTransactionDU =
        | TopupBalanceTransactionDU'String of string
        | TopupBalanceTransactionDU'BalanceTransaction of BalanceTransaction

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
    and Transfer (amount: int, amountReversed: int, balanceTransaction: TransferBalanceTransactionDU option, created: int, currency: string, description: string option, destination: TransferDestinationDU option, id: string, livemode: bool, metadata: Map<string, string>, object: TransferObject, reversals: Map<string, string>, reversed: bool, sourceTransaction: TransferSourceTransactionDU option, sourceType: string option, transferGroup: string option, ?destinationPayment: TransferDestinationPaymentDU) =

        member _.Amount = amount
        member _.AmountReversed = amountReversed
        member _.BalanceTransaction = balanceTransaction
        member _.Created = created
        member _.Currency = currency
        member _.Description = description
        member _.Destination = destination
        member _.DestinationPayment = destinationPayment
        member _.Id = id
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Object = object
        member _.Reversals = reversals
        member _.Reversed = reversed
        member _.SourceTransaction = sourceTransaction
        member _.SourceType = sourceType
        member _.TransferGroup = transferGroup

    and TransferObject =
        | TransferObject'Transfer

    and TransferBalanceTransactionDU =
        | TransferBalanceTransactionDU'String of string
        | TransferBalanceTransactionDU'BalanceTransaction of BalanceTransaction

    and TransferDestinationDU =
        | TransferDestinationDU'String of string
        | TransferDestinationDU'Account of Account

    and TransferDestinationPaymentDU =
        | TransferDestinationPaymentDU'String of string
        | TransferDestinationPaymentDU'Charge of Charge

    and TransferSourceTransactionDU =
        | TransferSourceTransactionDU'String of string
        | TransferSourceTransactionDU'Charge of Charge

    ///
    and TransferData (destination: TransferDataDestinationDU, ?amount: int) =

        member _.Amount = amount
        member _.Destination = destination

    and TransferDataDestinationDU =
        | TransferDataDestinationDU'String of string
        | TransferDataDestinationDU'Account of Account

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
    and TransferReversal (amount: int, balanceTransaction: TransferReversalBalanceTransactionDU option, created: int, currency: string, destinationPaymentRefund: TransferReversalDestinationPaymentRefundDU option, id: string, metadata: Map<string, string> option, object: TransferReversalObject, sourceRefund: TransferReversalSourceRefundDU option, transfer: TransferReversalTransferDU) =

        member _.Amount = amount
        member _.BalanceTransaction = balanceTransaction
        member _.Created = created
        member _.Currency = currency
        member _.DestinationPaymentRefund = destinationPaymentRefund
        member _.Id = id
        member _.Metadata = metadata
        member _.Object = object
        member _.SourceRefund = sourceRefund
        member _.Transfer = transfer

    and TransferReversalObject =
        | TransferReversalObject'TransferReversal

    and TransferReversalBalanceTransactionDU =
        | TransferReversalBalanceTransactionDU'String of string
        | TransferReversalBalanceTransactionDU'BalanceTransaction of BalanceTransaction

    and TransferReversalDestinationPaymentRefundDU =
        | TransferReversalDestinationPaymentRefundDU'String of string
        | TransferReversalDestinationPaymentRefundDU'Refund of Refund

    and TransferReversalSourceRefundDU =
        | TransferReversalSourceRefundDU'String of string
        | TransferReversalSourceRefundDU'Refund of Refund

    and TransferReversalTransferDU =
        | TransferReversalTransferDU'String of string
        | TransferReversalTransferDU'Transfer of Transfer

    ///
    and TransferSchedule (delayDays: int, interval: string, ?monthlyAnchor: int, ?weeklyAnchor: string) =

        member _.DelayDays = delayDays
        member _.Interval = interval
        member _.MonthlyAnchor = monthlyAnchor
        member _.WeeklyAnchor = weeklyAnchor

    ///
    and TransformQuantity (divideBy: int, round: TransformQuantityRound) =

        member _.DivideBy = divideBy
        member _.Round = round

    and TransformQuantityRound =
        | TransformQuantityRound'Down
        | TransformQuantityRound'Up

    ///
    and TransformUsage (divideBy: int, round: TransformUsageRound) =

        member _.DivideBy = divideBy
        member _.Round = round

    and TransformUsageRound =
        | TransformUsageRound'Down
        | TransformUsageRound'Up

    ///Usage records allow you to report customer usage and metrics to Stripe for
    ///metered billing of subscription prices.
    ///
    ///Related guide: [Metered Billing](https://stripe.com/docs/billing/subscriptions/metered-billing).
    and UsageRecord (id: string, livemode: bool, object: UsageRecordObject, quantity: int, subscriptionItem: string, timestamp: int) =

        member _.Id = id
        member _.Livemode = livemode
        member _.Object = object
        member _.Quantity = quantity
        member _.SubscriptionItem = subscriptionItem
        member _.Timestamp = timestamp

    and UsageRecordObject =
        | UsageRecordObject'UsageRecord

    ///
    and UsageRecordSummary (id: string, invoice: string option, livemode: bool, object: UsageRecordSummaryObject, period: Period, subscriptionItem: string, totalUsage: int) =

        member _.Id = id
        member _.Invoice = invoice
        member _.Livemode = livemode
        member _.Object = object
        member _.Period = period
        member _.SubscriptionItem = subscriptionItem
        member _.TotalUsage = totalUsage

    and UsageRecordSummaryObject =
        | UsageRecordSummaryObject'UsageRecordSummary

    ///You can configure [webhook endpoints](https://stripe.com/docs/webhooks/) via the API to be
    ///notified about events that happen in your Stripe account or connected
    ///accounts.
    ///
    ///Most users configure webhooks from [the dashboard](https://dashboard.stripe.com/webhooks), which provides a user interface for registering and testing your webhook endpoints.
    ///
    ///Related guide: [Setting up Webhooks](https://stripe.com/docs/webhooks/configure).
    and WebhookEndpoint (apiVersion: string option, application: string option, created: int, description: string option, enabledEvents: string list, id: string, livemode: bool, metadata: Map<string, string>, object: WebhookEndpointObject, status: string, url: string, ?secret: string) =

        member _.ApiVersion = apiVersion
        member _.Application = application
        member _.Created = created
        member _.Description = description
        member _.EnabledEvents = enabledEvents
        member _.Id = id
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Object = object
        member _.Secret = secret
        member _.Status = status
        member _.Url = url

    and WebhookEndpointObject =
        | WebhookEndpointObject'WebhookEndpoint

