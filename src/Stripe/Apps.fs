namespace Stripe.Apps

open System.Text.Json.Serialization
open FunStripe
open System

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
type SecretServiceResourceScopeType =
    | Account
    | User

type SecretServiceResourceScope =
    {
        /// The secret scope type.
        Type: SecretServiceResourceScopeType
        /// The user ID, if type is set to "user"
        User: string option
    }

type SecretServiceResourceScope with
    static member New(``type``: SecretServiceResourceScopeType, ?user: string) =
        {
            Type = ``type``
            User = user
        }

/// Secret Store is an API that allows Stripe Apps developers to securely persist secrets for use by UI Extensions and app backends.
/// The primary resource in Secret Store is a `secret`. Other apps can't view secrets created by an app. Additionally, secrets are scoped to provide further permission control.
/// All Dashboard users and the app backend share `account` scoped secrets. Use the `account` scope for secrets that don't change per-user, like a third-party API key.
/// A `user` scoped secret is accessible by the app backend and one specific Dashboard user. Use the `user` scope for per-user secrets like per-user OAuth tokens, where different users might have different permissions.
/// Related guide: [Store data between page reloads](https://docs.stripe.com/stripe-apps/store-auth-data-custom-objects)
type AppsSecret =
    {
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// If true, indicates that this secret has been deleted
        Deleted: bool option
        /// The Unix timestamp for the expiry time of the secret, after which the secret deletes.
        ExpiresAt: DateTime option
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// A name for the secret that's unique within the scope.
        Name: string
        /// The plaintext secret value to be stored.
        Payload: string option
        Scope: SecretServiceResourceScope
    }

type AppsSecret with
    static member New(created: DateTime, expiresAt: DateTime option, id: string, livemode: bool, name: string, scope: SecretServiceResourceScope, ?deleted: bool, ?payload: string option) =
        {
            Created = created
            ExpiresAt = expiresAt
            Id = id
            Livemode = livemode
            Name = name
            Scope = scope
            Deleted = deleted
            Payload = payload |> Option.flatten
        }

module AppsSecret =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "apps.secret"

