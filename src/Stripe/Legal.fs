namespace Stripe.Legal

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Address
open Stripe.File

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type LegalEntityPersonVerificationDetailsCode =
    | DocumentAddressMismatch
    | DocumentDobMismatch
    | DocumentDuplicateType
    | DocumentIdNumberMismatch
    | DocumentNameMismatch
    | DocumentNationalityMismatch
    | FailedKeyedIdentity
    | FailedOther

type LegalEntityPersonVerificationDocumentBack'AnyOf =
    | String of string
    | File of File

type LegalEntityPersonVerificationDocumentDetailsCode =
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

type LegalEntityPersonVerificationDocumentFront'AnyOf =
    | String of string
    | File of File

type LegalEntityPersonVerificationDocument =
    {
        /// The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`.
        Back: LegalEntityPersonVerificationDocumentBack'AnyOf option
        /// A user-displayable string describing the verification state of this document. For example, if a document is uploaded and the picture is too fuzzy, this may say "Identity document is too unclear to read".
        Details: string option
        /// One of `document_corrupt`, `document_country_not_supported`, `document_expired`, `document_failed_copy`, `document_failed_other`, `document_failed_test_mode`, `document_fraudulent`, `document_failed_greyscale`, `document_incomplete`, `document_invalid`, `document_manipulated`, `document_missing_back`, `document_missing_front`, `document_not_readable`, `document_not_uploaded`, `document_photo_mismatch`, `document_too_large`, or `document_type_not_supported`. A machine-readable code specifying the verification state for this document.
        DetailsCode: LegalEntityPersonVerificationDocumentDetailsCode option
        /// The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`.
        Front: LegalEntityPersonVerificationDocumentFront'AnyOf option
    }

module LegalEntityPersonVerificationDocument =
    let create
        (
            back: LegalEntityPersonVerificationDocumentBack'AnyOf option,
            details: string option,
            detailsCode: LegalEntityPersonVerificationDocumentDetailsCode option,
            front: LegalEntityPersonVerificationDocumentFront'AnyOf option
        ) : LegalEntityPersonVerificationDocument
        =
        {
          Back = back
          Details = details
          DetailsCode = detailsCode
          Front = front
        }

[<Struct>]
type LegalEntityPersonVerificationStatus =
    | Unverified
    | Pending
    | Verified

type LegalEntityPersonVerification =
    {
        /// A document showing address, either a passport, local ID card, or utility bill from a well-known utility company.
        AdditionalDocument: LegalEntityPersonVerificationDocument option
        /// A user-displayable string describing the verification state for the person. For example, this may say "Provided identity information could not be verified".
        Details: string option
        /// One of `document_address_mismatch`, `document_dob_mismatch`, `document_duplicate_type`, `document_id_number_mismatch`, `document_name_mismatch`, `document_nationality_mismatch`, `failed_keyed_identity`, or `failed_other`. A machine-readable code specifying the verification state for the person.
        DetailsCode: LegalEntityPersonVerificationDetailsCode option
        Document: LegalEntityPersonVerificationDocument option
        /// The state of verification for the person. Possible values are `unverified`, `pending`, or `verified`. Please refer [guide](https://docs.stripe.com/connect/handling-api-verification) to handle verification updates.
        Status: LegalEntityPersonVerificationStatus
    }

module LegalEntityPersonVerification =
    let create
        (
            status: LegalEntityPersonVerificationStatus
        ) : LegalEntityPersonVerification
        =
        {
          Status = status
          AdditionalDocument = None
          Details = None
          DetailsCode = None
          Document = None
        }

type LegalEntityDob =
    {
        /// The day of birth, between 1 and 31.
        Day: int option
        /// The month of birth, between 1 and 12.
        Month: int option
        /// The four-digit year of birth.
        Year: int option
    }

module LegalEntityDob =
    let create
        (
            day: int option,
            month: int option,
            year: int option
        ) : LegalEntityDob
        =
        {
          Day = day
          Month = month
          Year = year
        }

[<Struct>]
type LegalEntityCompanyOwnershipExemptionReason =
    | QualifiedEntityExceedsOwnershipThreshold
    | QualifiesAsFinancialInstitution

type LegalEntityCompanyStructure =
    | FreeZoneEstablishment
    | FreeZoneLlc
    | GovernmentInstrumentality
    | GovernmentalUnit
    | IncorporatedNonProfit
    | IncorporatedPartnership
    | LimitedLiabilityPartnership
    | Llc
    | MultiMemberLlc
    | PrivateCompany
    | PrivateCorporation
    | PrivatePartnership
    | PublicCompany
    | PublicCorporation
    | PublicPartnership
    | RegisteredCharity
    | SingleMemberLlc
    | SoleEstablishment
    | SoleProprietorship
    | TaxExemptGovernmentInstrumentality
    | UnincorporatedAssociation
    | UnincorporatedNonProfit
    | UnincorporatedPartnership

type LegalEntityCompanyVerificationDocumentBack'AnyOf =
    | String of string
    | File of File

type LegalEntityCompanyVerificationDocumentDetailsCode =
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

type LegalEntityCompanyVerificationDocumentFront'AnyOf =
    | String of string
    | File of File

type LegalEntityCompanyVerificationDocument =
    {
        /// The back of a document returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `additional_verification`. Note that `additional_verification` files are [not downloadable](/file-upload#uploading-a-file).
        Back: LegalEntityCompanyVerificationDocumentBack'AnyOf option
        /// A user-displayable string describing the verification state of this document.
        Details: string option
        /// One of `document_corrupt`, `document_expired`, `document_failed_copy`, `document_failed_greyscale`, `document_failed_other`, `document_failed_test_mode`, `document_fraudulent`, `document_incomplete`, `document_invalid`, `document_manipulated`, `document_not_readable`, `document_not_uploaded`, `document_type_not_supported`, or `document_too_large`. A machine-readable code specifying the verification state for this document.
        DetailsCode: LegalEntityCompanyVerificationDocumentDetailsCode option
        /// The front of a document returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `additional_verification`. Note that `additional_verification` files are [not downloadable](/file-upload#uploading-a-file).
        Front: LegalEntityCompanyVerificationDocumentFront'AnyOf option
    }

module LegalEntityCompanyVerificationDocument =
    let create
        (
            back: LegalEntityCompanyVerificationDocumentBack'AnyOf option,
            details: string option,
            detailsCode: LegalEntityCompanyVerificationDocumentDetailsCode option,
            front: LegalEntityCompanyVerificationDocumentFront'AnyOf option
        ) : LegalEntityCompanyVerificationDocument
        =
        {
          Back = back
          Details = details
          DetailsCode = detailsCode
          Front = front
        }

type LegalEntityCompanyVerification =
    { Document: LegalEntityCompanyVerificationDocument }

module LegalEntityCompanyVerification =
    let create
        (
            document: LegalEntityCompanyVerificationDocument
        ) : LegalEntityCompanyVerification
        =
        {
          Document = document
        }

type LegalEntityDirectorshipDeclaration =
    {
        /// The Unix timestamp marking when the directorship declaration attestation was made.
        Date: DateTime option
        /// The IP address from which the directorship declaration attestation was made.
        Ip: string option
        /// The user-agent string from the browser where the directorship declaration attestation was made.
        UserAgent: string option
    }

module LegalEntityDirectorshipDeclaration =
    let create
        (
            date: DateTime option,
            ip: string option,
            userAgent: string option
        ) : LegalEntityDirectorshipDeclaration
        =
        {
          Date = date
          Ip = ip
          UserAgent = userAgent
        }

type LegalEntityJapanAddress =
    {
        /// City/Ward.
        City: string option
        /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        Country: IsoTypes.IsoCountryCode option
        /// Block/Building number.
        [<JsonPropertyName("line1")>]
        Line1: string option
        /// Building details.
        [<JsonPropertyName("line2")>]
        Line2: string option
        /// ZIP or postal code.
        PostalCode: string option
        /// Prefecture.
        State: string option
        /// Town/cho-me.
        Town: string option
    }

module LegalEntityJapanAddress =
    let create
        (
            city: string option,
            country: IsoTypes.IsoCountryCode option,
            line1: string option,
            line2: string option,
            postalCode: string option,
            state: string option,
            town: string option
        ) : LegalEntityJapanAddress
        =
        {
          City = city
          Country = country
          Line1 = line1
          Line2 = line2
          PostalCode = postalCode
          State = state
          Town = town
        }

type LegalEntityRegistrationDate =
    {
        /// The day of registration, between 1 and 31.
        Day: int option
        /// The month of registration, between 1 and 12.
        Month: int option
        /// The four-digit year of registration.
        Year: int option
    }

module LegalEntityRegistrationDate =
    let create
        (
            day: int option,
            month: int option,
            year: int option
        ) : LegalEntityRegistrationDate
        =
        {
          Day = day
          Month = month
          Year = year
        }

type LegalEntityRepresentativeDeclaration =
    {
        /// The Unix timestamp marking when the representative declaration attestation was made.
        Date: DateTime option
        /// The IP address from which the representative declaration attestation was made.
        Ip: string option
        /// The user-agent string from the browser where the representative declaration attestation was made.
        UserAgent: string option
    }

module LegalEntityRepresentativeDeclaration =
    let create
        (
            date: DateTime option,
            ip: string option,
            userAgent: string option
        ) : LegalEntityRepresentativeDeclaration
        =
        {
          Date = date
          Ip = ip
          UserAgent = userAgent
        }

type LegalEntityUboDeclaration =
    {
        /// The Unix timestamp marking when the beneficial owner attestation was made.
        Date: DateTime option
        /// The IP address from which the beneficial owner attestation was made.
        Ip: string option
        /// The user-agent string from the browser where the beneficial owner attestation was made.
        UserAgent: string option
    }

module LegalEntityUboDeclaration =
    let create
        (
            date: DateTime option,
            ip: string option,
            userAgent: string option
        ) : LegalEntityUboDeclaration
        =
        {
          Date = date
          Ip = ip
          UserAgent = userAgent
        }

type LegalEntityCompany =
    {
        Address: Address option
        /// The Kana variation of the company's primary address (Japan only).
        AddressKana: LegalEntityJapanAddress option
        /// The Kanji variation of the company's primary address (Japan only).
        AddressKanji: LegalEntityJapanAddress option
        /// Whether the company's directors have been provided. This Boolean will be `true` if you've manually indicated that all directors are provided via [the `directors_provided` parameter](https://docs.stripe.com/api/accounts/update#update_account-company-directors_provided).
        DirectorsProvided: bool option
        /// This hash is used to attest that the director information provided to Stripe is both current and correct.
        DirectorshipDeclaration: LegalEntityDirectorshipDeclaration option
        /// Whether the company's executives have been provided. This Boolean will be `true` if you've manually indicated that all executives are provided via [the `executives_provided` parameter](https://docs.stripe.com/api/accounts/update#update_account-company-executives_provided), or if Stripe determined that sufficient executives were provided.
        ExecutivesProvided: bool option
        /// The export license ID number of the company, also referred as Import Export Code (India only).
        ExportLicenseId: string option
        /// The purpose code to use for export transactions (India only).
        ExportPurposeCode: string option
        /// The company's legal name. Also available for accounts where [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `stripe`.
        Name: string option
        /// The Kana variation of the company's legal name (Japan only). Also available for accounts where [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `stripe`.
        NameKana: string option
        /// The Kanji variation of the company's legal name (Japan only). Also available for accounts where [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `stripe`.
        NameKanji: string option
        /// Whether the company's owners have been provided. This Boolean will be `true` if you've manually indicated that all owners are provided via [the `owners_provided` parameter](https://docs.stripe.com/api/accounts/update#update_account-company-owners_provided), or if Stripe determined that sufficient owners were provided. Stripe determines ownership requirements using both the number of owners provided and their total percent ownership (calculated by adding the `percent_ownership` of each owner together).
        OwnersProvided: bool option
        /// This hash is used to attest that the beneficial owner information provided to Stripe is both current and correct.
        OwnershipDeclaration: LegalEntityUboDeclaration option
        /// This value is used to determine if a business is exempt from providing ultimate beneficial owners. See [this support article](https://support.stripe.com/questions/exemption-from-providing-ownership-details) and [changelog](https://docs.stripe.com/changelog/acacia/2025-01-27/ownership-exemption-reason-accounts-api) for more details.
        OwnershipExemptionReason: LegalEntityCompanyOwnershipExemptionReason option
        /// The company's phone number (used for verification).
        Phone: string option
        RegistrationDate: LegalEntityRegistrationDate option
        /// This hash is used to attest that the representative is authorized to act as the representative of their legal entity.
        RepresentativeDeclaration: LegalEntityRepresentativeDeclaration option
        /// The category identifying the legal structure of the company or legal entity. Also available for accounts where [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `stripe`. See [Business structure](https://docs.stripe.com/connect/identity-verification#business-structure) for more details.
        Structure: LegalEntityCompanyStructure option
        /// Whether the company's business ID number was provided.
        TaxIdProvided: bool option
        /// The jurisdiction in which the `tax_id` is registered (Germany-based companies only).
        TaxIdRegistrar: string option
        /// Whether the company's business VAT number was provided.
        VatIdProvided: bool option
        /// Information on the verification state of the company.
        Verification: LegalEntityCompanyVerification option
    }

module LegalEntityCompany =
    let create
        (
            address: Address option,
            addressKana: LegalEntityJapanAddress option option,
            addressKanji: LegalEntityJapanAddress option option,
            directorsProvided: bool option,
            directorshipDeclaration: LegalEntityDirectorshipDeclaration option option,
            executivesProvided: bool option,
            exportLicenseId: string option,
            exportPurposeCode: string option,
            name: string option option,
            nameKana: string option option,
            nameKanji: string option option,
            ownersProvided: bool option,
            ownershipDeclaration: LegalEntityUboDeclaration option option,
            ownershipExemptionReason: LegalEntityCompanyOwnershipExemptionReason option,
            phone: string option option,
            registrationDate: LegalEntityRegistrationDate option,
            representativeDeclaration: LegalEntityRepresentativeDeclaration option option,
            structure: LegalEntityCompanyStructure option,
            taxIdProvided: bool option,
            taxIdRegistrar: string option,
            vatIdProvided: bool option,
            verification: LegalEntityCompanyVerification option option
        ) : LegalEntityCompany
        =
        {
          Address = address
          AddressKana = addressKana |> Option.flatten
          AddressKanji = addressKanji |> Option.flatten
          DirectorsProvided = directorsProvided
          DirectorshipDeclaration = directorshipDeclaration |> Option.flatten
          ExecutivesProvided = executivesProvided
          ExportLicenseId = exportLicenseId
          ExportPurposeCode = exportPurposeCode
          Name = name |> Option.flatten
          NameKana = nameKana |> Option.flatten
          NameKanji = nameKanji |> Option.flatten
          OwnersProvided = ownersProvided
          OwnershipDeclaration = ownershipDeclaration |> Option.flatten
          OwnershipExemptionReason = ownershipExemptionReason
          Phone = phone |> Option.flatten
          RegistrationDate = registrationDate
          RepresentativeDeclaration = representativeDeclaration |> Option.flatten
          Structure = structure
          TaxIdProvided = taxIdProvided
          TaxIdRegistrar = taxIdRegistrar
          VatIdProvided = vatIdProvided
          Verification = verification |> Option.flatten
        }

