namespace StripeRequest.Identity

open FunStripe
open System.Text.Json.Serialization
open Stripe.Identity
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
module IdentityVerificationReports =

    type ListOptions =
        {
            /// A string to reference this user. This can be a customer ID, a session ID, or similar, and can be used to reconcile this verification with your internal systems.
            [<Config.Query>]
            ClientReferenceId: string option
            /// Only return VerificationReports that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Only return VerificationReports of this type
            [<Config.Query>]
            Type: string option
            /// Only return VerificationReports created by this VerificationSession ID. It is allowed to provide a VerificationIntent ID.
            [<Config.Query>]
            VerificationSession: string option
        }

    module ListOptions =
        let create
            (
                clientReferenceId: string option,
                created: int option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option,
                ``type``: string option,
                verificationSession: string option
            ) : ListOptions
            =
            {
              ClientReferenceId = clientReferenceId
              Created = created
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
              Type = ``type``
              VerificationSession = verificationSession
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Report: string
        }

    module RetrieveOptions =
        let create
            (
                report: string
            ) : RetrieveOptions
            =
            {
              Report = report
              Expand = None
            }

    ///<p>List all verification reports.</p>
    let List settings (options: ListOptions) =
        let qs = [("client_reference_id", options.ClientReferenceId |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("type", options.Type |> box); ("verification_session", options.VerificationSession |> box)] |> Map.ofList
        $"/v1/identity/verification_reports"
        |> RestApi.getAsync<StripeList<IdentityVerificationReport>> settings qs

    ///<p>Retrieves an existing VerificationReport</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/identity/verification_reports/{options.Report}"
        |> RestApi.getAsync<IdentityVerificationReport> settings qs

module IdentityVerificationSessions =

    type ListOptions =
        {
            /// A string to reference this user. This can be a customer ID, a session ID, or similar, and can be used to reconcile this verification with your internal systems.
            [<Config.Query>]
            ClientReferenceId: string option
            /// Only return VerificationSessions that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// Customer ID
            [<Config.Query>]
            RelatedCustomer: string option
            /// The ID of the Account representing a customer.
            [<Config.Query>]
            RelatedCustomerAccount: string option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Only return VerificationSessions with this status. [Learn more about the lifecycle of sessions](https://docs.stripe.com/identity/how-sessions-work).
            [<Config.Query>]
            Status: string option
        }

    module ListOptions =
        let create
            (
                clientReferenceId: string option,
                created: int option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                relatedCustomer: string option,
                relatedCustomerAccount: string option,
                startingAfter: string option,
                status: string option
            ) : ListOptions
            =
            {
              ClientReferenceId = clientReferenceId
              Created = created
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              RelatedCustomer = relatedCustomer
              RelatedCustomerAccount = relatedCustomerAccount
              StartingAfter = startingAfter
              Status = status
            }

    type Create'OptionsDocumentDocumentOptionsAllowedTypes =
        | DrivingLicense
        | IdCard
        | Passport

    type Create'OptionsDocumentDocumentOptions =
        {
            /// Array of strings of allowed identity document types. If the provided identity document isn’t one of the allowed types, the verification check will fail with a document_type_not_allowed error code.
            [<Config.Form>]
            AllowedTypes: Create'OptionsDocumentDocumentOptionsAllowedTypes list option
            /// Collect an ID number and perform an [ID number check](https://docs.stripe.com/identity/verification-checks?type=id-number) with the document’s extracted name and date of birth.
            [<Config.Form>]
            RequireIdNumber: bool option
            /// Disable image uploads, identity document images have to be captured using the device’s camera.
            [<Config.Form>]
            RequireLiveCapture: bool option
            /// Capture a face image and perform a [selfie check](https://docs.stripe.com/identity/verification-checks?type=selfie) comparing a photo ID and a picture of your user’s face. [Learn more](https://docs.stripe.com/identity/selfie).
            [<Config.Form>]
            RequireMatchingSelfie: bool option
        }

    module Create'OptionsDocumentDocumentOptions =
        let create
            (
                allowedTypes: Create'OptionsDocumentDocumentOptionsAllowedTypes list option,
                requireIdNumber: bool option,
                requireLiveCapture: bool option,
                requireMatchingSelfie: bool option
            ) : Create'OptionsDocumentDocumentOptions
            =
            {
              AllowedTypes = allowedTypes
              RequireIdNumber = requireIdNumber
              RequireLiveCapture = requireLiveCapture
              RequireMatchingSelfie = requireMatchingSelfie
            }

    type Create'Options =
        {
            /// Options that apply to the [document check](https://docs.stripe.com/identity/verification-checks?type=document).
            [<Config.Form>]
            Document: Choice<Create'OptionsDocumentDocumentOptions,string> option
        }

    module Create'Options =
        let create
            (
                document: Choice<Create'OptionsDocumentDocumentOptions,string> option
            ) : Create'Options
            =
            {
              Document = document
            }

    type Create'ProvidedDetails =
        {
            /// Email of user being verified
            [<Config.Form>]
            Email: string option
            /// Phone number of user being verified
            [<Config.Form>]
            Phone: string option
        }

    module Create'ProvidedDetails =
        let create
            (
                email: string option,
                phone: string option
            ) : Create'ProvidedDetails
            =
            {
              Email = email
              Phone = phone
            }

    type Create'RelatedPerson =
        {
            /// A token representing a connected account. If provided, the person parameter is also required and must be associated with the account.
            [<Config.Form>]
            Account: string option
            /// A token referencing a Person resource that this verification is being used to verify.
            [<Config.Form>]
            Person: string option
        }

    module Create'RelatedPerson =
        let create
            (
                account: string option,
                person: string option
            ) : Create'RelatedPerson
            =
            {
              Account = account
              Person = person
            }

    type Create'Type =
        | Document
        | IdNumber

    type CreateOptions =
        {
            /// A string to reference this user. This can be a customer ID, a session ID, or similar, and can be used to reconcile this verification with your internal systems.
            [<Config.Form>]
            ClientReferenceId: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// A set of options for the session’s verification checks.
            [<Config.Form>]
            Options: Create'Options option
            /// Details provided about the user being verified. These details might be shown to the user.
            [<Config.Form>]
            ProvidedDetails: Create'ProvidedDetails option
            /// Customer ID
            [<Config.Form>]
            RelatedCustomer: string option
            /// The ID of the Account representing a customer.
            [<Config.Form>]
            RelatedCustomerAccount: string option
            /// Tokens referencing a Person resource and its associated account.
            [<Config.Form>]
            RelatedPerson: Create'RelatedPerson option
            /// The URL that the user will be redirected to upon completing the verification flow.
            [<Config.Form>]
            ReturnUrl: string option
            /// The type of [verification check](https://docs.stripe.com/identity/verification-checks) to be performed. You must provide a `type` if not passing `verification_flow`.
            [<Config.Form>]
            Type: Create'Type option
            /// The ID of a verification flow from the Dashboard. See https://docs.stripe.com/identity/verification-flows.
            [<Config.Form>]
            VerificationFlow: string option
        }

    module CreateOptions =
        let create
            (
                clientReferenceId: string option,
                expand: string list option,
                metadata: Map<string, string> option,
                options: Create'Options option,
                providedDetails: Create'ProvidedDetails option,
                relatedCustomer: string option,
                relatedCustomerAccount: string option,
                relatedPerson: Create'RelatedPerson option,
                returnUrl: string option,
                ``type``: Create'Type option,
                verificationFlow: string option
            ) : CreateOptions
            =
            {
              ClientReferenceId = clientReferenceId
              Expand = expand
              Metadata = metadata
              Options = options
              ProvidedDetails = providedDetails
              RelatedCustomer = relatedCustomer
              RelatedCustomerAccount = relatedCustomerAccount
              RelatedPerson = relatedPerson
              ReturnUrl = returnUrl
              Type = ``type``
              VerificationFlow = verificationFlow
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Session: string
        }

    module RetrieveOptions =
        let create
            (
                session: string
            ) : RetrieveOptions
            =
            {
              Session = session
              Expand = None
            }

    type Update'OptionsDocumentDocumentOptionsAllowedTypes =
        | DrivingLicense
        | IdCard
        | Passport

    type Update'OptionsDocumentDocumentOptions =
        {
            /// Array of strings of allowed identity document types. If the provided identity document isn’t one of the allowed types, the verification check will fail with a document_type_not_allowed error code.
            [<Config.Form>]
            AllowedTypes: Update'OptionsDocumentDocumentOptionsAllowedTypes list option
            /// Collect an ID number and perform an [ID number check](https://docs.stripe.com/identity/verification-checks?type=id-number) with the document’s extracted name and date of birth.
            [<Config.Form>]
            RequireIdNumber: bool option
            /// Disable image uploads, identity document images have to be captured using the device’s camera.
            [<Config.Form>]
            RequireLiveCapture: bool option
            /// Capture a face image and perform a [selfie check](https://docs.stripe.com/identity/verification-checks?type=selfie) comparing a photo ID and a picture of your user’s face. [Learn more](https://docs.stripe.com/identity/selfie).
            [<Config.Form>]
            RequireMatchingSelfie: bool option
        }

    module Update'OptionsDocumentDocumentOptions =
        let create
            (
                allowedTypes: Update'OptionsDocumentDocumentOptionsAllowedTypes list option,
                requireIdNumber: bool option,
                requireLiveCapture: bool option,
                requireMatchingSelfie: bool option
            ) : Update'OptionsDocumentDocumentOptions
            =
            {
              AllowedTypes = allowedTypes
              RequireIdNumber = requireIdNumber
              RequireLiveCapture = requireLiveCapture
              RequireMatchingSelfie = requireMatchingSelfie
            }

    type Update'Options =
        {
            /// Options that apply to the [document check](https://docs.stripe.com/identity/verification-checks?type=document).
            [<Config.Form>]
            Document: Choice<Update'OptionsDocumentDocumentOptions,string> option
        }

    module Update'Options =
        let create
            (
                document: Choice<Update'OptionsDocumentDocumentOptions,string> option
            ) : Update'Options
            =
            {
              Document = document
            }

    type Update'ProvidedDetails =
        {
            /// Email of user being verified
            [<Config.Form>]
            Email: string option
            /// Phone number of user being verified
            [<Config.Form>]
            Phone: string option
        }

    module Update'ProvidedDetails =
        let create
            (
                email: string option,
                phone: string option
            ) : Update'ProvidedDetails
            =
            {
              Email = email
              Phone = phone
            }

    type Update'Type =
        | Document
        | IdNumber

    type UpdateOptions =
        {
            [<Config.Path>]
            Session: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// A set of options for the session’s verification checks.
            [<Config.Form>]
            Options: Update'Options option
            /// Details provided about the user being verified. These details may be shown to the user.
            [<Config.Form>]
            ProvidedDetails: Update'ProvidedDetails option
            /// The type of [verification check](https://docs.stripe.com/identity/verification-checks) to be performed.
            [<Config.Form>]
            Type: Update'Type option
        }

    module UpdateOptions =
        let create
            (
                session: string
            ) : UpdateOptions
            =
            {
              Session = session
              Expand = None
              Metadata = None
              Options = None
              ProvidedDetails = None
              Type = None
            }

    ///<p>Returns a list of VerificationSessions</p>
    let List settings (options: ListOptions) =
        let qs = [("client_reference_id", options.ClientReferenceId |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("related_customer", options.RelatedCustomer |> box); ("related_customer_account", options.RelatedCustomerAccount |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/identity/verification_sessions"
        |> RestApi.getAsync<StripeList<IdentityVerificationSession>> settings qs

    ///<p>Creates a VerificationSession object.</p>
    ///<p>After the VerificationSession is created, display a verification modal using the session <code>client_secret</code> or send your users to the session’s <code>url</code>.</p>
    ///<p>If your API key is in test mode, verification checks won’t actually process, though everything else will occur as if in live mode.</p>
    ///<p>Related guide: <a href="/docs/identity/verify-identity-documents">Verify your users’ identity documents</a></p>
    let Create settings (options: CreateOptions) =
        $"/v1/identity/verification_sessions"
        |> RestApi.postAsync<_, IdentityVerificationSession> settings (Map.empty) options

    ///<p>Retrieves the details of a VerificationSession that was previously created.</p>
    ///<p>When the session status is <code>requires_input</code>, you can use this method to retrieve a valid
    ///<code>client_secret</code> or <code>url</code> to allow re-submission.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/identity/verification_sessions/{options.Session}"
        |> RestApi.getAsync<IdentityVerificationSession> settings qs

    ///<p>Updates a VerificationSession object.</p>
    ///<p>When the session status is <code>requires_input</code>, you can use this method to update the
    ///verification check and options.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/identity/verification_sessions/{options.Session}"
        |> RestApi.postAsync<_, IdentityVerificationSession> settings (Map.empty) options

module IdentityVerificationSessionsCancel =

    type CancelOptions =
        {
            [<Config.Path>]
            Session: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module CancelOptions =
        let create
            (
                session: string
            ) : CancelOptions
            =
            {
              Session = session
              Expand = None
            }

    ///<p>A VerificationSession object can be canceled when it is in <code>requires_input</code> <a href="/docs/identity/how-sessions-work">status</a>.</p>
    ///<p>Once canceled, future submission attempts are disabled. This cannot be undone. <a href="/docs/identity/verification-sessions#cancel">Learn more</a>.</p>
    let Cancel settings (options: CancelOptions) =
        $"/v1/identity/verification_sessions/{options.Session}/cancel"
        |> RestApi.postAsync<_, IdentityVerificationSession> settings (Map.empty) options

module IdentityVerificationSessionsRedact =

    type RedactOptions =
        {
            [<Config.Path>]
            Session: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module RedactOptions =
        let create
            (
                session: string
            ) : RedactOptions
            =
            {
              Session = session
              Expand = None
            }

    ///<p>Redact a VerificationSession to remove all collected information from Stripe. This will redact
    ///the VerificationSession and all objects related to it, including VerificationReports, Events,
    ///request logs, etc.</p>
    ///<p>A VerificationSession object can be redacted when it is in <code>requires_input</code> or <code>verified</code>
    ///<a href="/docs/identity/how-sessions-work">status</a>. Redacting a VerificationSession in <code>requires_action</code>
    ///state will automatically cancel it.</p>
    ///<p>The redaction process may take up to four days. When the redaction process is in progress, the
    ///VerificationSession’s <code>redaction.status</code> field will be set to <code>processing</code>; when the process is
    ///finished, it will change to <code>redacted</code> and an <code>identity.verification_session.redacted</code> event
    ///will be emitted.</p>
    ///<p>Redaction is irreversible. Redacted objects are still accessible in the Stripe API, but all the
    ///fields that contain personal data will be replaced by the string <code>[redacted]</code> or a similar
    ///placeholder. The <code>metadata</code> field will also be erased. Redacted objects cannot be updated or
    ///used for any purpose.</p>
    ///<p><a href="/docs/identity/verification-sessions#redact">Learn more</a>.</p>
    let Redact settings (options: RedactOptions) =
        $"/v1/identity/verification_sessions/{options.Session}/redact"
        |> RestApi.postAsync<_, IdentityVerificationSession> settings (Map.empty) options

