namespace Stripe.Legal

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.File

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
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

type LegalEntityUboDeclaration =
    {
        /// The Unix timestamp marking when the beneficial owner attestation was made.
        Date: DateTime option
        /// The IP address from which the beneficial owner attestation was made.
        Ip: string option
        /// The user-agent string from the browser where the beneficial owner attestation was made.
        UserAgent: string option
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

type LegalEntityRegistrationDate =
    {
        /// The day of registration, between 1 and 31.
        Day: int option
        /// The month of registration, between 1 and 12.
        Month: int option
        /// The four-digit year of registration.
        Year: int option
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

type LegalEntityCompanyVerification =
    { Document: LegalEntityCompanyVerificationDocument }

