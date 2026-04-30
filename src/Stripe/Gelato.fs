namespace Stripe.Gelato

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type GelatoSessionPhoneOptions =
    {
        /// Request one time password verification of `provided_details.phone`.
        RequireVerification: bool option
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

type GelatoSessionIdNumberOptions =
    { GelatoSessionIdNumberOptions: string option }

type GelatoSessionEmailOptions =
    {
        /// Request one time password verification of `provided_details.email`.
        RequireVerification: bool option
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

type GelatoReportIdNumberOptions =
    { GelatoReportIdNumberOptions: string option }

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
type GelatoDataDocumentReportDateOfBirth =
    {
        /// Numerical day between 1 and 31.
        Day: int option
        /// Numerical month between 1 and 12.
        Month: int option
        /// The four-digit year.
        Year: int option
    }

