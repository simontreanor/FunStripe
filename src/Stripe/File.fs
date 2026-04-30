namespace Stripe.File

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type FilePurpose =
    | AccountRequirement
    | AdditionalVerification
    | BusinessIcon
    | BusinessLogo
    | CustomerSignature
    | DisputeEvidence
    | DocumentProviderIdentityDocument
    | FinanceReportRun
    | FinancialAccountStatement
    | IdentityDocument
    | IdentityDocumentDownloadable
    | IssuingRegulatoryReporting
    | PciDocument
    | PlatformTermsOfService
    | Selfie
    | SigmaScheduledQuery
    | TaxDocumentUserUpload
    | TerminalAndroidApk
    | TerminalReaderSplashscreen
    | TerminalWifiCertificate
    | TerminalWifiPrivateKey

/// This object represents files hosted on Stripe's servers. You can upload
/// files with the [create file](https://api.stripe.com#create_file) request
/// (for example, when uploading dispute evidence). Stripe also
/// creates files independently (for example, the results of a [Sigma scheduled
/// query](#scheduled_queries)).
/// Related guide: [File upload guide](https://docs.stripe.com/file-upload)
type File =
    {
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// The file expires and isn't available at this time in epoch seconds.
        ExpiresAt: DateTime option
        /// The suitable name for saving the file to a filesystem.
        Filename: string option
        /// Unique identifier for the object.
        Id: string
        /// A list of [file links](https://api.stripe.com#file_links) that point at this file.
        Links: FileLinks option
        /// The [purpose](https://docs.stripe.com/file-upload#uploading-a-file) of the uploaded file.
        Purpose: FilePurpose
        /// The size of the file object in bytes.
        Size: int
        /// A suitable title for the document.
        Title: string option
        /// The returned file type (for example, `csv`, `pdf`, `jpg`, or `png`).
        Type: string option
        /// Use your live secret API key to download the file from this URL.
        Url: string option
    }

/// A list of [file links](https://api.stripe.com#file_links) that point at this file.
and FileLinks =
    {
        /// Details about each object.
        Data: FileLink list
        /// True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        /// The URL where this list can be accessed.
        Url: string
    }

/// To share the contents of a `File` object with non-Stripe users, you can
/// create a `FileLink`. `FileLink`s contain a URL that you can use to
/// retrieve the contents of the file without authentication.
and FileLink =
    {
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Returns if the link is already expired.
        Expired: bool
        /// Time that the link expires.
        ExpiresAt: DateTime option
        /// The file object this link points to.
        File: FileLinkFile'AnyOf
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        /// The publicly accessible URL to download the file.
        Url: string option
    }

and FileLinkFile'AnyOf =
    | String of string
    | File of File

/// Occurs whenever a new Stripe-generated file is available for your account.
type FileCreated = { Object: File }

module File =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "file"

    let create
        (
            created: DateTime,
            expiresAt: DateTime option,
            filename: string option,
            id: string,
            purpose: FilePurpose,
            size: int,
            title: string option,
            ``type``: string option,
            url: string option,
            links: FileLinks option option
        ) : File
        =
        {
          Created = created
          ExpiresAt = expiresAt
          Filename = filename
          Id = id
          Purpose = purpose
          Size = size
          Title = title
          Type = ``type``
          Url = url
          Links = links |> Option.flatten
        }

module FileLinks =
    ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
    let object = "list"

    let create
        (
            data: FileLink list,
            hasMore: bool,
            url: string
        ) : FileLinks
        =
        {
          Data = data
          HasMore = hasMore
          Url = url
        }

module FileLink =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "file_link"

    let create
        (
            created: DateTime,
            expired: bool,
            expiresAt: DateTime option,
            file: FileLinkFile'AnyOf,
            id: string,
            livemode: bool,
            metadata: Map<string, string>,
            url: string option
        ) : FileLink
        =
        {
          Created = created
          Expired = expired
          ExpiresAt = expiresAt
          File = file
          Id = id
          Livemode = livemode
          Metadata = metadata
          Url = url
        }

module FileCreated =
    let create
        (
            object: File
        ) : FileCreated
        =
        {
          Object = object
        }

