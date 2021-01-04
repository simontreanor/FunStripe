namespace FunStripe

open FSharp.Json
open FunStripe.JsonUtil
open System

module StripeModel =

    ///This is an object representing a Stripe account. You can retrieve it to see
    ///properties on the account like its current e-mail address or if the account is
    ///enabled yet to make live charges.
    ///Some properties, marked below, are available only to platforms that want to
    ///[create and manage Express or Custom accounts](https://stripe.com/docs/connect/accounts).
    type Account = {
        ///Business information about the account.
        BusinessProfile: AccountBusinessProfile option
        ///The business type.
        BusinessType: AccountBusinessType option
        Capabilities: AccountCapabilities option
        ///Whether the account can create live charges.
        ChargesEnabled: bool option
        Company: LegalEntityCompany option
        ///The account's country.
        Country: string option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime option
        ///Three-letter ISO currency code representing the default currency for the account. This must be a currency that [Stripe supports in the account's country](https://stripe.com/docs/payouts).
        DefaultCurrency: string option
        ///Whether account details have been submitted. Standard accounts cannot receive payouts before this is true.
        DetailsSubmitted: bool option
        ///The primary user's email address.
        Email: string option
        ///External accounts (bank accounts and debit cards) currently attached to this account
        ExternalAccounts: AccountExternalAccounts option
        ///Unique identifier for the object.
        Id: string
        Individual: Person option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        ///Whether Stripe can send payouts to this account.
        PayoutsEnabled: bool option
        Requirements: AccountRequirements option
        ///Options for customizing how the account functions within Stripe.
        Settings: AccountSettings option
        TosAcceptance: AccountTosAcceptance option
        ///The Stripe account type. Can be `standard`, `express`, or `custom`.
        Type: AccountType option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "account"

        static member Create (id: string, ?businessProfile: AccountBusinessProfile option, ?businessType: AccountBusinessType option, ?capabilities: AccountCapabilities, ?chargesEnabled: bool, ?company: LegalEntityCompany, ?country: string, ?created: DateTime, ?defaultCurrency: string, ?detailsSubmitted: bool, ?email: string option, ?externalAccounts: AccountExternalAccounts, ?individual: Person, ?metadata: Map<string, string>, ?payoutsEnabled: bool, ?requirements: AccountRequirements, ?settings: AccountSettings option, ?tosAcceptance: AccountTosAcceptance, ?``type``: AccountType) =
            {
                Account.Id = id //required
                Account.BusinessProfile = businessProfile |> Option.flatten
                Account.BusinessType = businessType |> Option.flatten
                Account.Capabilities = capabilities
                Account.ChargesEnabled = chargesEnabled
                Account.Company = company
                Account.Country = country
                Account.Created = created
                Account.DefaultCurrency = defaultCurrency
                Account.DetailsSubmitted = detailsSubmitted
                Account.Email = email |> Option.flatten
                Account.ExternalAccounts = externalAccounts
                Account.Individual = individual
                Account.Metadata = metadata
                Account.PayoutsEnabled = payoutsEnabled
                Account.Requirements = requirements
                Account.Settings = settings |> Option.flatten
                Account.TosAcceptance = tosAcceptance
                Account.Type = ``type``
            }

    and AccountBusinessType =
        | Company
        | GovernmentEntity
        | Individual
        | NonProfit

    and AccountType =
        | Custom
        | Express
        | Standard

    ///External accounts (bank accounts and debit cards) currently attached to this account
    and AccountExternalAccounts = {
        ///The list contains all external accounts that have been attached to the Stripe account. These may be bank accounts or cards.
        Data: ExternalAccount list
        ///True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        ///The URL where this list can be accessed.
        Url: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
        member _.Object = "list"

        static member Create (data: ExternalAccount list, hasMore: bool, url: string) =
            {
                AccountExternalAccounts.Data = data //required
                AccountExternalAccounts.HasMore = hasMore //required
                AccountExternalAccounts.Url = url //required
            }

    and AccountBacsDebitPaymentsSettings = {
        ///The Bacs Direct Debit Display Name for this account. For payments made with Bacs Direct Debit, this will appear on the mandate, and as the statement descriptor.
        DisplayName: string option
    }
    with

        static member Create (?displayName: string) =
            {
                AccountBacsDebitPaymentsSettings.DisplayName = displayName
            }

    and AccountBrandingSettings = {
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) An icon for the account. Must be square and at least 128px x 128px.
        [<JsonField(Transform=typeof<AnyOfTransform<AccountBrandingSettingsIcon'AnyOf>>)>]Icon: AccountBrandingSettingsIcon'AnyOf option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) A logo for the account that will be used in Checkout instead of the icon and without the account's name next to it if provided. Must be at least 128px x 128px.
        [<JsonField(Transform=typeof<AnyOfTransform<AccountBrandingSettingsLogo'AnyOf>>)>]Logo: AccountBrandingSettingsLogo'AnyOf option
        ///A CSS hex color value representing the primary branding color for this account
        PrimaryColor: string option
        ///A CSS hex color value representing the secondary branding color for this account
        SecondaryColor: string option
    }
    with

        static member Create (icon: AccountBrandingSettingsIcon'AnyOf option, logo: AccountBrandingSettingsLogo'AnyOf option, primaryColor: string option, secondaryColor: string option) =
            {
                AccountBrandingSettings.Icon = icon //required
                AccountBrandingSettings.Logo = logo //required
                AccountBrandingSettings.PrimaryColor = primaryColor //required
                AccountBrandingSettings.SecondaryColor = secondaryColor //required
            }

    and AccountBrandingSettingsIcon'AnyOf =
        | String of string
        | File of File

    and AccountBrandingSettingsLogo'AnyOf =
        | String of string
        | File of File

    and AccountBusinessProfile = {
        ///[The merchant category code for the account](https://stripe.com/docs/connect/setting-mcc). MCCs are used to classify businesses based on the goods or services they provide.
        Mcc: string option
        ///The customer-facing business name.
        Name: string option
        ///Internal-only description of the product sold or service provided by the business. It's used by Stripe for risk and underwriting purposes.
        ProductDescription: string option
        ///A publicly available mailing address for sending support issues to.
        SupportAddress: Address option
        ///A publicly available email address for sending support issues to.
        SupportEmail: string option
        ///A publicly available phone number to call with support issues.
        SupportPhone: string option
        ///A publicly available website for handling support issues.
        SupportUrl: string option
        ///The business's publicly available website.
        Url: string option
    }
    with

        static member Create (mcc: string option, name: string option, supportAddress: Address option, supportEmail: string option, supportPhone: string option, supportUrl: string option, url: string option, ?productDescription: string option) =
            {
                AccountBusinessProfile.Mcc = mcc //required
                AccountBusinessProfile.Name = name //required
                AccountBusinessProfile.SupportAddress = supportAddress //required
                AccountBusinessProfile.SupportEmail = supportEmail //required
                AccountBusinessProfile.SupportPhone = supportPhone //required
                AccountBusinessProfile.SupportUrl = supportUrl //required
                AccountBusinessProfile.Url = url //required
                AccountBusinessProfile.ProductDescription = productDescription |> Option.flatten
            }

    and AccountCapabilities = {
        ///The status of the BECS Direct Debit (AU) payments capability of the account, or whether the account can directly process BECS Direct Debit (AU) charges.
        AuBecsDebitPayments: AccountCapabilitiesAuBecsDebitPayments option
        ///The status of the Bacs Direct Debits payments capability of the account, or whether the account can directly process Bacs Direct Debits charges.
        BacsDebitPayments: AccountCapabilitiesBacsDebitPayments option
        ///The status of the Bancontact payments capability of the account, or whether the account can directly process Bancontact charges.
        BancontactPayments: AccountCapabilitiesBancontactPayments option
        ///The status of the card issuing capability of the account, or whether you can use Issuing to distribute funds on cards
        CardIssuing: AccountCapabilitiesCardIssuing option
        ///The status of the card payments capability of the account, or whether the account can directly process credit and debit card charges.
        CardPayments: AccountCapabilitiesCardPayments option
        ///The status of the Cartes Bancaires payments capability of the account, or whether the account can directly process Cartes Bancaires card charges in EUR currency.
        CartesBancairesPayments: AccountCapabilitiesCartesBancairesPayments option
        ///The status of the EPS payments capability of the account, or whether the account can directly process EPS charges.
        EpsPayments: AccountCapabilitiesEpsPayments option
        ///The status of the FPX payments capability of the account, or whether the account can directly process FPX charges.
        FpxPayments: AccountCapabilitiesFpxPayments option
        ///The status of the giropay payments capability of the account, or whether the account can directly process giropay charges.
        GiropayPayments: AccountCapabilitiesGiropayPayments option
        ///The status of the GrabPay payments capability of the account, or whether the account can directly process GrabPay charges.
        GrabpayPayments: AccountCapabilitiesGrabpayPayments option
        ///The status of the iDEAL payments capability of the account, or whether the account can directly process iDEAL charges.
        IdealPayments: AccountCapabilitiesIdealPayments option
        ///The status of the JCB payments capability of the account, or whether the account (Japan only) can directly process JCB credit card charges in JPY currency.
        JcbPayments: AccountCapabilitiesJcbPayments option
        ///The status of the legacy payments capability of the account.
        LegacyPayments: AccountCapabilitiesLegacyPayments option
        ///The status of the OXXO payments capability of the account, or whether the account can directly process OXXO charges.
        OxxoPayments: AccountCapabilitiesOxxoPayments option
        ///The status of the P24 payments capability of the account, or whether the account can directly process P24 charges.
        [<JsonField(Name="p24_payments")>]P24Payments: AccountCapabilitiesP24Payments option
        ///The status of the SEPA Direct Debits payments capability of the account, or whether the account can directly process SEPA Direct Debits charges.
        SepaDebitPayments: AccountCapabilitiesSepaDebitPayments option
        ///The status of the Sofort payments capability of the account, or whether the account can directly process Sofort charges.
        SofortPayments: AccountCapabilitiesSofortPayments option
        ///The status of the tax reporting 1099-K (US) capability of the account.
        [<JsonField(Name="tax_reporting_us_1099_k")>]TaxReportingUs1099K: AccountCapabilitiesTaxReportingUs1099K option
        ///The status of the tax reporting 1099-MISC (US) capability of the account.
        [<JsonField(Name="tax_reporting_us_1099_misc")>]TaxReportingUs1099Misc: AccountCapabilitiesTaxReportingUs1099Misc option
        ///The status of the transfers capability of the account, or whether your platform can transfer funds to the account.
        Transfers: AccountCapabilitiesTransfers option
    }
    with

        static member Create (?auBecsDebitPayments: AccountCapabilitiesAuBecsDebitPayments, ?bacsDebitPayments: AccountCapabilitiesBacsDebitPayments, ?bancontactPayments: AccountCapabilitiesBancontactPayments, ?cardIssuing: AccountCapabilitiesCardIssuing, ?cardPayments: AccountCapabilitiesCardPayments, ?cartesBancairesPayments: AccountCapabilitiesCartesBancairesPayments, ?epsPayments: AccountCapabilitiesEpsPayments, ?fpxPayments: AccountCapabilitiesFpxPayments, ?giropayPayments: AccountCapabilitiesGiropayPayments, ?grabpayPayments: AccountCapabilitiesGrabpayPayments, ?idealPayments: AccountCapabilitiesIdealPayments, ?jcbPayments: AccountCapabilitiesJcbPayments, ?legacyPayments: AccountCapabilitiesLegacyPayments, ?oxxoPayments: AccountCapabilitiesOxxoPayments, ?p24Payments: AccountCapabilitiesP24Payments, ?sepaDebitPayments: AccountCapabilitiesSepaDebitPayments, ?sofortPayments: AccountCapabilitiesSofortPayments, ?taxReportingUs1099K: AccountCapabilitiesTaxReportingUs1099K, ?taxReportingUs1099Misc: AccountCapabilitiesTaxReportingUs1099Misc, ?transfers: AccountCapabilitiesTransfers) =
            {
                AccountCapabilities.AuBecsDebitPayments = auBecsDebitPayments
                AccountCapabilities.BacsDebitPayments = bacsDebitPayments
                AccountCapabilities.BancontactPayments = bancontactPayments
                AccountCapabilities.CardIssuing = cardIssuing
                AccountCapabilities.CardPayments = cardPayments
                AccountCapabilities.CartesBancairesPayments = cartesBancairesPayments
                AccountCapabilities.EpsPayments = epsPayments
                AccountCapabilities.FpxPayments = fpxPayments
                AccountCapabilities.GiropayPayments = giropayPayments
                AccountCapabilities.GrabpayPayments = grabpayPayments
                AccountCapabilities.IdealPayments = idealPayments
                AccountCapabilities.JcbPayments = jcbPayments
                AccountCapabilities.LegacyPayments = legacyPayments
                AccountCapabilities.OxxoPayments = oxxoPayments
                AccountCapabilities.P24Payments = p24Payments
                AccountCapabilities.SepaDebitPayments = sepaDebitPayments
                AccountCapabilities.SofortPayments = sofortPayments
                AccountCapabilities.TaxReportingUs1099K = taxReportingUs1099K
                AccountCapabilities.TaxReportingUs1099Misc = taxReportingUs1099Misc
                AccountCapabilities.Transfers = transfers
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

    and AccountCapabilityRequirements = {
        ///The date the fields in `currently_due` must be collected by to keep the capability enabled for the account.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]CurrentDeadline: DateTime option
        ///The fields that need to be collected to keep the capability enabled. If not collected by the `current_deadline`, these fields appear in `past_due` as well, and the capability is disabled.
        CurrentlyDue: string list
        ///If the capability is disabled, this string describes why. Possible values are `requirement.fields_needed`, `pending.onboarding`, `pending.review`, `rejected_fraud`, or `rejected.other`.
        DisabledReason: AccountCapabilityRequirementsDisabledReason option
        ///The fields that are `currently_due` and need to be collected again because validation or verification failed for some reason.
        Errors: AccountRequirementsError list
        ///The fields that need to be collected assuming all volume thresholds are reached. As they become required, these fields appear in `currently_due` as well, and the `current_deadline` is set.
        EventuallyDue: string list
        ///The fields that weren't collected by the `current_deadline`. These fields need to be collected to enable the capability for the account.
        PastDue: string list
        ///Fields that may become required depending on the results of verification or review. An empty array unless an asynchronous verification is pending. If verification fails, the fields in this array become required and move to `currently_due` or `past_due`.
        PendingVerification: string list
    }
    with

        static member Create (currentDeadline: DateTime option, currentlyDue: string list, disabledReason: AccountCapabilityRequirementsDisabledReason option, errors: AccountRequirementsError list, eventuallyDue: string list, pastDue: string list, pendingVerification: string list) =
            {
                AccountCapabilityRequirements.CurrentDeadline = currentDeadline //required
                AccountCapabilityRequirements.CurrentlyDue = currentlyDue //required
                AccountCapabilityRequirements.DisabledReason = disabledReason //required
                AccountCapabilityRequirements.Errors = errors //required
                AccountCapabilityRequirements.EventuallyDue = eventuallyDue //required
                AccountCapabilityRequirements.PastDue = pastDue //required
                AccountCapabilityRequirements.PendingVerification = pendingVerification //required
            }

    and AccountCapabilityRequirementsDisabledReason =
        | [<JsonUnionCase("requirement.fields_needed")>] RequirementFieldsNeeded
        | [<JsonUnionCase("pending.onboarding")>] PendingOnboarding
        | [<JsonUnionCase("pending.review")>] PendingReview
        | RejectedFraud
        | [<JsonUnionCase("rejected.other")>] RejectedOther

    and AccountCardPaymentsSettings = {
        DeclineOn: AccountDeclineChargeOn option
        ///The default text that appears on credit card statements when a charge is made. This field prefixes any dynamic `statement_descriptor` specified on the charge. `statement_descriptor_prefix` is useful for maximizing descriptor space for the dynamic portion.
        StatementDescriptorPrefix: string option
    }
    with

        static member Create (statementDescriptorPrefix: string option, ?declineOn: AccountDeclineChargeOn) =
            {
                AccountCardPaymentsSettings.StatementDescriptorPrefix = statementDescriptorPrefix //required
                AccountCardPaymentsSettings.DeclineOn = declineOn
            }

    and AccountDashboardSettings = {
        ///The display name for this account. This is used on the Stripe Dashboard to differentiate between accounts.
        DisplayName: string option
        ///The timezone used in the Stripe Dashboard for this account. A list of possible time zone values is maintained at the [IANA Time Zone Database](http://www.iana.org/time-zones).
        Timezone: string option
    }
    with

        static member Create (displayName: string option, timezone: string option) =
            {
                AccountDashboardSettings.DisplayName = displayName //required
                AccountDashboardSettings.Timezone = timezone //required
            }

    and AccountDeclineChargeOn = {
        ///Whether Stripe automatically declines charges with an incorrect ZIP or postal code. This setting only applies when a ZIP or postal code is provided and they fail bank verification.
        AvsFailure: bool
        ///Whether Stripe automatically declines charges with an incorrect CVC. This setting only applies when a CVC is provided and it fails bank verification.
        CvcFailure: bool
    }
    with

        static member Create (avsFailure: bool, cvcFailure: bool) =
            {
                AccountDeclineChargeOn.AvsFailure = avsFailure //required
                AccountDeclineChargeOn.CvcFailure = cvcFailure //required
            }

    ///Account Links are the means by which a Connect platform grants a connected account permission to access
    ///Stripe-hosted applications, such as Connect Onboarding.
    ///Related guide: [Connect Onboarding](https://stripe.com/docs/connect/connect-onboarding).
    and AccountLink = {
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///The timestamp at which this account link will expire.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]ExpiresAt: DateTime
        ///The URL for the account link.
        Url: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "account_link"

        static member Create (created: DateTime, expiresAt: DateTime, url: string) =
            {
                AccountLink.Created = created //required
                AccountLink.ExpiresAt = expiresAt //required
                AccountLink.Url = url //required
            }

    and AccountPaymentsSettings = {
        ///The default text that appears on credit card statements when a charge is made. This field prefixes any dynamic `statement_descriptor` specified on the charge.
        StatementDescriptor: string option
        ///The Kana variation of the default text that appears on credit card statements when a charge is made (Japan only)
        StatementDescriptorKana: string option
        ///The Kanji variation of the default text that appears on credit card statements when a charge is made (Japan only)
        StatementDescriptorKanji: string option
    }
    with

        static member Create (statementDescriptor: string option, statementDescriptorKana: string option, statementDescriptorKanji: string option) =
            {
                AccountPaymentsSettings.StatementDescriptor = statementDescriptor //required
                AccountPaymentsSettings.StatementDescriptorKana = statementDescriptorKana //required
                AccountPaymentsSettings.StatementDescriptorKanji = statementDescriptorKanji //required
            }

    and AccountPayoutSettings = {
        ///A Boolean indicating if Stripe should try to reclaim negative balances from an attached bank account. See our [Understanding Connect Account Balances](https://stripe.com/docs/connect/account-balances) documentation for details. Default value is `true` for Express accounts and `false` for Custom accounts.
        DebitNegativeBalances: bool
        Schedule: TransferSchedule
        ///The text that appears on the bank account statement for payouts. If not set, this defaults to the platform's bank descriptor as set in the Dashboard.
        StatementDescriptor: string option
    }
    with

        static member Create (debitNegativeBalances: bool, schedule: TransferSchedule, statementDescriptor: string option) =
            {
                AccountPayoutSettings.DebitNegativeBalances = debitNegativeBalances //required
                AccountPayoutSettings.Schedule = schedule //required
                AccountPayoutSettings.StatementDescriptor = statementDescriptor //required
            }

    and AccountRequirements = {
        ///The date the fields in `currently_due` must be collected by to keep payouts enabled for the account. These fields might block payouts sooner if the next threshold is reached before these fields are collected.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]CurrentDeadline: DateTime option
        ///The fields that need to be collected to keep the account enabled. If not collected by the `current_deadline`, these fields appear in `past_due` as well, and the account is disabled.
        CurrentlyDue: string list option
        ///If the account is disabled, this string describes why the account can’t create charges or receive payouts. Can be `requirements.past_due`, `requirements.pending_verification`, `rejected.fraud`, `rejected.terms_of_service`, `rejected.listed`, `rejected.other`, `listed`, `under_review`, or `other`.
        DisabledReason: AccountRequirementsDisabledReason option
        ///The fields that are `currently_due` and need to be collected again because validation or verification failed for some reason.
        Errors: AccountRequirementsError list option
        ///The fields that need to be collected assuming all volume thresholds are reached. As they become required, these fields appear in `currently_due` as well, and the `current_deadline` is set.
        EventuallyDue: string list option
        ///The fields that weren't collected by the `current_deadline`. These fields need to be collected to re-enable the account.
        PastDue: string list option
        ///Fields that may become required depending on the results of verification or review. An empty array unless an asynchronous verification is pending. If verification fails, the fields in this array become required and move to `currently_due` or `past_due`.
        PendingVerification: string list option
    }
    with

        static member Create (currentDeadline: DateTime option, currentlyDue: string list option, disabledReason: AccountRequirementsDisabledReason option, errors: AccountRequirementsError list option, eventuallyDue: string list option, pastDue: string list option, pendingVerification: string list option) =
            {
                AccountRequirements.CurrentDeadline = currentDeadline //required
                AccountRequirements.CurrentlyDue = currentlyDue //required
                AccountRequirements.DisabledReason = disabledReason //required
                AccountRequirements.Errors = errors //required
                AccountRequirements.EventuallyDue = eventuallyDue //required
                AccountRequirements.PastDue = pastDue //required
                AccountRequirements.PendingVerification = pendingVerification //required
            }

    and AccountRequirementsDisabledReason =
        | [<JsonUnionCase("requirements.past_due")>] RequirementsPastDue
        | [<JsonUnionCase("requirements.pending_verification")>] RequirementsPendingVerification
        | [<JsonUnionCase("rejected.fraud")>] RejectedFraud
        | [<JsonUnionCase("rejected.terms_of_service")>] RejectedTermsOfService
        | [<JsonUnionCase("rejected.listed")>] RejectedListed
        | [<JsonUnionCase("rejected.other")>] RejectedOther
        | Listed
        | UnderReview
        | Other

    and AccountRequirementsError = {
        ///The code for the type of error.
        Code: AccountRequirementsErrorCode
        ///An informative message that indicates the error type and provides additional details about the error.
        Reason: string
        ///The specific user onboarding requirement field (in the requirements hash) that needs to be resolved.
        Requirement: string
    }
    with

        static member Create (code: AccountRequirementsErrorCode, reason: string, requirement: string) =
            {
                AccountRequirementsError.Code = code //required
                AccountRequirementsError.Reason = reason //required
                AccountRequirementsError.Requirement = requirement //required
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

    and AccountSepaDebitPaymentsSettings = {
        ///SEPA creditor identifier that identifies the company making the payment.
        CreditorId: string option
    }
    with

        static member Create (?creditorId: string) =
            {
                AccountSepaDebitPaymentsSettings.CreditorId = creditorId
            }

    and AccountSettings = {
        BacsDebitPayments: AccountBacsDebitPaymentsSettings option
        Branding: AccountBrandingSettings
        CardPayments: AccountCardPaymentsSettings
        Dashboard: AccountDashboardSettings
        Payments: AccountPaymentsSettings
        Payouts: AccountPayoutSettings option
        SepaDebitPayments: AccountSepaDebitPaymentsSettings option
    }
    with

        static member Create (branding: AccountBrandingSettings, cardPayments: AccountCardPaymentsSettings, dashboard: AccountDashboardSettings, payments: AccountPaymentsSettings, ?bacsDebitPayments: AccountBacsDebitPaymentsSettings, ?payouts: AccountPayoutSettings, ?sepaDebitPayments: AccountSepaDebitPaymentsSettings) =
            {
                AccountSettings.Branding = branding //required
                AccountSettings.CardPayments = cardPayments //required
                AccountSettings.Dashboard = dashboard //required
                AccountSettings.Payments = payments //required
                AccountSettings.BacsDebitPayments = bacsDebitPayments
                AccountSettings.Payouts = payouts
                AccountSettings.SepaDebitPayments = sepaDebitPayments
            }

    and AccountTosAcceptance = {
        ///The Unix timestamp marking when the account representative accepted their service agreement
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Date: DateTime option
        ///The IP address from which the account representative accepted their service agreement
        Ip: string option
        ///The user's service agreement type
        ServiceAgreement: string option
        ///The user agent of the browser from which the account representative accepted their service agreement
        UserAgent: string option
    }
    with

        static member Create (?date: DateTime option, ?ip: string option, ?serviceAgreement: string, ?userAgent: string option) =
            {
                AccountTosAcceptance.Date = date |> Option.flatten
                AccountTosAcceptance.Ip = ip |> Option.flatten
                AccountTosAcceptance.ServiceAgreement = serviceAgreement
                AccountTosAcceptance.UserAgent = userAgent |> Option.flatten
            }

    and Address = {
        ///City, district, suburb, town, or village.
        City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<JsonField(Name="line1")>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<JsonField(Name="line2")>]Line2: string option
        ///ZIP or postal code.
        PostalCode: string option
        ///State, county, province, or region.
        State: string option
    }
    with

        static member Create (city: string option, country: string option, line1: string option, line2: string option, postalCode: string option, state: string option) =
            {
                Address.City = city //required
                Address.Country = country //required
                Address.Line1 = line1 //required
                Address.Line2 = line2 //required
                Address.PostalCode = postalCode //required
                Address.State = state //required
            }

    and AlipayAccount = {
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///The ID of the customer associated with this Alipay Account.
        [<JsonField(Transform=typeof<AnyOfTransform<AlipayAccountCustomer'AnyOf>>)>]Customer: AlipayAccountCustomer'AnyOf option
        ///Uniquely identifies the account and will be the same across all Alipay account objects that are linked to the same Alipay account.
        Fingerprint: string
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        ///If the Alipay account object is not reusable, the exact amount that you can create a charge for.
        PaymentAmount: int option
        ///If the Alipay account object is not reusable, the exact currency that you can create a charge for.
        PaymentCurrency: string option
        ///True if you can create multiple payments using this account. If the account is reusable, then you can freely choose the amount of each payment.
        Reusable: bool
        ///Whether this Alipay account object has ever been used for a payment.
        Used: bool
        ///The username for the Alipay account.
        Username: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "alipay_account"

        static member Create (created: DateTime, fingerprint: string, id: string, livemode: bool, paymentAmount: int option, paymentCurrency: string option, reusable: bool, used: bool, username: string, ?customer: AlipayAccountCustomer'AnyOf option, ?metadata: Map<string, string>) =
            {
                AlipayAccount.Created = created //required
                AlipayAccount.Fingerprint = fingerprint //required
                AlipayAccount.Id = id //required
                AlipayAccount.Livemode = livemode //required
                AlipayAccount.PaymentAmount = paymentAmount //required
                AlipayAccount.PaymentCurrency = paymentCurrency //required
                AlipayAccount.Reusable = reusable //required
                AlipayAccount.Used = used //required
                AlipayAccount.Username = username //required
                AlipayAccount.Customer = customer |> Option.flatten
                AlipayAccount.Metadata = metadata
            }

    and AlipayAccountCustomer'AnyOf =
        | String of string
        | Customer of Customer
        | DeletedCustomer of DeletedCustomer

    and AlternateStatementDescriptors = {
        ///The Kana variation of the descriptor.
        Kana: string option
        ///The Kanji variation of the descriptor.
        Kanji: string option
    }
    with

        static member Create (?kana: string, ?kanji: string) =
            {
                AlternateStatementDescriptors.Kana = kana
                AlternateStatementDescriptors.Kanji = kanji
            }

    and ApiErrors = {
        ///For card errors, the ID of the failed charge.
        Charge: string option
        ///For some errors that could be handled programmatically, a short string indicating the [error code](https://stripe.com/docs/error-codes) reported.
        Code: string option
        ///For card errors resulting from a card issuer decline, a short string indicating the [card issuer's reason for the decline](https://stripe.com/docs/declines#issuer-declines) if they provide one.
        DeclineCode: string option
        ///A URL to more information about the [error code](https://stripe.com/docs/error-codes) reported.
        DocUrl: string option
        ///A human-readable message providing more details about the error. For card errors, these messages can be shown to your users.
        Message: string option
        ///If the error is parameter-specific, the parameter related to the error. For example, you can use this to display a message near the correct form field.
        Param: string option
        PaymentIntent: PaymentIntent option
        PaymentMethod: PaymentMethod option
        ///If the error is specific to the type of payment method, the payment method type that had a problem. This field is only populated for invoice-related errors.
        PaymentMethodType: string option
        SetupIntent: SetupIntent option
        Source: PaymentSource option
        ///The type of error returned. One of `api_connection_error`, `api_error`, `authentication_error`, `card_error`, `idempotency_error`, `invalid_request_error`, or `rate_limit_error`
        Type: ApiErrorsType
    }
    with

        static member Create (``type``: ApiErrorsType, ?charge: string, ?code: string, ?declineCode: string, ?docUrl: string, ?message: string, ?param: string, ?paymentIntent: PaymentIntent, ?paymentMethod: PaymentMethod, ?paymentMethodType: string, ?setupIntent: SetupIntent, ?source: PaymentSource) =
            {
                ApiErrors.Type = ``type`` //required
                ApiErrors.Charge = charge
                ApiErrors.Code = code
                ApiErrors.DeclineCode = declineCode
                ApiErrors.DocUrl = docUrl
                ApiErrors.Message = message
                ApiErrors.Param = param
                ApiErrors.PaymentIntent = paymentIntent
                ApiErrors.PaymentMethod = paymentMethod
                ApiErrors.PaymentMethodType = paymentMethodType
                ApiErrors.SetupIntent = setupIntent
                ApiErrors.Source = source
            }

    and ApiErrorsType =
        | ApiConnectionError
        | ApiError
        | AuthenticationError
        | CardError
        | IdempotencyError
        | InvalidRequestError
        | RateLimitError

    and ApplePayDomain = {
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        DomainName: string
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "apple_pay_domain"

        static member Create (created: DateTime, domainName: string, id: string, livemode: bool) =
            {
                ApplePayDomain.Created = created //required
                ApplePayDomain.DomainName = domainName //required
                ApplePayDomain.Id = id //required
                ApplePayDomain.Livemode = livemode //required
            }

    and Application = {
        ///Unique identifier for the object.
        Id: string
        ///The name of the application.
        Name: string option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "application"

        static member Create (id: string, name: string option) =
            {
                Application.Id = id //required
                Application.Name = name //required
            }

    and ApplicationFee = {
        ///ID of the Stripe account this fee was taken from.
        [<JsonField(Transform=typeof<AnyOfTransform<ApplicationFeeAccount'AnyOf>>)>]Account: ApplicationFeeAccount'AnyOf
        ///Amount earned, in %s.
        Amount: int
        ///Amount in %s refunded (can be less than the amount attribute on the fee if a partial refund was issued)
        AmountRefunded: int
        ///ID of the Connect application that earned the fee.
        [<JsonField(Transform=typeof<AnyOfTransform<ApplicationFeeApplication'AnyOf>>)>]Application: ApplicationFeeApplication'AnyOf
        ///Balance transaction that describes the impact of this collected application fee on your account balance (not including refunds).
        [<JsonField(Transform=typeof<AnyOfTransform<ApplicationFeeBalanceTransaction'AnyOf>>)>]BalanceTransaction: ApplicationFeeBalanceTransaction'AnyOf option
        ///ID of the charge that the application fee was taken from.
        [<JsonField(Transform=typeof<AnyOfTransform<ApplicationFeeCharge'AnyOf>>)>]Charge: ApplicationFeeCharge'AnyOf
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///ID of the corresponding charge on the platform account, if this fee was the result of a charge using the `destination` parameter.
        [<JsonField(Transform=typeof<AnyOfTransform<ApplicationFeeOriginatingTransaction'AnyOf>>)>]OriginatingTransaction: ApplicationFeeOriginatingTransaction'AnyOf option
        ///Whether the fee has been fully refunded. If the fee is only partially refunded, this attribute will still be false.
        Refunded: bool
        ///A list of refunds that have been applied to the fee.
        Refunds: ApplicationFeeRefunds
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "application_fee"

        static member Create (account: ApplicationFeeAccount'AnyOf, amount: int, amountRefunded: int, application: ApplicationFeeApplication'AnyOf, balanceTransaction: ApplicationFeeBalanceTransaction'AnyOf option, charge: ApplicationFeeCharge'AnyOf, created: DateTime, currency: string, id: string, livemode: bool, originatingTransaction: ApplicationFeeOriginatingTransaction'AnyOf option, refunded: bool, refunds: ApplicationFeeRefunds) =
            {
                ApplicationFee.Account = account //required
                ApplicationFee.Amount = amount //required
                ApplicationFee.AmountRefunded = amountRefunded //required
                ApplicationFee.Application = application //required
                ApplicationFee.BalanceTransaction = balanceTransaction //required
                ApplicationFee.Charge = charge //required
                ApplicationFee.Created = created //required
                ApplicationFee.Currency = currency //required
                ApplicationFee.Id = id //required
                ApplicationFee.Livemode = livemode //required
                ApplicationFee.OriginatingTransaction = originatingTransaction //required
                ApplicationFee.Refunded = refunded //required
                ApplicationFee.Refunds = refunds //required
            }

    and ApplicationFeeAccount'AnyOf =
        | String of string
        | Account of Account

    and ApplicationFeeApplication'AnyOf =
        | String of string
        | Application of Application

    and ApplicationFeeBalanceTransaction'AnyOf =
        | String of string
        | BalanceTransaction of BalanceTransaction

    and ApplicationFeeCharge'AnyOf =
        | String of string
        | Charge of Charge

    and ApplicationFeeOriginatingTransaction'AnyOf =
        | String of string
        | Charge of Charge

    ///A list of refunds that have been applied to the fee.
    and ApplicationFeeRefunds = {
        ///Details about each object.
        Data: FeeRefund list
        ///True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        ///The URL where this list can be accessed.
        Url: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
        member _.Object = "list"

        static member Create (data: FeeRefund list, hasMore: bool, url: string) =
            {
                ApplicationFeeRefunds.Data = data //required
                ApplicationFeeRefunds.HasMore = hasMore //required
                ApplicationFeeRefunds.Url = url //required
            }

    ///This is an object representing your Stripe balance. You can retrieve it to see
    ///the balance currently on your Stripe account.
    ///You can also retrieve the balance history, which contains a list of
    ///[transactions](https://stripe.com/docs/reporting/balance-transaction-types) that contributed to the balance
    ///(charges, payouts, and so forth).
    ///The available and pending amounts for each currency are broken down further by
    ///payment source types.
    ///Related guide: [Understanding Connect Account Balances](https://stripe.com/docs/connect/account-balances).
    and Balance = {
        ///Funds that are available to be transferred or paid out, whether automatically by Stripe or explicitly via the [Transfers API](https://stripe.com/docs/api#transfers) or [Payouts API](https://stripe.com/docs/api#payouts). The available balance for each currency and payment type can be found in the `source_types` property.
        Available: BalanceAmount list
        ///Funds held due to negative balances on connected Custom accounts. The connect reserve balance for each currency and payment type can be found in the `source_types` property.
        ConnectReserved: BalanceAmount list option
        ///Funds that can be paid out using Instant Payouts.
        InstantAvailable: BalanceAmount list option
        Issuing: BalanceDetail option
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Funds that are not yet available in the balance, due to the 7-day rolling pay cycle. The pending balance for each currency, and for each payment type, can be found in the `source_types` property.
        Pending: BalanceAmount list
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "balance"

        static member Create (available: BalanceAmount list, livemode: bool, pending: BalanceAmount list, ?connectReserved: BalanceAmount list, ?instantAvailable: BalanceAmount list, ?issuing: BalanceDetail) =
            {
                Balance.Available = available //required
                Balance.Livemode = livemode //required
                Balance.Pending = pending //required
                Balance.ConnectReserved = connectReserved
                Balance.InstantAvailable = instantAvailable
                Balance.Issuing = issuing
            }

    and BalanceAmount = {
        ///Balance amount.
        Amount: int
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        SourceTypes: BalanceAmountBySourceType option
    }
    with

        static member Create (amount: int, currency: string, ?sourceTypes: BalanceAmountBySourceType) =
            {
                BalanceAmount.Amount = amount //required
                BalanceAmount.Currency = currency //required
                BalanceAmount.SourceTypes = sourceTypes
            }

    and BalanceAmountBySourceType = {
        ///Amount for bank account.
        BankAccount: int option
        ///Amount for card.
        Card: int option
        ///Amount for FPX.
        Fpx: int option
    }
    with

        static member Create (?bankAccount: int, ?card: int, ?fpx: int) =
            {
                BalanceAmountBySourceType.BankAccount = bankAccount
                BalanceAmountBySourceType.Card = card
                BalanceAmountBySourceType.Fpx = fpx
            }

    and BalanceDetail = {
        ///Funds that are available for use.
        Available: BalanceAmount list
    }
    with

        static member Create (available: BalanceAmount list) =
            {
                BalanceDetail.Available = available //required
            }

    ///Balance transactions represent funds moving through your Stripe account.
    ///They're created for every type of transaction that comes into or flows out of your Stripe account balance.
    ///Related guide: [Balance Transaction Types](https://stripe.com/docs/reports/balance-transaction-types).
    and BalanceTransaction = {
        ///Gross amount of the transaction, in %s.
        Amount: int
        ///The date the transaction's net funds will become available in the Stripe balance.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]AvailableOn: DateTime
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        ///The exchange rate used, if applicable, for this transaction. Specifically, if money was converted from currency A to currency B, then the `amount` in currency A, times `exchange_rate`, would be the `amount` in currency B. For example, suppose you charged a customer 10.00 EUR. Then the PaymentIntent's `amount` would be `1000` and `currency` would be `eur`. Suppose this was converted into 12.34 USD in your Stripe account. Then the BalanceTransaction's `amount` would be `1234`, `currency` would be `usd`, and `exchange_rate` would be `1.234`.
        ExchangeRate: decimal option
        ///Fees (in %s) paid for this transaction.
        Fee: int
        ///Detailed breakdown of fees (in %s) paid for this transaction.
        FeeDetails: Fee list
        ///Unique identifier for the object.
        Id: string
        ///Net amount of the transaction, in %s.
        Net: int
        ///[Learn more](https://stripe.com/docs/reports/reporting-categories) about how reporting categories can help you understand balance transactions from an accounting perspective.
        ReportingCategory: string
        ///The Stripe object to which this transaction is related.
        [<JsonField(Transform=typeof<AnyOfTransform<BalanceTransactionSource'AnyOf>>)>]Source: BalanceTransactionSource'AnyOf option
        ///If the transaction's net funds are available in the Stripe balance yet. Either `available` or `pending`.
        Status: BalanceTransactionStatus
        ///Transaction type: `adjustment`, `advance`, `advance_funding`, `anticipation_repayment`, `application_fee`, `application_fee_refund`, `charge`, `connect_collection_transfer`, `contribution`, `issuing_authorization_hold`, `issuing_authorization_release`, `issuing_dispute`, `issuing_transaction`, `payment`, `payment_failure_refund`, `payment_refund`, `payout`, `payout_cancel`, `payout_failure`, `refund`, `refund_failure`, `reserve_transaction`, `reserved_funds`, `stripe_fee`, `stripe_fx_fee`, `tax_fee`, `topup`, `topup_reversal`, `transfer`, `transfer_cancel`, `transfer_failure`, or `transfer_refund`. [Learn more](https://stripe.com/docs/reports/balance-transaction-types) about balance transaction types and what they represent. If you are looking to classify transactions for accounting purposes, you might want to consider `reporting_category` instead.
        Type: BalanceTransactionType
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "balance_transaction"

        static member Create (amount: int, availableOn: DateTime, created: DateTime, currency: string, description: string option, exchangeRate: decimal option, fee: int, feeDetails: Fee list, id: string, net: int, reportingCategory: string, source: BalanceTransactionSource'AnyOf option, status: BalanceTransactionStatus, ``type``: BalanceTransactionType) =
            {
                BalanceTransaction.Amount = amount //required
                BalanceTransaction.AvailableOn = availableOn //required
                BalanceTransaction.Created = created //required
                BalanceTransaction.Currency = currency //required
                BalanceTransaction.Description = description //required
                BalanceTransaction.ExchangeRate = exchangeRate //required
                BalanceTransaction.Fee = fee //required
                BalanceTransaction.FeeDetails = feeDetails //required
                BalanceTransaction.Id = id //required
                BalanceTransaction.Net = net //required
                BalanceTransaction.ReportingCategory = reportingCategory //required
                BalanceTransaction.Source = source //required
                BalanceTransaction.Status = status //required
                BalanceTransaction.Type = ``type`` //required
            }

    and BalanceTransactionSource'AnyOf =
        | String of string
        | BalanceTransactionSource of BalanceTransactionSource

    and BalanceTransactionStatus =
        | Available
        | Pending

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
    ///On the other hand [External Accounts](https://stripe.com/docs/api#external_accounts) are transfer
    ///destinations on `Account` objects for [Custom accounts](https://stripe.com/docs/connect/custom-accounts).
    ///They can be bank accounts or debit cards as well, and are documented in the links above.
    ///Related guide: [Bank Debits and Transfers](https://stripe.com/docs/payments/bank-debits-transfers).
    and BankAccount = {
        ///The ID of the account that the bank account is associated with.
        [<JsonField(Transform=typeof<AnyOfTransform<BankAccountAccount'AnyOf>>)>]Account: BankAccountAccount'AnyOf option
        ///The name of the person or business that owns the bank account.
        AccountHolderName: string option
        ///The type of entity that holds the account. This can be either `individual` or `company`.
        AccountHolderType: BankAccountAccountHolderType option
        ///A set of available payout methods for this bank account. Only values from this set should be passed as the `method` when creating a payout.
        AvailablePayoutMethods: BankAccountAvailablePayoutMethods list option
        ///Name of the bank associated with the routing number (e.g., `WELLS FARGO`).
        BankName: string option
        ///Two-letter ISO code representing the country the bank account is located in.
        Country: string
        ///Three-letter [ISO code for the currency](https://stripe.com/docs/payouts) paid out to the bank account.
        Currency: string
        ///The ID of the customer that the bank account is associated with.
        [<JsonField(Transform=typeof<AnyOfTransform<BankAccountCustomer'AnyOf>>)>]Customer: BankAccountCustomer'AnyOf option
        ///Whether this bank account is the default external account for its currency.
        DefaultForCurrency: bool option
        ///Uniquely identifies this particular bank account. You can use this attribute to check whether two bank accounts are the same.
        Fingerprint: string option
        ///Unique identifier for the object.
        Id: string
        ///The last four digits of the bank account number.
        [<JsonField(Name="last4")>]Last4: string
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        ///The routing transit number for the bank account.
        RoutingNumber: string option
        ///For bank accounts, possible values are `new`, `validated`, `verified`, `verification_failed`, or `errored`. A bank account that hasn't had any activity or validation performed is `new`. If Stripe can determine that the bank account exists, its status will be `validated`. Note that there often isn’t enough information to know (e.g., for smaller credit unions), and the validation is not always run. If customer bank account verification has succeeded, the bank account status will be `verified`. If the verification failed for any reason, such as microdeposit failure, the status will be `verification_failed`. If a transfer sent to this bank account fails, we'll set the status to `errored` and will not continue to send transfers until the bank details are updated.
    ///For external accounts, possible values are `new` and `errored`. Validations aren't run against external accounts because they're only used for payouts. This means the other statuses don't apply. If a transfer fails, the status is set to `errored` and transfers are stopped until account details are updated.
        Status: BankAccountStatus
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "bank_account"

        static member Create (accountHolderName: string option, accountHolderType: BankAccountAccountHolderType option, bankName: string option, country: string, currency: string, fingerprint: string option, id: string, last4: string, routingNumber: string option, status: BankAccountStatus, ?account: BankAccountAccount'AnyOf option, ?availablePayoutMethods: BankAccountAvailablePayoutMethods list option, ?customer: BankAccountCustomer'AnyOf option, ?defaultForCurrency: bool option, ?metadata: Map<string, string> option) =
            {
                BankAccount.AccountHolderName = accountHolderName //required
                BankAccount.AccountHolderType = accountHolderType //required
                BankAccount.BankName = bankName //required
                BankAccount.Country = country //required
                BankAccount.Currency = currency //required
                BankAccount.Fingerprint = fingerprint //required
                BankAccount.Id = id //required
                BankAccount.Last4 = last4 //required
                BankAccount.RoutingNumber = routingNumber //required
                BankAccount.Status = status //required
                BankAccount.Account = account |> Option.flatten
                BankAccount.AvailablePayoutMethods = availablePayoutMethods |> Option.flatten
                BankAccount.Customer = customer |> Option.flatten
                BankAccount.DefaultForCurrency = defaultForCurrency |> Option.flatten
                BankAccount.Metadata = metadata |> Option.flatten
            }

    and BankAccountAccount'AnyOf =
        | String of string
        | Account of Account

    and BankAccountAccountHolderType =
        | Individual
        | Company

    and BankAccountCustomer'AnyOf =
        | String of string
        | Customer of Customer
        | DeletedCustomer of DeletedCustomer

    and BankAccountStatus =
        | New
        | Validated
        | Verified
        | VerificationFailed
        | Errored

    and BankAccountAvailablePayoutMethods =
        | Instant
        | Standard

    and BillingDetails = {
        ///Billing address.
        Address: Address option
        ///Email address.
        Email: string option
        ///Full name.
        Name: string option
        ///Billing phone number (including extension).
        Phone: string option
    }
    with

        static member Create (address: Address option, email: string option, name: string option, phone: string option) =
            {
                BillingDetails.Address = address //required
                BillingDetails.Email = email //required
                BillingDetails.Name = name //required
                BillingDetails.Phone = phone //required
            }

    ///A session describes the instantiation of the customer portal for
    ///a particular customer. By visiting the session's URL, the customer
    ///can manage their subscriptions and billing details. For security reasons,
    ///sessions are short-lived and will expire if the customer does not visit the URL.
    ///Create sessions on-demand when customers intend to manage their subscriptions and billing details.
    ///Integration guide: [Billing customer portal](https://stripe.com/docs/billing/subscriptions/integrating-customer-portal).
    and BillingPortalSession = {
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///The ID of the customer for this session.
        Customer: string
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///The URL to which Stripe should send customers when they click on the link to return to your website.
        ReturnUrl: string
        ///The short-lived URL of the session giving customers access to the customer portal.
        Url: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "billing_portal.session"

        static member Create (created: DateTime, customer: string, id: string, livemode: bool, returnUrl: string, url: string) =
            {
                BillingPortalSession.Created = created //required
                BillingPortalSession.Customer = customer //required
                BillingPortalSession.Id = id //required
                BillingPortalSession.Livemode = livemode //required
                BillingPortalSession.ReturnUrl = returnUrl //required
                BillingPortalSession.Url = url //required
            }

    and BitcoinReceiver = {
        ///True when this bitcoin receiver has received a non-zero amount of bitcoin.
        Active: bool
        ///The amount of `currency` that you are collecting as payment.
        Amount: int
        ///The amount of `currency` to which `bitcoin_amount_received` has been converted.
        AmountReceived: int
        ///The amount of bitcoin that the customer should send to fill the receiver. The `bitcoin_amount` is denominated in Satoshi: there are 10^8 Satoshi in one bitcoin.
        BitcoinAmount: int
        ///The amount of bitcoin that has been sent by the customer to this receiver.
        BitcoinAmountReceived: int
        ///This URI can be displayed to the customer as a clickable link (to activate their bitcoin client) or as a QR code (for mobile wallets).
        BitcoinUri: string
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO code for the currency](https://stripe.com/docs/currencies) to which the bitcoin will be converted.
        Currency: string
        ///The customer ID of the bitcoin receiver.
        Customer: string option
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        ///The customer's email address, set by the API call that creates the receiver.
        Email: string option
        ///This flag is initially false and updates to true when the customer sends the `bitcoin_amount` to this receiver.
        Filled: bool
        ///Unique identifier for the object.
        Id: string
        ///A bitcoin address that is specific to this receiver. The customer can send bitcoin to this address to fill the receiver.
        InboundAddress: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        ///The ID of the payment created from the receiver, if any. Hidden when viewing the receiver with a publishable key.
        Payment: string option
        ///The refund address of this bitcoin receiver.
        RefundAddress: string option
        ///A list with one entry for each time that the customer sent bitcoin to the receiver. Hidden when viewing the receiver with a publishable key.
        Transactions: BitcoinReceiverTransactions option
        ///This receiver contains uncaptured funds that can be used for a payment or refunded.
        UncapturedFunds: bool
        ///Indicate if this source is used for payment.
        UsedForPayment: bool option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "bitcoin_receiver"

        static member Create (active: bool, amount: int, amountReceived: int, bitcoinAmount: int, bitcoinAmountReceived: int, bitcoinUri: string, created: DateTime, currency: string, description: string option, email: string option, filled: bool, id: string, inboundAddress: string, livemode: bool, metadata: Map<string, string> option, refundAddress: string option, uncapturedFunds: bool, usedForPayment: bool option, ?customer: string option, ?payment: string option, ?transactions: BitcoinReceiverTransactions) =
            {
                BitcoinReceiver.Active = active //required
                BitcoinReceiver.Amount = amount //required
                BitcoinReceiver.AmountReceived = amountReceived //required
                BitcoinReceiver.BitcoinAmount = bitcoinAmount //required
                BitcoinReceiver.BitcoinAmountReceived = bitcoinAmountReceived //required
                BitcoinReceiver.BitcoinUri = bitcoinUri //required
                BitcoinReceiver.Created = created //required
                BitcoinReceiver.Currency = currency //required
                BitcoinReceiver.Description = description //required
                BitcoinReceiver.Email = email //required
                BitcoinReceiver.Filled = filled //required
                BitcoinReceiver.Id = id //required
                BitcoinReceiver.InboundAddress = inboundAddress //required
                BitcoinReceiver.Livemode = livemode //required
                BitcoinReceiver.Metadata = metadata //required
                BitcoinReceiver.RefundAddress = refundAddress //required
                BitcoinReceiver.UncapturedFunds = uncapturedFunds //required
                BitcoinReceiver.UsedForPayment = usedForPayment //required
                BitcoinReceiver.Customer = customer |> Option.flatten
                BitcoinReceiver.Payment = payment |> Option.flatten
                BitcoinReceiver.Transactions = transactions
            }

    ///A list with one entry for each time that the customer sent bitcoin to the receiver. Hidden when viewing the receiver with a publishable key.
    and BitcoinReceiverTransactions = {
        ///Details about each object.
        Data: BitcoinTransaction list
        ///True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        ///The URL where this list can be accessed.
        Url: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
        member _.Object = "list"

        static member Create (data: BitcoinTransaction list, hasMore: bool, url: string) =
            {
                BitcoinReceiverTransactions.Data = data //required
                BitcoinReceiverTransactions.HasMore = hasMore //required
                BitcoinReceiverTransactions.Url = url //required
            }

    and BitcoinTransaction = {
        ///The amount of `currency` that the transaction was converted to in real-time.
        Amount: int
        ///The amount of bitcoin contained in the transaction.
        BitcoinAmount: int
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO code for the currency](https://stripe.com/docs/currencies) to which this transaction was converted.
        Currency: string
        ///Unique identifier for the object.
        Id: string
        ///The receiver to which this transaction was sent.
        Receiver: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "bitcoin_transaction"

        static member Create (amount: int, bitcoinAmount: int, created: DateTime, currency: string, id: string, receiver: string) =
            {
                BitcoinTransaction.Amount = amount //required
                BitcoinTransaction.BitcoinAmount = bitcoinAmount //required
                BitcoinTransaction.Created = created //required
                BitcoinTransaction.Currency = currency //required
                BitcoinTransaction.Id = id //required
                BitcoinTransaction.Receiver = receiver //required
            }

    ///This is an object representing a capability for a Stripe account.
    ///Related guide: [Account capabilities](https://stripe.com/docs/connect/account-capabilities).
    and Capability = {
        ///The account for which the capability enables functionality.
        [<JsonField(Transform=typeof<AnyOfTransform<CapabilityAccount'AnyOf>>)>]Account: CapabilityAccount'AnyOf
        ///The identifier for the capability.
        Id: string
        ///Whether the capability has been requested.
        Requested: bool
        ///Time at which the capability was requested. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]RequestedAt: DateTime option
        Requirements: AccountCapabilityRequirements option
        ///The status of the capability. Can be `active`, `inactive`, `pending`, or `unrequested`.
        Status: CapabilityStatus
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "capability"

        static member Create (account: CapabilityAccount'AnyOf, id: string, requested: bool, requestedAt: DateTime option, status: CapabilityStatus, ?requirements: AccountCapabilityRequirements) =
            {
                Capability.Account = account //required
                Capability.Id = id //required
                Capability.Requested = requested //required
                Capability.RequestedAt = requestedAt //required
                Capability.Status = status //required
                Capability.Requirements = requirements
            }

    and CapabilityAccount'AnyOf =
        | String of string
        | Account of Account

    and CapabilityStatus =
        | Active
        | Disabled
        | Inactive
        | Pending
        | Unrequested

    ///You can store multiple cards on a customer in order to charge the customer
    ///later. You can also store multiple debit cards on a recipient in order to
    ///transfer to those cards later.
    ///Related guide: [Card Payments with Sources](https://stripe.com/docs/sources/cards).
    and Card = {
        ///The account this card belongs to. This attribute will not be in the card object if the card belongs to a customer or recipient instead.
        [<JsonField(Transform=typeof<AnyOfTransform<CardAccount'AnyOf>>)>]Account: CardAccount'AnyOf option
        ///City/District/Suburb/Town/Village.
        AddressCity: string option
        ///Billing address country, if provided when creating card.
        AddressCountry: string option
        ///Address line 1 (Street address/PO Box/Company name).
        [<JsonField(Name="address_line1")>]AddressLine1: string option
        ///If `address_line1` was provided, results of the check: `pass`, `fail`, `unavailable`, or `unchecked`.
        [<JsonField(Name="address_line1_check")>]AddressLine1Check: CardAddressLine1Check option
        ///Address line 2 (Apartment/Suite/Unit/Building).
        [<JsonField(Name="address_line2")>]AddressLine2: string option
        ///State/County/Province/Region.
        AddressState: string option
        ///ZIP or postal code.
        AddressZip: string option
        ///If `address_zip` was provided, results of the check: `pass`, `fail`, `unavailable`, or `unchecked`.
        AddressZipCheck: CardAddressZipCheck option
        ///A set of available payout methods for this card. Only values from this set should be passed as the `method` when creating a payout.
        AvailablePayoutMethods: CardAvailablePayoutMethods list option
        ///Card brand. Can be `American Express`, `Diners Club`, `Discover`, `JCB`, `MasterCard`, `UnionPay`, `Visa`, or `Unknown`.
        Brand: CardBrand
        ///Two-letter ISO code representing the country of the card. You could use this attribute to get a sense of the international breakdown of cards you've collected.
        Country: string option
        ///Three-letter [ISO code for currency](https://stripe.com/docs/payouts). Only applicable on accounts (not customers or recipients). The card can be used as a transfer destination for funds in this currency.
        Currency: string option
        ///The customer that this card belongs to. This attribute will not be in the card object if the card belongs to an account or recipient instead.
        [<JsonField(Transform=typeof<AnyOfTransform<CardCustomer'AnyOf>>)>]Customer: CardCustomer'AnyOf option
        ///If a CVC was provided, results of the check: `pass`, `fail`, `unavailable`, or `unchecked`. A result of unchecked indicates that CVC was provided but hasn't been checked yet. Checks are typically performed when attaching a card to a Customer object, or when creating a charge. For more details, see [Check if a card is valid without a charge](https://support.stripe.com/questions/check-if-a-card-is-valid-without-a-charge).
        CvcCheck: CardCvcCheck option
        ///Whether this card is the default external account for its currency.
        DefaultForCurrency: bool option
        ///A high-level description of the type of cards issued in this range. (For internal use only and not typically available in standard API requests.)
        Description: string option
        ///(For tokenized numbers only.) The last four digits of the device account number.
        [<JsonField(Name="dynamic_last4")>]DynamicLast4: string option
        ///Two-digit number representing the card's expiration month.
        ExpMonth: int
        ///Four-digit number representing the card's expiration year.
        ExpYear: int
        ///Uniquely identifies this particular card number. You can use this attribute to check whether two customers who’ve signed up with you are using the same card number, for example. For payment methods that tokenize card information (Apple Pay, Google Pay), the tokenized number might be provided instead of the underlying card number.
        Fingerprint: string option
        ///Card funding type. Can be `credit`, `debit`, `prepaid`, or `unknown`.
        Funding: CardFunding
        ///Unique identifier for the object.
        Id: string
        ///Issuer identification number of the card. (For internal use only and not typically available in standard API requests.)
        Iin: string option
        ///The name of the card's issuing bank. (For internal use only and not typically available in standard API requests.)
        Issuer: string option
        ///The last four digits of the card.
        [<JsonField(Name="last4")>]Last4: string
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        ///Cardholder name.
        Name: string option
        ///The recipient that this card belongs to. This attribute will not be in the card object if the card belongs to a customer or account instead.
        [<JsonField(Transform=typeof<AnyOfTransform<CardRecipient'AnyOf>>)>]Recipient: CardRecipient'AnyOf option
        ///If the card number is tokenized, this is the method that was used. Can be `android_pay` (includes Google Pay), `apple_pay`, `masterpass`, `visa_checkout`, or null.
        TokenizationMethod: CardTokenizationMethod option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "card"

        static member Create (addressCity: string option, addressCountry: string option, addressLine1: string option, addressLine1Check: CardAddressLine1Check option, addressLine2: string option, addressState: string option, addressZip: string option, addressZipCheck: CardAddressZipCheck option, brand: CardBrand, country: string option, cvcCheck: CardCvcCheck option, dynamicLast4: string option, expMonth: int, expYear: int, funding: CardFunding, id: string, last4: string, metadata: Map<string, string> option, name: string option, tokenizationMethod: CardTokenizationMethod option, ?account: CardAccount'AnyOf option, ?availablePayoutMethods: CardAvailablePayoutMethods list option, ?currency: string option, ?customer: CardCustomer'AnyOf option, ?defaultForCurrency: bool option, ?description: string, ?fingerprint: string option, ?iin: string, ?issuer: string, ?recipient: CardRecipient'AnyOf option) =
            {
                Card.AddressCity = addressCity //required
                Card.AddressCountry = addressCountry //required
                Card.AddressLine1 = addressLine1 //required
                Card.AddressLine1Check = addressLine1Check //required
                Card.AddressLine2 = addressLine2 //required
                Card.AddressState = addressState //required
                Card.AddressZip = addressZip //required
                Card.AddressZipCheck = addressZipCheck //required
                Card.Brand = brand //required
                Card.Country = country //required
                Card.CvcCheck = cvcCheck //required
                Card.DynamicLast4 = dynamicLast4 //required
                Card.ExpMonth = expMonth //required
                Card.ExpYear = expYear //required
                Card.Funding = funding //required
                Card.Id = id //required
                Card.Last4 = last4 //required
                Card.Metadata = metadata //required
                Card.Name = name //required
                Card.TokenizationMethod = tokenizationMethod //required
                Card.Account = account |> Option.flatten
                Card.AvailablePayoutMethods = availablePayoutMethods |> Option.flatten
                Card.Currency = currency |> Option.flatten
                Card.Customer = customer |> Option.flatten
                Card.DefaultForCurrency = defaultForCurrency |> Option.flatten
                Card.Description = description
                Card.Fingerprint = fingerprint |> Option.flatten
                Card.Iin = iin
                Card.Issuer = issuer
                Card.Recipient = recipient |> Option.flatten
            }

    and CardAccount'AnyOf =
        | String of string
        | Account of Account

    and CardAddressLine1Check =
        | Pass
        | Fail
        | Unavailable
        | Unchecked

    and CardAddressZipCheck =
        | Pass
        | Fail
        | Unavailable
        | Unchecked

    and CardBrand =
        | [<JsonUnionCase("American Express")>] AmericanExpress
        | [<JsonUnionCase("Diners Club")>] DinersClub
        | [<JsonUnionCase("Discover")>] Discover
        | [<JsonUnionCase("JCB")>] JCB
        | [<JsonUnionCase("MasterCard")>] MasterCard
        | [<JsonUnionCase("UnionPay")>] UnionPay
        | [<JsonUnionCase("Visa")>] Visa
        | [<JsonUnionCase("Unknown")>] Unknown

    and CardCustomer'AnyOf =
        | String of string
        | Customer of Customer
        | DeletedCustomer of DeletedCustomer

    and CardCvcCheck =
        | Pass
        | Fail
        | Unavailable
        | Unchecked

    and CardFunding =
        | Credit
        | Debit
        | Prepaid
        | Unknown

    and CardRecipient'AnyOf =
        | String of string
        | Recipient of Recipient

    and CardTokenizationMethod =
        | AndroidPay
        | ApplePay
        | Masterpass
        | VisaCheckout

    and CardAvailablePayoutMethods =
        | Instant
        | Standard

    and CardMandatePaymentMethodDetails = {
        CardMandatePaymentMethodDetails: string option
    }
    with

        static member Create (?cardMandatePaymentMethodDetails: string option) =
            {
                CardMandatePaymentMethodDetails.CardMandatePaymentMethodDetails = cardMandatePaymentMethodDetails |> Option.flatten
            }

    ///To charge a credit or a debit card, you create a `Charge` object. You can
    ///retrieve and refund individual charges as well as list all charges. Charges
    ///are identified by a unique, random ID.
    ///Related guide: [Accept a payment with the Charges API](https://stripe.com/docs/payments/accept-a-payment-charges).
    and Charge = {
        AlternateStatementDescriptors: AlternateStatementDescriptors option
        ///Amount intended to be collected by this payment. A positive integer representing how much to charge in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal) (e.g., 100 cents to charge $1.00 or 100 to charge ¥100, a zero-decimal currency). The minimum amount is $0.50 US or [equivalent in charge currency](https://stripe.com/docs/currencies#minimum-and-maximum-charge-amounts). The amount value supports up to eight digits (e.g., a value of 99999999 for a USD charge of $999,999.99).
        Amount: int
        ///Amount in %s captured (can be less than the amount attribute on the charge if a partial capture was made).
        AmountCaptured: int
        ///Amount in %s refunded (can be less than the amount attribute on the charge if a partial refund was issued).
        AmountRefunded: int
        ///ID of the Connect application that created the charge.
        [<JsonField(Transform=typeof<AnyOfTransform<ChargeApplication'AnyOf>>)>]Application: ChargeApplication'AnyOf option
        ///The application fee (if any) for the charge. [See the Connect documentation](https://stripe.com/docs/connect/direct-charges#collecting-fees) for details.
        [<JsonField(Transform=typeof<AnyOfTransform<ChargeApplicationFee'AnyOf>>)>]ApplicationFee: ChargeApplicationFee'AnyOf option
        ///The amount of the application fee (if any) requested for the charge. [See the Connect documentation](https://stripe.com/docs/connect/direct-charges#collecting-fees) for details.
        ApplicationFeeAmount: int option
        ///Authorization code on the charge.
        AuthorizationCode: string option
        ///ID of the balance transaction that describes the impact of this charge on your account balance (not including refunds or disputes).
        [<JsonField(Transform=typeof<AnyOfTransform<ChargeBalanceTransaction'AnyOf>>)>]BalanceTransaction: ChargeBalanceTransaction'AnyOf option
        BillingDetails: BillingDetails
        ///The full statement descriptor that is passed to card networks, and that is displayed on your customers' credit card and bank statements. Allows you to see what the statement descriptor looks like after the static and dynamic portions are combined.
        CalculatedStatementDescriptor: string option
        ///If the charge was created without capturing, this Boolean represents whether it is still uncaptured or has since been captured.
        Captured: bool
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///ID of the customer this charge is for if one exists.
        [<JsonField(Transform=typeof<AnyOfTransform<ChargeCustomer'AnyOf>>)>]Customer: ChargeCustomer'AnyOf option
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        ///ID of an existing, connected Stripe account to transfer funds to if `transfer_data` was specified in the charge request.
        [<JsonField(Transform=typeof<AnyOfTransform<ChargeDestination'AnyOf>>)>]Destination: ChargeDestination'AnyOf option
        ///Details about the dispute if the charge has been disputed.
        [<JsonField(Transform=typeof<AnyOfTransform<ChargeDispute'AnyOf>>)>]Dispute: ChargeDispute'AnyOf option
        ///Whether the charge has been disputed.
        Disputed: bool
        ///Error code explaining reason for charge failure if available (see [the errors section](https://stripe.com/docs/api#errors) for a list of codes).
        FailureCode: string option
        ///Message to user further explaining reason for charge failure if available.
        FailureMessage: string option
        ///Information on fraud assessments for the charge.
        FraudDetails: ChargeFraudDetails option
        ///Unique identifier for the object.
        Id: string
        ///ID of the invoice this charge is for if one exists.
        [<JsonField(Transform=typeof<AnyOfTransform<ChargeInvoice'AnyOf>>)>]Invoice: ChargeInvoice'AnyOf option
        [<JsonField(Name="level3")>]Level3: Level3 option
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        ///The account (if any) the charge was made on behalf of without triggering an automatic transfer. See the [Connect documentation](https://stripe.com/docs/connect/charges-transfers) for details.
        [<JsonField(Transform=typeof<AnyOfTransform<ChargeOnBehalfOf'AnyOf>>)>]OnBehalfOf: ChargeOnBehalfOf'AnyOf option
        ///ID of the order this charge is for if one exists.
        [<JsonField(Transform=typeof<AnyOfTransform<ChargeOrder'AnyOf>>)>]Order: ChargeOrder'AnyOf option
        ///Details about whether the payment was accepted, and why. See [understanding declines](https://stripe.com/docs/declines) for details.
        Outcome: ChargeOutcome option
        ///`true` if the charge succeeded, or was successfully authorized for later capture.
        Paid: bool
        ///ID of the PaymentIntent associated with this charge, if one exists.
        [<JsonField(Transform=typeof<AnyOfTransform<ChargePaymentIntent'AnyOf>>)>]PaymentIntent: ChargePaymentIntent'AnyOf option
        ///ID of the payment method used in this charge.
        PaymentMethod: string option
        ///Details about the payment method at the time of the transaction.
        PaymentMethodDetails: PaymentMethodDetails option
        ///This is the email address that the receipt for this charge was sent to.
        ReceiptEmail: string option
        ///This is the transaction number that appears on email receipts sent for this charge. This attribute will be `null` until a receipt has been sent.
        ReceiptNumber: string option
        ///This is the URL to view the receipt for this charge. The receipt is kept up-to-date to the latest state of the charge, including any refunds. If the charge is for an Invoice, the receipt will be stylized as an Invoice receipt.
        ReceiptUrl: string option
        ///Whether the charge has been fully refunded. If the charge is only partially refunded, this attribute will still be false.
        Refunded: bool
        ///A list of refunds that have been applied to the charge.
        Refunds: ChargeRefunds
        ///ID of the review associated with this charge if one exists.
        [<JsonField(Transform=typeof<AnyOfTransform<ChargeReview'AnyOf>>)>]Review: ChargeReview'AnyOf option
        ///Shipping information for the charge.
        Shipping: Shipping option
        ///This is a legacy field that will be removed in the future. It contains the Source, Card, or BankAccount object used for the charge. For details about the payment method used for this charge, refer to `payment_method` or `payment_method_details` instead.
        Source: PaymentSource option
        ///The transfer ID which created this charge. Only present if the charge came from another Stripe account. [See the Connect documentation](https://stripe.com/docs/connect/destination-charges) for details.
        [<JsonField(Transform=typeof<AnyOfTransform<ChargeSourceTransfer'AnyOf>>)>]SourceTransfer: ChargeSourceTransfer'AnyOf option
        ///For card charges, use `statement_descriptor_suffix` instead. Otherwise, you can use this value as the complete description of a charge on your customers’ statements. Must contain at least one letter, maximum 22 characters.
        StatementDescriptor: string option
        ///Provides information about the charge that customers see on their statements. Concatenated with the prefix (shortened descriptor) or statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 22 characters for the concatenated descriptor.
        StatementDescriptorSuffix: string option
        ///The status of the payment is either `succeeded`, `pending`, or `failed`.
        Status: ChargeStatus
        ///ID of the transfer to the `destination` account (only applicable if the charge was created using the `destination` parameter).
        [<JsonField(Transform=typeof<AnyOfTransform<ChargeTransfer'AnyOf>>)>]Transfer: ChargeTransfer'AnyOf option
        ///An optional dictionary including the account to automatically transfer to as part of a destination charge. [See the Connect documentation](https://stripe.com/docs/connect/destination-charges) for details.
        TransferData: ChargeTransferData option
        ///A string that identifies this transaction as part of a group. See the [Connect documentation](https://stripe.com/docs/connect/charges-transfers#transfer-options) for details.
        TransferGroup: string option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "charge"

        static member Create (amount: int, amountCaptured: int, amountRefunded: int, application: ChargeApplication'AnyOf option, applicationFee: ChargeApplicationFee'AnyOf option, applicationFeeAmount: int option, balanceTransaction: ChargeBalanceTransaction'AnyOf option, billingDetails: BillingDetails, calculatedStatementDescriptor: string option, captured: bool, created: DateTime, currency: string, customer: ChargeCustomer'AnyOf option, description: string option, destination: ChargeDestination'AnyOf option, dispute: ChargeDispute'AnyOf option, disputed: bool, failureCode: string option, failureMessage: string option, fraudDetails: ChargeFraudDetails option, id: string, invoice: ChargeInvoice'AnyOf option, livemode: bool, metadata: Map<string, string>, onBehalfOf: ChargeOnBehalfOf'AnyOf option, order: ChargeOrder'AnyOf option, outcome: ChargeOutcome option, paid: bool, paymentIntent: ChargePaymentIntent'AnyOf option, paymentMethod: string option, paymentMethodDetails: PaymentMethodDetails option, receiptEmail: string option, receiptNumber: string option, receiptUrl: string option, refunded: bool, refunds: ChargeRefunds, review: ChargeReview'AnyOf option, shipping: Shipping option, source: PaymentSource option, sourceTransfer: ChargeSourceTransfer'AnyOf option, statementDescriptor: string option, statementDescriptorSuffix: string option, status: ChargeStatus, transferData: ChargeTransferData option, transferGroup: string option, ?alternateStatementDescriptors: AlternateStatementDescriptors, ?authorizationCode: string, ?level3: Level3, ?transfer: ChargeTransfer'AnyOf) =
            {
                Charge.Amount = amount //required
                Charge.AmountCaptured = amountCaptured //required
                Charge.AmountRefunded = amountRefunded //required
                Charge.Application = application //required
                Charge.ApplicationFee = applicationFee //required
                Charge.ApplicationFeeAmount = applicationFeeAmount //required
                Charge.BalanceTransaction = balanceTransaction //required
                Charge.BillingDetails = billingDetails //required
                Charge.CalculatedStatementDescriptor = calculatedStatementDescriptor //required
                Charge.Captured = captured //required
                Charge.Created = created //required
                Charge.Currency = currency //required
                Charge.Customer = customer //required
                Charge.Description = description //required
                Charge.Destination = destination //required
                Charge.Dispute = dispute //required
                Charge.Disputed = disputed //required
                Charge.FailureCode = failureCode //required
                Charge.FailureMessage = failureMessage //required
                Charge.FraudDetails = fraudDetails //required
                Charge.Id = id //required
                Charge.Invoice = invoice //required
                Charge.Livemode = livemode //required
                Charge.Metadata = metadata //required
                Charge.OnBehalfOf = onBehalfOf //required
                Charge.Order = order //required
                Charge.Outcome = outcome //required
                Charge.Paid = paid //required
                Charge.PaymentIntent = paymentIntent //required
                Charge.PaymentMethod = paymentMethod //required
                Charge.PaymentMethodDetails = paymentMethodDetails //required
                Charge.ReceiptEmail = receiptEmail //required
                Charge.ReceiptNumber = receiptNumber //required
                Charge.ReceiptUrl = receiptUrl //required
                Charge.Refunded = refunded //required
                Charge.Refunds = refunds //required
                Charge.Review = review //required
                Charge.Shipping = shipping //required
                Charge.Source = source //required
                Charge.SourceTransfer = sourceTransfer //required
                Charge.StatementDescriptor = statementDescriptor //required
                Charge.StatementDescriptorSuffix = statementDescriptorSuffix //required
                Charge.Status = status //required
                Charge.TransferData = transferData //required
                Charge.TransferGroup = transferGroup //required
                Charge.AlternateStatementDescriptors = alternateStatementDescriptors
                Charge.AuthorizationCode = authorizationCode
                Charge.Level3 = level3
                Charge.Transfer = transfer
            }

    and ChargeApplication'AnyOf =
        | String of string
        | Application of Application

    and ChargeApplicationFee'AnyOf =
        | String of string
        | ApplicationFee of ApplicationFee

    and ChargeBalanceTransaction'AnyOf =
        | String of string
        | BalanceTransaction of BalanceTransaction

    and ChargeCustomer'AnyOf =
        | String of string
        | Customer of Customer
        | DeletedCustomer of DeletedCustomer

    and ChargeDestination'AnyOf =
        | String of string
        | Account of Account

    and ChargeDispute'AnyOf =
        | String of string
        | Dispute of Dispute

    and ChargeInvoice'AnyOf =
        | String of string
        | Invoice of Invoice

    and ChargeOnBehalfOf'AnyOf =
        | String of string
        | Account of Account

    and ChargeOrder'AnyOf =
        | String of string
        | Order of Order

    and ChargePaymentIntent'AnyOf =
        | String of string
        | PaymentIntent of PaymentIntent

    and ChargeReview'AnyOf =
        | String of string
        | Review of Review

    and ChargeSourceTransfer'AnyOf =
        | String of string
        | Transfer of Transfer

    and ChargeStatus =
        | Succeeded
        | Pending
        | Failed

    and ChargeTransfer'AnyOf =
        | String of string
        | Transfer of Transfer

    ///A list of refunds that have been applied to the charge.
    and ChargeRefunds = {
        ///Details about each object.
        Data: Refund list
        ///True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        ///The URL where this list can be accessed.
        Url: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
        member _.Object = "list"

        static member Create (data: Refund list, hasMore: bool, url: string) =
            {
                ChargeRefunds.Data = data //required
                ChargeRefunds.HasMore = hasMore //required
                ChargeRefunds.Url = url //required
            }

    and ChargeFraudDetails = {
        ///Assessments from Stripe. If set, the value is `fraudulent`.
        StripeReport: string option
        ///Assessments reported by you. If set, possible values of are `safe` and `fraudulent`.
        UserReport: ChargeFraudDetailsUserReport option
    }
    with

        static member Create (?stripeReport: string, ?userReport: ChargeFraudDetailsUserReport) =
            {
                ChargeFraudDetails.StripeReport = stripeReport
                ChargeFraudDetails.UserReport = userReport
            }

    and ChargeFraudDetailsUserReport =
        | Safe
        | Fraudulent

    and ChargeOutcome = {
        ///Possible values are `approved_by_network`, `declined_by_network`, `not_sent_to_network`, and `reversed_after_approval`. The value `reversed_after_approval` indicates the payment was [blocked by Stripe](https://stripe.com/docs/declines#blocked-payments) after bank authorization, and may temporarily appear as "pending" on a cardholder's statement.
        NetworkStatus: ChargeOutcomeNetworkStatus option
        ///An enumerated value providing a more detailed explanation of the outcome's `type`. Charges blocked by Radar's default block rule have the value `highest_risk_level`. Charges placed in review by Radar's default review rule have the value `elevated_risk_level`. Charges authorized, blocked, or placed in review by custom rules have the value `rule`. See [understanding declines](https://stripe.com/docs/declines) for more details.
        Reason: string option
        ///Stripe Radar's evaluation of the riskiness of the payment. Possible values for evaluated payments are `normal`, `elevated`, `highest`. For non-card payments, and card-based payments predating the public assignment of risk levels, this field will have the value `not_assessed`. In the event of an error in the evaluation, this field will have the value `unknown`. This field is only available with Radar.
        RiskLevel: string option
        ///Stripe Radar's evaluation of the riskiness of the payment. Possible values for evaluated payments are between 0 and 100. For non-card payments, card-based payments predating the public assignment of risk scores, or in the event of an error during evaluation, this field will not be present. This field is only available with Radar for Fraud Teams.
        RiskScore: int option
        ///The ID of the Radar rule that matched the payment, if applicable.
        [<JsonField(Transform=typeof<AnyOfTransform<ChargeOutcomeRule'AnyOf>>)>]Rule: ChargeOutcomeRule'AnyOf option
        ///A human-readable description of the outcome type and reason, designed for you (the recipient of the payment), not your customer.
        SellerMessage: string option
        ///Possible values are `authorized`, `manual_review`, `issuer_declined`, `blocked`, and `invalid`. See [understanding declines](https://stripe.com/docs/declines) and [Radar reviews](https://stripe.com/docs/radar/reviews) for details.
        Type: ChargeOutcomeType
    }
    with

        static member Create (networkStatus: ChargeOutcomeNetworkStatus option, reason: string option, sellerMessage: string option, ``type``: ChargeOutcomeType, ?riskLevel: string, ?riskScore: int, ?rule: ChargeOutcomeRule'AnyOf) =
            {
                ChargeOutcome.NetworkStatus = networkStatus //required
                ChargeOutcome.Reason = reason //required
                ChargeOutcome.SellerMessage = sellerMessage //required
                ChargeOutcome.Type = ``type`` //required
                ChargeOutcome.RiskLevel = riskLevel
                ChargeOutcome.RiskScore = riskScore
                ChargeOutcome.Rule = rule
            }

    and ChargeOutcomeNetworkStatus =
        | ApprovedByNetwork
        | DeclinedByNetwork
        | NotSentToNetwork
        | ReversedAfterApproval

    and ChargeOutcomeRule'AnyOf =
        | String of string
        | Rule of Rule

    and ChargeOutcomeType =
        | Authorized
        | ManualReview
        | IssuerDeclined
        | Blocked
        | Invalid

    and ChargeTransferData = {
        ///The amount transferred to the destination account, if specified. By default, the entire charge amount is transferred to the destination account.
        Amount: int option
        ///ID of an existing, connected Stripe account to transfer funds to if `transfer_data` was specified in the charge request.
        [<JsonField(Transform=typeof<AnyOfTransform<ChargeTransferDataDestination'AnyOf>>)>]Destination: ChargeTransferDataDestination'AnyOf
    }
    with

        static member Create (amount: int option, destination: ChargeTransferDataDestination'AnyOf) =
            {
                ChargeTransferData.Amount = amount //required
                ChargeTransferData.Destination = destination //required
            }

    and ChargeTransferDataDestination'AnyOf =
        | String of string
        | Account of Account

    ///A Checkout Session represents your customer's session as they pay for
    ///one-time purchases or subscriptions through [Checkout](https://stripe.com/docs/payments/checkout).
    ///We recommend creating a new Session each time your customer attempts to pay.
    ///Once payment is successful, the Checkout Session will contain a reference
    ///to the [Customer](https://stripe.com/docs/api/customers), and either the successful
    ///[PaymentIntent](https://stripe.com/docs/api/payment_intents) or an active
    ///[Subscription](https://stripe.com/docs/api/subscriptions).
    ///You can create a Checkout Session on your server and pass its ID to the
    ///client to begin Checkout.
    ///Related guide: [Checkout Server Quickstart](https://stripe.com/docs/payments/checkout/api).
    and CheckoutSession = {
        ///Enables user redeemable promotion codes.
        AllowPromotionCodes: bool option
        ///Total of all items before discounts or taxes are applied.
        AmountSubtotal: int option
        ///Total of all items after discounts and taxes are applied.
        AmountTotal: int option
        ///Describes whether Checkout should collect the customer's billing address.
        BillingAddressCollection: CheckoutSessionBillingAddressCollection option
        ///The URL the customer will be directed to if they decide to cancel payment and return to your website.
        CancelUrl: string
        ///A unique string to reference the Checkout Session. This can be a
    ///customer ID, a cart ID, or similar, and can be used to reconcile the
    ///session with your internal systems.
        ClientReferenceId: string option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string option
        ///The ID of the customer for this session.
    ///For Checkout Sessions in `payment` or `subscription` mode, Checkout
    ///will create a new customer object based on information provided
    ///during the session unless an existing customer was provided when
    ///the session was created.
        [<JsonField(Transform=typeof<AnyOfTransform<CheckoutSessionCustomer'AnyOf>>)>]Customer: CheckoutSessionCustomer'AnyOf option
        ///If provided, this value will be used when the Customer object is created.
    ///If not provided, customers will be asked to enter their email address.
    ///Use this parameter to prefill customer data if you already have an email
    ///on file. To access information about the customer once a session is
    ///complete, use the `customer` attribute.
        CustomerEmail: string option
        ///Unique identifier for the object. Used to pass to `redirectToCheckout`
    ///in Stripe.js.
        Id: string
        ///The line items purchased by the customer.
        LineItems: CheckoutSessionLineItems option
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///The IETF language tag of the locale Checkout is displayed in. If blank or `auto`, the browser's locale is used.
        Locale: CheckoutSessionLocale option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        ///The mode of the Checkout Session.
        Mode: CheckoutSessionMode
        ///The ID of the PaymentIntent for Checkout Sessions in `payment` mode.
        [<JsonField(Transform=typeof<AnyOfTransform<CheckoutSessionPaymentIntent'AnyOf>>)>]PaymentIntent: CheckoutSessionPaymentIntent'AnyOf option
        ///A list of the types of payment methods (e.g. card) this Checkout
    ///Session is allowed to accept.
        PaymentMethodTypes: string list
        ///The payment status of the Checkout Session, one of `paid`, `unpaid`, or `no_payment_required`.
    ///You can use this value to decide when to fulfill your customer's order.
        PaymentStatus: CheckoutSessionPaymentStatus
        ///The ID of the SetupIntent for Checkout Sessions in `setup` mode.
        [<JsonField(Transform=typeof<AnyOfTransform<CheckoutSessionSetupIntent'AnyOf>>)>]SetupIntent: CheckoutSessionSetupIntent'AnyOf option
        ///Shipping information for this Checkout Session.
        Shipping: Shipping option
        ///When set, provides configuration for Checkout to collect a shipping address from a customer.
        ShippingAddressCollection: PaymentPagesPaymentPageResourcesShippingAddressCollection option
        ///Describes the type of transaction being performed by Checkout in order to customize
    ///relevant text on the page, such as the submit button. `submit_type` can only be
    ///specified on Checkout Sessions in `payment` mode, but not Checkout Sessions
    ///in `subscription` or `setup` mode.
        SubmitType: CheckoutSessionSubmitType option
        ///The ID of the subscription for Checkout Sessions in `subscription` mode.
        [<JsonField(Transform=typeof<AnyOfTransform<CheckoutSessionSubscription'AnyOf>>)>]Subscription: CheckoutSessionSubscription'AnyOf option
        ///The URL the customer will be directed to after the payment or
    ///subscription creation is successful.
        SuccessUrl: string
        ///Tax and discount details for the computed total amount.
        TotalDetails: PaymentPagesCheckoutSessionTotalDetails option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "checkout.session"

        static member Create (allowPromotionCodes: bool option, amountSubtotal: int option, amountTotal: int option, billingAddressCollection: CheckoutSessionBillingAddressCollection option, cancelUrl: string, clientReferenceId: string option, currency: string option, customer: CheckoutSessionCustomer'AnyOf option, customerEmail: string option, id: string, livemode: bool, locale: CheckoutSessionLocale option, metadata: Map<string, string> option, mode: CheckoutSessionMode, paymentIntent: CheckoutSessionPaymentIntent'AnyOf option, paymentMethodTypes: string list, paymentStatus: CheckoutSessionPaymentStatus, setupIntent: CheckoutSessionSetupIntent'AnyOf option, shipping: Shipping option, shippingAddressCollection: PaymentPagesPaymentPageResourcesShippingAddressCollection option, submitType: CheckoutSessionSubmitType option, subscription: CheckoutSessionSubscription'AnyOf option, successUrl: string, totalDetails: PaymentPagesCheckoutSessionTotalDetails option, ?lineItems: CheckoutSessionLineItems) =
            {
                CheckoutSession.AllowPromotionCodes = allowPromotionCodes //required
                CheckoutSession.AmountSubtotal = amountSubtotal //required
                CheckoutSession.AmountTotal = amountTotal //required
                CheckoutSession.BillingAddressCollection = billingAddressCollection //required
                CheckoutSession.CancelUrl = cancelUrl //required
                CheckoutSession.ClientReferenceId = clientReferenceId //required
                CheckoutSession.Currency = currency //required
                CheckoutSession.Customer = customer //required
                CheckoutSession.CustomerEmail = customerEmail //required
                CheckoutSession.Id = id //required
                CheckoutSession.Livemode = livemode //required
                CheckoutSession.Locale = locale //required
                CheckoutSession.Metadata = metadata //required
                CheckoutSession.Mode = mode //required
                CheckoutSession.PaymentIntent = paymentIntent //required
                CheckoutSession.PaymentMethodTypes = paymentMethodTypes //required
                CheckoutSession.PaymentStatus = paymentStatus //required
                CheckoutSession.SetupIntent = setupIntent //required
                CheckoutSession.Shipping = shipping //required
                CheckoutSession.ShippingAddressCollection = shippingAddressCollection //required
                CheckoutSession.SubmitType = submitType //required
                CheckoutSession.Subscription = subscription //required
                CheckoutSession.SuccessUrl = successUrl //required
                CheckoutSession.TotalDetails = totalDetails //required
                CheckoutSession.LineItems = lineItems
            }

    and CheckoutSessionBillingAddressCollection =
        | Auto
        | Required

    and CheckoutSessionCustomer'AnyOf =
        | String of string
        | Customer of Customer
        | DeletedCustomer of DeletedCustomer

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

    and CheckoutSessionPaymentIntent'AnyOf =
        | String of string
        | PaymentIntent of PaymentIntent

    and CheckoutSessionPaymentStatus =
        | NoPaymentRequired
        | Paid
        | Unpaid

    and CheckoutSessionSetupIntent'AnyOf =
        | String of string
        | SetupIntent of SetupIntent

    and CheckoutSessionSubmitType =
        | Auto
        | Book
        | Donate
        | Pay

    and CheckoutSessionSubscription'AnyOf =
        | String of string
        | Subscription of Subscription

    ///The line items purchased by the customer.
    and CheckoutSessionLineItems = {
        ///Details about each object.
        Data: Item list
        ///True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        ///The URL where this list can be accessed.
        Url: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
        member _.Object = "list"

        static member Create (data: Item list, hasMore: bool, url: string) =
            {
                CheckoutSessionLineItems.Data = data //required
                CheckoutSessionLineItems.HasMore = hasMore //required
                CheckoutSessionLineItems.Url = url //required
            }

    and ConnectCollectionTransfer = {
        ///Amount transferred, in %s.
        Amount: int
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///ID of the account that funds are being collected for.
        [<JsonField(Transform=typeof<AnyOfTransform<ConnectCollectionTransferDestination'AnyOf>>)>]Destination: ConnectCollectionTransferDestination'AnyOf
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "connect_collection_transfer"

        static member Create (amount: int, currency: string, destination: ConnectCollectionTransferDestination'AnyOf, id: string, livemode: bool) =
            {
                ConnectCollectionTransfer.Amount = amount //required
                ConnectCollectionTransfer.Currency = currency //required
                ConnectCollectionTransfer.Destination = destination //required
                ConnectCollectionTransfer.Id = id //required
                ConnectCollectionTransfer.Livemode = livemode //required
            }

    and ConnectCollectionTransferDestination'AnyOf =
        | String of string
        | Account of Account

    ///Stripe needs to collect certain pieces of information about each account
    ///created. These requirements can differ depending on the account's country. The
    ///Country Specs API makes these rules available to your integration.
    ///You can also view the information from this API call as [an online
    ///guide](/docs/connect/required-verification-information).
    and CountrySpec = {
        ///The default currency for this country. This applies to both payment methods and bank accounts.
        DefaultCurrency: string
        ///Unique identifier for the object. Represented as the ISO country code for this country.
        Id: string
        ///Currencies that can be accepted in the specific country (for transfers).
        SupportedBankAccountCurrencies: Map<string, string list>
        ///Currencies that can be accepted in the specified country (for payments).
        SupportedPaymentCurrencies: string list
        ///Payment methods available in the specified country. You may need to enable some payment methods (e.g., [ACH](https://stripe.com/docs/ach)) on your account before they appear in this list. The `stripe` payment method refers to [charging through your platform](https://stripe.com/docs/connect/destination-charges).
        SupportedPaymentMethods: string list
        ///Countries that can accept transfers from the specified country.
        SupportedTransferCountries: string list
        VerificationFields: CountrySpecVerificationFields
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "country_spec"

        static member Create (defaultCurrency: string, id: string, supportedBankAccountCurrencies: Map<string, string list>, supportedPaymentCurrencies: string list, supportedPaymentMethods: string list, supportedTransferCountries: string list, verificationFields: CountrySpecVerificationFields) =
            {
                CountrySpec.DefaultCurrency = defaultCurrency //required
                CountrySpec.Id = id //required
                CountrySpec.SupportedBankAccountCurrencies = supportedBankAccountCurrencies //required
                CountrySpec.SupportedPaymentCurrencies = supportedPaymentCurrencies //required
                CountrySpec.SupportedPaymentMethods = supportedPaymentMethods //required
                CountrySpec.SupportedTransferCountries = supportedTransferCountries //required
                CountrySpec.VerificationFields = verificationFields //required
            }

    and CountrySpecVerificationFieldDetails = {
        ///Additional fields which are only required for some users.
        Additional: string list
        ///Fields which every account must eventually provide.
        Minimum: string list
    }
    with

        static member Create (additional: string list, minimum: string list) =
            {
                CountrySpecVerificationFieldDetails.Additional = additional //required
                CountrySpecVerificationFieldDetails.Minimum = minimum //required
            }

    and CountrySpecVerificationFields = {
        Company: CountrySpecVerificationFieldDetails
        Individual: CountrySpecVerificationFieldDetails
    }
    with

        static member Create (company: CountrySpecVerificationFieldDetails, individual: CountrySpecVerificationFieldDetails) =
            {
                CountrySpecVerificationFields.Company = company //required
                CountrySpecVerificationFields.Individual = individual //required
            }

    ///A coupon contains information about a percent-off or amount-off discount you
    ///might want to apply to a customer. Coupons may be applied to [invoices](https://stripe.com/docs/api#invoices) or
    ///[orders](https://stripe.com/docs/api#create_order-coupon). Coupons do not work with conventional one-off [charges](https://stripe.com/docs/api#create_charge).
    and Coupon = {
        ///Amount (in the `currency` specified) that will be taken off the subtotal of any invoices for this customer.
        AmountOff: int option
        AppliesTo: CouponAppliesTo option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///If `amount_off` has been set, the three-letter [ISO code for the currency](https://stripe.com/docs/currencies) of the amount to take off.
        Currency: string option
        ///One of `forever`, `once`, and `repeating`. Describes how long a customer who applies this coupon will get the discount.
        Duration: CouponDuration
        ///If `duration` is `repeating`, the number of months the coupon applies. Null if coupon `duration` is `forever` or `once`.
        DurationInMonths: int option
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Maximum number of times this coupon can be redeemed, in total, across all customers, before it is no longer valid.
        MaxRedemptions: int option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        ///Name of the coupon displayed to customers on for instance invoices or receipts.
        Name: string option
        ///Percent that will be taken off the subtotal of any invoices for this customer for the duration of the coupon. For example, a coupon with percent_off of 50 will make a %s100 invoice %s50 instead.
        PercentOff: decimal option
        ///Date after which the coupon can no longer be redeemed.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]RedeemBy: DateTime option
        ///Number of times this coupon has been applied to a customer.
        TimesRedeemed: int
        ///Taking account of the above properties, whether this coupon can still be applied to a customer.
        Valid: bool
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "coupon"

        static member Create (amountOff: int option, created: DateTime, currency: string option, duration: CouponDuration, durationInMonths: int option, id: string, livemode: bool, maxRedemptions: int option, metadata: Map<string, string> option, name: string option, percentOff: decimal option, redeemBy: DateTime option, timesRedeemed: int, valid: bool, ?appliesTo: CouponAppliesTo) =
            {
                Coupon.AmountOff = amountOff //required
                Coupon.Created = created //required
                Coupon.Currency = currency //required
                Coupon.Duration = duration //required
                Coupon.DurationInMonths = durationInMonths //required
                Coupon.Id = id //required
                Coupon.Livemode = livemode //required
                Coupon.MaxRedemptions = maxRedemptions //required
                Coupon.Metadata = metadata //required
                Coupon.Name = name //required
                Coupon.PercentOff = percentOff //required
                Coupon.RedeemBy = redeemBy //required
                Coupon.TimesRedeemed = timesRedeemed //required
                Coupon.Valid = valid //required
                Coupon.AppliesTo = appliesTo
            }

    and CouponDuration =
        | Forever
        | Once
        | Repeating

    and CouponAppliesTo = {
        ///A list of product IDs this coupon applies to
        Products: string list
    }
    with

        static member Create (products: string list) =
            {
                CouponAppliesTo.Products = products //required
            }

    ///Issue a credit note to adjust an invoice's amount after the invoice is finalized.
    ///Related guide: [Credit Notes](https://stripe.com/docs/billing/invoices/credit-notes).
    and CreditNote = {
        ///The integer amount in %s representing the total amount of the credit note, including tax.
        Amount: int
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///ID of the customer.
        [<JsonField(Transform=typeof<AnyOfTransform<CreditNoteCustomer'AnyOf>>)>]Customer: CreditNoteCustomer'AnyOf
        ///Customer balance transaction related to this credit note.
        [<JsonField(Transform=typeof<AnyOfTransform<CreditNoteCustomerBalanceTransaction'AnyOf>>)>]CustomerBalanceTransaction: CreditNoteCustomerBalanceTransaction'AnyOf option
        ///The integer amount in %s representing the total amount of discount that was credited.
        DiscountAmount: int
        ///The aggregate amounts calculated per discount for all line items.
        DiscountAmounts: DiscountsResourceDiscountAmount list
        ///Unique identifier for the object.
        Id: string
        ///ID of the invoice.
        [<JsonField(Transform=typeof<AnyOfTransform<CreditNoteInvoice'AnyOf>>)>]Invoice: CreditNoteInvoice'AnyOf
        ///Line items that make up the credit note
        Lines: CreditNoteLines
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Customer-facing text that appears on the credit note PDF.
        Memo: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        ///A unique number that identifies this particular credit note and appears on the PDF of the credit note and its associated invoice.
        Number: string
        ///Amount that was credited outside of Stripe.
        OutOfBandAmount: int option
        ///The link to download the PDF of the credit note.
        Pdf: string
        ///Reason for issuing this credit note, one of `duplicate`, `fraudulent`, `order_change`, or `product_unsatisfactory`
        Reason: CreditNoteReason option
        ///Refund related to this credit note.
        [<JsonField(Transform=typeof<AnyOfTransform<CreditNoteRefund'AnyOf>>)>]Refund: CreditNoteRefund'AnyOf option
        ///Status of this credit note, one of `issued` or `void`. Learn more about [voiding credit notes](https://stripe.com/docs/billing/invoices/credit-notes#voiding).
        Status: CreditNoteStatus
        ///The integer amount in %s representing the amount of the credit note, excluding tax and invoice level discounts.
        Subtotal: int
        ///The aggregate amounts calculated per tax rate for all line items.
        TaxAmounts: CreditNoteTaxAmount list
        ///The integer amount in %s representing the total amount of the credit note, including tax and all discount.
        Total: int
        ///Type of this credit note, one of `pre_payment` or `post_payment`. A `pre_payment` credit note means it was issued when the invoice was open. A `post_payment` credit note means it was issued when the invoice was paid.
        Type: CreditNoteType
        ///The time that the credit note was voided.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]VoidedAt: DateTime option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "credit_note"

        static member Create (amount: int, created: DateTime, currency: string, customer: CreditNoteCustomer'AnyOf, customerBalanceTransaction: CreditNoteCustomerBalanceTransaction'AnyOf option, discountAmount: int, discountAmounts: DiscountsResourceDiscountAmount list, id: string, invoice: CreditNoteInvoice'AnyOf, lines: CreditNoteLines, livemode: bool, memo: string option, metadata: Map<string, string> option, number: string, outOfBandAmount: int option, pdf: string, reason: CreditNoteReason option, refund: CreditNoteRefund'AnyOf option, status: CreditNoteStatus, subtotal: int, taxAmounts: CreditNoteTaxAmount list, total: int, ``type``: CreditNoteType, voidedAt: DateTime option) =
            {
                CreditNote.Amount = amount //required
                CreditNote.Created = created //required
                CreditNote.Currency = currency //required
                CreditNote.Customer = customer //required
                CreditNote.CustomerBalanceTransaction = customerBalanceTransaction //required
                CreditNote.DiscountAmount = discountAmount //required
                CreditNote.DiscountAmounts = discountAmounts //required
                CreditNote.Id = id //required
                CreditNote.Invoice = invoice //required
                CreditNote.Lines = lines //required
                CreditNote.Livemode = livemode //required
                CreditNote.Memo = memo //required
                CreditNote.Metadata = metadata //required
                CreditNote.Number = number //required
                CreditNote.OutOfBandAmount = outOfBandAmount //required
                CreditNote.Pdf = pdf //required
                CreditNote.Reason = reason //required
                CreditNote.Refund = refund //required
                CreditNote.Status = status //required
                CreditNote.Subtotal = subtotal //required
                CreditNote.TaxAmounts = taxAmounts //required
                CreditNote.Total = total //required
                CreditNote.Type = ``type`` //required
                CreditNote.VoidedAt = voidedAt //required
            }

    and CreditNoteCustomer'AnyOf =
        | String of string
        | Customer of Customer
        | DeletedCustomer of DeletedCustomer

    and CreditNoteCustomerBalanceTransaction'AnyOf =
        | String of string
        | CustomerBalanceTransaction of CustomerBalanceTransaction

    and CreditNoteInvoice'AnyOf =
        | String of string
        | Invoice of Invoice

    and CreditNoteReason =
        | Duplicate
        | Fraudulent
        | OrderChange
        | ProductUnsatisfactory

    and CreditNoteRefund'AnyOf =
        | String of string
        | Refund of Refund

    and CreditNoteStatus =
        | Issued
        | Void

    and CreditNoteType =
        | PostPayment
        | PrePayment

    ///Line items that make up the credit note
    and CreditNoteLines = {
        ///Details about each object.
        Data: CreditNoteLineItem list
        ///True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        ///The URL where this list can be accessed.
        Url: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
        member _.Object = "list"

        static member Create (data: CreditNoteLineItem list, hasMore: bool, url: string) =
            {
                CreditNoteLines.Data = data //required
                CreditNoteLines.HasMore = hasMore //required
                CreditNoteLines.Url = url //required
            }

    and CreditNoteLineItem = {
        ///The integer amount in %s representing the gross amount being credited for this line item, excluding (exclusive) tax and discounts.
        Amount: int
        ///Description of the item being credited.
        Description: string option
        ///The integer amount in %s representing the discount being credited for this line item.
        DiscountAmount: int
        ///The amount of discount calculated per discount for this line item
        DiscountAmounts: DiscountsResourceDiscountAmount list
        ///Unique identifier for the object.
        Id: string
        ///ID of the invoice line item being credited
        InvoiceLineItem: string option
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///The number of units of product being credited.
        Quantity: int option
        ///The amount of tax calculated per tax rate for this line item
        TaxAmounts: CreditNoteTaxAmount list
        ///The tax rates which apply to the line item.
        TaxRates: TaxRate list
        ///The type of the credit note line item, one of `invoice_line_item` or `custom_line_item`. When the type is `invoice_line_item` there is an additional `invoice_line_item` property on the resource the value of which is the id of the credited line item on the invoice.
        Type: CreditNoteLineItemType
        ///The cost of each unit of product being credited.
        UnitAmount: int option
        ///Same as `unit_amount`, but contains a decimal value with at most 12 decimal places.
        UnitAmountDecimal: string option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "credit_note_line_item"

        static member Create (amount: int, description: string option, discountAmount: int, discountAmounts: DiscountsResourceDiscountAmount list, id: string, livemode: bool, quantity: int option, taxAmounts: CreditNoteTaxAmount list, taxRates: TaxRate list, ``type``: CreditNoteLineItemType, unitAmount: int option, unitAmountDecimal: string option, ?invoiceLineItem: string) =
            {
                CreditNoteLineItem.Amount = amount //required
                CreditNoteLineItem.Description = description //required
                CreditNoteLineItem.DiscountAmount = discountAmount //required
                CreditNoteLineItem.DiscountAmounts = discountAmounts //required
                CreditNoteLineItem.Id = id //required
                CreditNoteLineItem.Livemode = livemode //required
                CreditNoteLineItem.Quantity = quantity //required
                CreditNoteLineItem.TaxAmounts = taxAmounts //required
                CreditNoteLineItem.TaxRates = taxRates //required
                CreditNoteLineItem.Type = ``type`` //required
                CreditNoteLineItem.UnitAmount = unitAmount //required
                CreditNoteLineItem.UnitAmountDecimal = unitAmountDecimal //required
                CreditNoteLineItem.InvoiceLineItem = invoiceLineItem
            }

    and CreditNoteLineItemType =
        | CustomLineItem
        | InvoiceLineItem

    and CreditNoteTaxAmount = {
        ///The amount, in %s, of the tax.
        Amount: int
        ///Whether this tax amount is inclusive or exclusive.
        Inclusive: bool
        ///The tax rate that was applied to get this tax amount.
        [<JsonField(Transform=typeof<AnyOfTransform<CreditNoteTaxAmountTaxRate'AnyOf>>)>]TaxRate: CreditNoteTaxAmountTaxRate'AnyOf
    }
    with

        static member Create (amount: int, inclusive: bool, taxRate: CreditNoteTaxAmountTaxRate'AnyOf) =
            {
                CreditNoteTaxAmount.Amount = amount //required
                CreditNoteTaxAmount.Inclusive = inclusive //required
                CreditNoteTaxAmount.TaxRate = taxRate //required
            }

    and CreditNoteTaxAmountTaxRate'AnyOf =
        | String of string
        | TaxRate of TaxRate

    ///`Customer` objects allow you to perform recurring charges, and to track
    ///multiple charges, that are associated with the same customer. The API allows
    ///you to create, delete, and update your customers. You can retrieve individual
    ///customers as well as a list of all your customers.
    ///Related guide: [Save a card during payment](https://stripe.com/docs/payments/save-during-payment).
    and Customer = {
        ///The customer's address.
        Address: Address option
        ///Current balance, if any, being stored on the customer. If negative, the customer has credit to apply to their next invoice. If positive, the customer has an amount owed that will be added to their next invoice. The balance does not refer to any unpaid invoices; it solely takes into account amounts that have yet to be successfully applied to any invoice. This balance is only taken into account as invoices are finalized.
        Balance: int option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO code for the currency](https://stripe.com/docs/currencies) the customer can be charged in for recurring billing purposes.
        Currency: string option
        ///ID of the default payment source for the customer.
    ///If you are using payment methods created via the PaymentMethods API, see the [invoice_settings.default_payment_method](https://stripe.com/docs/api/customers/object#customer_object-invoice_settings-default_payment_method) field instead.
        [<JsonField(Transform=typeof<AnyOfTransform<CustomerDefaultSource'AnyOf>>)>]DefaultSource: CustomerDefaultSource'AnyOf option
        ///When the customer's latest invoice is billed by charging automatically, `delinquent` is `true` if the invoice's latest charge failed. When the customer's latest invoice is billed by sending an invoice, `delinquent` is `true` if the invoice isn't paid by its due date.
    ///If an invoice is marked uncollectible by [dunning](https://stripe.com/docs/billing/automatic-collection), `delinquent` doesn't get reset to `false`.
        Delinquent: bool option
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        ///Describes the current discount active on the customer, if there is one.
        Discount: Discount option
        ///The customer's email address.
        Email: string option
        ///Unique identifier for the object.
        Id: string
        ///The prefix for the customer used to generate unique invoice numbers.
        InvoicePrefix: string option
        InvoiceSettings: InvoiceSettingCustomerSetting option
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        ///The customer's full name or business name.
        Name: string option
        ///The suffix of the customer's next invoice number, e.g., 0001.
        NextInvoiceSequence: int option
        ///The customer's phone number.
        Phone: string option
        ///The customer's preferred locales (languages), ordered by preference.
        PreferredLocales: string list option
        ///Mailing and shipping address for the customer. Appears on invoices emailed to this customer.
        Shipping: Shipping option
        ///The customer's payment sources, if any.
        Sources: CustomerSources option
        ///The customer's current subscriptions, if any.
        Subscriptions: CustomerSubscriptions option
        ///Describes the customer's tax exemption status. One of `none`, `exempt`, or `reverse`. When set to `reverse`, invoice and receipt PDFs include the text **"Reverse charge"**.
        TaxExempt: CustomerTaxExempt option
        ///The customer's tax IDs.
        TaxIds: CustomerTaxIds option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "customer"

        static member Create (created: DateTime, defaultSource: CustomerDefaultSource'AnyOf option, description: string option, email: string option, id: string, livemode: bool, shipping: Shipping option, ?address: Address option, ?balance: int, ?currency: string option, ?delinquent: bool option, ?discount: Discount option, ?invoicePrefix: string option, ?invoiceSettings: InvoiceSettingCustomerSetting, ?metadata: Map<string, string>, ?name: string option, ?nextInvoiceSequence: int, ?phone: string option, ?preferredLocales: string list option, ?sources: CustomerSources, ?subscriptions: CustomerSubscriptions, ?taxExempt: CustomerTaxExempt option, ?taxIds: CustomerTaxIds) =
            {
                Customer.Created = created //required
                Customer.DefaultSource = defaultSource //required
                Customer.Description = description //required
                Customer.Email = email //required
                Customer.Id = id //required
                Customer.Livemode = livemode //required
                Customer.Shipping = shipping //required
                Customer.Address = address |> Option.flatten
                Customer.Balance = balance
                Customer.Currency = currency |> Option.flatten
                Customer.Delinquent = delinquent |> Option.flatten
                Customer.Discount = discount |> Option.flatten
                Customer.InvoicePrefix = invoicePrefix |> Option.flatten
                Customer.InvoiceSettings = invoiceSettings
                Customer.Metadata = metadata
                Customer.Name = name |> Option.flatten
                Customer.NextInvoiceSequence = nextInvoiceSequence
                Customer.Phone = phone |> Option.flatten
                Customer.PreferredLocales = preferredLocales |> Option.flatten
                Customer.Sources = sources
                Customer.Subscriptions = subscriptions
                Customer.TaxExempt = taxExempt |> Option.flatten
                Customer.TaxIds = taxIds
            }

    and CustomerDefaultSource'AnyOf =
        | String of string
        | PaymentSource of PaymentSource

    and CustomerTaxExempt =
        | Exempt
        | None'
        | Reverse

    ///The customer's payment sources, if any.
    and CustomerSources = {
        ///Details about each object.
        Data: PaymentSource list
        ///True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        ///The URL where this list can be accessed.
        Url: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
        member _.Object = "list"

        static member Create (data: PaymentSource list, hasMore: bool, url: string) =
            {
                CustomerSources.Data = data //required
                CustomerSources.HasMore = hasMore //required
                CustomerSources.Url = url //required
            }

    ///The customer's current subscriptions, if any.
    and CustomerSubscriptions = {
        ///Details about each object.
        Data: Subscription list
        ///True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        ///The URL where this list can be accessed.
        Url: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
        member _.Object = "list"

        static member Create (data: Subscription list, hasMore: bool, url: string) =
            {
                CustomerSubscriptions.Data = data //required
                CustomerSubscriptions.HasMore = hasMore //required
                CustomerSubscriptions.Url = url //required
            }

    ///The customer's tax IDs.
    and CustomerTaxIds = {
        ///Details about each object.
        Data: TaxId list
        ///True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        ///The URL where this list can be accessed.
        Url: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
        member _.Object = "list"

        static member Create (data: TaxId list, hasMore: bool, url: string) =
            {
                CustomerTaxIds.Data = data //required
                CustomerTaxIds.HasMore = hasMore //required
                CustomerTaxIds.Url = url //required
            }

    and CustomerAcceptance = {
        ///The time at which the customer accepted the Mandate.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]AcceptedAt: DateTime option
        Offline: OfflineAcceptance option
        Online: OnlineAcceptance option
        ///The type of customer acceptance information included with the Mandate. One of `online` or `offline`.
        Type: CustomerAcceptanceType
    }
    with

        static member Create (acceptedAt: DateTime option, ``type``: CustomerAcceptanceType, ?offline: OfflineAcceptance, ?online: OnlineAcceptance) =
            {
                CustomerAcceptance.AcceptedAt = acceptedAt //required
                CustomerAcceptance.Type = ``type`` //required
                CustomerAcceptance.Offline = offline
                CustomerAcceptance.Online = online
            }

    and CustomerAcceptanceType =
        | Offline
        | Online

    ///Each customer has a [`balance`](https://stripe.com/docs/api/customers/object#customer_object-balance) value,
    ///which denotes a debit or credit that's automatically applied to their next invoice upon finalization.
    ///You may modify the value directly by using the [update customer API](https://stripe.com/docs/api/customers/update),
    ///or by creating a Customer Balance Transaction, which increments or decrements the customer's `balance` by the specified `amount`.
    ///Related guide: [Customer Balance](https://stripe.com/docs/billing/customer/balance) to learn more.
    and CustomerBalanceTransaction = {
        ///The amount of the transaction. A negative value is a credit for the customer's balance, and a positive value is a debit to the customer's `balance`.
        Amount: int
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///The ID of the credit note (if any) related to the transaction.
        [<JsonField(Transform=typeof<AnyOfTransform<CustomerBalanceTransactionCreditNote'AnyOf>>)>]CreditNote: CustomerBalanceTransactionCreditNote'AnyOf option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///The ID of the customer the transaction belongs to.
        [<JsonField(Transform=typeof<AnyOfTransform<CustomerBalanceTransactionCustomer'AnyOf>>)>]Customer: CustomerBalanceTransactionCustomer'AnyOf
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        ///The customer's `balance` after the transaction was applied. A negative value decreases the amount due on the customer's next invoice. A positive value increases the amount due on the customer's next invoice.
        EndingBalance: int
        ///Unique identifier for the object.
        Id: string
        ///The ID of the invoice (if any) related to the transaction.
        [<JsonField(Transform=typeof<AnyOfTransform<CustomerBalanceTransactionInvoice'AnyOf>>)>]Invoice: CustomerBalanceTransactionInvoice'AnyOf option
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        ///Transaction type: `adjustment`, `applied_to_invoice`, `credit_note`, `initial`, `invoice_too_large`, `invoice_too_small`, `unspent_receiver_credit`, or `unapplied_from_invoice`. See the [Customer Balance page](https://stripe.com/docs/billing/customer/balance#types) to learn more about transaction types.
        Type: CustomerBalanceTransactionType
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "customer_balance_transaction"

        static member Create (amount: int, created: DateTime, creditNote: CustomerBalanceTransactionCreditNote'AnyOf option, currency: string, customer: CustomerBalanceTransactionCustomer'AnyOf, description: string option, endingBalance: int, id: string, invoice: CustomerBalanceTransactionInvoice'AnyOf option, livemode: bool, metadata: Map<string, string> option, ``type``: CustomerBalanceTransactionType) =
            {
                CustomerBalanceTransaction.Amount = amount //required
                CustomerBalanceTransaction.Created = created //required
                CustomerBalanceTransaction.CreditNote = creditNote //required
                CustomerBalanceTransaction.Currency = currency //required
                CustomerBalanceTransaction.Customer = customer //required
                CustomerBalanceTransaction.Description = description //required
                CustomerBalanceTransaction.EndingBalance = endingBalance //required
                CustomerBalanceTransaction.Id = id //required
                CustomerBalanceTransaction.Invoice = invoice //required
                CustomerBalanceTransaction.Livemode = livemode //required
                CustomerBalanceTransaction.Metadata = metadata //required
                CustomerBalanceTransaction.Type = ``type`` //required
            }

    and CustomerBalanceTransactionCreditNote'AnyOf =
        | String of string
        | CreditNote of CreditNote

    and CustomerBalanceTransactionCustomer'AnyOf =
        | String of string
        | Customer of Customer

    and CustomerBalanceTransactionInvoice'AnyOf =
        | String of string
        | Invoice of Invoice

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

    and DeletedAccount = {
        ///Always true for a deleted object
        Deleted: bool
        ///Unique identifier for the object.
        Id: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "account"

        static member Create (deleted: bool, id: string) =
            {
                DeletedAccount.Deleted = deleted //required
                DeletedAccount.Id = id //required
            }

    and DeletedAlipayAccount = {
        ///Always true for a deleted object
        Deleted: bool
        ///Unique identifier for the object.
        Id: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "alipay_account"

        static member Create (deleted: bool, id: string) =
            {
                DeletedAlipayAccount.Deleted = deleted //required
                DeletedAlipayAccount.Id = id //required
            }

    and DeletedApplePayDomain = {
        ///Always true for a deleted object
        Deleted: bool
        ///Unique identifier for the object.
        Id: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "apple_pay_domain"

        static member Create (deleted: bool, id: string) =
            {
                DeletedApplePayDomain.Deleted = deleted //required
                DeletedApplePayDomain.Id = id //required
            }

    and DeletedBankAccount = {
        ///Three-letter [ISO code for the currency](https://stripe.com/docs/payouts) paid out to the bank account.
        Currency: string option
        ///Always true for a deleted object
        Deleted: bool
        ///Unique identifier for the object.
        Id: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "bank_account"

        static member Create (currency: string option, deleted: bool, id: string) =
            {
                DeletedBankAccount.Currency = currency //required
                DeletedBankAccount.Deleted = deleted //required
                DeletedBankAccount.Id = id //required
            }

    and DeletedBitcoinReceiver = {
        ///Always true for a deleted object
        Deleted: bool
        ///Unique identifier for the object.
        Id: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "bitcoin_receiver"

        static member Create (deleted: bool, id: string) =
            {
                DeletedBitcoinReceiver.Deleted = deleted //required
                DeletedBitcoinReceiver.Id = id //required
            }

    and DeletedCard = {
        ///Three-letter [ISO code for the currency](https://stripe.com/docs/payouts) paid out to the bank account.
        Currency: string option
        ///Always true for a deleted object
        Deleted: bool
        ///Unique identifier for the object.
        Id: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "card"

        static member Create (currency: string option, deleted: bool, id: string) =
            {
                DeletedCard.Currency = currency //required
                DeletedCard.Deleted = deleted //required
                DeletedCard.Id = id //required
            }

    and DeletedCoupon = {
        ///Always true for a deleted object
        Deleted: bool
        ///Unique identifier for the object.
        Id: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "coupon"

        static member Create (deleted: bool, id: string) =
            {
                DeletedCoupon.Deleted = deleted //required
                DeletedCoupon.Id = id //required
            }

    and DeletedCustomer = {
        ///Always true for a deleted object
        Deleted: bool
        ///Unique identifier for the object.
        Id: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "customer"

        static member Create (deleted: bool, id: string) =
            {
                DeletedCustomer.Deleted = deleted //required
                DeletedCustomer.Id = id //required
            }

    and DeletedDiscount = {
        ///The Checkout session that this coupon is applied to, if it is applied to a particular session in payment mode. Will not be present for subscription mode.
        CheckoutSession: string option
        Coupon: Coupon
        ///The ID of the customer associated with this discount.
        [<JsonField(Transform=typeof<AnyOfTransform<DeletedDiscountCustomer'AnyOf>>)>]Customer: DeletedDiscountCustomer'AnyOf option
        ///Always true for a deleted object
        Deleted: bool
        ///The ID of the discount object. Discounts cannot be fetched by ID. Use `expand[]=discounts` in API calls to expand discount IDs in an array.
        Id: string
        ///The invoice that the discount's coupon was applied to, if it was applied directly to a particular invoice.
        Invoice: string option
        ///The invoice item `id` (or invoice line item `id` for invoice line items of type='subscription') that the discount's coupon was applied to, if it was applied directly to a particular invoice item or invoice line item.
        InvoiceItem: string option
        ///The promotion code applied to create this discount.
        [<JsonField(Transform=typeof<AnyOfTransform<DeletedDiscountPromotionCode'AnyOf>>)>]PromotionCode: DeletedDiscountPromotionCode'AnyOf option
        ///Date that the coupon was applied.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Start: DateTime
        ///The subscription that this coupon is applied to, if it is applied to a particular subscription.
        Subscription: string option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "discount"

        static member Create (checkoutSession: string option, coupon: Coupon, customer: DeletedDiscountCustomer'AnyOf option, deleted: bool, id: string, invoice: string option, invoiceItem: string option, promotionCode: DeletedDiscountPromotionCode'AnyOf option, start: DateTime, subscription: string option) =
            {
                DeletedDiscount.CheckoutSession = checkoutSession //required
                DeletedDiscount.Coupon = coupon //required
                DeletedDiscount.Customer = customer //required
                DeletedDiscount.Deleted = deleted //required
                DeletedDiscount.Id = id //required
                DeletedDiscount.Invoice = invoice //required
                DeletedDiscount.InvoiceItem = invoiceItem //required
                DeletedDiscount.PromotionCode = promotionCode //required
                DeletedDiscount.Start = start //required
                DeletedDiscount.Subscription = subscription //required
            }

    and DeletedDiscountCustomer'AnyOf =
        | String of string
        | Customer of Customer
        | DeletedCustomer of DeletedCustomer

    and DeletedDiscountPromotionCode'AnyOf =
        | String of string
        | PromotionCode of PromotionCode

    and DeletedExternalAccount =
        | DeletedBankAccount of DeletedBankAccount
        | DeletedCard of DeletedCard

    and DeletedInvoice = {
        ///Always true for a deleted object
        Deleted: bool
        ///Unique identifier for the object.
        Id: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "invoice"

        static member Create (deleted: bool, id: string) =
            {
                DeletedInvoice.Deleted = deleted //required
                DeletedInvoice.Id = id //required
            }

    and DeletedInvoiceitem = {
        ///Always true for a deleted object
        Deleted: bool
        ///Unique identifier for the object.
        Id: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "invoiceitem"

        static member Create (deleted: bool, id: string) =
            {
                DeletedInvoiceitem.Deleted = deleted //required
                DeletedInvoiceitem.Id = id //required
            }

    and DeletedPaymentSource =
        | DeletedAlipayAccount of DeletedAlipayAccount
        | DeletedBankAccount of DeletedBankAccount
        | DeletedBitcoinReceiver of DeletedBitcoinReceiver
        | DeletedCard of DeletedCard

    and DeletedPerson = {
        ///Always true for a deleted object
        Deleted: bool
        ///Unique identifier for the object.
        Id: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "person"

        static member Create (deleted: bool, id: string) =
            {
                DeletedPerson.Deleted = deleted //required
                DeletedPerson.Id = id //required
            }

    and DeletedPlan = {
        ///Always true for a deleted object
        Deleted: bool
        ///Unique identifier for the object.
        Id: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "plan"

        static member Create (deleted: bool, id: string) =
            {
                DeletedPlan.Deleted = deleted //required
                DeletedPlan.Id = id //required
            }

    and DeletedPrice = {
        ///Always true for a deleted object
        Deleted: bool
        ///Unique identifier for the object.
        Id: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "price"

        static member Create (deleted: bool, id: string) =
            {
                DeletedPrice.Deleted = deleted //required
                DeletedPrice.Id = id //required
            }

    and DeletedProduct = {
        ///Always true for a deleted object
        Deleted: bool
        ///Unique identifier for the object.
        Id: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "product"

        static member Create (deleted: bool, id: string) =
            {
                DeletedProduct.Deleted = deleted //required
                DeletedProduct.Id = id //required
            }

    and DeletedRadarValueList = {
        ///Always true for a deleted object
        Deleted: bool
        ///Unique identifier for the object.
        Id: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "radar.value_list"

        static member Create (deleted: bool, id: string) =
            {
                DeletedRadarValueList.Deleted = deleted //required
                DeletedRadarValueList.Id = id //required
            }

    and DeletedRadarValueListItem = {
        ///Always true for a deleted object
        Deleted: bool
        ///Unique identifier for the object.
        Id: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "radar.value_list_item"

        static member Create (deleted: bool, id: string) =
            {
                DeletedRadarValueListItem.Deleted = deleted //required
                DeletedRadarValueListItem.Id = id //required
            }

    and DeletedRecipient = {
        ///Always true for a deleted object
        Deleted: bool
        ///Unique identifier for the object.
        Id: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "recipient"

        static member Create (deleted: bool, id: string) =
            {
                DeletedRecipient.Deleted = deleted //required
                DeletedRecipient.Id = id //required
            }

    and DeletedSku = {
        ///Always true for a deleted object
        Deleted: bool
        ///Unique identifier for the object.
        Id: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "sku"

        static member Create (deleted: bool, id: string) =
            {
                DeletedSku.Deleted = deleted //required
                DeletedSku.Id = id //required
            }

    and DeletedSubscriptionItem = {
        ///Always true for a deleted object
        Deleted: bool
        ///Unique identifier for the object.
        Id: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "subscription_item"

        static member Create (deleted: bool, id: string) =
            {
                DeletedSubscriptionItem.Deleted = deleted //required
                DeletedSubscriptionItem.Id = id //required
            }

    and DeletedTaxId = {
        ///Always true for a deleted object
        Deleted: bool
        ///Unique identifier for the object.
        Id: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "tax_id"

        static member Create (deleted: bool, id: string) =
            {
                DeletedTaxId.Deleted = deleted //required
                DeletedTaxId.Id = id //required
            }

    and DeletedTerminalLocation = {
        ///Always true for a deleted object
        Deleted: bool
        ///Unique identifier for the object.
        Id: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "terminal.location"

        static member Create (deleted: bool, id: string) =
            {
                DeletedTerminalLocation.Deleted = deleted //required
                DeletedTerminalLocation.Id = id //required
            }

    and DeletedTerminalReader = {
        ///Always true for a deleted object
        Deleted: bool
        ///Unique identifier for the object.
        Id: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "terminal.reader"

        static member Create (deleted: bool, id: string) =
            {
                DeletedTerminalReader.Deleted = deleted //required
                DeletedTerminalReader.Id = id //required
            }

    and DeletedWebhookEndpoint = {
        ///Always true for a deleted object
        Deleted: bool
        ///Unique identifier for the object.
        Id: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "webhook_endpoint"

        static member Create (deleted: bool, id: string) =
            {
                DeletedWebhookEndpoint.Deleted = deleted //required
                DeletedWebhookEndpoint.Id = id //required
            }

    and DeliveryEstimate = {
        ///If `type` is `"exact"`, `date` will be the expected delivery date in the format YYYY-MM-DD.
        Date: string option
        ///If `type` is `"range"`, `earliest` will be be the earliest delivery date in the format YYYY-MM-DD.
        Earliest: string option
        ///If `type` is `"range"`, `latest` will be the latest delivery date in the format YYYY-MM-DD.
        Latest: string option
        ///The type of estimate. Must be either `"range"` or `"exact"`.
        Type: DeliveryEstimateType
    }
    with

        static member Create (``type``: DeliveryEstimateType, ?date: string, ?earliest: string, ?latest: string) =
            {
                DeliveryEstimate.Type = ``type`` //required
                DeliveryEstimate.Date = date
                DeliveryEstimate.Earliest = earliest
                DeliveryEstimate.Latest = latest
            }

    and DeliveryEstimateType =
        | Range
        | Exact

    ///A discount represents the actual application of a coupon to a particular
    ///customer. It contains information about when the discount began and when it
    ///will end.
    ///Related guide: [Applying Discounts to Subscriptions](https://stripe.com/docs/billing/subscriptions/discounts).
    and Discount = {
        ///The Checkout session that this coupon is applied to, if it is applied to a particular session in payment mode. Will not be present for subscription mode.
        CheckoutSession: string option
        Coupon: Coupon
        ///The ID of the customer associated with this discount.
        [<JsonField(Transform=typeof<AnyOfTransform<DiscountCustomer'AnyOf>>)>]Customer: DiscountCustomer'AnyOf option
        ///If the coupon has a duration of `repeating`, the date that this discount will end. If the coupon has a duration of `once` or `forever`, this attribute will be null.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]End: DateTime option
        ///The ID of the discount object. Discounts cannot be fetched by ID. Use `expand[]=discounts` in API calls to expand discount IDs in an array.
        Id: string
        ///The invoice that the discount's coupon was applied to, if it was applied directly to a particular invoice.
        Invoice: string option
        ///The invoice item `id` (or invoice line item `id` for invoice line items of type='subscription') that the discount's coupon was applied to, if it was applied directly to a particular invoice item or invoice line item.
        InvoiceItem: string option
        ///The promotion code applied to create this discount.
        [<JsonField(Transform=typeof<AnyOfTransform<DiscountPromotionCode'AnyOf>>)>]PromotionCode: DiscountPromotionCode'AnyOf option
        ///Date that the coupon was applied.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Start: DateTime
        ///The subscription that this coupon is applied to, if it is applied to a particular subscription.
        Subscription: string option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "discount"

        static member Create (checkoutSession: string option, coupon: Coupon, customer: DiscountCustomer'AnyOf option, ``end``: DateTime option, id: string, invoice: string option, invoiceItem: string option, promotionCode: DiscountPromotionCode'AnyOf option, start: DateTime, subscription: string option) =
            {
                Discount.CheckoutSession = checkoutSession //required
                Discount.Coupon = coupon //required
                Discount.Customer = customer //required
                Discount.End = ``end`` //required
                Discount.Id = id //required
                Discount.Invoice = invoice //required
                Discount.InvoiceItem = invoiceItem //required
                Discount.PromotionCode = promotionCode //required
                Discount.Start = start //required
                Discount.Subscription = subscription //required
            }

    and DiscountCustomer'AnyOf =
        | String of string
        | Customer of Customer
        | DeletedCustomer of DeletedCustomer

    and DiscountPromotionCode'AnyOf =
        | String of string
        | PromotionCode of PromotionCode

    and DiscountsResourceDiscountAmount = {
        ///The amount, in %s, of the discount.
        Amount: int
        ///The discount that was applied to get this discount amount.
        [<JsonField(Transform=typeof<AnyOfTransform<DiscountsResourceDiscountAmountDiscount'AnyOf>>)>]Discount: DiscountsResourceDiscountAmountDiscount'AnyOf
    }
    with

        static member Create (amount: int, discount: DiscountsResourceDiscountAmountDiscount'AnyOf) =
            {
                DiscountsResourceDiscountAmount.Amount = amount //required
                DiscountsResourceDiscountAmount.Discount = discount //required
            }

    and DiscountsResourceDiscountAmountDiscount'AnyOf =
        | String of string
        | Discount of Discount
        | DeletedDiscount of DeletedDiscount

    ///A dispute occurs when a customer questions your charge with their card issuer.
    ///When this happens, you're given the opportunity to respond to the dispute with
    ///evidence that shows that the charge is legitimate. You can find more
    ///information about the dispute process in our [Disputes and
    ///Fraud](/docs/disputes) documentation.
    ///Related guide: [Disputes and Fraud](https://stripe.com/docs/disputes).
    and Dispute = {
        ///Disputed amount. Usually the amount of the charge, but can differ (usually because of currency fluctuation or because only part of the order is disputed).
        Amount: int
        ///List of zero, one, or two balance transactions that show funds withdrawn and reinstated to your Stripe account as a result of this dispute.
        BalanceTransactions: BalanceTransaction list
        ///ID of the charge that was disputed.
        [<JsonField(Transform=typeof<AnyOfTransform<DisputeCharge'AnyOf>>)>]Charge: DisputeCharge'AnyOf
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        Evidence: DisputeEvidence
        EvidenceDetails: DisputeEvidenceDetails
        ///Unique identifier for the object.
        Id: string
        ///If true, it is still possible to refund the disputed payment. Once the payment has been fully refunded, no further funds will be withdrawn from your Stripe account as a result of this dispute.
        IsChargeRefundable: bool
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        ///Network-dependent reason code for the dispute.
        NetworkReasonCode: string option
        ///ID of the PaymentIntent that was disputed.
        [<JsonField(Transform=typeof<AnyOfTransform<DisputePaymentIntent'AnyOf>>)>]PaymentIntent: DisputePaymentIntent'AnyOf option
        ///Reason given by cardholder for dispute. Possible values are `bank_cannot_process`, `check_returned`, `credit_not_processed`, `customer_initiated`, `debit_not_authorized`, `duplicate`, `fraudulent`, `general`, `incorrect_account_details`, `insufficient_funds`, `product_not_received`, `product_unacceptable`, `subscription_canceled`, or `unrecognized`. Read more about [dispute reasons](https://stripe.com/docs/disputes/categories).
        Reason: DisputeReason
        ///Current status of dispute. Possible values are `warning_needs_response`, `warning_under_review`, `warning_closed`, `needs_response`, `under_review`, `charge_refunded`, `won`, or `lost`.
        Status: DisputeStatus
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "dispute"

        static member Create (amount: int, balanceTransactions: BalanceTransaction list, charge: DisputeCharge'AnyOf, created: DateTime, currency: string, evidence: DisputeEvidence, evidenceDetails: DisputeEvidenceDetails, id: string, isChargeRefundable: bool, livemode: bool, metadata: Map<string, string>, paymentIntent: DisputePaymentIntent'AnyOf option, reason: DisputeReason, status: DisputeStatus, ?networkReasonCode: string option) =
            {
                Dispute.Amount = amount //required
                Dispute.BalanceTransactions = balanceTransactions //required
                Dispute.Charge = charge //required
                Dispute.Created = created //required
                Dispute.Currency = currency //required
                Dispute.Evidence = evidence //required
                Dispute.EvidenceDetails = evidenceDetails //required
                Dispute.Id = id //required
                Dispute.IsChargeRefundable = isChargeRefundable //required
                Dispute.Livemode = livemode //required
                Dispute.Metadata = metadata //required
                Dispute.PaymentIntent = paymentIntent //required
                Dispute.Reason = reason //required
                Dispute.Status = status //required
                Dispute.NetworkReasonCode = networkReasonCode |> Option.flatten
            }

    and DisputeCharge'AnyOf =
        | String of string
        | Charge of Charge

    and DisputePaymentIntent'AnyOf =
        | String of string
        | PaymentIntent of PaymentIntent

    and DisputeReason =
        | BankCannotProcess
        | CheckReturned
        | CreditNotProcessed
        | CustomerInitiated
        | DebitNotAuthorized
        | Duplicate
        | Fraudulent
        | General
        | IncorrectAccountDetails
        | InsufficientFunds
        | ProductNotReceived
        | ProductUnacceptable
        | SubscriptionCanceled
        | Unrecognized

    and DisputeStatus =
        | ChargeRefunded
        | Lost
        | NeedsResponse
        | UnderReview
        | WarningClosed
        | WarningNeedsResponse
        | WarningUnderReview
        | Won

    and DisputeEvidence = {
        ///Any server or activity logs showing proof that the customer accessed or downloaded the purchased digital product. This information should include IP addresses, corresponding timestamps, and any detailed recorded activity.
        AccessActivityLog: string option
        ///The billing address provided by the customer.
        BillingAddress: string option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Your subscription cancellation policy, as shown to the customer.
        [<JsonField(Transform=typeof<AnyOfTransform<DisputeEvidenceCancellationPolicy'AnyOf>>)>]CancellationPolicy: DisputeEvidenceCancellationPolicy'AnyOf option
        ///An explanation of how and when the customer was shown your refund policy prior to purchase.
        CancellationPolicyDisclosure: string option
        ///A justification for why the customer's subscription was not canceled.
        CancellationRebuttal: string option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Any communication with the customer that you feel is relevant to your case. Examples include emails proving that the customer received the product or service, or demonstrating their use of or satisfaction with the product or service.
        [<JsonField(Transform=typeof<AnyOfTransform<DisputeEvidenceCustomerCommunication'AnyOf>>)>]CustomerCommunication: DisputeEvidenceCustomerCommunication'AnyOf option
        ///The email address of the customer.
        CustomerEmailAddress: string option
        ///The name of the customer.
        CustomerName: string option
        ///The IP address that the customer used when making the purchase.
        CustomerPurchaseIp: string option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) A relevant document or contract showing the customer's signature.
        [<JsonField(Transform=typeof<AnyOfTransform<DisputeEvidenceCustomerSignature'AnyOf>>)>]CustomerSignature: DisputeEvidenceCustomerSignature'AnyOf option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Documentation for the prior charge that can uniquely identify the charge, such as a receipt, shipping label, work order, etc. This document should be paired with a similar document from the disputed payment that proves the two payments are separate.
        [<JsonField(Transform=typeof<AnyOfTransform<DisputeEvidenceDuplicateChargeDocumentation'AnyOf>>)>]DuplicateChargeDocumentation: DisputeEvidenceDuplicateChargeDocumentation'AnyOf option
        ///An explanation of the difference between the disputed charge versus the prior charge that appears to be a duplicate.
        DuplicateChargeExplanation: string option
        ///The Stripe ID for the prior charge which appears to be a duplicate of the disputed charge.
        DuplicateChargeId: string option
        ///A description of the product or service that was sold.
        ProductDescription: string option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Any receipt or message sent to the customer notifying them of the charge.
        [<JsonField(Transform=typeof<AnyOfTransform<DisputeEvidenceReceipt'AnyOf>>)>]Receipt: DisputeEvidenceReceipt'AnyOf option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Your refund policy, as shown to the customer.
        [<JsonField(Transform=typeof<AnyOfTransform<DisputeEvidenceRefundPolicy'AnyOf>>)>]RefundPolicy: DisputeEvidenceRefundPolicy'AnyOf option
        ///Documentation demonstrating that the customer was shown your refund policy prior to purchase.
        RefundPolicyDisclosure: string option
        ///A justification for why the customer is not entitled to a refund.
        RefundRefusalExplanation: string option
        ///The date on which the customer received or began receiving the purchased service, in a clear human-readable format.
        ServiceDate: string option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Documentation showing proof that a service was provided to the customer. This could include a copy of a signed contract, work order, or other form of written agreement.
        [<JsonField(Transform=typeof<AnyOfTransform<DisputeEvidenceServiceDocumentation'AnyOf>>)>]ServiceDocumentation: DisputeEvidenceServiceDocumentation'AnyOf option
        ///The address to which a physical product was shipped. You should try to include as complete address information as possible.
        ShippingAddress: string option
        ///The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc. If multiple carriers were used for this purchase, please separate them with commas.
        ShippingCarrier: string option
        ///The date on which a physical product began its route to the shipping address, in a clear human-readable format.
        ShippingDate: string option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Documentation showing proof that a product was shipped to the customer at the same address the customer provided to you. This could include a copy of the shipment receipt, shipping label, etc. It should show the customer's full shipping address, if possible.
        [<JsonField(Transform=typeof<AnyOfTransform<DisputeEvidenceShippingDocumentation'AnyOf>>)>]ShippingDocumentation: DisputeEvidenceShippingDocumentation'AnyOf option
        ///The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
        ShippingTrackingNumber: string option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Any additional evidence or statements.
        [<JsonField(Transform=typeof<AnyOfTransform<DisputeEvidenceUncategorizedFile'AnyOf>>)>]UncategorizedFile: DisputeEvidenceUncategorizedFile'AnyOf option
        ///Any additional evidence or statements.
        UncategorizedText: string option
    }
    with

        static member Create (accessActivityLog: string option, billingAddress: string option, cancellationPolicy: DisputeEvidenceCancellationPolicy'AnyOf option, cancellationPolicyDisclosure: string option, cancellationRebuttal: string option, customerCommunication: DisputeEvidenceCustomerCommunication'AnyOf option, customerEmailAddress: string option, customerName: string option, customerPurchaseIp: string option, customerSignature: DisputeEvidenceCustomerSignature'AnyOf option, duplicateChargeDocumentation: DisputeEvidenceDuplicateChargeDocumentation'AnyOf option, duplicateChargeExplanation: string option, duplicateChargeId: string option, productDescription: string option, receipt: DisputeEvidenceReceipt'AnyOf option, refundPolicy: DisputeEvidenceRefundPolicy'AnyOf option, refundPolicyDisclosure: string option, refundRefusalExplanation: string option, serviceDate: string option, serviceDocumentation: DisputeEvidenceServiceDocumentation'AnyOf option, shippingAddress: string option, shippingCarrier: string option, shippingDate: string option, shippingDocumentation: DisputeEvidenceShippingDocumentation'AnyOf option, shippingTrackingNumber: string option, uncategorizedFile: DisputeEvidenceUncategorizedFile'AnyOf option, uncategorizedText: string option) =
            {
                DisputeEvidence.AccessActivityLog = accessActivityLog //required
                DisputeEvidence.BillingAddress = billingAddress //required
                DisputeEvidence.CancellationPolicy = cancellationPolicy //required
                DisputeEvidence.CancellationPolicyDisclosure = cancellationPolicyDisclosure //required
                DisputeEvidence.CancellationRebuttal = cancellationRebuttal //required
                DisputeEvidence.CustomerCommunication = customerCommunication //required
                DisputeEvidence.CustomerEmailAddress = customerEmailAddress //required
                DisputeEvidence.CustomerName = customerName //required
                DisputeEvidence.CustomerPurchaseIp = customerPurchaseIp //required
                DisputeEvidence.CustomerSignature = customerSignature //required
                DisputeEvidence.DuplicateChargeDocumentation = duplicateChargeDocumentation //required
                DisputeEvidence.DuplicateChargeExplanation = duplicateChargeExplanation //required
                DisputeEvidence.DuplicateChargeId = duplicateChargeId //required
                DisputeEvidence.ProductDescription = productDescription //required
                DisputeEvidence.Receipt = receipt //required
                DisputeEvidence.RefundPolicy = refundPolicy //required
                DisputeEvidence.RefundPolicyDisclosure = refundPolicyDisclosure //required
                DisputeEvidence.RefundRefusalExplanation = refundRefusalExplanation //required
                DisputeEvidence.ServiceDate = serviceDate //required
                DisputeEvidence.ServiceDocumentation = serviceDocumentation //required
                DisputeEvidence.ShippingAddress = shippingAddress //required
                DisputeEvidence.ShippingCarrier = shippingCarrier //required
                DisputeEvidence.ShippingDate = shippingDate //required
                DisputeEvidence.ShippingDocumentation = shippingDocumentation //required
                DisputeEvidence.ShippingTrackingNumber = shippingTrackingNumber //required
                DisputeEvidence.UncategorizedFile = uncategorizedFile //required
                DisputeEvidence.UncategorizedText = uncategorizedText //required
            }

    and DisputeEvidenceCancellationPolicy'AnyOf =
        | String of string
        | File of File

    and DisputeEvidenceCustomerCommunication'AnyOf =
        | String of string
        | File of File

    and DisputeEvidenceCustomerSignature'AnyOf =
        | String of string
        | File of File

    and DisputeEvidenceDuplicateChargeDocumentation'AnyOf =
        | String of string
        | File of File

    and DisputeEvidenceReceipt'AnyOf =
        | String of string
        | File of File

    and DisputeEvidenceRefundPolicy'AnyOf =
        | String of string
        | File of File

    and DisputeEvidenceServiceDocumentation'AnyOf =
        | String of string
        | File of File

    and DisputeEvidenceShippingDocumentation'AnyOf =
        | String of string
        | File of File

    and DisputeEvidenceUncategorizedFile'AnyOf =
        | String of string
        | File of File

    and DisputeEvidenceDetails = {
        ///Date by which evidence must be submitted in order to successfully challenge dispute. Will be null if the customer's bank or credit card company doesn't allow a response for this particular dispute.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]DueBy: DateTime option
        ///Whether evidence has been staged for this dispute.
        HasEvidence: bool
        ///Whether the last evidence submission was submitted past the due date. Defaults to `false` if no evidence submissions have occurred. If `true`, then delivery of the latest evidence is *not* guaranteed.
        PastDue: bool
        ///The number of times evidence has been submitted. Typically, you may only submit evidence once.
        SubmissionCount: int
    }
    with

        static member Create (dueBy: DateTime option, hasEvidence: bool, pastDue: bool, submissionCount: int) =
            {
                DisputeEvidenceDetails.DueBy = dueBy //required
                DisputeEvidenceDetails.HasEvidence = hasEvidence //required
                DisputeEvidenceDetails.PastDue = pastDue //required
                DisputeEvidenceDetails.SubmissionCount = submissionCount //required
            }

    and EphemeralKey = {
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Time at which the key will expire. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Expires: DateTime
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///The key's secret. You can use this value to make authorized requests to the Stripe API.
        Secret: string option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "ephemeral_key"

        static member Create (created: DateTime, expires: DateTime, id: string, livemode: bool, ?secret: string) =
            {
                EphemeralKey.Created = created //required
                EphemeralKey.Expires = expires //required
                EphemeralKey.Id = id //required
                EphemeralKey.Livemode = livemode //required
                EphemeralKey.Secret = secret
            }

    ///An error response from the Stripe API
    and Error = {
        Error: ApiErrors
    }
    with

        static member Create (error: ApiErrors) =
            {
                Error.Error = error //required
            }

    ///Events are our way of letting you know when something interesting happens in
    ///your account. When an interesting event occurs, we create a new `Event`
    ///object. For example, when a charge succeeds, we create a `charge.succeeded`
    ///event; and when an invoice payment attempt fails, we create an
    ///`invoice.payment_failed` event. Note that many API requests may cause multiple
    ///events to be created. For example, if you create a new subscription for a
    ///customer, you will receive both a `customer.subscription.created` event and a
    ///`charge.succeeded` event.
    ///Events occur when the state of another API resource changes. The state of that
    ///resource at the time of the change is embedded in the event's data field. For
    ///example, a `charge.succeeded` event will contain a charge, and an
    ///`invoice.payment_failed` event will contain an invoice.
    ///As with other API resources, you can use endpoints to retrieve an
    ///[individual event](https://stripe.com/docs/api#retrieve_event) or a [list of events](https://stripe.com/docs/api#list_events)
    ///from the API. We also have a separate
    ///[webhooks](http://en.wikipedia.org/wiki/Webhook) system for sending the
    ///`Event` objects directly to an endpoint on your server. Webhooks are managed
    ///in your
    ///[account settings](https://dashboard.stripe.com/account/webhooks),
    ///and our [Using Webhooks](https://stripe.com/docs/webhooks) guide will help you get set up.
    ///When using [Connect](https://stripe.com/docs/connect), you can also receive notifications of
    ///events that occur in connected accounts. For these events, there will be an
    ///additional `account` attribute in the received `Event` object.
    ///**NOTE:** Right now, access to events through the [Retrieve Event API](https://stripe.com/docs/api#retrieve_event) is
    ///guaranteed only for 30 days.
    and Event = {
        ///The connected account that originated the event.
        Account: string option
        ///The Stripe API version used to render `data`. *Note: This property is populated only for events on or after October 31, 2014*.
        ApiVersion: string option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        Data: NotificationEventData
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Number of webhooks that have yet to be successfully delivered (i.e., to return a 20x response) to the URLs you've specified.
        PendingWebhooks: int
        ///Information on the API request that instigated the event.
        Request: NotificationEventRequest option
        ///Description of the event (e.g., `invoice.created` or `charge.refunded`).
        Type: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "event"

        static member Create (apiVersion: string option, created: DateTime, data: NotificationEventData, id: string, livemode: bool, pendingWebhooks: int, request: NotificationEventRequest option, ``type``: string, ?account: string) =
            {
                Event.ApiVersion = apiVersion //required
                Event.Created = created //required
                Event.Data = data //required
                Event.Id = id //required
                Event.Livemode = livemode //required
                Event.PendingWebhooks = pendingWebhooks //required
                Event.Request = request //required
                Event.Type = ``type`` //required
                Event.Account = account
            }

    ///`Exchange Rate` objects allow you to determine the rates that Stripe is
    ///currently using to convert from one currency to another. Since this number is
    ///variable throughout the day, there are various reasons why you might want to
    ///know the current rate (for example, to dynamically price an item for a user
    ///with a default payment in a foreign currency).
    ///If you want a guarantee that the charge is made with a certain exchange rate
    ///you expect is current, you can pass in `exchange_rate` to charges endpoints.
    ///If the value is no longer up to date, the charge won't go through. Please
    ///refer to our [Exchange Rates API](https://stripe.com/docs/exchange-rates) guide for more
    ///details.
    and ExchangeRate = {
        ///Unique identifier for the object. Represented as the three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) in lowercase.
        Id: string
        ///Hash where the keys are supported currencies and the values are the exchange rate at which the base id currency converts to the key currency.
        Rates: Map<string, string list>
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "exchange_rate"

        static member Create (id: string, rates: Map<string, string list>) =
            {
                ExchangeRate.Id = id //required
                ExchangeRate.Rates = rates //required
            }

    and ExternalAccount =
        | BankAccount of BankAccount
        | Card of Card

    and Fee = {
        ///Amount of the fee, in cents.
        Amount: int
        ///ID of the Connect application that earned the fee.
        Application: string option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        ///Type of the fee, one of: `application_fee`, `stripe_fee` or `tax`.
        Type: FeeType
    }
    with

        static member Create (amount: int, application: string option, currency: string, description: string option, ``type``: FeeType) =
            {
                Fee.Amount = amount //required
                Fee.Application = application //required
                Fee.Currency = currency //required
                Fee.Description = description //required
                Fee.Type = ``type`` //required
            }

    and FeeType =
        | ApplicationFee
        | StripeFee
        | Tax

    ///`Application Fee Refund` objects allow you to refund an application fee that
    ///has previously been created but not yet refunded. Funds will be refunded to
    ///the Stripe account from which the fee was originally collected.
    ///Related guide: [Refunding Application Fees](https://stripe.com/docs/connect/destination-charges#refunding-app-fee).
    and FeeRefund = {
        ///Amount, in %s.
        Amount: int
        ///Balance transaction that describes the impact on your account balance.
        [<JsonField(Transform=typeof<AnyOfTransform<FeeRefundBalanceTransaction'AnyOf>>)>]BalanceTransaction: FeeRefundBalanceTransaction'AnyOf option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///ID of the application fee that was refunded.
        [<JsonField(Transform=typeof<AnyOfTransform<FeeRefundFee'AnyOf>>)>]Fee: FeeRefundFee'AnyOf
        ///Unique identifier for the object.
        Id: string
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "fee_refund"

        static member Create (amount: int, balanceTransaction: FeeRefundBalanceTransaction'AnyOf option, created: DateTime, currency: string, fee: FeeRefundFee'AnyOf, id: string, metadata: Map<string, string> option) =
            {
                FeeRefund.Amount = amount //required
                FeeRefund.BalanceTransaction = balanceTransaction //required
                FeeRefund.Created = created //required
                FeeRefund.Currency = currency //required
                FeeRefund.Fee = fee //required
                FeeRefund.Id = id //required
                FeeRefund.Metadata = metadata //required
            }

    and FeeRefundBalanceTransaction'AnyOf =
        | String of string
        | BalanceTransaction of BalanceTransaction

    and FeeRefundFee'AnyOf =
        | String of string
        | ApplicationFee of ApplicationFee

    ///This is an object representing a file hosted on Stripe's servers. The
    ///file may have been uploaded by yourself using the [create file](https://stripe.com/docs/api#create_file)
    ///request (for example, when uploading dispute evidence) or it may have
    ///been created by Stripe (for example, the results of a [Sigma scheduled
    ///query](#scheduled_queries)).
    ///Related guide: [File Upload Guide](https://stripe.com/docs/file-upload).
    and File = {
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///The time at which the file expires and is no longer available in epoch seconds.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]ExpiresAt: DateTime option
        ///A filename for the file, suitable for saving to a filesystem.
        Filename: string option
        ///Unique identifier for the object.
        Id: string
        ///A list of [file links](https://stripe.com/docs/api#file_links) that point at this file.
        Links: FileLinks option
        ///The [purpose](https://stripe.com/docs/file-upload#uploading-a-file) of the uploaded file.
        Purpose: FilePurpose
        ///The size in bytes of the file object.
        Size: int
        ///A user friendly title for the document.
        Title: string option
        ///The type of the file returned (e.g., `csv`, `pdf`, `jpg`, or `png`).
        Type: string option
        ///The URL from which the file can be downloaded using your live secret API key.
        Url: string option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "file"

        static member Create (created: DateTime, expiresAt: DateTime option, filename: string option, id: string, purpose: FilePurpose, size: int, title: string option, ``type``: string option, url: string option, ?links: FileLinks option) =
            {
                File.Created = created //required
                File.ExpiresAt = expiresAt //required
                File.Filename = filename //required
                File.Id = id //required
                File.Purpose = purpose //required
                File.Size = size //required
                File.Title = title //required
                File.Type = ``type`` //required
                File.Url = url //required
                File.Links = links |> Option.flatten
            }

    and FilePurpose =
        | AdditionalVerification
        | BusinessIcon
        | BusinessLogo
        | CustomerSignature
        | DisputeEvidence
        | IdentityDocument
        | PciDocument
        | TaxDocumentUserUpload

    ///A list of [file links](https://stripe.com/docs/api#file_links) that point at this file.
    and FileLinks = {
        ///Details about each object.
        Data: FileLink list
        ///True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        ///The URL where this list can be accessed.
        Url: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
        member _.Object = "list"

        static member Create (data: FileLink list, hasMore: bool, url: string) =
            {
                FileLinks.Data = data //required
                FileLinks.HasMore = hasMore //required
                FileLinks.Url = url //required
            }

    ///To share the contents of a `File` object with non-Stripe users, you can
    ///create a `FileLink`. `FileLink`s contain a URL that can be used to
    ///retrieve the contents of the file without authentication.
    and FileLink = {
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Whether this link is already expired.
        Expired: bool
        ///Time at which the link expires.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]ExpiresAt: DateTime option
        ///The file object this link points to.
        [<JsonField(Transform=typeof<AnyOfTransform<FileLinkFile'AnyOf>>)>]File: FileLinkFile'AnyOf
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        ///The publicly accessible URL to download the file.
        Url: string option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "file_link"

        static member Create (created: DateTime, expired: bool, expiresAt: DateTime option, file: FileLinkFile'AnyOf, id: string, livemode: bool, metadata: Map<string, string>, url: string option) =
            {
                FileLink.Created = created //required
                FileLink.Expired = expired //required
                FileLink.ExpiresAt = expiresAt //required
                FileLink.File = file //required
                FileLink.Id = id //required
                FileLink.Livemode = livemode //required
                FileLink.Metadata = metadata //required
                FileLink.Url = url //required
            }

    and FileLinkFile'AnyOf =
        | String of string
        | File of File

    and FinancialReportingFinanceReportRunRunParameters = {
        ///The set of output columns requested for inclusion in the report run.
        Columns: string list option
        ///Connected account ID by which to filter the report run.
        ConnectedAccount: string option
        ///Currency of objects to be included in the report run.
        Currency: string option
        ///Ending timestamp of data to be included in the report run (exclusive).
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]IntervalEnd: DateTime option
        ///Starting timestamp of data to be included in the report run.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]IntervalStart: DateTime option
        ///Payout ID by which to filter the report run.
        Payout: string option
        ///Category of balance transactions to be included in the report run.
        ReportingCategory: string option
        ///Defaults to `Etc/UTC`. The output timezone for all timestamps in the report. A list of possible time zone values is maintained at the [IANA Time Zone Database](http://www.iana.org/time-zones). Has no effect on `interval_start` or `interval_end`.
        Timezone: FinancialReportingFinanceReportRunRunParametersTimezone option
    }
    with

        static member Create (?columns: string list, ?connectedAccount: string, ?currency: string, ?intervalEnd: DateTime, ?intervalStart: DateTime, ?payout: string, ?reportingCategory: string, ?timezone: FinancialReportingFinanceReportRunRunParametersTimezone) =
            {
                FinancialReportingFinanceReportRunRunParameters.Columns = columns
                FinancialReportingFinanceReportRunRunParameters.ConnectedAccount = connectedAccount
                FinancialReportingFinanceReportRunRunParameters.Currency = currency
                FinancialReportingFinanceReportRunRunParameters.IntervalEnd = intervalEnd
                FinancialReportingFinanceReportRunRunParameters.IntervalStart = intervalStart
                FinancialReportingFinanceReportRunRunParameters.Payout = payout
                FinancialReportingFinanceReportRunRunParameters.ReportingCategory = reportingCategory
                FinancialReportingFinanceReportRunRunParameters.Timezone = timezone
            }

    and FinancialReportingFinanceReportRunRunParametersTimezone =
        | IntervalStart
        | IntervalEnd

    and Inventory = {
        ///The count of inventory available. Will be present if and only if `type` is `finite`.
        Quantity: int option
        ///Inventory type. Possible values are `finite`, `bucket` (not quantified), and `infinite`.
        Type: InventoryType
        ///An indicator of the inventory available. Possible values are `in_stock`, `limited`, and `out_of_stock`. Will be present if and only if `type` is `bucket`.
        Value: InventoryValue option
    }
    with

        static member Create (quantity: int option, ``type``: InventoryType, value: InventoryValue option) =
            {
                Inventory.Quantity = quantity //required
                Inventory.Type = ``type`` //required
                Inventory.Value = value //required
            }

    and InventoryType =
        | Finite
        | Bucket
        | Infinite

    and InventoryValue =
        | InStock
        | Limited
        | OutOfStock

    ///Invoices are statements of amounts owed by a customer, and are either
    ///generated one-off, or generated periodically from a subscription.
    ///They contain [invoice items](https://stripe.com/docs/api#invoiceitems), and proration adjustments
    ///that may be caused by subscription upgrades/downgrades (if necessary).
    ///If your invoice is configured to be billed through automatic charges,
    ///Stripe automatically finalizes your invoice and attempts payment. Note
    ///that finalizing the invoice,
    ///[when automatic](https://stripe.com/docs/billing/invoices/workflow/#auto_advance), does
    ///not happen immediately as the invoice is created. Stripe waits
    ///until one hour after the last webhook was successfully sent (or the last
    ///webhook timed out after failing). If you (and the platforms you may have
    ///connected to) have no webhooks configured, Stripe waits one hour after
    ///creation to finalize the invoice.
    ///If your invoice is configured to be billed by sending an email, then based on your
    ///[email settings](https://dashboard.stripe.com/account/billing/automatic'),
    ///Stripe will email the invoice to your customer and await payment. These
    ///emails can contain a link to a hosted page to pay the invoice.
    ///Stripe applies any customer credit on the account before determining the
    ///amount due for the invoice (i.e., the amount that will be actually
    ///charged). If the amount due for the invoice is less than Stripe's [minimum allowed charge
    ///per currency](/docs/currencies#minimum-and-maximum-charge-amounts), the
    ///invoice is automatically marked paid, and we add the amount due to the
    ///customer's running account balance which is applied to the next invoice.
    ///More details on the customer's account balance are
    ///[here](https://stripe.com/docs/api/customers/object#customer_object-account_balance).
    ///Related guide: [Send Invoices to Customers](https://stripe.com/docs/billing/invoices/sending).
    and Invoice = {
        ///The country of the business associated with this invoice, most often the business creating the invoice.
        AccountCountry: string option
        ///The public name of the business associated with this invoice, most often the business creating the invoice.
        AccountName: string option
        ///The account tax IDs associated with the invoice. Only editable when the invoice is a draft.
        AccountTaxIds: InvoiceAccountTaxIds'AnyOf list option
        ///Final amount due at this time for this invoice. If the invoice's total is smaller than the minimum charge amount, for example, or if there is account credit that can be applied to the invoice, the `amount_due` may be 0. If there is a positive `starting_balance` for the invoice (the customer owes money), the `amount_due` will also take that into account. The charge that gets generated for the invoice will be for the amount specified in `amount_due`.
        AmountDue: int
        ///The amount, in %s, that was paid.
        AmountPaid: int
        ///The amount remaining, in %s, that is due.
        AmountRemaining: int
        ///The fee in %s that will be applied to the invoice and transferred to the application owner's Stripe account when the invoice is paid.
        ApplicationFeeAmount: int option
        ///Number of payment attempts made for this invoice, from the perspective of the payment retry schedule. Any payment attempt counts as the first attempt, and subsequently only automatic retries increment the attempt count. In other words, manual payment attempts after the first attempt do not affect the retry schedule.
        AttemptCount: int
        ///Whether an attempt has been made to pay the invoice. An invoice is not attempted until 1 hour after the `invoice.created` webhook, for example, so you might not want to display that invoice as unpaid to your users.
        Attempted: bool
        ///Controls whether Stripe will perform [automatic collection](https://stripe.com/docs/billing/invoices/workflow/#auto_advance) of the invoice. When `false`, the invoice's state will not automatically advance without an explicit action.
        AutoAdvance: bool option
        ///Indicates the reason why the invoice was created. `subscription_cycle` indicates an invoice created by a subscription advancing into a new period. `subscription_create` indicates an invoice created due to creating a subscription. `subscription_update` indicates an invoice created due to updating a subscription. `subscription` is set for all old invoices to indicate either a change to a subscription or a period advancement. `manual` is set for all invoices unrelated to a subscription (for example: created via the invoice editor). The `upcoming` value is reserved for simulated invoices per the upcoming invoice endpoint. `subscription_threshold` indicates an invoice created due to a billing threshold being reached.
        BillingReason: InvoiceBillingReason option
        ///ID of the latest charge generated for this invoice, if any.
        [<JsonField(Transform=typeof<AnyOfTransform<InvoiceCharge'AnyOf>>)>]Charge: InvoiceCharge'AnyOf option
        ///Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay this invoice using the default source attached to the customer. When sending an invoice, Stripe will email this invoice to the customer with payment instructions.
        CollectionMethod: InvoiceCollectionMethod option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///Custom fields displayed on the invoice.
        CustomFields: InvoiceSettingCustomField list option
        ///The ID of the customer who will be billed.
        [<JsonField(Transform=typeof<AnyOfTransform<InvoiceCustomer'AnyOf>>)>]Customer: InvoiceCustomer'AnyOf
        ///The customer's address. Until the invoice is finalized, this field will equal `customer.address`. Once the invoice is finalized, this field will no longer be updated.
        CustomerAddress: Address option
        ///The customer's email. Until the invoice is finalized, this field will equal `customer.email`. Once the invoice is finalized, this field will no longer be updated.
        CustomerEmail: string option
        ///The customer's name. Until the invoice is finalized, this field will equal `customer.name`. Once the invoice is finalized, this field will no longer be updated.
        CustomerName: string option
        ///The customer's phone number. Until the invoice is finalized, this field will equal `customer.phone`. Once the invoice is finalized, this field will no longer be updated.
        CustomerPhone: string option
        ///The customer's shipping information. Until the invoice is finalized, this field will equal `customer.shipping`. Once the invoice is finalized, this field will no longer be updated.
        CustomerShipping: Shipping option
        ///The customer's tax exempt status. Until the invoice is finalized, this field will equal `customer.tax_exempt`. Once the invoice is finalized, this field will no longer be updated.
        CustomerTaxExempt: InvoiceCustomerTaxExempt option
        ///The customer's tax IDs. Until the invoice is finalized, this field will contain the same tax IDs as `customer.tax_ids`. Once the invoice is finalized, this field will no longer be updated.
        CustomerTaxIds: InvoicesResourceInvoiceTaxId list option
        ///ID of the default payment method for the invoice. It must belong to the customer associated with the invoice. If not set, defaults to the subscription's default payment method, if any, or to the default payment method in the customer's invoice settings.
        [<JsonField(Transform=typeof<AnyOfTransform<InvoiceDefaultPaymentMethod'AnyOf>>)>]DefaultPaymentMethod: InvoiceDefaultPaymentMethod'AnyOf option
        ///ID of the default payment source for the invoice. It must belong to the customer associated with the invoice and be in a chargeable state. If not set, defaults to the subscription's default source, if any, or to the customer's default source.
        [<JsonField(Transform=typeof<AnyOfTransform<InvoiceDefaultSource'AnyOf>>)>]DefaultSource: InvoiceDefaultSource'AnyOf option
        ///The tax rates applied to this invoice, if any.
        DefaultTaxRates: TaxRate list
        ///An arbitrary string attached to the object. Often useful for displaying to users. Referenced as 'memo' in the Dashboard.
        Description: string option
        ///Describes the current discount applied to this invoice, if there is one. Not populated if there are multiple discounts.
        Discount: Discount option
        ///The discounts applied to the invoice. Line item discounts are applied before invoice discounts. Use `expand[]=discounts` to expand each discount.
        Discounts: InvoiceDiscounts'AnyOf list option
        ///The date on which payment for this invoice is due. This value will be `null` for invoices where `collection_method=charge_automatically`.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]DueDate: DateTime option
        ///Ending customer balance after the invoice is finalized. Invoices are finalized approximately an hour after successful webhook delivery or when payment collection is attempted for the invoice. If the invoice has not been finalized yet, this will be null.
        EndingBalance: int option
        ///Footer displayed on the invoice.
        Footer: string option
        ///The URL for the hosted invoice page, which allows customers to view and pay an invoice. If the invoice has not been finalized yet, this will be null.
        HostedInvoiceUrl: string option
        ///Unique identifier for the object.
        Id: string option
        ///The link to download the PDF for the invoice. If the invoice has not been finalized yet, this will be null.
        InvoicePdf: string option
        ///The error encountered during the previous attempt to finalize the invoice. This field is cleared when the invoice is successfully finalized.
        LastFinalizationError: ApiErrors option
        ///The individual line items that make up the invoice. `lines` is sorted as follows: invoice items in reverse chronological order, followed by the subscription, if any.
        Lines: InvoiceLines
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        ///The time at which payment will next be attempted. This value will be `null` for invoices where `collection_method=send_invoice`.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]NextPaymentAttempt: DateTime option
        ///A unique, identifying string that appears on emails sent to the customer for this invoice. This starts with the customer's unique invoice_prefix if it is specified.
        Number: string option
        ///Whether payment was successfully collected for this invoice. An invoice can be paid (most commonly) with a charge or with credit from the customer's account balance.
        Paid: bool
        ///The PaymentIntent associated with this invoice. The PaymentIntent is generated when the invoice is finalized, and can then be used to pay the invoice. Note that voiding an invoice will cancel the PaymentIntent.
        [<JsonField(Transform=typeof<AnyOfTransform<InvoicePaymentIntent'AnyOf>>)>]PaymentIntent: InvoicePaymentIntent'AnyOf option
        ///End of the usage period during which invoice items were added to this invoice.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]PeriodEnd: DateTime
        ///Start of the usage period during which invoice items were added to this invoice.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]PeriodStart: DateTime
        ///Total amount of all post-payment credit notes issued for this invoice.
        PostPaymentCreditNotesAmount: int
        ///Total amount of all pre-payment credit notes issued for this invoice.
        PrePaymentCreditNotesAmount: int
        ///This is the transaction number that appears on email receipts sent for this invoice.
        ReceiptNumber: string option
        ///Starting customer balance before the invoice is finalized. If the invoice has not been finalized yet, this will be the current customer balance.
        StartingBalance: int
        ///Extra information about an invoice for the customer's credit card statement.
        StatementDescriptor: string option
        ///The status of the invoice, one of `draft`, `open`, `paid`, `uncollectible`, or `void`. [Learn more](https://stripe.com/docs/billing/invoices/workflow#workflow-overview)
        Status: InvoiceStatus option
        StatusTransitions: InvoicesStatusTransitions
        ///The subscription that this invoice was prepared for, if any.
        [<JsonField(Transform=typeof<AnyOfTransform<InvoiceSubscription'AnyOf>>)>]Subscription: InvoiceSubscription'AnyOf option
        ///Only set for upcoming invoices that preview prorations. The time used to calculate prorations.
        SubscriptionProrationDate: int option
        ///Total of all subscriptions, invoice items, and prorations on the invoice before any invoice level discount or tax is applied. Item discounts are already incorporated
        Subtotal: int
        ///The amount of tax on this invoice. This is the sum of all the tax amounts on this invoice.
        Tax: int option
        ThresholdReason: InvoiceThresholdReason option
        ///Total after discounts and taxes.
        Total: int
        ///The aggregate amounts calculated per discount across all line items.
        TotalDiscountAmounts: DiscountsResourceDiscountAmount list option
        ///The aggregate amounts calculated per tax rate for all line items.
        TotalTaxAmounts: InvoiceTaxAmount list
        ///The account (if any) the payment will be attributed to for tax reporting, and where funds from the payment will be transferred to for the invoice.
        TransferData: InvoiceTransferData option
        ///Invoices are automatically paid or sent 1 hour after webhooks are delivered, or until all webhook delivery attempts have [been exhausted](https://stripe.com/docs/billing/webhooks#understand). This field tracks the time when webhooks for this invoice were successfully delivered. If the invoice had no webhooks to deliver, this will be set while the invoice is being created.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]WebhooksDeliveredAt: DateTime option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "invoice"

        static member Create (accountCountry: string option, accountName: string option, amountDue: int, amountPaid: int, amountRemaining: int, applicationFeeAmount: int option, attemptCount: int, attempted: bool, billingReason: InvoiceBillingReason option, charge: InvoiceCharge'AnyOf option, collectionMethod: InvoiceCollectionMethod option, created: DateTime, currency: string, customFields: InvoiceSettingCustomField list option, customer: InvoiceCustomer'AnyOf, customerAddress: Address option, customerEmail: string option, customerName: string option, customerPhone: string option, customerShipping: Shipping option, customerTaxExempt: InvoiceCustomerTaxExempt option, defaultPaymentMethod: InvoiceDefaultPaymentMethod'AnyOf option, defaultSource: InvoiceDefaultSource'AnyOf option, defaultTaxRates: TaxRate list, description: string option, discount: Discount option, discounts: InvoiceDiscounts'AnyOf list option, dueDate: DateTime option, endingBalance: int option, footer: string option, lines: InvoiceLines, livemode: bool, metadata: Map<string, string> option, nextPaymentAttempt: DateTime option, number: string option, paid: bool, paymentIntent: InvoicePaymentIntent'AnyOf option, periodEnd: DateTime, periodStart: DateTime, postPaymentCreditNotesAmount: int, prePaymentCreditNotesAmount: int, receiptNumber: string option, startingBalance: int, statementDescriptor: string option, status: InvoiceStatus option, statusTransitions: InvoicesStatusTransitions, subscription: InvoiceSubscription'AnyOf option, subtotal: int, tax: int option, total: int, totalDiscountAmounts: DiscountsResourceDiscountAmount list option, totalTaxAmounts: InvoiceTaxAmount list, transferData: InvoiceTransferData option, webhooksDeliveredAt: DateTime option, ?accountTaxIds: InvoiceAccountTaxIds'AnyOf list option, ?autoAdvance: bool, ?customerTaxIds: InvoicesResourceInvoiceTaxId list option, ?hostedInvoiceUrl: string option, ?id: string, ?invoicePdf: string option, ?lastFinalizationError: ApiErrors option, ?subscriptionProrationDate: int, ?thresholdReason: InvoiceThresholdReason) =
            {
                Invoice.AccountCountry = accountCountry //required
                Invoice.AccountName = accountName //required
                Invoice.AmountDue = amountDue //required
                Invoice.AmountPaid = amountPaid //required
                Invoice.AmountRemaining = amountRemaining //required
                Invoice.ApplicationFeeAmount = applicationFeeAmount //required
                Invoice.AttemptCount = attemptCount //required
                Invoice.Attempted = attempted //required
                Invoice.BillingReason = billingReason //required
                Invoice.Charge = charge //required
                Invoice.CollectionMethod = collectionMethod //required
                Invoice.Created = created //required
                Invoice.Currency = currency //required
                Invoice.CustomFields = customFields //required
                Invoice.Customer = customer //required
                Invoice.CustomerAddress = customerAddress //required
                Invoice.CustomerEmail = customerEmail //required
                Invoice.CustomerName = customerName //required
                Invoice.CustomerPhone = customerPhone //required
                Invoice.CustomerShipping = customerShipping //required
                Invoice.CustomerTaxExempt = customerTaxExempt //required
                Invoice.DefaultPaymentMethod = defaultPaymentMethod //required
                Invoice.DefaultSource = defaultSource //required
                Invoice.DefaultTaxRates = defaultTaxRates //required
                Invoice.Description = description //required
                Invoice.Discount = discount //required
                Invoice.Discounts = discounts //required
                Invoice.DueDate = dueDate //required
                Invoice.EndingBalance = endingBalance //required
                Invoice.Footer = footer //required
                Invoice.Lines = lines //required
                Invoice.Livemode = livemode //required
                Invoice.Metadata = metadata //required
                Invoice.NextPaymentAttempt = nextPaymentAttempt //required
                Invoice.Number = number //required
                Invoice.Paid = paid //required
                Invoice.PaymentIntent = paymentIntent //required
                Invoice.PeriodEnd = periodEnd //required
                Invoice.PeriodStart = periodStart //required
                Invoice.PostPaymentCreditNotesAmount = postPaymentCreditNotesAmount //required
                Invoice.PrePaymentCreditNotesAmount = prePaymentCreditNotesAmount //required
                Invoice.ReceiptNumber = receiptNumber //required
                Invoice.StartingBalance = startingBalance //required
                Invoice.StatementDescriptor = statementDescriptor //required
                Invoice.Status = status //required
                Invoice.StatusTransitions = statusTransitions //required
                Invoice.Subscription = subscription //required
                Invoice.Subtotal = subtotal //required
                Invoice.Tax = tax //required
                Invoice.Total = total //required
                Invoice.TotalDiscountAmounts = totalDiscountAmounts //required
                Invoice.TotalTaxAmounts = totalTaxAmounts //required
                Invoice.TransferData = transferData //required
                Invoice.WebhooksDeliveredAt = webhooksDeliveredAt //required
                Invoice.AccountTaxIds = accountTaxIds |> Option.flatten
                Invoice.AutoAdvance = autoAdvance
                Invoice.CustomerTaxIds = customerTaxIds |> Option.flatten
                Invoice.HostedInvoiceUrl = hostedInvoiceUrl |> Option.flatten
                Invoice.Id = id
                Invoice.InvoicePdf = invoicePdf |> Option.flatten
                Invoice.LastFinalizationError = lastFinalizationError |> Option.flatten
                Invoice.SubscriptionProrationDate = subscriptionProrationDate
                Invoice.ThresholdReason = thresholdReason
            }

    and InvoiceBillingReason =
        | AutomaticPendingInvoiceItemInvoice
        | Manual
        | Subscription
        | SubscriptionCreate
        | SubscriptionCycle
        | SubscriptionThreshold
        | SubscriptionUpdate
        | Upcoming

    and InvoiceCharge'AnyOf =
        | String of string
        | Charge of Charge

    and InvoiceCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    and InvoiceCustomer'AnyOf =
        | String of string
        | Customer of Customer
        | DeletedCustomer of DeletedCustomer

    and InvoiceCustomerTaxExempt =
        | Exempt
        | None'
        | Reverse

    and InvoiceDefaultPaymentMethod'AnyOf =
        | String of string
        | PaymentMethod of PaymentMethod

    and InvoiceDefaultSource'AnyOf =
        | String of string
        | PaymentSource of PaymentSource

    and InvoicePaymentIntent'AnyOf =
        | String of string
        | PaymentIntent of PaymentIntent

    and InvoiceStatus =
        | Deleted
        | Draft
        | Open
        | Paid
        | Uncollectible
        | Void

    and InvoiceSubscription'AnyOf =
        | String of string
        | Subscription of Subscription

    and InvoiceAccountTaxIds'AnyOf =
        | String of string
        | TaxId of TaxId
        | DeletedTaxId of DeletedTaxId

    and InvoiceDiscounts'AnyOf =
        | String of string
        | Discount of Discount
        | DeletedDiscount of DeletedDiscount

    ///The individual line items that make up the invoice. `lines` is sorted as follows: invoice items in reverse chronological order, followed by the subscription, if any.
    and InvoiceLines = {
        ///Details about each object.
        Data: LineItem list
        ///True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        ///The URL where this list can be accessed.
        Url: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
        member _.Object = "list"

        static member Create (data: LineItem list, hasMore: bool, url: string) =
            {
                InvoiceLines.Data = data //required
                InvoiceLines.HasMore = hasMore //required
                InvoiceLines.Url = url //required
            }

    and InvoiceItemThresholdReason = {
        ///The IDs of the line items that triggered the threshold invoice.
        LineItemIds: string list
        ///The quantity threshold boundary that applied to the given line item.
        UsageGte: int
    }
    with

        static member Create (lineItemIds: string list, usageGte: int) =
            {
                InvoiceItemThresholdReason.LineItemIds = lineItemIds //required
                InvoiceItemThresholdReason.UsageGte = usageGte //required
            }

    and InvoiceLineItemPeriod = {
        ///End of the line item's billing period
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]End: DateTime
        ///Start of the line item's billing period
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Start: DateTime
    }
    with

        static member Create (``end``: DateTime, start: DateTime) =
            {
                InvoiceLineItemPeriod.End = ``end`` //required
                InvoiceLineItemPeriod.Start = start //required
            }

    and InvoiceSettingCustomField = {
        ///The name of the custom field.
        Name: string
        ///The value of the custom field.
        Value: string
    }
    with

        static member Create (name: string, value: string) =
            {
                InvoiceSettingCustomField.Name = name //required
                InvoiceSettingCustomField.Value = value //required
            }

    and InvoiceSettingCustomerSetting = {
        ///Default custom fields to be displayed on invoices for this customer.
        CustomFields: InvoiceSettingCustomField list option
        ///ID of a payment method that's attached to the customer, to be used as the customer's default payment method for subscriptions and invoices.
        [<JsonField(Transform=typeof<AnyOfTransform<InvoiceSettingCustomerSettingDefaultPaymentMethod'AnyOf>>)>]DefaultPaymentMethod: InvoiceSettingCustomerSettingDefaultPaymentMethod'AnyOf option
        ///Default footer to be displayed on invoices for this customer.
        Footer: string option
    }
    with

        static member Create (customFields: InvoiceSettingCustomField list option, defaultPaymentMethod: InvoiceSettingCustomerSettingDefaultPaymentMethod'AnyOf option, footer: string option) =
            {
                InvoiceSettingCustomerSetting.CustomFields = customFields //required
                InvoiceSettingCustomerSetting.DefaultPaymentMethod = defaultPaymentMethod //required
                InvoiceSettingCustomerSetting.Footer = footer //required
            }

    and InvoiceSettingCustomerSettingDefaultPaymentMethod'AnyOf =
        | String of string
        | PaymentMethod of PaymentMethod

    and InvoiceSettingSubscriptionScheduleSetting = {
        ///Number of days within which a customer must pay invoices generated by this subscription schedule. This value will be `null` for subscription schedules where `billing=charge_automatically`.
        DaysUntilDue: int option
    }
    with

        static member Create (daysUntilDue: int option) =
            {
                InvoiceSettingSubscriptionScheduleSetting.DaysUntilDue = daysUntilDue //required
            }

    and InvoiceTaxAmount = {
        ///The amount, in %s, of the tax.
        Amount: int
        ///Whether this tax amount is inclusive or exclusive.
        Inclusive: bool
        ///The tax rate that was applied to get this tax amount.
        [<JsonField(Transform=typeof<AnyOfTransform<InvoiceTaxAmountTaxRate'AnyOf>>)>]TaxRate: InvoiceTaxAmountTaxRate'AnyOf
    }
    with

        static member Create (amount: int, inclusive: bool, taxRate: InvoiceTaxAmountTaxRate'AnyOf) =
            {
                InvoiceTaxAmount.Amount = amount //required
                InvoiceTaxAmount.Inclusive = inclusive //required
                InvoiceTaxAmount.TaxRate = taxRate //required
            }

    and InvoiceTaxAmountTaxRate'AnyOf =
        | String of string
        | TaxRate of TaxRate

    and InvoiceThresholdReason = {
        ///The total invoice amount threshold boundary if it triggered the threshold invoice.
        AmountGte: int option
        ///Indicates which line items triggered a threshold invoice.
        ItemReasons: InvoiceItemThresholdReason list
    }
    with

        static member Create (amountGte: int option, itemReasons: InvoiceItemThresholdReason list) =
            {
                InvoiceThresholdReason.AmountGte = amountGte //required
                InvoiceThresholdReason.ItemReasons = itemReasons //required
            }

    and InvoiceTransferData = {
        ///The amount in %s that will be transferred to the destination account when the invoice is paid. By default, the entire amount is transferred to the destination.
        Amount: int option
        ///The account where funds from the payment will be transferred to upon payment success.
        [<JsonField(Transform=typeof<AnyOfTransform<InvoiceTransferDataDestination'AnyOf>>)>]Destination: InvoiceTransferDataDestination'AnyOf
    }
    with

        static member Create (amount: int option, destination: InvoiceTransferDataDestination'AnyOf) =
            {
                InvoiceTransferData.Amount = amount //required
                InvoiceTransferData.Destination = destination //required
            }

    and InvoiceTransferDataDestination'AnyOf =
        | String of string
        | Account of Account

    ///Sometimes you want to add a charge or credit to a customer, but actually
    ///charge or credit the customer's card only at the end of a regular billing
    ///cycle. This is useful for combining several charges (to minimize
    ///per-transaction fees), or for having Stripe tabulate your usage-based billing
    ///totals.
    ///Related guide: [Subscription Invoices](https://stripe.com/docs/billing/invoices/subscription#adding-upcoming-invoice-items).
    and Invoiceitem = {
        ///Amount (in the `currency` specified) of the invoice item. This should always be equal to `unit_amount * quantity`.
        Amount: int
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///The ID of the customer who will be billed when this invoice item is billed.
        [<JsonField(Transform=typeof<AnyOfTransform<InvoiceitemCustomer'AnyOf>>)>]Customer: InvoiceitemCustomer'AnyOf
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Date: DateTime
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        ///If true, discounts will apply to this invoice item. Always false for prorations.
        Discountable: bool
        ///The discounts which apply to the invoice item. Item discounts are applied before invoice discounts. Use `expand[]=discounts` to expand each discount.
        Discounts: InvoiceitemDiscounts'AnyOf list option
        ///Unique identifier for the object.
        Id: string
        ///The ID of the invoice this invoice item belongs to.
        [<JsonField(Transform=typeof<AnyOfTransform<InvoiceitemInvoice'AnyOf>>)>]Invoice: InvoiceitemInvoice'AnyOf option
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        Period: InvoiceLineItemPeriod
        ///If the invoice item is a proration, the plan of the subscription that the proration was computed for.
        Plan: Plan option
        ///The price of the invoice item.
        Price: Price option
        ///Whether the invoice item was created automatically as a proration adjustment when the customer switched plans.
        Proration: bool
        ///Quantity of units for the invoice item. If the invoice item is a proration, the quantity of the subscription that the proration was computed for.
        Quantity: int
        ///The subscription that this invoice item has been created for, if any.
        [<JsonField(Transform=typeof<AnyOfTransform<InvoiceitemSubscription'AnyOf>>)>]Subscription: InvoiceitemSubscription'AnyOf option
        ///The subscription item that this invoice item has been created for, if any.
        SubscriptionItem: string option
        ///The tax rates which apply to the invoice item. When set, the `default_tax_rates` on the invoice do not apply to this invoice item.
        TaxRates: TaxRate list option
        ///Unit amount (in the `currency` specified) of the invoice item.
        UnitAmount: int option
        ///Same as `unit_amount`, but contains a decimal value with at most 12 decimal places.
        UnitAmountDecimal: string option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "invoiceitem"

        static member Create (amount: int, currency: string, customer: InvoiceitemCustomer'AnyOf, date: DateTime, description: string option, discountable: bool, discounts: InvoiceitemDiscounts'AnyOf list option, id: string, invoice: InvoiceitemInvoice'AnyOf option, livemode: bool, metadata: Map<string, string> option, period: InvoiceLineItemPeriod, plan: Plan option, price: Price option, proration: bool, quantity: int, subscription: InvoiceitemSubscription'AnyOf option, taxRates: TaxRate list option, unitAmount: int option, unitAmountDecimal: string option, ?subscriptionItem: string) =
            {
                Invoiceitem.Amount = amount //required
                Invoiceitem.Currency = currency //required
                Invoiceitem.Customer = customer //required
                Invoiceitem.Date = date //required
                Invoiceitem.Description = description //required
                Invoiceitem.Discountable = discountable //required
                Invoiceitem.Discounts = discounts //required
                Invoiceitem.Id = id //required
                Invoiceitem.Invoice = invoice //required
                Invoiceitem.Livemode = livemode //required
                Invoiceitem.Metadata = metadata //required
                Invoiceitem.Period = period //required
                Invoiceitem.Plan = plan //required
                Invoiceitem.Price = price //required
                Invoiceitem.Proration = proration //required
                Invoiceitem.Quantity = quantity //required
                Invoiceitem.Subscription = subscription //required
                Invoiceitem.TaxRates = taxRates //required
                Invoiceitem.UnitAmount = unitAmount //required
                Invoiceitem.UnitAmountDecimal = unitAmountDecimal //required
                Invoiceitem.SubscriptionItem = subscriptionItem
            }

    and InvoiceitemCustomer'AnyOf =
        | String of string
        | Customer of Customer
        | DeletedCustomer of DeletedCustomer

    and InvoiceitemInvoice'AnyOf =
        | String of string
        | Invoice of Invoice

    and InvoiceitemSubscription'AnyOf =
        | String of string
        | Subscription of Subscription

    and InvoiceitemDiscounts'AnyOf =
        | String of string
        | Discount of Discount

    and InvoicesResourceInvoiceTaxId = {
        ///The type of the tax ID, one of `eu_vat`, `br_cnpj`, `br_cpf`, `nz_gst`, `au_abn`, `in_gst`, `no_vat`, `za_vat`, `ch_vat`, `mx_rfc`, `sg_uen`, `ru_inn`, `ru_kpp`, `ca_bn`, `hk_br`, `es_cif`, `tw_vat`, `th_vat`, `jp_cn`, `jp_rn`, `li_uid`, `my_itn`, `us_ein`, `kr_brn`, `ca_qst`, `my_sst`, `sg_gst`, `ae_trn`, `cl_tin`, `sa_vat`, `id_npwp`, `my_frp`, or `unknown`
        Type: InvoicesResourceInvoiceTaxIdType
        ///The value of the tax ID.
        Value: string option
    }
    with

        static member Create (``type``: InvoicesResourceInvoiceTaxIdType, value: string option) =
            {
                InvoicesResourceInvoiceTaxId.Type = ``type`` //required
                InvoicesResourceInvoiceTaxId.Value = value //required
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

    and InvoicesStatusTransitions = {
        ///The time that the invoice draft was finalized.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]FinalizedAt: DateTime option
        ///The time that the invoice was marked uncollectible.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]MarkedUncollectibleAt: DateTime option
        ///The time that the invoice was paid.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]PaidAt: DateTime option
        ///The time that the invoice was voided.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]VoidedAt: DateTime option
    }
    with

        static member Create (finalizedAt: DateTime option, markedUncollectibleAt: DateTime option, paidAt: DateTime option, voidedAt: DateTime option) =
            {
                InvoicesStatusTransitions.FinalizedAt = finalizedAt //required
                InvoicesStatusTransitions.MarkedUncollectibleAt = markedUncollectibleAt //required
                InvoicesStatusTransitions.PaidAt = paidAt //required
                InvoicesStatusTransitions.VoidedAt = voidedAt //required
            }

    ///This resource has been renamed to [Early Fraud
    ///Warning](#early_fraud_warning_object) and will be removed in a future API
    ///version.
    and IssuerFraudRecord = {
        ///An IFR is actionable if it has not received a dispute and has not been fully refunded. You may wish to proactively refund a charge that receives an IFR, in order to avoid receiving a dispute later.
        Actionable: bool
        ///ID of the charge this issuer fraud record is for, optionally expanded.
        [<JsonField(Transform=typeof<AnyOfTransform<IssuerFraudRecordCharge'AnyOf>>)>]Charge: IssuerFraudRecordCharge'AnyOf
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///The type of fraud labelled by the issuer. One of `card_never_received`, `fraudulent_card_application`, `made_with_counterfeit_card`, `made_with_lost_card`, `made_with_stolen_card`, `misc`, `unauthorized_use_of_card`.
        FraudType: string
        ///If true, the associated charge is subject to [liability shift](https://stripe.com/docs/payments/3d-secure#disputed-payments).
        HasLiabilityShift: bool
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///The timestamp at which the card issuer posted the issuer fraud record.
        PostDate: int
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "issuer_fraud_record"

        static member Create (actionable: bool, charge: IssuerFraudRecordCharge'AnyOf, created: DateTime, fraudType: string, hasLiabilityShift: bool, id: string, livemode: bool, postDate: int) =
            {
                IssuerFraudRecord.Actionable = actionable //required
                IssuerFraudRecord.Charge = charge //required
                IssuerFraudRecord.Created = created //required
                IssuerFraudRecord.FraudType = fraudType //required
                IssuerFraudRecord.HasLiabilityShift = hasLiabilityShift //required
                IssuerFraudRecord.Id = id //required
                IssuerFraudRecord.Livemode = livemode //required
                IssuerFraudRecord.PostDate = postDate //required
            }

    and IssuerFraudRecordCharge'AnyOf =
        | String of string
        | Charge of Charge

    ///When an [issued card](https://stripe.com/docs/issuing) is used to make a purchase, an Issuing `Authorization`
    ///object is created. [Authorizations](https://stripe.com/docs/issuing/purchases/authorizations) must be approved for the
    ///purchase to be completed successfully.
    ///Related guide: [Issued Card Authorizations](https://stripe.com/docs/issuing/purchases/authorizations).
    and IssuingAuthorization = {
        ///The total amount that was authorized or rejected. This amount is in the card's currency and in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal).
        Amount: int
        ///Detailed breakdown of amount components. These amounts are denominated in `currency` and in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal).
        AmountDetails: IssuingAuthorizationAmountDetails option
        ///Whether the authorization has been approved.
        Approved: bool
        ///How the card details were provided.
        AuthorizationMethod: IssuingAuthorizationAuthorizationMethod
        ///List of balance transactions associated with this authorization.
        BalanceTransactions: BalanceTransaction list
        Card: IssuingCard
        ///The cardholder to whom this authorization belongs.
        [<JsonField(Transform=typeof<AnyOfTransform<IssuingAuthorizationCardholder'AnyOf>>)>]Cardholder: IssuingAuthorizationCardholder'AnyOf option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///The total amount that was authorized or rejected. This amount is in the `merchant_currency` and in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal).
        MerchantAmount: int
        ///The currency that was presented to the cardholder for the authorization. Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        MerchantCurrency: string
        MerchantData: IssuingAuthorizationMerchantData
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        ///The pending authorization request. This field will only be non-null during an `issuing_authorization.request` webhook.
        PendingRequest: IssuingAuthorizationPendingRequest option
        ///History of every time the authorization was approved/denied (whether approved/denied by you directly or by Stripe based on your `spending_controls`). If the merchant changes the authorization by performing an [incremental authorization or partial capture](https://stripe.com/docs/issuing/purchases/authorizations), you can look at this field to see the previous states of the authorization.
        RequestHistory: IssuingAuthorizationRequest list
        ///The current status of the authorization in its lifecycle.
        Status: IssuingAuthorizationStatus
        ///List of [transactions](https://stripe.com/docs/api/issuing/transactions) associated with this authorization.
        Transactions: IssuingTransaction list
        VerificationData: IssuingAuthorizationVerificationData
        ///What, if any, digital wallet was used for this authorization. One of `apple_pay`, `google_pay`, or `samsung_pay`.
        Wallet: IssuingAuthorizationWallet option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "issuing.authorization"

        static member Create (amount: int, amountDetails: IssuingAuthorizationAmountDetails option, approved: bool, authorizationMethod: IssuingAuthorizationAuthorizationMethod, balanceTransactions: BalanceTransaction list, card: IssuingCard, cardholder: IssuingAuthorizationCardholder'AnyOf option, created: DateTime, currency: string, id: string, livemode: bool, merchantAmount: int, merchantCurrency: string, merchantData: IssuingAuthorizationMerchantData, metadata: Map<string, string>, pendingRequest: IssuingAuthorizationPendingRequest option, requestHistory: IssuingAuthorizationRequest list, status: IssuingAuthorizationStatus, transactions: IssuingTransaction list, verificationData: IssuingAuthorizationVerificationData, wallet: IssuingAuthorizationWallet option) =
            {
                IssuingAuthorization.Amount = amount //required
                IssuingAuthorization.AmountDetails = amountDetails //required
                IssuingAuthorization.Approved = approved //required
                IssuingAuthorization.AuthorizationMethod = authorizationMethod //required
                IssuingAuthorization.BalanceTransactions = balanceTransactions //required
                IssuingAuthorization.Card = card //required
                IssuingAuthorization.Cardholder = cardholder //required
                IssuingAuthorization.Created = created //required
                IssuingAuthorization.Currency = currency //required
                IssuingAuthorization.Id = id //required
                IssuingAuthorization.Livemode = livemode //required
                IssuingAuthorization.MerchantAmount = merchantAmount //required
                IssuingAuthorization.MerchantCurrency = merchantCurrency //required
                IssuingAuthorization.MerchantData = merchantData //required
                IssuingAuthorization.Metadata = metadata //required
                IssuingAuthorization.PendingRequest = pendingRequest //required
                IssuingAuthorization.RequestHistory = requestHistory //required
                IssuingAuthorization.Status = status //required
                IssuingAuthorization.Transactions = transactions //required
                IssuingAuthorization.VerificationData = verificationData //required
                IssuingAuthorization.Wallet = wallet //required
            }

    and IssuingAuthorizationAuthorizationMethod =
        | Chip
        | Contactless
        | KeyedIn
        | Online
        | Swipe

    and IssuingAuthorizationCardholder'AnyOf =
        | String of string
        | IssuingCardholder of IssuingCardholder

    and IssuingAuthorizationStatus =
        | Closed
        | Pending
        | Reversed

    and IssuingAuthorizationWallet =
        | ApplePay
        | GooglePay
        | SamsungPay

    ///You can [create physical or virtual cards](https://stripe.com/docs/issuing/cards) that are issued to cardholders.
    and IssuingCard = {
        ///The brand of the card.
        Brand: string
        ///The reason why the card was canceled.
        CancellationReason: IssuingCardCancellationReason option
        Cardholder: IssuingCardholder
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///The card's CVC. For security reasons, this is only available for virtual cards, and will be omitted unless you explicitly request it with [the `expand` parameter](https://stripe.com/docs/api/expanding_objects). Additionally, it's only available via the ["Retrieve a card" endpoint](https://stripe.com/docs/api/issuing/cards/retrieve), not via "List all cards" or any other endpoint.
        Cvc: string option
        ///The expiration month of the card.
        ExpMonth: int
        ///The expiration year of the card.
        ExpYear: int
        ///Unique identifier for the object.
        Id: string
        ///The last 4 digits of the card number.
        [<JsonField(Name="last4")>]Last4: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        ///The full unredacted card number. For security reasons, this is only available for virtual cards, and will be omitted unless you explicitly request it with [the `expand` parameter](https://stripe.com/docs/api/expanding_objects). Additionally, it's only available via the ["Retrieve a card" endpoint](https://stripe.com/docs/api/issuing/cards/retrieve), not via "List all cards" or any other endpoint.
        Number: string option
        ///The latest card that replaces this card, if any.
        [<JsonField(Transform=typeof<AnyOfTransform<IssuingCardReplacedBy'AnyOf>>)>]ReplacedBy: IssuingCardReplacedBy'AnyOf option
        ///The card this card replaces, if any.
        [<JsonField(Transform=typeof<AnyOfTransform<IssuingCardReplacementFor'AnyOf>>)>]ReplacementFor: IssuingCardReplacementFor'AnyOf option
        ///The reason why the previous card needed to be replaced.
        ReplacementReason: IssuingCardReplacementReason option
        ///Where and how the card will be shipped.
        Shipping: IssuingCardShipping option
        SpendingControls: IssuingCardAuthorizationControls
        ///Whether authorizations can be approved on this card.
        Status: IssuingCardStatus
        ///The type of the card.
        Type: IssuingCardType
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "issuing.card"

        static member Create (brand: string, cancellationReason: IssuingCardCancellationReason option, cardholder: IssuingCardholder, created: DateTime, currency: string, expMonth: int, expYear: int, id: string, last4: string, livemode: bool, metadata: Map<string, string>, replacedBy: IssuingCardReplacedBy'AnyOf option, replacementFor: IssuingCardReplacementFor'AnyOf option, replacementReason: IssuingCardReplacementReason option, shipping: IssuingCardShipping option, spendingControls: IssuingCardAuthorizationControls, status: IssuingCardStatus, ``type``: IssuingCardType, ?cvc: string, ?number: string) =
            {
                IssuingCard.Brand = brand //required
                IssuingCard.CancellationReason = cancellationReason //required
                IssuingCard.Cardholder = cardholder //required
                IssuingCard.Created = created //required
                IssuingCard.Currency = currency //required
                IssuingCard.ExpMonth = expMonth //required
                IssuingCard.ExpYear = expYear //required
                IssuingCard.Id = id //required
                IssuingCard.Last4 = last4 //required
                IssuingCard.Livemode = livemode //required
                IssuingCard.Metadata = metadata //required
                IssuingCard.ReplacedBy = replacedBy //required
                IssuingCard.ReplacementFor = replacementFor //required
                IssuingCard.ReplacementReason = replacementReason //required
                IssuingCard.Shipping = shipping //required
                IssuingCard.SpendingControls = spendingControls //required
                IssuingCard.Status = status //required
                IssuingCard.Type = ``type`` //required
                IssuingCard.Cvc = cvc
                IssuingCard.Number = number
            }

    and IssuingCardCancellationReason =
        | Lost
        | Stolen

    and IssuingCardReplacedBy'AnyOf =
        | String of string
        | IssuingCard of IssuingCard

    and IssuingCardReplacementFor'AnyOf =
        | String of string
        | IssuingCard of IssuingCard

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
    ///Related guide: [How to create a Cardholder](https://stripe.com/docs/issuing/cards#create-cardholder)
    and IssuingCardholder = {
        Billing: IssuingCardholderAddress
        ///Additional information about a `company` cardholder.
        Company: IssuingCardholderCompany option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///The cardholder's email address.
        Email: string option
        ///Unique identifier for the object.
        Id: string
        ///Additional information about an `individual` cardholder.
        Individual: IssuingCardholderIndividual option
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        ///The cardholder's name. This will be printed on cards issued to them.
        Name: string
        ///The cardholder's phone number.
        PhoneNumber: string option
        Requirements: IssuingCardholderRequirements
        ///Rules that control spending across this cardholder's cards. Refer to our [documentation](https://stripe.com/docs/issuing/controls/spending-controls) for more details.
        SpendingControls: IssuingCardholderAuthorizationControls option
        ///Specifies whether to permit authorizations on this cardholder's cards.
        Status: IssuingCardholderStatus
        ///One of `individual` or `company`.
        Type: IssuingCardholderType
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "issuing.cardholder"

        static member Create (billing: IssuingCardholderAddress, company: IssuingCardholderCompany option, created: DateTime, email: string option, id: string, individual: IssuingCardholderIndividual option, livemode: bool, metadata: Map<string, string>, name: string, phoneNumber: string option, requirements: IssuingCardholderRequirements, spendingControls: IssuingCardholderAuthorizationControls option, status: IssuingCardholderStatus, ``type``: IssuingCardholderType) =
            {
                IssuingCardholder.Billing = billing //required
                IssuingCardholder.Company = company //required
                IssuingCardholder.Created = created //required
                IssuingCardholder.Email = email //required
                IssuingCardholder.Id = id //required
                IssuingCardholder.Individual = individual //required
                IssuingCardholder.Livemode = livemode //required
                IssuingCardholder.Metadata = metadata //required
                IssuingCardholder.Name = name //required
                IssuingCardholder.PhoneNumber = phoneNumber //required
                IssuingCardholder.Requirements = requirements //required
                IssuingCardholder.SpendingControls = spendingControls //required
                IssuingCardholder.Status = status //required
                IssuingCardholder.Type = ``type`` //required
            }

    and IssuingCardholderStatus =
        | Active
        | Blocked
        | Inactive

    and IssuingCardholderType =
        | Company
        | Individual

    ///As a [card issuer](https://stripe.com/docs/issuing), you can dispute transactions that the cardholder does not recognize, suspects to be fraudulent, or has other issues with.
    ///Related guide: [Disputing Transactions](https://stripe.com/docs/issuing/purchases/disputes)
    and IssuingDispute = {
        ///Disputed amount. Usually the amount of the `disputed_transaction`, but can differ (usually because of currency fluctuation).
        Amount: int option
        ///List of balance transactions associated with the dispute.
        BalanceTransactions: BalanceTransaction list option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime option
        ///The currency the `disputed_transaction` was made in.
        Currency: string option
        Evidence: IssuingDisputeEvidence option
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        ///Current status of the dispute.
        Status: IssuingDisputeStatus option
        ///The transaction being disputed.
        [<JsonField(Transform=typeof<AnyOfTransform<IssuingDisputeTransaction'AnyOf>>)>]Transaction: IssuingDisputeTransaction'AnyOf
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "issuing.dispute"

        static member Create (balanceTransactions: BalanceTransaction list option, id: string, livemode: bool, transaction: IssuingDisputeTransaction'AnyOf, ?amount: int, ?created: DateTime, ?currency: string, ?evidence: IssuingDisputeEvidence, ?metadata: Map<string, string>, ?status: IssuingDisputeStatus) =
            {
                IssuingDispute.BalanceTransactions = balanceTransactions //required
                IssuingDispute.Id = id //required
                IssuingDispute.Livemode = livemode //required
                IssuingDispute.Transaction = transaction //required
                IssuingDispute.Amount = amount
                IssuingDispute.Created = created
                IssuingDispute.Currency = currency
                IssuingDispute.Evidence = evidence
                IssuingDispute.Metadata = metadata
                IssuingDispute.Status = status
            }

    and IssuingDisputeStatus =
        | Expired
        | Lost
        | Submitted
        | Unsubmitted
        | Won

    and IssuingDisputeTransaction'AnyOf =
        | String of string
        | IssuingTransaction of IssuingTransaction

    ///Any use of an [issued card](https://stripe.com/docs/issuing) that results in funds entering or leaving
    ///your Stripe account, such as a completed purchase or refund, is represented by an Issuing
    ///`Transaction` object.
    ///Related guide: [Issued Card Transactions](https://stripe.com/docs/issuing/purchases/transactions).
    and IssuingTransaction = {
        ///The transaction amount, which will be reflected in your balance. This amount is in your currency and in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal).
        Amount: int
        ///Detailed breakdown of amount components. These amounts are denominated in `currency` and in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal).
        AmountDetails: IssuingTransactionAmountDetails option
        ///The `Authorization` object that led to this transaction.
        [<JsonField(Transform=typeof<AnyOfTransform<IssuingTransactionAuthorization'AnyOf>>)>]Authorization: IssuingTransactionAuthorization'AnyOf option
        ///ID of the [balance transaction](https://stripe.com/docs/api/balance_transactions) associated with this transaction.
        [<JsonField(Transform=typeof<AnyOfTransform<IssuingTransactionBalanceTransaction'AnyOf>>)>]BalanceTransaction: IssuingTransactionBalanceTransaction'AnyOf option
        ///The card used to make this transaction.
        [<JsonField(Transform=typeof<AnyOfTransform<IssuingTransactionCard'AnyOf>>)>]Card: IssuingTransactionCard'AnyOf
        ///The cardholder to whom this transaction belongs.
        [<JsonField(Transform=typeof<AnyOfTransform<IssuingTransactionCardholder'AnyOf>>)>]Cardholder: IssuingTransactionCardholder'AnyOf option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///If you've disputed the transaction, the ID of the dispute.
        [<JsonField(Transform=typeof<AnyOfTransform<IssuingTransactionDispute'AnyOf>>)>]Dispute: IssuingTransactionDispute'AnyOf option
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///The amount that the merchant will receive, denominated in `merchant_currency` and in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal). It will be different from `amount` if the merchant is taking payment in a different currency.
        MerchantAmount: int
        ///The currency with which the merchant is taking payment.
        MerchantCurrency: string
        MerchantData: IssuingAuthorizationMerchantData
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        ///Additional purchase information that is optionally provided by the merchant.
        PurchaseDetails: IssuingTransactionPurchaseDetails option
        ///The nature of the transaction.
        Type: IssuingTransactionType
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "issuing.transaction"

        static member Create (amount: int, amountDetails: IssuingTransactionAmountDetails option, authorization: IssuingTransactionAuthorization'AnyOf option, balanceTransaction: IssuingTransactionBalanceTransaction'AnyOf option, card: IssuingTransactionCard'AnyOf, cardholder: IssuingTransactionCardholder'AnyOf option, created: DateTime, currency: string, id: string, livemode: bool, merchantAmount: int, merchantCurrency: string, merchantData: IssuingAuthorizationMerchantData, metadata: Map<string, string>, purchaseDetails: IssuingTransactionPurchaseDetails option, ``type``: IssuingTransactionType, ?dispute: IssuingTransactionDispute'AnyOf option) =
            {
                IssuingTransaction.Amount = amount //required
                IssuingTransaction.AmountDetails = amountDetails //required
                IssuingTransaction.Authorization = authorization //required
                IssuingTransaction.BalanceTransaction = balanceTransaction //required
                IssuingTransaction.Card = card //required
                IssuingTransaction.Cardholder = cardholder //required
                IssuingTransaction.Created = created //required
                IssuingTransaction.Currency = currency //required
                IssuingTransaction.Id = id //required
                IssuingTransaction.Livemode = livemode //required
                IssuingTransaction.MerchantAmount = merchantAmount //required
                IssuingTransaction.MerchantCurrency = merchantCurrency //required
                IssuingTransaction.MerchantData = merchantData //required
                IssuingTransaction.Metadata = metadata //required
                IssuingTransaction.PurchaseDetails = purchaseDetails //required
                IssuingTransaction.Type = ``type`` //required
                IssuingTransaction.Dispute = dispute |> Option.flatten
            }

    and IssuingTransactionAuthorization'AnyOf =
        | String of string
        | IssuingAuthorization of IssuingAuthorization

    and IssuingTransactionBalanceTransaction'AnyOf =
        | String of string
        | BalanceTransaction of BalanceTransaction

    and IssuingTransactionCard'AnyOf =
        | String of string
        | IssuingCard of IssuingCard

    and IssuingTransactionCardholder'AnyOf =
        | String of string
        | IssuingCardholder of IssuingCardholder

    and IssuingTransactionDispute'AnyOf =
        | String of string
        | IssuingDispute of IssuingDispute

    and IssuingTransactionType =
        | Capture
        | Dispute
        | Refund

    and IssuingAuthorizationAmountDetails = {
        ///The fee charged by the ATM for the cash withdrawal.
        AtmFee: int option
    }
    with

        static member Create (atmFee: int option) =
            {
                IssuingAuthorizationAmountDetails.AtmFee = atmFee //required
            }

    and IssuingAuthorizationMerchantData = {
        ///A categorization of the seller's type of business. See our [merchant categories guide](https://stripe.com/docs/issuing/merchant-categories) for a list of possible values.
        Category: string
        ///City where the seller is located
        City: string option
        ///Country where the seller is located
        Country: string option
        ///Name of the seller
        Name: string option
        ///Identifier assigned to the seller by the card brand
        NetworkId: string
        ///Postal code where the seller is located
        PostalCode: string option
        ///State where the seller is located
        State: string option
    }
    with

        static member Create (category: string, city: string option, country: string option, name: string option, networkId: string, postalCode: string option, state: string option) =
            {
                IssuingAuthorizationMerchantData.Category = category //required
                IssuingAuthorizationMerchantData.City = city //required
                IssuingAuthorizationMerchantData.Country = country //required
                IssuingAuthorizationMerchantData.Name = name //required
                IssuingAuthorizationMerchantData.NetworkId = networkId //required
                IssuingAuthorizationMerchantData.PostalCode = postalCode //required
                IssuingAuthorizationMerchantData.State = state //required
            }

    and IssuingAuthorizationPendingRequest = {
        ///The additional amount Stripe will hold if the authorization is approved, in the card's [currency](https://stripe.com/docs/api#issuing_authorization_object-pending-request-currency) and in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal).
        Amount: int
        ///Detailed breakdown of amount components. These amounts are denominated in `currency` and in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal).
        AmountDetails: IssuingAuthorizationAmountDetails option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///If set `true`, you may provide [amount](https://stripe.com/docs/api/issuing/authorizations/approve#approve_issuing_authorization-amount) to control how much to hold for the authorization.
        IsAmountControllable: bool
        ///The amount the merchant is requesting to be authorized in the `merchant_currency`. The amount is in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal).
        MerchantAmount: int
        ///The local currency the merchant is requesting to authorize.
        MerchantCurrency: string
    }
    with

        static member Create (amount: int, amountDetails: IssuingAuthorizationAmountDetails option, currency: string, isAmountControllable: bool, merchantAmount: int, merchantCurrency: string) =
            {
                IssuingAuthorizationPendingRequest.Amount = amount //required
                IssuingAuthorizationPendingRequest.AmountDetails = amountDetails //required
                IssuingAuthorizationPendingRequest.Currency = currency //required
                IssuingAuthorizationPendingRequest.IsAmountControllable = isAmountControllable //required
                IssuingAuthorizationPendingRequest.MerchantAmount = merchantAmount //required
                IssuingAuthorizationPendingRequest.MerchantCurrency = merchantCurrency //required
            }

    and IssuingAuthorizationRequest = {
        ///The authorization amount in your card's currency and in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal). Stripe held this amount from your account to fund the authorization if the request was approved.
        Amount: int
        ///Detailed breakdown of amount components. These amounts are denominated in `currency` and in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal).
        AmountDetails: IssuingAuthorizationAmountDetails option
        ///Whether this request was approved.
        Approved: bool
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///The amount that was authorized at the time of this request. This amount is in the `merchant_currency` and in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal).
        MerchantAmount: int
        ///The currency that was collected by the merchant and presented to the cardholder for the authorization. Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        MerchantCurrency: string
        ///The reason for the approval or decline.
        Reason: IssuingAuthorizationRequestReason
    }
    with

        static member Create (amount: int, amountDetails: IssuingAuthorizationAmountDetails option, approved: bool, created: DateTime, currency: string, merchantAmount: int, merchantCurrency: string, reason: IssuingAuthorizationRequestReason) =
            {
                IssuingAuthorizationRequest.Amount = amount //required
                IssuingAuthorizationRequest.AmountDetails = amountDetails //required
                IssuingAuthorizationRequest.Approved = approved //required
                IssuingAuthorizationRequest.Created = created //required
                IssuingAuthorizationRequest.Currency = currency //required
                IssuingAuthorizationRequest.MerchantAmount = merchantAmount //required
                IssuingAuthorizationRequest.MerchantCurrency = merchantCurrency //required
                IssuingAuthorizationRequest.Reason = reason //required
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

    and IssuingAuthorizationVerificationData = {
        ///Whether the cardholder provided an address first line and if it matched the cardholder’s `billing.address.line1`.
        [<JsonField(Name="address_line1_check")>]AddressLine1Check: IssuingAuthorizationVerificationDataAddressLine1Check
        ///Whether the cardholder provided a postal code and if it matched the cardholder’s `billing.address.postal_code`.
        AddressPostalCodeCheck: IssuingAuthorizationVerificationDataAddressPostalCodeCheck
        ///Whether the cardholder provided a CVC and if it matched Stripe’s record.
        CvcCheck: IssuingAuthorizationVerificationDataCvcCheck
        ///Whether the cardholder provided an expiry date and if it matched Stripe’s record.
        ExpiryCheck: IssuingAuthorizationVerificationDataExpiryCheck
    }
    with

        static member Create (addressLine1Check: IssuingAuthorizationVerificationDataAddressLine1Check, addressPostalCodeCheck: IssuingAuthorizationVerificationDataAddressPostalCodeCheck, cvcCheck: IssuingAuthorizationVerificationDataCvcCheck, expiryCheck: IssuingAuthorizationVerificationDataExpiryCheck) =
            {
                IssuingAuthorizationVerificationData.AddressLine1Check = addressLine1Check //required
                IssuingAuthorizationVerificationData.AddressPostalCodeCheck = addressPostalCodeCheck //required
                IssuingAuthorizationVerificationData.CvcCheck = cvcCheck //required
                IssuingAuthorizationVerificationData.ExpiryCheck = expiryCheck //required
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

    and IssuingCardAuthorizationControls = {
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) of authorizations to allow. All other categories will be blocked. Cannot be set with `blocked_categories`.
        AllowedCategories: IssuingCardAuthorizationControlsAllowedCategories list option
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) of authorizations to decline. All other categories will be allowed. Cannot be set with `allowed_categories`.
        BlockedCategories: IssuingCardAuthorizationControlsBlockedCategories list option
        ///Limit spending with amount-based rules.
        SpendingLimits: IssuingCardSpendingLimit list option
        ///Currency of the amounts within `spending_limits`. Always the same as the currency of the card.
        SpendingLimitsCurrency: string option
    }
    with

        static member Create (allowedCategories: IssuingCardAuthorizationControlsAllowedCategories list option, blockedCategories: IssuingCardAuthorizationControlsBlockedCategories list option, spendingLimits: IssuingCardSpendingLimit list option, spendingLimitsCurrency: string option) =
            {
                IssuingCardAuthorizationControls.AllowedCategories = allowedCategories //required
                IssuingCardAuthorizationControls.BlockedCategories = blockedCategories //required
                IssuingCardAuthorizationControls.SpendingLimits = spendingLimits //required
                IssuingCardAuthorizationControls.SpendingLimitsCurrency = spendingLimitsCurrency //required
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

    and IssuingCardShipping = {
        Address: Address
        ///The delivery company that shipped a card.
        Carrier: IssuingCardShippingCarrier option
        ///A unix timestamp representing a best estimate of when the card will be delivered.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Eta: DateTime option
        ///Recipient name.
        Name: string
        ///Shipment service, such as `standard` or `express`.
        Service: IssuingCardShippingService
        ///The delivery status of the card.
        Status: IssuingCardShippingStatus option
        ///A tracking number for a card shipment.
        TrackingNumber: string option
        ///A link to the shipping carrier's site where you can view detailed information about a card shipment.
        TrackingUrl: string option
        ///Packaging options.
        Type: IssuingCardShippingType
    }
    with

        static member Create (address: Address, carrier: IssuingCardShippingCarrier option, eta: DateTime option, name: string, service: IssuingCardShippingService, status: IssuingCardShippingStatus option, trackingNumber: string option, trackingUrl: string option, ``type``: IssuingCardShippingType) =
            {
                IssuingCardShipping.Address = address //required
                IssuingCardShipping.Carrier = carrier //required
                IssuingCardShipping.Eta = eta //required
                IssuingCardShipping.Name = name //required
                IssuingCardShipping.Service = service //required
                IssuingCardShipping.Status = status //required
                IssuingCardShipping.TrackingNumber = trackingNumber //required
                IssuingCardShipping.TrackingUrl = trackingUrl //required
                IssuingCardShipping.Type = ``type`` //required
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

    and IssuingCardSpendingLimit = {
        ///Maximum amount allowed to spend per interval.
        Amount: int
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) this limit applies to. Omitting this field will apply the limit to all categories.
        Categories: IssuingCardSpendingLimitCategories list option
        ///Interval (or event) to which the amount applies.
        Interval: IssuingCardSpendingLimitInterval
    }
    with

        static member Create (amount: int, categories: IssuingCardSpendingLimitCategories list option, interval: IssuingCardSpendingLimitInterval) =
            {
                IssuingCardSpendingLimit.Amount = amount //required
                IssuingCardSpendingLimit.Categories = categories //required
                IssuingCardSpendingLimit.Interval = interval //required
            }

    and IssuingCardSpendingLimitInterval =
        | AllTime
        | Daily
        | Monthly
        | PerAuthorization
        | Weekly
        | Yearly

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

    and IssuingCardholderAddress = {
        Address: Address
    }
    with

        static member Create (address: Address) =
            {
                IssuingCardholderAddress.Address = address //required
            }

    and IssuingCardholderAuthorizationControls = {
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) of authorizations to allow. All other categories will be blocked. Cannot be set with `blocked_categories`.
        AllowedCategories: IssuingCardholderAuthorizationControlsAllowedCategories list option
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) of authorizations to decline. All other categories will be allowed. Cannot be set with `allowed_categories`.
        BlockedCategories: IssuingCardholderAuthorizationControlsBlockedCategories list option
        ///Limit spending with amount-based rules that apply across this cardholder's cards.
        SpendingLimits: IssuingCardholderSpendingLimit list option
        ///Currency of the amounts within `spending_limits`.
        SpendingLimitsCurrency: string option
    }
    with

        static member Create (allowedCategories: IssuingCardholderAuthorizationControlsAllowedCategories list option, blockedCategories: IssuingCardholderAuthorizationControlsBlockedCategories list option, spendingLimits: IssuingCardholderSpendingLimit list option, spendingLimitsCurrency: string option) =
            {
                IssuingCardholderAuthorizationControls.AllowedCategories = allowedCategories //required
                IssuingCardholderAuthorizationControls.BlockedCategories = blockedCategories //required
                IssuingCardholderAuthorizationControls.SpendingLimits = spendingLimits //required
                IssuingCardholderAuthorizationControls.SpendingLimitsCurrency = spendingLimitsCurrency //required
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

    and IssuingCardholderCompany = {
        ///Whether the company's business ID number was provided.
        TaxIdProvided: bool
    }
    with

        static member Create (taxIdProvided: bool) =
            {
                IssuingCardholderCompany.TaxIdProvided = taxIdProvided //required
            }

    and IssuingCardholderIdDocument = {
        ///The back of a document returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`.
        [<JsonField(Transform=typeof<AnyOfTransform<IssuingCardholderIdDocumentBack'AnyOf>>)>]Back: IssuingCardholderIdDocumentBack'AnyOf option
        ///The front of a document returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`.
        [<JsonField(Transform=typeof<AnyOfTransform<IssuingCardholderIdDocumentFront'AnyOf>>)>]Front: IssuingCardholderIdDocumentFront'AnyOf option
    }
    with

        static member Create (back: IssuingCardholderIdDocumentBack'AnyOf option, front: IssuingCardholderIdDocumentFront'AnyOf option) =
            {
                IssuingCardholderIdDocument.Back = back //required
                IssuingCardholderIdDocument.Front = front //required
            }

    and IssuingCardholderIdDocumentBack'AnyOf =
        | String of string
        | File of File

    and IssuingCardholderIdDocumentFront'AnyOf =
        | String of string
        | File of File

    and IssuingCardholderIndividual = {
        ///The date of birth of this cardholder.
        Dob: IssuingCardholderIndividualDob option
        ///The first name of this cardholder.
        FirstName: string
        ///The last name of this cardholder.
        LastName: string
        ///Government-issued ID document for this cardholder.
        Verification: IssuingCardholderVerification option
    }
    with

        static member Create (dob: IssuingCardholderIndividualDob option, firstName: string, lastName: string, verification: IssuingCardholderVerification option) =
            {
                IssuingCardholderIndividual.Dob = dob //required
                IssuingCardholderIndividual.FirstName = firstName //required
                IssuingCardholderIndividual.LastName = lastName //required
                IssuingCardholderIndividual.Verification = verification //required
            }

    and IssuingCardholderIndividualDob = {
        ///The day of birth, between 1 and 31.
        Day: int option
        ///The month of birth, between 1 and 12.
        Month: int option
        ///The four-digit year of birth.
        Year: int option
    }
    with

        static member Create (day: int option, month: int option, year: int option) =
            {
                IssuingCardholderIndividualDob.Day = day //required
                IssuingCardholderIndividualDob.Month = month //required
                IssuingCardholderIndividualDob.Year = year //required
            }

    and IssuingCardholderRequirements = {
        ///If `disabled_reason` is present, all cards will decline authorizations with `cardholder_verification_required` reason.
        DisabledReason: IssuingCardholderRequirementsDisabledReason option
        ///Array of fields that need to be collected in order to verify and re-enable the cardholder.
        PastDue: IssuingCardholderRequirementsPastDue list option
    }
    with

        static member Create (disabledReason: IssuingCardholderRequirementsDisabledReason option, pastDue: IssuingCardholderRequirementsPastDue list option) =
            {
                IssuingCardholderRequirements.DisabledReason = disabledReason //required
                IssuingCardholderRequirements.PastDue = pastDue //required
            }

    and IssuingCardholderRequirementsDisabledReason =
        | Listed
        | [<JsonUnionCase("rejected.listed")>] RejectedListed
        | UnderReview

    and IssuingCardholderRequirementsPastDue =
        | [<JsonUnionCase("company.tax_id")>] CompanyTaxId
        | [<JsonUnionCase("individual.dob.day")>] IndividualDobDay
        | [<JsonUnionCase("individual.dob.month")>] IndividualDobMonth
        | [<JsonUnionCase("individual.dob.year")>] IndividualDobYear
        | [<JsonUnionCase("individual.first_name")>] IndividualFirstName
        | [<JsonUnionCase("individual.last_name")>] IndividualLastName
        | [<JsonUnionCase("individual.verification.document")>] IndividualVerificationDocument

    and IssuingCardholderSpendingLimit = {
        ///Maximum amount allowed to spend per interval.
        Amount: int
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) this limit applies to. Omitting this field will apply the limit to all categories.
        Categories: IssuingCardholderSpendingLimitCategories list option
        ///Interval (or event) to which the amount applies.
        Interval: IssuingCardholderSpendingLimitInterval
    }
    with

        static member Create (amount: int, categories: IssuingCardholderSpendingLimitCategories list option, interval: IssuingCardholderSpendingLimitInterval) =
            {
                IssuingCardholderSpendingLimit.Amount = amount //required
                IssuingCardholderSpendingLimit.Categories = categories //required
                IssuingCardholderSpendingLimit.Interval = interval //required
            }

    and IssuingCardholderSpendingLimitInterval =
        | AllTime
        | Daily
        | Monthly
        | PerAuthorization
        | Weekly
        | Yearly

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

    and IssuingCardholderVerification = {
        ///An identifying document, either a passport or local ID card.
        Document: IssuingCardholderIdDocument option
    }
    with

        static member Create (document: IssuingCardholderIdDocument option) =
            {
                IssuingCardholderVerification.Document = document //required
            }

    and IssuingDisputeCanceledEvidence = {
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        [<JsonField(Transform=typeof<AnyOfTransform<IssuingDisputeCanceledEvidenceAdditionalDocumentation'AnyOf>>)>]AdditionalDocumentation: IssuingDisputeCanceledEvidenceAdditionalDocumentation'AnyOf option
        ///Date when order was canceled.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]CanceledAt: DateTime option
        ///Whether the cardholder was provided with a cancellation policy.
        CancellationPolicyProvided: bool option
        ///Reason for canceling the order.
        CancellationReason: string option
        ///Date when the cardholder expected to receive the product.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]ExpectedAt: DateTime option
        ///Explanation of why the cardholder is disputing this transaction.
        Explanation: string option
        ///Description of the merchandise or service that was purchased.
        ProductDescription: string option
        ///Whether the product was a merchandise or service.
        ProductType: IssuingDisputeCanceledEvidenceProductType option
        ///Result of cardholder's attempt to return the product.
        ReturnStatus: IssuingDisputeCanceledEvidenceReturnStatus option
        ///Date when the product was returned or attempted to be returned.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]ReturnedAt: DateTime option
    }
    with

        static member Create (additionalDocumentation: IssuingDisputeCanceledEvidenceAdditionalDocumentation'AnyOf option, canceledAt: DateTime option, cancellationPolicyProvided: bool option, cancellationReason: string option, expectedAt: DateTime option, explanation: string option, productDescription: string option, productType: IssuingDisputeCanceledEvidenceProductType option, returnStatus: IssuingDisputeCanceledEvidenceReturnStatus option, returnedAt: DateTime option) =
            {
                IssuingDisputeCanceledEvidence.AdditionalDocumentation = additionalDocumentation //required
                IssuingDisputeCanceledEvidence.CanceledAt = canceledAt //required
                IssuingDisputeCanceledEvidence.CancellationPolicyProvided = cancellationPolicyProvided //required
                IssuingDisputeCanceledEvidence.CancellationReason = cancellationReason //required
                IssuingDisputeCanceledEvidence.ExpectedAt = expectedAt //required
                IssuingDisputeCanceledEvidence.Explanation = explanation //required
                IssuingDisputeCanceledEvidence.ProductDescription = productDescription //required
                IssuingDisputeCanceledEvidence.ProductType = productType //required
                IssuingDisputeCanceledEvidence.ReturnStatus = returnStatus //required
                IssuingDisputeCanceledEvidence.ReturnedAt = returnedAt //required
            }

    and IssuingDisputeCanceledEvidenceAdditionalDocumentation'AnyOf =
        | String of string
        | File of File

    and IssuingDisputeCanceledEvidenceProductType =
        | Merchandise
        | Service

    and IssuingDisputeCanceledEvidenceReturnStatus =
        | MerchantRejected
        | Successful

    and IssuingDisputeDuplicateEvidence = {
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        [<JsonField(Transform=typeof<AnyOfTransform<IssuingDisputeDuplicateEvidenceAdditionalDocumentation'AnyOf>>)>]AdditionalDocumentation: IssuingDisputeDuplicateEvidenceAdditionalDocumentation'AnyOf option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Copy of the card statement showing that the product had already been paid for.
        [<JsonField(Transform=typeof<AnyOfTransform<IssuingDisputeDuplicateEvidenceCardStatement'AnyOf>>)>]CardStatement: IssuingDisputeDuplicateEvidenceCardStatement'AnyOf option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Copy of the receipt showing that the product had been paid for in cash.
        [<JsonField(Transform=typeof<AnyOfTransform<IssuingDisputeDuplicateEvidenceCashReceipt'AnyOf>>)>]CashReceipt: IssuingDisputeDuplicateEvidenceCashReceipt'AnyOf option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Image of the front and back of the check that was used to pay for the product.
        [<JsonField(Transform=typeof<AnyOfTransform<IssuingDisputeDuplicateEvidenceCheckImage'AnyOf>>)>]CheckImage: IssuingDisputeDuplicateEvidenceCheckImage'AnyOf option
        ///Explanation of why the cardholder is disputing this transaction.
        Explanation: string option
        ///Transaction (e.g., ipi_...) that the disputed transaction is a duplicate of. Of the two or more transactions that are copies of each other, this is original undisputed one.
        OriginalTransaction: string option
    }
    with

        static member Create (additionalDocumentation: IssuingDisputeDuplicateEvidenceAdditionalDocumentation'AnyOf option, cardStatement: IssuingDisputeDuplicateEvidenceCardStatement'AnyOf option, cashReceipt: IssuingDisputeDuplicateEvidenceCashReceipt'AnyOf option, checkImage: IssuingDisputeDuplicateEvidenceCheckImage'AnyOf option, explanation: string option, originalTransaction: string option) =
            {
                IssuingDisputeDuplicateEvidence.AdditionalDocumentation = additionalDocumentation //required
                IssuingDisputeDuplicateEvidence.CardStatement = cardStatement //required
                IssuingDisputeDuplicateEvidence.CashReceipt = cashReceipt //required
                IssuingDisputeDuplicateEvidence.CheckImage = checkImage //required
                IssuingDisputeDuplicateEvidence.Explanation = explanation //required
                IssuingDisputeDuplicateEvidence.OriginalTransaction = originalTransaction //required
            }

    and IssuingDisputeDuplicateEvidenceAdditionalDocumentation'AnyOf =
        | String of string
        | File of File

    and IssuingDisputeDuplicateEvidenceCardStatement'AnyOf =
        | String of string
        | File of File

    and IssuingDisputeDuplicateEvidenceCashReceipt'AnyOf =
        | String of string
        | File of File

    and IssuingDisputeDuplicateEvidenceCheckImage'AnyOf =
        | String of string
        | File of File

    and IssuingDisputeEvidence = {
        Canceled: IssuingDisputeCanceledEvidence option
        Duplicate: IssuingDisputeDuplicateEvidence option
        Fraudulent: IssuingDisputeFraudulentEvidence option
        MerchandiseNotAsDescribed: IssuingDisputeMerchandiseNotAsDescribedEvidence option
        NotReceived: IssuingDisputeNotReceivedEvidence option
        Other: IssuingDisputeOtherEvidence option
        ///The reason for filing the dispute. Its value will match the field containing the evidence.
        Reason: IssuingDisputeEvidenceReason
        ServiceNotAsDescribed: IssuingDisputeServiceNotAsDescribedEvidence option
    }
    with

        static member Create (reason: IssuingDisputeEvidenceReason, ?canceled: IssuingDisputeCanceledEvidence, ?duplicate: IssuingDisputeDuplicateEvidence, ?fraudulent: IssuingDisputeFraudulentEvidence, ?merchandiseNotAsDescribed: IssuingDisputeMerchandiseNotAsDescribedEvidence, ?notReceived: IssuingDisputeNotReceivedEvidence, ?other: IssuingDisputeOtherEvidence, ?serviceNotAsDescribed: IssuingDisputeServiceNotAsDescribedEvidence) =
            {
                IssuingDisputeEvidence.Reason = reason //required
                IssuingDisputeEvidence.Canceled = canceled
                IssuingDisputeEvidence.Duplicate = duplicate
                IssuingDisputeEvidence.Fraudulent = fraudulent
                IssuingDisputeEvidence.MerchandiseNotAsDescribed = merchandiseNotAsDescribed
                IssuingDisputeEvidence.NotReceived = notReceived
                IssuingDisputeEvidence.Other = other
                IssuingDisputeEvidence.ServiceNotAsDescribed = serviceNotAsDescribed
            }

    and IssuingDisputeEvidenceReason =
        | Canceled
        | Duplicate
        | Fraudulent
        | MerchandiseNotAsDescribed
        | NotReceived
        | Other
        | ServiceNotAsDescribed

    and IssuingDisputeFraudulentEvidence = {
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        [<JsonField(Transform=typeof<AnyOfTransform<IssuingDisputeFraudulentEvidenceAdditionalDocumentation'AnyOf>>)>]AdditionalDocumentation: IssuingDisputeFraudulentEvidenceAdditionalDocumentation'AnyOf option
        ///Explanation of why the cardholder is disputing this transaction.
        Explanation: string option
    }
    with

        static member Create (additionalDocumentation: IssuingDisputeFraudulentEvidenceAdditionalDocumentation'AnyOf option, explanation: string option) =
            {
                IssuingDisputeFraudulentEvidence.AdditionalDocumentation = additionalDocumentation //required
                IssuingDisputeFraudulentEvidence.Explanation = explanation //required
            }

    and IssuingDisputeFraudulentEvidenceAdditionalDocumentation'AnyOf =
        | String of string
        | File of File

    and IssuingDisputeMerchandiseNotAsDescribedEvidence = {
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        [<JsonField(Transform=typeof<AnyOfTransform<IssuingDisputeMerchandiseNotAsDescribedEvidenceAdditionalDocumentation'AnyOf>>)>]AdditionalDocumentation: IssuingDisputeMerchandiseNotAsDescribedEvidenceAdditionalDocumentation'AnyOf option
        ///Explanation of why the cardholder is disputing this transaction.
        Explanation: string option
        ///Date when the product was received.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]ReceivedAt: DateTime option
        ///Description of the cardholder's attempt to return the product.
        ReturnDescription: string option
        ///Result of cardholder's attempt to return the product.
        ReturnStatus: IssuingDisputeMerchandiseNotAsDescribedEvidenceReturnStatus option
        ///Date when the product was returned or attempted to be returned.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]ReturnedAt: DateTime option
    }
    with

        static member Create (additionalDocumentation: IssuingDisputeMerchandiseNotAsDescribedEvidenceAdditionalDocumentation'AnyOf option, explanation: string option, receivedAt: DateTime option, returnDescription: string option, returnStatus: IssuingDisputeMerchandiseNotAsDescribedEvidenceReturnStatus option, returnedAt: DateTime option) =
            {
                IssuingDisputeMerchandiseNotAsDescribedEvidence.AdditionalDocumentation = additionalDocumentation //required
                IssuingDisputeMerchandiseNotAsDescribedEvidence.Explanation = explanation //required
                IssuingDisputeMerchandiseNotAsDescribedEvidence.ReceivedAt = receivedAt //required
                IssuingDisputeMerchandiseNotAsDescribedEvidence.ReturnDescription = returnDescription //required
                IssuingDisputeMerchandiseNotAsDescribedEvidence.ReturnStatus = returnStatus //required
                IssuingDisputeMerchandiseNotAsDescribedEvidence.ReturnedAt = returnedAt //required
            }

    and IssuingDisputeMerchandiseNotAsDescribedEvidenceAdditionalDocumentation'AnyOf =
        | String of string
        | File of File

    and IssuingDisputeMerchandiseNotAsDescribedEvidenceReturnStatus =
        | MerchantRejected
        | Successful

    and IssuingDisputeNotReceivedEvidence = {
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        [<JsonField(Transform=typeof<AnyOfTransform<IssuingDisputeNotReceivedEvidenceAdditionalDocumentation'AnyOf>>)>]AdditionalDocumentation: IssuingDisputeNotReceivedEvidenceAdditionalDocumentation'AnyOf option
        ///Date when the cardholder expected to receive the product.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]ExpectedAt: DateTime option
        ///Explanation of why the cardholder is disputing this transaction.
        Explanation: string option
        ///Description of the merchandise or service that was purchased.
        ProductDescription: string option
        ///Whether the product was a merchandise or service.
        ProductType: IssuingDisputeNotReceivedEvidenceProductType option
    }
    with

        static member Create (additionalDocumentation: IssuingDisputeNotReceivedEvidenceAdditionalDocumentation'AnyOf option, expectedAt: DateTime option, explanation: string option, productDescription: string option, productType: IssuingDisputeNotReceivedEvidenceProductType option) =
            {
                IssuingDisputeNotReceivedEvidence.AdditionalDocumentation = additionalDocumentation //required
                IssuingDisputeNotReceivedEvidence.ExpectedAt = expectedAt //required
                IssuingDisputeNotReceivedEvidence.Explanation = explanation //required
                IssuingDisputeNotReceivedEvidence.ProductDescription = productDescription //required
                IssuingDisputeNotReceivedEvidence.ProductType = productType //required
            }

    and IssuingDisputeNotReceivedEvidenceAdditionalDocumentation'AnyOf =
        | String of string
        | File of File

    and IssuingDisputeNotReceivedEvidenceProductType =
        | Merchandise
        | Service

    and IssuingDisputeOtherEvidence = {
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        [<JsonField(Transform=typeof<AnyOfTransform<IssuingDisputeOtherEvidenceAdditionalDocumentation'AnyOf>>)>]AdditionalDocumentation: IssuingDisputeOtherEvidenceAdditionalDocumentation'AnyOf option
        ///Explanation of why the cardholder is disputing this transaction.
        Explanation: string option
        ///Description of the merchandise or service that was purchased.
        ProductDescription: string option
        ///Whether the product was a merchandise or service.
        ProductType: IssuingDisputeOtherEvidenceProductType option
    }
    with

        static member Create (additionalDocumentation: IssuingDisputeOtherEvidenceAdditionalDocumentation'AnyOf option, explanation: string option, productDescription: string option, productType: IssuingDisputeOtherEvidenceProductType option) =
            {
                IssuingDisputeOtherEvidence.AdditionalDocumentation = additionalDocumentation //required
                IssuingDisputeOtherEvidence.Explanation = explanation //required
                IssuingDisputeOtherEvidence.ProductDescription = productDescription //required
                IssuingDisputeOtherEvidence.ProductType = productType //required
            }

    and IssuingDisputeOtherEvidenceAdditionalDocumentation'AnyOf =
        | String of string
        | File of File

    and IssuingDisputeOtherEvidenceProductType =
        | Merchandise
        | Service

    and IssuingDisputeServiceNotAsDescribedEvidence = {
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        [<JsonField(Transform=typeof<AnyOfTransform<IssuingDisputeServiceNotAsDescribedEvidenceAdditionalDocumentation'AnyOf>>)>]AdditionalDocumentation: IssuingDisputeServiceNotAsDescribedEvidenceAdditionalDocumentation'AnyOf option
        ///Date when order was canceled.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]CanceledAt: DateTime option
        ///Reason for canceling the order.
        CancellationReason: string option
        ///Explanation of why the cardholder is disputing this transaction.
        Explanation: string option
        ///Date when the product was received.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]ReceivedAt: DateTime option
    }
    with

        static member Create (additionalDocumentation: IssuingDisputeServiceNotAsDescribedEvidenceAdditionalDocumentation'AnyOf option, canceledAt: DateTime option, cancellationReason: string option, explanation: string option, receivedAt: DateTime option) =
            {
                IssuingDisputeServiceNotAsDescribedEvidence.AdditionalDocumentation = additionalDocumentation //required
                IssuingDisputeServiceNotAsDescribedEvidence.CanceledAt = canceledAt //required
                IssuingDisputeServiceNotAsDescribedEvidence.CancellationReason = cancellationReason //required
                IssuingDisputeServiceNotAsDescribedEvidence.Explanation = explanation //required
                IssuingDisputeServiceNotAsDescribedEvidence.ReceivedAt = receivedAt //required
            }

    and IssuingDisputeServiceNotAsDescribedEvidenceAdditionalDocumentation'AnyOf =
        | String of string
        | File of File

    and IssuingTransactionAmountDetails = {
        ///The fee charged by the ATM for the cash withdrawal.
        AtmFee: int option
    }
    with

        static member Create (atmFee: int option) =
            {
                IssuingTransactionAmountDetails.AtmFee = atmFee //required
            }

    and IssuingTransactionFlightData = {
        ///The time that the flight departed.
        DepartureAt: int option
        ///The name of the passenger.
        PassengerName: string option
        ///Whether the ticket is refundable.
        Refundable: bool option
        ///The legs of the trip.
        Segments: IssuingTransactionFlightDataLeg list option
        ///The travel agency that issued the ticket.
        TravelAgency: string option
    }
    with

        static member Create (departureAt: int option, passengerName: string option, refundable: bool option, segments: IssuingTransactionFlightDataLeg list option, travelAgency: string option) =
            {
                IssuingTransactionFlightData.DepartureAt = departureAt //required
                IssuingTransactionFlightData.PassengerName = passengerName //required
                IssuingTransactionFlightData.Refundable = refundable //required
                IssuingTransactionFlightData.Segments = segments //required
                IssuingTransactionFlightData.TravelAgency = travelAgency //required
            }

    and IssuingTransactionFlightDataLeg = {
        ///The three-letter IATA airport code of the flight's destination.
        ArrivalAirportCode: string option
        ///The airline carrier code.
        Carrier: string option
        ///The three-letter IATA airport code that the flight departed from.
        DepartureAirportCode: string option
        ///The flight number.
        FlightNumber: string option
        ///The flight's service class.
        ServiceClass: string option
        ///Whether a stopover is allowed on this flight.
        StopoverAllowed: bool option
    }
    with

        static member Create (arrivalAirportCode: string option, carrier: string option, departureAirportCode: string option, flightNumber: string option, serviceClass: string option, stopoverAllowed: bool option) =
            {
                IssuingTransactionFlightDataLeg.ArrivalAirportCode = arrivalAirportCode //required
                IssuingTransactionFlightDataLeg.Carrier = carrier //required
                IssuingTransactionFlightDataLeg.DepartureAirportCode = departureAirportCode //required
                IssuingTransactionFlightDataLeg.FlightNumber = flightNumber //required
                IssuingTransactionFlightDataLeg.ServiceClass = serviceClass //required
                IssuingTransactionFlightDataLeg.StopoverAllowed = stopoverAllowed //required
            }

    and IssuingTransactionFuelData = {
        ///The type of fuel that was purchased. One of `diesel`, `unleaded_plus`, `unleaded_regular`, `unleaded_super`, or `other`.
        Type: IssuingTransactionFuelDataType
        ///The units for `volume_decimal`. One of `us_gallon` or `liter`.
        Unit: IssuingTransactionFuelDataUnit
        ///The cost in cents per each unit of fuel, represented as a decimal string with at most 12 decimal places.
        UnitCostDecimal: string
        ///The volume of the fuel that was pumped, represented as a decimal string with at most 12 decimal places.
        VolumeDecimal: string option
    }
    with

        static member Create (``type``: IssuingTransactionFuelDataType, unit: IssuingTransactionFuelDataUnit, unitCostDecimal: string, volumeDecimal: string option) =
            {
                IssuingTransactionFuelData.Type = ``type`` //required
                IssuingTransactionFuelData.Unit = unit //required
                IssuingTransactionFuelData.UnitCostDecimal = unitCostDecimal //required
                IssuingTransactionFuelData.VolumeDecimal = volumeDecimal //required
            }

    and IssuingTransactionFuelDataType =
        | Diesel
        | UnleadedPlus
        | UnleadedRegular
        | UnleadedSuper
        | Other

    and IssuingTransactionFuelDataUnit =
        | UsGallon
        | Liter

    and IssuingTransactionLodgingData = {
        ///The time of checking into the lodging.
        CheckInAt: int option
        ///The number of nights stayed at the lodging.
        Nights: int option
    }
    with

        static member Create (checkInAt: int option, nights: int option) =
            {
                IssuingTransactionLodgingData.CheckInAt = checkInAt //required
                IssuingTransactionLodgingData.Nights = nights //required
            }

    and IssuingTransactionPurchaseDetails = {
        ///Information about the flight that was purchased with this transaction.
        Flight: IssuingTransactionFlightData option
        ///Information about fuel that was purchased with this transaction.
        Fuel: IssuingTransactionFuelData option
        ///Information about lodging that was purchased with this transaction.
        Lodging: IssuingTransactionLodgingData option
        ///The line items in the purchase.
        Receipt: IssuingTransactionReceiptData list option
        ///A merchant-specific order number.
        Reference: string option
    }
    with

        static member Create (flight: IssuingTransactionFlightData option, fuel: IssuingTransactionFuelData option, lodging: IssuingTransactionLodgingData option, receipt: IssuingTransactionReceiptData list option, reference: string option) =
            {
                IssuingTransactionPurchaseDetails.Flight = flight //required
                IssuingTransactionPurchaseDetails.Fuel = fuel //required
                IssuingTransactionPurchaseDetails.Lodging = lodging //required
                IssuingTransactionPurchaseDetails.Receipt = receipt //required
                IssuingTransactionPurchaseDetails.Reference = reference //required
            }

    and IssuingTransactionReceiptData = {
        ///The description of the item. The maximum length of this field is 26 characters.
        Description: string option
        ///The quantity of the item.
        Quantity: decimal option
        ///The total for this line item in cents.
        Total: int option
        ///The unit cost of the item in cents.
        UnitCost: int option
    }
    with

        static member Create (description: string option, quantity: decimal option, total: int option, unitCost: int option) =
            {
                IssuingTransactionReceiptData.Description = description //required
                IssuingTransactionReceiptData.Quantity = quantity //required
                IssuingTransactionReceiptData.Total = total //required
                IssuingTransactionReceiptData.UnitCost = unitCost //required
            }

    ///A line item.
    and Item = {
        ///Total before any discounts or taxes is applied.
        AmountSubtotal: int option
        ///Total after discounts and taxes.
        AmountTotal: int option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///An arbitrary string attached to the object. Often useful for displaying to users. Defaults to product name.
        Description: string
        ///The discounts applied to the line item.
        Discounts: LineItemsDiscountAmount list option
        ///Unique identifier for the object.
        Id: string
        Price: Price
        ///The quantity of products being purchased.
        Quantity: int option
        ///The taxes applied to the line item.
        Taxes: LineItemsTaxAmount list option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "item"

        static member Create (amountSubtotal: int option, amountTotal: int option, currency: string, description: string, id: string, price: Price, quantity: int option, ?discounts: LineItemsDiscountAmount list, ?taxes: LineItemsTaxAmount list) =
            {
                Item.AmountSubtotal = amountSubtotal //required
                Item.AmountTotal = amountTotal //required
                Item.Currency = currency //required
                Item.Description = description //required
                Item.Id = id //required
                Item.Price = price //required
                Item.Quantity = quantity //required
                Item.Discounts = discounts
                Item.Taxes = taxes
            }

    and LegalEntityCompany = {
        Address: Address option
        ///The Kana variation of the company's primary address (Japan only).
        AddressKana: LegalEntityJapanAddress option
        ///The Kanji variation of the company's primary address (Japan only).
        AddressKanji: LegalEntityJapanAddress option
        ///Whether the company's directors have been provided. This Boolean will be `true` if you've manually indicated that all directors are provided via [the `directors_provided` parameter](https://stripe.com/docs/api/accounts/update#update_account-company-directors_provided).
        DirectorsProvided: bool option
        ///Whether the company's executives have been provided. This Boolean will be `true` if you've manually indicated that all executives are provided via [the `executives_provided` parameter](https://stripe.com/docs/api/accounts/update#update_account-company-executives_provided), or if Stripe determined that sufficient executives were provided.
        ExecutivesProvided: bool option
        ///The company's legal name.
        Name: string option
        ///The Kana variation of the company's legal name (Japan only).
        NameKana: string option
        ///The Kanji variation of the company's legal name (Japan only).
        NameKanji: string option
        ///Whether the company's owners have been provided. This Boolean will be `true` if you've manually indicated that all owners are provided via [the `owners_provided` parameter](https://stripe.com/docs/api/accounts/update#update_account-company-owners_provided), or if Stripe determined that sufficient owners were provided. Stripe determines ownership requirements using both the number of owners provided and their total percent ownership (calculated by adding the `percent_ownership` of each owner together).
        OwnersProvided: bool option
        ///The company's phone number (used for verification).
        Phone: string option
        ///The category identifying the legal structure of the company or legal entity. See [Business structure](https://stripe.com/docs/connect/identity-verification#business-structure) for more details.
        Structure: LegalEntityCompanyStructure option
        ///Whether the company's business ID number was provided.
        TaxIdProvided: bool option
        ///The jurisdiction in which the `tax_id` is registered (Germany-based companies only).
        TaxIdRegistrar: string option
        ///Whether the company's business VAT number was provided.
        VatIdProvided: bool option
        ///Information on the verification state of the company.
        Verification: LegalEntityCompanyVerification option
    }
    with

        static member Create (name: string option, ?address: Address, ?addressKana: LegalEntityJapanAddress option, ?addressKanji: LegalEntityJapanAddress option, ?directorsProvided: bool, ?executivesProvided: bool, ?nameKana: string option, ?nameKanji: string option, ?ownersProvided: bool, ?phone: string option, ?structure: LegalEntityCompanyStructure, ?taxIdProvided: bool, ?taxIdRegistrar: string, ?vatIdProvided: bool, ?verification: LegalEntityCompanyVerification option) =
            {
                LegalEntityCompany.Name = name //required
                LegalEntityCompany.Address = address
                LegalEntityCompany.AddressKana = addressKana |> Option.flatten
                LegalEntityCompany.AddressKanji = addressKanji |> Option.flatten
                LegalEntityCompany.DirectorsProvided = directorsProvided
                LegalEntityCompany.ExecutivesProvided = executivesProvided
                LegalEntityCompany.NameKana = nameKana |> Option.flatten
                LegalEntityCompany.NameKanji = nameKanji |> Option.flatten
                LegalEntityCompany.OwnersProvided = ownersProvided
                LegalEntityCompany.Phone = phone |> Option.flatten
                LegalEntityCompany.Structure = structure
                LegalEntityCompany.TaxIdProvided = taxIdProvided
                LegalEntityCompany.TaxIdRegistrar = taxIdRegistrar
                LegalEntityCompany.VatIdProvided = vatIdProvided
                LegalEntityCompany.Verification = verification |> Option.flatten
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

    and LegalEntityCompanyVerification = {
        Document: LegalEntityCompanyVerificationDocument
    }
    with

        static member Create (document: LegalEntityCompanyVerificationDocument) =
            {
                LegalEntityCompanyVerification.Document = document //required
            }

    and LegalEntityCompanyVerificationDocument = {
        ///The back of a document returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `additional_verification`.
        [<JsonField(Transform=typeof<AnyOfTransform<LegalEntityCompanyVerificationDocumentBack'AnyOf>>)>]Back: LegalEntityCompanyVerificationDocumentBack'AnyOf option
        ///A user-displayable string describing the verification state of this document.
        Details: string option
        ///One of `document_corrupt`, `document_expired`, `document_failed_copy`, `document_failed_greyscale`, `document_failed_other`, `document_failed_test_mode`, `document_fraudulent`, `document_incomplete`, `document_invalid`, `document_manipulated`, `document_not_readable`, `document_not_uploaded`, `document_type_not_supported`, or `document_too_large`. A machine-readable code specifying the verification state for this document.
        DetailsCode: LegalEntityCompanyVerificationDocumentDetailsCode option
        ///The front of a document returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `additional_verification`.
        [<JsonField(Transform=typeof<AnyOfTransform<LegalEntityCompanyVerificationDocumentFront'AnyOf>>)>]Front: LegalEntityCompanyVerificationDocumentFront'AnyOf option
    }
    with

        static member Create (back: LegalEntityCompanyVerificationDocumentBack'AnyOf option, details: string option, detailsCode: LegalEntityCompanyVerificationDocumentDetailsCode option, front: LegalEntityCompanyVerificationDocumentFront'AnyOf option) =
            {
                LegalEntityCompanyVerificationDocument.Back = back //required
                LegalEntityCompanyVerificationDocument.Details = details //required
                LegalEntityCompanyVerificationDocument.DetailsCode = detailsCode //required
                LegalEntityCompanyVerificationDocument.Front = front //required
            }

    and LegalEntityCompanyVerificationDocumentBack'AnyOf =
        | String of string
        | File of File

    and LegalEntityCompanyVerificationDocumentDetailsCode =
        | DocumentCorrupt
        | DocumentExpired
        | DocumentFailedCopy
        | DocumentFailedGreyscale
        | DocumentFailedOther
        | DocumentFailedTestMode
        | DocumentFraudulent
        | DocumentIncomplete
        | DocumentInvalid
        | DocumentManipulated
        | DocumentNotReadable
        | DocumentNotUploaded
        | DocumentTypeNotSupported
        | DocumentTooLarge

    and LegalEntityCompanyVerificationDocumentFront'AnyOf =
        | String of string
        | File of File

    and LegalEntityDob = {
        ///The day of birth, between 1 and 31.
        Day: int option
        ///The month of birth, between 1 and 12.
        Month: int option
        ///The four-digit year of birth.
        Year: int option
    }
    with

        static member Create (day: int option, month: int option, year: int option) =
            {
                LegalEntityDob.Day = day //required
                LegalEntityDob.Month = month //required
                LegalEntityDob.Year = year //required
            }

    and LegalEntityJapanAddress = {
        ///City/Ward.
        City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        Country: string option
        ///Block/Building number.
        [<JsonField(Name="line1")>]Line1: string option
        ///Building details.
        [<JsonField(Name="line2")>]Line2: string option
        ///ZIP or postal code.
        PostalCode: string option
        ///Prefecture.
        State: string option
        ///Town/cho-me.
        Town: string option
    }
    with

        static member Create (city: string option, country: string option, line1: string option, line2: string option, postalCode: string option, state: string option, town: string option) =
            {
                LegalEntityJapanAddress.City = city //required
                LegalEntityJapanAddress.Country = country //required
                LegalEntityJapanAddress.Line1 = line1 //required
                LegalEntityJapanAddress.Line2 = line2 //required
                LegalEntityJapanAddress.PostalCode = postalCode //required
                LegalEntityJapanAddress.State = state //required
                LegalEntityJapanAddress.Town = town //required
            }

    and LegalEntityPersonVerification = {
        ///A document showing address, either a passport, local ID card, or utility bill from a well-known utility company.
        AdditionalDocument: LegalEntityPersonVerificationDocument option
        ///A user-displayable string describing the verification state for the person. For example, this may say "Provided identity information could not be verified".
        Details: string option
        ///One of `document_address_mismatch`, `document_dob_mismatch`, `document_duplicate_type`, `document_id_number_mismatch`, `document_name_mismatch`, `document_nationality_mismatch`, `failed_keyed_identity`, or `failed_other`. A machine-readable code specifying the verification state for the person.
        DetailsCode: LegalEntityPersonVerificationDetailsCode option
        Document: LegalEntityPersonVerificationDocument option
        ///The state of verification for the person. Possible values are `unverified`, `pending`, or `verified`.
        Status: LegalEntityPersonVerificationStatus
    }
    with

        static member Create (status: LegalEntityPersonVerificationStatus, ?additionalDocument: LegalEntityPersonVerificationDocument option, ?details: string option, ?detailsCode: LegalEntityPersonVerificationDetailsCode option, ?document: LegalEntityPersonVerificationDocument) =
            {
                LegalEntityPersonVerification.Status = status //required
                LegalEntityPersonVerification.AdditionalDocument = additionalDocument |> Option.flatten
                LegalEntityPersonVerification.Details = details |> Option.flatten
                LegalEntityPersonVerification.DetailsCode = detailsCode |> Option.flatten
                LegalEntityPersonVerification.Document = document
            }

    and LegalEntityPersonVerificationDetailsCode =
        | DocumentAddressMismatch
        | DocumentDobMismatch
        | DocumentDuplicateType
        | DocumentIdNumberMismatch
        | DocumentNameMismatch
        | DocumentNationalityMismatch
        | FailedKeyedIdentity
        | FailedOther

    and LegalEntityPersonVerificationStatus =
        | Unverified
        | Pending
        | Verified

    and LegalEntityPersonVerificationDocument = {
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`.
        [<JsonField(Transform=typeof<AnyOfTransform<LegalEntityPersonVerificationDocumentBack'AnyOf>>)>]Back: LegalEntityPersonVerificationDocumentBack'AnyOf option
        ///A user-displayable string describing the verification state of this document. For example, if a document is uploaded and the picture is too fuzzy, this may say "Identity document is too unclear to read".
        Details: string option
        ///One of `document_corrupt`, `document_country_not_supported`, `document_expired`, `document_failed_copy`, `document_failed_other`, `document_failed_test_mode`, `document_fraudulent`, `document_failed_greyscale`, `document_incomplete`, `document_invalid`, `document_manipulated`, `document_missing_back`, `document_missing_front`, `document_not_readable`, `document_not_uploaded`, `document_photo_mismatch`, `document_too_large`, or `document_type_not_supported`. A machine-readable code specifying the verification state for this document.
        DetailsCode: LegalEntityPersonVerificationDocumentDetailsCode option
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`.
        [<JsonField(Transform=typeof<AnyOfTransform<LegalEntityPersonVerificationDocumentFront'AnyOf>>)>]Front: LegalEntityPersonVerificationDocumentFront'AnyOf option
    }
    with

        static member Create (back: LegalEntityPersonVerificationDocumentBack'AnyOf option, details: string option, detailsCode: LegalEntityPersonVerificationDocumentDetailsCode option, front: LegalEntityPersonVerificationDocumentFront'AnyOf option) =
            {
                LegalEntityPersonVerificationDocument.Back = back //required
                LegalEntityPersonVerificationDocument.Details = details //required
                LegalEntityPersonVerificationDocument.DetailsCode = detailsCode //required
                LegalEntityPersonVerificationDocument.Front = front //required
            }

    and LegalEntityPersonVerificationDocumentBack'AnyOf =
        | String of string
        | File of File

    and LegalEntityPersonVerificationDocumentDetailsCode =
        | DocumentCorrupt
        | DocumentCountryNotSupported
        | DocumentExpired
        | DocumentFailedCopy
        | DocumentFailedOther
        | DocumentFailedTestMode
        | DocumentFraudulent
        | DocumentFailedGreyscale
        | DocumentIncomplete
        | DocumentInvalid
        | DocumentManipulated
        | DocumentMissingBack
        | DocumentMissingFront
        | DocumentNotReadable
        | DocumentNotUploaded
        | DocumentPhotoMismatch
        | DocumentTooLarge
        | DocumentTypeNotSupported

    and LegalEntityPersonVerificationDocumentFront'AnyOf =
        | String of string
        | File of File

    and Level3 = {
        CustomerReference: string option
        LineItems: Level3LineItems list
        MerchantReference: string
        ShippingAddressZip: string option
        ShippingAmount: int option
        ShippingFromZip: string option
    }
    with

        static member Create (lineItems: Level3LineItems list, merchantReference: string, ?customerReference: string, ?shippingAddressZip: string, ?shippingAmount: int, ?shippingFromZip: string) =
            {
                Level3.LineItems = lineItems //required
                Level3.MerchantReference = merchantReference //required
                Level3.CustomerReference = customerReference
                Level3.ShippingAddressZip = shippingAddressZip
                Level3.ShippingAmount = shippingAmount
                Level3.ShippingFromZip = shippingFromZip
            }

    and Level3LineItems = {
        DiscountAmount: int option
        ProductCode: string
        ProductDescription: string
        Quantity: int option
        TaxAmount: int option
        UnitCost: int option
    }
    with

        static member Create (discountAmount: int option, productCode: string, productDescription: string, quantity: int option, taxAmount: int option, unitCost: int option) =
            {
                Level3LineItems.DiscountAmount = discountAmount //required
                Level3LineItems.ProductCode = productCode //required
                Level3LineItems.ProductDescription = productDescription //required
                Level3LineItems.Quantity = quantity //required
                Level3LineItems.TaxAmount = taxAmount //required
                Level3LineItems.UnitCost = unitCost //required
            }

    and LineItem = {
        ///The amount, in %s.
        Amount: int
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        ///The amount of discount calculated per discount for this line item.
        DiscountAmounts: DiscountsResourceDiscountAmount list option
        ///If true, discounts will apply to this line item. Always false for prorations.
        Discountable: bool
        ///The discounts applied to the invoice line item. Line item discounts are applied before invoice discounts. Use `expand[]=discounts` to expand each discount.
        Discounts: LineItemDiscounts'AnyOf list option
        ///Unique identifier for the object.
        Id: string
        ///The ID of the [invoice item](https://stripe.com/docs/api/invoiceitems) associated with this line item if any.
        InvoiceItem: string option
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Note that for line items with `type=subscription` this will reflect the metadata of the subscription that caused the line item to be created.
        Metadata: Map<string, string>
        Period: InvoiceLineItemPeriod
        ///The plan of the subscription, if the line item is a subscription or a proration.
        Plan: Plan option
        ///The price of the line item.
        Price: Price option
        ///Whether this is a proration.
        Proration: bool
        ///The quantity of the subscription, if the line item is a subscription or a proration.
        Quantity: int option
        ///The subscription that the invoice item pertains to, if any.
        Subscription: string option
        ///The subscription item that generated this invoice item. Left empty if the line item is not an explicit result of a subscription.
        SubscriptionItem: string option
        ///The amount of tax calculated per tax rate for this line item
        TaxAmounts: InvoiceTaxAmount list option
        ///The tax rates which apply to the line item.
        TaxRates: TaxRate list option
        ///A string identifying the type of the source of this line item, either an `invoiceitem` or a `subscription`.
        Type: LineItemType
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "line_item"

        static member Create (amount: int, currency: string, description: string option, discountAmounts: DiscountsResourceDiscountAmount list option, discountable: bool, discounts: LineItemDiscounts'AnyOf list option, id: string, livemode: bool, metadata: Map<string, string>, period: InvoiceLineItemPeriod, plan: Plan option, price: Price option, proration: bool, quantity: int option, subscription: string option, ``type``: LineItemType, ?invoiceItem: string, ?subscriptionItem: string, ?taxAmounts: InvoiceTaxAmount list, ?taxRates: TaxRate list) =
            {
                LineItem.Amount = amount //required
                LineItem.Currency = currency //required
                LineItem.Description = description //required
                LineItem.DiscountAmounts = discountAmounts //required
                LineItem.Discountable = discountable //required
                LineItem.Discounts = discounts //required
                LineItem.Id = id //required
                LineItem.Livemode = livemode //required
                LineItem.Metadata = metadata //required
                LineItem.Period = period //required
                LineItem.Plan = plan //required
                LineItem.Price = price //required
                LineItem.Proration = proration //required
                LineItem.Quantity = quantity //required
                LineItem.Subscription = subscription //required
                LineItem.Type = ``type`` //required
                LineItem.InvoiceItem = invoiceItem
                LineItem.SubscriptionItem = subscriptionItem
                LineItem.TaxAmounts = taxAmounts
                LineItem.TaxRates = taxRates
            }

    and LineItemType =
        | Invoiceitem
        | Subscription

    and LineItemDiscounts'AnyOf =
        | String of string
        | Discount of Discount

    and LineItemsDiscountAmount = {
        ///The amount discounted.
        Amount: int
        Discount: Discount
    }
    with

        static member Create (amount: int, discount: Discount) =
            {
                LineItemsDiscountAmount.Amount = amount //required
                LineItemsDiscountAmount.Discount = discount //required
            }

    and LineItemsTaxAmount = {
        ///Amount of tax applied for this rate.
        Amount: int
        Rate: TaxRate
    }
    with

        static member Create (amount: int, rate: TaxRate) =
            {
                LineItemsTaxAmount.Amount = amount //required
                LineItemsTaxAmount.Rate = rate //required
            }

    and LoginLink = {
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///The URL for the login link.
        Url: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "login_link"

        static member Create (created: DateTime, url: string) =
            {
                LoginLink.Created = created //required
                LoginLink.Url = url //required
            }

    ///A Mandate is a record of the permission a customer has given you to debit their payment method.
    and Mandate = {
        CustomerAcceptance: CustomerAcceptance
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        MultiUse: MandateMultiUse option
        ///ID of the payment method associated with this mandate.
        [<JsonField(Transform=typeof<AnyOfTransform<MandatePaymentMethod'AnyOf>>)>]PaymentMethod: MandatePaymentMethod'AnyOf
        PaymentMethodDetails: MandatePaymentMethodDetails
        SingleUse: MandateSingleUse option
        ///The status of the mandate, which indicates whether it can be used to initiate a payment.
        Status: MandateStatus
        ///The type of the mandate.
        Type: MandateType
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "mandate"

        static member Create (customerAcceptance: CustomerAcceptance, id: string, livemode: bool, paymentMethod: MandatePaymentMethod'AnyOf, paymentMethodDetails: MandatePaymentMethodDetails, status: MandateStatus, ``type``: MandateType, ?multiUse: MandateMultiUse, ?singleUse: MandateSingleUse) =
            {
                Mandate.CustomerAcceptance = customerAcceptance //required
                Mandate.Id = id //required
                Mandate.Livemode = livemode //required
                Mandate.PaymentMethod = paymentMethod //required
                Mandate.PaymentMethodDetails = paymentMethodDetails //required
                Mandate.Status = status //required
                Mandate.Type = ``type`` //required
                Mandate.MultiUse = multiUse
                Mandate.SingleUse = singleUse
            }

    and MandatePaymentMethod'AnyOf =
        | String of string
        | PaymentMethod of PaymentMethod

    and MandateStatus =
        | Active
        | Inactive
        | Pending

    and MandateType =
        | MultiUse
        | SingleUse

    and MandateAuBecsDebit = {
        ///The URL of the mandate. This URL generally contains sensitive information about the customer and should be shared with them exclusively.
        Url: string
    }
    with

        static member Create (url: string) =
            {
                MandateAuBecsDebit.Url = url //required
            }

    and MandateBacsDebit = {
        ///The status of the mandate on the Bacs network. Can be one of `pending`, `revoked`, `refused`, or `accepted`.
        NetworkStatus: MandateBacsDebitNetworkStatus
        ///The unique reference identifying the mandate on the Bacs network.
        Reference: string
        ///The URL that will contain the mandate that the customer has signed.
        Url: string
    }
    with

        static member Create (networkStatus: MandateBacsDebitNetworkStatus, reference: string, url: string) =
            {
                MandateBacsDebit.NetworkStatus = networkStatus //required
                MandateBacsDebit.Reference = reference //required
                MandateBacsDebit.Url = url //required
            }

    and MandateBacsDebitNetworkStatus =
        | Accepted
        | Pending
        | Refused
        | Revoked

    and MandateMultiUse = {
        MandateMultiUse: string option
    }
    with

        static member Create (?mandateMultiUse: string option) =
            {
                MandateMultiUse.MandateMultiUse = mandateMultiUse |> Option.flatten
            }

    and MandatePaymentMethodDetails = {
        AuBecsDebit: MandateAuBecsDebit option
        BacsDebit: MandateBacsDebit option
        Card: CardMandatePaymentMethodDetails option
        SepaDebit: MandateSepaDebit option
        ///The type of the payment method associated with this mandate. An additional hash is included on `payment_method_details` with a name matching this value. It contains mandate information specific to the payment method.
        Type: string
    }
    with

        static member Create (``type``: string, ?auBecsDebit: MandateAuBecsDebit, ?bacsDebit: MandateBacsDebit, ?card: CardMandatePaymentMethodDetails, ?sepaDebit: MandateSepaDebit) =
            {
                MandatePaymentMethodDetails.Type = ``type`` //required
                MandatePaymentMethodDetails.AuBecsDebit = auBecsDebit
                MandatePaymentMethodDetails.BacsDebit = bacsDebit
                MandatePaymentMethodDetails.Card = card
                MandatePaymentMethodDetails.SepaDebit = sepaDebit
            }

    and MandateSepaDebit = {
        ///The unique reference of the mandate.
        Reference: string
        ///The URL of the mandate. This URL generally contains sensitive information about the customer and should be shared with them exclusively.
        Url: string
    }
    with

        static member Create (reference: string, url: string) =
            {
                MandateSepaDebit.Reference = reference //required
                MandateSepaDebit.Url = url //required
            }

    and MandateSingleUse = {
        ///On a single use mandate, the amount of the payment.
        Amount: int
        ///On a single use mandate, the currency of the payment.
        Currency: string
    }
    with

        static member Create (amount: int, currency: string) =
            {
                MandateSingleUse.Amount = amount //required
                MandateSingleUse.Currency = currency //required
            }

    and Networks = {
        ///All available networks for the card.
        Available: string list
        ///The preferred network for the card.
        Preferred: string option
    }
    with

        static member Create (available: string list, preferred: string option) =
            {
                Networks.Available = available //required
                Networks.Preferred = preferred //required
            }

    and NotificationEventData = {
        ///Object containing the API resource relevant to the event. For example, an `invoice.created` event will have a full [invoice object](https://stripe.com/docs/api#invoice_object) as the value of the object key.
        Object: obj
        ///Object containing the names of the attributes that have changed, and their previous values (sent along only with *.updated events).
        PreviousAttributes: obj option
    }
    with

        static member Create (object: obj, ?previousAttributes: obj) =
            {
                NotificationEventData.Object = object //required
                NotificationEventData.PreviousAttributes = previousAttributes
            }

    and NotificationEventRequest = {
        ///ID of the API request that caused the event. If null, the event was automatic (e.g., Stripe's automatic subscription handling). Request logs are available in the [dashboard](https://dashboard.stripe.com/logs), but currently not in the API.
        Id: string option
        ///The idempotency key transmitted during the request, if any. *Note: This property is populated only for events on or after May 23, 2017*.
        IdempotencyKey: string option
    }
    with

        static member Create (id: string option, idempotencyKey: string option) =
            {
                NotificationEventRequest.Id = id //required
                NotificationEventRequest.IdempotencyKey = idempotencyKey //required
            }

    and OfflineAcceptance = {
        OfflineAcceptance: string option
    }
    with

        static member Create (?offlineAcceptance: string option) =
            {
                OfflineAcceptance.OfflineAcceptance = offlineAcceptance |> Option.flatten
            }

    and OnlineAcceptance = {
        ///The IP address from which the Mandate was accepted by the customer.
        IpAddress: string option
        ///The user agent of the browser from which the Mandate was accepted by the customer.
        UserAgent: string option
    }
    with

        static member Create (ipAddress: string option, userAgent: string option) =
            {
                OnlineAcceptance.IpAddress = ipAddress //required
                OnlineAcceptance.UserAgent = userAgent //required
            }

    ///Order objects are created to handle end customers' purchases of previously
    ///defined [products](https://stripe.com/docs/api#products). You can create, retrieve, and pay individual orders, as well
    ///as list all orders. Orders are identified by a unique, random ID.
    ///Related guide: [Tax, Shipping, and Inventory](https://stripe.com/docs/orders).
    and Order = {
        ///A positive integer in the smallest currency unit (that is, 100 cents for $1.00, or 1 for ¥1, Japanese Yen being a zero-decimal currency) representing the total amount for the order.
        Amount: int
        ///The total amount that was returned to the customer.
        AmountReturned: int option
        ///ID of the Connect Application that created the order.
        Application: string option
        ///A fee in cents that will be applied to the order and transferred to the application owner’s Stripe account. The request must be made with an OAuth key or the Stripe-Account header in order to take an application fee. For more information, see the application fees documentation.
        ApplicationFee: int option
        ///The ID of the payment used to pay for the order. Present if the order status is `paid`, `fulfilled`, or `refunded`.
        [<JsonField(Transform=typeof<AnyOfTransform<OrderCharge'AnyOf>>)>]Charge: OrderCharge'AnyOf option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///The customer used for the order.
        [<JsonField(Transform=typeof<AnyOfTransform<OrderCustomer'AnyOf>>)>]Customer: OrderCustomer'AnyOf option
        ///The email address of the customer placing the order.
        Email: string option
        ///External coupon code to load for this order.
        ExternalCouponCode: string option
        ///Unique identifier for the object.
        Id: string
        ///List of items constituting the order. An order can have up to 25 items.
        Items: OrderItem list
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        ///A list of returns that have taken place for this order.
        Returns: OrderReturns option
        ///The shipping method that is currently selected for this order, if any. If present, it is equal to one of the `id`s of shipping methods in the `shipping_methods` array. At order creation time, if there are multiple shipping methods, Stripe will automatically selected the first method.
        SelectedShippingMethod: string option
        ///The shipping address for the order. Present if the order is for goods to be shipped.
        Shipping: Shipping option
        ///A list of supported shipping methods for this order. The desired shipping method can be specified either by updating the order, or when paying it.
        ShippingMethods: ShippingMethod list option
        ///Current order status. One of `created`, `paid`, `canceled`, `fulfilled`, or `returned`. More details in the [Orders Guide](https://stripe.com/docs/orders/guide#understanding-order-statuses).
        Status: OrderStatus
        ///The timestamps at which the order status was updated.
        StatusTransitions: StatusTransitions option
        ///Time at which the object was last updated. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Updated: DateTime option
        ///The user's order ID if it is different from the Stripe order ID.
        UpstreamId: string option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "order"

        static member Create (amount: int, amountReturned: int option, application: string option, applicationFee: int option, charge: OrderCharge'AnyOf option, created: DateTime, currency: string, customer: OrderCustomer'AnyOf option, email: string option, id: string, items: OrderItem list, livemode: bool, metadata: Map<string, string> option, returns: OrderReturns option, selectedShippingMethod: string option, shipping: Shipping option, shippingMethods: ShippingMethod list option, status: OrderStatus, statusTransitions: StatusTransitions option, updated: DateTime option, ?externalCouponCode: string, ?upstreamId: string) =
            {
                Order.Amount = amount //required
                Order.AmountReturned = amountReturned //required
                Order.Application = application //required
                Order.ApplicationFee = applicationFee //required
                Order.Charge = charge //required
                Order.Created = created //required
                Order.Currency = currency //required
                Order.Customer = customer //required
                Order.Email = email //required
                Order.Id = id //required
                Order.Items = items //required
                Order.Livemode = livemode //required
                Order.Metadata = metadata //required
                Order.Returns = returns //required
                Order.SelectedShippingMethod = selectedShippingMethod //required
                Order.Shipping = shipping //required
                Order.ShippingMethods = shippingMethods //required
                Order.Status = status //required
                Order.StatusTransitions = statusTransitions //required
                Order.Updated = updated //required
                Order.ExternalCouponCode = externalCouponCode
                Order.UpstreamId = upstreamId
            }

    and OrderCharge'AnyOf =
        | String of string
        | Charge of Charge

    and OrderCustomer'AnyOf =
        | String of string
        | Customer of Customer
        | DeletedCustomer of DeletedCustomer

    and OrderStatus =
        | Created
        | Paid
        | Canceled
        | Fulfilled
        | Returned

    ///A list of returns that have taken place for this order.
    and OrderReturns = {
        ///Details about each object.
        Data: OrderReturn list
        ///True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        ///The URL where this list can be accessed.
        Url: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
        member _.Object = "list"

        static member Create (data: OrderReturn list, hasMore: bool, url: string) =
            {
                OrderReturns.Data = data //required
                OrderReturns.HasMore = hasMore //required
                OrderReturns.Url = url //required
            }

    ///A representation of the constituent items of any given order. Can be used to
    ///represent [SKUs](https://stripe.com/docs/api#skus), shipping costs, or taxes owed on the order.
    ///Related guide: [Orders](https://stripe.com/docs/orders/guide).
    and OrderItem = {
        ///A positive integer in the smallest currency unit (that is, 100 cents for $1.00, or 1 for ¥1, Japanese Yen being a zero-decimal currency) representing the total amount for the line item.
        Amount: int
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///Description of the line item, meant to be displayable to the user (e.g., `"Express shipping"`).
        Description: string
        ///The ID of the associated object for this line item. Expandable if not null (e.g., expandable to a SKU).
        [<JsonField(Transform=typeof<AnyOfTransform<OrderItemParent'AnyOf>>)>]Parent: OrderItemParent'AnyOf option
        ///A positive integer representing the number of instances of `parent` that are included in this order item. Applicable/present only if `type` is `sku`.
        Quantity: int option
        ///The type of line item. One of `sku`, `tax`, `shipping`, or `discount`.
        Type: OrderItemType
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "order_item"

        static member Create (amount: int, currency: string, description: string, parent: OrderItemParent'AnyOf option, quantity: int option, ``type``: OrderItemType) =
            {
                OrderItem.Amount = amount //required
                OrderItem.Currency = currency //required
                OrderItem.Description = description //required
                OrderItem.Parent = parent //required
                OrderItem.Quantity = quantity //required
                OrderItem.Type = ``type`` //required
            }

    and OrderItemParent'AnyOf =
        | String of string
        | Sku of Sku

    and OrderItemType =
        | Sku
        | Tax
        | Shipping
        | Discount

    ///A return represents the full or partial return of a number of [order items](https://stripe.com/docs/api#order_items).
    ///Returns always belong to an order, and may optionally contain a refund.
    ///Related guide: [Handling Returns](https://stripe.com/docs/orders/guide#handling-returns).
    and OrderReturn = {
        ///A positive integer in the smallest currency unit (that is, 100 cents for $1.00, or 1 for ¥1, Japanese Yen being a zero-decimal currency) representing the total amount for the returned line item.
        Amount: int
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///Unique identifier for the object.
        Id: string
        ///The items included in this order return.
        Items: OrderItem list
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///The order that this return includes items from.
        [<JsonField(Transform=typeof<AnyOfTransform<OrderReturnOrder'AnyOf>>)>]Order: OrderReturnOrder'AnyOf option
        ///The ID of the refund issued for this return.
        [<JsonField(Transform=typeof<AnyOfTransform<OrderReturnRefund'AnyOf>>)>]Refund: OrderReturnRefund'AnyOf option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "order_return"

        static member Create (amount: int, created: DateTime, currency: string, id: string, items: OrderItem list, livemode: bool, order: OrderReturnOrder'AnyOf option, refund: OrderReturnRefund'AnyOf option) =
            {
                OrderReturn.Amount = amount //required
                OrderReturn.Created = created //required
                OrderReturn.Currency = currency //required
                OrderReturn.Id = id //required
                OrderReturn.Items = items //required
                OrderReturn.Livemode = livemode //required
                OrderReturn.Order = order //required
                OrderReturn.Refund = refund //required
            }

    and OrderReturnOrder'AnyOf =
        | String of string
        | Order of Order

    and OrderReturnRefund'AnyOf =
        | String of string
        | Refund of Refund

    and PackageDimensions = {
        ///Height, in inches.
        Height: decimal
        ///Length, in inches.
        Length: decimal
        ///Weight, in ounces.
        Weight: decimal
        ///Width, in inches.
        Width: decimal
    }
    with

        static member Create (height: decimal, length: decimal, weight: decimal, width: decimal) =
            {
                PackageDimensions.Height = height //required
                PackageDimensions.Length = length //required
                PackageDimensions.Weight = weight //required
                PackageDimensions.Width = width //required
            }

    and PaymentFlowsPrivatePaymentMethodsAlipay = {
        PaymentFlowsPrivatePaymentMethodsAlipay: string option
    }
    with

        static member Create (?paymentFlowsPrivatePaymentMethodsAlipay: string option) =
            {
                PaymentFlowsPrivatePaymentMethodsAlipay.PaymentFlowsPrivatePaymentMethodsAlipay = paymentFlowsPrivatePaymentMethodsAlipay |> Option.flatten
            }

    and PaymentFlowsPrivatePaymentMethodsAlipayDetails = {
        ///Uniquely identifies this particular Alipay account. You can use this attribute to check whether two Alipay accounts are the same.
        Fingerprint: string option
        ///Transaction ID of this particular Alipay transaction.
        TransactionId: string option
    }
    with

        static member Create (fingerprint: string option, transactionId: string option) =
            {
                PaymentFlowsPrivatePaymentMethodsAlipayDetails.Fingerprint = fingerprint //required
                PaymentFlowsPrivatePaymentMethodsAlipayDetails.TransactionId = transactionId //required
            }

    ///A PaymentIntent guides you through the process of collecting a payment from your customer.
    ///We recommend that you create exactly one PaymentIntent for each order or
    ///customer session in your system. You can reference the PaymentIntent later to
    ///see the history of payment attempts for a particular session.
    ///A PaymentIntent transitions through
    ///[multiple statuses](https://stripe.com/docs/payments/intents#intent-statuses)
    ///throughout its lifetime as it interfaces with Stripe.js to perform
    ///authentication flows and ultimately creates at most one successful charge.
    ///Related guide: [Payment Intents API](https://stripe.com/docs/payments/payment-intents).
    and PaymentIntent = {
        ///Amount intended to be collected by this PaymentIntent. A positive integer representing how much to charge in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal) (e.g., 100 cents to charge $1.00 or 100 to charge ¥100, a zero-decimal currency). The minimum amount is $0.50 US or [equivalent in charge currency](https://stripe.com/docs/currencies#minimum-and-maximum-charge-amounts). The amount value supports up to eight digits (e.g., a value of 99999999 for a USD charge of $999,999.99).
        Amount: int
        ///Amount that can be captured from this PaymentIntent.
        AmountCapturable: int
        ///Amount that was collected by this PaymentIntent.
        AmountReceived: int
        ///ID of the Connect application that created the PaymentIntent.
        [<JsonField(Transform=typeof<AnyOfTransform<PaymentIntentApplication'AnyOf>>)>]Application: PaymentIntentApplication'AnyOf option
        ///The amount of the application fee (if any) that will be requested to be applied to the payment and transferred to the application owner's Stripe account. The amount of the application fee collected will be capped at the total payment amount. For more information, see the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts).
        ApplicationFeeAmount: int option
        ///Populated when `status` is `canceled`, this is the time at which the PaymentIntent was canceled. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]CanceledAt: DateTime option
        ///Reason for cancellation of this PaymentIntent, either user-provided (`duplicate`, `fraudulent`, `requested_by_customer`, or `abandoned`) or generated by Stripe internally (`failed_invoice`, `void_invoice`, or `automatic`).
        CancellationReason: PaymentIntentCancellationReason option
        ///Controls when the funds will be captured from the customer's account.
        CaptureMethod: PaymentIntentCaptureMethod
        ///Charges that were created by this PaymentIntent, if any.
        Charges: PaymentIntentCharges
        ///The client secret of this PaymentIntent. Used for client-side retrieval using a publishable key. 
    ///The client secret can be used to complete a payment from your frontend. It should not be stored, logged, embedded in URLs, or exposed to anyone other than the customer. Make sure that you have TLS enabled on any page that includes the client secret.
    ///Refer to our docs to [accept a payment](https://stripe.com/docs/payments/accept-a-payment?integration=elements) and learn about how `client_secret` should be handled.
        ClientSecret: string option
        ConfirmationMethod: PaymentIntentConfirmationMethod
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///ID of the Customer this PaymentIntent belongs to, if one exists.
    ///Payment methods attached to other Customers cannot be used with this PaymentIntent.
    ///If present in combination with [setup_future_usage](https://stripe.com/docs/api#payment_intent_object-setup_future_usage), this PaymentIntent's payment method will be attached to the Customer after the PaymentIntent has been confirmed and any required actions from the user are complete.
        [<JsonField(Transform=typeof<AnyOfTransform<PaymentIntentCustomer'AnyOf>>)>]Customer: PaymentIntentCustomer'AnyOf option
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        ///Unique identifier for the object.
        Id: string
        ///ID of the invoice that created this PaymentIntent, if it exists.
        [<JsonField(Transform=typeof<AnyOfTransform<PaymentIntentInvoice'AnyOf>>)>]Invoice: PaymentIntentInvoice'AnyOf option
        ///The payment error encountered in the previous PaymentIntent confirmation. It will be cleared if the PaymentIntent is later updated for any reason.
        LastPaymentError: ApiErrors option
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. For more information, see the [documentation](https://stripe.com/docs/payments/payment-intents/creating-payment-intents#storing-information-in-metadata).
        Metadata: Map<string, string>
        ///If present, this property tells you what actions you need to take in order for your customer to fulfill a payment using the provided source.
        NextAction: PaymentIntentNextAction option
        ///The account (if any) for which the funds of the PaymentIntent are intended. See the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts) for details.
        [<JsonField(Transform=typeof<AnyOfTransform<PaymentIntentOnBehalfOf'AnyOf>>)>]OnBehalfOf: PaymentIntentOnBehalfOf'AnyOf option
        ///ID of the payment method used in this PaymentIntent.
        [<JsonField(Transform=typeof<AnyOfTransform<PaymentIntentPaymentMethod'AnyOf>>)>]PaymentMethod: PaymentIntentPaymentMethod'AnyOf option
        ///Payment-method-specific configuration for this PaymentIntent.
        PaymentMethodOptions: PaymentIntentPaymentMethodOptions option
        ///The list of payment method types (e.g. card) that this PaymentIntent is allowed to use.
        PaymentMethodTypes: string list
        ///Email address that the receipt for the resulting payment will be sent to. If `receipt_email` is specified for a payment in live mode, a receipt will be sent regardless of your [email settings](https://dashboard.stripe.com/account/emails).
        ReceiptEmail: string option
        ///ID of the review associated with this PaymentIntent, if any.
        [<JsonField(Transform=typeof<AnyOfTransform<PaymentIntentReview'AnyOf>>)>]Review: PaymentIntentReview'AnyOf option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
    ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
    ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        SetupFutureUsage: PaymentIntentSetupFutureUsage option
        ///Shipping information for this PaymentIntent.
        Shipping: Shipping option
        ///This is a legacy field that will be removed in the future. It is the ID of the Source object that is associated with this PaymentIntent, if one was supplied.
        [<JsonField(Transform=typeof<AnyOfTransform<PaymentIntentSource'AnyOf>>)>]Source: PaymentIntentSource'AnyOf option
        ///For non-card charges, you can use this value as the complete description that appears on your customers’ statements. Must contain at least one letter, maximum 22 characters.
        StatementDescriptor: string option
        ///Provides information about a card payment that customers see on their statements. Concatenated with the prefix (shortened descriptor) or statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 22 characters for the concatenated descriptor.
        StatementDescriptorSuffix: string option
        ///Status of this PaymentIntent, one of `requires_payment_method`, `requires_confirmation`, `requires_action`, `processing`, `requires_capture`, `canceled`, or `succeeded`. Read more about each PaymentIntent [status](https://stripe.com/docs/payments/intents#intent-statuses).
        Status: PaymentIntentStatus
        ///The data with which to automatically create a Transfer when the payment is finalized. See the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts) for details.
        TransferData: TransferData option
        ///A string that identifies the resulting payment as part of a group. See the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts) for details.
        TransferGroup: string option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "payment_intent"

        static member Create (amount: int, amountCapturable: int, amountReceived: int, application: PaymentIntentApplication'AnyOf option, applicationFeeAmount: int option, canceledAt: DateTime option, cancellationReason: PaymentIntentCancellationReason option, captureMethod: PaymentIntentCaptureMethod, charges: PaymentIntentCharges, clientSecret: string option, confirmationMethod: PaymentIntentConfirmationMethod, created: DateTime, currency: string, customer: PaymentIntentCustomer'AnyOf option, description: string option, id: string, invoice: PaymentIntentInvoice'AnyOf option, lastPaymentError: ApiErrors option, livemode: bool, metadata: Map<string, string>, nextAction: PaymentIntentNextAction option, onBehalfOf: PaymentIntentOnBehalfOf'AnyOf option, paymentMethod: PaymentIntentPaymentMethod'AnyOf option, paymentMethodOptions: PaymentIntentPaymentMethodOptions option, paymentMethodTypes: string list, receiptEmail: string option, review: PaymentIntentReview'AnyOf option, setupFutureUsage: PaymentIntentSetupFutureUsage option, shipping: Shipping option, source: PaymentIntentSource'AnyOf option, statementDescriptor: string option, statementDescriptorSuffix: string option, status: PaymentIntentStatus, transferData: TransferData option, transferGroup: string option) =
            {
                PaymentIntent.Amount = amount //required
                PaymentIntent.AmountCapturable = amountCapturable //required
                PaymentIntent.AmountReceived = amountReceived //required
                PaymentIntent.Application = application //required
                PaymentIntent.ApplicationFeeAmount = applicationFeeAmount //required
                PaymentIntent.CanceledAt = canceledAt //required
                PaymentIntent.CancellationReason = cancellationReason //required
                PaymentIntent.CaptureMethod = captureMethod //required
                PaymentIntent.Charges = charges //required
                PaymentIntent.ClientSecret = clientSecret //required
                PaymentIntent.ConfirmationMethod = confirmationMethod //required
                PaymentIntent.Created = created //required
                PaymentIntent.Currency = currency //required
                PaymentIntent.Customer = customer //required
                PaymentIntent.Description = description //required
                PaymentIntent.Id = id //required
                PaymentIntent.Invoice = invoice //required
                PaymentIntent.LastPaymentError = lastPaymentError //required
                PaymentIntent.Livemode = livemode //required
                PaymentIntent.Metadata = metadata //required
                PaymentIntent.NextAction = nextAction //required
                PaymentIntent.OnBehalfOf = onBehalfOf //required
                PaymentIntent.PaymentMethod = paymentMethod //required
                PaymentIntent.PaymentMethodOptions = paymentMethodOptions //required
                PaymentIntent.PaymentMethodTypes = paymentMethodTypes //required
                PaymentIntent.ReceiptEmail = receiptEmail //required
                PaymentIntent.Review = review //required
                PaymentIntent.SetupFutureUsage = setupFutureUsage //required
                PaymentIntent.Shipping = shipping //required
                PaymentIntent.Source = source //required
                PaymentIntent.StatementDescriptor = statementDescriptor //required
                PaymentIntent.StatementDescriptorSuffix = statementDescriptorSuffix //required
                PaymentIntent.Status = status //required
                PaymentIntent.TransferData = transferData //required
                PaymentIntent.TransferGroup = transferGroup //required
            }

    and PaymentIntentApplication'AnyOf =
        | String of string
        | Application of Application

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

    and PaymentIntentCustomer'AnyOf =
        | String of string
        | Customer of Customer
        | DeletedCustomer of DeletedCustomer

    and PaymentIntentInvoice'AnyOf =
        | String of string
        | Invoice of Invoice

    and PaymentIntentOnBehalfOf'AnyOf =
        | String of string
        | Account of Account

    and PaymentIntentPaymentMethod'AnyOf =
        | String of string
        | PaymentMethod of PaymentMethod

    and PaymentIntentReview'AnyOf =
        | String of string
        | Review of Review

    and PaymentIntentSetupFutureUsage =
        | OffSession
        | OnSession

    and PaymentIntentSource'AnyOf =
        | String of string
        | PaymentSource of PaymentSource
        | DeletedPaymentSource of DeletedPaymentSource

    and PaymentIntentStatus =
        | Canceled
        | Processing
        | RequiresAction
        | RequiresCapture
        | RequiresConfirmation
        | RequiresPaymentMethod
        | Succeeded

    ///Charges that were created by this PaymentIntent, if any.
    and PaymentIntentCharges = {
        ///This list only contains the latest charge, even if there were previously multiple unsuccessful charges. To view all previous charges for a PaymentIntent, you can filter the charges list using the `payment_intent` [parameter](https://stripe.com/docs/api/charges/list#list_charges-payment_intent).
        Data: Charge list
        ///True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        ///The URL where this list can be accessed.
        Url: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
        member _.Object = "list"

        static member Create (data: Charge list, hasMore: bool, url: string) =
            {
                PaymentIntentCharges.Data = data //required
                PaymentIntentCharges.HasMore = hasMore //required
                PaymentIntentCharges.Url = url //required
            }

    and PaymentIntentNextAction = {
        AlipayHandleRedirect: PaymentIntentNextActionAlipayHandleRedirect option
        OxxoDisplayDetails: PaymentIntentNextActionDisplayOxxoDetails option
        RedirectToUrl: PaymentIntentNextActionRedirectToUrl option
        ///Type of the next action to perform, one of `redirect_to_url` or `use_stripe_sdk`.
        Type: PaymentIntentNextActionType
        ///When confirming a PaymentIntent with Stripe.js, Stripe.js depends on the contents of this dictionary to invoke authentication flows. The shape of the contents is subject to change and is only intended to be used by Stripe.js.
        UseStripeSdk: obj option
    }
    with

        static member Create (``type``: PaymentIntentNextActionType, ?alipayHandleRedirect: PaymentIntentNextActionAlipayHandleRedirect, ?oxxoDisplayDetails: PaymentIntentNextActionDisplayOxxoDetails, ?redirectToUrl: PaymentIntentNextActionRedirectToUrl, ?useStripeSdk: obj) =
            {
                PaymentIntentNextAction.Type = ``type`` //required
                PaymentIntentNextAction.AlipayHandleRedirect = alipayHandleRedirect
                PaymentIntentNextAction.OxxoDisplayDetails = oxxoDisplayDetails
                PaymentIntentNextAction.RedirectToUrl = redirectToUrl
                PaymentIntentNextAction.UseStripeSdk = useStripeSdk
            }

    and PaymentIntentNextActionType =
        | RedirectToUrl
        | UseStripeSdk

    and PaymentIntentNextActionAlipayHandleRedirect = {
        ///The native data to be used with Alipay SDK you must redirect your customer to in order to authenticate the payment in an Android App.
        NativeData: string option
        ///The native URL you must redirect your customer to in order to authenticate the payment in an iOS App.
        NativeUrl: string option
        ///If the customer does not exit their browser while authenticating, they will be redirected to this specified URL after completion.
        ReturnUrl: string option
        ///The URL you must redirect your customer to in order to authenticate the payment.
        Url: string option
    }
    with

        static member Create (nativeData: string option, nativeUrl: string option, returnUrl: string option, url: string option) =
            {
                PaymentIntentNextActionAlipayHandleRedirect.NativeData = nativeData //required
                PaymentIntentNextActionAlipayHandleRedirect.NativeUrl = nativeUrl //required
                PaymentIntentNextActionAlipayHandleRedirect.ReturnUrl = returnUrl //required
                PaymentIntentNextActionAlipayHandleRedirect.Url = url //required
            }

    and PaymentIntentNextActionDisplayOxxoDetails = {
        ///The timestamp after which the OXXO voucher expires.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]ExpiresAfter: DateTime option
        ///The URL for the hosted OXXO voucher page, which allows customers to view and print an OXXO voucher.
        HostedVoucherUrl: string option
        ///OXXO reference number.
        Number: string option
    }
    with

        static member Create (expiresAfter: DateTime option, hostedVoucherUrl: string option, number: string option) =
            {
                PaymentIntentNextActionDisplayOxxoDetails.ExpiresAfter = expiresAfter //required
                PaymentIntentNextActionDisplayOxxoDetails.HostedVoucherUrl = hostedVoucherUrl //required
                PaymentIntentNextActionDisplayOxxoDetails.Number = number //required
            }

    and PaymentIntentNextActionRedirectToUrl = {
        ///If the customer does not exit their browser while authenticating, they will be redirected to this specified URL after completion.
        ReturnUrl: string option
        ///The URL you must redirect your customer to in order to authenticate the payment.
        Url: string option
    }
    with

        static member Create (returnUrl: string option, url: string option) =
            {
                PaymentIntentNextActionRedirectToUrl.ReturnUrl = returnUrl //required
                PaymentIntentNextActionRedirectToUrl.Url = url //required
            }

    and PaymentIntentPaymentMethodOptions = {
        Alipay: PaymentMethodOptionsAlipay option
        Bancontact: PaymentMethodOptionsBancontact option
        Card: PaymentIntentPaymentMethodOptionsCard option
        Oxxo: PaymentMethodOptionsOxxo option
        [<JsonField(Name="p24")>]P24: PaymentMethodOptionsP24 option
        SepaDebit: PaymentIntentPaymentMethodOptionsSepaDebit option
        Sofort: PaymentMethodOptionsSofort option
    }
    with

        static member Create (?alipay: PaymentMethodOptionsAlipay, ?bancontact: PaymentMethodOptionsBancontact, ?card: PaymentIntentPaymentMethodOptionsCard, ?oxxo: PaymentMethodOptionsOxxo, ?p24: PaymentMethodOptionsP24, ?sepaDebit: PaymentIntentPaymentMethodOptionsSepaDebit, ?sofort: PaymentMethodOptionsSofort) =
            {
                PaymentIntentPaymentMethodOptions.Alipay = alipay
                PaymentIntentPaymentMethodOptions.Bancontact = bancontact
                PaymentIntentPaymentMethodOptions.Card = card
                PaymentIntentPaymentMethodOptions.Oxxo = oxxo
                PaymentIntentPaymentMethodOptions.P24 = p24
                PaymentIntentPaymentMethodOptions.SepaDebit = sepaDebit
                PaymentIntentPaymentMethodOptions.Sofort = sofort
            }

    and PaymentIntentPaymentMethodOptionsCard = {
        ///Installment details for this payment (Mexico only).
    ///For more information, see the [installments integration guide](https://stripe.com/docs/payments/installments).
        Installments: PaymentMethodOptionsCardInstallments option
        ///Selected network to process this PaymentIntent on. Depends on the available networks of the card attached to the PaymentIntent. Can be only set confirm-time.
        Network: PaymentIntentPaymentMethodOptionsCardNetwork option
        ///We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://stripe.com/docs/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Permitted values include: `automatic` or `any`. If not provided, defaults to `automatic`. Read our guide on [manually requesting 3D Secure](https://stripe.com/docs/payments/3d-secure#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
        RequestThreeDSecure: PaymentIntentPaymentMethodOptionsCardRequestThreeDSecure option
    }
    with

        static member Create (installments: PaymentMethodOptionsCardInstallments option, network: PaymentIntentPaymentMethodOptionsCardNetwork option, requestThreeDSecure: PaymentIntentPaymentMethodOptionsCardRequestThreeDSecure option) =
            {
                PaymentIntentPaymentMethodOptionsCard.Installments = installments //required
                PaymentIntentPaymentMethodOptionsCard.Network = network //required
                PaymentIntentPaymentMethodOptionsCard.RequestThreeDSecure = requestThreeDSecure //required
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

    and PaymentIntentPaymentMethodOptionsMandateOptionsSepaDebit = {
        PaymentIntentPaymentMethodOptionsMandateOptionsSepaDebit: string option
    }
    with

        static member Create (?paymentIntentPaymentMethodOptionsMandateOptionsSepaDebit: string option) =
            {
                PaymentIntentPaymentMethodOptionsMandateOptionsSepaDebit.PaymentIntentPaymentMethodOptionsMandateOptionsSepaDebit = paymentIntentPaymentMethodOptionsMandateOptionsSepaDebit |> Option.flatten
            }

    and PaymentIntentPaymentMethodOptionsSepaDebit = {
        MandateOptions: PaymentIntentPaymentMethodOptionsMandateOptionsSepaDebit option
    }
    with

        static member Create (?mandateOptions: PaymentIntentPaymentMethodOptionsMandateOptionsSepaDebit) =
            {
                PaymentIntentPaymentMethodOptionsSepaDebit.MandateOptions = mandateOptions
            }

    ///PaymentMethod objects represent your customer's payment instruments.
    ///They can be used with [PaymentIntents](https://stripe.com/docs/payments/payment-intents) to collect payments or saved to
    ///Customer objects to store instrument details for future payments.
    ///Related guides: [Payment Methods](https://stripe.com/docs/payments/payment-methods) and [More Payment Scenarios](https://stripe.com/docs/payments/more-payment-scenarios).
    and PaymentMethod = {
        Alipay: PaymentFlowsPrivatePaymentMethodsAlipay option
        AuBecsDebit: PaymentMethodAuBecsDebit option
        BacsDebit: PaymentMethodBacsDebit option
        Bancontact: PaymentMethodBancontact option
        BillingDetails: BillingDetails
        Card: PaymentMethodCard option
        CardPresent: PaymentMethodCardPresent option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///The ID of the Customer to which this PaymentMethod is saved. This will not be set when the PaymentMethod has not been saved to a Customer.
        [<JsonField(Transform=typeof<AnyOfTransform<PaymentMethodCustomer'AnyOf>>)>]Customer: PaymentMethodCustomer'AnyOf option
        Eps: PaymentMethodEps option
        Fpx: PaymentMethodFpx option
        Giropay: PaymentMethodGiropay option
        Grabpay: PaymentMethodGrabpay option
        ///Unique identifier for the object.
        Id: string
        Ideal: PaymentMethodIdeal option
        InteracPresent: PaymentMethodInteracPresent option
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        Oxxo: PaymentMethodOxxo option
        [<JsonField(Name="p24")>]P24: PaymentMethodP24 option
        SepaDebit: PaymentMethodSepaDebit option
        Sofort: PaymentMethodSofort option
        ///The type of the PaymentMethod. An additional hash is included on the PaymentMethod with a name matching this value. It contains additional information specific to the PaymentMethod type.
        Type: PaymentMethodType
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "payment_method"

        static member Create (billingDetails: BillingDetails, created: DateTime, customer: PaymentMethodCustomer'AnyOf option, id: string, livemode: bool, metadata: Map<string, string> option, ``type``: PaymentMethodType, ?alipay: PaymentFlowsPrivatePaymentMethodsAlipay, ?auBecsDebit: PaymentMethodAuBecsDebit, ?bacsDebit: PaymentMethodBacsDebit, ?bancontact: PaymentMethodBancontact, ?card: PaymentMethodCard, ?cardPresent: PaymentMethodCardPresent, ?eps: PaymentMethodEps, ?fpx: PaymentMethodFpx, ?giropay: PaymentMethodGiropay, ?grabpay: PaymentMethodGrabpay, ?ideal: PaymentMethodIdeal, ?interacPresent: PaymentMethodInteracPresent, ?oxxo: PaymentMethodOxxo, ?p24: PaymentMethodP24, ?sepaDebit: PaymentMethodSepaDebit, ?sofort: PaymentMethodSofort) =
            {
                PaymentMethod.BillingDetails = billingDetails //required
                PaymentMethod.Created = created //required
                PaymentMethod.Customer = customer //required
                PaymentMethod.Id = id //required
                PaymentMethod.Livemode = livemode //required
                PaymentMethod.Metadata = metadata //required
                PaymentMethod.Type = ``type`` //required
                PaymentMethod.Alipay = alipay
                PaymentMethod.AuBecsDebit = auBecsDebit
                PaymentMethod.BacsDebit = bacsDebit
                PaymentMethod.Bancontact = bancontact
                PaymentMethod.Card = card
                PaymentMethod.CardPresent = cardPresent
                PaymentMethod.Eps = eps
                PaymentMethod.Fpx = fpx
                PaymentMethod.Giropay = giropay
                PaymentMethod.Grabpay = grabpay
                PaymentMethod.Ideal = ideal
                PaymentMethod.InteracPresent = interacPresent
                PaymentMethod.Oxxo = oxxo
                PaymentMethod.P24 = p24
                PaymentMethod.SepaDebit = sepaDebit
                PaymentMethod.Sofort = sofort
            }

    and PaymentMethodCustomer'AnyOf =
        | String of string
        | Customer of Customer

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

    and PaymentMethodAuBecsDebit = {
        ///Six-digit number identifying bank and branch associated with this bank account.
        BsbNumber: string option
        ///Uniquely identifies this particular bank account. You can use this attribute to check whether two bank accounts are the same.
        Fingerprint: string option
        ///Last four digits of the bank account number.
        [<JsonField(Name="last4")>]Last4: string option
    }
    with

        static member Create (bsbNumber: string option, fingerprint: string option, last4: string option) =
            {
                PaymentMethodAuBecsDebit.BsbNumber = bsbNumber //required
                PaymentMethodAuBecsDebit.Fingerprint = fingerprint //required
                PaymentMethodAuBecsDebit.Last4 = last4 //required
            }

    and PaymentMethodBacsDebit = {
        ///Uniquely identifies this particular bank account. You can use this attribute to check whether two bank accounts are the same.
        Fingerprint: string option
        ///Last four digits of the bank account number.
        [<JsonField(Name="last4")>]Last4: string option
        ///Sort code of the bank account. (e.g., `10-20-30`)
        SortCode: string option
    }
    with

        static member Create (fingerprint: string option, last4: string option, sortCode: string option) =
            {
                PaymentMethodBacsDebit.Fingerprint = fingerprint //required
                PaymentMethodBacsDebit.Last4 = last4 //required
                PaymentMethodBacsDebit.SortCode = sortCode //required
            }

    and PaymentMethodBancontact = {
        PaymentMethodBancontact: string option
    }
    with

        static member Create (?paymentMethodBancontact: string option) =
            {
                PaymentMethodBancontact.PaymentMethodBancontact = paymentMethodBancontact |> Option.flatten
            }

    and PaymentMethodCard = {
        ///Card brand. Can be `amex`, `diners`, `discover`, `jcb`, `mastercard`, `unionpay`, `visa`, or `unknown`.
        Brand: PaymentMethodCardBrand
        ///Checks on Card address and CVC if provided.
        Checks: PaymentMethodCardChecks option
        ///Two-letter ISO code representing the country of the card. You could use this attribute to get a sense of the international breakdown of cards you've collected.
        Country: string option
        ///A high-level description of the type of cards issued in this range. (For internal use only and not typically available in standard API requests.)
        Description: string option
        ///Two-digit number representing the card's expiration month.
        ExpMonth: int
        ///Four-digit number representing the card's expiration year.
        ExpYear: int
        ///Uniquely identifies this particular card number. You can use this attribute to check whether two customers who’ve signed up with you are using the same card number, for example. For payment methods that tokenize card information (Apple Pay, Google Pay), the tokenized number might be provided instead of the underlying card number.
        Fingerprint: string option
        ///Card funding type. Can be `credit`, `debit`, `prepaid`, or `unknown`.
        Funding: PaymentMethodCardFunding
        ///Issuer identification number of the card. (For internal use only and not typically available in standard API requests.)
        Iin: string option
        ///The name of the card's issuing bank. (For internal use only and not typically available in standard API requests.)
        Issuer: string option
        ///The last four digits of the card.
        [<JsonField(Name="last4")>]Last4: string
        ///Contains information about card networks that can be used to process the payment.
        Networks: Networks option
        ///Contains details on how this Card maybe be used for 3D Secure authentication.
        ThreeDSecureUsage: ThreeDSecureUsage option
        ///If this Card is part of a card wallet, this contains the details of the card wallet.
        Wallet: PaymentMethodCardWallet option
    }
    with

        static member Create (brand: PaymentMethodCardBrand, checks: PaymentMethodCardChecks option, country: string option, expMonth: int, expYear: int, funding: PaymentMethodCardFunding, last4: string, networks: Networks option, threeDSecureUsage: ThreeDSecureUsage option, wallet: PaymentMethodCardWallet option, ?description: string option, ?fingerprint: string option, ?iin: string option, ?issuer: string option) =
            {
                PaymentMethodCard.Brand = brand //required
                PaymentMethodCard.Checks = checks //required
                PaymentMethodCard.Country = country //required
                PaymentMethodCard.ExpMonth = expMonth //required
                PaymentMethodCard.ExpYear = expYear //required
                PaymentMethodCard.Funding = funding //required
                PaymentMethodCard.Last4 = last4 //required
                PaymentMethodCard.Networks = networks //required
                PaymentMethodCard.ThreeDSecureUsage = threeDSecureUsage //required
                PaymentMethodCard.Wallet = wallet //required
                PaymentMethodCard.Description = description |> Option.flatten
                PaymentMethodCard.Fingerprint = fingerprint |> Option.flatten
                PaymentMethodCard.Iin = iin |> Option.flatten
                PaymentMethodCard.Issuer = issuer |> Option.flatten
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

    and PaymentMethodCardChecks = {
        ///If a address line1 was provided, results of the check, one of `pass`, `fail`, `unavailable`, or `unchecked`.
        [<JsonField(Name="address_line1_check")>]AddressLine1Check: PaymentMethodCardChecksAddressLine1Check option
        ///If a address postal code was provided, results of the check, one of `pass`, `fail`, `unavailable`, or `unchecked`.
        AddressPostalCodeCheck: PaymentMethodCardChecksAddressPostalCodeCheck option
        ///If a CVC was provided, results of the check, one of `pass`, `fail`, `unavailable`, or `unchecked`.
        CvcCheck: PaymentMethodCardChecksCvcCheck option
    }
    with

        static member Create (addressLine1Check: PaymentMethodCardChecksAddressLine1Check option, addressPostalCodeCheck: PaymentMethodCardChecksAddressPostalCodeCheck option, cvcCheck: PaymentMethodCardChecksCvcCheck option) =
            {
                PaymentMethodCardChecks.AddressLine1Check = addressLine1Check //required
                PaymentMethodCardChecks.AddressPostalCodeCheck = addressPostalCodeCheck //required
                PaymentMethodCardChecks.CvcCheck = cvcCheck //required
            }

    and PaymentMethodCardChecksAddressLine1Check =
        | Pass
        | Fail
        | Unavailable
        | Unchecked

    and PaymentMethodCardChecksAddressPostalCodeCheck =
        | Pass
        | Fail
        | Unavailable
        | Unchecked

    and PaymentMethodCardChecksCvcCheck =
        | Pass
        | Fail
        | Unavailable
        | Unchecked

    and PaymentMethodCardPresent = {
        PaymentMethodCardPresent: string option
    }
    with

        static member Create (?paymentMethodCardPresent: string option) =
            {
                PaymentMethodCardPresent.PaymentMethodCardPresent = paymentMethodCardPresent |> Option.flatten
            }

    and PaymentMethodCardWallet = {
        AmexExpressCheckout: PaymentMethodCardWalletAmexExpressCheckout option
        ApplePay: PaymentMethodCardWalletApplePay option
        ///(For tokenized numbers only.) The last four digits of the device account number.
        [<JsonField(Name="dynamic_last4")>]DynamicLast4: string option
        GooglePay: PaymentMethodCardWalletGooglePay option
        Masterpass: PaymentMethodCardWalletMasterpass option
        SamsungPay: PaymentMethodCardWalletSamsungPay option
        ///The type of the card wallet, one of `amex_express_checkout`, `apple_pay`, `google_pay`, `masterpass`, `samsung_pay`, or `visa_checkout`. An additional hash is included on the Wallet subhash with a name matching this value. It contains additional information specific to the card wallet type.
        Type: PaymentMethodCardWalletType
        VisaCheckout: PaymentMethodCardWalletVisaCheckout option
    }
    with

        static member Create (dynamicLast4: string option, ``type``: PaymentMethodCardWalletType, ?amexExpressCheckout: PaymentMethodCardWalletAmexExpressCheckout, ?applePay: PaymentMethodCardWalletApplePay, ?googlePay: PaymentMethodCardWalletGooglePay, ?masterpass: PaymentMethodCardWalletMasterpass, ?samsungPay: PaymentMethodCardWalletSamsungPay, ?visaCheckout: PaymentMethodCardWalletVisaCheckout) =
            {
                PaymentMethodCardWallet.DynamicLast4 = dynamicLast4 //required
                PaymentMethodCardWallet.Type = ``type`` //required
                PaymentMethodCardWallet.AmexExpressCheckout = amexExpressCheckout
                PaymentMethodCardWallet.ApplePay = applePay
                PaymentMethodCardWallet.GooglePay = googlePay
                PaymentMethodCardWallet.Masterpass = masterpass
                PaymentMethodCardWallet.SamsungPay = samsungPay
                PaymentMethodCardWallet.VisaCheckout = visaCheckout
            }

    and PaymentMethodCardWalletType =
        | AmexExpressCheckout
        | ApplePay
        | GooglePay
        | Masterpass
        | SamsungPay
        | VisaCheckout

    and PaymentMethodCardWalletAmexExpressCheckout = {
        PaymentMethodCardWalletAmexExpressCheckout: string option
    }
    with

        static member Create (?paymentMethodCardWalletAmexExpressCheckout: string option) =
            {
                PaymentMethodCardWalletAmexExpressCheckout.PaymentMethodCardWalletAmexExpressCheckout = paymentMethodCardWalletAmexExpressCheckout |> Option.flatten
            }

    and PaymentMethodCardWalletApplePay = {
        PaymentMethodCardWalletApplePay: string option
    }
    with

        static member Create (?paymentMethodCardWalletApplePay: string option) =
            {
                PaymentMethodCardWalletApplePay.PaymentMethodCardWalletApplePay = paymentMethodCardWalletApplePay |> Option.flatten
            }

    and PaymentMethodCardWalletGooglePay = {
        PaymentMethodCardWalletGooglePay: string option
    }
    with

        static member Create (?paymentMethodCardWalletGooglePay: string option) =
            {
                PaymentMethodCardWalletGooglePay.PaymentMethodCardWalletGooglePay = paymentMethodCardWalletGooglePay |> Option.flatten
            }

    and PaymentMethodCardWalletMasterpass = {
        ///Owner's verified billing address. Values are verified or provided by the wallet directly (if supported) at the time of authorization or settlement. They cannot be set or mutated.
        BillingAddress: Address option
        ///Owner's verified email. Values are verified or provided by the wallet directly (if supported) at the time of authorization or settlement. They cannot be set or mutated.
        Email: string option
        ///Owner's verified full name. Values are verified or provided by the wallet directly (if supported) at the time of authorization or settlement. They cannot be set or mutated.
        Name: string option
        ///Owner's verified shipping address. Values are verified or provided by the wallet directly (if supported) at the time of authorization or settlement. They cannot be set or mutated.
        ShippingAddress: Address option
    }
    with

        static member Create (billingAddress: Address option, email: string option, name: string option, shippingAddress: Address option) =
            {
                PaymentMethodCardWalletMasterpass.BillingAddress = billingAddress //required
                PaymentMethodCardWalletMasterpass.Email = email //required
                PaymentMethodCardWalletMasterpass.Name = name //required
                PaymentMethodCardWalletMasterpass.ShippingAddress = shippingAddress //required
            }

    and PaymentMethodCardWalletSamsungPay = {
        PaymentMethodCardWalletSamsungPay: string option
    }
    with

        static member Create (?paymentMethodCardWalletSamsungPay: string option) =
            {
                PaymentMethodCardWalletSamsungPay.PaymentMethodCardWalletSamsungPay = paymentMethodCardWalletSamsungPay |> Option.flatten
            }

    and PaymentMethodCardWalletVisaCheckout = {
        ///Owner's verified billing address. Values are verified or provided by the wallet directly (if supported) at the time of authorization or settlement. They cannot be set or mutated.
        BillingAddress: Address option
        ///Owner's verified email. Values are verified or provided by the wallet directly (if supported) at the time of authorization or settlement. They cannot be set or mutated.
        Email: string option
        ///Owner's verified full name. Values are verified or provided by the wallet directly (if supported) at the time of authorization or settlement. They cannot be set or mutated.
        Name: string option
        ///Owner's verified shipping address. Values are verified or provided by the wallet directly (if supported) at the time of authorization or settlement. They cannot be set or mutated.
        ShippingAddress: Address option
    }
    with

        static member Create (billingAddress: Address option, email: string option, name: string option, shippingAddress: Address option) =
            {
                PaymentMethodCardWalletVisaCheckout.BillingAddress = billingAddress //required
                PaymentMethodCardWalletVisaCheckout.Email = email //required
                PaymentMethodCardWalletVisaCheckout.Name = name //required
                PaymentMethodCardWalletVisaCheckout.ShippingAddress = shippingAddress //required
            }

    and PaymentMethodDetails = {
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
        [<JsonField(Name="p24")>]P24: PaymentMethodDetailsP24 option
        SepaCreditTransfer: PaymentMethodDetailsSepaCreditTransfer option
        SepaDebit: PaymentMethodDetailsSepaDebit option
        Sofort: PaymentMethodDetailsSofort option
        StripeAccount: PaymentMethodDetailsStripeAccount option
        ///The type of transaction-specific details of the payment method used in the payment, one of `ach_credit_transfer`, `ach_debit`, `alipay`, `au_becs_debit`, `bancontact`, `card`, `card_present`, `eps`, `giropay`, `ideal`, `klarna`, `multibanco`, `p24`, `sepa_debit`, `sofort`, `stripe_account`, or `wechat`.
    ///An additional hash is included on `payment_method_details` with a name matching this value.
    ///It contains information specific to the payment method.
        Type: PaymentMethodDetailsType
        Wechat: PaymentMethodDetailsWechat option
    }
    with

        static member Create (``type``: PaymentMethodDetailsType, ?achCreditTransfer: PaymentMethodDetailsAchCreditTransfer, ?achDebit: PaymentMethodDetailsAchDebit, ?acssDebit: PaymentMethodDetailsAcssDebit, ?alipay: PaymentFlowsPrivatePaymentMethodsAlipayDetails, ?auBecsDebit: PaymentMethodDetailsAuBecsDebit, ?bacsDebit: PaymentMethodDetailsBacsDebit, ?bancontact: PaymentMethodDetailsBancontact, ?card: PaymentMethodDetailsCard, ?cardPresent: PaymentMethodDetailsCardPresent, ?eps: PaymentMethodDetailsEps, ?fpx: PaymentMethodDetailsFpx, ?giropay: PaymentMethodDetailsGiropay, ?grabpay: PaymentMethodDetailsGrabpay, ?ideal: PaymentMethodDetailsIdeal, ?interacPresent: PaymentMethodDetailsInteracPresent, ?klarna: PaymentMethodDetailsKlarna, ?multibanco: PaymentMethodDetailsMultibanco, ?oxxo: PaymentMethodDetailsOxxo, ?p24: PaymentMethodDetailsP24, ?sepaCreditTransfer: PaymentMethodDetailsSepaCreditTransfer, ?sepaDebit: PaymentMethodDetailsSepaDebit, ?sofort: PaymentMethodDetailsSofort, ?stripeAccount: PaymentMethodDetailsStripeAccount, ?wechat: PaymentMethodDetailsWechat) =
            {
                PaymentMethodDetails.Type = ``type`` //required
                PaymentMethodDetails.AchCreditTransfer = achCreditTransfer
                PaymentMethodDetails.AchDebit = achDebit
                PaymentMethodDetails.AcssDebit = acssDebit
                PaymentMethodDetails.Alipay = alipay
                PaymentMethodDetails.AuBecsDebit = auBecsDebit
                PaymentMethodDetails.BacsDebit = bacsDebit
                PaymentMethodDetails.Bancontact = bancontact
                PaymentMethodDetails.Card = card
                PaymentMethodDetails.CardPresent = cardPresent
                PaymentMethodDetails.Eps = eps
                PaymentMethodDetails.Fpx = fpx
                PaymentMethodDetails.Giropay = giropay
                PaymentMethodDetails.Grabpay = grabpay
                PaymentMethodDetails.Ideal = ideal
                PaymentMethodDetails.InteracPresent = interacPresent
                PaymentMethodDetails.Klarna = klarna
                PaymentMethodDetails.Multibanco = multibanco
                PaymentMethodDetails.Oxxo = oxxo
                PaymentMethodDetails.P24 = p24
                PaymentMethodDetails.SepaCreditTransfer = sepaCreditTransfer
                PaymentMethodDetails.SepaDebit = sepaDebit
                PaymentMethodDetails.Sofort = sofort
                PaymentMethodDetails.StripeAccount = stripeAccount
                PaymentMethodDetails.Wechat = wechat
            }

    and PaymentMethodDetailsType =
        | AchCreditTransfer
        | AchDebit
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
        | SepaDebit
        | Sofort
        | StripeAccount
        | Wechat

    and PaymentMethodDetailsAchCreditTransfer = {
        ///Account number to transfer funds to.
        AccountNumber: string option
        ///Name of the bank associated with the routing number.
        BankName: string option
        ///Routing transit number for the bank account to transfer funds to.
        RoutingNumber: string option
        ///SWIFT code of the bank associated with the routing number.
        SwiftCode: string option
    }
    with

        static member Create (accountNumber: string option, bankName: string option, routingNumber: string option, swiftCode: string option) =
            {
                PaymentMethodDetailsAchCreditTransfer.AccountNumber = accountNumber //required
                PaymentMethodDetailsAchCreditTransfer.BankName = bankName //required
                PaymentMethodDetailsAchCreditTransfer.RoutingNumber = routingNumber //required
                PaymentMethodDetailsAchCreditTransfer.SwiftCode = swiftCode //required
            }

    and PaymentMethodDetailsAchDebit = {
        ///Type of entity that holds the account. This can be either `individual` or `company`.
        AccountHolderType: PaymentMethodDetailsAchDebitAccountHolderType option
        ///Name of the bank associated with the bank account.
        BankName: string option
        ///Two-letter ISO code representing the country the bank account is located in.
        Country: string option
        ///Uniquely identifies this particular bank account. You can use this attribute to check whether two bank accounts are the same.
        Fingerprint: string option
        ///Last four digits of the bank account number.
        [<JsonField(Name="last4")>]Last4: string option
        ///Routing transit number of the bank account.
        RoutingNumber: string option
    }
    with

        static member Create (accountHolderType: PaymentMethodDetailsAchDebitAccountHolderType option, bankName: string option, country: string option, fingerprint: string option, last4: string option, routingNumber: string option) =
            {
                PaymentMethodDetailsAchDebit.AccountHolderType = accountHolderType //required
                PaymentMethodDetailsAchDebit.BankName = bankName //required
                PaymentMethodDetailsAchDebit.Country = country //required
                PaymentMethodDetailsAchDebit.Fingerprint = fingerprint //required
                PaymentMethodDetailsAchDebit.Last4 = last4 //required
                PaymentMethodDetailsAchDebit.RoutingNumber = routingNumber //required
            }

    and PaymentMethodDetailsAchDebitAccountHolderType =
        | Company
        | Individual

    and PaymentMethodDetailsAcssDebit = {
        ///Name of the bank associated with the bank account.
        BankName: string option
        ///Uniquely identifies this particular bank account. You can use this attribute to check whether two bank accounts are the same.
        Fingerprint: string option
        ///Institution number of the bank account
        InstitutionNumber: string option
        ///Last four digits of the bank account number.
        [<JsonField(Name="last4")>]Last4: string option
        ///ID of the mandate used to make this payment.
        Mandate: string option
        ///Transit number of the bank account.
        TransitNumber: string option
    }
    with

        static member Create (bankName: string option, fingerprint: string option, institutionNumber: string option, last4: string option, transitNumber: string option, ?mandate: string) =
            {
                PaymentMethodDetailsAcssDebit.BankName = bankName //required
                PaymentMethodDetailsAcssDebit.Fingerprint = fingerprint //required
                PaymentMethodDetailsAcssDebit.InstitutionNumber = institutionNumber //required
                PaymentMethodDetailsAcssDebit.Last4 = last4 //required
                PaymentMethodDetailsAcssDebit.TransitNumber = transitNumber //required
                PaymentMethodDetailsAcssDebit.Mandate = mandate
            }

    and PaymentMethodDetailsAuBecsDebit = {
        ///Bank-State-Branch number of the bank account.
        BsbNumber: string option
        ///Uniquely identifies this particular bank account. You can use this attribute to check whether two bank accounts are the same.
        Fingerprint: string option
        ///Last four digits of the bank account number.
        [<JsonField(Name="last4")>]Last4: string option
        ///ID of the mandate used to make this payment.
        Mandate: string option
    }
    with

        static member Create (bsbNumber: string option, fingerprint: string option, last4: string option, ?mandate: string) =
            {
                PaymentMethodDetailsAuBecsDebit.BsbNumber = bsbNumber //required
                PaymentMethodDetailsAuBecsDebit.Fingerprint = fingerprint //required
                PaymentMethodDetailsAuBecsDebit.Last4 = last4 //required
                PaymentMethodDetailsAuBecsDebit.Mandate = mandate
            }

    and PaymentMethodDetailsBacsDebit = {
        ///Uniquely identifies this particular bank account. You can use this attribute to check whether two bank accounts are the same.
        Fingerprint: string option
        ///Last four digits of the bank account number.
        [<JsonField(Name="last4")>]Last4: string option
        ///ID of the mandate used to make this payment.
        Mandate: string option
        ///Sort code of the bank account. (e.g., `10-20-30`)
        SortCode: string option
    }
    with

        static member Create (fingerprint: string option, last4: string option, mandate: string option, sortCode: string option) =
            {
                PaymentMethodDetailsBacsDebit.Fingerprint = fingerprint //required
                PaymentMethodDetailsBacsDebit.Last4 = last4 //required
                PaymentMethodDetailsBacsDebit.Mandate = mandate //required
                PaymentMethodDetailsBacsDebit.SortCode = sortCode //required
            }

    and PaymentMethodDetailsBancontact = {
        ///Bank code of bank associated with the bank account.
        BankCode: string option
        ///Name of the bank associated with the bank account.
        BankName: string option
        ///Bank Identifier Code of the bank associated with the bank account.
        Bic: string option
        ///The ID of the SEPA Direct Debit PaymentMethod which was generated by this Charge.
        [<JsonField(Transform=typeof<AnyOfTransform<PaymentMethodDetailsBancontactGeneratedSepaDebit'AnyOf>>)>]GeneratedSepaDebit: PaymentMethodDetailsBancontactGeneratedSepaDebit'AnyOf option
        ///The mandate for the SEPA Direct Debit PaymentMethod which was generated by this Charge.
        [<JsonField(Transform=typeof<AnyOfTransform<PaymentMethodDetailsBancontactGeneratedSepaDebitMandate'AnyOf>>)>]GeneratedSepaDebitMandate: PaymentMethodDetailsBancontactGeneratedSepaDebitMandate'AnyOf option
        ///Last four characters of the IBAN.
        [<JsonField(Name="iban_last4")>]IbanLast4: string option
        ///Preferred language of the Bancontact authorization page that the customer is redirected to.
    ///Can be one of `en`, `de`, `fr`, or `nl`
        PreferredLanguage: PaymentMethodDetailsBancontactPreferredLanguage option
        ///Owner's verified full name. Values are verified or provided by Bancontact directly
    ///(if supported) at the time of authorization or settlement. They cannot be set or mutated.
        VerifiedName: string option
    }
    with

        static member Create (bankCode: string option, bankName: string option, bic: string option, generatedSepaDebit: PaymentMethodDetailsBancontactGeneratedSepaDebit'AnyOf option, generatedSepaDebitMandate: PaymentMethodDetailsBancontactGeneratedSepaDebitMandate'AnyOf option, ibanLast4: string option, preferredLanguage: PaymentMethodDetailsBancontactPreferredLanguage option, verifiedName: string option) =
            {
                PaymentMethodDetailsBancontact.BankCode = bankCode //required
                PaymentMethodDetailsBancontact.BankName = bankName //required
                PaymentMethodDetailsBancontact.Bic = bic //required
                PaymentMethodDetailsBancontact.GeneratedSepaDebit = generatedSepaDebit //required
                PaymentMethodDetailsBancontact.GeneratedSepaDebitMandate = generatedSepaDebitMandate //required
                PaymentMethodDetailsBancontact.IbanLast4 = ibanLast4 //required
                PaymentMethodDetailsBancontact.PreferredLanguage = preferredLanguage //required
                PaymentMethodDetailsBancontact.VerifiedName = verifiedName //required
            }

    and PaymentMethodDetailsBancontactGeneratedSepaDebit'AnyOf =
        | String of string
        | PaymentMethod of PaymentMethod

    and PaymentMethodDetailsBancontactGeneratedSepaDebitMandate'AnyOf =
        | String of string
        | Mandate of Mandate

    and PaymentMethodDetailsBancontactPreferredLanguage =
        | De
        | En
        | Fr
        | Nl

    and PaymentMethodDetailsCard = {
        ///Card brand. Can be `amex`, `diners`, `discover`, `jcb`, `mastercard`, `unionpay`, `visa`, or `unknown`.
        Brand: PaymentMethodDetailsCardBrand option
        ///Check results by Card networks on Card address and CVC at time of payment.
        Checks: PaymentMethodDetailsCardChecks option
        ///Two-letter ISO code representing the country of the card. You could use this attribute to get a sense of the international breakdown of cards you've collected.
        Country: string option
        ///A high-level description of the type of cards issued in this range. (For internal use only and not typically available in standard API requests.)
        Description: string option
        ///Two-digit number representing the card's expiration month.
        ExpMonth: int
        ///Four-digit number representing the card's expiration year.
        ExpYear: int
        ///Uniquely identifies this particular card number. You can use this attribute to check whether two customers who’ve signed up with you are using the same card number, for example. For payment methods that tokenize card information (Apple Pay, Google Pay), the tokenized number might be provided instead of the underlying card number.
        Fingerprint: string option
        ///Card funding type. Can be `credit`, `debit`, `prepaid`, or `unknown`.
        Funding: PaymentMethodDetailsCardFunding option
        ///Issuer identification number of the card. (For internal use only and not typically available in standard API requests.)
        Iin: string option
        ///Installment details for this payment (Mexico only).
    ///For more information, see the [installments integration guide](https://stripe.com/docs/payments/installments).
        Installments: PaymentMethodDetailsCardInstallments option
        ///The name of the card's issuing bank. (For internal use only and not typically available in standard API requests.)
        Issuer: string option
        ///The last four digits of the card.
        [<JsonField(Name="last4")>]Last4: string option
        ///True if this payment was marked as MOTO and out of scope for SCA.
        Moto: bool option
        ///Identifies which network this charge was processed on. Can be `amex`, `cartes_bancaires`, `diners`, `discover`, `interac`, `jcb`, `mastercard`, `unionpay`, `visa`, or `unknown`.
        Network: PaymentMethodDetailsCardNetwork option
        ///Populated if this transaction used 3D Secure authentication.
        ThreeDSecure: ThreeDSecureDetails option
        ///If this Card is part of a card wallet, this contains the details of the card wallet.
        Wallet: PaymentMethodDetailsCardWallet option
    }
    with

        static member Create (brand: PaymentMethodDetailsCardBrand option, checks: PaymentMethodDetailsCardChecks option, country: string option, expMonth: int, expYear: int, funding: PaymentMethodDetailsCardFunding option, installments: PaymentMethodDetailsCardInstallments option, last4: string option, network: PaymentMethodDetailsCardNetwork option, threeDSecure: ThreeDSecureDetails option, wallet: PaymentMethodDetailsCardWallet option, ?description: string option, ?fingerprint: string option, ?iin: string option, ?issuer: string option, ?moto: bool option) =
            {
                PaymentMethodDetailsCard.Brand = brand //required
                PaymentMethodDetailsCard.Checks = checks //required
                PaymentMethodDetailsCard.Country = country //required
                PaymentMethodDetailsCard.ExpMonth = expMonth //required
                PaymentMethodDetailsCard.ExpYear = expYear //required
                PaymentMethodDetailsCard.Funding = funding //required
                PaymentMethodDetailsCard.Installments = installments //required
                PaymentMethodDetailsCard.Last4 = last4 //required
                PaymentMethodDetailsCard.Network = network //required
                PaymentMethodDetailsCard.ThreeDSecure = threeDSecure //required
                PaymentMethodDetailsCard.Wallet = wallet //required
                PaymentMethodDetailsCard.Description = description |> Option.flatten
                PaymentMethodDetailsCard.Fingerprint = fingerprint |> Option.flatten
                PaymentMethodDetailsCard.Iin = iin |> Option.flatten
                PaymentMethodDetailsCard.Issuer = issuer |> Option.flatten
                PaymentMethodDetailsCard.Moto = moto |> Option.flatten
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

    and PaymentMethodDetailsCardChecks = {
        ///If a address line1 was provided, results of the check, one of `pass`, `fail`, `unavailable`, or `unchecked`.
        [<JsonField(Name="address_line1_check")>]AddressLine1Check: PaymentMethodDetailsCardChecksAddressLine1Check option
        ///If a address postal code was provided, results of the check, one of `pass`, `fail`, `unavailable`, or `unchecked`.
        AddressPostalCodeCheck: PaymentMethodDetailsCardChecksAddressPostalCodeCheck option
        ///If a CVC was provided, results of the check, one of `pass`, `fail`, `unavailable`, or `unchecked`.
        CvcCheck: PaymentMethodDetailsCardChecksCvcCheck option
    }
    with

        static member Create (addressLine1Check: PaymentMethodDetailsCardChecksAddressLine1Check option, addressPostalCodeCheck: PaymentMethodDetailsCardChecksAddressPostalCodeCheck option, cvcCheck: PaymentMethodDetailsCardChecksCvcCheck option) =
            {
                PaymentMethodDetailsCardChecks.AddressLine1Check = addressLine1Check //required
                PaymentMethodDetailsCardChecks.AddressPostalCodeCheck = addressPostalCodeCheck //required
                PaymentMethodDetailsCardChecks.CvcCheck = cvcCheck //required
            }

    and PaymentMethodDetailsCardChecksAddressLine1Check =
        | Pass
        | Fail
        | Unavailable
        | Unchecked

    and PaymentMethodDetailsCardChecksAddressPostalCodeCheck =
        | Pass
        | Fail
        | Unavailable
        | Unchecked

    and PaymentMethodDetailsCardChecksCvcCheck =
        | Pass
        | Fail
        | Unavailable
        | Unchecked

    and PaymentMethodDetailsCardInstallments = {
        ///Installment plan selected for the payment.
        Plan: PaymentMethodDetailsCardInstallmentsPlan option
    }
    with

        static member Create (plan: PaymentMethodDetailsCardInstallmentsPlan option) =
            {
                PaymentMethodDetailsCardInstallments.Plan = plan //required
            }

    and PaymentMethodDetailsCardInstallmentsPlan = {
        ///For `fixed_count` installment plans, this is the number of installment payments your customer will make to their credit card.
        Count: int option
    }
    with
        ///For `fixed_count` installment plans, this is the interval between installment payments your customer will make to their credit card.
    ///One of `month`.
        member _.Interval = "month"
        ///Type of installment plan, one of `fixed_count`.
        member _.Type = "fixed_count"

        static member Create (count: int option) =
            {
                PaymentMethodDetailsCardInstallmentsPlan.Count = count //required
            }

    and PaymentMethodDetailsCardPresent = {
        ///Card brand. Can be `amex`, `diners`, `discover`, `jcb`, `mastercard`, `unionpay`, `visa`, or `unknown`.
        Brand: PaymentMethodDetailsCardPresentBrand option
        ///The cardholder name as read from the card, in [ISO 7813](https://en.wikipedia.org/wiki/ISO/IEC_7813) format. May include alphanumeric characters, special characters and first/last name separator (`/`).
        CardholderName: string option
        ///Two-letter ISO code representing the country of the card. You could use this attribute to get a sense of the international breakdown of cards you've collected.
        Country: string option
        ///A high-level description of the type of cards issued in this range. (For internal use only and not typically available in standard API requests.)
        Description: string option
        ///Authorization response cryptogram.
        EmvAuthData: string option
        ///Two-digit number representing the card's expiration month.
        ExpMonth: int
        ///Four-digit number representing the card's expiration year.
        ExpYear: int
        ///Uniquely identifies this particular card number. You can use this attribute to check whether two customers who’ve signed up with you are using the same card number, for example. For payment methods that tokenize card information (Apple Pay, Google Pay), the tokenized number might be provided instead of the underlying card number.
        Fingerprint: string option
        ///Card funding type. Can be `credit`, `debit`, `prepaid`, or `unknown`.
        Funding: PaymentMethodDetailsCardPresentFunding option
        ///ID of a card PaymentMethod generated from the card_present PaymentMethod that may be attached to a Customer for future transactions. Only present if it was possible to generate a card PaymentMethod.
        GeneratedCard: string option
        ///Issuer identification number of the card. (For internal use only and not typically available in standard API requests.)
        Iin: string option
        ///The name of the card's issuing bank. (For internal use only and not typically available in standard API requests.)
        Issuer: string option
        ///The last four digits of the card.
        [<JsonField(Name="last4")>]Last4: string option
        ///Identifies which network this charge was processed on. Can be `amex`, `cartes_bancaires`, `diners`, `discover`, `interac`, `jcb`, `mastercard`, `unionpay`, `visa`, or `unknown`.
        Network: PaymentMethodDetailsCardPresentNetwork option
        ///How card details were read in this transaction.
        ReadMethod: PaymentMethodDetailsCardPresentReadMethod option
        ///A collection of fields required to be displayed on receipts. Only required for EMV transactions.
        Receipt: PaymentMethodDetailsCardPresentReceipt option
    }
    with

        static member Create (brand: PaymentMethodDetailsCardPresentBrand option, cardholderName: string option, country: string option, emvAuthData: string option, expMonth: int, expYear: int, fingerprint: string option, funding: PaymentMethodDetailsCardPresentFunding option, generatedCard: string option, last4: string option, network: PaymentMethodDetailsCardPresentNetwork option, readMethod: PaymentMethodDetailsCardPresentReadMethod option, receipt: PaymentMethodDetailsCardPresentReceipt option, ?description: string option, ?iin: string option, ?issuer: string option) =
            {
                PaymentMethodDetailsCardPresent.Brand = brand //required
                PaymentMethodDetailsCardPresent.CardholderName = cardholderName //required
                PaymentMethodDetailsCardPresent.Country = country //required
                PaymentMethodDetailsCardPresent.EmvAuthData = emvAuthData //required
                PaymentMethodDetailsCardPresent.ExpMonth = expMonth //required
                PaymentMethodDetailsCardPresent.ExpYear = expYear //required
                PaymentMethodDetailsCardPresent.Fingerprint = fingerprint //required
                PaymentMethodDetailsCardPresent.Funding = funding //required
                PaymentMethodDetailsCardPresent.GeneratedCard = generatedCard //required
                PaymentMethodDetailsCardPresent.Last4 = last4 //required
                PaymentMethodDetailsCardPresent.Network = network //required
                PaymentMethodDetailsCardPresent.ReadMethod = readMethod //required
                PaymentMethodDetailsCardPresent.Receipt = receipt //required
                PaymentMethodDetailsCardPresent.Description = description |> Option.flatten
                PaymentMethodDetailsCardPresent.Iin = iin |> Option.flatten
                PaymentMethodDetailsCardPresent.Issuer = issuer |> Option.flatten
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

    and PaymentMethodDetailsCardPresentReceipt = {
        ///The type of account being debited or credited
        AccountType: PaymentMethodDetailsCardPresentReceiptAccountType option
        ///EMV tag 9F26, cryptogram generated by the integrated circuit chip.
        ApplicationCryptogram: string option
        ///Mnenomic of the Application Identifier.
        ApplicationPreferredName: string option
        ///Identifier for this transaction.
        AuthorizationCode: string option
        ///EMV tag 8A. A code returned by the card issuer.
        AuthorizationResponseCode: string option
        ///How the cardholder verified ownership of the card.
        CardholderVerificationMethod: string option
        ///EMV tag 84. Similar to the application identifier stored on the integrated circuit chip.
        DedicatedFileName: string option
        ///The outcome of a series of EMV functions performed by the card reader.
        TerminalVerificationResults: string option
        ///An indication of various EMV functions performed during the transaction.
        TransactionStatusInformation: string option
    }
    with

        static member Create (applicationCryptogram: string option, applicationPreferredName: string option, authorizationCode: string option, authorizationResponseCode: string option, cardholderVerificationMethod: string option, dedicatedFileName: string option, terminalVerificationResults: string option, transactionStatusInformation: string option, ?accountType: PaymentMethodDetailsCardPresentReceiptAccountType) =
            {
                PaymentMethodDetailsCardPresentReceipt.ApplicationCryptogram = applicationCryptogram //required
                PaymentMethodDetailsCardPresentReceipt.ApplicationPreferredName = applicationPreferredName //required
                PaymentMethodDetailsCardPresentReceipt.AuthorizationCode = authorizationCode //required
                PaymentMethodDetailsCardPresentReceipt.AuthorizationResponseCode = authorizationResponseCode //required
                PaymentMethodDetailsCardPresentReceipt.CardholderVerificationMethod = cardholderVerificationMethod //required
                PaymentMethodDetailsCardPresentReceipt.DedicatedFileName = dedicatedFileName //required
                PaymentMethodDetailsCardPresentReceipt.TerminalVerificationResults = terminalVerificationResults //required
                PaymentMethodDetailsCardPresentReceipt.TransactionStatusInformation = transactionStatusInformation //required
                PaymentMethodDetailsCardPresentReceipt.AccountType = accountType
            }

    and PaymentMethodDetailsCardPresentReceiptAccountType =
        | Checking
        | Credit
        | Prepaid
        | Unknown

    and PaymentMethodDetailsCardWallet = {
        AmexExpressCheckout: PaymentMethodDetailsCardWalletAmexExpressCheckout option
        ApplePay: PaymentMethodDetailsCardWalletApplePay option
        ///(For tokenized numbers only.) The last four digits of the device account number.
        [<JsonField(Name="dynamic_last4")>]DynamicLast4: string option
        GooglePay: PaymentMethodDetailsCardWalletGooglePay option
        Masterpass: PaymentMethodDetailsCardWalletMasterpass option
        SamsungPay: PaymentMethodDetailsCardWalletSamsungPay option
        ///The type of the card wallet, one of `amex_express_checkout`, `apple_pay`, `google_pay`, `masterpass`, `samsung_pay`, or `visa_checkout`. An additional hash is included on the Wallet subhash with a name matching this value. It contains additional information specific to the card wallet type.
        Type: PaymentMethodDetailsCardWalletType
        VisaCheckout: PaymentMethodDetailsCardWalletVisaCheckout option
    }
    with

        static member Create (dynamicLast4: string option, ``type``: PaymentMethodDetailsCardWalletType, ?amexExpressCheckout: PaymentMethodDetailsCardWalletAmexExpressCheckout, ?applePay: PaymentMethodDetailsCardWalletApplePay, ?googlePay: PaymentMethodDetailsCardWalletGooglePay, ?masterpass: PaymentMethodDetailsCardWalletMasterpass, ?samsungPay: PaymentMethodDetailsCardWalletSamsungPay, ?visaCheckout: PaymentMethodDetailsCardWalletVisaCheckout) =
            {
                PaymentMethodDetailsCardWallet.DynamicLast4 = dynamicLast4 //required
                PaymentMethodDetailsCardWallet.Type = ``type`` //required
                PaymentMethodDetailsCardWallet.AmexExpressCheckout = amexExpressCheckout
                PaymentMethodDetailsCardWallet.ApplePay = applePay
                PaymentMethodDetailsCardWallet.GooglePay = googlePay
                PaymentMethodDetailsCardWallet.Masterpass = masterpass
                PaymentMethodDetailsCardWallet.SamsungPay = samsungPay
                PaymentMethodDetailsCardWallet.VisaCheckout = visaCheckout
            }

    and PaymentMethodDetailsCardWalletType =
        | AmexExpressCheckout
        | ApplePay
        | GooglePay
        | Masterpass
        | SamsungPay
        | VisaCheckout

    and PaymentMethodDetailsCardWalletAmexExpressCheckout = {
        PaymentMethodDetailsCardWalletAmexExpressCheckout: string option
    }
    with

        static member Create (?paymentMethodDetailsCardWalletAmexExpressCheckout: string option) =
            {
                PaymentMethodDetailsCardWalletAmexExpressCheckout.PaymentMethodDetailsCardWalletAmexExpressCheckout = paymentMethodDetailsCardWalletAmexExpressCheckout |> Option.flatten
            }

    and PaymentMethodDetailsCardWalletApplePay = {
        PaymentMethodDetailsCardWalletApplePay: string option
    }
    with

        static member Create (?paymentMethodDetailsCardWalletApplePay: string option) =
            {
                PaymentMethodDetailsCardWalletApplePay.PaymentMethodDetailsCardWalletApplePay = paymentMethodDetailsCardWalletApplePay |> Option.flatten
            }

    and PaymentMethodDetailsCardWalletGooglePay = {
        PaymentMethodDetailsCardWalletGooglePay: string option
    }
    with

        static member Create (?paymentMethodDetailsCardWalletGooglePay: string option) =
            {
                PaymentMethodDetailsCardWalletGooglePay.PaymentMethodDetailsCardWalletGooglePay = paymentMethodDetailsCardWalletGooglePay |> Option.flatten
            }

    and PaymentMethodDetailsCardWalletMasterpass = {
        ///Owner's verified billing address. Values are verified or provided by the wallet directly (if supported) at the time of authorization or settlement. They cannot be set or mutated.
        BillingAddress: Address option
        ///Owner's verified email. Values are verified or provided by the wallet directly (if supported) at the time of authorization or settlement. They cannot be set or mutated.
        Email: string option
        ///Owner's verified full name. Values are verified or provided by the wallet directly (if supported) at the time of authorization or settlement. They cannot be set or mutated.
        Name: string option
        ///Owner's verified shipping address. Values are verified or provided by the wallet directly (if supported) at the time of authorization or settlement. They cannot be set or mutated.
        ShippingAddress: Address option
    }
    with

        static member Create (billingAddress: Address option, email: string option, name: string option, shippingAddress: Address option) =
            {
                PaymentMethodDetailsCardWalletMasterpass.BillingAddress = billingAddress //required
                PaymentMethodDetailsCardWalletMasterpass.Email = email //required
                PaymentMethodDetailsCardWalletMasterpass.Name = name //required
                PaymentMethodDetailsCardWalletMasterpass.ShippingAddress = shippingAddress //required
            }

    and PaymentMethodDetailsCardWalletSamsungPay = {
        PaymentMethodDetailsCardWalletSamsungPay: string option
    }
    with

        static member Create (?paymentMethodDetailsCardWalletSamsungPay: string option) =
            {
                PaymentMethodDetailsCardWalletSamsungPay.PaymentMethodDetailsCardWalletSamsungPay = paymentMethodDetailsCardWalletSamsungPay |> Option.flatten
            }

    and PaymentMethodDetailsCardWalletVisaCheckout = {
        ///Owner's verified billing address. Values are verified or provided by the wallet directly (if supported) at the time of authorization or settlement. They cannot be set or mutated.
        BillingAddress: Address option
        ///Owner's verified email. Values are verified or provided by the wallet directly (if supported) at the time of authorization or settlement. They cannot be set or mutated.
        Email: string option
        ///Owner's verified full name. Values are verified or provided by the wallet directly (if supported) at the time of authorization or settlement. They cannot be set or mutated.
        Name: string option
        ///Owner's verified shipping address. Values are verified or provided by the wallet directly (if supported) at the time of authorization or settlement. They cannot be set or mutated.
        ShippingAddress: Address option
    }
    with

        static member Create (billingAddress: Address option, email: string option, name: string option, shippingAddress: Address option) =
            {
                PaymentMethodDetailsCardWalletVisaCheckout.BillingAddress = billingAddress //required
                PaymentMethodDetailsCardWalletVisaCheckout.Email = email //required
                PaymentMethodDetailsCardWalletVisaCheckout.Name = name //required
                PaymentMethodDetailsCardWalletVisaCheckout.ShippingAddress = shippingAddress //required
            }

    and PaymentMethodDetailsEps = {
        ///Owner's verified full name. Values are verified or provided by EPS directly
    ///(if supported) at the time of authorization or settlement. They cannot be set or mutated.
    ///EPS rarely provides this information so the attribute is usually empty.
        VerifiedName: string option
    }
    with

        static member Create (verifiedName: string option) =
            {
                PaymentMethodDetailsEps.VerifiedName = verifiedName //required
            }

    and PaymentMethodDetailsFpx = {
        ///Account holder type, if provided. Can be one of `individual` or `company`.
        AccountHolderType: PaymentMethodDetailsFpxAccountHolderType option
        ///The customer's bank. Can be one of `affin_bank`, `alliance_bank`, `ambank`, `bank_islam`, `bank_muamalat`, `bank_rakyat`, `bsn`, `cimb`, `hong_leong_bank`, `hsbc`, `kfh`, `maybank2u`, `ocbc`, `public_bank`, `rhb`, `standard_chartered`, `uob`, `deutsche_bank`, `maybank2e`, or `pb_enterprise`.
        Bank: PaymentMethodDetailsFpxBank
        ///Unique transaction id generated by FPX for every request from the merchant
        TransactionId: string option
    }
    with

        static member Create (accountHolderType: PaymentMethodDetailsFpxAccountHolderType option, bank: PaymentMethodDetailsFpxBank, transactionId: string option) =
            {
                PaymentMethodDetailsFpx.AccountHolderType = accountHolderType //required
                PaymentMethodDetailsFpx.Bank = bank //required
                PaymentMethodDetailsFpx.TransactionId = transactionId //required
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

    and PaymentMethodDetailsGiropay = {
        ///Bank code of bank associated with the bank account.
        BankCode: string option
        ///Name of the bank associated with the bank account.
        BankName: string option
        ///Bank Identifier Code of the bank associated with the bank account.
        Bic: string option
        ///Owner's verified full name. Values are verified or provided by Giropay directly
    ///(if supported) at the time of authorization or settlement. They cannot be set or mutated.
    ///Giropay rarely provides this information so the attribute is usually empty.
        VerifiedName: string option
    }
    with

        static member Create (bankCode: string option, bankName: string option, bic: string option, verifiedName: string option) =
            {
                PaymentMethodDetailsGiropay.BankCode = bankCode //required
                PaymentMethodDetailsGiropay.BankName = bankName //required
                PaymentMethodDetailsGiropay.Bic = bic //required
                PaymentMethodDetailsGiropay.VerifiedName = verifiedName //required
            }

    and PaymentMethodDetailsGrabpay = {
        ///Unique transaction id generated by GrabPay
        TransactionId: string option
    }
    with

        static member Create (transactionId: string option) =
            {
                PaymentMethodDetailsGrabpay.TransactionId = transactionId //required
            }

    and PaymentMethodDetailsIdeal = {
        ///The customer's bank. Can be one of `abn_amro`, `asn_bank`, `bunq`, `handelsbanken`, `ing`, `knab`, `moneyou`, `rabobank`, `regiobank`, `sns_bank`, `triodos_bank`, or `van_lanschot`.
        Bank: PaymentMethodDetailsIdealBank option
        ///The Bank Identifier Code of the customer's bank.
        Bic: PaymentMethodDetailsIdealBic option
        ///The ID of the SEPA Direct Debit PaymentMethod which was generated by this Charge.
        [<JsonField(Transform=typeof<AnyOfTransform<PaymentMethodDetailsIdealGeneratedSepaDebit'AnyOf>>)>]GeneratedSepaDebit: PaymentMethodDetailsIdealGeneratedSepaDebit'AnyOf option
        ///The mandate for the SEPA Direct Debit PaymentMethod which was generated by this Charge.
        [<JsonField(Transform=typeof<AnyOfTransform<PaymentMethodDetailsIdealGeneratedSepaDebitMandate'AnyOf>>)>]GeneratedSepaDebitMandate: PaymentMethodDetailsIdealGeneratedSepaDebitMandate'AnyOf option
        ///Last four characters of the IBAN.
        [<JsonField(Name="iban_last4")>]IbanLast4: string option
        ///Owner's verified full name. Values are verified or provided by iDEAL directly
    ///(if supported) at the time of authorization or settlement. They cannot be set or mutated.
        VerifiedName: string option
    }
    with

        static member Create (bank: PaymentMethodDetailsIdealBank option, bic: PaymentMethodDetailsIdealBic option, generatedSepaDebit: PaymentMethodDetailsIdealGeneratedSepaDebit'AnyOf option, generatedSepaDebitMandate: PaymentMethodDetailsIdealGeneratedSepaDebitMandate'AnyOf option, ibanLast4: string option, verifiedName: string option) =
            {
                PaymentMethodDetailsIdeal.Bank = bank //required
                PaymentMethodDetailsIdeal.Bic = bic //required
                PaymentMethodDetailsIdeal.GeneratedSepaDebit = generatedSepaDebit //required
                PaymentMethodDetailsIdeal.GeneratedSepaDebitMandate = generatedSepaDebitMandate //required
                PaymentMethodDetailsIdeal.IbanLast4 = ibanLast4 //required
                PaymentMethodDetailsIdeal.VerifiedName = verifiedName //required
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

    and PaymentMethodDetailsIdealGeneratedSepaDebit'AnyOf =
        | String of string
        | PaymentMethod of PaymentMethod

    and PaymentMethodDetailsIdealGeneratedSepaDebitMandate'AnyOf =
        | String of string
        | Mandate of Mandate

    and PaymentMethodDetailsInteracPresent = {
        ///Card brand. Can be `interac`, `mastercard` or `visa`.
        Brand: PaymentMethodDetailsInteracPresentBrand option
        ///The cardholder name as read from the card, in [ISO 7813](https://en.wikipedia.org/wiki/ISO/IEC_7813) format. May include alphanumeric characters, special characters and first/last name separator (`/`).
        CardholderName: string option
        ///Two-letter ISO code representing the country of the card. You could use this attribute to get a sense of the international breakdown of cards you've collected.
        Country: string option
        ///A high-level description of the type of cards issued in this range. (For internal use only and not typically available in standard API requests.)
        Description: string option
        ///Authorization response cryptogram.
        EmvAuthData: string option
        ///Two-digit number representing the card's expiration month.
        ExpMonth: int
        ///Four-digit number representing the card's expiration year.
        ExpYear: int
        ///Uniquely identifies this particular card number. You can use this attribute to check whether two customers who’ve signed up with you are using the same card number, for example. For payment methods that tokenize card information (Apple Pay, Google Pay), the tokenized number might be provided instead of the underlying card number.
        Fingerprint: string option
        ///Card funding type. Can be `credit`, `debit`, `prepaid`, or `unknown`.
        Funding: PaymentMethodDetailsInteracPresentFunding option
        ///ID of a card PaymentMethod generated from the card_present PaymentMethod that may be attached to a Customer for future transactions. Only present if it was possible to generate a card PaymentMethod.
        GeneratedCard: string option
        ///Issuer identification number of the card. (For internal use only and not typically available in standard API requests.)
        Iin: string option
        ///The name of the card's issuing bank. (For internal use only and not typically available in standard API requests.)
        Issuer: string option
        ///The last four digits of the card.
        [<JsonField(Name="last4")>]Last4: string option
        ///Identifies which network this charge was processed on. Can be `amex`, `cartes_bancaires`, `diners`, `discover`, `interac`, `jcb`, `mastercard`, `unionpay`, `visa`, or `unknown`.
        Network: PaymentMethodDetailsInteracPresentNetwork option
        ///EMV tag 5F2D. Preferred languages specified by the integrated circuit chip.
        PreferredLocales: string list option
        ///How card details were read in this transaction.
        ReadMethod: PaymentMethodDetailsInteracPresentReadMethod option
        ///A collection of fields required to be displayed on receipts. Only required for EMV transactions.
        Receipt: PaymentMethodDetailsInteracPresentReceipt option
    }
    with

        static member Create (brand: PaymentMethodDetailsInteracPresentBrand option, cardholderName: string option, country: string option, emvAuthData: string option, expMonth: int, expYear: int, fingerprint: string option, funding: PaymentMethodDetailsInteracPresentFunding option, generatedCard: string option, last4: string option, network: PaymentMethodDetailsInteracPresentNetwork option, preferredLocales: string list option, readMethod: PaymentMethodDetailsInteracPresentReadMethod option, receipt: PaymentMethodDetailsInteracPresentReceipt option, ?description: string option, ?iin: string option, ?issuer: string option) =
            {
                PaymentMethodDetailsInteracPresent.Brand = brand //required
                PaymentMethodDetailsInteracPresent.CardholderName = cardholderName //required
                PaymentMethodDetailsInteracPresent.Country = country //required
                PaymentMethodDetailsInteracPresent.EmvAuthData = emvAuthData //required
                PaymentMethodDetailsInteracPresent.ExpMonth = expMonth //required
                PaymentMethodDetailsInteracPresent.ExpYear = expYear //required
                PaymentMethodDetailsInteracPresent.Fingerprint = fingerprint //required
                PaymentMethodDetailsInteracPresent.Funding = funding //required
                PaymentMethodDetailsInteracPresent.GeneratedCard = generatedCard //required
                PaymentMethodDetailsInteracPresent.Last4 = last4 //required
                PaymentMethodDetailsInteracPresent.Network = network //required
                PaymentMethodDetailsInteracPresent.PreferredLocales = preferredLocales //required
                PaymentMethodDetailsInteracPresent.ReadMethod = readMethod //required
                PaymentMethodDetailsInteracPresent.Receipt = receipt //required
                PaymentMethodDetailsInteracPresent.Description = description |> Option.flatten
                PaymentMethodDetailsInteracPresent.Iin = iin |> Option.flatten
                PaymentMethodDetailsInteracPresent.Issuer = issuer |> Option.flatten
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

    and PaymentMethodDetailsInteracPresentReceipt = {
        ///The type of account being debited or credited
        AccountType: PaymentMethodDetailsInteracPresentReceiptAccountType option
        ///EMV tag 9F26, cryptogram generated by the integrated circuit chip.
        ApplicationCryptogram: string option
        ///Mnenomic of the Application Identifier.
        ApplicationPreferredName: string option
        ///Identifier for this transaction.
        AuthorizationCode: string option
        ///EMV tag 8A. A code returned by the card issuer.
        AuthorizationResponseCode: string option
        ///How the cardholder verified ownership of the card.
        CardholderVerificationMethod: string option
        ///EMV tag 84. Similar to the application identifier stored on the integrated circuit chip.
        DedicatedFileName: string option
        ///The outcome of a series of EMV functions performed by the card reader.
        TerminalVerificationResults: string option
        ///An indication of various EMV functions performed during the transaction.
        TransactionStatusInformation: string option
    }
    with

        static member Create (applicationCryptogram: string option, applicationPreferredName: string option, authorizationCode: string option, authorizationResponseCode: string option, cardholderVerificationMethod: string option, dedicatedFileName: string option, terminalVerificationResults: string option, transactionStatusInformation: string option, ?accountType: PaymentMethodDetailsInteracPresentReceiptAccountType) =
            {
                PaymentMethodDetailsInteracPresentReceipt.ApplicationCryptogram = applicationCryptogram //required
                PaymentMethodDetailsInteracPresentReceipt.ApplicationPreferredName = applicationPreferredName //required
                PaymentMethodDetailsInteracPresentReceipt.AuthorizationCode = authorizationCode //required
                PaymentMethodDetailsInteracPresentReceipt.AuthorizationResponseCode = authorizationResponseCode //required
                PaymentMethodDetailsInteracPresentReceipt.CardholderVerificationMethod = cardholderVerificationMethod //required
                PaymentMethodDetailsInteracPresentReceipt.DedicatedFileName = dedicatedFileName //required
                PaymentMethodDetailsInteracPresentReceipt.TerminalVerificationResults = terminalVerificationResults //required
                PaymentMethodDetailsInteracPresentReceipt.TransactionStatusInformation = transactionStatusInformation //required
                PaymentMethodDetailsInteracPresentReceipt.AccountType = accountType
            }

    and PaymentMethodDetailsInteracPresentReceiptAccountType =
        | Checking
        | Savings
        | Unknown

    and PaymentMethodDetailsKlarna = {
        PaymentMethodDetailsKlarna: string option
    }
    with

        static member Create (?paymentMethodDetailsKlarna: string option) =
            {
                PaymentMethodDetailsKlarna.PaymentMethodDetailsKlarna = paymentMethodDetailsKlarna |> Option.flatten
            }

    and PaymentMethodDetailsMultibanco = {
        ///Entity number associated with this Multibanco payment.
        Entity: string option
        ///Reference number associated with this Multibanco payment.
        Reference: string option
    }
    with

        static member Create (entity: string option, reference: string option) =
            {
                PaymentMethodDetailsMultibanco.Entity = entity //required
                PaymentMethodDetailsMultibanco.Reference = reference //required
            }

    and PaymentMethodDetailsOxxo = {
        ///OXXO reference number
        Number: string option
    }
    with

        static member Create (number: string option) =
            {
                PaymentMethodDetailsOxxo.Number = number //required
            }

    and PaymentMethodDetailsP24 = {
        ///Unique reference for this Przelewy24 payment.
        Reference: string option
        ///Owner's verified full name. Values are verified or provided by Przelewy24 directly
    ///(if supported) at the time of authorization or settlement. They cannot be set or mutated.
    ///Przelewy24 rarely provides this information so the attribute is usually empty.
        VerifiedName: string option
    }
    with

        static member Create (reference: string option, verifiedName: string option) =
            {
                PaymentMethodDetailsP24.Reference = reference //required
                PaymentMethodDetailsP24.VerifiedName = verifiedName //required
            }

    and PaymentMethodDetailsSepaCreditTransfer = {
        ///Name of the bank associated with the bank account.
        BankName: string option
        ///Bank Identifier Code of the bank associated with the bank account.
        Bic: string option
        ///IBAN of the bank account to transfer funds to.
        Iban: string option
    }
    with

        static member Create (bankName: string option, bic: string option, iban: string option) =
            {
                PaymentMethodDetailsSepaCreditTransfer.BankName = bankName //required
                PaymentMethodDetailsSepaCreditTransfer.Bic = bic //required
                PaymentMethodDetailsSepaCreditTransfer.Iban = iban //required
            }

    and PaymentMethodDetailsSepaDebit = {
        ///Bank code of bank associated with the bank account.
        BankCode: string option
        ///Branch code of bank associated with the bank account.
        BranchCode: string option
        ///Two-letter ISO code representing the country the bank account is located in.
        Country: string option
        ///Uniquely identifies this particular bank account. You can use this attribute to check whether two bank accounts are the same.
        Fingerprint: string option
        ///Last four characters of the IBAN.
        [<JsonField(Name="last4")>]Last4: string option
        ///ID of the mandate used to make this payment.
        Mandate: string option
    }
    with

        static member Create (bankCode: string option, branchCode: string option, country: string option, fingerprint: string option, last4: string option, mandate: string option) =
            {
                PaymentMethodDetailsSepaDebit.BankCode = bankCode //required
                PaymentMethodDetailsSepaDebit.BranchCode = branchCode //required
                PaymentMethodDetailsSepaDebit.Country = country //required
                PaymentMethodDetailsSepaDebit.Fingerprint = fingerprint //required
                PaymentMethodDetailsSepaDebit.Last4 = last4 //required
                PaymentMethodDetailsSepaDebit.Mandate = mandate //required
            }

    and PaymentMethodDetailsSofort = {
        ///Bank code of bank associated with the bank account.
        BankCode: string option
        ///Name of the bank associated with the bank account.
        BankName: string option
        ///Bank Identifier Code of the bank associated with the bank account.
        Bic: string option
        ///Two-letter ISO code representing the country the bank account is located in.
        Country: string option
        ///The ID of the SEPA Direct Debit PaymentMethod which was generated by this Charge.
        [<JsonField(Transform=typeof<AnyOfTransform<PaymentMethodDetailsSofortGeneratedSepaDebit'AnyOf>>)>]GeneratedSepaDebit: PaymentMethodDetailsSofortGeneratedSepaDebit'AnyOf option
        ///The mandate for the SEPA Direct Debit PaymentMethod which was generated by this Charge.
        [<JsonField(Transform=typeof<AnyOfTransform<PaymentMethodDetailsSofortGeneratedSepaDebitMandate'AnyOf>>)>]GeneratedSepaDebitMandate: PaymentMethodDetailsSofortGeneratedSepaDebitMandate'AnyOf option
        ///Last four characters of the IBAN.
        [<JsonField(Name="iban_last4")>]IbanLast4: string option
        ///Preferred language of the SOFORT authorization page that the customer is redirected to.
    ///Can be one of `de`, `en`, `es`, `fr`, `it`, `nl`, or `pl`
        PreferredLanguage: PaymentMethodDetailsSofortPreferredLanguage option
        ///Owner's verified full name. Values are verified or provided by SOFORT directly
    ///(if supported) at the time of authorization or settlement. They cannot be set or mutated.
        VerifiedName: string option
    }
    with

        static member Create (bankCode: string option, bankName: string option, bic: string option, country: string option, generatedSepaDebit: PaymentMethodDetailsSofortGeneratedSepaDebit'AnyOf option, generatedSepaDebitMandate: PaymentMethodDetailsSofortGeneratedSepaDebitMandate'AnyOf option, ibanLast4: string option, preferredLanguage: PaymentMethodDetailsSofortPreferredLanguage option, verifiedName: string option) =
            {
                PaymentMethodDetailsSofort.BankCode = bankCode //required
                PaymentMethodDetailsSofort.BankName = bankName //required
                PaymentMethodDetailsSofort.Bic = bic //required
                PaymentMethodDetailsSofort.Country = country //required
                PaymentMethodDetailsSofort.GeneratedSepaDebit = generatedSepaDebit //required
                PaymentMethodDetailsSofort.GeneratedSepaDebitMandate = generatedSepaDebitMandate //required
                PaymentMethodDetailsSofort.IbanLast4 = ibanLast4 //required
                PaymentMethodDetailsSofort.PreferredLanguage = preferredLanguage //required
                PaymentMethodDetailsSofort.VerifiedName = verifiedName //required
            }

    and PaymentMethodDetailsSofortGeneratedSepaDebit'AnyOf =
        | String of string
        | PaymentMethod of PaymentMethod

    and PaymentMethodDetailsSofortGeneratedSepaDebitMandate'AnyOf =
        | String of string
        | Mandate of Mandate

    and PaymentMethodDetailsSofortPreferredLanguage =
        | De
        | En
        | Es
        | Fr
        | It
        | Nl
        | Pl

    and PaymentMethodDetailsStripeAccount = {
        PaymentMethodDetailsStripeAccount: string option
    }
    with

        static member Create (?paymentMethodDetailsStripeAccount: string option) =
            {
                PaymentMethodDetailsStripeAccount.PaymentMethodDetailsStripeAccount = paymentMethodDetailsStripeAccount |> Option.flatten
            }

    and PaymentMethodDetailsWechat = {
        PaymentMethodDetailsWechat: string option
    }
    with

        static member Create (?paymentMethodDetailsWechat: string option) =
            {
                PaymentMethodDetailsWechat.PaymentMethodDetailsWechat = paymentMethodDetailsWechat |> Option.flatten
            }

    and PaymentMethodEps = {
        PaymentMethodEps: string option
    }
    with

        static member Create (?paymentMethodEps: string option) =
            {
                PaymentMethodEps.PaymentMethodEps = paymentMethodEps |> Option.flatten
            }

    and PaymentMethodFpx = {
        ///Account holder type, if provided. Can be one of `individual` or `company`.
        AccountHolderType: PaymentMethodFpxAccountHolderType option
        ///The customer's bank, if provided. Can be one of `affin_bank`, `alliance_bank`, `ambank`, `bank_islam`, `bank_muamalat`, `bank_rakyat`, `bsn`, `cimb`, `hong_leong_bank`, `hsbc`, `kfh`, `maybank2u`, `ocbc`, `public_bank`, `rhb`, `standard_chartered`, `uob`, `deutsche_bank`, `maybank2e`, or `pb_enterprise`.
        Bank: PaymentMethodFpxBank
    }
    with

        static member Create (accountHolderType: PaymentMethodFpxAccountHolderType option, bank: PaymentMethodFpxBank) =
            {
                PaymentMethodFpx.AccountHolderType = accountHolderType //required
                PaymentMethodFpx.Bank = bank //required
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

    and PaymentMethodGiropay = {
        PaymentMethodGiropay: string option
    }
    with

        static member Create (?paymentMethodGiropay: string option) =
            {
                PaymentMethodGiropay.PaymentMethodGiropay = paymentMethodGiropay |> Option.flatten
            }

    and PaymentMethodGrabpay = {
        PaymentMethodGrabpay: string option
    }
    with

        static member Create (?paymentMethodGrabpay: string option) =
            {
                PaymentMethodGrabpay.PaymentMethodGrabpay = paymentMethodGrabpay |> Option.flatten
            }

    and PaymentMethodIdeal = {
        ///The customer's bank, if provided. Can be one of `abn_amro`, `asn_bank`, `bunq`, `handelsbanken`, `ing`, `knab`, `moneyou`, `rabobank`, `regiobank`, `sns_bank`, `triodos_bank`, or `van_lanschot`.
        Bank: PaymentMethodIdealBank option
        ///The Bank Identifier Code of the customer's bank, if the bank was provided.
        Bic: PaymentMethodIdealBic option
    }
    with

        static member Create (bank: PaymentMethodIdealBank option, bic: PaymentMethodIdealBic option) =
            {
                PaymentMethodIdeal.Bank = bank //required
                PaymentMethodIdeal.Bic = bic //required
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

    and PaymentMethodInteracPresent = {
        PaymentMethodInteracPresent: string option
    }
    with

        static member Create (?paymentMethodInteracPresent: string option) =
            {
                PaymentMethodInteracPresent.PaymentMethodInteracPresent = paymentMethodInteracPresent |> Option.flatten
            }

    and PaymentMethodOptionsAlipay = {
        PaymentMethodOptionsAlipay: string option
    }
    with

        static member Create (?paymentMethodOptionsAlipay: string option) =
            {
                PaymentMethodOptionsAlipay.PaymentMethodOptionsAlipay = paymentMethodOptionsAlipay |> Option.flatten
            }

    and PaymentMethodOptionsBancontact = {
        ///Preferred language of the Bancontact authorization page that the customer is redirected to.
        PreferredLanguage: PaymentMethodOptionsBancontactPreferredLanguage
    }
    with

        static member Create (preferredLanguage: PaymentMethodOptionsBancontactPreferredLanguage) =
            {
                PaymentMethodOptionsBancontact.PreferredLanguage = preferredLanguage //required
            }

    and PaymentMethodOptionsBancontactPreferredLanguage =
        | De
        | En
        | Fr
        | Nl

    and PaymentMethodOptionsCardInstallments = {
        ///Installment plans that may be selected for this PaymentIntent.
        AvailablePlans: PaymentMethodDetailsCardInstallmentsPlan list option
        ///Whether Installments are enabled for this PaymentIntent.
        Enabled: bool
        ///Installment plan selected for this PaymentIntent.
        Plan: PaymentMethodDetailsCardInstallmentsPlan option
    }
    with

        static member Create (availablePlans: PaymentMethodDetailsCardInstallmentsPlan list option, enabled: bool, plan: PaymentMethodDetailsCardInstallmentsPlan option) =
            {
                PaymentMethodOptionsCardInstallments.AvailablePlans = availablePlans //required
                PaymentMethodOptionsCardInstallments.Enabled = enabled //required
                PaymentMethodOptionsCardInstallments.Plan = plan //required
            }

    and PaymentMethodOptionsOxxo = {
        ///The number of calendar days before an OXXO invoice expires. For example, if you create an OXXO invoice on Monday and you set expires_after_days to 2, the OXXO invoice will expire on Wednesday at 23:59 America/Mexico_City time.
        ExpiresAfterDays: int
    }
    with

        static member Create (expiresAfterDays: int) =
            {
                PaymentMethodOptionsOxxo.ExpiresAfterDays = expiresAfterDays //required
            }

    and PaymentMethodOptionsP24 = {
        [<JsonField(Name="payment_method_options_p24")>]PaymentMethodOptionsP24: string option
    }
    with

        static member Create (?paymentMethodOptionsP24: string option) =
            {
                PaymentMethodOptionsP24.PaymentMethodOptionsP24 = paymentMethodOptionsP24 |> Option.flatten
            }

    and PaymentMethodOptionsSofort = {
        ///Preferred language of the SOFORT authorization page that the customer is redirected to.
        PreferredLanguage: PaymentMethodOptionsSofortPreferredLanguage option
    }
    with

        static member Create (preferredLanguage: PaymentMethodOptionsSofortPreferredLanguage option) =
            {
                PaymentMethodOptionsSofort.PreferredLanguage = preferredLanguage //required
            }

    and PaymentMethodOptionsSofortPreferredLanguage =
        | De
        | En
        | Es
        | Fr
        | It
        | Nl
        | Pl

    and PaymentMethodOxxo = {
        PaymentMethodOxxo: string option
    }
    with

        static member Create (?paymentMethodOxxo: string option) =
            {
                PaymentMethodOxxo.PaymentMethodOxxo = paymentMethodOxxo |> Option.flatten
            }

    and PaymentMethodP24 = {
        ///The customer's bank, if provided.
        Bank: PaymentMethodP24Bank option
    }
    with

        static member Create (bank: PaymentMethodP24Bank option) =
            {
                PaymentMethodP24.Bank = bank //required
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

    and PaymentMethodSepaDebit = {
        ///Bank code of bank associated with the bank account.
        BankCode: string option
        ///Branch code of bank associated with the bank account.
        BranchCode: string option
        ///Two-letter ISO code representing the country the bank account is located in.
        Country: string option
        ///Uniquely identifies this particular bank account. You can use this attribute to check whether two bank accounts are the same.
        Fingerprint: string option
        ///Information about the object that generated this PaymentMethod.
        GeneratedFrom: SepaDebitGeneratedFrom option
        ///Last four characters of the IBAN.
        [<JsonField(Name="last4")>]Last4: string option
    }
    with

        static member Create (bankCode: string option, branchCode: string option, country: string option, fingerprint: string option, generatedFrom: SepaDebitGeneratedFrom option, last4: string option) =
            {
                PaymentMethodSepaDebit.BankCode = bankCode //required
                PaymentMethodSepaDebit.BranchCode = branchCode //required
                PaymentMethodSepaDebit.Country = country //required
                PaymentMethodSepaDebit.Fingerprint = fingerprint //required
                PaymentMethodSepaDebit.GeneratedFrom = generatedFrom //required
                PaymentMethodSepaDebit.Last4 = last4 //required
            }

    and PaymentMethodSofort = {
        ///Two-letter ISO code representing the country the bank account is located in.
        Country: string option
    }
    with

        static member Create (country: string option) =
            {
                PaymentMethodSofort.Country = country //required
            }

    and PaymentPagesCheckoutSessionTotalDetails = {
        ///This is the sum of all the line item discounts.
        AmountDiscount: int
        ///This is the sum of all the line item tax amounts.
        AmountTax: int
        Breakdown: PaymentPagesCheckoutSessionTotalDetailsResourceBreakdown option
    }
    with

        static member Create (amountDiscount: int, amountTax: int, ?breakdown: PaymentPagesCheckoutSessionTotalDetailsResourceBreakdown) =
            {
                PaymentPagesCheckoutSessionTotalDetails.AmountDiscount = amountDiscount //required
                PaymentPagesCheckoutSessionTotalDetails.AmountTax = amountTax //required
                PaymentPagesCheckoutSessionTotalDetails.Breakdown = breakdown
            }

    and PaymentPagesCheckoutSessionTotalDetailsResourceBreakdown = {
        ///The aggregated line item discounts.
        Discounts: LineItemsDiscountAmount list
        ///The aggregated line item tax amounts by rate.
        Taxes: LineItemsTaxAmount list
    }
    with

        static member Create (discounts: LineItemsDiscountAmount list, taxes: LineItemsTaxAmount list) =
            {
                PaymentPagesCheckoutSessionTotalDetailsResourceBreakdown.Discounts = discounts //required
                PaymentPagesCheckoutSessionTotalDetailsResourceBreakdown.Taxes = taxes //required
            }

    and PaymentPagesPaymentPageResourcesShippingAddressCollection = {
        ///An array of two-letter ISO country codes representing which countries Checkout should provide as options for
    ///shipping locations. Unsupported country codes: `AS, CX, CC, CU, HM, IR, KP, MH, FM, NF, MP, PW, SD, SY, UM, VI`.
        AllowedCountries: PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries list
    }
    with

        static member Create (allowedCountries: PaymentPagesPaymentPageResourcesShippingAddressCollectionAllowedCountries list) =
            {
                PaymentPagesPaymentPageResourcesShippingAddressCollection.AllowedCountries = allowedCountries //required
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
    ///Related guide: [Receiving Payouts](https://stripe.com/docs/payouts).
    and Payout = {
        ///Amount (in %s) to be transferred to your bank account or debit card.
        Amount: int
        ///Date the payout is expected to arrive in the bank. This factors in delays like weekends or bank holidays.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]ArrivalDate: DateTime
        ///Returns `true` if the payout was created by an [automated payout schedule](https://stripe.com/docs/payouts#payout-schedule), and `false` if it was [requested manually](https://stripe.com/docs/payouts#manual-payouts).
        Automatic: bool
        ///ID of the balance transaction that describes the impact of this payout on your account balance.
        [<JsonField(Transform=typeof<AnyOfTransform<PayoutBalanceTransaction'AnyOf>>)>]BalanceTransaction: PayoutBalanceTransaction'AnyOf option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        ///ID of the bank account or card the payout was sent to.
        [<JsonField(Transform=typeof<AnyOfTransform<PayoutDestination'AnyOf>>)>]Destination: PayoutDestination'AnyOf option
        ///If the payout failed or was canceled, this will be the ID of the balance transaction that reversed the initial balance transaction, and puts the funds from the failed payout back in your balance.
        [<JsonField(Transform=typeof<AnyOfTransform<PayoutFailureBalanceTransaction'AnyOf>>)>]FailureBalanceTransaction: PayoutFailureBalanceTransaction'AnyOf option
        ///Error code explaining reason for payout failure if available. See [Types of payout failures](https://stripe.com/docs/api#payout_failures) for a list of failure codes.
        FailureCode: string option
        ///Message to user further explaining reason for payout failure if available.
        FailureMessage: string option
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        ///The method used to send this payout, which can be `standard` or `instant`. `instant` is only supported for payouts to debit cards. (See [Instant payouts for marketplaces](https://stripe.com/blog/instant-payouts-for-marketplaces) for more information.)
        Method: PayoutMethod
        ///If the payout reverses another, this is the ID of the original payout.
        [<JsonField(Transform=typeof<AnyOfTransform<PayoutOriginalPayout'AnyOf>>)>]OriginalPayout: PayoutOriginalPayout'AnyOf option
        ///If the payout was reversed, this is the ID of the payout that reverses this payout.
        [<JsonField(Transform=typeof<AnyOfTransform<PayoutReversedBy'AnyOf>>)>]ReversedBy: PayoutReversedBy'AnyOf option
        ///The source balance this payout came from. One of `card`, `fpx`, or `bank_account`.
        SourceType: PayoutSourceType
        ///Extra information about a payout to be displayed on the user's bank statement.
        StatementDescriptor: string option
        ///Current status of the payout: `paid`, `pending`, `in_transit`, `canceled` or `failed`. A payout is `pending` until it is submitted to the bank, when it becomes `in_transit`. The status then changes to `paid` if the transaction goes through, or to `failed` or `canceled` (within 5 business days). Some failed payouts may initially show as `paid` but then change to `failed`.
        Status: PayoutStatus
        ///Can be `bank_account` or `card`.
        Type: PayoutType
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "payout"

        static member Create (amount: int, arrivalDate: DateTime, automatic: bool, balanceTransaction: PayoutBalanceTransaction'AnyOf option, created: DateTime, currency: string, description: string option, destination: PayoutDestination'AnyOf option, failureBalanceTransaction: PayoutFailureBalanceTransaction'AnyOf option, failureCode: string option, failureMessage: string option, id: string, livemode: bool, metadata: Map<string, string> option, method: PayoutMethod, originalPayout: PayoutOriginalPayout'AnyOf option, reversedBy: PayoutReversedBy'AnyOf option, sourceType: PayoutSourceType, statementDescriptor: string option, status: PayoutStatus, ``type``: PayoutType) =
            {
                Payout.Amount = amount //required
                Payout.ArrivalDate = arrivalDate //required
                Payout.Automatic = automatic //required
                Payout.BalanceTransaction = balanceTransaction //required
                Payout.Created = created //required
                Payout.Currency = currency //required
                Payout.Description = description //required
                Payout.Destination = destination //required
                Payout.FailureBalanceTransaction = failureBalanceTransaction //required
                Payout.FailureCode = failureCode //required
                Payout.FailureMessage = failureMessage //required
                Payout.Id = id //required
                Payout.Livemode = livemode //required
                Payout.Metadata = metadata //required
                Payout.Method = method //required
                Payout.OriginalPayout = originalPayout //required
                Payout.ReversedBy = reversedBy //required
                Payout.SourceType = sourceType //required
                Payout.StatementDescriptor = statementDescriptor //required
                Payout.Status = status //required
                Payout.Type = ``type`` //required
            }

    and PayoutBalanceTransaction'AnyOf =
        | String of string
        | BalanceTransaction of BalanceTransaction

    and PayoutDestination'AnyOf =
        | String of string
        | ExternalAccount of ExternalAccount
        | DeletedExternalAccount of DeletedExternalAccount

    and PayoutFailureBalanceTransaction'AnyOf =
        | String of string
        | BalanceTransaction of BalanceTransaction

    and PayoutMethod =
        | Standard
        | Instant

    and PayoutOriginalPayout'AnyOf =
        | String of string
        | Payout of Payout

    and PayoutReversedBy'AnyOf =
        | String of string
        | Payout of Payout

    and PayoutSourceType =
        | Card
        | Fpx
        | BankAccount

    and PayoutStatus =
        | Paid
        | Pending
        | InTransit
        | Canceled
        | Failed

    and PayoutType =
        | BankAccount
        | Card

    and Period = {
        ///The end date of this usage period. All usage up to and including this point in time is included.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]End: DateTime option
        ///The start date of this usage period. All usage after this point in time is included.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Start: DateTime option
    }
    with

        static member Create (``end``: DateTime option, start: DateTime option) =
            {
                Period.End = ``end`` //required
                Period.Start = start //required
            }

    ///This is an object representing a person associated with a Stripe account.
    ///Related guide: [Handling Identity Verification with the API](https://stripe.com/docs/connect/identity-verification-api#person-information).
    and Person = {
        ///The account the person is associated with.
        Account: string option
        Address: Address option
        ///The Kana variation of the person's address (Japan only).
        AddressKana: LegalEntityJapanAddress option
        ///The Kanji variation of the person's address (Japan only).
        AddressKanji: LegalEntityJapanAddress option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        Dob: LegalEntityDob option
        ///The person's email address.
        Email: string option
        ///The person's first name.
        FirstName: string option
        ///The Kana variation of the person's first name (Japan only).
        FirstNameKana: string option
        ///The Kanji variation of the person's first name (Japan only).
        FirstNameKanji: string option
        ///The person's gender (International regulations require either "male" or "female").
        Gender: string option
        ///Unique identifier for the object.
        Id: string
        ///Whether the person's `id_number` was provided.
        IdNumberProvided: bool option
        ///The person's last name.
        LastName: string option
        ///The Kana variation of the person's last name (Japan only).
        LastNameKana: string option
        ///The Kanji variation of the person's last name (Japan only).
        LastNameKanji: string option
        ///The person's maiden name.
        MaidenName: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        ///The person's phone number.
        Phone: string option
        ///Indicates if the person or any of their representatives, family members, or other closely related persons, declares that they hold or have held an important public job or function, in any jurisdiction.
        PoliticalExposure: PersonPoliticalExposure option
        Relationship: PersonRelationship option
        ///Information about the requirements for this person, including what information needs to be collected, and by when.
        Requirements: PersonRequirements option
        ///Whether the last four digits of the person's Social Security number have been provided (U.S. only).
        SsnLast4Provided: bool option
        Verification: LegalEntityPersonVerification option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "person"

        static member Create (created: DateTime, id: string, ?account: string, ?address: Address, ?addressKana: LegalEntityJapanAddress option, ?addressKanji: LegalEntityJapanAddress option, ?dob: LegalEntityDob, ?email: string option, ?firstName: string option, ?firstNameKana: string option, ?firstNameKanji: string option, ?gender: string option, ?idNumberProvided: bool, ?lastName: string option, ?lastNameKana: string option, ?lastNameKanji: string option, ?maidenName: string option, ?metadata: Map<string, string>, ?phone: string option, ?politicalExposure: PersonPoliticalExposure, ?relationship: PersonRelationship, ?requirements: PersonRequirements option, ?ssnLast4Provided: bool, ?verification: LegalEntityPersonVerification) =
            {
                Person.Created = created //required
                Person.Id = id //required
                Person.Account = account
                Person.Address = address
                Person.AddressKana = addressKana |> Option.flatten
                Person.AddressKanji = addressKanji |> Option.flatten
                Person.Dob = dob
                Person.Email = email |> Option.flatten
                Person.FirstName = firstName |> Option.flatten
                Person.FirstNameKana = firstNameKana |> Option.flatten
                Person.FirstNameKanji = firstNameKanji |> Option.flatten
                Person.Gender = gender |> Option.flatten
                Person.IdNumberProvided = idNumberProvided
                Person.LastName = lastName |> Option.flatten
                Person.LastNameKana = lastNameKana |> Option.flatten
                Person.LastNameKanji = lastNameKanji |> Option.flatten
                Person.MaidenName = maidenName |> Option.flatten
                Person.Metadata = metadata
                Person.Phone = phone |> Option.flatten
                Person.PoliticalExposure = politicalExposure
                Person.Relationship = relationship
                Person.Requirements = requirements |> Option.flatten
                Person.SsnLast4Provided = ssnLast4Provided
                Person.Verification = verification
            }

    and PersonPoliticalExposure =
        | Existing
        | None'

    and PersonRelationship = {
        ///Whether the person is a director of the account's legal entity. Currently only required for accounts in the EU. Directors are typically members of the governing board of the company, or responsible for ensuring the company meets its regulatory obligations.
        Director: bool option
        ///Whether the person has significant responsibility to control, manage, or direct the organization.
        Executive: bool option
        ///Whether the person is an owner of the account’s legal entity.
        Owner: bool option
        ///The percent owned by the person of the account's legal entity.
        PercentOwnership: decimal option
        ///Whether the person is authorized as the primary representative of the account. This is the person nominated by the business to provide information about themselves, and general information about the account. There can only be one representative at any given time. At the time the account is created, this person should be set to the person responsible for opening the account.
        Representative: bool option
        ///The person's title (e.g., CEO, Support Engineer).
        Title: string option
    }
    with

        static member Create (director: bool option, executive: bool option, owner: bool option, percentOwnership: decimal option, representative: bool option, title: string option) =
            {
                PersonRelationship.Director = director //required
                PersonRelationship.Executive = executive //required
                PersonRelationship.Owner = owner //required
                PersonRelationship.PercentOwnership = percentOwnership //required
                PersonRelationship.Representative = representative //required
                PersonRelationship.Title = title //required
            }

    and PersonRequirements = {
        ///Fields that need to be collected to keep the person's account enabled. If not collected by the account's `current_deadline`, these fields appear in `past_due` as well, and the account is disabled.
        CurrentlyDue: string list
        ///The fields that are `currently_due` and need to be collected again because validation or verification failed for some reason.
        Errors: AccountRequirementsError list
        ///Fields that need to be collected assuming all volume thresholds are reached. As fields are needed, they are moved to `currently_due` and the account's `current_deadline` is set.
        EventuallyDue: string list
        ///Fields that weren't collected by the account's `current_deadline`. These fields need to be collected to enable payouts for the person's account.
        PastDue: string list
        ///Fields that may become required depending on the results of verification or review. An empty array unless an asynchronous verification is pending. If verification fails, the fields in this array become required and move to `currently_due` or `past_due`.
        PendingVerification: string list
    }
    with

        static member Create (currentlyDue: string list, errors: AccountRequirementsError list, eventuallyDue: string list, pastDue: string list, pendingVerification: string list) =
            {
                PersonRequirements.CurrentlyDue = currentlyDue //required
                PersonRequirements.Errors = errors //required
                PersonRequirements.EventuallyDue = eventuallyDue //required
                PersonRequirements.PastDue = pastDue //required
                PersonRequirements.PendingVerification = pendingVerification //required
            }

    ///You can now model subscriptions more flexibly using the [Prices API](https://stripe.com/docs/api#prices). It replaces the Plans API and is backwards compatible to simplify your migration.
    ///Plans define the base price, currency, and billing cycle for recurring purchases of products.
    ///[Products](https://stripe.com/docs/api#products) help you track inventory or provisioning, and plans help you track pricing. Different physical goods or levels of service should be represented by products, and pricing options should be represented by plans. This approach lets you change prices without having to change your provisioning scheme.
    ///For example, you might have a single "gold" product that has plans for $10/month, $100/year, €9/month, and €90/year.
    ///Related guides: [Set up a subscription](https://stripe.com/docs/billing/subscriptions/set-up-subscription) and more about [products and prices](https://stripe.com/docs/billing/prices-guide).
    and Plan = {
        ///Whether the plan can be used for new purchases.
        Active: bool
        ///Specifies a usage aggregation strategy for plans of `usage_type=metered`. Allowed values are `sum` for summing up all usage during a period, `last_during_period` for using the last usage record reported within a period, `last_ever` for using the last usage record ever (across period bounds) or `max` which uses the usage record with the maximum reported usage during a period. Defaults to `sum`.
        AggregateUsage: PlanAggregateUsage option
        ///The unit amount in %s to be charged, represented as a whole integer if possible.
        Amount: int option
        ///The unit amount in %s to be charged, represented as a decimal string with at most 12 decimal places.
        AmountDecimal: string option
        ///Describes how to compute the price per period. Either `per_unit` or `tiered`. `per_unit` indicates that the fixed amount (specified in `amount`) will be charged per unit in `quantity` (for plans with `usage_type=licensed`), or per unit of total usage (for plans with `usage_type=metered`). `tiered` indicates that the unit pricing will be computed using a tiering strategy as defined using the `tiers` and `tiers_mode` attributes.
        BillingScheme: PlanBillingScheme
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///Unique identifier for the object.
        Id: string
        ///The frequency at which a subscription is billed. One of `day`, `week`, `month` or `year`.
        Interval: PlanInterval
        ///The number of intervals (specified in the `interval` attribute) between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months.
        IntervalCount: int
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        ///A brief description of the plan, hidden from customers.
        Nickname: string option
        ///The product whose pricing this plan determines.
        [<JsonField(Transform=typeof<AnyOfTransform<PlanProduct'AnyOf>>)>]Product: PlanProduct'AnyOf option
        ///Each element represents a pricing tier. This parameter requires `billing_scheme` to be set to `tiered`. See also the documentation for `billing_scheme`.
        Tiers: PlanTier list option
        ///Defines if the tiering price should be `graduated` or `volume` based. In `volume`-based tiering, the maximum quantity within a period determines the per unit price. In `graduated` tiering, pricing can change as the quantity grows.
        TiersMode: PlanTiersMode option
        ///Apply a transformation to the reported usage or set quantity before computing the amount billed. Cannot be combined with `tiers`.
        TransformUsage: TransformUsage option
        ///Default number of trial days when subscribing a customer to this plan using [`trial_from_plan=true`](https://stripe.com/docs/api#create_subscription-trial_from_plan).
        TrialPeriodDays: int option
        ///Configures how the quantity per period should be determined. Can be either `metered` or `licensed`. `licensed` automatically bills the `quantity` set when adding it to a subscription. `metered` aggregates the total usage based on usage records. Defaults to `licensed`.
        UsageType: PlanUsageType
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "plan"

        static member Create (active: bool, aggregateUsage: PlanAggregateUsage option, amount: int option, amountDecimal: string option, billingScheme: PlanBillingScheme, created: DateTime, currency: string, id: string, interval: PlanInterval, intervalCount: int, livemode: bool, metadata: Map<string, string> option, nickname: string option, product: PlanProduct'AnyOf option, tiersMode: PlanTiersMode option, transformUsage: TransformUsage option, trialPeriodDays: int option, usageType: PlanUsageType, ?tiers: PlanTier list) =
            {
                Plan.Active = active //required
                Plan.AggregateUsage = aggregateUsage //required
                Plan.Amount = amount //required
                Plan.AmountDecimal = amountDecimal //required
                Plan.BillingScheme = billingScheme //required
                Plan.Created = created //required
                Plan.Currency = currency //required
                Plan.Id = id //required
                Plan.Interval = interval //required
                Plan.IntervalCount = intervalCount //required
                Plan.Livemode = livemode //required
                Plan.Metadata = metadata //required
                Plan.Nickname = nickname //required
                Plan.Product = product //required
                Plan.TiersMode = tiersMode //required
                Plan.TransformUsage = transformUsage //required
                Plan.TrialPeriodDays = trialPeriodDays //required
                Plan.UsageType = usageType //required
                Plan.Tiers = tiers
            }

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

    and PlanProduct'AnyOf =
        | String of string
        | Product of Product
        | DeletedProduct of DeletedProduct

    and PlanTiersMode =
        | Graduated
        | Volume

    and PlanUsageType =
        | Licensed
        | Metered

    and PlanTier = {
        ///Price for the entire tier.
        FlatAmount: int option
        ///Same as `flat_amount`, but contains a decimal value with at most 12 decimal places.
        FlatAmountDecimal: string option
        ///Per unit price for units relevant to the tier.
        UnitAmount: int option
        ///Same as `unit_amount`, but contains a decimal value with at most 12 decimal places.
        UnitAmountDecimal: string option
        ///Up to and including to this quantity will be contained in the tier.
        UpTo: int option
    }
    with

        static member Create (flatAmount: int option, flatAmountDecimal: string option, unitAmount: int option, unitAmountDecimal: string option, upTo: int option) =
            {
                PlanTier.FlatAmount = flatAmount //required
                PlanTier.FlatAmountDecimal = flatAmountDecimal //required
                PlanTier.UnitAmount = unitAmount //required
                PlanTier.UnitAmountDecimal = unitAmountDecimal //required
                PlanTier.UpTo = upTo //required
            }

    and PlatformTaxFee = {
        ///The Connected account that incurred this charge.
        Account: string
        ///Unique identifier for the object.
        Id: string
        ///The payment object that caused this tax to be inflicted.
        SourceTransaction: string
        ///The type of tax (VAT).
        Type: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "platform_tax_fee"

        static member Create (account: string, id: string, sourceTransaction: string, ``type``: string) =
            {
                PlatformTaxFee.Account = account //required
                PlatformTaxFee.Id = id //required
                PlatformTaxFee.SourceTransaction = sourceTransaction //required
                PlatformTaxFee.Type = ``type`` //required
            }

    ///Prices define the unit cost, currency, and (optional) billing cycle for both recurring and one-time purchases of products.
    ///[Products](https://stripe.com/docs/api#products) help you track inventory or provisioning, and prices help you track payment terms. Different physical goods or levels of service should be represented by products, and pricing options should be represented by prices. This approach lets you change prices without having to change your provisioning scheme.
    ///For example, you might have a single "gold" product that has prices for $10/month, $100/year, and €9 once.
    ///Related guides: [Set up a subscription](https://stripe.com/docs/billing/subscriptions/set-up-subscription), [create an invoice](https://stripe.com/docs/billing/invoices/create), and more about [products and prices](https://stripe.com/docs/billing/prices-guide).
    and Price = {
        ///Whether the price can be used for new purchases.
        Active: bool
        ///Describes how to compute the price per period. Either `per_unit` or `tiered`. `per_unit` indicates that the fixed amount (specified in `unit_amount` or `unit_amount_decimal`) will be charged per unit in `quantity` (for prices with `usage_type=licensed`), or per unit of total usage (for prices with `usage_type=metered`). `tiered` indicates that the unit pricing will be computed using a tiering strategy as defined using the `tiers` and `tiers_mode` attributes.
        BillingScheme: PriceBillingScheme
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///A lookup key used to retrieve prices dynamically from a static string.
        LookupKey: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        ///A brief description of the plan, hidden from customers.
        Nickname: string option
        ///The ID of the product this price is associated with.
        [<JsonField(Transform=typeof<AnyOfTransform<PriceProduct'AnyOf>>)>]Product: PriceProduct'AnyOf
        ///The recurring components of a price such as `interval` and `usage_type`.
        Recurring: Recurring option
        ///Each element represents a pricing tier. This parameter requires `billing_scheme` to be set to `tiered`. See also the documentation for `billing_scheme`.
        Tiers: PriceTier list option
        ///Defines if the tiering price should be `graduated` or `volume` based. In `volume`-based tiering, the maximum quantity within a period determines the per unit price. In `graduated` tiering, pricing can change as the quantity grows.
        TiersMode: PriceTiersMode option
        ///Apply a transformation to the reported usage or set quantity before computing the amount billed. Cannot be combined with `tiers`.
        TransformQuantity: TransformQuantity option
        ///One of `one_time` or `recurring` depending on whether the price is for a one-time purchase or a recurring (subscription) purchase.
        Type: PriceType
        ///The unit amount in %s to be charged, represented as a whole integer if possible.
        UnitAmount: int option
        ///The unit amount in %s to be charged, represented as a decimal string with at most 12 decimal places.
        UnitAmountDecimal: string option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "price"

        static member Create (active: bool, billingScheme: PriceBillingScheme, created: DateTime, currency: string, id: string, livemode: bool, lookupKey: string option, metadata: Map<string, string>, nickname: string option, product: PriceProduct'AnyOf, recurring: Recurring option, tiersMode: PriceTiersMode option, transformQuantity: TransformQuantity option, ``type``: PriceType, unitAmount: int option, unitAmountDecimal: string option, ?tiers: PriceTier list) =
            {
                Price.Active = active //required
                Price.BillingScheme = billingScheme //required
                Price.Created = created //required
                Price.Currency = currency //required
                Price.Id = id //required
                Price.Livemode = livemode //required
                Price.LookupKey = lookupKey //required
                Price.Metadata = metadata //required
                Price.Nickname = nickname //required
                Price.Product = product //required
                Price.Recurring = recurring //required
                Price.TiersMode = tiersMode //required
                Price.TransformQuantity = transformQuantity //required
                Price.Type = ``type`` //required
                Price.UnitAmount = unitAmount //required
                Price.UnitAmountDecimal = unitAmountDecimal //required
                Price.Tiers = tiers
            }

    and PriceBillingScheme =
        | PerUnit
        | Tiered

    and PriceProduct'AnyOf =
        | String of string
        | Product of Product
        | DeletedProduct of DeletedProduct

    and PriceTiersMode =
        | Graduated
        | Volume

    and PriceType =
        | OneTime
        | Recurring

    and PriceTier = {
        ///Price for the entire tier.
        FlatAmount: int option
        ///Same as `flat_amount`, but contains a decimal value with at most 12 decimal places.
        FlatAmountDecimal: string option
        ///Per unit price for units relevant to the tier.
        UnitAmount: int option
        ///Same as `unit_amount`, but contains a decimal value with at most 12 decimal places.
        UnitAmountDecimal: string option
        ///Up to and including to this quantity will be contained in the tier.
        UpTo: int option
    }
    with

        static member Create (flatAmount: int option, flatAmountDecimal: string option, unitAmount: int option, unitAmountDecimal: string option, upTo: int option) =
            {
                PriceTier.FlatAmount = flatAmount //required
                PriceTier.FlatAmountDecimal = flatAmountDecimal //required
                PriceTier.UnitAmount = unitAmount //required
                PriceTier.UnitAmountDecimal = unitAmountDecimal //required
                PriceTier.UpTo = upTo //required
            }

    ///Products describe the specific goods or services you offer to your customers.
    ///For example, you might offer a Standard and Premium version of your goods or service; each version would be a separate Product.
    ///They can be used in conjunction with [Prices](https://stripe.com/docs/api#prices) to configure pricing in Checkout and Subscriptions.
    ///Related guides: [Set up a subscription](https://stripe.com/docs/billing/subscriptions/set-up-subscription) or accept [one-time payments with Checkout](https://stripe.com/docs/payments/checkout/client#create-products) and more about [Products and Prices](https://stripe.com/docs/billing/prices-guide)
    and Product = {
        ///Whether the product is currently available for purchase.
        Active: bool
        ///A list of up to 5 attributes that each SKU can provide values for (e.g., `["color", "size"]`).
        Attributes: string list option
        ///A short one-line description of the product, meant to be displayable to the customer. Only applicable to products of `type=good`.
        Caption: string option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///An array of connect application identifiers that cannot purchase this product. Only applicable to products of `type=good`.
        DeactivateOn: string list option
        ///The product's description, meant to be displayable to the customer. Use this field to optionally store a long form explanation of the product being sold for your own rendering purposes.
        Description: string option
        ///Unique identifier for the object.
        Id: string
        ///A list of up to 8 URLs of images for this product, meant to be displayable to the customer.
        Images: string list
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        ///The product's name, meant to be displayable to the customer. Whenever this product is sold via a subscription, name will show up on associated invoice line item descriptions.
        Name: string
        ///The dimensions of this product for shipping purposes. A SKU associated with this product can override this value by having its own `package_dimensions`. Only applicable to products of `type=good`.
        PackageDimensions: PackageDimensions option
        ///Whether this product is a shipped good. Only applicable to products of `type=good`.
        Shippable: bool option
        ///Extra information about a product which will appear on your customer's credit card statement. In the case that multiple products are billed at once, the first statement descriptor will be used.
        StatementDescriptor: string option
        ///The type of the product. The product is either of type `good`, which is eligible for use with Orders and SKUs, or `service`, which is eligible for use with Subscriptions and Plans.
        Type: ProductType
        ///A label that represents units of this product in Stripe and on customers’ receipts and invoices. When set, this will be included in associated invoice line item descriptions.
        UnitLabel: string option
        ///Time at which the object was last updated. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Updated: DateTime
        ///A URL of a publicly-accessible webpage for this product. Only applicable to products of `type=good`.
        Url: string option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "product"

        static member Create (active: bool, attributes: string list option, caption: string option, created: DateTime, description: string option, id: string, images: string list, livemode: bool, metadata: Map<string, string>, name: string, packageDimensions: PackageDimensions option, shippable: bool option, statementDescriptor: string option, ``type``: ProductType, unitLabel: string option, updated: DateTime, url: string option, ?deactivateOn: string list) =
            {
                Product.Active = active //required
                Product.Attributes = attributes //required
                Product.Caption = caption //required
                Product.Created = created //required
                Product.Description = description //required
                Product.Id = id //required
                Product.Images = images //required
                Product.Livemode = livemode //required
                Product.Metadata = metadata //required
                Product.Name = name //required
                Product.PackageDimensions = packageDimensions //required
                Product.Shippable = shippable //required
                Product.StatementDescriptor = statementDescriptor //required
                Product.Type = ``type`` //required
                Product.UnitLabel = unitLabel //required
                Product.Updated = updated //required
                Product.Url = url //required
                Product.DeactivateOn = deactivateOn
            }

    and ProductType =
        | Good
        | Service

    ///A Promotion Code represents a customer-redeemable code for a coupon. It can be used to
    ///create multiple codes for a single coupon.
    and PromotionCode = {
        ///Whether the promotion code is currently active. A promotion code is only active if the coupon is also valid.
        Active: bool
        ///The customer-facing code. Regardless of case, this code must be unique across all active promotion codes for each customer.
        Code: string
        Coupon: Coupon
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///The customer that this promotion code can be used by.
        [<JsonField(Transform=typeof<AnyOfTransform<PromotionCodeCustomer'AnyOf>>)>]Customer: PromotionCodeCustomer'AnyOf option
        ///Date at which the promotion code can no longer be redeemed.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]ExpiresAt: DateTime option
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Maximum number of times this promotion code can be redeemed.
        MaxRedemptions: int option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        Restrictions: PromotionCodesResourceRestrictions
        ///Number of times this promotion code has been used.
        TimesRedeemed: int
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "promotion_code"

        static member Create (active: bool, code: string, coupon: Coupon, created: DateTime, customer: PromotionCodeCustomer'AnyOf option, expiresAt: DateTime option, id: string, livemode: bool, maxRedemptions: int option, metadata: Map<string, string> option, restrictions: PromotionCodesResourceRestrictions, timesRedeemed: int) =
            {
                PromotionCode.Active = active //required
                PromotionCode.Code = code //required
                PromotionCode.Coupon = coupon //required
                PromotionCode.Created = created //required
                PromotionCode.Customer = customer //required
                PromotionCode.ExpiresAt = expiresAt //required
                PromotionCode.Id = id //required
                PromotionCode.Livemode = livemode //required
                PromotionCode.MaxRedemptions = maxRedemptions //required
                PromotionCode.Metadata = metadata //required
                PromotionCode.Restrictions = restrictions //required
                PromotionCode.TimesRedeemed = timesRedeemed //required
            }

    and PromotionCodeCustomer'AnyOf =
        | String of string
        | Customer of Customer
        | DeletedCustomer of DeletedCustomer

    and PromotionCodesResourceRestrictions = {
        ///A Boolean indicating if the Promotion Code should only be redeemed for Customers without any successful payments or invoices
        FirstTimeTransaction: bool
        ///Minimum amount required to redeem this Promotion Code into a Coupon (e.g., a purchase must be $100 or more to work).
        MinimumAmount: int option
        ///Three-letter [ISO code](https://stripe.com/docs/currencies) for minimum_amount
        MinimumAmountCurrency: string option
    }
    with

        static member Create (firstTimeTransaction: bool, minimumAmount: int option, minimumAmountCurrency: string option) =
            {
                PromotionCodesResourceRestrictions.FirstTimeTransaction = firstTimeTransaction //required
                PromotionCodesResourceRestrictions.MinimumAmount = minimumAmount //required
                PromotionCodesResourceRestrictions.MinimumAmountCurrency = minimumAmountCurrency //required
            }

    ///An early fraud warning indicates that the card issuer has notified us that a
    ///charge may be fraudulent.
    ///Related guide: [Early Fraud Warnings](https://stripe.com/docs/disputes/measuring#early-fraud-warnings).
    and RadarEarlyFraudWarning = {
        ///An EFW is actionable if it has not received a dispute and has not been fully refunded. You may wish to proactively refund a charge that receives an EFW, in order to avoid receiving a dispute later.
        Actionable: bool
        ///ID of the charge this early fraud warning is for, optionally expanded.
        [<JsonField(Transform=typeof<AnyOfTransform<RadarEarlyFraudWarningCharge'AnyOf>>)>]Charge: RadarEarlyFraudWarningCharge'AnyOf
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///The type of fraud labelled by the issuer. One of `card_never_received`, `fraudulent_card_application`, `made_with_counterfeit_card`, `made_with_lost_card`, `made_with_stolen_card`, `misc`, `unauthorized_use_of_card`.
        FraudType: string
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "radar.early_fraud_warning"

        static member Create (actionable: bool, charge: RadarEarlyFraudWarningCharge'AnyOf, created: DateTime, fraudType: string, id: string, livemode: bool) =
            {
                RadarEarlyFraudWarning.Actionable = actionable //required
                RadarEarlyFraudWarning.Charge = charge //required
                RadarEarlyFraudWarning.Created = created //required
                RadarEarlyFraudWarning.FraudType = fraudType //required
                RadarEarlyFraudWarning.Id = id //required
                RadarEarlyFraudWarning.Livemode = livemode //required
            }

    and RadarEarlyFraudWarningCharge'AnyOf =
        | String of string
        | Charge of Charge

    ///Value lists allow you to group values together which can then be referenced in rules.
    ///Related guide: [Default Stripe Lists](https://stripe.com/docs/radar/lists#managing-list-items).
    and RadarValueList = {
        ///The name of the value list for use in rules.
        Alias: string
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///The name or email address of the user who created this value list.
        CreatedBy: string
        ///Unique identifier for the object.
        Id: string
        ///The type of items in the value list. One of `card_fingerprint`, `card_bin`, `email`, `ip_address`, `country`, `string`, or `case_sensitive_string`.
        ItemType: RadarValueListItemType
        ///List of items contained within this value list.
        ListItems: RadarValueListListItems
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        ///The name of the value list.
        Name: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "radar.value_list"

        static member Create (alias: string, created: DateTime, createdBy: string, id: string, itemType: RadarValueListItemType, listItems: RadarValueListListItems, livemode: bool, metadata: Map<string, string>, name: string) =
            {
                RadarValueList.Alias = alias //required
                RadarValueList.Created = created //required
                RadarValueList.CreatedBy = createdBy //required
                RadarValueList.Id = id //required
                RadarValueList.ItemType = itemType //required
                RadarValueList.ListItems = listItems //required
                RadarValueList.Livemode = livemode //required
                RadarValueList.Metadata = metadata //required
                RadarValueList.Name = name //required
            }

    and RadarValueListItemType =
        | CardBin
        | CardFingerprint
        | CaseSensitiveString
        | Country
        | Email
        | IpAddress
        | String

    ///List of items contained within this value list.
    and RadarValueListListItems = {
        ///Details about each object.
        Data: RadarValueListItem list
        ///True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        ///The URL where this list can be accessed.
        Url: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
        member _.Object = "list"

        static member Create (data: RadarValueListItem list, hasMore: bool, url: string) =
            {
                RadarValueListListItems.Data = data //required
                RadarValueListListItems.HasMore = hasMore //required
                RadarValueListListItems.Url = url //required
            }

    ///Value list items allow you to add specific values to a given Radar value list, which can then be used in rules.
    ///Related guide: [Managing List Items](https://stripe.com/docs/radar/lists#managing-list-items).
    and RadarValueListItem = {
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///The name or email address of the user who added this item to the value list.
        CreatedBy: string
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///The value of the item.
        Value: string
        ///The identifier of the value list this item belongs to.
        ValueList: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "radar.value_list_item"

        static member Create (created: DateTime, createdBy: string, id: string, livemode: bool, value: string, valueList: string) =
            {
                RadarValueListItem.Created = created //required
                RadarValueListItem.CreatedBy = createdBy //required
                RadarValueListItem.Id = id //required
                RadarValueListItem.Livemode = livemode //required
                RadarValueListItem.Value = value //required
                RadarValueListItem.ValueList = valueList //required
            }

    and RadarReviewResourceLocation = {
        ///The city where the payment originated.
        City: string option
        ///Two-letter ISO code representing the country where the payment originated.
        Country: string option
        ///The geographic latitude where the payment originated.
        Latitude: decimal option
        ///The geographic longitude where the payment originated.
        Longitude: decimal option
        ///The state/county/province/region where the payment originated.
        Region: string option
    }
    with

        static member Create (city: string option, country: string option, latitude: decimal option, longitude: decimal option, region: string option) =
            {
                RadarReviewResourceLocation.City = city //required
                RadarReviewResourceLocation.Country = country //required
                RadarReviewResourceLocation.Latitude = latitude //required
                RadarReviewResourceLocation.Longitude = longitude //required
                RadarReviewResourceLocation.Region = region //required
            }

    and RadarReviewResourceSession = {
        ///The browser used in this browser session (e.g., `Chrome`).
        Browser: string option
        ///Information about the device used for the browser session (e.g., `Samsung SM-G930T`).
        Device: string option
        ///The platform for the browser session (e.g., `Macintosh`).
        Platform: string option
        ///The version for the browser session (e.g., `61.0.3163.100`).
        Version: string option
    }
    with

        static member Create (browser: string option, device: string option, platform: string option, version: string option) =
            {
                RadarReviewResourceSession.Browser = browser //required
                RadarReviewResourceSession.Device = device //required
                RadarReviewResourceSession.Platform = platform //required
                RadarReviewResourceSession.Version = version //required
            }

    ///With `Recipient` objects, you can transfer money from your Stripe account to a
    ///third-party bank account or debit card. The API allows you to create, delete,
    ///and update your recipients. You can retrieve individual recipients as well as
    ///a list of all your recipients.
    ///**`Recipient` objects have been deprecated in favor of
    ///[Connect](https://stripe.com/docs/connect), specifically Connect's much more powerful
    ///[Account objects](https://stripe.com/docs/api#account). Stripe accounts that don't already use
    ///recipients can no longer begin doing so. Please use `Account` objects
    ///instead.**
    and Recipient = {
        ///Hash describing the current account on the recipient, if there is one.
        ActiveAccount: BankAccount option
        Cards: RecipientCards option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///The default card to use for creating transfers to this recipient.
        [<JsonField(Transform=typeof<AnyOfTransform<RecipientDefaultCard'AnyOf>>)>]DefaultCard: RecipientDefaultCard'AnyOf option
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        Email: string option
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        ///The ID of the [Custom account](https://stripe.com/docs/connect/custom-accounts) this recipient was migrated to. If set, the recipient can no longer be updated, nor can transfers be made to it: use the Custom account instead.
        [<JsonField(Transform=typeof<AnyOfTransform<RecipientMigratedTo'AnyOf>>)>]MigratedTo: RecipientMigratedTo'AnyOf option
        ///Full, legal name of the recipient.
        Name: string option
        [<JsonField(Transform=typeof<AnyOfTransform<RecipientRolledBackFrom'AnyOf>>)>]RolledBackFrom: RecipientRolledBackFrom'AnyOf option
        ///Type of the recipient, one of `individual` or `corporation`.
        Type: RecipientType
        ///Whether the recipient has been verified. This field is non-standard, and maybe removed in the future
        Verified: bool
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "recipient"

        static member Create (activeAccount: BankAccount option, cards: RecipientCards option, created: DateTime, defaultCard: RecipientDefaultCard'AnyOf option, description: string option, email: string option, id: string, livemode: bool, metadata: Map<string, string>, migratedTo: RecipientMigratedTo'AnyOf option, name: string option, ``type``: RecipientType, verified: bool, ?rolledBackFrom: RecipientRolledBackFrom'AnyOf) =
            {
                Recipient.ActiveAccount = activeAccount //required
                Recipient.Cards = cards //required
                Recipient.Created = created //required
                Recipient.DefaultCard = defaultCard //required
                Recipient.Description = description //required
                Recipient.Email = email //required
                Recipient.Id = id //required
                Recipient.Livemode = livemode //required
                Recipient.Metadata = metadata //required
                Recipient.MigratedTo = migratedTo //required
                Recipient.Name = name //required
                Recipient.Type = ``type`` //required
                Recipient.Verified = verified //required
                Recipient.RolledBackFrom = rolledBackFrom
            }

    and RecipientDefaultCard'AnyOf =
        | String of string
        | Card of Card

    and RecipientMigratedTo'AnyOf =
        | String of string
        | Account of Account

    and RecipientRolledBackFrom'AnyOf =
        | String of string
        | Account of Account

    and RecipientType =
        | Individual
        | Corporation

    and RecipientCards = {
        Data: Card list
        ///True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        ///The URL where this list can be accessed.
        Url: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
        member _.Object = "list"

        static member Create (data: Card list, hasMore: bool, url: string) =
            {
                RecipientCards.Data = data //required
                RecipientCards.HasMore = hasMore //required
                RecipientCards.Url = url //required
            }

    and Recurring = {
        ///Specifies a usage aggregation strategy for prices of `usage_type=metered`. Allowed values are `sum` for summing up all usage during a period, `last_during_period` for using the last usage record reported within a period, `last_ever` for using the last usage record ever (across period bounds) or `max` which uses the usage record with the maximum reported usage during a period. Defaults to `sum`.
        AggregateUsage: RecurringAggregateUsage option
        ///The frequency at which a subscription is billed. One of `day`, `week`, `month` or `year`.
        Interval: RecurringInterval
        ///The number of intervals (specified in the `interval` attribute) between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months.
        IntervalCount: int
        ///Default number of trial days when subscribing a customer to this price using [`trial_from_plan=true`](https://stripe.com/docs/api#create_subscription-trial_from_plan).
        TrialPeriodDays: int option
        ///Configures how the quantity per period should be determined. Can be either `metered` or `licensed`. `licensed` automatically bills the `quantity` set when adding it to a subscription. `metered` aggregates the total usage based on usage records. Defaults to `licensed`.
        UsageType: RecurringUsageType
    }
    with

        static member Create (aggregateUsage: RecurringAggregateUsage option, interval: RecurringInterval, intervalCount: int, trialPeriodDays: int option, usageType: RecurringUsageType) =
            {
                Recurring.AggregateUsage = aggregateUsage //required
                Recurring.Interval = interval //required
                Recurring.IntervalCount = intervalCount //required
                Recurring.TrialPeriodDays = trialPeriodDays //required
                Recurring.UsageType = usageType //required
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
    ///Related guide: [Refunds](https://stripe.com/docs/refunds).
    and Refund = {
        ///Amount, in %s.
        Amount: int
        ///Balance transaction that describes the impact on your account balance.
        [<JsonField(Transform=typeof<AnyOfTransform<RefundBalanceTransaction'AnyOf>>)>]BalanceTransaction: RefundBalanceTransaction'AnyOf option
        ///ID of the charge that was refunded.
        [<JsonField(Transform=typeof<AnyOfTransform<RefundCharge'AnyOf>>)>]Charge: RefundCharge'AnyOf option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///An arbitrary string attached to the object. Often useful for displaying to users. (Available on non-card refunds only)
        Description: string option
        ///If the refund failed, this balance transaction describes the adjustment made on your account balance that reverses the initial balance transaction.
        [<JsonField(Transform=typeof<AnyOfTransform<RefundFailureBalanceTransaction'AnyOf>>)>]FailureBalanceTransaction: RefundFailureBalanceTransaction'AnyOf option
        ///If the refund failed, the reason for refund failure if known. Possible values are `lost_or_stolen_card`, `expired_or_canceled_card`, or `unknown`.
        FailureReason: RefundFailureReason option
        ///Unique identifier for the object.
        Id: string
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        ///ID of the PaymentIntent that was refunded.
        [<JsonField(Transform=typeof<AnyOfTransform<RefundPaymentIntent'AnyOf>>)>]PaymentIntent: RefundPaymentIntent'AnyOf option
        ///Reason for the refund, either user-provided (`duplicate`, `fraudulent`, or `requested_by_customer`) or generated by Stripe internally (`expired_uncaptured_charge`).
        Reason: string option
        ///This is the transaction number that appears on email receipts sent for this refund.
        ReceiptNumber: string option
        ///The transfer reversal that is associated with the refund. Only present if the charge came from another Stripe account. See the Connect documentation for details.
        [<JsonField(Transform=typeof<AnyOfTransform<RefundSourceTransferReversal'AnyOf>>)>]SourceTransferReversal: RefundSourceTransferReversal'AnyOf option
        ///Status of the refund. For credit card refunds, this can be `pending`, `succeeded`, or `failed`. For other types of refunds, it can be `pending`, `succeeded`, `failed`, or `canceled`. Refer to our [refunds](https://stripe.com/docs/refunds#failed-refunds) documentation for more details.
        Status: RefundStatus option
        ///If the accompanying transfer was reversed, the transfer reversal object. Only applicable if the charge was created using the destination parameter.
        [<JsonField(Transform=typeof<AnyOfTransform<RefundTransferReversal'AnyOf>>)>]TransferReversal: RefundTransferReversal'AnyOf option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "refund"

        static member Create (amount: int, balanceTransaction: RefundBalanceTransaction'AnyOf option, charge: RefundCharge'AnyOf option, created: DateTime, currency: string, id: string, metadata: Map<string, string> option, paymentIntent: RefundPaymentIntent'AnyOf option, reason: string option, receiptNumber: string option, sourceTransferReversal: RefundSourceTransferReversal'AnyOf option, status: RefundStatus option, transferReversal: RefundTransferReversal'AnyOf option, ?description: string, ?failureBalanceTransaction: RefundFailureBalanceTransaction'AnyOf, ?failureReason: RefundFailureReason) =
            {
                Refund.Amount = amount //required
                Refund.BalanceTransaction = balanceTransaction //required
                Refund.Charge = charge //required
                Refund.Created = created //required
                Refund.Currency = currency //required
                Refund.Id = id //required
                Refund.Metadata = metadata //required
                Refund.PaymentIntent = paymentIntent //required
                Refund.Reason = reason //required
                Refund.ReceiptNumber = receiptNumber //required
                Refund.SourceTransferReversal = sourceTransferReversal //required
                Refund.Status = status //required
                Refund.TransferReversal = transferReversal //required
                Refund.Description = description
                Refund.FailureBalanceTransaction = failureBalanceTransaction
                Refund.FailureReason = failureReason
            }

    and RefundBalanceTransaction'AnyOf =
        | String of string
        | BalanceTransaction of BalanceTransaction

    and RefundCharge'AnyOf =
        | String of string
        | Charge of Charge

    and RefundFailureBalanceTransaction'AnyOf =
        | String of string
        | BalanceTransaction of BalanceTransaction

    and RefundFailureReason =
        | LostOrStolenCard
        | ExpiredOrCanceledCard
        | Unknown

    and RefundPaymentIntent'AnyOf =
        | String of string
        | PaymentIntent of PaymentIntent

    and RefundSourceTransferReversal'AnyOf =
        | String of string
        | TransferReversal of TransferReversal

    and RefundStatus =
        | Pending
        | Succeeded
        | Failed

    and RefundTransferReversal'AnyOf =
        | String of string
        | TransferReversal of TransferReversal

    ///The Report Run object represents an instance of a report type generated with
    ///specific run parameters. Once the object is created, Stripe begins processing the report.
    ///When the report has finished running, it will give you a reference to a file
    ///where you can retrieve your results. For an overview, see
    ///[API Access to Reports](https://stripe.com/docs/reporting/statements/api).
    ///Note that reports can only be run based on your live-mode data (not test-mode
    ///data), and thus related requests must be made with a
    ///[live-mode API key](https://stripe.com/docs/keys#test-live-modes).
    and ReportingReportRun = {
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///If something should go wrong during the run, a message about the failure (populated when
    /// `status=failed`).
        Error: string option
        ///Unique identifier for the object.
        Id: string
        ///Always `true`: reports can only be run on live-mode data.
        Livemode: bool
        Parameters: FinancialReportingFinanceReportRunRunParameters
        ///The ID of the [report type](https://stripe.com/docs/reports/report-types) to run, such as `"balance.summary.1"`.
        ReportType: string
        ///The file object representing the result of the report run (populated when
    /// `status=succeeded`).
        Result: File option
        ///Status of this report run. This will be `pending` when the run is initially created.
    /// When the run finishes, this will be set to `succeeded` and the `result` field will be populated.
    /// Rarely, we may encounter an error, at which point this will be set to `failed` and the `error` field will be populated.
        Status: string
        ///Timestamp at which this run successfully finished (populated when
    /// `status=succeeded`). Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]SucceededAt: DateTime option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "reporting.report_run"

        static member Create (created: DateTime, error: string option, id: string, livemode: bool, parameters: FinancialReportingFinanceReportRunRunParameters, reportType: string, result: File option, status: string, succeededAt: DateTime option) =
            {
                ReportingReportRun.Created = created //required
                ReportingReportRun.Error = error //required
                ReportingReportRun.Id = id //required
                ReportingReportRun.Livemode = livemode //required
                ReportingReportRun.Parameters = parameters //required
                ReportingReportRun.ReportType = reportType //required
                ReportingReportRun.Result = result //required
                ReportingReportRun.Status = status //required
                ReportingReportRun.SucceededAt = succeededAt //required
            }

    ///The Report Type resource corresponds to a particular type of report, such as
    ///the "Activity summary" or "Itemized payouts" reports. These objects are
    ///identified by an ID belonging to a set of enumerated values. See
    ///[API Access to Reports documentation](https://stripe.com/docs/reporting/statements/api)
    ///for those Report Type IDs, along with required and optional parameters.
    ///Note that reports can only be run based on your live-mode data (not test-mode
    ///data), and thus related requests must be made with a
    ///[live-mode API key](https://stripe.com/docs/keys#test-live-modes).
    and ReportingReportType = {
        ///Most recent time for which this Report Type is available. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]DataAvailableEnd: DateTime
        ///Earliest time for which this Report Type is available. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]DataAvailableStart: DateTime
        ///List of column names that are included by default when this Report Type gets run. (If the Report Type doesn't support the `columns` parameter, this will be null.)
        DefaultColumns: string list option
        ///The [ID of the Report Type](https://stripe.com/docs/reporting/statements/api#available-report-types), such as `balance.summary.1`.
        Id: string
        ///Human-readable name of the Report Type
        Name: string
        ///When this Report Type was latest updated. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Updated: DateTime
        ///Version of the Report Type. Different versions report with the same ID will have the same purpose, but may take different run parameters or have different result schemas.
        Version: int
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "reporting.report_type"

        static member Create (dataAvailableEnd: DateTime, dataAvailableStart: DateTime, defaultColumns: string list option, id: string, name: string, updated: DateTime, version: int) =
            {
                ReportingReportType.DataAvailableEnd = dataAvailableEnd //required
                ReportingReportType.DataAvailableStart = dataAvailableStart //required
                ReportingReportType.DefaultColumns = defaultColumns //required
                ReportingReportType.Id = id //required
                ReportingReportType.Name = name //required
                ReportingReportType.Updated = updated //required
                ReportingReportType.Version = version //required
            }

    and ReserveTransaction = {
        Amount: int
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        ///Unique identifier for the object.
        Id: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "reserve_transaction"

        static member Create (amount: int, currency: string, description: string option, id: string) =
            {
                ReserveTransaction.Amount = amount //required
                ReserveTransaction.Currency = currency //required
                ReserveTransaction.Description = description //required
                ReserveTransaction.Id = id //required
            }

    ///Reviews can be used to supplement automated fraud detection with human expertise.
    ///Learn more about [Radar](/radar) and reviewing payments
    ///[here](https://stripe.com/docs/radar/reviews).
    and Review = {
        ///The ZIP or postal code of the card used, if applicable.
        BillingZip: string option
        ///The charge associated with this review.
        [<JsonField(Transform=typeof<AnyOfTransform<ReviewCharge'AnyOf>>)>]Charge: ReviewCharge'AnyOf option
        ///The reason the review was closed, or null if it has not yet been closed. One of `approved`, `refunded`, `refunded_as_fraud`, or `disputed`.
        ClosedReason: ReviewClosedReason option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Unique identifier for the object.
        Id: string
        ///The IP address where the payment originated.
        IpAddress: string option
        ///Information related to the location of the payment. Note that this information is an approximation and attempts to locate the nearest population center - it should not be used to determine a specific address.
        IpAddressLocation: RadarReviewResourceLocation option
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///If `true`, the review needs action.
        Open: bool
        ///The reason the review was opened. One of `rule` or `manual`.
        OpenedReason: ReviewOpenedReason
        ///The PaymentIntent ID associated with this review, if one exists.
        [<JsonField(Transform=typeof<AnyOfTransform<ReviewPaymentIntent'AnyOf>>)>]PaymentIntent: ReviewPaymentIntent'AnyOf option
        ///The reason the review is currently open or closed. One of `rule`, `manual`, `approved`, `refunded`, `refunded_as_fraud`, or `disputed`.
        Reason: ReviewReason
        ///Information related to the browsing session of the user who initiated the payment.
        Session: RadarReviewResourceSession option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "review"

        static member Create (billingZip: string option, charge: ReviewCharge'AnyOf option, closedReason: ReviewClosedReason option, created: DateTime, id: string, ipAddress: string option, ipAddressLocation: RadarReviewResourceLocation option, livemode: bool, ``open``: bool, openedReason: ReviewOpenedReason, reason: ReviewReason, session: RadarReviewResourceSession option, ?paymentIntent: ReviewPaymentIntent'AnyOf) =
            {
                Review.BillingZip = billingZip //required
                Review.Charge = charge //required
                Review.ClosedReason = closedReason //required
                Review.Created = created //required
                Review.Id = id //required
                Review.IpAddress = ipAddress //required
                Review.IpAddressLocation = ipAddressLocation //required
                Review.Livemode = livemode //required
                Review.Open = ``open`` //required
                Review.OpenedReason = openedReason //required
                Review.Reason = reason //required
                Review.Session = session //required
                Review.PaymentIntent = paymentIntent
            }

    and ReviewCharge'AnyOf =
        | String of string
        | Charge of Charge

    and ReviewClosedReason =
        | Approved
        | Disputed
        | Refunded
        | RefundedAsFraud

    and ReviewOpenedReason =
        | Manual
        | Rule

    and ReviewPaymentIntent'AnyOf =
        | String of string
        | PaymentIntent of PaymentIntent

    and ReviewReason =
        | Rule
        | Manual
        | Approved
        | Refunded
        | RefundedAsFraud
        | Disputed

    and Rule = {
        ///The action taken on the payment.
        Action: string
        ///Unique identifier for the object.
        Id: string
        ///The predicate to evaluate the payment against.
        Predicate: string
    }
    with

        static member Create (action: string, id: string, predicate: string) =
            {
                Rule.Action = action //required
                Rule.Id = id //required
                Rule.Predicate = predicate //required
            }

    ///If you have [scheduled a Sigma query](https://stripe.com/docs/sigma/scheduled-queries), you'll
    ///receive a `sigma.scheduled_query_run.created` webhook each time the query
    ///runs. The webhook contains a `ScheduledQueryRun` object, which you can use to
    ///retrieve the query results.
    and ScheduledQueryRun = {
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///When the query was run, Sigma contained a snapshot of your Stripe data at this time.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]DataLoadTime: DateTime
        Error: SigmaScheduledQueryRunError option
        ///The file object representing the results of the query.
        File: File option
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Time at which the result expires and is no longer available for download.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]ResultAvailableUntil: DateTime
        ///SQL for the query.
        Sql: string
        ///The query's execution status, which will be `completed` for successful runs, and `canceled`, `failed`, or `timed_out` otherwise.
        Status: string
        ///Title of the query.
        Title: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "scheduled_query_run"

        static member Create (created: DateTime, dataLoadTime: DateTime, file: File option, id: string, livemode: bool, resultAvailableUntil: DateTime, sql: string, status: string, title: string, ?error: SigmaScheduledQueryRunError) =
            {
                ScheduledQueryRun.Created = created //required
                ScheduledQueryRun.DataLoadTime = dataLoadTime //required
                ScheduledQueryRun.File = file //required
                ScheduledQueryRun.Id = id //required
                ScheduledQueryRun.Livemode = livemode //required
                ScheduledQueryRun.ResultAvailableUntil = resultAvailableUntil //required
                ScheduledQueryRun.Sql = sql //required
                ScheduledQueryRun.Status = status //required
                ScheduledQueryRun.Title = title //required
                ScheduledQueryRun.Error = error
            }

    and SepaDebitGeneratedFrom = {
        ///The ID of the Charge that generated this PaymentMethod, if any.
        [<JsonField(Transform=typeof<AnyOfTransform<SepaDebitGeneratedFromCharge'AnyOf>>)>]Charge: SepaDebitGeneratedFromCharge'AnyOf option
        ///The ID of the SetupAttempt that generated this PaymentMethod, if any.
        [<JsonField(Transform=typeof<AnyOfTransform<SepaDebitGeneratedFromSetupAttempt'AnyOf>>)>]SetupAttempt: SepaDebitGeneratedFromSetupAttempt'AnyOf option
    }
    with

        static member Create (charge: SepaDebitGeneratedFromCharge'AnyOf option, setupAttempt: SepaDebitGeneratedFromSetupAttempt'AnyOf option) =
            {
                SepaDebitGeneratedFrom.Charge = charge //required
                SepaDebitGeneratedFrom.SetupAttempt = setupAttempt //required
            }

    and SepaDebitGeneratedFromCharge'AnyOf =
        | String of string
        | Charge of Charge

    and SepaDebitGeneratedFromSetupAttempt'AnyOf =
        | String of string
        | SetupAttempt of SetupAttempt

    ///A SetupAttempt describes one attempted confirmation of a SetupIntent,
    ///whether that confirmation was successful or unsuccessful. You can use
    ///SetupAttempts to inspect details of a specific attempt at setting up a
    ///payment method using a SetupIntent.
    and SetupAttempt = {
        ///The value of [application](https://stripe.com/docs/api/setup_intents/object#setup_intent_object-application) on the SetupIntent at the time of this confirmation.
        [<JsonField(Transform=typeof<AnyOfTransform<SetupAttemptApplication'AnyOf>>)>]Application: SetupAttemptApplication'AnyOf option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///The value of [customer](https://stripe.com/docs/api/setup_intents/object#setup_intent_object-customer) on the SetupIntent at the time of this confirmation.
        [<JsonField(Transform=typeof<AnyOfTransform<SetupAttemptCustomer'AnyOf>>)>]Customer: SetupAttemptCustomer'AnyOf option
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///The value of [on_behalf_of](https://stripe.com/docs/api/setup_intents/object#setup_intent_object-on_behalf_of) on the SetupIntent at the time of this confirmation.
        [<JsonField(Transform=typeof<AnyOfTransform<SetupAttemptOnBehalfOf'AnyOf>>)>]OnBehalfOf: SetupAttemptOnBehalfOf'AnyOf option
        ///ID of the payment method used with this SetupAttempt.
        [<JsonField(Transform=typeof<AnyOfTransform<SetupAttemptPaymentMethod'AnyOf>>)>]PaymentMethod: SetupAttemptPaymentMethod'AnyOf
        PaymentMethodDetails: SetupAttemptPaymentMethodDetails
        ///The error encountered during this attempt to confirm the SetupIntent, if any.
        SetupError: ApiErrors option
        ///ID of the SetupIntent that this attempt belongs to.
        [<JsonField(Transform=typeof<AnyOfTransform<SetupAttemptSetupIntent'AnyOf>>)>]SetupIntent: SetupAttemptSetupIntent'AnyOf
        ///Status of this SetupAttempt, one of `requires_confirmation`, `requires_action`, `processing`, `succeeded`, `failed`, or `abandoned`.
        Status: SetupAttemptStatus
        ///The value of [usage](https://stripe.com/docs/api/setup_intents/object#setup_intent_object-usage) on the SetupIntent at the time of this confirmation, one of `off_session` or `on_session`.
        Usage: SetupAttemptUsage
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "setup_attempt"

        static member Create (application: SetupAttemptApplication'AnyOf option, created: DateTime, customer: SetupAttemptCustomer'AnyOf option, id: string, livemode: bool, onBehalfOf: SetupAttemptOnBehalfOf'AnyOf option, paymentMethod: SetupAttemptPaymentMethod'AnyOf, paymentMethodDetails: SetupAttemptPaymentMethodDetails, setupError: ApiErrors option, setupIntent: SetupAttemptSetupIntent'AnyOf, status: SetupAttemptStatus, usage: SetupAttemptUsage) =
            {
                SetupAttempt.Application = application //required
                SetupAttempt.Created = created //required
                SetupAttempt.Customer = customer //required
                SetupAttempt.Id = id //required
                SetupAttempt.Livemode = livemode //required
                SetupAttempt.OnBehalfOf = onBehalfOf //required
                SetupAttempt.PaymentMethod = paymentMethod //required
                SetupAttempt.PaymentMethodDetails = paymentMethodDetails //required
                SetupAttempt.SetupError = setupError //required
                SetupAttempt.SetupIntent = setupIntent //required
                SetupAttempt.Status = status //required
                SetupAttempt.Usage = usage //required
            }

    and SetupAttemptApplication'AnyOf =
        | String of string
        | Application of Application

    and SetupAttemptCustomer'AnyOf =
        | String of string
        | Customer of Customer
        | DeletedCustomer of DeletedCustomer

    and SetupAttemptOnBehalfOf'AnyOf =
        | String of string
        | Account of Account

    and SetupAttemptPaymentMethod'AnyOf =
        | String of string
        | PaymentMethod of PaymentMethod

    and SetupAttemptSetupIntent'AnyOf =
        | String of string
        | SetupIntent of SetupIntent

    and SetupAttemptStatus =
        | RequiresConfirmation
        | RequiresAction
        | Processing
        | Succeeded
        | Failed
        | Abandoned

    and SetupAttemptUsage =
        | OffSession
        | OnSession

    and SetupAttemptPaymentMethodDetails = {
        Bancontact: SetupAttemptPaymentMethodDetailsBancontact option
        Card: SetupAttemptPaymentMethodDetailsCard option
        Ideal: SetupAttemptPaymentMethodDetailsIdeal option
        Sofort: SetupAttemptPaymentMethodDetailsSofort option
        ///The type of the payment method used in the SetupIntent (e.g., `card`). An additional hash is included on `payment_method_details` with a name matching this value. It contains confirmation-specific information for the payment method.
        Type: string
    }
    with

        static member Create (``type``: string, ?bancontact: SetupAttemptPaymentMethodDetailsBancontact, ?card: SetupAttemptPaymentMethodDetailsCard, ?ideal: SetupAttemptPaymentMethodDetailsIdeal, ?sofort: SetupAttemptPaymentMethodDetailsSofort) =
            {
                SetupAttemptPaymentMethodDetails.Type = ``type`` //required
                SetupAttemptPaymentMethodDetails.Bancontact = bancontact
                SetupAttemptPaymentMethodDetails.Card = card
                SetupAttemptPaymentMethodDetails.Ideal = ideal
                SetupAttemptPaymentMethodDetails.Sofort = sofort
            }

    and SetupAttemptPaymentMethodDetailsBancontact = {
        ///Bank code of bank associated with the bank account.
        BankCode: string option
        ///Name of the bank associated with the bank account.
        BankName: string option
        ///Bank Identifier Code of the bank associated with the bank account.
        Bic: string option
        ///The ID of the SEPA Direct Debit PaymentMethod which was generated by this SetupAttempt.
        [<JsonField(Transform=typeof<AnyOfTransform<SetupAttemptPaymentMethodDetailsBancontactGeneratedSepaDebit'AnyOf>>)>]GeneratedSepaDebit: SetupAttemptPaymentMethodDetailsBancontactGeneratedSepaDebit'AnyOf option
        ///The mandate for the SEPA Direct Debit PaymentMethod which was generated by this SetupAttempt.
        [<JsonField(Transform=typeof<AnyOfTransform<SetupAttemptPaymentMethodDetailsBancontactGeneratedSepaDebitMandate'AnyOf>>)>]GeneratedSepaDebitMandate: SetupAttemptPaymentMethodDetailsBancontactGeneratedSepaDebitMandate'AnyOf option
        ///Last four characters of the IBAN.
        [<JsonField(Name="iban_last4")>]IbanLast4: string option
        ///Preferred language of the Bancontact authorization page that the customer is redirected to.
    ///Can be one of `en`, `de`, `fr`, or `nl`
        PreferredLanguage: SetupAttemptPaymentMethodDetailsBancontactPreferredLanguage option
        ///Owner's verified full name. Values are verified or provided by Bancontact directly
    ///(if supported) at the time of authorization or settlement. They cannot be set or mutated.
        VerifiedName: string option
    }
    with

        static member Create (bankCode: string option, bankName: string option, bic: string option, generatedSepaDebit: SetupAttemptPaymentMethodDetailsBancontactGeneratedSepaDebit'AnyOf option, generatedSepaDebitMandate: SetupAttemptPaymentMethodDetailsBancontactGeneratedSepaDebitMandate'AnyOf option, ibanLast4: string option, preferredLanguage: SetupAttemptPaymentMethodDetailsBancontactPreferredLanguage option, verifiedName: string option) =
            {
                SetupAttemptPaymentMethodDetailsBancontact.BankCode = bankCode //required
                SetupAttemptPaymentMethodDetailsBancontact.BankName = bankName //required
                SetupAttemptPaymentMethodDetailsBancontact.Bic = bic //required
                SetupAttemptPaymentMethodDetailsBancontact.GeneratedSepaDebit = generatedSepaDebit //required
                SetupAttemptPaymentMethodDetailsBancontact.GeneratedSepaDebitMandate = generatedSepaDebitMandate //required
                SetupAttemptPaymentMethodDetailsBancontact.IbanLast4 = ibanLast4 //required
                SetupAttemptPaymentMethodDetailsBancontact.PreferredLanguage = preferredLanguage //required
                SetupAttemptPaymentMethodDetailsBancontact.VerifiedName = verifiedName //required
            }

    and SetupAttemptPaymentMethodDetailsBancontactGeneratedSepaDebit'AnyOf =
        | String of string
        | PaymentMethod of PaymentMethod

    and SetupAttemptPaymentMethodDetailsBancontactGeneratedSepaDebitMandate'AnyOf =
        | String of string
        | Mandate of Mandate

    and SetupAttemptPaymentMethodDetailsBancontactPreferredLanguage =
        | De
        | En
        | Fr
        | Nl

    and SetupAttemptPaymentMethodDetailsCard = {
        ///Populated if this authorization used 3D Secure authentication.
        ThreeDSecure: ThreeDSecureDetails option
    }
    with

        static member Create (threeDSecure: ThreeDSecureDetails option) =
            {
                SetupAttemptPaymentMethodDetailsCard.ThreeDSecure = threeDSecure //required
            }

    and SetupAttemptPaymentMethodDetailsIdeal = {
        ///The customer's bank. Can be one of `abn_amro`, `asn_bank`, `bunq`, `handelsbanken`, `ing`, `knab`, `moneyou`, `rabobank`, `regiobank`, `sns_bank`, `triodos_bank`, or `van_lanschot`.
        Bank: SetupAttemptPaymentMethodDetailsIdealBank option
        ///The Bank Identifier Code of the customer's bank.
        Bic: SetupAttemptPaymentMethodDetailsIdealBic option
        ///The ID of the SEPA Direct Debit PaymentMethod which was generated by this SetupAttempt.
        [<JsonField(Transform=typeof<AnyOfTransform<SetupAttemptPaymentMethodDetailsIdealGeneratedSepaDebit'AnyOf>>)>]GeneratedSepaDebit: SetupAttemptPaymentMethodDetailsIdealGeneratedSepaDebit'AnyOf option
        ///The mandate for the SEPA Direct Debit PaymentMethod which was generated by this SetupAttempt.
        [<JsonField(Transform=typeof<AnyOfTransform<SetupAttemptPaymentMethodDetailsIdealGeneratedSepaDebitMandate'AnyOf>>)>]GeneratedSepaDebitMandate: SetupAttemptPaymentMethodDetailsIdealGeneratedSepaDebitMandate'AnyOf option
        ///Last four characters of the IBAN.
        [<JsonField(Name="iban_last4")>]IbanLast4: string option
        ///Owner's verified full name. Values are verified or provided by iDEAL directly
    ///(if supported) at the time of authorization or settlement. They cannot be set or mutated.
        VerifiedName: string option
    }
    with

        static member Create (bank: SetupAttemptPaymentMethodDetailsIdealBank option, bic: SetupAttemptPaymentMethodDetailsIdealBic option, generatedSepaDebit: SetupAttemptPaymentMethodDetailsIdealGeneratedSepaDebit'AnyOf option, generatedSepaDebitMandate: SetupAttemptPaymentMethodDetailsIdealGeneratedSepaDebitMandate'AnyOf option, ibanLast4: string option, verifiedName: string option) =
            {
                SetupAttemptPaymentMethodDetailsIdeal.Bank = bank //required
                SetupAttemptPaymentMethodDetailsIdeal.Bic = bic //required
                SetupAttemptPaymentMethodDetailsIdeal.GeneratedSepaDebit = generatedSepaDebit //required
                SetupAttemptPaymentMethodDetailsIdeal.GeneratedSepaDebitMandate = generatedSepaDebitMandate //required
                SetupAttemptPaymentMethodDetailsIdeal.IbanLast4 = ibanLast4 //required
                SetupAttemptPaymentMethodDetailsIdeal.VerifiedName = verifiedName //required
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

    and SetupAttemptPaymentMethodDetailsIdealGeneratedSepaDebit'AnyOf =
        | String of string
        | PaymentMethod of PaymentMethod

    and SetupAttemptPaymentMethodDetailsIdealGeneratedSepaDebitMandate'AnyOf =
        | String of string
        | Mandate of Mandate

    and SetupAttemptPaymentMethodDetailsSofort = {
        ///Bank code of bank associated with the bank account.
        BankCode: string option
        ///Name of the bank associated with the bank account.
        BankName: string option
        ///Bank Identifier Code of the bank associated with the bank account.
        Bic: string option
        ///The ID of the SEPA Direct Debit PaymentMethod which was generated by this SetupAttempt.
        [<JsonField(Transform=typeof<AnyOfTransform<SetupAttemptPaymentMethodDetailsSofortGeneratedSepaDebit'AnyOf>>)>]GeneratedSepaDebit: SetupAttemptPaymentMethodDetailsSofortGeneratedSepaDebit'AnyOf option
        ///The mandate for the SEPA Direct Debit PaymentMethod which was generated by this SetupAttempt.
        [<JsonField(Transform=typeof<AnyOfTransform<SetupAttemptPaymentMethodDetailsSofortGeneratedSepaDebitMandate'AnyOf>>)>]GeneratedSepaDebitMandate: SetupAttemptPaymentMethodDetailsSofortGeneratedSepaDebitMandate'AnyOf option
        ///Last four characters of the IBAN.
        [<JsonField(Name="iban_last4")>]IbanLast4: string option
        ///Preferred language of the Sofort authorization page that the customer is redirected to.
    ///Can be one of `en`, `de`, `fr`, or `nl`
        PreferredLanguage: SetupAttemptPaymentMethodDetailsSofortPreferredLanguage option
        ///Owner's verified full name. Values are verified or provided by Sofort directly
    ///(if supported) at the time of authorization or settlement. They cannot be set or mutated.
        VerifiedName: string option
    }
    with

        static member Create (bankCode: string option, bankName: string option, bic: string option, generatedSepaDebit: SetupAttemptPaymentMethodDetailsSofortGeneratedSepaDebit'AnyOf option, generatedSepaDebitMandate: SetupAttemptPaymentMethodDetailsSofortGeneratedSepaDebitMandate'AnyOf option, ibanLast4: string option, preferredLanguage: SetupAttemptPaymentMethodDetailsSofortPreferredLanguage option, verifiedName: string option) =
            {
                SetupAttemptPaymentMethodDetailsSofort.BankCode = bankCode //required
                SetupAttemptPaymentMethodDetailsSofort.BankName = bankName //required
                SetupAttemptPaymentMethodDetailsSofort.Bic = bic //required
                SetupAttemptPaymentMethodDetailsSofort.GeneratedSepaDebit = generatedSepaDebit //required
                SetupAttemptPaymentMethodDetailsSofort.GeneratedSepaDebitMandate = generatedSepaDebitMandate //required
                SetupAttemptPaymentMethodDetailsSofort.IbanLast4 = ibanLast4 //required
                SetupAttemptPaymentMethodDetailsSofort.PreferredLanguage = preferredLanguage //required
                SetupAttemptPaymentMethodDetailsSofort.VerifiedName = verifiedName //required
            }

    and SetupAttemptPaymentMethodDetailsSofortGeneratedSepaDebit'AnyOf =
        | String of string
        | PaymentMethod of PaymentMethod

    and SetupAttemptPaymentMethodDetailsSofortGeneratedSepaDebitMandate'AnyOf =
        | String of string
        | Mandate of Mandate

    and SetupAttemptPaymentMethodDetailsSofortPreferredLanguage =
        | De
        | En
        | Fr
        | Nl

    ///A SetupIntent guides you through the process of setting up and saving a customer's payment credentials for future payments.
    ///For example, you could use a SetupIntent to set up and save your customer's card without immediately collecting a payment.
    ///Later, you can use [PaymentIntents](https://stripe.com/docs/api#payment_intents) to drive the payment flow.
    ///Create a SetupIntent as soon as you're ready to collect your customer's payment credentials.
    ///Do not maintain long-lived, unconfirmed SetupIntents as they may no longer be valid.
    ///The SetupIntent then transitions through multiple [statuses](https://stripe.com/docs/payments/intents#intent-statuses) as it guides
    ///you through the setup process.
    ///Successful SetupIntents result in payment credentials that are optimized for future payments.
    ///For example, cardholders in [certain regions](/guides/strong-customer-authentication) may need to be run through
    ///[Strong Customer Authentication](https://stripe.com/docs/strong-customer-authentication) at the time of payment method collection
    ///in order to streamline later [off-session payments](https://stripe.com/docs/payments/setup-intents).
    ///If the SetupIntent is used with a [Customer](https://stripe.com/docs/api#setup_intent_object-customer), upon success,
    ///it will automatically attach the resulting payment method to that Customer.
    ///We recommend using SetupIntents or [setup_future_usage](https://stripe.com/docs/api#payment_intent_object-setup_future_usage) on
    ///PaymentIntents to save payment methods in order to prevent saving invalid or unoptimized payment methods.
    ///By using SetupIntents, you ensure that your customers experience the minimum set of required friction,
    ///even as regulations change over time.
    ///Related guide: [Setup Intents API](https://stripe.com/docs/payments/setup-intents).
    and SetupIntent = {
        ///ID of the Connect application that created the SetupIntent.
        [<JsonField(Transform=typeof<AnyOfTransform<SetupIntentApplication'AnyOf>>)>]Application: SetupIntentApplication'AnyOf option
        ///Reason for cancellation of this SetupIntent, one of `abandoned`, `requested_by_customer`, or `duplicate`.
        CancellationReason: SetupIntentCancellationReason option
        ///The client secret of this SetupIntent. Used for client-side retrieval using a publishable key.
    ///The client secret can be used to complete payment setup from your frontend. It should not be stored, logged, embedded in URLs, or exposed to anyone other than the customer. Make sure that you have TLS enabled on any page that includes the client secret.
        ClientSecret: string option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///ID of the Customer this SetupIntent belongs to, if one exists.
    ///If present, the SetupIntent's payment method will be attached to the Customer on successful setup. Payment methods attached to other Customers cannot be used with this SetupIntent.
        [<JsonField(Transform=typeof<AnyOfTransform<SetupIntentCustomer'AnyOf>>)>]Customer: SetupIntentCustomer'AnyOf option
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        ///Unique identifier for the object.
        Id: string
        ///The error encountered in the previous SetupIntent confirmation.
        LastSetupError: ApiErrors option
        ///The most recent SetupAttempt for this SetupIntent.
        [<JsonField(Transform=typeof<AnyOfTransform<SetupIntentLatestAttempt'AnyOf>>)>]LatestAttempt: SetupIntentLatestAttempt'AnyOf option
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///ID of the multi use Mandate generated by the SetupIntent.
        [<JsonField(Transform=typeof<AnyOfTransform<SetupIntentMandate'AnyOf>>)>]Mandate: SetupIntentMandate'AnyOf option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        ///If present, this property tells you what actions you need to take in order for your customer to continue payment setup.
        NextAction: SetupIntentNextAction option
        ///The account (if any) for which the setup is intended.
        [<JsonField(Transform=typeof<AnyOfTransform<SetupIntentOnBehalfOf'AnyOf>>)>]OnBehalfOf: SetupIntentOnBehalfOf'AnyOf option
        ///ID of the payment method used with this SetupIntent.
        [<JsonField(Transform=typeof<AnyOfTransform<SetupIntentPaymentMethod'AnyOf>>)>]PaymentMethod: SetupIntentPaymentMethod'AnyOf option
        ///Payment-method-specific configuration for this SetupIntent.
        PaymentMethodOptions: SetupIntentPaymentMethodOptions option
        ///The list of payment method types (e.g. card) that this SetupIntent is allowed to set up.
        PaymentMethodTypes: string list
        ///ID of the single_use Mandate generated by the SetupIntent.
        [<JsonField(Transform=typeof<AnyOfTransform<SetupIntentSingleUseMandate'AnyOf>>)>]SingleUseMandate: SetupIntentSingleUseMandate'AnyOf option
        ///[Status](https://stripe.com/docs/payments/intents#intent-statuses) of this SetupIntent, one of `requires_payment_method`, `requires_confirmation`, `requires_action`, `processing`, `canceled`, or `succeeded`.
        Status: SetupIntentStatus
        ///Indicates how the payment method is intended to be used in the future.
    ///Use `on_session` if you intend to only reuse the payment method when the customer is in your checkout flow. Use `off_session` if your customer may or may not be in your checkout flow. If not provided, this value defaults to `off_session`.
        Usage: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "setup_intent"

        static member Create (application: SetupIntentApplication'AnyOf option, cancellationReason: SetupIntentCancellationReason option, clientSecret: string option, created: DateTime, customer: SetupIntentCustomer'AnyOf option, description: string option, id: string, lastSetupError: ApiErrors option, latestAttempt: SetupIntentLatestAttempt'AnyOf option, livemode: bool, mandate: SetupIntentMandate'AnyOf option, metadata: Map<string, string> option, nextAction: SetupIntentNextAction option, onBehalfOf: SetupIntentOnBehalfOf'AnyOf option, paymentMethod: SetupIntentPaymentMethod'AnyOf option, paymentMethodOptions: SetupIntentPaymentMethodOptions option, paymentMethodTypes: string list, singleUseMandate: SetupIntentSingleUseMandate'AnyOf option, status: SetupIntentStatus, usage: string) =
            {
                SetupIntent.Application = application //required
                SetupIntent.CancellationReason = cancellationReason //required
                SetupIntent.ClientSecret = clientSecret //required
                SetupIntent.Created = created //required
                SetupIntent.Customer = customer //required
                SetupIntent.Description = description //required
                SetupIntent.Id = id //required
                SetupIntent.LastSetupError = lastSetupError //required
                SetupIntent.LatestAttempt = latestAttempt //required
                SetupIntent.Livemode = livemode //required
                SetupIntent.Mandate = mandate //required
                SetupIntent.Metadata = metadata //required
                SetupIntent.NextAction = nextAction //required
                SetupIntent.OnBehalfOf = onBehalfOf //required
                SetupIntent.PaymentMethod = paymentMethod //required
                SetupIntent.PaymentMethodOptions = paymentMethodOptions //required
                SetupIntent.PaymentMethodTypes = paymentMethodTypes //required
                SetupIntent.SingleUseMandate = singleUseMandate //required
                SetupIntent.Status = status //required
                SetupIntent.Usage = usage //required
            }

    and SetupIntentApplication'AnyOf =
        | String of string
        | Application of Application

    and SetupIntentCancellationReason =
        | Abandoned
        | Duplicate
        | RequestedByCustomer

    and SetupIntentCustomer'AnyOf =
        | String of string
        | Customer of Customer
        | DeletedCustomer of DeletedCustomer

    and SetupIntentLatestAttempt'AnyOf =
        | String of string
        | SetupAttempt of SetupAttempt

    and SetupIntentMandate'AnyOf =
        | String of string
        | Mandate of Mandate

    and SetupIntentOnBehalfOf'AnyOf =
        | String of string
        | Account of Account

    and SetupIntentPaymentMethod'AnyOf =
        | String of string
        | PaymentMethod of PaymentMethod

    and SetupIntentSingleUseMandate'AnyOf =
        | String of string
        | Mandate of Mandate

    and SetupIntentStatus =
        | Canceled
        | Processing
        | RequiresAction
        | RequiresConfirmation
        | RequiresPaymentMethod
        | Succeeded

    and SetupIntentNextAction = {
        RedirectToUrl: SetupIntentNextActionRedirectToUrl option
        ///Type of the next action to perform, one of `redirect_to_url` or `use_stripe_sdk`.
        Type: SetupIntentNextActionType
        ///When confirming a SetupIntent with Stripe.js, Stripe.js depends on the contents of this dictionary to invoke authentication flows. The shape of the contents is subject to change and is only intended to be used by Stripe.js.
        UseStripeSdk: obj option
    }
    with

        static member Create (``type``: SetupIntentNextActionType, ?redirectToUrl: SetupIntentNextActionRedirectToUrl, ?useStripeSdk: obj) =
            {
                SetupIntentNextAction.Type = ``type`` //required
                SetupIntentNextAction.RedirectToUrl = redirectToUrl
                SetupIntentNextAction.UseStripeSdk = useStripeSdk
            }

    and SetupIntentNextActionType =
        | RedirectToUrl
        | UseStripeSdk

    and SetupIntentNextActionRedirectToUrl = {
        ///If the customer does not exit their browser while authenticating, they will be redirected to this specified URL after completion.
        ReturnUrl: string option
        ///The URL you must redirect your customer to in order to authenticate.
        Url: string option
    }
    with

        static member Create (returnUrl: string option, url: string option) =
            {
                SetupIntentNextActionRedirectToUrl.ReturnUrl = returnUrl //required
                SetupIntentNextActionRedirectToUrl.Url = url //required
            }

    and SetupIntentPaymentMethodOptions = {
        Card: SetupIntentPaymentMethodOptionsCard option
        SepaDebit: SetupIntentPaymentMethodOptionsSepaDebit option
    }
    with

        static member Create (?card: SetupIntentPaymentMethodOptionsCard, ?sepaDebit: SetupIntentPaymentMethodOptionsSepaDebit) =
            {
                SetupIntentPaymentMethodOptions.Card = card
                SetupIntentPaymentMethodOptions.SepaDebit = sepaDebit
            }

    and SetupIntentPaymentMethodOptionsCard = {
        ///We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://stripe.com/docs/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Permitted values include: `automatic` or `any`. If not provided, defaults to `automatic`. Read our guide on [manually requesting 3D Secure](https://stripe.com/docs/payments/3d-secure#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
        RequestThreeDSecure: SetupIntentPaymentMethodOptionsCardRequestThreeDSecure option
    }
    with

        static member Create (requestThreeDSecure: SetupIntentPaymentMethodOptionsCardRequestThreeDSecure option) =
            {
                SetupIntentPaymentMethodOptionsCard.RequestThreeDSecure = requestThreeDSecure //required
            }

    and SetupIntentPaymentMethodOptionsCardRequestThreeDSecure =
        | Any
        | Automatic
        | ChallengeOnly

    and SetupIntentPaymentMethodOptionsMandateOptionsSepaDebit = {
        SetupIntentPaymentMethodOptionsMandateOptionsSepaDebit: string option
    }
    with

        static member Create (?setupIntentPaymentMethodOptionsMandateOptionsSepaDebit: string option) =
            {
                SetupIntentPaymentMethodOptionsMandateOptionsSepaDebit.SetupIntentPaymentMethodOptionsMandateOptionsSepaDebit = setupIntentPaymentMethodOptionsMandateOptionsSepaDebit |> Option.flatten
            }

    and SetupIntentPaymentMethodOptionsSepaDebit = {
        MandateOptions: SetupIntentPaymentMethodOptionsMandateOptionsSepaDebit option
    }
    with

        static member Create (?mandateOptions: SetupIntentPaymentMethodOptionsMandateOptionsSepaDebit) =
            {
                SetupIntentPaymentMethodOptionsSepaDebit.MandateOptions = mandateOptions
            }

    and Shipping = {
        Address: Address option
        ///The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc.
        Carrier: string option
        ///Recipient name.
        Name: string option
        ///Recipient phone (including extension).
        Phone: string option
        ///The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
        TrackingNumber: string option
    }
    with

        static member Create (?address: Address, ?carrier: string option, ?name: string option, ?phone: string option, ?trackingNumber: string option) =
            {
                Shipping.Address = address
                Shipping.Carrier = carrier |> Option.flatten
                Shipping.Name = name |> Option.flatten
                Shipping.Phone = phone |> Option.flatten
                Shipping.TrackingNumber = trackingNumber |> Option.flatten
            }

    and ShippingMethod = {
        ///A positive integer in the smallest currency unit (that is, 100 cents for $1.00, or 1 for ¥1, Japanese Yen being a zero-decimal currency) representing the total amount for the line item.
        Amount: int
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///The estimated delivery date for the given shipping method. Can be either a specific date or a range.
        DeliveryEstimate: DeliveryEstimate option
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string
        ///Unique identifier for the object.
        Id: string
    }
    with

        static member Create (amount: int, currency: string, deliveryEstimate: DeliveryEstimate option, description: string, id: string) =
            {
                ShippingMethod.Amount = amount //required
                ShippingMethod.Currency = currency //required
                ShippingMethod.DeliveryEstimate = deliveryEstimate //required
                ShippingMethod.Description = description //required
                ShippingMethod.Id = id //required
            }

    and SigmaScheduledQueryRunError = {
        ///Information about the run failure.
        Message: string
    }
    with

        static member Create (message: string) =
            {
                SigmaScheduledQueryRunError.Message = message //required
            }

    ///Stores representations of [stock keeping units](http://en.wikipedia.org/wiki/Stock_keeping_unit).
    ///SKUs describe specific product variations, taking into account any combination of: attributes,
    ///currency, and cost. For example, a product may be a T-shirt, whereas a specific SKU represents
    ///the `size: large`, `color: red` version of that shirt.
    ///Can also be used to manage inventory.
    ///Related guide: [Tax, Shipping, and Inventory](https://stripe.com/docs/orders).
    and Sku = {
        ///Whether the SKU is available for purchase.
        Active: bool
        ///A dictionary of attributes and values for the attributes defined by the product. If, for example, a product's attributes are `["size", "gender"]`, a valid SKU has the following dictionary of attributes: `{"size": "Medium", "gender": "Unisex"}`.
        Attributes: Map<string, string>
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///Unique identifier for the object.
        Id: string
        ///The URL of an image for this SKU, meant to be displayable to the customer.
        Image: string option
        Inventory: Inventory
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        ///The dimensions of this SKU for shipping purposes.
        PackageDimensions: PackageDimensions option
        ///The cost of the item as a positive integer in the smallest currency unit (that is, 100 cents to charge $1.00, or 100 to charge ¥100, Japanese Yen being a zero-decimal currency).
        Price: int
        ///The ID of the product this SKU is associated with. The product must be currently active.
        [<JsonField(Transform=typeof<AnyOfTransform<SkuProduct'AnyOf>>)>]Product: SkuProduct'AnyOf
        ///Time at which the object was last updated. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Updated: DateTime
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "sku"

        static member Create (active: bool, attributes: Map<string, string>, created: DateTime, currency: string, id: string, image: string option, inventory: Inventory, livemode: bool, metadata: Map<string, string>, packageDimensions: PackageDimensions option, price: int, product: SkuProduct'AnyOf, updated: DateTime) =
            {
                Sku.Active = active //required
                Sku.Attributes = attributes //required
                Sku.Created = created //required
                Sku.Currency = currency //required
                Sku.Id = id //required
                Sku.Image = image //required
                Sku.Inventory = inventory //required
                Sku.Livemode = livemode //required
                Sku.Metadata = metadata //required
                Sku.PackageDimensions = packageDimensions //required
                Sku.Price = price //required
                Sku.Product = product //required
                Sku.Updated = updated //required
            }

    and SkuProduct'AnyOf =
        | String of string
        | Product of Product

    ///`Source` objects allow you to accept a variety of payment methods. They
    ///represent a customer's payment instrument, and can be used with the Stripe API
    ///just like a `Card` object: once chargeable, they can be charged, or can be
    ///attached to customers.
    ///Related guides: [Sources API](https://stripe.com/docs/sources) and [Sources & Customers](https://stripe.com/docs/sources/customers).
    and Source = {
        AchCreditTransfer: SourceTypeAchCreditTransfer option
        AchDebit: SourceTypeAchDebit option
        AcssDebit: SourceTypeAcssDebit option
        Alipay: SourceTypeAlipay option
        ///A positive integer in the smallest currency unit (that is, 100 cents for $1.00, or 1 for ¥1, Japanese Yen being a zero-decimal currency) representing the total amount associated with the source. This is the amount for which the source will be chargeable once ready. Required for `single_use` sources.
        Amount: int option
        AuBecsDebit: SourceTypeAuBecsDebit option
        Bancontact: SourceTypeBancontact option
        Card: SourceTypeCard option
        CardPresent: SourceTypeCardPresent option
        ///The client secret of the source. Used for client-side retrieval using a publishable key.
        ClientSecret: string
        CodeVerification: SourceCodeVerificationFlow option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO code for the currency](https://stripe.com/docs/currencies) associated with the source. This is the currency for which the source will be chargeable once ready. Required for `single_use` sources.
        Currency: string option
        ///The ID of the customer to which this source is attached. This will not be present when the source has not been attached to a customer.
        Customer: string option
        Eps: SourceTypeEps option
        ///The authentication `flow` of the source. `flow` is one of `redirect`, `receiver`, `code_verification`, `none`.
        Flow: string
        Giropay: SourceTypeGiropay option
        ///Unique identifier for the object.
        Id: string
        Ideal: SourceTypeIdeal option
        Klarna: SourceTypeKlarna option
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        Multibanco: SourceTypeMultibanco option
        ///Information about the owner of the payment instrument that may be used or required by particular source types.
        Owner: SourceOwner option
        [<JsonField(Name="p24")>]P24: SourceTypeP24 option
        Receiver: SourceReceiverFlow option
        Redirect: SourceRedirectFlow option
        SepaCreditTransfer: SourceTypeSepaCreditTransfer option
        SepaDebit: SourceTypeSepaDebit option
        Sofort: SourceTypeSofort option
        SourceOrder: SourceOrder option
        ///Extra information about a source. This will appear on your customer's statement every time you charge the source.
        StatementDescriptor: string option
        ///The status of the source, one of `canceled`, `chargeable`, `consumed`, `failed`, or `pending`. Only `chargeable` sources can be used to create a charge.
        Status: SourceStatus
        ThreeDSecure: SourceTypeThreeDSecure option
        ///The `type` of the source. The `type` is a payment method, one of `ach_credit_transfer`, `ach_debit`, `alipay`, `bancontact`, `card`, `card_present`, `eps`, `giropay`, `ideal`, `multibanco`, `klarna`, `p24`, `sepa_debit`, `sofort`, `three_d_secure`, or `wechat`. An additional hash is included on the source with a name matching this value. It contains additional information specific to the [payment method](https://stripe.com/docs/sources) used.
        Type: SourceType
        ///Either `reusable` or `single_use`. Whether this source should be reusable or not. Some source types may or may not be reusable by construction, while others may leave the option at creation. If an incompatible value is passed, an error will be returned.
        Usage: SourceUsage option
        Wechat: SourceTypeWechat option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "source"

        static member Create (amount: int option, clientSecret: string, created: DateTime, currency: string option, flow: string, id: string, livemode: bool, metadata: Map<string, string> option, owner: SourceOwner option, statementDescriptor: string option, status: SourceStatus, ``type``: SourceType, usage: SourceUsage option, ?achCreditTransfer: SourceTypeAchCreditTransfer, ?achDebit: SourceTypeAchDebit, ?acssDebit: SourceTypeAcssDebit, ?alipay: SourceTypeAlipay, ?auBecsDebit: SourceTypeAuBecsDebit, ?bancontact: SourceTypeBancontact, ?card: SourceTypeCard, ?cardPresent: SourceTypeCardPresent, ?codeVerification: SourceCodeVerificationFlow, ?customer: string, ?eps: SourceTypeEps, ?giropay: SourceTypeGiropay, ?ideal: SourceTypeIdeal, ?klarna: SourceTypeKlarna, ?multibanco: SourceTypeMultibanco, ?p24: SourceTypeP24, ?receiver: SourceReceiverFlow, ?redirect: SourceRedirectFlow, ?sepaCreditTransfer: SourceTypeSepaCreditTransfer, ?sepaDebit: SourceTypeSepaDebit, ?sofort: SourceTypeSofort, ?sourceOrder: SourceOrder, ?threeDSecure: SourceTypeThreeDSecure, ?wechat: SourceTypeWechat) =
            {
                Source.Amount = amount //required
                Source.ClientSecret = clientSecret //required
                Source.Created = created //required
                Source.Currency = currency //required
                Source.Flow = flow //required
                Source.Id = id //required
                Source.Livemode = livemode //required
                Source.Metadata = metadata //required
                Source.Owner = owner //required
                Source.StatementDescriptor = statementDescriptor //required
                Source.Status = status //required
                Source.Type = ``type`` //required
                Source.Usage = usage //required
                Source.AchCreditTransfer = achCreditTransfer
                Source.AchDebit = achDebit
                Source.AcssDebit = acssDebit
                Source.Alipay = alipay
                Source.AuBecsDebit = auBecsDebit
                Source.Bancontact = bancontact
                Source.Card = card
                Source.CardPresent = cardPresent
                Source.CodeVerification = codeVerification
                Source.Customer = customer
                Source.Eps = eps
                Source.Giropay = giropay
                Source.Ideal = ideal
                Source.Klarna = klarna
                Source.Multibanco = multibanco
                Source.P24 = p24
                Source.Receiver = receiver
                Source.Redirect = redirect
                Source.SepaCreditTransfer = sepaCreditTransfer
                Source.SepaDebit = sepaDebit
                Source.Sofort = sofort
                Source.SourceOrder = sourceOrder
                Source.ThreeDSecure = threeDSecure
                Source.Wechat = wechat
            }

    and SourceStatus =
        | Canceled
        | Chargeable
        | Consumed
        | Failed
        | Pending

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

    and SourceUsage =
        | Reusable
        | SingleUse

    and SourceCodeVerificationFlow = {
        ///The number of attempts remaining to authenticate the source object with a verification code.
        AttemptsRemaining: int
        ///The status of the code verification, either `pending` (awaiting verification, `attempts_remaining` should be greater than 0), `succeeded` (successful verification) or `failed` (failed verification, cannot be verified anymore as `attempts_remaining` should be 0).
        Status: string
    }
    with

        static member Create (attemptsRemaining: int, status: string) =
            {
                SourceCodeVerificationFlow.AttemptsRemaining = attemptsRemaining //required
                SourceCodeVerificationFlow.Status = status //required
            }

    ///Source mandate notifications should be created when a notification related to
    ///a source mandate must be sent to the payer. They will trigger a webhook or
    ///deliver an email to the customer.
    and SourceMandateNotification = {
        AcssDebit: SourceMandateNotificationAcssDebitData option
        ///A positive integer in the smallest currency unit (that is, 100 cents for $1.00, or 1 for ¥1, Japanese Yen being a zero-decimal currency) representing the amount associated with the mandate notification. The amount is expressed in the currency of the underlying source. Required if the notification type is `debit_initiated`.
        Amount: int option
        BacsDebit: SourceMandateNotificationBacsDebitData option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///The reason of the mandate notification. Valid reasons are `mandate_confirmed` or `debit_initiated`.
        Reason: SourceMandateNotificationReason
        SepaDebit: SourceMandateNotificationSepaDebitData option
        Source: Source
        ///The status of the mandate notification. Valid statuses are `pending` or `submitted`.
        Status: SourceMandateNotificationStatus
        ///The type of source this mandate notification is attached to. Should be the source type identifier code for the payment method, such as `three_d_secure`.
        Type: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "source_mandate_notification"

        static member Create (amount: int option, created: DateTime, id: string, livemode: bool, reason: SourceMandateNotificationReason, source: Source, status: SourceMandateNotificationStatus, ``type``: string, ?acssDebit: SourceMandateNotificationAcssDebitData, ?bacsDebit: SourceMandateNotificationBacsDebitData, ?sepaDebit: SourceMandateNotificationSepaDebitData) =
            {
                SourceMandateNotification.Amount = amount //required
                SourceMandateNotification.Created = created //required
                SourceMandateNotification.Id = id //required
                SourceMandateNotification.Livemode = livemode //required
                SourceMandateNotification.Reason = reason //required
                SourceMandateNotification.Source = source //required
                SourceMandateNotification.Status = status //required
                SourceMandateNotification.Type = ``type`` //required
                SourceMandateNotification.AcssDebit = acssDebit
                SourceMandateNotification.BacsDebit = bacsDebit
                SourceMandateNotification.SepaDebit = sepaDebit
            }

    and SourceMandateNotificationReason =
        | MandateConfirmed
        | DebitInitiated

    and SourceMandateNotificationStatus =
        | Pending
        | Submitted

    and SourceMandateNotificationAcssDebitData = {
        ///The statement descriptor associate with the debit.
        StatementDescriptor: string option
    }
    with

        static member Create (?statementDescriptor: string) =
            {
                SourceMandateNotificationAcssDebitData.StatementDescriptor = statementDescriptor
            }

    and SourceMandateNotificationBacsDebitData = {
        ///Last 4 digits of the account number associated with the debit.
        [<JsonField(Name="last4")>]Last4: string option
    }
    with

        static member Create (?last4: string) =
            {
                SourceMandateNotificationBacsDebitData.Last4 = last4
            }

    and SourceMandateNotificationSepaDebitData = {
        ///SEPA creditor ID.
        CreditorIdentifier: string option
        ///Last 4 digits of the account number associated with the debit.
        [<JsonField(Name="last4")>]Last4: string option
        ///Mandate reference associated with the debit.
        MandateReference: string option
    }
    with

        static member Create (?creditorIdentifier: string, ?last4: string, ?mandateReference: string) =
            {
                SourceMandateNotificationSepaDebitData.CreditorIdentifier = creditorIdentifier
                SourceMandateNotificationSepaDebitData.Last4 = last4
                SourceMandateNotificationSepaDebitData.MandateReference = mandateReference
            }

    and SourceOrder = {
        ///A positive integer in the smallest currency unit (that is, 100 cents for $1.00, or 1 for ¥1, Japanese Yen being a zero-decimal currency) representing the total amount for the order.
        Amount: int
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///The email address of the customer placing the order.
        Email: string option
        ///List of items constituting the order.
        Items: SourceOrderItem list option
        Shipping: Shipping option
    }
    with

        static member Create (amount: int, currency: string, items: SourceOrderItem list option, ?email: string, ?shipping: Shipping) =
            {
                SourceOrder.Amount = amount //required
                SourceOrder.Currency = currency //required
                SourceOrder.Items = items //required
                SourceOrder.Email = email
                SourceOrder.Shipping = shipping
            }

    and SourceOrderItem = {
        ///The amount (price) for this order item.
        Amount: int option
        ///This currency of this order item. Required when `amount` is present.
        Currency: string option
        ///Human-readable description for this order item.
        Description: string option
        ///The ID of the associated object for this line item. Expandable if not null (e.g., expandable to a SKU).
        Parent: string option
        ///The quantity of this order item. When type is `sku`, this is the number of instances of the SKU to be ordered.
        Quantity: int option
        ///The type of this order item. Must be `sku`, `tax`, or `shipping`.
        Type: SourceOrderItemType option
    }
    with

        static member Create (amount: int option, currency: string option, description: string option, parent: string option, ``type``: SourceOrderItemType option, ?quantity: int) =
            {
                SourceOrderItem.Amount = amount //required
                SourceOrderItem.Currency = currency //required
                SourceOrderItem.Description = description //required
                SourceOrderItem.Parent = parent //required
                SourceOrderItem.Type = ``type`` //required
                SourceOrderItem.Quantity = quantity
            }

    and SourceOrderItemType =
        | Sku
        | Tax
        | Shipping

    and SourceOwner = {
        ///Owner's address.
        Address: Address option
        ///Owner's email address.
        Email: string option
        ///Owner's full name.
        Name: string option
        ///Owner's phone number (including extension).
        Phone: string option
        ///Verified owner's address. Verified values are verified or provided by the payment method directly (and if supported) at the time of authorization or settlement. They cannot be set or mutated.
        VerifiedAddress: Address option
        ///Verified owner's email address. Verified values are verified or provided by the payment method directly (and if supported) at the time of authorization or settlement. They cannot be set or mutated.
        VerifiedEmail: string option
        ///Verified owner's full name. Verified values are verified or provided by the payment method directly (and if supported) at the time of authorization or settlement. They cannot be set or mutated.
        VerifiedName: string option
        ///Verified owner's phone number (including extension). Verified values are verified or provided by the payment method directly (and if supported) at the time of authorization or settlement. They cannot be set or mutated.
        VerifiedPhone: string option
    }
    with

        static member Create (address: Address option, email: string option, name: string option, phone: string option, verifiedAddress: Address option, verifiedEmail: string option, verifiedName: string option, verifiedPhone: string option) =
            {
                SourceOwner.Address = address //required
                SourceOwner.Email = email //required
                SourceOwner.Name = name //required
                SourceOwner.Phone = phone //required
                SourceOwner.VerifiedAddress = verifiedAddress //required
                SourceOwner.VerifiedEmail = verifiedEmail //required
                SourceOwner.VerifiedName = verifiedName //required
                SourceOwner.VerifiedPhone = verifiedPhone //required
            }

    and SourceReceiverFlow = {
        ///The address of the receiver source. This is the value that should be communicated to the customer to send their funds to.
        Address: string option
        ///The total amount that was moved to your balance. This is almost always equal to the amount charged. In rare cases when customers deposit excess funds and we are unable to refund those, those funds get moved to your balance and show up in amount_charged as well. The amount charged is expressed in the source's currency.
        AmountCharged: int
        ///The total amount received by the receiver source. `amount_received = amount_returned + amount_charged` should be true for consumed sources unless customers deposit excess funds. The amount received is expressed in the source's currency.
        AmountReceived: int
        ///The total amount that was returned to the customer. The amount returned is expressed in the source's currency.
        AmountReturned: int
        ///Type of refund attribute method, one of `email`, `manual`, or `none`.
        RefundAttributesMethod: SourceReceiverFlowRefundAttributesMethod
        ///Type of refund attribute status, one of `missing`, `requested`, or `available`.
        RefundAttributesStatus: SourceReceiverFlowRefundAttributesStatus
    }
    with

        static member Create (address: string option, amountCharged: int, amountReceived: int, amountReturned: int, refundAttributesMethod: SourceReceiverFlowRefundAttributesMethod, refundAttributesStatus: SourceReceiverFlowRefundAttributesStatus) =
            {
                SourceReceiverFlow.Address = address //required
                SourceReceiverFlow.AmountCharged = amountCharged //required
                SourceReceiverFlow.AmountReceived = amountReceived //required
                SourceReceiverFlow.AmountReturned = amountReturned //required
                SourceReceiverFlow.RefundAttributesMethod = refundAttributesMethod //required
                SourceReceiverFlow.RefundAttributesStatus = refundAttributesStatus //required
            }

    and SourceReceiverFlowRefundAttributesMethod =
        | Email
        | Manual
        | None'

    and SourceReceiverFlowRefundAttributesStatus =
        | Missing
        | Requested
        | Available

    and SourceRedirectFlow = {
        ///The failure reason for the redirect, either `user_abort` (the customer aborted or dropped out of the redirect flow), `declined` (the authentication failed or the transaction was declined), or `processing_error` (the redirect failed due to a technical error). Present only if the redirect status is `failed`.
        FailureReason: string option
        ///The URL you provide to redirect the customer to after they authenticated their payment.
        ReturnUrl: string
        ///The status of the redirect, either `pending` (ready to be used by your customer to authenticate the transaction), `succeeded` (succesful authentication, cannot be reused) or `not_required` (redirect should not be used) or `failed` (failed authentication, cannot be reused).
        Status: string
        ///The URL provided to you to redirect a customer to as part of a `redirect` authentication flow.
        Url: string
    }
    with

        static member Create (failureReason: string option, returnUrl: string, status: string, url: string) =
            {
                SourceRedirectFlow.FailureReason = failureReason //required
                SourceRedirectFlow.ReturnUrl = returnUrl //required
                SourceRedirectFlow.Status = status //required
                SourceRedirectFlow.Url = url //required
            }

    ///Some payment methods have no required amount that a customer must send.
    ///Customers can be instructed to send any amount, and it can be made up of
    ///multiple transactions. As such, sources can have multiple associated
    ///transactions.
    and SourceTransaction = {
        AchCreditTransfer: SourceTransactionAchCreditTransferData option
        ///A positive integer in the smallest currency unit (that is, 100 cents for $1.00, or 1 for ¥1, Japanese Yen being a zero-decimal currency) representing the amount your customer has pushed to the receiver.
        Amount: int
        ChfCreditTransfer: SourceTransactionChfCreditTransferData option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        GbpCreditTransfer: SourceTransactionGbpCreditTransferData option
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        PaperCheck: SourceTransactionPaperCheckData option
        SepaCreditTransfer: SourceTransactionSepaCreditTransferData option
        ///The ID of the source this transaction is attached to.
        Source: string
        ///The status of the transaction, one of `succeeded`, `pending`, or `failed`.
        Status: SourceTransactionStatus
        ///The type of source this transaction is attached to.
        Type: SourceTransactionType
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "source_transaction"

        static member Create (amount: int, created: DateTime, currency: string, id: string, livemode: bool, source: string, status: SourceTransactionStatus, ``type``: SourceTransactionType, ?achCreditTransfer: SourceTransactionAchCreditTransferData, ?chfCreditTransfer: SourceTransactionChfCreditTransferData, ?gbpCreditTransfer: SourceTransactionGbpCreditTransferData, ?paperCheck: SourceTransactionPaperCheckData, ?sepaCreditTransfer: SourceTransactionSepaCreditTransferData) =
            {
                SourceTransaction.Amount = amount //required
                SourceTransaction.Created = created //required
                SourceTransaction.Currency = currency //required
                SourceTransaction.Id = id //required
                SourceTransaction.Livemode = livemode //required
                SourceTransaction.Source = source //required
                SourceTransaction.Status = status //required
                SourceTransaction.Type = ``type`` //required
                SourceTransaction.AchCreditTransfer = achCreditTransfer
                SourceTransaction.ChfCreditTransfer = chfCreditTransfer
                SourceTransaction.GbpCreditTransfer = gbpCreditTransfer
                SourceTransaction.PaperCheck = paperCheck
                SourceTransaction.SepaCreditTransfer = sepaCreditTransfer
            }

    and SourceTransactionStatus =
        | Succeeded
        | Pending
        | Failed

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

    and SourceTransactionAchCreditTransferData = {
        ///Customer data associated with the transfer.
        CustomerData: string option
        ///Bank account fingerprint associated with the transfer.
        Fingerprint: string option
        ///Last 4 digits of the account number associated with the transfer.
        [<JsonField(Name="last4")>]Last4: string option
        ///Routing number associated with the transfer.
        RoutingNumber: string option
    }
    with

        static member Create (?customerData: string, ?fingerprint: string, ?last4: string, ?routingNumber: string) =
            {
                SourceTransactionAchCreditTransferData.CustomerData = customerData
                SourceTransactionAchCreditTransferData.Fingerprint = fingerprint
                SourceTransactionAchCreditTransferData.Last4 = last4
                SourceTransactionAchCreditTransferData.RoutingNumber = routingNumber
            }

    and SourceTransactionChfCreditTransferData = {
        ///Reference associated with the transfer.
        Reference: string option
        ///Sender's country address.
        SenderAddressCountry: string option
        ///Sender's line 1 address.
        [<JsonField(Name="sender_address_line1")>]SenderAddressLine1: string option
        ///Sender's bank account IBAN.
        SenderIban: string option
        ///Sender's name.
        SenderName: string option
    }
    with

        static member Create (?reference: string, ?senderAddressCountry: string, ?senderAddressLine1: string, ?senderIban: string, ?senderName: string) =
            {
                SourceTransactionChfCreditTransferData.Reference = reference
                SourceTransactionChfCreditTransferData.SenderAddressCountry = senderAddressCountry
                SourceTransactionChfCreditTransferData.SenderAddressLine1 = senderAddressLine1
                SourceTransactionChfCreditTransferData.SenderIban = senderIban
                SourceTransactionChfCreditTransferData.SenderName = senderName
            }

    and SourceTransactionGbpCreditTransferData = {
        ///Bank account fingerprint associated with the Stripe owned bank account receiving the transfer.
        Fingerprint: string option
        ///The credit transfer rails the sender used to push this transfer. The possible rails are: Faster Payments, BACS, CHAPS, and wire transfers. Currently only Faster Payments is supported.
        FundingMethod: string option
        ///Last 4 digits of sender account number associated with the transfer.
        [<JsonField(Name="last4")>]Last4: string option
        ///Sender entered arbitrary information about the transfer.
        Reference: string option
        ///Sender account number associated with the transfer.
        SenderAccountNumber: string option
        ///Sender name associated with the transfer.
        SenderName: string option
        ///Sender sort code associated with the transfer.
        SenderSortCode: string option
    }
    with

        static member Create (?fingerprint: string, ?fundingMethod: string, ?last4: string, ?reference: string, ?senderAccountNumber: string, ?senderName: string, ?senderSortCode: string) =
            {
                SourceTransactionGbpCreditTransferData.Fingerprint = fingerprint
                SourceTransactionGbpCreditTransferData.FundingMethod = fundingMethod
                SourceTransactionGbpCreditTransferData.Last4 = last4
                SourceTransactionGbpCreditTransferData.Reference = reference
                SourceTransactionGbpCreditTransferData.SenderAccountNumber = senderAccountNumber
                SourceTransactionGbpCreditTransferData.SenderName = senderName
                SourceTransactionGbpCreditTransferData.SenderSortCode = senderSortCode
            }

    and SourceTransactionPaperCheckData = {
        ///Time at which the deposited funds will be available for use. Measured in seconds since the Unix epoch.
        AvailableAt: string option
        ///Comma-separated list of invoice IDs associated with the paper check.
        Invoices: string option
    }
    with

        static member Create (?availableAt: string, ?invoices: string) =
            {
                SourceTransactionPaperCheckData.AvailableAt = availableAt
                SourceTransactionPaperCheckData.Invoices = invoices
            }

    and SourceTransactionSepaCreditTransferData = {
        ///Reference associated with the transfer.
        Reference: string option
        ///Sender's bank account IBAN.
        SenderIban: string option
        ///Sender's name.
        SenderName: string option
    }
    with

        static member Create (?reference: string, ?senderIban: string, ?senderName: string) =
            {
                SourceTransactionSepaCreditTransferData.Reference = reference
                SourceTransactionSepaCreditTransferData.SenderIban = senderIban
                SourceTransactionSepaCreditTransferData.SenderName = senderName
            }

    and SourceTypeAchCreditTransfer = {
        AccountNumber: string option
        BankName: string option
        Fingerprint: string option
        RefundAccountHolderName: string option
        RefundAccountHolderType: string option
        RefundRoutingNumber: string option
        RoutingNumber: string option
        SwiftCode: string option
    }
    with

        static member Create (?accountNumber: string option, ?bankName: string option, ?fingerprint: string option, ?refundAccountHolderName: string option, ?refundAccountHolderType: string option, ?refundRoutingNumber: string option, ?routingNumber: string option, ?swiftCode: string option) =
            {
                SourceTypeAchCreditTransfer.AccountNumber = accountNumber |> Option.flatten
                SourceTypeAchCreditTransfer.BankName = bankName |> Option.flatten
                SourceTypeAchCreditTransfer.Fingerprint = fingerprint |> Option.flatten
                SourceTypeAchCreditTransfer.RefundAccountHolderName = refundAccountHolderName |> Option.flatten
                SourceTypeAchCreditTransfer.RefundAccountHolderType = refundAccountHolderType |> Option.flatten
                SourceTypeAchCreditTransfer.RefundRoutingNumber = refundRoutingNumber |> Option.flatten
                SourceTypeAchCreditTransfer.RoutingNumber = routingNumber |> Option.flatten
                SourceTypeAchCreditTransfer.SwiftCode = swiftCode |> Option.flatten
            }

    and SourceTypeAchDebit = {
        BankName: string option
        Country: string option
        Fingerprint: string option
        [<JsonField(Name="last4")>]Last4: string option
        RoutingNumber: string option
        Type: string option
    }
    with

        static member Create (?bankName: string option, ?country: string option, ?fingerprint: string option, ?last4: string option, ?routingNumber: string option, ?``type``: string option) =
            {
                SourceTypeAchDebit.BankName = bankName |> Option.flatten
                SourceTypeAchDebit.Country = country |> Option.flatten
                SourceTypeAchDebit.Fingerprint = fingerprint |> Option.flatten
                SourceTypeAchDebit.Last4 = last4 |> Option.flatten
                SourceTypeAchDebit.RoutingNumber = routingNumber |> Option.flatten
                SourceTypeAchDebit.Type = ``type`` |> Option.flatten
            }

    and SourceTypeAcssDebit = {
        BankAddressCity: string option
        BankAddressLine1: string option
        BankAddressLine2: string option
        BankAddressPostalCode: string option
        BankName: string option
        Category: string option
        Country: string option
        Fingerprint: string option
        [<JsonField(Name="last4")>]Last4: string option
        RoutingNumber: string option
    }
    with

        static member Create (?bankAddressCity: string option, ?bankAddressLine1: string option, ?bankAddressLine2: string option, ?bankAddressPostalCode: string option, ?bankName: string option, ?category: string option, ?country: string option, ?fingerprint: string option, ?last4: string option, ?routingNumber: string option) =
            {
                SourceTypeAcssDebit.BankAddressCity = bankAddressCity |> Option.flatten
                SourceTypeAcssDebit.BankAddressLine1 = bankAddressLine1 |> Option.flatten
                SourceTypeAcssDebit.BankAddressLine2 = bankAddressLine2 |> Option.flatten
                SourceTypeAcssDebit.BankAddressPostalCode = bankAddressPostalCode |> Option.flatten
                SourceTypeAcssDebit.BankName = bankName |> Option.flatten
                SourceTypeAcssDebit.Category = category |> Option.flatten
                SourceTypeAcssDebit.Country = country |> Option.flatten
                SourceTypeAcssDebit.Fingerprint = fingerprint |> Option.flatten
                SourceTypeAcssDebit.Last4 = last4 |> Option.flatten
                SourceTypeAcssDebit.RoutingNumber = routingNumber |> Option.flatten
            }

    and SourceTypeAlipay = {
        DataString: string option
        NativeUrl: string option
        StatementDescriptor: string option
    }
    with

        static member Create (?dataString: string option, ?nativeUrl: string option, ?statementDescriptor: string option) =
            {
                SourceTypeAlipay.DataString = dataString |> Option.flatten
                SourceTypeAlipay.NativeUrl = nativeUrl |> Option.flatten
                SourceTypeAlipay.StatementDescriptor = statementDescriptor |> Option.flatten
            }

    and SourceTypeAuBecsDebit = {
        BsbNumber: string option
        Fingerprint: string option
        [<JsonField(Name="last4")>]Last4: string option
    }
    with

        static member Create (?bsbNumber: string option, ?fingerprint: string option, ?last4: string option) =
            {
                SourceTypeAuBecsDebit.BsbNumber = bsbNumber |> Option.flatten
                SourceTypeAuBecsDebit.Fingerprint = fingerprint |> Option.flatten
                SourceTypeAuBecsDebit.Last4 = last4 |> Option.flatten
            }

    and SourceTypeBancontact = {
        BankCode: string option
        BankName: string option
        Bic: string option
        [<JsonField(Name="iban_last4")>]IbanLast4: string option
        PreferredLanguage: string option
        StatementDescriptor: string option
    }
    with

        static member Create (?bankCode: string option, ?bankName: string option, ?bic: string option, ?ibanLast4: string option, ?preferredLanguage: string option, ?statementDescriptor: string option) =
            {
                SourceTypeBancontact.BankCode = bankCode |> Option.flatten
                SourceTypeBancontact.BankName = bankName |> Option.flatten
                SourceTypeBancontact.Bic = bic |> Option.flatten
                SourceTypeBancontact.IbanLast4 = ibanLast4 |> Option.flatten
                SourceTypeBancontact.PreferredLanguage = preferredLanguage |> Option.flatten
                SourceTypeBancontact.StatementDescriptor = statementDescriptor |> Option.flatten
            }

    and SourceTypeCard = {
        [<JsonField(Name="address_line1_check")>]AddressLine1Check: string option
        AddressZipCheck: string option
        Brand: string option
        Country: string option
        CvcCheck: string option
        Description: string option
        [<JsonField(Name="dynamic_last4")>]DynamicLast4: string option
        ExpMonth: int option
        ExpYear: int option
        Fingerprint: string option
        Funding: string option
        Iin: string option
        Issuer: string option
        [<JsonField(Name="last4")>]Last4: string option
        Name: string option
        ThreeDSecure: string option
        TokenizationMethod: string option
    }
    with

        static member Create (?addressLine1Check: string option, ?addressZipCheck: string option, ?brand: string option, ?country: string option, ?cvcCheck: string option, ?description: string, ?dynamicLast4: string option, ?expMonth: int option, ?expYear: int option, ?fingerprint: string, ?funding: string option, ?iin: string, ?issuer: string, ?last4: string option, ?name: string option, ?threeDSecure: string, ?tokenizationMethod: string option) =
            {
                SourceTypeCard.AddressLine1Check = addressLine1Check |> Option.flatten
                SourceTypeCard.AddressZipCheck = addressZipCheck |> Option.flatten
                SourceTypeCard.Brand = brand |> Option.flatten
                SourceTypeCard.Country = country |> Option.flatten
                SourceTypeCard.CvcCheck = cvcCheck |> Option.flatten
                SourceTypeCard.Description = description
                SourceTypeCard.DynamicLast4 = dynamicLast4 |> Option.flatten
                SourceTypeCard.ExpMonth = expMonth |> Option.flatten
                SourceTypeCard.ExpYear = expYear |> Option.flatten
                SourceTypeCard.Fingerprint = fingerprint
                SourceTypeCard.Funding = funding |> Option.flatten
                SourceTypeCard.Iin = iin
                SourceTypeCard.Issuer = issuer
                SourceTypeCard.Last4 = last4 |> Option.flatten
                SourceTypeCard.Name = name |> Option.flatten
                SourceTypeCard.ThreeDSecure = threeDSecure
                SourceTypeCard.TokenizationMethod = tokenizationMethod |> Option.flatten
            }

    and SourceTypeCardPresent = {
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
        ExpMonth: int option
        ExpYear: int option
        Fingerprint: string option
        Funding: string option
        Iin: string option
        Issuer: string option
        [<JsonField(Name="last4")>]Last4: string option
        PosDeviceId: string option
        PosEntryMode: string option
        ReadMethod: string option
        Reader: string option
        TerminalVerificationResults: string option
        TransactionStatusInformation: string option
    }
    with

        static member Create (?applicationCryptogram: string, ?applicationPreferredName: string, ?authorizationCode: string option, ?authorizationResponseCode: string, ?brand: string option, ?country: string option, ?cvmType: string, ?dataType: string option, ?dedicatedFileName: string, ?description: string, ?emvAuthData: string, ?evidenceCustomerSignature: string option, ?evidenceTransactionCertificate: string option, ?expMonth: int option, ?expYear: int option, ?fingerprint: string, ?funding: string option, ?iin: string, ?issuer: string, ?last4: string option, ?posDeviceId: string option, ?posEntryMode: string, ?readMethod: string option, ?reader: string option, ?terminalVerificationResults: string, ?transactionStatusInformation: string) =
            {
                SourceTypeCardPresent.ApplicationCryptogram = applicationCryptogram
                SourceTypeCardPresent.ApplicationPreferredName = applicationPreferredName
                SourceTypeCardPresent.AuthorizationCode = authorizationCode |> Option.flatten
                SourceTypeCardPresent.AuthorizationResponseCode = authorizationResponseCode
                SourceTypeCardPresent.Brand = brand |> Option.flatten
                SourceTypeCardPresent.Country = country |> Option.flatten
                SourceTypeCardPresent.CvmType = cvmType
                SourceTypeCardPresent.DataType = dataType |> Option.flatten
                SourceTypeCardPresent.DedicatedFileName = dedicatedFileName
                SourceTypeCardPresent.Description = description
                SourceTypeCardPresent.EmvAuthData = emvAuthData
                SourceTypeCardPresent.EvidenceCustomerSignature = evidenceCustomerSignature |> Option.flatten
                SourceTypeCardPresent.EvidenceTransactionCertificate = evidenceTransactionCertificate |> Option.flatten
                SourceTypeCardPresent.ExpMonth = expMonth |> Option.flatten
                SourceTypeCardPresent.ExpYear = expYear |> Option.flatten
                SourceTypeCardPresent.Fingerprint = fingerprint
                SourceTypeCardPresent.Funding = funding |> Option.flatten
                SourceTypeCardPresent.Iin = iin
                SourceTypeCardPresent.Issuer = issuer
                SourceTypeCardPresent.Last4 = last4 |> Option.flatten
                SourceTypeCardPresent.PosDeviceId = posDeviceId |> Option.flatten
                SourceTypeCardPresent.PosEntryMode = posEntryMode
                SourceTypeCardPresent.ReadMethod = readMethod |> Option.flatten
                SourceTypeCardPresent.Reader = reader |> Option.flatten
                SourceTypeCardPresent.TerminalVerificationResults = terminalVerificationResults
                SourceTypeCardPresent.TransactionStatusInformation = transactionStatusInformation
            }

    and SourceTypeEps = {
        Reference: string option
        StatementDescriptor: string option
    }
    with

        static member Create (?reference: string option, ?statementDescriptor: string option) =
            {
                SourceTypeEps.Reference = reference |> Option.flatten
                SourceTypeEps.StatementDescriptor = statementDescriptor |> Option.flatten
            }

    and SourceTypeGiropay = {
        BankCode: string option
        BankName: string option
        Bic: string option
        StatementDescriptor: string option
    }
    with

        static member Create (?bankCode: string option, ?bankName: string option, ?bic: string option, ?statementDescriptor: string option) =
            {
                SourceTypeGiropay.BankCode = bankCode |> Option.flatten
                SourceTypeGiropay.BankName = bankName |> Option.flatten
                SourceTypeGiropay.Bic = bic |> Option.flatten
                SourceTypeGiropay.StatementDescriptor = statementDescriptor |> Option.flatten
            }

    and SourceTypeIdeal = {
        Bank: string option
        Bic: string option
        [<JsonField(Name="iban_last4")>]IbanLast4: string option
        StatementDescriptor: string option
    }
    with

        static member Create (?bank: string option, ?bic: string option, ?ibanLast4: string option, ?statementDescriptor: string option) =
            {
                SourceTypeIdeal.Bank = bank |> Option.flatten
                SourceTypeIdeal.Bic = bic |> Option.flatten
                SourceTypeIdeal.IbanLast4 = ibanLast4 |> Option.flatten
                SourceTypeIdeal.StatementDescriptor = statementDescriptor |> Option.flatten
            }

    and SourceTypeKlarna = {
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
        ShippingDelay: int option
        ShippingFirstName: string option
        ShippingLastName: string option
    }
    with

        static member Create (?backgroundImageUrl: string, ?clientToken: string option, ?firstName: string, ?lastName: string, ?locale: string, ?logoUrl: string, ?pageTitle: string, ?payLaterAssetUrlsDescriptive: string, ?payLaterAssetUrlsStandard: string, ?payLaterName: string, ?payLaterRedirectUrl: string, ?payNowAssetUrlsDescriptive: string, ?payNowAssetUrlsStandard: string, ?payNowName: string, ?payNowRedirectUrl: string, ?payOverTimeAssetUrlsDescriptive: string, ?payOverTimeAssetUrlsStandard: string, ?payOverTimeName: string, ?payOverTimeRedirectUrl: string, ?paymentMethodCategories: string, ?purchaseCountry: string, ?purchaseType: string, ?redirectUrl: string, ?shippingDelay: int, ?shippingFirstName: string, ?shippingLastName: string) =
            {
                SourceTypeKlarna.BackgroundImageUrl = backgroundImageUrl
                SourceTypeKlarna.ClientToken = clientToken |> Option.flatten
                SourceTypeKlarna.FirstName = firstName
                SourceTypeKlarna.LastName = lastName
                SourceTypeKlarna.Locale = locale
                SourceTypeKlarna.LogoUrl = logoUrl
                SourceTypeKlarna.PageTitle = pageTitle
                SourceTypeKlarna.PayLaterAssetUrlsDescriptive = payLaterAssetUrlsDescriptive
                SourceTypeKlarna.PayLaterAssetUrlsStandard = payLaterAssetUrlsStandard
                SourceTypeKlarna.PayLaterName = payLaterName
                SourceTypeKlarna.PayLaterRedirectUrl = payLaterRedirectUrl
                SourceTypeKlarna.PayNowAssetUrlsDescriptive = payNowAssetUrlsDescriptive
                SourceTypeKlarna.PayNowAssetUrlsStandard = payNowAssetUrlsStandard
                SourceTypeKlarna.PayNowName = payNowName
                SourceTypeKlarna.PayNowRedirectUrl = payNowRedirectUrl
                SourceTypeKlarna.PayOverTimeAssetUrlsDescriptive = payOverTimeAssetUrlsDescriptive
                SourceTypeKlarna.PayOverTimeAssetUrlsStandard = payOverTimeAssetUrlsStandard
                SourceTypeKlarna.PayOverTimeName = payOverTimeName
                SourceTypeKlarna.PayOverTimeRedirectUrl = payOverTimeRedirectUrl
                SourceTypeKlarna.PaymentMethodCategories = paymentMethodCategories
                SourceTypeKlarna.PurchaseCountry = purchaseCountry
                SourceTypeKlarna.PurchaseType = purchaseType
                SourceTypeKlarna.RedirectUrl = redirectUrl
                SourceTypeKlarna.ShippingDelay = shippingDelay
                SourceTypeKlarna.ShippingFirstName = shippingFirstName
                SourceTypeKlarna.ShippingLastName = shippingLastName
            }

    and SourceTypeMultibanco = {
        Entity: string option
        Reference: string option
        RefundAccountHolderAddressCity: string option
        RefundAccountHolderAddressCountry: string option
        [<JsonField(Name="refund_account_holder_address_line1")>]RefundAccountHolderAddressLine1: string option
        [<JsonField(Name="refund_account_holder_address_line2")>]RefundAccountHolderAddressLine2: string option
        RefundAccountHolderAddressPostalCode: string option
        RefundAccountHolderAddressState: string option
        RefundAccountHolderName: string option
        RefundIban: string option
    }
    with

        static member Create (?entity: string option, ?reference: string option, ?refundAccountHolderAddressCity: string option, ?refundAccountHolderAddressCountry: string option, ?refundAccountHolderAddressLine1: string option, ?refundAccountHolderAddressLine2: string option, ?refundAccountHolderAddressPostalCode: string option, ?refundAccountHolderAddressState: string option, ?refundAccountHolderName: string option, ?refundIban: string option) =
            {
                SourceTypeMultibanco.Entity = entity |> Option.flatten
                SourceTypeMultibanco.Reference = reference |> Option.flatten
                SourceTypeMultibanco.RefundAccountHolderAddressCity = refundAccountHolderAddressCity |> Option.flatten
                SourceTypeMultibanco.RefundAccountHolderAddressCountry = refundAccountHolderAddressCountry |> Option.flatten
                SourceTypeMultibanco.RefundAccountHolderAddressLine1 = refundAccountHolderAddressLine1 |> Option.flatten
                SourceTypeMultibanco.RefundAccountHolderAddressLine2 = refundAccountHolderAddressLine2 |> Option.flatten
                SourceTypeMultibanco.RefundAccountHolderAddressPostalCode = refundAccountHolderAddressPostalCode |> Option.flatten
                SourceTypeMultibanco.RefundAccountHolderAddressState = refundAccountHolderAddressState |> Option.flatten
                SourceTypeMultibanco.RefundAccountHolderName = refundAccountHolderName |> Option.flatten
                SourceTypeMultibanco.RefundIban = refundIban |> Option.flatten
            }

    and SourceTypeP24 = {
        Reference: string option
    }
    with

        static member Create (?reference: string option) =
            {
                SourceTypeP24.Reference = reference |> Option.flatten
            }

    and SourceTypeSepaCreditTransfer = {
        BankName: string option
        Bic: string option
        Iban: string option
        RefundAccountHolderAddressCity: string option
        RefundAccountHolderAddressCountry: string option
        [<JsonField(Name="refund_account_holder_address_line1")>]RefundAccountHolderAddressLine1: string option
        [<JsonField(Name="refund_account_holder_address_line2")>]RefundAccountHolderAddressLine2: string option
        RefundAccountHolderAddressPostalCode: string option
        RefundAccountHolderAddressState: string option
        RefundAccountHolderName: string option
        RefundIban: string option
    }
    with

        static member Create (?bankName: string option, ?bic: string option, ?iban: string option, ?refundAccountHolderAddressCity: string option, ?refundAccountHolderAddressCountry: string option, ?refundAccountHolderAddressLine1: string option, ?refundAccountHolderAddressLine2: string option, ?refundAccountHolderAddressPostalCode: string option, ?refundAccountHolderAddressState: string option, ?refundAccountHolderName: string option, ?refundIban: string option) =
            {
                SourceTypeSepaCreditTransfer.BankName = bankName |> Option.flatten
                SourceTypeSepaCreditTransfer.Bic = bic |> Option.flatten
                SourceTypeSepaCreditTransfer.Iban = iban |> Option.flatten
                SourceTypeSepaCreditTransfer.RefundAccountHolderAddressCity = refundAccountHolderAddressCity |> Option.flatten
                SourceTypeSepaCreditTransfer.RefundAccountHolderAddressCountry = refundAccountHolderAddressCountry |> Option.flatten
                SourceTypeSepaCreditTransfer.RefundAccountHolderAddressLine1 = refundAccountHolderAddressLine1 |> Option.flatten
                SourceTypeSepaCreditTransfer.RefundAccountHolderAddressLine2 = refundAccountHolderAddressLine2 |> Option.flatten
                SourceTypeSepaCreditTransfer.RefundAccountHolderAddressPostalCode = refundAccountHolderAddressPostalCode |> Option.flatten
                SourceTypeSepaCreditTransfer.RefundAccountHolderAddressState = refundAccountHolderAddressState |> Option.flatten
                SourceTypeSepaCreditTransfer.RefundAccountHolderName = refundAccountHolderName |> Option.flatten
                SourceTypeSepaCreditTransfer.RefundIban = refundIban |> Option.flatten
            }

    and SourceTypeSepaDebit = {
        BankCode: string option
        BranchCode: string option
        Country: string option
        Fingerprint: string option
        [<JsonField(Name="last4")>]Last4: string option
        MandateReference: string option
        MandateUrl: string option
    }
    with

        static member Create (?bankCode: string option, ?branchCode: string option, ?country: string option, ?fingerprint: string option, ?last4: string option, ?mandateReference: string option, ?mandateUrl: string option) =
            {
                SourceTypeSepaDebit.BankCode = bankCode |> Option.flatten
                SourceTypeSepaDebit.BranchCode = branchCode |> Option.flatten
                SourceTypeSepaDebit.Country = country |> Option.flatten
                SourceTypeSepaDebit.Fingerprint = fingerprint |> Option.flatten
                SourceTypeSepaDebit.Last4 = last4 |> Option.flatten
                SourceTypeSepaDebit.MandateReference = mandateReference |> Option.flatten
                SourceTypeSepaDebit.MandateUrl = mandateUrl |> Option.flatten
            }

    and SourceTypeSofort = {
        BankCode: string option
        BankName: string option
        Bic: string option
        Country: string option
        [<JsonField(Name="iban_last4")>]IbanLast4: string option
        PreferredLanguage: string option
        StatementDescriptor: string option
    }
    with

        static member Create (?bankCode: string option, ?bankName: string option, ?bic: string option, ?country: string option, ?ibanLast4: string option, ?preferredLanguage: string option, ?statementDescriptor: string option) =
            {
                SourceTypeSofort.BankCode = bankCode |> Option.flatten
                SourceTypeSofort.BankName = bankName |> Option.flatten
                SourceTypeSofort.Bic = bic |> Option.flatten
                SourceTypeSofort.Country = country |> Option.flatten
                SourceTypeSofort.IbanLast4 = ibanLast4 |> Option.flatten
                SourceTypeSofort.PreferredLanguage = preferredLanguage |> Option.flatten
                SourceTypeSofort.StatementDescriptor = statementDescriptor |> Option.flatten
            }

    and SourceTypeThreeDSecure = {
        [<JsonField(Name="address_line1_check")>]AddressLine1Check: string option
        AddressZipCheck: string option
        Authenticated: bool option
        Brand: string option
        Card: string option
        Country: string option
        Customer: string option
        CvcCheck: string option
        Description: string option
        [<JsonField(Name="dynamic_last4")>]DynamicLast4: string option
        ExpMonth: int option
        ExpYear: int option
        Fingerprint: string option
        Funding: string option
        Iin: string option
        Issuer: string option
        [<JsonField(Name="last4")>]Last4: string option
        Name: string option
        ThreeDSecure: string option
        TokenizationMethod: string option
    }
    with

        static member Create (?addressLine1Check: string option, ?addressZipCheck: string option, ?authenticated: bool option, ?brand: string option, ?card: string option, ?country: string option, ?customer: string option, ?cvcCheck: string option, ?description: string, ?dynamicLast4: string option, ?expMonth: int option, ?expYear: int option, ?fingerprint: string, ?funding: string option, ?iin: string, ?issuer: string, ?last4: string option, ?name: string option, ?threeDSecure: string, ?tokenizationMethod: string option) =
            {
                SourceTypeThreeDSecure.AddressLine1Check = addressLine1Check |> Option.flatten
                SourceTypeThreeDSecure.AddressZipCheck = addressZipCheck |> Option.flatten
                SourceTypeThreeDSecure.Authenticated = authenticated |> Option.flatten
                SourceTypeThreeDSecure.Brand = brand |> Option.flatten
                SourceTypeThreeDSecure.Card = card |> Option.flatten
                SourceTypeThreeDSecure.Country = country |> Option.flatten
                SourceTypeThreeDSecure.Customer = customer |> Option.flatten
                SourceTypeThreeDSecure.CvcCheck = cvcCheck |> Option.flatten
                SourceTypeThreeDSecure.Description = description
                SourceTypeThreeDSecure.DynamicLast4 = dynamicLast4 |> Option.flatten
                SourceTypeThreeDSecure.ExpMonth = expMonth |> Option.flatten
                SourceTypeThreeDSecure.ExpYear = expYear |> Option.flatten
                SourceTypeThreeDSecure.Fingerprint = fingerprint
                SourceTypeThreeDSecure.Funding = funding |> Option.flatten
                SourceTypeThreeDSecure.Iin = iin
                SourceTypeThreeDSecure.Issuer = issuer
                SourceTypeThreeDSecure.Last4 = last4 |> Option.flatten
                SourceTypeThreeDSecure.Name = name |> Option.flatten
                SourceTypeThreeDSecure.ThreeDSecure = threeDSecure
                SourceTypeThreeDSecure.TokenizationMethod = tokenizationMethod |> Option.flatten
            }

    and SourceTypeWechat = {
        PrepayId: string option
        QrCodeUrl: string option
        StatementDescriptor: string option
    }
    with

        static member Create (?prepayId: string, ?qrCodeUrl: string option, ?statementDescriptor: string) =
            {
                SourceTypeWechat.PrepayId = prepayId
                SourceTypeWechat.QrCodeUrl = qrCodeUrl |> Option.flatten
                SourceTypeWechat.StatementDescriptor = statementDescriptor
            }

    and StatusTransitions = {
        ///The time that the order was canceled.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Canceled: DateTime option
        ///The time that the order was fulfilled.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Fulfiled: DateTime option
        ///The time that the order was paid.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Paid: DateTime option
        ///The time that the order was returned.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Returned: DateTime option
    }
    with

        static member Create (canceled: DateTime option, fulfiled: DateTime option, paid: DateTime option, returned: DateTime option) =
            {
                StatusTransitions.Canceled = canceled //required
                StatusTransitions.Fulfiled = fulfiled //required
                StatusTransitions.Paid = paid //required
                StatusTransitions.Returned = returned //required
            }

    ///Subscriptions allow you to charge a customer on a recurring basis.
    ///Related guide: [Creating Subscriptions](https://stripe.com/docs/billing/subscriptions/creating).
    and Subscription = {
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice subtotal that will be transferred to the application owner's Stripe account.
        ApplicationFeePercent: decimal option
        ///Determines the date of the first full invoice, and, for plans with `month` or `year` intervals, the day of the month for subsequent invoices.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]BillingCycleAnchor: DateTime
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period
        BillingThresholds: SubscriptionBillingThresholds option
        ///A date in the future at which the subscription will automatically get canceled
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]CancelAt: DateTime option
        ///If the subscription has been canceled with the `at_period_end` flag set to `true`, `cancel_at_period_end` on the subscription will be true. You can use this attribute to determine whether a subscription that has a status of active is scheduled to be canceled at the end of the current period.
        CancelAtPeriodEnd: bool
        ///If the subscription has been canceled, the date of that cancellation. If the subscription was canceled with `cancel_at_period_end`, `canceled_at` will reflect the time of the most recent update request, not the end of the subscription period when the subscription is automatically moved to a canceled state.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]CanceledAt: DateTime option
        ///Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay this subscription at the end of the cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions.
        CollectionMethod: SubscriptionCollectionMethod option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///End of the current period that the subscription has been invoiced for. At the end of this period, a new invoice will be created.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]CurrentPeriodEnd: DateTime
        ///Start of the current period that the subscription has been invoiced for.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]CurrentPeriodStart: DateTime
        ///ID of the customer who owns the subscription.
        [<JsonField(Transform=typeof<AnyOfTransform<SubscriptionCustomer'AnyOf>>)>]Customer: SubscriptionCustomer'AnyOf
        ///Number of days a customer has to pay invoices generated by this subscription. This value will be `null` for subscriptions where `collection_method=charge_automatically`.
        DaysUntilDue: int option
        ///ID of the default payment method for the subscription. It must belong to the customer associated with the subscription. This takes precedence over `default_source`. If neither are set, invoices will use the customer's [invoice_settings.default_payment_method](https://stripe.com/docs/api/customers/object#customer_object-invoice_settings-default_payment_method) or [default_source](https://stripe.com/docs/api/customers/object#customer_object-default_source).
        [<JsonField(Transform=typeof<AnyOfTransform<SubscriptionDefaultPaymentMethod'AnyOf>>)>]DefaultPaymentMethod: SubscriptionDefaultPaymentMethod'AnyOf option
        ///ID of the default payment source for the subscription. It must belong to the customer associated with the subscription and be in a chargeable state. If `default_payment_method` is also set, `default_payment_method` will take precedence. If neither are set, invoices will use the customer's [invoice_settings.default_payment_method](https://stripe.com/docs/api/customers/object#customer_object-invoice_settings-default_payment_method) or [default_source](https://stripe.com/docs/api/customers/object#customer_object-default_source).
        [<JsonField(Transform=typeof<AnyOfTransform<SubscriptionDefaultSource'AnyOf>>)>]DefaultSource: SubscriptionDefaultSource'AnyOf option
        ///The tax rates that will apply to any subscription item that does not have `tax_rates` set. Invoices created will have their `default_tax_rates` populated from the subscription.
        DefaultTaxRates: TaxRate list option
        ///Describes the current discount applied to this subscription, if there is one. When billing, a discount applied to a subscription overrides a discount applied on a customer-wide basis.
        Discount: Discount option
        ///If the subscription has ended, the date the subscription ended.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]EndedAt: DateTime option
        ///Unique identifier for the object.
        Id: string
        ///List of subscription items, each with an attached price.
        Items: SubscriptionItems
        ///The most recent invoice this subscription has generated.
        [<JsonField(Transform=typeof<AnyOfTransform<SubscriptionLatestInvoice'AnyOf>>)>]LatestInvoice: SubscriptionLatestInvoice'AnyOf option
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        ///Specifies the approximate timestamp on which any pending invoice items will be billed according to the schedule provided at `pending_invoice_item_interval`.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]NextPendingInvoiceItemInvoice: DateTime option
        ///If specified, payment collection for this subscription will be paused.
        PauseCollection: SubscriptionsResourcePauseCollection option
        ///Specifies an interval for how often to bill for any pending invoice items. It is analogous to calling [Create an invoice](https://stripe.com/docs/api#create_invoice) for the given subscription at the specified interval.
        PendingInvoiceItemInterval: SubscriptionPendingInvoiceItemInterval option
        ///You can use this [SetupIntent](https://stripe.com/docs/api/setup_intents) to collect user authentication when creating a subscription without immediate payment or updating a subscription's payment method, allowing you to optimize for off-session payments. Learn more in the [SCA Migration Guide](https://stripe.com/docs/billing/migration/strong-customer-authentication#scenario-2).
        [<JsonField(Transform=typeof<AnyOfTransform<SubscriptionPendingSetupIntent'AnyOf>>)>]PendingSetupIntent: SubscriptionPendingSetupIntent'AnyOf option
        ///If specified, [pending updates](https://stripe.com/docs/billing/subscriptions/pending-updates) that will be applied to the subscription once the `latest_invoice` has been paid.
        PendingUpdate: SubscriptionsResourcePendingUpdate option
        ///The schedule attached to the subscription
        [<JsonField(Transform=typeof<AnyOfTransform<SubscriptionSchedule'AnyOf>>)>]Schedule: SubscriptionSchedule'AnyOf option
        ///Date when the subscription was first created. The date might differ from the `created` date due to backdating.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]StartDate: DateTime
        ///Possible values are `incomplete`, `incomplete_expired`, `trialing`, `active`, `past_due`, `canceled`, or `unpaid`. 
    ///For `collection_method=charge_automatically` a subscription moves into `incomplete` if the initial payment attempt fails. A subscription in this state can only have metadata and default_source updated. Once the first invoice is paid, the subscription moves into an `active` state. If the first invoice is not paid within 23 hours, the subscription transitions to `incomplete_expired`. This is a terminal state, the open invoice will be voided and no further invoices will be generated. 
    ///A subscription that is currently in a trial period is `trialing` and moves to `active` when the trial period is over. 
    ///If subscription `collection_method=charge_automatically` it becomes `past_due` when payment to renew it fails and `canceled` or `unpaid` (depending on your subscriptions settings) when Stripe has exhausted all payment retry attempts. 
    ///If subscription `collection_method=send_invoice` it becomes `past_due` when its invoice is not paid by the due date, and `canceled` or `unpaid` if it is still not paid by an additional deadline after that. Note that when a subscription has a status of `unpaid`, no subsequent invoices will be attempted (invoices will be created, but then immediately automatically closed). After receiving updated payment information from a customer, you may choose to reopen and pay their closed invoices.
        Status: SubscriptionStatus
        ///The account (if any) the subscription's payments will be attributed to for tax reporting, and where funds from each payment will be transferred to for each of the subscription's invoices.
        TransferData: SubscriptionTransferData option
        ///If the subscription has a trial, the end of that trial.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]TrialEnd: DateTime option
        ///If the subscription has a trial, the beginning of that trial.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]TrialStart: DateTime option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "subscription"

        static member Create (applicationFeePercent: decimal option, billingCycleAnchor: DateTime, billingThresholds: SubscriptionBillingThresholds option, cancelAt: DateTime option, cancelAtPeriodEnd: bool, canceledAt: DateTime option, collectionMethod: SubscriptionCollectionMethod option, created: DateTime, currentPeriodEnd: DateTime, currentPeriodStart: DateTime, customer: SubscriptionCustomer'AnyOf, daysUntilDue: int option, defaultPaymentMethod: SubscriptionDefaultPaymentMethod'AnyOf option, defaultSource: SubscriptionDefaultSource'AnyOf option, discount: Discount option, endedAt: DateTime option, id: string, items: SubscriptionItems, latestInvoice: SubscriptionLatestInvoice'AnyOf option, livemode: bool, metadata: Map<string, string>, nextPendingInvoiceItemInvoice: DateTime option, pauseCollection: SubscriptionsResourcePauseCollection option, pendingInvoiceItemInterval: SubscriptionPendingInvoiceItemInterval option, pendingSetupIntent: SubscriptionPendingSetupIntent'AnyOf option, pendingUpdate: SubscriptionsResourcePendingUpdate option, schedule: SubscriptionSchedule'AnyOf option, startDate: DateTime, status: SubscriptionStatus, transferData: SubscriptionTransferData option, trialEnd: DateTime option, trialStart: DateTime option, ?defaultTaxRates: TaxRate list option) =
            {
                Subscription.ApplicationFeePercent = applicationFeePercent //required
                Subscription.BillingCycleAnchor = billingCycleAnchor //required
                Subscription.BillingThresholds = billingThresholds //required
                Subscription.CancelAt = cancelAt //required
                Subscription.CancelAtPeriodEnd = cancelAtPeriodEnd //required
                Subscription.CanceledAt = canceledAt //required
                Subscription.CollectionMethod = collectionMethod //required
                Subscription.Created = created //required
                Subscription.CurrentPeriodEnd = currentPeriodEnd //required
                Subscription.CurrentPeriodStart = currentPeriodStart //required
                Subscription.Customer = customer //required
                Subscription.DaysUntilDue = daysUntilDue //required
                Subscription.DefaultPaymentMethod = defaultPaymentMethod //required
                Subscription.DefaultSource = defaultSource //required
                Subscription.Discount = discount //required
                Subscription.EndedAt = endedAt //required
                Subscription.Id = id //required
                Subscription.Items = items //required
                Subscription.LatestInvoice = latestInvoice //required
                Subscription.Livemode = livemode //required
                Subscription.Metadata = metadata //required
                Subscription.NextPendingInvoiceItemInvoice = nextPendingInvoiceItemInvoice //required
                Subscription.PauseCollection = pauseCollection //required
                Subscription.PendingInvoiceItemInterval = pendingInvoiceItemInterval //required
                Subscription.PendingSetupIntent = pendingSetupIntent //required
                Subscription.PendingUpdate = pendingUpdate //required
                Subscription.Schedule = schedule //required
                Subscription.StartDate = startDate //required
                Subscription.Status = status //required
                Subscription.TransferData = transferData //required
                Subscription.TrialEnd = trialEnd //required
                Subscription.TrialStart = trialStart //required
                Subscription.DefaultTaxRates = defaultTaxRates |> Option.flatten
            }

    and SubscriptionCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    and SubscriptionCustomer'AnyOf =
        | String of string
        | Customer of Customer
        | DeletedCustomer of DeletedCustomer

    and SubscriptionDefaultPaymentMethod'AnyOf =
        | String of string
        | PaymentMethod of PaymentMethod

    and SubscriptionDefaultSource'AnyOf =
        | String of string
        | PaymentSource of PaymentSource

    and SubscriptionLatestInvoice'AnyOf =
        | String of string
        | Invoice of Invoice

    and SubscriptionPendingSetupIntent'AnyOf =
        | String of string
        | SetupIntent of SetupIntent

    and SubscriptionSchedule'AnyOf =
        | String of string
        | SubscriptionSchedule of SubscriptionSchedule

    and SubscriptionStatus =
        | Active
        | Canceled
        | Incomplete
        | IncompleteExpired
        | PastDue
        | Trialing
        | Unpaid

    ///List of subscription items, each with an attached price.
    and SubscriptionItems = {
        ///Details about each object.
        Data: SubscriptionItem list
        ///True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        ///The URL where this list can be accessed.
        Url: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
        member _.Object = "list"

        static member Create (data: SubscriptionItem list, hasMore: bool, url: string) =
            {
                SubscriptionItems.Data = data //required
                SubscriptionItems.HasMore = hasMore //required
                SubscriptionItems.Url = url //required
            }

    and SubscriptionBillingThresholds = {
        ///Monetary threshold that triggers the subscription to create an invoice
        AmountGte: int option
        ///Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged. This value may not be `true` if the subscription contains items with plans that have `aggregate_usage=last_ever`.
        ResetBillingCycleAnchor: bool option
    }
    with

        static member Create (amountGte: int option, resetBillingCycleAnchor: bool option) =
            {
                SubscriptionBillingThresholds.AmountGte = amountGte //required
                SubscriptionBillingThresholds.ResetBillingCycleAnchor = resetBillingCycleAnchor //required
            }

    ///Subscription items allow you to create customer subscriptions with more than
    ///one plan, making it easy to represent complex billing relationships.
    and SubscriptionItem = {
        ///Define thresholds at which an invoice will be sent, and the related subscription advanced to a new billing period
        BillingThresholds: SubscriptionItemBillingThresholds option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: int
        ///Unique identifier for the object.
        Id: string
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        Plan: Plan
        Price: Price
        ///The [quantity](https://stripe.com/docs/subscriptions/quantities) of the plan to which the customer should be subscribed.
        Quantity: int option
        ///The `subscription` this `subscription_item` belongs to.
        Subscription: string
        ///The tax rates which apply to this `subscription_item`. When set, the `default_tax_rates` on the subscription do not apply to this `subscription_item`.
        TaxRates: TaxRate list option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "subscription_item"

        static member Create (billingThresholds: SubscriptionItemBillingThresholds option, created: int, id: string, metadata: Map<string, string>, plan: Plan, price: Price, subscription: string, taxRates: TaxRate list option, ?quantity: int) =
            {
                SubscriptionItem.BillingThresholds = billingThresholds //required
                SubscriptionItem.Created = created //required
                SubscriptionItem.Id = id //required
                SubscriptionItem.Metadata = metadata //required
                SubscriptionItem.Plan = plan //required
                SubscriptionItem.Price = price //required
                SubscriptionItem.Subscription = subscription //required
                SubscriptionItem.TaxRates = taxRates //required
                SubscriptionItem.Quantity = quantity
            }

    and SubscriptionItemBillingThresholds = {
        ///Usage threshold that triggers the subscription to create an invoice
        UsageGte: int option
    }
    with

        static member Create (usageGte: int option) =
            {
                SubscriptionItemBillingThresholds.UsageGte = usageGte //required
            }

    and SubscriptionPendingInvoiceItemInterval = {
        ///Specifies invoicing frequency. Either `day`, `week`, `month` or `year`.
        Interval: SubscriptionPendingInvoiceItemIntervalInterval
        ///The number of intervals between invoices. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        IntervalCount: int
    }
    with

        static member Create (interval: SubscriptionPendingInvoiceItemIntervalInterval, intervalCount: int) =
            {
                SubscriptionPendingInvoiceItemInterval.Interval = interval //required
                SubscriptionPendingInvoiceItemInterval.IntervalCount = intervalCount //required
            }

    and SubscriptionPendingInvoiceItemIntervalInterval =
        | Day
        | Month
        | Week
        | Year

    ///A subscription schedule allows you to create and manage the lifecycle of a subscription by predefining expected changes.
    ///Related guide: [Subscription Schedules](https://stripe.com/docs/billing/subscriptions/subscription-schedules).
    and SubscriptionSchedule = {
        ///Time at which the subscription schedule was canceled. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]CanceledAt: DateTime option
        ///Time at which the subscription schedule was completed. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]CompletedAt: DateTime option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Object representing the start and end dates for the current phase of the subscription schedule, if it is `active`.
        CurrentPhase: SubscriptionScheduleCurrentPhase option
        ///ID of the customer who owns the subscription schedule.
        [<JsonField(Transform=typeof<AnyOfTransform<SubscriptionScheduleCustomer'AnyOf>>)>]Customer: SubscriptionScheduleCustomer'AnyOf
        DefaultSettings: SubscriptionSchedulesResourceDefaultSettings
        ///Behavior of the subscription schedule and underlying subscription when it ends. Possible values are `release` and `cancel`.
        EndBehavior: SubscriptionScheduleEndBehavior
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        ///Configuration for the subscription schedule's phases.
        Phases: SubscriptionSchedulePhaseConfiguration list
        ///Time at which the subscription schedule was released. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]ReleasedAt: DateTime option
        ///ID of the subscription once managed by the subscription schedule (if it is released).
        ReleasedSubscription: string option
        ///The present status of the subscription schedule. Possible values are `not_started`, `active`, `completed`, `released`, and `canceled`. You can read more about the different states in our [behavior guide](https://stripe.com/docs/billing/subscriptions/subscription-schedules).
        Status: SubscriptionScheduleStatus
        ///ID of the subscription managed by the subscription schedule.
        [<JsonField(Transform=typeof<AnyOfTransform<SubscriptionScheduleSubscription'AnyOf>>)>]Subscription: SubscriptionScheduleSubscription'AnyOf option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "subscription_schedule"

        static member Create (canceledAt: DateTime option, completedAt: DateTime option, created: DateTime, currentPhase: SubscriptionScheduleCurrentPhase option, customer: SubscriptionScheduleCustomer'AnyOf, defaultSettings: SubscriptionSchedulesResourceDefaultSettings, endBehavior: SubscriptionScheduleEndBehavior, id: string, livemode: bool, metadata: Map<string, string> option, phases: SubscriptionSchedulePhaseConfiguration list, releasedAt: DateTime option, releasedSubscription: string option, status: SubscriptionScheduleStatus, subscription: SubscriptionScheduleSubscription'AnyOf option) =
            {
                SubscriptionSchedule.CanceledAt = canceledAt //required
                SubscriptionSchedule.CompletedAt = completedAt //required
                SubscriptionSchedule.Created = created //required
                SubscriptionSchedule.CurrentPhase = currentPhase //required
                SubscriptionSchedule.Customer = customer //required
                SubscriptionSchedule.DefaultSettings = defaultSettings //required
                SubscriptionSchedule.EndBehavior = endBehavior //required
                SubscriptionSchedule.Id = id //required
                SubscriptionSchedule.Livemode = livemode //required
                SubscriptionSchedule.Metadata = metadata //required
                SubscriptionSchedule.Phases = phases //required
                SubscriptionSchedule.ReleasedAt = releasedAt //required
                SubscriptionSchedule.ReleasedSubscription = releasedSubscription //required
                SubscriptionSchedule.Status = status //required
                SubscriptionSchedule.Subscription = subscription //required
            }

    and SubscriptionScheduleCustomer'AnyOf =
        | String of string
        | Customer of Customer
        | DeletedCustomer of DeletedCustomer

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

    and SubscriptionScheduleSubscription'AnyOf =
        | String of string
        | Subscription of Subscription

    ///An Add Invoice Item describes the prices and quantities that will be added as pending invoice items when entering a phase.
    and SubscriptionScheduleAddInvoiceItem = {
        ///ID of the price used to generate the invoice item.
        [<JsonField(Transform=typeof<AnyOfTransform<SubscriptionScheduleAddInvoiceItemPrice'AnyOf>>)>]Price: SubscriptionScheduleAddInvoiceItemPrice'AnyOf
        ///The quantity of the invoice item.
        Quantity: int option
        ///The tax rates which apply to the item. When set, the `default_tax_rates` do not apply to this item.
        TaxRates: TaxRate list option
    }
    with

        static member Create (price: SubscriptionScheduleAddInvoiceItemPrice'AnyOf, quantity: int option, ?taxRates: TaxRate list option) =
            {
                SubscriptionScheduleAddInvoiceItem.Price = price //required
                SubscriptionScheduleAddInvoiceItem.Quantity = quantity //required
                SubscriptionScheduleAddInvoiceItem.TaxRates = taxRates |> Option.flatten
            }

    and SubscriptionScheduleAddInvoiceItemPrice'AnyOf =
        | String of string
        | Price of Price
        | DeletedPrice of DeletedPrice

    ///A phase item describes the price and quantity of a phase.
    and SubscriptionScheduleConfigurationItem = {
        ///Define thresholds at which an invoice will be sent, and the related subscription advanced to a new billing period
        BillingThresholds: SubscriptionItemBillingThresholds option
        ///ID of the plan to which the customer should be subscribed.
        [<JsonField(Transform=typeof<AnyOfTransform<SubscriptionScheduleConfigurationItemPlan'AnyOf>>)>]Plan: SubscriptionScheduleConfigurationItemPlan'AnyOf
        ///ID of the price to which the customer should be subscribed.
        [<JsonField(Transform=typeof<AnyOfTransform<SubscriptionScheduleConfigurationItemPrice'AnyOf>>)>]Price: SubscriptionScheduleConfigurationItemPrice'AnyOf
        ///Quantity of the plan to which the customer should be subscribed.
        Quantity: int option
        ///The tax rates which apply to this `phase_item`. When set, the `default_tax_rates` on the phase do not apply to this `phase_item`.
        TaxRates: TaxRate list option
    }
    with

        static member Create (billingThresholds: SubscriptionItemBillingThresholds option, plan: SubscriptionScheduleConfigurationItemPlan'AnyOf, price: SubscriptionScheduleConfigurationItemPrice'AnyOf, ?quantity: int, ?taxRates: TaxRate list option) =
            {
                SubscriptionScheduleConfigurationItem.BillingThresholds = billingThresholds //required
                SubscriptionScheduleConfigurationItem.Plan = plan //required
                SubscriptionScheduleConfigurationItem.Price = price //required
                SubscriptionScheduleConfigurationItem.Quantity = quantity
                SubscriptionScheduleConfigurationItem.TaxRates = taxRates |> Option.flatten
            }

    and SubscriptionScheduleConfigurationItemPlan'AnyOf =
        | String of string
        | Plan of Plan
        | DeletedPlan of DeletedPlan

    and SubscriptionScheduleConfigurationItemPrice'AnyOf =
        | String of string
        | Price of Price
        | DeletedPrice of DeletedPrice

    and SubscriptionScheduleCurrentPhase = {
        ///The end of this phase of the subscription schedule.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]EndDate: DateTime
        ///The start of this phase of the subscription schedule.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]StartDate: DateTime
    }
    with

        static member Create (endDate: DateTime, startDate: DateTime) =
            {
                SubscriptionScheduleCurrentPhase.EndDate = endDate //required
                SubscriptionScheduleCurrentPhase.StartDate = startDate //required
            }

    ///A phase describes the plans, coupon, and trialing status of a subscription for a predefined time period.
    and SubscriptionSchedulePhaseConfiguration = {
        ///A list of prices and quantities that will generate invoice items appended to the first invoice for this phase.
        AddInvoiceItems: SubscriptionScheduleAddInvoiceItem list
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice subtotal that will be transferred to the application owner's Stripe account during this phase of the schedule.
        ApplicationFeePercent: decimal option
        ///Possible values are `phase_start` or `automatic`. If `phase_start` then billing cycle anchor of the subscription is set to the start of the phase when entering the phase. If `automatic` then the billing cycle anchor is automatically modified as needed when entering the phase. For more information, see the billing cycle [documentation](https://stripe.com/docs/billing/subscriptions/billing-cycle).
        BillingCycleAnchor: SubscriptionSchedulePhaseConfigurationBillingCycleAnchor option
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period
        BillingThresholds: SubscriptionBillingThresholds option
        ///Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay the underlying subscription at the end of each billing cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions.
        CollectionMethod: SubscriptionSchedulePhaseConfigurationCollectionMethod option
        ///ID of the coupon to use during this phase of the subscription schedule.
        [<JsonField(Transform=typeof<AnyOfTransform<SubscriptionSchedulePhaseConfigurationCoupon'AnyOf>>)>]Coupon: SubscriptionSchedulePhaseConfigurationCoupon'AnyOf option
        ///ID of the default payment method for the subscription schedule. It must belong to the customer associated with the subscription schedule. If not set, invoices will use the default payment method in the customer's invoice settings.
        [<JsonField(Transform=typeof<AnyOfTransform<SubscriptionSchedulePhaseConfigurationDefaultPaymentMethod'AnyOf>>)>]DefaultPaymentMethod: SubscriptionSchedulePhaseConfigurationDefaultPaymentMethod'AnyOf option
        ///The default tax rates to apply to the subscription during this phase of the subscription schedule.
        DefaultTaxRates: TaxRate list option
        ///The end of this phase of the subscription schedule.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]EndDate: DateTime
        ///The subscription schedule's default invoice settings.
        InvoiceSettings: InvoiceSettingSubscriptionScheduleSetting option
        ///Subscription items to configure the subscription to during this phase of the subscription schedule.
        Items: SubscriptionScheduleConfigurationItem list
        ///If the subscription schedule will prorate when transitioning to this phase. Possible values are `create_prorations` and `none`.
        ProrationBehavior: SubscriptionSchedulePhaseConfigurationProrationBehavior
        ///The start of this phase of the subscription schedule.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]StartDate: DateTime
        ///The account (if any) the associated subscription's payments will be attributed to for tax reporting, and where funds from each payment will be transferred to for each of the subscription's invoices.
        TransferData: SubscriptionTransferData option
        ///When the trial ends within the phase.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]TrialEnd: DateTime option
    }
    with

        static member Create (addInvoiceItems: SubscriptionScheduleAddInvoiceItem list, applicationFeePercent: decimal option, billingCycleAnchor: SubscriptionSchedulePhaseConfigurationBillingCycleAnchor option, billingThresholds: SubscriptionBillingThresholds option, collectionMethod: SubscriptionSchedulePhaseConfigurationCollectionMethod option, coupon: SubscriptionSchedulePhaseConfigurationCoupon'AnyOf option, defaultPaymentMethod: SubscriptionSchedulePhaseConfigurationDefaultPaymentMethod'AnyOf option, endDate: DateTime, invoiceSettings: InvoiceSettingSubscriptionScheduleSetting option, items: SubscriptionScheduleConfigurationItem list, prorationBehavior: SubscriptionSchedulePhaseConfigurationProrationBehavior, startDate: DateTime, transferData: SubscriptionTransferData option, trialEnd: DateTime option, ?defaultTaxRates: TaxRate list option) =
            {
                SubscriptionSchedulePhaseConfiguration.AddInvoiceItems = addInvoiceItems //required
                SubscriptionSchedulePhaseConfiguration.ApplicationFeePercent = applicationFeePercent //required
                SubscriptionSchedulePhaseConfiguration.BillingCycleAnchor = billingCycleAnchor //required
                SubscriptionSchedulePhaseConfiguration.BillingThresholds = billingThresholds //required
                SubscriptionSchedulePhaseConfiguration.CollectionMethod = collectionMethod //required
                SubscriptionSchedulePhaseConfiguration.Coupon = coupon //required
                SubscriptionSchedulePhaseConfiguration.DefaultPaymentMethod = defaultPaymentMethod //required
                SubscriptionSchedulePhaseConfiguration.EndDate = endDate //required
                SubscriptionSchedulePhaseConfiguration.InvoiceSettings = invoiceSettings //required
                SubscriptionSchedulePhaseConfiguration.Items = items //required
                SubscriptionSchedulePhaseConfiguration.ProrationBehavior = prorationBehavior //required
                SubscriptionSchedulePhaseConfiguration.StartDate = startDate //required
                SubscriptionSchedulePhaseConfiguration.TransferData = transferData //required
                SubscriptionSchedulePhaseConfiguration.TrialEnd = trialEnd //required
                SubscriptionSchedulePhaseConfiguration.DefaultTaxRates = defaultTaxRates |> Option.flatten
            }

    and SubscriptionSchedulePhaseConfigurationBillingCycleAnchor =
        | Automatic
        | PhaseStart

    and SubscriptionSchedulePhaseConfigurationCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    and SubscriptionSchedulePhaseConfigurationCoupon'AnyOf =
        | String of string
        | Coupon of Coupon
        | DeletedCoupon of DeletedCoupon

    and SubscriptionSchedulePhaseConfigurationDefaultPaymentMethod'AnyOf =
        | String of string
        | PaymentMethod of PaymentMethod

    and SubscriptionSchedulePhaseConfigurationProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | None'

    and SubscriptionSchedulesResourceDefaultSettings = {
        ///Possible values are `phase_start` or `automatic`. If `phase_start` then billing cycle anchor of the subscription is set to the start of the phase when entering the phase. If `automatic` then the billing cycle anchor is automatically modified as needed when entering the phase. For more information, see the billing cycle [documentation](https://stripe.com/docs/billing/subscriptions/billing-cycle).
        BillingCycleAnchor: SubscriptionSchedulesResourceDefaultSettingsBillingCycleAnchor
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period
        BillingThresholds: SubscriptionBillingThresholds option
        ///Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay the underlying subscription at the end of each billing cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions.
        CollectionMethod: SubscriptionSchedulesResourceDefaultSettingsCollectionMethod option
        ///ID of the default payment method for the subscription schedule. If not set, invoices will use the default payment method in the customer's invoice settings.
        [<JsonField(Transform=typeof<AnyOfTransform<SubscriptionSchedulesResourceDefaultSettingsDefaultPaymentMethod'AnyOf>>)>]DefaultPaymentMethod: SubscriptionSchedulesResourceDefaultSettingsDefaultPaymentMethod'AnyOf option
        ///The subscription schedule's default invoice settings.
        InvoiceSettings: InvoiceSettingSubscriptionScheduleSetting option
        ///The account (if any) the associated subscription's payments will be attributed to for tax reporting, and where funds from each payment will be transferred to for each of the subscription's invoices.
        TransferData: SubscriptionTransferData option
    }
    with

        static member Create (billingCycleAnchor: SubscriptionSchedulesResourceDefaultSettingsBillingCycleAnchor, billingThresholds: SubscriptionBillingThresholds option, collectionMethod: SubscriptionSchedulesResourceDefaultSettingsCollectionMethod option, defaultPaymentMethod: SubscriptionSchedulesResourceDefaultSettingsDefaultPaymentMethod'AnyOf option, invoiceSettings: InvoiceSettingSubscriptionScheduleSetting option, transferData: SubscriptionTransferData option) =
            {
                SubscriptionSchedulesResourceDefaultSettings.BillingCycleAnchor = billingCycleAnchor //required
                SubscriptionSchedulesResourceDefaultSettings.BillingThresholds = billingThresholds //required
                SubscriptionSchedulesResourceDefaultSettings.CollectionMethod = collectionMethod //required
                SubscriptionSchedulesResourceDefaultSettings.DefaultPaymentMethod = defaultPaymentMethod //required
                SubscriptionSchedulesResourceDefaultSettings.InvoiceSettings = invoiceSettings //required
                SubscriptionSchedulesResourceDefaultSettings.TransferData = transferData //required
            }

    and SubscriptionSchedulesResourceDefaultSettingsBillingCycleAnchor =
        | Automatic
        | PhaseStart

    and SubscriptionSchedulesResourceDefaultSettingsCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    and SubscriptionSchedulesResourceDefaultSettingsDefaultPaymentMethod'AnyOf =
        | String of string
        | PaymentMethod of PaymentMethod

    and SubscriptionTransferData = {
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice subtotal that will be transferred to the destination account. By default, the entire amount is transferred to the destination.
        AmountPercent: decimal option
        ///The account where funds from the payment will be transferred to upon payment success.
        [<JsonField(Transform=typeof<AnyOfTransform<SubscriptionTransferDataDestination'AnyOf>>)>]Destination: SubscriptionTransferDataDestination'AnyOf
    }
    with

        static member Create (amountPercent: decimal option, destination: SubscriptionTransferDataDestination'AnyOf) =
            {
                SubscriptionTransferData.AmountPercent = amountPercent //required
                SubscriptionTransferData.Destination = destination //required
            }

    and SubscriptionTransferDataDestination'AnyOf =
        | String of string
        | Account of Account

    ///The Pause Collection settings determine how we will pause collection for this subscription and for how long the subscription
    ///should be paused.
    and SubscriptionsResourcePauseCollection = {
        ///The payment collection behavior for this subscription while paused. One of `keep_as_draft`, `mark_uncollectible`, or `void`.
        Behavior: SubscriptionsResourcePauseCollectionBehavior
        ///The time after which the subscription will resume collecting payments.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]ResumesAt: DateTime option
    }
    with

        static member Create (behavior: SubscriptionsResourcePauseCollectionBehavior, resumesAt: DateTime option) =
            {
                SubscriptionsResourcePauseCollection.Behavior = behavior //required
                SubscriptionsResourcePauseCollection.ResumesAt = resumesAt //required
            }

    and SubscriptionsResourcePauseCollectionBehavior =
        | KeepAsDraft
        | MarkUncollectible
        | Void

    ///Pending Updates store the changes pending from a previous update that will be applied
    ///to the Subscription upon successful payment.
    and SubscriptionsResourcePendingUpdate = {
        ///If the update is applied, determines the date of the first full invoice, and, for plans with `month` or `year` intervals, the day of the month for subsequent invoices.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]BillingCycleAnchor: DateTime option
        ///The point after which the changes reflected by this update will be discarded and no longer applied.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]ExpiresAt: DateTime
        ///List of subscription items, each with an attached plan, that will be set if the update is applied.
        SubscriptionItems: SubscriptionItem list option
        ///Unix timestamp representing the end of the trial period the customer will get before being charged for the first time, if the update is applied.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]TrialEnd: DateTime option
        ///Indicates if a plan's `trial_period_days` should be applied to the subscription. Setting `trial_end` per subscription is preferred, and this defaults to `false`. Setting this flag to `true` together with `trial_end` is not allowed.
        TrialFromPlan: bool option
    }
    with

        static member Create (billingCycleAnchor: DateTime option, expiresAt: DateTime, subscriptionItems: SubscriptionItem list option, trialEnd: DateTime option, trialFromPlan: bool option) =
            {
                SubscriptionsResourcePendingUpdate.BillingCycleAnchor = billingCycleAnchor //required
                SubscriptionsResourcePendingUpdate.ExpiresAt = expiresAt //required
                SubscriptionsResourcePendingUpdate.SubscriptionItems = subscriptionItems //required
                SubscriptionsResourcePendingUpdate.TrialEnd = trialEnd //required
                SubscriptionsResourcePendingUpdate.TrialFromPlan = trialFromPlan //required
            }

    and TaxDeductedAtSource = {
        ///Unique identifier for the object.
        Id: string
        ///The end of the invoicing period. This TDS applies to Stripe fees collected during this invoicing period.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]PeriodEnd: DateTime
        ///The start of the invoicing period. This TDS applies to Stripe fees collected during this invoicing period.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]PeriodStart: DateTime
        ///The TAN that was supplied to Stripe when TDS was assessed
        TaxDeductionAccountNumber: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "tax_deducted_at_source"

        static member Create (id: string, periodEnd: DateTime, periodStart: DateTime, taxDeductionAccountNumber: string) =
            {
                TaxDeductedAtSource.Id = id //required
                TaxDeductedAtSource.PeriodEnd = periodEnd //required
                TaxDeductedAtSource.PeriodStart = periodStart //required
                TaxDeductedAtSource.TaxDeductionAccountNumber = taxDeductionAccountNumber //required
            }

    ///You can add one or multiple tax IDs to a [customer](https://stripe.com/docs/api/customers).
    ///A customer's tax IDs are displayed on invoices and credit notes issued for the customer.
    ///Related guide: [Customer Tax Identification Numbers](https://stripe.com/docs/billing/taxes/tax-ids).
    and TaxId = {
        ///Two-letter ISO code representing the country of the tax ID.
        Country: string option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///ID of the customer.
        [<JsonField(Transform=typeof<AnyOfTransform<TaxIdCustomer'AnyOf>>)>]Customer: TaxIdCustomer'AnyOf option
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Type of the tax ID, one of `ae_trn`, `au_abn`, `br_cnpj`, `br_cpf`, `ca_bn`, `ca_qst`, `ch_vat`, `cl_tin`, `es_cif`, `eu_vat`, `hk_br`, `id_npwp`, `in_gst`, `jp_cn`, `jp_rn`, `kr_brn`, `li_uid`, `mx_rfc`, `my_frp`, `my_itn`, `my_sst`, `no_vat`, `nz_gst`, `ru_inn`, `ru_kpp`, `sa_vat`, `sg_gst`, `sg_uen`, `th_vat`, `tw_vat`, `us_ein`, or `za_vat`. Note that some legacy tax IDs have type `unknown`
        Type: TaxIdType
        ///Value of the tax ID.
        Value: string
        ///Tax ID verification information.
        Verification: TaxIdVerification option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "tax_id"

        static member Create (country: string option, created: DateTime, customer: TaxIdCustomer'AnyOf option, id: string, livemode: bool, ``type``: TaxIdType, value: string, verification: TaxIdVerification option) =
            {
                TaxId.Country = country //required
                TaxId.Created = created //required
                TaxId.Customer = customer //required
                TaxId.Id = id //required
                TaxId.Livemode = livemode //required
                TaxId.Type = ``type`` //required
                TaxId.Value = value //required
                TaxId.Verification = verification //required
            }

    and TaxIdCustomer'AnyOf =
        | String of string
        | Customer of Customer

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

    and TaxIdVerification = {
        ///Verification status, one of `pending`, `verified`, `unverified`, or `unavailable`.
        Status: TaxIdVerificationStatus
        ///Verified address.
        VerifiedAddress: string option
        ///Verified name.
        VerifiedName: string option
    }
    with

        static member Create (status: TaxIdVerificationStatus, verifiedAddress: string option, verifiedName: string option) =
            {
                TaxIdVerification.Status = status //required
                TaxIdVerification.VerifiedAddress = verifiedAddress //required
                TaxIdVerification.VerifiedName = verifiedName //required
            }

    and TaxIdVerificationStatus =
        | Pending
        | Unavailable
        | Unverified
        | Verified

    ///Tax rates can be applied to [invoices](https://stripe.com/docs/billing/invoices/tax-rates), [subscriptions](https://stripe.com/docs/billing/subscriptions/taxes) and [Checkout Sessions](https://stripe.com/docs/payments/checkout/set-up-a-subscription#tax-rates) to collect tax.
    ///Related guide: [Tax Rates](https://stripe.com/docs/billing/taxes/tax-rates).
    and TaxRate = {
        ///Defaults to `true`. When set to `false`, this tax rate cannot be used with new applications or Checkout Sessions, but will still work for subscriptions and invoices that already have it set.
        Active: bool
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///An arbitrary string attached to the tax rate for your internal use only. It will not be visible to your customers.
        Description: string option
        ///The display name of the tax rates as it will appear to your customer on their receipt email, PDF, and the hosted invoice page.
        DisplayName: string
        ///Unique identifier for the object.
        Id: string
        ///This specifies if the tax rate is inclusive or exclusive.
        Inclusive: bool
        ///The jurisdiction for the tax rate. You can use this label field for tax reporting purposes. It also appears on your customer’s invoice.
        Jurisdiction: string option
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        ///This represents the tax rate percent out of 100.
        Percentage: decimal
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "tax_rate"

        static member Create (active: bool, created: DateTime, description: string option, displayName: string, id: string, inclusive: bool, jurisdiction: string option, livemode: bool, metadata: Map<string, string> option, percentage: decimal) =
            {
                TaxRate.Active = active //required
                TaxRate.Created = created //required
                TaxRate.Description = description //required
                TaxRate.DisplayName = displayName //required
                TaxRate.Id = id //required
                TaxRate.Inclusive = inclusive //required
                TaxRate.Jurisdiction = jurisdiction //required
                TaxRate.Livemode = livemode //required
                TaxRate.Metadata = metadata //required
                TaxRate.Percentage = percentage //required
            }

    ///A Connection Token is used by the Stripe Terminal SDK to connect to a reader.
    ///Related guide: [Fleet Management](https://stripe.com/docs/terminal/readers/fleet-management#create).
    and TerminalConnectionToken = {
        ///The id of the location that this connection token is scoped to.
        Location: string option
        ///Your application should pass this token to the Stripe Terminal SDK.
        Secret: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "terminal.connection_token"

        static member Create (secret: string, ?location: string) =
            {
                TerminalConnectionToken.Secret = secret //required
                TerminalConnectionToken.Location = location
            }

    ///A Location represents a grouping of readers.
    ///Related guide: [Fleet Management](https://stripe.com/docs/terminal/readers/fleet-management#create).
    and TerminalLocation = {
        Address: Address
        ///The display name of the location.
        DisplayName: string
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "terminal.location"

        static member Create (address: Address, displayName: string, id: string, livemode: bool, metadata: Map<string, string>) =
            {
                TerminalLocation.Address = address //required
                TerminalLocation.DisplayName = displayName //required
                TerminalLocation.Id = id //required
                TerminalLocation.Livemode = livemode //required
                TerminalLocation.Metadata = metadata //required
            }

    ///A Reader represents a physical device for accepting payment details.
    ///Related guide: [Connecting to a Reader](https://stripe.com/docs/terminal/readers/connecting).
    and TerminalReader = {
        ///The current software version of the reader.
        DeviceSwVersion: string option
        ///Type of reader, one of `bbpos_chipper2x` or `verifone_P400`.
        DeviceType: TerminalReaderDeviceType
        ///Unique identifier for the object.
        Id: string
        ///The local IP address of the reader.
        IpAddress: string option
        ///Custom label given to the reader for easier identification.
        Label: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///The location identifier of the reader.
        Location: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        ///Serial number of the reader.
        SerialNumber: string
        ///The networking status of the reader.
        Status: string option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "terminal.reader"

        static member Create (deviceSwVersion: string option, deviceType: TerminalReaderDeviceType, id: string, ipAddress: string option, label: string, livemode: bool, location: string option, metadata: Map<string, string>, serialNumber: string, status: string option) =
            {
                TerminalReader.DeviceSwVersion = deviceSwVersion //required
                TerminalReader.DeviceType = deviceType //required
                TerminalReader.Id = id //required
                TerminalReader.IpAddress = ipAddress //required
                TerminalReader.Label = label //required
                TerminalReader.Livemode = livemode //required
                TerminalReader.Location = location //required
                TerminalReader.Metadata = metadata //required
                TerminalReader.SerialNumber = serialNumber //required
                TerminalReader.Status = status //required
            }

    and TerminalReaderDeviceType =
        | BbposChipper2x
        | VerifoneP400

    ///Cardholder authentication via 3D Secure is initiated by creating a `3D Secure`
    ///object. Once the object has been created, you can use it to authenticate the
    ///cardholder and create a charge.
    and ThreeDSecure = {
        ///Amount of the charge that you will create when authentication completes.
        Amount: int
        ///True if the cardholder went through the authentication flow and their bank indicated that authentication succeeded.
        Authenticated: bool
        Card: Card
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///If present, this is the URL that you should send the cardholder to for authentication. If you are going to use Stripe.js to display the authentication page in an iframe, you should use the value "_callback".
        RedirectUrl: string option
        ///Possible values are `redirect_pending`, `succeeded`, or `failed`. When the cardholder can be authenticated, the object starts with status `redirect_pending`. When liability will be shifted to the cardholder's bank (either because the cardholder was successfully authenticated, or because the bank has not implemented 3D Secure, the object wlil be in status `succeeded`. `failed` indicates that authentication was attempted unsuccessfully.
        Status: ThreeDSecureStatus
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "three_d_secure"

        static member Create (amount: int, authenticated: bool, card: Card, created: DateTime, currency: string, id: string, livemode: bool, redirectUrl: string option, status: ThreeDSecureStatus) =
            {
                ThreeDSecure.Amount = amount //required
                ThreeDSecure.Authenticated = authenticated //required
                ThreeDSecure.Card = card //required
                ThreeDSecure.Created = created //required
                ThreeDSecure.Currency = currency //required
                ThreeDSecure.Id = id //required
                ThreeDSecure.Livemode = livemode //required
                ThreeDSecure.RedirectUrl = redirectUrl //required
                ThreeDSecure.Status = status //required
            }

    and ThreeDSecureStatus =
        | RedirectPending
        | Succeeded
        | Failed

    and ThreeDSecureDetails = {
        ///For authenticated transactions: how the customer was authenticated by
    ///the issuing bank.
        AuthenticationFlow: ThreeDSecureDetailsAuthenticationFlow option
        ///Indicates the outcome of 3D Secure authentication.
        Result: ThreeDSecureDetailsResult
        ///Additional information about why 3D Secure succeeded or failed based
    ///on the `result`.
        ResultReason: ThreeDSecureDetailsResultReason option
        ///The version of 3D Secure that was used.
        Version: ThreeDSecureDetailsVersion
    }
    with

        static member Create (authenticationFlow: ThreeDSecureDetailsAuthenticationFlow option, result: ThreeDSecureDetailsResult, resultReason: ThreeDSecureDetailsResultReason option, version: ThreeDSecureDetailsVersion) =
            {
                ThreeDSecureDetails.AuthenticationFlow = authenticationFlow //required
                ThreeDSecureDetails.Result = result //required
                ThreeDSecureDetails.ResultReason = resultReason //required
                ThreeDSecureDetails.Version = version //required
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

    and ThreeDSecureUsage = {
        ///Whether 3D Secure is supported on this card.
        Supported: bool
    }
    with

        static member Create (supported: bool) =
            {
                ThreeDSecureUsage.Supported = supported //required
            }

    ///Tokenization is the process Stripe uses to collect sensitive card or bank
    ///account details, or personally identifiable information (PII), directly from
    ///your customers in a secure manner. A token representing this information is
    ///returned to your server to use. You should use our
    ///[recommended payments integrations](https://stripe.com/docs/payments) to perform this process
    ///client-side. This ensures that no sensitive card data touches your server,
    ///and allows your integration to operate in a PCI-compliant way.
    ///If you cannot use client-side tokenization, you can also create tokens using
    ///the API with either your publishable or secret API key. Keep in mind that if
    ///your integration uses this method, you are responsible for any PCI compliance
    ///that may be required, and you must keep your secret API key safe. Unlike with
    ///client-side tokenization, your customer's information is not sent directly to
    ///Stripe, so we cannot determine how it is handled or stored.
    ///Tokens cannot be stored or used more than once. To store card or bank account
    ///information for later use, you can create [Customer](https://stripe.com/docs/api#customers)
    ///objects or [Custom accounts](https://stripe.com/docs/api#external_accounts). Note that
    ///[Radar](https://stripe.com/docs/radar), our integrated solution for automatic fraud protection,
    ///supports only integrations that use client-side tokenization.
    ///Related guide: [Accept a payment](https://stripe.com/docs/payments/accept-a-payment-charges#web-create-token)
    and Token = {
        BankAccount: BankAccount option
        Card: Card option
        ///IP address of the client that generated the token.
        ClientIp: string option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Type of the token: `account`, `bank_account`, `card`, or `pii`.
        Type: TokenType
        ///Whether this token has already been used (tokens can be used only once).
        Used: bool
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "token"

        static member Create (clientIp: string option, created: DateTime, id: string, livemode: bool, ``type``: TokenType, used: bool, ?bankAccount: BankAccount, ?card: Card) =
            {
                Token.ClientIp = clientIp //required
                Token.Created = created //required
                Token.Id = id //required
                Token.Livemode = livemode //required
                Token.Type = ``type`` //required
                Token.Used = used //required
                Token.BankAccount = bankAccount
                Token.Card = card
            }

    and TokenType =
        | Account
        | BankAccount
        | Card
        | Pii

    ///To top up your Stripe balance, you create a top-up object. You can retrieve
    ///individual top-ups, as well as list all top-ups. Top-ups are identified by a
    ///unique, random ID.
    ///Related guide: [Topping Up your Platform Account](https://stripe.com/docs/connect/top-ups).
    and Topup = {
        ///Amount transferred.
        Amount: int
        ///ID of the balance transaction that describes the impact of this top-up on your account balance. May not be specified depending on status of top-up.
        [<JsonField(Transform=typeof<AnyOfTransform<TopupBalanceTransaction'AnyOf>>)>]BalanceTransaction: TopupBalanceTransaction'AnyOf option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        ///Date the funds are expected to arrive in your Stripe account for payouts. This factors in delays like weekends or bank holidays. May not be specified depending on status of top-up.
        ExpectedAvailabilityDate: int option
        ///Error code explaining reason for top-up failure if available (see [the errors section](https://stripe.com/docs/api#errors) for a list of codes).
        FailureCode: string option
        ///Message to user further explaining reason for top-up failure if available.
        FailureMessage: string option
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        Source: Source
        ///Extra information about a top-up. This will appear on your source's bank statement. It must contain at least one letter.
        StatementDescriptor: string option
        ///The status of the top-up is either `canceled`, `failed`, `pending`, `reversed`, or `succeeded`.
        Status: TopupStatus
        ///A string that identifies this top-up as part of a group.
        TransferGroup: string option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "topup"

        static member Create (amount: int, balanceTransaction: TopupBalanceTransaction'AnyOf option, created: DateTime, currency: string, description: string option, expectedAvailabilityDate: int option, failureCode: string option, failureMessage: string option, id: string, livemode: bool, metadata: Map<string, string>, source: Source, statementDescriptor: string option, status: TopupStatus, transferGroup: string option) =
            {
                Topup.Amount = amount //required
                Topup.BalanceTransaction = balanceTransaction //required
                Topup.Created = created //required
                Topup.Currency = currency //required
                Topup.Description = description //required
                Topup.ExpectedAvailabilityDate = expectedAvailabilityDate //required
                Topup.FailureCode = failureCode //required
                Topup.FailureMessage = failureMessage //required
                Topup.Id = id //required
                Topup.Livemode = livemode //required
                Topup.Metadata = metadata //required
                Topup.Source = source //required
                Topup.StatementDescriptor = statementDescriptor //required
                Topup.Status = status //required
                Topup.TransferGroup = transferGroup //required
            }

    and TopupBalanceTransaction'AnyOf =
        | String of string
        | BalanceTransaction of BalanceTransaction

    and TopupStatus =
        | Canceled
        | Failed
        | Pending
        | Reversed
        | Succeeded

    ///A `Transfer` object is created when you move funds between Stripe accounts as
    ///part of Connect.
    ///Before April 6, 2017, transfers also represented movement of funds from a
    ///Stripe account to a card or bank account. This behavior has since been split
    ///out into a [Payout](https://stripe.com/docs/api#payout_object) object, with corresponding payout endpoints. For more
    ///information, read about the
    ///[transfer/payout split](https://stripe.com/docs/transfer-payout-split).
    ///Related guide: [Creating Separate Charges and Transfers](https://stripe.com/docs/connect/charges-transfers).
    and Transfer = {
        ///Amount in %s to be transferred.
        Amount: int
        ///Amount in %s reversed (can be less than the amount attribute on the transfer if a partial reversal was issued).
        AmountReversed: int
        ///Balance transaction that describes the impact of this transfer on your account balance.
        [<JsonField(Transform=typeof<AnyOfTransform<TransferBalanceTransaction'AnyOf>>)>]BalanceTransaction: TransferBalanceTransaction'AnyOf option
        ///Time that this record of the transfer was first created.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        ///ID of the Stripe account the transfer was sent to.
        [<JsonField(Transform=typeof<AnyOfTransform<TransferDestination'AnyOf>>)>]Destination: TransferDestination'AnyOf option
        ///If the destination is a Stripe account, this will be the ID of the payment that the destination account received for the transfer.
        [<JsonField(Transform=typeof<AnyOfTransform<TransferDestinationPayment'AnyOf>>)>]DestinationPayment: TransferDestinationPayment'AnyOf option
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        ///A list of reversals that have been applied to the transfer.
        Reversals: TransferReversals
        ///Whether the transfer has been fully reversed. If the transfer is only partially reversed, this attribute will still be false.
        Reversed: bool
        ///ID of the charge or payment that was used to fund the transfer. If null, the transfer was funded from the available balance.
        [<JsonField(Transform=typeof<AnyOfTransform<TransferSourceTransaction'AnyOf>>)>]SourceTransaction: TransferSourceTransaction'AnyOf option
        ///The source balance this transfer came from. One of `card`, `fpx`, or `bank_account`.
        SourceType: TransferSourceType option
        ///A string that identifies this transaction as part of a group. See the [Connect documentation](https://stripe.com/docs/connect/charges-transfers#transfer-options) for details.
        TransferGroup: string option
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "transfer"

        static member Create (amount: int, amountReversed: int, balanceTransaction: TransferBalanceTransaction'AnyOf option, created: DateTime, currency: string, description: string option, destination: TransferDestination'AnyOf option, id: string, livemode: bool, metadata: Map<string, string>, reversals: TransferReversals, reversed: bool, sourceTransaction: TransferSourceTransaction'AnyOf option, sourceType: TransferSourceType option, transferGroup: string option, ?destinationPayment: TransferDestinationPayment'AnyOf) =
            {
                Transfer.Amount = amount //required
                Transfer.AmountReversed = amountReversed //required
                Transfer.BalanceTransaction = balanceTransaction //required
                Transfer.Created = created //required
                Transfer.Currency = currency //required
                Transfer.Description = description //required
                Transfer.Destination = destination //required
                Transfer.Id = id //required
                Transfer.Livemode = livemode //required
                Transfer.Metadata = metadata //required
                Transfer.Reversals = reversals //required
                Transfer.Reversed = reversed //required
                Transfer.SourceTransaction = sourceTransaction //required
                Transfer.SourceType = sourceType //required
                Transfer.TransferGroup = transferGroup //required
                Transfer.DestinationPayment = destinationPayment
            }

    and TransferBalanceTransaction'AnyOf =
        | String of string
        | BalanceTransaction of BalanceTransaction

    and TransferDestination'AnyOf =
        | String of string
        | Account of Account

    and TransferDestinationPayment'AnyOf =
        | String of string
        | Charge of Charge

    and TransferSourceTransaction'AnyOf =
        | String of string
        | Charge of Charge

    and TransferSourceType =
        | Card
        | Fpx
        | BankAccount

    ///A list of reversals that have been applied to the transfer.
    and TransferReversals = {
        ///Details about each object.
        Data: TransferReversal list
        ///True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        ///The URL where this list can be accessed.
        Url: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
        member _.Object = "list"

        static member Create (data: TransferReversal list, hasMore: bool, url: string) =
            {
                TransferReversals.Data = data //required
                TransferReversals.HasMore = hasMore //required
                TransferReversals.Url = url //required
            }

    and TransferData = {
        ///Amount intended to be collected by this PaymentIntent. A positive integer representing how much to charge in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal) (e.g., 100 cents to charge $1.00 or 100 to charge ¥100, a zero-decimal currency). The minimum amount is $0.50 US or [equivalent in charge currency](https://stripe.com/docs/currencies#minimum-and-maximum-charge-amounts). The amount value supports up to eight digits (e.g., a value of 99999999 for a USD charge of $999,999.99).
        Amount: int option
        ///The account (if any) the payment will be attributed to for tax
    ///reporting, and where funds from the payment will be transferred to upon
    ///payment success.
        [<JsonField(Transform=typeof<AnyOfTransform<TransferDataDestination'AnyOf>>)>]Destination: TransferDataDestination'AnyOf
    }
    with

        static member Create (destination: TransferDataDestination'AnyOf, ?amount: int) =
            {
                TransferData.Destination = destination //required
                TransferData.Amount = amount
            }

    and TransferDataDestination'AnyOf =
        | String of string
        | Account of Account

    ///[Stripe Connect](https://stripe.com/docs/connect) platforms can reverse transfers made to a
    ///connected account, either entirely or partially, and can also specify whether
    ///to refund any related application fees. Transfer reversals add to the
    ///platform's balance and subtract from the destination account's balance.
    ///Reversing a transfer that was made for a [destination
    ///charge](/docs/connect/destination-charges) is allowed only up to the amount of
    ///the charge. It is possible to reverse a
    ///[transfer_group](https://stripe.com/docs/connect/charges-transfers#transfer-options)
    ///transfer only if the destination account has enough balance to cover the
    ///reversal.
    ///Related guide: [Reversing Transfers](https://stripe.com/docs/connect/charges-transfers#reversing-transfers).
    and TransferReversal = {
        ///Amount, in %s.
        Amount: int
        ///Balance transaction that describes the impact on your account balance.
        [<JsonField(Transform=typeof<AnyOfTransform<TransferReversalBalanceTransaction'AnyOf>>)>]BalanceTransaction: TransferReversalBalanceTransaction'AnyOf option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: string
        ///Linked payment refund for the transfer reversal.
        [<JsonField(Transform=typeof<AnyOfTransform<TransferReversalDestinationPaymentRefund'AnyOf>>)>]DestinationPaymentRefund: TransferReversalDestinationPaymentRefund'AnyOf option
        ///Unique identifier for the object.
        Id: string
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        ///ID of the refund responsible for the transfer reversal.
        [<JsonField(Transform=typeof<AnyOfTransform<TransferReversalSourceRefund'AnyOf>>)>]SourceRefund: TransferReversalSourceRefund'AnyOf option
        ///ID of the transfer that was reversed.
        [<JsonField(Transform=typeof<AnyOfTransform<TransferReversalTransfer'AnyOf>>)>]Transfer: TransferReversalTransfer'AnyOf
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "transfer_reversal"

        static member Create (amount: int, balanceTransaction: TransferReversalBalanceTransaction'AnyOf option, created: DateTime, currency: string, destinationPaymentRefund: TransferReversalDestinationPaymentRefund'AnyOf option, id: string, metadata: Map<string, string> option, sourceRefund: TransferReversalSourceRefund'AnyOf option, transfer: TransferReversalTransfer'AnyOf) =
            {
                TransferReversal.Amount = amount //required
                TransferReversal.BalanceTransaction = balanceTransaction //required
                TransferReversal.Created = created //required
                TransferReversal.Currency = currency //required
                TransferReversal.DestinationPaymentRefund = destinationPaymentRefund //required
                TransferReversal.Id = id //required
                TransferReversal.Metadata = metadata //required
                TransferReversal.SourceRefund = sourceRefund //required
                TransferReversal.Transfer = transfer //required
            }

    and TransferReversalBalanceTransaction'AnyOf =
        | String of string
        | BalanceTransaction of BalanceTransaction

    and TransferReversalDestinationPaymentRefund'AnyOf =
        | String of string
        | Refund of Refund

    and TransferReversalSourceRefund'AnyOf =
        | String of string
        | Refund of Refund

    and TransferReversalTransfer'AnyOf =
        | String of string
        | Transfer of Transfer

    and TransferSchedule = {
        ///The number of days charges for the account will be held before being paid out.
        DelayDays: int
        ///How frequently funds will be paid out. One of `manual` (payouts only created via API call), `daily`, `weekly`, or `monthly`.
        Interval: TransferScheduleInterval
        ///The day of the month funds will be paid out. Only shown if `interval` is monthly. Payouts scheduled between the 29th and 31st of the month are sent on the last day of shorter months.
        MonthlyAnchor: int option
        ///The day of the week funds will be paid out, of the style 'monday', 'tuesday', etc. Only shown if `interval` is weekly.
        WeeklyAnchor: string option
    }
    with

        static member Create (delayDays: int, interval: TransferScheduleInterval, ?monthlyAnchor: int, ?weeklyAnchor: string) =
            {
                TransferSchedule.DelayDays = delayDays //required
                TransferSchedule.Interval = interval //required
                TransferSchedule.MonthlyAnchor = monthlyAnchor
                TransferSchedule.WeeklyAnchor = weeklyAnchor
            }

    and TransferScheduleInterval =
        | Manual
        | Daily
        | Weekly
        | Monthly

    and TransformQuantity = {
        ///Divide usage by this number.
        DivideBy: int
        ///After division, either round the result `up` or `down`.
        Round: TransformQuantityRound
    }
    with

        static member Create (divideBy: int, round: TransformQuantityRound) =
            {
                TransformQuantity.DivideBy = divideBy //required
                TransformQuantity.Round = round //required
            }

    and TransformQuantityRound =
        | Down
        | Up

    and TransformUsage = {
        ///Divide usage by this number.
        DivideBy: int
        ///After division, either round the result `up` or `down`.
        Round: TransformUsageRound
    }
    with

        static member Create (divideBy: int, round: TransformUsageRound) =
            {
                TransformUsage.DivideBy = divideBy //required
                TransformUsage.Round = round //required
            }

    and TransformUsageRound =
        | Down
        | Up

    ///Usage records allow you to report customer usage and metrics to Stripe for
    ///metered billing of subscription prices.
    ///Related guide: [Metered Billing](https://stripe.com/docs/billing/subscriptions/metered-billing).
    and UsageRecord = {
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///The usage quantity for the specified date.
        Quantity: int
        ///The ID of the subscription item this usage record contains data for.
        SubscriptionItem: string
        ///The timestamp when this usage occurred.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Timestamp: DateTime
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "usage_record"

        static member Create (id: string, livemode: bool, quantity: int, subscriptionItem: string, timestamp: DateTime) =
            {
                UsageRecord.Id = id //required
                UsageRecord.Livemode = livemode //required
                UsageRecord.Quantity = quantity //required
                UsageRecord.SubscriptionItem = subscriptionItem //required
                UsageRecord.Timestamp = timestamp //required
            }

    and UsageRecordSummary = {
        ///Unique identifier for the object.
        Id: string
        ///The invoice in which this usage period has been billed for.
        Invoice: string option
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        Period: Period
        ///The ID of the subscription item this summary is describing.
        SubscriptionItem: string
        ///The total usage within this usage period.
        TotalUsage: int
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "usage_record_summary"

        static member Create (id: string, invoice: string option, livemode: bool, period: Period, subscriptionItem: string, totalUsage: int) =
            {
                UsageRecordSummary.Id = id //required
                UsageRecordSummary.Invoice = invoice //required
                UsageRecordSummary.Livemode = livemode //required
                UsageRecordSummary.Period = period //required
                UsageRecordSummary.SubscriptionItem = subscriptionItem //required
                UsageRecordSummary.TotalUsage = totalUsage //required
            }

    ///You can configure [webhook endpoints](https://stripe.com/docs/webhooks/) via the API to be
    ///notified about events that happen in your Stripe account or connected
    ///accounts.
    ///Most users configure webhooks from [the dashboard](https://dashboard.stripe.com/webhooks), which provides a user interface for registering and testing your webhook endpoints.
    ///Related guide: [Setting up Webhooks](https://stripe.com/docs/webhooks/configure).
    and WebhookEndpoint = {
        ///The API version events are rendered as for this webhook endpoint.
        ApiVersion: string option
        ///The ID of the associated Connect application.
        Application: string option
        ///Time at which the object was created. Measured in seconds since the Unix epoch.
        [<JsonField(Transform=typeof<Transforms.DateTimeEpoch>)>]Created: DateTime
        ///An optional description of what the webhook is used for.
        Description: string option
        ///The list of events to enable for this endpoint. `['*']` indicates that all events are enabled, except those that require explicit selection.
        EnabledEvents: string list
        ///Unique identifier for the object.
        Id: string
        ///Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        ///The endpoint's secret, used to generate [webhook signatures](https://stripe.com/docs/webhooks/signatures). Only returned at creation.
        Secret: string option
        ///The status of the webhook. It can be `enabled` or `disabled`.
        Status: WebhookEndpointStatus
        ///The URL of the webhook endpoint.
        Url: string
    }
    with
        ///String representing the object's type. Objects of the same type share the same value.
        member _.Object = "webhook_endpoint"

        static member Create (apiVersion: string option, application: string option, created: DateTime, description: string option, enabledEvents: string list, id: string, livemode: bool, metadata: Map<string, string>, status: WebhookEndpointStatus, url: string, ?secret: string) =
            {
                WebhookEndpoint.ApiVersion = apiVersion //required
                WebhookEndpoint.Application = application //required
                WebhookEndpoint.Created = created //required
                WebhookEndpoint.Description = description //required
                WebhookEndpoint.EnabledEvents = enabledEvents //required
                WebhookEndpoint.Id = id //required
                WebhookEndpoint.Livemode = livemode //required
                WebhookEndpoint.Metadata = metadata //required
                WebhookEndpoint.Status = status //required
                WebhookEndpoint.Url = url //required
                WebhookEndpoint.Secret = secret
            }

    and WebhookEndpointStatus =
        | Enabled
        | Disabled

