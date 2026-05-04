namespace Stripe.Identity

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.FundingInstructions

/// Point in Time
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
type GelatoDataDocumentReportDateOfBirth =
    {
        /// Numerical day between 1 and 31.
        Day: int option
        /// Numerical month between 1 and 12.
        Month: int option
        /// The four-digit year.
        Year: int option
    }

type GelatoDataDocumentReportDateOfBirth with
    static member New(day: int option, month: int option, year: int option) =
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

type GelatoDataDocumentReportExpirationDate with
    static member New(day: int option, month: int option, year: int option) =
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

type GelatoDataDocumentReportIssuedDate with
    static member New(day: int option, month: int option, year: int option) =
        {
            Day = day
            Month = month
            Year = year
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

type GelatoDataIdNumberReportDate with
    static member New(day: int option, month: int option, year: int option) =
        {
            Day = day
            Month = month
            Year = year
        }

/// Point in Time
type GelatoDataVerifiedOutputsDate =
    {
        /// Numerical day between 1 and 31.
        Day: int option
        /// Numerical month between 1 and 12.
        Month: int option
        /// The four-digit year.
        Year: int option
    }

type GelatoDataVerifiedOutputsDate with
    static member New(day: int option, month: int option, year: int option) =
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

type GelatoDocumentReportError with
    static member New(code: GelatoDocumentReportErrorCode option, reason: string option) =
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

type GelatoDocumentReport with
    static member New(address: Address option, error: GelatoDocumentReportError option, files: string list option, firstName: string option, issuedDate: GelatoDataDocumentReportIssuedDate option, issuingCountry: IsoTypes.IsoCountryCode option, lastName: string option, status: GelatoDocumentReportStatus, ``type``: GelatoDocumentReportType option, ?dob: GelatoDataDocumentReportDateOfBirth option, ?expirationDate: GelatoDataDocumentReportExpirationDate option, ?number: string option, ?sex: GelatoDocumentReportSex option, ?unparsedPlaceOfBirth: string option, ?unparsedSex: string option) =
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
            Dob = dob |> Option.flatten
            ExpirationDate = expirationDate |> Option.flatten
            Number = number |> Option.flatten
            Sex = sex |> Option.flatten
            UnparsedPlaceOfBirth = unparsedPlaceOfBirth |> Option.flatten
            UnparsedSex = unparsedSex |> Option.flatten
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

type GelatoEmailReportError with
    static member New(code: GelatoEmailReportErrorCode option, reason: string option) =
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

type GelatoEmailReport with
    static member New(email: string option, error: GelatoEmailReportError option, status: GelatoEmailReportStatus) =
        {
            Email = email
            Error = error
            Status = status
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

type GelatoIdNumberReportError with
    static member New(code: GelatoIdNumberReportErrorCode option, reason: string option) =
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

type GelatoIdNumberReport with
    static member New(error: GelatoIdNumberReportError option, firstName: string option, idNumberType: GelatoIdNumberReportIdNumberType option, lastName: string option, status: GelatoIdNumberReportStatus, ?dob: GelatoDataIdNumberReportDate option, ?idNumber: string option) =
        {
            Error = error
            FirstName = firstName
            IdNumberType = idNumberType
            LastName = lastName
            Status = status
            Dob = dob |> Option.flatten
            IdNumber = idNumber |> Option.flatten
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

type GelatoPhoneReportError with
    static member New(code: GelatoPhoneReportErrorCode option, reason: string option) =
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

type GelatoPhoneReport with
    static member New(error: GelatoPhoneReportError option, phone: string option, status: GelatoPhoneReportStatus) =
        {
            Error = error
            Phone = phone
            Status = status
        }

type GelatoProvidedDetails =
    {
        /// Email of user being verified
        Email: string option
        /// Phone number of user being verified
        Phone: string option
    }

type GelatoProvidedDetails with
    static member New(?email: string, ?phone: string) =
        {
            Email = email
            Phone = phone
        }

type GelatoRelatedPerson =
    {
        /// Token referencing the associated Account of the related Person resource.
        Account: string
        /// Token referencing the related Person resource.
        Person: string
    }

type GelatoRelatedPerson with
    static member New(account: string, person: string) =
        {
            Account = account
            Person = person
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

type GelatoReportDocumentOptions with
    static member New(?allowedTypes: GelatoReportDocumentOptionsAllowedTypes list, ?requireIdNumber: bool, ?requireLiveCapture: bool, ?requireMatchingSelfie: bool) =
        {
            AllowedTypes = allowedTypes
            RequireIdNumber = requireIdNumber
            RequireLiveCapture = requireLiveCapture
            RequireMatchingSelfie = requireMatchingSelfie
        }

type GelatoReportIdNumberOptions =
    { GelatoReportIdNumberOptions: string option }

type GelatoReportIdNumberOptions with
    static member New(?gelatoReportIdNumberOptions: string option) =
        {
            GelatoReportIdNumberOptions = gelatoReportIdNumberOptions |> Option.flatten
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

type GelatoSelfieReportError with
    static member New(code: GelatoSelfieReportErrorCode option, reason: string option) =
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

type GelatoSelfieReport with
    static member New(document: string option, error: GelatoSelfieReportError option, selfie: string option, status: GelatoSelfieReportStatus) =
        {
            Document = document
            Error = error
            Selfie = selfie
            Status = status
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

type GelatoSessionDocumentOptions with
    static member New(?allowedTypes: GelatoSessionDocumentOptionsAllowedTypes list, ?requireIdNumber: bool, ?requireLiveCapture: bool, ?requireMatchingSelfie: bool) =
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

type GelatoSessionEmailOptions with
    static member New(?requireVerification: bool) =
        {
            RequireVerification = requireVerification
        }

type GelatoSessionIdNumberOptions =
    { GelatoSessionIdNumberOptions: string option }

type GelatoSessionIdNumberOptions with
    static member New(?gelatoSessionIdNumberOptions: string option) =
        {
            GelatoSessionIdNumberOptions = gelatoSessionIdNumberOptions |> Option.flatten
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

type GelatoSessionLastError with
    static member New(code: GelatoSessionLastErrorCode option, reason: string option) =
        {
            Code = code
            Reason = reason
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

type GelatoSessionMatchingOptions with
    static member New(?dob: GelatoSessionMatchingOptionsDob, ?name: GelatoSessionMatchingOptionsName) =
        {
            Dob = dob
            Name = name
        }

type GelatoSessionPhoneOptions =
    {
        /// Request one time password verification of `provided_details.phone`.
        RequireVerification: bool option
    }

type GelatoSessionPhoneOptions with
    static member New(?requireVerification: bool) =
        {
            RequireVerification = requireVerification
        }

type GelatoVerificationReportOptions =
    { Document: GelatoReportDocumentOptions option
      IdNumber: GelatoReportIdNumberOptions option }

type GelatoVerificationReportOptions with
    static member New(?document: GelatoReportDocumentOptions, ?idNumber: GelatoReportIdNumberOptions) =
        {
            Document = document
            IdNumber = idNumber
        }

type GelatoVerificationSessionOptions =
    { Document: GelatoSessionDocumentOptions option
      Email: GelatoSessionEmailOptions option
      IdNumber: GelatoSessionIdNumberOptions option
      Matching: GelatoSessionMatchingOptions option
      Phone: GelatoSessionPhoneOptions option }

type GelatoVerificationSessionOptions with
    static member New(?document: GelatoSessionDocumentOptions, ?email: GelatoSessionEmailOptions, ?idNumber: GelatoSessionIdNumberOptions, ?matching: GelatoSessionMatchingOptions, ?phone: GelatoSessionPhoneOptions) =
        {
            Document = document
            Email = email
            IdNumber = idNumber
            Matching = matching
            Phone = phone
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

type GelatoVerifiedOutputs with
    static member New(address: Address option, email: string option, firstName: string option, idNumberType: GelatoVerifiedOutputsIdNumberType option, lastName: string option, phone: string option, ?dob: GelatoDataVerifiedOutputsDate option, ?idNumber: string option, ?sex: GelatoVerifiedOutputsSex option, ?unparsedPlaceOfBirth: string option, ?unparsedSex: string option) =
        {
            Address = address
            Email = email
            FirstName = firstName
            IdNumberType = idNumberType
            LastName = lastName
            Phone = phone
            Dob = dob |> Option.flatten
            IdNumber = idNumber |> Option.flatten
            Sex = sex |> Option.flatten
            UnparsedPlaceOfBirth = unparsedPlaceOfBirth |> Option.flatten
            UnparsedSex = unparsedSex |> Option.flatten
        }

[<Struct>]
type IdentityVerificationReportType =
    | Document
    | IdNumber
    | VerificationFlow

/// A VerificationReport is the result of an attempt to collect and verify data from a user.
/// The collection of verification checks performed is determined from the `type` and `options`
/// parameters used. You can find the result of each verification check performed in the
/// appropriate sub-resource: `document`, `id_number`, `selfie`.
/// Each VerificationReport contains a copy of any data collected by the user as well as
/// reference IDs which can be used to access collected images through the [FileUpload](https://docs.stripe.com/api/files)
/// API. To configure and create VerificationReports, use the
/// [VerificationSession](https://docs.stripe.com/api/identity/verification_sessions) API.
/// Related guide: [Accessing verification results](https://docs.stripe.com/identity/verification-sessions#results).
type IdentityVerificationReport =
    {
        /// A string to reference this user. This can be a customer ID, a session ID, or similar, and can be used to reconcile this verification with your internal systems.
        ClientReferenceId: string option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        Document: GelatoDocumentReport option
        Email: GelatoEmailReport option
        /// Unique identifier for the object.
        Id: string
        IdNumber: GelatoIdNumberReport option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        Options: GelatoVerificationReportOptions option
        Phone: GelatoPhoneReport option
        Selfie: GelatoSelfieReport option
        /// Type of report.
        Type: IdentityVerificationReportType
        /// The configuration token of a verification flow from the dashboard.
        VerificationFlow: string option
        /// ID of the VerificationSession that created this report.
        VerificationSession: string option
    }

type IdentityVerificationReport with
    static member New(clientReferenceId: string option, created: DateTime, id: string, livemode: bool, ``type``: IdentityVerificationReportType, verificationSession: string option, ?document: GelatoDocumentReport, ?email: GelatoEmailReport, ?idNumber: GelatoIdNumberReport, ?options: GelatoVerificationReportOptions, ?phone: GelatoPhoneReport, ?selfie: GelatoSelfieReport, ?verificationFlow: string) =
        {
            ClientReferenceId = clientReferenceId
            Created = created
            Id = id
            Livemode = livemode
            Type = ``type``
            VerificationSession = verificationSession
            Document = document
            Email = email
            IdNumber = idNumber
            Options = options
            Phone = phone
            Selfie = selfie
            VerificationFlow = verificationFlow
        }

module IdentityVerificationReport =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "identity.verification_report"

[<Struct>]
type IdentityVerificationSessionStatus =
    | Canceled
    | Processing
    | RequiresInput
    | Verified

[<Struct>]
type IdentityVerificationSessionType =
    | Document
    | IdNumber
    | VerificationFlow

[<Struct>]
type VerificationSessionRedactionStatus =
    | Processing
    | Redacted

type VerificationSessionRedaction =
    {
        /// Indicates whether this object and its related objects have been redacted or not.
        Status: VerificationSessionRedactionStatus
    }

type VerificationSessionRedaction with
    static member New(status: VerificationSessionRedactionStatus) =
        {
            Status = status
        }

/// A VerificationSession guides you through the process of collecting and verifying the identities
/// of your users. It contains details about the type of verification, such as what [verification
/// check](/docs/identity/verification-checks) to perform. Only create one VerificationSession for
/// each verification in your system.
/// A VerificationSession transitions through [multiple
/// statuses](/docs/identity/how-sessions-work) throughout its lifetime as it progresses through
/// the verification flow. The VerificationSession contains the user's verified data after
/// verification checks are complete.
/// Related guide: [The Verification Sessions API](https://docs.stripe.com/identity/verification-sessions)
type IdentityVerificationSession =
    {
        /// A string to reference this user. This can be a customer ID, a session ID, or similar, and can be used to reconcile this verification with your internal systems.
        ClientReferenceId: string option
        /// The short-lived client secret used by Stripe.js to [show a verification modal](https://docs.stripe.com/js/identity/modal) inside your app. This client secret expires after 24 hours and can only be used once. Don’t store it, log it, embed it in a URL, or expose it to anyone other than the user. Make sure that you have TLS enabled on any page that includes the client secret. Refer to our docs on [passing the client secret to the frontend](https://docs.stripe.com/identity/verification-sessions#client-secret) to learn more.
        ClientSecret: string option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Unique identifier for the object.
        Id: string
        /// If present, this property tells you the last error encountered when processing the verification.
        LastError: GelatoSessionLastError option
        /// ID of the most recent VerificationReport. [Learn more about accessing detailed verification results.](https://docs.stripe.com/identity/verification-sessions#results)
        LastVerificationReport: StripeId<Markers.IdentityVerificationReport> option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        /// A set of options for the session’s verification checks.
        Options: GelatoVerificationSessionOptions option
        /// Details provided about the user being verified. These details may be shown to the user.
        ProvidedDetails: GelatoProvidedDetails option
        /// Redaction status of this VerificationSession. If the VerificationSession is not redacted, this field will be null.
        Redaction: VerificationSessionRedaction option
        /// Customer ID
        RelatedCustomer: string option
        /// The ID of the Account representing a customer.
        RelatedCustomerAccount: string option
        RelatedPerson: GelatoRelatedPerson option
        /// Status of this VerificationSession. [Learn more about the lifecycle of sessions](https://docs.stripe.com/identity/how-sessions-work).
        Status: IdentityVerificationSessionStatus
        /// The type of [verification check](https://docs.stripe.com/identity/verification-checks) to be performed.
        Type: IdentityVerificationSessionType
        /// The short-lived URL that you use to redirect a user to Stripe to submit their identity information. This URL expires after 48 hours and can only be used once. Don’t store it, log it, send it in emails or expose it to anyone other than the user. Refer to our docs on [verifying identity documents](https://docs.stripe.com/identity/verify-identity-documents?platform=web&type=redirect) to learn how to redirect users to Stripe.
        Url: string option
        /// The configuration token of a verification flow from the dashboard.
        VerificationFlow: string option
        /// The user’s verified data.
        VerifiedOutputs: GelatoVerifiedOutputs option
    }

type IdentityVerificationSession with
    static member New(clientReferenceId: string option, clientSecret: string option, created: DateTime, id: string, lastError: GelatoSessionLastError option, lastVerificationReport: StripeId<Markers.IdentityVerificationReport> option, livemode: bool, metadata: Map<string, string>, options: GelatoVerificationSessionOptions option, redaction: VerificationSessionRedaction option, relatedCustomer: string option, relatedCustomerAccount: string option, status: IdentityVerificationSessionStatus, ``type``: IdentityVerificationSessionType, url: string option, ?providedDetails: GelatoProvidedDetails option, ?relatedPerson: GelatoRelatedPerson, ?verificationFlow: string, ?verifiedOutputs: GelatoVerifiedOutputs option) =
        {
            ClientReferenceId = clientReferenceId
            ClientSecret = clientSecret
            Created = created
            Id = id
            LastError = lastError
            LastVerificationReport = lastVerificationReport
            Livemode = livemode
            Metadata = metadata
            Options = options
            Redaction = redaction
            RelatedCustomer = relatedCustomer
            RelatedCustomerAccount = relatedCustomerAccount
            Status = status
            Type = ``type``
            Url = url
            ProvidedDetails = providedDetails |> Option.flatten
            RelatedPerson = relatedPerson
            VerificationFlow = verificationFlow
            VerifiedOutputs = verifiedOutputs |> Option.flatten
        }

module IdentityVerificationSession =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "identity.verification_session"

/// Occurs whenever a VerificationSession is canceled
type IdentityVerificationSessionCanceled = { Object: IdentityVerificationSession }

type IdentityVerificationSessionCanceled with
    static member New(object: IdentityVerificationSession) =
        {
            Object = object
        }

/// Occurs whenever a VerificationSession is created
type IdentityVerificationSessionCreated = { Object: IdentityVerificationSession }

type IdentityVerificationSessionCreated with
    static member New(object: IdentityVerificationSession) =
        {
            Object = object
        }

/// Occurs whenever a VerificationSession transitions to processing
type IdentityVerificationSessionProcessing = { Object: IdentityVerificationSession }

type IdentityVerificationSessionProcessing with
    static member New(object: IdentityVerificationSession) =
        {
            Object = object
        }

/// Occurs whenever a VerificationSession is redacted.
type IdentityVerificationSessionRedacted = { Object: IdentityVerificationSession }

type IdentityVerificationSessionRedacted with
    static member New(object: IdentityVerificationSession) =
        {
            Object = object
        }

/// Occurs whenever a VerificationSession transitions to require user input
type IdentityVerificationSessionRequiresInput = { Object: IdentityVerificationSession }

type IdentityVerificationSessionRequiresInput with
    static member New(object: IdentityVerificationSession) =
        {
            Object = object
        }

/// Occurs whenever a VerificationSession transitions to verified
type IdentityVerificationSessionVerified = { Object: IdentityVerificationSession }

type IdentityVerificationSessionVerified with
    static member New(object: IdentityVerificationSession) =
        {
            Object = object
        }

