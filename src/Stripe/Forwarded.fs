namespace Stripe.Forwarded

open System.Text.Json.Serialization
open FunStripe
open System

/// Header data.
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type ForwardedRequestHeader =
    {
        /// The header name.
        Name: string
        /// The header value.
        Value: string
    }

module ForwardedRequestHeader =
    let create
        (
            name: string,
            value: string
        ) : ForwardedRequestHeader
        =
        {
          Name = name
          Value = value
        }

/// Details about the response from the destination endpoint.
type ForwardedResponseDetails =
    {
        /// The response body from the destination endpoint to Stripe.
        Body: string
        /// HTTP headers that the destination endpoint returned.
        Headers: ForwardedRequestHeader list
        /// The HTTP status code that the destination endpoint returned.
        Status: int
    }

module ForwardedResponseDetails =
    let create
        (
            body: string,
            headers: ForwardedRequestHeader list,
            status: int
        ) : ForwardedResponseDetails
        =
        {
          Body = body
          Headers = headers
          Status = status
        }

/// Details about the request forwarded to the destination endpoint.
type ForwardedRequestDetails =
    {
        /// The body payload to send to the destination endpoint.
        Body: string
        /// The headers to include in the forwarded request. Can be omitted if no additional headers (excluding Stripe-generated ones such as the Content-Type header) should be included.
        Headers: ForwardedRequestHeader list
    }

module ForwardedRequestDetails =
    ///The HTTP method used to call the destination endpoint.
    let httpMethod = "POST"

    let create
        (
            body: string,
            headers: ForwardedRequestHeader list
        ) : ForwardedRequestDetails
        =
        {
          Body = body
          Headers = headers
        }

/// Metadata about the forwarded request.
type ForwardedRequestContext =
    {
        /// The time it took in milliseconds for the destination endpoint to respond.
        DestinationDuration: int
        /// The IP address of the destination.
        DestinationIpAddress: string
    }

module ForwardedRequestContext =
    let create
        (
            destinationDuration: int,
            destinationIpAddress: string
        ) : ForwardedRequestContext
        =
        {
          DestinationDuration = destinationDuration
          DestinationIpAddress = destinationIpAddress
        }

