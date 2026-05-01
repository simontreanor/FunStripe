namespace StripeRequest.Apple

open FunStripe
open System.Text.Json.Serialization
open Stripe.ApplePayDomain
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
module ApplePayDomains =

    type ListOptions =
        {
            [<Config.Query>]
            DomainName: string option
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
        static member New(?domainName: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                DomainName = domainName
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    type CreateOptions =
        {
            [<Config.Form>]
            DomainName: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type CreateOptions with
        static member New(domainName: string, ?expand: string list) =
            {
                DomainName = domainName
                Expand = expand
            }

    type DeleteOptions =
        { [<Config.Path>]
          Domain: string }

    type DeleteOptions with
        static member New(domain: string) =
            {
                Domain = domain
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            Domain: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    type RetrieveOptions with
        static member New(domain: string, ?expand: string list) =
            {
                Domain = domain
                Expand = expand
            }

    ///<p>List apple pay domains.</p>
    let List settings (options: ListOptions) =
        let qs = [("domain_name", options.DomainName |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/apple_pay/domains"
        |> RestApi.getAsync<StripeList<ApplePayDomain>> settings qs

    ///<p>Create an apple pay domain.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/apple_pay/domains"
        |> RestApi.postAsync<_, ApplePayDomain> settings (Map.empty) options

    ///<p>Delete an apple pay domain.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/apple_pay/domains/{options.Domain}"
        |> RestApi.deleteAsync<DeletedApplePayDomain> settings (Map.empty)

    ///<p>Retrieve an apple pay domain.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/apple_pay/domains/{options.Domain}"
        |> RestApi.getAsync<ApplePayDomain> settings qs

