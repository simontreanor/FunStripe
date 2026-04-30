namespace Stripe.Gelato

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Address

/// Point in Time
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type GelatoDataVerifiedOutputsDate =
    {
        /// Numerical day between 1 and 31.
        Day: int option
        /// Numerical month between 1 and 12.
        Month: int option
        /// The four-digit year.
        Year: int option
    }

[<Struct>]
type GelatoVerifiedOutputsIdNumberType =
    | BrCpf
    | SgNric
    | UsSsn

[<Struct>]
type GelatoVerifiedOutputsSex =
    | Redacted
    | Female
    | Male
    | Unknown

type GelatoVerifiedOutputs =
    {
        /// The user's verified address.
        Address: Address option
        /// The user’s verified date of birth.
        Dob: GelatoDataVerifiedOutputsDate option
        /// The user's verified email address
        Email: string option
        /// The user's verified first name.
        FirstName: string option
        /// The user's verified id number.
        IdNumber: string option
        /// The user's verified id number type.
        IdNumberType: GelatoVerifiedOutputsIdNumberType option
        /// The user's verified last name.
        LastName: string option
        /// The user's verified phone number
        Phone: string option
        /// The user's verified sex.
        Sex: GelatoVerifiedOutputsSex option
        /// The user's verified place of birth as it appears in the document.
        UnparsedPlaceOfBirth: string option
        /// The user's verified sex as it appears in the document.
        UnparsedSex: string option
    }

[<Struct>]
type GelatoSessionDocumentOptionsAllowedTypes =
    | DrivingLicense
    | IdCard
    | Passport

type GelatoSessionDocumentOptions =
    {
        /// Array of strings of allowed identity document types. If the provided identity document isn’t one of the allowed types, the verification check will fail with a document_type_not_allowed error code.
        AllowedTypes: GelatoSessionDocumentOptionsAllowedTypes list option
        /// Collect an ID number and perform an [ID number check](https://docs.stripe.com/identity/verification-checks?type=id-number) with the document’s extracted name and date of birth.
        RequireIdNumber: bool option
        /// Disable image uploads, identity document images have to be captured using the device’s camera.
        RequireLiveCapture: bool option
        /// Capture a face image and perform a [selfie check](https://docs.stripe.com/identity/verification-checks?type=selfie) comparing a photo ID and a picture of your user’s face. [Learn more](https://docs.stripe.com/identity/selfie).
        RequireMatchingSelfie: bool option
    }

type GelatoSessionEmailOptions =
    {
        /// Request one time password verification of `provided_details.email`.
        RequireVerification: bool option
    }

type GelatoSessionIdNumberOptions =
    { GelatoSessionIdNumberOptions: string option }

[<Struct>]
type GelatoSessionMatchingOptionsDob =
    | [<JsonPropertyName("none")>] None'
    | Similar

[<Struct>]
type GelatoSessionMatchingOptionsName =
    | [<JsonPropertyName("none")>] None'
    | Similar

type GelatoSessionMatchingOptions =
    {
        /// Strictness of the DOB matching policy to apply.
        Dob: GelatoSessionMatchingOptionsDob option
        /// Strictness of the name matching policy to apply.
        Name: GelatoSessionMatchingOptionsName option
    }

type GelatoSessionPhoneOptions =
    {
        /// Request one time password verification of `provided_details.phone`.
        RequireVerification: bool option
    }

type GelatoVerificationSessionOptions =
    { Document: GelatoSessionDocumentOptions option
      Email: GelatoSessionEmailOptions option
      IdNumber: GelatoSessionIdNumberOptions option
      Matching: GelatoSessionMatchingOptions option
      Phone: GelatoSessionPhoneOptions option }

[<Struct>]
type GelatoReportDocumentOptionsAllowedTypes =
    | DrivingLicense
    | IdCard
    | Passport

type GelatoReportDocumentOptions =
    {
        /// Array of strings of allowed identity document types. If the provided identity document isn’t one of the allowed types, the verification check will fail with a document_type_not_allowed error code.
        AllowedTypes: GelatoReportDocumentOptionsAllowedTypes list option
        /// Collect an ID number and perform an [ID number check](https://docs.stripe.com/identity/verification-checks?type=id-number) with the document’s extracted name and date of birth.
        RequireIdNumber: bool option
        /// Disable image uploads, identity document images have to be captured using the device’s camera.
        RequireLiveCapture: bool option
        /// Capture a face image and perform a [selfie check](https://docs.stripe.com/identity/verification-checks?type=selfie) comparing a photo ID and a picture of your user’s face. [Learn more](https://docs.stripe.com/identity/selfie).
        RequireMatchingSelfie: bool option
    }

type GelatoReportIdNumberOptions =
    { GelatoReportIdNumberOptions: string option }

type GelatoVerificationReportOptions =
    { Document: GelatoReportDocumentOptions option
      IdNumber: GelatoReportIdNumberOptions option }

type GelatoSessionLastErrorCode =
    | Abandoned
    | ConsentDeclined
    | CountryNotSupported
    | DeviceNotSupported
    | DocumentExpired
    | DocumentTypeNotSupported
    | DocumentUnverifiedOther
    | EmailUnverifiedOther
    | EmailVerificationDeclined
    | IdNumberInsufficientDocumentData
    | IdNumberMismatch
    | IdNumberUnverifiedOther
    | PhoneUnverifiedOther
    | PhoneVerificationDeclined
    | SelfieDocumentMissingPhoto
    | SelfieFaceMismatch
    | SelfieManipulated
    | SelfieUnverifiedOther
    | UnderSupportedAge

/// Shows last VerificationSession error
type GelatoSessionLastError =
    {
        /// A short machine-readable string giving the reason for the verification or user-session failure.
        Code: GelatoSessionLastErrorCode option
        /// A message that explains the reason for verification or user-session failure.
        Reason: string option
    }

[<Struct>]
type GelatoSelfieReportErrorCode =
    | SelfieDocumentMissingPhoto
    | SelfieFaceMismatch
    | SelfieManipulated
    | SelfieUnverifiedOther

type GelatoSelfieReportError =
    {
        /// A short machine-readable string giving the reason for the verification failure.
        Code: GelatoSelfieReportErrorCode option
        /// A human-readable message giving the reason for the failure. These messages can be shown to your users.
        Reason: string option
    }

[<Struct>]
type GelatoSelfieReportStatus =
    | Unverified
    | Verified

/// Result from a selfie check
type GelatoSelfieReport =
    {
        /// ID of the [File](https://docs.stripe.com/api/files) holding the image of the identity document used in this check.
        Document: string option
        /// Details on the verification error. Present when status is `unverified`.
        Error: GelatoSelfieReportError option
        /// ID of the [File](https://docs.stripe.com/api/files) holding the image of the selfie used in this check.
        Selfie: string option
        /// Status of this `selfie` check.
        Status: GelatoSelfieReportStatus
    }

type GelatoRelatedPerson =
    {
        /// Token referencing the associated Account of the related Person resource.
        Account: string
        /// Token referencing the related Person resource.
        Person: string
    }

type GelatoProvidedDetails =
    {
        /// Email of user being verified
        Email: string option
        /// Phone number of user being verified
        Phone: string option
    }

[<Struct>]
type GelatoPhoneReportErrorCode =
    | PhoneUnverifiedOther
    | PhoneVerificationDeclined

type GelatoPhoneReportError =
    {
        /// A short machine-readable string giving the reason for the verification failure.
        Code: GelatoPhoneReportErrorCode option
        /// A human-readable message giving the reason for the failure. These messages can be shown to your users.
        Reason: string option
    }

[<Struct>]
type GelatoPhoneReportStatus =
    | Unverified
    | Verified

/// Result from a phone check
type GelatoPhoneReport =
    {
        /// Details on the verification error. Present when status is `unverified`.
        Error: GelatoPhoneReportError option
        /// Phone to be verified.
        Phone: string option
        /// Status of this `phone` check.
        Status: GelatoPhoneReportStatus
    }

/// Point in Time
type GelatoDataIdNumberReportDate =
    {
        /// Numerical day between 1 and 31.
        Day: int option
        /// Numerical month between 1 and 12.
        Month: int option
        /// The four-digit year.
        Year: int option
    }

[<Struct>]
type GelatoIdNumberReportErrorCode =
    | IdNumberInsufficientDocumentData
    | IdNumberMismatch
    | IdNumberUnverifiedOther

type GelatoIdNumberReportError =
    {
        /// A short machine-readable string giving the reason for the verification failure.
        Code: GelatoIdNumberReportErrorCode option
        /// A human-readable message giving the reason for the failure. These messages can be shown to your users.
        Reason: string option
    }

[<Struct>]
type GelatoIdNumberReportIdNumberType =
    | BrCpf
    | SgNric
    | UsSsn

[<Struct>]
type GelatoIdNumberReportStatus =
    | Unverified
    | Verified

/// Result from an id_number check
type GelatoIdNumberReport =
    {
        /// Date of birth.
        Dob: GelatoDataIdNumberReportDate option
        /// Details on the verification error. Present when status is `unverified`.
        Error: GelatoIdNumberReportError option
        /// First name.
        FirstName: string option
        /// ID number. When `id_number_type` is `us_ssn`, only the last 4 digits are present.
        IdNumber: string option
        /// Type of ID number.
        IdNumberType: GelatoIdNumberReportIdNumberType option
        /// Last name.
        LastName: string option
        /// Status of this `id_number` check.
        Status: GelatoIdNumberReportStatus
    }

[<Struct>]
type GelatoEmailReportErrorCode =
    | EmailUnverifiedOther
    | EmailVerificationDeclined

type GelatoEmailReportError =
    {
        /// A short machine-readable string giving the reason for the verification failure.
        Code: GelatoEmailReportErrorCode option
        /// A human-readable message giving the reason for the failure. These messages can be shown to your users.
        Reason: string option
    }

[<Struct>]
type GelatoEmailReportStatus =
    | Unverified
    | Verified

/// Result from a email check
type GelatoEmailReport =
    {
        /// Email to be verified.
        Email: string option
        /// Details on the verification error. Present when status is `unverified`.
        Error: GelatoEmailReportError option
        /// Status of this `email` check.
        Status: GelatoEmailReportStatus
    }

/// Point in Time
type GelatoDataDocumentReportDateOfBirth =
    {
        /// Numerical day between 1 and 31.
        Day: int option
        /// Numerical month between 1 and 12.
        Month: int option
        /// The four-digit year.
        Year: int option
    }

/// Point in Time
type GelatoDataDocumentReportExpirationDate =
    {
        /// Numerical day between 1 and 31.
        Day: int option
        /// Numerical month between 1 and 12.
        Month: int option
        /// The four-digit year.
        Year: int option
    }

/// Point in Time
type GelatoDataDocumentReportIssuedDate =
    {
        /// Numerical day between 1 and 31.
        Day: int option
        /// Numerical month between 1 and 12.
        Month: int option
        /// The four-digit year.
        Year: int option
    }

[<Struct>]
type GelatoDocumentReportErrorCode =
    | DocumentExpired
    | DocumentTypeNotSupported
    | DocumentUnverifiedOther

type GelatoDocumentReportError =
    {
        /// A short machine-readable string giving the reason for the verification failure.
        Code: GelatoDocumentReportErrorCode option
        /// A human-readable message giving the reason for the failure. These messages can be shown to your users.
        Reason: string option
    }

[<Struct>]
type GelatoDocumentReportSex =
    | Redacted
    | Female
    | Male
    | Unknown

[<Struct>]
type GelatoDocumentReportStatus =
    | Unverified
    | Verified

[<Struct>]
type GelatoDocumentReportType =
    | DrivingLicense
    | IdCard
    | Passport

/// Result from a document check
type GelatoDocumentReport =
    {
        /// Address as it appears in the document.
        Address: Address option
        /// Date of birth as it appears in the document.
        Dob: GelatoDataDocumentReportDateOfBirth option
        /// Details on the verification error. Present when status is `unverified`.
        Error: GelatoDocumentReportError option
        /// Expiration date of the document.
        ExpirationDate: GelatoDataDocumentReportExpirationDate option
        /// Array of [File](https://docs.stripe.com/api/files) ids containing images for this document.
        Files: string list option
        /// First name as it appears in the document.
        FirstName: string option
        /// Issued date of the document.
        IssuedDate: GelatoDataDocumentReportIssuedDate option
        /// Issuing country of the document.
        IssuingCountry: IsoTypes.IsoCountryCode option
        /// Last name as it appears in the document.
        LastName: string option
        /// Document ID number.
        Number: string option
        /// Sex of the person in the document.
        Sex: GelatoDocumentReportSex option
        /// Status of this `document` check.
        Status: GelatoDocumentReportStatus
        /// Type of the document.
        Type: GelatoDocumentReportType option
        /// Place of birth as it appears in the document.
        UnparsedPlaceOfBirth: string option
        /// Sex as it appears in the document.
        UnparsedSex: string option
    }

