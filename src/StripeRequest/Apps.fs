namespace StripeRequest.Apps

open FunStripe
open System.Text.Json.Serialization
open Stripe.Apps
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "3.0.0")>]
module AppsInstalls =

    type ListOptions =
        {
            /// Only return installs made by this account. Only useful to app developers and embedding platforms, whose lists span the accounts that installed their app.
            [<Config.Query>]
            Account: string option
            /// Only return installs for the app specified by this app ID.
            [<Config.Query>]
            App: string option
            /// Only return installs whose installer must authorize pending permissions, content security policy entries, or endpoints.
            [<Config.Query>]
            ApprovalRequired: bool option
            /// Only return installs in the distribution channel specified by this channel name.
            [<Config.Query>]
            Channel: string option
            /// Only return app installs that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            /// Only return installs created by the embedding platform specified by this account ID.
            [<Config.Query>]
            CreatedBy: string option
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
            /// Only return installs with the given status.
            [<Config.Query>]
            Status: string option
        }

    type ListOptions with
        static member New(?account: string, ?app: string, ?approvalRequired: bool, ?channel: string, ?created: int, ?createdBy: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
            {
                Account = account
                App = app
                ApprovalRequired = approvalRequired
                Channel = channel
                Created = created
                CreatedBy = createdBy
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Status = status
            }

    type Create'Channel =
        | PrivateLive
        | PrivateTest
        | Public
        | Testing

    type CreateOptions =
        {
            /// The ID of the app to install.
            [<Config.Form>]
            App: string
            /// The distribution channel to install from. Defaults to `public`. A private app must be installed on `private_test` or `private_live`, matching the mode of the API key.
            [<Config.Form>]
            Channel: Create'Channel option
            /// For OAuth apps, the PKCE code challenge used to issue the `auth_code` returned on the install. Must be 43 to 128 characters and contain only letters, numbers, `-`, `.`, `_`, and `~`. Only applies to installs made by the app developer or an embedding platform; ignored when an account installs its own private app.
            [<Config.Form>]
            CodeChallenge: string option
            /// The method used to derive `code_challenge`. Required when `code_challenge` is provided, and must be `S256`.
            [<Config.Form>]
            CodeChallengeMethod: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type CreateOptions with
        static member New(app: string, ?channel: Create'Channel, ?codeChallenge: string, ?codeChallengeMethod: string, ?expand: string list) =
            {
                App = app
                Channel = channel
                CodeChallenge = codeChallenge
                CodeChallengeMethod = codeChallengeMethod
                Expand = expand
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
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type UpdateOptions with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    ///<p>Returns a list of app installs. An app developer or embedding platform filtering by its own app sees the installs across the accounts that installed it; other callers see the installs on their own account. The key selects the environment: a live key lists live installs, a sandbox API key lists the installs on that sandbox, and the key of an app’s managed sandbox filtering by <code>app</code> lists that app’s installs across every sandbox. For existing accounts that still use legacy test mode, a test mode key lists legacy test mode installs.</p>
    let List settings (options: ListOptions) =
        let qs = [("account", options.Account |> box); ("app", options.App |> box); ("approval_required", options.ApprovalRequired |> box); ("channel", options.Channel |> box); ("created", options.Created |> box); ("created_by", options.CreatedBy |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/apps/installs"
        |> RestApi.getAsync<StripeList<AppsInstall>> settings qs

    ///<p>Creates an app install. An account installs its own private app with its own key; public and testing installs are made from the Dashboard. An app developer or embedding platform acting on a connected account through <code>Stripe-Account</code> installs or reinstalls its app there. Creating an install for a private app that is already installed at the channel’s current version with nothing pending returns the existing install.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/apps/installs"
        |> RestApi.postAsync<_, AppsInstall> settings (Map.empty) options

    ///<p>Retrieves an app install. The installing account, the app’s developer (with the keys of the account that owns the app or of the app’s managed sandbox), and the embedding platform that created the install can retrieve it.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/apps/installs/{options.Id}"
        |> RestApi.getAsync<AppsInstall> settings qs

    ///<p>Reauthorizes an app install. The installer grants the permissions, content security policy entries, and endpoints that the latest published version of the app requests. An account reauthorizes its own installs on any channel with its own key; app developers and embedding platforms reauthorize installs on connected accounts through <code>Stripe-Account</code>. For private apps, install a new version from the Dashboard to grant its permissions.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/apps/installs/{options.Id}"
        |> RestApi.postAsync<_, AppsInstall> settings (Map.empty) options

module AppsInstallsUninstall =

    type UninstallOptions =
        {
            [<Config.Path>]
            Id: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type UninstallOptions with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    ///<p>Uninstalls an app from the account that installed it.</p>
    let Uninstall settings (options: UninstallOptions) =
        $"/v1/apps/installs/{options.Id}/uninstall"
        |> RestApi.postAsync<_, AppsInstall> settings (Map.empty) options

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

    type ListOptions with
        static member New(scope: Map<string, string>, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Scope = scope
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
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

    type Create'Scope with
        static member New(?type': Create'ScopeType, ?user: string) =
            {
                Type = type'
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

    type CreateOptions with
        static member New(name: string, payload: string, scope: Create'Scope, ?expand: string list, ?expiresAt: DateTime) =
            {
                Name = name
                Payload = payload
                Scope = scope
                Expand = expand
                ExpiresAt = expiresAt
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

    type DeleteWhere'Scope with
        static member New(?type': DeleteWhere'ScopeType, ?user: string) =
            {
                Type = type'
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

    type DeleteWhereOptions with
        static member New(name: string, scope: DeleteWhere'Scope, ?expand: string list) =
            {
                Name = name
                Scope = scope
                Expand = expand
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

    type FindOptions with
        static member New(name: string, scope: Map<string, string>, ?expand: string list) =
            {
                Name = name
                Scope = scope
                Expand = expand
            }

    ///<p>Finds a secret in the secret store by name and scope.</p>
    let Find settings (options: FindOptions) =
        let qs = [("expand", options.Expand |> box); ("name", options.Name |> box); ("scope", options.Scope |> box)] |> Map.ofList
        $"/v1/apps/secrets/find"
        |> RestApi.getAsync<AppsSecret> settings qs

