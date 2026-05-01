namespace StripeRequest.Files

open FunStripe
open System.Text.Json.Serialization
open Stripe.File
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
module Files =

    type ListOptions =
        {
            /// Only return files that were created during the given date interval.
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
            /// Filter queries by the file purpose. If you don't provide a purpose, the queries return unfiltered files.
            [<Config.Query>]
            Purpose: string option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    type ListOptions with
        static member New(?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?purpose: string, ?startingAfter: string) =
            {
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Purpose = purpose
                StartingAfter = startingAfter
            }

    type Create'FileLinkData =
        {
            /// Set this to `true` to create a file link for the newly created file. Creating a link is only possible when the file's `purpose` is one of the following: `business_icon`, `business_logo`, `customer_signature`, `dispute_evidence`, `issuing_regulatory_reporting`, `pci_document`, `tax_document_user_upload`, `terminal_android_apk`, or `terminal_reader_splashscreen`.
            [<Config.Form>]
            Create: bool option
            /// The link isn't available after this future timestamp.
            [<Config.Form>]
            ExpiresAt: DateTime option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
        }

    type Create'FileLinkData with
        static member New(?create: bool, ?expiresAt: DateTime, ?metadata: Map<string, string>) =
            {
                Create = create
                ExpiresAt = expiresAt
                Metadata = metadata
            }

    type Create'Purpose =
        | AccountRequirement
        | AdditionalVerification
        | BusinessIcon
        | BusinessLogo
        | CustomerSignature
        | DisputeEvidence
        | IdentityDocument
        | IssuingRegulatoryReporting
        | PciDocument
        | PlatformTermsOfService
        | TaxDocumentUserUpload
        | TerminalAndroidApk
        | TerminalReaderSplashscreen
        | TerminalWifiCertificate
        | TerminalWifiPrivateKey

    type CreateOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// A file to upload. Make sure that the specifications follow RFC 2388, which defines file transfers for the `multipart/form-data` protocol.
            [<Config.Form>]
            File: string
            /// Optional parameters that automatically create a [file link](https://api.stripe.com#file_links) for the newly created file.
            [<Config.Form>]
            FileLinkData: Create'FileLinkData option
            /// The [purpose](https://docs.stripe.com/file-upload#uploading-a-file) of the uploaded file.
            [<Config.Form>]
            Purpose: Create'Purpose
        }

    type CreateOptions with
        static member New(file: string, purpose: Create'Purpose, ?expand: string list, ?fileLinkData: Create'FileLinkData) =
            {
                File = file
                Purpose = purpose
                Expand = expand
                FileLinkData = fileLinkData
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            File: string
        }

    type RetrieveOptions with
        static member New(file: string, ?expand: string list) =
            {
                File = file
                Expand = expand
            }

    ///<p>Returns a list of the files that your account has access to. Stripe sorts and returns the files by their creation dates, placing the most recently created files at the top.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("purpose", options.Purpose |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/files"
        |> RestApi.getAsync<StripeList<File>> settings qs

    ///<p>To upload a file to Stripe, you need to send a request of type <code>multipart/form-data</code>. Include the file you want to upload in the request, and the parameters for creating a file.</p>
    ///<p>All of Stripe’s officially supported Client libraries support sending <code>multipart/form-data</code>.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/files"
        |> RestApi.postAsync<_, File> settings (Map.empty) options

    ///<p>Retrieves the details of an existing file object. After you supply a unique file ID, Stripe returns the corresponding file object. Learn how to <a href="/docs/file-upload#download-file-contents">access file contents</a>.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/files/{options.File}"
        |> RestApi.getAsync<File> settings qs

