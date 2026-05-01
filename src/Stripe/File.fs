namespace Stripe.File

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.FileLink

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
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

type File with
    static member New(created: DateTime, expiresAt: DateTime option, filename: string option, id: string, purpose: FilePurpose, size: int, title: string option, ``type``: string option, url: string option, ?links: FileLinks option) =
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

module File =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "file"

/// Occurs whenever a new Stripe-generated file is available for your account.
type FileCreated = { Object: File }

type FileCreated with
    static member New(object: File) =
        {
            Object = object
        }

