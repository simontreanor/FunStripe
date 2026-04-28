namespace FunStripe.StripeRequest

open FunStripe
open FunStripe.Json
open FunStripe.StripeModel
open System

module IdentityVerificationReports =

    type ListOptions = {
        [<Config.Query>]Created: int option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///Only return VerificationReports of this type
        [<Config.Query>]Type: string option
        ///Only return VerificationReports created by this VerificationSession ID. It is allowed to provide a VerificationIntent ID.
        [<Config.Query>]VerificationSession: string option
    }
    with
        static member New(?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?type': string, ?verificationSession: string) =
            {
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Type = type'
                VerificationSession = verificationSession
            }

    ///<p>List all verification reports.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("type", options.Type |> box); ("verification_session", options.VerificationSession |> box)] |> Map.ofList
        $"/v1/identity/verification_reports"
        |> RestApi.getAsync<IdentityVerificationReport list> settings qs

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Report: string
    }
    with
        static member New(report: string, ?expand: string list) =
            {
                Expand = expand
                Report = report
            }

    ///<p>Retrieves an existing VerificationReport</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/identity/verification_reports/{options.Report}"
        |> RestApi.getAsync<IdentityVerificationReport> settings qs

module IdentityVerificationSessions =

    type ListOptions = {
        [<Config.Query>]Created: int option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///Only return VerificationSessions with this status. [Learn more about the lifecycle of sessions](https://stripe.com/docs/identity/how-sessions-work).
        [<Config.Query>]Status: string option
    }
    with
        static member New(?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
            {
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Status = status
            }

    ///<p>Returns a list of VerificationSessions</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/identity/verification_sessions"
        |> RestApi.getAsync<IdentityVerificationSession list> settings qs

    type Create'OptionsDocumentDocumentOptionsAllowedTypes =
    | DrivingLicense
    | IdCard
    | Passport

    type Create'OptionsDocumentDocumentOptions = {
        ///Array of strings of allowed identity document types. If the provided identity document isn’t one of the allowed types, the verification check will fail with a document_type_not_allowed error code.
        [<Config.Form>]AllowedTypes: Create'OptionsDocumentDocumentOptionsAllowedTypes list option
        ///Collect an ID number and perform an [ID number check](https://stripe.com/docs/identity/verification-checks?type=id-number) with the document’s extracted name and date of birth.
        [<Config.Form>]RequireIdNumber: bool option
        ///Disable image uploads, identity document images have to be captured using the device’s camera.
        [<Config.Form>]RequireLiveCapture: bool option
        ///Capture a face image and perform a [selfie check](https://stripe.com/docs/identity/verification-checks?type=selfie) comparing a photo ID and a picture of your user’s face. [Learn more](https://stripe.com/docs/identity/selfie).
        [<Config.Form>]RequireMatchingSelfie: bool option
    }
    with
        static member New(?allowedTypes: Create'OptionsDocumentDocumentOptionsAllowedTypes list, ?requireIdNumber: bool, ?requireLiveCapture: bool, ?requireMatchingSelfie: bool) =
            {
                AllowedTypes = allowedTypes
                RequireIdNumber = requireIdNumber
                RequireLiveCapture = requireLiveCapture
                RequireMatchingSelfie = requireMatchingSelfie
            }

    type Create'Options = {
        ///Options that apply to the [document check](https://stripe.com/docs/identity/verification-checks?type=document).
        [<Config.Form>]Document: Choice<Create'OptionsDocumentDocumentOptions,string> option
    }
    with
        static member New(?document: Choice<Create'OptionsDocumentDocumentOptions,string>) =
            {
                Document = document
            }

    type Create'Type =
    | Document
    | IdNumber

    type CreateOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///A set of options for the session’s verification checks.
        [<Config.Form>]Options: Create'Options option
        ///The URL that the user will be redirected to upon completing the verification flow.
        [<Config.Form>]ReturnUrl: string option
        ///The type of [verification check](https://stripe.com/docs/identity/verification-checks) to be performed.
        [<Config.Form>]Type: Create'Type
    }
    with
        static member New(type': Create'Type, ?expand: string list, ?metadata: Map<string, string>, ?options: Create'Options, ?returnUrl: string) =
            {
                Expand = expand
                Metadata = metadata
                Options = options
                ReturnUrl = returnUrl
                Type = type'
            }

    ///<p>Creates a VerificationSession object.
    ///After the VerificationSession is created, display a verification modal using the session <code>client_secret</code> or send your users to the session’s <code>url</code>.
    ///If your API key is in test mode, verification checks won’t actually process, though everything else will occur as if in live mode.
    ///Related guide: <a href="/docs/identity/verify-identity-documents">Verify your users’ identity documents</a></p>
    let Create settings (options: CreateOptions) =
        $"/v1/identity/verification_sessions"
        |> RestApi.postAsync<_, IdentityVerificationSession> settings (Map.empty) options

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Session: string
    }
    with
        static member New(session: string, ?expand: string list) =
            {
                Expand = expand
                Session = session
            }

    ///<p>Retrieves the details of a VerificationSession that was previously created.
    ///When the session status is <code>requires_input</code>, you can use this method to retrieve a valid
    ///<code>client_secret</code> or <code>url</code> to allow re-submission.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/identity/verification_sessions/{options.Session}"
        |> RestApi.getAsync<IdentityVerificationSession> settings qs

    type Update'OptionsDocumentDocumentOptionsAllowedTypes =
    | DrivingLicense
    | IdCard
    | Passport

    type Update'OptionsDocumentDocumentOptions = {
        ///Array of strings of allowed identity document types. If the provided identity document isn’t one of the allowed types, the verification check will fail with a document_type_not_allowed error code.
        [<Config.Form>]AllowedTypes: Update'OptionsDocumentDocumentOptionsAllowedTypes list option
        ///Collect an ID number and perform an [ID number check](https://stripe.com/docs/identity/verification-checks?type=id-number) with the document’s extracted name and date of birth.
        [<Config.Form>]RequireIdNumber: bool option
        ///Disable image uploads, identity document images have to be captured using the device’s camera.
        [<Config.Form>]RequireLiveCapture: bool option
        ///Capture a face image and perform a [selfie check](https://stripe.com/docs/identity/verification-checks?type=selfie) comparing a photo ID and a picture of your user’s face. [Learn more](https://stripe.com/docs/identity/selfie).
        [<Config.Form>]RequireMatchingSelfie: bool option
    }
    with
        static member New(?allowedTypes: Update'OptionsDocumentDocumentOptionsAllowedTypes list, ?requireIdNumber: bool, ?requireLiveCapture: bool, ?requireMatchingSelfie: bool) =
            {
                AllowedTypes = allowedTypes
                RequireIdNumber = requireIdNumber
                RequireLiveCapture = requireLiveCapture
                RequireMatchingSelfie = requireMatchingSelfie
            }

    type Update'Options = {
        ///Options that apply to the [document check](https://stripe.com/docs/identity/verification-checks?type=document).
        [<Config.Form>]Document: Choice<Update'OptionsDocumentDocumentOptions,string> option
    }
    with
        static member New(?document: Choice<Update'OptionsDocumentDocumentOptions,string>) =
            {
                Document = document
            }

    type Update'Type =
    | Document
    | IdNumber

    type UpdateOptions = {
        [<Config.Path>]Session: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///A set of options for the session’s verification checks.
        [<Config.Form>]Options: Update'Options option
        ///The type of [verification check](https://stripe.com/docs/identity/verification-checks) to be performed.
        [<Config.Form>]Type: Update'Type option
    }
    with
        static member New(session: string, ?expand: string list, ?metadata: Map<string, string>, ?options: Update'Options, ?type': Update'Type) =
            {
                Session = session
                Expand = expand
                Metadata = metadata
                Options = options
                Type = type'
            }

    ///<p>Updates a VerificationSession object.
    ///When the session status is <code>requires_input</code>, you can use this method to update the
    ///verification check and options.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/identity/verification_sessions/{options.Session}"
        |> RestApi.postAsync<_, IdentityVerificationSession> settings (Map.empty) options

module IdentityVerificationSessionsCancel =

    type CancelOptions = {
        [<Config.Path>]Session: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(session: string, ?expand: string list) =
            {
                Session = session
                Expand = expand
            }

    ///<p>A VerificationSession object can be canceled when it is in <code>requires_input</code> <a href="/docs/identity/how-sessions-work">status</a>.
    ///Once canceled, future submission attempts are disabled. This cannot be undone. <a href="/docs/identity/verification-sessions#cancel">Learn more</a>.</p>
    let Cancel settings (options: CancelOptions) =
        $"/v1/identity/verification_sessions/{options.Session}/cancel"
        |> RestApi.postAsync<_, IdentityVerificationSession> settings (Map.empty) options

module IdentityVerificationSessionsRedact =

    type RedactOptions = {
        [<Config.Path>]Session: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(session: string, ?expand: string list) =
            {
                Session = session
                Expand = expand
            }

    ///<p>Redact a VerificationSession to remove all collected information from Stripe. This will redact
    ///the VerificationSession and all objects related to it, including VerificationReports, Events,
    ///request logs, etc.
    ///A VerificationSession object can be redacted when it is in <code>requires_input</code> or <code>verified</code>
    ///<a href="/docs/identity/how-sessions-work">status</a>. Redacting a VerificationSession in <code>requires_action</code>
    ///state will automatically cancel it.
    ///The redaction process may take up to four days. When the redaction process is in progress, the
    ///VerificationSession’s <code>redaction.status</code> field will be set to <code>processing</code>; when the process is
    ///finished, it will change to <code>redacted</code> and an <code>identity.verification_session.redacted</code> event
    ///will be emitted.
    ///Redaction is irreversible. Redacted objects are still accessible in the Stripe API, but all the
    ///fields that contain personal data will be replaced by the string <code>[redacted]</code> or a similar
    ///placeholder. The <code>metadata</code> field will also be erased. Redacted objects cannot be updated or
    ///used for any purpose.
    ///<a href="/docs/identity/verification-sessions#redact">Learn more</a>.</p>
    let Redact settings (options: RedactOptions) =
        $"/v1/identity/verification_sessions/{options.Session}/redact"
        |> RestApi.postAsync<_, IdentityVerificationSession> settings (Map.empty) options
