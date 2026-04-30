namespace FunStripe.StripeRequest

open FunStripe
open System.Text.Json.Serialization
open FunStripe.StripeModel
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
module IdentityVerificationReports =

    type ListOptions = {
        ///<summary>A string to reference this user. This can be a customer ID, a session ID, or similar, and can be used to reconcile this verification with your internal systems.</summary>
        [<Config.Query>]ClientReferenceId: string option
        ///<summary>Only return VerificationReports that were created during the given date interval.</summary>
        [<Config.Query>]Created: int option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Only return VerificationReports of this type</summary>
        [<Config.Query>]Type: string option
        ///<summary>Only return VerificationReports created by this VerificationSession ID. It is allowed to provide a VerificationIntent ID.</summary>
        [<Config.Query>]VerificationSession: string option
    }
    with
        static member New(?clientReferenceId: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?type': string, ?verificationSession: string) =
            {
                ClientReferenceId = clientReferenceId
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Type = type'
                VerificationSession = verificationSession
            }

    ///<summary><p>List all verification reports.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("client_reference_id", options.ClientReferenceId |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("type", options.Type |> box); ("verification_session", options.VerificationSession |> box)] |> Map.ofList
        $"/v1/identity/verification_reports"
        |> RestApi.getAsync<StripeList<IdentityVerificationReport>> settings qs

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Report: string
    }
    with
        static member New(report: string, ?expand: string list) =
            {
                Expand = expand
                Report = report
            }

    ///<summary><p>Retrieves an existing VerificationReport</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/identity/verification_reports/{options.Report}"
        |> RestApi.getAsync<IdentityVerificationReport> settings qs

module IdentityVerificationSessions =

    type ListOptions = {
        ///<summary>A string to reference this user. This can be a customer ID, a session ID, or similar, and can be used to reconcile this verification with your internal systems.</summary>
        [<Config.Query>]ClientReferenceId: string option
        ///<summary>Only return VerificationSessions that were created during the given date interval.</summary>
        [<Config.Query>]Created: int option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>Customer ID</summary>
        [<Config.Query>]RelatedCustomer: string option
        ///<summary>The ID of the Account representing a customer.</summary>
        [<Config.Query>]RelatedCustomerAccount: string option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Only return VerificationSessions with this status. [Learn more about the lifecycle of sessions](https://docs.stripe.com/identity/how-sessions-work).</summary>
        [<Config.Query>]Status: string option
    }
    with
        static member New(?clientReferenceId: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?relatedCustomer: string, ?relatedCustomerAccount: string, ?startingAfter: string, ?status: string) =
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

    ///<summary><p>Returns a list of VerificationSessions</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("client_reference_id", options.ClientReferenceId |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("related_customer", options.RelatedCustomer |> box); ("related_customer_account", options.RelatedCustomerAccount |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/identity/verification_sessions"
        |> RestApi.getAsync<StripeList<IdentityVerificationSession>> settings qs

    type Create'OptionsDocumentDocumentOptionsAllowedTypes =
    | DrivingLicense
    | IdCard
    | Passport

    type Create'OptionsDocumentDocumentOptions = {
        ///<summary>Array of strings of allowed identity document types. If the provided identity document isn’t one of the allowed types, the verification check will fail with a document_type_not_allowed error code.</summary>
        [<Config.Form>]AllowedTypes: Create'OptionsDocumentDocumentOptionsAllowedTypes list option
        ///<summary>Collect an ID number and perform an [ID number check](https://docs.stripe.com/identity/verification-checks?type=id-number) with the document’s extracted name and date of birth.</summary>
        [<Config.Form>]RequireIdNumber: bool option
        ///<summary>Disable image uploads, identity document images have to be captured using the device’s camera.</summary>
        [<Config.Form>]RequireLiveCapture: bool option
        ///<summary>Capture a face image and perform a [selfie check](https://docs.stripe.com/identity/verification-checks?type=selfie) comparing a photo ID and a picture of your user’s face. [Learn more](https://docs.stripe.com/identity/selfie).</summary>
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
        ///<summary>Options that apply to the [document check](https://docs.stripe.com/identity/verification-checks?type=document).</summary>
        [<Config.Form>]Document: Choice<Create'OptionsDocumentDocumentOptions,string> option
    }
    with
        static member New(?document: Choice<Create'OptionsDocumentDocumentOptions,string>) =
            {
                Document = document
            }

    type Create'ProvidedDetails = {
        ///<summary>Email of user being verified</summary>
        [<Config.Form>]Email: string option
        ///<summary>Phone number of user being verified</summary>
        [<Config.Form>]Phone: string option
    }
    with
        static member New(?email: string, ?phone: string) =
            {
                Email = email
                Phone = phone
            }

    type Create'RelatedPerson = {
        ///<summary>A token representing a connected account. If provided, the person parameter is also required and must be associated with the account.</summary>
        [<Config.Form>]Account: string option
        ///<summary>A token referencing a Person resource that this verification is being used to verify.</summary>
        [<Config.Form>]Person: string option
    }
    with
        static member New(?account: string, ?person: string) =
            {
                Account = account
                Person = person
            }

    type Create'Type =
    | Document
    | IdNumber

    type CreateOptions = {
        ///<summary>A string to reference this user. This can be a customer ID, a session ID, or similar, and can be used to reconcile this verification with your internal systems.</summary>
        [<Config.Form>]ClientReferenceId: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>A set of options for the session’s verification checks.</summary>
        [<Config.Form>]Options: Create'Options option
        ///<summary>Details provided about the user being verified. These details might be shown to the user.</summary>
        [<Config.Form>]ProvidedDetails: Create'ProvidedDetails option
        ///<summary>Customer ID</summary>
        [<Config.Form>]RelatedCustomer: string option
        ///<summary>The ID of the Account representing a customer.</summary>
        [<Config.Form>]RelatedCustomerAccount: string option
        ///<summary>Tokens referencing a Person resource and its associated account.</summary>
        [<Config.Form>]RelatedPerson: Create'RelatedPerson option
        ///<summary>The URL that the user will be redirected to upon completing the verification flow.</summary>
        [<Config.Form>]ReturnUrl: string option
        ///<summary>The type of [verification check](https://docs.stripe.com/identity/verification-checks) to be performed. You must provide a `type` if not passing `verification_flow`.</summary>
        [<Config.Form>]Type: Create'Type option
        ///<summary>The ID of a verification flow from the Dashboard. See https://docs.stripe.com/identity/verification-flows.</summary>
        [<Config.Form>]VerificationFlow: string option
    }
    with
        static member New(?clientReferenceId: string, ?expand: string list, ?metadata: Map<string, string>, ?options: Create'Options, ?providedDetails: Create'ProvidedDetails, ?relatedCustomer: string, ?relatedCustomerAccount: string, ?relatedPerson: Create'RelatedPerson, ?returnUrl: string, ?type': Create'Type, ?verificationFlow: string) =
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
                Type = type'
                VerificationFlow = verificationFlow
            }

    ///<summary><p>Creates a VerificationSession object.</p>
    ///<p>After the VerificationSession is created, display a verification modal using the session <code>client_secret</code> or send your users to the session’s <code>url</code>.</p>
    ///<p>If your API key is in test mode, verification checks won’t actually process, though everything else will occur as if in live mode.</p>
    ///<p>Related guide: <a href="/docs/identity/verify-identity-documents">Verify your users’ identity documents</a></p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/identity/verification_sessions"
        |> RestApi.postAsync<_, IdentityVerificationSession> settings (Map.empty) options

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Session: string
    }
    with
        static member New(session: string, ?expand: string list) =
            {
                Expand = expand
                Session = session
            }

    ///<summary><p>Retrieves the details of a VerificationSession that was previously created.</p>
    ///<p>When the session status is <code>requires_input</code>, you can use this method to retrieve a valid
    ///<code>client_secret</code> or <code>url</code> to allow re-submission.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/identity/verification_sessions/{options.Session}"
        |> RestApi.getAsync<IdentityVerificationSession> settings qs

    type Update'OptionsDocumentDocumentOptionsAllowedTypes =
    | DrivingLicense
    | IdCard
    | Passport

    type Update'OptionsDocumentDocumentOptions = {
        ///<summary>Array of strings of allowed identity document types. If the provided identity document isn’t one of the allowed types, the verification check will fail with a document_type_not_allowed error code.</summary>
        [<Config.Form>]AllowedTypes: Update'OptionsDocumentDocumentOptionsAllowedTypes list option
        ///<summary>Collect an ID number and perform an [ID number check](https://docs.stripe.com/identity/verification-checks?type=id-number) with the document’s extracted name and date of birth.</summary>
        [<Config.Form>]RequireIdNumber: bool option
        ///<summary>Disable image uploads, identity document images have to be captured using the device’s camera.</summary>
        [<Config.Form>]RequireLiveCapture: bool option
        ///<summary>Capture a face image and perform a [selfie check](https://docs.stripe.com/identity/verification-checks?type=selfie) comparing a photo ID and a picture of your user’s face. [Learn more](https://docs.stripe.com/identity/selfie).</summary>
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
        ///<summary>Options that apply to the [document check](https://docs.stripe.com/identity/verification-checks?type=document).</summary>
        [<Config.Form>]Document: Choice<Update'OptionsDocumentDocumentOptions,string> option
    }
    with
        static member New(?document: Choice<Update'OptionsDocumentDocumentOptions,string>) =
            {
                Document = document
            }

    type Update'ProvidedDetails = {
        ///<summary>Email of user being verified</summary>
        [<Config.Form>]Email: string option
        ///<summary>Phone number of user being verified</summary>
        [<Config.Form>]Phone: string option
    }
    with
        static member New(?email: string, ?phone: string) =
            {
                Email = email
                Phone = phone
            }

    type Update'Type =
    | Document
    | IdNumber

    type UpdateOptions = {
        [<Config.Path>]Session: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>A set of options for the session’s verification checks.</summary>
        [<Config.Form>]Options: Update'Options option
        ///<summary>Details provided about the user being verified. These details may be shown to the user.</summary>
        [<Config.Form>]ProvidedDetails: Update'ProvidedDetails option
        ///<summary>The type of [verification check](https://docs.stripe.com/identity/verification-checks) to be performed.</summary>
        [<Config.Form>]Type: Update'Type option
    }
    with
        static member New(session: string, ?expand: string list, ?metadata: Map<string, string>, ?options: Update'Options, ?providedDetails: Update'ProvidedDetails, ?type': Update'Type) =
            {
                Session = session
                Expand = expand
                Metadata = metadata
                Options = options
                ProvidedDetails = providedDetails
                Type = type'
            }

    ///<summary><p>Updates a VerificationSession object.</p>
    ///<p>When the session status is <code>requires_input</code>, you can use this method to update the
    ///verification check and options.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/identity/verification_sessions/{options.Session}"
        |> RestApi.postAsync<_, IdentityVerificationSession> settings (Map.empty) options

module IdentityVerificationSessionsCancel =

    type CancelOptions = {
        [<Config.Path>]Session: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(session: string, ?expand: string list) =
            {
                Session = session
                Expand = expand
            }

    ///<summary><p>A VerificationSession object can be canceled when it is in <code>requires_input</code> <a href="/docs/identity/how-sessions-work">status</a>.</p>
    ///<p>Once canceled, future submission attempts are disabled. This cannot be undone. <a href="/docs/identity/verification-sessions#cancel">Learn more</a>.</p></summary>
    let Cancel settings (options: CancelOptions) =
        $"/v1/identity/verification_sessions/{options.Session}/cancel"
        |> RestApi.postAsync<_, IdentityVerificationSession> settings (Map.empty) options

module IdentityVerificationSessionsRedact =

    type RedactOptions = {
        [<Config.Path>]Session: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(session: string, ?expand: string list) =
            {
                Session = session
                Expand = expand
            }

    ///<summary><p>Redact a VerificationSession to remove all collected information from Stripe. This will redact
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
    ///<p><a href="/docs/identity/verification-sessions#redact">Learn more</a>.</p></summary>
    let Redact settings (options: RedactOptions) =
        $"/v1/identity/verification_sessions/{options.Session}/redact"
        |> RestApi.postAsync<_, IdentityVerificationSession> settings (Map.empty) options
