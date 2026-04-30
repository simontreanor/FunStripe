namespace Stripe.Identity

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Gelato
open Stripe.Verification

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
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

module IdentityVerificationReport =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "identity.verification_report"

type IdentityVerificationSessionLastVerificationReport'AnyOf =
    | String of string
    | IdentityVerificationReport of IdentityVerificationReport

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
        LastVerificationReport: IdentityVerificationSessionLastVerificationReport'AnyOf option
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

module IdentityVerificationSession =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "identity.verification_session"

/// Occurs whenever a VerificationSession transitions to verified
type IdentityVerificationSessionVerified = { Object: IdentityVerificationSession }

/// Occurs whenever a VerificationSession transitions to require user input
type IdentityVerificationSessionRequiresInput = { Object: IdentityVerificationSession }

/// Occurs whenever a VerificationSession is redacted.
type IdentityVerificationSessionRedacted = { Object: IdentityVerificationSession }

/// Occurs whenever a VerificationSession transitions to processing
type IdentityVerificationSessionProcessing = { Object: IdentityVerificationSession }

/// Occurs whenever a VerificationSession is created
type IdentityVerificationSessionCreated = { Object: IdentityVerificationSession }

/// Occurs whenever a VerificationSession is canceled
type IdentityVerificationSessionCanceled = { Object: IdentityVerificationSession }

