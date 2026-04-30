namespace StripeRequest.Apple

open FunStripe
open System.Text.Json.Serialization
open Stripe.ApplePayDomain
open Stripe.Deleted
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
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

    module ListOptions =
        let create
            (
                domainName: string option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option
            ) : ListOptions
            =
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

    module CreateOptions =
        let create
            (
                domainName: string
            ) : CreateOptions
            =
            {
              DomainName = domainName
              Expand = None
            }

    type DeleteOptions =
        { [<Config.Path>]
          Domain: string }

    module DeleteOptions =
        let create
            (
                domain: string
            ) : DeleteOptions
            =
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

    module RetrieveOptions =
        let create
            (
                domain: string
            ) : RetrieveOptions
            =
            {
              Domain = domain
              Expand = None
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

