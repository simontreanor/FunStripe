namespace FunStripe

open FunStripe.Json
open System

module StripeRequest =

    type Post3dSecureParams (amount: int, currency: string, returnUrl: string, ?card: string, ?customer: string, ?expand: string list) =
        ///Amount of the charge that you will create when authentication completes.
        member _.Amount = amount
        ///The ID of a card token, or the ID of a card belonging to the given customer.
        member _.Card = card
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///The customer associated with this 3D secure authentication.
        member _.Customer = customer
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///The URL that the cardholder's browser will be returned to when authentication completes.
        member _.ReturnUrl = returnUrl

    and PostAccountLinksParams (account: string, ``type``: PostAccountLinksType, ?collect: PostAccountLinksCollect, ?expand: string list, ?refreshUrl: string, ?returnUrl: string) =
        ///The identifier of the account to create an account link for.
        member _.Account = account
        ///Which information the platform needs to collect from the user. One of `currently_due` or `eventually_due`. Default is `currently_due`.
        member _.Collect = collect
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///The URL that the user will be redirected to if the account link is no longer valid. Your `refresh_url` should trigger a method on your server to create a new account link using this API, with the same parameters, and redirect the user to the new account link.
        member _.RefreshUrl = refreshUrl
        ///The URL that the user will be redirected to upon leaving or completing the linked flow.
        member _.ReturnUrl = returnUrl
        ///The type of account link the user is requesting. Possible values are `account_onboarding` or `account_update`.
        member _.Type = ``type``

    and PostAccountLinksCollect =
        | CurrentlyDue
        | EventuallyDue

    and PostAccountLinksType =
        | AccountOnboarding
        | AccountUpdate
        | CustomAccountUpdate
        | CustomAccountVerification

    and PostAccountsParams (?accountToken: string, ?businessProfile: PostAccountsBusinessProfile, ?businessType: PostAccountsBusinessType, ?capabilities: PostAccountsCapabilities, ?company: PostAccountsCompany, ?country: string, ?defaultCurrency: string, ?email: string, ?expand: string list, ?externalAccount: string, ?individual: PostAccountsIndividual, ?metadata: Map<string, string>, ?settings: PostAccountsSettings, ?tosAcceptance: PostAccountsTosAcceptance, ?``type``: PostAccountsType) =
        ///An [account token](https://stripe.com/docs/api#create_account_token), used to securely provide details to the account.
        member _.AccountToken = accountToken
        ///Business information about the account.
        member _.BusinessProfile = businessProfile
        ///The business type.
        member _.BusinessType = businessType
        ///Each key of the dictionary represents a capability, and each capability maps to its settings (e.g. whether it has been requested or not). Each capability will be inactive until you have provided its specific requirements and Stripe has verified them. An account may have some of its requested capabilities be active and some be inactive.
        member _.Capabilities = capabilities
        ///Information about the company or business. This field is available for any `business_type`.
        member _.Company = company
        ///The country in which the account holder resides, or in which the business is legally established. This should be an ISO 3166-1 alpha-2 country code. For example, if you are in the United States and the business for which you're creating an account is legally represented in Canada, you would use `CA` as the country for the account being created.
        member _.Country = country
        ///Three-letter ISO currency code representing the default currency for the account. This must be a currency that [Stripe supports in the account's country](https://stripe.com/docs/payouts).
        member _.DefaultCurrency = defaultCurrency
        ///The email address of the account holder. This is only to make the account easier to identify to you. Stripe will never directly email Custom accounts.
        member _.Email = email
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///A card or bank account to attach to the account for receiving [payouts](https://stripe.com/docs/connect/bank-debit-card-payouts) (you won’t be able to use it for top-ups). You can provide either a token, like the ones returned by [Stripe.js](https://stripe.com/docs/stripe.js), or a dictionary, as documented in the `external_account` parameter for [bank account](https://stripe.com/docs/api#account_create_bank_account) creation. <br><br>By default, providing an external account sets it as the new default external account for its currency, and deletes the old default if one exists. To add additional external accounts without replacing the existing default for the currency, use the bank account or card creation API.
        member _.ExternalAccount = externalAccount
        ///Information about the person represented by the account. This field is null unless `business_type` is set to `individual`.
        member _.Individual = individual
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Options for customizing how the account functions within Stripe.
        member _.Settings = settings
        ///Details on the account's acceptance of the [Stripe Services Agreement](https://stripe.com/docs/connect/updating-accounts#tos-acceptance).
        member _.TosAcceptance = tosAcceptance
        ///The type of Stripe account to create. May be one of `custom`, `express` or `standard`.
        member _.Type = ``type``

    and PostAccountsBusinessType =
        | Company
        | GovernmentEntity
        | Individual
        | NonProfit

    and PostAccountsType =
        | Custom
        | Express
        | Standard

    and PostAccountsBusinessProfile (?mcc: string, ?name: string, ?productDescription: string, ?supportAddress: PostAccountsBusinessProfileSupportAddress, ?supportEmail: string, ?supportPhone: string, ?supportUrl: string, ?url: string) =
        ///[The merchant category code for the account](https://stripe.com/docs/connect/setting-mcc). MCCs are used to classify businesses based on the goods or services they provide.
        member _.Mcc = mcc
        ///The customer-facing business name.
        member _.Name = name
        ///Internal-only description of the product sold by, or service provided by, the business. Used by Stripe for risk and underwriting purposes.
        member _.ProductDescription = productDescription
        ///A publicly available mailing address for sending support issues to.
        member _.SupportAddress = supportAddress
        ///A publicly available email address for sending support issues to.
        member _.SupportEmail = supportEmail
        ///A publicly available phone number to call with support issues.
        member _.SupportPhone = supportPhone
        ///A publicly available website for handling support issues.
        member _.SupportUrl = supportUrl
        ///The business's publicly available website.
        member _.Url = url

    and PostAccountsBusinessProfileSupportAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostAccountsCapabilities (?auBecsDebitPayments: PostAccountsCapabilitiesAuBecsDebitPayments, ?taxReportingUs1099K: PostAccountsCapabilitiesTaxReportingUs1099K, ?sofortPayments: PostAccountsCapabilitiesSofortPayments, ?sepaDebitPayments: PostAccountsCapabilitiesSepaDebitPayments, ?p24Payments: PostAccountsCapabilitiesP24Payments, ?oxxoPayments: PostAccountsCapabilitiesOxxoPayments, ?legacyPayments: PostAccountsCapabilitiesLegacyPayments, ?jcbPayments: PostAccountsCapabilitiesJcbPayments, ?idealPayments: PostAccountsCapabilitiesIdealPayments, ?grabpayPayments: PostAccountsCapabilitiesGrabpayPayments, ?giropayPayments: PostAccountsCapabilitiesGiropayPayments, ?fpxPayments: PostAccountsCapabilitiesFpxPayments, ?epsPayments: PostAccountsCapabilitiesEpsPayments, ?cartesBancairesPayments: PostAccountsCapabilitiesCartesBancairesPayments, ?cardPayments: PostAccountsCapabilitiesCardPayments, ?cardIssuing: PostAccountsCapabilitiesCardIssuing, ?bancontactPayments: PostAccountsCapabilitiesBancontactPayments, ?bacsDebitPayments: PostAccountsCapabilitiesBacsDebitPayments, ?taxReportingUs1099Misc: PostAccountsCapabilitiesTaxReportingUs1099Misc, ?transfers: PostAccountsCapabilitiesTransfers) =
        ///The au_becs_debit_payments capability.
        member _.AuBecsDebitPayments = auBecsDebitPayments
        ///The bacs_debit_payments capability.
        member _.BacsDebitPayments = bacsDebitPayments
        ///The bancontact_payments capability.
        member _.BancontactPayments = bancontactPayments
        ///The card_issuing capability.
        member _.CardIssuing = cardIssuing
        ///The card_payments capability.
        member _.CardPayments = cardPayments
        ///The cartes_bancaires_payments capability.
        member _.CartesBancairesPayments = cartesBancairesPayments
        ///The eps_payments capability.
        member _.EpsPayments = epsPayments
        ///The fpx_payments capability.
        member _.FpxPayments = fpxPayments
        ///The giropay_payments capability.
        member _.GiropayPayments = giropayPayments
        ///The grabpay_payments capability.
        member _.GrabpayPayments = grabpayPayments
        ///The ideal_payments capability.
        member _.IdealPayments = idealPayments
        ///The jcb_payments capability.
        member _.JcbPayments = jcbPayments
        ///The legacy_payments capability.
        member _.LegacyPayments = legacyPayments
        ///The oxxo_payments capability.
        member _.OxxoPayments = oxxoPayments
        ///The p24_payments capability.
        member _.P24Payments = p24Payments
        ///The sepa_debit_payments capability.
        member _.SepaDebitPayments = sepaDebitPayments
        ///The sofort_payments capability.
        member _.SofortPayments = sofortPayments
        ///The tax_reporting_us_1099_k capability.
        member _.TaxReportingUs1099K = taxReportingUs1099K
        ///The tax_reporting_us_1099_misc capability.
        member _.TaxReportingUs1099Misc = taxReportingUs1099Misc
        ///The transfers capability.
        member _.Transfers = transfers

    and PostAccountsCapabilitiesAuBecsDebitPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsCapabilitiesBacsDebitPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsCapabilitiesBancontactPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsCapabilitiesCardIssuing (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsCapabilitiesCardPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsCapabilitiesCartesBancairesPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsCapabilitiesEpsPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsCapabilitiesFpxPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsCapabilitiesGiropayPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsCapabilitiesGrabpayPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsCapabilitiesIdealPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsCapabilitiesJcbPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsCapabilitiesLegacyPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsCapabilitiesOxxoPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsCapabilitiesP24Payments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsCapabilitiesSepaDebitPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsCapabilitiesSofortPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsCapabilitiesTaxReportingUs1099K (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsCapabilitiesTaxReportingUs1099Misc (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsCapabilitiesTransfers (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsCompany (?address: PostAccountsCompanyAddress, ?addressKana: PostAccountsCompanyAddressKana, ?addressKanji: PostAccountsCompanyAddressKanji, ?directorsProvided: bool, ?executivesProvided: bool, ?name: string, ?nameKana: string, ?nameKanji: string, ?ownersProvided: bool, ?phone: string, ?registrationNumber: string, ?structure: PostAccountsCompanyStructure, ?taxId: string, ?taxIdRegistrar: string, ?vatId: string, ?verification: PostAccountsCompanyVerification) =
        ///The company's primary address.
        member _.Address = address
        ///The Kana variation of the company's primary address (Japan only).
        member _.AddressKana = addressKana
        ///The Kanji variation of the company's primary address (Japan only).
        member _.AddressKanji = addressKanji
        ///Whether the company's directors have been provided. Set this Boolean to `true` after creating all the company's directors with [the Persons API](https://stripe.com/docs/api/persons) for accounts with a `relationship.director` requirement. This value is not automatically set to `true` after creating directors, so it needs to be updated to indicate all directors have been provided.
        member _.DirectorsProvided = directorsProvided
        ///Whether the company's executives have been provided. Set this Boolean to `true` after creating all the company's executives with [the Persons API](https://stripe.com/docs/api/persons) for accounts with a `relationship.executive` requirement.
        member _.ExecutivesProvided = executivesProvided
        ///The company's legal name.
        member _.Name = name
        ///The Kana variation of the company's legal name (Japan only).
        member _.NameKana = nameKana
        ///The Kanji variation of the company's legal name (Japan only).
        member _.NameKanji = nameKanji
        ///Whether the company's owners have been provided. Set this Boolean to `true` after creating all the company's owners with [the Persons API](https://stripe.com/docs/api/persons) for accounts with a `relationship.owner` requirement.
        member _.OwnersProvided = ownersProvided
        ///The company's phone number (used for verification).
        member _.Phone = phone
        ///The identification number given to a company when it is registered or incorporated, if distinct from the identification number used for filing taxes. (Examples are the CIN for companies and LLP IN for partnerships in India, and the Company Registration Number in Hong Kong).
        member _.RegistrationNumber = registrationNumber
        ///The category identifying the legal structure of the company or legal entity. See [Business structure](https://stripe.com/docs/connect/identity-verification#business-structure) for more details.
        member _.Structure = structure
        ///The business ID number of the company, as appropriate for the company’s country. (Examples are an Employer ID Number in the U.S., a Business Number in Canada, or a Company Number in the UK.)
        member _.TaxId = taxId
        ///The jurisdiction in which the `tax_id` is registered (Germany-based companies only).
        member _.TaxIdRegistrar = taxIdRegistrar
        ///The VAT number of the company.
        member _.VatId = vatId
        ///Information on the verification state of the company.
        member _.Verification = verification

    and PostAccountsCompanyStructure =
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

    and PostAccountsCompanyAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostAccountsCompanyAddressKana (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
        ///City or ward.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Block or building number.
        member _.Line1 = line1
        ///Building details.
        member _.Line2 = line2
        ///Postal code.
        member _.PostalCode = postalCode
        ///Prefecture.
        member _.State = state
        ///Town or cho-me.
        member _.Town = town

    and PostAccountsCompanyAddressKanji (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
        ///City or ward.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Block or building number.
        member _.Line1 = line1
        ///Building details.
        member _.Line2 = line2
        ///Postal code.
        member _.PostalCode = postalCode
        ///Prefecture.
        member _.State = state
        ///Town or cho-me.
        member _.Town = town

    and PostAccountsCompanyVerification (?document: PostAccountsCompanyVerificationDocument) =
        ///A document verifying the business.
        member _.Document = document

    and PostAccountsCompanyVerificationDocument (?back: string, ?front: string) =
        ///The back of a document returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `additional_verification`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Back = back
        ///The front of a document returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `additional_verification`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Front = front

    and PostAccountsIndividual (?address: PostAccountsIndividualAddress, ?politicalExposure: PostAccountsIndividualPoliticalExposure, ?phone: string, ?metadata: Map<string, string>, ?maidenName: string, ?lastNameKanji: string, ?lastNameKana: string, ?lastName: string, ?ssnLast4: string, ?idNumber: string, ?firstNameKanji: string, ?firstNameKana: string, ?firstName: string, ?email: string, ?dob: Choice<PostAccountsIndividualDobDateOfBirthSpecs,string>, ?addressKanji: PostAccountsIndividualAddressKanji, ?addressKana: PostAccountsIndividualAddressKana, ?gender: string, ?verification: PostAccountsIndividualVerification) =
        ///The individual's primary address.
        member _.Address = address
        ///The Kana variation of the the individual's primary address (Japan only).
        member _.AddressKana = addressKana
        ///The Kanji variation of the the individual's primary address (Japan only).
        member _.AddressKanji = addressKanji
        ///The individual's date of birth.
        member _.Dob = dob
        ///The individual's email address.
        member _.Email = email
        ///The individual's first name.
        member _.FirstName = firstName
        ///The Kana variation of the the individual's first name (Japan only).
        member _.FirstNameKana = firstNameKana
        ///The Kanji variation of the individual's first name (Japan only).
        member _.FirstNameKanji = firstNameKanji
        ///The individual's gender (International regulations require either "male" or "female").
        member _.Gender = gender
        ///The government-issued ID number of the individual, as appropriate for the representative’s country. (Examples are a Social Security Number in the U.S., or a Social Insurance Number in Canada). Instead of the number itself, you can also provide a [PII token created with Stripe.js](https://stripe.com/docs/stripe.js#collecting-pii-data).
        member _.IdNumber = idNumber
        ///The individual's last name.
        member _.LastName = lastName
        ///The Kana varation of the individual's last name (Japan only).
        member _.LastNameKana = lastNameKana
        ///The Kanji varation of the individual's last name (Japan only).
        member _.LastNameKanji = lastNameKanji
        ///The individual's maiden name.
        member _.MaidenName = maidenName
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The individual's phone number.
        member _.Phone = phone
        ///Indicates if the person or any of their representatives, family members, or other closely related persons, declares that they hold or have held an important public job or function, in any jurisdiction.
        member _.PoliticalExposure = politicalExposure
        ///The last four digits of the individual's Social Security Number (U.S. only).
        member _.SsnLast4 = ssnLast4
        ///The individual's verification document information.
        member _.Verification = verification

    and PostAccountsIndividualPoliticalExposure =
        | Existing
        | None'

    and PostAccountsIndividualAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostAccountsIndividualAddressKana (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
        ///City or ward.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Block or building number.
        member _.Line1 = line1
        ///Building details.
        member _.Line2 = line2
        ///Postal code.
        member _.PostalCode = postalCode
        ///Prefecture.
        member _.State = state
        ///Town or cho-me.
        member _.Town = town

    and PostAccountsIndividualAddressKanji (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
        ///City or ward.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Block or building number.
        member _.Line1 = line1
        ///Building details.
        member _.Line2 = line2
        ///Postal code.
        member _.PostalCode = postalCode
        ///Prefecture.
        member _.State = state
        ///Town or cho-me.
        member _.Town = town

    and PostAccountsIndividualDobDateOfBirthSpecs (?day: int, ?month: int, ?year: int) =
        ///The day of birth, between 1 and 31.
        member _.Day = day
        ///The month of birth, between 1 and 12.
        member _.Month = month
        ///The four-digit year of birth.
        member _.Year = year

    and PostAccountsIndividualVerification (?additionalDocument: PostAccountsIndividualVerificationAdditionalDocument, ?document: PostAccountsIndividualVerificationDocument) =
        ///A document showing address, either a passport, local ID card, or utility bill from a well-known utility company.
        member _.AdditionalDocument = additionalDocument
        ///An identifying document, either a passport or local ID card.
        member _.Document = document

    and PostAccountsIndividualVerificationAdditionalDocument (?back: string, ?front: string) =
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Back = back
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Front = front

    and PostAccountsIndividualVerificationDocument (?back: string, ?front: string) =
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Back = back
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Front = front

    and PostAccountsSettings (?branding: PostAccountsSettingsBranding, ?cardPayments: PostAccountsSettingsCardPayments, ?payments: PostAccountsSettingsPayments, ?payouts: PostAccountsSettingsPayouts) =
        ///Settings used to apply the account's branding to email receipts, invoices, Checkout, and other products.
        member _.Branding = branding
        ///Settings specific to card charging on the account.
        member _.CardPayments = cardPayments
        ///Settings that apply across payment methods for charging on the account.
        member _.Payments = payments
        ///Settings specific to the account's payouts.
        member _.Payouts = payouts

    and PostAccountsSettingsBranding (?icon: string, ?logo: string, ?primaryColor: string, ?secondaryColor: string) =
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) An icon for the account. Must be square and at least 128px x 128px.
        member _.Icon = icon
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) A logo for the account that will be used in Checkout instead of the icon and without the account's name next to it if provided. Must be at least 128px x 128px.
        member _.Logo = logo
        ///A CSS hex color value representing the primary branding color for this account.
        member _.PrimaryColor = primaryColor
        ///A CSS hex color value representing the secondary branding color for this account.
        member _.SecondaryColor = secondaryColor

    and PostAccountsSettingsCardPayments (?declineOn: PostAccountsSettingsCardPaymentsDeclineOn, ?statementDescriptorPrefix: string) =
        ///Automatically declines certain charge types regardless of whether the card issuer accepted or declined the charge.
        member _.DeclineOn = declineOn
        ///The default text that appears on credit card statements when a charge is made. This field prefixes any dynamic `statement_descriptor` specified on the charge. `statement_descriptor_prefix` is useful for maximizing descriptor space for the dynamic portion.
        member _.StatementDescriptorPrefix = statementDescriptorPrefix

    and PostAccountsSettingsCardPaymentsDeclineOn (?avsFailure: bool, ?cvcFailure: bool) =
        ///Whether Stripe automatically declines charges with an incorrect ZIP or postal code. This setting only applies when a ZIP or postal code is provided and they fail bank verification.
        member _.AvsFailure = avsFailure
        ///Whether Stripe automatically declines charges with an incorrect CVC. This setting only applies when a CVC is provided and it fails bank verification.
        member _.CvcFailure = cvcFailure

    and PostAccountsSettingsPayments (?statementDescriptor: string, ?statementDescriptorKana: string, ?statementDescriptorKanji: string) =
        ///The default text that appears on credit card statements when a charge is made. This field prefixes any dynamic `statement_descriptor` specified on the charge.
        member _.StatementDescriptor = statementDescriptor
        ///The Kana variation of the default text that appears on credit card statements when a charge is made (Japan only).
        member _.StatementDescriptorKana = statementDescriptorKana
        ///The Kanji variation of the default text that appears on credit card statements when a charge is made (Japan only).
        member _.StatementDescriptorKanji = statementDescriptorKanji

    and PostAccountsSettingsPayouts (?debitNegativeBalances: bool, ?schedule: PostAccountsSettingsPayoutsSchedule, ?statementDescriptor: string) =
        ///A Boolean indicating whether Stripe should try to reclaim negative balances from an attached bank account. For details, see [Understanding Connect Account Balances](https://stripe.com/docs/connect/account-balances).
        member _.DebitNegativeBalances = debitNegativeBalances
        ///Details on when funds from charges are available, and when they are paid out to an external account. For details, see our [Setting Bank and Debit Card Payouts](https://stripe.com/docs/connect/bank-transfers#payout-information) documentation.
        member _.Schedule = schedule
        ///The text that appears on the bank account statement for payouts. If not set, this defaults to the platform's bank descriptor as set in the Dashboard.
        member _.StatementDescriptor = statementDescriptor

    and PostAccountsSettingsPayoutsSchedule (?delayDays: Choice<PostAccountsSettingsPayoutsScheduleDelayDays,int>, ?interval: PostAccountsSettingsPayoutsScheduleInterval, ?monthlyAnchor: int, ?weeklyAnchor: PostAccountsSettingsPayoutsScheduleWeeklyAnchor) =
        ///The number of days charge funds are held before being paid out. May also be set to `minimum`, representing the lowest available value for the account country. Default is `minimum`. The `delay_days` parameter does not apply when the `interval` is `manual`.
        member _.DelayDays = delayDays
        ///How frequently available funds are paid out. One of: `daily`, `manual`, `weekly`, or `monthly`. Default is `daily`.
        member _.Interval = interval
        ///The day of the month when available funds are paid out, specified as a number between 1--31. Payouts nominally scheduled between the 29th and 31st of the month are instead sent on the last day of a shorter month. Required and applicable only if `interval` is `monthly`.
        member _.MonthlyAnchor = monthlyAnchor
        ///The day of the week when available funds are paid out, specified as `monday`, `tuesday`, etc. (required and applicable only if `interval` is `weekly`.)
        member _.WeeklyAnchor = weeklyAnchor

    and PostAccountsSettingsPayoutsScheduleInterval =
        | Daily
        | Manual
        | Monthly
        | Weekly

    and PostAccountsSettingsPayoutsScheduleWeeklyAnchor =
        | Friday
        | Monday
        | Saturday
        | Sunday
        | Thursday
        | Tuesday
        | Wednesday

    and PostAccountsSettingsPayoutsScheduleDelayDays =
        | Minimum

    and PostAccountsTosAcceptance (?date: DateTime, ?ip: string, ?serviceAgreement: string, ?userAgent: string) =
        ///The Unix timestamp marking when the account representative accepted their service agreement.
        member _.Date = date
        ///The IP address from which the account representative accepted their service agreement.
        member _.Ip = ip
        ///The user's service agreement type.
        member _.ServiceAgreement = serviceAgreement
        ///The user agent of the browser from which the account representative accepted their service agreement.
        member _.UserAgent = userAgent

    and PostAccountsAccountParams (?accountToken: string, ?businessProfile: PostAccountsAccountBusinessProfile, ?businessType: PostAccountsAccountBusinessType, ?capabilities: PostAccountsAccountCapabilities, ?company: PostAccountsAccountCompany, ?defaultCurrency: string, ?email: string, ?expand: string list, ?externalAccount: string, ?individual: PostAccountsAccountIndividual, ?metadata: Map<string, string>, ?settings: PostAccountsAccountSettings, ?tosAcceptance: PostAccountsAccountTosAcceptance) =
        ///An [account token](https://stripe.com/docs/api#create_account_token), used to securely provide details to the account.
        member _.AccountToken = accountToken
        ///Business information about the account.
        member _.BusinessProfile = businessProfile
        ///The business type.
        member _.BusinessType = businessType
        ///Each key of the dictionary represents a capability, and each capability maps to its settings (e.g. whether it has been requested or not). Each capability will be inactive until you have provided its specific requirements and Stripe has verified them. An account may have some of its requested capabilities be active and some be inactive.
        member _.Capabilities = capabilities
        ///Information about the company or business. This field is available for any `business_type`.
        member _.Company = company
        ///Three-letter ISO currency code representing the default currency for the account. This must be a currency that [Stripe supports in the account's country](https://stripe.com/docs/payouts).
        member _.DefaultCurrency = defaultCurrency
        ///The email address of the account holder. This is only to make the account easier to identify to you. Stripe will never directly email Custom accounts.
        member _.Email = email
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///A card or bank account to attach to the account for receiving [payouts](https://stripe.com/docs/connect/bank-debit-card-payouts) (you won’t be able to use it for top-ups). You can provide either a token, like the ones returned by [Stripe.js](https://stripe.com/docs/stripe.js), or a dictionary, as documented in the `external_account` parameter for [bank account](https://stripe.com/docs/api#account_create_bank_account) creation. <br><br>By default, providing an external account sets it as the new default external account for its currency, and deletes the old default if one exists. To add additional external accounts without replacing the existing default for the currency, use the bank account or card creation API.
        member _.ExternalAccount = externalAccount
        ///Information about the person represented by the account. This field is null unless `business_type` is set to `individual`.
        member _.Individual = individual
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Options for customizing how the account functions within Stripe.
        member _.Settings = settings
        ///Details on the account's acceptance of the [Stripe Services Agreement](https://stripe.com/docs/connect/updating-accounts#tos-acceptance).
        member _.TosAcceptance = tosAcceptance

    and PostAccountsAccountBusinessType =
        | Company
        | GovernmentEntity
        | Individual
        | NonProfit

    and PostAccountsAccountBusinessProfile (?mcc: string, ?name: string, ?productDescription: string, ?supportAddress: PostAccountsAccountBusinessProfileSupportAddress, ?supportEmail: string, ?supportPhone: string, ?supportUrl: string, ?url: string) =
        ///[The merchant category code for the account](https://stripe.com/docs/connect/setting-mcc). MCCs are used to classify businesses based on the goods or services they provide.
        member _.Mcc = mcc
        ///The customer-facing business name.
        member _.Name = name
        ///Internal-only description of the product sold by, or service provided by, the business. Used by Stripe for risk and underwriting purposes.
        member _.ProductDescription = productDescription
        ///A publicly available mailing address for sending support issues to.
        member _.SupportAddress = supportAddress
        ///A publicly available email address for sending support issues to.
        member _.SupportEmail = supportEmail
        ///A publicly available phone number to call with support issues.
        member _.SupportPhone = supportPhone
        ///A publicly available website for handling support issues.
        member _.SupportUrl = supportUrl
        ///The business's publicly available website.
        member _.Url = url

    and PostAccountsAccountBusinessProfileSupportAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostAccountsAccountCapabilities (?auBecsDebitPayments: PostAccountsAccountCapabilitiesAuBecsDebitPayments, ?taxReportingUs1099K: PostAccountsAccountCapabilitiesTaxReportingUs1099K, ?sofortPayments: PostAccountsAccountCapabilitiesSofortPayments, ?sepaDebitPayments: PostAccountsAccountCapabilitiesSepaDebitPayments, ?p24Payments: PostAccountsAccountCapabilitiesP24Payments, ?oxxoPayments: PostAccountsAccountCapabilitiesOxxoPayments, ?legacyPayments: PostAccountsAccountCapabilitiesLegacyPayments, ?jcbPayments: PostAccountsAccountCapabilitiesJcbPayments, ?idealPayments: PostAccountsAccountCapabilitiesIdealPayments, ?grabpayPayments: PostAccountsAccountCapabilitiesGrabpayPayments, ?giropayPayments: PostAccountsAccountCapabilitiesGiropayPayments, ?fpxPayments: PostAccountsAccountCapabilitiesFpxPayments, ?epsPayments: PostAccountsAccountCapabilitiesEpsPayments, ?cartesBancairesPayments: PostAccountsAccountCapabilitiesCartesBancairesPayments, ?cardPayments: PostAccountsAccountCapabilitiesCardPayments, ?cardIssuing: PostAccountsAccountCapabilitiesCardIssuing, ?bancontactPayments: PostAccountsAccountCapabilitiesBancontactPayments, ?bacsDebitPayments: PostAccountsAccountCapabilitiesBacsDebitPayments, ?taxReportingUs1099Misc: PostAccountsAccountCapabilitiesTaxReportingUs1099Misc, ?transfers: PostAccountsAccountCapabilitiesTransfers) =
        ///The au_becs_debit_payments capability.
        member _.AuBecsDebitPayments = auBecsDebitPayments
        ///The bacs_debit_payments capability.
        member _.BacsDebitPayments = bacsDebitPayments
        ///The bancontact_payments capability.
        member _.BancontactPayments = bancontactPayments
        ///The card_issuing capability.
        member _.CardIssuing = cardIssuing
        ///The card_payments capability.
        member _.CardPayments = cardPayments
        ///The cartes_bancaires_payments capability.
        member _.CartesBancairesPayments = cartesBancairesPayments
        ///The eps_payments capability.
        member _.EpsPayments = epsPayments
        ///The fpx_payments capability.
        member _.FpxPayments = fpxPayments
        ///The giropay_payments capability.
        member _.GiropayPayments = giropayPayments
        ///The grabpay_payments capability.
        member _.GrabpayPayments = grabpayPayments
        ///The ideal_payments capability.
        member _.IdealPayments = idealPayments
        ///The jcb_payments capability.
        member _.JcbPayments = jcbPayments
        ///The legacy_payments capability.
        member _.LegacyPayments = legacyPayments
        ///The oxxo_payments capability.
        member _.OxxoPayments = oxxoPayments
        ///The p24_payments capability.
        member _.P24Payments = p24Payments
        ///The sepa_debit_payments capability.
        member _.SepaDebitPayments = sepaDebitPayments
        ///The sofort_payments capability.
        member _.SofortPayments = sofortPayments
        ///The tax_reporting_us_1099_k capability.
        member _.TaxReportingUs1099K = taxReportingUs1099K
        ///The tax_reporting_us_1099_misc capability.
        member _.TaxReportingUs1099Misc = taxReportingUs1099Misc
        ///The transfers capability.
        member _.Transfers = transfers

    and PostAccountsAccountCapabilitiesAuBecsDebitPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsAccountCapabilitiesBacsDebitPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsAccountCapabilitiesBancontactPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsAccountCapabilitiesCardIssuing (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsAccountCapabilitiesCardPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsAccountCapabilitiesCartesBancairesPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsAccountCapabilitiesEpsPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsAccountCapabilitiesFpxPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsAccountCapabilitiesGiropayPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsAccountCapabilitiesGrabpayPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsAccountCapabilitiesIdealPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsAccountCapabilitiesJcbPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsAccountCapabilitiesLegacyPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsAccountCapabilitiesOxxoPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsAccountCapabilitiesP24Payments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsAccountCapabilitiesSepaDebitPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsAccountCapabilitiesSofortPayments (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsAccountCapabilitiesTaxReportingUs1099K (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsAccountCapabilitiesTaxReportingUs1099Misc (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsAccountCapabilitiesTransfers (?requested: bool) =
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsAccountCompany (?address: PostAccountsAccountCompanyAddress, ?addressKana: PostAccountsAccountCompanyAddressKana, ?addressKanji: PostAccountsAccountCompanyAddressKanji, ?directorsProvided: bool, ?executivesProvided: bool, ?name: string, ?nameKana: string, ?nameKanji: string, ?ownersProvided: bool, ?phone: string, ?registrationNumber: string, ?structure: PostAccountsAccountCompanyStructure, ?taxId: string, ?taxIdRegistrar: string, ?vatId: string, ?verification: PostAccountsAccountCompanyVerification) =
        ///The company's primary address.
        member _.Address = address
        ///The Kana variation of the company's primary address (Japan only).
        member _.AddressKana = addressKana
        ///The Kanji variation of the company's primary address (Japan only).
        member _.AddressKanji = addressKanji
        ///Whether the company's directors have been provided. Set this Boolean to `true` after creating all the company's directors with [the Persons API](https://stripe.com/docs/api/persons) for accounts with a `relationship.director` requirement. This value is not automatically set to `true` after creating directors, so it needs to be updated to indicate all directors have been provided.
        member _.DirectorsProvided = directorsProvided
        ///Whether the company's executives have been provided. Set this Boolean to `true` after creating all the company's executives with [the Persons API](https://stripe.com/docs/api/persons) for accounts with a `relationship.executive` requirement.
        member _.ExecutivesProvided = executivesProvided
        ///The company's legal name.
        member _.Name = name
        ///The Kana variation of the company's legal name (Japan only).
        member _.NameKana = nameKana
        ///The Kanji variation of the company's legal name (Japan only).
        member _.NameKanji = nameKanji
        ///Whether the company's owners have been provided. Set this Boolean to `true` after creating all the company's owners with [the Persons API](https://stripe.com/docs/api/persons) for accounts with a `relationship.owner` requirement.
        member _.OwnersProvided = ownersProvided
        ///The company's phone number (used for verification).
        member _.Phone = phone
        ///The identification number given to a company when it is registered or incorporated, if distinct from the identification number used for filing taxes. (Examples are the CIN for companies and LLP IN for partnerships in India, and the Company Registration Number in Hong Kong).
        member _.RegistrationNumber = registrationNumber
        ///The category identifying the legal structure of the company or legal entity. See [Business structure](https://stripe.com/docs/connect/identity-verification#business-structure) for more details.
        member _.Structure = structure
        ///The business ID number of the company, as appropriate for the company’s country. (Examples are an Employer ID Number in the U.S., a Business Number in Canada, or a Company Number in the UK.)
        member _.TaxId = taxId
        ///The jurisdiction in which the `tax_id` is registered (Germany-based companies only).
        member _.TaxIdRegistrar = taxIdRegistrar
        ///The VAT number of the company.
        member _.VatId = vatId
        ///Information on the verification state of the company.
        member _.Verification = verification

    and PostAccountsAccountCompanyStructure =
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

    and PostAccountsAccountCompanyAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostAccountsAccountCompanyAddressKana (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
        ///City or ward.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Block or building number.
        member _.Line1 = line1
        ///Building details.
        member _.Line2 = line2
        ///Postal code.
        member _.PostalCode = postalCode
        ///Prefecture.
        member _.State = state
        ///Town or cho-me.
        member _.Town = town

    and PostAccountsAccountCompanyAddressKanji (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
        ///City or ward.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Block or building number.
        member _.Line1 = line1
        ///Building details.
        member _.Line2 = line2
        ///Postal code.
        member _.PostalCode = postalCode
        ///Prefecture.
        member _.State = state
        ///Town or cho-me.
        member _.Town = town

    and PostAccountsAccountCompanyVerification (?document: PostAccountsAccountCompanyVerificationDocument) =
        ///A document verifying the business.
        member _.Document = document

    and PostAccountsAccountCompanyVerificationDocument (?back: string, ?front: string) =
        ///The back of a document returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `additional_verification`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Back = back
        ///The front of a document returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `additional_verification`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Front = front

    and PostAccountsAccountIndividual (?address: PostAccountsAccountIndividualAddress, ?politicalExposure: PostAccountsAccountIndividualPoliticalExposure, ?phone: string, ?metadata: Map<string, string>, ?maidenName: string, ?lastNameKanji: string, ?lastNameKana: string, ?lastName: string, ?ssnLast4: string, ?idNumber: string, ?firstNameKanji: string, ?firstNameKana: string, ?firstName: string, ?email: string, ?dob: Choice<PostAccountsAccountIndividualDobDateOfBirthSpecs,string>, ?addressKanji: PostAccountsAccountIndividualAddressKanji, ?addressKana: PostAccountsAccountIndividualAddressKana, ?gender: string, ?verification: PostAccountsAccountIndividualVerification) =
        ///The individual's primary address.
        member _.Address = address
        ///The Kana variation of the the individual's primary address (Japan only).
        member _.AddressKana = addressKana
        ///The Kanji variation of the the individual's primary address (Japan only).
        member _.AddressKanji = addressKanji
        ///The individual's date of birth.
        member _.Dob = dob
        ///The individual's email address.
        member _.Email = email
        ///The individual's first name.
        member _.FirstName = firstName
        ///The Kana variation of the the individual's first name (Japan only).
        member _.FirstNameKana = firstNameKana
        ///The Kanji variation of the individual's first name (Japan only).
        member _.FirstNameKanji = firstNameKanji
        ///The individual's gender (International regulations require either "male" or "female").
        member _.Gender = gender
        ///The government-issued ID number of the individual, as appropriate for the representative’s country. (Examples are a Social Security Number in the U.S., or a Social Insurance Number in Canada). Instead of the number itself, you can also provide a [PII token created with Stripe.js](https://stripe.com/docs/stripe.js#collecting-pii-data).
        member _.IdNumber = idNumber
        ///The individual's last name.
        member _.LastName = lastName
        ///The Kana varation of the individual's last name (Japan only).
        member _.LastNameKana = lastNameKana
        ///The Kanji varation of the individual's last name (Japan only).
        member _.LastNameKanji = lastNameKanji
        ///The individual's maiden name.
        member _.MaidenName = maidenName
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The individual's phone number.
        member _.Phone = phone
        ///Indicates if the person or any of their representatives, family members, or other closely related persons, declares that they hold or have held an important public job or function, in any jurisdiction.
        member _.PoliticalExposure = politicalExposure
        ///The last four digits of the individual's Social Security Number (U.S. only).
        member _.SsnLast4 = ssnLast4
        ///The individual's verification document information.
        member _.Verification = verification

    and PostAccountsAccountIndividualPoliticalExposure =
        | Existing
        | None'

    and PostAccountsAccountIndividualAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostAccountsAccountIndividualAddressKana (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
        ///City or ward.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Block or building number.
        member _.Line1 = line1
        ///Building details.
        member _.Line2 = line2
        ///Postal code.
        member _.PostalCode = postalCode
        ///Prefecture.
        member _.State = state
        ///Town or cho-me.
        member _.Town = town

    and PostAccountsAccountIndividualAddressKanji (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
        ///City or ward.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Block or building number.
        member _.Line1 = line1
        ///Building details.
        member _.Line2 = line2
        ///Postal code.
        member _.PostalCode = postalCode
        ///Prefecture.
        member _.State = state
        ///Town or cho-me.
        member _.Town = town

    and PostAccountsAccountIndividualDobDateOfBirthSpecs (?day: int, ?month: int, ?year: int) =
        ///The day of birth, between 1 and 31.
        member _.Day = day
        ///The month of birth, between 1 and 12.
        member _.Month = month
        ///The four-digit year of birth.
        member _.Year = year

    and PostAccountsAccountIndividualVerification (?additionalDocument: PostAccountsAccountIndividualVerificationAdditionalDocument, ?document: PostAccountsAccountIndividualVerificationDocument) =
        ///A document showing address, either a passport, local ID card, or utility bill from a well-known utility company.
        member _.AdditionalDocument = additionalDocument
        ///An identifying document, either a passport or local ID card.
        member _.Document = document

    and PostAccountsAccountIndividualVerificationAdditionalDocument (?back: string, ?front: string) =
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Back = back
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Front = front

    and PostAccountsAccountIndividualVerificationDocument (?back: string, ?front: string) =
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Back = back
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Front = front

    and PostAccountsAccountSettings (?branding: PostAccountsAccountSettingsBranding, ?cardPayments: PostAccountsAccountSettingsCardPayments, ?payments: PostAccountsAccountSettingsPayments, ?payouts: PostAccountsAccountSettingsPayouts) =
        ///Settings used to apply the account's branding to email receipts, invoices, Checkout, and other products.
        member _.Branding = branding
        ///Settings specific to card charging on the account.
        member _.CardPayments = cardPayments
        ///Settings that apply across payment methods for charging on the account.
        member _.Payments = payments
        ///Settings specific to the account's payouts.
        member _.Payouts = payouts

    and PostAccountsAccountSettingsBranding (?icon: string, ?logo: string, ?primaryColor: string, ?secondaryColor: string) =
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) An icon for the account. Must be square and at least 128px x 128px.
        member _.Icon = icon
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) A logo for the account that will be used in Checkout instead of the icon and without the account's name next to it if provided. Must be at least 128px x 128px.
        member _.Logo = logo
        ///A CSS hex color value representing the primary branding color for this account.
        member _.PrimaryColor = primaryColor
        ///A CSS hex color value representing the secondary branding color for this account.
        member _.SecondaryColor = secondaryColor

    and PostAccountsAccountSettingsCardPayments (?declineOn: PostAccountsAccountSettingsCardPaymentsDeclineOn, ?statementDescriptorPrefix: string) =
        ///Automatically declines certain charge types regardless of whether the card issuer accepted or declined the charge.
        member _.DeclineOn = declineOn
        ///The default text that appears on credit card statements when a charge is made. This field prefixes any dynamic `statement_descriptor` specified on the charge. `statement_descriptor_prefix` is useful for maximizing descriptor space for the dynamic portion.
        member _.StatementDescriptorPrefix = statementDescriptorPrefix

    and PostAccountsAccountSettingsCardPaymentsDeclineOn (?avsFailure: bool, ?cvcFailure: bool) =
        ///Whether Stripe automatically declines charges with an incorrect ZIP or postal code. This setting only applies when a ZIP or postal code is provided and they fail bank verification.
        member _.AvsFailure = avsFailure
        ///Whether Stripe automatically declines charges with an incorrect CVC. This setting only applies when a CVC is provided and it fails bank verification.
        member _.CvcFailure = cvcFailure

    and PostAccountsAccountSettingsPayments (?statementDescriptor: string, ?statementDescriptorKana: string, ?statementDescriptorKanji: string) =
        ///The default text that appears on credit card statements when a charge is made. This field prefixes any dynamic `statement_descriptor` specified on the charge.
        member _.StatementDescriptor = statementDescriptor
        ///The Kana variation of the default text that appears on credit card statements when a charge is made (Japan only).
        member _.StatementDescriptorKana = statementDescriptorKana
        ///The Kanji variation of the default text that appears on credit card statements when a charge is made (Japan only).
        member _.StatementDescriptorKanji = statementDescriptorKanji

    and PostAccountsAccountSettingsPayouts (?debitNegativeBalances: bool, ?schedule: PostAccountsAccountSettingsPayoutsSchedule, ?statementDescriptor: string) =
        ///A Boolean indicating whether Stripe should try to reclaim negative balances from an attached bank account. For details, see [Understanding Connect Account Balances](https://stripe.com/docs/connect/account-balances).
        member _.DebitNegativeBalances = debitNegativeBalances
        ///Details on when funds from charges are available, and when they are paid out to an external account. For details, see our [Setting Bank and Debit Card Payouts](https://stripe.com/docs/connect/bank-transfers#payout-information) documentation.
        member _.Schedule = schedule
        ///The text that appears on the bank account statement for payouts. If not set, this defaults to the platform's bank descriptor as set in the Dashboard.
        member _.StatementDescriptor = statementDescriptor

    and PostAccountsAccountSettingsPayoutsSchedule (?delayDays: Choice<PostAccountsAccountSettingsPayoutsScheduleDelayDays,int>, ?interval: PostAccountsAccountSettingsPayoutsScheduleInterval, ?monthlyAnchor: int, ?weeklyAnchor: PostAccountsAccountSettingsPayoutsScheduleWeeklyAnchor) =
        ///The number of days charge funds are held before being paid out. May also be set to `minimum`, representing the lowest available value for the account country. Default is `minimum`. The `delay_days` parameter does not apply when the `interval` is `manual`.
        member _.DelayDays = delayDays
        ///How frequently available funds are paid out. One of: `daily`, `manual`, `weekly`, or `monthly`. Default is `daily`.
        member _.Interval = interval
        ///The day of the month when available funds are paid out, specified as a number between 1--31. Payouts nominally scheduled between the 29th and 31st of the month are instead sent on the last day of a shorter month. Required and applicable only if `interval` is `monthly`.
        member _.MonthlyAnchor = monthlyAnchor
        ///The day of the week when available funds are paid out, specified as `monday`, `tuesday`, etc. (required and applicable only if `interval` is `weekly`.)
        member _.WeeklyAnchor = weeklyAnchor

    and PostAccountsAccountSettingsPayoutsScheduleInterval =
        | Daily
        | Manual
        | Monthly
        | Weekly

    and PostAccountsAccountSettingsPayoutsScheduleWeeklyAnchor =
        | Friday
        | Monday
        | Saturday
        | Sunday
        | Thursday
        | Tuesday
        | Wednesday

    and PostAccountsAccountSettingsPayoutsScheduleDelayDays =
        | Minimum

    and PostAccountsAccountTosAcceptance (?date: DateTime, ?ip: string, ?serviceAgreement: string, ?userAgent: string) =
        ///The Unix timestamp marking when the account representative accepted their service agreement.
        member _.Date = date
        ///The IP address from which the account representative accepted their service agreement.
        member _.Ip = ip
        ///The user's service agreement type.
        member _.ServiceAgreement = serviceAgreement
        ///The user agent of the browser from which the account representative accepted their service agreement.
        member _.UserAgent = userAgent

    and PostAccountsAccountCapabilitiesCapabilityParams (?expand: string list, ?requested: bool) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        member _.Requested = requested

    and PostAccountsAccountExternalAccountsParams (externalAccount: string, ?defaultForCurrency: bool, ?expand: string list, ?metadata: Map<string, string>) =
        ///When set to true, or if this is the first external account added in this currency, this account becomes the default external account for its currency.
        member _.DefaultForCurrency = defaultForCurrency
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Please refer to full [documentation](https://stripe.com/docs/api) instead.
        member _.ExternalAccount = externalAccount
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostAccountsAccountExternalAccountsIdParams (?accountHolderName: string, ?accountHolderType: PostAccountsAccountExternalAccountsIdAccountHolderType, ?addressCity: string, ?addressCountry: string, ?addressLine1: string, ?addressLine2: string, ?addressState: string, ?addressZip: string, ?defaultForCurrency: bool, ?expMonth: string, ?expYear: string, ?expand: string list, ?metadata: Map<string, string>, ?name: string) =
        ///The name of the person or business that owns the bank account.
        member _.AccountHolderName = accountHolderName
        ///The type of entity that holds the account. This can be either `individual` or `company`.
        member _.AccountHolderType = accountHolderType
        ///City/District/Suburb/Town/Village.
        member _.AddressCity = addressCity
        ///Billing address country, if provided when creating card.
        member _.AddressCountry = addressCountry
        ///Address line 1 (Street address/PO Box/Company name).
        member _.AddressLine1 = addressLine1
        ///Address line 2 (Apartment/Suite/Unit/Building).
        member _.AddressLine2 = addressLine2
        ///State/County/Province/Region.
        member _.AddressState = addressState
        ///ZIP or postal code.
        member _.AddressZip = addressZip
        ///When set to true, this becomes the default external account for its currency.
        member _.DefaultForCurrency = defaultForCurrency
        ///Two digit number representing the card’s expiration month.
        member _.ExpMonth = expMonth
        ///Four digit number representing the card’s expiration year.
        member _.ExpYear = expYear
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Cardholder name.
        member _.Name = name

    and PostAccountsAccountExternalAccountsIdAccountHolderType =
        | Company
        | Individual

    and PostAccountsAccountLoginLinksParams (?expand: string list, ?redirectUrl: string) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Where to redirect the user after they log out of their dashboard.
        member _.RedirectUrl = redirectUrl

    and PostAccountsAccountPersonsParams (?address: PostAccountsAccountPersonsAddress, ?relationship: PostAccountsAccountPersonsRelationship, ?politicalExposure: string, ?phone: string, ?personToken: string, ?metadata: Map<string, string>, ?maidenName: string, ?lastNameKanji: string, ?lastNameKana: string, ?lastName: string, ?idNumber: string, ?gender: string, ?firstNameKanji: string, ?firstNameKana: string, ?firstName: string, ?expand: string list, ?email: string, ?dob: Choice<PostAccountsAccountPersonsDobDateOfBirthSpecs,string>, ?addressKanji: PostAccountsAccountPersonsAddressKanji, ?addressKana: PostAccountsAccountPersonsAddressKana, ?ssnLast4: string, ?verification: PostAccountsAccountPersonsVerification) =
        ///The person's address.
        member _.Address = address
        ///The Kana variation of the person's address (Japan only).
        member _.AddressKana = addressKana
        ///The Kanji variation of the person's address (Japan only).
        member _.AddressKanji = addressKanji
        ///The person's date of birth.
        member _.Dob = dob
        ///The person's email address.
        member _.Email = email
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///The person's first name.
        member _.FirstName = firstName
        ///The Kana variation of the person's first name (Japan only).
        member _.FirstNameKana = firstNameKana
        ///The Kanji variation of the person's first name (Japan only).
        member _.FirstNameKanji = firstNameKanji
        ///The person's gender (International regulations require either "male" or "female").
        member _.Gender = gender
        ///The person's ID number, as appropriate for their country. For example, a social security number in the U.S., social insurance number in Canada, etc. Instead of the number itself, you can also provide a [PII token provided by Stripe.js](https://stripe.com/docs/stripe.js#collecting-pii-data).
        member _.IdNumber = idNumber
        ///The person's last name.
        member _.LastName = lastName
        ///The Kana variation of the person's last name (Japan only).
        member _.LastNameKana = lastNameKana
        ///The Kanji variation of the person's last name (Japan only).
        member _.LastNameKanji = lastNameKanji
        ///The person's maiden name.
        member _.MaidenName = maidenName
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///A [person token](https://stripe.com/docs/connect/account-tokens), used to securely provide details to the person.
        member _.PersonToken = personToken
        ///The person's phone number.
        member _.Phone = phone
        ///Indicates if the person or any of their representatives, family members, or other closely related persons, declares that they hold or have held an important public job or function, in any jurisdiction.
        member _.PoliticalExposure = politicalExposure
        ///The relationship that this person has with the account's legal entity.
        member _.Relationship = relationship
        ///The last four digits of the person's Social Security number (U.S. only).
        member _.SsnLast4 = ssnLast4
        ///The person's verification status.
        member _.Verification = verification

    and PostAccountsAccountPersonsAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostAccountsAccountPersonsAddressKana (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
        ///City or ward.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Block or building number.
        member _.Line1 = line1
        ///Building details.
        member _.Line2 = line2
        ///Postal code.
        member _.PostalCode = postalCode
        ///Prefecture.
        member _.State = state
        ///Town or cho-me.
        member _.Town = town

    and PostAccountsAccountPersonsAddressKanji (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
        ///City or ward.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Block or building number.
        member _.Line1 = line1
        ///Building details.
        member _.Line2 = line2
        ///Postal code.
        member _.PostalCode = postalCode
        ///Prefecture.
        member _.State = state
        ///Town or cho-me.
        member _.Town = town

    and PostAccountsAccountPersonsDobDateOfBirthSpecs (?day: int, ?month: int, ?year: int) =
        ///The day of birth, between 1 and 31.
        member _.Day = day
        ///The month of birth, between 1 and 12.
        member _.Month = month
        ///The four-digit year of birth.
        member _.Year = year

    and PostAccountsAccountPersonsRelationship (?director: bool, ?executive: bool, ?owner: bool, ?percentOwnership: Choice<decimal,string>, ?representative: bool, ?title: string) =
        ///Whether the person is a director of the account's legal entity. Currently only required for accounts in the EU. Directors are typically members of the governing board of the company, or responsible for ensuring the company meets its regulatory obligations.
        member _.Director = director
        ///Whether the person has significant responsibility to control, manage, or direct the organization.
        member _.Executive = executive
        ///Whether the person is an owner of the account’s legal entity.
        member _.Owner = owner
        ///The percent owned by the person of the account's legal entity.
        member _.PercentOwnership = percentOwnership
        ///Whether the person is authorized as the primary representative of the account. This is the person nominated by the business to provide information about themselves, and general information about the account. There can only be one representative at any given time. At the time the account is created, this person should be set to the person responsible for opening the account.
        member _.Representative = representative
        ///The person's title (e.g., CEO, Support Engineer).
        member _.Title = title

    and PostAccountsAccountPersonsVerification (?additionalDocument: PostAccountsAccountPersonsVerificationAdditionalDocument, ?document: PostAccountsAccountPersonsVerificationDocument) =
        ///A document showing address, either a passport, local ID card, or utility bill from a well-known utility company.
        member _.AdditionalDocument = additionalDocument
        ///An identifying document, either a passport or local ID card.
        member _.Document = document

    and PostAccountsAccountPersonsVerificationAdditionalDocument (?back: string, ?front: string) =
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Back = back
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Front = front

    and PostAccountsAccountPersonsVerificationDocument (?back: string, ?front: string) =
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Back = back
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Front = front

    and PostAccountsAccountPersonsPersonParams (?address: PostAccountsAccountPersonsPersonAddress, ?relationship: PostAccountsAccountPersonsPersonRelationship, ?politicalExposure: string, ?phone: string, ?personToken: string, ?metadata: Map<string, string>, ?maidenName: string, ?lastNameKanji: string, ?lastNameKana: string, ?lastName: string, ?idNumber: string, ?gender: string, ?firstNameKanji: string, ?firstNameKana: string, ?firstName: string, ?expand: string list, ?email: string, ?dob: Choice<PostAccountsAccountPersonsPersonDobDateOfBirthSpecs,string>, ?addressKanji: PostAccountsAccountPersonsPersonAddressKanji, ?addressKana: PostAccountsAccountPersonsPersonAddressKana, ?ssnLast4: string, ?verification: PostAccountsAccountPersonsPersonVerification) =
        ///The person's address.
        member _.Address = address
        ///The Kana variation of the person's address (Japan only).
        member _.AddressKana = addressKana
        ///The Kanji variation of the person's address (Japan only).
        member _.AddressKanji = addressKanji
        ///The person's date of birth.
        member _.Dob = dob
        ///The person's email address.
        member _.Email = email
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///The person's first name.
        member _.FirstName = firstName
        ///The Kana variation of the person's first name (Japan only).
        member _.FirstNameKana = firstNameKana
        ///The Kanji variation of the person's first name (Japan only).
        member _.FirstNameKanji = firstNameKanji
        ///The person's gender (International regulations require either "male" or "female").
        member _.Gender = gender
        ///The person's ID number, as appropriate for their country. For example, a social security number in the U.S., social insurance number in Canada, etc. Instead of the number itself, you can also provide a [PII token provided by Stripe.js](https://stripe.com/docs/stripe.js#collecting-pii-data).
        member _.IdNumber = idNumber
        ///The person's last name.
        member _.LastName = lastName
        ///The Kana variation of the person's last name (Japan only).
        member _.LastNameKana = lastNameKana
        ///The Kanji variation of the person's last name (Japan only).
        member _.LastNameKanji = lastNameKanji
        ///The person's maiden name.
        member _.MaidenName = maidenName
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///A [person token](https://stripe.com/docs/connect/account-tokens), used to securely provide details to the person.
        member _.PersonToken = personToken
        ///The person's phone number.
        member _.Phone = phone
        ///Indicates if the person or any of their representatives, family members, or other closely related persons, declares that they hold or have held an important public job or function, in any jurisdiction.
        member _.PoliticalExposure = politicalExposure
        ///The relationship that this person has with the account's legal entity.
        member _.Relationship = relationship
        ///The last four digits of the person's Social Security number (U.S. only).
        member _.SsnLast4 = ssnLast4
        ///The person's verification status.
        member _.Verification = verification

    and PostAccountsAccountPersonsPersonAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostAccountsAccountPersonsPersonAddressKana (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
        ///City or ward.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Block or building number.
        member _.Line1 = line1
        ///Building details.
        member _.Line2 = line2
        ///Postal code.
        member _.PostalCode = postalCode
        ///Prefecture.
        member _.State = state
        ///Town or cho-me.
        member _.Town = town

    and PostAccountsAccountPersonsPersonAddressKanji (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
        ///City or ward.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Block or building number.
        member _.Line1 = line1
        ///Building details.
        member _.Line2 = line2
        ///Postal code.
        member _.PostalCode = postalCode
        ///Prefecture.
        member _.State = state
        ///Town or cho-me.
        member _.Town = town

    and PostAccountsAccountPersonsPersonDobDateOfBirthSpecs (?day: int, ?month: int, ?year: int) =
        ///The day of birth, between 1 and 31.
        member _.Day = day
        ///The month of birth, between 1 and 12.
        member _.Month = month
        ///The four-digit year of birth.
        member _.Year = year

    and PostAccountsAccountPersonsPersonRelationship (?director: bool, ?executive: bool, ?owner: bool, ?percentOwnership: Choice<decimal,string>, ?representative: bool, ?title: string) =
        ///Whether the person is a director of the account's legal entity. Currently only required for accounts in the EU. Directors are typically members of the governing board of the company, or responsible for ensuring the company meets its regulatory obligations.
        member _.Director = director
        ///Whether the person has significant responsibility to control, manage, or direct the organization.
        member _.Executive = executive
        ///Whether the person is an owner of the account’s legal entity.
        member _.Owner = owner
        ///The percent owned by the person of the account's legal entity.
        member _.PercentOwnership = percentOwnership
        ///Whether the person is authorized as the primary representative of the account. This is the person nominated by the business to provide information about themselves, and general information about the account. There can only be one representative at any given time. At the time the account is created, this person should be set to the person responsible for opening the account.
        member _.Representative = representative
        ///The person's title (e.g., CEO, Support Engineer).
        member _.Title = title

    and PostAccountsAccountPersonsPersonVerification (?additionalDocument: PostAccountsAccountPersonsPersonVerificationAdditionalDocument, ?document: PostAccountsAccountPersonsPersonVerificationDocument) =
        ///A document showing address, either a passport, local ID card, or utility bill from a well-known utility company.
        member _.AdditionalDocument = additionalDocument
        ///An identifying document, either a passport or local ID card.
        member _.Document = document

    and PostAccountsAccountPersonsPersonVerificationAdditionalDocument (?back: string, ?front: string) =
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Back = back
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Front = front

    and PostAccountsAccountPersonsPersonVerificationDocument (?back: string, ?front: string) =
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Back = back
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Front = front

    and PostAccountsAccountRejectParams (reason: string, ?expand: string list) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///The reason for rejecting the account. Can be `fraud`, `terms_of_service`, or `other`.
        member _.Reason = reason

    and PostAccountsAccountXstripeparametersoverrideBankAccountIdParams (?accountHolderName: string, ?accountHolderType: PostAccountsAccountXstripeparametersoverrideBankAccountIdAccountHolderType, ?defaultForCurrency: bool, ?expand: string list, ?metadata: Map<string, string>) =
        ///The name of the person or business that owns the bank account.
        member _.AccountHolderName = accountHolderName
        ///The type of entity that holds the account. This can be either `individual` or `company`.
        member _.AccountHolderType = accountHolderType
        ///When set to true, this becomes the default external account for its currency.
        member _.DefaultForCurrency = defaultForCurrency
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostAccountsAccountXstripeparametersoverrideBankAccountIdAccountHolderType =
        | Company
        | Individual

    and PostAccountsAccountXstripeparametersoverrideCardIdParams (?addressCity: string, ?addressCountry: string, ?addressLine1: string, ?addressLine2: string, ?addressState: string, ?addressZip: string, ?defaultForCurrency: bool, ?expMonth: string, ?expYear: string, ?expand: string list, ?metadata: Map<string, string>, ?name: string) =
        ///City/District/Suburb/Town/Village.
        member _.AddressCity = addressCity
        ///Billing address country, if provided when creating card.
        member _.AddressCountry = addressCountry
        ///Address line 1 (Street address/PO Box/Company name).
        member _.AddressLine1 = addressLine1
        ///Address line 2 (Apartment/Suite/Unit/Building).
        member _.AddressLine2 = addressLine2
        ///State/County/Province/Region.
        member _.AddressState = addressState
        ///ZIP or postal code.
        member _.AddressZip = addressZip
        ///When set to true, this becomes the default external account for its currency.
        member _.DefaultForCurrency = defaultForCurrency
        ///Two digit number representing the card’s expiration month.
        member _.ExpMonth = expMonth
        ///Four digit number representing the card’s expiration year.
        member _.ExpYear = expYear
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Cardholder name.
        member _.Name = name

    and PostApplePayDomainsParams (domainName: string, ?expand: string list) =
        ///
        member _.DomainName = domainName
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand

    and PostApplicationFeesFeeRefundsIdParams (?expand: string list, ?metadata: Map<string, string>) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostApplicationFeesIdRefundsParams (?amount: int, ?expand: string list, ?metadata: Map<string, string>) =
        ///A positive integer, in _%s_, representing how much of this fee to refund. Can refund only up to the remaining unrefunded amount of the fee.
        member _.Amount = amount
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostBillingPortalSessionsParams (customer: string, ?expand: string list, ?returnUrl: string) =
        ///The ID of an existing customer.
        member _.Customer = customer
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///The URL to which Stripe should send customers when they click on the link to return to your website. This field is required if a default return URL has not been configured for the portal.
        member _.ReturnUrl = returnUrl

    and PostChargesParams (?amount: int, ?statementDescriptorSuffix: string, ?statementDescriptor: string, ?source: string, ?shipping: PostChargesShipping, ?receiptEmail: string, ?onBehalfOf: string, ?metadata: Map<string, string>, ?expand: string list, ?destination: PostChargesDestination, ?description: string, ?customer: string, ?currency: string, ?capture: bool, ?applicationFeeAmount: int, ?applicationFee: int, ?transferData: PostChargesTransferData, ?transferGroup: string) =
        ///Amount intended to be collected by this payment. A positive integer representing how much to charge in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal) (e.g., 100 cents to charge $1.00 or 100 to charge ¥100, a zero-decimal currency). The minimum amount is $0.50 US or [equivalent in charge currency](https://stripe.com/docs/currencies#minimum-and-maximum-charge-amounts). The amount value supports up to eight digits (e.g., a value of 99999999 for a USD charge of $999,999.99).
        member _.Amount = amount
        ///
        member _.ApplicationFee = applicationFee
        ///A fee in %s that will be applied to the charge and transferred to the application owner's Stripe account. The request must be made with an OAuth key or the `Stripe-Account` header in order to take an application fee. For more information, see the application fees [documentation](https://stripe.com/docs/connect/direct-charges#collecting-fees).
        member _.ApplicationFeeAmount = applicationFeeAmount
        ///Whether to immediately capture the charge. Defaults to `true`. When `false`, the charge issues an authorization (or pre-authorization), and will need to be [captured](https://stripe.com/docs/api#capture_charge) later. Uncaptured charges expire in _seven days_. For more information, see the [authorizing charges and settling later](https://stripe.com/docs/charges/placing-a-hold) documentation.
        member _.Capture = capture
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///The ID of an existing customer that will be charged in this request.
        member _.Customer = customer
        ///An arbitrary string which you can attach to a `Charge` object. It is displayed when in the web interface alongside the charge. Note that if you use Stripe to send automatic email receipts to your customers, your receipt emails will include the `description` of the charge(s) that they are describing.
        member _.Description = description
        ///
        member _.Destination = destination
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The Stripe account ID for which these funds are intended. Automatically set if you use the `destination` parameter. For details, see [Creating Separate Charges and Transfers](https://stripe.com/docs/connect/charges-transfers#on-behalf-of).
        member _.OnBehalfOf = onBehalfOf
        ///The email address to which this charge's [receipt](https://stripe.com/docs/dashboard/receipts) will be sent. The receipt will not be sent until the charge is paid, and no receipts will be sent for test mode charges. If this charge is for a [Customer](https://stripe.com/docs/api/customers/object), the email address specified here will override the customer's email address. If `receipt_email` is specified for a charge in live mode, a receipt will be sent regardless of your [email settings](https://dashboard.stripe.com/account/emails).
        member _.ReceiptEmail = receiptEmail
        ///Shipping information for the charge. Helps prevent fraud on charges for physical goods.
        member _.Shipping = shipping
        ///A payment source to be charged. This can be the ID of a [card](https://stripe.com/docs/api#cards) (i.e., credit or debit card), a [bank account](https://stripe.com/docs/api#bank_accounts), a [source](https://stripe.com/docs/api#sources), a [token](https://stripe.com/docs/api#tokens), or a [connected account](https://stripe.com/docs/connect/account-debits#charging-a-connected-account). For certain sources---namely, [cards](https://stripe.com/docs/api#cards), [bank accounts](https://stripe.com/docs/api#bank_accounts), and attached [sources](https://stripe.com/docs/api#sources)---you must also pass the ID of the associated customer.
        member _.Source = source
        ///For card charges, use `statement_descriptor_suffix` instead. Otherwise, you can use this value as the complete description of a charge on your customers’ statements. Must contain at least one letter, maximum 22 characters.
        member _.StatementDescriptor = statementDescriptor
        ///Provides information about the charge that customers see on their statements. Concatenated with the prefix (shortened descriptor) or statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 22 characters for the concatenated descriptor.
        member _.StatementDescriptorSuffix = statementDescriptorSuffix
        ///An optional dictionary including the account to automatically transfer to as part of a destination charge. [See the Connect documentation](https://stripe.com/docs/connect/destination-charges) for details.
        member _.TransferData = transferData
        ///A string that identifies this transaction as part of a group. For details, see [Grouping transactions](https://stripe.com/docs/connect/charges-transfers#transfer-options).
        member _.TransferGroup = transferGroup

    and PostChargesDestination (?account: string, ?amount: int) =
        ///ID of an existing, connected Stripe account.
        member _.Account = account
        ///The amount to transfer to the destination account without creating an `Application Fee` object. Cannot be combined with the `application_fee` parameter. Must be less than or equal to the charge amount.
        member _.Amount = amount

    and PostChargesShipping (?address: PostChargesShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
        ///Shipping address.
        member _.Address = address
        ///The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc.
        member _.Carrier = carrier
        ///Recipient name.
        member _.Name = name
        ///Recipient phone (including extension).
        member _.Phone = phone
        ///The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
        member _.TrackingNumber = trackingNumber

    and PostChargesShippingAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostChargesTransferData (?amount: int, ?destination: string) =
        ///The amount transferred to the destination account, if specified. By default, the entire charge amount is transferred to the destination account.
        member _.Amount = amount
        ///ID of an existing, connected Stripe account.
        member _.Destination = destination

    and PostChargesChargeParams (?customer: string, ?description: string, ?expand: string list, ?fraudDetails: PostChargesChargeFraudDetails, ?metadata: Map<string, string>, ?receiptEmail: string, ?shipping: PostChargesChargeShipping, ?transferGroup: string) =
        ///The ID of an existing customer that will be associated with this request. This field may only be updated if there is no existing associated customer with this charge.
        member _.Customer = customer
        ///An arbitrary string which you can attach to a charge object. It is displayed when in the web interface alongside the charge. Note that if you use Stripe to send automatic email receipts to your customers, your receipt emails will include the `description` of the charge(s) that they are describing.
        member _.Description = description
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///A set of key-value pairs you can attach to a charge giving information about its riskiness. If you believe a charge is fraudulent, include a `user_report` key with a value of `fraudulent`. If you believe a charge is safe, include a `user_report` key with a value of `safe`. Stripe will use the information you send to improve our fraud detection algorithms.
        member _.FraudDetails = fraudDetails
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///This is the email address that the receipt for this charge will be sent to. If this field is updated, then a new email receipt will be sent to the updated address.
        member _.ReceiptEmail = receiptEmail
        ///Shipping information for the charge. Helps prevent fraud on charges for physical goods.
        member _.Shipping = shipping
        ///A string that identifies this transaction as part of a group. `transfer_group` may only be provided if it has not been set. See the [Connect documentation](https://stripe.com/docs/connect/charges-transfers#transfer-options) for details.
        member _.TransferGroup = transferGroup

    and PostChargesChargeFraudDetails (?userReport: PostChargesChargeFraudDetailsUserReport) =
        ///Either `safe` or `fraudulent`.
        member _.UserReport = userReport

    and PostChargesChargeFraudDetailsUserReport =
        | Fraudulent
        | Safe

    and PostChargesChargeShipping (?address: PostChargesChargeShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
        ///Shipping address.
        member _.Address = address
        ///The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc.
        member _.Carrier = carrier
        ///Recipient name.
        member _.Name = name
        ///Recipient phone (including extension).
        member _.Phone = phone
        ///The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
        member _.TrackingNumber = trackingNumber

    and PostChargesChargeShippingAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostChargesChargeCaptureParams (?amount: int, ?applicationFee: int, ?applicationFeeAmount: int, ?expand: string list, ?receiptEmail: string, ?statementDescriptor: string, ?statementDescriptorSuffix: string, ?transferData: PostChargesChargeCaptureTransferData, ?transferGroup: string) =
        ///The amount to capture, which must be less than or equal to the original amount. Any additional amount will be automatically refunded.
        member _.Amount = amount
        ///An application fee to add on to this charge.
        member _.ApplicationFee = applicationFee
        ///An application fee amount to add on to this charge, which must be less than or equal to the original amount.
        member _.ApplicationFeeAmount = applicationFeeAmount
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///The email address to send this charge's receipt to. This will override the previously-specified email address for this charge, if one was set. Receipts will not be sent in test mode.
        member _.ReceiptEmail = receiptEmail
        ///For card charges, use `statement_descriptor_suffix` instead. Otherwise, you can use this value as the complete description of a charge on your customers’ statements. Must contain at least one letter, maximum 22 characters.
        member _.StatementDescriptor = statementDescriptor
        ///Provides information about the charge that customers see on their statements. Concatenated with the prefix (shortened descriptor) or statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 22 characters for the concatenated descriptor.
        member _.StatementDescriptorSuffix = statementDescriptorSuffix
        ///An optional dictionary including the account to automatically transfer to as part of a destination charge. [See the Connect documentation](https://stripe.com/docs/connect/destination-charges) for details.
        member _.TransferData = transferData
        ///A string that identifies this transaction as part of a group. `transfer_group` may only be provided if it has not been set. See the [Connect documentation](https://stripe.com/docs/connect/charges-transfers#transfer-options) for details.
        member _.TransferGroup = transferGroup

    and PostChargesChargeCaptureTransferData (?amount: int) =
        ///The amount transferred to the destination account, if specified. By default, the entire charge amount is transferred to the destination account.
        member _.Amount = amount

    and PostCheckoutSessionsParams (successUrl: string, cancelUrl: string, paymentMethodTypes: PostCheckoutSessionsPaymentMethodTypes list, ?submitType: PostCheckoutSessionsSubmitType, ?shippingAddressCollection: PostCheckoutSessionsShippingAddressCollection, ?setupIntentData: PostCheckoutSessionsSetupIntentData, ?paymentIntentData: PostCheckoutSessionsPaymentIntentData, ?mode: PostCheckoutSessionsMode, ?metadata: Map<string, string>, ?locale: PostCheckoutSessionsLocale, ?lineItems: PostCheckoutSessionsLineItems list, ?expand: string list, ?discounts: PostCheckoutSessionsDiscounts list, ?customerEmail: string, ?customer: string, ?clientReferenceId: string, ?billingAddressCollection: PostCheckoutSessionsBillingAddressCollection, ?subscriptionData: PostCheckoutSessionsSubscriptionData, ?allowPromotionCodes: bool) =
        ///Enables user redeemable promotion codes.
        member _.AllowPromotionCodes = allowPromotionCodes
        ///Specify whether Checkout should collect the customer's billing address.
        member _.BillingAddressCollection = billingAddressCollection
        ///The URL the customer will be directed to if they decide to cancel payment and return to your website.
        member _.CancelUrl = cancelUrl
        ///A unique string to reference the Checkout Session. This can be a
        ///customer ID, a cart ID, or similar, and can be used to reconcile the
        ///session with your internal systems.
        member _.ClientReferenceId = clientReferenceId
        ///ID of an existing customer, if one exists. The email stored on the
        ///customer will be used to prefill the email field on the Checkout page.
        ///If the customer changes their email on the Checkout page, the Customer
        ///object will be updated with the new email.
        ///If blank for Checkout Sessions in `payment` or `subscription` mode,
        ///Checkout will create a new customer object based on information
        ///provided during the session.
        member _.Customer = customer
        ///If provided, this value will be used when the Customer object is created.
        ///If not provided, customers will be asked to enter their email address.
        ///Use this parameter to prefill customer data if you already have an email
        ///on file. To access information about the customer once a session is
        ///complete, use the `customer` field.
        member _.CustomerEmail = customerEmail
        ///The coupon or promotion code to apply to this session. Currently, only up to one may be specified.
        member _.Discounts = discounts
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///A list of items the customer is purchasing. Use this parameter to pass one-time or recurring [Prices](https://stripe.com/docs/api/prices).
        ///One-time Prices in `subscription` mode will be on the initial invoice only.
        ///There is a maximum of 100 line items, however it is recommended to
        ///consolidate line items if there are more than a few dozen.
        member _.LineItems = lineItems
        ///The IETF language tag of the locale Checkout is displayed in. If blank or `auto`, the browser's locale is used.
        member _.Locale = locale
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The mode of the Checkout Session. Required when using prices or `setup` mode. Pass `subscription` if Checkout session includes at least one recurring item.
        member _.Mode = mode
        ///A subset of parameters to be passed to PaymentIntent creation for Checkout Sessions in `payment` mode.
        member _.PaymentIntentData = paymentIntentData
        ///A list of the types of payment methods (e.g., `card`) this Checkout session can accept.
        ///Read more about the supported payment methods and their requirements in our [payment
        ///method details guide](/docs/payments/checkout/payment-methods).
        ///If multiple payment methods are passed, Checkout will dynamically reorder them to
        ///prioritize the most relevant payment methods based on the customer's location and
        ///other characteristics.
        member _.PaymentMethodTypes = paymentMethodTypes
        ///A subset of parameters to be passed to SetupIntent creation for Checkout Sessions in `setup` mode.
        member _.SetupIntentData = setupIntentData
        ///When set, provides configuration for Checkout to collect a shipping address from a customer.
        member _.ShippingAddressCollection = shippingAddressCollection
        ///Describes the type of transaction being performed by Checkout in order to customize
        ///relevant text on the page, such as the submit button. `submit_type` can only be
        ///specified on Checkout Sessions in `payment` mode, but not Checkout Sessions
        ///in `subscription` or `setup` mode.
        member _.SubmitType = submitType
        ///A subset of parameters to be passed to subscription creation for Checkout Sessions in `subscription` mode.
        member _.SubscriptionData = subscriptionData
        ///The URL to which Stripe should send customers when payment or setup
        ///is complete.
        ///If you’d like access to the Checkout Session for the successful
        ///payment, read more about it in the guide on [fulfilling orders](https://stripe.com/docs/payments/checkout/fulfill-orders).
        member _.SuccessUrl = successUrl

    and PostCheckoutSessionsBillingAddressCollection =
        | Auto
        | Required

    and PostCheckoutSessionsLocale =
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

    and PostCheckoutSessionsMode =
        | Payment
        | Setup
        | Subscription

    and PostCheckoutSessionsSubmitType =
        | Auto
        | Book
        | Donate
        | Pay

    and PostCheckoutSessionsDiscounts (?coupon: string, ?promotionCode: string) =
        ///The ID of the coupon to apply to this session.
        member _.Coupon = coupon
        ///The ID of a promotion code to apply to this session.
        member _.PromotionCode = promotionCode

    and PostCheckoutSessionsLineItems (?amount: int, ?currency: string, ?description: string, ?images: string list, ?name: string, ?price: string, ?priceData: PostCheckoutSessionsLineItemsPriceData, ?quantity: int, ?taxRates: string list) =
        ///The amount to be collected per unit of the line item. If specified, must also pass `currency` and `name`.
        member _.Amount = amount
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies). Required if `amount` is passed.
        member _.Currency = currency
        ///The description for the line item, to be displayed on the Checkout page.
        ///If using `price` or `price_data`, will default to the name of the associated product.
        member _.Description = description
        ///A list of image URLs representing this line item. Each image can be up to 5 MB in size. If passing `price` or `price_data`, specify images on the associated product instead.
        member _.Images = images
        ///The name for the item to be displayed on the Checkout page. Required if `amount` is passed.
        member _.Name = name
        ///The ID of the [Price](https://stripe.com/docs/api/prices) or [Plan](https://stripe.com/docs/api/plans) object. One of `price`, `price_data` or `amount` is required.
        member _.Price = price
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline. One of `price`, `price_data` or `amount` is required.
        member _.PriceData = priceData
        ///The quantity of the line item being purchased.
        member _.Quantity = quantity
        ///The [tax rates](https://stripe.com/docs/api/tax_rates) which apply to this line item. This is only allowed in subscription mode.
        member _.TaxRates = taxRates

    and PostCheckoutSessionsLineItemsPriceData (?currency: string, ?product: string, ?productData: PostCheckoutSessionsLineItemsPriceDataProductData, ?recurring: PostCheckoutSessionsLineItemsPriceDataRecurring, ?unitAmount: int, ?unitAmountDecimal: string) =
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///The ID of the product that this price will belong to. One of `product` or `product_data` is required.
        member _.Product = product
        ///Data used to generate a new product object inline. One of `product` or `product_data` is required.
        member _.ProductData = productData
        ///The recurring components of a price such as `interval` and `usage_type`.
        member _.Recurring = recurring
        ///A non-negative integer in %s representing how much to charge. One of `unit_amount` or `unit_amount_decimal` is required.
        member _.UnitAmount = unitAmount
        ///Same as `unit_amount`, but accepts a decimal value in %s with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        member _.UnitAmountDecimal = unitAmountDecimal

    and PostCheckoutSessionsLineItemsPriceDataProductData (?description: string, ?images: string list, ?metadata: Map<string, string>, ?name: string) =
        ///The product's description, meant to be displayable to the customer. Use this field to optionally store a long form explanation of the product being sold for your own rendering purposes.
        member _.Description = description
        ///A list of up to 8 URLs of images for this product, meant to be displayable to the customer.
        member _.Images = images
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The product's name, meant to be displayable to the customer. Whenever this product is sold via a subscription, name will show up on associated invoice line item descriptions.
        member _.Name = name

    and PostCheckoutSessionsLineItemsPriceDataRecurring (?interval: PostCheckoutSessionsLineItemsPriceDataRecurringInterval, ?intervalCount: int) =
        ///Specifies billing frequency. Either `day`, `week`, `month` or `year`.
        member _.Interval = interval
        ///The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        member _.IntervalCount = intervalCount

    and PostCheckoutSessionsLineItemsPriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    and PostCheckoutSessionsPaymentIntentData (?applicationFeeAmount: int, ?captureMethod: PostCheckoutSessionsPaymentIntentDataCaptureMethod, ?description: string, ?metadata: Map<string, string>, ?onBehalfOf: string, ?receiptEmail: string, ?setupFutureUsage: PostCheckoutSessionsPaymentIntentDataSetupFutureUsage, ?shipping: PostCheckoutSessionsPaymentIntentDataShipping, ?statementDescriptor: string, ?statementDescriptorSuffix: string, ?transferData: PostCheckoutSessionsPaymentIntentDataTransferData, ?transferGroup: string) =
        ///The amount of the application fee (if any) that will be requested to be applied to the payment and
        ///transferred to the application owner's Stripe account. The amount of the application fee collected
        ///will be capped at the total payment amount. To use an application fee, the request must be made on
        ///behalf of another account, using the `Stripe-Account` header or an OAuth key. For more information,
        ///see the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts).
        member _.ApplicationFeeAmount = applicationFeeAmount
        ///Controls when the funds will be captured from the customer's account.
        member _.CaptureMethod = captureMethod
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        member _.Description = description
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The Stripe account ID for which these funds are intended. For details,
        ///see the PaymentIntents [use case for connected
        ///accounts](/docs/payments/connected-accounts).
        member _.OnBehalfOf = onBehalfOf
        ///Email address that the receipt for the resulting payment will be sent to. If `receipt_email` is specified for a payment in live mode, a receipt will be sent regardless of your [email settings](https://dashboard.stripe.com/account/emails).
        member _.ReceiptEmail = receiptEmail
        ///Indicates that you intend to make future payments with the payment
        ///method collected by this Checkout Session.
        ///When setting this to `off_session`, Checkout will show a notice to the
        ///customer that their payment details will be saved and used for future
        ///payments.
        ///When processing card payments, Checkout also uses `setup_future_usage`
        ///to dynamically optimize your payment flow and comply with regional
        ///legislation and network rules, such as SCA.
        member _.SetupFutureUsage = setupFutureUsage
        ///Shipping information for this payment.
        member _.Shipping = shipping
        ///Extra information about the payment. This will appear on your
        ///customer's statement when this payment succeeds in creating a charge.
        member _.StatementDescriptor = statementDescriptor
        ///Provides information about the charge that customers see on their statements. Concatenated with the
        ///prefix (shortened descriptor) or statement descriptor that’s set on the account to form the complete
        ///statement descriptor. Maximum 22 characters for the concatenated descriptor.
        member _.StatementDescriptorSuffix = statementDescriptorSuffix
        ///The parameters used to automatically create a Transfer when the payment succeeds.
        ///For more information, see the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts).
        member _.TransferData = transferData
        ///A string that identifies the resulting payment as part of a group. See the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts) for details.
        member _.TransferGroup = transferGroup

    and PostCheckoutSessionsPaymentIntentDataCaptureMethod =
        | Automatic
        | Manual

    and PostCheckoutSessionsPaymentIntentDataSetupFutureUsage =
        | OffSession
        | OnSession

    and PostCheckoutSessionsPaymentIntentDataShipping (?address: PostCheckoutSessionsPaymentIntentDataShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
        ///Shipping address.
        member _.Address = address
        ///The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc.
        member _.Carrier = carrier
        ///Recipient name.
        member _.Name = name
        ///Recipient phone (including extension).
        member _.Phone = phone
        ///The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
        member _.TrackingNumber = trackingNumber

    and PostCheckoutSessionsPaymentIntentDataShippingAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostCheckoutSessionsPaymentIntentDataTransferData (?amount: int, ?destination: string) =
        ///The amount that will be transferred automatically when a charge succeeds.
        member _.Amount = amount
        ///If specified, successful charges will be attributed to the destination
        ///account for tax reporting, and the funds from charges will be transferred
        ///to the destination account. The ID of the resulting transfer will be
        ///returned on the successful charge's `transfer` field.
        member _.Destination = destination

    and PostCheckoutSessionsPaymentMethodTypes =
        | Alipay
        | BacsDebit
        | Bancontact
        | Card
        | Eps
        | Fpx
        | Giropay
        | Grabpay
        | Ideal
        | P24
        | SepaDebit
        | Sofort

    and PostCheckoutSessionsSetupIntentData (?description: string, ?metadata: Map<string, string>, ?onBehalfOf: string) =
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        member _.Description = description
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The Stripe account for which the setup is intended.
        member _.OnBehalfOf = onBehalfOf

    and PostCheckoutSessionsShippingAddressCollection (?allowedCountries: PostCheckoutSessionsShippingAddressCollectionAllowedCountries list) =
        ///An array of two-letter ISO country codes representing which countries Checkout should provide as options for
        ///shipping locations. Unsupported country codes: `AS, CX, CC, CU, HM, IR, KP, MH, FM, NF, MP, PW, SD, SY, UM, VI`.
        member _.AllowedCountries = allowedCountries

    and PostCheckoutSessionsShippingAddressCollectionAllowedCountries =
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

    and PostCheckoutSessionsSubscriptionData (?applicationFeePercent: decimal, ?coupon: string, ?defaultTaxRates: string list, ?items: PostCheckoutSessionsSubscriptionDataItems list, ?metadata: Map<string, string>, ?trialEnd: DateTime, ?trialFromPlan: bool, ?trialPeriodDays: int) =
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice subtotal that will be transferred to the application owner's Stripe account. To use an application fee percent, the request must be made on behalf of another account, using the `Stripe-Account` header or an OAuth key. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).
        member _.ApplicationFeePercent = applicationFeePercent
        ///The ID of the coupon to apply to this subscription. A coupon applied to a subscription will only affect invoices created for that particular subscription.
        member _.Coupon = coupon
        ///The tax rates that will apply to any subscription item that does not have
        ///`tax_rates` set. Invoices created will have their `default_tax_rates` populated
        ///from the subscription.
        member _.DefaultTaxRates = defaultTaxRates
        ///A list of items, each with an attached plan, that the customer is subscribing to. Prefer using `line_items`.
        member _.Items = items
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Unix timestamp representing the end of the trial period the customer
        ///will get before being charged for the first time. Has to be at least
        ///48 hours in the future.
        member _.TrialEnd = trialEnd
        ///Indicates if a plan’s `trial_period_days` should be applied to the subscription. Setting `trial_end` on `subscription_data` is preferred. Defaults to `false`.
        member _.TrialFromPlan = trialFromPlan
        ///Integer representing the number of trial period days before the
        ///customer is charged for the first time. Has to be at least 1.
        member _.TrialPeriodDays = trialPeriodDays

    and PostCheckoutSessionsSubscriptionDataItems (?plan: string, ?quantity: int, ?taxRates: string list) =
        ///Plan ID for this item.
        member _.Plan = plan
        ///Quantity for this item.
        member _.Quantity = quantity
        ///The tax rates which apply to this item. When set, the `default_tax_rates`
        ///on `subscription_data` do not apply to this item.
        member _.TaxRates = taxRates

    and PostCouponsParams (duration: PostCouponsDuration, ?amountOff: int, ?appliesTo: PostCouponsAppliesTo, ?currency: string, ?durationInMonths: int, ?expand: string list, ?id: string, ?maxRedemptions: int, ?metadata: Map<string, string>, ?name: string, ?percentOff: decimal, ?redeemBy: DateTime) =
        ///A positive integer representing the amount to subtract from an invoice total (required if `percent_off` is not passed).
        member _.AmountOff = amountOff
        ///A hash containing directions for what this Coupon will apply discounts to.
        member _.AppliesTo = appliesTo
        ///Three-letter [ISO code for the currency](https://stripe.com/docs/currencies) of the `amount_off` parameter (required if `amount_off` is passed).
        member _.Currency = currency
        ///Specifies how long the discount will be in effect. Can be `forever`, `once`, or `repeating`.
        member _.Duration = duration
        ///Required only if `duration` is `repeating`, in which case it must be a positive integer that specifies the number of months the discount will be in effect.
        member _.DurationInMonths = durationInMonths
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Unique string of your choice that will be used to identify this coupon when applying it to a customer. If you don't want to specify a particular code, you can leave the ID blank and we'll generate a random code for you.
        member _.Id = id
        ///A positive integer specifying the number of times the coupon can be redeemed before it's no longer valid. For example, you might have a 50% off coupon that the first 20 readers of your blog can use.
        member _.MaxRedemptions = maxRedemptions
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Name of the coupon displayed to customers on, for instance invoices, or receipts. By default the `id` is shown if `name` is not set.
        member _.Name = name
        ///A positive float larger than 0, and smaller or equal to 100, that represents the discount the coupon will apply (required if `amount_off` is not passed).
        member _.PercentOff = percentOff
        ///Unix timestamp specifying the last time at which the coupon can be redeemed. After the redeem_by date, the coupon can no longer be applied to new customers.
        member _.RedeemBy = redeemBy

    and PostCouponsDuration =
        | Forever
        | Once
        | Repeating

    and PostCouponsAppliesTo (?products: string list) =
        ///An array of Product IDs that this Coupon will apply to.
        member _.Products = products

    and PostCouponsCouponParams (?expand: string list, ?metadata: Map<string, string>, ?name: string) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Name of the coupon displayed to customers on, for instance invoices, or receipts. By default the `id` is shown if `name` is not set.
        member _.Name = name

    and PostCreditNotesParams (invoice: string, ?amount: int, ?creditAmount: int, ?expand: string list, ?lines: PostCreditNotesLines list, ?memo: string, ?metadata: Map<string, string>, ?outOfBandAmount: int, ?reason: PostCreditNotesReason, ?refund: string, ?refundAmount: int) =
        ///The integer amount in %s representing the total amount of the credit note.
        member _.Amount = amount
        ///The integer amount in %s representing the amount to credit the customer's balance, which will be automatically applied to their next invoice.
        member _.CreditAmount = creditAmount
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///ID of the invoice.
        member _.Invoice = invoice
        ///Line items that make up the credit note.
        member _.Lines = lines
        ///The credit note's memo appears on the credit note PDF.
        member _.Memo = memo
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The integer amount in %s representing the amount that is credited outside of Stripe.
        member _.OutOfBandAmount = outOfBandAmount
        ///Reason for issuing this credit note, one of `duplicate`, `fraudulent`, `order_change`, or `product_unsatisfactory`
        member _.Reason = reason
        ///ID of an existing refund to link this credit note to.
        member _.Refund = refund
        ///The integer amount in %s representing the amount to refund. If set, a refund will be created for the charge associated with the invoice.
        member _.RefundAmount = refundAmount

    and PostCreditNotesReason =
        | Duplicate
        | Fraudulent
        | OrderChange
        | ProductUnsatisfactory

    and PostCreditNotesLines (?amount: int, ?description: string, ?invoiceLineItem: string, ?quantity: int, ?taxRates: Choice<string list,string>, ?``type``: PostCreditNotesLinesType, ?unitAmount: int, ?unitAmountDecimal: string) =
        ///The line item amount to credit. Only valid when `type` is `invoice_line_item` and the referenced invoice line item does not have a quantity, only an amount.
        member _.Amount = amount
        ///The description of the credit note line item. Only valid when the `type` is `custom_line_item`.
        member _.Description = description
        ///The invoice line item to credit. Only valid when the `type` is `invoice_line_item`.
        member _.InvoiceLineItem = invoiceLineItem
        ///The line item quantity to credit.
        member _.Quantity = quantity
        ///The tax rates which apply to the credit note line item. Only valid when the `type` is `custom_line_item`.
        member _.TaxRates = taxRates
        ///Type of the credit note line item, one of `invoice_line_item` or `custom_line_item`
        member _.Type = ``type``
        ///The integer unit amount in %s of the credit note line item. This `unit_amount` will be multiplied by the quantity to get the full amount to credit for this line item. Only valid when `type` is `custom_line_item`.
        member _.UnitAmount = unitAmount
        ///Same as `unit_amount`, but accepts a decimal value in %s with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        member _.UnitAmountDecimal = unitAmountDecimal

    and PostCreditNotesLinesType =
        | CustomLineItem
        | InvoiceLineItem

    and PostCreditNotesIdParams (?expand: string list, ?memo: string, ?metadata: Map<string, string>) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Credit note memo.
        member _.Memo = memo
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostCreditNotesIdVoidParams (?expand: string list) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand

    and PostCustomersParams (?address: Choice<PostCustomersAddressAddress,string>, ?source: string, ?shipping: Choice<PostCustomersShippingCustomerShipping,string>, ?promotionCode: string, ?preferredLocales: string list, ?phone: string, ?paymentMethod: string, ?nextInvoiceSequence: int, ?taxExempt: PostCustomersTaxExempt, ?name: string, ?invoiceSettings: PostCustomersInvoiceSettings, ?invoicePrefix: string, ?expand: string list, ?email: string, ?description: string, ?coupon: string, ?balance: int, ?metadata: Map<string, string>, ?taxIdData: PostCustomersTaxIdData list) =
        ///The customer's address.
        member _.Address = address
        ///An integer amount in %s that represents the customer's current balance, which affect the customer's future invoices. A negative amount represents a credit that decreases the amount due on an invoice; a positive amount increases the amount due on an invoice.
        member _.Balance = balance
        ///
        member _.Coupon = coupon
        ///An arbitrary string that you can attach to a customer object. It is displayed alongside the customer in the dashboard.
        member _.Description = description
        ///Customer's email address. It's displayed alongside the customer in your dashboard and can be useful for searching and tracking. This may be up to *512 characters*.
        member _.Email = email
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///The prefix for the customer used to generate unique invoice numbers. Must be 3–12 uppercase letters or numbers.
        member _.InvoicePrefix = invoicePrefix
        ///Default invoice settings for this customer.
        member _.InvoiceSettings = invoiceSettings
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The customer's full name or business name.
        member _.Name = name
        ///The sequence to be used on the customer's next invoice. Defaults to 1.
        member _.NextInvoiceSequence = nextInvoiceSequence
        ///
        member _.PaymentMethod = paymentMethod
        ///The customer's phone number.
        member _.Phone = phone
        ///Customer's preferred languages, ordered by preference.
        member _.PreferredLocales = preferredLocales
        ///The API ID of a promotion code to apply to the customer. The customer will have a discount applied on all recurring payments. Charges you create through the API will not have the discount.
        member _.PromotionCode = promotionCode
        ///The customer's shipping information. Appears on invoices emailed to this customer.
        member _.Shipping = shipping
        ///
        member _.Source = source
        ///The customer's tax exemption. One of `none`, `exempt`, or `reverse`.
        member _.TaxExempt = taxExempt
        ///The customer's tax IDs.
        member _.TaxIdData = taxIdData

    and PostCustomersTaxExempt =
        | Exempt
        | None'
        | Reverse

    and PostCustomersAddressAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostCustomersInvoiceSettings (?customFields: Choice<PostCustomersInvoiceSettingsCustomFields list,string>, ?defaultPaymentMethod: string, ?footer: string) =
        ///Default custom fields to be displayed on invoices for this customer. When updating, pass an empty string to remove previously-defined fields.
        member _.CustomFields = customFields
        ///ID of a payment method that's attached to the customer, to be used as the customer's default payment method for subscriptions and invoices.
        member _.DefaultPaymentMethod = defaultPaymentMethod
        ///Default footer to be displayed on invoices for this customer.
        member _.Footer = footer

    and PostCustomersInvoiceSettingsCustomFields (?name: string, ?value: string) =
        ///The name of the custom field. This may be up to 30 characters.
        member _.Name = name
        ///The value of the custom field. This may be up to 30 characters.
        member _.Value = value

    and PostCustomersShippingCustomerShipping (?address: PostCustomersShippingCustomerShippingAddress, ?name: string, ?phone: string) =
        ///Customer shipping address.
        member _.Address = address
        ///Customer name.
        member _.Name = name
        ///Customer phone (including extension).
        member _.Phone = phone

    and PostCustomersShippingCustomerShippingAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostCustomersTaxIdData (?``type``: PostCustomersTaxIdDataType, ?value: string) =
        ///Type of the tax ID, one of `ae_trn`, `au_abn`, `br_cnpj`, `br_cpf`, `ca_bn`, `ca_qst`, `ch_vat`, `cl_tin`, `es_cif`, `eu_vat`, `hk_br`, `id_npwp`, `in_gst`, `jp_cn`, `jp_rn`, `kr_brn`, `li_uid`, `mx_rfc`, `my_frp`, `my_itn`, `my_sst`, `no_vat`, `nz_gst`, `ru_inn`, `ru_kpp`, `sa_vat`, `sg_gst`, `sg_uen`, `th_vat`, `tw_vat`, `us_ein`, or `za_vat`
        member _.Type = ``type``
        ///Value of the tax ID.
        member _.Value = value

    and PostCustomersTaxIdDataType =
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
        | UsEin
        | ZaVat

    and PostCustomersCustomerParams (?address: Choice<PostCustomersCustomerAddressAddress,string>, ?source: string, ?shipping: Choice<PostCustomersCustomerShippingCustomerShipping,string>, ?promotionCode: string, ?preferredLocales: string list, ?phone: string, ?nextInvoiceSequence: int, ?name: string, ?taxExempt: PostCustomersCustomerTaxExempt, ?metadata: Map<string, string>, ?invoicePrefix: string, ?expand: string list, ?email: string, ?description: string, ?defaultSource: string, ?coupon: string, ?balance: int, ?invoiceSettings: PostCustomersCustomerInvoiceSettings, ?trialEnd: Choice<PostCustomersCustomerTrialEnd,DateTime>) =
        ///The customer's address.
        member _.Address = address
        ///An integer amount in %s that represents the customer's current balance, which affect the customer's future invoices. A negative amount represents a credit that decreases the amount due on an invoice; a positive amount increases the amount due on an invoice.
        member _.Balance = balance
        ///
        member _.Coupon = coupon
        ///If you are using payment methods created via the PaymentMethods API, see the [invoice_settings.default_payment_method](https://stripe.com/docs/api/customers/update#update_customer-invoice_settings-default_payment_method) parameter.
        ///Provide the ID of a payment source already attached to this customer to make it this customer's default payment source.
        ///If you want to add a new payment source and make it the default, see the [source](https://stripe.com/docs/api/customers/update#update_customer-source) property.
        member _.DefaultSource = defaultSource
        ///An arbitrary string that you can attach to a customer object. It is displayed alongside the customer in the dashboard.
        member _.Description = description
        ///Customer's email address. It's displayed alongside the customer in your dashboard and can be useful for searching and tracking. This may be up to *512 characters*.
        member _.Email = email
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///The prefix for the customer used to generate unique invoice numbers. Must be 3–12 uppercase letters or numbers.
        member _.InvoicePrefix = invoicePrefix
        ///Default invoice settings for this customer.
        member _.InvoiceSettings = invoiceSettings
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The customer's full name or business name.
        member _.Name = name
        ///The sequence to be used on the customer's next invoice. Defaults to 1.
        member _.NextInvoiceSequence = nextInvoiceSequence
        ///The customer's phone number.
        member _.Phone = phone
        ///Customer's preferred languages, ordered by preference.
        member _.PreferredLocales = preferredLocales
        ///The API ID of a promotion code to apply to the customer. The customer will have a discount applied on all recurring payments. Charges you create through the API will not have the discount.
        member _.PromotionCode = promotionCode
        ///The customer's shipping information. Appears on invoices emailed to this customer.
        member _.Shipping = shipping
        ///
        member _.Source = source
        ///The customer's tax exemption. One of `none`, `exempt`, or `reverse`.
        member _.TaxExempt = taxExempt
        ///Unix timestamp representing the end of the trial period the customer will get before being charged for the first time. This will always overwrite any trials that might apply via a subscribed plan. If set, trial_end will override the default trial period of the plan the customer is being subscribed to. The special value `now` can be provided to end the customer's trial immediately. Can be at most two years from `billing_cycle_anchor`.
        member _.TrialEnd = trialEnd

    and PostCustomersCustomerTaxExempt =
        | Exempt
        | None'
        | Reverse

    and PostCustomersCustomerAddressAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostCustomersCustomerInvoiceSettings (?customFields: Choice<PostCustomersCustomerInvoiceSettingsCustomFields list,string>, ?defaultPaymentMethod: string, ?footer: string) =
        ///Default custom fields to be displayed on invoices for this customer. When updating, pass an empty string to remove previously-defined fields.
        member _.CustomFields = customFields
        ///ID of a payment method that's attached to the customer, to be used as the customer's default payment method for subscriptions and invoices.
        member _.DefaultPaymentMethod = defaultPaymentMethod
        ///Default footer to be displayed on invoices for this customer.
        member _.Footer = footer

    and PostCustomersCustomerInvoiceSettingsCustomFields (?name: string, ?value: string) =
        ///The name of the custom field. This may be up to 30 characters.
        member _.Name = name
        ///The value of the custom field. This may be up to 30 characters.
        member _.Value = value

    and PostCustomersCustomerShippingCustomerShipping (?address: PostCustomersCustomerShippingCustomerShippingAddress, ?name: string, ?phone: string) =
        ///Customer shipping address.
        member _.Address = address
        ///Customer name.
        member _.Name = name
        ///Customer phone (including extension).
        member _.Phone = phone

    and PostCustomersCustomerShippingCustomerShippingAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostCustomersCustomerTrialEnd =
        | Now

    and PostCustomersCustomerBalanceTransactionsParams (amount: int, currency: string, ?description: string, ?expand: string list, ?metadata: Map<string, string>) =
        ///The integer amount in **%s** to apply to the customer's credit balance.
        member _.Amount = amount
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies). If the customer's [`currency`](https://stripe.com/docs/api/customers/object#customer_object-currency) is set, this value must match it. If the customer's `currency` is not set, it will be updated to this value.
        member _.Currency = currency
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        member _.Description = description
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostCustomersCustomerBalanceTransactionsTransactionParams (?description: string, ?expand: string list, ?metadata: Map<string, string>) =
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        member _.Description = description
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostCustomersCustomerSourcesParams (source: string, ?metadata: Map<string, string>, ?expand: string list) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Please refer to full [documentation](https://stripe.com/docs/api) instead.
        member _.Source = source

    and DeleteCustomersCustomerSourcesIdParams (?expand: string list) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand

    and PostCustomersCustomerSourcesIdParams (?accountHolderName: string, ?accountHolderType: PostCustomersCustomerSourcesIdAccountHolderType, ?addressCity: string, ?addressCountry: string, ?addressLine1: string, ?addressLine2: string, ?addressState: string, ?addressZip: string, ?expMonth: string, ?expYear: string, ?expand: string list, ?metadata: Map<string, string>, ?name: string, ?owner: PostCustomersCustomerSourcesIdOwner) =
        ///The name of the person or business that owns the bank account.
        member _.AccountHolderName = accountHolderName
        ///The type of entity that holds the account. This can be either `individual` or `company`.
        member _.AccountHolderType = accountHolderType
        ///City/District/Suburb/Town/Village.
        member _.AddressCity = addressCity
        ///Billing address country, if provided when creating card.
        member _.AddressCountry = addressCountry
        ///Address line 1 (Street address/PO Box/Company name).
        member _.AddressLine1 = addressLine1
        ///Address line 2 (Apartment/Suite/Unit/Building).
        member _.AddressLine2 = addressLine2
        ///State/County/Province/Region.
        member _.AddressState = addressState
        ///ZIP or postal code.
        member _.AddressZip = addressZip
        ///Two digit number representing the card’s expiration month.
        member _.ExpMonth = expMonth
        ///Four digit number representing the card’s expiration year.
        member _.ExpYear = expYear
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Cardholder name.
        member _.Name = name
        ///
        member _.Owner = owner

    and PostCustomersCustomerSourcesIdAccountHolderType =
        | Company
        | Individual

    and PostCustomersCustomerSourcesIdOwner (?address: PostCustomersCustomerSourcesIdOwnerAddress, ?email: string, ?name: string, ?phone: string) =
        ///Owner's address.
        member _.Address = address
        ///Owner's email address.
        member _.Email = email
        ///Owner's full name.
        member _.Name = name
        ///Owner's phone number.
        member _.Phone = phone

    and PostCustomersCustomerSourcesIdOwnerAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostCustomersCustomerSourcesIdVerifyParams (?amounts: int list, ?expand: string list) =
        ///Two positive integers, in *cents*, equal to the values of the microdeposits sent to the bank account.
        member _.Amounts = amounts
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand

    and PostCustomersCustomerTaxIdsParams (``type``: PostCustomersCustomerTaxIdsType, value: string, ?expand: string list) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Type of the tax ID, one of `ae_trn`, `au_abn`, `br_cnpj`, `br_cpf`, `ca_bn`, `ca_qst`, `ch_vat`, `cl_tin`, `es_cif`, `eu_vat`, `hk_br`, `id_npwp`, `in_gst`, `jp_cn`, `jp_rn`, `kr_brn`, `li_uid`, `mx_rfc`, `my_frp`, `my_itn`, `my_sst`, `no_vat`, `nz_gst`, `ru_inn`, `ru_kpp`, `sa_vat`, `sg_gst`, `sg_uen`, `th_vat`, `tw_vat`, `us_ein`, or `za_vat`
        member _.Type = ``type``
        ///Value of the tax ID.
        member _.Value = value

    and PostCustomersCustomerTaxIdsType =
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
        | UsEin
        | ZaVat

    and PostCustomersCustomerXstripeparametersoverrideBankAccountsIdParams (?accountHolderName: string, ?accountHolderType: PostCustomersCustomerXstripeparametersoverrideBankAccountsIdAccountHolderType, ?expand: string list, ?metadata: Map<string, string>) =
        ///The name of the person or business that owns the bank account.
        member _.AccountHolderName = accountHolderName
        ///The type of entity that holds the account. This can be either `individual` or `company`.
        member _.AccountHolderType = accountHolderType
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostCustomersCustomerXstripeparametersoverrideBankAccountsIdAccountHolderType =
        | Company
        | Individual

    and PostCustomersCustomerXstripeparametersoverrideCardsIdParams (?addressCity: string, ?addressCountry: string, ?addressLine1: string, ?addressLine2: string, ?addressState: string, ?addressZip: string, ?expMonth: string, ?expYear: string, ?expand: string list, ?metadata: Map<string, string>, ?name: string) =
        ///City/District/Suburb/Town/Village.
        member _.AddressCity = addressCity
        ///Billing address country, if provided when creating card.
        member _.AddressCountry = addressCountry
        ///Address line 1 (Street address/PO Box/Company name).
        member _.AddressLine1 = addressLine1
        ///Address line 2 (Apartment/Suite/Unit/Building).
        member _.AddressLine2 = addressLine2
        ///State/County/Province/Region.
        member _.AddressState = addressState
        ///ZIP or postal code.
        member _.AddressZip = addressZip
        ///Two digit number representing the card’s expiration month.
        member _.ExpMonth = expMonth
        ///Four digit number representing the card’s expiration year.
        member _.ExpYear = expYear
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Cardholder name.
        member _.Name = name

    and PostDisputesDisputeParams (?evidence: PostDisputesDisputeEvidence, ?expand: string list, ?metadata: Map<string, string>, ?submit: bool) =
        ///Evidence to upload, to respond to a dispute. Updating any field in the hash will submit all fields in the hash for review. The combined character count of all fields is limited to 150,000.
        member _.Evidence = evidence
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Whether to immediately submit evidence to the bank. If `false`, evidence is staged on the dispute. Staged evidence is visible in the API and Dashboard, and can be submitted to the bank by making another request with this attribute set to `true` (the default).
        member _.Submit = submit

    and PostDisputesDisputeEvidence (?accessActivityLog: string, ?shippingTrackingNumber: string, ?shippingDocumentation: string, ?shippingDate: string, ?shippingCarrier: string, ?shippingAddress: string, ?serviceDocumentation: string, ?serviceDate: string, ?refundRefusalExplanation: string, ?refundPolicyDisclosure: string, ?refundPolicy: string, ?receipt: string, ?uncategorizedFile: string, ?productDescription: string, ?duplicateChargeExplanation: string, ?duplicateChargeDocumentation: string, ?customerSignature: string, ?customerPurchaseIp: string, ?customerName: string, ?customerEmailAddress: string, ?customerCommunication: string, ?cancellationRebuttal: string, ?cancellationPolicyDisclosure: string, ?cancellationPolicy: string, ?billingAddress: string, ?duplicateChargeId: string, ?uncategorizedText: string) =
        ///Any server or activity logs showing proof that the customer accessed or downloaded the purchased digital product. This information should include IP addresses, corresponding timestamps, and any detailed recorded activity. Has a maximum character count of 20,000.
        member _.AccessActivityLog = accessActivityLog
        ///The billing address provided by the customer.
        member _.BillingAddress = billingAddress
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Your subscription cancellation policy, as shown to the customer.
        member _.CancellationPolicy = cancellationPolicy
        ///An explanation of how and when the customer was shown your refund policy prior to purchase. Has a maximum character count of 20,000.
        member _.CancellationPolicyDisclosure = cancellationPolicyDisclosure
        ///A justification for why the customer's subscription was not canceled. Has a maximum character count of 20,000.
        member _.CancellationRebuttal = cancellationRebuttal
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Any communication with the customer that you feel is relevant to your case. Examples include emails proving that the customer received the product or service, or demonstrating their use of or satisfaction with the product or service.
        member _.CustomerCommunication = customerCommunication
        ///The email address of the customer.
        member _.CustomerEmailAddress = customerEmailAddress
        ///The name of the customer.
        member _.CustomerName = customerName
        ///The IP address that the customer used when making the purchase.
        member _.CustomerPurchaseIp = customerPurchaseIp
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) A relevant document or contract showing the customer's signature.
        member _.CustomerSignature = customerSignature
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Documentation for the prior charge that can uniquely identify the charge, such as a receipt, shipping label, work order, etc. This document should be paired with a similar document from the disputed payment that proves the two payments are separate.
        member _.DuplicateChargeDocumentation = duplicateChargeDocumentation
        ///An explanation of the difference between the disputed charge versus the prior charge that appears to be a duplicate. Has a maximum character count of 20,000.
        member _.DuplicateChargeExplanation = duplicateChargeExplanation
        ///The Stripe ID for the prior charge which appears to be a duplicate of the disputed charge.
        member _.DuplicateChargeId = duplicateChargeId
        ///A description of the product or service that was sold. Has a maximum character count of 20,000.
        member _.ProductDescription = productDescription
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Any receipt or message sent to the customer notifying them of the charge.
        member _.Receipt = receipt
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Your refund policy, as shown to the customer.
        member _.RefundPolicy = refundPolicy
        ///Documentation demonstrating that the customer was shown your refund policy prior to purchase. Has a maximum character count of 20,000.
        member _.RefundPolicyDisclosure = refundPolicyDisclosure
        ///A justification for why the customer is not entitled to a refund. Has a maximum character count of 20,000.
        member _.RefundRefusalExplanation = refundRefusalExplanation
        ///The date on which the customer received or began receiving the purchased service, in a clear human-readable format.
        member _.ServiceDate = serviceDate
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Documentation showing proof that a service was provided to the customer. This could include a copy of a signed contract, work order, or other form of written agreement.
        member _.ServiceDocumentation = serviceDocumentation
        ///The address to which a physical product was shipped. You should try to include as complete address information as possible.
        member _.ShippingAddress = shippingAddress
        ///The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc. If multiple carriers were used for this purchase, please separate them with commas.
        member _.ShippingCarrier = shippingCarrier
        ///The date on which a physical product began its route to the shipping address, in a clear human-readable format.
        member _.ShippingDate = shippingDate
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Documentation showing proof that a product was shipped to the customer at the same address the customer provided to you. This could include a copy of the shipment receipt, shipping label, etc. It should show the customer's full shipping address, if possible.
        member _.ShippingDocumentation = shippingDocumentation
        ///The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
        member _.ShippingTrackingNumber = shippingTrackingNumber
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Any additional evidence or statements.
        member _.UncategorizedFile = uncategorizedFile
        ///Any additional evidence or statements. Has a maximum character count of 20,000.
        member _.UncategorizedText = uncategorizedText

    and PostDisputesDisputeCloseParams (?expand: string list) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand

    and PostEphemeralKeysParams (?customer: string, ?expand: string list, ?issuingCard: string) =
        ///The ID of the Customer you'd like to modify using the resulting ephemeral key.
        member _.Customer = customer
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///The ID of the Issuing Card you'd like to access using the resulting ephemeral key.
        member _.IssuingCard = issuingCard

    and DeleteEphemeralKeysKeyParams (?expand: string list) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand

    and PostFileLinksParams (file: string, ?expand: string list, ?expiresAt: DateTime, ?metadata: Map<string, string>) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///A future timestamp after which the link will no longer be usable.
        member _.ExpiresAt = expiresAt
        ///The ID of the file. The file's `purpose` must be one of the following: `business_icon`, `business_logo`, `customer_signature`, `dispute_evidence`, `finance_report_run`, `pci_document`, `sigma_scheduled_query`, or `tax_document_user_upload`.
        member _.File = file
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostFileLinksLinkParams (?expand: string list, ?expiresAt: Choice<PostFileLinksLinkExpiresAt,DateTime,string>, ?metadata: Map<string, string>) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///A future timestamp after which the link will no longer be usable, or `now` to expire the link immediately.
        member _.ExpiresAt = expiresAt
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostFileLinksLinkExpiresAt =
        | Now

    and PostFilesParams (file: string, purpose: PostFilesPurpose, ?expand: string list, ?fileLinkData: PostFilesFileLinkData) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///A file to upload. The file should follow the specifications of RFC 2388 (which defines file transfers for the `multipart/form-data` protocol).
        member _.File = file
        ///Optional parameters to automatically create a [file link](https://stripe.com/docs/api#file_links) for the newly created file.
        member _.FileLinkData = fileLinkData
        ///The [purpose](https://stripe.com/docs/file-upload#uploading-a-file) of the uploaded file.
        member _.Purpose = purpose

    and PostFilesPurpose =
        | AdditionalVerification
        | BusinessIcon
        | BusinessLogo
        | CustomerSignature
        | DisputeEvidence
        | IdentityDocument
        | PciDocument
        | TaxDocumentUserUpload

    and PostFilesFileLinkData (?create: bool, ?expiresAt: DateTime, ?metadata: Map<string, string>) =
        ///Set this to `true` to create a file link for the newly created file. Creating a link is only possible when the file's `purpose` is one of the following: `business_icon`, `business_logo`, `customer_signature`, `dispute_evidence`, `pci_document`, or `tax_document_user_upload`.
        member _.Create = create
        ///A future timestamp after which the link will no longer be usable.
        member _.ExpiresAt = expiresAt
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostInvoiceitemsParams (customer: string, ?amount: int, ?taxRates: string list, ?subscription: string, ?quantity: int, ?priceData: PostInvoiceitemsPriceData, ?price: string, ?period: PostInvoiceitemsPeriod, ?metadata: Map<string, string>, ?invoice: string, ?expand: string list, ?discounts: Choice<PostInvoiceitemsDiscounts list,string>, ?discountable: bool, ?description: string, ?currency: string, ?unitAmount: int, ?unitAmountDecimal: string) =
        ///The integer amount in %s of the charge to be applied to the upcoming invoice. Passing in a negative `amount` will reduce the `amount_due` on the invoice.
        member _.Amount = amount
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///The ID of the customer who will be billed when this invoice item is billed.
        member _.Customer = customer
        ///An arbitrary string which you can attach to the invoice item. The description is displayed in the invoice for easy tracking.
        member _.Description = description
        ///Controls whether discounts apply to this invoice item. Defaults to false for prorations or negative invoice items, and true for all other invoice items.
        member _.Discountable = discountable
        ///The coupons to redeem into discounts for the invoice item or invoice line item.
        member _.Discounts = discounts
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///The ID of an existing invoice to add this invoice item to. When left blank, the invoice item will be added to the next upcoming scheduled invoice. This is useful when adding invoice items in response to an invoice.created webhook. You can only add invoice items to draft invoices and there is a maximum of 250 items per invoice.
        member _.Invoice = invoice
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The period associated with this invoice item.
        member _.Period = period
        ///The ID of the price object.
        member _.Price = price
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline.
        member _.PriceData = priceData
        ///Non-negative integer. The quantity of units for the invoice item.
        member _.Quantity = quantity
        ///The ID of a subscription to add this invoice item to. When left blank, the invoice item will be be added to the next upcoming scheduled invoice. When set, scheduled invoices for subscriptions other than the specified subscription will ignore the invoice item. Use this when you want to express that an invoice item has been accrued within the context of a particular subscription.
        member _.Subscription = subscription
        ///The tax rates which apply to the invoice item. When set, the `default_tax_rates` on the invoice do not apply to this invoice item.
        member _.TaxRates = taxRates
        ///The integer unit amount in %s of the charge to be applied to the upcoming invoice. This `unit_amount` will be multiplied by the quantity to get the full amount. Passing in a negative `unit_amount` will reduce the `amount_due` on the invoice.
        member _.UnitAmount = unitAmount
        ///Same as `unit_amount`, but accepts a decimal value in %s with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        member _.UnitAmountDecimal = unitAmountDecimal

    and PostInvoiceitemsDiscounts (?coupon: string, ?discount: string) =
        ///ID of the coupon to create a new discount for.
        member _.Coupon = coupon
        ///ID of an existing discount on the object (or one of its ancestors) to reuse.
        member _.Discount = discount

    and PostInvoiceitemsPeriod (?``end``: DateTime, ?start: DateTime) =
        ///The end of the period, which must be greater than or equal to the start.
        member _.End = ``end``
        ///The start of the period.
        member _.Start = start

    and PostInvoiceitemsPriceData (?currency: string, ?product: string, ?unitAmount: int, ?unitAmountDecimal: string) =
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///The ID of the product that this price will belong to.
        member _.Product = product
        ///A positive integer in %s (or 0 for a free price) representing how much to charge.
        member _.UnitAmount = unitAmount
        ///Same as `unit_amount`, but accepts a decimal value in %s with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        member _.UnitAmountDecimal = unitAmountDecimal

    and PostInvoiceitemsInvoiceitemParams (?amount: int, ?description: string, ?discountable: bool, ?discounts: Choice<PostInvoiceitemsInvoiceitemDiscounts list,string>, ?expand: string list, ?metadata: Map<string, string>, ?period: PostInvoiceitemsInvoiceitemPeriod, ?price: string, ?priceData: PostInvoiceitemsInvoiceitemPriceData, ?quantity: int, ?taxRates: Choice<string list,string>, ?unitAmount: int, ?unitAmountDecimal: string) =
        ///The integer amount in %s of the charge to be applied to the upcoming invoice. If you want to apply a credit to the customer's account, pass a negative amount.
        member _.Amount = amount
        ///An arbitrary string which you can attach to the invoice item. The description is displayed in the invoice for easy tracking.
        member _.Description = description
        ///Controls whether discounts apply to this invoice item. Defaults to false for prorations or negative invoice items, and true for all other invoice items. Cannot be set to true for prorations.
        member _.Discountable = discountable
        ///The coupons & existing discounts which apply to the invoice item or invoice line item. Item discounts are applied before invoice discounts. Pass an empty string to remove previously-defined discounts.
        member _.Discounts = discounts
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The period associated with this invoice item.
        member _.Period = period
        ///The ID of the price object.
        member _.Price = price
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline.
        member _.PriceData = priceData
        ///Non-negative integer. The quantity of units for the invoice item.
        member _.Quantity = quantity
        ///The tax rates which apply to the invoice item. When set, the `default_tax_rates` on the invoice do not apply to this invoice item. Pass an empty string to remove previously-defined tax rates.
        member _.TaxRates = taxRates
        ///The integer unit amount in %s of the charge to be applied to the upcoming invoice. This unit_amount will be multiplied by the quantity to get the full amount. If you want to apply a credit to the customer's account, pass a negative unit_amount.
        member _.UnitAmount = unitAmount
        ///Same as `unit_amount`, but accepts a decimal value in %s with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        member _.UnitAmountDecimal = unitAmountDecimal

    and PostInvoiceitemsInvoiceitemDiscounts (?coupon: string, ?discount: string) =
        ///ID of the coupon to create a new discount for.
        member _.Coupon = coupon
        ///ID of an existing discount on the object (or one of its ancestors) to reuse.
        member _.Discount = discount

    and PostInvoiceitemsInvoiceitemPeriod (?``end``: DateTime, ?start: DateTime) =
        ///The end of the period, which must be greater than or equal to the start.
        member _.End = ``end``
        ///The start of the period.
        member _.Start = start

    and PostInvoiceitemsInvoiceitemPriceData (?currency: string, ?product: string, ?unitAmount: int, ?unitAmountDecimal: string) =
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///The ID of the product that this price will belong to.
        member _.Product = product
        ///A positive integer in %s (or 0 for a free price) representing how much to charge.
        member _.UnitAmount = unitAmount
        ///Same as `unit_amount`, but accepts a decimal value in %s with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        member _.UnitAmountDecimal = unitAmountDecimal

    and PostInvoicesParams (customer: string, ?accountTaxIds: Choice<string list,string>, ?statementDescriptor: string, ?metadata: Map<string, string>, ?footer: string, ?expand: string list, ?dueDate: DateTime, ?discounts: Choice<PostInvoicesDiscounts list,string>, ?description: string, ?defaultTaxRates: string list, ?defaultSource: string, ?defaultPaymentMethod: string, ?daysUntilDue: int, ?customFields: Choice<PostInvoicesCustomFields list,string>, ?collectionMethod: PostInvoicesCollectionMethod, ?autoAdvance: bool, ?applicationFeeAmount: int, ?subscription: string, ?transferData: PostInvoicesTransferData) =
        ///The account tax IDs associated with the invoice. Only editable when the invoice is a draft.
        member _.AccountTaxIds = accountTaxIds
        ///A fee in %s that will be applied to the invoice and transferred to the application owner's Stripe account. The request must be made with an OAuth key or the Stripe-Account header in order to take an application fee. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#invoices).
        member _.ApplicationFeeAmount = applicationFeeAmount
        ///Controls whether Stripe will perform [automatic collection](https://stripe.com/docs/billing/invoices/workflow/#auto_advance) of the invoice. When `false`, the invoice's state will not automatically advance without an explicit action.
        member _.AutoAdvance = autoAdvance
        ///Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay this invoice using the default source attached to the customer. When sending an invoice, Stripe will email this invoice to the customer with payment instructions. Defaults to `charge_automatically`.
        member _.CollectionMethod = collectionMethod
        ///A list of up to 4 custom fields to be displayed on the invoice.
        member _.CustomFields = customFields
        ///The ID of the customer who will be billed.
        member _.Customer = customer
        ///The number of days from when the invoice is created until it is due. Valid only for invoices where `collection_method=send_invoice`.
        member _.DaysUntilDue = daysUntilDue
        ///ID of the default payment method for the invoice. It must belong to the customer associated with the invoice. If not set, defaults to the subscription's default payment method, if any, or to the default payment method in the customer's invoice settings.
        member _.DefaultPaymentMethod = defaultPaymentMethod
        ///ID of the default payment source for the invoice. It must belong to the customer associated with the invoice and be in a chargeable state. If not set, defaults to the subscription's default source, if any, or to the customer's default source.
        member _.DefaultSource = defaultSource
        ///The tax rates that will apply to any line item that does not have `tax_rates` set.
        member _.DefaultTaxRates = defaultTaxRates
        ///An arbitrary string attached to the object. Often useful for displaying to users. Referenced as 'memo' in the Dashboard.
        member _.Description = description
        ///The coupons to redeem into discounts for the invoice. If not specified, inherits the discount from the invoice's customer. Pass an empty string to avoid inheriting any discounts.
        member _.Discounts = discounts
        ///The date on which payment for this invoice is due. Valid only for invoices where `collection_method=send_invoice`.
        member _.DueDate = dueDate
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Footer to be displayed on the invoice.
        member _.Footer = footer
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Extra information about a charge for the customer's credit card statement. It must contain at least one letter. If not specified and this invoice is part of a subscription, the default `statement_descriptor` will be set to the first subscription item's product's `statement_descriptor`.
        member _.StatementDescriptor = statementDescriptor
        ///The ID of the subscription to invoice, if any. If not set, the created invoice will include all pending invoice items for the customer. If set, the created invoice will only include pending invoice items for that subscription and pending invoice items not associated with any subscription. The subscription's billing cycle and regular subscription events won't be affected.
        member _.Subscription = subscription
        ///If specified, the funds from the invoice will be transferred to the destination and the ID of the resulting transfer will be found on the invoice's charge.
        member _.TransferData = transferData

    and PostInvoicesCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    and PostInvoicesCustomFields (?name: string, ?value: string) =
        ///The name of the custom field. This may be up to 30 characters.
        member _.Name = name
        ///The value of the custom field. This may be up to 30 characters.
        member _.Value = value

    and PostInvoicesDiscounts (?coupon: string, ?discount: string) =
        ///ID of the coupon to create a new discount for.
        member _.Coupon = coupon
        ///ID of an existing discount on the object (or one of its ancestors) to reuse.
        member _.Discount = discount

    and PostInvoicesTransferData (?amount: int, ?destination: string) =
        ///The amount that will be transferred automatically when the invoice is paid. If no amount is set, the full amount is transferred.
        member _.Amount = amount
        ///ID of an existing, connected Stripe account.
        member _.Destination = destination

    and PostInvoicesInvoiceParams (?accountTaxIds: Choice<string list,string>, ?metadata: Map<string, string>, ?footer: string, ?expand: string list, ?dueDate: DateTime, ?discounts: Choice<PostInvoicesInvoiceDiscounts list,string>, ?description: string, ?statementDescriptor: string, ?defaultTaxRates: Choice<string list,string>, ?defaultPaymentMethod: string, ?daysUntilDue: int, ?customFields: Choice<PostInvoicesInvoiceCustomFields list,string>, ?collectionMethod: PostInvoicesInvoiceCollectionMethod, ?autoAdvance: bool, ?applicationFeeAmount: int, ?defaultSource: string, ?transferData: Choice<PostInvoicesInvoiceTransferDataTransferDataSpecs,string>) =
        ///The account tax IDs associated with the invoice. Only editable when the invoice is a draft.
        member _.AccountTaxIds = accountTaxIds
        ///A fee in %s that will be applied to the invoice and transferred to the application owner's Stripe account. The request must be made with an OAuth key or the Stripe-Account header in order to take an application fee. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#invoices).
        member _.ApplicationFeeAmount = applicationFeeAmount
        ///Controls whether Stripe will perform [automatic collection](https://stripe.com/docs/billing/invoices/workflow/#auto_advance) of the invoice.
        member _.AutoAdvance = autoAdvance
        ///Either `charge_automatically` or `send_invoice`. This field can be updated only on `draft` invoices.
        member _.CollectionMethod = collectionMethod
        ///A list of up to 4 custom fields to be displayed on the invoice. If a value for `custom_fields` is specified, the list specified will replace the existing custom field list on this invoice. Pass an empty string to remove previously-defined fields.
        member _.CustomFields = customFields
        ///The number of days from which the invoice is created until it is due. Only valid for invoices where `collection_method=send_invoice`. This field can only be updated on `draft` invoices.
        member _.DaysUntilDue = daysUntilDue
        ///ID of the default payment method for the invoice. It must belong to the customer associated with the invoice. If not set, defaults to the subscription's default payment method, if any, or to the default payment method in the customer's invoice settings.
        member _.DefaultPaymentMethod = defaultPaymentMethod
        ///ID of the default payment source for the invoice. It must belong to the customer associated with the invoice and be in a chargeable state. If not set, defaults to the subscription's default source, if any, or to the customer's default source.
        member _.DefaultSource = defaultSource
        ///The tax rates that will apply to any line item that does not have `tax_rates` set. Pass an empty string to remove previously-defined tax rates.
        member _.DefaultTaxRates = defaultTaxRates
        ///An arbitrary string attached to the object. Often useful for displaying to users. Referenced as 'memo' in the Dashboard.
        member _.Description = description
        ///The discounts that will apply to the invoice. Pass an empty string to remove previously-defined discounts.
        member _.Discounts = discounts
        ///The date on which payment for this invoice is due. Only valid for invoices where `collection_method=send_invoice`. This field can only be updated on `draft` invoices.
        member _.DueDate = dueDate
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Footer to be displayed on the invoice.
        member _.Footer = footer
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Extra information about a charge for the customer's credit card statement. It must contain at least one letter. If not specified and this invoice is part of a subscription, the default `statement_descriptor` will be set to the first subscription item's product's `statement_descriptor`.
        member _.StatementDescriptor = statementDescriptor
        ///If specified, the funds from the invoice will be transferred to the destination and the ID of the resulting transfer will be found on the invoice's charge. This will be unset if you POST an empty value.
        member _.TransferData = transferData

    and PostInvoicesInvoiceCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    and PostInvoicesInvoiceCustomFields (?name: string, ?value: string) =
        ///The name of the custom field. This may be up to 30 characters.
        member _.Name = name
        ///The value of the custom field. This may be up to 30 characters.
        member _.Value = value

    and PostInvoicesInvoiceDiscounts (?coupon: string, ?discount: string) =
        ///ID of the coupon to create a new discount for.
        member _.Coupon = coupon
        ///ID of an existing discount on the object (or one of its ancestors) to reuse.
        member _.Discount = discount

    and PostInvoicesInvoiceTransferDataTransferDataSpecs (?amount: int, ?destination: string) =
        ///The amount that will be transferred automatically when the invoice is paid. If no amount is set, the full amount is transferred.
        member _.Amount = amount
        ///ID of an existing, connected Stripe account.
        member _.Destination = destination

    and PostInvoicesInvoiceFinalizeParams (?autoAdvance: bool, ?expand: string list) =
        ///Controls whether Stripe will perform [automatic collection](https://stripe.com/docs/billing/invoices/workflow/#auto_advance) of the invoice. When `false`, the invoice's state will not automatically advance without an explicit action.
        member _.AutoAdvance = autoAdvance
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand

    and PostInvoicesInvoiceMarkUncollectibleParams (?expand: string list) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand

    and PostInvoicesInvoicePayParams (?expand: string list, ?forgive: bool, ?offSession: bool, ?paidOutOfBand: bool, ?paymentMethod: string, ?source: string) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///In cases where the source used to pay the invoice has insufficient funds, passing `forgive=true` controls whether a charge should be attempted for the full amount available on the source, up to the amount to fully pay the invoice. This effectively forgives the difference between the amount available on the source and the amount due. 
        ///Passing `forgive=false` will fail the charge if the source hasn't been pre-funded with the right amount. An example for this case is with ACH Credit Transfers and wires: if the amount wired is less than the amount due by a small amount, you might want to forgive the difference. Defaults to `false`.
        member _.Forgive = forgive
        ///Indicates if a customer is on or off-session while an invoice payment is attempted. Defaults to `true` (off-session).
        member _.OffSession = offSession
        ///Boolean representing whether an invoice is paid outside of Stripe. This will result in no charge being made. Defaults to `false`.
        member _.PaidOutOfBand = paidOutOfBand
        ///A PaymentMethod to be charged. The PaymentMethod must be the ID of a PaymentMethod belonging to the customer associated with the invoice being paid.
        member _.PaymentMethod = paymentMethod
        ///A payment source to be charged. The source must be the ID of a source belonging to the customer associated with the invoice being paid.
        member _.Source = source

    and PostInvoicesInvoiceSendParams (?expand: string list) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand

    and PostInvoicesInvoiceVoidParams (?expand: string list) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand

    and PostIssuingAuthorizationsAuthorizationParams (?expand: string list, ?metadata: Map<string, string>) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostIssuingAuthorizationsAuthorizationApproveParams (?amount: int, ?expand: string list, ?metadata: Map<string, string>) =
        ///If the authorization's `pending_request.is_amount_controllable` property is `true`, you may provide this value to control how much to hold for the authorization. Must be positive (use [`decline`](https://stripe.com/docs/api/issuing/authorizations/decline) to decline an authorization request).
        member _.Amount = amount
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostIssuingAuthorizationsAuthorizationDeclineParams (?expand: string list, ?metadata: Map<string, string>) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostIssuingCardholdersParams (billing: PostIssuingCardholdersBilling, name: string, ``type``: PostIssuingCardholdersType, ?company: PostIssuingCardholdersCompany, ?email: string, ?expand: string list, ?individual: PostIssuingCardholdersIndividual, ?metadata: Map<string, string>, ?phoneNumber: string, ?spendingControls: PostIssuingCardholdersSpendingControls, ?status: PostIssuingCardholdersStatus) =
        ///The cardholder's billing address.
        member _.Billing = billing
        ///Additional information about a `company` cardholder.
        member _.Company = company
        ///The cardholder's email address.
        member _.Email = email
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Additional information about an `individual` cardholder.
        member _.Individual = individual
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The cardholder's name. This will be printed on cards issued to them.
        member _.Name = name
        ///The cardholder's phone number. This will be transformed to [E.164](https://en.wikipedia.org/wiki/E.164) if it is not provided in that format already.
        member _.PhoneNumber = phoneNumber
        ///Rules that control spending across this cardholder's cards. Refer to our [documentation](https://stripe.com/docs/issuing/controls/spending-controls) for more details.
        member _.SpendingControls = spendingControls
        ///Specifies whether to permit authorizations on this cardholder's cards. Defaults to `active`.
        member _.Status = status
        ///One of `individual` or `company`.
        member _.Type = ``type``

    and PostIssuingCardholdersStatus =
        | Active
        | Inactive

    and PostIssuingCardholdersType =
        | Company
        | Individual

    and PostIssuingCardholdersBilling (?address: PostIssuingCardholdersBillingAddress) =
        ///The cardholder’s billing address.
        member _.Address = address

    and PostIssuingCardholdersBillingAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostIssuingCardholdersCompany (?taxId: string) =
        ///The entity's business ID number.
        member _.TaxId = taxId

    and PostIssuingCardholdersIndividual (?dob: PostIssuingCardholdersIndividualDob, ?firstName: string, ?lastName: string, ?verification: PostIssuingCardholdersIndividualVerification) =
        ///The date of birth of this cardholder.
        member _.Dob = dob
        ///The first name of this cardholder.
        member _.FirstName = firstName
        ///The last name of this cardholder.
        member _.LastName = lastName
        ///Government-issued ID document for this cardholder.
        member _.Verification = verification

    and PostIssuingCardholdersIndividualDob (?day: int, ?month: int, ?year: int) =
        ///The day of birth, between 1 and 31.
        member _.Day = day
        ///The month of birth, between 1 and 12.
        member _.Month = month
        ///The four-digit year of birth.
        member _.Year = year

    and PostIssuingCardholdersIndividualVerification (?document: PostIssuingCardholdersIndividualVerificationDocument) =
        ///An identifying document, either a passport or local ID card.
        member _.Document = document

    and PostIssuingCardholdersIndividualVerificationDocument (?back: string, ?front: string) =
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`.
        member _.Back = back
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`.
        member _.Front = front

    and PostIssuingCardholdersSpendingControls (?allowedCategories: PostIssuingCardholdersSpendingControlsAllowedCategories list, ?blockedCategories: PostIssuingCardholdersSpendingControlsBlockedCategories list, ?spendingLimits: PostIssuingCardholdersSpendingControlsSpendingLimits list, ?spendingLimitsCurrency: string) =
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) of authorizations to allow. All other categories will be blocked. Cannot be set with `blocked_categories`.
        member _.AllowedCategories = allowedCategories
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) of authorizations to decline. All other categories will be allowed. Cannot be set with `allowed_categories`.
        member _.BlockedCategories = blockedCategories
        ///Limit spending with amount-based rules that apply across this cardholder's cards.
        member _.SpendingLimits = spendingLimits
        ///Currency of amounts within `spending_limits`. Defaults to your merchant country's currency.
        member _.SpendingLimitsCurrency = spendingLimitsCurrency

    and PostIssuingCardholdersSpendingControlsAllowedCategories =
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

    and PostIssuingCardholdersSpendingControlsBlockedCategories =
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

    and PostIssuingCardholdersSpendingControlsSpendingLimits (?amount: int, ?categories: PostIssuingCardholdersSpendingControlsSpendingLimitsCategories list, ?interval: PostIssuingCardholdersSpendingControlsSpendingLimitsInterval) =
        ///Maximum amount allowed to spend per interval.
        member _.Amount = amount
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) this limit applies to. Omitting this field will apply the limit to all categories.
        member _.Categories = categories
        ///Interval (or event) to which the amount applies.
        member _.Interval = interval

    and PostIssuingCardholdersSpendingControlsSpendingLimitsInterval =
        | AllTime
        | Daily
        | Monthly
        | PerAuthorization
        | Weekly
        | Yearly

    and PostIssuingCardholdersSpendingControlsSpendingLimitsCategories =
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

    and PostIssuingCardholdersCardholderParams (?billing: PostIssuingCardholdersCardholderBilling, ?company: PostIssuingCardholdersCardholderCompany, ?email: string, ?expand: string list, ?individual: PostIssuingCardholdersCardholderIndividual, ?metadata: Map<string, string>, ?phoneNumber: string, ?spendingControls: PostIssuingCardholdersCardholderSpendingControls, ?status: PostIssuingCardholdersCardholderStatus) =
        ///The cardholder's billing address.
        member _.Billing = billing
        ///Additional information about a `company` cardholder.
        member _.Company = company
        ///The cardholder's email address.
        member _.Email = email
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Additional information about an `individual` cardholder.
        member _.Individual = individual
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The cardholder's phone number.
        member _.PhoneNumber = phoneNumber
        ///Rules that control spending across this cardholder's cards. Refer to our [documentation](https://stripe.com/docs/issuing/controls/spending-controls) for more details.
        member _.SpendingControls = spendingControls
        ///Specifies whether to permit authorizations on this cardholder's cards.
        member _.Status = status

    and PostIssuingCardholdersCardholderStatus =
        | Active
        | Inactive

    and PostIssuingCardholdersCardholderBilling (?address: PostIssuingCardholdersCardholderBillingAddress) =
        ///The cardholder’s billing address.
        member _.Address = address

    and PostIssuingCardholdersCardholderBillingAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostIssuingCardholdersCardholderCompany (?taxId: string) =
        ///The entity's business ID number.
        member _.TaxId = taxId

    and PostIssuingCardholdersCardholderIndividual (?dob: PostIssuingCardholdersCardholderIndividualDob, ?firstName: string, ?lastName: string, ?verification: PostIssuingCardholdersCardholderIndividualVerification) =
        ///The date of birth of this cardholder.
        member _.Dob = dob
        ///The first name of this cardholder.
        member _.FirstName = firstName
        ///The last name of this cardholder.
        member _.LastName = lastName
        ///Government-issued ID document for this cardholder.
        member _.Verification = verification

    and PostIssuingCardholdersCardholderIndividualDob (?day: int, ?month: int, ?year: int) =
        ///The day of birth, between 1 and 31.
        member _.Day = day
        ///The month of birth, between 1 and 12.
        member _.Month = month
        ///The four-digit year of birth.
        member _.Year = year

    and PostIssuingCardholdersCardholderIndividualVerification (?document: PostIssuingCardholdersCardholderIndividualVerificationDocument) =
        ///An identifying document, either a passport or local ID card.
        member _.Document = document

    and PostIssuingCardholdersCardholderIndividualVerificationDocument (?back: string, ?front: string) =
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`.
        member _.Back = back
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`.
        member _.Front = front

    and PostIssuingCardholdersCardholderSpendingControls (?allowedCategories: PostIssuingCardholdersCardholderSpendingControlsAllowedCategories list, ?blockedCategories: PostIssuingCardholdersCardholderSpendingControlsBlockedCategories list, ?spendingLimits: PostIssuingCardholdersCardholderSpendingControlsSpendingLimits list, ?spendingLimitsCurrency: string) =
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) of authorizations to allow. All other categories will be blocked. Cannot be set with `blocked_categories`.
        member _.AllowedCategories = allowedCategories
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) of authorizations to decline. All other categories will be allowed. Cannot be set with `allowed_categories`.
        member _.BlockedCategories = blockedCategories
        ///Limit spending with amount-based rules that apply across this cardholder's cards.
        member _.SpendingLimits = spendingLimits
        ///Currency of amounts within `spending_limits`. Defaults to your merchant country's currency.
        member _.SpendingLimitsCurrency = spendingLimitsCurrency

    and PostIssuingCardholdersCardholderSpendingControlsAllowedCategories =
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

    and PostIssuingCardholdersCardholderSpendingControlsBlockedCategories =
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

    and PostIssuingCardholdersCardholderSpendingControlsSpendingLimits (?amount: int, ?categories: PostIssuingCardholdersCardholderSpendingControlsSpendingLimitsCategories list, ?interval: PostIssuingCardholdersCardholderSpendingControlsSpendingLimitsInterval) =
        ///Maximum amount allowed to spend per interval.
        member _.Amount = amount
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) this limit applies to. Omitting this field will apply the limit to all categories.
        member _.Categories = categories
        ///Interval (or event) to which the amount applies.
        member _.Interval = interval

    and PostIssuingCardholdersCardholderSpendingControlsSpendingLimitsInterval =
        | AllTime
        | Daily
        | Monthly
        | PerAuthorization
        | Weekly
        | Yearly

    and PostIssuingCardholdersCardholderSpendingControlsSpendingLimitsCategories =
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

    and PostIssuingCardsParams (currency: string, ``type``: PostIssuingCardsType, ?cardholder: string, ?expand: string list, ?metadata: Map<string, string>, ?replacementFor: string, ?replacementReason: PostIssuingCardsReplacementReason, ?shipping: PostIssuingCardsShipping, ?spendingControls: PostIssuingCardsSpendingControls, ?status: PostIssuingCardsStatus) =
        ///The [Cardholder](https://stripe.com/docs/api#issuing_cardholder_object) object with which the card will be associated.
        member _.Cardholder = cardholder
        ///The currency for the card. This currently must be `usd`.
        member _.Currency = currency
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The card this is meant to be a replacement for (if any).
        member _.ReplacementFor = replacementFor
        ///If `replacement_for` is specified, this should indicate why that card is being replaced.
        member _.ReplacementReason = replacementReason
        ///The address where the card will be shipped.
        member _.Shipping = shipping
        ///Rules that control spending for this card. Refer to our [documentation](https://stripe.com/docs/issuing/controls/spending-controls) for more details.
        member _.SpendingControls = spendingControls
        ///Whether authorizations can be approved on this card. Defaults to `inactive`.
        member _.Status = status
        ///The type of card to issue. Possible values are `physical` or `virtual`.
        member _.Type = ``type``

    and PostIssuingCardsReplacementReason =
        | Damaged
        | Expired
        | Lost
        | Stolen

    and PostIssuingCardsStatus =
        | Active
        | Inactive

    and PostIssuingCardsType =
        | Physical
        | Virtual

    and PostIssuingCardsShipping (?address: PostIssuingCardsShippingAddress, ?name: string, ?service: PostIssuingCardsShippingService, ?``type``: PostIssuingCardsShippingType) =
        ///The address that the card is shipped to.
        member _.Address = address
        ///The name printed on the shipping label when shipping the card.
        member _.Name = name
        ///Shipment service.
        member _.Service = service
        ///Packaging options.
        member _.Type = ``type``

    and PostIssuingCardsShippingService =
        | Express
        | Priority
        | Standard

    and PostIssuingCardsShippingType =
        | Bulk
        | Individual

    and PostIssuingCardsShippingAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostIssuingCardsSpendingControls (?allowedCategories: PostIssuingCardsSpendingControlsAllowedCategories list, ?blockedCategories: PostIssuingCardsSpendingControlsBlockedCategories list, ?spendingLimits: PostIssuingCardsSpendingControlsSpendingLimits list) =
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) of authorizations to allow. All other categories will be blocked. Cannot be set with `blocked_categories`.
        member _.AllowedCategories = allowedCategories
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) of authorizations to decline. All other categories will be allowed. Cannot be set with `allowed_categories`.
        member _.BlockedCategories = blockedCategories
        ///Limit spending with amount-based rules.
        member _.SpendingLimits = spendingLimits

    and PostIssuingCardsSpendingControlsAllowedCategories =
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

    and PostIssuingCardsSpendingControlsBlockedCategories =
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

    and PostIssuingCardsSpendingControlsSpendingLimits (?amount: int, ?categories: PostIssuingCardsSpendingControlsSpendingLimitsCategories list, ?interval: PostIssuingCardsSpendingControlsSpendingLimitsInterval) =
        ///Maximum amount allowed to spend per interval.
        member _.Amount = amount
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) this limit applies to. Omitting this field will apply the limit to all categories.
        member _.Categories = categories
        ///Interval (or event) to which the amount applies.
        member _.Interval = interval

    and PostIssuingCardsSpendingControlsSpendingLimitsInterval =
        | AllTime
        | Daily
        | Monthly
        | PerAuthorization
        | Weekly
        | Yearly

    and PostIssuingCardsSpendingControlsSpendingLimitsCategories =
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

    and PostIssuingCardsCardParams (?cancellationReason: PostIssuingCardsCardCancellationReason, ?expand: string list, ?metadata: Map<string, string>, ?spendingControls: PostIssuingCardsCardSpendingControls, ?status: PostIssuingCardsCardStatus) =
        ///Reason why the `status` of this card is `canceled`.
        member _.CancellationReason = cancellationReason
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Rules that control spending for this card. Refer to our [documentation](https://stripe.com/docs/issuing/controls/spending-controls) for more details.
        member _.SpendingControls = spendingControls
        ///Dictates whether authorizations can be approved on this card. If this card is being canceled because it was lost or stolen, this information should be provided as `cancellation_reason`.
        member _.Status = status

    and PostIssuingCardsCardCancellationReason =
        | Lost
        | Stolen

    and PostIssuingCardsCardStatus =
        | Active
        | Canceled
        | Inactive

    and PostIssuingCardsCardSpendingControls (?allowedCategories: PostIssuingCardsCardSpendingControlsAllowedCategories list, ?blockedCategories: PostIssuingCardsCardSpendingControlsBlockedCategories list, ?spendingLimits: PostIssuingCardsCardSpendingControlsSpendingLimits list) =
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) of authorizations to allow. All other categories will be blocked. Cannot be set with `blocked_categories`.
        member _.AllowedCategories = allowedCategories
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) of authorizations to decline. All other categories will be allowed. Cannot be set with `allowed_categories`.
        member _.BlockedCategories = blockedCategories
        ///Limit spending with amount-based rules.
        member _.SpendingLimits = spendingLimits

    and PostIssuingCardsCardSpendingControlsAllowedCategories =
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

    and PostIssuingCardsCardSpendingControlsBlockedCategories =
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

    and PostIssuingCardsCardSpendingControlsSpendingLimits (?amount: int, ?categories: PostIssuingCardsCardSpendingControlsSpendingLimitsCategories list, ?interval: PostIssuingCardsCardSpendingControlsSpendingLimitsInterval) =
        ///Maximum amount allowed to spend per interval.
        member _.Amount = amount
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) this limit applies to. Omitting this field will apply the limit to all categories.
        member _.Categories = categories
        ///Interval (or event) to which the amount applies.
        member _.Interval = interval

    and PostIssuingCardsCardSpendingControlsSpendingLimitsInterval =
        | AllTime
        | Daily
        | Monthly
        | PerAuthorization
        | Weekly
        | Yearly

    and PostIssuingCardsCardSpendingControlsSpendingLimitsCategories =
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

    and PostIssuingDisputesParams (transaction: string, ?evidence: PostIssuingDisputesEvidence, ?expand: string list, ?metadata: Map<string, string>) =
        ///Evidence provided for the dispute.
        member _.Evidence = evidence
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The ID of the issuing transaction to create a dispute for.
        member _.Transaction = transaction

    and PostIssuingDisputesEvidence (?canceled: Choice<PostIssuingDisputesEvidenceCanceledCanceled,string>, ?duplicate: Choice<PostIssuingDisputesEvidenceDuplicateDuplicate,string>, ?fraudulent: Choice<PostIssuingDisputesEvidenceFraudulentFraudulent,string>, ?merchandiseNotAsDescribed: Choice<PostIssuingDisputesEvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed,string>, ?notReceived: Choice<PostIssuingDisputesEvidenceNotReceivedNotReceived,string>, ?other: Choice<PostIssuingDisputesEvidenceOtherOther,string>, ?reason: PostIssuingDisputesEvidenceReason, ?serviceNotAsDescribed: Choice<PostIssuingDisputesEvidenceServiceNotAsDescribedServiceNotAsDescribed,string>) =
        ///Evidence provided when `reason` is 'canceled'.
        member _.Canceled = canceled
        ///Evidence provided when `reason` is 'duplicate'.
        member _.Duplicate = duplicate
        ///Evidence provided when `reason` is 'fraudulent'.
        member _.Fraudulent = fraudulent
        ///Evidence provided when `reason` is 'merchandise_not_as_described'.
        member _.MerchandiseNotAsDescribed = merchandiseNotAsDescribed
        ///Evidence provided when `reason` is 'not_received'.
        member _.NotReceived = notReceived
        ///Evidence provided when `reason` is 'other'.
        member _.Other = other
        ///The reason for filing the dispute. The evidence should be submitted in the field of the same name.
        member _.Reason = reason
        ///Evidence provided when `reason` is 'service_not_as_described'.
        member _.ServiceNotAsDescribed = serviceNotAsDescribed

    and PostIssuingDisputesEvidenceReason =
        | Canceled
        | Duplicate
        | Fraudulent
        | MerchandiseNotAsDescribed
        | NotReceived
        | Other
        | ServiceNotAsDescribed

    and PostIssuingDisputesEvidenceCanceledCanceled (?additionalDocumentation: Choice<string,string>, ?canceledAt: Choice<DateTime,string>, ?cancellationPolicyProvided: Choice<bool,string>, ?cancellationReason: string, ?expectedAt: Choice<DateTime,string>, ?explanation: string, ?productDescription: string, ?productType: PostIssuingDisputesEvidenceCanceledCanceledProductType, ?returnStatus: PostIssuingDisputesEvidenceCanceledCanceledReturnStatus, ?returnedAt: Choice<DateTime,string>) =
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        member _.AdditionalDocumentation = additionalDocumentation
        ///Date when order was canceled.
        member _.CanceledAt = canceledAt
        ///Whether the cardholder was provided with a cancellation policy.
        member _.CancellationPolicyProvided = cancellationPolicyProvided
        ///Reason for canceling the order.
        member _.CancellationReason = cancellationReason
        ///Date when the cardholder expected to receive the product.
        member _.ExpectedAt = expectedAt
        ///Explanation of why the cardholder is disputing this transaction.
        member _.Explanation = explanation
        ///Description of the merchandise or service that was purchased.
        member _.ProductDescription = productDescription
        ///Whether the product was a merchandise or service.
        member _.ProductType = productType
        ///Result of cardholder's attempt to return the product.
        member _.ReturnStatus = returnStatus
        ///Date when the product was returned or attempted to be returned.
        member _.ReturnedAt = returnedAt

    and PostIssuingDisputesEvidenceCanceledCanceledProductType =
        | Merchandise
        | Service

    and PostIssuingDisputesEvidenceCanceledCanceledReturnStatus =
        | MerchantRejected
        | Successful

    and PostIssuingDisputesEvidenceDuplicateDuplicate (?additionalDocumentation: Choice<string,string>, ?cardStatement: Choice<string,string>, ?cashReceipt: Choice<string,string>, ?checkImage: Choice<string,string>, ?explanation: string, ?originalTransaction: string) =
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        member _.AdditionalDocumentation = additionalDocumentation
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Copy of the card statement showing that the product had already been paid for.
        member _.CardStatement = cardStatement
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Copy of the receipt showing that the product had been paid for in cash.
        member _.CashReceipt = cashReceipt
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Image of the front and back of the check that was used to pay for the product.
        member _.CheckImage = checkImage
        ///Explanation of why the cardholder is disputing this transaction.
        member _.Explanation = explanation
        ///Transaction (e.g., ipi_...) that the disputed transaction is a duplicate of. Of the two or more transactions that are copies of each other, this is original undisputed one.
        member _.OriginalTransaction = originalTransaction

    and PostIssuingDisputesEvidenceFraudulentFraudulent (?additionalDocumentation: Choice<string,string>, ?explanation: string) =
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        member _.AdditionalDocumentation = additionalDocumentation
        ///Explanation of why the cardholder is disputing this transaction.
        member _.Explanation = explanation

    and PostIssuingDisputesEvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed (?additionalDocumentation: Choice<string,string>, ?explanation: string, ?receivedAt: Choice<DateTime,string>, ?returnDescription: string, ?returnStatus: PostIssuingDisputesEvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus, ?returnedAt: Choice<DateTime,string>) =
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        member _.AdditionalDocumentation = additionalDocumentation
        ///Explanation of why the cardholder is disputing this transaction.
        member _.Explanation = explanation
        ///Date when the product was received.
        member _.ReceivedAt = receivedAt
        ///Description of the cardholder's attempt to return the product.
        member _.ReturnDescription = returnDescription
        ///Result of cardholder's attempt to return the product.
        member _.ReturnStatus = returnStatus
        ///Date when the product was returned or attempted to be returned.
        member _.ReturnedAt = returnedAt

    and PostIssuingDisputesEvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus =
        | MerchantRejected
        | Successful

    and PostIssuingDisputesEvidenceNotReceivedNotReceived (?additionalDocumentation: Choice<string,string>, ?expectedAt: Choice<DateTime,string>, ?explanation: string, ?productDescription: string, ?productType: PostIssuingDisputesEvidenceNotReceivedNotReceivedProductType) =
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        member _.AdditionalDocumentation = additionalDocumentation
        ///Date when the cardholder expected to receive the product.
        member _.ExpectedAt = expectedAt
        ///Explanation of why the cardholder is disputing this transaction.
        member _.Explanation = explanation
        ///Description of the merchandise or service that was purchased.
        member _.ProductDescription = productDescription
        ///Whether the product was a merchandise or service.
        member _.ProductType = productType

    and PostIssuingDisputesEvidenceNotReceivedNotReceivedProductType =
        | Merchandise
        | Service

    and PostIssuingDisputesEvidenceOtherOther (?additionalDocumentation: Choice<string,string>, ?explanation: string, ?productDescription: string, ?productType: PostIssuingDisputesEvidenceOtherOtherProductType) =
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        member _.AdditionalDocumentation = additionalDocumentation
        ///Explanation of why the cardholder is disputing this transaction.
        member _.Explanation = explanation
        ///Description of the merchandise or service that was purchased.
        member _.ProductDescription = productDescription
        ///Whether the product was a merchandise or service.
        member _.ProductType = productType

    and PostIssuingDisputesEvidenceOtherOtherProductType =
        | Merchandise
        | Service

    and PostIssuingDisputesEvidenceServiceNotAsDescribedServiceNotAsDescribed (?additionalDocumentation: Choice<string,string>, ?canceledAt: Choice<DateTime,string>, ?cancellationReason: string, ?explanation: string, ?receivedAt: Choice<DateTime,string>) =
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        member _.AdditionalDocumentation = additionalDocumentation
        ///Date when order was canceled.
        member _.CanceledAt = canceledAt
        ///Reason for canceling the order.
        member _.CancellationReason = cancellationReason
        ///Explanation of why the cardholder is disputing this transaction.
        member _.Explanation = explanation
        ///Date when the product was received.
        member _.ReceivedAt = receivedAt

    and PostIssuingDisputesDisputeParams (?evidence: PostIssuingDisputesDisputeEvidence, ?expand: string list, ?metadata: Map<string, string>) =
        ///Evidence provided for the dispute.
        member _.Evidence = evidence
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostIssuingDisputesDisputeEvidence (?canceled: Choice<PostIssuingDisputesDisputeEvidenceCanceledCanceled,string>, ?duplicate: Choice<PostIssuingDisputesDisputeEvidenceDuplicateDuplicate,string>, ?fraudulent: Choice<PostIssuingDisputesDisputeEvidenceFraudulentFraudulent,string>, ?merchandiseNotAsDescribed: Choice<PostIssuingDisputesDisputeEvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed,string>, ?notReceived: Choice<PostIssuingDisputesDisputeEvidenceNotReceivedNotReceived,string>, ?other: Choice<PostIssuingDisputesDisputeEvidenceOtherOther,string>, ?reason: PostIssuingDisputesDisputeEvidenceReason, ?serviceNotAsDescribed: Choice<PostIssuingDisputesDisputeEvidenceServiceNotAsDescribedServiceNotAsDescribed,string>) =
        ///Evidence provided when `reason` is 'canceled'.
        member _.Canceled = canceled
        ///Evidence provided when `reason` is 'duplicate'.
        member _.Duplicate = duplicate
        ///Evidence provided when `reason` is 'fraudulent'.
        member _.Fraudulent = fraudulent
        ///Evidence provided when `reason` is 'merchandise_not_as_described'.
        member _.MerchandiseNotAsDescribed = merchandiseNotAsDescribed
        ///Evidence provided when `reason` is 'not_received'.
        member _.NotReceived = notReceived
        ///Evidence provided when `reason` is 'other'.
        member _.Other = other
        ///The reason for filing the dispute. The evidence should be submitted in the field of the same name.
        member _.Reason = reason
        ///Evidence provided when `reason` is 'service_not_as_described'.
        member _.ServiceNotAsDescribed = serviceNotAsDescribed

    and PostIssuingDisputesDisputeEvidenceReason =
        | Canceled
        | Duplicate
        | Fraudulent
        | MerchandiseNotAsDescribed
        | NotReceived
        | Other
        | ServiceNotAsDescribed

    and PostIssuingDisputesDisputeEvidenceCanceledCanceled (?additionalDocumentation: Choice<string,string>, ?canceledAt: Choice<DateTime,string>, ?cancellationPolicyProvided: Choice<bool,string>, ?cancellationReason: string, ?expectedAt: Choice<DateTime,string>, ?explanation: string, ?productDescription: string, ?productType: PostIssuingDisputesDisputeEvidenceCanceledCanceledProductType, ?returnStatus: PostIssuingDisputesDisputeEvidenceCanceledCanceledReturnStatus, ?returnedAt: Choice<DateTime,string>) =
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        member _.AdditionalDocumentation = additionalDocumentation
        ///Date when order was canceled.
        member _.CanceledAt = canceledAt
        ///Whether the cardholder was provided with a cancellation policy.
        member _.CancellationPolicyProvided = cancellationPolicyProvided
        ///Reason for canceling the order.
        member _.CancellationReason = cancellationReason
        ///Date when the cardholder expected to receive the product.
        member _.ExpectedAt = expectedAt
        ///Explanation of why the cardholder is disputing this transaction.
        member _.Explanation = explanation
        ///Description of the merchandise or service that was purchased.
        member _.ProductDescription = productDescription
        ///Whether the product was a merchandise or service.
        member _.ProductType = productType
        ///Result of cardholder's attempt to return the product.
        member _.ReturnStatus = returnStatus
        ///Date when the product was returned or attempted to be returned.
        member _.ReturnedAt = returnedAt

    and PostIssuingDisputesDisputeEvidenceCanceledCanceledProductType =
        | Merchandise
        | Service

    and PostIssuingDisputesDisputeEvidenceCanceledCanceledReturnStatus =
        | MerchantRejected
        | Successful

    and PostIssuingDisputesDisputeEvidenceDuplicateDuplicate (?additionalDocumentation: Choice<string,string>, ?cardStatement: Choice<string,string>, ?cashReceipt: Choice<string,string>, ?checkImage: Choice<string,string>, ?explanation: string, ?originalTransaction: string) =
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        member _.AdditionalDocumentation = additionalDocumentation
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Copy of the card statement showing that the product had already been paid for.
        member _.CardStatement = cardStatement
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Copy of the receipt showing that the product had been paid for in cash.
        member _.CashReceipt = cashReceipt
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Image of the front and back of the check that was used to pay for the product.
        member _.CheckImage = checkImage
        ///Explanation of why the cardholder is disputing this transaction.
        member _.Explanation = explanation
        ///Transaction (e.g., ipi_...) that the disputed transaction is a duplicate of. Of the two or more transactions that are copies of each other, this is original undisputed one.
        member _.OriginalTransaction = originalTransaction

    and PostIssuingDisputesDisputeEvidenceFraudulentFraudulent (?additionalDocumentation: Choice<string,string>, ?explanation: string) =
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        member _.AdditionalDocumentation = additionalDocumentation
        ///Explanation of why the cardholder is disputing this transaction.
        member _.Explanation = explanation

    and PostIssuingDisputesDisputeEvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed (?additionalDocumentation: Choice<string,string>, ?explanation: string, ?receivedAt: Choice<DateTime,string>, ?returnDescription: string, ?returnStatus: PostIssuingDisputesDisputeEvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus, ?returnedAt: Choice<DateTime,string>) =
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        member _.AdditionalDocumentation = additionalDocumentation
        ///Explanation of why the cardholder is disputing this transaction.
        member _.Explanation = explanation
        ///Date when the product was received.
        member _.ReceivedAt = receivedAt
        ///Description of the cardholder's attempt to return the product.
        member _.ReturnDescription = returnDescription
        ///Result of cardholder's attempt to return the product.
        member _.ReturnStatus = returnStatus
        ///Date when the product was returned or attempted to be returned.
        member _.ReturnedAt = returnedAt

    and PostIssuingDisputesDisputeEvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus =
        | MerchantRejected
        | Successful

    and PostIssuingDisputesDisputeEvidenceNotReceivedNotReceived (?additionalDocumentation: Choice<string,string>, ?expectedAt: Choice<DateTime,string>, ?explanation: string, ?productDescription: string, ?productType: PostIssuingDisputesDisputeEvidenceNotReceivedNotReceivedProductType) =
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        member _.AdditionalDocumentation = additionalDocumentation
        ///Date when the cardholder expected to receive the product.
        member _.ExpectedAt = expectedAt
        ///Explanation of why the cardholder is disputing this transaction.
        member _.Explanation = explanation
        ///Description of the merchandise or service that was purchased.
        member _.ProductDescription = productDescription
        ///Whether the product was a merchandise or service.
        member _.ProductType = productType

    and PostIssuingDisputesDisputeEvidenceNotReceivedNotReceivedProductType =
        | Merchandise
        | Service

    and PostIssuingDisputesDisputeEvidenceOtherOther (?additionalDocumentation: Choice<string,string>, ?explanation: string, ?productDescription: string, ?productType: PostIssuingDisputesDisputeEvidenceOtherOtherProductType) =
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        member _.AdditionalDocumentation = additionalDocumentation
        ///Explanation of why the cardholder is disputing this transaction.
        member _.Explanation = explanation
        ///Description of the merchandise or service that was purchased.
        member _.ProductDescription = productDescription
        ///Whether the product was a merchandise or service.
        member _.ProductType = productType

    and PostIssuingDisputesDisputeEvidenceOtherOtherProductType =
        | Merchandise
        | Service

    and PostIssuingDisputesDisputeEvidenceServiceNotAsDescribedServiceNotAsDescribed (?additionalDocumentation: Choice<string,string>, ?canceledAt: Choice<DateTime,string>, ?cancellationReason: string, ?explanation: string, ?receivedAt: Choice<DateTime,string>) =
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        member _.AdditionalDocumentation = additionalDocumentation
        ///Date when order was canceled.
        member _.CanceledAt = canceledAt
        ///Reason for canceling the order.
        member _.CancellationReason = cancellationReason
        ///Explanation of why the cardholder is disputing this transaction.
        member _.Explanation = explanation
        ///Date when the product was received.
        member _.ReceivedAt = receivedAt

    and PostIssuingDisputesDisputeSubmitParams (?expand: string list, ?metadata: Map<string, string>) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostIssuingTransactionsTransactionParams (?expand: string list, ?metadata: Map<string, string>) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostOrdersParams (currency: string, ?coupon: string, ?customer: string, ?email: string, ?expand: string list, ?items: PostOrdersItems list, ?metadata: Map<string, string>, ?shipping: PostOrdersShipping) =
        ///A coupon code that represents a discount to be applied to this order. Must be one-time duration and in same currency as the order. An order can have multiple coupons.
        member _.Coupon = coupon
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///The ID of an existing customer to use for this order. If provided, the customer email and shipping address will be used to create the order. Subsequently, the customer will also be charged to pay the order. If `email` or `shipping` are also provided, they will override the values retrieved from the customer object.
        member _.Customer = customer
        ///The email address of the customer placing the order.
        member _.Email = email
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///List of items constituting the order. An order can have up to 25 items.
        member _.Items = items
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Shipping address for the order. Required if any of the SKUs are for products that have `shippable` set to true.
        member _.Shipping = shipping

    and PostOrdersItems (?amount: int, ?currency: string, ?description: string, ?parent: string, ?quantity: int, ?``type``: PostOrdersItemsType) =
        ///
        member _.Amount = amount
        ///
        member _.Currency = currency
        ///
        member _.Description = description
        ///The ID of the SKU being ordered.
        member _.Parent = parent
        ///The quantity of this order item. When type is `sku`, this is the number of instances of the SKU to be ordered.
        member _.Quantity = quantity
        ///
        member _.Type = ``type``

    and PostOrdersItemsType =
        | Discount
        | Shipping
        | Sku
        | Tax

    and PostOrdersShipping (?address: PostOrdersShippingAddress, ?name: string, ?phone: string) =
        ///Customer shipping address.
        member _.Address = address
        ///Customer name.
        member _.Name = name
        ///Customer phone (including extension).
        member _.Phone = phone

    and PostOrdersShippingAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostOrdersIdParams (?coupon: string, ?expand: string list, ?metadata: Map<string, string>, ?selectedShippingMethod: string, ?shipping: PostOrdersIdShipping, ?status: PostOrdersIdStatus) =
        ///A coupon code that represents a discount to be applied to this order. Must be one-time duration and in same currency as the order. An order can have multiple coupons.
        member _.Coupon = coupon
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The shipping method to select for fulfilling this order. If specified, must be one of the `id`s of a shipping method in the `shipping_methods` array. If specified, will overwrite the existing selected shipping method, updating `items` as necessary.
        member _.SelectedShippingMethod = selectedShippingMethod
        ///Tracking information once the order has been fulfilled.
        member _.Shipping = shipping
        ///Current order status. One of `created`, `paid`, `canceled`, `fulfilled`, or `returned`. More detail in the [Orders Guide](https://stripe.com/docs/orders/guide#understanding-order-statuses).
        member _.Status = status

    and PostOrdersIdStatus =
        | Canceled
        | Created
        | Fulfilled
        | Paid
        | Returned

    and PostOrdersIdShipping (?carrier: string, ?trackingNumber: string) =
        ///The name of the carrier like `USPS`, `UPS`, or `FedEx`.
        member _.Carrier = carrier
        ///The tracking number provided by the carrier.
        member _.TrackingNumber = trackingNumber

    and PostOrdersIdPayParams (?applicationFee: int, ?customer: string, ?email: string, ?expand: string list, ?metadata: Map<string, string>, ?source: string) =
        ///A fee in %s that will be applied to the order and transferred to the application owner's Stripe account. The request must be made with an OAuth key or the `Stripe-Account` header in order to take an application fee. For more information, see the application fees [documentation](https://stripe.com/docs/connect/direct-charges#collecting-fees).
        member _.ApplicationFee = applicationFee
        ///The ID of an existing customer that will be charged for this order. If no customer was attached to the order at creation, either `source` or `customer` is required. Otherwise, the specified customer will be charged instead of the one attached to the order.
        member _.Customer = customer
        ///The email address of the customer placing the order. Required if not previously specified for the order.
        member _.Email = email
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///A [Token](https://stripe.com/docs/api#tokens)'s or a [Source](https://stripe.com/docs/api#sources)'s ID, as returned by [Elements](https://stripe.com/docs/elements). If no customer was attached to the order at creation, either `source` or `customer` is required. Otherwise, the specified source will be charged intead of the customer attached to the order.
        member _.Source = source

    and PostOrdersIdReturnsParams (?expand: string list, ?items: Choice<PostOrdersIdReturnsItems list,string>) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///List of items to return.
        member _.Items = items

    and PostOrdersIdReturnsItems (?amount: int, ?description: string, ?parent: string, ?quantity: int, ?``type``: PostOrdersIdReturnsItemsType) =
        ///The amount (price) for this order item to return.
        member _.Amount = amount
        ///If returning a `tax` item, use description to disambiguate which one to return.
        member _.Description = description
        ///The ID of the SKU, tax, or shipping item being returned.
        member _.Parent = parent
        ///When type is `sku`, this is the number of instances of the SKU to be returned.
        member _.Quantity = quantity
        ///The type of this order item. Must be `sku`, `tax`, or `shipping`.
        member _.Type = ``type``

    and PostOrdersIdReturnsItemsType =
        | Discount
        | Shipping
        | Sku
        | Tax

    and PostPaymentIntentsParams (amount: int, currency: string, ?transferData: PostPaymentIntentsTransferData, ?statementDescriptorSuffix: string, ?statementDescriptor: string, ?shipping: PostPaymentIntentsShipping, ?setupFutureUsage: PostPaymentIntentsSetupFutureUsage, ?returnUrl: string, ?receiptEmail: string, ?paymentMethodTypes: string list, ?paymentMethodOptions: PostPaymentIntentsPaymentMethodOptions, ?paymentMethodData: PostPaymentIntentsPaymentMethodData, ?paymentMethod: string, ?onBehalfOf: string, ?offSession: Choice<bool,PostPaymentIntentsOffSession>, ?metadata: Map<string, string>, ?mandateData: PostPaymentIntentsMandateData, ?mandate: string, ?expand: string list, ?errorOnRequiresAction: bool, ?description: string, ?customer: string, ?confirmationMethod: PostPaymentIntentsConfirmationMethod, ?confirm: bool, ?captureMethod: PostPaymentIntentsCaptureMethod, ?applicationFeeAmount: int, ?transferGroup: string, ?useStripeSdk: bool) =
        ///Amount intended to be collected by this PaymentIntent. A positive integer representing how much to charge in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal) (e.g., 100 cents to charge $1.00 or 100 to charge ¥100, a zero-decimal currency). The minimum amount is $0.50 US or [equivalent in charge currency](https://stripe.com/docs/currencies#minimum-and-maximum-charge-amounts). The amount value supports up to eight digits (e.g., a value of 99999999 for a USD charge of $999,999.99).
        member _.Amount = amount
        ///The amount of the application fee (if any) that will be requested to be applied to the payment and transferred to the application owner's Stripe account. The amount of the application fee collected will be capped at the total payment amount. For more information, see the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts).
        member _.ApplicationFeeAmount = applicationFeeAmount
        ///Controls when the funds will be captured from the customer's account.
        member _.CaptureMethod = captureMethod
        ///Set to `true` to attempt to [confirm](https://stripe.com/docs/api/payment_intents/confirm) this PaymentIntent immediately. This parameter defaults to `false`. When creating and confirming a PaymentIntent at the same time, parameters available in the [confirm](https://stripe.com/docs/api/payment_intents/confirm) API may also be provided.
        member _.Confirm = confirm
        ///
        member _.ConfirmationMethod = confirmationMethod
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///ID of the Customer this PaymentIntent belongs to, if one exists.
        ///Payment methods attached to other Customers cannot be used with this PaymentIntent.
        ///If present in combination with [setup_future_usage](https://stripe.com/docs/api#payment_intent_object-setup_future_usage), this PaymentIntent's payment method will be attached to the Customer after the PaymentIntent has been confirmed and any required actions from the user are complete.
        member _.Customer = customer
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        member _.Description = description
        ///Set to `true` to fail the payment attempt if the PaymentIntent transitions into `requires_action`. This parameter is intended for simpler integrations that do not handle customer actions, like [saving cards without authentication](https://stripe.com/docs/payments/save-card-without-authentication). This parameter can only be used with [`confirm=true`](https://stripe.com/docs/api/payment_intents/create#create_payment_intent-confirm).
        member _.ErrorOnRequiresAction = errorOnRequiresAction
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///ID of the mandate to be used for this payment. This parameter can only be used with [`confirm=true`](https://stripe.com/docs/api/payment_intents/create#create_payment_intent-confirm).
        member _.Mandate = mandate
        ///This hash contains details about the Mandate to create. This parameter can only be used with [`confirm=true`](https://stripe.com/docs/api/payment_intents/create#create_payment_intent-confirm).
        member _.MandateData = mandateData
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Set to `true` to indicate that the customer is not in your checkout flow during this payment attempt, and therefore is unable to authenticate. This parameter is intended for scenarios where you collect card details and [charge them later](https://stripe.com/docs/payments/cards/charging-saved-cards). This parameter can only be used with [`confirm=true`](https://stripe.com/docs/api/payment_intents/create#create_payment_intent-confirm).
        member _.OffSession = offSession
        ///The Stripe account ID for which these funds are intended. For details, see the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts).
        member _.OnBehalfOf = onBehalfOf
        ///ID of the payment method (a PaymentMethod, Card, or [compatible Source](https://stripe.com/docs/payments/payment-methods#compatibility) object) to attach to this PaymentIntent.
        ///If neither the `payment_method` parameter nor the `source` parameter are provided with `confirm=true`, `source` will be automatically populated with `customer.default_source` to improve the migration experience for users of the Charges API. We recommend that you explicitly provide the `payment_method` going forward.
        member _.PaymentMethod = paymentMethod
        ///If provided, this hash will be used to create a PaymentMethod. The new PaymentMethod will appear
        ///in the [payment_method](https://stripe.com/docs/api/payment_intents/object#payment_intent_object-payment_method)
        ///property on the PaymentIntent.
        member _.PaymentMethodData = paymentMethodData
        ///Payment-method-specific configuration for this PaymentIntent.
        member _.PaymentMethodOptions = paymentMethodOptions
        ///The list of payment method types (e.g. card) that this PaymentIntent is allowed to use. If this is not provided, defaults to ["card"].
        member _.PaymentMethodTypes = paymentMethodTypes
        ///Email address that the receipt for the resulting payment will be sent to. If `receipt_email` is specified for a payment in live mode, a receipt will be sent regardless of your [email settings](https://dashboard.stripe.com/account/emails).
        member _.ReceiptEmail = receiptEmail
        ///The URL to redirect your customer back to after they authenticate or cancel their payment on the payment method's app or site. If you'd prefer to redirect to a mobile application, you can alternatively supply an application URI scheme. This parameter can only be used with [`confirm=true`](https://stripe.com/docs/api/payment_intents/create#create_payment_intent-confirm).
        member _.ReturnUrl = returnUrl
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        member _.SetupFutureUsage = setupFutureUsage
        ///Shipping information for this PaymentIntent.
        member _.Shipping = shipping
        ///For non-card charges, you can use this value as the complete description that appears on your customers’ statements. Must contain at least one letter, maximum 22 characters.
        member _.StatementDescriptor = statementDescriptor
        ///Provides information about a card payment that customers see on their statements. Concatenated with the prefix (shortened descriptor) or statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 22 characters for the concatenated descriptor.
        member _.StatementDescriptorSuffix = statementDescriptorSuffix
        ///The parameters used to automatically create a Transfer when the payment succeeds.
        ///For more information, see the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts).
        member _.TransferData = transferData
        ///A string that identifies the resulting payment as part of a group. See the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts) for details.
        member _.TransferGroup = transferGroup
        ///Set to `true` only when using manual confirmation and the iOS or Android SDKs to handle additional authentication steps.
        member _.UseStripeSdk = useStripeSdk

    and PostPaymentIntentsCaptureMethod =
        | Automatic
        | Manual

    and PostPaymentIntentsConfirmationMethod =
        | Automatic
        | Manual

    and PostPaymentIntentsSetupFutureUsage =
        | OffSession
        | OnSession

    and PostPaymentIntentsMandateData (?customerAcceptance: PostPaymentIntentsMandateDataCustomerAcceptance) =
        ///This hash contains details about the customer acceptance of the Mandate.
        member _.CustomerAcceptance = customerAcceptance

    and PostPaymentIntentsMandateDataCustomerAcceptance (?acceptedAt: DateTime, ?offline: string, ?online: PostPaymentIntentsMandateDataCustomerAcceptanceOnline, ?``type``: PostPaymentIntentsMandateDataCustomerAcceptanceType) =
        ///The time at which the customer accepted the Mandate.
        member _.AcceptedAt = acceptedAt
        ///If this is a Mandate accepted offline, this hash contains details about the offline acceptance.
        member _.Offline = offline
        ///If this is a Mandate accepted online, this hash contains details about the online acceptance.
        member _.Online = online
        ///The type of customer acceptance information included with the Mandate. One of `online` or `offline`.
        member _.Type = ``type``

    and PostPaymentIntentsMandateDataCustomerAcceptanceType =
        | Offline
        | Online

    and PostPaymentIntentsMandateDataCustomerAcceptanceOnline (?ipAddress: string, ?userAgent: string) =
        ///The IP address from which the Mandate was accepted by the customer.
        member _.IpAddress = ipAddress
        ///The user agent of the browser from which the Mandate was accepted by the customer.
        member _.UserAgent = userAgent

    and PostPaymentIntentsOffSession =
        | OneOff
        | Recurring

    and PostPaymentIntentsPaymentMethodData (?alipay: string, ?sepaDebit: PostPaymentIntentsPaymentMethodDataSepaDebit, ?p24: PostPaymentIntentsPaymentMethodDataP24, ?oxxo: string, ?metadata: Map<string, string>, ?interacPresent: string, ?ideal: PostPaymentIntentsPaymentMethodDataIdeal, ?sofort: PostPaymentIntentsPaymentMethodDataSofort, ?grabpay: string, ?fpx: PostPaymentIntentsPaymentMethodDataFpx, ?eps: string, ?billingDetails: PostPaymentIntentsPaymentMethodDataBillingDetails, ?bancontact: string, ?bacsDebit: PostPaymentIntentsPaymentMethodDataBacsDebit, ?auBecsDebit: PostPaymentIntentsPaymentMethodDataAuBecsDebit, ?giropay: string, ?``type``: PostPaymentIntentsPaymentMethodDataType) =
        ///If this is an `Alipay` PaymentMethod, this hash contains details about the Alipay payment method.
        member _.Alipay = alipay
        ///If this is an `au_becs_debit` PaymentMethod, this hash contains details about the bank account.
        member _.AuBecsDebit = auBecsDebit
        ///If this is a `bacs_debit` PaymentMethod, this hash contains details about the Bacs Direct Debit bank account.
        member _.BacsDebit = bacsDebit
        ///If this is a `bancontact` PaymentMethod, this hash contains details about the Bancontact payment method.
        member _.Bancontact = bancontact
        ///Billing information associated with the PaymentMethod that may be used or required by particular types of payment methods.
        member _.BillingDetails = billingDetails
        ///If this is an `eps` PaymentMethod, this hash contains details about the EPS payment method.
        member _.Eps = eps
        ///If this is an `fpx` PaymentMethod, this hash contains details about the FPX payment method.
        member _.Fpx = fpx
        ///If this is a `giropay` PaymentMethod, this hash contains details about the Giropay payment method.
        member _.Giropay = giropay
        ///If this is a `grabpay` PaymentMethod, this hash contains details about the GrabPay payment method.
        member _.Grabpay = grabpay
        ///If this is an `ideal` PaymentMethod, this hash contains details about the iDEAL payment method.
        member _.Ideal = ideal
        ///If this is an `interac_present` PaymentMethod, this hash contains details about the Interac Present payment method.
        member _.InteracPresent = interacPresent
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///If this is an `oxxo` PaymentMethod, this hash contains details about the OXXO payment method.
        member _.Oxxo = oxxo
        ///If this is a `p24` PaymentMethod, this hash contains details about the P24 payment method.
        member _.P24 = p24
        ///If this is a `sepa_debit` PaymentMethod, this hash contains details about the SEPA debit bank account.
        member _.SepaDebit = sepaDebit
        ///If this is a `sofort` PaymentMethod, this hash contains details about the SOFORT payment method.
        member _.Sofort = sofort
        ///The type of the PaymentMethod. An additional hash is included on the PaymentMethod with a name matching this value. It contains additional information specific to the PaymentMethod type.
        member _.Type = ``type``

    and PostPaymentIntentsPaymentMethodDataType =
        | Alipay
        | AuBecsDebit
        | BacsDebit
        | Bancontact
        | Eps
        | Fpx
        | Giropay
        | Grabpay
        | Ideal
        | Oxxo
        | P24
        | SepaDebit
        | Sofort

    and PostPaymentIntentsPaymentMethodDataAuBecsDebit (?accountNumber: string, ?bsbNumber: string) =
        ///The account number for the bank account.
        member _.AccountNumber = accountNumber
        ///Bank-State-Branch number of the bank account.
        member _.BsbNumber = bsbNumber

    and PostPaymentIntentsPaymentMethodDataBacsDebit (?accountNumber: string, ?sortCode: string) =
        ///Account number of the bank account that the funds will be debited from.
        member _.AccountNumber = accountNumber
        ///Sort code of the bank account. (e.g., `10-20-30`)
        member _.SortCode = sortCode

    and PostPaymentIntentsPaymentMethodDataBillingDetails (?address: Choice<PostPaymentIntentsPaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string>, ?email: string, ?name: string, ?phone: string) =
        ///Billing address.
        member _.Address = address
        ///Email address.
        member _.Email = email
        ///Full name.
        member _.Name = name
        ///Billing phone number (including extension).
        member _.Phone = phone

    and PostPaymentIntentsPaymentMethodDataBillingDetailsAddressBillingDetailsAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostPaymentIntentsPaymentMethodDataFpx (?accountHolderType: PostPaymentIntentsPaymentMethodDataFpxAccountHolderType, ?bank: PostPaymentIntentsPaymentMethodDataFpxBank) =
        ///Account holder type for FPX transaction
        member _.AccountHolderType = accountHolderType
        ///The customer's bank.
        member _.Bank = bank

    and PostPaymentIntentsPaymentMethodDataFpxAccountHolderType =
        | Company
        | Individual

    and PostPaymentIntentsPaymentMethodDataFpxBank =
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

    and PostPaymentIntentsPaymentMethodDataIdeal (?bank: PostPaymentIntentsPaymentMethodDataIdealBank) =
        ///The customer's bank.
        member _.Bank = bank

    and PostPaymentIntentsPaymentMethodDataIdealBank =
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

    and PostPaymentIntentsPaymentMethodDataP24 (?bank: PostPaymentIntentsPaymentMethodDataP24Bank) =
        ///The customer's bank.
        member _.Bank = bank

    and PostPaymentIntentsPaymentMethodDataP24Bank =
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

    and PostPaymentIntentsPaymentMethodDataSepaDebit (?iban: string) =
        ///IBAN of the bank account.
        member _.Iban = iban

    and PostPaymentIntentsPaymentMethodDataSofort (?country: PostPaymentIntentsPaymentMethodDataSofortCountry) =
        ///Two-letter ISO code representing the country the bank account is located in.
        member _.Country = country

    and PostPaymentIntentsPaymentMethodDataSofortCountry =
        | [<JsonUnionCase("AT")>] AT
        | [<JsonUnionCase("BE")>] BE
        | [<JsonUnionCase("DE")>] DE
        | [<JsonUnionCase("ES")>] ES
        | [<JsonUnionCase("IT")>] IT
        | [<JsonUnionCase("NL")>] NL

    and PostPaymentIntentsPaymentMethodOptions (?alipay: Choice<string,string>, ?bancontact: Choice<PostPaymentIntentsPaymentMethodOptionsBancontactPaymentMethodOptions,string>, ?card: Choice<PostPaymentIntentsPaymentMethodOptionsCardPaymentIntent,string>, ?oxxo: Choice<PostPaymentIntentsPaymentMethodOptionsOxxoPaymentMethodOptions,string>, ?p24: Choice<string,string>, ?sepaDebit: Choice<PostPaymentIntentsPaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptions,string>, ?sofort: Choice<PostPaymentIntentsPaymentMethodOptionsSofortPaymentMethodOptions,string>) =
        ///If this is a `alipay` PaymentMethod, this sub-hash contains details about the Alipay payment method options.
        member _.Alipay = alipay
        ///If this is a `bancontact` PaymentMethod, this sub-hash contains details about the Bancontact payment method options.
        member _.Bancontact = bancontact
        ///Configuration for any card payments attempted on this PaymentIntent.
        member _.Card = card
        ///If this is a `oxxo` PaymentMethod, this sub-hash contains details about the OXXO payment method options.
        member _.Oxxo = oxxo
        ///If this is a `p24` PaymentMethod, this sub-hash contains details about the Przelewy24 payment method options.
        member _.P24 = p24
        ///If this is a `sepa_debit` PaymentIntent, this sub-hash contains details about the SEPA Debit payment method options.
        member _.SepaDebit = sepaDebit
        ///If this is a `sofort` PaymentMethod, this sub-hash contains details about the SOFORT payment method options.
        member _.Sofort = sofort

    and PostPaymentIntentsPaymentMethodOptionsBancontactPaymentMethodOptions (?preferredLanguage: PostPaymentIntentsPaymentMethodOptionsBancontactPaymentMethodOptionsPreferredLanguage) =
        ///Preferred language of the Bancontact authorization page that the customer is redirected to.
        member _.PreferredLanguage = preferredLanguage

    and PostPaymentIntentsPaymentMethodOptionsBancontactPaymentMethodOptionsPreferredLanguage =
        | De
        | En
        | Fr
        | Nl

    and PostPaymentIntentsPaymentMethodOptionsCardPaymentIntent (?cvcToken: string, ?installments: PostPaymentIntentsPaymentMethodOptionsCardPaymentIntentInstallments, ?moto: bool, ?network: PostPaymentIntentsPaymentMethodOptionsCardPaymentIntentNetwork, ?requestThreeDSecure: PostPaymentIntentsPaymentMethodOptionsCardPaymentIntentRequestThreeDSecure) =
        ///A single-use `cvc_update` Token that represents a card CVC value. When provided, the CVC value will be verified during the card payment attempt. This parameter can only be provided during confirmation.
        member _.CvcToken = cvcToken
        ///Installment configuration for payments attempted on this PaymentIntent (Mexico Only).
        ///For more information, see the [installments integration guide](https://stripe.com/docs/payments/installments).
        member _.Installments = installments
        ///When specified, this parameter indicates that a transaction will be marked
        ///as MOTO (Mail Order Telephone Order) and thus out of scope for SCA. This
        ///parameter can only be provided during confirmation.
        member _.Moto = moto
        ///Selected network to process this PaymentIntent on. Depends on the available networks of the card attached to the PaymentIntent. Can be only set confirm-time.
        member _.Network = network
        ///We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://stripe.com/docs/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Permitted values include: `automatic` or `any`. If not provided, defaults to `automatic`. Read our guide on [manually requesting 3D Secure](https://stripe.com/docs/payments/3d-secure#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
        member _.RequestThreeDSecure = requestThreeDSecure

    and PostPaymentIntentsPaymentMethodOptionsCardPaymentIntentNetwork =
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

    and PostPaymentIntentsPaymentMethodOptionsCardPaymentIntentRequestThreeDSecure =
        | Any
        | Automatic

    and PostPaymentIntentsPaymentMethodOptionsCardPaymentIntentInstallments (?enabled: bool, ?plan: Choice<PostPaymentIntentsPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlan,string>) =
        ///Setting to true enables installments for this PaymentIntent.
        ///This will cause the response to contain a list of available installment plans.
        ///Setting to false will prevent any selected plan from applying to a charge.
        member _.Enabled = enabled
        ///The selected installment plan to use for this payment attempt.
        ///This parameter can only be provided during confirmation.
        member _.Plan = plan

    and PostPaymentIntentsPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlan (?count: int, ?interval: PostPaymentIntentsPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanInterval, ?``type``: PostPaymentIntentsPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanType) =
        ///For `fixed_count` installment plans, this is the number of installment payments your customer will make to their credit card.
        member _.Count = count
        ///For `fixed_count` installment plans, this is the interval between installment payments your customer will make to their credit card.
        ///One of `month`.
        member _.Interval = interval
        ///Type of installment plan, one of `fixed_count`.
        member _.Type = ``type``

    and PostPaymentIntentsPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanInterval =
        | Month

    and PostPaymentIntentsPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanType =
        | FixedCount

    and PostPaymentIntentsPaymentMethodOptionsOxxoPaymentMethodOptions (?expiresAfterDays: int) =
        ///The number of calendar days before an OXXO voucher expires. For example, if you create an OXXO voucher on Monday and you set expires_after_days to 2, the OXXO invoice will expire on Wednesday at 23:59 America/Mexico_City time.
        member _.ExpiresAfterDays = expiresAfterDays

    and PostPaymentIntentsPaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptions (?mandateOptions: string) =
        ///Additional fields for Mandate creation
        member _.MandateOptions = mandateOptions

    and PostPaymentIntentsPaymentMethodOptionsSofortPaymentMethodOptions (?preferredLanguage: PostPaymentIntentsPaymentMethodOptionsSofortPaymentMethodOptionsPreferredLanguage) =
        ///Language shown to the payer on redirect.
        member _.PreferredLanguage = preferredLanguage

    and PostPaymentIntentsPaymentMethodOptionsSofortPaymentMethodOptionsPreferredLanguage =
        | De
        | En
        | Es
        | Fr
        | It
        | Nl
        | Pl

    and PostPaymentIntentsShipping (?address: PostPaymentIntentsShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
        ///Shipping address.
        member _.Address = address
        ///The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc.
        member _.Carrier = carrier
        ///Recipient name.
        member _.Name = name
        ///Recipient phone (including extension).
        member _.Phone = phone
        ///The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
        member _.TrackingNumber = trackingNumber

    and PostPaymentIntentsShippingAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostPaymentIntentsTransferData (?amount: int, ?destination: string) =
        ///The amount that will be transferred automatically when a charge succeeds.
        ///The amount is capped at the total transaction amount and if no amount is set,
        ///the full amount is transferred.
        ///If you intend to collect a fee and you need a more robust reporting experience, using
        ///[application_fee_amount](https://stripe.com/docs/api/payment_intents/create#create_payment_intent-application_fee_amount)
        ///might be a better fit for your integration.
        member _.Amount = amount
        ///If specified, successful charges will be attributed to the destination
        ///account for tax reporting, and the funds from charges will be transferred
        ///to the destination account. The ID of the resulting transfer will be
        ///returned on the successful charge's `transfer` field.
        member _.Destination = destination

    and PostPaymentIntentsIntentParams (?amount: int, ?statementDescriptorSuffix: string, ?statementDescriptor: string, ?shipping: Choice<PostPaymentIntentsIntentShippingShipping,string>, ?setupFutureUsage: PostPaymentIntentsIntentSetupFutureUsage, ?receiptEmail: Choice<string,string>, ?paymentMethodTypes: string list, ?paymentMethodOptions: PostPaymentIntentsIntentPaymentMethodOptions, ?paymentMethodData: PostPaymentIntentsIntentPaymentMethodData, ?paymentMethod: string, ?metadata: Map<string, string>, ?expand: string list, ?description: string, ?customer: string, ?currency: string, ?applicationFeeAmount: Choice<int,string>, ?transferData: PostPaymentIntentsIntentTransferData, ?transferGroup: string) =
        ///Amount intended to be collected by this PaymentIntent. A positive integer representing how much to charge in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal) (e.g., 100 cents to charge $1.00 or 100 to charge ¥100, a zero-decimal currency). The minimum amount is $0.50 US or [equivalent in charge currency](https://stripe.com/docs/currencies#minimum-and-maximum-charge-amounts). The amount value supports up to eight digits (e.g., a value of 99999999 for a USD charge of $999,999.99).
        member _.Amount = amount
        ///The amount of the application fee (if any) that will be requested to be applied to the payment and transferred to the application owner's Stripe account. The amount of the application fee collected will be capped at the total payment amount. For more information, see the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts).
        member _.ApplicationFeeAmount = applicationFeeAmount
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///ID of the Customer this PaymentIntent belongs to, if one exists.
        ///Payment methods attached to other Customers cannot be used with this PaymentIntent.
        ///If present in combination with [setup_future_usage](https://stripe.com/docs/api#payment_intent_object-setup_future_usage), this PaymentIntent's payment method will be attached to the Customer after the PaymentIntent has been confirmed and any required actions from the user are complete.
        member _.Customer = customer
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        member _.Description = description
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///ID of the payment method (a PaymentMethod, Card, or [compatible Source](https://stripe.com/docs/payments/payment-methods#compatibility) object) to attach to this PaymentIntent.
        member _.PaymentMethod = paymentMethod
        ///If provided, this hash will be used to create a PaymentMethod. The new PaymentMethod will appear
        ///in the [payment_method](https://stripe.com/docs/api/payment_intents/object#payment_intent_object-payment_method)
        ///property on the PaymentIntent.
        member _.PaymentMethodData = paymentMethodData
        ///Payment-method-specific configuration for this PaymentIntent.
        member _.PaymentMethodOptions = paymentMethodOptions
        ///The list of payment method types (e.g. card) that this PaymentIntent is allowed to use.
        member _.PaymentMethodTypes = paymentMethodTypes
        ///Email address that the receipt for the resulting payment will be sent to. If `receipt_email` is specified for a payment in live mode, a receipt will be sent regardless of your [email settings](https://dashboard.stripe.com/account/emails).
        member _.ReceiptEmail = receiptEmail
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        member _.SetupFutureUsage = setupFutureUsage
        ///Shipping information for this PaymentIntent.
        member _.Shipping = shipping
        ///For non-card charges, you can use this value as the complete description that appears on your customers’ statements. Must contain at least one letter, maximum 22 characters.
        member _.StatementDescriptor = statementDescriptor
        ///Provides information about a card payment that customers see on their statements. Concatenated with the prefix (shortened descriptor) or statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 22 characters for the concatenated descriptor.
        member _.StatementDescriptorSuffix = statementDescriptorSuffix
        ///The parameters used to automatically create a Transfer when the payment succeeds. For more information, see the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts).
        member _.TransferData = transferData
        ///A string that identifies the resulting payment as part of a group. `transfer_group` may only be provided if it has not been set. See the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts) for details.
        member _.TransferGroup = transferGroup

    and PostPaymentIntentsIntentSetupFutureUsage =
        | OffSession
        | OnSession

    and PostPaymentIntentsIntentPaymentMethodData (?alipay: string, ?sepaDebit: PostPaymentIntentsIntentPaymentMethodDataSepaDebit, ?p24: PostPaymentIntentsIntentPaymentMethodDataP24, ?oxxo: string, ?metadata: Map<string, string>, ?interacPresent: string, ?ideal: PostPaymentIntentsIntentPaymentMethodDataIdeal, ?sofort: PostPaymentIntentsIntentPaymentMethodDataSofort, ?grabpay: string, ?fpx: PostPaymentIntentsIntentPaymentMethodDataFpx, ?eps: string, ?billingDetails: PostPaymentIntentsIntentPaymentMethodDataBillingDetails, ?bancontact: string, ?bacsDebit: PostPaymentIntentsIntentPaymentMethodDataBacsDebit, ?auBecsDebit: PostPaymentIntentsIntentPaymentMethodDataAuBecsDebit, ?giropay: string, ?``type``: PostPaymentIntentsIntentPaymentMethodDataType) =
        ///If this is an `Alipay` PaymentMethod, this hash contains details about the Alipay payment method.
        member _.Alipay = alipay
        ///If this is an `au_becs_debit` PaymentMethod, this hash contains details about the bank account.
        member _.AuBecsDebit = auBecsDebit
        ///If this is a `bacs_debit` PaymentMethod, this hash contains details about the Bacs Direct Debit bank account.
        member _.BacsDebit = bacsDebit
        ///If this is a `bancontact` PaymentMethod, this hash contains details about the Bancontact payment method.
        member _.Bancontact = bancontact
        ///Billing information associated with the PaymentMethod that may be used or required by particular types of payment methods.
        member _.BillingDetails = billingDetails
        ///If this is an `eps` PaymentMethod, this hash contains details about the EPS payment method.
        member _.Eps = eps
        ///If this is an `fpx` PaymentMethod, this hash contains details about the FPX payment method.
        member _.Fpx = fpx
        ///If this is a `giropay` PaymentMethod, this hash contains details about the Giropay payment method.
        member _.Giropay = giropay
        ///If this is a `grabpay` PaymentMethod, this hash contains details about the GrabPay payment method.
        member _.Grabpay = grabpay
        ///If this is an `ideal` PaymentMethod, this hash contains details about the iDEAL payment method.
        member _.Ideal = ideal
        ///If this is an `interac_present` PaymentMethod, this hash contains details about the Interac Present payment method.
        member _.InteracPresent = interacPresent
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///If this is an `oxxo` PaymentMethod, this hash contains details about the OXXO payment method.
        member _.Oxxo = oxxo
        ///If this is a `p24` PaymentMethod, this hash contains details about the P24 payment method.
        member _.P24 = p24
        ///If this is a `sepa_debit` PaymentMethod, this hash contains details about the SEPA debit bank account.
        member _.SepaDebit = sepaDebit
        ///If this is a `sofort` PaymentMethod, this hash contains details about the SOFORT payment method.
        member _.Sofort = sofort
        ///The type of the PaymentMethod. An additional hash is included on the PaymentMethod with a name matching this value. It contains additional information specific to the PaymentMethod type.
        member _.Type = ``type``

    and PostPaymentIntentsIntentPaymentMethodDataType =
        | Alipay
        | AuBecsDebit
        | BacsDebit
        | Bancontact
        | Eps
        | Fpx
        | Giropay
        | Grabpay
        | Ideal
        | Oxxo
        | P24
        | SepaDebit
        | Sofort

    and PostPaymentIntentsIntentPaymentMethodDataAuBecsDebit (?accountNumber: string, ?bsbNumber: string) =
        ///The account number for the bank account.
        member _.AccountNumber = accountNumber
        ///Bank-State-Branch number of the bank account.
        member _.BsbNumber = bsbNumber

    and PostPaymentIntentsIntentPaymentMethodDataBacsDebit (?accountNumber: string, ?sortCode: string) =
        ///Account number of the bank account that the funds will be debited from.
        member _.AccountNumber = accountNumber
        ///Sort code of the bank account. (e.g., `10-20-30`)
        member _.SortCode = sortCode

    and PostPaymentIntentsIntentPaymentMethodDataBillingDetails (?address: Choice<PostPaymentIntentsIntentPaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string>, ?email: string, ?name: string, ?phone: string) =
        ///Billing address.
        member _.Address = address
        ///Email address.
        member _.Email = email
        ///Full name.
        member _.Name = name
        ///Billing phone number (including extension).
        member _.Phone = phone

    and PostPaymentIntentsIntentPaymentMethodDataBillingDetailsAddressBillingDetailsAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostPaymentIntentsIntentPaymentMethodDataFpx (?accountHolderType: PostPaymentIntentsIntentPaymentMethodDataFpxAccountHolderType, ?bank: PostPaymentIntentsIntentPaymentMethodDataFpxBank) =
        ///Account holder type for FPX transaction
        member _.AccountHolderType = accountHolderType
        ///The customer's bank.
        member _.Bank = bank

    and PostPaymentIntentsIntentPaymentMethodDataFpxAccountHolderType =
        | Company
        | Individual

    and PostPaymentIntentsIntentPaymentMethodDataFpxBank =
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

    and PostPaymentIntentsIntentPaymentMethodDataIdeal (?bank: PostPaymentIntentsIntentPaymentMethodDataIdealBank) =
        ///The customer's bank.
        member _.Bank = bank

    and PostPaymentIntentsIntentPaymentMethodDataIdealBank =
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

    and PostPaymentIntentsIntentPaymentMethodDataP24 (?bank: PostPaymentIntentsIntentPaymentMethodDataP24Bank) =
        ///The customer's bank.
        member _.Bank = bank

    and PostPaymentIntentsIntentPaymentMethodDataP24Bank =
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

    and PostPaymentIntentsIntentPaymentMethodDataSepaDebit (?iban: string) =
        ///IBAN of the bank account.
        member _.Iban = iban

    and PostPaymentIntentsIntentPaymentMethodDataSofort (?country: PostPaymentIntentsIntentPaymentMethodDataSofortCountry) =
        ///Two-letter ISO code representing the country the bank account is located in.
        member _.Country = country

    and PostPaymentIntentsIntentPaymentMethodDataSofortCountry =
        | [<JsonUnionCase("AT")>] AT
        | [<JsonUnionCase("BE")>] BE
        | [<JsonUnionCase("DE")>] DE
        | [<JsonUnionCase("ES")>] ES
        | [<JsonUnionCase("IT")>] IT
        | [<JsonUnionCase("NL")>] NL

    and PostPaymentIntentsIntentPaymentMethodOptions (?alipay: Choice<string,string>, ?bancontact: Choice<PostPaymentIntentsIntentPaymentMethodOptionsBancontactPaymentMethodOptions,string>, ?card: Choice<PostPaymentIntentsIntentPaymentMethodOptionsCardPaymentIntent,string>, ?oxxo: Choice<PostPaymentIntentsIntentPaymentMethodOptionsOxxoPaymentMethodOptions,string>, ?p24: Choice<string,string>, ?sepaDebit: Choice<PostPaymentIntentsIntentPaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptions,string>, ?sofort: Choice<PostPaymentIntentsIntentPaymentMethodOptionsSofortPaymentMethodOptions,string>) =
        ///If this is a `alipay` PaymentMethod, this sub-hash contains details about the Alipay payment method options.
        member _.Alipay = alipay
        ///If this is a `bancontact` PaymentMethod, this sub-hash contains details about the Bancontact payment method options.
        member _.Bancontact = bancontact
        ///Configuration for any card payments attempted on this PaymentIntent.
        member _.Card = card
        ///If this is a `oxxo` PaymentMethod, this sub-hash contains details about the OXXO payment method options.
        member _.Oxxo = oxxo
        ///If this is a `p24` PaymentMethod, this sub-hash contains details about the Przelewy24 payment method options.
        member _.P24 = p24
        ///If this is a `sepa_debit` PaymentIntent, this sub-hash contains details about the SEPA Debit payment method options.
        member _.SepaDebit = sepaDebit
        ///If this is a `sofort` PaymentMethod, this sub-hash contains details about the SOFORT payment method options.
        member _.Sofort = sofort

    and PostPaymentIntentsIntentPaymentMethodOptionsBancontactPaymentMethodOptions (?preferredLanguage: PostPaymentIntentsIntentPaymentMethodOptionsBancontactPaymentMethodOptionsPreferredLanguage) =
        ///Preferred language of the Bancontact authorization page that the customer is redirected to.
        member _.PreferredLanguage = preferredLanguage

    and PostPaymentIntentsIntentPaymentMethodOptionsBancontactPaymentMethodOptionsPreferredLanguage =
        | De
        | En
        | Fr
        | Nl

    and PostPaymentIntentsIntentPaymentMethodOptionsCardPaymentIntent (?cvcToken: string, ?installments: PostPaymentIntentsIntentPaymentMethodOptionsCardPaymentIntentInstallments, ?moto: bool, ?network: PostPaymentIntentsIntentPaymentMethodOptionsCardPaymentIntentNetwork, ?requestThreeDSecure: PostPaymentIntentsIntentPaymentMethodOptionsCardPaymentIntentRequestThreeDSecure) =
        ///A single-use `cvc_update` Token that represents a card CVC value. When provided, the CVC value will be verified during the card payment attempt. This parameter can only be provided during confirmation.
        member _.CvcToken = cvcToken
        ///Installment configuration for payments attempted on this PaymentIntent (Mexico Only).
        ///For more information, see the [installments integration guide](https://stripe.com/docs/payments/installments).
        member _.Installments = installments
        ///When specified, this parameter indicates that a transaction will be marked
        ///as MOTO (Mail Order Telephone Order) and thus out of scope for SCA. This
        ///parameter can only be provided during confirmation.
        member _.Moto = moto
        ///Selected network to process this PaymentIntent on. Depends on the available networks of the card attached to the PaymentIntent. Can be only set confirm-time.
        member _.Network = network
        ///We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://stripe.com/docs/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Permitted values include: `automatic` or `any`. If not provided, defaults to `automatic`. Read our guide on [manually requesting 3D Secure](https://stripe.com/docs/payments/3d-secure#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
        member _.RequestThreeDSecure = requestThreeDSecure

    and PostPaymentIntentsIntentPaymentMethodOptionsCardPaymentIntentNetwork =
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

    and PostPaymentIntentsIntentPaymentMethodOptionsCardPaymentIntentRequestThreeDSecure =
        | Any
        | Automatic

    and PostPaymentIntentsIntentPaymentMethodOptionsCardPaymentIntentInstallments (?enabled: bool, ?plan: Choice<PostPaymentIntentsIntentPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlan,string>) =
        ///Setting to true enables installments for this PaymentIntent.
        ///This will cause the response to contain a list of available installment plans.
        ///Setting to false will prevent any selected plan from applying to a charge.
        member _.Enabled = enabled
        ///The selected installment plan to use for this payment attempt.
        ///This parameter can only be provided during confirmation.
        member _.Plan = plan

    and PostPaymentIntentsIntentPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlan (?count: int, ?interval: PostPaymentIntentsIntentPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanInterval, ?``type``: PostPaymentIntentsIntentPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanType) =
        ///For `fixed_count` installment plans, this is the number of installment payments your customer will make to their credit card.
        member _.Count = count
        ///For `fixed_count` installment plans, this is the interval between installment payments your customer will make to their credit card.
        ///One of `month`.
        member _.Interval = interval
        ///Type of installment plan, one of `fixed_count`.
        member _.Type = ``type``

    and PostPaymentIntentsIntentPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanInterval =
        | Month

    and PostPaymentIntentsIntentPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanType =
        | FixedCount

    and PostPaymentIntentsIntentPaymentMethodOptionsOxxoPaymentMethodOptions (?expiresAfterDays: int) =
        ///The number of calendar days before an OXXO voucher expires. For example, if you create an OXXO voucher on Monday and you set expires_after_days to 2, the OXXO invoice will expire on Wednesday at 23:59 America/Mexico_City time.
        member _.ExpiresAfterDays = expiresAfterDays

    and PostPaymentIntentsIntentPaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptions (?mandateOptions: string) =
        ///Additional fields for Mandate creation
        member _.MandateOptions = mandateOptions

    and PostPaymentIntentsIntentPaymentMethodOptionsSofortPaymentMethodOptions (?preferredLanguage: PostPaymentIntentsIntentPaymentMethodOptionsSofortPaymentMethodOptionsPreferredLanguage) =
        ///Language shown to the payer on redirect.
        member _.PreferredLanguage = preferredLanguage

    and PostPaymentIntentsIntentPaymentMethodOptionsSofortPaymentMethodOptionsPreferredLanguage =
        | De
        | En
        | Es
        | Fr
        | It
        | Nl
        | Pl

    and PostPaymentIntentsIntentShippingShipping (?address: PostPaymentIntentsIntentShippingShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
        ///Shipping address.
        member _.Address = address
        ///The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc.
        member _.Carrier = carrier
        ///Recipient name.
        member _.Name = name
        ///Recipient phone (including extension).
        member _.Phone = phone
        ///The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
        member _.TrackingNumber = trackingNumber

    and PostPaymentIntentsIntentShippingShippingAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostPaymentIntentsIntentTransferData (?amount: int) =
        ///The amount that will be transferred automatically when a charge succeeds.
        member _.Amount = amount

    and PostPaymentIntentsIntentCancelParams (?cancellationReason: PostPaymentIntentsIntentCancelCancellationReason, ?expand: string list) =
        ///Reason for canceling this PaymentIntent. Possible values are `duplicate`, `fraudulent`, `requested_by_customer`, or `abandoned`
        member _.CancellationReason = cancellationReason
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand

    and PostPaymentIntentsIntentCancelCancellationReason =
        | Abandoned
        | Duplicate
        | Fraudulent
        | RequestedByCustomer

    and PostPaymentIntentsIntentCaptureParams (?amountToCapture: int, ?applicationFeeAmount: int, ?expand: string list, ?statementDescriptor: string, ?statementDescriptorSuffix: string, ?transferData: PostPaymentIntentsIntentCaptureTransferData) =
        ///The amount to capture from the PaymentIntent, which must be less than or equal to the original amount. Any additional amount will be automatically refunded. Defaults to the full `amount_capturable` if not provided.
        member _.AmountToCapture = amountToCapture
        ///The amount of the application fee (if any) that will be requested to be applied to the payment and transferred to the application owner's Stripe account. The amount of the application fee collected will be capped at the total payment amount. For more information, see the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts).
        member _.ApplicationFeeAmount = applicationFeeAmount
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///For non-card charges, you can use this value as the complete description that appears on your customers’ statements. Must contain at least one letter, maximum 22 characters.
        member _.StatementDescriptor = statementDescriptor
        ///Provides information about a card payment that customers see on their statements. Concatenated with the prefix (shortened descriptor) or statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 22 characters for the concatenated descriptor.
        member _.StatementDescriptorSuffix = statementDescriptorSuffix
        ///The parameters used to automatically create a Transfer when the payment
        ///is captured. For more information, see the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts).
        member _.TransferData = transferData

    and PostPaymentIntentsIntentCaptureTransferData (?amount: int) =
        ///The amount that will be transferred automatically when a charge succeeds.
        member _.Amount = amount

    and PostPaymentIntentsIntentConfirmParams (?errorOnRequiresAction: bool, ?expand: string list, ?mandate: string, ?mandateData: Choice<PostPaymentIntentsIntentConfirmMandateDataSecretKey,PostPaymentIntentsIntentConfirmMandateDataClientKey>, ?offSession: Choice<bool,PostPaymentIntentsIntentConfirmOffSession>, ?paymentMethod: string, ?paymentMethodData: PostPaymentIntentsIntentConfirmPaymentMethodData, ?paymentMethodOptions: PostPaymentIntentsIntentConfirmPaymentMethodOptions, ?receiptEmail: Choice<string,string>, ?returnUrl: string, ?setupFutureUsage: PostPaymentIntentsIntentConfirmSetupFutureUsage, ?shipping: Choice<PostPaymentIntentsIntentConfirmShippingShipping,string>, ?useStripeSdk: bool) =
        ///Set to `true` to fail the payment attempt if the PaymentIntent transitions into `requires_action`. This parameter is intended for simpler integrations that do not handle customer actions, like [saving cards without authentication](https://stripe.com/docs/payments/save-card-without-authentication).
        member _.ErrorOnRequiresAction = errorOnRequiresAction
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///ID of the mandate to be used for this payment.
        member _.Mandate = mandate
        ///This hash contains details about the Mandate to create
        member _.MandateData = mandateData
        ///Set to `true` to indicate that the customer is not in your checkout flow during this payment attempt, and therefore is unable to authenticate. This parameter is intended for scenarios where you collect card details and [charge them later](https://stripe.com/docs/payments/cards/charging-saved-cards).
        member _.OffSession = offSession
        ///ID of the payment method (a PaymentMethod, Card, or [compatible Source](https://stripe.com/docs/payments/payment-methods#compatibility) object) to attach to this PaymentIntent.
        member _.PaymentMethod = paymentMethod
        ///If provided, this hash will be used to create a PaymentMethod. The new PaymentMethod will appear
        ///in the [payment_method](https://stripe.com/docs/api/payment_intents/object#payment_intent_object-payment_method)
        ///property on the PaymentIntent.
        member _.PaymentMethodData = paymentMethodData
        ///Payment-method-specific configuration for this PaymentIntent.
        member _.PaymentMethodOptions = paymentMethodOptions
        ///Email address that the receipt for the resulting payment will be sent to. If `receipt_email` is specified for a payment in live mode, a receipt will be sent regardless of your [email settings](https://dashboard.stripe.com/account/emails).
        member _.ReceiptEmail = receiptEmail
        ///The URL to redirect your customer back to after they authenticate or cancel their payment on the payment method's app or site.
        ///If you'd prefer to redirect to a mobile application, you can alternatively supply an application URI scheme.
        ///This parameter is only used for cards and other redirect-based payment methods.
        member _.ReturnUrl = returnUrl
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        member _.SetupFutureUsage = setupFutureUsage
        ///Shipping information for this PaymentIntent.
        member _.Shipping = shipping
        ///Set to `true` only when using manual confirmation and the iOS or Android SDKs to handle additional authentication steps.
        member _.UseStripeSdk = useStripeSdk

    and PostPaymentIntentsIntentConfirmSetupFutureUsage =
        | OffSession
        | OnSession

    and PostPaymentIntentsIntentConfirmMandateDataSecretKey (?customerAcceptance: PostPaymentIntentsIntentConfirmMandateDataSecretKeyCustomerAcceptance) =
        ///This hash contains details about the customer acceptance of the Mandate.
        member _.CustomerAcceptance = customerAcceptance

    and PostPaymentIntentsIntentConfirmMandateDataSecretKeyCustomerAcceptance (?acceptedAt: DateTime, ?offline: string, ?online: PostPaymentIntentsIntentConfirmMandateDataSecretKeyCustomerAcceptanceOnline, ?``type``: PostPaymentIntentsIntentConfirmMandateDataSecretKeyCustomerAcceptanceType) =
        ///The time at which the customer accepted the Mandate.
        member _.AcceptedAt = acceptedAt
        ///If this is a Mandate accepted offline, this hash contains details about the offline acceptance.
        member _.Offline = offline
        ///If this is a Mandate accepted online, this hash contains details about the online acceptance.
        member _.Online = online
        ///The type of customer acceptance information included with the Mandate. One of `online` or `offline`.
        member _.Type = ``type``

    and PostPaymentIntentsIntentConfirmMandateDataSecretKeyCustomerAcceptanceType =
        | Offline
        | Online

    and PostPaymentIntentsIntentConfirmMandateDataSecretKeyCustomerAcceptanceOnline (?ipAddress: string, ?userAgent: string) =
        ///The IP address from which the Mandate was accepted by the customer.
        member _.IpAddress = ipAddress
        ///The user agent of the browser from which the Mandate was accepted by the customer.
        member _.UserAgent = userAgent

    and PostPaymentIntentsIntentConfirmMandateDataClientKey (?customerAcceptance: PostPaymentIntentsIntentConfirmMandateDataClientKeyCustomerAcceptance) =
        ///This hash contains details about the customer acceptance of the Mandate.
        member _.CustomerAcceptance = customerAcceptance

    and PostPaymentIntentsIntentConfirmMandateDataClientKeyCustomerAcceptance (?online: PostPaymentIntentsIntentConfirmMandateDataClientKeyCustomerAcceptanceOnline, ?``type``: PostPaymentIntentsIntentConfirmMandateDataClientKeyCustomerAcceptanceType) =
        ///If this is a Mandate accepted online, this hash contains details about the online acceptance.
        member _.Online = online
        ///The type of customer acceptance information included with the Mandate.
        member _.Type = ``type``

    and PostPaymentIntentsIntentConfirmMandateDataClientKeyCustomerAcceptanceType =
        | Online

    and PostPaymentIntentsIntentConfirmMandateDataClientKeyCustomerAcceptanceOnline (?ipAddress: string, ?userAgent: string) =
        ///The IP address from which the Mandate was accepted by the customer.
        member _.IpAddress = ipAddress
        ///The user agent of the browser from which the Mandate was accepted by the customer.
        member _.UserAgent = userAgent

    and PostPaymentIntentsIntentConfirmOffSession =
        | OneOff
        | Recurring

    and PostPaymentIntentsIntentConfirmPaymentMethodData (?alipay: string, ?sepaDebit: PostPaymentIntentsIntentConfirmPaymentMethodDataSepaDebit, ?p24: PostPaymentIntentsIntentConfirmPaymentMethodDataP24, ?oxxo: string, ?metadata: Map<string, string>, ?interacPresent: string, ?ideal: PostPaymentIntentsIntentConfirmPaymentMethodDataIdeal, ?sofort: PostPaymentIntentsIntentConfirmPaymentMethodDataSofort, ?grabpay: string, ?fpx: PostPaymentIntentsIntentConfirmPaymentMethodDataFpx, ?eps: string, ?billingDetails: PostPaymentIntentsIntentConfirmPaymentMethodDataBillingDetails, ?bancontact: string, ?bacsDebit: PostPaymentIntentsIntentConfirmPaymentMethodDataBacsDebit, ?auBecsDebit: PostPaymentIntentsIntentConfirmPaymentMethodDataAuBecsDebit, ?giropay: string, ?``type``: PostPaymentIntentsIntentConfirmPaymentMethodDataType) =
        ///If this is an `Alipay` PaymentMethod, this hash contains details about the Alipay payment method.
        member _.Alipay = alipay
        ///If this is an `au_becs_debit` PaymentMethod, this hash contains details about the bank account.
        member _.AuBecsDebit = auBecsDebit
        ///If this is a `bacs_debit` PaymentMethod, this hash contains details about the Bacs Direct Debit bank account.
        member _.BacsDebit = bacsDebit
        ///If this is a `bancontact` PaymentMethod, this hash contains details about the Bancontact payment method.
        member _.Bancontact = bancontact
        ///Billing information associated with the PaymentMethod that may be used or required by particular types of payment methods.
        member _.BillingDetails = billingDetails
        ///If this is an `eps` PaymentMethod, this hash contains details about the EPS payment method.
        member _.Eps = eps
        ///If this is an `fpx` PaymentMethod, this hash contains details about the FPX payment method.
        member _.Fpx = fpx
        ///If this is a `giropay` PaymentMethod, this hash contains details about the Giropay payment method.
        member _.Giropay = giropay
        ///If this is a `grabpay` PaymentMethod, this hash contains details about the GrabPay payment method.
        member _.Grabpay = grabpay
        ///If this is an `ideal` PaymentMethod, this hash contains details about the iDEAL payment method.
        member _.Ideal = ideal
        ///If this is an `interac_present` PaymentMethod, this hash contains details about the Interac Present payment method.
        member _.InteracPresent = interacPresent
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///If this is an `oxxo` PaymentMethod, this hash contains details about the OXXO payment method.
        member _.Oxxo = oxxo
        ///If this is a `p24` PaymentMethod, this hash contains details about the P24 payment method.
        member _.P24 = p24
        ///If this is a `sepa_debit` PaymentMethod, this hash contains details about the SEPA debit bank account.
        member _.SepaDebit = sepaDebit
        ///If this is a `sofort` PaymentMethod, this hash contains details about the SOFORT payment method.
        member _.Sofort = sofort
        ///The type of the PaymentMethod. An additional hash is included on the PaymentMethod with a name matching this value. It contains additional information specific to the PaymentMethod type.
        member _.Type = ``type``

    and PostPaymentIntentsIntentConfirmPaymentMethodDataType =
        | Alipay
        | AuBecsDebit
        | BacsDebit
        | Bancontact
        | Eps
        | Fpx
        | Giropay
        | Grabpay
        | Ideal
        | Oxxo
        | P24
        | SepaDebit
        | Sofort

    and PostPaymentIntentsIntentConfirmPaymentMethodDataAuBecsDebit (?accountNumber: string, ?bsbNumber: string) =
        ///The account number for the bank account.
        member _.AccountNumber = accountNumber
        ///Bank-State-Branch number of the bank account.
        member _.BsbNumber = bsbNumber

    and PostPaymentIntentsIntentConfirmPaymentMethodDataBacsDebit (?accountNumber: string, ?sortCode: string) =
        ///Account number of the bank account that the funds will be debited from.
        member _.AccountNumber = accountNumber
        ///Sort code of the bank account. (e.g., `10-20-30`)
        member _.SortCode = sortCode

    and PostPaymentIntentsIntentConfirmPaymentMethodDataBillingDetails (?address: Choice<PostPaymentIntentsIntentConfirmPaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string>, ?email: string, ?name: string, ?phone: string) =
        ///Billing address.
        member _.Address = address
        ///Email address.
        member _.Email = email
        ///Full name.
        member _.Name = name
        ///Billing phone number (including extension).
        member _.Phone = phone

    and PostPaymentIntentsIntentConfirmPaymentMethodDataBillingDetailsAddressBillingDetailsAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostPaymentIntentsIntentConfirmPaymentMethodDataFpx (?accountHolderType: PostPaymentIntentsIntentConfirmPaymentMethodDataFpxAccountHolderType, ?bank: PostPaymentIntentsIntentConfirmPaymentMethodDataFpxBank) =
        ///Account holder type for FPX transaction
        member _.AccountHolderType = accountHolderType
        ///The customer's bank.
        member _.Bank = bank

    and PostPaymentIntentsIntentConfirmPaymentMethodDataFpxAccountHolderType =
        | Company
        | Individual

    and PostPaymentIntentsIntentConfirmPaymentMethodDataFpxBank =
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

    and PostPaymentIntentsIntentConfirmPaymentMethodDataIdeal (?bank: PostPaymentIntentsIntentConfirmPaymentMethodDataIdealBank) =
        ///The customer's bank.
        member _.Bank = bank

    and PostPaymentIntentsIntentConfirmPaymentMethodDataIdealBank =
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

    and PostPaymentIntentsIntentConfirmPaymentMethodDataP24 (?bank: PostPaymentIntentsIntentConfirmPaymentMethodDataP24Bank) =
        ///The customer's bank.
        member _.Bank = bank

    and PostPaymentIntentsIntentConfirmPaymentMethodDataP24Bank =
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

    and PostPaymentIntentsIntentConfirmPaymentMethodDataSepaDebit (?iban: string) =
        ///IBAN of the bank account.
        member _.Iban = iban

    and PostPaymentIntentsIntentConfirmPaymentMethodDataSofort (?country: PostPaymentIntentsIntentConfirmPaymentMethodDataSofortCountry) =
        ///Two-letter ISO code representing the country the bank account is located in.
        member _.Country = country

    and PostPaymentIntentsIntentConfirmPaymentMethodDataSofortCountry =
        | [<JsonUnionCase("AT")>] AT
        | [<JsonUnionCase("BE")>] BE
        | [<JsonUnionCase("DE")>] DE
        | [<JsonUnionCase("ES")>] ES
        | [<JsonUnionCase("IT")>] IT
        | [<JsonUnionCase("NL")>] NL

    and PostPaymentIntentsIntentConfirmPaymentMethodOptions (?alipay: Choice<string,string>, ?bancontact: Choice<PostPaymentIntentsIntentConfirmPaymentMethodOptionsBancontactPaymentMethodOptions,string>, ?card: Choice<PostPaymentIntentsIntentConfirmPaymentMethodOptionsCardPaymentIntent,string>, ?oxxo: Choice<PostPaymentIntentsIntentConfirmPaymentMethodOptionsOxxoPaymentMethodOptions,string>, ?p24: Choice<string,string>, ?sepaDebit: Choice<PostPaymentIntentsIntentConfirmPaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptions,string>, ?sofort: Choice<PostPaymentIntentsIntentConfirmPaymentMethodOptionsSofortPaymentMethodOptions,string>) =
        ///If this is a `alipay` PaymentMethod, this sub-hash contains details about the Alipay payment method options.
        member _.Alipay = alipay
        ///If this is a `bancontact` PaymentMethod, this sub-hash contains details about the Bancontact payment method options.
        member _.Bancontact = bancontact
        ///Configuration for any card payments attempted on this PaymentIntent.
        member _.Card = card
        ///If this is a `oxxo` PaymentMethod, this sub-hash contains details about the OXXO payment method options.
        member _.Oxxo = oxxo
        ///If this is a `p24` PaymentMethod, this sub-hash contains details about the Przelewy24 payment method options.
        member _.P24 = p24
        ///If this is a `sepa_debit` PaymentIntent, this sub-hash contains details about the SEPA Debit payment method options.
        member _.SepaDebit = sepaDebit
        ///If this is a `sofort` PaymentMethod, this sub-hash contains details about the SOFORT payment method options.
        member _.Sofort = sofort

    and PostPaymentIntentsIntentConfirmPaymentMethodOptionsBancontactPaymentMethodOptions (?preferredLanguage: PostPaymentIntentsIntentConfirmPaymentMethodOptionsBancontactPaymentMethodOptionsPreferredLanguage) =
        ///Preferred language of the Bancontact authorization page that the customer is redirected to.
        member _.PreferredLanguage = preferredLanguage

    and PostPaymentIntentsIntentConfirmPaymentMethodOptionsBancontactPaymentMethodOptionsPreferredLanguage =
        | De
        | En
        | Fr
        | Nl

    and PostPaymentIntentsIntentConfirmPaymentMethodOptionsCardPaymentIntent (?cvcToken: string, ?installments: PostPaymentIntentsIntentConfirmPaymentMethodOptionsCardPaymentIntentInstallments, ?moto: bool, ?network: PostPaymentIntentsIntentConfirmPaymentMethodOptionsCardPaymentIntentNetwork, ?requestThreeDSecure: PostPaymentIntentsIntentConfirmPaymentMethodOptionsCardPaymentIntentRequestThreeDSecure) =
        ///A single-use `cvc_update` Token that represents a card CVC value. When provided, the CVC value will be verified during the card payment attempt. This parameter can only be provided during confirmation.
        member _.CvcToken = cvcToken
        ///Installment configuration for payments attempted on this PaymentIntent (Mexico Only).
        ///For more information, see the [installments integration guide](https://stripe.com/docs/payments/installments).
        member _.Installments = installments
        ///When specified, this parameter indicates that a transaction will be marked
        ///as MOTO (Mail Order Telephone Order) and thus out of scope for SCA. This
        ///parameter can only be provided during confirmation.
        member _.Moto = moto
        ///Selected network to process this PaymentIntent on. Depends on the available networks of the card attached to the PaymentIntent. Can be only set confirm-time.
        member _.Network = network
        ///We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://stripe.com/docs/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Permitted values include: `automatic` or `any`. If not provided, defaults to `automatic`. Read our guide on [manually requesting 3D Secure](https://stripe.com/docs/payments/3d-secure#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
        member _.RequestThreeDSecure = requestThreeDSecure

    and PostPaymentIntentsIntentConfirmPaymentMethodOptionsCardPaymentIntentNetwork =
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

    and PostPaymentIntentsIntentConfirmPaymentMethodOptionsCardPaymentIntentRequestThreeDSecure =
        | Any
        | Automatic

    and PostPaymentIntentsIntentConfirmPaymentMethodOptionsCardPaymentIntentInstallments (?enabled: bool, ?plan: Choice<PostPaymentIntentsIntentConfirmPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlan,string>) =
        ///Setting to true enables installments for this PaymentIntent.
        ///This will cause the response to contain a list of available installment plans.
        ///Setting to false will prevent any selected plan from applying to a charge.
        member _.Enabled = enabled
        ///The selected installment plan to use for this payment attempt.
        ///This parameter can only be provided during confirmation.
        member _.Plan = plan

    and PostPaymentIntentsIntentConfirmPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlan (?count: int, ?interval: PostPaymentIntentsIntentConfirmPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanInterval, ?``type``: PostPaymentIntentsIntentConfirmPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanType) =
        ///For `fixed_count` installment plans, this is the number of installment payments your customer will make to their credit card.
        member _.Count = count
        ///For `fixed_count` installment plans, this is the interval between installment payments your customer will make to their credit card.
        ///One of `month`.
        member _.Interval = interval
        ///Type of installment plan, one of `fixed_count`.
        member _.Type = ``type``

    and PostPaymentIntentsIntentConfirmPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanInterval =
        | Month

    and PostPaymentIntentsIntentConfirmPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanType =
        | FixedCount

    and PostPaymentIntentsIntentConfirmPaymentMethodOptionsOxxoPaymentMethodOptions (?expiresAfterDays: int) =
        ///The number of calendar days before an OXXO voucher expires. For example, if you create an OXXO voucher on Monday and you set expires_after_days to 2, the OXXO invoice will expire on Wednesday at 23:59 America/Mexico_City time.
        member _.ExpiresAfterDays = expiresAfterDays

    and PostPaymentIntentsIntentConfirmPaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptions (?mandateOptions: string) =
        ///Additional fields for Mandate creation
        member _.MandateOptions = mandateOptions

    and PostPaymentIntentsIntentConfirmPaymentMethodOptionsSofortPaymentMethodOptions (?preferredLanguage: PostPaymentIntentsIntentConfirmPaymentMethodOptionsSofortPaymentMethodOptionsPreferredLanguage) =
        ///Language shown to the payer on redirect.
        member _.PreferredLanguage = preferredLanguage

    and PostPaymentIntentsIntentConfirmPaymentMethodOptionsSofortPaymentMethodOptionsPreferredLanguage =
        | De
        | En
        | Es
        | Fr
        | It
        | Nl
        | Pl

    and PostPaymentIntentsIntentConfirmShippingShipping (?address: PostPaymentIntentsIntentConfirmShippingShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
        ///Shipping address.
        member _.Address = address
        ///The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc.
        member _.Carrier = carrier
        ///Recipient name.
        member _.Name = name
        ///Recipient phone (including extension).
        member _.Phone = phone
        ///The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
        member _.TrackingNumber = trackingNumber

    and PostPaymentIntentsIntentConfirmShippingShippingAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostPaymentMethodsParams (?alipay: string, ?sepaDebit: PostPaymentMethodsSepaDebit, ?paymentMethod: string, ?p24: PostPaymentMethodsP24, ?oxxo: string, ?metadata: Map<string, string>, ?interacPresent: string, ?ideal: PostPaymentMethodsIdeal, ?grabpay: string, ?sofort: PostPaymentMethodsSofort, ?giropay: string, ?expand: string list, ?eps: string, ?customer: string, ?card: Choice<PostPaymentMethodsCardCardDetailsParams,PostPaymentMethodsCardTokenParams>, ?billingDetails: PostPaymentMethodsBillingDetails, ?bancontact: string, ?bacsDebit: PostPaymentMethodsBacsDebit, ?auBecsDebit: PostPaymentMethodsAuBecsDebit, ?fpx: PostPaymentMethodsFpx, ?``type``: PostPaymentMethodsType) =
        ///If this is an `Alipay` PaymentMethod, this hash contains details about the Alipay payment method.
        member _.Alipay = alipay
        ///If this is an `au_becs_debit` PaymentMethod, this hash contains details about the bank account.
        member _.AuBecsDebit = auBecsDebit
        ///If this is a `bacs_debit` PaymentMethod, this hash contains details about the Bacs Direct Debit bank account.
        member _.BacsDebit = bacsDebit
        ///If this is a `bancontact` PaymentMethod, this hash contains details about the Bancontact payment method.
        member _.Bancontact = bancontact
        ///Billing information associated with the PaymentMethod that may be used or required by particular types of payment methods.
        member _.BillingDetails = billingDetails
        ///If this is a `card` PaymentMethod, this hash contains the user's card details. For backwards compatibility, you can alternatively provide a Stripe token (e.g., for Apple Pay, Amex Express Checkout, or legacy Checkout) into the card hash with format `card: {token: "tok_visa"}`. When providing a card number, you must meet the requirements for [PCI compliance](https://stripe.com/docs/security#validating-pci-compliance). We strongly recommend using Stripe.js instead of interacting with this API directly.
        member _.Card = card
        ///The `Customer` to whom the original PaymentMethod is attached.
        member _.Customer = customer
        ///If this is an `eps` PaymentMethod, this hash contains details about the EPS payment method.
        member _.Eps = eps
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///If this is an `fpx` PaymentMethod, this hash contains details about the FPX payment method.
        member _.Fpx = fpx
        ///If this is a `giropay` PaymentMethod, this hash contains details about the Giropay payment method.
        member _.Giropay = giropay
        ///If this is a `grabpay` PaymentMethod, this hash contains details about the GrabPay payment method.
        member _.Grabpay = grabpay
        ///If this is an `ideal` PaymentMethod, this hash contains details about the iDEAL payment method.
        member _.Ideal = ideal
        ///If this is an `interac_present` PaymentMethod, this hash contains details about the Interac Present payment method.
        member _.InteracPresent = interacPresent
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///If this is an `oxxo` PaymentMethod, this hash contains details about the OXXO payment method.
        member _.Oxxo = oxxo
        ///If this is a `p24` PaymentMethod, this hash contains details about the P24 payment method.
        member _.P24 = p24
        ///The PaymentMethod to share.
        member _.PaymentMethod = paymentMethod
        ///If this is a `sepa_debit` PaymentMethod, this hash contains details about the SEPA debit bank account.
        member _.SepaDebit = sepaDebit
        ///If this is a `sofort` PaymentMethod, this hash contains details about the SOFORT payment method.
        member _.Sofort = sofort
        ///The type of the PaymentMethod. An additional hash is included on the PaymentMethod with a name matching this value. It contains additional information specific to the PaymentMethod type.
        member _.Type = ``type``

    and PostPaymentMethodsType =
        | Alipay
        | AuBecsDebit
        | BacsDebit
        | Bancontact
        | Card
        | Eps
        | Fpx
        | Giropay
        | Grabpay
        | Ideal
        | Oxxo
        | P24
        | SepaDebit
        | Sofort

    and PostPaymentMethodsAuBecsDebit (?accountNumber: string, ?bsbNumber: string) =
        ///The account number for the bank account.
        member _.AccountNumber = accountNumber
        ///Bank-State-Branch number of the bank account.
        member _.BsbNumber = bsbNumber

    and PostPaymentMethodsBacsDebit (?accountNumber: string, ?sortCode: string) =
        ///Account number of the bank account that the funds will be debited from.
        member _.AccountNumber = accountNumber
        ///Sort code of the bank account. (e.g., `10-20-30`)
        member _.SortCode = sortCode

    and PostPaymentMethodsBillingDetails (?address: Choice<PostPaymentMethodsBillingDetailsAddressBillingDetailsAddress,string>, ?email: string, ?name: string, ?phone: string) =
        ///Billing address.
        member _.Address = address
        ///Email address.
        member _.Email = email
        ///Full name.
        member _.Name = name
        ///Billing phone number (including extension).
        member _.Phone = phone

    and PostPaymentMethodsBillingDetailsAddressBillingDetailsAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostPaymentMethodsCardCardDetailsParams (?cvc: string, ?expMonth: int, ?expYear: int, ?number: string) =
        ///The card's CVC. It is highly recommended to always include this value.
        member _.Cvc = cvc
        ///Two-digit number representing the card's expiration month.
        member _.ExpMonth = expMonth
        ///Four-digit number representing the card's expiration year.
        member _.ExpYear = expYear
        ///The card number, as a string without any separators.
        member _.Number = number

    and PostPaymentMethodsCardTokenParams (?token: string) =
        ///
        member _.Token = token

    and PostPaymentMethodsFpx (?accountHolderType: PostPaymentMethodsFpxAccountHolderType, ?bank: PostPaymentMethodsFpxBank) =
        ///Account holder type for FPX transaction
        member _.AccountHolderType = accountHolderType
        ///The customer's bank.
        member _.Bank = bank

    and PostPaymentMethodsFpxAccountHolderType =
        | Company
        | Individual

    and PostPaymentMethodsFpxBank =
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

    and PostPaymentMethodsIdeal (?bank: PostPaymentMethodsIdealBank) =
        ///The customer's bank.
        member _.Bank = bank

    and PostPaymentMethodsIdealBank =
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

    and PostPaymentMethodsP24 (?bank: PostPaymentMethodsP24Bank) =
        ///The customer's bank.
        member _.Bank = bank

    and PostPaymentMethodsP24Bank =
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

    and PostPaymentMethodsSepaDebit (?iban: string) =
        ///IBAN of the bank account.
        member _.Iban = iban

    and PostPaymentMethodsSofort (?country: PostPaymentMethodsSofortCountry) =
        ///Two-letter ISO code representing the country the bank account is located in.
        member _.Country = country

    and PostPaymentMethodsSofortCountry =
        | [<JsonUnionCase("AT")>] AT
        | [<JsonUnionCase("BE")>] BE
        | [<JsonUnionCase("DE")>] DE
        | [<JsonUnionCase("ES")>] ES
        | [<JsonUnionCase("IT")>] IT
        | [<JsonUnionCase("NL")>] NL

    and PostPaymentMethodsPaymentMethodParams (?auBecsDebit: string, ?billingDetails: PostPaymentMethodsPaymentMethodBillingDetails, ?card: PostPaymentMethodsPaymentMethodCard, ?expand: string list, ?metadata: Map<string, string>, ?sepaDebit: string) =
        ///This is a legacy parameter that will be removed in the future. It is a hash that does not accept any keys.
        member _.AuBecsDebit = auBecsDebit
        ///Billing information associated with the PaymentMethod that may be used or required by particular types of payment methods.
        member _.BillingDetails = billingDetails
        ///If this is a `card` PaymentMethod, this hash contains the user's card details.
        member _.Card = card
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///This is a legacy parameter that will be removed in the future. It is a hash that does not accept any keys.
        member _.SepaDebit = sepaDebit

    and PostPaymentMethodsPaymentMethodBillingDetails (?address: Choice<PostPaymentMethodsPaymentMethodBillingDetailsAddressBillingDetailsAddress,string>, ?email: string, ?name: string, ?phone: string) =
        ///Billing address.
        member _.Address = address
        ///Email address.
        member _.Email = email
        ///Full name.
        member _.Name = name
        ///Billing phone number (including extension).
        member _.Phone = phone

    and PostPaymentMethodsPaymentMethodBillingDetailsAddressBillingDetailsAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostPaymentMethodsPaymentMethodCard (?expMonth: int, ?expYear: int) =
        ///Two-digit number representing the card's expiration month.
        member _.ExpMonth = expMonth
        ///Four-digit number representing the card's expiration year.
        member _.ExpYear = expYear

    and PostPaymentMethodsPaymentMethodAttachParams (customer: string, ?expand: string list) =
        ///The ID of the customer to which to attach the PaymentMethod.
        member _.Customer = customer
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand

    and PostPaymentMethodsPaymentMethodDetachParams (?expand: string list) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand

    and PostPayoutsParams (amount: int, currency: string, ?description: string, ?destination: string, ?expand: string list, ?metadata: Map<string, string>, ?method: PostPayoutsMethod, ?sourceType: PostPayoutsSourceType, ?statementDescriptor: string) =
        ///A positive integer in cents representing how much to payout.
        member _.Amount = amount
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        member _.Description = description
        ///The ID of a bank account or a card to send the payout to. If no destination is supplied, the default external account for the specified currency will be used.
        member _.Destination = destination
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The method used to send this payout, which can be `standard` or `instant`. `instant` is only supported for payouts to debit cards. (See [Instant payouts for marketplaces for more information](https://stripe.com/blog/instant-payouts-for-marketplaces).)
        member _.Method = method
        ///The balance type of your Stripe balance to draw this payout from. Balances for different payment sources are kept separately. You can find the amounts with the balances API. One of `bank_account`, `card`, or `fpx`.
        member _.SourceType = sourceType
        ///A string to be displayed on the recipient's bank or card statement. This may be at most 22 characters. Attempting to use a `statement_descriptor` longer than 22 characters will return an error. Note: Most banks will truncate this information and/or display it inconsistently. Some may not display it at all.
        member _.StatementDescriptor = statementDescriptor

    and PostPayoutsMethod =
        | Instant
        | Standard

    and PostPayoutsSourceType =
        | BankAccount
        | Card
        | Fpx

    and PostPayoutsPayoutParams (?expand: string list, ?metadata: Map<string, string>) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostPayoutsPayoutCancelParams (?expand: string list) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand

    and PostPayoutsPayoutReverseParams (?expand: string list, ?metadata: Map<string, string>) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostPlansParams (interval: PostPlansInterval, currency: string, ?transformUsage: PostPlansTransformUsage, ?tiersMode: PostPlansTiersMode, ?tiers: PostPlansTiers list, ?product: Choice<PostPlansProductInlineProductParams,string>, ?nickname: string, ?metadata: Map<string, string>, ?intervalCount: int, ?active: bool, ?id: string, ?expand: string list, ?billingScheme: PostPlansBillingScheme, ?amountDecimal: string, ?amount: int, ?aggregateUsage: PostPlansAggregateUsage, ?trialPeriodDays: int, ?usageType: PostPlansUsageType) =
        ///Whether the plan is currently available for new subscriptions. Defaults to `true`.
        member _.Active = active
        ///Specifies a usage aggregation strategy for plans of `usage_type=metered`. Allowed values are `sum` for summing up all usage during a period, `last_during_period` for using the last usage record reported within a period, `last_ever` for using the last usage record ever (across period bounds) or `max` which uses the usage record with the maximum reported usage during a period. Defaults to `sum`.
        member _.AggregateUsage = aggregateUsage
        ///A positive integer in %s (or 0 for a free plan) representing how much to charge on a recurring basis.
        member _.Amount = amount
        ///Same as `amount`, but accepts a decimal value with at most 12 decimal places. Only one of `amount` and `amount_decimal` can be set.
        member _.AmountDecimal = amountDecimal
        ///Describes how to compute the price per period. Either `per_unit` or `tiered`. `per_unit` indicates that the fixed amount (specified in `amount`) will be charged per unit in `quantity` (for plans with `usage_type=licensed`), or per unit of total usage (for plans with `usage_type=metered`). `tiered` indicates that the unit pricing will be computed using a tiering strategy as defined using the `tiers` and `tiers_mode` attributes.
        member _.BillingScheme = billingScheme
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///An identifier randomly generated by Stripe. Used to identify this plan when subscribing a customer. You can optionally override this ID, but the ID must be unique across all plans in your Stripe account. You can, however, use the same plan ID in both live and test modes.
        member _.Id = id
        ///Specifies billing frequency. Either `day`, `week`, `month` or `year`.
        member _.Interval = interval
        ///The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        member _.IntervalCount = intervalCount
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///A brief description of the plan, hidden from customers.
        member _.Nickname = nickname
        ///
        member _.Product = product
        ///Each element represents a pricing tier. This parameter requires `billing_scheme` to be set to `tiered`. See also the documentation for `billing_scheme`.
        member _.Tiers = tiers
        ///Defines if the tiering price should be `graduated` or `volume` based. In `volume`-based tiering, the maximum quantity within a period determines the per unit price, in `graduated` tiering pricing can successively change as the quantity grows.
        member _.TiersMode = tiersMode
        ///Apply a transformation to the reported usage or set quantity before computing the billed price. Cannot be combined with `tiers`.
        member _.TransformUsage = transformUsage
        ///Default number of trial days when subscribing a customer to this plan using [`trial_from_plan=true`](https://stripe.com/docs/api#create_subscription-trial_from_plan).
        member _.TrialPeriodDays = trialPeriodDays
        ///Configures how the quantity per period should be determined. Can be either `metered` or `licensed`. `licensed` automatically bills the `quantity` set when adding it to a subscription. `metered` aggregates the total usage based on usage records. Defaults to `licensed`.
        member _.UsageType = usageType

    and PostPlansAggregateUsage =
        | LastDuringPeriod
        | LastEver
        | Max
        | Sum

    and PostPlansBillingScheme =
        | PerUnit
        | Tiered

    and PostPlansInterval =
        | Day
        | Month
        | Week
        | Year

    and PostPlansTiersMode =
        | Graduated
        | Volume

    and PostPlansUsageType =
        | Licensed
        | Metered

    and PostPlansProductInlineProductParams (?active: bool, ?id: string, ?metadata: Map<string, string>, ?name: string, ?statementDescriptor: string, ?unitLabel: string) =
        ///Whether the product is currently available for purchase. Defaults to `true`.
        member _.Active = active
        ///The identifier for the product. Must be unique. If not provided, an identifier will be randomly generated.
        member _.Id = id
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The product's name, meant to be displayable to the customer. Whenever this product is sold via a subscription, name will show up on associated invoice line item descriptions.
        member _.Name = name
        ///An arbitrary string to be displayed on your customer's credit card or bank statement. While most banks display this information consistently, some may display it incorrectly or not at all.
        ///This may be up to 22 characters. The statement description may not include `<`, `>`, `\`, `"`, `'` characters, and will appear on your customer's statement in capital letters. Non-ASCII characters are automatically stripped.
        member _.StatementDescriptor = statementDescriptor
        ///A label that represents units of this product in Stripe and on customers’ receipts and invoices. When set, this will be included in associated invoice line item descriptions.
        member _.UnitLabel = unitLabel

    and PostPlansTiers (?flatAmount: int, ?flatAmountDecimal: string, ?unitAmount: int, ?unitAmountDecimal: string, ?upTo: Choice<PostPlansTiersUpTo,int>) =
        ///The flat billing amount for an entire tier, regardless of the number of units in the tier.
        member _.FlatAmount = flatAmount
        ///Same as `flat_amount`, but accepts a decimal value representing an integer in the minor units of the currency. Only one of `flat_amount` and `flat_amount_decimal` can be set.
        member _.FlatAmountDecimal = flatAmountDecimal
        ///The per unit billing amount for each individual unit for which this tier applies.
        member _.UnitAmount = unitAmount
        ///Same as `unit_amount`, but accepts a decimal value in %s with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        member _.UnitAmountDecimal = unitAmountDecimal
        ///Specifies the upper bound of this tier. The lower bound of a tier is the upper bound of the previous tier adding one. Use `inf` to define a fallback tier.
        member _.UpTo = upTo

    and PostPlansTiersUpTo =
        | Inf

    and PostPlansTransformUsage (?divideBy: int, ?round: PostPlansTransformUsageRound) =
        ///Divide usage by this number.
        member _.DivideBy = divideBy
        ///After division, either round the result `up` or `down`.
        member _.Round = round

    and PostPlansTransformUsageRound =
        | Down
        | Up

    and PostPlansPlanParams (?active: bool, ?expand: string list, ?metadata: Map<string, string>, ?nickname: string, ?product: string, ?trialPeriodDays: int) =
        ///Whether the plan is currently available for new subscriptions.
        member _.Active = active
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///A brief description of the plan, hidden from customers.
        member _.Nickname = nickname
        ///The product the plan belongs to. This cannot be changed once it has been used in a subscription or subscription schedule.
        member _.Product = product
        ///Default number of trial days when subscribing a customer to this plan using [`trial_from_plan=true`](https://stripe.com/docs/api#create_subscription-trial_from_plan).
        member _.TrialPeriodDays = trialPeriodDays

    and PostPricesParams (currency: string, ?active: bool, ?billingScheme: PostPricesBillingScheme, ?expand: string list, ?lookupKey: string, ?metadata: Map<string, string>, ?nickname: string, ?product: string, ?productData: PostPricesProductData, ?recurring: PostPricesRecurring, ?tiers: PostPricesTiers list, ?tiersMode: PostPricesTiersMode, ?transferLookupKey: bool, ?transformQuantity: PostPricesTransformQuantity, ?unitAmount: int, ?unitAmountDecimal: string) =
        ///Whether the price can be used for new purchases. Defaults to `true`.
        member _.Active = active
        ///Describes how to compute the price per period. Either `per_unit` or `tiered`. `per_unit` indicates that the fixed amount (specified in `unit_amount` or `unit_amount_decimal`) will be charged per unit in `quantity` (for prices with `usage_type=licensed`), or per unit of total usage (for prices with `usage_type=metered`). `tiered` indicates that the unit pricing will be computed using a tiering strategy as defined using the `tiers` and `tiers_mode` attributes.
        member _.BillingScheme = billingScheme
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///A lookup key used to retrieve prices dynamically from a static string.
        member _.LookupKey = lookupKey
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///A brief description of the price, hidden from customers.
        member _.Nickname = nickname
        ///The ID of the product that this price will belong to.
        member _.Product = product
        ///These fields can be used to create a new product that this price will belong to.
        member _.ProductData = productData
        ///The recurring components of a price such as `interval` and `usage_type`.
        member _.Recurring = recurring
        ///Each element represents a pricing tier. This parameter requires `billing_scheme` to be set to `tiered`. See also the documentation for `billing_scheme`.
        member _.Tiers = tiers
        ///Defines if the tiering price should be `graduated` or `volume` based. In `volume`-based tiering, the maximum quantity within a period determines the per unit price, in `graduated` tiering pricing can successively change as the quantity grows.
        member _.TiersMode = tiersMode
        ///If set to true, will atomically remove the lookup key from the existing price, and assign it to this price.
        member _.TransferLookupKey = transferLookupKey
        ///Apply a transformation to the reported usage or set quantity before computing the billed price. Cannot be combined with `tiers`.
        member _.TransformQuantity = transformQuantity
        ///A positive integer in %s (or 0 for a free price) representing how much to charge.
        member _.UnitAmount = unitAmount
        ///Same as `unit_amount`, but accepts a decimal value in %s with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        member _.UnitAmountDecimal = unitAmountDecimal

    and PostPricesBillingScheme =
        | PerUnit
        | Tiered

    and PostPricesTiersMode =
        | Graduated
        | Volume

    and PostPricesProductData (?active: bool, ?id: string, ?metadata: Map<string, string>, ?name: string, ?statementDescriptor: string, ?unitLabel: string) =
        ///Whether the product is currently available for purchase. Defaults to `true`.
        member _.Active = active
        ///The identifier for the product. Must be unique. If not provided, an identifier will be randomly generated.
        member _.Id = id
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The product's name, meant to be displayable to the customer. Whenever this product is sold via a subscription, name will show up on associated invoice line item descriptions.
        member _.Name = name
        ///An arbitrary string to be displayed on your customer's credit card or bank statement. While most banks display this information consistently, some may display it incorrectly or not at all.
        ///This may be up to 22 characters. The statement description may not include `<`, `>`, `\`, `"`, `'` characters, and will appear on your customer's statement in capital letters. Non-ASCII characters are automatically stripped.
        member _.StatementDescriptor = statementDescriptor
        ///A label that represents units of this product in Stripe and on customers’ receipts and invoices. When set, this will be included in associated invoice line item descriptions.
        member _.UnitLabel = unitLabel

    and PostPricesRecurring (?aggregateUsage: PostPricesRecurringAggregateUsage, ?interval: PostPricesRecurringInterval, ?intervalCount: int, ?trialPeriodDays: int, ?usageType: PostPricesRecurringUsageType) =
        ///Specifies a usage aggregation strategy for prices of `usage_type=metered`. Allowed values are `sum` for summing up all usage during a period, `last_during_period` for using the last usage record reported within a period, `last_ever` for using the last usage record ever (across period bounds) or `max` which uses the usage record with the maximum reported usage during a period. Defaults to `sum`.
        member _.AggregateUsage = aggregateUsage
        ///Specifies billing frequency. Either `day`, `week`, `month` or `year`.
        member _.Interval = interval
        ///The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        member _.IntervalCount = intervalCount
        ///Default number of trial days when subscribing a customer to this price using [`trial_from_plan=true`](https://stripe.com/docs/api#create_subscription-trial_from_plan).
        member _.TrialPeriodDays = trialPeriodDays
        ///Configures how the quantity per period should be determined. Can be either `metered` or `licensed`. `licensed` automatically bills the `quantity` set when adding it to a subscription. `metered` aggregates the total usage based on usage records. Defaults to `licensed`.
        member _.UsageType = usageType

    and PostPricesRecurringAggregateUsage =
        | LastDuringPeriod
        | LastEver
        | Max
        | Sum

    and PostPricesRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    and PostPricesRecurringUsageType =
        | Licensed
        | Metered

    and PostPricesTiers (?flatAmount: int, ?flatAmountDecimal: string, ?unitAmount: int, ?unitAmountDecimal: string, ?upTo: Choice<PostPricesTiersUpTo,int>) =
        ///The flat billing amount for an entire tier, regardless of the number of units in the tier.
        member _.FlatAmount = flatAmount
        ///Same as `flat_amount`, but accepts a decimal value representing an integer in the minor units of the currency. Only one of `flat_amount` and `flat_amount_decimal` can be set.
        member _.FlatAmountDecimal = flatAmountDecimal
        ///The per unit billing amount for each individual unit for which this tier applies.
        member _.UnitAmount = unitAmount
        ///Same as `unit_amount`, but accepts a decimal value in %s with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        member _.UnitAmountDecimal = unitAmountDecimal
        ///Specifies the upper bound of this tier. The lower bound of a tier is the upper bound of the previous tier adding one. Use `inf` to define a fallback tier.
        member _.UpTo = upTo

    and PostPricesTiersUpTo =
        | Inf

    and PostPricesTransformQuantity (?divideBy: int, ?round: PostPricesTransformQuantityRound) =
        ///Divide usage by this number.
        member _.DivideBy = divideBy
        ///After division, either round the result `up` or `down`.
        member _.Round = round

    and PostPricesTransformQuantityRound =
        | Down
        | Up

    and PostPricesPriceParams (?active: bool, ?expand: string list, ?lookupKey: string, ?metadata: Map<string, string>, ?nickname: string, ?recurring: Choice<PostPricesPriceRecurringUpdateRecurringParams,string>, ?transferLookupKey: bool) =
        ///Whether the price can be used for new purchases. Defaults to `true`.
        member _.Active = active
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///A lookup key used to retrieve prices dynamically from a static string.
        member _.LookupKey = lookupKey
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///A brief description of the price, hidden from customers.
        member _.Nickname = nickname
        ///The recurring components of a price such as `interval` and `usage_type`.
        member _.Recurring = recurring
        ///If set to true, will atomically remove the lookup key from the existing price, and assign it to this price.
        member _.TransferLookupKey = transferLookupKey

    and PostPricesPriceRecurringUpdateRecurringParams (?trialPeriodDays: int) =
        ///Default number of trial days when subscribing a customer to this plan using [`trial_from_plan=true`](https://stripe.com/docs/api#create_subscription-trial_from_plan).
        member _.TrialPeriodDays = trialPeriodDays

    and PostProductsParams (name: string, ?active: bool, ?attributes: string list, ?caption: string, ?deactivateOn: string list, ?description: string, ?expand: string list, ?id: string, ?images: string list, ?metadata: Map<string, string>, ?packageDimensions: PostProductsPackageDimensions, ?shippable: bool, ?statementDescriptor: string, ?``type``: PostProductsType, ?unitLabel: string, ?url: string) =
        ///Whether the product is currently available for purchase. Defaults to `true`.
        member _.Active = active
        ///A list of up to 5 alphanumeric attributes. Should only be set if type=`good`.
        member _.Attributes = attributes
        ///A short one-line description of the product, meant to be displayable to the customer. May only be set if type=`good`.
        member _.Caption = caption
        ///An array of Connect application names or identifiers that should not be able to order the SKUs for this product. May only be set if type=`good`.
        member _.DeactivateOn = deactivateOn
        ///The product's description, meant to be displayable to the customer. Use this field to optionally store a long form explanation of the product being sold for your own rendering purposes.
        member _.Description = description
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///An identifier will be randomly generated by Stripe. You can optionally override this ID, but the ID must be unique across all products in your Stripe account.
        member _.Id = id
        ///A list of up to 8 URLs of images for this product, meant to be displayable to the customer.
        member _.Images = images
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The product's name, meant to be displayable to the customer. Whenever this product is sold via a subscription, name will show up on associated invoice line item descriptions.
        member _.Name = name
        ///The dimensions of this product for shipping purposes. A SKU associated with this product can override this value by having its own `package_dimensions`. May only be set if type=`good`.
        member _.PackageDimensions = packageDimensions
        ///Whether this product is shipped (i.e., physical goods). Defaults to `true`. May only be set if type=`good`.
        member _.Shippable = shippable
        ///An arbitrary string to be displayed on your customer's credit card or bank statement. While most banks display this information consistently, some may display it incorrectly or not at all.
        ///This may be up to 22 characters. The statement description may not include `<`, `>`, `\`, `"`, `'` characters, and will appear on your customer's statement in capital letters. Non-ASCII characters are automatically stripped.
        /// It must contain at least one letter.
        member _.StatementDescriptor = statementDescriptor
        ///The type of the product. Defaults to `service` if not explicitly specified, enabling use of this product with Subscriptions and Plans. Set this parameter to `good` to use this product with Orders and SKUs. On API versions before `2018-02-05`, this field defaults to `good` for compatibility reasons.
        member _.Type = ``type``
        ///A label that represents units of this product in Stripe and on customers’ receipts and invoices. When set, this will be included in associated invoice line item descriptions.
        member _.UnitLabel = unitLabel
        ///A URL of a publicly-accessible webpage for this product. May only be set if type=`good`.
        member _.Url = url

    and PostProductsType =
        | Good
        | Service

    and PostProductsPackageDimensions (?height: decimal, ?length: decimal, ?weight: decimal, ?width: decimal) =
        ///Height, in inches. Maximum precision is 2 decimal places.
        member _.Height = height
        ///Length, in inches. Maximum precision is 2 decimal places.
        member _.Length = length
        ///Weight, in ounces. Maximum precision is 2 decimal places.
        member _.Weight = weight
        ///Width, in inches. Maximum precision is 2 decimal places.
        member _.Width = width

    and PostProductsIdParams (?active: bool, ?attributes: Choice<string list,string>, ?caption: string, ?deactivateOn: string list, ?description: string, ?expand: string list, ?images: Choice<string list,string>, ?metadata: Map<string, string>, ?name: string, ?packageDimensions: Choice<PostProductsIdPackageDimensionsPackageDimensionsSpecs,string>, ?shippable: bool, ?statementDescriptor: string, ?unitLabel: string, ?url: string) =
        ///Whether the product is available for purchase.
        member _.Active = active
        ///A list of up to 5 alphanumeric attributes that each SKU can provide values for (e.g., `["color", "size"]`). If a value for `attributes` is specified, the list specified will replace the existing attributes list on this product. Any attributes not present after the update will be deleted from the SKUs for this product.
        member _.Attributes = attributes
        ///A short one-line description of the product, meant to be displayable to the customer. May only be set if `type=good`.
        member _.Caption = caption
        ///An array of Connect application names or identifiers that should not be able to order the SKUs for this product. May only be set if `type=good`.
        member _.DeactivateOn = deactivateOn
        ///The product's description, meant to be displayable to the customer. Use this field to optionally store a long form explanation of the product being sold for your own rendering purposes.
        member _.Description = description
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///A list of up to 8 URLs of images for this product, meant to be displayable to the customer.
        member _.Images = images
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The product's name, meant to be displayable to the customer. Whenever this product is sold via a subscription, name will show up on associated invoice line item descriptions.
        member _.Name = name
        ///The dimensions of this product for shipping purposes. A SKU associated with this product can override this value by having its own `package_dimensions`. May only be set if `type=good`.
        member _.PackageDimensions = packageDimensions
        ///Whether this product is shipped (i.e., physical goods). Defaults to `true`. May only be set if `type=good`.
        member _.Shippable = shippable
        ///An arbitrary string to be displayed on your customer's credit card or bank statement. While most banks display this information consistently, some may display it incorrectly or not at all.
        ///This may be up to 22 characters. The statement description may not include `<`, `>`, `\`, `"`, `'` characters, and will appear on your customer's statement in capital letters. Non-ASCII characters are automatically stripped.
        /// It must contain at least one letter. May only be set if `type=service`.
        member _.StatementDescriptor = statementDescriptor
        ///A label that represents units of this product in Stripe and on customers’ receipts and invoices. When set, this will be included in associated invoice line item descriptions. May only be set if `type=service`.
        member _.UnitLabel = unitLabel
        ///A URL of a publicly-accessible webpage for this product. May only be set if `type=good`.
        member _.Url = url

    and PostProductsIdPackageDimensionsPackageDimensionsSpecs (?height: decimal, ?length: decimal, ?weight: decimal, ?width: decimal) =
        ///Height, in inches. Maximum precision is 2 decimal places.
        member _.Height = height
        ///Length, in inches. Maximum precision is 2 decimal places.
        member _.Length = length
        ///Weight, in ounces. Maximum precision is 2 decimal places.
        member _.Weight = weight
        ///Width, in inches. Maximum precision is 2 decimal places.
        member _.Width = width

    and PostPromotionCodesParams (coupon: string, ?active: bool, ?code: string, ?customer: string, ?expand: string list, ?expiresAt: DateTime, ?maxRedemptions: int, ?metadata: Map<string, string>, ?restrictions: PostPromotionCodesRestrictions) =
        ///Whether the promotion code is currently active.
        member _.Active = active
        ///The customer-facing code. Regardless of case, this code must be unique across all active promotion codes for a specific customer. If left blank, we will generate one automatically.
        member _.Code = code
        ///The coupon for this promotion code.
        member _.Coupon = coupon
        ///The customer that this promotion code can be used by. If not set, the promotion code can be used by all customers.
        member _.Customer = customer
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///The timestamp at which this promotion code will expire. If the coupon has specified a `redeems_by`, then this value cannot be after the coupon's `redeems_by`.
        member _.ExpiresAt = expiresAt
        ///A positive integer specifying the number of times the promotion code can be redeemed. If the coupon has specified a `max_redemptions`, then this value cannot be greater than the coupon's `max_redemptions`.
        member _.MaxRedemptions = maxRedemptions
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Settings that restrict the redemption of the promotion code.
        member _.Restrictions = restrictions

    and PostPromotionCodesRestrictions (?firstTimeTransaction: bool, ?minimumAmount: int, ?minimumAmountCurrency: string) =
        ///A Boolean indicating if the Promotion Code should only be redeemed for Customers without any successful payments or invoices
        member _.FirstTimeTransaction = firstTimeTransaction
        ///Minimum amount required to redeem this Promotion Code into a Coupon (e.g., a purchase must be $100 or more to work).
        member _.MinimumAmount = minimumAmount
        ///Three-letter [ISO code](https://stripe.com/docs/currencies) for minimum_amount
        member _.MinimumAmountCurrency = minimumAmountCurrency

    and PostPromotionCodesPromotionCodeParams (?active: bool, ?expand: string list, ?metadata: Map<string, string>) =
        ///Whether the promotion code is currently active. A promotion code can only be reactivated when the coupon is still valid and the promotion code is otherwise redeemable.
        member _.Active = active
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostRadarValueListItemsParams (value: string, valueList: string, ?expand: string list) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///The value of the item (whose type must match the type of the parent value list).
        member _.Value = value
        ///The identifier of the value list which the created item will be added to.
        member _.ValueList = valueList

    and PostRadarValueListsParams (alias: string, name: string, ?expand: string list, ?itemType: PostRadarValueListsItemType, ?metadata: Map<string, string>) =
        ///The name of the value list for use in rules.
        member _.Alias = alias
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Type of the items in the value list. One of `card_fingerprint`, `card_bin`, `email`, `ip_address`, `country`, `string`, or `case_sensitive_string`. Use `string` if the item type is unknown or mixed.
        member _.ItemType = itemType
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The human-readable name of the value list.
        member _.Name = name

    and PostRadarValueListsItemType =
        | CardBin
        | CardFingerprint
        | CaseSensitiveString
        | Country
        | Email
        | IpAddress
        | String

    and PostRadarValueListsValueListParams (?alias: string, ?expand: string list, ?metadata: Map<string, string>, ?name: string) =
        ///The name of the value list for use in rules.
        member _.Alias = alias
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The human-readable name of the value list.
        member _.Name = name

    and PostRecipientsParams (name: string, ``type``: string, ?bankAccount: string, ?card: string, ?description: string, ?email: string, ?expand: string list, ?metadata: Map<string, string>, ?taxId: string) =
        ///A bank account to attach to the recipient. You can provide either a token, like the ones returned by [Stripe.js](https://stripe.com/docs/stripe-js), or a dictionary containing a user's bank account details, with the options described below.
        member _.BankAccount = bankAccount
        ///A U.S. Visa or MasterCard debit card (_not_ prepaid) to attach to the recipient. If the debit card is not valid, recipient creation will fail. You can provide either a token, like the ones returned by [Stripe.js](https://stripe.com/docs/stripe-js), or a dictionary containing a user's debit card details, with the options described below. Although not all information is required, the extra info helps prevent fraud.
        member _.Card = card
        ///An arbitrary string which you can attach to a `Recipient` object. It is displayed alongside the recipient in the web interface.
        member _.Description = description
        ///The recipient's email address. It is displayed alongside the recipient in the web interface, and can be useful for searching and tracking.
        member _.Email = email
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The recipient's full, legal name. For type `individual`, should be in the format `First Last`, `First Middle Last`, or `First M Last` (no prefixes or suffixes). For `corporation`, the full, incorporated name.
        member _.Name = name
        ///The recipient's tax ID, as a string. For type `individual`, the full SSN; for type `corporation`, the full EIN.
        member _.TaxId = taxId
        ///Type of the recipient: either `individual` or `corporation`.
        member _.Type = ``type``

    and PostRecipientsIdParams (?bankAccount: string, ?card: string, ?defaultCard: string, ?description: string, ?email: string, ?expand: string list, ?metadata: Map<string, string>, ?name: string, ?taxId: string) =
        ///A bank account to attach to the recipient. You can provide either a token, like the ones returned by [Stripe.js](https://stripe.com/docs/stripe-js), or a dictionary containing a user's bank account details, with the options described below.
        member _.BankAccount = bankAccount
        ///A U.S. Visa or MasterCard debit card (not prepaid) to attach to the recipient. You can provide either a token, like the ones returned by [Stripe.js](https://stripe.com/docs/stripe-js), or a dictionary containing a user's debit card details, with the options described below. Passing `card` will create a new card, make it the new recipient default card, and delete the old recipient default (if one exists). If you want to add additional debit cards instead of replacing the existing default, use the [card creation API](https://stripe.com/docs/api#create_card). Whenever you attach a card to a recipient, Stripe will automatically validate the debit card.
        member _.Card = card
        ///ID of the card to set as the recipient's new default for payouts.
        member _.DefaultCard = defaultCard
        ///An arbitrary string which you can attach to a `Recipient` object. It is displayed alongside the recipient in the web interface.
        member _.Description = description
        ///The recipient's email address. It is displayed alongside the recipient in the web interface, and can be useful for searching and tracking.
        member _.Email = email
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The recipient's full, legal name. For type `individual`, should be in the format `First Last`, `First Middle Last`, or `First M Last` (no prefixes or suffixes). For `corporation`, the full, incorporated name.
        member _.Name = name
        ///The recipient's tax ID, as a string. For type `individual`, the full SSN; for type `corporation`, the full EIN.
        member _.TaxId = taxId

    and PostRefundsParams (?amount: int, ?charge: string, ?expand: string list, ?metadata: Map<string, string>, ?paymentIntent: string, ?reason: PostRefundsReason, ?refundApplicationFee: bool, ?reverseTransfer: bool) =
        ///
        member _.Amount = amount
        ///
        member _.Charge = charge
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///
        member _.PaymentIntent = paymentIntent
        ///
        member _.Reason = reason
        ///
        member _.RefundApplicationFee = refundApplicationFee
        ///
        member _.ReverseTransfer = reverseTransfer

    and PostRefundsReason =
        | Duplicate
        | Fraudulent
        | RequestedByCustomer

    and PostRefundsRefundParams (?expand: string list, ?metadata: Map<string, string>) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostReportingReportRunsParams (reportType: string, ?parameters: PostReportingReportRunsParameters, ?expand: string list) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Parameters specifying how the report should be run. Different Report Types have different required and optional parameters, listed in the [API Access to Reports](https://stripe.com/docs/reporting/statements/api) documentation.
        member _.Parameters = parameters
        ///The ID of the [report type](https://stripe.com/docs/reporting/statements/api#report-types) to run, such as `"balance.summary.1"`.
        member _.ReportType = reportType

    and PostReportingReportRunsParameters (?columns: string list, ?connectedAccount: string, ?currency: string, ?intervalEnd: DateTime, ?intervalStart: DateTime, ?payout: string, ?reportingCategory: PostReportingReportRunsParametersReportingCategory, ?timezone: PostReportingReportRunsParametersTimezone) =
        ///The set of report columns to include in the report output. If omitted, the Report Type is run with its default column set.
        member _.Columns = columns
        ///Connected account ID to filter for in the report run.
        member _.ConnectedAccount = connectedAccount
        ///Currency of objects to be included in the report run.
        member _.Currency = currency
        ///Ending timestamp of data to be included in the report run (exclusive).
        member _.IntervalEnd = intervalEnd
        ///Starting timestamp of data to be included in the report run.
        member _.IntervalStart = intervalStart
        ///Payout ID by which to filter the report run.
        member _.Payout = payout
        ///Category of balance transactions to be included in the report run.
        member _.ReportingCategory = reportingCategory
        ///Defaults to `Etc/UTC`. The output timezone for all timestamps in the report. A list of possible time zone values is maintained at the [IANA Time Zone Database](http://www.iana.org/time-zones). Has no effect on `interval_start` or `interval_end`.
        member _.Timezone = timezone

    and PostReportingReportRunsParametersReportingCategory =
        | Advance
        | AdvanceFunding
        | AnticipationRepayment
        | Charge
        | ChargeFailure
        | ConnectCollectionTransfer
        | ConnectReservedFunds
        | Contribution
        | Dispute
        | DisputeReversal
        | Fee
        | FinancingPaydown
        | FinancingPaydownReversal
        | FinancingPayout
        | FinancingPayoutReversal
        | IssuingAuthorizationHold
        | IssuingAuthorizationRelease
        | IssuingDispute
        | IssuingTransaction
        | NetworkCost
        | OtherAdjustment
        | PartialCaptureReversal
        | Payout
        | PayoutReversal
        | PlatformEarning
        | PlatformEarningRefund
        | Refund
        | RefundFailure
        | RiskReservedFunds
        | Tax
        | Topup
        | TopupReversal
        | Transfer
        | TransferReversal

    and PostReportingReportRunsParametersTimezone =
        | [<JsonUnionCase("Africa/Abidjan")>] AfricaAbidjan
        | [<JsonUnionCase("Africa/Accra")>] AfricaAccra
        | [<JsonUnionCase("Africa/Addis_Ababa")>] AfricaAddisAbaba
        | [<JsonUnionCase("Africa/Algiers")>] AfricaAlgiers
        | [<JsonUnionCase("Africa/Asmara")>] AfricaAsmara
        | [<JsonUnionCase("Africa/Asmera")>] AfricaAsmera
        | [<JsonUnionCase("Africa/Bamako")>] AfricaBamako
        | [<JsonUnionCase("Africa/Bangui")>] AfricaBangui
        | [<JsonUnionCase("Africa/Banjul")>] AfricaBanjul
        | [<JsonUnionCase("Africa/Bissau")>] AfricaBissau
        | [<JsonUnionCase("Africa/Blantyre")>] AfricaBlantyre
        | [<JsonUnionCase("Africa/Brazzaville")>] AfricaBrazzaville
        | [<JsonUnionCase("Africa/Bujumbura")>] AfricaBujumbura
        | [<JsonUnionCase("Africa/Cairo")>] AfricaCairo
        | [<JsonUnionCase("Africa/Casablanca")>] AfricaCasablanca
        | [<JsonUnionCase("Africa/Ceuta")>] AfricaCeuta
        | [<JsonUnionCase("Africa/Conakry")>] AfricaConakry
        | [<JsonUnionCase("Africa/Dakar")>] AfricaDakar
        | [<JsonUnionCase("Africa/Dar_es_Salaam")>] AfricaDarEsSalaam
        | [<JsonUnionCase("Africa/Djibouti")>] AfricaDjibouti
        | [<JsonUnionCase("Africa/Douala")>] AfricaDouala
        | [<JsonUnionCase("Africa/El_Aaiun")>] AfricaElAaiun
        | [<JsonUnionCase("Africa/Freetown")>] AfricaFreetown
        | [<JsonUnionCase("Africa/Gaborone")>] AfricaGaborone
        | [<JsonUnionCase("Africa/Harare")>] AfricaHarare
        | [<JsonUnionCase("Africa/Johannesburg")>] AfricaJohannesburg
        | [<JsonUnionCase("Africa/Juba")>] AfricaJuba
        | [<JsonUnionCase("Africa/Kampala")>] AfricaKampala
        | [<JsonUnionCase("Africa/Khartoum")>] AfricaKhartoum
        | [<JsonUnionCase("Africa/Kigali")>] AfricaKigali
        | [<JsonUnionCase("Africa/Kinshasa")>] AfricaKinshasa
        | [<JsonUnionCase("Africa/Lagos")>] AfricaLagos
        | [<JsonUnionCase("Africa/Libreville")>] AfricaLibreville
        | [<JsonUnionCase("Africa/Lome")>] AfricaLome
        | [<JsonUnionCase("Africa/Luanda")>] AfricaLuanda
        | [<JsonUnionCase("Africa/Lubumbashi")>] AfricaLubumbashi
        | [<JsonUnionCase("Africa/Lusaka")>] AfricaLusaka
        | [<JsonUnionCase("Africa/Malabo")>] AfricaMalabo
        | [<JsonUnionCase("Africa/Maputo")>] AfricaMaputo
        | [<JsonUnionCase("Africa/Maseru")>] AfricaMaseru
        | [<JsonUnionCase("Africa/Mbabane")>] AfricaMbabane
        | [<JsonUnionCase("Africa/Mogadishu")>] AfricaMogadishu
        | [<JsonUnionCase("Africa/Monrovia")>] AfricaMonrovia
        | [<JsonUnionCase("Africa/Nairobi")>] AfricaNairobi
        | [<JsonUnionCase("Africa/Ndjamena")>] AfricaNdjamena
        | [<JsonUnionCase("Africa/Niamey")>] AfricaNiamey
        | [<JsonUnionCase("Africa/Nouakchott")>] AfricaNouakchott
        | [<JsonUnionCase("Africa/Ouagadougou")>] AfricaOuagadougou
        | [<JsonUnionCase("Africa/Porto-Novo")>] AfricaPortoNovo
        | [<JsonUnionCase("Africa/Sao_Tome")>] AfricaSaoTome
        | [<JsonUnionCase("Africa/Timbuktu")>] AfricaTimbuktu
        | [<JsonUnionCase("Africa/Tripoli")>] AfricaTripoli
        | [<JsonUnionCase("Africa/Tunis")>] AfricaTunis
        | [<JsonUnionCase("Africa/Windhoek")>] AfricaWindhoek
        | [<JsonUnionCase("America/Adak")>] AmericaAdak
        | [<JsonUnionCase("America/Anchorage")>] AmericaAnchorage
        | [<JsonUnionCase("America/Anguilla")>] AmericaAnguilla
        | [<JsonUnionCase("America/Antigua")>] AmericaAntigua
        | [<JsonUnionCase("America/Araguaina")>] AmericaAraguaina
        | [<JsonUnionCase("America/Argentina/Buenos_Aires")>] AmericaArgentinaBuenosAires
        | [<JsonUnionCase("America/Argentina/Catamarca")>] AmericaArgentinaCatamarca
        | [<JsonUnionCase("America/Argentina/ComodRivadavia")>] AmericaArgentinaComodRivadavia
        | [<JsonUnionCase("America/Argentina/Cordoba")>] AmericaArgentinaCordoba
        | [<JsonUnionCase("America/Argentina/Jujuy")>] AmericaArgentinaJujuy
        | [<JsonUnionCase("America/Argentina/La_Rioja")>] AmericaArgentinaLaRioja
        | [<JsonUnionCase("America/Argentina/Mendoza")>] AmericaArgentinaMendoza
        | [<JsonUnionCase("America/Argentina/Rio_Gallegos")>] AmericaArgentinaRioGallegos
        | [<JsonUnionCase("America/Argentina/Salta")>] AmericaArgentinaSalta
        | [<JsonUnionCase("America/Argentina/San_Juan")>] AmericaArgentinaSanJuan
        | [<JsonUnionCase("America/Argentina/San_Luis")>] AmericaArgentinaSanLuis
        | [<JsonUnionCase("America/Argentina/Tucuman")>] AmericaArgentinaTucuman
        | [<JsonUnionCase("America/Argentina/Ushuaia")>] AmericaArgentinaUshuaia
        | [<JsonUnionCase("America/Aruba")>] AmericaAruba
        | [<JsonUnionCase("America/Asuncion")>] AmericaAsuncion
        | [<JsonUnionCase("America/Atikokan")>] AmericaAtikokan
        | [<JsonUnionCase("America/Atka")>] AmericaAtka
        | [<JsonUnionCase("America/Bahia")>] AmericaBahia
        | [<JsonUnionCase("America/Bahia_Banderas")>] AmericaBahiaBanderas
        | [<JsonUnionCase("America/Barbados")>] AmericaBarbados
        | [<JsonUnionCase("America/Belem")>] AmericaBelem
        | [<JsonUnionCase("America/Belize")>] AmericaBelize
        | [<JsonUnionCase("America/Blanc-Sablon")>] AmericaBlancSablon
        | [<JsonUnionCase("America/Boa_Vista")>] AmericaBoaVista
        | [<JsonUnionCase("America/Bogota")>] AmericaBogota
        | [<JsonUnionCase("America/Boise")>] AmericaBoise
        | [<JsonUnionCase("America/Buenos_Aires")>] AmericaBuenosAires
        | [<JsonUnionCase("America/Cambridge_Bay")>] AmericaCambridgeBay
        | [<JsonUnionCase("America/Campo_Grande")>] AmericaCampoGrande
        | [<JsonUnionCase("America/Cancun")>] AmericaCancun
        | [<JsonUnionCase("America/Caracas")>] AmericaCaracas
        | [<JsonUnionCase("America/Catamarca")>] AmericaCatamarca
        | [<JsonUnionCase("America/Cayenne")>] AmericaCayenne
        | [<JsonUnionCase("America/Cayman")>] AmericaCayman
        | [<JsonUnionCase("America/Chicago")>] AmericaChicago
        | [<JsonUnionCase("America/Chihuahua")>] AmericaChihuahua
        | [<JsonUnionCase("America/Coral_Harbour")>] AmericaCoralHarbour
        | [<JsonUnionCase("America/Cordoba")>] AmericaCordoba
        | [<JsonUnionCase("America/Costa_Rica")>] AmericaCostaRica
        | [<JsonUnionCase("America/Creston")>] AmericaCreston
        | [<JsonUnionCase("America/Cuiaba")>] AmericaCuiaba
        | [<JsonUnionCase("America/Curacao")>] AmericaCuracao
        | [<JsonUnionCase("America/Danmarkshavn")>] AmericaDanmarkshavn
        | [<JsonUnionCase("America/Dawson")>] AmericaDawson
        | [<JsonUnionCase("America/Dawson_Creek")>] AmericaDawsonCreek
        | [<JsonUnionCase("America/Denver")>] AmericaDenver
        | [<JsonUnionCase("America/Detroit")>] AmericaDetroit
        | [<JsonUnionCase("America/Dominica")>] AmericaDominica
        | [<JsonUnionCase("America/Edmonton")>] AmericaEdmonton
        | [<JsonUnionCase("America/Eirunepe")>] AmericaEirunepe
        | [<JsonUnionCase("America/El_Salvador")>] AmericaElSalvador
        | [<JsonUnionCase("America/Ensenada")>] AmericaEnsenada
        | [<JsonUnionCase("America/Fort_Nelson")>] AmericaFortNelson
        | [<JsonUnionCase("America/Fort_Wayne")>] AmericaFortWayne
        | [<JsonUnionCase("America/Fortaleza")>] AmericaFortaleza
        | [<JsonUnionCase("America/Glace_Bay")>] AmericaGlaceBay
        | [<JsonUnionCase("America/Godthab")>] AmericaGodthab
        | [<JsonUnionCase("America/Goose_Bay")>] AmericaGooseBay
        | [<JsonUnionCase("America/Grand_Turk")>] AmericaGrandTurk
        | [<JsonUnionCase("America/Grenada")>] AmericaGrenada
        | [<JsonUnionCase("America/Guadeloupe")>] AmericaGuadeloupe
        | [<JsonUnionCase("America/Guatemala")>] AmericaGuatemala
        | [<JsonUnionCase("America/Guayaquil")>] AmericaGuayaquil
        | [<JsonUnionCase("America/Guyana")>] AmericaGuyana
        | [<JsonUnionCase("America/Halifax")>] AmericaHalifax
        | [<JsonUnionCase("America/Havana")>] AmericaHavana
        | [<JsonUnionCase("America/Hermosillo")>] AmericaHermosillo
        | [<JsonUnionCase("America/Indiana/Indianapolis")>] AmericaIndianaIndianapolis
        | [<JsonUnionCase("America/Indiana/Knox")>] AmericaIndianaKnox
        | [<JsonUnionCase("America/Indiana/Marengo")>] AmericaIndianaMarengo
        | [<JsonUnionCase("America/Indiana/Petersburg")>] AmericaIndianaPetersburg
        | [<JsonUnionCase("America/Indiana/Tell_City")>] AmericaIndianaTellCity
        | [<JsonUnionCase("America/Indiana/Vevay")>] AmericaIndianaVevay
        | [<JsonUnionCase("America/Indiana/Vincennes")>] AmericaIndianaVincennes
        | [<JsonUnionCase("America/Indiana/Winamac")>] AmericaIndianaWinamac
        | [<JsonUnionCase("America/Indianapolis")>] AmericaIndianapolis
        | [<JsonUnionCase("America/Inuvik")>] AmericaInuvik
        | [<JsonUnionCase("America/Iqaluit")>] AmericaIqaluit
        | [<JsonUnionCase("America/Jamaica")>] AmericaJamaica
        | [<JsonUnionCase("America/Jujuy")>] AmericaJujuy
        | [<JsonUnionCase("America/Juneau")>] AmericaJuneau
        | [<JsonUnionCase("America/Kentucky/Louisville")>] AmericaKentuckyLouisville
        | [<JsonUnionCase("America/Kentucky/Monticello")>] AmericaKentuckyMonticello
        | [<JsonUnionCase("America/Knox_IN")>] AmericaKnoxIN
        | [<JsonUnionCase("America/Kralendijk")>] AmericaKralendijk
        | [<JsonUnionCase("America/La_Paz")>] AmericaLaPaz
        | [<JsonUnionCase("America/Lima")>] AmericaLima
        | [<JsonUnionCase("America/Los_Angeles")>] AmericaLosAngeles
        | [<JsonUnionCase("America/Louisville")>] AmericaLouisville
        | [<JsonUnionCase("America/Lower_Princes")>] AmericaLowerPrinces
        | [<JsonUnionCase("America/Maceio")>] AmericaMaceio
        | [<JsonUnionCase("America/Managua")>] AmericaManagua
        | [<JsonUnionCase("America/Manaus")>] AmericaManaus
        | [<JsonUnionCase("America/Marigot")>] AmericaMarigot
        | [<JsonUnionCase("America/Martinique")>] AmericaMartinique
        | [<JsonUnionCase("America/Matamoros")>] AmericaMatamoros
        | [<JsonUnionCase("America/Mazatlan")>] AmericaMazatlan
        | [<JsonUnionCase("America/Mendoza")>] AmericaMendoza
        | [<JsonUnionCase("America/Menominee")>] AmericaMenominee
        | [<JsonUnionCase("America/Merida")>] AmericaMerida
        | [<JsonUnionCase("America/Metlakatla")>] AmericaMetlakatla
        | [<JsonUnionCase("America/Mexico_City")>] AmericaMexicoCity
        | [<JsonUnionCase("America/Miquelon")>] AmericaMiquelon
        | [<JsonUnionCase("America/Moncton")>] AmericaMoncton
        | [<JsonUnionCase("America/Monterrey")>] AmericaMonterrey
        | [<JsonUnionCase("America/Montevideo")>] AmericaMontevideo
        | [<JsonUnionCase("America/Montreal")>] AmericaMontreal
        | [<JsonUnionCase("America/Montserrat")>] AmericaMontserrat
        | [<JsonUnionCase("America/Nassau")>] AmericaNassau
        | [<JsonUnionCase("America/New_York")>] AmericaNewYork
        | [<JsonUnionCase("America/Nipigon")>] AmericaNipigon
        | [<JsonUnionCase("America/Nome")>] AmericaNome
        | [<JsonUnionCase("America/Noronha")>] AmericaNoronha
        | [<JsonUnionCase("America/North_Dakota/Beulah")>] AmericaNorthDakotaBeulah
        | [<JsonUnionCase("America/North_Dakota/Center")>] AmericaNorthDakotaCenter
        | [<JsonUnionCase("America/North_Dakota/New_Salem")>] AmericaNorthDakotaNewSalem
        | [<JsonUnionCase("America/Ojinaga")>] AmericaOjinaga
        | [<JsonUnionCase("America/Panama")>] AmericaPanama
        | [<JsonUnionCase("America/Pangnirtung")>] AmericaPangnirtung
        | [<JsonUnionCase("America/Paramaribo")>] AmericaParamaribo
        | [<JsonUnionCase("America/Phoenix")>] AmericaPhoenix
        | [<JsonUnionCase("America/Port-au-Prince")>] AmericaPortauPrince
        | [<JsonUnionCase("America/Port_of_Spain")>] AmericaPortOfSpain
        | [<JsonUnionCase("America/Porto_Acre")>] AmericaPortoAcre
        | [<JsonUnionCase("America/Porto_Velho")>] AmericaPortoVelho
        | [<JsonUnionCase("America/Puerto_Rico")>] AmericaPuertoRico
        | [<JsonUnionCase("America/Punta_Arenas")>] AmericaPuntaArenas
        | [<JsonUnionCase("America/Rainy_River")>] AmericaRainyRiver
        | [<JsonUnionCase("America/Rankin_Inlet")>] AmericaRankinInlet
        | [<JsonUnionCase("America/Recife")>] AmericaRecife
        | [<JsonUnionCase("America/Regina")>] AmericaRegina
        | [<JsonUnionCase("America/Resolute")>] AmericaResolute
        | [<JsonUnionCase("America/Rio_Branco")>] AmericaRioBranco
        | [<JsonUnionCase("America/Rosario")>] AmericaRosario
        | [<JsonUnionCase("America/Santa_Isabel")>] AmericaSantaIsabel
        | [<JsonUnionCase("America/Santarem")>] AmericaSantarem
        | [<JsonUnionCase("America/Santiago")>] AmericaSantiago
        | [<JsonUnionCase("America/Santo_Domingo")>] AmericaSantoDomingo
        | [<JsonUnionCase("America/Sao_Paulo")>] AmericaSaoPaulo
        | [<JsonUnionCase("America/Scoresbysund")>] AmericaScoresbysund
        | [<JsonUnionCase("America/Shiprock")>] AmericaShiprock
        | [<JsonUnionCase("America/Sitka")>] AmericaSitka
        | [<JsonUnionCase("America/St_Barthelemy")>] AmericaStBarthelemy
        | [<JsonUnionCase("America/St_Johns")>] AmericaStJohns
        | [<JsonUnionCase("America/St_Kitts")>] AmericaStKitts
        | [<JsonUnionCase("America/St_Lucia")>] AmericaStLucia
        | [<JsonUnionCase("America/St_Thomas")>] AmericaStThomas
        | [<JsonUnionCase("America/St_Vincent")>] AmericaStVincent
        | [<JsonUnionCase("America/Swift_Current")>] AmericaSwiftCurrent
        | [<JsonUnionCase("America/Tegucigalpa")>] AmericaTegucigalpa
        | [<JsonUnionCase("America/Thule")>] AmericaThule
        | [<JsonUnionCase("America/Thunder_Bay")>] AmericaThunderBay
        | [<JsonUnionCase("America/Tijuana")>] AmericaTijuana
        | [<JsonUnionCase("America/Toronto")>] AmericaToronto
        | [<JsonUnionCase("America/Tortola")>] AmericaTortola
        | [<JsonUnionCase("America/Vancouver")>] AmericaVancouver
        | [<JsonUnionCase("America/Virgin")>] AmericaVirgin
        | [<JsonUnionCase("America/Whitehorse")>] AmericaWhitehorse
        | [<JsonUnionCase("America/Winnipeg")>] AmericaWinnipeg
        | [<JsonUnionCase("America/Yakutat")>] AmericaYakutat
        | [<JsonUnionCase("America/Yellowknife")>] AmericaYellowknife
        | [<JsonUnionCase("Antarctica/Casey")>] AntarcticaCasey
        | [<JsonUnionCase("Antarctica/Davis")>] AntarcticaDavis
        | [<JsonUnionCase("Antarctica/DumontDUrville")>] AntarcticaDumontDUrville
        | [<JsonUnionCase("Antarctica/Macquarie")>] AntarcticaMacquarie
        | [<JsonUnionCase("Antarctica/Mawson")>] AntarcticaMawson
        | [<JsonUnionCase("Antarctica/McMurdo")>] AntarcticaMcMurdo
        | [<JsonUnionCase("Antarctica/Palmer")>] AntarcticaPalmer
        | [<JsonUnionCase("Antarctica/Rothera")>] AntarcticaRothera
        | [<JsonUnionCase("Antarctica/South_Pole")>] AntarcticaSouthPole
        | [<JsonUnionCase("Antarctica/Syowa")>] AntarcticaSyowa
        | [<JsonUnionCase("Antarctica/Troll")>] AntarcticaTroll
        | [<JsonUnionCase("Antarctica/Vostok")>] AntarcticaVostok
        | [<JsonUnionCase("Arctic/Longyearbyen")>] ArcticLongyearbyen
        | [<JsonUnionCase("Asia/Aden")>] AsiaAden
        | [<JsonUnionCase("Asia/Almaty")>] AsiaAlmaty
        | [<JsonUnionCase("Asia/Amman")>] AsiaAmman
        | [<JsonUnionCase("Asia/Anadyr")>] AsiaAnadyr
        | [<JsonUnionCase("Asia/Aqtau")>] AsiaAqtau
        | [<JsonUnionCase("Asia/Aqtobe")>] AsiaAqtobe
        | [<JsonUnionCase("Asia/Ashgabat")>] AsiaAshgabat
        | [<JsonUnionCase("Asia/Ashkhabad")>] AsiaAshkhabad
        | [<JsonUnionCase("Asia/Atyrau")>] AsiaAtyrau
        | [<JsonUnionCase("Asia/Baghdad")>] AsiaBaghdad
        | [<JsonUnionCase("Asia/Bahrain")>] AsiaBahrain
        | [<JsonUnionCase("Asia/Baku")>] AsiaBaku
        | [<JsonUnionCase("Asia/Bangkok")>] AsiaBangkok
        | [<JsonUnionCase("Asia/Barnaul")>] AsiaBarnaul
        | [<JsonUnionCase("Asia/Beirut")>] AsiaBeirut
        | [<JsonUnionCase("Asia/Bishkek")>] AsiaBishkek
        | [<JsonUnionCase("Asia/Brunei")>] AsiaBrunei
        | [<JsonUnionCase("Asia/Calcutta")>] AsiaCalcutta
        | [<JsonUnionCase("Asia/Chita")>] AsiaChita
        | [<JsonUnionCase("Asia/Choibalsan")>] AsiaChoibalsan
        | [<JsonUnionCase("Asia/Chongqing")>] AsiaChongqing
        | [<JsonUnionCase("Asia/Chungking")>] AsiaChungking
        | [<JsonUnionCase("Asia/Colombo")>] AsiaColombo
        | [<JsonUnionCase("Asia/Dacca")>] AsiaDacca
        | [<JsonUnionCase("Asia/Damascus")>] AsiaDamascus
        | [<JsonUnionCase("Asia/Dhaka")>] AsiaDhaka
        | [<JsonUnionCase("Asia/Dili")>] AsiaDili
        | [<JsonUnionCase("Asia/Dubai")>] AsiaDubai
        | [<JsonUnionCase("Asia/Dushanbe")>] AsiaDushanbe
        | [<JsonUnionCase("Asia/Famagusta")>] AsiaFamagusta
        | [<JsonUnionCase("Asia/Gaza")>] AsiaGaza
        | [<JsonUnionCase("Asia/Harbin")>] AsiaHarbin
        | [<JsonUnionCase("Asia/Hebron")>] AsiaHebron
        | [<JsonUnionCase("Asia/Ho_Chi_Minh")>] AsiaHoChiMinh
        | [<JsonUnionCase("Asia/Hong_Kong")>] AsiaHongKong
        | [<JsonUnionCase("Asia/Hovd")>] AsiaHovd
        | [<JsonUnionCase("Asia/Irkutsk")>] AsiaIrkutsk
        | [<JsonUnionCase("Asia/Istanbul")>] AsiaIstanbul
        | [<JsonUnionCase("Asia/Jakarta")>] AsiaJakarta
        | [<JsonUnionCase("Asia/Jayapura")>] AsiaJayapura
        | [<JsonUnionCase("Asia/Jerusalem")>] AsiaJerusalem
        | [<JsonUnionCase("Asia/Kabul")>] AsiaKabul
        | [<JsonUnionCase("Asia/Kamchatka")>] AsiaKamchatka
        | [<JsonUnionCase("Asia/Karachi")>] AsiaKarachi
        | [<JsonUnionCase("Asia/Kashgar")>] AsiaKashgar
        | [<JsonUnionCase("Asia/Kathmandu")>] AsiaKathmandu
        | [<JsonUnionCase("Asia/Katmandu")>] AsiaKatmandu
        | [<JsonUnionCase("Asia/Khandyga")>] AsiaKhandyga
        | [<JsonUnionCase("Asia/Kolkata")>] AsiaKolkata
        | [<JsonUnionCase("Asia/Krasnoyarsk")>] AsiaKrasnoyarsk
        | [<JsonUnionCase("Asia/Kuala_Lumpur")>] AsiaKualaLumpur
        | [<JsonUnionCase("Asia/Kuching")>] AsiaKuching
        | [<JsonUnionCase("Asia/Kuwait")>] AsiaKuwait
        | [<JsonUnionCase("Asia/Macao")>] AsiaMacao
        | [<JsonUnionCase("Asia/Macau")>] AsiaMacau
        | [<JsonUnionCase("Asia/Magadan")>] AsiaMagadan
        | [<JsonUnionCase("Asia/Makassar")>] AsiaMakassar
        | [<JsonUnionCase("Asia/Manila")>] AsiaManila
        | [<JsonUnionCase("Asia/Muscat")>] AsiaMuscat
        | [<JsonUnionCase("Asia/Nicosia")>] AsiaNicosia
        | [<JsonUnionCase("Asia/Novokuznetsk")>] AsiaNovokuznetsk
        | [<JsonUnionCase("Asia/Novosibirsk")>] AsiaNovosibirsk
        | [<JsonUnionCase("Asia/Omsk")>] AsiaOmsk
        | [<JsonUnionCase("Asia/Oral")>] AsiaOral
        | [<JsonUnionCase("Asia/Phnom_Penh")>] AsiaPhnomPenh
        | [<JsonUnionCase("Asia/Pontianak")>] AsiaPontianak
        | [<JsonUnionCase("Asia/Pyongyang")>] AsiaPyongyang
        | [<JsonUnionCase("Asia/Qatar")>] AsiaQatar
        | [<JsonUnionCase("Asia/Qostanay")>] AsiaQostanay
        | [<JsonUnionCase("Asia/Qyzylorda")>] AsiaQyzylorda
        | [<JsonUnionCase("Asia/Rangoon")>] AsiaRangoon
        | [<JsonUnionCase("Asia/Riyadh")>] AsiaRiyadh
        | [<JsonUnionCase("Asia/Saigon")>] AsiaSaigon
        | [<JsonUnionCase("Asia/Sakhalin")>] AsiaSakhalin
        | [<JsonUnionCase("Asia/Samarkand")>] AsiaSamarkand
        | [<JsonUnionCase("Asia/Seoul")>] AsiaSeoul
        | [<JsonUnionCase("Asia/Shanghai")>] AsiaShanghai
        | [<JsonUnionCase("Asia/Singapore")>] AsiaSingapore
        | [<JsonUnionCase("Asia/Srednekolymsk")>] AsiaSrednekolymsk
        | [<JsonUnionCase("Asia/Taipei")>] AsiaTaipei
        | [<JsonUnionCase("Asia/Tashkent")>] AsiaTashkent
        | [<JsonUnionCase("Asia/Tbilisi")>] AsiaTbilisi
        | [<JsonUnionCase("Asia/Tehran")>] AsiaTehran
        | [<JsonUnionCase("Asia/Tel_Aviv")>] AsiaTelAviv
        | [<JsonUnionCase("Asia/Thimbu")>] AsiaThimbu
        | [<JsonUnionCase("Asia/Thimphu")>] AsiaThimphu
        | [<JsonUnionCase("Asia/Tokyo")>] AsiaTokyo
        | [<JsonUnionCase("Asia/Tomsk")>] AsiaTomsk
        | [<JsonUnionCase("Asia/Ujung_Pandang")>] AsiaUjungPandang
        | [<JsonUnionCase("Asia/Ulaanbaatar")>] AsiaUlaanbaatar
        | [<JsonUnionCase("Asia/Ulan_Bator")>] AsiaUlanBator
        | [<JsonUnionCase("Asia/Urumqi")>] AsiaUrumqi
        | [<JsonUnionCase("Asia/Ust-Nera")>] AsiaUstNera
        | [<JsonUnionCase("Asia/Vientiane")>] AsiaVientiane
        | [<JsonUnionCase("Asia/Vladivostok")>] AsiaVladivostok
        | [<JsonUnionCase("Asia/Yakutsk")>] AsiaYakutsk
        | [<JsonUnionCase("Asia/Yangon")>] AsiaYangon
        | [<JsonUnionCase("Asia/Yekaterinburg")>] AsiaYekaterinburg
        | [<JsonUnionCase("Asia/Yerevan")>] AsiaYerevan
        | [<JsonUnionCase("Atlantic/Azores")>] AtlanticAzores
        | [<JsonUnionCase("Atlantic/Bermuda")>] AtlanticBermuda
        | [<JsonUnionCase("Atlantic/Canary")>] AtlanticCanary
        | [<JsonUnionCase("Atlantic/Cape_Verde")>] AtlanticCapeVerde
        | [<JsonUnionCase("Atlantic/Faeroe")>] AtlanticFaeroe
        | [<JsonUnionCase("Atlantic/Faroe")>] AtlanticFaroe
        | [<JsonUnionCase("Atlantic/Jan_Mayen")>] AtlanticJanMayen
        | [<JsonUnionCase("Atlantic/Madeira")>] AtlanticMadeira
        | [<JsonUnionCase("Atlantic/Reykjavik")>] AtlanticReykjavik
        | [<JsonUnionCase("Atlantic/South_Georgia")>] AtlanticSouthGeorgia
        | [<JsonUnionCase("Atlantic/St_Helena")>] AtlanticStHelena
        | [<JsonUnionCase("Atlantic/Stanley")>] AtlanticStanley
        | [<JsonUnionCase("Australia/ACT")>] AustraliaACT
        | [<JsonUnionCase("Australia/Adelaide")>] AustraliaAdelaide
        | [<JsonUnionCase("Australia/Brisbane")>] AustraliaBrisbane
        | [<JsonUnionCase("Australia/Broken_Hill")>] AustraliaBrokenHill
        | [<JsonUnionCase("Australia/Canberra")>] AustraliaCanberra
        | [<JsonUnionCase("Australia/Currie")>] AustraliaCurrie
        | [<JsonUnionCase("Australia/Darwin")>] AustraliaDarwin
        | [<JsonUnionCase("Australia/Eucla")>] AustraliaEucla
        | [<JsonUnionCase("Australia/Hobart")>] AustraliaHobart
        | [<JsonUnionCase("Australia/LHI")>] AustraliaLHI
        | [<JsonUnionCase("Australia/Lindeman")>] AustraliaLindeman
        | [<JsonUnionCase("Australia/Lord_Howe")>] AustraliaLordHowe
        | [<JsonUnionCase("Australia/Melbourne")>] AustraliaMelbourne
        | [<JsonUnionCase("Australia/NSW")>] AustraliaNSW
        | [<JsonUnionCase("Australia/North")>] AustraliaNorth
        | [<JsonUnionCase("Australia/Perth")>] AustraliaPerth
        | [<JsonUnionCase("Australia/Queensland")>] AustraliaQueensland
        | [<JsonUnionCase("Australia/South")>] AustraliaSouth
        | [<JsonUnionCase("Australia/Sydney")>] AustraliaSydney
        | [<JsonUnionCase("Australia/Tasmania")>] AustraliaTasmania
        | [<JsonUnionCase("Australia/Victoria")>] AustraliaVictoria
        | [<JsonUnionCase("Australia/West")>] AustraliaWest
        | [<JsonUnionCase("Australia/Yancowinna")>] AustraliaYancowinna
        | [<JsonUnionCase("Brazil/Acre")>] BrazilAcre
        | [<JsonUnionCase("Brazil/DeNoronha")>] BrazilDeNoronha
        | [<JsonUnionCase("Brazil/East")>] BrazilEast
        | [<JsonUnionCase("Brazil/West")>] BrazilWest
        | [<JsonUnionCase("CET")>] CET
        | [<JsonUnionCase("CST6CDT")>] CST6CDT
        | [<JsonUnionCase("Canada/Atlantic")>] CanadaAtlantic
        | [<JsonUnionCase("Canada/Central")>] CanadaCentral
        | [<JsonUnionCase("Canada/Eastern")>] CanadaEastern
        | [<JsonUnionCase("Canada/Mountain")>] CanadaMountain
        | [<JsonUnionCase("Canada/Newfoundland")>] CanadaNewfoundland
        | [<JsonUnionCase("Canada/Pacific")>] CanadaPacific
        | [<JsonUnionCase("Canada/Saskatchewan")>] CanadaSaskatchewan
        | [<JsonUnionCase("Canada/Yukon")>] CanadaYukon
        | [<JsonUnionCase("Chile/Continental")>] ChileContinental
        | [<JsonUnionCase("Chile/EasterIsland")>] ChileEasterIsland
        | [<JsonUnionCase("Cuba")>] Cuba
        | [<JsonUnionCase("EET")>] EET
        | [<JsonUnionCase("EST")>] EST
        | [<JsonUnionCase("EST5EDT")>] EST5EDT
        | [<JsonUnionCase("Egypt")>] Egypt
        | [<JsonUnionCase("Eire")>] Eire
        | [<JsonUnionCase("Etc/GMT")>] EtcGMT
        | [<JsonUnionCase("Etc/GMT+0")>] EtcGMTplus0
        | [<JsonUnionCase("Etc/GMT+1")>] EtcGMTplus1
        | [<JsonUnionCase("Etc/GMT+10")>] EtcGMTplus10
        | [<JsonUnionCase("Etc/GMT+11")>] EtcGMTplus11
        | [<JsonUnionCase("Etc/GMT+12")>] EtcGMTplus12
        | [<JsonUnionCase("Etc/GMT+2")>] EtcGMTplus2
        | [<JsonUnionCase("Etc/GMT+3")>] EtcGMTplus3
        | [<JsonUnionCase("Etc/GMT+4")>] EtcGMTplus4
        | [<JsonUnionCase("Etc/GMT+5")>] EtcGMTplus5
        | [<JsonUnionCase("Etc/GMT+6")>] EtcGMTplus6
        | [<JsonUnionCase("Etc/GMT+7")>] EtcGMTplus7
        | [<JsonUnionCase("Etc/GMT+8")>] EtcGMTplus8
        | [<JsonUnionCase("Etc/GMT+9")>] EtcGMTplus9
        | [<JsonUnionCase("Etc/GMT-0")>] EtcGMTminus0
        | [<JsonUnionCase("Etc/GMT-1")>] EtcGMTminus1
        | [<JsonUnionCase("Etc/GMT-10")>] EtcGMTminus10
        | [<JsonUnionCase("Etc/GMT-11")>] EtcGMTminus11
        | [<JsonUnionCase("Etc/GMT-12")>] EtcGMTminus12
        | [<JsonUnionCase("Etc/GMT-13")>] EtcGMTminus13
        | [<JsonUnionCase("Etc/GMT-14")>] EtcGMTminus14
        | [<JsonUnionCase("Etc/GMT-2")>] EtcGMTminus2
        | [<JsonUnionCase("Etc/GMT-3")>] EtcGMTminus3
        | [<JsonUnionCase("Etc/GMT-4")>] EtcGMTminus4
        | [<JsonUnionCase("Etc/GMT-5")>] EtcGMTminus5
        | [<JsonUnionCase("Etc/GMT-6")>] EtcGMTminus6
        | [<JsonUnionCase("Etc/GMT-7")>] EtcGMTminus7
        | [<JsonUnionCase("Etc/GMT-8")>] EtcGMTminus8
        | [<JsonUnionCase("Etc/GMT-9")>] EtcGMTminus9
        | [<JsonUnionCase("Etc/GMT0")>] EtcGMT0
        | [<JsonUnionCase("Etc/Greenwich")>] EtcGreenwich
        | [<JsonUnionCase("Etc/UCT")>] EtcUCT
        | [<JsonUnionCase("Etc/UTC")>] EtcUTC
        | [<JsonUnionCase("Etc/Universal")>] EtcUniversal
        | [<JsonUnionCase("Etc/Zulu")>] EtcZulu
        | [<JsonUnionCase("Europe/Amsterdam")>] EuropeAmsterdam
        | [<JsonUnionCase("Europe/Andorra")>] EuropeAndorra
        | [<JsonUnionCase("Europe/Astrakhan")>] EuropeAstrakhan
        | [<JsonUnionCase("Europe/Athens")>] EuropeAthens
        | [<JsonUnionCase("Europe/Belfast")>] EuropeBelfast
        | [<JsonUnionCase("Europe/Belgrade")>] EuropeBelgrade
        | [<JsonUnionCase("Europe/Berlin")>] EuropeBerlin
        | [<JsonUnionCase("Europe/Bratislava")>] EuropeBratislava
        | [<JsonUnionCase("Europe/Brussels")>] EuropeBrussels
        | [<JsonUnionCase("Europe/Bucharest")>] EuropeBucharest
        | [<JsonUnionCase("Europe/Budapest")>] EuropeBudapest
        | [<JsonUnionCase("Europe/Busingen")>] EuropeBusingen
        | [<JsonUnionCase("Europe/Chisinau")>] EuropeChisinau
        | [<JsonUnionCase("Europe/Copenhagen")>] EuropeCopenhagen
        | [<JsonUnionCase("Europe/Dublin")>] EuropeDublin
        | [<JsonUnionCase("Europe/Gibraltar")>] EuropeGibraltar
        | [<JsonUnionCase("Europe/Guernsey")>] EuropeGuernsey
        | [<JsonUnionCase("Europe/Helsinki")>] EuropeHelsinki
        | [<JsonUnionCase("Europe/Isle_of_Man")>] EuropeIsleOfMan
        | [<JsonUnionCase("Europe/Istanbul")>] EuropeIstanbul
        | [<JsonUnionCase("Europe/Jersey")>] EuropeJersey
        | [<JsonUnionCase("Europe/Kaliningrad")>] EuropeKaliningrad
        | [<JsonUnionCase("Europe/Kiev")>] EuropeKiev
        | [<JsonUnionCase("Europe/Kirov")>] EuropeKirov
        | [<JsonUnionCase("Europe/Lisbon")>] EuropeLisbon
        | [<JsonUnionCase("Europe/Ljubljana")>] EuropeLjubljana
        | [<JsonUnionCase("Europe/London")>] EuropeLondon
        | [<JsonUnionCase("Europe/Luxembourg")>] EuropeLuxembourg
        | [<JsonUnionCase("Europe/Madrid")>] EuropeMadrid
        | [<JsonUnionCase("Europe/Malta")>] EuropeMalta
        | [<JsonUnionCase("Europe/Mariehamn")>] EuropeMariehamn
        | [<JsonUnionCase("Europe/Minsk")>] EuropeMinsk
        | [<JsonUnionCase("Europe/Monaco")>] EuropeMonaco
        | [<JsonUnionCase("Europe/Moscow")>] EuropeMoscow
        | [<JsonUnionCase("Europe/Nicosia")>] EuropeNicosia
        | [<JsonUnionCase("Europe/Oslo")>] EuropeOslo
        | [<JsonUnionCase("Europe/Paris")>] EuropeParis
        | [<JsonUnionCase("Europe/Podgorica")>] EuropePodgorica
        | [<JsonUnionCase("Europe/Prague")>] EuropePrague
        | [<JsonUnionCase("Europe/Riga")>] EuropeRiga
        | [<JsonUnionCase("Europe/Rome")>] EuropeRome
        | [<JsonUnionCase("Europe/Samara")>] EuropeSamara
        | [<JsonUnionCase("Europe/San_Marino")>] EuropeSanMarino
        | [<JsonUnionCase("Europe/Sarajevo")>] EuropeSarajevo
        | [<JsonUnionCase("Europe/Saratov")>] EuropeSaratov
        | [<JsonUnionCase("Europe/Simferopol")>] EuropeSimferopol
        | [<JsonUnionCase("Europe/Skopje")>] EuropeSkopje
        | [<JsonUnionCase("Europe/Sofia")>] EuropeSofia
        | [<JsonUnionCase("Europe/Stockholm")>] EuropeStockholm
        | [<JsonUnionCase("Europe/Tallinn")>] EuropeTallinn
        | [<JsonUnionCase("Europe/Tirane")>] EuropeTirane
        | [<JsonUnionCase("Europe/Tiraspol")>] EuropeTiraspol
        | [<JsonUnionCase("Europe/Ulyanovsk")>] EuropeUlyanovsk
        | [<JsonUnionCase("Europe/Uzhgorod")>] EuropeUzhgorod
        | [<JsonUnionCase("Europe/Vaduz")>] EuropeVaduz
        | [<JsonUnionCase("Europe/Vatican")>] EuropeVatican
        | [<JsonUnionCase("Europe/Vienna")>] EuropeVienna
        | [<JsonUnionCase("Europe/Vilnius")>] EuropeVilnius
        | [<JsonUnionCase("Europe/Volgograd")>] EuropeVolgograd
        | [<JsonUnionCase("Europe/Warsaw")>] EuropeWarsaw
        | [<JsonUnionCase("Europe/Zagreb")>] EuropeZagreb
        | [<JsonUnionCase("Europe/Zaporozhye")>] EuropeZaporozhye
        | [<JsonUnionCase("Europe/Zurich")>] EuropeZurich
        | [<JsonUnionCase("Factory")>] Factory
        | [<JsonUnionCase("GB")>] GB
        | [<JsonUnionCase("GB-Eire")>] GBEire
        | [<JsonUnionCase("GMT")>] GMT
        | [<JsonUnionCase("GMT+0")>] GMTplus0
        | [<JsonUnionCase("GMT-0")>] GMTminus0
        | [<JsonUnionCase("GMT0")>] GMT0
        | [<JsonUnionCase("Greenwich")>] Greenwich
        | [<JsonUnionCase("HST")>] HST
        | [<JsonUnionCase("Hongkong")>] Hongkong
        | [<JsonUnionCase("Iceland")>] Iceland
        | [<JsonUnionCase("Indian/Antananarivo")>] IndianAntananarivo
        | [<JsonUnionCase("Indian/Chagos")>] IndianChagos
        | [<JsonUnionCase("Indian/Christmas")>] IndianChristmas
        | [<JsonUnionCase("Indian/Cocos")>] IndianCocos
        | [<JsonUnionCase("Indian/Comoro")>] IndianComoro
        | [<JsonUnionCase("Indian/Kerguelen")>] IndianKerguelen
        | [<JsonUnionCase("Indian/Mahe")>] IndianMahe
        | [<JsonUnionCase("Indian/Maldives")>] IndianMaldives
        | [<JsonUnionCase("Indian/Mauritius")>] IndianMauritius
        | [<JsonUnionCase("Indian/Mayotte")>] IndianMayotte
        | [<JsonUnionCase("Indian/Reunion")>] IndianReunion
        | [<JsonUnionCase("Iran")>] Iran
        | [<JsonUnionCase("Israel")>] Israel
        | [<JsonUnionCase("Jamaica")>] Jamaica
        | [<JsonUnionCase("Japan")>] Japan
        | [<JsonUnionCase("Kwajalein")>] Kwajalein
        | [<JsonUnionCase("Libya")>] Libya
        | [<JsonUnionCase("MET")>] MET
        | [<JsonUnionCase("MST")>] MST
        | [<JsonUnionCase("MST7MDT")>] MST7MDT
        | [<JsonUnionCase("Mexico/BajaNorte")>] MexicoBajaNorte
        | [<JsonUnionCase("Mexico/BajaSur")>] MexicoBajaSur
        | [<JsonUnionCase("Mexico/General")>] MexicoGeneral
        | [<JsonUnionCase("NZ")>] NZ
        | [<JsonUnionCase("NZ-CHAT")>] NZCHAT
        | [<JsonUnionCase("Navajo")>] Navajo
        | [<JsonUnionCase("PRC")>] PRC
        | [<JsonUnionCase("PST8PDT")>] PST8PDT
        | [<JsonUnionCase("Pacific/Apia")>] PacificApia
        | [<JsonUnionCase("Pacific/Auckland")>] PacificAuckland
        | [<JsonUnionCase("Pacific/Bougainville")>] PacificBougainville
        | [<JsonUnionCase("Pacific/Chatham")>] PacificChatham
        | [<JsonUnionCase("Pacific/Chuuk")>] PacificChuuk
        | [<JsonUnionCase("Pacific/Easter")>] PacificEaster
        | [<JsonUnionCase("Pacific/Efate")>] PacificEfate
        | [<JsonUnionCase("Pacific/Enderbury")>] PacificEnderbury
        | [<JsonUnionCase("Pacific/Fakaofo")>] PacificFakaofo
        | [<JsonUnionCase("Pacific/Fiji")>] PacificFiji
        | [<JsonUnionCase("Pacific/Funafuti")>] PacificFunafuti
        | [<JsonUnionCase("Pacific/Galapagos")>] PacificGalapagos
        | [<JsonUnionCase("Pacific/Gambier")>] PacificGambier
        | [<JsonUnionCase("Pacific/Guadalcanal")>] PacificGuadalcanal
        | [<JsonUnionCase("Pacific/Guam")>] PacificGuam
        | [<JsonUnionCase("Pacific/Honolulu")>] PacificHonolulu
        | [<JsonUnionCase("Pacific/Johnston")>] PacificJohnston
        | [<JsonUnionCase("Pacific/Kiritimati")>] PacificKiritimati
        | [<JsonUnionCase("Pacific/Kosrae")>] PacificKosrae
        | [<JsonUnionCase("Pacific/Kwajalein")>] PacificKwajalein
        | [<JsonUnionCase("Pacific/Majuro")>] PacificMajuro
        | [<JsonUnionCase("Pacific/Marquesas")>] PacificMarquesas
        | [<JsonUnionCase("Pacific/Midway")>] PacificMidway
        | [<JsonUnionCase("Pacific/Nauru")>] PacificNauru
        | [<JsonUnionCase("Pacific/Niue")>] PacificNiue
        | [<JsonUnionCase("Pacific/Norfolk")>] PacificNorfolk
        | [<JsonUnionCase("Pacific/Noumea")>] PacificNoumea
        | [<JsonUnionCase("Pacific/Pago_Pago")>] PacificPagoPago
        | [<JsonUnionCase("Pacific/Palau")>] PacificPalau
        | [<JsonUnionCase("Pacific/Pitcairn")>] PacificPitcairn
        | [<JsonUnionCase("Pacific/Pohnpei")>] PacificPohnpei
        | [<JsonUnionCase("Pacific/Ponape")>] PacificPonape
        | [<JsonUnionCase("Pacific/Port_Moresby")>] PacificPortMoresby
        | [<JsonUnionCase("Pacific/Rarotonga")>] PacificRarotonga
        | [<JsonUnionCase("Pacific/Saipan")>] PacificSaipan
        | [<JsonUnionCase("Pacific/Samoa")>] PacificSamoa
        | [<JsonUnionCase("Pacific/Tahiti")>] PacificTahiti
        | [<JsonUnionCase("Pacific/Tarawa")>] PacificTarawa
        | [<JsonUnionCase("Pacific/Tongatapu")>] PacificTongatapu
        | [<JsonUnionCase("Pacific/Truk")>] PacificTruk
        | [<JsonUnionCase("Pacific/Wake")>] PacificWake
        | [<JsonUnionCase("Pacific/Wallis")>] PacificWallis
        | [<JsonUnionCase("Pacific/Yap")>] PacificYap
        | [<JsonUnionCase("Poland")>] Poland
        | [<JsonUnionCase("Portugal")>] Portugal
        | [<JsonUnionCase("ROC")>] ROC
        | [<JsonUnionCase("ROK")>] ROK
        | [<JsonUnionCase("Singapore")>] Singapore
        | [<JsonUnionCase("Turkey")>] Turkey
        | [<JsonUnionCase("UCT")>] UCT
        | [<JsonUnionCase("US/Alaska")>] USAlaska
        | [<JsonUnionCase("US/Aleutian")>] USAleutian
        | [<JsonUnionCase("US/Arizona")>] USArizona
        | [<JsonUnionCase("US/Central")>] USCentral
        | [<JsonUnionCase("US/East-Indiana")>] USEastIndiana
        | [<JsonUnionCase("US/Eastern")>] USEastern
        | [<JsonUnionCase("US/Hawaii")>] USHawaii
        | [<JsonUnionCase("US/Indiana-Starke")>] USIndianaStarke
        | [<JsonUnionCase("US/Michigan")>] USMichigan
        | [<JsonUnionCase("US/Mountain")>] USMountain
        | [<JsonUnionCase("US/Pacific")>] USPacific
        | [<JsonUnionCase("US/Pacific-New")>] USPacificNew
        | [<JsonUnionCase("US/Samoa")>] USSamoa
        | [<JsonUnionCase("UTC")>] UTC
        | [<JsonUnionCase("Universal")>] Universal
        | [<JsonUnionCase("W-SU")>] WSU
        | [<JsonUnionCase("WET")>] WET
        | [<JsonUnionCase("Zulu")>] Zulu

    and PostReviewsReviewApproveParams (?expand: string list) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand

    and PostSetupIntentsParams (?confirm: bool, ?customer: string, ?description: string, ?expand: string list, ?mandateData: PostSetupIntentsMandateData, ?metadata: Map<string, string>, ?onBehalfOf: string, ?paymentMethod: string, ?paymentMethodOptions: PostSetupIntentsPaymentMethodOptions, ?paymentMethodTypes: string list, ?returnUrl: string, ?singleUse: PostSetupIntentsSingleUse, ?usage: PostSetupIntentsUsage) =
        ///Set to `true` to attempt to confirm this SetupIntent immediately. This parameter defaults to `false`. If the payment method attached is a card, a return_url may be provided in case additional authentication is required.
        member _.Confirm = confirm
        ///ID of the Customer this SetupIntent belongs to, if one exists.
        ///If present, the SetupIntent's payment method will be attached to the Customer on successful setup. Payment methods attached to other Customers cannot be used with this SetupIntent.
        member _.Customer = customer
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        member _.Description = description
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///This hash contains details about the Mandate to create. This parameter can only be used with [`confirm=true`](https://stripe.com/docs/api/setup_intents/create#create_setup_intent-confirm).
        member _.MandateData = mandateData
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The Stripe account ID for which this SetupIntent is created.
        member _.OnBehalfOf = onBehalfOf
        ///ID of the payment method (a PaymentMethod, Card, or saved Source object) to attach to this SetupIntent.
        member _.PaymentMethod = paymentMethod
        ///Payment-method-specific configuration for this SetupIntent.
        member _.PaymentMethodOptions = paymentMethodOptions
        ///The list of payment method types (e.g. card) that this SetupIntent is allowed to use. If this is not provided, defaults to ["card"].
        member _.PaymentMethodTypes = paymentMethodTypes
        ///The URL to redirect your customer back to after they authenticate or cancel their payment on the payment method's app or site. If you'd prefer to redirect to a mobile application, you can alternatively supply an application URI scheme. This parameter can only be used with [`confirm=true`](https://stripe.com/docs/api/setup_intents/create#create_setup_intent-confirm).
        member _.ReturnUrl = returnUrl
        ///If this hash is populated, this SetupIntent will generate a single_use Mandate on success.
        member _.SingleUse = singleUse
        ///Indicates how the payment method is intended to be used in the future. If not provided, this value defaults to `off_session`.
        member _.Usage = usage

    and PostSetupIntentsUsage =
        | OffSession
        | OnSession

    and PostSetupIntentsMandateData (?customerAcceptance: PostSetupIntentsMandateDataCustomerAcceptance) =
        ///This hash contains details about the customer acceptance of the Mandate.
        member _.CustomerAcceptance = customerAcceptance

    and PostSetupIntentsMandateDataCustomerAcceptance (?acceptedAt: DateTime, ?offline: string, ?online: PostSetupIntentsMandateDataCustomerAcceptanceOnline, ?``type``: PostSetupIntentsMandateDataCustomerAcceptanceType) =
        ///The time at which the customer accepted the Mandate.
        member _.AcceptedAt = acceptedAt
        ///If this is a Mandate accepted offline, this hash contains details about the offline acceptance.
        member _.Offline = offline
        ///If this is a Mandate accepted online, this hash contains details about the online acceptance.
        member _.Online = online
        ///The type of customer acceptance information included with the Mandate. One of `online` or `offline`.
        member _.Type = ``type``

    and PostSetupIntentsMandateDataCustomerAcceptanceType =
        | Offline
        | Online

    and PostSetupIntentsMandateDataCustomerAcceptanceOnline (?ipAddress: string, ?userAgent: string) =
        ///The IP address from which the Mandate was accepted by the customer.
        member _.IpAddress = ipAddress
        ///The user agent of the browser from which the Mandate was accepted by the customer.
        member _.UserAgent = userAgent

    and PostSetupIntentsPaymentMethodOptions (?card: PostSetupIntentsPaymentMethodOptionsCard, ?sepaDebit: PostSetupIntentsPaymentMethodOptionsSepaDebit) =
        ///Configuration for any card setup attempted on this SetupIntent.
        member _.Card = card
        ///If this is a `sepa_debit` SetupIntent, this sub-hash contains details about the SEPA Debit payment method options.
        member _.SepaDebit = sepaDebit

    and PostSetupIntentsPaymentMethodOptionsCard (?moto: bool, ?requestThreeDSecure: PostSetupIntentsPaymentMethodOptionsCardRequestThreeDSecure) =
        ///When specified, this parameter signals that a card has been collected
        ///as MOTO (Mail Order Telephone Order) and thus out of scope for SCA. This
        ///parameter can only be provided during confirmation.
        member _.Moto = moto
        ///We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://stripe.com/docs/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Permitted values include: `automatic` or `any`. If not provided, defaults to `automatic`. Read our guide on [manually requesting 3D Secure](https://stripe.com/docs/payments/3d-secure#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
        member _.RequestThreeDSecure = requestThreeDSecure

    and PostSetupIntentsPaymentMethodOptionsCardRequestThreeDSecure =
        | Any
        | Automatic

    and PostSetupIntentsPaymentMethodOptionsSepaDebit (?mandateOptions: string) =
        ///Additional fields for Mandate creation
        member _.MandateOptions = mandateOptions

    and PostSetupIntentsSingleUse (?amount: int, ?currency: string) =
        ///Amount the customer is granting permission to collect later. A positive integer representing how much to charge in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal) (e.g., 100 cents to charge $1.00 or 100 to charge ¥100, a zero-decimal currency). The minimum amount is $0.50 US or [equivalent in charge currency](https://stripe.com/docs/currencies#minimum-and-maximum-charge-amounts). The amount value supports up to eight digits (e.g., a value of 99999999 for a USD charge of $999,999.99).
        member _.Amount = amount
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency

    and PostSetupIntentsIntentParams (?customer: string, ?description: string, ?expand: string list, ?metadata: Map<string, string>, ?paymentMethod: string, ?paymentMethodOptions: PostSetupIntentsIntentPaymentMethodOptions, ?paymentMethodTypes: string list) =
        ///ID of the Customer this SetupIntent belongs to, if one exists.
        ///If present, the SetupIntent's payment method will be attached to the Customer on successful setup. Payment methods attached to other Customers cannot be used with this SetupIntent.
        member _.Customer = customer
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        member _.Description = description
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///ID of the payment method (a PaymentMethod, Card, or saved Source object) to attach to this SetupIntent.
        member _.PaymentMethod = paymentMethod
        ///Payment-method-specific configuration for this SetupIntent.
        member _.PaymentMethodOptions = paymentMethodOptions
        ///The list of payment method types (e.g. card) that this SetupIntent is allowed to set up. If this is not provided, defaults to ["card"].
        member _.PaymentMethodTypes = paymentMethodTypes

    and PostSetupIntentsIntentPaymentMethodOptions (?card: PostSetupIntentsIntentPaymentMethodOptionsCard, ?sepaDebit: PostSetupIntentsIntentPaymentMethodOptionsSepaDebit) =
        ///Configuration for any card setup attempted on this SetupIntent.
        member _.Card = card
        ///If this is a `sepa_debit` SetupIntent, this sub-hash contains details about the SEPA Debit payment method options.
        member _.SepaDebit = sepaDebit

    and PostSetupIntentsIntentPaymentMethodOptionsCard (?moto: bool, ?requestThreeDSecure: PostSetupIntentsIntentPaymentMethodOptionsCardRequestThreeDSecure) =
        ///When specified, this parameter signals that a card has been collected
        ///as MOTO (Mail Order Telephone Order) and thus out of scope for SCA. This
        ///parameter can only be provided during confirmation.
        member _.Moto = moto
        ///We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://stripe.com/docs/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Permitted values include: `automatic` or `any`. If not provided, defaults to `automatic`. Read our guide on [manually requesting 3D Secure](https://stripe.com/docs/payments/3d-secure#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
        member _.RequestThreeDSecure = requestThreeDSecure

    and PostSetupIntentsIntentPaymentMethodOptionsCardRequestThreeDSecure =
        | Any
        | Automatic

    and PostSetupIntentsIntentPaymentMethodOptionsSepaDebit (?mandateOptions: string) =
        ///Additional fields for Mandate creation
        member _.MandateOptions = mandateOptions

    and PostSetupIntentsIntentCancelParams (?cancellationReason: PostSetupIntentsIntentCancelCancellationReason, ?expand: string list) =
        ///Reason for canceling this SetupIntent. Possible values are `abandoned`, `requested_by_customer`, or `duplicate`
        member _.CancellationReason = cancellationReason
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand

    and PostSetupIntentsIntentCancelCancellationReason =
        | Abandoned
        | Duplicate
        | RequestedByCustomer

    and PostSetupIntentsIntentConfirmParams (?expand: string list, ?mandateData: Choice<PostSetupIntentsIntentConfirmMandateDataSecretKey,PostSetupIntentsIntentConfirmMandateDataClientKey>, ?paymentMethod: string, ?paymentMethodOptions: PostSetupIntentsIntentConfirmPaymentMethodOptions, ?returnUrl: string) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///This hash contains details about the Mandate to create
        member _.MandateData = mandateData
        ///ID of the payment method (a PaymentMethod, Card, or saved Source object) to attach to this SetupIntent.
        member _.PaymentMethod = paymentMethod
        ///Payment-method-specific configuration for this SetupIntent.
        member _.PaymentMethodOptions = paymentMethodOptions
        ///The URL to redirect your customer back to after they authenticate on the payment method's app or site.
        ///If you'd prefer to redirect to a mobile application, you can alternatively supply an application URI scheme.
        ///This parameter is only used for cards and other redirect-based payment methods.
        member _.ReturnUrl = returnUrl

    and PostSetupIntentsIntentConfirmMandateDataSecretKey (?customerAcceptance: PostSetupIntentsIntentConfirmMandateDataSecretKeyCustomerAcceptance) =
        ///This hash contains details about the customer acceptance of the Mandate.
        member _.CustomerAcceptance = customerAcceptance

    and PostSetupIntentsIntentConfirmMandateDataSecretKeyCustomerAcceptance (?acceptedAt: DateTime, ?offline: string, ?online: PostSetupIntentsIntentConfirmMandateDataSecretKeyCustomerAcceptanceOnline, ?``type``: PostSetupIntentsIntentConfirmMandateDataSecretKeyCustomerAcceptanceType) =
        ///The time at which the customer accepted the Mandate.
        member _.AcceptedAt = acceptedAt
        ///If this is a Mandate accepted offline, this hash contains details about the offline acceptance.
        member _.Offline = offline
        ///If this is a Mandate accepted online, this hash contains details about the online acceptance.
        member _.Online = online
        ///The type of customer acceptance information included with the Mandate. One of `online` or `offline`.
        member _.Type = ``type``

    and PostSetupIntentsIntentConfirmMandateDataSecretKeyCustomerAcceptanceType =
        | Offline
        | Online

    and PostSetupIntentsIntentConfirmMandateDataSecretKeyCustomerAcceptanceOnline (?ipAddress: string, ?userAgent: string) =
        ///The IP address from which the Mandate was accepted by the customer.
        member _.IpAddress = ipAddress
        ///The user agent of the browser from which the Mandate was accepted by the customer.
        member _.UserAgent = userAgent

    and PostSetupIntentsIntentConfirmMandateDataClientKey (?customerAcceptance: PostSetupIntentsIntentConfirmMandateDataClientKeyCustomerAcceptance) =
        ///This hash contains details about the customer acceptance of the Mandate.
        member _.CustomerAcceptance = customerAcceptance

    and PostSetupIntentsIntentConfirmMandateDataClientKeyCustomerAcceptance (?online: PostSetupIntentsIntentConfirmMandateDataClientKeyCustomerAcceptanceOnline, ?``type``: PostSetupIntentsIntentConfirmMandateDataClientKeyCustomerAcceptanceType) =
        ///If this is a Mandate accepted online, this hash contains details about the online acceptance.
        member _.Online = online
        ///The type of customer acceptance information included with the Mandate.
        member _.Type = ``type``

    and PostSetupIntentsIntentConfirmMandateDataClientKeyCustomerAcceptanceType =
        | Online

    and PostSetupIntentsIntentConfirmMandateDataClientKeyCustomerAcceptanceOnline (?ipAddress: string, ?userAgent: string) =
        ///The IP address from which the Mandate was accepted by the customer.
        member _.IpAddress = ipAddress
        ///The user agent of the browser from which the Mandate was accepted by the customer.
        member _.UserAgent = userAgent

    and PostSetupIntentsIntentConfirmPaymentMethodOptions (?card: PostSetupIntentsIntentConfirmPaymentMethodOptionsCard, ?sepaDebit: PostSetupIntentsIntentConfirmPaymentMethodOptionsSepaDebit) =
        ///Configuration for any card setup attempted on this SetupIntent.
        member _.Card = card
        ///If this is a `sepa_debit` SetupIntent, this sub-hash contains details about the SEPA Debit payment method options.
        member _.SepaDebit = sepaDebit

    and PostSetupIntentsIntentConfirmPaymentMethodOptionsCard (?moto: bool, ?requestThreeDSecure: PostSetupIntentsIntentConfirmPaymentMethodOptionsCardRequestThreeDSecure) =
        ///When specified, this parameter signals that a card has been collected
        ///as MOTO (Mail Order Telephone Order) and thus out of scope for SCA. This
        ///parameter can only be provided during confirmation.
        member _.Moto = moto
        ///We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://stripe.com/docs/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Permitted values include: `automatic` or `any`. If not provided, defaults to `automatic`. Read our guide on [manually requesting 3D Secure](https://stripe.com/docs/payments/3d-secure#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
        member _.RequestThreeDSecure = requestThreeDSecure

    and PostSetupIntentsIntentConfirmPaymentMethodOptionsCardRequestThreeDSecure =
        | Any
        | Automatic

    and PostSetupIntentsIntentConfirmPaymentMethodOptionsSepaDebit (?mandateOptions: string) =
        ///Additional fields for Mandate creation
        member _.MandateOptions = mandateOptions

    and PostSkusParams (currency: string, inventory: PostSkusInventory, price: int, product: string, ?active: bool, ?attributes: Map<string, string>, ?expand: string list, ?id: string, ?image: string, ?metadata: Map<string, string>, ?packageDimensions: PostSkusPackageDimensions) =
        ///Whether the SKU is available for purchase. Default to `true`.
        member _.Active = active
        ///A dictionary of attributes and values for the attributes defined by the product. If, for example, a product's attributes are `["size", "gender"]`, a valid SKU has the following dictionary of attributes: `{"size": "Medium", "gender": "Unisex"}`.
        member _.Attributes = attributes
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///The identifier for the SKU. Must be unique. If not provided, an identifier will be randomly generated.
        member _.Id = id
        ///The URL of an image for this SKU, meant to be displayable to the customer.
        member _.Image = image
        ///Description of the SKU's inventory.
        member _.Inventory = inventory
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The dimensions of this SKU for shipping purposes.
        member _.PackageDimensions = packageDimensions
        ///The cost of the item as a nonnegative integer in the smallest currency unit (that is, 100 cents to charge $1.00, or 100 to charge ¥100, Japanese Yen being a zero-decimal currency).
        member _.Price = price
        ///The ID of the product this SKU is associated with. Must be a product with type `good`.
        member _.Product = product

    and PostSkusInventory (?quantity: int, ?``type``: PostSkusInventoryType, ?value: PostSkusInventoryValue) =
        ///The count of inventory available. Required if `type` is `finite`.
        member _.Quantity = quantity
        ///Inventory type. Possible values are `finite`, `bucket` (not quantified), and `infinite`.
        member _.Type = ``type``
        ///An indicator of the inventory available. Possible values are `in_stock`, `limited`, and `out_of_stock`. Will be present if and only if `type` is `bucket`.
        member _.Value = value

    and PostSkusInventoryType =
        | Bucket
        | Finite
        | Infinite

    and PostSkusInventoryValue =
        | InStock
        | Limited
        | OutOfStock

    and PostSkusPackageDimensions (?height: decimal, ?length: decimal, ?weight: decimal, ?width: decimal) =
        ///Height, in inches. Maximum precision is 2 decimal places.
        member _.Height = height
        ///Length, in inches. Maximum precision is 2 decimal places.
        member _.Length = length
        ///Weight, in ounces. Maximum precision is 2 decimal places.
        member _.Weight = weight
        ///Width, in inches. Maximum precision is 2 decimal places.
        member _.Width = width

    and PostSkusIdParams (?active: bool, ?attributes: Map<string, string>, ?currency: string, ?expand: string list, ?image: string, ?inventory: PostSkusIdInventory, ?metadata: Map<string, string>, ?packageDimensions: Choice<PostSkusIdPackageDimensionsPackageDimensionsSpecs,string>, ?price: int, ?product: string) =
        ///Whether this SKU is available for purchase.
        member _.Active = active
        ///A dictionary of attributes and values for the attributes defined by the product. When specified, `attributes` will partially update the existing attributes dictionary on the product, with the postcondition that a value must be present for each attribute key on the product.
        member _.Attributes = attributes
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///The URL of an image for this SKU, meant to be displayable to the customer.
        member _.Image = image
        ///Description of the SKU's inventory.
        member _.Inventory = inventory
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The dimensions of this SKU for shipping purposes.
        member _.PackageDimensions = packageDimensions
        ///The cost of the item as a positive integer in the smallest currency unit (that is, 100 cents to charge $1.00, or 100 to charge ¥100, Japanese Yen being a zero-decimal currency).
        member _.Price = price
        ///The ID of the product that this SKU should belong to. The product must exist, have the same set of attribute names as the SKU's current product, and be of type `good`.
        member _.Product = product

    and PostSkusIdInventory (?quantity: int, ?``type``: PostSkusIdInventoryType, ?value: PostSkusIdInventoryValue) =
        ///The count of inventory available. Required if `type` is `finite`.
        member _.Quantity = quantity
        ///Inventory type. Possible values are `finite`, `bucket` (not quantified), and `infinite`.
        member _.Type = ``type``
        ///An indicator of the inventory available. Possible values are `in_stock`, `limited`, and `out_of_stock`. Will be present if and only if `type` is `bucket`.
        member _.Value = value

    and PostSkusIdInventoryType =
        | Bucket
        | Finite
        | Infinite

    and PostSkusIdInventoryValue =
        | InStock
        | Limited
        | OutOfStock

    and PostSkusIdPackageDimensionsPackageDimensionsSpecs (?height: decimal, ?length: decimal, ?weight: decimal, ?width: decimal) =
        ///Height, in inches. Maximum precision is 2 decimal places.
        member _.Height = height
        ///Length, in inches. Maximum precision is 2 decimal places.
        member _.Length = length
        ///Weight, in ounces. Maximum precision is 2 decimal places.
        member _.Weight = weight
        ///Width, in inches. Maximum precision is 2 decimal places.
        member _.Width = width

    and PostSourcesParams (?amount: int, ?currency: string, ?customer: string, ?expand: string list, ?flow: PostSourcesFlow, ?mandate: PostSourcesMandate, ?metadata: Map<string, string>, ?originalSource: string, ?owner: PostSourcesOwner, ?receiver: PostSourcesReceiver, ?redirect: PostSourcesRedirect, ?sourceOrder: PostSourcesSourceOrder, ?statementDescriptor: string, ?token: string, ?``type``: string, ?usage: PostSourcesUsage) =
        ///Amount associated with the source. This is the amount for which the source will be chargeable once ready. Required for `single_use` sources. Not supported for `receiver` type sources, where charge amount may not be specified until funds land.
        member _.Amount = amount
        ///Three-letter [ISO code for the currency](https://stripe.com/docs/currencies) associated with the source. This is the currency for which the source will be chargeable once ready.
        member _.Currency = currency
        ///The `Customer` to whom the original source is attached to. Must be set when the original source is not a `Source` (e.g., `Card`).
        member _.Customer = customer
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///The authentication `flow` of the source to create. `flow` is one of `redirect`, `receiver`, `code_verification`, `none`. It is generally inferred unless a type supports multiple flows.
        member _.Flow = flow
        ///Information about a mandate possibility attached to a source object (generally for bank debits) as well as its acceptance status.
        member _.Mandate = mandate
        ///
        member _.Metadata = metadata
        ///The source to share.
        member _.OriginalSource = originalSource
        ///Information about the owner of the payment instrument that may be used or required by particular source types.
        member _.Owner = owner
        ///Optional parameters for the receiver flow. Can be set only if the source is a receiver (`flow` is `receiver`).
        member _.Receiver = receiver
        ///Parameters required for the redirect flow. Required if the source is authenticated by a redirect (`flow` is `redirect`).
        member _.Redirect = redirect
        ///Information about the items and shipping associated with the source. Required for transactional credit (for example Klarna) sources before you can charge it.
        member _.SourceOrder = sourceOrder
        ///An arbitrary string to be displayed on your customer's statement. As an example, if your website is `RunClub` and the item you're charging for is a race ticket, you may want to specify a `statement_descriptor` of `RunClub 5K race ticket.` While many payment types will display this information, some may not display it at all.
        member _.StatementDescriptor = statementDescriptor
        ///An optional token used to create the source. When passed, token properties will override source parameters.
        member _.Token = token
        ///The `type` of the source to create. Required unless `customer` and `original_source` are specified (see the [Cloning card Sources](https://stripe.com/docs/sources/connect#cloning-card-sources) guide)
        member _.Type = ``type``
        ///
        member _.Usage = usage

    and PostSourcesFlow =
        | CodeVerification
        | None'
        | Receiver
        | Redirect

    and PostSourcesUsage =
        | Reusable
        | SingleUse

    and PostSourcesMandate (?acceptance: PostSourcesMandateAcceptance, ?amount: Choice<int,string>, ?currency: string, ?interval: PostSourcesMandateInterval, ?notificationMethod: PostSourcesMandateNotificationMethod) =
        ///The parameters required to notify Stripe of a mandate acceptance or refusal by the customer.
        member _.Acceptance = acceptance
        ///The amount specified by the mandate. (Leave null for a mandate covering all amounts)
        member _.Amount = amount
        ///The currency specified by the mandate. (Must match `currency` of the source)
        member _.Currency = currency
        ///The interval of debits permitted by the mandate. Either `one_time` (just permitting a single debit), `scheduled` (with debits on an agreed schedule or for clearly-defined events), or `variable`(for debits with any frequency)
        member _.Interval = interval
        ///The method Stripe should use to notify the customer of upcoming debit instructions and/or mandate confirmation as required by the underlying debit network. Either `email` (an email is sent directly to the customer), `manual` (a `source.mandate_notification` event is sent to your webhooks endpoint and you should handle the notification) or `none` (the underlying debit network does not require any notification).
        member _.NotificationMethod = notificationMethod

    and PostSourcesMandateInterval =
        | OneTime
        | Scheduled
        | Variable

    and PostSourcesMandateNotificationMethod =
        | DeprecatedNone'
        | Email
        | Manual
        | None'
        | StripeEmail

    and PostSourcesMandateAcceptance (?date: DateTime, ?ip: string, ?offline: PostSourcesMandateAcceptanceOffline, ?online: PostSourcesMandateAcceptanceOnline, ?status: PostSourcesMandateAcceptanceStatus, ?``type``: PostSourcesMandateAcceptanceType, ?userAgent: string) =
        ///The Unix timestamp (in seconds) when the mandate was accepted or refused by the customer.
        member _.Date = date
        ///The IP address from which the mandate was accepted or refused by the customer.
        member _.Ip = ip
        ///The parameters required to store a mandate accepted offline. Should only be set if `mandate[type]` is `offline`
        member _.Offline = offline
        ///The parameters required to store a mandate accepted online. Should only be set if `mandate[type]` is `online`
        member _.Online = online
        ///The status of the mandate acceptance. Either `accepted` (the mandate was accepted) or `refused` (the mandate was refused).
        member _.Status = status
        ///The type of acceptance information included with the mandate. Either `online` or `offline`
        member _.Type = ``type``
        ///The user agent of the browser from which the mandate was accepted or refused by the customer.
        member _.UserAgent = userAgent

    and PostSourcesMandateAcceptanceStatus =
        | Accepted
        | Pending
        | Refused
        | Revoked

    and PostSourcesMandateAcceptanceType =
        | Offline
        | Online

    and PostSourcesMandateAcceptanceOffline (?contactEmail: string) =
        ///An email to contact you with if a copy of the mandate is requested, required if `type` is `offline`.
        member _.ContactEmail = contactEmail

    and PostSourcesMandateAcceptanceOnline (?date: DateTime, ?ip: string, ?userAgent: string) =
        ///The Unix timestamp (in seconds) when the mandate was accepted or refused by the customer.
        member _.Date = date
        ///The IP address from which the mandate was accepted or refused by the customer.
        member _.Ip = ip
        ///The user agent of the browser from which the mandate was accepted or refused by the customer.
        member _.UserAgent = userAgent

    and PostSourcesOwner (?address: PostSourcesOwnerAddress, ?email: string, ?name: string, ?phone: string) =
        ///Owner's address.
        member _.Address = address
        ///Owner's email address.
        member _.Email = email
        ///Owner's full name.
        member _.Name = name
        ///Owner's phone number.
        member _.Phone = phone

    and PostSourcesOwnerAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostSourcesReceiver (?refundAttributesMethod: PostSourcesReceiverRefundAttributesMethod) =
        ///The method Stripe should use to request information needed to process a refund or mispayment. Either `email` (an email is sent directly to the customer) or `manual` (a `source.refund_attributes_required` event is sent to your webhooks endpoint). Refer to each payment method's documentation to learn which refund attributes may be required.
        member _.RefundAttributesMethod = refundAttributesMethod

    and PostSourcesReceiverRefundAttributesMethod =
        | Email
        | Manual
        | None'

    and PostSourcesRedirect (?returnUrl: string) =
        ///The URL you provide to redirect the customer back to you after they authenticated their payment. It can use your application URI scheme in the context of a mobile application.
        member _.ReturnUrl = returnUrl

    and PostSourcesSourceOrder (?items: PostSourcesSourceOrderItems list, ?shipping: PostSourcesSourceOrderShipping) =
        ///List of items constituting the order.
        member _.Items = items
        ///Shipping address for the order. Required if any of the SKUs are for products that have `shippable` set to true.
        member _.Shipping = shipping

    and PostSourcesSourceOrderItems (?amount: int, ?currency: string, ?description: string, ?parent: string, ?quantity: int, ?``type``: PostSourcesSourceOrderItemsType) =
        ///
        member _.Amount = amount
        ///
        member _.Currency = currency
        ///
        member _.Description = description
        ///The ID of the SKU being ordered.
        member _.Parent = parent
        ///The quantity of this order item. When type is `sku`, this is the number of instances of the SKU to be ordered.
        member _.Quantity = quantity
        ///
        member _.Type = ``type``

    and PostSourcesSourceOrderItemsType =
        | Discount
        | Shipping
        | Sku
        | Tax

    and PostSourcesSourceOrderShipping (?address: PostSourcesSourceOrderShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
        ///Shipping address.
        member _.Address = address
        ///The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc.
        member _.Carrier = carrier
        ///Recipient name.
        member _.Name = name
        ///Recipient phone (including extension).
        member _.Phone = phone
        ///The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
        member _.TrackingNumber = trackingNumber

    and PostSourcesSourceOrderShippingAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostSourcesSourceParams (?amount: int, ?expand: string list, ?mandate: PostSourcesSourceMandate, ?metadata: Map<string, string>, ?owner: PostSourcesSourceOwner, ?sourceOrder: PostSourcesSourceSourceOrder) =
        ///Amount associated with the source.
        member _.Amount = amount
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Information about a mandate possibility attached to a source object (generally for bank debits) as well as its acceptance status.
        member _.Mandate = mandate
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Information about the owner of the payment instrument that may be used or required by particular source types.
        member _.Owner = owner
        ///Information about the items and shipping associated with the source. Required for transactional credit (for example Klarna) sources before you can charge it.
        member _.SourceOrder = sourceOrder

    and PostSourcesSourceMandate (?acceptance: PostSourcesSourceMandateAcceptance, ?amount: Choice<int,string>, ?currency: string, ?interval: PostSourcesSourceMandateInterval, ?notificationMethod: PostSourcesSourceMandateNotificationMethod) =
        ///The parameters required to notify Stripe of a mandate acceptance or refusal by the customer.
        member _.Acceptance = acceptance
        ///The amount specified by the mandate. (Leave null for a mandate covering all amounts)
        member _.Amount = amount
        ///The currency specified by the mandate. (Must match `currency` of the source)
        member _.Currency = currency
        ///The interval of debits permitted by the mandate. Either `one_time` (just permitting a single debit), `scheduled` (with debits on an agreed schedule or for clearly-defined events), or `variable`(for debits with any frequency)
        member _.Interval = interval
        ///The method Stripe should use to notify the customer of upcoming debit instructions and/or mandate confirmation as required by the underlying debit network. Either `email` (an email is sent directly to the customer), `manual` (a `source.mandate_notification` event is sent to your webhooks endpoint and you should handle the notification) or `none` (the underlying debit network does not require any notification).
        member _.NotificationMethod = notificationMethod

    and PostSourcesSourceMandateInterval =
        | OneTime
        | Scheduled
        | Variable

    and PostSourcesSourceMandateNotificationMethod =
        | DeprecatedNone'
        | Email
        | Manual
        | None'
        | StripeEmail

    and PostSourcesSourceMandateAcceptance (?date: DateTime, ?ip: string, ?offline: PostSourcesSourceMandateAcceptanceOffline, ?online: PostSourcesSourceMandateAcceptanceOnline, ?status: PostSourcesSourceMandateAcceptanceStatus, ?``type``: PostSourcesSourceMandateAcceptanceType, ?userAgent: string) =
        ///The Unix timestamp (in seconds) when the mandate was accepted or refused by the customer.
        member _.Date = date
        ///The IP address from which the mandate was accepted or refused by the customer.
        member _.Ip = ip
        ///The parameters required to store a mandate accepted offline. Should only be set if `mandate[type]` is `offline`
        member _.Offline = offline
        ///The parameters required to store a mandate accepted online. Should only be set if `mandate[type]` is `online`
        member _.Online = online
        ///The status of the mandate acceptance. Either `accepted` (the mandate was accepted) or `refused` (the mandate was refused).
        member _.Status = status
        ///The type of acceptance information included with the mandate. Either `online` or `offline`
        member _.Type = ``type``
        ///The user agent of the browser from which the mandate was accepted or refused by the customer.
        member _.UserAgent = userAgent

    and PostSourcesSourceMandateAcceptanceStatus =
        | Accepted
        | Pending
        | Refused
        | Revoked

    and PostSourcesSourceMandateAcceptanceType =
        | Offline
        | Online

    and PostSourcesSourceMandateAcceptanceOffline (?contactEmail: string) =
        ///An email to contact you with if a copy of the mandate is requested, required if `type` is `offline`.
        member _.ContactEmail = contactEmail

    and PostSourcesSourceMandateAcceptanceOnline (?date: DateTime, ?ip: string, ?userAgent: string) =
        ///The Unix timestamp (in seconds) when the mandate was accepted or refused by the customer.
        member _.Date = date
        ///The IP address from which the mandate was accepted or refused by the customer.
        member _.Ip = ip
        ///The user agent of the browser from which the mandate was accepted or refused by the customer.
        member _.UserAgent = userAgent

    and PostSourcesSourceOwner (?address: PostSourcesSourceOwnerAddress, ?email: string, ?name: string, ?phone: string) =
        ///Owner's address.
        member _.Address = address
        ///Owner's email address.
        member _.Email = email
        ///Owner's full name.
        member _.Name = name
        ///Owner's phone number.
        member _.Phone = phone

    and PostSourcesSourceOwnerAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostSourcesSourceSourceOrder (?items: PostSourcesSourceSourceOrderItems list, ?shipping: PostSourcesSourceSourceOrderShipping) =
        ///List of items constituting the order.
        member _.Items = items
        ///Shipping address for the order. Required if any of the SKUs are for products that have `shippable` set to true.
        member _.Shipping = shipping

    and PostSourcesSourceSourceOrderItems (?amount: int, ?currency: string, ?description: string, ?parent: string, ?quantity: int, ?``type``: PostSourcesSourceSourceOrderItemsType) =
        ///
        member _.Amount = amount
        ///
        member _.Currency = currency
        ///
        member _.Description = description
        ///The ID of the SKU being ordered.
        member _.Parent = parent
        ///The quantity of this order item. When type is `sku`, this is the number of instances of the SKU to be ordered.
        member _.Quantity = quantity
        ///
        member _.Type = ``type``

    and PostSourcesSourceSourceOrderItemsType =
        | Discount
        | Shipping
        | Sku
        | Tax

    and PostSourcesSourceSourceOrderShipping (?address: PostSourcesSourceSourceOrderShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
        ///Shipping address.
        member _.Address = address
        ///The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc.
        member _.Carrier = carrier
        ///Recipient name.
        member _.Name = name
        ///Recipient phone (including extension).
        member _.Phone = phone
        ///The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
        member _.TrackingNumber = trackingNumber

    and PostSourcesSourceSourceOrderShippingAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostSourcesSourceVerifyParams (values: string list, ?expand: string list) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///The values needed to verify the source.
        member _.Values = values

    and PostSubscriptionItemsParams (subscription: string, ?billingThresholds: Choice<PostSubscriptionItemsBillingThresholdsItemBillingThresholds,string>, ?expand: string list, ?metadata: Map<string, string>, ?paymentBehavior: PostSubscriptionItemsPaymentBehavior, ?plan: string, ?price: string, ?priceData: PostSubscriptionItemsPriceData, ?prorationBehavior: PostSubscriptionItemsProrationBehavior, ?prorationDate: DateTime, ?quantity: int, ?taxRates: Choice<string list,string>) =
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. When updating, pass an empty string to remove previously-defined thresholds.
        member _.BillingThresholds = billingThresholds
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Use `allow_incomplete` to transition the subscription to `status=past_due` if a payment is required but cannot be paid. This allows you to manage scenarios where additional user actions are needed to pay a subscription's invoice. For example, SCA regulation may require 3DS authentication to complete payment. See the [SCA Migration Guide](https://stripe.com/docs/billing/migration/strong-customer-authentication) for Billing to learn more. This is the default behavior.
        ///Use `pending_if_incomplete` to update the subscription using [pending updates](https://stripe.com/docs/billing/subscriptions/pending-updates). When you use `pending_if_incomplete` you can only pass the parameters [supported by pending updates](https://stripe.com/docs/billing/pending-updates-reference#supported-attributes).
        ///Use `error_if_incomplete` if you want Stripe to return an HTTP 402 status code if a subscription's invoice cannot be paid. For example, if a payment method requires 3DS authentication due to SCA regulation and further user action is needed, this parameter does not update the subscription and returns an error instead. This was the default behavior for API versions prior to 2019-03-14. See the [changelog](https://stripe.com/docs/upgrades#2019-03-14) to learn more.
        member _.PaymentBehavior = paymentBehavior
        ///The identifier of the plan to add to the subscription.
        member _.Plan = plan
        ///The ID of the price object.
        member _.Price = price
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline.
        member _.PriceData = priceData
        ///Determines how to handle [prorations](https://stripe.com/docs/subscriptions/billing-cycle#prorations) when the billing cycle changes (e.g., when switching plans, resetting `billing_cycle_anchor=now`, or starting a trial), or if an item's `quantity` changes. Valid values are `create_prorations`, `none`, or `always_invoice`.
        ///Passing `create_prorations` will cause proration invoice items to be created when applicable. These proration items will only be invoiced immediately under [certain conditions](https://stripe.com/docs/subscriptions/upgrading-downgrading#immediate-payment). In order to always invoice immediately for prorations, pass `always_invoice`.
        ///Prorations can be disabled by passing `none`.
        member _.ProrationBehavior = prorationBehavior
        ///If set, the proration will be calculated as though the subscription was updated at the given time. This can be used to apply the same proration that was previewed with the [upcoming invoice](https://stripe.com/docs/api#retrieve_customer_invoice) endpoint.
        member _.ProrationDate = prorationDate
        ///The quantity you'd like to apply to the subscription item you're creating.
        member _.Quantity = quantity
        ///The identifier of the subscription to modify.
        member _.Subscription = subscription
        ///A list of [Tax Rate](https://stripe.com/docs/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://stripe.com/docs/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.
        member _.TaxRates = taxRates

    and PostSubscriptionItemsPaymentBehavior =
        | AllowIncomplete
        | ErrorIfIncomplete
        | PendingIfIncomplete

    and PostSubscriptionItemsProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | None'

    and PostSubscriptionItemsBillingThresholdsItemBillingThresholds (?usageGte: int) =
        ///Usage threshold that triggers the subscription to advance to a new billing period
        member _.UsageGte = usageGte

    and PostSubscriptionItemsPriceData (?currency: string, ?product: string, ?recurring: PostSubscriptionItemsPriceDataRecurring, ?unitAmount: int, ?unitAmountDecimal: string) =
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///The ID of the product that this price will belong to.
        member _.Product = product
        ///The recurring components of a price such as `interval` and `usage_type`.
        member _.Recurring = recurring
        ///A positive integer in %s (or 0 for a free price) representing how much to charge.
        member _.UnitAmount = unitAmount
        ///Same as `unit_amount`, but accepts a decimal value in %s with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        member _.UnitAmountDecimal = unitAmountDecimal

    and PostSubscriptionItemsPriceDataRecurring (?interval: PostSubscriptionItemsPriceDataRecurringInterval, ?intervalCount: int) =
        ///Specifies billing frequency. Either `day`, `week`, `month` or `year`.
        member _.Interval = interval
        ///The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        member _.IntervalCount = intervalCount

    and PostSubscriptionItemsPriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    and DeleteSubscriptionItemsItemParams (?clearUsage: bool, ?prorationBehavior: DeleteSubscriptionItemsItemProrationBehavior, ?prorationDate: DateTime) =
        ///Delete all usage for the given subscription item. Allowed only when the current plan's `usage_type` is `metered`.
        member _.ClearUsage = clearUsage
        ///Determines how to handle [prorations](https://stripe.com/docs/subscriptions/billing-cycle#prorations) when the billing cycle changes (e.g., when switching plans, resetting `billing_cycle_anchor=now`, or starting a trial), or if an item's `quantity` changes. Valid values are `create_prorations`, `none`, or `always_invoice`.
        ///Passing `create_prorations` will cause proration invoice items to be created when applicable. These proration items will only be invoiced immediately under [certain conditions](https://stripe.com/docs/subscriptions/upgrading-downgrading#immediate-payment). In order to always invoice immediately for prorations, pass `always_invoice`.
        ///Prorations can be disabled by passing `none`.
        member _.ProrationBehavior = prorationBehavior
        ///If set, the proration will be calculated as though the subscription was updated at the given time. This can be used to apply the same proration that was previewed with the [upcoming invoice](https://stripe.com/docs/api#retrieve_customer_invoice) endpoint.
        member _.ProrationDate = prorationDate

    and DeleteSubscriptionItemsItemProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | None'

    and PostSubscriptionItemsItemParams (?billingThresholds: Choice<PostSubscriptionItemsItemBillingThresholdsItemBillingThresholds,string>, ?expand: string list, ?metadata: Map<string, string>, ?offSession: bool, ?paymentBehavior: PostSubscriptionItemsItemPaymentBehavior, ?plan: string, ?price: string, ?priceData: PostSubscriptionItemsItemPriceData, ?prorationBehavior: PostSubscriptionItemsItemProrationBehavior, ?prorationDate: DateTime, ?quantity: int, ?taxRates: Choice<string list,string>) =
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. When updating, pass an empty string to remove previously-defined thresholds.
        member _.BillingThresholds = billingThresholds
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Indicates if a customer is on or off-session while an invoice payment is attempted.
        member _.OffSession = offSession
        ///Use `allow_incomplete` to transition the subscription to `status=past_due` if a payment is required but cannot be paid. This allows you to manage scenarios where additional user actions are needed to pay a subscription's invoice. For example, SCA regulation may require 3DS authentication to complete payment. See the [SCA Migration Guide](https://stripe.com/docs/billing/migration/strong-customer-authentication) for Billing to learn more. This is the default behavior.
        ///Use `pending_if_incomplete` to update the subscription using [pending updates](https://stripe.com/docs/billing/subscriptions/pending-updates). When you use `pending_if_incomplete` you can only pass the parameters [supported by pending updates](https://stripe.com/docs/billing/pending-updates-reference#supported-attributes).
        ///Use `error_if_incomplete` if you want Stripe to return an HTTP 402 status code if a subscription's invoice cannot be paid. For example, if a payment method requires 3DS authentication due to SCA regulation and further user action is needed, this parameter does not update the subscription and returns an error instead. This was the default behavior for API versions prior to 2019-03-14. See the [changelog](https://stripe.com/docs/upgrades#2019-03-14) to learn more.
        member _.PaymentBehavior = paymentBehavior
        ///The identifier of the new plan for this subscription item.
        member _.Plan = plan
        ///The ID of the price object.
        member _.Price = price
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline.
        member _.PriceData = priceData
        ///Determines how to handle [prorations](https://stripe.com/docs/subscriptions/billing-cycle#prorations) when the billing cycle changes (e.g., when switching plans, resetting `billing_cycle_anchor=now`, or starting a trial), or if an item's `quantity` changes. Valid values are `create_prorations`, `none`, or `always_invoice`.
        ///Passing `create_prorations` will cause proration invoice items to be created when applicable. These proration items will only be invoiced immediately under [certain conditions](https://stripe.com/docs/subscriptions/upgrading-downgrading#immediate-payment). In order to always invoice immediately for prorations, pass `always_invoice`.
        ///Prorations can be disabled by passing `none`.
        member _.ProrationBehavior = prorationBehavior
        ///If set, the proration will be calculated as though the subscription was updated at the given time. This can be used to apply the same proration that was previewed with the [upcoming invoice](https://stripe.com/docs/api#retrieve_customer_invoice) endpoint.
        member _.ProrationDate = prorationDate
        ///The quantity you'd like to apply to the subscription item you're creating.
        member _.Quantity = quantity
        ///A list of [Tax Rate](https://stripe.com/docs/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://stripe.com/docs/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.
        member _.TaxRates = taxRates

    and PostSubscriptionItemsItemPaymentBehavior =
        | AllowIncomplete
        | ErrorIfIncomplete
        | PendingIfIncomplete

    and PostSubscriptionItemsItemProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | None'

    and PostSubscriptionItemsItemBillingThresholdsItemBillingThresholds (?usageGte: int) =
        ///Usage threshold that triggers the subscription to advance to a new billing period
        member _.UsageGte = usageGte

    and PostSubscriptionItemsItemPriceData (?currency: string, ?product: string, ?recurring: PostSubscriptionItemsItemPriceDataRecurring, ?unitAmount: int, ?unitAmountDecimal: string) =
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///The ID of the product that this price will belong to.
        member _.Product = product
        ///The recurring components of a price such as `interval` and `usage_type`.
        member _.Recurring = recurring
        ///A positive integer in %s (or 0 for a free price) representing how much to charge.
        member _.UnitAmount = unitAmount
        ///Same as `unit_amount`, but accepts a decimal value in %s with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        member _.UnitAmountDecimal = unitAmountDecimal

    and PostSubscriptionItemsItemPriceDataRecurring (?interval: PostSubscriptionItemsItemPriceDataRecurringInterval, ?intervalCount: int) =
        ///Specifies billing frequency. Either `day`, `week`, `month` or `year`.
        member _.Interval = interval
        ///The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        member _.IntervalCount = intervalCount

    and PostSubscriptionItemsItemPriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    and PostSubscriptionItemsSubscriptionItemUsageRecordsParams (quantity: int, timestamp: int, ?action: PostSubscriptionItemsSubscriptionItemUsageRecordsAction, ?expand: string list) =
        ///Valid values are `increment` (default) or `set`. When using `increment` the specified `quantity` will be added to the usage at the specified timestamp. The `set` action will overwrite the usage quantity at that timestamp. If the subscription has [billing thresholds](https://stripe.com/docs/api/subscriptions/object#subscription_object-billing_thresholds), `increment` is the only allowed value.
        member _.Action = action
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///The usage quantity for the specified timestamp.
        member _.Quantity = quantity
        ///The timestamp for the usage event. This timestamp must be within the current billing period of the subscription of the provided `subscription_item`.
        member _.Timestamp = timestamp

    and PostSubscriptionItemsSubscriptionItemUsageRecordsAction =
        | Increment
        | Set

    and PostSubscriptionSchedulesParams (?customer: string, ?defaultSettings: PostSubscriptionSchedulesDefaultSettings, ?endBehavior: PostSubscriptionSchedulesEndBehavior, ?expand: string list, ?fromSubscription: string, ?metadata: Map<string, string>, ?phases: PostSubscriptionSchedulesPhases list, ?startDate: Choice<int,PostSubscriptionSchedulesStartDate>) =
        ///The identifier of the customer to create the subscription schedule for.
        member _.Customer = customer
        ///Object representing the subscription schedule's default settings.
        member _.DefaultSettings = defaultSettings
        ///Configures how the subscription schedule behaves when it ends. Possible values are `release` or `cancel` with the default being `release`. `release` will end the subscription schedule and keep the underlying subscription running.`cancel` will end the subscription schedule and cancel the underlying subscription.
        member _.EndBehavior = endBehavior
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Migrate an existing subscription to be managed by a subscription schedule. If this parameter is set, a subscription schedule will be created using the subscription's item(s), set to auto-renew using the subscription's interval. When using this parameter, other parameters (such as phase values) cannot be set. To create a subscription schedule with other modifications, we recommend making two separate API calls.
        member _.FromSubscription = fromSubscription
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///List representing phases of the subscription schedule. Each phase can be customized to have different durations, plans, and coupons. If there are multiple phases, the `end_date` of one phase will always equal the `start_date` of the next phase.
        member _.Phases = phases
        ///When the subscription schedule starts. We recommend using `now` so that it starts the subscription immediately. You can also use a Unix timestamp to backdate the subscription so that it starts on a past date, or set a future date for the subscription to start on.
        member _.StartDate = startDate

    and PostSubscriptionSchedulesEndBehavior =
        | Cancel
        | None'
        | Release
        | Renew

    and PostSubscriptionSchedulesDefaultSettings (?billingCycleAnchor: PostSubscriptionSchedulesDefaultSettingsBillingCycleAnchor, ?billingThresholds: Choice<PostSubscriptionSchedulesDefaultSettingsBillingThresholdsBillingThresholds,string>, ?collectionMethod: PostSubscriptionSchedulesDefaultSettingsCollectionMethod, ?defaultPaymentMethod: string, ?invoiceSettings: PostSubscriptionSchedulesDefaultSettingsInvoiceSettings, ?transferData: Choice<PostSubscriptionSchedulesDefaultSettingsTransferDataTransferDataSpecs,string>) =
        ///Can be set to `phase_start` to set the anchor to the start of the phase or `automatic` to automatically change it if needed. Cannot be set to `phase_start` if this phase specifies a trial. For more information, see the billing cycle [documentation](https://stripe.com/docs/billing/subscriptions/billing-cycle).
        member _.BillingCycleAnchor = billingCycleAnchor
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
        member _.BillingThresholds = billingThresholds
        ///Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay the underlying subscription at the end of each billing cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions. Defaults to `charge_automatically` on creation.
        member _.CollectionMethod = collectionMethod
        ///ID of the default payment method for the subscription schedule. It must belong to the customer associated with the subscription schedule. If not set, invoices will use the default payment method in the customer's invoice settings.
        member _.DefaultPaymentMethod = defaultPaymentMethod
        ///All invoices will be billed using the specified settings.
        member _.InvoiceSettings = invoiceSettings
        ///The data with which to automatically create a Transfer for each of the associated subscription's invoices.
        member _.TransferData = transferData

    and PostSubscriptionSchedulesDefaultSettingsBillingCycleAnchor =
        | Automatic
        | PhaseStart

    and PostSubscriptionSchedulesDefaultSettingsCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    and PostSubscriptionSchedulesDefaultSettingsBillingThresholdsBillingThresholds (?amountGte: int, ?resetBillingCycleAnchor: bool) =
        ///Monetary threshold that triggers the subscription to advance to a new billing period
        member _.AmountGte = amountGte
        ///Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.
        member _.ResetBillingCycleAnchor = resetBillingCycleAnchor

    and PostSubscriptionSchedulesDefaultSettingsInvoiceSettings (?daysUntilDue: int) =
        ///Number of days within which a customer must pay invoices generated by this subscription schedule. This value will be `null` for subscription schedules where `billing=charge_automatically`.
        member _.DaysUntilDue = daysUntilDue

    and PostSubscriptionSchedulesDefaultSettingsTransferDataTransferDataSpecs (?amountPercent: decimal, ?destination: string) =
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice subtotal that will be transferred to the destination account. By default, the entire amount is transferred to the destination.
        member _.AmountPercent = amountPercent
        ///ID of an existing, connected Stripe account.
        member _.Destination = destination

    and PostSubscriptionSchedulesPhases (?addInvoiceItems: PostSubscriptionSchedulesPhasesAddInvoiceItems list, ?applicationFeePercent: decimal, ?billingCycleAnchor: PostSubscriptionSchedulesPhasesBillingCycleAnchor, ?billingThresholds: Choice<PostSubscriptionSchedulesPhasesBillingThresholdsBillingThresholds,string>, ?collectionMethod: PostSubscriptionSchedulesPhasesCollectionMethod, ?coupon: string, ?defaultPaymentMethod: string, ?defaultTaxRates: Choice<string list,string>, ?endDate: DateTime, ?invoiceSettings: PostSubscriptionSchedulesPhasesInvoiceSettings, ?items: PostSubscriptionSchedulesPhasesItems list, ?iterations: int, ?prorationBehavior: PostSubscriptionSchedulesPhasesProrationBehavior, ?transferData: PostSubscriptionSchedulesPhasesTransferData, ?trial: bool, ?trialEnd: DateTime) =
        ///A list of prices and quantities that will generate invoice items appended to the next invoice. You may pass up to 10 items.
        member _.AddInvoiceItems = addInvoiceItems
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice subtotal that will be transferred to the application owner's Stripe account. The request must be made by a platform account on a connected account in order to set an application fee percentage. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).
        member _.ApplicationFeePercent = applicationFeePercent
        ///Can be set to `phase_start` to set the anchor to the start of the phase or `automatic` to automatically change it if needed. Cannot be set to `phase_start` if this phase specifies a trial. For more information, see the billing cycle [documentation](https://stripe.com/docs/billing/subscriptions/billing-cycle).
        member _.BillingCycleAnchor = billingCycleAnchor
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
        member _.BillingThresholds = billingThresholds
        ///Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay the underlying subscription at the end of each billing cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions. Defaults to `charge_automatically` on creation.
        member _.CollectionMethod = collectionMethod
        ///The identifier of the coupon to apply to this phase of the subscription schedule.
        member _.Coupon = coupon
        ///ID of the default payment method for the subscription schedule. It must belong to the customer associated with the subscription schedule. If not set, invoices will use the default payment method in the customer's invoice settings.
        member _.DefaultPaymentMethod = defaultPaymentMethod
        ///A list of [Tax Rate](https://stripe.com/docs/api/tax_rates) ids. These Tax Rates will set the Subscription's [`default_tax_rates`](https://stripe.com/docs/api/subscriptions/create#create_subscription-default_tax_rates), which means they will be the Invoice's [`default_tax_rates`](https://stripe.com/docs/api/invoices/create#create_invoice-default_tax_rates) for any Invoices issued by the Subscription during this Phase.
        member _.DefaultTaxRates = defaultTaxRates
        ///The date at which this phase of the subscription schedule ends. If set, `iterations` must not be set.
        member _.EndDate = endDate
        ///All invoices will be billed using the specified settings.
        member _.InvoiceSettings = invoiceSettings
        ///List of configuration items, each with an attached price, to apply during this phase of the subscription schedule.
        member _.Items = items
        ///Integer representing the multiplier applied to the price interval. For example, `iterations=2` applied to a price with `interval=month` and `interval_count=3` results in a phase of duration `2 * 3 months = 6 months`. If set, `end_date` must not be set.
        member _.Iterations = iterations
        ///If a subscription schedule will create prorations when transitioning to this phase. Possible values are `create_prorations` or `none`, and the default value is `create_prorations`. See [Prorations](https://stripe.com/docs/billing/subscriptions/prorations).
        member _.ProrationBehavior = prorationBehavior
        ///The data with which to automatically create a Transfer for each of the associated subscription's invoices.
        member _.TransferData = transferData
        ///If set to true the entire phase is counted as a trial and the customer will not be charged for any fees.
        member _.Trial = trial
        ///Sets the phase to trialing from the start date to this date. Must be before the phase end date, can not be combined with `trial`
        member _.TrialEnd = trialEnd

    and PostSubscriptionSchedulesPhasesBillingCycleAnchor =
        | Automatic
        | PhaseStart

    and PostSubscriptionSchedulesPhasesCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    and PostSubscriptionSchedulesPhasesProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | None'

    and PostSubscriptionSchedulesPhasesAddInvoiceItems (?price: string, ?priceData: PostSubscriptionSchedulesPhasesAddInvoiceItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
        ///The ID of the price object.
        member _.Price = price
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline.
        member _.PriceData = priceData
        ///Quantity for this item. Defaults to 1.
        member _.Quantity = quantity
        ///The tax rates which apply to the item. When set, the `default_tax_rates` do not apply to this item.
        member _.TaxRates = taxRates

    and PostSubscriptionSchedulesPhasesAddInvoiceItemsPriceData (?currency: string, ?product: string, ?unitAmount: int, ?unitAmountDecimal: string) =
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///The ID of the product that this price will belong to.
        member _.Product = product
        ///A positive integer in %s (or 0 for a free price) representing how much to charge.
        member _.UnitAmount = unitAmount
        ///Same as `unit_amount`, but accepts a decimal value in %s with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        member _.UnitAmountDecimal = unitAmountDecimal

    and PostSubscriptionSchedulesPhasesBillingThresholdsBillingThresholds (?amountGte: int, ?resetBillingCycleAnchor: bool) =
        ///Monetary threshold that triggers the subscription to advance to a new billing period
        member _.AmountGte = amountGte
        ///Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.
        member _.ResetBillingCycleAnchor = resetBillingCycleAnchor

    and PostSubscriptionSchedulesPhasesInvoiceSettings (?daysUntilDue: int) =
        ///Number of days within which a customer must pay invoices generated by this subscription schedule. This value will be `null` for subscription schedules where `billing=charge_automatically`.
        member _.DaysUntilDue = daysUntilDue

    and PostSubscriptionSchedulesPhasesItems (?billingThresholds: Choice<PostSubscriptionSchedulesPhasesItemsBillingThresholdsItemBillingThresholds,string>, ?plan: string, ?price: string, ?priceData: PostSubscriptionSchedulesPhasesItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. When updating, pass an empty string to remove previously-defined thresholds.
        member _.BillingThresholds = billingThresholds
        ///The plan ID to subscribe to. You may specify the same ID in `plan` and `price`.
        member _.Plan = plan
        ///The ID of the price object.
        member _.Price = price
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline.
        member _.PriceData = priceData
        ///Quantity for the given price. Can be set only if the price's `usage_type` is `licensed` and not `metered`.
        member _.Quantity = quantity
        ///A list of [Tax Rate](https://stripe.com/docs/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://stripe.com/docs/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.
        member _.TaxRates = taxRates

    and PostSubscriptionSchedulesPhasesItemsBillingThresholdsItemBillingThresholds (?usageGte: int) =
        ///Usage threshold that triggers the subscription to advance to a new billing period
        member _.UsageGte = usageGte

    and PostSubscriptionSchedulesPhasesItemsPriceData (?currency: string, ?product: string, ?recurring: PostSubscriptionSchedulesPhasesItemsPriceDataRecurring, ?unitAmount: int, ?unitAmountDecimal: string) =
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///The ID of the product that this price will belong to.
        member _.Product = product
        ///The recurring components of a price such as `interval` and `usage_type`.
        member _.Recurring = recurring
        ///A positive integer in %s (or 0 for a free price) representing how much to charge.
        member _.UnitAmount = unitAmount
        ///Same as `unit_amount`, but accepts a decimal value in %s with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        member _.UnitAmountDecimal = unitAmountDecimal

    and PostSubscriptionSchedulesPhasesItemsPriceDataRecurring (?interval: PostSubscriptionSchedulesPhasesItemsPriceDataRecurringInterval, ?intervalCount: int) =
        ///Specifies billing frequency. Either `day`, `week`, `month` or `year`.
        member _.Interval = interval
        ///The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        member _.IntervalCount = intervalCount

    and PostSubscriptionSchedulesPhasesItemsPriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    and PostSubscriptionSchedulesPhasesTransferData (?amountPercent: decimal, ?destination: string) =
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice subtotal that will be transferred to the destination account. By default, the entire amount is transferred to the destination.
        member _.AmountPercent = amountPercent
        ///ID of an existing, connected Stripe account.
        member _.Destination = destination

    and PostSubscriptionSchedulesStartDate =
        | Now

    and PostSubscriptionSchedulesScheduleParams (?defaultSettings: PostSubscriptionSchedulesScheduleDefaultSettings, ?endBehavior: PostSubscriptionSchedulesScheduleEndBehavior, ?expand: string list, ?metadata: Map<string, string>, ?phases: PostSubscriptionSchedulesSchedulePhases list, ?prorationBehavior: PostSubscriptionSchedulesScheduleProrationBehavior) =
        ///Object representing the subscription schedule's default settings.
        member _.DefaultSettings = defaultSettings
        ///Configures how the subscription schedule behaves when it ends. Possible values are `release` or `cancel` with the default being `release`. `release` will end the subscription schedule and keep the underlying subscription running.`cancel` will end the subscription schedule and cancel the underlying subscription.
        member _.EndBehavior = endBehavior
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///List representing phases of the subscription schedule. Each phase can be customized to have different durations, plans, and coupons. If there are multiple phases, the `end_date` of one phase will always equal the `start_date` of the next phase. Note that past phases can be omitted.
        member _.Phases = phases
        ///If the update changes the current phase, indicates if the changes should be prorated. Possible values are `create_prorations` or `none`, and the default value is `create_prorations`.
        member _.ProrationBehavior = prorationBehavior

    and PostSubscriptionSchedulesScheduleEndBehavior =
        | Cancel
        | None'
        | Release
        | Renew

    and PostSubscriptionSchedulesScheduleProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | None'

    and PostSubscriptionSchedulesScheduleDefaultSettings (?billingCycleAnchor: PostSubscriptionSchedulesScheduleDefaultSettingsBillingCycleAnchor, ?billingThresholds: Choice<PostSubscriptionSchedulesScheduleDefaultSettingsBillingThresholdsBillingThresholds,string>, ?collectionMethod: PostSubscriptionSchedulesScheduleDefaultSettingsCollectionMethod, ?defaultPaymentMethod: string, ?invoiceSettings: PostSubscriptionSchedulesScheduleDefaultSettingsInvoiceSettings, ?transferData: Choice<PostSubscriptionSchedulesScheduleDefaultSettingsTransferDataTransferDataSpecs,string>) =
        ///Can be set to `phase_start` to set the anchor to the start of the phase or `automatic` to automatically change it if needed. Cannot be set to `phase_start` if this phase specifies a trial. For more information, see the billing cycle [documentation](https://stripe.com/docs/billing/subscriptions/billing-cycle).
        member _.BillingCycleAnchor = billingCycleAnchor
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
        member _.BillingThresholds = billingThresholds
        ///Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay the underlying subscription at the end of each billing cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions. Defaults to `charge_automatically` on creation.
        member _.CollectionMethod = collectionMethod
        ///ID of the default payment method for the subscription schedule. It must belong to the customer associated with the subscription schedule. If not set, invoices will use the default payment method in the customer's invoice settings.
        member _.DefaultPaymentMethod = defaultPaymentMethod
        ///All invoices will be billed using the specified settings.
        member _.InvoiceSettings = invoiceSettings
        ///The data with which to automatically create a Transfer for each of the associated subscription's invoices.
        member _.TransferData = transferData

    and PostSubscriptionSchedulesScheduleDefaultSettingsBillingCycleAnchor =
        | Automatic
        | PhaseStart

    and PostSubscriptionSchedulesScheduleDefaultSettingsCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    and PostSubscriptionSchedulesScheduleDefaultSettingsBillingThresholdsBillingThresholds (?amountGte: int, ?resetBillingCycleAnchor: bool) =
        ///Monetary threshold that triggers the subscription to advance to a new billing period
        member _.AmountGte = amountGte
        ///Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.
        member _.ResetBillingCycleAnchor = resetBillingCycleAnchor

    and PostSubscriptionSchedulesScheduleDefaultSettingsInvoiceSettings (?daysUntilDue: int) =
        ///Number of days within which a customer must pay invoices generated by this subscription schedule. This value will be `null` for subscription schedules where `billing=charge_automatically`.
        member _.DaysUntilDue = daysUntilDue

    and PostSubscriptionSchedulesScheduleDefaultSettingsTransferDataTransferDataSpecs (?amountPercent: decimal, ?destination: string) =
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice subtotal that will be transferred to the destination account. By default, the entire amount is transferred to the destination.
        member _.AmountPercent = amountPercent
        ///ID of an existing, connected Stripe account.
        member _.Destination = destination

    and PostSubscriptionSchedulesSchedulePhases (?addInvoiceItems: PostSubscriptionSchedulesSchedulePhasesAddInvoiceItems list, ?transferData: PostSubscriptionSchedulesSchedulePhasesTransferData, ?startDate: Choice<int,PostSubscriptionSchedulesSchedulePhasesStartDate>, ?prorationBehavior: PostSubscriptionSchedulesSchedulePhasesProrationBehavior, ?iterations: int, ?items: PostSubscriptionSchedulesSchedulePhasesItems list, ?invoiceSettings: PostSubscriptionSchedulesSchedulePhasesInvoiceSettings, ?trial: bool, ?endDate: Choice<int,PostSubscriptionSchedulesSchedulePhasesEndDate>, ?defaultPaymentMethod: string, ?coupon: string, ?collectionMethod: PostSubscriptionSchedulesSchedulePhasesCollectionMethod, ?billingThresholds: Choice<PostSubscriptionSchedulesSchedulePhasesBillingThresholdsBillingThresholds,string>, ?billingCycleAnchor: PostSubscriptionSchedulesSchedulePhasesBillingCycleAnchor, ?applicationFeePercent: decimal, ?defaultTaxRates: Choice<string list,string>, ?trialEnd: Choice<int,PostSubscriptionSchedulesSchedulePhasesTrialEnd>) =
        ///A list of prices and quantities that will generate invoice items appended to the next invoice. You may pass up to 10 items.
        member _.AddInvoiceItems = addInvoiceItems
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice subtotal that will be transferred to the application owner's Stripe account. The request must be made by a platform account on a connected account in order to set an application fee percentage. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).
        member _.ApplicationFeePercent = applicationFeePercent
        ///Can be set to `phase_start` to set the anchor to the start of the phase or `automatic` to automatically change it if needed. Cannot be set to `phase_start` if this phase specifies a trial. For more information, see the billing cycle [documentation](https://stripe.com/docs/billing/subscriptions/billing-cycle).
        member _.BillingCycleAnchor = billingCycleAnchor
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
        member _.BillingThresholds = billingThresholds
        ///Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay the underlying subscription at the end of each billing cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions. Defaults to `charge_automatically` on creation.
        member _.CollectionMethod = collectionMethod
        ///The identifier of the coupon to apply to this phase of the subscription schedule.
        member _.Coupon = coupon
        ///ID of the default payment method for the subscription schedule. It must belong to the customer associated with the subscription schedule. If not set, invoices will use the default payment method in the customer's invoice settings.
        member _.DefaultPaymentMethod = defaultPaymentMethod
        ///A list of [Tax Rate](https://stripe.com/docs/api/tax_rates) ids. These Tax Rates will set the Subscription's [`default_tax_rates`](https://stripe.com/docs/api/subscriptions/create#create_subscription-default_tax_rates), which means they will be the Invoice's [`default_tax_rates`](https://stripe.com/docs/api/invoices/create#create_invoice-default_tax_rates) for any Invoices issued by the Subscription during this Phase.
        member _.DefaultTaxRates = defaultTaxRates
        ///The date at which this phase of the subscription schedule ends. If set, `iterations` must not be set.
        member _.EndDate = endDate
        ///All invoices will be billed using the specified settings.
        member _.InvoiceSettings = invoiceSettings
        ///List of configuration items, each with an attached price, to apply during this phase of the subscription schedule.
        member _.Items = items
        ///Integer representing the multiplier applied to the price interval. For example, `iterations=2` applied to a price with `interval=month` and `interval_count=3` results in a phase of duration `2 * 3 months = 6 months`. If set, `end_date` must not be set.
        member _.Iterations = iterations
        ///If a subscription schedule will create prorations when transitioning to this phase. Possible values are `create_prorations` or `none`, and the default value is `create_prorations`. See [Prorations](https://stripe.com/docs/billing/subscriptions/prorations).
        member _.ProrationBehavior = prorationBehavior
        ///The date at which this phase of the subscription schedule starts or `now`. Must be set on the first phase.
        member _.StartDate = startDate
        ///The data with which to automatically create a Transfer for each of the associated subscription's invoices.
        member _.TransferData = transferData
        ///If set to true the entire phase is counted as a trial and the customer will not be charged for any fees.
        member _.Trial = trial
        ///Sets the phase to trialing from the start date to this date. Must be before the phase end date, can not be combined with `trial`
        member _.TrialEnd = trialEnd

    and PostSubscriptionSchedulesSchedulePhasesBillingCycleAnchor =
        | Automatic
        | PhaseStart

    and PostSubscriptionSchedulesSchedulePhasesCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    and PostSubscriptionSchedulesSchedulePhasesProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | None'

    and PostSubscriptionSchedulesSchedulePhasesAddInvoiceItems (?price: string, ?priceData: PostSubscriptionSchedulesSchedulePhasesAddInvoiceItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
        ///The ID of the price object.
        member _.Price = price
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline.
        member _.PriceData = priceData
        ///Quantity for this item. Defaults to 1.
        member _.Quantity = quantity
        ///The tax rates which apply to the item. When set, the `default_tax_rates` do not apply to this item.
        member _.TaxRates = taxRates

    and PostSubscriptionSchedulesSchedulePhasesAddInvoiceItemsPriceData (?currency: string, ?product: string, ?unitAmount: int, ?unitAmountDecimal: string) =
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///The ID of the product that this price will belong to.
        member _.Product = product
        ///A positive integer in %s (or 0 for a free price) representing how much to charge.
        member _.UnitAmount = unitAmount
        ///Same as `unit_amount`, but accepts a decimal value in %s with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        member _.UnitAmountDecimal = unitAmountDecimal

    and PostSubscriptionSchedulesSchedulePhasesBillingThresholdsBillingThresholds (?amountGte: int, ?resetBillingCycleAnchor: bool) =
        ///Monetary threshold that triggers the subscription to advance to a new billing period
        member _.AmountGte = amountGte
        ///Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.
        member _.ResetBillingCycleAnchor = resetBillingCycleAnchor

    and PostSubscriptionSchedulesSchedulePhasesEndDate =
        | Now

    and PostSubscriptionSchedulesSchedulePhasesInvoiceSettings (?daysUntilDue: int) =
        ///Number of days within which a customer must pay invoices generated by this subscription schedule. This value will be `null` for subscription schedules where `billing=charge_automatically`.
        member _.DaysUntilDue = daysUntilDue

    and PostSubscriptionSchedulesSchedulePhasesItems (?billingThresholds: Choice<PostSubscriptionSchedulesSchedulePhasesItemsBillingThresholdsItemBillingThresholds,string>, ?plan: string, ?price: string, ?priceData: PostSubscriptionSchedulesSchedulePhasesItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. When updating, pass an empty string to remove previously-defined thresholds.
        member _.BillingThresholds = billingThresholds
        ///The plan ID to subscribe to. You may specify the same ID in `plan` and `price`.
        member _.Plan = plan
        ///The ID of the price object.
        member _.Price = price
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline.
        member _.PriceData = priceData
        ///Quantity for the given price. Can be set only if the price's `usage_type` is `licensed` and not `metered`.
        member _.Quantity = quantity
        ///A list of [Tax Rate](https://stripe.com/docs/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://stripe.com/docs/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.
        member _.TaxRates = taxRates

    and PostSubscriptionSchedulesSchedulePhasesItemsBillingThresholdsItemBillingThresholds (?usageGte: int) =
        ///Usage threshold that triggers the subscription to advance to a new billing period
        member _.UsageGte = usageGte

    and PostSubscriptionSchedulesSchedulePhasesItemsPriceData (?currency: string, ?product: string, ?recurring: PostSubscriptionSchedulesSchedulePhasesItemsPriceDataRecurring, ?unitAmount: int, ?unitAmountDecimal: string) =
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///The ID of the product that this price will belong to.
        member _.Product = product
        ///The recurring components of a price such as `interval` and `usage_type`.
        member _.Recurring = recurring
        ///A positive integer in %s (or 0 for a free price) representing how much to charge.
        member _.UnitAmount = unitAmount
        ///Same as `unit_amount`, but accepts a decimal value in %s with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        member _.UnitAmountDecimal = unitAmountDecimal

    and PostSubscriptionSchedulesSchedulePhasesItemsPriceDataRecurring (?interval: PostSubscriptionSchedulesSchedulePhasesItemsPriceDataRecurringInterval, ?intervalCount: int) =
        ///Specifies billing frequency. Either `day`, `week`, `month` or `year`.
        member _.Interval = interval
        ///The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        member _.IntervalCount = intervalCount

    and PostSubscriptionSchedulesSchedulePhasesItemsPriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    and PostSubscriptionSchedulesSchedulePhasesStartDate =
        | Now

    and PostSubscriptionSchedulesSchedulePhasesTransferData (?amountPercent: decimal, ?destination: string) =
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice subtotal that will be transferred to the destination account. By default, the entire amount is transferred to the destination.
        member _.AmountPercent = amountPercent
        ///ID of an existing, connected Stripe account.
        member _.Destination = destination

    and PostSubscriptionSchedulesSchedulePhasesTrialEnd =
        | Now

    and PostSubscriptionSchedulesScheduleCancelParams (?expand: string list, ?invoiceNow: bool, ?prorate: bool) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///If the subscription schedule is `active`, indicates if a final invoice will be generated that contains any un-invoiced metered usage and new/pending proration invoice items. Defaults to `true`.
        member _.InvoiceNow = invoiceNow
        ///If the subscription schedule is `active`, indicates if the cancellation should be prorated. Defaults to `true`.
        member _.Prorate = prorate

    and PostSubscriptionSchedulesScheduleReleaseParams (?expand: string list, ?preserveCancelDate: bool) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Keep any cancellation on the subscription that the schedule has set
        member _.PreserveCancelDate = preserveCancelDate

    and PostSubscriptionsParams (customer: string, ?addInvoiceItems: PostSubscriptionsAddInvoiceItems list, ?trialEnd: Choice<PostSubscriptionsTrialEnd,DateTime>, ?transferData: PostSubscriptionsTransferData, ?prorationBehavior: PostSubscriptionsProrationBehavior, ?promotionCode: string, ?pendingInvoiceItemInterval: Choice<PostSubscriptionsPendingInvoiceItemIntervalPendingInvoiceItemIntervalParams,string>, ?paymentBehavior: PostSubscriptionsPaymentBehavior, ?offSession: bool, ?metadata: Map<string, string>, ?items: PostSubscriptionsItems list, ?expand: string list, ?defaultTaxRates: Choice<string list,string>, ?defaultSource: string, ?defaultPaymentMethod: string, ?daysUntilDue: int, ?coupon: string, ?collectionMethod: PostSubscriptionsCollectionMethod, ?cancelAtPeriodEnd: bool, ?cancelAt: DateTime, ?billingThresholds: Choice<PostSubscriptionsBillingThresholdsBillingThresholds,string>, ?billingCycleAnchor: DateTime, ?backdateStartDate: DateTime, ?applicationFeePercent: decimal, ?trialFromPlan: bool, ?trialPeriodDays: int) =
        ///A list of prices and quantities that will generate invoice items appended to the first invoice for this subscription. You may pass up to 10 items.
        member _.AddInvoiceItems = addInvoiceItems
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice subtotal that will be transferred to the application owner's Stripe account. The request must be made by a platform account on a connected account in order to set an application fee percentage. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).
        member _.ApplicationFeePercent = applicationFeePercent
        ///For new subscriptions, a past timestamp to backdate the subscription's start date to. If set, the first invoice will contain a proration for the timespan between the start date and the current time. Can be combined with trials and the billing cycle anchor.
        member _.BackdateStartDate = backdateStartDate
        ///A future timestamp to anchor the subscription's [billing cycle](https://stripe.com/docs/subscriptions/billing-cycle). This is used to determine the date of the first full invoice, and, for plans with `month` or `year` intervals, the day of the month for subsequent invoices.
        member _.BillingCycleAnchor = billingCycleAnchor
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
        member _.BillingThresholds = billingThresholds
        ///A timestamp at which the subscription should cancel. If set to a date before the current period ends, this will cause a proration if prorations have been enabled using `proration_behavior`. If set during a future period, this will always cause a proration for that period.
        member _.CancelAt = cancelAt
        ///Boolean indicating whether this subscription should cancel at the end of the current period.
        member _.CancelAtPeriodEnd = cancelAtPeriodEnd
        ///Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay this subscription at the end of the cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions. Defaults to `charge_automatically`.
        member _.CollectionMethod = collectionMethod
        ///The code of the coupon to apply to this subscription. A coupon applied to a subscription will only affect invoices created for that particular subscription.
        member _.Coupon = coupon
        ///The identifier of the customer to subscribe.
        member _.Customer = customer
        ///Number of days a customer has to pay invoices generated by this subscription. Valid only for subscriptions where `collection_method` is set to `send_invoice`.
        member _.DaysUntilDue = daysUntilDue
        ///ID of the default payment method for the subscription. It must belong to the customer associated with the subscription. This takes precedence over `default_source`. If neither are set, invoices will use the customer's [invoice_settings.default_payment_method](https://stripe.com/docs/api/customers/object#customer_object-invoice_settings-default_payment_method) or [default_source](https://stripe.com/docs/api/customers/object#customer_object-default_source).
        member _.DefaultPaymentMethod = defaultPaymentMethod
        ///ID of the default payment source for the subscription. It must belong to the customer associated with the subscription and be in a chargeable state. If `default_payment_method` is also set, `default_payment_method` will take precedence. If neither are set, invoices will use the customer's [invoice_settings.default_payment_method](https://stripe.com/docs/api/customers/object#customer_object-invoice_settings-default_payment_method) or [default_source](https://stripe.com/docs/api/customers/object#customer_object-default_source).
        member _.DefaultSource = defaultSource
        ///The tax rates that will apply to any subscription item that does not have `tax_rates` set. Invoices created will have their `default_tax_rates` populated from the subscription.
        member _.DefaultTaxRates = defaultTaxRates
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///A list of up to 20 subscription items, each with an attached price.
        member _.Items = items
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Indicates if a customer is on or off-session while an invoice payment is attempted.
        member _.OffSession = offSession
        ///Use `allow_incomplete` to create subscriptions with `status=incomplete` if the first invoice cannot be paid. Creating subscriptions with this status allows you to manage scenarios where additional user actions are needed to pay a subscription's invoice. For example, SCA regulation may require 3DS authentication to complete payment. See the [SCA Migration Guide](https://stripe.com/docs/billing/migration/strong-customer-authentication) for Billing to learn more. This is the default behavior.
        ///Use `error_if_incomplete` if you want Stripe to return an HTTP 402 status code if a subscription's first invoice cannot be paid. For example, if a payment method requires 3DS authentication due to SCA regulation and further user action is needed, this parameter does not create a subscription and returns an error instead. This was the default behavior for API versions prior to 2019-03-14. See the [changelog](https://stripe.com/docs/upgrades#2019-03-14) to learn more.
        ///`pending_if_incomplete` is only used with updates and cannot be passed when creating a subscription.
        member _.PaymentBehavior = paymentBehavior
        ///Specifies an interval for how often to bill for any pending invoice items. It is analogous to calling [Create an invoice](https://stripe.com/docs/api#create_invoice) for the given subscription at the specified interval.
        member _.PendingInvoiceItemInterval = pendingInvoiceItemInterval
        ///The API ID of a promotion code to apply to this subscription. A promotion code applied to a subscription will only affect invoices created for that particular subscription.
        member _.PromotionCode = promotionCode
        ///Determines how to handle [prorations](https://stripe.com/docs/subscriptions/billing-cycle#prorations) resulting from the `billing_cycle_anchor`. Valid values are `create_prorations` or `none`.
        ///Passing `create_prorations` will cause proration invoice items to be created when applicable. Prorations can be disabled by passing `none`. If no value is passed, the default is `create_prorations`.
        member _.ProrationBehavior = prorationBehavior
        ///If specified, the funds from the subscription's invoices will be transferred to the destination and the ID of the resulting transfers will be found on the resulting charges.
        member _.TransferData = transferData
        ///Unix timestamp representing the end of the trial period the customer will get before being charged for the first time. This will always overwrite any trials that might apply via a subscribed plan. If set, trial_end will override the default trial period of the plan the customer is being subscribed to. The special value `now` can be provided to end the customer's trial immediately. Can be at most two years from `billing_cycle_anchor`.
        member _.TrialEnd = trialEnd
        ///Indicates if a plan's `trial_period_days` should be applied to the subscription. Setting `trial_end` per subscription is preferred, and this defaults to `false`. Setting this flag to `true` together with `trial_end` is not allowed.
        member _.TrialFromPlan = trialFromPlan
        ///Integer representing the number of trial period days before the customer is charged for the first time. This will always overwrite any trials that might apply via a subscribed plan.
        member _.TrialPeriodDays = trialPeriodDays

    and PostSubscriptionsCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    and PostSubscriptionsPaymentBehavior =
        | AllowIncomplete
        | ErrorIfIncomplete
        | PendingIfIncomplete

    and PostSubscriptionsProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | None'

    and PostSubscriptionsAddInvoiceItems (?price: string, ?priceData: PostSubscriptionsAddInvoiceItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
        ///The ID of the price object.
        member _.Price = price
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline.
        member _.PriceData = priceData
        ///Quantity for this item. Defaults to 1.
        member _.Quantity = quantity
        ///The tax rates which apply to the item. When set, the `default_tax_rates` do not apply to this item.
        member _.TaxRates = taxRates

    and PostSubscriptionsAddInvoiceItemsPriceData (?currency: string, ?product: string, ?unitAmount: int, ?unitAmountDecimal: string) =
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///The ID of the product that this price will belong to.
        member _.Product = product
        ///A positive integer in %s (or 0 for a free price) representing how much to charge.
        member _.UnitAmount = unitAmount
        ///Same as `unit_amount`, but accepts a decimal value in %s with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        member _.UnitAmountDecimal = unitAmountDecimal

    and PostSubscriptionsBillingThresholdsBillingThresholds (?amountGte: int, ?resetBillingCycleAnchor: bool) =
        ///Monetary threshold that triggers the subscription to advance to a new billing period
        member _.AmountGte = amountGte
        ///Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.
        member _.ResetBillingCycleAnchor = resetBillingCycleAnchor

    and PostSubscriptionsItems (?billingThresholds: Choice<PostSubscriptionsItemsBillingThresholdsItemBillingThresholds,string>, ?metadata: Map<string, string>, ?plan: string, ?price: string, ?priceData: PostSubscriptionsItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. When updating, pass an empty string to remove previously-defined thresholds.
        member _.BillingThresholds = billingThresholds
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Plan ID for this item, as a string.
        member _.Plan = plan
        ///The ID of the price object.
        member _.Price = price
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline.
        member _.PriceData = priceData
        ///Quantity for this item.
        member _.Quantity = quantity
        ///A list of [Tax Rate](https://stripe.com/docs/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://stripe.com/docs/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.
        member _.TaxRates = taxRates

    and PostSubscriptionsItemsBillingThresholdsItemBillingThresholds (?usageGte: int) =
        ///Usage threshold that triggers the subscription to advance to a new billing period
        member _.UsageGte = usageGte

    and PostSubscriptionsItemsPriceData (?currency: string, ?product: string, ?recurring: PostSubscriptionsItemsPriceDataRecurring, ?unitAmount: int, ?unitAmountDecimal: string) =
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///The ID of the product that this price will belong to.
        member _.Product = product
        ///The recurring components of a price such as `interval` and `usage_type`.
        member _.Recurring = recurring
        ///A positive integer in %s (or 0 for a free price) representing how much to charge.
        member _.UnitAmount = unitAmount
        ///Same as `unit_amount`, but accepts a decimal value in %s with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        member _.UnitAmountDecimal = unitAmountDecimal

    and PostSubscriptionsItemsPriceDataRecurring (?interval: PostSubscriptionsItemsPriceDataRecurringInterval, ?intervalCount: int) =
        ///Specifies billing frequency. Either `day`, `week`, `month` or `year`.
        member _.Interval = interval
        ///The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        member _.IntervalCount = intervalCount

    and PostSubscriptionsItemsPriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    and PostSubscriptionsPendingInvoiceItemIntervalPendingInvoiceItemIntervalParams (?interval: PostSubscriptionsPendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval, ?intervalCount: int) =
        ///Specifies invoicing frequency. Either `day`, `week`, `month` or `year`.
        member _.Interval = interval
        ///The number of intervals between invoices. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        member _.IntervalCount = intervalCount

    and PostSubscriptionsPendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval =
        | Day
        | Month
        | Week
        | Year

    and PostSubscriptionsTransferData (?amountPercent: decimal, ?destination: string) =
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice subtotal that will be transferred to the destination account. By default, the entire amount is transferred to the destination.
        member _.AmountPercent = amountPercent
        ///ID of an existing, connected Stripe account.
        member _.Destination = destination

    and PostSubscriptionsTrialEnd =
        | Now

    and DeleteSubscriptionsSubscriptionExposedIdParams (?expand: string list, ?invoiceNow: bool, ?prorate: bool) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Will generate a final invoice that invoices for any un-invoiced metered usage and new/pending proration invoice items.
        member _.InvoiceNow = invoiceNow
        ///Will generate a proration invoice item that credits remaining unused time until the subscription period end.
        member _.Prorate = prorate

    and PostSubscriptionsSubscriptionExposedIdParams (?addInvoiceItems: PostSubscriptionsSubscriptionExposedIdAddInvoiceItems list, ?transferData: Choice<PostSubscriptionsSubscriptionExposedIdTransferDataTransferDataSpecs,string>, ?prorationDate: DateTime, ?prorationBehavior: PostSubscriptionsSubscriptionExposedIdProrationBehavior, ?promotionCode: string, ?pendingInvoiceItemInterval: Choice<PostSubscriptionsSubscriptionExposedIdPendingInvoiceItemIntervalPendingInvoiceItemIntervalParams,string>, ?paymentBehavior: PostSubscriptionsSubscriptionExposedIdPaymentBehavior, ?pauseCollection: Choice<PostSubscriptionsSubscriptionExposedIdPauseCollectionPauseCollection,string>, ?offSession: bool, ?metadata: Map<string, string>, ?items: PostSubscriptionsSubscriptionExposedIdItems list, ?trialEnd: Choice<PostSubscriptionsSubscriptionExposedIdTrialEnd,DateTime>, ?expand: string list, ?defaultSource: string, ?defaultPaymentMethod: string, ?daysUntilDue: int, ?coupon: string, ?collectionMethod: PostSubscriptionsSubscriptionExposedIdCollectionMethod, ?cancelAtPeriodEnd: bool, ?cancelAt: Choice<DateTime,string>, ?billingThresholds: Choice<PostSubscriptionsSubscriptionExposedIdBillingThresholdsBillingThresholds,string>, ?billingCycleAnchor: PostSubscriptionsSubscriptionExposedIdBillingCycleAnchor, ?applicationFeePercent: decimal, ?defaultTaxRates: Choice<string list,string>, ?trialFromPlan: bool) =
        ///A list of prices and quantities that will generate invoice items appended to the first invoice for this subscription. You may pass up to 10 items.
        member _.AddInvoiceItems = addInvoiceItems
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice subtotal that will be transferred to the application owner's Stripe account. The request must be made by a platform account on a connected account in order to set an application fee percentage. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).
        member _.ApplicationFeePercent = applicationFeePercent
        ///Either `now` or `unchanged`. Setting the value to `now` resets the subscription's billing cycle anchor to the current time. For more information, see the billing cycle [documentation](https://stripe.com/docs/billing/subscriptions/billing-cycle).
        member _.BillingCycleAnchor = billingCycleAnchor
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
        member _.BillingThresholds = billingThresholds
        ///A timestamp at which the subscription should cancel. If set to a date before the current period ends, this will cause a proration if prorations have been enabled using `proration_behavior`. If set during a future period, this will always cause a proration for that period.
        member _.CancelAt = cancelAt
        ///Boolean indicating whether this subscription should cancel at the end of the current period.
        member _.CancelAtPeriodEnd = cancelAtPeriodEnd
        ///Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay this subscription at the end of the cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions. Defaults to `charge_automatically`.
        member _.CollectionMethod = collectionMethod
        ///The code of the coupon to apply to this subscription. A coupon applied to a subscription will only affect invoices created for that particular subscription.
        member _.Coupon = coupon
        ///Number of days a customer has to pay invoices generated by this subscription. Valid only for subscriptions where `collection_method` is set to `send_invoice`.
        member _.DaysUntilDue = daysUntilDue
        ///ID of the default payment method for the subscription. It must belong to the customer associated with the subscription. This takes precedence over `default_source`. If neither are set, invoices will use the customer's [invoice_settings.default_payment_method](https://stripe.com/docs/api/customers/object#customer_object-invoice_settings-default_payment_method) or [default_source](https://stripe.com/docs/api/customers/object#customer_object-default_source).
        member _.DefaultPaymentMethod = defaultPaymentMethod
        ///ID of the default payment source for the subscription. It must belong to the customer associated with the subscription and be in a chargeable state. If `default_payment_method` is also set, `default_payment_method` will take precedence. If neither are set, invoices will use the customer's [invoice_settings.default_payment_method](https://stripe.com/docs/api/customers/object#customer_object-invoice_settings-default_payment_method) or [default_source](https://stripe.com/docs/api/customers/object#customer_object-default_source).
        member _.DefaultSource = defaultSource
        ///The tax rates that will apply to any subscription item that does not have `tax_rates` set. Invoices created will have their `default_tax_rates` populated from the subscription. Pass an empty string to remove previously-defined tax rates.
        member _.DefaultTaxRates = defaultTaxRates
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///A list of up to 20 subscription items, each with an attached price.
        member _.Items = items
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Indicates if a customer is on or off-session while an invoice payment is attempted.
        member _.OffSession = offSession
        ///If specified, payment collection for this subscription will be paused.
        member _.PauseCollection = pauseCollection
        ///Use `allow_incomplete` to transition the subscription to `status=past_due` if a payment is required but cannot be paid. This allows you to manage scenarios where additional user actions are needed to pay a subscription's invoice. For example, SCA regulation may require 3DS authentication to complete payment. See the [SCA Migration Guide](https://stripe.com/docs/billing/migration/strong-customer-authentication) for Billing to learn more. This is the default behavior.
        ///Use `pending_if_incomplete` to update the subscription using [pending updates](https://stripe.com/docs/billing/subscriptions/pending-updates). When you use `pending_if_incomplete` you can only pass the parameters [supported by pending updates](https://stripe.com/docs/billing/pending-updates-reference#supported-attributes).
        ///Use `error_if_incomplete` if you want Stripe to return an HTTP 402 status code if a subscription's invoice cannot be paid. For example, if a payment method requires 3DS authentication due to SCA regulation and further user action is needed, this parameter does not update the subscription and returns an error instead. This was the default behavior for API versions prior to 2019-03-14. See the [changelog](https://stripe.com/docs/upgrades#2019-03-14) to learn more.
        member _.PaymentBehavior = paymentBehavior
        ///Specifies an interval for how often to bill for any pending invoice items. It is analogous to calling [Create an invoice](https://stripe.com/docs/api#create_invoice) for the given subscription at the specified interval.
        member _.PendingInvoiceItemInterval = pendingInvoiceItemInterval
        ///The promotion code to apply to this subscription. A promotion code applied to a subscription will only affect invoices created for that particular subscription.
        member _.PromotionCode = promotionCode
        ///Determines how to handle [prorations](https://stripe.com/docs/subscriptions/billing-cycle#prorations) when the billing cycle changes (e.g., when switching plans, resetting `billing_cycle_anchor=now`, or starting a trial), or if an item's `quantity` changes. Valid values are `create_prorations`, `none`, or `always_invoice`.
        ///Passing `create_prorations` will cause proration invoice items to be created when applicable. These proration items will only be invoiced immediately under [certain conditions](https://stripe.com/docs/subscriptions/upgrading-downgrading#immediate-payment). In order to always invoice immediately for prorations, pass `always_invoice`.
        ///Prorations can be disabled by passing `none`.
        member _.ProrationBehavior = prorationBehavior
        ///If set, the proration will be calculated as though the subscription was updated at the given time. This can be used to apply exactly the same proration that was previewed with [upcoming invoice](https://stripe.com/docs/api#retrieve_customer_invoice) endpoint. It can also be used to implement custom proration logic, such as prorating by day instead of by second, by providing the time that you wish to use for proration calculations.
        member _.ProrationDate = prorationDate
        ///If specified, the funds from the subscription's invoices will be transferred to the destination and the ID of the resulting transfers will be found on the resulting charges. This will be unset if you POST an empty value.
        member _.TransferData = transferData
        ///Unix timestamp representing the end of the trial period the customer will get before being charged for the first time. This will always overwrite any trials that might apply via a subscribed plan. If set, trial_end will override the default trial period of the plan the customer is being subscribed to. The special value `now` can be provided to end the customer's trial immediately. Can be at most two years from `billing_cycle_anchor`.
        member _.TrialEnd = trialEnd
        ///Indicates if a plan's `trial_period_days` should be applied to the subscription. Setting `trial_end` per subscription is preferred, and this defaults to `false`. Setting this flag to `true` together with `trial_end` is not allowed.
        member _.TrialFromPlan = trialFromPlan

    and PostSubscriptionsSubscriptionExposedIdBillingCycleAnchor =
        | Now
        | Unchanged

    and PostSubscriptionsSubscriptionExposedIdCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    and PostSubscriptionsSubscriptionExposedIdPaymentBehavior =
        | AllowIncomplete
        | ErrorIfIncomplete
        | PendingIfIncomplete

    and PostSubscriptionsSubscriptionExposedIdProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | None'

    and PostSubscriptionsSubscriptionExposedIdAddInvoiceItems (?price: string, ?priceData: PostSubscriptionsSubscriptionExposedIdAddInvoiceItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
        ///The ID of the price object.
        member _.Price = price
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline.
        member _.PriceData = priceData
        ///Quantity for this item. Defaults to 1.
        member _.Quantity = quantity
        ///The tax rates which apply to the item. When set, the `default_tax_rates` do not apply to this item.
        member _.TaxRates = taxRates

    and PostSubscriptionsSubscriptionExposedIdAddInvoiceItemsPriceData (?currency: string, ?product: string, ?unitAmount: int, ?unitAmountDecimal: string) =
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///The ID of the product that this price will belong to.
        member _.Product = product
        ///A positive integer in %s (or 0 for a free price) representing how much to charge.
        member _.UnitAmount = unitAmount
        ///Same as `unit_amount`, but accepts a decimal value in %s with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        member _.UnitAmountDecimal = unitAmountDecimal

    and PostSubscriptionsSubscriptionExposedIdBillingThresholdsBillingThresholds (?amountGte: int, ?resetBillingCycleAnchor: bool) =
        ///Monetary threshold that triggers the subscription to advance to a new billing period
        member _.AmountGte = amountGte
        ///Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.
        member _.ResetBillingCycleAnchor = resetBillingCycleAnchor

    and PostSubscriptionsSubscriptionExposedIdItems (?billingThresholds: Choice<PostSubscriptionsSubscriptionExposedIdItemsBillingThresholdsItemBillingThresholds,string>, ?clearUsage: bool, ?deleted: bool, ?id: string, ?metadata: Map<string, string>, ?plan: string, ?price: string, ?priceData: PostSubscriptionsSubscriptionExposedIdItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. When updating, pass an empty string to remove previously-defined thresholds.
        member _.BillingThresholds = billingThresholds
        ///Delete all usage for a given subscription item. Allowed only when `deleted` is set to `true` and the current plan's `usage_type` is `metered`.
        member _.ClearUsage = clearUsage
        ///A flag that, if set to `true`, will delete the specified item.
        member _.Deleted = deleted
        ///Subscription item to update.
        member _.Id = id
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Plan ID for this item, as a string.
        member _.Plan = plan
        ///The ID of the price object.
        member _.Price = price
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline.
        member _.PriceData = priceData
        ///Quantity for this item.
        member _.Quantity = quantity
        ///A list of [Tax Rate](https://stripe.com/docs/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://stripe.com/docs/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.
        member _.TaxRates = taxRates

    and PostSubscriptionsSubscriptionExposedIdItemsBillingThresholdsItemBillingThresholds (?usageGte: int) =
        ///Usage threshold that triggers the subscription to advance to a new billing period
        member _.UsageGte = usageGte

    and PostSubscriptionsSubscriptionExposedIdItemsPriceData (?currency: string, ?product: string, ?recurring: PostSubscriptionsSubscriptionExposedIdItemsPriceDataRecurring, ?unitAmount: int, ?unitAmountDecimal: string) =
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///The ID of the product that this price will belong to.
        member _.Product = product
        ///The recurring components of a price such as `interval` and `usage_type`.
        member _.Recurring = recurring
        ///A positive integer in %s (or 0 for a free price) representing how much to charge.
        member _.UnitAmount = unitAmount
        ///Same as `unit_amount`, but accepts a decimal value in %s with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        member _.UnitAmountDecimal = unitAmountDecimal

    and PostSubscriptionsSubscriptionExposedIdItemsPriceDataRecurring (?interval: PostSubscriptionsSubscriptionExposedIdItemsPriceDataRecurringInterval, ?intervalCount: int) =
        ///Specifies billing frequency. Either `day`, `week`, `month` or `year`.
        member _.Interval = interval
        ///The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        member _.IntervalCount = intervalCount

    and PostSubscriptionsSubscriptionExposedIdItemsPriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    and PostSubscriptionsSubscriptionExposedIdPauseCollectionPauseCollection (?behavior: PostSubscriptionsSubscriptionExposedIdPauseCollectionPauseCollectionBehavior, ?resumesAt: DateTime) =
        ///The payment collection behavior for this subscription while paused. One of `keep_as_draft`, `mark_uncollectible`, or `void`.
        member _.Behavior = behavior
        ///The time after which the subscription will resume collecting payments.
        member _.ResumesAt = resumesAt

    and PostSubscriptionsSubscriptionExposedIdPauseCollectionPauseCollectionBehavior =
        | KeepAsDraft
        | MarkUncollectible
        | Void

    and PostSubscriptionsSubscriptionExposedIdPendingInvoiceItemIntervalPendingInvoiceItemIntervalParams (?interval: PostSubscriptionsSubscriptionExposedIdPendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval, ?intervalCount: int) =
        ///Specifies invoicing frequency. Either `day`, `week`, `month` or `year`.
        member _.Interval = interval
        ///The number of intervals between invoices. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        member _.IntervalCount = intervalCount

    and PostSubscriptionsSubscriptionExposedIdPendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval =
        | Day
        | Month
        | Week
        | Year

    and PostSubscriptionsSubscriptionExposedIdTransferDataTransferDataSpecs (?amountPercent: decimal, ?destination: string) =
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice subtotal that will be transferred to the destination account. By default, the entire amount is transferred to the destination.
        member _.AmountPercent = amountPercent
        ///ID of an existing, connected Stripe account.
        member _.Destination = destination

    and PostSubscriptionsSubscriptionExposedIdTrialEnd =
        | Now

    and PostTaxRatesParams (displayName: string, inclusive: bool, percentage: decimal, ?active: bool, ?description: string, ?expand: string list, ?jurisdiction: string, ?metadata: Map<string, string>) =
        ///Flag determining whether the tax rate is active or inactive (archived). Inactive tax rates cannot be used with new applications or Checkout Sessions, but will still work for subscriptions and invoices that already have it set.
        member _.Active = active
        ///An arbitrary string attached to the tax rate for your internal use only. It will not be visible to your customers.
        member _.Description = description
        ///The display name of the tax rate, which will be shown to users.
        member _.DisplayName = displayName
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///This specifies if the tax rate is inclusive or exclusive.
        member _.Inclusive = inclusive
        ///The jurisdiction for the tax rate. You can use this label field for tax reporting purposes. It also appears on your customer’s invoice.
        member _.Jurisdiction = jurisdiction
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///This represents the tax rate percent out of 100.
        member _.Percentage = percentage

    and PostTaxRatesTaxRateParams (?active: bool, ?description: string, ?displayName: string, ?expand: string list, ?jurisdiction: string, ?metadata: Map<string, string>) =
        ///Flag determining whether the tax rate is active or inactive (archived). Inactive tax rates cannot be used with new applications or Checkout Sessions, but will still work for subscriptions and invoices that already have it set.
        member _.Active = active
        ///An arbitrary string attached to the tax rate for your internal use only. It will not be visible to your customers.
        member _.Description = description
        ///The display name of the tax rate, which will be shown to users.
        member _.DisplayName = displayName
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///The jurisdiction for the tax rate. You can use this label field for tax reporting purposes. It also appears on your customer’s invoice.
        member _.Jurisdiction = jurisdiction
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostTerminalConnectionTokensParams (?expand: string list, ?location: string) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///The id of the location that this connection token is scoped to. If specified the connection token will only be usable with readers assigned to that location, otherwise the connection token will be usable with all readers.
        member _.Location = location

    and PostTerminalLocationsParams (address: PostTerminalLocationsAddress, displayName: string, ?expand: string list, ?metadata: Map<string, string>) =
        ///The full address of the location.
        member _.Address = address
        ///A name for the location.
        member _.DisplayName = displayName
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostTerminalLocationsAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostTerminalLocationsLocationParams (?address: PostTerminalLocationsLocationAddress, ?displayName: string, ?expand: string list, ?metadata: Map<string, string>) =
        ///The full address of the location.
        member _.Address = address
        ///A name for the location.
        member _.DisplayName = displayName
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostTerminalLocationsLocationAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostTerminalReadersParams (registrationCode: string, ?expand: string list, ?label: string, ?location: string, ?metadata: Map<string, string>) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Custom label given to the reader for easier identification. If no label is specified, the registration code will be used.
        member _.Label = label
        ///The location to assign the reader to. If no location is specified, the reader will be assigned to the account's default location.
        member _.Location = location
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///A code generated by the reader used for registering to an account.
        member _.RegistrationCode = registrationCode

    and PostTerminalReadersReaderParams (?expand: string list, ?label: string, ?metadata: Map<string, string>) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///The new label of the reader.
        member _.Label = label
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostTokensParams (?account: PostTokensAccount, ?bankAccount: PostTokensBankAccount, ?card: Choice<PostTokensCardCreditCardSpecs,string>, ?customer: string, ?cvcUpdate: PostTokensCvcUpdate, ?expand: string list, ?person: PostTokensPerson, ?pii: PostTokensPii) =
        ///Information for the account this token will represent.
        member _.Account = account
        ///The bank account this token will represent.
        member _.BankAccount = bankAccount
        ///
        member _.Card = card
        ///The customer (owned by the application's account) for which to create a token. This can be used only with an [OAuth access token](https://stripe.com/docs/connect/standard-accounts) or [Stripe-Account header](https://stripe.com/docs/connect/authentication). For more details, see [Cloning Saved Payment Methods](https://stripe.com/docs/connect/cloning-saved-payment-methods).
        member _.Customer = customer
        ///The updated CVC value this token will represent.
        member _.CvcUpdate = cvcUpdate
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Information for the person this token will represent.
        member _.Person = person
        ///The PII this token will represent.
        member _.Pii = pii

    and PostTokensAccount (?businessType: PostTokensAccountBusinessType, ?company: PostTokensAccountCompany, ?individual: PostTokensAccountIndividual, ?tosShownAndAccepted: bool) =
        ///The business type.
        member _.BusinessType = businessType
        ///Information about the company or business.
        member _.Company = company
        ///Information about the person represented by the account.
        member _.Individual = individual
        ///Whether the user described by the data in the token has been shown [the Stripe Connected Account Agreement](https://stripe.com/docs/connect/account-tokens#stripe-connected-account-agreement). When creating an account token to create a new Connect account, this value must be `true`.
        member _.TosShownAndAccepted = tosShownAndAccepted

    and PostTokensAccountBusinessType =
        | Company
        | GovernmentEntity
        | Individual
        | NonProfit

    and PostTokensAccountCompany (?address: PostTokensAccountCompanyAddress, ?addressKana: PostTokensAccountCompanyAddressKana, ?addressKanji: PostTokensAccountCompanyAddressKanji, ?directorsProvided: bool, ?executivesProvided: bool, ?name: string, ?nameKana: string, ?nameKanji: string, ?ownersProvided: bool, ?phone: string, ?registrationNumber: string, ?structure: PostTokensAccountCompanyStructure, ?taxId: string, ?taxIdRegistrar: string, ?vatId: string, ?verification: PostTokensAccountCompanyVerification) =
        ///The company's primary address.
        member _.Address = address
        ///The Kana variation of the company's primary address (Japan only).
        member _.AddressKana = addressKana
        ///The Kanji variation of the company's primary address (Japan only).
        member _.AddressKanji = addressKanji
        ///Whether the company's directors have been provided. Set this Boolean to `true` after creating all the company's directors with [the Persons API](https://stripe.com/docs/api/persons) for accounts with a `relationship.director` requirement. This value is not automatically set to `true` after creating directors, so it needs to be updated to indicate all directors have been provided.
        member _.DirectorsProvided = directorsProvided
        ///Whether the company's executives have been provided. Set this Boolean to `true` after creating all the company's executives with [the Persons API](https://stripe.com/docs/api/persons) for accounts with a `relationship.executive` requirement.
        member _.ExecutivesProvided = executivesProvided
        ///The company's legal name.
        member _.Name = name
        ///The Kana variation of the company's legal name (Japan only).
        member _.NameKana = nameKana
        ///The Kanji variation of the company's legal name (Japan only).
        member _.NameKanji = nameKanji
        ///Whether the company's owners have been provided. Set this Boolean to `true` after creating all the company's owners with [the Persons API](https://stripe.com/docs/api/persons) for accounts with a `relationship.owner` requirement.
        member _.OwnersProvided = ownersProvided
        ///The company's phone number (used for verification).
        member _.Phone = phone
        ///The identification number given to a company when it is registered or incorporated, if distinct from the identification number used for filing taxes. (Examples are the CIN for companies and LLP IN for partnerships in India, and the Company Registration Number in Hong Kong).
        member _.RegistrationNumber = registrationNumber
        ///The category identifying the legal structure of the company or legal entity. See [Business structure](https://stripe.com/docs/connect/identity-verification#business-structure) for more details.
        member _.Structure = structure
        ///The business ID number of the company, as appropriate for the company’s country. (Examples are an Employer ID Number in the U.S., a Business Number in Canada, or a Company Number in the UK.)
        member _.TaxId = taxId
        ///The jurisdiction in which the `tax_id` is registered (Germany-based companies only).
        member _.TaxIdRegistrar = taxIdRegistrar
        ///The VAT number of the company.
        member _.VatId = vatId
        ///Information on the verification state of the company.
        member _.Verification = verification

    and PostTokensAccountCompanyStructure =
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

    and PostTokensAccountCompanyAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostTokensAccountCompanyAddressKana (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
        ///City or ward.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Block or building number.
        member _.Line1 = line1
        ///Building details.
        member _.Line2 = line2
        ///Postal code.
        member _.PostalCode = postalCode
        ///Prefecture.
        member _.State = state
        ///Town or cho-me.
        member _.Town = town

    and PostTokensAccountCompanyAddressKanji (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
        ///City or ward.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Block or building number.
        member _.Line1 = line1
        ///Building details.
        member _.Line2 = line2
        ///Postal code.
        member _.PostalCode = postalCode
        ///Prefecture.
        member _.State = state
        ///Town or cho-me.
        member _.Town = town

    and PostTokensAccountCompanyVerification (?document: PostTokensAccountCompanyVerificationDocument) =
        ///A document verifying the business.
        member _.Document = document

    and PostTokensAccountCompanyVerificationDocument (?back: string, ?front: string) =
        ///The back of a document returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `additional_verification`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Back = back
        ///The front of a document returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `additional_verification`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Front = front

    and PostTokensAccountIndividual (?address: PostTokensAccountIndividualAddress, ?politicalExposure: PostTokensAccountIndividualPoliticalExposure, ?phone: string, ?metadata: Map<string, string>, ?maidenName: string, ?lastNameKanji: string, ?lastNameKana: string, ?lastName: string, ?ssnLast4: string, ?idNumber: string, ?firstNameKanji: string, ?firstNameKana: string, ?firstName: string, ?email: string, ?dob: Choice<PostTokensAccountIndividualDobDateOfBirthSpecs,string>, ?addressKanji: PostTokensAccountIndividualAddressKanji, ?addressKana: PostTokensAccountIndividualAddressKana, ?gender: string, ?verification: PostTokensAccountIndividualVerification) =
        ///The individual's primary address.
        member _.Address = address
        ///The Kana variation of the the individual's primary address (Japan only).
        member _.AddressKana = addressKana
        ///The Kanji variation of the the individual's primary address (Japan only).
        member _.AddressKanji = addressKanji
        ///The individual's date of birth.
        member _.Dob = dob
        ///The individual's email address.
        member _.Email = email
        ///The individual's first name.
        member _.FirstName = firstName
        ///The Kana variation of the the individual's first name (Japan only).
        member _.FirstNameKana = firstNameKana
        ///The Kanji variation of the individual's first name (Japan only).
        member _.FirstNameKanji = firstNameKanji
        ///The individual's gender (International regulations require either "male" or "female").
        member _.Gender = gender
        ///The government-issued ID number of the individual, as appropriate for the representative’s country. (Examples are a Social Security Number in the U.S., or a Social Insurance Number in Canada). Instead of the number itself, you can also provide a [PII token created with Stripe.js](https://stripe.com/docs/stripe.js#collecting-pii-data).
        member _.IdNumber = idNumber
        ///The individual's last name.
        member _.LastName = lastName
        ///The Kana varation of the individual's last name (Japan only).
        member _.LastNameKana = lastNameKana
        ///The Kanji varation of the individual's last name (Japan only).
        member _.LastNameKanji = lastNameKanji
        ///The individual's maiden name.
        member _.MaidenName = maidenName
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The individual's phone number.
        member _.Phone = phone
        ///Indicates if the person or any of their representatives, family members, or other closely related persons, declares that they hold or have held an important public job or function, in any jurisdiction.
        member _.PoliticalExposure = politicalExposure
        ///The last four digits of the individual's Social Security Number (U.S. only).
        member _.SsnLast4 = ssnLast4
        ///The individual's verification document information.
        member _.Verification = verification

    and PostTokensAccountIndividualPoliticalExposure =
        | Existing
        | None'

    and PostTokensAccountIndividualAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostTokensAccountIndividualAddressKana (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
        ///City or ward.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Block or building number.
        member _.Line1 = line1
        ///Building details.
        member _.Line2 = line2
        ///Postal code.
        member _.PostalCode = postalCode
        ///Prefecture.
        member _.State = state
        ///Town or cho-me.
        member _.Town = town

    and PostTokensAccountIndividualAddressKanji (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
        ///City or ward.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Block or building number.
        member _.Line1 = line1
        ///Building details.
        member _.Line2 = line2
        ///Postal code.
        member _.PostalCode = postalCode
        ///Prefecture.
        member _.State = state
        ///Town or cho-me.
        member _.Town = town

    and PostTokensAccountIndividualDobDateOfBirthSpecs (?day: int, ?month: int, ?year: int) =
        ///The day of birth, between 1 and 31.
        member _.Day = day
        ///The month of birth, between 1 and 12.
        member _.Month = month
        ///The four-digit year of birth.
        member _.Year = year

    and PostTokensAccountIndividualVerification (?additionalDocument: PostTokensAccountIndividualVerificationAdditionalDocument, ?document: PostTokensAccountIndividualVerificationDocument) =
        ///A document showing address, either a passport, local ID card, or utility bill from a well-known utility company.
        member _.AdditionalDocument = additionalDocument
        ///An identifying document, either a passport or local ID card.
        member _.Document = document

    and PostTokensAccountIndividualVerificationAdditionalDocument (?back: string, ?front: string) =
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Back = back
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Front = front

    and PostTokensAccountIndividualVerificationDocument (?back: string, ?front: string) =
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Back = back
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Front = front

    and PostTokensBankAccount (?accountHolderName: string, ?accountHolderType: PostTokensBankAccountAccountHolderType, ?accountNumber: string, ?country: string, ?currency: string, ?routingNumber: string) =
        ///The name of the person or business that owns the bank account.This field is required when attaching the bank account to a `Customer` object.
        member _.AccountHolderName = accountHolderName
        ///The type of entity that holds the account. It can be `company` or `individual`. This field is required when attaching the bank account to a `Customer` object.
        member _.AccountHolderType = accountHolderType
        ///The account number for the bank account, in string form. Must be a checking account.
        member _.AccountNumber = accountNumber
        ///The country in which the bank account is located.
        member _.Country = country
        ///The currency the bank account is in. This must be a country/currency pairing that [Stripe supports.](https://stripe.com/docs/payouts)
        member _.Currency = currency
        ///The routing number, sort code, or other country-appropriateinstitution number for the bank account. For US bank accounts, this is required and should bethe ACH routing number, not the wire routing number. If you are providing an IBAN for`account_number`, this field is not required.
        member _.RoutingNumber = routingNumber

    and PostTokensBankAccountAccountHolderType =
        | Company
        | Individual

    and PostTokensCardCreditCardSpecs (?addressCity: string, ?addressCountry: string, ?addressLine1: string, ?addressLine2: string, ?addressState: string, ?addressZip: string, ?currency: string, ?cvc: string, ?expMonth: string, ?expYear: string, ?name: string, ?number: string) =
        ///
        member _.AddressCity = addressCity
        ///
        member _.AddressCountry = addressCountry
        ///
        member _.AddressLine1 = addressLine1
        ///
        member _.AddressLine2 = addressLine2
        ///
        member _.AddressState = addressState
        ///
        member _.AddressZip = addressZip
        ///
        member _.Currency = currency
        ///
        member _.Cvc = cvc
        ///
        member _.ExpMonth = expMonth
        ///
        member _.ExpYear = expYear
        ///
        member _.Name = name
        ///
        member _.Number = number

    and PostTokensCvcUpdate (?cvc: string) =
        ///The CVC value, in string form.
        member _.Cvc = cvc

    and PostTokensPerson (?address: PostTokensPersonAddress, ?relationship: PostTokensPersonRelationship, ?politicalExposure: string, ?phone: string, ?metadata: Map<string, string>, ?maidenName: string, ?lastNameKanji: string, ?lastNameKana: string, ?lastName: string, ?idNumber: string, ?gender: string, ?firstNameKanji: string, ?firstNameKana: string, ?firstName: string, ?email: string, ?dob: Choice<PostTokensPersonDobDateOfBirthSpecs,string>, ?addressKanji: PostTokensPersonAddressKanji, ?addressKana: PostTokensPersonAddressKana, ?ssnLast4: string, ?verification: PostTokensPersonVerification) =
        ///The person's address.
        member _.Address = address
        ///The Kana variation of the person's address (Japan only).
        member _.AddressKana = addressKana
        ///The Kanji variation of the person's address (Japan only).
        member _.AddressKanji = addressKanji
        ///The person's date of birth.
        member _.Dob = dob
        ///The person's email address.
        member _.Email = email
        ///The person's first name.
        member _.FirstName = firstName
        ///The Kana variation of the person's first name (Japan only).
        member _.FirstNameKana = firstNameKana
        ///The Kanji variation of the person's first name (Japan only).
        member _.FirstNameKanji = firstNameKanji
        ///The person's gender (International regulations require either "male" or "female").
        member _.Gender = gender
        ///The person's ID number, as appropriate for their country. For example, a social security number in the U.S., social insurance number in Canada, etc. Instead of the number itself, you can also provide a [PII token provided by Stripe.js](https://stripe.com/docs/stripe.js#collecting-pii-data).
        member _.IdNumber = idNumber
        ///The person's last name.
        member _.LastName = lastName
        ///The Kana variation of the person's last name (Japan only).
        member _.LastNameKana = lastNameKana
        ///The Kanji variation of the person's last name (Japan only).
        member _.LastNameKanji = lastNameKanji
        ///The person's maiden name.
        member _.MaidenName = maidenName
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The person's phone number.
        member _.Phone = phone
        ///Indicates if the person or any of their representatives, family members, or other closely related persons, declares that they hold or have held an important public job or function, in any jurisdiction.
        member _.PoliticalExposure = politicalExposure
        ///The relationship that this person has with the account's legal entity.
        member _.Relationship = relationship
        ///The last four digits of the person's Social Security number (U.S. only).
        member _.SsnLast4 = ssnLast4
        ///The person's verification status.
        member _.Verification = verification

    and PostTokensPersonAddress (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
        ///City, district, suburb, town, or village.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Address line 1 (e.g., street, PO Box, or company name).
        member _.Line1 = line1
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        member _.Line2 = line2
        ///ZIP or postal code.
        member _.PostalCode = postalCode
        ///State, county, province, or region.
        member _.State = state

    and PostTokensPersonAddressKana (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
        ///City or ward.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Block or building number.
        member _.Line1 = line1
        ///Building details.
        member _.Line2 = line2
        ///Postal code.
        member _.PostalCode = postalCode
        ///Prefecture.
        member _.State = state
        ///Town or cho-me.
        member _.Town = town

    and PostTokensPersonAddressKanji (?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
        ///City or ward.
        member _.City = city
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        member _.Country = country
        ///Block or building number.
        member _.Line1 = line1
        ///Building details.
        member _.Line2 = line2
        ///Postal code.
        member _.PostalCode = postalCode
        ///Prefecture.
        member _.State = state
        ///Town or cho-me.
        member _.Town = town

    and PostTokensPersonDobDateOfBirthSpecs (?day: int, ?month: int, ?year: int) =
        ///The day of birth, between 1 and 31.
        member _.Day = day
        ///The month of birth, between 1 and 12.
        member _.Month = month
        ///The four-digit year of birth.
        member _.Year = year

    and PostTokensPersonRelationship (?director: bool, ?executive: bool, ?owner: bool, ?percentOwnership: Choice<decimal,string>, ?representative: bool, ?title: string) =
        ///Whether the person is a director of the account's legal entity. Currently only required for accounts in the EU. Directors are typically members of the governing board of the company, or responsible for ensuring the company meets its regulatory obligations.
        member _.Director = director
        ///Whether the person has significant responsibility to control, manage, or direct the organization.
        member _.Executive = executive
        ///Whether the person is an owner of the account’s legal entity.
        member _.Owner = owner
        ///The percent owned by the person of the account's legal entity.
        member _.PercentOwnership = percentOwnership
        ///Whether the person is authorized as the primary representative of the account. This is the person nominated by the business to provide information about themselves, and general information about the account. There can only be one representative at any given time. At the time the account is created, this person should be set to the person responsible for opening the account.
        member _.Representative = representative
        ///The person's title (e.g., CEO, Support Engineer).
        member _.Title = title

    and PostTokensPersonVerification (?additionalDocument: PostTokensPersonVerificationAdditionalDocument, ?document: PostTokensPersonVerificationDocument) =
        ///A document showing address, either a passport, local ID card, or utility bill from a well-known utility company.
        member _.AdditionalDocument = additionalDocument
        ///An identifying document, either a passport or local ID card.
        member _.Document = document

    and PostTokensPersonVerificationAdditionalDocument (?back: string, ?front: string) =
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Back = back
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Front = front

    and PostTokensPersonVerificationDocument (?back: string, ?front: string) =
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Back = back
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        member _.Front = front

    and PostTokensPii (?idNumber: string) =
        ///The `id_number` for the PII, in string form.
        member _.IdNumber = idNumber

    and PostTopupsParams (amount: int, currency: string, ?description: string, ?expand: string list, ?metadata: Map<string, string>, ?source: string, ?statementDescriptor: string, ?transferGroup: string) =
        ///A positive integer representing how much to transfer.
        member _.Amount = amount
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        member _.Currency = currency
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        member _.Description = description
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The ID of a source to transfer funds from. For most users, this should be left unspecified which will use the bank account that was set up in the dashboard for the specified currency. In test mode, this can be a test bank token (see [Testing Top-ups](https://stripe.com/docs/connect/testing#testing-top-ups)).
        member _.Source = source
        ///Extra information about a top-up for the source's bank statement. Limited to 15 ASCII characters.
        member _.StatementDescriptor = statementDescriptor
        ///A string that identifies this top-up as part of a group.
        member _.TransferGroup = transferGroup

    and PostTopupsTopupParams (?description: string, ?expand: string list, ?metadata: Map<string, string>) =
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        member _.Description = description
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostTopupsTopupCancelParams (?expand: string list) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand

    and PostTransfersParams (currency: string, destination: string, ?amount: int, ?description: string, ?expand: string list, ?metadata: Map<string, string>, ?sourceTransaction: string, ?sourceType: PostTransfersSourceType, ?transferGroup: string) =
        ///A positive integer in %s representing how much to transfer.
        member _.Amount = amount
        ///3-letter [ISO code for currency](https://stripe.com/docs/payouts).
        member _.Currency = currency
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        member _.Description = description
        ///The ID of a connected Stripe account. <a href="/docs/connect/charges-transfers">See the Connect documentation</a> for details.
        member _.Destination = destination
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///You can use this parameter to transfer funds from a charge before they are added to your available balance. A pending balance will transfer immediately but the funds will not become available until the original charge becomes available. [See the Connect documentation](https://stripe.com/docs/connect/charges-transfers#transfer-availability) for details.
        member _.SourceTransaction = sourceTransaction
        ///The source balance to use for this transfer. One of `bank_account`, `card`, or `fpx`. For most users, this will default to `card`.
        member _.SourceType = sourceType
        ///A string that identifies this transaction as part of a group. See the [Connect documentation](https://stripe.com/docs/connect/charges-transfers#transfer-options) for details.
        member _.TransferGroup = transferGroup

    and PostTransfersSourceType =
        | BankAccount
        | Card
        | Fpx

    and PostTransfersIdReversalsParams (?amount: int, ?description: string, ?expand: string list, ?metadata: Map<string, string>, ?refundApplicationFee: bool) =
        ///A positive integer in %s representing how much of this transfer to reverse. Can only reverse up to the unreversed amount remaining of the transfer. Partial transfer reversals are only allowed for transfers to Stripe Accounts. Defaults to the entire transfer amount.
        member _.Amount = amount
        ///An arbitrary string which you can attach to a reversal object. It is displayed alongside the reversal in the Dashboard. This will be unset if you POST an empty value.
        member _.Description = description
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///Boolean indicating whether the application fee should be refunded when reversing this transfer. If a full transfer reversal is given, the full application fee will be refunded. Otherwise, the application fee will be refunded with an amount proportional to the amount of the transfer reversed.
        member _.RefundApplicationFee = refundApplicationFee

    and PostTransfersTransferParams (?description: string, ?expand: string list, ?metadata: Map<string, string>) =
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        member _.Description = description
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostTransfersTransferReversalsIdParams (?expand: string list, ?metadata: Map<string, string>) =
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata

    and PostWebhookEndpointsParams (enabledEvents: PostWebhookEndpointsEnabledEvents list, url: string, ?apiVersion: PostWebhookEndpointsApiVersion, ?connect: bool, ?description: string, ?expand: string list, ?metadata: Map<string, string>) =
        ///Events sent to this endpoint will be generated with this Stripe Version instead of your account's default Stripe Version.
        member _.ApiVersion = apiVersion
        ///Whether this endpoint should receive events from connected accounts (`true`), or from your account (`false`). Defaults to `false`.
        member _.Connect = connect
        ///An optional description of what the webhook is used for.
        member _.Description = description
        ///The list of events to enable for this endpoint. You may specify `['*']` to enable all events, except those that require explicit selection.
        member _.EnabledEvents = enabledEvents
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The URL of the webhook endpoint.
        member _.Url = url

    and PostWebhookEndpointsApiVersion =
        | [<JsonUnionCase("2011-01-01")>] Numeric20110101
        | [<JsonUnionCase("2011-06-21")>] Numeric20110621
        | [<JsonUnionCase("2011-06-28")>] Numeric20110628
        | [<JsonUnionCase("2011-08-01")>] Numeric20110801
        | [<JsonUnionCase("2011-09-15")>] Numeric20110915
        | [<JsonUnionCase("2011-11-17")>] Numeric20111117
        | [<JsonUnionCase("2012-02-23")>] Numeric20120223
        | [<JsonUnionCase("2012-03-25")>] Numeric20120325
        | [<JsonUnionCase("2012-06-18")>] Numeric20120618
        | [<JsonUnionCase("2012-06-28")>] Numeric20120628
        | [<JsonUnionCase("2012-07-09")>] Numeric20120709
        | [<JsonUnionCase("2012-09-24")>] Numeric20120924
        | [<JsonUnionCase("2012-10-26")>] Numeric20121026
        | [<JsonUnionCase("2012-11-07")>] Numeric20121107
        | [<JsonUnionCase("2013-02-11")>] Numeric20130211
        | [<JsonUnionCase("2013-02-13")>] Numeric20130213
        | [<JsonUnionCase("2013-07-05")>] Numeric20130705
        | [<JsonUnionCase("2013-08-12")>] Numeric20130812
        | [<JsonUnionCase("2013-08-13")>] Numeric20130813
        | [<JsonUnionCase("2013-10-29")>] Numeric20131029
        | [<JsonUnionCase("2013-12-03")>] Numeric20131203
        | [<JsonUnionCase("2014-01-31")>] Numeric20140131
        | [<JsonUnionCase("2014-03-13")>] Numeric20140313
        | [<JsonUnionCase("2014-03-28")>] Numeric20140328
        | [<JsonUnionCase("2014-05-19")>] Numeric20140519
        | [<JsonUnionCase("2014-06-13")>] Numeric20140613
        | [<JsonUnionCase("2014-06-17")>] Numeric20140617
        | [<JsonUnionCase("2014-07-22")>] Numeric20140722
        | [<JsonUnionCase("2014-07-26")>] Numeric20140726
        | [<JsonUnionCase("2014-08-04")>] Numeric20140804
        | [<JsonUnionCase("2014-08-20")>] Numeric20140820
        | [<JsonUnionCase("2014-09-08")>] Numeric20140908
        | [<JsonUnionCase("2014-10-07")>] Numeric20141007
        | [<JsonUnionCase("2014-11-05")>] Numeric20141105
        | [<JsonUnionCase("2014-11-20")>] Numeric20141120
        | [<JsonUnionCase("2014-12-08")>] Numeric20141208
        | [<JsonUnionCase("2014-12-17")>] Numeric20141217
        | [<JsonUnionCase("2014-12-22")>] Numeric20141222
        | [<JsonUnionCase("2015-01-11")>] Numeric20150111
        | [<JsonUnionCase("2015-01-26")>] Numeric20150126
        | [<JsonUnionCase("2015-02-10")>] Numeric20150210
        | [<JsonUnionCase("2015-02-16")>] Numeric20150216
        | [<JsonUnionCase("2015-02-18")>] Numeric20150218
        | [<JsonUnionCase("2015-03-24")>] Numeric20150324
        | [<JsonUnionCase("2015-04-07")>] Numeric20150407
        | [<JsonUnionCase("2015-06-15")>] Numeric20150615
        | [<JsonUnionCase("2015-07-07")>] Numeric20150707
        | [<JsonUnionCase("2015-07-13")>] Numeric20150713
        | [<JsonUnionCase("2015-07-28")>] Numeric20150728
        | [<JsonUnionCase("2015-08-07")>] Numeric20150807
        | [<JsonUnionCase("2015-08-19")>] Numeric20150819
        | [<JsonUnionCase("2015-09-03")>] Numeric20150903
        | [<JsonUnionCase("2015-09-08")>] Numeric20150908
        | [<JsonUnionCase("2015-09-23")>] Numeric20150923
        | [<JsonUnionCase("2015-10-01")>] Numeric20151001
        | [<JsonUnionCase("2015-10-12")>] Numeric20151012
        | [<JsonUnionCase("2015-10-16")>] Numeric20151016
        | [<JsonUnionCase("2016-02-03")>] Numeric20160203
        | [<JsonUnionCase("2016-02-19")>] Numeric20160219
        | [<JsonUnionCase("2016-02-22")>] Numeric20160222
        | [<JsonUnionCase("2016-02-23")>] Numeric20160223
        | [<JsonUnionCase("2016-02-29")>] Numeric20160229
        | [<JsonUnionCase("2016-03-07")>] Numeric20160307
        | [<JsonUnionCase("2016-06-15")>] Numeric20160615
        | [<JsonUnionCase("2016-07-06")>] Numeric20160706
        | [<JsonUnionCase("2016-10-19")>] Numeric20161019
        | [<JsonUnionCase("2017-01-27")>] Numeric20170127
        | [<JsonUnionCase("2017-02-14")>] Numeric20170214
        | [<JsonUnionCase("2017-04-06")>] Numeric20170406
        | [<JsonUnionCase("2017-05-25")>] Numeric20170525
        | [<JsonUnionCase("2017-06-05")>] Numeric20170605
        | [<JsonUnionCase("2017-08-15")>] Numeric20170815
        | [<JsonUnionCase("2017-12-14")>] Numeric20171214
        | [<JsonUnionCase("2018-01-23")>] Numeric20180123
        | [<JsonUnionCase("2018-02-05")>] Numeric20180205
        | [<JsonUnionCase("2018-02-06")>] Numeric20180206
        | [<JsonUnionCase("2018-02-28")>] Numeric20180228
        | [<JsonUnionCase("2018-05-21")>] Numeric20180521
        | [<JsonUnionCase("2018-07-27")>] Numeric20180727
        | [<JsonUnionCase("2018-08-23")>] Numeric20180823
        | [<JsonUnionCase("2018-09-06")>] Numeric20180906
        | [<JsonUnionCase("2018-09-24")>] Numeric20180924
        | [<JsonUnionCase("2018-10-31")>] Numeric20181031
        | [<JsonUnionCase("2018-11-08")>] Numeric20181108
        | [<JsonUnionCase("2019-02-11")>] Numeric20190211
        | [<JsonUnionCase("2019-02-19")>] Numeric20190219
        | [<JsonUnionCase("2019-03-14")>] Numeric20190314
        | [<JsonUnionCase("2019-05-16")>] Numeric20190516
        | [<JsonUnionCase("2019-08-14")>] Numeric20190814
        | [<JsonUnionCase("2019-09-09")>] Numeric20190909
        | [<JsonUnionCase("2019-10-08")>] Numeric20191008
        | [<JsonUnionCase("2019-10-17")>] Numeric20191017
        | [<JsonUnionCase("2019-11-05")>] Numeric20191105
        | [<JsonUnionCase("2019-12-03")>] Numeric20191203
        | [<JsonUnionCase("2020-03-02")>] Numeric20200302
        | [<JsonUnionCase("2020-08-27")>] Numeric20200827

    and PostWebhookEndpointsEnabledEvents =
        | Asterix
        | AccountApplicationAuthorized
        | AccountApplicationDeauthorized
        | AccountExternalAccountCreated
        | AccountExternalAccountDeleted
        | AccountExternalAccountUpdated
        | AccountUpdated
        | ApplicationFeeCreated
        | ApplicationFeeRefundUpdated
        | ApplicationFeeRefunded
        | BalanceAvailable
        | CapabilityUpdated
        | ChargeCaptured
        | ChargeDisputeClosed
        | ChargeDisputeCreated
        | ChargeDisputeFundsReinstated
        | ChargeDisputeFundsWithdrawn
        | ChargeDisputeUpdated
        | ChargeExpired
        | ChargeFailed
        | ChargePending
        | ChargeRefundUpdated
        | ChargeRefunded
        | ChargeSucceeded
        | ChargeUpdated
        | CheckoutSessionAsyncPaymentFailed
        | CheckoutSessionAsyncPaymentSucceeded
        | CheckoutSessionCompleted
        | CouponCreated
        | CouponDeleted
        | CouponUpdated
        | CreditNoteCreated
        | CreditNoteUpdated
        | CreditNoteVoided
        | CustomerCreated
        | CustomerDeleted
        | CustomerDiscountCreated
        | CustomerDiscountDeleted
        | CustomerDiscountUpdated
        | CustomerSourceCreated
        | CustomerSourceDeleted
        | CustomerSourceExpiring
        | CustomerSourceUpdated
        | CustomerSubscriptionCreated
        | CustomerSubscriptionDeleted
        | CustomerSubscriptionPendingUpdateApplied
        | CustomerSubscriptionPendingUpdateExpired
        | CustomerSubscriptionTrialWillEnd
        | CustomerSubscriptionUpdated
        | CustomerTaxIdCreated
        | CustomerTaxIdDeleted
        | CustomerTaxIdUpdated
        | CustomerUpdated
        | FileCreated
        | InvoiceCreated
        | InvoiceDeleted
        | InvoiceFinalizationFailed
        | InvoiceFinalized
        | InvoiceMarkedUncollectible
        | InvoicePaid
        | InvoicePaymentActionRequired
        | InvoicePaymentFailed
        | InvoicePaymentSucceeded
        | InvoiceSent
        | InvoiceUpcoming
        | InvoiceUpdated
        | InvoiceVoided
        | InvoiceitemCreated
        | InvoiceitemDeleted
        | InvoiceitemUpdated
        | IssuingAuthorizationCreated
        | IssuingAuthorizationRequest
        | IssuingAuthorizationUpdated
        | IssuingCardCreated
        | IssuingCardUpdated
        | IssuingCardholderCreated
        | IssuingCardholderUpdated
        | IssuingDisputeClosed
        | IssuingDisputeCreated
        | IssuingDisputeFundsReinstated
        | IssuingDisputeSubmitted
        | IssuingDisputeUpdated
        | IssuingTransactionCreated
        | IssuingTransactionUpdated
        | MandateUpdated
        | OrderCreated
        | OrderPaymentFailed
        | OrderPaymentSucceeded
        | OrderUpdated
        | OrderReturnCreated
        | PaymentIntentAmountCapturableUpdated
        | PaymentIntentCanceled
        | PaymentIntentCreated
        | PaymentIntentPaymentFailed
        | PaymentIntentProcessing
        | PaymentIntentRequiresAction
        | PaymentIntentSucceeded
        | PaymentMethodAttached
        | PaymentMethodAutomaticallyUpdated
        | PaymentMethodDetached
        | PaymentMethodUpdated
        | PayoutCanceled
        | PayoutCreated
        | PayoutFailed
        | PayoutPaid
        | PayoutUpdated
        | PersonCreated
        | PersonDeleted
        | PersonUpdated
        | PlanCreated
        | PlanDeleted
        | PlanUpdated
        | PriceCreated
        | PriceDeleted
        | PriceUpdated
        | ProductCreated
        | ProductDeleted
        | ProductUpdated
        | PromotionCodeCreated
        | PromotionCodeUpdated
        | RadarEarlyFraudWarningCreated
        | RadarEarlyFraudWarningUpdated
        | RecipientCreated
        | RecipientDeleted
        | RecipientUpdated
        | ReportingReportRunFailed
        | ReportingReportRunSucceeded
        | ReportingReportTypeUpdated
        | ReviewClosed
        | ReviewOpened
        | SetupIntentCanceled
        | SetupIntentCreated
        | SetupIntentRequiresAction
        | SetupIntentSetupFailed
        | SetupIntentSucceeded
        | SigmaScheduledQueryRunCreated
        | SkuCreated
        | SkuDeleted
        | SkuUpdated
        | SourceCanceled
        | SourceChargeable
        | SourceFailed
        | SourceMandateNotification
        | SourceRefundAttributesRequired
        | SourceTransactionCreated
        | SourceTransactionUpdated
        | SubscriptionScheduleAborted
        | SubscriptionScheduleCanceled
        | SubscriptionScheduleCompleted
        | SubscriptionScheduleCreated
        | SubscriptionScheduleExpiring
        | SubscriptionScheduleReleased
        | SubscriptionScheduleUpdated
        | TaxRateCreated
        | TaxRateUpdated
        | TopupCanceled
        | TopupCreated
        | TopupFailed
        | TopupReversed
        | TopupSucceeded
        | TransferCreated
        | TransferFailed
        | TransferPaid
        | TransferReversed
        | TransferUpdated

    and PostWebhookEndpointsWebhookEndpointParams (?description: string, ?disabled: bool, ?enabledEvents: PostWebhookEndpointsWebhookEndpointEnabledEvents list, ?expand: string list, ?metadata: Map<string, string>, ?url: string) =
        ///An optional description of what the webhook is used for.
        member _.Description = description
        ///Disable the webhook endpoint if set to true.
        member _.Disabled = disabled
        ///The list of events to enable for this endpoint. You may specify `['*']` to enable all events, except those that require explicit selection.
        member _.EnabledEvents = enabledEvents
        ///Specifies which fields in the response should be expanded.
        member _.Expand = expand
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        member _.Metadata = metadata
        ///The URL of the webhook endpoint.
        member _.Url = url

    and PostWebhookEndpointsWebhookEndpointEnabledEvents =
        | Asterix
        | AccountApplicationAuthorized
        | AccountApplicationDeauthorized
        | AccountExternalAccountCreated
        | AccountExternalAccountDeleted
        | AccountExternalAccountUpdated
        | AccountUpdated
        | ApplicationFeeCreated
        | ApplicationFeeRefundUpdated
        | ApplicationFeeRefunded
        | BalanceAvailable
        | CapabilityUpdated
        | ChargeCaptured
        | ChargeDisputeClosed
        | ChargeDisputeCreated
        | ChargeDisputeFundsReinstated
        | ChargeDisputeFundsWithdrawn
        | ChargeDisputeUpdated
        | ChargeExpired
        | ChargeFailed
        | ChargePending
        | ChargeRefundUpdated
        | ChargeRefunded
        | ChargeSucceeded
        | ChargeUpdated
        | CheckoutSessionAsyncPaymentFailed
        | CheckoutSessionAsyncPaymentSucceeded
        | CheckoutSessionCompleted
        | CouponCreated
        | CouponDeleted
        | CouponUpdated
        | CreditNoteCreated
        | CreditNoteUpdated
        | CreditNoteVoided
        | CustomerCreated
        | CustomerDeleted
        | CustomerDiscountCreated
        | CustomerDiscountDeleted
        | CustomerDiscountUpdated
        | CustomerSourceCreated
        | CustomerSourceDeleted
        | CustomerSourceExpiring
        | CustomerSourceUpdated
        | CustomerSubscriptionCreated
        | CustomerSubscriptionDeleted
        | CustomerSubscriptionPendingUpdateApplied
        | CustomerSubscriptionPendingUpdateExpired
        | CustomerSubscriptionTrialWillEnd
        | CustomerSubscriptionUpdated
        | CustomerTaxIdCreated
        | CustomerTaxIdDeleted
        | CustomerTaxIdUpdated
        | CustomerUpdated
        | FileCreated
        | InvoiceCreated
        | InvoiceDeleted
        | InvoiceFinalizationFailed
        | InvoiceFinalized
        | InvoiceMarkedUncollectible
        | InvoicePaid
        | InvoicePaymentActionRequired
        | InvoicePaymentFailed
        | InvoicePaymentSucceeded
        | InvoiceSent
        | InvoiceUpcoming
        | InvoiceUpdated
        | InvoiceVoided
        | InvoiceitemCreated
        | InvoiceitemDeleted
        | InvoiceitemUpdated
        | IssuingAuthorizationCreated
        | IssuingAuthorizationRequest
        | IssuingAuthorizationUpdated
        | IssuingCardCreated
        | IssuingCardUpdated
        | IssuingCardholderCreated
        | IssuingCardholderUpdated
        | IssuingDisputeClosed
        | IssuingDisputeCreated
        | IssuingDisputeFundsReinstated
        | IssuingDisputeSubmitted
        | IssuingDisputeUpdated
        | IssuingTransactionCreated
        | IssuingTransactionUpdated
        | MandateUpdated
        | OrderCreated
        | OrderPaymentFailed
        | OrderPaymentSucceeded
        | OrderUpdated
        | OrderReturnCreated
        | PaymentIntentAmountCapturableUpdated
        | PaymentIntentCanceled
        | PaymentIntentCreated
        | PaymentIntentPaymentFailed
        | PaymentIntentProcessing
        | PaymentIntentRequiresAction
        | PaymentIntentSucceeded
        | PaymentMethodAttached
        | PaymentMethodAutomaticallyUpdated
        | PaymentMethodDetached
        | PaymentMethodUpdated
        | PayoutCanceled
        | PayoutCreated
        | PayoutFailed
        | PayoutPaid
        | PayoutUpdated
        | PersonCreated
        | PersonDeleted
        | PersonUpdated
        | PlanCreated
        | PlanDeleted
        | PlanUpdated
        | PriceCreated
        | PriceDeleted
        | PriceUpdated
        | ProductCreated
        | ProductDeleted
        | ProductUpdated
        | PromotionCodeCreated
        | PromotionCodeUpdated
        | RadarEarlyFraudWarningCreated
        | RadarEarlyFraudWarningUpdated
        | RecipientCreated
        | RecipientDeleted
        | RecipientUpdated
        | ReportingReportRunFailed
        | ReportingReportRunSucceeded
        | ReportingReportTypeUpdated
        | ReviewClosed
        | ReviewOpened
        | SetupIntentCanceled
        | SetupIntentCreated
        | SetupIntentRequiresAction
        | SetupIntentSetupFailed
        | SetupIntentSucceeded
        | SigmaScheduledQueryRunCreated
        | SkuCreated
        | SkuDeleted
        | SkuUpdated
        | SourceCanceled
        | SourceChargeable
        | SourceFailed
        | SourceMandateNotification
        | SourceRefundAttributesRequired
        | SourceTransactionCreated
        | SourceTransactionUpdated
        | SubscriptionScheduleAborted
        | SubscriptionScheduleCanceled
        | SubscriptionScheduleCompleted
        | SubscriptionScheduleCreated
        | SubscriptionScheduleExpiring
        | SubscriptionScheduleReleased
        | SubscriptionScheduleUpdated
        | TaxRateCreated
        | TaxRateUpdated
        | TopupCanceled
        | TopupCreated
        | TopupFailed
        | TopupReversed
        | TopupSucceeded
        | TransferCreated
        | TransferFailed
        | TransferPaid
        | TransferReversed
        | TransferUpdated

