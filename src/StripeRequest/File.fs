namespace StripeRequest.File

open FunStripe
open System.Text.Json.Serialization
open Stripe.File
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module FileLinks =

    type ListOptions =
        {
            /// Only return links that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// Filter links by their expiration status. By default, Stripe returns all links.
            [<Config.Query>]
            Expired: bool option
            /// Only return links for the given file.
            [<Config.Query>]
            File: string option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    module ListOptions =
        let create
            (
                created: int option,
                endingBefore: string option,
                expand: string list option,
                expired: bool option,
                file: string option,
                limit: int option,
                startingAfter: string option
            ) : ListOptions
            =
            {
              Created = created
              EndingBefore = endingBefore
              Expand = expand
              Expired = expired
              File = file
              Limit = limit
              StartingAfter = startingAfter
            }

    type CreateOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The link isn't usable after this future timestamp.
            [<Config.Form>]
            ExpiresAt: DateTime option
            /// The ID of the file. The file's `purpose` must be one of the following: `business_icon`, `business_logo`, `customer_signature`, `dispute_evidence`, `finance_report_run`, `financial_account_statement`, `identity_document_downloadable`, `issuing_regulatory_reporting`, `pci_document`, `selfie`, `sigma_scheduled_query`, `tax_document_user_upload`, `terminal_android_apk`, or `terminal_reader_splashscreen`.
            [<Config.Form>]
            File: string
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
        }

    module CreateOptions =
        let create
            (
                file: string
            ) : CreateOptions
            =
            {
              File = file
              Expand = None
              ExpiresAt = None
              Metadata = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Link: string
        }

    module RetrieveOptions =
        let create
            (
                link: string
            ) : RetrieveOptions
            =
            {
              Link = link
              Expand = None
            }

    type Update'ExpiresAt = | Now

    type UpdateOptions =
        {
            [<Config.Path>]
            Link: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// A future timestamp after which the link will no longer be usable, or `now` to expire the link immediately.
            [<Config.Form>]
            ExpiresAt: Choice<Update'ExpiresAt,DateTime,string> option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
        }

    module UpdateOptions =
        let create
            (
                link: string
            ) : UpdateOptions
            =
            {
              Link = link
              Expand = None
              ExpiresAt = None
              Metadata = None
            }

    ///<p>Returns a list of file links.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("expired", options.Expired |> box); ("file", options.File |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/file_links"
        |> RestApi.getAsync<StripeList<FileLink>> settings qs

    ///<p>Creates a new file link object.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/file_links"
        |> RestApi.postAsync<_, FileLink> settings (Map.empty) options

    ///<p>Retrieves the file link with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/file_links/{options.Link}"
        |> RestApi.getAsync<FileLink> settings qs

    ///<p>Updates an existing file link object. Expired links can no longer be updated.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/file_links/{options.Link}"
        |> RestApi.postAsync<_, FileLink> settings (Map.empty) options

