namespace Stripe.Forwarding

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Forwarded

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type ForwardingRequestReplacements =
    | CardCvc
    | CardExpiry
    | CardNumber
    | CardholderName
    | RequestSignature

/// Instructs Stripe to make a request on your behalf using the destination URL. The destination URL
/// is activated by Stripe at the time of onboarding. Stripe verifies requests with your credentials
/// provided during onboarding, and injects card details from the payment_method into the request.
/// Stripe redacts all sensitive fields and headers, including authentication credentials and card numbers,
/// before storing the request and response data in the forwarding Request object, which are subject to a
/// 30-day retention period.
/// You can provide a Stripe idempotency key to make sure that requests with the same key result in only one
/// outbound request. The Stripe idempotency key provided should be unique and different from any idempotency
/// keys provided on the underlying third-party request.
/// Forwarding Requests are synchronous requests that return a response or time out according to
/// Stripe’s limits.
/// Related guide: [Forward card details to third-party API endpoints](https://docs.stripe.com/payments/forwarding).
type ForwardingRequest =
    {
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        /// The PaymentMethod to insert into the forwarded request. Forwarding previously consumed PaymentMethods is allowed.
        PaymentMethod: string
        /// The field kinds to be replaced in the forwarded request.
        Replacements: ForwardingRequestReplacements list
        /// Context about the request from Stripe's servers to the destination endpoint.
        RequestContext: ForwardedRequestContext option
        /// The request that was sent to the destination endpoint. We redact any sensitive fields.
        RequestDetails: ForwardedRequestDetails option
        /// The response that the destination endpoint returned to us. We redact any sensitive fields.
        ResponseDetails: ForwardedResponseDetails option
        /// The destination URL for the forwarded request. Must be supported by the config.
        Url: string option
    }

module ForwardingRequest =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "forwarding.request"

    let create
        (
            created: DateTime,
            id: string,
            livemode: bool,
            paymentMethod: string,
            replacements: ForwardingRequestReplacements list,
            requestContext: ForwardedRequestContext option,
            requestDetails: ForwardedRequestDetails option,
            responseDetails: ForwardedResponseDetails option,
            url: string option,
            metadata: Map<string, string> option option
        ) : ForwardingRequest
        =
        {
          Created = created
          Id = id
          Livemode = livemode
          PaymentMethod = paymentMethod
          Replacements = replacements
          RequestContext = requestContext
          RequestDetails = requestDetails
          ResponseDetails = responseDetails
          Url = url
          Metadata = metadata |> Option.flatten
        }

