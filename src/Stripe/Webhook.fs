namespace Stripe.Webhook

open System.Text.Json.Serialization
open FunStripe
open System

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type WebhookEndpointStatus =
    | Enabled
    | Disabled

/// You can configure [webhook endpoints](https://docs.stripe.com/webhooks/) via the API to be
/// notified about events that happen in your Stripe account or connected
/// accounts.
/// Most users configure webhooks from [the dashboard](https://dashboard.stripe.com/webhooks), which provides a user interface for registering and testing your webhook endpoints.
/// Related guide: [Setting up webhooks](https://docs.stripe.com/webhooks/configure)
type WebhookEndpoint =
    {
        /// The API version events are rendered as for this webhook endpoint.
        ApiVersion: string option
        /// The ID of the associated Connect application.
        Application: string option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// An optional description of what the webhook is used for.
        Description: string option
        /// The list of events to enable for this endpoint. `['*']` indicates that all events are enabled, except those that require explicit selection.
        EnabledEvents: string list
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        /// The endpoint's secret, used to generate [webhook signatures](https://docs.stripe.com/webhooks/signatures). Only returned at creation.
        Secret: string option
        /// The status of the webhook. It can be `enabled` or `disabled`.
        Status: WebhookEndpointStatus
        /// The URL of the webhook endpoint.
        Url: string
    }

module WebhookEndpoint =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "webhook_endpoint"

