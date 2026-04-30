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

module GelatoDataVerifiedOutputsDate =
    let create
        (
            day: int option,
            month: int option,
            year: int option
        ) : GelatoDataVerifiedOutputsDate
        =
        {
          Day = day
          Month = month
          Year = year
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

module GelatoVerifiedOutputs =
    let create
        (
            address: Address option,
            email: string option,
            firstName: string option,
            idNumberType: GelatoVerifiedOutputsIdNumberType option,
            lastName: string option,
            phone: string option
        ) : GelatoVerifiedOutputs
        =
        {
          Address = address
          Email = email
          FirstName = firstName
          IdNumberType = idNumberType
          LastName = lastName
          Phone = phone
          Dob = None
          IdNumber = None
          Sex = None
          UnparsedPlaceOfBirth = None
          UnparsedSex = None
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

module GelatoSessionDocumentOptions =
    let create
        (
            allowedTypes: GelatoSessionDocumentOptionsAllowedTypes list option,
            requireIdNumber: bool option,
            requireLiveCapture: bool option,
            requireMatchingSelfie: bool option
        ) : GelatoSessionDocumentOptions
        =
        {
          AllowedTypes = allowedTypes
          RequireIdNumber = requireIdNumber
          RequireLiveCapture = requireLiveCapture
          RequireMatchingSelfie = requireMatchingSelfie
        }

type GelatoSessionEmailOptions =
    {
        /// Request one time password verification of `provided_details.email`.
        RequireVerification: bool option
    }

module GelatoSessionEmailOptions =
    let create
        (
            requireVerification: bool option
        ) : GelatoSessionEmailOptions
        =
        {
          RequireVerification = requireVerification
        }

type GelatoSessionIdNumberOptions =
    { GelatoSessionIdNumberOptions: string option }

module GelatoSessionIdNumberOptions =
    let create
        (
            gelatoSessionIdNumberOptions: string option option
        ) : GelatoSessionIdNumberOptions
        =
        {
          GelatoSessionIdNumberOptions = gelatoSessionIdNumberOptions |> Option.flatten
        }

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

module GelatoSessionMatchingOptions =
    let create
        (
            dob: GelatoSessionMatchingOptionsDob option,
            name: GelatoSessionMatchingOptionsName option
        ) : GelatoSessionMatchingOptions
        =
        {
          Dob = dob
          Name = name
        }

type GelatoSessionPhoneOptions =
    {
        /// Request one time password verification of `provided_details.phone`.
        RequireVerification: bool option
    }

module GelatoSessionPhoneOptions =
    let create
        (
            requireVerification: bool option
        ) : GelatoSessionPhoneOptions
        =
        {
          RequireVerification = requireVerification
        }

type GelatoVerificationSessionOptions =
    { Document: GelatoSessionDocumentOptions option
      Email: GelatoSessionEmailOptions option
      IdNumber: GelatoSessionIdNumberOptions option
      Matching: GelatoSessionMatchingOptions option
      Phone: GelatoSessionPhoneOptions option }

module GelatoVerificationSessionOptions =
    let create
        (
            document: GelatoSessionDocumentOptions option,
            email: GelatoSessionEmailOptions option,
            idNumber: GelatoSessionIdNumberOptions option,
            matching: GelatoSessionMatchingOptions option,
            phone: GelatoSessionPhoneOptions option
        ) : GelatoVerificationSessionOptions
        =
        {
          Document = document
          Email = email
          IdNumber = idNumber
          Matching = matching
          Phone = phone
        }

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

module GelatoReportDocumentOptions =
    let create
        (
            allowedTypes: GelatoReportDocumentOptionsAllowedTypes list option,
            requireIdNumber: bool option,
            requireLiveCapture: bool option,
            requireMatchingSelfie: bool option
        ) : GelatoReportDocumentOptions
        =
        {
          AllowedTypes = allowedTypes
          RequireIdNumber = requireIdNumber
          RequireLiveCapture = requireLiveCapture
          RequireMatchingSelfie = requireMatchingSelfie
        }

type GelatoReportIdNumberOptions =
    { GelatoReportIdNumberOptions: string option }

module GelatoReportIdNumberOptions =
    let create
        (
            gelatoReportIdNumberOptions: string option option
        ) : GelatoReportIdNumberOptions
        =
        {
          GelatoReportIdNumberOptions = gelatoReportIdNumberOptions |> Option.flatten
        }

type GelatoVerificationReportOptions =
    { Document: GelatoReportDocumentOptions option
      IdNumber: GelatoReportIdNumberOptions option }

module GelatoVerificationReportOptions =
    let create
        (
            document: GelatoReportDocumentOptions option,
            idNumber: GelatoReportIdNumberOptions option
        ) : GelatoVerificationReportOptions
        =
        {
          Document = document
          IdNumber = idNumber
        }

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

module GelatoSessionLastError =
    let create
        (
            code: GelatoSessionLastErrorCode option,
            reason: string option
        ) : GelatoSessionLastError
        =
        {
          Code = code
          Reason = reason
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

module GelatoSelfieReportError =
    let create
        (
            code: GelatoSelfieReportErrorCode option,
            reason: string option
        ) : GelatoSelfieReportError
        =
        {
          Code = code
          Reason = reason
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

module GelatoSelfieReport =
    let create
        (
            document: string option,
            error: GelatoSelfieReportError option,
            selfie: string option,
            status: GelatoSelfieReportStatus
        ) : GelatoSelfieReport
        =
        {
          Document = document
          Error = error
          Selfie = selfie
          Status = status
        }

type GelatoRelatedPerson =
    {
        /// Token referencing the associated Account of the related Person resource.
        Account: string
        /// Token referencing the related Person resource.
        Person: string
    }

module GelatoRelatedPerson =
    let create
        (
            account: string,
            person: string
        ) : GelatoRelatedPerson
        =
        {
          Account = account
          Person = person
        }

type GelatoProvidedDetails =
    {
        /// Email of user being verified
        Email: string option
        /// Phone number of user being verified
        Phone: string option
    }

module GelatoProvidedDetails =
    let create
        (
            email: string option,
            phone: string option
        ) : GelatoProvidedDetails
        =
        {
          Email = email
          Phone = phone
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

module GelatoPhoneReportError =
    let create
        (
            code: GelatoPhoneReportErrorCode option,
            reason: string option
        ) : GelatoPhoneReportError
        =
        {
          Code = code
          Reason = reason
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

module GelatoPhoneReport =
    let create
        (
            error: GelatoPhoneReportError option,
            phone: string option,
            status: GelatoPhoneReportStatus
        ) : GelatoPhoneReport
        =
        {
          Error = error
          Phone = phone
          Status = status
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

module GelatoDataIdNumberReportDate =
    let create
        (
            day: int option,
            month: int option,
            year: int option
        ) : GelatoDataIdNumberReportDate
        =
        {
          Day = day
          Month = month
          Year = year
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

module GelatoIdNumberReportError =
    let create
        (
            code: GelatoIdNumberReportErrorCode option,
            reason: string option
        ) : GelatoIdNumberReportError
        =
        {
          Code = code
          Reason = reason
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

module GelatoIdNumberReport =
    let create
        (
            error: GelatoIdNumberReportError option,
            firstName: string option,
            idNumberType: GelatoIdNumberReportIdNumberType option,
            lastName: string option,
            status: GelatoIdNumberReportStatus
        ) : GelatoIdNumberReport
        =
        {
          Error = error
          FirstName = firstName
          IdNumberType = idNumberType
          LastName = lastName
          Status = status
          Dob = None
          IdNumber = None
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

module GelatoEmailReportError =
    let create
        (
            code: GelatoEmailReportErrorCode option,
            reason: string option
        ) : GelatoEmailReportError
        =
        {
          Code = code
          Reason = reason
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

module GelatoEmailReport =
    let create
        (
            email: string option,
            error: GelatoEmailReportError option,
            status: GelatoEmailReportStatus
        ) : GelatoEmailReport
        =
        {
          Email = email
          Error = error
          Status = status
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

module GelatoDataDocumentReportDateOfBirth =
    let create
        (
            day: int option,
            month: int option,
            year: int option
        ) : GelatoDataDocumentReportDateOfBirth
        =
        {
          Day = day
          Month = month
          Year = year
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

module GelatoDataDocumentReportExpirationDate =
    let create
        (
            day: int option,
            month: int option,
            year: int option
        ) : GelatoDataDocumentReportExpirationDate
        =
        {
          Day = day
          Month = month
          Year = year
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

module GelatoDataDocumentReportIssuedDate =
    let create
        (
            day: int option,
            month: int option,
            year: int option
        ) : GelatoDataDocumentReportIssuedDate
        =
        {
          Day = day
          Month = month
          Year = year
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

module GelatoDocumentReportError =
    let create
        (
            code: GelatoDocumentReportErrorCode option,
            reason: string option
        ) : GelatoDocumentReportError
        =
        {
          Code = code
          Reason = reason
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

module GelatoDocumentReport =
    let create
        (
            address: Address option,
            error: GelatoDocumentReportError option,
            files: string list option,
            firstName: string option,
            issuedDate: GelatoDataDocumentReportIssuedDate option,
            issuingCountry: IsoTypes.IsoCountryCode option,
            lastName: string option,
            status: GelatoDocumentReportStatus,
            ``type``: GelatoDocumentReportType option
        ) : GelatoDocumentReport
        =
        {
          Address = address
          Error = error
          Files = files
          FirstName = firstName
          IssuedDate = issuedDate
          IssuingCountry = issuingCountry
          LastName = lastName
          Status = status
          Type = ``type``
          Dob = None
          ExpirationDate = None
          Number = None
          Sex = None
          UnparsedPlaceOfBirth = None
          UnparsedSex = None
        }

