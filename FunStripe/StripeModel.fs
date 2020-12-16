namespace FunStripe

open FSharp.Json

module StripeModel =

    ///This is an object representing a Stripe account. You can retrieve it to see
    ///properties on the account like its current e-mail address or if the account is
    ///enabled yet to make live charges.
    ///
    ///Some properties, marked below, are available only to platforms that want to
    ///[create and manage Express or Custom accounts](https://stripe.com/docs/connect/accounts).
    type Account (id: string, ?businessProfile: AccountBusinessProfile option, ?businessType: AccountBusinessType option, ?capabilities: AccountCapabilities, ?chargesEnabled: bool, ?company: LegalEntityCompany, ?country: string, ?created: int64, ?defaultCurrency: string, ?detailsSubmitted: bool, ?email: string option, ?externalAccounts: Map<string, string>, ?individual: Person, ?metadata: Map<string, string>, ?payoutsEnabled: bool, ?requirements: AccountRequirements, ?settings: AccountSettings option, ?tosAcceptance: AccountTosAcceptance, ?``type``: AccountType) =

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
        member _.Object = "account"
        member _.PayoutsEnabled = payoutsEnabled
        member _.Requirements = requirements
        member _.Settings = settings |> Option.flatten
        member _.TosAcceptance = tosAcceptance
        member _.Type = ``type``

    and AccountBusinessType =
        | [<JsonUnionCase("company")>] AccountBusinessType'Company
        | [<JsonUnionCase("government_entity")>] AccountBusinessType'GovernmentEntity
        | [<JsonUnionCase("individual")>] AccountBusinessType'Individual
        | [<JsonUnionCase("non_profit")>] AccountBusinessType'NonProfit

    and AccountType =
        | [<JsonUnionCase("custom")>] AccountType'Custom
        | [<JsonUnionCase("express")>] AccountType'Express
        | [<JsonUnionCase("standard")>] AccountType'Standard

    ///
    and AccountBacsDebitPaymentsSettings (?displayName: string) =

        member _.DisplayName = displayName

    ///
    and AccountBrandingSettings (icon: Choice<string, File> option, logo: Choice<string, File> option, primaryColor: string option, secondaryColor: string option) =

        member _.Icon = icon
        member _.Logo = logo
        member _.PrimaryColor = primaryColor
        member _.SecondaryColor = secondaryColor

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
        | [<JsonUnionCase("active")>] AccountCapabilitiesAuBecsDebitPayments'Active
        | [<JsonUnionCase("inactive")>] AccountCapabilitiesAuBecsDebitPayments'Inactive
        | [<JsonUnionCase("pending")>] AccountCapabilitiesAuBecsDebitPayments'Pending

    and AccountCapabilitiesBacsDebitPayments =
        | [<JsonUnionCase("active")>] AccountCapabilitiesBacsDebitPayments'Active
        | [<JsonUnionCase("inactive")>] AccountCapabilitiesBacsDebitPayments'Inactive
        | [<JsonUnionCase("pending")>] AccountCapabilitiesBacsDebitPayments'Pending

    and AccountCapabilitiesBancontactPayments =
        | [<JsonUnionCase("active")>] AccountCapabilitiesBancontactPayments'Active
        | [<JsonUnionCase("inactive")>] AccountCapabilitiesBancontactPayments'Inactive
        | [<JsonUnionCase("pending")>] AccountCapabilitiesBancontactPayments'Pending

    and AccountCapabilitiesCardIssuing =
        | [<JsonUnionCase("active")>] AccountCapabilitiesCardIssuing'Active
        | [<JsonUnionCase("inactive")>] AccountCapabilitiesCardIssuing'Inactive
        | [<JsonUnionCase("pending")>] AccountCapabilitiesCardIssuing'Pending

    and AccountCapabilitiesCardPayments =
        | [<JsonUnionCase("active")>] AccountCapabilitiesCardPayments'Active
        | [<JsonUnionCase("inactive")>] AccountCapabilitiesCardPayments'Inactive
        | [<JsonUnionCase("pending")>] AccountCapabilitiesCardPayments'Pending

    and AccountCapabilitiesCartesBancairesPayments =
        | [<JsonUnionCase("active")>] AccountCapabilitiesCartesBancairesPayments'Active
        | [<JsonUnionCase("inactive")>] AccountCapabilitiesCartesBancairesPayments'Inactive
        | [<JsonUnionCase("pending")>] AccountCapabilitiesCartesBancairesPayments'Pending

    and AccountCapabilitiesEpsPayments =
        | [<JsonUnionCase("active")>] AccountCapabilitiesEpsPayments'Active
        | [<JsonUnionCase("inactive")>] AccountCapabilitiesEpsPayments'Inactive
        | [<JsonUnionCase("pending")>] AccountCapabilitiesEpsPayments'Pending

    and AccountCapabilitiesFpxPayments =
        | [<JsonUnionCase("active")>] AccountCapabilitiesFpxPayments'Active
        | [<JsonUnionCase("inactive")>] AccountCapabilitiesFpxPayments'Inactive
        | [<JsonUnionCase("pending")>] AccountCapabilitiesFpxPayments'Pending

    and AccountCapabilitiesGiropayPayments =
        | [<JsonUnionCase("active")>] AccountCapabilitiesGiropayPayments'Active
        | [<JsonUnionCase("inactive")>] AccountCapabilitiesGiropayPayments'Inactive
        | [<JsonUnionCase("pending")>] AccountCapabilitiesGiropayPayments'Pending

    and AccountCapabilitiesGrabpayPayments =
        | [<JsonUnionCase("active")>] AccountCapabilitiesGrabpayPayments'Active
        | [<JsonUnionCase("inactive")>] AccountCapabilitiesGrabpayPayments'Inactive
        | [<JsonUnionCase("pending")>] AccountCapabilitiesGrabpayPayments'Pending

    and AccountCapabilitiesIdealPayments =
        | [<JsonUnionCase("active")>] AccountCapabilitiesIdealPayments'Active
        | [<JsonUnionCase("inactive")>] AccountCapabilitiesIdealPayments'Inactive
        | [<JsonUnionCase("pending")>] AccountCapabilitiesIdealPayments'Pending

    and AccountCapabilitiesJcbPayments =
        | [<JsonUnionCase("active")>] AccountCapabilitiesJcbPayments'Active
        | [<JsonUnionCase("inactive")>] AccountCapabilitiesJcbPayments'Inactive
        | [<JsonUnionCase("pending")>] AccountCapabilitiesJcbPayments'Pending

    and AccountCapabilitiesLegacyPayments =
        | [<JsonUnionCase("active")>] AccountCapabilitiesLegacyPayments'Active
        | [<JsonUnionCase("inactive")>] AccountCapabilitiesLegacyPayments'Inactive
        | [<JsonUnionCase("pending")>] AccountCapabilitiesLegacyPayments'Pending

    and AccountCapabilitiesOxxoPayments =
        | [<JsonUnionCase("active")>] AccountCapabilitiesOxxoPayments'Active
        | [<JsonUnionCase("inactive")>] AccountCapabilitiesOxxoPayments'Inactive
        | [<JsonUnionCase("pending")>] AccountCapabilitiesOxxoPayments'Pending

    and AccountCapabilitiesP24Payments =
        | [<JsonUnionCase("active")>] AccountCapabilitiesP24Payments'Active
        | [<JsonUnionCase("inactive")>] AccountCapabilitiesP24Payments'Inactive
        | [<JsonUnionCase("pending")>] AccountCapabilitiesP24Payments'Pending

    and AccountCapabilitiesSepaDebitPayments =
        | [<JsonUnionCase("active")>] AccountCapabilitiesSepaDebitPayments'Active
        | [<JsonUnionCase("inactive")>] AccountCapabilitiesSepaDebitPayments'Inactive
        | [<JsonUnionCase("pending")>] AccountCapabilitiesSepaDebitPayments'Pending

    and AccountCapabilitiesSofortPayments =
        | [<JsonUnionCase("active")>] AccountCapabilitiesSofortPayments'Active
        | [<JsonUnionCase("inactive")>] AccountCapabilitiesSofortPayments'Inactive
        | [<JsonUnionCase("pending")>] AccountCapabilitiesSofortPayments'Pending

    and AccountCapabilitiesTaxReportingUs1099K =
        | [<JsonUnionCase("active")>] AccountCapabilitiesTaxReportingUs1099K'Active
        | [<JsonUnionCase("inactive")>] AccountCapabilitiesTaxReportingUs1099K'Inactive
        | [<JsonUnionCase("pending")>] AccountCapabilitiesTaxReportingUs1099K'Pending

    and AccountCapabilitiesTaxReportingUs1099Misc =
        | [<JsonUnionCase("active")>] AccountCapabilitiesTaxReportingUs1099Misc'Active
        | [<JsonUnionCase("inactive")>] AccountCapabilitiesTaxReportingUs1099Misc'Inactive
        | [<JsonUnionCase("pending")>] AccountCapabilitiesTaxReportingUs1099Misc'Pending

    and AccountCapabilitiesTransfers =
        | [<JsonUnionCase("active")>] AccountCapabilitiesTransfers'Active
        | [<JsonUnionCase("inactive")>] AccountCapabilitiesTransfers'Inactive
        | [<JsonUnionCase("pending")>] AccountCapabilitiesTransfers'Pending

    ///
    and AccountCapabilityRequirements (currentDeadline: int64 option, currentlyDue: string list, disabledReason: string option, errors: AccountRequirementsError list, eventuallyDue: string list, pastDue: string list, pendingVerification: string list) =

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
    and AccountLink (created: int64, expiresAt: int64, url: string) =

        member _.Created = created
        member _.ExpiresAt = expiresAt
        member _.Object = "account_link"
        member _.Url = url

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
    and AccountRequirements (currentDeadline: int64 option, currentlyDue: string list option, disabledReason: AccountRequirementsDisabledReason option, errors: AccountRequirementsError list option, eventuallyDue: string list option, pastDue: string list option, pendingVerification: string list option) =

        member _.CurrentDeadline = currentDeadline
        member _.CurrentlyDue = currentlyDue
        member _.DisabledReason = disabledReason
        member _.Errors = errors
        member _.EventuallyDue = eventuallyDue
        member _.PastDue = pastDue
        member _.PendingVerification = pendingVerification

    and AccountRequirementsDisabledReason =
        | [<JsonUnionCase("requirements.past_due")>] AccountRequirementsDisabledReason'RequirementsPastDue
        | [<JsonUnionCase("requirements.pending_verification")>] AccountRequirementsDisabledReason'RequirementsPendingVerification
        | [<JsonUnionCase("rejected.fraud")>] AccountRequirementsDisabledReason'RejectedFraud
        | [<JsonUnionCase("rejected.terms_of_service")>] AccountRequirementsDisabledReason'RejectedTermsOfService
        | [<JsonUnionCase("rejected.listed")>] AccountRequirementsDisabledReason'RejectedListed
        | [<JsonUnionCase("rejected.other")>] AccountRequirementsDisabledReason'RejectedOther
        | [<JsonUnionCase("listed")>] AccountRequirementsDisabledReason'Listed
        | [<JsonUnionCase("under_review")>] AccountRequirementsDisabledReason'UnderReview
        | [<JsonUnionCase("other")>] AccountRequirementsDisabledReason'Other

    ///
    and AccountRequirementsError (code: AccountRequirementsErrorCode, reason: string, requirement: string) =

        member _.Code = code
        member _.Reason = reason
        member _.Requirement = requirement

    and AccountRequirementsErrorCode =
        | [<JsonUnionCase("invalid_address_city_state_postal_code")>] AccountRequirementsErrorCode'InvalidAddressCityStatePostalCode
        | [<JsonUnionCase("invalid_street_address")>] AccountRequirementsErrorCode'InvalidStreetAddress
        | [<JsonUnionCase("invalid_value_other")>] AccountRequirementsErrorCode'InvalidValueOther
        | [<JsonUnionCase("verification_document_address_mismatch")>] AccountRequirementsErrorCode'VerificationDocumentAddressMismatch
        | [<JsonUnionCase("verification_document_address_missing")>] AccountRequirementsErrorCode'VerificationDocumentAddressMissing
        | [<JsonUnionCase("verification_document_corrupt")>] AccountRequirementsErrorCode'VerificationDocumentCorrupt
        | [<JsonUnionCase("verification_document_country_not_supported")>] AccountRequirementsErrorCode'VerificationDocumentCountryNotSupported
        | [<JsonUnionCase("verification_document_dob_mismatch")>] AccountRequirementsErrorCode'VerificationDocumentDobMismatch
        | [<JsonUnionCase("verification_document_duplicate_type")>] AccountRequirementsErrorCode'VerificationDocumentDuplicateType
        | [<JsonUnionCase("verification_document_expired")>] AccountRequirementsErrorCode'VerificationDocumentExpired
        | [<JsonUnionCase("verification_document_failed_copy")>] AccountRequirementsErrorCode'VerificationDocumentFailedCopy
        | [<JsonUnionCase("verification_document_failed_greyscale")>] AccountRequirementsErrorCode'VerificationDocumentFailedGreyscale
        | [<JsonUnionCase("verification_document_failed_other")>] AccountRequirementsErrorCode'VerificationDocumentFailedOther
        | [<JsonUnionCase("verification_document_failed_test_mode")>] AccountRequirementsErrorCode'VerificationDocumentFailedTestMode
        | [<JsonUnionCase("verification_document_fraudulent")>] AccountRequirementsErrorCode'VerificationDocumentFraudulent
        | [<JsonUnionCase("verification_document_id_number_mismatch")>] AccountRequirementsErrorCode'VerificationDocumentIdNumberMismatch
        | [<JsonUnionCase("verification_document_id_number_missing")>] AccountRequirementsErrorCode'VerificationDocumentIdNumberMissing
        | [<JsonUnionCase("verification_document_incomplete")>] AccountRequirementsErrorCode'VerificationDocumentIncomplete
        | [<JsonUnionCase("verification_document_invalid")>] AccountRequirementsErrorCode'VerificationDocumentInvalid
        | [<JsonUnionCase("verification_document_issue_or_expiry_date_missing")>] AccountRequirementsErrorCode'VerificationDocumentIssueOrExpiryDateMissing
        | [<JsonUnionCase("verification_document_manipulated")>] AccountRequirementsErrorCode'VerificationDocumentManipulated
        | [<JsonUnionCase("verification_document_missing_back")>] AccountRequirementsErrorCode'VerificationDocumentMissingBack
        | [<JsonUnionCase("verification_document_missing_front")>] AccountRequirementsErrorCode'VerificationDocumentMissingFront
        | [<JsonUnionCase("verification_document_name_mismatch")>] AccountRequirementsErrorCode'VerificationDocumentNameMismatch
        | [<JsonUnionCase("verification_document_name_missing")>] AccountRequirementsErrorCode'VerificationDocumentNameMissing
        | [<JsonUnionCase("verification_document_nationality_mismatch")>] AccountRequirementsErrorCode'VerificationDocumentNationalityMismatch
        | [<JsonUnionCase("verification_document_not_readable")>] AccountRequirementsErrorCode'VerificationDocumentNotReadable
        | [<JsonUnionCase("verification_document_not_signed")>] AccountRequirementsErrorCode'VerificationDocumentNotSigned
        | [<JsonUnionCase("verification_document_not_uploaded")>] AccountRequirementsErrorCode'VerificationDocumentNotUploaded
        | [<JsonUnionCase("verification_document_photo_mismatch")>] AccountRequirementsErrorCode'VerificationDocumentPhotoMismatch
        | [<JsonUnionCase("verification_document_too_large")>] AccountRequirementsErrorCode'VerificationDocumentTooLarge
        | [<JsonUnionCase("verification_document_type_not_supported")>] AccountRequirementsErrorCode'VerificationDocumentTypeNotSupported
        | [<JsonUnionCase("verification_failed_address_match")>] AccountRequirementsErrorCode'VerificationFailedAddressMatch
        | [<JsonUnionCase("verification_failed_business_iec_number")>] AccountRequirementsErrorCode'VerificationFailedBusinessIecNumber
        | [<JsonUnionCase("verification_failed_document_match")>] AccountRequirementsErrorCode'VerificationFailedDocumentMatch
        | [<JsonUnionCase("verification_failed_id_number_match")>] AccountRequirementsErrorCode'VerificationFailedIdNumberMatch
        | [<JsonUnionCase("verification_failed_keyed_identity")>] AccountRequirementsErrorCode'VerificationFailedKeyedIdentity
        | [<JsonUnionCase("verification_failed_keyed_match")>] AccountRequirementsErrorCode'VerificationFailedKeyedMatch
        | [<JsonUnionCase("verification_failed_name_match")>] AccountRequirementsErrorCode'VerificationFailedNameMatch
        | [<JsonUnionCase("verification_failed_other")>] AccountRequirementsErrorCode'VerificationFailedOther
        | [<JsonUnionCase("verification_failed_tax_id_match")>] AccountRequirementsErrorCode'VerificationFailedTaxIdMatch
        | [<JsonUnionCase("verification_failed_tax_id_not_issued")>] AccountRequirementsErrorCode'VerificationFailedTaxIdNotIssued

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
    and AccountTosAcceptance (?date: int64 option, ?ip: string option, ?serviceAgreement: string, ?userAgent: string option) =

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
    and AlipayAccount (created: int64, fingerprint: string, id: string, livemode: bool, paymentAmount: int64 option, paymentCurrency: string option, reusable: bool, used: bool, username: string, ?customer: Choice<string, Customer, DeletedCustomer> option, ?metadata: Map<string, string>) =

        member _.Created = created
        member _.Customer = customer |> Option.flatten
        member _.Fingerprint = fingerprint
        member _.Id = id
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Object = "alipay_account"
        member _.PaymentAmount = paymentAmount
        member _.PaymentCurrency = paymentCurrency
        member _.Reusable = reusable
        member _.Used = used
        member _.Username = username

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
        | [<JsonUnionCase("api_connection_error")>] ApiErrorsType'ApiConnectionError
        | [<JsonUnionCase("api_error")>] ApiErrorsType'ApiError
        | [<JsonUnionCase("authentication_error")>] ApiErrorsType'AuthenticationError
        | [<JsonUnionCase("card_error")>] ApiErrorsType'CardError
        | [<JsonUnionCase("idempotency_error")>] ApiErrorsType'IdempotencyError
        | [<JsonUnionCase("invalid_request_error")>] ApiErrorsType'InvalidRequestError
        | [<JsonUnionCase("rate_limit_error")>] ApiErrorsType'RateLimitError

    ///
    and ApplePayDomain (created: int64, domainName: string, id: string, livemode: bool) =

        member _.Created = created
        member _.DomainName = domainName
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = "apple_pay_domain"

    ///
    and Application (id: string, name: string option) =

        member _.Id = id
        member _.Name = name
        member _.Object = "application"

    ///
    and ApplicationFee (account: Choice<string, Account>, amount: int64, amountRefunded: int64, application: Choice<string, Application>, balanceTransaction: Choice<string, BalanceTransaction> option, charge: Choice<string, Charge>, created: int64, currency: string, id: string, livemode: bool, originatingTransaction: Choice<string, Charge> option, refunded: bool, refunds: Map<string, string>) =

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
        member _.Object = "application_fee"
        member _.OriginatingTransaction = originatingTransaction
        member _.Refunded = refunded
        member _.Refunds = refunds

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
    and Balance (available: BalanceAmount list, livemode: bool, pending: BalanceAmount list, ?connectReserved: BalanceAmount list, ?instantAvailable: BalanceAmount list, ?issuing: BalanceDetail) =

        member _.Available = available
        member _.ConnectReserved = connectReserved
        member _.InstantAvailable = instantAvailable
        member _.Issuing = issuing
        member _.Livemode = livemode
        member _.Object = "balance"
        member _.Pending = pending

    ///
    and BalanceAmount (amount: int64, currency: string, ?sourceTypes: BalanceAmountBySourceType) =

        member _.Amount = amount
        member _.Currency = currency
        member _.SourceTypes = sourceTypes

    ///
    and BalanceAmountBySourceType (?bankAccount: int64, ?card: int64, ?fpx: int64) =

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
    and BalanceTransaction (amount: int64, availableOn: int64, created: int64, currency: string, description: string option, exchangeRate: decimal option, fee: int64, feeDetails: Fee list, id: string, net: int64, reportingCategory: string, source: Choice<string, BalanceTransactionSource> option, status: string, ``type``: BalanceTransactionType) =

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
        member _.Object = "balance_transaction"
        member _.ReportingCategory = reportingCategory
        member _.Source = source
        member _.Status = status
        member _.Type = ``type``

    and BalanceTransactionType =
        | [<JsonUnionCase("adjustment")>] BalanceTransactionType'Adjustment
        | [<JsonUnionCase("advance")>] BalanceTransactionType'Advance
        | [<JsonUnionCase("advance_funding")>] BalanceTransactionType'AdvanceFunding
        | [<JsonUnionCase("anticipation_repayment")>] BalanceTransactionType'AnticipationRepayment
        | [<JsonUnionCase("application_fee")>] BalanceTransactionType'ApplicationFee
        | [<JsonUnionCase("application_fee_refund")>] BalanceTransactionType'ApplicationFeeRefund
        | [<JsonUnionCase("charge")>] BalanceTransactionType'Charge
        | [<JsonUnionCase("connect_collection_transfer")>] BalanceTransactionType'ConnectCollectionTransfer
        | [<JsonUnionCase("contribution")>] BalanceTransactionType'Contribution
        | [<JsonUnionCase("issuing_authorization_hold")>] BalanceTransactionType'IssuingAuthorizationHold
        | [<JsonUnionCase("issuing_authorization_release")>] BalanceTransactionType'IssuingAuthorizationRelease
        | [<JsonUnionCase("issuing_dispute")>] BalanceTransactionType'IssuingDispute
        | [<JsonUnionCase("issuing_transaction")>] BalanceTransactionType'IssuingTransaction
        | [<JsonUnionCase("payment")>] BalanceTransactionType'Payment
        | [<JsonUnionCase("payment_failure_refund")>] BalanceTransactionType'PaymentFailureRefund
        | [<JsonUnionCase("payment_refund")>] BalanceTransactionType'PaymentRefund
        | [<JsonUnionCase("payout")>] BalanceTransactionType'Payout
        | [<JsonUnionCase("payout_cancel")>] BalanceTransactionType'PayoutCancel
        | [<JsonUnionCase("payout_failure")>] BalanceTransactionType'PayoutFailure
        | [<JsonUnionCase("refund")>] BalanceTransactionType'Refund
        | [<JsonUnionCase("refund_failure")>] BalanceTransactionType'RefundFailure
        | [<JsonUnionCase("reserve_transaction")>] BalanceTransactionType'ReserveTransaction
        | [<JsonUnionCase("reserved_funds")>] BalanceTransactionType'ReservedFunds
        | [<JsonUnionCase("stripe_fee")>] BalanceTransactionType'StripeFee
        | [<JsonUnionCase("stripe_fx_fee")>] BalanceTransactionType'StripeFxFee
        | [<JsonUnionCase("tax_fee")>] BalanceTransactionType'TaxFee
        | [<JsonUnionCase("topup")>] BalanceTransactionType'Topup
        | [<JsonUnionCase("topup_reversal")>] BalanceTransactionType'TopupReversal
        | [<JsonUnionCase("transfer")>] BalanceTransactionType'Transfer
        | [<JsonUnionCase("transfer_cancel")>] BalanceTransactionType'TransferCancel
        | [<JsonUnionCase("transfer_failure")>] BalanceTransactionType'TransferFailure
        | [<JsonUnionCase("transfer_refund")>] BalanceTransactionType'TransferRefund

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
    and BankAccount (accountHolderName: string option, accountHolderType: string option, bankName: string option, country: string, currency: string, fingerprint: string option, id: string, last4: string, routingNumber: string option, status: string, ?account: Choice<string, Account> option, ?availablePayoutMethods: BankAccountAvailablePayoutMethods list option, ?customer: Choice<string, Customer, DeletedCustomer> option, ?defaultForCurrency: bool option, ?metadata: Map<string, string> option) =

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
        member _.Object = "bank_account"
        member _.RoutingNumber = routingNumber
        member _.Status = status

    and BankAccountAvailablePayoutMethods =
        | [<JsonUnionCase("instant")>] BankAccountAvailablePayoutMethods'Instant
        | [<JsonUnionCase("standard")>] BankAccountAvailablePayoutMethods'Standard

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
    and BillingPortalSession (created: int64, customer: string, id: string, livemode: bool, returnUrl: string, url: string) =

        member _.Created = created
        member _.Customer = customer
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = "billing_portal.session"
        member _.ReturnUrl = returnUrl
        member _.Url = url

    ///
    and BitcoinReceiver (active: bool, amount: int64, amountReceived: int64, bitcoinAmount: int64, bitcoinAmountReceived: int64, bitcoinUri: string, created: int64, currency: string, description: string option, email: string option, filled: bool, id: string, inboundAddress: string, livemode: bool, metadata: Map<string, string> option, refundAddress: string option, uncapturedFunds: bool, usedForPayment: bool option, ?customer: string option, ?payment: string option, ?transactions: Map<string, string>) =

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
        member _.Object = "bitcoin_receiver"
        member _.Payment = payment |> Option.flatten
        member _.RefundAddress = refundAddress
        member _.Transactions = transactions
        member _.UncapturedFunds = uncapturedFunds
        member _.UsedForPayment = usedForPayment

    ///
    and BitcoinTransaction (amount: int64, bitcoinAmount: int64, created: int64, currency: string, id: string, receiver: string) =

        member _.Amount = amount
        member _.BitcoinAmount = bitcoinAmount
        member _.Created = created
        member _.Currency = currency
        member _.Id = id
        member _.Object = "bitcoin_transaction"
        member _.Receiver = receiver

    ///This is an object representing a capability for a Stripe account.
    ///
    ///Related guide: [Account capabilities](https://stripe.com/docs/connect/account-capabilities).
    and Capability (account: Choice<string, Account>, id: string, requested: bool, requestedAt: int64 option, status: CapabilityStatus, ?requirements: AccountCapabilityRequirements) =

        member _.Account = account
        member _.Id = id
        member _.Object = "capability"
        member _.Requested = requested
        member _.RequestedAt = requestedAt
        member _.Requirements = requirements
        member _.Status = status

    and CapabilityStatus =
        | [<JsonUnionCase("active")>] CapabilityStatus'Active
        | [<JsonUnionCase("disabled")>] CapabilityStatus'Disabled
        | [<JsonUnionCase("inactive")>] CapabilityStatus'Inactive
        | [<JsonUnionCase("pending")>] CapabilityStatus'Pending
        | [<JsonUnionCase("unrequested")>] CapabilityStatus'Unrequested

    ///You can store multiple cards on a customer in order to charge the customer
    ///later. You can also store multiple debit cards on a recipient in order to
    ///transfer to those cards later.
    ///
    ///Related guide: [Card Payments with Sources](https://stripe.com/docs/sources/cards).
    and Card (addressCity: string option, addressCountry: string option, addressLine1: string option, addressLine1Check: string option, addressLine2: string option, addressState: string option, addressZip: string option, addressZipCheck: string option, brand: CardBrand, country: string option, cvcCheck: string option, dynamicLast4: string option, expMonth: int64, expYear: int64, funding: CardFunding, id: string, last4: string, metadata: Map<string, string> option, name: string option, tokenizationMethod: CardTokenizationMethod option, ?account: Choice<string, Account> option, ?availablePayoutMethods: CardAvailablePayoutMethods list option, ?currency: string option, ?customer: Choice<string, Customer, DeletedCustomer> option, ?defaultForCurrency: bool option, ?description: string, ?fingerprint: string option, ?iin: string, ?issuer: string, ?recipient: Choice<string, Recipient> option) =

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
        member _.Object = "card"
        member _.Recipient = recipient |> Option.flatten
        member _.TokenizationMethod = tokenizationMethod

    and CardAvailablePayoutMethods =
        | [<JsonUnionCase("instant")>] CardAvailablePayoutMethods'Instant
        | [<JsonUnionCase("standard")>] CardAvailablePayoutMethods'Standard

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
        | [<JsonUnionCase("credit")>] CardFunding'Credit
        | [<JsonUnionCase("debit")>] CardFunding'Debit
        | [<JsonUnionCase("prepaid")>] CardFunding'Prepaid
        | [<JsonUnionCase("unknown")>] CardFunding'Unknown

    and CardTokenizationMethod =
        | [<JsonUnionCase("android_pay")>] CardTokenizationMethod'AndroidPay
        | [<JsonUnionCase("apple_pay")>] CardTokenizationMethod'ApplePay
        | [<JsonUnionCase("masterpass")>] CardTokenizationMethod'Masterpass
        | [<JsonUnionCase("visa_checkout")>] CardTokenizationMethod'VisaCheckout

    ///
    and CardMandatePaymentMethodDetails (?undefined: string list) =

        member _.Undefined = undefined

    ///To charge a credit or a debit card, you create a `Charge` object. You can
    ///retrieve and refund individual charges as well as list all charges. Charges
    ///are identified by a unique, random ID.
    ///
    ///Related guide: [Accept a payment with the Charges API](https://stripe.com/docs/payments/accept-a-payment-charges).
    and Charge (amount: int64, amountCaptured: int64, amountRefunded: int64, application: Choice<string, Application> option, applicationFee: Choice<string, ApplicationFee> option, applicationFeeAmount: int64 option, balanceTransaction: Choice<string, BalanceTransaction> option, billingDetails: BillingDetails, calculatedStatementDescriptor: string option, captured: bool, created: int64, currency: string, customer: Choice<string, Customer, DeletedCustomer> option, description: string option, destination: Choice<string, Account> option, dispute: Choice<string, Dispute> option, disputed: bool, failureCode: string option, failureMessage: string option, fraudDetails: ChargeFraudDetails option, id: string, invoice: Choice<string, Invoice> option, livemode: bool, metadata: Map<string, string>, onBehalfOf: Choice<string, Account> option, order: Choice<string, Order> option, outcome: ChargeOutcome option, paid: bool, paymentIntent: Choice<string, PaymentIntent> option, paymentMethod: string option, paymentMethodDetails: PaymentMethodDetails option, receiptEmail: string option, receiptNumber: string option, receiptUrl: string option, refunded: bool, refunds: Map<string, string>, review: Choice<string, Review> option, shipping: Shipping option, source: PaymentSource option, sourceTransfer: Choice<string, Transfer> option, statementDescriptor: string option, statementDescriptorSuffix: string option, status: string, transferData: ChargeTransferData option, transferGroup: string option, ?alternateStatementDescriptors: AlternateStatementDescriptors, ?authorizationCode: string, ?level3: Level3, ?transfer: Choice<string, Transfer>) =

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
        member _.Object = "charge"
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

    ///
    and ChargeFraudDetails (?stripeReport: string, ?userReport: string) =

        member _.StripeReport = stripeReport
        member _.UserReport = userReport

    ///
    and ChargeOutcome (networkStatus: string option, reason: string option, sellerMessage: string option, ``type``: string, ?riskLevel: string, ?riskScore: int64, ?rule: Choice<string, Rule>) =

        member _.NetworkStatus = networkStatus
        member _.Reason = reason
        member _.RiskLevel = riskLevel
        member _.RiskScore = riskScore
        member _.Rule = rule
        member _.SellerMessage = sellerMessage
        member _.Type = ``type``

    ///
    and ChargeTransferData (amount: int64 option, destination: Choice<string, Account>) =

        member _.Amount = amount
        member _.Destination = destination

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
    and CheckoutSession (allowPromotionCodes: bool option, amountSubtotal: int64 option, amountTotal: int64 option, billingAddressCollection: CheckoutSessionBillingAddressCollection option, cancelUrl: string, clientReferenceId: string option, currency: string option, customer: Choice<string, Customer, DeletedCustomer> option, customerEmail: string option, id: string, livemode: bool, locale: CheckoutSessionLocale option, metadata: Map<string, string> option, mode: CheckoutSessionMode, paymentIntent: Choice<string, PaymentIntent> option, paymentMethodTypes: string list, paymentStatus: CheckoutSessionPaymentStatus, setupIntent: Choice<string, SetupIntent> option, shipping: Shipping option, shippingAddressCollection: PaymentPagesPaymentPageResourcesShippingAddressCollection option, submitType: CheckoutSessionSubmitType option, subscription: Choice<string, Subscription> option, successUrl: string, totalDetails: PaymentPagesCheckoutSessionTotalDetails option, ?lineItems: Map<string, string>) =

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
        member _.Object = "checkout.session"
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
        | [<JsonUnionCase("auto")>] CheckoutSessionBillingAddressCollection'Auto
        | [<JsonUnionCase("required")>] CheckoutSessionBillingAddressCollection'Required

    and CheckoutSessionLocale =
        | [<JsonUnionCase("auto")>] CheckoutSessionLocale'Auto
        | [<JsonUnionCase("bg")>] CheckoutSessionLocale'Bg
        | [<JsonUnionCase("cs")>] CheckoutSessionLocale'Cs
        | [<JsonUnionCase("da")>] CheckoutSessionLocale'Da
        | [<JsonUnionCase("de")>] CheckoutSessionLocale'De
        | [<JsonUnionCase("el")>] CheckoutSessionLocale'El
        | [<JsonUnionCase("en")>] CheckoutSessionLocale'En
        | [<JsonUnionCase("en-GB")>] CheckoutSessionLocale'EnGB
        | [<JsonUnionCase("es")>] CheckoutSessionLocale'Es
        | [<JsonUnionCase("es-419")>] CheckoutSessionLocale'Es419
        | [<JsonUnionCase("et")>] CheckoutSessionLocale'Et
        | [<JsonUnionCase("fi")>] CheckoutSessionLocale'Fi
        | [<JsonUnionCase("fr")>] CheckoutSessionLocale'Fr
        | [<JsonUnionCase("fr-CA")>] CheckoutSessionLocale'FrCA
        | [<JsonUnionCase("hu")>] CheckoutSessionLocale'Hu
        | [<JsonUnionCase("id")>] CheckoutSessionLocale'Id
        | [<JsonUnionCase("it")>] CheckoutSessionLocale'It
        | [<JsonUnionCase("ja")>] CheckoutSessionLocale'Ja
        | [<JsonUnionCase("lt")>] CheckoutSessionLocale'Lt
        | [<JsonUnionCase("lv")>] CheckoutSessionLocale'Lv
        | [<JsonUnionCase("ms")>] CheckoutSessionLocale'Ms
        | [<JsonUnionCase("mt")>] CheckoutSessionLocale'Mt
        | [<JsonUnionCase("nb")>] CheckoutSessionLocale'Nb
        | [<JsonUnionCase("nl")>] CheckoutSessionLocale'Nl
        | [<JsonUnionCase("pl")>] CheckoutSessionLocale'Pl
        | [<JsonUnionCase("pt")>] CheckoutSessionLocale'Pt
        | [<JsonUnionCase("pt-BR")>] CheckoutSessionLocale'PtBR
        | [<JsonUnionCase("ro")>] CheckoutSessionLocale'Ro
        | [<JsonUnionCase("ru")>] CheckoutSessionLocale'Ru
        | [<JsonUnionCase("sk")>] CheckoutSessionLocale'Sk
        | [<JsonUnionCase("sl")>] CheckoutSessionLocale'Sl
        | [<JsonUnionCase("sv")>] CheckoutSessionLocale'Sv
        | [<JsonUnionCase("tr")>] CheckoutSessionLocale'Tr
        | [<JsonUnionCase("zh")>] CheckoutSessionLocale'Zh
        | [<JsonUnionCase("zh-HK")>] CheckoutSessionLocale'ZhHK
        | [<JsonUnionCase("zh-TW")>] CheckoutSessionLocale'ZhTW

    and CheckoutSessionMode =
        | [<JsonUnionCase("payment")>] CheckoutSessionMode'Payment
        | [<JsonUnionCase("setup")>] CheckoutSessionMode'Setup
        | [<JsonUnionCase("subscription")>] CheckoutSessionMode'Subscription

    and CheckoutSessionPaymentStatus =
        | [<JsonUnionCase("no_payment_required")>] CheckoutSessionPaymentStatus'NoPaymentRequired
        | [<JsonUnionCase("paid")>] CheckoutSessionPaymentStatus'Paid
        | [<JsonUnionCase("unpaid")>] CheckoutSessionPaymentStatus'Unpaid

    and CheckoutSessionSubmitType =
        | [<JsonUnionCase("auto")>] CheckoutSessionSubmitType'Auto
        | [<JsonUnionCase("book")>] CheckoutSessionSubmitType'Book
        | [<JsonUnionCase("donate")>] CheckoutSessionSubmitType'Donate
        | [<JsonUnionCase("pay")>] CheckoutSessionSubmitType'Pay

    ///
    and ConnectCollectionTransfer (amount: int64, currency: string, destination: Choice<string, Account>, id: string, livemode: bool) =

        member _.Amount = amount
        member _.Currency = currency
        member _.Destination = destination
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = "connect_collection_transfer"

    ///Stripe needs to collect certain pieces of information about each account
    ///created. These requirements can differ depending on the account's country. The
    ///Country Specs API makes these rules available to your integration.
    ///
    ///You can also view the information from this API call as [an online
    ///guide](/docs/connect/required-verification-information).
    and CountrySpec (defaultCurrency: string, id: string, supportedBankAccountCurrencies: Map<string, string>, supportedPaymentCurrencies: string list, supportedPaymentMethods: string list, supportedTransferCountries: string list, verificationFields: CountrySpecVerificationFields) =

        member _.DefaultCurrency = defaultCurrency
        member _.Id = id
        member _.Object = "country_spec"
        member _.SupportedBankAccountCurrencies = supportedBankAccountCurrencies
        member _.SupportedPaymentCurrencies = supportedPaymentCurrencies
        member _.SupportedPaymentMethods = supportedPaymentMethods
        member _.SupportedTransferCountries = supportedTransferCountries
        member _.VerificationFields = verificationFields

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
    and Coupon (amountOff: int64 option, created: int64, currency: string option, duration: CouponDuration, durationInMonths: int64 option, id: string, livemode: bool, maxRedemptions: int64 option, metadata: Map<string, string> option, name: string option, percentOff: decimal option, redeemBy: int64 option, timesRedeemed: int64, valid: bool, ?appliesTo: CouponAppliesTo) =

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
        member _.Object = "coupon"
        member _.PercentOff = percentOff
        member _.RedeemBy = redeemBy
        member _.TimesRedeemed = timesRedeemed
        member _.Valid = valid

    and CouponDuration =
        | [<JsonUnionCase("forever")>] CouponDuration'Forever
        | [<JsonUnionCase("once")>] CouponDuration'Once
        | [<JsonUnionCase("repeating")>] CouponDuration'Repeating

    ///
    and CouponAppliesTo (products: string list) =

        member _.Products = products

    ///Issue a credit note to adjust an invoice's amount after the invoice is finalized.
    ///
    ///Related guide: [Credit Notes](https://stripe.com/docs/billing/invoices/credit-notes).
    and CreditNote (amount: int64, created: int64, currency: string, customer: Choice<string, Customer, DeletedCustomer>, customerBalanceTransaction: Choice<string, CustomerBalanceTransaction> option, discountAmount: int64, discountAmounts: DiscountsResourceDiscountAmount list, id: string, invoice: Choice<string, Invoice>, lines: Map<string, string>, livemode: bool, memo: string option, metadata: Map<string, string> option, number: string, outOfBandAmount: int64 option, pdf: string, reason: CreditNoteReason option, refund: Choice<string, Refund> option, status: CreditNoteStatus, subtotal: int64, taxAmounts: CreditNoteTaxAmount list, total: int64, ``type``: CreditNoteType, voidedAt: int64 option) =

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
        member _.Object = "credit_note"
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

    and CreditNoteReason =
        | [<JsonUnionCase("duplicate")>] CreditNoteReason'Duplicate
        | [<JsonUnionCase("fraudulent")>] CreditNoteReason'Fraudulent
        | [<JsonUnionCase("order_change")>] CreditNoteReason'OrderChange
        | [<JsonUnionCase("product_unsatisfactory")>] CreditNoteReason'ProductUnsatisfactory

    and CreditNoteStatus =
        | [<JsonUnionCase("issued")>] CreditNoteStatus'Issued
        | [<JsonUnionCase("void")>] CreditNoteStatus'Void

    and CreditNoteType =
        | [<JsonUnionCase("post_payment")>] CreditNoteType'PostPayment
        | [<JsonUnionCase("pre_payment")>] CreditNoteType'PrePayment

    ///
    and CreditNoteLineItem (amount: int64, description: string option, discountAmount: int64, discountAmounts: DiscountsResourceDiscountAmount list, id: string, livemode: bool, quantity: int64 option, taxAmounts: CreditNoteTaxAmount list, taxRates: TaxRate list, ``type``: CreditNoteLineItemType, unitAmount: int64 option, unitAmountDecimal: string option, ?invoiceLineItem: string) =

        member _.Amount = amount
        member _.Description = description
        member _.DiscountAmount = discountAmount
        member _.DiscountAmounts = discountAmounts
        member _.Id = id
        member _.InvoiceLineItem = invoiceLineItem
        member _.Livemode = livemode
        member _.Object = "credit_note_line_item"
        member _.Quantity = quantity
        member _.TaxAmounts = taxAmounts
        member _.TaxRates = taxRates
        member _.Type = ``type``
        member _.UnitAmount = unitAmount
        member _.UnitAmountDecimal = unitAmountDecimal

    and CreditNoteLineItemType =
        | [<JsonUnionCase("custom_line_item")>] CreditNoteLineItemType'CustomLineItem
        | [<JsonUnionCase("invoice_line_item")>] CreditNoteLineItemType'InvoiceLineItem

    ///
    and CreditNoteTaxAmount (amount: int64, inclusive: bool, taxRate: Choice<string, TaxRate>) =

        member _.Amount = amount
        member _.Inclusive = inclusive
        member _.TaxRate = taxRate

    ///`Customer` objects allow you to perform recurring charges, and to track
    ///multiple charges, that are associated with the same customer. The API allows
    ///you to create, delete, and update your customers. You can retrieve individual
    ///customers as well as a list of all your customers.
    ///
    ///Related guide: [Save a card during payment](https://stripe.com/docs/payments/save-during-payment).
    and Customer (created: int64, defaultSource: Choice<string, PaymentSource> option, description: string option, email: string option, id: string, livemode: bool, shipping: Shipping option, ?address: Address option, ?balance: int64, ?currency: string option, ?delinquent: bool option, ?discount: Discount option, ?invoicePrefix: string option, ?invoiceSettings: InvoiceSettingCustomerSetting, ?metadata: Map<string, string>, ?name: string option, ?nextInvoiceSequence: int64, ?phone: string option, ?preferredLocales: string list option, ?sources: Map<string, string>, ?subscriptions: Map<string, string>, ?taxExempt: CustomerTaxExempt option, ?taxIds: Map<string, string>) =

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
        member _.Object = "customer"
        member _.Phone = phone |> Option.flatten
        member _.PreferredLocales = preferredLocales |> Option.flatten
        member _.Shipping = shipping
        member _.Sources = sources
        member _.Subscriptions = subscriptions
        member _.TaxExempt = taxExempt |> Option.flatten
        member _.TaxIds = taxIds

    and CustomerTaxExempt =
        | [<JsonUnionCase("exempt")>] CustomerTaxExempt'Exempt
        | [<JsonUnionCase("none")>] CustomerTaxExempt'None
        | [<JsonUnionCase("reverse")>] CustomerTaxExempt'Reverse

    ///
    and CustomerAcceptance (acceptedAt: int64 option, ``type``: CustomerAcceptanceType, ?offline: OfflineAcceptance, ?online: OnlineAcceptance) =

        member _.AcceptedAt = acceptedAt
        member _.Offline = offline
        member _.Online = online
        member _.Type = ``type``

    and CustomerAcceptanceType =
        | [<JsonUnionCase("offline")>] CustomerAcceptanceType'Offline
        | [<JsonUnionCase("online")>] CustomerAcceptanceType'Online

    ///Each customer has a [`balance`](https://stripe.com/docs/api/customers/object#customer_object-balance) value,
    ///which denotes a debit or credit that's automatically applied to their next invoice upon finalization.
    ///You may modify the value directly by using the [update customer API](https://stripe.com/docs/api/customers/update),
    ///or by creating a Customer Balance Transaction, which increments or decrements the customer's `balance` by the specified `amount`.
    ///
    ///Related guide: [Customer Balance](https://stripe.com/docs/billing/customer/balance) to learn more.
    and CustomerBalanceTransaction (amount: int64, created: int64, creditNote: Choice<string, CreditNote> option, currency: string, customer: Choice<string, Customer>, description: string option, endingBalance: int64, id: string, invoice: Choice<string, Invoice> option, livemode: bool, metadata: Map<string, string> option, ``type``: CustomerBalanceTransactionType) =

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
        member _.Object = "customer_balance_transaction"
        member _.Type = ``type``

    and CustomerBalanceTransactionType =
        | [<JsonUnionCase("adjustment")>] CustomerBalanceTransactionType'Adjustment
        | [<JsonUnionCase("applied_to_invoice")>] CustomerBalanceTransactionType'AppliedToInvoice
        | [<JsonUnionCase("credit_note")>] CustomerBalanceTransactionType'CreditNote
        | [<JsonUnionCase("initial")>] CustomerBalanceTransactionType'Initial
        | [<JsonUnionCase("invoice_too_large")>] CustomerBalanceTransactionType'InvoiceTooLarge
        | [<JsonUnionCase("invoice_too_small")>] CustomerBalanceTransactionType'InvoiceTooSmall
        | [<JsonUnionCase("migration")>] CustomerBalanceTransactionType'Migration
        | [<JsonUnionCase("unapplied_from_invoice")>] CustomerBalanceTransactionType'UnappliedFromInvoice
        | [<JsonUnionCase("unspent_receiver_credit")>] CustomerBalanceTransactionType'UnspentReceiverCredit

    ///
    and DeletedAccount (deleted: DeletedAccountDeleted, id: string) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = "deleted_account"

    and DeletedAccountDeleted =
        | [<JsonUnionCase("true")>] DeletedAccountDeleted'True

    ///
    and DeletedAlipayAccount (deleted: DeletedAlipayAccountDeleted, id: string) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = "deleted_alipay_account"

    and DeletedAlipayAccountDeleted =
        | [<JsonUnionCase("true")>] DeletedAlipayAccountDeleted'True

    ///
    and DeletedApplePayDomain (deleted: DeletedApplePayDomainDeleted, id: string) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = "deleted_apple_pay_domain"

    and DeletedApplePayDomainDeleted =
        | [<JsonUnionCase("true")>] DeletedApplePayDomainDeleted'True

    ///
    and DeletedBankAccount (currency: string option, deleted: DeletedBankAccountDeleted, id: string) =

        member _.Currency = currency
        member _.Deleted = deleted
        member _.Id = id
        member _.Object = "deleted_bank_account"

    and DeletedBankAccountDeleted =
        | [<JsonUnionCase("true")>] DeletedBankAccountDeleted'True

    ///
    and DeletedBitcoinReceiver (deleted: DeletedBitcoinReceiverDeleted, id: string) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = "deleted_bitcoin_receiver"

    and DeletedBitcoinReceiverDeleted =
        | [<JsonUnionCase("true")>] DeletedBitcoinReceiverDeleted'True

    ///
    and DeletedCard (currency: string option, deleted: DeletedCardDeleted, id: string) =

        member _.Currency = currency
        member _.Deleted = deleted
        member _.Id = id
        member _.Object = "deleted_card"

    and DeletedCardDeleted =
        | [<JsonUnionCase("true")>] DeletedCardDeleted'True

    ///
    and DeletedCoupon (deleted: DeletedCouponDeleted, id: string) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = "deleted_coupon"

    and DeletedCouponDeleted =
        | [<JsonUnionCase("true")>] DeletedCouponDeleted'True

    ///
    and DeletedCustomer (deleted: DeletedCustomerDeleted, id: string) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = "deleted_customer"

    and DeletedCustomerDeleted =
        | [<JsonUnionCase("true")>] DeletedCustomerDeleted'True

    ///
    and DeletedDiscount (checkoutSession: string option, coupon: Coupon, customer: Choice<string, Customer, DeletedCustomer> option, deleted: DeletedDiscountDeleted, id: string, invoice: string option, invoiceItem: string option, promotionCode: Choice<string, PromotionCode> option, start: int64, subscription: string option) =

        member _.CheckoutSession = checkoutSession
        member _.Coupon = coupon
        member _.Customer = customer
        member _.Deleted = deleted
        member _.Id = id
        member _.Invoice = invoice
        member _.InvoiceItem = invoiceItem
        member _.Object = "deleted_discount"
        member _.PromotionCode = promotionCode
        member _.Start = start
        member _.Subscription = subscription

    and DeletedDiscountDeleted =
        | [<JsonUnionCase("true")>] DeletedDiscountDeleted'True

    and DeletedExternalAccount =
        | DeletedBankAccount of DeletedBankAccount
        | DeletedCard of DeletedCard

    ///
    and DeletedInvoice (deleted: DeletedInvoiceDeleted, id: string) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = "deleted_invoice"

    and DeletedInvoiceDeleted =
        | [<JsonUnionCase("true")>] DeletedInvoiceDeleted'True

    ///
    and DeletedInvoiceitem (deleted: DeletedInvoiceitemDeleted, id: string) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = "deleted_invoiceitem"

    and DeletedInvoiceitemDeleted =
        | [<JsonUnionCase("true")>] DeletedInvoiceitemDeleted'True

    and DeletedPaymentSource =
        | DeletedAlipayAccount of DeletedAlipayAccount
        | DeletedBankAccount of DeletedBankAccount
        | DeletedBitcoinReceiver of DeletedBitcoinReceiver
        | DeletedCard of DeletedCard

    ///
    and DeletedPerson (deleted: DeletedPersonDeleted, id: string) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = "deleted_person"

    and DeletedPersonDeleted =
        | [<JsonUnionCase("true")>] DeletedPersonDeleted'True

    ///
    and DeletedPlan (deleted: DeletedPlanDeleted, id: string) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = "deleted_plan"

    and DeletedPlanDeleted =
        | [<JsonUnionCase("true")>] DeletedPlanDeleted'True

    ///
    and DeletedPrice (deleted: DeletedPriceDeleted, id: string) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = "deleted_price"

    and DeletedPriceDeleted =
        | [<JsonUnionCase("true")>] DeletedPriceDeleted'True

    ///
    and DeletedProduct (deleted: DeletedProductDeleted, id: string) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = "deleted_product"

    and DeletedProductDeleted =
        | [<JsonUnionCase("true")>] DeletedProductDeleted'True

    ///
    and DeletedRadarValueList (deleted: DeletedRadarValueListDeleted, id: string) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = "deleted_radar.value_list"

    and DeletedRadarValueListDeleted =
        | [<JsonUnionCase("true")>] DeletedRadarValueListDeleted'True

    ///
    and DeletedRadarValueListItem (deleted: DeletedRadarValueListItemDeleted, id: string) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = "deleted_radar.value_list_item"

    and DeletedRadarValueListItemDeleted =
        | [<JsonUnionCase("true")>] DeletedRadarValueListItemDeleted'True

    ///
    and DeletedRecipient (deleted: DeletedRecipientDeleted, id: string) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = "deleted_recipient"

    and DeletedRecipientDeleted =
        | [<JsonUnionCase("true")>] DeletedRecipientDeleted'True

    ///
    and DeletedSku (deleted: DeletedSkuDeleted, id: string) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = "deleted_sku"

    and DeletedSkuDeleted =
        | [<JsonUnionCase("true")>] DeletedSkuDeleted'True

    ///
    and DeletedSubscriptionItem (deleted: DeletedSubscriptionItemDeleted, id: string) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = "deleted_subscription_item"

    and DeletedSubscriptionItemDeleted =
        | [<JsonUnionCase("true")>] DeletedSubscriptionItemDeleted'True

    ///
    and DeletedTaxId (deleted: DeletedTaxIdDeleted, id: string) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = "deleted_tax_id"

    and DeletedTaxIdDeleted =
        | [<JsonUnionCase("true")>] DeletedTaxIdDeleted'True

    ///
    and DeletedTerminalLocation (deleted: DeletedTerminalLocationDeleted, id: string) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = "deleted_terminal.location"

    and DeletedTerminalLocationDeleted =
        | [<JsonUnionCase("true")>] DeletedTerminalLocationDeleted'True

    ///
    and DeletedTerminalReader (deleted: DeletedTerminalReaderDeleted, id: string) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = "deleted_terminal.reader"

    and DeletedTerminalReaderDeleted =
        | [<JsonUnionCase("true")>] DeletedTerminalReaderDeleted'True

    ///
    and DeletedWebhookEndpoint (deleted: DeletedWebhookEndpointDeleted, id: string) =

        member _.Deleted = deleted
        member _.Id = id
        member _.Object = "deleted_webhook_endpoint"

    and DeletedWebhookEndpointDeleted =
        | [<JsonUnionCase("true")>] DeletedWebhookEndpointDeleted'True

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
    and Discount (checkoutSession: string option, coupon: Coupon, customer: Choice<string, Customer, DeletedCustomer> option, ``end``: int64 option, id: string, invoice: string option, invoiceItem: string option, promotionCode: Choice<string, PromotionCode> option, start: int64, subscription: string option) =

        member _.CheckoutSession = checkoutSession
        member _.Coupon = coupon
        member _.Customer = customer
        member _.End = ``end``
        member _.Id = id
        member _.Invoice = invoice
        member _.InvoiceItem = invoiceItem
        member _.Object = "discount"
        member _.PromotionCode = promotionCode
        member _.Start = start
        member _.Subscription = subscription

    ///
    and DiscountsResourceDiscountAmount (amount: int64, discount: Choice<string, Discount, DeletedDiscount>) =

        member _.Amount = amount
        member _.Discount = discount

    ///A dispute occurs when a customer questions your charge with their card issuer.
    ///When this happens, you're given the opportunity to respond to the dispute with
    ///evidence that shows that the charge is legitimate. You can find more
    ///information about the dispute process in our [Disputes and
    ///Fraud](/docs/disputes) documentation.
    ///
    ///Related guide: [Disputes and Fraud](https://stripe.com/docs/disputes).
    and Dispute (amount: int64, balanceTransactions: BalanceTransaction list, charge: Choice<string, Charge>, created: int64, currency: string, evidence: DisputeEvidence, evidenceDetails: DisputeEvidenceDetails, id: string, isChargeRefundable: bool, livemode: bool, metadata: Map<string, string>, paymentIntent: Choice<string, PaymentIntent> option, reason: string, status: DisputeStatus, ?networkReasonCode: string option) =

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
        member _.Object = "dispute"
        member _.PaymentIntent = paymentIntent
        member _.Reason = reason
        member _.Status = status

    and DisputeStatus =
        | [<JsonUnionCase("charge_refunded")>] DisputeStatus'ChargeRefunded
        | [<JsonUnionCase("lost")>] DisputeStatus'Lost
        | [<JsonUnionCase("needs_response")>] DisputeStatus'NeedsResponse
        | [<JsonUnionCase("under_review")>] DisputeStatus'UnderReview
        | [<JsonUnionCase("warning_closed")>] DisputeStatus'WarningClosed
        | [<JsonUnionCase("warning_needs_response")>] DisputeStatus'WarningNeedsResponse
        | [<JsonUnionCase("warning_under_review")>] DisputeStatus'WarningUnderReview
        | [<JsonUnionCase("won")>] DisputeStatus'Won

    ///
    and DisputeEvidence (accessActivityLog: string option, billingAddress: string option, cancellationPolicy: Choice<string, File> option, cancellationPolicyDisclosure: string option, cancellationRebuttal: string option, customerCommunication: Choice<string, File> option, customerEmailAddress: string option, customerName: string option, customerPurchaseIp: string option, customerSignature: Choice<string, File> option, duplicateChargeDocumentation: Choice<string, File> option, duplicateChargeExplanation: string option, duplicateChargeId: string option, productDescription: string option, receipt: Choice<string, File> option, refundPolicy: Choice<string, File> option, refundPolicyDisclosure: string option, refundRefusalExplanation: string option, serviceDate: string option, serviceDocumentation: Choice<string, File> option, shippingAddress: string option, shippingCarrier: string option, shippingDate: string option, shippingDocumentation: Choice<string, File> option, shippingTrackingNumber: string option, uncategorizedFile: Choice<string, File> option, uncategorizedText: string option) =

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

    ///
    and DisputeEvidenceDetails (dueBy: int64 option, hasEvidence: bool, pastDue: bool, submissionCount: int64) =

        member _.DueBy = dueBy
        member _.HasEvidence = hasEvidence
        member _.PastDue = pastDue
        member _.SubmissionCount = submissionCount

    ///
    and EphemeralKey (created: int64, expires: int64, id: string, livemode: bool, ?secret: string) =

        member _.Created = created
        member _.Expires = expires
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = "ephemeral_key"
        member _.Secret = secret

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
    and Event (apiVersion: string option, created: int64, data: NotificationEventData, id: string, livemode: bool, pendingWebhooks: int64, request: NotificationEventRequest option, ``type``: string, ?account: string) =

        member _.Account = account
        member _.ApiVersion = apiVersion
        member _.Created = created
        member _.Data = data
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = "event"
        member _.PendingWebhooks = pendingWebhooks
        member _.Request = request
        member _.Type = ``type``

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
    and ExchangeRate (id: string, rates: Map<string, string>) =

        member _.Id = id
        member _.Object = "exchange_rate"
        member _.Rates = rates

    and ExternalAccount =
        | BankAccount of BankAccount
        | Card of Card

    ///
    and Fee (amount: int64, application: string option, currency: string, description: string option, ``type``: string) =

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
    and FeeRefund (amount: int64, balanceTransaction: Choice<string, BalanceTransaction> option, created: int64, currency: string, fee: Choice<string, ApplicationFee>, id: string, metadata: Map<string, string> option) =

        member _.Amount = amount
        member _.BalanceTransaction = balanceTransaction
        member _.Created = created
        member _.Currency = currency
        member _.Fee = fee
        member _.Id = id
        member _.Metadata = metadata
        member _.Object = "fee_refund"

    ///This is an object representing a file hosted on Stripe's servers. The
    ///file may have been uploaded by yourself using the [create file](https://stripe.com/docs/api#create_file)
    ///request (for example, when uploading dispute evidence) or it may have
    ///been created by Stripe (for example, the results of a [Sigma scheduled
    ///query](#scheduled_queries)).
    ///
    ///Related guide: [File Upload Guide](https://stripe.com/docs/file-upload).
    and File (created: int64, expiresAt: int64 option, filename: string option, id: string, purpose: FilePurpose, size: int64, title: string option, ``type``: string option, url: string option, ?links: Map<string, string> option) =

        member _.Created = created
        member _.ExpiresAt = expiresAt
        member _.Filename = filename
        member _.Id = id
        member _.Links = links |> Option.flatten
        member _.Object = "file"
        member _.Purpose = purpose
        member _.Size = size
        member _.Title = title
        member _.Type = ``type``
        member _.Url = url

    and FilePurpose =
        | [<JsonUnionCase("additional_verification")>] FilePurpose'AdditionalVerification
        | [<JsonUnionCase("business_icon")>] FilePurpose'BusinessIcon
        | [<JsonUnionCase("business_logo")>] FilePurpose'BusinessLogo
        | [<JsonUnionCase("customer_signature")>] FilePurpose'CustomerSignature
        | [<JsonUnionCase("dispute_evidence")>] FilePurpose'DisputeEvidence
        | [<JsonUnionCase("identity_document")>] FilePurpose'IdentityDocument
        | [<JsonUnionCase("pci_document")>] FilePurpose'PciDocument
        | [<JsonUnionCase("tax_document_user_upload")>] FilePurpose'TaxDocumentUserUpload

    ///To share the contents of a `File` object with non-Stripe users, you can
    ///create a `FileLink`. `FileLink`s contain a URL that can be used to
    ///retrieve the contents of the file without authentication.
    and FileLink (created: int64, expired: bool, expiresAt: int64 option, file: Choice<string, File>, id: string, livemode: bool, metadata: Map<string, string>, url: string option) =

        member _.Created = created
        member _.Expired = expired
        member _.ExpiresAt = expiresAt
        member _.File = file
        member _.Id = id
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Object = "file_link"
        member _.Url = url

    ///
    and FinancialReportingFinanceReportRunRunParameters (?columns: string list, ?connectedAccount: string, ?currency: string, ?intervalEnd: int64, ?intervalStart: int64, ?payout: string, ?reportingCategory: string, ?timezone: string) =

        member _.Columns = columns
        member _.ConnectedAccount = connectedAccount
        member _.Currency = currency
        member _.IntervalEnd = intervalEnd
        member _.IntervalStart = intervalStart
        member _.Payout = payout
        member _.ReportingCategory = reportingCategory
        member _.Timezone = timezone

    ///
    and Inventory (quantity: int64 option, ``type``: string, value: string option) =

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
    and Invoice (accountCountry: string option, accountName: string option, amountDue: int64, amountPaid: int64, amountRemaining: int64, applicationFeeAmount: int64 option, attemptCount: int64, attempted: bool, billingReason: InvoiceBillingReason option, charge: Choice<string, Charge> option, collectionMethod: InvoiceCollectionMethod option, created: int64, currency: string, customFields: InvoiceSettingCustomField list option, customer: Choice<string, Customer, DeletedCustomer>, customerAddress: Address option, customerEmail: string option, customerName: string option, customerPhone: string option, customerShipping: Shipping option, customerTaxExempt: InvoiceCustomerTaxExempt option, defaultPaymentMethod: Choice<string, PaymentMethod> option, defaultSource: Choice<string, PaymentSource> option, defaultTaxRates: TaxRate list, description: string option, discount: Discount option, discounts: Choice<string, Discount, DeletedDiscount> list option, dueDate: int64 option, endingBalance: int64 option, footer: string option, lines: Map<string, string>, livemode: bool, metadata: Map<string, string> option, nextPaymentAttempt: int64 option, number: string option, paid: bool, paymentIntent: Choice<string, PaymentIntent> option, periodEnd: int64, periodStart: int64, postPaymentCreditNotesAmount: int64, prePaymentCreditNotesAmount: int64, receiptNumber: string option, startingBalance: int64, statementDescriptor: string option, status: InvoiceStatus option, statusTransitions: InvoicesStatusTransitions, subscription: Choice<string, Subscription> option, subtotal: int64, tax: int64 option, total: int64, totalDiscountAmounts: DiscountsResourceDiscountAmount list option, totalTaxAmounts: InvoiceTaxAmount list, transferData: InvoiceTransferData option, webhooksDeliveredAt: int64 option, ?accountTaxIds: Choice<string, TaxId, DeletedTaxId> list option, ?autoAdvance: bool, ?customerTaxIds: InvoicesResourceInvoiceTaxId list option, ?hostedInvoiceUrl: string option, ?id: string, ?invoicePdf: string option, ?lastFinalizationError: ApiErrors option, ?subscriptionProrationDate: int64, ?thresholdReason: InvoiceThresholdReason) =

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
        member _.Object = "invoice"
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
        | [<JsonUnionCase("automatic_pending_invoice_item_invoice")>] InvoiceBillingReason'AutomaticPendingInvoiceItemInvoice
        | [<JsonUnionCase("manual")>] InvoiceBillingReason'Manual
        | [<JsonUnionCase("subscription")>] InvoiceBillingReason'Subscription
        | [<JsonUnionCase("subscription_create")>] InvoiceBillingReason'SubscriptionCreate
        | [<JsonUnionCase("subscription_cycle")>] InvoiceBillingReason'SubscriptionCycle
        | [<JsonUnionCase("subscription_threshold")>] InvoiceBillingReason'SubscriptionThreshold
        | [<JsonUnionCase("subscription_update")>] InvoiceBillingReason'SubscriptionUpdate
        | [<JsonUnionCase("upcoming")>] InvoiceBillingReason'Upcoming

    and InvoiceCollectionMethod =
        | [<JsonUnionCase("charge_automatically")>] InvoiceCollectionMethod'ChargeAutomatically
        | [<JsonUnionCase("send_invoice")>] InvoiceCollectionMethod'SendInvoice

    and InvoiceCustomerTaxExempt =
        | [<JsonUnionCase("exempt")>] InvoiceCustomerTaxExempt'Exempt
        | [<JsonUnionCase("none")>] InvoiceCustomerTaxExempt'None
        | [<JsonUnionCase("reverse")>] InvoiceCustomerTaxExempt'Reverse

    and InvoiceStatus =
        | [<JsonUnionCase("deleted")>] InvoiceStatus'Deleted
        | [<JsonUnionCase("draft")>] InvoiceStatus'Draft
        | [<JsonUnionCase("open")>] InvoiceStatus'Open
        | [<JsonUnionCase("paid")>] InvoiceStatus'Paid
        | [<JsonUnionCase("uncollectible")>] InvoiceStatus'Uncollectible
        | [<JsonUnionCase("void")>] InvoiceStatus'Void

    ///
    and InvoiceItemThresholdReason (lineItemIds: string list, usageGte: int64) =

        member _.LineItemIds = lineItemIds
        member _.UsageGte = usageGte

    ///
    and InvoiceLineItemPeriod (``end``: int64, start: int64) =

        member _.End = ``end``
        member _.Start = start

    ///
    and InvoiceSettingCustomField (name: string, value: string) =

        member _.Name = name
        member _.Value = value

    ///
    and InvoiceSettingCustomerSetting (customFields: InvoiceSettingCustomField list option, defaultPaymentMethod: Choice<string, PaymentMethod> option, footer: string option) =

        member _.CustomFields = customFields
        member _.DefaultPaymentMethod = defaultPaymentMethod
        member _.Footer = footer

    ///
    and InvoiceSettingSubscriptionScheduleSetting (daysUntilDue: int64 option) =

        member _.DaysUntilDue = daysUntilDue

    ///
    and InvoiceTaxAmount (amount: int64, inclusive: bool, taxRate: Choice<string, TaxRate>) =

        member _.Amount = amount
        member _.Inclusive = inclusive
        member _.TaxRate = taxRate

    ///
    and InvoiceThresholdReason (amountGte: int64 option, itemReasons: InvoiceItemThresholdReason list) =

        member _.AmountGte = amountGte
        member _.ItemReasons = itemReasons

    ///
    and InvoiceTransferData (amount: int64 option, destination: Choice<string, Account>) =

        member _.Amount = amount
        member _.Destination = destination

    ///Sometimes you want to add a charge or credit to a customer, but actually
    ///charge or credit the customer's card only at the end of a regular billing
    ///cycle. This is useful for combining several charges (to minimize
    ///per-transaction fees), or for having Stripe tabulate your usage-based billing
    ///totals.
    ///
    ///Related guide: [Subscription Invoices](https://stripe.com/docs/billing/invoices/subscription#adding-upcoming-invoice-items).
    and Invoiceitem (amount: int64, currency: string, customer: Choice<string, Customer, DeletedCustomer>, date: int64, description: string option, discountable: bool, discounts: Choice<string, Discount> list option, id: string, invoice: Choice<string, Invoice> option, livemode: bool, metadata: Map<string, string> option, period: InvoiceLineItemPeriod, plan: Plan option, price: Price option, proration: bool, quantity: int64, subscription: Choice<string, Subscription> option, taxRates: TaxRate list option, unitAmount: int64 option, unitAmountDecimal: string option, ?subscriptionItem: string) =

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
        member _.Object = "invoiceitem"
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

    ///
    and InvoicesResourceInvoiceTaxId (``type``: InvoicesResourceInvoiceTaxIdType, value: string option) =

        member _.Type = ``type``
        member _.Value = value

    and InvoicesResourceInvoiceTaxIdType =
        | [<JsonUnionCase("ae_trn")>] InvoicesResourceInvoiceTaxIdType'AeTrn
        | [<JsonUnionCase("au_abn")>] InvoicesResourceInvoiceTaxIdType'AuAbn
        | [<JsonUnionCase("br_cnpj")>] InvoicesResourceInvoiceTaxIdType'BrCnpj
        | [<JsonUnionCase("br_cpf")>] InvoicesResourceInvoiceTaxIdType'BrCpf
        | [<JsonUnionCase("ca_bn")>] InvoicesResourceInvoiceTaxIdType'CaBn
        | [<JsonUnionCase("ca_qst")>] InvoicesResourceInvoiceTaxIdType'CaQst
        | [<JsonUnionCase("ch_vat")>] InvoicesResourceInvoiceTaxIdType'ChVat
        | [<JsonUnionCase("cl_tin")>] InvoicesResourceInvoiceTaxIdType'ClTin
        | [<JsonUnionCase("es_cif")>] InvoicesResourceInvoiceTaxIdType'EsCif
        | [<JsonUnionCase("eu_vat")>] InvoicesResourceInvoiceTaxIdType'EuVat
        | [<JsonUnionCase("hk_br")>] InvoicesResourceInvoiceTaxIdType'HkBr
        | [<JsonUnionCase("id_npwp")>] InvoicesResourceInvoiceTaxIdType'IdNpwp
        | [<JsonUnionCase("in_gst")>] InvoicesResourceInvoiceTaxIdType'InGst
        | [<JsonUnionCase("jp_cn")>] InvoicesResourceInvoiceTaxIdType'JpCn
        | [<JsonUnionCase("jp_rn")>] InvoicesResourceInvoiceTaxIdType'JpRn
        | [<JsonUnionCase("kr_brn")>] InvoicesResourceInvoiceTaxIdType'KrBrn
        | [<JsonUnionCase("li_uid")>] InvoicesResourceInvoiceTaxIdType'LiUid
        | [<JsonUnionCase("mx_rfc")>] InvoicesResourceInvoiceTaxIdType'MxRfc
        | [<JsonUnionCase("my_frp")>] InvoicesResourceInvoiceTaxIdType'MyFrp
        | [<JsonUnionCase("my_itn")>] InvoicesResourceInvoiceTaxIdType'MyItn
        | [<JsonUnionCase("my_sst")>] InvoicesResourceInvoiceTaxIdType'MySst
        | [<JsonUnionCase("no_vat")>] InvoicesResourceInvoiceTaxIdType'NoVat
        | [<JsonUnionCase("nz_gst")>] InvoicesResourceInvoiceTaxIdType'NzGst
        | [<JsonUnionCase("ru_inn")>] InvoicesResourceInvoiceTaxIdType'RuInn
        | [<JsonUnionCase("ru_kpp")>] InvoicesResourceInvoiceTaxIdType'RuKpp
        | [<JsonUnionCase("sa_vat")>] InvoicesResourceInvoiceTaxIdType'SaVat
        | [<JsonUnionCase("sg_gst")>] InvoicesResourceInvoiceTaxIdType'SgGst
        | [<JsonUnionCase("sg_uen")>] InvoicesResourceInvoiceTaxIdType'SgUen
        | [<JsonUnionCase("th_vat")>] InvoicesResourceInvoiceTaxIdType'ThVat
        | [<JsonUnionCase("tw_vat")>] InvoicesResourceInvoiceTaxIdType'TwVat
        | [<JsonUnionCase("unknown")>] InvoicesResourceInvoiceTaxIdType'Unknown
        | [<JsonUnionCase("us_ein")>] InvoicesResourceInvoiceTaxIdType'UsEin
        | [<JsonUnionCase("za_vat")>] InvoicesResourceInvoiceTaxIdType'ZaVat

    ///
    and InvoicesStatusTransitions (finalizedAt: int64 option, markedUncollectibleAt: int64 option, paidAt: int64 option, voidedAt: int64 option) =

        member _.FinalizedAt = finalizedAt
        member _.MarkedUncollectibleAt = markedUncollectibleAt
        member _.PaidAt = paidAt
        member _.VoidedAt = voidedAt

    ///This resource has been renamed to [Early Fraud
    ///Warning](#early_fraud_warning_object) and will be removed in a future API
    ///version.
    and IssuerFraudRecord (actionable: bool, charge: Choice<string, Charge>, created: int64, fraudType: string, hasLiabilityShift: bool, id: string, livemode: bool, postDate: int64) =

        member _.Actionable = actionable
        member _.Charge = charge
        member _.Created = created
        member _.FraudType = fraudType
        member _.HasLiabilityShift = hasLiabilityShift
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = "issuer_fraud_record"
        member _.PostDate = postDate

    ///When an [issued card](https://stripe.com/docs/issuing) is used to make a purchase, an Issuing `Authorization`
    ///object is created. [Authorizations](https://stripe.com/docs/issuing/purchases/authorizations) must be approved for the
    ///purchase to be completed successfully.
    ///
    ///Related guide: [Issued Card Authorizations](https://stripe.com/docs/issuing/purchases/authorizations).
    and IssuingAuthorization (amount: int64, amountDetails: IssuingAuthorizationAmountDetails option, approved: bool, authorizationMethod: IssuingAuthorizationAuthorizationMethod, balanceTransactions: BalanceTransaction list, card: IssuingCard, cardholder: Choice<string, IssuingCardholder> option, created: int64, currency: string, id: string, livemode: bool, merchantAmount: int64, merchantCurrency: string, merchantData: IssuingAuthorizationMerchantData, metadata: Map<string, string>, pendingRequest: IssuingAuthorizationPendingRequest option, requestHistory: IssuingAuthorizationRequest list, status: IssuingAuthorizationStatus, transactions: IssuingTransaction list, verificationData: IssuingAuthorizationVerificationData, wallet: string option) =

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
        member _.Object = "issuing.authorization"
        member _.PendingRequest = pendingRequest
        member _.RequestHistory = requestHistory
        member _.Status = status
        member _.Transactions = transactions
        member _.VerificationData = verificationData
        member _.Wallet = wallet

    and IssuingAuthorizationAuthorizationMethod =
        | [<JsonUnionCase("chip")>] IssuingAuthorizationAuthorizationMethod'Chip
        | [<JsonUnionCase("contactless")>] IssuingAuthorizationAuthorizationMethod'Contactless
        | [<JsonUnionCase("keyed_in")>] IssuingAuthorizationAuthorizationMethod'KeyedIn
        | [<JsonUnionCase("online")>] IssuingAuthorizationAuthorizationMethod'Online
        | [<JsonUnionCase("swipe")>] IssuingAuthorizationAuthorizationMethod'Swipe

    and IssuingAuthorizationStatus =
        | [<JsonUnionCase("closed")>] IssuingAuthorizationStatus'Closed
        | [<JsonUnionCase("pending")>] IssuingAuthorizationStatus'Pending
        | [<JsonUnionCase("reversed")>] IssuingAuthorizationStatus'Reversed

    ///You can [create physical or virtual cards](https://stripe.com/docs/issuing/cards) that are issued to cardholders.
    and IssuingCard (brand: string, cancellationReason: IssuingCardCancellationReason option, cardholder: IssuingCardholder, created: int64, currency: string, expMonth: int64, expYear: int64, id: string, last4: string, livemode: bool, metadata: Map<string, string>, replacedBy: Choice<string, IssuingCard> option, replacementFor: Choice<string, IssuingCard> option, replacementReason: IssuingCardReplacementReason option, shipping: IssuingCardShipping option, spendingControls: IssuingCardAuthorizationControls, status: IssuingCardStatus, ``type``: IssuingCardType, ?cvc: string, ?number: string) =

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
        member _.Object = "issuing.card"
        member _.ReplacedBy = replacedBy
        member _.ReplacementFor = replacementFor
        member _.ReplacementReason = replacementReason
        member _.Shipping = shipping
        member _.SpendingControls = spendingControls
        member _.Status = status
        member _.Type = ``type``

    and IssuingCardCancellationReason =
        | [<JsonUnionCase("lost")>] IssuingCardCancellationReason'Lost
        | [<JsonUnionCase("stolen")>] IssuingCardCancellationReason'Stolen

    and IssuingCardReplacementReason =
        | [<JsonUnionCase("damaged")>] IssuingCardReplacementReason'Damaged
        | [<JsonUnionCase("expired")>] IssuingCardReplacementReason'Expired
        | [<JsonUnionCase("lost")>] IssuingCardReplacementReason'Lost
        | [<JsonUnionCase("stolen")>] IssuingCardReplacementReason'Stolen

    and IssuingCardStatus =
        | [<JsonUnionCase("active")>] IssuingCardStatus'Active
        | [<JsonUnionCase("canceled")>] IssuingCardStatus'Canceled
        | [<JsonUnionCase("inactive")>] IssuingCardStatus'Inactive

    and IssuingCardType =
        | [<JsonUnionCase("physical")>] IssuingCardType'Physical
        | [<JsonUnionCase("virtual")>] IssuingCardType'Virtual

    ///An Issuing `Cardholder` object represents an individual or business entity who is [issued](https://stripe.com/docs/issuing) cards.
    ///
    ///Related guide: [How to create a Cardholder](https://stripe.com/docs/issuing/cards#create-cardholder)
    and IssuingCardholder (billing: IssuingCardholderAddress, company: IssuingCardholderCompany option, created: int64, email: string option, id: string, individual: IssuingCardholderIndividual option, livemode: bool, metadata: Map<string, string>, name: string, phoneNumber: string option, requirements: IssuingCardholderRequirements, spendingControls: IssuingCardholderAuthorizationControls option, status: IssuingCardholderStatus, ``type``: IssuingCardholderType) =

        member _.Billing = billing
        member _.Company = company
        member _.Created = created
        member _.Email = email
        member _.Id = id
        member _.Individual = individual
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Name = name
        member _.Object = "issuing.cardholder"
        member _.PhoneNumber = phoneNumber
        member _.Requirements = requirements
        member _.SpendingControls = spendingControls
        member _.Status = status
        member _.Type = ``type``

    and IssuingCardholderStatus =
        | [<JsonUnionCase("active")>] IssuingCardholderStatus'Active
        | [<JsonUnionCase("blocked")>] IssuingCardholderStatus'Blocked
        | [<JsonUnionCase("inactive")>] IssuingCardholderStatus'Inactive

    and IssuingCardholderType =
        | [<JsonUnionCase("company")>] IssuingCardholderType'Company
        | [<JsonUnionCase("individual")>] IssuingCardholderType'Individual

    ///As a [card issuer](https://stripe.com/docs/issuing), you can dispute transactions that the cardholder does not recognize, suspects to be fraudulent, or has other issues with.
    ///
    ///Related guide: [Disputing Transactions](https://stripe.com/docs/issuing/purchases/disputes)
    and IssuingDispute (balanceTransactions: BalanceTransaction list option, id: string, livemode: bool, transaction: Choice<string, IssuingTransaction>, ?amount: int64, ?created: int64, ?currency: string, ?evidence: IssuingDisputeEvidence, ?metadata: Map<string, string>, ?status: IssuingDisputeStatus) =

        member _.Amount = amount
        member _.BalanceTransactions = balanceTransactions
        member _.Created = created
        member _.Currency = currency
        member _.Evidence = evidence
        member _.Id = id
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Object = "issuing.dispute"
        member _.Status = status
        member _.Transaction = transaction

    and IssuingDisputeStatus =
        | [<JsonUnionCase("expired")>] IssuingDisputeStatus'Expired
        | [<JsonUnionCase("lost")>] IssuingDisputeStatus'Lost
        | [<JsonUnionCase("submitted")>] IssuingDisputeStatus'Submitted
        | [<JsonUnionCase("unsubmitted")>] IssuingDisputeStatus'Unsubmitted
        | [<JsonUnionCase("won")>] IssuingDisputeStatus'Won

    ///Any use of an [issued card](https://stripe.com/docs/issuing) that results in funds entering or leaving
    ///your Stripe account, such as a completed purchase or refund, is represented by an Issuing
    ///`Transaction` object.
    ///
    ///Related guide: [Issued Card Transactions](https://stripe.com/docs/issuing/purchases/transactions).
    and IssuingTransaction (amount: int64, amountDetails: IssuingTransactionAmountDetails option, authorization: Choice<string, IssuingAuthorization> option, balanceTransaction: Choice<string, BalanceTransaction> option, card: Choice<string, IssuingCard>, cardholder: Choice<string, IssuingCardholder> option, created: int64, currency: string, id: string, livemode: bool, merchantAmount: int64, merchantCurrency: string, merchantData: IssuingAuthorizationMerchantData, metadata: Map<string, string>, purchaseDetails: IssuingTransactionPurchaseDetails option, ``type``: IssuingTransactionType, ?dispute: Choice<string, IssuingDispute> option) =

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
        member _.Object = "issuing.transaction"
        member _.PurchaseDetails = purchaseDetails
        member _.Type = ``type``

    and IssuingTransactionType =
        | [<JsonUnionCase("capture")>] IssuingTransactionType'Capture
        | [<JsonUnionCase("dispute")>] IssuingTransactionType'Dispute
        | [<JsonUnionCase("refund")>] IssuingTransactionType'Refund

    ///
    and IssuingAuthorizationAmountDetails (atmFee: int64 option) =

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
    and IssuingAuthorizationPendingRequest (amount: int64, amountDetails: IssuingAuthorizationAmountDetails option, currency: string, isAmountControllable: bool, merchantAmount: int64, merchantCurrency: string) =

        member _.Amount = amount
        member _.AmountDetails = amountDetails
        member _.Currency = currency
        member _.IsAmountControllable = isAmountControllable
        member _.MerchantAmount = merchantAmount
        member _.MerchantCurrency = merchantCurrency

    ///
    and IssuingAuthorizationRequest (amount: int64, amountDetails: IssuingAuthorizationAmountDetails option, approved: bool, created: int64, currency: string, merchantAmount: int64, merchantCurrency: string, reason: IssuingAuthorizationRequestReason) =

        member _.Amount = amount
        member _.AmountDetails = amountDetails
        member _.Approved = approved
        member _.Created = created
        member _.Currency = currency
        member _.MerchantAmount = merchantAmount
        member _.MerchantCurrency = merchantCurrency
        member _.Reason = reason

    and IssuingAuthorizationRequestReason =
        | [<JsonUnionCase("account_disabled")>] IssuingAuthorizationRequestReason'AccountDisabled
        | [<JsonUnionCase("card_active")>] IssuingAuthorizationRequestReason'CardActive
        | [<JsonUnionCase("card_inactive")>] IssuingAuthorizationRequestReason'CardInactive
        | [<JsonUnionCase("cardholder_inactive")>] IssuingAuthorizationRequestReason'CardholderInactive
        | [<JsonUnionCase("cardholder_verification_required")>] IssuingAuthorizationRequestReason'CardholderVerificationRequired
        | [<JsonUnionCase("insufficient_funds")>] IssuingAuthorizationRequestReason'InsufficientFunds
        | [<JsonUnionCase("not_allowed")>] IssuingAuthorizationRequestReason'NotAllowed
        | [<JsonUnionCase("spending_controls")>] IssuingAuthorizationRequestReason'SpendingControls
        | [<JsonUnionCase("suspected_fraud")>] IssuingAuthorizationRequestReason'SuspectedFraud
        | [<JsonUnionCase("verification_failed")>] IssuingAuthorizationRequestReason'VerificationFailed
        | [<JsonUnionCase("webhook_approved")>] IssuingAuthorizationRequestReason'WebhookApproved
        | [<JsonUnionCase("webhook_declined")>] IssuingAuthorizationRequestReason'WebhookDeclined
        | [<JsonUnionCase("webhook_timeout")>] IssuingAuthorizationRequestReason'WebhookTimeout

    ///
    and IssuingAuthorizationVerificationData (addressLine1Check: IssuingAuthorizationVerificationDataAddressLine1Check, addressPostalCodeCheck: IssuingAuthorizationVerificationDataAddressPostalCodeCheck, cvcCheck: IssuingAuthorizationVerificationDataCvcCheck, expiryCheck: IssuingAuthorizationVerificationDataExpiryCheck) =

        member _.AddressLine1Check = addressLine1Check
        member _.AddressPostalCodeCheck = addressPostalCodeCheck
        member _.CvcCheck = cvcCheck
        member _.ExpiryCheck = expiryCheck

    and IssuingAuthorizationVerificationDataAddressLine1Check =
        | [<JsonUnionCase("match")>] IssuingAuthorizationVerificationDataAddressLine1Check'Match
        | [<JsonUnionCase("mismatch")>] IssuingAuthorizationVerificationDataAddressLine1Check'Mismatch
        | [<JsonUnionCase("not_provided")>] IssuingAuthorizationVerificationDataAddressLine1Check'NotProvided

    and IssuingAuthorizationVerificationDataAddressPostalCodeCheck =
        | [<JsonUnionCase("match")>] IssuingAuthorizationVerificationDataAddressPostalCodeCheck'Match
        | [<JsonUnionCase("mismatch")>] IssuingAuthorizationVerificationDataAddressPostalCodeCheck'Mismatch
        | [<JsonUnionCase("not_provided")>] IssuingAuthorizationVerificationDataAddressPostalCodeCheck'NotProvided

    and IssuingAuthorizationVerificationDataCvcCheck =
        | [<JsonUnionCase("match")>] IssuingAuthorizationVerificationDataCvcCheck'Match
        | [<JsonUnionCase("mismatch")>] IssuingAuthorizationVerificationDataCvcCheck'Mismatch
        | [<JsonUnionCase("not_provided")>] IssuingAuthorizationVerificationDataCvcCheck'NotProvided

    and IssuingAuthorizationVerificationDataExpiryCheck =
        | [<JsonUnionCase("match")>] IssuingAuthorizationVerificationDataExpiryCheck'Match
        | [<JsonUnionCase("mismatch")>] IssuingAuthorizationVerificationDataExpiryCheck'Mismatch
        | [<JsonUnionCase("not_provided")>] IssuingAuthorizationVerificationDataExpiryCheck'NotProvided

    ///
    and IssuingCardAuthorizationControls (allowedCategories: IssuingCardAuthorizationControlsAllowedCategories list option, blockedCategories: IssuingCardAuthorizationControlsBlockedCategories list option, spendingLimits: IssuingCardSpendingLimit list option, spendingLimitsCurrency: string option) =

        member _.AllowedCategories = allowedCategories
        member _.BlockedCategories = blockedCategories
        member _.SpendingLimits = spendingLimits
        member _.SpendingLimitsCurrency = spendingLimitsCurrency

    and IssuingCardAuthorizationControlsAllowedCategories =
        | [<JsonUnionCase("ac_refrigeration_repair")>] IssuingCardAuthorizationControlsAllowedCategories'AcRefrigerationRepair
        | [<JsonUnionCase("accounting_bookkeeping_services")>] IssuingCardAuthorizationControlsAllowedCategories'AccountingBookkeepingServices
        | [<JsonUnionCase("advertising_services")>] IssuingCardAuthorizationControlsAllowedCategories'AdvertisingServices
        | [<JsonUnionCase("agricultural_cooperative")>] IssuingCardAuthorizationControlsAllowedCategories'AgriculturalCooperative
        | [<JsonUnionCase("airlines_air_carriers")>] IssuingCardAuthorizationControlsAllowedCategories'AirlinesAirCarriers
        | [<JsonUnionCase("airports_flying_fields")>] IssuingCardAuthorizationControlsAllowedCategories'AirportsFlyingFields
        | [<JsonUnionCase("ambulance_services")>] IssuingCardAuthorizationControlsAllowedCategories'AmbulanceServices
        | [<JsonUnionCase("amusement_parks_carnivals")>] IssuingCardAuthorizationControlsAllowedCategories'AmusementParksCarnivals
        | [<JsonUnionCase("antique_reproductions")>] IssuingCardAuthorizationControlsAllowedCategories'AntiqueReproductions
        | [<JsonUnionCase("antique_shops")>] IssuingCardAuthorizationControlsAllowedCategories'AntiqueShops
        | [<JsonUnionCase("aquariums")>] IssuingCardAuthorizationControlsAllowedCategories'Aquariums
        | [<JsonUnionCase("architectural_surveying_services")>] IssuingCardAuthorizationControlsAllowedCategories'ArchitecturalSurveyingServices
        | [<JsonUnionCase("art_dealers_and_galleries")>] IssuingCardAuthorizationControlsAllowedCategories'ArtDealersAndGalleries
        | [<JsonUnionCase("artists_supply_and_craft_shops")>] IssuingCardAuthorizationControlsAllowedCategories'ArtistsSupplyAndCraftShops
        | [<JsonUnionCase("auto_and_home_supply_stores")>] IssuingCardAuthorizationControlsAllowedCategories'AutoAndHomeSupplyStores
        | [<JsonUnionCase("auto_body_repair_shops")>] IssuingCardAuthorizationControlsAllowedCategories'AutoBodyRepairShops
        | [<JsonUnionCase("auto_paint_shops")>] IssuingCardAuthorizationControlsAllowedCategories'AutoPaintShops
        | [<JsonUnionCase("auto_service_shops")>] IssuingCardAuthorizationControlsAllowedCategories'AutoServiceShops
        | [<JsonUnionCase("automated_cash_disburse")>] IssuingCardAuthorizationControlsAllowedCategories'AutomatedCashDisburse
        | [<JsonUnionCase("automated_fuel_dispensers")>] IssuingCardAuthorizationControlsAllowedCategories'AutomatedFuelDispensers
        | [<JsonUnionCase("automobile_associations")>] IssuingCardAuthorizationControlsAllowedCategories'AutomobileAssociations
        | [<JsonUnionCase("automotive_parts_and_accessories_stores")>] IssuingCardAuthorizationControlsAllowedCategories'AutomotivePartsAndAccessoriesStores
        | [<JsonUnionCase("automotive_tire_stores")>] IssuingCardAuthorizationControlsAllowedCategories'AutomotiveTireStores
        | [<JsonUnionCase("bail_and_bond_payments")>] IssuingCardAuthorizationControlsAllowedCategories'BailAndBondPayments
        | [<JsonUnionCase("bakeries")>] IssuingCardAuthorizationControlsAllowedCategories'Bakeries
        | [<JsonUnionCase("bands_orchestras")>] IssuingCardAuthorizationControlsAllowedCategories'BandsOrchestras
        | [<JsonUnionCase("barber_and_beauty_shops")>] IssuingCardAuthorizationControlsAllowedCategories'BarberAndBeautyShops
        | [<JsonUnionCase("betting_casino_gambling")>] IssuingCardAuthorizationControlsAllowedCategories'BettingCasinoGambling
        | [<JsonUnionCase("bicycle_shops")>] IssuingCardAuthorizationControlsAllowedCategories'BicycleShops
        | [<JsonUnionCase("billiard_pool_establishments")>] IssuingCardAuthorizationControlsAllowedCategories'BilliardPoolEstablishments
        | [<JsonUnionCase("boat_dealers")>] IssuingCardAuthorizationControlsAllowedCategories'BoatDealers
        | [<JsonUnionCase("boat_rentals_and_leases")>] IssuingCardAuthorizationControlsAllowedCategories'BoatRentalsAndLeases
        | [<JsonUnionCase("book_stores")>] IssuingCardAuthorizationControlsAllowedCategories'BookStores
        | [<JsonUnionCase("books_periodicals_and_newspapers")>] IssuingCardAuthorizationControlsAllowedCategories'BooksPeriodicalsAndNewspapers
        | [<JsonUnionCase("bowling_alleys")>] IssuingCardAuthorizationControlsAllowedCategories'BowlingAlleys
        | [<JsonUnionCase("bus_lines")>] IssuingCardAuthorizationControlsAllowedCategories'BusLines
        | [<JsonUnionCase("business_secretarial_schools")>] IssuingCardAuthorizationControlsAllowedCategories'BusinessSecretarialSchools
        | [<JsonUnionCase("buying_shopping_services")>] IssuingCardAuthorizationControlsAllowedCategories'BuyingShoppingServices
        | [<JsonUnionCase("cable_satellite_and_other_pay_television_and_radio")>] IssuingCardAuthorizationControlsAllowedCategories'CableSatelliteAndOtherPayTelevisionAndRadio
        | [<JsonUnionCase("camera_and_photographic_supply_stores")>] IssuingCardAuthorizationControlsAllowedCategories'CameraAndPhotographicSupplyStores
        | [<JsonUnionCase("candy_nut_and_confectionery_stores")>] IssuingCardAuthorizationControlsAllowedCategories'CandyNutAndConfectioneryStores
        | [<JsonUnionCase("car_and_truck_dealers_new_used")>] IssuingCardAuthorizationControlsAllowedCategories'CarAndTruckDealersNewUsed
        | [<JsonUnionCase("car_and_truck_dealers_used_only")>] IssuingCardAuthorizationControlsAllowedCategories'CarAndTruckDealersUsedOnly
        | [<JsonUnionCase("car_rental_agencies")>] IssuingCardAuthorizationControlsAllowedCategories'CarRentalAgencies
        | [<JsonUnionCase("car_washes")>] IssuingCardAuthorizationControlsAllowedCategories'CarWashes
        | [<JsonUnionCase("carpentry_services")>] IssuingCardAuthorizationControlsAllowedCategories'CarpentryServices
        | [<JsonUnionCase("carpet_upholstery_cleaning")>] IssuingCardAuthorizationControlsAllowedCategories'CarpetUpholsteryCleaning
        | [<JsonUnionCase("caterers")>] IssuingCardAuthorizationControlsAllowedCategories'Caterers
        | [<JsonUnionCase("charitable_and_social_service_organizations_fundraising")>] IssuingCardAuthorizationControlsAllowedCategories'CharitableAndSocialServiceOrganizationsFundraising
        | [<JsonUnionCase("chemicals_and_allied_products")>] IssuingCardAuthorizationControlsAllowedCategories'ChemicalsAndAlliedProducts
        | [<JsonUnionCase("child_care_services")>] IssuingCardAuthorizationControlsAllowedCategories'ChildCareServices
        | [<JsonUnionCase("childrens_and_infants_wear_stores")>] IssuingCardAuthorizationControlsAllowedCategories'ChildrensAndInfantsWearStores
        | [<JsonUnionCase("chiropodists_podiatrists")>] IssuingCardAuthorizationControlsAllowedCategories'ChiropodistsPodiatrists
        | [<JsonUnionCase("chiropractors")>] IssuingCardAuthorizationControlsAllowedCategories'Chiropractors
        | [<JsonUnionCase("cigar_stores_and_stands")>] IssuingCardAuthorizationControlsAllowedCategories'CigarStoresAndStands
        | [<JsonUnionCase("civic_social_fraternal_associations")>] IssuingCardAuthorizationControlsAllowedCategories'CivicSocialFraternalAssociations
        | [<JsonUnionCase("cleaning_and_maintenance")>] IssuingCardAuthorizationControlsAllowedCategories'CleaningAndMaintenance
        | [<JsonUnionCase("clothing_rental")>] IssuingCardAuthorizationControlsAllowedCategories'ClothingRental
        | [<JsonUnionCase("colleges_universities")>] IssuingCardAuthorizationControlsAllowedCategories'CollegesUniversities
        | [<JsonUnionCase("commercial_equipment")>] IssuingCardAuthorizationControlsAllowedCategories'CommercialEquipment
        | [<JsonUnionCase("commercial_footwear")>] IssuingCardAuthorizationControlsAllowedCategories'CommercialFootwear
        | [<JsonUnionCase("commercial_photography_art_and_graphics")>] IssuingCardAuthorizationControlsAllowedCategories'CommercialPhotographyArtAndGraphics
        | [<JsonUnionCase("commuter_transport_and_ferries")>] IssuingCardAuthorizationControlsAllowedCategories'CommuterTransportAndFerries
        | [<JsonUnionCase("computer_network_services")>] IssuingCardAuthorizationControlsAllowedCategories'ComputerNetworkServices
        | [<JsonUnionCase("computer_programming")>] IssuingCardAuthorizationControlsAllowedCategories'ComputerProgramming
        | [<JsonUnionCase("computer_repair")>] IssuingCardAuthorizationControlsAllowedCategories'ComputerRepair
        | [<JsonUnionCase("computer_software_stores")>] IssuingCardAuthorizationControlsAllowedCategories'ComputerSoftwareStores
        | [<JsonUnionCase("computers_peripherals_and_software")>] IssuingCardAuthorizationControlsAllowedCategories'ComputersPeripheralsAndSoftware
        | [<JsonUnionCase("concrete_work_services")>] IssuingCardAuthorizationControlsAllowedCategories'ConcreteWorkServices
        | [<JsonUnionCase("construction_materials")>] IssuingCardAuthorizationControlsAllowedCategories'ConstructionMaterials
        | [<JsonUnionCase("consulting_public_relations")>] IssuingCardAuthorizationControlsAllowedCategories'ConsultingPublicRelations
        | [<JsonUnionCase("correspondence_schools")>] IssuingCardAuthorizationControlsAllowedCategories'CorrespondenceSchools
        | [<JsonUnionCase("cosmetic_stores")>] IssuingCardAuthorizationControlsAllowedCategories'CosmeticStores
        | [<JsonUnionCase("counseling_services")>] IssuingCardAuthorizationControlsAllowedCategories'CounselingServices
        | [<JsonUnionCase("country_clubs")>] IssuingCardAuthorizationControlsAllowedCategories'CountryClubs
        | [<JsonUnionCase("courier_services")>] IssuingCardAuthorizationControlsAllowedCategories'CourierServices
        | [<JsonUnionCase("court_costs")>] IssuingCardAuthorizationControlsAllowedCategories'CourtCosts
        | [<JsonUnionCase("credit_reporting_agencies")>] IssuingCardAuthorizationControlsAllowedCategories'CreditReportingAgencies
        | [<JsonUnionCase("cruise_lines")>] IssuingCardAuthorizationControlsAllowedCategories'CruiseLines
        | [<JsonUnionCase("dairy_products_stores")>] IssuingCardAuthorizationControlsAllowedCategories'DairyProductsStores
        | [<JsonUnionCase("dance_hall_studios_schools")>] IssuingCardAuthorizationControlsAllowedCategories'DanceHallStudiosSchools
        | [<JsonUnionCase("dating_escort_services")>] IssuingCardAuthorizationControlsAllowedCategories'DatingEscortServices
        | [<JsonUnionCase("dentists_orthodontists")>] IssuingCardAuthorizationControlsAllowedCategories'DentistsOrthodontists
        | [<JsonUnionCase("department_stores")>] IssuingCardAuthorizationControlsAllowedCategories'DepartmentStores
        | [<JsonUnionCase("detective_agencies")>] IssuingCardAuthorizationControlsAllowedCategories'DetectiveAgencies
        | [<JsonUnionCase("digital_goods_applications")>] IssuingCardAuthorizationControlsAllowedCategories'DigitalGoodsApplications
        | [<JsonUnionCase("digital_goods_games")>] IssuingCardAuthorizationControlsAllowedCategories'DigitalGoodsGames
        | [<JsonUnionCase("digital_goods_large_volume")>] IssuingCardAuthorizationControlsAllowedCategories'DigitalGoodsLargeVolume
        | [<JsonUnionCase("digital_goods_media")>] IssuingCardAuthorizationControlsAllowedCategories'DigitalGoodsMedia
        | [<JsonUnionCase("direct_marketing_catalog_merchant")>] IssuingCardAuthorizationControlsAllowedCategories'DirectMarketingCatalogMerchant
        | [<JsonUnionCase("direct_marketing_combination_catalog_and_retail_merchant")>] IssuingCardAuthorizationControlsAllowedCategories'DirectMarketingCombinationCatalogAndRetailMerchant
        | [<JsonUnionCase("direct_marketing_inbound_telemarketing")>] IssuingCardAuthorizationControlsAllowedCategories'DirectMarketingInboundTelemarketing
        | [<JsonUnionCase("direct_marketing_insurance_services")>] IssuingCardAuthorizationControlsAllowedCategories'DirectMarketingInsuranceServices
        | [<JsonUnionCase("direct_marketing_other")>] IssuingCardAuthorizationControlsAllowedCategories'DirectMarketingOther
        | [<JsonUnionCase("direct_marketing_outbound_telemarketing")>] IssuingCardAuthorizationControlsAllowedCategories'DirectMarketingOutboundTelemarketing
        | [<JsonUnionCase("direct_marketing_subscription")>] IssuingCardAuthorizationControlsAllowedCategories'DirectMarketingSubscription
        | [<JsonUnionCase("direct_marketing_travel")>] IssuingCardAuthorizationControlsAllowedCategories'DirectMarketingTravel
        | [<JsonUnionCase("discount_stores")>] IssuingCardAuthorizationControlsAllowedCategories'DiscountStores
        | [<JsonUnionCase("doctors")>] IssuingCardAuthorizationControlsAllowedCategories'Doctors
        | [<JsonUnionCase("door_to_door_sales")>] IssuingCardAuthorizationControlsAllowedCategories'DoorToDoorSales
        | [<JsonUnionCase("drapery_window_covering_and_upholstery_stores")>] IssuingCardAuthorizationControlsAllowedCategories'DraperyWindowCoveringAndUpholsteryStores
        | [<JsonUnionCase("drinking_places")>] IssuingCardAuthorizationControlsAllowedCategories'DrinkingPlaces
        | [<JsonUnionCase("drug_stores_and_pharmacies")>] IssuingCardAuthorizationControlsAllowedCategories'DrugStoresAndPharmacies
        | [<JsonUnionCase("drugs_drug_proprietaries_and_druggist_sundries")>] IssuingCardAuthorizationControlsAllowedCategories'DrugsDrugProprietariesAndDruggistSundries
        | [<JsonUnionCase("dry_cleaners")>] IssuingCardAuthorizationControlsAllowedCategories'DryCleaners
        | [<JsonUnionCase("durable_goods")>] IssuingCardAuthorizationControlsAllowedCategories'DurableGoods
        | [<JsonUnionCase("duty_free_stores")>] IssuingCardAuthorizationControlsAllowedCategories'DutyFreeStores
        | [<JsonUnionCase("eating_places_restaurants")>] IssuingCardAuthorizationControlsAllowedCategories'EatingPlacesRestaurants
        | [<JsonUnionCase("educational_services")>] IssuingCardAuthorizationControlsAllowedCategories'EducationalServices
        | [<JsonUnionCase("electric_razor_stores")>] IssuingCardAuthorizationControlsAllowedCategories'ElectricRazorStores
        | [<JsonUnionCase("electrical_parts_and_equipment")>] IssuingCardAuthorizationControlsAllowedCategories'ElectricalPartsAndEquipment
        | [<JsonUnionCase("electrical_services")>] IssuingCardAuthorizationControlsAllowedCategories'ElectricalServices
        | [<JsonUnionCase("electronics_repair_shops")>] IssuingCardAuthorizationControlsAllowedCategories'ElectronicsRepairShops
        | [<JsonUnionCase("electronics_stores")>] IssuingCardAuthorizationControlsAllowedCategories'ElectronicsStores
        | [<JsonUnionCase("elementary_secondary_schools")>] IssuingCardAuthorizationControlsAllowedCategories'ElementarySecondarySchools
        | [<JsonUnionCase("employment_temp_agencies")>] IssuingCardAuthorizationControlsAllowedCategories'EmploymentTempAgencies
        | [<JsonUnionCase("equipment_rental")>] IssuingCardAuthorizationControlsAllowedCategories'EquipmentRental
        | [<JsonUnionCase("exterminating_services")>] IssuingCardAuthorizationControlsAllowedCategories'ExterminatingServices
        | [<JsonUnionCase("family_clothing_stores")>] IssuingCardAuthorizationControlsAllowedCategories'FamilyClothingStores
        | [<JsonUnionCase("fast_food_restaurants")>] IssuingCardAuthorizationControlsAllowedCategories'FastFoodRestaurants
        | [<JsonUnionCase("financial_institutions")>] IssuingCardAuthorizationControlsAllowedCategories'FinancialInstitutions
        | [<JsonUnionCase("fines_government_administrative_entities")>] IssuingCardAuthorizationControlsAllowedCategories'FinesGovernmentAdministrativeEntities
        | [<JsonUnionCase("fireplace_fireplace_screens_and_accessories_stores")>] IssuingCardAuthorizationControlsAllowedCategories'FireplaceFireplaceScreensAndAccessoriesStores
        | [<JsonUnionCase("floor_covering_stores")>] IssuingCardAuthorizationControlsAllowedCategories'FloorCoveringStores
        | [<JsonUnionCase("florists")>] IssuingCardAuthorizationControlsAllowedCategories'Florists
        | [<JsonUnionCase("florists_supplies_nursery_stock_and_flowers")>] IssuingCardAuthorizationControlsAllowedCategories'FloristsSuppliesNurseryStockAndFlowers
        | [<JsonUnionCase("freezer_and_locker_meat_provisioners")>] IssuingCardAuthorizationControlsAllowedCategories'FreezerAndLockerMeatProvisioners
        | [<JsonUnionCase("fuel_dealers_non_automotive")>] IssuingCardAuthorizationControlsAllowedCategories'FuelDealersNonAutomotive
        | [<JsonUnionCase("funeral_services_crematories")>] IssuingCardAuthorizationControlsAllowedCategories'FuneralServicesCrematories
        | [<JsonUnionCase("furniture_home_furnishings_and_equipment_stores_except_appliances")>] IssuingCardAuthorizationControlsAllowedCategories'FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | [<JsonUnionCase("furniture_repair_refinishing")>] IssuingCardAuthorizationControlsAllowedCategories'FurnitureRepairRefinishing
        | [<JsonUnionCase("furriers_and_fur_shops")>] IssuingCardAuthorizationControlsAllowedCategories'FurriersAndFurShops
        | [<JsonUnionCase("general_services")>] IssuingCardAuthorizationControlsAllowedCategories'GeneralServices
        | [<JsonUnionCase("gift_card_novelty_and_souvenir_shops")>] IssuingCardAuthorizationControlsAllowedCategories'GiftCardNoveltyAndSouvenirShops
        | [<JsonUnionCase("glass_paint_and_wallpaper_stores")>] IssuingCardAuthorizationControlsAllowedCategories'GlassPaintAndWallpaperStores
        | [<JsonUnionCase("glassware_crystal_stores")>] IssuingCardAuthorizationControlsAllowedCategories'GlasswareCrystalStores
        | [<JsonUnionCase("golf_courses_public")>] IssuingCardAuthorizationControlsAllowedCategories'GolfCoursesPublic
        | [<JsonUnionCase("government_services")>] IssuingCardAuthorizationControlsAllowedCategories'GovernmentServices
        | [<JsonUnionCase("grocery_stores_supermarkets")>] IssuingCardAuthorizationControlsAllowedCategories'GroceryStoresSupermarkets
        | [<JsonUnionCase("hardware_equipment_and_supplies")>] IssuingCardAuthorizationControlsAllowedCategories'HardwareEquipmentAndSupplies
        | [<JsonUnionCase("hardware_stores")>] IssuingCardAuthorizationControlsAllowedCategories'HardwareStores
        | [<JsonUnionCase("health_and_beauty_spas")>] IssuingCardAuthorizationControlsAllowedCategories'HealthAndBeautySpas
        | [<JsonUnionCase("hearing_aids_sales_and_supplies")>] IssuingCardAuthorizationControlsAllowedCategories'HearingAidsSalesAndSupplies
        | [<JsonUnionCase("heating_plumbing_a_c")>] IssuingCardAuthorizationControlsAllowedCategories'HeatingPlumbingAC
        | [<JsonUnionCase("hobby_toy_and_game_shops")>] IssuingCardAuthorizationControlsAllowedCategories'HobbyToyAndGameShops
        | [<JsonUnionCase("home_supply_warehouse_stores")>] IssuingCardAuthorizationControlsAllowedCategories'HomeSupplyWarehouseStores
        | [<JsonUnionCase("hospitals")>] IssuingCardAuthorizationControlsAllowedCategories'Hospitals
        | [<JsonUnionCase("hotels_motels_and_resorts")>] IssuingCardAuthorizationControlsAllowedCategories'HotelsMotelsAndResorts
        | [<JsonUnionCase("household_appliance_stores")>] IssuingCardAuthorizationControlsAllowedCategories'HouseholdApplianceStores
        | [<JsonUnionCase("industrial_supplies")>] IssuingCardAuthorizationControlsAllowedCategories'IndustrialSupplies
        | [<JsonUnionCase("information_retrieval_services")>] IssuingCardAuthorizationControlsAllowedCategories'InformationRetrievalServices
        | [<JsonUnionCase("insurance_default")>] IssuingCardAuthorizationControlsAllowedCategories'InsuranceDefault
        | [<JsonUnionCase("insurance_underwriting_premiums")>] IssuingCardAuthorizationControlsAllowedCategories'InsuranceUnderwritingPremiums
        | [<JsonUnionCase("intra_company_purchases")>] IssuingCardAuthorizationControlsAllowedCategories'IntraCompanyPurchases
        | [<JsonUnionCase("jewelry_stores_watches_clocks_and_silverware_stores")>] IssuingCardAuthorizationControlsAllowedCategories'JewelryStoresWatchesClocksAndSilverwareStores
        | [<JsonUnionCase("landscaping_services")>] IssuingCardAuthorizationControlsAllowedCategories'LandscapingServices
        | [<JsonUnionCase("laundries")>] IssuingCardAuthorizationControlsAllowedCategories'Laundries
        | [<JsonUnionCase("laundry_cleaning_services")>] IssuingCardAuthorizationControlsAllowedCategories'LaundryCleaningServices
        | [<JsonUnionCase("legal_services_attorneys")>] IssuingCardAuthorizationControlsAllowedCategories'LegalServicesAttorneys
        | [<JsonUnionCase("luggage_and_leather_goods_stores")>] IssuingCardAuthorizationControlsAllowedCategories'LuggageAndLeatherGoodsStores
        | [<JsonUnionCase("lumber_building_materials_stores")>] IssuingCardAuthorizationControlsAllowedCategories'LumberBuildingMaterialsStores
        | [<JsonUnionCase("manual_cash_disburse")>] IssuingCardAuthorizationControlsAllowedCategories'ManualCashDisburse
        | [<JsonUnionCase("marinas_service_and_supplies")>] IssuingCardAuthorizationControlsAllowedCategories'MarinasServiceAndSupplies
        | [<JsonUnionCase("masonry_stonework_and_plaster")>] IssuingCardAuthorizationControlsAllowedCategories'MasonryStoneworkAndPlaster
        | [<JsonUnionCase("massage_parlors")>] IssuingCardAuthorizationControlsAllowedCategories'MassageParlors
        | [<JsonUnionCase("medical_and_dental_labs")>] IssuingCardAuthorizationControlsAllowedCategories'MedicalAndDentalLabs
        | [<JsonUnionCase("medical_dental_ophthalmic_and_hospital_equipment_and_supplies")>] IssuingCardAuthorizationControlsAllowedCategories'MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | [<JsonUnionCase("medical_services")>] IssuingCardAuthorizationControlsAllowedCategories'MedicalServices
        | [<JsonUnionCase("membership_organizations")>] IssuingCardAuthorizationControlsAllowedCategories'MembershipOrganizations
        | [<JsonUnionCase("mens_and_boys_clothing_and_accessories_stores")>] IssuingCardAuthorizationControlsAllowedCategories'MensAndBoysClothingAndAccessoriesStores
        | [<JsonUnionCase("mens_womens_clothing_stores")>] IssuingCardAuthorizationControlsAllowedCategories'MensWomensClothingStores
        | [<JsonUnionCase("metal_service_centers")>] IssuingCardAuthorizationControlsAllowedCategories'MetalServiceCenters
        | [<JsonUnionCase("miscellaneous")>] IssuingCardAuthorizationControlsAllowedCategories'Miscellaneous
        | [<JsonUnionCase("miscellaneous_apparel_and_accessory_shops")>] IssuingCardAuthorizationControlsAllowedCategories'MiscellaneousApparelAndAccessoryShops
        | [<JsonUnionCase("miscellaneous_auto_dealers")>] IssuingCardAuthorizationControlsAllowedCategories'MiscellaneousAutoDealers
        | [<JsonUnionCase("miscellaneous_business_services")>] IssuingCardAuthorizationControlsAllowedCategories'MiscellaneousBusinessServices
        | [<JsonUnionCase("miscellaneous_food_stores")>] IssuingCardAuthorizationControlsAllowedCategories'MiscellaneousFoodStores
        | [<JsonUnionCase("miscellaneous_general_merchandise")>] IssuingCardAuthorizationControlsAllowedCategories'MiscellaneousGeneralMerchandise
        | [<JsonUnionCase("miscellaneous_general_services")>] IssuingCardAuthorizationControlsAllowedCategories'MiscellaneousGeneralServices
        | [<JsonUnionCase("miscellaneous_home_furnishing_specialty_stores")>] IssuingCardAuthorizationControlsAllowedCategories'MiscellaneousHomeFurnishingSpecialtyStores
        | [<JsonUnionCase("miscellaneous_publishing_and_printing")>] IssuingCardAuthorizationControlsAllowedCategories'MiscellaneousPublishingAndPrinting
        | [<JsonUnionCase("miscellaneous_recreation_services")>] IssuingCardAuthorizationControlsAllowedCategories'MiscellaneousRecreationServices
        | [<JsonUnionCase("miscellaneous_repair_shops")>] IssuingCardAuthorizationControlsAllowedCategories'MiscellaneousRepairShops
        | [<JsonUnionCase("miscellaneous_specialty_retail")>] IssuingCardAuthorizationControlsAllowedCategories'MiscellaneousSpecialtyRetail
        | [<JsonUnionCase("mobile_home_dealers")>] IssuingCardAuthorizationControlsAllowedCategories'MobileHomeDealers
        | [<JsonUnionCase("motion_picture_theaters")>] IssuingCardAuthorizationControlsAllowedCategories'MotionPictureTheaters
        | [<JsonUnionCase("motor_freight_carriers_and_trucking")>] IssuingCardAuthorizationControlsAllowedCategories'MotorFreightCarriersAndTrucking
        | [<JsonUnionCase("motor_homes_dealers")>] IssuingCardAuthorizationControlsAllowedCategories'MotorHomesDealers
        | [<JsonUnionCase("motor_vehicle_supplies_and_new_parts")>] IssuingCardAuthorizationControlsAllowedCategories'MotorVehicleSuppliesAndNewParts
        | [<JsonUnionCase("motorcycle_shops_and_dealers")>] IssuingCardAuthorizationControlsAllowedCategories'MotorcycleShopsAndDealers
        | [<JsonUnionCase("motorcycle_shops_dealers")>] IssuingCardAuthorizationControlsAllowedCategories'MotorcycleShopsDealers
        | [<JsonUnionCase("music_stores_musical_instruments_pianos_and_sheet_music")>] IssuingCardAuthorizationControlsAllowedCategories'MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | [<JsonUnionCase("news_dealers_and_newsstands")>] IssuingCardAuthorizationControlsAllowedCategories'NewsDealersAndNewsstands
        | [<JsonUnionCase("non_fi_money_orders")>] IssuingCardAuthorizationControlsAllowedCategories'NonFiMoneyOrders
        | [<JsonUnionCase("non_fi_stored_value_card_purchase_load")>] IssuingCardAuthorizationControlsAllowedCategories'NonFiStoredValueCardPurchaseLoad
        | [<JsonUnionCase("nondurable_goods")>] IssuingCardAuthorizationControlsAllowedCategories'NondurableGoods
        | [<JsonUnionCase("nurseries_lawn_and_garden_supply_stores")>] IssuingCardAuthorizationControlsAllowedCategories'NurseriesLawnAndGardenSupplyStores
        | [<JsonUnionCase("nursing_personal_care")>] IssuingCardAuthorizationControlsAllowedCategories'NursingPersonalCare
        | [<JsonUnionCase("office_and_commercial_furniture")>] IssuingCardAuthorizationControlsAllowedCategories'OfficeAndCommercialFurniture
        | [<JsonUnionCase("opticians_eyeglasses")>] IssuingCardAuthorizationControlsAllowedCategories'OpticiansEyeglasses
        | [<JsonUnionCase("optometrists_ophthalmologist")>] IssuingCardAuthorizationControlsAllowedCategories'OptometristsOphthalmologist
        | [<JsonUnionCase("orthopedic_goods_prosthetic_devices")>] IssuingCardAuthorizationControlsAllowedCategories'OrthopedicGoodsProstheticDevices
        | [<JsonUnionCase("osteopaths")>] IssuingCardAuthorizationControlsAllowedCategories'Osteopaths
        | [<JsonUnionCase("package_stores_beer_wine_and_liquor")>] IssuingCardAuthorizationControlsAllowedCategories'PackageStoresBeerWineAndLiquor
        | [<JsonUnionCase("paints_varnishes_and_supplies")>] IssuingCardAuthorizationControlsAllowedCategories'PaintsVarnishesAndSupplies
        | [<JsonUnionCase("parking_lots_garages")>] IssuingCardAuthorizationControlsAllowedCategories'ParkingLotsGarages
        | [<JsonUnionCase("passenger_railways")>] IssuingCardAuthorizationControlsAllowedCategories'PassengerRailways
        | [<JsonUnionCase("pawn_shops")>] IssuingCardAuthorizationControlsAllowedCategories'PawnShops
        | [<JsonUnionCase("pet_shops_pet_food_and_supplies")>] IssuingCardAuthorizationControlsAllowedCategories'PetShopsPetFoodAndSupplies
        | [<JsonUnionCase("petroleum_and_petroleum_products")>] IssuingCardAuthorizationControlsAllowedCategories'PetroleumAndPetroleumProducts
        | [<JsonUnionCase("photo_developing")>] IssuingCardAuthorizationControlsAllowedCategories'PhotoDeveloping
        | [<JsonUnionCase("photographic_photocopy_microfilm_equipment_and_supplies")>] IssuingCardAuthorizationControlsAllowedCategories'PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | [<JsonUnionCase("photographic_studios")>] IssuingCardAuthorizationControlsAllowedCategories'PhotographicStudios
        | [<JsonUnionCase("picture_video_production")>] IssuingCardAuthorizationControlsAllowedCategories'PictureVideoProduction
        | [<JsonUnionCase("piece_goods_notions_and_other_dry_goods")>] IssuingCardAuthorizationControlsAllowedCategories'PieceGoodsNotionsAndOtherDryGoods
        | [<JsonUnionCase("plumbing_heating_equipment_and_supplies")>] IssuingCardAuthorizationControlsAllowedCategories'PlumbingHeatingEquipmentAndSupplies
        | [<JsonUnionCase("political_organizations")>] IssuingCardAuthorizationControlsAllowedCategories'PoliticalOrganizations
        | [<JsonUnionCase("postal_services_government_only")>] IssuingCardAuthorizationControlsAllowedCategories'PostalServicesGovernmentOnly
        | [<JsonUnionCase("precious_stones_and_metals_watches_and_jewelry")>] IssuingCardAuthorizationControlsAllowedCategories'PreciousStonesAndMetalsWatchesAndJewelry
        | [<JsonUnionCase("professional_services")>] IssuingCardAuthorizationControlsAllowedCategories'ProfessionalServices
        | [<JsonUnionCase("public_warehousing_and_storage")>] IssuingCardAuthorizationControlsAllowedCategories'PublicWarehousingAndStorage
        | [<JsonUnionCase("quick_copy_repro_and_blueprint")>] IssuingCardAuthorizationControlsAllowedCategories'QuickCopyReproAndBlueprint
        | [<JsonUnionCase("railroads")>] IssuingCardAuthorizationControlsAllowedCategories'Railroads
        | [<JsonUnionCase("real_estate_agents_and_managers_rentals")>] IssuingCardAuthorizationControlsAllowedCategories'RealEstateAgentsAndManagersRentals
        | [<JsonUnionCase("record_stores")>] IssuingCardAuthorizationControlsAllowedCategories'RecordStores
        | [<JsonUnionCase("recreational_vehicle_rentals")>] IssuingCardAuthorizationControlsAllowedCategories'RecreationalVehicleRentals
        | [<JsonUnionCase("religious_goods_stores")>] IssuingCardAuthorizationControlsAllowedCategories'ReligiousGoodsStores
        | [<JsonUnionCase("religious_organizations")>] IssuingCardAuthorizationControlsAllowedCategories'ReligiousOrganizations
        | [<JsonUnionCase("roofing_siding_sheet_metal")>] IssuingCardAuthorizationControlsAllowedCategories'RoofingSidingSheetMetal
        | [<JsonUnionCase("secretarial_support_services")>] IssuingCardAuthorizationControlsAllowedCategories'SecretarialSupportServices
        | [<JsonUnionCase("security_brokers_dealers")>] IssuingCardAuthorizationControlsAllowedCategories'SecurityBrokersDealers
        | [<JsonUnionCase("service_stations")>] IssuingCardAuthorizationControlsAllowedCategories'ServiceStations
        | [<JsonUnionCase("sewing_needlework_fabric_and_piece_goods_stores")>] IssuingCardAuthorizationControlsAllowedCategories'SewingNeedleworkFabricAndPieceGoodsStores
        | [<JsonUnionCase("shoe_repair_hat_cleaning")>] IssuingCardAuthorizationControlsAllowedCategories'ShoeRepairHatCleaning
        | [<JsonUnionCase("shoe_stores")>] IssuingCardAuthorizationControlsAllowedCategories'ShoeStores
        | [<JsonUnionCase("small_appliance_repair")>] IssuingCardAuthorizationControlsAllowedCategories'SmallApplianceRepair
        | [<JsonUnionCase("snowmobile_dealers")>] IssuingCardAuthorizationControlsAllowedCategories'SnowmobileDealers
        | [<JsonUnionCase("special_trade_services")>] IssuingCardAuthorizationControlsAllowedCategories'SpecialTradeServices
        | [<JsonUnionCase("specialty_cleaning")>] IssuingCardAuthorizationControlsAllowedCategories'SpecialtyCleaning
        | [<JsonUnionCase("sporting_goods_stores")>] IssuingCardAuthorizationControlsAllowedCategories'SportingGoodsStores
        | [<JsonUnionCase("sporting_recreation_camps")>] IssuingCardAuthorizationControlsAllowedCategories'SportingRecreationCamps
        | [<JsonUnionCase("sports_and_riding_apparel_stores")>] IssuingCardAuthorizationControlsAllowedCategories'SportsAndRidingApparelStores
        | [<JsonUnionCase("sports_clubs_fields")>] IssuingCardAuthorizationControlsAllowedCategories'SportsClubsFields
        | [<JsonUnionCase("stamp_and_coin_stores")>] IssuingCardAuthorizationControlsAllowedCategories'StampAndCoinStores
        | [<JsonUnionCase("stationary_office_supplies_printing_and_writing_paper")>] IssuingCardAuthorizationControlsAllowedCategories'StationaryOfficeSuppliesPrintingAndWritingPaper
        | [<JsonUnionCase("stationery_stores_office_and_school_supply_stores")>] IssuingCardAuthorizationControlsAllowedCategories'StationeryStoresOfficeAndSchoolSupplyStores
        | [<JsonUnionCase("swimming_pools_sales")>] IssuingCardAuthorizationControlsAllowedCategories'SwimmingPoolsSales
        | [<JsonUnionCase("t_ui_travel_germany")>] IssuingCardAuthorizationControlsAllowedCategories'TUiTravelGermany
        | [<JsonUnionCase("tailors_alterations")>] IssuingCardAuthorizationControlsAllowedCategories'TailorsAlterations
        | [<JsonUnionCase("tax_payments_government_agencies")>] IssuingCardAuthorizationControlsAllowedCategories'TaxPaymentsGovernmentAgencies
        | [<JsonUnionCase("tax_preparation_services")>] IssuingCardAuthorizationControlsAllowedCategories'TaxPreparationServices
        | [<JsonUnionCase("taxicabs_limousines")>] IssuingCardAuthorizationControlsAllowedCategories'TaxicabsLimousines
        | [<JsonUnionCase("telecommunication_equipment_and_telephone_sales")>] IssuingCardAuthorizationControlsAllowedCategories'TelecommunicationEquipmentAndTelephoneSales
        | [<JsonUnionCase("telecommunication_services")>] IssuingCardAuthorizationControlsAllowedCategories'TelecommunicationServices
        | [<JsonUnionCase("telegraph_services")>] IssuingCardAuthorizationControlsAllowedCategories'TelegraphServices
        | [<JsonUnionCase("tent_and_awning_shops")>] IssuingCardAuthorizationControlsAllowedCategories'TentAndAwningShops
        | [<JsonUnionCase("testing_laboratories")>] IssuingCardAuthorizationControlsAllowedCategories'TestingLaboratories
        | [<JsonUnionCase("theatrical_ticket_agencies")>] IssuingCardAuthorizationControlsAllowedCategories'TheatricalTicketAgencies
        | [<JsonUnionCase("timeshares")>] IssuingCardAuthorizationControlsAllowedCategories'Timeshares
        | [<JsonUnionCase("tire_retreading_and_repair")>] IssuingCardAuthorizationControlsAllowedCategories'TireRetreadingAndRepair
        | [<JsonUnionCase("tolls_bridge_fees")>] IssuingCardAuthorizationControlsAllowedCategories'TollsBridgeFees
        | [<JsonUnionCase("tourist_attractions_and_exhibits")>] IssuingCardAuthorizationControlsAllowedCategories'TouristAttractionsAndExhibits
        | [<JsonUnionCase("towing_services")>] IssuingCardAuthorizationControlsAllowedCategories'TowingServices
        | [<JsonUnionCase("trailer_parks_campgrounds")>] IssuingCardAuthorizationControlsAllowedCategories'TrailerParksCampgrounds
        | [<JsonUnionCase("transportation_services")>] IssuingCardAuthorizationControlsAllowedCategories'TransportationServices
        | [<JsonUnionCase("travel_agencies_tour_operators")>] IssuingCardAuthorizationControlsAllowedCategories'TravelAgenciesTourOperators
        | [<JsonUnionCase("truck_stop_iteration")>] IssuingCardAuthorizationControlsAllowedCategories'TruckStopIteration
        | [<JsonUnionCase("truck_utility_trailer_rentals")>] IssuingCardAuthorizationControlsAllowedCategories'TruckUtilityTrailerRentals
        | [<JsonUnionCase("typesetting_plate_making_and_related_services")>] IssuingCardAuthorizationControlsAllowedCategories'TypesettingPlateMakingAndRelatedServices
        | [<JsonUnionCase("typewriter_stores")>] IssuingCardAuthorizationControlsAllowedCategories'TypewriterStores
        | [<JsonUnionCase("u_s_federal_government_agencies_or_departments")>] IssuingCardAuthorizationControlsAllowedCategories'USFederalGovernmentAgenciesOrDepartments
        | [<JsonUnionCase("uniforms_commercial_clothing")>] IssuingCardAuthorizationControlsAllowedCategories'UniformsCommercialClothing
        | [<JsonUnionCase("used_merchandise_and_secondhand_stores")>] IssuingCardAuthorizationControlsAllowedCategories'UsedMerchandiseAndSecondhandStores
        | [<JsonUnionCase("utilities")>] IssuingCardAuthorizationControlsAllowedCategories'Utilities
        | [<JsonUnionCase("variety_stores")>] IssuingCardAuthorizationControlsAllowedCategories'VarietyStores
        | [<JsonUnionCase("veterinary_services")>] IssuingCardAuthorizationControlsAllowedCategories'VeterinaryServices
        | [<JsonUnionCase("video_amusement_game_supplies")>] IssuingCardAuthorizationControlsAllowedCategories'VideoAmusementGameSupplies
        | [<JsonUnionCase("video_game_arcades")>] IssuingCardAuthorizationControlsAllowedCategories'VideoGameArcades
        | [<JsonUnionCase("video_tape_rental_stores")>] IssuingCardAuthorizationControlsAllowedCategories'VideoTapeRentalStores
        | [<JsonUnionCase("vocational_trade_schools")>] IssuingCardAuthorizationControlsAllowedCategories'VocationalTradeSchools
        | [<JsonUnionCase("watch_jewelry_repair")>] IssuingCardAuthorizationControlsAllowedCategories'WatchJewelryRepair
        | [<JsonUnionCase("welding_repair")>] IssuingCardAuthorizationControlsAllowedCategories'WeldingRepair
        | [<JsonUnionCase("wholesale_clubs")>] IssuingCardAuthorizationControlsAllowedCategories'WholesaleClubs
        | [<JsonUnionCase("wig_and_toupee_stores")>] IssuingCardAuthorizationControlsAllowedCategories'WigAndToupeeStores
        | [<JsonUnionCase("wires_money_orders")>] IssuingCardAuthorizationControlsAllowedCategories'WiresMoneyOrders
        | [<JsonUnionCase("womens_accessory_and_specialty_shops")>] IssuingCardAuthorizationControlsAllowedCategories'WomensAccessoryAndSpecialtyShops
        | [<JsonUnionCase("womens_ready_to_wear_stores")>] IssuingCardAuthorizationControlsAllowedCategories'WomensReadyToWearStores
        | [<JsonUnionCase("wrecking_and_salvage_yards")>] IssuingCardAuthorizationControlsAllowedCategories'WreckingAndSalvageYards

    and IssuingCardAuthorizationControlsBlockedCategories =
        | [<JsonUnionCase("ac_refrigeration_repair")>] IssuingCardAuthorizationControlsBlockedCategories'AcRefrigerationRepair
        | [<JsonUnionCase("accounting_bookkeeping_services")>] IssuingCardAuthorizationControlsBlockedCategories'AccountingBookkeepingServices
        | [<JsonUnionCase("advertising_services")>] IssuingCardAuthorizationControlsBlockedCategories'AdvertisingServices
        | [<JsonUnionCase("agricultural_cooperative")>] IssuingCardAuthorizationControlsBlockedCategories'AgriculturalCooperative
        | [<JsonUnionCase("airlines_air_carriers")>] IssuingCardAuthorizationControlsBlockedCategories'AirlinesAirCarriers
        | [<JsonUnionCase("airports_flying_fields")>] IssuingCardAuthorizationControlsBlockedCategories'AirportsFlyingFields
        | [<JsonUnionCase("ambulance_services")>] IssuingCardAuthorizationControlsBlockedCategories'AmbulanceServices
        | [<JsonUnionCase("amusement_parks_carnivals")>] IssuingCardAuthorizationControlsBlockedCategories'AmusementParksCarnivals
        | [<JsonUnionCase("antique_reproductions")>] IssuingCardAuthorizationControlsBlockedCategories'AntiqueReproductions
        | [<JsonUnionCase("antique_shops")>] IssuingCardAuthorizationControlsBlockedCategories'AntiqueShops
        | [<JsonUnionCase("aquariums")>] IssuingCardAuthorizationControlsBlockedCategories'Aquariums
        | [<JsonUnionCase("architectural_surveying_services")>] IssuingCardAuthorizationControlsBlockedCategories'ArchitecturalSurveyingServices
        | [<JsonUnionCase("art_dealers_and_galleries")>] IssuingCardAuthorizationControlsBlockedCategories'ArtDealersAndGalleries
        | [<JsonUnionCase("artists_supply_and_craft_shops")>] IssuingCardAuthorizationControlsBlockedCategories'ArtistsSupplyAndCraftShops
        | [<JsonUnionCase("auto_and_home_supply_stores")>] IssuingCardAuthorizationControlsBlockedCategories'AutoAndHomeSupplyStores
        | [<JsonUnionCase("auto_body_repair_shops")>] IssuingCardAuthorizationControlsBlockedCategories'AutoBodyRepairShops
        | [<JsonUnionCase("auto_paint_shops")>] IssuingCardAuthorizationControlsBlockedCategories'AutoPaintShops
        | [<JsonUnionCase("auto_service_shops")>] IssuingCardAuthorizationControlsBlockedCategories'AutoServiceShops
        | [<JsonUnionCase("automated_cash_disburse")>] IssuingCardAuthorizationControlsBlockedCategories'AutomatedCashDisburse
        | [<JsonUnionCase("automated_fuel_dispensers")>] IssuingCardAuthorizationControlsBlockedCategories'AutomatedFuelDispensers
        | [<JsonUnionCase("automobile_associations")>] IssuingCardAuthorizationControlsBlockedCategories'AutomobileAssociations
        | [<JsonUnionCase("automotive_parts_and_accessories_stores")>] IssuingCardAuthorizationControlsBlockedCategories'AutomotivePartsAndAccessoriesStores
        | [<JsonUnionCase("automotive_tire_stores")>] IssuingCardAuthorizationControlsBlockedCategories'AutomotiveTireStores
        | [<JsonUnionCase("bail_and_bond_payments")>] IssuingCardAuthorizationControlsBlockedCategories'BailAndBondPayments
        | [<JsonUnionCase("bakeries")>] IssuingCardAuthorizationControlsBlockedCategories'Bakeries
        | [<JsonUnionCase("bands_orchestras")>] IssuingCardAuthorizationControlsBlockedCategories'BandsOrchestras
        | [<JsonUnionCase("barber_and_beauty_shops")>] IssuingCardAuthorizationControlsBlockedCategories'BarberAndBeautyShops
        | [<JsonUnionCase("betting_casino_gambling")>] IssuingCardAuthorizationControlsBlockedCategories'BettingCasinoGambling
        | [<JsonUnionCase("bicycle_shops")>] IssuingCardAuthorizationControlsBlockedCategories'BicycleShops
        | [<JsonUnionCase("billiard_pool_establishments")>] IssuingCardAuthorizationControlsBlockedCategories'BilliardPoolEstablishments
        | [<JsonUnionCase("boat_dealers")>] IssuingCardAuthorizationControlsBlockedCategories'BoatDealers
        | [<JsonUnionCase("boat_rentals_and_leases")>] IssuingCardAuthorizationControlsBlockedCategories'BoatRentalsAndLeases
        | [<JsonUnionCase("book_stores")>] IssuingCardAuthorizationControlsBlockedCategories'BookStores
        | [<JsonUnionCase("books_periodicals_and_newspapers")>] IssuingCardAuthorizationControlsBlockedCategories'BooksPeriodicalsAndNewspapers
        | [<JsonUnionCase("bowling_alleys")>] IssuingCardAuthorizationControlsBlockedCategories'BowlingAlleys
        | [<JsonUnionCase("bus_lines")>] IssuingCardAuthorizationControlsBlockedCategories'BusLines
        | [<JsonUnionCase("business_secretarial_schools")>] IssuingCardAuthorizationControlsBlockedCategories'BusinessSecretarialSchools
        | [<JsonUnionCase("buying_shopping_services")>] IssuingCardAuthorizationControlsBlockedCategories'BuyingShoppingServices
        | [<JsonUnionCase("cable_satellite_and_other_pay_television_and_radio")>] IssuingCardAuthorizationControlsBlockedCategories'CableSatelliteAndOtherPayTelevisionAndRadio
        | [<JsonUnionCase("camera_and_photographic_supply_stores")>] IssuingCardAuthorizationControlsBlockedCategories'CameraAndPhotographicSupplyStores
        | [<JsonUnionCase("candy_nut_and_confectionery_stores")>] IssuingCardAuthorizationControlsBlockedCategories'CandyNutAndConfectioneryStores
        | [<JsonUnionCase("car_and_truck_dealers_new_used")>] IssuingCardAuthorizationControlsBlockedCategories'CarAndTruckDealersNewUsed
        | [<JsonUnionCase("car_and_truck_dealers_used_only")>] IssuingCardAuthorizationControlsBlockedCategories'CarAndTruckDealersUsedOnly
        | [<JsonUnionCase("car_rental_agencies")>] IssuingCardAuthorizationControlsBlockedCategories'CarRentalAgencies
        | [<JsonUnionCase("car_washes")>] IssuingCardAuthorizationControlsBlockedCategories'CarWashes
        | [<JsonUnionCase("carpentry_services")>] IssuingCardAuthorizationControlsBlockedCategories'CarpentryServices
        | [<JsonUnionCase("carpet_upholstery_cleaning")>] IssuingCardAuthorizationControlsBlockedCategories'CarpetUpholsteryCleaning
        | [<JsonUnionCase("caterers")>] IssuingCardAuthorizationControlsBlockedCategories'Caterers
        | [<JsonUnionCase("charitable_and_social_service_organizations_fundraising")>] IssuingCardAuthorizationControlsBlockedCategories'CharitableAndSocialServiceOrganizationsFundraising
        | [<JsonUnionCase("chemicals_and_allied_products")>] IssuingCardAuthorizationControlsBlockedCategories'ChemicalsAndAlliedProducts
        | [<JsonUnionCase("child_care_services")>] IssuingCardAuthorizationControlsBlockedCategories'ChildCareServices
        | [<JsonUnionCase("childrens_and_infants_wear_stores")>] IssuingCardAuthorizationControlsBlockedCategories'ChildrensAndInfantsWearStores
        | [<JsonUnionCase("chiropodists_podiatrists")>] IssuingCardAuthorizationControlsBlockedCategories'ChiropodistsPodiatrists
        | [<JsonUnionCase("chiropractors")>] IssuingCardAuthorizationControlsBlockedCategories'Chiropractors
        | [<JsonUnionCase("cigar_stores_and_stands")>] IssuingCardAuthorizationControlsBlockedCategories'CigarStoresAndStands
        | [<JsonUnionCase("civic_social_fraternal_associations")>] IssuingCardAuthorizationControlsBlockedCategories'CivicSocialFraternalAssociations
        | [<JsonUnionCase("cleaning_and_maintenance")>] IssuingCardAuthorizationControlsBlockedCategories'CleaningAndMaintenance
        | [<JsonUnionCase("clothing_rental")>] IssuingCardAuthorizationControlsBlockedCategories'ClothingRental
        | [<JsonUnionCase("colleges_universities")>] IssuingCardAuthorizationControlsBlockedCategories'CollegesUniversities
        | [<JsonUnionCase("commercial_equipment")>] IssuingCardAuthorizationControlsBlockedCategories'CommercialEquipment
        | [<JsonUnionCase("commercial_footwear")>] IssuingCardAuthorizationControlsBlockedCategories'CommercialFootwear
        | [<JsonUnionCase("commercial_photography_art_and_graphics")>] IssuingCardAuthorizationControlsBlockedCategories'CommercialPhotographyArtAndGraphics
        | [<JsonUnionCase("commuter_transport_and_ferries")>] IssuingCardAuthorizationControlsBlockedCategories'CommuterTransportAndFerries
        | [<JsonUnionCase("computer_network_services")>] IssuingCardAuthorizationControlsBlockedCategories'ComputerNetworkServices
        | [<JsonUnionCase("computer_programming")>] IssuingCardAuthorizationControlsBlockedCategories'ComputerProgramming
        | [<JsonUnionCase("computer_repair")>] IssuingCardAuthorizationControlsBlockedCategories'ComputerRepair
        | [<JsonUnionCase("computer_software_stores")>] IssuingCardAuthorizationControlsBlockedCategories'ComputerSoftwareStores
        | [<JsonUnionCase("computers_peripherals_and_software")>] IssuingCardAuthorizationControlsBlockedCategories'ComputersPeripheralsAndSoftware
        | [<JsonUnionCase("concrete_work_services")>] IssuingCardAuthorizationControlsBlockedCategories'ConcreteWorkServices
        | [<JsonUnionCase("construction_materials")>] IssuingCardAuthorizationControlsBlockedCategories'ConstructionMaterials
        | [<JsonUnionCase("consulting_public_relations")>] IssuingCardAuthorizationControlsBlockedCategories'ConsultingPublicRelations
        | [<JsonUnionCase("correspondence_schools")>] IssuingCardAuthorizationControlsBlockedCategories'CorrespondenceSchools
        | [<JsonUnionCase("cosmetic_stores")>] IssuingCardAuthorizationControlsBlockedCategories'CosmeticStores
        | [<JsonUnionCase("counseling_services")>] IssuingCardAuthorizationControlsBlockedCategories'CounselingServices
        | [<JsonUnionCase("country_clubs")>] IssuingCardAuthorizationControlsBlockedCategories'CountryClubs
        | [<JsonUnionCase("courier_services")>] IssuingCardAuthorizationControlsBlockedCategories'CourierServices
        | [<JsonUnionCase("court_costs")>] IssuingCardAuthorizationControlsBlockedCategories'CourtCosts
        | [<JsonUnionCase("credit_reporting_agencies")>] IssuingCardAuthorizationControlsBlockedCategories'CreditReportingAgencies
        | [<JsonUnionCase("cruise_lines")>] IssuingCardAuthorizationControlsBlockedCategories'CruiseLines
        | [<JsonUnionCase("dairy_products_stores")>] IssuingCardAuthorizationControlsBlockedCategories'DairyProductsStores
        | [<JsonUnionCase("dance_hall_studios_schools")>] IssuingCardAuthorizationControlsBlockedCategories'DanceHallStudiosSchools
        | [<JsonUnionCase("dating_escort_services")>] IssuingCardAuthorizationControlsBlockedCategories'DatingEscortServices
        | [<JsonUnionCase("dentists_orthodontists")>] IssuingCardAuthorizationControlsBlockedCategories'DentistsOrthodontists
        | [<JsonUnionCase("department_stores")>] IssuingCardAuthorizationControlsBlockedCategories'DepartmentStores
        | [<JsonUnionCase("detective_agencies")>] IssuingCardAuthorizationControlsBlockedCategories'DetectiveAgencies
        | [<JsonUnionCase("digital_goods_applications")>] IssuingCardAuthorizationControlsBlockedCategories'DigitalGoodsApplications
        | [<JsonUnionCase("digital_goods_games")>] IssuingCardAuthorizationControlsBlockedCategories'DigitalGoodsGames
        | [<JsonUnionCase("digital_goods_large_volume")>] IssuingCardAuthorizationControlsBlockedCategories'DigitalGoodsLargeVolume
        | [<JsonUnionCase("digital_goods_media")>] IssuingCardAuthorizationControlsBlockedCategories'DigitalGoodsMedia
        | [<JsonUnionCase("direct_marketing_catalog_merchant")>] IssuingCardAuthorizationControlsBlockedCategories'DirectMarketingCatalogMerchant
        | [<JsonUnionCase("direct_marketing_combination_catalog_and_retail_merchant")>] IssuingCardAuthorizationControlsBlockedCategories'DirectMarketingCombinationCatalogAndRetailMerchant
        | [<JsonUnionCase("direct_marketing_inbound_telemarketing")>] IssuingCardAuthorizationControlsBlockedCategories'DirectMarketingInboundTelemarketing
        | [<JsonUnionCase("direct_marketing_insurance_services")>] IssuingCardAuthorizationControlsBlockedCategories'DirectMarketingInsuranceServices
        | [<JsonUnionCase("direct_marketing_other")>] IssuingCardAuthorizationControlsBlockedCategories'DirectMarketingOther
        | [<JsonUnionCase("direct_marketing_outbound_telemarketing")>] IssuingCardAuthorizationControlsBlockedCategories'DirectMarketingOutboundTelemarketing
        | [<JsonUnionCase("direct_marketing_subscription")>] IssuingCardAuthorizationControlsBlockedCategories'DirectMarketingSubscription
        | [<JsonUnionCase("direct_marketing_travel")>] IssuingCardAuthorizationControlsBlockedCategories'DirectMarketingTravel
        | [<JsonUnionCase("discount_stores")>] IssuingCardAuthorizationControlsBlockedCategories'DiscountStores
        | [<JsonUnionCase("doctors")>] IssuingCardAuthorizationControlsBlockedCategories'Doctors
        | [<JsonUnionCase("door_to_door_sales")>] IssuingCardAuthorizationControlsBlockedCategories'DoorToDoorSales
        | [<JsonUnionCase("drapery_window_covering_and_upholstery_stores")>] IssuingCardAuthorizationControlsBlockedCategories'DraperyWindowCoveringAndUpholsteryStores
        | [<JsonUnionCase("drinking_places")>] IssuingCardAuthorizationControlsBlockedCategories'DrinkingPlaces
        | [<JsonUnionCase("drug_stores_and_pharmacies")>] IssuingCardAuthorizationControlsBlockedCategories'DrugStoresAndPharmacies
        | [<JsonUnionCase("drugs_drug_proprietaries_and_druggist_sundries")>] IssuingCardAuthorizationControlsBlockedCategories'DrugsDrugProprietariesAndDruggistSundries
        | [<JsonUnionCase("dry_cleaners")>] IssuingCardAuthorizationControlsBlockedCategories'DryCleaners
        | [<JsonUnionCase("durable_goods")>] IssuingCardAuthorizationControlsBlockedCategories'DurableGoods
        | [<JsonUnionCase("duty_free_stores")>] IssuingCardAuthorizationControlsBlockedCategories'DutyFreeStores
        | [<JsonUnionCase("eating_places_restaurants")>] IssuingCardAuthorizationControlsBlockedCategories'EatingPlacesRestaurants
        | [<JsonUnionCase("educational_services")>] IssuingCardAuthorizationControlsBlockedCategories'EducationalServices
        | [<JsonUnionCase("electric_razor_stores")>] IssuingCardAuthorizationControlsBlockedCategories'ElectricRazorStores
        | [<JsonUnionCase("electrical_parts_and_equipment")>] IssuingCardAuthorizationControlsBlockedCategories'ElectricalPartsAndEquipment
        | [<JsonUnionCase("electrical_services")>] IssuingCardAuthorizationControlsBlockedCategories'ElectricalServices
        | [<JsonUnionCase("electronics_repair_shops")>] IssuingCardAuthorizationControlsBlockedCategories'ElectronicsRepairShops
        | [<JsonUnionCase("electronics_stores")>] IssuingCardAuthorizationControlsBlockedCategories'ElectronicsStores
        | [<JsonUnionCase("elementary_secondary_schools")>] IssuingCardAuthorizationControlsBlockedCategories'ElementarySecondarySchools
        | [<JsonUnionCase("employment_temp_agencies")>] IssuingCardAuthorizationControlsBlockedCategories'EmploymentTempAgencies
        | [<JsonUnionCase("equipment_rental")>] IssuingCardAuthorizationControlsBlockedCategories'EquipmentRental
        | [<JsonUnionCase("exterminating_services")>] IssuingCardAuthorizationControlsBlockedCategories'ExterminatingServices
        | [<JsonUnionCase("family_clothing_stores")>] IssuingCardAuthorizationControlsBlockedCategories'FamilyClothingStores
        | [<JsonUnionCase("fast_food_restaurants")>] IssuingCardAuthorizationControlsBlockedCategories'FastFoodRestaurants
        | [<JsonUnionCase("financial_institutions")>] IssuingCardAuthorizationControlsBlockedCategories'FinancialInstitutions
        | [<JsonUnionCase("fines_government_administrative_entities")>] IssuingCardAuthorizationControlsBlockedCategories'FinesGovernmentAdministrativeEntities
        | [<JsonUnionCase("fireplace_fireplace_screens_and_accessories_stores")>] IssuingCardAuthorizationControlsBlockedCategories'FireplaceFireplaceScreensAndAccessoriesStores
        | [<JsonUnionCase("floor_covering_stores")>] IssuingCardAuthorizationControlsBlockedCategories'FloorCoveringStores
        | [<JsonUnionCase("florists")>] IssuingCardAuthorizationControlsBlockedCategories'Florists
        | [<JsonUnionCase("florists_supplies_nursery_stock_and_flowers")>] IssuingCardAuthorizationControlsBlockedCategories'FloristsSuppliesNurseryStockAndFlowers
        | [<JsonUnionCase("freezer_and_locker_meat_provisioners")>] IssuingCardAuthorizationControlsBlockedCategories'FreezerAndLockerMeatProvisioners
        | [<JsonUnionCase("fuel_dealers_non_automotive")>] IssuingCardAuthorizationControlsBlockedCategories'FuelDealersNonAutomotive
        | [<JsonUnionCase("funeral_services_crematories")>] IssuingCardAuthorizationControlsBlockedCategories'FuneralServicesCrematories
        | [<JsonUnionCase("furniture_home_furnishings_and_equipment_stores_except_appliances")>] IssuingCardAuthorizationControlsBlockedCategories'FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | [<JsonUnionCase("furniture_repair_refinishing")>] IssuingCardAuthorizationControlsBlockedCategories'FurnitureRepairRefinishing
        | [<JsonUnionCase("furriers_and_fur_shops")>] IssuingCardAuthorizationControlsBlockedCategories'FurriersAndFurShops
        | [<JsonUnionCase("general_services")>] IssuingCardAuthorizationControlsBlockedCategories'GeneralServices
        | [<JsonUnionCase("gift_card_novelty_and_souvenir_shops")>] IssuingCardAuthorizationControlsBlockedCategories'GiftCardNoveltyAndSouvenirShops
        | [<JsonUnionCase("glass_paint_and_wallpaper_stores")>] IssuingCardAuthorizationControlsBlockedCategories'GlassPaintAndWallpaperStores
        | [<JsonUnionCase("glassware_crystal_stores")>] IssuingCardAuthorizationControlsBlockedCategories'GlasswareCrystalStores
        | [<JsonUnionCase("golf_courses_public")>] IssuingCardAuthorizationControlsBlockedCategories'GolfCoursesPublic
        | [<JsonUnionCase("government_services")>] IssuingCardAuthorizationControlsBlockedCategories'GovernmentServices
        | [<JsonUnionCase("grocery_stores_supermarkets")>] IssuingCardAuthorizationControlsBlockedCategories'GroceryStoresSupermarkets
        | [<JsonUnionCase("hardware_equipment_and_supplies")>] IssuingCardAuthorizationControlsBlockedCategories'HardwareEquipmentAndSupplies
        | [<JsonUnionCase("hardware_stores")>] IssuingCardAuthorizationControlsBlockedCategories'HardwareStores
        | [<JsonUnionCase("health_and_beauty_spas")>] IssuingCardAuthorizationControlsBlockedCategories'HealthAndBeautySpas
        | [<JsonUnionCase("hearing_aids_sales_and_supplies")>] IssuingCardAuthorizationControlsBlockedCategories'HearingAidsSalesAndSupplies
        | [<JsonUnionCase("heating_plumbing_a_c")>] IssuingCardAuthorizationControlsBlockedCategories'HeatingPlumbingAC
        | [<JsonUnionCase("hobby_toy_and_game_shops")>] IssuingCardAuthorizationControlsBlockedCategories'HobbyToyAndGameShops
        | [<JsonUnionCase("home_supply_warehouse_stores")>] IssuingCardAuthorizationControlsBlockedCategories'HomeSupplyWarehouseStores
        | [<JsonUnionCase("hospitals")>] IssuingCardAuthorizationControlsBlockedCategories'Hospitals
        | [<JsonUnionCase("hotels_motels_and_resorts")>] IssuingCardAuthorizationControlsBlockedCategories'HotelsMotelsAndResorts
        | [<JsonUnionCase("household_appliance_stores")>] IssuingCardAuthorizationControlsBlockedCategories'HouseholdApplianceStores
        | [<JsonUnionCase("industrial_supplies")>] IssuingCardAuthorizationControlsBlockedCategories'IndustrialSupplies
        | [<JsonUnionCase("information_retrieval_services")>] IssuingCardAuthorizationControlsBlockedCategories'InformationRetrievalServices
        | [<JsonUnionCase("insurance_default")>] IssuingCardAuthorizationControlsBlockedCategories'InsuranceDefault
        | [<JsonUnionCase("insurance_underwriting_premiums")>] IssuingCardAuthorizationControlsBlockedCategories'InsuranceUnderwritingPremiums
        | [<JsonUnionCase("intra_company_purchases")>] IssuingCardAuthorizationControlsBlockedCategories'IntraCompanyPurchases
        | [<JsonUnionCase("jewelry_stores_watches_clocks_and_silverware_stores")>] IssuingCardAuthorizationControlsBlockedCategories'JewelryStoresWatchesClocksAndSilverwareStores
        | [<JsonUnionCase("landscaping_services")>] IssuingCardAuthorizationControlsBlockedCategories'LandscapingServices
        | [<JsonUnionCase("laundries")>] IssuingCardAuthorizationControlsBlockedCategories'Laundries
        | [<JsonUnionCase("laundry_cleaning_services")>] IssuingCardAuthorizationControlsBlockedCategories'LaundryCleaningServices
        | [<JsonUnionCase("legal_services_attorneys")>] IssuingCardAuthorizationControlsBlockedCategories'LegalServicesAttorneys
        | [<JsonUnionCase("luggage_and_leather_goods_stores")>] IssuingCardAuthorizationControlsBlockedCategories'LuggageAndLeatherGoodsStores
        | [<JsonUnionCase("lumber_building_materials_stores")>] IssuingCardAuthorizationControlsBlockedCategories'LumberBuildingMaterialsStores
        | [<JsonUnionCase("manual_cash_disburse")>] IssuingCardAuthorizationControlsBlockedCategories'ManualCashDisburse
        | [<JsonUnionCase("marinas_service_and_supplies")>] IssuingCardAuthorizationControlsBlockedCategories'MarinasServiceAndSupplies
        | [<JsonUnionCase("masonry_stonework_and_plaster")>] IssuingCardAuthorizationControlsBlockedCategories'MasonryStoneworkAndPlaster
        | [<JsonUnionCase("massage_parlors")>] IssuingCardAuthorizationControlsBlockedCategories'MassageParlors
        | [<JsonUnionCase("medical_and_dental_labs")>] IssuingCardAuthorizationControlsBlockedCategories'MedicalAndDentalLabs
        | [<JsonUnionCase("medical_dental_ophthalmic_and_hospital_equipment_and_supplies")>] IssuingCardAuthorizationControlsBlockedCategories'MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | [<JsonUnionCase("medical_services")>] IssuingCardAuthorizationControlsBlockedCategories'MedicalServices
        | [<JsonUnionCase("membership_organizations")>] IssuingCardAuthorizationControlsBlockedCategories'MembershipOrganizations
        | [<JsonUnionCase("mens_and_boys_clothing_and_accessories_stores")>] IssuingCardAuthorizationControlsBlockedCategories'MensAndBoysClothingAndAccessoriesStores
        | [<JsonUnionCase("mens_womens_clothing_stores")>] IssuingCardAuthorizationControlsBlockedCategories'MensWomensClothingStores
        | [<JsonUnionCase("metal_service_centers")>] IssuingCardAuthorizationControlsBlockedCategories'MetalServiceCenters
        | [<JsonUnionCase("miscellaneous")>] IssuingCardAuthorizationControlsBlockedCategories'Miscellaneous
        | [<JsonUnionCase("miscellaneous_apparel_and_accessory_shops")>] IssuingCardAuthorizationControlsBlockedCategories'MiscellaneousApparelAndAccessoryShops
        | [<JsonUnionCase("miscellaneous_auto_dealers")>] IssuingCardAuthorizationControlsBlockedCategories'MiscellaneousAutoDealers
        | [<JsonUnionCase("miscellaneous_business_services")>] IssuingCardAuthorizationControlsBlockedCategories'MiscellaneousBusinessServices
        | [<JsonUnionCase("miscellaneous_food_stores")>] IssuingCardAuthorizationControlsBlockedCategories'MiscellaneousFoodStores
        | [<JsonUnionCase("miscellaneous_general_merchandise")>] IssuingCardAuthorizationControlsBlockedCategories'MiscellaneousGeneralMerchandise
        | [<JsonUnionCase("miscellaneous_general_services")>] IssuingCardAuthorizationControlsBlockedCategories'MiscellaneousGeneralServices
        | [<JsonUnionCase("miscellaneous_home_furnishing_specialty_stores")>] IssuingCardAuthorizationControlsBlockedCategories'MiscellaneousHomeFurnishingSpecialtyStores
        | [<JsonUnionCase("miscellaneous_publishing_and_printing")>] IssuingCardAuthorizationControlsBlockedCategories'MiscellaneousPublishingAndPrinting
        | [<JsonUnionCase("miscellaneous_recreation_services")>] IssuingCardAuthorizationControlsBlockedCategories'MiscellaneousRecreationServices
        | [<JsonUnionCase("miscellaneous_repair_shops")>] IssuingCardAuthorizationControlsBlockedCategories'MiscellaneousRepairShops
        | [<JsonUnionCase("miscellaneous_specialty_retail")>] IssuingCardAuthorizationControlsBlockedCategories'MiscellaneousSpecialtyRetail
        | [<JsonUnionCase("mobile_home_dealers")>] IssuingCardAuthorizationControlsBlockedCategories'MobileHomeDealers
        | [<JsonUnionCase("motion_picture_theaters")>] IssuingCardAuthorizationControlsBlockedCategories'MotionPictureTheaters
        | [<JsonUnionCase("motor_freight_carriers_and_trucking")>] IssuingCardAuthorizationControlsBlockedCategories'MotorFreightCarriersAndTrucking
        | [<JsonUnionCase("motor_homes_dealers")>] IssuingCardAuthorizationControlsBlockedCategories'MotorHomesDealers
        | [<JsonUnionCase("motor_vehicle_supplies_and_new_parts")>] IssuingCardAuthorizationControlsBlockedCategories'MotorVehicleSuppliesAndNewParts
        | [<JsonUnionCase("motorcycle_shops_and_dealers")>] IssuingCardAuthorizationControlsBlockedCategories'MotorcycleShopsAndDealers
        | [<JsonUnionCase("motorcycle_shops_dealers")>] IssuingCardAuthorizationControlsBlockedCategories'MotorcycleShopsDealers
        | [<JsonUnionCase("music_stores_musical_instruments_pianos_and_sheet_music")>] IssuingCardAuthorizationControlsBlockedCategories'MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | [<JsonUnionCase("news_dealers_and_newsstands")>] IssuingCardAuthorizationControlsBlockedCategories'NewsDealersAndNewsstands
        | [<JsonUnionCase("non_fi_money_orders")>] IssuingCardAuthorizationControlsBlockedCategories'NonFiMoneyOrders
        | [<JsonUnionCase("non_fi_stored_value_card_purchase_load")>] IssuingCardAuthorizationControlsBlockedCategories'NonFiStoredValueCardPurchaseLoad
        | [<JsonUnionCase("nondurable_goods")>] IssuingCardAuthorizationControlsBlockedCategories'NondurableGoods
        | [<JsonUnionCase("nurseries_lawn_and_garden_supply_stores")>] IssuingCardAuthorizationControlsBlockedCategories'NurseriesLawnAndGardenSupplyStores
        | [<JsonUnionCase("nursing_personal_care")>] IssuingCardAuthorizationControlsBlockedCategories'NursingPersonalCare
        | [<JsonUnionCase("office_and_commercial_furniture")>] IssuingCardAuthorizationControlsBlockedCategories'OfficeAndCommercialFurniture
        | [<JsonUnionCase("opticians_eyeglasses")>] IssuingCardAuthorizationControlsBlockedCategories'OpticiansEyeglasses
        | [<JsonUnionCase("optometrists_ophthalmologist")>] IssuingCardAuthorizationControlsBlockedCategories'OptometristsOphthalmologist
        | [<JsonUnionCase("orthopedic_goods_prosthetic_devices")>] IssuingCardAuthorizationControlsBlockedCategories'OrthopedicGoodsProstheticDevices
        | [<JsonUnionCase("osteopaths")>] IssuingCardAuthorizationControlsBlockedCategories'Osteopaths
        | [<JsonUnionCase("package_stores_beer_wine_and_liquor")>] IssuingCardAuthorizationControlsBlockedCategories'PackageStoresBeerWineAndLiquor
        | [<JsonUnionCase("paints_varnishes_and_supplies")>] IssuingCardAuthorizationControlsBlockedCategories'PaintsVarnishesAndSupplies
        | [<JsonUnionCase("parking_lots_garages")>] IssuingCardAuthorizationControlsBlockedCategories'ParkingLotsGarages
        | [<JsonUnionCase("passenger_railways")>] IssuingCardAuthorizationControlsBlockedCategories'PassengerRailways
        | [<JsonUnionCase("pawn_shops")>] IssuingCardAuthorizationControlsBlockedCategories'PawnShops
        | [<JsonUnionCase("pet_shops_pet_food_and_supplies")>] IssuingCardAuthorizationControlsBlockedCategories'PetShopsPetFoodAndSupplies
        | [<JsonUnionCase("petroleum_and_petroleum_products")>] IssuingCardAuthorizationControlsBlockedCategories'PetroleumAndPetroleumProducts
        | [<JsonUnionCase("photo_developing")>] IssuingCardAuthorizationControlsBlockedCategories'PhotoDeveloping
        | [<JsonUnionCase("photographic_photocopy_microfilm_equipment_and_supplies")>] IssuingCardAuthorizationControlsBlockedCategories'PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | [<JsonUnionCase("photographic_studios")>] IssuingCardAuthorizationControlsBlockedCategories'PhotographicStudios
        | [<JsonUnionCase("picture_video_production")>] IssuingCardAuthorizationControlsBlockedCategories'PictureVideoProduction
        | [<JsonUnionCase("piece_goods_notions_and_other_dry_goods")>] IssuingCardAuthorizationControlsBlockedCategories'PieceGoodsNotionsAndOtherDryGoods
        | [<JsonUnionCase("plumbing_heating_equipment_and_supplies")>] IssuingCardAuthorizationControlsBlockedCategories'PlumbingHeatingEquipmentAndSupplies
        | [<JsonUnionCase("political_organizations")>] IssuingCardAuthorizationControlsBlockedCategories'PoliticalOrganizations
        | [<JsonUnionCase("postal_services_government_only")>] IssuingCardAuthorizationControlsBlockedCategories'PostalServicesGovernmentOnly
        | [<JsonUnionCase("precious_stones_and_metals_watches_and_jewelry")>] IssuingCardAuthorizationControlsBlockedCategories'PreciousStonesAndMetalsWatchesAndJewelry
        | [<JsonUnionCase("professional_services")>] IssuingCardAuthorizationControlsBlockedCategories'ProfessionalServices
        | [<JsonUnionCase("public_warehousing_and_storage")>] IssuingCardAuthorizationControlsBlockedCategories'PublicWarehousingAndStorage
        | [<JsonUnionCase("quick_copy_repro_and_blueprint")>] IssuingCardAuthorizationControlsBlockedCategories'QuickCopyReproAndBlueprint
        | [<JsonUnionCase("railroads")>] IssuingCardAuthorizationControlsBlockedCategories'Railroads
        | [<JsonUnionCase("real_estate_agents_and_managers_rentals")>] IssuingCardAuthorizationControlsBlockedCategories'RealEstateAgentsAndManagersRentals
        | [<JsonUnionCase("record_stores")>] IssuingCardAuthorizationControlsBlockedCategories'RecordStores
        | [<JsonUnionCase("recreational_vehicle_rentals")>] IssuingCardAuthorizationControlsBlockedCategories'RecreationalVehicleRentals
        | [<JsonUnionCase("religious_goods_stores")>] IssuingCardAuthorizationControlsBlockedCategories'ReligiousGoodsStores
        | [<JsonUnionCase("religious_organizations")>] IssuingCardAuthorizationControlsBlockedCategories'ReligiousOrganizations
        | [<JsonUnionCase("roofing_siding_sheet_metal")>] IssuingCardAuthorizationControlsBlockedCategories'RoofingSidingSheetMetal
        | [<JsonUnionCase("secretarial_support_services")>] IssuingCardAuthorizationControlsBlockedCategories'SecretarialSupportServices
        | [<JsonUnionCase("security_brokers_dealers")>] IssuingCardAuthorizationControlsBlockedCategories'SecurityBrokersDealers
        | [<JsonUnionCase("service_stations")>] IssuingCardAuthorizationControlsBlockedCategories'ServiceStations
        | [<JsonUnionCase("sewing_needlework_fabric_and_piece_goods_stores")>] IssuingCardAuthorizationControlsBlockedCategories'SewingNeedleworkFabricAndPieceGoodsStores
        | [<JsonUnionCase("shoe_repair_hat_cleaning")>] IssuingCardAuthorizationControlsBlockedCategories'ShoeRepairHatCleaning
        | [<JsonUnionCase("shoe_stores")>] IssuingCardAuthorizationControlsBlockedCategories'ShoeStores
        | [<JsonUnionCase("small_appliance_repair")>] IssuingCardAuthorizationControlsBlockedCategories'SmallApplianceRepair
        | [<JsonUnionCase("snowmobile_dealers")>] IssuingCardAuthorizationControlsBlockedCategories'SnowmobileDealers
        | [<JsonUnionCase("special_trade_services")>] IssuingCardAuthorizationControlsBlockedCategories'SpecialTradeServices
        | [<JsonUnionCase("specialty_cleaning")>] IssuingCardAuthorizationControlsBlockedCategories'SpecialtyCleaning
        | [<JsonUnionCase("sporting_goods_stores")>] IssuingCardAuthorizationControlsBlockedCategories'SportingGoodsStores
        | [<JsonUnionCase("sporting_recreation_camps")>] IssuingCardAuthorizationControlsBlockedCategories'SportingRecreationCamps
        | [<JsonUnionCase("sports_and_riding_apparel_stores")>] IssuingCardAuthorizationControlsBlockedCategories'SportsAndRidingApparelStores
        | [<JsonUnionCase("sports_clubs_fields")>] IssuingCardAuthorizationControlsBlockedCategories'SportsClubsFields
        | [<JsonUnionCase("stamp_and_coin_stores")>] IssuingCardAuthorizationControlsBlockedCategories'StampAndCoinStores
        | [<JsonUnionCase("stationary_office_supplies_printing_and_writing_paper")>] IssuingCardAuthorizationControlsBlockedCategories'StationaryOfficeSuppliesPrintingAndWritingPaper
        | [<JsonUnionCase("stationery_stores_office_and_school_supply_stores")>] IssuingCardAuthorizationControlsBlockedCategories'StationeryStoresOfficeAndSchoolSupplyStores
        | [<JsonUnionCase("swimming_pools_sales")>] IssuingCardAuthorizationControlsBlockedCategories'SwimmingPoolsSales
        | [<JsonUnionCase("t_ui_travel_germany")>] IssuingCardAuthorizationControlsBlockedCategories'TUiTravelGermany
        | [<JsonUnionCase("tailors_alterations")>] IssuingCardAuthorizationControlsBlockedCategories'TailorsAlterations
        | [<JsonUnionCase("tax_payments_government_agencies")>] IssuingCardAuthorizationControlsBlockedCategories'TaxPaymentsGovernmentAgencies
        | [<JsonUnionCase("tax_preparation_services")>] IssuingCardAuthorizationControlsBlockedCategories'TaxPreparationServices
        | [<JsonUnionCase("taxicabs_limousines")>] IssuingCardAuthorizationControlsBlockedCategories'TaxicabsLimousines
        | [<JsonUnionCase("telecommunication_equipment_and_telephone_sales")>] IssuingCardAuthorizationControlsBlockedCategories'TelecommunicationEquipmentAndTelephoneSales
        | [<JsonUnionCase("telecommunication_services")>] IssuingCardAuthorizationControlsBlockedCategories'TelecommunicationServices
        | [<JsonUnionCase("telegraph_services")>] IssuingCardAuthorizationControlsBlockedCategories'TelegraphServices
        | [<JsonUnionCase("tent_and_awning_shops")>] IssuingCardAuthorizationControlsBlockedCategories'TentAndAwningShops
        | [<JsonUnionCase("testing_laboratories")>] IssuingCardAuthorizationControlsBlockedCategories'TestingLaboratories
        | [<JsonUnionCase("theatrical_ticket_agencies")>] IssuingCardAuthorizationControlsBlockedCategories'TheatricalTicketAgencies
        | [<JsonUnionCase("timeshares")>] IssuingCardAuthorizationControlsBlockedCategories'Timeshares
        | [<JsonUnionCase("tire_retreading_and_repair")>] IssuingCardAuthorizationControlsBlockedCategories'TireRetreadingAndRepair
        | [<JsonUnionCase("tolls_bridge_fees")>] IssuingCardAuthorizationControlsBlockedCategories'TollsBridgeFees
        | [<JsonUnionCase("tourist_attractions_and_exhibits")>] IssuingCardAuthorizationControlsBlockedCategories'TouristAttractionsAndExhibits
        | [<JsonUnionCase("towing_services")>] IssuingCardAuthorizationControlsBlockedCategories'TowingServices
        | [<JsonUnionCase("trailer_parks_campgrounds")>] IssuingCardAuthorizationControlsBlockedCategories'TrailerParksCampgrounds
        | [<JsonUnionCase("transportation_services")>] IssuingCardAuthorizationControlsBlockedCategories'TransportationServices
        | [<JsonUnionCase("travel_agencies_tour_operators")>] IssuingCardAuthorizationControlsBlockedCategories'TravelAgenciesTourOperators
        | [<JsonUnionCase("truck_stop_iteration")>] IssuingCardAuthorizationControlsBlockedCategories'TruckStopIteration
        | [<JsonUnionCase("truck_utility_trailer_rentals")>] IssuingCardAuthorizationControlsBlockedCategories'TruckUtilityTrailerRentals
        | [<JsonUnionCase("typesetting_plate_making_and_related_services")>] IssuingCardAuthorizationControlsBlockedCategories'TypesettingPlateMakingAndRelatedServices
        | [<JsonUnionCase("typewriter_stores")>] IssuingCardAuthorizationControlsBlockedCategories'TypewriterStores
        | [<JsonUnionCase("u_s_federal_government_agencies_or_departments")>] IssuingCardAuthorizationControlsBlockedCategories'USFederalGovernmentAgenciesOrDepartments
        | [<JsonUnionCase("uniforms_commercial_clothing")>] IssuingCardAuthorizationControlsBlockedCategories'UniformsCommercialClothing
        | [<JsonUnionCase("used_merchandise_and_secondhand_stores")>] IssuingCardAuthorizationControlsBlockedCategories'UsedMerchandiseAndSecondhandStores
        | [<JsonUnionCase("utilities")>] IssuingCardAuthorizationControlsBlockedCategories'Utilities
        | [<JsonUnionCase("variety_stores")>] IssuingCardAuthorizationControlsBlockedCategories'VarietyStores
        | [<JsonUnionCase("veterinary_services")>] IssuingCardAuthorizationControlsBlockedCategories'VeterinaryServices
        | [<JsonUnionCase("video_amusement_game_supplies")>] IssuingCardAuthorizationControlsBlockedCategories'VideoAmusementGameSupplies
        | [<JsonUnionCase("video_game_arcades")>] IssuingCardAuthorizationControlsBlockedCategories'VideoGameArcades
        | [<JsonUnionCase("video_tape_rental_stores")>] IssuingCardAuthorizationControlsBlockedCategories'VideoTapeRentalStores
        | [<JsonUnionCase("vocational_trade_schools")>] IssuingCardAuthorizationControlsBlockedCategories'VocationalTradeSchools
        | [<JsonUnionCase("watch_jewelry_repair")>] IssuingCardAuthorizationControlsBlockedCategories'WatchJewelryRepair
        | [<JsonUnionCase("welding_repair")>] IssuingCardAuthorizationControlsBlockedCategories'WeldingRepair
        | [<JsonUnionCase("wholesale_clubs")>] IssuingCardAuthorizationControlsBlockedCategories'WholesaleClubs
        | [<JsonUnionCase("wig_and_toupee_stores")>] IssuingCardAuthorizationControlsBlockedCategories'WigAndToupeeStores
        | [<JsonUnionCase("wires_money_orders")>] IssuingCardAuthorizationControlsBlockedCategories'WiresMoneyOrders
        | [<JsonUnionCase("womens_accessory_and_specialty_shops")>] IssuingCardAuthorizationControlsBlockedCategories'WomensAccessoryAndSpecialtyShops
        | [<JsonUnionCase("womens_ready_to_wear_stores")>] IssuingCardAuthorizationControlsBlockedCategories'WomensReadyToWearStores
        | [<JsonUnionCase("wrecking_and_salvage_yards")>] IssuingCardAuthorizationControlsBlockedCategories'WreckingAndSalvageYards

    ///
    and IssuingCardShipping (address: Address, carrier: IssuingCardShippingCarrier option, eta: int64 option, name: string, service: IssuingCardShippingService, status: IssuingCardShippingStatus option, trackingNumber: string option, trackingUrl: string option, ``type``: IssuingCardShippingType) =

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
        | [<JsonUnionCase("fedex")>] IssuingCardShippingCarrier'Fedex
        | [<JsonUnionCase("usps")>] IssuingCardShippingCarrier'Usps

    and IssuingCardShippingService =
        | [<JsonUnionCase("express")>] IssuingCardShippingService'Express
        | [<JsonUnionCase("priority")>] IssuingCardShippingService'Priority
        | [<JsonUnionCase("standard")>] IssuingCardShippingService'Standard

    and IssuingCardShippingStatus =
        | [<JsonUnionCase("canceled")>] IssuingCardShippingStatus'Canceled
        | [<JsonUnionCase("delivered")>] IssuingCardShippingStatus'Delivered
        | [<JsonUnionCase("failure")>] IssuingCardShippingStatus'Failure
        | [<JsonUnionCase("pending")>] IssuingCardShippingStatus'Pending
        | [<JsonUnionCase("returned")>] IssuingCardShippingStatus'Returned
        | [<JsonUnionCase("shipped")>] IssuingCardShippingStatus'Shipped

    and IssuingCardShippingType =
        | [<JsonUnionCase("bulk")>] IssuingCardShippingType'Bulk
        | [<JsonUnionCase("individual")>] IssuingCardShippingType'Individual

    ///
    and IssuingCardSpendingLimit (amount: int64, categories: IssuingCardSpendingLimitCategories list option, interval: IssuingCardSpendingLimitInterval) =

        member _.Amount = amount
        member _.Categories = categories
        member _.Interval = interval

    and IssuingCardSpendingLimitCategories =
        | [<JsonUnionCase("ac_refrigeration_repair")>] IssuingCardSpendingLimitCategories'AcRefrigerationRepair
        | [<JsonUnionCase("accounting_bookkeeping_services")>] IssuingCardSpendingLimitCategories'AccountingBookkeepingServices
        | [<JsonUnionCase("advertising_services")>] IssuingCardSpendingLimitCategories'AdvertisingServices
        | [<JsonUnionCase("agricultural_cooperative")>] IssuingCardSpendingLimitCategories'AgriculturalCooperative
        | [<JsonUnionCase("airlines_air_carriers")>] IssuingCardSpendingLimitCategories'AirlinesAirCarriers
        | [<JsonUnionCase("airports_flying_fields")>] IssuingCardSpendingLimitCategories'AirportsFlyingFields
        | [<JsonUnionCase("ambulance_services")>] IssuingCardSpendingLimitCategories'AmbulanceServices
        | [<JsonUnionCase("amusement_parks_carnivals")>] IssuingCardSpendingLimitCategories'AmusementParksCarnivals
        | [<JsonUnionCase("antique_reproductions")>] IssuingCardSpendingLimitCategories'AntiqueReproductions
        | [<JsonUnionCase("antique_shops")>] IssuingCardSpendingLimitCategories'AntiqueShops
        | [<JsonUnionCase("aquariums")>] IssuingCardSpendingLimitCategories'Aquariums
        | [<JsonUnionCase("architectural_surveying_services")>] IssuingCardSpendingLimitCategories'ArchitecturalSurveyingServices
        | [<JsonUnionCase("art_dealers_and_galleries")>] IssuingCardSpendingLimitCategories'ArtDealersAndGalleries
        | [<JsonUnionCase("artists_supply_and_craft_shops")>] IssuingCardSpendingLimitCategories'ArtistsSupplyAndCraftShops
        | [<JsonUnionCase("auto_and_home_supply_stores")>] IssuingCardSpendingLimitCategories'AutoAndHomeSupplyStores
        | [<JsonUnionCase("auto_body_repair_shops")>] IssuingCardSpendingLimitCategories'AutoBodyRepairShops
        | [<JsonUnionCase("auto_paint_shops")>] IssuingCardSpendingLimitCategories'AutoPaintShops
        | [<JsonUnionCase("auto_service_shops")>] IssuingCardSpendingLimitCategories'AutoServiceShops
        | [<JsonUnionCase("automated_cash_disburse")>] IssuingCardSpendingLimitCategories'AutomatedCashDisburse
        | [<JsonUnionCase("automated_fuel_dispensers")>] IssuingCardSpendingLimitCategories'AutomatedFuelDispensers
        | [<JsonUnionCase("automobile_associations")>] IssuingCardSpendingLimitCategories'AutomobileAssociations
        | [<JsonUnionCase("automotive_parts_and_accessories_stores")>] IssuingCardSpendingLimitCategories'AutomotivePartsAndAccessoriesStores
        | [<JsonUnionCase("automotive_tire_stores")>] IssuingCardSpendingLimitCategories'AutomotiveTireStores
        | [<JsonUnionCase("bail_and_bond_payments")>] IssuingCardSpendingLimitCategories'BailAndBondPayments
        | [<JsonUnionCase("bakeries")>] IssuingCardSpendingLimitCategories'Bakeries
        | [<JsonUnionCase("bands_orchestras")>] IssuingCardSpendingLimitCategories'BandsOrchestras
        | [<JsonUnionCase("barber_and_beauty_shops")>] IssuingCardSpendingLimitCategories'BarberAndBeautyShops
        | [<JsonUnionCase("betting_casino_gambling")>] IssuingCardSpendingLimitCategories'BettingCasinoGambling
        | [<JsonUnionCase("bicycle_shops")>] IssuingCardSpendingLimitCategories'BicycleShops
        | [<JsonUnionCase("billiard_pool_establishments")>] IssuingCardSpendingLimitCategories'BilliardPoolEstablishments
        | [<JsonUnionCase("boat_dealers")>] IssuingCardSpendingLimitCategories'BoatDealers
        | [<JsonUnionCase("boat_rentals_and_leases")>] IssuingCardSpendingLimitCategories'BoatRentalsAndLeases
        | [<JsonUnionCase("book_stores")>] IssuingCardSpendingLimitCategories'BookStores
        | [<JsonUnionCase("books_periodicals_and_newspapers")>] IssuingCardSpendingLimitCategories'BooksPeriodicalsAndNewspapers
        | [<JsonUnionCase("bowling_alleys")>] IssuingCardSpendingLimitCategories'BowlingAlleys
        | [<JsonUnionCase("bus_lines")>] IssuingCardSpendingLimitCategories'BusLines
        | [<JsonUnionCase("business_secretarial_schools")>] IssuingCardSpendingLimitCategories'BusinessSecretarialSchools
        | [<JsonUnionCase("buying_shopping_services")>] IssuingCardSpendingLimitCategories'BuyingShoppingServices
        | [<JsonUnionCase("cable_satellite_and_other_pay_television_and_radio")>] IssuingCardSpendingLimitCategories'CableSatelliteAndOtherPayTelevisionAndRadio
        | [<JsonUnionCase("camera_and_photographic_supply_stores")>] IssuingCardSpendingLimitCategories'CameraAndPhotographicSupplyStores
        | [<JsonUnionCase("candy_nut_and_confectionery_stores")>] IssuingCardSpendingLimitCategories'CandyNutAndConfectioneryStores
        | [<JsonUnionCase("car_and_truck_dealers_new_used")>] IssuingCardSpendingLimitCategories'CarAndTruckDealersNewUsed
        | [<JsonUnionCase("car_and_truck_dealers_used_only")>] IssuingCardSpendingLimitCategories'CarAndTruckDealersUsedOnly
        | [<JsonUnionCase("car_rental_agencies")>] IssuingCardSpendingLimitCategories'CarRentalAgencies
        | [<JsonUnionCase("car_washes")>] IssuingCardSpendingLimitCategories'CarWashes
        | [<JsonUnionCase("carpentry_services")>] IssuingCardSpendingLimitCategories'CarpentryServices
        | [<JsonUnionCase("carpet_upholstery_cleaning")>] IssuingCardSpendingLimitCategories'CarpetUpholsteryCleaning
        | [<JsonUnionCase("caterers")>] IssuingCardSpendingLimitCategories'Caterers
        | [<JsonUnionCase("charitable_and_social_service_organizations_fundraising")>] IssuingCardSpendingLimitCategories'CharitableAndSocialServiceOrganizationsFundraising
        | [<JsonUnionCase("chemicals_and_allied_products")>] IssuingCardSpendingLimitCategories'ChemicalsAndAlliedProducts
        | [<JsonUnionCase("child_care_services")>] IssuingCardSpendingLimitCategories'ChildCareServices
        | [<JsonUnionCase("childrens_and_infants_wear_stores")>] IssuingCardSpendingLimitCategories'ChildrensAndInfantsWearStores
        | [<JsonUnionCase("chiropodists_podiatrists")>] IssuingCardSpendingLimitCategories'ChiropodistsPodiatrists
        | [<JsonUnionCase("chiropractors")>] IssuingCardSpendingLimitCategories'Chiropractors
        | [<JsonUnionCase("cigar_stores_and_stands")>] IssuingCardSpendingLimitCategories'CigarStoresAndStands
        | [<JsonUnionCase("civic_social_fraternal_associations")>] IssuingCardSpendingLimitCategories'CivicSocialFraternalAssociations
        | [<JsonUnionCase("cleaning_and_maintenance")>] IssuingCardSpendingLimitCategories'CleaningAndMaintenance
        | [<JsonUnionCase("clothing_rental")>] IssuingCardSpendingLimitCategories'ClothingRental
        | [<JsonUnionCase("colleges_universities")>] IssuingCardSpendingLimitCategories'CollegesUniversities
        | [<JsonUnionCase("commercial_equipment")>] IssuingCardSpendingLimitCategories'CommercialEquipment
        | [<JsonUnionCase("commercial_footwear")>] IssuingCardSpendingLimitCategories'CommercialFootwear
        | [<JsonUnionCase("commercial_photography_art_and_graphics")>] IssuingCardSpendingLimitCategories'CommercialPhotographyArtAndGraphics
        | [<JsonUnionCase("commuter_transport_and_ferries")>] IssuingCardSpendingLimitCategories'CommuterTransportAndFerries
        | [<JsonUnionCase("computer_network_services")>] IssuingCardSpendingLimitCategories'ComputerNetworkServices
        | [<JsonUnionCase("computer_programming")>] IssuingCardSpendingLimitCategories'ComputerProgramming
        | [<JsonUnionCase("computer_repair")>] IssuingCardSpendingLimitCategories'ComputerRepair
        | [<JsonUnionCase("computer_software_stores")>] IssuingCardSpendingLimitCategories'ComputerSoftwareStores
        | [<JsonUnionCase("computers_peripherals_and_software")>] IssuingCardSpendingLimitCategories'ComputersPeripheralsAndSoftware
        | [<JsonUnionCase("concrete_work_services")>] IssuingCardSpendingLimitCategories'ConcreteWorkServices
        | [<JsonUnionCase("construction_materials")>] IssuingCardSpendingLimitCategories'ConstructionMaterials
        | [<JsonUnionCase("consulting_public_relations")>] IssuingCardSpendingLimitCategories'ConsultingPublicRelations
        | [<JsonUnionCase("correspondence_schools")>] IssuingCardSpendingLimitCategories'CorrespondenceSchools
        | [<JsonUnionCase("cosmetic_stores")>] IssuingCardSpendingLimitCategories'CosmeticStores
        | [<JsonUnionCase("counseling_services")>] IssuingCardSpendingLimitCategories'CounselingServices
        | [<JsonUnionCase("country_clubs")>] IssuingCardSpendingLimitCategories'CountryClubs
        | [<JsonUnionCase("courier_services")>] IssuingCardSpendingLimitCategories'CourierServices
        | [<JsonUnionCase("court_costs")>] IssuingCardSpendingLimitCategories'CourtCosts
        | [<JsonUnionCase("credit_reporting_agencies")>] IssuingCardSpendingLimitCategories'CreditReportingAgencies
        | [<JsonUnionCase("cruise_lines")>] IssuingCardSpendingLimitCategories'CruiseLines
        | [<JsonUnionCase("dairy_products_stores")>] IssuingCardSpendingLimitCategories'DairyProductsStores
        | [<JsonUnionCase("dance_hall_studios_schools")>] IssuingCardSpendingLimitCategories'DanceHallStudiosSchools
        | [<JsonUnionCase("dating_escort_services")>] IssuingCardSpendingLimitCategories'DatingEscortServices
        | [<JsonUnionCase("dentists_orthodontists")>] IssuingCardSpendingLimitCategories'DentistsOrthodontists
        | [<JsonUnionCase("department_stores")>] IssuingCardSpendingLimitCategories'DepartmentStores
        | [<JsonUnionCase("detective_agencies")>] IssuingCardSpendingLimitCategories'DetectiveAgencies
        | [<JsonUnionCase("digital_goods_applications")>] IssuingCardSpendingLimitCategories'DigitalGoodsApplications
        | [<JsonUnionCase("digital_goods_games")>] IssuingCardSpendingLimitCategories'DigitalGoodsGames
        | [<JsonUnionCase("digital_goods_large_volume")>] IssuingCardSpendingLimitCategories'DigitalGoodsLargeVolume
        | [<JsonUnionCase("digital_goods_media")>] IssuingCardSpendingLimitCategories'DigitalGoodsMedia
        | [<JsonUnionCase("direct_marketing_catalog_merchant")>] IssuingCardSpendingLimitCategories'DirectMarketingCatalogMerchant
        | [<JsonUnionCase("direct_marketing_combination_catalog_and_retail_merchant")>] IssuingCardSpendingLimitCategories'DirectMarketingCombinationCatalogAndRetailMerchant
        | [<JsonUnionCase("direct_marketing_inbound_telemarketing")>] IssuingCardSpendingLimitCategories'DirectMarketingInboundTelemarketing
        | [<JsonUnionCase("direct_marketing_insurance_services")>] IssuingCardSpendingLimitCategories'DirectMarketingInsuranceServices
        | [<JsonUnionCase("direct_marketing_other")>] IssuingCardSpendingLimitCategories'DirectMarketingOther
        | [<JsonUnionCase("direct_marketing_outbound_telemarketing")>] IssuingCardSpendingLimitCategories'DirectMarketingOutboundTelemarketing
        | [<JsonUnionCase("direct_marketing_subscription")>] IssuingCardSpendingLimitCategories'DirectMarketingSubscription
        | [<JsonUnionCase("direct_marketing_travel")>] IssuingCardSpendingLimitCategories'DirectMarketingTravel
        | [<JsonUnionCase("discount_stores")>] IssuingCardSpendingLimitCategories'DiscountStores
        | [<JsonUnionCase("doctors")>] IssuingCardSpendingLimitCategories'Doctors
        | [<JsonUnionCase("door_to_door_sales")>] IssuingCardSpendingLimitCategories'DoorToDoorSales
        | [<JsonUnionCase("drapery_window_covering_and_upholstery_stores")>] IssuingCardSpendingLimitCategories'DraperyWindowCoveringAndUpholsteryStores
        | [<JsonUnionCase("drinking_places")>] IssuingCardSpendingLimitCategories'DrinkingPlaces
        | [<JsonUnionCase("drug_stores_and_pharmacies")>] IssuingCardSpendingLimitCategories'DrugStoresAndPharmacies
        | [<JsonUnionCase("drugs_drug_proprietaries_and_druggist_sundries")>] IssuingCardSpendingLimitCategories'DrugsDrugProprietariesAndDruggistSundries
        | [<JsonUnionCase("dry_cleaners")>] IssuingCardSpendingLimitCategories'DryCleaners
        | [<JsonUnionCase("durable_goods")>] IssuingCardSpendingLimitCategories'DurableGoods
        | [<JsonUnionCase("duty_free_stores")>] IssuingCardSpendingLimitCategories'DutyFreeStores
        | [<JsonUnionCase("eating_places_restaurants")>] IssuingCardSpendingLimitCategories'EatingPlacesRestaurants
        | [<JsonUnionCase("educational_services")>] IssuingCardSpendingLimitCategories'EducationalServices
        | [<JsonUnionCase("electric_razor_stores")>] IssuingCardSpendingLimitCategories'ElectricRazorStores
        | [<JsonUnionCase("electrical_parts_and_equipment")>] IssuingCardSpendingLimitCategories'ElectricalPartsAndEquipment
        | [<JsonUnionCase("electrical_services")>] IssuingCardSpendingLimitCategories'ElectricalServices
        | [<JsonUnionCase("electronics_repair_shops")>] IssuingCardSpendingLimitCategories'ElectronicsRepairShops
        | [<JsonUnionCase("electronics_stores")>] IssuingCardSpendingLimitCategories'ElectronicsStores
        | [<JsonUnionCase("elementary_secondary_schools")>] IssuingCardSpendingLimitCategories'ElementarySecondarySchools
        | [<JsonUnionCase("employment_temp_agencies")>] IssuingCardSpendingLimitCategories'EmploymentTempAgencies
        | [<JsonUnionCase("equipment_rental")>] IssuingCardSpendingLimitCategories'EquipmentRental
        | [<JsonUnionCase("exterminating_services")>] IssuingCardSpendingLimitCategories'ExterminatingServices
        | [<JsonUnionCase("family_clothing_stores")>] IssuingCardSpendingLimitCategories'FamilyClothingStores
        | [<JsonUnionCase("fast_food_restaurants")>] IssuingCardSpendingLimitCategories'FastFoodRestaurants
        | [<JsonUnionCase("financial_institutions")>] IssuingCardSpendingLimitCategories'FinancialInstitutions
        | [<JsonUnionCase("fines_government_administrative_entities")>] IssuingCardSpendingLimitCategories'FinesGovernmentAdministrativeEntities
        | [<JsonUnionCase("fireplace_fireplace_screens_and_accessories_stores")>] IssuingCardSpendingLimitCategories'FireplaceFireplaceScreensAndAccessoriesStores
        | [<JsonUnionCase("floor_covering_stores")>] IssuingCardSpendingLimitCategories'FloorCoveringStores
        | [<JsonUnionCase("florists")>] IssuingCardSpendingLimitCategories'Florists
        | [<JsonUnionCase("florists_supplies_nursery_stock_and_flowers")>] IssuingCardSpendingLimitCategories'FloristsSuppliesNurseryStockAndFlowers
        | [<JsonUnionCase("freezer_and_locker_meat_provisioners")>] IssuingCardSpendingLimitCategories'FreezerAndLockerMeatProvisioners
        | [<JsonUnionCase("fuel_dealers_non_automotive")>] IssuingCardSpendingLimitCategories'FuelDealersNonAutomotive
        | [<JsonUnionCase("funeral_services_crematories")>] IssuingCardSpendingLimitCategories'FuneralServicesCrematories
        | [<JsonUnionCase("furniture_home_furnishings_and_equipment_stores_except_appliances")>] IssuingCardSpendingLimitCategories'FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | [<JsonUnionCase("furniture_repair_refinishing")>] IssuingCardSpendingLimitCategories'FurnitureRepairRefinishing
        | [<JsonUnionCase("furriers_and_fur_shops")>] IssuingCardSpendingLimitCategories'FurriersAndFurShops
        | [<JsonUnionCase("general_services")>] IssuingCardSpendingLimitCategories'GeneralServices
        | [<JsonUnionCase("gift_card_novelty_and_souvenir_shops")>] IssuingCardSpendingLimitCategories'GiftCardNoveltyAndSouvenirShops
        | [<JsonUnionCase("glass_paint_and_wallpaper_stores")>] IssuingCardSpendingLimitCategories'GlassPaintAndWallpaperStores
        | [<JsonUnionCase("glassware_crystal_stores")>] IssuingCardSpendingLimitCategories'GlasswareCrystalStores
        | [<JsonUnionCase("golf_courses_public")>] IssuingCardSpendingLimitCategories'GolfCoursesPublic
        | [<JsonUnionCase("government_services")>] IssuingCardSpendingLimitCategories'GovernmentServices
        | [<JsonUnionCase("grocery_stores_supermarkets")>] IssuingCardSpendingLimitCategories'GroceryStoresSupermarkets
        | [<JsonUnionCase("hardware_equipment_and_supplies")>] IssuingCardSpendingLimitCategories'HardwareEquipmentAndSupplies
        | [<JsonUnionCase("hardware_stores")>] IssuingCardSpendingLimitCategories'HardwareStores
        | [<JsonUnionCase("health_and_beauty_spas")>] IssuingCardSpendingLimitCategories'HealthAndBeautySpas
        | [<JsonUnionCase("hearing_aids_sales_and_supplies")>] IssuingCardSpendingLimitCategories'HearingAidsSalesAndSupplies
        | [<JsonUnionCase("heating_plumbing_a_c")>] IssuingCardSpendingLimitCategories'HeatingPlumbingAC
        | [<JsonUnionCase("hobby_toy_and_game_shops")>] IssuingCardSpendingLimitCategories'HobbyToyAndGameShops
        | [<JsonUnionCase("home_supply_warehouse_stores")>] IssuingCardSpendingLimitCategories'HomeSupplyWarehouseStores
        | [<JsonUnionCase("hospitals")>] IssuingCardSpendingLimitCategories'Hospitals
        | [<JsonUnionCase("hotels_motels_and_resorts")>] IssuingCardSpendingLimitCategories'HotelsMotelsAndResorts
        | [<JsonUnionCase("household_appliance_stores")>] IssuingCardSpendingLimitCategories'HouseholdApplianceStores
        | [<JsonUnionCase("industrial_supplies")>] IssuingCardSpendingLimitCategories'IndustrialSupplies
        | [<JsonUnionCase("information_retrieval_services")>] IssuingCardSpendingLimitCategories'InformationRetrievalServices
        | [<JsonUnionCase("insurance_default")>] IssuingCardSpendingLimitCategories'InsuranceDefault
        | [<JsonUnionCase("insurance_underwriting_premiums")>] IssuingCardSpendingLimitCategories'InsuranceUnderwritingPremiums
        | [<JsonUnionCase("intra_company_purchases")>] IssuingCardSpendingLimitCategories'IntraCompanyPurchases
        | [<JsonUnionCase("jewelry_stores_watches_clocks_and_silverware_stores")>] IssuingCardSpendingLimitCategories'JewelryStoresWatchesClocksAndSilverwareStores
        | [<JsonUnionCase("landscaping_services")>] IssuingCardSpendingLimitCategories'LandscapingServices
        | [<JsonUnionCase("laundries")>] IssuingCardSpendingLimitCategories'Laundries
        | [<JsonUnionCase("laundry_cleaning_services")>] IssuingCardSpendingLimitCategories'LaundryCleaningServices
        | [<JsonUnionCase("legal_services_attorneys")>] IssuingCardSpendingLimitCategories'LegalServicesAttorneys
        | [<JsonUnionCase("luggage_and_leather_goods_stores")>] IssuingCardSpendingLimitCategories'LuggageAndLeatherGoodsStores
        | [<JsonUnionCase("lumber_building_materials_stores")>] IssuingCardSpendingLimitCategories'LumberBuildingMaterialsStores
        | [<JsonUnionCase("manual_cash_disburse")>] IssuingCardSpendingLimitCategories'ManualCashDisburse
        | [<JsonUnionCase("marinas_service_and_supplies")>] IssuingCardSpendingLimitCategories'MarinasServiceAndSupplies
        | [<JsonUnionCase("masonry_stonework_and_plaster")>] IssuingCardSpendingLimitCategories'MasonryStoneworkAndPlaster
        | [<JsonUnionCase("massage_parlors")>] IssuingCardSpendingLimitCategories'MassageParlors
        | [<JsonUnionCase("medical_and_dental_labs")>] IssuingCardSpendingLimitCategories'MedicalAndDentalLabs
        | [<JsonUnionCase("medical_dental_ophthalmic_and_hospital_equipment_and_supplies")>] IssuingCardSpendingLimitCategories'MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | [<JsonUnionCase("medical_services")>] IssuingCardSpendingLimitCategories'MedicalServices
        | [<JsonUnionCase("membership_organizations")>] IssuingCardSpendingLimitCategories'MembershipOrganizations
        | [<JsonUnionCase("mens_and_boys_clothing_and_accessories_stores")>] IssuingCardSpendingLimitCategories'MensAndBoysClothingAndAccessoriesStores
        | [<JsonUnionCase("mens_womens_clothing_stores")>] IssuingCardSpendingLimitCategories'MensWomensClothingStores
        | [<JsonUnionCase("metal_service_centers")>] IssuingCardSpendingLimitCategories'MetalServiceCenters
        | [<JsonUnionCase("miscellaneous")>] IssuingCardSpendingLimitCategories'Miscellaneous
        | [<JsonUnionCase("miscellaneous_apparel_and_accessory_shops")>] IssuingCardSpendingLimitCategories'MiscellaneousApparelAndAccessoryShops
        | [<JsonUnionCase("miscellaneous_auto_dealers")>] IssuingCardSpendingLimitCategories'MiscellaneousAutoDealers
        | [<JsonUnionCase("miscellaneous_business_services")>] IssuingCardSpendingLimitCategories'MiscellaneousBusinessServices
        | [<JsonUnionCase("miscellaneous_food_stores")>] IssuingCardSpendingLimitCategories'MiscellaneousFoodStores
        | [<JsonUnionCase("miscellaneous_general_merchandise")>] IssuingCardSpendingLimitCategories'MiscellaneousGeneralMerchandise
        | [<JsonUnionCase("miscellaneous_general_services")>] IssuingCardSpendingLimitCategories'MiscellaneousGeneralServices
        | [<JsonUnionCase("miscellaneous_home_furnishing_specialty_stores")>] IssuingCardSpendingLimitCategories'MiscellaneousHomeFurnishingSpecialtyStores
        | [<JsonUnionCase("miscellaneous_publishing_and_printing")>] IssuingCardSpendingLimitCategories'MiscellaneousPublishingAndPrinting
        | [<JsonUnionCase("miscellaneous_recreation_services")>] IssuingCardSpendingLimitCategories'MiscellaneousRecreationServices
        | [<JsonUnionCase("miscellaneous_repair_shops")>] IssuingCardSpendingLimitCategories'MiscellaneousRepairShops
        | [<JsonUnionCase("miscellaneous_specialty_retail")>] IssuingCardSpendingLimitCategories'MiscellaneousSpecialtyRetail
        | [<JsonUnionCase("mobile_home_dealers")>] IssuingCardSpendingLimitCategories'MobileHomeDealers
        | [<JsonUnionCase("motion_picture_theaters")>] IssuingCardSpendingLimitCategories'MotionPictureTheaters
        | [<JsonUnionCase("motor_freight_carriers_and_trucking")>] IssuingCardSpendingLimitCategories'MotorFreightCarriersAndTrucking
        | [<JsonUnionCase("motor_homes_dealers")>] IssuingCardSpendingLimitCategories'MotorHomesDealers
        | [<JsonUnionCase("motor_vehicle_supplies_and_new_parts")>] IssuingCardSpendingLimitCategories'MotorVehicleSuppliesAndNewParts
        | [<JsonUnionCase("motorcycle_shops_and_dealers")>] IssuingCardSpendingLimitCategories'MotorcycleShopsAndDealers
        | [<JsonUnionCase("motorcycle_shops_dealers")>] IssuingCardSpendingLimitCategories'MotorcycleShopsDealers
        | [<JsonUnionCase("music_stores_musical_instruments_pianos_and_sheet_music")>] IssuingCardSpendingLimitCategories'MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | [<JsonUnionCase("news_dealers_and_newsstands")>] IssuingCardSpendingLimitCategories'NewsDealersAndNewsstands
        | [<JsonUnionCase("non_fi_money_orders")>] IssuingCardSpendingLimitCategories'NonFiMoneyOrders
        | [<JsonUnionCase("non_fi_stored_value_card_purchase_load")>] IssuingCardSpendingLimitCategories'NonFiStoredValueCardPurchaseLoad
        | [<JsonUnionCase("nondurable_goods")>] IssuingCardSpendingLimitCategories'NondurableGoods
        | [<JsonUnionCase("nurseries_lawn_and_garden_supply_stores")>] IssuingCardSpendingLimitCategories'NurseriesLawnAndGardenSupplyStores
        | [<JsonUnionCase("nursing_personal_care")>] IssuingCardSpendingLimitCategories'NursingPersonalCare
        | [<JsonUnionCase("office_and_commercial_furniture")>] IssuingCardSpendingLimitCategories'OfficeAndCommercialFurniture
        | [<JsonUnionCase("opticians_eyeglasses")>] IssuingCardSpendingLimitCategories'OpticiansEyeglasses
        | [<JsonUnionCase("optometrists_ophthalmologist")>] IssuingCardSpendingLimitCategories'OptometristsOphthalmologist
        | [<JsonUnionCase("orthopedic_goods_prosthetic_devices")>] IssuingCardSpendingLimitCategories'OrthopedicGoodsProstheticDevices
        | [<JsonUnionCase("osteopaths")>] IssuingCardSpendingLimitCategories'Osteopaths
        | [<JsonUnionCase("package_stores_beer_wine_and_liquor")>] IssuingCardSpendingLimitCategories'PackageStoresBeerWineAndLiquor
        | [<JsonUnionCase("paints_varnishes_and_supplies")>] IssuingCardSpendingLimitCategories'PaintsVarnishesAndSupplies
        | [<JsonUnionCase("parking_lots_garages")>] IssuingCardSpendingLimitCategories'ParkingLotsGarages
        | [<JsonUnionCase("passenger_railways")>] IssuingCardSpendingLimitCategories'PassengerRailways
        | [<JsonUnionCase("pawn_shops")>] IssuingCardSpendingLimitCategories'PawnShops
        | [<JsonUnionCase("pet_shops_pet_food_and_supplies")>] IssuingCardSpendingLimitCategories'PetShopsPetFoodAndSupplies
        | [<JsonUnionCase("petroleum_and_petroleum_products")>] IssuingCardSpendingLimitCategories'PetroleumAndPetroleumProducts
        | [<JsonUnionCase("photo_developing")>] IssuingCardSpendingLimitCategories'PhotoDeveloping
        | [<JsonUnionCase("photographic_photocopy_microfilm_equipment_and_supplies")>] IssuingCardSpendingLimitCategories'PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | [<JsonUnionCase("photographic_studios")>] IssuingCardSpendingLimitCategories'PhotographicStudios
        | [<JsonUnionCase("picture_video_production")>] IssuingCardSpendingLimitCategories'PictureVideoProduction
        | [<JsonUnionCase("piece_goods_notions_and_other_dry_goods")>] IssuingCardSpendingLimitCategories'PieceGoodsNotionsAndOtherDryGoods
        | [<JsonUnionCase("plumbing_heating_equipment_and_supplies")>] IssuingCardSpendingLimitCategories'PlumbingHeatingEquipmentAndSupplies
        | [<JsonUnionCase("political_organizations")>] IssuingCardSpendingLimitCategories'PoliticalOrganizations
        | [<JsonUnionCase("postal_services_government_only")>] IssuingCardSpendingLimitCategories'PostalServicesGovernmentOnly
        | [<JsonUnionCase("precious_stones_and_metals_watches_and_jewelry")>] IssuingCardSpendingLimitCategories'PreciousStonesAndMetalsWatchesAndJewelry
        | [<JsonUnionCase("professional_services")>] IssuingCardSpendingLimitCategories'ProfessionalServices
        | [<JsonUnionCase("public_warehousing_and_storage")>] IssuingCardSpendingLimitCategories'PublicWarehousingAndStorage
        | [<JsonUnionCase("quick_copy_repro_and_blueprint")>] IssuingCardSpendingLimitCategories'QuickCopyReproAndBlueprint
        | [<JsonUnionCase("railroads")>] IssuingCardSpendingLimitCategories'Railroads
        | [<JsonUnionCase("real_estate_agents_and_managers_rentals")>] IssuingCardSpendingLimitCategories'RealEstateAgentsAndManagersRentals
        | [<JsonUnionCase("record_stores")>] IssuingCardSpendingLimitCategories'RecordStores
        | [<JsonUnionCase("recreational_vehicle_rentals")>] IssuingCardSpendingLimitCategories'RecreationalVehicleRentals
        | [<JsonUnionCase("religious_goods_stores")>] IssuingCardSpendingLimitCategories'ReligiousGoodsStores
        | [<JsonUnionCase("religious_organizations")>] IssuingCardSpendingLimitCategories'ReligiousOrganizations
        | [<JsonUnionCase("roofing_siding_sheet_metal")>] IssuingCardSpendingLimitCategories'RoofingSidingSheetMetal
        | [<JsonUnionCase("secretarial_support_services")>] IssuingCardSpendingLimitCategories'SecretarialSupportServices
        | [<JsonUnionCase("security_brokers_dealers")>] IssuingCardSpendingLimitCategories'SecurityBrokersDealers
        | [<JsonUnionCase("service_stations")>] IssuingCardSpendingLimitCategories'ServiceStations
        | [<JsonUnionCase("sewing_needlework_fabric_and_piece_goods_stores")>] IssuingCardSpendingLimitCategories'SewingNeedleworkFabricAndPieceGoodsStores
        | [<JsonUnionCase("shoe_repair_hat_cleaning")>] IssuingCardSpendingLimitCategories'ShoeRepairHatCleaning
        | [<JsonUnionCase("shoe_stores")>] IssuingCardSpendingLimitCategories'ShoeStores
        | [<JsonUnionCase("small_appliance_repair")>] IssuingCardSpendingLimitCategories'SmallApplianceRepair
        | [<JsonUnionCase("snowmobile_dealers")>] IssuingCardSpendingLimitCategories'SnowmobileDealers
        | [<JsonUnionCase("special_trade_services")>] IssuingCardSpendingLimitCategories'SpecialTradeServices
        | [<JsonUnionCase("specialty_cleaning")>] IssuingCardSpendingLimitCategories'SpecialtyCleaning
        | [<JsonUnionCase("sporting_goods_stores")>] IssuingCardSpendingLimitCategories'SportingGoodsStores
        | [<JsonUnionCase("sporting_recreation_camps")>] IssuingCardSpendingLimitCategories'SportingRecreationCamps
        | [<JsonUnionCase("sports_and_riding_apparel_stores")>] IssuingCardSpendingLimitCategories'SportsAndRidingApparelStores
        | [<JsonUnionCase("sports_clubs_fields")>] IssuingCardSpendingLimitCategories'SportsClubsFields
        | [<JsonUnionCase("stamp_and_coin_stores")>] IssuingCardSpendingLimitCategories'StampAndCoinStores
        | [<JsonUnionCase("stationary_office_supplies_printing_and_writing_paper")>] IssuingCardSpendingLimitCategories'StationaryOfficeSuppliesPrintingAndWritingPaper
        | [<JsonUnionCase("stationery_stores_office_and_school_supply_stores")>] IssuingCardSpendingLimitCategories'StationeryStoresOfficeAndSchoolSupplyStores
        | [<JsonUnionCase("swimming_pools_sales")>] IssuingCardSpendingLimitCategories'SwimmingPoolsSales
        | [<JsonUnionCase("t_ui_travel_germany")>] IssuingCardSpendingLimitCategories'TUiTravelGermany
        | [<JsonUnionCase("tailors_alterations")>] IssuingCardSpendingLimitCategories'TailorsAlterations
        | [<JsonUnionCase("tax_payments_government_agencies")>] IssuingCardSpendingLimitCategories'TaxPaymentsGovernmentAgencies
        | [<JsonUnionCase("tax_preparation_services")>] IssuingCardSpendingLimitCategories'TaxPreparationServices
        | [<JsonUnionCase("taxicabs_limousines")>] IssuingCardSpendingLimitCategories'TaxicabsLimousines
        | [<JsonUnionCase("telecommunication_equipment_and_telephone_sales")>] IssuingCardSpendingLimitCategories'TelecommunicationEquipmentAndTelephoneSales
        | [<JsonUnionCase("telecommunication_services")>] IssuingCardSpendingLimitCategories'TelecommunicationServices
        | [<JsonUnionCase("telegraph_services")>] IssuingCardSpendingLimitCategories'TelegraphServices
        | [<JsonUnionCase("tent_and_awning_shops")>] IssuingCardSpendingLimitCategories'TentAndAwningShops
        | [<JsonUnionCase("testing_laboratories")>] IssuingCardSpendingLimitCategories'TestingLaboratories
        | [<JsonUnionCase("theatrical_ticket_agencies")>] IssuingCardSpendingLimitCategories'TheatricalTicketAgencies
        | [<JsonUnionCase("timeshares")>] IssuingCardSpendingLimitCategories'Timeshares
        | [<JsonUnionCase("tire_retreading_and_repair")>] IssuingCardSpendingLimitCategories'TireRetreadingAndRepair
        | [<JsonUnionCase("tolls_bridge_fees")>] IssuingCardSpendingLimitCategories'TollsBridgeFees
        | [<JsonUnionCase("tourist_attractions_and_exhibits")>] IssuingCardSpendingLimitCategories'TouristAttractionsAndExhibits
        | [<JsonUnionCase("towing_services")>] IssuingCardSpendingLimitCategories'TowingServices
        | [<JsonUnionCase("trailer_parks_campgrounds")>] IssuingCardSpendingLimitCategories'TrailerParksCampgrounds
        | [<JsonUnionCase("transportation_services")>] IssuingCardSpendingLimitCategories'TransportationServices
        | [<JsonUnionCase("travel_agencies_tour_operators")>] IssuingCardSpendingLimitCategories'TravelAgenciesTourOperators
        | [<JsonUnionCase("truck_stop_iteration")>] IssuingCardSpendingLimitCategories'TruckStopIteration
        | [<JsonUnionCase("truck_utility_trailer_rentals")>] IssuingCardSpendingLimitCategories'TruckUtilityTrailerRentals
        | [<JsonUnionCase("typesetting_plate_making_and_related_services")>] IssuingCardSpendingLimitCategories'TypesettingPlateMakingAndRelatedServices
        | [<JsonUnionCase("typewriter_stores")>] IssuingCardSpendingLimitCategories'TypewriterStores
        | [<JsonUnionCase("u_s_federal_government_agencies_or_departments")>] IssuingCardSpendingLimitCategories'USFederalGovernmentAgenciesOrDepartments
        | [<JsonUnionCase("uniforms_commercial_clothing")>] IssuingCardSpendingLimitCategories'UniformsCommercialClothing
        | [<JsonUnionCase("used_merchandise_and_secondhand_stores")>] IssuingCardSpendingLimitCategories'UsedMerchandiseAndSecondhandStores
        | [<JsonUnionCase("utilities")>] IssuingCardSpendingLimitCategories'Utilities
        | [<JsonUnionCase("variety_stores")>] IssuingCardSpendingLimitCategories'VarietyStores
        | [<JsonUnionCase("veterinary_services")>] IssuingCardSpendingLimitCategories'VeterinaryServices
        | [<JsonUnionCase("video_amusement_game_supplies")>] IssuingCardSpendingLimitCategories'VideoAmusementGameSupplies
        | [<JsonUnionCase("video_game_arcades")>] IssuingCardSpendingLimitCategories'VideoGameArcades
        | [<JsonUnionCase("video_tape_rental_stores")>] IssuingCardSpendingLimitCategories'VideoTapeRentalStores
        | [<JsonUnionCase("vocational_trade_schools")>] IssuingCardSpendingLimitCategories'VocationalTradeSchools
        | [<JsonUnionCase("watch_jewelry_repair")>] IssuingCardSpendingLimitCategories'WatchJewelryRepair
        | [<JsonUnionCase("welding_repair")>] IssuingCardSpendingLimitCategories'WeldingRepair
        | [<JsonUnionCase("wholesale_clubs")>] IssuingCardSpendingLimitCategories'WholesaleClubs
        | [<JsonUnionCase("wig_and_toupee_stores")>] IssuingCardSpendingLimitCategories'WigAndToupeeStores
        | [<JsonUnionCase("wires_money_orders")>] IssuingCardSpendingLimitCategories'WiresMoneyOrders
        | [<JsonUnionCase("womens_accessory_and_specialty_shops")>] IssuingCardSpendingLimitCategories'WomensAccessoryAndSpecialtyShops
        | [<JsonUnionCase("womens_ready_to_wear_stores")>] IssuingCardSpendingLimitCategories'WomensReadyToWearStores
        | [<JsonUnionCase("wrecking_and_salvage_yards")>] IssuingCardSpendingLimitCategories'WreckingAndSalvageYards

    and IssuingCardSpendingLimitInterval =
        | [<JsonUnionCase("all_time")>] IssuingCardSpendingLimitInterval'AllTime
        | [<JsonUnionCase("daily")>] IssuingCardSpendingLimitInterval'Daily
        | [<JsonUnionCase("monthly")>] IssuingCardSpendingLimitInterval'Monthly
        | [<JsonUnionCase("per_authorization")>] IssuingCardSpendingLimitInterval'PerAuthorization
        | [<JsonUnionCase("weekly")>] IssuingCardSpendingLimitInterval'Weekly
        | [<JsonUnionCase("yearly")>] IssuingCardSpendingLimitInterval'Yearly

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
        | [<JsonUnionCase("ac_refrigeration_repair")>] IssuingCardholderAuthorizationControlsAllowedCategories'AcRefrigerationRepair
        | [<JsonUnionCase("accounting_bookkeeping_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'AccountingBookkeepingServices
        | [<JsonUnionCase("advertising_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'AdvertisingServices
        | [<JsonUnionCase("agricultural_cooperative")>] IssuingCardholderAuthorizationControlsAllowedCategories'AgriculturalCooperative
        | [<JsonUnionCase("airlines_air_carriers")>] IssuingCardholderAuthorizationControlsAllowedCategories'AirlinesAirCarriers
        | [<JsonUnionCase("airports_flying_fields")>] IssuingCardholderAuthorizationControlsAllowedCategories'AirportsFlyingFields
        | [<JsonUnionCase("ambulance_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'AmbulanceServices
        | [<JsonUnionCase("amusement_parks_carnivals")>] IssuingCardholderAuthorizationControlsAllowedCategories'AmusementParksCarnivals
        | [<JsonUnionCase("antique_reproductions")>] IssuingCardholderAuthorizationControlsAllowedCategories'AntiqueReproductions
        | [<JsonUnionCase("antique_shops")>] IssuingCardholderAuthorizationControlsAllowedCategories'AntiqueShops
        | [<JsonUnionCase("aquariums")>] IssuingCardholderAuthorizationControlsAllowedCategories'Aquariums
        | [<JsonUnionCase("architectural_surveying_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'ArchitecturalSurveyingServices
        | [<JsonUnionCase("art_dealers_and_galleries")>] IssuingCardholderAuthorizationControlsAllowedCategories'ArtDealersAndGalleries
        | [<JsonUnionCase("artists_supply_and_craft_shops")>] IssuingCardholderAuthorizationControlsAllowedCategories'ArtistsSupplyAndCraftShops
        | [<JsonUnionCase("auto_and_home_supply_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'AutoAndHomeSupplyStores
        | [<JsonUnionCase("auto_body_repair_shops")>] IssuingCardholderAuthorizationControlsAllowedCategories'AutoBodyRepairShops
        | [<JsonUnionCase("auto_paint_shops")>] IssuingCardholderAuthorizationControlsAllowedCategories'AutoPaintShops
        | [<JsonUnionCase("auto_service_shops")>] IssuingCardholderAuthorizationControlsAllowedCategories'AutoServiceShops
        | [<JsonUnionCase("automated_cash_disburse")>] IssuingCardholderAuthorizationControlsAllowedCategories'AutomatedCashDisburse
        | [<JsonUnionCase("automated_fuel_dispensers")>] IssuingCardholderAuthorizationControlsAllowedCategories'AutomatedFuelDispensers
        | [<JsonUnionCase("automobile_associations")>] IssuingCardholderAuthorizationControlsAllowedCategories'AutomobileAssociations
        | [<JsonUnionCase("automotive_parts_and_accessories_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'AutomotivePartsAndAccessoriesStores
        | [<JsonUnionCase("automotive_tire_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'AutomotiveTireStores
        | [<JsonUnionCase("bail_and_bond_payments")>] IssuingCardholderAuthorizationControlsAllowedCategories'BailAndBondPayments
        | [<JsonUnionCase("bakeries")>] IssuingCardholderAuthorizationControlsAllowedCategories'Bakeries
        | [<JsonUnionCase("bands_orchestras")>] IssuingCardholderAuthorizationControlsAllowedCategories'BandsOrchestras
        | [<JsonUnionCase("barber_and_beauty_shops")>] IssuingCardholderAuthorizationControlsAllowedCategories'BarberAndBeautyShops
        | [<JsonUnionCase("betting_casino_gambling")>] IssuingCardholderAuthorizationControlsAllowedCategories'BettingCasinoGambling
        | [<JsonUnionCase("bicycle_shops")>] IssuingCardholderAuthorizationControlsAllowedCategories'BicycleShops
        | [<JsonUnionCase("billiard_pool_establishments")>] IssuingCardholderAuthorizationControlsAllowedCategories'BilliardPoolEstablishments
        | [<JsonUnionCase("boat_dealers")>] IssuingCardholderAuthorizationControlsAllowedCategories'BoatDealers
        | [<JsonUnionCase("boat_rentals_and_leases")>] IssuingCardholderAuthorizationControlsAllowedCategories'BoatRentalsAndLeases
        | [<JsonUnionCase("book_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'BookStores
        | [<JsonUnionCase("books_periodicals_and_newspapers")>] IssuingCardholderAuthorizationControlsAllowedCategories'BooksPeriodicalsAndNewspapers
        | [<JsonUnionCase("bowling_alleys")>] IssuingCardholderAuthorizationControlsAllowedCategories'BowlingAlleys
        | [<JsonUnionCase("bus_lines")>] IssuingCardholderAuthorizationControlsAllowedCategories'BusLines
        | [<JsonUnionCase("business_secretarial_schools")>] IssuingCardholderAuthorizationControlsAllowedCategories'BusinessSecretarialSchools
        | [<JsonUnionCase("buying_shopping_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'BuyingShoppingServices
        | [<JsonUnionCase("cable_satellite_and_other_pay_television_and_radio")>] IssuingCardholderAuthorizationControlsAllowedCategories'CableSatelliteAndOtherPayTelevisionAndRadio
        | [<JsonUnionCase("camera_and_photographic_supply_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'CameraAndPhotographicSupplyStores
        | [<JsonUnionCase("candy_nut_and_confectionery_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'CandyNutAndConfectioneryStores
        | [<JsonUnionCase("car_and_truck_dealers_new_used")>] IssuingCardholderAuthorizationControlsAllowedCategories'CarAndTruckDealersNewUsed
        | [<JsonUnionCase("car_and_truck_dealers_used_only")>] IssuingCardholderAuthorizationControlsAllowedCategories'CarAndTruckDealersUsedOnly
        | [<JsonUnionCase("car_rental_agencies")>] IssuingCardholderAuthorizationControlsAllowedCategories'CarRentalAgencies
        | [<JsonUnionCase("car_washes")>] IssuingCardholderAuthorizationControlsAllowedCategories'CarWashes
        | [<JsonUnionCase("carpentry_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'CarpentryServices
        | [<JsonUnionCase("carpet_upholstery_cleaning")>] IssuingCardholderAuthorizationControlsAllowedCategories'CarpetUpholsteryCleaning
        | [<JsonUnionCase("caterers")>] IssuingCardholderAuthorizationControlsAllowedCategories'Caterers
        | [<JsonUnionCase("charitable_and_social_service_organizations_fundraising")>] IssuingCardholderAuthorizationControlsAllowedCategories'CharitableAndSocialServiceOrganizationsFundraising
        | [<JsonUnionCase("chemicals_and_allied_products")>] IssuingCardholderAuthorizationControlsAllowedCategories'ChemicalsAndAlliedProducts
        | [<JsonUnionCase("child_care_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'ChildCareServices
        | [<JsonUnionCase("childrens_and_infants_wear_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'ChildrensAndInfantsWearStores
        | [<JsonUnionCase("chiropodists_podiatrists")>] IssuingCardholderAuthorizationControlsAllowedCategories'ChiropodistsPodiatrists
        | [<JsonUnionCase("chiropractors")>] IssuingCardholderAuthorizationControlsAllowedCategories'Chiropractors
        | [<JsonUnionCase("cigar_stores_and_stands")>] IssuingCardholderAuthorizationControlsAllowedCategories'CigarStoresAndStands
        | [<JsonUnionCase("civic_social_fraternal_associations")>] IssuingCardholderAuthorizationControlsAllowedCategories'CivicSocialFraternalAssociations
        | [<JsonUnionCase("cleaning_and_maintenance")>] IssuingCardholderAuthorizationControlsAllowedCategories'CleaningAndMaintenance
        | [<JsonUnionCase("clothing_rental")>] IssuingCardholderAuthorizationControlsAllowedCategories'ClothingRental
        | [<JsonUnionCase("colleges_universities")>] IssuingCardholderAuthorizationControlsAllowedCategories'CollegesUniversities
        | [<JsonUnionCase("commercial_equipment")>] IssuingCardholderAuthorizationControlsAllowedCategories'CommercialEquipment
        | [<JsonUnionCase("commercial_footwear")>] IssuingCardholderAuthorizationControlsAllowedCategories'CommercialFootwear
        | [<JsonUnionCase("commercial_photography_art_and_graphics")>] IssuingCardholderAuthorizationControlsAllowedCategories'CommercialPhotographyArtAndGraphics
        | [<JsonUnionCase("commuter_transport_and_ferries")>] IssuingCardholderAuthorizationControlsAllowedCategories'CommuterTransportAndFerries
        | [<JsonUnionCase("computer_network_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'ComputerNetworkServices
        | [<JsonUnionCase("computer_programming")>] IssuingCardholderAuthorizationControlsAllowedCategories'ComputerProgramming
        | [<JsonUnionCase("computer_repair")>] IssuingCardholderAuthorizationControlsAllowedCategories'ComputerRepair
        | [<JsonUnionCase("computer_software_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'ComputerSoftwareStores
        | [<JsonUnionCase("computers_peripherals_and_software")>] IssuingCardholderAuthorizationControlsAllowedCategories'ComputersPeripheralsAndSoftware
        | [<JsonUnionCase("concrete_work_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'ConcreteWorkServices
        | [<JsonUnionCase("construction_materials")>] IssuingCardholderAuthorizationControlsAllowedCategories'ConstructionMaterials
        | [<JsonUnionCase("consulting_public_relations")>] IssuingCardholderAuthorizationControlsAllowedCategories'ConsultingPublicRelations
        | [<JsonUnionCase("correspondence_schools")>] IssuingCardholderAuthorizationControlsAllowedCategories'CorrespondenceSchools
        | [<JsonUnionCase("cosmetic_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'CosmeticStores
        | [<JsonUnionCase("counseling_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'CounselingServices
        | [<JsonUnionCase("country_clubs")>] IssuingCardholderAuthorizationControlsAllowedCategories'CountryClubs
        | [<JsonUnionCase("courier_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'CourierServices
        | [<JsonUnionCase("court_costs")>] IssuingCardholderAuthorizationControlsAllowedCategories'CourtCosts
        | [<JsonUnionCase("credit_reporting_agencies")>] IssuingCardholderAuthorizationControlsAllowedCategories'CreditReportingAgencies
        | [<JsonUnionCase("cruise_lines")>] IssuingCardholderAuthorizationControlsAllowedCategories'CruiseLines
        | [<JsonUnionCase("dairy_products_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'DairyProductsStores
        | [<JsonUnionCase("dance_hall_studios_schools")>] IssuingCardholderAuthorizationControlsAllowedCategories'DanceHallStudiosSchools
        | [<JsonUnionCase("dating_escort_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'DatingEscortServices
        | [<JsonUnionCase("dentists_orthodontists")>] IssuingCardholderAuthorizationControlsAllowedCategories'DentistsOrthodontists
        | [<JsonUnionCase("department_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'DepartmentStores
        | [<JsonUnionCase("detective_agencies")>] IssuingCardholderAuthorizationControlsAllowedCategories'DetectiveAgencies
        | [<JsonUnionCase("digital_goods_applications")>] IssuingCardholderAuthorizationControlsAllowedCategories'DigitalGoodsApplications
        | [<JsonUnionCase("digital_goods_games")>] IssuingCardholderAuthorizationControlsAllowedCategories'DigitalGoodsGames
        | [<JsonUnionCase("digital_goods_large_volume")>] IssuingCardholderAuthorizationControlsAllowedCategories'DigitalGoodsLargeVolume
        | [<JsonUnionCase("digital_goods_media")>] IssuingCardholderAuthorizationControlsAllowedCategories'DigitalGoodsMedia
        | [<JsonUnionCase("direct_marketing_catalog_merchant")>] IssuingCardholderAuthorizationControlsAllowedCategories'DirectMarketingCatalogMerchant
        | [<JsonUnionCase("direct_marketing_combination_catalog_and_retail_merchant")>] IssuingCardholderAuthorizationControlsAllowedCategories'DirectMarketingCombinationCatalogAndRetailMerchant
        | [<JsonUnionCase("direct_marketing_inbound_telemarketing")>] IssuingCardholderAuthorizationControlsAllowedCategories'DirectMarketingInboundTelemarketing
        | [<JsonUnionCase("direct_marketing_insurance_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'DirectMarketingInsuranceServices
        | [<JsonUnionCase("direct_marketing_other")>] IssuingCardholderAuthorizationControlsAllowedCategories'DirectMarketingOther
        | [<JsonUnionCase("direct_marketing_outbound_telemarketing")>] IssuingCardholderAuthorizationControlsAllowedCategories'DirectMarketingOutboundTelemarketing
        | [<JsonUnionCase("direct_marketing_subscription")>] IssuingCardholderAuthorizationControlsAllowedCategories'DirectMarketingSubscription
        | [<JsonUnionCase("direct_marketing_travel")>] IssuingCardholderAuthorizationControlsAllowedCategories'DirectMarketingTravel
        | [<JsonUnionCase("discount_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'DiscountStores
        | [<JsonUnionCase("doctors")>] IssuingCardholderAuthorizationControlsAllowedCategories'Doctors
        | [<JsonUnionCase("door_to_door_sales")>] IssuingCardholderAuthorizationControlsAllowedCategories'DoorToDoorSales
        | [<JsonUnionCase("drapery_window_covering_and_upholstery_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'DraperyWindowCoveringAndUpholsteryStores
        | [<JsonUnionCase("drinking_places")>] IssuingCardholderAuthorizationControlsAllowedCategories'DrinkingPlaces
        | [<JsonUnionCase("drug_stores_and_pharmacies")>] IssuingCardholderAuthorizationControlsAllowedCategories'DrugStoresAndPharmacies
        | [<JsonUnionCase("drugs_drug_proprietaries_and_druggist_sundries")>] IssuingCardholderAuthorizationControlsAllowedCategories'DrugsDrugProprietariesAndDruggistSundries
        | [<JsonUnionCase("dry_cleaners")>] IssuingCardholderAuthorizationControlsAllowedCategories'DryCleaners
        | [<JsonUnionCase("durable_goods")>] IssuingCardholderAuthorizationControlsAllowedCategories'DurableGoods
        | [<JsonUnionCase("duty_free_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'DutyFreeStores
        | [<JsonUnionCase("eating_places_restaurants")>] IssuingCardholderAuthorizationControlsAllowedCategories'EatingPlacesRestaurants
        | [<JsonUnionCase("educational_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'EducationalServices
        | [<JsonUnionCase("electric_razor_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'ElectricRazorStores
        | [<JsonUnionCase("electrical_parts_and_equipment")>] IssuingCardholderAuthorizationControlsAllowedCategories'ElectricalPartsAndEquipment
        | [<JsonUnionCase("electrical_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'ElectricalServices
        | [<JsonUnionCase("electronics_repair_shops")>] IssuingCardholderAuthorizationControlsAllowedCategories'ElectronicsRepairShops
        | [<JsonUnionCase("electronics_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'ElectronicsStores
        | [<JsonUnionCase("elementary_secondary_schools")>] IssuingCardholderAuthorizationControlsAllowedCategories'ElementarySecondarySchools
        | [<JsonUnionCase("employment_temp_agencies")>] IssuingCardholderAuthorizationControlsAllowedCategories'EmploymentTempAgencies
        | [<JsonUnionCase("equipment_rental")>] IssuingCardholderAuthorizationControlsAllowedCategories'EquipmentRental
        | [<JsonUnionCase("exterminating_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'ExterminatingServices
        | [<JsonUnionCase("family_clothing_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'FamilyClothingStores
        | [<JsonUnionCase("fast_food_restaurants")>] IssuingCardholderAuthorizationControlsAllowedCategories'FastFoodRestaurants
        | [<JsonUnionCase("financial_institutions")>] IssuingCardholderAuthorizationControlsAllowedCategories'FinancialInstitutions
        | [<JsonUnionCase("fines_government_administrative_entities")>] IssuingCardholderAuthorizationControlsAllowedCategories'FinesGovernmentAdministrativeEntities
        | [<JsonUnionCase("fireplace_fireplace_screens_and_accessories_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'FireplaceFireplaceScreensAndAccessoriesStores
        | [<JsonUnionCase("floor_covering_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'FloorCoveringStores
        | [<JsonUnionCase("florists")>] IssuingCardholderAuthorizationControlsAllowedCategories'Florists
        | [<JsonUnionCase("florists_supplies_nursery_stock_and_flowers")>] IssuingCardholderAuthorizationControlsAllowedCategories'FloristsSuppliesNurseryStockAndFlowers
        | [<JsonUnionCase("freezer_and_locker_meat_provisioners")>] IssuingCardholderAuthorizationControlsAllowedCategories'FreezerAndLockerMeatProvisioners
        | [<JsonUnionCase("fuel_dealers_non_automotive")>] IssuingCardholderAuthorizationControlsAllowedCategories'FuelDealersNonAutomotive
        | [<JsonUnionCase("funeral_services_crematories")>] IssuingCardholderAuthorizationControlsAllowedCategories'FuneralServicesCrematories
        | [<JsonUnionCase("furniture_home_furnishings_and_equipment_stores_except_appliances")>] IssuingCardholderAuthorizationControlsAllowedCategories'FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | [<JsonUnionCase("furniture_repair_refinishing")>] IssuingCardholderAuthorizationControlsAllowedCategories'FurnitureRepairRefinishing
        | [<JsonUnionCase("furriers_and_fur_shops")>] IssuingCardholderAuthorizationControlsAllowedCategories'FurriersAndFurShops
        | [<JsonUnionCase("general_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'GeneralServices
        | [<JsonUnionCase("gift_card_novelty_and_souvenir_shops")>] IssuingCardholderAuthorizationControlsAllowedCategories'GiftCardNoveltyAndSouvenirShops
        | [<JsonUnionCase("glass_paint_and_wallpaper_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'GlassPaintAndWallpaperStores
        | [<JsonUnionCase("glassware_crystal_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'GlasswareCrystalStores
        | [<JsonUnionCase("golf_courses_public")>] IssuingCardholderAuthorizationControlsAllowedCategories'GolfCoursesPublic
        | [<JsonUnionCase("government_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'GovernmentServices
        | [<JsonUnionCase("grocery_stores_supermarkets")>] IssuingCardholderAuthorizationControlsAllowedCategories'GroceryStoresSupermarkets
        | [<JsonUnionCase("hardware_equipment_and_supplies")>] IssuingCardholderAuthorizationControlsAllowedCategories'HardwareEquipmentAndSupplies
        | [<JsonUnionCase("hardware_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'HardwareStores
        | [<JsonUnionCase("health_and_beauty_spas")>] IssuingCardholderAuthorizationControlsAllowedCategories'HealthAndBeautySpas
        | [<JsonUnionCase("hearing_aids_sales_and_supplies")>] IssuingCardholderAuthorizationControlsAllowedCategories'HearingAidsSalesAndSupplies
        | [<JsonUnionCase("heating_plumbing_a_c")>] IssuingCardholderAuthorizationControlsAllowedCategories'HeatingPlumbingAC
        | [<JsonUnionCase("hobby_toy_and_game_shops")>] IssuingCardholderAuthorizationControlsAllowedCategories'HobbyToyAndGameShops
        | [<JsonUnionCase("home_supply_warehouse_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'HomeSupplyWarehouseStores
        | [<JsonUnionCase("hospitals")>] IssuingCardholderAuthorizationControlsAllowedCategories'Hospitals
        | [<JsonUnionCase("hotels_motels_and_resorts")>] IssuingCardholderAuthorizationControlsAllowedCategories'HotelsMotelsAndResorts
        | [<JsonUnionCase("household_appliance_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'HouseholdApplianceStores
        | [<JsonUnionCase("industrial_supplies")>] IssuingCardholderAuthorizationControlsAllowedCategories'IndustrialSupplies
        | [<JsonUnionCase("information_retrieval_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'InformationRetrievalServices
        | [<JsonUnionCase("insurance_default")>] IssuingCardholderAuthorizationControlsAllowedCategories'InsuranceDefault
        | [<JsonUnionCase("insurance_underwriting_premiums")>] IssuingCardholderAuthorizationControlsAllowedCategories'InsuranceUnderwritingPremiums
        | [<JsonUnionCase("intra_company_purchases")>] IssuingCardholderAuthorizationControlsAllowedCategories'IntraCompanyPurchases
        | [<JsonUnionCase("jewelry_stores_watches_clocks_and_silverware_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'JewelryStoresWatchesClocksAndSilverwareStores
        | [<JsonUnionCase("landscaping_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'LandscapingServices
        | [<JsonUnionCase("laundries")>] IssuingCardholderAuthorizationControlsAllowedCategories'Laundries
        | [<JsonUnionCase("laundry_cleaning_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'LaundryCleaningServices
        | [<JsonUnionCase("legal_services_attorneys")>] IssuingCardholderAuthorizationControlsAllowedCategories'LegalServicesAttorneys
        | [<JsonUnionCase("luggage_and_leather_goods_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'LuggageAndLeatherGoodsStores
        | [<JsonUnionCase("lumber_building_materials_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'LumberBuildingMaterialsStores
        | [<JsonUnionCase("manual_cash_disburse")>] IssuingCardholderAuthorizationControlsAllowedCategories'ManualCashDisburse
        | [<JsonUnionCase("marinas_service_and_supplies")>] IssuingCardholderAuthorizationControlsAllowedCategories'MarinasServiceAndSupplies
        | [<JsonUnionCase("masonry_stonework_and_plaster")>] IssuingCardholderAuthorizationControlsAllowedCategories'MasonryStoneworkAndPlaster
        | [<JsonUnionCase("massage_parlors")>] IssuingCardholderAuthorizationControlsAllowedCategories'MassageParlors
        | [<JsonUnionCase("medical_and_dental_labs")>] IssuingCardholderAuthorizationControlsAllowedCategories'MedicalAndDentalLabs
        | [<JsonUnionCase("medical_dental_ophthalmic_and_hospital_equipment_and_supplies")>] IssuingCardholderAuthorizationControlsAllowedCategories'MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | [<JsonUnionCase("medical_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'MedicalServices
        | [<JsonUnionCase("membership_organizations")>] IssuingCardholderAuthorizationControlsAllowedCategories'MembershipOrganizations
        | [<JsonUnionCase("mens_and_boys_clothing_and_accessories_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'MensAndBoysClothingAndAccessoriesStores
        | [<JsonUnionCase("mens_womens_clothing_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'MensWomensClothingStores
        | [<JsonUnionCase("metal_service_centers")>] IssuingCardholderAuthorizationControlsAllowedCategories'MetalServiceCenters
        | [<JsonUnionCase("miscellaneous")>] IssuingCardholderAuthorizationControlsAllowedCategories'Miscellaneous
        | [<JsonUnionCase("miscellaneous_apparel_and_accessory_shops")>] IssuingCardholderAuthorizationControlsAllowedCategories'MiscellaneousApparelAndAccessoryShops
        | [<JsonUnionCase("miscellaneous_auto_dealers")>] IssuingCardholderAuthorizationControlsAllowedCategories'MiscellaneousAutoDealers
        | [<JsonUnionCase("miscellaneous_business_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'MiscellaneousBusinessServices
        | [<JsonUnionCase("miscellaneous_food_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'MiscellaneousFoodStores
        | [<JsonUnionCase("miscellaneous_general_merchandise")>] IssuingCardholderAuthorizationControlsAllowedCategories'MiscellaneousGeneralMerchandise
        | [<JsonUnionCase("miscellaneous_general_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'MiscellaneousGeneralServices
        | [<JsonUnionCase("miscellaneous_home_furnishing_specialty_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'MiscellaneousHomeFurnishingSpecialtyStores
        | [<JsonUnionCase("miscellaneous_publishing_and_printing")>] IssuingCardholderAuthorizationControlsAllowedCategories'MiscellaneousPublishingAndPrinting
        | [<JsonUnionCase("miscellaneous_recreation_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'MiscellaneousRecreationServices
        | [<JsonUnionCase("miscellaneous_repair_shops")>] IssuingCardholderAuthorizationControlsAllowedCategories'MiscellaneousRepairShops
        | [<JsonUnionCase("miscellaneous_specialty_retail")>] IssuingCardholderAuthorizationControlsAllowedCategories'MiscellaneousSpecialtyRetail
        | [<JsonUnionCase("mobile_home_dealers")>] IssuingCardholderAuthorizationControlsAllowedCategories'MobileHomeDealers
        | [<JsonUnionCase("motion_picture_theaters")>] IssuingCardholderAuthorizationControlsAllowedCategories'MotionPictureTheaters
        | [<JsonUnionCase("motor_freight_carriers_and_trucking")>] IssuingCardholderAuthorizationControlsAllowedCategories'MotorFreightCarriersAndTrucking
        | [<JsonUnionCase("motor_homes_dealers")>] IssuingCardholderAuthorizationControlsAllowedCategories'MotorHomesDealers
        | [<JsonUnionCase("motor_vehicle_supplies_and_new_parts")>] IssuingCardholderAuthorizationControlsAllowedCategories'MotorVehicleSuppliesAndNewParts
        | [<JsonUnionCase("motorcycle_shops_and_dealers")>] IssuingCardholderAuthorizationControlsAllowedCategories'MotorcycleShopsAndDealers
        | [<JsonUnionCase("motorcycle_shops_dealers")>] IssuingCardholderAuthorizationControlsAllowedCategories'MotorcycleShopsDealers
        | [<JsonUnionCase("music_stores_musical_instruments_pianos_and_sheet_music")>] IssuingCardholderAuthorizationControlsAllowedCategories'MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | [<JsonUnionCase("news_dealers_and_newsstands")>] IssuingCardholderAuthorizationControlsAllowedCategories'NewsDealersAndNewsstands
        | [<JsonUnionCase("non_fi_money_orders")>] IssuingCardholderAuthorizationControlsAllowedCategories'NonFiMoneyOrders
        | [<JsonUnionCase("non_fi_stored_value_card_purchase_load")>] IssuingCardholderAuthorizationControlsAllowedCategories'NonFiStoredValueCardPurchaseLoad
        | [<JsonUnionCase("nondurable_goods")>] IssuingCardholderAuthorizationControlsAllowedCategories'NondurableGoods
        | [<JsonUnionCase("nurseries_lawn_and_garden_supply_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'NurseriesLawnAndGardenSupplyStores
        | [<JsonUnionCase("nursing_personal_care")>] IssuingCardholderAuthorizationControlsAllowedCategories'NursingPersonalCare
        | [<JsonUnionCase("office_and_commercial_furniture")>] IssuingCardholderAuthorizationControlsAllowedCategories'OfficeAndCommercialFurniture
        | [<JsonUnionCase("opticians_eyeglasses")>] IssuingCardholderAuthorizationControlsAllowedCategories'OpticiansEyeglasses
        | [<JsonUnionCase("optometrists_ophthalmologist")>] IssuingCardholderAuthorizationControlsAllowedCategories'OptometristsOphthalmologist
        | [<JsonUnionCase("orthopedic_goods_prosthetic_devices")>] IssuingCardholderAuthorizationControlsAllowedCategories'OrthopedicGoodsProstheticDevices
        | [<JsonUnionCase("osteopaths")>] IssuingCardholderAuthorizationControlsAllowedCategories'Osteopaths
        | [<JsonUnionCase("package_stores_beer_wine_and_liquor")>] IssuingCardholderAuthorizationControlsAllowedCategories'PackageStoresBeerWineAndLiquor
        | [<JsonUnionCase("paints_varnishes_and_supplies")>] IssuingCardholderAuthorizationControlsAllowedCategories'PaintsVarnishesAndSupplies
        | [<JsonUnionCase("parking_lots_garages")>] IssuingCardholderAuthorizationControlsAllowedCategories'ParkingLotsGarages
        | [<JsonUnionCase("passenger_railways")>] IssuingCardholderAuthorizationControlsAllowedCategories'PassengerRailways
        | [<JsonUnionCase("pawn_shops")>] IssuingCardholderAuthorizationControlsAllowedCategories'PawnShops
        | [<JsonUnionCase("pet_shops_pet_food_and_supplies")>] IssuingCardholderAuthorizationControlsAllowedCategories'PetShopsPetFoodAndSupplies
        | [<JsonUnionCase("petroleum_and_petroleum_products")>] IssuingCardholderAuthorizationControlsAllowedCategories'PetroleumAndPetroleumProducts
        | [<JsonUnionCase("photo_developing")>] IssuingCardholderAuthorizationControlsAllowedCategories'PhotoDeveloping
        | [<JsonUnionCase("photographic_photocopy_microfilm_equipment_and_supplies")>] IssuingCardholderAuthorizationControlsAllowedCategories'PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | [<JsonUnionCase("photographic_studios")>] IssuingCardholderAuthorizationControlsAllowedCategories'PhotographicStudios
        | [<JsonUnionCase("picture_video_production")>] IssuingCardholderAuthorizationControlsAllowedCategories'PictureVideoProduction
        | [<JsonUnionCase("piece_goods_notions_and_other_dry_goods")>] IssuingCardholderAuthorizationControlsAllowedCategories'PieceGoodsNotionsAndOtherDryGoods
        | [<JsonUnionCase("plumbing_heating_equipment_and_supplies")>] IssuingCardholderAuthorizationControlsAllowedCategories'PlumbingHeatingEquipmentAndSupplies
        | [<JsonUnionCase("political_organizations")>] IssuingCardholderAuthorizationControlsAllowedCategories'PoliticalOrganizations
        | [<JsonUnionCase("postal_services_government_only")>] IssuingCardholderAuthorizationControlsAllowedCategories'PostalServicesGovernmentOnly
        | [<JsonUnionCase("precious_stones_and_metals_watches_and_jewelry")>] IssuingCardholderAuthorizationControlsAllowedCategories'PreciousStonesAndMetalsWatchesAndJewelry
        | [<JsonUnionCase("professional_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'ProfessionalServices
        | [<JsonUnionCase("public_warehousing_and_storage")>] IssuingCardholderAuthorizationControlsAllowedCategories'PublicWarehousingAndStorage
        | [<JsonUnionCase("quick_copy_repro_and_blueprint")>] IssuingCardholderAuthorizationControlsAllowedCategories'QuickCopyReproAndBlueprint
        | [<JsonUnionCase("railroads")>] IssuingCardholderAuthorizationControlsAllowedCategories'Railroads
        | [<JsonUnionCase("real_estate_agents_and_managers_rentals")>] IssuingCardholderAuthorizationControlsAllowedCategories'RealEstateAgentsAndManagersRentals
        | [<JsonUnionCase("record_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'RecordStores
        | [<JsonUnionCase("recreational_vehicle_rentals")>] IssuingCardholderAuthorizationControlsAllowedCategories'RecreationalVehicleRentals
        | [<JsonUnionCase("religious_goods_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'ReligiousGoodsStores
        | [<JsonUnionCase("religious_organizations")>] IssuingCardholderAuthorizationControlsAllowedCategories'ReligiousOrganizations
        | [<JsonUnionCase("roofing_siding_sheet_metal")>] IssuingCardholderAuthorizationControlsAllowedCategories'RoofingSidingSheetMetal
        | [<JsonUnionCase("secretarial_support_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'SecretarialSupportServices
        | [<JsonUnionCase("security_brokers_dealers")>] IssuingCardholderAuthorizationControlsAllowedCategories'SecurityBrokersDealers
        | [<JsonUnionCase("service_stations")>] IssuingCardholderAuthorizationControlsAllowedCategories'ServiceStations
        | [<JsonUnionCase("sewing_needlework_fabric_and_piece_goods_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'SewingNeedleworkFabricAndPieceGoodsStores
        | [<JsonUnionCase("shoe_repair_hat_cleaning")>] IssuingCardholderAuthorizationControlsAllowedCategories'ShoeRepairHatCleaning
        | [<JsonUnionCase("shoe_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'ShoeStores
        | [<JsonUnionCase("small_appliance_repair")>] IssuingCardholderAuthorizationControlsAllowedCategories'SmallApplianceRepair
        | [<JsonUnionCase("snowmobile_dealers")>] IssuingCardholderAuthorizationControlsAllowedCategories'SnowmobileDealers
        | [<JsonUnionCase("special_trade_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'SpecialTradeServices
        | [<JsonUnionCase("specialty_cleaning")>] IssuingCardholderAuthorizationControlsAllowedCategories'SpecialtyCleaning
        | [<JsonUnionCase("sporting_goods_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'SportingGoodsStores
        | [<JsonUnionCase("sporting_recreation_camps")>] IssuingCardholderAuthorizationControlsAllowedCategories'SportingRecreationCamps
        | [<JsonUnionCase("sports_and_riding_apparel_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'SportsAndRidingApparelStores
        | [<JsonUnionCase("sports_clubs_fields")>] IssuingCardholderAuthorizationControlsAllowedCategories'SportsClubsFields
        | [<JsonUnionCase("stamp_and_coin_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'StampAndCoinStores
        | [<JsonUnionCase("stationary_office_supplies_printing_and_writing_paper")>] IssuingCardholderAuthorizationControlsAllowedCategories'StationaryOfficeSuppliesPrintingAndWritingPaper
        | [<JsonUnionCase("stationery_stores_office_and_school_supply_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'StationeryStoresOfficeAndSchoolSupplyStores
        | [<JsonUnionCase("swimming_pools_sales")>] IssuingCardholderAuthorizationControlsAllowedCategories'SwimmingPoolsSales
        | [<JsonUnionCase("t_ui_travel_germany")>] IssuingCardholderAuthorizationControlsAllowedCategories'TUiTravelGermany
        | [<JsonUnionCase("tailors_alterations")>] IssuingCardholderAuthorizationControlsAllowedCategories'TailorsAlterations
        | [<JsonUnionCase("tax_payments_government_agencies")>] IssuingCardholderAuthorizationControlsAllowedCategories'TaxPaymentsGovernmentAgencies
        | [<JsonUnionCase("tax_preparation_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'TaxPreparationServices
        | [<JsonUnionCase("taxicabs_limousines")>] IssuingCardholderAuthorizationControlsAllowedCategories'TaxicabsLimousines
        | [<JsonUnionCase("telecommunication_equipment_and_telephone_sales")>] IssuingCardholderAuthorizationControlsAllowedCategories'TelecommunicationEquipmentAndTelephoneSales
        | [<JsonUnionCase("telecommunication_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'TelecommunicationServices
        | [<JsonUnionCase("telegraph_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'TelegraphServices
        | [<JsonUnionCase("tent_and_awning_shops")>] IssuingCardholderAuthorizationControlsAllowedCategories'TentAndAwningShops
        | [<JsonUnionCase("testing_laboratories")>] IssuingCardholderAuthorizationControlsAllowedCategories'TestingLaboratories
        | [<JsonUnionCase("theatrical_ticket_agencies")>] IssuingCardholderAuthorizationControlsAllowedCategories'TheatricalTicketAgencies
        | [<JsonUnionCase("timeshares")>] IssuingCardholderAuthorizationControlsAllowedCategories'Timeshares
        | [<JsonUnionCase("tire_retreading_and_repair")>] IssuingCardholderAuthorizationControlsAllowedCategories'TireRetreadingAndRepair
        | [<JsonUnionCase("tolls_bridge_fees")>] IssuingCardholderAuthorizationControlsAllowedCategories'TollsBridgeFees
        | [<JsonUnionCase("tourist_attractions_and_exhibits")>] IssuingCardholderAuthorizationControlsAllowedCategories'TouristAttractionsAndExhibits
        | [<JsonUnionCase("towing_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'TowingServices
        | [<JsonUnionCase("trailer_parks_campgrounds")>] IssuingCardholderAuthorizationControlsAllowedCategories'TrailerParksCampgrounds
        | [<JsonUnionCase("transportation_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'TransportationServices
        | [<JsonUnionCase("travel_agencies_tour_operators")>] IssuingCardholderAuthorizationControlsAllowedCategories'TravelAgenciesTourOperators
        | [<JsonUnionCase("truck_stop_iteration")>] IssuingCardholderAuthorizationControlsAllowedCategories'TruckStopIteration
        | [<JsonUnionCase("truck_utility_trailer_rentals")>] IssuingCardholderAuthorizationControlsAllowedCategories'TruckUtilityTrailerRentals
        | [<JsonUnionCase("typesetting_plate_making_and_related_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'TypesettingPlateMakingAndRelatedServices
        | [<JsonUnionCase("typewriter_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'TypewriterStores
        | [<JsonUnionCase("u_s_federal_government_agencies_or_departments")>] IssuingCardholderAuthorizationControlsAllowedCategories'USFederalGovernmentAgenciesOrDepartments
        | [<JsonUnionCase("uniforms_commercial_clothing")>] IssuingCardholderAuthorizationControlsAllowedCategories'UniformsCommercialClothing
        | [<JsonUnionCase("used_merchandise_and_secondhand_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'UsedMerchandiseAndSecondhandStores
        | [<JsonUnionCase("utilities")>] IssuingCardholderAuthorizationControlsAllowedCategories'Utilities
        | [<JsonUnionCase("variety_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'VarietyStores
        | [<JsonUnionCase("veterinary_services")>] IssuingCardholderAuthorizationControlsAllowedCategories'VeterinaryServices
        | [<JsonUnionCase("video_amusement_game_supplies")>] IssuingCardholderAuthorizationControlsAllowedCategories'VideoAmusementGameSupplies
        | [<JsonUnionCase("video_game_arcades")>] IssuingCardholderAuthorizationControlsAllowedCategories'VideoGameArcades
        | [<JsonUnionCase("video_tape_rental_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'VideoTapeRentalStores
        | [<JsonUnionCase("vocational_trade_schools")>] IssuingCardholderAuthorizationControlsAllowedCategories'VocationalTradeSchools
        | [<JsonUnionCase("watch_jewelry_repair")>] IssuingCardholderAuthorizationControlsAllowedCategories'WatchJewelryRepair
        | [<JsonUnionCase("welding_repair")>] IssuingCardholderAuthorizationControlsAllowedCategories'WeldingRepair
        | [<JsonUnionCase("wholesale_clubs")>] IssuingCardholderAuthorizationControlsAllowedCategories'WholesaleClubs
        | [<JsonUnionCase("wig_and_toupee_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'WigAndToupeeStores
        | [<JsonUnionCase("wires_money_orders")>] IssuingCardholderAuthorizationControlsAllowedCategories'WiresMoneyOrders
        | [<JsonUnionCase("womens_accessory_and_specialty_shops")>] IssuingCardholderAuthorizationControlsAllowedCategories'WomensAccessoryAndSpecialtyShops
        | [<JsonUnionCase("womens_ready_to_wear_stores")>] IssuingCardholderAuthorizationControlsAllowedCategories'WomensReadyToWearStores
        | [<JsonUnionCase("wrecking_and_salvage_yards")>] IssuingCardholderAuthorizationControlsAllowedCategories'WreckingAndSalvageYards

    and IssuingCardholderAuthorizationControlsBlockedCategories =
        | [<JsonUnionCase("ac_refrigeration_repair")>] IssuingCardholderAuthorizationControlsBlockedCategories'AcRefrigerationRepair
        | [<JsonUnionCase("accounting_bookkeeping_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'AccountingBookkeepingServices
        | [<JsonUnionCase("advertising_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'AdvertisingServices
        | [<JsonUnionCase("agricultural_cooperative")>] IssuingCardholderAuthorizationControlsBlockedCategories'AgriculturalCooperative
        | [<JsonUnionCase("airlines_air_carriers")>] IssuingCardholderAuthorizationControlsBlockedCategories'AirlinesAirCarriers
        | [<JsonUnionCase("airports_flying_fields")>] IssuingCardholderAuthorizationControlsBlockedCategories'AirportsFlyingFields
        | [<JsonUnionCase("ambulance_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'AmbulanceServices
        | [<JsonUnionCase("amusement_parks_carnivals")>] IssuingCardholderAuthorizationControlsBlockedCategories'AmusementParksCarnivals
        | [<JsonUnionCase("antique_reproductions")>] IssuingCardholderAuthorizationControlsBlockedCategories'AntiqueReproductions
        | [<JsonUnionCase("antique_shops")>] IssuingCardholderAuthorizationControlsBlockedCategories'AntiqueShops
        | [<JsonUnionCase("aquariums")>] IssuingCardholderAuthorizationControlsBlockedCategories'Aquariums
        | [<JsonUnionCase("architectural_surveying_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'ArchitecturalSurveyingServices
        | [<JsonUnionCase("art_dealers_and_galleries")>] IssuingCardholderAuthorizationControlsBlockedCategories'ArtDealersAndGalleries
        | [<JsonUnionCase("artists_supply_and_craft_shops")>] IssuingCardholderAuthorizationControlsBlockedCategories'ArtistsSupplyAndCraftShops
        | [<JsonUnionCase("auto_and_home_supply_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'AutoAndHomeSupplyStores
        | [<JsonUnionCase("auto_body_repair_shops")>] IssuingCardholderAuthorizationControlsBlockedCategories'AutoBodyRepairShops
        | [<JsonUnionCase("auto_paint_shops")>] IssuingCardholderAuthorizationControlsBlockedCategories'AutoPaintShops
        | [<JsonUnionCase("auto_service_shops")>] IssuingCardholderAuthorizationControlsBlockedCategories'AutoServiceShops
        | [<JsonUnionCase("automated_cash_disburse")>] IssuingCardholderAuthorizationControlsBlockedCategories'AutomatedCashDisburse
        | [<JsonUnionCase("automated_fuel_dispensers")>] IssuingCardholderAuthorizationControlsBlockedCategories'AutomatedFuelDispensers
        | [<JsonUnionCase("automobile_associations")>] IssuingCardholderAuthorizationControlsBlockedCategories'AutomobileAssociations
        | [<JsonUnionCase("automotive_parts_and_accessories_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'AutomotivePartsAndAccessoriesStores
        | [<JsonUnionCase("automotive_tire_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'AutomotiveTireStores
        | [<JsonUnionCase("bail_and_bond_payments")>] IssuingCardholderAuthorizationControlsBlockedCategories'BailAndBondPayments
        | [<JsonUnionCase("bakeries")>] IssuingCardholderAuthorizationControlsBlockedCategories'Bakeries
        | [<JsonUnionCase("bands_orchestras")>] IssuingCardholderAuthorizationControlsBlockedCategories'BandsOrchestras
        | [<JsonUnionCase("barber_and_beauty_shops")>] IssuingCardholderAuthorizationControlsBlockedCategories'BarberAndBeautyShops
        | [<JsonUnionCase("betting_casino_gambling")>] IssuingCardholderAuthorizationControlsBlockedCategories'BettingCasinoGambling
        | [<JsonUnionCase("bicycle_shops")>] IssuingCardholderAuthorizationControlsBlockedCategories'BicycleShops
        | [<JsonUnionCase("billiard_pool_establishments")>] IssuingCardholderAuthorizationControlsBlockedCategories'BilliardPoolEstablishments
        | [<JsonUnionCase("boat_dealers")>] IssuingCardholderAuthorizationControlsBlockedCategories'BoatDealers
        | [<JsonUnionCase("boat_rentals_and_leases")>] IssuingCardholderAuthorizationControlsBlockedCategories'BoatRentalsAndLeases
        | [<JsonUnionCase("book_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'BookStores
        | [<JsonUnionCase("books_periodicals_and_newspapers")>] IssuingCardholderAuthorizationControlsBlockedCategories'BooksPeriodicalsAndNewspapers
        | [<JsonUnionCase("bowling_alleys")>] IssuingCardholderAuthorizationControlsBlockedCategories'BowlingAlleys
        | [<JsonUnionCase("bus_lines")>] IssuingCardholderAuthorizationControlsBlockedCategories'BusLines
        | [<JsonUnionCase("business_secretarial_schools")>] IssuingCardholderAuthorizationControlsBlockedCategories'BusinessSecretarialSchools
        | [<JsonUnionCase("buying_shopping_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'BuyingShoppingServices
        | [<JsonUnionCase("cable_satellite_and_other_pay_television_and_radio")>] IssuingCardholderAuthorizationControlsBlockedCategories'CableSatelliteAndOtherPayTelevisionAndRadio
        | [<JsonUnionCase("camera_and_photographic_supply_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'CameraAndPhotographicSupplyStores
        | [<JsonUnionCase("candy_nut_and_confectionery_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'CandyNutAndConfectioneryStores
        | [<JsonUnionCase("car_and_truck_dealers_new_used")>] IssuingCardholderAuthorizationControlsBlockedCategories'CarAndTruckDealersNewUsed
        | [<JsonUnionCase("car_and_truck_dealers_used_only")>] IssuingCardholderAuthorizationControlsBlockedCategories'CarAndTruckDealersUsedOnly
        | [<JsonUnionCase("car_rental_agencies")>] IssuingCardholderAuthorizationControlsBlockedCategories'CarRentalAgencies
        | [<JsonUnionCase("car_washes")>] IssuingCardholderAuthorizationControlsBlockedCategories'CarWashes
        | [<JsonUnionCase("carpentry_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'CarpentryServices
        | [<JsonUnionCase("carpet_upholstery_cleaning")>] IssuingCardholderAuthorizationControlsBlockedCategories'CarpetUpholsteryCleaning
        | [<JsonUnionCase("caterers")>] IssuingCardholderAuthorizationControlsBlockedCategories'Caterers
        | [<JsonUnionCase("charitable_and_social_service_organizations_fundraising")>] IssuingCardholderAuthorizationControlsBlockedCategories'CharitableAndSocialServiceOrganizationsFundraising
        | [<JsonUnionCase("chemicals_and_allied_products")>] IssuingCardholderAuthorizationControlsBlockedCategories'ChemicalsAndAlliedProducts
        | [<JsonUnionCase("child_care_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'ChildCareServices
        | [<JsonUnionCase("childrens_and_infants_wear_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'ChildrensAndInfantsWearStores
        | [<JsonUnionCase("chiropodists_podiatrists")>] IssuingCardholderAuthorizationControlsBlockedCategories'ChiropodistsPodiatrists
        | [<JsonUnionCase("chiropractors")>] IssuingCardholderAuthorizationControlsBlockedCategories'Chiropractors
        | [<JsonUnionCase("cigar_stores_and_stands")>] IssuingCardholderAuthorizationControlsBlockedCategories'CigarStoresAndStands
        | [<JsonUnionCase("civic_social_fraternal_associations")>] IssuingCardholderAuthorizationControlsBlockedCategories'CivicSocialFraternalAssociations
        | [<JsonUnionCase("cleaning_and_maintenance")>] IssuingCardholderAuthorizationControlsBlockedCategories'CleaningAndMaintenance
        | [<JsonUnionCase("clothing_rental")>] IssuingCardholderAuthorizationControlsBlockedCategories'ClothingRental
        | [<JsonUnionCase("colleges_universities")>] IssuingCardholderAuthorizationControlsBlockedCategories'CollegesUniversities
        | [<JsonUnionCase("commercial_equipment")>] IssuingCardholderAuthorizationControlsBlockedCategories'CommercialEquipment
        | [<JsonUnionCase("commercial_footwear")>] IssuingCardholderAuthorizationControlsBlockedCategories'CommercialFootwear
        | [<JsonUnionCase("commercial_photography_art_and_graphics")>] IssuingCardholderAuthorizationControlsBlockedCategories'CommercialPhotographyArtAndGraphics
        | [<JsonUnionCase("commuter_transport_and_ferries")>] IssuingCardholderAuthorizationControlsBlockedCategories'CommuterTransportAndFerries
        | [<JsonUnionCase("computer_network_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'ComputerNetworkServices
        | [<JsonUnionCase("computer_programming")>] IssuingCardholderAuthorizationControlsBlockedCategories'ComputerProgramming
        | [<JsonUnionCase("computer_repair")>] IssuingCardholderAuthorizationControlsBlockedCategories'ComputerRepair
        | [<JsonUnionCase("computer_software_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'ComputerSoftwareStores
        | [<JsonUnionCase("computers_peripherals_and_software")>] IssuingCardholderAuthorizationControlsBlockedCategories'ComputersPeripheralsAndSoftware
        | [<JsonUnionCase("concrete_work_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'ConcreteWorkServices
        | [<JsonUnionCase("construction_materials")>] IssuingCardholderAuthorizationControlsBlockedCategories'ConstructionMaterials
        | [<JsonUnionCase("consulting_public_relations")>] IssuingCardholderAuthorizationControlsBlockedCategories'ConsultingPublicRelations
        | [<JsonUnionCase("correspondence_schools")>] IssuingCardholderAuthorizationControlsBlockedCategories'CorrespondenceSchools
        | [<JsonUnionCase("cosmetic_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'CosmeticStores
        | [<JsonUnionCase("counseling_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'CounselingServices
        | [<JsonUnionCase("country_clubs")>] IssuingCardholderAuthorizationControlsBlockedCategories'CountryClubs
        | [<JsonUnionCase("courier_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'CourierServices
        | [<JsonUnionCase("court_costs")>] IssuingCardholderAuthorizationControlsBlockedCategories'CourtCosts
        | [<JsonUnionCase("credit_reporting_agencies")>] IssuingCardholderAuthorizationControlsBlockedCategories'CreditReportingAgencies
        | [<JsonUnionCase("cruise_lines")>] IssuingCardholderAuthorizationControlsBlockedCategories'CruiseLines
        | [<JsonUnionCase("dairy_products_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'DairyProductsStores
        | [<JsonUnionCase("dance_hall_studios_schools")>] IssuingCardholderAuthorizationControlsBlockedCategories'DanceHallStudiosSchools
        | [<JsonUnionCase("dating_escort_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'DatingEscortServices
        | [<JsonUnionCase("dentists_orthodontists")>] IssuingCardholderAuthorizationControlsBlockedCategories'DentistsOrthodontists
        | [<JsonUnionCase("department_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'DepartmentStores
        | [<JsonUnionCase("detective_agencies")>] IssuingCardholderAuthorizationControlsBlockedCategories'DetectiveAgencies
        | [<JsonUnionCase("digital_goods_applications")>] IssuingCardholderAuthorizationControlsBlockedCategories'DigitalGoodsApplications
        | [<JsonUnionCase("digital_goods_games")>] IssuingCardholderAuthorizationControlsBlockedCategories'DigitalGoodsGames
        | [<JsonUnionCase("digital_goods_large_volume")>] IssuingCardholderAuthorizationControlsBlockedCategories'DigitalGoodsLargeVolume
        | [<JsonUnionCase("digital_goods_media")>] IssuingCardholderAuthorizationControlsBlockedCategories'DigitalGoodsMedia
        | [<JsonUnionCase("direct_marketing_catalog_merchant")>] IssuingCardholderAuthorizationControlsBlockedCategories'DirectMarketingCatalogMerchant
        | [<JsonUnionCase("direct_marketing_combination_catalog_and_retail_merchant")>] IssuingCardholderAuthorizationControlsBlockedCategories'DirectMarketingCombinationCatalogAndRetailMerchant
        | [<JsonUnionCase("direct_marketing_inbound_telemarketing")>] IssuingCardholderAuthorizationControlsBlockedCategories'DirectMarketingInboundTelemarketing
        | [<JsonUnionCase("direct_marketing_insurance_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'DirectMarketingInsuranceServices
        | [<JsonUnionCase("direct_marketing_other")>] IssuingCardholderAuthorizationControlsBlockedCategories'DirectMarketingOther
        | [<JsonUnionCase("direct_marketing_outbound_telemarketing")>] IssuingCardholderAuthorizationControlsBlockedCategories'DirectMarketingOutboundTelemarketing
        | [<JsonUnionCase("direct_marketing_subscription")>] IssuingCardholderAuthorizationControlsBlockedCategories'DirectMarketingSubscription
        | [<JsonUnionCase("direct_marketing_travel")>] IssuingCardholderAuthorizationControlsBlockedCategories'DirectMarketingTravel
        | [<JsonUnionCase("discount_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'DiscountStores
        | [<JsonUnionCase("doctors")>] IssuingCardholderAuthorizationControlsBlockedCategories'Doctors
        | [<JsonUnionCase("door_to_door_sales")>] IssuingCardholderAuthorizationControlsBlockedCategories'DoorToDoorSales
        | [<JsonUnionCase("drapery_window_covering_and_upholstery_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'DraperyWindowCoveringAndUpholsteryStores
        | [<JsonUnionCase("drinking_places")>] IssuingCardholderAuthorizationControlsBlockedCategories'DrinkingPlaces
        | [<JsonUnionCase("drug_stores_and_pharmacies")>] IssuingCardholderAuthorizationControlsBlockedCategories'DrugStoresAndPharmacies
        | [<JsonUnionCase("drugs_drug_proprietaries_and_druggist_sundries")>] IssuingCardholderAuthorizationControlsBlockedCategories'DrugsDrugProprietariesAndDruggistSundries
        | [<JsonUnionCase("dry_cleaners")>] IssuingCardholderAuthorizationControlsBlockedCategories'DryCleaners
        | [<JsonUnionCase("durable_goods")>] IssuingCardholderAuthorizationControlsBlockedCategories'DurableGoods
        | [<JsonUnionCase("duty_free_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'DutyFreeStores
        | [<JsonUnionCase("eating_places_restaurants")>] IssuingCardholderAuthorizationControlsBlockedCategories'EatingPlacesRestaurants
        | [<JsonUnionCase("educational_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'EducationalServices
        | [<JsonUnionCase("electric_razor_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'ElectricRazorStores
        | [<JsonUnionCase("electrical_parts_and_equipment")>] IssuingCardholderAuthorizationControlsBlockedCategories'ElectricalPartsAndEquipment
        | [<JsonUnionCase("electrical_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'ElectricalServices
        | [<JsonUnionCase("electronics_repair_shops")>] IssuingCardholderAuthorizationControlsBlockedCategories'ElectronicsRepairShops
        | [<JsonUnionCase("electronics_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'ElectronicsStores
        | [<JsonUnionCase("elementary_secondary_schools")>] IssuingCardholderAuthorizationControlsBlockedCategories'ElementarySecondarySchools
        | [<JsonUnionCase("employment_temp_agencies")>] IssuingCardholderAuthorizationControlsBlockedCategories'EmploymentTempAgencies
        | [<JsonUnionCase("equipment_rental")>] IssuingCardholderAuthorizationControlsBlockedCategories'EquipmentRental
        | [<JsonUnionCase("exterminating_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'ExterminatingServices
        | [<JsonUnionCase("family_clothing_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'FamilyClothingStores
        | [<JsonUnionCase("fast_food_restaurants")>] IssuingCardholderAuthorizationControlsBlockedCategories'FastFoodRestaurants
        | [<JsonUnionCase("financial_institutions")>] IssuingCardholderAuthorizationControlsBlockedCategories'FinancialInstitutions
        | [<JsonUnionCase("fines_government_administrative_entities")>] IssuingCardholderAuthorizationControlsBlockedCategories'FinesGovernmentAdministrativeEntities
        | [<JsonUnionCase("fireplace_fireplace_screens_and_accessories_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'FireplaceFireplaceScreensAndAccessoriesStores
        | [<JsonUnionCase("floor_covering_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'FloorCoveringStores
        | [<JsonUnionCase("florists")>] IssuingCardholderAuthorizationControlsBlockedCategories'Florists
        | [<JsonUnionCase("florists_supplies_nursery_stock_and_flowers")>] IssuingCardholderAuthorizationControlsBlockedCategories'FloristsSuppliesNurseryStockAndFlowers
        | [<JsonUnionCase("freezer_and_locker_meat_provisioners")>] IssuingCardholderAuthorizationControlsBlockedCategories'FreezerAndLockerMeatProvisioners
        | [<JsonUnionCase("fuel_dealers_non_automotive")>] IssuingCardholderAuthorizationControlsBlockedCategories'FuelDealersNonAutomotive
        | [<JsonUnionCase("funeral_services_crematories")>] IssuingCardholderAuthorizationControlsBlockedCategories'FuneralServicesCrematories
        | [<JsonUnionCase("furniture_home_furnishings_and_equipment_stores_except_appliances")>] IssuingCardholderAuthorizationControlsBlockedCategories'FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | [<JsonUnionCase("furniture_repair_refinishing")>] IssuingCardholderAuthorizationControlsBlockedCategories'FurnitureRepairRefinishing
        | [<JsonUnionCase("furriers_and_fur_shops")>] IssuingCardholderAuthorizationControlsBlockedCategories'FurriersAndFurShops
        | [<JsonUnionCase("general_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'GeneralServices
        | [<JsonUnionCase("gift_card_novelty_and_souvenir_shops")>] IssuingCardholderAuthorizationControlsBlockedCategories'GiftCardNoveltyAndSouvenirShops
        | [<JsonUnionCase("glass_paint_and_wallpaper_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'GlassPaintAndWallpaperStores
        | [<JsonUnionCase("glassware_crystal_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'GlasswareCrystalStores
        | [<JsonUnionCase("golf_courses_public")>] IssuingCardholderAuthorizationControlsBlockedCategories'GolfCoursesPublic
        | [<JsonUnionCase("government_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'GovernmentServices
        | [<JsonUnionCase("grocery_stores_supermarkets")>] IssuingCardholderAuthorizationControlsBlockedCategories'GroceryStoresSupermarkets
        | [<JsonUnionCase("hardware_equipment_and_supplies")>] IssuingCardholderAuthorizationControlsBlockedCategories'HardwareEquipmentAndSupplies
        | [<JsonUnionCase("hardware_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'HardwareStores
        | [<JsonUnionCase("health_and_beauty_spas")>] IssuingCardholderAuthorizationControlsBlockedCategories'HealthAndBeautySpas
        | [<JsonUnionCase("hearing_aids_sales_and_supplies")>] IssuingCardholderAuthorizationControlsBlockedCategories'HearingAidsSalesAndSupplies
        | [<JsonUnionCase("heating_plumbing_a_c")>] IssuingCardholderAuthorizationControlsBlockedCategories'HeatingPlumbingAC
        | [<JsonUnionCase("hobby_toy_and_game_shops")>] IssuingCardholderAuthorizationControlsBlockedCategories'HobbyToyAndGameShops
        | [<JsonUnionCase("home_supply_warehouse_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'HomeSupplyWarehouseStores
        | [<JsonUnionCase("hospitals")>] IssuingCardholderAuthorizationControlsBlockedCategories'Hospitals
        | [<JsonUnionCase("hotels_motels_and_resorts")>] IssuingCardholderAuthorizationControlsBlockedCategories'HotelsMotelsAndResorts
        | [<JsonUnionCase("household_appliance_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'HouseholdApplianceStores
        | [<JsonUnionCase("industrial_supplies")>] IssuingCardholderAuthorizationControlsBlockedCategories'IndustrialSupplies
        | [<JsonUnionCase("information_retrieval_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'InformationRetrievalServices
        | [<JsonUnionCase("insurance_default")>] IssuingCardholderAuthorizationControlsBlockedCategories'InsuranceDefault
        | [<JsonUnionCase("insurance_underwriting_premiums")>] IssuingCardholderAuthorizationControlsBlockedCategories'InsuranceUnderwritingPremiums
        | [<JsonUnionCase("intra_company_purchases")>] IssuingCardholderAuthorizationControlsBlockedCategories'IntraCompanyPurchases
        | [<JsonUnionCase("jewelry_stores_watches_clocks_and_silverware_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'JewelryStoresWatchesClocksAndSilverwareStores
        | [<JsonUnionCase("landscaping_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'LandscapingServices
        | [<JsonUnionCase("laundries")>] IssuingCardholderAuthorizationControlsBlockedCategories'Laundries
        | [<JsonUnionCase("laundry_cleaning_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'LaundryCleaningServices
        | [<JsonUnionCase("legal_services_attorneys")>] IssuingCardholderAuthorizationControlsBlockedCategories'LegalServicesAttorneys
        | [<JsonUnionCase("luggage_and_leather_goods_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'LuggageAndLeatherGoodsStores
        | [<JsonUnionCase("lumber_building_materials_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'LumberBuildingMaterialsStores
        | [<JsonUnionCase("manual_cash_disburse")>] IssuingCardholderAuthorizationControlsBlockedCategories'ManualCashDisburse
        | [<JsonUnionCase("marinas_service_and_supplies")>] IssuingCardholderAuthorizationControlsBlockedCategories'MarinasServiceAndSupplies
        | [<JsonUnionCase("masonry_stonework_and_plaster")>] IssuingCardholderAuthorizationControlsBlockedCategories'MasonryStoneworkAndPlaster
        | [<JsonUnionCase("massage_parlors")>] IssuingCardholderAuthorizationControlsBlockedCategories'MassageParlors
        | [<JsonUnionCase("medical_and_dental_labs")>] IssuingCardholderAuthorizationControlsBlockedCategories'MedicalAndDentalLabs
        | [<JsonUnionCase("medical_dental_ophthalmic_and_hospital_equipment_and_supplies")>] IssuingCardholderAuthorizationControlsBlockedCategories'MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | [<JsonUnionCase("medical_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'MedicalServices
        | [<JsonUnionCase("membership_organizations")>] IssuingCardholderAuthorizationControlsBlockedCategories'MembershipOrganizations
        | [<JsonUnionCase("mens_and_boys_clothing_and_accessories_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'MensAndBoysClothingAndAccessoriesStores
        | [<JsonUnionCase("mens_womens_clothing_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'MensWomensClothingStores
        | [<JsonUnionCase("metal_service_centers")>] IssuingCardholderAuthorizationControlsBlockedCategories'MetalServiceCenters
        | [<JsonUnionCase("miscellaneous")>] IssuingCardholderAuthorizationControlsBlockedCategories'Miscellaneous
        | [<JsonUnionCase("miscellaneous_apparel_and_accessory_shops")>] IssuingCardholderAuthorizationControlsBlockedCategories'MiscellaneousApparelAndAccessoryShops
        | [<JsonUnionCase("miscellaneous_auto_dealers")>] IssuingCardholderAuthorizationControlsBlockedCategories'MiscellaneousAutoDealers
        | [<JsonUnionCase("miscellaneous_business_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'MiscellaneousBusinessServices
        | [<JsonUnionCase("miscellaneous_food_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'MiscellaneousFoodStores
        | [<JsonUnionCase("miscellaneous_general_merchandise")>] IssuingCardholderAuthorizationControlsBlockedCategories'MiscellaneousGeneralMerchandise
        | [<JsonUnionCase("miscellaneous_general_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'MiscellaneousGeneralServices
        | [<JsonUnionCase("miscellaneous_home_furnishing_specialty_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'MiscellaneousHomeFurnishingSpecialtyStores
        | [<JsonUnionCase("miscellaneous_publishing_and_printing")>] IssuingCardholderAuthorizationControlsBlockedCategories'MiscellaneousPublishingAndPrinting
        | [<JsonUnionCase("miscellaneous_recreation_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'MiscellaneousRecreationServices
        | [<JsonUnionCase("miscellaneous_repair_shops")>] IssuingCardholderAuthorizationControlsBlockedCategories'MiscellaneousRepairShops
        | [<JsonUnionCase("miscellaneous_specialty_retail")>] IssuingCardholderAuthorizationControlsBlockedCategories'MiscellaneousSpecialtyRetail
        | [<JsonUnionCase("mobile_home_dealers")>] IssuingCardholderAuthorizationControlsBlockedCategories'MobileHomeDealers
        | [<JsonUnionCase("motion_picture_theaters")>] IssuingCardholderAuthorizationControlsBlockedCategories'MotionPictureTheaters
        | [<JsonUnionCase("motor_freight_carriers_and_trucking")>] IssuingCardholderAuthorizationControlsBlockedCategories'MotorFreightCarriersAndTrucking
        | [<JsonUnionCase("motor_homes_dealers")>] IssuingCardholderAuthorizationControlsBlockedCategories'MotorHomesDealers
        | [<JsonUnionCase("motor_vehicle_supplies_and_new_parts")>] IssuingCardholderAuthorizationControlsBlockedCategories'MotorVehicleSuppliesAndNewParts
        | [<JsonUnionCase("motorcycle_shops_and_dealers")>] IssuingCardholderAuthorizationControlsBlockedCategories'MotorcycleShopsAndDealers
        | [<JsonUnionCase("motorcycle_shops_dealers")>] IssuingCardholderAuthorizationControlsBlockedCategories'MotorcycleShopsDealers
        | [<JsonUnionCase("music_stores_musical_instruments_pianos_and_sheet_music")>] IssuingCardholderAuthorizationControlsBlockedCategories'MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | [<JsonUnionCase("news_dealers_and_newsstands")>] IssuingCardholderAuthorizationControlsBlockedCategories'NewsDealersAndNewsstands
        | [<JsonUnionCase("non_fi_money_orders")>] IssuingCardholderAuthorizationControlsBlockedCategories'NonFiMoneyOrders
        | [<JsonUnionCase("non_fi_stored_value_card_purchase_load")>] IssuingCardholderAuthorizationControlsBlockedCategories'NonFiStoredValueCardPurchaseLoad
        | [<JsonUnionCase("nondurable_goods")>] IssuingCardholderAuthorizationControlsBlockedCategories'NondurableGoods
        | [<JsonUnionCase("nurseries_lawn_and_garden_supply_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'NurseriesLawnAndGardenSupplyStores
        | [<JsonUnionCase("nursing_personal_care")>] IssuingCardholderAuthorizationControlsBlockedCategories'NursingPersonalCare
        | [<JsonUnionCase("office_and_commercial_furniture")>] IssuingCardholderAuthorizationControlsBlockedCategories'OfficeAndCommercialFurniture
        | [<JsonUnionCase("opticians_eyeglasses")>] IssuingCardholderAuthorizationControlsBlockedCategories'OpticiansEyeglasses
        | [<JsonUnionCase("optometrists_ophthalmologist")>] IssuingCardholderAuthorizationControlsBlockedCategories'OptometristsOphthalmologist
        | [<JsonUnionCase("orthopedic_goods_prosthetic_devices")>] IssuingCardholderAuthorizationControlsBlockedCategories'OrthopedicGoodsProstheticDevices
        | [<JsonUnionCase("osteopaths")>] IssuingCardholderAuthorizationControlsBlockedCategories'Osteopaths
        | [<JsonUnionCase("package_stores_beer_wine_and_liquor")>] IssuingCardholderAuthorizationControlsBlockedCategories'PackageStoresBeerWineAndLiquor
        | [<JsonUnionCase("paints_varnishes_and_supplies")>] IssuingCardholderAuthorizationControlsBlockedCategories'PaintsVarnishesAndSupplies
        | [<JsonUnionCase("parking_lots_garages")>] IssuingCardholderAuthorizationControlsBlockedCategories'ParkingLotsGarages
        | [<JsonUnionCase("passenger_railways")>] IssuingCardholderAuthorizationControlsBlockedCategories'PassengerRailways
        | [<JsonUnionCase("pawn_shops")>] IssuingCardholderAuthorizationControlsBlockedCategories'PawnShops
        | [<JsonUnionCase("pet_shops_pet_food_and_supplies")>] IssuingCardholderAuthorizationControlsBlockedCategories'PetShopsPetFoodAndSupplies
        | [<JsonUnionCase("petroleum_and_petroleum_products")>] IssuingCardholderAuthorizationControlsBlockedCategories'PetroleumAndPetroleumProducts
        | [<JsonUnionCase("photo_developing")>] IssuingCardholderAuthorizationControlsBlockedCategories'PhotoDeveloping
        | [<JsonUnionCase("photographic_photocopy_microfilm_equipment_and_supplies")>] IssuingCardholderAuthorizationControlsBlockedCategories'PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | [<JsonUnionCase("photographic_studios")>] IssuingCardholderAuthorizationControlsBlockedCategories'PhotographicStudios
        | [<JsonUnionCase("picture_video_production")>] IssuingCardholderAuthorizationControlsBlockedCategories'PictureVideoProduction
        | [<JsonUnionCase("piece_goods_notions_and_other_dry_goods")>] IssuingCardholderAuthorizationControlsBlockedCategories'PieceGoodsNotionsAndOtherDryGoods
        | [<JsonUnionCase("plumbing_heating_equipment_and_supplies")>] IssuingCardholderAuthorizationControlsBlockedCategories'PlumbingHeatingEquipmentAndSupplies
        | [<JsonUnionCase("political_organizations")>] IssuingCardholderAuthorizationControlsBlockedCategories'PoliticalOrganizations
        | [<JsonUnionCase("postal_services_government_only")>] IssuingCardholderAuthorizationControlsBlockedCategories'PostalServicesGovernmentOnly
        | [<JsonUnionCase("precious_stones_and_metals_watches_and_jewelry")>] IssuingCardholderAuthorizationControlsBlockedCategories'PreciousStonesAndMetalsWatchesAndJewelry
        | [<JsonUnionCase("professional_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'ProfessionalServices
        | [<JsonUnionCase("public_warehousing_and_storage")>] IssuingCardholderAuthorizationControlsBlockedCategories'PublicWarehousingAndStorage
        | [<JsonUnionCase("quick_copy_repro_and_blueprint")>] IssuingCardholderAuthorizationControlsBlockedCategories'QuickCopyReproAndBlueprint
        | [<JsonUnionCase("railroads")>] IssuingCardholderAuthorizationControlsBlockedCategories'Railroads
        | [<JsonUnionCase("real_estate_agents_and_managers_rentals")>] IssuingCardholderAuthorizationControlsBlockedCategories'RealEstateAgentsAndManagersRentals
        | [<JsonUnionCase("record_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'RecordStores
        | [<JsonUnionCase("recreational_vehicle_rentals")>] IssuingCardholderAuthorizationControlsBlockedCategories'RecreationalVehicleRentals
        | [<JsonUnionCase("religious_goods_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'ReligiousGoodsStores
        | [<JsonUnionCase("religious_organizations")>] IssuingCardholderAuthorizationControlsBlockedCategories'ReligiousOrganizations
        | [<JsonUnionCase("roofing_siding_sheet_metal")>] IssuingCardholderAuthorizationControlsBlockedCategories'RoofingSidingSheetMetal
        | [<JsonUnionCase("secretarial_support_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'SecretarialSupportServices
        | [<JsonUnionCase("security_brokers_dealers")>] IssuingCardholderAuthorizationControlsBlockedCategories'SecurityBrokersDealers
        | [<JsonUnionCase("service_stations")>] IssuingCardholderAuthorizationControlsBlockedCategories'ServiceStations
        | [<JsonUnionCase("sewing_needlework_fabric_and_piece_goods_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'SewingNeedleworkFabricAndPieceGoodsStores
        | [<JsonUnionCase("shoe_repair_hat_cleaning")>] IssuingCardholderAuthorizationControlsBlockedCategories'ShoeRepairHatCleaning
        | [<JsonUnionCase("shoe_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'ShoeStores
        | [<JsonUnionCase("small_appliance_repair")>] IssuingCardholderAuthorizationControlsBlockedCategories'SmallApplianceRepair
        | [<JsonUnionCase("snowmobile_dealers")>] IssuingCardholderAuthorizationControlsBlockedCategories'SnowmobileDealers
        | [<JsonUnionCase("special_trade_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'SpecialTradeServices
        | [<JsonUnionCase("specialty_cleaning")>] IssuingCardholderAuthorizationControlsBlockedCategories'SpecialtyCleaning
        | [<JsonUnionCase("sporting_goods_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'SportingGoodsStores
        | [<JsonUnionCase("sporting_recreation_camps")>] IssuingCardholderAuthorizationControlsBlockedCategories'SportingRecreationCamps
        | [<JsonUnionCase("sports_and_riding_apparel_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'SportsAndRidingApparelStores
        | [<JsonUnionCase("sports_clubs_fields")>] IssuingCardholderAuthorizationControlsBlockedCategories'SportsClubsFields
        | [<JsonUnionCase("stamp_and_coin_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'StampAndCoinStores
        | [<JsonUnionCase("stationary_office_supplies_printing_and_writing_paper")>] IssuingCardholderAuthorizationControlsBlockedCategories'StationaryOfficeSuppliesPrintingAndWritingPaper
        | [<JsonUnionCase("stationery_stores_office_and_school_supply_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'StationeryStoresOfficeAndSchoolSupplyStores
        | [<JsonUnionCase("swimming_pools_sales")>] IssuingCardholderAuthorizationControlsBlockedCategories'SwimmingPoolsSales
        | [<JsonUnionCase("t_ui_travel_germany")>] IssuingCardholderAuthorizationControlsBlockedCategories'TUiTravelGermany
        | [<JsonUnionCase("tailors_alterations")>] IssuingCardholderAuthorizationControlsBlockedCategories'TailorsAlterations
        | [<JsonUnionCase("tax_payments_government_agencies")>] IssuingCardholderAuthorizationControlsBlockedCategories'TaxPaymentsGovernmentAgencies
        | [<JsonUnionCase("tax_preparation_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'TaxPreparationServices
        | [<JsonUnionCase("taxicabs_limousines")>] IssuingCardholderAuthorizationControlsBlockedCategories'TaxicabsLimousines
        | [<JsonUnionCase("telecommunication_equipment_and_telephone_sales")>] IssuingCardholderAuthorizationControlsBlockedCategories'TelecommunicationEquipmentAndTelephoneSales
        | [<JsonUnionCase("telecommunication_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'TelecommunicationServices
        | [<JsonUnionCase("telegraph_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'TelegraphServices
        | [<JsonUnionCase("tent_and_awning_shops")>] IssuingCardholderAuthorizationControlsBlockedCategories'TentAndAwningShops
        | [<JsonUnionCase("testing_laboratories")>] IssuingCardholderAuthorizationControlsBlockedCategories'TestingLaboratories
        | [<JsonUnionCase("theatrical_ticket_agencies")>] IssuingCardholderAuthorizationControlsBlockedCategories'TheatricalTicketAgencies
        | [<JsonUnionCase("timeshares")>] IssuingCardholderAuthorizationControlsBlockedCategories'Timeshares
        | [<JsonUnionCase("tire_retreading_and_repair")>] IssuingCardholderAuthorizationControlsBlockedCategories'TireRetreadingAndRepair
        | [<JsonUnionCase("tolls_bridge_fees")>] IssuingCardholderAuthorizationControlsBlockedCategories'TollsBridgeFees
        | [<JsonUnionCase("tourist_attractions_and_exhibits")>] IssuingCardholderAuthorizationControlsBlockedCategories'TouristAttractionsAndExhibits
        | [<JsonUnionCase("towing_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'TowingServices
        | [<JsonUnionCase("trailer_parks_campgrounds")>] IssuingCardholderAuthorizationControlsBlockedCategories'TrailerParksCampgrounds
        | [<JsonUnionCase("transportation_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'TransportationServices
        | [<JsonUnionCase("travel_agencies_tour_operators")>] IssuingCardholderAuthorizationControlsBlockedCategories'TravelAgenciesTourOperators
        | [<JsonUnionCase("truck_stop_iteration")>] IssuingCardholderAuthorizationControlsBlockedCategories'TruckStopIteration
        | [<JsonUnionCase("truck_utility_trailer_rentals")>] IssuingCardholderAuthorizationControlsBlockedCategories'TruckUtilityTrailerRentals
        | [<JsonUnionCase("typesetting_plate_making_and_related_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'TypesettingPlateMakingAndRelatedServices
        | [<JsonUnionCase("typewriter_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'TypewriterStores
        | [<JsonUnionCase("u_s_federal_government_agencies_or_departments")>] IssuingCardholderAuthorizationControlsBlockedCategories'USFederalGovernmentAgenciesOrDepartments
        | [<JsonUnionCase("uniforms_commercial_clothing")>] IssuingCardholderAuthorizationControlsBlockedCategories'UniformsCommercialClothing
        | [<JsonUnionCase("used_merchandise_and_secondhand_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'UsedMerchandiseAndSecondhandStores
        | [<JsonUnionCase("utilities")>] IssuingCardholderAuthorizationControlsBlockedCategories'Utilities
        | [<JsonUnionCase("variety_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'VarietyStores
        | [<JsonUnionCase("veterinary_services")>] IssuingCardholderAuthorizationControlsBlockedCategories'VeterinaryServices
        | [<JsonUnionCase("video_amusement_game_supplies")>] IssuingCardholderAuthorizationControlsBlockedCategories'VideoAmusementGameSupplies
        | [<JsonUnionCase("video_game_arcades")>] IssuingCardholderAuthorizationControlsBlockedCategories'VideoGameArcades
        | [<JsonUnionCase("video_tape_rental_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'VideoTapeRentalStores
        | [<JsonUnionCase("vocational_trade_schools")>] IssuingCardholderAuthorizationControlsBlockedCategories'VocationalTradeSchools
        | [<JsonUnionCase("watch_jewelry_repair")>] IssuingCardholderAuthorizationControlsBlockedCategories'WatchJewelryRepair
        | [<JsonUnionCase("welding_repair")>] IssuingCardholderAuthorizationControlsBlockedCategories'WeldingRepair
        | [<JsonUnionCase("wholesale_clubs")>] IssuingCardholderAuthorizationControlsBlockedCategories'WholesaleClubs
        | [<JsonUnionCase("wig_and_toupee_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'WigAndToupeeStores
        | [<JsonUnionCase("wires_money_orders")>] IssuingCardholderAuthorizationControlsBlockedCategories'WiresMoneyOrders
        | [<JsonUnionCase("womens_accessory_and_specialty_shops")>] IssuingCardholderAuthorizationControlsBlockedCategories'WomensAccessoryAndSpecialtyShops
        | [<JsonUnionCase("womens_ready_to_wear_stores")>] IssuingCardholderAuthorizationControlsBlockedCategories'WomensReadyToWearStores
        | [<JsonUnionCase("wrecking_and_salvage_yards")>] IssuingCardholderAuthorizationControlsBlockedCategories'WreckingAndSalvageYards

    ///
    and IssuingCardholderCompany (taxIdProvided: bool) =

        member _.TaxIdProvided = taxIdProvided

    ///
    and IssuingCardholderIdDocument (back: Choice<string, File> option, front: Choice<string, File> option) =

        member _.Back = back
        member _.Front = front

    ///
    and IssuingCardholderIndividual (dob: IssuingCardholderIndividualDob option, firstName: string, lastName: string, verification: IssuingCardholderVerification option) =

        member _.Dob = dob
        member _.FirstName = firstName
        member _.LastName = lastName
        member _.Verification = verification

    ///
    and IssuingCardholderIndividualDob (day: int64 option, month: int64 option, year: int64 option) =

        member _.Day = day
        member _.Month = month
        member _.Year = year

    ///
    and IssuingCardholderRequirements (disabledReason: IssuingCardholderRequirementsDisabledReason option, pastDue: IssuingCardholderRequirementsPastDue list option) =

        member _.DisabledReason = disabledReason
        member _.PastDue = pastDue

    and IssuingCardholderRequirementsDisabledReason =
        | [<JsonUnionCase("listed")>] IssuingCardholderRequirementsDisabledReason'Listed
        | [<JsonUnionCase("rejected.listed")>] IssuingCardholderRequirementsDisabledReason'RejectedListed
        | [<JsonUnionCase("under_review")>] IssuingCardholderRequirementsDisabledReason'UnderReview

    and IssuingCardholderRequirementsPastDue =
        | [<JsonUnionCase("company.tax_id")>] IssuingCardholderRequirementsPastDue'CompanyTaxId
        | [<JsonUnionCase("individual.dob.day")>] IssuingCardholderRequirementsPastDue'IndividualDobDay
        | [<JsonUnionCase("individual.dob.month")>] IssuingCardholderRequirementsPastDue'IndividualDobMonth
        | [<JsonUnionCase("individual.dob.year")>] IssuingCardholderRequirementsPastDue'IndividualDobYear
        | [<JsonUnionCase("individual.first_name")>] IssuingCardholderRequirementsPastDue'IndividualFirstName
        | [<JsonUnionCase("individual.last_name")>] IssuingCardholderRequirementsPastDue'IndividualLastName
        | [<JsonUnionCase("individual.verification.document")>] IssuingCardholderRequirementsPastDue'IndividualVerificationDocument

    ///
    and IssuingCardholderSpendingLimit (amount: int64, categories: IssuingCardholderSpendingLimitCategories list option, interval: IssuingCardholderSpendingLimitInterval) =

        member _.Amount = amount
        member _.Categories = categories
        member _.Interval = interval

    and IssuingCardholderSpendingLimitCategories =
        | [<JsonUnionCase("ac_refrigeration_repair")>] IssuingCardholderSpendingLimitCategories'AcRefrigerationRepair
        | [<JsonUnionCase("accounting_bookkeeping_services")>] IssuingCardholderSpendingLimitCategories'AccountingBookkeepingServices
        | [<JsonUnionCase("advertising_services")>] IssuingCardholderSpendingLimitCategories'AdvertisingServices
        | [<JsonUnionCase("agricultural_cooperative")>] IssuingCardholderSpendingLimitCategories'AgriculturalCooperative
        | [<JsonUnionCase("airlines_air_carriers")>] IssuingCardholderSpendingLimitCategories'AirlinesAirCarriers
        | [<JsonUnionCase("airports_flying_fields")>] IssuingCardholderSpendingLimitCategories'AirportsFlyingFields
        | [<JsonUnionCase("ambulance_services")>] IssuingCardholderSpendingLimitCategories'AmbulanceServices
        | [<JsonUnionCase("amusement_parks_carnivals")>] IssuingCardholderSpendingLimitCategories'AmusementParksCarnivals
        | [<JsonUnionCase("antique_reproductions")>] IssuingCardholderSpendingLimitCategories'AntiqueReproductions
        | [<JsonUnionCase("antique_shops")>] IssuingCardholderSpendingLimitCategories'AntiqueShops
        | [<JsonUnionCase("aquariums")>] IssuingCardholderSpendingLimitCategories'Aquariums
        | [<JsonUnionCase("architectural_surveying_services")>] IssuingCardholderSpendingLimitCategories'ArchitecturalSurveyingServices
        | [<JsonUnionCase("art_dealers_and_galleries")>] IssuingCardholderSpendingLimitCategories'ArtDealersAndGalleries
        | [<JsonUnionCase("artists_supply_and_craft_shops")>] IssuingCardholderSpendingLimitCategories'ArtistsSupplyAndCraftShops
        | [<JsonUnionCase("auto_and_home_supply_stores")>] IssuingCardholderSpendingLimitCategories'AutoAndHomeSupplyStores
        | [<JsonUnionCase("auto_body_repair_shops")>] IssuingCardholderSpendingLimitCategories'AutoBodyRepairShops
        | [<JsonUnionCase("auto_paint_shops")>] IssuingCardholderSpendingLimitCategories'AutoPaintShops
        | [<JsonUnionCase("auto_service_shops")>] IssuingCardholderSpendingLimitCategories'AutoServiceShops
        | [<JsonUnionCase("automated_cash_disburse")>] IssuingCardholderSpendingLimitCategories'AutomatedCashDisburse
        | [<JsonUnionCase("automated_fuel_dispensers")>] IssuingCardholderSpendingLimitCategories'AutomatedFuelDispensers
        | [<JsonUnionCase("automobile_associations")>] IssuingCardholderSpendingLimitCategories'AutomobileAssociations
        | [<JsonUnionCase("automotive_parts_and_accessories_stores")>] IssuingCardholderSpendingLimitCategories'AutomotivePartsAndAccessoriesStores
        | [<JsonUnionCase("automotive_tire_stores")>] IssuingCardholderSpendingLimitCategories'AutomotiveTireStores
        | [<JsonUnionCase("bail_and_bond_payments")>] IssuingCardholderSpendingLimitCategories'BailAndBondPayments
        | [<JsonUnionCase("bakeries")>] IssuingCardholderSpendingLimitCategories'Bakeries
        | [<JsonUnionCase("bands_orchestras")>] IssuingCardholderSpendingLimitCategories'BandsOrchestras
        | [<JsonUnionCase("barber_and_beauty_shops")>] IssuingCardholderSpendingLimitCategories'BarberAndBeautyShops
        | [<JsonUnionCase("betting_casino_gambling")>] IssuingCardholderSpendingLimitCategories'BettingCasinoGambling
        | [<JsonUnionCase("bicycle_shops")>] IssuingCardholderSpendingLimitCategories'BicycleShops
        | [<JsonUnionCase("billiard_pool_establishments")>] IssuingCardholderSpendingLimitCategories'BilliardPoolEstablishments
        | [<JsonUnionCase("boat_dealers")>] IssuingCardholderSpendingLimitCategories'BoatDealers
        | [<JsonUnionCase("boat_rentals_and_leases")>] IssuingCardholderSpendingLimitCategories'BoatRentalsAndLeases
        | [<JsonUnionCase("book_stores")>] IssuingCardholderSpendingLimitCategories'BookStores
        | [<JsonUnionCase("books_periodicals_and_newspapers")>] IssuingCardholderSpendingLimitCategories'BooksPeriodicalsAndNewspapers
        | [<JsonUnionCase("bowling_alleys")>] IssuingCardholderSpendingLimitCategories'BowlingAlleys
        | [<JsonUnionCase("bus_lines")>] IssuingCardholderSpendingLimitCategories'BusLines
        | [<JsonUnionCase("business_secretarial_schools")>] IssuingCardholderSpendingLimitCategories'BusinessSecretarialSchools
        | [<JsonUnionCase("buying_shopping_services")>] IssuingCardholderSpendingLimitCategories'BuyingShoppingServices
        | [<JsonUnionCase("cable_satellite_and_other_pay_television_and_radio")>] IssuingCardholderSpendingLimitCategories'CableSatelliteAndOtherPayTelevisionAndRadio
        | [<JsonUnionCase("camera_and_photographic_supply_stores")>] IssuingCardholderSpendingLimitCategories'CameraAndPhotographicSupplyStores
        | [<JsonUnionCase("candy_nut_and_confectionery_stores")>] IssuingCardholderSpendingLimitCategories'CandyNutAndConfectioneryStores
        | [<JsonUnionCase("car_and_truck_dealers_new_used")>] IssuingCardholderSpendingLimitCategories'CarAndTruckDealersNewUsed
        | [<JsonUnionCase("car_and_truck_dealers_used_only")>] IssuingCardholderSpendingLimitCategories'CarAndTruckDealersUsedOnly
        | [<JsonUnionCase("car_rental_agencies")>] IssuingCardholderSpendingLimitCategories'CarRentalAgencies
        | [<JsonUnionCase("car_washes")>] IssuingCardholderSpendingLimitCategories'CarWashes
        | [<JsonUnionCase("carpentry_services")>] IssuingCardholderSpendingLimitCategories'CarpentryServices
        | [<JsonUnionCase("carpet_upholstery_cleaning")>] IssuingCardholderSpendingLimitCategories'CarpetUpholsteryCleaning
        | [<JsonUnionCase("caterers")>] IssuingCardholderSpendingLimitCategories'Caterers
        | [<JsonUnionCase("charitable_and_social_service_organizations_fundraising")>] IssuingCardholderSpendingLimitCategories'CharitableAndSocialServiceOrganizationsFundraising
        | [<JsonUnionCase("chemicals_and_allied_products")>] IssuingCardholderSpendingLimitCategories'ChemicalsAndAlliedProducts
        | [<JsonUnionCase("child_care_services")>] IssuingCardholderSpendingLimitCategories'ChildCareServices
        | [<JsonUnionCase("childrens_and_infants_wear_stores")>] IssuingCardholderSpendingLimitCategories'ChildrensAndInfantsWearStores
        | [<JsonUnionCase("chiropodists_podiatrists")>] IssuingCardholderSpendingLimitCategories'ChiropodistsPodiatrists
        | [<JsonUnionCase("chiropractors")>] IssuingCardholderSpendingLimitCategories'Chiropractors
        | [<JsonUnionCase("cigar_stores_and_stands")>] IssuingCardholderSpendingLimitCategories'CigarStoresAndStands
        | [<JsonUnionCase("civic_social_fraternal_associations")>] IssuingCardholderSpendingLimitCategories'CivicSocialFraternalAssociations
        | [<JsonUnionCase("cleaning_and_maintenance")>] IssuingCardholderSpendingLimitCategories'CleaningAndMaintenance
        | [<JsonUnionCase("clothing_rental")>] IssuingCardholderSpendingLimitCategories'ClothingRental
        | [<JsonUnionCase("colleges_universities")>] IssuingCardholderSpendingLimitCategories'CollegesUniversities
        | [<JsonUnionCase("commercial_equipment")>] IssuingCardholderSpendingLimitCategories'CommercialEquipment
        | [<JsonUnionCase("commercial_footwear")>] IssuingCardholderSpendingLimitCategories'CommercialFootwear
        | [<JsonUnionCase("commercial_photography_art_and_graphics")>] IssuingCardholderSpendingLimitCategories'CommercialPhotographyArtAndGraphics
        | [<JsonUnionCase("commuter_transport_and_ferries")>] IssuingCardholderSpendingLimitCategories'CommuterTransportAndFerries
        | [<JsonUnionCase("computer_network_services")>] IssuingCardholderSpendingLimitCategories'ComputerNetworkServices
        | [<JsonUnionCase("computer_programming")>] IssuingCardholderSpendingLimitCategories'ComputerProgramming
        | [<JsonUnionCase("computer_repair")>] IssuingCardholderSpendingLimitCategories'ComputerRepair
        | [<JsonUnionCase("computer_software_stores")>] IssuingCardholderSpendingLimitCategories'ComputerSoftwareStores
        | [<JsonUnionCase("computers_peripherals_and_software")>] IssuingCardholderSpendingLimitCategories'ComputersPeripheralsAndSoftware
        | [<JsonUnionCase("concrete_work_services")>] IssuingCardholderSpendingLimitCategories'ConcreteWorkServices
        | [<JsonUnionCase("construction_materials")>] IssuingCardholderSpendingLimitCategories'ConstructionMaterials
        | [<JsonUnionCase("consulting_public_relations")>] IssuingCardholderSpendingLimitCategories'ConsultingPublicRelations
        | [<JsonUnionCase("correspondence_schools")>] IssuingCardholderSpendingLimitCategories'CorrespondenceSchools
        | [<JsonUnionCase("cosmetic_stores")>] IssuingCardholderSpendingLimitCategories'CosmeticStores
        | [<JsonUnionCase("counseling_services")>] IssuingCardholderSpendingLimitCategories'CounselingServices
        | [<JsonUnionCase("country_clubs")>] IssuingCardholderSpendingLimitCategories'CountryClubs
        | [<JsonUnionCase("courier_services")>] IssuingCardholderSpendingLimitCategories'CourierServices
        | [<JsonUnionCase("court_costs")>] IssuingCardholderSpendingLimitCategories'CourtCosts
        | [<JsonUnionCase("credit_reporting_agencies")>] IssuingCardholderSpendingLimitCategories'CreditReportingAgencies
        | [<JsonUnionCase("cruise_lines")>] IssuingCardholderSpendingLimitCategories'CruiseLines
        | [<JsonUnionCase("dairy_products_stores")>] IssuingCardholderSpendingLimitCategories'DairyProductsStores
        | [<JsonUnionCase("dance_hall_studios_schools")>] IssuingCardholderSpendingLimitCategories'DanceHallStudiosSchools
        | [<JsonUnionCase("dating_escort_services")>] IssuingCardholderSpendingLimitCategories'DatingEscortServices
        | [<JsonUnionCase("dentists_orthodontists")>] IssuingCardholderSpendingLimitCategories'DentistsOrthodontists
        | [<JsonUnionCase("department_stores")>] IssuingCardholderSpendingLimitCategories'DepartmentStores
        | [<JsonUnionCase("detective_agencies")>] IssuingCardholderSpendingLimitCategories'DetectiveAgencies
        | [<JsonUnionCase("digital_goods_applications")>] IssuingCardholderSpendingLimitCategories'DigitalGoodsApplications
        | [<JsonUnionCase("digital_goods_games")>] IssuingCardholderSpendingLimitCategories'DigitalGoodsGames
        | [<JsonUnionCase("digital_goods_large_volume")>] IssuingCardholderSpendingLimitCategories'DigitalGoodsLargeVolume
        | [<JsonUnionCase("digital_goods_media")>] IssuingCardholderSpendingLimitCategories'DigitalGoodsMedia
        | [<JsonUnionCase("direct_marketing_catalog_merchant")>] IssuingCardholderSpendingLimitCategories'DirectMarketingCatalogMerchant
        | [<JsonUnionCase("direct_marketing_combination_catalog_and_retail_merchant")>] IssuingCardholderSpendingLimitCategories'DirectMarketingCombinationCatalogAndRetailMerchant
        | [<JsonUnionCase("direct_marketing_inbound_telemarketing")>] IssuingCardholderSpendingLimitCategories'DirectMarketingInboundTelemarketing
        | [<JsonUnionCase("direct_marketing_insurance_services")>] IssuingCardholderSpendingLimitCategories'DirectMarketingInsuranceServices
        | [<JsonUnionCase("direct_marketing_other")>] IssuingCardholderSpendingLimitCategories'DirectMarketingOther
        | [<JsonUnionCase("direct_marketing_outbound_telemarketing")>] IssuingCardholderSpendingLimitCategories'DirectMarketingOutboundTelemarketing
        | [<JsonUnionCase("direct_marketing_subscription")>] IssuingCardholderSpendingLimitCategories'DirectMarketingSubscription
        | [<JsonUnionCase("direct_marketing_travel")>] IssuingCardholderSpendingLimitCategories'DirectMarketingTravel
        | [<JsonUnionCase("discount_stores")>] IssuingCardholderSpendingLimitCategories'DiscountStores
        | [<JsonUnionCase("doctors")>] IssuingCardholderSpendingLimitCategories'Doctors
        | [<JsonUnionCase("door_to_door_sales")>] IssuingCardholderSpendingLimitCategories'DoorToDoorSales
        | [<JsonUnionCase("drapery_window_covering_and_upholstery_stores")>] IssuingCardholderSpendingLimitCategories'DraperyWindowCoveringAndUpholsteryStores
        | [<JsonUnionCase("drinking_places")>] IssuingCardholderSpendingLimitCategories'DrinkingPlaces
        | [<JsonUnionCase("drug_stores_and_pharmacies")>] IssuingCardholderSpendingLimitCategories'DrugStoresAndPharmacies
        | [<JsonUnionCase("drugs_drug_proprietaries_and_druggist_sundries")>] IssuingCardholderSpendingLimitCategories'DrugsDrugProprietariesAndDruggistSundries
        | [<JsonUnionCase("dry_cleaners")>] IssuingCardholderSpendingLimitCategories'DryCleaners
        | [<JsonUnionCase("durable_goods")>] IssuingCardholderSpendingLimitCategories'DurableGoods
        | [<JsonUnionCase("duty_free_stores")>] IssuingCardholderSpendingLimitCategories'DutyFreeStores
        | [<JsonUnionCase("eating_places_restaurants")>] IssuingCardholderSpendingLimitCategories'EatingPlacesRestaurants
        | [<JsonUnionCase("educational_services")>] IssuingCardholderSpendingLimitCategories'EducationalServices
        | [<JsonUnionCase("electric_razor_stores")>] IssuingCardholderSpendingLimitCategories'ElectricRazorStores
        | [<JsonUnionCase("electrical_parts_and_equipment")>] IssuingCardholderSpendingLimitCategories'ElectricalPartsAndEquipment
        | [<JsonUnionCase("electrical_services")>] IssuingCardholderSpendingLimitCategories'ElectricalServices
        | [<JsonUnionCase("electronics_repair_shops")>] IssuingCardholderSpendingLimitCategories'ElectronicsRepairShops
        | [<JsonUnionCase("electronics_stores")>] IssuingCardholderSpendingLimitCategories'ElectronicsStores
        | [<JsonUnionCase("elementary_secondary_schools")>] IssuingCardholderSpendingLimitCategories'ElementarySecondarySchools
        | [<JsonUnionCase("employment_temp_agencies")>] IssuingCardholderSpendingLimitCategories'EmploymentTempAgencies
        | [<JsonUnionCase("equipment_rental")>] IssuingCardholderSpendingLimitCategories'EquipmentRental
        | [<JsonUnionCase("exterminating_services")>] IssuingCardholderSpendingLimitCategories'ExterminatingServices
        | [<JsonUnionCase("family_clothing_stores")>] IssuingCardholderSpendingLimitCategories'FamilyClothingStores
        | [<JsonUnionCase("fast_food_restaurants")>] IssuingCardholderSpendingLimitCategories'FastFoodRestaurants
        | [<JsonUnionCase("financial_institutions")>] IssuingCardholderSpendingLimitCategories'FinancialInstitutions
        | [<JsonUnionCase("fines_government_administrative_entities")>] IssuingCardholderSpendingLimitCategories'FinesGovernmentAdministrativeEntities
        | [<JsonUnionCase("fireplace_fireplace_screens_and_accessories_stores")>] IssuingCardholderSpendingLimitCategories'FireplaceFireplaceScreensAndAccessoriesStores
        | [<JsonUnionCase("floor_covering_stores")>] IssuingCardholderSpendingLimitCategories'FloorCoveringStores
        | [<JsonUnionCase("florists")>] IssuingCardholderSpendingLimitCategories'Florists
        | [<JsonUnionCase("florists_supplies_nursery_stock_and_flowers")>] IssuingCardholderSpendingLimitCategories'FloristsSuppliesNurseryStockAndFlowers
        | [<JsonUnionCase("freezer_and_locker_meat_provisioners")>] IssuingCardholderSpendingLimitCategories'FreezerAndLockerMeatProvisioners
        | [<JsonUnionCase("fuel_dealers_non_automotive")>] IssuingCardholderSpendingLimitCategories'FuelDealersNonAutomotive
        | [<JsonUnionCase("funeral_services_crematories")>] IssuingCardholderSpendingLimitCategories'FuneralServicesCrematories
        | [<JsonUnionCase("furniture_home_furnishings_and_equipment_stores_except_appliances")>] IssuingCardholderSpendingLimitCategories'FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | [<JsonUnionCase("furniture_repair_refinishing")>] IssuingCardholderSpendingLimitCategories'FurnitureRepairRefinishing
        | [<JsonUnionCase("furriers_and_fur_shops")>] IssuingCardholderSpendingLimitCategories'FurriersAndFurShops
        | [<JsonUnionCase("general_services")>] IssuingCardholderSpendingLimitCategories'GeneralServices
        | [<JsonUnionCase("gift_card_novelty_and_souvenir_shops")>] IssuingCardholderSpendingLimitCategories'GiftCardNoveltyAndSouvenirShops
        | [<JsonUnionCase("glass_paint_and_wallpaper_stores")>] IssuingCardholderSpendingLimitCategories'GlassPaintAndWallpaperStores
        | [<JsonUnionCase("glassware_crystal_stores")>] IssuingCardholderSpendingLimitCategories'GlasswareCrystalStores
        | [<JsonUnionCase("golf_courses_public")>] IssuingCardholderSpendingLimitCategories'GolfCoursesPublic
        | [<JsonUnionCase("government_services")>] IssuingCardholderSpendingLimitCategories'GovernmentServices
        | [<JsonUnionCase("grocery_stores_supermarkets")>] IssuingCardholderSpendingLimitCategories'GroceryStoresSupermarkets
        | [<JsonUnionCase("hardware_equipment_and_supplies")>] IssuingCardholderSpendingLimitCategories'HardwareEquipmentAndSupplies
        | [<JsonUnionCase("hardware_stores")>] IssuingCardholderSpendingLimitCategories'HardwareStores
        | [<JsonUnionCase("health_and_beauty_spas")>] IssuingCardholderSpendingLimitCategories'HealthAndBeautySpas
        | [<JsonUnionCase("hearing_aids_sales_and_supplies")>] IssuingCardholderSpendingLimitCategories'HearingAidsSalesAndSupplies
        | [<JsonUnionCase("heating_plumbing_a_c")>] IssuingCardholderSpendingLimitCategories'HeatingPlumbingAC
        | [<JsonUnionCase("hobby_toy_and_game_shops")>] IssuingCardholderSpendingLimitCategories'HobbyToyAndGameShops
        | [<JsonUnionCase("home_supply_warehouse_stores")>] IssuingCardholderSpendingLimitCategories'HomeSupplyWarehouseStores
        | [<JsonUnionCase("hospitals")>] IssuingCardholderSpendingLimitCategories'Hospitals
        | [<JsonUnionCase("hotels_motels_and_resorts")>] IssuingCardholderSpendingLimitCategories'HotelsMotelsAndResorts
        | [<JsonUnionCase("household_appliance_stores")>] IssuingCardholderSpendingLimitCategories'HouseholdApplianceStores
        | [<JsonUnionCase("industrial_supplies")>] IssuingCardholderSpendingLimitCategories'IndustrialSupplies
        | [<JsonUnionCase("information_retrieval_services")>] IssuingCardholderSpendingLimitCategories'InformationRetrievalServices
        | [<JsonUnionCase("insurance_default")>] IssuingCardholderSpendingLimitCategories'InsuranceDefault
        | [<JsonUnionCase("insurance_underwriting_premiums")>] IssuingCardholderSpendingLimitCategories'InsuranceUnderwritingPremiums
        | [<JsonUnionCase("intra_company_purchases")>] IssuingCardholderSpendingLimitCategories'IntraCompanyPurchases
        | [<JsonUnionCase("jewelry_stores_watches_clocks_and_silverware_stores")>] IssuingCardholderSpendingLimitCategories'JewelryStoresWatchesClocksAndSilverwareStores
        | [<JsonUnionCase("landscaping_services")>] IssuingCardholderSpendingLimitCategories'LandscapingServices
        | [<JsonUnionCase("laundries")>] IssuingCardholderSpendingLimitCategories'Laundries
        | [<JsonUnionCase("laundry_cleaning_services")>] IssuingCardholderSpendingLimitCategories'LaundryCleaningServices
        | [<JsonUnionCase("legal_services_attorneys")>] IssuingCardholderSpendingLimitCategories'LegalServicesAttorneys
        | [<JsonUnionCase("luggage_and_leather_goods_stores")>] IssuingCardholderSpendingLimitCategories'LuggageAndLeatherGoodsStores
        | [<JsonUnionCase("lumber_building_materials_stores")>] IssuingCardholderSpendingLimitCategories'LumberBuildingMaterialsStores
        | [<JsonUnionCase("manual_cash_disburse")>] IssuingCardholderSpendingLimitCategories'ManualCashDisburse
        | [<JsonUnionCase("marinas_service_and_supplies")>] IssuingCardholderSpendingLimitCategories'MarinasServiceAndSupplies
        | [<JsonUnionCase("masonry_stonework_and_plaster")>] IssuingCardholderSpendingLimitCategories'MasonryStoneworkAndPlaster
        | [<JsonUnionCase("massage_parlors")>] IssuingCardholderSpendingLimitCategories'MassageParlors
        | [<JsonUnionCase("medical_and_dental_labs")>] IssuingCardholderSpendingLimitCategories'MedicalAndDentalLabs
        | [<JsonUnionCase("medical_dental_ophthalmic_and_hospital_equipment_and_supplies")>] IssuingCardholderSpendingLimitCategories'MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | [<JsonUnionCase("medical_services")>] IssuingCardholderSpendingLimitCategories'MedicalServices
        | [<JsonUnionCase("membership_organizations")>] IssuingCardholderSpendingLimitCategories'MembershipOrganizations
        | [<JsonUnionCase("mens_and_boys_clothing_and_accessories_stores")>] IssuingCardholderSpendingLimitCategories'MensAndBoysClothingAndAccessoriesStores
        | [<JsonUnionCase("mens_womens_clothing_stores")>] IssuingCardholderSpendingLimitCategories'MensWomensClothingStores
        | [<JsonUnionCase("metal_service_centers")>] IssuingCardholderSpendingLimitCategories'MetalServiceCenters
        | [<JsonUnionCase("miscellaneous")>] IssuingCardholderSpendingLimitCategories'Miscellaneous
        | [<JsonUnionCase("miscellaneous_apparel_and_accessory_shops")>] IssuingCardholderSpendingLimitCategories'MiscellaneousApparelAndAccessoryShops
        | [<JsonUnionCase("miscellaneous_auto_dealers")>] IssuingCardholderSpendingLimitCategories'MiscellaneousAutoDealers
        | [<JsonUnionCase("miscellaneous_business_services")>] IssuingCardholderSpendingLimitCategories'MiscellaneousBusinessServices
        | [<JsonUnionCase("miscellaneous_food_stores")>] IssuingCardholderSpendingLimitCategories'MiscellaneousFoodStores
        | [<JsonUnionCase("miscellaneous_general_merchandise")>] IssuingCardholderSpendingLimitCategories'MiscellaneousGeneralMerchandise
        | [<JsonUnionCase("miscellaneous_general_services")>] IssuingCardholderSpendingLimitCategories'MiscellaneousGeneralServices
        | [<JsonUnionCase("miscellaneous_home_furnishing_specialty_stores")>] IssuingCardholderSpendingLimitCategories'MiscellaneousHomeFurnishingSpecialtyStores
        | [<JsonUnionCase("miscellaneous_publishing_and_printing")>] IssuingCardholderSpendingLimitCategories'MiscellaneousPublishingAndPrinting
        | [<JsonUnionCase("miscellaneous_recreation_services")>] IssuingCardholderSpendingLimitCategories'MiscellaneousRecreationServices
        | [<JsonUnionCase("miscellaneous_repair_shops")>] IssuingCardholderSpendingLimitCategories'MiscellaneousRepairShops
        | [<JsonUnionCase("miscellaneous_specialty_retail")>] IssuingCardholderSpendingLimitCategories'MiscellaneousSpecialtyRetail
        | [<JsonUnionCase("mobile_home_dealers")>] IssuingCardholderSpendingLimitCategories'MobileHomeDealers
        | [<JsonUnionCase("motion_picture_theaters")>] IssuingCardholderSpendingLimitCategories'MotionPictureTheaters
        | [<JsonUnionCase("motor_freight_carriers_and_trucking")>] IssuingCardholderSpendingLimitCategories'MotorFreightCarriersAndTrucking
        | [<JsonUnionCase("motor_homes_dealers")>] IssuingCardholderSpendingLimitCategories'MotorHomesDealers
        | [<JsonUnionCase("motor_vehicle_supplies_and_new_parts")>] IssuingCardholderSpendingLimitCategories'MotorVehicleSuppliesAndNewParts
        | [<JsonUnionCase("motorcycle_shops_and_dealers")>] IssuingCardholderSpendingLimitCategories'MotorcycleShopsAndDealers
        | [<JsonUnionCase("motorcycle_shops_dealers")>] IssuingCardholderSpendingLimitCategories'MotorcycleShopsDealers
        | [<JsonUnionCase("music_stores_musical_instruments_pianos_and_sheet_music")>] IssuingCardholderSpendingLimitCategories'MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | [<JsonUnionCase("news_dealers_and_newsstands")>] IssuingCardholderSpendingLimitCategories'NewsDealersAndNewsstands
        | [<JsonUnionCase("non_fi_money_orders")>] IssuingCardholderSpendingLimitCategories'NonFiMoneyOrders
        | [<JsonUnionCase("non_fi_stored_value_card_purchase_load")>] IssuingCardholderSpendingLimitCategories'NonFiStoredValueCardPurchaseLoad
        | [<JsonUnionCase("nondurable_goods")>] IssuingCardholderSpendingLimitCategories'NondurableGoods
        | [<JsonUnionCase("nurseries_lawn_and_garden_supply_stores")>] IssuingCardholderSpendingLimitCategories'NurseriesLawnAndGardenSupplyStores
        | [<JsonUnionCase("nursing_personal_care")>] IssuingCardholderSpendingLimitCategories'NursingPersonalCare
        | [<JsonUnionCase("office_and_commercial_furniture")>] IssuingCardholderSpendingLimitCategories'OfficeAndCommercialFurniture
        | [<JsonUnionCase("opticians_eyeglasses")>] IssuingCardholderSpendingLimitCategories'OpticiansEyeglasses
        | [<JsonUnionCase("optometrists_ophthalmologist")>] IssuingCardholderSpendingLimitCategories'OptometristsOphthalmologist
        | [<JsonUnionCase("orthopedic_goods_prosthetic_devices")>] IssuingCardholderSpendingLimitCategories'OrthopedicGoodsProstheticDevices
        | [<JsonUnionCase("osteopaths")>] IssuingCardholderSpendingLimitCategories'Osteopaths
        | [<JsonUnionCase("package_stores_beer_wine_and_liquor")>] IssuingCardholderSpendingLimitCategories'PackageStoresBeerWineAndLiquor
        | [<JsonUnionCase("paints_varnishes_and_supplies")>] IssuingCardholderSpendingLimitCategories'PaintsVarnishesAndSupplies
        | [<JsonUnionCase("parking_lots_garages")>] IssuingCardholderSpendingLimitCategories'ParkingLotsGarages
        | [<JsonUnionCase("passenger_railways")>] IssuingCardholderSpendingLimitCategories'PassengerRailways
        | [<JsonUnionCase("pawn_shops")>] IssuingCardholderSpendingLimitCategories'PawnShops
        | [<JsonUnionCase("pet_shops_pet_food_and_supplies")>] IssuingCardholderSpendingLimitCategories'PetShopsPetFoodAndSupplies
        | [<JsonUnionCase("petroleum_and_petroleum_products")>] IssuingCardholderSpendingLimitCategories'PetroleumAndPetroleumProducts
        | [<JsonUnionCase("photo_developing")>] IssuingCardholderSpendingLimitCategories'PhotoDeveloping
        | [<JsonUnionCase("photographic_photocopy_microfilm_equipment_and_supplies")>] IssuingCardholderSpendingLimitCategories'PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | [<JsonUnionCase("photographic_studios")>] IssuingCardholderSpendingLimitCategories'PhotographicStudios
        | [<JsonUnionCase("picture_video_production")>] IssuingCardholderSpendingLimitCategories'PictureVideoProduction
        | [<JsonUnionCase("piece_goods_notions_and_other_dry_goods")>] IssuingCardholderSpendingLimitCategories'PieceGoodsNotionsAndOtherDryGoods
        | [<JsonUnionCase("plumbing_heating_equipment_and_supplies")>] IssuingCardholderSpendingLimitCategories'PlumbingHeatingEquipmentAndSupplies
        | [<JsonUnionCase("political_organizations")>] IssuingCardholderSpendingLimitCategories'PoliticalOrganizations
        | [<JsonUnionCase("postal_services_government_only")>] IssuingCardholderSpendingLimitCategories'PostalServicesGovernmentOnly
        | [<JsonUnionCase("precious_stones_and_metals_watches_and_jewelry")>] IssuingCardholderSpendingLimitCategories'PreciousStonesAndMetalsWatchesAndJewelry
        | [<JsonUnionCase("professional_services")>] IssuingCardholderSpendingLimitCategories'ProfessionalServices
        | [<JsonUnionCase("public_warehousing_and_storage")>] IssuingCardholderSpendingLimitCategories'PublicWarehousingAndStorage
        | [<JsonUnionCase("quick_copy_repro_and_blueprint")>] IssuingCardholderSpendingLimitCategories'QuickCopyReproAndBlueprint
        | [<JsonUnionCase("railroads")>] IssuingCardholderSpendingLimitCategories'Railroads
        | [<JsonUnionCase("real_estate_agents_and_managers_rentals")>] IssuingCardholderSpendingLimitCategories'RealEstateAgentsAndManagersRentals
        | [<JsonUnionCase("record_stores")>] IssuingCardholderSpendingLimitCategories'RecordStores
        | [<JsonUnionCase("recreational_vehicle_rentals")>] IssuingCardholderSpendingLimitCategories'RecreationalVehicleRentals
        | [<JsonUnionCase("religious_goods_stores")>] IssuingCardholderSpendingLimitCategories'ReligiousGoodsStores
        | [<JsonUnionCase("religious_organizations")>] IssuingCardholderSpendingLimitCategories'ReligiousOrganizations
        | [<JsonUnionCase("roofing_siding_sheet_metal")>] IssuingCardholderSpendingLimitCategories'RoofingSidingSheetMetal
        | [<JsonUnionCase("secretarial_support_services")>] IssuingCardholderSpendingLimitCategories'SecretarialSupportServices
        | [<JsonUnionCase("security_brokers_dealers")>] IssuingCardholderSpendingLimitCategories'SecurityBrokersDealers
        | [<JsonUnionCase("service_stations")>] IssuingCardholderSpendingLimitCategories'ServiceStations
        | [<JsonUnionCase("sewing_needlework_fabric_and_piece_goods_stores")>] IssuingCardholderSpendingLimitCategories'SewingNeedleworkFabricAndPieceGoodsStores
        | [<JsonUnionCase("shoe_repair_hat_cleaning")>] IssuingCardholderSpendingLimitCategories'ShoeRepairHatCleaning
        | [<JsonUnionCase("shoe_stores")>] IssuingCardholderSpendingLimitCategories'ShoeStores
        | [<JsonUnionCase("small_appliance_repair")>] IssuingCardholderSpendingLimitCategories'SmallApplianceRepair
        | [<JsonUnionCase("snowmobile_dealers")>] IssuingCardholderSpendingLimitCategories'SnowmobileDealers
        | [<JsonUnionCase("special_trade_services")>] IssuingCardholderSpendingLimitCategories'SpecialTradeServices
        | [<JsonUnionCase("specialty_cleaning")>] IssuingCardholderSpendingLimitCategories'SpecialtyCleaning
        | [<JsonUnionCase("sporting_goods_stores")>] IssuingCardholderSpendingLimitCategories'SportingGoodsStores
        | [<JsonUnionCase("sporting_recreation_camps")>] IssuingCardholderSpendingLimitCategories'SportingRecreationCamps
        | [<JsonUnionCase("sports_and_riding_apparel_stores")>] IssuingCardholderSpendingLimitCategories'SportsAndRidingApparelStores
        | [<JsonUnionCase("sports_clubs_fields")>] IssuingCardholderSpendingLimitCategories'SportsClubsFields
        | [<JsonUnionCase("stamp_and_coin_stores")>] IssuingCardholderSpendingLimitCategories'StampAndCoinStores
        | [<JsonUnionCase("stationary_office_supplies_printing_and_writing_paper")>] IssuingCardholderSpendingLimitCategories'StationaryOfficeSuppliesPrintingAndWritingPaper
        | [<JsonUnionCase("stationery_stores_office_and_school_supply_stores")>] IssuingCardholderSpendingLimitCategories'StationeryStoresOfficeAndSchoolSupplyStores
        | [<JsonUnionCase("swimming_pools_sales")>] IssuingCardholderSpendingLimitCategories'SwimmingPoolsSales
        | [<JsonUnionCase("t_ui_travel_germany")>] IssuingCardholderSpendingLimitCategories'TUiTravelGermany
        | [<JsonUnionCase("tailors_alterations")>] IssuingCardholderSpendingLimitCategories'TailorsAlterations
        | [<JsonUnionCase("tax_payments_government_agencies")>] IssuingCardholderSpendingLimitCategories'TaxPaymentsGovernmentAgencies
        | [<JsonUnionCase("tax_preparation_services")>] IssuingCardholderSpendingLimitCategories'TaxPreparationServices
        | [<JsonUnionCase("taxicabs_limousines")>] IssuingCardholderSpendingLimitCategories'TaxicabsLimousines
        | [<JsonUnionCase("telecommunication_equipment_and_telephone_sales")>] IssuingCardholderSpendingLimitCategories'TelecommunicationEquipmentAndTelephoneSales
        | [<JsonUnionCase("telecommunication_services")>] IssuingCardholderSpendingLimitCategories'TelecommunicationServices
        | [<JsonUnionCase("telegraph_services")>] IssuingCardholderSpendingLimitCategories'TelegraphServices
        | [<JsonUnionCase("tent_and_awning_shops")>] IssuingCardholderSpendingLimitCategories'TentAndAwningShops
        | [<JsonUnionCase("testing_laboratories")>] IssuingCardholderSpendingLimitCategories'TestingLaboratories
        | [<JsonUnionCase("theatrical_ticket_agencies")>] IssuingCardholderSpendingLimitCategories'TheatricalTicketAgencies
        | [<JsonUnionCase("timeshares")>] IssuingCardholderSpendingLimitCategories'Timeshares
        | [<JsonUnionCase("tire_retreading_and_repair")>] IssuingCardholderSpendingLimitCategories'TireRetreadingAndRepair
        | [<JsonUnionCase("tolls_bridge_fees")>] IssuingCardholderSpendingLimitCategories'TollsBridgeFees
        | [<JsonUnionCase("tourist_attractions_and_exhibits")>] IssuingCardholderSpendingLimitCategories'TouristAttractionsAndExhibits
        | [<JsonUnionCase("towing_services")>] IssuingCardholderSpendingLimitCategories'TowingServices
        | [<JsonUnionCase("trailer_parks_campgrounds")>] IssuingCardholderSpendingLimitCategories'TrailerParksCampgrounds
        | [<JsonUnionCase("transportation_services")>] IssuingCardholderSpendingLimitCategories'TransportationServices
        | [<JsonUnionCase("travel_agencies_tour_operators")>] IssuingCardholderSpendingLimitCategories'TravelAgenciesTourOperators
        | [<JsonUnionCase("truck_stop_iteration")>] IssuingCardholderSpendingLimitCategories'TruckStopIteration
        | [<JsonUnionCase("truck_utility_trailer_rentals")>] IssuingCardholderSpendingLimitCategories'TruckUtilityTrailerRentals
        | [<JsonUnionCase("typesetting_plate_making_and_related_services")>] IssuingCardholderSpendingLimitCategories'TypesettingPlateMakingAndRelatedServices
        | [<JsonUnionCase("typewriter_stores")>] IssuingCardholderSpendingLimitCategories'TypewriterStores
        | [<JsonUnionCase("u_s_federal_government_agencies_or_departments")>] IssuingCardholderSpendingLimitCategories'USFederalGovernmentAgenciesOrDepartments
        | [<JsonUnionCase("uniforms_commercial_clothing")>] IssuingCardholderSpendingLimitCategories'UniformsCommercialClothing
        | [<JsonUnionCase("used_merchandise_and_secondhand_stores")>] IssuingCardholderSpendingLimitCategories'UsedMerchandiseAndSecondhandStores
        | [<JsonUnionCase("utilities")>] IssuingCardholderSpendingLimitCategories'Utilities
        | [<JsonUnionCase("variety_stores")>] IssuingCardholderSpendingLimitCategories'VarietyStores
        | [<JsonUnionCase("veterinary_services")>] IssuingCardholderSpendingLimitCategories'VeterinaryServices
        | [<JsonUnionCase("video_amusement_game_supplies")>] IssuingCardholderSpendingLimitCategories'VideoAmusementGameSupplies
        | [<JsonUnionCase("video_game_arcades")>] IssuingCardholderSpendingLimitCategories'VideoGameArcades
        | [<JsonUnionCase("video_tape_rental_stores")>] IssuingCardholderSpendingLimitCategories'VideoTapeRentalStores
        | [<JsonUnionCase("vocational_trade_schools")>] IssuingCardholderSpendingLimitCategories'VocationalTradeSchools
        | [<JsonUnionCase("watch_jewelry_repair")>] IssuingCardholderSpendingLimitCategories'WatchJewelryRepair
        | [<JsonUnionCase("welding_repair")>] IssuingCardholderSpendingLimitCategories'WeldingRepair
        | [<JsonUnionCase("wholesale_clubs")>] IssuingCardholderSpendingLimitCategories'WholesaleClubs
        | [<JsonUnionCase("wig_and_toupee_stores")>] IssuingCardholderSpendingLimitCategories'WigAndToupeeStores
        | [<JsonUnionCase("wires_money_orders")>] IssuingCardholderSpendingLimitCategories'WiresMoneyOrders
        | [<JsonUnionCase("womens_accessory_and_specialty_shops")>] IssuingCardholderSpendingLimitCategories'WomensAccessoryAndSpecialtyShops
        | [<JsonUnionCase("womens_ready_to_wear_stores")>] IssuingCardholderSpendingLimitCategories'WomensReadyToWearStores
        | [<JsonUnionCase("wrecking_and_salvage_yards")>] IssuingCardholderSpendingLimitCategories'WreckingAndSalvageYards

    and IssuingCardholderSpendingLimitInterval =
        | [<JsonUnionCase("all_time")>] IssuingCardholderSpendingLimitInterval'AllTime
        | [<JsonUnionCase("daily")>] IssuingCardholderSpendingLimitInterval'Daily
        | [<JsonUnionCase("monthly")>] IssuingCardholderSpendingLimitInterval'Monthly
        | [<JsonUnionCase("per_authorization")>] IssuingCardholderSpendingLimitInterval'PerAuthorization
        | [<JsonUnionCase("weekly")>] IssuingCardholderSpendingLimitInterval'Weekly
        | [<JsonUnionCase("yearly")>] IssuingCardholderSpendingLimitInterval'Yearly

    ///
    and IssuingCardholderVerification (document: IssuingCardholderIdDocument option) =

        member _.Document = document

    ///
    and IssuingDisputeCanceledEvidence (additionalDocumentation: Choice<string, File> option, canceledAt: int64 option, cancellationPolicyProvided: bool option, cancellationReason: string option, expectedAt: int64 option, explanation: string option, productDescription: string option, productType: IssuingDisputeCanceledEvidenceProductType option, returnStatus: IssuingDisputeCanceledEvidenceReturnStatus option, returnedAt: int64 option) =

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
        | [<JsonUnionCase("merchandise")>] IssuingDisputeCanceledEvidenceProductType'Merchandise
        | [<JsonUnionCase("service")>] IssuingDisputeCanceledEvidenceProductType'Service

    and IssuingDisputeCanceledEvidenceReturnStatus =
        | [<JsonUnionCase("merchant_rejected")>] IssuingDisputeCanceledEvidenceReturnStatus'MerchantRejected
        | [<JsonUnionCase("successful")>] IssuingDisputeCanceledEvidenceReturnStatus'Successful

    ///
    and IssuingDisputeDuplicateEvidence (additionalDocumentation: Choice<string, File> option, cardStatement: Choice<string, File> option, cashReceipt: Choice<string, File> option, checkImage: Choice<string, File> option, explanation: string option, originalTransaction: string option) =

        member _.AdditionalDocumentation = additionalDocumentation
        member _.CardStatement = cardStatement
        member _.CashReceipt = cashReceipt
        member _.CheckImage = checkImage
        member _.Explanation = explanation
        member _.OriginalTransaction = originalTransaction

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
        | [<JsonUnionCase("canceled")>] IssuingDisputeEvidenceReason'Canceled
        | [<JsonUnionCase("duplicate")>] IssuingDisputeEvidenceReason'Duplicate
        | [<JsonUnionCase("fraudulent")>] IssuingDisputeEvidenceReason'Fraudulent
        | [<JsonUnionCase("merchandise_not_as_described")>] IssuingDisputeEvidenceReason'MerchandiseNotAsDescribed
        | [<JsonUnionCase("not_received")>] IssuingDisputeEvidenceReason'NotReceived
        | [<JsonUnionCase("other")>] IssuingDisputeEvidenceReason'Other
        | [<JsonUnionCase("service_not_as_described")>] IssuingDisputeEvidenceReason'ServiceNotAsDescribed

    ///
    and IssuingDisputeFraudulentEvidence (additionalDocumentation: Choice<string, File> option, explanation: string option) =

        member _.AdditionalDocumentation = additionalDocumentation
        member _.Explanation = explanation

    ///
    and IssuingDisputeMerchandiseNotAsDescribedEvidence (additionalDocumentation: Choice<string, File> option, explanation: string option, receivedAt: int64 option, returnDescription: string option, returnStatus: IssuingDisputeMerchandiseNotAsDescribedEvidenceReturnStatus option, returnedAt: int64 option) =

        member _.AdditionalDocumentation = additionalDocumentation
        member _.Explanation = explanation
        member _.ReceivedAt = receivedAt
        member _.ReturnDescription = returnDescription
        member _.ReturnStatus = returnStatus
        member _.ReturnedAt = returnedAt

    and IssuingDisputeMerchandiseNotAsDescribedEvidenceReturnStatus =
        | [<JsonUnionCase("merchant_rejected")>] IssuingDisputeMerchandiseNotAsDescribedEvidenceReturnStatus'MerchantRejected
        | [<JsonUnionCase("successful")>] IssuingDisputeMerchandiseNotAsDescribedEvidenceReturnStatus'Successful

    ///
    and IssuingDisputeNotReceivedEvidence (additionalDocumentation: Choice<string, File> option, expectedAt: int64 option, explanation: string option, productDescription: string option, productType: IssuingDisputeNotReceivedEvidenceProductType option) =

        member _.AdditionalDocumentation = additionalDocumentation
        member _.ExpectedAt = expectedAt
        member _.Explanation = explanation
        member _.ProductDescription = productDescription
        member _.ProductType = productType

    and IssuingDisputeNotReceivedEvidenceProductType =
        | [<JsonUnionCase("merchandise")>] IssuingDisputeNotReceivedEvidenceProductType'Merchandise
        | [<JsonUnionCase("service")>] IssuingDisputeNotReceivedEvidenceProductType'Service

    ///
    and IssuingDisputeOtherEvidence (additionalDocumentation: Choice<string, File> option, explanation: string option, productDescription: string option, productType: IssuingDisputeOtherEvidenceProductType option) =

        member _.AdditionalDocumentation = additionalDocumentation
        member _.Explanation = explanation
        member _.ProductDescription = productDescription
        member _.ProductType = productType

    and IssuingDisputeOtherEvidenceProductType =
        | [<JsonUnionCase("merchandise")>] IssuingDisputeOtherEvidenceProductType'Merchandise
        | [<JsonUnionCase("service")>] IssuingDisputeOtherEvidenceProductType'Service

    ///
    and IssuingDisputeServiceNotAsDescribedEvidence (additionalDocumentation: Choice<string, File> option, canceledAt: int64 option, cancellationReason: string option, explanation: string option, receivedAt: int64 option) =

        member _.AdditionalDocumentation = additionalDocumentation
        member _.CanceledAt = canceledAt
        member _.CancellationReason = cancellationReason
        member _.Explanation = explanation
        member _.ReceivedAt = receivedAt

    ///
    and IssuingTransactionAmountDetails (atmFee: int64 option) =

        member _.AtmFee = atmFee

    ///
    and IssuingTransactionFlightData (departureAt: int64 option, passengerName: string option, refundable: bool option, segments: IssuingTransactionFlightDataLeg list option, travelAgency: string option) =

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
    and IssuingTransactionLodgingData (checkInAt: int64 option, nights: int64 option) =

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
    and IssuingTransactionReceiptData (description: string option, quantity: decimal option, total: int64 option, unitCost: int64 option) =

        member _.Description = description
        member _.Quantity = quantity
        member _.Total = total
        member _.UnitCost = unitCost

    ///A line item.
    and Item (amountSubtotal: int64 option, amountTotal: int64 option, currency: string, description: string, id: string, price: Price, quantity: int64 option, ?discounts: LineItemsDiscountAmount list, ?taxes: LineItemsTaxAmount list) =

        member _.AmountSubtotal = amountSubtotal
        member _.AmountTotal = amountTotal
        member _.Currency = currency
        member _.Description = description
        member _.Discounts = discounts
        member _.Id = id
        member _.Object = "item"
        member _.Price = price
        member _.Quantity = quantity
        member _.Taxes = taxes

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
        | [<JsonUnionCase("government_instrumentality")>] LegalEntityCompanyStructure'GovernmentInstrumentality
        | [<JsonUnionCase("governmental_unit")>] LegalEntityCompanyStructure'GovernmentalUnit
        | [<JsonUnionCase("incorporated_non_profit")>] LegalEntityCompanyStructure'IncorporatedNonProfit
        | [<JsonUnionCase("limited_liability_partnership")>] LegalEntityCompanyStructure'LimitedLiabilityPartnership
        | [<JsonUnionCase("multi_member_llc")>] LegalEntityCompanyStructure'MultiMemberLlc
        | [<JsonUnionCase("private_company")>] LegalEntityCompanyStructure'PrivateCompany
        | [<JsonUnionCase("private_corporation")>] LegalEntityCompanyStructure'PrivateCorporation
        | [<JsonUnionCase("private_partnership")>] LegalEntityCompanyStructure'PrivatePartnership
        | [<JsonUnionCase("public_company")>] LegalEntityCompanyStructure'PublicCompany
        | [<JsonUnionCase("public_corporation")>] LegalEntityCompanyStructure'PublicCorporation
        | [<JsonUnionCase("public_partnership")>] LegalEntityCompanyStructure'PublicPartnership
        | [<JsonUnionCase("sole_proprietorship")>] LegalEntityCompanyStructure'SoleProprietorship
        | [<JsonUnionCase("tax_exempt_government_instrumentality")>] LegalEntityCompanyStructure'TaxExemptGovernmentInstrumentality
        | [<JsonUnionCase("unincorporated_association")>] LegalEntityCompanyStructure'UnincorporatedAssociation
        | [<JsonUnionCase("unincorporated_non_profit")>] LegalEntityCompanyStructure'UnincorporatedNonProfit

    ///
    and LegalEntityCompanyVerification (document: LegalEntityCompanyVerificationDocument) =

        member _.Document = document

    ///
    and LegalEntityCompanyVerificationDocument (back: Choice<string, File> option, details: string option, detailsCode: string option, front: Choice<string, File> option) =

        member _.Back = back
        member _.Details = details
        member _.DetailsCode = detailsCode
        member _.Front = front

    ///
    and LegalEntityDob (day: int64 option, month: int64 option, year: int64 option) =

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
    and LegalEntityPersonVerificationDocument (back: Choice<string, File> option, details: string option, detailsCode: string option, front: Choice<string, File> option) =

        member _.Back = back
        member _.Details = details
        member _.DetailsCode = detailsCode
        member _.Front = front

    ///
    and Level3 (lineItems: Level3LineItems list, merchantReference: string, ?customerReference: string, ?shippingAddressZip: string, ?shippingAmount: int64, ?shippingFromZip: string) =

        member _.CustomerReference = customerReference
        member _.LineItems = lineItems
        member _.MerchantReference = merchantReference
        member _.ShippingAddressZip = shippingAddressZip
        member _.ShippingAmount = shippingAmount
        member _.ShippingFromZip = shippingFromZip

    ///
    and Level3LineItems (discountAmount: int64 option, productCode: string, productDescription: string, quantity: int64 option, taxAmount: int64 option, unitCost: int64 option) =

        member _.DiscountAmount = discountAmount
        member _.ProductCode = productCode
        member _.ProductDescription = productDescription
        member _.Quantity = quantity
        member _.TaxAmount = taxAmount
        member _.UnitCost = unitCost

    ///
    and LineItem (amount: int64, currency: string, description: string option, discountAmounts: DiscountsResourceDiscountAmount list option, discountable: bool, discounts: Choice<string, Discount> list option, id: string, livemode: bool, metadata: Map<string, string>, period: InvoiceLineItemPeriod, plan: Plan option, price: Price option, proration: bool, quantity: int64 option, subscription: string option, ``type``: LineItemType, ?invoiceItem: string, ?subscriptionItem: string, ?taxAmounts: InvoiceTaxAmount list, ?taxRates: TaxRate list) =

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
        member _.Object = "line_item"
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

    and LineItemType =
        | [<JsonUnionCase("invoiceitem")>] LineItemType'Invoiceitem
        | [<JsonUnionCase("subscription")>] LineItemType'Subscription

    ///
    and LineItemsDiscountAmount (amount: int64, discount: Discount) =

        member _.Amount = amount
        member _.Discount = discount

    ///
    and LineItemsTaxAmount (amount: int64, rate: TaxRate) =

        member _.Amount = amount
        member _.Rate = rate

    ///
    and LoginLink (created: int64, url: string) =

        member _.Created = created
        member _.Object = "login_link"
        member _.Url = url

    ///A Mandate is a record of the permission a customer has given you to debit their payment method.
    and Mandate (customerAcceptance: CustomerAcceptance, id: string, livemode: bool, paymentMethod: Choice<string, PaymentMethod>, paymentMethodDetails: MandatePaymentMethodDetails, status: MandateStatus, ``type``: MandateType, ?multiUse: MandateMultiUse, ?singleUse: MandateSingleUse) =

        member _.CustomerAcceptance = customerAcceptance
        member _.Id = id
        member _.Livemode = livemode
        member _.MultiUse = multiUse
        member _.Object = "mandate"
        member _.PaymentMethod = paymentMethod
        member _.PaymentMethodDetails = paymentMethodDetails
        member _.SingleUse = singleUse
        member _.Status = status
        member _.Type = ``type``

    and MandateStatus =
        | [<JsonUnionCase("active")>] MandateStatus'Active
        | [<JsonUnionCase("inactive")>] MandateStatus'Inactive
        | [<JsonUnionCase("pending")>] MandateStatus'Pending

    and MandateType =
        | [<JsonUnionCase("multi_use")>] MandateType'MultiUse
        | [<JsonUnionCase("single_use")>] MandateType'SingleUse

    ///
    and MandateAuBecsDebit (url: string) =

        member _.Url = url

    ///
    and MandateBacsDebit (networkStatus: MandateBacsDebitNetworkStatus, reference: string, url: string) =

        member _.NetworkStatus = networkStatus
        member _.Reference = reference
        member _.Url = url

    and MandateBacsDebitNetworkStatus =
        | [<JsonUnionCase("accepted")>] MandateBacsDebitNetworkStatus'Accepted
        | [<JsonUnionCase("pending")>] MandateBacsDebitNetworkStatus'Pending
        | [<JsonUnionCase("refused")>] MandateBacsDebitNetworkStatus'Refused
        | [<JsonUnionCase("revoked")>] MandateBacsDebitNetworkStatus'Revoked

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
    and MandateSingleUse (amount: int64, currency: string) =

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
    and Order (amount: int64, amountReturned: int64 option, application: string option, applicationFee: int64 option, charge: Choice<string, Charge> option, created: int64, currency: string, customer: Choice<string, Customer, DeletedCustomer> option, email: string option, id: string, items: OrderItem list, livemode: bool, metadata: Map<string, string> option, returns: Map<string, string> option, selectedShippingMethod: string option, shipping: Shipping option, shippingMethods: ShippingMethod list option, status: string, statusTransitions: StatusTransitions option, updated: int64 option, ?externalCouponCode: string, ?upstreamId: string) =

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
        member _.Object = "order"
        member _.Returns = returns
        member _.SelectedShippingMethod = selectedShippingMethod
        member _.Shipping = shipping
        member _.ShippingMethods = shippingMethods
        member _.Status = status
        member _.StatusTransitions = statusTransitions
        member _.Updated = updated
        member _.UpstreamId = upstreamId

    ///A representation of the constituent items of any given order. Can be used to
    ///represent [SKUs](https://stripe.com/docs/api#skus), shipping costs, or taxes owed on the order.
    ///
    ///Related guide: [Orders](https://stripe.com/docs/orders/guide).
    and OrderItem (amount: int64, currency: string, description: string, parent: Choice<string, Sku> option, quantity: int64 option, ``type``: string) =

        member _.Amount = amount
        member _.Currency = currency
        member _.Description = description
        member _.Object = "order_item"
        member _.Parent = parent
        member _.Quantity = quantity
        member _.Type = ``type``

    ///A return represents the full or partial return of a number of [order items](https://stripe.com/docs/api#order_items).
    ///Returns always belong to an order, and may optionally contain a refund.
    ///
    ///Related guide: [Handling Returns](https://stripe.com/docs/orders/guide#handling-returns).
    and OrderReturn (amount: int64, created: int64, currency: string, id: string, items: OrderItem list, livemode: bool, order: Choice<string, Order> option, refund: Choice<string, Refund> option) =

        member _.Amount = amount
        member _.Created = created
        member _.Currency = currency
        member _.Id = id
        member _.Items = items
        member _.Livemode = livemode
        member _.Object = "order_return"
        member _.Order = order
        member _.Refund = refund

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
    and PaymentIntent (amount: int64, amountCapturable: int64, amountReceived: int64, application: Choice<string, Application> option, applicationFeeAmount: int64 option, canceledAt: int64 option, cancellationReason: PaymentIntentCancellationReason option, captureMethod: PaymentIntentCaptureMethod, charges: Map<string, string>, clientSecret: string option, confirmationMethod: PaymentIntentConfirmationMethod, created: int64, currency: string, customer: Choice<string, Customer, DeletedCustomer> option, description: string option, id: string, invoice: Choice<string, Invoice> option, lastPaymentError: ApiErrors option, livemode: bool, metadata: Map<string, string>, nextAction: PaymentIntentNextAction option, onBehalfOf: Choice<string, Account> option, paymentMethod: Choice<string, PaymentMethod> option, paymentMethodOptions: PaymentIntentPaymentMethodOptions option, paymentMethodTypes: string list, receiptEmail: string option, review: Choice<string, Review> option, setupFutureUsage: PaymentIntentSetupFutureUsage option, shipping: Shipping option, source: Choice<string, PaymentSource, DeletedPaymentSource> option, statementDescriptor: string option, statementDescriptorSuffix: string option, status: PaymentIntentStatus, transferData: TransferData option, transferGroup: string option) =

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
        member _.Object = "payment_intent"
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
        | [<JsonUnionCase("abandoned")>] PaymentIntentCancellationReason'Abandoned
        | [<JsonUnionCase("automatic")>] PaymentIntentCancellationReason'Automatic
        | [<JsonUnionCase("duplicate")>] PaymentIntentCancellationReason'Duplicate
        | [<JsonUnionCase("failed_invoice")>] PaymentIntentCancellationReason'FailedInvoice
        | [<JsonUnionCase("fraudulent")>] PaymentIntentCancellationReason'Fraudulent
        | [<JsonUnionCase("requested_by_customer")>] PaymentIntentCancellationReason'RequestedByCustomer
        | [<JsonUnionCase("void_invoice")>] PaymentIntentCancellationReason'VoidInvoice

    and PaymentIntentCaptureMethod =
        | [<JsonUnionCase("automatic")>] PaymentIntentCaptureMethod'Automatic
        | [<JsonUnionCase("manual")>] PaymentIntentCaptureMethod'Manual

    and PaymentIntentConfirmationMethod =
        | [<JsonUnionCase("automatic")>] PaymentIntentConfirmationMethod'Automatic
        | [<JsonUnionCase("manual")>] PaymentIntentConfirmationMethod'Manual

    and PaymentIntentSetupFutureUsage =
        | [<JsonUnionCase("off_session")>] PaymentIntentSetupFutureUsage'OffSession
        | [<JsonUnionCase("on_session")>] PaymentIntentSetupFutureUsage'OnSession

    and PaymentIntentStatus =
        | [<JsonUnionCase("canceled")>] PaymentIntentStatus'Canceled
        | [<JsonUnionCase("processing")>] PaymentIntentStatus'Processing
        | [<JsonUnionCase("requires_action")>] PaymentIntentStatus'RequiresAction
        | [<JsonUnionCase("requires_capture")>] PaymentIntentStatus'RequiresCapture
        | [<JsonUnionCase("requires_confirmation")>] PaymentIntentStatus'RequiresConfirmation
        | [<JsonUnionCase("requires_payment_method")>] PaymentIntentStatus'RequiresPaymentMethod
        | [<JsonUnionCase("succeeded")>] PaymentIntentStatus'Succeeded

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
    and PaymentIntentNextActionDisplayOxxoDetails (expiresAfter: int64 option, hostedVoucherUrl: string option, number: string option) =

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
        | [<JsonUnionCase("amex")>] PaymentIntentPaymentMethodOptionsCardNetwork'Amex
        | [<JsonUnionCase("cartes_bancaires")>] PaymentIntentPaymentMethodOptionsCardNetwork'CartesBancaires
        | [<JsonUnionCase("diners")>] PaymentIntentPaymentMethodOptionsCardNetwork'Diners
        | [<JsonUnionCase("discover")>] PaymentIntentPaymentMethodOptionsCardNetwork'Discover
        | [<JsonUnionCase("interac")>] PaymentIntentPaymentMethodOptionsCardNetwork'Interac
        | [<JsonUnionCase("jcb")>] PaymentIntentPaymentMethodOptionsCardNetwork'Jcb
        | [<JsonUnionCase("mastercard")>] PaymentIntentPaymentMethodOptionsCardNetwork'Mastercard
        | [<JsonUnionCase("unionpay")>] PaymentIntentPaymentMethodOptionsCardNetwork'Unionpay
        | [<JsonUnionCase("unknown")>] PaymentIntentPaymentMethodOptionsCardNetwork'Unknown
        | [<JsonUnionCase("visa")>] PaymentIntentPaymentMethodOptionsCardNetwork'Visa

    and PaymentIntentPaymentMethodOptionsCardRequestThreeDSecure =
        | [<JsonUnionCase("any")>] PaymentIntentPaymentMethodOptionsCardRequestThreeDSecure'Any
        | [<JsonUnionCase("automatic")>] PaymentIntentPaymentMethodOptionsCardRequestThreeDSecure'Automatic
        | [<JsonUnionCase("challenge_only")>] PaymentIntentPaymentMethodOptionsCardRequestThreeDSecure'ChallengeOnly

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
    and PaymentMethod (billingDetails: BillingDetails, created: int64, customer: Choice<string, Customer> option, id: string, livemode: bool, metadata: Map<string, string> option, ``type``: PaymentMethodType, ?alipay: PaymentFlowsPrivatePaymentMethodsAlipay, ?auBecsDebit: PaymentMethodAuBecsDebit, ?bacsDebit: PaymentMethodBacsDebit, ?bancontact: PaymentMethodBancontact, ?card: PaymentMethodCard, ?cardPresent: PaymentMethodCardPresent, ?eps: PaymentMethodEps, ?fpx: PaymentMethodFpx, ?giropay: PaymentMethodGiropay, ?grabpay: PaymentMethodGrabpay, ?ideal: PaymentMethodIdeal, ?interacPresent: PaymentMethodInteracPresent, ?oxxo: PaymentMethodOxxo, ?p24: PaymentMethodP24, ?sepaDebit: PaymentMethodSepaDebit, ?sofort: PaymentMethodSofort) =

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
        member _.Object = "payment_method"
        member _.Oxxo = oxxo
        member _.P24 = p24
        member _.SepaDebit = sepaDebit
        member _.Sofort = sofort
        member _.Type = ``type``

    and PaymentMethodType =
        | [<JsonUnionCase("alipay")>] PaymentMethodType'Alipay
        | [<JsonUnionCase("au_becs_debit")>] PaymentMethodType'AuBecsDebit
        | [<JsonUnionCase("bacs_debit")>] PaymentMethodType'BacsDebit
        | [<JsonUnionCase("bancontact")>] PaymentMethodType'Bancontact
        | [<JsonUnionCase("card")>] PaymentMethodType'Card
        | [<JsonUnionCase("card_present")>] PaymentMethodType'CardPresent
        | [<JsonUnionCase("eps")>] PaymentMethodType'Eps
        | [<JsonUnionCase("fpx")>] PaymentMethodType'Fpx
        | [<JsonUnionCase("giropay")>] PaymentMethodType'Giropay
        | [<JsonUnionCase("grabpay")>] PaymentMethodType'Grabpay
        | [<JsonUnionCase("ideal")>] PaymentMethodType'Ideal
        | [<JsonUnionCase("interac_present")>] PaymentMethodType'InteracPresent
        | [<JsonUnionCase("oxxo")>] PaymentMethodType'Oxxo
        | [<JsonUnionCase("p24")>] PaymentMethodType'P24
        | [<JsonUnionCase("sepa_debit")>] PaymentMethodType'SepaDebit
        | [<JsonUnionCase("sofort")>] PaymentMethodType'Sofort

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
    and PaymentMethodCard (brand: PaymentMethodCardBrand, checks: PaymentMethodCardChecks option, country: string option, expMonth: int64, expYear: int64, funding: PaymentMethodCardFunding, last4: string, networks: Networks option, threeDSecureUsage: ThreeDSecureUsage option, wallet: PaymentMethodCardWallet option, ?description: string option, ?fingerprint: string option, ?iin: string option, ?issuer: string option) =

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
        | [<JsonUnionCase("amex")>] PaymentMethodCardBrand'Amex
        | [<JsonUnionCase("diners")>] PaymentMethodCardBrand'Diners
        | [<JsonUnionCase("discover")>] PaymentMethodCardBrand'Discover
        | [<JsonUnionCase("jcb")>] PaymentMethodCardBrand'Jcb
        | [<JsonUnionCase("mastercard")>] PaymentMethodCardBrand'Mastercard
        | [<JsonUnionCase("unionpay")>] PaymentMethodCardBrand'Unionpay
        | [<JsonUnionCase("visa")>] PaymentMethodCardBrand'Visa
        | [<JsonUnionCase("unknown")>] PaymentMethodCardBrand'Unknown

    and PaymentMethodCardFunding =
        | [<JsonUnionCase("credit")>] PaymentMethodCardFunding'Credit
        | [<JsonUnionCase("debit")>] PaymentMethodCardFunding'Debit
        | [<JsonUnionCase("prepaid")>] PaymentMethodCardFunding'Prepaid
        | [<JsonUnionCase("unknown")>] PaymentMethodCardFunding'Unknown

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
        | [<JsonUnionCase("amex_express_checkout")>] PaymentMethodCardWalletType'AmexExpressCheckout
        | [<JsonUnionCase("apple_pay")>] PaymentMethodCardWalletType'ApplePay
        | [<JsonUnionCase("google_pay")>] PaymentMethodCardWalletType'GooglePay
        | [<JsonUnionCase("masterpass")>] PaymentMethodCardWalletType'Masterpass
        | [<JsonUnionCase("samsung_pay")>] PaymentMethodCardWalletType'SamsungPay
        | [<JsonUnionCase("visa_checkout")>] PaymentMethodCardWalletType'VisaCheckout

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
        | [<JsonUnionCase("company")>] PaymentMethodDetailsAchDebitAccountHolderType'Company
        | [<JsonUnionCase("individual")>] PaymentMethodDetailsAchDebitAccountHolderType'Individual

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
    and PaymentMethodDetailsBancontact (bankCode: string option, bankName: string option, bic: string option, generatedSepaDebit: Choice<string, PaymentMethod> option, generatedSepaDebitMandate: Choice<string, Mandate> option, ibanLast4: string option, preferredLanguage: PaymentMethodDetailsBancontactPreferredLanguage option, verifiedName: string option) =

        member _.BankCode = bankCode
        member _.BankName = bankName
        member _.Bic = bic
        member _.GeneratedSepaDebit = generatedSepaDebit
        member _.GeneratedSepaDebitMandate = generatedSepaDebitMandate
        member _.IbanLast4 = ibanLast4
        member _.PreferredLanguage = preferredLanguage
        member _.VerifiedName = verifiedName

    and PaymentMethodDetailsBancontactPreferredLanguage =
        | [<JsonUnionCase("de")>] PaymentMethodDetailsBancontactPreferredLanguage'De
        | [<JsonUnionCase("en")>] PaymentMethodDetailsBancontactPreferredLanguage'En
        | [<JsonUnionCase("fr")>] PaymentMethodDetailsBancontactPreferredLanguage'Fr
        | [<JsonUnionCase("nl")>] PaymentMethodDetailsBancontactPreferredLanguage'Nl

    ///
    and PaymentMethodDetailsCard (brand: PaymentMethodDetailsCardBrand option, checks: PaymentMethodDetailsCardChecks option, country: string option, expMonth: int64, expYear: int64, funding: PaymentMethodDetailsCardFunding option, installments: PaymentMethodDetailsCardInstallments option, last4: string option, network: PaymentMethodDetailsCardNetwork option, threeDSecure: ThreeDSecureDetails option, wallet: PaymentMethodDetailsCardWallet option, ?description: string option, ?fingerprint: string option, ?iin: string option, ?issuer: string option, ?moto: bool option) =

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
        | [<JsonUnionCase("amex")>] PaymentMethodDetailsCardBrand'Amex
        | [<JsonUnionCase("diners")>] PaymentMethodDetailsCardBrand'Diners
        | [<JsonUnionCase("discover")>] PaymentMethodDetailsCardBrand'Discover
        | [<JsonUnionCase("jcb")>] PaymentMethodDetailsCardBrand'Jcb
        | [<JsonUnionCase("mastercard")>] PaymentMethodDetailsCardBrand'Mastercard
        | [<JsonUnionCase("unionpay")>] PaymentMethodDetailsCardBrand'Unionpay
        | [<JsonUnionCase("visa")>] PaymentMethodDetailsCardBrand'Visa
        | [<JsonUnionCase("unknown")>] PaymentMethodDetailsCardBrand'Unknown

    and PaymentMethodDetailsCardFunding =
        | [<JsonUnionCase("credit")>] PaymentMethodDetailsCardFunding'Credit
        | [<JsonUnionCase("debit")>] PaymentMethodDetailsCardFunding'Debit
        | [<JsonUnionCase("prepaid")>] PaymentMethodDetailsCardFunding'Prepaid
        | [<JsonUnionCase("unknown")>] PaymentMethodDetailsCardFunding'Unknown

    and PaymentMethodDetailsCardNetwork =
        | [<JsonUnionCase("amex")>] PaymentMethodDetailsCardNetwork'Amex
        | [<JsonUnionCase("cartes_bancaires")>] PaymentMethodDetailsCardNetwork'CartesBancaires
        | [<JsonUnionCase("diners")>] PaymentMethodDetailsCardNetwork'Diners
        | [<JsonUnionCase("discover")>] PaymentMethodDetailsCardNetwork'Discover
        | [<JsonUnionCase("interac")>] PaymentMethodDetailsCardNetwork'Interac
        | [<JsonUnionCase("jcb")>] PaymentMethodDetailsCardNetwork'Jcb
        | [<JsonUnionCase("mastercard")>] PaymentMethodDetailsCardNetwork'Mastercard
        | [<JsonUnionCase("unionpay")>] PaymentMethodDetailsCardNetwork'Unionpay
        | [<JsonUnionCase("visa")>] PaymentMethodDetailsCardNetwork'Visa
        | [<JsonUnionCase("unknown")>] PaymentMethodDetailsCardNetwork'Unknown

    ///
    and PaymentMethodDetailsCardChecks (addressLine1Check: string option, addressPostalCodeCheck: string option, cvcCheck: string option) =

        member _.AddressLine1Check = addressLine1Check
        member _.AddressPostalCodeCheck = addressPostalCodeCheck
        member _.CvcCheck = cvcCheck

    ///
    and PaymentMethodDetailsCardInstallments (plan: PaymentMethodDetailsCardInstallmentsPlan option) =

        member _.Plan = plan

    ///
    and PaymentMethodDetailsCardInstallmentsPlan (count: int64 option, interval: PaymentMethodDetailsCardInstallmentsPlanInterval option, ``type``: PaymentMethodDetailsCardInstallmentsPlanType) =

        member _.Count = count
        member _.Interval = interval
        member _.Type = ``type``

    and PaymentMethodDetailsCardInstallmentsPlanInterval =
        | [<JsonUnionCase("month")>] PaymentMethodDetailsCardInstallmentsPlanInterval'Month

    and PaymentMethodDetailsCardInstallmentsPlanType =
        | [<JsonUnionCase("fixed_count")>] PaymentMethodDetailsCardInstallmentsPlanType'FixedCount

    ///
    and PaymentMethodDetailsCardPresent (brand: PaymentMethodDetailsCardPresentBrand option, cardholderName: string option, country: string option, emvAuthData: string option, expMonth: int64, expYear: int64, fingerprint: string option, funding: PaymentMethodDetailsCardPresentFunding option, generatedCard: string option, last4: string option, network: PaymentMethodDetailsCardPresentNetwork option, readMethod: PaymentMethodDetailsCardPresentReadMethod option, receipt: PaymentMethodDetailsCardPresentReceipt option, ?description: string option, ?iin: string option, ?issuer: string option) =

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
        | [<JsonUnionCase("amex")>] PaymentMethodDetailsCardPresentBrand'Amex
        | [<JsonUnionCase("diners")>] PaymentMethodDetailsCardPresentBrand'Diners
        | [<JsonUnionCase("discover")>] PaymentMethodDetailsCardPresentBrand'Discover
        | [<JsonUnionCase("jcb")>] PaymentMethodDetailsCardPresentBrand'Jcb
        | [<JsonUnionCase("mastercard")>] PaymentMethodDetailsCardPresentBrand'Mastercard
        | [<JsonUnionCase("unionpay")>] PaymentMethodDetailsCardPresentBrand'Unionpay
        | [<JsonUnionCase("visa")>] PaymentMethodDetailsCardPresentBrand'Visa
        | [<JsonUnionCase("unknown")>] PaymentMethodDetailsCardPresentBrand'Unknown

    and PaymentMethodDetailsCardPresentFunding =
        | [<JsonUnionCase("credit")>] PaymentMethodDetailsCardPresentFunding'Credit
        | [<JsonUnionCase("debit")>] PaymentMethodDetailsCardPresentFunding'Debit
        | [<JsonUnionCase("prepaid")>] PaymentMethodDetailsCardPresentFunding'Prepaid
        | [<JsonUnionCase("unknown")>] PaymentMethodDetailsCardPresentFunding'Unknown

    and PaymentMethodDetailsCardPresentNetwork =
        | [<JsonUnionCase("amex")>] PaymentMethodDetailsCardPresentNetwork'Amex
        | [<JsonUnionCase("cartes_bancaires")>] PaymentMethodDetailsCardPresentNetwork'CartesBancaires
        | [<JsonUnionCase("diners")>] PaymentMethodDetailsCardPresentNetwork'Diners
        | [<JsonUnionCase("discover")>] PaymentMethodDetailsCardPresentNetwork'Discover
        | [<JsonUnionCase("interac")>] PaymentMethodDetailsCardPresentNetwork'Interac
        | [<JsonUnionCase("jcb")>] PaymentMethodDetailsCardPresentNetwork'Jcb
        | [<JsonUnionCase("mastercard")>] PaymentMethodDetailsCardPresentNetwork'Mastercard
        | [<JsonUnionCase("unionpay")>] PaymentMethodDetailsCardPresentNetwork'Unionpay
        | [<JsonUnionCase("visa")>] PaymentMethodDetailsCardPresentNetwork'Visa
        | [<JsonUnionCase("unknown")>] PaymentMethodDetailsCardPresentNetwork'Unknown

    and PaymentMethodDetailsCardPresentReadMethod =
        | [<JsonUnionCase("contact_emv")>] PaymentMethodDetailsCardPresentReadMethod'ContactEmv
        | [<JsonUnionCase("contactless_emv")>] PaymentMethodDetailsCardPresentReadMethod'ContactlessEmv
        | [<JsonUnionCase("contactless_magstripe_mode")>] PaymentMethodDetailsCardPresentReadMethod'ContactlessMagstripeMode
        | [<JsonUnionCase("magnetic_stripe_fallback")>] PaymentMethodDetailsCardPresentReadMethod'MagneticStripeFallback
        | [<JsonUnionCase("magnetic_stripe_track2")>] PaymentMethodDetailsCardPresentReadMethod'MagneticStripeTrack2

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
        | [<JsonUnionCase("checking")>] PaymentMethodDetailsCardPresentReceiptAccountType'Checking
        | [<JsonUnionCase("credit")>] PaymentMethodDetailsCardPresentReceiptAccountType'Credit
        | [<JsonUnionCase("prepaid")>] PaymentMethodDetailsCardPresentReceiptAccountType'Prepaid
        | [<JsonUnionCase("unknown")>] PaymentMethodDetailsCardPresentReceiptAccountType'Unknown

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
        | [<JsonUnionCase("amex_express_checkout")>] PaymentMethodDetailsCardWalletType'AmexExpressCheckout
        | [<JsonUnionCase("apple_pay")>] PaymentMethodDetailsCardWalletType'ApplePay
        | [<JsonUnionCase("google_pay")>] PaymentMethodDetailsCardWalletType'GooglePay
        | [<JsonUnionCase("masterpass")>] PaymentMethodDetailsCardWalletType'Masterpass
        | [<JsonUnionCase("samsung_pay")>] PaymentMethodDetailsCardWalletType'SamsungPay
        | [<JsonUnionCase("visa_checkout")>] PaymentMethodDetailsCardWalletType'VisaCheckout

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
        | [<JsonUnionCase("company")>] PaymentMethodDetailsFpxAccountHolderType'Company
        | [<JsonUnionCase("individual")>] PaymentMethodDetailsFpxAccountHolderType'Individual

    and PaymentMethodDetailsFpxBank =
        | [<JsonUnionCase("affin_bank")>] PaymentMethodDetailsFpxBank'AffinBank
        | [<JsonUnionCase("alliance_bank")>] PaymentMethodDetailsFpxBank'AllianceBank
        | [<JsonUnionCase("ambank")>] PaymentMethodDetailsFpxBank'Ambank
        | [<JsonUnionCase("bank_islam")>] PaymentMethodDetailsFpxBank'BankIslam
        | [<JsonUnionCase("bank_muamalat")>] PaymentMethodDetailsFpxBank'BankMuamalat
        | [<JsonUnionCase("bank_rakyat")>] PaymentMethodDetailsFpxBank'BankRakyat
        | [<JsonUnionCase("bsn")>] PaymentMethodDetailsFpxBank'Bsn
        | [<JsonUnionCase("cimb")>] PaymentMethodDetailsFpxBank'Cimb
        | [<JsonUnionCase("deutsche_bank")>] PaymentMethodDetailsFpxBank'DeutscheBank
        | [<JsonUnionCase("hong_leong_bank")>] PaymentMethodDetailsFpxBank'HongLeongBank
        | [<JsonUnionCase("hsbc")>] PaymentMethodDetailsFpxBank'Hsbc
        | [<JsonUnionCase("kfh")>] PaymentMethodDetailsFpxBank'Kfh
        | [<JsonUnionCase("maybank2e")>] PaymentMethodDetailsFpxBank'Maybank2e
        | [<JsonUnionCase("maybank2u")>] PaymentMethodDetailsFpxBank'Maybank2u
        | [<JsonUnionCase("ocbc")>] PaymentMethodDetailsFpxBank'Ocbc
        | [<JsonUnionCase("pb_enterprise")>] PaymentMethodDetailsFpxBank'PbEnterprise
        | [<JsonUnionCase("public_bank")>] PaymentMethodDetailsFpxBank'PublicBank
        | [<JsonUnionCase("rhb")>] PaymentMethodDetailsFpxBank'Rhb
        | [<JsonUnionCase("standard_chartered")>] PaymentMethodDetailsFpxBank'StandardChartered
        | [<JsonUnionCase("uob")>] PaymentMethodDetailsFpxBank'Uob

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
    and PaymentMethodDetailsIdeal (bank: PaymentMethodDetailsIdealBank option, bic: PaymentMethodDetailsIdealBic option, generatedSepaDebit: Choice<string, PaymentMethod> option, generatedSepaDebitMandate: Choice<string, Mandate> option, ibanLast4: string option, verifiedName: string option) =

        member _.Bank = bank
        member _.Bic = bic
        member _.GeneratedSepaDebit = generatedSepaDebit
        member _.GeneratedSepaDebitMandate = generatedSepaDebitMandate
        member _.IbanLast4 = ibanLast4
        member _.VerifiedName = verifiedName

    and PaymentMethodDetailsIdealBank =
        | [<JsonUnionCase("abn_amro")>] PaymentMethodDetailsIdealBank'AbnAmro
        | [<JsonUnionCase("asn_bank")>] PaymentMethodDetailsIdealBank'AsnBank
        | [<JsonUnionCase("bunq")>] PaymentMethodDetailsIdealBank'Bunq
        | [<JsonUnionCase("handelsbanken")>] PaymentMethodDetailsIdealBank'Handelsbanken
        | [<JsonUnionCase("ing")>] PaymentMethodDetailsIdealBank'Ing
        | [<JsonUnionCase("knab")>] PaymentMethodDetailsIdealBank'Knab
        | [<JsonUnionCase("moneyou")>] PaymentMethodDetailsIdealBank'Moneyou
        | [<JsonUnionCase("rabobank")>] PaymentMethodDetailsIdealBank'Rabobank
        | [<JsonUnionCase("regiobank")>] PaymentMethodDetailsIdealBank'Regiobank
        | [<JsonUnionCase("sns_bank")>] PaymentMethodDetailsIdealBank'SnsBank
        | [<JsonUnionCase("triodos_bank")>] PaymentMethodDetailsIdealBank'TriodosBank
        | [<JsonUnionCase("van_lanschot")>] PaymentMethodDetailsIdealBank'VanLanschot

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

    ///
    and PaymentMethodDetailsInteracPresent (brand: PaymentMethodDetailsInteracPresentBrand option, cardholderName: string option, country: string option, emvAuthData: string option, expMonth: int64, expYear: int64, fingerprint: string option, funding: PaymentMethodDetailsInteracPresentFunding option, generatedCard: string option, last4: string option, network: PaymentMethodDetailsInteracPresentNetwork option, preferredLocales: string list option, readMethod: PaymentMethodDetailsInteracPresentReadMethod option, receipt: PaymentMethodDetailsInteracPresentReceipt option, ?description: string option, ?iin: string option, ?issuer: string option) =

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
        | [<JsonUnionCase("interac")>] PaymentMethodDetailsInteracPresentBrand'Interac
        | [<JsonUnionCase("mastercard")>] PaymentMethodDetailsInteracPresentBrand'Mastercard
        | [<JsonUnionCase("visa")>] PaymentMethodDetailsInteracPresentBrand'Visa

    and PaymentMethodDetailsInteracPresentFunding =
        | [<JsonUnionCase("credit")>] PaymentMethodDetailsInteracPresentFunding'Credit
        | [<JsonUnionCase("debit")>] PaymentMethodDetailsInteracPresentFunding'Debit
        | [<JsonUnionCase("prepaid")>] PaymentMethodDetailsInteracPresentFunding'Prepaid
        | [<JsonUnionCase("unknown")>] PaymentMethodDetailsInteracPresentFunding'Unknown

    and PaymentMethodDetailsInteracPresentNetwork =
        | [<JsonUnionCase("amex")>] PaymentMethodDetailsInteracPresentNetwork'Amex
        | [<JsonUnionCase("cartes_bancaires")>] PaymentMethodDetailsInteracPresentNetwork'CartesBancaires
        | [<JsonUnionCase("diners")>] PaymentMethodDetailsInteracPresentNetwork'Diners
        | [<JsonUnionCase("discover")>] PaymentMethodDetailsInteracPresentNetwork'Discover
        | [<JsonUnionCase("interac")>] PaymentMethodDetailsInteracPresentNetwork'Interac
        | [<JsonUnionCase("jcb")>] PaymentMethodDetailsInteracPresentNetwork'Jcb
        | [<JsonUnionCase("mastercard")>] PaymentMethodDetailsInteracPresentNetwork'Mastercard
        | [<JsonUnionCase("unionpay")>] PaymentMethodDetailsInteracPresentNetwork'Unionpay
        | [<JsonUnionCase("visa")>] PaymentMethodDetailsInteracPresentNetwork'Visa
        | [<JsonUnionCase("unknown")>] PaymentMethodDetailsInteracPresentNetwork'Unknown

    and PaymentMethodDetailsInteracPresentReadMethod =
        | [<JsonUnionCase("contact_emv")>] PaymentMethodDetailsInteracPresentReadMethod'ContactEmv
        | [<JsonUnionCase("contactless_emv")>] PaymentMethodDetailsInteracPresentReadMethod'ContactlessEmv
        | [<JsonUnionCase("contactless_magstripe_mode")>] PaymentMethodDetailsInteracPresentReadMethod'ContactlessMagstripeMode
        | [<JsonUnionCase("magnetic_stripe_fallback")>] PaymentMethodDetailsInteracPresentReadMethod'MagneticStripeFallback
        | [<JsonUnionCase("magnetic_stripe_track2")>] PaymentMethodDetailsInteracPresentReadMethod'MagneticStripeTrack2

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
        | [<JsonUnionCase("checking")>] PaymentMethodDetailsInteracPresentReceiptAccountType'Checking
        | [<JsonUnionCase("savings")>] PaymentMethodDetailsInteracPresentReceiptAccountType'Savings
        | [<JsonUnionCase("unknown")>] PaymentMethodDetailsInteracPresentReceiptAccountType'Unknown

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
    and PaymentMethodDetailsSofort (bankCode: string option, bankName: string option, bic: string option, country: string option, generatedSepaDebit: Choice<string, PaymentMethod> option, generatedSepaDebitMandate: Choice<string, Mandate> option, ibanLast4: string option, preferredLanguage: PaymentMethodDetailsSofortPreferredLanguage option, verifiedName: string option) =

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
        | [<JsonUnionCase("de")>] PaymentMethodDetailsSofortPreferredLanguage'De
        | [<JsonUnionCase("en")>] PaymentMethodDetailsSofortPreferredLanguage'En
        | [<JsonUnionCase("es")>] PaymentMethodDetailsSofortPreferredLanguage'Es
        | [<JsonUnionCase("fr")>] PaymentMethodDetailsSofortPreferredLanguage'Fr
        | [<JsonUnionCase("it")>] PaymentMethodDetailsSofortPreferredLanguage'It
        | [<JsonUnionCase("nl")>] PaymentMethodDetailsSofortPreferredLanguage'Nl
        | [<JsonUnionCase("pl")>] PaymentMethodDetailsSofortPreferredLanguage'Pl

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
        | [<JsonUnionCase("company")>] PaymentMethodFpxAccountHolderType'Company
        | [<JsonUnionCase("individual")>] PaymentMethodFpxAccountHolderType'Individual

    and PaymentMethodFpxBank =
        | [<JsonUnionCase("affin_bank")>] PaymentMethodFpxBank'AffinBank
        | [<JsonUnionCase("alliance_bank")>] PaymentMethodFpxBank'AllianceBank
        | [<JsonUnionCase("ambank")>] PaymentMethodFpxBank'Ambank
        | [<JsonUnionCase("bank_islam")>] PaymentMethodFpxBank'BankIslam
        | [<JsonUnionCase("bank_muamalat")>] PaymentMethodFpxBank'BankMuamalat
        | [<JsonUnionCase("bank_rakyat")>] PaymentMethodFpxBank'BankRakyat
        | [<JsonUnionCase("bsn")>] PaymentMethodFpxBank'Bsn
        | [<JsonUnionCase("cimb")>] PaymentMethodFpxBank'Cimb
        | [<JsonUnionCase("deutsche_bank")>] PaymentMethodFpxBank'DeutscheBank
        | [<JsonUnionCase("hong_leong_bank")>] PaymentMethodFpxBank'HongLeongBank
        | [<JsonUnionCase("hsbc")>] PaymentMethodFpxBank'Hsbc
        | [<JsonUnionCase("kfh")>] PaymentMethodFpxBank'Kfh
        | [<JsonUnionCase("maybank2e")>] PaymentMethodFpxBank'Maybank2e
        | [<JsonUnionCase("maybank2u")>] PaymentMethodFpxBank'Maybank2u
        | [<JsonUnionCase("ocbc")>] PaymentMethodFpxBank'Ocbc
        | [<JsonUnionCase("pb_enterprise")>] PaymentMethodFpxBank'PbEnterprise
        | [<JsonUnionCase("public_bank")>] PaymentMethodFpxBank'PublicBank
        | [<JsonUnionCase("rhb")>] PaymentMethodFpxBank'Rhb
        | [<JsonUnionCase("standard_chartered")>] PaymentMethodFpxBank'StandardChartered
        | [<JsonUnionCase("uob")>] PaymentMethodFpxBank'Uob

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
        | [<JsonUnionCase("abn_amro")>] PaymentMethodIdealBank'AbnAmro
        | [<JsonUnionCase("asn_bank")>] PaymentMethodIdealBank'AsnBank
        | [<JsonUnionCase("bunq")>] PaymentMethodIdealBank'Bunq
        | [<JsonUnionCase("handelsbanken")>] PaymentMethodIdealBank'Handelsbanken
        | [<JsonUnionCase("ing")>] PaymentMethodIdealBank'Ing
        | [<JsonUnionCase("knab")>] PaymentMethodIdealBank'Knab
        | [<JsonUnionCase("moneyou")>] PaymentMethodIdealBank'Moneyou
        | [<JsonUnionCase("rabobank")>] PaymentMethodIdealBank'Rabobank
        | [<JsonUnionCase("regiobank")>] PaymentMethodIdealBank'Regiobank
        | [<JsonUnionCase("sns_bank")>] PaymentMethodIdealBank'SnsBank
        | [<JsonUnionCase("triodos_bank")>] PaymentMethodIdealBank'TriodosBank
        | [<JsonUnionCase("van_lanschot")>] PaymentMethodIdealBank'VanLanschot

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
        | [<JsonUnionCase("de")>] PaymentMethodOptionsBancontactPreferredLanguage'De
        | [<JsonUnionCase("en")>] PaymentMethodOptionsBancontactPreferredLanguage'En
        | [<JsonUnionCase("fr")>] PaymentMethodOptionsBancontactPreferredLanguage'Fr
        | [<JsonUnionCase("nl")>] PaymentMethodOptionsBancontactPreferredLanguage'Nl

    ///
    and PaymentMethodOptionsCardInstallments (availablePlans: PaymentMethodDetailsCardInstallmentsPlan list option, enabled: bool, plan: PaymentMethodDetailsCardInstallmentsPlan option) =

        member _.AvailablePlans = availablePlans
        member _.Enabled = enabled
        member _.Plan = plan

    ///
    and PaymentMethodOptionsOxxo (expiresAfterDays: int64) =

        member _.ExpiresAfterDays = expiresAfterDays

    ///
    and PaymentMethodOptionsP24 (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and PaymentMethodOptionsSofort (preferredLanguage: PaymentMethodOptionsSofortPreferredLanguage option) =

        member _.PreferredLanguage = preferredLanguage

    and PaymentMethodOptionsSofortPreferredLanguage =
        | [<JsonUnionCase("de")>] PaymentMethodOptionsSofortPreferredLanguage'De
        | [<JsonUnionCase("en")>] PaymentMethodOptionsSofortPreferredLanguage'En
        | [<JsonUnionCase("es")>] PaymentMethodOptionsSofortPreferredLanguage'Es
        | [<JsonUnionCase("fr")>] PaymentMethodOptionsSofortPreferredLanguage'Fr
        | [<JsonUnionCase("it")>] PaymentMethodOptionsSofortPreferredLanguage'It
        | [<JsonUnionCase("nl")>] PaymentMethodOptionsSofortPreferredLanguage'Nl
        | [<JsonUnionCase("pl")>] PaymentMethodOptionsSofortPreferredLanguage'Pl

    ///
    and PaymentMethodOxxo (?undefined: string list) =

        member _.Undefined = undefined

    ///
    and PaymentMethodP24 (bank: PaymentMethodP24Bank option) =

        member _.Bank = bank

    and PaymentMethodP24Bank =
        | [<JsonUnionCase("alior_bank")>] PaymentMethodP24Bank'AliorBank
        | [<JsonUnionCase("bank_millennium")>] PaymentMethodP24Bank'BankMillennium
        | [<JsonUnionCase("bank_nowy_bfg_sa")>] PaymentMethodP24Bank'BankNowyBfgSa
        | [<JsonUnionCase("bank_pekao_sa")>] PaymentMethodP24Bank'BankPekaoSa
        | [<JsonUnionCase("banki_spbdzielcze")>] PaymentMethodP24Bank'BankiSpbdzielcze
        | [<JsonUnionCase("blik")>] PaymentMethodP24Bank'Blik
        | [<JsonUnionCase("bnp_paribas")>] PaymentMethodP24Bank'BnpParibas
        | [<JsonUnionCase("boz")>] PaymentMethodP24Bank'Boz
        | [<JsonUnionCase("citi_handlowy")>] PaymentMethodP24Bank'CitiHandlowy
        | [<JsonUnionCase("credit_agricole")>] PaymentMethodP24Bank'CreditAgricole
        | [<JsonUnionCase("envelobank")>] PaymentMethodP24Bank'Envelobank
        | [<JsonUnionCase("etransfer_pocztowy24")>] PaymentMethodP24Bank'EtransferPocztowy24
        | [<JsonUnionCase("getin_bank")>] PaymentMethodP24Bank'GetinBank
        | [<JsonUnionCase("ideabank")>] PaymentMethodP24Bank'Ideabank
        | [<JsonUnionCase("ing")>] PaymentMethodP24Bank'Ing
        | [<JsonUnionCase("inteligo")>] PaymentMethodP24Bank'Inteligo
        | [<JsonUnionCase("mbank_mtransfer")>] PaymentMethodP24Bank'MbankMtransfer
        | [<JsonUnionCase("nest_przelew")>] PaymentMethodP24Bank'NestPrzelew
        | [<JsonUnionCase("noble_pay")>] PaymentMethodP24Bank'NoblePay
        | [<JsonUnionCase("pbac_z_ipko")>] PaymentMethodP24Bank'PbacZIpko
        | [<JsonUnionCase("plus_bank")>] PaymentMethodP24Bank'PlusBank
        | [<JsonUnionCase("santander_przelew24")>] PaymentMethodP24Bank'SantanderPrzelew24
        | [<JsonUnionCase("tmobile_usbugi_bankowe")>] PaymentMethodP24Bank'TmobileUsbugiBankowe
        | [<JsonUnionCase("toyota_bank")>] PaymentMethodP24Bank'ToyotaBank
        | [<JsonUnionCase("volkswagen_bank")>] PaymentMethodP24Bank'VolkswagenBank

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
    and PaymentPagesCheckoutSessionTotalDetails (amountDiscount: int64, amountTax: int64, ?breakdown: PaymentPagesCheckoutSessionTotalDetailsResourceBreakdown) =

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
    and Payout (amount: int64, arrivalDate: int64, automatic: bool, balanceTransaction: Choice<string, BalanceTransaction> option, created: int64, currency: string, description: string option, destination: Choice<string, ExternalAccount, DeletedExternalAccount> option, failureBalanceTransaction: Choice<string, BalanceTransaction> option, failureCode: string option, failureMessage: string option, id: string, livemode: bool, metadata: Map<string, string> option, method: string, originalPayout: Choice<string, Payout> option, reversedBy: Choice<string, Payout> option, sourceType: string, statementDescriptor: string option, status: string, ``type``: PayoutType) =

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
        member _.Object = "payout"
        member _.OriginalPayout = originalPayout
        member _.ReversedBy = reversedBy
        member _.SourceType = sourceType
        member _.StatementDescriptor = statementDescriptor
        member _.Status = status
        member _.Type = ``type``

    and PayoutType =
        | [<JsonUnionCase("bank_account")>] PayoutType'BankAccount
        | [<JsonUnionCase("card")>] PayoutType'Card

    ///
    and Period (``end``: int64 option, start: int64 option) =

        member _.End = ``end``
        member _.Start = start

    ///This is an object representing a person associated with a Stripe account.
    ///
    ///Related guide: [Handling Identity Verification with the API](https://stripe.com/docs/connect/identity-verification-api#person-information).
    and Person (created: int64, id: string, ?account: string, ?address: Address, ?addressKana: LegalEntityJapanAddress option, ?addressKanji: LegalEntityJapanAddress option, ?dob: LegalEntityDob, ?email: string option, ?firstName: string option, ?firstNameKana: string option, ?firstNameKanji: string option, ?gender: string option, ?idNumberProvided: bool, ?lastName: string option, ?lastNameKana: string option, ?lastNameKanji: string option, ?maidenName: string option, ?metadata: Map<string, string>, ?phone: string option, ?politicalExposure: PersonPoliticalExposure, ?relationship: PersonRelationship, ?requirements: PersonRequirements option, ?ssnLast4Provided: bool, ?verification: LegalEntityPersonVerification) =

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
        member _.Object = "person"
        member _.Phone = phone |> Option.flatten
        member _.PoliticalExposure = politicalExposure
        member _.Relationship = relationship
        member _.Requirements = requirements |> Option.flatten
        member _.SsnLast4Provided = ssnLast4Provided
        member _.Verification = verification

    and PersonPoliticalExposure =
        | [<JsonUnionCase("existing")>] PersonPoliticalExposure'Existing
        | [<JsonUnionCase("none")>] PersonPoliticalExposure'None

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
    and Plan (active: bool, aggregateUsage: PlanAggregateUsage option, amount: int64 option, amountDecimal: string option, billingScheme: PlanBillingScheme, created: int64, currency: string, id: string, interval: PlanInterval, intervalCount: int64, livemode: bool, metadata: Map<string, string> option, nickname: string option, product: Choice<string, Product, DeletedProduct> option, tiersMode: PlanTiersMode option, transformUsage: TransformUsage option, trialPeriodDays: int64 option, usageType: PlanUsageType, ?tiers: PlanTier list) =

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
        member _.Object = "plan"
        member _.Product = product
        member _.Tiers = tiers
        member _.TiersMode = tiersMode
        member _.TransformUsage = transformUsage
        member _.TrialPeriodDays = trialPeriodDays
        member _.UsageType = usageType

    and PlanAggregateUsage =
        | [<JsonUnionCase("last_during_period")>] PlanAggregateUsage'LastDuringPeriod
        | [<JsonUnionCase("last_ever")>] PlanAggregateUsage'LastEver
        | [<JsonUnionCase("max")>] PlanAggregateUsage'Max
        | [<JsonUnionCase("sum")>] PlanAggregateUsage'Sum

    and PlanBillingScheme =
        | [<JsonUnionCase("per_unit")>] PlanBillingScheme'PerUnit
        | [<JsonUnionCase("tiered")>] PlanBillingScheme'Tiered

    and PlanInterval =
        | [<JsonUnionCase("day")>] PlanInterval'Day
        | [<JsonUnionCase("month")>] PlanInterval'Month
        | [<JsonUnionCase("week")>] PlanInterval'Week
        | [<JsonUnionCase("year")>] PlanInterval'Year

    and PlanTiersMode =
        | [<JsonUnionCase("graduated")>] PlanTiersMode'Graduated
        | [<JsonUnionCase("volume")>] PlanTiersMode'Volume

    and PlanUsageType =
        | [<JsonUnionCase("licensed")>] PlanUsageType'Licensed
        | [<JsonUnionCase("metered")>] PlanUsageType'Metered

    ///
    and PlanTier (flatAmount: int64 option, flatAmountDecimal: string option, unitAmount: int64 option, unitAmountDecimal: string option, upTo: int64 option) =

        member _.FlatAmount = flatAmount
        member _.FlatAmountDecimal = flatAmountDecimal
        member _.UnitAmount = unitAmount
        member _.UnitAmountDecimal = unitAmountDecimal
        member _.UpTo = upTo

    ///
    and PlatformTaxFee (account: string, id: string, sourceTransaction: string, ``type``: string) =

        member _.Account = account
        member _.Id = id
        member _.Object = "platform_tax_fee"
        member _.SourceTransaction = sourceTransaction
        member _.Type = ``type``

    ///Prices define the unit cost, currency, and (optional) billing cycle for both recurring and one-time purchases of products.
    ///[Products](https://stripe.com/docs/api#products) help you track inventory or provisioning, and prices help you track payment terms. Different physical goods or levels of service should be represented by products, and pricing options should be represented by prices. This approach lets you change prices without having to change your provisioning scheme.
    ///
    ///For example, you might have a single "gold" product that has prices for $10/month, $100/year, and €9 once.
    ///
    ///Related guides: [Set up a subscription](https://stripe.com/docs/billing/subscriptions/set-up-subscription), [create an invoice](https://stripe.com/docs/billing/invoices/create), and more about [products and prices](https://stripe.com/docs/billing/prices-guide).
    and Price (active: bool, billingScheme: PriceBillingScheme, created: int64, currency: string, id: string, livemode: bool, lookupKey: string option, metadata: Map<string, string>, nickname: string option, product: Choice<string, Product, DeletedProduct>, recurring: Recurring option, tiersMode: PriceTiersMode option, transformQuantity: TransformQuantity option, ``type``: PriceType, unitAmount: int64 option, unitAmountDecimal: string option, ?tiers: PriceTier list) =

        member _.Active = active
        member _.BillingScheme = billingScheme
        member _.Created = created
        member _.Currency = currency
        member _.Id = id
        member _.Livemode = livemode
        member _.LookupKey = lookupKey
        member _.Metadata = metadata
        member _.Nickname = nickname
        member _.Object = "price"
        member _.Product = product
        member _.Recurring = recurring
        member _.Tiers = tiers
        member _.TiersMode = tiersMode
        member _.TransformQuantity = transformQuantity
        member _.Type = ``type``
        member _.UnitAmount = unitAmount
        member _.UnitAmountDecimal = unitAmountDecimal

    and PriceBillingScheme =
        | [<JsonUnionCase("per_unit")>] PriceBillingScheme'PerUnit
        | [<JsonUnionCase("tiered")>] PriceBillingScheme'Tiered

    and PriceTiersMode =
        | [<JsonUnionCase("graduated")>] PriceTiersMode'Graduated
        | [<JsonUnionCase("volume")>] PriceTiersMode'Volume

    and PriceType =
        | [<JsonUnionCase("one_time")>] PriceType'OneTime
        | [<JsonUnionCase("recurring")>] PriceType'Recurring

    ///
    and PriceTier (flatAmount: int64 option, flatAmountDecimal: string option, unitAmount: int64 option, unitAmountDecimal: string option, upTo: int64 option) =

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
    and Product (active: bool, attributes: string list option, caption: string option, created: int64, description: string option, id: string, images: string list, livemode: bool, metadata: Map<string, string>, name: string, packageDimensions: PackageDimensions option, shippable: bool option, statementDescriptor: string option, ``type``: ProductType, unitLabel: string option, updated: int64, url: string option, ?deactivateOn: string list) =

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
        member _.Object = "product"
        member _.PackageDimensions = packageDimensions
        member _.Shippable = shippable
        member _.StatementDescriptor = statementDescriptor
        member _.Type = ``type``
        member _.UnitLabel = unitLabel
        member _.Updated = updated
        member _.Url = url

    and ProductType =
        | [<JsonUnionCase("good")>] ProductType'Good
        | [<JsonUnionCase("service")>] ProductType'Service

    ///A Promotion Code represents a customer-redeemable code for a coupon. It can be used to
    ///create multiple codes for a single coupon.
    and PromotionCode (active: bool, code: string, coupon: Coupon, created: int64, customer: Choice<string, Customer, DeletedCustomer> option, expiresAt: int64 option, id: string, livemode: bool, maxRedemptions: int64 option, metadata: Map<string, string> option, restrictions: PromotionCodesResourceRestrictions, timesRedeemed: int64) =

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
        member _.Object = "promotion_code"
        member _.Restrictions = restrictions
        member _.TimesRedeemed = timesRedeemed

    ///
    and PromotionCodesResourceRestrictions (firstTimeTransaction: bool, minimumAmount: int64 option, minimumAmountCurrency: string option) =

        member _.FirstTimeTransaction = firstTimeTransaction
        member _.MinimumAmount = minimumAmount
        member _.MinimumAmountCurrency = minimumAmountCurrency

    ///An early fraud warning indicates that the card issuer has notified us that a
    ///charge may be fraudulent.
    ///
    ///Related guide: [Early Fraud Warnings](https://stripe.com/docs/disputes/measuring#early-fraud-warnings).
    and RadarEarlyFraudWarning (actionable: bool, charge: Choice<string, Charge>, created: int64, fraudType: string, id: string, livemode: bool) =

        member _.Actionable = actionable
        member _.Charge = charge
        member _.Created = created
        member _.FraudType = fraudType
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = "radar.early_fraud_warning"

    ///Value lists allow you to group values together which can then be referenced in rules.
    ///
    ///Related guide: [Default Stripe Lists](https://stripe.com/docs/radar/lists#managing-list-items).
    and RadarValueList (alias: string, created: int64, createdBy: string, id: string, itemType: RadarValueListItemType, listItems: Map<string, string>, livemode: bool, metadata: Map<string, string>, name: string) =

        member _.Alias = alias
        member _.Created = created
        member _.CreatedBy = createdBy
        member _.Id = id
        member _.ItemType = itemType
        member _.ListItems = listItems
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Name = name
        member _.Object = "radar.value_list"

    and RadarValueListItemType =
        | [<JsonUnionCase("card_bin")>] RadarValueListItemType'CardBin
        | [<JsonUnionCase("card_fingerprint")>] RadarValueListItemType'CardFingerprint
        | [<JsonUnionCase("case_sensitive_string")>] RadarValueListItemType'CaseSensitiveString
        | [<JsonUnionCase("country")>] RadarValueListItemType'Country
        | [<JsonUnionCase("email")>] RadarValueListItemType'Email
        | [<JsonUnionCase("ip_address")>] RadarValueListItemType'IpAddress
        | [<JsonUnionCase("string")>] RadarValueListItemType'String

    ///Value list items allow you to add specific values to a given Radar value list, which can then be used in rules.
    ///
    ///Related guide: [Managing List Items](https://stripe.com/docs/radar/lists#managing-list-items).
    and RadarValueListItem (created: int64, createdBy: string, id: string, livemode: bool, value: string, valueList: string) =

        member _.Created = created
        member _.CreatedBy = createdBy
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = "radar.value_list_item"
        member _.Value = value
        member _.ValueList = valueList

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
    and Recipient (activeAccount: BankAccount option, cards: Map<string, string> option, created: int64, defaultCard: Choice<string, Card> option, description: string option, email: string option, id: string, livemode: bool, metadata: Map<string, string>, migratedTo: Choice<string, Account> option, name: string option, ``type``: string, verified: bool, ?rolledBackFrom: Choice<string, Account>) =

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
        member _.Object = "recipient"
        member _.RolledBackFrom = rolledBackFrom
        member _.Type = ``type``
        member _.Verified = verified

    ///
    and Recurring (aggregateUsage: RecurringAggregateUsage option, interval: RecurringInterval, intervalCount: int64, trialPeriodDays: int64 option, usageType: RecurringUsageType) =

        member _.AggregateUsage = aggregateUsage
        member _.Interval = interval
        member _.IntervalCount = intervalCount
        member _.TrialPeriodDays = trialPeriodDays
        member _.UsageType = usageType

    and RecurringAggregateUsage =
        | [<JsonUnionCase("last_during_period")>] RecurringAggregateUsage'LastDuringPeriod
        | [<JsonUnionCase("last_ever")>] RecurringAggregateUsage'LastEver
        | [<JsonUnionCase("max")>] RecurringAggregateUsage'Max
        | [<JsonUnionCase("sum")>] RecurringAggregateUsage'Sum

    and RecurringInterval =
        | [<JsonUnionCase("day")>] RecurringInterval'Day
        | [<JsonUnionCase("month")>] RecurringInterval'Month
        | [<JsonUnionCase("week")>] RecurringInterval'Week
        | [<JsonUnionCase("year")>] RecurringInterval'Year

    and RecurringUsageType =
        | [<JsonUnionCase("licensed")>] RecurringUsageType'Licensed
        | [<JsonUnionCase("metered")>] RecurringUsageType'Metered

    ///`Refund` objects allow you to refund a charge that has previously been created
    ///but not yet refunded. Funds will be refunded to the credit or debit card that
    ///was originally charged.
    ///
    ///Related guide: [Refunds](https://stripe.com/docs/refunds).
    and Refund (amount: int64, balanceTransaction: Choice<string, BalanceTransaction> option, charge: Choice<string, Charge> option, created: int64, currency: string, id: string, metadata: Map<string, string> option, paymentIntent: Choice<string, PaymentIntent> option, reason: string option, receiptNumber: string option, sourceTransferReversal: Choice<string, TransferReversal> option, status: string option, transferReversal: Choice<string, TransferReversal> option, ?description: string, ?failureBalanceTransaction: Choice<string, BalanceTransaction>, ?failureReason: string) =

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
        member _.Object = "refund"
        member _.PaymentIntent = paymentIntent
        member _.Reason = reason
        member _.ReceiptNumber = receiptNumber
        member _.SourceTransferReversal = sourceTransferReversal
        member _.Status = status
        member _.TransferReversal = transferReversal

    ///The Report Run object represents an instance of a report type generated with
    ///specific run parameters. Once the object is created, Stripe begins processing the report.
    ///When the report has finished running, it will give you a reference to a file
    ///where you can retrieve your results. For an overview, see
    ///[API Access to Reports](https://stripe.com/docs/reporting/statements/api).
    ///
    ///Note that reports can only be run based on your live-mode data (not test-mode
    ///data), and thus related requests must be made with a
    ///[live-mode API key](https://stripe.com/docs/keys#test-live-modes).
    and ReportingReportRun (created: int64, error: string option, id: string, livemode: bool, parameters: FinancialReportingFinanceReportRunRunParameters, reportType: string, result: File option, status: string, succeededAt: int64 option) =

        member _.Created = created
        member _.Error = error
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = "reporting.report_run"
        member _.Parameters = parameters
        member _.ReportType = reportType
        member _.Result = result
        member _.Status = status
        member _.SucceededAt = succeededAt

    ///The Report Type resource corresponds to a particular type of report, such as
    ///the "Activity summary" or "Itemized payouts" reports. These objects are
    ///identified by an ID belonging to a set of enumerated values. See
    ///[API Access to Reports documentation](https://stripe.com/docs/reporting/statements/api)
    ///for those Report Type IDs, along with required and optional parameters.
    ///
    ///Note that reports can only be run based on your live-mode data (not test-mode
    ///data), and thus related requests must be made with a
    ///[live-mode API key](https://stripe.com/docs/keys#test-live-modes).
    and ReportingReportType (dataAvailableEnd: int64, dataAvailableStart: int64, defaultColumns: string list option, id: string, name: string, updated: int64, version: int64) =

        member _.DataAvailableEnd = dataAvailableEnd
        member _.DataAvailableStart = dataAvailableStart
        member _.DefaultColumns = defaultColumns
        member _.Id = id
        member _.Name = name
        member _.Object = "reporting.report_type"
        member _.Updated = updated
        member _.Version = version

    ///
    and ReserveTransaction (amount: int64, currency: string, description: string option, id: string) =

        member _.Amount = amount
        member _.Currency = currency
        member _.Description = description
        member _.Id = id
        member _.Object = "reserve_transaction"

    ///Reviews can be used to supplement automated fraud detection with human expertise.
    ///
    ///Learn more about [Radar](/radar) and reviewing payments
    ///[here](https://stripe.com/docs/radar/reviews).
    and Review (billingZip: string option, charge: Choice<string, Charge> option, closedReason: ReviewClosedReason option, created: int64, id: string, ipAddress: string option, ipAddressLocation: RadarReviewResourceLocation option, livemode: bool, ``open``: bool, openedReason: ReviewOpenedReason, reason: string, session: RadarReviewResourceSession option, ?paymentIntent: Choice<string, PaymentIntent>) =

        member _.BillingZip = billingZip
        member _.Charge = charge
        member _.ClosedReason = closedReason
        member _.Created = created
        member _.Id = id
        member _.IpAddress = ipAddress
        member _.IpAddressLocation = ipAddressLocation
        member _.Livemode = livemode
        member _.Object = "review"
        member _.Open = ``open``
        member _.OpenedReason = openedReason
        member _.PaymentIntent = paymentIntent
        member _.Reason = reason
        member _.Session = session

    and ReviewClosedReason =
        | [<JsonUnionCase("approved")>] ReviewClosedReason'Approved
        | [<JsonUnionCase("disputed")>] ReviewClosedReason'Disputed
        | [<JsonUnionCase("refunded")>] ReviewClosedReason'Refunded
        | [<JsonUnionCase("refunded_as_fraud")>] ReviewClosedReason'RefundedAsFraud

    and ReviewOpenedReason =
        | [<JsonUnionCase("manual")>] ReviewOpenedReason'Manual
        | [<JsonUnionCase("rule")>] ReviewOpenedReason'Rule

    ///
    and Rule (action: string, id: string, predicate: string) =

        member _.Action = action
        member _.Id = id
        member _.Predicate = predicate

    ///If you have [scheduled a Sigma query](https://stripe.com/docs/sigma/scheduled-queries), you'll
    ///receive a `sigma.scheduled_query_run.created` webhook each time the query
    ///runs. The webhook contains a `ScheduledQueryRun` object, which you can use to
    ///retrieve the query results.
    and ScheduledQueryRun (created: int64, dataLoadTime: int64, file: File option, id: string, livemode: bool, resultAvailableUntil: int64, sql: string, status: string, title: string, ?error: SigmaScheduledQueryRunError) =

        member _.Created = created
        member _.DataLoadTime = dataLoadTime
        member _.Error = error
        member _.File = file
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = "scheduled_query_run"
        member _.ResultAvailableUntil = resultAvailableUntil
        member _.Sql = sql
        member _.Status = status
        member _.Title = title

    ///
    and SepaDebitGeneratedFrom (charge: Choice<string, Charge> option, setupAttempt: Choice<string, SetupAttempt> option) =

        member _.Charge = charge
        member _.SetupAttempt = setupAttempt

    ///A SetupAttempt describes one attempted confirmation of a SetupIntent,
    ///whether that confirmation was successful or unsuccessful. You can use
    ///SetupAttempts to inspect details of a specific attempt at setting up a
    ///payment method using a SetupIntent.
    and SetupAttempt (application: Choice<string, Application> option, created: int64, customer: Choice<string, Customer, DeletedCustomer> option, id: string, livemode: bool, onBehalfOf: Choice<string, Account> option, paymentMethod: Choice<string, PaymentMethod>, paymentMethodDetails: SetupAttemptPaymentMethodDetails, setupError: ApiErrors option, setupIntent: Choice<string, SetupIntent>, status: string, usage: string) =

        member _.Application = application
        member _.Created = created
        member _.Customer = customer
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = "setup_attempt"
        member _.OnBehalfOf = onBehalfOf
        member _.PaymentMethod = paymentMethod
        member _.PaymentMethodDetails = paymentMethodDetails
        member _.SetupError = setupError
        member _.SetupIntent = setupIntent
        member _.Status = status
        member _.Usage = usage

    ///
    and SetupAttemptPaymentMethodDetails (``type``: string, ?bancontact: SetupAttemptPaymentMethodDetailsBancontact, ?card: SetupAttemptPaymentMethodDetailsCard, ?ideal: SetupAttemptPaymentMethodDetailsIdeal, ?sofort: SetupAttemptPaymentMethodDetailsSofort) =

        member _.Bancontact = bancontact
        member _.Card = card
        member _.Ideal = ideal
        member _.Sofort = sofort
        member _.Type = ``type``

    ///
    and SetupAttemptPaymentMethodDetailsBancontact (bankCode: string option, bankName: string option, bic: string option, generatedSepaDebit: Choice<string, PaymentMethod> option, generatedSepaDebitMandate: Choice<string, Mandate> option, ibanLast4: string option, preferredLanguage: SetupAttemptPaymentMethodDetailsBancontactPreferredLanguage option, verifiedName: string option) =

        member _.BankCode = bankCode
        member _.BankName = bankName
        member _.Bic = bic
        member _.GeneratedSepaDebit = generatedSepaDebit
        member _.GeneratedSepaDebitMandate = generatedSepaDebitMandate
        member _.IbanLast4 = ibanLast4
        member _.PreferredLanguage = preferredLanguage
        member _.VerifiedName = verifiedName

    and SetupAttemptPaymentMethodDetailsBancontactPreferredLanguage =
        | [<JsonUnionCase("de")>] SetupAttemptPaymentMethodDetailsBancontactPreferredLanguage'De
        | [<JsonUnionCase("en")>] SetupAttemptPaymentMethodDetailsBancontactPreferredLanguage'En
        | [<JsonUnionCase("fr")>] SetupAttemptPaymentMethodDetailsBancontactPreferredLanguage'Fr
        | [<JsonUnionCase("nl")>] SetupAttemptPaymentMethodDetailsBancontactPreferredLanguage'Nl

    ///
    and SetupAttemptPaymentMethodDetailsCard (threeDSecure: ThreeDSecureDetails option) =

        member _.ThreeDSecure = threeDSecure

    ///
    and SetupAttemptPaymentMethodDetailsIdeal (bank: SetupAttemptPaymentMethodDetailsIdealBank option, bic: SetupAttemptPaymentMethodDetailsIdealBic option, generatedSepaDebit: Choice<string, PaymentMethod> option, generatedSepaDebitMandate: Choice<string, Mandate> option, ibanLast4: string option, verifiedName: string option) =

        member _.Bank = bank
        member _.Bic = bic
        member _.GeneratedSepaDebit = generatedSepaDebit
        member _.GeneratedSepaDebitMandate = generatedSepaDebitMandate
        member _.IbanLast4 = ibanLast4
        member _.VerifiedName = verifiedName

    and SetupAttemptPaymentMethodDetailsIdealBank =
        | [<JsonUnionCase("abn_amro")>] SetupAttemptPaymentMethodDetailsIdealBank'AbnAmro
        | [<JsonUnionCase("asn_bank")>] SetupAttemptPaymentMethodDetailsIdealBank'AsnBank
        | [<JsonUnionCase("bunq")>] SetupAttemptPaymentMethodDetailsIdealBank'Bunq
        | [<JsonUnionCase("handelsbanken")>] SetupAttemptPaymentMethodDetailsIdealBank'Handelsbanken
        | [<JsonUnionCase("ing")>] SetupAttemptPaymentMethodDetailsIdealBank'Ing
        | [<JsonUnionCase("knab")>] SetupAttemptPaymentMethodDetailsIdealBank'Knab
        | [<JsonUnionCase("moneyou")>] SetupAttemptPaymentMethodDetailsIdealBank'Moneyou
        | [<JsonUnionCase("rabobank")>] SetupAttemptPaymentMethodDetailsIdealBank'Rabobank
        | [<JsonUnionCase("regiobank")>] SetupAttemptPaymentMethodDetailsIdealBank'Regiobank
        | [<JsonUnionCase("sns_bank")>] SetupAttemptPaymentMethodDetailsIdealBank'SnsBank
        | [<JsonUnionCase("triodos_bank")>] SetupAttemptPaymentMethodDetailsIdealBank'TriodosBank
        | [<JsonUnionCase("van_lanschot")>] SetupAttemptPaymentMethodDetailsIdealBank'VanLanschot

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

    ///
    and SetupAttemptPaymentMethodDetailsSofort (bankCode: string option, bankName: string option, bic: string option, generatedSepaDebit: Choice<string, PaymentMethod> option, generatedSepaDebitMandate: Choice<string, Mandate> option, ibanLast4: string option, preferredLanguage: SetupAttemptPaymentMethodDetailsSofortPreferredLanguage option, verifiedName: string option) =

        member _.BankCode = bankCode
        member _.BankName = bankName
        member _.Bic = bic
        member _.GeneratedSepaDebit = generatedSepaDebit
        member _.GeneratedSepaDebitMandate = generatedSepaDebitMandate
        member _.IbanLast4 = ibanLast4
        member _.PreferredLanguage = preferredLanguage
        member _.VerifiedName = verifiedName

    and SetupAttemptPaymentMethodDetailsSofortPreferredLanguage =
        | [<JsonUnionCase("de")>] SetupAttemptPaymentMethodDetailsSofortPreferredLanguage'De
        | [<JsonUnionCase("en")>] SetupAttemptPaymentMethodDetailsSofortPreferredLanguage'En
        | [<JsonUnionCase("fr")>] SetupAttemptPaymentMethodDetailsSofortPreferredLanguage'Fr
        | [<JsonUnionCase("nl")>] SetupAttemptPaymentMethodDetailsSofortPreferredLanguage'Nl

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
    and SetupIntent (application: Choice<string, Application> option, cancellationReason: SetupIntentCancellationReason option, clientSecret: string option, created: int64, customer: Choice<string, Customer, DeletedCustomer> option, description: string option, id: string, lastSetupError: ApiErrors option, latestAttempt: Choice<string, SetupAttempt> option, livemode: bool, mandate: Choice<string, Mandate> option, metadata: Map<string, string> option, nextAction: SetupIntentNextAction option, onBehalfOf: Choice<string, Account> option, paymentMethod: Choice<string, PaymentMethod> option, paymentMethodOptions: SetupIntentPaymentMethodOptions option, paymentMethodTypes: string list, singleUseMandate: Choice<string, Mandate> option, status: SetupIntentStatus, usage: string) =

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
        member _.Object = "setup_intent"
        member _.OnBehalfOf = onBehalfOf
        member _.PaymentMethod = paymentMethod
        member _.PaymentMethodOptions = paymentMethodOptions
        member _.PaymentMethodTypes = paymentMethodTypes
        member _.SingleUseMandate = singleUseMandate
        member _.Status = status
        member _.Usage = usage

    and SetupIntentCancellationReason =
        | [<JsonUnionCase("abandoned")>] SetupIntentCancellationReason'Abandoned
        | [<JsonUnionCase("duplicate")>] SetupIntentCancellationReason'Duplicate
        | [<JsonUnionCase("requested_by_customer")>] SetupIntentCancellationReason'RequestedByCustomer

    and SetupIntentStatus =
        | [<JsonUnionCase("canceled")>] SetupIntentStatus'Canceled
        | [<JsonUnionCase("processing")>] SetupIntentStatus'Processing
        | [<JsonUnionCase("requires_action")>] SetupIntentStatus'RequiresAction
        | [<JsonUnionCase("requires_confirmation")>] SetupIntentStatus'RequiresConfirmation
        | [<JsonUnionCase("requires_payment_method")>] SetupIntentStatus'RequiresPaymentMethod
        | [<JsonUnionCase("succeeded")>] SetupIntentStatus'Succeeded

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
        | [<JsonUnionCase("any")>] SetupIntentPaymentMethodOptionsCardRequestThreeDSecure'Any
        | [<JsonUnionCase("automatic")>] SetupIntentPaymentMethodOptionsCardRequestThreeDSecure'Automatic
        | [<JsonUnionCase("challenge_only")>] SetupIntentPaymentMethodOptionsCardRequestThreeDSecure'ChallengeOnly

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
    and ShippingMethod (amount: int64, currency: string, deliveryEstimate: DeliveryEstimate option, description: string, id: string) =

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
    and Sku (active: bool, attributes: Map<string, string>, created: int64, currency: string, id: string, image: string option, inventory: Inventory, livemode: bool, metadata: Map<string, string>, packageDimensions: PackageDimensions option, price: int64, product: Choice<string, Product>, updated: int64) =

        member _.Active = active
        member _.Attributes = attributes
        member _.Created = created
        member _.Currency = currency
        member _.Id = id
        member _.Image = image
        member _.Inventory = inventory
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Object = "sku"
        member _.PackageDimensions = packageDimensions
        member _.Price = price
        member _.Product = product
        member _.Updated = updated

    ///`Source` objects allow you to accept a variety of payment methods. They
    ///represent a customer's payment instrument, and can be used with the Stripe API
    ///just like a `Card` object: once chargeable, they can be charged, or can be
    ///attached to customers.
    ///
    ///Related guides: [Sources API](https://stripe.com/docs/sources) and [Sources & Customers](https://stripe.com/docs/sources/customers).
    and Source (amount: int64 option, clientSecret: string, created: int64, currency: string option, flow: string, id: string, livemode: bool, metadata: Map<string, string> option, owner: SourceOwner option, statementDescriptor: string option, status: string, ``type``: SourceType, usage: string option, ?achCreditTransfer: SourceTypeAchCreditTransfer, ?achDebit: SourceTypeAchDebit, ?acssDebit: SourceTypeAcssDebit, ?alipay: SourceTypeAlipay, ?auBecsDebit: SourceTypeAuBecsDebit, ?bancontact: SourceTypeBancontact, ?card: SourceTypeCard, ?cardPresent: SourceTypeCardPresent, ?codeVerification: SourceCodeVerificationFlow, ?customer: string, ?eps: SourceTypeEps, ?giropay: SourceTypeGiropay, ?ideal: SourceTypeIdeal, ?klarna: SourceTypeKlarna, ?multibanco: SourceTypeMultibanco, ?p24: SourceTypeP24, ?receiver: SourceReceiverFlow, ?redirect: SourceRedirectFlow, ?sepaCreditTransfer: SourceTypeSepaCreditTransfer, ?sepaDebit: SourceTypeSepaDebit, ?sofort: SourceTypeSofort, ?sourceOrder: SourceOrder, ?threeDSecure: SourceTypeThreeDSecure, ?wechat: SourceTypeWechat) =

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
        member _.Object = "source"
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

    and SourceType =
        | [<JsonUnionCase("ach_credit_transfer")>] SourceType'AchCreditTransfer
        | [<JsonUnionCase("ach_debit")>] SourceType'AchDebit
        | [<JsonUnionCase("acss_debit")>] SourceType'AcssDebit
        | [<JsonUnionCase("alipay")>] SourceType'Alipay
        | [<JsonUnionCase("au_becs_debit")>] SourceType'AuBecsDebit
        | [<JsonUnionCase("bancontact")>] SourceType'Bancontact
        | [<JsonUnionCase("card")>] SourceType'Card
        | [<JsonUnionCase("card_present")>] SourceType'CardPresent
        | [<JsonUnionCase("eps")>] SourceType'Eps
        | [<JsonUnionCase("giropay")>] SourceType'Giropay
        | [<JsonUnionCase("ideal")>] SourceType'Ideal
        | [<JsonUnionCase("klarna")>] SourceType'Klarna
        | [<JsonUnionCase("multibanco")>] SourceType'Multibanco
        | [<JsonUnionCase("p24")>] SourceType'P24
        | [<JsonUnionCase("sepa_credit_transfer")>] SourceType'SepaCreditTransfer
        | [<JsonUnionCase("sepa_debit")>] SourceType'SepaDebit
        | [<JsonUnionCase("sofort")>] SourceType'Sofort
        | [<JsonUnionCase("three_d_secure")>] SourceType'ThreeDSecure
        | [<JsonUnionCase("wechat")>] SourceType'Wechat

    ///
    and SourceCodeVerificationFlow (attemptsRemaining: int64, status: string) =

        member _.AttemptsRemaining = attemptsRemaining
        member _.Status = status

    ///Source mandate notifications should be created when a notification related to
    ///a source mandate must be sent to the payer. They will trigger a webhook or
    ///deliver an email to the customer.
    and SourceMandateNotification (amount: int64 option, created: int64, id: string, livemode: bool, reason: string, source: Source, status: string, ``type``: string, ?acssDebit: SourceMandateNotificationAcssDebitData, ?bacsDebit: SourceMandateNotificationBacsDebitData, ?sepaDebit: SourceMandateNotificationSepaDebitData) =

        member _.AcssDebit = acssDebit
        member _.Amount = amount
        member _.BacsDebit = bacsDebit
        member _.Created = created
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = "source_mandate_notification"
        member _.Reason = reason
        member _.SepaDebit = sepaDebit
        member _.Source = source
        member _.Status = status
        member _.Type = ``type``

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
    and SourceOrder (amount: int64, currency: string, items: SourceOrderItem list option, ?email: string, ?shipping: Shipping) =

        member _.Amount = amount
        member _.Currency = currency
        member _.Email = email
        member _.Items = items
        member _.Shipping = shipping

    ///
    and SourceOrderItem (amount: int64 option, currency: string option, description: string option, parent: string option, ``type``: string option, ?quantity: int64) =

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
    and SourceReceiverFlow (address: string option, amountCharged: int64, amountReceived: int64, amountReturned: int64, refundAttributesMethod: string, refundAttributesStatus: string) =

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
    and SourceTransaction (amount: int64, created: int64, currency: string, id: string, livemode: bool, source: string, status: string, ``type``: SourceTransactionType, ?achCreditTransfer: SourceTransactionAchCreditTransferData, ?chfCreditTransfer: SourceTransactionChfCreditTransferData, ?gbpCreditTransfer: SourceTransactionGbpCreditTransferData, ?paperCheck: SourceTransactionPaperCheckData, ?sepaCreditTransfer: SourceTransactionSepaCreditTransferData) =

        member _.AchCreditTransfer = achCreditTransfer
        member _.Amount = amount
        member _.ChfCreditTransfer = chfCreditTransfer
        member _.Created = created
        member _.Currency = currency
        member _.GbpCreditTransfer = gbpCreditTransfer
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = "source_transaction"
        member _.PaperCheck = paperCheck
        member _.SepaCreditTransfer = sepaCreditTransfer
        member _.Source = source
        member _.Status = status
        member _.Type = ``type``

    and SourceTransactionType =
        | [<JsonUnionCase("ach_credit_transfer")>] SourceTransactionType'AchCreditTransfer
        | [<JsonUnionCase("ach_debit")>] SourceTransactionType'AchDebit
        | [<JsonUnionCase("alipay")>] SourceTransactionType'Alipay
        | [<JsonUnionCase("bancontact")>] SourceTransactionType'Bancontact
        | [<JsonUnionCase("card")>] SourceTransactionType'Card
        | [<JsonUnionCase("card_present")>] SourceTransactionType'CardPresent
        | [<JsonUnionCase("eps")>] SourceTransactionType'Eps
        | [<JsonUnionCase("giropay")>] SourceTransactionType'Giropay
        | [<JsonUnionCase("ideal")>] SourceTransactionType'Ideal
        | [<JsonUnionCase("klarna")>] SourceTransactionType'Klarna
        | [<JsonUnionCase("multibanco")>] SourceTransactionType'Multibanco
        | [<JsonUnionCase("p24")>] SourceTransactionType'P24
        | [<JsonUnionCase("sepa_debit")>] SourceTransactionType'SepaDebit
        | [<JsonUnionCase("sofort")>] SourceTransactionType'Sofort
        | [<JsonUnionCase("three_d_secure")>] SourceTransactionType'ThreeDSecure
        | [<JsonUnionCase("wechat")>] SourceTransactionType'Wechat

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

    and SourceTypeCard (?addressLine1Check: string option, ?addressZipCheck: string option, ?brand: string option, ?country: string option, ?cvcCheck: string option, ?description: string, ?dynamicLast4: string option, ?expMonth: int64 option, ?expYear: int64 option, ?fingerprint: string, ?funding: string option, ?iin: string, ?issuer: string, ?last4: string option, ?name: string option, ?threeDSecure: string, ?tokenizationMethod: string option) =

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

    and SourceTypeCardPresent (?applicationCryptogram: string, ?applicationPreferredName: string, ?authorizationCode: string option, ?authorizationResponseCode: string, ?brand: string option, ?country: string option, ?cvmType: string, ?dataType: string option, ?dedicatedFileName: string, ?description: string, ?emvAuthData: string, ?evidenceCustomerSignature: string option, ?evidenceTransactionCertificate: string option, ?expMonth: int64 option, ?expYear: int64 option, ?fingerprint: string, ?funding: string option, ?iin: string, ?issuer: string, ?last4: string option, ?posDeviceId: string option, ?posEntryMode: string, ?readMethod: string option, ?reader: string option, ?terminalVerificationResults: string, ?transactionStatusInformation: string) =

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

    and SourceTypeKlarna (?backgroundImageUrl: string, ?clientToken: string option, ?firstName: string, ?lastName: string, ?locale: string, ?logoUrl: string, ?pageTitle: string, ?payLaterAssetUrlsDescriptive: string, ?payLaterAssetUrlsStandard: string, ?payLaterName: string, ?payLaterRedirectUrl: string, ?payNowAssetUrlsDescriptive: string, ?payNowAssetUrlsStandard: string, ?payNowName: string, ?payNowRedirectUrl: string, ?payOverTimeAssetUrlsDescriptive: string, ?payOverTimeAssetUrlsStandard: string, ?payOverTimeName: string, ?payOverTimeRedirectUrl: string, ?paymentMethodCategories: string, ?purchaseCountry: string, ?purchaseType: string, ?redirectUrl: string, ?shippingDelay: int64, ?shippingFirstName: string, ?shippingLastName: string) =

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

    and SourceTypeThreeDSecure (?addressLine1Check: string option, ?addressZipCheck: string option, ?authenticated: bool option, ?brand: string option, ?card: string option, ?country: string option, ?customer: string option, ?cvcCheck: string option, ?description: string, ?dynamicLast4: string option, ?expMonth: int64 option, ?expYear: int64 option, ?fingerprint: string, ?funding: string option, ?iin: string, ?issuer: string, ?last4: string option, ?name: string option, ?threeDSecure: string, ?tokenizationMethod: string option) =

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
    and StatusTransitions (canceled: int64 option, fulfiled: int64 option, paid: int64 option, returned: int64 option) =

        member _.Canceled = canceled
        member _.Fulfiled = fulfiled
        member _.Paid = paid
        member _.Returned = returned

    ///Subscriptions allow you to charge a customer on a recurring basis.
    ///
    ///Related guide: [Creating Subscriptions](https://stripe.com/docs/billing/subscriptions/creating).
    and Subscription (applicationFeePercent: decimal option, billingCycleAnchor: int64, billingThresholds: SubscriptionBillingThresholds option, cancelAt: int64 option, cancelAtPeriodEnd: bool, canceledAt: int64 option, collectionMethod: SubscriptionCollectionMethod option, created: int64, currentPeriodEnd: int64, currentPeriodStart: int64, customer: Choice<string, Customer, DeletedCustomer>, daysUntilDue: int64 option, defaultPaymentMethod: Choice<string, PaymentMethod> option, defaultSource: Choice<string, PaymentSource> option, discount: Discount option, endedAt: int64 option, id: string, items: Map<string, string>, latestInvoice: Choice<string, Invoice> option, livemode: bool, metadata: Map<string, string>, nextPendingInvoiceItemInvoice: int64 option, pauseCollection: SubscriptionsResourcePauseCollection option, pendingInvoiceItemInterval: SubscriptionPendingInvoiceItemInterval option, pendingSetupIntent: Choice<string, SetupIntent> option, pendingUpdate: SubscriptionsResourcePendingUpdate option, schedule: Choice<string, SubscriptionSchedule> option, startDate: int64, status: SubscriptionStatus, transferData: SubscriptionTransferData option, trialEnd: int64 option, trialStart: int64 option, ?defaultTaxRates: TaxRate list option) =

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
        member _.Object = "subscription"
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
        | [<JsonUnionCase("charge_automatically")>] SubscriptionCollectionMethod'ChargeAutomatically
        | [<JsonUnionCase("send_invoice")>] SubscriptionCollectionMethod'SendInvoice

    and SubscriptionStatus =
        | [<JsonUnionCase("active")>] SubscriptionStatus'Active
        | [<JsonUnionCase("canceled")>] SubscriptionStatus'Canceled
        | [<JsonUnionCase("incomplete")>] SubscriptionStatus'Incomplete
        | [<JsonUnionCase("incomplete_expired")>] SubscriptionStatus'IncompleteExpired
        | [<JsonUnionCase("past_due")>] SubscriptionStatus'PastDue
        | [<JsonUnionCase("trialing")>] SubscriptionStatus'Trialing
        | [<JsonUnionCase("unpaid")>] SubscriptionStatus'Unpaid

    ///
    and SubscriptionBillingThresholds (amountGte: int64 option, resetBillingCycleAnchor: bool option) =

        member _.AmountGte = amountGte
        member _.ResetBillingCycleAnchor = resetBillingCycleAnchor

    ///Subscription items allow you to create customer subscriptions with more than
    ///one plan, making it easy to represent complex billing relationships.
    and SubscriptionItem (billingThresholds: SubscriptionItemBillingThresholds option, created: int64, id: string, metadata: Map<string, string>, plan: Plan, price: Price, subscription: string, taxRates: TaxRate list option, ?quantity: int64) =

        member _.BillingThresholds = billingThresholds
        member _.Created = created
        member _.Id = id
        member _.Metadata = metadata
        member _.Object = "subscription_item"
        member _.Plan = plan
        member _.Price = price
        member _.Quantity = quantity
        member _.Subscription = subscription
        member _.TaxRates = taxRates

    ///
    and SubscriptionItemBillingThresholds (usageGte: int64 option) =

        member _.UsageGte = usageGte

    ///
    and SubscriptionPendingInvoiceItemInterval (interval: SubscriptionPendingInvoiceItemIntervalInterval, intervalCount: int64) =

        member _.Interval = interval
        member _.IntervalCount = intervalCount

    and SubscriptionPendingInvoiceItemIntervalInterval =
        | [<JsonUnionCase("day")>] SubscriptionPendingInvoiceItemIntervalInterval'Day
        | [<JsonUnionCase("month")>] SubscriptionPendingInvoiceItemIntervalInterval'Month
        | [<JsonUnionCase("week")>] SubscriptionPendingInvoiceItemIntervalInterval'Week
        | [<JsonUnionCase("year")>] SubscriptionPendingInvoiceItemIntervalInterval'Year

    ///A subscription schedule allows you to create and manage the lifecycle of a subscription by predefining expected changes.
    ///
    ///Related guide: [Subscription Schedules](https://stripe.com/docs/billing/subscriptions/subscription-schedules).
    and SubscriptionSchedule (canceledAt: int64 option, completedAt: int64 option, created: int64, currentPhase: SubscriptionScheduleCurrentPhase option, customer: Choice<string, Customer, DeletedCustomer>, defaultSettings: SubscriptionSchedulesResourceDefaultSettings, endBehavior: SubscriptionScheduleEndBehavior, id: string, livemode: bool, metadata: Map<string, string> option, phases: SubscriptionSchedulePhaseConfiguration list, releasedAt: int64 option, releasedSubscription: string option, status: SubscriptionScheduleStatus, subscription: Choice<string, Subscription> option) =

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
        member _.Object = "subscription_schedule"
        member _.Phases = phases
        member _.ReleasedAt = releasedAt
        member _.ReleasedSubscription = releasedSubscription
        member _.Status = status
        member _.Subscription = subscription

    and SubscriptionScheduleEndBehavior =
        | [<JsonUnionCase("cancel")>] SubscriptionScheduleEndBehavior'Cancel
        | [<JsonUnionCase("none")>] SubscriptionScheduleEndBehavior'None
        | [<JsonUnionCase("release")>] SubscriptionScheduleEndBehavior'Release
        | [<JsonUnionCase("renew")>] SubscriptionScheduleEndBehavior'Renew

    and SubscriptionScheduleStatus =
        | [<JsonUnionCase("active")>] SubscriptionScheduleStatus'Active
        | [<JsonUnionCase("canceled")>] SubscriptionScheduleStatus'Canceled
        | [<JsonUnionCase("completed")>] SubscriptionScheduleStatus'Completed
        | [<JsonUnionCase("not_started")>] SubscriptionScheduleStatus'NotStarted
        | [<JsonUnionCase("released")>] SubscriptionScheduleStatus'Released

    ///An Add Invoice Item describes the prices and quantities that will be added as pending invoice items when entering a phase.
    and SubscriptionScheduleAddInvoiceItem (price: Choice<string, Price, DeletedPrice>, quantity: int64 option, ?taxRates: TaxRate list option) =

        member _.Price = price
        member _.Quantity = quantity
        member _.TaxRates = taxRates |> Option.flatten

    ///A phase item describes the price and quantity of a phase.
    and SubscriptionScheduleConfigurationItem (billingThresholds: SubscriptionItemBillingThresholds option, plan: Choice<string, Plan, DeletedPlan>, price: Choice<string, Price, DeletedPrice>, ?quantity: int64, ?taxRates: TaxRate list option) =

        member _.BillingThresholds = billingThresholds
        member _.Plan = plan
        member _.Price = price
        member _.Quantity = quantity
        member _.TaxRates = taxRates |> Option.flatten

    ///
    and SubscriptionScheduleCurrentPhase (endDate: int64, startDate: int64) =

        member _.EndDate = endDate
        member _.StartDate = startDate

    ///A phase describes the plans, coupon, and trialing status of a subscription for a predefined time period.
    and SubscriptionSchedulePhaseConfiguration (addInvoiceItems: SubscriptionScheduleAddInvoiceItem list, applicationFeePercent: decimal option, billingCycleAnchor: SubscriptionSchedulePhaseConfigurationBillingCycleAnchor option, billingThresholds: SubscriptionBillingThresholds option, collectionMethod: SubscriptionSchedulePhaseConfigurationCollectionMethod option, coupon: Choice<string, Coupon, DeletedCoupon> option, defaultPaymentMethod: Choice<string, PaymentMethod> option, endDate: int64, invoiceSettings: InvoiceSettingSubscriptionScheduleSetting option, items: SubscriptionScheduleConfigurationItem list, prorationBehavior: SubscriptionSchedulePhaseConfigurationProrationBehavior, startDate: int64, transferData: SubscriptionTransferData option, trialEnd: int64 option, ?defaultTaxRates: TaxRate list option) =

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
        | [<JsonUnionCase("automatic")>] SubscriptionSchedulePhaseConfigurationBillingCycleAnchor'Automatic
        | [<JsonUnionCase("phase_start")>] SubscriptionSchedulePhaseConfigurationBillingCycleAnchor'PhaseStart

    and SubscriptionSchedulePhaseConfigurationCollectionMethod =
        | [<JsonUnionCase("charge_automatically")>] SubscriptionSchedulePhaseConfigurationCollectionMethod'ChargeAutomatically
        | [<JsonUnionCase("send_invoice")>] SubscriptionSchedulePhaseConfigurationCollectionMethod'SendInvoice

    and SubscriptionSchedulePhaseConfigurationProrationBehavior =
        | [<JsonUnionCase("always_invoice")>] SubscriptionSchedulePhaseConfigurationProrationBehavior'AlwaysInvoice
        | [<JsonUnionCase("create_prorations")>] SubscriptionSchedulePhaseConfigurationProrationBehavior'CreateProrations
        | [<JsonUnionCase("none")>] SubscriptionSchedulePhaseConfigurationProrationBehavior'None

    ///
    and SubscriptionSchedulesResourceDefaultSettings (billingCycleAnchor: SubscriptionSchedulesResourceDefaultSettingsBillingCycleAnchor, billingThresholds: SubscriptionBillingThresholds option, collectionMethod: SubscriptionSchedulesResourceDefaultSettingsCollectionMethod option, defaultPaymentMethod: Choice<string, PaymentMethod> option, invoiceSettings: InvoiceSettingSubscriptionScheduleSetting option, transferData: SubscriptionTransferData option) =

        member _.BillingCycleAnchor = billingCycleAnchor
        member _.BillingThresholds = billingThresholds
        member _.CollectionMethod = collectionMethod
        member _.DefaultPaymentMethod = defaultPaymentMethod
        member _.InvoiceSettings = invoiceSettings
        member _.TransferData = transferData

    and SubscriptionSchedulesResourceDefaultSettingsBillingCycleAnchor =
        | [<JsonUnionCase("automatic")>] SubscriptionSchedulesResourceDefaultSettingsBillingCycleAnchor'Automatic
        | [<JsonUnionCase("phase_start")>] SubscriptionSchedulesResourceDefaultSettingsBillingCycleAnchor'PhaseStart

    and SubscriptionSchedulesResourceDefaultSettingsCollectionMethod =
        | [<JsonUnionCase("charge_automatically")>] SubscriptionSchedulesResourceDefaultSettingsCollectionMethod'ChargeAutomatically
        | [<JsonUnionCase("send_invoice")>] SubscriptionSchedulesResourceDefaultSettingsCollectionMethod'SendInvoice

    ///
    and SubscriptionTransferData (amountPercent: decimal option, destination: Choice<string, Account>) =

        member _.AmountPercent = amountPercent
        member _.Destination = destination

    ///The Pause Collection settings determine how we will pause collection for this subscription and for how long the subscription
    ///should be paused.
    and SubscriptionsResourcePauseCollection (behavior: SubscriptionsResourcePauseCollectionBehavior, resumesAt: int64 option) =

        member _.Behavior = behavior
        member _.ResumesAt = resumesAt

    and SubscriptionsResourcePauseCollectionBehavior =
        | [<JsonUnionCase("keep_as_draft")>] SubscriptionsResourcePauseCollectionBehavior'KeepAsDraft
        | [<JsonUnionCase("mark_uncollectible")>] SubscriptionsResourcePauseCollectionBehavior'MarkUncollectible
        | [<JsonUnionCase("void")>] SubscriptionsResourcePauseCollectionBehavior'Void

    ///Pending Updates store the changes pending from a previous update that will be applied
    ///to the Subscription upon successful payment.
    and SubscriptionsResourcePendingUpdate (billingCycleAnchor: int64 option, expiresAt: int64, subscriptionItems: SubscriptionItem list option, trialEnd: int64 option, trialFromPlan: bool option) =

        member _.BillingCycleAnchor = billingCycleAnchor
        member _.ExpiresAt = expiresAt
        member _.SubscriptionItems = subscriptionItems
        member _.TrialEnd = trialEnd
        member _.TrialFromPlan = trialFromPlan

    ///
    and TaxDeductedAtSource (id: string, periodEnd: int64, periodStart: int64, taxDeductionAccountNumber: string) =

        member _.Id = id
        member _.Object = "tax_deducted_at_source"
        member _.PeriodEnd = periodEnd
        member _.PeriodStart = periodStart
        member _.TaxDeductionAccountNumber = taxDeductionAccountNumber

    ///You can add one or multiple tax IDs to a [customer](https://stripe.com/docs/api/customers).
    ///A customer's tax IDs are displayed on invoices and credit notes issued for the customer.
    ///
    ///Related guide: [Customer Tax Identification Numbers](https://stripe.com/docs/billing/taxes/tax-ids).
    and TaxId (country: string option, created: int64, customer: Choice<string, Customer> option, id: string, livemode: bool, ``type``: TaxIdType, value: string, verification: TaxIdVerification option) =

        member _.Country = country
        member _.Created = created
        member _.Customer = customer
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = "tax_id"
        member _.Type = ``type``
        member _.Value = value
        member _.Verification = verification

    and TaxIdType =
        | [<JsonUnionCase("ae_trn")>] TaxIdType'AeTrn
        | [<JsonUnionCase("au_abn")>] TaxIdType'AuAbn
        | [<JsonUnionCase("br_cnpj")>] TaxIdType'BrCnpj
        | [<JsonUnionCase("br_cpf")>] TaxIdType'BrCpf
        | [<JsonUnionCase("ca_bn")>] TaxIdType'CaBn
        | [<JsonUnionCase("ca_qst")>] TaxIdType'CaQst
        | [<JsonUnionCase("ch_vat")>] TaxIdType'ChVat
        | [<JsonUnionCase("cl_tin")>] TaxIdType'ClTin
        | [<JsonUnionCase("es_cif")>] TaxIdType'EsCif
        | [<JsonUnionCase("eu_vat")>] TaxIdType'EuVat
        | [<JsonUnionCase("hk_br")>] TaxIdType'HkBr
        | [<JsonUnionCase("id_npwp")>] TaxIdType'IdNpwp
        | [<JsonUnionCase("in_gst")>] TaxIdType'InGst
        | [<JsonUnionCase("jp_cn")>] TaxIdType'JpCn
        | [<JsonUnionCase("jp_rn")>] TaxIdType'JpRn
        | [<JsonUnionCase("kr_brn")>] TaxIdType'KrBrn
        | [<JsonUnionCase("li_uid")>] TaxIdType'LiUid
        | [<JsonUnionCase("mx_rfc")>] TaxIdType'MxRfc
        | [<JsonUnionCase("my_frp")>] TaxIdType'MyFrp
        | [<JsonUnionCase("my_itn")>] TaxIdType'MyItn
        | [<JsonUnionCase("my_sst")>] TaxIdType'MySst
        | [<JsonUnionCase("no_vat")>] TaxIdType'NoVat
        | [<JsonUnionCase("nz_gst")>] TaxIdType'NzGst
        | [<JsonUnionCase("ru_inn")>] TaxIdType'RuInn
        | [<JsonUnionCase("ru_kpp")>] TaxIdType'RuKpp
        | [<JsonUnionCase("sa_vat")>] TaxIdType'SaVat
        | [<JsonUnionCase("sg_gst")>] TaxIdType'SgGst
        | [<JsonUnionCase("sg_uen")>] TaxIdType'SgUen
        | [<JsonUnionCase("th_vat")>] TaxIdType'ThVat
        | [<JsonUnionCase("tw_vat")>] TaxIdType'TwVat
        | [<JsonUnionCase("unknown")>] TaxIdType'Unknown
        | [<JsonUnionCase("us_ein")>] TaxIdType'UsEin
        | [<JsonUnionCase("za_vat")>] TaxIdType'ZaVat

    ///
    and TaxIdVerification (status: TaxIdVerificationStatus, verifiedAddress: string option, verifiedName: string option) =

        member _.Status = status
        member _.VerifiedAddress = verifiedAddress
        member _.VerifiedName = verifiedName

    and TaxIdVerificationStatus =
        | [<JsonUnionCase("pending")>] TaxIdVerificationStatus'Pending
        | [<JsonUnionCase("unavailable")>] TaxIdVerificationStatus'Unavailable
        | [<JsonUnionCase("unverified")>] TaxIdVerificationStatus'Unverified
        | [<JsonUnionCase("verified")>] TaxIdVerificationStatus'Verified

    ///Tax rates can be applied to [invoices](https://stripe.com/docs/billing/invoices/tax-rates), [subscriptions](https://stripe.com/docs/billing/subscriptions/taxes) and [Checkout Sessions](https://stripe.com/docs/payments/checkout/set-up-a-subscription#tax-rates) to collect tax.
    ///
    ///Related guide: [Tax Rates](https://stripe.com/docs/billing/taxes/tax-rates).
    and TaxRate (active: bool, created: int64, description: string option, displayName: string, id: string, inclusive: bool, jurisdiction: string option, livemode: bool, metadata: Map<string, string> option, percentage: decimal) =

        member _.Active = active
        member _.Created = created
        member _.Description = description
        member _.DisplayName = displayName
        member _.Id = id
        member _.Inclusive = inclusive
        member _.Jurisdiction = jurisdiction
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Object = "tax_rate"
        member _.Percentage = percentage

    ///A Connection Token is used by the Stripe Terminal SDK to connect to a reader.
    ///
    ///Related guide: [Fleet Management](https://stripe.com/docs/terminal/readers/fleet-management#create).
    and TerminalConnectionToken (secret: string, ?location: string) =

        member _.Location = location
        member _.Object = "terminal.connection_token"
        member _.Secret = secret

    ///A Location represents a grouping of readers.
    ///
    ///Related guide: [Fleet Management](https://stripe.com/docs/terminal/readers/fleet-management#create).
    and TerminalLocation (address: Address, displayName: string, id: string, livemode: bool, metadata: Map<string, string>) =

        member _.Address = address
        member _.DisplayName = displayName
        member _.Id = id
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Object = "terminal.location"

    ///A Reader represents a physical device for accepting payment details.
    ///
    ///Related guide: [Connecting to a Reader](https://stripe.com/docs/terminal/readers/connecting).
    and TerminalReader (deviceSwVersion: string option, deviceType: TerminalReaderDeviceType, id: string, ipAddress: string option, label: string, livemode: bool, location: string option, metadata: Map<string, string>, serialNumber: string, status: string option) =

        member _.DeviceSwVersion = deviceSwVersion
        member _.DeviceType = deviceType
        member _.Id = id
        member _.IpAddress = ipAddress
        member _.Label = label
        member _.Livemode = livemode
        member _.Location = location
        member _.Metadata = metadata
        member _.Object = "terminal.reader"
        member _.SerialNumber = serialNumber
        member _.Status = status

    and TerminalReaderDeviceType =
        | [<JsonUnionCase("bbpos_chipper2x")>] TerminalReaderDeviceType'BbposChipper2x
        | [<JsonUnionCase("verifone_P400")>] TerminalReaderDeviceType'VerifoneP400

    ///Cardholder authentication via 3D Secure is initiated by creating a `3D Secure`
    ///object. Once the object has been created, you can use it to authenticate the
    ///cardholder and create a charge.
    and ThreeDSecure (amount: int64, authenticated: bool, card: Card, created: int64, currency: string, id: string, livemode: bool, redirectUrl: string option, status: string) =

        member _.Amount = amount
        member _.Authenticated = authenticated
        member _.Card = card
        member _.Created = created
        member _.Currency = currency
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = "three_d_secure"
        member _.RedirectUrl = redirectUrl
        member _.Status = status

    ///
    and ThreeDSecureDetails (authenticationFlow: ThreeDSecureDetailsAuthenticationFlow option, result: ThreeDSecureDetailsResult, resultReason: ThreeDSecureDetailsResultReason option, version: ThreeDSecureDetailsVersion) =

        member _.AuthenticationFlow = authenticationFlow
        member _.Result = result
        member _.ResultReason = resultReason
        member _.Version = version

    and ThreeDSecureDetailsAuthenticationFlow =
        | [<JsonUnionCase("challenge")>] ThreeDSecureDetailsAuthenticationFlow'Challenge
        | [<JsonUnionCase("frictionless")>] ThreeDSecureDetailsAuthenticationFlow'Frictionless

    and ThreeDSecureDetailsResult =
        | [<JsonUnionCase("attempt_acknowledged")>] ThreeDSecureDetailsResult'AttemptAcknowledged
        | [<JsonUnionCase("authenticated")>] ThreeDSecureDetailsResult'Authenticated
        | [<JsonUnionCase("failed")>] ThreeDSecureDetailsResult'Failed
        | [<JsonUnionCase("not_supported")>] ThreeDSecureDetailsResult'NotSupported
        | [<JsonUnionCase("processing_error")>] ThreeDSecureDetailsResult'ProcessingError

    and ThreeDSecureDetailsResultReason =
        | [<JsonUnionCase("abandoned")>] ThreeDSecureDetailsResultReason'Abandoned
        | [<JsonUnionCase("bypassed")>] ThreeDSecureDetailsResultReason'Bypassed
        | [<JsonUnionCase("canceled")>] ThreeDSecureDetailsResultReason'Canceled
        | [<JsonUnionCase("card_not_enrolled")>] ThreeDSecureDetailsResultReason'CardNotEnrolled
        | [<JsonUnionCase("network_not_supported")>] ThreeDSecureDetailsResultReason'NetworkNotSupported
        | [<JsonUnionCase("protocol_error")>] ThreeDSecureDetailsResultReason'ProtocolError
        | [<JsonUnionCase("rejected")>] ThreeDSecureDetailsResultReason'Rejected

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
    and Token (clientIp: string option, created: int64, id: string, livemode: bool, ``type``: string, used: bool, ?bankAccount: BankAccount, ?card: Card) =

        member _.BankAccount = bankAccount
        member _.Card = card
        member _.ClientIp = clientIp
        member _.Created = created
        member _.Id = id
        member _.Livemode = livemode
        member _.Object = "token"
        member _.Type = ``type``
        member _.Used = used

    ///To top up your Stripe balance, you create a top-up object. You can retrieve
    ///individual top-ups, as well as list all top-ups. Top-ups are identified by a
    ///unique, random ID.
    ///
    ///Related guide: [Topping Up your Platform Account](https://stripe.com/docs/connect/top-ups).
    and Topup (amount: int64, balanceTransaction: Choice<string, BalanceTransaction> option, created: int64, currency: string, description: string option, expectedAvailabilityDate: int64 option, failureCode: string option, failureMessage: string option, id: string, livemode: bool, metadata: Map<string, string>, source: Source, statementDescriptor: string option, status: TopupStatus, transferGroup: string option) =

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
        member _.Object = "topup"
        member _.Source = source
        member _.StatementDescriptor = statementDescriptor
        member _.Status = status
        member _.TransferGroup = transferGroup

    and TopupStatus =
        | [<JsonUnionCase("canceled")>] TopupStatus'Canceled
        | [<JsonUnionCase("failed")>] TopupStatus'Failed
        | [<JsonUnionCase("pending")>] TopupStatus'Pending
        | [<JsonUnionCase("reversed")>] TopupStatus'Reversed
        | [<JsonUnionCase("succeeded")>] TopupStatus'Succeeded

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
    and Transfer (amount: int64, amountReversed: int64, balanceTransaction: Choice<string, BalanceTransaction> option, created: int64, currency: string, description: string option, destination: Choice<string, Account> option, id: string, livemode: bool, metadata: Map<string, string>, reversals: Map<string, string>, reversed: bool, sourceTransaction: Choice<string, Charge> option, sourceType: string option, transferGroup: string option, ?destinationPayment: Choice<string, Charge>) =

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
        member _.Object = "transfer"
        member _.Reversals = reversals
        member _.Reversed = reversed
        member _.SourceTransaction = sourceTransaction
        member _.SourceType = sourceType
        member _.TransferGroup = transferGroup

    ///
    and TransferData (destination: Choice<string, Account>, ?amount: int64) =

        member _.Amount = amount
        member _.Destination = destination

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
    and TransferReversal (amount: int64, balanceTransaction: Choice<string, BalanceTransaction> option, created: int64, currency: string, destinationPaymentRefund: Choice<string, Refund> option, id: string, metadata: Map<string, string> option, sourceRefund: Choice<string, Refund> option, transfer: Choice<string, Transfer>) =

        member _.Amount = amount
        member _.BalanceTransaction = balanceTransaction
        member _.Created = created
        member _.Currency = currency
        member _.DestinationPaymentRefund = destinationPaymentRefund
        member _.Id = id
        member _.Metadata = metadata
        member _.Object = "transfer_reversal"
        member _.SourceRefund = sourceRefund
        member _.Transfer = transfer

    ///
    and TransferSchedule (delayDays: int64, interval: string, ?monthlyAnchor: int64, ?weeklyAnchor: string) =

        member _.DelayDays = delayDays
        member _.Interval = interval
        member _.MonthlyAnchor = monthlyAnchor
        member _.WeeklyAnchor = weeklyAnchor

    ///
    and TransformQuantity (divideBy: int64, round: TransformQuantityRound) =

        member _.DivideBy = divideBy
        member _.Round = round

    and TransformQuantityRound =
        | [<JsonUnionCase("down")>] TransformQuantityRound'Down
        | [<JsonUnionCase("up")>] TransformQuantityRound'Up

    ///
    and TransformUsage (divideBy: int64, round: TransformUsageRound) =

        member _.DivideBy = divideBy
        member _.Round = round

    and TransformUsageRound =
        | [<JsonUnionCase("down")>] TransformUsageRound'Down
        | [<JsonUnionCase("up")>] TransformUsageRound'Up

    ///Usage records allow you to report customer usage and metrics to Stripe for
    ///metered billing of subscription prices.
    ///
    ///Related guide: [Metered Billing](https://stripe.com/docs/billing/subscriptions/metered-billing).
    and UsageRecord (id: string, livemode: bool, quantity: int64, subscriptionItem: string, timestamp: int64) =

        member _.Id = id
        member _.Livemode = livemode
        member _.Object = "usage_record"
        member _.Quantity = quantity
        member _.SubscriptionItem = subscriptionItem
        member _.Timestamp = timestamp

    ///
    and UsageRecordSummary (id: string, invoice: string option, livemode: bool, period: Period, subscriptionItem: string, totalUsage: int64) =

        member _.Id = id
        member _.Invoice = invoice
        member _.Livemode = livemode
        member _.Object = "usage_record_summary"
        member _.Period = period
        member _.SubscriptionItem = subscriptionItem
        member _.TotalUsage = totalUsage

    ///You can configure [webhook endpoints](https://stripe.com/docs/webhooks/) via the API to be
    ///notified about events that happen in your Stripe account or connected
    ///accounts.
    ///
    ///Most users configure webhooks from [the dashboard](https://dashboard.stripe.com/webhooks), which provides a user interface for registering and testing your webhook endpoints.
    ///
    ///Related guide: [Setting up Webhooks](https://stripe.com/docs/webhooks/configure).
    and WebhookEndpoint (apiVersion: string option, application: string option, created: int64, description: string option, enabledEvents: string list, id: string, livemode: bool, metadata: Map<string, string>, status: string, url: string, ?secret: string) =

        member _.ApiVersion = apiVersion
        member _.Application = application
        member _.Created = created
        member _.Description = description
        member _.EnabledEvents = enabledEvents
        member _.Id = id
        member _.Livemode = livemode
        member _.Metadata = metadata
        member _.Object = "webhook_endpoint"
        member _.Secret = secret
        member _.Status = status
        member _.Url = url

