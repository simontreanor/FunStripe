namespace Stripe.FileLink

open System.Text.Json.Serialization
open FunStripe
open System

/// To share the contents of a `File` object with non-Stripe users, you can
/// create a `FileLink`. `FileLink`s contain a URL that you can use to
/// retrieve the contents of the file without authentication.
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
type FileLink =
    {
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Returns if the link is already expired.
        Expired: bool
        /// Time that the link expires.
        ExpiresAt: DateTime option
        /// The file object this link points to.
        File: StripeId<Markers.File>
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        /// The publicly accessible URL to download the file.
        Url: string option
    }

type FileLink with
    static member New(created: DateTime, expired: bool, expiresAt: DateTime option, file: StripeId<Markers.File>, id: string, livemode: bool, metadata: Map<string, string>, url: string option) =
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

module FileLink =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "file_link"

/// A list of [file links](https://api.stripe.com#file_links) that point at this file.
type FileLinks =
    {
        /// Details about each object.
        Data: FileLink list
        /// True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        /// The URL where this list can be accessed.
        Url: string
    }

type FileLinks with
    static member New(data: FileLink list, hasMore: bool, url: string) =
        {
            Data = data
            HasMore = hasMore
            Url = url
        }

module FileLinks =
    ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
    let object = "list"

