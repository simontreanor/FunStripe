namespace StripeRequest.Apps

open FunStripe
open System.Text.Json.Serialization
open Stripe.Apps
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
module AppsSecrets =

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
            /// Specifies the scoping of the secret. Requests originating from UI extensions can only access account-scoped secrets or secrets scoped to their own user.
            [<Config.Query>]
            Scope: Map<string, string>
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    module ListOptions =
        let create
            (
                scope: Map<string, string>
            ) : ListOptions
            =
            {
              Scope = scope
              EndingBefore = None
              Expand = None
              Limit = None
              StartingAfter = None
            }

    type Create'ScopeType =
        | Account
        | User

    type Create'Scope =
        {
            /// The secret scope type.
            [<Config.Form>]
            Type: Create'ScopeType option
            /// The user ID. This field is required if `type` is set to `user`, and should not be provided if `type` is set to `account`.
            [<Config.Form>]
            User: string option
        }

    module Create'Scope =
        let create
            (
                ``type``: Create'ScopeType option,
                user: string option
            ) : Create'Scope
            =
            {
              Type = ``type``
              User = user
            }

    type CreateOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The Unix timestamp for the expiry time of the secret, after which the secret deletes.
            [<Config.Form>]
            ExpiresAt: DateTime option
            /// A name for the secret that's unique within the scope.
            [<Config.Form>]
            Name: string
            /// The plaintext secret value to be stored.
            [<Config.Form>]
            Payload: string
            /// Specifies the scoping of the secret. Requests originating from UI extensions can only access account-scoped secrets or secrets scoped to their own user.
            [<Config.Form>]
            Scope: Create'Scope
        }

    module CreateOptions =
        let create
            (
                name: string,
                payload: string,
                scope: Create'Scope
            ) : CreateOptions
            =
            {
              Name = name
              Payload = payload
              Scope = scope
              Expand = None
              ExpiresAt = None
            }

    ///<p>List all secrets stored on the given scope.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("scope", options.Scope |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/apps/secrets"
        |> RestApi.getAsync<StripeList<AppsSecret>> settings qs

    ///<p>Create or replace a secret in the secret store.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/apps/secrets"
        |> RestApi.postAsync<_, AppsSecret> settings (Map.empty) options

module AppsSecretsDelete =

    type DeleteWhere'ScopeType =
        | Account
        | User

    type DeleteWhere'Scope =
        {
            /// The secret scope type.
            [<Config.Form>]
            Type: DeleteWhere'ScopeType option
            /// The user ID. This field is required if `type` is set to `user`, and should not be provided if `type` is set to `account`.
            [<Config.Form>]
            User: string option
        }

    module DeleteWhere'Scope =
        let create
            (
                ``type``: DeleteWhere'ScopeType option,
                user: string option
            ) : DeleteWhere'Scope
            =
            {
              Type = ``type``
              User = user
            }

    type DeleteWhereOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// A name for the secret that's unique within the scope.
            [<Config.Form>]
            Name: string
            /// Specifies the scoping of the secret. Requests originating from UI extensions can only access account-scoped secrets or secrets scoped to their own user.
            [<Config.Form>]
            Scope: DeleteWhere'Scope
        }

    module DeleteWhereOptions =
        let create
            (
                name: string,
                scope: DeleteWhere'Scope
            ) : DeleteWhereOptions
            =
            {
              Name = name
              Scope = scope
              Expand = None
            }

    ///<p>Deletes a secret from the secret store by name and scope.</p>
    let DeleteWhere settings (options: DeleteWhereOptions) =
        $"/v1/apps/secrets/delete"
        |> RestApi.postAsync<_, AppsSecret> settings (Map.empty) options

module AppsSecretsFind =

    type FindOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A name for the secret that's unique within the scope.
            [<Config.Query>]
            Name: string
            /// Specifies the scoping of the secret. Requests originating from UI extensions can only access account-scoped secrets or secrets scoped to their own user.
            [<Config.Query>]
            Scope: Map<string, string>
        }

    module FindOptions =
        let create
            (
                name: string,
                scope: Map<string, string>
            ) : FindOptions
            =
            {
              Name = name
              Scope = scope
              Expand = None
            }

    ///<p>Finds a secret in the secret store by name and scope.</p>
    let Find settings (options: FindOptions) =
        let qs = [("expand", options.Expand |> box); ("name", options.Name |> box); ("scope", options.Scope |> box)] |> Map.ofList
        $"/v1/apps/secrets/find"
        |> RestApi.getAsync<AppsSecret> settings qs

