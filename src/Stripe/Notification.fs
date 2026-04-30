namespace Stripe.Notification

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type NotificationEventRequest =
    {
        /// ID of the API request that caused the event. If null, the event was automatic (e.g., Stripe's automatic subscription handling). Request logs are available in the [dashboard](https://dashboard.stripe.com/logs), but currently not in the API.
        Id: string option
        /// The idempotency key transmitted during the request, if any. *Note: This property is populated only for events on or after May 23, 2017*.
        IdempotencyKey: string option
    }

type NotificationEventData =
    {
        /// Object containing the API resource relevant to the event. For example, an `invoice.created` event will have a full [invoice object](https://api.stripe.com#invoice_object) as the value of the object key.
        Object: string
        /// Object containing the names of the updated attributes and their values prior to the event (only included in events of type `*.updated`). If an array attribute has any updated elements, this object contains the entire array. In Stripe API versions 2017-04-06 or earlier, an updated array attribute in this object includes only the updated array elements.
        PreviousAttributes: string option
    }

