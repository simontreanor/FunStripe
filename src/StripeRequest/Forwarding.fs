namespace StripeRequest.Forwarding

open FunStripe
open System.Text.Json.Serialization
open Stripe.Forwarding
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module ForwardingRequests =

    type ListOptions =
        {
            /// Similar to other List endpoints, filters results based on created timestamp. You can pass gt, gte, lt, and lte timestamp values.
            [<Config.Query>]
            Created: Map<string, string> option
            /// A pagination cursor to fetch the previous page of the list. The value must be a ForwardingRequest ID.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A pagination cursor to fetch the next page of the list. The value must be a ForwardingRequest ID.
            [<Config.Query>]
            StartingAfter: string option
        }

    module ListOptions =
        let create
            (
                created: Map<string, string> option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option
            ) : ListOptions
            =
            {
              Created = created
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
            }

    type Create'Replacements =
        | CardCvc
        | CardExpiry
        | CardNumber
        | CardholderName
        | RequestSignature

    type Create'RequestHeaders =
        {
            /// The header name.
            [<Config.Form>]
            Name: string option
            /// The header value.
            [<Config.Form>]
            Value: string option
        }

    module Create'RequestHeaders =
        let create
            (
                name: string option,
                value: string option
            ) : Create'RequestHeaders
            =
            {
              Name = name
              Value = value
            }

    type Create'Request =
        {
            /// The body payload to send to the destination endpoint.
            [<Config.Form>]
            Body: string option
            /// The headers to include in the forwarded request. Can be omitted if no additional headers (excluding Stripe-generated ones such as the Content-Type header) should be included.
            [<Config.Form>]
            Headers: Create'RequestHeaders list option
        }

    module Create'Request =
        let create
            (
                body: string option,
                headers: Create'RequestHeaders list option
            ) : Create'Request
            =
            {
              Body = body
              Headers = headers
            }

    type CreateOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The PaymentMethod to insert into the forwarded request. Forwarding previously consumed PaymentMethods is allowed.
            [<Config.Form>]
            PaymentMethod: string
            /// The field kinds to be replaced in the forwarded request.
            [<Config.Form>]
            Replacements: Create'Replacements list
            /// The request body and headers to be sent to the destination endpoint.
            [<Config.Form>]
            Request: Create'Request option
            /// The destination URL for the forwarded request. Must be supported by the config.
            [<Config.Form>]
            Url: string
        }

    module CreateOptions =
        let create
            (
                paymentMethod: string,
                replacements: Create'Replacements list,
                url: string
            ) : CreateOptions
            =
            {
              PaymentMethod = paymentMethod
              Replacements = replacements
              Url = url
              Expand = None
              Metadata = None
              Request = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Id: string
        }

    module RetrieveOptions =
        let create
            (
                id: string
            ) : RetrieveOptions
            =
            {
              Id = id
              Expand = None
            }

    ///<p>Lists all ForwardingRequest objects.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/forwarding/requests"
        |> RestApi.getAsync<StripeList<ForwardingRequest>> settings qs

    ///<p>Creates a ForwardingRequest object.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/forwarding/requests"
        |> RestApi.postAsync<_, ForwardingRequest> settings (Map.empty) options

    ///<p>Retrieves a ForwardingRequest object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/forwarding/requests/{options.Id}"
        |> RestApi.getAsync<ForwardingRequest> settings qs

