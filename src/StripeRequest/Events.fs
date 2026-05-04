namespace StripeRequest.Events

open FunStripe
open System.Text.Json.Serialization
open Stripe.Event
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
module Events =

    type ListOptions =
        {
            /// Only return events that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            /// Filter events by whether all webhooks were successfully delivered. If false, events which are still pending or have failed all delivery attempts to a webhook endpoint will be returned.
            [<Config.Query>]
            DeliverySuccess: bool option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// A string containing a specific event name, or group of events using * as a wildcard. The list will be filtered to include only events with a matching event property.
            [<Config.Query>]
            Type: string option
            /// An array of up to 20 strings containing specific event names. The list will be filtered to include only events with a matching event property. You may pass either `type` or `types`, but not both.
            [<Config.Query>]
            Types: string list option
        }

    type ListOptions with
        static member New(?created: int, ?deliverySuccess: bool, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?type': string, ?types: string list) =
            {
                Created = created
                DeliverySuccess = deliverySuccess
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Type = type'
                Types = types
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Id: string
        }

    type RetrieveOptions with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    ///<p>List events, going back up to 30 days. Each event data is rendered according to Stripe API version at its creation time, specified in <a href="https://docs.stripe.com/api/events/object">event object</a> <code>api_version</code> attribute (not according to your current Stripe API version or <code>Stripe-Version</code> header).</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("delivery_success", options.DeliverySuccess |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("type", options.Type |> box); ("types", options.Types |> box)] |> Map.ofList
        $"/v1/events"
        |> RestApi.getAsync<StripeList<Event>> settings qs

    ///<p>Retrieves the details of an event if it was created in the last 30 days. Supply the unique identifier of the event, which you might have received in a webhook.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/events/{options.Id}"
        |> RestApi.getAsync<Event> settings qs

