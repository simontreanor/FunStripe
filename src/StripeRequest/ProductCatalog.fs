namespace StripeRequest.ProductCatalog

open FunStripe
open System.Text.Json.Serialization
open Stripe.ProductCatalog
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.5.0")>]
module ProductCatalogTrialOffers =

    type ListOptions =
        {
            /// Only return trial offers that are active (`true`) or archived (`false`). If omitted, both active and archived trial offers are returned.
            [<Config.Query>]
            Active: bool option
            /// Only return trial offers that were created during the given date interval.
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
            /// Only return trial offers that reference these prices (during the trial period).
            [<Config.Query>]
            Prices: string list option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    type ListOptions with
        static member New(?active: bool, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?prices: string list, ?startingAfter: string) =
            {
                Active = active
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Prices = prices
                StartingAfter = startingAfter
            }

    type Create'DurationRelative =
        {
            /// The number of recurring price's interval to apply for the trial period.
            [<Config.Form>]
            Iterations: int option
        }

    type Create'DurationRelative with
        static member New(?iterations: int) =
            {
                Iterations = iterations
            }

    type Create'DurationType = | Relative

    type Create'Duration =
        {
            /// The relative duration of the trial period computed as the number of recurring price intervals.
            [<Config.Form>]
            Relative: Create'DurationRelative option
            /// Specifies how the trial offer duration is determined.
            [<Config.Form>]
            Type: Create'DurationType option
        }

    type Create'Duration with
        static member New(?relative: Create'DurationRelative, ?type': Create'DurationType) =
            {
                Relative = relative
                Type = type'
            }

    type Create'EndBehaviorTransition =
        {
            /// The price to transition the recurring item to when the trial offer ends.
            [<Config.Form>]
            Price: string option
        }

    type Create'EndBehaviorTransition with
        static member New(?price: string) =
            {
                Price = price
            }

    type Create'EndBehavior =
        {
            /// The transition to apply when the trial offer ends.
            [<Config.Form>]
            Transition: Create'EndBehaviorTransition option
        }

    type Create'EndBehavior with
        static member New(?transition: Create'EndBehaviorTransition) =
            {
                Transition = transition
            }

    type CreateOptions =
        {
            /// Whether the trial offer can be used for new subscriptions. Defaults to true.
            [<Config.Form>]
            Active: bool option
            /// Duration of one service period of the trial.
            [<Config.Form>]
            Duration: Create'Duration
            /// Define behavior that occurs at the end of the trial.
            [<Config.Form>]
            EndBehavior: Create'EndBehavior
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// A brief description of the trial offer, hidden from customers.
            [<Config.Form>]
            Nickname: string option
            /// Price configuration during the trial period (amount, billing scheme, etc).
            [<Config.Form>]
            Price: string
        }

    type CreateOptions with
        static member New(duration: Create'Duration, endBehavior: Create'EndBehavior, price: string, ?active: bool, ?expand: string list, ?nickname: string) =
            {
                Duration = duration
                EndBehavior = endBehavior
                Price = price
                Active = active
                Expand = expand
                Nickname = nickname
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

    type UpdateOptions =
        {
            [<Config.Path>]
            Id: string
            /// Whether the trial offer can be used for new purchases.
            [<Config.Form>]
            Active: bool option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type UpdateOptions with
        static member New(id: string, ?active: bool, ?expand: string list) =
            {
                Id = id
                Active = active
                Expand = expand
            }

    ///<p>Returns a list of trial offers.</p>
    let List settings (options: ListOptions) =
        let qs = [("active", options.Active |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("prices", options.Prices |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/product_catalog/trial_offers"
        |> RestApi.getAsync<StripeList<ProductCatalogTrialOffer>> settings qs

    ///<p>Creates a trial offer.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/product_catalog/trial_offers"
        |> RestApi.postAsync<_, ProductCatalogTrialOffer> settings (Map.empty) options

    ///<p>Retrieves the trial offer with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/product_catalog/trial_offers/{options.Id}"
        |> RestApi.getAsync<ProductCatalogTrialOffer> settings qs

    ///<p>Updates the specified trial offer by setting the values of the parameters passed. Any parameters not provided are left unchanged.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/product_catalog/trial_offers/{options.Id}"
        |> RestApi.postAsync<_, ProductCatalogTrialOffer> settings (Map.empty) options

