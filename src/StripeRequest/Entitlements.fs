namespace StripeRequest.Entitlements

open FunStripe
open System.Text.Json.Serialization
open Stripe.Entitlements
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module EntitlementsActiveEntitlements =

    type ListOptions =
        {
            /// The ID of the customer.
            [<Config.Query>]
            Customer: string
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
        static member New(customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Customer = customer
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    module ListOptions =
        let create
            (
                customer: string
            ) : ListOptions
            =
            {
              Customer = customer
              EndingBefore = None
              Expand = None
              Limit = None
              StartingAfter = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// The ID of the entitlement.
            [<Config.Path>]
            Id: string
        }

    type RetrieveOptions with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    module RetrieveOptions =
        let create
            (
                id: string
            ) : RetrieveOptions
            =
            {
              Id = id
              Expand = None
            }

    ///<p>Retrieve a list of active entitlements for a customer</p>
    let List settings (options: ListOptions) =
        let qs = [("customer", options.Customer |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/entitlements/active_entitlements"
        |> RestApi.getAsync<StripeList<EntitlementsActiveEntitlement>> settings qs

    ///<p>Retrieve an active entitlement</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/entitlements/active_entitlements/{options.Id}"
        |> RestApi.getAsync<EntitlementsActiveEntitlement> settings qs

module EntitlementsFeatures =

    type ListOptions =
        {
            /// If set, filter results to only include features with the given archive status.
            [<Config.Query>]
            Archived: bool option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// If set, filter results to only include features with the given lookup_key.
            [<Config.Query>]
            LookupKey: string option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    type ListOptions with
        static member New(?archived: bool, ?endingBefore: string, ?expand: string list, ?limit: int, ?lookupKey: string, ?startingAfter: string) =
            {
                Archived = archived
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                LookupKey = lookupKey
                StartingAfter = startingAfter
            }

    module ListOptions =
        let create
            (
                archived: bool option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                lookupKey: string option,
                startingAfter: string option
            ) : ListOptions
            =
            {
              Archived = archived
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              LookupKey = lookupKey
              StartingAfter = startingAfter
            }

    type CreateOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// A unique key you provide as your own system identifier. This may be up to 80 characters.
            [<Config.Form>]
            LookupKey: string
            /// Set of key-value pairs that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The feature's name, for your own purpose, not meant to be displayable to the customer.
            [<Config.Form>]
            Name: string
        }

    type CreateOptions with
        static member New(lookupKey: string, name: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                LookupKey = lookupKey
                Name = name
                Expand = expand
                Metadata = metadata
            }

    module CreateOptions =
        let create
            (
                lookupKey: string,
                name: string
            ) : CreateOptions
            =
            {
              LookupKey = lookupKey
              Name = name
              Expand = None
              Metadata = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// The ID of the feature.
            [<Config.Path>]
            Id: string
        }

    type RetrieveOptions with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    module RetrieveOptions =
        let create
            (
                id: string
            ) : RetrieveOptions
            =
            {
              Id = id
              Expand = None
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Id: string
            /// Inactive features cannot be attached to new products and will not be returned from the features list endpoint.
            [<Config.Form>]
            Active: bool option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of key-value pairs that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The feature's name, for your own purpose, not meant to be displayable to the customer.
            [<Config.Form>]
            Name: string option
        }

    type UpdateOptions with
        static member New(id: string, ?active: bool, ?expand: string list, ?metadata: Map<string, string>, ?name: string) =
            {
                Id = id
                Active = active
                Expand = expand
                Metadata = metadata
                Name = name
            }

    module UpdateOptions =
        let create
            (
                id: string
            ) : UpdateOptions
            =
            {
              Id = id
              Active = None
              Expand = None
              Metadata = None
              Name = None
            }

    ///<p>Retrieve a list of features</p>
    let List settings (options: ListOptions) =
        let qs = [("archived", options.Archived |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("lookup_key", options.LookupKey |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/entitlements/features"
        |> RestApi.getAsync<StripeList<EntitlementsFeature>> settings qs

    ///<p>Creates a feature</p>
    let Create settings (options: CreateOptions) =
        $"/v1/entitlements/features"
        |> RestApi.postAsync<_, EntitlementsFeature> settings (Map.empty) options

    ///<p>Retrieves a feature</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/entitlements/features/{options.Id}"
        |> RestApi.getAsync<EntitlementsFeature> settings qs

    ///<p>Update a feature’s metadata or permanently deactivate it.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/entitlements/features/{options.Id}"
        |> RestApi.postAsync<_, EntitlementsFeature> settings (Map.empty) options

