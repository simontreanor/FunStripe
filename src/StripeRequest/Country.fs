namespace StripeRequest.Country

open FunStripe
open System.Text.Json.Serialization
open Stripe.CountrySpec
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
module CountrySpecs =

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
            [<Config.Path>]
            Country: IsoTypes.IsoCountryCode
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    type RetrieveOptions with
        static member New(country: IsoTypes.IsoCountryCode, ?expand: string list) =
            {
                Country = country
                Expand = expand
            }

    ///<p>Lists all Country Spec objects available in the API.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/country_specs"
        |> RestApi.getAsync<StripeList<CountrySpec>> settings qs

    ///<p>Returns a Country Spec for a given Country code.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/country_specs/{options.Country}"
        |> RestApi.getAsync<CountrySpec> settings qs

