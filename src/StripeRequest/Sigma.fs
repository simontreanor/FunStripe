namespace StripeRequest.Sigma

open FunStripe
open System.Text.Json.Serialization
open Stripe.Sigma
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
module SigmaScheduledQueryRuns =

    type ListOptions =
        {
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
        }

    type ListOptions with
        static member New(?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            ScheduledQueryRun: string
        }

    type RetrieveOptions with
        static member New(scheduledQueryRun: string, ?expand: string list) =
            {
                ScheduledQueryRun = scheduledQueryRun
                Expand = expand
            }

    ///<p>Returns a list of scheduled query runs.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/sigma/scheduled_query_runs"
        |> RestApi.getAsync<StripeList<ScheduledQueryRun>> settings qs

    ///<p>Retrieves the details of an scheduled query run.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/sigma/scheduled_query_runs/{options.ScheduledQueryRun}"
        |> RestApi.getAsync<ScheduledQueryRun> settings qs

