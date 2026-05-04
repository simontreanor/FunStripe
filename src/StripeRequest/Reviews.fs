namespace StripeRequest.Reviews

open FunStripe
open System.Text.Json.Serialization
open Stripe.Review
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
module Reviews =

    type ListOptions =
        {
            /// Only return reviews that were created during the given date interval.
            [<Config.Query>]
            Created: int option
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
        static member New(?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Created = created
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
            Review: string
        }

    type RetrieveOptions with
        static member New(review: string, ?expand: string list) =
            {
                Review = review
                Expand = expand
            }

    ///<p>Returns a list of <code>Review</code> objects that have <code>open</code> set to <code>true</code>. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/reviews"
        |> RestApi.getAsync<StripeList<Review>> settings qs

    ///<p>Retrieves a <code>Review</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/reviews/{options.Review}"
        |> RestApi.getAsync<Review> settings qs

module ReviewsApprove =

    type ApproveOptions =
        {
            [<Config.Path>]
            Review: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type ApproveOptions with
        static member New(review: string, ?expand: string list) =
            {
                Review = review
                Expand = expand
            }

    ///<p>Approves a <code>Review</code> object, closing it and removing it from the list of reviews.</p>
    let Approve settings (options: ApproveOptions) =
        $"/v1/reviews/{options.Review}/approve"
        |> RestApi.postAsync<_, Review> settings (Map.empty) options

